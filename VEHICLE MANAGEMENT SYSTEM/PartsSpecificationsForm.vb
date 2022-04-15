Public Class PartsSpecificationsForm
    Private SelectionFilter = ""
    Private WorkOrderPartsDataGridViewInitialized = False
    Private WorkOrderPartsFieldsToSelect = ""
    Private WorkOrderPartsSelectionFilter = ""
    Private WorkOrderPartsSelectionOrder = ""
    Private WorkOrderPartsRecordCount As Integer = -1
    Private CurrentWorkOrderPartsDataGridViewRow As Integer = -1
    Private CurrentWorkOrderPartID As Integer = -1


    Private CurrentWorkOrderPartSpecificationsID = -1
    Private CurrentVolumeSpecificationID = -1

    Private CurrentPartNumberSpecificationID = -1
    Private CurrentPartSpecificationsID = -1

    Private CurrentJobID = -1
    Private CurrentMasterCodeBookID As Integer = -1
    Private SavedCallingForm As Form
    Private PurposeOfEntry = ""
    Private BackToEditMode = False

    Private Sub PartSpecificationsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' NOTE CodeVehiclesTable WILL DETERMINE ALL LINKS TO THE SPECIFICS OF THE PART
        ' INPUT WILL THEN BE MASTERCODEBOOKID AND VEHICLEID
        Me.Text = Tunnel3
        SavedCallingForm = CallingForm
        CurrentMasterCodeBookID = Tunnel2

        ' Initialize TEXT BOXES TO DEFINE WHAT TYPE OF DATA TO STORE
        FluidSpecificationsTextBox.Text = ""
        SpecifiedPartNumberTextBox.Text = ""
        SpecifiedQuantityTextBox.Text = ""
        SpecifiedUnitTextBox.Text = ""

        WorkOrderPartsSelectionFilter = " WHERE WorkOrderPartID_AutoNumber = " & CurrentMasterCodeBookID.ToString
    End Sub

    Private Sub FillWorkOrderPartsDataGridView()
        WorkOrderPartsFieldsToSelect =
" 
SELECT WorkOrderPartsTable.WorkOrderPartID_AutoNumber, 
WorkOrderPartsTable.Quantity_Integer, 
WorkOrderPartsTable.Unit_ShortText3, 
MasterCodeBookTable.MasterCodeBookID_Autonumber, 
MasterCodeBookTable.SystemDesc_ShortText100Fld, 
InformationsHeadersTable.InformationsHeaderID_AutoNumber, 
InformationsHeadersTable.InformationsHeaderDescription_ShortText255,
CodeVehiclesTable.CodeVehicleID_AutoNumber, 
SpecificationsTable.SpecificationID_AutoNumber, 
SpecificationsTable.PartSpecifications_ShortText255, 
PartNumberSpecificationsTable.PartNumber_ShortText25, 
WorkOrderPartsTable.CodeVehicleID_LongInteger, 
VolumeSpecificationsTable.VolumeSpecificationID_AutoNumber, 
VolumeSpecificationsTable.InformationsHeaderID_LongInteger, 
VolumeSpecificationsTable.VolumeQuantity_Double, 

