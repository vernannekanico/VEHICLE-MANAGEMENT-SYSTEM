Public Class WorkOrderFormASS
    Private CurrentWorkOrderConcernJobsID As Integer = -1
    Private CurrentWorkOrderConcernJobsRow As Integer = -1
    Private WorkOrderConcernJobsRecordCount As Integer = -1

    Private CurrentWorkOrderConcernJobsNumber As String
    Private WorkOrderConcernJobsTable As New MyDbControls
    Private WorkOrderConcernJobsFieldsToSelect = ""
    Private WorkOrderConcernJobsTablesLinks = ""
    Private WorkOrderConcernJobselectionFilter = ""
    Private WorkOrderConcernJobselectionOrder = ""
    Private WorkOrderConcernJobsDataGridViewAlreadyFormated = False
    Private CurrentWorkOrderConcernJobID As Integer = -1

    Private WorkOrdersFieldsToSelect = ""
    Private WorkOrdersTableLinks = ""
    Private WorkOrdersSelectionFilter = ""
    Private WorkOrdersSelectionOrder = ""
    Private WorkOrdersRecordCount As Integer = -1
    Private CurrentWorkOrdersDataGridViewRow As Integer = -1
    Private WorkOrdersDataGridViewAlreadyFormated = False
    Private CurrentWorkOrdersRow As Integer = -1
    Private WorkOrderStatus = ""

    Private WorkOrderConcernsFieldsToSelect = ""
    Private WorkOrderConcernsTableLinks = ""
    Private WorkOrderConcernsSelectionFilter = ""
    Private WorkOrderConcernsSelectionOrder = ""
    Private WorkOrderConcernsRecordCount As Integer = -1
    Private CurrentWorkOrderConcernID As Integer = -1
    Private CurrentWorkOrderConcernsRow As Integer = -1
    Private WorkOrderConcernsDataGridViewAlreadyFormated = False
    Private WorkOrderConcernsDataGridViewLocationY As Integer

    Private WorkOrderPartsPerJobFieldsToSelect = " "
    Private WorkOrderPartsPerJobTablesLinks = "   "
    Private WorkOrderPartsPerJobSelectionFilter = " "
    Private WorkOrderPartsPerJobSelectionOrder = " "
    Private WorkOrderPartsPerJobRecordCount = 0
    Private CurrentWorkOrderPartsPerJobID As Integer = -1
    Private CurrentWorkOrderPartsPerJobRow = -1
    Private WorkOrderPartsPerJobDataGridViewAlreadyFormated = False

    Private AllWorkOrderPartsFieldsToSelect = " "
    Private AllWorkOrderPartsTablesLinks = "   "
    Private AllWorkOrderPartsSelectionFilter = " "
    Private AllWorkOrderPartsSelectionOrder = " "
    Private AllWorkOrderPartsRecordCount = 0
    Private CurrentAllWorkOrderPartsID As Integer = -1
    Private CurrentAllWorkOrderPartsRow = -1
    Private AllWorkOrderPartsDataGridViewAlreadyFormated = False
    Private SavedCallingForm As Form
    Private Sub WorkOrderFormASS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SavedCallingForm = CallingForm
        WorkOrdersSelectionFilter = " WHERE WorkOrderStatus_Byte = 4 "  '4	For assignment To Lead service Specialist, outstanding For ASS, SS
        ' updated when job(s) are done setting status to 5

        FillWorkOrdersDataGridViewSaved()
    End Sub
    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub

    Private Sub FillWorkOrdersDataGridViewSaved()
        Dim VehicleName = " (VehiclesTable.YearManufactured_ShortText4 & space(1) & Trim(VehicleTypeTable.VehicleType_ShortText20) & space(1) & trim(VehicleModelsTable.VehicleModel_ShortText20) & space(1) & trim(VehicleTrimTable.VehicleTrimName_ShortText25)),"
        Dim xxOnPreparation = "IIf(RequisitionTable.PartsStatus_Byte = 0, " & Chr(34) & " On Preparation " & Chr(34) & ","
        Dim xxRequestSubmitted = "IIf(RequisitionTable.PartsStatus_Byte = 1, " & Chr(34) & " Request Submitted " & Chr(34) & ","
        Dim xxRequestRevisionSubmited = "IIf(RequisitionTable.PartsStatus_Byte = 2, " & Chr(34) & " Request Revision Submited " & Chr(34) & ","
        Dim xxPartiallyReceived = "IIf(RequisitionTable.PartsStatus_Byte = 3, " & Chr(34) & " Partially Received " & Chr(34) & ","
        Dim xxFullyReceived = "IIf(RequisitionTable.PartsStatus_Byte = 4, " & Chr(34) & " Fully Received " & Chr(34) & ","
        Dim xxPartsStatus = xxOnPreparation & xxRequestSubmitted & xxRequestRevisionSubmited & xxPartiallyReceived & xxFullyReceived & Chr(34) & Chr(34) & " ))))) "

        WorkOrdersFieldsToSelect = "Select 
