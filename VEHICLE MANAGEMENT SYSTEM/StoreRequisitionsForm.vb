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

    Private CurrentPartsRequisitionsItemID = -1

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
    Private Sub PartsRequisitionsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        MySelection = StoreSuppliesRequisitionsItemsFieldsToSelect & StoreSuppliesRequisitionsItemsTableLinks & StoreSuppliesRequisitionsItemsSelectionFilter & StoreSuppliesRequisitionsItemsSelectionOrder
        SavedCallingForm = CallingForm
        SetScreenToDraftMode()

    End Sub

    Private Sub PartsRequisitionsForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        If Me.Enabled = False Then Exit Sub
        CallingForm = SavedCallingForm
        ' GET RETURNED DATA HERE
        Select Case Tunnel1
            Case "Tunnel2IsMasterCodeBookID"
                CurrentMasterCodeBookId = Tunnel2
                PartTextBox.Text = Tunnel3
            Case "Tunnel2IsProductPartID"
                CurrentRequestedProductPartID = Tunnel2
                RequisitionItemQuantityTextBox.Select()
            Case Else
                MsgBox("setup this routine")
        End Select
    End Sub
    Private Sub FillStoreSuppliesRequisitionsItemsDataGridView()
        Dim xxDraft = " IIf(StoreSuppliesRequisitionsItemsTable.StoreSuppliesRequisitionsItemStatus_Byte = 0, " & Chr(34) & "Draft" & Chr(34) & ","
        Dim xxSubmitted = " IIf(StoreSuppliesRequisitionsItemsTable.StoreSuppliesRequisitionsItemStatus_Byte= 1, " & Chr(34) & "Submitted" & Chr(34) & ","
        Dim xxReordered = " IIf(StoreSuppliesRequisitionsItemsTable.StoreSuppliesRequisitionsItemStatus_Byte= 2, " & Chr(34) & "Re-ordered" & Chr(34) & ","
        Dim xxCompletelyOrdered = " IIf(StoreSuppliesRequisitionsItemsTable.StoreSuppliesRequisitionsItemStatus_Byte= 3, " & Chr(34) & "Ordered" & Chr(34) & ","

        Dim StoreSuppliesRequisitionsItemStatus = xxDraft & xxSubmitted & xxCompletelyOrdered & xxReordered & Chr(34) & Chr(34) &
                                " )))) AS StoreSuppliesRequisitionsItemStatus "

        StoreSuppliesRequisitionsItemsFieldsToSelect =
"
SELECT StoreSuppliesRequisitionsItemsTable.StoreSuppliesRequisitionsItemID_AutoNumber,
StoreSuppliesRequisitionsItemsTable.MasterCodeBookID_LongInteger,
StoreSuppliesRequisitionsItemsTable.ProductPartID_LongInteger,
MasterCodeBookTable.SystemDesc_ShortText100Fld,
StoreSuppliesRequisitionsItemsTable.StoreSupplyRequisitionQuantity_Double, 
StoreSuppliesRequisitionsItemsTable.StoreSupplyRequisitionUnit_ShortText3, 
StoreSuppliesRequisitionsItemsTable.VehicleID_LongInteger,
StoreSuppliesRequisitionsItemsTable.StoreSuppliesRequisitionsItemStatus_Byte,
ProductsPartsTableRequested.ManufacturerPartNo_ShortText30Fld,
ProductsPartsTableRequested.ManufacturerDescription_ShortText250,
ProductsPartsTableRequested.Unit_ShortText3, 
BrandsTableRequested.BrandName_ShortText20,
ProductsPartsTableRequested.BrandID_LongInteger,
ProductsPartsTableRequested.MasterCodeBookID_LongInteger,
PartsRequisitionsItemsTable.ProductPartID_LongInteger,
PartsRequisitionsItemsTable.RequisitionQuantity_Double,
PartsRequisitionsItemsTable.PartsRequisitionID_LongInteger,
ProductsPartsTablePurchased.ManufacturerPartNo_ShortText30Fld,
ProductsPartsTablePurchased.ManufacturerDescription_ShortText250,
ProductsPartsTablePurchased.Unit_ShortText3,
BrandsTableOrdered.BrandName_ShortText20, 
" & StoreSuppliesRequisitionsItemStatus & "
FROM (((PartsRequisitionsItemsTable RIGHT JOIN (((StoreSuppliesRequisitionsItemsTable LEFT JOIN MasterCodeBookTable ON StoreSuppliesRequisitionsItemsTable.MasterCodeBookID_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) LEFT JOIN ProductsPartsTable AS ProductsPartsTableRequested ON StoreSuppliesRequisitionsItemsTable.ProductPartID_LongInteger = ProductsPartsTableRequested.ProductsPartID_Autonumber) LEFT JOIN VehicleDescription ON StoreSuppliesRequisitionsItemsTable.VehicleID_LongInteger = VehicleDescription.VehicleID_AutoNumber) ON PartsRequisitionsItemsTable.OrderPartsRequisitionsItemID_LongInteger = StoreSuppliesRequisitionsItemsTable.StoreSuppliesRequisitionsItemID_AutoNumber) LEFT JOIN ProductsPartsTable AS ProductsPartsTablePurchased ON PartsRequisitionsItemsTable.ProductPartID_LongInteger = ProductsPartsTablePurchased.ProductsPartID_Autonumber) LEFT JOIN BrandsTable AS BrandsTableOrdered ON ProductsPartsTablePurchased.BrandID_LongInteger = BrandsTableOrdered.BrandID_Autonumber) LEFT JOIN BrandsTable AS BrandsTableRequested ON ProductsPartsTableRequested.BrandID_LongInteger = BrandsTableRequested.BrandID_Autonumber
"
        StoreSuppliesRequisitionsItemsTableLinks =
