Public Class StoreRequisitionsForm
    Private PartsRequisitionStatus = ""

    Private PartsRequisitionsFieldsToSelect = ""
    Private PartsRequisitionsTableLinks = ""
    Private PartsRequisitionsSelectionFilter = ""
    Private PartsRequisitionsSelectionOrder = ""
    Private PartsRequisitionsRecordCount As Integer = -1
    Private PartsRequisitionsDataGridViewAlreadyFormatted = False
    Private CurrentPartsRequisitionsRow As Integer = -1
    Private CurrentPartsRequisitionStatus As String
    Private CurrentPartsRequisitionID = -1


    Private StoreSuppliesRequisitionsItemsFieldsToSelect = ""
    Private StoreSuppliesRequisitionsItemsTableLinks = ""
    Private StoreSuppliesRequisitionsItemsSelectionFilter = ""
    Private StoreSuppliesRequisitionsItemsSelectionOrder = ""
    Private StoreSuppliesRequisitionsItemsRecordCount As Integer = -1
    Private StoreSuppliesRequisitionsItemsDataGridViewAlreadyFormated = False
    Private CurrentStoreSuppliesRequisitionsItemID = -1
    Private CurrentStoreSuppliesRequisitionsItemsDataGridViewRow As Integer = -1
    Private CurrentRequestedProductPartID = -1
    Private SavedProductPartID = CurrentRequestedProductPartID
    Private CurrentQtyToIssue = -1
    Private CurrentQtyToOrder = -1
    Private CurrentMasterCodeBookId = -1
    Private CreatingRequisitionItems = False
    Private SavedCallingForm As Form
    Private PurposeOfEntry = ""
    Private CurrentStoreSuppliesRequisitionsItemStatus = ""
    Private Sub PartsRequisitionsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        SavedCallingForm = CallingForm
        'NOTE Requisition header will only be created when submitting the requisition to procurement dept
        '
        StoreSuppliesRequisitionsItemsSelectionFilter = SetupTableSelectionFilter(
                                                            GetStatusIdFor("StoreSuppliesRequisitionsItemsTable", "Draft", 1),
                                                            2,
                                                            Me,
                                                            "Draft"
                                                            )
        FillStoreSuppliesRequisitionsItemsDataGridView()
        '       StoreSuppliesRequisitionsItemsGroupBox.Width = Me.Width - 10

    End Sub

    Private Sub PartsRequisitionsForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        If Me.Enabled = False Then Exit Sub
        CallingForm = SavedCallingForm
        ' GET RETURNED DATA HERE
        Select Case Tunnel1
            Case "Tunnel2IsMasterCodeBookID"
                CurrentMasterCodeBookId = Tunnel2
                PartTextBox.Text = Tunnel3
                RequisitionItemProductDescTextBox.Enabled = True
                POItemProductPartNoTextBox.Enabled = True
                RequisitionItemQuantityTextBox.Enabled = True
            Case "Tunnel2IsProductPartID"
                CurrentRequestedProductPartID = Tunnel2
                RequisitionItemQuantityTextBox.Select()
        End Select
    End Sub
    Private Sub FillStoreSuppliesRequisitionsItemsDataGridView()
        StoreSuppliesRequisitionsItemsFieldsToSelect =
