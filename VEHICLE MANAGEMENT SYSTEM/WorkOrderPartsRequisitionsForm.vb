Public Class WorkOrderPartsRequisitionsForm
    Private WorkOrderPartsRequisitionsFieldsToSelect = ""
    Private WorkOrderPartsRequisitionsTableLinks = ""
    Private WorkOrderPartsRequisitionsSelectionFilter = ""
    Private WorkOrderPartsRequisitionsSelectionOrder = ""
    Private WorkOrderPartsRequisitionsRecordCount As Integer = -1
    Private WorkOrderPartsRequisitionsDataGridViewAlreadyFormated = False
    Private CurrentWorkOrderPartsRequisitionsDataGridViewRow As Integer = -1
    Private CurrentWorkOrderPartsRequisitionID As Integer = -1
    Private CurrentWorkOrderPartsRequisitionsStatusSelection = -1
    Private WorkOrderPartsRequisitionStatus = ""
    Private WorkOrderPartsRequisitionsItemsFieldsToSelect = ""
    Private WorkOrderPartsRequisitionsItemsTableLinks = ""
    Private WorkOrderPartsRequisitionsItemsSelectionFilter = ""
    Private WorkOrderPartsRequisitionsItemsSelectionOrder = ""
    Private WorkOrderPartsRequisitionsItemsRecordCount As Integer = -1
    Private WorkOrderPartsRequisitionsItemsDataGridViewAlreadyFormated = False
    Private CurrentWorkOrderPartsRequisitionsItemsDataGridViewRow As Integer = -1
    Private CurrentWorkOrderPartsRequisitionsItemID As Integer = -1

    Private PartNumberFieldsToSelect = ""
    Private PartNumbersTableLinks = ""
    Private PartNumberSelectionFilter = ""
    Private PartNumberSelectionOrder = ""
    Private PartNumberRecordCount As Integer = -1
    Private PartNumberDataGridViewAlreadyFormated = False
    Private CurrentPartNumberDataGridViewRow As Integer = -1
    Private CurrentPartNumberID As Integer = -1

    Private PartsRequisitionsItemsFieldsToSelect = ""
    Private PartsRequisitionsItemsTableLinks = ""
    Private PartsRequisitionsItemsSelectionFilter = ""
    Private PartsRequisitionsItemsSelectionOrder = ""
    Private PartsRequisitionsItemsRecordCount As Integer = -1
    Private PartsRequisitionsItemsDataGridViewAlreadyFormated = False
    Private CurrentPartsRequisitionsItemsID As Integer = -1
    Private CurrentPartsRequisitionsItemsDataGridViewRow As Integer = -1
    Private CurrentPartsRequisitionsItemID = -1

    Private CurrentPartsRequisitionID = -1
    Private CurrentWorkOrderPartID As Integer = -1
    Private CurrentProductsPartID = -1
    Private CurrentQtyToIssue = -1
    Private CurrentQtyToOrder = -1
    Private CurrentMasterCodeBookId = -1
    Private CreatingRequisitionItems = False
    Private SavedCallingForm As Form
    Private Sub WorkOrderPartsRequisitionsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        SavedCallingForm = CallingForm
        CurrentWorkOrderPartsRequisitionsStatusSelection = 0
        WorkOrderPartsRequisitionsSelectionFilter = SetupTableSelectionFilter(CurrentWorkOrderPartsRequisitionsStatusSelection, Me, "DRAFT WORK ORDER REQUISITIONS", "")
        MsgBox("'note on trial development ,else STOP AND delete above, watch routine SetupTableSelectionFilter above")

        WorkOrderPartsRequisitionsSelectionFilter = " WHERE WorkOrderPartsRequisitionStatusID_Integer =  " & GetStatusIdFor("WorkOrderPartsRequisitionsTable", "Outstanding").ToString &
                                                        " OR WorkOrderPartsRequisitionStatusID_Integer =  " & GetStatusIdFor("WorkOrderPartsRequisitionsTable", "For Revision").ToString

        FillWorkOrderPartsRequisitionsDataGridView()
    End Sub

    Private Sub WorkOrderPartsRequisitionsForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        If Me.Enabled = False Then Exit Sub
        CallingForm = SavedCallingForm

        ' GET RETURNED DATA HERE

        Select Case Tunnel1
            Case "Tunnel2IsWorkOrderPartsRequisitionCode"
                CurrentWorkOrderPartsRequisitionID = Tunnel2
            Case = "Tunnel2IsProductPartID"
                CurrentProductsPartID = Tunnel2
                QuantityGroupBox.Visible = True
                If CurrentProductsPartID > 0 Then
                    Dim xxFilter = " WHERE WorkOrderPartsRequisitionsItemID_AutoNumber = " & CurrentWorkOrderPartsRequisitionsItemID.ToString

                    MySelection = " UPDATE WorkOrderPartsRequisitionsItemsTable " &
                              " SET ProductPartID_LongInteger = " & CurrentProductsPartID & xxFilter
                    JustExecuteMySelection()
                    FillWorkOrderPartsRequisitionsItemsDataGridView()
                End If
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
SELECT 
WorkOrderPartsRequisitionsTable.WorkOrderPartsRequisitionNumber_ShortText12,
WorkOrderPartsRequisitionsTable.WorkOrderPartsRequisitionRevision_Integer,
WorkOrderPartsRequisitionsTable.WorkOrderPartsRequisitionDate_ShortDate,
(VehiclesTable.YearManufactured_ShortText4 & Space(1) & 
Trim(VehicleTypeTable.VehicleType_ShortText20) & Space(1) & 
Trim(VehicleModelsTable.VehicleModel_ShortText20) & Space(1) & 
Trim(VehicleTrimTable.VehicleTrimName_ShortText25) & Space(1) & 
Trim(VehiclesTable.Engine_ShortText20)) As VehicleName,
(PersonnelTable.LastName_ShortText15 & space(1) & mid(PersonnelTable.FirstName_ShortText15,1,1)) As RequestedBy,
WorkOrderPartsRequisitionsTable.WorkOrderID_LongInteger,
WorkOrderPartsRequisitionsTable.WorkOrderPartsRequisitionID_AutoNumber,
StatusesTable.StatusText_ShortText25
FROM ((((((((WorkOrderPartsRequisitionsTable LEFT JOIN WorkOrdersTable ON WorkOrderPartsRequisitionsTable.WorkOrderID_LongInteger = WorkOrdersTable.WorkOrderID_AutoNumber) LEFT JOIN ServicedVehiclesTable ON WorkOrdersTable.ServicedVehicleID_LongInteger = ServicedVehiclesTable.ServicedVehicleID_AutoNumber) LEFT JOIN VehiclesTable ON ServicedVehiclesTable.VehicleID_LongInteger = VehiclesTable.VehicleID_AutoNumber) LEFT JOIN VehicleModelsRelationsTable ON VehiclesTable.VehicleModelsRelationID_LongInteger = VehicleModelsRelationsTable.VehicleModelsRelationID_Autonumber) LEFT JOIN VehicleTypeTable ON VehicleModelsRelationsTable.VehicleTypeID_LongInteger = VehicleTypeTable.VehicleTypeID_AutoNumber) LEFT JOIN VehicleTrimTable ON VehicleModelsRelationsTable.VehicleTrimID_LongInteger = VehicleTrimTable.VehicleTrimID_Autonumber) LEFT JOIN VehicleModelsTable ON VehicleModelsRelationsTable.VehicleModelID_LongInteger = VehicleModelsTable.VehicleModelID_Autonumber) LEFT JOIN PersonnelTable ON WorkOrderPartsRequisitionsTable.RequestedByID_LongInteger = PersonnelTable.PersonnelID_AutoNumber) LEFT JOIN StatusesTable ON WorkOrderPartsRequisitionsTable.WorkOrderPartsRequisitionStatusID_Integer = StatusesTable.StatusID_Autonumber
"
        WorkOrderPartsRequisitionsSelectionOrder = " ORDER BY WorkOrderPartsRequisitionID_AutoNumber DESC "

        MySelection = WorkOrderPartsRequisitionsFieldsToSelect & WorkOrderPartsRequisitionsSelectionFilter & WorkOrderPartsRequisitionsSelectionOrder

        JustExecuteMySelection()
        WorkOrderPartsRequisitionsRecordCount = RecordCount
        WorkOrderPartsRequisitionsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If Not WorkOrderPartsRequisitionsDataGridViewAlreadyFormated Then
            FormatWorkOrderPartsRequisitionsDataGridView()
        End If

        Dim NoOfHeaderLines = 1
        Dim RecordsDisplyed = WorkOrderPartsRequisitionsRecordCount
        If WorkOrderPartsRequisitionsRecordCount > 12 Then
            RecordsDisplyed = 12
        Else
            RecordsDisplyed = WorkOrderPartsRequisitionsRecordCount
        End If

        WorkOrderPartsRequisitionsDataGridView.Height = (WorkOrderPartsRequisitionsDataGridView.ColumnHeadersHeight * NoOfHeaderLines) + (DataGridViewRowHeight * (RecordsDisplyed + 1))


    End Sub
    Private Sub FormatWorkOrderPartsRequisitionsDataGridView()
        WorkOrderPartsRequisitionsDataGridViewAlreadyFormated = True
        WorkOrderPartsRequisitionsDataGridView.Width = 0
        For i = 0 To WorkOrderPartsRequisitionsDataGridView.Columns.GetColumnCount(0) - 1

            WorkOrderPartsRequisitionsDataGridView.Columns.Item(i).Visible = False

            Select Case WorkOrderPartsRequisitionsDataGridView.Columns.Item(i).HeaderText
                Case "VehicleName"
                    WorkOrderPartsRequisitionsDataGridView.Columns.Item(i).HeaderText = "Model"
                    WorkOrderPartsRequisitionsDataGridView.Columns.Item(i).Width = 200
                    WorkOrderPartsRequisitionsDataGridView.Columns.Item(i).Visible = True
                Case "WorkOrderPartsRequisitionNumber_ShortText12"
                    WorkOrderPartsRequisitionsDataGridView.Columns.Item(i).HeaderText = "Requitition No. "
                    WorkOrderPartsRequisitionsDataGridView.Columns.Item(i).Width = 120
                    WorkOrderPartsRequisitionsDataGridView.Columns.Item(i).Visible = True
                Case "WorkOrderPartsRequisitionRevision_Integer"
                    WorkOrderPartsRequisitionsDataGridView.Columns.Item(i).HeaderText = "Rev"
                    WorkOrderPartsRequisitionsDataGridView.Columns.Item(i).Width = 30
                    WorkOrderPartsRequisitionsDataGridView.Columns.Item(i).Visible = True
                Case "WorkOrderPartsRequisitionDate_ShortDate"
                    WorkOrderPartsRequisitionsDataGridView.Columns.Item(i).HeaderText = "Date"
                    WorkOrderPartsRequisitionsDataGridView.Columns.Item(i).Width = 100
                    WorkOrderPartsRequisitionsDataGridView.Columns.Item(i).Visible = True
                Case "StatusText_ShortText25"
                    WorkOrderPartsRequisitionsDataGridView.Columns.Item(i).HeaderText = "Status"
                    WorkOrderPartsRequisitionsDataGridView.Columns.Item(i).Width = 200
                    WorkOrderPartsRequisitionsDataGridView.Columns.Item(i).Visible = True
            End Select
            If WorkOrderPartsRequisitionsDataGridView.Columns.Item(i).Visible = True Then
                WorkOrderPartsRequisitionsDataGridView.Width = WorkOrderPartsRequisitionsDataGridView.Width + WorkOrderPartsRequisitionsDataGridView.Columns.Item(i).Width
            End If
        Next
        ' NOTE" SYSTEM AUTOFITS THE GRIDVIEW FIELDS ACCORDING To THEIR WITDH

        Me.Width = VehicleManagementSystemForm.Width
        Me.Location = New Point(Me.Location.X, 55)
        Me.Left = VehicleManagementSystemForm.Left

        If WorkOrderPartsRequisitionsDataGridView.Width > Me.Width + 20 Then WorkOrderPartsRequisitionsDataGridView.Width = Me.Width - 80

        WorkOrderPartsRequisitionsDataGridView.Left = 5
        WorkOrderPartsRequisitionsDataGridView.Top = WorkOrderPartsMenuStrip.Top + WorkOrderPartsMenuStrip.Height

        PartNumberDataGridView.Top = WorkOrderPartsRequisitionsDataGridView.Top
        PartNumberDataGridView.Left = WorkOrderPartsRequisitionsDataGridView.Left + WorkOrderPartsRequisitionsDataGridView.Width + 5

        PartDetailsGroupBox.Top = WorkOrderPartsRequisitionsDataGridView.Top
        PartDetailsGroupBox.Left = PartNumberDataGridView.Left + PartNumberDataGridView.Width + 5
        PartDetailsGroupBox.Height = 258

        WorkOrderPartsRequisitionsItemsDataGridView.Top = PartDetailsGroupBox.Top + PartDetailsGroupBox.Height + 10
        WorkOrderPartsRequisitionsItemsDataGridView.Left = (Me.Width - WorkOrderPartsRequisitionsItemsDataGridView.Width) / 2

    End Sub
    Private Sub WorkOrderPartsRequisitionsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles WorkOrderPartsRequisitionsDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If WorkOrderPartsRequisitionsRecordCount = 0 Then Exit Sub
        CurrentWorkOrderPartsRequisitionsDataGridViewRow = e.RowIndex

        PartNumberTextBox.Text = ""
        OtherSpecificationsTextBox.Text = ""
        CurrentWorkOrderPartsRequisitionID = WorkOrderPartsRequisitionsDataGridView.Item("WorkOrderPartsRequisitionID_AutoNumber", CurrentWorkOrderPartsRequisitionsDataGridViewRow).Value
        WorkOrderPartsRequisitionStatus = WorkOrderPartsRequisitionsDataGridView.Item("StatusText_ShortText25", CurrentWorkOrderPartsRequisitionsDataGridViewRow).Value
        CurrentWorkOrderID = WorkOrderPartsRequisitionsDataGridView.Item("WorkOrderID_LongInteger", CurrentWorkOrderPartsRequisitionsDataGridViewRow).Value
        VehicleModelTextBox.Text = WorkOrderPartsRequisitionsDataGridView.Item("VehicleName", CurrentWorkOrderPartsRequisitionsDataGridViewRow).Value
        PartNumberTextBox.Text = ""
        CheckStockAvailabilityToolStripMenuItem.Visible = False
        EditPartDetailsToolStripMenuItem.Visible = False
        DeleteProductToolStripMenuItem.Visible = False
        ReleasePartsToolStripMenuItem.Visible = False
        PrepareRequisitionForPurchaseToolStripMenuItem.Visible = False
        SubmitRequisitionsForPurchaseToolStripMenuItem.Visible = False




        Select Case WorkOrderPartsRequisitionStatus
            Case "Outstanding"
                PrepareRequisitionForPurchaseToolStripMenuItem.Visible = True
            Case "Requisition Submitted"
            Case "Outstanding for Release"
                CheckStockAvailabilityToolStripMenuItem.Visible = True
                EditPartDetailsToolStripMenuItem.Visible = True
                DeleteProductToolStripMenuItem.Visible = True
                ReleasePartsToolStripMenuItem.Visible = True
                PrepareRequisitionForPurchaseToolStripMenuItem.Visible = True
            Case "Partially Received"
                ReleasePartsToolStripMenuItem.Visible = True
            Case "CompletelyReceived"
                ReleasePartsToolStripMenuItem.Visible = False

        End Select

        '' SETUP CURRENT VEHICLE INFORMATIONS
        SetVehicleInformations()    'REQUIRES CurrentWorkOrderID

        WorkOrderPartsRequisitionsItemsSelectionFilter = " WHERE WorkOrderPartsRequisitionID_AutoNumber = " & CurrentWorkOrderPartsRequisitionID.ToString

        FillWorkOrderPartsRequisitionsItemsDataGridView()

    End Sub

    Private Sub ReleasePartsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReleasePartsToolStripMenuItem.Click
        MsgBox("Sure all parts requested are ready for release?")
    End Sub


    Private Sub FillWorkOrderPartsRequisitionsItemsDataGridView()
        WorkOrderPartsRequisitionsItemsDataGridView.Visible = True

        WorkOrderPartsRequisitionsItemsFieldsToSelect =
