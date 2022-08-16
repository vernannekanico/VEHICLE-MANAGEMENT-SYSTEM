﻿Public Class WorkOrderPartsRequisitionsForm
    Private WorkOrderPartsRequisitionsFieldsToSelect = ""
    Private WorkOrderRequestedPartsHeadersTableLinks = ""
    Private WorkOrderPartsRequisitionsSelectionFilter = ""
    Private WorkOrderPartsRequisitionsSelectionOrder = ""
    Private WorkOrderPartsRequisitionsRecordCount As Integer = -1
    Private WorkOrderPartsRequisitionsDataGridViewAlreadyFormated = False
    Private CurrentWorkOrderPartsRequisitionsDataGridViewRow As Integer = -1
    Private CurrentWorkOrderRequestedPartsHeaderID As Integer = -1
    Private CurrentWorkOrderPartsRequisitionsStatusSelection = -1
    Private WorkOrderPartsRequisitionStatus = ""
    Private WorkOrderRequestedPartsFieldsToSelect = ""
    Private WorkOrderRequestedPartsTableLinks = ""
    Private WorkOrderRequestedPartsSelectionFilter = ""
    Private WorkOrderRequestedPartsSelectionOrder = ""
    Private WorkOrderRequestedPartsRecordCount As Integer = -1
    Private WorkOrderRequestedPartsDataGridViewAlreadyFormated = False
    Private CurrentWorkOrderRequestedPartsDataGridViewRow As Integer = -1
    Private CurrentWorkOrderRequestedPartID As Integer = -1


    Private PartsRequisitionsItemsFieldsToSelect = ""
    Private PartsRequisitionsItemsTableLinks = ""
    Private PartsRequisitionsItemsSelectionFilter = ""
    Private PartsRequisitionsItemsSelectionOrder = ""
    Private PartsRequisitionsItemsRecordCount As Integer = -1
    Private PartsRequisitionsItemsDataGridViewAlreadyFormated = False
    Private CurrentPartsRequisitionsItemsID As Integer = -1
    Private CurrentPartsRequisitionsItemsDataGridViewRow As Integer = -1
    Private CurrentPartsRequisitionsItemID = -1
    Private ReceivedByID = -1

    Private CurrentPartsRequisitionID = -1
    Private CurrentWorkOrderPartID As Integer = -1
    Private CurrentProductsPartID = -1
    Private CurrentQtyToIssue = -1
    Private CurrentQtyToOrder = -1
    Private CurrentMasterCodeBookId = -1
    Private SavedCallingForm As Form
    Private Sub WorkOrderPartsRequisitionsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        SavedCallingForm = CallingForm
        Me.Text = "Parts for Issuance"
        CurrentWorkOrderPartsRequisitionsStatusSelection = 0
        SetWorkOrderPartsRequisitionsSelectionFilter(GetStatusIdFor("WorkOrderRequestedPartsHeadersTable", "Warehouse Outstanding", 1), 1, Me, "Warehouse Outstanding")
        SubmitRequisitionsForPurchaseToolStripMenuItem.Visible = True
        QuantityGroupBox.Top = (Me.Height - QuantityGroupBox.Height) / 2
        QuantityGroupBox.Left = (Me.Width - QuantityGroupBox.Width) / 2
    End Sub

    Private Sub WorkOrderPartsRequisitionsForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        If Me.Enabled = False Then Exit Sub
        CallingForm = SavedCallingForm

        ' GET RETURNED DATA HERE

        Select Case Tunnel1
            Case "Tunnel2IsWorkOrderPartsRequisitionCode"
                CurrentWorkOrderRequestedPartsHeaderID = Tunnel2
            Case = "Tunnel2IsProductPartID"
                CurrentProductsPartID = Tunnel2
                QuantityGroupBox.Visible = True
                If CurrentProductsPartID > 0 Then
                    Dim xxFilter = " WHERE WorkOrderRequestedPartID_AutoNumber = " & CurrentWorkOrderRequestedPartID.ToString

                    MySelection = " UPDATE WorkOrderRequestedPartsTable " &
                              " SET ProductPartID_LongInteger = " & CurrentProductsPartID & xxFilter
                    JustExecuteMySelection()
                    FillWorkOrderRequestedPartsDataGridView()
                End If
            Case "Tunnel2IsPersonnelID"
                ReceivedByID = Tunnel2
        End Select

    End Sub
    Private Sub ReturnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnToolStripMenuItem.Click
        If QuantityGroupBox.Visible = True Then
            QuantityGroupBox.Visible = False
            Exit Sub
        End If
        DoCommonHouseKeeping(Me, SavedCallingForm)

    End Sub

    Private Sub FillWorkOrderPartsRequisitionsDataGridView()


        WorkOrderPartsRequisitionsFieldsToSelect = "
