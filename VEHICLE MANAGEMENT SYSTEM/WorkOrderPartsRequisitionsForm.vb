Imports Microsoft.Office.Interop.Excel

Public Class WorkOrderPartsRequisitionsForm
    Private WorkOrderRequestedPartsHeadersFieldsToSelect = ""
    Private WorkOrderRequestedPartsHeadersSelectionFilter = ""
    Private WorkOrderRequestedPartsHeadersSelectionOrder = ""
    Private WorkOrderRequestedPartsHeadersRecordCount As Integer = -1
    Private WorkOrderRequestedPartsHeadersDataGridViewAlreadyFormated = False
    Private CurrentWorkOrderRequestedPartsHeadersDataGridViewRow As Integer = -1
    Private CurrentWorkOrderRequestedPartsHeaderID As Integer = -1
    Private CurrentWorkOrderRequestedPartsHeadersStatusSelection = -1
    Private WorkOrderRequestedPartsHeaderStatus = ""

    Private WorkOrderRequestedPartsFieldsToSelect = ""
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
    Private CurrentWorkOrderIssuedPartStatus As String = ""
    Private WorkOrderIssuedPartsDataGridViewAlreadyFormated = False

    Private RequisitionsItemsFieldsToSelect = ""
    Private RequisitionsItemsTableLinks = ""
    Private RequisitionsItemsSelectionFilter = ""
    Private RequisitionsItemsSelectionOrder = ""
    Private RequisitionsItemsRecordCount As Integer = -1
    Private RequisitionsItemsDataGridViewAlreadyFormated = False
    Private CurrentRequisitionsItemsID As Integer = -1
    Private CurrentRequisitionsItemsDataGridViewRow As Integer = -1
    Private CurrentRequisitionsItemID = -1


    Private ReceivedByID = -1
    Private CurrentPartsSpecificationID = -1
    Private CurrentPartsRequisitionID = -1
    Private CurrentWorkOrderPartID As Integer = -1
    Private CurrentProductsPartID = -1
    Private CurrentQtyToIssue = -1
    Private CurrentQtyToOrder = -1
    Private CurrentMasterCodeBookId = -1
    Private SavedCallingForm As Form
    Private Sub WorkOrderRequestedPartsHeadersForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        SavedCallingForm = CallingForm
        Me.Text = "Parts for Issuance"
        CurrentWorkOrderRequestedPartsHeadersStatusSelection = 0
        SetWorkOrderRequestedPartsHeadersSelectionFilter(GetStatusIdFor("WorkOrderRequestedPartsHeadersTable", "Warehouse Outstanding", 1), 1, Me, "Warehouse Outstanding")
        SubmitRequisitionsForPurchaseToolStripMenuItem.Visible = True
        QuantityGroupBox.Top = (Me.Height - QuantityGroupBox.Height) / 2
        QuantityGroupBox.Left = (Me.Width - QuantityGroupBox.Width) / 2
    End Sub

    Private Sub WorkOrderRequestedPartsHeadersForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
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
                    Dim RecordFilter = " WHERE ProductsPartID_Autonumber =  " & CurrentProductsPartID.ToString
                    Dim SetCommand = " SET  Selected = True "
                    UpdateTable("ProductsPartsTable", SetCommand, RecordFilter)
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


        WorkOrderRequestedPartsHeadersFieldsToSelect = "
