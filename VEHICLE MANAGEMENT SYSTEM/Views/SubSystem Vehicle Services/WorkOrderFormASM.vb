Public Class WorkOrderFormASM

    Private CurrentWorkOrderNumber As String

    Private CurrentConcernID As Integer = -1
    Private CurrentJobID As Integer = -1

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
    Private CurrentWorkOrderStatus As String = ""

    Private WorkOrdersDataGridViewAlreadyFormatted = False

    Private WorkOrderConcernsFieldsToSelect = ""
    Private WorkOrderConcernsTablesLinks = ""
    Private WorkOrderConcernsSelectionFilter = ""
    Private WorkOrderConcernsSelectionOrder = ""
    Private WorkOrderConcernsDataGridViewLocationX As Integer
    Private WorkOrderConcernsDataGridViewLocationY As Integer
    Private CurrentInformationsHeaderID As Integer
    Private WorkOrderConcernsDataGridViewAlreadyFormatted = False
    Private SavedCustomer = ""
    Private PurposeOfEntry As String
    Private CurrentConcernAssignedServiceSpecialistID = -1

    Private WorkOrderConcernJobsFieldsToSelect = " "
    Private WorkOrderConcernJobsTablesLinks = "   "
    Private WorkOrderConcernJobsSelectionFilter = " "
    Private WorkOrderConcernJobsSelectionOrder = " "
    Private WorkOrderConcernJobsRecordCount = 0
    Private CurrentWorkOrderConcernJobID As Integer = -1
    Private CurrentWorkOrderConcernJobsRow = -1
    Private CurrentWorkOrderConcernStatusSequence = -1
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
    Private CurrentJobMasterCodeID = -1
    Private CurrentWorkOrderStatusSequence = -1
    Private CurrentConcernStatus = ""
    Private CurrentConcernJobStatusID = -1

    Public OutstandingForThisUserFilter = ""
    Private AssignmentIsFor = ""
    Private SavedCallingForm As Form

    Private Sub WorkOrderForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReceivepartsfromtheCustomerToolStripMenuItem.Text = "Register Customer Supplied Parts"
        SavedCallingForm = CallingForm
        ' INITIALIZE FIRST ALL DATAGRIDVIEWS for enabling all its field for reference

        WorkOrdersGroupBox.Visible = False
        WorkOrderConcernsGroupBox.Visible = False
        WorkOrderConcernJobsGroupBox.Visible = False
        WorkOrderPartsPerJobGroupBox.Visible = False
        WorkOrderDetailsGroup.Top = (Me.Height - WorkOrderDetailsGroup.Height) / 2
        WorkOrderDetailsGroup.Left = (Me.Width - WorkOrderDetailsGroup.Width) / 2
        DisplayOutstandingRecords()
        ' for the logged in user. this routine proceeds to FillWorkOrdersDataGridView()
        WorkOrderConcernsDataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True '(1 - Property state = true, 2- false, 3-default on development
        Me.Top = VehicleManagementSystemForm.VehicleManagementMenuStrip.Top + VehicleManagementSystemForm.VehicleManagementMenuStrip.Height

    End Sub

    Private Sub FillWorkOrdersDataGridView()

        WorkOrdersSelectionOrder = " ORDER BY WorkOrderID_AutoNumber DESC "

        WorkOrdersFieldsToSelect = " 
