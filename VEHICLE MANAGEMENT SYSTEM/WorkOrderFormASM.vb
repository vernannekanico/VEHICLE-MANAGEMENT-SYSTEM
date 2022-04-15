Public Class WorkOrderFormASM

    Private CurrentWorkOrderNumber As String

    Private CurrentConcernID As Integer = -1
    Private CurrentJobID As Integer = -1

    '    Private CurrentWorkOrderConcernID As Integer = -1
    Private CurrentWorkOrderConcernsRow As Integer
    Private WorkOrderConcernsRecordCount As Integer = -1
    Private CurrentWorkOrderConcernID As Integer = -1
    Private CurrentLongTextConcernID = -1
    Private CurrentCustomerID As Integer = -1
    Private CurrentServicedVehicleID As Integer = -1

    Private AssignedPersonnelID As Integer

    Private WorkOrdersTable As New MyDbControls
    Private WorkOrdersFieldsToSelect = ""
    Private WorkOrdersTableLinks = ""
    Private WorkOrdersSelectionFilter = ""
    Private WorkOrdersSelectionOrder = ""
    Private CurrentWorkOrdersRow As Integer = -1
    Private WorkOrdersRecordCount As Integer = -1
    Private CurrentWorkOrderStatus As String

    Private WorkOrderStatusSelection As Integer = 1
    Private WorkOrdersDataGridViewAlreadyFormatted = False

    Private WorkOrderConcernsFieldsToSelect = ""
    Private WorkOrderConcernsTablesLinks = ""
    Private WorkOrderConcernsSelectionFilter = ""
    '   Private WorkOrderConcernsSelectionFilterSaved = ""
    Private WorkOrderConcernsSelectionOrder = ""
    Private WorkOrderConcernsDataGridViewLocationX As Integer
    Private WorkOrderConcernsDataGridViewLocationY As Integer
    Private CurrentInformationsHeaderID As Integer
    Private WorkOrderConcernsDataGridViewAlreadyFormatted = False
    '   Private Savedmilage As Integer
    Private SavedCustomer = ""
    '   Private VINSaved As String
    Private PurposeOfEntry As String
    '   Dim NewWorkOrderFormYAxis = Me.Location.Y + 100

    Private WorkOrderConcernJobsFieldsToSelect = " "
    Private WorkOrderConcernJobsTablesLinks = "   "
    Private WorkOrderConcernJobsSelectionFilter = " "
    Private WorkOrderConcernJobsSelectionOrder = " "
    Private WorkOrderConcernJobsRecordCount = 0
    Private CurrentWorkOrderConcernJobID As Integer = -1
    Private CurrentWorkOrderConcernJobsRow = -1
    Private WorkOrderConcernJobsDataGridViewFormatted = False

    Private WorkOrderStatus = ""
    Private WorkOrderPartsPerJobFieldsToSelect = " "
    Private WorkOrderPartsPerJobTablesLinks = "   "
    Private WorkOrderPartsPerJobSelectionFilter = " "
    Private WorkOrderPartsPerJobSelectionOrder = " "
    Private WorkOrderPartsPerJobRecordCount = 0
    Private CurrentWorkOrderPartsPerJobID As Integer = -1
    Private CurrentWorkOrderPartsPerJobRow = -1
    Private WorkOrderPartsPerJobDataGridViewAlreadyFormatted = False

    Public OutstandingForThisUserFilter = ""
    Private AssignmentIsFor = ""
    Private SavedCallingForm As Form

    Private Sub WorkOrderForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RequestPartsFromWarehouseToolStripMenuItem.Text = "Request Parts"
        CustomerSuppliedPartsToolStripMenuItem.Text = "Customer Supplied Parts"
        SavedCallingForm = CallingForm
        ' INITIALIZE FIRST ALL DATAGRIDVIEWS for enabling all its field for reference
        '        FillWorkOrdersDataGridView()

        '        FormatWorkOrderConcernsDataGridView()

        If CurrentUserGroup = "Automotive Service Specialist" Then
            WorkOrderConcernJobsSelectionFilter = " WHERE (WorkOrderConcernJobStatus_Byte  < 2 ) " &
                    " AND WorkOrderConcernJobsTable.AssignedServiceSpecialist_LongInteger = " & CurrentPersonelID.ToString
            FillWorkOrderConcernJobsTable()
            FormatWorkOrderConcernJobsDataGridView()
            FillWorkOrdersDataGridView()
            Exit Sub
        Else
            SetupFormUserAccess()
            SetupWorkOrderSelection(0)                      ' 0 is used to display outstanding
            FillWorkOrdersDataGridView()
        End If
        ' for the logged in user. this routine proceeds to FillWorkOrdersDataGridView()
        WorkOrderConcernsDataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True '(1 - Property state = true, 2- false, 3-default on development
        Me.Top = VehicleManagementSystemForm.VehicleManagementMenuStrip.Top + VehicleManagementSystemForm.VehicleManagementMenuStrip.Height
        WorkOrdersGroupBox.Top = WorkOrderFormASMMenuStrip.Top + WorkOrderFormASMMenuStrip.Height

    End Sub
    Private Sub SetupFormUserAccess()
        DisAbleAccessForAll()
        '0   Temporary entry status					SubmitForService
        'Updated during registation by CSS
        'Outstanding job for the CSS

        '1   For Analysis status, outstanding for the ASM
        'Updated to 2 upon assignment to LeadASS

        '2   For assignment status, outstanding for the LeadASS
        'Updated when all jobs are assigned setting status to 4
        'Updated when all jobs are completed  setting status to 3     

        '3   Jobs done status., outstanding for CSS
        'Updated when ready for billing, updated to status 8

        '4   For assignment to Lead service Specialist, outstanding for ASS, SS
        'updated when job(s) are done setting status to 5

        '5   Partially complete status,  outstanding for the LASS
        ' updated when specific job(s) are done

        '8   For Payment outstanding for the Cashier
        'Updated to 9 when fully paid

        '9   Vehicle Released

        Select Case CurrentUserGroup
            Case "Customer Service Specialist"
                OutstandingForThisUserFilter = " WHERE (WorkOrderStatus_Byte  = 0 OR WorkOrderStatus_Byte = 3)"
            Case "Assistant Service Manager"
                OutstandingForThisUserFilter = " WHERE (WorkOrderStatus_Byte  = 1)"
            Case "Lead Service Specialist"
                OutstandingForThisUserFilter = " WHERE (WorkOrderStatus_Byte  > 1 AND WorkOrderStatus_Byte  < 6) " &
                    " AND AssignedLeadMechanic_longInteger = " & CurrentPersonelID.ToString
                'NOTE: >1AND<6 COVERS ALL OUTSTANDING WORK ASSIGNED TO A Lead Service Specialist
            Case "Systems Manager"
                OutstandingForThisUserFilter = ""
            Case Else
                MsgBox("BREAK, SETUP THIS USER")
                Exit Sub
        End Select

    End Sub

    Private Sub DisAbleAccessForAll()
        CONCERNToolStripMenuItem.Visible = False
        AssignConcernToolStripMenuItem.Visible = False
        JOBToolStripMenuItem.Visible = False
        AddJobToolStripMenuItem.Visible = False
        EditToolStripMenuItem.Visible = False
        AssignJobToolStripMenuItem.Visible = False
        ProcessJobToolStripMenuItem.Visible = False
        RemoveJobToolStripMenuItem.Visible = False
        AssignWorkOrderToolStripMenuItem.Visible = False
        RevertStatusToolStripMenuItem.Visible = False
        GetStandardJobsToolStripMenuItem.Visible = False
        RequestPartsFromWarehouseToolStripMenuItem.Visible = False
        CustomerSuppliedPartsToolStripMenuItem.Visible = False
        DoneToolStripMenuItem.Visible = False
    End Sub
    Private Sub FillWorkOrdersDataGridView()
        WorkOrdersSelectionOrder = " ORDER BY WorkOrderID_AutoNumber DESC "
        Dim VehicleDescription = " 
(VehiclesTable.YearManufactured_ShortText4 & space(1) & 
Trim(VehicleTypeTable.VehicleType_ShortText20) & space(1) & 
trim(VehicleModelsTable.VehicleModel_ShortText20) & space(1) & 
trim(VehicleTrimTable.VehicleTrimName_ShortText25)) AS VehicleDescription,
"
        Dim CustomerServiceSpecialist = "
(trim(CSSTable.FirstName_ShortText15) & space(1) & Trim(CSSTable.LastName_ShortText15)) AS CustomerServiceSpecialist, 
"
        Dim AssistantServiceManager = " 
(trim(ASMTable.FirstName_ShortText15) & space(1) & Trim(ASMTable.LastName_ShortText15)) AS AssistantServiceManager, 
"
        Dim AssignedLeadMechanic = " 
(trim(ALMTable.FirstName_ShortText15) & space(1) & Trim(ALMTable.LastName_ShortText15)) AS AssignedLeadMechanic, 
"
        Dim xxPending = "
