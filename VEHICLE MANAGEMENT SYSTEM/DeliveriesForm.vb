Public Class DeliveriesForm
    Private DeliveriesFieldsToSelect = ""
    Private DeliveriesTableLinks = ""
    Private DeliveriesSelectionFilter = ""
    Private DeliveriesSelectionOrder = ""
    Private DeliveriesRecordCount As Integer = -1
    Private CurrentDeliveryID As Integer = -1
    Private CurrentDeliveriesDataGridViewRow As Integer = -1
    Private CurrentDeliveriesStatusSelection = 0
    Private DeliveriesDataGridViewAlreadyFormated = False
    Private DeliveryStatus = -1

    Private DeliveryItemsFieldsToSelect = ""
    Private DeliveryItemsTableLinks = ""
    Private DeliveryItemsSelectionFilter = ""
    Private DeliveryItemsSelectionOrder = ""
    Private DeliveryItemsRecordCount As Integer = -1
    Private CurrentDeliveryItemID As Integer = -1
    Private CurrentDeliveryItemsDataGridViewRow As Integer = -1
    Private DeliveryItemsDataGridViewAlreadyFormated = False

    Private SavedProductPartID = -1
    Private CurrentProductPartID = -1
    Private PurposeOfEntry = ""
    Private CurrentDeliveryStatus
    Private SavedCallingForm As Form
    Private StatusCodeUpdate = 1
    Private CurrentWorkOrderConcernID = ""

    Private Sub ReceiveItemsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        SavedCallingForm = CallingForm
        DeliveriesSelectionFilter = " WHERE DeliveriesStatus_Byte = 0 "
        Me.Top = VehicleManagementSystemForm.VehicleManagementMenuStrip.Top + VehicleManagementSystemForm.VehicleManagementMenuStrip.Height + 20
        DeliveriesGroupBox.Left = 1
        DeliveriesGroupBox.Top = DeliveriesMenuStrip.Top + DeliveriesMenuStrip.Height + 5
        DeliveryDetailsGroupBox.Top = DeliveriesGroupBox.Top
        FillDeliveriesDataGridView()
        If CallingForm.Name = "WorkOrderFormASM" Then
            CurrentWorkOrderConcernID = Tunnel1
            EditDeliveryHeader()
            DeliveryNoteNoTextBox.Text = "Customer Supplied"
        End If
        Me.Left = (VehicleManagementSystemForm.Width - Me.Width) / 2
        DeliveryDetailsGroupBox.Left = DeliveriesGroupBox.Left + DeliveriesGroupBox.Width
    End Sub
    Private Sub ReturnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnToolStripMenuItem.Click
        DoCommonHouseKeeping(Me, SavedCallingForm)

    End Sub
    Private Sub ReceiveItemsForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        If Me.Enabled = False Then
            Exit Sub
        End If
        CallingForm = SavedCallingForm

        Select Case Tunnel1
            Case "Tunnel2IsProductPartID"
                CurrentProductPartID = Tunnel2
        End Select

        ' GET RETURNED DATA HERE
        '      Select Case Tunnel1
        FillDeliveryItemsDataGridView()
    End Sub
    Private Sub FillDeliveriesDataGridView()

        Dim xxDraft = " IIf(DeliveriesTable.DeliveriesStatus_Byte = 0, " & Chr(34) & "Draft" & Chr(34) & ","
        Dim xxClosed = " IIf(DeliveriesTable.DeliveriesStatus_Byte = 1, " & Chr(34) & "Closed" & Chr(34) & ","

        DeliveryStatus = xxDraft & xxClosed & Chr(34) & Chr(34) &
                                " )) AS DeliveryStatus "

        DeliveriesFieldsToSelect =
"
SELECT DeliveriesTable.DeliverieID_AutoNumber,
DeliveriesTable.DeliveryDate_ShortDate,
DeliveriesTable.DeliveryNote_ShortText12,
DeliveriesTable.ReceivedBy_LongInteger,
" & DeliveryStatus & "
FROM DeliveriesTable
"
        DeliveriesTableLinks =
            " 
