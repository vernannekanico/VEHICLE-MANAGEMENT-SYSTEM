Public Class PurchaseOrdersForm
    Private PurchaseOrdersFieldsToSelect = ""
    Private PurchaseOrdersTableLinks = ""
    Private PurchaseOrdersSelectionFilter = ""
    Private PurchaseOrdersSelectionOrder = ""
    Private PurchaseOrdersRecordCount As Integer = -1
    Private CurrentPurchaseOrderID As Integer = -1
    Private CurrentPurchaseOrdersDataGridViewRow As Integer = -1
    Private PurchaseOrdersDataGridViewAlreadyFormated = False
    Private PurchaseOrderStatus = ""
    Private CurrentPOStatus = -1

    Private PurchaseOrdersItemsFieldsToSelect = ""
    Private PurchaseOrdersItemsTableLinks = ""
    Private PurchaseOrdersItemsSelectionFilter = ""
    Private PurchaseOrdersItemsSelectionOrder = ""
    Private PurchaseOrdersItemsRecordCount As Integer = -1
    Private CurrentPurchaseOrdersItemID As Integer = -1
    Private CurrentPurchaseOrdersItemsDataGridViewRow As Integer = -1
    Private PurchaseOrdersItemsDataGridViewAlreadyFormated = False
    Private PurchaseOrdersItemStatus = ""

    Private PurchaseStatusSelection = 0
    Private PurposeOfEntry As String

    Private CurrentSupplierID = -1
    Private CurrentPurchaseOrdersStatusSelection = -1
    Private CurrentProductPartId = -1
    Private SavedProductPartID = CurrentProductPartId

    Private SavedPurchaseOrderDiscount = 0
    Private SavedTaxAmount = 0
    Private SavedTax = 0
    Private SavedPurchaseOrderTotal = 0
    Private SavedSupplierName = ""
    Private SavedCallingForm As Form

    Private Sub PurchaseOrdersForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        SavedCallingForm = CallingForm
        CurrentPurchaseOrdersStatusSelection = 0
        If Tunnel1 = "Delivery Update" Then
            Me.Text = "SELECT ITEMS DELIVERED"
            SetToDeliveryMode()
            SetPurchaseOrdersSelectionFilter("Approved and Finalized")
        Else
            SetPurchaseOrdersSelectionFilter("Draft")
            PurchaseOrderDetailsGroupBox.Enabled = False
            DeliveredToolStripMenuItem.Visible = False
        End If
        PurchaseOrdersItemsDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        PurchaseOrdersDataGridView.Visible = True
    End Sub
    Private Sub PurchaseOrdersForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        If Me.Enabled = False Then
            Exit Sub
        End If
        CallingForm = SavedCallingForm

        ' GET RETURNED DATA HERE
        Select Case Tunnel1
            Case "Tunnel2IsProductPartID"
                CurrentProductPartId = Tunnel2
            Case "Tunnel2IsSupplierID"
                CurrentSupplierID = Tunnel2
                SupplierNameTextBox.Text = Tunnel3
        End Select
    End Sub

    Private Sub FillPurchaseOrdersDataGridView()
        PurchaseOrderDate.Text = DateString
        PurchaseOrderRevisionNoTextBox.Text = "0"

        Dim xxDraft = " IIf(PurchaseOrdersTable.PurchaseOrderStatus_Byte = 0, " & Chr(34) & "Draft" & Chr(34) & ","
        Dim xxForApproval = " IIf(PurchaseOrdersTable.PurchaseOrderStatus_Byte = 1, " & Chr(34) & "For Approval" & Chr(34) & ","
        Dim xxFinalized = " IIf(PurchaseOrdersTable.PurchaseOrderStatus_Byte = 2, " & Chr(34) & "Finalized" & Chr(34) & ","

        PurchaseOrderStatus = xxDraft & xxForApproval & xxFinalized & Chr(34) & Chr(34) &
                                " ))) AS PurchaseOrderStatus "

        PurchaseOrdersFieldsToSelect = " 
