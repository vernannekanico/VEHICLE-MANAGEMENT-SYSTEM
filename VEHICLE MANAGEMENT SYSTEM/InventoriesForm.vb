Public Class InventoriesForm
    Private InventoriesFieldsToSelect = ""
    Private InventoriesSelectionFilter = ""
    Private InventoriesSelectionOrder = ""
    Private CurrentInventoriesRow As Integer = -1
    Private InventoriesRecordCount As Integer = -1
    Private CurrentProductPartID = -1
    Private InventoriesDataGridViewAlreadyFormated = False

    Private SavedCallingForm As Form

    Private Sub ReleasedPartForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SavedCallingForm = CallingForm
        FillInventoriesDataGridView()
    End Sub
    Private Sub FillInventoriesDataGridView()
        InventoriesSelectionOrder = " ORDER BY SystemDesc_ShortText100Fld DESC "
        InventoriesFieldsToSelect = " 
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
ProductsPartsTable.ProductsPartID_Autonumber
FROM StocksTable LEFT JOIN (((ProductsPartsTable LEFT JOIN MasterCodeBookTable ON ProductsPartsTable.MasterCodeBookID_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) LEFT JOIN PartsSpecificationsTable ON ProductsPartsTable.PartsSpecificationID_LongInteger = PartsSpecificationsTable.PartsSpecificationID_AutoNumber) LEFT JOIN BrandsTable ON ProductsPartsTable.BrandID_LongInteger = BrandsTable.BrandID_Autonumber) ON StocksTable.ProductPartID_LongInteger = ProductsPartsTable.ProductsPartID_Autonumber
"

        MySelection = InventoriesFieldsToSelect & InventoriesSelectionFilter & InventoriesSelectionOrder

        JustExecuteMySelection()
        InventoriesRecordCount = RecordCount

        If InventoriesRecordCount > 0 Then
            InventoriesGroupBox.Visible = True
        Else
            InventoriesGroupBox.Visible = False
        End If
        InventoriesDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If InventoriesRecordCount = 0 Then
            CurrentProductPartID = -1
        End If


        ' HERE AT ROW_ENTER, FillReleasedPartConcernsDataGridView is called and ReleasedPartConcernsbOX IS ALREADY FORMATTED
        If Not InventoriesDataGridViewAlreadyFormated Then
            FormatInventoriesDataGridView()
            SetFormWidthAndGroupBoxLeft(Me,
                                            MyStandardsFormMenuStrip,
                                            InventoriesGroupBox,
                                            InventoriesGroupBox,
                                            InventoriesGroupBox,
                                            InventoriesGroupBox)
        End If

        SetGroupBoxHeight(50, InventoriesRecordCount, InventoriesGroupBox, InventoriesDataGridView)
        Me.Top = VehicleManagementSystemForm.VehicleManagementMenuStrip.Top + VehicleManagementSystemForm.VehicleManagementMenuStrip.Height + 20
        Me.Left = VehicleManagementSystemForm.Left
        Me.Height = VehicleManagementSystemForm.Height - Me.Top

    End Sub
    Private Sub FormatInventoriesDataGridView()
        InventoriesDataGridViewAlreadyFormated = True
        InventoriesGroupBox.Width = 0
        For i = 0 To InventoriesDataGridView.Columns.GetColumnCount(0) - 1

            InventoriesDataGridView.Columns.Item(i).Visible = False
            Select Case InventoriesDataGridView.Columns.Item(i).Name
                Case "Selected"
                    InventoriesDataGridView.Columns.Item(i).HeaderText = "*"
                    InventoriesDataGridView.Columns.Item(i).Width = 20
                    InventoriesDataGridView.Columns.Item(i).Visible = True
                Case "MasterCodeBookID_LongInteger"
                    InventoriesDataGridView.Columns.Item(i).HeaderText = "CodeBookID"
                    InventoriesDataGridView.Columns.Item(i).Width = 80
                    InventoriesDataGridView.Columns.Item(i).Visible = True
                Case "SystemDesc_ShortText100Fld"
                    InventoriesDataGridView.Columns.Item(i).HeaderText = "Part Desc"
                    InventoriesDataGridView.Columns.Item(i).Width = 300
                    InventoriesDataGridView.Columns.Item(i).Visible = True
                Case "PartSpecifications_ShortText255"
                    InventoriesDataGridView.Columns.Item(i).HeaderText = "Specification"
                    InventoriesDataGridView.Columns.Item(i).Width = 150
                    InventoriesDataGridView.Columns.Item(i).Visible = True
                Case "ManufacturerPartNo_ShortText30Fld"
                    InventoriesDataGridView.Columns.Item(i).HeaderText = "Manufacturer PN"
                    InventoriesDataGridView.Columns.Item(i).Width = 150
                    InventoriesDataGridView.Columns.Item(i).Visible = True
                Case "ManufacturerDescription_ShortText250"
                    InventoriesDataGridView.Columns.Item(i).HeaderText = "Manufacturer Desc"
                    InventoriesDataGridView.Columns.Item(i).Width = 400
                    InventoriesDataGridView.Columns.Item(i).Visible = True
                Case "QuantityInStock_Double"
                    InventoriesDataGridView.Columns.Item(i).HeaderText = "Qty in Stock"
                    InventoriesDataGridView.Columns.Item(i).Width = 70
                    InventoriesDataGridView.Columns.Item(i).Visible = True
                Case "Unit_ShortText3"
                    InventoriesDataGridView.Columns.Item(i).HeaderText = "Unit"
                    InventoriesDataGridView.Columns.Item(i).Width = 70
                    InventoriesDataGridView.Columns.Item(i).Visible = True
                Case "BrandName_ShortText20"
                    InventoriesDataGridView.Columns.Item(i).HeaderText = "Brand"
                    InventoriesDataGridView.Columns.Item(i).Width = 150
                    InventoriesDataGridView.Columns.Item(i).Visible = True
                Case "MinimumQuantity_Double"
                    InventoriesDataGridView.Columns.Item(i).HeaderText = "Minimun Qty"
                    InventoriesDataGridView.Columns.Item(i).Width = 70
                    InventoriesDataGridView.Columns.Item(i).Visible = True
                Case "Location_ShortText10"
                    InventoriesDataGridView.Columns.Item(i).HeaderText = "Location"
                    InventoriesDataGridView.Columns.Item(i).Width = 70
                    InventoriesDataGridView.Columns.Item(i).Visible = True
                Case "ProductDescription_ShortText250"
                    InventoriesDataGridView.Columns.Item(i).HeaderText = "excel Desc"
                    InventoriesDataGridView.Columns.Item(i).Width = 400
                    InventoriesDataGridView.Columns.Item(i).Visible = True
                Case "VehicleRepairClassID_LongInteger"
                    InventoriesDataGridView.Columns.Item(i).HeaderText = "RepairClassID"
                    InventoriesDataGridView.Columns.Item(i).Width = 70
                    InventoriesDataGridView.Columns.Item(i).Visible = True
                Case "VehicleDescription"
                    InventoriesDataGridView.Columns.Item(i).HeaderText = "Vehicle model"
                    InventoriesDataGridView.Columns.Item(i).Width = 180
                    InventoriesDataGridView.Columns.Item(i).Visible = True
                Case "QuantityPerPack_Double"
                    InventoriesDataGridView.Columns.Item(i).HeaderText = "QtyPerPack"
                    InventoriesDataGridView.Columns.Item(i).Width = 70
                    InventoriesDataGridView.Columns.Item(i).Visible = True
                Case "UnitOfTheQuantity_ShortText3"
                    InventoriesDataGridView.Columns.Item(i).HeaderText = "UnitOfTheQuantity"
                    InventoriesDataGridView.Columns.Item(i).Width = 70
                    InventoriesDataGridView.Columns.Item(i).Visible = True
            End Select

            If InventoriesDataGridView.Columns.Item(i).Visible = True Then
                InventoriesGroupBox.Width = InventoriesGroupBox.Width + InventoriesDataGridView.Columns.Item(i).Width
            End If
        Next
        If InventoriesGroupBox.Width > VehicleManagementSystemForm.Width Then
            InventoriesGroupBox.Width = VehicleManagementSystemForm.Width - 4
        Else
            HorizontalCenter(InventoriesGroupBox, Me)
        End If
    End Sub
    Private Sub InventoriesDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles InventoriesDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If InventoriesRecordCount = 0 Then Exit Sub

        CurrentInventoriesRow = e.RowIndex
        CurrentProductPartID = InventoriesDataGridView.Item("ProductsPartID_Autonumber", CurrentInventoriesRow).Value


    End Sub

    Private Sub ReturnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnToolStripMenuItem.Click
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub

    Private Sub EditProductToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditProductToolStripMenuItem.Click
        SetupEditMode()
    End Sub
    Private Sub SetupEditMode()
        ProductDetailsGroup.Visible = True
        SelectToolStripMenuItem.Visible = False
        '     UpdateMasterCodeLinkToolStripMenuItem.Visible = False
        AddProductToolStripMenuItem.Visible = False
        DeleteProductToolStripMenuItem.Visible = False
        EditProductToolStripMenuItem.Visible = False

        LoadProductDetails()
        ManufacturerPartDescTextBox.Select()
        ManufacturerPartNoTextBox.Enabled = True
        BrandNameTextBox.Enabled = True
        UnitTextBox.Enabled = True
        AvailableQuantitiesTextBox.Enabled = True
        MinimumQantityTextBox.Enabled = True
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
            FillInventoriesDataGridView()
        End If

    End Sub
    Private Sub LoadProductDetails()
        FillField(ProductSpecificationTextBox.Text, InventoriesDataGridView.Item("PartSpecifications_ShortText255", CurrentInventoriesRow).Value)
        FillField(SystemPartDescriptionTextBox.Text, InventoriesDataGridView.Item("SystemDesc_ShortText100Fld", CurrentInventoriesRow).Value)
        FillField(ManufacturerPartNoTextBox.Text, InventoriesDataGridView.Item("ManufacturerPartNo_ShortText30Fld", CurrentInventoriesRow).Value)
        FillField(ManufacturerPartDescTextBox.Text, InventoriesDataGridView.Item("ManufacturerDescription_ShortText250", CurrentInventoriesRow).Value)
        FillField(BrandNameTextBox.Text, InventoriesDataGridView.Item("BrandName_ShortText20", CurrentInventoriesRow).Value)
        FillField(UnitTextBox.Text, InventoriesDataGridView.Item("Unit_ShortText3", CurrentInventoriesRow).Value)
        FillField(AvailableQuantitiesTextBox.Text, InventoriesDataGridView.Item("QuantityInStock_Double", CurrentInventoriesRow).Value)
        FillField(MinimumQantityTextBox.Text, InventoriesDataGridView.Item("MinimumQuantity_Double", CurrentInventoriesRow).Value)
        FillField(LocationTextBox.Text, InventoriesDataGridView.Item("Location_ShortText10", CurrentInventoriesRow).Value)
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
End Class