"
SELECT 
StoreSuppliesRequisitionsItemsTable.StoreSuppliesRequisitionsItemID_AutoNumber, 
MasterCodeBookTable.MasterCodeBookID_Autonumber, 
MasterCodeBookTable.SystemDesc_ShortText100Fld,
ProductsPartsTable.ManufacturerPartNo_ShortText30Fld,
ProductsPartsTable.ManufacturerDescription_ShortText250,
StoreSuppliesRequisitionsItemsTable.StoreSupplyRequisitionQuantity_Double,
ProductsPartsTable.Unit_ShortText3, 
BrandsTableRequested.BrandName_ShortText20, 
ProductsPartsTable.ProductsPartID_Autonumber, 
VehicleDescription.VehicleDescription, 
StoreSuppliesRequisitionsItemsTable.PartsRequisitionID_LongInteger,
StatusesTable.StatusSequence_LongInteger, 
StatusesTable.StatusText_ShortText25, 
PartsRequisitionsTable.PartsRequisitionType_Byte
FROM (((((StoreSuppliesRequisitionsItemsTable LEFT JOIN MasterCodeBookTable ON StoreSuppliesRequisitionsItemsTable.MasterCodeBookID_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) LEFT JOIN ProductsPartsTable ON StoreSuppliesRequisitionsItemsTable.ProductPartID_LongInteger = ProductsPartsTable.ProductsPartID_Autonumber) LEFT JOIN VehicleDescription ON StoreSuppliesRequisitionsItemsTable.VehicleID_LongInteger = VehicleDescription.VehicleID_AutoNumber) LEFT JOIN BrandsTable AS BrandsTableRequested ON ProductsPartsTable.BrandID_LongInteger = BrandsTableRequested.BrandID_Autonumber) LEFT JOIN StatusesTable ON StoreSuppliesRequisitionsItemsTable.StoreSuppliesRequisitionsItemStatus_Integer = StatusesTable.StatusID_Autonumber) LEFT JOIN PartsRequisitionsTable ON StoreSuppliesRequisitionsItemsTable.PartsRequisitionID_LongInteger = PartsRequisitionsTable.PartsRequisitionID_AutoNumber
"


        MySelection = StoreSuppliesRequisitionsItemsFieldsToSelect & StoreSuppliesRequisitionsItemsSelectionFilter & StoreSuppliesRequisitionsItemsSelectionOrder
        JustExecuteMySelection()

        StoreSuppliesRequisitionsItemsRecordCount = RecordCount
        StoreSuppliesRequisitionsItemsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        Dim RecordsToDisplay = 28
        SetGroupBoxHeight(RecordsToDisplay, StoreSuppliesRequisitionsItemsRecordCount, StoreSuppliesRequisitionsItemsGroupBox, StoreSuppliesRequisitionsItemsDataGridView)

        If Not StoreSuppliesRequisitionsItemsDataGridViewAlreadyFormated Then
            FormatStoreSuppliesRequisitionsItemsDataGridView()
        End If
        If PartsRequisitionsRecordCount > 0 Then
            StoreSuppliesRequisitionsItemsGroupBox.Top = PartsRequisitionsDataGridView.Top +
                                                        PartsRequisitionsDataGridView.Height
        Else
            StoreSuppliesRequisitionsItemsGroupBox.Top = PartsRequisitionsMenuStrip.Top +
                                                        PartsRequisitionsMenuStrip.Height
        End If
    End Sub
    Private Sub FormatStoreSuppliesRequisitionsItemsDataGridView()
        StoreSuppliesRequisitionsItemsDataGridViewAlreadyFormated = True
        StoreSuppliesRequisitionsItemsDataGridView.Width = 0
        For i = 0 To StoreSuppliesRequisitionsItemsDataGridView.Columns.GetColumnCount(0) - 1

            StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).Visible = False

            Select Case StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).Name
                Case "VehicleDescription"
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "For Vehicle"
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).Width = 200
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "SystemDesc_ShortText100Fld"
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Part"
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).Width = 350
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "StoreSupplyRequisitionQuantity_Double"
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Req Qty"
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).Width = 50
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "StoreSupplyRequisitionUnit_ShortText3"
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Req Unit"
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).Width = 50
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "ManufacturerPartNo_ShortText30Fld"
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Reqstd. Part No"
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).Width = 135
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "ManufacturerDescription_ShortText250"
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Reqstd. Product"
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).Width = 350
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                    StoreSuppliesRequisitionsItemsDataGridView.Columns(i).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                Case "Unit_ShortText3"
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Reqstd. Unit"
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).Width = 120
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "BrandName_ShortText20"
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Reqstd Brand"
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).Width = 150
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "ManufacturerPartNo_ShortText30Fld"
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Purchd. Part No"
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).Width = 135
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "Unit_ShortText3"
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Purchd. Unit"
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).Width = 120
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "StatusText_ShortText25"
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Status"
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).Width = 120
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).Visible = True

            End Select
            If StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).Visible = True Then
                'WIDTH OF DATAGRIDVIEW INSIDE A GROUPBOX AUTOMATICALLY ADJUST TO GroupBox.Width - 4
                '               StoreSuppliesRequisitionsItemsGroupBox.Width = StoreSuppliesRequisitionsItemsGroupBox.Width + StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).Width
            End If
        Next
        Me.Width = VehicleManagementSystemForm.Width - 2
        HorizontalCenter(Me, VehicleManagementSystemForm)
        StoreSuppliesRequisitionsItemsGroupBox.Width = Me.Width - 4
        HorizontalCenter(StoreSuppliesRequisitionsItemsGroupBox, Me)
    End Sub
    Private Sub StoreSuppliesRequisitionsItemsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles StoreSuppliesRequisitionsItemsDataGridView.RowEnter

        CurrentStoreSuppliesRequisitionsItemID = -1
        If e.RowIndex < 0 Then
            Exit Sub
        End If
        If StoreSuppliesRequisitionsItemsRecordCount = 0 Then
            Exit Sub
        End If
        CurrentStoreSuppliesRequisitionsItemsDataGridViewRow = e.RowIndex
        CurrentStoreSuppliesRequisitionsItemID = StoreSuppliesRequisitionsItemsDataGridView.Item("StoreSuppliesRequisitionsItemID_AutoNumber", CurrentStoreSuppliesRequisitionsItemsDataGridViewRow).Value
        CurrentRequestedProductPartID = StoreSuppliesRequisitionsItemsDataGridView.Item("ProductsPartID_Autonumber", CurrentStoreSuppliesRequisitionsItemsDataGridViewRow).Value
        CurrentStoreSuppliesRequisitionsItemStatus = StoreSuppliesRequisitionsItemsDataGridView.Item("StatusText_ShortText25", CurrentStoreSuppliesRequisitionsItemsDataGridViewRow).Value
        EditItemToolStripMenuItem.Visible = False
        DeleteItemToolStripMenuItem.Visible = False
        SubmitRequisitionsForPurchaseToolStripMenuItem.Visible = False
        Select Case CurrentStoreSuppliesRequisitionsItemStatus
            Case "Draft"
                EditItemToolStripMenuItem.Visible = True
                DeleteItemToolStripMenuItem.Visible = True
                SubmitRequisitionsForPurchaseToolStripMenuItem.Visible = True
            Case "Submitted"
            Case "Received"
        End Select
    End Sub
    Public Sub FillPartsRequisitionsDataGridView()
        PartsRequisitionsSelectionOrder = " ORDER BY PartsRequisitionID_AutoNumber DESC "

        '        VehicleDescription.VehicleDescription,
        PartsRequisitionsFieldsToSelect =
