Public Class StocksForm
    Private ProductsInventoriesFieldsToSelect = ""
    Private ProductsInventoriesSelectionFilter = ""
    Private ProductsInventoriesSelectionOrder = ""
    Private CurrentProductsInventoriesRow As Integer = -1
    Private ProductsInventoriesRecordCount As Integer = -1
    Private CurrentProductPartID = -1
    Private ProductsInventoriesDataGridViewAlreadyFormated = False

    Private SpecificationsInventoriesFieldsToSelect = ""
    Private SpecificationsInventoriesSelectionFilter = ""
    Private SpecificationsInventoriesSelectionOrder = ""
    Private CurrentSpecificationsInventoriesRow As Integer = -1
    Private SpecificationsInventoriesRecordCount As Integer = -1
    Private CurrentThisProductPartID = -1
    Private SpecificationsInventoriesDataGridViewAlreadyFormated = False

    Private InventoriesFieldsToSelect = ""
    Private InventoriesSelectionFilter = ""
    Private InventoriesSelectionOrder = ""
    Private InventoriesRecordCount As Integer = -1
    Private CurrentInventoriesRow As Integer = -1
    Private CurrentInventoryID = -1
    Private CurrentInventoryStatus As String
    Private InventoriesDataGridViewAlreadyFormated = False
    Private Property CurrentStockID As Object
    Private CurrentlocationID As Object
    Private Property SaveMessage As String
    Private SavedCallingForm As Form

    Private Sub StocksForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SavedCallingForm = CallingForm
        FillProductsInventoriesDataGridView()
        StocksGroupBox.Top = BottomOf(SearchToolStrip)
    End Sub
    Private Sub FillProductsInventoriesDataGridView()
        ProductsInventoriesSelectionOrder = " ORDER BY SystemDesc_ShortText100Fld DESC "

        ProductsInventoriesFieldsToSelect = " 
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
StocksQuantitiesPerSpecsTable.StocksQuantitiesPerSpecsID_AutoNumber, 
StocksTable.StockID_Autonumber, 
StocksLocationsTable.StocksLocationID_AutoNumber
FROM (((StocksTable LEFT JOIN (((ProductsPartsTable LEFT JOIN MasterCodeBookTable ON ProductsPartsTable.MasterCodeBookID_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) LEFT JOIN PartsSpecificationsTable ON ProductsPartsTable.PartsSpecificationID_LongInteger = PartsSpecificationsTable.PartsSpecificationID_AutoNumber) LEFT JOIN BrandsTable ON ProductsPartsTable.BrandID_LongInteger = BrandsTable.BrandID_Autonumber) ON StocksTable.ProductPartID_LongInteger = ProductsPartsTable.ProductsPartID_Autonumber) LEFT JOIN StocksLocationsTable ON StocksTable.StocksLocationID_LongInteger = StocksLocationsTable.StocksLocationID_AutoNumber) LEFT JOIN ProductPartsPackingsTable ON StocksTable.ProductPartID_LongInteger = ProductPartsPackingsTable.ProductPartID_LongInteger) LEFT JOIN StocksQuantitiesPerSpecsTable ON ProductsPartsTable.PartsSpecificationID_LongInteger = StocksQuantitiesPerSpecsTable.PartsSpecificationID_LongInteger
"

        MySelection = ProductsInventoriesFieldsToSelect & ProductsInventoriesSelectionFilter & ProductsInventoriesSelectionOrder

        JustExecuteMySelection()
        ProductsInventoriesRecordCount = RecordCount

        If ProductsInventoriesRecordCount > 0 Then
            StocksGroupBox.Visible = True
        Else
            StocksGroupBox.Visible = False
        End If
        StocksDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If ProductsInventoriesRecordCount = 0 Then
            CurrentProductPartID = -1
        End If


        ' HERE AT ROW_ENTER, FillReleasedPartConcernsDataGridView is called and ReleasedPartConcernsbOX IS ALREADY FORMATTED
        If Not ProductsInventoriesDataGridViewAlreadyFormated Then
            FormatProductsInventoriesDataGridView()
        End If

        SetGroupBoxHeight(50, ProductsInventoriesRecordCount, StocksGroupBox, StocksDataGridView)
    End Sub
    Private Sub FormatProductsInventoriesDataGridView()
        ProductsInventoriesDataGridViewAlreadyFormated = True
        StocksGroupBox.Width = 0
        For i = 0 To StocksDataGridView.Columns.GetColumnCount(0) - 1

            StocksDataGridView.Columns.Item(i).Visible = False
            Select Case StocksDataGridView.Columns.Item(i).Name
                Case "Selected"
                    StocksDataGridView.Columns.Item(i).HeaderText = "*"
                    StocksDataGridView.Columns.Item(i).Width = 20
                    StocksDataGridView.Columns.Item(i).Visible = True
                Case "MasterCodeBookID_LongInteger"
                    StocksDataGridView.Columns.Item(i).HeaderText = "CodeBookID"
                    StocksDataGridView.Columns.Item(i).Width = 80
                    StocksDataGridView.Columns.Item(i).Visible = True
                Case "SystemDesc_ShortText100Fld"
                    StocksDataGridView.Columns.Item(i).HeaderText = "Part Desc"
                    StocksDataGridView.Columns.Item(i).Width = 300
                    StocksDataGridView.Columns.Item(i).Visible = True
                Case "PartSpecifications_ShortText255"
                    StocksDataGridView.Columns.Item(i).HeaderText = "Specification"
                    StocksDataGridView.Columns.Item(i).Width = 200
                    StocksDataGridView.Columns.Item(i).Visible = True
                Case "ManufacturerPartNo_ShortText30Fld"
                    StocksDataGridView.Columns.Item(i).HeaderText = "Manufacturer PN"
                    StocksDataGridView.Columns.Item(i).Width = 150
                    StocksDataGridView.Columns.Item(i).Visible = True
                Case "ManufacturerDescription_ShortText250"
                    StocksDataGridView.Columns.Item(i).HeaderText = "Manufacturer Desc"
                    StocksDataGridView.Columns.Item(i).Width = 400
                    StocksDataGridView.Columns.Item(i).Visible = True
                Case "QuantityInStock_Double"
                    StocksDataGridView.Columns.Item(i).HeaderText = "Qty in Stock"
                    StocksDataGridView.Columns.Item(i).Width = 70
                    StocksDataGridView.Columns.Item(i).Visible = True
                Case "Unit_ShortText3"
                    StocksDataGridView.Columns.Item(i).HeaderText = "Unit"
                    StocksDataGridView.Columns.Item(i).Width = 70
                    StocksDataGridView.Columns.Item(i).Visible = True
                Case "BrandName_ShortText20"
                    StocksDataGridView.Columns.Item(i).HeaderText = "Brand"
                    StocksDataGridView.Columns.Item(i).Width = 150
                    StocksDataGridView.Columns.Item(i).Visible = True
                Case "MinimumQuantityPerSpecs_Double"
                    StocksDataGridView.Columns.Item(i).HeaderText = "Minimun Qty"
                    StocksDataGridView.Columns.Item(i).Width = 70
                    StocksDataGridView.Columns.Item(i).Visible = True
                Case "Location_ShortText10"
                    StocksDataGridView.Columns.Item(i).HeaderText = "Location"
                    StocksDataGridView.Columns.Item(i).Width = 70
                    StocksDataGridView.Columns.Item(i).Visible = True
                Case "ProductDescription_ShortText250"
                    StocksDataGridView.Columns.Item(i).HeaderText = "excel Desc"
                    StocksDataGridView.Columns.Item(i).Width = 400
                    StocksDataGridView.Columns.Item(i).Visible = True
                Case "VehicleRepairClassID_LongInteger"
                    StocksDataGridView.Columns.Item(i).HeaderText = "RepairClassID"
                    StocksDataGridView.Columns.Item(i).Width = 70
                    StocksDataGridView.Columns.Item(i).Visible = True
                Case "VehicleDescription"
                    StocksDataGridView.Columns.Item(i).HeaderText = "Vehicle model"
                    StocksDataGridView.Columns.Item(i).Width = 180
                    StocksDataGridView.Columns.Item(i).Visible = True
                Case "QuantityPerPack_Double"
                    StocksDataGridView.Columns.Item(i).HeaderText = "QtyPerPack"
                    StocksDataGridView.Columns.Item(i).Width = 70
                    StocksDataGridView.Columns.Item(i).Visible = True
                Case "UnitOfTheQuantity_ShortText3"
                    StocksDataGridView.Columns.Item(i).HeaderText = "UnitOfTheQuantity"
                    StocksDataGridView.Columns.Item(i).Width = 70
                    StocksDataGridView.Columns.Item(i).Visible = True
                Case "LocationCode_ShortText11"
                    StocksDataGridView.Columns.Item(i).HeaderText = "location"
                    StocksDataGridView.Columns.Item(i).Width = 120
                    StocksDataGridView.Columns.Item(i).Visible = True

            End Select

            If StocksDataGridView.Columns.Item(i).Visible = True Then
                StocksGroupBox.Width = StocksGroupBox.Width + StocksDataGridView.Columns.Item(i).Width
            End If
        Next
        If StocksGroupBox.Width > VehicleManagementSystemForm.Width Then
            StocksGroupBox.Width = VehicleManagementSystemForm.Width - 4
        Else
            HorizontalCenter(StocksGroupBox, Me)
        End If
        StocksGroupBox.Top = BottomOf(SearchToolStrip)
    End Sub
    Private Sub ProductsInventoriesDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles StocksDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If ProductsInventoriesRecordCount = 0 Then Exit Sub

        CurrentProductsInventoriesRow = e.RowIndex
        CurrentProductPartID = StocksDataGridView.Item("ProductsPartID_Autonumber", CurrentProductsInventoriesRow).Value
        CurrentStockID = StocksDataGridView.Item("StockID_Autonumber", CurrentProductsInventoriesRow).Value
        CurrentlocationID = StocksDataGridView.Item("StocksLocationID_AutoNumber", CurrentProductsInventoriesRow).Value
        If IsEmpty(StocksDataGridView.Item("PartsSpecificationID_AutoNumber", CurrentProductsInventoriesRow).Value) Then
            MsgBox("Part/Product Specification is missing, " & vbLf & "need to update, " & vbLf &
                   "required to determine available quantities")
            SpecificationInventoriesGroupBox.Visible = False
            Exit Sub
        End If
        SpecificationsInventoriesSelectionFilter = "WHERE PartsSpecificationID_AutoNumber = " &
                                                StocksDataGridView.Item("PartsSpecificationID_AutoNumber", CurrentProductsInventoriesRow).Value
        FillSpecificationsInventoriesDataGridView()
        Dim AvailableQuantities = 0
        For i = 0 To SpecificationsInventoriesRecordCount - 1
            Dim QuantityPerPack = 0
            FillField(QuantityPerPack, SpecificationsInventoriesDataGridView.Item("QuantityPerPack_Double", CurrentSpecificationsInventoriesRow).Value)
            If QuantityPerPack = -1 Then QuantityPerPack = 0
            AvailableQuantities +=
             SpecificationsInventoriesDataGridView.Item("BulkBalanceQuantity_Double", CurrentSpecificationsInventoriesRow).Value +
             (SpecificationsInventoriesDataGridView.Item("QuantityInStock_Double", CurrentSpecificationsInventoriesRow).Value *
             QuantityPerPack)
        Next i
        Dim ThisProductMinimumQuantity = 0
        FillField(ThisProductMinimumQuantity, SpecificationsInventoriesDataGridView.Item("MinimumQuantityPerSpecs_Double", CurrentSpecificationsInventoriesRow).Value)
        SpecificationInventoriesGroupBox.Text = "[" & StocksDataGridView.Item("SystemDesc_ShortText100Fld", CurrentProductsInventoriesRow).Value & "] " &
                                                " [SPECIFICATION: " &
                                                StocksDataGridView.Item("PartSpecifications_ShortText255", CurrentProductsInventoriesRow).Value & "] " &
                                                " [Available Quantities : " & AvailableQuantities.ToString & "] " &
                                                " [Minimum Quantity : " & ThisProductMinimumQuantity
    End Sub
    Private Sub FillSpecificationsInventoriesDataGridView()
        SpecificationsInventoriesSelectionOrder = " ORDER BY SystemDesc_ShortText100Fld DESC "

        SpecificationsInventoriesFieldsToSelect = " 
