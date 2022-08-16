Public Class PartsSpecificationsForm
    Private FluidSpecificationsFieldsToSelect = ""
    Private FluidSpecificationsSelectionFilter = ""
    Private FluidSpecificationsSelectionOrder = ""
    Private FluidSpecificationsRecordCount As Integer = -1
    Private CurrentFluidSpecificationsDataGridViewRow As Integer = -1
    Private CurrentFluidSpecificationsID = -1
    Private FluidSpecificationsDataGridViewAlreadyFormatted = False
    Private SpecificationsFlag = False

    Private CodeVehicleFluidsSpecificationsFieldsToSelect = ""
    Private CodeVehicleFluidsSpecificationsSelectionFilter = ""
    Private CodeVehicleFluidsSpecificationsSelectionOrder = ""
    Private CodeVehicleFluidsSpecificationsRecordCount As Integer = -1
    Private CurrentCodeVehicleFluidsSpecificationsDataGridViewRow As Integer = -1
    Private CurrentCodeVehicleFluidsSpecificationID = -1
    Private CodeVehicleFluidsSpecificationsDataGridViewAlreadyFormatted = False

    Private PartNumberSpecificationsFieldsToSelect = ""
    Private PartNumberSpecificationsSelectionFilter = ""
    Private PartNumberSpecificationsSelectionOrder = ""
    Private PartNumberSpecificationsRecordCount As Integer = -1
    Private CurrentPartNumberSpecificationsDataGridViewRow As Integer = -1
    Private PartNumberSpecificationsDataGridViewAlreadyFormatted = False

    Private CodeVehiclePNSpecificationsFieldsToSelect = ""
    Private CodeVehiclePNSpecificationsSelectionFilter = ""
    Private CodeVehiclePNSpecificationsSelectionOrder = ""
    Private CodeVehiclePNSpecificationsRecordCount As Integer = -1
    Private CurrentCodeVehiclePNSpecificationsDataGridViewRow As Integer = -1
    Private CurrentCodeVehiclePNSpecificationID = -1
    Private CodeVehiclePNSpecificationsDataGridViewAlreadyFormatted = False

    Private QuantitySpecificationsFieldsToSelect = ""
    Private QuantitySpecificationsSelectionFilter = ""
    Private QuantitySpecificationsSelectionOrder = ""
    Private QuantitySpecificationsRecordCount As Integer = -1
    Private CurrentQuantitySpecificationsID As Integer = -1
    Private CurrentQuantitySpecificationsDataGridViewRow As Integer = -1
    Private QuantitySpecificationsDataGridViewAlreadyFormatted = False

    Private CurrentQuantitySpecificationID = -1
    Private CurrentJobDesCription = ""
    Private CurrentPartNumberSpecificationID = -1
    Private CurrentPartSpecificationsID = -1
    Private CurrentCodeVehicleID = -1
    Private CurrentInformationsHeaderID = -1
    Private CurrentMasterCodeBookID As Integer = -1
    Private SavedCallingForm As Form
    Private PurposeOfEntry = ""
    Private BackToEditMode = False

    Private Sub PartSpecificationsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' NOTE CodeVehiclesTable WILL DETERMINE ALL LINKS TO THE SPECIFICS OF THE PART
        ' INPUT WILL THEN BE MASTERCODEBOOKID AND VEHICLEID
        ' Tunnel 1 - MasterCodebookID
        ' Tunnel 2 - CodeVehicleID
        ' Tunnel 3 - InformationsHeaderID
        SavedCallingForm = CallingForm
        CurrentJobDesCription = Tunnel1
        CurrentMasterCodeBookID = Tunnel3
        CurrentCodeVehicleID = Tunnel2
        VehicleModelTextBox.Text = RequestPartsForm.VehicleNameButton.Text
        '      PartDescriptionTextBox.Text = CurrentJobDesCription
        ' Initialize TEXT BOXES TO DEFINE WHAT TYPE OF DATA TO STORE
        If FluidSpecificationsTextBox.Enabled Then
            PartSpecificationsItemToolStripMenuItem.Visible = False
            CodeVehicleFluidsSpecificationsGroupBox.Text = "Fluid Specs for " + GetFieldValue("MasterCodeBookTable", "MasterCodeBookID_Autonumber", CurrentMasterCodeBookID, "SystemDesc_ShortText100Fld")
            CodeVehicleFluidsSpecificationsSelectionFilter = " WHERE CodeVehicleID_LongInteger = " & CurrentCodeVehicleID.ToString
            FillCodeVehicleFluidsSpecificationsRelations()
            CodeVehicleFluidsSpecificationsGroupBox.Visible = True
            FluidSpecificationsGroupBox.Text = "All Fluid Specs for " + GetFieldValue("MasterCodeBookTable", "MasterCodeBookID_Autonumber", CurrentMasterCodeBookID, "SystemDesc_ShortText100Fld")
            FluidSpecificationsSelectionFilter = " WHERE MasterCodeBookID_LongInteger = " & CurrentMasterCodeBookID.ToString
            FillFluidSpecificationsDataGridView()
        Else
            DisableFluidSpecificationsOPtions()
            DisableQuantitySpecificationsOPtions()
            PartNumberSpecificationsGroupBox.Visible = False
            CodeVehiclePNSpecificationsGroupBox.Visible = True
            CodeVehiclePNSpecificationsGroupBox.Enabled = True
            CodeVehiclePNSpecificationsSelectionFilter = " WHERE CodeVehicleID_LongInteger = " & CurrentCodeVehicleID.ToString

            FillCodeVehiclePNSpecificationsRelations()
            PartNumberSpecificationsGroupBox.Text = "All part number Specs for " + GetFieldValue("MasterCodeBookTable", "MasterCodeBookID_Autonumber", CurrentMasterCodeBookID, "SystemDesc_ShortText100Fld")
            PartNumberSpecificationsSelectionFilter = " WHERE MasterCodeBookID_LongInteger = " & CurrentMasterCodeBookID.ToString
            FillPartNumberSpecificationsDataGridView()
            PartSpecificationsItemToolStripMenuItem.Select()
        End If
        ServiceToPerformTextBox.Text = CurrentJobDesCription
        SpecifiedQuantityTextBox.Text = RequestPartsForm.SpecifiedQuantityTextBox.Text
        SpecifiedUnitTextBox.Text = RequestPartsForm.SpecifiedUnitTextBox.Text

    End Sub
    Private Sub FillCodeVehicleFluidsSpecificationsRelations()
        CodeVehicleFluidsSpecificationsFieldsToSelect =
