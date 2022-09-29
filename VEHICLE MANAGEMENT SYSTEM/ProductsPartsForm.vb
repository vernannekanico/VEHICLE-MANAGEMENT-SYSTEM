Public Class ProductsPartsForm
    Private ProductsPartsFieldsToSelect = " "
    Private ProductsPartsSelectionFilter = " "
    Private ProductsPartsSelectionOrder = " "
    Private ProductsPartsRecordCount = 0
    Private CurrentProductPartID As Integer = -1
    Private CurrentProductsPartsRow = -1
    Private ProductsPartsDataGridViewAlreadyFormated = False
    Private CleanedManufacturerPartNo = ""
    Private PurposeOfEntry As String
    Private CurrentMasterCodeBookID = -1
    Private CurrentPartDescription = ""
    Private CurrentBrandID = -1
    Private CurrentStocksID = -1
    Private CurrentProductPartsPackingID = -1
    Private SavedCallingForm As Form
    Private CurrentSpecificationsPartID = -1
    Private BackToEditMode = False
    Private ProductsMode = False
    Private CurrentProductSpecificationID = -1
    Private RequestedMasterCodeBook = -1
    Public CurrentVehicleID = -1

    Private Sub ProductsPartsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        SavedCallingForm = CallingForm
        'NOTE  
        '      Tunnel2 = CurrentMasterCodeBookID
        '      Tunnel3 = MODE  1 = NULL OR EMPTY (pRODUCTS mODE) 2 (STOCKS MODE)
        VerticalCenter(FiltersGroupBox, Me)
        HorizontalCenter(FiltersGroupBox, Me)
        VerticalCenter(ProductDetailsGroup, Me)
        HorizontalCenter(ProductDetailsGroup, Me)
        ProductSpecificationTextBox.Enabled = True
        Me.Top = VehicleManagementSystemForm.VehicleManagementMenuStrip.Top +
                VehicleManagementSystemForm.VehicleManagementMenuStrip.Height
        'NOTE: FILL PRODUCTS IS ALREADY IN THE ExecuteSearchParameters()
        If IsEmpty(Tunnel3) Then
            ProductsMode = True
        End If
        CurrentMasterCodeBookID = Tunnel2
        If IsNotEmpty(Tunnel2) Then RequestedMasterCodeBook = Tunnel2
        ExecuteSearchParameters()
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
                CurrentProductPartsPackingID = Tunnel2
                PackingTextBox.Text = Tunnel3
                PackingTextBox.Visible = True
            Case "Tunnel2IsMasterCodeBookID"
                ProductDetailsGroup.Visible = True
                ProductDetailsGroup.BringToFront()
                CurrentMasterCodeBookID = Tunnel2
                SystemPartDescriptionTextBox.Text = Tunnel3
        End Select

    End Sub
    Private Sub SetToStocksViewMode()
        FormatProductsPartsDataGridView()
        If Not SavedCallingForm.Name = "StoreRequisitionsForm" Then
            SelectToolStripMenuItem.Visible = False
        End If
    End Sub

    Private Sub SetToProductsViewMode()
        FormatProductsPartsDataGridView()
        SelectToolStripMenuItem.Visible = True
        ProductsPartsMenuStrip.Visible = True
        ProductsPartsMenuStrip.Left = CancelToolStripMenuItem.Width + 2
        ProductsPartsMenuStrip.Top = 0

        If IsNotEmpty(Tunnel3) Then
            CurrentMasterCodeBookID = Tunnel1
            CurrentPartDescription = Tunnel2
            PartDescriptionSearchTextBox.Text = Tunnel2
            SetSearchParameters()
        End If

    End Sub


    Private Sub FillProductsPartsDataGridView()

        ProductsPartsFieldsToSelect =