IIf(WorkOrdersTable.WorkOrderStatus_Byte = 0, 
" & Chr(34) & "pending" & Chr(34) & ","
        Dim xxForAnalysis = "
IIf(WorkOrdersTable.WorkOrderStatus_Byte = 1, 
" & Chr(34) & "for analysis" & Chr(34) & ","

        Dim xxForAssignment = "
IIf(WorkOrdersTable.WorkOrderStatus_Byte = 2, 
" & Chr(34) & "for assignment" & Chr(34) & ","

        Dim xxForBilling = "
IIf(WorkOrdersTable.WorkOrderStatus_Byte = 3, 
" & Chr(34) & "for billing" & Chr(34) & ","
        Dim xxAssigned = "

IIf(WorkOrdersTable.WorkOrderStatus_Byte = 4, 
" & Chr(34) & "Assigned" & Chr(34) & ","

        Dim xxRepairOngoing = "
IIf(WorkOrdersTable.WorkOrderStatus_Byte = 5, 
" & Chr(34) & "Repair Ongoing" & Chr(34) & ","

        WorkOrderStatus = xxPending & xxForAnalysis & xxForAssignment & xxForBilling & xxAssigned & xxRepairOngoing & Chr(34) & Chr(34) & " 
)))))) AS WorkOrderStatus, 
"

        Dim OwnerName = " 
(trim(OwnersTable.FirstName_ShortText15) & space(1) & 
Trim(OwnersTable.LastName_ShortText15) & space(1) & 
trim(OwnersTable.NamePrefix_ShortText3)) AS OwnerName,
"
        WorkOrdersFieldsToSelect = " 
