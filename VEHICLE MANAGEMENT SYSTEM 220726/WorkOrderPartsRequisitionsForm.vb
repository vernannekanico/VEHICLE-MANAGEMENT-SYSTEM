Public Class WorkOrderPartsRequisitionsForm
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

    Private AvailableStocksFieldsToSelect = ""
    Private AvailableStocksSelectionFilter = ""
    Private AvailableStocksSelectionOrder = ""
    Private CurrentAvailableStocksRow As Integer = -1
    Private AvailableStocksRecordCount As Integer = -1
    Private CurrentAvailableStockID = -1
    Private CurrentAvailableStockStatus As String
    Private AvailableStocksDataGridViewAlreadyFormated = False

    Private WorkOrderIssuedPartsFieldsToSelect = ""
    Private WorkOrderIssuedPartsSelectionFilter = ""
    Private WorkOrderIssuedPartsSelectionOrder = ""
    Private CurrentWorkOrderIssuedPartsRow As Integer = -1
    Private WorkOrderIssuedPartsRecordCount As Integer = -1
    Private CurrentWorkOrderIssuedPartID = -1
    Private CurrentWorkOrderIssuedPartStatus As String
    Private WorkOrderIssuedPartsDataGridViewAlreadyFormated = False

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
    Private CurrentPartsSpecificationID = -1
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

    Private Sub FillWorkOrderRequestedPartsHeadersDataGridView()


        WorkOrderPartsRequisitionsFieldsToSelect = "
