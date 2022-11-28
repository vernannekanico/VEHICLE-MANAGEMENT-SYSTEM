Public Class InventoriesForm
    Private ProductsInventoriesFieldsToSelect = ""
    Private ProductsInventoriesSelectionFilter = ""
    Private ProductsInventoriesSelectionOrder = ""
    Private CurrentProductsInventoriesRow As Integer = -1
    Private ProductsInventoriesRecordCount As Integer = -1
    Private CurrentProductPartID = -1
    Private Property CurrentStockID As Object
    Private ProductsInventoriesDataGridViewAlreadyFormated = False
    Private SavedCallingForm As Form
    Private CurrentlocationID As Object
    Public Property SaveMessage As String

    Private Sub ReleasedPartForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SavedCallingForm = CallingForm
        FillProductsInventoriesDataGridView()
        ProductsInventoriesGroupBox.Top = BottomOf(SearchToolStrip)
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
StocksQuantitiesPerSpecsTable.MinimumQuantityPerSpecs_Double, 
StocksQuantitiesPerSpecsTable.AvailableQuantityPerSpecs_Double, 
StocksTable.StockID_Autonumber, 
StocksLocationsTable.StocksLocationID_AutoNumber
FROM (((StocksTable LEFT JOIN (((ProductsPartsTable LEFT JOIN MasterCodeBookTable ON ProductsPartsTable.MasterCodeBookID_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) LEFT JOIN PartsSpecificationsTable ON ProductsPartsTable.PartsSpecificationID_LongInteger = PartsSpecificationsTable.PartsSpecificationID_AutoNumber) LEFT JOIN BrandsTable ON ProductsPartsTable.BrandID_LongInteger = BrandsTable.BrandID_Autonumber) ON StocksTable.ProductPartID_LongInteger = ProductsPartsTable.ProductsPartID_Autonumber) LEFT JOIN StocksLocationsTable ON StocksTable.StocksLocationID_LongInteger = StocksLocationsTable.StocksLocationID_AutoNumber) LEFT JOIN ProductPartsPackingsTable ON StocksTable.ProductPartID_LongInteger = ProductPartsPackingsTable.ProductPartID_LongInteger) LEFT JOIN StocksQuantitiesPerSpecsTable ON ProductsPartsTable.PartsSpecificationID_LongInteger = StocksQuantitiesPerSpecsTable.PartsSpecificationID_LongInteger
"

        MySelection = ProductsInventoriesFieldsToSelect & ProductsInventoriesSelectionFilter & ProductsInventoriesSelectionOrder

        JustExecuteMySelection()
        ProductsInventoriesRecordCount = RecordCount

        If ProductsInventoriesRecordCount > 0 Then
            ProductsInventoriesGroupBox.Visible = True
        Else
            ProductsInventoriesGroupBox.Visible = False
        End If
        ProductsInventoriesDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If ProductsInventoriesRecordCount = 0 Then
            CurrentProductPartID = -1
        End If


        ' HERE AT ROW_ENTER, FillReleasedPartConcernsDataGridView is called and ReleasedPartConcernsbOX IS ALREADY FORMATTED
        If Not ProductsInventoriesDataGridViewAlreadyFormated Then
            FormatInventoriesDataGridView()
            SetFormWidthAndGroupBoxLeft(Me,
                                            MyStandardsFormMenuStrip,
                                            ProductsInventoriesGroupBox,
                                            ProductsInventoriesGroupBox,
                                            ProductsInventoriesGroupBox,
                                            ProductsInventoriesGroupBox)
        End If

        SetGroupBoxHeight(50, ProductsInventoriesRecordCount, ProductsInventoriesGroupBox, ProductsInventoriesDataGridView)
        Me.Top = VehicleManagementSystemForm.VehicleManagementMenuStrip.Top + VehicleManagementSystemForm.VehicleManagementMenuStrip.Height + 20
        Me.Left = VehicleManagementSystemForm.Left
        Me.Height = VehicleManagementSystemForm.Height - Me.Top

    End Sub
    Private Sub FormatInventoriesDataGridView()
        ProductsInventoriesDataGridViewAlreadyFormated = True
        ProductsInventoriesGroupBox.Width = 0
        For i = 0 To ProductsInventoriesDataGridView.Columns.GetColumnCount(0) - 1

            ProductsInventoriesDataGridView.Columns.Item(i).Visible = False
            Select Case ProductsInventoriesDataGridView.Columns.Item(i).Name
                Case "Selected"
                    ProductsInventoriesDataGridView.Columns.Item(i).HeaderText = "*"
                    ProductsInventoriesDataGridView.Columns.Item(i).Width = 20
                    ProductsInventoriesDataGridView.Columns.Item(i).Visible = True
                Case "MasterCodeBookID_LongInteger"
                    ProductsInventoriesDataGridView.Columns.Item(i).HeaderText = "CodeBookID"
                    ProductsInventoriesDataGridView.Columns.Item(i).Width = 80
                    ProductsInventoriesDataGridView.Columns.Item(i).Visible = True
                Case "SystemDesc_ShortText100Fld"
                    ProductsInventoriesDataGridView.Columns.Item(i).HeaderText = "Part Desc"
                    ProductsInventoriesDataGridView.Columns.Item(i).Width = 300
                    ProductsInventoriesDataGridView.Columns.Item(i).Visible = True
                Case "PartSpecifications_ShortText255"
                    ProductsInventoriesDataGridView.Columns.Item(i).HeaderText = "Specification"
                    ProductsInventoriesDataGridView.Columns.Item(i).Width = 200
                    ProductsInventoriesDataGridView.Columns.Item(i).Visible = True
                Case "ManufacturerPartNo_ShortText30Fld"
                    ProductsInventoriesDataGridView.Columns.Item(i).HeaderText = "Manufacturer PN"
                    ProductsInventoriesDataGridView.Columns.Item(i).Width = 150
                    ProductsInventoriesDataGridView.Columns.Item(i).Visible = True
                Case "ManufacturerDescription_ShortText250"
                    ProductsInventoriesDataGridView.Columns.Item(i).HeaderText = "Manufacturer Desc"
                    ProductsInventoriesDataGridView.Columns.Item(i).Width = 400
                    ProductsInventoriesDataGridView.Columns.Item(i).Visible = True
                Case "QuantityInStock_Double"
                    ProductsInventoriesDataGridView.Columns.Item(i).HeaderText = "Qty in Stock"
                    ProductsInventoriesDataGridView.Columns.Item(i).Width = 70
                    ProductsInventoriesDataGridView.Columns.Item(i).Visible = True
                Case "Unit_ShortText3"
                    ProductsInventoriesDataGridView.Columns.Item(i).HeaderText = "Unit"
                    ProductsInventoriesDataGridView.Columns.Item(i).Width = 70
                    ProductsInventoriesDataGridView.Columns.Item(i).Visible = True
                Case "BrandName_ShortText20"
                    ProductsInventoriesDataGridView.Columns.Item(i).HeaderText = "Brand"
                    ProductsInventoriesDataGridView.Columns.Item(i).Width = 150
                    ProductsInventoriesDataGridView.Columns.Item(i).Visible = True
                Case "MinimumQuantity_Double"
                    ProductsInventoriesDataGridView.Columns.Item(i).HeaderText = "Minimun Qty"
                    ProductsInventoriesDataGridView.Columns.Item(i).Width = 70
                    ProductsInventoriesDataGridView.Columns.Item(i).Visible = True
                Case "Location_ShortText10"
                    ProductsInventoriesDataGridView.Columns.Item(i).HeaderText = "Location"
                    ProductsInventoriesDataGridView.Columns.Item(i).Width = 70
                    ProductsInventoriesDataGridView.Columns.Item(i).Visible = True
                Case "ProductDescription_ShortText250"
                    ProductsInventoriesDataGridView.Columns.Item(i).HeaderText = "excel Desc"
                    ProductsInventoriesDataGridView.Columns.Item(i).Width = 400
                    ProductsInventoriesDataGridView.Columns.Item(i).Visible = True
                Case "VehicleRepairClassID_LongInteger"
                    ProductsInventoriesDataGridView.Columns.Item(i).HeaderText = "RepairClassID"
                    ProductsInventoriesDataGridView.Columns.Item(i).Width = 70
                    ProductsInventoriesDataGridView.Columns.Item(i).Visible = True
                Case "VehicleDescription"
                    ProductsInventoriesDataGridView.Columns.Item(i).HeaderText = "Vehicle model"
                    ProductsInventoriesDataGridView.Columns.Item(i).Width = 180
                    ProductsInventoriesDataGridView.Columns.Item(i).Visible = True
                Case "QuantityPerPack_Double"
                    ProductsInventoriesDataGridView.Columns.Item(i).HeaderText = "QtyPerPack"
                    ProductsInventoriesDataGridView.Columns.Item(i).Width = 70
                    ProductsInventoriesDataGridView.Columns.Item(i).Visible = True
                Case "UnitOfTheQuantity_ShortText3"
                    ProductsInventoriesDataGridView.Columns.Item(i).HeaderText = "UnitOfTheQuantity"
                    ProductsInventoriesDataGridView.Columns.Item(i).Width = 70
                    ProductsInventoriesDataGridView.Columns.Item(i).Visible = True
                Case "LocationCode_ShortText11"
                    ProductsInventoriesDataGridView.Columns.Item(i).HeaderText = "location"
                    ProductsInventoriesDataGridView.Columns.Item(i).Width = 120
                    ProductsInventoriesDataGridView.Columns.Item(i).Visible = True

            End Select

            If ProductsInventoriesDataGridView.Columns.Item(i).Visible = True Then
                ProductsInventoriesGroupBox.Width = ProductsInventoriesGroupBox.Width + ProductsInventoriesDataGridView.Columns.Item(i).Width
            End If
        Next
        If ProductsInventoriesGroupBox.Width > VehicleManagementSystemForm.Width Then
            ProductsInventoriesGroupBox.Width = VehicleManagementSystemForm.Width - 4
        Else
            HorizontalCenter(ProductsInventoriesGroupBox, Me)
        End If
        ProductsInventoriesGroupBox.Top = BottomOf(SearchToolStrip)
    End Sub
    Private Sub InventoriesDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles ProductsInventoriesDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If ProductsInventoriesRecordCount = 0 Then Exit Sub

        CurrentProductsInventoriesRow = e.RowIndex
        CurrentProductPartID = ProductsInventoriesDataGridView.Item("ProductsPartID_Autonumber", CurrentProductsInventoriesRow).Value
        CurrentStockID = ProductsInventoriesDataGridView.Item("StockID_Autonumber", CurrentProductsInventoriesRow).Value
        CurrentlocationID = ProductsInventoriesDataGridView.Item("StocksLocationID_AutoNumber", CurrentProductsInventoriesRow).Value
    End Sub
    Private Sub EditProductToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditProductDetailsToolStripMenuItem.Click
        SetupEditMode()
    End Sub
    Private Sub SetupEditMode()
        ThisProductDetailsGroup.Visible = True
        SelectToolStripMenuItem.Visible = False
        '     UpdateMasterCodeLinkToolStripMenuItem.Visible = False
        AddProductToolStripMenuItem.Visible = False
        DeleteProductToolStripMenuItem.Visible = False
        EditProductDetailsToolStripMenuItem.Visible = False

        LoadProductDetails()
        ManufacturerPartDescTextBox.Select()
        ManufacturerPartNoTextBox.Enabled = True
        BrandNameTextBox.Enabled = True
        UnitTextBox.Enabled = True
        AvailableQuantitiesTextBox.Enabled = True
        MinimumQuantityTextBox.Enabled = True
        LocationTextBox.Enabled = True
    End Sub
    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteProductToolStripMenuItem.Click
        Dim TablesToCheck = {
                                             "WorkOrderPartsTable",
                                             "WorkOrderReceivedPartsTable",
                                             "WorkOrderRequestedPartsTable",
                                             "StoreSuppliesRequisitionsItemsTable",
                                             "PurchaseOrdersItemsTable",
                                             "RequisitionsItemsTable",
                                             "DeliveryItemsTable"
                                             }

        If Not LinkExistsIn(TablesToCheck, "ProductPartID_LongInteger", CurrentProductPartID) Then
            MySelection = " DELETE FROM StocksTable WHERE ProductPartID_LongInteger =  " & CurrentProductPartID
            JustExecuteMySelection()
            ' delete all related records in stokcstable and StocksTable (delete stocks record)
            '           ProductPartsPackingsTable
            MySelection = " DELETE FROM ProductPartsPackingsTable WHERE ProductPartID_LongInteger =  " & CurrentProductPartID
            JustExecuteMySelection()
            If MsgBox("Continue DELETE this record ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            MySelection = " DELETE FROM ProductsPartsTable WHERE ProductsPartID_Autonumber =  " & CurrentProductPartID
            JustExecuteMySelection()
            FillProductsInventoriesDataGridView()
        End If
    End Sub
    Private Sub LoadProductDetails()
        FillField(ProductSpecificationTextBox.Text, ProductsInventoriesDataGridView.Item("PartSpecifications_ShortText255", CurrentProductsInventoriesRow).Value)
        FillField(SystemPartDescriptionTextBox.Text, ProductsInventoriesDataGridView.Item("SystemDesc_ShortText100Fld", CurrentProductsInventoriesRow).Value)
        FillField(ManufacturerPartNoTextBox.Text, ProductsInventoriesDataGridView.Item("ManufacturerPartNo_ShortText30Fld", CurrentProductsInventoriesRow).Value)
        FillField(ManufacturerPartDescTextBox.Text, ProductsInventoriesDataGridView.Item("ManufacturerDescription_ShortText250", CurrentProductsInventoriesRow).Value)
        FillField(BrandNameTextBox.Text, ProductsInventoriesDataGridView.Item("BrandName_ShortText20", CurrentProductsInventoriesRow).Value)
        FillField(UnitTextBox.Text, ProductsInventoriesDataGridView.Item("Unit_ShortText3", CurrentProductsInventoriesRow).Value)
        FillField(AvailableQuantitiesTextBox.Text, ProductsInventoriesDataGridView.Item("QuantityInStock_Double", CurrentProductsInventoriesRow).Value)
        FillField(MinimumQuantityTextBox.Text, ProductsInventoriesDataGridView.Item("MinimumQuantity_Double", CurrentProductsInventoriesRow).Value)
        FillField(LocationTextBox.Text, ProductsInventoriesDataGridView.Item("LocationCode_ShortText11", CurrentProductsInventoriesRow).Value)
        If IsNotEmpty(ProductsInventoriesDataGridView.Item("QuantityPerPack_Double", CurrentProductsInventoriesRow).Value) Then
            PackingTextBox.Text = ProductsInventoriesDataGridView.Item("QuantityPerPack_Double", CurrentProductsInventoriesRow).Value.ToString & Space(1) &
                                      ProductsInventoriesDataGridView.Item("UnitOfTheQuantity_ShortText3", CurrentProductsInventoriesRow).Value.ToString &
                                        " / " &
                                      ProductsInventoriesDataGridView.Item("Unit_ShortText3", CurrentProductsInventoriesRow).Value.ToString
            PackingTextBox.Visible = True
        Else
            PackingTextBox.Text = ""
            PackingTextBox.Visible = False
        End If
    End Sub
    Private Sub LocationTextBox_Click(sender As Object, e As EventArgs) Handles LocationTextBox.Click
        If Not LocationTextBox.Text = "" Then
            If MsgBox("CHANGE BRAND?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
            StockLocationsForm.StockLocationSearchTextBox.Text = LocationTextBox.Text
        End If
        ShowCalledForm(Me, StockLocationsForm)
    End Sub
    Private Sub InventoriesForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        If Me.Enabled = False Then Exit Sub
        CallingForm = SavedCallingForm

        Select Case Tunnel1
            Case "Tunnel2IsStocksLocationID"
                CurrentlocationID = Tunnel2
        End Select

    End Sub
    Private Sub ReturnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnToolStripMenuItem.Click
        If ThisProductDetailsGroup.Visible = True Then
            SaveMessage = "Would you like to disregard your changes ?"
            SaveChanges()
            ThisProductDetailsGroup.Visible = False
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
                ThisProductDetailsGroup.Visible = False
                Exit Sub
            End If
            If Not AllEntriesOfThisStockInventoryDetailsAreValid() Then Exit Sub
            RegisterDetailsOfThisStockInventoryChanges()
        End If
    End Sub
    Private Function AChangeInThisStockInventoryDetailsOccurred()
        '*******************************************************
        ' THIS ROUTINE DETERMINES ALSO IF THE PURPOSE OF ENTRY = "ADD OR EDIT
        If TheseAreNotEqual(AvailableQuantitiesTextBox.Text, ProductsInventoriesDataGridView.Item("QuantityInStock_Double", CurrentProductsInventoriesRow).Value) Then Return True
        If TheseAreNotEqual(MinimumQuantityTextBox.Text, ProductsInventoriesDataGridView.Item("MinimumQuantity_Double", CurrentProductsInventoriesRow).Value) Then Return True
        If TheseAreNotEqual(LocationTextBox.Text, ProductsInventoriesDataGridView.Item("LocationCode_ShortText11", CurrentProductsInventoriesRow).Value) Then Return True
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
        '        MySelection = " Select top 1 * FROM InventoriesTable WHERE InventoryID_Autonumber = " & CurrentInventoryID.ToString
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
End Class