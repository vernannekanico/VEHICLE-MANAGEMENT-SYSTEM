Public Class DeliveriesForm
    Private DeliveriesFieldsToSelect = ""
    Private DeliveriesSelectionFilter = ""
    Private DeliveriesSelectionOrder = ""
    Private DeliveriesRecordCount As Integer = -1
    Private CurrentDeliveryID As Integer = -1
    Private CurrentDeliveriesDataGridViewRow As Integer = -1
    Private DeliveriesDataGridViewAlreadyFormated = False
    Private DeliveryStatus = -1

    Private DeliveryItemsFieldsToSelect = ""
    Private DeliveryItemsSelectionFilter = ""
    Private DeliveryItemsSelectionOrder = ""
    Private DeliveryItemsRecordCount As Integer = -1
    Private CurrentDeliveryItemID As Integer = -1
    Private CurrentDeliveryItemsDataGridViewRow As Integer = -1
    Private DeliveryItemsDataGridViewAlreadyFormated = False

    Private CurrentStocksLocationCode = ""
    Private SavedProductPartID = -1
    Private CurrentProductPartID = -1
    Private PurposeOfEntry = ""
    Private CurrentDeliveryStatus
    Private SavedCallingForm As Form
    Private StatusCodeUpdate = 1
    Private CurrentWorkOrderConcernID = ""

    Private Sub ReceiveItemsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        SavedCallingForm = CallingForm

        Me.Top = VehicleManagementSystemForm.VehicleManagementMenuStrip.Top + VehicleManagementSystemForm.VehicleManagementMenuStrip.Height + 20
        DeliveriesGroupBox.Left = 1
        DeliveriesGroupBox.Top = DeliveriesMenuStrip.Top + DeliveriesMenuStrip.Height + 5
        DeliveryHeaderDetailsGroupBox.Top = DeliveriesGroupBox.Top
        'Initiate formatting of Deliveries view
        DeliveryItemsSelectionFilter = " Where DeliveryItemID_AutoNumber = -1"
        FillDeliveryItemsDataGridView()
        DeliveriesSelectionFilter = SetupTableSelectionFilter(GetStatusIdFor("DeliveriesTable", "Draft Deliveries", 1), 1, Me, "Draft Deliveries")
        FillDeliveriesDataGridView()
        If CallingForm.Name = "WorkOrderFormASM" Then
            CurrentWorkOrderConcernID = Tunnel1
            EditDeliveryHeader()
            DeliveryNoteNoTextBox.Text = "Customer Supplied"
        End If

        ' NOTE" SYSTEM AUTOFITS THE GRIDVIEW FIELDS ACCORDING TO THEIR WITDH

        DeliveryHeaderDetailsGroupBox.Left = DeliveriesGroupBox.Left + DeliveriesGroupBox.Width
        Me.Left = (VehicleManagementSystemForm.Width - Me.Width) / 2
        DeliveryItemsGroupBox.Left = ((Me.Width - DeliveryItemsGroupBox.Width) / 2) + 1
        DeliveryItemDetailsGroupBox.Left = DeliveriesGroupBox.Left
        DeliveryItemDetailsGroupBox.Top = DeliveriesGroupBox.Top + 50
        Me.Width = DeliveryItemsGroupBox.Width + DeliveryHeaderDetailsGroupBox.Width + 2

    End Sub
    Private Sub ReturnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnToolStripMenuItem.Click
        If DeliveryItemDetailsGroupBox.Visible Then
            DeliveryItemDetailsGroupBox.Visible = False
            Exit Sub
        End If
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
            Case "CurrentStocksLocationCode"
                CurrentStocksLocationCode = Tunnel3
                MsgBox("Please put this delivery on location " & CurrentStocksLocationCode)
        End Select

        ' GET RETURNED DATA HERE
        '      Select Case Tunnel1
        FillDeliveryItemsDataGridView()
    End Sub
    Private Sub FillDeliveriesDataGridView()


        DeliveriesFieldsToSelect =
