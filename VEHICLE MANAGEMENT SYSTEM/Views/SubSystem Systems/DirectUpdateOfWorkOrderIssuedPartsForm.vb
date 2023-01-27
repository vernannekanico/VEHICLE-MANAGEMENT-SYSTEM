Public Class DirectUpdateOfWorkOrderIssuedPartsForm
    Private WorkOrderIssuedPartsRecordCount As Integer = -1
    Private WorkOrderIssuedPartsSelectionOrder = ""
    Private WorkOrderIssuedPartsFieldsToSelect = ""
    Private CurrentWorkOrderIssuedPartID As Integer = -1
    Private CurrentWorkOrderIssuedPartsRow As Integer = -1
    Private CurrentWorkOrderIssuedPartProductID = -1
    Private WorkOrderIssuedPartsSelectionFilter = ""

    Private CurrentProductPartID = -1
    Private CurrentProductsPartsPackingRelationID = -1
    Private WorkOrderIssuedPartsDataGridViewAlreadyFormated = False
    Private SavedCallingForm As Form

    Private Sub StartForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SavedCallingForm = CallingForm
        FillWorkOrderIssuedPartsDataGridView()

    End Sub

    Private Sub FillWorkOrderIssuedPartsDataGridView()

        WorkOrderIssuedPartsSelectionOrder = " ORDER BY ProductInIssuedTable.ManufacturerDescription_ShortText250 desc "
        WorkOrderIssuedPartsFieldsToSelect =