SELECT
WorkOrdersTable.WorkOrderNumber_ShortText12,
WorkOrdersTable.ServiceDate_DateTime,
WorkOrdersTable.ReleaseDate_DateTime,
WorkOrdersTable.VehicleMilage_Integer,
(VehiclesTable.YearManufactured_ShortText4 & space(1) & 
Trim(VehicleTypeTable.VehicleType_ShortText20) & space(1) & 
trim(VehicleModelsTable.VehicleModel_ShortText20) & space(1) & 
trim(VehicleTrimTable.VehicleTrimName_ShortText25)) AS VehicleModels,
(trim(OwnersTable.FirstName_ShortText30) & space(1) & 
Trim(OwnersTable.LastName_ShortText30) & space(1) & 
trim(OwnersTable.NamePrefix_ShortText3)) AS VehicleOwner,
OwnersTable.TelNo_ShortText10, 
(trim(CSSTable.FirstName_ShortText30) & space(1) & Trim(CSSTable.LastName_ShortText30)) AS CustomerServiceSpecialist, 
WorkOrdersTable.WorkOrderID_AutoNumber,
WorkOrdersTable.CustomerServiceInCharge_LongInteger,
WorkOrdersTable.ServiceManagerAssigning_LongInteger,
WorkOrdersTable.AssignedLeadMechanic_longInteger, 
WorkOrdersTable.WorkOrderStatusID_LongInteger,
StatusesTable.StatusSequence_LongInteger,
StatusesTable.StatusText_ShortText25 AS WorkOrderStatus
FROM ((((((((((WorkOrdersTable LEFT JOIN ServicedVehiclesTable ON WorkOrdersTable.ServicedVehicleID_LongInteger = ServicedVehiclesTable.ServicedVehicleID_AutoNumber) LEFT JOIN OwnersTable ON ServicedVehiclesTable.OwnerID_LongInteger = OwnersTable.OwnerID_AutoNumber) LEFT JOIN VehiclesTable ON ServicedVehiclesTable.VehicleID_LongInteger = VehiclesTable.VehicleID_AutoNumber) LEFT JOIN VehicleModelsRelationsTable ON VehiclesTable.VehicleModelsRelationID_LongInteger = VehicleModelsRelationsTable.VehicleModelsRelationID_Autonumber) LEFT JOIN VehicleTypeTable ON VehicleModelsRelationsTable.VehicleTypeID_LongInteger = VehicleTypeTable.VehicleTypeID_AutoNumber) LEFT JOIN VehicleTrimTable ON VehicleModelsRelationsTable.VehicleTrimID_LongInteger = VehicleTrimTable.VehicleTrimID_Autonumber) LEFT JOIN VehicleModelsTable ON VehicleModelsRelationsTable.VehicleModelID_LongInteger = VehicleModelsTable.VehicleModelID_Autonumber) LEFT JOIN PersonnelTable AS CSSTable ON WorkOrdersTable.CustomerServiceInCharge_LongInteger = CSSTable.PersonnelID_AutoNumber) LEFT JOIN PersonnelTable AS ASMTable ON WorkOrdersTable.ServiceManagerAssigning_LongInteger = ASMTable.PersonnelID_AutoNumber) LEFT JOIN PersonnelTable AS ALMTable ON WorkOrdersTable.AssignedLeadMechanic_longInteger = ALMTable.PersonnelID_AutoNumber) LEFT JOIN StatusesTable ON WorkOrdersTable.WorkOrderStatusID_LongInteger = StatusesTable.StatusID_Autonumber
"
        MySelection = WorkOrdersFieldsToSelect & WorkOrdersSelectionFilter & WorkOrdersSelectionOrder

        JustExecuteMySelection()
        WorkOrdersRecordCount = RecordCount
        If Not CurrentUserGroup = "Automotive Service Specialist" Then
            WorkOrderConcernsGroupBox.Visible = False
            WorkOrderConcernJobsGroupBox.Visible = False
            WorkOrderPartsPerJobGroupBox.Visible = False
        End If

        If WorkOrdersRecordCount > 0 Then
            WorkOrdersGroupBox.Visible = True
        Else
            WorkOrdersGroupBox.Visible = False
        End If
        WorkOrdersDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If WorkOrdersRecordCount = 0 Then
            CurrentWorkOrderID = -1
            PrintWorkOrderDetailsToolStripMenuItem.Visible = False
            AddJobToolStripMenuItem.Visible = False
            RemoveJobToolStripMenuItem.Visible = False
        End If


        ' HERE AT ROW_ENTER, FillWorkOrderConcernsDataGridView is called and WorkOrderConcernsbOX IS ALREADY FORMATTED
        If Not WorkOrdersDataGridViewAlreadyFormatted Then
            FormatWorkOrdersDataGridView()
            SetFormWidthAndGroupBoxLeft()
        End If

        Dim RecordsToDisplay = 5
        SetGroupBoxHeight(RecordsToDisplay, WorkOrdersRecordCount, WorkOrdersGroupBox, WorkOrdersDataGridView)
        If Not CurrentUserGroup = "Automotive Service Specialist" Then
            WorkOrdersGroupBox.Top = WorkOrderFormASMMenuStrip.Top + WorkOrderFormASMMenuStrip.Height
            WorkOrderConcernsGroupBox.Top = WorkOrdersGroupBox.Top + WorkOrdersGroupBox.Height
            WorkOrderConcernJobsGroupBox.Top = WorkOrderConcernsGroupBox.Top + WorkOrderConcernsGroupBox.Height
            WorkOrderPartsPerJobGroupBox.Top = WorkOrderConcernJobsGroupBox.Top + WorkOrderConcernJobsGroupBox.Height
        End If

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
                Case "VehicleModels"
                    WorkOrdersDataGridView.Columns.Item("VehicleModels").HeaderText = "VEHICLE"
                    WorkOrdersDataGridView.Columns.Item("VehicleModels").Width = 200
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
                Case "NewWorkOrderStatus"
                    WorkOrdersDataGridView.Columns.Item(i).HeaderText = "Status (new)"
                    WorkOrdersDataGridView.Columns.Item(i).Width = 200
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

        FillField(CurrentWorkOrderStatus, WorkOrdersDataGridView.Item("WorkOrderStatus", CurrentWorkOrdersRow).Value)
        FillField(CurrentWorkOrderStatusSequence, WorkOrdersDataGridView.Item("StatusSequence_LongInteger", CurrentWorkOrdersRow).Value)

        If CurrentUserGroup = "Automotive Service Specialist" Then Exit Sub

        'DISABLE ALL OPTIONAL WORK ORDER OPTIONS
        WorkOrderMenusToolStripMenuItem.Visible = False
        ConcernMenusToolStripMenuItem.Visible = False
        JobMenusToolStripMenuItem.Visible = False
        AssignWorkOrderToolStripMenuItem.Visible = False
        RevertWorkOrderStatsToolStripMenuItem.Visible = False

        If CurrentUserGroup = "Assistant Service Manager" Then 'NOTE ONLY THE Assistant Service Manager CAN Assign WorkOrder
            WorkOrderMenusToolStripMenuItem.Visible = True
            RevertWorkOrderStatsToolStripMenuItem.Visible = True
            If CurrentWorkOrderStatus = "For Analysis" Then
                AssignWorkOrderToolStripMenuItem.Visible = True
            End If
        End If
        If CurrentUserGroup = "Lead Service Specialist" Then 'NOTE ONLY THE Assistant Service Manager CAN Assign WorkOrder
            If CurrentWorkOrderStatus = "For Assignment" Then
                WorkOrderMenusToolStripMenuItem.Visible = True
                AssignWorkOrderToolStripMenuItem.Visible = True
            End If
        End If
        WorkOrderPartsPerJobGroupBox.Visible = False
        ReceivepartsfromtheCustomerToolStripMenuItem.Visible = False
        ' NOTE THIS IS A CASE OF FROm WORK ORDER TO JOBS
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
                                         " InformationsHeadersTypeTable.ConcernPrefix_ShortText50, " & ") 