"
        DeliveriesSelectionOrder = " ORDER BY DeliverieID_AutoNumber DESC"

        MySelection = DeliveriesFieldsToSelect & DeliveriesTableLinks & DeliveriesSelectionFilter & DeliveriesSelectionOrder '

        JustExecuteMySelection()
        DeliveriesRecordCount = RecordCount
        If DeliveriesRecordCount = 0 Then
            DeliveryDetailsGroupBox.Visible = False
            DeliveryItemsGroupBox.Visible = False
        Else
            DeliveryDetailsGroupBox.Visible = True
            DeliveryItemsGroupBox.Visible = True
        End If
        DeliveriesDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        If Not DeliveriesDataGridViewAlreadyFormated Then
            FormatDeliveriesDataGridView()
        End If

        SetGroupBoxHeight(1, 10, DeliveriesRecordCount, DeliveriesGroupBox, DeliveriesDataGridView)

        DeliveryItemsGroupBox.Top = DeliveriesGroupBox.Top + DeliveriesGroupBox.Height + 5
    End Sub
    Private Sub FormatDeliveriesDataGridView()
        DeliveriesDataGridViewAlreadyFormated = True
        DeliveriesGroupBox.Width = 0
        For i = 0 To DeliveriesDataGridView.Columns.GetColumnCount(0) - 1

            DeliveriesDataGridView.Columns.Item(i).Visible = False

            Select Case DeliveriesDataGridView.Columns.Item(i).Name
                Case "DeliverieID_AutoNumber"
                    DeliveriesDataGridView.Columns.Item(i).HeaderText = "Delivery Ref. Number"
                    DeliveriesDataGridView.Columns.Item(i).Width = 140
                    DeliveriesDataGridView.Columns.Item(i).Visible = True
                Case "DeliveryDate_ShortDate"
                    DeliveriesDataGridView.Columns.Item(i).HeaderText = "Delivery Date"
                    DeliveriesDataGridView.Columns.Item(i).Width = 90
                    DeliveriesDataGridView.Columns.Item(i).Visible = True
                Case "ReceivedBy_LongInteger"
                    DeliveriesDataGridView.Columns.Item(i).HeaderText = "Received by"
                    DeliveriesDataGridView.Columns.Item(i).Width = 150
                    DeliveriesDataGridView.Columns.Item(i).Visible = True
                Case "DeliveryNote_ShortText12"
                    DeliveriesDataGridView.Columns.Item(i).HeaderText = "Delivery Note"
                    DeliveriesDataGridView.Columns.Item(i).Width = 150
                    DeliveriesDataGridView.Columns.Item(i).Visible = True
                Case "DeliveryStatus"
                    DeliveriesDataGridView.Columns.Item(i).HeaderText = "Status"
                    DeliveriesDataGridView.Columns.Item(i).Width = 150
                    DeliveriesDataGridView.Columns.Item(i).Visible = True
            End Select

            If DeliveriesDataGridView.Columns.Item(i).Visible = True Then
                DeliveriesGroupBox.Width = DeliveriesGroupBox.Width + DeliveriesDataGridView.Columns.Item(i).Width
            End If
        Next

        ' NOTE" SYSTEM AUTOFITS THE GRIDVIEW FIELDS ACCORDING TO THEIR WITDH
        Me.Width = DeliveriesGroupBox.Width + DeliveryDetailsGroupBox.Width + 2

    End Sub

    Private Sub DeliveriesDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DeliveriesDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If DeliveriesRecordCount = 0 Then Exit Sub

        CurrentDeliveriesDataGridViewRow = e.RowIndex
        CurrentDeliveryID = DeliveriesDataGridView.Item("DeliverieID_AutoNumber", CurrentDeliveriesDataGridViewRow).Value
        DeliveryNoTextBox.Text = NotNull(DeliveriesDataGridView.Item("DeliverieID_AutoNumber", CurrentDeliveriesDataGridViewRow).Value)
        DeliveryrDate.Text = NotNull(DeliveriesDataGridView.Item("DeliveryDate_ShortDate", CurrentDeliveriesDataGridViewRow).Value)
        DeliveryNoteNoTextBox.Text = NotNull(DeliveriesDataGridView.Item("DeliveryNote_ShortText12", CurrentDeliveriesDataGridViewRow).Value)
        CurrentDeliveryStatus = NotNull(DeliveriesDataGridView.Item("DeliveryStatus", CurrentDeliveriesDataGridViewRow).Value)
        If CurrentDeliveryStatus = "Draft" Then
            EnableDeliveryItemMenus()
            DeliveryDetailsGroupBox.Enabled = True
            FinalizeDeliveryEntryToolStripMenuItem.Visible = True
        Else
            DisableDeliveryItemMenus()
            DeliveryDetailsGroupBox.Enabled = False
            FinalizeDeliveryEntryToolStripMenuItem.Visible = False
        End If
        DeliveryItemsSelectionFilter = " WHERE DeliverieID_LongInteger = " & CurrentDeliveryID.ToString
        FillDeliveryItemsDataGridView()

    End Sub
    Private Sub FillDeliveryItemsDataGridView()

        DeliveryItemsFieldsToSelect = "