"
SELECT 
MasterCodeBookTable.SystemDesc_ShortText100Fld,
ProductsPartsTable.ManufacturerPartNo_ShortText30Fld, 
ProductsPartsTable.ManufacturerDescription_ShortText250, 
StocksTable.QuantityInStock_Double, 
WorkOrderPartsRequisitionsItemsTable.RequiredQuantity_Double, 
PartsRequisitionsItemsTable.RequisitionQuantity_Double, 
BrandsTable.BrandName_ShortText20, 
StocksTable.Location_ShortText10, 
ProductsPartsTable.ProductDescription_ShortText250, 
WorkOrderPartsRequisitionsItemsTable.WorkOrderPartID_LongInteger, 
WorkOrderPartsRequisitionsItemsTable.ProductPartID_LongInteger, 
PartsRequisitionsItemsTable.PartsRequisitionsItemID_AutoNumber, 
WorkOrderPartsRequisitionsItemsTable.WorkOrderPartsRequisitionsItemID_AutoNumber, 
WorkOrderPartsRequisitionsItemsTable.WorkOrderPartsRequisitionsID_LongInteger, 
MasterCodeBookTable.MasterCodeBookID_Autonumber, WorkOrderPartsTable.WorkOrderPartID_AutoNumber
FROM (((PartsRequisitionsItemsTable RIGHT JOIN (StocksTable RIGHT JOIN ((WorkOrderPartsRequisitionsItemsTable LEFT JOIN ProductsPartsTable ON WorkOrderPartsRequisitionsItemsTable.ProductPartID_LongInteger = ProductsPartsTable.ProductsPartID_Autonumber) LEFT JOIN BrandsTable ON ProductsPartsTable.BrandID_LongInteger = BrandsTable.BrandID_Autonumber) ON StocksTable.ProductPartID_LongInteger = ProductsPartsTable.ProductsPartID_Autonumber) ON PartsRequisitionsItemsTable.OrderPartsRequisitionsItemID_LongInteger = WorkOrderPartsRequisitionsItemsTable.WorkOrderPartsRequisitionsItemID_AutoNumber) LEFT JOIN WorkOrderPartsRequisitionsTable ON WorkOrderPartsRequisitionsItemsTable.WorkOrderPartsRequisitionsID_LongInteger = WorkOrderPartsRequisitionsTable.WorkOrderPartsRequisitionID_AutoNumber) LEFT JOIN WorkOrderPartsTable ON WorkOrderPartsRequisitionsItemsTable.WorkOrderPartID_LongInteger = WorkOrderPartsTable.WorkOrderPartID_AutoNumber) LEFT JOIN MasterCodeBookTable ON WorkOrderPartsTable.MasterCodeBookID_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber
"
        MySelection = WorkOrderPartsRequisitionsItemsFieldsToSelect & WorkOrderPartsRequisitionsItemsSelectionFilter & WorkOrderPartsRequisitionsItemsSelectionOrder
        JustExecuteMySelection()

        WorkOrderPartsRequisitionsItemsRecordCount = RecordCount
        WorkOrderPartsRequisitionsItemsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        If Not WorkOrderPartsRequisitionsItemsDataGridViewAlreadyFormated Then
            FormatWorkOrderPartsRequisitionsItemsDataGridView()
        End If

        Dim NoOfHeaderLines = 1
        Dim RecordsDisplyed = WorkOrderPartsRequisitionsItemsRecordCount
        If WorkOrderPartsRequisitionsItemsRecordCount > 12 Then
            RecordsDisplyed = 12
        Else
            RecordsDisplyed = WorkOrderPartsRequisitionsItemsRecordCount
        End If


        WorkOrderPartsRequisitionsItemsDataGridView.Height = (WorkOrderPartsRequisitionsItemsDataGridView.ColumnHeadersHeight * NoOfHeaderLines) + (DataGridViewRowHeight * (RecordsDisplyed + 1))

    End Sub
    Private Sub FormatWorkOrderPartsRequisitionsItemsDataGridView()
        WorkOrderPartsRequisitionsItemsDataGridViewAlreadyFormated = True



        WorkOrderPartsRequisitionsItemsDataGridView.Width = 0

        For i = 0 To WorkOrderPartsRequisitionsItemsDataGridView.Columns.GetColumnCount(0) - 1

            WorkOrderPartsRequisitionsItemsDataGridView.Columns.Item(i).Visible = False

            Select Case WorkOrderPartsRequisitionsItemsDataGridView.Columns.Item(i).Name
                Case "SystemDesc_ShortText100Fld"
                    WorkOrderPartsRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Part"
                    WorkOrderPartsRequisitionsItemsDataGridView.Columns.Item(i).Width = 300
                    WorkOrderPartsRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "ManufacturerPartNo_ShortText30Fld"
                    WorkOrderPartsRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Manuf Part #"
                    WorkOrderPartsRequisitionsItemsDataGridView.Columns.Item(i).Width = 150
                    WorkOrderPartsRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "ManufacturerDescription_ShortText250"
                    WorkOrderPartsRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Manuf Desc."
                    WorkOrderPartsRequisitionsItemsDataGridView.Columns.Item(i).Width = 300
                    WorkOrderPartsRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "Quantity_Integer"
                    WorkOrderPartsRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Request"
                    WorkOrderPartsRequisitionsItemsDataGridView.Columns.Item(i).Width = 70
                    WorkOrderPartsRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "QuantityInStock_Double"
                    WorkOrderPartsRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Available"
                    WorkOrderPartsRequisitionsItemsDataGridView.Columns.Item(i).Width = 70
                    WorkOrderPartsRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "RequiredQuantity_Double"
                    WorkOrderPartsRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "to Issue"
                    WorkOrderPartsRequisitionsItemsDataGridView.Columns.Item(i).Width = 70
                    WorkOrderPartsRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "RequisitionQuantity_Double"
                    WorkOrderPartsRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "to order"
                    WorkOrderPartsRequisitionsItemsDataGridView.Columns.Item(i).Width = 70
                    WorkOrderPartsRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "BrandName_ShortText20"
                    WorkOrderPartsRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Brand"
                    WorkOrderPartsRequisitionsItemsDataGridView.Columns.Item(i).Width = 200
                    WorkOrderPartsRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "WorkOrderPartsTable.Unit_ShortText3"
                    WorkOrderPartsRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "WO UNIT"
                    WorkOrderPartsRequisitionsItemsDataGridView.Columns.Item(i).Width = 70
                    WorkOrderPartsRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "ProductDescription_ShortText250"
                    WorkOrderPartsRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Orig excel Desc."
                    WorkOrderPartsRequisitionsItemsDataGridView.Columns.Item(i).Width = 400
                    WorkOrderPartsRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "Location_ShortText10"
                    WorkOrderPartsRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Location"
                    WorkOrderPartsRequisitionsItemsDataGridView.Columns.Item(i).Width = 80
                    WorkOrderPartsRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
            End Select
            If WorkOrderPartsRequisitionsItemsDataGridView.Columns.Item(i).Visible = True Then
                WorkOrderPartsRequisitionsItemsDataGridView.Width = WorkOrderPartsRequisitionsItemsDataGridView.Width + WorkOrderPartsRequisitionsItemsDataGridView.Columns.Item(i).Width
            End If
        Next
        If WorkOrderPartsRequisitionsItemsDataGridView.Width > Me.Width Then
            WorkOrderPartsRequisitionsItemsDataGridView.Width = Me.Width
        End If
        WorkOrderPartsRequisitionsItemsDataGridView.Left = (Me.Width - WorkOrderPartsRequisitionsItemsDataGridView.Width)

    End Sub

    Private Sub WorkOrderPartsRequisitionsItemsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles WorkOrderPartsRequisitionsItemsDataGridView.RowEnter
        CurrentWorkOrderPartID = -1
        If e.RowIndex < 0 Then Exit Sub
        If WorkOrderPartsRequisitionsItemsRecordCount = 0 Then Exit Sub
        CurrentWorkOrderPartsRequisitionsItemsDataGridViewRow = e.RowIndex

        CurrentWorkOrderPartID = WorkOrderPartsRequisitionsItemsDataGridView.Item("WorkOrderPartID_Autonumber", CurrentWorkOrderPartsRequisitionsItemsDataGridViewRow).Value
        CurrentMasterCodeBookId = WorkOrderPartsRequisitionsItemsDataGridView.Item("MasterCodeBookID_Autonumber", CurrentWorkOrderPartsRequisitionsItemsDataGridViewRow).Value
        RequestedQuantityTextBox.Text = WorkOrderPartsRequisitionsItemsDataGridView.Item("RequiredQuantity_Double", CurrentWorkOrderPartsRequisitionsItemsDataGridViewRow).Value

        EditPartDetailsToolStripMenuItem.Visible = True
        DeleteProductToolStripMenuItem.Visible = True
        EditPartDetailsToolStripMenuItem.Visible = True
        '    If NotNull(WorkOrderPartsRequisitionsItemsDataGridView.Item("WorkOrderPartsRequisitionsItemStatus_Byte", CurrentWorkOrderPartsRequisitionsItemsDataGridViewRow).Value) = "2" Then ' 0 - outstanding 1 = outstanding re-order, 2 is received
        '    PrepareRequisitionForPurchaseToolStripMenuItem.Visible = False
        '   EditPartDetailsToolStripMenuItem.Visible = False
        '   DeleteProductToolStripMenuItem.Visible = False
        '    EditPartDetailsToolStripMenuItem.Visible = False
        '    End If

        CurrentWorkOrderPartsRequisitionsItemID = WorkOrderPartsRequisitionsItemsDataGridView.Item("WorkOrderPartsRequisitionsItemID_AutoNumber", CurrentWorkOrderPartsRequisitionsItemsDataGridViewRow).Value
        'CHECK IF THERE IS ALREADY REQUISITION RECORD ATTACHED
        CurrentWorkOrderPartsRequisitionsItemID = WorkOrderPartsRequisitionsItemsDataGridView.Item("WorkOrderPartsRequisitionsItemID_AutoNumber", CurrentWorkOrderPartsRequisitionsItemsDataGridViewRow).Value
        'CHECK IF THERE IS ALREADY REQUISITION RECORD ATTACHED
        If IsNotEmpty(WorkOrderPartsRequisitionsItemsDataGridView.Item("QuantityInStock_Double", CurrentWorkOrderPartsRequisitionsItemsDataGridViewRow).Value) Then
            ReleasePartsToolStripMenuItem.Visible = True
        Else
            ReleasePartsToolStripMenuItem.Visible = False
        End If
        If IsNotEmpty(CurrentMasterCodeBookId) Then
            PartNumberSelectionFilter = " WHERE  VehicleID_LongInteger = " & CurrentVehicleID.ToString
        End If

        '    FillPartNumberDataGridView()

        ' DSPLAY PART SPECIFICATIONS IF AVAILABLE

        CurrentWorkOrderPartID = WorkOrderPartsRequisitionsItemsDataGridView.Item("WorkOrderPartID_AutoNumber", CurrentWorkOrderPartsRequisitionsItemsDataGridViewRow).Value
        If IsNotEmpty(WorkOrderPartsRequisitionsItemsDataGridView.Item("RequiredQuantity_Double", CurrentWorkOrderPartsRequisitionsItemsDataGridViewRow).Value) Then
            ToIssueQuantityTextBox.Text = WorkOrderPartsRequisitionsItemsDataGridView.Item("RequiredQuantity_Double", CurrentWorkOrderPartsRequisitionsItemsDataGridViewRow).Value
        End If
        If IsNotEmpty(WorkOrderPartsRequisitionsItemsDataGridView.Item("ProductPartID_LongInteger", CurrentWorkOrderPartsRequisitionsItemsDataGridViewRow).Value) Then
            CurrentProductsPartID = WorkOrderPartsRequisitionsItemsDataGridView.Item("ProductPartID_LongInteger", CurrentWorkOrderPartsRequisitionsItemsDataGridViewRow).Value
            CheckStockAvailabilityToolStripMenuItem.Visible = False
        Else
            CurrentProductsPartID = -1
            CheckStockAvailabilityToolStripMenuItem.Visible = True
        End If
        If IsNotEmpty(WorkOrderPartsRequisitionsItemsDataGridView.Item("RequisitionQuantity_Double", CurrentWorkOrderPartsRequisitionsItemsDataGridViewRow).Value) Then
            ToOrderQuantityTextBox.Text = WorkOrderPartsRequisitionsItemsDataGridView.Item("RequisitionQuantity_Double", CurrentWorkOrderPartsRequisitionsItemsDataGridViewRow).Value
        Else
            ToOrderQuantityTextBox.Text = "0"
        End If
        CurrentQtyToIssue = Val(ToIssueQuantityTextBox.Text)
        CurrentQtyToOrder = Val(ToOrderQuantityTextBox.Text)
    End Sub
    Private Sub FillPartNumberDataGridView()
        PartNumberFieldsToSelect = " 