"
        Dim ConcernAssignedServiceSpecialist = " PersonnelTable.LastName_ShortText30 & space(1) & " &
                                              " mid(PersonnelTable.FirstName_ShortText30,1,1) as ConcernAssignedServiceSpecialist, "

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
WorkOrderConcernsTable.AssignedServiceSpecialist_LongInteger,
WorkOrderConcernsTable.WorkOrderConcernStatusID_LongInteger,
ConcernsTable.InformationsHeadersTypeID_LongInteger,
ConcernsTable.Concern_ShortText255,
InformationsHeadersTypeTable.ConcernPrefix_ShortText50, " &
ConcernDescription &
" 
MasterCodeBookTable.SystemDesc_ShortText100Fld,
LongTextConcern_LongText, " &
ConcernAssignedServiceSpecialist &
" 
    StatusesTable.StatusText_ShortText25,
    StatusesTable.StatusText_ShortText25,
    OriginalExcelRecordTable.description
    FROM ((((((WorkOrderConcernsTable LEFT JOIN ConcernsTable ON WorkOrderConcernsTable.ConcernID_LongInteger = ConcernsTable.ConcernID_AutoNumber) LEFT JOIN InformationsHeadersTypeTable ON ConcernsTable.InformationsHeadersTypeID_LongInteger = InformationsHeadersTypeTable.InformationsHeadersTypeID_AutoNumber) LEFT JOIN MasterCodeBookTable ON ConcernsTable.MasterCodeBookId_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) LEFT JOIN ConcernAsIsByClientTable ON WorkOrderConcernsTable.ConcernLongTextCodeID_LongInteger = ConcernAsIsByClientTable.LongTextConcernID_Autonumber) LEFT JOIN OriginalExcelRecordTable ON WorkOrderConcernsTable.OriginalID_LongInteger = OriginalExcelRecordTable.OriginalID_AutoNumber) LEFT JOIN PersonnelTable ON WorkOrderConcernsTable.AssignedServiceSpecialist_LongInteger = PersonnelTable.PersonnelID_AutoNumber) LEFT JOIN StatusesTable ON WorkOrderConcernsTable.WorkOrderConcernStatusID_LongInteger = StatusesTable.StatusID_Autonumber
    "

        WorkOrderConcernsSelectionOrder = ""

        MySelection = WorkOrderConcernsFieldsToSelect & WorkOrderConcernsSelectionFilter & WorkOrderConcernsSelectionOrder

        JustExecuteMySelection()
        WorkOrderConcernsRecordCount = RecordCount
        WorkOrderConcernsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If WorkOrderConcernsRecordCount > 0 Then
            WorkOrderConcernsGroupBox.Visible = True
        Else
            WorkOrderConcernsGroupBox.Visible = False
        End If



        If Not WorkOrderConcernsDataGridViewAlreadyFormatted Then
            WorkOrderConcernsDataGridViewAlreadyFormatted = True
            FormatWorkOrderConcernsDataGridView()
        End If

        Dim RecordsToDisplay = 5
        SetGroupBoxHeight(RecordsToDisplay, WorkOrderConcernsRecordCount, WorkOrderConcernsGroupBox, WorkOrderConcernsDataGridView)
        If CurrentUserGroup = "Automotive Service Specialist" Then
            WorkOrderConcernsGroupBox.Top = WorkOrderConcernJobsGroupBox.Top + WorkOrderConcernJobsGroupBox.Height
            WorkOrdersGroupBox.Top = WorkOrderConcernsGroupBox.Top + WorkOrderConcernsGroupBox.Height
        Else
            WorkOrderConcernsGroupBox.Top = WorkOrdersGroupBox.Top + WorkOrdersGroupBox.Height
            WorkOrderConcernJobsGroupBox.Top = WorkOrderConcernsGroupBox.Top + WorkOrderConcernsGroupBox.Height
            WorkOrderPartsPerJobGroupBox.Top = WorkOrderConcernJobsGroupBox.Top + WorkOrderConcernJobsGroupBox.Height
        End If

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
                    WorkOrderConcernsDataGridView.Columns.Item(i).HeaderText = "Assigned Service Specialist"
                    WorkOrderConcernsDataGridView.Columns.Item(i).Width = 300
                    WorkOrderConcernsDataGridView.Columns.Item(i).Visible = True
                Case "StatusText_ShortText25"
                    WorkOrderConcernsDataGridView.Columns.Item(i).HeaderText = "Status"
                    WorkOrderConcernsDataGridView.Columns.Item(i).Width = 200
                    WorkOrderConcernsDataGridView.Columns.Item(i).Visible = True
            End Select
            If WorkOrderConcernsDataGridView.Columns.Item(i).Visible = True Then
                WorkOrderConcernsGroupBox.Width = WorkOrderConcernsGroupBox.Width + WorkOrderConcernsDataGridView.Columns.Item(i).Width
            End If
        Next
        If WorkOrderConcernsGroupBox.Width > VehicleManagementSystemForm.Width Then
            WorkOrderConcernsGroupBox.Width = Me.Width - 8
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
        CurrentConcernAssignedServiceSpecialistID = WorkOrderConcernsDataGridView.Item("AssignedServiceSpecialist_LongInteger", CurrentWorkOrderConcernsRow).Value
        CurrentConcernStatus = ""
        FillField(CurrentConcernStatus, WorkOrderConcernsDataGridView.Item("StatusText_ShortText25", CurrentWorkOrderConcernsRow).Value)
        ConcernMenusToolStripMenuItem.Visible = False
        GetStandardJobForThisConcernToolStripMenuItem.Visible = False
        EditJobToolStripMenuItem.Visible = False
        RemoveJobToolStripMenuItem.Visible = False
        AssignJobToolStripMenuItem.Visible = False

        If CurrentUserGroup = "Automotive Service Specialist" Then
            CurrentWorkOrderID = WorkOrderConcernsDataGridView.Item("WorkOrderID_LongInteger", CurrentWorkOrderConcernsRow).Value
            WorkOrdersSelectionFilter = " WHERE WorkOrderID_AutoNumber = " & Str(CurrentWorkOrderID)
            FillWorkOrdersDataGridView()
            Exit Sub
        End If

        FillWorkOrderConcernJobsTable()
        If InStr("No Action Yet/Assigned/Draft Work Order", CurrentConcernStatus) Then
            If CurrentUserGroup = "Lead Service Specialist" Or CurrentUserGroup = "Automotive Service Specialist" Then
                If WorkOrderConcernJobsRecordCount = 0 Then
                    GetStandardJobForThisConcernToolStripMenuItem.Visible = True
                End If
                JobMenusToolStripMenuItem.Visible = True
            End If
            If CurrentUserGroup = "Lead Service Specialist" Then
                ConcernMenusToolStripMenuItem.Visible = True
            End If
        End If
    End Sub




    Private Sub FillWorkOrderConcernJobsTable()
        WorkOrderPartsPerJobGroupBox.Visible = False

        WorkOrderConcernJobsFieldsToSelect =