SELECT 
MasterCodeBookTableOrdered.SystemDesc_ShortText100Fld,
ProductsPartsTableDelivered.ManufacturerPartNo_ShortText30Fld,
ProductsPartsTableDelivered.ManufacturerDescription_ShortText250,
DeliveryItemsTable.DeliveredQty_Integer, 
ProductsPartsTableDelivered.Unit_ShortText3, 
BrandsTableDelivered.BrandName_ShortText20, 
PurchaseOrdersTable.PurchaseOrderID_AutoNumber, PurchaseOrdersTable.PurchaseOrderRevision_Integer, 
ProductsPartsTableOrdered.ManufacturerPartNo_ShortText30Fld, ProductsPartsTableOrdered.ManufacturerDescription_ShortText250, PurchaseOrdersItemsTable.POQty_Integer, ProductsPartsTableOrdered.Unit_ShortText3, BrandsTableOrdered.BrandName_ShortText20, 
MasterCodeBookTableOrdered.MasterCodeBookID_Autonumber,
DeliveryItemsTable.ProductPartID_LongInteger,
DeliveryItemsTable.DeliveryItemID_AutoNumber 
FROM ((((((DeliveryItemsTable LEFT JOIN PurchaseOrdersItemsTable ON DeliveryItemsTable.PurchaseOrderItemID_LongInteger = PurchaseOrdersItemsTable.PurchaseOrdersItemID_AutoNumber) LEFT JOIN PurchaseOrdersTable ON PurchaseOrdersItemsTable.PurchaseOrderID_LongInteger = PurchaseOrdersTable.PurchaseOrderID_AutoNumber) LEFT JOIN ProductsPartsTable AS ProductsPartsTableDelivered ON DeliveryItemsTable.ProductPartID_LongInteger = ProductsPartsTableDelivered.ProductsPartID_Autonumber) LEFT JOIN ProductsPartsTable AS ProductsPartsTableOrdered ON PurchaseOrdersItemsTable.ProductPartID_LongInteger = ProductsPartsTableOrdered.ProductsPartID_Autonumber) LEFT JOIN BrandsTable AS BrandsTableDelivered ON ProductsPartsTableDelivered.BrandID_LongInteger = BrandsTableDelivered.BrandID_Autonumber) LEFT JOIN BrandsTable AS BrandsTableOrdered ON ProductsPartsTableOrdered.BrandID_LongInteger = BrandsTableOrdered.BrandID_Autonumber) LEFT JOIN MasterCodeBookTable AS MasterCodeBookTableOrdered ON ProductsPartsTableOrdered.MasterCodeBookID_LongInteger = MasterCodeBookTableOrdered.MasterCodeBookID_Autonumber"
        DeliveryItemsTableLinks = " 
