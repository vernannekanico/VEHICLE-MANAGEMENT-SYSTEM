Public Class InventoriesForm
    Private InventoriesFieldsToSelect = ""
    Private InventoriesSelectionFilter = ""
    Private InventoriesSelectionOrder = ""
    Private CurrentInventoriesRow As Integer = -1
    Private InventoriesRecordCount As Integer = -1
    Private CurrentInventoryHeaderID = -1
    Private InventoriesDataGridViewAlreadyFormated = False

    Private InventoryItemsFieldsToSelect = ""
    Private InventoryItemsSelectionFilter = ""
    Private InventoryItemsSelectionOrder = ""
    Private CurrentInventoryItemsRow As Integer = -1
    Private InventoryItemsRecordCount As Integer = -1
    Private CurrentInventoryItemID = -1
    Private InventoryItemsDataGridViewAlreadyFormated = False
    Private CurrentProductsPartsPackingRelationID = -1
    Private SavedCallingForm As Form
    Private CurrentlocationID = -1
    Private CurrentStockID = -1
    Private CurrentProductPartId = -1
    Private SavedLocation As String
    Private Property SaveMessage As String

    Private Sub InventoriesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SavedCallingForm = CallingForm
        InventoriesSelectionFilter = "WHERE InventoryHeaderID_AutoNumber - 1"
        FillInventoriesDataGridView()
        If InventoriesRecordCount = 0 Then
            InventoryItemsSelectionFilter = "WHERE InventoryHeaderID_LongInteger = -1 "
            InventoriesGroupBox.Visible = False
            InventoryItemsGroupBox.Top = BottomOf(SearchToolStrip)
            FillInventoryItemsDataGridView()
            VerticalCenter(InventoryItemsGroupBox, Me)
        Else
            InventoryItemsGroupBox.Top = BottomOf(InventoriesGroupBox)
            InventoryItemsGroupBox.Left = InventoriesGroupBox.Left + InventoriesGroupBox.Width
        End If
        InventoriesGroupBox.Top = BottomOf(SearchToolStrip)
        InventoriesGroupBox.Left = Me.Left
        HorizontalCenter(StockDetailsGroup, Me)
        VerticalCenter(StockDetailsGroup, Me)
        StockDetailsGroup.Visible = False
        RegisterInventoryToolStripMenuItem.Visible = False
        PrintInventoryToolStripMenuItem.Visible = False

    End Sub
    Private Sub FillInventoriesDataGridView()

        InventoriesSelectionOrder = " ORDER BY InventoryDate_ShortDate DESC"
        InventoriesFieldsToSelect =
