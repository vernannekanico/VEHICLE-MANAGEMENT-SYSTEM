Public Class PartsRequisitionsForm

    '   Private CurrentWorkOrderPartsRequisitionsItemsDataGridViewRow As Integer = -1
    '    Private WorkOrderPartsRequisitionsItemsDataGridViewAlreadyFormated = False
    Private ProductsPartsDataGridViewAlreadyFormated = False
    '   Private CurrentQuantity = -1


    Private CurrentIssuedProductPartID = -1
    Private PartsRequisitionStatus = ""

    Private PartsRequisitionsTable As New MyDbControls
    Private PartsRequisitionsFieldsToSelect = ""
    Private PartsRequisitionsTableLinks = ""
    Private PartsRequisitionsSelectionFilter = ""
    Private PartsRequisitionsSelectionOrder = ""
    Private CurrentPartsRequisitionsRow As Integer = -1
    Private PartsRequisitionsRecordCount As Integer = -1
    Private CurrentPartsRequisitionStatus As String
    Private PartsRequisitionsDataGridViewAlreadyFormatted = False
    Private CurrentPartsRequisitionID = -1
    Private PartsRequisitionStatusSelection As Integer = 1
    Private PartsRequisitionType = -1

    Private PartsRequisitionsItemsFieldsToSelect = ""
    Private PartsRequisitionsItemsTableLinks = ""
    Private PartsRequisitionsItemsSelectionFilter = ""
    Private PartsRequisitionsItemsSelectionOrder = ""
    Private PartsRequisitionsItemsRecordCount As Integer = -1
    Private PartsRequisitionsItemsDataGridViewAlreadyFormated = False
    Private CurrentPartsRequisitionItemID = -1
    Private CurrentPartsRequisitionsID = -1
    Private CurrentPartsRequisitionsItemsDataGridViewRow As Integer = -1

    Private CurrentProductsPartID = -1
    Private CurrentQtyToIssue = -1
    Private CurrentQtyToOrder = -1
    Private CreatingRequisitionItems = False
    Private SavedCallingForm As Form
    Private CurrentPurchaseOrderID = -1

    Private Sub PartsRequisitionsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        SavedCallingForm = CallingForm
        If Val(Tunnel1) > 0 Then
            CurrentPurchaseOrderID = Tunnel1
            SelectToolStripMenuItem.Visible = True
        Else
            CreatePurchaseOrderToolStripMenuItem.Visible = True
        End If
        SetRequisitionsSelectionFilter(10, Me, "ALL REQUISITIONS")
        PartsRequisitionsItemsDataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        SetRequisitionsSelectionFilter(0, Me, "OUTSTANDING REQUISITIONS")
        PartsRequisitionsItemsDataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        FillPartsRequisitionsDataGridView()
    End Sub

    Private Sub PartsRequisitionsForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        If Me.Enabled = False Then Exit Sub
        CallingForm = SavedCallingForm

        ' GET RETURNED DATA HERE
        'show
        Select Case Tunnel1

            Case Else
                MsgBox("setup this routine")
        End Select


        Me.Select()             'enables the page to be active

    End Sub
    Public Sub FillPartsRequisitionsDataGridView()
        PartsRequisitionsSelectionOrder = " ORDER BY PartsRequisitionID_AutoNumber DESC "
        Dim xxWorkOrder = " IIf(PartsRequisitionsTable.PartsRequisitionStatus_Integer = 1, " & Chr(34) & "Work Order" & Chr(34) & ","
        Dim xxStoreOrder = " IIf(PartsRequisitionsTable.PartsRequisitionStatus_Integer = 2, " & Chr(34) & "Store Order" & Chr(34) & ","
        PartsRequisitionType = xxWorkOrder & xxStoreOrder & " )) AS PartsRequisitionType,  "

        Dim xxOutstanding = " IIf(PartsRequisitionsTable.PartsRequisitionStatus_Integer = 0, " & Chr(34) & "Outstanding" & Chr(34) & ","
        Dim xxPartiallyOrdered = " IIf(PartsRequisitionsTable.PartsRequisitionStatus_Integer = 1, " & Chr(34) & "Partially Ordered" & Chr(34) & ","
        Dim xxReordered = " IIf(PartsRequisitionsTable.PartsRequisitionStatus_Integer = 2, " & Chr(34) & "Re-Ordered" & Chr(34) & ","
        Dim xxCompletelyOrdered = " IIf(PartsRequisitionsTable.PartsRequisitionStatus_Integer = 3, " & Chr(34) & "Completely Ordered" & Chr(34) & ","

        PartsRequisitionStatus = xxOutstanding & xxPartiallyOrdered & xxCompletelyOrdered & xxReordered & Chr(34) & Chr(34) &
                                " )))) AS PartsRequisitionStatus "

        PartsRequisitionsFieldsToSelect =