Select 
PartNumbersTable.PartNumberID_AutoNumber, 
CodeVehiclesTable.CodeVehicleID_AutoNumber, 
PartNumbersTable.PartNumber_ShortText25, 
CodeVehiclesTable.MasterCodeBookID_LongInteger, 
CodeVehiclesTable.VehicleID_LongInteger
From PartNumbersTable LEFT Join CodeVehiclesTable On PartNumbersTable.CodeVehicleID_LongInteger = CodeVehiclesTable.CodeVehicleID_AutoNumber 
"

        MySelection = PartNumberFieldsToSelect & PartNumberSelectionFilter & PartNumberSelectionOrder

        JustExecuteMySelection()

        PartNumberRecordCount = RecordCount
        PartNumberDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        If Not PartNumberDataGridViewAlreadyFormated Then
            PartNumberDataGridViewAlreadyFormated = True
            FormatPartNumberDataGridView()
        End If


        Dim NoOfHeaderLines = 1
        Dim RecordsDisplyed = PartNumberRecordCount
        If PartNumberRecordCount > 10 Then
            RecordsDisplyed = 10
        Else
            RecordsDisplyed = PartNumberRecordCount
        End If

        PartNumberDataGridView.Height = (PartNumberDataGridView.ColumnHeadersHeight * NoOfHeaderLines) + (DataGridViewRowHeight * (RecordsDisplyed + 1))

    End Sub
    Private Sub FormatPartNumberDataGridView()
        PartNumberDataGridView.Width = 0

        For i = 0 To PartNumberDataGridView.Columns.GetColumnCount(0) - 1

            PartNumberDataGridView.Columns.Item(i).Visible = False

            Select Case PartNumberDataGridView.Columns.Item(i).Name
                Case "PartNumber_ShortText25"
                    PartNumberDataGridView.Columns.Item(i).HeaderText = "PART NUMBER"
                    PartNumberDataGridView.Columns.Item(i).Width = 300
                    PartNumberDataGridView.Columns.Item(i).Visible = True
            End Select
            If PartNumberDataGridView.Columns.Item(i).Visible = True Then
                PartNumberDataGridView.Width = PartNumberDataGridView.Width + PartNumberDataGridView.Columns.Item(i).Width
            End If
        Next

    End Sub
    Private Sub PartNumberDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles PartNumberDataGridView.RowEnter
        CurrentPartNumberID = -1
        If e.RowIndex < 0 Then Exit Sub
        If PartNumberRecordCount = 0 Then Exit Sub
        CurrentPartNumberDataGridViewRow = e.RowIndex
        CurrentPartNumberID = PartNumberDataGridView.Item("PartNumberID_AutoNumber", CurrentPartNumberDataGridViewRow).Value
        PartNumberTextBox.Text = PartNumberDataGridView.Item("PartNumber_ShortText25", CurrentPartNumberDataGridViewRow).Value
    End Sub
    Private Sub FillPartsRequisitionsItemsDataGridView()
        PartsRequisitionsItemsFieldsToSelect = " 
