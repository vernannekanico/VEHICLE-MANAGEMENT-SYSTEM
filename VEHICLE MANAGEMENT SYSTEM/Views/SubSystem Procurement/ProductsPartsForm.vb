Imports System.Data.SqlClient

Public Class ProductsPartsForm
    Private ProductsPartsFieldsToSelect = " "
    Private ProductsPartsSelectionFilter = " "
    Private ProductsPartsSelectionOrder = " "
    Private ProductsPartsRecordCount = 0
    Private CurrentProductPartID As Integer = -1
    Private CurrentProductsPartsRow = -1
    Private ProductsPartsDataGridViewAlreadyFormated = False

    Private ProductsPartsPackingsFieldsToSelect = ""
    Private ProductsPartsPackingsSelectionFilter = ""
    Private ProductsPartsPackingsSelectionOrder = ""
    Private ProductsPartsPackingsRecordCount As Integer = -1
    Private CurrentProductsPartsPackingsRow As Integer = -1
    Private CurrentProductsPartsPackingID = -1
    Private ProductsPartsPackingsDataGridViewAlreadyFormated = False
    Private CurrentProductsPartsPackingRelationID = -1

    Private CleanedManufacturerPartNo = ""
    Private PurposeOfEntry As String
    Private CurrentMasterCodeBookID = -1
    Private CurrentBrandID = -1
    Private CurrentStocksID = -1
    Private SavedCallingForm As Form
    Private BackToEditMode = False
    Private CurrentProductSpecificationID = -1

    Private HistoriesFieldsToSelect = ""
    Private HistoriesSelectionFilter = ""
    Private HistoriesSelectionOrder = ""
    Private HistoriesRecordCount As Integer = -1
    Private CurrentHistoriesRow As Integer = -1
    Private CurrentWorkOrderPartID = -1
    Private CurrentPurchaseOrderItemID = -1
    Private CurrentWorkOrderPartStatus As String
    Private HistoriesDataGridViewAlreadyFormated = False
    Private HistoryMode = 1

    Public CurrentVehicleID = -1
    Private ForDeletionRecord_YesNo As Boolean

    Private Sub ProductsPartsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        SavedCallingForm = CallingForm
        'NOTE  
        '      Tunnel2 = CurrentMasterCodeBookID
        VerticalCenter(FiltersGroupBox, Me)
        HorizontalCenter(FiltersGroupBox, Me)
        VerticalCenter(ProductDetailsGroup, Me)
        HorizontalCenter(ProductDetailsGroup, Me)
        '  VerticalCenter(HistoriesGroupBox, Me)
        ProductSpecificationTextBox.Enabled = True
        Me.Top = VehicleManagementSystemForm.VehicleManagementMenuStrip.Top +
                VehicleManagementSystemForm.VehicleManagementMenuStrip.Height
        'NOTE: FILL PRODUCTS IS ALREADY IN THE ExecuteSearchParameters()
        CurrentMasterCodeBookID = Tunnel2

        If Tunnel1 = "Tunnel2IsProductPartID" Then
            CurrentProductPartID = Tunnel2
            ProductsPartsSelectionFilter = " WHERE ProductsPartID_Autonumber = " & CurrentProductPartID.ToString
            FillProductsPartsDataGridView()
            CurrentStocksID = GetFieldValue("StocksTable", "ProductPartID_LongInteger", CurrentProductPartID, "StockID_Autonumber")
            ProductsPartsMenuStrip.Visible = False
            SystemPartDescriptionTextBox.Enabled = True
            SetupEditMode()

            If IsEmpty(ProductsPartsDataGridView.Item("SystemDesc_ShortText100Fld", CurrentProductsPartsRow).Value) Then
                MsgBox("This Product is not linked to the MasterCodeBook, link this as " & SystemPartDescriptionTextBox.Text & "?")
                ShowMasterCodeBookForm()
            End If
            Exit Sub
        End If
        If IsNotEmpty(PartDescriptionSearchTextBox.Text) Or Tunnel2 > -1 Or IsNotEmpty(PartNoSearchTextBox.Text) Or
            IsNotEmpty(ProductSpecificationSearchTextBox.Text) Then
            SetSearchParameters()
            FillProductsPartsDataGridView()
        End If
        FillProductsPartsDataGridView()
    End Sub
    Private Sub ProductsPartsForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        If Me.Enabled = False Then Exit Sub
        CallingForm = SavedCallingForm

        ' GET RETURNED DATA HERE
        Select Case Tunnel1
            Case "Tunnel2IsPartsSpecificationsID"
                CurrentProductSpecificationID = Tunnel2
            Case "Tunnel2IsBrandID"
                CurrentBrandID = Tunnel2
            Case "Tunnel2IsProductPartsPackingID"
                CurrentProductsPartsPackingID = Tunnel2
            Case "Tunnel2IsMasterCodeBookID"
                ProductDetailsGroup.Visible = True
                ProductDetailsGroup.BringToFront()
                CurrentMasterCodeBookID = Tunnel2
                SelectToolStripMenuItem.Visible = True
                SystemPartDescriptionTextBox.Text = Tunnel3
            Case "Tunnel2IsProductsPartsPackingRelationID"
                CurrentProductsPartsPackingRelationID = Tunnel2
                UnitTextBox.Text = Tunnel4
                If IsNotEmpty(Tunnel3) Then
                    PackingTextBox.Text = Tunnel3
                    PackingTextBox.Visible = True
                    Label3.Visible = True
                Else
                    PackingTextBox.Visible = False
                    Label3.Visible = False
                End If
                '                Tunnel3 = ProductPartsPackingRelationsDataGridView.Item("Packing", CurrentProductPartsPackingRelationsRow).Value.ToString
                '               Tunnel4 = ProductPartsPackingRelationsDataGridView.Item("UnitOfTheQuantity_ShortText3", CurrentProductPartsPackingRelationsRow).Value
        End Select

    End Sub
    Private Sub FillProductsPartsDataGridView()

        ProductsPartsFieldsToSelect = "
SELECT ProductsPartsTable.Selected, 
ProductsPartsTable.MasterCodeBookID_LongInteger, 
MasterCodeBookTable.SubSystemCode_ShortText24Fld, 
MasterCodeBookTable.SystemDesc_ShortText100Fld, 
PartsSpecificationsTable.PartsSpecificationID_AutoNumber, 
PartsSpecificationsTable.PartSpecifications_ShortText255, 
ProductsPartsTable.ManufacturerPartNo_ShortText30Fld, 
ProductsPartsTable.ManufacturerDescription_ShortText250, 
Packings.ProductsPartsPackingRelationID_AutoNumber,
Packings.QuantityPerPack_Double, 
Packings.UnitOfTheQuantity_ShortText3, 
Packings.UnitOfThePacking_ShortText3, 
Packings.Packing,
ProductsPartsTable.ProductDescription_ShortText250, 
BrandsTable.BrandName_ShortText20, 
ProductsPartsTable.WorkOrderItemID_LongInteger, 
ProductsPartsTable.Unit_ShortText3, 
BrandsTable.BrandID_Autonumber, 
ProductsPartsTable.ProductsPartID_Autonumber
FROM ((((ProductsPartsTable LEFT JOIN BrandsTable ON ProductsPartsTable.BrandID_LongInteger = BrandsTable.BrandID_Autonumber) LEFT JOIN MasterCodeBookTable ON ProductsPartsTable.MasterCodeBookID_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) LEFT JOIN PartsSpecificationsTable ON ProductsPartsTable.PartsSpecificationID_LongInteger = PartsSpecificationsTable.PartsSpecificationID_AutoNumber) LEFT JOIN ProductsPartsPackingRelationsTable ON ProductsPartsTable.ProductsPartID_Autonumber = ProductsPartsPackingRelationsTable.ProductPartID_LongInteger) LEFT JOIN Packings ON ProductsPartsPackingRelationsTable.ProductsPartsPackingRelationID_AutoNumber = Packings.ProductsPartsPackingRelationID_AutoNumber"
        ProductsPartsFieldsToSelect = 
