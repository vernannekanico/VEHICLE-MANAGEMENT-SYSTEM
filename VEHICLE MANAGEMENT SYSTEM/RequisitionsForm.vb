Public Class RequisitionsForm

    '   Private CurrentWorkOrderRequestedPartsDataGridViewRow As Integer = -1
    '    Private WorkOrderRequestedPartsDataGridViewAlreadyFormated = False
    Private ProductsPartsDataGridViewAlreadyFormated = False
    '   Private CurrentQuantity = -1


    Private CurrentIssuedProductPartID = -1
    Private Requisitionstatus = ""

    Private RequisitionsTable As New MyDbControls
    Private RequisitionsFieldsToSelect = ""
    Private RequisitionsTableLinks = ""
    Private RequisitionsSelectionFilter = ""
    Private RequisitionsSelectionOrder = ""
    Private CurrentRequisitionsRow As Integer = -1
    Private RequisitionsRecordCount As Integer = -1
    Private CurrentRequisitionstatus As String
    Private RequisitionsDataGridViewAlreadyFormatted = False
    Private CurrentPartsRequisitionID = -1
    Private RequisitionstatusSelection As Integer = 1
    Private PartsRequisitionType = -1

    Private RequisitionsItemsFieldsToSelect = ""
    Private RequisitionsItemsSelectionFilter = ""
    Private RequisitionsItemsSelectionOrder = ""
    Private RequisitionsItemsRecordCount As Integer = -1
    Private RequisitionsItemsDataGridViewAlreadyFormated = False
    Private CurrentRequisitionItemID = -1
    Private CurrentRequisitionsID = -1
    Private CurrentRequisitionsItemsDataGridViewRow As Integer = -1

    Private CurrentProductsPartID = -1
    Private CurrentQtyToIssue = -1
    Private CurrentQtyToOrder = -1
    Private CreatingRequisitionItems = False
    Private SavedCallingForm As Form
    Private CurrentPurchaseOrderID = -1
    Private CurrentUserFilter = ""

    Private Sub RequisitionsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        SavedCallingForm = CallingForm
        If Val(Tunnel1) > 0 Then
            CurrentPurchaseOrderID = Tunnel1
            WhatToDoToolStripMenuItem.Text = "Attach selected items to Purchase Order " & Tunnel1.ToString
        Else
            WhatToDoToolStripMenuItem.Text = "Create Purchase Order for Selected Item(s) "
        End If
        RequisitionsItemsDataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        CurrentUserFilter = "Purchaser_LongInteger = " & CurrentPersonelID.ToString
        SetRequisitionsSelectionFilter("Outstanding Requisition", 2, Me, "OUTSTANDING REQUISITIONS")
    End Sub

    Private Sub RequisitionsForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
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
    Public Sub FillRequisitionsDataGridView()
        RequisitionsSelectionOrder = " ORDER BY RequisitionID_AutoNumber DESC "
        Dim xxWorkOrder = " IIf(RequisitionsTable.Requisitionstatus_Integer = 1, " & Chr(34) & "Work Order" & Chr(34) & ","
        Dim xxStoreOrder = " IIf(RequisitionsTable.Requisitionstatus_Integer = 2, " & Chr(34) & "Store Order" & Chr(34) & ","
        PartsRequisitionType = xxWorkOrder & xxStoreOrder & " )) AS PartsRequisitionType,  "

        Dim xxOutstanding = " IIf(RequisitionsTable.Requisitionstatus_Integer = 0, " & Chr(34) & "Outstanding" & Chr(34) & ","
        Dim xxPartiallyOrdered = " IIf(RequisitionsTable.Requisitionstatus_Integer = 1, " & Chr(34) & "Partially Ordered" & Chr(34) & ","
        Dim xxReordered = " IIf(RequisitionsTable.Requisitionstatus_Integer = 2, " & Chr(34) & "Re-Ordered" & Chr(34) & ","
        Dim xxCompletelyOrdered = " IIf(RequisitionsTable.Requisitionstatus_Integer = 3, " & Chr(34) & "Completely Ordered" & Chr(34) & ","

        Requisitionstatus = xxOutstanding & xxPartiallyOrdered & xxCompletelyOrdered & xxReordered & Chr(34) & Chr(34) &
                                " )))) AS Requisitionstatus "

        RequisitionsFieldsToSelect =
