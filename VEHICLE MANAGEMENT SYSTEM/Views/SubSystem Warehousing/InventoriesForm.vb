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
    Private InventoryItemsDataGridViewAlreadyFormated = False

    Private SavedCallingForm As Form
    Private CurrentlocationID = -1
    Private CurrentStockID = -1
    Private CurrentProductPartId = -1
    Private CurrentInventoryHeaderID = -1
    Private Property SaveMessage As String

    Private Sub InventoriesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SavedCallingForm = CallingForm
        InventoriesSelectionFilter = "WHERE InventoryHeaderID_AutoNumber - 1"
        FillInventoriesDataGridView()
        InventoriesGroupBox.Top = BottomOf(SearchToolStrip)
        InventoryItemsGroupBox.Top = BottomOf(SearchToolStrip)
        InventoriesGroupBox.Left = Me.Left
        InventoryItemsGroupBox.Left = InventoriesGroupBox.Left + InventoriesGroupBox.Width
        HorizontalCenter(StockDetailsGroup, Me)
        VerticalCenter(StockDetailsGroup, Me)
        StockDetailsGroup.Visible = False
        RegisterInventoryToolStripMenuItem.Visible = False
        PrintToolStripMenuItem.Visible = False

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
        InventoryItemsSelectionOrder = " ORDER BY SystemDesc_ShortText100Fld DESC "

        InventoryItemsFieldsToSelect = " 