" 
SELECT InventoryHeadersTable.InventoryHeaderID_AutoNumber, 
InventoryHeadersTable.InventoryDate_ShortDate, 
StatusesTable.StatusText_ShortText25, PersonnelFullName.PersonnelFullName
FROM (InventoryHeadersTable LEFT JOIN StatusesTable ON InventoryHeadersTable.InventoryStatus_Integer = StatusesTable.StatusID_Autonumber) LEFT JOIN PersonnelFullName ON InventoryHeadersTable.StoreKeeperID_LongInteger = PersonnelFullName.PersonnelID_AutoNumber
"
        MySelection = InventoriesFieldsToSelect & InventoriesSelectionFilter & InventoriesSelectionOrder

        JustExecuteMySelection()
        InventoriesRecordCount = RecordCount

        If InventoriesRecordCount = 0 Then
            CurrentInventoryHeaderID = -1
        End If
        InventoriesDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable


        If Not InventoriesDataGridViewAlreadyFormated Then
            FormatInventoriesDataGridView()
        End If

        SetGroupBoxHeight(25, InventoriesRecordCount, InventoriesGroupBox, InventoriesDataGridView)

    End Sub
    Private Sub FormatInventoriesDataGridView()
        InventoriesDataGridViewAlreadyFormated = True
        InventoriesGroupBox.Width = 0
        For i = 0 To InventoriesDataGridView.Columns.GetColumnCount(0) - 1

            InventoriesDataGridView.Columns.Item(i).Visible = False
            Select Case InventoriesDataGridView.Columns.Item(i).Name
                Case "InventoryDate_ShortDate"
                    InventoriesDataGridView.Columns.Item(i).HeaderText = "Date"
                    InventoriesDataGridView.Columns.Item(i).Width = 100
                    InventoriesDataGridView.Columns.Item(i).Visible = True
                Case "StatusText_ShortText25"
                    InventoriesDataGridView.Columns.Item(i).HeaderText = "Status"
                    InventoriesDataGridView.Columns.Item(i).Width = 150
                    InventoriesDataGridView.Columns.Item(i).Visible = True
                Case "PersonnelFullName"
                    InventoriesDataGridView.Columns.Item(i).HeaderText = "Store Keeper"
                    InventoriesDataGridView.Columns.Item(i).Width = 200
                    InventoriesDataGridView.Columns.Item(i).Visible = True

            End Select

            If InventoriesDataGridView.Columns.Item(i).Visible = True Then
                InventoriesGroupBox.Width = InventoriesGroupBox.Width + InventoriesDataGridView.Columns.Item(i).Width
            End If
        Next
        If InventoriesGroupBox.Width > VehicleManagementSystemForm.Width Then
            InventoriesGroupBox.Width = VehicleManagementSystemForm.Width - 4
        End If
    End Sub
    Private Sub InventoriesDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles InventoriesDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If InventoriesRecordCount = 0 Then Exit Sub

        CurrentInventoriesRow = e.RowIndex
        CurrentInventoryHeaderID = InventoriesDataGridView.Item("ProductsPartID_Autonumber", CurrentInventoriesRow).Value

        If IsEmpty(InventoriesDataGridView.Item("PartsSpecificationID_AutoNumber", CurrentInventoriesRow).Value) Then
            MsgBox("Part/Product Specification is missing, " & vbLf & "need to update, " & vbLf &
                   "required to determine available quantities")
            InventoryItemsGroupBox.Visible = False
            Exit Sub
        End If
        InventoryItemsSelectionFilter = "WHERE PartsSpecificationID_AutoNumber = " &
                                                InventoriesDataGridView.Item("PartsSpecificationID_AutoNumber", CurrentInventoriesRow).Value
        FillInventoryItemsDataGridView()
        Dim AvailableQuantities = 0
        For i = 0 To InventoryItemsRecordCount - 1
            Dim QuantityPerPack = 0
            FillField(QuantityPerPack, InventoryItemsDataGridView.Item("QuantityPerPack_Double", CurrentInventoryItemsRow).Value)
            If QuantityPerPack = -1 Then QuantityPerPack = 0
            AvailableQuantities +=
             InventoryItemsDataGridView.Item("BulkBalanceQuantity_Double", CurrentInventoryItemsRow).Value +
             (InventoryItemsDataGridView.Item("QuantityInStock_Double", CurrentInventoryItemsRow).Value *
             QuantityPerPack)
        Next i
        Dim ThisProductMinimumQuantity = 0
        FillField(ThisProductMinimumQuantity, InventoryItemsDataGridView.Item("MinimumQuantityPerSpecs_Double", CurrentInventoryItemsRow).Value)
        InventoryItemsGroupBox.Text = "[" & InventoriesDataGridView.Item("SystemDesc_ShortText100Fld", CurrentInventoriesRow).Value & "] " &
                                                " [SPECIFICATION: " &
                                                InventoriesDataGridView.Item("PartSpecifications_ShortText255", CurrentInventoriesRow).Value & "] " &
                                                " [Available Quantities : " & AvailableQuantities.ToString & "] " &
                                                " [Minimum Quantity : " & ThisProductMinimumQuantity
    End Sub
    Private Sub FillInventoryItemsDataGridView()
        RegisterInventoryToolStripMenuItem.Visible = False
        PrintInventoryToolStripMenuItem.Visible = False
        InventoryItemsSelectionOrder = " ORDER BY LocationCode_ShortText11, PartSpecifications_ShortText255, SystemDesc_ShortText100Fld DESC "
        InventoryItemsFieldsToSelect = "