SELECT 
WorkOrderPartsTable.WorkOrderID_LongInteger,
MasterCodeBookTable.MasterCodeBookID_Autonumber, 
ProductsPartsTable.ManufacturerPartNo_ShortText30Fld, ProductsPartsTable.ManufacturerDescription_ShortText250, WorkOrderPartsTable.Quantity_Integer, WorkOrderPartsTable.Unit_ShortText3, StocksTable.QuantityInStock_Double, WorkOrderPartsRequisitionsItemsTable.RequiredQuantity_Double, PartsRequisitionsItemsTable.PartsRequisitionsItemID_AutoNumber, PartsRequisitionsItemsTable.RequisitionQuantity_Double, PartsRequisitionsItemsTable.PartsRequisitionID_LongInteger, PartsRequisitionsItemsTable.ProductPartID_LongInteger, PartsRequisitionsItemsTable.PartsRequisitionItemStatusID_LongInteger, MasterCodeBookTable.SystemDesc_ShortText100Fld, ProductsPartsTable.ProductsPartID_Autonumber, BrandsTable.BrandName_ShortText20, ProductsPartsTable.ProductDescription_ShortText250, WorkOrderPartsTable.WorkOrderPartID_AutoNumber, WorkOrderPartsRequisitionsItemsTable.WorkOrderPartID_LongInteger, WorkOrderPartsRequisitionsItemsTable.WorkOrderPartsRequisitionsItemID_AutoNumber, PartsRequisitionsTable.PartsRequisitionStatus_Integer
FROM (PartsRequisitionsItemsTable LEFT JOIN ((((WorkOrderPartsRequisitionsItemsTable LEFT JOIN ProductsPartsTable ON WorkOrderPartsRequisitionsItemsTable.ProductPartID_LongInteger = ProductsPartsTable.ProductsPartID_Autonumber) LEFT JOIN StocksTable ON WorkOrderPartsRequisitionsItemsTable.ProductPartID_LongInteger = StocksTable.ProductPartID_LongInteger) LEFT JOIN BrandsTable ON ProductsPartsTable.BrandID_LongInteger = BrandsTable.BrandID_Autonumber) LEFT JOIN ((WorkOrderPartsTable LEFT JOIN MasterCodeBookTable ON WorkOrderPartsTable.MasterCodeBookID_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) LEFT JOIN WorkOrderPartsRequisitionsTable ON WorkOrderPartsTable.WorkOrderPartsRequisitionID_LongInteger = WorkOrderPartsRequisitionsTable.WorkOrderPartsRequisitionID_AutoNumber) ON WorkOrderPartsRequisitionsItemsTable.WorkOrderPartID_LongInteger = WorkOrderPartsTable.WorkOrderPartID_AutoNumber) ON PartsRequisitionsItemsTable.OrderPartsRequisitionsItemID_LongInteger = WorkOrderPartsRequisitionsItemsTable.WorkOrderPartsRequisitionsItemID_AutoNumber) LEFT JOIN PartsRequisitionsTable ON PartsRequisitionsItemsTable.PartsRequisitionID_LongInteger = PartsRequisitionsTable.PartsRequisitionID_AutoNumber
"
        MySelection = PartsRequisitionsItemsFieldsToSelect & PartsRequisitionsItemsSelectionFilter & PartsRequisitionsItemsSelectionOrder

        JustExecuteMySelection()

        PartsRequisitionsItemsRecordCount = RecordCount
        PartsRequisitionsItemsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable


        If Not PartsRequisitionsItemsDataGridViewAlreadyFormated Then
            PartsRequisitionsItemsDataGridViewAlreadyFormated = True
            FormatRequisitionsItemsDataGridView()
        End If

        Dim NoOfHeaderLines = 1
        Dim RecordsDisplyed = PartsRequisitionsItemsRecordCount
        If PartsRequisitionsItemsRecordCount > 10 Then
            RecordsDisplyed = 10
        Else
            RecordsDisplyed = PartsRequisitionsItemsRecordCount
        End If

        PartsRequisitionsItemsDataGridView.Height = (PartsRequisitionsItemsDataGridView.ColumnHeadersHeight * NoOfHeaderLines) + (DataGridViewRowHeight * (RecordsDisplyed + 1))

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
                Case "RequiredQuantity_Double"
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
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Width = 125
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "ManufacturerDescription_ShortText250"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "ManufacturerDescription"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Width = 300
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "BrandName_ShortText20"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Brand"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Width = 150
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "ManufacturerDescription_ShortText250"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "Manufac Desc"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Width = 300
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
                Case "ProductDescription_ShortText250"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).HeaderText = "excel"
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Width = 300
                    PartsRequisitionsItemsDataGridView.Columns.Item(i).Visible = True
            End Select
            If PartsRequisitionsItemsDataGridView.Columns.Item(i).Visible = True Then
                PartsRequisitionsItemsDataGridView.Width = PartsRequisitionsItemsDataGridView.Width + PartsRequisitionsItemsDataGridView.Columns.Item(i).Width
            End If
        Next
        If PartsRequisitionsItemsDataGridView.Width > Me.Width Then
            PartsRequisitionsItemsDataGridView.Width = Me.Width - 20
        End If
        RequestForPurchaseGroupBox.Width = PartsRequisitionsItemsDataGridView.Width + 20
        RequestForPurchaseGroupBox.Left = (Me.Width - RequestForPurchaseGroupBox.Width) / 2
        PartsRequisitionsItemsDataGridView.Left = 5
    End Sub

    Private Sub PartsRequisitionsItemsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles PartsRequisitionsItemsDataGridView.RowEnter
        CurrentPartsRequisitionsItemsID = -1
        If e.RowIndex < 0 Then Exit Sub
        If PartsRequisitionsItemsRecordCount = 0 Then Exit Sub
        CurrentPartsRequisitionsItemsDataGridViewRow = e.RowIndex

        CurrentWorkOrderPartsRequisitionsItemID = PartsRequisitionsItemsDataGridView.Item("WorkOrderPartsRequisitionsItemID_AutoNumber", CurrentPartsRequisitionsItemsDataGridViewRow).Value
        '        CurrentProductsPartID = PartsRequisitionsItemsDataGridView.Item("ProductsPartID_Autonumber", CurrentPartsRequisitionsItemsDataGridViewRow).Value
        CurrentPartsRequisitionsItemID = PartsRequisitionsItemsDataGridView.Item("PartsRequisitionsItemID_AutoNumber", CurrentPartsRequisitionsItemsDataGridViewRow).Value
        RequestedQuantityTextBox.Text = PartsRequisitionsItemsDataGridView.Item("Quantity_Integer", CurrentPartsRequisitionsItemsDataGridViewRow).Value
        AvailableQuantityTextBox.Text = "0"
        ToOrderQuantityTextBox.Text = "0"
        If IsDBNull(PartsRequisitionsItemsDataGridView.Item("PartsRequisitionItemStatusID_LongInteger", CurrentPartsRequisitionsItemsDataGridViewRow).Value) Then
            SubmitRequisitionsForPurchaseToolStripMenuItem.Text = "Submit Requisitions for Purchase"
            QuantityGroupBox.Enabled = True
        Else
            SubmitRequisitionsForPurchaseToolStripMenuItem.Text = "Requisition has already been submitted"
            QuantityGroupBox.Enabled = False
            ReturnToolStripMenuItem.Enabled = True
        End If
        AvailableQuantityTextBox.Text = NotNull(PartsRequisitionsItemsDataGridView.Item("QuantityInStock_Double", CurrentPartsRequisitionsItemsDataGridViewRow).Value)
        ToIssueQuantityTextBox.Text = PartsRequisitionsItemsDataGridView.Item("RequiredQuantity_Double", CurrentPartsRequisitionsItemsDataGridViewRow).Value
        ToOrderQuantityTextBox.Text = PartsRequisitionsItemsDataGridView.Item("RequisitionQuantity_Double", CurrentPartsRequisitionsItemsDataGridViewRow).Value
        CurrentQtyToIssue = Val(ToIssueQuantityTextBox.Text)
        CurrentQtyToOrder = Val(ToOrderQuantityTextBox.Text)

    End Sub


    Private Sub AddNewPartNumber()
        ' WRONG THISSHOUD BE CALLING UPDATE CODEVEHICLEPARTNUN
    End Sub


    Private Sub CheckAndIssueThisPartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckStockAvailabilityToolStripMenuItem.Click
        PartDetailsGroupBox.Visible = True
        ProductsPartsForm.PartNoToolStripTextBox.Text = PartNumberTextBox.Text
        ProductsPartsForm.SearchDescriptionToolStripTextBox.Text = WorkOrderPartsRequisitionsItemsDataGridView.Item("SystemDesc_ShortText100Fld", CurrentWorkOrderPartsRequisitionsItemsDataGridViewRow).Value
        ProductsPartsForm.VehicleFilterToolStripTextBox.Text = VehicleModelTextBox.Text
        '        Tunnel1 = "Tunnel1IsMasterCodeBookID"
        '       Tunnel2 = WorkOrderPartsRequisitionsItemsDataGridView.Item("MasterCodeBookID_LongInteger", CurrentWorkOrderPartsRequisitionsItemsDataGridViewRow).Value
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
                    MySelection = " UPDATE WorkOrderPartsRequisitionsItemsTable  " &
                              " SET ProductPartID_LongInteger = 0 " &
                              " WHERE WorkOrderPartsRequisitionsItemID_AutoNumber = " & CurrentWorkOrderPartsRequisitionsItemID.ToString
                    JustExecuteMySelection()
                    FillWorkOrderPartsRequisitionsItemsDataGridView()
                End If
            End If
            WorkOrderPartsRequisitionsItemsDataGridView.Refresh()
        End If
    End Sub

    Private Sub DeleteProductToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteProductToolStripMenuItem.Click
        If Not MsgBox("Would you like to remove the specified Product ?", vbYesNoCancel) = MsgBoxResult.Yes Then
            Exit Sub
        End If
        If Not MsgBox("Are you sure to unlink this product ?", vbYesNoCancel) = MsgBoxResult.Yes Then
            Exit Sub
        End If
        MySelection = " UPDATE WorkOrderPartsRequisitionsItemsTable  " &
                              " SET ProductPartID_LongInteger = -1 " &
                              " WHERE WorkOrderPartsRequisitionsItemID_AutoNumber = " & CurrentWorkOrderPartsRequisitionsItemID
        JustExecuteMySelection()
        FillWorkOrderPartsRequisitionsItemsDataGridView()
    End Sub
    Private Sub SubmitAllRequisitionsForPurchaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SubmitRequisitionsForPurchaseToolStripMenuItem.Click
        If SubmitRequisitionsForPurchaseToolStripMenuItem.Text = "Requisition has already been submitted" Then
            RequestForPurchaseGroupBox.Visible = False
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
                             0.ToString

        CurrentPartsRequisitionID = InsertNewRecord("PartsRequisitionsTable", FieldsToUpdate, FieldsData)


        'ALL TEMPORARY ITEMS IN PartsRequisitionsItemsTable WILL THEN BE MARKED FINAL REPLACING THE PartsRequisitionID_LongInteger
        ' WITH THE NEWLY CREATED PartsRequisitionsHeader

        For i = 0 To PartsRequisitionsItemsRecordCount - 1
            CurrentPartsRequisitionsItemID = PartsRequisitionsItemsDataGridView.Item("PartsRequisitionsItemID_AutoNumber", i).Value
            CurrentProductsPartID = -1
            If Not IsEmpty(PartsRequisitionsItemsDataGridView.Item("ProductsPartID_Autonumber", i).Value) Then
                If PartsRequisitionsItemsDataGridView.Item("ProductsPartID_Autonumber", i).Value > 0 Then
                    CurrentProductsPartID = PartsRequisitionsItemsDataGridView.Item("ProductsPartID_Autonumber", i).Value
                End If
            End If

            MySelection = " UPDATE PartsRequisitionsItemsTable  " &
                              " SET PartsRequisitionID_LongInteger = " & CurrentPartsRequisitionID.ToString & ", " &
                              " ProductPartID_LongInteger = " & CurrentProductsPartID.ToString &
                              " WHERE PartsRequisitionsItemID_AutoNumber = " & CurrentPartsRequisitionsItemID.ToString
            JustExecuteMySelection()
        Next
        MySelection = " UPDATE WorkOrderPartsRequisitionsTable  " &
                              " SET WorkOrderPartsRequisitionStatusID_Integer = " & GetStatusIdFor("WorkOrderPartsRequisitionsTable", "Requisition Submitted").ToString &
                              " WHERE WorkOrderPartsRequisitionID_AutoNumber = " & CurrentWorkOrderPartsRequisitionID.ToString
        JustExecuteMySelection()

        RequestForPurchaseGroupBox.Visible = False
        QuantityGroupBox.Visible = False
        FillWorkOrderPartsRequisitionsDataGridView()

    End Sub



    Private Sub QuantityGroupBox_VisibleChanged(sender As Object, e As EventArgs) Handles QuantityGroupBox.VisibleChanged
        If QuantityGroupBox.Visible = True Then
            QuantityGroupBox.Left = RequestForPurchaseGroupBox.Width - QuantityGroupBox.Width
            QuantityGroupBox.Top = RequestForPurchaseGroupBox.Top + 5

            ToOrderQuantityTextBox.Text = ToIssueQuantityTextBox.Text

            CheckStockAvailabilityToolStripMenuItem.Visible = False
            EditPartDetailsToolStripMenuItem.Visible = False
            DeleteProductToolStripMenuItem.Visible = False
            ReleasePartsToolStripMenuItem.Visible = False
            PrepareRequisitionForPurchaseToolStripMenuItem.Visible = False

            WorkOrderPartsRequisitionsDataGridView.Enabled = False
            WorkOrderPartsRequisitionsItemsDataGridView.Enabled = False
        Else
            CheckStockAvailabilityToolStripMenuItem.Visible = True
            EditPartDetailsToolStripMenuItem.Visible = True
            DeleteProductToolStripMenuItem.Visible = True
            ReleasePartsToolStripMenuItem.Visible = True
            PrepareRequisitionForPurchaseToolStripMenuItem.Visible = True

            WorkOrderPartsRequisitionsDataGridView.Enabled = True
            WorkOrderPartsRequisitionsItemsDataGridView.Enabled = True
        End If
    End Sub

    Private Sub PrepareRequisitionForPurchaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrepareRequisitionForPurchaseToolStripMenuItem.Click
        CreatingRequisitionItems = True
        ' PartsRequisitionsItems may have been inserted already by individually updating the order quantity
        ' on entry here, for all those items  not yet in the requisition items, the quantity requested against available quantity
        ' on stock is checked and for any negative result, a new order record will be inserted with the balance qty needed.
        ' therefore process will be - check if a requisition record already exists in the RequistionItemsTable and that status is not 0
        ' 
        For I = 0 To WorkOrderPartsRequisitionsItemsRecordCount - 1
            ' IS THERE ALREADY AN ORDER ?
            If IsNotEmpty(WorkOrderPartsRequisitionsItemsDataGridView.Item("PartsRequisitionsItemID_AutoNumber", I).Value) Then
                Continue For
            End If

            'NONE
            WorkOrderPartsRequisitionsItemsDataGridView.Rows(I).Selected = True

            CurrentWorkOrderPartsRequisitionsItemID = WorkOrderPartsRequisitionsItemsDataGridView.Item("WorkOrderPartsRequisitionsItemID_AutoNumber", I).Value
            CurrentWorkOrderPartID = WorkOrderPartsRequisitionsItemsDataGridView.Item("WorkOrderPartID_Autonumber", I).Value
            CurrentMasterCodeBookId = WorkOrderPartsRequisitionsItemsDataGridView.Item("MasterCodeBookID_LongInteger", I).Value
            CurrentProductsPartID = WorkOrderPartsRequisitionsItemsDataGridView.Item("ProductPartID_LongInteger", I).Value
            RequestedQuantityTextBox.Text = WorkOrderPartsRequisitionsItemsDataGridView.Item("Quantity_Integer", I).Value
            ToIssueQuantityTextBox.Text = RequestedQuantityTextBox.Text
            ToOrderQuantityTextBox.Text = Val(AvailableQuantityTextBox.Text) - Val(ToIssueQuantityTextBox.Text)
            If Val(ToOrderQuantityTextBox.Text) < 0 Then ToOrderQuantityTextBox.Text = (Val(ToOrderQuantityTextBox.Text) * -1).ToString

            'IS THERE ALREADY AN SPECIFIC PRODUCT REQUESTED?
            'CHECK IF THERE IS A NEED TO UPDATE THE PARTSREQUISITIONITEMSTABLE
            UpdatePartsRequisitionsItemsTable()
            WorkOrderPartsRequisitionsItemsDataGridView.Rows(I).Selected = False
        Next
        ' I STOPED HERE FIGURING OUT RECORDS TO RELEASE AND TO ORDER
        'THEN THERE IS NO CORRESPONDING RECORD YET TO ISSUE, CREATE ONE INCLUDE QUANTITIES
        '                      SendKeys.Send("{DOWN}")
        '                      SendKeys.Send("{up}")
        CurrentWorkOrderPartID = WorkOrderPartsRequisitionsItemsDataGridView.Item("WorkOrderPartID_Autonumber", CurrentWorkOrderPartsRequisitionsItemsDataGridViewRow).Value

        CurrentMasterCodeBookId = WorkOrderPartsRequisitionsItemsDataGridView.Item("MasterCodeBookID_Autonumber", CurrentWorkOrderPartsRequisitionsItemsDataGridViewRow).Value

        PartsRequisitionsItemsSelectionFilter = " WHERE WorkOrderPartsTable.WorkOrderID_LongInteger = " & CurrentWorkOrderID
        RequestForPurchaseGroupBox.Visible = True
        CreatingRequisitionItems = False

    End Sub
    Private Sub RequestForPurchaseGroupBox_VisibleChanged(sender As Object, e As EventArgs) Handles RequestForPurchaseGroupBox.VisibleChanged
        If RequestForPurchaseGroupBox.Visible = True Then
            SubmitRequisitionsForPurchaseToolStripMenuItem.Visible = True
            QuantityGroupBox.Visible = True
            ToIssueQuantityTextBox.Enabled = False
            ReturnToolStripMenuItem.Enabled = False
            WorkOrderPartsRequisitionsDataGridView.Enabled = False
            PartDetailsGroupBox.Enabled = False
            WorkOrderPartsRequisitionsItemsDataGridView.Enabled = False
            FillPartsRequisitionsItemsDataGridView()
        Else
            SubmitRequisitionsForPurchaseToolStripMenuItem.Visible = False
            QuantityGroupBox.Visible = False
            ToIssueQuantityTextBox.Enabled = True
            WorkOrderPartsRequisitionsDataGridView.Enabled = True
            PartDetailsGroupBox.Enabled = True
            WorkOrderPartsRequisitionsItemsDataGridView.Enabled = True
            ReturnToolStripMenuItem.Enabled = True
        End If
    End Sub
    Private Sub ConfirmQuantitiesButton_Click(sender As Object, e As EventArgs) Handles ConfirmQuantitiesButton.Click
        ' check if ff are redunndant
        If Val(ToIssueQuantityTextBox.Text) <> CurrentQtyToIssue Then
            If Val(ToIssueQuantityTextBox.Text) > 0 Then

                UpdateWorkOrderPartsRequisitionsItemsTable()
            End If
        End If
        If Val(ToOrderQuantityTextBox.Text) <> NotNull(WorkOrderPartsRequisitionsItemsDataGridView.Item("RequisitionQuantity_Double", CurrentWorkOrderPartsRequisitionsItemsDataGridViewRow).Value) Then
            If Val(ToOrderQuantityTextBox.Text) > 0 Then
                UpdatePartsRequisitionsItemsTable()
            Else
                If MsgBox("Remove this item?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    MySelection = " DELETE FROM PartsRequisitionsItemsTable WHERE PartsRequisitionsItemID_AutoNumber =  " & CurrentPartsRequisitionsItemID
                    JustExecuteMySelection()
                    FillPartsRequisitionsItemsDataGridView()
                End If
            End If
        End If
        FillPartsRequisitionsItemsDataGridView()
        If RequestForPurchaseGroupBox.Visible = True Then
        Else
            QuantityGroupBox.Visible = False
            FillWorkOrderPartsRequisitionsItemsDataGridView()
        End If

    End Sub
    Private Sub UpdatePartsRequisitionsItemsTable()

        Dim xxFilter = ""


        ' THIS MODULE MAY BE CALLED BY the SYSTEM WHEN:
        '                           1-THE REQUEST FOR PARTS IS AUTO DETERMINED UPON ENTRY TO THE PrepareRequisitionForPurchase ROUTINE
        '                           2-ConfirmQuantities ROUTINE IS REQUESTING THIS ROUTINE

        'NEXT WE WILL UPDATE THE WAREHOUSE DATABASE (STOCKS TABLE) when product is specified

        If Not IsEmpty(CurrentProductsPartID) Then ' THERE IS A PRODUCT LINKED (SPECIFIC TO BUY)
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
        If CurrentPartsRequisitionsItemID > 0 Then
            xxFilter = " WHERE OrderPartsRequisitionsItemID_LongInteger = " & CurrentPartsRequisitionsItemID.ToString

            MySelection = " SELECT * FROM PartsRequisitionsItemsTable " & xxFilter

            JustExecuteMySelection()

            If RecordCount > 0 Then
                If Val(ToOrderQuantityTextBox.Text) = 0 Then
                    If MsgBox("You reset the value to order to 0, Do you want to remove this order ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        MySelection = " PartsRequisitionsItemsTable " & xxFilter
                    End If
                Else
                    MySelection = " UPDATE PartsRequisitionsItemsTable " &
                                  " SET RequisitionQuantity_Double = " & ToOrderQuantityTextBox.Text & xxFilter
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
            Dim FieldsToUpdate =
                                       " PartsRequisitionID_LongInteger, " &
                                       " ProductPartID_LongInteger, " &
                                       " RequisitionQuantity_Double, " &
                                       " OrderPartsRequisitionsItemID_LongInteger, " &
                                       " PartsRequisitionItemStatusID_LongInteger "
            Dim FieldsData =
                                        -1.ToString & "," &
                                        CurrentProductsPartID.ToString & "," &
                                        ToOrderQuantityTextBox.Text & "," &
                                        CurrentWorkOrderPartsRequisitionsItemID.ToString & "," &
                                        GetStatusIdFor("PartsRequisitionsItemsTable")

            CurrentPartsRequisitionsItemID = InsertNewRecord("PartsRequisitionsItemsTable", FieldsToUpdate, FieldsData)
        End If
        Dim xxRequisitionsItemsDataGridViewRow = CurrentPartsRequisitionsItemsDataGridViewRow
        If Not CreatingRequisitionItems Then
            FillPartsRequisitionsItemsDataGridView()
            PartsRequisitionsItemsDataGridView.Rows(RecordCount - 1).Selected = True
            PartsRequisitionsItemsDataGridView.Refresh()
        End If

    End Sub
    Private Sub UpdateWorkOrderPartsRequisitionsItemsTable()
        If MsgBox("Proceed replacing ToIssue Qty from " & CurrentQtyToIssue.ToString & " to " & ToIssueQuantityTextBox.Text, MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        ' EXECUTE INSERT COMMAND 
        Dim xxFilter = ""
        If IsEmpty(CurrentWorkOrderPartsRequisitionsItemID) Then ' THE PART HAS NO RECORD YET IN THE WorkOrderPartsRequisitionsItemsTable
            RecordCount = 0
        Else
            xxFilter = " WHERE WorkOrderPartsRequisitionsItemID_AutoNumber = " & CurrentWorkOrderPartsRequisitionsItemID.ToString

            MySelection = " SELECT * FROM WorkOrderPartsRequisitionsItemsTable " & xxFilter

            JustExecuteMySelection()
        End If

        If RecordCount > 0 Then
            MySelection = " UPDATE WorkOrderPartsRequisitionsItemsTable " &
                              " SET RequiredQuantity_Double = " & ToIssueQuantityTextBox.Text & xxFilter
        Else
            MySelection = " INSERT INTO WorkOrderPartsRequisitionsItemsTable (" &
                                       " WorkOrderPartID_LongInteger, " &
                                       " ProductPartID_LongInteger, " &
                                       " RequiredQuantity_Double " &
                                ") VALUES (" &
                                       CurrentWorkOrderPartID.ToString & "," &
                                       CurrentProductsPartID.ToString & "," &
                                       ToIssueQuantityTextBox.Text & ")"
        End If
        JustExecuteMySelection()
    End Sub
    Private Sub NewItemButton_Click(sender As Object, e As EventArgs) Handles NewItemButton.Click
        PartsSpecificationsForm.SpecifiedPartNumberTextBox.Text = PartNumberTextBox.Text
        PartsSpecificationsForm.PartNumberButton.Text = "Save PART NUMBER"
        Tunnel1 = "Tunnel2IsMasterCodeBookID"
        Tunnel2 = CurrentMasterCodeBookId
        Tunnel3 = CurrentWorkOrderPartsRequisitionsItemID = PartsRequisitionsItemsDataGridView.Item("SystemDesc_ShortText100Fld", CurrentPartsRequisitionsItemsDataGridViewRow).Value &
                                                            " for " & CurrentVehicleString
        ShowCalledForm(Me, PartsSpecificationsForm)
    End Sub
    Private Sub CancelRequisitionForPurchaseButton_Click(sender As Object, e As EventArgs) Handles CancelRequisitionForPurchaseButton.Click
        RequestForPurchaseGroupBox.Visible = False
        QuantityGroupBox.Visible = False
    End Sub
    Private Sub OutstandingRequisitionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OutstandingRequisitionsToolStripMenuItem.Click
        SetWorkOrderPartsRequisitionsSelectionFilter(1, Me, "OUTSTANDING FOR RELASE")
    End Sub

    Private Sub DraftRequisitiosForPurchaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DraftRequisitiosForPurchaseToolStripMenuItem.Click
        SetWorkOrderPartsRequisitionsSelectionFilter(2, Me, "DRAFT DRAFT REQUISITIONS FOR PURCHASE")
    End Sub
    Private Sub AllPurchaseOrdersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllPurchaseOrdersToolStripMenuItem.Click
        SetWorkOrderPartsRequisitionsSelectionFilter(3, Me, "3 - Submitted Requisition ")
    End Sub

    Private Sub PrintPurchaseOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintPurchaseOrderToolStripMenuItem.Click
        SetWorkOrderPartsRequisitionsSelectionFilter(4, Me, "4 - Reordered")
    End Sub

    Private Sub ReorderedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReorderedToolStripMenuItem.Click
        SetWorkOrderPartsRequisitionsSelectionFilter(5, Me, "5 - Partially Received")
    End Sub

    Private Sub CompletelyReceivedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompletelyReceivedToolStripMenuItem.Click
        SetWorkOrderPartsRequisitionsSelectionFilter(6, Me, "6 - Completely Received")
    End Sub

    Private Sub FinalizedPurchaseOrdersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FinalizedPurchaseOrdersToolStripMenuItem.Click
        SetWorkOrderPartsRequisitionsSelectionFilter(7, Me, "7 - Partially Issued")
    End Sub

    Private Sub CompletelyIssuedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompletelyIssuedToolStripMenuItem.Click
        SetWorkOrderPartsRequisitionsSelectionFilter(8, Me, "8 - Completely Issued")
    End Sub

    Private Sub AllPartsRequisitionsForIssuanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllPartsRequisitionsForIssuanceToolStripMenuItem.Click
        SetWorkOrderPartsRequisitionsSelectionFilter(10, Me, "ALL REQUISITIONS")
    End Sub
    Private Sub SetWorkOrderPartsRequisitionsSelectionFilter(PassedStatusCode As Integer, PassedForm As Form, FormHeaderText As String)
        CurrentWorkOrderPartsRequisitionsStatusSelection = PassedStatusCode
        WorkOrderPartsRequisitionsSelectionFilter = SetupTableSelectionFilter(CurrentWorkOrderPartsRequisitionsStatusSelection, PassedForm, FormHeaderText, "")
        FillWorkOrderPartsRequisitionsDataGridView()
    End Sub
End Class