SELECT ProductsPartsTable.Selected, 
ProductsPartsTable.MasterCodeBookID_LongInteger, 
MasterCodeBookTable.SystemDesc_ShortText100Fld, 
PartsSpecificationsTable.PartsSpecificationID_AutoNumber, 
PartsSpecificationsTable.PartSpecifications_ShortText255, 
ProductsPartsTable.ManufacturerPartNo_ShortText30Fld, 
ProductsPartsTable.ManufacturerDescription_ShortText250, 
ProductsPartsTable.Unit_ShortText3, 
BrandsTable.BrandID_Autonumber, 
BrandsTable.BrandName_ShortText20, 
StocksTable.QuantityInStock_Double, 
StocksQuantitiesPerSpecsTable.MinimumQuantityPerSpecs_Double, 
StocksTable.StocksLocationID_LongInteger, 
StocksLocationsTable.LocationCode_ShortText11, 
ProductPartsPackingsTable.QuantityPerPack_Double, 
ProductPartsPackingsTable.UnitOfTheQuantity_ShortText3, 
ProductPartsPackingsTable.UnitOfThePacking_ShortText3, 
ProductsPartsTable.ProductsPartID_Autonumber, 
StocksQuantitiesPerSpecsTable.AvailableQuantityPerSpecs_Double, 
StocksTable.StockID_Autonumber, 
StocksLocationsTable.StocksLocationID_AutoNumber, 
StocksQuantitiesPerSpecsTable.StocksQuantitiesPerSpecsID_AutoNumber, 
InventoryItemsTable.InventoryHeaderID_LongInteger
FROM (InventoryItemsTable LEFT JOIN InventoryHeadersTable ON InventoryItemsTable.InventoryHeaderID_LongInteger = InventoryHeadersTable.InventoryHeaderID_AutoNumber) LEFT JOIN ((((StocksTable LEFT JOIN (((ProductsPartsTable LEFT JOIN MasterCodeBookTable ON ProductsPartsTable.MasterCodeBookID_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) LEFT JOIN PartsSpecificationsTable ON ProductsPartsTable.PartsSpecificationID_LongInteger = PartsSpecificationsTable.PartsSpecificationID_AutoNumber) LEFT JOIN BrandsTable ON ProductsPartsTable.BrandID_LongInteger = BrandsTable.BrandID_Autonumber) ON StocksTable.ProductPartID_LongInteger = ProductsPartsTable.ProductsPartID_Autonumber) LEFT JOIN StocksLocationsTable ON StocksTable.StocksLocationID_LongInteger = StocksLocationsTable.StocksLocationID_AutoNumber) LEFT JOIN ProductPartsPackingsTable ON StocksTable.ProductPartID_LongInteger = ProductPartsPackingsTable.ProductPartID_LongInteger) LEFT JOIN StocksQuantitiesPerSpecsTable ON ProductsPartsTable.PartsSpecificationID_LongInteger = StocksQuantitiesPerSpecsTable.PartsSpecificationID_LongInteger) ON InventoryItemsTable.StockID__LongInteger = StocksTable.StockID_Autonumber;
"

        MySelection = InventoryItemsFieldsToSelect & InventoryItemsSelectionFilter & InventoryItemsSelectionOrder

        JustExecuteMySelection()
        InventoryItemsRecordCount = RecordCount

        If InventoryItemsRecordCount > 0 Then
            InventoryItemsGroupBox.Visible = True
        Else
            InventoryItemsGroupBox.Visible = False
        End If
        InventoryItemsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable


        If Not InventoryItemsDataGridViewAlreadyFormated Then
            FormatInventoryItemsDataGridView()
        End If

        SetGroupBoxHeight(5, InventoryItemsRecordCount, InventoryItemsGroupBox, InventoryItemsDataGridView)
        InventoryItemsGroupBox.Top = BottomOf(InventoriesGroupBox)

    End Sub
    Private Sub FormatInventoryItemsDataGridView()
        InventoryItemsDataGridViewAlreadyFormated = True
        InventoryItemsGroupBox.Width = 0
        For i = 0 To InventoryItemsDataGridView.Columns.GetColumnCount(0) - 1

            InventoryItemsDataGridView.Columns.Item(i).Visible = False
            Select Case InventoryItemsDataGridView.Columns.Item(i).Name
                Case "ManufacturerPartNo_ShortText30Fld"
                    InventoryItemsDataGridView.Columns.Item(i).HeaderText = "Manufacturer PN"
                    InventoryItemsDataGridView.Columns.Item(i).Width = 150
                    InventoryItemsDataGridView.Columns.Item(i).Visible = True
                Case "ManufacturerDescription_ShortText250"
                    InventoryItemsDataGridView.Columns.Item(i).HeaderText = "Manufacturer Desc"
                    InventoryItemsDataGridView.Columns.Item(i).Width = 400
                    InventoryItemsDataGridView.Columns.Item(i).Visible = True
                Case "QuantityInStock_Double"
                    InventoryItemsDataGridView.Columns.Item(i).HeaderText = "Qty in Stock"
                    InventoryItemsDataGridView.Columns.Item(i).Width = 70
                    InventoryItemsDataGridView.Columns.Item(i).Visible = True
                Case "Unit_ShortText3"
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
                Case "VehicleRepairClassID_LongInteger"
                    InventoryItemsDataGridView.Columns.Item(i).HeaderText = "RepairClassID"
                    InventoryItemsDataGridView.Columns.Item(i).Width = 70
                    InventoryItemsDataGridView.Columns.Item(i).Visible = True
                Case "QuantityPerPack_Double"
                    InventoryItemsDataGridView.Columns.Item(i).HeaderText = "QtyPerPack"
                    InventoryItemsDataGridView.Columns.Item(i).Width = 70
                    InventoryItemsDataGridView.Columns.Item(i).Visible = True
                Case "UnitOfTheQuantity_ShortText3"
                    InventoryItemsDataGridView.Columns.Item(i).HeaderText = "UnitOfTheQuantity"
                    InventoryItemsDataGridView.Columns.Item(i).Width = 70
                    InventoryItemsDataGridView.Columns.Item(i).Visible = True
                Case "LocationCode_ShortText11"
                    InventoryItemsDataGridView.Columns.Item(i).HeaderText = "location"
                    InventoryItemsDataGridView.Columns.Item(i).Width = 120
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
        InventoryItemsGroupBox.Top = BottomOf(InventoriesGroupBox)
    End Sub
    Private Sub InventoryItemsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles InventoryItemsDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If InventoryItemsRecordCount = 0 Then Exit Sub

        CurrentInventoryItemsRow = e.RowIndex
        CurrentInventoryHeaderID = InventoryItemsDataGridView.Item("InventoryHeaderID_LongInteger", CurrentInventoryItemsRow).Value

        FillField(CurrentMyStandardStatus, MyStandardsDataGridView.Item("MyStandardStatus", CurrentMyStandardsRow).Value)

        Select Case CurrentMyStandardStatus
            Case "Assigned"
        End Select

        RegisterInventoryToolStripMenuItem.Visible = True
        PrintToolStripMenuItem.Visible = True
    End Sub
    Private Sub EditProductToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditProductDetailsToolStripMenuItem.Click
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
        ViewToolStripMenuItem.Visible = False
        AddProductToolStripMenuItem.Visible = False
        EditProductDetailsToolStripMenuItem.Visible = False
        DeleteProductToolStripMenuItem.Visible = False
        SaveProductDetailsToolStripMenuItem.Visible = True
        RegisterInventoryToolStripMenuItem.Visible = False
        PrintToolStripMenuItem.Visible = False
    End Sub
    Private Sub SetupBrowseMode()
        ViewToolStripMenuItem.Visible = True
        AddProductToolStripMenuItem.Visible = True
        EditProductDetailsToolStripMenuItem.Visible = True
        DeleteProductToolStripMenuItem.Visible = True
        SaveProductDetailsToolStripMenuItem.Visible = False
    End Sub
    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteProductToolStripMenuItem.Click
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
        FillField(ProductSpecificationTextBox.Text, InventoriesDataGridView.Item("PartSpecifications_ShortText255", CurrentInventoriesRow).Value)
        FillField(SystemPartDescriptionTextBox.Text, InventoriesDataGridView.Item("SystemDesc_ShortText100Fld", CurrentInventoriesRow).Value)
        FillField(ManufacturerPartNoTextBox.Text, InventoriesDataGridView.Item("ManufacturerPartNo_ShortText30Fld", CurrentInventoriesRow).Value)
        FillField(ManufacturerPartDescTextBox.Text, InventoriesDataGridView.Item("ManufacturerDescription_ShortText250", CurrentInventoriesRow).Value)
        FillField(BrandNameTextBox.Text, InventoriesDataGridView.Item("BrandName_ShortText20", CurrentInventoriesRow).Value)
        FillField(UnitTextBox.Text, InventoriesDataGridView.Item("Unit_ShortText3", CurrentInventoriesRow).Value)
        FillField(QtyInBasicUnitTextBox.Text, InventoriesDataGridView.Item("QuantityInStock_Double", CurrentInventoriesRow).Value)
        FillField(MinimumQuantityTextBox.Text, InventoriesDataGridView.Item("MinimumQuantityPerSpecs_Double", CurrentInventoriesRow).Value)
        FillField(LocationTextBox.Text, InventoriesDataGridView.Item("LocationCode_ShortText11", CurrentInventoriesRow).Value)
        If IsNotEmpty(InventoriesDataGridView.Item("QuantityPerPack_Double", CurrentInventoriesRow).Value) Then
            PackingTextBox.Text = InventoriesDataGridView.Item("QuantityPerPack_Double", CurrentInventoriesRow).Value.ToString & Space(1) &
                                      InventoriesDataGridView.Item("UnitOfTheQuantity_ShortText3", CurrentInventoriesRow).Value.ToString &
                                        " / " &
                                      InventoriesDataGridView.Item("Unit_ShortText3", CurrentInventoriesRow).Value.ToString
            PackingTextBox.Visible = True
        Else
            PackingTextBox.Text = ""
            PackingTextBox.Visible = False
        End If
    End Sub
    Private Sub InventoriesForm_EnabledChanged(sender As Object, e As EventArgs) Handles MyBase.EnabledChanged
        If Me.Enabled = False Then Exit Sub
        CallingForm = SavedCallingForm

        Select Case Tunnel1
            Case "Tunnel2IsStocksLocationID"