" 
SELECT WorkOrdersTable.WorkOrderNumber_ShortText12, 
WorkOrderConcernJobsTable.WorkOrderConcernJobID_AutoNumber, 
WorkOrderConcernJobsTable.InformationsHeaderID_LongInteger, 
WorkOrderConcernJobsTable.WorkOrderConcernJobStatus_Byte, 
WorkOrderConcernJobsTable.WorkOrderConcernID_LongInteger, 
WorkOrderConcernJobsTable.WorkOrderConcernJobStatusID_LongInteger, 
WorkOrderConcernJobsTable.AssignedServiceSpecialist_LongInteger, 
WorkOrderConcernsTable.WorkOrderID_LongInteger, 
WorkOrderConcernsTable.ConcernID_LongInteger, 
InformationsHeadersTypeTable.Prefix & Space(1) & MasterCodeBookTable.SystemDesc_ShortText100Fld AS Job, 
MasterCodeBookTable.SystemDesc_ShortText100Fld, 
PersonnelTable.FirstName_ShortText30, 
PersonnelTable.LastName_ShortText30, 
OriginalExcelRecordTable.description, 
PersonnelTable.LastName_ShortText30 & Space(1) & Mid(PersonnelTable.FirstName_ShortText30,1,1) AS AssignedServiceSpecialist, 
InformationsHeadersTable.MasterCodeBookId_LongInteger, 
StatusesTable.StatusSequence_LongInteger,
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
        RequestPartsFromWarehouseToolStripMenuItem.Visible = False
        WorkOrderConcernJobsRecordCount = RecordCount
        WorkOrderConcernJobsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        WorkOrderPartsPerJobGroupBox.Visible = False
        If WorkOrderConcernJobsRecordCount > 0 Then
            JobMenusToolStripMenuItem.Visible = True
            WorkOrderConcernJobsGroupBox.Visible = True
        Else
            WorkOrderConcernJobsGroupBox.Visible = False
            If CurrentUserGroup = "Lead Service Specialist" Then
                RemoveConcernToolStripMenuItem.Visible = True
                ConcernMenusToolStripMenuItem.Visible = True
            End If
        End If

        If Not WorkOrderConcernJobsDataGridViewFormatted Then
            FormatWorkOrderConcernJobsDataGridView()
            SetFormWidthAndGroupBoxLeft()
        End If
        Dim RecordsToDisplay = 7
        SetGroupBoxHeight(RecordsToDisplay, WorkOrderConcernJobsRecordCount, WorkOrderConcernJobsGroupBox, WorkOrderConcernJobsDataGridView)
        If CurrentUserGroup = "Automotive Service Specialist" Then
            WorkOrderConcernJobsGroupBox.Top = WorkOrderFormASMMenuStrip.Top + WorkOrderFormASMMenuStrip.Height
            WorkOrderConcernsGroupBox.Top = WorkOrderConcernJobsGroupBox.Top + WorkOrderConcernJobsGroupBox.Height
            WorkOrdersGroupBox.Top = WorkOrderConcernsGroupBox.Top + WorkOrderConcernsGroupBox.Height
            WorkOrderPartsPerJobGroupBox.Top = WorkOrdersGroupBox.Top + WorkOrdersGroupBox.Height
        Else
            WorkOrderPartsPerJobGroupBox.Top = WorkOrderConcernJobsGroupBox.Top + WorkOrderConcernJobsGroupBox.Height
        End If
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
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).Width = 200
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

        Dim XXCurrentJobStatus = ""
        Dim CurrentAssignedServiceSpecialistID = -1
        CurrentWorkOrderConcernJobsRow = e.RowIndex
        JobDoneToolStripMenuItem.Visible = False
        ProcessJobToolStripMenuItem.Visible = False
        CurrentWorkOrderConcernJobID = WorkOrderConcernJobsDataGridView.Item("WorkOrderConcernJobID_AutoNumber", CurrentWorkOrderConcernJobsRow).Value
        CurrentInformationsHeaderID = WorkOrderConcernJobsDataGridView.Item("InformationsHeaderID_LongInteger", CurrentWorkOrderConcernJobsRow).Value
        CurrentJobMasterCodeID = WorkOrderConcernJobsDataGridView.Item("MasterCodeBookId_LongInteger", CurrentWorkOrderConcernJobsRow).Value
        CurrentConcernJobStatusID = WorkOrderConcernJobsDataGridView.Item("WorkOrderConcernJobStatusID_LongInteger", CurrentWorkOrderConcernJobsRow).Value
        FillField(CurrentAssignedServiceSpecialistID, WorkOrderConcernJobsDataGridView.Item("AssignedServiceSpecialist_LongInteger", CurrentWorkOrderConcernJobsRow).Value)
        FillField(XXCurrentJobStatus, WorkOrderConcernJobsDataGridView.Item("StatusText_ShortText25", CurrentWorkOrderConcernJobsRow).Value)
        AssignJobToolStripMenuItem.Visible = False
        RemoveJobToolStripMenuItem.Visible = False
        RequestPartsFromWarehouseToolStripMenuItem.Visible = False
        EditJobToolStripMenuItem.Visible = False
        'ADDING JOB DEPENDS ON THE STATUS OF THE CONCERN

        If CurrentUserGroup = "Lead Service Specialist" Then
            If InStr("No Action Yet/Assigned/", XXCurrentJobStatus) Then
                AssignJobToolStripMenuItem.Visible = True
                RemoveJobToolStripMenuItem.Visible = True
                EditJobToolStripMenuItem.Visible = True
            End If
        End If
        If CurrentPersonelID = CurrentAssignedServiceSpecialistID Then
            If XXCurrentJobStatus = "Repair Ongoing" Then
                JobDoneToolStripMenuItem.Visible = True
            ElseIf XXCurrentJobStatus = "All Parts Received" Then
                ProcessJobToolStripMenuItem.Visible = True
            ElseIf InStr("No Part Needed/Parts From Customer/Assigned", XXCurrentJobStatus) Then
                RemoveJobToolStripMenuItem.Visible = True ' though attached part(s) should be removed 1st
                EditJobToolStripMenuItem.Visible = True ' though attached part(s) should be removed 1st
            ElseIf InStr("No Action Yet/Draft Requisition//Assigned", XXCurrentJobStatus) Then
                RemoveJobToolStripMenuItem.Visible = True ' though attached part(s) should be removed 1st
                EditJobToolStripMenuItem.Visible = True ' though attached part(s) should be removed 1st
                RequestPartsFromWarehouseToolStripMenuItem.Visible = True
                ReceivepartsfromtheCustomerToolStripMenuItem.Visible = True
            End If
        End If
        WorkOrderPartsPerJobSelectionFilter = " WHERE WorkOrderConcernJobID_AutoNumber = " & CurrentWorkOrderConcernJobID

        FillWorkOrderPartsPerJobDataGridView()

        If CurrentUserGroup = "Automotive Service Specialist" Then
            ' SHOWING FROM JOBS TO CONCERNS BACKWARDS
            CurrentWorkOrderConcernID = WorkOrderConcernJobsDataGridView.Item("WorkOrderConcernID_LongInteger", CurrentWorkOrderConcernJobsRow).Value
            WorkOrderConcernsSelectionFilter = " WHERE WorkOrderConcernsTable.WorkOrderConcernID_AutoNumber = " & CurrentWorkOrderConcernID
            FillWorkOrderConcernsDataGridView()

        End If

    End Sub
    Private Sub FillWorkOrderPartsPerJobDataGridView()
        WorkOrderPartsPerJobFieldsToSelect =
