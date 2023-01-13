Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class InventoriesForm
    Private InventoryHeadersFieldsToSelect = ""
    Private InventoryHeadersSelectionFilter = ""
    Private InventoryHeadersSelectionOrder = ""
    Private CurrentInventoryHeadersRow As Integer = -1
    Private InventoryHeadersRecordCount As Integer = -1
    Private CurrentInventoryHeaderID = -1
    Private InventoryHeadersDataGridViewAlreadyFormated = False
    Private CurrentInventoryStatus = ""
    Private InventoryItemsFieldsToSelect = ""
    Private InventoryItemsSelectionFilter = ""
    Private InventoryItemsSelectionOrder = ""
    Private CurrentInventoryItemsRow As Integer = -1
    Private InventoryItemsRecordCount As Integer = -1
    Private CurrentInventoryItemID = -1
    Private InventoryItemsDataGridViewAlreadyFormated = False
    Private CurrentInventoryQtyInStock = -1
    Private CurrentInventoryBulkBalanceQty = -1

    Private CurrentProductsPartsPackingRelationID = -1
    Private SavedCallingForm As Form
    Private CurrentlocationID = -1
    Private CurrentStockID = -1
    Private CurrentProductPartId = -1
    Private Property SaveMessage As String

    Private Sub InventoryHeadersForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' SEE FORM InventoriesForm DOCUMENTATION
        SavedCallingForm = CallingForm
        InventoryHeadersSelectionFilter = "  WHERE StatusText_ShortText25 <> " & InQuotes("Registered")
        FillInventoryHeadersDataGridView()
        InventoryHeadersGroupBox.Top = BottomOf(SearchToolStrip)
        InventoryHeadersGroupBox.Left = Me.Left
        HorizontalCenter(InventoryDetailsGroup, Me)
        VerticalCenter(InventoryDetailsGroup, Me)
        InventoryDetailsGroup.Visible = False

    End Sub
    Private Sub FillInventoryHeadersDataGridView()
        InventoryHeadersSelectionOrder = " ORDER BY InventoryDate_ShortDate DESC"
        InventoryHeadersFieldsToSelect =