" 
SELECT PartsRequisitionsTable.PartsRequisitionID_AutoNumber,
PartsRequisitionsTable.RequisitionRevision_Integer,
PartsRequisitionsTable.RequisitionDate_ShortDate,
PartsRequisitionsTable.RequestedByID_LongInteger,
PartsRequisitionsTable.PartsRequisitionStatus_Integer,
PartsRequisitionsTable.PartsRequisitionType_Byte,
PartsRequisitionsTable.VehicleID_LongInteger,
VehicleTypeTable.VehicleType_ShortText20,
VehicleTrimTable.VehicleTrimName_ShortText25,
VehicleModelsTable.VehicleModel_ShortText20,
VehiclesTable.YearManufactured_ShortText4,
VehiclesTable.Engine_ShortText20,
(VehiclesTable.YearManufactured_ShortText4 & Space(1) & Trim(VehicleTypeTable.VehicleType_ShortText20) & Space(1) & Trim(VehicleModelsTable.VehicleModel_ShortText20) & Space(1) & Trim(VehicleTrimTable.VehicleTrimName_ShortText25)) AS VehicleDescription, PersonnelTable.LastName_ShortText15, PersonnelTable.FirstName_ShortText15,
" & PartsRequisitionType &
PartsRequisitionStatus &
 "
FROM (PartsRequisitionsTable LEFT JOIN PersonnelTable ON PartsRequisitionsTable.RequestedByID_LongInteger = PersonnelTable.PersonnelID_AutoNumber) LEFT JOIN ((((VehiclesTable LEFT JOIN VehicleModelsRelationsTable ON VehiclesTable.VehicleModelsRelationID_LongInteger = VehicleModelsRelationsTable.VehicleModelsRelationID_Autonumber) LEFT JOIN VehicleTypeTable ON VehicleModelsRelationsTable.VehicleTypeID_LongInteger = VehicleTypeTable.VehicleTypeID_AutoNumber) LEFT JOIN VehicleTrimTable ON VehicleModelsRelationsTable.VehicleTrimID_LongInteger = VehicleTrimTable.VehicleTrimID_Autonumber) LEFT JOIN VehicleModelsTable ON VehicleModelsRelationsTable.VehicleModelID_LongInteger = VehicleModelsTable.VehicleModelID_Autonumber) ON PartsRequisitionsTable.VehicleID_LongInteger = VehiclesTable.VehicleID_AutoNumber
"
        PartsRequisitionsTableLinks = " 