Select
WorkOrdersTable.WorkOrderNumber_ShortText12,
WorkOrderRequestedPartsHeadersTable.WorkOrderRequestedPartsHeaderNumber_ShortText12,
WorkOrderRequestedPartsHeadersTable.WorkOrderRequestedPartsHeaderRevision_Integer,
WorkOrderRequestedPartsHeadersTable.WorkOrderRequestedPartsHeaderDate_ShortDate,
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
FROM ((((((((WorkOrderRequestedPartsHeadersTable 
LEFT JOIN WorkOrdersTable ON WorkOrderRequestedPartsHeadersTable.WorkOrderID_LongInteger = WorkOrdersTable.WorkOrderID_AutoNumber) 
LEFT JOIN ServicedVehiclesTable ON WorkOrdersTable.ServicedVehicleID_LongInteger = ServicedVehiclesTable.ServicedVehicleID_AutoNumber) 
LEFT JOIN VehiclesTable ON ServicedVehiclesTable.VehicleID_LongInteger = VehiclesTable.VehicleID_AutoNumber) 
LEFT JOIN VehicleModelsRelationsTable ON VehiclesTable.VehicleModelsRelationID_LongInteger = VehicleModelsRelationsTable.VehicleModelsRelationID_Autonumber) 
LEFT JOIN VehicleTypeTable ON VehicleModelsRelationsTable.VehicleTypeID_LongInteger = VehicleTypeTable.VehicleTypeID_AutoNumber) 
LEFT JOIN VehicleTrimTable ON VehicleModelsRelationsTable.VehicleTrimID_LongInteger = VehicleTrimTable.VehicleTrimID_Autonumber) 
LEFT JOIN VehicleModelsTable ON VehicleModelsRelationsTable.VehicleModelID_LongInteger = VehicleModelsTable.VehicleModelID_Autonumber) 
LEFT JOIN PersonnelTable ON WorkOrderRequestedPartsHeadersTable.RequestedByID_LongInteger = PersonnelTable.PersonnelID_AutoNumber) 
LEFT JOIN StatusesTable ON WorkOrderRequestedPartsHeadersTable.WorkOrderRequestedPartsHeaderStatusID_Integer = StatusesTable.StatusID_Autonumber
"
        WorkOrderPartsRequisitionsSelectionOrder = " ORDER BY WorkOrderRequestedPartsHeaderID_AutoNumber DESC "

        MySelection = WorkOrderPartsRequisitionsFieldsToSelect & WorkOrderPartsRequisitionsSelectionFilter & WorkOrderPartsRequisitionsSelectionOrder

        JustExecuteMySelection()
        WorkOrderPartsRequisitionsRecordCount = RecordCount
        WorkOrderRequestedPartsHeadersDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        Dim RecordsToDisplay = 8
        If WorkOrderPartsRequisitionsRecordCount < RecordsToDisplay Then RecordsToDisplay = WorkOrderPartsRequisitionsRecordCount
        WorkOrderRequestedPartsHeadersDataGridView.Height = WorkOrderRequestedPartsHeadersDataGridView.ColumnHeadersHeight + (DataGridViewRowHeight * (RecordsToDisplay + 1))

        If Not WorkOrderPartsRequisitionsDataGridViewAlreadyFormated Then
            FormatWorkOrderPartsRequisitionsDataGridView()
        End If

    End Sub
    Private Sub FormatWorkOrderPartsRequisitionsDataGridView()
        WorkOrderPartsRequisitionsDataGridViewAlreadyFormated = True
        WorkOrderRequestedPartsHeadersDataGridView.Width = 0
        For i = 0 To WorkOrderRequestedPartsHeadersDataGridView.Columns.GetColumnCount(0) - 1

            WorkOrderRequestedPartsHeadersDataGridView.Columns.Item(i).Visible = False

            Select Case WorkOrderRequestedPartsHeadersDataGridView.Columns.Item(i).HeaderText

                Case "VehicleName"
                    WorkOrderRequestedPartsHeadersDataGridView.Columns.Item(i).HeaderText = "Model"
                    WorkOrderRequestedPartsHeadersDataGridView.Columns.Item(i).Width = 300
                    WorkOrderRequestedPartsHeadersDataGridView.Columns.Item(i).Visible = True
                Case "WorkOrderNumber_ShortText12"
                    WorkOrderRequestedPartsHeadersDataGridView.Columns.Item(i).HeaderText = "Work Order #"
                    WorkOrderRequestedPartsHeadersDataGridView.Columns.Item(i).Width = 170
                    WorkOrderRequestedPartsHeadersDataGridView.Columns.Item(i).Visible = True
                Case "WorkOrderPartsRequisitionNumber_ShortText12"
                    WorkOrderRequestedPartsHeadersDataGridView.Columns.Item(i).HeaderText = "Requitition No. "
                    WorkOrderRequestedPartsHeadersDataGridView.Columns.Item(i).Width = 100
                    WorkOrderRequestedPartsHeadersDataGridView.Columns.Item(i).Visible = True
                Case "WorkOrderPartsRequisitionRevision_Integer"
                    WorkOrderRequestedPartsHeadersDataGridView.Columns.Item(i).HeaderText = "Rev"
                    WorkOrderRequestedPartsHeadersDataGridView.Columns.Item(i).Width = 30
                    WorkOrderRequestedPartsHeadersDataGridView.Columns.Item(i).Visible = True
                Case "WorkOrderPartsRequisitionDate_ShortDate"
                    WorkOrderRequestedPartsHeadersDataGridView.Columns.Item(i).HeaderText = "Date"
                    WorkOrderRequestedPartsHeadersDataGridView.Columns.Item(i).Width = 120
                    WorkOrderRequestedPartsHeadersDataGridView.Columns.Item(i).Visible = True
                Case "StatusText_ShortText25"
                    WorkOrderRequestedPartsHeadersDataGridView.Columns.Item(i).HeaderText = "Status"
                    WorkOrderRequestedPartsHeadersDataGridView.Columns.Item(i).Width = 250
                    WorkOrderRequestedPartsHeadersDataGridView.Columns.Item(i).Visible = True
            End Select
            If WorkOrderRequestedPartsHeadersDataGridView.Columns.Item(i).Visible = True Then
                WorkOrderRequestedPartsHeadersDataGridView.Width = WorkOrderRequestedPartsHeadersDataGridView.Width + WorkOrderRequestedPartsHeadersDataGridView.Columns.Item(i).Width
            End If
        Next
        ' NOTE" SYSTEM AUTOFITS THE GRIDVIEW FIELDS ACCORDING To THEIR WITDH

        Me.Width = VehicleManagementSystemForm.Width
        Me.Height = VehicleManagementSystemForm.Height
        Me.Location = New Point(Me.Location.X, 55)
        Me.Left = VehicleManagementSystemForm.Left

        If WorkOrderRequestedPartsHeadersDataGridView.Width > Me.Width Then
            WorkOrderRequestedPartsHeadersDataGridView.Width = Me.Width - 8
        End If

        WorkOrderRequestedPartsHeadersDataGridView.Left = 5
        WorkOrderRequestedPartsHeadersDataGridView.Top = WorkOrderPartsMenuStrip.Top + WorkOrderPartsMenuStrip.Height

        WorkOrderRequestedPartsDataGridView.Top = WorkOrderRequestedPartsHeadersDataGridView.Top + WorkOrderRequestedPartsHeadersDataGridView.Height
        WorkOrderRequestedPartsDataGridView.Left = (Me.Width - WorkOrderRequestedPartsDataGridView.Width) / 2

        RequestForPurchaseGroupBox.Top = WorkOrderRequestedPartsDataGridView.Top + WorkOrderRequestedPartsDataGridView.Height
        RequestForPurchaseGroupBox.Width = Me.Width - 6
        RequestForPurchaseGroupBox.Left = (Me.Width - RequestForPurchaseGroupBox.Width) / 2
        PartsRequisitionsItemsDataGridView.Left = 5
    End Sub
    Private Sub WorkOrderPartsRequisitionsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles WorkOrderRequestedPartsHeadersDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If WorkOrderPartsRequisitionsRecordCount = 0 Then Exit Sub
        CurrentWorkOrderPartsRequisitionsDataGridViewRow = e.RowIndex

        CurrentWorkOrderRequestedPartsHeaderID = WorkOrderRequestedPartsHeadersDataGridView.Item("WorkOrderRequestedPartsHeaderID_AutoNumber", CurrentWorkOrderPartsRequisitionsDataGridViewRow).Value
        Dim CurrentWorkOrderPartsRequisitionStatusSequence = WorkOrderRequestedPartsHeadersDataGridView.Item("StatusSequence_LongInteger", CurrentWorkOrderPartsRequisitionsDataGridViewRow).Value
        WorkOrderPartsRequisitionStatus = WorkOrderRequestedPartsHeadersDataGridView.Item("StatusText_ShortText25", CurrentWorkOrderPartsRequisitionsDataGridViewRow).Value
        CurrentWorkOrderID = WorkOrderRequestedPartsHeadersDataGridView.Item("WorkOrderID_LongInteger", CurrentWorkOrderPartsRequisitionsDataGridViewRow).Value
        VehicleModelTextBox.Text = WorkOrderRequestedPartsHeadersDataGridView.Item("VehicleName", CurrentWorkOrderPartsRequisitionsDataGridViewRow).Value
        EditPartDetailsToolStripMenuItem.Visible = False
        DeleteProductToolStripMenuItem.Visible = False
        SubmitRequisitionsForPurchaseToolStripMenuItem.Visible = False


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
        WorkOrderRequestedPartsHeadersDataGridView.Enabled = False
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
PartsSpecificationsTable.PartSpecifications_ShortText255,
ProductsPartsTable.ManufacturerPartNo_ShortText30Fld, 
ProductsPartsTable.ManufacturerDescription_ShortText250, 
StocksTable.QuantityInStock_Double, 
WorkOrderRequestedPartsTable.RequestedQuantity_Double, 
PartsRequisitionsItemsTable.RequisitionQuantity_Double, 
BrandsTable.BrandName_ShortText20, 
StocksTable.Location_ShortText10, 
ProductsPartsTable.ProductDescription_ShortText250, 
WorkOrderRequestedPartsTable.WorkOrderPartID_LongInteger, 
WorkOrderRequestedPartsTable.ProductPartID_LongInteger, 
PartsRequisitionsItemsTable.PartsRequisitionsItemID_AutoNumber, 
PartsRequisitionsItemsTable.PartsRequisitionItemStatusID_LongInteger, 
PartsRequisitionsItemsTable.PartsRequisitionItemStatusID_LongInteger, 
WorkOrderRequestedPartsTable.WorkOrderRequestedPartID_AutoNumber, 
WorkOrderRequestedPartsTable.WorkOrderRequestedPartsHeaderID_LongInteger, 
MasterCodeBookTable.MasterCodeBookID_Autonumber, 
WorkOrderPartsTable.WorkOrderPartID_AutoNumber, 
StatusesTable.StatusText_ShortText25, 
WorkOrderRequestedPartsTable.WorkOrderRequestedPartStatus_Integer, 
StatusesTable.StatusID_Autonumber, 
CodeVehiclePartsSpecificationsRelationsTable.CodeVehicleID_LongInteger, 
CodeVehiclePartsSpecificationsRelationsTable.PartsSpecificationID_LongInteger
FROM ((((((PartsRequisitionsItemsTable RIGHT JOIN WorkOrderRequestedPartsTable ON PartsRequisitionsItemsTable.WorkOrderPartsRequisitionsItemID_LongInteger = WorkOrderRequestedPartsTable.[WorkOrderRequestedPartID_AutoNumber]) LEFT JOIN WorkOrderRequestedPartsHeadersTable ON WorkOrderRequestedPartsTable.[WorkOrderRequestedPartsHeaderID_LongInteger] = WorkOrderRequestedPartsHeadersTable.[WorkOrderRequestedPartsHeaderID_AutoNumber]) LEFT JOIN (WorkOrderPartsTable LEFT JOIN MasterCodeBookTable ON WorkOrderPartsTable.MasterCodeBookID_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) ON WorkOrderRequestedPartsTable.WorkOrderPartID_LongInteger = WorkOrderPartsTable.WorkOrderPartID_AutoNumber) LEFT JOIN (StocksTable RIGHT JOIN (ProductsPartsTable LEFT JOIN BrandsTable ON ProductsPartsTable.BrandID_LongInteger = BrandsTable.BrandID_Autonumber) ON StocksTable.ProductPartID_LongInteger = ProductsPartsTable.ProductsPartID_Autonumber) ON WorkOrderRequestedPartsTable.ProductPartID_LongInteger = ProductsPartsTable.ProductsPartID_Autonumber) LEFT JOIN StatusesTable ON WorkOrderRequestedPartsTable.[WorkOrderRequestedPartStatus_Integer] = StatusesTable.StatusID_Autonumber) LEFT JOIN CodeVehiclePartsSpecificationsRelationsTable ON WorkOrderPartsTable.CodeVehicleID_LongInteger = CodeVehiclePartsSpecificationsRelationsTable.CodeVehicleID_LongInteger) LEFT JOIN PartsSpecificationsTable ON CodeVehiclePartsSpecificationsRelationsTable.PartsSpecificationID_LongInteger = PartsSpecificationsTable.PartsSpecificationID_AutoNumber
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
                Case "PartSpecifications_ShortText255"
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).HeaderText = "Specifications"
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).Width = 250
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
        CurrentCodeVehicleID = WorkOrderRequestedPartsDataGridView.Item("CodeVehicleID_LongInteger", CurrentWorkOrderRequestedPartsDataGridViewRow).Value
        CurrentPartsSpecificationID = WorkOrderRequestedPartsDataGridView.Item("PartsSpecificationID_LongInteger", CurrentWorkOrderRequestedPartsDataGridViewRow).Value
        RequestedQuantityTextBox.Text = WorkOrderRequestedPartsDataGridView.Item("RequestedQuantity_Double", CurrentWorkOrderRequestedPartsDataGridViewRow).Value

        If Not (PrintReleaseNotesToolStripMenuItem.Visible Or PartsReleaseInfoGroupBox.Visible) Then
            DeleteProductToolStripMenuItem.Visible = True
            EditPartDetailsToolStripMenuItem.Visible = True
        End If

        ' DSPLAY PART SPECIFICATIONS IF AVAILABLE
        CheckStockAvailabilityToolStripMenuItem.Visible = False
        EditPartDetailsToolStripMenuItem.Visible = False
        DeleteProductToolStripMenuItem.Visible = False
        Select Case CurrentPartStatus
            Case "Warehouse Outstanding"
                CheckStockAvailabilityToolStripMenuItem.Visible = True
                EditPartDetailsToolStripMenuItem.Visible = True
                If IsNotEmpty(WorkOrderRequestedPartsDataGridView.Item("ManufacturerDescription_ShortText250", CurrentWorkOrderRequestedPartsDataGridViewRow).Value) Then
                    DeleteProductToolStripMenuItem.Visible = True
                End If
        End Select
        CurrentWorkOrderPartID = WorkOrderRequestedPartsDataGridView.Item("WorkOrderPartID_AutoNumber", CurrentWorkOrderRequestedPartsDataGridViewRow).Value

        WorkOrderIssuedPartsSelectionFilter = " WHERE WorkOrderPartID_LongInteger = " & CurrentWorkOrderPartID.ToString
        FillWorkOrderIssuedPartsDataGridView()

        AvailableStocksDataGridView.Visible = False
        If WorkOrderIssuedPartsRecordCount = 0 Then
            If IsNotEmpty(CurrentPartsSpecificationID) Then
                AvailableStocksSelectionFilter = " WHERE PartsSpecificationID_AutoNumber = " & CurrentPartsSpecificationID.ToString
            Else
                AvailableStocksSelectionFilter = " WHERE MasterCodeBookID_Autonumber = " & CurrentMasterCodeBookId.ToString
            End If
            FillAvailableStocksDataGridView()
        End If


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
    Private Sub FillAvailableStocksDataGridView()

        AvailableStocksSelectionOrder = " ORDER BY PartsSpecificationID_AutoNumber "
        AvailableStocksFieldsToSelect =