" 
Select  
InventoryHeadersTable.InventoryHeaderID_AutoNumber, 
InventoryHeadersTable.InventoryDate_ShortDate, 
StatusesTable.StatusText_ShortText25, 
PersonnelFullName.PersonnelFullName
FROM (InventoryHeadersTable LEFT JOIN StatusesTable ON InventoryHeadersTable.InventoryStatus_Integer = StatusesTable.StatusID_Autonumber) LEFT JOIN PersonnelFullName ON InventoryHeadersTable.StoreKeeperID_LongInteger = PersonnelFullName.PersonnelID_AutoNumber
"
        MySelection = InventoryHeadersFieldsToSelect & InventoryHeadersSelectionFilter & InventoryHeadersSelectionOrder

        JustExecuteMySelection()
        InventoryHeadersRecordCount = RecordCount
        If InventoryHeadersRecordCount = 0 Then
            CurrentInventoryHeaderID = -1
            InventoryItemsSelectionFilter = "WHERE InventoryHeaderID_LongInteger = -1 "
            FillInventoryItemsDataGridView()
        End If
        If InventoryHeadersRecordCount < 2 Then
            InventoryHeadersDataGridView.Visible = False
            InventoryItemsGroupBox.Top = BottomOf(SearchToolStrip)
            InventoryItemsGroupBox.Left = 2
        Else
            InventoryHeadersDataGridView.Visible = False
            InventoryItemsGroupBox.Top = BottomOf(InventoryHeadersGroupBox)
            InventoryItemsGroupBox.Left = InventoryHeadersGroupBox.Left + InventoryHeadersGroupBox.Width
        End If
        InventoryHeadersDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable


        If Not InventoryHeadersDataGridViewAlreadyFormated Then
            FormatInventoryHeadersDataGridView()
        End If

        SetGroupBoxHeight(25, InventoryHeadersRecordCount, InventoryHeadersGroupBox, InventoryHeadersDataGridView)

    End Sub
    Private Sub FormatInventoryHeadersDataGridView()
        InventoryHeadersDataGridViewAlreadyFormated = True
        InventoryHeadersGroupBox.Width = 0
        For i = 0 To InventoryHeadersDataGridView.Columns.GetColumnCount(0) - 1

            InventoryHeadersDataGridView.Columns.Item(i).Visible = False
            Select Case InventoryHeadersDataGridView.Columns.Item(i).Name
                Case "InventoryDate_ShortDate"
                    InventoryHeadersDataGridView.Columns.Item(i).HeaderText = "Date"
                    InventoryHeadersDataGridView.Columns.Item(i).Width = 100
                    InventoryHeadersDataGridView.Columns.Item(i).Visible = True
                Case "StatusText_ShortText25"
                    InventoryHeadersDataGridView.Columns.Item(i).HeaderText = "Status"
                    InventoryHeadersDataGridView.Columns.Item(i).Width = 150
                    InventoryHeadersDataGridView.Columns.Item(i).Visible = True
                Case "PersonnelFullName"
                    InventoryHeadersDataGridView.Columns.Item(i).HeaderText = "Store Keeper"
                    InventoryHeadersDataGridView.Columns.Item(i).Width = 200
                    InventoryHeadersDataGridView.Columns.Item(i).Visible = True

            End Select

            If InventoryHeadersDataGridView.Columns.Item(i).Visible = True Then
                InventoryHeadersGroupBox.Width = InventoryHeadersGroupBox.Width + InventoryHeadersDataGridView.Columns.Item(i).Width
            End If
        Next
        If InventoryHeadersGroupBox.Width > VehicleManagementSystemForm.Width Then
            InventoryHeadersGroupBox.Width = VehicleManagementSystemForm.Width - 4
        End If
    End Sub
    Private Sub InventoryHeadersDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles InventoryHeadersDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If InventoryHeadersRecordCount = 0 Then Exit Sub

        CurrentInventoryHeadersRow = e.RowIndex
        CurrentInventoryHeaderID = InventoryHeadersDataGridView.Item("InventoryHeaderID_AutoNumber", CurrentInventoryHeadersRow).Value
        CurrentInventoryStatus = InventoryHeadersDataGridView.Item("StatusText_ShortText25", CurrentInventoryHeadersRow).Value
        InventoryItemsSelectionFilter = "WHERE InventoryHeaderID_LongInteger = -1 "
        Select Case CurrentInventoryStatus
            Case "Registered"
                SetOptions(1)
                InventoryItemsSelectionFilter = "WHERE InventoryHeaderID_LongInteger = -1 " & CurrentInventoryHeaderID.ToString
            Case "For Approval"
                SetOptions(2)
            Case "Approved"
                SetOptions(3)

        End Select
        FillInventoryItemsDataGridView()
    End Sub
    Private Sub SetOptions(Mode)
        '1 - Registered Status
        '2 - For Approval
        '3 - Approved
        AddInventoryToolStripMenuItem.Visible = False
        EditInventoryDetailsToolStripMenuItem.Visible = False
        DeleteInventoryItemToolStripMenuItem.Visible = False
        SaveInventoryDetailsToolStripMenuItem.Visible = False
        SubmitForApprovalToolStripMenuItem.Visible = False
        ApproveToolStripMenuItem.Visible = False
        RegisterInventoryToolStripMenuItem.Visible = False
        If Mode = 2 Then
            If CurrentUserGroup = "Warehouse Manager" Then
                ApproveToolStripMenuItem.Visible = True
            Else

                MsgBox("Change this when there is already a Warehouse Manager user")
                MsgBox("ApproveToolStripMenuItem.Visible = False")
                ApproveToolStripMenuItem.Visible = True
            End If
        End If
        If Mode = 3 Then
            RegisterInventoryToolStripMenuItem.Visible = True
        End If
    End Sub
    Private Sub FillInventoryItemsDataGridView()
        PrintInventoryToolStripMenuItem.Visible = False
        InventoryItemsSelectionOrder = " ORDER BY LocationCode_ShortText11, PartSpecifications_ShortText255, SystemDesc_ShortText100Fld DESC "
        InventoryItemsFieldsToSelect = "