SELECT 
PurchaseOrdersTable.PurchaseOrderID_AutoNumber,
PurchaseOrdersTable.PurchaseOrderRevision_Integer,
PurchaseOrdersTable.PurchaseOrderDate_ShortDate,
PurchaseOrdersTable.SupplierID_LongInteger, 
PurchaseOrdersTable.Discount_Integer, 
PurchaseOrdersTable.ShippingCost_Double, 
PurchaseOrdersTable.TaxedAmount_Double, 
PurchaseOrdersTable.POTotal_Double, 
PurchaseOrdersTable.PurchaseOrderStatus_Byte,
SupplierTable.SupplierName_ShortText35, 
StatusesTable.StatusText_ShortText25
FROM (PurchaseOrdersTable LEFT JOIN SupplierTable ON PurchaseOrdersTable.SupplierID_LongInteger = SupplierTable.SupplierID_AutoNumber) LEFT JOIN StatusesTable ON PurchaseOrdersTable.PurchaseOrderStatusID_LongInteger = StatusesTable.StatusID_Autonumber
"
        PurchaseOrdersSelectionOrder = " ORDER BY PurchaseOrderID_AutoNumber DESC"

        MySelection = PurchaseOrdersFieldsToSelect & PurchaseOrdersTableLinks & PurchaseOrdersSelectionFilter & PurchaseOrdersSelectionOrder '

        JustExecuteMySelection()
        PurchaseOrdersRecordCount = RecordCount
        PurchaseOrdersDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        DeletePurchaseOrderToolStripMenuItem.Visible = True
        If PurchaseOrdersRecordCount = 0 Then
            DisablePurchaseOrderItemMenus()
        Else
            EnablePurchaseOrderItemMenus()
        End If
        If Not PurchaseOrdersDataGridViewAlreadyFormated Then
            FormatPurchaseOrderDataGridView()
        End If

        SetGroupBoxHeight(1, 10, PurchaseOrdersRecordCount, PurchaseOrdersGroupBox, PurchaseOrdersDataGridView)

        Me.Top = VehicleManagementSystemForm.VehicleManagementMenuStrip.Top + VehicleManagementSystemForm.VehicleManagementMenuStrip.Height + 20
        Me.Left = VehicleManagementSystemForm.Left
        PurchaseOrdersGroupBox.Left = (Me.Width - PurchaseOrdersGroupBox.Width) / 2
        PurchaseOrdersItemsGroupBox.Left = Me.Left
        PurchaseOrdersGroupBox.Top = PurchaseOrdersSearchToolStrip.Top + PurchaseOrdersSearchToolStrip.Height + 5
        PurchaseOrdersItemsGroupBox.Top = PurchaseOrdersGroupBox.Top + PurchaseOrdersGroupBox.Height + 5
        PurchaseOrderDetailsGroupBox.Top = PurchaseOrdersGroupBox.Top
        Me.Height = VehicleManagementSystemForm.Height - Me.Top
        RequisitionDetailsGroupBox.Top = (Me.Height - RequisitionDetailsGroupBox.Height) / 2
        RequisitionDetailsGroupBox.Left = (Me.Width - RequisitionDetailsGroupBox.Width) / 2
    End Sub
    Private Sub FormatPurchaseOrderDataGridView()
        PurchaseOrdersDataGridViewAlreadyFormated = True
        PurchaseOrdersGroupBox.Width = 0
        For i = 0 To PurchaseOrdersDataGridView.Columns.GetColumnCount(0) - 1

            PurchaseOrdersDataGridView.Columns.Item(i).Visible = False

            Select Case PurchaseOrdersDataGridView.Columns.Item(i).Name
                Case "PurchaseOrderID_AutoNumber"
                    PurchaseOrdersDataGridView.Columns.Item(i).HeaderText = "Purchase Order ID"
                    PurchaseOrdersDataGridView.Columns.Item(i).Width = 70
                    PurchaseOrdersDataGridView.Columns.Item(i).Visible = True
                Case "PurchaseOrderRevision_Integer"
                    PurchaseOrdersDataGridView.Columns.Item(i).HeaderText = "PO rev. #"
                    PurchaseOrdersDataGridView.Columns.Item(i).Width = 70
                    PurchaseOrdersDataGridView.Columns.Item(i).Visible = True
                Case "PurchaseOrderDate_ShortDate"
                    PurchaseOrdersDataGridView.Columns.Item(i).HeaderText = "PO Date"
                    PurchaseOrdersDataGridView.Columns.Item(i).Width = 90
                    PurchaseOrdersDataGridView.Columns.Item(i).Visible = True
                Case "Discount_Integer"
                    PurchaseOrdersDataGridView.Columns.Item(i).HeaderText = "Lump Sum Disc"
                    PurchaseOrdersDataGridView.Columns.Item(i).Width = 120
                    PurchaseOrdersDataGridView.Columns.Item(i).Visible = True
                Case "ShippingCost_Double"
                    PurchaseOrdersDataGridView.Columns.Item(i).HeaderText = "Shipping Cost"
                    PurchaseOrdersDataGridView.Columns.Item(i).Width = 120
                    PurchaseOrdersDataGridView.Columns.Item(i).Visible = True
                Case "TaxedAmount_Double"
                    PurchaseOrdersDataGridView.Columns.Item(i).HeaderText = "Tax"
                    PurchaseOrdersDataGridView.Columns.Item(i).Width = 120
                    PurchaseOrdersDataGridView.Columns.Item(i).Visible = True
                Case "POTotal_Double"
                    PurchaseOrdersDataGridView.Columns.Item(i).HeaderText = "Grand Total"
                    PurchaseOrdersDataGridView.Columns.Item(i).Width = 120
                    PurchaseOrdersDataGridView.Columns.Item(i).Visible = True
                Case "SupplierName_ShortText35"
                    PurchaseOrdersDataGridView.Columns.Item(i).HeaderText = "Supplier"
                    PurchaseOrdersDataGridView.Columns.Item(i).Width = 200
                    PurchaseOrdersDataGridView.Columns.Item(i).Visible = True
                Case "StatusText_ShortText25"
                    PurchaseOrdersDataGridView.Columns.Item(i).HeaderText = "Status"
                    PurchaseOrdersDataGridView.Columns.Item(i).Width = 150
                    PurchaseOrdersDataGridView.Columns.Item(i).Visible = True
            End Select
            If PurchaseOrdersDataGridView.Columns.Item(i).Visible = True Then
                PurchaseOrdersGroupBox.Width = PurchaseOrdersGroupBox.Width + PurchaseOrdersDataGridView.Columns.Item(i).Width
            End If
        Next

        ' NOTE" SYSTEM AUTOFITS THE GRIDVIEW FIELDS ACCORDING TO THEIR WITDH
        Me.Width = VehicleManagementSystemForm.Width
        If PurchaseOrdersItemsGroupBox.Width > Me.Width Then
            PurchaseOrdersItemsGroupBox.Width = Me.Width - 2
        End If
        If PurchaseOrdersGroupBox.Width > Me.Width + 20 Then
            PurchaseOrdersGroupBox.Width = Me.Width - 80
        Else
            PurchaseOrdersGroupBox.Width = PurchaseOrdersGroupBox.Width + 20
        End If


    End Sub

    Private Sub PurchaseOrderDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles PurchaseOrdersDataGridView.RowEnter
        If ShowInTaskbarFlag Then
            Exit Sub
        End If
        If e.RowIndex < 0 Then Exit Sub
        If PurchaseOrdersRecordCount = 0 Then Exit Sub

        CurrentPurchaseOrdersDataGridViewRow = e.RowIndex
        CurrentPurchaseOrderID = PurchaseOrdersDataGridView.Item("PurchaseOrderID_Autonumber", CurrentPurchaseOrdersDataGridViewRow).Value
        CurrentSupplierID = PurchaseOrdersDataGridView.Item("SupplierID_LongInteger", CurrentPurchaseOrdersDataGridViewRow).Value
        CurrentPOStatus = PurchaseOrdersDataGridView.Item("StatusText_ShortText25", CurrentPurchaseOrdersDataGridViewRow).Value
        SupplierNameTextBox.Text = NotNull(PurchaseOrdersDataGridView.Item("SupplierName_ShortText35", CurrentPurchaseOrdersDataGridViewRow).Value)
        PurchaseOrderRevisionNoTextBox.Text = NotNull(PurchaseOrdersDataGridView.Item("PurchaseOrderRevision_Integer", CurrentPurchaseOrdersDataGridViewRow).Value)
        PurchaseOrderDate.Text = NotNull(PurchaseOrdersDataGridView.Item("PurchaseOrderDate_ShortDate", CurrentPurchaseOrdersDataGridViewRow).Value)
        POLumpSumDiscountTextBox.Text = NotNull(PurchaseOrdersDataGridView.Item("Discount_Integer", CurrentPurchaseOrdersDataGridViewRow).Value)
        ShippingCostTextBox.Text = NotNull(PurchaseOrdersDataGridView.Item("ShippingCost_Double", CurrentPurchaseOrdersDataGridViewRow).Value)
        POTaxAmountTextBox.Text = NotNull(PurchaseOrdersDataGridView.Item("TaxedAmount_Double", CurrentPurchaseOrdersDataGridViewRow).Value)
        POTotalTextBox.Text = NotNull(PurchaseOrdersDataGridView.Item("POTotal_Double", CurrentPurchaseOrdersDataGridViewRow).Value)
        PurchaseOrderIDTextBox.Text = NotNull(PurchaseOrdersDataGridView.Item("PurchaseOrderID_AutoNumber", CurrentPurchaseOrdersDataGridViewRow).Value)
        PurchaseOrdersItemsSelectionFilter = " WHERE PurchaseOrdersItemsTable.PurchaseOrderID_LongInteger = " & CurrentPurchaseOrderID.ToString
        EditPurchaseOrderToolStripMenuItem.Visible = False
        DeletePurchaseOrderToolStripMenuItem.Visible = False
        SubmitForApprovalToolStripMenuItem.Visible = False
        ApproveStripMenuItem.Visible = False
        DisablePurchaseOrderItemMenus()
        Select Case CurrentPOStatus
            Case "Draft"
                EditPurchaseOrderToolStripMenuItem.Visible = True
                DeletePurchaseOrderToolStripMenuItem.Visible = True
                SubmitForApprovalToolStripMenuItem.Visible = True
                EnablePurchaseOrderMenus()
                EnablePurchaseOrderItemMenus()
            Case "For Approval"
                DisablePurchaseOrderMenus()
                DisablePurchaseOrderItemMenus()
                ApproveStripMenuItem.Visible = True
                AddPurchaseOrderToolStripMenuItem.Visible = True
        End Select
        FillPurchaseOrdersItemsDataGridView()

    End Sub


    Private Sub FillPurchaseOrdersItemsDataGridView()
        Dim xxDraft = " IIf(PurchaseOrdersItemsTable.PurchaseOrdersItemStatus_Byte = 0, " & Chr(34) & "Draft" & Chr(34) & ","
        Dim xxForApproval = " IIf(PurchaseOrdersItemsTable.PurchaseOrdersItemStatus_Byte = 1, " & Chr(34) & "For Approval" & Chr(34) & ","
        Dim xxOrdered = " IIf(PurchaseOrdersItemsTable.PurchaseOrdersItemStatus_Byte = 2, " & Chr(34) & "Ordered" & Chr(34) & ","

        PurchaseOrdersItemStatus = xxDraft & xxForApproval & xxOrdered & Chr(34) & Chr(34) &
                                " ))) AS PurchaseOrderStatus "

        PurchaseOrdersItemsFieldsToSelect = "