" 
SELECT WorkOrderPartsTable.WorkOrderPartID_AutoNumber, 
MasterCodeBookTable.MasterCodeBookID_Autonumber, 
MasterCodeBookTable.SystemDesc_ShortText100Fld, 
PartNumbersSpecificationsTable.PartNumberSpecifications_ShortText30, 
PartsSpecificationsTable.PartsSpecificationID_AutoNumber, 
PartsSpecificationsTable.PartSpecifications_ShortText255, 
WorkOrderPartsTable.Quantity_Integer, WorkOrderPartsTable.Unit_ShortText3, 
WorkOrderPartsTable.ProductPartID_LongInteger, 
StatusesTable.StatusText_ShortText25, 
WorkOrderConcernJobsTable.WorkOrderConcernJobID_AutoNumber, 
WorkOrderPartsTable.CodeVehicleID_LongInteger, 
StatusesTable.StatusID_Autonumber
FROM ((((((WorkOrderPartsTable LEFT JOIN MasterCodeBookTable ON WorkOrderPartsTable.MasterCodeBookID_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) LEFT JOIN WorkOrderConcernJobsTable ON WorkOrderPartsTable.WorkOrderConcernJobID_LongInteger = WorkOrderConcernJobsTable.WorkOrderConcernJobID_AutoNumber) LEFT JOIN StatusesTable ON WorkOrderPartsTable.WorkOrderPartStatusID_LongInteger = StatusesTable.StatusID_Autonumber) LEFT JOIN CodeVehiclePartNumbersSpecificationsRelationsTable ON WorkOrderPartsTable.CodeVehicleID_LongInteger = CodeVehiclePartNumbersSpecificationsRelationsTable.CodeVehicleID_LongInteger) LEFT JOIN CodeVehiclePartsSpecificationsRelationsTable ON WorkOrderPartsTable.CodeVehicleID_LongInteger = CodeVehiclePartsSpecificationsRelationsTable.CodeVehicleID_LongInteger) LEFT JOIN PartsSpecificationsTable ON CodeVehiclePartsSpecificationsRelationsTable.PartsSpecificationID_LongInteger = PartsSpecificationsTable.PartsSpecificationID_AutoNumber) LEFT JOIN PartNumbersSpecificationsTable ON CodeVehiclePartNumbersSpecificationsRelationsTable.PartNumbersSpecificationID_LongInteger = PartNumbersSpecificationsTable.PartNUmbersSpecificationID_AutoNumber
"
        WorkOrderPartsPerJobSelectionOrder = "  "
        MySelection = WorkOrderPartsPerJobFieldsToSelect & WorkOrderPartsPerJobSelectionFilter
        JustExecuteMySelection()
        WorkOrderPartsPerJobRecordCount = RecordCount
        If WorkOrderPartsPerJobRecordCount > 0 Then
            WorkOrderPartsPerJobGroupBox.Visible = True
        Else
            WorkOrderPartsPerJobGroupBox.Visible = False
        End If
        If CurrentUserGroup = "Automotive Service Specialist" Then
            WorkOrderPartsPerJobDataGridView.Top = WorkOrdersDataGridView.Top + WorkOrdersDataGridView.Height
        Else
            WorkOrderConcernsGroupBox.Top = WorkOrdersDataGridView.Top + WorkOrdersDataGridView.Height
        End If
        Dim RecordsToDisplay = 5
        SetGroupBoxHeight(RecordsToDisplay, WorkOrderPartsPerJobRecordCount, WorkOrderPartsPerJobGroupBox, WorkOrderPartsPerJobDataGridView)
        WorkOrderPartsPerJobDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If Not WorkOrderPartsPerJobDataGridViewAlreadyFormatted Then FormatWorkOrderPartsPerJobDataGridView()
    End Sub
    Private Sub FormatWorkOrderPartsPerJobDataGridView()
        Dim PartsFromCustomer = False
        If WorkOrderPartsPerJobRecordCount > 0 Then
        End If
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
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).HeaderText = "Part Required"
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).Width = 250
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).Visible = True
                Case "Quantity_Integer"
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).HeaderText = "Spec Qty"
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).Width = 60
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).Visible = True
                Case "Unit_ShortText3"
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).HeaderText = "Spec Unit"
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).Width = 100
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).Visible = True
                Case "PartNumberSpecifications_ShortText30"
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).HeaderText = "Part # Specifications"
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).Width = 200
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).Visible = True
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                Case "PartsSpecifications_ShortText255"
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).HeaderText = "Part Specifications"
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).Width = 400
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).Visible = True
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                Case "StatusText_ShortText25"
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).HeaderText = "Status"
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).Width = 120
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).Visible = True
            End Select

            If WorkOrderPartsPerJobDataGridView.Columns.Item(i).Visible = True Then
                WorkOrderPartsPerJobGroupBox.Width = WorkOrderPartsPerJobGroupBox.Width + WorkOrderPartsPerJobDataGridView.Columns.Item(i).Width
            End If
        Next

        If WorkOrderPartsPerJobGroupBox.Width > Me.Width Then
            WorkOrderPartsPerJobGroupBox.Width = Me.Width - 8
        End If
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
                'UPDATE InformationsHeadersTable AND MARK FIELD Selected true
                UpdateTable("InformationsHeadersTable", "SET Selected = True", "WHERE InformationsHeaderID_AutoNumber = " & CurrentJobID)

            Case "Tunnel2IsPersonnelID"
                AssignedPersonnelID = Tunnel2
                Select Case CurrentUserGroup
                    Case "Lead Service Specialist"

                        Select Case AssignmentIsFor
                            Case "WORKORDER"
                                ' SET WORK STATUS  TO "Assigned"	For job fixing, outstanding for ASS
                                MySelection = " UPDATE WorkOrdersTable SET " &
                                              " WorkOrderStatusID_LongInteger = " & GetStatusIdFor("WorkOrdersTable", "Assigned") &
                                                 " WHERE  WorkOrderID_AutoNumber = " & CurrentWorkOrderID
                                JustExecuteMySelection()
                                AssignThisConcern()
                            Case "CONCERN"
                                AssignThisConcern()
                            Case "JOB"
                                AssignThisJob()
                        End Select
                    Case "Assistant Service Manager"

                        MySelection = " UPDATE WorkOrdersTable  SET " &
                                    " WorkOrderStatusID_LongInteger = " & GetStatusIdFor(" WorkOrdersTable", "For Assignment") & " , " & ' for lead mechanic to re assign jobs to specialists
                                    " AssignedLeadMechanic_longInteger = " & AssignedPersonnelID &
                                    " WHERE WorkOrderID_AutoNumber = " & Str(CurrentWorkOrderID)
                        JustExecuteMySelection()
                    Case Else
                        MsgBox("BREAK DEBUGGER HERE, UNDETERMINED CALLED FORM")

                End Select

                FillWorkOrdersDataGridView()
            Case Else
                If CurrentUserGroup = "Automotive Service Specialist" Then
                    FillWorkOrderConcernJobsTable()
                Else
                    FillWorkOrdersDataGridView()
                End If

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
        Dim FieldsToUpdate =
" 
WorkOrderID_LongInteger, 
WorkOrderConcernID_LongInteger,
AssignedServiceSpecialist_LongInteger,
InformationsHeaderID_LongInteger,
WorkOrderConcernJobStatusID_LongInteger
"

        Dim FieldsData =
