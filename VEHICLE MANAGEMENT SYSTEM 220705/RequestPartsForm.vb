Public Class RequestPartsForm
    Private CurrentWorkOrderPartsRow As Integer = -1
    Private CurrentMasterCodeBookID As Integer = -1
    Private CurrentInformationsHeaderID As Integer = -1

    Private WorkOrderPartsFieldsToSelect = ""
    Private WorkOrderPartsSelectionFilter = ""
    Private WorkOrderPartsSelectionOrder = ""
    Private CurrentWorkOrderPartID As Integer = -1
    Private WorkOrderPartsRecordCount As Integer = 0
    Private WorkOrderPartsGridViewAlreadyFormated = False

    Private WorkOrderRequestedPartsFieldsToSelect = ""
    Private WorkOrderRequestedPartsSelectionFilter = ""
    Private CurrentWorkOrderRequestedPartID As Integer = -1
    Private WorkOrderRequestedPartsRecordCount As Integer = 0
    Private WorkOrderRequestedPartsGridViewAlreadyFormated = False
    Private CurrentWorkOrderRequestedPartsRow As Integer = -1

    Private CustomerSuppliedPartsFieldsToSelect = ""
    Private CustomerSuppliedPartsSelectionFilter = ""
    Private CurrentCustomerSuppliedPartID As Integer = -1
    Private CustomerSuppliedPartsRecordCount As Integer = 0
    Private CustomerSuppliedPartsGridViewAlreadyFormated = False
    Private CurrentCustomerSuppliedPartsRow As Integer = -1

    Private WorkOrderConcernJobsFieldsToSelect = ""
    Private WorkOrderConcernJobsSelectionFilter = ""
    Private WorkOrderConcernJobsSelectionOrder = ""
    Private WorkOrderConcernJobsRecordCount As Integer = 0
    Private WorkOrderConcernJobsGridViewAlreadyFormated = False
    Private CurrentWorkOrderConcernJobsRow As Integer = -1
    Private CurrentWorkOrderConcernJobID As Integer = -1
    Private CurrentPartsSpecificationID = -1
    Private CurrentQuantitySpecificationsID = -1
    Private CurrentWorkOrderConcernID = -1
    Private CurrentWorkOrderRequestedPartsHeaderID = -1
    Private CurrentProductPartID = -1
    Private WorkOrderPartsRequisitionStatusID = -1
    Private PurposeOfEntry = ""
    Private SavedCallingForm As Form
    Private ChangesOccured = False
    'Private GetStandardPartsFlag = False

    Private Sub RequestPartForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' form returns       Tunnel1 = CurrentVehicleModelsRelationID
        '                    Tunnel2 = 
        ' ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        SavedCallingForm = CallingForm
        SubmitRequestForPartsToolStripMenuItem.Text = "Submit Request For Parts"
        RegisterReceivedPartFromCustomerToolStripMenuItem.Text = "Register Received Part(s) From Customer"
        Me.Width = VehicleManagementSystemForm.Width - 4
        Me.Left = VehicleManagementSystemForm.Left
        Me.Text = Tunnel3
        VerticalCenter(PartDetailsGroupBox, Me)
        HorizontalCenter(PartDetailsGroupBox, Me)
        WorkOrderConcernJobsGroupBox.Top = WorkOrderConcernButton.Top + WorkOrderConcernButton.Height
        CurrentWorkOrderConcernID = Tunnel1
        CurrentVehicleString = VehicleNameButton.Text
        WorkOrderConcernJobsSelectionFilter = " WHERE WorkOrderConcernID_AutoNumber = " & CurrentWorkOrderConcernID.ToString
        FillWorkOrderConcernJobsDataGridView()
        SaveToolStripMenuItem.Visible = False
        RemovePartToolStripMenuItem.Visible = False
        If Me.Text = "Receive parts from the Customer" Then
            RequisitionDetailsGroupBox.Visible = False
            SubmitRequestForPartsToolStripMenuItem.Visible = False
            RegisterReceivedPartFromCustomerToolStripMenuItem.Visible = True
            ProductDetailsGroupBox.Visible = True
            CustomerSuppliedGroupBox.Visible = True
            RequisitionInformationsGroupBox.Visible = False
            JobGroupBox.Top = RequisitionInformationsGroupBox.Top
            RequisitionDetailsGroupBox.Height = (RequisitionDetailsGroupBox.Top + RequisitionInformationsGroupBox.Top + JobGroupBox.Height) - RequisitionDetailsGroupBox.Top
        Else
            'note: check if there already exists a requisition header for this workorder (unfinished / on preparation requisition for this Concern
            RequisitionDetailsGroupBox.Visible = True
            RegisterReceivedPartFromCustomerToolStripMenuItem.Visible = False
            SubmitRequestForPartsToolStripMenuItem.Visible = True
            WOPartsRequisitionNumberTextBox.Text = "WOR" & CurrentWorkOrderID.ToString & "-" & CurrentWorkOrderConcernID.ToString
            Dim r As DataRow
            SetParentRecordReference("WorkOrderRequestedPartsHeadersTable", "WorkOrderRequestedPartsHeaderNumber_ShortText12", WOPartsRequisitionNumberTextBox.Text)
            If RecordCount > 0 Then
                r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
                WOPartsRequisitionDateTimeTextBox.Text = r("WorkOrderPartsRequisitionDate_ShortDate")
                CurrentWorkOrderRequestedPartsHeaderID = r("WorkOrderRequestedPartsHeaderID_AutoNumber")
                WOPartsRequisitionNumberTextBox.Text = r("WorkOrderPartsRequisitionNumber_ShortText12")
                WOPartsRequisionRevisionTextBox.Text = r("WorkOrderPartsRequisitionRevision_Integer")
                WorkOrderPartsRequisitionStatusID = r("WorkOrderPartsRequisitionStatusID_Integer")
                SetParentRecordReference("StatusesTable", "StatusID_Autonumber", WorkOrderPartsRequisitionStatusID)
                If RecordCount > 0 Then
                    r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
                    RequisitionStatusTextBox.Text = r("StatusText_ShortText25")
                    Select Case RequisitionStatusTextBox.Text
                        Case "Parts Requested"
                            RemovePartToolStripMenuItem.Visible = False
                            AddPartToolStripMenuItem.Visible = False
                        Case "On Preparation"
                            SubmitRequestForPartsToolStripMenuItem.Text = "Print/Submit Requisition Revision " & WOPartsRequisionRevisionTextBox.Text
                        Case "On Revision"
                            SubmitRequestForPartsToolStripMenuItem.Text = "Print/Submit Requisition Revision " & WOPartsRequisionRevisionTextBox.Text
                    End Select
                Else

                    MsgBox("Invalid Status link")
                End If

            Else
                WOPartsRequisitionDateTimeTextBox.Text = Now.ToString
                WOPartsRequisionRevisionTextBox.Text = "0"
                CurrentWorkOrderRequestedPartsHeaderID = -1
                WorkOrderPartsRequisitionStatusID = GetStatusIdFor("WorkOrderRequestedPartsHeadersTable")
                RequisitionStatusTextBox.Text = Tunnel1
            End If
            WorkOrderConcernJobTextBox.Text = "All JOBS"
        End If
        RequisitionDetailsGroupBox.Left = WorkOrderConcernJobsGroupBox.Left + WorkOrderConcernJobsGroupBox.Width
    End Sub
    Private Sub FillWorkOrderConcernJobsDataGridView()
        WorkOrderConcernJobsFieldsToSelect =