" 
SELECT 
PartsSpecificationsTable.PartsSpecificationID_AutoNumber,
PartsSpecificationsTable.PartSpecifications_ShortText255, 
ProductsPartsTable.ManufacturerPartNo_ShortText30Fld, 
ProductsPartsTable.ManufacturerDescription_ShortText250, 
StocksTable.QuantityInStock_Double,
ProductsPartsTable.Unit_ShortText3, 
ProductPartsPackingsTable.QuantityPerPack_Double, 
ProductPartsPackingsTable.UnitOfTheQuantity_ShortText3, 
StocksTable.Location_ShortText10
FROM ProductPartsPackingsTable RIGHT JOIN ((StocksTable LEFT JOIN ProductsPartsTable ON StocksTable.ProductPartID_LongInteger = ProductsPartsTable.ProductsPartID_Autonumber) LEFT JOIN PartsSpecificationsTable ON ProductsPartsTable.PartsSpecificationID_LongInteger = PartsSpecificationsTable.PartsSpecificationID_AutoNumber) ON ProductPartsPackingsTable.ProductPartID_LongInteger = ProductsPartsTable.ProductsPartID_Autonumber
"

        MySelection = AvailableStocksFieldsToSelect & AvailableStocksSelectionFilter & AvailableStocksSelectionOrder

        JustExecuteMySelection()
        AvailableStocksRecordCount = RecordCount

        If AvailableStocksRecordCount > 0 Then
            AvailableStocksGroupBox.Visible = True
            AvailableStocksGroupBox.Top = WorkOrderRequestedPartsDataGridView.Top + WorkOrderRequestedPartsDataGridView.Height
        Else
            CurrentAvailableStockID = -1
            AvailableStocksGroupBox.Visible = False
        End If
        AvailableStocksDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable


        ' HERE AT ROW_ENTER, FillAvailableStockConcernsDataGridView is called and AvailableStockConcernsbOX IS ALREADY FORMATTED
        If Not AvailableStocksDataGridViewAlreadyFormated Then
            FormatAvailableStocksDataGridView()
        End If

    End Sub
    Private Sub FormatAvailableStocksDataGridView()
        AvailableStocksDataGridViewAlreadyFormated = True
        AvailableStocksGroupBox.Width = 0
        For i = 0 To AvailableStocksDataGridView.Columns.GetColumnCount(0) - 1

            AvailableStocksDataGridView.Columns.Item(i).Visible = False
            Select Case AvailableStocksDataGridView.Columns.Item(i).Name
                Case "ManufacturerPartNo_ShortText30Fld"
                    AvailableStocksDataGridView.Columns.Item(i).HeaderText = "Manuf Part #"
                    AvailableStocksDataGridView.Columns.Item(i).Width = 150
                    AvailableStocksDataGridView.Columns.Item(i).Visible = True
                Case "ManufacturerDescription_ShortText250"
                    AvailableStocksDataGridView.Columns.Item(i).HeaderText = "Manuf Desc."
                    AvailableStocksDataGridView.Columns.Item(i).Width = 300
                    AvailableStocksDataGridView.Columns.Item(i).Visible = True
                Case "QuantityInStock_Double"
                    AvailableStocksDataGridView.Columns.Item(i).HeaderText = "Available"
                    AvailableStocksDataGridView.Columns.Item(i).Width = 70
                    AvailableStocksDataGridView.Columns.Item(i).Visible = True
                Case "QuantityPerPack_Double"
                    AvailableStocksDataGridView.Columns.Item(i).HeaderText = "Quantity Per Pack"
                    AvailableStocksDataGridView.Columns.Item(i).Width = 80
                    AvailableStocksDataGridView.Columns.Item(i).Visible = True
                Case "UnitOfTheQuantity_ShortText3"
                    AvailableStocksDataGridView.Columns.Item(i).HeaderText = "Quantity Unit"
                    AvailableStocksDataGridView.Columns.Item(i).Width = 80
                    AvailableStocksDataGridView.Columns.Item(i).Visible = True
                Case "Location_ShortText10"
                    AvailableStocksDataGridView.Columns.Item(i).HeaderText = "Location"
                    AvailableStocksDataGridView.Columns.Item(i).Width = 80
                    AvailableStocksDataGridView.Columns.Item(i).Visible = True
            End Select

            If AvailableStocksDataGridView.Columns.Item(i).Visible = True Then
                AvailableStocksGroupBox.Width = AvailableStocksGroupBox.Width + AvailableStocksDataGridView.Columns.Item(i).Width
            End If
        Next
        If AvailableStocksGroupBox.Width > VehicleManagementSystemForm.Width Then
            AvailableStocksGroupBox.Width = VehicleManagementSystemForm.Width - 4
        End If
        HorizontalCenter(AvailableStocksGroupBox, Me)
    End Sub
    Private Sub AvailableStocksDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles AvailableStocksDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If AvailableStocksRecordCount = 0 Then Exit Sub

        CurrentAvailableStocksRow = e.RowIndex
        CurrentAvailableStockID = AvailableStocksDataGridView.Item("AvailableStockID_AutoNumber", CurrentAvailableStocksRow).Value

        FillField(CurrentAvailableStockStatus, AvailableStocksDataGridView.Item("AvailableStockStatus", CurrentAvailableStocksRow).Value)

        Select Case CurrentAvailableStockStatus
            Case "Assigned"
        End Select

    End Sub
    Private Sub FillPartsRequisitionsItemsDataGridView()
        PartsRequisitionsItemsFieldsToSelect =