Str(CurrentWorkOrderID) & ",  " &
Str(CurrentWorkOrderConcernID) & ",  " &
Str(CurrentConcernAssignedServiceSpecialistID) & ",  " &
Str(CurrentJobID) & ",  " &
GetStatusIdFor("WorkOrderConcernJobsTable")


        CurrentWorkOrderConcernJobID = InsertNewRecord("WorkOrderConcernJobsTable", FieldsToUpdate, FieldsData)

        FillWorkOrderConcernJobsTable()
        ' Concerns table should be updated through the codebookform

    End Sub
    Private Sub AssignThisConcern()
        MySelection = " UPDATE WorkOrderConcernsTable  SET " &
                   " WorkOrderConcernStatusID_LongInteger = " & GetStatusIdFor(" WorkOrderConcernsTable", "Assigned") & " , " & ' for lead mechanic to re assign jobs to specialists
                   " AssignedServiceSpecialist_LongInteger = " & Str(AssignedPersonnelID) &
                   " WHERE WorkOrderConcernID_AutoNumber = " & CurrentWorkOrderConcernID.ToString

        JustExecuteMySelection()
        For I = 0 To WorkOrderConcernJobsRecordCount - 1
            CurrentWorkOrderConcernJobID = WorkOrderConcernJobsDataGridView.Item("WorkOrderConcernJobID_AutoNumber", I).Value
            AssignThisJob()
        Next
    End Sub
    Private Sub AssignThisJob()
        MySelection = " UPDATE WorkOrderConcernJobsTable  SET " &
                   " WorkOrderConcernJobStatusID_LongInteger = " & GetStatusIdFor("WorkOrderConcernJobsTable", "Assigned") & " , " & ' for lead mechanic to re assign jobs to specialists
                   " AssignedServiceSpecialist_LongInteger = " & Str(AssignedPersonnelID) &
                   " WHERE WorkOrderConcernJobID_AutoNumber = " & CurrentWorkOrderConcernJobID.ToString
        JustExecuteMySelection()
    End Sub

    Private Sub DisplayOutstandingRecords()
        Select Case CurrentUserGroup
            Case "Assistant Service Manager"
                Dim xxUserFilter = ""
                WorkOrdersSelectionFilter = SetupTableSelectionFilter(GetStatusIdFor("WorkOrdersTable", "For Analysis", 1), 2, Me, "Outstanding For Analysis", xxUserFilter)
            Case "Automotive Service Specialist"
                Dim xxUserFilter = " WorkOrderConcernJobsTable.AssignedServiceSpecialist_LongInteger = " & CurrentPersonelID.ToString
                WorkOrderConcernJobsSelectionFilter = SetupTableSelectionFilter(GetStatusIdFor("WorkOrderConcernJobsTable", "Repair Done", 1), 4, Me, "Outstanding", xxUserFilter)
                FillWorkOrderConcernJobsTable()
                Exit Sub
            Case "Lead Service Specialist"
                Dim xxUserFilter = " AssignedLeadMechanic_longInteger= " & CurrentPersonelID.ToString
                WorkOrdersSelectionFilter = SetupTableSelectionFilter(GetStatusIdFor("WorkOrdersTable", "Repair Ongoing", 1), 1, Me, "Outstanding", xxUserFilter)
            Case Else
                MsgBox("usergrop not i select case ")
        End Select
        FillWorkOrdersDataGridView()
    End Sub

    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        If WorkOrderDetailsGroup.Visible Then
            WorkOrderDetailsGroup.Visible = False
            WorkOrdersGroupBox.Enabled = True
            WorkOrderConcernsGroupBox.Enabled = True
            WorkOrderConcernJobsGroupBox.Enabled = True
            WorkOrderPartsPerJobGroupBox.Enabled = True
        Else
            DoCommonHouseKeeping(Me, SavedCallingForm)
        End If
    End Sub
    Private Sub AddJobToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddJobToolStripMenuItem.Click
        Tunnel1 = "ADD"
        ShowInformationsHeadersForm()
    End Sub
    Private Sub ShowInformationsHeadersForm()
        InformationsHeadersForm.CodeBookDescriptionToolStripTextBox.Text = CurrentVehicleString
        Tunnel2 = CurrentConcernID
        ShowCalledForm(Me, InformationsHeadersForm)
    End Sub
    Private Sub EditJobToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditJobToolStripMenuItem.Click
        Tunnel1 = "UPDATE"
        ShowJobsForm()
    End Sub
    Public Sub ShowJobsForm()
    End Sub

    Public Sub ShowPersonnelForm()
        ShowCalledForm(Me, PersonnelsForm)
    End Sub
    Private Sub RevertWorkOrderStatsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RevertWorkOrderStatsToolStripMenuItem.Click

        If MsgBox("Are you sure you would like to revert current WORK ORDER status? ", 4) = vbNo Then
            Exit Sub
        End If

        RevertCurrentStatusOf("WorkOrdersTable", CurrentWorkOrderStatusSequence, CurrentWorkOrderID)

        CurrentWorkOrderConcernStatusSequence = WorkOrderConcernsDataGridView.Item("StatusSequence_LongInteger", CurrentWorkOrderConcernsRow).Value
        RevertCurrentStatusOf("WorkOrdersTable", CurrentWorkOrderConcernStatusSequence, CurrentWorkOrderConcernID)
        For i = 0 To WorkOrderConcernJobsRecordCount - 1
            CurrentWorkOrderConcernJobID = WorkOrderConcernJobsDataGridView.Item("WorkOrderConcernJobID_AutoNumber", i).Value
            Dim CurrentWorkOrderConcernJobStatusSequence = WorkOrderConcernJobsDataGridView.Item("WorkOrderConcernJobStatusID_LongInteger", i).Value
            RevertCurrentStatusOf("WorkOrderConcernJobsTable", CurrentWorkOrderConcernJobStatusSequence, CurrentWorkOrderConcernJobID)
        Next

        FillWorkOrdersDataGridView()

    End Sub
    Private Sub RevertConcernToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RevertConcernToolStripMenuItem.Click
        If MsgBox("Are you sure you would like to revert current CONCERN status? ", 4) = vbNo Then
            Exit Sub
        End If

        Dim CurrentWorkOrderConcernStatusSequence = WorkOrderConcernsDataGridView.Item("WorkOrderConcernStatusID_LongInteger", CurrentWorkOrderConcernsRow).Value
        RevertCurrentStatusOf("WorkOrderConcernsTable", CurrentWorkOrderConcernStatusSequence, CurrentWorkOrderConcernID)
        For i = 0 To WorkOrderConcernJobsRecordCount - 1
            CurrentWorkOrderConcernJobID = WorkOrderConcernJobsDataGridView.Item("WorkOrderConcernJobID_AutoNumber", i).Value
            Dim CurrentWorkOrderConcernJobStatusSequence = WorkOrderConcernJobsDataGridView.Item("StatusSequence_LongInteger", i).Value
            RevertCurrentStatusOf("WorkOrderConcernJobsTable", CurrentWorkOrderConcernJobStatusSequence, CurrentWorkOrderConcernJobID)
        Next

        FillWorkOrdersDataGridView()
    End Sub
    Private Sub RevertJobStatusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RevertJobStatusToolStripMenuItem.Click

        If MsgBox("Are you sure you would like to revert current JOB status? ", 4) = vbNo Then
            Exit Sub
        End If

        CurrentWorkOrderConcernJobID = WorkOrderConcernJobsDataGridView.Item("WorkOrderConcernJobID_AutoNumber", CurrentWorkOrderConcernJobsRow).Value
        Dim CurrentWorkOrderConcernJobStatusSequence = WorkOrderConcernJobsDataGridView.Item("StatusSequence_LongInteger", CurrentWorkOrderConcernJobsRow).Value
        If CurrentWorkOrderConcernJobStatusSequence = 0 Then
            MsgBox("Initial Status of this job has been reached !!! ")
            Exit Sub
        End If
        RevertCurrentStatusOf("WorkOrderConcernJobsTable", CurrentWorkOrderConcernJobStatusSequence, CurrentWorkOrderConcernJobID)

        FillWorkOrderConcernJobsTable()
    End Sub
    Private Sub AssignJobToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles AssignJobToolStripMenuItem.Click

        AssignmentIsFor = "JOB"
        '      Tunnel1 = UserLevelAccess
        ShowPersonnelForm()

    End Sub
    Private Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles ProcessJobToolStripMenuItem.Click
        MsgBox("HERE jobs are set to as if Repair Ongoing")
        MySelection = " update WorkOrderConcernJobsTable SET " &
                             " WorkOrderConcernJobStatusID_LongInteger =  " & GetStatusIdFor("WorkOrderConcernJobsTable", "Repair Ongoing") &' newly assigned
                              " WHERE WorkOrderConcernJobID_AutoNumber = " & CurrentWorkOrderConcernJobID

        JustExecuteMySelection()
        FillWorkOrderConcernJobsTable()
        Exit Sub
        Tunnel1 = CurrentJobMasterCodeID
        ShowCalledForm(Me, MasterCodeBookForm)
    End Sub
    Private Sub ToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles RequestPartsFromWarehouseToolStripMenuItem.Click
        Tunnel3 = "Request parts from the Store / Parts Department"
        ShowRequestPartsForm()
    End Sub
    Private Sub ToolStripMenuItem9_Click(sender As Object, e As EventArgs) Handles ReceivepartsfromtheCustomerToolStripMenuItem.Click
        Tunnel3 = "Receive parts from the Customer"
        ShowRequestPartsForm()
    End Sub
    Private Sub ShowRequestPartsForm()
        Tunnel1 = CurrentWorkOrderConcernID
        RequestPartsForm.WorkOrderConcernButton.Text = WorkOrderConcernsDataGridView.Item("CoinedConcern", CurrentWorkOrderConcernsRow).Value
        If CurrentWorkOrdersRow <> -1 Then RequestPartsForm.VehicleNameButton.Text = WorkOrdersDataGridView.Item("VehicleModels", CurrentWorkOrdersRow).Value
        ShowCalledForm(Me, RequestPartsForm)

    End Sub
    Private Sub EnableConcernMenus()
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
    Private Sub ToolStripMenuItem10_Click(sender As Object, e As EventArgs) Handles JobDoneToolStripMenuItem.Click

        If MsgBox("Continue Finalizing this Job ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        ' update job status to "Repair Done"
        'TEMPORARILY USING WorkOrdersDataGridView
        ShowInTaskbarFlag = True

        MySelection = " update WorkOrderConcernJobsTable SET " &
                          " WorkOrderConcernJobStatusID_LongInteger =  " & GetStatusIdFor("WorkOrderConcernJobsTable", "Repair Done") &
                                    " WHERE  WorkOrderConcernJobID_Autonumber = " & CurrentWorkOrderConcernJobID

        JustExecuteMySelection()

        UpdateConcernStatus()

        UpdateWorkOrderStatus()
        'NOW RESTORE WorkOrdersDataGridView TO ITS ORIGINAL CONTENTS
        ShowInTaskbarFlag = False
        If CurrentUserGroup = "Automotive Service Specialist" Then
            FillWorkOrderConcernJobsTable()
        Else
            FillWorkOrdersDataGridView()
        End If
    End Sub
    Private Sub UpdateConcernStatus()
        MySelection = " Select * From WorkOrderConcernJobsTable WHERE WorkOrderConcernID_LongInteger = " & CurrentWorkOrderConcernID.ToString
        JustExecuteMySelection()
        WorkOrdersDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        Dim xxConcernStatus = "Done"
        For i = 0 To RecordCount - 1
            Dim xxWorkOrderConcernJobsID = WorkOrdersDataGridView.Item("WorkOrderConcernJobID_AutoNumber", i).Value
            Dim xFieldValue = GetFieldValue("WorkOrderConcernJobsTable", "WorkOrderConcernJobID_AutoNumber", CurrentWorkOrderConcernJobID, "WorkOrderConcernJobStatusID_LongInteger")
            Dim xxStatus = GetFieldValue("StatusesTable", "StatusID_AutoNumber", xFieldValue, "StatusText_ShortText25")
            If Not xxStatus = "Repair Done" Then
                xxConcernStatus = "Partially Done"
            End If
        Next
        MySelection = " UPDATE WorkOrderConcernsTable SET " &
                      " WorkOrderConcernStatusID_LongInteger =  " & GetStatusIdFor("WorkOrderConcernsTable", xxConcernStatus) &
                        " WHERE  WorkOrderConcernID_AutoNumber = " & CurrentWorkOrderConcernID

        JustExecuteMySelection()
    End Sub
    Private Sub UpdateWorkOrderStatus()
        MySelection = " Select * From WorkOrderConcernsTable WHERE WorkOrderID_LongInteger = " & CurrentWorkOrderID.ToString
        JustExecuteMySelection()

        'TEMPORARILY USING WorkOrdersDataGridView
        WorkOrdersDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        For i = 0 To RecordCount - 1
            Dim xxWorkOrderConcernID = WorkOrdersDataGridView.Item("WorkOrderConcernID_AutoNumber", i).Value
            Dim xFieldValue = GetFieldValue("WorkOrderConcernsTable", "WorkOrderConcernID_AutoNumber", xxWorkOrderConcernID, "WorkOrderConcernStatusID_LongInteger")
            Dim xxStatus = GetFieldValue("StatusesTable", "StatusID_AutoNumber", xFieldValue, "StatusText_ShortText25")
            If Not xxStatus = "Done" Then
                Exit Sub
            End If
        Next
        'NOW RESTORE WorkOrdersDataGridView TO ITS ORIGINAL CONTENTS
        MySelection = " UPDATE WorkOrdersTable SET " &
                          " WorkOrderStatusID_LongInteger = " & GetStatusIdFor("WorkOrdersTable", "For Billing") &
                          " WHERE  WorkOrderID_AutoNumber = " & CurrentWorkOrderID

        JustExecuteMySelection()
    End Sub

    Private Sub AssignWorkOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AssignWorkOrderToolStripMenuItem.Click
        AssignmentIsFor = "WORKORDER"
        ShowPersonnelForm()
    End Sub
    Private Sub AssignConcernToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles AssignConcernToolStripMenuItem.Click
        If WorkOrderConcernJobsRecordCount = 0 Then
            MsgBox("Not Job(s) attached yet")
            Exit Sub
        End If
        AssignmentIsFor = "CONCERN"
        ShowPersonnelForm()
    End Sub
    Private Sub AddConcernToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddConcernToolStripMenuItem.Click
        CurrentLongTextConcernID = -1
        CurrentConcernID = -1
        ShowCalledForm(Me, ConcernsForm)
    End Sub
    Private Sub EditToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles EditConcernToolStripMenuItem.Click
        PurposeOfEntry = "EDIT"
        ShowCalledForm(Me, ConcernsForm)
    End Sub
    Private Sub RemoveConcernToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveConcernToolStripMenuItem.Click
        If CurrentWorkOrderConcernJobID > 0 Then
            MsgBox("Remove linked job(s) to be able to delete this concern")
        End If
        Dim Concern_ShortText255 As String = ""
        If IsDBNull(WorkOrderConcernsDataGridView("Concern_ShortText255", CurrentWorkOrderConcernsRow).Value) Then
            If IsDBNull(WorkOrderConcernsDataGridView("WorkOrderID_LongInteger", CurrentWorkOrderConcernsRow).Value) Then
                If IsDBNull(WorkOrderConcernsDataGridView("LongTextConcern_LongText", CurrentWorkOrderConcernsRow).Value) Then
                    Exit Sub
                Else
                    Concern_ShortText255 = Trim(WorkOrderConcernsDataGridView("LongTextConcern_LongText", CurrentWorkOrderConcernsRow).Value)
                End If
            Else
                Concern_ShortText255 = Trim(WorkOrderConcernsDataGridView("SystemDesc_ShortText100Fld", CurrentWorkOrderConcernsRow).Value)
            End If
        Else
            Concern_ShortText255 = Trim(WorkOrderConcernsDataGridView("Concern_ShortText255", CurrentWorkOrderConcernsRow).Value)
        End If
        Dim Question As String = Trim(Concern_ShortText255) & Chr(13) & "Do you want to remove this concern"


        Dim DeleteThisConcern As String = MsgBox(Question, 4)
        If DeleteThisConcern = vbNo Then
            Exit Sub
        End If

        MySelection = "DELETE FROM WorkOrderConcernsTable WHERE WorkOrderConcernID_AutoNumber = " & Str(CurrentWorkOrderConcernID)
        JustExecuteMySelection()
        FillWorkOrderConcernsDataGridView()
    End Sub
    Private Sub RemoveJobToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles RemoveJobToolStripMenuItem.Click

        Dim Job_ShortText255 As String = ""
        If WorkOrderPartsPerJobRecordCount > 0 Then
            MsgBox("Remove all attached part before deleting this job")
            Exit Sub
        End If
        Job_ShortText255 = Trim(WorkOrderConcernJobsDataGridView("Job", CurrentWorkOrderConcernJobsRow).Value)
        Dim Question As String = "Do you want to remove the job" & vbCrLf & vbCrLf & Trim(Job_ShortText255)

        Dim DeleteThisConcernJob As String = MsgBox(Question, 4)
        If DeleteThisConcernJob = vbNo Then
            Exit Sub
        End If

        MySelection = "DELETE FROM WorkOrderConcernJobsTable WHERE WorkOrderConcernJobID_AutoNumber = " & Str(CurrentWorkOrderConcernJobID)
        JustExecuteMySelection()
        FillWorkOrderConcernJobsTable()
    End Sub

    Private Sub GetStandardJobForThisConcernToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GetStandardJobForThisConcernToolStripMenuItem.Click

        'Using GetStandardJobsQuery

        Dim xxFieldsSelect = " 
SELECT top 50 
WorkOrdersTable.WorkOrderID_AutoNumber,
WorkOrderConcernsTable.ConcernID_LongInteger, 
WorkOrderConcernJobsTable.InformationsHeaderID_LongInteger,
WorkOrderConcernJobStatusID_LongInteger ,
MasterCodeBookTable.SystemDesc_ShortText100Fld
FROM ((((WorkOrderConcernJobsTable LEFT JOIN WorkOrderConcernsTable ON WorkOrderConcernJobsTable.WorkOrderConcernID_LongInteger = WorkOrderConcernsTable.WorkOrderConcernID_AutoNumber) LEFT JOIN WorkOrdersTable ON WorkOrderConcernsTable.WorkOrderID_LongInteger = WorkOrdersTable.WorkOrderID_AutoNumber) LEFT JOIN InformationsHeadersTable ON WorkOrderConcernJobsTable.InformationsHeaderID_LongInteger = InformationsHeadersTable.InformationsHeaderID_AutoNumber) LEFT JOIN WorkOrderPartsTable ON WorkOrderConcernJobsTable.WorkOrderConcernJobID_AutoNumber = WorkOrderPartsTable.WorkOrderConcernJobID_LongInteger) LEFT JOIN MasterCodeBookTable ON WorkOrderPartsTable.MasterCodeBookID_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber
 "
        Dim xxSelectionFilter = " WHERE WorkOrderConcernsTable.ConcernID_LongInteger = " & CurrentConcernID
        Dim xxOrder = " ORDER BY ServiceDate_DateTime DESC"
        MySelection = xxFieldsSelect & xxSelectionFilter & xxOrder

        JustExecuteMySelection()
        Dim xxRecordCount = RecordCount
        WorkOrderConcernJobsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If xxRecordCount > 0 Then
            Dim JobList = ""
            Dim xxConcernJobStatusID = ""
            For i = 0 To xxRecordCount - 1
                Dim xxJobID = WorkOrderConcernJobsDataGridView.Item("InformationsHeaderID_LongInteger", i).Value
                If Not InStr(JobList, xxJobID) > 0 Then
                    JobList = JobList & "," & xxJobID
                    If IsEmpty(WorkOrderConcernJobsDataGridView.Item("SystemDesc_ShortText100Fld", i).Value) Then
                        xxConcernJobStatusID = GetStatusIdFor("WorkOrderConcernJobsTable", "No Part Needed")
                    Else
                        xxConcernJobStatusID = GetStatusIdFor("WorkOrderConcernJobsTable")
                    End If
                    MySelection = "INSERT INTO WorkOrderConcernJobsTable  ( " &
                                                                      "  WorkOrderConcernID_LongInteger, " &
                                                                     "  InformationsHeaderID_LongInteger, " &
                                                                     "  WorkOrderConcernJobStatusID_LongInteger " &
                                                                     "  ) " &
                                                              " VALUES ( " &
                                                                        Str(CurrentWorkOrderConcernID) & ",  " &
                                                                         xxJobID.ToString & ",  " &
                                                                         xxConcernJobStatusID.ToString &
                                                                      " ) "
                    JustExecuteMySelection()
                End If
            Next

        End If
        FillWorkOrderConcernJobsTable()

    End Sub
    Private Sub OutstandingWorkOrdersToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles OutstandingWorkOrdersToolStripMenuItem.Click
        DisplayOutstandingRecords()
    End Sub

    Private Sub AllWorkOrdersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllWorkOrdersToolStripMenuItem.Click
        Select Case CurrentUserGroup
            Case "Automotive Service Specialist"
                WorkOrderConcernJobsSelectionFilter = " WHERE WorkOrderConcernJobsTable.AssignedServiceSpecialist_LongInteger = " & CurrentPersonelID.ToString
                FillWorkOrderConcernJobsTable()
                Exit Sub
            Case "Assistant Service Manager"
                WorkOrdersSelectionFilter = ""
            Case "Lead Service Specialist"
                WorkOrdersSelectionFilter = " WHERE AssignedLeadMechanic_longInteger= " & CurrentPersonelID.ToString
            Case Else
                MsgBox("sTOP dEBUGGING, FIX THIS")
        End Select
        FillWorkOrdersDataGridView()
    End Sub
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

    Private Sub AssignJobToolStripMenuItemDeleteMe_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SubcontractJobToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SubcontractJobToolStripMenuItem.Click
        If MsgBox("Continue submit requisition to sub-contract the job?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        'CREATE A HEADER HERE
        Dim FieldsToUpdate = "
                            RequisitionDate_ShortDate, 
                            RequestedByID_LongInteger, 
                            RequisitionStatus_Integer 
                            "
        Dim FieldsData =
                            Chr(34) & DateString & Chr(34) & ", " &
                            CurrentPersonelID.ToString & "," &
                             GetStatusIdFor("RequisitionsTable").ToString

        Dim CurrentPartsRequisitionID = InsertNewRecord("RequisitionsTable", FieldsToUpdate, FieldsData)

        'CREATE A job reference here
        FieldsToUpdate = " RequisitionsID_LongInteger, 
                           InformationsHeaderID_LongInteger "
        FieldsData = CurrentPartsRequisitionID & ", " &
                     CurrentInformationsHeaderID.ToString

        Dim xxCurrentPartsRequisitionID = InsertNewRecord("JobsReferencesForRequisitionsTable", FieldsToUpdate, FieldsData)
    End Sub

End Class