""
        StoreSuppliesRequisitionsItemsFieldsToSelect =
"
"
        MySelection = StoreSuppliesRequisitionsItemsFieldsToSelect & StoreSuppliesRequisitionsItemsTableLinks & StoreSuppliesRequisitionsItemsSelectionFilter & StoreSuppliesRequisitionsItemsSelectionOrder
        JustExecuteMySelection()

        StoreSuppliesRequisitionsItemsRecordCount = RecordCount
        StoreSuppliesRequisitionsItemsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        Dim NoOfHeaderLines = 2, RecordsToDisplay = 28
        SetGroupBoxHeight(NoOfHeaderLines, RecordsToDisplay, StoreSuppliesRequisitionsItemsRecordCount, StoreSuppliesRequisitionsItemsGroupBox, StoreSuppliesRequisitionsItemsDataGridView)

        If Not StoreSuppliesRequisitionsItemsDataGridViewAlreadyFormated Then
            FormatStoreSuppliesRequisitionsItemsDataGridView()
        End If
    End Sub
    Private Sub FormatStoreSuppliesRequisitionsItemsDataGridView()
        StoreSuppliesRequisitionsItemsDataGridViewAlreadyFormated = True
        StoreSuppliesRequisitionsItemsGroupBox.Width = 0
        For i = 0 To StoreSuppliesRequisitionsItemsDataGridView.Columns.GetColumnCount(0) - 1

            StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).Visible = False

            Select Case StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).Name
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
                Case "ProductsPartsTableRequested.ManufacturerPartNo_ShortText30Fld"
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Reqstd. Part No"
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).Width = 135
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "ProductsPartsTableRequested.ManufacturerDescription_ShortText250"
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Reqstd. Description"
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).Width = 350
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                    StoreSuppliesRequisitionsItemsDataGridView.Columns(i).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                Case "ProductsPartsTableRequested.Unit_ShortText3"
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Reqstd. Unit"
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).Width = 120
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "BrandsTableOrdered.BrandName_ShortText20"
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Reqstd Brand"
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).Width = 150
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "StoreSuppliesRequisitionsItemStatus"
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Status"
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).Width = 120
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "ProductsPartsTablePurchased.ManufacturerPartNo_ShortText30Fld"
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Purchd. Part No"
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).Width = 135
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "ProductsPartsTablePurchased.ManufacturerDescription_ShortText250"
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Purchd. Description"
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).Width = 350
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                    StoreSuppliesRequisitionsItemsDataGridView.Columns(i).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                Case "ProductsPartsTablePurchased.Unit_ShortText3"
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Purchd. Unit"
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).Width = 120
                    StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
            End Select
            If StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).Visible = True Then
                'WIDTH OF DATAGRIDVIEW INSIDE A GROUPBOX AUTOMATICALLY ADJUST TO GroupBox.Width - 4
                StoreSuppliesRequisitionsItemsGroupBox.Width = StoreSuppliesRequisitionsItemsGroupBox.Width + StoreSuppliesRequisitionsItemsDataGridView.Columns.Item(i).Width
            End If
        Next
        If StoreSuppliesRequisitionsItemsGroupBox.Width > Me.Width Then
            'WIDTH OF DATAGRIDVIEW INSIDE A GROUPBOX AUTOMATICALLY ADJUST TO GroupBox.Width - 4
            StoreSuppliesRequisitionsItemsGroupBox.Width = Me.Width - 2
        End If
        StoreSuppliesRequisitionsItemsGroupBox.Top = PartsRequisitionsMenuStrip.Top + PartsRequisitionsMenuStrip.Height
        StoreSuppliesRequisitionsItemsGroupBox.Left = Me.Left

    End Sub
    Private Sub StoreSuppliesRequisitionsItemsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs)

        CurrentStoreSuppliesRequisitionsItemID = -1
        If e.RowIndex < 0 Then
            Exit Sub
        End If
        If StoreSuppliesRequisitionsItemsRecordCount = 0 Then
            Exit Sub
        End If
        CurrentStoreSuppliesRequisitionsItemsDataGridViewRow = e.RowIndex
        CurrentStoreSuppliesRequisitionsItemID = StoreSuppliesRequisitionsItemsDataGridView.Item("StoreSuppliesRequisitionsItemID_AutoNumber", CurrentStoreSuppliesRequisitionsItemsDataGridViewRow).Value
        CurrentRequestedProductPartID = StoreSuppliesRequisitionsItemsDataGridView.Item("ProductPartID_LongInteger", CurrentStoreSuppliesRequisitionsItemsDataGridViewRow).Value
        If StoreSuppliesRequisitionsItemsDataGridView.Item("StoreSuppliesRequisitionsItemStatus", CurrentStoreSuppliesRequisitionsItemsDataGridViewRow).Value = "Ordered" Then
            StoreSuppliesRequisitionsItemsDataGridView.Rows(CurrentStoreSuppliesRequisitionsItemsDataGridViewRow).DefaultCellStyle.ForeColor = Color.Red
        End If
        If Not StoreSuppliesRequisitionsItemsDataGridView.Item("StoreSuppliesRequisitionsItemStatus", CurrentStoreSuppliesRequisitionsItemsDataGridViewRow).Value = "Outstanding" Then
            RequisitionDetailsToolStripMenuItem.Visible = True
        Else
            RequisitionDetailsToolStripMenuItem.Visible = False
        End If
    End Sub
    Public Sub FillPartsRequisitionsDataGridView()
        PartsRequisitionsSelectionOrder = " ORDER BY PartsRequisitionID_AutoNumber DESC "
        Dim xxOutstanding = " IIf(PartsRequisitionsTable.PartsRequisitionStatus_Integer = 0, " & Chr(34) & "Outstanding" & Chr(34) & ","
        Dim xxDraft = " IIf(PartsRequisitionsTable.PartsRequisitionStatus_Integer = -1, " & Chr(34) & "Draft" & Chr(34) & ","
        Dim xxPartiallyOrdered = " IIf(PartsRequisitionsTable.PartsRequisitionStatus_Integer = 1, " & Chr(34) & "Partially Ordered" & Chr(34) & ","
        Dim xxReordered = " IIf(PartsRequisitionsTable.PartsRequisitionStatus_Integer = 2, " & Chr(34) & "Re-Ordered" & Chr(34) & ","
        Dim xxCompletelyOrdered = " IIf(PartsRequisitionsTable.PartsRequisitionStatus_Integer = 3, " & Chr(34) & "Completely Ordered" & Chr(34) & ","

        PartsRequisitionStatus = xxOutstanding & xxDraft & xxPartiallyOrdered & xxCompletelyOrdered & xxReordered & Chr(34) & Chr(34) &
                                " ))))) AS PartsRequisitionStatus "

        PartsRequisitionsFieldsToSelect = " 