" 
SELECT RequisitionsTable.RequisitionID_AutoNumber,
RequisitionsTable.RequisitionRevision_Integer,
RequisitionsTable.RequisitionDate_ShortDate,
RequisitionsTable.RequestedByID_LongInteger,
RequisitionsTable.Requisitionstatus_Integer,
RequisitionsTable.RequisitionType_Byte,
RequisitionsTable.VehicleID_LongInteger,
RequisitionsTable.Purchaser_LongInteger,
VehicleTypeTable.VehicleType_ShortText20,
VehicleTrimTable.VehicleTrimName_ShortText25,
VehicleModelsTable.VehicleModel_ShortText20,
VehiclesTable.YearManufactured_ShortText4,
VehiclesTable.Engine_ShortText20,
StatusesTable.StatusSequence_LongInteger,
StatusesTable.StatusText_ShortText25,
(VehiclesTable.YearManufactured_ShortText4 & Space(1) & Trim(VehicleTypeTable.VehicleType_ShortText20) & Space(1) & Trim(VehicleModelsTable.VehicleModel_ShortText20) & Space(1) & Trim(VehicleTrimTable.VehicleTrimName_ShortText25)) AS VehicleDescription, PersonnelTable.LastName_ShortText30, PersonnelTable.FirstName_ShortText30,
" & PartsRequisitionType &
Requisitionstatus &
 "
