Imports System.Data.SqlClient

Public Class UpdateATableForm
    Private CurrentPurchaseOrderItemID As Integer = -1
    Private CurrentPurchaseOrderItemsRow As Integer = -1
    Private PurchaseOrderItemsRecordCount As Integer = -1
    Private CurrentPurchaseOrderItemsNumber As String
    Private CurrentPurchaseOrderItemProductID = -1

    Private PurchaseOrderItemsFieldsToSelect = ""
    Private PurchaseOrderItemsSelectionFilter = ""
    Private PurchaseOrderItemsSelectionOrder = ""
    Private CurrentProductPartID = -1
    Private CurrentWorkOrderItemProductID = -1
    Private CurrentWorkOrderItemID = -1
    Private PurchaseOrderItemsDataGridViewAlreadyFormated = False
    Private SavedCallingForm As Form
    Private CurrentWorkOrderNumber_ShortText12 = ""

    Private Sub StartForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SavedCallingForm = CallingForm
        '       MsgBox("Do A BREAK here")
        FillPurchaseOrderItemsDataGridView()

    End Sub

    Private Sub FillPurchaseOrderItemsDataGridView()
        PurchaseOrderItemsFieldsToSelect =
"
SELECT OriginalExcelRecordTable.OriginalID_AutoNumber, 
OriginalExcelRecordTable.last_service_date, 
WorkOrdersTable.WorkOrderID_AutoNumber, 
WorkOrderPartsTable.WorkOrderPartID_AutoNumber, 
OriginalExcelRecordTable.RecordType, PurchaseOrdersItemsTable.PurchaseOrdersItemID_AutoNumber,
WorkOrdersTable.ServiceDate_DateTime, 
WorkOrderPartsTable.ProductPartID_LongInteger, 
PurchaseOrdersItemsTable.ProductPartID_LongInteger, 
OriginalExcelRecordTable.description, 
ProductsPartsTable.ManufacturerDescription_ShortText250, 
ProductsPartsTable_1.ManufacturerDescription_ShortText250, 
OriginalExcelRecordTable.SupplierCode, 
OriginalExcelRecordTable.QTY, 
WorkOrderPartsTable.Quantity_Integer, 
OriginalExcelRecordTable.UnitName, 
WorkOrderPartsTable.Unit_ShortText3, 
OriginalExcelRecordTable.price, WorkOrderPartsTable.Price_Currency, OriginalExcelRecordTable.brand, 
OriginalExcelRecordTable.SUPPLIER, VehicleModels.VehicleModel, 
WorkOrderPartsTable.intAmountPaid_Currency, OriginalExcelRecordTable.ServiceProvider
FROM ((((WorkOrderPartsTable RIGHT JOIN OriginalExcelRecordTable ON WorkOrderPartsTable.OriginalID_LongInteger = OriginalExcelRecordTable.OriginalID_AutoNumber) LEFT JOIN ProductsPartsTable ON WorkOrderPartsTable.ProductPartID_LongInteger = ProductsPartsTable.ProductsPartID_Autonumber) LEFT JOIN ((WorkOrdersTable LEFT JOIN ServicedVehiclesTable ON WorkOrdersTable.ServicedVehicleID_LongInteger = ServicedVehiclesTable.ServicedVehicleID_AutoNumber) LEFT JOIN VehicleModels ON ServicedVehiclesTable.VehicleID_LongInteger = VehicleModels.VehicleID_AutoNumber) ON WorkOrderPartsTable.WorkOrderID_LongInteger = WorkOrdersTable.WorkOrderID_AutoNumber) LEFT JOIN PurchaseOrdersItemsTable ON OriginalExcelRecordTable.OriginalID_AutoNumber = PurchaseOrdersItemsTable.OriginalID_LongInteger) LEFT JOIN ProductsPartsTable AS ProductsPartsTable_1 ON PurchaseOrdersItemsTable.ProductPartID_LongInteger = ProductsPartsTable_1.ProductsPartID_Autonumber
"
        PurchaseOrderItemsSelectionOrder = "ORDER BY last_service_date ASC,WorkOrderID_AutoNumber "
        PurchaseOrderItemsSelectionFilter = "" 'WHERE PurchaseOrderStatusID_LongInteger = 35 "

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
        FillField(CurrentWorkOrderItemID, PurchaseOrderItemsDataGridView.Item("WorkOrderPartID_AutoNumber", CurrentPurchaseOrderItemsRow).Value)
        FillField(CurrentPurchaseOrderItemProductID, PurchaseOrderItemsDataGridView.Item("PurchaseOrdersItemID_AutoNumber", CurrentPurchaseOrderItemsRow).Value)
        FillField(CurrentWorkOrderItemProductID, PurchaseOrderItemsDataGridView.Item("WorkOrderPartsTable.ProductPartID_LongInteger", CurrentPurchaseOrderItemsRow).Value)
        FillField(CurrentPurchaseOrderItemProductID, PurchaseOrderItemsDataGridView.Item("PurchaseOrdersItemsTable.ProductPartID_LongInteger", CurrentPurchaseOrderItemsRow).Value)
    End Sub

    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'THIS ROUTINE WORKS FOR MASS UPDATE
        Exit Sub
        For i = 0 To PurchaseOrderItemsRecordCount - 1
            Dim CurrentPurchaseOrderItemStatusID_LongInteger = -1
            FillField(CurrentPurchaseOrderItemID, PurchaseOrderItemsDataGridView.Item("PurchaseOrdersItemID_AutoNumber", i).Value)
            Dim CurrentPurchaseOrderDate_ShortDate = PurchaseOrderItemsDataGridView.Item("PurchaseOrderDate_ShortDate", i).Value
            If IsEmpty(CurrentPurchaseOrderDate_ShortDate) Then
                Continue For
            End If
            Dim RecordFilter = "WHERE PurchaseOrdersItemID_AutoNumber = " & CurrentPurchaseOrderItemID
            Dim SetCommand = "SET PurchaseOrdersItemStatusID_LongInteger = 127 "
            UpdateTable("PurchaseOrdersItemsTable", SetCommand, RecordFilter)
        Next
        FillPurchaseOrderItemsDataGridView()
    End Sub

    Private Sub RefreshDataGridViewButton_Click(sender As Object, e As EventArgs) Handles RefreshDataGridViewButton.Click
        FillPurchaseOrderItemsDataGridView()
    End Sub

    Private Sub AAProductButton_Click(sender As Object, e As EventArgs) Handles EditProductButton.Click
        If ProductDescTextBox.Text <> "" Then
            If MsgBox("Do you intend to replace the Product?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        If CurrentPurchaseOrderItemProductID <> CurrentWorkOrderItemProductID Then
            If IsEmpty(CurrentPurchaseOrderItemProductID) Then
                UpdatePurchaseOrdersItemsTable()
            ElseIf IsEmpty(CurrentWorkOrderItemProductID) Then
                UpdateWorkOrdersItemsTable()
            End If
        Else
            AddAProductdGroupBox.Visible = True
            ProductsPartsForm.CurrentVehicleID = CurrentVehicleID
            ProductsPartsForm.VehicleModelSearchTextBox.Text = CurrentVehicleString
            ShowCalledForm(Me, ProductsPartsForm)
        End If
    End Sub

    Private Sub SaveNewWordButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        FillField(CurrentPurchaseOrderItemID, PurchaseOrderItemsDataGridView.Item("PurchaseOrdersItemID_AutoNumber", CurrentPurchaseOrderItemsRow).Value)

        If CurrentPurchaseOrderItemProductID = -1 Then
            UpdatePurchaseOrdersItemsTable()
        End If
        If CurrentWorkOrderItemProductID = -1 Then
            UpdatePurchaseOrdersItemsTable()
        End If
        AddAProductdGroupBox.Visible = False
    End Sub

    Private Sub UpdatePurchaseOrdersItemsTable()
        Dim RecordFilter = "WHERE PurchaseOrdersItemID_AutoNumber = " & CurrentPurchaseOrderItemID
        Dim SetCommand = "SET ProductPartID_LongInteger =  " & CurrentProductPartID
        UpdateTable("PurchaseOrdersItemsTable", SetCommand, RecordFilter)
        FillPurchaseOrderItemsDataGridView()
    End Sub
    Private Sub UpdateWorkOrdersItemsTable()
        Dim RecordFilter = "WHERE WorkOrderPartID_AutoNumber = " & CurrentWorkOrderItemID
        Dim SetCommand = "SET ProductPartID_LongInteger =  " & CurrentProductPartID
        UpdateTable("WorkOrderPartsTable", SetCommand, RecordFilter)
        FillPurchaseOrderItemsDataGridView()
    End Sub
    Private Sub CancelNewWordButton_Click(sender As Object, e As EventArgs) Handles CancelButton.Click
        AddAProductdGroupBox.Hide()
    End Sub

    Private Sub UpdateATableForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        If Me.Enabled = False Then Exit Sub
        CallingForm = SavedCallingForm
        ' GET RETURNED DATA HERE
        Select Case Tunnel1
            Case "Tunnel2IsProductPartID"
                CurrentProductPartID = Tunnel2
                ProductDescTextBox.Text = Tunnel3
            Case Else
                If AddAProductdGroupBox.Visible Then AddAProductdGroupBox.Visible = False
        End Select
    End Sub

    Private Sub DeleteThisJobButton_Click(sender As Object, e As EventArgs) Handles DeleteThisJobButton.Click
        MySelection = " DELETE FROM WorkOrderPartsTable WHERE WorkOrderPartID_AutoNumber =  " & CurrentWorkOrderItemProductID
        JustExecuteMySelection()
        MySelection = " DELETE FROM WorkOrderPartsTable WHERE WorkOrderPartID_AutoNumber =  " & CurrentWorkOrderItemProductID
        JustExecuteMySelection()
        Dim SavedFilter = PurchaseOrderItemsSelectionFilter
        PurchaseOrderItemsSelectionFilter = PurchaseOrderItemsSelectionFilter & " AND ProductsPartID_Autonumber => " & CurrentProductPartID
        FillPurchaseOrderItemsDataGridView()
        PurchaseOrderItemsSelectionFilter = SavedFilter
    End Sub
End Class