"
SELECT CodeVehicleFluidsSpecificationsRelationsTable.CodeVehicleID_LongInteger, 
FluidsSpecificationsTable.FluidSpecifications_ShortText255, 
MasterCodeBookTable.SystemDesc_ShortText100Fld, 
CodeVehicleFluidsSpecificationsRelationsTable.CodeVehicleFluidsSpecificationsRelationID_AutoNumber
FROM ((CodeVehicleFluidsSpecificationsRelationsTable LEFT JOIN FluidsSpecificationsTable ON CodeVehicleFluidsSpecificationsRelationsTable.FluidsSpecificationID_LongInteger = FluidsSpecificationsTable.FluidsSpecificationID_AutoNumber) LEFT JOIN CodeVehiclesTable ON CodeVehicleFluidsSpecificationsRelationsTable.CodeVehicleID_LongInteger = CodeVehiclesTable.CodeVehicleID_AutoNumber) LEFT JOIN MasterCodeBookTable ON CodeVehiclesTable.MasterCodeBookID_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber
"
        MySelection = CodeVehicleFluidsSpecificationsFieldsToSelect & CodeVehicleFluidsSpecificationsSelectionFilter

        JustExecuteMySelection()
        CodeVehicleFluidsSpecificationsRecordCount = RecordCount
        CodeVehicleFluidsSpecificationsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        CodeVehicleFluidsSpecificationsDataGridView.Visible = True
        If Not CodeVehicleFluidsSpecificationsDataGridViewAlreadyFormatted Then
            FormatCodeVehicleFluidsSpecificationsDataGridView()
        End If
        SetGroupBoxHeight(6, CodeVehicleFluidsSpecificationsRecordCount + 1, CodeVehicleFluidsSpecificationsGroupBox, CodeVehicleFluidsSpecificationsDataGridView)
        CodeVehicleFluidsSpecificationsGroupBox.Top = VehicleModelTextBox.Top + VehicleModelTextBox.Height + 2
    End Sub

    Private Sub FormatCodeVehicleFluidsSpecificationsDataGridView()
        CodeVehicleFluidsSpecificationsDataGridViewAlreadyFormatted = True
        CodeVehicleFluidsSpecificationsGroupBox.Width = 0

        For i = 0 To CodeVehicleFluidsSpecificationsDataGridView.Columns.GetColumnCount(0) - 1

            CodeVehicleFluidsSpecificationsDataGridView.Columns.Item(i).Visible = False

            Select Case CodeVehicleFluidsSpecificationsDataGridView.Columns.Item(i).Name
                Case "FluidSpecifications_ShortText255"
                    CodeVehicleFluidsSpecificationsDataGridView.Columns.Item(i).HeaderText = "SPECIFICATIONS"
                    CodeVehicleFluidsSpecificationsDataGridView.Columns.Item(i).Width = PartDescriptionTextBox.Width
                    CodeVehicleFluidsSpecificationsDataGridView.Columns.Item(i).Visible = True
            End Select
            If CodeVehicleFluidsSpecificationsDataGridView.Columns.Item(i).Visible = True Then
                CodeVehicleFluidsSpecificationsGroupBox.Width = CodeVehicleFluidsSpecificationsGroupBox.Width + CodeVehicleFluidsSpecificationsDataGridView.Columns.Item(i).Width
            End If
        Next
        CodeVehicleFluidsSpecificationsDataGridView.Width = CodeVehicleFluidsSpecificationsGroupBox.Width - 6
        Dim RecordsDisplyed = CodeVehicleFluidsSpecificationsRecordCount
        If CodeVehicleFluidsSpecificationsRecordCount > 5 Then
            RecordsDisplyed = 5
        Else
            RecordsDisplyed = CodeVehicleFluidsSpecificationsRecordCount
        End If
        CodeVehicleFluidsSpecificationsGroupBox.Left = PartDescriptionTextBox.Left

    End Sub
    Private Sub CodeVehicleFluidsSpecificationsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles CodeVehicleFluidsSpecificationsDataGridView.RowEnter
        PartSpecificationsItemToolStripMenuItem.Visible = False
        AddFluidSpecificationsToolStripMenuItem.Visible = False
        SelectFluidSpecificationsToolStripMenuItem.Visible = False
        EditFluidSpecificationsToolStripMenuItem.Visible = False
        RemoveFluidFluidSpecificationsToolStripMenuItem.Visible = False
        If e.RowIndex < 0 Then Exit Sub
        If CodeVehicleFluidsSpecificationsRecordCount = 0 Then Exit Sub

        PartSpecificationsItemToolStripMenuItem.Visible = True
        AddFluidSpecificationsToolStripMenuItem.Visible = True
        SelectFluidSpecificationsToolStripMenuItem.Visible = True
        EditFluidSpecificationsToolStripMenuItem.Visible = True
        RemoveFluidFluidSpecificationsToolStripMenuItem.Visible = True

        CurrentCodeVehicleFluidsSpecificationsDataGridViewRow = e.RowIndex
        CurrentCodeVehicleFluidsSpecificationID = CodeVehicleFluidsSpecificationsDataGridView.Item("CodeVehicleFluidsSpecificationsRelationID_AutoNumber", CurrentCodeVehicleFluidsSpecificationsDataGridViewRow).Value
        SpecificationsFlag = False


    End Sub
    Private Sub FillFluidSpecificationsDataGridView()
        FluidSpecificationsFieldsToSelect =