SELECT 
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
StocksTable.BulkBalanceQuantity_Double,
StocksQuantitiesPerSpecsTable.MinimumQuantityPerSpecs_Double, 
StocksTable.StocksLocationID_LongInteger, 
StocksLocationsTable.LocationCode_ShortText11,
ProductPartsPackingsTable.QuantityPerPack_Double, 
ProductPartsPackingsTable.UnitOfTheQuantity_ShortText3, 
ProductPartsPackingsTable.UnitOfThePacking_ShortText3,
ProductsPartsTable.ProductsPartID_Autonumber,
StocksQuantitiesPerSpecsTable.AvailableQuantityPerSpecs_Double, 
StocksTable.StockID_Autonumber, 
StocksLocationsTable.StocksLocationID_AutoNumber
FROM (((StocksTable LEFT JOIN (((ProductsPartsTable LEFT JOIN MasterCodeBookTable ON ProductsPartsTable.MasterCodeBookID_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) LEFT JOIN PartsSpecificationsTable ON ProductsPartsTable.PartsSpecificationID_LongInteger = PartsSpecificationsTable.PartsSpecificationID_AutoNumber) LEFT JOIN BrandsTable ON ProductsPartsTable.BrandID_LongInteger = BrandsTable.BrandID_Autonumber) ON StocksTable.ProductPartID_LongInteger = ProductsPartsTable.ProductsPartID_Autonumber) LEFT JOIN StocksLocationsTable ON StocksTable.StocksLocationID_LongInteger = StocksLocationsTable.StocksLocationID_AutoNumber) LEFT JOIN ProductPartsPackingsTable ON StocksTable.ProductPartID_LongInteger = ProductPartsPackingsTable.ProductPartID_LongInteger) LEFT JOIN StocksQuantitiesPerSpecsTable ON ProductsPartsTable.PartsSpecificationID_LongInteger = StocksQuantitiesPerSpecsTable.PartsSpecificationID_LongInteger
"

        MySelection = SpecificationsInventoriesFieldsToSelect & SpecificationsInventoriesSelectionFilter & SpecificationsInventoriesSelectionOrder

        JustExecuteMySelection()
        SpecificationsInventoriesRecordCount = RecordCount

        If SpecificationsInventoriesRecordCount > 0 Then
            SpecificationInventoriesGroupBox.Visible = True
        Else
            SpecificationInventoriesGroupBox.Visible = False
        End If
        SpecificationsInventoriesDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable


        If Not SpecificationsInventoriesDataGridViewAlreadyFormated Then
            FormatSpecificationsInventoriesDataGridView()
        End If

        SetGroupBoxHeight(5, SpecificationsInventoriesRecordCount, SpecificationInventoriesGroupBox, SpecificationsInventoriesDataGridView)
        SpecificationInventoriesGroupBox.Top = BottomOf(StocksGroupBox)

    End Sub
    Private Sub FormatSpecificationsInventoriesDataGridView()
        SpecificationsInventoriesDataGridViewAlreadyFormated = True
        SpecificationInventoriesGroupBox.Width = 0
        For i = 0 To SpecificationsInventoriesDataGridView.Columns.GetColumnCount(0) - 1

            SpecificationsInventoriesDataGridView.Columns.Item(i).Visible = False
            Select Case SpecificationsInventoriesDataGridView.Columns.Item(i).Name
                Case "ManufacturerPartNo_ShortText30Fld"
                    SpecificationsInventoriesDataGridView.Columns.Item(i).HeaderText = "Manufacturer PN"
                    SpecificationsInventoriesDataGridView.Columns.Item(i).Width = 150
                    SpecificationsInventoriesDataGridView.Columns.Item(i).Visible = True
                Case "ManufacturerDescription_ShortText250"
                    SpecificationsInventoriesDataGridView.Columns.Item(i).HeaderText = "Manufacturer Desc"
                    SpecificationsInventoriesDataGridView.Columns.Item(i).Width = 400
                    SpecificationsInventoriesDataGridView.Columns.Item(i).Visible = True
                Case "QuantityInStock_Double"
                    SpecificationsInventoriesDataGridView.Columns.Item(i).HeaderText = "Qty in Stock"
                    SpecificationsInventoriesDataGridView.Columns.Item(i).Width = 70
                    SpecificationsInventoriesDataGridView.Columns.Item(i).Visible = True
                Case "Unit_ShortText3"
                    SpecificationsInventoriesDataGridView.Columns.Item(i).HeaderText = "Unit"
                    SpecificationsInventoriesDataGridView.Columns.Item(i).Width = 70
                    SpecificationsInventoriesDataGridView.Columns.Item(i).Visible = True
                Case "BrandName_ShortText20"
                    SpecificationsInventoriesDataGridView.Columns.Item(i).HeaderText = "Brand"
                    SpecificationsInventoriesDataGridView.Columns.Item(i).Width = 150
                    SpecificationsInventoriesDataGridView.Columns.Item(i).Visible = True
                Case "Location_ShortText10"
                    SpecificationsInventoriesDataGridView.Columns.Item(i).HeaderText = "Location"
                    SpecificationsInventoriesDataGridView.Columns.Item(i).Width = 70
                    SpecificationsInventoriesDataGridView.Columns.Item(i).Visible = True
                Case "ProductDescription_ShortText250"
                    SpecificationsInventoriesDataGridView.Columns.Item(i).HeaderText = "excel Desc"
                    SpecificationsInventoriesDataGridView.Columns.Item(i).Width = 400
                    SpecificationsInventoriesDataGridView.Columns.Item(i).Visible = True
                Case "VehicleRepairClassID_LongInteger"
                    SpecificationsInventoriesDataGridView.Columns.Item(i).HeaderText = "RepairClassID"
                    SpecificationsInventoriesDataGridView.Columns.Item(i).Width = 70
                    SpecificationsInventoriesDataGridView.Columns.Item(i).Visible = True
                Case "QuantityPerPack_Double"
                    SpecificationsInventoriesDataGridView.Columns.Item(i).HeaderText = "QtyPerPack"
                    SpecificationsInventoriesDataGridView.Columns.Item(i).Width = 70
                    SpecificationsInventoriesDataGridView.Columns.Item(i).Visible = True
                Case "UnitOfTheQuantity_ShortText3"
                    SpecificationsInventoriesDataGridView.Columns.Item(i).HeaderText = "UnitOfTheQuantity"
                    SpecificationsInventoriesDataGridView.Columns.Item(i).Width = 70
                    SpecificationsInventoriesDataGridView.Columns.Item(i).Visible = True
                Case "LocationCode_ShortText11"
                    SpecificationsInventoriesDataGridView.Columns.Item(i).HeaderText = "location"
                    SpecificationsInventoriesDataGridView.Columns.Item(i).Width = 120
                    SpecificationsInventoriesDataGridView.Columns.Item(i).Visible = True

            End Select

            If SpecificationsInventoriesDataGridView.Columns.Item(i).Visible = True Then
                SpecificationInventoriesGroupBox.Width = SpecificationInventoriesGroupBox.Width + SpecificationsInventoriesDataGridView.Columns.Item(i).Width
            End If
        Next
        If SpecificationInventoriesGroupBox.Width > VehicleManagementSystemForm.Width Then
            SpecificationInventoriesGroupBox.Width = VehicleManagementSystemForm.Width - 4
        Else
            HorizontalCenter(SpecificationInventoriesGroupBox, Me)
        End If
        SpecificationInventoriesGroupBox.Top = BottomOf(StocksGroupBox)
    End Sub
    Private Sub SpecificationsInventoriesDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles SpecificationsInventoriesDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If SpecificationsInventoriesRecordCount = 0 Then Exit Sub
        CurrentSpecificationsInventoriesRow = e.RowIndex
        CurrentThisProductPartID = SpecificationsInventoriesDataGridView.Item("ProductsPartID_Autonumber", CurrentSpecificationsInventoriesRow).Value
    End Sub
    Private Sub EditProductToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditProductDetailsToolStripMenuItem.Click
        SetupEditMode()
    End Sub
    Private Sub SetupEditMode()
        StockDetailsGroup.Visible = True
        SelectToolStripMenuItem.Visible = False
        '     UpdateMasterCodeLinkToolStripMenuItem.Visible = False
        AddProductToolStripMenuItem.Visible = False
        DeleteProductToolStripMenuItem.Visible = False
        EditProductDetailsToolStripMenuItem.Visible = False

        LoadProductDetails()
        ManufacturerPartDescTextBox.Select()
        ManufacturerPartDescTextBox.Enabled = True
        BrandNameTextBox.Enabled = True
        UnitTextBox.Enabled = True
        AvailableQuantitiesTextBox.Enabled = True
        MinimumQuantityTextBox.Enabled = True
        LocationTextBox.Enabled = True
    End Sub
    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteProductToolStripMenuItem.Click
        If IsDBNull(StocksDataGridView.Item("StocksQuantitiesPerSpecsID_AutoNumber", CurrentProductsInventoriesRow).Value) Then
            If MsgBox("Continue delete this item?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                MySelection = " DELETE FROM StocksTable WHERE ProductPartID_LongInteger =  " & CurrentProductPartID
                JustExecuteMySelection()
            End If
        Else
            MsgBox("This Product is listed as required to be always available on stock")
        End If

        FillProductsInventoriesDataGridView()
    End Sub
    Private Sub LoadProductDetails()
        FillField(ProductSpecificationTextBox.Text, StocksDataGridView.Item("PartSpecifications_ShortText255", CurrentProductsInventoriesRow).Value)
        FillField(SystemPartDescriptionTextBox.Text, StocksDataGridView.Item("SystemDesc_ShortText100Fld", CurrentProductsInventoriesRow).Value)
        FillField(ManufacturerPartNoTextBox.Text, StocksDataGridView.Item("ManufacturerPartNo_ShortText30Fld", CurrentProductsInventoriesRow).Value)
        FillField(ManufacturerPartDescTextBox.Text, StocksDataGridView.Item("ManufacturerDescription_ShortText250", CurrentProductsInventoriesRow).Value)
        FillField(BrandNameTextBox.Text, StocksDataGridView.Item("BrandName_ShortText20", CurrentProductsInventoriesRow).Value)
        FillField(UnitTextBox.Text, StocksDataGridView.Item("Unit_ShortText3", CurrentProductsInventoriesRow).Value)
        FillField(AvailableQuantitiesTextBox.Text, StocksDataGridView.Item("QuantityInStock_Double", CurrentProductsInventoriesRow).Value)
        FillField(MinimumQuantityTextBox.Text, StocksDataGridView.Item("MinimumQuantityPerSpecs_Double", CurrentProductsInventoriesRow).Value)
        FillField(LocationTextBox.Text, StocksDataGridView.Item("LocationCode_ShortText11", CurrentProductsInventoriesRow).Value)
        If IsNotEmpty(StocksDataGridView.Item("QuantityPerPack_Double", CurrentProductsInventoriesRow).Value) Then
            PackingTextBox.Text = StocksDataGridView.Item("QuantityPerPack_Double", CurrentProductsInventoriesRow).Value.ToString & Space(1) &
                                      StocksDataGridView.Item("UnitOfTheQuantity_ShortText3", CurrentProductsInventoriesRow).Value.ToString &
                                        " / " &
                                      StocksDataGridView.Item("Unit_ShortText3", CurrentProductsInventoriesRow).Value.ToString
            PackingTextBox.Visible = True
        Else
            PackingTextBox.Text = ""
            PackingTextBox.Visible = False
        End If
    End Sub
    Private Sub InventoriesForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        If Me.Enabled = False Then Exit Sub
        CallingForm = SavedCallingForm

        Select Case Tunnel1
            Case "Tunnel2IsStocksLocationID"
                CurrentlocationID = Tunnel2
            Case "Tunnel2IsProductPartID"
                FillProductsInventoriesDataGridView()
        End Select
    End Sub
    Private Sub ReturnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnToolStripMenuItem.Click
        If StockDetailsGroup.Visible = True Then
            SaveMessage = "Would you like to disregard your changes ?"
            SaveChanges()
            StockDetailsGroup.Visible = False
        Else
            DoCommonHouseKeeping(Me, SavedCallingForm)
        End If
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub
    Private Sub SaveProductToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveProductDetailsToolStripMenuItem.Click
        SaveMessage = "Continue saving the changes ?"
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
            If Not AllEntriesOfThisStockInventoryDetailsAreValid() Then Exit Sub
            RegisterDetailsOfThisStockInventoryChanges()
        End If
    End Sub
    Private Function AChangeInThisStockInventoryDetailsOccurred()
        '*******************************************************
        ' THIS ROUTINE DETERMINES ALSO IF THE PURPOSE OF ENTRY = "ADD OR EDIT
        If TheseAreNotEqual(AvailableQuantitiesTextBox.Text, StocksDataGridView.Item("QuantityInStock_Double", CurrentProductsInventoriesRow).Value) Then Return True
        If TheseAreNotEqual(MinimumQuantityTextBox.Text, StocksDataGridView.Item("MinimumQuantityPerSpecs_Double", CurrentProductsInventoriesRow).Value) Then Return True
        If TheseAreNotEqual(LocationTextBox.Text, StocksDataGridView.Item("LocationCode_ShortText11", CurrentProductsInventoriesRow).Value) Then Return True
        Return False
    End Function
    Private Function AllEntriesOfThisStockInventoryDetailsAreValid()
        If Trim(AvailableQuantitiesTextBox.Text) = "" Then
            If MsgBox("Would you like to leave the quantities blank ?", vbYesNo) = vbNo Then
                Return False
            Else
                If MsgBox("Would you like to add this to the" & " list of items to order " & "?", vbYesNo) = vbYes Then
                    AddToListOfItemToBuy()
                End If
            End If
        End If
        Return True
    End Function
    Private Sub RegisterDetailsOfThisStockInventoryChanges()
        'NOTE COMMENTED LINES DOES NOT APPLY HERE. NEW PRODUCTS ARE INSERTED IN THE PARTSPRODUCTSFORM
        'STILL RETAINED HERE TO SHOW STANDARD ROUTINE
        '        MySelection = " Select top 1 * FROM InventoriesTable WHERE InventoryID_Autonumber = " & CurrentInventoryHeaderID.ToString
        '        JustExecuteMySelection()
        '        If RecordCount = 0 Then
        '        InsertNewInventory()
        '        Else
        SaveThisStockInventoryDetailsChanges()
        '        End If
        FillProductsInventoriesDataGridView()
    End Sub
    Private Sub SaveThisStockInventoryDetailsChanges()
        Dim RecordFilter = " WHERE StockID_Autonumber = " & CurrentStockID.ToString
        Dim SetCommand = " SET StocksLocationID_LongInteger = " & CurrentlocationID.ToString

        UpdateTable("StocksTable", SetCommand, RecordFilter)
    End Sub
    Private Sub AddToListOfItemToBuy()
        MsgBox("CODE this Routine AddToListOfItemToBuy()")
    End Sub
    Private Sub UpdateProductInformationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateProductInformationToolStripMenuItem.Click
        Tunnel1 = "Tunnel2IsProductPartID"
        Tunnel2 = CurrentProductPartID
        ProductsPartsForm.SystemPartDescriptionTextBox.Text = StocksDataGridView.Item("SystemDesc_ShortText100Fld", CurrentProductsInventoriesRow).Value

        ShowCalledForm(Me, ProductsPartsForm)

    End Sub
    Private Sub LocationTextBox_Click(sender As Object, e As EventArgs) Handles LocationTextBox.Click
        If Not LocationTextBox.Text = "" Then
            If MsgBox("CHANGE Location?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
            StockLocationsForm.StockLocationSearchTextBox.Text = LocationTextBox.Text
        End If
        ShowCalledForm(Me, StockLocationsForm)

    End Sub
End Class