Select
WorkOrdersTable.WorkOrderNumber_ShortText12,
WorkOrderRequestedPartsHeadersTable.WorkOrderPartsRequisitionNumber_ShortText12,
WorkOrderRequestedPartsHeadersTable.WorkOrderPartsRequisitionRevision_Integer,
WorkOrderRequestedPartsHeadersTable.WorkOrderPartsRequisitionDate_ShortDate,
WorkOrderRequestedPartsHeadersTable.RequestedByID_LongInteger,
(VehiclesTable.YearManufactured_ShortText4 & Space(1) & 
Trim(VehicleTypeTable.VehicleType_ShortText20) & Space(1) & 
Trim(VehicleModelsTable.VehicleModel_ShortText20) & Space(1) & 
Trim(VehicleTrimTable.VehicleTrimName_ShortText25) & Space(1) & 
Trim(VehiclesTable.Engine_ShortText20)) As VehicleName,
(PersonnelTable.LastName_ShortText30 & space(1) & mid(PersonnelTable.FirstName_ShortText30,1,1)) As RequestedBy,
WorkOrderRequestedPartsHeadersTable.WorkOrderID_LongInteger,
WorkOrderRequestedPartsHeadersTable.WorkOrderRequestedPartsHeaderID_AutoNumber,
StatusesTable.StatusSequence_LongInteger,
StatusesTable.StatusText_ShortText25
FROM ((((((((WorkOrderRequestedPartsHeadersTable LEFT JOIN WorkOrdersTable ON WorkOrderRequestedPartsHeadersTable.WorkOrderID_LongInteger = WorkOrdersTable.WorkOrderID_AutoNumber) LEFT JOIN ServicedVehiclesTable ON WorkOrdersTable.ServicedVehicleID_LongInteger = ServicedVehiclesTable.ServicedVehicleID_AutoNumber) LEFT JOIN VehiclesTable ON ServicedVehiclesTable.VehicleID_LongInteger = VehiclesTable.VehicleID_AutoNumber) LEFT JOIN VehicleModelsRelationsTable ON VehiclesTable.VehicleModelsRelationID_LongInteger = VehicleModelsRelationsTable.VehicleModelsRelationID_Autonumber) LEFT JOIN VehicleTypeTable ON VehicleModelsRelationsTable.VehicleTypeID_LongInteger = VehicleTypeTable.VehicleTypeID_AutoNumber) LEFT JOIN VehicleTrimTable ON VehicleModelsRelationsTable.VehicleTrimID_LongInteger = VehicleTrimTable.VehicleTrimID_Autonumber) LEFT JOIN VehicleModelsTable ON VehicleModelsRelationsTable.VehicleModelID_LongInteger = VehicleModelsTable.VehicleModelID_Autonumber) LEFT JOIN PersonnelTable ON WorkOrderRequestedPartsHeadersTable.RequestedByID_LongInteger = PersonnelTable.PersonnelID_AutoNumber) LEFT JOIN StatusesTable ON WorkOrderRequestedPartsHeadersTable.WorkOrderPartsRequisitionStatusID_Integer = StatusesTable.StatusID_Autonumber
"
        WorkOrderPartsRequisitionsSelectionOrder = " ORDER BY WorkOrderRequestedPartsHeaderID_AutoNumber DESC "

        MySelection = WorkOrderPartsRequisitionsFieldsToSelect & WorkOrderPartsRequisitionsSelectionFilter & WorkOrderPartsRequisitionsSelectionOrder

        JustExecuteMySelection()
        WorkOrderPartsRequisitionsRecordCount = RecordCount
        WorkOrderPartsRequisitionsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        Dim RecordsToDisplay = 8
        If WorkOrderPartsRequisitionsRecordCount < RecordsToDisplay Then RecordsToDisplay = WorkOrderPartsRequisitionsRecordCount
        WorkOrderPartsRequisitionsDataGridView.Height = WorkOrderPartsRequisitionsDataGridView.ColumnHeadersHeight + (DataGridViewRowHeight * (RecordsToDisplay + 1))

        If Not WorkOrderPartsRequisitionsDataGridViewAlreadyFormated Then
            FormatWorkOrderPartsRequisitionsDataGridView()
        End If

    End Sub
    Private Sub FormatWorkOrderPartsRequisitionsDataGridView()
        WorkOrderPartsRequisitionsDataGridViewAlreadyFormated = True
        WorkOrderPartsRequisitionsDataGridView.Width = 0
        For i = 0 To WorkOrderPartsRequisitionsDataGridView.Columns.GetColumnCount(0) - 1

            WorkOrderPartsRequisitionsDataGridView.Columns.Item(i).Visible = False

            Select Case WorkOrderPartsRequisitionsDataGridView.Columns.Item(i).HeaderText

                Case "VehicleName"
                    WorkOrderPartsRequisitionsDataGridView.Columns.Item(i).HeaderText = "Model"
                    WorkOrderPartsRequisitionsDataGridView.Columns.Item(i).Width = 300
                    WorkOrderPartsRequisitionsDataGridView.Columns.Item(i).Visible = True
                Case "WorkOrderNumber_ShortText12"
                    WorkOrderPartsRequisitionsDataGridView.Columns.Item(i).HeaderText = "Work Order #"
                    WorkOrderPartsRequisitionsDataGridView.Columns.Item(i).Width = 170
                    WorkOrderPartsRequisitionsDataGridView.Columns.Item(i).Visible = True
                Case "WorkOrderPartsRequisitionNumber_ShortText12"
                    WorkOrderPartsRequisitionsDataGridView.Columns.Item(i).HeaderText = "Requitition No. "
                    WorkOrderPartsRequisitionsDataGridView.Columns.Item(i).Width = 100
                    WorkOrderPartsRequisitionsDataGridView.Columns.Item(i).Visible = True
                Case "WorkOrderPartsRequisitionRevision_Integer"
                    WorkOrderPartsRequisitionsDataGridView.Columns.Item(i).HeaderText = "Rev"
                    WorkOrderPartsRequisitionsDataGridView.Columns.Item(i).Width = 30
                    WorkOrderPartsRequisitionsDataGridView.Columns.Item(i).Visible = True
                Case "WorkOrderPartsRequisitionDate_ShortDate"
                    WorkOrderPartsRequisitionsDataGridView.Columns.Item(i).HeaderText = "Date"
                    WorkOrderPartsRequisitionsDataGridView.Columns.Item(i).Width = 120
                    WorkOrderPartsRequisitionsDataGridView.Columns.Item(i).Visible = True
                Case "StatusText_ShortText25"
                    WorkOrderPartsRequisitionsDataGridView.Columns.Item(i).HeaderText = "Status"
                    WorkOrderPartsRequisitionsDataGridView.Columns.Item(i).Width = 250
                    WorkOrderPartsRequisitionsDataGridView.Columns.Item(i).Visible = True
            End Select
            If WorkOrderPartsRequisitionsDataGridView.Columns.Item(i).Visible = True Then
                WorkOrderPartsRequisitionsDataGridView.Width = WorkOrderPartsRequisitionsDataGridView.Width + WorkOrderPartsRequisitionsDataGridView.Columns.Item(i).Width
            End If
        Next
        ' NOTE" SYSTEM AUTOFITS THE GRIDVIEW FIELDS ACCORDING To THEIR WITDH

        Me.Width = VehicleManagementSystemForm.Width
        Me.Height = VehicleManagementSystemForm.Height
        Me.Location = New Point(Me.Location.X, 55)
        Me.Left = VehicleManagementSystemForm.Left

        If WorkOrderPartsRequisitionsDataGridView.Width > Me.Width Then
            WorkOrderPartsRequisitionsDataGridView.Width = Me.Width - 8
        End If

        WorkOrderPartsRequisitionsDataGridView.Left = 5
        WorkOrderPartsRequisitionsDataGridView.Top = WorkOrderPartsMenuStrip.Top + WorkOrderPartsMenuStrip.Height

        WorkOrderRequestedPartsDataGridView.Top = WorkOrderPartsRequisitionsDataGridView.Top + WorkOrderPartsRequisitionsDataGridView.Height
        WorkOrderRequestedPartsDataGridView.Left = (Me.Width - WorkOrderRequestedPartsDataGridView.Width) / 2

        RequestForPurchaseGroupBox.Top = WorkOrderRequestedPartsDataGridView.Top + WorkOrderRequestedPartsDataGridView.Height
        RequestForPurchaseGroupBox.Width = Me.Width - 6
        RequestForPurchaseGroupBox.Left = (Me.Width - RequestForPurchaseGroupBox.Width) / 2
        PartsRequisitionsItemsDataGridView.Left = 5
    End Sub
    Private Sub WorkOrderPartsRequisitionsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles WorkOrderPartsRequisitionsDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If WorkOrderPartsRequisitionsRecordCount = 0 Then Exit Sub
        CurrentWorkOrderPartsRequisitionsDataGridViewRow = e.RowIndex

        CurrentWorkOrderRequestedPartsHeaderID = WorkOrderPartsRequisitionsDataGridView.Item("WorkOrderRequestedPartsHeaderID_AutoNumber", CurrentWorkOrderPartsRequisitionsDataGridViewRow).Value
        Dim CurrentWorkOrderPartsRequisitionStatusSequence = WorkOrderPartsRequisitionsDataGridView.Item("StatusSequence_LongInteger", CurrentWorkOrderPartsRequisitionsDataGridViewRow).Value
        WorkOrderPartsRequisitionStatus = WorkOrderPartsRequisitionsDataGridView.Item("StatusText_ShortText25", CurrentWorkOrderPartsRequisitionsDataGridViewRow).Value
        CurrentWorkOrderID = WorkOrderPartsRequisitionsDataGridView.Item("WorkOrderID_LongInteger", CurrentWorkOrderPartsRequisitionsDataGridViewRow).Value
        VehicleModelTextBox.Text = WorkOrderPartsRequisitionsDataGridView.Item("VehicleName", CurrentWorkOrderPartsRequisitionsDataGridViewRow).Value
        EditPartDetailsToolStripMenuItem.Visible = False
        DeleteProductToolStripMenuItem.Visible = False
        SubmitRequisitionsForPurchaseToolStripMenuItem.Visible = False

        If CurrentWorkOrderPartsRequisitionStatusSequence <= GetStatusIdFor("WorkOrderRequestedPartsHeadersTable", "Draft Requisition", 1) Then
            CheckStockAvailabilityToolStripMenuItem.Visible = True
        Else
            CheckStockAvailabilityToolStripMenuItem.Visible = False
        End If

        Select Case WorkOrderPartsRequisitionStatus
            Case "Draft Requisition"
                SubmitRequisitionsForPurchaseToolStripMenuItem.Text = "Submit Requisitions for Purchase"
                SubmitRequisitionsForPurchaseToolStripMenuItem.Visible = False
            Case "Warehouse Outstanding"
        End Select


        '' SETUP CURRENT VEHICLE INFORMATIONS
        SetVehicleInformations()    'REQUIRES CurrentWorkOrderID

        WorkOrderRequestedPartsSelectionFilter = " WHERE WorkOrderRequestedPartsHeaderID_AutoNumber = " & CurrentWorkOrderRequestedPartsHeaderID.ToString
        FillWorkOrderRequestedPartsDataGridView()
        PartsRequisitionsItemsSelectionFilter = " WHERE WorkOrderConcernsTable.WorkOrderID_LongInteger = " & CurrentWorkOrderID
        FillPartsRequisitionsItemsDataGridView()

    End Sub

    Private Sub ReleasePartsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReleasePartsToolStripMenuItem.Click
        If MsgBox("Sure all parts requested are ready for release?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        PrintReleaseNotesToolStripMenuItem.Visible = True
        ReleasePartsToolStripMenuItem.Visible = False
        EditPartDetailsToolStripMenuItem.Visible = False
        DeleteProductToolStripMenuItem.Visible = False
        ViewToolStripMenuItem.Visible = False
        WorkOrderPartsRequisitionsDataGridView.Enabled = False
        WorkOrderRequestedPartsDataGridView.Enabled = False
        WorkOrderRequestedPartsSelectionFilter = " WHERE WorkOrderPartsRequisitionsID_LongInteger = " & CurrentWorkOrderRequestedPartsHeaderID &
                                                            " and QuantityInStock_Double > 0"
        FillWorkOrderRequestedPartsDataGridView()
    End Sub


    Private Sub FillWorkOrderRequestedPartsDataGridView()
        WorkOrderRequestedPartsDataGridView.Visible = True

        WorkOrderRequestedPartsFieldsToSelect =
"
SELECT 
MasterCodeBookTable.SystemDesc_ShortText100Fld,
ProductsPartsTable.ManufacturerPartNo_ShortText30Fld, 
ProductsPartsTable.ManufacturerDescription_ShortText250, 
StocksTable.QuantityInStock_Double, 
WorkOrderRequestedPartsTable.RequestedQuantity_Double, 
PartsRequisitionsItemsTable.RequisitionQuantity_Double, 
BrandsTable.BrandName_ShortText20, 
StocksTable.Location_ShortText10, 
StocksTable.StockID_Autonumber,
ProductsPartsTable.ProductDescription_ShortText250, 
WorkOrderRequestedPartsTable.WorkOrderPartID_LongInteger, 
WorkOrderRequestedPartsTable.ProductPartID_LongInteger, 
PartsRequisitionsItemsTable.PartsRequisitionsItemID_AutoNumber, 
PartsRequisitionsItemsTable.PartsRequisitionItemStatusID_LongInteger, 
PartsRequisitionsItemsTable.PartsRequisitionItemStatusID_LongInteger, 
WorkOrderRequestedPartsTable.WorkOrderRequestedPartID_AutoNumber, 
WorkOrderRequestedPartsTable.WorkOrderPartsRequisitionsID_LongInteger, 
MasterCodeBookTable.MasterCodeBookID_Autonumber, 
WorkOrderPartsTable.WorkOrderPartID_AutoNumber, 
StatusesTable.StatusText_ShortText25
FROM ((((PartsRequisitionsItemsTable RIGHT JOIN WorkOrderRequestedPartsTable ON PartsRequisitionsItemsTable.WorkOrderRequestedPartID_LongInteger = WorkOrderRequestedPartsTable.WorkOrderRequestedPartID_AutoNumber) LEFT JOIN WorkOrderRequestedPartsHeadersTable ON WorkOrderRequestedPartsTable.WorkOrderPartsRequisitionsID_LongInteger = WorkOrderRequestedPartsHeadersTable.WorkOrderRequestedPartsHeaderID_AutoNumber) LEFT JOIN (WorkOrderPartsTable LEFT JOIN MasterCodeBookTable ON WorkOrderPartsTable.MasterCodeBookID_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) ON WorkOrderRequestedPartsTable.WorkOrderPartID_LongInteger = WorkOrderPartsTable.WorkOrderPartID_AutoNumber) LEFT JOIN (StocksTable RIGHT JOIN (ProductsPartsTable LEFT JOIN BrandsTable ON ProductsPartsTable.BrandID_LongInteger = BrandsTable.BrandID_Autonumber) ON StocksTable.ProductPartID_LongInteger = ProductsPartsTable.ProductsPartID_Autonumber) ON WorkOrderRequestedPartsTable.ProductPartID_LongInteger = ProductsPartsTable.ProductsPartID_Autonumber) LEFT JOIN StatusesTable ON WorkOrderRequestedPartsTable.WorkOrderRequestedPartStatus_Integer = StatusesTable.StatusID_Autonumber
"
        MySelection = WorkOrderRequestedPartsFieldsToSelect & WorkOrderRequestedPartsSelectionFilter & WorkOrderRequestedPartsSelectionOrder
        JustExecuteMySelection()

        WorkOrderRequestedPartsRecordCount = RecordCount
        WorkOrderRequestedPartsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        Dim xxQuantityInStock = 0
        For i = 0 To WorkOrderRequestedPartsRecordCount - 1
            If IsNotEmpty(WorkOrderRequestedPartsDataGridView.Item("QuantityInStock_Double", i).Value) Then
                xxQuantityInStock = xxQuantityInStock + 1
            End If
        Next

        If xxQuantityInStock = 0 Then
            ReleasePartsToolStripMenuItem.Visible = False
        Else
            If Not PrintReleaseNotesToolStripMenuItem.Visible Then
                ReleasePartsToolStripMenuItem.Visible = True
            End If
        End If


        If Not WorkOrderRequestedPartsDataGridViewAlreadyFormated Then
            FormatWorkOrderRequestedPartsDataGridView()
        End If

        Dim NoOfHeaderLines = 1
        Dim RecordsDisplyed = WorkOrderRequestedPartsRecordCount
        If WorkOrderRequestedPartsRecordCount > 12 Then
            RecordsDisplyed = 12
        Else
            RecordsDisplyed = WorkOrderRequestedPartsRecordCount
        End If


        WorkOrderRequestedPartsDataGridView.Height = (WorkOrderRequestedPartsDataGridView.ColumnHeadersHeight * NoOfHeaderLines) + (DataGridViewRowHeight * (RecordsDisplyed + 1))

    End Sub
    Private Sub FormatWorkOrderRequestedPartsDataGridView()
        WorkOrderRequestedPartsDataGridViewAlreadyFormated = True

        WorkOrderRequestedPartsDataGridView.Width = 0

        For i = 0 To WorkOrderRequestedPartsDataGridView.Columns.GetColumnCount(0) - 1

            WorkOrderRequestedPartsDataGridView.Columns.Item(i).Visible = False

            Select Case WorkOrderRequestedPartsDataGridView.Columns.Item(i).Name
                Case "SystemDesc_ShortText100Fld"
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).HeaderText = "Part"
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).Width = 300
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).Visible = True
                Case "ManufacturerPartNo_ShortText30Fld"
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).HeaderText = "Manuf Part #"
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).Width = 150
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).Visible = True
                Case "ManufacturerDescription_ShortText250"
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).HeaderText = "Manuf Desc."
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).Width = 300
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).Visible = True
                Case "Quantity_Integer"
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).HeaderText = "Request"
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).Width = 70
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).Visible = True
                Case "QuantityInStock_Double"
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).HeaderText = "Available"
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).Width = 70
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).Visible = True
                Case "RequestedQuantity_Double"
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).HeaderText = "to Issue"
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).Width = 70
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).Visible = True
                Case "RequisitionQuantity_Double"
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).HeaderText = "to order"
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).Width = 70
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).Visible = True
                Case "BrandName_ShortText20"
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).HeaderText = "Brand"
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).Width = 200
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).Visible = True
                Case "WorkOrderPartsTable.Unit_ShortText3"
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).HeaderText = "WO UNIT"
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).Width = 70
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).Visible = True
                Case "ProductDescription_ShortText250"
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).HeaderText = "Orig excel Desc."
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).Width = 400
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).Visible = True
                Case "Location_ShortText10"
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).HeaderText = "Location"
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).Width = 80
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).Visible = True
                Case "StatusText_ShortText25"
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).HeaderText = "Requisition Status"
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).Width = 100
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).Visible = True
            End Select
            If WorkOrderRequestedPartsDataGridView.Columns.Item(i).Visible = True Then
                WorkOrderRequestedPartsDataGridView.Width = WorkOrderRequestedPartsDataGridView.Width + WorkOrderRequestedPartsDataGridView.Columns.Item(i).Width
            End If
        Next
        If WorkOrderRequestedPartsDataGridView.Width > Me.Width Then
            WorkOrderRequestedPartsDataGridView.Width = Me.Width - 20
        End If
        WorkOrderRequestedPartsDataGridView.Left = (Me.Width - WorkOrderRequestedPartsDataGridView.Width) / 2

    End Sub

    Private Sub WorkOrderRequestedPartsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles WorkOrderRequestedPartsDataGridView.RowEnter
        CurrentWorkOrderPartID = -1
        If e.RowIndex < 0 Then Exit Sub
        If WorkOrderRequestedPartsRecordCount = 0 Then Exit Sub
        CurrentWorkOrderRequestedPartsDataGridViewRow = e.RowIndex
        CurrentPartsRequisitionsItemID = WorkOrderRequestedPartsDataGridView.Item("PartsRequisitionsItemID_AutoNumber", CurrentWorkOrderRequestedPartsDataGridViewRow).Value
        Dim CurrentPartStatus = WorkOrderRequestedPartsDataGridView.Item("StatusText_ShortText25", CurrentWorkOrderRequestedPartsDataGridViewRow).Value

        CurrentWorkOrderRequestedPartID = WorkOrderRequestedPartsDataGridView.Item("WorkOrderRequestedPartID_AutoNumber", CurrentWorkOrderRequestedPartsDataGridViewRow).Value
        CurrentWorkOrderPartID = WorkOrderRequestedPartsDataGridView.Item("WorkOrderPartID_Autonumber", CurrentWorkOrderRequestedPartsDataGridViewRow).Value
        CurrentMasterCodeBookId = WorkOrderRequestedPartsDataGridView.Item("MasterCodeBookID_Autonumber", CurrentWorkOrderRequestedPartsDataGridViewRow).Value
        RequestedQuantityTextBox.Text = WorkOrderRequestedPartsDataGridView.Item("RequestedQuantity_Double", CurrentWorkOrderRequestedPartsDataGridViewRow).Value

        If Not (PrintReleaseNotesToolStripMenuItem.Visible Or PartsReleaseInfoGroupBox.Visible) Then
            DeleteProductToolStripMenuItem.Visible = True
            EditPartDetailsToolStripMenuItem.Visible = True
        End If

        ' DSPLAY PART SPECIFICATIONS IF AVAILABLE
        Select Case CurrentPartStatus
            Case "Warehouse Outstanding"

        End Select
        CurrentWorkOrderPartID = WorkOrderRequestedPartsDataGridView.Item("WorkOrderPartID_AutoNumber", CurrentWorkOrderRequestedPartsDataGridViewRow).Value
        If IsNotEmpty(WorkOrderRequestedPartsDataGridView.Item("RequestedQuantity_Double", CurrentWorkOrderRequestedPartsDataGridViewRow).Value) Then
            ToIssueQuantityTextBox.Text = WorkOrderRequestedPartsDataGridView.Item("RequestedQuantity_Double", CurrentWorkOrderRequestedPartsDataGridViewRow).Value
        End If
        If IsNotEmpty(WorkOrderRequestedPartsDataGridView.Item("ProductPartID_LongInteger", CurrentWorkOrderRequestedPartsDataGridViewRow).Value) Then
            CurrentProductsPartID = WorkOrderRequestedPartsDataGridView.Item("ProductPartID_LongInteger", CurrentWorkOrderRequestedPartsDataGridViewRow).Value
            CheckStockAvailabilityToolStripMenuItem.Visible = False
        Else
            CurrentProductsPartID = -1
            CheckStockAvailabilityToolStripMenuItem.Visible = True
        End If
        If IsNotEmpty(WorkOrderRequestedPartsDataGridView.Item("RequisitionQuantity_Double", CurrentWorkOrderRequestedPartsDataGridViewRow).Value) Then
            ToOrderQuantityTextBox.Text = WorkOrderRequestedPartsDataGridView.Item("RequisitionQuantity_Double", CurrentWorkOrderRequestedPartsDataGridViewRow).Value
        Else
            ToOrderQuantityTextBox.Text = "0"
        End If
        CurrentQtyToIssue = Val(ToIssueQuantityTextBox.Text)
        CurrentQtyToOrder = Val(ToOrderQuantityTextBox.Text)
    End Sub
    Private Sub FillPartsRequisitionsItemsDataGridView()
        PartsRequisitionsItemsFieldsToSelect = " 