SELECT 
WorkOrdersTable.WorkOrderNumber_ShortText12, 
WorkOrderRequestedPartsHeadersTable.WorkOrderRequestedPartsHeaderNumber_ShortText12, 
WorkOrderRequestedPartsHeadersTable.WorkOrderRequestedPartsHeaderRevision_Integer, 
WorkOrderRequestedPartsHeadersTable.WorkOrderRequestedPartsHeaderDate_ShortDate, 
WorkOrderRequestedPartsHeadersTable.RequestedByID_LongInteger, 
WorkOrderRequestedPartsHeadersTable.WorkOrderID_LongInteger, 
WorkOrderRequestedPartsHeadersTable.WorkOrderRequestedPartsHeaderID_AutoNumber, 
VehicleDescription.VehicleDescription,
StatusesTable.StatusSequence_LongInteger, StatusesTable.StatusText_ShortText25
FROM ((((WorkOrderRequestedPartsHeadersTable LEFT JOIN WorkOrdersTable ON WorkOrderRequestedPartsHeadersTable.WorkOrderID_LongInteger = WorkOrdersTable.WorkOrderID_AutoNumber) LEFT JOIN ServicedVehiclesTable ON WorkOrdersTable.ServicedVehicleID_LongInteger = ServicedVehiclesTable.ServicedVehicleID_AutoNumber) LEFT JOIN PersonnelTable ON WorkOrderRequestedPartsHeadersTable.RequestedByID_LongInteger = PersonnelTable.PersonnelID_AutoNumber) LEFT JOIN StatusesTable ON WorkOrderRequestedPartsHeadersTable.WorkOrderRequestedPartsHeaderStatusID_Integer = StatusesTable.StatusID_Autonumber) LEFT JOIN VehicleDescription ON ServicedVehiclesTable.VehicleID_LongInteger = VehicleDescription.VehicleID_AutoNumber
"
        WorkOrderRequestedPartsHeadersSelectionOrder = " ORDER BY WorkOrderRequestedPartsHeaderID_AutoNumber DESC "

        MySelection = WorkOrderRequestedPartsHeadersFieldsToSelect & WorkOrderRequestedPartsHeadersSelectionFilter & WorkOrderRequestedPartsHeadersSelectionOrder

        JustExecuteMySelection()
        WorkOrderRequestedPartsHeadersRecordCount = RecordCount
        WorkOrderRequestedPartsHeadersDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        Dim RecordsToDisplay = 8
        If WorkOrderRequestedPartsHeadersRecordCount < RecordsToDisplay Then RecordsToDisplay = WorkOrderRequestedPartsHeadersRecordCount
        WorkOrderRequestedPartsHeadersDataGridView.Height = WorkOrderRequestedPartsHeadersDataGridView.ColumnHeadersHeight + (DataGridViewRowHeight * (RecordsToDisplay + 1))

        If Not WorkOrderRequestedPartsHeadersDataGridViewAlreadyFormated Then
            FormatWorkOrderRequestedPartsHeadersDataGridView()
        End If

    End Sub
    Private Sub FormatWorkOrderRequestedPartsHeadersDataGridView()
        WorkOrderRequestedPartsHeadersDataGridViewAlreadyFormated = True
        WorkOrderRequestedPartsHeadersDataGridView.Width = 0
        For i = 0 To WorkOrderRequestedPartsHeadersDataGridView.Columns.GetColumnCount(0) - 1

            WorkOrderRequestedPartsHeadersDataGridView.Columns.Item(i).Visible = False

            Select Case WorkOrderRequestedPartsHeadersDataGridView.Columns.Item(i).HeaderText

                Case "VehicleDescription"
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
        '      Me.Location = New Point(Me.Location.X, 55)
        Me.Left = VehicleManagementSystemForm.Left

        If WorkOrderRequestedPartsHeadersDataGridView.Width > Me.Width Then
            WorkOrderRequestedPartsHeadersDataGridView.Width = Me.Width - 8
        End If

        WorkOrderRequestedPartsHeadersDataGridView.Left = 5
        WorkOrderRequestedPartsHeadersDataGridView.Top = WorkOrderPartsMenuStrip.Top + WorkOrderPartsMenuStrip.Height

        WorkOrderRequestedPartsDataGridView.Top = WorkOrderRequestedPartsHeadersDataGridView.Top + WorkOrderRequestedPartsHeadersDataGridView.Height
        WorkOrderRequestedPartsDataGridView.Left = (Me.Width - WorkOrderRequestedPartsDataGridView.Width) / 2

        RequisitionsItemsDataGridView.Left = 5
    End Sub
    Private Sub WorkOrderRequestedPartsHeadersDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles WorkOrderRequestedPartsHeadersDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If WorkOrderRequestedPartsHeadersRecordCount = 0 Then Exit Sub
        CurrentWorkOrderRequestedPartsHeadersDataGridViewRow = e.RowIndex

        CurrentWorkOrderRequestedPartsHeaderID = WorkOrderRequestedPartsHeadersDataGridView.Item("WorkOrderRequestedPartsHeaderID_AutoNumber", CurrentWorkOrderRequestedPartsHeadersDataGridViewRow).Value
        Dim CurrentWorkOrderRequestedPartsHeaderstatusSequence = WorkOrderRequestedPartsHeadersDataGridView.Item("StatusSequence_LongInteger", CurrentWorkOrderRequestedPartsHeadersDataGridViewRow).Value
        WorkOrderRequestedPartsHeaderStatus = WorkOrderRequestedPartsHeadersDataGridView.Item("StatusText_ShortText25", CurrentWorkOrderRequestedPartsHeadersDataGridViewRow).Value
        CurrentWorkOrderID = WorkOrderRequestedPartsHeadersDataGridView.Item("WorkOrderID_LongInteger", CurrentWorkOrderRequestedPartsHeadersDataGridViewRow).Value
        VehicleModelTextBox.Text = WorkOrderRequestedPartsHeadersDataGridView.Item("VehicleDescription", CurrentWorkOrderRequestedPartsHeadersDataGridViewRow).Value
        EditPartDetailsToolStripMenuItem.Visible = False
        DeleteProductToolStripMenuItem.Visible = False
        SubmitRequisitionsForPurchaseToolStripMenuItem.Visible = False


        Select Case WorkOrderRequestedPartsHeaderStatus
            Case "Draft Requisition"
                SubmitRequisitionsForPurchaseToolStripMenuItem.Text = "Submit Requisitions for Purchase"
                SubmitRequisitionsForPurchaseToolStripMenuItem.Visible = False
            Case "Warehouse Outstanding"
        End Select


        '' SETUP CURRENT VEHICLE INFORMATIONS
        SetVehicleInformations()    'REQUIRES CurrentWorkOrderID

        WorkOrderRequestedPartsSelectionFilter = " WHERE WorkOrderRequestedPartsHeaderID_AutoNumber = " & CurrentWorkOrderRequestedPartsHeaderID.ToString
        FillWorkOrderRequestedPartsDataGridView()
        'FOLLOWING COMMENTED LINES SET RequisitionsItemsSelectionFilter REMAINED = ""
        'SOLUTION: MOVED TO WorkOrderRequestedPartsDataGridView.RowEnter
        RequisitionsItemsSelectionFilter = " WHERE WorkOrderID_LongInteger = " & CurrentWorkOrderID
        FillRequisitionsItemsDataGridView()

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
SELECT MasterCodeBookTable.SystemDesc_ShortText100Fld, PartsSpecificationsTable.PartSpecifications_ShortText255, ProductsPartsTable.ManufacturerPartNo_ShortText30Fld, ProductsPartsTable.ManufacturerDescription_ShortText250, StocksTable.QuantityInStock_Double, WorkOrderRequestedPartsTable.RequestedQuantity_Double, RequisitionsItemsTable.RequisitionQuantity_Double, BrandsTable.BrandName_ShortText20, StocksTable.Location_ShortText10, ProductsPartsTable.ProductDescription_ShortText250, WorkOrderRequestedPartsTable.WorkOrderPartID_LongInteger, WorkOrderRequestedPartsTable.ProductPartID_LongInteger, RequisitionsItemsTable.RequisitionsItemID_AutoNumber, RequisitionsItemsTable.RequisitionItemStatusID_LongInteger, WorkOrderRequestedPartsTable.WorkOrderRequestedPartID_AutoNumber, WorkOrderRequestedPartsTable.WorkOrderRequestedPartsHeaderID_LongInteger, MasterCodeBookTable.MasterCodeBookID_Autonumber, WorkOrderPartsTable.WorkOrderPartID_AutoNumber, StatusesTable.StatusText_ShortText25, WorkOrderRequestedPartsTable.WorkOrderRequestedPartStatus_Integer, StatusesTable.StatusID_Autonumber, CodeVehiclePartsSpecificationsRelationsTable.CodeVehicleID_LongInteger, CodeVehiclePartsSpecificationsRelationsTable.PartsSpecificationID_LongInteger
FROM ((((((WorkOrderRequestedPartsTable LEFT JOIN WorkOrderRequestedPartsHeadersTable ON WorkOrderRequestedPartsTable.[WorkOrderRequestedPartsHeaderID_LongInteger] = WorkOrderRequestedPartsHeadersTable.[WorkOrderRequestedPartsHeaderID_AutoNumber]) LEFT JOIN (WorkOrderPartsTable LEFT JOIN MasterCodeBookTable ON WorkOrderPartsTable.MasterCodeBookID_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) ON WorkOrderRequestedPartsTable.WorkOrderPartID_LongInteger = WorkOrderPartsTable.WorkOrderPartID_AutoNumber) LEFT JOIN (StocksTable RIGHT JOIN (ProductsPartsTable LEFT JOIN BrandsTable ON ProductsPartsTable.BrandID_LongInteger = BrandsTable.BrandID_Autonumber) ON StocksTable.ProductPartID_LongInteger = ProductsPartsTable.ProductsPartID_Autonumber) ON WorkOrderRequestedPartsTable.ProductPartID_LongInteger = ProductsPartsTable.ProductsPartID_Autonumber) LEFT JOIN StatusesTable ON WorkOrderRequestedPartsTable.[WorkOrderRequestedPartStatus_Integer] = StatusesTable.StatusID_Autonumber) LEFT JOIN CodeVehiclePartsSpecificationsRelationsTable ON WorkOrderPartsTable.CodeVehicleID_LongInteger = CodeVehiclePartsSpecificationsRelationsTable.CodeVehicleID_LongInteger) LEFT JOIN PartsSpecificationsTable ON CodeVehiclePartsSpecificationsRelationsTable.PartsSpecificationID_LongInteger = PartsSpecificationsTable.PartsSpecificationID_AutoNumber) LEFT JOIN RequisitionsItemsTable ON WorkOrderRequestedPartsTable.WorkOrderRequestedPartID_AutoNumber = RequisitionsItemsTable.WorkOrderRequestedPartID_LongInteger
"
        MySelection = WorkOrderRequestedPartsFieldsToSelect & WorkOrderRequestedPartsSelectionFilter & WorkOrderRequestedPartsSelectionOrder
        JustExecuteMySelection()

        WorkOrderRequestedPartsRecordCount = RecordCount
        WorkOrderRequestedPartsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If WorkOrderRequestedPartsRecordCount > 0 Then
            WorkOrderRequestedPartsDataGridView.Visible = True
            AvailableStocksGroupBox.Visible = True
        Else
            WorkOrderRequestedPartsDataGridView.Visible = False
            AvailableStocksGroupBox.Visible = False
            Exit Sub
        End If
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
        AvailableStocksGroupBox.Top = WorkOrderRequestedPartsDataGridView.Top + WorkOrderRequestedPartsDataGridView.Height
        RequestForPurchaseGroupBox.Top = AvailableStocksGroupBox.Top + AvailableStocksDataGridView.Height
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
        CurrentRequisitionsItemID = WorkOrderRequestedPartsDataGridView.Item("RequisitionsItemID_AutoNumber", CurrentWorkOrderRequestedPartsDataGridViewRow).Value
        Dim CurrentPartStatus = WorkOrderRequestedPartsDataGridView.Item("StatusText_ShortText25", CurrentWorkOrderRequestedPartsDataGridViewRow).Value

        CurrentWorkOrderRequestedPartID = WorkOrderRequestedPartsDataGridView.Item("WorkOrderRequestedPartID_AutoNumber", CurrentWorkOrderRequestedPartsDataGridViewRow).Value
        CurrentWorkOrderPartID = WorkOrderRequestedPartsDataGridView.Item("WorkOrderPartID_Autonumber", CurrentWorkOrderRequestedPartsDataGridViewRow).Value
        CurrentMasterCodeBookId = WorkOrderRequestedPartsDataGridView.Item("MasterCodeBookID_Autonumber", CurrentWorkOrderRequestedPartsDataGridViewRow).Value
        FillField(CurrentCodeVehicleID, WorkOrderRequestedPartsDataGridView.Item("CodeVehicleID_LongInteger", CurrentWorkOrderRequestedPartsDataGridViewRow).Value)
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

        If WorkOrderIssuedPartsRecordCount = 0 Then
            If IsNotEmpty(CurrentPartsSpecificationID) Then
                AvailableStocksSelectionFilter = " WHERE PartsSpecificationID_AutoNumber = " & CurrentPartsSpecificationID.ToString
            Else
                AvailableStocksSelectionFilter = " WHERE ProductsPartsTable.MasterCodeBookID_LongInteger = " & CurrentMasterCodeBookId.ToString
            End If
            FillAvailableStocksDataGridView()
        End If


        If IsNotEmpty(WorkOrderRequestedPartsDataGridView.Item("RequestedQuantity_Double", CurrentWorkOrderRequestedPartsDataGridViewRow).Value) Then
            ToIssueQuantityTextBox.Text = WorkOrderRequestedPartsDataGridView.Item("RequestedQuantity_Double", CurrentWorkOrderRequestedPartsDataGridViewRow).Value
        End If
        ' FOLLOWING TESTS IF THE SPECIFIC PRODUCT IS MENTIONED ON THE REQUESITION 
        ' CheckStockAvailability IS NOT NEEDED SINCE IT IS ALREADY SHOWN ON SCREEN
        ' JUST EDIT THE QUANTITIES FOR PURCHASE IF NEEDED ELSE RELEASE THE NEEDED QWUANTITY

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
PartsSpecificationsTable.PartSpecifications_ShortText255, 
ProductsPartsTable.ManufacturerPartNo_ShortText30Fld, 
ProductsPartsTable.ManufacturerDescription_ShortText250, 
StocksTable.StockID_Autonumber,
StocksTable.QuantityInStock_Double,
ProductsPartsTable.Unit_ShortText3, 
ProductPartsPackingsTable.QuantityPerPack_Double, 
ProductPartsPackingsTable.UnitOfTheQuantity_ShortText3, 
ProductPartsPackingsTable.UnitOfThePacking_ShortText3, 
StocksTable.Location_ShortText10
FROM StocksTable LEFT JOIN (ProductPartsPackingsTable RIGHT JOIN (ProductsPartsTable LEFT JOIN PartsSpecificationsTable ON ProductsPartsTable.PartsSpecificationID_LongInteger = PartsSpecificationsTable.PartsSpecificationID_AutoNumber) ON ProductPartsPackingsTable.ProductPartID_LongInteger = ProductsPartsTable.ProductsPartID_Autonumber) ON StocksTable.ProductPartID_LongInteger = ProductsPartsTable.ProductsPartID_Autonumber
"

        MySelection = AvailableStocksFieldsToSelect & AvailableStocksSelectionFilter & AvailableStocksSelectionOrder

        JustExecuteMySelection()
        AvailableStocksRecordCount = RecordCount

        AvailableStocksGroupBox.Top = WorkOrderRequestedPartsDataGridView.Top + WorkOrderRequestedPartsDataGridView.Height
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
                Case "UnitOfThePacking_ShortText3"
                    AvailableStocksDataGridView.Columns.Item(i).HeaderText = "Packing Unit"
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
        CurrentAvailableStockID = AvailableStocksDataGridView.Item("StockID_Autonumber", CurrentAvailableStocksRow).Value


    End Sub
    Private Sub FillRequisitionsItemsDataGridView()
        RequisitionsItemsFieldsToSelect =
