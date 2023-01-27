Imports System.Data.SqlClient

Public Class DirectUpdateATableStandardForm
    Private CurrentWorkOrderRequestedPartID As Integer = -1
    Private CurrentWorkOrderRequestedPartsRow As Integer = -1
    Private WorkOrderRequestedPartsRecordCount As Integer = -1
    Private CurrentWorkOrderRequestedPartProductID = -1

    Private WorkOrderRequestedPartsFieldsToSelect = ""
    Private WorkOrderRequestedPartsSelectionFilter = ""

    Private CurrentProductPartID = -1
    Private CurrentWorkOrderItemProductID = -1
    Private CurrentProductsPartsPackingRelationID = -1
    Private WorkOrderRequestedPartsDataGridViewAlreadyFormated = False
    Private SavedCallingForm As Form

    Private Sub StartForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SavedCallingForm = CallingForm
        FillWorkOrderRequestedPartsDataGridView()

    End Sub

    Private Sub FillWorkOrderRequestedPartsDataGridView()
        MsgBox("Update This")
        Stop
        WorkOrderRequestedPartsFieldsToSelect =
"
SELECT 
WorkOrderRequestedPartsTable.WorkOrderRequestedPartID_AutoNumber, 
WorkOrderRequestedPartsTable.ProductPartID_LongInteger,
WorkOrderRequestedPartsTable.RequestedQuantity_Double,
ProductsPartsTable_1.ManufacturerDescription_ShortText250, 
ProductsPartsTable.ManufacturerDescription_ShortText250,
ProductsPartsPackingRelationsTable.ProductsPartsPackingRelationID_AutoNumber, 
ProductsPartsPackingRelationsTable.ProductPartID_LongInteger, 
ProductsPartsPackingRelationsTable.ProductPartsPackingID_LongInteger, 
ProductPartsPackingsTable.QuantityPerPack_Double,
ProductsPartsTable_1.Unit_ShortText3,
ProductPartsPackingsTable.UnitOfTheQuantity_ShortText3, 
ProductPartsPackingsTable.UnitOfThePacking_ShortText3
FROM (((WorkOrderRequestedPartsTable LEFT JOIN WorkOrderPartsTable ON WorkOrderRequestedPartsTable.WorkOrderPartID_LongInteger = WorkOrderPartsTable.WorkOrderPartID_AutoNumber) LEFT JOIN (ProductsPartsPackingRelationsTable LEFT JOIN ProductPartsPackingsTable ON ProductsPartsPackingRelationsTable.ProductPartsPackingID_LongInteger = ProductPartsPackingsTable.ProductPartsPackingID_Autonumber) ON WorkOrderRequestedPartsTable.ProductsPartsPackingRelationID_LongInteger = ProductsPartsPackingRelationsTable.ProductsPartsPackingRelationID_AutoNumber) LEFT JOIN ProductsPartsTable ON ProductsPartsPackingRelationsTable.ProductPartID_LongInteger = ProductsPartsTable.ProductsPartID_Autonumber) LEFT JOIN ProductsPartsTable AS ProductsPartsTable_1 ON WorkOrderRequestedPartsTable.ProductPartID_LongInteger = ProductsPartsTable_1.ProductsPartID_Autonumber
"
        WorkOrderRequestedPartsSelectionFilter = "" 'WHERE PurchaseOrderStatusID_LongInteger = 35 "

        MySelection = WorkOrderRequestedPartsFieldsToSelect
        JustExecuteMySelection()
        WorkOrderRequestedPartsRecordCount = RecordCount
        WorkOrderRequestedPartsTablesDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        If Not WorkOrderRequestedPartsDataGridViewAlreadyFormated Then
            WorkOrderRequestedPartsDataGridViewAlreadyFormated = True
            FormatWorkOrderRequestedPartsDataGridView()
        End If
        Dim TotalRowsHeight = 20 * DataGridViewRowHeight
        Me.Width = UpdateATableForm.MenuStrip2.Width - 2
        Me.Height = VehicleManagementSystemForm.Height - (UpdateATableForm.MenuStrip2.Top - UpdateATableForm.MenuStrip2.Height)
        Me.Left = 1
        WorkOrderRequestedPartsTablesDataGridView.Width = Me.Width - 10
        WorkOrderRequestedPartsTablesDataGridView.Height = (WorkOrderRequestedPartsTablesDataGridView.ColumnHeadersHeight) + TotalRowsHeight
        WorkOrderRequestedPartsTablesDataGridView.Width = WorkOrderRequestedPartsTablesDataGridView.Width - 2
        WorkOrderRequestedPartsTablesDataGridView.Visible = True
        WorkOrderRequestedPartsTablesDataGridView.Top = BottomOf(MenuStrip2)
        WorkOrderRequestedPartsTablesDataGridView.Left = 1
    End Sub

    Private Sub FormatWorkOrderRequestedPartsDataGridView()
        WorkOrderRequestedPartsDataGridViewAlreadyFormated = True
        WorkOrderRequestedPartsTablesDataGridView.Width = 0
        For i = 0 To WorkOrderRequestedPartsTablesDataGridView.Columns.GetColumnCount(0) - 1

            WorkOrderRequestedPartsTablesDataGridView.Columns.Item(i).Visible = False
            Select Case WorkOrderRequestedPartsTablesDataGridView.Columns.Item(i).Name
                Case "WorkOrderRequestedPartID_AutoNumber"
                    WorkOrderRequestedPartsTablesDataGridView.Columns.Item(i).HeaderText = "WR ID"
                    WorkOrderRequestedPartsTablesDataGridView.Columns.Item(i).Width = 80
                    WorkOrderRequestedPartsTablesDataGridView.Columns.Item(i).Visible = True
                Case "ProductsPartsTable_1.ManufacturerDescription_ShortText250"
                    WorkOrderRequestedPartsTablesDataGridView.Columns.Item(i).HeaderText = "WO PRODUCT"
                    WorkOrderRequestedPartsTablesDataGridView.Columns.Item(i).Width = 250
                    WorkOrderRequestedPartsTablesDataGridView.Columns.Item(i).Visible = True
                Case "RequestedQuantity_Double"
                    WorkOrderRequestedPartsTablesDataGridView.Columns.Item(i).HeaderText = "req qty"
                    WorkOrderRequestedPartsTablesDataGridView.Columns.Item(i).Width = 70
                    WorkOrderRequestedPartsTablesDataGridView.Columns.Item(i).Visible = True
                Case "ProductsPartsPackingRelationID_AutoNumber"
                    WorkOrderRequestedPartsTablesDataGridView.Columns.Item(i).HeaderText = "REL ID"
                    WorkOrderRequestedPartsTablesDataGridView.Columns.Item(i).Width = 70
                    WorkOrderRequestedPartsTablesDataGridView.Columns.Item(i).Visible = True
                Case "WorkOrderRequestedPartsTable.ProductPartID_LongInteger"
                    WorkOrderRequestedPartsTablesDataGridView.Columns.Item(i).HeaderText = "REQ PROD ID"
                    WorkOrderRequestedPartsTablesDataGridView.Columns.Item(i).Width = 70
                    WorkOrderRequestedPartsTablesDataGridView.Columns.Item(i).Visible = True
                Case "ProductPartsPackingID_LongInteger"
                    WorkOrderRequestedPartsTablesDataGridView.Columns.Item(i).HeaderText = "REL PKNG ID"
                    WorkOrderRequestedPartsTablesDataGridView.Columns.Item(i).Width = 70
                    WorkOrderRequestedPartsTablesDataGridView.Columns.Item(i).Visible = True
                Case "ProductsPartsTable.ManufacturerDescription_ShortText250"
                    WorkOrderRequestedPartsTablesDataGridView.Columns.Item(i).HeaderText = "REL PRODUCT"
                    WorkOrderRequestedPartsTablesDataGridView.Columns.Item(i).Width = 250
                    WorkOrderRequestedPartsTablesDataGridView.Columns.Item(i).Visible = True
                Case "Unit_ShortText3"
                    WorkOrderRequestedPartsTablesDataGridView.Columns.Item(i).HeaderText = "WO UNIT"
                    WorkOrderRequestedPartsTablesDataGridView.Columns.Item(i).Width = 70
                    WorkOrderRequestedPartsTablesDataGridView.Columns.Item(i).Visible = True
                Case "QuantityPerPack_Double"
                    WorkOrderRequestedPartsTablesDataGridView.Columns.Item(i).HeaderText = "QTY"
                    WorkOrderRequestedPartsTablesDataGridView.Columns.Item(i).Width = 70
                    WorkOrderRequestedPartsTablesDataGridView.Columns.Item(i).Visible = True
                Case "UnitOfTheQuantity_ShortText3"
                    WorkOrderRequestedPartsTablesDataGridView.Columns.Item(i).HeaderText = "QTY UNIT"
                    WorkOrderRequestedPartsTablesDataGridView.Columns.Item(i).Width = 70
                    WorkOrderRequestedPartsTablesDataGridView.Columns.Item(i).Visible = True
                Case "UnitOfThePacking_ShortText3"
                    WorkOrderRequestedPartsTablesDataGridView.Columns.Item(i).HeaderText = "PKG UNIT"
                    WorkOrderRequestedPartsTablesDataGridView.Columns.Item(i).Width = 70
                    WorkOrderRequestedPartsTablesDataGridView.Columns.Item(i).Visible = True
            End Select

            If WorkOrderRequestedPartsTablesDataGridView.Columns.Item(i).Visible = True Then
                WorkOrderRequestedPartsTablesDataGridView.Width = WorkOrderRequestedPartsTablesDataGridView.Width + WorkOrderRequestedPartsTablesDataGridView.Columns.Item(i).Width
            End If
        Next
    End Sub
    Private Sub WorkOrderRequestedPartsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles WorkOrderRequestedPartsTablesDataGridView.RowEnter
        If e.RowIndex < 0 Then Exit Sub
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If WorkOrderRequestedPartsRecordCount = 0 Then Exit Sub
        CurrentWorkOrderRequestedPartsRow = e.RowIndex

        FillField(CurrentWorkOrderRequestedPartID, WorkOrderRequestedPartsTablesDataGridView.Item("WorkOrderRequestedPartID_AutoNumber", CurrentWorkOrderRequestedPartsRow).Value)
        FillField(CurrentWorkOrderRequestedPartProductID, WorkOrderRequestedPartsTablesDataGridView.Item("WorkOrderRequestedPartsTable.ProductPartID_LongInteger", CurrentWorkOrderRequestedPartsRow).Value)
        FillField(CurrentProductsPartsPackingRelationID, WorkOrderRequestedPartsTablesDataGridView.Item("ProductsPartsPackingRelationID_AutoNumber", CurrentWorkOrderRequestedPartsRow).Value)
        FillField(CurrentProductPartID, WorkOrderRequestedPartsTablesDataGridView.Item("WorkOrderRequestedPartsTable.ProductPartID_LongInteger", CurrentWorkOrderRequestedPartsRow).Value)
    End Sub

    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub




    Private Sub SaveNewWordButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        FillField(CurrentWorkOrderRequestedPartID, WorkOrderRequestedPartsTablesDataGridView.Item("PurchaseOrdersItemID_AutoNumber", CurrentWorkOrderRequestedPartsRow).Value)

        If CurrentWorkOrderRequestedPartProductID = -1 Then
            UpdatePurchaseOrdersItemsTable()
        End If
        If CurrentWorkOrderItemProductID = -1 Then
            UpdatePurchaseOrdersItemsTable()
        End If
        AddAProductdGroupBox.Visible = False
    End Sub

    Private Sub UpdatePurchaseOrdersItemsTable()
        Dim RecordFilter = "WHERE PurchaseOrdersItemID_AutoNumber = " & CurrentWorkOrderRequestedPartID
        Dim SetCommand = "SET ProductPartID_LongInteger =  " & CurrentProductPartID
        UpdateTable("PurchaseOrdersItemsTable", SetCommand, RecordFilter)
        FillWorkOrderRequestedPartsDataGridView()
    End Sub
    Private Sub UpdateWorkOrderRequestedPartsTable()
        Dim RecordFilter = "WHERE WorkOrderRequestedPartID_AutoNumber = " & CurrentWorkOrderRequestedPartID
        Dim SetCommand = "SET ProductsPartsPackingRelationID_LongInteger =  " & CurrentProductsPartsPackingRelationID
        UpdateTable("WorkOrderRequestedPartsTable", SetCommand, RecordFilter)
        FillWorkOrderRequestedPartsDataGridView()
    End Sub
    Private Sub CancelNewWordButton_Click(sender As Object, e As EventArgs) Handles CancelButton.Click
        AddAProductdGroupBox.Hide()
    End Sub

    Private Sub UpdateATableForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        If Me.Enabled = False Then Exit Sub
        CallingForm = SavedCallingForm
        ' GET RETURNED DATA HERE

        Select Case Tunnel1
            Case "Tunnel2IsProductsPartsPackingRelationID"
                CurrentProductsPartsPackingRelationID = Tunnel2
                UpdateWorkOrderRequestedPartsTable()
        End Select
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        If IsNotEmpty(CurrentProductPartID) Then
            If MsgBox("Do you intend to replace the Packing?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        Tunnel1 = "Tunnel2IsProductPartID"
        Tunnel2 = CurrentProductPartID
        FillField(Tunnel3, WorkOrderRequestedPartsTablesDataGridView.Item("ProductsPartsTable_1.ManufacturerDescription_ShortText250", CurrentWorkOrderRequestedPartsRow).Value)
        ShowCalledForm(Me, ProductPartsPackingRelationsForm)
    End Sub
    Private Sub GlobalUpdateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GlobalUpdateToolStripMenuItem.Click
        'THIS ROUTINE WORKS FOR MASS UPDATE
        Exit Sub
        For i = 0 To WorkOrderRequestedPartsRecordCount - 1
            Dim CurrentWorkOrderRequestedPartStatusID_LongInteger = -1
            FillField(CurrentWorkOrderRequestedPartID, WorkOrderRequestedPartsTablesDataGridView.Item("PurchaseOrdersItemID_AutoNumber", i).Value)
            Dim CurrentPurchaseOrderDate_ShortDate = WorkOrderRequestedPartsTablesDataGridView.Item("PurchaseOrderDate_ShortDate", i).Value
            If IsEmpty(CurrentPurchaseOrderDate_ShortDate) Then
                Continue For
            End If
            Dim RecordFilter = "WHERE PurchaseOrdersItemID_AutoNumber = " & CurrentWorkOrderRequestedPartID
            Dim SetCommand = "SET PurchaseOrdersItemStatusID_LongInteger = 127 "
            UpdateTable("PurchaseOrdersItemsTable", SetCommand, RecordFilter)
        Next
        FillWorkOrderRequestedPartsDataGridView()
    End Sub
    Private Sub RefreshViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshViewToolStripMenuItem.Click
        FillWorkOrderRequestedPartsDataGridView()
    End Sub
    Private Sub DeleteThisWorkOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteThisWorkOrderToolStripMenuItem.Click
        Stop
        Exit Sub
        MySelection = " DELETE FROM WorkOrderPartsTable WHERE WorkOrderPartID_AutoNumber =  " & CurrentWorkOrderItemProductID
        JustExecuteMySelection()
        MySelection = " DELETE FROM WorkOrderPartsTable WHERE WorkOrderPartID_AutoNumber =  " & CurrentWorkOrderItemProductID
        JustExecuteMySelection()
        Dim SavedFilter = WorkOrderRequestedPartsSelectionFilter
        WorkOrderRequestedPartsSelectionFilter = WorkOrderRequestedPartsSelectionFilter & " AND WorkOrderRequestedPartID_Autonumber => " & CurrentProductPartID
        FillWorkOrderRequestedPartsDataGridView()
        WorkOrderRequestedPartsSelectionFilter = SavedFilter
    End Sub
End Class