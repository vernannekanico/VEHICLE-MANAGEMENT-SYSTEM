Public Class PurchasedItemsForm
    Private PurchasedItemsFieldsToSelect = ""
    Private PurchasedItemsSelectionFilter = ""
    Private PurchasedItemsSelectionOrder = ""
    Private CurrentPurchasedItemsRow As Integer = -1
    Private PurchasedItemsRecordCount As Integer = -1
    Private CurrentPurchasedItemID = -1
    Private CurrentPurchasedItemStatus = ""
    Private PurchasedItemsDataGridViewAlreadyFormated = False

    Private SavedCallingForm As Form

    Private Sub PurchasedItemForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SavedCallingForm = CallingForm
        FillPurchasedItemsDataGridView()

    End Sub
    Private Sub FillPurchasedItemsDataGridView()

        PurchasedItemsSelectionOrder = " ORDER BY PurchasedItemID_AutoNumber DESC "
        PurchasedItemsFieldsToSelect =
" 
SELECT PurchaseOrdersItemsTable.PurchaseOrdersItemID_AutoNumber,
ProductsPartsOrderedTable.ManufacturerDescription_ShortText250,
ProductsPartsOrderedTable.ManufacturerPartNo_ShortText30Fld,
PurchaseOrdersItemsTable.POQty_Integer, 
PurchaseOrdersItemsTable.ItemDiscount_Integer, 
PurchaseOrdersItemsTable.Price_Currency,
PackagePricesTable.PackagePrice_Double,
ProductsPartsOrderedTable.Unit_ShortText3,
PurchaseOrdersItemsTable.PurchaseOrdersItemStatusID_LongInteger, 
PurchaseOrdersTable.PurchaseOrderID_AutoNumber,
PurchaseOrdersTable.PurchaseOrderRevision_Integer, 
BrandsOrderedTable.BrandName_ShortText20, 
VehicleDescription.VehicleDescription,
PurchaseOrdersItemsTable.DeliveryMode_Byte
FROM ((((((PurchaseOrdersItemsTable LEFT JOIN PurchaseOrdersTable ON PurchaseOrdersItemsTable.PurchaseOrderID_LongInteger = PurchaseOrdersTable.PurchaseOrderID_AutoNumber) LEFT JOIN ProductsPartsTable AS ProductsPartsOrderedTable ON PurchaseOrdersItemsTable.ProductPartID_LongInteger = ProductsPartsOrderedTable.ProductsPartID_Autonumber) LEFT JOIN BrandsTable AS BrandsOrderedTable ON ProductsPartsOrderedTable.BrandID_LongInteger = BrandsOrderedTable.BrandID_Autonumber) LEFT JOIN ((PartsRequisitionsItemsTable LEFT JOIN PartsRequisitionsTable ON PartsRequisitionsItemsTable.PartsRequisitionID_LongInteger = PartsRequisitionsTable.PartsRequisitionID_AutoNumber) LEFT JOIN VehicleDescription ON PartsRequisitionsTable.VehicleID_LongInteger = VehicleDescription.VehicleID_AutoNumber) ON PurchaseOrdersItemsTable.PartsRequisitionsItemID_LongInteger = PartsRequisitionsItemsTable.PartsRequisitionID_LongInteger) LEFT JOIN PackagePricesTable ON PurchaseOrdersItemsTable.PurchaseOrdersItemID_AutoNumber = PackagePricesTable.PackagePriceID_LongInteger) LEFT JOIN MasterCodeBookTable ON ProductsPartsOrderedTable.MasterCodeBookID_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) LEFT JOIN StatusesTable ON PurchaseOrdersItemsTable.PurchaseOrdersItemStatusID_LongInteger = StatusesTable.StatusID_Autonumber
  "

        MySelection = PurchasedItemsFieldsToSelect '& PurchasedItemsSelectionFilter & PurchasedItemsSelectionOrder

        JustExecuteMySelection()
        PurchasedItemsRecordCount = RecordCount

        PurchasedItemsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If PurchasedItemsRecordCount = 0 Then
            CurrentPurchasedItemID = -1
        End If


        If Not PurchasedItemsDataGridViewAlreadyFormated Then
            FormatPurchasedItemsDataGridView()
            SetFormWidthAndGroupBoxLeft()
        End If

        SetGroupBoxHeight(27, PurchasedItemsRecordCount, PurchasedItemsGroupBox, PurchasedItemsDataGridView)

        Me.Top = VehicleManagementSystemForm.VehicleManagementMenuStrip.Top + VehicleManagementSystemForm.VehicleManagementMenuStrip.Height + 20
        Me.Left = VehicleManagementSystemForm.Left
        Me.Height = VehicleManagementSystemForm.Height - Me.Top
        PurchasedItemsGroupBox.Top = SearchToolStrip.Top + SearchToolStrip.Height + 5

    End Sub
    Private Sub FormatPurchasedItemsDataGridView()
        PurchasedItemsDataGridViewAlreadyFormated = True
        PurchasedItemsGroupBox.Width = 0
        For i = 0 To PurchasedItemsDataGridView.Columns.GetColumnCount(0) - 1

            PurchasedItemsDataGridView.Columns.Item(i).Visible = False
            Select Case PurchasedItemsDataGridView.Columns.Item(i).Name
                Case "PurchaseOrderID_AutoNumber"
                    PurchasedItemsDataGridView.Columns.Item(i).HeaderText = "PO Number"
                    PurchasedItemsDataGridView.Columns.Item(i).Width = 70
                    PurchasedItemsDataGridView.Columns.Item(i).Visible = True
                Case "PurchaseOrderRevision_Integer"
                    PurchasedItemsDataGridView.Columns.Item(i).HeaderText = "PO Number Rev"
                    PurchasedItemsDataGridView.Columns.Item(i).Width = 70
                    PurchasedItemsDataGridView.Columns.Item(i).Visible = True
                Case "ManufacturerPartNo_ShortText30Fld"
                    PurchasedItemsDataGridView.Columns.Item(i).HeaderText = "Manufac Part #"
                    PurchasedItemsDataGridView.Columns.Item(i).Width = 130
                    PurchasedItemsDataGridView.Columns.Item(i).Visible = True
                Case "ManufacturerDescription_ShortText250"
                    PurchasedItemsDataGridView.Columns.Item(i).HeaderText = "Manufac Description"
                    PurchasedItemsDataGridView.Columns.Item(i).Width = 350
                    PurchasedItemsDataGridView.Columns.Item(i).Visible = True
                Case "POQty_Integer"
                    PurchasedItemsDataGridView.Columns.Item(i).HeaderText = "Qty"
                    PurchasedItemsDataGridView.Columns.Item(i).Width = 50
                    PurchasedItemsDataGridView.Columns.Item(i).Visible = True
                Case "Unit_ShortText3"
                    PurchasedItemsDataGridView.Columns.Item(i).HeaderText = "Unit"
                    PurchasedItemsDataGridView.Columns.Item(i).Width = 50
                    PurchasedItemsDataGridView.Columns.Item(i).Visible = True
                Case "Price_Currency"
                    PurchasedItemsDataGridView.Columns.Item(i).HeaderText = "Price"
                    PurchasedItemsDataGridView.Columns.Item(i).Width = 60
                    PurchasedItemsDataGridView.Columns.Item(i).Visible = True
                Case "ItemDiscount_Integer"
                    PurchasedItemsDataGridView.Columns.Item(i).HeaderText = "Disc %"
                    PurchasedItemsDataGridView.Columns.Item(i).Width = 50
                    PurchasedItemsDataGridView.Columns.Item(i).Visible = True
                Case "BrandName_ShortText20"
                    PurchasedItemsDataGridView.Columns.Item(i).HeaderText = "Brand"
                    PurchasedItemsDataGridView.Columns.Item(i).Width = 120
                    PurchasedItemsDataGridView.Columns.Item(i).Visible = True
                Case "DeliveryMode_Byte"
                    PurchasedItemsDataGridView.Columns.Item(i).HeaderText = "Delivery Mode"
                    PurchasedItemsDataGridView.Columns.Item(i).Width = 120
                    PurchasedItemsDataGridView.Columns.Item(i).Visible = True
                Case "VehicleDescription"
                    PurchasedItemsDataGridView.Columns.Item(i).HeaderText = " Vehicle Model"
                    PurchasedItemsDataGridView.Columns.Item(i).Width = 250
                    PurchasedItemsDataGridView.Columns.Item(i).Visible = True
                Case "PackagePrice_Double"
                    PurchasedItemsDataGridView.Columns.Item(i).HeaderText = "Package Price"
                    PurchasedItemsDataGridView.Columns.Item(i).Width = 150
                    PurchasedItemsDataGridView.Columns.Item(i).Visible = True

            End Select

            If PurchasedItemsDataGridView.Columns.Item(i).Visible = True Then
                PurchasedItemsGroupBox.Width = PurchasedItemsGroupBox.Width + PurchasedItemsDataGridView.Columns.Item(i).Width
            End If
        Next
        If PurchasedItemsGroupBox.Width > VehicleManagementSystemForm.Width Then
            PurchasedItemsGroupBox.Width = VehicleManagementSystemForm.Width - 4
        Else
            HorizontalCenter(PurchasedItemsGroupBox, Me)
        End If
    End Sub
    Private Sub PurchasedItemsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles PurchasedItemsDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If PurchasedItemsRecordCount = 0 Then Exit Sub

        CurrentPurchasedItemsRow = e.RowIndex
        CurrentPurchasedItemID = PurchasedItemsDataGridView.Item("PurchaseOrdersItemID_AutoNumber", CurrentPurchasedItemsRow).Value

    End Sub
    Private Sub SetFormWidthAndGroupBoxLeft()
        Dim LargestWidth = 0
        'note for multiple pyramidal datagrid
        For i = 1 To 4
            '           If WorkOrdersGroupBox.Width > LargestWidth Then
            '          LargestWidth = WorkOrdersGroupBox.Width
            '            ElseIf WorkOrderConcernsGroupBox.Width > LargestWidth Then
            '            LargestWidth = WorkOrderConcernsGroupBox.Width
            '         ElseIf WorkOrderConcernJobsGroupBox.Width > LargestWidth Then
            '           LargestWidth = WorkOrderConcernJobsGroupBox.Width
            '           ElseIf WorkOrderPartsPerJobGroupBox.Width > LargestWidth Then
            '           LargestWidth = WorkOrderPartsPerJobGroupBox.Width
            '            End If
        Next
        LargestWidth = PurchasedItemsGroupBox.Width

        If LargestWidth > VehicleManagementSystemForm.Width Then
            Me.Width = VehicleManagementSystemForm.Width - 4
        Else
            Me.Width = LargestWidth + 4
        End If

        HorizontalCenter(Me, VehicleManagementSystemForm)
        PurchasedItemsGroupBox.Left = (Me.Width - PurchasedItemsGroupBox.Width) / 2

    End Sub

    Private Sub ReturnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnToolStripMenuItem.Click
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub

End Class