SELECT 
MasterCodeBookTable.SystemDesc_ShortText100Fld, 
ProductsPartsOrderedTable.ManufacturerDescription_ShortText250, 
ProductsPartsOrderedTable.ManufacturerPartNo_ShortText30Fld, 
PurchaseOrdersItemsTable.POQty_Integer, 
ProductsPartsOrderedTable.Unit_ShortText3, 
PurchaseOrdersItemsTable.Price_Currency, 
PurchaseOrdersItemsTable.ItemDiscount_Integer, 
BrandsOrderedTable.BrandName_ShortText20, 
PurchaseOrdersItemsTable.DeliveryMode_Byte,
MasterCodeBookTable.MasterCodeBookID_Autonumber, 
WorkOrderPartsTable.Unit_ShortText3, 
ProductsPartsRequestedTable.ManufacturerPartNo_ShortText30Fld, 
ProductsPartsRequestedTable.ManufacturerDescription_ShortText250, 
PartsRequisitionsItemsTable.RequisitionQuantity_Double, 
ProductsPartsRequestedTable.Unit_ShortText3, 
BrandsRequestedTable.BrandName_ShortText20, 
PurchaseOrdersTable.PurchaseOrderRevision_Integer, 
PurchaseOrdersTable.PurchaseOrderID_AutoNumber, 
PurchaseOrdersTable.PurchaseOrderDate_ShortDate, 
PartsRequisitionsItemsTable.PartsRequisitionsItemID_AutoNumber, 
PartsRequisitionsItemsTable.PartsRequisitionID_LongInteger, 
PartsRequisitionsItemsTable.ProductPartID_LongInteger, 
PurchaseOrdersItemsTable.PurchaseOrdersItemID_AutoNumber, 
PurchaseOrdersItemsTable.PurchaseOrdersItemStatus_Byte, 
VehicleDescription.VehicleDescription
FROM ((((((((((PurchaseOrdersItemsTable RIGHT JOIN PartsRequisitionsItemsTable ON PurchaseOrdersItemsTable.PartsRequisitionsItemID_LongInteger = PartsRequisitionsItemsTable.PartsRequisitionsItemID_AutoNumber) LEFT JOIN PurchaseOrdersTable ON PurchaseOrdersItemsTable.PurchaseOrderID_LongInteger = PurchaseOrdersTable.PurchaseOrderID_AutoNumber) LEFT JOIN ProductsPartsTable AS ProductsPartsRequestedTable ON PartsRequisitionsItemsTable.ProductPartID_LongInteger = ProductsPartsRequestedTable.ProductsPartID_Autonumber) LEFT JOIN MasterCodeBookTable ON ProductsPartsRequestedTable.MasterCodeBookID_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) LEFT JOIN BrandsTable AS BrandsRequestedTable ON ProductsPartsRequestedTable.BrandID_LongInteger = BrandsRequestedTable.BrandID_Autonumber) LEFT JOIN WorkOrderPartsRequisitionsItemsTable ON PartsRequisitionsItemsTable.OrderPartsRequisitionsItemID_LongInteger = WorkOrderPartsRequisitionsItemsTable.WorkOrderPartsRequisitionsItemID_AutoNumber) LEFT JOIN WorkOrderPartsTable ON WorkOrderPartsRequisitionsItemsTable.WorkOrderPartID_LongInteger = WorkOrderPartsTable.WorkOrderPartID_AutoNumber) LEFT JOIN ProductsPartsTable AS ProductsPartsOrderedTable ON PurchaseOrdersItemsTable.ProductPartID_LongInteger = ProductsPartsOrderedTable.ProductsPartID_Autonumber) LEFT JOIN BrandsTable AS BrandsOrderedTable ON ProductsPartsOrderedTable.BrandID_LongInteger = BrandsOrderedTable.BrandID_Autonumber) LEFT JOIN PartsRequisitionsTable ON PartsRequisitionsItemsTable.PartsRequisitionID_LongInteger = PartsRequisitionsTable.PartsRequisitionID_AutoNumber) LEFT JOIN VehicleDescription ON PartsRequisitionsTable.VehicleID_LongInteger = VehicleDescription.VehicleID_AutoNumber
"

        PurchaseOrdersItemsTableLinks = " 
