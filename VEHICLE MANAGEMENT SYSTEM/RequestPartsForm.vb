Public Class RequestPartsForm
    Private CurrentWorkOrderInformationsHeaderID As Integer = -1
    Private CurrentWorkOrderPartsRow As Integer = -1
    Private CurrentMasterCodeBookID As Integer = -1
    Private CurrentInformationsHeaderID As Integer = -1

    Private WorkOrderPartsFieldsToSelect = ""
    Private WorkOrderPartsTablesLinks = ""
    Private WorkOrderPartsSelectionFilter = ""
    Private WorkOrderPartsSelectionOrder = ""
    Private CurrentWorkOrderPartID As Integer = -1
    Private WorkOrderPartsRecordCount As Integer = 0
    Private WorkOrderPartsGridViewAlreadyFormated = False
    Private CurrentPartSpecificationsID = -1

    Private SpecificationsFieldsToSelect = ""
    Private SpecificationsSelectionFilter = ""
    Private SpecificationsRecordCount = 0
    Private SpecificationsGridViewAlreadyFormated = False

    Private WorkOrderReceivedPartsFieldsToSelect = ""
    Private WorkOrderReceivedPartsSelectionFilter = ""
    Private WorkOrderReceivedPartsSelectionOrder = ""
    Private CurrentWorkOrderReceivedPartID As Integer = -1
    Private WorkOrderReceivedPartsRecordCount As Integer = 0
    Private WorkOrderReceivedPartsGridViewAlreadyFormated = False
    Private CurrentWorkOrderReceivedPartsRow As Integer = -1
    Private CurrentPartNumberSpecificationsID As Integer = -1

    Private WorkOrderConcernJobsFieldsToSelect = ""
    Private WorkOrderConcernJobsTablesLinks = ""
    Private WorkOrderConcernJobsSelectionFilter = ""
    Private WorkOrderConcernJobsSelectionOrder = ""
    Private WorkOrderConcernJobsRecordCount As Integer = 0
    Private WorkOrderConcernJobsGridViewAlreadyFormated = False
    Private CurrentWorkOrderConcernJobsRow As Integer = -1
    Private CurrentWorkOrderConcernJobID As Integer = -1

    Private CurrentWorkOrderConcernID = -1
    Private CurrentWorkOrderPartsRequisitionID = -1
    Private CurrentProductPartID = -1
    Private WorkOrderPartsRequisitionStatusID = -1

    Private PurposeOfEntry = ""
    Private SavedCallingForm As Form
    Private ChangesOccured = False
    Private NoHeaderFound = True

    Private Sub RequestPartForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' form returns       Tunnel1 = CurrentVehicleModelsRelationID
        '                    Tunnel2 = 
        ' ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        SavedCallingForm = CallingForm
        Dim abcd = CurrentVehicleID
        Me.Width = VehicleManagementSystemForm.Width - 4
        Me.Left = VehicleManagementSystemForm.Left
        Me.Text = Tunnel3
        CurrentWorkOrderConcernID = Tunnel1
        VehicleNameButton.Text = CurrentVehicleString
        WorkOrderConcernJobsSelectionFilter = " WHERE WorkOrderConcernID_AutoNumber = " & CurrentWorkOrderConcernID.ToString
        FillWorkOrderConcernJobsDataGridView()
        RemovePartToolStripMenuItem.Visible = True
        GetStandarPartsToolStripMenuItem.Visible = True
        AddPartToolStripMenuItem.Visible = True
        WorkOrderReceivedPartsDataGridView.Visible = False

        If Me.Text = "Receive parts from the Customer" Then
            WorkOrderReceivedPartsDataGridView.Visible = True
            CustomerSuppliedGroupBox.Visible = True
            RequisitionInformationsGroupBox.Visible = False
            JobGroupBox.Top = RequisitionInformationsGroupBox.Top
            PartDetailsGroupBox.Top = RequisitionInformationsGroupBox.Top + JobGroupBox.Height

            RequisitionDetailsGroupBox.Height = (RequisitionDetailsGroupBox.Top + RequisitionInformationsGroupBox.Top + JobGroupBox.Height) - RequisitionDetailsGroupBox.Top
        Else
            'note: check if there already exists a requisition header for this workorder (unfinished / on preparation requisition for this Concern
            SubmitRequestForPartsToolStripMenuItem.Visible = True
            WOPartsRequisitionNumberTextBox.Text = "WOR" & CurrentWorkOrderID.ToString
            Dim r As DataRow
            SetParentRecordReference("WorkOrderPartsRequisitionsTable", "WorkOrderPartsRequisitionNumber_ShortText12", WOPartsRequisitionNumberTextBox.Text)
            If RecordCount > 0 Then
                r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
                WOPartsRequisitionDateTimeTextBox.Text = r("WorkOrderPartsRequisitionDate_ShortDate")
                CurrentWorkOrderPartsRequisitionID = r("WorkOrderPartsRequisitionID_AutoNumber")
                WOPartsRequisitionNumberTextBox.Text = r("WorkOrderPartsRequisitionNumber_ShortText12")
                WOPartsRequisionRevisionTextBox.Text = r("WorkOrderPartsRequisitionRevision_Integer")
                WorkOrderPartsRequisitionStatusID = r("WorkOrderPartsRequisitionStatusID_Integer")
                SetParentRecordReference("StatusesTable", "StatusID_Autonumber", WorkOrderPartsRequisitionStatusID)
                NoHeaderFound = True
                If RecordCount > 0 Then
                    NoHeaderFound = False
                    r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
                    RequisitionStatusTextBox.Text = r("StatusText_ShortText25")
                    Select Case RequisitionStatusTextBox.Text
                        Case "Requisition Submitted"
                            RemovePartToolStripMenuItem.Visible = False
                            SubmitRequestForPartsToolStripMenuItem.Visible = False
                            GetStandarPartsToolStripMenuItem.Visible = False
                            AddPartToolStripMenuItem.Visible = False
                    End Select
                Else
                    MsgBox("Invalid Status link")
                End If

                If RequisitionStatusTextBox.Text = "On Preparation" Or RequisitionStatusTextBox.Text = "On Revision" Then
                    SubmitRequestForPartsToolStripMenuItem.Text = "Print/Submit Requisition Revision " & WOPartsRequisionRevisionTextBox.Text
                Else
                    GetStandarPartsToolStripMenuItem.Visible = False
                    AddPartToolStripMenuItem.Visible = False
                    EditPartToolStripMenuItem.Visible = False
                    RemovePartToolStripMenuItem.Visible = False
                End If
            Else
                WOPartsRequisitionDateTimeTextBox.Text = Now.ToString
                WOPartsRequisionRevisionTextBox.Text = "0"
                CurrentWorkOrderPartsRequisitionID = -1
                WorkOrderPartsRequisitionStatusID = GetStatusIdFor("WorkOrderPartsRequisitionsTable")
                RequisitionStatusTextBox.Text = Tunnel1
            End If
            WorkOrderConcernJobTextBox.Text = "All JOBS"
        End If
        WorkOrderPartsSelectionFilter = " WHERE WorkOrderPartsRequisitionID_LongInteger = " & CurrentWorkOrderPartsRequisitionID.ToString
        RequisitionDetailsGroupBox.Left = WorkOrderConcernJobsDataGridView.Left + WorkOrderConcernJobsDataGridView.Width
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
MasterCodeBookTable.SystemDesc_ShortText100Fld
FROM ((((WorkOrderConcernJobsTable LEFT JOIN WorkOrderConcernsTable ON WorkOrderConcernJobsTable.WorkOrderConcernID_LongInteger = WorkOrderConcernsTable.WorkOrderConcernID_AutoNumber) LEFT JOIN WorkOrdersTable ON WorkOrderConcernsTable.WorkOrderID_LongInteger = WorkOrdersTable.WorkOrderID_AutoNumber) LEFT JOIN InformationsHeadersTable ON WorkOrderConcernJobsTable.InformationsHeaderID_LongInteger = InformationsHeadersTable.InformationsHeaderID_AutoNumber) LEFT JOIN MasterCodeBookTable ON InformationsHeadersTable.MasterCodeBookId_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) LEFT JOIN InformationsHeadersTypeTable ON InformationsHeadersTable.InformationsHeadersTypeID_LongInteger = InformationsHeadersTypeTable.InformationsHeadersTypeID_AutoNumber
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
        WorkOrderConcernJobsDataGridView.Height = (WorkOrderConcernJobsDataGridView.ColumnHeadersHeight * NoOfHeaderLines) + (DataGridViewRowHeight * (RecordsDisplyed + 1))

        Dim RequisitionDetailsGroupBoxBottom = RequisitionDetailsGroupBox.Top + RequisitionDetailsGroupBox.Height
        Dim WorkOrderConcernJobsDataGridViewBottom = WorkOrderConcernJobsDataGridView.Top + WorkOrderConcernJobsDataGridView.Height
        If RequisitionDetailsGroupBoxBottom > WorkOrderConcernJobsDataGridViewBottom Then
            WorkOrderPartsDataGridView.Top = RequisitionDetailsGroupBoxBottom
        Else
            WorkOrderPartsDataGridView.Top = WorkOrderConcernJobsDataGridViewBottom
        End If
    End Sub

    Private Sub FormatWorkOrderConcernJobsDataGridView()
        WorkOrderConcernJobsDataGridView.Width = 0
        For i = 0 To WorkOrderConcernJobsDataGridView.Columns.GetColumnCount(0) - 1

            WorkOrderConcernJobsDataGridView.Columns.Item(i).Visible = False
            Select Case WorkOrderConcernJobsDataGridView.Columns.Item(i).HeaderText
                Case "JobDescription"
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).HeaderText = "JOBS"
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).Width = 400
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).Visible = True

            End Select

            If WorkOrderConcernJobsDataGridView.Columns.Item(i).Visible = True Then
                WorkOrderConcernJobsDataGridView.Width = WorkOrderConcernJobsDataGridView.Width + WorkOrderConcernJobsDataGridView.Columns.Item(i).Width
            End If
        Next
        '       WorkOrderConcernJobs2DataGridView.Location = New Point(28, 49)
        WorkOrderConcernJobsDataGridView.Location = New Point(28, 100)

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

        FillWorkOrderPartsDataGridView()
        GetStandarPartsToolStripMenuItem.Visible = True
        RemovePartToolStripMenuItem.Visible = False
        If WorkOrderPartsRecordCount > 0 Then
            GetStandarPartsToolStripMenuItem.Visible = False
            RemovePartToolStripMenuItem.Visible = True
        End If
    End Sub
    Private Sub AllJOBSButton_Click(sender As Object, e As EventArgs) Handles AllJOBSButton.Click
        WorkOrderConcernJobTextBox.Text = "All JOBS"
        WorkOrderPartsSelectionFilter = " WHERE WorkOrderPartsRequisitionID_LongInteger = " & CurrentWorkOrderPartsRequisitionID.ToString

        FillWorkOrderPartsDataGridView()
    End Sub

    Private Sub FillWorkOrderPartsDataGridView()

        WorkOrderPartsFieldsToSelect =