SELECT
WorkOrdersTable.WorkOrderNumber_ShortText12,
WorkOrdersTable.ServiceDate_DateTime,
WorkOrdersTable.ReleaseDate_DateTime,
WorkOrdersTable.VehicleMilage_Integer,
" & VehicleDescription & OwnerName & " 
OwnersTable.TelNo_ShortText10, 
" &
CustomerServiceSpecialist &
AssistantServiceManager &
WorkOrderStatus &
AssignedLeadMechanic & "
ServicedVehiclesTable.VinNo_ShortText20,
WorkOrdersTable.WorkOrderID_AutoNumber,
WorkOrdersTable.CustomerServiceInCharge_LongInteger,
WorkOrdersTable.ServiceManagerAssigning_LongInteger,
WorkOrdersTable.AssignedLeadMechanic_longInteger, 
StatusesTable.StatusText_ShortText25
FROM ((((((((((WorkOrdersTable LEFT JOIN ServicedVehiclesTable ON WorkOrdersTable.ServicedVehicleID_LongInteger = ServicedVehiclesTable.ServicedVehicleID_AutoNumber) LEFT JOIN OwnersTable ON ServicedVehiclesTable.OwnerID_LongInteger = OwnersTable.OwnerID_AutoNumber) LEFT JOIN VehiclesTable ON ServicedVehiclesTable.VehicleID_LongInteger = VehiclesTable.VehicleID_AutoNumber) LEFT JOIN VehicleModelsRelationsTable ON VehiclesTable.VehicleModelsRelationID_LongInteger = VehicleModelsRelationsTable.VehicleModelsRelationID_Autonumber) LEFT JOIN VehicleTypeTable ON VehicleModelsRelationsTable.VehicleTypeID_LongInteger = VehicleTypeTable.VehicleTypeID_AutoNumber) LEFT JOIN VehicleTrimTable ON VehicleModelsRelationsTable.VehicleTrimID_LongInteger = VehicleTrimTable.VehicleTrimID_Autonumber) LEFT JOIN VehicleModelsTable ON VehicleModelsRelationsTable.VehicleModelID_LongInteger = VehicleModelsTable.VehicleModelID_Autonumber) LEFT JOIN PersonnelTable AS CSSTable ON WorkOrdersTable.CustomerServiceInCharge_LongInteger = CSSTable.PersonnelID_AutoNumber) LEFT JOIN PersonnelTable AS ASMTable ON WorkOrdersTable.ServiceManagerAssigning_LongInteger = ASMTable.PersonnelID_AutoNumber) LEFT JOIN PersonnelTable AS ALMTable ON WorkOrdersTable.AssignedLeadMechanic_longInteger = ALMTable.PersonnelID_AutoNumber) LEFT JOIN StatusesTable ON WorkOrdersTable.WorkOrderStatusID_LongInteger = StatusesTable.StatusID_Autonumber
"

        MySelection = WorkOrdersFieldsToSelect & WorkOrdersSelectionFilter & WorkOrdersSelectionOrder

        JustExecuteMySelection()
        WorkOrdersRecordCount = RecordCount
        If Not CurrentUserGroup = "Automotive Service Specialist" Then
            WorkOrdersGroupBox.Visible = False
            WorkOrderConcernsGroupBox.Visible = False
            WorkOrderConcernJobsGroupBox.Visible = False
        End If

        If WorkOrdersRecordCount > 0 Then
            WorkOrdersGroupBox.Visible = True
        End If
        WorkOrdersDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        If WorkOrdersRecordCount = 0 Then
            CurrentWorkOrderID = -1
            PrintWorkOrderToolStripMenuItem.Visible = False
            AddJobToolStripMenuItem.Visible = False
            RemoveJobToolStripMenuItem.Visible = False
        End If


        ' HERE AT ROW_ENTER, FillWorkOrderConcernsDataGridView is called and WorkOrderConcernsbOX IS ALREADY FORMATTED
        If Not CurrentUserGroup = "Automotive Service Specialist" Then
            FillWorkOrderConcernJobsTable()
            FillWorkOrderPartsPerJobDataGridView()
        End If
        If Not WorkOrdersDataGridViewAlreadyFormatted Then
            FormatWorkOrdersDataGridView()
        End If
        SetFormWidthAndGroupBoxLeft()

        Dim NoOfHeaderLines = 2, RecordsToDisplay = 8
        SetGroupBoxHeight(NoOfHeaderLines, RecordsToDisplay, WorkOrdersRecordCount, WorkOrdersGroupBox, WorkOrdersDataGridView)
        WorkOrdersGroupBox.Top = WorkOrderFormASMMenuStrip.Top + WorkOrderFormASMMenuStrip.Height
        WorkOrderConcernsGroupBox.Top = WorkOrdersGroupBox.Top + WorkOrdersGroupBox.Height
        WorkOrderConcernJobsGroupBox.Top = WorkOrderConcernsGroupBox.Top + WorkOrderConcernsGroupBox.Height
        WorkOrderPartsPerJobGroupBox.Top = WorkOrderConcernJobsGroupBox.Top + WorkOrderConcernJobsGroupBox.Height

    End Sub
    Private Sub FormatWorkOrdersDataGridView()
        WorkOrdersDataGridViewAlreadyFormatted = True
        WorkOrdersGroupBox.Width = 0
        For i = 0 To WorkOrdersDataGridView.Columns.GetColumnCount(0) - 1

            WorkOrdersDataGridView.Columns.Item(i).Visible = False
            Select Case WorkOrdersDataGridView.Columns.Item(i).Name
                Case "WorkOrderNumber_ShortText12"
                    WorkOrdersDataGridView.Columns.Item(i).HeaderText = "WORK ORDER No."
                    WorkOrdersDataGridView.Columns.Item(i).Width = 120
                    WorkOrdersDataGridView.Columns.Item(i).Visible = True
                Case "ServiceDate_DateTime"
                    WorkOrdersDataGridView.Columns.Item(i).HeaderText = "Date/Time In"
                    WorkOrdersDataGridView.Columns.Item(i).Width = 80
                    WorkOrdersDataGridView.Columns(i).DefaultCellStyle.Format = "yy-MM-dd"
                    WorkOrdersDataGridView.Columns.Item(i).Visible = True
                Case "VehicleMilage_Integer"
                    WorkOrdersDataGridView.Columns.Item(i).HeaderText = "Milage"
                    WorkOrdersDataGridView.Columns.Item(i).Width = 70
                    WorkOrdersDataGridView.Columns(i).DefaultCellStyle.Format = "###,###"
                    WorkOrdersDataGridView.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    WorkOrdersDataGridView.Columns.Item(i).Visible = True
                Case "VehicleDescription"
                    WorkOrdersDataGridView.Columns.Item("VehicleDescription").HeaderText = "VEHICLE"
                    WorkOrdersDataGridView.Columns.Item("VehicleDescription").Width = 200
                    WorkOrdersDataGridView.Columns.Item(i).Visible = True
                Case "OwnerName"
                    WorkOrdersDataGridView.Columns.Item(i).HeaderText = "OWNER"
                    WorkOrdersDataGridView.Columns.Item(i).Width = 150
                    WorkOrdersDataGridView.Columns.Item(i).Visible = True
                Case "TelNo_ShortText10"
                    WorkOrdersDataGridView.Columns.Item(i).HeaderText = "TEL. NO."
                    WorkOrdersDataGridView.Columns.Item(i).Width = 100
                    WorkOrdersDataGridView.Columns.Item(i).Visible = True
                Case "AssignedLeadMechanic"
                    WorkOrdersDataGridView.Columns.Item(i).HeaderText = "Lead Mechanic"
                    WorkOrdersDataGridView.Columns.Item(i).Width = 160
                    WorkOrdersDataGridView.Columns.Item(i).Visible = True
                    If CurrentUserGroup = "Lead Service Specialist" Then WorkOrdersDataGridView.Columns.Item(i).Visible = False
                Case "WorkOrderStatus"
                    WorkOrdersDataGridView.Columns.Item(i).HeaderText = "Status"
                    WorkOrdersDataGridView.Columns.Item(i).Width = 171
                    WorkOrdersDataGridView.Columns.Item(i).Visible = True
                Case "StatusText_ShortText25"
                    WorkOrdersDataGridView.Columns.Item(i).HeaderText = "Status (new)"
                    WorkOrdersDataGridView.Columns.Item(i).Width = 171
                    WorkOrdersDataGridView.Columns.Item(i).Visible = True
            End Select

            If WorkOrdersDataGridView.Columns.Item(i).Visible = True Then
                WorkOrdersGroupBox.Width = WorkOrdersGroupBox.Width + WorkOrdersDataGridView.Columns.Item(i).Width
            End If
        Next
        If WorkOrdersGroupBox.Width > VehicleManagementSystemForm.Width Then
            WorkOrdersGroupBox.Width = VehicleManagementSystemForm.Width - 4
        End If
    End Sub
    Private Sub WorkOrdersDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles WorkOrdersDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If WorkOrdersRecordCount = 0 Then Exit Sub

        CurrentWorkOrdersRow = e.RowIndex
        CurrentWorkOrderID = WorkOrdersDataGridView.Item("WorkOrderID_AutoNumber", CurrentWorkOrdersRow).Value
        SetVehicleInformations()
        CurrentWorkOrderStatus = WorkOrdersDataGridView.Item("WorkOrderStatus", CurrentWorkOrdersRow).Value


        AssignWorkOrderToolStripMenuItem.Visible = False
        AssignConcernToolStripMenuItem.Visible = False
        RevertStatusToolStripMenuItem.Visible = False
        CONCERNToolStripMenuItem.Visible = False
        GetStandardJobsToolStripMenuItem.Visible = False

        RequestPartsFromWarehouseToolStripMenuItem.Visible = True
        JOBToolStripMenuItem.Visible = False
        AddJobToolStripMenuItem.Visible = False
        EditToolStripMenuItem.Visible = False
        RemoveJobToolStripMenuItem.Visible = False
        ProcessJobToolStripMenuItem.Visible = False
        CustomerSuppliedPartsToolStripMenuItem.Visible = False
        DoneToolStripMenuItem.Visible = False
        RevertStatusToolStripMenuItem.Visible = False

        Select Case CurrentWorkOrderStatus
            Case "pending"
                Dim nbg = ""
            Case "for analysis"
                RevertStatusToolStripMenuItem.Visible = True
                AssignWorkOrderToolStripMenuItem.Visible = True
                GetStandardJobsToolStripMenuItem.Visible = False
                JOBToolStripMenuItem.Visible = False
            Case "for assignment"
                RevertStatusToolStripMenuItem.Visible = True
                If CurrentUserGroup = "Lead Service Specialist" Then
                    EnableJobsOptions()
                    CONCERNToolStripMenuItem.Visible = True
                    If AllConcernsHaveJob() Then
                        AssignWorkOrderToolStripMenuItem.Visible = True
                    End If
                    If WorkOrderConcernJobsRecordCount > 0 Then
                        AssignConcernToolStripMenuItem.Visible = True
                    Else
                        GetStandardJobsToolStripMenuItem.Visible = True
                    End If
                End If
            Case "for billing"  '3
                Dim xxxxx = 1
            Case "Assigned"
                If CurrentPersonelID = WorkOrdersDataGridView.Item("AssignedLeadMechanic_longInteger", CurrentWorkOrdersRow).Value Then
                    EnableJobsOptions()
                End If
                If CurrentUserGroup = "Lead Service Specialist" And CurrentPersonelID = WorkOrdersDataGridView.Item("AssignedLeadMechanic_longInteger", CurrentWorkOrdersRow).Value Then
                    CustomerSuppliedPartsToolStripMenuItem.Visible = True
                    DoneToolStripMenuItem.Visible = True
                    ProcessJobToolStripMenuItem.Visible = True

                End If
                If CurrentUserGroup = "Assistant Service Manager" Or CurrentUserGroup = "Lead Service Specialist" Then
                    RevertStatusToolStripMenuItem.Visible = True
                End If
                If CurrentUserGroup = "Automotive Service Specialist" Then
                    ProcessJobToolStripMenuItem.Visible = True
                    CustomerSuppliedPartsToolStripMenuItem.Visible = True
                    DoneToolStripMenuItem.Visible = True
                    Exit Sub
                End If
            Case "Repair Ongoing"
            Case ""
                MsgBox("CurrentWorkOrderStatus is null")
            Case Else
                If Not CurrentUserGroup = "Automotive Service Specialist" Then
                    MsgBox("break here")
                End If
        End Select
        WorkOrderConcernsSelectionFilter = " WHERE WorkOrderConcernsTable.WorkOrderID_LongInteger = " & CurrentWorkOrderID.ToString
        FillWorkOrderConcernsDataGridView()

    End Sub
    Private Sub SetFormWidthAndGroupBoxLeft()
        Dim LargestWidth = 0

        For i = 1 To 4
            If WorkOrdersGroupBox.Width > LargestWidth Then
                LargestWidth = WorkOrdersGroupBox.Width
            ElseIf WorkOrderConcernsGroupBox.Width > LargestWidth Then
                LargestWidth = WorkOrderConcernsGroupBox.Width
            ElseIf WorkOrderConcernJobsGroupBox.Width > LargestWidth Then
                LargestWidth = WorkOrderConcernJobsGroupBox.Width
            ElseIf WorkOrderPartsPerJobGroupBox.Width > LargestWidth Then
                LargestWidth = WorkOrderPartsPerJobGroupBox.Width
            End If
        Next

        If LargestWidth > VehicleManagementSystemForm.Width Then
            Me.Width = VehicleManagementSystemForm.Width - 4
        Else
            Me.Width = LargestWidth + 4
        End If
        '    Me.Width = VehicleManagementSystemForm.Width

        Me.Left = (VehicleManagementSystemForm.Width - Me.Width) / 2
        WorkOrdersGroupBox.Left = (Me.Width - WorkOrdersDataGridView.Width) / 2
        WorkOrderConcernsGroupBox.Left = (Me.Width - WorkOrderConcernsGroupBox.Width) / 2
        WorkOrderConcernJobsGroupBox.Left = (Me.Width - WorkOrderConcernJobsGroupBox.Width) / 2
        WorkOrderPartsPerJobGroupBox.Left = (Me.Width - WorkOrderPartsPerJobGroupBox.Width) / 2

    End Sub
    Private Sub FillWorkOrderConcernsDataGridView()
        'NOTE IF MasterCodeBookTable.SystemDesc_ShortText100Fld IS EMPTY IT MEANS 
        ' ConcernAsIsByClientTable.LongTextConcern_LongText

        Dim ActionToTake = " 