"
SELECT 
WorkOrderPartsTable.WorkOrderID_LongInteger, 
MasterCodeBookTable.SystemDesc_ShortText100Fld, 
ProductsPartsTable.ManufacturerDescription_ShortText250, 
ProductsPartsTable.ManufacturerPartNo_ShortText30Fld, 
RequisitionsItemsTable.RequisitionsItemID_AutoNumber, 
RequisitionsItemsTable.WorkOrderRequestedPartID_LongInteger,
RequisitionsItemsTable.RequisitionQuantity_Double, 
RequisitionsItemsTable.ProductPartID_LongInteger, 
RequisitionsItemsTable.RequisitionItemStatusID_LongInteger, 
ProductsPartsTable.ProductDescription_ShortText250, 
BrandsTable.BrandName_ShortText20, 
StatusesTable.StatusText_ShortText25 
FROM ((RequisitionsItemsTable LEFT JOIN (((WorkOrderRequestedPartsTable LEFT JOIN ProductsPartsTable ON WorkOrderRequestedPartsTable.ProductPartID_LongInteger = ProductsPartsTable.ProductsPartID_Autonumber) LEFT JOIN BrandsTable ON ProductsPartsTable.BrandID_LongInteger = BrandsTable.BrandID_Autonumber) LEFT JOIN (WorkOrderPartsTable LEFT JOIN MasterCodeBookTable ON WorkOrderPartsTable.MasterCodeBookID_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) ON WorkOrderRequestedPartsTable.WorkOrderPartID_LongInteger = WorkOrderPartsTable.WorkOrderPartID_AutoNumber) ON RequisitionsItemsTable.WorkOrderRequestedPartID_LongInteger = WorkOrderRequestedPartsTable.[WorkOrderRequestedPartID_AutoNumber]) LEFT JOIN RequisitionsTable ON RequisitionsItemsTable.RequisitionID_LongInteger = RequisitionsTable.RequisitionID_AutoNumber) LEFT JOIN StatusesTable ON RequisitionsItemsTable.RequisitionItemStatusID_LongInteger = StatusesTable.StatusID_Autonumber
"

        MySelection = RequisitionsItemsFieldsToSelect & RequisitionsItemsSelectionFilter & RequisitionsItemsSelectionOrder

        JustExecuteMySelection()

        RequisitionsItemsRecordCount = RecordCount
        RequisitionsItemsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If RequisitionsItemsRecordCount > 0 Then
            RequestForPurchaseGroupBox.Visible = True
            SubmitRequisitionsForPurchaseToolStripMenuItem.Visible = True
        Else
            RequestForPurchaseGroupBox.Visible = False
            SubmitRequisitionsForPurchaseToolStripMenuItem.Visible = False
            CurrentRequisitionsItemID = -1
        End If
        If Not RequisitionsItemsDataGridViewAlreadyFormated Then
            RequisitionsItemsDataGridViewAlreadyFormated = True
            FormatRequisitionsItemsDataGridView()
        End If
        Dim RecordsToDisplay = 10
        If RequisitionsItemsRecordCount < RecordsToDisplay Then RecordsToDisplay = RequisitionsItemsRecordCount
        RequisitionsItemsDataGridView.Height = RequisitionsItemsDataGridView.ColumnHeadersHeight + (DataGridViewRowHeight * (RecordsToDisplay + 1))
        RequestForPurchaseGroupBox.Width = Me.Width - 6
        RequestForPurchaseGroupBox.Left = (Me.Width - RequestForPurchaseGroupBox.Width) / 2
    End Sub
    Private Sub FormatRequisitionsItemsDataGridView()
        RequisitionsItemsDataGridView.Width = 0

        For i = 0 To RequisitionsItemsDataGridView.Columns.GetColumnCount(0) - 1

            RequisitionsItemsDataGridView.Columns.Item(i).Visible = False

            Select Case RequisitionsItemsDataGridView.Columns.Item(i).Name
                Case "SystemDesc_ShortText100Fld"
                    RequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "SystemDesc"
                    RequisitionsItemsDataGridView.Columns.Item(i).Width = 300
                    RequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "ManufacturerDescription_ShortText250"
                    RequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "ManufacturerDescription"
                    RequisitionsItemsDataGridView.Columns.Item(i).Width = 300
                    RequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "ManufacturerPartNo_ShortText30Fld"
                    RequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Part #"
                    RequisitionsItemsDataGridView.Columns.Item(i).Width = 150
                    RequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "RequisitionQuantity_Double"
                    RequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "QTY"
                    RequisitionsItemsDataGridView.Columns.Item(i).Width = 70
                    RequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "BrandName_ShortText20"
                    RequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Brand"
                    RequisitionsItemsDataGridView.Columns.Item(i).Width = 150
                    RequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "StatusText_ShortText25"
                    RequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Status"
                    RequisitionsItemsDataGridView.Columns.Item(i).Width = 150
                    RequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "ProductDescription_ShortText250"
                    RequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "excel"
                    RequisitionsItemsDataGridView.Columns.Item(i).Width = 200
                    RequisitionsItemsDataGridView.Columns.Item(i).Visible = True

            End Select
            If RequisitionsItemsDataGridView.Columns.Item(i).Visible = True Then
                RequisitionsItemsDataGridView.Width = RequisitionsItemsDataGridView.Width + RequisitionsItemsDataGridView.Columns.Item(i).Width
            End If
        Next
        If RequisitionsItemsDataGridView.Width > Me.Width Then
            RequisitionsItemsDataGridView.Width = Me.Width - 8
        End If
    End Sub

    Private Sub RequisitionsItemsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles RequisitionsItemsDataGridView.RowEnter
        CurrentRequisitionsItemsID = -1
        If e.RowIndex < 0 Then Exit Sub
        If RequisitionsItemsRecordCount = 0 Then Exit Sub
        CurrentRequisitionsItemsDataGridViewRow = e.RowIndex

        ' CurrentWorkOrderRequestedPartID = RequisitionsItemsDataGridView.Item("WorkOrderRequestedPartID_AutoNumber", CurrentRequisitionsItemsDataGridViewRow).Value
        '        CurrentProductsPartID = RequisitionsItemsDataGridView.Item("ProductsPartID_Autonumber", CurrentRequisitionsItemsDataGridViewRow).Value
        ' CurrentRequisitionsItemID = RequisitionsItemsDataGridView.Item("RequisitionsItemID_AutoNumber", CurrentRequisitionsItemsDataGridViewRow).Value
        ' RequestedQuantityTextBox.Text = RequisitionsItemsDataGridView.Item("Quantity_Integer", CurrentRequisitionsItemsDataGridViewRow).Value
        ' AvailableQuantityTextBox.Text = "0"
        ' ToOrderQuantityTextBox.Text = "0"
        ' AvailableQuantityTextBox.Text = NotNull(RequisitionsItemsDataGridView.Item("QuantityInStock_Double", CurrentRequisitionsItemsDataGridViewRow).Value)
        ' ToIssueQuantityTextBox.Text = RequisitionsItemsDataGridView.Item("RequestedQuantity_Double", CurrentRequisitionsItemsDataGridViewRow).Value
        ToOrderQuantityTextBox.Text = RequisitionsItemsDataGridView.Item("RequisitionQuantity_Double", CurrentRequisitionsItemsDataGridViewRow).Value
        ' CurrentQtyToIssue = Val(ToIssueQuantityTextBox.Text)
        ' CurrentQtyToOrder = Val(ToOrderQuantityTextBox.Text)


    End Sub

    Private Sub FillWorkOrderIssuedPartsDataGridView()

        WorkOrderIssuedPartsSelectionOrder = " ORDER BY WorkOrderPartID_LongInteger "
        WorkOrderIssuedPartsFieldsToSelect =