"
SELECT WorkOrderPartsTable.WorkOrderPartID_AutoNumber, 
WorkOrderPartsTable.Quantity_Integer, 
WorkOrderPartsTable.Unit_ShortText3, 
MasterCodeBookTable.MasterCodeBookID_Autonumber, 
MasterCodeBookTable.SystemDesc_ShortText100Fld, 
WorkOrderPartsRequisitionsTable.WorkOrderPartsRequisitionID_AutoNumber, 
WorkOrderConcernJobsTable.WorkOrderConcernJobID_AutoNumber, 
InformationsHeadersTable.InformationsHeaderID_AutoNumber, 
WorkOrderPartsTable.CodeVehicleID_LongInteger, 
StatusesTable.StatusID_Autonumber, 
StatusesTable.StatusText_ShortText25
FROM ((((WorkOrderPartsTable LEFT JOIN MasterCodeBookTable ON WorkOrderPartsTable.MasterCodeBookID_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) LEFT JOIN WorkOrderPartsRequisitionsTable ON WorkOrderPartsTable.WorkOrderPartsRequisitionID_LongInteger = WorkOrderPartsRequisitionsTable.WorkOrderPartsRequisitionID_AutoNumber) LEFT JOIN WorkOrderConcernJobsTable ON WorkOrderPartsTable.WorkOrderConcernJobID_LongInteger = WorkOrderConcernJobsTable.WorkOrderConcernJobID_AutoNumber) LEFT JOIN InformationsHeadersTable ON WorkOrderPartsTable.InformationsHeaderID_LongInteger = InformationsHeadersTable.InformationsHeaderID_AutoNumber) LEFT JOIN StatusesTable ON WorkOrderPartsTable.WorkOrderPartStatusID_LongInteger = StatusesTable.StatusID_Autonumber
"
        MySelection = WorkOrderPartsFieldsToSelect & WorkOrderPartsSelectionFilter
        JustExecuteMySelection()
        WorkOrderPartsRecordCount = RecordCount
        If WorkOrderPartsRecordCount = 0 Then
            EditPartToolStripMenuItem.Visible = False
            WorkOrderPartsDataGridView.Visible = False
        Else
            EditPartToolStripMenuItem.Visible = True
            WorkOrderPartsDataGridView.Visible = True
        End If

        WorkOrderPartsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        WorkOrderPartsDataGridView.Width = Me.Width
        '       If Not WorkOrderPartsGridViewAlreadyFormated Then
        '      WorkOrderPartsGridViewAlreadyFormated = True
        '     FormatWorkOrderPartsDataGridView()
        '      End If
        Dim RecordsDisplyed = WorkOrderPartsRecordCount
        If WorkOrderPartsRecordCount > 10 Then
            RecordsDisplyed = 10
        Else
            RecordsDisplyed = WorkOrderPartsRecordCount
        End If
        WorkOrderPartsDataGridView.Height = (WorkOrderPartsDataGridView.ColumnHeadersHeight) + (DataGridViewRowHeight * (RecordsDisplyed + 1))



        WorkOrderReceivedPartsDataGridView.Top = WorkOrderPartsDataGridView.Top + WorkOrderPartsDataGridView.Height
    End Sub
    Private Sub FormatWorkOrderPartsDataGridView()
        WorkOrderPartsDataGridView.Width = 0
        For i = 0 To WorkOrderPartsDataGridView.Columns.GetColumnCount(0) - 1

            WorkOrderPartsDataGridView.Columns.Item(i).Visible = False
            Select Case WorkOrderPartsDataGridView.Columns.Item(i).Name
                Case "SystemDesc_ShortText100Fld"
                    WorkOrderPartsDataGridView.Columns.Item(i).HeaderText = "SYSTEM DESC"
                    WorkOrderPartsDataGridView.Columns.Item(i).Width = 400
                    WorkOrderPartsDataGridView.Columns.Item(i).Visible = True
                Case "Quantity_Integer"
                    WorkOrderPartsDataGridView.Columns.Item(i).HeaderText = "WO QTY"
                    WorkOrderPartsDataGridView.Columns.Item(i).Width = 60
                    WorkOrderPartsDataGridView.Columns.Item(i).Visible = True
                Case "WorkOrderPartsTable.Unit_ShortText3"
                    WorkOrderPartsDataGridView.Columns.Item(i).HeaderText = "WO UNIT"
                    WorkOrderPartsDataGridView.Columns.Item(i).Width = 100
                    WorkOrderPartsDataGridView.Columns.Item(i).Visible = True
                Case "PartSpecifications_ShortText255"
                    WorkOrderPartsDataGridView.Columns.Item(i).HeaderText = "Part Specifications"
                    WorkOrderPartsDataGridView.Columns.Item(i).Width = 400
                    WorkOrderPartsDataGridView.Columns.Item(i).Visible = True
                    WorkOrderPartsDataGridView.Columns.Item(i).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                Case "StatusText_ShortText25"
                    WorkOrderPartsDataGridView.Columns.Item(i).HeaderText = "Status"
                    WorkOrderPartsDataGridView.Columns.Item(i).Width = 100
                    WorkOrderPartsDataGridView.Columns.Item(i).Visible = True
            End Select
            If WorkOrderPartsDataGridView.Columns.Item(i).Visible = True Then
                WorkOrderPartsDataGridView.Width = WorkOrderPartsDataGridView.Width + WorkOrderPartsDataGridView.Columns.Item(i).Width
            End If
        Next
        If WorkOrderPartsDataGridView.Width + WorkOrderReceivedPartsDataGridView.Width > Me.Width Then
            WorkOrderPartsDataGridView.Width = Me.Width - WorkOrderReceivedPartsDataGridView.Width - 4
        End If
        WorkOrderPartsDataGridView.Left = (Me.Width - WorkOrderPartsDataGridView.Width) / 2
        WorkOrderReceivedPartsDataGridView.Left = (Me.Width - WorkOrderReceivedPartsDataGridView.Width) / 2
    End Sub

    Private Sub WorkOrderPartsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles WorkOrderPartsDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If Me.Enabled = False Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If WorkOrderPartsRecordCount = 0 Then Exit Sub


        CurrentWorkOrderPartsRow = e.RowIndex
        If IsNotEmpty(WorkOrderPartsDataGridView.Item("MasterCodeBookID_Autonumber", CurrentWorkOrderPartsRow).Value) Then
            CurrentMasterCodeBookID = WorkOrderPartsDataGridView.Item("MasterCodeBookID_Autonumber", CurrentWorkOrderPartsRow).Value
        Else
            CurrentMasterCodeBookID = -1
        End If
        FillField(CurrentWorkOrderPartID, WorkOrderPartsDataGridView.Item("WorkOrderPartID_AutoNumber", CurrentWorkOrderPartsRow).Value)
        FillField(PartDescriptionTextBox.Text, WorkOrderPartsDataGridView.Item("SystemDesc_ShortText100Fld", CurrentWorkOrderPartsRow).Value)
        FillField(CurrentCodeVehicleID, WorkOrderPartsDataGridView.Item("CodeVehicleID_LongInteger", CurrentWorkOrderPartsRow).Value)

        'FOLLOWING UPDATES THOSE OLD RECORDS WITH NO CODEVEHICLE REFERENCE
        If CurrentCodeVehicleID < 1 Then
            MsgBox("CodeVehicleID is not updated" & vbCrLf & "Will be  updated")
            GetCodeVehicleID(CurrentMasterCodeBookID, CurrentVehicleID)
            Dim RecordFilter = " WHERE WorkOrderPartID_AutoNumber = " & CurrentWorkOrderPartID.ToString
            Dim SetCommand = " SET CodeVehicleID_LongInteger = " & CurrentCodeVehicleID.ToString
            UpdateTable("WorkOrderPartsTable", SetCommand, RecordFilter)

        End If


        If RegisterReceivedPartFromCustomerToolStripMenuItem.Visible = True Then
            WorkOrderReceivedPartsSelectionFilter = " WHERE WorkOrderPartID_LongInteger = " & CurrentWorkOrderPartID.ToString
            FillWorkOrderReceivedPartsDataGridView()
        End If

    End Sub
    Private Sub FillSpecificationsTable()



        SpecificationsFieldsToSelect =