IIf( not ConcernAsIsByClientTable.LongTextConcern_LongText = " & Chr(34) & Chr(34) & ",  " &
                                       Chr(34) & " Diagnose " & Chr(34) & ",  " &
                                         " InformationsHeadersTypeTable.InformationsHeadersTypePrefix_ShortText50, " & ") 
"
        Dim ConcernAssignedServiceSpecialist = " PersonnelTable.LastName_ShortText15 & space(1) & " &
                                              " mid(PersonnelTable.FirstName_ShortText15,1,1) as ConcernAssignedServiceSpecialist, "

        Dim ConcernDescription = " 
IIf( not ConcernAsIsByClientTable.LongTextConcern_LongText = " & Chr(34) & Chr(34) & ",  " &
                                       " ConcernAsIsByClientTable.LongTextConcern_LongText, " &
                                        " MasterCodeBookTable.SystemDesc_ShortText100Fld) as  CoinedConcern, 
"

        ConcernDescription = ActionToTake & " & Space(1) & " & ConcernDescription

        WorkOrderConcernsFieldsToSelect = " 
Select 
WorkOrderConcernsTable.WorkOrderConcernID_AutoNumber,
WorkOrderConcernsTable.WorkOrderID_LongInteger,
WorkOrderConcernsTable.ConcernID_LongInteger,
WorkOrderConcernsTable.ConcernLongTextCodeID_LongInteger,
WorkOrderConcernsTable.WorkOrderConcernStatus_Byte,
ConcernsTable.InformationsHeadersTypeID_LongInteger,
ConcernsTable.Concern_ShortText255,
InformationsHeadersTypeTable.InformationsHeadersTypePrefix_ShortText50, " &
ConcernDescription &
" 
MasterCodeBookTable.SystemDesc_ShortText100Fld,
LongTextConcern_LongText, " &
ConcernAssignedServiceSpecialist &
" 
StatusesTable.StatusText_ShortText25,
OriginalExcelRecordTable.description
"

        WorkOrderConcernsTablesLinks = " 
FROM ((((((WorkOrderConcernsTable LEFT JOIN ConcernsTable ON WorkOrderConcernsTable.ConcernID_LongInteger = ConcernsTable.ConcernID_AutoNumber) LEFT JOIN InformationsHeadersTypeTable ON ConcernsTable.InformationsHeadersTypeID_LongInteger = InformationsHeadersTypeTable.InformationsHeadersTypeID_AutoNumber) LEFT JOIN MasterCodeBookTable ON ConcernsTable.MasterCodeBookId_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) LEFT JOIN ConcernAsIsByClientTable ON WorkOrderConcernsTable.ConcernLongTextCodeID_LongInteger = ConcernAsIsByClientTable.LongTextConcernID_Autonumber) LEFT JOIN OriginalExcelRecordTable ON WorkOrderConcernsTable.OriginalID_LongInteger = OriginalExcelRecordTable.OriginalID_AutoNumber) LEFT JOIN PersonnelTable ON WorkOrderConcernsTable.AssignedServiceSpecialist_LongInteger = PersonnelTable.PersonnelID_AutoNumber) LEFT JOIN StatusesTable ON WorkOrderConcernsTable.WorkOrderConcernStatusID_LongInteger = StatusesTable.StatusID_Autonumber
"

        WorkOrderConcernsSelectionOrder = ""

        MySelection = WorkOrderConcernsFieldsToSelect & WorkOrderConcernsTablesLinks & WorkOrderConcernsSelectionFilter & WorkOrderConcernsSelectionOrder

        JustExecuteMySelection()
        WorkOrderConcernsRecordCount = RecordCount
        If Not CurrentUserGroup = "Automotive Service Specialist" Then
            WorkOrderConcernsGroupBox.Visible = False
            WorkOrderConcernJobsGroupBox.Visible = False
        End If
        If WorkOrderConcernsRecordCount > 0 Then
            WorkOrderConcernsGroupBox.Visible = True
        End If



        WorkOrderConcernsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        If Not WorkOrderConcernsDataGridViewAlreadyFormatted Then
            WorkOrderConcernsDataGridViewAlreadyFormatted = True
            FormatWorkOrderConcernsDataGridView()
        End If

        Dim NoOfHeaderLines = 1, RecordsToDisplay = 5
        SetGroupBoxHeight(NoOfHeaderLines, RecordsToDisplay, WorkOrderConcernsRecordCount, WorkOrderConcernsGroupBox, WorkOrderConcernsDataGridView)
        WorkOrderConcernJobsGroupBox.Top = WorkOrderConcernsGroupBox.Top + WorkOrderConcernsGroupBox.Height
        WorkOrderPartsPerJobGroupBox.Top = WorkOrderConcernJobsGroupBox.Top + WorkOrderConcernJobsGroupBox.Height

    End Sub


    Private Sub FormatWorkOrderConcernsDataGridView()

        WorkOrderConcernsGroupBox.Width = 0

        For i = 0 To WorkOrderConcernsDataGridView.Columns.GetColumnCount(0) - 1

            WorkOrderConcernsDataGridView.Columns.Item(i).Visible = False

            Select Case WorkOrderConcernsDataGridView.Columns.Item(i).HeaderText
                Case "CoinedConcern"
                    WorkOrderConcernsDataGridView.Columns.Item(i).HeaderText = "CONCERN"
                    WorkOrderConcernsDataGridView.Columns.Item(i).Width = 500
                    WorkOrderConcernsDataGridView.Columns.Item(i).Visible = True '                   WorkOrderConcernsDataGridView.Columns.Item(i).Visible = True
                Case "description"
                    WorkOrderConcernsDataGridView.Columns.Item(i).HeaderText = "original (excel)"
                    WorkOrderConcernsDataGridView.Columns.Item(i).Width = 400
                    WorkOrderConcernsDataGridView.Columns.Item(i).Visible = True
                Case "ConcernAssignedServiceSpecialist"
                    WorkOrderConcernsDataGridView.Columns.Item(i).HeaderText = "Service Specialist"
                    WorkOrderConcernsDataGridView.Columns.Item(i).Width = 200
                    WorkOrderConcernsDataGridView.Columns.Item(i).Visible = True
                Case "StatusText_ShortText25"
                    WorkOrderConcernsDataGridView.Columns.Item(i).HeaderText = "Status"
                    WorkOrderConcernsDataGridView.Columns.Item(i).Width = 171
                    WorkOrderConcernsDataGridView.Columns.Item(i).Visible = True
            End Select
            If WorkOrderConcernsDataGridView.Columns.Item(i).Visible = True Then
                WorkOrderConcernsGroupBox.Width = WorkOrderConcernsGroupBox.Width + WorkOrderConcernsDataGridView.Columns.Item(i).Width
            End If
        Next
        If WorkOrderConcernsGroupBox.Width > VehicleManagementSystemForm.Width Then
            WorkOrderConcernsGroupBox.Width = VehicleManagementSystemForm.Width - 4
        End If


    End Sub
    Private Sub WorkOrderConcernsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles WorkOrderConcernsDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If WorkOrderConcernsRecordCount = 0 Then Exit Sub

        CurrentWorkOrderConcernsRow = e.RowIndex

        CurrentWorkOrderConcernID = WorkOrderConcernsDataGridView.Item("WorkOrderConcernID_AutoNumber", CurrentWorkOrderConcernsRow).Value
        CurrentConcernID = WorkOrderConcernsDataGridView.Item("ConcernID_LongInteger", CurrentWorkOrderConcernsRow).Value
        CurrentLongTextConcernID = WorkOrderConcernsDataGridView.Item("ConcernLongTextCodeID_LongInteger", CurrentWorkOrderConcernsRow).Value

        GetStandardJobsToolStripMenuItem.Visible = False
        If CurrentConcernID > 0 Then
            EnableJobsOptions()
            If WorkOrderConcernJobsRecordCount = 0 Then
                GetStandardJobsToolStripMenuItem.Visible = True
            End If
        End If
        If CurrentUserGroup = "Automotive Service Specialist" Then
            Exit Sub
        End If

        FillWorkOrderConcernJobsTable()
        If WorkOrderConcernJobsRecordCount > 0 Then
            GetStandardJobsToolStripMenuItem.Visible = False
        Else
            GetStandardJobsToolStripMenuItem.Visible = True
        End If
    End Sub


    Public Sub SetupWorkOrderSelection(WorkOrderStatusSelection)

        WorkOrderStatusSelection = WorkOrderStatusSelection
        Select Case WorkOrderStatusSelection
            Case 0
                WorkOrdersSelectionFilter = OutstandingForThisUserFilter
                Me.Text = "OUTSTANDING WORK ORDERS"
            Case 1
                WorkOrdersSelectionFilter = " WHERE WorkOrderStatus_Byte = 1 "
            Case 2
                WorkOrdersSelectionFilter = " WHERE WorkOrderStatus_Byte = 2 "
            Case 8
                WorkOrdersSelectionFilter = " WHERE WorkOrderStatus_Byte = 8 "
                Me.Text = "FINISHED WORK ORDERS for BILLING "
            Case 9
                WorkOrdersSelectionFilter = " WHERE WorkOrderStatus_Byte = 9 "
                Me.Text = "WORK ORDERS RELEASED"
            Case 10
                WorkOrdersSelectionFilter = ""
                Me.Text = "ALL WORK ORDERS"

        End Select
        FillWorkOrdersDataGridView()
    End Sub


    Private Sub FillWorkOrderConcernJobsTable()
        WorkOrderPartsPerJobGroupBox.Visible = False
        Dim JobDescription = " 
trim(InformationsHeadersTypeTable.InformationsHeadersTypePrefix_ShortText50,) " &
                                              " & space(1) & MasterCodeBookTable.SystemDesc_ShortText100Fld as Job, "

        Dim AssignedServiceSpecialist = " PersonnelTable.LastName_ShortText15 & space(1) & " &
                                              " mid(PersonnelTable.FirstName_ShortText15,1,1) as AssignedServiceSpecialist, "

        WorkOrderConcernJobsFieldsToSelect = " 
Select 
WorkOrdersTable.WorkOrderNumber_ShortText12,
WorkOrderConcernJobsTable.WorkOrderConcernJobID_AutoNumber, 
WorkOrderConcernJobsTable.InformationsHeaderID_LongInteger,
WorkOrderConcernJobsTable.WorkOrderConcernJobStatus_Byte,
WorkOrderConcernsTable.WorkOrderID_LongInteger, 
WorkOrderConcernsTable.AssignedServiceSpecialist_LongInteger,
WorkOrderConcernsTable.ConcernID_LongInteger,
" & JobDescription & " 
InformationsHeadersTypeTable.InformationsHeadersTypePrefix_ShortText50,
MasterCodeBookTable.SystemDesc_ShortText100Fld,
PersonnelTable.FirstName_ShortText15,
PersonnelTable.LastName_ShortText15,
InformationsHeadersTable.InformationsHeaderDescription_ShortText255,
OriginalExcelRecordTable.description, 
" & AssignedServiceSpecialist & " 
InformationsHeadersTable.MasterCodeBookId_LongInteger ,
StatusesTable.StatusText_ShortText25
FROM (((((((WorkOrderConcernJobsTable LEFT JOIN WorkOrderConcernsTable ON WorkOrderConcernJobsTable.WorkOrderConcernID_LongInteger = WorkOrderConcernsTable.WorkOrderConcernID_AutoNumber) LEFT JOIN OriginalExcelRecordTable ON WorkOrderConcernJobsTable.OriginalID_LongInteger = OriginalExcelRecordTable.OriginalID_AutoNumber) LEFT JOIN PersonnelTable ON WorkOrderConcernJobsTable.AssignedServiceSpecialist_LongInteger = PersonnelTable.PersonnelID_AutoNumber) LEFT JOIN InformationsHeadersTable ON WorkOrderConcernJobsTable.InformationsHeaderID_LongInteger = InformationsHeadersTable.InformationsHeaderID_AutoNumber) LEFT JOIN InformationsHeadersTypeTable ON InformationsHeadersTable.InformationsHeadersTypeID_LongInteger = InformationsHeadersTypeTable.InformationsHeadersTypeID_AutoNumber) LEFT JOIN MasterCodeBookTable ON InformationsHeadersTable.MasterCodeBookId_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) LEFT JOIN WorkOrdersTable ON WorkOrderConcernsTable.WorkOrderID_LongInteger = WorkOrdersTable.WorkOrderID_AutoNumber) LEFT JOIN StatusesTable ON WorkOrderConcernJobsTable.WorkOrderConcernJobStatusID_LongInteger = StatusesTable.StatusID_Autonumber
"

        WorkOrderConcernJobsSelectionOrder = " ORDER BY WorkOrderConcernsTable.WorkOrderID_LongInteger DESC "

        Select Case CurrentUserGroup
            Case "Customer Service Specialist"
                WorkOrderConcernJobsSelectionFilter = " WHERE WorkOrderConcernsTable.WorkOrderID_LongInteger = " & Str(CurrentWorkOrderID)
            Case "Assistant Service Manager"
                WorkOrderConcernJobsSelectionFilter = " WHERE WorkOrderConcernsTable.WorkOrderID_LongInteger = " & Str(CurrentWorkOrderID) &
                                                        " And WorkOrderConcernID_LongInteger = " & Str(CurrentWorkOrderConcernID)
            Case "Lead Service Specialist"
                WorkOrderConcernJobsSelectionFilter = " WHERE WorkOrderConcernID_LongInteger = " & Str(CurrentWorkOrderConcernID)
        End Select

        MySelection = WorkOrderConcernJobsFieldsToSelect & WorkOrderConcernJobsSelectionFilter & WorkOrderConcernJobsSelectionOrder


        JustExecuteMySelection()
        WorkOrderConcernJobsRecordCount = RecordCount

        If WorkOrderConcernJobsRecordCount > 0 Then
            WorkOrderConcernJobsGroupBox.Visible = True
        End If

        WorkOrderConcernJobsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If Not WorkOrderConcernJobsDataGridViewFormatted Then
            FormatWorkOrderConcernJobsDataGridView()
        End If
        Dim NoOfHeaderLines = 1, RecordsToDisplay = 5
        SetGroupBoxHeight(NoOfHeaderLines, RecordsToDisplay, WorkOrderConcernJobsRecordCount, WorkOrderConcernJobsGroupBox, WorkOrderConcernJobsDataGridView)
        WorkOrderPartsPerJobGroupBox.Top = WorkOrderConcernJobsGroupBox.Top + WorkOrderConcernJobsGroupBox.Height
    End Sub
    Private Sub FormatWorkOrderConcernJobsDataGridView()
        WorkOrderConcernJobsDataGridViewFormatted = True
        WorkOrderConcernJobsGroupBox.Width = 0
        For i = 0 To WorkOrderConcernJobsDataGridView.Columns.GetColumnCount(0) - 1

            WorkOrderConcernJobsDataGridView.Columns.Item(i).Visible = False

            Select Case WorkOrderConcernJobsDataGridView.Columns.Item(i).Name
                Case "WorkOrderNumber_ShortText12"
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).HeaderText = "Work Order #"
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).Width = 115
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).Visible = True
                Case "Job"
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).Width = 300
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).Visible = True
                Case "InformationsHeaderDescription_ShortText255"
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).HeaderText = "InformationsHeaderDescription"
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).Width = 300
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).Visible = True
                Case "AssignedServiceSpecialist"
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).HeaderText = "Service Specialist"
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).Width = 200
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).Visible = True
                Case "StatusText_ShortText25"
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).HeaderText = "Status"
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).Width = 171
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).Visible = True
            End Select
            If WorkOrderConcernJobsDataGridView.Columns.Item(i).Visible = True Then
                WorkOrderConcernJobsGroupBox.Width = WorkOrderConcernJobsGroupBox.Width + WorkOrderConcernJobsDataGridView.Columns.Item(i).Width
            End If
        Next

        If WorkOrderConcernJobsGroupBox.Width > VehicleManagementSystemForm.Width Then
            WorkOrderConcernJobsGroupBox.Width = VehicleManagementSystemForm.Width - 6
        End If


    End Sub
    Private Sub WorkOrderConcernJobsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles WorkOrderConcernJobsDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If WorkOrderConcernJobsRecordCount = 0 Then Exit Sub

        CurrentWorkOrderConcernJobsRow = e.RowIndex

        CurrentWorkOrderConcernJobID = WorkOrderConcernJobsDataGridView.Item("WorkOrderConcernJobID_AutoNumber", CurrentWorkOrderConcernJobsRow).Value
        CurrentInformationsHeaderID = WorkOrderConcernJobsDataGridView.Item("InformationsHeaderID_LongInteger", CurrentWorkOrderConcernJobsRow).Value
        WorkOrderPartsPerJobSelectionFilter = " WHERE WorkOrderConcernJobID_AutoNumber = " & CurrentWorkOrderConcernJobID
        FillWorkOrderPartsPerJobDataGridView()

        '       WorkOrderPartsPerJobGroupBox.Top = WorkOrderConcernJobsGroupBox.Top + WorkOrderConcernJobsGroupBox.Height
        If CurrentUserGroup = "Automotive Service Specialist" Then
            ' SHOWING FROM JOBS TO CONCERNS BACKWARDS
            CurrentWorkOrderID = -1
            If IsNotEmpty(WorkOrderConcernJobsDataGridView.Item("WorkOrderID_LongInteger", CurrentWorkOrderConcernJobsRow).Value) Then
                CurrentWorkOrderID = WorkOrderConcernJobsDataGridView.Item("WorkOrderID_LongInteger", CurrentWorkOrderConcernJobsRow).Value
            End If
            CurrentWorkOrderConcernID = -1
            If IsNotEmpty(WorkOrderConcernJobsDataGridView.Item("ConcernID_LongInteger", CurrentWorkOrderConcernJobsRow).Value) Then
                CurrentWorkOrderConcernID = WorkOrderConcernJobsDataGridView.Item("ConcernID_LongInteger", CurrentWorkOrderConcernJobsRow).Value
            End If
            WorkOrderConcernsSelectionFilter = " WHERE WorkOrderConcernsTable.WorkOrderID_LongInteger = " & CurrentWorkOrderID.ToString &
                                                " AND WorkOrderConcernsTable.ConcernID_LongInteger = " & CurrentWorkOrderConcernID
            FillWorkOrderConcernsDataGridView()
            WorkOrdersSelectionFilter = " WHERE WorkOrderID_AutoNUmber = " & CurrentWorkOrderID
            FillWorkOrdersDataGridView()
        End If
        If CurrentUserGroup = "Lead Service Specialist" Then
            If WorkOrderConcernJobsRecordCount = 0 Then
                RemoveJobToolStripMenuItem.Visible = True
            End If
        End If

    End Sub
    Private Sub FillWorkOrderPartsPerJobDataGridView()

        WorkOrderPartsPerJobFieldsToSelect =