"
        PurchaseOrdersItemsSelectionOrder = " ORDER BY PurchaseOrdersItemID_AutoNumber DESC"

        MySelection = PurchaseOrdersItemsFieldsToSelect & PurchaseOrdersItemsTableLinks & PurchaseOrdersItemsSelectionFilter & PurchaseOrdersItemsSelectionOrder '
        JustExecuteMySelection()
        PurchaseOrdersItemsRecordCount = RecordCount
        PurchaseOrdersItemsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If Not PurchaseOrdersItemsDataGridViewAlreadyFormated Then
            FormatPurchaseOrdersItemsDataGridView()
        End If


        Dim MaxBottom = 20 - PurchaseOrdersItemsRecordCount
        SetGroupBoxHeight(1, MaxBottom, PurchaseOrdersRecordCount, PurchaseOrdersGroupBox, PurchaseOrdersDataGridView)

        PurchaseOrdersItemsGroupBox.Top = PurchaseOrdersGroupBox.Top + PurchaseOrdersGroupBox.Height
        Dim RowsHeight = 0
        For i = 0 To PurchaseOrdersItemsRecordCount - 1
            RowsHeight = RowsHeight + PurchaseOrdersItemsDataGridView.Rows(CurrentPurchaseOrdersItemsDataGridViewRow).Height
        Next
        PurchaseOrdersItemsGroupBox.Height = RowsHeight + PurchaseOrdersItemsDataGridView.ColumnHeadersHeight + 60

    End Sub
    Private Sub FormatPurchaseOrdersItemsDataGridView()
        PurchaseOrdersItemsDataGridViewAlreadyFormated = True
        PurchaseOrdersItemsGroupBox.Width = 0
        For i = 0 To PurchaseOrdersItemsDataGridView.Columns.GetColumnCount(0) - 1
            PurchaseOrdersItemsDataGridView.Columns.Item(i).Visible = False
            Select Case PurchaseOrdersItemsDataGridView.Columns.Item(i).Name
                Case "SystemDesc_ShortText100Fld"
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).HeaderText = "Part "
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).Width = 200
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).Visible = True
                Case "ProductsPartsOrderedTable.ManufacturerPartNo_ShortText30Fld"
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).HeaderText = "Manufac Part #"
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).Width = 130
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).Visible = True
                Case "ProductsPartsOrderedTable.ManufacturerDescription_ShortText250"
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).HeaderText = "Manufac Description"
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).Width = 350
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).Visible = True
                Case "POQty_Integer"
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).HeaderText = "Qty"
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).Width = 50
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).Visible = True
                Case "ProductsPartsOrderedTable.Unit_ShortText3"
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).HeaderText = "Unit"
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).Width = 50
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).Visible = True
                Case "Price_Currency"
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).HeaderText = "Price"
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).Width = 60
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).Visible = True
                Case "ItemDiscount_Integer"
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).HeaderText = "Disc %"
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).Width = 50
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).Visible = True
                Case "BrandsOrderedTable.BrandName_ShortText20"
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).HeaderText = "Brand"
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).Width = 120
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).Visible = True
                Case "DeliveryMode_Byte"
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).HeaderText = "Delivery Mode"
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).Width = 120
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).Visible = True
                Case "WorkOrderPartsTable.Unit_ShortText3"
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).HeaderText = "Spec unit"
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).Width = 50
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).Visible = True
                Case "VehicleDescription"
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).HeaderText = " Vehicle Model"
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).Width = 250
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).Visible = True
                Case "ProductsPartsRequestedTable.ManufacturerPartNo_ShortText30Fld"
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).HeaderText = "Req Part #"
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).Width = 130
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).Visible = True
                Case "ProductsPartsRequestedTable.ManufacturerDescription_ShortText250"
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).HeaderText = "Req Manufac Description"
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).Width = 350
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).Visible = True
                Case "RequisitionQuantity_Double"
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).HeaderText = "Req Qty"
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).Width = 60
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).Visible = True
                Case "ProductsPartsRequestedTable.Unit_ShortText3"
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).HeaderText = "Req Unt"
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).Width = 50
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).Visible = True
                Case "BrandsRequestedTable.BrandName_ShortText20"
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).HeaderText = "Req Brand"
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).Width = 150
                    PurchaseOrdersItemsDataGridView.Columns.Item(i).Visible = True
            End Select
            If PurchaseOrdersItemsDataGridView.Columns.Item(i).Visible = True Then
                PurchaseOrdersItemsGroupBox.Width = PurchaseOrdersItemsGroupBox.Width + PurchaseOrdersItemsDataGridView.Columns.Item(i).Width
            End If
        Next

        ' NOTE" SYSTEM AUTOFITS THE GRIDVIEW FIELDS ACCORDING TO THEIR WITDH

    End Sub
    Private Sub PurchaseOrdersItemsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles PurchaseOrdersItemsDataGridView.RowEnter
        If ShowInTaskbarFlag Then
            Exit Sub
        End If
        If e.RowIndex < 0 Then Exit Sub
        If PurchaseOrdersItemsRecordCount = 0 Then Exit Sub
        CurrentPurchaseOrdersItemsDataGridViewRow = e.RowIndex
        CurrentProductPartId = PurchaseOrdersItemsDataGridView.Item("ProductPartID_LongInteger", CurrentPurchaseOrdersItemsDataGridViewRow).Value
        CurrentPurchaseOrdersItemID = PurchaseOrdersItemsDataGridView.Item("PurchaseOrdersItemID_AutoNumber", CurrentPurchaseOrdersItemsDataGridViewRow).Value
    End Sub
    Private Sub ReturnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnToolStripMenuItem.Click
        If PurchaseOrderDetailsGroupBox.Visible Then
            If SupplierNameTextBox.Text <> "Search" Or SupplierNameTextBox.Text <> "" Then
                DoCommonSaveRoutine()
                PurchaseOrderDetailsGroupBox.Visible = False
                Exit Sub
            End If
        End If
        If DeliveredToolStripMenuItem.Visible Then
            UpdateDeliveredItems()
        End If
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub
    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddPurchaseOrderToolStripMenuItem.Click
        PurchaseOrderIDTextBox.Text = ""
        PurchaseOrderRevisionNoTextBox.Text = "0"
        PurchaseOrderIDTextBox.Text = ""
        PurchaseOrderDate.Text = DateString
        SupplierNameTextBox.Text = "Search"
        PurchaseOrderDetailsGroupBox.Enabled = False
        PurchaseOrderDetailsGroupBox.Enabled = True
        PurposeOfEntry = "ADD"
        CurrentPurchaseOrderID = -1
        SupplierNameTextBox.Select()
        DisablePurchaseOrderMenus()
    End Sub
    Private Sub AddAPurchaseOrderRecord()
        'record was first tested if it already exist in the PurchaseOrder table
        Dim FieldsToUpdate = " PurchaseOrderRevision_Integer, " &
                                " PurchaseOrderDate_ShortDate, " &
                                " SupplierID_LongInteger, " &
                                " Purchaser_LongInteger, " &
                                " Discount_Integer, " &
                                " ShippingCost_Double, " &
                                " TaxedAmount_Double, " &
                                " POTotal_Double, " &
                                " PurchaseOrderStatus_Byte "

        Dim FieldsData = 0.ToString & ", " &
                                Chr(34) & DateString & Chr(34) & ", " &
                                CurrentSupplierID.ToString & ", " &
                                CurrentUserID.ToString & ", " &
                                0.ToString & ", " &
                                0.ToString & ", " &
                                0.ToString & ", " &
                                0.ToString & ", " &
                                0.ToString

        CurrentPurchaseOrderID = InsertNewRecord("PurchaseOrdersTable", FieldsToUpdate, FieldsData)

    End Sub
    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditPurchaseOrderToolStripMenuItem.Click
        PODetailsOFFToolStripMenuItem.Visible = False
        PurposeOfEntry = "EDIT"
        PurchaseOrderDetailsGroupBox.Enabled = True
        PurchaseOrderDetailsGroupBox.Visible = True
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeletePurchaseOrderToolStripMenuItem.Click
        PurposeOfEntry = "DELETE"
        '      LoadPurchaseOrderDetails()
        If PurchaseOrdersItemsRecordCount > 0 Then
            MsgBox("Unable to delete this Work Order." & vbCrLf & "delete first all PurchaseOrders items attached")
            Exit Sub
        End If

        Dim Question As String = "Proceed to delete"
        Dim DeleteThisPurchaseOrder As String = MsgBox(Question, 4)
        If DeleteThisPurchaseOrder = vbNo Then
            Exit Sub
        End If
        MySelection = "DELETE FROM PurchaseOrdersTable WHERE PurchaseOrderID_AutoNumber = " & Str(CurrentPurchaseOrderID)

        JustExecuteMySelection()
        ' CHECK     SetupPurchaseOrdersSelection(1)
        If ThisRecordNotYetExistsInThePurchaseOrdersTable() Then
            MsgBox("Successfuly deleted the record")
        Else
            MsgBox("UnSuccessfuly deleted the record, ????????")
        End If
        FillPurchaseOrdersDataGridView()

    End Sub
    Private Function ThisRecordNotYetExistsInThePurchaseOrdersTable()
        MySelection = "SELECT * " &
                       " FROM PurchaseOrdersTable " &
                      " WHERE PurchaseOrderID_AutoNumber = " & CurrentPurchaseOrderID.ToString

        If NoRecordFound() Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SavePurchaseOrderToolStripMenuItem.Click
        DoCommonSaveRoutine()
    End Sub
    Private Function AChangeOccuredInPOEdit()





        '*******************************************************
        ' CHECK THIS THE TheseAreNotEqual ROUTINE WAS MODIFIED, WATCH PARAMETER pURPOSEOFENTRY










        If TheseAreNotEqual(CurrentSupplierID, NotNull(PurchaseOrdersDataGridView.Item("SupplierID_LongInteger", CurrentPurchaseOrdersDataGridViewRow).Value), PurposeOfEntry) Then Return True
        If TheseAreNotEqual(PurchaseOrderDate.Text, NotNull(PurchaseOrdersItemsDataGridView.Item("PurchaseOrderDate_ShortDate", CurrentPurchaseOrdersItemsDataGridViewRow).Value), PurposeOfEntry) Then Return True
        If TheseAreNotEqual(Val(POLumpSumDiscountTextBox.Text), NotNull(PurchaseOrdersDataGridView.Item("Discount_Integer", CurrentPurchaseOrdersDataGridViewRow).Value), PurposeOfEntry) Then Return True
        If TheseAreNotEqual(Val(POTaxAmountTextBox.Text), NotNull(PurchaseOrdersDataGridView.Item("TaxedAmount_Double", CurrentPurchaseOrdersDataGridViewRow).Value), PurposeOfEntry) Then Return True
        If TheseAreNotEqual(Val(POTotalTextBox.Text), NotNull(PurchaseOrdersDataGridView.Item("POTotal_Double", CurrentPurchaseOrdersDataGridViewRow).Value), PurposeOfEntry) Then Return True
        If TheseAreNotEqual(POItemProductDescTextBox.Text, NotNull(PurchaseOrdersItemsDataGridView.Item("ProductsPartsOrderedTable.ManufacturerDescription_ShortText250", CurrentPurchaseOrdersItemsDataGridViewRow).Value), PurposeOfEntry) Then Return True
        Return False

    End Function
    Private Sub DoCommonSaveRoutine()
        If PurchaseOrderDetailsGroupBox.Visible Then
            SavePOHeaderChanges()
        ElseIf RequisitionDetailsGroupBox.Visible Then
            SaveChanges()
        Else
            DoCommonHouseKeeping(Me, SavedCallingForm)
        End If
    End Sub
    Private Sub SavePOHeaderChanges()
        Dim xxAppendex = "  this as new Purchase Order? "
        If SupplierNameTextBox.Text = "Search" Or SupplierNameTextBox.Text = "" Then
            If Not MsgBox(" No Supplier is indicated, CONTINUE ? ", vbYesNo) = vbYes Then
                If Not MsgBox(" Would you like this Purchase Order with no Supplier Info ", vbYesNo) = vbYes Then
                    PurchaseOrderDetailsGroupBox.Enabled = False
                    Exit Sub
                End If
                CurrentSupplierID = -1
            Else
                SupplierNameTextBox.Select()
                Exit Sub
            End If
        End If

        Select Case PurposeOfEntry
            Case "ADD"
                If ThisRecordNotYetExistsInThePurchaseOrdersTable() Then
                    If Not MsgBox(" Sure you want to create" & xxAppendex, vbYesNo) = vbYes Then
                        PurchaseOrderDetailsGroupBox.Enabled = False
                        Exit Sub
                    End If
                    MySelection = "SELECT * " &
                       " FROM PurchaseOrdersTable " &
                      " WHERE PurchaseOrderID_AutoNumber = " & CurrentPurchaseOrderID.ToString
                    AddAPurchaseOrderRecord()
                Else
                    MsgBox(" Record Is already registerd")
                    Close()
                    Exit Sub
                End If
            Case = "EDIT"
                If Not AChangeOccuredInPOHeaderEdit() Then
                    MsgBox("No Changes to Save ?")
                    PurchaseOrderDetailsGroupBox.Visible = False
                    Exit Sub
                End If
                If Not MsgBox(" Confirm Saving changes to this Purchase Order details ", vbYesNo) = vbYes Then
                    PurchaseOrderDetailsGroupBox.Enabled = False
                    Exit Sub
                End If


                Dim RecordFilter = " WHERE PurchaseOrderID_AutoNumber = " & Str(CurrentPurchaseOrderID)
                Dim SetCommand = " SET SupplierID_LongInteger = " & CurrentSupplierID.ToString & "," &
                                      " PurchaseOrderDate_ShortDate = " & Chr(34) & Trim(PurchaseOrderDate.Text) & Chr(34) & ", " &
                                      " Discount_Integer = " & Val(POLumpSumDiscountTextBox.Text).ToString & "," &
                                      " TaxedAmount_Double = " & Val(POTaxAmountTextBox.Text).ToString & "," &
                                      " ShippingCost_Double = " & Val(ShippingCostTextBox.Text).ToString & "," &
                                      " POTotal_Double = " & Val(POTotalTextBox.Text).ToString
                UpdateTable("PurchaseOrdersTable", SetCommand, RecordFilter)
                PurchaseOrderDetailsGroupBox.Enabled = False
                FillPurchaseOrdersDataGridView()
        End Select
        PurchaseOrderDetailsGroupBox.Enabled = False


    End Sub
    Private Function AChangeOccuredInPOHeaderEdit()
        Dim xxxPurchaseOrderDate = Convert.ToDateTime(PurchaseOrderDate.Text)
        Dim xxxPurchaseOrderDate_ShortDate = NotNull(PurchaseOrdersDataGridView.Item("PurchaseOrderDate_ShortDate", CurrentPurchaseOrdersDataGridViewRow).Value)
        xxxPurchaseOrderDate_ShortDate = Convert.ToDateTime(xxxPurchaseOrderDate_ShortDate)






        '*******************************************************
        ' CHECK THIS THE TheseAreNotEqual ROUTINE WAS MODIFIED, WATCH PARAMETER pURPOSEOFENTRY









        If TheseAreNotEqual(SupplierNameTextBox.Text, NotNull(PurchaseOrdersDataGridView.Item("SupplierName_ShortText35", CurrentPurchaseOrdersDataGridViewRow).Value), PurposeOfEntry) Then Return True
        If TheseAreNotEqual(xxxPurchaseOrderDate, NotNull(PurchaseOrdersDataGridView.Item("PurchaseOrderDate_ShortDate", CurrentPurchaseOrdersDataGridViewRow).Value), PurposeOfEntry) Then Return True
        If TheseAreNotEqual(POTaxAmountTextBox.Text, NotNull(PurchaseOrdersDataGridView.Item("TaxedAmount_Double", CurrentPurchaseOrdersDataGridViewRow).Value), PurposeOfEntry) Then Return True
        If TheseAreNotEqual(POTotalTextBox.Text, NotNull(PurchaseOrdersDataGridView.Item("POTotal_Double", CurrentPurchaseOrdersDataGridViewRow).Value), PurposeOfEntry) Then Return True
        If TheseAreNotEqual(POLumpSumDiscountTextBox.Text, NotNull(PurchaseOrdersDataGridView.Item("Discount_Integer", CurrentPurchaseOrdersDataGridViewRow).Value), PurposeOfEntry) Then Return True


        Return False
    End Function
    Private Sub DraftPurchaseOrdersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DraftPurchaseOrdersToolStripMenuItem.Click
        SetPurchaseOrdersSelectionFilter("Draft")
    End Sub

    Private Sub SubmittedForApprovalPurchaseOrders_Click(sender As Object, e As EventArgs) Handles SubmittedForApprovalPurchaseOrdersToolStripMenuItem.Click
        SetPurchaseOrdersSelectionFilter("For Approval")
    End Sub
    Private Sub FinalizedPurchaseOrdersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FinalizedPurchaseOrdersToolStripMenuItem.Click
        SetPurchaseOrdersSelectionFilter("Approved and Finalized")
    End Sub
    Private Sub AllPurchaseOrdersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllPurchaseOrdersToolStripMenuItem.Click
        PurchaseOrdersSelectionFilter = ""
        FillPurchaseOrdersDataGridView()
    End Sub
    Private Sub SetPurchaseOrdersSelectionFilter(Passed As String)
        PurchaseOrdersSelectionFilter = " WHERE PurchaseOrderStatusID_LongInteger = " & GetStatusIdFor("PurchaseOrdersTable", Passed)
        FillPurchaseOrdersDataGridView()
    End Sub
    Private Sub PrintPurchaseOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintPurchaseOrderToolStripMenuItem.Click

    End Sub


    Private Sub PODetailsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PODetailsToolStripMenuItem1.Click
        PurposeOfEntry = "VIEW"
        PurchaseOrderDetailsGroupBox.Visible = True
        PODetailsOFFToolStripMenuItem.Visible = True
        PODetailsToolStripMenuItem1.Visible = False
    End Sub
    Private Sub PODetailsOFFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PODetailsOFFToolStripMenuItem.Click
        PODetailsOFFToolStripMenuItem.Visible = False
        PODetailsToolStripMenuItem1.Visible = True
        PurchaseOrderDetailsGroupBox.Visible = False
    End Sub
    Private Sub PurchaseOrderDetailsGroupBox_VisibleChanged(sender As Object, e As EventArgs) Handles PurchaseOrderDetailsGroupBox.VisibleChanged
        If PurchaseOrderDetailsGroupBox.Visible = True Then
            SavedSupplierName = SupplierNameTextBox.Text
            CalculatePOTotals()
            SavedPurchaseOrderTotal = Val(POTotalTextBox.Text)
            SavedPurchaseOrderDiscount = Val(POLumpSumDiscountTextBox.Text)
            SavedTaxAmount = Val(POTaxAmountTextBox.Text)
            SavedTax = Val(POLumpSumDiscountTextBox.Text)
            DisablePurchaseOrderItemMenus()


        Else
            EnablePurchaseOrderMenus()
            EnablePurchaseOrderItemMenus()
        End If
    End Sub

    Private Sub PurchaseOrderDetailsGroupBox_EnabledChanged(sender As Object, e As EventArgs) Handles PurchaseOrderDetailsGroupBox.EnabledChanged
        If CurrentPurchaseOrdersDataGridViewRow > -1 Then
            If PurchaseOrdersDataGridView.Item("PurchaseOrderStatus_Byte", CurrentPurchaseOrdersDataGridViewRow).Value > 0 Then Exit Sub
        End If
        If PurchaseOrderDetailsGroupBox.Enabled = True Then
            PurchaseOrderDetailsGroupBox.Visible = True
            SavePurchaseOrderToolStripMenuItem.Visible = True
            PurchaseOrdersGroupBox.Enabled = False
            PurchaseOrdersItemsGroupBox.Enabled = False
            EnablePurchaseOrderItemMenus()
            DisablePurchaseOrderMenus()
            CalculatePOTotals()
        Else
            SavePurchaseOrderToolStripMenuItem.Visible = False
            PurchaseOrderDetailsGroupBox.Visible = False
            EnablePurchaseOrderMenus()
            EnablePurchaseOrderItemMenus()
            PurchaseOrdersGroupBox.Enabled = True
            PurchaseOrdersItemsGroupBox.Enabled = True
        End If
    End Sub

    Private Sub SupplierNameTextBox_Click(sender As Object, e As EventArgs) Handles SupplierNameTextBox.Click
        If SupplierNameTextBox.Text <> "Search" Or IsEmpty(SupplierNameTextBox.Text) Then
            If MsgBox("Do you intend to change the Supplier ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        End If
        ShowCalledForm(Me, SuppliersForm)
    End Sub
    Private Sub AddPOItemsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddPOItemsToolStripMenuItem.Click
        'note items will be selected from the PartsRequisitions for purchase
        PurchaseOrderDetailsGroupBox.Enabled = False
        PurchaseOrderDetailsGroupBox.Enabled = True
        AddPurchaseOrderToolStripMenuItem.Enabled = False
        PurposeOfEntry = "ADD"
        CurrentPurchaseOrderID = -1

        ShowCalledForm(Me, PartsRequisitionsForm)

        PurchaseOrderDate.Text = DateString
        SupplierNameTextBox.Select()

    End Sub

    Private Sub EditPOItemToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles EditPOItemToolStripMenuItem.Click
        RequisitionDetailsGroupBox.Visible = True
        POItemProductPartNoTextBox.Text = NotNull(PurchaseOrdersItemsDataGridView.Item("ProductsPartsOrderedTable.ManufacturerPartNo_ShortText30Fld", CurrentPurchaseOrdersItemsDataGridViewRow).Value)
        POItemProductDescTextBox.Text = NotNull(PurchaseOrdersItemsDataGridView.Item("ProductsPartsOrderedTable.ManufacturerDescription_ShortText250", CurrentPurchaseOrdersItemsDataGridViewRow).Value)
        POItemQuantityTextBox.Text = NotNull(PurchaseOrdersItemsDataGridView.Item("POQty_Integer", CurrentPurchaseOrdersItemsDataGridViewRow).Value)
        POItemUnitTextBox.Text = NotNull(PurchaseOrdersItemsDataGridView.Item("ProductsPartsOrderedTable.Unit_ShortText3", CurrentPurchaseOrdersItemsDataGridViewRow).Value)
        POItemPriceTextBox.Text = NotNull(PurchaseOrdersItemsDataGridView.Item("Price_Currency", CurrentPurchaseOrdersItemsDataGridViewRow).Value)
        DeliveryModeTextBox.Text = NotNull(PurchaseOrdersItemsDataGridView.Item("DeliveryMode_Byte", CurrentPurchaseOrdersItemsDataGridViewRow).Value)
        RequisitionItemProductDescText.Text = NotNull(PurchaseOrdersItemsDataGridView.Item("ProductsPartsRequestedTable.ManufacturerDescription_ShortText250", CurrentPurchaseOrdersItemsDataGridViewRow).Value)
        RequisitionItemProductPartNoTextBox.Text = NotNull(PurchaseOrdersItemsDataGridView.Item("ProductsPartsRequestedTable.ManufacturerPartNo_ShortText30Fld", CurrentPurchaseOrdersItemsDataGridViewRow).Value)
        RequisitionItemQuantityTextBox.Text = NotNull(PurchaseOrdersItemsDataGridView.Item("RequisitionQuantity_Double", CurrentPurchaseOrdersItemsDataGridViewRow).Value)
        RequisitionItemUnitTextBox.Text = NotNull(PurchaseOrdersItemsDataGridView.Item("ProductsPartsRequestedTable.Unit_ShortText3", CurrentPurchaseOrdersItemsDataGridViewRow).Value)
        PartDescTextBox.Text = NotNull(PurchaseOrdersItemsDataGridView.Item("SystemDesc_ShortText100Fld", CurrentPurchaseOrdersItemsDataGridViewRow).Value)
        SavedProductPartID = CurrentProductPartId
        If NotEmpty(RequisitionItemProductDescText.Text) Then
            CopyProductButton.Visible = True
        Else
            CopyProductButton.Visible = False
        End If
    End Sub
    Private Sub RequisitionDetailsGroupBox_VisibleChanged(sender As Object, e As EventArgs) Handles RequisitionDetailsGroupBox.VisibleChanged

        If RequisitionDetailsGroupBox.Visible = True Then
            EditPOItemToolStripMenuItem.Visible = False
            PurchaseOrdersGroupBox.Enabled = False
            PurchaseOrdersItemsGroupBox.Enabled = False
            DisablePurchaseOrderMenus()
            DisablePurchaseOrderItemMenus()
        Else
            EditPOItemToolStripMenuItem.Visible = True
            PurchaseOrdersGroupBox.Enabled = True
            PurchaseOrdersItemsGroupBox.Enabled = True
            EnablePurchaseOrderMenus()
            EnablePurchaseOrderItemMenus()
        End If
    End Sub
    Private Sub EnablePurchaseOrderMenus()
        '       PurchaseOrdersToolStripMenus.Visible = True
        AddPurchaseOrderToolStripMenuItem.Visible = True
        EditPurchaseOrderToolStripMenuItem.Visible = True
        DeletePurchaseOrderToolStripMenuItem.Visible = True
    End Sub
    Private Sub DisablePurchaseOrderMenus()
        '       PurchaseOrdersToolStripMenus.Visible = False
        AddPurchaseOrderToolStripMenuItem.Visible = False
        EditPurchaseOrderToolStripMenuItem.Visible = False
        DeletePurchaseOrderToolStripMenuItem.Visible = False
        SubmitForApprovalToolStripMenuItem.Visible = False
    End Sub
    Private Sub EnablePurchaseOrderItemMenus()
        PurchaseOrderItemsToolStripMenus.Visible = True
        EditPOItemToolStripMenuItem.Visible = True
        DeletePOItem.Visible = True
        AddPOItemsToolStripMenuItem.Visible = True
    End Sub
    Private Sub DisablePurchaseOrderItemMenus()
        PurchaseOrderItemsToolStripMenus.Visible = False
        EditPOItemToolStripMenuItem.Visible = False
        DeletePOItem.Visible = False
        AddPOItemsToolStripMenuItem.Visible = False
    End Sub
    Private Sub DeletePOItem_Click(sender As Object, e As EventArgs) Handles DeletePOItem.Click
        If MsgBox("Proceed to delete ?", MsgBoxStyle.YesNo) = vbNo Then
            Exit Sub
        End If
        MySelection = "DELETE FROM PurchaseOrdersItemsTable WHERE PurchaseOrdersItemID_AutoNumber = " & Str(CurrentPurchaseOrdersItemID)
        JustExecuteMySelection()
        FillPurchaseOrdersItemsDataGridView()
    End Sub


    Private Sub ItemPurchseHistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ItemPurchseHistoryToolStripMenuItem.Click

    End Sub


    Private Sub ConfirmQuantitiesButton_Click(sender As Object, e As EventArgs) Handles EXITSAVEChangesButton.Click
        SaveChanges()
    End Sub
    Private Sub SaveChanges()
        If AChangeOccured() Then
            Dim xxmsgResult = MsgBox("Save Changes ?", MsgBoxStyle.YesNoCancel)
            If xxmsgResult = vbNo Then
                RequisitionDetailsGroupBox.Visible = False
                Exit Sub
            ElseIf xxmsgResult = MsgBoxResult.Cancel Then
                Exit Sub
            End If
        Else
            RequisitionDetailsGroupBox.Visible = False 'NO CHANGES
            Exit Sub
        End If
        If MsgBox("About to replace original information, Continue ?", MsgBoxStyle.YesNo) = vbNo Then
            Exit Sub
        End If
        Dim RecordFilter = " WHERE PurchaseOrdersItemID_AutoNumber = " & CurrentPurchaseOrdersItemID.ToString
        Dim SetCommand = " SET ProductPartID_LongInteger = " & CurrentProductPartId.ToString & "," &
                                  "POQty_Integer = " & Val(POItemQuantityTextBox.Text).ToString & "," &
                                  "Price_Currency = " & Val(POItemPriceTextBox.Text).ToString
        UpdateTable("PurchaseOrdersItemsTable", SetCommand, RecordFilter)
        RequisitionDetailsGroupBox.Visible = False
        FillPurchaseOrdersItemsDataGridView()
    End Sub
    Private Function AChangeOccured()



        '*******************************************************
        ' CHECK THIS THE TheseAreNotEqual ROUTINE WAS MODIFIED, WATCH PARAMETER pURPOSEOFENTRY





        If TheseAreNotEqual(SavedProductPartID, CurrentProductPartId, PurposeOfEntry) Then Return True

        If TheseAreNotEqual(POItemPriceTextBox.Text, NotNull(PurchaseOrdersItemsDataGridView.Item("Price_Currency", CurrentPurchaseOrdersItemsDataGridViewRow).Value), PurposeOfEntry) Then Return True
        If TheseAreNotEqual(POItemProductPartNoTextBox.Text, NotNull(PurchaseOrdersItemsDataGridView.Item("ProductsPartsOrderedTable.ManufacturerPartNo_ShortText30Fld", CurrentPurchaseOrdersItemsDataGridViewRow).Value), PurposeOfEntry) Then Return True
        If TheseAreNotEqual(POItemQuantityTextBox.Text, NotNull(PurchaseOrdersItemsDataGridView.Item("POQty_Integer", CurrentPurchaseOrdersItemsDataGridViewRow).Value), PurposeOfEntry) Then Return True
        If TheseAreNotEqual(POItemProductDescTextBox.Text, NotNull(PurchaseOrdersItemsDataGridView.Item("ProductsPartsOrderedTable.ManufacturerDescription_ShortText250", CurrentPurchaseOrdersItemsDataGridViewRow).Value), PurposeOfEntry) Then Return True
        Return False
    End Function

    Private Sub CopyProductButton_Click(sender As Object, e As EventArgs) Handles CopyProductButton.Click
        If MsgBox("Cancel Copying the Specified Product ?", MsgBoxStyle.YesNo) = vbYes Then
            Exit Sub
        End If
        CurrentProductPartId = PurchaseOrdersItemsDataGridView.Item("ProductsPartsRequestedTable.ProductsPartID_Autonumber", CurrentPurchaseOrdersItemsDataGridViewRow).Value
        POItemProductDescTextBox.Text = PurchaseOrdersItemsDataGridView.Item("ProductsPartsRequestedTable.ManufacturerDescription_ShortText250", CurrentPurchaseOrdersItemsDataGridViewRow).Value
        POItemProductPartNoTextBox.Text = PurchaseOrdersItemsDataGridView.Item("ProductsPartsRequestedTable.ManufacturerPartNo_ShortText30Fld", CurrentPurchaseOrdersItemsDataGridViewRow).Value
        POItemQuantityTextBox.Text = PurchaseOrdersItemsDataGridView.Item("RequisitionQuantity_Double", CurrentPurchaseOrdersItemsDataGridViewRow).Value
        POItemUnitTextBox.Text = PurchaseOrdersItemsDataGridView.Item("ProductsPartsRequestedTable.Unit_ShortText3", CurrentPurchaseOrdersItemsDataGridViewRow).Value

    End Sub
    Private Sub CalculatePOTotals()
        If PurchaseOrdersItemsRecordCount < 1 Then Exit Sub
        'CALCULATE ITEM TOTAL
        Dim xxComputedItemDiscount = 0
        Dim ItemTotalCost = 0
        Dim POTotalCost = 0
        For i = 0 To PurchaseOrdersItemsRecordCount - 1
            Dim xxItemQuantity = Val(NotNull(PurchaseOrdersItemsDataGridView.Item("POQty_Integer", CurrentPurchaseOrdersItemsDataGridViewRow).Value))
            Dim xxUnitPrice = Val(NotNull(PurchaseOrdersItemsDataGridView.Item("Price_Currency", CurrentPurchaseOrdersItemsDataGridViewRow).Value))
            Dim xxItemDiscount = Val(NotNull(PurchaseOrdersItemsDataGridView.Item("ItemDiscount_Integer", CurrentPurchaseOrdersItemsDataGridViewRow).Value))
            CurrentProductPartId = PurchaseOrdersItemsDataGridView.Item("ProductPartID_LongInteger", CurrentPurchaseOrdersItemsDataGridViewRow).Value
            xxComputedItemDiscount = (xxItemDiscount * 10 / 100) * (xxItemQuantity * xxUnitPrice)
            ItemTotalCost = (xxItemQuantity * xxUnitPrice) - xxComputedItemDiscount
            POTotalCost = POTotalCost + ItemTotalCost
        Next
        POTotalItemCostTextBox.Text = POTotalCost.ToString
        POTotalBeforeTaxTextBox.Text = POTotalCost.ToString - Val(NotNull(POLumpSumDiscountTextBox.Text))
        If Val(NotNull(PurchaseOrdersItemsDataGridView.Item("ItemDiscount_Integer", CurrentPurchaseOrdersItemsDataGridViewRow).Value)) = 0 Then
            POTaxAmountTextBox.Text = POTotalBeforeTaxTextBox.Text * 0.1
        End If
        '        xxPODiscount = (Val(NotNull(POTotalTextBox.Text)) * 10 / 100) * POTotalCost
        POTotalTextBox.Text = Val(NotNull(POTotalBeforeTaxTextBox.Text)) + Val(NotNull(POTaxAmountTextBox.Text)) + Val(NotNull(ShippingCostTextBox.Text))
        'CALCULATE TAX AND DISCOUNTS
    End Sub
    Private Sub PurchaseOrderDiscountTextBox_Leave(sender As Object, e As EventArgs) Handles POLumpSumDiscountTextBox.Leave
        If Not SavedPurchaseOrderDiscount = Val(POLumpSumDiscountTextBox.Text) Then CalculatePOTotals()
        '                           TotalCost * xxPercentage
        '  PerctageAmount         =    -----------------------
        '                                   100 
    End Sub
    Private Sub TaxAmountTextBox_Leave(sender As Object, e As EventArgs) Handles POTaxAmountTextBox.Leave
        If Val(POTaxAmountTextBox.Text) = 0 Then Exit Sub
        If SavedTaxAmount = Val(POTaxAmountTextBox.Text) Then Exit Sub
        CalculatePOTotals()
        If Not SavedTaxAmount = Val(POTaxAmountTextBox.Text) Then CalculatePOTotals()
        '                           TotalCost * (Percentage)
        '  perctage amount      = -----------------------
        '                               100
        'PerctageAmount * 100   = TotalCost * xxPercentage 
        'TotalCost * xxPercentage = PerctageAmount * 100   

        '                       = PerctageAmount * 100
        '  xxPercentage         =    -----------------------
        '                           TotalCost
        Dim TotalCost = Val(POTotalItemCostTextBox.Text)
        Dim PerctageAmount = Val(POTaxAmountTextBox.Text)

        POTotalTextBox.Text = TotalCost + PerctageAmount
        Dim xxPercentage = (100 * PerctageAmount) / TotalCost
        Dim RoundedPercentage = RoundUp(xxPercentage)
        '    TaxPercentageTextBox.Text = RoundedPercentage.ToString & "%"
    End Sub
    Private Sub SupplierNameTextBox_TextChanged(sender As Object, e As EventArgs) Handles SupplierNameTextBox.Leave
        If IsEmpty(SupplierNameTextBox.Text) Then
            SupplierNameTextBox.Text = "Search"
            CurrentSupplierID = -1
        End If
    End Sub

    Private Sub SpecificationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SpecificationsToolStripMenuItem.Click

    End Sub

    Private Sub RequisitionItemUnitTextBox_Leave(sender As Object, e As EventArgs) Handles RequisitionItemUnitTextBox.Leave
        RequisitionItemUnitTextBox.Text = RequisitionItemUnitTextBox.Text.ToUpper




        '*******************************************************
        ' CHECK THIS THE TheseAreNotEqual ROUTINE WAS MODIFIED, WATCH PARAMETER pURPOSEOFENTRY








        If TheseAreNotEqual(RequisitionItemUnitTextBox.Text, NotNull(PurchaseOrdersItemsDataGridView.Item("ProductsPartsRequestedTable.Unit_ShortText3", CurrentPurchaseOrdersItemsDataGridViewRow).Value), PurposeOfEntry) Then

        End If

    End Sub

    Private Sub SubmitForApprovalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SubmitForApprovalToolStripMenuItem.Click
        Dim ReadyForApproval = True
        For i = 0 To PurchaseOrdersItemsRecordCount - 1
            If IsEmpty(PurchaseOrdersItemsDataGridView.Item("POQty_Integer", i).Value) Then
                MsgBox(PurchaseOrdersItemsDataGridView.Item("ProductsPartsRequestedTable.ManufacturerPartNo_ShortText30Fld", i).Value & "has no quantity")
                ReadyForApproval = False
            End If
            If IsEmpty(PurchaseOrdersItemsDataGridView.Item("Price_Currency", i).Value) Then
                If MsgBox(PurchaseOrdersItemsDataGridView.Item("ProductsPartsRequestedTable.ManufacturerPartNo_ShortText30Fld", i).Value & "has no price, is this okay", MsgBoxStyle.YesNo) = vbNo Then
                    ReadyForApproval = False
                End If
            End If
        Next
        If ReadyForApproval Then
            If MsgBox("Submit for Approval ?", MsgBoxStyle.YesNo) = vbNo Then
                Exit Sub
            End If
        End If

        UpdatePOStatus(1)
        ApproveStripMenuItem.Visible = True
        SubmitForApprovalToolStripMenuItem.Visible = False
    End Sub
    Private Sub ApproveStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApproveStripMenuItem.Click
        If MsgBox("Shall we proceed for Spproval and execution of thi Purchase Order ?", MsgBoxStyle.YesNo) = vbNo Then
            Exit Sub
        End If
        UpdatePOStatus(2)
        ApproveStripMenuItem.Visible = False
    End Sub
    Private Sub UpdatePOStatus(PassedStatus)
        Dim RecordFilter = " WHERE PurchaseOrderID_AutoNumber = " & Str(CurrentPurchaseOrderID)
        Dim SetCommand = " SET PurchaseOrderStatusID_LongInteger = " & Str(GetStatusIdFor("PurchaseOrdersTable", "For Approval"))
        UpdateTable("PurchaseOrdersTable", SetCommand, RecordFilter)
        PurchaseOrderDetailsGroupBox.Enabled = False
        FillPurchaseOrdersDataGridView()
    End Sub

    Private Sub POItemProductDescTextBox_TextChanged(sender As Object, e As EventArgs) Handles POItemProductDescTextBox.Click
        If POItemProductDescTextBox.Text <> "" Then
            If MsgBox("Do you intend to replace the Product?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        ProductsPartsForm.PartNoToolStripTextBox.Text = "?"
        Tunnel1 = NotNull(PurchaseOrdersItemsDataGridView.Item("MasterCodeBookID_Autonumber", CurrentPurchaseOrdersItemsDataGridViewRow).Value)
        Tunnel2 = NotNull(PurchaseOrdersItemsDataGridView.Item("SystemDesc_ShortText100Fld", CurrentPurchaseOrdersItemsDataGridViewRow).Value)
        ProductsPartsForm.VehicleFilterToolStripTextBox.Text = CurrentVehicleString
        ShowCalledForm(Me, ProductsPartsForm)
    End Sub

    Private Sub CalculateTotalsButton_Click(sender As Object, e As EventArgs) Handles CalculateTotalsButton.Click
        CalculatePOTotals()
    End Sub
    Private Sub SetToDeliveryMode() ' this works with parts brought by customers
        DisablePurchaseOrderItemMenus()
        DisablePurchaseOrderMenus()
        DeliveredToolStripMenuItem.Visible = True
        SpecificationsToolStripMenuItem.Visible = False
        ItemPurchseHistoryToolStripMenuItem.Visible = False
        ViewToolStripMenuItem.Visible = False
        SavePurchaseOrderToolStripMenuItem.Visible = False
    End Sub

    Private Sub DeliveredToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeliveredToolStripMenuItem.Click
        UpdateDeliveredItems()
    End Sub
    Private Sub UpdateDeliveredItems()
        DoCommonHouseKeeping(Me, SavedCallingForm)
        Exit Sub
        If MsgBox("Have you Selected All Delivered Items ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        If MsgBox("Proceed Selecting the Items ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        Dim xxselected = 0
        For i = 0 To PurchaseOrdersItemsRecordCount - 1
            If Not PurchaseOrdersItemsDataGridView.Rows(i).Selected Then Continue For
            Dim xxPurchaseOrdersItemID = PurchaseOrdersItemsDataGridView.Item("PurchaseOrdersItemID_AutoNumber", CurrentPurchaseOrdersItemsDataGridViewRow).Value
            Dim FieldsToUpdate = " DeliveryItemID_AutoNumber "
            Dim FieldsData = xxPurchaseOrdersItemID.ToString
            Dim xxDummyID = InsertNewRecord("DeliveryItemsTable", FieldsToUpdate, FieldsData)
        Next


    End Sub
End Class