"
SELECT PartVehicleSpecificationsTable.PartVehicleSpecificationID_AutoNumber, SpecificationsTable.SpecificationID_AutoNumber, SpecificationsTable.PartSpecifications_ShortText255, CodeVehiclesTable.CodeVehicleID_AutoNumber
FROM (PartVehicleSpecificationsTable LEFT JOIN CodeVehiclesTable ON PartVehicleSpecificationsTable.CodeVehicleID_LongInteger = CodeVehiclesTable.CodeVehicleID_AutoNumber) LEFT JOIN SpecificationsTable ON PartVehicleSpecificationsTable.SpecificationID_LongInteger = SpecificationsTable.SpecificationID_AutoNumber
"

        MySelection = SpecificationsFieldsToSelect & SpecificationsSelectionFilter
        JustExecuteMySelection()
        SpecificationsRecordCount = RecordCount

        SpecificationsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If Not SpecificationsGridViewAlreadyFormated Then
            SpecificationsGridViewAlreadyFormated = True
            FormatSpecificationsDataGridView()
        End If

        Dim NoOfHeaderLines = 1
        Dim RecordsDisplyed = SpecificationsRecordCount
        If SpecificationsRecordCount > 2 Then
            RecordsDisplyed = 2
        Else
            RecordsDisplyed = SpecificationsRecordCount
        End If
        SpecificationsDataGridView.Height = (SpecificationsDataGridView.ColumnHeadersHeight * NoOfHeaderLines) + (DataGridViewRowHeight * (RecordsDisplyed + 1))

    End Sub
    Private Sub FormatSpecificationsDataGridView()
        SpecificationsDataGridView.Width = 0
        For i = 0 To SpecificationsDataGridView.Columns.GetColumnCount(0) - 1

            SpecificationsDataGridView.Columns.Item(i).Visible = False
            Select Case SpecificationsDataGridView.Columns.Item(i).Name
                Case "PartSpecifications_ShortText255"
                    SpecificationsDataGridView.Columns.Item(i).HeaderText = "SPECIFICATIONS"
                    SpecificationsDataGridView.Columns.Item(i).Width = 400
                    SpecificationsDataGridView.Columns.Item(i).Visible = True
            End Select
            If SpecificationsDataGridView.Columns.Item(i).Visible = True Then
                SpecificationsDataGridView.Width = SpecificationsDataGridView.Width + SpecificationsDataGridView.Columns.Item(i).Width
            End If
        Next
    End Sub

    Private Sub FillWorkOrderReceivedPartsDataGridView()

        WorkOrderReceivedPartsFieldsToSelect =