" 
Select WorkOrderPartsTable.WorkOrderPartID_AutoNumber, 
WorkOrderPartsTable.WorkOrderPartsRequisitionID_LongInteger, 
WorkOrderPartsTable.InformationsHeaderID_LongInteger, 
WorkOrderPartsTable.MasterCodeBookID_LongInteger, 
WorkOrderPartsTable.Quantity_Integer, 
WorkOrderPartsTable.Unit_ShortText3, 
MasterCodeBookTable.SystemDesc_ShortText100Fld, 
WorkOrderConcernJobsTable.WorkOrderConcernJobID_AutoNumber, 
WorkOrderConcernJobsTable.WorkOrderConcernJobStatus_Byte, 
WorkOrderPartsRequisitionsTable.WorkOrderPartsRequisitionID_AutoNumber, 
MasterCodeBookTable.MasterCodeBookID_Autonumber, 
StatusesTable.StatusText_ShortText25,
ProductsPartsTable.ManufacturerPartNo_ShortText30Fld, 
ProductsPartsTable.ManufacturerDescription_ShortText250
FROM (((((WorkOrderPartsTable LEFT JOIN MasterCodeBookTable ON WorkOrderPartsTable.MasterCodeBookID_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) LEFT JOIN WorkOrderPartsRequisitionsTable ON WorkOrderPartsTable.[WorkOrderPartsRequisitionID_LongInteger] = WorkOrderPartsRequisitionsTable.WorkOrderPartsRequisitionID_AutoNumber) LEFT JOIN WorkOrderConcernJobsTable ON WorkOrderPartsTable.WorkOrderConcernJobID_LongInteger = WorkOrderConcernJobsTable.WorkOrderConcernJobID_AutoNumber) LEFT JOIN StatusesTable ON WorkOrderPartsTable.WorkOrderPartStatusID_LongInteger = StatusesTable.StatusID_Autonumber) LEFT JOIN WorkOrderReceivedPartsTable ON WorkOrderPartsTable.WorkOrderPartID_AutoNumber = WorkOrderReceivedPartsTable.WorkOrderPartID_LongInteger) LEFT JOIN ProductsPartsTable ON WorkOrderReceivedPartsTable.ProductPartID_LongInteger = ProductsPartsTable.ProductsPartID_Autonumber
"
        WorkOrderPartsPerJobSelectionOrder = "  "
        MySelection = WorkOrderPartsPerJobFieldsToSelect & WorkOrderPartsPerJobSelectionFilter
        JustExecuteMySelection()
        WorkOrderPartsPerJobRecordCount = RecordCount
        If WorkOrderPartsPerJobRecordCount > 0 Then
            WorkOrderPartsPerJobGroupBox.Visible = True
        End If
        Dim NoOfHeaderLines = 1, RecordsToDisplay = 7

        SetGroupBoxHeight(NoOfHeaderLines, RecordsToDisplay, WorkOrderPartsPerJobRecordCount, WorkOrderPartsPerJobGroupBox, WorkOrderPartsPerJobDataGridView)
        WorkOrderPartsPerJobDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If Not WorkOrderPartsPerJobDataGridViewAlreadyFormatted Then
            FormatWorkOrderPartsPerJobDataGridView()
        End If

    End Sub
    Private Sub FormatWorkOrderPartsPerJobDataGridView()
        WorkOrderPartsPerJobDataGridViewAlreadyFormatted = True
        WorkOrderPartsPerJobGroupBox.Width = 0
        For i = 0 To WorkOrderPartsPerJobDataGridView.Columns.GetColumnCount(0) - 1
            WorkOrderPartsPerJobDataGridView.Columns.Item(i).Visible = False
            Select Case WorkOrderPartsPerJobDataGridView.Columns.Item(i).Name
                Case "ManufacturerPartNo_ShortText30Fld"
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).HeaderText = "Manuf PN"
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).Width = 150
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).Visible = True
                Case "SystemDesc_ShortText100Fld"
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).HeaderText = "SYSTEM DESC"
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).Width = 400
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).Visible = True
                Case "Unit_ShortText3"
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).HeaderText = "FL UNIT"
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).Width = 100
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).Visible = True
                Case "Quantity_Integer"
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).HeaderText = "WO QTY"
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).Width = 60
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).Visible = True
                Case "ManufacturerDescription_ShortText250"
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).HeaderText = "excel"
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).Width = 400
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).Visible = True
                Case "StatusText_ShortText25"
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).HeaderText = "Status"
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).Width = 171
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).Visible = True
            End Select

            If WorkOrderPartsPerJobDataGridView.Columns.Item(i).Visible = True Then
                WorkOrderPartsPerJobGroupBox.Width = WorkOrderPartsPerJobGroupBox.Width + WorkOrderPartsPerJobDataGridView.Columns.Item(i).Width
            End If
        Next

        If WorkOrderPartsPerJobGroupBox.Width > VehicleManagementSystemForm.Width Then
            WorkOrderPartsPerJobGroupBox.Width = VehicleManagementSystemForm.Width - 4
        End If
        WorkOrderPartsPerJobGroupBox.Width = Me.Width - 6
    End Sub
    Private Sub WorkOrderPartsPerJobDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles WorkOrderPartsPerJobDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If WorkOrderPartsPerJobRecordCount = 0 Then Exit Sub
        CurrentWorkOrderPartsPerJobRow = e.RowIndex
        CurrentWorkOrderPartsPerJobID = WorkOrderPartsPerJobDataGridView.Item("WorkOrderPartID_AutoNumber", CurrentWorkOrderPartsPerJobRow).Value
    End Sub

    Private Sub WorkOrderForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        'Refresh datagridviw here
        ' GET RETURNED DATA HERE

        If Me.Enabled = False Then Exit Sub
        CallingForm = SavedCallingForm

        Select Case Tunnel1
            Case "Tunnel2IsInformationsHeaderID"
                CurrentJobID = Tunnel2
                SaveNewWorkOrderConcernJob()

            Case "Tunnel2IsPersonnelID"
                AssignedPersonnelID = Tunnel2
                Select Case CurrentUserGroup
                    Case "Lead Service Specialist"

                        Select Case AssignmentIsFor
                            Case "WORKORDER"
                                ' SET WORK STATUS  TO 4	For job fixing, outstanding for ASS
                                MySelection = " UPDATE WorkOrdersTable SET " &
                                              " WorkOrderStatus_Byte = 4 " & ' Work Order is COMPLETELY assigned 
                                                 " WHERE  WorkOrderID_AutoNumber = " & CurrentWorkOrderID
                                JustExecuteMySelection()

                                ' SET CONCERN STATUS TO 2 Concern is COMPLETELY assigned FOR ALL CONCERNS
                                MySelection = " UPDATE WorkOrderConcernsTable SET " &
                                              " WorkOrderConcernStatus_Byte = 2, " & ' Concern is COMPLETELY assigned 
                                              " AssignedServiceSpecialist_LongInteger = " & AssignedPersonnelID.ToString &' Concern is COMPLETELY assigned 
                                                " WHERE  WorkOrderID_LongInteger = " & CurrentWorkOrderID

                                JustExecuteMySelection()

                                For i = 0 To WorkOrderConcernsRecordCount - 1
                                    Dim xxWorkOrderConcernID = WorkOrderConcernsDataGridView.Item("WorkOrderConcernID_AutoNumber", i).Value
                                    MySelection = " update WorkOrderConcernJobsTable SET " &
                                                  " AssignedServiceSpecialist_LongInteger = " & AssignedPersonnelID &
                                                  ", WorkOrderConcernJobStatus_Byte = 1 " & ' newly assigned
                                                            " WHERE  WorkOrderConcernID_LongInteger = " & xxWorkOrderConcernID

                                    JustExecuteMySelection()
                                Next
                            Case "CONCERN"
                                AssignThisConcern()
                            Case "JOB"
                                AssignThisJob()
                        End Select
                    Case "Assistant Service Manager"

                        MySelection = " UPDATE WorkOrdersTable  SET " &
                                    " WorkOrderStatusID_LongInteger = " & GetStatusIdFor(" WorkOrdersTable", "For Assignment") & " , " & ' for lead mechanic to re assign jobs to specialists
                                    " WorkOrderStatus_Byte = 2 " & '2	For assignment status, outstanding for the LeadASS
                                    ", AssignedLeadMechanic_longInteger = " & AssignedPersonnelID &
                                    " WHERE WorkOrderID_AutoNumber = " & Str(CurrentWorkOrderID)
                        JustExecuteMySelection()
                    Case Else
                        MsgBox("BREAK DEBUGGER HERE, UNDETERMINED CALLED FORM")

                End Select
                SetupWorkOrderSelection(0)
                WorkOrderStatusSelection = 0

                FillWorkOrdersDataGridView()
            Case Else
                FillWorkOrdersDataGridView()
        End Select

    End Sub
    Private Sub SaveNewWorkOrderConcernJob()
        MySelection = "Select top 1 * from WorkOrderConcernJobsTable where WorkOrderID_LongInteger = " & Str(CurrentWorkOrderID) &
                        " AND WorkOrderConcernID_LongInteger  = " & Str(CurrentWorkOrderConcernID) &
                        " AND InformationsHeaderID_LongInteger = " & Str(CurrentJobID)
        If RecordIsFound() Then
            MsgBox("This job is already linked")
            Exit Sub
        End If
        Dim xxWorkOrderConcernJobStatus_Byte = 0
        Dim FieldsToUpdate =