"
SELECT DeliveriesTable.DeliveryID_AutoNumber, 
DeliveriesTable.DeliveryDate_ShortDate, 
DeliveriesTable.DeliveryNote_ShortText12, 
DeliveriesTable.ReceivedBy_LongInteger, 
DeliveriesTable.DeliveryStatusID_LongInteger, 
StatusesTable.StatusSequence_LongInteger, 
StatusesTable.StatusText_ShortText25
FROM DeliveriesTable LEFT JOIN StatusesTable ON DeliveriesTable.DeliveryStatusID_LongInteger = StatusesTable.StatusID_Autonumber
"
        DeliveriesSelectionOrder = " ORDER BY DeliveryID_AutoNumber DESC"

        MySelection = DeliveriesFieldsToSelect & DeliveriesSelectionFilter & DeliveriesSelectionOrder '

        JustExecuteMySelection()
        DeliveriesRecordCount = RecordCount
        CurrentDeliveryID = -1
        DisableDeliveryItemMenus()
        DeliveriesDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        DeliveryHeaderDetailsGroupBox.Visible = False
        If DeliveryItemsRecordCount > 0 Then
            OrderItemDetailsToolStripMenuItem.Visible = True
        Else
            OrderItemDetailsToolStripMenuItem.Visible = False
        End If

        If Not DeliveriesDataGridViewAlreadyFormated Then
            FormatDeliveriesDataGridView()
        End If

        SetGroupBoxHeight(10, DeliveriesRecordCount, DeliveriesGroupBox, DeliveriesDataGridView)



    End Sub
    Private Sub FormatDeliveriesDataGridView()
        DeliveriesDataGridViewAlreadyFormated = True
        DeliveriesGroupBox.Width = 0
        For i = 0 To DeliveriesDataGridView.Columns.GetColumnCount(0) - 1

            DeliveriesDataGridView.Columns.Item(i).Visible = False

            Select Case DeliveriesDataGridView.Columns.Item(i).Name
                Case "DeliveryID_AutoNumber"
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
                Case "StatusText_ShortText25"
                    DeliveriesDataGridView.Columns.Item(i).HeaderText = "Status"
                    DeliveriesDataGridView.Columns.Item(i).Width = 150
                    DeliveriesDataGridView.Columns.Item(i).Visible = True
            End Select

            If DeliveriesDataGridView.Columns.Item(i).Visible = True Then
                DeliveriesGroupBox.Width = DeliveriesGroupBox.Width + DeliveriesDataGridView.Columns.Item(i).Width
            End If
        Next


    End Sub

    Private Sub DeliveriesDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DeliveriesDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If DeliveriesRecordCount = 0 Then Exit Sub

        CurrentDeliveriesDataGridViewRow = e.RowIndex
        CurrentDeliveryID = DeliveriesDataGridView.Item("DeliveryID_AutoNumber", CurrentDeliveriesDataGridViewRow).Value
        DeliveryNoTextBox.Text = NotNull(DeliveriesDataGridView.Item("DeliveryID_AutoNumber", CurrentDeliveriesDataGridViewRow).Value)
        DeliveryrDate.Text = NotNull(DeliveriesDataGridView.Item("DeliveryDate_ShortDate", CurrentDeliveriesDataGridViewRow).Value)
        DeliveryNoteNoTextBox.Text = NotNull(DeliveriesDataGridView.Item("DeliveryNote_ShortText12", CurrentDeliveriesDataGridViewRow).Value)
        CurrentDeliveryStatus = NotNull(DeliveriesDataGridView.Item("StatusText_ShortText25", CurrentDeliveriesDataGridViewRow).Value)
        DisableDeliveryItemMenus()
        DeliveryHeaderDetailsGroupBox.Enabled = False
        FinalizeDeliveryEntryToolStripMenuItem.Visible = False
        Select Case CurrentDeliveryStatus
            Case "Draft Deliveries"
                EnableDeliveryItemMenus()
                DeliveryHeaderDetailsGroupBox.Visible = True
                FinalizeDeliveryEntryToolStripMenuItem.Visible = True
            Case "Processed"
                DisableDeliveryItemMenus()
                DeliveryHeaderDetailsGroupBox.Visible = False
                FinalizeDeliveryEntryToolStripMenuItem.Visible = False
        End Select
        DeliveryItemsSelectionFilter = " WHERE DeliveryID_LongInteger = " & CurrentDeliveryID.ToString
        FillDeliveryItemsDataGridView()

    End Sub
    Private Sub FillDeliveryItemsDataGridView()

        DeliveryItemsFieldsToSelect = "