" 
SELECT 
FluidsSpecificationsTable.FluidsSpecificationID_AutoNumber, 
FluidsSpecificationsTable.MasterCodeBookID_LongInteger, 
FluidsSpecificationsTable.FluidSpecifications_ShortText255
FROM FluidsSpecificationsTable
"
        MySelection = FluidSpecificationsFieldsToSelect & FluidSpecificationsSelectionFilter

        JustExecuteMySelection()
        FluidSpecificationsRecordCount = RecordCount
        FluidSpecificationsGroupBox.Visible = True
        FluidSpecificationsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If Not FluidSpecificationsDataGridViewAlreadyFormatted Then
            FormatFluidSpecificationsDataGridView()
        End If
        SetGroupBoxHeight(6, FluidSpecificationsRecordCount + 1, FluidSpecificationsGroupBox, FluidSpecificationsDataGridView)
        FluidSpecificationsGroupBox.Top = CodeVehicleFluidsSpecificationsGroupBox.Top + CodeVehicleFluidsSpecificationsGroupBox.Height + 100
    End Sub

    Private Sub FormatFluidSpecificationsDataGridView()
        FluidSpecificationsDataGridViewAlreadyFormatted = True
        FluidSpecificationsGroupBox.Width = 0

        For i = 0 To FluidSpecificationsDataGridView.Columns.GetColumnCount(0) - 1

            FluidSpecificationsDataGridView.Columns.Item(i).Visible = False
            Select Case FluidSpecificationsDataGridView.Columns.Item(i).Name
                Case "FluidSpecifications_ShortText255"
                    FluidSpecificationsDataGridView.Columns.Item(i).HeaderText = "SPECIFICATIONS ALL"
                    FluidSpecificationsDataGridView.Columns.Item(i).Width = PartDescriptionTextBox.Width
                    FluidSpecificationsDataGridView.Columns.Item(i).Visible = True
            End Select
            If FluidSpecificationsDataGridView.Columns.Item(i).Visible = True Then
                FluidSpecificationsGroupBox.Width = FluidSpecificationsGroupBox.Width + FluidSpecificationsDataGridView.Columns.Item(i).Width
            End If
        Next
        FluidSpecificationsGroupBox.Left = CodeVehicleFluidsSpecificationsGroupBox.Left

    End Sub
    Private Sub FluidSpecificationsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles FluidSpecificationsDataGridView.RowEnter

        If ShowInTaskbarFlag Then Exit Sub
        If Me.Enabled = False Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If FluidSpecificationsRecordCount = 0 Then Exit Sub

        CurrentFluidSpecificationsDataGridViewRow = e.RowIndex
        FillField(CurrentFluidSpecificationsID, FluidSpecificationsDataGridView.Item("FluidsSpecificationID_AutoNumber", CurrentFluidSpecificationsDataGridViewRow).Value)
        SpecificationsFlag = True
        If FluidSpecificationsTextBox.Text = "type new specifications" Then FluidSpecificationsTextBox.Text = ""
        EnableFluidOPtions()
    End Sub
    Private Sub FillCodeVehiclePNSpecificationsRelations()
        CodeVehiclePNSpecificationsFieldsToSelect =