FROM ((RequisitionsTable LEFT JOIN PersonnelTable ON RequisitionsTable.RequestedByID_LongInteger = PersonnelTable.PersonnelID_AutoNumber) LEFT JOIN ((((VehiclesTable LEFT JOIN VehicleModelsRelationsTable ON VehiclesTable.VehicleModelsRelationID_LongInteger = VehicleModelsRelationsTable.VehicleModelsRelationID_Autonumber) LEFT JOIN VehicleTypeTable ON VehicleModelsRelationsTable.VehicleTypeID_LongInteger = VehicleTypeTable.VehicleTypeID_AutoNumber) LEFT JOIN VehicleTrimTable ON VehicleModelsRelationsTable.VehicleTrimID_LongInteger = VehicleTrimTable.VehicleTrimID_Autonumber) LEFT JOIN VehicleModelsTable ON VehicleModelsRelationsTable.VehicleModelID_LongInteger = VehicleModelsTable.VehicleModelID_Autonumber) ON RequisitionsTable.VehicleID_LongInteger = VehiclesTable.VehicleID_AutoNumber) LEFT JOIN StatusesTable ON RequisitionsTable.Requisitionstatus_Integer = StatusesTable.StatusID_Autonumber"

        MySelection = RequisitionsFieldsToSelect & RequisitionsSelectionFilter & RequisitionsSelectionOrder
        JustExecuteMySelection()

        RequisitionsRecordCount = RecordCount
        If RequisitionsRecordCount = 0 Then
            RequisitionsItemsGroupBox.Visible = False
        Else
            RequisitionsItemsGroupBox.Visible = True
        End If
        RequisitionsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        Dim RecordsToDisplay = 10
        SetGroupBoxHeight(RecordsToDisplay, RequisitionsRecordCount, RequisitionsGroupBox, RequisitionsDataGridView)

        If RequisitionsItemsDataGridViewAlreadyFormated Then

            FormatRequisitionsDataGridView()
            SetFormWidthAndGroupBoxLeft(Me,
                                        RequisitionsMenuStrip,
                                        RequisitionsGroupBox,
                                        RequisitionsItemsGroupBox,
                                        RequisitionsGroupBox,
                                        RequisitionsGroupBox
                                        )
        End If
    End Sub
    Private Sub FormatRequisitionsDataGridView()
        RequisitionsDataGridViewAlreadyFormatted = True
        RequisitionsGroupBox.Width = 0
        For i = 0 To RequisitionsDataGridView.Columns.GetColumnCount(0) - 1

            RequisitionsDataGridView.Columns.Item(i).Visible = False
            Select Case RequisitionsDataGridView.Columns.Item(i).Name
                Case "RequisitionID_AutoNumber"
                    RequisitionsDataGridView.Columns.Item(i).HeaderText = "Requistion No."
                    RequisitionsDataGridView.Columns.Item(i).Width = 90
                    RequisitionsDataGridView.Columns.Item(i).Visible = True
                Case "RequisitionRevision_Integer"
                    RequisitionsDataGridView.Columns.Item(i).HeaderText = "Rev."
                    RequisitionsDataGridView.Columns.Item(i).Width = 50
                    RequisitionsDataGridView.Columns.Item(i).Visible = True
                Case "RequisitionDate_ShortDate"
                    RequisitionsDataGridView.Columns.Item(i).HeaderText = "Date"
                    RequisitionsDataGridView.Columns.Item(i).Width = 100
                    RequisitionsDataGridView.Columns.Item(i).Visible = True
                Case "VehicleDescription"
                    RequisitionsDataGridView.Columns.Item(i).HeaderText = "For Vehicle"
                    RequisitionsDataGridView.Columns.Item(i).Width = 300
                    RequisitionsDataGridView.Columns.Item(i).Visible = True
                Case "RequestedBy"
                    RequisitionsDataGridView.Columns.Item(i).HeaderText = "Requested By"
                    RequisitionsDataGridView.Columns.Item(i).Width = 250
                    RequisitionsDataGridView.Columns.Item(i).Visible = True
                Case "StatusText_ShortText25"
                    RequisitionsDataGridView.Columns.Item(i).HeaderText = "RequisitStatus"
                    RequisitionsDataGridView.Columns.Item(i).Width = 150
                    RequisitionsDataGridView.Columns.Item(i).Visible = True
            End Select
            If RequisitionsDataGridView.Columns.Item(i).Visible = True Then
                'WIDTH OF DATAGRIDVIEW INSIDE A GROUPBOX AUTOMATICALLY ADJUST TO GroupBox.Width - 4
                RequisitionsGroupBox.Width = RequisitionsGroupBox.Width + RequisitionsDataGridView.Columns.Item(i).Width
            End If
        Next
    End Sub
    Private Sub RequisitionsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles RequisitionsDataGridView.RowEnter
        If e.RowIndex < 0 Then Exit Sub
        If RequisitionsRecordCount = 0 Then Exit Sub

        CurrentRequisitionsRow = e.RowIndex
        CurrentPartsRequisitionID = RequisitionsDataGridView.Item("RequisitionID_AutoNumber", CurrentRequisitionsRow).Value
        CurrentVehicleID = RequisitionsDataGridView.Item("VehicleID_LongInteger", CurrentRequisitionsRow).Value
        CurrentRequisitionstatus = NotNull(RequisitionsDataGridView.Item("RequisitionType_Byte", CurrentRequisitionsRow).Value)

        RequisitionsItemsSelectionFilter = " WHERE RequisitionsItemsTable.RequisitionID_LongInteger = " & CurrentPartsRequisitionID.ToString
        FillRequisitionsItemsDataGridView()
        WhatToDoToolStripMenuItem.Visible = False
    End Sub
    Private Sub ReturnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnToolStripMenuItem.Click
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub

    Private Sub FillRequisitionsItemsDataGridView()

        Dim xxMasterCodeBookID_LongInteger = "  "
        Dim xxVehicleDescription = "  "

        Dim xxRequestedUnit = "  "
        Dim xxRequestedBrand = " "
        Dim RequisitionsItemstatus = " "
        If RequisitionsDataGridView.Item("RequisitionType_Byte", CurrentRequisitionsRow).Value = 1 Then ' 1- WorkOrder 2-Store
            xxVehicleDescription = " VehicleDescriptionWorkOrder.VehicleDescription, "
        Else
            xxVehicleDescription = " VehicleDescriptionStoreSupplies.VehicleDescription, "
        End If

        RequisitionsItemsFieldsToSelect =