"
SELECT 
Trim(InformationsHeadersTypeTable.InformationsHeadersTypePrefix_ShortText50) & Space(1) & MasterCodeBookTable.SystemDesc_ShortText100Fld AS JobDescription, 
WorkOrderConcernJobsTable.WorkOrderConcernJobID_AutoNumber, 
WorkOrderConcernJobsTable.WorkOrderConcernJobStatus_Byte,
WorkOrderConcernsTable.WorkOrderConcernID_AutoNumber, 
WorkOrdersTable.WorkOrderID_AutoNumber, 
InformationsHeadersTable.InformationsHeaderID_AutoNumber,
InformationsHeadersTable.InformationsHeaderDescription_ShortText255,
InformationsHeadersTypeTable.InformationsHeadersTypePrefix_ShortText50, 
MasterCodeBookTable.MasterCodeBookID_Autonumber, 
MasterCodeBookTable.SystemDesc_ShortText100Fld,
StatusesTable.StatusText_ShortText25, 
DoesNotNeedPartsTable.DoesNotNeedPartID_AutoNumber
FROM DoesNotNeedPartsTable RIGHT JOIN ((((((WorkOrderConcernJobsTable LEFT JOIN WorkOrderConcernsTable ON WorkOrderConcernJobsTable.WorkOrderConcernID_LongInteger = WorkOrderConcernsTable.WorkOrderConcernID_AutoNumber) LEFT JOIN WorkOrdersTable ON WorkOrderConcernsTable.WorkOrderID_LongInteger = WorkOrdersTable.WorkOrderID_AutoNumber) LEFT JOIN InformationsHeadersTable ON WorkOrderConcernJobsTable.InformationsHeaderID_LongInteger = InformationsHeadersTable.InformationsHeaderID_AutoNumber) LEFT JOIN MasterCodeBookTable ON InformationsHeadersTable.MasterCodeBookId_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) LEFT JOIN InformationsHeadersTypeTable ON InformationsHeadersTable.InformationsHeadersTypeID_LongInteger = InformationsHeadersTypeTable.InformationsHeadersTypeID_AutoNumber) LEFT JOIN StatusesTable ON WorkOrderConcernJobsTable.WorkOrderConcernJobStatusID_LongInteger = StatusesTable.StatusID_Autonumber) ON DoesNotNeedPartsTable.InformationsHeaderID_LongInteger = InformationsHeadersTable.InformationsHeaderID_AutoNumber
"
        WorkOrderConcernJobsSelectionOrder = ""

        MySelection = WorkOrderConcernJobsFieldsToSelect & WorkOrderConcernJobsSelectionFilter & WorkOrderConcernJobsSelectionOrder

        JustExecuteMySelection()
        WorkOrderConcernJobsRecordCount = RecordCount
        WorkOrderConcernJobsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If Not WorkOrderConcernJobsGridViewAlreadyFormated Then
            WorkOrderConcernJobsGridViewAlreadyFormated = True
            FormatWorkOrderConcernJobsDataGridView()
        End If

        Dim NoOfHeaderLines = 1
        Dim RecordsDisplyed = WorkOrderConcernJobsRecordCount
        If WorkOrderConcernJobsRecordCount > 10 Then
            RecordsDisplyed = 10
        Else
            RecordsDisplyed = WorkOrderConcernJobsRecordCount
        End If
        WorkOrderConcernJobsGroupBox.Height = (WorkOrderConcernJobsDataGridView.ColumnHeadersHeight * NoOfHeaderLines) + (DataGridViewRowHeight * (RecordsDisplyed + 1))

        Dim RequisitionDetailsGroupBoxBottom = RequisitionDetailsGroupBox.Top + RequisitionDetailsGroupBox.Height
        Dim WorkOrderConcernJobsDataGridViewBottom = WorkOrderConcernJobsGroupBox.Top + WorkOrderConcernJobsGroupBox.Height
        If RequisitionDetailsGroupBoxBottom > WorkOrderConcernJobsDataGridViewBottom Then
            WorkOrderPartsGroupBox.Top = RequisitionDetailsGroupBoxBottom
        Else
            WorkOrderPartsGroupBox.Top = WorkOrderConcernJobsDataGridViewBottom
        End If
    End Sub
    Private Sub FormatWorkOrderConcernJobsDataGridView()
        WorkOrderConcernJobsGroupBox.Width = 0
        For i = 0 To WorkOrderConcernJobsDataGridView.Columns.GetColumnCount(0) - 1
            WorkOrderConcernJobsDataGridView.Columns.Item(i).Visible = False
            Select Case WorkOrderConcernJobsDataGridView.Columns.Item(i).HeaderText
                Case "InformationsHeaderDescription_ShortText255"
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).HeaderText = "JOBS"
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).Width = 400
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).Visible = True
                Case "StatusText_ShortText25"
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).HeaderText = "STATUS"
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).Width = 200
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).Visible = True
            End Select

            If WorkOrderConcernJobsDataGridView.Columns.Item(i).Visible = True Then
                WorkOrderConcernJobsGroupBox.Width = WorkOrderConcernJobsGroupBox.Width + WorkOrderConcernJobsDataGridView.Columns.Item(i).Width
            End If
        Next

    End Sub
    Private Sub WorkOrderConcernJobsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles WorkOrderConcernJobsDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If Me.Enabled = False Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If WorkOrderConcernJobsRecordCount = 0 Then Exit Sub

        CurrentWorkOrderConcernJobsRow = e.RowIndex
        WorkOrderConcernJobTextBox.Text = WorkOrderConcernJobsDataGridView.Item("JobDescription", CurrentWorkOrderConcernJobsRow).Value
        CurrentWorkOrderConcernJobID = WorkOrderConcernJobsDataGridView.Item("WorkOrderConcernJobID_AutoNumber", CurrentWorkOrderConcernJobsRow).Value
        CurrentInformationsHeaderID = WorkOrderConcernJobsDataGridView.Item("InformationsHeaderID_AutoNumber", CurrentWorkOrderConcernJobsRow).Value
        WorkOrderPartsSelectionFilter = " WHERE WorkOrderConcernJobID_AutoNumber = " & CurrentWorkOrderConcernJobID.ToString
        Dim CurrentJobStatus = WorkOrderConcernJobsDataGridView.Item("StatusText_ShortText25", CurrentWorkOrderConcernJobsRow).Value
        AddPartToolStripMenuItem.Visible = False
        RemovePartToolStripMenuItem.Visible = False
        EditPartToolStripMenuItem.Visible = False
        RemoveProductToolStripMenuItem.Visible = False
        Select Case CurrentJobStatus
            Case "No Action Yet"
                AddPartToolStripMenuItem.Visible = True
            Case "Assigned"
                AddPartToolStripMenuItem.Visible = True
            Case "Draft Requisition"
                AddPartToolStripMenuItem.Visible = True
        End Select
        FillWorkOrderPartsDataGridView()
        If WorkOrderPartsRecordCount > 0 Then
            GetStandarPartsToolStripMenuItem.Visible = False
        Else
            GetStandarPartsToolStripMenuItem.Visible = True
        End If
    End Sub
    Private Sub AllJOBSButton_Click(sender As Object, e As EventArgs) Handles AllJOBSButton.Click
        WorkOrderConcernJobTextBox.Text = "All JOBS"
        WorkOrderPartsSelectionFilter = " WHERE WorkOrderRequestedPartsHeaderID_LongInteger = " & CurrentWorkOrderRequestedPartsHeaderID.ToString

        FillWorkOrderPartsDataGridView()
    End Sub

    Private Sub FillWorkOrderPartsDataGridView()
        WorkOrderPartsFieldsToSelect =
"
SELECT WorkOrderPartsTable.WorkOrderPartID_AutoNumber, 
MasterCodeBookTable.MasterCodeBookID_Autonumber, 
MasterCodeBookTable.SystemDesc_ShortText100Fld, 
PartNumbersSpecificationsTable.PartNumberSpecifications_ShortText30, 
PartsSpecificationsTable.PartsSpecificationID_AutoNumber, 
PartsSpecificationsTable.PartSpecifications_ShortText255, 
WorkOrderPartsTable.Quantity_Integer, 
WorkOrderPartsTable.Unit_ShortText3, 
WorkOrderPartsTable.ProductPartID_LongInteger, 
StatusesTable.StatusText_ShortText25, 
WorkOrderConcernJobsTable.WorkOrderConcernJobID_AutoNumber, 
InformationsHeadersTable.InformationsHeaderID_AutoNumber, 
WorkOrderPartsTable.CodeVehicleID_LongInteger, 
StatusesTable.StatusID_Autonumber, 
OrderedProductsPartsTable.ManufacturerPartNo_ShortText30Fld, 
OrderedProductsPartsTable.ManufacturerDescription_ShortText250
FROM ((((((((WorkOrderPartsTable LEFT JOIN MasterCodeBookTable ON WorkOrderPartsTable.MasterCodeBookID_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) LEFT JOIN WorkOrderConcernJobsTable ON WorkOrderPartsTable.WorkOrderConcernJobID_LongInteger = WorkOrderConcernJobsTable.WorkOrderConcernJobID_AutoNumber) LEFT JOIN InformationsHeadersTable ON WorkOrderPartsTable.InformationsHeaderID_LongInteger = InformationsHeadersTable.InformationsHeaderID_AutoNumber) LEFT JOIN StatusesTable ON WorkOrderPartsTable.WorkOrderPartStatusID_LongInteger = StatusesTable.StatusID_Autonumber) LEFT JOIN ProductsPartsTable AS OrderedProductsPartsTable ON WorkOrderPartsTable.ProductPartID_LongInteger = OrderedProductsPartsTable.ProductsPartID_Autonumber) LEFT JOIN CodeVehiclePartNumbersSpecificationsRelationsTable ON WorkOrderPartsTable.CodeVehicleID_LongInteger = CodeVehiclePartNumbersSpecificationsRelationsTable.CodeVehicleID_LongInteger) LEFT JOIN CodeVehiclePartsSpecificationsRelationsTable ON WorkOrderPartsTable.CodeVehicleID_LongInteger = CodeVehiclePartsSpecificationsRelationsTable.CodeVehicleID_LongInteger) LEFT JOIN PartsSpecificationsTable ON CodeVehiclePartsSpecificationsRelationsTable.PartsSpecificationID_LongInteger = PartsSpecificationsTable.PartsSpecificationID_AutoNumber) LEFT JOIN PartNumbersSpecificationsTable ON CodeVehiclePartNumbersSpecificationsRelationsTable.PartNumbersSpecificationID_LongInteger = PartNumbersSpecificationsTable.PartNUmbersSpecificationID_AutoNumber
"

        MySelection = WorkOrderPartsFieldsToSelect & WorkOrderPartsSelectionFilter & WorkOrderPartsSelectionOrder
        JustExecuteMySelection()
        WorkOrderPartsRecordCount = RecordCount
        If WorkOrderPartsRecordCount > 0 Then
            WorkOrderPartsGroupBox.Visible = True
        Else
            WorkOrderPartsGroupBox.Visible = True
        End If
        CustomerSuppliedPartsGroupBox.Visible = False
        WorkOrderRequestedPartsGroupBox.Visible = False
        WorkOrderPartsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        If Not WorkOrderPartsGridViewAlreadyFormated Then
            FormatWorkOrderPartsDataGridView()
        End If

        Dim RecordsToDisplay = 7
        SetGroupBoxHeight(RecordsToDisplay, WorkOrderPartsRecordCount, WorkOrderPartsGroupBox, WorkOrderPartsDataGridView)
    End Sub
    Private Sub FormatWorkOrderPartsDataGridView()
        WorkOrderPartsGridViewAlreadyFormated = True
        WorkOrderPartsGroupBox.Width = 0
        For i = 0 To WorkOrderPartsDataGridView.Columns.GetColumnCount(0) - 1

            WorkOrderPartsDataGridView.Columns.Item(i).Visible = False
            Select Case WorkOrderPartsDataGridView.Columns.Item(i).Name
                Case "SystemDesc_ShortText100Fld"
                    WorkOrderPartsDataGridView.Columns.Item(i).HeaderText = "Part Required"
                    WorkOrderPartsDataGridView.Columns.Item(i).Width = 250
                    WorkOrderPartsDataGridView.Columns.Item(i).Visible = True
                Case "Quantity_Integer"
                    WorkOrderPartsDataGridView.Columns.Item(i).HeaderText = "Spec Qty"
                    WorkOrderPartsDataGridView.Columns.Item(i).Width = 60
                    WorkOrderPartsDataGridView.Columns.Item(i).Visible = True
                Case "Unit_ShortText3"
                    WorkOrderPartsDataGridView.Columns.Item(i).HeaderText = "Spec Unit"
                    WorkOrderPartsDataGridView.Columns.Item(i).Width = 100
                    WorkOrderPartsDataGridView.Columns.Item(i).Visible = True
                Case "PartNumberSpecifications_ShortText30"
                    WorkOrderPartsDataGridView.Columns.Item(i).HeaderText = "Part # Specifications"
                    WorkOrderPartsDataGridView.Columns.Item(i).Width = 200
                    WorkOrderPartsDataGridView.Columns.Item(i).Visible = True
                    WorkOrderPartsDataGridView.Columns.Item(i).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                Case "PartsSpecifications_ShortText255"
                    WorkOrderPartsDataGridView.Columns.Item(i).HeaderText = "Part Specifications"
                    WorkOrderPartsDataGridView.Columns.Item(i).Width = 400
                    WorkOrderPartsDataGridView.Columns.Item(i).Visible = True
                    WorkOrderPartsDataGridView.Columns.Item(i).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                Case "StatusText_ShortText25"
                    WorkOrderPartsDataGridView.Columns.Item(i).HeaderText = "Status"
                    WorkOrderPartsDataGridView.Columns.Item(i).Width = 120
                    WorkOrderPartsDataGridView.Columns.Item(i).Visible = True
            End Select
            If WorkOrderPartsDataGridView.Columns.Item(i).Visible = True Then
                WorkOrderPartsGroupBox.Width = WorkOrderPartsGroupBox.Width + WorkOrderPartsDataGridView.Columns.Item(i).Width
            End If
        Next
        If WorkOrderPartsGroupBox.Width > Me.Width Then
            WorkOrderPartsGroupBox.Width = Me.Width - 8 - 4
        End If
        HorizontalCenter(WorkOrderPartsGroupBox, Me)

        '        WorkOrderPartsGroupBox.Left = 5
    End Sub

    Private Sub WorkOrderPartsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles WorkOrderPartsDataGridView.RowEnter

        If ShowInTaskbarFlag Then Exit Sub
        If Me.Enabled = False Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If WorkOrderPartsRecordCount = 0 Then Exit Sub
        Dim xxProduct = ""
        Dim CurrentPartStatus = ""
        CurrentWorkOrderPartsRow = e.RowIndex
        If IsNotEmpty(WorkOrderPartsDataGridView.Item("MasterCodeBookID_Autonumber", CurrentWorkOrderPartsRow).Value) Then
            CurrentMasterCodeBookID = WorkOrderPartsDataGridView.Item("MasterCodeBookID_Autonumber", CurrentWorkOrderPartsRow).Value
        Else
            CurrentMasterCodeBookID = -1
        End If
        FillField(CurrentWorkOrderPartID, WorkOrderPartsDataGridView.Item("WorkOrderPartID_AutoNumber", CurrentWorkOrderPartsRow).Value)
        FillField(CurrentCodeVehicleID, WorkOrderPartsDataGridView.Item("CodeVehicleID_LongInteger", CurrentWorkOrderPartsRow).Value)
        FillField(CurrentPartsSpecificationID, WorkOrderPartsDataGridView.Item("PartsSpecificationID_AutoNumber", CurrentWorkOrderPartsRow).Value)
        FillField(xxProduct, WorkOrderPartsDataGridView.Item("ManufacturerDescription_ShortText250", CurrentWorkOrderPartsRow).Value)
        FillField(CurrentPartStatus, WorkOrderPartsDataGridView.Item("StatusText_ShortText25", CurrentWorkOrderPartsRow).Value)
        '        If GetStandardPartsFlag Then Exit Sub

        'FOLLOWING UPDATES THOSE OLD RECORDS WITH NO CODEVEHICLE REFERENCE
        '       If IsEmpty(xxProduct) Then
        '       RemoveProductToolStripMenuItem.Visible = False
        '       Else
        '       RemoveProductToolStripMenuItem.Visible = True
        '      End If
        If CurrentCodeVehicleID < 1 Then
            MsgBox("CodeVehicleID is not updated" & vbCrLf & "Will be  updated")
            GetCodeVehicleID(CurrentMasterCodeBookID, CurrentVehicleID)
            Dim RecordFilter = " WHERE WorkOrderPartID_AutoNumber = " & CurrentWorkOrderPartID.ToString
            Dim SetCommand = " SET CodeVehicleID_LongInteger = " & CurrentCodeVehicleID.ToString
            UpdateTable("WorkOrderPartsTable", SetCommand, RecordFilter)
        End If

        WorkOrderRequestedPartsSelectionFilter = " WHERE WorkOrderPartID_LongInteger = " & CurrentWorkOrderPartID.ToString
        FillWorkOrderRequestedPartsDataGridView()

        CustomerSuppliedPartsSelectionFilter = " WHERE WorkOrderPartID_LongInteger = " & CurrentWorkOrderPartID.ToString
        FillCustomerSuppliedPartsDataGridView()
        EditPartToolStripMenuItem.Visible = False
        RemovePartToolStripMenuItem.Visible = False
        Select Case CurrentPartStatus
            Case ""
                MsgBox("WorkOrderPart with null status, now set, delete this routine when all records are fixed")
                Dim xxStatusID = 0
                If RegisterReceivedPartFromCustomerToolStripMenuItem.Visible Then
                    xxStatusID = GetStatusIdFor("WorkOrderPartsTable", "Draft From Customer")
                Else
                    xxStatusID = GetStatusIdFor("WorkOrderPartsTable", "Draft Requisition")
                End If
                Dim RecordFilter = " WHERE WorkOrderPartID_AutoNumber = " & CurrentWorkOrderPartID.ToString
                Dim SetCommand = " SET WorkOrderPartStatusID_LongInteger = " & xxStatusID.ToString
                UpdateTable("WorkOrderPartsTable", SetCommand, RecordFilter)
            Case "Draft Requisition"
                EditPartToolStripMenuItem.Visible = True
                RemovePartToolStripMenuItem.Visible = True
            Case "No Action Yet"
                EditPartToolStripMenuItem.Visible = True
                RemovePartToolStripMenuItem.Visible = True
            Case "Draft From Customer"
                EditPartToolStripMenuItem.Visible = True
                RemovePartToolStripMenuItem.Visible = True
        End Select

        Dim RecordsToDisplay = 7
        SetGroupBoxHeight(RecordsToDisplay, CustomerSuppliedPartsRecordCount, CustomerSuppliedPartsGroupBox, CustomerSuppliedPartsDataGridView)
        SetTopPositionsOfTheGroupBoxes()

    End Sub
    Private Sub SetTopPositionsOfTheGroupBoxes()
        If WorkOrderRequestedPartsGroupBox.Visible Then
            WorkOrderRequestedPartsGroupBox.Top = WorkOrderPartsGroupBox.Top + WorkOrderPartsGroupBox.Height
            CustomerSuppliedPartsGroupBox.Top = WorkOrderRequestedPartsGroupBox.Top + WorkOrderRequestedPartsGroupBox.Height
        Else
            CustomerSuppliedPartsGroupBox.Top = WorkOrderPartsGroupBox.Top + WorkOrderPartsGroupBox.Height
        End If
    End Sub


    Private Sub FillWorkOrderRequestedPartsDataGridView()
        WorkOrderRequestedPartsFieldsToSelect =