"
SELECT 
CodeVehiclePartNumbersSpecificationsRelationsTable.CodeVehiclePartNumbersSpecificationsRelationID_AutoNumber, 
CodeVehiclePartNumbersSpecificationsRelationsTable.CodeVehicleID_LongInteger, 
PartNumbersSpecificationsTable.PartNumberSpecifications_ShortText30, 
MasterCodeBookTable.SystemDesc_ShortText100Fld
FROM (CodeVehiclePartNumbersSpecificationsRelationsTable LEFT JOIN PartNumbersSpecificationsTable ON CodeVehiclePartNumbersSpecificationsRelationsTable.[PartNumbersSpecificationID_LongInteger] = PartNumbersSpecificationsTable.PartNUmbersSpecificationID_AutoNumber) LEFT JOIN (CodeVehiclesTable LEFT JOIN MasterCodeBookTable ON CodeVehiclesTable.MasterCodeBookID_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) ON CodeVehiclePartNumbersSpecificationsRelationsTable.CodeVehicleID_LongInteger = CodeVehiclesTable.CodeVehicleID_AutoNumber
"
        MySelection = CodeVehiclePNSpecificationsFieldsToSelect & CodeVehiclePNSpecificationsSelectionFilter

        JustExecuteMySelection()
        CodeVehiclePNSpecificationsDataGridView.Enabled = True
        PartNumberSpecificationsGroupBox.Visible = False
        CodeVehiclePNSpecificationsRecordCount = RecordCount
        If CodeVehiclePNSpecificationsRecordCount = 0 Then
            'THERE IS NO part SPECIFICATION YET FOR THIS CODE
            'MUST ADD NEW PART SPECIFICATION 1ST IN THE PART SPECIFICATION LIST
            'ENABLE RDITING OF THE PartNumberSpecifications LIST
            CodeVehiclePNSpecificationsDataGridView.Enabled = False
            PartNumberSpecificationsGroupBox.Visible = True
        End If

        If CodeVehiclePNSpecificationsDataGridView.Enabled = True Then  'CodeVehiclePNSpecificationsDataGridView is active
            SelectPartNumberToolStripMenuItem.Visible = False
            EditPartNumberToolStripMenuItem.Visible = False
            RemovePartNumberToolStripMenuItem.Visible = False
            If CodeVehiclePNSpecificationsRecordCount > 0 Then
                SelectPartNumberToolStripMenuItem.Visible = True
                EditPartNumberToolStripMenuItem.Visible = True
                RemovePartNumberToolStripMenuItem.Visible = True
            End If
        End If
        If PartNumberSpecificationsGroupBox.Visible Then
            SelectPartNumberToolStripMenuItem.Visible = True
            EditPartNumberToolStripMenuItem.Visible = True
            DeletePartNumberToolStripMenuItem.Visible = True
        End If

        CodeVehiclePNSpecificationsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If Not CodeVehiclePNSpecificationsDataGridViewAlreadyFormatted Then
            FormatCodeVehiclePNSpecificationsDataGridView()
        End If
        SetGroupBoxHeight(6, CodeVehiclePNSpecificationsRecordCount + 1, CodeVehiclePNSpecificationsGroupBox, CodeVehiclePNSpecificationsDataGridView)
        CodeVehiclePNSpecificationsGroupBox.Top = VehicleModelTextBox.Top + VehicleModelTextBox.Height + 2
    End Sub

    Private Sub FormatCodeVehiclePNSpecificationsDataGridView()
        CodeVehiclePNSpecificationsDataGridViewAlreadyFormatted = True
        CodeVehiclePNSpecificationsGroupBox.Width = 0

        For i = 0 To CodeVehiclePNSpecificationsDataGridView.Columns.GetColumnCount(0) - 1

            CodeVehiclePNSpecificationsDataGridView.Columns.Item(i).Visible = False

            Select Case CodeVehiclePNSpecificationsDataGridView.Columns.Item(i).Name
                Case "PartNumberSpecifications_ShortText30"
                    CodeVehiclePNSpecificationsDataGridView.Columns.Item(i).HeaderText = "SPECIFICATIONS"
                    CodeVehiclePNSpecificationsDataGridView.Columns.Item(i).Width = PartDescriptionTextBox.Width
                    CodeVehiclePNSpecificationsDataGridView.Columns.Item(i).Visible = True
            End Select
            If CodeVehiclePNSpecificationsDataGridView.Columns.Item(i).Visible = True Then
                CodeVehiclePNSpecificationsGroupBox.Width = CodeVehiclePNSpecificationsGroupBox.Width + CodeVehiclePNSpecificationsDataGridView.Columns.Item(i).Width
            End If
        Next
        CodeVehiclePNSpecificationsDataGridView.Width = CodeVehiclePNSpecificationsGroupBox.Width - 6
        CodeVehiclePNSpecificationsGroupBox.Left = PartDescriptionTextBox.Left

    End Sub
    Private Sub CodeVehiclePNSpecificationsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles CodeVehiclePNSpecificationsDataGridView.RowEnter
        If e.RowIndex < 0 Then Exit Sub
        If CodeVehiclePNSpecificationsRecordCount = 0 Then Exit Sub

        CurrentCodeVehiclePNSpecificationsDataGridViewRow = e.RowIndex
        CurrentCodeVehiclePNSpecificationID = CodeVehiclePNSpecificationsDataGridView.Item("CodeVehiclePartNumbersSpecificationsRelationID_AutoNumber", CurrentCodeVehiclePNSpecificationsDataGridViewRow).Value
    End Sub

    Private Sub FillPartNumberSpecificationsDataGridView()
        PartNumberSpecificationsFieldsToSelect =
" 
SELECT PartNumbersSpecificationsTable.PartNUmbersSpecificationID_AutoNumber, PartNumbersSpecificationsTable.MasterCodeBookID_LongInteger, PartNumbersSpecificationsTable.PartNumberSpecifications_ShortText30
FROM PartNumbersSpecificationsTable
"
        MySelection = PartNumberSpecificationsFieldsToSelect & PartNumberSpecificationsSelectionFilter

        JustExecuteMySelection()
        PartNumberSpecificationsRecordCount = RecordCount
        If PartNumberSpecificationsRecordCount > 0 Then
            PartNumberSpecificationsGroupBox.Visible = True
        Else
            PartNumberSpecificationsGroupBox.Visible = False
        End If

        If PartNumberSpecificationsGroupBox.Visible = True Then
            SelectPartNumberToolStripMenuItem.Visible = False
            EditPartNumberToolStripMenuItem.Visible = False
            DeletePartNumberToolStripMenuItem.Visible = False
            If PartNumberSpecificationsRecordCount > 0 Then
                SelectPartNumberToolStripMenuItem.Visible = True
                EditPartNumberToolStripMenuItem.Visible = True
                DeletePartNumberToolStripMenuItem.Visible = True
            End If
        End If
        PartNumberSpecificationsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If Not PartNumberSpecificationsDataGridViewAlreadyFormatted Then
            FormatPartNumberSpecificationsDataGridView()
        End If
        SetGroupBoxHeight(6, PartNumberSpecificationsRecordCount + 1, PartNumberSpecificationsGroupBox, PartNumberSpecificationsDataGridView)
        PartNumberSpecificationsGroupBox.Top = CodeVehiclePNSpecificationsGroupBox.Top + CodeVehiclePNSpecificationsGroupBox.Height

    End Sub

    Private Sub FormatPartNumberSpecificationsDataGridView()
        PartNumberSpecificationsDataGridViewAlreadyFormatted = True
        PartNumberSpecificationsGroupBox.Width = 0

        For i = 0 To PartNumberSpecificationsDataGridView.Columns.GetColumnCount(0) - 1

            PartNumberSpecificationsDataGridView.Columns.Item(i).Visible = False
            Select Case PartNumberSpecificationsDataGridView.Columns.Item(i).Name
                Case "PartNumberSpecifications_ShortText30"
                    PartNumberSpecificationsDataGridView.Columns.Item(i).HeaderText = "SPECIFICATIONS"
                    PartNumberSpecificationsDataGridView.Columns.Item(i).Width = PartDescriptionTextBox.Width
                    PartNumberSpecificationsDataGridView.Columns.Item(i).Visible = True
            End Select
            If PartNumberSpecificationsDataGridView.Columns.Item(i).Visible = True Then
                PartNumberSpecificationsGroupBox.Width = PartNumberSpecificationsGroupBox.Width + PartNumberSpecificationsDataGridView.Columns.Item(i).Width
            End If
        Next
        PartNumberSpecificationsGroupBox.Left = CodeVehiclePNSpecificationsGroupBox.Left

    End Sub
    Private Sub PartNumberSpecificationsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles PartNumberSpecificationsDataGridView.RowEnter
        SelectPartNumberToolStripMenuItem.Visible = False
        If ShowInTaskbarFlag Then Exit Sub
        If Me.Enabled = False Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If PartNumberSpecificationsRecordCount = 0 Then Exit Sub
        SelectPartNumberToolStripMenuItem.Visible = True
        CurrentPartNumberSpecificationsDataGridViewRow = e.RowIndex
        FillField(CurrentPartNumberSpecificationID, PartNumberSpecificationsDataGridView.Item("PartNUmbersSpecificationID_AutoNumber", CurrentPartNumberSpecificationsDataGridViewRow).Value)
    End Sub
    Private Sub FillQuantitySpecificationsDataGridView()

        '   USING QuantitySpecificationsQuery

        QuantitySpecificationsFieldsToSelect =
            " 