" 
WorkOrderID_LongInteger, 
WorkOrderConcernID_LongInteger,
CodeVehicleID_LongInteger,
AssignedServiceSpecialist_LongInteger,
InformationsHeaderID_LongInteger,
WorkOrderConcernJobStatusID_LongInteger,
WorkOrderConcernJobStatus_Byte"

        Dim FieldsData =
Str(CurrentWorkOrderID) & ",  " &
Str(CurrentWorkOrderConcernID) & ",  " &
Str(CurrentCodeVehicleID) & ",  " &
Str(CurrentPersonelID) & ",  " &
Str(CurrentJobID) & ",  " &
Str(GetStatusIdFor("WorkOrderConcernJobsTable")) & ",  " &
InQuotes(xxWorkOrderConcernJobStatus_Byte)


        CurrentWorkOrderConcernJobID = InsertNewRecord("WorkOrderConcernJobsTable", FieldsToUpdate, FieldsData)

        FillWorkOrderConcernJobsTable()
        ' Concerns table should be updated through the codebookform

    End Sub
    Private Sub AssignThisConcern()
        WorkOrdersFieldsToSelect = " UPDATE WorkOrdersTable  SET " &
                   " WorkOrderStatus_Byte = 2, " & ' for lead mechanic to re assign jobs to specialists
                   " WorkOrderStatusID_LongInteger = " & GetStatusIdFor(" WorkOrdersTable", "For Assignment") & " , " & ' for lead mechanic to re assign jobs to specialists
                   " AssignedLeadMechanic_longInteger = " & Str(AssignedPersonnelID) & ", " &
                   " ServiceManagerAssigning_LongInteger = " & Str(CurrentUserID)

        MySelection = WorkOrdersFieldsToSelect & WorkOrdersSelectionFilter
        JustExecuteMySelection()

    End Sub
    Private Sub AssignThisJob()
        Dim xxJobsFieldsToSelect = " UPDATE  WorkOrderConcernJobsTable  SET " &
                   " JobStatus_Byte = 1, " & ' assigned to specialists
                   " AssignedServiceSpecialist_LongInteger = " & Str(AssignedPersonnelID)

        MySelection = xxJobsFieldsToSelect & WorkOrdersSelectionFilter
        JustExecuteMySelection()
    End Sub


    Private Sub AssignThisWorkOrder()

        Select Case CurrentUserGroup
            Case "Lead Service Specialist"
                'NOTE:  ASSIGNING THE WHOLE CONCERN TO AUTOMOTIVE SERVICE SPECIALIST ASSIGNS CURRENTLY SELECTED ASS TO all attached JOBS TO
                '       CURRENT CONCERN STATUS IS SET TO 2 - Concern is COMPLETELY assigned (SEE DOCUMENTATION)
                WorkOrdersFieldsToSelect = " UPDATE WorkOrdersTable  SET " &
                   " WorkOrderStatusID_LongInteger = " & GetStatusIdFor(" WorkOrdersTable", "Assigned") & " , " & ' fAssigned to specialists
                   " WorkOrderStatus_Byte = 4 "

                WorkOrdersSelectionFilter = " WHERE WorkOrderID_AutoNumber = " & CurrentWorkOrderID.ToString

            Case "Assistant Service Manager"


                WorkOrdersFieldsToSelect = " UPDATE WorkOrdersTable  SET " &
                    " WorkOrderStatusID_LongInteger = " & GetStatusIdFor(" WorkOrdersTable", "For Assignment") & " , " & ' for lead mechanic to re assign jobs to specialists
                  " WorkOrderStatus_Byte = 2, " & ' for lead mechanic to re assign jobs to specialists
                   " AssignedLeadMechanic_longInteger = " & Str(AssignedPersonnelID) & ", " &
                   " ServiceManagerAssigning_LongInteger = " & Str(CurrentUserID)

        End Select


        MySelection = WorkOrdersFieldsToSelect & WorkOrdersSelectionFilter
        JustExecuteMySelection()



    End Sub


    Private Sub RemoveConcernToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveJobToolStripMenuItem.Click
        If WorkOrderPartsPerJobRecordCount > 0 Then
            MsgBox("Parts are attached, unable to remove this job")
            Exit Sub
        End If
        Dim Job_ShortText255 As String = ""
            Job_ShortText255 = Trim(WorkOrderConcernJobsDataGridView("Job", CurrentWorkOrderConcernJobsRow).Value)
        Dim Question As String = Trim(Job_ShortText255) & Chr(13) & "Do you want to remove this job"


        Dim DeleteThisConcern As String = MsgBox(Question, 4)
        If DeleteThisConcern = vbNo Then
            Exit Sub
        End If

        MySelection = "DELETE FROM WorkOrderConcernJobsTable WHERE WorkOrderConcernJobID_AutoNumber = " & Str(CurrentWorkOrderConcernJobID)
        JustExecuteMySelection()
        FillWorkOrderConcernJobsTable()
    End Sub

    Private Sub OutstandingWorkOrdersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OutstandingWorkOrdersToolStripMenuItem.Click
        If Not WorkOrderStatusSelection = 0 Then WorkOrdersSelectionFilter = OutstandingForThisUserFilter
        WorkOrderStatusSelection = 0
    End Sub
    Private Sub ForFinalizationBillingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ForFinalizationBillingToolStripMenuItem.Click
        If Not WorkOrderStatusSelection = 8 Then SetupWorkOrderSelection(8)
    End Sub
    Private Sub CompletedWorkOrdersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompletedWorkOrdersToolStripMenuItem.Click
        If Not WorkOrderStatusSelection = 9 Then SetupWorkOrderSelection(9)
        WorkOrderStatusSelection = 9
    End Sub
    Private Sub AllWorkOrdersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllWorkOrdersToolStripMenuItem.Click
        SetupWorkOrderSelection(10)
    End Sub

    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub

    Private Sub AddToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles AddJobToolStripMenuItem.Click
        Tunnel1 = "ADD"
        ShowInformationsHeadersForm()
    End Sub
    Private Sub ShowInformationsHeadersForm()
        InformationsHeadersForm.CodeBookDescriptionToolStripTextBox.Text = CurrentVehicleString
        Tunnel2 = CurrentConcernID
        ShowCalledForm(Me, InformationsHeadersForm)
    End Sub
    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        Tunnel1 = "UPDATE"
        ShowJobsForm()
    End Sub
    Public Sub ShowJobsForm()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PrintWorkOrderToolStripMenuItem.Click
        MsgBox("Print you Work Order Here")

    End Sub


    Private Sub AssignWorkOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AssignWorkOrderToolStripMenuItem.Click
        AssignmentIsFor = "WORKORDER"
        ShowPersonnelForm()
    End Sub
    Public Sub ShowPersonnelForm()
        ShowCalledForm(Me, PersonnelsForm)
    End Sub

    Private Sub RevertStatusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RevertStatusToolStripMenuItem.Click
        If MsgBox("Are you sure you would like to revert current status? ", 4) = vbNo Then
            Exit Sub
        End If


        Dim revertValue = 0 ' FIX THIS
        Dim FieldToReset = ""
        Select Case CurrentWorkOrderStatus
            Case "for analysis"
                revertValue = 0
            Case "for assignment"
                revertValue = 1
                FieldToReset = ", AssignedLeadMechanic_longInteger = -1"
            Case "Assigned"
                revertValue = 2
                FieldToReset = ", AssignedLeadMechanic_longInteger = -1"
            Case Else
                MsgBox("need to break here")
        End Select
        MySelection = " UPDATE WorkOrdersTable  SET " &
                    " WorkOrderStatus_Byte =  " & revertValue.ToString &
                    FieldToReset &
                    " WHERE WorkOrderID_AutoNumber = " & Str(CurrentWorkOrderID)
        JustExecuteMySelection()
        '        SetupWorkOrderSelection(1)
        '       WorkOrderStatusSelection = 1

        FillWorkOrdersDataGridView()
        RevertStatusToolStripMenuItem.Visible = False

    End Sub





    Private Sub AssignJobToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AssignJobToolStripMenuItem.Click
        AssignmentIsFor = "JOB"
        If Not MsgBox("Do you want to Assign the Work Order now to a Lead Service Specialist ?", vbYesNo) = vbYes Then
            Exit Sub
        End If
        '      Tunnel1 = UserLevelAccess
        ShowPersonnelForm()

        WorkOrdersSelectionFilter = " WHERE WorkOrderID_AutoNumber = " & Str(CurrentWorkOrderID)
        WorkOrdersFieldsToSelect = " UPDATE WorkOrdersTable  SET " &
                    " WorkOrderStatusID_LongInteger = " & GetStatusIdFor(" WorkOrdersTable", "For Analysis") & " , " & ' for lead mechanic to re assign jobs to specialists
                   " WorkOrderStatus_Byte = 1 "
        MySelection = WorkOrdersFieldsToSelect & WorkOrdersSelectionFilter
        JustExecuteMySelection()

        SetupWorkOrderSelection(0)
        WorkOrderStatusSelection = 0

        FillWorkOrdersDataGridView()
    End Sub

    Private Sub ProcessJobToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProcessJobToolStripMenuItem.Click

    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles AssignConcernToolStripMenuItem.Click
        AssignmentIsFor = "CONCERN"
        If Not MsgBox("Assign the Concern now to One Service Specialist ?", vbYesNo) = vbYes Then
            Exit Sub
        End If
        ShowPersonnelForm()
    End Sub

    Private Sub GetStandardJobsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GetStandardJobsToolStripMenuItem.Click
        'Using GetStandardJobsQuery

        Dim xxFieldsSelect = " 