SELECT 
InventoryItemsTable.InventoryItemID_Autonumber,
InventoryItemsTable.InventoryHeaderID_LongInteger,
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
BrandsTable.BrandName_ShortText20, 
Packings.ProductsPartsPackingRelationID_AutoNumber, 
Packings.Packing,
BrandsTable.BrandID_Autonumber
FROM (((InventoryItemsTable LEFT JOIN InventoryHeadersTable ON InventoryItemsTable.InventoryHeaderID_LongInteger = InventoryHeadersTable.InventoryHeaderID_AutoNumber) LEFT JOIN (((ProductsPartsTable LEFT JOIN MasterCodeBookTable ON ProductsPartsTable.MasterCodeBookID_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) LEFT JOIN PartsSpecificationsTable ON ProductsPartsTable.PartsSpecificationID_LongInteger = PartsSpecificationsTable.PartsSpecificationID_AutoNumber) LEFT JOIN BrandsTable ON ProductsPartsTable.BrandID_LongInteger = BrandsTable.BrandID_Autonumber) ON InventoryItemsTable.ProductPartID_LongInteger = ProductsPartsTable.ProductsPartID_Autonumber) LEFT JOIN (StocksTable LEFT JOIN StocksLocationsTable ON StocksTable.StocksLocationID_LongInteger = StocksLocationsTable.StocksLocationID_AutoNumber) ON ProductsPartsTable.ProductsPartID_Autonumber = StocksTable.ProductPartID_LongInteger) INNER JOIN (ProductsPartsPackingRelationsTable LEFT JOIN Packings ON ProductsPartsPackingRelationsTable.ProductsPartsPackingRelationID_AutoNumber = Packings.ProductsPartsPackingRelationID_AutoNumber) ON InventoryItemsTable.ProductsPartsPackingRelationID_LongInteger = ProductsPartsPackingRelationsTable.ProductsPartsPackingRelationID_AutoNumber
"
        MySelection = InventoryItemsFieldsToSelect & InventoryItemsSelectionFilter & InventoryItemsSelectionOrder
        JustExecuteMySelection()
        InventoryItemsRecordCount = RecordCount

        InventoryItemsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable


        If Not InventoryItemsDataGridViewAlreadyFormated Then
            FormatInventoryItemsDataGridView()
        End If

        SetGroupBoxHeight(24, InventoryItemsRecordCount, InventoryItemsGroupBox, InventoryItemsDataGridView)

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
                Case "ManufacturerDescription_ShortText250"
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
                Case "LocationCode_ShortText11"
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

        If CurrentInventoryHeaderID = -1 Then
            RegisterInventoryToolStripMenuItem.Visible = True
            PrintInventoryToolStripMenuItem.Visible = True
        End If
    End Sub
    Private Sub EditProductToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditInventoryDetailsToolStripMenuItem.Click
        LoadProductDetails()
        InventoryDetailsGroup.Visible = True
        SetupEditMode()
    End Sub
    Private Sub StockDetailsGroup_VisibleChanged(sender As Object, e As EventArgs) Handles InventoryDetailsGroup.VisibleChanged
        If InventoryDetailsGroup.Visible Then
            SetupEditMode()
        Else
            SetupBrowseMode()
        End If
    End Sub
    Private Sub SetupEditMode()
        ViewInventoriesToolStripMenuItem.Visible = False
        AddInventoryToolStripMenuItem.Visible = False
        EditInventoryDetailsToolStripMenuItem.Visible = False
        DeleteInventoryItemToolStripMenuItem.Visible = False
        SaveInventoryDetailsToolStripMenuItem.Visible = True
        RegisterInventoryToolStripMenuItem.Visible = False
        PrintInventoryToolStripMenuItem.Visible = False
    End Sub
    Private Sub SetupBrowseMode()
        ViewInventoriesToolStripMenuItem.Visible = True
    End Sub
    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteInventoryItemToolStripMenuItem.Click
        If MsgBox("Continue delete this item?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            MySelection = " DELETE FROM InventoryItemsTable WHERE InventoryItemID_Autonumber =  " & CurrentInventoryItemID
            JustExecuteMySelection()
        End If

        FillInventoryItemsDataGridView()
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
        If PackingTextBox.Text = "" Then
            PackingTextBox.Visible = False
            Label3.Visible = False
        End If
    End Sub
    Private Sub InventoryHeadersForm_EnabledChanged(sender As Object, e As EventArgs) Handles MyBase.EnabledChanged
        If Me.Enabled = False Then Exit Sub
        CallingForm = SavedCallingForm

        Select Case Tunnel1
            Case "Tunnel2IsProductPartID"
                If CurrentProductPartId = Tunnel2 Then Exit Sub
                MySelection = " SELECT * FROM InventoryItemsTable 
                                    WHERE ProductPartID_LongInteger = " & Tunnel2 &
                                    "  AND ProductsPartsPackingRelationID_LongInteger = " & Tunnel4
                JustExecuteMySelection()
                If RecordCount > 0 Then
                    MsgBox(ManufacturerPartDescTextBox.Text & vbCrLf & " in " & UnitTextBox.Text & vbCrLf & "ALREADY IN THE LIST")
                    Exit Sub
                End If
                CurrentProductPartId = Tunnel2
                InventoryDetailsGroup.Visible = True
                'SELECTED PRODUCT DETAILS HAS BEEN UPDATED BY ProductsPartsForm
                ResetQuantityDetailsGroup()
                CurrentProductsPartsPackingRelationID = Tunnel4
                '--------------------
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
                            LocationTextBox.Text = InventoryHeadersDataGridView.Item("LocationCode_ShortText11", CurrentInventoryHeadersRow).Value
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
                '-------------------
        End Select
    End Sub
    Private Sub ResetQuantityDetailsGroup()
        QtyInBasicUnitTextBox.Text = "0"
        BulkBalanceTextBox.Text = "0"
        QtyInBasicUnitTextBox.Select()
    End Sub

    Private Sub ReturnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnToolStripMenuItem.Click
        If InventoryDetailsGroup.Visible = True Then
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
                InventoryDetailsGroup.Visible = False
                Exit Sub
            End If
            RegisterDetailsOfThisStockInventoryChanges()
        End If

    End Sub

    Private Sub UpdateStocksTable(Mode As Integer)
        'CHECK IF THIS PRODUCT PART EXISTS IN THE StocksTable
        MySelection = "SELECT TOP 1  ProductPartID_LongInteger from StocksTable WHERE ProductPartID_LongInteger = " & CurrentProductPartId &
                        " AND ProductsPartsPackingRelationID_LongInteger = " & CurrentProductsPartsPackingRelationID
        JustExecuteMySelection()
        If RecordCount = 0 Then
            'Insert a new Stock record for this product
            Dim FieldsToUpdate = " ProductPartID_LongInteger, ProductsPartsPackingRelationID_LongInteger "
            Dim FieldsData = CurrentProductPartId.ToString & ", " & CurrentProductsPartsPackingRelationID.ToString
            CurrentStockID = InsertNewRecord("StocksTable", FieldsToUpdate, FieldsData)
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
        If CurrentProductPartId > 0 And CurrentInventoryHeadersRow = -1 Then Return True
        ' THIS ROUTINE DETERMINES ALSO IF THE PURPOSE OF ENTRY = "ADD Or EDIT
        If TheseAreNotEqual(QtyInBasicUnitTextBox.Text, InventoryHeadersDataGridView.Item("InventoryQtyInStock_Double", CurrentInventoryHeadersRow).Value) Then Return True
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
        InventoryDetailsGroup.Visible = False
        FillInventoryItemsDataGridView()
    End Sub
    Private Sub SaveThisStockInventoryDetailsChanges()
        If CurrentInventoryItemID = -1 Then
            AddNewInventoryItem()
        Else
            UpdateCurrentInventoryItemId()
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
        CurrentInventoryItemID = -1
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
        MsgBox("Fix this, Ammend this routine, Updating should be throug the StocksForm")
        If Not LocationTextBox.Text = "" Then
            If MsgBox("Would you like to change the Location ? ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        End If
        MsgBox("-Updating the location should be done in the the StocksForm")
        MsgBox(" Updating should only be allowed to this specific product part And packing ")
        Tunnel1 = "Tunnel2IsProductsPartsID"
        Tunnel2 = CurrentProductPartId
        Tunnel3 = CurrentProductsPartsPackingRelationID
        ShowCalledForm(Me, StocksForm)
    End Sub

    Private Sub UnitTextBox_Click(sender As Object, e As EventArgs) Handles UnitTextBox.Click
        MsgBox("DELETE THIS ROUTINE")
    End Sub
    Private Sub SubmitForApprovalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SubmitForApprovalToolStripMenuItem.Click
        ' UPDATE ALL THE OUTSTANDING InventoryItems with the CurrentInventoryHeaderID
        Dim SetCommand = " SET InventoryHeaderID_LongInteger = " & CurrentInventoryHeaderID.ToString &
                            GetStatusIdFor("InventoryHeadersTable", "For Approval").ToString()
        Dim Recordfilter = " WHERE InventoryHeaderID_LongInteger = -1 " & CurrentInventoryHeaderID
        UpdateTable("InventoryItemsTable", SetCommand, Recordfilter)
        FillInventoryHeadersDataGridView()
        Exit Sub

        If MsgBox("Setting status FOR APPROVAL will not allow editing of this list anymore," & vbCrLf & vbCrLf &
               "Continue ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        ' CREATE THE HEADER RECORDS FOR THE WHOLE OUTSTANDING INVENTORY
        Dim FieldsToUpdate = " StoreKeeperID_LongInteger, InventoryStatus_Integer "
        Dim FieldsData = CurrentPersonelID.ToString & ", " & GetStatusIdFor("InventoryHeadersTable").ToString
        CurrentInventoryHeaderID = InsertNewRecord("InventoryHeadersTable", FieldsToUpdate, FieldsData)







        FillInventoryHeadersDataGridView()
    End Sub
    Private Sub ApproveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApproveToolStripMenuItem.Click
        Dim SetCommand = " SET InventoryStatus_Integer = " & GetStatusIdFor("InventoryHeadersTable", "Approved").ToString
        Dim Recordfilter = " WHERE InventoryHeaderID_AutoNumber = " & CurrentInventoryHeaderID
        UpdateTable("InventoryHeadersTable", SetCommand, Recordfilter)
        FillInventoryHeadersDataGridView()
    End Sub

    Private Sub RegisterInventoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegisterInventoryToolStripMenuItem.Click
        ' check if list is not empty
        FillInventoryItemsDataGridView()
        If InventoryItemsRecordCount < 1 Then Exit Sub
        Dim FieldsToUpdate = ""
        Dim FieldsData = ""
        Dim SelectionFilter = ""
        Dim OldInventoryQtyInStock = -1
        Dim OldInventoryBulkBalanceQty = -1
        Dim ThereAreNewStocksRecords = False

        'DESELECT CURRENTLY SELECTED InventoryItemsDataGridView ROW
        InventoryItemsDataGridView.Rows(CurrentInventoryHeadersRow).Selected = False
        For CurrentInventoryItemsRow = 0 To InventoryItemsRecordCount - 1
            'NOTE YOU CAN USE A LOCAL VARIABLE AS VARIABLE NAME FOR THE COUNTER
            'BECAUSE THE LOOP INCREMENTS ONLY ITS OWN CREATE LOCAL VARIABLE WITH THE SAME NAME
            'OUTSIDE THE LOOP THE VARIABLE WITH THE SAME NAME WILL REFERERENCE THE ORIGINAL VARIABLE
            'all needed informations here will be updated in the DataGrid.rows(selected)
            InventoryItemsDataGridView.Rows(CurrentInventoryItemsRow).Selected = True
            SelectionFilter = "WHERE ProductPartID_LongInteger = " & CurrentProductPartId.ToString &
                              "   AND ProductsPartsPackingRelationID_LongInteger = " & CurrentProductsPartsPackingRelationID.ToString
            MySelection = " SELECT * FROM StocksTAble " & SelectionFilter
            JustExecuteMySelection()
            If RecordCount = 0 Then
                FieldsToUpdate = " ProductPartID_LongInteger,
                                   ProductsPartsPackingRelationID_LongInteger,
                                   QuantityInStock_Double,
                                   BulkBalanceQuantity_Double
"
                FieldsData = CurrentProductPartId.ToString & ", " &
                         CurrentProductsPartsPackingRelationID.ToString & ", " &
                         CurrentInventoryQtyInStock.ToString & ", " &
                         CurrentInventoryBulkBalanceQty.ToString


                'SINCE FUNCTION InsertNewRecord() ALWAYS RETURNS THE CURRENTLY INSERTED RECORD
                Dim SavedStockID = CurrentStockID
                CurrentStockID = InsertNewRecord("StocksTable", FieldsToUpdate, FieldsData, True)
                If CurrentStockID <> CurrentStockID Then
                    CurrentStockID = SavedStockID
                End If
            End If

            'HERE REGISTER THE OLD QUANTITIES FIRST

            Dim SetCommand = " SET ReplacedQtyInStock_Double = " & CurrentInventoryQtyInStock.ToString & ", " &
                         " ReplacedBulkBalanceQty_Double = " & CurrentInventoryBulkBalanceQty.ToString
            Dim RecordFilter = " WHERE InventoryItemID_Autonumber = " & CurrentInventoryItemID.ToString

            UpdateTable("InventoryItemsTable", SetCommand, RecordFilter)

            'NOW UPDATE THE STOCKSTABLE QUANTITIES

            GetCurrentStockID()
            FillField(CurrentInventoryQtyInStock, InventoryItemsDataGridView.Item("InventoryQtyInStock_Double", CurrentInventoryItemsRow).Value)
            FillField(CurrentInventoryBulkBalanceQty, InventoryItemsDataGridView.Item("InventoryBulkBalanceQty_Double", CurrentInventoryItemsRow).Value)


            SetCommand = " SET QuantityInStock_Double = " & CurrentInventoryQtyInStock.ToString & ", " &
                         " BulkBalanceQuantity_Double = " & CurrentInventoryBulkBalanceQty.ToString
            RecordFilter = " WHERE StockID_Autonumber = " & CurrentStockID.ToString
            UpdateTable("StocksTable", SetCommand, RecordFilter)
            'AND THEN THE 
        Next
    End Sub
    Private Function GetCurrentStockID()
        Dim SelectionFilter = "WHERE ProductPartID_LongInteger = " & CurrentProductPartId.ToString &
                              "   AND ProductsPartsPackingRelationID_LongInteger = " & CurrentProductsPartsPackingRelationID.ToString
        MySelection = " SELECT * FROM StocksTAble " & SelectionFilter
        JustExecuteMySelection()

        If RecordCount = 0 Then
            MsgBox("Something is wrong")
            Return -1
        Else
            Dim r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
            CurrentStockID = r("StockID_Autonumber")
            CurrentInventoryQtyInStock = r("QuantityInStock_Double")
            CurrentInventoryBulkBalanceQty = r("BulkBalanceQuantity_Double")
        End If
        Return CurrentStockID
    End Function

    Private Sub ResetForApprovalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetForApprovalToolStripMenuItem.Click
        If MsgBox("Are you sure you want to reset for editing ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        MySelection = "DELETE FROM InventoryHeadersTable WHERE InventoryHeaderID_AutoNumber = " & CurrentInventoryHeaderID.ToString
        JustExecuteMySelection()
        FillInventoryHeadersDataGridView()
    End Sub

    Private Sub LocationTextBox_TextChanged(sender As Object, e As EventArgs) Handles LocationTextBox.TextChanged

    End Sub

    Private Sub InventoryItemsDataGridView_SelectionChanged(sender As Object, e As EventArgs) Handles InventoryItemsDataGridView.SelectionChanged
        Try
            ' OPEN A CONNECTION
            CurrentProductPartId = InventoryItemsDataGridView.Item("ProductsPartID_Autonumber", CurrentInventoryItemsRow).Value
            FillField(CurrentInventoryItemID, InventoryItemsDataGridView.Item("InventoryItemID_Autonumber", CurrentInventoryItemsRow).Value)
            FillField(CurrentProductsPartsPackingRelationID, InventoryItemsDataGridView.Item("ProductsPartsPackingRelationID_AutoNumber", CurrentInventoryItemsRow).Value)
            FillField(CurrentlocationID, InventoryItemsDataGridView.Item("StocksLocationID_Autonumber", CurrentInventoryItemsRow).Value)
            FillField(CurrentStockID, InventoryItemsDataGridView.Item("StockID_AutoNumber", CurrentInventoryItemsRow).Value)
        Catch ex As Exception
            If ex.Message = "Index was out of range. Must be non-negative and less than the size of the collection.
Parameter name: index" Then
                Exit Sub
            End If
            MsgBox(ex.Message)
            Stop
        End Try
    End Sub
End Class