" 
SELECT 
WorkOrderReceivedPartsTable.WorkOrderPartID_LongInteger, 
WorkOrderReceivedPartsTable.WorkOrderReceivedPartID_AutoNumber, 
WorkOrderReceivedPartsTable.WorkOrderReceivedPartStatusID_LongInteger, 
ProductsPartsTable.ProductsPartID_Autonumber, 
ProductsPartsTable.ManufacturerPartNo_ShortText30Fld, 
ProductsPartsTable.ManufacturerDescription_ShortText250, 
WorkOrderReceivedPartsTable.ReceivedQuantity_Double, 
ProductsPartsTable.Unit_ShortText3, 
ProductPartsPackingsTable.QuantityPerPack_Double, 
ProductPartsPackingsTable.UnitOfTheQuantity_ShortText3
FROM WorkOrderReceivedPartsTable LEFT JOIN (ProductPartsPackingsTable RIGHT JOIN (StocksTable RIGHT JOIN ProductsPartsTable ON StocksTable.ProductPartID_LongInteger = ProductsPartsTable.ProductsPartID_Autonumber) ON ProductPartsPackingsTable.ProductPartID_LongInteger = ProductsPartsTable.ProductsPartID_Autonumber) ON WorkOrderReceivedPartsTable.ProductPartID_LongInteger = ProductsPartsTable.ProductsPartID_Autonumber
"

        MySelection = WorkOrderIssuedPartsFieldsToSelect & WorkOrderIssuedPartsSelectionFilter & WorkOrderIssuedPartsSelectionOrder

        JustExecuteMySelection()
        WorkOrderIssuedPartsRecordCount = RecordCount

        If WorkOrderIssuedPartsRecordCount > 0 Then
            'why this
            CurrentWorkOrderIssuedPartID = -1
            WorkOrderIssuedPartsGroupBox.Visible = True
        Else
            WorkOrderIssuedPartsGroupBox.Visible = False
        End If
        WorkOrderIssuedPartsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If WorkOrderIssuedPartsRecordCount = 0 Then
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
        CurrentWorkOrderIssuedPartID = WorkOrderIssuedPartsDataGridView.Item("WorkOrderReceivedPartID_AutoNumber", CurrentWorkOrderIssuedPartsRow).Value

        FillField(CurrentWorkOrderIssuedPartStatus, WorkOrderIssuedPartsDataGridView.Item("WorkOrderReceivedPartStatusID_LongInteger", CurrentWorkOrderIssuedPartsRow).Value)

        Select Case CurrentWorkOrderIssuedPartStatus
            Case ""
        End Select

    End Sub

    Private Sub AddNewPartNumber()
        ' WRONG THISSHOUD BE CALLING UPDATE CODEVEHICLEPARTNUN
    End Sub


    Private Sub CheckAndIssueThisPartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckStockAvailabilityToolStripMenuItem.Click
        ProductsPartsForm.PartDescriptionSearchTextBox.Text = WorkOrderRequestedPartsDataGridView.Item("SystemDesc_ShortText100Fld", CurrentWorkOrderRequestedPartsDataGridViewRow).Value
        ProductsPartsForm.VehicleModelSearchTextBox.Text = VehicleModelTextBox.Text
        ProductsPartsForm.CurrentVehicleID = CurrentVehicleID
        Tunnel2 = CurrentMasterCodeBookId

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
                    MySelection = " UPDATE WorkOrderPartsRequisitionsTable  " &
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
                            RequisitionStatus_Integer 
                            "
        Dim FieldsData =
                            Chr(34) & DateString & Chr(34) & ", " &
                            CurrentPersonelID.ToString & "," &
                            CurrentVehicleID.ToString & "," &
                            GetStatusIdFor("RequisitionsTable").ToString

        CurrentPartsRequisitionID = InsertNewRecord("RequisitionsTable", FieldsToUpdate, FieldsData)

        MsgBox("Modifications below is not yet testED, referenced vehicle is created")
        'CREATE vehicle record here
        FieldsToUpdate = " RequisitionsID_LongInteger, 
                           VehicleID_LongInteger "
        FieldsData = CurrentPartsRequisitionID & ", " &
                     CurrentVehicleID.ToString

        Dim xxCurrentPartsRequisitionID = InsertNewRecord("VehicleReferencesForRequisitionsTable", FieldsToUpdate, FieldsData)

        'ALL TEMPORARY ITEMS IN RequisitionsItemsTable WILL THEN BE MARKED FINAL REPLACING THE RequisitionID_LongInteger
        ' WITH THE NEWLY CREATED PartsRequisitionsHeader

        For i = 0 To RequisitionsItemsRecordCount - 1
            CurrentRequisitionsItemID = RequisitionsItemsDataGridView.Item("RequisitionsItemID_AutoNumber", i).Value

            MySelection = " UPDATE RequisitionsItemsTable  " &
                              " SET RequisitionID_LongInteger = " & CurrentPartsRequisitionID.ToString & ", " &
                              " RequisitionItemStatusID_LongInteger = " & GetStatusIdFor("RequisitionsItemsTable", "Draft Requisition").ToString &
                              " WHERE RequisitionsItemID_AutoNumber = " & CurrentRequisitionsItemID.ToString
            JustExecuteMySelection()
            CurrentWorkOrderRequestedPartID = RequisitionsItemsDataGridView.Item("WorkOrderRequestedPartID_LongInteger", i).Value
            MySelection = " UPDATE WorkOrderRequestedPartsTable  " &
                                          " SET WorkOrderRequestedPartStatus_Integer = " & GetStatusIdFor("WorkOrderRequestedPartsTable", "Procurement Outstanding").ToString &
                                          " WHERE WorkOrderRequestedPartID_AutoNumber = " & CurrentWorkOrderRequestedPartID.ToString
            JustExecuteMySelection()
        Next
        MySelection = " UPDATE WorkOrderRequestedPartsHeadersTable  " &
                              " SET WorkOrderRequestedPartsHeaderStatusID_Integer = " & GetStatusIdFor("WorkOrderRequestedPartsHeadersTable", "Procurement Outstanding").ToString &
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
                UpdateWorkOrderPartsRequisitionsTable()
            End If
        End If
        If Val(ToOrderQuantityTextBox.Text) <> NotNull(WorkOrderRequestedPartsDataGridView.Item("RequisitionQuantity_Double", CurrentWorkOrderRequestedPartsDataGridViewRow).Value) Then
            If Val(ToOrderQuantityTextBox.Text) > 0 Then
                UpdateRequisitionsItemsTable()
            Else
                If MsgBox("Remove this item?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    MySelection = " DELETE FROM RequisitionsItemsTable WHERE RequisitionsItemID_AutoNumber =  " & CurrentRequisitionsItemID
                    JustExecuteMySelection()
                    FillRequisitionsItemsDataGridView()
                    If RequisitionsItemsRecordCount = 0 Then
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
        FillRequisitionsItemsDataGridView()

    End Sub
    Private Sub UpdateRequisitionsItemsTable()

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
                MsgBox("following update was not yet tested")
                Dim RecordFilter = " WHERE ProductsPartID_Autonumber =  " & CurrentProductsPartID.ToString
                Dim SetCommand = " SET  Selected = True "
                UpdateTable("ProductsPartsTable", SetCommand, RecordFilter)

            End If
        End If

        'IS THERE ALREADY REFERENCED RECORD IN THE RequisitionsItemsTable?
        ' CHECK IF THERE IS ALREADY A CORRESPONDING RECORD  IN THE RequisitiosItemsTable and is flagged active (1)
        Dim InsertFlag = False
        If IsNotEmpty(CurrentRequisitionsItemID) Then
            xxFilter = " WHERE RequisitionsItemID_AutoNumber = " & CurrentRequisitionsItemID.ToString

            MySelection = " SELECT * FROM RequisitionsItemsTable " & xxFilter

            JustExecuteMySelection()

            If RecordCount > 0 Then
                If Val(ToOrderQuantityTextBox.Text) = 0 Then
                    If MsgBox("You reset the value to order to 0, Do you want to remove this order ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        MySelection = " RequisitionsItemsTable " & xxFilter
                    End If
                Else
                    MySelection = " UPDATE RequisitionsItemsTable " &
                                    " SET RequisitionID_LongInteger = " & CurrentPartsRequisitionID.ToString & ", " &
                                    " ProductPartID_LongInteger = " & CurrentProductsPartID.ToString & ", " &
                                    " RequisitionItemStatusID_LongInteger = " & GetStatusIdFor("RequisitionsItemsTable", "Draft Requisition").ToString & ", " &
                                    " RequisitionQuantity_Double = " & ToOrderQuantityTextBox.Text & xxFilter
                    JustExecuteMySelection()
                    Dim RecordFilter = " WHERE ProductsPartID_Autonumber =  " & CurrentProductsPartID.ToString
                    Dim SetCommand = " SET  Selected = True "
                    UpdateTable("ProductsPartsTable", SetCommand, RecordFilter)
                End If
            Else
                InsertFlag = True
            End If
        Else
            'note RequisitionID_LongInteger is initially set to -1
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
                                       " RequisitionID_LongInteger, " &
                                       " ProductPartID_LongInteger, " &
                                       " RequisitionQuantity_Double, " &
                                       " WorkOrderRequestedPartID_LongInteger, " &
                                       " RequisitionItemStatusID_LongInteger "
        Dim FieldsData =
                                        CurrentWorkOrderRequestedPartsHeaderID.ToString & "," &
                                        CurrentProductsPartID.ToString & "," &
                                        ToOrderQuantityTextBox.Text & "," &
                                        CurrentWorkOrderRequestedPartID.ToString & "," &
                                        GetStatusIdFor("RequisitionsItemsTable")
        CurrentRequisitionsItemID = InsertNewRecord("RequisitionsItemsTable", FieldsToUpdate, FieldsData)
        Dim RecordFilter = " WHERE ProductsPartID_Autonumber =  " & CurrentProductsPartID.ToString
        Dim SetCommand = " SET  Selected = True "
        UpdateTable("ProductsPartsTable", SetCommand, RecordFilter)

        FillRequisitionsItemsDataGridView()
        RequisitionsItemsDataGridView.Rows(RecordCount - 1).Selected = True
        MySelection = " UPDATE WorkOrderRequestedPartsHeadersTable " &
                              " SET WorkOrderRequestedPartsHeaderStatusID_Integer = " & GetStatusIdFor("WorkOrderRequestedPartsHeadersTable", "Draft Requisition") &
                              " WHERE WorkOrderRequestedPartsHeaderID_AutoNumber = " & CurrentWorkOrderRequestedPartsHeaderID
        JustExecuteMySelection()
    End Sub
    Private Sub UpdateWorkOrderPartsRequisitionsTable()
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
        MsgBox("following update was not yet tested")
        Dim RecordFilter = " WHERE ProductsPartID_Autonumber =  " & CurrentProductsPartID.ToString
        Dim SetCommand = " SET  Selected = True "
        UpdateTable("ProductsPartsTable", SetCommand, RecordFilter)
    End Sub
    Private Sub OutstandingRequisitionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OutstandingRequisitionsToolStripMenuItem.Click
        SetWorkOrderRequestedPartsHeadersSelectionFilter(GetStatusIdFor("Procurement Outstanding"), 1, Me, "Outstanding Requisitions")
    End Sub

    Private Sub DraftRequisitiosForPurchaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DraftRequisitiosForPurchaseToolStripMenuItem.Click
        SetWorkOrderRequestedPartsHeadersSelectionFilter(GetStatusIdFor("Draft Requisition"), 2, Me, "Draft Requisition")
    End Sub
    Private Sub AllPurchaseOrdersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SubmittedRequisitionsToolStripMenuItem.Click
        SetWorkOrderRequestedPartsHeadersSelectionFilter(GetStatusIdFor("Procurement Outstanding"), 3, Me, "Submitted Requisitions")
    End Sub

    Private Sub PrintPurchaseOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReOrderedToolStripMenuItem.Click
        SetWorkOrderRequestedPartsHeadersSelectionFilter(GetStatusIdFor("Re-ordered"), 2, Me, "Re-ordered")
    End Sub

    Private Sub ReorderedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PartiallyDeliveredToolStripMenuItem.Click
        SetWorkOrderRequestedPartsHeadersSelectionFilter(GetStatusIdFor("Partially Delivered"), 2, Me, "Partially Delivered")
    End Sub

    Private Sub CompletelyReceivedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompletelyDeliveredToolStripMenuItem.Click
        SetWorkOrderRequestedPartsHeadersSelectionFilter(GetStatusIdFor("Completely Delivered"), 2, Me, "Completely Delivered")
    End Sub

    Private Sub FinalizedPurchaseOrdersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PartiallyIssuedToolStripMenuItem.Click
        SetWorkOrderRequestedPartsHeadersSelectionFilter(GetStatusIdFor("Partially Issued"), 2, Me, "Partially Issued")
    End Sub

    Private Sub CompletelyIssuedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompletelyIssuedToolStripMenuItem.Click
        SetWorkOrderRequestedPartsHeadersSelectionFilter(GetStatusIdFor("Completely Issued"), 2, Me, "Completely Issued")
    End Sub

    Private Sub AllPartsRequisitionsForIssuanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllPartsRequisitionsForIssuanceToolStripMenuItem.Click
        SetWorkOrderRequestedPartsHeadersSelectionFilter(GetStatusIdFor("Used"), 3, Me, "ALL REQUISITIONS")
    End Sub
    Private Sub SetWorkOrderRequestedPartsHeadersSelectionFilter(PassedStatusSequence As Integer, PassedStatusSequenceCondition As Integer, PassedForm As Form, FormHeaderText As String)
        WorkOrderRequestedPartsHeadersSelectionFilter = SetupTableSelectionFilter(PassedStatusSequence, PassedStatusSequenceCondition, PassedForm, FormHeaderText)
        FillWorkOrderRequestedPartsHeadersDataGridView()
    End Sub

    Private Sub PrintReleaseNotesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintReleaseNotesToolStripMenuItem.Click
        PrintReleaseNotesToolStripMenuItem.Visible = False
        PartsReleaseInfoGroupBox.Visible = True
        ReceivedByTextBox.Text = WorkOrderRequestedPartsHeadersDataGridView.Item("RequestedBy", CurrentWorkOrderRequestedPartsHeadersDataGridViewRow).Value
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