SELECT PartsRequisitionsTable.PartsRequisitionID_AutoNumber, 
PartsRequisitionsTable.RequisitionRevision_Integer, 
PartsRequisitionsTable.RequisitionDate_ShortDate, 
PartsRequisitionsTable.RequestedByID_LongInteger, 
PartsRequisitionsTable.PartsRequisitionStatus_Integer, 
PartsRequisitionsTable.VehicleID_LongInteger, 
PartsRequisitionsTable.PartsRequisitionStatus_Integer, 
PartsRequisitionsTable.PartsRequisitionStatus_Integer, 
PartsRequisitionsTable.PartsRequisitionType_Byte, 
PartsRequisitionsTable.PartsRequisitionStatus_Integer, 
PartsRequisitionsTable.PartsRequisitionType_Byte, 
VehicleDescription.VehicleDescription,
PartsRequisitionsTable.PartsRequisitionStatus_Integer,
" & PartsRequisitionStatus

        PartsRequisitionsTableLinks = " 
FROM ((PartsRequisitionsTable LEFT JOIN PersonnelTable ON PartsRequisitionsTable.RequestedByID_LongInteger = PersonnelTable.PersonnelID_AutoNumber) LEFT JOIN VehiclesTable ON PartsRequisitionsTable.VehicleID_LongInteger = VehiclesTable.VehicleID_AutoNumber) LEFT JOIN VehicleDescription ON VehiclesTable.VehicleID_AutoNumber = VehicleDescription.VehicleID_AutoNumber
"
        MySelection = PartsRequisitionsFieldsToSelect & PartsRequisitionsTableLinks & PartsRequisitionsSelectionFilter & PartsRequisitionsSelectionOrder
        JustExecuteMySelection()
        PartsRequisitionsRecordCount = RecordCount
        PartsRequisitionsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If PartsRequisitionsRecordCount = 0 Then
            PartsRequisitionsGroupBox.Visible = False
        Else
            PartsRequisitionsGroupBox.Visible = True
        End If

        Dim NoOfHeaderLines = 1, RecordsToDisplay = 10
        SetGroupBoxHeight(NoOfHeaderLines, RecordsToDisplay, PartsRequisitionsRecordCount, PartsRequisitionsGroupBox, PartsRequisitionsDataGridView)

        If Not PartsRequisitionsDataGridViewAlreadyFormatted Then
            FormatPartsRequisitionsDataGridView()
        End If
        StoreSuppliesRequisitionsItemsGroupBox.Top = PartsRequisitionsGroupBox.Top + PartsRequisitionsGroupBox.Height + 4
        SetFormWidthAndGroupBoxLeft()
        Me.Width = VehicleManagementSystemForm.Width - 4
        Me.Left = (VehicleManagementSystemForm.Width - Me.Width) / 2
        PartsRequisitionsGroupBox.Left = 2
        StoreSuppliesRequisitionsItemsGroupBox.Left = 2
    End Sub
    Private Sub SetFormWidthAndGroupBoxLeft()
        Dim LargestWidth = 0
        For i = 1 To 2
            If PartsRequisitionsGroupBox.Width > LargestWidth Then
                LargestWidth = PartsRequisitionsGroupBox.Width
            ElseIf StoreSuppliesRequisitionsItemsGroupBox.Width > LargestWidth Then
                LargestWidth = StoreSuppliesRequisitionsItemsGroupBox.Width
            End If
        Next
        If LargestWidth > VehicleManagementSystemForm.Width Then
        Else
            Me.Width = LargestWidth + 4
        End If
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
                Case "VehicleDescription"
                    PartsRequisitionsDataGridView.Columns.Item(i).HeaderText = "For Vehicle"
                    PartsRequisitionsDataGridView.Columns.Item(i).Width = 300
                    PartsRequisitionsDataGridView.Columns.Item(i).Visible = True
                Case "RequestedBy"
                    PartsRequisitionsDataGridView.Columns.Item(i).HeaderText = "Requested By"
                    PartsRequisitionsDataGridView.Columns.Item(i).Width = 250
                    PartsRequisitionsDataGridView.Columns.Item(i).Visible = True
                Case "PartsRequisitionStatus"
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
        CurrentVehicleID = PartsRequisitionsDataGridView.Item("VehicleID_LongInteger", CurrentPartsRequisitionsRow).Value
        CurrentPartsRequisitionStatus = NotNull(PartsRequisitionsDataGridView.Item("PartsRequisitionStatus_Integer", CurrentPartsRequisitionsRow).Value)
        If CurrentPartsRequisitionStatus = -1 Then
            SubmitRequisitionsForPurchaseToolStripMenuItem.Visible = True
            EnableRequisitionItemsMenu()
        Else
            SubmitRequisitionsForPurchaseToolStripMenuItem.Visible = False
            DisAbleRequisitionItemsMenu()
        End If
        StoreSuppliesRequisitionsItemsSelectionFilter = " WHERE PartsRequisitionID_LongInteger = " & CurrentPartsRequisitionID.ToString
        FillStoreSuppliesRequisitionsItemsDataGridView()
    End Sub
    Private Sub EnableRequisitionItemsMenu()
        EditItemToolStripMenuItem.Visible = True
        DeleteItemToolStripMenuItem.Visible = True
    End Sub
    Private Sub DisAbleRequisitionItemsMenu()
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
    Private Sub DraftRequisitionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DraftRequisitionsToolStripMenuItem.Click
        SetScreenToDraftMode()
    End Sub
    Private Sub SetScreenToDraftMode()
        PartsRequisitionsGroupBox.Visible = False
        StoreSuppliesRequisitionsItemsGroupBox.Visible = True
        StoreSuppliesRequisitionsItemsSelectionFilter = " WHERE StoreSuppliesRequisitionsItemStatus_Byte = 0 "
        FillStoreSuppliesRequisitionsItemsDataGridView()

    End Sub
    Private Sub OutstandingRequisitionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OutstandingRequisitionsToolStripMenuItem.Click
        SetRequisitionsSelectionFilter(0, Me, "OUTSTANDING REQUISITIONS")
    End Sub

    Private Sub PartiallyOrderedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PartiallyOrderedToolStripMenuItem.Click
        SetRequisitionsSelectionFilter(1, Me, "PARTIALLY ORDERED REQUISITIONS")
    End Sub

    Private Sub ReorderedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReorderedToolStripMenuItem.Click
        SetRequisitionsSelectionFilter(2, Me, "RE-ORDERED REQUISITIONS")
    End Sub

    Private Sub CompletlyOrderedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompletlyOrderedToolStripMenuItem.Click
        SetRequisitionsSelectionFilter(3, Me, "COMPLETELY ORDERED REQUISITIONS")
    End Sub

    Private Sub AllRequisitionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllRequisitionsToolStripMenuItem.Click
        SetRequisitionsSelectionFilter(10, Me, "ALL REQUISITIONS")
    End Sub

    Private Sub PrintRequissitionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintRequisitionToolStripMenuItem.Click

    End Sub
    Private Sub SetRequisitionsSelectionFilter(PassedStatusCode As Integer, PassedForm As Form, FormHeaderText As String)

        PartsRequisitionsSelectionFilter = SetupTableSelectionFilter(PassedStatusCode, PassedForm, FormHeaderText, " PartsRequisitionType_Byte = 2 ")
        PartsRequisitionsSelectionFilter = Replace(PartsRequisitionsSelectionFilter, "StoreRequisitionStatus_Byte", "PartsRequisitionStatus_Integer")

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
        If PurposeOfEntry = "ADD" Then
            Dim FieldsToUpdate = "
                            MasterCodeBookID_LongInteger, 
                            ProductPartID_LongInteger, 
                            StoreSupplyRequisitionQuantity_Double,
                            StoreSupplyRequisitionUnit_ShortText3,
                            VehicleID_LongInteger
                            "
            Dim FieldsData =
                            CurrentMasterCodeBookId.ToString & "," &
                            CurrentRequestedProductPartID.ToString & "," &
                            RequisitionItemQuantityTextBox.Text & "," &
                            Chr(34) & RequisitionItemUnitTextBox.Text & Chr(34) & ", " &
                            CurrentVehicleID.ToString

            CurrentPartsRequisitionID = InsertNewRecord("StoreSuppliesRequisitionsItemsTable", FieldsToUpdate, FieldsData)
        Else

            If AChangeOccured() Then
                Dim xxmsgResult = MsgBox("Save Changes ?", MsgBoxStyle.YesNoCancel)
                If xxmsgResult = vbNo Then
                    RequisitionItemDetailsGroupBox.Visible = False
                    Exit Sub
                ElseIf xxmsgResult = MsgBoxResult.Cancel Then
                    Exit Sub
                End If
            Else
                RequisitionItemDetailsGroupBox.Visible = False 'NO CHANGES
                Exit Sub
            End If
            If MsgBox("About to replace original information, Continue ?", MsgBoxStyle.YesNo) = vbNo Then
                Exit Sub
            End If
            Dim RecordFilter = " WHERE PurchaseOrdersItemID_AutoNumber = " & CurrentPartsRequisitionsItemID.ToString
            Dim SetCommand = " SET ProductPartID_LongInteger = " & CurrentRequestedProductPartID.ToString & "," &
                                      "StoreSupplyRequisitionQuantity_Double = " & Val(RequisitionItemQuantityTextBox.Text).ToString
            UpdateTable("PurchaseOrdersItemsTable", SetCommand, RecordFilter)
        End If
        RequisitionItemDetailsGroupBox.Visible = False
        FillPartsRequisitionsDataGridView()
    End Sub
    Private Function AChangeOccured()



        '*******************************************************
        ' CHECK THIS THE TheseAreNotEqual ROUTINE WAS MODIFIED, WATCH PARAMETER pURPOSEOFENTRY





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
        MasterCodeBookForm.ChangeVehicleDefaults.Enabled = True
        ShowCalledForm(Me, MasterCodeBookForm)

    End Sub

    Private Sub POItemProductDescTextBox_TextChanged(sender As Object, e As EventArgs) Handles RequisitionItemProductDescTextBox.Click
        If RequisitionItemProductDescTextBox.Text <> "" Then
            If MsgBox("Do you intend to replace the Product?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        Tunnel1 = CurrentMasterCodeBookId
        Tunnel2 = PartTextBox.Text
        ShowCalledForm(Me, ProductsPartsForm)

    End Sub

    Private Sub AddPartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddItemToolStripMenuItem.Click
        'note items will be selected from the PartsRequisitions for purchase
        SetScreenToDraftMode()
        PurposeOfEntry = "ADD"
        CurrentPartsRequisitionsItemID = -1
        RequisitionItemDetailsGroupBox.Visible = True
        PartTextBox.Text = ""
        RequisitionItemProductDescTextBox.Text = ""
        POItemProductPartNoTextBox.Text = ""
        RequisitionItemQuantityTextBox.Text = ""
        RequisitionItemUnitTextBox.Text = ""
    End Sub

    Private Sub SubmitRequisitionsForPurchaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SubmitRequisitionsForPurchaseToolStripMenuItem.Click
        'VALIDATION
        Dim xxEmptyField = ""
        For i = 0 To StoreSuppliesRequisitionsItemsRecordCount - 1
            If IsEmpty(StoreSuppliesRequisitionsItemsDataGridView.Item("StoreSupplyRequisitionUnit_ShortText3", i).Value) Then
                xxEmptyField = "Unit"
            ElseIf IsEmpty(StoreSuppliesRequisitionsItemsDataGridView.Item("StoreSupplyRequisitionQuantity_Double", i).Value) Then
                xxEmptyField = "Quantity"
            ElseIf IsEmpty(StoreSuppliesRequisitionsItemsDataGridView.Item("ProductsPartsTableRequested.MasterCodeBookID_LongInteger", i).Value) Then
                xxEmptyField = "Kind of Part"
            End If
            If Not xxEmptyField = "" Then
                MsgBox(xxEmptyField & " of item " & i + 1.ToString & " should not be empty")
                Exit Sub
            End If
        Next

        If MsgBox("Continue submit requisition for purchase?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        'CREATE A HEADER HERE

        Dim FieldsToUpdate = " RequisitionDate_ShortDate, " &
                                " RequestedByID_LongInteger, " &
                                " PartsRequisitionType_Byte  "

        Dim FieldsData = Chr(34) & DateString & Chr(34) & ", " &
                                CurrentUserID.ToString & ", " &
                                2.ToString

        CurrentPartsRequisitionID = InsertNewRecord("PartsRequisitionsTable", FieldsToUpdate, FieldsData)



        'ALL TEMPORARY ITEMS IN StoreRequisitionsItemsTable WILL THEN BE MARKED submited, StoreSuppliesRequisitionsItemStatus_Byte = 1
        ' WITH THE NEWLY CREATED PartsRequisitionsHeader
        For i = 0 To StoreSuppliesRequisitionsItemsRecordCount - 1
            CurrentStoreSuppliesRequisitionsItemID = StoreSuppliesRequisitionsItemsDataGridView.Item("StoreSuppliesRequisitionsItemID_AutoNumber", i).Value
            CurrentRequestedProductPartID = -1
            CurrentRequestedProductPartID = StoreSuppliesRequisitionsItemsDataGridView.Item("StoreSuppliesRequisitionsItemsTable.ProductPartID_LongInteger", i).Value
            CurrentPartsRequisitionsItemID = StoreSuppliesRequisitionsItemsDataGridView.Item("StoreSuppliesRequisitionsItemID_AutoNumber", i).Value

            MySelection = " UPDATE StoreSuppliesRequisitionsItemsTable  " &
                              " SET StoreSuppliesRequisitionsItemStatus_Byte = 1 " &
                              " WHERE StoreSuppliesRequisitionsItemID_AutoNumber = " & CurrentPartsRequisitionsItemID.ToString
            JustExecuteMySelection()

            FieldsToUpdate = " PartsRequisitionID_LongInteger, " &
                            " OrderPartsRequisitionsItemID_LongInteger, " &
                            " ProductPartID_LongInteger, " &
                            " RequisitionQuantity_Double, " &
                            " PartsRequisitionItemStatusID_LongInteger "

            FieldsData = CurrentPartsRequisitionID.ToString & ", " &
                    StoreSuppliesRequisitionsItemsDataGridView.Item("ProductsPartsTableRequested.MasterCodeBookID_LongInteger", i).Value.ToString & ", " &
                    CurrentRequestedProductPartID.ToString() & ", " &
                    StoreSuppliesRequisitionsItemsDataGridView.Item("StoreSupplyRequisitionQuantity_Double", i).Value & ", " &
                    GetStatusIdFor("PartsRequisitionsItemsTable").ToString

            CurrentPartsRequisitionsItemID = InsertNewRecord("PartsRequisitionsItemsTable", FieldsToUpdate, FieldsData)
        Next

        'check this

        StoreSuppliesRequisitionsItemsGroupBox.Visible = False
        FillStoreSuppliesRequisitionsItemsDataGridView()







        Dim RecordFilter = " WHERE PartsRequisitionID_AutoNumber = " & CurrentPartsRequisitionID.ToString
        Dim SetCommand = " SET PartsRequisitionStatus_Integer = 0 "
        UpdateTable("PartsRequisitionsTable", SetCommand, RecordFilter)

        FillPartsRequisitionsDataGridView()

    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditItemToolStripMenuItem.Click
        StoreSuppliesRequisitionsItemsGroupBox.Visible = True
        PartTextBox.Text = NotNull(StoreSuppliesRequisitionsItemsDataGridView.Item("MasterCodeBookTable.SystemDesc_ShortText100Fld", CurrentStoreSuppliesRequisitionsItemsDataGridViewRow).Value)
        RequisitionItemProductDescTextBox.Text = NotNull(StoreSuppliesRequisitionsItemsDataGridView.Item("ProductsPartsOrderedTable.ManufacturerDescription_ShortText250", CurrentStoreSuppliesRequisitionsItemsDataGridViewRow).Value)
        POItemProductPartNoTextBox.Text = NotNull(StoreSuppliesRequisitionsItemsDataGridView.Item("Price_Currency", CurrentStoreSuppliesRequisitionsItemsDataGridViewRow).Value)
        RequisitionItemQuantityTextBox.Text = NotNull(StoreSuppliesRequisitionsItemsDataGridView.Item("StoreSupplyRequisitionQuantity_Double", CurrentStoreSuppliesRequisitionsItemsDataGridViewRow).Value)
        RequisitionItemUnitTextBox.Text = NotNull(StoreSuppliesRequisitionsItemsDataGridView.Item("ProductsPartsOrderedTable.Unit_ShortText3", CurrentStoreSuppliesRequisitionsItemsDataGridViewRow).Value)
        SavedProductPartID = CurrentRequestedProductPartID
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteItemToolStripMenuItem.Click
        If MsgBox("Proceed to delete ?", MsgBoxStyle.YesNo) = vbNo Then
            Exit Sub
        End If
        MySelection = "DELETE FROM PurchaseOrdersItemsTable WHERE PurchaseOrdersItemID_AutoNumber = " & Str(CurrentPartsRequisitionsItemID)
        JustExecuteMySelection()
        FillStoreSuppliesRequisitionsItemsDataGridView()
    End Sub
End Class