" 
SELECT 
MasterCodeBookTableWorkOrder.SystemDesc_ShortText100Fld,
MasterCodeBookTableStoreSupplies.SystemDesc_ShortText100Fld,
ProductsPartsTable.ManufacturerPartNo_ShortText30Fld,
ProductsPartsTable.ManufacturerDescription_ShortText250,
RequisitionsItemsTable.RequisitionQuantity_Double,
ProductsPartsTable.Unit_ShortText3,
ProductPartsPackingsTable.QuantityPerPack_Double, 
ProductPartsPackingsTable.UnitOfTheQuantity_ShortText3,
BrandsTable.BrandName_ShortText20,
PurchaseOrdersTable.PurchaseOrderID_AutoNumber,
PurchaseOrdersTable.PurchaseOrderRevision_Integer,
PurchaseOrdersTable.PurchaseOrderDate_ShortDate,
RequisitionsItemsTable.RequisitionsItemID_AutoNumber,
RequisitionsItemsTable.RequisitionID_LongInteger,
RequisitionsItemsTable.ProductPartID_LongInteger,
VehicleDescriptionStoreSupplies.VehicleDescription,
VehicleDescriptionWorkOrder.VehicleDescription,
StatusesTable.StatusText_ShortText25
FROM ProductPartsPackingsTable RIGHT JOIN ((((((((((((((PurchaseOrdersItemsTable RIGHT JOIN RequisitionsItemsTable ON PurchaseOrdersItemsTable.RequisitionsItemID_LongInteger = RequisitionsItemsTable.RequisitionsItemID_AutoNumber) LEFT JOIN PurchaseOrdersTable ON PurchaseOrdersItemsTable.PurchaseOrderID_LongInteger = PurchaseOrdersTable.PurchaseOrderID_AutoNumber) LEFT JOIN ProductsPartsTable ON RequisitionsItemsTable.ProductPartID_LongInteger = ProductsPartsTable.ProductsPartID_Autonumber) LEFT JOIN BrandsTable ON ProductsPartsTable.BrandID_LongInteger = BrandsTable.BrandID_Autonumber) LEFT JOIN WorkOrderRequestedPartsTable ON RequisitionsItemsTable.[WorkOrderPartsRequisitionsItemID_LongInteger] = WorkOrderRequestedPartsTable.WorkOrderRequestedPartID_AutoNumber) LEFT JOIN WorkOrderPartsTable ON WorkOrderRequestedPartsTable.WorkOrderPartID_LongInteger = WorkOrderPartsTable.WorkOrderPartID_AutoNumber) LEFT JOIN StoreSuppliesRequisitionsItemsTable ON RequisitionsItemsTable.WorkOrderPartsRequisitionsItemID_LongInteger = StoreSuppliesRequisitionsItemsTable.StoreSuppliesRequisitionsItemID_AutoNumber) LEFT JOIN MasterCodeBookTable AS MasterCodeBookTableWorkOrder ON WorkOrderPartsTable.MasterCodeBookID_LongInteger = MasterCodeBookTableWorkOrder.MasterCodeBookID_Autonumber) LEFT JOIN MasterCodeBookTable AS MasterCodeBookTableStoreSupplies ON StoreSuppliesRequisitionsItemsTable.MasterCodeBookID_LongInteger = MasterCodeBookTableStoreSupplies.MasterCodeBookID_Autonumber) LEFT JOIN VehicleDescription AS VehicleDescriptionStoreSupplies ON StoreSuppliesRequisitionsItemsTable.VehicleID_LongInteger = VehicleDescriptionStoreSupplies.VehicleID_AutoNumber) LEFT JOIN WorkOrdersTable ON WorkOrderPartsTable.WorkOrderID_LongInteger = WorkOrdersTable.WorkOrderID_AutoNumber) LEFT JOIN ServicedVehiclesTable ON WorkOrdersTable.ServicedVehicleID_LongInteger = ServicedVehiclesTable.ServicedVehicleID_AutoNumber) LEFT JOIN VehicleDescription AS VehicleDescriptionWorkOrder ON ServicedVehiclesTable.VehicleID_LongInteger = VehicleDescriptionWorkOrder.VehicleID_AutoNumber) LEFT JOIN StatusesTable ON RequisitionsItemsTable.RequisitionItemStatusID_LongInteger = StatusesTable.StatusID_Autonumber) ON ProductPartsPackingsTable.ProductPartID_LongInteger = ProductsPartsTable.ProductsPartID_Autonumber
"
        MySelection = RequisitionsItemsFieldsToSelect & RequisitionsItemsSelectionFilter & RequisitionsItemsSelectionOrder
        JustExecuteMySelection()

        RequisitionsItemsRecordCount = RecordCount
        RequisitionsItemsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        Dim RecordsToDisplay = 28
        SetGroupBoxHeight(RecordsToDisplay, RequisitionsItemsRecordCount, RequisitionsItemsGroupBox, RequisitionsItemsDataGridView)

        If Not RequisitionsItemsDataGridViewAlreadyFormated Then
            FormatRequisitionsItemsDataGridView()
        End If
    End Sub
    Private Sub FormatRequisitionsItemsDataGridView()
        RequisitionsItemsDataGridViewAlreadyFormated = True
        RequisitionsItemsGroupBox.Width = 0
        For i = 0 To RequisitionsItemsDataGridView.Columns.GetColumnCount(0) - 1

            RequisitionsItemsDataGridView.Columns.Item(i).Visible = False

            Select Case RequisitionsItemsDataGridView.Columns.Item(i).Name
                Case "MasterCodeBookTableWorkOrder.SystemDesc_ShortText100Fld"
                    RequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Part"
                    RequisitionsItemsDataGridView.Columns.Item(i).Width = 350
                    RequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "ManufacturerPartNo_ShortText30Fld"
                    RequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Manuf. Part No"
                    RequisitionsItemsDataGridView.Columns.Item(i).Width = 135
                    RequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "ManufacturerDescription_ShortText250"
                    RequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Manuf. Description"
                    RequisitionsItemsDataGridView.Columns.Item(i).Width = 350
                    RequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                    RequisitionsItemsDataGridView.Columns(i).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                Case "RequisitionQuantity_Double"
                    RequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Req Qty"
                    RequisitionsItemsDataGridView.Columns.Item(i).Width = 50
                    RequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "Unit_ShortText3"
                    RequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Req Unit"
                    RequisitionsItemsDataGridView.Columns.Item(i).Width = 50
                    RequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "QuantityPerPack_Double"
                    RequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "packing"
                    RequisitionsItemsDataGridView.Columns.Item(i).Width = 50
                    RequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "UnitOfTheQuantity_ShortText3"
                    RequisitionsItemsDataGridView.Columns.Item(i).HeaderText = ""
                    RequisitionsItemsDataGridView.Columns.Item(i).Width = 50
                    RequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "BrandName_ShortText20"
                    RequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Req Brand"
                    RequisitionsItemsDataGridView.Columns.Item(i).Width = 150
                    RequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "ProductDescription_ShortText250"
                    RequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Product Description"
                    RequisitionsItemsDataGridView.Columns.Item(i).Width = 400
                    RequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "PurchaseOrderID_AutoNumber"
                    RequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "P.O. #"
                    RequisitionsItemsDataGridView.Columns.Item(i).Width = 70
                    RequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "PurchaseOrderRevision_Integer"
                    RequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Rev"
                    RequisitionsItemsDataGridView.Columns.Item(i).Width = 50
                    RequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "PurchaseOrderDate_ShortDate"
                    RequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "PO Date"
                    RequisitionsItemsDataGridView.Columns.Item(i).Width = 90
                    RequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "StatusText_ShortText25"
                    RequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Status"
                    RequisitionsItemsDataGridView.Columns.Item(i).Width = 120
                    RequisitionsItemsDataGridView.Columns.Item(i).Visible = True

            End Select
            If RequisitionsItemsDataGridView.Columns.Item(i).Visible = True Then
                'WIDTH OF DATAGRIDVIEW INSIDE A GROUPBOX AUTOMATICALLY ADJUST TO GroupBox.Width - 4
                RequisitionsItemsGroupBox.Width = RequisitionsItemsGroupBox.Width + RequisitionsItemsDataGridView.Columns.Item(i).Width
            End If
        Next
    End Sub
    Private Sub RequisitionsItemsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles RequisitionsItemsDataGridView.RowEnter
        RequisitionsItemsGroupBox.Visible = True

        CurrentRequisitionItemID = -1
        If e.RowIndex < 0 Then
            Exit Sub
        End If
        If RequisitionsItemsRecordCount = 0 Then
            Exit Sub
        End If
        CurrentRequisitionsItemsDataGridViewRow = e.RowIndex
        CurrentRequisitionItemID = RequisitionsItemsDataGridView.Item("RequisitionsItemID_AutoNumber", CurrentRequisitionsItemsDataGridViewRow).Value
        CurrentRequisitionsID = RequisitionsItemsDataGridView.Item("RequisitionID_LongInteger", CurrentRequisitionsItemsDataGridViewRow).Value
        CurrentProductsPartID = RequisitionsItemsDataGridView.Item("ProductPartID_LongInteger", CurrentRequisitionsItemsDataGridViewRow).Value
        Dim CurrentRequisitionsItemstatus = RequisitionsItemsDataGridView.Item("StatusText_ShortText25", CurrentRequisitionsItemsDataGridViewRow).Value
        RequisitionDetailsToolStripMenuItem.Visible = False
        Select Case CurrentRequisitionsItemstatus
            Case "Outstanding Requisition"
                RequisitionDetailsToolStripMenuItem.Visible = True
            Case "Completely Ordered"
                RequisitionsItemsDataGridView.Rows(CurrentRequisitionsItemsDataGridViewRow).DefaultCellStyle.ForeColor = Color.Red
        End Select

    End Sub
    Private Sub PurchaseOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WhatToDoToolStripMenuItem.Click
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
        Dim xxSelectedRecordsCount = 0
        For i = 0 To RequisitionsItemsRecordCount - 1
            If RequisitionsItemsDataGridView.Rows(i).Selected Then xxSelectedRecordsCount = xxSelectedRecordsCount + 1
        Next
        If xxSelectedRecordsCount = 0 Then
            MsgBox("Select first item(s) you want to attach to a purchase order")
            Exit Sub
        End If
        If xxSelectedRecordsCount <> RequisitionsItemsRecordCount Then
            If MsgBox("Not all Items were selected, continue? ", vbYesNo) = vbNo Then Exit Sub
        Else
            If MsgBox("Continue create the  Purchase Order ? ", vbYesNo) = vbNo Then Exit Sub
        End If
        If Not AllItemsAreValid(RequisitionsItemsDataGridView, "RequisitionQuantity_Double", xxSelectedRecordsCount,
                                      "ProductsPartsTable.ManufacturerPartNo_ShortText30Fld", "has no quantity") Then
        End If
        'HERE CREATE A HEADER Purchase Order if there is no purchase order number passed
        Dim FieldsToUpdate = ""
        Dim FieldsData = ""
        If CurrentPurchaseOrderID < 1 Then
            FieldsToUpdate = " PurchaseOrderDate_ShortDate, " &
                              " Purchaser_LongInteger, " &
                              " PurchaseOrderStatusID_LongInteger "

            FieldsData = DateString & "," &
                         CurrentPersonelID.ToString & "," &
                         GetStatusIdFor("PurchaseOrdersTable", "Draft")

            CurrentPurchaseOrderID = InsertNewRecord("PurchaseOrdersTable", FieldsToUpdate, FieldsData)
        End If

        'START PROCESSING EACH ITEM
        Dim TableToUpdate As String = ""
        Dim SetCommand As String = ""
        Dim RecordFilter As String = ""
        For i = 0 To RequisitionsItemsRecordCount - 1
            If Not RequisitionsItemsDataGridView.Rows(i).Selected Then Continue For ' ONLY THE SELECTED
            ' CHECK IF SAME ITEM IS ALREADY IN THE PurchaseOrdersItemsTable 
            Dim xxRequisitionItemID = RequisitionsItemsDataGridView.Item("RequisitionsItemID_AutoNumber", i).Value
            Dim xxProductPartID = RequisitionsItemsDataGridView.Item("ProductPartID_LongInteger", i).Value
            Dim xxRequisitionQuantity_Double = RequisitionsItemsDataGridView.Item("RequisitionQuantity_Double", i).Value
            MySelection = " select top 1 * FROM PurchaseOrdersItemsTable Where RequisitionsItemID_LongInteger = " & xxRequisitionItemID.ToString
            JustExecuteMySelection()
            If RecordCount = 0 Then

                FieldsToUpdate = " PurchaseOrderID_LongInteger, " &
                                    " ProductPartID_LongInteger, " &
                                    " POQty_Integer, " &
                                    " RequisitionsItemID_LongInteger, " &
                                    " PurchaseOrdersItemStatusID_LongInteger "

                FieldsData = CurrentPurchaseOrderID.ToString & "," &
                                    xxProductPartID & "," &
                                    xxRequisitionQuantity_Double.ToString & "," &
                                    xxRequisitionItemID.ToString & "," &
                                    GetStatusIdFor("PurchaseOrdersItemsTable", "Draft").ToString

                Dim CurrentPurchaseOrderItemID = InsertNewRecord("PurchaseOrdersItemsTable", FieldsToUpdate, FieldsData)

                RecordFilter = " WHERE ProductsPartID_Autonumber =  " & CurrentProductsPartID.ToString
                SetCommand = " SET  Selected = True "
                UpdateTable("ProductsPartsTable", SetCommand, RecordFilter)
            Else
                MsgBox("Item " & (i + 1).ToString & "  ALREADY EXIST IN THE PURCHASE ORDER ITEMS")
            End If
            SetCommand = " SET RequisitionItemStatusID_LongInteger = " & GetStatusIdFor("RequisitionsItemsTable", "Draft PO").ToString
            xxRequisitionItemID = RequisitionsItemsDataGridView.Item("RequisitionsItemID_AutoNumber", i).Value

            RecordFilter = " WHERE RequisitionsItemID_AutoNumber = " & xxRequisitionItemID
            UpdateTable("RequisitionsItemsTable", SetCommand, RecordFilter)
        Next

        MsgBox("PO Number : " & CurrentPurchaseOrderID.ToString & " has been created..")


        SetCommand = " SET Requisitionstatus_Integer = " & GetStatusIdFor("RequisitionsTable", "Draft PO").ToString
        RecordFilter = " WHERE RequisitionID_AutoNumber = " & CurrentPartsRequisitionID
        UpdateTable("RequisitionsTable", SetCommand, RecordFilter)

        FillRequisitionsDataGridView()
        ShowCalledForm(Me, PurchaseOrdersForm)
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
        SetRequisitionsSelectionFilter("Partially Ordered", 1, Me, "OUTSTANDING REQUISITIONS")
    End Sub

    Private Sub PartiallyOrderedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PartiallyOrderedToolStripMenuItem.Click
        SetRequisitionsSelectionFilter("Partially Ordered", 2, Me, "PARTIALLY ORDERED REQUISITIONS")
    End Sub

    Private Sub ReorderedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReorderedToolStripMenuItem.Click
        SetRequisitionsSelectionFilter("Re-ordered", 2, Me, "RE-ORDERED REQUISITIONS")
    End Sub

    Private Sub CompletlyOrderedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompletlyOrderedToolStripMenuItem.Click
        SetRequisitionsSelectionFilter(GetStatusIdFor("Completely Ordered"), 2, Me, "COMPLETELY ORDERED REQUISITIONS")
    End Sub

    Private Sub AllRequisitionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllRequisitionsToolStripMenuItem.Click
        SetRequisitionsSelectionFilter(GetStatusIdFor("Completely Ordered"), 3, Me, "ALL REQUISITIONS")
    End Sub

    Private Sub PrintRequissitionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintRequisitionToolStripMenuItem.Click

    End Sub
    Private Sub SetRequisitionsSelectionFilter(PassedStatusText As String, PassedStatusSequenceCondition As Integer, PassedForm As Form, FormHeaderText As String)
        Dim PassedStatusSequence = GetStatusIdFor("RequisitionsTable", PassedStatusText, 1)
        RequisitionsSelectionFilter = SetupTableSelectionFilter(PassedStatusSequence, PassedStatusSequenceCondition, PassedForm, FormHeaderText, CurrentUserFilter)
        FillRequisitionsDataGridView()
    End Sub

    Private Sub POItemProductDescTextBox_TextChanged(sender As Object, e As EventArgs) Handles RequisitionItemProductDescTextBox.Click
        If RequisitionItemProductDescTextBox.Text <> "" Then
            If MsgBox("Do you intend to replace the Product?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        ProductsPartsForm.PartNoSearchTextBox.Text = ""
        '       ProductsPartsForm.PartDescriptionSearchTextBox.Text = PurchaseOrdersItemsDataGridView.Item("SystemDesc_ShortText100Fld", CurrentPurchaseOrdersItemsDataGridViewRow).Value
        '        Tunnel2 = PurchaseOrdersItemsDataGridView.Item("MasterCodeBookID_Autonumber", CurrentPurchaseOrdersItemsDataGridViewRow).Value
        '       ProductsPartsForm.VehicleFilterToolStripTextBox.Text = CurrentVehicleString
        ShowCalledForm(Me, ProductsPartsForm)

    End Sub

End Class