"
        Select ProductsPartsTable.Selected, ProductsPartsTable.MasterCodeBookID_LongInteger, MasterCodeBookTable.SubSystemCode_ShortText24Fld, MasterCodeBookTable.SystemDesc_ShortText100Fld, PartsSpecificationsTable.PartsSpecificationID_AutoNumber, PartsSpecificationsTable.PartSpecifications_ShortText255, ProductsPartsTable.ManufacturerPartNo_ShortText30Fld, ProductsPartsTable.ManufacturerDescription_ShortText250, ProductsPartsTable.ProductDescription_ShortText250, BrandsTable.BrandName_ShortText20, ProductsPartsTable.WorkOrderItemID_LongInteger, ProductsPartsTable.Unit_ShortText3, BrandsTable.BrandID_Autonumber, ProductsPartsTable.ProductsPartID_Autonumber, Packings.QuantityPerPack_Double, Packings.UnitOfTheQuantity_ShortText3, Packings.UnitOfThePacking_ShortText3, Packings.Packing, Packings.ProductsPartsPackingRelationID_AutoNumber
FROM ((((ProductsPartsTable LEFT JOIN BrandsTable ON ProductsPartsTable.BrandID_LongInteger = BrandsTable.BrandID_Autonumber) LEFT JOIN MasterCodeBookTable ON ProductsPartsTable.MasterCodeBookID_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) LEFT JOIN PartsSpecificationsTable ON ProductsPartsTable.PartsSpecificationID_LongInteger = PartsSpecificationsTable.PartsSpecificationID_AutoNumber) LEFT JOIN ProductsPartsPackingRelationsTable ON ProductsPartsTable.ProductsPartID_Autonumber = ProductsPartsPackingRelationsTable.ProductPartID_LongInteger) LEFT JOIN Packings ON ProductsPartsPackingRelationsTable.ProductsPartsPackingRelationID_AutoNumber = Packings.ProductsPartsPackingRelationID_AutoNumber"

        MySelection = ProductsPartsFieldsToSelect & ProductsPartsSelectionFilter & ProductsPartsSelectionOrder
        JustExecuteMySelection()
        ProductsPartsRecordCount = RecordCount

        ProductsPartsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If Not ProductsPartsDataGridViewAlreadyFormated Then
            FormatProductsPartsDataGridView()
            ProductsPartsDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        End If
        Dim AvailableHeightSpace = VehicleManagementSystemForm.Height -
                                    (ProductsPartsMenuStrip.Top + ProductsPartsMenuStrip.Height) +
                                    ProductsPartsDataGridView.ColumnHeadersHeight
        Dim MyMaximumHeight = VehicleManagementSystemForm.Height -
                                  VehicleManagementSystemForm.VehicleManagementMenuStrip.Top

        Dim RowsHeight = 0
        If CurrentProductsPartsRow > -1 Then
            For i = 0 To ProductsPartsRecordCount - 1
                RowsHeight += RowsHeight + ProductsPartsDataGridView.Rows(i).Height
                If RowsHeight > AvailableHeightSpace Then Exit For
            Next
            If RowsHeight > AvailableHeightSpace Then
                ProductsPartsDataGridView.Height = AvailableHeightSpace - 120
            Else
                ProductsPartsDataGridView.Height = RowsHeight + ProductsPartsDataGridView.ColumnHeadersHeight
            End If
        End If
        ProductsPartsDataGridView.Height += RowsHeight
        If ProductsPartsDataGridView.Height > MyMaximumHeight Then
            Me.Height = ProductsPartsDataGridView.Height + 20
        Else
            Me.Height = MyMaximumHeight
        End If
        ProductDetailsGroup.Top = BottomOf(ProductsPartsMenuStrip)
        ProductsPartsDataGridView.Top = ProductsPartsMenuStrip.Top + ProductsPartsMenuStrip.Height
        '---------------------------------------------------------------------

        SetGroupBoxHeight(20, ProductsPartsRecordCount, ProductsPartsGroupBox, ProductsPartsDataGridView)
    End Sub

    Private Sub FormatProductsPartsDataGridView()
        ProductsPartsDataGridViewAlreadyFormated = True
        ProductsPartsGroupBox.Width = 0
        For i = 0 To ProductsPartsDataGridView.Columns.GetColumnCount(0) - 1

            ProductsPartsDataGridView.Columns.Item(i).Visible = False
            Select Case ProductsPartsDataGridView.Columns.Item(i).Name
                Case "Selected"
                    ProductsPartsDataGridView.Columns.Item(i).HeaderText = "*"
                    ProductsPartsDataGridView.Columns.Item(i).Width = 20
                    ProductsPartsDataGridView.Columns.Item(i).Visible = True
                Case "SystemDesc_ShortText100Fld"
                    ProductsPartsDataGridView.Columns.Item(i).HeaderText = "Part Desc"
                    ProductsPartsDataGridView.Columns.Item(i).Width = 250
                    ProductsPartsDataGridView.Columns.Item(i).Visible = True
                Case "PartSpecifications_ShortText255"
                    ProductsPartsDataGridView.Columns.Item(i).HeaderText = "Specification"
                    ProductsPartsDataGridView.Columns.Item(i).Width = 150
                    ProductsPartsDataGridView.Columns.Item(i).Visible = True
                Case "ManufacturerPartNo_ShortText30Fld"
                    ProductsPartsDataGridView.Columns.Item(i).HeaderText = "Manufacturer PN"
                    ProductsPartsDataGridView.Columns.Item(i).Width = 150
                    ProductsPartsDataGridView.Columns.Item(i).Visible = True
                Case "ManufacturerDescription_ShortText250"
                    ProductsPartsDataGridView.Columns.Item(i).HeaderText = "Manufacturer Desc"
                    ProductsPartsDataGridView.Columns.Item(i).Width = 350
                    ProductsPartsDataGridView.Columns.Item(i).Visible = True
                Case "BrandName_ShortText20"
                    ProductsPartsDataGridView.Columns.Item(i).HeaderText = "Brand"
                    ProductsPartsDataGridView.Columns.Item(i).Width = 150
                    ProductsPartsDataGridView.Columns.Item(i).Visible = True
                Case "ProductDescription_ShortText250"
                    ProductsPartsDataGridView.Columns.Item(i).HeaderText = "excel Desc"
                    ProductsPartsDataGridView.Columns.Item(i).Width = 400
                    ProductsPartsDataGridView.Columns.Item(i).Visible = True
                Case "Packing"
                    ProductsPartsDataGridView.Columns.Item(i).HeaderText = "Packing"
                    ProductsPartsDataGridView.Columns.Item(i).Width = 70
                    ProductsPartsDataGridView.Columns.Item(i).Visible = True
                Case "UnitOfThePacking_ShortText3"
                    ProductsPartsDataGridView.Columns.Item(i).HeaderText = "Unit"
                    ProductsPartsDataGridView.Columns.Item(i).Width = 70
                    ProductsPartsDataGridView.Columns.Item(i).Visible = True
                Case "ProductsPartsPackingRelationID_AutoNumber"
                    ProductsPartsDataGridView.Columns.Item(i).HeaderText = "RelationID"
                    ProductsPartsDataGridView.Columns.Item(i).Width = 70
                    ProductsPartsDataGridView.Columns.Item(i).Visible = True

            End Select

            If ProductsPartsDataGridView.Columns.Item(i).Visible = True Then
                ProductsPartsGroupBox.Width = ProductsPartsGroupBox.Width + ProductsPartsDataGridView.Columns.Item(i).Width
            End If
        Next

        ' NOTE" SYSTEM AUTOFITS THE GRIDVIEW FIELDS ACCORDING To THEIR WITDH
        Me.Width = VehicleManagementSystemForm.Width
        If ProductsPartsGroupBox.Width > Me.Width + 20 Then
            ProductsPartsGroupBox.Width = Me.Width - 80
        Else
            ProductsPartsGroupBox.Width = ProductsPartsGroupBox.Width + 20
        End If
        '
        If Me.Width > ProductsPartsGroupBox.Width Then
            ProductsPartsGroupBox.Left = (Me.Width - ProductsPartsGroupBox.Width) / 2
        Else
            ProductsPartsGroupBox.Left = Me.Left
            ProductsPartsGroupBox.Width = Me.Width
        End If
        ProductsPartsGroupBox.Top = (ProductsPartsMenuStrip.Top + ProductsPartsMenuStrip.Height)
        Me.Left = VehicleManagementSystemForm.Left
    End Sub
    Private Sub ProductsPartsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles ProductsPartsDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If ProductsPartsRecordCount = 0 Then Exit Sub
        CurrentProductsPartsRow = e.RowIndex
        CurrentProductPartID = ProductsPartsDataGridView.Item("ProductsPartID_Autonumber", CurrentProductsPartsRow).Value
        FillField(CurrentProductSpecificationID, ProductsPartsDataGridView.Item("PartsSpecificationID_AutoNumber", CurrentProductsPartsRow).Value)
        FillField(CurrentProductsPartsPackingRelationID, ProductsPartsDataGridView.Item("ProductsPartsPackingRelationID_AutoNumber", CurrentProductsPartsRow).Value)
        CurrentMasterCodeBookID = ProductsPartsDataGridView.Item("MasterCodeBookID_LongInteger", CurrentProductsPartsRow).Value
        CurrentBrandID = ProductsPartsDataGridView.Item("ProductsPartID_Autonumber", CurrentProductsPartsRow).Value
        SelectToolStripMenuItem.Visible = True
        If CurrentMasterCodeBookID > -1 Then
            SelectToolStripMenuItem.Visible = True
        Else
            SelectToolStripMenuItem.Visible = False
        End If
        'DISPLAY HISTORY FOR THIS PRODUCT BASED ON THE MODE
        If HistoriesGroupBox.Visible = True Then SetFilterAndDisplayRequesteHistory()
    End Sub
    Private Sub FillProductsPartsPackingsDataGridView()

        ProductsPartsPackingsFieldsToSelect = " SELECT * FROM ProductPartPackingsQuery "
        MySelection = ProductsPartsPackingsFieldsToSelect & ProductsPartsPackingsSelectionFilter & ProductsPartsPackingsSelectionOrder

        JustExecuteMySelection()
        ProductsPartsPackingsRecordCount = RecordCount

        If ProductsPartsPackingsRecordCount > 0 Then
            ProductsPartsPackingsGroupBox.Visible = True
        Else
            ProductsPartsPackingsGroupBox.Visible = False
            CurrentProductsPartsPackingID = -1
        End If
        ProductsPartsPackingsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        If Not ProductsPartsPackingsDataGridViewAlreadyFormated Then
            FormatProductsPartsPackingsDataGridView()
        End If
        SetGroupBoxHeight(5, ProductsPartsPackingsRecordCount, ProductsPartsPackingsGroupBox, ProductsPartsPackingsDataGridView)
        ProductsPartsPackingsGroupBox.Top = BottomOf(ProductDetailsGroup)
    End Sub
    Private Sub FormatProductsPartsPackingsDataGridView()
        ProductsPartsPackingsDataGridViewAlreadyFormated = True
        ProductsPartsPackingsGroupBox.Width = 0

        For i = 0 To ProductsPartsPackingsDataGridView.Columns.GetColumnCount(0) - 1

            ProductsPartsPackingsDataGridView.Columns.Item(i).Visible = False
            Select Case ProductsPartsPackingsDataGridView.Columns.Item(i).Name
                Case "QuantityPerPack_Double"
                    ProductsPartsPackingsDataGridView.Columns.Item(i).HeaderText = "Quantity Per Pack"
                    ProductsPartsPackingsDataGridView.Columns.Item(i).Width = 80
                    ProductsPartsPackingsDataGridView.Columns.Item(i).Visible = True
                Case "UnitOfTheQuantity_ShortText3"
                    ProductsPartsPackingsDataGridView.Columns.Item(i).HeaderText = "Quantity Unit"
                    ProductsPartsPackingsDataGridView.Columns.Item(i).Width = 80
                    ProductsPartsPackingsDataGridView.Columns.Item(i).Visible = True
                Case "UnitOfThePacking_ShortText3"
                    ProductsPartsPackingsDataGridView.Columns.Item(i).HeaderText = "Packing Unit"
                    ProductsPartsPackingsDataGridView.Columns.Item(i).Width = 80
                    ProductsPartsPackingsDataGridView.Columns.Item(i).Visible = True
            End Select

            If ProductsPartsPackingsDataGridView.Columns.Item(i).Visible = True Then
                ProductsPartsPackingsGroupBox.Width = ProductsPartsPackingsGroupBox.Width + ProductsPartsPackingsDataGridView.Columns.Item(i).Width
            End If
        Next
    End Sub
    Private Sub ProductsPartsPackingsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles ProductsPartsPackingsDataGridView.RowEnter

        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If ProductsPartsPackingsRecordCount = 0 Then Exit Sub

        CurrentProductsPartsPackingsRow = e.RowIndex
        CurrentProductsPartsPackingID = ProductsPartsPackingsDataGridView.Item("ProductsPartsPackingRelationID_AutoNumber", CurrentProductsPartsPackingsRow).Value

    End Sub
    Private Sub FillHistoriesDataGridView()
        '  HistoryMode will be used to indicate what records are to displayed in the HistoriesDataGridView
        '  where Work Order Items = 1, Purchases = 2, others to develop
        Select Case HistoryMode
            Case 1 ' Work Order Items
                HistoriesSelectionOrder = " ORDER BY  ServiceDate_DateTime"
                HistoriesFieldsToSelect = "