"
SELECT WorkOrderPartsTable.WorkOrderID_LongInteger, MasterCodeBookTable.MasterCodeBookID_Autonumber, ProductsPartsTable.ManufacturerPartNo_ShortText30Fld, ProductsPartsTable.ManufacturerDescription_ShortText250, WorkOrderPartsTable.Quantity_Integer, WorkOrderPartsTable.Unit_ShortText3, StocksTable.QuantityInStock_Double, [WorkOrderRequestedPartsTable].[RequestedQuantity_Double], PartsRequisitionsItemsTable.PartsRequisitionsItemID_AutoNumber, PartsRequisitionsItemsTable.RequisitionQuantity_Double, PartsRequisitionsItemsTable.PartsRequisitionID_LongInteger, PartsRequisitionsItemsTable.ProductPartID_LongInteger, PartsRequisitionsItemsTable.PartsRequisitionItemStatusID_LongInteger, MasterCodeBookTable.SystemDesc_ShortText100Fld, ProductsPartsTable.ProductsPartID_Autonumber, BrandsTable.BrandName_ShortText20, ProductsPartsTable.ProductDescription_ShortText250, WorkOrderPartsTable.WorkOrderPartID_AutoNumber, [WorkOrderRequestedPartsTable].WorkOrderPartID_LongInteger, [WorkOrderRequestedPartsTable].[WorkOrderRequestedPartID_AutoNumber], PartsRequisitionsTable.PartsRequisitionStatus_Integer, StatusesTable.StatusText_ShortText25, WorkOrderConcernsTable.WorkOrderID_LongInteger
FROM ((((PartsRequisitionsItemsTable LEFT JOIN ((((WorkOrderRequestedPartsTable LEFT JOIN ProductsPartsTable ON [WorkOrderRequestedPartsTable].ProductPartID_LongInteger=ProductsPartsTable.ProductsPartID_Autonumber) LEFT JOIN StocksTable ON [WorkOrderRequestedPartsTable].ProductPartID_LongInteger=StocksTable.ProductPartID_LongInteger) LEFT JOIN BrandsTable ON ProductsPartsTable.BrandID_LongInteger = BrandsTable.BrandID_Autonumber) LEFT JOIN ((WorkOrderPartsTable LEFT JOIN MasterCodeBookTable ON WorkOrderPartsTable.MasterCodeBookID_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) LEFT JOIN WorkOrderRequestedPartsHeadersTable ON WorkOrderPartsTable.[WorkOrderRequestedPartsHeaderID_LongInteger]=[WorkOrderRequestedPartsHeadersTable].[WorkOrderRequestedPartsHeaderID_AutoNumber]) ON [WorkOrderRequestedPartsTable].WorkOrderPartID_LongInteger=WorkOrderPartsTable.WorkOrderPartID_AutoNumber) ON PartsRequisitionsItemsTable.WorkOrderPartsRequisitionsItemID_LongInteger=[WorkOrderRequestedPartsTable].[WorkOrderRequestedPartID_AutoNumber]) LEFT JOIN PartsRequisitionsTable ON PartsRequisitionsItemsTable.PartsRequisitionID_LongInteger = PartsRequisitionsTable.PartsRequisitionID_AutoNumber) LEFT JOIN StatusesTable ON PartsRequisitionsItemsTable.PartsRequisitionItemStatusID_LongInteger = StatusesTable.StatusID_Autonumber) LEFT JOIN WorkOrderConcernJobsTable ON WorkOrderPartsTable.WorkOrderConcernJobID_LongInteger = WorkOrderConcernJobsTable.WorkOrderConcernJobID_AutoNumber) LEFT JOIN WorkOrderConcernsTable ON WorkOrderConcernJobsTable.WorkOrderConcernID_LongInteger = WorkOrderConcernsTable.WorkOrderConcernID_AutoNumber
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

    Private Sub FillWorkOrderIssuedPartsDataGridView()

        WorkOrderIssuedPartsSelectionOrder = " ORDER BY WorkOrderPartID_LongInteger "
        WorkOrderIssuedPartsFieldsToSelect =