"
SELECT 
WorkOrderIssuedPartsTable.WorkOrderIssuedPartID_AutoNumber, 
WorkOrderIssuedPartsTable.ProductPartID_LongInteger, 
ProductInIssuedTable.ManufacturerDescription_ShortText250, 
ProductInPacingRelationTable.ManufacturerDescription_ShortText250, 
ProductsPartsPackingRelationsTable.ProductsPartsPackingRelationID_AutoNumber, 
ProductsPartsPackingRelationsTable.ProductPartID_LongInteger, 
ProductsPartsPackingRelationsTable.ProductPartsPackingID_LongInteger, 
ProductPartsPackingsTable.QuantityPerPack_Double, 
ProductInIssuedTable.Unit_ShortText3, 
ProductPartsPackingsTable.UnitOfTheQuantity_ShortText3, 
ProductPartsPackingsTable.UnitOfThePacking_ShortText3,
WorkOrderIssuedPartsTable.IssuedQuantity_Double
FROM (((WorkOrderIssuedPartsTable LEFT JOIN WorkOrderPartsTable ON WorkOrderIssuedPartsTable.WorkOrderPartID_LongInteger = WorkOrderPartsTable.WorkOrderPartID_AutoNumber) LEFT JOIN (ProductsPartsPackingRelationsTable LEFT JOIN ProductPartsPackingsTable ON ProductsPartsPackingRelationsTable.ProductPartsPackingID_LongInteger = ProductPartsPackingsTable.ProductPartsPackingID_Autonumber) ON WorkOrderIssuedPartsTable.ProductsPartsPackingRelationID_LongInteger = ProductsPartsPackingRelationsTable.ProductsPartsPackingRelationID_AutoNumber) LEFT JOIN ProductsPartsTable AS ProductInPacingRelationTable ON ProductsPartsPackingRelationsTable.ProductPartID_LongInteger = ProductInPacingRelationTable.ProductsPartID_Autonumber) LEFT JOIN ProductsPartsTable AS ProductInIssuedTable ON WorkOrderIssuedPartsTable.ProductPartID_LongInteger = ProductInIssuedTable.ProductsPartID_Autonumber
"
        MySelection = WorkOrderIssuedPartsFieldsToSelect & WorkOrderIssuedPartsSelectionFilter & WorkOrderIssuedPartsSelectionOrder

        JustExecuteMySelection()
        WorkOrderIssuedPartsRecordCount = RecordCount
        WorkOrderIssuedPartsTablesDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        If Not WorkOrderIssuedPartsDataGridViewAlreadyFormated Then
            WorkOrderIssuedPartsDataGridViewAlreadyFormated = True
            FormatWorkOrderIssuedPartsDataGridView()
        End If
        Dim TotalRowsHeight = 20 * DataGridViewRowHeight
        Me.Width = UpdateATableForm.MenuStrip2.Width - 2
        Me.Height = VehicleManagementSystemForm.Height - (UpdateATableForm.MenuStrip2.Top - UpdateATableForm.MenuStrip2.Height)
        Me.Left = 1
        WorkOrderIssuedPartsTablesDataGridView.Width = Me.Width - 10
        WorkOrderIssuedPartsTablesDataGridView.Height = (WorkOrderIssuedPartsTablesDataGridView.ColumnHeadersHeight) + TotalRowsHeight
        WorkOrderIssuedPartsTablesDataGridView.Width = WorkOrderIssuedPartsTablesDataGridView.Width - 2
        WorkOrderIssuedPartsTablesDataGridView.Visible = True
        WorkOrderIssuedPartsTablesDataGridView.Top = BottomOf(MenuStrip2)
        WorkOrderIssuedPartsTablesDataGridView.Left = 1
    End Sub

    Private Sub FormatWorkOrderIssuedPartsDataGridView()
        WorkOrderIssuedPartsDataGridViewAlreadyFormated = True
        WorkOrderIssuedPartsTablesDataGridView.Width = 0
        For i = 0 To WorkOrderIssuedPartsTablesDataGridView.Columns.GetColumnCount(0) - 1

            WorkOrderIssuedPartsTablesDataGridView.Columns.Item(i).Visible = False
            Select Case WorkOrderIssuedPartsTablesDataGridView.Columns.Item(i).Name
                Case "WorkOrderIssuedPartID_AutoNumber"
                    WorkOrderIssuedPartsTablesDataGridView.Columns.Item(i).HeaderText = "Iss ID"
                    WorkOrderIssuedPartsTablesDataGridView.Columns.Item(i).Width = 80
                    WorkOrderIssuedPartsTablesDataGridView.Columns.Item(i).Visible = True
                Case "ProductInIssuedTable.ManufacturerDescription_ShortText250"
                    WorkOrderIssuedPartsTablesDataGridView.Columns.Item(i).HeaderText = "Iss PRODUCT"
                    WorkOrderIssuedPartsTablesDataGridView.Columns.Item(i).Width = 250
                    WorkOrderIssuedPartsTablesDataGridView.Columns.Item(i).Visible = True
                Case "IssuedQuantity_Double"
                    WorkOrderIssuedPartsTablesDataGridView.Columns.Item(i).HeaderText = "req qty"
                    WorkOrderIssuedPartsTablesDataGridView.Columns.Item(i).Width = 70
                    WorkOrderIssuedPartsTablesDataGridView.Columns.Item(i).Visible = True
                Case "ProductsPartsPackingRelationID_AutoNumber"
                    WorkOrderIssuedPartsTablesDataGridView.Columns.Item(i).HeaderText = "REL ID"
                    WorkOrderIssuedPartsTablesDataGridView.Columns.Item(i).Width = 70
                    WorkOrderIssuedPartsTablesDataGridView.Columns.Item(i).Visible = True
                Case "WorkOrderIssuedPartsTable.ProductPartID_LongInteger"
                    WorkOrderIssuedPartsTablesDataGridView.Columns.Item(i).HeaderText = "REQ PROD ID"
                    WorkOrderIssuedPartsTablesDataGridView.Columns.Item(i).Width = 70
                    WorkOrderIssuedPartsTablesDataGridView.Columns.Item(i).Visible = True
                Case "ProductPartsPackingID_LongInteger"
                    WorkOrderIssuedPartsTablesDataGridView.Columns.Item(i).HeaderText = "REL PKNG ID"
                    WorkOrderIssuedPartsTablesDataGridView.Columns.Item(i).Width = 70
                    WorkOrderIssuedPartsTablesDataGridView.Columns.Item(i).Visible = True
                Case "ProductInPacingRelationTable.ManufacturerDescription_ShortText250"
                    WorkOrderIssuedPartsTablesDataGridView.Columns.Item(i).HeaderText = "REL PRODUCT"
                    WorkOrderIssuedPartsTablesDataGridView.Columns.Item(i).Width = 250
                    WorkOrderIssuedPartsTablesDataGridView.Columns.Item(i).Visible = True
                Case "Unit_ShortText3"
                    WorkOrderIssuedPartsTablesDataGridView.Columns.Item(i).HeaderText = "Iss UNIT"
                    WorkOrderIssuedPartsTablesDataGridView.Columns.Item(i).Width = 70
                    WorkOrderIssuedPartsTablesDataGridView.Columns.Item(i).Visible = True
                Case "QuantityPerPack_Double"
                    WorkOrderIssuedPartsTablesDataGridView.Columns.Item(i).HeaderText = "QTY"
                    WorkOrderIssuedPartsTablesDataGridView.Columns.Item(i).Width = 70
                    WorkOrderIssuedPartsTablesDataGridView.Columns.Item(i).Visible = True
                Case "UnitOfTheQuantity_ShortText3"
                    WorkOrderIssuedPartsTablesDataGridView.Columns.Item(i).HeaderText = "QTY UNIT"
                    WorkOrderIssuedPartsTablesDataGridView.Columns.Item(i).Width = 70
                    WorkOrderIssuedPartsTablesDataGridView.Columns.Item(i).Visible = True
                Case "UnitOfThePacking_ShortText3"
                    WorkOrderIssuedPartsTablesDataGridView.Columns.Item(i).HeaderText = "PKG UNIT"
                    WorkOrderIssuedPartsTablesDataGridView.Columns.Item(i).Width = 70
                    WorkOrderIssuedPartsTablesDataGridView.Columns.Item(i).Visible = True
            End Select

            If WorkOrderIssuedPartsTablesDataGridView.Columns.Item(i).Visible = True Then
                WorkOrderIssuedPartsTablesDataGridView.Width = WorkOrderIssuedPartsTablesDataGridView.Width + WorkOrderIssuedPartsTablesDataGridView.Columns.Item(i).Width
            End If
        Next
    End Sub
    Private Sub WorkOrderIssuedPartsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles WorkOrderIssuedPartsTablesDataGridView.RowEnter
        If e.RowIndex < 0 Then Exit Sub
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If WorkOrderIssuedPartsRecordCount = 0 Then Exit Sub
        CurrentWorkOrderIssuedPartsRow = e.RowIndex

        FillField(CurrentWorkOrderIssuedPartID, WorkOrderIssuedPartsTablesDataGridView.Item("WorkOrderIssuedPartID_AutoNumber", CurrentWorkOrderIssuedPartsRow).Value)
        FillField(CurrentWorkOrderIssuedPartProductID, WorkOrderIssuedPartsTablesDataGridView.Item("WorkOrderIssuedPartsTable.ProductPartID_LongInteger", CurrentWorkOrderIssuedPartsRow).Value)
        FillField(CurrentProductsPartsPackingRelationID, WorkOrderIssuedPartsTablesDataGridView.Item("ProductsPartsPackingRelationID_AutoNumber", CurrentWorkOrderIssuedPartsRow).Value)
    End Sub

    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub

    Private Sub UpdateWorkOrderIssuedPartsTable()
        Dim RecordFilter = "WHERE WorkOrderIssuedPartsTable.ProductPartID_LongInteger = " & CurrentWorkOrderIssuedPartProductID
        Dim SetCommand = "SET ProductsPartsPackingRelationID_LongInteger =  " & CurrentProductsPartsPackingRelationID
        UpdateTable("WorkOrderIssuedPartsTable", SetCommand, RecordFilter)
        FillWorkOrderIssuedPartsDataGridView()
    End Sub

    Private Sub UpdateATableForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        If Me.Enabled = False Then Exit Sub
        CallingForm = SavedCallingForm
        ' GET RETURNED DATA HERE

        Select Case Tunnel1
            Case "Tunnel2IsProductsPartsPackingRelationID"
                CurrentProductsPartsPackingRelationID = Tunnel2
                UpdateWorkOrderIssuedPartsTable()
        End Select
    End Sub


    Private Sub UpdateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdatePackingToolStripMenuItem.Click
        If IsNotEmpty(CurrentProductPartID) Then
            If MsgBox("Do you intend to replace the Packing?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        Tunnel1 = "Tunnel2IsProductPartID"
        Tunnel2 = CurrentWorkOrderIssuedPartProductID
        FillField(Tunnel3, WorkOrderIssuedPartsTablesDataGridView.Item("ProductInIssuedTable.ManufacturerDescription_ShortText250", CurrentWorkOrderIssuedPartsRow).Value)
        ShowCalledForm(Me, ProductPartsPackingRelationsForm)
    End Sub

    Private Sub RefreshViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshViewToolStripMenuItem.Click
        FillWorkOrderIssuedPartsDataGridView()
    End Sub

    Private Sub GlobalUpdateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GlobalUpdateToolStripMenuItem.Click
        'THIS ROUTINE WORKS FOR MASS UPDATE
        WorkOrderIssuedPartsSelectionFilter = " WHERE ProductInIssuedTable.Unit_ShortText3 = " & InQuotes("NO") &
                                        " OR ProductInIssuedTable.Unit_ShortText3 = " & InQuotes("PC")
        FillWorkOrderIssuedPartsDataGridView()
        For i = 0 To WorkOrderIssuedPartsRecordCount - 1
            FillField(CurrentWorkOrderIssuedPartID, WorkOrderIssuedPartsTablesDataGridView.Item("WorkOrderIssuedPartID_AutoNumber", i).Value)
            FillField(CurrentWorkOrderIssuedPartProductID, WorkOrderIssuedPartsTablesDataGridView.Item("WorkOrderIssuedPartsTable.ProductPartID_LongInteger", i).Value)
            FillField(CurrentProductsPartsPackingRelationID, WorkOrderIssuedPartsTablesDataGridView.Item("ProductsPartsPackingRelationID_AutoNumber", i).Value)

            If IsNotEmpty(CurrentProductsPartsPackingRelationID) Then
                Continue For
            End If
            MySelection = " SELECT * FROM ProductsPartsPackingRelationsTable  
                            WHERE ProductPartsPackingID_LongInteger = 37 AND 
                                  ProductPartID_LongInteger = " & CurrentWorkOrderIssuedPartProductID.ToString
            JustExecuteMySelection()
            If RecordCount = 0 Then
                Dim FieldsToUpdate = " ProductPartsPackingID_LongInteger, " &
                              " ProductPartID_LongInteger "
                Dim FieldsData = 37.ToString & ", " &
                         CurrentWorkOrderIssuedPartProductID.ToString

                CurrentProductsPartsPackingRelationID = InsertNewRecord("ProductsPartsPackingRelationsTable", FieldsToUpdate, FieldsData)
                If IsNotEmpty(CurrentProductsPartsPackingRelationID) Then
                    Dim RecordFilter = "WHERE WorkOrderIssuedPartID_AutoNumber = " & CurrentWorkOrderIssuedPartID
                    Dim SetCommand = "SET ProductsPartsPackingRelationID_LongInteger = " & CurrentProductsPartsPackingRelationID.ToString
                    UpdateTable("WorkOrderIssuedPartsTable", SetCommand, RecordFilter)
                Else
                    MsgBox("Unsuccesful creation of record for WorkOrderIssuedPartsTable")
                    Stop
                End If
            End If
        Next
        FillWorkOrderIssuedPartsDataGridView()
    End Sub

    Private Sub DeleteThisIssuedItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteThisIssuedItemToolStripMenuItem.Click
        Dim CurrentSortKey = ""
        FillField(CurrentSortKey, WorkOrderIssuedPartsTablesDataGridView.Item("ProductInIssuedTable.ManufacturerDescription_ShortText250", CurrentWorkOrderIssuedPartsRow).Value)
        MySelection = " DELETE FROM ProductsPartsPackingRelationsTable WHERE ProductsPartsPackingRelationID_AutoNumber =  " & CurrentProductsPartsPackingRelationID
        JustExecuteMySelection()

        MySelection = " DELETE FROM WorkOrderIssuedPartsTable WHERE WorkOrderIssuedPartID_AutoNumber =  " & CurrentWorkOrderIssuedPartID
        JustExecuteMySelection()
        ' DISPLAY THE RECORDS STARTING FROM THE RECORD WHOSE ORDER IF ANY OR THE RECORD ID > AND
        ' IF THERE ARE OTHER FILTERS THEN APPEND TO THE NEW FILLTER
        ' SINCE DISPLAY IS SORTED BY DESCRIPTION DESC THEN FILTER SHOULD BE LESS (<) ProductInIssuedTable.ManufacturerDescription_ShortText250
        WorkOrderIssuedPartsSelectionFilter = " WHERE ProductInIssuedTable.ManufacturerDescription_ShortText250 <= " & InQuotes(CurrentSortKey)
        FillWorkOrderIssuedPartsDataGridView()
    End Sub
End Class