"
        DeliveryItemsSelectionOrder = " ORDER BY DeliveryItemID_AutoNumber DESC"

        MySelection = DeliveryItemsFieldsToSelect & DeliveryItemsTableLinks & DeliveryItemsSelectionFilter & DeliveryItemsSelectionOrder '

        JustExecuteMySelection()
        DeliveryItemsRecordCount = RecordCount
        DeliveryItemsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If Not DeliveryItemsDataGridViewAlreadyFormated Then
            FormatDeliveryItemsDataGridView()
        End If

        SetGroupBoxHeight(2, 15, DeliveryItemsRecordCount, DeliveryItemsGroupBox, DeliveryItemsDataGridView)
        Me.Height = DeliveryItemsGroupBox.Top + DeliveryItemsGroupBox.Height + 2

        Dim MaxBottom = 15 - DeliveryItemsRecordCount
        SetGroupBoxHeight(1, MaxBottom, DeliveryItemsRecordCount, DeliveriesGroupBox, DeliveriesDataGridView)

        DeliveryItemsGroupBox.Top = DeliveriesGroupBox.Top + DeliveriesGroupBox.Height + 5
        If DeliveryItemsGroupBox.Top < DeliveryDetailsGroupBox.Top + DeliveryDetailsGroupBox.Height Then
            DeliveryItemsGroupBox.Top = DeliveryDetailsGroupBox.Top + DeliveryDetailsGroupBox.Height + 2
        End If
    End Sub


    Private Sub FormatDeliveryItemsDataGridView()
        DeliveryItemsDataGridViewAlreadyFormated = True
        DeliveryItemsGroupBox.Width = 0
        For i = 0 To DeliveryItemsDataGridView.Columns.GetColumnCount(0) - 1
            DeliveryItemsDataGridView.Columns.Item(i).Visible = False
            Select Case DeliveryItemsDataGridView.Columns.Item(i).Name
                Case "SystemDesc_ShortText100Fld"
                    DeliveryItemsDataGridView.Columns.Item(i).HeaderText = "Part "
                    DeliveryItemsDataGridView.Columns.Item(i).Width = 250
                    DeliveryItemsDataGridView.Columns.Item(i).Visible = True
                Case "ProductsPartsTableDelivered.ManufacturerPartNo_ShortText30Fld"
                    DeliveryItemsDataGridView.Columns.Item(i).HeaderText = "Part # "
                    DeliveryItemsDataGridView.Columns.Item(i).Width = 130
                    DeliveryItemsDataGridView.Columns.Item(i).Visible = True
                Case "ProductsPartsTableDelivered.ManufacturerDescription_ShortText250"
                    DeliveryItemsDataGridView.Columns.Item(i).HeaderText = "Manufac Description Delivered"
                    DeliveryItemsDataGridView.Columns.Item(i).Width = 350
                    DeliveryItemsDataGridView.Columns.Item(i).Visible = True
                Case "DeliveredQty_Integer"
                    DeliveryItemsDataGridView.Columns.Item(i).HeaderText = "Qty"
                    DeliveryItemsDataGridView.Columns.Item(i).Width = 50
                    DeliveryItemsDataGridView.Columns.Item(i).Visible = True
                Case "ProductsPartsTableDelivered.Unit_ShortText3"
                    DeliveryItemsDataGridView.Columns.Item(i).HeaderText = "Unit"
                    DeliveryItemsDataGridView.Columns.Item(i).Width = 50
                    DeliveryItemsDataGridView.Columns.Item(i).Visible = True
                Case "BrandsTableDelivered.BrandName_ShortText20"
                    DeliveryItemsDataGridView.Columns.Item(i).HeaderText = "Req Brand"
                    DeliveryItemsDataGridView.Columns.Item(i).Width = 150
                    DeliveryItemsDataGridView.Columns.Item(i).Visible = True
                Case "PurchaseOrderID_AutoNumber"
                    DeliveryItemsDataGridView.Columns.Item(i).HeaderText = "PO Ref. No."
                    DeliveryItemsDataGridView.Columns.Item(i).Width = 60
                    DeliveryItemsDataGridView.Columns.Item(i).Visible = True
                Case "PurchaseOrderRevision_Integer"
                    DeliveryItemsDataGridView.Columns.Item(i).HeaderText = "PO Rev."
                    DeliveryItemsDataGridView.Columns.Item(i).Width = 50
                    DeliveryItemsDataGridView.Columns.Item(i).Visible = True
                Case "ProductsPartsTableOrdered.ManufacturerPartNo_ShortText30Fld"
                    DeliveryItemsDataGridView.Columns.Item(i).HeaderText = "Part # "
                    DeliveryItemsDataGridView.Columns.Item(i).Width = 130
                    DeliveryItemsDataGridView.Columns.Item(i).Visible = True
                Case "ProductsPartsTableOrdered.ManufacturerDescription_ShortText250"
                    DeliveryItemsDataGridView.Columns.Item(i).HeaderText = "Manufac Description Ordered"
                    DeliveryItemsDataGridView.Columns.Item(i).Width = 350
                    DeliveryItemsDataGridView.Columns.Item(i).Visible = True
                Case "POQty_Integer"
                    DeliveryItemsDataGridView.Columns.Item(i).HeaderText = "Qty"
                    DeliveryItemsDataGridView.Columns.Item(i).Width = 50
                    DeliveryItemsDataGridView.Columns.Item(i).Visible = True
                Case "ProductsPartsTableOrdered.Unit_ShortText3"
                    DeliveryItemsDataGridView.Columns.Item(i).HeaderText = "Unit"
                    DeliveryItemsDataGridView.Columns.Item(i).Width = 50
                    DeliveryItemsDataGridView.Columns.Item(i).Visible = True
                Case "BrandsTableOrdered.BrandName_ShortText20"
                    DeliveryItemsDataGridView.Columns.Item(i).HeaderText = "Brand"
                    DeliveryItemsDataGridView.Columns.Item(i).Width = 150
                    DeliveryItemsDataGridView.Columns.Item(i).Visible = True
                Case "PurchaseOrderID_AutoNumber"
            End Select
            If DeliveryItemsDataGridView.Columns.Item(i).Visible = True Then
                DeliveryItemsGroupBox.Width = DeliveryItemsGroupBox.Width + DeliveryItemsDataGridView.Columns.Item(i).Width
            End If
        Next
        ' NOTE" SYSTEM AUTOFITS THE GRIDVIEW FIELDS ACCORDING TO THEIR WITDH
        If DeliveryItemsGroupBox.Width > VehicleManagementSystemForm.Width Then
            Me.Width = VehicleManagementSystemForm.Width - 2
            DeliveryItemsGroupBox.Width = Me.Width - 2
        Else
            Me.Width = DeliveryItemsGroupBox.Width + 2
        End If
        Me.Left = (VehicleManagementSystemForm.Width - Me.Width) / 2
        DeliveryItemsGroupBox.Left = 1 + (Me.Width - DeliveryItemsGroupBox.Width) / 2

    End Sub
    Private Sub DeliveryItemsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DeliveryItemsDataGridView.RowEnter
        If ShowInTaskbarFlag Then
            Exit Sub
        End If
        If e.RowIndex < 0 Then Exit Sub
        If DeliveryItemsRecordCount = 0 Then Exit Sub
        CurrentDeliveryItemsDataGridViewRow = e.RowIndex
        CurrentDeliveryItemID = DeliveryItemsDataGridView.Item("DeliveryItemID_AutoNumber", CurrentDeliveryItemsDataGridViewRow).Value
        CurrentProductPartID = DeliveryItemsDataGridView.Item("ProductPartID_LongInteger", CurrentDeliveryItemsDataGridViewRow).Value
    End Sub
    Private Sub EnableDeliveryItemMenus()
        DeliveryItemsToolStripMenus.Visible = True
        AddDeliveryItemsToolStripMenuItem.Visible = True
        EditDeliveryItemToolStripMenuItem.Visible = True
        RemoveDeliveryItemToolStripMenuItem.Visible = True
        AddDeliveryToolStripMenuItem.Visible = False
        SaveDeliveryToolStripMenuItem.Visible = True
        DeleteDeliveryToolStripMenuItem.Visible = False
    End Sub
    Private Sub DisableDeliveryItemMenus()
        DeliveryItemsToolStripMenus.Visible = False
        AddDeliveryItemsToolStripMenuItem.Visible = False
        EditDeliveryItemToolStripMenuItem.Visible = False
        RemoveDeliveryItemToolStripMenuItem.Visible = False
        AddDeliveryToolStripMenuItem.Visible = True
        SaveDeliveryToolStripMenuItem.Visible = False
        DeleteDeliveryToolStripMenuItem.Visible = False
    End Sub

    Private Sub AddDeliveryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddDeliveryToolStripMenuItem.Click
        EditDeliveryHeader()
    End Sub

    Private Sub DeleteDeliveryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteDeliveryToolStripMenuItem.Click
        If DeliveryItemsRecordCount > 0 Then
            MsgBox("Remove allattached items before you can delete this delivery header")
            Exit Sub
        End If
        MySelection = " DELETE FROM DeliveriesTable WHERE DeliverieID_AutoNumber =  " & CurrentDeliveryID
        JustExecuteMySelection()
        FillDeliveriesDataGridView()
    End Sub

    Private Sub EditDeliveryHeader()
        DeliveryrDate.Text = DateString
        DeliveryNoTextBox.Text = ""
        DeliveryNoteNoTextBox.Text = ""
        DeliveriesGroupBox.Enabled = False
        DeliveryItemsGroupBox.Enabled = False
        CurrentDeliveryID = -1
        DeliveryDetailsGroupBox.Visible = True
    End Sub

    Private Sub CloseDeliveryEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FinalizeDeliveryEntryToolStripMenuItem.Click
        Dim xxEmptyField = ""
        For i = 0 To DeliveryItemsRecordCount - 1
            If IsEmpty(DeliveryItemsDataGridView.Item("DeliveredQty_Integer", CurrentDeliveryItemsDataGridViewRow).Value) Then
                xxEmptyField = "Quantity"
                MsgBox(xxEmptyField & " of item " & i + 1.ToString & " should not be empty")
                Exit Sub
            End If
        Next
        If IsEmpty(DeliveryNoteNoTextBox.Text) Then
            If MsgBox("Do you want to enter a delivery note?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                DeliveryNoteNoTextBox.Select()
                Exit Sub
            End If
        End If

        If MsgBox("Continue Finalize deliveries?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        StatusCodeUpdate = 1 ' Delivered
        UpdateDeliveryHeader()

        ' UPDATE DELIVERY ITEMS,        ' UPDATE stocks quantity
        For i = 0 To DeliveryItemsRecordCount - 1
            CurrentDeliveryItemID = DeliveryItemsDataGridView.Item("DeliveryItemID_AutoNumber", CurrentDeliveryItemsDataGridViewRow).Value

            MySelection = " UPDATE DeliveryItemsTable  " &
                              " SET DeliverieID_LongInteger = " & CurrentDeliveryID.ToString &
                              " WHERE DeliveryItemID_AutoNumber = " & CurrentDeliveryItemID.ToString
            JustExecuteMySelection()

            Dim CurrentProductID = DeliveryItemsDataGridView.Item("ProductPartID_LongInteger", CurrentDeliveryItemsDataGridViewRow).Value
            Dim xxDeliveredQuantity = DeliveryItemsDataGridView.Item("DeliveredQty_Integer", CurrentDeliveryItemsDataGridViewRow).Value

            MySelection = " UPDATE StocksTable  " &
                              " SET QuantityInStock_Double = QuantityInStock_Double + " & xxDeliveredQuantity &
                              " WHERE ProductPartID_LongInteger = " & CurrentProductID
            JustExecuteMySelection()

        Next

        DeliveriesSelectionFilter = ""
        FillDeliveriesDataGridView()
    End Sub


    Private Sub EditDeliveryItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditDeliveryItemToolStripMenuItem.Click

        If CurrentDeliveryItemsDataGridViewRow = -1 Then Exit Sub
        DeliveryItemDetailsGroupBox.Visible = True
        DeliveryItemsGroupBox.Top = DeliveryItemDetailsGroupBox.Top + DeliveryItemDetailsGroupBox.Height
        POItemProductDescTextBox.Text = NotNull(DeliveryItemsDataGridView.Item("ProductsPartsTableDelivered.ManufacturerDescription_ShortText250", CurrentDeliveryItemsDataGridViewRow).Value)
        POItemProductPartNoTextBox.Text = NotNull(DeliveryItemsDataGridView.Item("ProductsPartsTableDelivered.ManufacturerPartNo_ShortText30Fld", CurrentDeliveryItemsDataGridViewRow).Value)
        POItemQuantityTextBox.Text = NotNull(DeliveryItemsDataGridView.Item("DeliveredQty_Integer", CurrentDeliveryItemsDataGridViewRow).Value)
        POItemUnitTextBox.Text = NotNull(DeliveryItemsDataGridView.Item("ProductsPartsTableDelivered.Unit_ShortText3", CurrentDeliveryItemsDataGridViewRow).Value)
        BrandTextBox.Text = NotNull(DeliveryItemsDataGridView.Item("BrandsTableDelivered.BrandName_ShortText20", CurrentDeliveryItemsDataGridViewRow).Value)
        SavedProductPartID = CurrentProductPartID

    End Sub

    Private Sub DeleteDeliveryItem_Click(sender As Object, e As EventArgs) Handles RemoveDeliveryItemToolStripMenuItem.Click

    End Sub

    Private Sub FromCustomerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FromCustomerToolStripMenuItem.Click
        '       Tunnel1 = CurrentWorkOrderConcernID
        ShowCalledForm(Me, RequestPartsForm)
    End Sub

    Private Sub FromPurchaseOrdersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FromPurchaseOrdersToolStripMenuItem.Click
        Tunnel1 = "Delivery Update"
        ShowCalledForm(Me, PurchaseOrdersForm)
    End Sub

    Private Sub POItemProductDescTextBox_Click(sender As Object, e As EventArgs) Handles POItemProductDescTextBox.Click
        If POItemProductDescTextBox.Text <> "" Then
            If MsgBox("Do you intend to replace the Product?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        ProductsPartsForm.PartNoToolStripTextBox.Text = ""
        Tunnel1 = DeliveryItemsDataGridView.Item("MasterCodeBookID_Autonumber", CurrentDeliveryItemsDataGridViewRow).Value
        Tunnel2 = DeliveryItemsDataGridView.Item("ProductsPartsTableOrdered.ManufacturerDescription_ShortText250", CurrentDeliveryItemsDataGridViewRow).Value
        ShowCalledForm(Me, ProductsPartsForm)

    End Sub
    Private Sub SetDeliveriesSelectionFilter(PassedStatusCode As Integer, PassedForm As Form, FormHeaderText As String)
        CurrentDeliveriesStatusSelection = PassedStatusCode
        DeliveriesSelectionFilter = SetupTableSelectionFilter(CurrentDeliveriesStatusSelection, PassedForm, FormHeaderText, "")
        FillDeliveriesDataGridView()
    End Sub

    Private Sub EXITSAVEChangesButton_Click(sender As Object, e As EventArgs) Handles EXITSAVEChangesButton.Click
        SaveChanges()
    End Sub
    Private Sub SaveChanges()
        If PurposeOfEntry = "ADD" Then
            Dim FieldsToUpdate = "
                            "
            Dim FieldsData =
                            CurrentVehicleID.ToString

            Dim xxxdummyID = InsertNewRecord("Table", FieldsToUpdate, FieldsData)
        Else
            If AChangeOccured() Then
                Dim xxmsgResult = MsgBox("Save Changes ?", MsgBoxStyle.YesNoCancel)
                If xxmsgResult = vbNo Then
                    DeliveryItemDetailsGroupBox.Visible = False
                    Exit Sub
                ElseIf xxmsgResult = MsgBoxResult.Cancel Then
                    Exit Sub
                End If
            Else
                DeliveryItemDetailsGroupBox.Visible = False 'NO CHANGES
                Exit Sub
            End If
            If MsgBox("About to replace original information, Continue ?", MsgBoxStyle.YesNo) = vbNo Then
                Exit Sub
            End If
            Dim RecordFilter = " WHERE DeliveryItemID_AutoNumber = " & CurrentDeliveryItemID.ToString
            Dim SetCommand = " SET ProductPartID_LongInteger = " & CurrentProductPartID.ToString & "," &
                             " DeliveredQty_Integer = " & Val(POItemQuantityTextBox.Text).ToString
            UpdateTable("DeliveryItemsTable", SetCommand, RecordFilter)
        End If

        DeliveryItemDetailsGroupBox.Visible = False
        FillDeliveryItemsDataGridView()
    End Sub
    Private Function AChangeOccured()
        If CurrentDeliveryItemsDataGridViewRow = -1 Then
            If POItemProductDescTextBox.Text <> "" Then
                Return True
            Else
                Return False
            End If
        Else



            '*******************************************************
            ' CHECK THIS THE TheseAreNotEqual ROUTINE WAS MODIFIED, WATCH PARAMETER pURPOSEOFENTRY





            If TheseAreNotEqual(POItemProductDescTextBox.Text, NotNull(DeliveryItemsDataGridView.Item("ManufacturerDescription_ShortText250", CurrentDeliveryItemsDataGridViewRow).Value), PurposeOfEntry) Then Return True
            If TheseAreNotEqual(POItemQuantityTextBox.Text, NotNull(DeliveryItemsDataGridView.Item("DeliveredQty_Integer", CurrentDeliveryItemsDataGridViewRow).Value), PurposeOfEntry) Then Return True
            Return False
        End If
    End Function

    Private Sub SaveDeliveryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveDeliveryToolStripMenuItem.Click
        If MsgBox("Proceed Saving this Delivery Header ? ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        StatusCodeUpdate = 0
        UpdateDeliveryHeader()
        FillDeliveriesDataGridView()
    End Sub
    Private Sub UpdateDeliveryHeader()
        Dim xxDeliveryNote = ""
        If Not IsEmpty(DeliveryNoteNoTextBox.Text) Then
            xxDeliveryNote = " DeliveryNote_ShortText12 = " & Chr(34) & Trim(DeliveryNoteNoTextBox.Text) & Chr(34) & ", "
        End If
        If CurrentDeliveryID = -1 Then
            Dim FieldsToUpdate = " DeliveryDate_ShortDate, 
                                ReceivedBy_LongInteger, 
                                DeliveryNote_ShortText12
"
            Dim FieldsData = " Chr(34) & Trim(DeliveryrDate.Text) & Chr(34) " & ", " &
                                xxDeliveryNote
            CurrentUserID.ToString()

            Dim CurrentDeliveryID = InsertNewRecord("DeliveriesTable", FieldsToUpdate, FieldsData)
        Else

            MySelection = " UPDATE DeliveriesTable  " &
                              " SET DeliveryDate_ShortDate = " & Chr(34) & Trim(DeliveryrDate.Text) & Chr(34) & ", " &
                               xxDeliveryNote &
                                 " DeliveriesStatus_Byte = " & StatusCodeUpdate.ToString &
                              " WHERE DeliverieID_AutoNumber = " & CurrentDeliveryID.ToString
            JustExecuteMySelection()

        End If
    End Sub

    Private Sub DraftPurchaseOrdersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DraftPurchaseOrdersToolStripMenuItem.Click
        DeliveriesSelectionFilter = " WHERE DeliveriesStatus_Byte = 0 "
        FillDeliveriesDataGridView()
    End Sub

    Private Sub AllPurchaseOrdersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllPurchaseOrdersToolStripMenuItem.Click
        DeliveriesSelectionFilter = ""
        FillDeliveriesDataGridView()
    End Sub

End Class