" 
SELECT 
PartsRequisitionsTable.PartsRequisitionID_AutoNumber, 
PartsRequisitionsTable.RequisitionRevision_Integer, 
PartsRequisitionsTable.RequisitionDate_ShortDate, 
(trim(PersonnelTable.FirstName_ShortText30) & space(1) & Trim(PersonnelTable.LastName_ShortText30)) AS RequestedBy, 
PartsRequisitionsTable.PartsRequisitionType_Byte,
StatusesTable.StatusText_ShortText25,
StatusesTable.StatusSequence_LongInteger
FROM (PartsRequisitionsTable LEFT JOIN PersonnelTable ON PartsRequisitionsTable.RequestedByID_LongInteger = PersonnelTable.PersonnelID_AutoNumber) LEFT JOIN StatusesTable ON PartsRequisitionsTable.PartsRequisitionStatus_Integer = StatusesTable.StatusID_Autonumber
"
        MySelection = PartsRequisitionsFieldsToSelect & PartsRequisitionsSelectionFilter & PartsRequisitionsSelectionOrder
        JustExecuteMySelection()
        PartsRequisitionsRecordCount = RecordCount
        If PartsRequisitionsRecordCount = 0 Then
            PartsRequisitionsGroupBox.Visible = False
        Else
            PartsRequisitionsGroupBox.Visible = True
        End If
        PartsRequisitionsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        Dim RecordsToDisplay = 10
        SetGroupBoxHeight(RecordsToDisplay, PartsRequisitionsRecordCount, PartsRequisitionsGroupBox, PartsRequisitionsDataGridView)

        If Not PartsRequisitionsDataGridViewAlreadyFormatted Then
            FormatPartsRequisitionsDataGridView()
        End If
        StoreSuppliesRequisitionsItemsGroupBox.Top = PartsRequisitionsGroupBox.Top + PartsRequisitionsGroupBox.Height + 4
        Me.Left = 0
        PartsRequisitionsGroupBox.Left = 0
    End Sub
    Private Sub FormatPartsRequisitionsDataGridView()
        PartsRequisitionsDataGridViewAlreadyFormatted = True
        PartsRequisitionsGroupBox.Width = 0
        For i = 0 To PartsRequisitionsDataGridView.Columns.GetColumnCount(0) - 1

            PartsRequisitionsDataGridView.Columns.Item(i).Visible = False
            Select Case PartsRequisitionsDataGridView.Columns.Item(i).Name
                Case "PartsRequisitionID_AutoNumber"
                    PartsRequisitionsDataGridView.Columns.Item(i).HeaderText = "Requistion No."
                    PartsRequisitionsDataGridView.Columns.Item(i).Width = 90
                    PartsRequisitionsDataGridView.Columns.Item(i).Visible = True
                Case "RequisitionRevision_Integer"
                    PartsRequisitionsDataGridView.Columns.Item(i).HeaderText = "Rev."
                    PartsRequisitionsDataGridView.Columns.Item(i).Width = 50
                    PartsRequisitionsDataGridView.Columns.Item(i).Visible = True
                Case "RequisitionDate_ShortDate"
                    PartsRequisitionsDataGridView.Columns.Item(i).HeaderText = "Date"
                    PartsRequisitionsDataGridView.Columns.Item(i).Width = 100
                    PartsRequisitionsDataGridView.Columns.Item(i).Visible = True
                Case "RequestedBy"
                    PartsRequisitionsDataGridView.Columns.Item(i).HeaderText = "Requested By"
                    PartsRequisitionsDataGridView.Columns.Item(i).Width = 250
                    PartsRequisitionsDataGridView.Columns.Item(i).Visible = True
                Case "StatusText_ShortText25"
                    PartsRequisitionsDataGridView.Columns.Item(i).HeaderText = "Requisition Status"
                    PartsRequisitionsDataGridView.Columns.Item(i).Width = 150
                    PartsRequisitionsDataGridView.Columns.Item(i).Visible = True
            End Select
            If PartsRequisitionsDataGridView.Columns.Item(i).Visible = True Then
                'WIDTH OF DATAGRIDVIEW INSIDE A GROUPBOX AUTOMATICALLY ADJUST TO GroupBox.Width - 4
                PartsRequisitionsGroupBox.Width = PartsRequisitionsGroupBox.Width + PartsRequisitionsDataGridView.Columns.Item(i).Width
            End If
        Next
    End Sub
    Private Sub PartsRequisitionsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles PartsRequisitionsDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If PartsRequisitionsRecordCount = 0 Then Exit Sub

        CurrentPartsRequisitionsRow = e.RowIndex
        CurrentPartsRequisitionID = PartsRequisitionsDataGridView.Item("PartsRequisitionID_AutoNumber", CurrentPartsRequisitionsRow).Value
        CurrentPartsRequisitionStatus = NotNull(PartsRequisitionsDataGridView.Item("StatusText_ShortText25", CurrentPartsRequisitionsRow).Value)
        SubmitRequisitionsForPurchaseToolStripMenuItem.Visible = False
        DisAbleRequisitionItemsMenu()
        Select Case CurrentPartsRequisitionStatus
            Case "Draft"
                SubmitRequisitionsForPurchaseToolStripMenuItem.Visible = True
                EnableRequisitionItemsMenu()
        End Select
        StoreSuppliesRequisitionsItemsSelectionFilter = " WHERE PartsRequisitionID_LongInteger = " & CurrentPartsRequisitionID.ToString
        FillStoreSuppliesRequisitionsItemsDataGridView()
    End Sub
    Private Sub EnableRequisitionItemsMenu()
        EditItemToolStripMenuItem.Visible = True
        DeleteItemToolStripMenuItem.Visible = True
        AddItemToolStripMenuItem.Visible = True
    End Sub
    Private Sub DisAbleRequisitionItemsMenu()
        AddItemToolStripMenuItem.Visible = False
        EditItemToolStripMenuItem.Visible = False
        DeleteItemToolStripMenuItem.Visible = False
    End Sub
    Private Sub ReturnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnToolStripMenuItem.Click
        If RequisitionItemDetailsGroupBox.Visible Then
            If AChangeOccured() Then
                If MsgBox("A change was made, continue editing?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Exit Sub
                End If
            End If
            RequisitionItemDetailsGroupBox.Visible = False
            Exit Sub
        End If
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub

    Private Function AllItemsAreValid(PassedataGridView As DataGridView, PassedFieldToTest As String, PassedNoOfRecords As Integer,
                                      PassedFieldToDisplay As String, PassedMsg As String)
        Dim AllHaveValidStatus = True
        For i = 0 To PassedNoOfRecords - 1
            If IsEmpty(PassedataGridView.Item(PassedFieldToTest, i).Value) Then
                MsgBox(PassedataGridView.Item(PassedFieldToDisplay, i).Value & PassedMsg)
                AllHaveValidStatus = False
            End If
        Next
        If AllHaveValidStatus Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub ShowPurchaseOrdersForm()
        If MsgBox("Delete this Routine", vbYesNo) = vbNo Then
            Exit Sub
        End If
    End Sub


    Private Sub RequisitionDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RequisitionDetailsToolStripMenuItem.Click
        If RequisitionDetailsToolStripMenuItem.Text = "Requisition Details" Then
            RequisitionItemDetailsGroupBox.Visible = True
            RequisitionDetailsToolStripMenuItem.Text = "Requisition Details OFF"
        Else
            RequisitionItemDetailsGroupBox.Visible = False
            RequisitionDetailsToolStripMenuItem.Text = "Requisition Details"
        End If
    End Sub
    Private Sub OutstandingRequisitionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OutstandingRequisitionsToolStripMenuItem.Click
        SetRequisitionsSelectionFilter(GetStatusIdFor("Partially Ordered"), 1, Me, "OUTSTANDING REQUISITIONS")
    End Sub

    Private Sub PartiallyOrderedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PartiallyOrderedToolStripMenuItem.Click
        SetRequisitionsSelectionFilter(GetStatusIdFor("Partially Ordered"), 2, Me, "PARTIALLY ORDERED REQUISITIONS")
    End Sub

    Private Sub ReorderedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReorderedToolStripMenuItem.Click
        SetRequisitionsSelectionFilter(GetStatusIdFor("Re-ordered"), 2, Me, "RE-ORDERED REQUISITIONS")
    End Sub

    Private Sub CompletlyOrderedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompletlyOrderedToolStripMenuItem.Click
        SetRequisitionsSelectionFilter(GetStatusIdFor("Completely Ordered"), 2, Me, "COMPLETELY ORDERED REQUISITIONS")
    End Sub

    Private Sub AllRequisitionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllRequisitionsToolStripMenuItem.Click
        SetRequisitionsSelectionFilter(
                        GetStatusIdFor("PartsRequisitionsTable", "Completely Ordered", 1),
                        1,
                        Me,
                        "ALL REQUISITIONS"
                        )
        FillPartsRequisitionsDataGridView()
    End Sub

    Private Sub PrintRequissitionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintRequisitionToolStripMenuItem.Click

    End Sub
    Private Sub SetRequisitionsSelectionFilter(PassedStatusSequence As Integer, PassedStatusSequenceCondition As Integer, PassedForm As Form, FormHeaderText As String)
        PartsRequisitionsSelectionFilter = SetupTableSelectionFilter(PassedStatusSequence,
                                                                     PassedStatusSequenceCondition,
                                                                     PassedForm,
                                                                     FormHeaderText,
                                                                     "PartsRequisitionType_Byte = 2"
                                                                     )

        FillPartsRequisitionsDataGridView()
    End Sub

    Private Sub DeleteRequisitionToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If MsgBox("DELETE this Requisition?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            MySelection = " DELETE FROM PartsRequisitionsTable WHERE PartsRequisitionID_AutoNumber =  " & CurrentPartsRequisitionID
            JustExecuteMySelection()
            FillPartsRequisitionsDataGridView()
        End If

    End Sub

    Private Sub EXITSAVEChangesButton_Click(sender As Object, e As EventArgs) Handles EXITSAVEChangesButton.Click
        SaveChanges()
    End Sub
    Private Sub SaveChanges()

        If AChangeOccured() Then
            Dim xxmsgResult = MsgBox("Save Changes ?", MsgBoxStyle.YesNoCancel)
            If xxmsgResult = vbNo Then
                RequisitionItemDetailsGroupBox.Visible = False
                Exit Sub
            ElseIf xxmsgResult = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            'VALIDATION:
            If IsEmpty(PartTextBox.Text) Then
                PartTextBox.Select()
                Exit Sub
            End If
            If IsEmpty(RequisitionItemQuantityTextBox.Text) Then
                RequisitionItemQuantityTextBox.Select()
                Exit Sub
            End If
            If IsEmpty(RequisitionItemProductDescTextBox.Text) And
                IsEmpty(PartSpecificationTextBox.Text) Then
                PartSpecificationTextBox.Select()
                Exit Sub
            End If

        Else
            RequisitionItemDetailsGroupBox.Visible = False 'NO CHANGES
            Exit Sub
        End If
        If PurposeOfEntry = "ADD" Then
            Dim FieldsToUpdate = "
                            MasterCodeBookID_LongInteger, 
                            ProductPartID_LongInteger, 
                            StoreSupplyRequisitionQuantity_Double,
                            StoreSuppliesRequisitionsItemStatus_Integer,
                            "
            Dim FieldsData =
                            CurrentMasterCodeBookId.ToString & "," &
                            CurrentRequestedProductPartID.ToString & "," &
                            RequisitionItemQuantityTextBox.Text & "," &
                            GetStatusIdFor("StoreSuppliesRequisitionsItemsTable").ToString &
                            CurrentVehicleID.ToString
            FieldsToUpdate = "
                            MasterCodeBookID_LongInteger, 
                            ProductPartID_LongInteger,
                            StoreSupplyRequisitionQuantity_Double,
                            StoreSuppliesRequisitionsItemStatus_Integer,
                            VehicleID_LongInteger
                            "
            FieldsData =
                            CurrentMasterCodeBookId.ToString & "," &
                            CurrentRequestedProductPartID.ToString & "," &
                            RequisitionItemQuantityTextBox.Text & "," &
                            GetStatusIdFor("StoreSuppliesRequisitionsItemsTable").ToString() & "," &
                            CurrentVehicleID.ToString()

            CurrentStoreSuppliesRequisitionsItemID = InsertNewRecord("StoreSuppliesRequisitionsItemsTable", FieldsToUpdate, FieldsData)
        Else
            MsgBox("this segment has to be re coded")
            If MsgBox("About to replace original information, Continue ?", MsgBoxStyle.YesNo) = vbNo Then
                Exit Sub
            End If
            Dim RecordFilter = " WHERE StoreSuppliesRequisitionsItemID_AutoNumber = " & CurrentStoreSuppliesRequisitionsItemID.ToString
            Dim SetCommand = " SET ProductPartID_LongInteger = " & CurrentRequestedProductPartID.ToString & "," &
                             "StoreSupplyRequisitionQuantity_Double = " & Val(RequisitionItemQuantityTextBox.Text).ToString
            UpdateTable("StoreSuppliesRequisitionsItemsTable", SetCommand, RecordFilter)

            MsgBox("following update was not yet tested")
            RecordFilter = " WHERE ProductsPartID_Autonumber =  " & CurrentRequestedProductPartID.ToString
            SetCommand = " SET  Selected = True "
            UpdateTable("ProductsPartsTable", SetCommand, RecordFilter)
        End If
        RequisitionItemDetailsGroupBox.Visible = False
        FillStoreSuppliesRequisitionsItemsDataGridView()
    End Sub
    Private Function AChangeOccured()
        If TheseAreNotEqual(SavedProductPartID, CurrentRequestedProductPartID, PurposeOfEntry) Then Return True
        If TheseAreNotEqual(PartTextBox.Text, NotNull(StoreSuppliesRequisitionsItemsDataGridView.Item("MasterCodeBookTable.SystemDesc_ShortText100Fld", CurrentStoreSuppliesRequisitionsItemsDataGridViewRow).Value), PurposeOfEntry) Then Return True
        If TheseAreNotEqual(POItemProductPartNoTextBox.Text, NotNull(StoreSuppliesRequisitionsItemsDataGridView.Item("Price_Currency", CurrentStoreSuppliesRequisitionsItemsDataGridViewRow).Value), PurposeOfEntry) Then Return True
        If TheseAreNotEqual(RequisitionItemProductDescTextBox.Text, NotNull(StoreSuppliesRequisitionsItemsDataGridView.Item("ProductsPartsOrderedTable.ManufacturerDescription_ShortText250", CurrentStoreSuppliesRequisitionsItemsDataGridViewRow).Value), PurposeOfEntry) Then Return True
        If TheseAreNotEqual(RequisitionItemQuantityTextBox.Text, NotNull(StoreSuppliesRequisitionsItemsDataGridView.Item("StoreSupplyRequisitionQuantity_Double", CurrentStoreSuppliesRequisitionsItemsDataGridViewRow).Value), PurposeOfEntry) Then Return True
        If TheseAreNotEqual(RequisitionItemUnitTextBox.Text, NotNull(StoreSuppliesRequisitionsItemsDataGridView.Item("StoreSupplyRequisitionUnit_ShortText3", CurrentStoreSuppliesRequisitionsItemsDataGridViewRow).Value), PurposeOfEntry) Then Return True
        Return False
    End Function

    Private Sub PartTextBox_Click(sender As Object, e As EventArgs) Handles PartTextBox.Click
        If IsNotEmpty(PartTextBox.Text) Then
            If MsgBox("Do you want to change the part? ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        ShowCalledForm(Me, MasterCodeBookForm)

    End Sub
    Private Sub PartSpecificationTextBox_Click(sender As Object, e As EventArgs) Handles PartSpecificationTextBox.Click
        If IsNotEmpty(PartTextBox.Text) Then
            If MsgBox("Do you want to change the part? ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        Tunnel1 = "Tunnel2IsMasterCodeBookID"
        Tunnel2 = CurrentMasterCodeBookId
        ShowCalledForm(Me, PartsSpecificationsForm)
    End Sub
    Private Sub POItemProductDescTextBox_TextChanged(sender As Object, e As EventArgs) Handles RequisitionItemProductDescTextBox.Click
        If RequisitionItemProductDescTextBox.Text <> "" Then
            If MsgBox("Do you intend to replace the Product?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        Tunnel2 = CurrentMasterCodeBookId
        ProductsPartsForm.PartDescriptionSearchTextBox.Text = PartTextBox.Text
        ShowCalledForm(Me, ProductsPartsForm)

    End Sub
    Private Sub POItemProductPartNoTextBox_Click(sender As Object, e As EventArgs) Handles POItemProductPartNoTextBox.Click
        If RequisitionItemProductDescTextBox.Text <> "" Then
            If MsgBox("Do you intend to replace the Product?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        ShowCalledForm(Me, ProductsPartsForm)
    End Sub
    Private Sub AddPartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddItemToolStripMenuItem.Click
        'note items will be selected from the PartsRequisitions for purchase
        PurposeOfEntry = "ADD"
        CurrentStoreSuppliesRequisitionsItemID = -1
        PartTextBox.Text = ""
        RequisitionItemProductDescTextBox.Text = ""
        POItemProductPartNoTextBox.Text = ""
        RequisitionItemQuantityTextBox.Text = ""
        RequisitionItemUnitTextBox.Text = ""
        ProductSpecificationTextBox.Text = ""
        BrandTextBox.Text = ""
        PackingTextBox.Text = ""
        RequisitionItemDetailsGroupBox.Visible = True
    End Sub

    Private Sub SubmitRequisitionsForPurchaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SubmitRequisitionsForPurchaseToolStripMenuItem.Click
        'VALIDATION
        Dim xxEmptyField = ""

        If MsgBox("Continue submit requisition for purchase?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        'CREATE A HEADER HERE

        Dim FieldsToUpdate = " RequisitionDate_ShortDate, " &
                                " RequestedByID_LongInteger, " &
                                " PartsRequisitionStatus_Integer,  " &
                                " PartsRequisitionType_Byte  "

        Dim FieldsData = Chr(34) & DateString & Chr(34) & ", " &
                                CurrentUserID.ToString & ", " &
                                GetStatusIdFor("PartsRequisitionsTable", "Submitted").ToString & ", " &
                                2.ToString

        CurrentPartsRequisitionID = InsertNewRecord("PartsRequisitionsTable", FieldsToUpdate, FieldsData)




        'ALL TEMPORARY ITEMS IN StoreRequisitionsItemsTable WILL THEN BE MARKED submited, StoreSuppliesRequisitionsItemStatus_Byte = 1
        ' WITH THE NEWLY CREATED PartsRequisitionsHeader
        For i = 0 To StoreSuppliesRequisitionsItemsRecordCount - 1
            CurrentStoreSuppliesRequisitionsItemID = StoreSuppliesRequisitionsItemsDataGridView.Item("StoreSuppliesRequisitionsItemID_AutoNumber", i).Value
            CurrentRequestedProductPartID = StoreSuppliesRequisitionsItemsDataGridView.Item("ProductsPartID_Autonumber", i).Value

            MySelection = " UPDATE StoreSuppliesRequisitionsItemsTable  " &
                              " SET StoreSuppliesRequisitionsItemStatus_Integer = " & GetStatusIdFor("StoreSuppliesRequisitionsItemsTable", "Submitted") &
                              " WHERE StoreSuppliesRequisitionsItemID_AutoNumber = " & CurrentStoreSuppliesRequisitionsItemID.ToString
            JustExecuteMySelection()

            FieldsToUpdate = " PartsRequisitionID_LongInteger, " &
                             " StoreSuppliesRequisitionsItemID_LongInteger, " &
                            " ProductPartID_LongInteger, " &
                            " RequisitionQuantity_Double, " &
                            " PartsRequisitionItemStatusID_LongInteger "

            FieldsData = CurrentPartsRequisitionID.ToString & ", " &
                    StoreSuppliesRequisitionsItemsDataGridView.Item("StoreSuppliesRequisitionsItemID_AutoNumber", i).Value & ", " &
                    CurrentRequestedProductPartID.ToString() & ", " &
                    StoreSuppliesRequisitionsItemsDataGridView.Item("StoreSupplyRequisitionQuantity_Double", i).Value & ", " &
                    GetStatusIdFor("PartsRequisitionsItemsTable").ToString

            CurrentStoreSuppliesRequisitionsItemID = InsertNewRecord("PartsRequisitionsItemsTable", FieldsToUpdate, FieldsData)
            Dim xxRecordFilter = " WHERE ProductsPartID_Autonumber = " & CurrentRequestedProductPartID.ToString
            Dim xxSetCommand = " SET  Selected = True "
            UpdateTable("ProductsPartsTable", xxSetCommand, xxRecordFilter)
        Next

        'check this

        FillStoreSuppliesRequisitionsItemsDataGridView()
        Dim RecordFilter = " WHERE PartsRequisitionID_AutoNumber = " & CurrentPartsRequisitionID.ToString
        Dim SetCommand = " SET PartsRequisitionStatus_Integer = " & GetStatusIdFor("PartsRequisitionsTable", "Submitted")
        UpdateTable("PartsRequisitionsTable", SetCommand, RecordFilter)

        FillPartsRequisitionsDataGridView()

    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditItemToolStripMenuItem.Click
        PartTextBox.Text = NotNull(StoreSuppliesRequisitionsItemsDataGridView.Item("SystemDesc_ShortText100Fld", CurrentStoreSuppliesRequisitionsItemsDataGridViewRow).Value)
        RequisitionItemProductDescTextBox.Text = NotNull(StoreSuppliesRequisitionsItemsDataGridView.Item("ManufacturerDescription_ShortText250", CurrentStoreSuppliesRequisitionsItemsDataGridViewRow).Value)
        POItemProductPartNoTextBox.Text = NotNull(StoreSuppliesRequisitionsItemsDataGridView.Item("ManufacturerPartNo_ShortText30Fld", CurrentStoreSuppliesRequisitionsItemsDataGridViewRow).Value)
        RequisitionItemQuantityTextBox.Text = NotNull(StoreSuppliesRequisitionsItemsDataGridView.Item("StoreSupplyRequisitionQuantity_Double", CurrentStoreSuppliesRequisitionsItemsDataGridViewRow).Value)
        RequisitionItemUnitTextBox.Text = NotNull(StoreSuppliesRequisitionsItemsDataGridView.Item("Unit_ShortText3", CurrentStoreSuppliesRequisitionsItemsDataGridViewRow).Value)
        SavedProductPartID = CurrentRequestedProductPartID
        RequisitionItemDetailsGroupBox.Visible = True
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteItemToolStripMenuItem.Click
        If MsgBox("Proceed to delete ?", MsgBoxStyle.YesNo) = vbNo Then
            Exit Sub
        End If
        MySelection = "DELETE FROM StoreSuppliesRequisitionsItemsTable WHERE StoreSuppliesRequisitionsItemID_AutoNumber = " & Str(CurrentStoreSuppliesRequisitionsItemID)
        JustExecuteMySelection()
        FillStoreSuppliesRequisitionsItemsDataGridView()
    End Sub

    Private Sub RequisitionItemDetailsGroupBox_EnabledChanged(sender As Object, e As EventArgs) Handles RequisitionItemDetailsGroupBox.VisibleChanged
        If RequisitionItemDetailsGroupBox.Visible = True Then
            AddItemToolStripMenuItem.Visible = False
            SubmitRequisitionsForPurchaseToolStripMenuItem.Visible = False
            ViewToolStripMenuItem.Visible = False
            If CurrentMasterCodeBookId > 0 Then
                RequisitionItemProductDescTextBox.Enabled = True
                POItemProductPartNoTextBox.Enabled = True
                RequisitionItemQuantityTextBox.Enabled = True
            Else
                RequisitionItemProductDescTextBox.Enabled = False
                POItemProductPartNoTextBox.Enabled = False
                RequisitionItemQuantityTextBox.Enabled = False
                PartTextBox.Select()
            End If
        Else
            AddItemToolStripMenuItem.Visible = True
            SubmitRequisitionsForPurchaseToolStripMenuItem.Visible = True
            ViewToolStripMenuItem.Visible = True
        End If
    End Sub

End Class