" 
SELECT 
ProductsPartsTable.ProductsPartID_Autonumber, 
ProductsPartsTable.Unit_ShortText3, 
ProductPartPackingsQuery.QuantityPerPack_Double, 
ProductPartPackingsQuery.UnitOfTheQuantity_ShortText3, 
WorkOrderRequestedPartsTable.WorkOrderRequestedPartsHeaderID_LongInteger, 
PartsSpecificationsTable.PartSpecifications_ShortText255, 
WorkOrderRequestedPartsTable.WorkOrderRequestedPartID_AutoNumber, 
WorkOrderRequestedPartsTable.RequestedQuantity_Double, 
WorkOrderRequestedPartsTable.RequestedUnit_ShortText3, 
ProductsPartsTable.ManufacturerPartNo_ShortText30Fld, 
ProductsPartsTable.ManufacturerDescription_ShortText250, 
WorkOrderRequestedPartsTable.WorkOrderRequestedPartStatus_Integer, 
WorkOrderRequestedPartsHeadersTable.WorkOrderRequestedPartsHeaderRevision_Integer, 
WorkOrderRequestedPartsHeadersTable.WorkOrderRequestedPartsHeaderNumber_ShortText12, 
WorkOrderRequestedPartsHeadersTable.WorkOrderRequestedPartsHeaderDate_ShortDate, 
WorkOrderRequestedPartsHeadersTable.RequestedByID_LongInteger, 
WorkOrderRequestedPartsHeadersTable.WorkOrderRequestedPartsHeaderStatusID_Integer
FROM ((WorkOrderRequestedPartsTable LEFT JOIN (ProductsPartsTable LEFT JOIN ProductPartPackingsQuery ON ProductsPartsTable.ProductsPartID_Autonumber = ProductPartPackingsQuery.ProductPartID_LongInteger) ON WorkOrderRequestedPartsTable.ProductPartID_LongInteger = ProductsPartsTable.ProductsPartID_Autonumber) LEFT JOIN PartsSpecificationsTable ON WorkOrderRequestedPartsTable.SpecificationID_LongInteger = PartsSpecificationsTable.PartsSpecificationID_AutoNumber) LEFT JOIN WorkOrderRequestedPartsHeadersTable ON WorkOrderRequestedPartsTable.WorkOrderRequestedPartsHeaderID_LongInteger = WorkOrderRequestedPartsHeadersTable.WorkOrderRequestedPartsHeaderID_AutoNumber

"
        MySelection = WorkOrderRequestedPartsFieldsToSelect & WorkOrderRequestedPartsSelectionFilter
        JustExecuteMySelection()
        WorkOrderRequestedPartsRecordCount = RecordCount
        If WorkOrderRequestedPartsRecordCount > 0 Then
            WorkOrderRequestedPartsGroupBox.Visible = True
        Else
            WorkOrderRequestedPartsGroupBox.Visible = False
        End If
        WorkOrderRequestedPartsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If Not WorkOrderRequestedPartsGridViewAlreadyFormated Then
            WorkOrderRequestedPartsGridViewAlreadyFormated = True
            FormatWorkOrderRequestedPartsDataGridView()
        End If

        Dim RecordsToDisplay = 7
        SetGroupBoxHeight(RecordsToDisplay, WorkOrderRequestedPartsRecordCount, WorkOrderRequestedPartsGroupBox, WorkOrderRequestedPartsDataGridView)
        SetTopPositionsOfTheGroupBoxes()
    End Sub

    Private Sub FormatWorkOrderRequestedPartsDataGridView()
        WorkOrderRequestedPartsGroupBox.Width = 0
        For i = 0 To WorkOrderRequestedPartsDataGridView.Columns.GetColumnCount(0) - 1

            WorkOrderRequestedPartsDataGridView.Columns.Item(i).Visible = False
            Select Case WorkOrderRequestedPartsDataGridView.Columns.Item(i).Name
                Case "ManufacturerPartNo_ShortText30Fld"
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).HeaderText = "Manuf Part Number"
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).Width = 150
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).Visible = True
                Case "ManufacturerDescription_ShortText250"
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).HeaderText = "Product "
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).Width = 400
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).Visible = True
                Case "RequestedQuantity_Double"
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).HeaderText = "Requested QTY"
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).Width = 100
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).Visible = True
                Case "RequestedUnit_ShortText3"
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).HeaderText = "UNIT"
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).Width = 100
                    WorkOrderRequestedPartsDataGridView.Columns.Item(i).Visible = True
            End Select
            If WorkOrderRequestedPartsDataGridView.Columns.Item(i).Visible = True Then
                WorkOrderRequestedPartsGroupBox.Width = WorkOrderRequestedPartsGroupBox.Width + WorkOrderRequestedPartsDataGridView.Columns.Item(i).Width
            End If
        Next
        If WorkOrderRequestedPartsGroupBox.Width > Me.Width Then
            WorkOrderRequestedPartsGroupBox.Width = Me.Width - 4
        End If
        HorizontalCenter(WorkOrderRequestedPartsGroupBox, Me)
    End Sub

    Private Sub WorkOrderRequestedPartsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles WorkOrderRequestedPartsDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If Me.Enabled = False Then Exit Sub
        RemoveProductToolStripMenuItem.Visible = False
        If e.RowIndex < 0 Then Exit Sub
        If WorkOrderRequestedPartsRecordCount = 0 Then Exit Sub

        RemoveProductToolStripMenuItem.Text = "Remove Requested Part"
        RemoveProductToolStripMenuItem.Visible = True
        CurrentWorkOrderRequestedPartsRow = e.RowIndex
        FillField(CurrentWorkOrderRequestedPartID, NotNull(WorkOrderRequestedPartsDataGridView.Item("WorkOrderRequestedPartID_AutoNumber", CurrentWorkOrderRequestedPartsRow).Value))
    End Sub

    Private Sub FillCustomerSuppliedPartsDataGridView()

        CustomerSuppliedPartsFieldsToSelect =