WorkOrdersTable.WorkOrderID_Autonumber,
WorkOrdersTable.WorkOrderNumber_ShortText12,
ServiceDate_DateTime,
WorkOrdersTable.ServiceDate_DateTime,
WorkOrdersTable.WorkOrderStatus_Byte, 
" & VehicleName & xxPartsStatus & "
, OriginalExcelRecordTable.description 
"
        WorkOrdersTableLinks = " From RequisitionTable 
RIGHT Join ((((((((WorkOrdersTable 
LEFT Join ServicedVehiclesTable On WorkOrdersTable.ServicedVehicleID_LongInteger = ServicedVehiclesTable.ServicedVehicleID_AutoNumber) 
LEFT Join OwnersTable On ServicedVehiclesTable.OwnerID_LongInteger = OwnersTable.OwnerID_AutoNumber) 
LEFT Join CityTable On OwnersTable.CityID_LongInteger = CityTable.CityID_AutoNumber) 
LEFT Join (VehiclesTable 
LEFT Join VehicleModelsRelationsTable On VehiclesTable.[VehicleModelsRelationID_LongInteger] = VehicleModelsRelationsTable.[VehicleModelsRelationID_Autonumber]) ON ServicedVehiclesTable.VehicleID_LongInteger = VehiclesTable.VehicleID_AutoNumber) 
LEFT Join VehicleTypeTable On VehicleModelsRelationsTable.VehicleTypeID_LongInteger = VehicleTypeTable.VehicleTypeID_AutoNumber) 
LEFT Join VehicleTrimTable On VehicleModelsRelationsTable.VehicleTrimID_LongInteger = VehicleTrimTable.VehicleTrimID_Autonumber) 
LEFT Join VehicleModelsTable On VehicleModelsRelationsTable.VehicleModelID_LongInteger = VehicleModelsTable.VehicleModelID_Autonumber) 
LEFT Join OriginalExcelRecordTable On WorkOrdersTable.OriginalID_LongInteger = OriginalExcelRecordTable.OriginalID_AutoNumber) ON RequisitionTable.WorkOrderID_LongInteger = WorkOrdersTable.WorkOrderID_AutoNumber "

        WorkOrdersSelectionOrder = " ORDER BY WorkOrdersTable.WorkOrderNumber_ShortText12 "

        MySelection = WorkOrdersFieldsToSelect & WorkOrdersTableLinks & WorkOrdersSelectionFilter & WorkOrdersSelectionOrder

        JustExecuteMySelection()
        WorkOrdersDataGridViewSaved.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        WorkOrdersRecordCount = RecordCount
        If Not WorkOrdersDataGridViewAlreadyFormated Then FormatWorkOrdersDataGridViewSaved()


        Dim NoOfHeaderLines = 1
        Dim RecordsDisplyed = WorkOrdersRecordCount
        Dim FormLowPointFromGrid = 90
        If WorkOrdersRecordCount > 27 Then
            RecordsDisplyed = 27
        Else
            RecordsDisplyed = WorkOrdersRecordCount
        End If

        WorkOrdersDataGridViewSaved.Height = (WorkOrdersDataGridViewSaved.ColumnHeadersHeight * NoOfHeaderLines * 2) + (DataGridViewRowHeight * (RecordsDisplyed + 1))

        Dim HeightToAdd = IIf(WorkOrdersRecordCount = 0, 0, ((WorkOrdersRecordCount) * DataGridViewRowHeight))
        WorkOrdersDataGridViewSaved.Height = WorkOrdersDataGridViewSaved.ColumnHeadersHeight + HeightToAdd + 20

        Me.Location = New Point(Me.Location.X, 55)
        Me.Left = (VehicleManagementSystemForm.Width - Me.Width) / 2
        WorkOrdersDataGridViewSaved.Left = (Me.Width - WorkOrdersDataGridViewSaved.Width) / 2
        WorkOrderConcernJobsDataGridView.Left = (Me.Width - WorkOrderConcernJobsDataGridView.Width) / 2
        WorkOrderConcernsDataGridView.Left = (Me.Width - WorkOrderConcernsDataGridView.Width) / 2

        WorkOrdersDataGridViewSaved.Top = 30

        WorkOrderConcernsDataGridView.Top = WorkOrdersDataGridViewSaved.Top + WorkOrdersDataGridViewSaved.Height - 5

        WorkOrderConcernJobsDataGridView.Top = WorkOrderConcernsDataGridView.Top + WorkOrderConcernsDataGridView.Height - 5

    End Sub
    Private Sub FormatWorkOrdersDataGridViewSaved()
        WorkOrdersDataGridViewAlreadyFormated = True
        WorkOrdersDataGridViewSaved.Width = 0
        For i = 0 To WorkOrdersDataGridViewSaved.Columns.GetColumnCount(0) - 1

            WorkOrdersDataGridViewSaved.Columns.Item(i).Visible = False

            Select Case WorkOrdersDataGridViewSaved.Columns.Item(i).Name
                Case "WorkOrderNumber_ShortText12"
                    WorkOrdersDataGridViewSaved.Columns.Item(i).HeaderText = "Work Order"
                    WorkOrdersDataGridViewSaved.Columns.Item(i).Width = 150
                    WorkOrdersDataGridViewSaved.Columns.Item(i).Visible = True
                Case "WorkOrdersTable.ServiceDate_DateTime"
                    WorkOrdersDataGridViewSaved.Columns.Item(i).HeaderText = ""
                    WorkOrdersDataGridViewSaved.Columns.Item(i).Width = 100
                    WorkOrdersDataGridViewSaved.Columns.Item(i).Visible = True
                Case "Expr1005"
                    WorkOrdersDataGridViewSaved.Columns.Item(i).HeaderText = "Vehicle"
                    WorkOrdersDataGridViewSaved.Columns.Item(i).Width = 300
                    WorkOrdersDataGridViewSaved.Columns.Item(i).Visible = True
                Case "Expr1006"
                    WorkOrdersDataGridViewSaved.Columns.Item(i).HeaderText = "Parts Status"
                    WorkOrdersDataGridViewSaved.Columns.Item(i).Width = 200
                    WorkOrdersDataGridViewSaved.Columns.Item(i).Visible = True
                Case "description"
                    WorkOrdersDataGridViewSaved.Columns.Item(i).HeaderText = "original"
                    WorkOrdersDataGridViewSaved.Columns.Item(i).Width = 300
                    WorkOrdersDataGridViewSaved.Columns.Item(i).Visible = True
            End Select

            If WorkOrdersDataGridViewSaved.Columns.Item(i).Visible = True Then
                WorkOrdersDataGridViewSaved.Width = WorkOrdersDataGridViewSaved.Width + WorkOrdersDataGridViewSaved.Columns.Item(i).Width
            End If
        Next

        If WorkOrdersDataGridViewSaved.Width > VehicleManagementSystemForm.Width Or
           WorkOrderConcernJobsDataGridView.Width > VehicleManagementSystemForm.Width Or
           WorkOrderConcernsDataGridView.Width > VehicleManagementSystemForm.Width Then
            Me.Width = WorkOrderConcernJobsDataGridView.Width + 20
        Else
            Me.Width = 0
            If WorkOrdersDataGridViewSaved.Width > Me.Width Then Me.Width = WorkOrdersDataGridViewSaved.Width
            If WorkOrderConcernJobsDataGridView.Width > Me.Width Then Me.Width = WorkOrderConcernJobsDataGridView.Width
            If WorkOrderConcernsDataGridView.Width > Me.Width Then Me.Width = WorkOrderConcernsDataGridView.Width

            Me.Width = Me.Width + 20

        End If

    End Sub
    Private Sub WorkOrdersDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles WorkOrdersDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub

        If e.RowIndex < 0 Then Exit Sub
        If WorkOrdersRecordCount = 0 Then Exit Sub

        CurrentWorkOrdersRow = e.RowIndex
        CurrentWorkOrderID = WorkOrdersDataGridView.Item("WorkOrderID_AutoNumber", CurrentWorkOrdersRow).Value
        SetVehicleInformations()
        FillWorkOrderConcernsDataGridView()
        Dim YRelativeLocation = CurrentWorkOrdersRow
        While Not YRelativeLocation < 15
            YRelativeLocation = YRelativeLocation / 15
        End While
        WorkOrderConcernsDataGridViewLocationY = WorkOrdersDataGridView.Location.Y + ((YRelativeLocation * DataGridViewRowHeight) + (DataGridViewRowHeight * 3))
        If WorkOrderConcernsDataGridViewLocationY < 120 Then WorkOrderConcernsDataGridViewLocationY = 120
        WorkOrderConcernsDataGridView.Left = (Me.Width - WorkOrderConcernsDataGridView.Width) / 2
        WorkOrderConcernsDataGridView.Location = New Point(WorkOrderConcernsDataGridView.Left, WorkOrderConcernsDataGridViewLocationY + 50)

        AllWorkOrderPartsSelectionFilter = " WHERE WorkOrderID_LongInteger = " & CurrentWorkOrderID.ToString
        FillAllPartsPerJobDataGridView()
    End Sub

    Private Sub WorkOrdersDataGridViewSaved_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles WorkOrdersDataGridViewSaved.RowEnter
        If e.RowIndex < 0 Or WorkOrdersRecordCount < 1 Then Exit Sub

        CurrentWorkOrdersDataGridViewRow = e.RowIndex

        CurrentWorkOrderID = WorkOrdersDataGridViewSaved.Item("WorkOrderID_Autonumber", CurrentWorkOrdersDataGridViewRow).Value
        SetVehicleInformations()
        FillWorkOrderConcernsDataGridView()

    End Sub
    Private Sub FillWorkOrderConcernJobsDataGridView()
        'USING WorkOrderConcernJobsQueryForASS

        Dim ActionToTake = " IIf( not ConcernAsIsByClientTable.LongTextConcern_LongText = " & Chr(34) & Chr(34) & ",  " &
                                       Chr(34) & " Diagnose " & Chr(34) & ",  " &
                                         " InformationsHeadersTypeTable.InformationsHeadersTypePrefix_ShortText50 " & ") "

        Dim ConcernDescription = " IIf( not ConcernAsIsByClientTable.LongTextConcern_LongText = " & Chr(34) & Chr(34) & ",  " &
                                       " ConcernAsIsByClientTable.LongTextConcern_LongText, " &
                                        " MasterCodeBookTable_1.SystemDesc_ShortText100Fld) AS ConcernDescription, "

        ConcernDescription = ActionToTake & " & Space(1) & " & ConcernDescription

        WorkOrderConcernJobselectionOrder = " ORDER BY WorkOrderConcernJobID_AutoNumber, WorkOrderConcernID_LongInteger "

        Dim JobDescription = " trim(InformationsHeadersTypeTable.InformationsHeadersTypePrefix_ShortText50,) " &
                                              " & space(1) & MasterCodeBookTable.SystemDesc_ShortText100Fld AS Job, "

        Dim xxOnPreparation = "IIf(RequisitionTable.PartsStatus_Byte = 0, " & Chr(34) & " On Preparation " & Chr(34) & ","
        Dim xxRequestSubmitted = "IIf(RequisitionTable.PartsStatus_Byte = 1, " & Chr(34) & " Request Submitted " & Chr(34) & ","
        Dim xxRequestRevisionSubmited = "IIf(RequisitionTable.PartsStatus_Byte = 2, " & Chr(34) & " Request Revision Submited " & Chr(34) & ","
        Dim xxPartiallyReceived = "IIf(RequisitionTable.PartsStatus_Byte = 3, " & Chr(34) & " Partially Received " & Chr(34) & ","
        Dim xxFullyReceived = "IIf(RequisitionTable.PartsStatus_Byte = 4, " & Chr(34) & " Fully Received " & Chr(34) & ","
        '      Dim xxPartsStatus = xxOnPreparation & xxRequestSubmitted & xxRequestRevisionSubmited & xxPartiallyReceived & xxFullyReceived & Chr(34) & Chr(34) & " )))), "
        Dim PartStatus = xxOnPreparation & xxRequestSubmitted & xxRequestRevisionSubmited & xxPartiallyReceived & xxFullyReceived & Chr(34) & Chr(34) & " ))))) AS PartStatus "


        WorkOrderConcernJobsFieldsToSelect = " Select " &
        " WorkOrderConcernJobsTable.WorkOrderConcernJobID_AutoNumber, " &
        " WorkOrderConcernsTable.WorkOrderID_LongInteger, " &
        " WorkOrdersTable.WorkOrderNumber_ShortText12, " &
                                        ConcernDescription & JobDescription &
        " ConcernAsIsByClientTable.LongTextConcern_LongText, " &
        " InformationsHeadersTypeTable.InformationsHeadersTypePrefix_ShortText50,  " &
        " MasterCodeBookTable_1.SystemDesc_ShortText100Fld,  " &
        " WorkOrdersTable.AssignedLeadMechanic_longInteger,  " &
        " ConcernAsIsByClientTable.LongTextConcern_LongText,  " &
        " InformationsHeadersTypeTable.InformationsHeadersTypePrefix_ShortText50,  " &
        "  MasterCodeBookTable_1.SystemDesc_ShortText100Fld,  " &
        "  WorkOrderConcernJobsTable.WorkOrderConcernJobStatus_Byte,  " & PartStatus
        '       "  RequisitionTable.PartsStatus_Byte "

        WorkOrderConcernJobsTablesLinks = " FROM ((RequisitionTable RIGHT JOIN ((((((WorkOrderConcernJobsTable LEFT JOIN WorkOrderConcernsTable ON WorkOrderConcernJobsTable.WorkOrderConcernID_LongInteger = WorkOrderConcernsTable.WorkOrderConcernID_AutoNumber) LEFT JOIN WorkOrdersTable ON WorkOrderConcernsTable.WorkOrderID_LongInteger = WorkOrdersTable.WorkOrderID_AutoNumber) LEFT JOIN ConcernsTable ON WorkOrderConcernsTable.ConcernID_LongInteger = ConcernsTable.ConcernID_AutoNumber) LEFT JOIN ConcernAsIsByClientTable ON WorkOrderConcernsTable.ConcernLongTextCodeID_LongInteger = ConcernAsIsByClientTable.LongTextConcernID_Autonumber) LEFT JOIN JobsTableRepLACED ON WorkOrderConcernJobsTable.[InformationsHeaderID_LongInteger] = JobsTableRepLACED.JobID_AutoNumber) LEFT JOIN MasterCodeBookTable AS MasterCodeBookTable_1 ON ConcernsTable.MasterCodeBookId_LongInteger = MasterCodeBookTable_1.MasterCodeBookID_Autonumber) ON RequisitionTable.WorkOrderID_LongInteger = WorkOrdersTable.WorkOrderID_AutoNumber) LEFT JOIN InformationsHeadersTypeTable ON WorkOrderConcernJobsTable.InformationsHeaderID_LongInteger = InformationsHeadersTypeTable.InformationsHeadersTypeID_AutoNumber) LEFT JOIN MasterCodeBookTable ON JobsTableRepLACED.MasterCodeBookId_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber "

        WorkOrderConcernJobselectionFilter = " WHERE WorkOrderConcernJobsTable.AssignedServiceSpecialist_LongInteger = " & CurrentPersonelID.ToString &
                                        " AND WorkOrderConcernID_LongInteger = " & CurrentWorkOrderConcernID.ToString & Space(1) &
                                        " AND WorkOrderConcernsTable.WorkOrderID_LongInteger = " & CurrentWorkOrderID.ToString & Space(1)

        MySelection = WorkOrderConcernJobsFieldsToSelect & WorkOrderConcernJobsTablesLinks & WorkOrderConcernJobselectionFilter & WorkOrderConcernJobselectionOrder

        JustExecuteMySelection()
        WorkOrderConcernJobsRecordCount = RecordCount

        WorkOrderConcernJobsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        FormatWorkOrderConcernJobsDataGridView()

        Dim NoOfHeaderLines = 1
        Dim RecordsDisplyed = WorkOrderConcernJobsRecordCount
        Dim FormLowPointFromGrid = 90
        If WorkOrderConcernJobsRecordCount > 27 Then
            RecordsDisplyed = 27
        Else
            RecordsDisplyed = WorkOrderConcernJobsRecordCount
        End If

        WorkOrderConcernJobsDataGridView.Height = (WorkOrderConcernJobsDataGridView.ColumnHeadersHeight * NoOfHeaderLines * 2) + (DataGridViewRowHeight * (RecordsDisplyed + 1))

        Dim HeightToAdd = IIf(WorkOrderConcernJobsRecordCount = 0, 0, ((WorkOrderConcernJobsRecordCount) * DataGridViewRowHeight))
        WorkOrderConcernJobsDataGridView.Height = WorkOrderConcernJobsDataGridView.ColumnHeadersHeight + HeightToAdd + 50

    End Sub
    Private Sub FormatWorkOrderConcernJobsDataGridView()
        WorkOrderConcernJobsDataGridView.Width = 0
        For i = 0 To WorkOrderConcernJobsDataGridView.Columns.GetColumnCount(0) - 1

            WorkOrderConcernJobsDataGridView.Columns.Item(i).Visible = False
            Select Case WorkOrderConcernJobsDataGridView.Columns.Item(i).Name
                Case "ConcernDescription"
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).HeaderText = "CONCERN"
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).Width = 300
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).Visible = True
                Case "Job"
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).HeaderText = "JOBS"
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).Width = 300
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).Visible = True
                Case "WorkOrderConcernJobStatus_Byte"
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).HeaderText = "Job STATUS"
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).Width = 80
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).Visible = True
                Case "PartStatus"
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).HeaderText = "Part Status"
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).Width = 150
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).Visible = True

            End Select

            If WorkOrderConcernJobsDataGridView.Columns.Item(i).Visible = True Then
                WorkOrderConcernJobsDataGridView.Width = WorkOrderConcernJobsDataGridView.Width + WorkOrderConcernJobsDataGridView.Columns.Item(i).Width
            End If
        Next

    End Sub


    Private Sub ProcessJobToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProcessJobToolStripMenuItem.Click
        SetVehicleInformations()
        Tunnel2 = WorkOrderConcernJobsDataGridView.Item("SubSystemCode_ShortText24Fld", CurrentWorkOrderConcernJobsRow).Value
        ShowMasterCodeBookForm()
    End Sub
    Private Sub ShowMasterCodeBookForm()
        ShowCalledForm(Me, MasterCodeBookForm)
    End Sub

    Private Sub WorkOrderConcernJobsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles WorkOrderConcernJobsDataGridView.RowEnter
        WorkOrderConcernJobsDataGridView.Visible = False
        If Me.Enabled = False Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If RecordCount = 0 Then Exit Sub
        WorkOrderConcernJobsDataGridView.Visible = True
        CurrentWorkOrderConcernJobsRow = e.RowIndex

        CurrentWorkOrderConcernJobsID = WorkOrderConcernJobsDataGridView.Item("WorkOrderConcernJobID_AutoNumber", CurrentWorkOrderConcernJobsRow).Value
        RemoveConcernJobToolStripMenuItem.Visible = True
        RemoveConcernJobToolStripMenuItem.Visible = False
        If e.RowIndex < 0 Then Exit Sub
        If WorkOrderConcernJobsRecordCount = 0 Then Exit Sub
        RemoveConcernJobToolStripMenuItem.Visible = True

        CurrentWorkOrderConcernJobsRow = e.RowIndex

        CurrentWorkOrderConcernJobID = WorkOrderConcernJobsDataGridView.Item("WorkOrderConcernJobID_AutoNumber", CurrentWorkOrderConcernJobsRow).Value

        WorkOrderPartsPerJobSelectionFilter = " WHERE WorkOrderID_LongInteger = " & CurrentWorkOrderID.ToString &
                                                     " And InformationsHeaderID_LongInteger = " & CurrentWorkOrderConcernJobID.ToString
        FillWorkOrderPartsPerJobDataGridView()
        If CurrentUserGroup = "Lead Service Specialist" Then
            If WorkOrderConcernJobsRecordCount = 0 Then
                RemoveConcernJobToolStripMenuItem.Visible = True
            End If
        End If



    End Sub
    Private Sub FillWorkOrderConcernsDataGridView()
        'NOTE IF MasterCodeBookTable.SystemDesc_ShortText100Fld IS EMPTY IT MEANS 
        ' ConcernAsIsByClientTable.LongTextConcern_LongText

        Dim ActionToTake = " IIf( not ConcernAsIsByClientTable.LongTextConcern_LongText = " & Chr(34) & Chr(34) & ",  " &
                                       Chr(34) & " Diagnose " & Chr(34) & ",  " &
                                         " InformationsHeadersTypeTable.InformationsHeadersTypePrefix_ShortText50, " & ") "

        Dim ConcernDescription = " IIf( not ConcernAsIsByClientTable.LongTextConcern_LongText = " & Chr(34) & Chr(34) & ",  " &
                                       " ConcernAsIsByClientTable.LongTextConcern_LongText, " &
                                        " MasterCodeBookTable.SystemDesc_ShortText100Fld) AS ConcernDescription, "

        ConcernDescription = ActionToTake & " & Space(1) & " & ConcernDescription

        WorkOrderConcernsFieldsToSelect = " Select " &
                                          " WorkOrderConcernsTable.WorkOrderConcernID_AutoNumber, " &
                                          " WorkOrderConcernsTable.WorkOrderID_LongInteger, " &
                                          " WorkOrderConcernsTable.ConcernID_LongInteger, " &
                                          " WorkOrderConcernsTable.ConcernLongTextCodeID_LongInteger, " &
                                          " ConcernsTable.InformationsHeadersTypeID_LongInteger, " &
                                          " ConcernsTable.Concern_ShortText255, " &
                                          " InformationsHeadersTypeTable.InformationsHeadersTypePrefix_ShortText50, " &
                                           ConcernDescription &
                                          " MasterCodeBookTable.SystemDesc_ShortText100Fld, " &
                                          " LongTextConcern_LongText, " &
                                          " OriginalExcelRecordTable.description "

        WorkOrderConcernsTableLinks = " 