"
SELECT WorkOrderReceivedPartsTable.WorkOrderPartID_LongInteger, WorkOrderReceivedPartsTable.WorkOrderReceivedPartID_AutoNumber, ProductsPartsTable.ProductsPartID_Autonumber, ProductsPartsTable.ManufacturerPartNo_ShortText30Fld, ProductsPartsTable.ManufacturerDescription_ShortText250, WorkOrderReceivedPartsTable.ReceivedQuantity_Double, ProductsPartsTable.Unit_ShortText3, ProductPartPackingsQuery.QuantityPerPack_Double, ProductPartPackingsQuery.UnitOfTheQuantity_ShortText3
FROM (WorkOrderReceivedPartsTable LEFT JOIN ProductsPartsTable ON WorkOrderReceivedPartsTable.ProductPartID_LongInteger = ProductsPartsTable.ProductsPartID_Autonumber) LEFT JOIN ProductPartPackingsQuery ON ProductsPartsTable.ProductsPartID_Autonumber = ProductPartPackingsQuery.ProductPartID_LongInteger
"
        MySelection = WorkOrderReceivedPartsFieldsToSelect & WorkOrderReceivedPartsSelectionFilter
        JustExecuteMySelection()
        WorkOrderReceivedPartsRecordCount = RecordCount
        If WorkOrderReceivedPartsRecordCount > 0 Then
            RegisterReceivedPartFromCustomerToolStripMenuItem.Visible = True
        End If
        WorkOrderReceivedPartsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If Not WorkOrderReceivedPartsGridViewAlreadyFormated Then
            WorkOrderReceivedPartsGridViewAlreadyFormated = True
            FormatWorkOrderReceivedPartsDataGridView()
        End If

        Dim NoOfHeaderLines = 1
        Dim RecordsDisplyed = WorkOrderReceivedPartsRecordCount
        If WorkOrderReceivedPartsRecordCount > 10 Then
            RecordsDisplyed = 10
        Else
            RecordsDisplyed = WorkOrderReceivedPartsRecordCount
        End If
        WorkOrderReceivedPartsDataGridView.Height = (WorkOrderReceivedPartsDataGridView.ColumnHeadersHeight * NoOfHeaderLines) + (DataGridViewRowHeight * (RecordsDisplyed + 1))

    End Sub
    Private Sub FormatWorkOrderReceivedPartsDataGridView()
        WorkOrderReceivedPartsDataGridView.Width = 0
        For i = 0 To WorkOrderReceivedPartsDataGridView.Columns.GetColumnCount(0) - 1

            WorkOrderReceivedPartsDataGridView.Columns.Item(i).Visible = False
            Select Case WorkOrderReceivedPartsDataGridView.Columns.Item(i).Name
                Case "ManufacturerPartNo_ShortText30Fld"
                    WorkOrderReceivedPartsDataGridView.Columns.Item(i).HeaderText = "Manuf Part Number"
                    WorkOrderReceivedPartsDataGridView.Columns.Item(i).Width = 150
                    WorkOrderReceivedPartsDataGridView.Columns.Item(i).Visible = True
                Case "ManufacturerDescription_ShortText250"
                    WorkOrderReceivedPartsDataGridView.Columns.Item(i).HeaderText = "Product "
                    WorkOrderReceivedPartsDataGridView.Columns.Item(i).Width = 400
                    WorkOrderReceivedPartsDataGridView.Columns.Item(i).Visible = True
                Case "ReceivedQuantity_Double"
                    WorkOrderReceivedPartsDataGridView.Columns.Item(i).HeaderText = "Received QTY"
                    WorkOrderReceivedPartsDataGridView.Columns.Item(i).Width = 100
                    WorkOrderReceivedPartsDataGridView.Columns.Item(i).Visible = True
                Case "Unit_ShortText3"
                    WorkOrderReceivedPartsDataGridView.Columns.Item(i).HeaderText = "UNIT"
                    WorkOrderReceivedPartsDataGridView.Columns.Item(i).Width = 100
                    WorkOrderReceivedPartsDataGridView.Columns.Item(i).Visible = True
            End Select
            If WorkOrderReceivedPartsDataGridView.Columns.Item(i).Visible = True Then
                WorkOrderReceivedPartsDataGridView.Width = WorkOrderReceivedPartsDataGridView.Width + WorkOrderReceivedPartsDataGridView.Columns.Item(i).Width
            End If
        Next
    End Sub

    Private Sub WorkOrderReceivedPartsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles WorkOrderReceivedPartsDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If Me.Enabled = False Then Exit Sub
        RemoveProductToolStripMenuItem.Visible = False
        If e.RowIndex < 0 Then Exit Sub
        If WorkOrderReceivedPartsRecordCount = 0 Then Exit Sub
        RemoveProductToolStripMenuItem.Visible = True
        CurrentWorkOrderReceivedPartsRow = e.RowIndex
        FillField(CurrentWorkOrderReceivedPartID, NotNull(WorkOrderReceivedPartsDataGridView.Item("WorkOrderReceivedPartID_AutoNumber", CurrentWorkOrderReceivedPartsRow).Value))
    End Sub

    Private Sub ReturnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnToolStripMenuItem.Click
        If SaveToolStripMenuItem.Visible = True Then
            SaveChanges()
            If ChangesOccured Then
                FillWorkOrderPartsDataGridView()
            End If
            PartDetailsGroupBox.Visible = False
            SaveToolStripMenuItem.Visible = False
        Else
            If SubmitRequestForPartsToolStripMenuItem.Visible = True Then
                If NoHeaderFound And WorkOrderPartsRecordCount > 0 Then
                    InsertNewWorkOrderPartsRequisition()
                End If
            End If
            DoCommonHouseKeeping(Me, SavedCallingForm)
        End If
    End Sub
    Private Sub SpecificationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SpecificationsToolStripMenuItem.Click
        Tunnel1 = "Tunnel2IsMasterCodeBookID"
        Tunnel2 = CurrentMasterCodeBookID
        Tunnel3 = PartDescriptionTextBox.Text & " for " & CurrentVehicleString
        ShowCalledForm(Me, PartsSpecificationsForm)
    End Sub
    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        ChangesOccured = False
        SaveChanges()
        If ChangesOccured Then
            FillWorkOrderPartsDataGridView()
            PartDetailsGroupBox.Visible = False
            SaveToolStripMenuItem.Visible = False
        End If
    End Sub

    Private Sub SaveChanges()
        If Not ValidPartEntries() Then Exit Sub
        SavePartChanges()
        If CurrentWorkOrderPartID < 0 Then Exit Sub 'NOTE THERE IS NO PART SO NO NEED FOR PRODUCT
        If Not Me.Text = "Receive parts from the Customer" Then Exit Sub
        If Not ValidProductEntries() Then Exit Sub
        SaveProductChanges()
    End Sub
    Private Function ValidPartEntries()
        If IsEmpty(PartDescriptionTextBox.Text) Then
            MsgBox("No Part is entered")
            PartDescriptionTextBox.Select()
            Return False
        End If
        If IsEmpty(OrderedQuantityTextBox.Text) Then
            MsgBox("quantity required")
            OrderedQuantityTextBox.Select()
            Return False
        End If
        Return True
    End Function
    Private Sub SavePartChanges()
        If AChangeInWorkOrderPartsOccured() Then
            ChangesOccured = True
            If IsEmpty(OrderedQuantityTextBox.Text) Then
                If MsgBox("Quantity is empty, want to cancel changes", MsgBoxStyle.YesNo) = vbYes Then Exit Sub
                OrderedQuantityTextBox.Select()
                Exit Sub
            End If
            Dim xxmsgResult = MsgBox("Save Changes in the Required parts?", MsgBoxStyle.YesNoCancel)
            If xxmsgResult = vbNo Then
                RequisitionDetailsGroupBox.Visible = False
                Exit Sub
            ElseIf xxmsgResult = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            RegisterWorkOrderPartsChanges()
        End If
    End Sub
    Private Function ValidProductEntries()
        If IsEmpty(CustomerSuppliedQuantityTextBox.Text) Then
            MsgBox("quantity required")
            CustomerSuppliedQuantityTextBox.Select()
            Return False
        End If
        Return True
    End Function
    Private Sub SaveProductChanges()
        If AChangeInCustomerSuppliedPartsOccured() Then
            ChangesOccured = True
            Dim xxmsgResult = MsgBox("Save Changes in the Required parts?", MsgBoxStyle.YesNoCancel)
            If xxmsgResult = vbNo Then
                RequisitionDetailsGroupBox.Visible = False
                Exit Sub
            ElseIf xxmsgResult = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            RegisterCustomerSuppliedPartsChanges()
        End If
    End Sub
    Private Function AChangeInWorkOrderPartsOccured()

        '*******************************************************
        ' CHECK THIS THE TheseAreNotEqual ROUTINE WAS MODIFIED, WATCH PARAMETER pURPOSEOFENTRY
        If WorkOrderPartsRecordCount < 1 Then
            If Trim(PartDescriptionTextBox.Text) <> "" Then Return True
            If Trim(SpecifiedQuantityTextBox.Text) <> "" Then Return True
            If Trim(SpecifiedUnitTextBox.Text) <> "" Then Return True
            Return False
        Else
            If CurrentWorkOrderPartsRow > -1 Then
                If TheseAreNotEqual(PartDescriptionTextBox.Text, WorkOrderPartsDataGridView.Item("SystemDesc_ShortText100Fld", CurrentWorkOrderPartsRow).Value, PurposeOfEntry) Then Return True
                If TheseAreNotEqual(OrderedQuantityTextBox.Text, WorkOrderPartsDataGridView.Item("Quantity_Integer", CurrentWorkOrderPartsRow).Value, PurposeOfEntry) Then Return True
            Else
                If Not IsEmpty(PartDescriptionTextBox.Text) Then Return True
            End If
        End If
        Return False
    End Function
    Private Function AChangeInCustomerSuppliedPartsOccured()
        If WorkOrderReceivedPartsRecordCount < 1 Then
            If Trim(ProductTextBox.Text) <> "" And
           Trim(CustomerSuppliedQuantityTextBox.Text) <> "" Then Return True
        Else
            If TheseAreNotEqual(ProductTextBox.Text, NotNull(WorkOrderReceivedPartsDataGridView.Item("ManufacturerDescription_ShortText250", CurrentWorkOrderPartsRow).Value), PurposeOfEntry) Then Return True
            If TheseAreNotEqual(CustomerSuppliedQuantityTextBox.Text, NotNull(WorkOrderReceivedPartsDataGridView.Item("ReceivedQuantity_Double", CurrentWorkOrderPartsRow).Value), PurposeOfEntry) Then Return True
            If TheseAreNotEqual(CustomerSuppliedUnitTextBox.Text, NotNull(WorkOrderReceivedPartsDataGridView.Item("Unit_ShortText3", CurrentWorkOrderPartsRow).Value), PurposeOfEntry) Then Return True
        End If
        Return False
    End Function
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
        Dim FieldsToUpdate = "  WorkOrderPartsRequisitionID_LongInteger, " &
                       "  WorkOrderID_LongInteger, " &
                       "  WorkOrderConcernJobID_LongInteger, " &
                       "  InformationsHeaderID_LongInteger, " &
                       "  MasterCodeBookID_LongInteger, " &
                       "  CodeVehicleID_LongInteger, " &
                       "  Quantity_Integer, " &
                       " Unit_ShortText3 "

        Dim FieldsData = CurrentWorkOrderPartsRequisitionID.ToString & ",  " &
                                  CurrentWorkOrderID.ToString & ",  " &
                                  CurrentWorkOrderConcernJobID.ToString & ",  " &
                                  CurrentInformationsHeaderID.ToString & ",  " &
                                  CurrentMasterCodeBookID.ToString & ",  " &
                                  CurrentCodeVehicleID.ToString & ",  " &
                                  Val(SpecifiedQuantityTextBox.Text).ToString & ",  " &
                                  Chr(34) & SpecifiedUnitTextBox.Text & Chr(34)

        CurrentWorkOrderPartID = InsertNewRecord("WorkOrderPartsTable", FieldsToUpdate, FieldsData)
    End Sub
    Private Sub UpdateWorkOrderPart()
        If MsgBox("About to replace original informations, Continue ?", MsgBoxStyle.YesNo) = vbNo Then
            Exit Sub
        End If
        Dim RecordFilter = " WHERE WorkOrderPartID_AutoNumber = " & CurrentWorkOrderPartID.ToString
        Dim SetCommand = " SET MasterCodeBookID_LongInteger = " & CurrentMasterCodeBookID.ToString & "," &
                                      "Unit_ShortText3 = " & Chr(34) & LTrim(Trim(SpecifiedUnitTextBox.Text)) & Chr(34) & "," &
                                      "Quantity_Integer = " & Val(OrderedQuantityTextBox.Text).ToString
        UpdateTable("WorkOrderPartsTable", SetCommand, RecordFilter)
    End Sub
    Private Sub RegisterCustomerSuppliedPartsChanges()
        CurrentWorkOrderReceivedPartID = -1
        MySelection = " Select top 1 * FROM WorkOrderReceivedPartsTable WHERE WorkOrderPartID_LongInteger = " & CurrentWorkOrderPartID.ToString &
                                      " AND ProductPartID_LongInteger = " & CurrentProductPartID.ToString

        JustExecuteMySelection()
        If RecordCount = 0 Then
            InsertNewWorkOrderWorkOrderReceivedPart()
        Else
            UpdateWorkOrderWorkOrderReceivedPart()
        End If
    End Sub

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
                                  GetStatusIdFor("WorkOrderReceivedPartsTable").ToString()

        CurrentWorkOrderPartID = InsertNewRecord("WorkOrderReceivedPartsTable", FieldsToUpdate, FieldsData)

        'NOW UPDATE owner JOB, CONCERN AND WORKORDER

        Dim RecordFilter = " WHERE WorkOrderConcernJobID_AutoNumber = " & CurrentWorkOrderConcernJobID.ToString
        Dim SetCommand = " SET WorkOrderConcernJobStatusID_LongInteger = " & GetStatusIdFor("WorkOrderConcernJobsTable", "Parts From Customer").ToString
        UpdateTable("WorkOrderConcernJobsTable", SetCommand, RecordFilter)

        RecordFilter = " WHERE WorkOrderConcernID_AutoNumber = " & CurrentWorkOrderConcernID.ToString
        SetCommand = " SET WorkOrderConcernStatusI_LongInteger = " & GetStatusIdFor("WorkOrderConcernsTable", "Parts From Customer").ToString
        UpdateTable("WorkOrderConcernsTable", SetCommand, RecordFilter)

        RecordFilter = " WHERE WorkOrderID_AutoNumber = " & CurrentWorkOrderID.ToString
        SetCommand = " SET WorkOrderStatusID_LongInteger = " & GetStatusIdFor("WorkOrdersTable", "Awaiting Parts").ToString
        UpdateTable("WorkOrdersTable", SetCommand, RecordFilter)
    End Sub
    Private Sub UpdateWorkOrderWorkOrderReceivedPart()
        If MsgBox("About to replace original informations, Continue ?", MsgBoxStyle.YesNo) = vbNo Then
            Exit Sub
        End If
        Dim RecordFilter = " WHERE WorkOrderPartID_AutoNumber = " & CurrentWorkOrderPartID.ToString
        Dim SetCommand = " SET MasterCodeBookID_LongInteger = " & CurrentMasterCodeBookID.ToString & "," &
                                      "Unit_ShortText3 = " & Chr(34) & LTrim(Trim(SpecifiedUnitTextBox.Text)) & Chr(34) & "," &
                                      "Quantity_Integer = " & Val(SpecifiedQuantityTextBox.Text).ToString
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
                PartDetailsGroupBox.Visible = True
            Case "Tunnel2IsProductPartID"
                CurrentProductPartID = Tunnel2
                If IsEmpty(PackingTextBox.Text) Then
                    PackingTextBox.Visible = False
                    PackingLabel.Visible = False
                Else
                    PackingTextBox.Visible = True
                    PackingLabel.Visible = True
                End If
                If IsEmpty(CustomerSuppliedQuantityTextBox.Text) Then
                    CustomerSuppliedQuantityTextBox.Select()
                End If
                Exit Sub
        End Select
        FillWorkOrderPartsDataGridView()
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemovePartToolStripMenuItem.Click
        If WorkOrderReceivedPartsRecordCount > 0 Then
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
        ' BUT AT THIS POINT REQUISITION REVISION IS NOT YET PROVIDED
        Dim ValidationMsg = ""
        Dim ExitLoop = False
        Dim GridViewIndex = 0
        WorkOrderPartsDataGridView.Rows(CurrentWorkOrderPartsRow).Selected = False
        'validation
        For GridViewIndex = 0 To WorkOrderPartsRecordCount - 1
            WorkOrderPartsDataGridView.Rows(GridViewIndex).Selected = True
            If NotNull(WorkOrderPartsDataGridView.Item("Quantity_Integer", GridViewIndex).Value) < 1 Then
                SpecifiedQuantityTextBox.Select()
                ValidationMsg = "Please put a quantity"
                ExitLoop = True
                Exit For

            ElseIf NotNull(WorkOrderPartsDataGridView.Item("Unit_ShortText3", GridViewIndex).Value) = "" Then
                SpecifiedUnitTextBox.Select()
                ValidationMsg = "Please put a unit"
                ExitLoop = True
                Exit For
            End If
            WorkOrderPartsDataGridView.Rows(GridViewIndex).Selected = False
        Next
        If ExitLoop Then
            CurrentWorkOrderPartsRow = GridViewIndex
            LoadPartDetails()
            MsgBox(ValidationMsg)
            Exit Sub
        End If
        'validation

        WorkOrderPartsDataGridView.Rows(CurrentWorkOrderPartsRow).Selected = True
        Dim xxFilter = ""
        Dim xxJobStatus = 1
        If Not MsgBox("Sure all parts needed for each job are attached to the requisition? ", vbYesNoCancel) = vbYes Then
            Exit Sub
        End If

        ' GO THROUGH ALL THE JOBS
        If NoHeaderFound Then
            InsertNewWorkOrderPartsRequisition()
        Else
            WorkOrderPartsRequisitionStatusID = 12 ' "set status to Request Submitted"
            UpdateWorkOrderPartsRequisition()
        End If
        For i = 0 To WorkOrderConcernJobsRecordCount - 1
            xxJobStatus = 1
            WorkOrderConcernJobTextBox.Text = WorkOrderConcernJobsDataGridView.Item("JobDescription", i).Value
            CurrentWorkOrderConcernJobID = WorkOrderConcernJobsDataGridView.Item("WorkOrderConcernJobID_AutoNumber", i).Value
            CurrentInformationsHeaderID = WorkOrderConcernJobsDataGridView.Item("InformationsHeaderID_AutoNumber", i).Value
            If NotNull(WorkOrderConcernJobsDataGridView.Item("WorkOrderConcernJobStatus_Byte", i).Value) = 5 Then 'NO PART NEEDED
                Continue For
            End If

            'WORK ON THE PARTS FOR THIS JOB
            WorkOrderPartsSelectionFilter = " WHERE WorkOrderConcernJobID_AutoNumber = " & CurrentWorkOrderConcernJobID.ToString

            FillWorkOrderPartsDataGridView()
            If WorkOrderPartsRecordCount = 0 Then
                If MsgBox(WorkOrderConcernJobTextBox.Text & " has no part attached," & vbCrLf &
                " mark this as PART-LESS-JOB ? ", vbYesNoCancel) = vbYes Then
                    ' 0 - not yet worked on, 1- parts requested 2 parts received, 3 - Job Ongoing 4 - Done 5 - no part needed
                    xxJobStatus = 8
                End If
            Else
                Dim xxWorkOrderPartID_LongInteger = -1
                Dim xxProductPartID_LongInteger = -1
                Dim xxRequiredQuantity_Double = -1
                Dim xxUnit_ShortText3 = ""
                For j = 0 To WorkOrderPartsRecordCount - 1
                    FillField(xxWorkOrderPartID_LongInteger, WorkOrderPartsDataGridView.Item("WorkOrderPartID_AutoNumber", j).Value)
                    '                   FillField(xxProductPartID_LongInteger, WorkOrderPartsDataGridView.Item("ProductsPartID_Autonumber", j).Value)
                    FillField(xxRequiredQuantity_Double, WorkOrderPartsDataGridView.Item("Quantity_Integer", j).Value)
                    FillField(xxUnit_ShortText3, WorkOrderPartsDataGridView.Item("Unit_ShortText3", j).Value)

                    MySelection = "SELECT * FROM WorkOrderPartsRequisitionsItemsTable WHERE WorkOrderPartID_LongInteger = " & xxWorkOrderPartID_LongInteger.ToString
                    JustExecuteMySelection()

                    If RecordCount > 0 Then
                        MySelection = " UPDATE WorkOrderPartsRequisitionsItemsTable  " &
                                  " SET WorkOrderPartsRequisitionsID_LongInteger = " & CurrentWorkOrderPartsRequisitionID.ToString
                        xxFilter = " WHERE WorkOrderPartID_LongInteger = " & xxWorkOrderPartID_LongInteger.ToString &
                              " AND WorkOrderPartsRequisitionsID_LongInteger = -1 "

                        MySelection = MySelection & xxFilter
                        JustExecuteMySelection()

                    Else
                        Dim CurrentWorkOrderPartsRequisitionsItemStatus = GetStatusIdFor("WorkOrderPartsRequisitionsItemsTable")
                        Dim FieldsToUpdate =
                           "  WorkOrderPartID_LongInteger, " &
                           "  WorkOrderPartsRequisitionsID_LongInteger, " &
                           "  RequiredQuantity_Double, " &
                           "  Unit_ShortText3, " &
                           "  WorkOrderPartsRequisitionsItemStatus_Integer "


                        Dim FieldsData =
                                xxWorkOrderPartID_LongInteger.ToString & ", " &
                                CurrentWorkOrderPartsRequisitionID.ToString & ", " &
                                xxRequiredQuantity_Double.ToString & ", " &
                                Chr(34) & xxUnit_ShortText3 & Chr(34) & ", " &
                                CurrentWorkOrderPartsRequisitionsItemStatus.ToString

                        Dim xxDummy = InsertNewRecord("WorkOrderPartsRequisitionsItemsTable", FieldsToUpdate, FieldsData)
                    End If

                Next j
            End If

            MySelection = " UPDATE WorkOrderConcernJobsTable  " &
                                  " SET WorkOrderConcernJobStatus_Byte = " & xxJobStatus.ToString

            xxFilter = " WHERE WorkOrderConcernJobID_AutoNumber = " & CurrentWorkOrderConcernJobID.ToString
            MySelection = MySelection & xxFilter
            JustExecuteMySelection()
        Next i

        ' CHECK WorkOrderPartsRequisitionsTable IF THERE ALREADY EXIST A REQUEST FOR Parts for this workorder

        xxFilter = " WHERE WorkOrderID_LongInteger = " & CurrentWorkOrderID

        MySelection = "Select * From WorkOrderPartsRequisitionsTable " & xxFilter
        JustExecuteMySelection()




        'THEN UPDATE WorkOrdersTable TO 5 - Repair Ongoing
        xxFilter = " WHERE WorkOrderID_AutoNumber = " & CurrentWorkOrderID
        MySelection = " UPDATE WorkOrdersTable " &
                              " SET WorkOrderStatus_Byte = 5 "
        MySelection = MySelection & xxFilter
        JustExecuteMySelection()

        'THEN UPDATE WorkOrderConcernsTable.ConcernStatus_Byte TO 3 - Parts Requested
        xxFilter = " WHERE WorkOrderConcernID_AutoNumber = " & CurrentWorkOrderConcernID
        MySelection = " UPDATE WorkOrderConcernsTable " &
                              " SET WorkOrderConcernStatus_Byte = 3 "
        MySelection = MySelection & xxFilter

        JustExecuteMySelection()


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
                         GetStatusIdFor("WorkOrderPartsRequisitionsTable").ToString()

        CurrentWorkOrderPartsRequisitionID = InsertNewRecord("WorkOrderPartsRequisitionsTable", FieldsToUpdate, FieldsData)
    End Sub
    Private Sub UpdateWorkOrderPartsRequisition()
        Dim RecordFilter = " WHERE WorkOrderPartsRequisitionID_AutoNumber = " & CurrentWorkOrderPartsRequisitionID.ToString
        Dim SetCommand = " SET WorkOrderPartsRequisitionStatusID_Integer = " & WorkOrderPartsRequisitionStatusID.ToString()
        UpdateTable("WorkOrderPartsRequisitionsTable", SetCommand, RecordFilter)
    End Sub
    Private Sub GetStandarPartsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GetStandarPartsToolStripMenuItem.Click
        ' PARTS WILL BE SELECTED PER JOB AS EACH JOB WILL BE IDENTIFIED AND SEARCH THE WorkOrderConcernJobsTable FOR THE 1ST INSTANCE
        ' ONCE FOUND (EXISTS) EACH ATTACHED PARTS USED ARE IDENTIFIED AND ADDED TO THE REQUISITION
        ' a NEW REQUISITION HEADER (TEMPORARY) WILL BE CREATED UPON SAVE
        ' REQUISITION NO WILL BE THE WO NUMBER PREFIXED WITH R
        ' EACH REQUISITION WILL HAVE ITS REVISION NUMBER STARTING WITH 0

        For i = 0 To WorkOrderConcernJobsRecordCount - 1
            Dim xxJobID = WorkOrderConcernJobsDataGridView.Item("WorkOrderConcernJobID_AutoNumber", i).Value
            GetAttachedProducts(xxJobID)
        Next
    End Sub
    Private Sub GetAttachedProducts(JobID)
        'NOTES  1 - FIND 1ST OCCURRENCE OF THE PASSED JOBID
        '       2 - GET THE WORKORDER ID THEN FILTER RECORDS PER WORKORDER ID And JOB ID

        'USING WorkOrderPartsQuery
        Dim SavedFilter = WorkOrderPartsSelectionFilter
        CurrentInformationsHeaderID = JobID ' CurrentJobId will Be Used In the record insertion

        WorkOrderPartsSelectionFilter = " WHERE WorkOrderConcernJobsTable.WorkOrderConcernJobID_AutoNumber = " & CurrentWorkOrderConcernJobID

        FillWorkOrderPartsDataGridView()
        If WorkOrderPartsRecordCount > 0 Then

            Dim WorkingOnWorkOrder = WorkOrderPartsDataGridView.Item("WorkOrderID_LongInteger", 0).Value
            For i = 0 To WorkOrderPartsRecordCount - 1
                If WorkingOnWorkOrder <> WorkOrderPartsDataGridView.Item("WorkOrderID_LongInteger", i).Value Then Continue For

                'IF NO LINK TO THE ProductsPartsTable READ NEXT
                If IsEmpty(WorkOrderPartsDataGridView.Item("WorkOrderPartID_AutoNumber", i).Value) Then Continue For

                Dim xxQuantity = 1
                Dim xxUnit = "pc"
                Dim xxPartNumber = ""
                Dim xxMasterCodeBookId = -1
                If IsNotEmpty(WorkOrderPartsDataGridView.Item("MasterCodeBookID_LongInteger", i).Value) Then
                    xxMasterCodeBookId = WorkOrderPartsDataGridView.Item("MasterCodeBookID_LongInteger", i).Value
                Else
                    Continue For
                End If
                If IsNotEmpty(xxDataGridView.Item("Unit_ShortText3", i).Value) Then
                    xxUnit = WorkOrderPartsDataGridView.Item("Unit_ShortText3", i).Value

                End If
                If IsNotEmpty(xxDataGridView.Item("Quantity_Integer", i).Value) Then
                    xxQuantity = WorkOrderPartsDataGridView.Item("Quantity_Integer", i).Value
                End If

                ' TEST IF ALREADY IN THE LIST
                MySelection = " SELECT TOP 1 * FROM WorkOrderPartsTable " &
                               " WHERE WorkOrderPartsRequisitionID_LongInteger = " & CurrentWorkOrderPartsRequisitionID.ToString &
                               " AND MasterCodeBookID_LongInteger = " & xxMasterCodeBookId.ToString
                JustExecuteMySelection()
                If RecordCount > 0 Then Continue For
                InsertNewWorkOrderPart()
            Next
        End If
        WorkOrderPartsSelectionFilter = SavedFilter
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
        MySelection = " Select top 1 * FROM VolumeSpecificationsTable WHERE CodeVehicleID_LongInteger = " & CurrentCodeVehicleID.ToString &
                                                                        "AND InformationsHeaderID_LongInteger = " & CurrentWorkOrderConcernJobID
        JustExecuteMySelection()
        If RecordCount > 0 Then
            Dim r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
            SpecifiedQuantityTextBox.Text = r("VolumeQuantity_Double")
            SpecifiedUnitTextBox.Text = r("VolumeUnit_ShortText3")
        Else
            If Not IsEmpty(WorkOrderPartsDataGridView.Item("Quantity_Integer", CurrentWorkOrderPartsRow).Value) Then
                OrderedQuantityTextBox.Text = WorkOrderPartsDataGridView.Item("Quantity_Integer", CurrentWorkOrderPartsRow).Value
                SpecifiedUnitTextBox.Text = WorkOrderPartsDataGridView.Item("Unit_ShortText3", CurrentWorkOrderPartsRow).Value
            Else
                OrderedQuantityTextBox.Text = 1
                SpecifiedUnitTextBox.Text = "pc"
            End If
        End If

        SpecificationsSelectionFilter = " WHERE CodeVehicleID_AutoNumber = " & CurrentCodeVehicleID.ToString
        FillSpecificationsTable()

        PartDetailsGroupBox.Visible = True
        SaveToolStripMenuItem.Visible = True
        If WorkOrderReceivedPartsRecordCount > 0 Then
            FillField(ProductTextBox.Text, WorkOrderReceivedPartsDataGridView.Item("ManufacturerDescription_ShortText250", CurrentWorkOrderReceivedPartsRow).Value)
            FillField(PartNumberTextBox.Text, WorkOrderReceivedPartsDataGridView.Item("ManufacturerPartNo_ShortText30Fld", CurrentWorkOrderReceivedPartsRow).Value)
            FillField(CustomerSuppliedQuantityTextBox.Text, WorkOrderReceivedPartsDataGridView.Item("ReceivedQuantity_Double", CurrentWorkOrderReceivedPartsRow).Value)
            FillField(CustomerSuppliedUnitTextBox.Text, WorkOrderReceivedPartsDataGridView.Item("Unit_ShortText3", CurrentWorkOrderReceivedPartsRow).Value)
            If IsNotEmpty(WorkOrderReceivedPartsDataGridView.Item("QuantityPerPack_Double", CurrentWorkOrderReceivedPartsRow).Value) Then
                PackingTextBox.Text = WorkOrderReceivedPartsDataGridView.Item("QuantityPerPack_Double", CurrentWorkOrderReceivedPartsRow).Value.ToString & Space(1) &
                                      WorkOrderReceivedPartsDataGridView.Item("UnitOfTheQuantity_ShortText3", CurrentWorkOrderReceivedPartsRow).Value.ToString &
                                        " / " &
                                      WorkOrderReceivedPartsDataGridView.Item("Unit_ShortText3", CurrentWorkOrderReceivedPartsRow).Value.ToString
                PackingLabel.Visible = True
                PackingTextBox.Visible = True
            Else
                PackingLabel.Visible = False
                PackingTextBox.Visible = False
            End If

        Else
            ProductTextBox.Text = ""
            PartNumberTextBox.Text = ""

            CustomerSuppliedQuantityTextBox.Text = SpecifiedQuantityTextBox.Text
            CustomerSuppliedUnitTextBox.Text = SpecifiedUnitTextBox.Text
        End If
    End Sub

    Private Sub PartDetailsGroupBox_Enter(sender As Object, e As EventArgs) Handles PartDetailsGroupBox.VisibleChanged
        If PartDetailsGroupBox.Visible = True Then
            SaveToolStripMenuItem.Visible = True
            SpecificationsToolStripMenuItem.Visible = True
            GetStandarPartsToolStripMenuItem.Visible = False
            AddPartToolStripMenuItem.Visible = False
            EditPartToolStripMenuItem.Visible = False
            RemovePartToolStripMenuItem.Visible = False
            If Me.Text = "Receive parts from the Customer" Then
                RegisterReceivedPartFromCustomerToolStripMenuItem.Visible = False
            End If
            WorkOrderConcernJobsDataGridView.Enabled = False
            RequisitionDetailsGroupBox.Visible = False
        Else
            GetStandarPartsToolStripMenuItem.Visible = True
            AddPartToolStripMenuItem.Visible = True
            EditPartToolStripMenuItem.Visible = True
            RemovePartToolStripMenuItem.Visible = True
            SaveToolStripMenuItem.Visible = False
            WorkOrderConcernJobsDataGridView.Enabled = True
            RequisitionDetailsGroupBox.Visible = True
            SpecificationsToolStripMenuItem.Visible = False
            If Me.Text = "Receive parts from the Customer" Then
                RegisterReceivedPartFromCustomerToolStripMenuItem.Visible = True
            End If
        End If
    End Sub
    Private Sub ReceivedPartDescTextBox_TextChanged(sender As Object, e As EventArgs) Handles ProductTextBox.Click
        If ProductTextBox.Text <> "" Then
            If MsgBox("Do you intend to update the Product?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        ProductsPartsForm.PartNoToolStripTextBox.Text = PartNumberTextBox.Text
        ProductsPartsForm.SearchDescriptionToolStripTextBox.Text = PartDescriptionTextBox.Text

        ShowCalledForm(Me, ProductsPartsForm)

    End Sub

    Private Sub RemoveProductToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveProductToolStripMenuItem.Click
        If MsgBox("Do you really want To Delete This Item ?", vbYesNo) = vbYes Then
            MySelection = "DELETE FROM WorkOrderReceivedPartsTable WHERE WorkOrderReceivedPartID_AutoNumber = " & Str(CurrentWorkOrderReceivedPartID)
            JustExecuteMySelection()
            FillWorkOrderReceivedPartsDataGridView()
        End If
    End Sub

    Private Sub RegisterReceivedPartFromCustomerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegisterReceivedPartFromCustomerToolStripMenuItem.Click
        If MsgBox("About to replace original informations, Continue ?", MsgBoxStyle.YesNo) = vbNo Then
            Exit Sub
        End If
        Dim RecordFilter = ""
        Dim SetCommand = ""
        For i = 0 To WorkOrderReceivedPartsRecordCount - 1
            FillField(CurrentWorkOrderReceivedPartID, NotNull(WorkOrderReceivedPartsDataGridView.Item("WorkOrderReceivedPartID_AutoNumber", i).Value))
            RecordFilter = " WHERE WorkOrderReceivedPartID_AutoNumber = " & CurrentWorkOrderReceivedPartID.ToString
            SetCommand = " SET WorkOrderReceivedPartStatusID_LongInteger = " & GetStatusIdFor("WorkOrderReceivedPartsTable", "Received From Customer").ToString
            UpdateTable("WorkOrderReceivedPartsTable", SetCommand, RecordFilter)
        Next
        'NOW UPDATE owner JOB, CONCERN AND WORKORDER
        RecordFilter = " WHERE WorkOrderConcernJobID_AutoNumber = " & CurrentWorkOrderConcernJobID.ToString
        SetCommand = " SET WorkOrderConcernJobStatusID_LongInteger = " & GetStatusIdFor("WorkOrderConcernJobsTable", "Customer Parts Received").ToString
        UpdateTable("WorkOrderConcernJobsTable", SetCommand, RecordFilter)


        RecordFilter = " WHERE WorkOrderID_AutoNumber = " & CurrentWorkOrderID.ToString
        SetCommand = " SET WorkOrderStatusID_LongInteger = " & GetStatusIdFor("WorkOrdersTable", "Parts Received").ToString
        UpdateTable("WorkOrdersTable", SetCommand, RecordFilter)
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub
End Class