"
SELECT 
WorkOrderReceivedPartsTable.WorkOrderPartID_LongInteger, 
WorkOrderReceivedPartsTable.WorkOrderReceivedPartID_AutoNumber, 
ProductsPartsTable.ProductsPartID_Autonumber, 
ProductsPartsTable.ManufacturerPartNo_ShortText30Fld, 
ProductsPartsTable.ManufacturerDescription_ShortText250, 
WorkOrderReceivedPartsTable.ReceivedQuantity_Double, 
ProductsPartsTable.Unit_ShortText3, 
ProductPartPackingsQuery.QuantityPerPack_Double, 
ProductPartPackingsQuery.UnitOfTheQuantity_ShortText3
FROM (WorkOrderReceivedPartsTable LEFT JOIN ProductsPartsTable ON WorkOrderReceivedPartsTable.ProductPartID_LongInteger = ProductsPartsTable.ProductsPartID_Autonumber) LEFT JOIN ProductPartPackingsQuery ON ProductsPartsTable.ProductsPartID_Autonumber = ProductPartPackingsQuery.ProductPartID_LongInteger
"
        MySelection = CustomerSuppliedPartsFieldsToSelect & CustomerSuppliedPartsSelectionFilter
        JustExecuteMySelection()
        CustomerSuppliedPartsRecordCount = RecordCount
        If CustomerSuppliedPartsRecordCount > 0 Then
            CustomerSuppliedPartsGroupBox.Visible = True
        Else
            CustomerSuppliedPartsGroupBox.Visible = False
        End If
        CustomerSuppliedPartsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If Not CustomerSuppliedPartsGridViewAlreadyFormated Then
            CustomerSuppliedPartsGridViewAlreadyFormated = True
            FormatCustomerSuppliedPartsDataGridView()
        End If

        Dim RecordsToDisplay = 7
        SetGroupBoxHeight(RecordsToDisplay, CustomerSuppliedPartsRecordCount, CustomerSuppliedPartsGroupBox, CustomerSuppliedPartsDataGridView)
        SetTopPositionsOfTheGroupBoxes()
    End Sub
    Private Sub FormatCustomerSuppliedPartsDataGridView()
        CustomerSuppliedPartsGroupBox.Width = 0
        For i = 0 To CustomerSuppliedPartsDataGridView.Columns.GetColumnCount(0) - 1

            CustomerSuppliedPartsDataGridView.Columns.Item(i).Visible = False
            Select Case CustomerSuppliedPartsDataGridView.Columns.Item(i).Name
                Case "ManufacturerPartNo_ShortText30Fld"
                    CustomerSuppliedPartsDataGridView.Columns.Item(i).HeaderText = "Manuf Part Number"
                    CustomerSuppliedPartsDataGridView.Columns.Item(i).Width = 150
                    CustomerSuppliedPartsDataGridView.Columns.Item(i).Visible = True
                Case "ManufacturerDescription_ShortText250"
                    CustomerSuppliedPartsDataGridView.Columns.Item(i).HeaderText = "Product "
                    CustomerSuppliedPartsDataGridView.Columns.Item(i).Width = 400
                    CustomerSuppliedPartsDataGridView.Columns.Item(i).Visible = True
                Case "ReceivedQuantity_Double"
                    CustomerSuppliedPartsDataGridView.Columns.Item(i).HeaderText = "Received QTY"
                    CustomerSuppliedPartsDataGridView.Columns.Item(i).Width = 100
                    CustomerSuppliedPartsDataGridView.Columns.Item(i).Visible = True
                Case "Unit_ShortText3"
                    CustomerSuppliedPartsDataGridView.Columns.Item(i).HeaderText = "UNIT"
                    CustomerSuppliedPartsDataGridView.Columns.Item(i).Width = 100
                    CustomerSuppliedPartsDataGridView.Columns.Item(i).Visible = True
            End Select
            If CustomerSuppliedPartsDataGridView.Columns.Item(i).Visible = True Then
                CustomerSuppliedPartsGroupBox.Width = CustomerSuppliedPartsGroupBox.Width + CustomerSuppliedPartsDataGridView.Columns.Item(i).Width
            End If
        Next
        If CustomerSuppliedPartsGroupBox.Width > Me.Width Then
            CustomerSuppliedPartsGroupBox.Width = Me.Width - 4
        End If
        HorizontalCenter(CustomerSuppliedPartsGroupBox, Me)
    End Sub

    Private Sub CustomerSuppliedPartsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles CustomerSuppliedPartsDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If Me.Enabled = False Then Exit Sub
        RemoveProductToolStripMenuItem.Visible = False
        If e.RowIndex < 0 Then Exit Sub
        If CustomerSuppliedPartsRecordCount = 0 Then Exit Sub

        RemoveProductToolStripMenuItem.Text = "Remove Received Part"
        RemoveProductToolStripMenuItem.Visible = True
        CurrentCustomerSuppliedPartsRow = e.RowIndex
        FillField(CurrentCustomerSuppliedPartID, NotNull(CustomerSuppliedPartsDataGridView.Item("WorkOrderReceivedPartID_AutoNumber", CurrentCustomerSuppliedPartsRow).Value))
    End Sub
    Private Sub ReturnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnToolStripMenuItem.Click
        If SaveToolStripMenuItem.Visible = True Then
            SaveChanges()
        Else
            DoCommonHouseKeeping(Me, SavedCallingForm)
        End If
    End Sub
    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        SaveChanges()
    End Sub
    Private Sub SaveChanges()

        If AChangeInSpecificationsOccured() Then
            RegisterSpecificationsChanges()
        End If
        If AChangeInWorkOrderPartsOccured() Then
            If Not ValidPartEntries() Then Exit Sub
            RegisterWorkOrderPartsChanges()
        End If
        If AChangeInWorkOrderRequestPartsOccured() Then
            If Not ValidRequestedPartsEntries() Then Exit Sub
            RegisterWorkOrderRequestedPartChanges()
        End If
        If CurrentWorkOrderPartID < 0 Then Exit Sub 'NOTE THERE IS NO PART SO NO NEED FOR PRODUCT
        If Me.Text = "Receive parts from the Customer" Then
            If AChangeInCustomerSuppliedPartsOccured() Then
                If Not ValidCustomerSuppliedParts() Then Exit Sub
                SaveReceivedPartsChanges()
            End If
        Else
            SaveOrderChanges()
        End If
        FillWorkOrderPartsDataGridView()
        PartDetailsGroupBox.Visible = False
        SaveToolStripMenuItem.Visible = False
    End Sub
    Private Function AChangeInSpecificationsOccured()
        If CurrentQuantitySpecificationsID = -1 Then
            If NotEmpty(SpecifiedQuantityTextBox.Text) Then Return True
            Return False
        End If

        'HERE AN OLD VOLUME INFO ALREADY EXISTS
        MySelection = " Select top 1 * FROM QuantitySpecificationsTable WHERE QuantitySpecificationID_AutoNumber = " & CurrentQuantitySpecificationsID.ToString
        JustExecuteMySelection()
        Dim r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        If Not SpecifiedQuantityTextBox.Text = r("SpecifiedQuantity_Double") Then Return True
        If Not SpecifiedUnitTextBox.Text = r("SpecifiedUnit_ShortText3") Then Return True
        Return False
    End Function
    Private Function ValidRequestedPartsEntries()
        If IsEmpty(RequestedQuantityTextBox.Text) Then
            MsgBox("Required / Ordered quantity required")
            RequestedQuantityTextBox.Select()
            Return False
        End If
        Return True
    End Function
    Private Function ValidPartEntries()
        If IsEmpty(PartDescriptionTextBox.Text) Then
            MsgBox("No Part is entered")
            PartDescriptionTextBox.Select()
            Return False
        End If
        Return True
    End Function
    Private Function ValidProductEntries()
        If Me.Text = "Receive parts from the Customer" Then
            If IsEmpty(CustomerSuppliedQuantityTextBox.Text) Then
                MsgBox("customer supplied quantity required")
                CustomerSuppliedQuantityTextBox.Select()
                Return False
            End If
        End If
        Return True
    End Function
    Private Sub SaveOrderChanges()
        If Not ValidProductEntries() Then Exit Sub

        If AChangeInOrderedProductOccured() Then
            Dim xxmsgResult = MsgBox("Save Changes in the Product informations?", MsgBoxStyle.YesNoCancel)
            If xxmsgResult = vbNo Then
                RequisitionDetailsGroupBox.Visible = False
                Exit Sub
            ElseIf xxmsgResult = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            RegisterRequestedProductChanges()
        End If
    End Sub
    Private Sub SaveReceivedPartsChanges()
        ChangesOccured = True
        Dim xxmsgResult = MsgBox("Save RECEIVED PART informations changes?", MsgBoxStyle.YesNoCancel)
        If xxmsgResult = vbNo Then
            RequisitionDetailsGroupBox.Visible = False
            Exit Sub
        ElseIf xxmsgResult = MsgBoxResult.Cancel Then
            Exit Sub
        End If
        RegisterCustomerSuppliedPartsChanges()

    End Sub
    Private Function AChangeInWorkOrderRequestPartsOccured()

        '*******************************************************
        If WorkOrderPartsRecordCount > -1 Then
            If TheseAreNotEqual(RequestedQuantityTextBox.Text, WorkOrderRequestedPartsDataGridView.Item("RequestedQuantity_Double", CurrentWorkOrderPartsRow).Value, PurposeOfEntry) Then Return True
        End If
        Return False
    End Function
    Private Function AChangeInWorkOrderPartsOccured()

        '*******************************************************
        ' CHECK THIS THE TheseAreNotEqual ROUTINE WAS MODIFIED, WATCH PARAMETER pURPOSEOFENTRY
        If WorkOrderPartsRecordCount = -1 Then
            If Trim(PartDescriptionTextBox.Text) <> "" Then Return True
            Return False
        Else
            If CurrentWorkOrderPartsRow > -1 Then
                If TheseAreNotEqual(PartDescriptionTextBox.Text, WorkOrderPartsDataGridView.Item("SystemDesc_ShortText100Fld", CurrentWorkOrderPartsRow).Value, PurposeOfEntry) Then Return True
            Else
                If IsNotEmpty(PartDescriptionTextBox.Text) Then Return True
            End If
        End If
        Return False
    End Function
    Private Function AChangeInOrderedProductOccured()
        If TheseAreNotEqual(ProductTextBox.Text, WorkOrderPartsDataGridView.Item("ManufacturerDescription_ShortText250", CurrentWorkOrderPartsRow).Value, PurposeOfEntry) Then Return True
        If TheseAreNotEqual(PartNumberTextBox.Text, WorkOrderPartsDataGridView.Item("ManufacturerPartNo_ShortText30Fld", CurrentWorkOrderPartsRow).Value, PurposeOfEntry) Then Return True
        If SubmitRequestForPartsToolStripMenuItem.Visible Then
            If TheseAreNotEqual(RequestedQuantityTextBox.Text, WorkOrderPartsDataGridView.Item("Quantity_Integer", CurrentWorkOrderPartsRow).Value, PurposeOfEntry) Then Return True
        Else
            If TheseAreNotEqual(CustomerSuppliedQuantityTextBox.Text, WorkOrderPartsDataGridView.Item("Quantity_Integer", CurrentWorkOrderPartsRow).Value, PurposeOfEntry) Then Return True
        End If
        Return False
    End Function
    Private Function AChangeInCustomerSuppliedPartsOccured()
        If CustomerSuppliedPartsRecordCount < 1 Then Return True 'NEWLY INSERTED CUSTOMER SUPPLIED PART
        If TheseAreNotEqual(ProductTextBox.Text, NotNull(CustomerSuppliedPartsDataGridView.Item("ManufacturerDescription_ShortText250", CurrentCustomerSuppliedPartsRow).Value), PurposeOfEntry) Then Return True
        If TheseAreNotEqual(CustomerSuppliedQuantityTextBox.Text, NotNull(CustomerSuppliedPartsDataGridView.Item("ReceivedQuantity_Double", CurrentCustomerSuppliedPartsRow).Value), PurposeOfEntry) Then Return True
        If TheseAreNotEqual(CustomerSuppliedUnitTextBox.Text, NotNull(CustomerSuppliedPartsDataGridView.Item("Unit_ShortText3", CurrentWorkOrderPartsRow).Value), PurposeOfEntry) Then Return True
        Return False
    End Function
    Private Sub RegisterSpecificationsChanges()
        If CurrentQuantitySpecificationsID = -1 Then
            InsertQuantitySpecificationsTable()
        Else
            UpdateQuantitySpecificationsTable()
        End If

    End Sub
    Private Sub InsertQuantitySpecificationsTable()
        Dim FieldsToUpdate = "  InformationsHeaderID_LongInteger, " &
                       "  CodeVehicleID_LongInteger, " &
                       "  SpecifiedQuantity_Double, " &
                       "  SpecifiedUnit_ShortText3, " &
                       "  LastUpdatedBy_longInteger, " &
                       "  LastDateUpdated_DateTime "

        Dim FieldsData = CurrentInformationsHeaderID.ToString & ",  " &
                                  CurrentCodeVehicleID.ToString & ",  " &
                                  SpecifiedQuantityTextBox.Text & ",  " &
                                  InQuotes(SpecifiedUnitTextBox.Text) & ",  " &
                                  CurrentPersonelID.ToString & ",  " &
                                  InQuotes(Now())

        CurrentQuantitySpecificationsID = InsertNewRecord("QuantitySpecificationsTable", FieldsToUpdate, FieldsData)


    End Sub
    Private Sub UpdateQuantitySpecificationsTable()
        If MsgBox("About to replace CHANGES IN SPECIFICATIONS, Continue ?", MsgBoxStyle.YesNo) = vbNo Then
            Exit Sub
        End If
        Dim RecordFilter = " WHERE QuantitySpecificationID_AutoNumber = " & CurrentQuantitySpecificationsID.ToString
        Dim SetCommand = " SET InformationsHeaderID_LongInteger = " & CurrentInformationsHeaderID.ToString & "," &
                                      " CodeVehicleID_LongInteger = " & CurrentCodeVehicleID.ToString & ",  " &
                                      " SpecifiedQuantity_Double = " & SpecifiedQuantityTextBox.Text & "," &
                                      " SpecifiedUnit_ShortText3 = " & InQuotes(SpecifiedUnitTextBox.Text) & ",  " &
                                      " LastUpdatedBy_longInteger = " & CurrentPersonelID.ToString & ",  " &
                                      " LastDateUpdated_DateTime = " & InQuotes(Now())
        UpdateTable("QuantitySpecificationsTable", SetCommand, RecordFilter)
    End Sub
    Private Sub RegisterWorkOrderPartsChanges()
        MySelection = " Select top 1 * FROM WorkOrderPartsTable WHERE WorkOrderPartID_AutoNumber = " & CurrentWorkOrderPartID.ToString

        JustExecuteMySelection()
        If RecordCount = 0 Then
            InsertNewWorkOrderPart()
        Else
            UpdateWorkOrderPart()
        End If

        FillWorkOrderPartsDataGridView()
    End Sub
    Private Sub InsertNewWorkOrderPart()
        MsgBox("check this, " & vbCrLf & "the field workorderid was restored but can be deleted once jobs and concerns are updated")
        Dim xxStatusID = 0
        If RegisterReceivedPartFromCustomerToolStripMenuItem.Visible Then
            xxStatusID = GetStatusIdFor("WorkOrderPartsTable", "Draft From Customer")
        Else
            xxStatusID = GetStatusIdFor("WorkOrderPartsTable", "Draft Requisition")
        End If
        Dim FieldsToUpdate = "  WorkOrderRequestedPartsHeaderID_LongInteger, " &
                       "  WorkOrderID_LongInteger, " &
                       "  WorkOrderConcernJobID_LongInteger, " &
                       "  InformationsHeaderID_LongInteger, " &
                       "  MasterCodeBookID_LongInteger, " &
                       "  CodeVehicleID_LongInteger, " &
                       "  Quantity_Integer, " &
                       " WorkOrderPartStatusID_LongInteger "

        Dim FieldsData = CurrentWorkOrderRequestedPartsHeaderID.ToString & ",  " &
                                  CurrentWorkOrderID.ToString & ",  " &
                                  CurrentWorkOrderConcernJobID.ToString & ",  " &
                                  CurrentInformationsHeaderID.ToString & ",  " &
                                  CurrentMasterCodeBookID.ToString & ",  " &
                                  CurrentCodeVehicleID.ToString & ",  " &
                                  Val(RequestedQuantityTextBox.Text).ToString & ",  " &
                                  xxStatusID.ToString

        CurrentWorkOrderPartID = InsertNewRecord("WorkOrderPartsTable", FieldsToUpdate, FieldsData)


        'since parts are already linked the WorkOrderConcernJobsTable status should be updated
        MySelection = " UPDATE WorkOrderConcernJobsTable SET " &
                            " WorkOrderConcernJobStatusID_LongInteger = " & GetStatusIdFor("WorkOrderConcernJobsTable", "Draft Requisition") &
                            " WHERE WorkOrderConcernJobID_AutoNumber = " & CurrentWorkOrderConcernJobID.ToString
        JustExecuteMySelection()
    End Sub
    Private Sub UpdateWorkOrderPart()
        If MsgBox("About to update changes in the work order parts informations, Continue ?", MsgBoxStyle.YesNo) = vbNo Then
            Exit Sub
        End If
        Dim RecordFilter = " WHERE WorkOrderPartID_AutoNumber = " & CurrentWorkOrderPartID.ToString
        Dim SetCommand = " SET MasterCodeBookID_LongInteger = " & CurrentMasterCodeBookID.ToString & "," &
                                      " Unit_ShortText3 = " & Chr(34) & LTrim(Trim(SpecifiedUnitTextBox.Text)) & Chr(34) & "," &
                                      " Quantity_Integer = " & Val(RequestedQuantityTextBox.Text).ToString
        UpdateTable("WorkOrderPartsTable", SetCommand, RecordFilter)
    End Sub
    Private Sub RegisterRequestedProductChanges()
    End Sub
    Private Sub RegisterWorkOrderRequestedPartChanges()

        If CurrentWorkOrderRequestedPartsHeaderID = -1 Then
            InsertNewWorkOrderWorkOrderRequestedPart()
        Else
            UpdateWorkOrderWorkOrderRequestedPart()
        End If
        If MsgBox("About to replace original informations, Continue ?", MsgBoxStyle.YesNo) = vbNo Then
            Exit Sub
        End If
    End Sub
    Private Sub InsertNewWorkOrderWorkOrderRequestedPart()
        Dim FieldsToUpdate =
                           "  WorkOrderPartID_LongInteger, " &
                           "  WorkOrderRequestedPartsHeaderID_LongInteger, " &
                           "  SpecificationID_LongInteger, " &
                           "  RequestedQuantity_Double, " &
                           "  RequestedUnit_ShortText3, " &
                           "  ProductPartID_LongInteger, " &
                           "  WorkOrderRequestedPartStatus_Integer "
        Dim FieldsData =
                                CurrentWorkOrderPartID.ToString & ", " &
                                CurrentWorkOrderRequestedPartsHeaderID.ToString & ", " &
                                CurrentPartsSpecificationID.ToString & ", " &
                                RequestedQuantityTextBox.Text & ", " &
                                InQuotes(RequestedUnitTextBox.Text) & ", " &
                                CurrentProductPartID.ToString & ", " &
                                GetStatusIdFor("WorkOrderRequestedPartsTable").ToString

        Dim xxWorkOrderRequestedPart = InsertNewRecord("WorkOrderRequestedPartsTable", FieldsToUpdate, FieldsData)
    End Sub
    Private Sub UpdateWorkOrderWorkOrderRequestedPart()
        Dim RecordFilter = " WHERE WorkOrderRequestedPartID_AutoNumber = " & CurrentWorkOrderRequestedPartsHeaderID.ToString
        Dim SetCommand = " SET ProductPartID_LongInteger = " & CurrentProductPartID.ToString & ", " &
                         "  ProductPartID_LongInteger = " & CurrentProductPartID.ToString & ", " &
                         " SET RequestedQuantity_Double = " & RequestedQuantityTextBox.Text & ", " &
                         " SET RequestedUnit_ShortText3 = " & RequestedUnitTextBox.Text
        UpdateTable("WorkOrderRequestedPartsTable", SetCommand, RecordFilter)
    End Sub

    Private Sub RegisterCustomerSuppliedPartsChanges()
        MySelection = " Select top 1 * FROM CustomerSuppliedPartsTable WHERE CustomerSuppliedPartID_AutoNumber = " & CurrentCustomerSuppliedPartID.ToString &
                                      " AND ProductPartID_LongInteger = " & CurrentProductPartID.ToString

        JustExecuteMySelection()
        If RecordCount = 0 Then
            InsertNewWorkOrderWorkOrderReceivedPart()     'TESTED PASS
        Else
            UpdateWorkOrderWorkOrderReceivedPart()
        End If
    End Sub
    Private Function ValidCustomerSuppliedParts()
        If IsEmpty("ProductTextBox") Then
            MsgBox("Product required !")
            ProductTextBox.Select()
            Return False
        End If
        Return True
    End Function

    Private Sub InsertNewWorkOrderWorkOrderReceivedPart()
        Dim FieldsToUpdate = "  WorkOrderPartID_LongInteger, " &
                                  "  ProductPartID_LongInteger, " &
                          "  ReceivedBy_LongInteger, " &
                                " DateReceived_DateTime," &
                       "  ReceivedQuantity_Double ," &
                       "  WorkOrderReceivedPartStatusID_LongInteger "

        Dim FieldsData = CurrentWorkOrderPartID.ToString & ",  " &
                                  CurrentProductPartID.ToString & ",  " &
                                  CurrentUserID.ToString & ",  " &
                                  InQuotes(DateString) & ", " &
                                  Val(CustomerSuppliedQuantityTextBox.Text).ToString() & ", " &
                                  GetStatusIdFor("WorkOrderReceivedPartsTable", "Draft from Customer").ToString()

        CurrentCustomerSuppliedPartID = InsertNewRecord("WorkOrderReceivedPartsTable", FieldsToUpdate, FieldsData)

        'NOW UPDATE JOB WITH "Parts From Customer"

        Dim RecordFilter = " WHERE WorkOrderConcernJobID_AutoNumber = " & CurrentWorkOrderConcernJobID.ToString
        Dim SetCommand = " SET WorkOrderConcernJobStatusID_LongInteger = " & GetStatusIdFor("WorkOrderConcernJobsTable", "Parts From Customer").ToString
        UpdateTable("WorkOrderConcernJobsTable", SetCommand, RecordFilter)
        'UPDATE THE PRODUCTFILE INDICATING NTHAT THIS PRODUCT IS ALREADY LINK AND SHOULD BE 
        'THE PRIORITY IN LINKING
        RecordFilter = " WHERE ProductsPartID_Autonumber = " & CurrentProductPartID.ToString
        SetCommand = " SET ProductsPartID_LongInteger = " & CurrentProductPartID.ToString
        UpdateTable("ProductsPartsTable", SetCommand, RecordFilter)
    End Sub
    Private Sub UpdateWorkOrderWorkOrderReceivedPart()
        If MsgBox("About to replace RECEIVED PARTS informations, Continue ?", MsgBoxStyle.YesNo) = vbNo Then
            Exit Sub
        End If
        Dim RecordFilter = " WHERE WorkOrderReceivedPartID_AutoNumber = " & CurrentCustomerSuppliedPartID.ToString
        Dim SetCommand = " SET  ReceivedQuantity_Double = " & Val(CustomerSuppliedQuantityTextBox.Text).ToString
        UpdateTable("WorkOrderReceivedPartsTable", SetCommand, RecordFilter)
    End Sub

    Private Sub RequisitionForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        If Me.Enabled = False Then Exit Sub
        ' GET RETURNED DATA HERE

        CallingForm = SavedCallingForm
        Select Case Tunnel1
            Case "Tunnel2IsMasterCodeBookID"
                CurrentMasterCodeBookID = Tunnel2
                CurrentCodeVehicleID = GetCodeVehicleID(CurrentMasterCodeBookID, CurrentVehicleID)
                PartDescriptionTextBox.Text = Tunnel3
                If MsgBox("Continue ADD this part ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                CurrentWorkOrderPartID = -1
                RegisterWorkOrderPartsChanges()
            Case "Tunnel2IsProductPartID"
                CurrentProductPartID = Tunnel2
                If IsEmpty(CustomerSuppliedQuantityTextBox.Text) Then
                    CustomerSuppliedQuantityTextBox.Select()
                End If
                Exit Sub
            Case "Tunnel2IsCodeVehiclePNSpecificationID"
                PartDetailsGroupBox.Visible = False

        End Select
        FillWorkOrderPartsDataGridView()
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemovePartToolStripMenuItem.Click
        If CustomerSuppliedPartsRecordCount > 0 Then
            MsgBox("A product received is attached, delete attachment(s) before deletion ")
            Exit Sub
        End If
        If MsgBox("Do you really want To Delete This Item ?", vbYesNo) = vbYes Then
            MySelection = "DELETE FROM WorkOrderPartsTable WHERE WorkOrderPartID_AutoNumber = " & Str(CurrentWorkOrderPartID)
            JustExecuteMySelection()
            FillWorkOrderPartsDataGridView()
        End If
    End Sub
    Private Function RequisitionFieldsEntriesAreNotValidAndComplete()
        If Trim(WOPartsRequisitionNumberTextBox.Text) = "" Then
            WOPartsRequisitionNumberTextBox.Select()
            Return True
        End If
        If Trim(WOPartsRequisitionDateTimeTextBox.Text) = "" Then
            WOPartsRequisitionDateTimeTextBox.Select()
            Return True
        End If
        If Trim(WorkOrderNumberTextBox.Text) = "" Then
            WorkOrderNumberTextBox.Select()
            Return True
        End If
        Return False
    End Function

    Private Sub ShowMasterCodeBookForm()
        MasterCodeBookForm.SearchMasterCodeBookTextBox.Text = WorkOrderConcernJobsDataGridView.Item("SystemDesc_ShortText100Fld", CurrentWorkOrderConcernJobsRow).Value
        MasterCodeBookForm.DefaultVehicleModelTextBox.Text = VehicleNameButton.Text
        MasterCodeBookForm.ChangeVehicleDefaults.Enabled = False
        ShowCalledForm(Me, MasterCodeBookForm)

    End Sub

    Private Sub PrintSubmitRequisitionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SubmitRequestForPartsToolStripMenuItem.Click
        ' CHECK IF THERE ARE AVAILABLE PARTS OUTSTANDING FOR REQUEST FOR PURCHASE
        If MsgBox("Continue Finalizing registration of received parts from customer ?", MsgBoxStyle.YesNo) = vbNo Then
            Exit Sub
        End If
        ' VALIDATION
        For i = 0 To WorkOrderConcernJobsRecordCount - 1
            'CHECK FIRST IF ALL JOBS ARE LINKED TO A REQUEST FOR RELEASE FROM WAREHOUSE OR TO THE
            'PARTS RECEIVED FROM CUSTOMER OR DOES NOT A PART
            CurrentWorkOrderConcernJobID = WorkOrderConcernJobsDataGridView.Item("WorkOrderConcernJobID_AutoNumber", i).Value
            WorkOrderPartsSelectionFilter = " WHERE WorkOrderConcernJobID_AutoNumber = " & CurrentWorkOrderConcernJobID.ToString

            FillWorkOrderPartsDataGridView()
            Dim DoesNotNeedPartID = WorkOrderConcernJobsDataGridView.Item("DoesNotNeedPartID_AutoNumber", i).Value
            If IsNotEmpty(DoesNotNeedPartID) Then
                'THIS JOB IS MARKED AS NO-PART-NEEDed JOB
                If WorkOrderPartsRecordCount > 0 Then
                    If MsgBox("This job is marked as NO-PART-NEED-JOB, you attached a part though, " & vbCrLf &
                              " Want me remove the NO-PART-NEED-JOB indicator ? ") = MsgBoxResult.Yes Then
                        If MsgBox("About to remove the indicator, continue ? ") = MsgBoxResult.Yes Then
                            MySelection = " DELETE FROM DoesNotNeedPartsTable WHERE DoesNotNeedPartID_AutoNumber =  " & DoesNotNeedPartID.ToString
                            JustExecuteMySelection()
                        End If
                    End If
                Else
                    Continue For
                End If
            End If
            For j = 0 To WorkOrderPartsRecordCount - 1
                FillField(CurrentWorkOrderPartID, WorkOrderPartsDataGridView.Item("WorkOrderPartID_AutoNumber", j).Value)
                CustomerSuppliedPartsSelectionFilter = " WHERE WorkOrderPartID_LongInteger = " & CurrentWorkOrderPartID.ToString
                FillCustomerSuppliedPartsDataGridView()
                ' is WorkOrderRequestedPartID_AutoNumber  NULL (REQUISITION DOES EXISTS FOR THIS PART )  OR
                If WorkOrderRequestedPartsRecordCount < 1 And CustomerSuppliedPartsRecordCount < 1 Then
                    'this part is not a no part-needed-job and there is no product linked then
                    'this is still an outstanding part required
                    MsgBox(WorkOrderPartsDataGridView.Item("SystemDesc_ShortText100Fld", j).Value & " is still outstanding ")
                    Exit Sub
                Else
                    ' THERE IS A REQUEST, VALIIDATE QUANTITY
                    If NotNull(WorkOrderPartsDataGridView.Item("Quantity_Integer", j).Value) < 1 Then
                        MsgBox("Please put a quantity for " & WorkOrderPartsDataGridView.Item("SystemDesc_ShortText100Fld", j).Value)
                        Exit Sub
                    End If
                End If
            Next
        Next
        Dim SetCommand = ""
        Dim RecordFilter = ""
        Dim NoOfRequestedPart = 0
        Dim xxFilter = ""

        'STARTING WITH JOBS
        For i = 0 To WorkOrderConcernJobsRecordCount - 1
            WorkOrderConcernJobTextBox.Text = WorkOrderConcernJobsDataGridView.Item("JobDescription", i).Value
            CurrentWorkOrderConcernJobID = WorkOrderConcernJobsDataGridView.Item("WorkOrderConcernJobID_AutoNumber", i).Value
            CurrentInformationsHeaderID = WorkOrderConcernJobsDataGridView.Item("InformationsHeaderID_AutoNumber", i).Value

            'WORK ON THE PARTS FOR THIS JOB
            WorkOrderPartsSelectionFilter = " WHERE WorkOrderConcernJobID_AutoNumber = " & CurrentWorkOrderConcernJobID.ToString

            FillWorkOrderPartsDataGridView()
            If WorkOrderPartsRecordCount > 0 Then
                Dim xxWorkOrderPartID_LongInteger = -1
                Dim xxProductPartID_LongInteger = -1
                Dim xxRequestedQuantity_Double = -1
                Dim xxUnit_ShortText3 = ""
                For j = 0 To WorkOrderPartsRecordCount - 1
                    FillField(xxWorkOrderPartID_LongInteger, WorkOrderPartsDataGridView.Item("WorkOrderPartID_AutoNumber", j).Value)
                    FillField(xxProductPartID_LongInteger, WorkOrderPartsDataGridView.Item("ProductPartID_LongInteger", j).Value)
                    FillField(xxRequestedQuantity_Double, WorkOrderPartsDataGridView.Item("Quantity_Integer", j).Value)
                    FillField(xxUnit_ShortText3, WorkOrderPartsDataGridView.Item("Unit_ShortText3", j).Value)
                    MySelection = "SELECT * FROM WorkOrderRequestedPartsTable WHERE WorkOrderPartID_LongInteger = " & xxWorkOrderPartID_LongInteger.ToString
                    JustExecuteMySelection()
                    If WorkOrderRequestedPartsRecordCount < 1 Then Continue For


                    SetCommand = " SET " &
                       "  WorkOrderRequestedPartStatus_Integer = " & GetStatusIdFor("WorkOrderRequestedPartsTable", "Requisition Submitted").ToString

                    RecordFilter = " WHERE WorkOrderPartID_LongInteger = " & xxWorkOrderPartID_LongInteger.ToString

                    UpdateTable("WorkOrderRequestedPartsTable", SetCommand, RecordFilter)
                Next j
            End If
            MySelection = " UPDATE WorkOrderConcernJobsTable  " &
                                  " SET WorkOrderConcernJobStatusID_LongInteger = " & GetStatusIdFor("WorkOrderConcernJobsTable", "Parts Requested").ToString
            xxFilter = " WHERE WorkOrderConcernJobID_AutoNumber = " & CurrentWorkOrderConcernJobID.ToString
            MySelection = MySelection & xxFilter
            JustExecuteMySelection()
        Next i

        'THEN UPDATE STATUS OF WorkOrderConcernsTable (THIS IS DELETED)

        'THEN UPDATE STATUS OF WorkOrdersTable (THIS IS DELETED)

        MsgBox("Succesfully submitted your parts request to the warehouse department, see you there")
        DoCommonHouseKeeping(Me, SavedCallingForm)

    End Sub
    Private Sub InsertNewWorkOrderPartsRequisition()
        Dim FieldsToUpdate = " WorkOrderID_LongInteger, " &
                             " WorkOrderPartsRequisitionNumber_ShortText12, " &
                             " WorkOrderPartsRequisitionRevision_Integer, " &
                             " RequestedByID_LongInteger, " &
                             " WorkOrderPartsRequisitionDate_ShortDate, " &
                             " WorkOrderPartsRequisitionStatusID_Integer "

        Dim FieldsData = CurrentWorkOrderID.ToString & ",  " &
                         InQuotes(WOPartsRequisitionNumberTextBox.Text) & ",  " &
                         InQuotes(WOPartsRequisionRevisionTextBox.Text) & ",  " &
                         CurrentPersonelID.ToString & ",  " &
                         InQuotes(Today.ToString) & ",  " &
                         GetStatusIdFor("WorkOrderRequestedPartsHeadersTable").ToString()

        CurrentWorkOrderRequestedPartsHeaderID = InsertNewRecord("WorkOrderRequestedPartsHeadersTable", FieldsToUpdate, FieldsData)
    End Sub
    Private Sub UpdateWorkOrderPartsRequisition()
        Dim RecordFilter = " WHERE WorkOrderRequestedPartsHeaderID_AutoNumber = " & CurrentWorkOrderRequestedPartsHeaderID.ToString
        Dim SetCommand = " SET WorkOrderPartsRequisitionStatusID_Integer = " & WorkOrderPartsRequisitionStatusID.ToString()
        UpdateTable("WorkOrderRequestedPartsHeadersTable", SetCommand, RecordFilter)
    End Sub
    Private Sub GetStandarPartsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GetStandarPartsToolStripMenuItem.Click
        ' PARTS WILL BE SELECTED PER JOB AS EACH JOB WILL BE IDENTIFIED AND SEARCH THE WorkOrderConcernJobsTable FOR THE 1ST INSTANCE
        ' ONCE FOUND (EXISTS) EACH ATTACHED PARTS USED ARE IDENTIFIED AND ADDED TO THE REQUISITION
        ' a NEW REQUISITION HEADER (TEMPORARY) WILL BE CREATED UPON SAVE
        ' REQUISITION NO WILL BE THE WO NUMBER PREFIXED WITH R
        ' EACH REQUISITION WILL HAVE ITS REVISION NUMBER STARTING WITH 0

        GetAttachedProducts()
    End Sub
    Private Sub GetAttachedProducts()
        'NOTES  1 - FIND 1ST OCCURRENCE OF THE PASSED JOBID
        '       2 - GET THE WORKORDER ID THEN FILTER RECORDS PER WORKORDER ID And JOB ID

        'TEMPORARY USING WorkOrderPa
        'rtsDataGridView

        Dim SavedWorkOrderPartsFieldsToSelect = WorkOrderPartsFieldsToSelect
        Dim SavedWorkOrderPartsSelectionFilter = WorkOrderPartsSelectionFilter
        WorkOrderPartsFieldsToSelect =
"
SELECT 
WorkOrderPartsTable.WorkOrderPartID_AutoNumber, 
WorkOrderPartsTable.Quantity_Integer, 
WorkOrderConcernJobsTable.InformationsHeaderID_LongInteger, 
WorkOrderConcernJobsTable.WorkOrderConcernJobID_AutoNumber,
WorkOrderPartsTable.Quantity_Integer,
MasterCodeBookTable.MasterCodeBookID_Autonumber
FROM (WorkOrderPartsTable LEFT JOIN WorkOrderConcernJobsTable ON WorkOrderPartsTable.WorkOrderConcernJobID_LongInteger = WorkOrderConcernJobsTable.WorkOrderConcernJobID_AutoNumber) LEFT JOIN MasterCodeBookTable ON WorkOrderPartsTable.MasterCodeBookID_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber
"
        WorkOrderPartsSelectionOrder = " ORDER BY WorkOrderConcernJobID_AutoNumber DESC "
        WorkOrderPartsSelectionFilter = " WHERE WorkOrderConcernJobsTable.InformationsHeaderID_LongInteger = " & CurrentInformationsHeaderID '&
        '    GetStandardPartsFlag = True

        MySelection = WorkOrderPartsFieldsToSelect & WorkOrderPartsSelectionFilter & WorkOrderPartsSelectionOrder
        JustExecuteMySelection()
        WorkOrderPartsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If RecordCount > 0 Then
            Dim CurrentWorkOrderConcernJodID = WorkOrderPartsDataGridView.Item("WorkOrderConcernJobID_AutoNumber", 0).Value
            For i = 0 To RecordCount - 1
                If CurrentWorkOrderConcernJodID <> WorkOrderPartsDataGridView.Item("WorkOrderConcernJobID_AutoNumber", i).Value Then Exit For
                RequestedQuantityTextBox.Text = WorkOrderPartsDataGridView.Item("Quantity_Integer", i).Value
                CurrentMasterCodeBookID = WorkOrderPartsDataGridView.Item("MasterCodeBookID_Autonumber", i).Value
                GetCodeVehicleID(CurrentMasterCodeBookID, CurrentVehicleID)
                InsertNewWorkOrderPart()
            Next
        End If
        WorkOrderPartsFieldsToSelect = SavedWorkOrderPartsFieldsToSelect
        WorkOrderPartsSelectionFilter = SavedWorkOrderPartsSelectionFilter
        WorkOrderPartsSelectionOrder = ""
        '    GetStandardPartsFlag = True
        FillWorkOrderPartsDataGridView()
    End Sub
    Private Sub AddPartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddPartToolStripMenuItem.Click
        If WorkOrderPartsRecordCount > 0 Then
            If MsgBox("Continue adding another part needed for this job ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        PurposeOfEntry = "ADD"
        ShowMasterCodeBookForm()
    End Sub
    Private Sub EditPartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditPartToolStripMenuItem.Click
        If WorkOrderPartsRecordCount < 1 Then
            PurposeOfEntry = "ADD"
            ShowMasterCodeBookForm()
            Exit Sub
        End If
        PurposeOfEntry = "EDIT"
        LoadPartDetails()
    End Sub
    Private Sub LoadPartDetails()
        'NOTE CHECK FOR VOLUME SPECIFICATION IF THERE IS PRODUCT RECEIVED AND POINT TO THAT RECORD IF THERE ARE MULTIPLE SPECIFICATIONS
        'here THE QuantitySpecificationsTable SPECIFIES NEEDED SPECIFICATION FOR CODEVEHICLE REFERENCE
        'EX: AN OIL BREQUIREMENT FOR RAV4 2008 FOR A JOB : OIL CHANGE WITH FILTER IS DIFFERENT FROM OIL CHANGE WITHOUT FILTER
        MySelection = " Select top 1 * FROM QuantitySpecificationsTable WHERE CodeVehicleID_LongInteger = " & CurrentCodeVehicleID.ToString &
                                                                        " AND InformationsHeaderID_LongInteger = " & CurrentInformationsHeaderID
        JustExecuteMySelection()
        CurrentQuantitySpecificationsID = -1
        PartNumberSpecificationTextBox.Text = ""
        SpecificationsTextBox.Text = ""
        SpecifiedQuantityTextBox.Text = ""
        SpecifiedUnitTextBox.Text = ""
        CustomerSuppliedQuantityTextBox.Text = ""
        CustomerSuppliedUnitTextBox.Text = ""
        PartNumberTextBox.Text = ""
        PackingTextBox.Text = ""
        If RecordCount > 0 Then
            SpecificationsGroupBox.Text = "Fluid Specifications"
            Dim r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
            CurrentQuantitySpecificationsID = r("QuantitySpecificationID_AutoNumber")
            SpecifiedQuantityTextBox.Text = r("SpecifiedQuantity_Double")
            SpecifiedUnitTextBox.Text = r("SpecifiedUnit_ShortText3")
        End If

        PartDetailsGroupBox.Visible = True
        SaveToolStripMenuItem.Visible = True

        FillField(CurrentPartsSpecificationID, WorkOrderPartsDataGridView.Item("PartsSpecificationID_AutoNumber", CurrentWorkOrderPartsRow).Value)
        FillField(RequestedQuantityTextBox.Text, WorkOrderRequestedPartsDataGridView.Item("RequestedQuantity_Double", CurrentWorkOrderPartsRow).Value)
        FillField(RequestedUnitTextBox.Text, WorkOrderRequestedPartsDataGridView.Item("RequestedUnit_ShortText3", CurrentWorkOrderPartsRow).Value)
        FillField(PartDescriptionTextBox.Text, WorkOrderPartsDataGridView.Item("SystemDesc_ShortText100Fld", CurrentWorkOrderPartsRow).Value)
        FillField(ProductTextBox.Text, WorkOrderPartsDataGridView.Item("ManufacturerDescription_ShortText250", CurrentWorkOrderPartsRow).Value)
        FillField(PartNumberTextBox.Text, WorkOrderPartsDataGridView.Item("ManufacturerPartNo_ShortText30Fld", CurrentWorkOrderPartsRow).Value)
        If IsEmpty(RequestedQuantityTextBox.Text) Then
            If IsEmpty(SpecifiedQuantityTextBox.Text) Then
                ' Defaultvalues are 1 PC
                RequestedQuantityTextBox.Text = "1"
                RequestedUnitTextBox.Text = "PC"
            End If
        End If
        If CustomerSuppliedPartsRecordCount > 0 Then
            ' HERE the CUSTOMER SUPPLIED the PARTS
            FillField(CurrentCustomerSuppliedPartID, CustomerSuppliedPartsDataGridView.Item("WorkOrderReceivedPartID_AutoNumber", CurrentCustomerSuppliedPartsRow).Value)
            FillField(CurrentProductPartID, CustomerSuppliedPartsDataGridView.Item("ProductsPartID_Autonumber", CurrentCustomerSuppliedPartsRow).Value)
            FillField(CustomerSuppliedQuantityTextBox.Text, CustomerSuppliedPartsDataGridView.Item("ReceivedQuantity_Double", CurrentCustomerSuppliedPartsRow).Value)
            FillField(CustomerSuppliedUnitTextBox.Text, CustomerSuppliedPartsDataGridView.Item("Unit_ShortText3", CurrentCustomerSuppliedPartsRow).Value)
            FillField(ProductTextBox.Text, CustomerSuppliedPartsDataGridView.Item("ManufacturerDescription_ShortText250", CurrentCustomerSuppliedPartsRow).Value)
            FillField(PartNumberTextBox.Text, CustomerSuppliedPartsDataGridView.Item("ManufacturerPartNo_ShortText30Fld", CurrentCustomerSuppliedPartsRow).Value)
            FillField(CurrentCustomerSuppliedPartID, NotNull(CustomerSuppliedPartsDataGridView.Item("WorkOrderReceivedPartID_AutoNumber", CurrentCustomerSuppliedPartsRow).Value))

            'HERE SYSTEM DEALS WITH DISPLAYING PACKING INFORMATIONS IF AVAILABLE
            If IsNotEmpty(CustomerSuppliedPartsDataGridView.Item("QuantityPerPack_Double", CurrentCustomerSuppliedPartsRow).Value) Then
                PackingTextBox.Text = CustomerSuppliedPartsDataGridView.Item("QuantityPerPack_Double", CurrentCustomerSuppliedPartsRow).Value.ToString & Space(1) &
                                      CustomerSuppliedPartsDataGridView.Item("UnitOfTheQuantity_ShortText3", CurrentCustomerSuppliedPartsRow).Value.ToString &
                                        " / " &
                                      CustomerSuppliedPartsDataGridView.Item("Unit_ShortText3", CurrentCustomerSuppliedPartsRow).Value.ToString
            End If
        End If
    End Sub

    Private Sub PartDetailsGroupBox_Enter(sender As Object, e As EventArgs) Handles PartDetailsGroupBox.VisibleChanged
        If PartDetailsGroupBox.Visible = True Then
            EditPartToolStripMenuItem.Visible = False
            AddPartToolStripMenuItem.Visible = False
            RemovePartToolStripMenuItem.Visible = False
            WorkOrderConcernJobsDataGridView.Enabled = False
            RequisitionDetailsGroupBox.Visible = False
        Else

            AddPartToolStripMenuItem.Visible = True
            EditPartToolStripMenuItem.Visible = True
            RemovePartToolStripMenuItem.Visible = True
            SaveToolStripMenuItem.Visible = False
            WorkOrderConcernJobsDataGridView.Enabled = True
            RequisitionDetailsGroupBox.Visible = True
        End If
    End Sub
    Private Sub ReceivedPartDescTextBox_TextChanged(sender As Object, e As EventArgs) Handles ProductTextBox.Click
        If ProductTextBox.Text <> "" Then
            If MsgBox("Do you intend to update the Product?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        ProductsPartsForm.PartNoSearchTextBox.Text = PartNumberTextBox.Text
        ProductsPartsForm.PartDescriptionSearchTextBox.Text = PartDescriptionTextBox.Text
        ProductsPartsForm.ProductSpecificationSearchTextBox.Text = PartNumberSpecificationTextBox.Text

        ShowCalledForm(Me, ProductsPartsForm)

    End Sub

    Private Sub RemoveProductToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveProductToolStripMenuItem.Click
        If MsgBox("Are you sure you want to " &
                RemoveProductToolStripMenuItem.Text &
                " ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        If RemoveProductToolStripMenuItem.Text = "Remove Requested Part" Then
            MySelection = "DELETE FROM WorkOrderRequestedPartsTable WHERE WorkOrderRequestedPartID_AutoNumber = " & Str(CurrentWorkOrderRequestedPartID)
            JustExecuteMySelection()
            FillWorkOrderRequestedPartsDataGridView()
        Else
            MySelection = "DELETE FROM WorkOrderReceivedPartsTable WHERE WorkOrderReceivedPartID_AutoNumber = " & Str(CurrentCustomerSuppliedPartID)
            JustExecuteMySelection()
            FillCustomerSuppliedPartsDataGridView()
        End If
    End Sub

    Private Sub RegisterReceivedPartFromCustomerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegisterReceivedPartFromCustomerToolStripMenuItem.Click
        If MsgBox("Continue Finalizing registration of received parts from customer ?", MsgBoxStyle.YesNo) = vbNo Then
            Exit Sub
        End If
        Dim RecordFilter = ""
        Dim SetCommand = ""
        ' VALIDATION
        For i = 0 To WorkOrderConcernJobsRecordCount - 1
            'CHECK FIRST IF ALL JOBS ARE LINKED TO A REQUEST FOR RELEASE FROM WAREHOUSE OR TO THE
            'PARTS RECEIVED FROM CUSTOMER OR DOES NOT A PART
            CurrentWorkOrderConcernJobID = WorkOrderConcernJobsDataGridView.Item("WorkOrderConcernJobID_AutoNumber", i).Value
            WorkOrderPartsSelectionFilter = " WHERE WorkOrderConcernJobID_AutoNumber = " & CurrentWorkOrderConcernJobID.ToString

            FillWorkOrderPartsDataGridView()
            Dim DoesNotNeedPartID = WorkOrderConcernJobsDataGridView.Item("DoesNotNeedPartID_AutoNumber", i).Value
            If IsNotEmpty(DoesNotNeedPartID) Then
                'THIS JOB IS MARKED AS NO PART NEED JOB
                If WorkOrderPartsRecordCount > 0 Then
                    If MsgBox("This job is marked as NO-PART-NEED-JOB, you attached a part though, " & vbCrLf &
                              " Want me remove the NO-PART-NEED-JOB indicator ? ") = MsgBoxResult.Yes Then
                        If MsgBox("About to remove the indicator, continue ? ") = MsgBoxResult.Yes Then
                            MySelection = " DELETE FROM DoesNotNeedPartsTable WHERE DoesNotNeedPartID_AutoNumber =  " & DoesNotNeedPartID.ToString
                            JustExecuteMySelection()
                        End If
                    End If
                End If
                Continue For
            End If
            For j = 0 To WorkOrderPartsRecordCount - 1
                FillField(CurrentWorkOrderPartID, WorkOrderPartsDataGridView.Item("WorkOrderPartID_AutoNumber", j).Value)
                CustomerSuppliedPartsSelectionFilter = " WHERE WorkOrderPartID_LongInteger = " & CurrentWorkOrderPartID.ToString
                FillCustomerSuppliedPartsDataGridView()
                ' is WorkOrderRequestedPartID_AutoNumber  NULL (REQUISITION DOES EXISTS FOR THIS PART )  OR
                If CustomerSuppliedPartsRecordCount = 0 Then
                    If IsEmpty(WorkOrderPartsDataGridView.Item("WorkOrderRequestedPartID_AutoNumber", j).Value) Then
                        'this part is not a no part-needed-job and there is no product linked then
                        'this is still an outstanding part required
                        MsgBox(WorkOrderPartsDataGridView.Item("SystemDesc_ShortText100Fld", j).Value & " is still outstanding ")
                        Exit Sub
                    End If
                End If
            Next
        Next
        ' START THE REGISTRATION

        For i = 0 To WorkOrderConcernJobsRecordCount - 1
            'CHECK FIRST IF ALL JOBS ARE LINKED TO A REQUEST FOR RELEASE FROM WAREHOUSE OR TO THE
            'PARTS RECEIVED FROM CUSTOMER OR DOES NOT A PART
            CurrentWorkOrderConcernJobID = WorkOrderConcernJobsDataGridView.Item("WorkOrderConcernJobID_AutoNumber", i).Value
            WorkOrderPartsSelectionFilter = " WHERE WorkOrderConcernJobID_AutoNumber = " & CurrentWorkOrderConcernJobID.ToString

            FillWorkOrderPartsDataGridView()
            For j = 0 To WorkOrderPartsRecordCount - 1
                FillField(CurrentWorkOrderPartID, WorkOrderPartsDataGridView.Item("WorkOrderPartID_AutoNumber", j).Value)
                CustomerSuppliedPartsSelectionFilter = " WHERE WorkOrderPartID_LongInteger = " & CurrentWorkOrderPartID.ToString
                FillCustomerSuppliedPartsDataGridView()
                If CustomerSuppliedPartsRecordCount > 0 Then
                    For k = 0 To CustomerSuppliedPartsRecordCount - 1
                        FillField(CurrentCustomerSuppliedPartID, NotNull(CustomerSuppliedPartsDataGridView.Item("WorkOrderReceivedPartID_AutoNumber", k).Value))
                        RecordFilter = " WHERE WorkOrderReceivedPartID_AutoNumber = " & CurrentCustomerSuppliedPartID.ToString
                        SetCommand = " SET WorkOrderReceivedPartStatusID_LongInteger = " & GetStatusIdFor("WorkOrderReceivedPartsTable", "Received from Customer").ToString
                        UpdateTable("WorkOrderReceivedPartsTable", SetCommand, RecordFilter)
                    Next
                    RecordFilter = " WHERE WorkOrderPartID_AutoNumber = " & CurrentWorkOrderPartID.ToString
                    SetCommand = " SET WorkOrderPartStatusID_LongInteger = " & GetStatusIdFor("WorkOrderPartsTable", "Received From Customer").ToString
                    UpdateTable("WorkOrderPartsTable", SetCommand, RecordFilter)
                End If
            Next
        Next
        'NOW UPDATE owner JOB, CONCERN AND WORKORDER
        RecordFilter = " WHERE WorkOrderConcernJobID_AutoNumber = " & CurrentWorkOrderConcernJobID.ToString
        SetCommand = " SET WorkOrderConcernJobStatusID_LongInteger = " & GetStatusIdFor("WorkOrderConcernJobsTable", "Customer Parts Received").ToString
        UpdateTable("WorkOrderConcernJobsTable", SetCommand, RecordFilter)
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub

    Private Sub CustomerSuppliedGroupBox_VisibleChanged(sender As Object, e As EventArgs) Handles CustomerSuppliedGroupBox.VisibleChanged
        If CustomerSuppliedGroupBox.Visible = True Then
            PartDetailsGroupBox.Height = PartDetailsGroupBox.Height + CustomerSuppliedGroupBox.Height
        Else
            PartDetailsGroupBox.Height = PartDetailsGroupBox.Height - CustomerSuppliedGroupBox.Height
        End If
        PartDetailsGroupBox.Top = (Me.Height - PartDetailsGroupBox.Height) / 2
        PartDetailsGroupBox.Left = (Me.Width - PartDetailsGroupBox.Width) / 2
    End Sub

    Private Sub SpecificationsTextBox_Click(sender As Object, e As EventArgs) Handles SpecificationsTextBox.Click
        PartsSpecificationsForm.PartNumberSpecificationTextBox.Enabled = False
        PartsSpecificationsForm.PartSpecificationsTextBox.Enabled = True
        ShowPartsSpecificationsForm("fluid specification", SpecificationsTextBox)
    End Sub

    Private Sub PartNumberSpecificationTextBox_Click(sender As Object, e As EventArgs) Handles PartNumberSpecificationTextBox.Click
        ShowPartsSpecificationsForm("part number specification", PartNumberSpecificationTextBox)
    End Sub
    Private Sub ShowPartsSpecificationsForm(SpecificationType As String, FieldTextBox As TextBox)
        If IsNotEmpty(FieldTextBox.Text) Then
            If MsgBox("Do you intend to update current " & SpecificationType, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            PartsSpecificationsForm.PartNumberSpecificationTextBox.Text = PartNumberSpecificationTextBox.Text
        End If
        If CurrentWorkOrderPartsRow < 0 Then MsgBox("STOP, FIX THIS")
        PartsSpecificationsForm.PartDescriptionTextBox.Text = WorkOrderPartsDataGridView.Item("SystemDesc_ShortText100Fld", CurrentWorkOrderPartsRow).Value
        Tunnel1 = WorkOrderConcernJobsDataGridView.Item("InformationsHeaderDescription_ShortText255", CurrentWorkOrderConcernJobsRow).Value
        Tunnel2 = CurrentCodeVehicleID
        Tunnel3 = CurrentMasterCodeBookID
        ShowCalledForm(Me, PartsSpecificationsForm)
    End Sub

End Class