FROM ((((WorkOrderConcernsTable 
LEFT JOIN ConcernsTable ON WorkOrderConcernsTable.ConcernID_LongInteger = ConcernsTable.ConcernID_AutoNumber) 
LEFT JOIN InformationsHeadersTypeTable ON ConcernsTable.InformationsHeadersTypeID_LongInteger = InformationsHeadersTypeTable.InformationsHeadersTypeID_AutoNumber) 
LEFT JOIN MasterCodeBookTable ON ConcernsTable.MasterCodeBookId_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) 
LEFT JOIN ConcernAsIsByClientTable ON WorkOrderConcernsTable.ConcernLongTextCodeID_LongInteger = ConcernAsIsByClientTable.LongTextConcernID_Autonumber) 
LEFT JOIN OriginalExcelRecordTable ON WorkOrderConcernsTable.OriginalID_LongInteger = OriginalExcelRecordTable.OriginalID_AutoNumber 
"
        WorkOrderConcernsSelectionFilter = " WHERE WorkOrderConcernsTable.WorkOrderID_LongInteger = " & Str(CurrentWorkOrderID)
        WorkOrderConcernsSelectionOrder = ""

        MySelection = WorkOrderConcernsFieldsToSelect & WorkOrderConcernsTableLinks & WorkOrderConcernsSelectionFilter & WorkOrderConcernsSelectionOrder

        JustExecuteMySelection()

        WorkOrderConcernsRecordCount = RecordCount
        WorkOrderConcernsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable


        If Not WorkOrderConcernsDataGridViewAlreadyFormated Then
            WorkOrderConcernsDataGridViewAlreadyFormated = True
            FormatWorkOrderConcernsDataGridView()
        End If

        Dim NoOfHeaderLines = 1
        Dim RecordsDisplyed = WorkOrderConcernsRecordCount
        Dim FormLowPointFromGrid = 90
        If WorkOrderConcernsRecordCount > 27 Then
            RecordsDisplyed = 27
        Else
            RecordsDisplyed = WorkOrderConcernsRecordCount
        End If

        WorkOrderConcernsDataGridView.Height = (WorkOrderConcernsDataGridView.ColumnHeadersHeight * NoOfHeaderLines * 2) + (DataGridViewRowHeight * (RecordsDisplyed + 1))
        Dim HeightToAdd = IIf(WorkOrderConcernsRecordCount = 0, 0, ((WorkOrderConcernsRecordCount) * DataGridViewRowHeight))
        WorkOrderConcernsDataGridView.Height = WorkOrderConcernsDataGridView.ColumnHeadersHeight + HeightToAdd + 50

        WorkOrderConcernJobsDataGridView.Top = WorkOrderConcernsDataGridView.Top + WorkOrderConcernsDataGridView.Height - 5

    End Sub


    Private Sub FormatWorkOrderConcernsDataGridView()
        Dim HeightToAdd = IIf(WorkOrderConcernsRecordCount = 0, 0, ((WorkOrderConcernsRecordCount) * DataGridViewRowHeight))
        WorkOrderConcernsDataGridView.Height = WorkOrderConcernsDataGridView.ColumnHeadersHeight + HeightToAdd + 100

        WorkOrderConcernsDataGridView.Width = 0

        For i = 0 To WorkOrderConcernsDataGridView.Columns.GetColumnCount(0) - 1

            WorkOrderConcernsDataGridView.Columns.Item(i).Visible = False

            Select Case WorkOrderConcernsDataGridView.Columns.Item(i).Name
                Case "ConcernDescription"
                    WorkOrderConcernsDataGridView.Columns.Item(i).HeaderText = "CONCERN"
                    WorkOrderConcernsDataGridView.Columns.Item(i).Width = 500
                    WorkOrderConcernsDataGridView.Columns.Item(i).Visible = True
                Case "Concern_ShortText255"
                    WorkOrderConcernsDataGridView.Columns.Item(i).HeaderText = "ConcernsTable"
                    WorkOrderConcernsDataGridView.Columns.Item(i).Width = 400
                    WorkOrderConcernsDataGridView.Columns.Item(i).Visible = True
                Case "description"
                    WorkOrderConcernsDataGridView.Columns.Item(i).HeaderText = "original (excel)"
                    WorkOrderConcernsDataGridView.Columns.Item(i).Width = 400
                    WorkOrderConcernsDataGridView.Columns.Item(i).Visible = True
            End Select
            If WorkOrderConcernsDataGridView.Columns.Item(i).Visible = True Then
                WorkOrderConcernsDataGridView.Width = WorkOrderConcernsDataGridView.Width + WorkOrderConcernsDataGridView.Columns.Item(i).Width
            End If
        Next

    End Sub
    Private Sub WorkOrderConcernsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles WorkOrderConcernsDataGridView.RowEnter
        WorkOrderConcernsDataGridView.Visible = False
        If e.RowIndex < 0 Then Exit Sub
        If WorkOrderConcernsRecordCount = 0 Then Exit Sub
        WorkOrderConcernsDataGridView.Visible = True
        CurrentWorkOrderConcernsRow = e.RowIndex

        CurrentWorkOrderConcernID = WorkOrderConcernsDataGridView.Item("WorkOrderConcernID_Autonumber", CurrentWorkOrderConcernsRow).Value
        FillWorkOrderConcernJobsDataGridView()

    End Sub
    Private Sub FillWorkOrderPartsPerJobDataGridView()

        WorkOrderPartsPerJobFieldsToSelect = "Select " &
                                               " WorkOrderPartsTable.WorkOrderID_LongInteger, " &
                                               " WorkOrderPartsTable.InformationsHeaderID_LongInteger, " &
                                               " WorkOrderPartsTable.ProductPartID_LongInteger, " &
                                               " ProductsPartsTable.ManufacturerPartNo_ShortText30Fld, " &
                                               " ProductsPartsTable.ProductDescription_ShortText250 "

        WorkOrderPartsPerJobTablesLinks = " From WorkOrderPartsTable LEFT Join ProductsPartsTable " &
                                               " On WorkOrderPartsTable.ProductPartID_LongInteger = ProductsPartsTable.ProductsPartID_Autonumber "

        WorkOrderPartsPerJobSelectionOrder = " ORDER BY ProductDescription_ShortText250"

        MySelection = WorkOrderPartsPerJobFieldsToSelect & WorkOrderPartsPerJobTablesLinks & WorkOrderPartsPerJobSelectionFilter & WorkOrderPartsPerJobSelectionOrder

        WorkOrderPartsPerJobDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        If Not WorkOrderPartsPerJobDataGridViewAlreadyFormated Then
            WorkOrderPartsPerJobDataGridViewAlreadyFormated = True
            FormatWorkOrderPartsPerJobDataGridView()
        End If
    End Sub

    Private Sub FormatWorkOrderPartsPerJobDataGridView()
        WorkOrderPartsPerJobDataGridView.Width = 0
        For i = 0 To WorkOrderPartsPerJobDataGridView.Columns.GetColumnCount(0) - 1

            Dim DoNotDisplayFields = "WorkOrderPartsTable.InformationsHeaderID_LongInteger, " &
                                         " WorkOrderPartsTable.ProductPartID_LongInteger, "

            If InStr(DoNotDisplayFields, WorkOrderPartsPerJobDataGridView.Columns.Item(i).HeaderText) > 0 Then
                WorkOrderPartsPerJobDataGridView.Columns.Item(i).Visible = False
            End If

            Select Case WorkOrderPartsPerJobDataGridView.Columns.Item(i).HeaderText
                Case "ManufacturerPartNo_ShortText30Fld"
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).Width = 120
                Case "ProductDescription_ShortText250"
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).HeaderText = "WORK ORDER No."
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).Width = 500
            End Select

            If WorkOrderPartsPerJobDataGridView.Columns.Item(i).Visible = True Then
                WorkOrderPartsPerJobDataGridView.Width = WorkOrderPartsPerJobDataGridView.Width + WorkOrderPartsPerJobDataGridView.Columns.Item(i).Width
            End If
        Next
        If WorkOrderPartsPerJobDataGridView.Width > Me.Width Then
            WorkOrderPartsPerJobDataGridView.Width = Me.Width - 100
        Else
            WorkOrderPartsPerJobDataGridView.Width = WorkOrderPartsPerJobDataGridView.Width + 20
        End If
        WorkOrderPartsPerJobDataGridView.Left = (Me.Width - WorkOrderPartsPerJobDataGridView.Width) / 2

    End Sub

    Private Sub WorkOrderPartsPerJobDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles WorkOrderPartsPerJobDataGridView.RowEnter
        If e.RowIndex < 0 Then Exit Sub
        If WorkOrderPartsPerJobRecordCount = 0 Then Exit Sub
        WorkOrderPartsPerJobDataGridView.Visible = True
        CurrentWorkOrderPartsPerJobRow = e.RowIndex



        CurrentWorkOrderPartsPerJobID = WorkOrderConcernsDataGridView.Item("WorkOrderID_LongInteger", CurrentWorkOrderConcernsRow).Value

    End Sub
    Private Sub FillAllPartsPerJobDataGridView()

        AllWorkOrderPartsFieldsToSelect = "Select " &
                                         " WorkOrderPartsTable.WorkOrderID_LongInteger, " &
                                         " WorkOrderPartsTable.InformationsHeaderID_LongInteger, " &
                                         " WorkOrderPartsTable.ProductPartID_LongInteger, " &
                                         " ProductsPartsTable.ManufacturerPartNo_ShortText30Fld, " &
                                         " ProductsPartsTable.ProductDescription_ShortText250 "

        AllWorkOrderPartsTablesLinks = " From WorkOrderPartsTable LEFT Join ProductsPartsTable  " &
                                             " On WorkOrderPartsTable.ProductPartID_LongInteger = ProductsPartsTable.ProductsPartID_Autonumber "
        AllWorkOrderPartsSelectionOrder = " ORDER BY ProductDescription_ShortText250 "

        MySelection = AllWorkOrderPartsFieldsToSelect & AllWorkOrderPartsTablesLinks & AllWorkOrderPartsSelectionFilter & AllWorkOrderPartsSelectionOrder

        JustExecuteMySelection()
        AllWorkOrderPartsRecordCount = RecordCount

        AllWorkOrderPartsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If Not AllWorkOrderPartsDataGridViewAlreadyFormated Then
            AllWorkOrderPartsDataGridViewAlreadyFormated = True
            FormatAllWorkOrderPartsDataGridView()
        End If
    End Sub
    Private Sub FormatAllWorkOrderPartsDataGridView()
        AllWorkOrderPartsDataGridView.Width = 0
        For i = 0 To AllWorkOrderPartsDataGridView.Columns.GetColumnCount(0) - 1

            Dim DoNotDisplayFields = "WorkOrderID_LongInteger, " &
                                     " InformationsHeaderID_LongInteger, " &
                                     " ProductPartID_LongInteger, "

            If InStr(DoNotDisplayFields, AllWorkOrderPartsDataGridView.Columns.Item(i).HeaderText) > 0 Then
                AllWorkOrderPartsDataGridView.Columns.Item(i).Visible = False
            End If

            Select Case AllWorkOrderPartsDataGridView.Columns.Item(i).HeaderText
                Case "ManufacturerPartNo_ShortText30Fld"
                    AllWorkOrderPartsDataGridView.Columns.Item(i).Width = 120
                Case "ProductDescription_ShortText250"
                    AllWorkOrderPartsDataGridView.Columns.Item(i).Width = 500
            End Select

            If AllWorkOrderPartsDataGridView.Columns.Item(i).Visible = True Then
                AllWorkOrderPartsDataGridView.Width = AllWorkOrderPartsDataGridView.Width + AllWorkOrderPartsDataGridView.Columns.Item(i).Width
            End If
        Next

        ' NOTE" SYSTEM AUTOFITS THE GRIDVIEW FIELDS ACCORDING TO THEIR WITDH

        If AllWorkOrderPartsDataGridView.Width > Me.Width + 20 Then
            AllWorkOrderPartsDataGridView.Width = Me.Width - 80
        Else
            AllWorkOrderPartsDataGridView.Width = AllWorkOrderPartsDataGridView.Width + 20
            Dim LargestWidth = AllWorkOrderPartsDataGridView.Width
        End If
        ' NOTE IF YOU WANT TO CENTER THE GRIDVIEW
        '       AllWorkOrderPartsDataGridView.Left = (Me.Width - AllWorkOrderPartsDataGridView.Width) / 2
    End Sub

    Private Sub AllWorkOrderPartsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles AllWorkOrderPartsDataGridView.RowEnter
        AllWorkOrderPartsDataGridView.Visible = False
        If e.RowIndex < 0 Then Exit Sub
        If AllWorkOrderPartsRecordCount = 0 Then Exit Sub
        AllWorkOrderPartsDataGridView.Visible = True
        CurrentAllWorkOrderPartsRow = e.RowIndex

        CurrentAllWorkOrderPartsID = AllWorkOrderPartsDataGridView.Item("WorkOrderID_LongInteger", CurrentAllWorkOrderPartsRow).Value
    End Sub

    Private Sub RequestForPartsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WarehouseRequestForPartsToolStripMenuItem.Click
        If WorkOrdersDataGridViewSaved.Item("Expr1006", CurrentWorkOrdersDataGridViewRow).Value = " Request Submitted " Then
            If MsgBox("Parts Requested already submitted, Would you like to revise", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        End If
        RequestPartsForm.WorkOrderNumberTextBox.Text = WorkOrderConcernJobsDataGridView.Item("WorkOrderNumber_ShortText12", CurrentWorkOrderConcernJobsRow).Value
        RequestPartsForm.ActivatedByTextBox.Text = Me.Name
        Me.Enabled = False
        Me.Hide()
        RequestPartsForm.Show()
    End Sub

End Class