SELECT QuantitySpecificationsTable.QuantitySpecificationID_AutoNumber,
QuantitySpecificationsTable.InformationsHeaderID_LongInteger,
QuantitySpecificationsTable.CodeVehicleID_LongInteger,
InformationsHeadersTable.InformationsHeaderDescription_ShortText255,
QuantitySpecificationsTable.SpecifiedQuantity_Double,
QuantitySpecificationsTable.SpecifiedUnit_ShortText3
FROM QuantitySpecificationsTable INNER JOIN InformationsHeadersTable ON QuantitySpecificationsTable.InformationsHeaderID_LongInteger = InformationsHeadersTable.InformationsHeaderID_AutoNumber
"

        QuantitySpecificationsSelectionOrder = ""

        MySelection = QuantitySpecificationsFieldsToSelect & QuantitySpecificationsSelectionFilter & QuantitySpecificationsSelectionOrder


        JustExecuteMySelection()
        QuantitySpecificationsRecordCount = RecordCount
        QuantitySpecificationsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If QuantitySpecificationsRecordCount = 0 Then
            QuantitySpecificationsDataGridView.Visible = False
        Else
            QuantitySpecificationsDataGridView.Visible = True
        End If

        If Not QuantitySpecificationsDataGridViewAlreadyFormatted Then
            FormatQuantitySpecificationsDataGridView()
        End If
    End Sub


    Private Sub FormatQuantitySpecificationsDataGridView()
        QuantitySpecificationsDataGridViewAlreadyFormatted = True

        QuantitySpecificationsDataGridView.Width = 0

        For i = 0 To QuantitySpecificationsDataGridView.Columns.GetColumnCount(0) - 1

            QuantitySpecificationsDataGridView.Columns.Item(i).Visible = False

            Select Case QuantitySpecificationsDataGridView.Columns.Item(i).Name
                Case "InformationsHeaderDescription_ShortText255"
                    QuantitySpecificationsDataGridView.Columns.Item(i).HeaderText = "JOB"
                    QuantitySpecificationsDataGridView.Columns.Item(i).Width = 300
                    QuantitySpecificationsDataGridView.Columns.Item(i).Visible = True
                Case "SpecifiedQuantity_Double"
                    QuantitySpecificationsDataGridView.Columns.Item(i).HeaderText = "QTY"
                    QuantitySpecificationsDataGridView.Columns.Item(i).Width = 60
                    QuantitySpecificationsDataGridView.Columns.Item(i).Visible = True
                Case "SpecifiedUnit_ShortText3"
                    QuantitySpecificationsDataGridView.Columns.Item(i).HeaderText = "UNIT"
                    QuantitySpecificationsDataGridView.Columns.Item(i).Width = 100
                    QuantitySpecificationsDataGridView.Columns.Item(i).Visible = True
            End Select
            If QuantitySpecificationsDataGridView.Columns.Item(i).Visible = True Then
                QuantitySpecificationsDataGridView.Width = QuantitySpecificationsDataGridView.Width + QuantitySpecificationsDataGridView.Columns.Item(i).Width
            End If
        Next

        If QuantitySpecificationsDataGridView.Width > Me.Width Then
            QuantitySpecificationsDataGridView.Width = Me.Width - 100
        Else
            QuantitySpecificationsDataGridView.Width = QuantitySpecificationsDataGridView.Width + 20
        End If
        QuantitySpecificationsDataGridView.Width = QuantitySpecificationsDataGridView.Width

        Me.Left = (VehicleManagementSystemForm.Width - Me.Width) / 2
        Me.Location = New Point(Me.Location.X, 55)
        '===========================

        Dim RecordsDisplyed = QuantitySpecificationsRecordCount
        Dim FormLowPointFromGrid = 90
        If QuantitySpecificationsRecordCount > 27 Then
            RecordsDisplyed = 27
        Else
            RecordsDisplyed = QuantitySpecificationsRecordCount
        End If

        QuantitySpecificationsDataGridView.Height = (QuantitySpecificationsDataGridView.ColumnHeadersHeight) + (DataGridViewRowHeight * (RecordsDisplyed + 1))



    End Sub
    Private Sub QuantitySpecificationsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles QuantitySpecificationsDataGridView.RowEnter

        If e.RowIndex < 0 Then Exit Sub
        If QuantitySpecificationsRecordCount = 0 Then Exit Sub

        CurrentQuantitySpecificationsDataGridViewRow = e.RowIndex

        CurrentQuantitySpecificationsID = QuantitySpecificationsDataGridView.Item("QuantitySpecificationsID_Autonumber", CurrentQuantitySpecificationsDataGridViewRow).Value
    End Sub

    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        '      RegisterFluidSpecificationsChanges()()
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub
    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        If PartNumberSpecificationTextBox.Enabled Then
            If AChangeInPartNumberSpecificationOccured() Then
                RegisterPartNumberSpecificationChanges()
            End If
        Else
            If FluidSpecificationsTextBox.Enabled Then
                RegisterFluidSpecificationsChanges()
            End If
        End If
        If BackToEditMode Then Exit Sub
        SaveToolStripMenuItem.Visible = False
        PartNumberSpecificationTextBox.Text = ""
        FluidSpecificationsTextBox.Text = ""
        PartSpecificationsDetailsGroup.Visible = False
    End Sub
    Private Function AChangeInPartNumberSpecificationOccured()
        If CurrentPartNumberSpecificationID = -1 Then
            If IsNotEmpty(PartNumberSpecificationTextBox.Text) Then Return True
        Else
            If TheseAreNotEqual(PartNumberSpecificationTextBox.Text, FluidSpecificationsDataGridView.Item("PartNumber_ShortText25", CurrentFluidSpecificationsDataGridViewRow).Value, PurposeOfEntry) Then Return True
        End If
        Return False
    End Function
    Private Sub RegisterPartNumberSpecificationChanges()
        If MsgBox("Continue saving  Part Number specification ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            If MsgBox("Discard your part number specification changes ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                PartNumberSpecificationTextBox.SelectAll()
                Exit Sub
            End If
        End If

        MySelection = " SELECT * FROM PartNumbersSpecificationsTable WHERE PartNumberSpecifications_ShortText30 = " &
                                                            InQuotes(PartNumberSpecificationTextBox.Text)
        JustExecuteMySelection()

        If RecordCount > 0 Then
            If CurrentPartNumberSpecificationID = -1 Then
                Dim r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
                Dim xxx = r("PartNUmbersSpecificationID_AutoNumber")
                PartNumberSpecificationsGroupBox.Visible = True
                MsgBox(PartNumberSpecificationTextBox.Text & "ALREADY EXIST!")
            Else
                UpdatePartNumberSpecifications()
            End If
        Else
            InsertNewPartNumberSpecification()
        End If
        FillPartNumberSpecificationsDataGridView()
    End Sub
    Private Sub UpdatePartNumberSpecifications()
        'UPDATE LIST OF ALL PART NUMBER SPWCIFICATIONS
        Dim RecordFilter = " WHERE PartNUmbersSpecificationID_AutoNumber = " & CurrentPartNumberSpecificationID.ToString
        Dim SetCommand = " SET MasterCodeBookID_LongInteger = " & CurrentMasterCodeBookID.ToString & "," &
                          " PartNumberSpecifications_ShortText30 = " & InQuotes(PartNumberSpecificationTextBox.Text)
        UpdateTable("PartNumbersSpecificationsTable", SetCommand, RecordFilter)
    End Sub
    Private Sub InsertNewPartNumberSpecification()
        'insert into the LIST OF ALL PART NUMBER SPWCIFICATIONS
        Dim FieldsToUpdate = "  MasterCodeBookID_LongInteger, " &
                             "  PartNumberSpecifications_ShortText30 "

        Dim FieldsData = CurrentMasterCodeBookID.ToString & ",  " &
                         InQuotes(PartNumberSpecificationTextBox.Text)

        CurrentPartNumberSpecificationID = InsertNewRecord("PartNumbersSpecificationsTable", FieldsToUpdate, FieldsData)
    End Sub

    Private Sub RegisterFluidSpecificationsChanges()
        If MsgBox("Continue saving  fluid specification ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            If MsgBox("Discard your fluid specification changes ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                PartNumberSpecificationTextBox.SelectAll()
                Exit Sub
            End If
        End If

        MySelection = " SELECT * FROM FluidsSpecificationsTable WHERE FluidSpecifications_ShortText255 = " & InQuotes(FluidSpecificationsTextBox.Text)
        JustExecuteMySelection()
        If FluidSpecificationsRecordCount > 0 Then
            UpdateFluidSpecifications()
        Else
            InsertNewFluidSpecification()
        End If
        End Sub
    Private Sub UpdateFluidSpecifications()
        'UPDATE LIST OF ALL FLUID SPECIFICATIONS
        Dim RecordFilter = " WHERE FluidsSpecificationID_AutoNumber = " & CurrentFluidSpecificationsID.ToString
        Dim SetCommand = " SET MasterCodeBookID_LongInteger = " & CurrentMasterCodeBookID.ToString & "," &
                          " FluidSpecifications_ShortText255 = " & InQuotes(FluidSpecificationsTextBox.Text)
        UpdateTable("FluidsSpecificationsTable", SetCommand, RecordFilter)
    End Sub
    Private Sub InsertNewFluidSpecification()
        'insert into the LIST OF ALL FLUID SPWCIFICATIONS
        Dim FieldsToUpdate = "  MasterCodeBookID_LongInteger, " &
                             "  FluidSpecifications_ShortText255 "

        Dim FieldsData = CurrentMasterCodeBookID.ToString & ",  " &
                         InQuotes(FluidSpecificationsTextBox.Text)

        CurrentPartNumberSpecificationID = InsertNewRecord("FluidsSpecificationsTable", FieldsToUpdate, FieldsData)
    End Sub

    Private Function AChangeInQuantitySpecificationsOccured()
        If CurrentFluidSpecificationsDataGridViewRow > -1 Then
            If TheseAreNotEqual(SpecifiedQuantityTextBox.Text, FluidSpecificationsDataGridView.Item("SpecifiedQuantity_Double", CurrentFluidSpecificationsDataGridViewRow).Value, PurposeOfEntry) Then Return True
            If TheseAreNotEqual(SpecifiedUnitTextBox.Text, FluidSpecificationsDataGridView.Item("SpecifiedUnit_ShortText3", CurrentFluidSpecificationsDataGridViewRow).Value, PurposeOfEntry) Then Return True
        Else
            If IsNotEmpty(SpecifiedQuantityTextBox.Text) Then Return True
            If IsNotEmpty(SpecifiedUnitTextBox.Text) Then Return True
        End If
        Return False
    End Function
    Private Function AChangeInPartSpecificationsOccured()
        If CurrentFluidSpecificationsDataGridViewRow > -1 Then
            If TheseAreNotEqual(FluidSpecificationsTextBox.Text, FluidSpecificationsDataGridView.Item("PartSpecifications_ShortText255", CurrentFluidSpecificationsDataGridViewRow).Value, PurposeOfEntry) Then Return True
        Else
            If IsNotEmpty(FluidSpecificationsTextBox.Text) Then Return True
        End If
        Return False
    End Function
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

        Dim FieldsData = InQuotes(PartNumberSpecificationTextBox.Text)

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
    Private Sub RegisterQuantitySpecificationsChanges()
        If MsgBox("Would you like to update Fluid Specifications for this part ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            If MsgBox("Disregard your Fluid Specifications changes ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                FluidSpecificationsTextBox.SelectAll()
                BackToEditMode = True
                Exit Sub
            End If
        End If
        MySelection = " Select top 1 * FROM QuantitySpecificationsTable WHERE InformationsHeaderID_LongInteger = " & CurrentInformationsHeaderID.ToString &
                        " AND CodeVehicleID_LongInteger = " & CurrentCodeVehicleID.ToString
        JustExecuteMySelection()
        If RecordCount = 0 Then
            InsertNewQuantitySpecifications()
        Else
            UpdateQuantitySpecifications()
        End If
    End Sub
    Private Sub InsertNewQuantitySpecifications()
        Dim FieldsToUpdate = "  CodeVehicleID_LongInteger, " &
                             "  PartSpecifications_ShortText255 "

        Dim FieldsData = CurrentCodeVehicleID.ToString & ",  " &
                         InQuotes(FluidSpecificationsTextBox.Text)

        CurrentPartNumberSpecificationID = InsertNewRecord("SpecificationsTable", FieldsToUpdate, FieldsData)
    End Sub
    Private Sub UpdateQuantitySpecifications()
        If MsgBox("About to replace previous Specifications, Continue ?", MsgBoxStyle.YesNo) = vbNo Then
            Exit Sub
        End If
        Dim RecordFilter = " WHERE PartSpecificationsID_AutoNumber = " & CurrentPartSpecificationsID.ToString
        Dim SetCommand = " SET CodeVehicleID_LongInteger = " & CurrentCodeVehicleID.ToString & "," &
                          "PartSpecifications_ShortText255 = " & InQuotes(FluidSpecificationsTextBox.Text)
        UpdateTable("SpecificationsTable", SetCommand, RecordFilter)
    End Sub
    Private Sub SelectFluidSpecificationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectFluidSpecificationsToolStripMenuItem.Click
        If SpecificationsFlag Then
            If MsgBox("Continue Adding this as Specification for " & VehicleModelTextBox.Text, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim FieldsToUpdate = "  CodeVehicleID_LongInteger, " &
                                     " FluidsSpecificationID_LongInteger "
                Dim FieldsData = CurrentCodeVehicleID.ToString & ", " &
                                 CurrentFluidSpecificationsID

                CurrentCodeVehicleFluidsSpecificationID = InsertNewRecord("CodeVehicleFluidsSpecificationsRelationsTable", FieldsToUpdate, FieldsData)
                FillCodeVehicleFluidsSpecificationsRelations()
                CodeVehicleFluidsSpecificationsGroupBox.Enabled = True
                FluidSpecificationsGroupBox.Visible = False
                Exit Sub
            End If
        End If
        Tunnel1 = "Tunnel2IsCodeVehicleFluidsSpecificationID"
        Tunnel2 = CurrentCodeVehicleFluidsSpecificationID
        Select Case SavedCallingForm.Name
            Case "RequestPartsForm"
                RequestPartsForm.SpecificationsTextBox.Text = CodeVehicleFluidsSpecificationsDataGridView.Item("FluidSpecifications_ShortText255", CurrentCodeVehicleFluidsSpecificationsDataGridViewRow).Value
        End Select
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub
    Private Sub SpecifiedPartNumberTextBox_TextChanged(sender As Object, e As EventArgs) Handles PartNumberSpecificationTextBox.TextChanged

    End Sub

    Private Sub FluidSpecificationsTextBox_Click(sender As Object, e As EventArgs) Handles FluidSpecificationsTextBox.Click
        If FluidSpecificationsTextBox.ReadOnly = False Then Exit Sub
        EnableFluidOPtions()
    End Sub
    Private Sub EnableFluidOPtions()
        FluidSpecificationsHeaderMenuToolStripMenuItem.Visible = True
        AddFluidSpecificationsToolStripMenuItem.Visible = True
        If FluidSpecificationsRecordCount = 0 Then
            SelectFluidSpecificationsToolStripMenuItem.Visible = False
            EditFluidSpecificationsToolStripMenuItem.Visible = False
            RemoveFluidFluidSpecificationsToolStripMenuItem.Visible = False
        Else
            SelectFluidSpecificationsToolStripMenuItem.Visible = True
            EditFluidSpecificationsToolStripMenuItem.Visible = True
            RemoveFluidFluidSpecificationsToolStripMenuItem.Visible = True
        End If
    End Sub
    Private Sub EnablePartNUmberOPtions()
        PartSpecificationsItemToolStripMenuItem.Visible = True
        If PartNumberSpecificationsRecordCount = 0 Then
            SelectPartNumberToolStripMenuItem.Visible = False
            EditPartNumberToolStripMenuItem.Visible = False
            RemovePartNumberToolStripMenuItem.Visible = False
        Else
            SelectPartNumberToolStripMenuItem.Visible = True
            EditPartNumberToolStripMenuItem.Visible = True
            RemovePartNumberToolStripMenuItem.Visible = True
        End If
    End Sub
    Private Sub DisableFluidSpecificationsOPtions()
        FluidSpecificationsHeaderMenuToolStripMenuItem.Visible = False
        AddFluidSpecificationsToolStripMenuItem.Visible = False
        SelectFluidSpecificationsToolStripMenuItem.Visible = False
        EditFluidSpecificationsToolStripMenuItem.Visible = False
        RemoveFluidFluidSpecificationsToolStripMenuItem.Visible = False
    End Sub
    Private Sub EnablePartSpecificationsOPtions()
        PartSpecificationsItemToolStripMenuItem.Visible = True
    End Sub
    Private Sub DisablePartSpecificationsOPtions()
        PartSpecificationsItemToolStripMenuItem.Visible = False
    End Sub
    Private Sub EnableQuantitySpecificationsOPtions()
        QuantitySpecificationsToolStripTextBox.Visible = True
    End Sub
    Private Sub DisableQuantitySpecificationsOPtions()
        QuantitySpecificationsToolStripTextBox.Visible = False
    End Sub

    Private Sub LinkAnSpecification()
        CurrentPartSpecificationsID = -1
        DisableFluidSpecificationsOPtions()
        SaveToolStripMenuItem.Visible = True
        FluidSpecificationsGroupBox.Visible = True
        FluidSpecificationsTextBox.ReadOnly = False
        FluidSpecificationsTextBox.Select()

    End Sub

    Private Sub AddFluidSpecificationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddFluidSpecificationsToolStripMenuItem.Click
        If FluidSpecificationsGroupBox.Visible = False Then
            FluidSpecificationsGroupBox.Visible = True
        End If
        CurrentFluidSpecificationsID = -1
        FluidSpecificationsTextBox.Text = "type new specifications"
        FluidSpecificationsTextBox.ReadOnly = False
        FluidSpecificationsTextBox.SelectAll()
        SaveToolStripMenuItem.Visible = True
        PartSpecificationsDetailsGroup.Visible = True
    End Sub

    Private Sub EditFluidSpecificationsToolStripMenuItem_Click_2(sender As Object, e As EventArgs) Handles EditFluidSpecificationsToolStripMenuItem.Click

    End Sub

    Private Sub RemoveFluidFluidSpecificationsToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles RemoveFluidFluidSpecificationsToolStripMenuItem.Click
        If MsgBox("Are sure you want unlink this specification ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        MySelection = " DELETE FROM CodeVehicleFluidsSpecificationsRelationsTable WHERE CodeVehicleFluidsSpecificationsRelationID_AutoNumber =  " & CurrentCodeVehicleFluidsSpecificationID
        JustExecuteMySelection()
        FillCodeVehicleFluidsSpecificationsRelations()

    End Sub

    Private Sub SelectPartNumberToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectPartNumberToolStripMenuItem.Click
        If PartNumberSpecificationsGroupBox.Visible = True Then
            PartNumberSpecificationsGroupBox.Visible = False
            MySelection = " Select * FROM CodeVehiclePartNumbersSpecificationsRelationsTable WHERE PartNumbersSpecificationID_LongInteger = " & CurrentPartNumberSpecificationID &
                            " AND CodeVehicleID_LongInteger = " & CurrentCodeVehicleID.ToString
            CurrentPartNumberSpecificationID.ToString()
            JustExecuteMySelection()
            If RecordCount > 0 Then
                MsgBox("Selected Specification already in the list")
                Exit Sub
            End If
            Dim FieldsToUpdate = "  CodeVehicleID_LongInteger, " &
                             "  PartNumbersSpecificationID_LongInteger "

            Dim FieldsData = CurrentCodeVehicleID.ToString & ",  " &
                         CurrentPartNumberSpecificationID.ToString

            CurrentCodeVehiclePNSpecificationID = InsertNewRecord("CodeVehiclePartNumbersSpecificationsRelationsTable", FieldsToUpdate, FieldsData)
            CodeVehiclePNSpecificationsGroupBox.Enabled = True
            FillCodeVehiclePNSpecificationsRelations()
        Else
            Tunnel1 = "Tunnel2IsCodeVehiclePNSpecificationID"
            Tunnel2 = CurrentCodeVehiclePNSpecificationID
            Select Case SavedCallingForm.Name
                Case "RequestPartsForm"
                    RequestPartsForm.PartNumberSpecificationTextBox.Text = CodeVehiclePNSpecificationsDataGridView.Item("PartNumberSpecifications_ShortText30", CurrentCodeVehiclePNSpecificationsDataGridViewRow).Value
            End Select
            DoCommonHouseKeeping(Me, SavedCallingForm)

        End If

    End Sub

    Private Sub AddPartNumberToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddPartNumberToolStripMenuItem.Click
        PartSpecificationsDetailsGroup.Visible = True
        CodeVehiclePNSpecificationsGroupBox.Enabled = False
        CurrentPartNumberSpecificationID = -1
        PartNumberSpecificationTextBox.ReadOnly = False
        PartNumberSpecificationTextBox.Enabled = True
        PartNumberSpecificationTextBox.Text = "type new part number specification"
        PartNumberSpecificationTextBox.SelectAll()
        SaveToolStripMenuItem.Visible = True
    End Sub

    Private Sub EditPartNumberToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditPartNumberToolStripMenuItem.Click
        PartNumberSpecificationTextBox.ReadOnly = False
        PartNumberSpecificationTextBox.SelectAll()
    End Sub

    Private Sub RemovePartNumberToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemovePartNumberToolStripMenuItem.Click

    End Sub

    Private Sub DeletePartNumberToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeletePartNumberToolStripMenuItem.Click

    End Sub
End Class