"
        MySelection = PartsRequisitionsFieldsToSelect & PartsRequisitionsTableLinks & PartsRequisitionsSelectionFilter & PartsRequisitionsSelectionOrder
        JustExecuteMySelection()

        PartsRequisitionsRecordCount = RecordCount
        If PartsRequisitionsRecordCount = 0 Then
            PartsRequisitionsItemsGroupBox.Visible = False
        Else
            PartsRequisitionsItemsGroupBox.Visible = True
        End If
        PartsRequisitionsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        Dim NoOfHeaderLines = 2, RecordsToDisplay = 10
        SetGroupBoxHeight(NoOfHeaderLines, RecordsToDisplay, PartsRequisitionsRecordCount, PartsRequisitionsGroupBox, PartsRequisitionsDataGridView)

        If Not PartsRequisitionsDataGridViewAlreadyFormatted Then
            FormatPartsRequisitionsDataGridView()
        End If
        PartsRequisitionsItemsGroupBox.Top = PartsRequisitionsGroupBox.Top + PartsRequisitionsGroupBox.Height + 4
        SetFormWidthAndGroupBoxLeft()
        Me.Width = VehicleManagementSystemForm.Width - 4
        Me.Left = (VehicleManagementSystemForm.Width - Me.Width) / 2
        PartsRequisitionsGroupBox.Left = 2
        PartsRequisitionsItemsGroupBox.Left = 2
    End Sub
    Private Sub SetFormWidthAndGroupBoxLeft()
        Dim LargestWidth = 0

        For i = 1 To 2
            If PartsRequisitionsGroupBox.Width > LargestWidth Then
                LargestWidth = PartsRequisitionsGroupBox.Width
            ElseIf PartsRequisitionsItemsGroupBox.Width > LargestWidth Then
                LargestWidth = PartsRequisitionsItemsGroupBox.Width
            End If
        Next

        If LargestWidth > VehicleManagementSystemForm.Width Then
        Else
            Me.Width = LargestWidth + 4
        End If
    End Sub
    Private Sub FormatPartsRequisitionsDataGridView()
        PartsRequisitionsDataGridViewAlreadyFormatted = True
        PartsRequisitionsGroupBox.Width = 0
        For i = 0 To PartsRequisitionsDataGridView.Columns.GetColumnCount(0) - 1

            PartsRequisitionsDataGridView.Columns.Item(i).Visible = False
            Select Case PartsRequisitionsDataGridView.Columns.Item(i).Name
                Case "PartsRequisitionID_AutoNumber"
                    PartsRequisitionsDataGridView.Columns.Item(i).HeaderText = "Requistion No."
                    PartsRequisitionsDataGridView.Columns.Item(i).Width = 90
                    PartsRequisitionsDataGridView.Columns.Item(i).Visible = True
                Case "RequisitionRevision_Integer"
                    PartsRequisitionsDataGridView.Columns.Item(i).HeaderText = "Rev."
                    PartsRequisitionsDataGridView.Columns.Item(i).Width = 50
                    PartsRequisitionsDataGridView.Columns.Item(i).Visible = True
                Case "RequisitionDate_ShortDate"
                    PartsRequisitionsDataGridView.Columns.Item(i).HeaderText = "Date"
                    PartsRequisitionsDataGridView.Columns.Item(i).Width = 100
                    PartsRequisitionsDataGridView.Columns.Item(i).Visible = True
                Case "VehicleDescription"
                    PartsRequisitionsDataGridView.Columns.Item(i).HeaderText = "For Vehicle"
                    PartsRequisitionsDataGridView.Columns.Item(i).Width = 300
                    PartsRequisitionsDataGridView.Columns.Item(i).Visible = True
                Case "RequestedBy"
                    PartsRequisitionsDataGridView.Columns.Item(i).HeaderText = "Requested By"
                    PartsRequisitionsDataGridView.Columns.Item(i).Width = 250
                    PartsRequisitionsDataGridView.Columns.Item(i).Visible = True
                Case "PartsRequisitionStatus"
                    PartsRequisitionsDataGridView.Columns.Item(i).HeaderText = "Requisition Status"
                    PartsRequisitionsDataGridView.Columns.Item(i).Width = 150
                    PartsRequisitionsDataGridView.Columns.Item(i).Visible = True
            End Select
            If PartsRequisitionsDataGridView.Columns.Item(i).Visible = True Then
                'WIDTH OF DATAGRIDVIEW INSIDE A GROUPBOX AUTOMATICALLY ADJUST TO GroupBox.Width - 4
                PartsRequisitionsGroupBox.Width = PartsRequisitionsGroupBox.Width + PartsRequisitionsDataGridView.Columns.Item(i).Width
            End If
        Next
    End Sub
    Private Sub PartsRequisitionsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles PartsRequisitionsDataGridView.RowEnter
        If e.RowIndex < 0 Then Exit Sub
        If PartsRequisitionsRecordCount = 0 Then Exit Sub

        CurrentPartsRequisitionsRow = e.RowIndex
        CurrentPartsRequisitionID = PartsRequisitionsDataGridView.Item("PartsRequisitionID_AutoNumber", CurrentPartsRequisitionsRow).Value
        CurrentVehicleID = PartsRequisitionsDataGridView.Item("VehicleID_LongInteger", CurrentPartsRequisitionsRow).Value
        If Not IsEmpty(PartsRequisitionsDataGridView.Item("PartsRequisitionType_Byte", CurrentPartsRequisitionsRow).Value) Then
            If NotNull(PartsRequisitionsDataGridView.Item("PartsRequisitionType_Byte", CurrentPartsRequisitionsRow).Value) = 3 Then
                CreatePurchaseOrderToolStripMenuItem.Visible = False
            Else
                CreatePurchaseOrderToolStripMenuItem.Visible = True
            End If
        Else
            CreatePurchaseOrderToolStripMenuItem.Visible = True
        End If
        CurrentPartsRequisitionStatus = NotNull(PartsRequisitionsDataGridView.Item("PartsRequisitionType_Byte", CurrentPartsRequisitionsRow).Value)

        PartsRequisitionsItemsSelectionFilter = " WHERE PartsRequisitionID_LongInteger = " & CurrentPartsRequisitionID.ToString

        FillPartsRequisitionsItemsDataGridView()

    End Sub
    Private Sub ReturnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnToolStripMenuItem.Click
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub

    Private Sub FillPartsRequisitionsItemsDataGridView()

        Dim xxMasterCodeBookID_LongInteger = "  "
        Dim xxVehicleDescription = "  "
        Dim xxRequestedProductDesc = "  "
        Dim xxRequestedUnit = "  "
        Dim xxRequestedBrand = " "
        Dim PartsRequisitionsItemStatus = " "
        If PartsRequisitionsDataGridView.Item("PartsRequisitionType_Byte", CurrentPartsRequisitionsRow).Value = 1 Then ' 1- WorkOrder 2-Store
            xxVehicleDescription = " VehicleDescriptionWorkOrder.VehicleDescription, "
        Else
            xxVehicleDescription = " VehicleDescriptionStoreSupplies.VehicleDescription, "
        End If

        PartsRequisitionsItemsFieldsToSelect =