VolumeSpecificationsTable.VolumeUnit_ShortText3
FROM (((WorkOrderPartsTable LEFT JOIN MasterCodeBookTable ON WorkOrderPartsTable.MasterCodeBookID_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) LEFT JOIN InformationsHeadersTable ON WorkOrderPartsTable.InformationsHeaderID_LongInteger = InformationsHeadersTable.InformationsHeaderID_AutoNumber) LEFT JOIN ((CodeVehiclesTable LEFT JOIN SpecificationsTable ON CodeVehiclesTable.CodeVehicleID_AutoNumber = SpecificationsTable.CodeVehicleID_LongInteger) LEFT JOIN PartNumberSpecificationsTable ON CodeVehiclesTable.CodeVehicleID_AutoNumber = PartNumberSpecificationsTable.CodeVehicleID_LongInteger) ON WorkOrderPartsTable.CodeVehicleID_LongInteger = CodeVehiclesTable.CodeVehicleID_AutoNumber) LEFT JOIN VolumeSpecificationsTable ON CodeVehiclesTable.CodeVehicleID_AutoNumber = VolumeSpecificationsTable.CodeVehicleID_LongInteger
"


        MySelection = WorkOrderPartsFieldsToSelect & WorkOrderPartsSelectionFilter

        JustExecuteMySelection()
        WorkOrderPartsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        WorkOrderPartsRecordCount = RecordCount
        WorkOrderPartsDataGridView.Visible = False
    End Sub
    Private Sub WorkOrderPartsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles WorkOrderPartsDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If Me.Enabled = False Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If WorkOrderPartsRecordCount = 0 Then Exit Sub


        CurrentWorkOrderPartsDataGridViewRow = e.RowIndex
        FillField(CurrentWorkOrderPartID, WorkOrderPartsDataGridView.Item("WorkOrderPartID_AutoNumber", CurrentWorkOrderPartsDataGridViewRow).Value)
        FillField(CurrentPartSpecificationsID, WorkOrderPartsDataGridView.Item("SpecificationID_AutoNumber", CurrentWorkOrderPartsDataGridViewRow).Value)
        FillField(CurrentVolumeSpecificationID, WorkOrderPartsDataGridView.Item("VolumeSpecificationID_AutoNumber", CurrentWorkOrderPartsDataGridViewRow).Value)
        FillField(CurrentJobID, WorkOrderPartsDataGridView.Item("InformationsHeaderID_AutoNumber", CurrentWorkOrderPartsDataGridViewRow).Value)

        LoadPartDetails()
        If Me.Enabled = False Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        '        If WorkOrderPartsRecordCount = 0 Then Exit Sub


    End Sub
    Private Sub LoadPartDetails()

        SaveToolStripMenuItem.Visible = True
        FillField(SpecifiedPartNumberTextBox.Text, WorkOrderPartsDataGridView.Item("PartNumber_ShortText25", CurrentWorkOrderPartsDataGridViewRow).Value)
        FillField(FluidSpecificationsTextBox.Text, WorkOrderPartsDataGridView.Item("PartSpecifications_ShortText255", CurrentWorkOrderPartsDataGridViewRow).Value)
        FillField(ServiceToPerformTextBox.Text, WorkOrderPartsDataGridView.Item("PartSpecifications_ShortText255", CurrentWorkOrderPartsDataGridViewRow).Value)
        FillField(SpecifiedQuantityTextBox.Text, WorkOrderPartsDataGridView.Item("VolumeQuantity_Double", CurrentWorkOrderPartsDataGridViewRow).Value)
        FillField(SpecifiedUnitTextBox.Text, WorkOrderPartsDataGridView.Item("VolumeUnit_ShortText3", CurrentWorkOrderPartsDataGridViewRow).Value)

    End Sub

    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        SaveChanges()
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub
    Private Sub SaveVolumeSpecsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        SaveChanges()
    End Sub

    Private Sub SaveChanges()
        BackToEditMode = False
        If AChangeInPartNumberSpecificationOccured() Then
            RegisterPartNumberSpecificationChanges()
        End If
        If BackToEditMode Then Exit Sub
        If AChangeInPartSpecificationsOccured() Then
            RegisterPartSpecificationsChanges()
        End If
        If BackToEditMode Then Exit Sub
        If AChangeInVolumeSpecificationsOccured() Then
            RegisterVolumeSpecificationsChanges()
        End If
        FillWorkOrderPartsDataGridView()
        SaveToolStripMenuItem.Visible = False
    End Sub
    Private Function AChangeInPartNumberSpecificationOccured()
        If CurrentWorkOrderPartsDataGridViewRow > -1 Then
            If TheseAreNotEqual(SpecifiedPartNumberTextBox.Text, WorkOrderPartsDataGridView.Item("PartNumber_ShortText25", CurrentWorkOrderPartsDataGridViewRow).Value, PurposeOfEntry) Then Return True
        Else
            If IsNotEmpty(SpecifiedPartNumberTextBox.Text) Then Return True
        End If
        Return False
    End Function
    Private Function AChangeInPartSpecificationsOccured()
        If CurrentWorkOrderPartsDataGridViewRow > -1 Then
            If TheseAreNotEqual(FluidSpecificationsTextBox.Text, WorkOrderPartsDataGridView.Item("PartSpecifications_ShortText255", CurrentWorkOrderPartsDataGridViewRow).Value, PurposeOfEntry) Then Return True
        Else
            If IsNotEmpty(FluidSpecificationsTextBox.Text) Then Return True
        End If
        Return False
    End Function

    Private Function AChangeInVolumeSpecificationsOccured()
        If CurrentWorkOrderPartsDataGridViewRow > -1 Then
            If TheseAreNotEqual(SpecifiedQuantityTextBox.Text, WorkOrderPartsDataGridView.Item("VolumeQuantity_Double", CurrentWorkOrderPartsDataGridViewRow).Value, PurposeOfEntry) Then Return True
            If TheseAreNotEqual(SpecifiedUnitTextBox.Text, WorkOrderPartsDataGridView.Item("VolumeUnit_ShortText3", CurrentWorkOrderPartsDataGridViewRow).Value, PurposeOfEntry) Then Return True
        Else
            If IsNotEmpty(SpecifiedQuantityTextBox.Text) Then Return True
            If IsNotEmpty(SpecifiedUnitTextBox.Text) Then Return True
        End If
        Return False
    End Function

    Private Sub RegisterPartNumberSpecificationChanges()
        If MsgBox("Would you like to update Part Number specification for this part ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            If MsgBox("Disregard your part number specification changes ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                SpecifiedPartNumberTextBox.SelectAll()
                BackToEditMode = True
                Exit Sub
            End If
        End If
        MySelection = " Select top 1 * FROM SpecificationsTable WHERE PartSpecifications_ShortText255 = " & InQuotes(SpecifiedPartNumberTextBox.Text)
        JustExecuteMySelection()
        If RecordCount = 0 Then
            InsertNewPartSpecifications()
        Else
            UpdatePartSpecifications()
        End If



    End Sub
    Private Sub InsertNewPartNumberSpecification()
        Dim FieldsToUpdate = "  CodeVehicleID_LongInteger, " &
                                  "  PartNumber_ShortText25 "

        Dim FieldsData = CurrentCodeVehicleID.ToString & ",  " &
                                  InQuotes(SpecifiedPartNumberTextBox.Text)

        CurrentPartNumberSpecificationID = InsertNewRecord("PartNumberSpecificationsTable", FieldsToUpdate, FieldsData)
    End Sub
    Private Sub UpdatePartNumberSpecification()
        If MsgBox("About to replace original informations, Continue ?", MsgBoxStyle.YesNo) = vbNo Then
            Exit Sub
        End If
        Dim RecordFilter = " WHERE WorkOrderPartID_AutoNumber = " & CurrentWorkOrderPartID.ToString
        Dim SetCommand = " SET MasterCodeBookID_LongInteger = " & CurrentMasterCodeBookID.ToString & "," &
                                      "Unit_ShortText3 = " & Chr(34) & LTrim(Trim(SpecifiedUnitTextBox.Text)) & Chr(34) & "," &
                                      "Quantity_Integer = " & Val(SpecifiedQuantityTextBox.Text).ToString
        UpdateTable("WorkOrderPartsTable", SetCommand, RecordFilter)
    End Sub
    Private Sub RegisterPartSpecificationsChanges()
        If MsgBox("Would you like to update Part specifications for this part ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            If MsgBox("Disregard your part specifications changes ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                FluidSpecificationsTextBox.SelectAll()
                BackToEditMode = True
                Exit Sub
            End If
        End If
        MySelection = " Select top 1 * FROM SpecificationsTable WHERE CodeVehicleID_LongInteger = " & CurrentCodeVehicleID &
                        " AND PartSpecifications_ShortText255 = " & FluidSpecificationsTextBox.Text
        JustExecuteMySelection()
        If RecordCount = 0 Then
            InsertNewPartSpecifications()
        Else
            UpdatePartSpecifications()
        End If
    End Sub
    Private Sub InsertNewPartSpecifications()
        Dim FieldsToUpdate = "  PartSpecifications_ShortText255 "

        Dim FieldsData = InQuotes(SpecifiedPartNumberTextBox.Text)

        CurrentPartSpecificationsID = InsertNewRecord("SpecificationsTable", FieldsToUpdate, FieldsData)
    End Sub
    Private Sub UpdatePartSpecifications()
        If MsgBox("About to replace previous Specifications, Continue ?", MsgBoxStyle.YesNo) = vbNo Then
            Exit Sub
        End If
        Dim RecordFilter = " WHERE PartSpecificationsID_AutoNumber = " & CurrentPartSpecificationsID.ToString
        Dim SetCommand = " SET CodeVehicleID_LongInteger = " & CurrentCodeVehicleID.ToString & "," &
                          "PartSpecifications_ShortText255 = " & InQuotes(FluidSpecificationsTextBox.Text)
        UpdateTable("SpecificationsTable", SetCommand, RecordFilter)
    End Sub
    Private Sub RegisterVolumeSpecificationsChanges()
        If MsgBox("Would you like to update Fluid Specifications for this part ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            If MsgBox("Disregard your Fluid Specifications changes ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                FluidSpecificationsTextBox.SelectAll()
                BackToEditMode = True
                Exit Sub
            End If
        End If
        MySelection = " Select top 1 * FROM VolumeSpecificationsTable WHERE InformationsHeaderID_LongInteger = " & CurrentJobID.ToString &
                        " AND CodeVehicleID_LongInteger = " & CurrentCodeVehicleID.ToString
        JustExecuteMySelection()
        If RecordCount = 0 Then
            InsertNewVolumeSpecifications()
        Else
            UpdateVolumeSpecifications()
        End If
    End Sub
    Private Sub InsertNewVolumeSpecifications()
        Dim FieldsToUpdate = "  CodeVehicleID_LongInteger, " &
                             "  PartSpecifications_ShortText255 "

        Dim FieldsData = CurrentCodeVehicleID.ToString & ",  " &
                         InQuotes(FluidSpecificationsTextBox.Text)

        CurrentWorkOrderPartID = InsertNewRecord("SpecificationsTable", FieldsToUpdate, FieldsData)
    End Sub
    Private Sub UpdateVolumeSpecifications()
        If MsgBox("About to replace previous Specifications, Continue ?", MsgBoxStyle.YesNo) = vbNo Then
            Exit Sub
        End If
        Dim RecordFilter = " WHERE PartSpecificationsID_AutoNumber = " & CurrentPartSpecificationsID.ToString
        Dim SetCommand = " SET CodeVehicleID_LongInteger = " & CurrentCodeVehicleID.ToString & "," &
                          "PartSpecifications_ShortText255 = " & InQuotes(FluidSpecificationsTextBox.Text)
        UpdateTable("SpecificationsTable", SetCommand, RecordFilter)
    End Sub

End Class