'                CurrentlocationID = Tunnel2
            Case "Tunnel2IsProductPartID"
                CurrentProductPartId = Tunnel2
                StockDetailsGroup.Visible = True
                SaveProductDetailsToolStripMenuItem.Visible = True
        End Select
    End Sub
    Private Sub ReturnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnToolStripMenuItem.Click
        If StockDetailsGroup.Visible = True Then
            SaveMessage = "There are new entries made, save your changes ?"
            If AllEntriesOfThisStockInventoryDetailsAreValid() Then
                SaveChanges()
                StockDetailsGroup.Visible = False
                Exit Sub
            End If
        End If
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub
    Private Sub SaveProductToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveProductDetailsToolStripMenuItem.Click
        SaveMessage = "Continue saving the changes ?"
        If Not AllEntriesOfThisStockInventoryDetailsAreValid() Then Exit Sub
        SaveChanges()
    End Sub
    Private Sub SaveChanges()
        'CHECK CHANGES REGISTER IF NEEDED
        If AChangeInThisStockInventoryDetailsOccurred() Then
            'VALIDATE
            If MsgBox(SaveMessage, MsgBoxStyle.YesNo) = vbNo Then
                StockDetailsGroup.Visible = False
                Exit Sub
            End If
            RegisterDetailsOfThisStockInventoryChanges()
        End If
    End Sub
    Private Function AChangeInThisStockInventoryDetailsOccurred()
        '*******************************************************
        'Test 1st if a Part/Product is selected and this is the 1st entry in the list
        If CurrentProductPartId > 0 And CurrentInventoriesRow = -1 Then Return True
        ' THIS ROUTINE DETERMINES ALSO IF THE PURPOSE OF ENTRY = "ADD OR EDIT
        If TheseAreNotEqual(QtyInBasicUnitTextBox.Text, InventoriesDataGridView.Item("QuantityInStock_Double", CurrentInventoriesRow).Value) Then Return True
        If TheseAreNotEqual(MinimumQuantityTextBox.Text, InventoriesDataGridView.Item("MinimumQuantityPerSpecs_Double", CurrentInventoriesRow).Value) Then Return True
        If TheseAreNotEqual(LocationTextBox.Text, InventoriesDataGridView.Item("LocationCode_ShortText11", CurrentInventoriesRow).Value) Then Return True
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
        FillInventoriesDataGridView()
    End Sub
    Private Sub SaveThisStockInventoryDetailsChanges()
        Dim RecordFilter = " SELECT TOP 1 FROM InventoryItemsTable WHERE InventoryHeaderID_LongInteger = " & CurrentInventoryHeaderID.ToString
        JustExecuteMySelection()
        If RecordCount > 1 Then
            UpdateCurrentInventoryItemId()
        Else
            AddNewInventoryItem()
        End If
        Dim SetCommand = " SET StocksLocationID_LongInteger = " & CurrentlocationID.ToString

        UpdateTable("StocksTable", SetCommand, RecordFilter)
    End Sub

    Private Sub AddProductToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddProductToolStripMenuItem.Click
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

End Class