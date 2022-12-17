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
        Dim Packing = "str(ProductPartsPackingsTable.QuantityPerPack_Double) & ProductPartsPackingsTable.UnitOfTheQuantity_ShortText3 & chr(47) & ProductPartsPackingsTable.UnitOfThePacking_ShortText3 as Packing,"
        InventoryItemsFieldsToSelect = " 
SELECT 
StocksLocationsTable.LocationCode_ShortText11,
MasterCodeBookTable.SystemDesc_ShortText100Fld, 
PartsSpecificationsTable.PartSpecifications_ShortText255, 
ProductsPartsTable.ManufacturerPartNo_ShortText30Fld, 
ProductsPartsTable.ManufacturerDescription_ShortText250, 
StocksTable.QuantityInStock_Double, 
ProductsPartsTable.Unit_ShortText3, 
StocksTable.BulkBalanceQuantity_Double,
ProductPartsPackingsTable.UnitOfTheQuantity_ShortText3, 
BrandsTable.BrandID_Autonumber, 
BrandsTable.BrandName_ShortText20, 
ProductPartsPackingsTable.QuantityPerPack_Double, 
ProductPartsPackingsTable.UnitOfThePacking_ShortText3, 
" & Packing & "
ProductsPartsTable.ProductsPartID_Autonumber, 
StocksTable.StockID_Autonumber, 
StocksLocationsTable.StocksLocationID_AutoNumber, 
InventoryItemsTable.InventoryHeaderID_LongInteger
FROM (((InventoryItemsTable LEFT JOIN InventoryHeadersTable ON InventoryItemsTable.InventoryHeaderID_LongInteger = InventoryHeadersTable.InventoryHeaderID_AutoNumber) LEFT JOIN (((ProductsPartsTable LEFT JOIN MasterCodeBookTable ON ProductsPartsTable.MasterCodeBookID_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) LEFT JOIN PartsSpecificationsTable ON ProductsPartsTable.PartsSpecificationID_LongInteger = PartsSpecificationsTable.PartsSpecificationID_AutoNumber) LEFT JOIN BrandsTable ON ProductsPartsTable.BrandID_LongInteger = BrandsTable.BrandID_Autonumber) ON InventoryItemsTable.ProductPartID_LongInteger = ProductsPartsTable.ProductsPartID_Autonumber) LEFT JOIN (StocksTable LEFT JOIN StocksLocationsTable ON StocksTable.StocksLocationID_LongInteger = StocksLocationsTable.StocksLocationID_AutoNumber) ON ProductsPartsTable.ProductsPartID_Autonumber = StocksTable.ProductPartID_LongInteger) LEFT JOIN ProductPartsPackingsTable ON ProductsPartsTable.ProductsPartID_Autonumber = ProductPartsPackingsTable.ProductPartID_LongInteger
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
                    InventoryItemsDataGridView.Columns.Item(i).Width = 200
                    InventoryItemsDataGridView.Columns.Item(i).Visible = True
                Case "ManufacturerPartNo_ShortText30Fld"
                    InventoryItemsDataGridView.Columns.Item(i).HeaderText = "Manufacturer Part no."
                    InventoryItemsDataGridView.Columns.Item(i).Width = 150
                    InventoryItemsDataGridView.Columns.Item(i).Visible = True
                Case "QuantityInStock_Double"
                    InventoryItemsDataGridView.Columns.Item(i).HeaderText = "Qty in Stock"
                    InventoryItemsDataGridView.Columns.Item(i).Width = 70
                    InventoryItemsDataGridView.Columns.Item(i).Visible = True
                Case "Unit_ShortText3"
                    InventoryItemsDataGridView.Columns.Item(i).HeaderText = "Unit"
                    InventoryItemsDataGridView.Columns.Item(i).Width = 70
                    InventoryItemsDataGridView.Columns.Item(i).Visible = True
                Case "BulkBalanceQuantity_Double"
                    InventoryItemsDataGridView.Columns.Item(i).HeaderText = "Bulk balance"
                    InventoryItemsDataGridView.Columns.Item(i).Width = 70
                    InventoryItemsDataGridView.Columns.Item(i).Visible = True
                Case "UnitOfTheQuantity_ShortText3"
                    InventoryItemsDataGridView.Columns.Item(i).HeaderText = " "
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
        CurrentInventoryHeaderID = InventoryItemsDataGridView.Item("InventoryHeaderID_LongInteger", CurrentInventoryItemsRow).Value
        CurrentProductPartId = InventoryItemsDataGridView.Item("ProductsPartID_Autonumber", CurrentInventoryItemsRow).Value
        FillField(CurrentlocationID, InventoryItemsDataGridView.Item("StocksLocationID_Autonumber", CurrentInventoryItemsRow).Value)
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
        FillField(UnitTextBox.Text, InventoryItemsDataGridView.Item("Unit_ShortText3", CurrentInventoryItemsRow).Value)
        FillField(QtyInBasicUnitTextBox.Text, InventoryItemsDataGridView.Item("QuantityInStock_Double", CurrentInventoryItemsRow).Value)
        FillField(LocationTextBox.Text, InventoryItemsDataGridView.Item("LocationCode_ShortText11", CurrentInventoryItemsRow).Value)
        If IsNotEmpty(InventoryItemsDataGridView.Item("QuantityPerPack_Double", CurrentInventoryItemsRow).Value) Then
            PackingTextBox.Text = InventoryItemsDataGridView.Item("QuantityPerPack_Double", CurrentInventoryItemsRow).Value.ToString & Space(1) &
                                      InventoryItemsDataGridView.Item("UnitOfTheQuantity_ShortText3", CurrentInventoryItemsRow).Value.ToString &
                                        " / " &
                                      InventoryItemsDataGridView.Item("Unit_ShortText3", CurrentInventoryItemsRow).Value.ToString
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
                If TheseAreNotEqual(SavedLocation, LocationTextBox.Text) Then
                    If MsgBox("Location Code has been changed, continue changing it ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        '                CurrentlocationID = Tunnel2
                        UpdateStocksTable(1)
                    Else
                        LocationTextBox.Text = InventoriesDataGridView.Item("LocationCode_ShortText11", CurrentInventoriesRow).Value
                        FillField(CurrentlocationID, InventoriesDataGridView.Item("LocationCode_ShortText11", CurrentInventoriesRow).Value)
                    End If
                End If
            Case "Tunnel2IsProductPartID"
                CurrentProductPartId = Tunnel2
                StockDetailsGroup.Visible = True
            Case "Tunnel2IsStocksLocationID"
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
            If MsgBox(SaveMessage, MsgBoxStyle.YesNo) = vbNo Then
                StockDetailsGroup.Visible = False
                Exit Sub
            End If
            RegisterDetailsOfThisStockInventoryChanges()
        End If
    End Sub

    Private Sub UpdateStocksTable(Mode As Integer)
        MySelection = "SELECT TOP 1  ProductPartID_LongInteger from StocksTable WHERE ProductPartID_LongInteger = " & CurrentProductPartId
        JustExecuteMySelection()
        If RecordCount = 0 Then
            'Insert a new Stock record for this product
            InsertNewRecord("StocksTable", "ProductPartID_LongInteger", CurrentProductPartId.ToString)
        End If
        Select Case Mode
            Case 1
                'update the location code' this occurs when during entry the location code is changed
                Dim SetCommand = " SET StocksLocationID_LongInteger = " & CurrentlocationID.ToString
                Dim RecordFilter = " WHERE ProductPartID_LongInteger = " & CurrentProductPartId

                UpdateTable("StocksTable", SetCommand, RecordFilter)
            Case 2
                'update the quantities  this occurs during batch update
                Dim SetCommand = " SET QuantityInStock_Double = " & QtyInBasicUnitTextBox.Text & ", " &
                                "BulkBalanceQuantity_Double = " & BulkBalanceTextBox.Text
                Dim RecordFilter = " WHERE ProductPartID_LongInteger = " & CurrentProductPartId

                UpdateTable("StocksTable", SetCommand, RecordFilter)
            Case Else
                Exit Select
        End Select
    End Sub

    Private Function AChangeInThisStockInventoryDetailsOccurred()
        '*******************************************************
        'Test 1st if a Part/Product is selected and this is the 1st entry in the list
        If CurrentProductPartId > 0 And CurrentInventoriesRow = -1 Then Return True
        ' THIS ROUTINE DETERMINES ALSO IF THE PURPOSE OF ENTRY = "ADD OR EDIT
        If TheseAreNotEqual(QtyInBasicUnitTextBox.Text, InventoriesDataGridView.Item("QuantityInStock_Double", CurrentInventoriesRow).Value) Then Return True
        If TheseAreNotEqual(BulkBalanceTextBox.Text, InventoriesDataGridView.Item("MinimumQuantityPerSpecs_Double", CurrentInventoriesRow).Value) Then Return True
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
    End Sub
    Private Sub UpdateCurrentInventoryItemId()
        Dim SetCommand = " SET StocksLocationID_LongInteger = " & CurrentlocationID.ToString & ", " &
                                "StockID_LongInteger = " & CurrentProductPartId.ToString
        Dim RecordFilter = " WHERE InventoryHeaderID_LongInteger = -1 AND " & CurrentProductPartId.ToString

        UpdateTable("StocksTable", SetCommand, RecordFilter)

    End Sub
    Private Sub AddNewInventoryItem()
        Dim FieldsToUpdate = " ProductPartID_LongInteger, 
                                InventoryQtyInStock_Double, 
                                InventoryBulkBalanceQty_Double "

        Dim FieldsData = CurrentProductPartId.ToString & ", " &
                             Val(QtyInBasicUnitTextBox.Text).ToString & ", " &
                             Val(BulkBalanceTextBox.Text).ToString

        Dim XXXdUMMY = InsertNewRecord("InventoryItemsTable", FieldsToUpdate, FieldsData)
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

End Class