SELECT 
WorkOrderRequestedPartsTable.WorkOrderPartID_LongInteger,
RequisitionsItemsTable.RequisitionID_LongInteger,
MasterCodeBookTable.MasterCodeBookID_Autonumber, 
MasterCodeBookTable.SystemDesc_ShortText100Fld, 
ProductsPartsTableDelivered.ProductsPartID_Autonumber,
ProductsPartsTableDelivered.ManufacturerPartNo_ShortText30Fld, 
ProductsPartsTableDelivered.ManufacturerDescription_ShortText250, 
BrandsTableDelivered.BrandName_ShortText20, 
DeliveryItemsTable.DeliveryItemID_AutoNumber,
DeliveryItemsTable.DeliveredQty_Double, 
ProductsPartsTableDelivered.Unit_ShortText3, 
PurchaseOrdersItemsTable.PurchaseOrderID_LongInteger, 
PurchaseOrdersItemsTable.POQty_Integer,
ProductsPartsTableOrdered.ProductsPartID_Autonumber, 
ProductsPartsTableOrdered.ManufacturerPartNo_ShortText30Fld, 
ProductsPartsTableOrdered.ManufacturerDescription_ShortText250,
ProductsPartsTableOrdered.Unit_ShortText3, 
BrandsTableOrdered.BrandName_ShortText20
FROM (((((((DeliveryItemsTable LEFT JOIN PurchaseOrdersItemsTable ON DeliveryItemsTable.PurchaseOrderItemID_LongInteger = PurchaseOrdersItemsTable.PurchaseOrdersItemID_AutoNumber) LEFT JOIN ProductsPartsTable AS ProductsPartsTableDelivered ON DeliveryItemsTable.ProductPartID_LongInteger = ProductsPartsTableDelivered.ProductsPartID_Autonumber) LEFT JOIN BrandsTable AS BrandsTableDelivered ON ProductsPartsTableDelivered.BrandID_LongInteger = BrandsTableDelivered.BrandID_Autonumber) LEFT JOIN ProductsPartsTable AS ProductsPartsTableOrdered ON PurchaseOrdersItemsTable.ProductPartID_LongInteger = ProductsPartsTableOrdered.ProductsPartID_Autonumber) LEFT JOIN BrandsTable AS BrandsTableOrdered ON ProductsPartsTableOrdered.BrandID_LongInteger = BrandsTableOrdered.BrandID_Autonumber) LEFT JOIN MasterCodeBookTable ON ProductsPartsTableOrdered.MasterCodeBookID_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) LEFT JOIN RequisitionsItemsTable ON PurchaseOrdersItemsTable.RequisitionsItemID_LongInteger = RequisitionsItemsTable.RequisitionsItemID_AutoNumber) LEFT JOIN WorkOrderRequestedPartsTable ON RequisitionsItemsTable.WorkOrderRequestedPartID_LongInteger = WorkOrderRequestedPartsTable.WorkOrderRequestedPartID_AutoNumber"
        DeliveryItemsSelectionOrder = " ORDER BY WorkOrderPartID_LongInteger, RequisitionID_LongInteger, DeliveryItemID_AutoNumber DESC"
        MySelection = DeliveryItemsFieldsToSelect & DeliveryItemsSelectionFilter & DeliveryItemsSelectionOrder '

        JustExecuteMySelection()
        DeliveryItemsRecordCount = RecordCount
        If DeliveryItemsRecordCount > 0 Then
            DeliveryItemsGroupBox.Visible = True
            FinalizeDeliveryEntryToolStripMenuItem.Visible = True
            PODetailsToolStripMenuItem.Visible = True
            RequisitionDetailsToolStripMenuItem.Visible = True
        Else
            DeliveryItemsGroupBox.Visible = False
            FinalizeDeliveryEntryToolStripMenuItem.Visible = False
            PODetailsToolStripMenuItem.Visible = False
            RequisitionDetailsToolStripMenuItem.Visible = False
        End If
        DeliveryItemsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If Not DeliveryItemsDataGridViewAlreadyFormated Then
            FormatDeliveryItemsDataGridView()
        End If

        SetGroupBoxHeight(15, DeliveryItemsRecordCount, DeliveryItemsGroupBox, DeliveryItemsDataGridView)

        DeliveryItemsGroupBox.Top = DeliveryHeaderDetailsGroupBox.Top + DeliveryHeaderDetailsGroupBox.Height + 5
    End Sub


    Private Sub FormatDeliveryItemsDataGridView()
        DeliveryItemsDataGridViewAlreadyFormated = True
        DeliveryItemsGroupBox.Width = 0
        For i = 0 To DeliveryItemsDataGridView.Columns.GetColumnCount(0) - 1
            DeliveryItemsDataGridView.Columns.Item(i).Visible = False
            Select Case DeliveryItemsDataGridView.Columns.Item(i).Name
                Case "RequisitionID_LongInteger"
                    DeliveryItemsDataGridView.Columns.Item(i).HeaderText = "REQ #"
                    DeliveryItemsDataGridView.Columns.Item(i).Width = 80
                    DeliveryItemsDataGridView.Columns.Item(i).Visible = True
                    DeliveryItemsDataGridView.Columns.Item(i).Visible = True

                Case "WorkOrderPartID_LongInteger"
                    DeliveryItemsDataGridView.Columns.Item(i).HeaderText = "WO #"
                    DeliveryItemsDataGridView.Columns.Item(i).Width = 80
                    DeliveryItemsDataGridView.Columns.Item(i).Visible = True
                    DeliveryItemsDataGridView.Columns.Item(i).Visible = True
                Case "SystemDesc_ShortText100Fld"
                    DeliveryItemsDataGridView.Columns.Item(i).HeaderText = "Part "
                    DeliveryItemsDataGridView.Columns.Item(i).Width = 250
                    DeliveryItemsDataGridView.Columns.Item(i).Visible = True
                    DeliveryItemsDataGridView.Columns.Item(i).Visible = True
                Case "ProductsPartsTableDelivered.ManufacturerPartNo_ShortText30Fld"
                    DeliveryItemsDataGridView.Columns.Item(i).HeaderText = "Part #"
                    DeliveryItemsDataGridView.Columns.Item(i).Width = 130
                    DeliveryItemsDataGridView.Columns.Item(i).Visible = True
                Case "ProductsPartsTableDelivered.ManufacturerDescription_ShortText250"
                    DeliveryItemsDataGridView.Columns.Item(i).HeaderText = "Manufac Description Delivered"
                    DeliveryItemsDataGridView.Columns.Item(i).Width = 350
                    DeliveryItemsDataGridView.Columns.Item(i).Visible = True
                Case "DeliveredQty_Double"
                    DeliveryItemsDataGridView.Columns.Item(i).HeaderText = "Qty"
                    DeliveryItemsDataGridView.Columns.Item(i).Width = 50
                    DeliveryItemsDataGridView.Columns.Item(i).Visible = True
                Case "ProductsPartsTableDelivered.Unit_ShortText3"
                    DeliveryItemsDataGridView.Columns.Item(i).HeaderText = "Unit"
                    DeliveryItemsDataGridView.Columns.Item(i).Width = 50
                    DeliveryItemsDataGridView.Columns.Item(i).Visible = True
                Case "BrandsTableDelivered.BrandName_ShortText20"
                    DeliveryItemsDataGridView.Columns.Item(i).HeaderText = "Brand Delivered"
                    DeliveryItemsDataGridView.Columns.Item(i).Width = 150
                    DeliveryItemsDataGridView.Columns.Item(i).Visible = True
                Case "PurchaseOrderID_LongInteger"
                    DeliveryItemsDataGridView.Columns.Item(i).HeaderText = "PO #"
                    DeliveryItemsDataGridView.Columns.Item(i).Width = 80
                    DeliveryItemsDataGridView.Columns.Item(i).Visible = True
                Case "PurchaseOrderRevision_Integer"
                    DeliveryItemsDataGridView.Columns.Item(i).HeaderText = "PO Rev."
                    DeliveryItemsDataGridView.Columns.Item(i).Width = 50
                    DeliveryItemsDataGridView.Columns.Item(i).Visible = True
            End Select
            If DeliveryItemsDataGridView.Columns.Item(i).Visible = True Then
                DeliveryItemsGroupBox.Width = DeliveryItemsGroupBox.Width + DeliveryItemsDataGridView.Columns.Item(i).Width
            End If
        Next



    End Sub
    Private Sub DeliveryItemsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DeliveryItemsDataGridView.RowEnter
        If ShowInTaskbarFlag Then
            Exit Sub
        End If
        If e.RowIndex < 0 Then Exit Sub
        If DeliveryItemsRecordCount = 0 Then Exit Sub
        CurrentDeliveryItemsDataGridViewRow = e.RowIndex
        FillField(CurrentDeliveryItemID, DeliveryItemsDataGridView.Item("DeliveryItemID_AutoNumber", CurrentDeliveryItemsDataGridViewRow).Value)
        FillField(CurrentProductPartID, DeliveryItemsDataGridView.Item("ProductsPartsTableDelivered.ProductsPartID_Autonumber", CurrentDeliveryItemsDataGridViewRow).Value)
        PODetailsToolStripMenuItem.Text = "PO " & DeliveryItemsDataGridView.Item("PurchaseOrderID_LongInteger", CurrentDeliveryItemsDataGridViewRow).Value & " Details"
        RequisitionDetailsToolStripMenuItem.Text = "REQ " & DeliveryItemsDataGridView.Item("RequisitionID_LongInteger", CurrentDeliveryItemsDataGridViewRow).Value & " Details"
        If CurrentProductPartID = -1 Then
            EditCurrentItem()
        End If

    End Sub
    Private Sub EnableDeliveryItemMenus()
        DeliveryItemsToolStripMenus.Visible = True
        AddDeliveryItemsToolStripMenuItem.Visible = True
        EditDeliveryItemToolStripMenuItem.Visible = True
        RemoveDeliveryItemToolStripMenuItem.Visible = True
        NewDeliveryToolStripMenuItem.Visible = False
        SaveDeliveryHeaderToolStripMenuItem.Visible = True
        DeleteDeliveryToolStripMenuItem.Visible = False
    End Sub
    Private Sub DisableDeliveryItemMenus()
        DeliveryItemsToolStripMenus.Visible = False
        AddDeliveryItemsToolStripMenuItem.Visible = False
        EditDeliveryItemToolStripMenuItem.Visible = False
        RemoveDeliveryItemToolStripMenuItem.Visible = False
        NewDeliveryToolStripMenuItem.Visible = True
        SaveDeliveryHeaderToolStripMenuItem.Visible = False
        DeleteDeliveryToolStripMenuItem.Visible = False
    End Sub

    Private Sub NewDeliveryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewDeliveryToolStripMenuItem.Click
        EditDeliveryHeader()
    End Sub

    Private Sub DeleteDeliveryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteDeliveryToolStripMenuItem.Click
        If DeliveryItemsRecordCount > 0 Then
            MsgBox("Remove allattached items before you can delete this delivery header")
            Exit Sub
        End If
        MySelection = " DELETE FROM DeliveriesTable WHERE DeliveryID_AutoNumber =  " & CurrentDeliveryID
        JustExecuteMySelection()
        FillDeliveriesDataGridView()
    End Sub

    Private Sub EditDeliveryHeader()
        NewDeliveryToolStripMenuItem.Visible = False
        ViewToolStripMenuItem.Visible = False
        DeleteDeliveryToolStripMenuItem.Visible = False
        DeliveryrDate.Text = DateString
        DeliveryNoTextBox.Text = ""
        DeliveryNoteNoTextBox.Text = ""
        DeliveriesGroupBox.Enabled = False
        DeliveryHeaderDetailsGroupBox.Visible = True
        SaveDeliveryHeaderToolStripMenuItem.Visible = True

    End Sub

    Private Sub CloseDeliveryEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FinalizeDeliveryEntryToolStripMenuItem.Click
        Dim xxEmptyField = ""
        ' VALIDATION
        If IsEmpty(DeliveryNoteNoTextBox.Text) Then
            If MsgBox("Do you want to enter a delivery note?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                DeliveryNoteNoTextBox.Select()
                Exit Sub
            End If
        End If
        For i = 0 To DeliveryItemsRecordCount - 1
            If IsEmpty(DeliveryItemsDataGridView.Item("DeliveredQty_Double", i).Value) Then
                xxEmptyField = "Quantity"
                MsgBox(xxEmptyField & " of item " & i + 1.ToString & " should not be empty")
                Exit Sub
            End If
        Next

        If MsgBox("Continue Finalize deliveries?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        StatusCodeUpdate = 1 ' Delivered

        MySelection = " UPDATE DeliveriesTable  " &
                              "SET DeliveryStatusID_LongInteger = " & GetStatusIdFor("DeliveriesTable", "Processed").ToString &
                              " WHERE DeliveryID_AutoNumber = " & CurrentDeliveryID.ToString
        JustExecuteMySelection()
        Dim PurchaseRequestType = ""

        If IsNotEmpty(
            DeliveryItemsDataGridView.Item("WorkOrderPartID_LongInteger", CurrentDeliveryItemsDataGridViewRow).Value
            ) Then
            'GET LOCATION FOR TEMPORARY STORAGE
            PurchaseRequestType = "Work Order Parts"
        End If

        ' UPDATE DELIVERY ITEMS,        ' UPDATE stocks quantity
        For i = 0 To DeliveryItemsRecordCount - 1
            MySelection = " UPDATE DeliveryItemsTable  SET " &
                              " DeliveryID_LongInteger = " & CurrentDeliveryID.ToString &
                              ", DeliveryItemsStatusID_LongInteger = " & GetStatusIdFor("DeliveryItemsTable", "Processed").ToString &
                              " WHERE DeliveryItemID_AutoNumber = " & DeliveryItemsDataGridView.Item("DeliveryItemID_AutoNumber", i).Value.ToString
            JustExecuteMySelection()
            Dim CurrentProductID = DeliveryItemsDataGridView.Item("ProductsPartsTableDelivered.ProductsPartID_Autonumber", i).Value
            Dim xxDeliveredQuantity = DeliveryItemsDataGridView.Item("DeliveredQty_Double", i).Value

            'nOTE only store stocks should be registered in the stockstable

            If Not PurchaseRequestType = "Work Order Parts" Then

                MySelection = " UPDATE StocksTable  " &
                              " SET QuantityInStock_Double = QuantityInStock_Double + " & xxDeliveredQuantity &
                              " WHERE ProductPartID_LongInteger = " & CurrentProductID
                JustExecuteMySelection()
            End If

            'UPDATE ProductsPartTable AND MARK FIELD Selected true
            'THIS IS USED FOR THE TIME BEING
            UpdateTable("ProductsPartsTable", "SET Selected = True", "WHERE ProductsPartID_AutoNumber = " & CurrentProductID)

        Next


        DeliveriesSelectionFilter = ""
        FillDeliveriesDataGridView()
        ShowCalledForm(Me, StockLocationsForm)
        MsgBox("Select where to stock delivered parts")

    End Sub


    Private Sub EditDeliveryItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditDeliveryItemToolStripMenuItem.Click
        EditCurrentItem()
    End Sub
    Private Sub EditCurrentItem()
        If CurrentDeliveryItemsDataGridViewRow = -1 Then Exit Sub
        DeliveryItemDetailsGroupBox.Text = "Delivery Details"
        DeliveryItemDetailsGroupBox.Visible = True
        If IsEmpty(DeliveryItemsDataGridView.Item("ProductsPartsTableDelivered.ManufacturerDescription_ShortText250", CurrentDeliveryItemsDataGridViewRow).Value) Then
            POItemProductDescTextBox.Text = NotNull(DeliveryItemsDataGridView.Item("ProductsPartsTableOrdered.ManufacturerDescription_ShortText250", CurrentDeliveryItemsDataGridViewRow).Value)
            POItemProductPartNoTextBox.Text = NotNull(DeliveryItemsDataGridView.Item("ProductsPartsTableOrdered.ManufacturerPartNo_ShortText30Fld", CurrentDeliveryItemsDataGridViewRow).Value)
            POItemQuantityTextBox.Text = NotNull(DeliveryItemsDataGridView.Item("POQty_Integer", CurrentDeliveryItemsDataGridViewRow).Value)
            POItemUnitTextBox.Text = NotNull(DeliveryItemsDataGridView.Item("ProductsPartsTableOrdered.Unit_ShortText3", CurrentDeliveryItemsDataGridViewRow).Value)
            BrandTextBox.Text = NotNull(DeliveryItemsDataGridView.Item("BrandsTableOrdered.BrandName_ShortText20", CurrentDeliveryItemsDataGridViewRow).Value)
            POItemUnitTextBox.Text = NotNull(DeliveryItemsDataGridView.Item("ProductsPartsTableOrdered.Unit_ShortText3", CurrentDeliveryItemsDataGridViewRow).Value)
            FillField(CurrentProductPartID, DeliveryItemsDataGridView.Item("ProductsPartsTableOrdered.ProductsPartID_Autonumber", CurrentDeliveryItemsDataGridViewRow).Value)
            If MsgBox("Confirm suggested ordered/delivered product", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                POItemQuantityTextBox.Select()
            Else
                POItemProductDescTextBox.Select()
                EditDeliveryItem()
            End If
        Else
            POItemProductDescTextBox.Text = NotNull(DeliveryItemsDataGridView.Item("ProductsPartsTableDelivered.ManufacturerDescription_ShortText250", CurrentDeliveryItemsDataGridViewRow).Value)
            POItemProductPartNoTextBox.Text = NotNull(DeliveryItemsDataGridView.Item("ProductsPartsTableDelivered.ManufacturerPartNo_ShortText30Fld", CurrentDeliveryItemsDataGridViewRow).Value)
            POItemQuantityTextBox.Text = NotNull(DeliveryItemsDataGridView.Item("DeliveredQty_Double", CurrentDeliveryItemsDataGridViewRow).Value)
            POItemUnitTextBox.Text = NotNull(DeliveryItemsDataGridView.Item("ProductsPartsTableDelivered.Unit_ShortText3", CurrentDeliveryItemsDataGridViewRow).Value)
            BrandTextBox.Text = NotNull(DeliveryItemsDataGridView.Item("BrandsTableDelivered.BrandName_ShortText20", CurrentDeliveryItemsDataGridViewRow).Value)
        End If

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
        Tunnel2 = CurrentDeliveryID
        ShowCalledForm(Me, PurchaseOrdersForm)
    End Sub

    Private Sub POItemProductDescTextBox_Click(sender As Object, e As EventArgs) Handles POItemProductDescTextBox.Click
        EditDeliveryItem()
    End Sub

    Private Sub EditDeliveryItem()
        If POItemProductDescTextBox.Text <> "" Then
            If MsgBox("Do you intend to replace the Product?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        ProductsPartsForm.PartNoSearchTextBox.Text = DeliveryItemsDataGridView.Item("ProductsPartsTableOrdered.ManufacturerPartNo_ShortText30Fld", CurrentDeliveryItemsDataGridViewRow).Value
        Tunnel2 = DeliveryItemsDataGridView.Item("MasterCodeBookID_Autonumber", CurrentDeliveryItemsDataGridViewRow).Value
        ProductsPartsForm.PartDescriptionSearchTextBox.Text = DeliveryItemsDataGridView.Item("ProductsPartsTableOrdered.ManufacturerDescription_ShortText250", CurrentDeliveryItemsDataGridViewRow).Value
        ShowCalledForm(Me, ProductsPartsForm)

    End Sub
    Private Sub SetDeliveriesSelectionFilter(PassedStatusSequence As Integer, PassedStatusSequenceCondition As Integer, PassedForm As Form, FormHeaderText As String)
        DeliveriesSelectionFilter = SetupTableSelectionFilter(PassedStatusSequence, PassedStatusSequenceCondition, PassedForm, FormHeaderText, "")
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
                             " DeliveredQty_Double = " & Val(POItemQuantityTextBox.Text).ToString
            UpdateTable("DeliveryItemsTable", SetCommand, RecordFilter)
            'UPDATE ProductsPartTable AND MARK FIELD Selected true
            UpdateTable("ProductsPartsTable", "SET Selected = True", "WHERE ProductsPartID_AutoNumber = " & CurrentProductPartID.ToString)
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





            If TheseAreNotEqual(POItemProductDescTextBox.Text, NotNull(DeliveryItemsDataGridView.Item("ProductsPartsTableDelivered.ManufacturerDescription_ShortText250", CurrentDeliveryItemsDataGridViewRow).Value)) Then Return True
            If TheseAreNotEqual(POItemQuantityTextBox.Text, NotNull(DeliveryItemsDataGridView.Item("DeliveredQty_Double", CurrentDeliveryItemsDataGridViewRow).Value)) Then Return True
            Return False
        End If
    End Function

    Private Sub SaveDeliveryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveDeliveryHeaderToolStripMenuItem.Click
        If MsgBox("Proceed Saving this Delivery Header ? ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        StatusCodeUpdate = 0
        UpdateDeliveryHeader()
        SaveDeliveryHeaderToolStripMenuItem.Visible = False
        FillDeliveriesDataGridView()
    End Sub
    Private Sub UpdateDeliveryHeader()
        If CurrentDeliveryID = -1 Then
            Dim FieldsToUpdate = " DeliveryDate_ShortDate, 
                                ReceivedBy_LongInteger, DeliveryNote_ShortText12, DeliveryStatusID_LongInteger "

            Dim FieldsData = Chr(34) & Trim(DeliveryrDate.Text) & Chr(34) & ", " &
                             CurrentPersonelID.ToString &
                                ", " & Chr(34) & Trim(DeliveryNoteNoTextBox.Text) & Chr(34) & ", " &
                                GetStatusIdFor("DeliveriesTable", "Draft Deliveries").ToString

            CurrentDeliveryID = InsertNewRecord("DeliveriesTable", FieldsToUpdate, FieldsData)
        Else

            MySelection = " UPDATE DeliveriesTable  " &
                              " SET DeliveryDate_ShortDate = " & Chr(34) & Trim(DeliveryrDate.Text) & Chr(34) &
                              " ReceivedBy_LongInteger = " & CurrentPersonelID.ToString &
                              ", DeliveryNote_ShortText12 = " & Chr(34) & Trim(DeliveryNoteNoTextBox.Text) & Chr(34) &
                              ", DeliveryStatusID_LongInteger = " & GetStatusIdFor("DeliveriesTable", "Draft Deliveries").ToString &
                              " WHERE DeliveryID_AutoNumber = " & CurrentDeliveryID.ToString
            JustExecuteMySelection()

        End If
    End Sub

    Private Sub DraftPurchaseOrdersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DraftPurchaseOrdersToolStripMenuItem.Click
        SetDeliveriesSelectionFilter(GetStatusIdFor("DeliveriesTable"), 2, Me, "Draft Deliveries")
        FillDeliveriesDataGridView()
    End Sub

    Private Sub AllPurchaseOrdersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllPurchaseOrdersToolStripMenuItem.Click
        SetDeliveriesSelectionFilter(GetStatusIdFor("DeliveriesTable"), 1, Me, "All Deliveries")
        FillDeliveriesDataGridView()
    End Sub

    Private Sub OrderDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrderItemDetailsToolStripMenuItem.Click
        'NOTE DeliveryItemDetailsGroupBox IS USED ALSO TO DISPLAY THE PURCHASE ORDER ITEM DETAILS
        If CurrentDeliveryItemsDataGridViewRow < 0 Then Exit Sub
        DeliveryItemDetailsGroupBox.Text = "Order Details"
        DeliveryItemDetailsGroupBox.Visible = True
        FillField(POItemProductDescTextBox.Text, NotNull(DeliveryItemsDataGridView.Item("ProductsPartsTableOrdered.ManufacturerDescription_ShortText250", CurrentDeliveryItemsDataGridViewRow).Value))
        FillField(POItemProductPartNoTextBox.Text, NotNull(DeliveryItemsDataGridView.Item("ProductsPartsTableOrdered.ManufacturerPartNo_ShortText30Fld", CurrentDeliveryItemsDataGridViewRow).Value))
        FillField(POItemQuantityTextBox.Text, NotNull(DeliveryItemsDataGridView.Item("POQty_Integer", CurrentDeliveryItemsDataGridViewRow).Value))
        FillField(POItemUnitTextBox.Text, NotNull(DeliveryItemsDataGridView.Item("ProductsPartsTableOrdered.Unit_ShortText3", CurrentDeliveryItemsDataGridViewRow).Value))
        FillField(BrandTextBox.Text, NotNull(DeliveryItemsDataGridView.Item("BrandsTableOrdered.BrandName_ShortText20", CurrentDeliveryItemsDataGridViewRow).Value))
        FillField(POItemUnitTextBox.Text, NotNull(DeliveryItemsDataGridView.Item("ProductsPartsTableOrdered.Unit_ShortText3", CurrentDeliveryItemsDataGridViewRow).Value))
    End Sub

    Private Sub DeliveryItemDetailsGroupBox_TextChanged(sender As Object, e As EventArgs) Handles DeliveryItemDetailsGroupBox.TextChanged
        If DeliveryItemDetailsGroupBox.Text = "Order Details" Then
            DeliveryItemDetailsGroupBox.Enabled = False
        Else
            DeliveryItemDetailsGroupBox.Enabled = True
        End If
    End Sub

    Private Sub PODetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PODetailsToolStripMenuItem.Click
        Tunnel1 = DeliveryItemsDataGridView.Item("PurchaseOrderID_LongInteger", CurrentDeliveryItemsDataGridViewRow).Value
        ShowCalledForm(Me, PurchaseOrdersForm)
    End Sub

    Private Sub RequisitionDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RequisitionDetailsToolStripMenuItem.Click

    End Sub
End Class