" 

SELECT MasterCodeBookTableWorkOrder.SystemDesc_ShortText100Fld,
MasterCodeBookTableStoreSupplies.SystemDesc_ShortText100Fld,
ProductsPartsTableWorkOrder.ManufacturerPartNo_ShortText30Fld,
ProductsPartsTableWorkOrder.ManufacturerDescription_ShortText250,
PartsRequisitionsItemsTable.RequisitionQuantity_Double,
ProductsPartsTableWorkOrder.Unit_ShortText3,
BrandsTable.BrandName_ShortText20,
PurchaseOrdersTable.PurchaseOrderID_AutoNumber,
PurchaseOrdersTable.PurchaseOrderRevision_Integer,
PurchaseOrdersTable.PurchaseOrderDate_ShortDate,
PartsRequisitionsItemsTable.PartsRequisitionsItemID_AutoNumber,
PartsRequisitionsItemsTable.PartsRequisitionID_LongInteger,
PartsRequisitionsItemsTable.ProductPartID_LongInteger,
VehicleDescriptionStoreSupplies.VehicleDescription,
" & PartsRequisitionsItemStatus & "
VehicleDescriptionWorkOrder.VehicleDescription
FROM ((((((((((((PurchaseOrdersItemsTable RIGHT JOIN PartsRequisitionsItemsTable ON PurchaseOrdersItemsTable.PartsRequisitionsItemID_LongInteger = PartsRequisitionsItemsTable.PartsRequisitionsItemID_AutoNumber) LEFT JOIN PurchaseOrdersTable ON PurchaseOrdersItemsTable.PurchaseOrderID_LongInteger = PurchaseOrdersTable.PurchaseOrderID_AutoNumber) LEFT JOIN ProductsPartsTable AS ProductsPartsTableWorkOrder ON PartsRequisitionsItemsTable.ProductPartID_LongInteger = ProductsPartsTableWorkOrder.ProductsPartID_Autonumber) LEFT JOIN BrandsTable ON ProductsPartsTableWorkOrder.BrandID_LongInteger = BrandsTable.BrandID_Autonumber) LEFT JOIN WorkOrderPartsRequisitionsItemsTable ON PartsRequisitionsItemsTable.[OrderPartsRequisitionsItemID_LongInteger] = WorkOrderPartsRequisitionsItemsTable.WorkOrderPartsRequisitionsItemID_AutoNumber) LEFT JOIN WorkOrderPartsTable ON WorkOrderPartsRequisitionsItemsTable.WorkOrderPartID_LongInteger = WorkOrderPartsTable.WorkOrderPartID_AutoNumber) LEFT JOIN StoreSuppliesRequisitionsItemsTable ON PartsRequisitionsItemsTable.OrderPartsRequisitionsItemID_LongInteger = StoreSuppliesRequisitionsItemsTable.StoreSuppliesRequisitionsItemID_AutoNumber) LEFT JOIN MasterCodeBookTable AS MasterCodeBookTableWorkOrder ON WorkOrderPartsTable.MasterCodeBookID_LongInteger = MasterCodeBookTableWorkOrder.MasterCodeBookID_Autonumber) LEFT JOIN MasterCodeBookTable AS MasterCodeBookTableStoreSupplies ON StoreSuppliesRequisitionsItemsTable.MasterCodeBookID_LongInteger = MasterCodeBookTableStoreSupplies.MasterCodeBookID_Autonumber) LEFT JOIN VehicleDescription AS VehicleDescriptionStoreSupplies ON StoreSuppliesRequisitionsItemsTable.VehicleID_LongInteger = VehicleDescriptionStoreSupplies.VehicleID_AutoNumber) LEFT JOIN WorkOrdersTable ON WorkOrderPartsTable.WorkOrderID_LongInteger = WorkOrdersTable.WorkOrderID_AutoNumber) LEFT JOIN ServicedVehiclesTable ON WorkOrdersTable.ServicedVehicleID_LongInteger = ServicedVehiclesTable.ServicedVehicleID_AutoNumber) LEFT JOIN VehicleDescription AS VehicleDescriptionWorkOrder ON ServicedVehiclesTable.VehicleID_LongInteger = VehicleDescriptionWorkOrder.VehicleID_AutoNumber
"
        PartsRequisitionsItemsTableLinks =
