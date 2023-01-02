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
    Private CurrentWorkOrderNumber_ShortText12 = ""

    Private Sub StartForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SavedCallingForm = CallingForm
        '       MsgBox("Do A BREAK here")
        FillPurchaseOrderItemsDataGridView()

    End Sub

    Private Sub FillPurchaseOrderItemsDataGridView()
        PurchaseOrderItemsFieldsToSelect =
"
SELECT 
PurchaseOrdersItemsTable.PurchaseOrdersItemID_AutoNumber, 
PurchaseOrdersItemsTable.PurchaseOrdersItemStatusID_LongInteger,
PurchaseOrdersTable.PurchaseOrderStatusID_LongInteger, 
PurchaseOrdersTable.PurchaseOrderDate_ShortDate
FROM PurchaseOrdersItemsTable LEFT JOIN PurchaseOrdersTable ON PurchaseOrdersItemsTable.PurchaseOrderID_LongInteger = PurchaseOrdersTable.PurchaseOrderID_AutoNumber
"
        PurchaseOrderItemsSelectionOrder = "" 'ORDER BY last_service_date ASC "
        PurchaseOrderItemsSelectionFilter = " WHERE PurchaseOrderStatusID_LongInteger = 35 "

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

        For i = 0 To PurchaseOrderItemsRecordCount - 1
            Dim CurrentPurchaseOrderItemStatusID_LongInteger = -1
            FillField(CurrentPurchaseOrderItemID, PurchaseOrderItemsDataGridView.Item("PurchaseOrdersItemID_AutoNumber", i).Value)
            Dim CurrentPurchaseOrderItemDate_ShortDate = PurchaseOrderItemsDataGridView.Item("PurchaseOrdersItemStatusID_LongIntegerr", i).Value
            CurrentPurchaseOrderItemID = PurchaseOrderItemsDataGridView.Item("PurchaseOrdersItemID_AutoNumber", i).Value
            Dim RecordFilter = "WHERE PurchaseOrdersItemID_AutoNumber = " & CurrentPurchaseOrderItemID
            Dim SetCommand = "SET PurchaseOrdersItemStatusID_LongInteger = 127, 
                                  PurchaseOrderItemDate_ShortDate = " & InQuotes(CurrentPurchaseOrderItemDate_ShortDate)
            UpdateTable("PurchaseOrderItemsTable", SetCommand, RecordFilter)
        Next
    End Sub

    Private Sub RefreshDataGridViewButton_Click(sender As Object, e As EventArgs) Handles RefreshDataGridViewButton.Click
        FillPurchaseOrderItemsDataGridView()
    End Sub
End Class