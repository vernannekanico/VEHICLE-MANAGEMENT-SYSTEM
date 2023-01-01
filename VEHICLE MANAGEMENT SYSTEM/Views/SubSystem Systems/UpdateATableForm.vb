Imports System.Data.SqlClient

Public Class UpdateATableForm
    Private CurrentPurchaseOrderItemID As Integer = -1
    Private CurrentPurchaseOrderItemsRow As Integer = -1
    Private PurchaseOrderItemsRecordCount As Integer = -1
    Private CurrentPurchaseOrderItemsNumber As String

    Private PurchaseOrderItemsFieldsToSelect = ""
    Private PurchaseOrderItemsSelectionFilter = ""
    Private PurchaseOrderItemsSelectionOrder = ""

    Private PurchaseOrderItemsDataGridViewAlreadyFormated = False
    Private SavedCallingForm As Form
    Private CurrentPurchaseOrderID = -1
    Private CurrentWorkOrderNumber_ShortText12 = ""

    Private Sub StartForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SavedCallingForm = CallingForm
        '       MsgBox("Do A BREAK here")
        FillPurchaseOrderItemsDataGridView()

    End Sub

    Private Sub FillPurchaseOrderItemsDataGridView()
        PurchaseOrderItemsFieldsToSelect =
"
SELECT WorkOrderPartsTable.WorkOrderPartID_AutoNumber, 
WorkOrdersTable.WorkOrderNumber_ShortText12, 
SuppliersTable.SupplierName_ShortText35, 
PurchaseOrdersItemsTable.PurchaseOrdersItemID_AutoNumber, 
PurchaseOrdersItemsTable.PurchaseOrderID_LongInteger, 
PurchaseOrdersTable.PurchaseOrderID_AutoNumber, 
PurchaseOrdersTable.WorkOrderNumber_Guide, WorkOrdersTable.ServiceDate_DateTime, OriginalExcelRecordTable.description, ProductsPartsTable.ManufacturerDescription_ShortText250, VehicleModels.VehicleModel, WorkOrdersTable.VehicleMilage_Integer, WorkOrdersTable.WorkOrderID_AutoNumber
FROM ((((((OriginalExcelRecordTable LEFT JOIN PurchaseOrdersItemsTable ON OriginalExcelRecordTable.OriginalID_AutoNumber = PurchaseOrdersItemsTable.OriginalID_LongInteger) RIGHT JOIN WorkOrderPartsTable ON OriginalExcelRecordTable.OriginalID_AutoNumber = WorkOrderPartsTable.OriginalID_LongInteger) LEFT JOIN WorkOrdersTable ON WorkOrderPartsTable.WorkOrderID_LongInteger = WorkOrdersTable.WorkOrderID_AutoNumber) LEFT JOIN PurchaseOrdersTable ON PurchaseOrdersItemsTable.PurchaseOrderID_LongInteger = PurchaseOrdersTable.PurchaseOrderID_AutoNumber) LEFT JOIN SuppliersTable ON WorkOrderPartsTable.SupplierID_LongInteger = SuppliersTable.SupplierID_AutoNumber) LEFT JOIN (ServicedVehiclesTable LEFT JOIN VehicleModels ON ServicedVehiclesTable.VehicleID_LongInteger = VehicleModels.VehicleID_AutoNumber) ON WorkOrdersTable.ServicedVehicleID_LongInteger = ServicedVehiclesTable.ServicedVehicleID_AutoNumber) LEFT JOIN ProductsPartsTable ON WorkOrderPartsTable.ProductPartID_LongInteger = ProductsPartsTable.ProductsPartID_Autonumber"
        PurchaseOrderItemsSelectionOrder = " ORDER BY WorkOrdersTable.WorkOrderNumber_ShortText12 ASC, SupplierName_ShortText35 ASC  "
        PurchaseOrderItemsSelectionFilter = " " 'WHERE trim(len(WorkOrdersTable.WorkOrderNumber_ShortText12)) > 0 "

        MySelection = PurchaseOrderItemsFieldsToSelect & PurchaseOrderItemsSelectionFilter & PurchaseOrderItemsSelectionOrder
        JustExecuteMySelection()
        PurchaseOrderItemsRecordCount = RecordCount
        PurchaseOrderItemsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        '     If Not PurchaseOrderItemsDataGridViewAlreadyFormated Then
        '    PurchaseOrderItemsDataGridViewAlreadyFormated = True
        '    '           FormatPurchaseOrderItemsDataGridView()
        '      End If
        Dim TotalRowsHeight = 20 * DataGridViewRowHeight
        PurchaseOrderItemsDataGridView.Width = Me.Width - 10
        PurchaseOrderItemsDataGridView.Height = (PurchaseOrderItemsDataGridView.ColumnHeadersHeight) + TotalRowsHeight
        PurchaseOrderItemsDataGridView.Visible = True
        PurchaseOrderItemsDataGridView.Top = BottomOf(MenuStrip2)
        PurchaseOrderItemsDataGridView.Left = 1
    End Sub

    Private Sub FormatPurchaseOrderItemsDataGridView()
        PurchaseOrderItemsDataGridViewAlreadyFormated = True
        PurchaseOrderItemsDataGridView.Width = 0
        For i = 0 To PurchaseOrderItemsDataGridView.Columns.GetColumnCount(0) - 1

            PurchaseOrderItemsDataGridView.Columns.Item(i).Visible = False
            Select Case PurchaseOrderItemsDataGridView.Columns.Item(i).Name
                Case "description"
                    PurchaseOrderItemsDataGridView.Columns.Item(i).HeaderText = "description"
                    PurchaseOrderItemsDataGridView.Columns.Item(i).Width = 300
                    PurchaseOrderItemsDataGridView.Columns.Item(i).Visible = True
                Case "SupplierName_ShortText35"
                    PurchaseOrderItemsDataGridView.Columns.Item(i).HeaderText = "SUPPLIER"
                    PurchaseOrderItemsDataGridView.Columns.Item(i).Width = 150
                    PurchaseOrderItemsDataGridView.Columns.Item(i).Visible = True
                Case "PurchaseOrderID_LongInteger"
                    PurchaseOrderItemsDataGridView.Columns.Item(i).HeaderText = "PurchaseOrderID_LongInteger"
                    PurchaseOrderItemsDataGridView.Columns.Item(i).Width = 120
                    PurchaseOrderItemsDataGridView.Columns.Item(i).Visible = True
                Case "PurchaseOrderID_AutoNumber"
                    PurchaseOrderItemsDataGridView.Columns.Item(i).HeaderText = "PurchaseOrderID_AutoNumber"
                    PurchaseOrderItemsDataGridView.Columns.Item(i).Width = 120
                    PurchaseOrderItemsDataGridView.Columns.Item(i).Visible = True

            End Select

            If PurchaseOrderItemsDataGridView.Columns.Item(i).Visible = True Then
                PurchaseOrderItemsDataGridView.Width = PurchaseOrderItemsDataGridView.Width + PurchaseOrderItemsDataGridView.Columns.Item(i).Width
            End If
        Next
    End Sub
    Private Sub ProductsPartsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles PurchaseOrderItemsDataGridView.RowEnter
        If e.RowIndex < 0 Then Exit Sub
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If PurchaseOrderItemsRecordCount = 0 Then Exit Sub

        CurrentPurchaseOrderItemsRow = e.RowIndex
        FillField(CurrentPurchaseOrderItemID, PurchaseOrderItemsDataGridView.Item("PurchaseOrdersItemID_AutoNumber", CurrentPurchaseOrderItemsRow).Value)
    End Sub

    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox("re-code")
    End Sub

    Private Sub RefreshDataGridViewButton_Click(sender As Object, e As EventArgs) Handles RefreshDataGridViewButton.Click
        FillPurchaseOrderItemsDataGridView()
    End Sub
End Class