" 
SELECT 
WorkOrderReceivedPartsTable.WorkOrderPartID_LongInteger, 
WorkOrderReceivedPartsTable.WorkOrderReceivedPartID_AutoNumber, 
ProductsPartsTable.ProductsPartID_Autonumber, 
ProductsPartsTable.ManufacturerPartNo_ShortText30Fld, 
ProductsPartsTable.ManufacturerDescription_ShortText250, 
WorkOrderReceivedPartsTable.ReceivedQuantity_Double, 
ProductsPartsTable.Unit_ShortText3, 
ProductPartsPackingsTable.QuantityPerPack_Double, 
ProductPartsPackingsTable.UnitOfTheQuantity_ShortText3
FROM ProductPartsPackingsTable RIGHT JOIN (StocksTable RIGHT JOIN (WorkOrderReceivedPartsTable LEFT JOIN ProductsPartsTable ON WorkOrderReceivedPartsTable.ProductPartID_LongInteger = ProductsPartsTable.ProductsPartID_Autonumber) ON StocksTable.ProductPartID_LongInteger = ProductsPartsTable.ProductsPartID_Autonumber) ON ProductPartsPackingsTable.ProductPartID_LongInteger = ProductsPartsTable.ProductsPartID_Autonumber
"

        MySelection = WorkOrderIssuedPartsFieldsToSelect & WorkOrderIssuedPartsSelectionFilter & WorkOrderIssuedPartsSelectionOrder

        JustExecuteMySelection()
        WorkOrderIssuedPartsRecordCount = RecordCount

        If WorkOrderIssuedPartsRecordCount > 0 Then
            WorkOrderIssuedPartsGroupBox.Visible = True
        Else
            WorkOrderIssuedPartsGroupBox.Visible = False
        End If
        WorkOrderIssuedPartsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If WorkOrderIssuedPartsRecordCount = 0 Then
            CurrentWorkOrderIssuedPartID = -1
        End If


        ' HERE AT ROW_ENTER, FillWorkOrderIssuedPartConcernsDataGridView is called and WorkOrderIssuedPartConcernsbOX IS ALREADY FORMATTED
        If Not WorkOrderIssuedPartsDataGridViewAlreadyFormated Then
            FormatWorkOrderIssuedPartsDataGridView()
        End If

        SetGroupBoxHeight(5, WorkOrderIssuedPartsRecordCount, WorkOrderIssuedPartsGroupBox, WorkOrderIssuedPartsDataGridView)
    End Sub
    Private Sub FormatWorkOrderIssuedPartsDataGridView()
        WorkOrderIssuedPartsDataGridViewAlreadyFormated = True
        WorkOrderIssuedPartsGroupBox.Width = 0
        For i = 0 To WorkOrderIssuedPartsDataGridView.Columns.GetColumnCount(0) - 1

            WorkOrderIssuedPartsDataGridView.Columns.Item(i).Visible = False
            Select Case WorkOrderIssuedPartsDataGridView.Columns.Item(i).Name
                Case "ManufacturerPartNo_ShortText30Fld"
                    WorkOrderIssuedPartsDataGridView.Columns.Item(i).HeaderText = "Manuf Part #"
                    WorkOrderIssuedPartsDataGridView.Columns.Item(i).Width = 150
                    WorkOrderIssuedPartsDataGridView.Columns.Item(i).Visible = True
                Case "ManufacturerDescription_ShortText250"
                    WorkOrderIssuedPartsDataGridView.Columns.Item(i).HeaderText = "Manuf Desc."
                    WorkOrderIssuedPartsDataGridView.Columns.Item(i).Width = 300
                    WorkOrderIssuedPartsDataGridView.Columns.Item(i).Visible = True
                Case "ReceivedQuantity_Double"
                    WorkOrderIssuedPartsDataGridView.Columns.Item(i).HeaderText = "Issued Qty"
                    WorkOrderIssuedPartsDataGridView.Columns.Item(i).Width = 70
                    WorkOrderIssuedPartsDataGridView.Columns.Item(i).Visible = True
                Case "Unit_ShortText3"
                    WorkOrderIssuedPartsDataGridView.Columns.Item(i).HeaderText = "Unit"
                    WorkOrderIssuedPartsDataGridView.Columns.Item(i).Width = 70
                    WorkOrderIssuedPartsDataGridView.Columns.Item(i).Visible = True
                Case "QuantityPerPack_Double"
                    WorkOrderIssuedPartsDataGridView.Columns.Item(i).HeaderText = "Quantity Per Pack"
                    WorkOrderIssuedPartsDataGridView.Columns.Item(i).Width = 80
                    WorkOrderIssuedPartsDataGridView.Columns.Item(i).Visible = True
                Case "UnitOfTheQuantity_ShortText3"
                    WorkOrderIssuedPartsDataGridView.Columns.Item(i).HeaderText = "Quantity Unit"
                    WorkOrderIssuedPartsDataGridView.Columns.Item(i).Width = 80
                    WorkOrderIssuedPartsDataGridView.Columns.Item(i).Visible = True
            End Select

            If WorkOrderIssuedPartsDataGridView.Columns.Item(i).Visible = True Then
                WorkOrderIssuedPartsGroupBox.Width = WorkOrderIssuedPartsGroupBox.Width + WorkOrderIssuedPartsDataGridView.Columns.Item(i).Width
            End If
        Next
        If WorkOrderIssuedPartsGroupBox.Width > VehicleManagementSystemForm.Width Then
            WorkOrderIssuedPartsGroupBox.Width = VehicleManagementSystemForm.Width - 4
        End If
        HorizontalCenter(WorkOrderIssuedPartsDataGridView, Me)
    End Sub
    Private Sub WorkOrderIssuedPartsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles WorkOrderIssuedPartsDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If WorkOrderIssuedPartsRecordCount = 0 Then Exit Sub

        CurrentWorkOrderIssuedPartsRow = e.RowIndex
        CurrentWorkOrderIssuedPartID = WorkOrderIssuedPartsDataGridView.Item("WorkOrderIssuedPartID_AutoNumber", CurrentWorkOrderIssuedPartsRow).Value

        FillField(CurrentWorkOrderIssuedPartStatus, WorkOrderIssuedPartsDataGridView.Item("WorkOrderIssuedPartStatus", CurrentWorkOrderIssuedPartsRow).Value)

        Select Case CurrentWorkOrderIssuedPartStatus
            Case ""
        End Select

    End Sub

    Private Sub AddNewPartNumber()
        ' WRONG THISSHOUD BE CALLING UPDATE CODEVEHICLEPARTNUN
    End Sub


    Private Sub CheckAndIssueThisPartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckStockAvailabilityToolStripMenuItem.Click
        ProductsPartsForm.PartDescriptionSearchTextBox.Text = WorkOrderRequestedPartsDataGridView.Item("SystemDesc_ShortText100Fld", CurrentWorkOrderRequestedPartsDataGridViewRow).Value
        ProductsPartsForm.VehicleFilterToolStripTextBox.Text = VehicleModelTextBox.Text
        ShowCalledForm(Me, ProductsPartsForm)

    End Sub
    Private Sub EditProductToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditPartDetailsToolStripMenuItem.Click
        EnableEdit()
    End Sub
    Private Sub EnableEdit()
        'ToOrderQuantityTextBox.Enabled = False
        If Val(ToIssueQuantityTextBox.Text) > 0 Then
            If MsgBox("Would you Like to change QUANTITIES ?", vbYesNoCancel) = MsgBoxResult.Yes Then
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
        If Not MsgBox("Would you Like to remove the specified Product ?", vbYesNoCancel) = MsgBoxResult.Yes Then
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
        FillWorkOrderRequestedPartsHeadersDataGridView()

    End Sub

    Private Sub QuantityGroupBox_VisibleChanged(sender As Object, e As EventArgs) Handles QuantityGroupBox.VisibleChanged
        If QuantityGroupBox.Visible = True Then
            If IsEmpty(ToOrderQuantityTextBox.Text) Then ToOrderQuantityTextBox.Text = ToIssueQuantityTextBox.Text
            EditPartDetailsToolStripMenuItem.Visible = False
            WorkOrderRequestedPartsHeadersDataGridView.Enabled = False
            WorkOrderRequestedPartsDataGridView.Enabled = False
            RequestForPurchaseGroupBox.Enabled = False
        Else
            EditPartDetailsToolStripMenuItem.Visible = True
            WorkOrderRequestedPartsHeadersDataGridView.Enabled = True
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
        FillWorkOrderRequestedPartsHeadersDataGridView()
    End Sub

    Private Sub PrintReleaseNotesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintReleaseNotesToolStripMenuItem.Click
        PrintReleaseNotesToolStripMenuItem.Visible = False
        PartsReleaseInfoGroupBox.Visible = True
        ReceivedByTextBox.Text = WorkOrderRequestedPartsHeadersDataGridView.Item("RequestedBy", CurrentWorkOrderPartsRequisitionsDataGridViewRow).Value
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
        FillWorkOrderRequestedPartsHeadersDataGridView()
    End Sub
End Class