SELECT 
MasterCodeBookTable.MasterCodeBookID_Autonumber, 
ProductsPartsTable.ManufacturerPartNo_ShortText30Fld, 
ProductsPartsTable.ManufacturerDescription_ShortText250, 
WorkOrderPartsTable.Quantity_Integer, 
WorkOrderPartsTable.Unit_ShortText3, 
StocksTable.QuantityInStock_Double, 
WorkOrderRequestedPartsTable.RequestedQuantity_Double, 
PartsRequisitionsItemsTable.PartsRequisitionsItemID_AutoNumber, 
PartsRequisitionsItemsTable.RequisitionQuantity_Double, 
PartsRequisitionsItemsTable.PartsRequisitionID_LongInteger, 
PartsRequisitionsItemsTable.ProductPartID_LongInteger, 
PartsRequisitionsItemsTable.WorkOrderRequestedPartID_LongInteger, 
PartsRequisitionsItemsTable.PartsRequisitionItemStatusID_LongInteger, 
MasterCodeBookTable.SystemDesc_ShortText100Fld, 
ProductsPartsTable.ProductsPartID_Autonumber, 
BrandsTable.BrandName_ShortText20, 
ProductsPartsTable.ProductDescription_ShortText250, 
WorkOrderPartsTable.WorkOrderPartID_AutoNumber, 
WorkOrderRequestedPartsTable.WorkOrderPartID_LongInteger, 
WorkOrderRequestedPartsTable.WorkOrderRequestedPartID_AutoNumber, 
StatusesTable.StatusText_ShortText25, 
WorkOrderConcernsTable.WorkOrderID_LongInteger
FROM ((((PartsRequisitionsItemsTable LEFT JOIN ((((WorkOrderRequestedPartsTable LEFT JOIN ProductsPartsTable ON WorkOrderRequestedPartsTable.ProductPartID_LongInteger = ProductsPartsTable.ProductsPartID_Autonumber) LEFT JOIN StocksTable ON WorkOrderRequestedPartsTable.ProductPartID_LongInteger = StocksTable.ProductPartID_LongInteger) LEFT JOIN BrandsTable ON ProductsPartsTable.BrandID_LongInteger = BrandsTable.BrandID_Autonumber) LEFT JOIN ((WorkOrderPartsTable LEFT JOIN MasterCodeBookTable ON WorkOrderPartsTable.MasterCodeBookID_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) LEFT JOIN WorkOrderRequestedPartsHeadersTable ON WorkOrderPartsTable.WorkOrderRequestedPartsHeaderID_LongInteger = WorkOrderRequestedPartsHeadersTable.WorkOrderRequestedPartsHeaderID_AutoNumber) ON WorkOrderRequestedPartsTable.WorkOrderPartID_LongInteger = WorkOrderPartsTable.WorkOrderPartID_AutoNumber) ON PartsRequisitionsItemsTable.WorkOrderRequestedPartID_LongInteger = WorkOrderRequestedPartsTable.WorkOrderRequestedPartID_AutoNumber) LEFT JOIN PartsRequisitionsTable ON PartsRequisitionsItemsTable.PartsRequisitionID_LongInteger = PartsRequisitionsTable.PartsRequisitionID_AutoNumber) LEFT JOIN StatusesTable ON PartsRequisitionsItemsTable.PartsRequisitionItemStatusID_LongInteger = StatusesTable.StatusID_Autonumber) LEFT JOIN WorkOrderConcernJobsTable ON WorkOrderPartsTable.WorkOrderConcernJobID_LongInteger = WorkOrderConcernJobsTable.WorkOrderConcernJobID_AutoNumber) LEFT JOIN WorkOrderConcernsTable ON WorkOrderConcernJobsTable.WorkOrderConcernID_LongInteger = WorkOrderConcernsTable.WorkOrderConcernID_AutoNumber
"
        MySelection = PartsRequisitionsItemsFieldsToSelect & PartsRequisitionsItemsSelectionFilter & PartsRequisitionsItemsSelectionOrder

        JustExecuteMySelection()

        PartsRequisitionsItemsRecordCount = RecordCount
        PartsRequisitionsItemsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If PartsRequisitionsItemsRecordCount > 0 Then
            RequestForPurchaseGroupBox.Visible = True
            SubmitRequisitionsForPurchaseToolStripMenuItem.Visible = True
        Else
            RequestForPurchaseGroupBox.Visible = False
            SubmitRequisitionsForPurchaseToolStripMenuItem.Visible = False
            CurrentPartsRequisitionsItemID = -1
        End If
        If Not PartsRequisitionsItemsDataGridViewAlreadyFormated Then
            PartsRequisitionsItemsDataGridViewAlreadyFormated = True
            FormatRequisitionsItemsDataGridView()
        End If
        Dim RecordsToDisplay = 10
        If PartsRequisitionsItemsRecordCount < RecordsToDisplay Then RecordsToDisplay = PartsRequisitionsItemsRecordCount
        PartsRequisitionsItemsDataGridView.Height = PartsRequisitionsItemsDataGridView.ColumnHeadersHeight + (DataGridViewRowHeight * (RecordsToDisplay + 1))
    End Sub
    Private Sub FormatRequisitionsItemsDataGridView()
        PartsRequisitionsItemsDataGridView.Width = 0

        For i = 0 To PartsRequisitionsItemsDataGridView.Columns.GetColumnCount(0) - 1

            PartsRequisitionsItemsDataGridView.Columns.Item(i).Visible = False

            Select Case PartsRequisitionsItemsDataGridView.Columns.Item(i).Name
                Case "SystemDesc_ShortText100Fld"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "SystemDesc"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Width = 300
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "Quantity_Integer"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Rqd QTY"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Width = 70
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "Unit_ShortText3"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Rqd Unit"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Width = 70
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "RequestedQuantity_Double"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "QTY to Issue"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Width = 70
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "QuantityInStock_Double"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "QTY in Store"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Width = 70
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "RequisitionQuantity_Double"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "QTY to Order"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Width = 70
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "ManufacturerPartNo_ShortText30Fld"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Part #"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Width = 150
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "ManufacturerDescription_ShortText250"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "ManufacturerDescription"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Width = 300
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "BrandName_ShortText20"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Brand"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Width = 150
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "ProductDescription_ShortText250"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "excel"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Width = 300
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "StatusText_ShortText25"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Status"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Width = 150
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Visible = True

            End Select
            If PartsRequisitionsItemsDataGridView.Columns.Item(i).Visible = True Then
                PartsRequisitionsItemsDataGridView.Width = PartsRequisitionsItemsDataGridView.Width + PartsRequisitionsItemsDataGridView.Columns.Item(i).Width
            End If
        Next
        If PartsRequisitionsItemsDataGridView.Width > Me.Width Then
            PartsRequisitionsItemsDataGridView.Width = Me.Width - 8
        End If
    End Sub

    Private Sub PartsRequisitionsItemsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles PartsRequisitionsItemsDataGridView.RowEnter
        CurrentPartsRequisitionsItemsID = -1
        If e.RowIndex < 0 Then Exit Sub
        If PartsRequisitionsItemsRecordCount = 0 Then Exit Sub
        CurrentPartsRequisitionsItemsDataGridViewRow = e.RowIndex

        CurrentWorkOrderRequestedPartID = PartsRequisitionsItemsDataGridView.Item("WorkOrderRequestedPartID_AutoNumber", CurrentPartsRequisitionsItemsDataGridViewRow).Value
        '        CurrentProductsPartID = PartsRequisitionsItemsDataGridView.Item("ProductsPartID_Autonumber", CurrentPartsRequisitionsItemsDataGridViewRow).Value
        CurrentPartsRequisitionsItemID = PartsRequisitionsItemsDataGridView.Item("PartsRequisitionsItemID_AutoNumber", CurrentPartsRequisitionsItemsDataGridViewRow).Value
        RequestedQuantityTextBox.Text = PartsRequisitionsItemsDataGridView.Item("Quantity_Integer", CurrentPartsRequisitionsItemsDataGridViewRow).Value
        AvailableQuantityTextBox.Text = "0"
        ToOrderQuantityTextBox.Text = "0"
        AvailableQuantityTextBox.Text = NotNull(PartsRequisitionsItemsDataGridView.Item("QuantityInStock_Double", CurrentPartsRequisitionsItemsDataGridViewRow).Value)
        ToIssueQuantityTextBox.Text = PartsRequisitionsItemsDataGridView.Item("RequestedQuantity_Double", CurrentPartsRequisitionsItemsDataGridViewRow).Value
        ToOrderQuantityTextBox.Text = PartsRequisitionsItemsDataGridView.Item("RequisitionQuantity_Double", CurrentPartsRequisitionsItemsDataGridViewRow).Value
        CurrentQtyToIssue = Val(ToIssueQuantityTextBox.Text)
        CurrentQtyToOrder = Val(ToOrderQuantityTextBox.Text)


    End Sub


    Private Sub AddNewPartNumber()
        ' WRONG THISSHOUD BE CALLING UPDATE CODEVEHICLEPARTNUN
    End Sub


    Private Sub CheckAndIssueThisPartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckStockAvailabilityToolStripMenuItem.Click
        ProductsPartsForm.SearchDescriptionToolStripTextBox.Text = WorkOrderRequestedPartsDataGridView.Item("SystemDesc_ShortText100Fld", CurrentWorkOrderRequestedPartsDataGridViewRow).Value
        ProductsPartsForm.VehicleFilterToolStripTextBox.Text = VehicleModelTextBox.Text
        '        Tunnel1 = "Tunnel1IsMasterCodeBookID"
        '       Tunnel2 = WorkOrderRequestedPartsDataGridView.Item("MasterCodeBookID_LongInteger", CurrentWorkOrderRequestedPartsDataGridViewRow).Value
        ShowCalledForm(Me, ProductsPartsForm)

    End Sub
    Private Sub EditProductToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditPartDetailsToolStripMenuItem.Click
        EnableEdit()
    End Sub
    Private Sub EnableEdit()
        'ToOrderQuantityTextBox.Enabled = False
        If Val(ToIssueQuantityTextBox.Text) > 0 Then
            If MsgBox("Would you like to change QUANTITIES ?", vbYesNoCancel) = MsgBoxResult.Yes Then
                QuantityGroupBox.Visible = True
                QuantityGroupBox.Select()
            End If
            If CurrentProductsPartID > 0 Then
                If MsgBox("Retain this Product ?", vbYesNoCancel) = MsgBoxResult.No Then
                    MySelection = " UPDATE WorkOrderRequestedPartsTable  " &
                              " SET ProductPartID_LongInteger = 0 " &
                              " WHERE WorkOrderRequestedPartID_AutoNumber = " & CurrentWorkOrderRequestedPartID.ToString
                    JustExecuteMySelection()
                    FillWorkOrderRequestedPartsDataGridView()
                End If
            End If
            WorkOrderRequestedPartsDataGridView.Refresh()
        End If
    End Sub

    Private Sub DeleteProductToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteProductToolStripMenuItem.Click
        If Not MsgBox("Would you like to remove the specified Product ?", vbYesNoCancel) = MsgBoxResult.Yes Then
            Exit Sub
        End If
        If Not MsgBox("Are you sure to unlink this product ?", vbYesNoCancel) = MsgBoxResult.Yes Then
            Exit Sub
        End If
        MySelection = " UPDATE WorkOrderRequestedPartsTable  " &
                              " SET ProductPartID_LongInteger = -1 " &
                              " WHERE WorkOrderRequestedPartID_AutoNumber = " & CurrentWorkOrderRequestedPartID
        JustExecuteMySelection()
        FillWorkOrderRequestedPartsDataGridView()
    End Sub
    Private Sub SubmitAllRequisitionsForPurchaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SubmitRequisitionsForPurchaseToolStripMenuItem.Click


        If SubmitRequisitionsForPurchaseToolStripMenuItem.Text = "Requisition has already been submitted" Then
            QuantityGroupBox.Visible = False
            Exit Sub
        End If

        If MsgBox("Continue submit requisition for purchase?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        'CREATE A HEADER HERE
        Dim FieldsToUpdate = "
                            RequisitionDate_ShortDate, 
                            RequestedByID_LongInteger, 
                            VehicleID_LongInteger, 
                            PartsRequisitionStatus_Integer 
                            "
        Dim FieldsData =
                            Chr(34) & DateString & Chr(34) & ", " &
                            CurrentUserID.ToString & "," &
                            CurrentVehicleID.ToString & "," &
                             GetStatusIdFor("PartsRequisitionsTable").ToString

        CurrentPartsRequisitionID = InsertNewRecord("PartsRequisitionsTable", FieldsToUpdate, FieldsData)


        'ALL TEMPORARY ITEMS IN PartsRequisitionsItemsTable WILL THEN BE MARKED FINAL REPLACING THE PartsRequisitionID_LongInteger
        ' WITH THE NEWLY CREATED PartsRequisitionsHeader

        For i = 0 To PartsRequisitionsItemsRecordCount - 1
            CurrentPartsRequisitionsItemID = PartsRequisitionsItemsDataGridView.Item("PartsRequisitionsItemID_AutoNumber", i).Value

            MySelection = " UPDATE PartsRequisitionsItemsTable  " &
                              " SET PartsRequisitionID_LongInteger = " & CurrentPartsRequisitionID.ToString & ", " &
                              " PartsRequisitionItemStatusID_LongInteger = " & GetStatusIdFor("PartsRequisitionsItemsTable", "Requisition Submitted").ToString &
                              " WHERE PartsRequisitionsItemID_AutoNumber = " & CurrentPartsRequisitionsItemID.ToString
            JustExecuteMySelection()

            CurrentWorkOrderRequestedPartID = PartsRequisitionsItemsDataGridView.Item("WorkOrderRequestedPartID_LongInteger", i).Value
            MySelection = " UPDATE WorkOrderRequestedPartsTable  " &
                              " SET WorkOrderRequestedPartStatus_Integer = " & GetStatusIdFor("WorkOrderRequestedPartsTable", "Requisition Submitted").ToString &
                              " WHERE WorkOrderRequestedPartID_AutoNumber = " & CurrentWorkOrderRequestedPartID.ToString
            JustExecuteMySelection()

            CurrentWorkOrderRequestedPartID = PartsRequisitionsItemsDataGridView.Item("WorkOrderRequestedPartID_LongInteger", i).Value
        Next
        MySelection = " UPDATE WorkOrderRequestedPartsHeadersTable  " &
                              " SET WorkOrderPartsRequisitionStatusID_Integer = " & GetStatusIdFor("WorkOrderRequestedPartsHeadersTable", "Procurement Outstanding").ToString &
                              " WHERE WorkOrderRequestedPartsHeaderID_AutoNumber = " & CurrentWorkOrderRequestedPartsHeaderID.ToString
        JustExecuteMySelection()

        QuantityGroupBox.Visible = False
        FillWorkOrderPartsRequisitionsDataGridView()

    End Sub

    Private Sub QuantityGroupBox_VisibleChanged(sender As Object, e As EventArgs) Handles QuantityGroupBox.VisibleChanged
        If QuantityGroupBox.Visible = True Then
            If IsEmpty(ToOrderQuantityTextBox.Text) Then ToOrderQuantityTextBox.Text = ToIssueQuantityTextBox.Text
            CheckStockAvailabilityToolStripMenuItem.Visible = False
            EditPartDetailsToolStripMenuItem.Visible = False
            WorkOrderPartsRequisitionsDataGridView.Enabled = False
            WorkOrderRequestedPartsDataGridView.Enabled = False
            RequestForPurchaseGroupBox.Enabled = False
        Else
            CheckStockAvailabilityToolStripMenuItem.Visible = True
            EditPartDetailsToolStripMenuItem.Visible = True
            WorkOrderPartsRequisitionsDataGridView.Enabled = True
            WorkOrderRequestedPartsDataGridView.Enabled = True
            RequestForPurchaseGroupBox.Enabled = True
        End If
    End Sub

    Private Sub ConfirmQuantitiesButton_Click(sender As Object, e As EventArgs) Handles ConfirmQuantitiesButton.Click
        ' check if ff are redunndant
        If Val(ToIssueQuantityTextBox.Text) <> CurrentQtyToIssue Then
            If Val(ToIssueQuantityTextBox.Text) > 0 Then
                UpdateWorkOrderRequestedPartsTable()
            End If
        End If
        If Val(ToOrderQuantityTextBox.Text) <> NotNull(WorkOrderRequestedPartsDataGridView.Item("RequisitionQuantity_Double", CurrentWorkOrderRequestedPartsDataGridViewRow).Value) Then
            If Val(ToOrderQuantityTextBox.Text) > 0 Then
                UpdatePartsRequisitionsItemsTable()
            Else
                If MsgBox("Remove this item?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    MySelection = " DELETE FROM PartsRequisitionsItemsTable WHERE PartsRequisitionsItemID_AutoNumber =  " & CurrentPartsRequisitionsItemID
                    JustExecuteMySelection()
                    FillPartsRequisitionsItemsDataGridView()
                    If PartsRequisitionsItemsRecordCount = 0 Then
                        MySelection = " UPDATE WorkOrderRequestedPartsTable " &
                                    " SET WorkOrderRequestedPartStatus_Integer = " & GetStatusIdFor("WorkOrderRequestedPartsTable").ToString &
                                    " WHERE WorkOrderRequestedPartID_AutoNumber = " & CurrentWorkOrderRequestedPartID.ToString

                        JustExecuteMySelection()
                        WorkOrderRequestedPartsDataGridView.RefreshEdit()
                        If WorkOrderRequestedPartsRecordCount = 1 Then
                            MySelection = " UPDATE WorkOrderRequestedPartsHeadersTable " &
                                    " SET WorkOrderPartsRequisitionStatusID_Integer = " & GetStatusIdFor("WorkOrderRequestedPartsHeadersTable").ToString &
                                    " WHERE WorkOrderRequestedPartsHeaderID_AutoNumber = " & CurrentWorkOrderRequestedPartsHeaderID.ToString
                            JustExecuteMySelection()
                            WorkOrderRequestedPartsDataGridView.RefreshEdit()
                        End If
                    End If
                End If
            End If
        End If
        QuantityGroupBox.Visible = False
        FillWorkOrderRequestedPartsDataGridView()
        FillPartsRequisitionsItemsDataGridView()

    End Sub
    Private Sub UpdatePartsRequisitionsItemsTable()

        Dim xxFilter = ""


        ' THIS MODULE MAY BE CALLED BY the SYSTEM WHEN:
        '                           1-THE REQUEST FOR PARTS IS AUTO DETERMINED UPON ENTRY TO THE PrepareRequisitionForPurchase ROUTINE
        '                           2-ConfirmQuantities ROUTINE IS REQUESTING THIS ROUTINE

        'NEXT WE WILL UPDATE THE WAREHOUSE DATABASE (STOCKS TABLE) when product is specified

        If IsNotEmpty(CurrentProductsPartID) Then ' THERE IS A PRODUCT LINKED (SPECIFIC TO BUY)
            xxFilter = " WHERE ProductPartID_LongInteger = " & CurrentProductsPartID

            MySelection = " SELECT * FROM StocksTable " & xxFilter
            JustExecuteMySelection()

            If RecordCount = 0 Then
                MySelection = " INSERT INTO StocksTable (" &
                                       " ProductPartID_LongInteger, " &
                                       " Location_ShortText10, " &
                                       " QuantityInStock_Double " &
                                ") VALUES (" &
                                       CurrentProductsPartID.ToString & "," &
                                      Chr(34) & Chr(34) & "," &
                                      0.ToString & ")"

                JustExecuteMySelection()
            End If
        End If

        'IS THERE ALREADY REFERENCED RECORD IN THE PartsRequisitionsItemsTable?
        ' CHECK IF THERE IS ALREADY A CORRESPONDING RECORD  IN THE RequisitiosItemsTable and is flagged active (1)
        Dim InsertFlag = False
        If IsNotEmpty(CurrentPartsRequisitionsItemID) Then
            xxFilter = " WHERE PartsRequisitionsItemID_AutoNumber = " & CurrentPartsRequisitionsItemID.ToString

            MySelection = " SELECT * FROM PartsRequisitionsItemsTable " & xxFilter

            JustExecuteMySelection()

            If RecordCount > 0 Then
                If Val(ToOrderQuantityTextBox.Text) = 0 Then
                    If MsgBox("You reset the value to order to 0, Do you want to remove this order ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        MySelection = " PartsRequisitionsItemsTable " & xxFilter
                    End If
                Else
                    MySelection = " UPDATE PartsRequisitionsItemsTable " &
                                    " SET PartsRequisitionID_LongInteger = " & CurrentPartsRequisitionID.ToString & ", " &
                                    " ProductPartID_LongInteger = " & CurrentProductsPartID.ToString & ", " &
                                    " PartsRequisitionItemStatusID_LongInteger = " & GetStatusIdFor("PartsRequisitionsItemsTable", "Draft Requisition").ToString & ", " &
                                    " RequisitionQuantity_Double = " & ToOrderQuantityTextBox.Text & xxFilter
                    JustExecuteMySelection()
                End If
            Else
                InsertFlag = True
            End If
        Else
            'note PartsRequisitionID_LongInteger is initially set to -1
            'and will be updated once a requisition header is created upon submissioon to the procurement department
            If ToOrderQuantityTextBox.Text > 0 Then
                InsertFlag = True
            End If
        End If
        If InsertFlag Then
            InsertNewPartsRequisitionsItem()
        End If

    End Sub
    Private Sub InsertNewPartsRequisitionsItem()
        Dim FieldsToUpdate =
                                       " PartsRequisitionID_LongInteger, " &
                                       " ProductPartID_LongInteger, " &
                                       " RequisitionQuantity_Double, " &
                                       " WorkOrderRequestedPartID_LongInteger, " &
                                       " PartsRequisitionItemStatusID_LongInteger "
        Dim FieldsData =
                                        -1.ToString & "," &
                                        CurrentProductsPartID.ToString & "," &
                                        ToOrderQuantityTextBox.Text & "," &
                                        CurrentWorkOrderRequestedPartID.ToString & "," &
                                        GetStatusIdFor("PartsRequisitionsItemsTable")
        CurrentPartsRequisitionsItemID = InsertNewRecord("PartsRequisitionsItemsTable", FieldsToUpdate, FieldsData)
        Dim xxRequisitionsItemsDataGridViewRow = CurrentPartsRequisitionsItemsDataGridViewRow
        FillPartsRequisitionsItemsDataGridView()
        PartsRequisitionsItemsDataGridView.Rows(RecordCount - 1).Selected = True
        MySelection = " UPDATE WorkOrderRequestedPartsHeadersTable " &
                              " SET WorkOrderPartsRequisitionStatusID_Integer = " & GetStatusIdFor("WorkOrderRequestedPartsHeadersTable", "Draft Requisition") &
                              " WHERE WorkOrderRequestedPartsHeaderID_AutoNumber = " & CurrentWorkOrderRequestedPartsHeaderID
        JustExecuteMySelection()
    End Sub
    Private Sub UpdateWorkOrderRequestedPartsTable()
        If MsgBox("Proceed replacing ToIssue Qty from " & CurrentQtyToIssue.ToString & " to " & ToIssueQuantityTextBox.Text, MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        ' EXECUTE INSERT COMMAND 
        Dim xxFilter = ""
        If IsEmpty(CurrentWorkOrderRequestedPartID) Then ' THE PART HAS NO RECORD YET IN THE WorkOrderRequestedPartsTable
            RecordCount = 0
        Else
            xxFilter = " WHERE WorkOrderRequestedPartID_AutoNumber = " & CurrentWorkOrderRequestedPartID.ToString

            MySelection = " SELECT * FROM WorkOrderRequestedPartsTable " & xxFilter

            JustExecuteMySelection()
        End If

        If RecordCount > 0 Then
            MySelection = " UPDATE WorkOrderRequestedPartsTable " &
                              " SET RequestedQuantity_Double = " & ToIssueQuantityTextBox.Text & xxFilter
        Else
            MySelection = " INSERT INTO WorkOrderRequestedPartsTable (" &
                                       " WorkOrderPartID_LongInteger, " &
                                       " ProductPartID_LongInteger, " &
                                       " RequestedQuantity_Double " &
                                ") VALUES (" &
                                       CurrentWorkOrderPartID.ToString & "," &
                                       CurrentProductsPartID.ToString & "," &
                                       ToIssueQuantityTextBox.Text & ")"
        End If
        JustExecuteMySelection()
    End Sub
    Private Sub OutstandingRequisitionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OutstandingRequisitionsToolStripMenuItem.Click
        SetWorkOrderPartsRequisitionsSelectionFilter(GetStatusIdFor("Procurement Outstanding"), 1, Me, "Outstanding Requisitions")
    End Sub

    Private Sub DraftRequisitiosForPurchaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DraftRequisitiosForPurchaseToolStripMenuItem.Click
        SetWorkOrderPartsRequisitionsSelectionFilter(GetStatusIdFor("Draft Requisition"), 2, Me, "Draft Requisition")
    End Sub
    Private Sub AllPurchaseOrdersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SubmittedRequisitionsToolStripMenuItem.Click
        SetWorkOrderPartsRequisitionsSelectionFilter(GetStatusIdFor("Procurement Outstanding"), 3, Me, "Submitted Requisitions")
    End Sub

    Private Sub PrintPurchaseOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReOrderedToolStripMenuItem.Click
        SetWorkOrderPartsRequisitionsSelectionFilter(GetStatusIdFor("Re-ordered"), 2, Me, "Re-ordered")
    End Sub

    Private Sub ReorderedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PartiallyDeliveredToolStripMenuItem.Click
        SetWorkOrderPartsRequisitionsSelectionFilter(GetStatusIdFor("Partially Delivered"), 2, Me, "Partially Delivered")
    End Sub

    Private Sub CompletelyReceivedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompletelyDeliveredToolStripMenuItem.Click
        SetWorkOrderPartsRequisitionsSelectionFilter(GetStatusIdFor("Completely Delivered"), 2, Me, "Completely Delivered")
    End Sub

    Private Sub FinalizedPurchaseOrdersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PartiallyIssuedToolStripMenuItem.Click
        SetWorkOrderPartsRequisitionsSelectionFilter(GetStatusIdFor("Partially Issued"), 2, Me, "Partially Issued")
    End Sub

    Private Sub CompletelyIssuedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompletelyIssuedToolStripMenuItem.Click
        SetWorkOrderPartsRequisitionsSelectionFilter(GetStatusIdFor("Completely Issued"), 2, Me, "Completely Issued")
    End Sub

    Private Sub AllPartsRequisitionsForIssuanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllPartsRequisitionsForIssuanceToolStripMenuItem.Click
        SetWorkOrderPartsRequisitionsSelectionFilter(GetStatusIdFor("Used"), 3, Me, "ALL REQUISITIONS")
    End Sub
    Private Sub SetWorkOrderPartsRequisitionsSelectionFilter(PassedStatusSequence As Integer, PassedStatusSequenceCondition As Integer, PassedForm As Form, FormHeaderText As String)
        WorkOrderPartsRequisitionsSelectionFilter = SetupTableSelectionFilter(PassedStatusSequence, PassedStatusSequenceCondition, PassedForm, FormHeaderText)
        FillWorkOrderPartsRequisitionsDataGridView()
    End Sub

    Private Sub PrintReleaseNotesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintReleaseNotesToolStripMenuItem.Click
        PrintReleaseNotesToolStripMenuItem.Visible = False
        PartsReleaseInfoGroupBox.Visible = True
        ReceivedByTextBox.Text = WorkOrderPartsRequisitionsDataGridView.Item("RequestedBy", CurrentWorkOrderPartsRequisitionsDataGridViewRow).Value
    End Sub

    Private Sub ReceivedByTextBox_Click(sender As Object, e As EventArgs) Handles ReceivedByTextBox.Click
        If MsgBox("Is the recepient not this person? ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        ShowCalledForm(Me, PersonnelsForm)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MsgBox("Continue finalizing to the issuance ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        WorkOrderRequestedPartsSelectionFilter = " WHERE WorkOrderRequestedPartsHeaderID_AutoNumber = " & CurrentWorkOrderRequestedPartsHeaderID.ToString
        Dim xxStatus = ""
        FillWorkOrderRequestedPartsDataGridView()
        For i = 0 To WorkOrderRequestedPartsRecordCount - 1
            'update WorkOrderRequestedPartID
            'WorkOrderRequestedPartStatus_Integer   if issued quantity  - requested quantity "Partially Issued" else 
            '                                                                                        "Completely Issued"
            xxStatus = "Completely Issued"
            Dim xxOrdered = WorkOrderRequestedPartsDataGridView.Item("RequestedQuantity_Double", i).Value
            Dim xxQuantityInStock_Double = WorkOrderRequestedPartsDataGridView.Item("QuantityInStock_Double", i).Value
            Dim xxToIssue = xxOrdered
            If xxQuantityInStock_Double - xxOrdered Then
                xxToIssue = xxQuantityInStock_Double
                xxStatus = "Partially Issued"
            End If
            CurrentWorkOrderRequestedPartID = WorkOrderRequestedPartsDataGridView.Item("WorkOrderRequestedPartID_AutoNumber", i).Value

            MySelection = " UPDATE WorkOrderRequestedPartsTable  " &
                              " SET WorkOrderRequestedPartStatus_Integer = " &
                                    GetStatusIdFor("WorkOrderRequestedPartsTable", xxStatus).ToString &
                              " WHERE WorkOrderRequestedPartID_AutoNumber = " & CurrentWorkOrderRequestedPartID.ToString
            JustExecuteMySelection()




            'UPDATE STOCK
            'get the amount to issue and update available quantity
            'get stock id 

            Dim xxAvailableStockBalance = xxQuantityInStock_Double - xxToIssue


            Dim xxStockID = WorkOrderRequestedPartsDataGridView.Item("StockID_Autonumber", CurrentWorkOrderRequestedPartsDataGridViewRow).Value
            Dim xxFilter = " WHERE StockID_Autonumber = " & xxStockID.ToString
            MySelection = " UPDATE StocksTable " &
                               " SET QuantityInStock_Double = " & xxAvailableStockBalance.ToString
            JustExecuteMySelection()

        Next


        ' now update requisition header status
        ' reset the selected records to all items attached
        ' go through all items if these are alredy "completely issued"
        ' otherwise set to partialy issued

        WorkOrderRequestedPartsSelectionFilter = " WHERE WorkOrderRequestedPartsHeaderID_AutoNumber = " & CurrentWorkOrderRequestedPartsHeaderID.ToString
        FillWorkOrderRequestedPartsDataGridView()

        Dim xxCompletelyIssuedStatusID = GetStatusIdFor("WorkOrderRequestedPartsTable", "Completely Issued").ToString
        xxStatus = "Completely Issued"
        'Determine if all items in these requisition are all Issued
        For i = 0 To WorkOrderRequestedPartsRecordCount - 1
            Dim xxStatusText_ShortText25 = WorkOrderRequestedPartsDataGridView.Item("StatusText_ShortText25", i).Value
            If Not xxStatusText_ShortText25 = "Completely Issued" Then
                xxStatus = "Partially Issued"
            End If
        Next
        MySelection = " UPDATE WorkOrderRequestedPartsHeadersTable  " &
                              " SET WorkOrderPartsRequisitionStatusID_Integer = " & GetStatusIdFor("WorkOrderRequestedPartsHeadersTable", "Completely Issued") &
                              " WHERE WorkOrderRequestedPartsHeaderID_AutoNumber = " & CurrentWorkOrderRequestedPartsHeaderID.ToString

        JustExecuteMySelection()
        FillWorkOrderPartsRequisitionsDataGridView()
    End Sub
End Class