"
SELECT 
ProductsPartsTable.Selected, 
ProductsPartsTable.MasterCodeBookID_LongInteger, 
MasterCodeBookTable.SystemDesc_ShortText100Fld, 
PartsSpecificationsTable.PartsSpecificationID_AutoNumber,
PartsSpecificationsTable.PartSpecifications_ShortText255,
ProductsPartsTable.ManufacturerPartNo_ShortText30Fld, 
ProductsPartsTable.ManufacturerDescription_ShortText250, 
StocksTable.QuantityInStock_Double, 
ProductsPartsTable.Unit_ShortText3, 
BrandsTable.BrandID_Autonumber,
BrandsTable.BrandName_ShortText20, 
StocksTable.StockID_Autonumber, 
StocksTable.Location_ShortText10, 
StocksTable.MinimumQuantity_Double, 
ProductsPartsTable.VehicleRepairClassID_LongInteger, 
VehicleDescription.VehicleDescription, 
ProductsPartsTable.ProductsPartID_Autonumber, 
ProductPartsPackingsTable.QuantityPerPack_Double, 
ProductPartsPackingsTable.UnitOfThePacking_ShortText3,
ProductPartsPackingsTable.UnitOfTheQuantity_ShortText3
FROM ProductPartsPackingsTable RIGHT JOIN ((StocksTable RIGHT JOIN ((((((ProductsPartsTable LEFT JOIN BrandsTable ON ProductsPartsTable.BrandID_LongInteger = BrandsTable.BrandID_Autonumber) LEFT JOIN VehicleRepairClassTable ON ProductsPartsTable.VehicleRepairClassID_LongInteger = VehicleRepairClassTable.VehicleRepairClassID_AutoNumber) LEFT JOIN ServicedVehiclesTable ON ProductsPartsTable.ServicedVehicleID_LongInteger = ServicedVehiclesTable.ServicedVehicleID_AutoNumber) LEFT JOIN VehiclesTable ON ServicedVehiclesTable.VehicleID_LongInteger = VehiclesTable.VehicleID_AutoNumber) LEFT JOIN MasterCodeBookTable ON ProductsPartsTable.MasterCodeBookID_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) LEFT JOIN VehicleDescription ON VehiclesTable.VehicleID_AutoNumber = VehicleDescription.VehicleID_AutoNumber) ON StocksTable.ProductPartID_LongInteger = ProductsPartsTable.ProductsPartID_Autonumber) LEFT JOIN PartsSpecificationsTable ON ProductsPartsTable.PartsSpecificationID_LongInteger = PartsSpecificationsTable.PartsSpecificationID_AutoNumber) ON ProductPartsPackingsTable.ProductPartID_LongInteger = ProductsPartsTable.ProductsPartID_Autonumber"


        ProductsPartsSelectionOrder = " ORDER BY SystemDesc_ShortText100Fld, ManufacturerPartNo_ShortText30Fld "
        MySelection = ProductsPartsFieldsToSelect & ProductsPartsSelectionFilter & ProductsPartsSelectionOrder
        JustExecuteMySelection()
        ProductsPartsRecordCount = RecordCount
        ProductsPartsDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

        ProductsPartsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If Not ProductsPartsDataGridViewAlreadyFormated Then
            If ProductsMode Then
                SetToProductsViewMode()
            Else
                SetToStocksViewMode()
            End If
        End If
        Dim RowsHeight = 0
        Dim AvailableHeightSpace = VehicleManagementSystemForm.Height -
                                    (ProductsPartsMenuStrip.Top + ProductsPartsMenuStrip.Height) +
                                    ProductsPartsDataGridView.ColumnHeadersHeight
        Dim MyMaximumHeight = VehicleManagementSystemForm.Height -
                                  VehicleManagementSystemForm.VehicleManagementMenuStrip.Top

        If CurrentProductsPartsRow > -1 Then
            For i = 0 To ProductsPartsRecordCount - 1
                RowsHeight = RowsHeight + ProductsPartsDataGridView.Rows(i).Height
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
            Me.Height = mymaximumheight
        End If
        ProductDetailsGroup.Top = ProductsPartsDataGridView.Top
        ProductsPartsDataGridView.Top = ProductsPartsMenuStrip.Top + ProductsPartsMenuStrip.Height
    End Sub

    Private Sub FormatProductsPartsDataGridView()
        ProductsPartsDataGridViewAlreadyFormated = True
        ProductsPartsDataGridView.Width = 0
        For i = 0 To ProductsPartsDataGridView.Columns.GetColumnCount(0) - 1

            ProductsPartsDataGridView.Columns.Item(i).Visible = False
            Select Case ProductsPartsDataGridView.Columns.Item(i).Name
                Case "Selected"
                    ProductsPartsDataGridView.Columns.Item(i).HeaderText = "*"
                    ProductsPartsDataGridView.Columns.Item(i).Width = 20
                    ProductsPartsDataGridView.Columns.Item(i).Visible = True
                Case "MasterCodeBookID_LongInteger"
                    ProductsPartsDataGridView.Columns.Item(i).HeaderText = "CodeBookID"
                    ProductsPartsDataGridView.Columns.Item(i).Width = 80
                    ProductsPartsDataGridView.Columns.Item(i).Visible = True
                Case "ProductPartID_LongInteger"
                    ProductsPartsDataGridView.Columns.Item(i).HeaderText = "linked as"
                    ProductsPartsDataGridView.Columns.Item(i).Width = 80
                    ProductsPartsDataGridView.Columns.Item(i).Visible = True
                Case "SystemDesc_ShortText100Fld"
                    ProductsPartsDataGridView.Columns.Item(i).HeaderText = "Part Desc"
                    ProductsPartsDataGridView.Columns.Item(i).Width = 300
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
                    ProductsPartsDataGridView.Columns.Item(i).Width = 400
                    ProductsPartsDataGridView.Columns.Item(i).Visible = True
                Case "QuantityInStock_Double"
                    ProductsPartsDataGridView.Columns.Item(i).HeaderText = "Qty in Stock"
                    ProductsPartsDataGridView.Columns.Item(i).Width = 70
                    ProductsPartsDataGridView.Columns.Item(i).Visible = True
                Case "Unit_ShortText3"
                    ProductsPartsDataGridView.Columns.Item(i).HeaderText = "Unit"
                    ProductsPartsDataGridView.Columns.Item(i).Width = 70
                    ProductsPartsDataGridView.Columns.Item(i).Visible = True
                Case "BrandName_ShortText20"
                    ProductsPartsDataGridView.Columns.Item(i).HeaderText = "Brand"
                    ProductsPartsDataGridView.Columns.Item(i).Width = 150
                    ProductsPartsDataGridView.Columns.Item(i).Visible = True
                Case "MinimumQuantity_Double"
                    ProductsPartsDataGridView.Columns.Item(i).HeaderText = "Minimun Qty"
                    ProductsPartsDataGridView.Columns.Item(i).Width = 70
                    ProductsPartsDataGridView.Columns.Item(i).Visible = True
                Case "Location_ShortText10"
                    ProductsPartsDataGridView.Columns.Item(i).HeaderText = "Location"
                    ProductsPartsDataGridView.Columns.Item(i).Width = 70
                    ProductsPartsDataGridView.Columns.Item(i).Visible = True
                Case "ProductDescription_ShortText250"
                    ProductsPartsDataGridView.Columns.Item(i).HeaderText = "excel Desc"
                    ProductsPartsDataGridView.Columns.Item(i).Width = 400
                    ProductsPartsDataGridView.Columns.Item(i).Visible = True
                Case "VehicleRepairClassID_LongInteger"
                    ProductsPartsDataGridView.Columns.Item(i).HeaderText = "RepairClassID"
                    ProductsPartsDataGridView.Columns.Item(i).Width = 70
                    ProductsPartsDataGridView.Columns.Item(i).Visible = True
                Case "VehicleDescription"
                    ProductsPartsDataGridView.Columns.Item(i).HeaderText = "Vehicle model"
                    ProductsPartsDataGridView.Columns.Item(i).Width = 180
                    ProductsPartsDataGridView.Columns.Item(i).Visible = True
                Case "QuantityPerPack_Double"
                    ProductsPartsDataGridView.Columns.Item(i).HeaderText = "QtyPerPack"
                    ProductsPartsDataGridView.Columns.Item(i).Width = 70
                    ProductsPartsDataGridView.Columns.Item(i).Visible = True
                Case "UnitOfTheQuantity_ShortText3"
                    ProductsPartsDataGridView.Columns.Item(i).HeaderText = "UnitOfTheQuantity"
                    ProductsPartsDataGridView.Columns.Item(i).Width = 70
                    ProductsPartsDataGridView.Columns.Item(i).Visible = True
            End Select


            If ProductsPartsDataGridView.Columns.Item(i).Visible = True Then
                ProductsPartsDataGridView.Width = ProductsPartsDataGridView.Width + ProductsPartsDataGridView.Columns.Item(i).Width
            End If
        Next

        ' NOTE" SYSTEM AUTOFITS THE GRIDVIEW FIELDS ACCORDING To THEIR WITDH
        Me.Width = VehicleManagementSystemForm.Width
        If ProductsPartsDataGridView.Width > Me.Width + 20 Then
            ProductsPartsDataGridView.Width = Me.Width - 80
        Else
            ProductsPartsDataGridView.Width = ProductsPartsDataGridView.Width + 20
        End If
        '
        If Me.Width > ProductsPartsDataGridView.Width Then
            ProductsPartsDataGridView.Left = (Me.Width - ProductsPartsDataGridView.Width) / 2
        Else
            ProductsPartsDataGridView.Left = Me.Left
            ProductsPartsDataGridView.Width = Me.Width
        End If
        ProductsPartsDataGridView.Top = (ProductsPartsMenuStrip.Top + ProductsPartsMenuStrip.Height)
        Me.Left = VehicleManagementSystemForm.Left
    End Sub
    Private Sub ProductsPartsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles ProductsPartsDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If ProductsPartsRecordCount = 0 Then Exit Sub
        CurrentProductsPartsRow = e.RowIndex
        CurrentProductPartID = ProductsPartsDataGridView.Item("ProductsPartID_Autonumber", CurrentProductsPartsRow).Value
        FillField(CurrentProductSpecificationID, ProductsPartsDataGridView.Item("PartsSpecificationID_AutoNumber", CurrentProductsPartsRow).Value)
        CurrentMasterCodeBookID = ProductsPartsDataGridView.Item("MasterCodeBookID_LongInteger", CurrentProductsPartsRow).Value
        FillField(CurrentStocksID, ProductsPartsDataGridView.Item("StockID_Autonumber", CurrentProductsPartsRow).Value)
        CurrentBrandID = ProductsPartsDataGridView.Item("ProductsPartID_Autonumber", CurrentProductsPartsRow).Value
        SelectToolStripMenuItem.Visible = True
        If RequestedMasterCodeBook > -1 Then
            If RequestedMasterCodeBook = CurrentMasterCodeBookID Then
                SelectToolStripMenuItem.Visible = True
            Else
                SelectToolStripMenuItem.Visible = False
            End If
        End If

    End Sub

    Private Sub SelectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectToolStripMenuItem.Click
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
        Tunnel1 = "Tunnel2IsProductPartID"
        Tunnel2 = CurrentProductPartID

        Select Case SavedCallingForm.Name
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
                RequestPartsForm.PackingTextBox.Text = PackingTextBox.Text
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
    Private Sub UpdateStocksTable()

    End Sub
    Private Sub ExecuteSearchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExecuteSearchToolStripMenuItem.Click
        FiltersGroupBox.Visible = False
        If PartDescriptionSearchTextBox.Text = "" And PartNoSearchTextBox.Text = "" Then Exit Sub
        ExecuteSearchParameters()
        If ProductsPartsRecordCount > 0 Then
            ProductsPartsDataGridView.Rows(0).Selected = False
        End If

    End Sub
    Private Sub ExecuteSearchParameters()
        If PartDescriptionSearchTextBox.Text = "" And
            PartNoSearchTextBox.Text = "" And
            CurrentMasterCodeBookID = -1 Then
            ProductsPartsSelectionFilter = " WHERE StocksTable.MinimumQuantity_Double > 0 "
            FillProductsPartsDataGridView()
            Exit Sub

        End If
        SetSearchParameters()
        FillProductsPartsDataGridView()
    End Sub
    Private Sub SetSearchParameters()
        ProductsPartsSelectionFilter = " WHERE "
        Dim xxOR = ""
        If IsNotEmpty(PartNoSearchTextBox.Text) Then
            ProductsPartsSelectionFilter &= " ManufacturerPartNo_ShortText30Fld Like " & InQuotes("%" & Trim(PartNoSearchTextBox.Text) & "%")
            ProductsPartsSelectionFilter &= " OR ManufacturerPartNoClean_ShortText30Fld Like " & InQuotes("%" & GetCleanedManufacturerPartNo(PartNoSearchTextBox.Text) & "%")
            xxOR = " OR "
        End If
        If IsNotEmpty(PartDescriptionSearchTextBox.Text) Then
            ProductsPartsSelectionFilter &= xxOR & " ProductDescription_ShortText250 Like " & InQuotes("%" & Trim(PartDescriptionSearchTextBox.Text) & "%")
            ProductsPartsSelectionFilter &= " OR  ManufacturerDescription_ShortText250 Like " & InQuotes("%" & Trim(PartDescriptionSearchTextBox.Text) & "%")
            ProductsPartsSelectionFilter &= " OR  SystemDesc_ShortText100Fld Like " & InQuotes("%" & Trim(PartDescriptionSearchTextBox.Text) & "%")
            '            
        End If
        If IsNotEmpty(CurrentMasterCodeBookID) Then
            ProductsPartsSelectionFilter &= " OR ProductsPartsTable.MasterCodeBookID_LongInteger = " & CurrentMasterCodeBookID.ToString
        End If
    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        SystemPartDescriptionTextBox.Text = ""
        ManufacturerPartNoTextBox.Text = ""
        ManufacturerPartDescTextBox.Text = ""
        BrandNameTextBox.Text = ""
        UnitTextBox.Text = ""
        AvailableQuantitiesTextBox.Text = ""
        LocationTextBox.Text = ""
        MinimumQantityTextBox.Text = ""
        PackingTextBox.Text = ""
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
        ToolStripMenuItem1.Visible = False

        lOADProductDetails()
        ManufacturerPartDescTextBox.Select()
        ManufacturerPartNoTextBox.Enabled = True
        BrandNameTextBox.Enabled = True
        UnitTextBox.Enabled = True
        AvailableQuantitiesTextBox.Enabled = True
        MinimumQantityTextBox.Enabled = True
        LocationTextBox.Enabled = True
    End Sub
    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
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
            FillProductsPartsDataGridView()
        End If

    End Sub

    Private Sub lOADProductDetails()
        FillField(ProductSpecificationTextBox.Text, ProductsPartsDataGridView.Item("PartSpecifications_ShortText255", CurrentProductsPartsRow).Value)
        FillField(SystemPartDescriptionTextBox.Text, ProductsPartsDataGridView.Item("SystemDesc_ShortText100Fld", CurrentProductsPartsRow).Value)
        FillField(ManufacturerPartNoTextBox.Text, ProductsPartsDataGridView.Item("ManufacturerPartNo_ShortText30Fld", CurrentProductsPartsRow).Value)
        FillField(ManufacturerPartDescTextBox.Text, ProductsPartsDataGridView.Item("ManufacturerDescription_ShortText250", CurrentProductsPartsRow).Value)
        FillField(BrandNameTextBox.Text, ProductsPartsDataGridView.Item("BrandName_ShortText20", CurrentProductsPartsRow).Value)
        FillField(CurrentBrandID, ProductsPartsDataGridView.Item("BrandID_Autonumber", CurrentProductsPartsRow).Value)
        FillField(UnitTextBox.Text, ProductsPartsDataGridView.Item("Unit_ShortText3", CurrentProductsPartsRow).Value)
        FillField(AvailableQuantitiesTextBox.Text, ProductsPartsDataGridView.Item("QuantityInStock_Double", CurrentProductsPartsRow).Value)
        FillField(MinimumQantityTextBox.Text, ProductsPartsDataGridView.Item("MinimumQuantity_Double", CurrentProductsPartsRow).Value)
        FillField(LocationTextBox.Text, ProductsPartsDataGridView.Item("Location_ShortText10", CurrentProductsPartsRow).Value)
        If IsNotEmpty(ProductsPartsDataGridView.Item("QuantityPerPack_Double", CurrentProductsPartsRow).Value) Then
            PackingTextBox.Text = ProductsPartsDataGridView.Item("QuantityPerPack_Double", CurrentProductsPartsRow).Value.ToString & Space(1) &
                                      ProductsPartsDataGridView.Item("UnitOfTheQuantity_ShortText3", CurrentProductsPartsRow).Value.ToString &
                                        " / " &
                                      ProductsPartsDataGridView.Item("Unit_ShortText3", CurrentProductsPartsRow).Value.ToString
            PackingTextBox.Visible = True
        Else
            PackingTextBox.Text = ""
            PackingTextBox.Visible = False
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        If IsEmpty(SystemPartDescriptionTextBox.Text) Then
            MsgBox("This Product is not linked to the MasterCodeBook, link this as " & CurrentPartDescription & "?")
            ShowMasterCodeBookForm()
            Exit Sub
        End If
        'VALIDATIONS
        Dim AnswerToMessage = ""
        If Trim(ManufacturerPartNoTextBox.Text) = "" Then
            If MsgBox("Leave the PART NUMBER blank ? ", MsgBoxStyle.YesNo) = vbYesNo Then
                ManufacturerPartNoTextBox.Select()
                Exit Sub
            End If
        End If
        If Trim(ManufacturerPartDescTextBox.Text) = "" Then
            ManufacturerPartDescTextBox.Select()
            Exit Sub
        End If
        If Trim(BrandNameTextBox.Text) = "" Then
            AnswerToMessage = MsgBox("Would you like to leave the Brand blank ?", vbYesNo)
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
        If AChangeInStocksDetails() Then
            RegisterStocksDetailsChanges()
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
        ToolStripMenuItem1.Visible = True
    End Sub
    Private Function AChangeInStocksDetails()

        If IsEmpty(CurrentStocksID) Then Return True
        If TheseAreNotEqual(AvailableQuantitiesTextBox.Text, ProductsPartsDataGridView.Item("QuantityInStock_Double", CurrentProductsPartsRow).Value, PurposeOfEntry) Then Return True
        If TheseAreNotEqual(MinimumQantityTextBox.Text, ProductsPartsDataGridView.Item("MinimumQuantity_Double", CurrentProductsPartsRow).Value, PurposeOfEntry) Then Return True
        If TheseAreNotEqual(LocationTextBox.Text, ProductsPartsDataGridView.Item("Location_ShortText10", CurrentProductsPartsRow).Value, PurposeOfEntry) Then Return True
        Return False
    End Function
    Private Sub RegisterStocksDetailsChanges()

        If IsEmpty(CurrentStocksID) Then
            InsertNewStocksInfoChanges()
        Else
            If MsgBox("Continue Save Stocks Info Changes ? ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                If MsgBox("Disregard your changes ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    SystemPartDescriptionTextBox.Select()
                    BackToEditMode = True
                    Exit Sub
                End If
            End If
            UpdateStocksInfoChanges()
        End If
        RegisterProductPartnumnberChanges()
    End Sub
    Private Sub InsertNewStocksInfoChanges()
        Dim FieldsToUpdate =
                               "
                               ProductPartID_LongInteger,
                               Location_ShortText10,
                               MinimumQuantity_Double,
                               QuantityInStock_Double
                                "
        Dim FieldsData =
                                CurrentProductPartID.ToString & "," &
                                InQuotes(LocationTextBox.Text) & "," &
                                Val(MinimumQantityTextBox.Text) & "," &
                                Val(AvailableQuantitiesTextBox.Text)

        CurrentStocksID = InsertNewRecord("StocksTable", FieldsToUpdate, FieldsData)

        'UPDATE ProductsPartTable AND MARK FIELD Selected true
        UpdateTable("ProductsPartsTable", "SET Selected = True", "WHERE ProductsPartID_AutoNumber = " & CurrentProductPartID.ToString)
    End Sub
    Private Sub UpdateStocksInfoChanges()
        Dim RecordFilter = " WHERE StockID_Autonumber = " & Str(CurrentStocksID)
        Dim SetCommand =
                    " Set " &
                    " Location_ShortText10 = " & InQuotes(LocationTextBox.Text) & "," &
                    " MinimumQuantity_Double = " & Val(MinimumQantityTextBox.Text) & "," &
                    " QuantityInStock_Double = " & Val(AvailableQuantitiesTextBox.Text)
        UpdateTable("StocksTable", SetCommand, RecordFilter)
    End Sub

    Private Function AChangeInProductDetails()

        If CurrentProductsPartsRow > -1 Then
            If TheseAreNotEqual(SystemPartDescriptionTextBox.Text, ProductsPartsDataGridView.Item("SystemDesc_ShortText100Fld", CurrentProductsPartsRow).Value, PurposeOfEntry) Then Return True
            If TheseAreNotEqual(ManufacturerPartNoTextBox.Text, ProductsPartsDataGridView.Item("ManufacturerPartNo_ShortText30Fld", CurrentProductsPartsRow).Value, PurposeOfEntry) Then Return True
            If TheseAreNotEqual(ManufacturerPartDescTextBox.Text, ProductsPartsDataGridView.Item("ManufacturerDescription_ShortText250", CurrentProductsPartsRow).Value, PurposeOfEntry) Then Return True
            If TheseAreNotEqual(ProductSpecificationTextBox.Text, ProductsPartsDataGridView.Item("PartSpecifications_ShortText255", CurrentProductsPartsRow).Value, PurposeOfEntry) Then Return True
            If TheseAreNotEqual(BrandNameTextBox.Text, ProductsPartsDataGridView.Item("BrandName_ShortText20", CurrentProductsPartsRow).Value, PurposeOfEntry) Then Return True
            If TheseAreNotEqual(UnitTextBox.Text, ProductsPartsDataGridView.Item("Unit_ShortText3", CurrentProductsPartsRow).Value, PurposeOfEntry) Then Return True
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
        RegisterProductPartnumnberChanges()
    End Sub
    Private Sub RegisterProductPartnumnberChanges()
        MsgBox("STUDY THIS, WORKING WITH PART NUMBERS")
    End Sub
    Private Sub InsertNewProductsPartChanges()
        Dim FieldsToUpdate =
                    " ManufacturerPartNo_ShortText30Fld, " &
                    " ManufacturerPartNoClean_ShortText30Fld, " &
                    " ManufacturerDescription_ShortText250, " &
                    " MasterCodeBookID_LongInteger, " &
                    " PartsSpecificationID_LongInteger, " &
                    " BrandID_LongInteger, " &
                   " Unit_ShortText3 "

        Dim ReplacementData =
                    InQuotes(ManufacturerPartNoTextBox.Text) & ", " &
                    InQuotes(GetCleanedManufacturerPartNo(ManufacturerPartNoTextBox.Text)) & ", " &
                    InQuotes(Trim(ManufacturerPartDescTextBox.Text)) & ", " &
                    Str(CurrentMasterCodeBookID) & ", " &
                    CurrentProductSpecificationID.ToString & ", " &
                    Str(CurrentBrandID) & ", " &
                    InQuotes(Trim(UnitTextBox.Text).ToUpper)

        CurrentProductPartID = InsertNewRecord("ProductsPartsTable", FieldsToUpdate, ReplacementData)
        If CurrentProductPartsPackingID > -1 Then
            'update new packing record with with the currentproduct
            Dim RecordFilter = " WHERE ProductPartsPackingID_Autonumber = " & CurrentProductPartsPackingID.ToString
            Dim SetCommand = " SET ProductPartID_LongInteger = " & CurrentProductPartID.ToString
            UpdateTable("ProductPartsPackingsTable", SetCommand, RecordFilter)

            'UPDATE ProductsPartTable AND MARK FIELD Selected true
            UpdateTable("ProductsPartsTable", "SET Selected = True", "WHERE ProductsPartID_AutoNumber = " & CurrentProductPartID.ToString)
        End If
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
                    " BrandID_LongInteger = " & Str(CurrentBrandID) & ", " &
                    " Unit_ShortText3 = " & InQuotes(Trim(UnitTextBox.Text).ToUpper)
        UpdateTable("ProductsPartsTable", SetCommand, RecordFilter)
    End Sub


    Private Sub UpdateMasterCodeLinkToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateMasterCodeLinkToolStripMenuItem.Click
        lOADProductDetails()
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
                      " AND UCASE(ProductDescription_ShortText250) = " & InQuotes((ManufacturerPartDescTextBox.Text).ToUpper) &
                      " AND UCASE(Unit_ShortText3) = " & InQuotes((UnitTextBox.Text).ToUpper) &
            xxCurrentBrandID

            If RecordIsFound() Then
                MsgBox("Product Part already exist")

            End If
        Else

        End If
    End Sub
    Private Function GetCleanedManufacturerPartNo(PassedManufacturerPartNumber)
        CleanedManufacturerPartNo = ""
        Dim LastKeyedIn = ""
        For i = 1 To Len(Trim(PassedManufacturerPartNumber))
            LastKeyedIn = Mid(PassedManufacturerPartNumber, i, 1).ToUpper
            If InStr("012345678910ABCDEFGHIJKLMNOPQRSTUVWXYZ", LastKeyedIn) > 0 Then
                Dim xxcccx = Mid(PassedManufacturerPartNumber, i, 1)
                CleanedManufacturerPartNo &= Mid(PassedManufacturerPartNumber, i, 1)
            End If
        Next
        Return CleanedManufacturerPartNo
    End Function
    Private Sub ProductDetailsGroup_VisibleChanged(sender As Object, e As EventArgs) Handles ProductDetailsGroup.VisibleChanged
        If ProductDetailsGroup.Visible = True Then
            If Not PurposeOfEntry = "ADD" Then lOADProductDetails()
            SaveToolStripMenuItem.Visible = True
                AddToolStripMenuItem.Visible = False
                EditToolStripMenuItem.Visible = False
                DeleteToolStripMenuItem.Visible = False
                SelectToolStripMenuItem.Visible = False
                ProductDetailsToolStripMenuItem.Visible = False
                ToolStripMenuItem1.Visible = False
                UpdateMasterCodeLinkToolStripMenuItem.Visible = False
            Else
                SaveToolStripMenuItem.Visible = False
            AddToolStripMenuItem.Visible = True
            EditToolStripMenuItem.Visible = True
            DeleteToolStripMenuItem.Visible = True
            SelectToolStripMenuItem.Visible = True
            ProductDetailsToolStripMenuItem.Visible = True
            ToolStripMenuItem1.Visible = True
            UpdateMasterCodeLinkToolStripMenuItem.Visible = True
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


    Private Sub PackingButton_Click(sender As Object, e As EventArgs) Handles PackingButton.Click
        If IsEmpty(UnitTextBox.Text) Then
            MsgBox("Unit should not be empty before working on the packing")
            UnitTextBox.Select()
            Exit Sub
        End If
        Tunnel1 = "Tunnel2IsProductPartID"
        Tunnel2 = CurrentProductPartID
        ShowCalledForm(Me, ProductPartsPackingsForm)
        ProductPartsPackingsForm.Text = "PACKINGS for " & ManufacturerPartDescTextBox.Text
        If IsNotEmpty(ManufacturerPartNoTextBox.Text) Then
            ProductPartsPackingsForm.Text = ProductPartsPackingsForm.Text & " PART NUMBER: " & ManufacturerPartNoTextBox.Text
        End If
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

    Private Sub PartDescriptionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PartDescriptionToolStripMenuItem.Click
        PartDescriptionSearchTextBox.Select()
        FiltersGroupBox.Visible = True

    End Sub
    Private Sub PartDescriptionSearchTextBox_TextChanged(sender As Object, e As EventArgs) Handles PartDescriptionSearchTextBox.TextChanged
        PartDescriptionToolStripMenuItem.Text = "Product Description = " & PartDescriptionSearchTextBox.Text
    End Sub
    Private Sub PartNoSearchTextBox_TextChanged(sender As Object, e As EventArgs) Handles PartNoSearchTextBox.TextChanged
        PartDescriptionToolStripMenuItem.Text = "Part No = " & PartNoSearchTextBox.Text
    End Sub
    Private Sub PartNumberToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PartNumberToolStripMenuItem.Click
        FiltersGroupBox.Visible = True
    End Sub
    Private Sub PartSpecificationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PartSpecificationToolStripMenuItem.Click
        FiltersGroupBox.Visible = True
    End Sub

    Private Sub VehicleFilterOFFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToggleVehiclefilterToolStripMenuItem.Click
        If ToggleVehiclefilterToolStripMenuItem.Text = "ON" Then
            ToggleVehiclefilterToolStripMenuItem.Text = "OFF"
        Else
            ToggleVehiclefilterToolStripMenuItem.Text = "ON"
        End If
        FiltersGroupBox.Visible = True
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

    Private Sub ProductSpecificationButton_Click(sender As Object, e As EventArgs) Handles ProductSpecificationButton.Click

    End Sub

    Private Sub VehicleModelButton_Click(sender As Object, e As EventArgs) Handles VehicleModelButton.Click

    End Sub

    Private Sub PurchasesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PurchasesToolStripMenuItem.Click

    End Sub

    Private Sub UsageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UsageToolStripMenuItem.Click

    End Sub

    Private Sub VehicleLinksToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VehicleLinksToolStripMenuItem.Click

    End Sub
End Class