SELECT top 10 WorkOrderConcernJobsTable.WorkOrderID_LongInteger, 
WorkOrdersTable.ServiceDate_DateTime, 
WorkOrderConcernsTable.ConcernID_LongInteger, 
WorkOrderConcernJobsTable.InformationsHeaderID_LongInteger
 "
        'TOP 10 ONLY TO COVER ALL MOST JOB LINKED CONCERN

        Dim xxTableLinks = " 
FROM(WorkOrderConcernJobsTable LEFT JOIN WorkOrderConcernsTable On WorkOrderConcernJobsTable.WorkOrderConcernID_LongInteger = WorkOrderConcernsTable.WorkOrderConcernID_AutoNumber) LEFT JOIN WorkOrdersTable On WorkOrderConcernsTable.WorkOrderID_LongInteger = WorkOrdersTable.WorkOrderID_AutoNumber
 "
        Dim xxSelectionFilter = " WHERE ConcernID_LongInteger = " & CurrentConcernID
        Dim xxOrder = " ORDER BY ServiceDate_DateTime DESC, WorkOrderConcernJobsTable.WorkOrderID_LongInteger "
        MySelection = xxFieldsSelect & xxTableLinks & xxSelectionFilter & xxOrder

        JustExecuteMySelection()
        Dim xxRecordCount = RecordCount
        WorkOrderConcernJobsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If xxRecordCount > 0 Then
            Dim SavedJobID = -1
            Dim SavedWorkOrderId = WorkOrderConcernJobsDataGridView.Item("WorkOrderID_LongInteger", 0).Value
            For i = 0 To xxRecordCount - 1
                If SavedWorkOrderId <> WorkOrderConcernJobsDataGridView.Item("WorkOrderID_LongInteger", i).Value Then
                    Exit For
                End If
                SavedJobID = WorkOrderConcernJobsDataGridView.Item("InformationsHeaderID_LongInteger", i).Value
                MySelection = "INSERT INTO WorkOrderConcernJobsTable  ( " &
                                                                      "  WorkOrderConcernID_LongInteger, " &
                                                                     "  InformationsHeaderID_LongInteger " &
                                                                     "  ) " &
                                                              " VALUES ( " &
                                                                        Str(CurrentWorkOrderConcernID) & ",  " &
                                                                         SavedJobID.ToString &
                                                                      " ) "
                JustExecuteMySelection()
            Next

        End If
        FillWorkOrderConcernJobsTable()
    End Sub

    Private Sub WarehouseRequestForPartsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RequestPartsFromWarehouseToolStripMenuItem.Click
        Tunnel1 = CurrentWorkOrderConcernID
        Tunnel3 = "Request parts from the Store / Parts Department"
        RequestPartsForm.WorkOrderNumberTextBox.Text = WorkOrdersDataGridView.Item("WorkOrderNumber_ShortText12", CurrentWorkOrdersRow).Value
        ShowCalledForm(Me, RequestPartsForm)
    End Sub
    Private Sub CustomerSuppliedPartsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomerSuppliedPartsToolStripMenuItem.Click
        Tunnel1 = CurrentWorkOrderConcernID
        Tunnel3 = "Receive parts from the Customer"
        RequestPartsForm.WorkOrderNumberTextBox.Text = WorkOrdersDataGridView.Item("WorkOrderNumber_ShortText12", CurrentWorkOrdersRow).Value
        ShowCalledForm(Me, RequestPartsForm)
    End Sub
    Private Sub EnableJobsOptions()
        JOBToolStripMenuItem.Visible = True
        AddJobToolStripMenuItem.Visible = True
        EditToolStripMenuItem.Visible = True
        RemoveJobToolStripMenuItem.Visible = True
    End Sub
    Private Function AllConcernsHaveJob()
        For i = 0 To WorkOrderConcernsRecordCount - 1
            CurrentWorkOrderConcernID = WorkOrderConcernsDataGridView.Item("WorkOrderConcernID_AutoNumber", i).Value
            CurrentConcernID = WorkOrderConcernsDataGridView.Item("ConcernID_LongInteger", i).Value
            CurrentLongTextConcernID = WorkOrderConcernsDataGridView.Item("ConcernLongTextCodeID_LongInteger", i).Value
            If CurrentConcernID > 0 Then
                FillWorkOrderConcernJobsTable()
                If WorkOrderConcernJobsRecordCount = 0 Then
                    MsgBox(WorkOrderConcernsDataGridView.Item("CoinedConcern", i).Value & " does not have jobs attached yet")
                    Return False
                End If
            End If

        Next

        Return True
    End Function

    Private Sub WorkOrderDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WorkOrderDetailsToolStripMenuItem.Click
        PurposeOfEntry = "VIEW"
        WorkOrderDetailsGroup.Visible = True
        WorkOrdersGroupBox.Enabled = False
        WorkOrderConcernsGroupBox.Enabled = False
        WorkOrderConcernJobsGroupBox.Enabled = False
        WorkOrderPartsPerJobGroupBox.Enabled = False
        WorkOrderNumberTextBox.Text = WorkOrdersDataGridView.Item("WorkOrderNumber_ShortText12", CurrentWorkOrdersRow).Value
        ServiceDate_DateTimeTextBox.Text = WorkOrdersDataGridView.Item("ServiceDate_DateTime", CurrentWorkOrdersRow).Value
        If IsNotEmpty(WorkOrdersDataGridView.Item("ReleaseDate_DateTime", CurrentWorkOrdersRow).Value) Then
            DateTimeOutTextBox.Text = WorkOrdersDataGridView.Item("ReleaseDate_DateTime", CurrentWorkOrdersRow).Value
        End If
        If IsNotEmpty(WorkOrdersDataGridView.Item("VehicleMilage_Integer", CurrentWorkOrdersRow).Value) Then
            MilageMaskedTextBox.Text = WorkOrdersDataGridView.Item("VehicleMilage_Integer", CurrentWorkOrdersRow).Value
        End If
        CustomerTextBox.Text = WorkOrdersDataGridView.Item("OwnerName", CurrentWorkOrdersRow).Value

        VINTextBox.Text = WorkOrdersDataGridView.Item("VinNo_ShortText20", CurrentWorkOrdersRow).Value
        VehicleDetailsTextBox.Text = CurrentVehicleString
        If Val(MilageMaskedTextBox.Text) < 1 Then
            MilageMaskedTextBox.Enabled = True
            MilageMaskedTextBox.Select()
        End If
        CancelToolStripMenuItem.Visible = True
    End Sub

    Private Sub SaveWorkOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveWorkOrderToolStripMenuItem.Click
        If IsNotEmpty(MilageMaskedTextBox.Text) Then
            WorkOrderDetailsGroup.Visible = False
            WorkOrdersGroupBox.Enabled = True
            WorkOrderConcernsGroupBox.Enabled = True
            WorkOrderConcernJobsGroupBox.Enabled = True
            WorkOrderPartsPerJobGroupBox.Enabled = True
            If MsgBox("Continue update the milage?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If MsgBox("Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    UpdateThisWorkOrderRecord()
                End If
            End If
        End If
    End Sub
    Private Sub UpdateThisWorkOrderRecord()
        Dim WorkOrderNumber = GetNewWorkOrderID(Convert.ToDateTime(Trim(ServiceDate_DateTimeTextBox.Text)), Trim(MilageMaskedTextBox.Text))

        MySelection = " UPDATE WorkOrdersTable  SET " &
                                    " WorkOrderNumber_ShortText12 = " & WorkOrderNumber &
                                    ", VehicleMilage_Integer = " & Val(MilageMaskedTextBox.Text) &
                                    " WHERE WorkOrderID_AutoNumber = " & Str(CurrentWorkOrderID)
        JustExecuteMySelection()
        FillWorkOrdersDataGridView()
    End Sub

End Class