""
        MySelection = PartsRequisitionsItemsFieldsToSelect & PartsRequisitionsItemsTableLinks & PartsRequisitionsItemsSelectionFilter '& PartsRequisitionsItemsSelectionOrder
        JustExecuteMySelection()

        PartsRequisitionsItemsRecordCount = RecordCount
        PartsRequisitionsItemsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        Dim NoOfHeaderLines = 3, RecordsToDisplay = 28
        SetGroupBoxHeight(NoOfHeaderLines, RecordsToDisplay, PartsRequisitionsItemsRecordCount, PartsRequisitionsItemsGroupBox, PartsRequisitionsItemsDataGridView)

        If Not PartsRequisitionsItemsDataGridViewAlreadyFormated Then
            FormatPartsRequisitionsItemsDataGridView()
        End If
    End Sub
    Private Sub FormatPartsRequisitionsItemsDataGridView()
        PartsRequisitionsItemsDataGridViewAlreadyFormated = True
        PartsRequisitionsItemsGroupBox.Width = 0
        For i = 0 To PartsRequisitionsItemsDataGridView.Columns.GetColumnCount(0) - 1

            PartsRequisitionsItemsDataGridView.Columns.Item(i).Visible = False

            Select Case PartsRequisitionsItemsDataGridView.Columns.Item(i).Name
                Case "PartNumber_ShortText25"   'for future redesign
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Part Number"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Width = 135
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "SystemDesc_ShortText100Fld"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Part"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Width = 350
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "WorkOrderPartsTable.Unit_ShortText3"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Specs"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Width = 70
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "ManufacturerPartNo_ShortText30Fld"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Manuf. Part No"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Width = 135
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "ManufacturerDescription_ShortText250"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Manuf. Description"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Width = 350
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                    PartsRequisitionsItemsDataGridView.Columns(i).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                Case "RequisitionQuantity_Double"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Req Qty"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Width = 50
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "ProductsPartsTable.Unit_ShortText3"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Req Unit"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Width = 50
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "BrandName_ShortText20"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Req Brand"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Width = 150
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "ProductDescription_ShortText250"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Product Description"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Width = 400
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "PurchaseOrderID_AutoNumber"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "P.O. #"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Width = 70
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "PurchaseOrderRevision_Integer"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Rev"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Width = 50
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "PurchaseOrderDate_ShortDate"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "PO Date"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Width = 90
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "PartsRequisitionsItemStatus"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Status"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Width = 120
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Visible = True

            End Select
            If PartsRequisitionsItemsDataGridView.Columns.Item(i).Visible = True Then
                'WIDTH OF DATAGRIDVIEW INSIDE A GROUPBOX AUTOMATICALLY ADJUST TO GroupBox.Width - 4
                PartsRequisitionsItemsGroupBox.Width = PartsRequisitionsItemsGroupBox.Width + PartsRequisitionsItemsDataGridView.Columns.Item(i).Width
            End If
        Next
        If PartsRequisitionsItemsGroupBox.Width > Me.Width Then
            'WIDTH OF DATAGRIDVIEW INSIDE A GROUPBOX AUTOMATICALLY ADJUST TO GroupBox.Width - 4
            PartsRequisitionsItemsGroupBox.Width = Me.Width - 2
        End If
        PartsRequisitionsItemsGroupBox.Left = (Me.Width - PartsRequisitionsItemsGroupBox.Width) / 2
        PartsRequisitionsItemsGroupBox.Left = 2
    End Sub
    Private Sub PartsRequisitionsItemsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles PartsRequisitionsItemsDataGridView.RowEnter
        PartsRequisitionsItemsGroupBox.Visible = True

        CurrentPartsRequisitionItemID = -1
        If e.RowIndex < 0 Then
            Exit Sub
        End If
        If PartsRequisitionsItemsRecordCount = 0 Then
            Exit Sub
        End If
        CurrentPartsRequisitionsItemsDataGridViewRow = e.RowIndex
        CurrentPartsRequisitionItemID = PartsRequisitionsItemsDataGridView.Item("PartsRequisitionsItemID_AutoNumber", CurrentPartsRequisitionsItemsDataGridViewRow).Value
        CurrentPartsRequisitionsID = PartsRequisitionsItemsDataGridView.Item("PartsRequisitionID_LongInteger", CurrentPartsRequisitionsItemsDataGridViewRow).Value
        CurrentProductsPartID = PartsRequisitionsItemsDataGridView.Item("ProductPartID_LongInteger", CurrentPartsRequisitionsItemsDataGridViewRow).Value
        If PartsRequisitionsItemsDataGridView.Item("PartsRequisitionsItemStatus", CurrentPartsRequisitionsItemsDataGridViewRow).Value = "Ordered" Then
            PartsRequisitionsItemsDataGridView.Rows(CurrentPartsRequisitionsItemsDataGridViewRow).DefaultCellStyle.ForeColor = Color.Red
        End If
        If Not PartsRequisitionsItemsDataGridView.Item("PartsRequisitionsItemStatus", CurrentPartsRequisitionsItemsDataGridViewRow).Value = "Outstanding" Then
            RequisitionDetailsToolStripMenuItem.Visible = True
        Else
            RequisitionDetailsToolStripMenuItem.Visible = False
        End If
    End Sub


    Private Sub PurchaseOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreatePurchaseOrderToolStripMenuItem.Click
        ShowPurchaseOrdersForm()
    End Sub
    Private Function AllItemsAreValid(PassedataGridView As DataGridView, PassedFieldToTest As String, PassedNoOfRecords As Integer,
                                      PassedFieldToDisplay As String, PassedMsg As String)
        Dim AllHaveValidStatus = True
        For i = 0 To PassedNoOfRecords - 1
            If IsEmpty(PassedataGridView.Item(PassedFieldToTest, i).Value) Then
                MsgBox(PassedataGridView.Item(PassedFieldToDisplay, i).Value & PassedMsg)
                AllHaveValidStatus = False
            End If
        Next
        If AllHaveValidStatus Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub ShowPurchaseOrdersForm()
        If MsgBox("Have you selected all items to purchase >", vbYesNo) = vbNo Then
            Exit Sub
        End If
        Dim xxSelectedRecordsCount = 0
        For i = 0 To PartsRequisitionsItemsRecordCount - 1
            If PartsRequisitionsItemsDataGridView.Rows(i).Selected Then xxSelectedRecordsCount = xxSelectedRecordsCount + 1
        Next
        If PartsRequisitionsItemsRecordCount > xxSelectedRecordsCount Then
            If MsgBox("All Items are not selected, PROCEED to Purchase only this item(s) ? ", vbYesNoCancel) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        If Not AllItemsAreValid(PartsRequisitionsItemsDataGridView, "RequisitionQuantity_Double", xxSelectedRecordsCount,
                                      "ProductsPartsTable.ManufacturerPartNo_ShortText30Fld", "has no quantity") Then
        End If
        'HERE CREATE A HEADER REQUISITION

        Dim FieldsToUpdate = " PurchaseOrderDate_ShortDate, " &
                              " Purchaser_LongInteger, " &
                              " PurchaseOrderStatus_Byte "

        Dim FieldsData = DateString & "," &
                         CurrentUserID.ToString & "," &
                         0.ToString

        CurrentPurchaseOrderID = InsertNewRecord("PurchaseOrdersTable", FieldsToUpdate, FieldsData)
        'HERE START PROCESSING EACH ITEM
        Dim TableToUpdate As String
        Dim SetCommand As String
        Dim RecordFilter As String
        For i = 0 To PartsRequisitionsItemsRecordCount - 1
            If Not PartsRequisitionsItemsDataGridView.Rows(i).Selected Then Continue For ' ONLY THE SELECTED
            ' CHECK IF SAME ITEM IS ALREADY IN THE PurchaseOrdersItemsTable 
            Dim xxPartsRequisitionItemID = PartsRequisitionsItemsDataGridView.Item("PartsRequisitionsItemID_AutoNumber", i).Value
            Dim xxProductPartID = PartsRequisitionsItemsDataGridView.Item("ProductPartID_LongInteger", i).Value
            Dim xxRequisitionQuantity_Double = PartsRequisitionsItemsDataGridView.Item("RequisitionQuantity_Double", i).Value
            MySelection = " select top 1 * FROM PurchaseOrdersItemsTable Where PartsRequisitionsItemID_LongInteger = " & xxPartsRequisitionItemID.ToString
            JustExecuteMySelection()
            If RecordCount > 0 Then
                MsgBox("an ITEM ALREADY EXIST IN THE PURCHASE ORDER ITEMS")
            End If

            FieldsToUpdate = " PurchaseOrderID_LongInteger, " &
                                    " ProductPartID_LongInteger, " &
                                    " POQty_Integer, " &
                                    " PartsRequisitionsItemID_LongInteger, " &
                                    " PartsRequisitionItemStatusID_LongInteger "

            FieldsData = CurrentPurchaseOrderID.ToString & "," &
                                xxProductPartID & "," &
                                xxRequisitionQuantity_Double.ToString & "," &
                                xxPartsRequisitionItemID.ToString & "," &
                                0.ToString

            Dim CurrentPurchaseOrderItemID = InsertNewRecord("PurchaseOrdersItemsTable", FieldsToUpdate, FieldsData)
            If CurrentPurchaseOrderItemID > 0 Then
                '	0- Outstanding 1- Partially Ordered 2 - Reordered 3 - Completly Ordered 
                ' HERE PartsRequisitionsTablE PartsRequisitionsItemsTable ARE TO BE UPDATED 
                MsgBox(" GetStatusIdFor( this has been modified updated chack if okay")
                SetCommand = " SET PartsRequisitionItemStatusID_LongInteger = " & GetStatusIdFor("PartsRequisitionsItemsTable", "Completely Ordered")
                RecordFilter = " WHERE PartsRequisitionsItemID_AutoNumber = " & xxPartsRequisitionItemID.ToString
                UpdateTable("PartsRequisitionsItemsTable", SetCommand, RecordFilter)
            Else
                MsgBox("a record was unsuccesfully created in the Puechase Order Items")
            End If
        Next


        ' HERE PartsRequisitionsTable IS TO BE UPDATED 
        '	0- Outstanding 1- Partially Ordered 2 - Reordered 3 - Completly Ordered 
        Dim CompletelyOrderedStatusSequence = GetStatusIdFor("StatusSequence_LongInteger", "Completely Ordered")
        For i = 0 To PartsRequisitionsItemsRecordCount - 1
            If PartsRequisitionsItemsDataGridView.Item("StatusSequence_LongInteger", i).Value <> CompletelyOrderedStatusSequence Then Exit For
        Next

        '	0- Outstanding 1- Partially Ordered 2 - Reordered 3 - Completly Ordered 
        TableToUpdate = "PartsRequisitionsTable"
        SetCommand = " SET PartsRequisitionItemStatusID_LongInteger = " & GetStatusIdFor("StatusSequence_LongInteger", "Completely Ordered").ToString
        MsgBox("Check the following")
        RecordFilter = " WHERE PartsRequisitionID_AutoNumber = " &
            Val(PartsRequisitionsItemsDataGridView.Item("PartsRequisitionID_LongInteger", 0).Value).ToString &
            PartsRequisitionsItemsDataGridView.Item("StatusSequence_LongInteger", 0).Value <> CompletelyOrderedStatusSequence
        UpdateTable(TableToUpdate, SetCommand, RecordFilter)
        MsgBox("PO Number : " & CurrentPurchaseOrderID.ToString & " has been created..")

        FillPartsRequisitionsDataGridView()
    End Sub

    Private Sub SelectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectToolStripMenuItem.Click

    End Sub

    Private Sub RequisitionDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RequisitionDetailsToolStripMenuItem.Click
        If RequisitionDetailsToolStripMenuItem.Text = "Requisition Details" Then
            RequisitionItemDetailsGroupBox.Visible = True
            RequisitionDetailsToolStripMenuItem.Text = "Requisition Details OFF"
        Else
            RequisitionItemDetailsGroupBox.Visible = False
            RequisitionDetailsToolStripMenuItem.Text = "Requisition Details"
        End If
    End Sub

    Private Sub OutstandingRequisitionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OutstandingRequisitionsToolStripMenuItem.Click
        SetRequisitionsSelectionFilter(0, Me, "OUTSTANDING REQUISITIONS")
    End Sub

    Private Sub PartiallyOrderedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PartiallyOrderedToolStripMenuItem.Click
        SetRequisitionsSelectionFilter(1, Me, "PARTIALLY ORDERED REQUISITIONS")
    End Sub

    Private Sub ReorderedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReorderedToolStripMenuItem.Click
        SetRequisitionsSelectionFilter(2, Me, "RE-ORDERED REQUISITIONS")
    End Sub

    Private Sub CompletlyOrderedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompletlyOrderedToolStripMenuItem.Click
        SetRequisitionsSelectionFilter(3, Me, "COMPLETELY ORDERED REQUISITIONS")
    End Sub

    Private Sub AllRequisitionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllRequisitionsToolStripMenuItem.Click
        SetRequisitionsSelectionFilter(10, Me, "ALL REQUISITIONS")
    End Sub

    Private Sub PrintRequissitionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintRequisitionToolStripMenuItem.Click

    End Sub
    Private Sub SetRequisitionsSelectionFilter(PassedStatusCode As Integer, PassedForm As Form, FormHeaderText As String)
        PartsRequisitionsSelectionFilter = SetupTableSelectionFilter(PassedStatusCode, PassedForm, FormHeaderText, "")
        PartsRequisitionsSelectionFilter = Replace(PartsRequisitionsSelectionFilter, "Status_Byte", "Status_Integer")
        FillPartsRequisitionsDataGridView()
    End Sub

    Private Sub AddPurchaseOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddPurchaseOrderToolStripMenuItem.Click
        If MsgBox("Shall we proceed creating a new Requisition ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        Dim FieldsToUpdate = " RequisitionDate_ShortDate, " &
                                " RequestedByID_LongInteger, " &
                                " VehicleID_LongInteger, " &
                                " PartsRequisitionType_Byte "

        Dim FieldsData = Chr(34) & DateString & Chr(34) & ", " &
                                CurrentUserID.ToString & ", " &
                                -1.ToString & ", " &
                                0.ToString

        CurrentPartsRequisitionsID = InsertNewRecord("PartsRequisitionsTable", FieldsToUpdate, FieldsData)
        FillPartsRequisitionsDataGridView()
        RequisitionItemDetailsGroupBox.Visible = True
    End Sub

    Private Sub EditPurchaseOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditPurchaseOrderToolStripMenuItem.Click

    End Sub

    Private Sub DeletePurchaseOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeletePurchaseOrderToolStripMenuItem.Click

    End Sub

    Private Sub SavePurchaseOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SavePurchaseOrderToolStripMenuItem.Click

    End Sub

    Private Sub DeleteRequisitionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteRequisitionToolStripMenuItem.Click
        If MsgBox("Remove this Requisition?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            MySelection = " DELETE FROM PartsRequisitionsTable WHERE PartsRequisitionID_AutoNumber =  " & CurrentPartsRequisitionID
            JustExecuteMySelection()
            FillPartsRequisitionsDataGridView()
        End If

    End Sub

    Private Sub EXITSAVEChangesButton_Click(sender As Object, e As EventArgs) Handles EXITSAVEChangesButton.Click
        SaveChanges()
    End Sub
    Private Sub SaveChanges()
        ' check otherformat
    End Sub

    Private Sub POItemProductDescTextBox_TextChanged(sender As Object, e As EventArgs) Handles RequisitionItemProductDescTextBox.Click
        If RequisitionItemProductDescTextBox.Text <> "" Then
            If MsgBox("Do you intend to replace the Product?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        ProductsPartsForm.PartNoToolStripTextBox.Text = ""
        '        ProductsPartsForm.SearchDescriptionToolStripTextBox.Text = PurchaseOrdersItemsDataGridView.Item("SystemDesc_ShortText100Fld", CurrentPurchaseOrdersItemsDataGridViewRow).Value
        '        Tunnel1 = PurchaseOrdersItemsDataGridView.Item("MasterCodeBookID_Autonumber", CurrentPurchaseOrdersItemsDataGridViewRow).Value
        '       ProductsPartsForm.VehicleFilterToolStripTextBox.Text = CurrentVehicleString
        ShowCalledForm(Me, ProductsPartsForm)

    End Sub
End Class