SELECT WorkOrderPartsTable.WorkOrderPartID_AutoNumber, WorkOrderPartsTable.ProductPartID_LongInteger, WorkOrderPartsTable.Quantity_Integer, WorkOrderPartsTable.Unit_ShortText3, WorkOrdersTable.WorkOrderNumber_ShortText12, WorkOrdersTable.ServiceDate_DateTime, VehicleModels.VehicleModel
FROM ((WorkOrderPartsTable LEFT JOIN WorkOrdersTable ON WorkOrderPartsTable.WorkOrderID_LongInteger = WorkOrdersTable.WorkOrderID_AutoNumber) LEFT JOIN CodeVehiclesTable ON WorkOrderPartsTable.CodeVehicleID_LongInteger = CodeVehiclesTable.CodeVehicleID_AutoNumber) LEFT JOIN (ServicedVehiclesTable LEFT JOIN VehicleModels ON ServicedVehiclesTable.VehicleID_LongInteger = VehicleModels.VehicleID_AutoNumber) ON WorkOrdersTable.ServicedVehicleID_LongInteger = ServicedVehiclesTable.ServicedVehicleID_AutoNumber
"
            Case 2 ' Purchases
                HistoriesSelectionOrder = " ORDER BY  "
                HistoriesFieldsToSelect = " "
        End Select

        MySelection = HistoriesFieldsToSelect & HistoriesSelectionFilter & HistoriesSelectionOrder

        JustExecuteMySelection()
        HistoriesRecordCount = RecordCount

        HistoriesDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If HistoriesRecordCount = 0 Then
            MsgBox("No History of usage found")
            CurrentWorkOrderPartID = -1
            CurrentPurchaseOrderItemID = 1
            Exit Sub
        Else
            HistoriesGroupBox.Visible = True
            ProductsPartsMenuStrip.Visible = False
        End If

        ' HERE AT ROW_ENTER, FillMyStandardConcernsDataGridView is called and MyStandardConcernsbOX IS ALREADY FORMATTED
        If Not HistoriesDataGridViewAlreadyFormated Then
            FormatHistoriesDataGridView()
            SetFormWidthAndGroupBoxLeft(Me,
                                        ProductsPartsMenuStrip,
                                        ProductsPartsGroupBox,
                                        ProductsPartsPackingsGroupBox,
                                        HistoriesGroupBox,
                                        HistoriesGroupBox)
        End If

        SetGroupBoxHeight(15, HistoriesRecordCount, HistoriesGroupBox, HistoriesDataGridView)
        HistoriesGroupBox.Top = BottomOf(ProductsPartsMenuStrip)
    End Sub
    Private Sub FormatHistoriesDataGridView()
        HistoriesDataGridViewAlreadyFormated = True
        HistoriesGroupBox.Width = 0
        For i = 0 To HistoriesDataGridView.Columns.GetColumnCount(0) - 1
            HistoriesDataGridView.Columns.Item(i).Visible = False
            Select Case HistoryMode
                Case 1
                    Select Case HistoriesDataGridView.Columns.Item(i).Name
                        Case "Quantity_Integer"
                            HistoriesDataGridView.Columns.Item(i).HeaderText = "Quantity"
                            HistoriesDataGridView.Columns.Item(i).Width = 120
                            HistoriesDataGridView.Columns.Item(i).Visible = True
                        Case "Unit_ShortText3"
                            HistoriesDataGridView.Columns.Item(i).HeaderText = "Original unit"
                            HistoriesDataGridView.Columns.Item(i).Width = 80
                            HistoriesDataGridView.Columns.Item(i).Visible = True
                        Case "WorkOrderNumber_ShortText12"
                            HistoriesDataGridView.Columns.Item(i).HeaderText = "Work Order #"
                            HistoriesDataGridView.Columns.Item(i).Width = 120
                            HistoriesDataGridView.Columns.Item(i).Visible = True
                        Case "ServiceDate_DateTime"
                            HistoriesDataGridView.Columns.Item(i).HeaderText = "Service Date"
                            HistoriesDataGridView.Columns.Item(i).Width = 70
                            HistoriesDataGridView.Columns(i).DefaultCellStyle.Format = "yy-MM-dd"
                            HistoriesDataGridView.Columns.Item(i).Visible = True
                        Case "VehicleModel"
                            HistoriesDataGridView.Columns.Item(i).HeaderText = "Model"
                            HistoriesDataGridView.Columns.Item(i).Width = 200
                            HistoriesDataGridView.Columns.Item(i).Visible = True
                    End Select
                Case 2
                    Select Case HistoriesDataGridView.Columns.Item(i).Name
                    End Select
            End Select
            If HistoriesDataGridView.Columns.Item(i).Visible = True Then
                HistoriesGroupBox.Width = HistoriesGroupBox.Width + HistoriesDataGridView.Columns.Item(i).Width
            End If
        Next
        If HistoriesGroupBox.Width > VehicleManagementSystemForm.Width Then
            HistoriesGroupBox.Width = VehicleManagementSystemForm.Width - 4
        Else
            HorizontalCenter(HistoriesGroupBox, Me)
        End If
    End Sub
    Private Sub HistoriesDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles HistoriesDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If HistoriesRecordCount = 0 Then Exit Sub

        CurrentHistoriesRow = e.RowIndex
        Select Case HistoryMode
            Case 1
                CurrentWorkOrderPartID = HistoriesDataGridView.Item("WorkOrderPartID_AutoNumber", CurrentHistoriesRow).Value
        End Select


    End Sub
    Private Sub SelectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectToolStripMenuItem.Click
        Dim CurrentPartDescription = ProductsPartsDataGridView.Item("ManufacturerDescription_ShortText250", CurrentProductsPartsRow).Value

        If IsEmpty(ProductsPartsDataGridView.Item("SystemDesc_ShortText100Fld", CurrentProductsPartsRow).Value) Then
            MsgBox("This Product is not linked to the MasterCodeBook, link this as " & CurrentPartDescription & "?")
            ShowMasterCodeBookForm()
            Exit Sub
        End If
        If IsEmpty(ProductsPartsDataGridView.Item("ManufacturerDescription_ShortText250", CurrentProductsPartsRow).Value) Then
            MsgBox("There are no product informations attached " & CurrentPartDescription & "?")
            SetupEditMode()
            Exit Sub
        End If
        MarkSelected()
        Tunnel1 = "Tunnel2IsProductPartID"
        Tunnel2 = CurrentProductPartID
        Tunnel3 = ProductsPartsDataGridView.Item("ManufacturerDescription_ShortText250", CurrentProductsPartsRow).Value
        FillField(Tunnel4, ProductsPartsDataGridView.Item("ProductsPartsPackingRelationID_AutoNumber", CurrentProductsPartsRow).Value)
        Select Case SavedCallingForm.Name
            Case "InventoriesForm"
                Dim Packing = ProductsPartsDataGridView.Item("QuantityPerPack_Double", CurrentProductsPartsRow).Value.ToString & " " &
                              ProductsPartsDataGridView.Item("UnitOfTheQuantity_ShortText3", CurrentProductsPartsRow).Value.ToString & "s/" &
                              ProductsPartsDataGridView.Item("UnitOfThePacking_ShortText3", CurrentProductsPartsRow).Value.ToString
                InventoriesForm.SystemPartDescriptionTextBox.Text = ProductsPartsDataGridView.Item("SystemDesc_ShortText100Fld", CurrentProductsPartsRow).Value
                InventoriesForm.ManufacturerPartNoTextBox.Text = ProductsPartsDataGridView.Item("ManufacturerPartNo_ShortText30Fld", CurrentProductsPartsRow).Value
                InventoriesForm.ManufacturerPartDescTextBox.Text = ProductsPartsDataGridView.Item("ManufacturerDescription_ShortText250", CurrentProductsPartsRow).Value
                FillField(InventoriesForm.UnitTextBox.Text, ProductsPartsDataGridView.Item("UnitOfThePacking_ShortText3", CurrentProductsPartsRow).Value)
                InventoriesForm.PackingTextBox.Text = Packing
                FillField(InventoriesForm.BulkBalanceUnitTextBox.Text, ProductsPartsDataGridView.Item("UnitOfTheQuantity_ShortText3", CurrentProductsPartsRow).Value.ToString())
                FillField(InventoriesForm.BrandNameTextBox.Text, ProductsPartsDataGridView.Item("BrandName_ShortText20", CurrentProductsPartsRow).Value)
                FillField(InventoriesForm.ProductSpecificationTextBox.Text, ProductsPartsDataGridView.Item("PartSpecifications_ShortText255", CurrentProductsPartsRow).Value)
            Case "PurchaseOrdersForm"
                PurchaseOrdersForm.POItemProductPartNoTextBox.Text = ProductsPartsDataGridView.Item("ManufacturerPartNo_ShortText30Fld", CurrentProductsPartsRow).Value
                PurchaseOrdersForm.POItemProductDescTextBox.Text = ProductsPartsDataGridView.Item("ManufacturerDescription_ShortText250", CurrentProductsPartsRow).Value
                PurchaseOrdersForm.POItemUnitTextBox.Text = ProductsPartsDataGridView.Item("Unit_ShortText3", CurrentProductsPartsRow).Value
            Case "RequisitionsForm"
                StoreRequisitionsForm.POItemProductPartNoTextBox.Text = ProductsPartsDataGridView.Item("ManufacturerPartNo_ShortText30Fld", CurrentProductsPartsRow).Value
                StoreRequisitionsForm.RequisitionItemProductDescTextBox.Text = ProductsPartsDataGridView.Item("ManufacturerDescription_ShortText250", CurrentProductsPartsRow).Value
                StoreRequisitionsForm.RequisitionItemUnitTextBox.Text = ProductsPartsDataGridView.Item("Unit_ShortText3", CurrentProductsPartsRow).Value
            Case "DeliveriesItemsForm"
                DeliveriesForm.POItemProductPartNoTextBox.Text = ProductsPartsDataGridView.Item("ManufacturerPartNo_ShortText30Fld", CurrentProductsPartsRow).Value
                DeliveriesForm.POItemProductDescTextBox.Text = ProductsPartsDataGridView.Item("ManufacturerDescription_ShortText250", CurrentProductsPartsRow).Value
                DeliveriesForm.POItemUnitTextBox.Text = ProductsPartsDataGridView.Item("Unit_ShortText3", CurrentProductsPartsRow).Value
                DeliveriesForm.BrandTextBox.Text = ProductsPartsDataGridView.Item("BrandName_ShortText20", CurrentProductsPartsRow).Value
            Case "RequestPartsForm"
                RequestPartsForm.PartNumberTextBox.Text = ProductsPartsDataGridView.Item("ManufacturerPartNo_ShortText30Fld", CurrentProductsPartsRow).Value
                RequestPartsForm.ProductTextBox.Text = ProductsPartsDataGridView.Item("ManufacturerDescription_ShortText250", CurrentProductsPartsRow).Value
                RequestPartsForm.CustomerSuppliedUnitTextBox.Text = ProductsPartsDataGridView.Item("Unit_ShortText3", CurrentProductsPartsRow).Value
            Case "StoreRequisitionsForm"
                StoreRequisitionsForm.POItemProductPartNoTextBox.Text = ProductsPartsDataGridView.Item("ManufacturerPartNo_ShortText30Fld", CurrentProductsPartsRow).Value
                StoreRequisitionsForm.RequisitionItemProductDescTextBox.Text = ProductsPartsDataGridView.Item("ManufacturerDescription_ShortText250", CurrentProductsPartsRow).Value
                StoreRequisitionsForm.RequisitionItemUnitTextBox.Text = ProductsPartsDataGridView.Item("Unit_ShortText3", CurrentProductsPartsRow).Value
                If IsNotEmpty(ProductsPartsDataGridView.Item("QuantityPerPack_Double", CurrentProductsPartsRow).Value) Then
                    StoreRequisitionsForm.PackingTextBox.Text = ProductsPartsDataGridView.Item("QuantityPerPack_Double", CurrentProductsPartsRow).Value.ToString & Space(1) &
                                      ProductsPartsDataGridView.Item("UnitOfTheQuantity_ShortText3", CurrentProductsPartsRow).Value.ToString &
                                        " / " &
                                      ProductsPartsDataGridView.Item("Unit_ShortText3", CurrentProductsPartsRow).Value.ToString
                End If
                FillField(StoreRequisitionsForm.BrandTextBox.Text, ProductsPartsDataGridView.Item("BrandName_ShortText20", CurrentProductsPartsRow).Value)
                StoreRequisitionsForm.ProductSpecificationTextBox.Text = ProductsPartsDataGridView.Item("PartSpecifications_ShortText255", CurrentProductsPartsRow).Value

        End Select
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub
    Private Sub SetSearchParameters()
        ProductsPartsSelectionFilter = " WHERE ( "
        Dim xxOR = ""
        If IsNotEmpty(PartNoSearchTextBox.Text) Then
            ProductsPartsSelectionFilter &= " ManufacturerPartNo_ShortText30Fld Like " & InQuotes("%" & Trim(PartNoSearchTextBox.Text) & "%")
            ProductsPartsSelectionFilter &= " OR ManufacturerPartNoClean_ShortText30Fld Like " & InQuotes("%" & GetCleanedManufacturerPartNo(PartNoSearchTextBox.Text) & "%")
        End If
        If IsNotEmpty(PartDescriptionSearchTextBox.Text) Then
            ProductsPartsSelectionFilter &= xxOR & " ProductDescription_ShortText250 Like " & InQuotes("%" & Trim(PartDescriptionSearchTextBox.Text) & "%")
            ProductsPartsSelectionFilter &= " OR  ManufacturerDescription_ShortText250 Like " & InQuotes("%" & Trim(PartDescriptionSearchTextBox.Text) & "%")
            ProductsPartsSelectionFilter &= " OR  SystemDesc_ShortText100Fld Like " & InQuotes("%" & Trim(PartDescriptionSearchTextBox.Text) & "%")
            '            
        End If
        If IsNotEmpty(ProductSpecificationSearchTextBox.Text) Then
            If ProductsPartsSelectionFilter = " WHERE ( " Then
                xxOR = ""
            Else
                xxOR = " OR "
            End If
            ProductsPartsSelectionFilter &= xxOR & " PartSpecifications_ShortText255 = " & InQuotes(ProductSpecificationSearchTextBox.Text)
        End If
        If ProductsPartsSelectionFilter <> " WHERE ( " Then
            ProductsPartsSelectionFilter += ") AND NOT ForDeletionRecord_YesNo "
        Else
            ProductsPartsSelectionFilter = " NOT ForDeletionRecord_YesNo "
        End If

    End Sub
    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        SystemPartDescriptionTextBox.Text = ""
        ManufacturerPartNoTextBox.Text = ""
        ManufacturerPartDescTextBox.Text = ""
        BrandNameTextBox.Text = ""
        PurposeOfEntry = "ADD"
        CurrentProductPartID = -1
        ShowMasterCodeBookForm()
    End Sub
    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        SetupEditMode()
    End Sub
    Private Sub SetupEditMode()
        PurposeOfEntry = "EDIT"
        ProductDetailsGroup.Visible = True
        SelectToolStripMenuItem.Visible = False
        UpdateMasterCodeLinkToolStripMenuItem.Visible = False
        AddToolStripMenuItem.Visible = False
        DeleteToolStripMenuItem.Visible = False
        EditToolStripMenuItem.Visible = False
        SearchToolStripMenuItem.Visible = False

        LoadProductDetails()
        ManufacturerPartDescTextBox.Select()
        ManufacturerPartNoTextBox.Enabled = True
        BrandNameTextBox.Enabled = True
    End Sub
    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        If ProductIsNotYetUsed() Then
            If MsgBox("No references has been found, continue DELETE this record ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            MySelection = " DELETE FROM ProductsPartsTable WHERE ProductsPartID_Autonumber =  " & CurrentProductPartID
            JustExecuteMySelection()
            FillProductsPartsDataGridView()
        Else
            MsgBox("This Product is already used, can not delete")
        End If
    End Sub
    Private Function ProductIsNotYetUsed()
        Dim TablesToCheck = {
                                             "CodeVehicleProductsPartsTable",
                                             "DeliveryItemsTable",
                                             "InventoryItemsTable",
                                             "WorkOrderPartsTable",
                                             "WorkOrderPartsIssuedItemsTable",
                                             "WorkOrderReceivedPartsTable",
                                             "WorkOrderRequestedPartsTable",
                                             "StocksTable",
                                             "StoreSuppliesRequisitionsItemsTable",
                                             "ProductsPartsPackingRelationsTable",
                                             "PurchaseOrdersItemsTable",
                                             "RequisitionsItemsTable",
                                             "DeliveryItemsTable"
                                             }
        If LinkExistsIn(TablesToCheck, "ProductPartID_LongInteger", CurrentProductPartID) Then Return False
        Return True
    End Function
    Private Sub LoadProductDetails()
        FillField(ProductSpecificationTextBox.Text, ProductsPartsDataGridView.Item("PartSpecifications_ShortText255", CurrentProductsPartsRow).Value)
        FillField(SystemPartDescriptionTextBox.Text, ProductsPartsDataGridView.Item("SystemDesc_ShortText100Fld", CurrentProductsPartsRow).Value)
        FillField(ManufacturerPartNoTextBox.Text, ProductsPartsDataGridView.Item("ManufacturerPartNo_ShortText30Fld", CurrentProductsPartsRow).Value)
        FillField(ManufacturerPartDescTextBox.Text, ProductsPartsDataGridView.Item("ManufacturerDescription_ShortText250", CurrentProductsPartsRow).Value)
        FillField(BrandNameTextBox.Text, ProductsPartsDataGridView.Item("BrandName_ShortText20", CurrentProductsPartsRow).Value)
        FillField(CurrentBrandID, ProductsPartsDataGridView.Item("BrandID_Autonumber", CurrentProductsPartsRow).Value)
        FillField(UnitTextBox.Text, ProductsPartsDataGridView.Item("UnitOfThePacking_ShortText3", CurrentProductsPartsRow).Value)
        FillField(PackingTextBox.Text, ProductsPartsDataGridView.Item("Packing", CurrentProductsPartsRow).Value)
        ProductsPartsPackingsSelectionFilter = "WHERE ProductPartID_LongInteger = " & CurrentProductPartID
        FillProductsPartsPackingsDataGridView()
    End Sub
    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        Dim CurrentPartDescription = ProductsPartsDataGridView.Item("ManufacturerDescription_ShortText250", CurrentProductsPartsRow).Value
        If IsEmpty(SystemPartDescriptionTextBox.Text) Then
            MsgBox("This Product is not linked to the MasterCodeBook, link this as " & CurrentPartDescription & "?")
            ShowMasterCodeBookForm()
            Exit Sub
        End If
        'VALIDATIONS
        If Trim(ManufacturerPartNoTextBox.Text) = "" Then
            If MsgBox("Leave the PART NUMBER blank ? ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                ManufacturerPartNoTextBox.Select()
                Exit Sub
            End If
        End If
        If Trim(ManufacturerPartDescTextBox.Text) = "" Then
            ManufacturerPartDescTextBox.Select()
            Exit Sub
        End If
        If Trim(BrandNameTextBox.Text) = "" Then
            Dim AnswerToMessage = MsgBox("Would you like to leave the Brand blank ?", vbYesNo)
            If AnswerToMessage = vbNo Then
                BrandNameTextBox.Select()
                Exit Sub
            End If
        End If

        If IsEmpty(SystemPartDescriptionTextBox.Text) Then
            MsgBox("mUST LINK THIS PRODUCT TO A PART")
            ShowMasterCodeBookForm()
            Exit Sub
        End If

        SaveChanges()

    End Sub
    Private Sub SaveChanges()
        BackToEditMode = False
        If AChangeInProductDetails() Then
            RegisterProductDetailsChanges()
        End If
        If BackToEditMode Then Exit Sub
        FillProductsPartsDataGridView()
        ProductDetailsGroup.Visible = False
        SaveToolStripMenuItem.Visible = False
        SelectToolStripMenuItem.Visible = True
        UpdateMasterCodeLinkToolStripMenuItem.Visible = True
        AddToolStripMenuItem.Visible = True
        DeleteToolStripMenuItem.Visible = True
        EditToolStripMenuItem.Visible = True
        SearchToolStripMenuItem.Visible = True
    End Sub
    Private Function AChangeInProductDetails()
        If CurrentProductsPartsRow > -1 Then
            If TheseAreNotEqual(SystemPartDescriptionTextBox.Text, ProductsPartsDataGridView.Item("SystemDesc_ShortText100Fld", CurrentProductsPartsRow).Value) Then Return True
            If TheseAreNotEqual(ManufacturerPartNoTextBox.Text, ProductsPartsDataGridView.Item("ManufacturerPartNo_ShortText30Fld", CurrentProductsPartsRow).Value) Then Return True
            If TheseAreNotEqual(ManufacturerPartDescTextBox.Text, ProductsPartsDataGridView.Item("ManufacturerDescription_ShortText250", CurrentProductsPartsRow).Value) Then Return True
            If TheseAreNotEqual(ProductSpecificationTextBox.Text, ProductsPartsDataGridView.Item("PartSpecifications_ShortText255", CurrentProductsPartsRow).Value) Then Return True
            If TheseAreNotEqual(BrandNameTextBox.Text, ProductsPartsDataGridView.Item("BrandName_ShortText20", CurrentProductsPartsRow).Value) Then Return True
        Else
            If IsNotEmpty(ManufacturerPartDescTextBox.Text) Then Return True
        End If
        Return False
    End Function
    Private Sub RegisterProductDetailsChanges()
        MySelection = " Select  * FROM ProductsPartsTable WHERE ProductsPartID_Autonumber = " & CurrentProductPartID
        JustExecuteMySelection()

        Dim xxMessage = ""
        If RecordCount = 0 Then
            xxMessage = ("Continue ADD this Product ? ")
        Else
            xxMessage = ("Continue Save Changes ? ")
        End If
        If MsgBox(xxMessage, MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            If MsgBox("Disregard your changes ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                SystemPartDescriptionTextBox.Select()
                BackToEditMode = True
                Exit Sub
            End If
        End If

        If RecordCount = 0 Then
            InsertNewProductsPartChanges()
        Else
            UpdateProductsPartChanges()
        End If
    End Sub
    Private Sub InsertNewProductsPartChanges()
        Dim FieldsToUpdate =
                    " ManufacturerPartNo_ShortText30Fld, " &
                    " ManufacturerPartNoClean_ShortText30Fld, " &
                    " ManufacturerDescription_ShortText250, " &
                    " MasterCodeBookID_LongInteger, " &
                    " PartsSpecificationID_LongInteger, " &
                    " BrandID_LongInteger "

        Dim ReplacementData =
                    InQuotes(ManufacturerPartNoTextBox.Text) & ", " &
                    InQuotes(GetCleanedManufacturerPartNo(ManufacturerPartNoTextBox.Text)) & ", " &
                    InQuotes(Trim(ManufacturerPartDescTextBox.Text)) & ", " &
                    Str(CurrentMasterCodeBookID) & ", " &
                    CurrentProductSpecificationID.ToString & ", " &
                    Str(CurrentBrandID)

        CurrentProductPartID = InsertNewRecord("ProductsPartsTable", FieldsToUpdate, ReplacementData)
        MsgBox("COMMENTED COMMANDS SHOULD BE ENABLED TO ALLOW ADDING PACKINGS OF PRODUCTS/PARTS")
    End Sub
    Private Sub UpdateProductsPartChanges()
        Dim RecordFilter = " WHERE ProductsPartID_Autonumber = " & Str(CurrentProductPartID)
        Dim SetCommand =
                    " Set " &
                    " ManufacturerPartNo_ShortText30Fld = " & InQuotes(ManufacturerPartNoTextBox.Text) & ", " &
                    " ManufacturerPartNoClean_ShortText30Fld = " & InQuotes(GetCleanedManufacturerPartNo(ManufacturerPartNoTextBox.Text)) & ", " &
                    " ManufacturerDescription_ShortText250 = " & InQuotes(Trim(ManufacturerPartDescTextBox.Text)) & ", " &
                    " PartsSpecificationID_LongInteger = " & CurrentProductSpecificationID.ToString & ", " &
                    " MasterCodeBookID_LongInteger = " & Str(CurrentMasterCodeBookID) & ", " &
                    " BrandID_LongInteger = " & Str(CurrentBrandID)
        UpdateTable("ProductsPartsTable", SetCommand, RecordFilter)
    End Sub
    Private Sub UpdateMasterCodeLinkToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateMasterCodeLinkToolStripMenuItem.Click
        LoadProductDetails()
        ManufacturerPartDescTextBox.Select()
        ShowMasterCodeBookForm()
        ProductDetailsGroup.Visible = True
        ProductDetailsGroup.BringToFront()
    End Sub
    Private Sub ShowMasterCodeBookForm()
        Me.Enabled = False
        MasterCodeBookForm.SearchMasterCodeBookTextBox.Text = PartDescriptionSearchTextBox.Text
        MasterCodeBookForm.ChangeVehicleDefaults.Enabled = False
        ShowCalledForm(Me, MasterCodeBookForm)
    End Sub
    Private Sub ManufacturerPartNoTextBox_TextChanged(sender As Object, e As EventArgs) Handles ManufacturerPartNoTextBox.TextChanged
        If ManufacturerPartNoTextBox.Text = "" Then
            Exit Sub
        End If
        Dim xxCleanedManufacturerPartNo = GetCleanedManufacturerPartNo(ManufacturerPartNoTextBox.Text)
    End Sub
    Private Sub ManufacturerPartNoTextBox_Leave(sender As Object, e As EventArgs) Handles ManufacturerPartNoTextBox.Leave
        If ProductDetailsGroup.Visible = False Then Exit Sub
        If ManufacturerPartNoTextBox.Text = "" Then Exit Sub
        If PurposeOfEntry = "ADD" Then

            Dim xxCurrentBrandID = " AND BrandID_LongInteger = " & CurrentBrandID.ToString
            If CurrentBrandID.ToString <= 0 Then xxCurrentBrandID = ""
            MySelection = "SELECT * " &
                       " FROM ProductsPartsTable " &
                      " WHERE trim(ManufacturerPartNoClean_ShortText30Fld) = " & InQuotes(Trim(ManufacturerPartNoTextBox.Text).ToUpper) &
                      " AND UCASE(ProductDescription_ShortText250) = " & InQuotes((ManufacturerPartDescTextBox.Text).ToUpper)

            If RecordIsFound() Then
                MsgBox("Product Part already exist")

            End If
        Else

        End If
    End Sub
    Private Function GetCleanedManufacturerPartNo(PassedManufacturerPartNumber)
        CleanedManufacturerPartNo = ""
        For i = 1 To Len(Trim(PassedManufacturerPartNumber))
            Dim LastKeyedIn = Mid(PassedManufacturerPartNumber, i, 1).ToUpper
            If InStr("012345678910ABCDEFGHIJKLMNOPQRSTUVWXYZ", LastKeyedIn) > 0 Then
                Dim xxcccx = Mid(PassedManufacturerPartNumber, i, 1)
                CleanedManufacturerPartNo &= Mid(PassedManufacturerPartNumber, i, 1)
            End If
        Next
        Return CleanedManufacturerPartNo
    End Function
    Private Sub ProductDetailsGroup_VisibleChanged(sender As Object, e As EventArgs) Handles ProductDetailsGroup.VisibleChanged
        If ProductDetailsGroup.Visible = True Then
            ProductsPartsGroupBox.Enabled = False
            If Not PurposeOfEntry = "ADD" Then LoadProductDetails()
            SaveToolStripMenuItem.Visible = True
            EditPackingToolStripMenuItem.Visible = True
            AddToolStripMenuItem.Visible = False
            EditToolStripMenuItem.Visible = False
            DeleteToolStripMenuItem.Visible = False
            SelectToolStripMenuItem.Visible = False
            ProductDetailsToolStripMenuItem.Visible = False
            SearchToolStripMenuItem.Visible = False
            UpdateMasterCodeLinkToolStripMenuItem.Visible = False
        Else
            ProductsPartsGroupBox.Enabled = True
            SaveToolStripMenuItem.Visible = False
            AddToolStripMenuItem.Visible = True
            EditToolStripMenuItem.Visible = True
            DeleteToolStripMenuItem.Visible = True
            SelectToolStripMenuItem.Visible = True
            ProductDetailsToolStripMenuItem.Visible = True
            SearchToolStripMenuItem.Visible = True
            UpdateMasterCodeLinkToolStripMenuItem.Visible = True
            EditPackingToolStripMenuItem.Visible = False
            ProductsPartsPackingsGroupBox.Visible = False
        End If
    End Sub
    Private Sub BrandNameTextBox_GotFocus(sender As Object, e As EventArgs) Handles BrandNameTextBox.Click
        If BrandNameTextBox.Text = "" Then
            ShowBrandsForm()
            Exit Sub
        End If
        If MsgBox("CHANGE BRAND?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ShowBrandsForm()
        End If
    End Sub
    Private Sub ShowBrandsForm()
        ShowCalledForm(Me, BrandsForm)
    End Sub
    Private Sub BrandNameTextBox_TextChanged(sender As Object, e As EventArgs) Handles BrandNameTextBox.TextChanged
        If BrandNameTextBox.Text = "" Then Exit Sub
        If Len(Trim(BrandNameTextBox.Text)) > 20 Then
            BrandNameTextBox.Text = BrandNameTextBox.Text.Substring(0, 19)
        End If
        ManufacturerPartNoTextBox.Select()
    End Sub
    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        If HistoriesGroupBox.Visible = True Then
            HistoriesGroupBox.Visible = False
            ProductsPartsMenuStrip.Visible = True
            Exit Sub
        End If
        If ProductDetailsGroup.Visible = True Then
            If IsNotEmpty(ManufacturerPartDescTextBox.Text) Then
                SaveChanges()
            End If
            ProductDetailsGroup.Visible = False
            Exit Sub
        End If
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub
    Private Sub PartDescriptionSearchTextBox_Click(sender As Object, e As EventArgs) Handles PartDescriptionSearchTextBox.Click
        PartDescriptionSearchTextBox.SelectAll()
    End Sub
    Private Sub ProductDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductDetailsToolStripMenuItem.Click
        If ProductsPartsRecordCount < 1 Then Exit Sub
        ProductDetailsGroup.Visible = True
    End Sub
    Private Sub SpecificationTextBox_Click(sender As Object, e As EventArgs) Handles PartSpecificationTextBox.Click
        If MsgBox("Register Specification for this product ? ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        If IsEmpty(PartSpecificationTextBox.Text) Then Exit Sub
        If IsEmpty(CurrentMasterCodeBookID) Then
            SystemPartDescriptionTextBox.Select()
            Exit Sub
        End If

        PartsSpecificationsForm.PartDescriptionTextBox.Text = ProductsPartsDataGridView.Item("SystemDesc_ShortText100Fld", CurrentProductsPartsRow).Value
        Tunnel1 = ProductsPartsDataGridView.Item("ManufacturerDescription_ShortText250", CurrentProductsPartsRow).Value
        Tunnel2 = -1
        Tunnel3 = CurrentMasterCodeBookID
        ShowCalledForm(Me, PartsSpecificationsForm)

    End Sub
    Private Sub ProductSpecificationTextBox_Click(sender As Object, e As EventArgs) Handles ProductSpecificationTextBox.Click
        If MsgBox("Update Specification for this product ? ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        PartsSpecificationsForm.PartDescriptionTextBox.Text = ProductSpecificationTextBox.Text
        PartsSpecificationsForm.JobLabel.Visible = False
        PartsSpecificationsForm.ServiceToPerformTextBox.Visible = False
        PartsSpecificationsForm.VehicleLabel.Visible = False
        PartsSpecificationsForm.VehicleModelTextBox.Visible = False
        ' Tunnel 1 - InformationsHeaderID (Job Description)
        ' Tunnel 2 - CodeVehicleID
        ' Tunnel 3 - MasterCodeBookID

        Tunnel1 = ""
        Tunnel2 = -1
        Tunnel3 = CurrentMasterCodeBookID
        ShowCalledForm(Me, PartsSpecificationsForm)
    End Sub

    Private Sub VehicleModelButton_Click(sender As Object, e As EventArgs) Handles VehicleModelButton.Click
        If VehicleModelButton.Text = "ON" Then
            VehicleModelButton.Text = "OFF"
        Else
            VehicleModelButton.Text = "ON"
        End If
        FiltersGroupBox.Visible = True
    End Sub



    Private Sub SystemPartDescriptionTextBox_Click(sender As Object, e As EventArgs) Handles SystemPartDescriptionTextBox.Click
        If MsgBox("Do you want to update MasterCodeBook link?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ShowMasterCodeBookForm()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FiltersGroupBox.Visible = False
        If PartDescriptionSearchTextBox.Text = "" And PartNoSearchTextBox.Text = "" Then
            ProductsPartsSelectionFilter = " WHERE NOT ForDeletionRecord_YesNo "
        Else
            SetSearchParameters()
        End If
        FillProductsPartsDataGridView()

        If ProductsPartsRecordCount > 0 Then
            ProductsPartsDataGridView.Rows(0).Selected = True
        End If
    End Sub

    Private Sub SearchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SearchToolStripMenuItem.Click
        If FiltersGroupBox.Visible Then Exit Sub
        FiltersGroupBox.Visible = True
        FiltersGroupBox.BringToFront()
        PartDescriptionSearchTextBox.Select()
    End Sub
    Private Sub EditPackingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditPackingToolStripMenuItem.Click
        Tunnel1 = "Tunnel2IsProductPartID"
        Tunnel2 = CurrentProductPartID
        ProductPartsPackingRelationsForm.Show()
        ProductPartsPackingRelationsForm.Text = "PACKINGS for " & ManufacturerPartDescTextBox.Text
        If IsNotEmpty(ManufacturerPartNoTextBox.Text) Then
            ProductPartsPackingRelationsForm.Text = ProductPartsPackingRelationsForm.Text & " PART NUMBER: " & ManufacturerPartNoTextBox.Text
        End If
    End Sub

    Private Sub MarkSeletedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MarkSeletedToolStripMenuItem.Click
        MarkSelected()
        FillProductsPartsDataGridView()
    End Sub
    Private Sub MarkSelected()

        If ProductsPartsRecordCount < 1 Then Exit Sub
        Dim SetCommand = ""
        Dim RecordFilter = ""
        If ProductsPartsDataGridView.Item("Selected", CurrentProductsPartsRow).Value Then
            If MsgBox("Do you want to de-select this product?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If Not ProductIsNotYetUsed() Then
                    MsgBox("references already exist in other tables, can not de-select this record ")
                    Exit Sub
                End If
                SetCommand = "Set Selected = false  "
                RecordFilter = "WHERE ProductsPartID_Autonumber = " & CurrentProductPartID.ToString
                UpdateTable("ProductsPartsTable", SetCommand, RecordFilter)
                Exit Sub
            End If
        End If
        SetCommand = "Set Selected = true "
        RecordFilter = "where ProductsPartID_Autonumber = " & CurrentProductPartID.ToString
        UpdateTable("ProductsPartsTable", SetCommand, RecordFilter)
    End Sub
    Private Sub MarkAllRecordsAsForDeletionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MarkAllRecordsAsForDeletionToolStripMenuItem.Click
        MsgBox("This has been Done, no need to do")
        Exit Sub
        UpdateTable("ProductsPartsTable", " SET ForDeletionRecord_YesNo = TRUE", "")
    End Sub

    Private Sub SetToFalseForAllRecordsWithUnitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetToFalseForAllRecordsWithUnitToolStripMenuItem.Click
        MsgBox("REMOVE THE FIELD WorkOrderItemID_LongInteger FROM THE FILLPARTS")
        For i = 0 To ProductsPartsRecordCount - 1
            Dim SetToFalseForDeletion = False
            Dim CurrentProductPartID2 = ProductsPartsDataGridView.Item("ProductsPartID_Autonumber", i).Value
            If IsNotEmpty(ProductsPartsDataGridView.Item("Unit_ShortText3", i).Value) Then SetToFalseForDeletion = True
            If IsNotEmpty(ProductsPartsDataGridView.Item("WorkOrderItemID_LongInteger", i).Value) Then SetToFalseForDeletion = True
            If SetToFalseForDeletion Then
                UpdateTable("ProductsPartsTable", " SET ForDeletionRecord_YesNo = FALSE", "WHERE ProductsPartID_Autonumber = " & CurrentProductPartID2)
            End If
        Next
    End Sub
    Private Sub ToggleFilterToForDeletionOnOffToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToggleFilterToForDeletionOnOffToolStripMenuItem.Click
        If ForDeletionRecord_YesNo Then
            ForDeletionRecord_YesNo = False
            ProductsPartsSelectionFilter = " WHERE ForDeletionRecord_YesNo = false "
        Else
            ForDeletionRecord_YesNo = True
            ProductsPartsSelectionFilter = " WHERE ForDeletionRecord_YesNo = true "
        End If
        FillProductsPartsDataGridView()
    End Sub
    Private Sub ReIDSelectedToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ReIDSelectedToolStripMenuItem.Click
        If Not ProductsPartsDataGridView.MultiSelect Then
            ProductsPartsDataGridView.MultiSelect = True
            MsgBox("Multi Select has been enabled, Please Select your records")
        Else
            ' DETERMINE IF MORE THAN 1 RECORD IS SELECTED AND IF THERE IS A RECORD WITH FIELD Selected = true
            ' SelectedRecordsCount IS SET TO 0
            ' ONLY ONE AND THERE MUST BE ONE SELECTED
            ' FOR  ProductsPartsDataGridView.Item("Selected", i).Value = TRUE, THE ProductsPartID_Autonumber FIELD 
            ' IS SAVED TO REPLACE THE ProductsPartID_Selected OF THE PRODUCTSPARTSTABLE
            ' SET THE FIELD ForDeletionRecord_YesNo = TRUE
            ' SET THE ProductPartID_LongInteger FIELD OF THE REFERENCING TABLES TO THIS PRODUCT (SEE BELOW LIST)
            Dim RecordsSetSelected = 0
            Dim SelectedRecordsCount = 0
            For i = 0 To ProductsPartsRecordCount - 1
                If ProductsPartsDataGridView.Rows(i).Selected Then
                    SelectedRecordsCount += 1
                    If ProductsPartsDataGridView.Item("Selected", i).Value Then
                        CurrentProductPartID = ProductsPartsDataGridView.Item("ProductsPartID_Autonumber", i).Value
                        RecordsSetSelected += 1
                    End If
                End If
            Next
            If SelectedRecordsCount < 1 Then
                MsgBox("Not more than 1 record is selected")
                Exit Sub
            End If
            If RecordsSetSelected = 0 Then
                MsgBox("There is no record set as Selected")
                Exit Sub
            End If
            If RecordsSetSelected > 1 Then
                MsgBox("Only 1 record SHOULD BE set as Selected" & vbLf & "Deselect 1 by hitting again the MARK SELECTED")
                Exit Sub
            End If
            Dim SetCommand = ""
            Dim RecordFilter = ""

            For i = 0 To ProductsPartsRecordCount - 1
                If ProductsPartsDataGridView.Rows(i).Selected Then
                    'PROCESS ONLY THE SELECTED
                    ' UPDATE CURRENT SELECTED RECORD
                    If Not ProductsPartsDataGridView.Item("Selected", i).Value Then
                        SetCommand = "SET ProductsPartID_Selected = " & CurrentProductPartID.ToString &
                                      ",   ForDeletionRecord_YesNo = TRUE "
                        RecordFilter = "where ProductsPartID_Autonumber = " & ProductsPartsDataGridView.Item("ProductsPartID_Autonumber", i).Value.ToString
                        UpdateTable("ProductsPartsTable", SetCommand, RecordFilter)
                    Else
                        'NO NEED TO UPDATE THE REFERENCING TABLES
                        Continue For
                    End If
                    'now UPDATE ALL REFERENCING TABLE TO THIS PRODUCT
                    SetCommand = "SET ProductPartID_LongInteger = " & CurrentProductPartID.ToString
                    RecordFilter = "where ProductPartID_LongInteger = " & ProductsPartsDataGridView.Item("ProductsPartID_Autonumber", i).Value.ToString
                    UpdateTable("WorkOrderRequestedPartsTable", SetCommand, RecordFilter)
                    UpdateTable("WorkOrderReceivedPartsTable", SetCommand, RecordFilter)
                    UpdateTable("WorkOrderPartsIssuedItemsTable", SetCommand, RecordFilter)
                    UpdateTable("StoreSuppliesRequisitionsItemsTable", SetCommand, RecordFilter)
                    UpdateTable("StocksTable", SetCommand, RecordFilter)
                    UpdateTable("RequisitionsItemsTable", SetCommand, RecordFilter)
                    UpdateTable("PurchaseOrdersItemsTable", SetCommand, RecordFilter)
                    UpdateTable("ProductsPartsPackingRelationsTable", SetCommand, RecordFilter)
                    UpdateTable("InventoryItemsTable", SetCommand, RecordFilter)
                    UpdateTable("DeliveryItemsTable", SetCommand, RecordFilter)
                    UpdateTable("CodeVehicleProductsPartsTable", SetCommand, RecordFilter)
                End If
            Next
            ProductsPartsDataGridView.MultiSelect = False
            FillProductsPartsDataGridView()
        End If
    End Sub
    Private Sub WorkOrderPartsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WorkOrderPartsToolStripMenuItem.Click
        HistoryMode = 1
        SetFilterAndDisplayRequesteHistory()
    End Sub

    Private Sub SetFilterAndDisplayRequesteHistory()
        Select Case HistoryMode
            Case 1
                HistoriesGroupBox.Text = ProductsPartsDataGridView.Item("ManufacturerDescription_ShortText250", CurrentProductsPartsRow).Value &
                                     Space(1) & "P/N " & ProductsPartsDataGridView.Item("ManufacturerPartNo_ShortText30Fld", CurrentProductsPartsRow).Value
                HistoriesSelectionFilter = "WHERE ProductPartID_LongInteger = " & CurrentProductPartID
        End Select
        FillHistoriesDataGridView()
    End Sub
    Private Sub CopyDescriptionToolStripTextBox_Click(sender As Object, e As EventArgs) Handles CopyDescriptionToolStripTextBox.Click
        ProductsPartsDataGridViewContextMenuStrip.Visible = False
        Clipboard.SetText(ProductsPartsDataGridView.Item("ManufacturerDescription_ShortText250", CurrentProductsPartsRow).Value)
    End Sub
    Private Sub UnitTextBox_Click(sender As Object, e As EventArgs) Handles UnitTextBox.Click
        If IsNotEmpty(UnitTextBox.Text) Then
            If MsgBox("Would you like to replace the unit ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        End If
        Tunnel1 = "Tunnel2IsProductPartID"
        Tunnel2 = CurrentProductPartID
        ShowCalledForm(Me, ProductPartsPackingRelationsForm)
    End Sub

End Class