SELECT 
InventoryItemsTable.InventoryItemID_Autonumber,
InventoryHeadersTable.InventoryHeaderID_AutoNumber, 
StocksTable.StockID_Autonumber, 
ProductsPartsTable.ProductsPartID_Autonumber, 
StocksLocationsTable.StocksLocationID_AutoNumber, 
StocksLocationsTable.LocationCode_ShortText11, 
MasterCodeBookTable.SystemDesc_ShortText100Fld, 
PartsSpecificationsTable.PartSpecifications_ShortText255, 
ProductsPartsTable.ManufacturerPartNo_ShortText30Fld, 
ProductsPartsTable.ManufacturerDescription_ShortText250, 
StocksTable.QuantityInStock_Double, 
InventoryItemsTable.InventoryQtyInStock_Double, 
Packings.UnitOfThePacking_ShortText3, 
InventoryItemsTable.InventoryBulkBalanceQty_Double,
StocksTable.BulkBalanceQuantity_Double, 
Packings.UnitOfTheQuantity_ShortText3,
BrandsTable.BrandID_Autonumber, 
BrandsTable.BrandName_ShortText20, 
Packings.ProductsPartsPackingRelationID_AutoNumber, 
Packings.Packing
FROM (((InventoryItemsTable LEFT JOIN InventoryHeadersTable ON InventoryItemsTable.InventoryHeaderID_LongInteger = InventoryHeadersTable.InventoryHeaderID_AutoNumber) LEFT JOIN (((ProductsPartsTable LEFT JOIN MasterCodeBookTable ON ProductsPartsTable.MasterCodeBookID_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) LEFT JOIN PartsSpecificationsTable ON ProductsPartsTable.PartsSpecificationID_LongInteger = PartsSpecificationsTable.PartsSpecificationID_AutoNumber) LEFT JOIN BrandsTable ON ProductsPartsTable.BrandID_LongInteger = BrandsTable.BrandID_Autonumber) ON InventoryItemsTable.ProductPartID_LongInteger = ProductsPartsTable.ProductsPartID_Autonumber) LEFT JOIN (StocksTable LEFT JOIN StocksLocationsTable ON StocksTable.StocksLocationID_LongInteger = StocksLocationsTable.StocksLocationID_AutoNumber) ON ProductsPartsTable.ProductsPartID_Autonumber = StocksTable.ProductPartID_LongInteger) LEFT JOIN (ProductsPartsPackingRelationsTable LEFT JOIN Packings ON ProductsPartsPackingRelationsTable.ProductsPartsPackingRelationID_AutoNumber = Packings.ProductsPartsPackingRelationID_AutoNumber) ON InventoryItemsTable.ProductsPartsPackingRelationID_LongInteger = ProductsPartsPackingRelationsTable.ProductsPartsPackingRelationID_AutoNumber
"
        MySelection = InventoryItemsFieldsToSelect & InventoryItemsSelectionFilter & InventoryItemsSelectionOrder

        JustExecuteMySelection()
        InventoryItemsRecordCount = RecordCount

        InventoryItemsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable


        If Not InventoryItemsDataGridViewAlreadyFormated Then
            FormatInventoryItemsDataGridView()
        End If

        SetGroupBoxHeight(5, InventoryItemsRecordCount, InventoryItemsGroupBox, InventoryItemsDataGridView)

    End Sub
    Private Sub FormatInventoryItemsDataGridView()
        InventoryItemsDataGridViewAlreadyFormated = True
        InventoryItemsGroupBox.Width = 0
        For i = 0 To InventoryItemsDataGridView.Columns.GetColumnCount(0) - 1

            InventoryItemsDataGridView.Columns.Item(i).Visible = False
            Select Case InventoryItemsDataGridView.Columns.Item(i).Name
                Case "LocationCode_ShortText11"
                    InventoryItemsDataGridView.Columns.Item(i).HeaderText = "location"
                    InventoryItemsDataGridView.Columns.Item(i).Width = 120
                    InventoryItemsDataGridView.Columns.Item(i).Visible = True
                Case "SystemDesc_ShortText100Fld"
                    InventoryItemsDataGridView.Columns.Item(i).HeaderText = "Product"
                    InventoryItemsDataGridView.Columns.Item(i).Width = 350
                    InventoryItemsDataGridView.Columns.Item(i).Visible = True
                Case "ManufacturerPartNo_ShortText30Fld"
                    InventoryItemsDataGridView.Columns.Item(i).HeaderText = "Manufacturer Part no."
                    InventoryItemsDataGridView.Columns.Item(i).Width = 150
                    InventoryItemsDataGridView.Columns.Item(i).Visible = True
                Case "InventoryQtyInStock_Double"
                    InventoryItemsDataGridView.Columns.Item(i).HeaderText = "Qty in Stock"
                    InventoryItemsDataGridView.Columns.Item(i).Width = 70
                    InventoryItemsDataGridView.Columns.Item(i).Visible = True
                Case "UnitOfThePacking_ShortText3"
                    InventoryItemsDataGridView.Columns.Item(i).HeaderText = "Unit"
                    InventoryItemsDataGridView.Columns.Item(i).Width = 70
                    InventoryItemsDataGridView.Columns.Item(i).Visible = True
                Case "InventoryBulkBalanceQty_Double"
                    InventoryItemsDataGridView.Columns.Item(i).HeaderText = "Bulk balance"
                    InventoryItemsDataGridView.Columns.Item(i).Width = 70
                    InventoryItemsDataGridView.Columns.Item(i).Visible = True
                Case "UnitOfTheQuantity_ShortText3"
                    InventoryItemsDataGridView.Columns.Item(i).HeaderText = "Unit"
                    InventoryItemsDataGridView.Columns.Item(i).Width = 70
                    InventoryItemsDataGridView.Columns.Item(i).Visible = True
                Case "BrandName_ShortText20"
                    InventoryItemsDataGridView.Columns.Item(i).HeaderText = "Brand"
                    InventoryItemsDataGridView.Columns.Item(i).Width = 150
                    InventoryItemsDataGridView.Columns.Item(i).Visible = True
                Case "Location_ShortText10"
                    InventoryItemsDataGridView.Columns.Item(i).HeaderText = "Location"
                    InventoryItemsDataGridView.Columns.Item(i).Width = 70
                    InventoryItemsDataGridView.Columns.Item(i).Visible = True
                Case "ProductDescription_ShortText250"
                    InventoryItemsDataGridView.Columns.Item(i).HeaderText = "excel Desc"
                    InventoryItemsDataGridView.Columns.Item(i).Width = 400
                    InventoryItemsDataGridView.Columns.Item(i).Visible = True
                Case "Packing"
                    InventoryItemsDataGridView.Columns.Item(i).HeaderText = "Packing"
                    InventoryItemsDataGridView.Columns.Item(i).Width = 130
                    InventoryItemsDataGridView.Columns.Item(i).Visible = True

            End Select

            If InventoryItemsDataGridView.Columns.Item(i).Visible = True Then
                InventoryItemsGroupBox.Width = InventoryItemsGroupBox.Width + InventoryItemsDataGridView.Columns.Item(i).Width
            End If
        Next
        If InventoryItemsGroupBox.Width > VehicleManagementSystemForm.Width Then
            InventoryItemsGroupBox.Width = VehicleManagementSystemForm.Width - 4
        Else
            HorizontalCenter(InventoryItemsGroupBox, Me)
        End If
    End Sub
    Private Sub InventoryItemsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles InventoryItemsDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If InventoryItemsRecordCount = 0 Then Exit Sub
        CurrentInventoryItemsRow = e.RowIndex

        FillField(CurrentInventoryItemID, InventoryItemsDataGridView.Item("InventoryItemID_Autonumber", CurrentInventoryItemsRow).Value)
        FillField(CurrentInventoryHeaderID, InventoryItemsDataGridView.Item("InventoryHeaderID_Autonumber", CurrentInventoryItemsRow).Value)
        CurrentProductPartId = InventoryItemsDataGridView.Item("ProductsPartID_Autonumber", CurrentInventoryItemsRow).Value
        FillField(CurrentProductsPartsPackingRelationID, InventoryItemsDataGridView.Item("ProductsPartsPackingRelationID_AutoNumber", CurrentInventoryItemsRow).Value)
        FillField(CurrentlocationID, InventoryItemsDataGridView.Item("StocksLocationID_Autonumber", CurrentInventoryItemsRow).Value)
        FillField(CurrentStockID, InventoryItemsDataGridView.Item("StockID_AutoNumber", CurrentInventoryItemsRow).Value)
        If CurrentInventoryHeaderID = -1 Then
            RegisterInventoryToolStripMenuItem.Visible = True
            PrintInventoryToolStripMenuItem.Visible = True
        End If
    End Sub
    Private Sub EditProductToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditInventoryDetailsToolStripMenuItem.Click
        LoadProductDetails()
        StockDetailsGroup.Visible = True
        SetupEditMode()
    End Sub
    Private Sub StockDetailsGroup_VisibleChanged(sender As Object, e As EventArgs) Handles StockDetailsGroup.VisibleChanged
        If StockDetailsGroup.Visible Then
            SetupEditMode()
        Else
            SetupBrowseMode()
        End If
    End Sub
    Private Sub SetupEditMode()
        ViewInventoriesToolStripMenuItem.Visible = False
        AddInventoryToolStripMenuItem.Visible = False
        EditInventoryDetailsToolStripMenuItem.Visible = False
        DeleteInventoryToolStripMenuItem.Visible = False
        SaveInventoryDetailsToolStripMenuItem.Visible = True
        RegisterInventoryToolStripMenuItem.Visible = False
        PrintInventoryToolStripMenuItem.Visible = False
    End Sub
    Private Sub SetupBrowseMode()
        ViewInventoriesToolStripMenuItem.Visible = True
        AddInventoryToolStripMenuItem.Visible = True
        EditInventoryDetailsToolStripMenuItem.Visible = True
        DeleteInventoryToolStripMenuItem.Visible = True
        SaveInventoryDetailsToolStripMenuItem.Visible = False
    End Sub
    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteInventoryToolStripMenuItem.Click
        If IsDBNull(InventoriesDataGridView.Item("StocksQuantitiesPerSpecsID_AutoNumber", CurrentInventoriesRow).Value) Then
            If MsgBox("Continue delete this item?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                MySelection = " DELETE FROM StocksTable WHERE ProductPartID_LongInteger =  " '& 'CurrentProductPartID
                JustExecuteMySelection()
            End If
        Else
            MsgBox("This Product is listed as required to be always available on stock")
        End If

        FillInventoriesDataGridView()
    End Sub
    Private Sub LoadProductDetails()
        FillField(ProductSpecificationTextBox.Text, InventoryItemsDataGridView.Item("PartSpecifications_ShortText255", CurrentInventoryItemsRow).Value)
        FillField(SystemPartDescriptionTextBox.Text, InventoryItemsDataGridView.Item("SystemDesc_ShortText100Fld", CurrentInventoryItemsRow).Value)
        FillField(ManufacturerPartNoTextBox.Text, InventoryItemsDataGridView.Item("ManufacturerPartNo_ShortText30Fld", CurrentInventoryItemsRow).Value)
        FillField(ManufacturerPartDescTextBox.Text, InventoryItemsDataGridView.Item("ManufacturerDescription_ShortText250", CurrentInventoryItemsRow).Value)
        FillField(BrandNameTextBox.Text, InventoryItemsDataGridView.Item("BrandName_ShortText20", CurrentInventoryItemsRow).Value)
        FillField(UnitTextBox.Text, InventoryItemsDataGridView.Item("UnitOfThePacking_ShortText3", CurrentInventoryItemsRow).Value)
        FillField(QtyInBasicUnitTextBox.Text, InventoryItemsDataGridView.Item("InventoryQtyInStock_Double", CurrentInventoryItemsRow).Value)
        FillField(BulkBalanceTextBox.Text, InventoryItemsDataGridView.Item("InventoryBulkBalanceQty_Double", CurrentInventoryItemsRow).Value)
        FillField(LocationTextBox.Text, InventoryItemsDataGridView.Item("LocationCode_ShortText11", CurrentInventoryItemsRow).Value)
        FillField(PackingTextBox.Text, InventoryItemsDataGridView.Item("Packing", CurrentInventoryItemsRow).Value)
        PackingTextBox.Visible = True
        If PackingTextBox.Text = " /" Then
            PackingTextBox.Visible = False
            Label3.Visible = False
        End If
    End Sub
    Private Sub InventoriesForm_EnabledChanged(sender As Object, e As EventArgs) Handles MyBase.EnabledChanged
        If Me.Enabled = False Then Exit Sub
        CallingForm = SavedCallingForm

        Select Case Tunnel1
            Case "Tunnel2IsStocksLocationID"
                CurrentlocationID = Tunnel2
                Dim PreviousLocationID = -1
                FillField(PreviousLocationID, InventoryItemsDataGridView.Item("StocksLocationID_AutoNumber", CurrentInventoryItemsRow).Value)
                If TheseAreNotEqual(CurrentlocationID, PreviousLocationID) Then
                    If IsNotEmpty(PreviousLocationID) Then
                        If MsgBox("Location has been changed, " & vbCrLf & vbCrLf &
                                  "continue UPDATE the stocks record ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        Else
                            'RESTORE ORIGINAL LOCATION DISPLAYED
                            LocationTextBox.Text = InventoriesDataGridView.Item("LocationCode_ShortText11", CurrentInventoriesRow).Value
                            Exit Sub
                        End If
                    End If
                    UpdateStocksTable(1)
                    LocationTextBox.Text = Tunnel3
                    Dim SavedRow = CurrentInventoryItemsRow
                    FillInventoryItemsDataGridView()
                    InventoryItemsDataGridView.Rows(CurrentInventoryItemsRow).Selected = False
                    InventoryItemsDataGridView.Rows(SavedRow).Selected = True
                    CurrentInventoryItemsRow = SavedRow
                End If
            Case "Tunnel2IsProductPartID"
                CurrentProductPartId = Tunnel2
                StockDetailsGroup.Visible = True
                CurrentProductsPartsPackingRelationID = Tunnel4
            Case "Tunnel2IsProductsPartsPackingRelationID"
                CurrentProductsPartsPackingRelationID = Tunnel2
                If Val(BulkBalanceTextBox.Text) > 0 Then
                    BulkBalanceUnitTextBox.Text = Tunnel4
                End If
                If IsNotEmpty(Tunnel3) Then
                    PackingTextBox.Text = Tunnel3
                    PackingTextBox.Visible = True
                    Label3.Visible = True
                End If

        End Select
    End Sub
    Private Sub ReturnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnToolStripMenuItem.Click
        If StockDetailsGroup.Visible = True Then
            SaveMessage = "There are changes made, save your changes ?"
            SaveChanges()
            Exit Sub
        End If
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub
    Private Sub SaveProductToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveInventoryDetailsToolStripMenuItem.Click
        SaveMessage = "Continue saving the changes ?"
        'VALIDATE
        If Not AllEntriesOfThisStockInventoryDetailsAreValid() Then Exit Sub
        SaveChanges()
    End Sub
    Private Sub SaveChanges()
        'CHECK CHANGES REGISTER IF NEEDED
        ' Fields to possibly be updated here
        '   StocksTable.ProductPartID_LongInteger
        '   StocksTable.QuantityInStock_Double
        '   StocksTable.BulkBalanceQuantity_Double
        '   StocksTable.StocksLocationID_LongInteger

        If AChangeInThisStockInventoryDetailsOccurred() Then
            If Not AllEntriesOfThisStockInventoryDetailsAreValid() Then Exit Sub
            If MsgBox(SaveMessage, MsgBoxStyle.YesNo) = vbNo Then
                StockDetailsGroup.Visible = False
                Exit Sub
            End If
            RegisterDetailsOfThisStockInventoryChanges()
        End If

    End Sub

    Private Sub UpdateStocksTable(Mode As Integer)
        MySelection = "SELECT TOP 1  ProductPartID_LongInteger from StocksTable WHERE ProductPartID_LongInteger = " & CurrentProductPartId &
                        " AND ProductsPartsPackingRelationID_LongInteger = " & CurrentProductsPartsPackingRelationID
        JustExecuteMySelection()
        If RecordCount = 0 Then
            'Insert a new Stock record for this product
            CurrentStockID = InsertNewRecord("StocksTable", "ProductPartID_LongInteger", CurrentProductPartId.ToString)
        End If
        Dim SetCommand = ""
        Dim RecordFilter = ""
        Select Case Mode
            Case 1
                'update the location code' this occurs when  data in the location code is changed

                SetCommand = " SET StocksLocationID_LongInteger = " & CurrentlocationID.ToString
            Case 2
                'update the quantities  this occurs during batch update
                SetCommand = " SET QuantityInStock_Double = " & QtyInBasicUnitTextBox.Text & ", " &
                                "BulkBalanceQuantity_Double = " & BulkBalanceTextBox.Text
            Case Else
                Exit Sub
        End Select
        RecordFilter = " WHERE StockID_Autonumber = " & CurrentStockID
        UpdateTable("StocksTable", SetCommand, RecordFilter)

    End Sub

    Private Function AChangeInThisStockInventoryDetailsOccurred()
        '*******************************************************
        'Test 1st if a Part/Product is selected and this is the 1st entry in the list
        If CurrentProductPartId > 0 And CurrentInventoriesRow = -1 Then Return True
        ' THIS ROUTINE DETERMINES ALSO IF THE PURPOSE OF ENTRY = "ADD Or EDIT
        If TheseAreNotEqual(QtyInBasicUnitTextBox.Text, InventoriesDataGridView.Item("InventoryQtyInStock_Double", CurrentInventoriesRow).Value) Then Return True
        If TheseAreNotEqual(BulkBalanceTextBox.Text, InventoryItemsDataGridView.Item("InventoryBulkBalanceQty_Double", CurrentInventoryItemsRow).Value) Then Return True
        Return False
    End Function
    Private Function AllEntriesOfThisStockInventoryDetailsAreValid()
        If Trim(QtyInBasicUnitTextBox.Text) = "" And Trim(BulkBalanceTextBox.Text) = "" Then
            MsgBox("No quantities are entered ")
            QtyInBasicUnitTextBox.Select()
            Return False
        End If
        Return True
    End Function
    Private Sub RegisterDetailsOfThisStockInventoryChanges()
        SaveThisStockInventoryDetailsChanges()
        StockDetailsGroup.Visible = False
        FillInventoryItemsDataGridView()
    End Sub
    Private Sub SaveThisStockInventoryDetailsChanges()
        MySelection = " SELECT TOP 1 InventoryHeaderID_LongInteger FROM InventoryItemsTable WHERE InventoryHeaderID_LongInteger = " & CurrentInventoryHeaderID.ToString &
                            " AND ProductPartID_LongInteger = " & CurrentProductPartId.ToString
        JustExecuteMySelection()
        If RecordCount > 0 Then
            UpdateCurrentInventoryItemId()
        Else
            AddNewInventoryItem()
        End If
        FillInventoryItemsDataGridView()
    End Sub
    Private Sub UpdateCurrentInventoryItemId()
        Dim SetCommand = " SET InventoryQtyInStock_Double = " & QtyInBasicUnitTextBox.Text & ", " &
                         " InventoryBulkBalanceQty_Double = " & Val(BulkBalanceTextBox.Text) & ", " &
                         " ProductsPartsPackingRelationID_LongInteger = " & CurrentProductsPartsPackingRelationID.ToString
        Dim RecordFilter = " WHERE InventoryItemID_Autonumber = " & CurrentInventoryItemID.ToString

        UpdateTable("InventoryItemsTable", SetCommand, RecordFilter)
    End Sub
    Private Sub AddNewInventoryItem()
        Dim FieldsToUpdate = " ProductPartID_LongInteger, 
                                InventoryQtyInStock_Double, 
                                InventoryBulkBalanceQty_Double,
                                ProductsPartsPackingRelationID_LongInteger"

        Dim FieldsData = CurrentProductPartId.ToString & ", " &
                             Val(QtyInBasicUnitTextBox.Text).ToString & ", " &
                             Val(BulkBalanceTextBox.Text).ToString & ", " &
                            CurrentProductsPartsPackingRelationID.ToString()
        CurrentInventoryItemID = InsertNewRecord("InventoryItemsTable", FieldsToUpdate, FieldsData)
    End Sub
    Private Sub AddInventoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddInventoryToolStripMenuItem.Click
        ShowProductsForm()
    End Sub
    Private Sub ShowProductsForm()
        ShowCalledForm(Me, ProductsPartsForm)
    End Sub
    Private Sub ManufacturerPartDescTextBox_Click(sender As Object, e As EventArgs) Handles ManufacturerPartDescTextBox.Click
        If Not ManufacturerPartDescTextBox.Text = "" Then
            If MsgBox("Would you like to change the product ? ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        End If
        ShowProductsForm()
    End Sub

    Private Sub LocationTextBox_Click(sender As Object, e As EventArgs) Handles LocationTextBox.Click
        If Not LocationTextBox.Text = "" Then
            If MsgBox("Would you like to change the Location ? ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        End If
        SavedLocation = LocationTextBox.Text
        ShowCalledForm(Me, StockLocationsForm)
    End Sub

    Private Sub UnitTextBox_Click(sender As Object, e As EventArgs) Handles UnitTextBox.Click
        If IsNotEmpty(UnitTextBox.Text) Then
            If MsgBox("Would you like to replace the unit ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        End If
        Tunnel1 = "Tunnel2IsProductPartID"
        Tunnel2 = CurrentProductPartId
        ShowCalledForm(Me, ProductPartsPackingRelationsForm)
    End Sub
End Class