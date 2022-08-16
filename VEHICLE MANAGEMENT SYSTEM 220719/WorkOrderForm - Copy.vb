Public Class WorkOrderForm
    Private CurrentWorkOrderID As Integer = -1
    Private CurrentWorkOrderRow As Integer = -1
    Private WorkOrdersRecordCount As Integer = -1

    Private CurrentWorkOrderNumber As String

    Private CurrentConcernID As Integer = -1

    Private CurrentWorkOrderConcernID As Integer = -1
    Private CurrentWorkOrderConcernsRow As Integer
    Private WorkOrderConcernsRecordCount As Integer = -1

    Private CurrentCustomerID As Integer = -1
    Private CurrentVehicleServicedID As Integer = -1

    Private CurrentWorkOrderStatus As Integer

    Private AssignedPersonnelID As Integer

    Private WorkOrderTable As New MyDbControls
    Private WorkOrderDataGridViewInitialized = False
    Private WorkOrderConcernsDataGridViewInitialized = False
    Private WorkOrderFieldsToSelect = ""
    Private WorkOrderTablesLinks = ""
    Private WorkOrderSelectionFilter = ""
    Private WorkOrderSelectionOrder = ""

    Private WorkOrderStatusSelection As Integer = 1

    Private WorkOrderConcernsFieldsToSelect = ""
    Private WorkOrderConcernsTablesLinks = ""
    Private WorkOrderConcernsSelectionFilter = ""
    Private WorkOrderConcernsSelectionFilterSaved = ""
    Private WorkOrderConcernsSelectionOrder = ""

    Private WorkOrderConcernsDataGridViewLocationX As Integer
    Private WorkOrderConcernsDataGridViewLocationY As Integer

    Private Savedmilage As Integer
    Private SavedCustomer = ""
    Private VINSaved As String
    Private PurposeOfEntry As String
    Dim NewWorkOrderFormYAxis = Me.Location.Y + 100
    Private WorkOrderDataGridViewAlreadyFormated = False

    Private Sub WorkOrderForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' INITIALIZE FIRST ALL DATAGRIDVIEWS for enabling all its field for reference
        Select Case ActivatedBy.Text
            Case "VehicleManagementSystemForm"
                VehicleManagementSystemForm.ShowInTaskbar = False
        End Select

        FillWorkOrderDataGridView()
        SetupFormUserAccess()
        SetupWorkOrderSelection(1)                      ' this routine proceeds to FillWorkOrderDataGridView()
        WorkOrderConcernsDataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True '(1 - Property state = true, 2- false, 3-default on development
    End Sub
    Private Sub SetupFormUserAccess()
        Select Case UserLevelAccess
            Case "1A"                                      ' nick p lalangan no restriction
            Case "1B"                                      ' Systems Analyst no restriction
            Case "3E"                                      ' Customer Relations Specialist 
                WorkOrderConcernsDataGridView.Columns.Item("SystemDesc_ShortText100Fld").Visible = False
                WorkOrderConcernsDataGridView.Columns.Item("ConcernType_ShortText100").Visible = False
                WorkOrderConcernsDataGridView.Columns.Item("ConcernTypePrefix_ShortText50").Visible = False
            Case "3B"                                       '   Service Deparment Assistant Manager	
                AddWorkOrderToolStripMenuItem.Visible = False
                EditWorkOrderToolStripMenuItem.Visible = False
                DeleteWorkOrderToolStripMenuItem.Visible = False
                PrintWorkOrderToolStripMenuItem.Visible = False
                SubmitForServiceToolStripMenuItem.Visible = False
                ConcernsToolStripMenuItem.Visible = False
                AddWorkOrderConcernToolStripMenuItem.Visible = False
                AssignWorkOrderToolStripMenuItem.Visible = True   '   Assign work to Lead Service Specialist

            Case Else
                MsgBox("UserLevelAccess = " & UserLevelAccess & "not yet addressed ")
        End Select

    End Sub


    Private Sub FillWorkOrderDataGridView()
        WorkOrderSelectionOrder = " ORDER BY WorkOrderID_AutoNumber DESC "
        Dim VehicleName = " (VehicleDetailsTable.YearManufactured_ShortText4 & space(1) & Trim(VehicleTypeTable.VehicleType_ShortText20) & space(1) & trim(VehicleModelsTable.VehicleModel_ShortText20) & space(1) & trim(VehicleTrimTable.VehicleTrimName_ShortText25)),"
        Dim OwnerName = " (trim(OwnerTable.FirstName_ShortText15) & space(1) & Trim(OwnerTable.LastName_ShortText15) & space(1) & trim(OwnerTable.NamePrefix_ShortText3)),"
        Dim AssignedLeadMechanic = " (trim(PersonnelTable.FirstName_ShortText15) & space(1) & Trim(PersonnelTable.LastName_ShortText15)), "
        Dim AssistantServiceManager = " (trim(PersonnelTable_1.FirstName_ShortText15) & space(1) & Trim(PersonnelTable_1.LastName_ShortText15)), "
        Dim CustomerServiceSpecialist = " (trim(PersonnelTable_2.FirstName_ShortText15) & space(1) & Trim(PersonnelTable_2.LastName_ShortText15)), "
        Dim VehicleReleaseDate = " WorkOrderTable.ReleaseDate_DateTime, "
        Dim EmailAddress = " OwnerTable.EmailAddress_ShortText20, "
        Dim Address = "(trim(OwnerTable.Street_ShortText25) & trim(OwnerTable.BldgAptRmNo_ShortText25) &  "", "" & Trim(CityTable.CityName_ShortText25) & "", "" & Trim(CityTable.ZipCode_ShortText9))"
        Dim WorkStatus = " IIf(WorkOrderTable.WorkOrderStatus_Byte = 0, ""pending"", iif(WorkOrderTable.WorkOrderStatus_Byte = 1,""for assignment"",""for billing"")), "
        Select Case CurrentUserGroup
            Case "Service Deparment Assistant Manager"
                EmailAddress = ""
                Address = ""
            Case "Customer Relations Specialist"

            Case Else
                VehicleReleaseDate = ""

        End Select


        WorkOrderFieldsToSelect = " SELECT " &
                                           " WorkOrderTable.WorkOrderNumber_ShortText12, " &
                                           " WorkOrderTable.ServiceDate_DateTime, " &
                                              VehicleReleaseDate &
                                          " WorkOrderTable.VehicleMilage_Integer, " &
                                             VehicleName &
                                             OwnerName &
                                           " WorkOrderTable.WorkOrderStatus_Byte, " &
                                           " OwnerTable.TelNo_ShortText10, " &
                                             EmailAddress &
                                             AssistantServiceManager &
                                             AssignedLeadMechanic &
                                             CustomerServiceSpecialist &
                                             WorkStatus &
                                           " WorkOrderTable.CustomerServiceInCharge_LongImteger, " &
                                           " WorkOrderTable.ServiceManagerAssigning_LongInteger, " &
                                           " WorkOrderTable.AssignedLeadMechanic_longInteger, " &
                                           " WorkOrderTable.WorkOrderID_AutoNumber "

        WorkOrderTablesLinks = " FROM (((((((((WorkOrderTable LEFT JOIN VehicleServicedTable ON WorkOrderTable.[VehicleServicedID_LongInteger] = VehicleServicedTable.VehicleServicedID_AutoNumber) " &
                                                            " LEFT JOIN OwnerTable On VehicleServicedTable.OwnerID_LongInteger = OwnerTable.OwnerID_AutoNumber) " &
                                                            " LEFT JOIN CityTable On OwnerTable.CityID_LongInteger = CityTable.CityID_AutoNumber) " &
                                                            " LEFT JOIN (VehicleDetailsTable LEFT JOIN VehicleModelsRelationsTable On VehicleDetailsTable.[VehicleModelsRelationsID_LongInteger] = VehicleModelsRelationsTable.[VehicleModelsRelationsID_Autonumber]) On VehicleServicedTable.VehicleDetailsID_LongInteger = VehicleDetailsTable.VehicleDetailsID_AutoNumber) " &
                                                            " LEFT JOIN VehicleTypeTable On VehicleModelsRelationsTable.VehicleTypeID_LongInteger = VehicleTypeTable.VehicleTypeID_AutoNumber) " &
                                                            " LEFT JOIN VehicleTrimTable On VehicleModelsRelationsTable.VehicleTrimID_LongInteger = VehicleTrimTable.VehicleTrimID_Autonumber) " &
                                                            " LEFT JOIN VehicleModelsTable On VehicleModelsRelationsTable.VehicleModelID_LongInteger = VehicleModelsTable.VehicleModelID_Autonumber) " &
                                                            " LEFT JOIN PersonnelTable On WorkOrderTable.AssignedLeadMechanic_longInteger = PersonnelTable.PersonnelID_AutoNumber) " &
                                                            " LEFT JOIN PersonnelTable As PersonnelTable_1 On WorkOrderTable.ServiceManagerAssigning_LongInteger = PersonnelTable_1.PersonnelID_AutoNumber) " &
                                                            " LEFT JOIN PersonnelTable As PersonnelTable_2 On WorkOrderTable.CustomerServiceInCharge_LongImteger = PersonnelTable_2.PersonnelID_AutoNumber "

        MySelection = WorkOrderFieldsToSelect & WorkOrderTablesLinks & WorkOrderSelectionFilter & WorkOrderSelectionOrder

        WorkOrderTable.MyDbCommand(MySelection)
        If NotEmpty(WorkOrderTable.Exception) Then MsgBox(WorkOrderTable.Exception) : Exit Sub
        WorkOrdersRecordCount = RecordCount

        WorkOrdersDataGridView.DataSource = WorkOrderTable.MyAccessDbDataTable
        If Not WorkOrderDataGridViewAlreadyFormated Then
            FormatWorkOrdersDataGridView()
        End If
    End Sub
    Private Sub FormatWorkOrdersDataGridView()
        WorkOrderDataGridViewAlreadyFormated = True
        WorkOrdersDataGridView.Width = 0
        For i = 0 To WorkOrdersDataGridView.Columns.GetColumnCount(0) - 1
            Dim DoNotDisplayFields = "PlateNumber_ShortText20VinNo_ShortText20WorkOrderID_AutoNumberWorkOrderStatus_ByteCustomerServiceInCharge_LongImtegerServiceManagerAssigning_LongIntegerAssignedLeadMechanic_longInteger"
            If InStr(DoNotDisplayFields, WorkOrdersDataGridView.Columns.Item(i).HeaderText) > 0 Then
                WorkOrdersDataGridView.Columns.Item(i).Visible = False
            End If
            Select Case WorkOrdersDataGridView.Columns.Item(i).HeaderText
                Case "WorkOrderNumber_ShortText12"
                    WorkOrdersDataGridView.Columns.Item(i).HeaderText = "WORK ORDER No."
                    WorkOrdersDataGridView.Columns.Item(i).Width = 120
                Case "ServiceDate_DateTime"
                    WorkOrdersDataGridView.Columns.Item(i).HeaderText = "Date/Time In"
                    WorkOrdersDataGridView.Columns.Item(i).Width = 80
                    WorkOrdersDataGridView.Columns(i).DefaultCellStyle.Format = "yy-MM-dd"
                Case "ReleaseDate_DateTime"
                    WorkOrdersDataGridView.Columns.Item(i).HeaderText = "Date/Time Out"
                    WorkOrdersDataGridView.Columns.Item(i).Width = 80
                    WorkOrdersDataGridView.Columns(i).DefaultCellStyle.Format = "yy-MM-dd"
                Case "VehicleMilage_Integer"
                    WorkOrdersDataGridView.Columns.Item(i).HeaderText = "Milage"
                    WorkOrdersDataGridView.Columns.Item(i).Width = 70
                    WorkOrdersDataGridView.Columns(i).DefaultCellStyle.Format = "###,###"
                    WorkOrdersDataGridView.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "TelNo_ShortText10"
                    WorkOrdersDataGridView.Columns.Item(i).HeaderText = "Telephone Number"
                    WorkOrdersDataGridView.Columns.Item(i).Width = 100
                Case "EmailAddress_ShortText20"
                    WorkOrdersDataGridView.Columns.Item(i).HeaderText = "Email Address"
                    WorkOrdersDataGridView.Columns.Item(i).Width = 100
                Case "Expr1004"
                    WorkOrdersDataGridView.Columns.Item(i).HeaderText = "Vehicle Description"
                    WorkOrdersDataGridView.Columns.Item(i).Width = 180
                Case "Expr1005"
                    WorkOrdersDataGridView.Columns.Item(i).HeaderText = "Customer"
                    WorkOrdersDataGridView.Columns.Item(i).Width = 160
                Case "Expr1009"
                    WorkOrdersDataGridView.Columns.Item(i).HeaderText = "Supervisor"
                    WorkOrdersDataGridView.Columns.Item(i).Width = 160
                Case "Expr1010"
                    WorkOrdersDataGridView.Columns.Item(i).HeaderText = "Lead Mechanic"
                    WorkOrdersDataGridView.Columns.Item(i).Width = 160
                Case "Expr1011"
                    WorkOrdersDataGridView.Columns.Item(i).HeaderText = "Processed by"
                    WorkOrdersDataGridView.Columns.Item(i).Width = 160
                Case "Expr1012"
                    WorkOrdersDataGridView.Columns.Item(i).Width = 117
                    WorkOrdersDataGridView.Columns.Item(i).HeaderText = "Status"

            End Select

            If WorkOrdersDataGridView.Columns.Item(i).Visible = True Then
                WorkOrdersDataGridView.Width = WorkOrdersDataGridView.Width + WorkOrdersDataGridView.Columns.Item(i).Width
            End If
        Next
        If WorkOrdersDataGridView.Width > VehicleManagementSystemForm.Width Then
            WorkOrdersDataGridView.Width = Me.Width - 100
        Else
            WorkOrdersDataGridView.Width = WorkOrdersDataGridView.Width + 20
            Dim LargestWidth = WorkOrdersDataGridView.Width
            If LargestWidth < WorkOrderConcernsDataGridView.Width Then LargestWidth = WorkOrderConcernsDataGridView.Width

            Me.Width = LargestWidth + 10
        End If
        '       WorkOrderConcernsDataGridView.Width = WorkOrderConcernsDataGridView.Width


        WorkOrderConcernsDataGridView.Left = (Me.Width - WorkOrderConcernsDataGridView.Width) / 2
        WorkOrdersDataGridView.Top = 30
        Me.Left = (VehicleManagementSystemForm.Width - Me.Width) / 2
        Me.Location = New Point(Me.Location.X, 55)
        WorkOrdersDataGridView.Left = (Me.Width - WorkOrdersDataGridView.Width) / 2

    End Sub
    Private Sub FillWorkOrderConcernsDataGridView()

        WorkOrderConcernsFieldsToSelect = "Select " &
                " WorkOrderConcernsTable.WorkOrderConcernsID_AutoNumber, " &
                " WorkOrderConcernsTable.WorkOrderConcernsItemNo_NumberInteger, " &
                " WorkOrderConcernsTable.TextType_Byte, " &
                " iif(WorkOrderConcernsTable.TextType_Byte=1, LongTextConcernTable.LongTextConcern_LongText, ConcernsTable.Concern_ShortText150), " &
                " WorkOrderConcernsTable.WorkOrderID_Integer, " &
                " WorkOrderConcernsTable.Concern_LongText, " &
                " ConcernsTable.Concern_ShortText150, " &
                " MasterCodeBookTable.SystemDesc_ShortText100Fld, " &
                " ConcernTypeTable.ConcernType_ShortText100, " &
                " ConcernTypeTable.ConcernTypePrefix_ShortText50, " &
                " WorkOrderConcernsTable.ConcernLongTextCodeID_LongInteger "

        WorkOrderConcernsTablesLinks = " FROM((((WorkOrderConcernsTable LEFT JOIN WorkOrderTable ON WorkOrderConcernsTable.WorkOrderID_Integer = WorkOrderTable.WorkOrderID_AutoNumber) " &
                                              " LEFT JOIN ConcernsTable On WorkOrderConcernsTable.[ConcernLongTextCodeID_LongInteger] = ConcernsTable.ConcernCodeID_AutoNumber) " &
                                              " LEFT JOIN MasterCodeBookTable On ConcernsTable.MasterCodeBookId_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) " &
                                              " LEFT JOIN ConcernTypeTable On ConcernsTable.ConcernTypeID_LongInteger = ConcernTypeTable.ConcernTypeID_AutoNumber) " &
                                              " LEFT JOIN LongTextConcernTable On WorkOrderConcernsTable.ConcernLongTextCodeID_LongInteger = LongTextConcernTable.LongTextConcernID_Autonumber "
        WorkOrderConcernsSelectionFilter = " WHERE WorkOrderID_Integer = " & Str(CurrentWorkOrderID)
        WorkOrderConcernsSelectionOrder = " ORDER BY WorkOrderConcernsItemNo_NumberInteger "




        MySelection = WorkOrderConcernsFieldsToSelect & WorkOrderConcernsTablesLinks & WorkOrderConcernsSelectionFilter & WorkOrderConcernsSelectionOrder

        JustExecuteMySelection()
        WorkOrderConcernsRecordCount = RecordCount
        WorkOrderConcernsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        Dim HeightToAdd = IIf(WorkOrderConcernsRecordCount = 0, 0, (WorkOrderConcernsRecordCount * DataGridViewRowHeight))
        WorkOrderConcernsDataGridView.Height = WorkOrderConcernsDataGridView.ColumnHeadersHeight + HeightToAdd + 100
        '        " WorkOrderConcernsTable.WorkOrderConcernsID_AutoNumber, " &
        WorkOrderConcernsDataGridView.Columns.Item("WorkOrderConcernsID_AutoNumber").Visible = False
        '        " WorkOrderConcernsTable.WorkOrderID_Integer, " &
        WorkOrderConcernsDataGridView.Columns.Item("WorkOrderID_Integer").Visible = False
        '        " WorkOrderConcernsTable.ConcernLongTextCodeID_LongInteger "
        WorkOrderConcernsDataGridView.Columns.Item("ConcernLongTextCodeID_LongInteger").Visible = False

        '        " WorkOrderConcernsTable.WorkOrderConcernsItemNo_NumberInteger, " &
        WorkOrderConcernsDataGridView.Columns.Item("WorkOrderConcernsItemNo_NumberInteger").HeaderText = "Itm"
        WorkOrderConcernsDataGridView.Columns.Item("WorkOrderConcernsItemNo_NumberInteger").Width = 30
        WorkOrderConcernsDataGridView.Columns.Item("WorkOrderConcernsItemNo_NumberInteger").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        WorkOrderConcernsDataGridView.Columns.Item("TextType_Byte").HeaderText = "Type"
        WorkOrderConcernsDataGridView.Columns.Item("TextType_Byte").Width = 30

        '          " WorkOrderConcernsTable.Concern_LongText, " &
        WorkOrderConcernsDataGridView.Columns.Item("EXPR1003").HeaderText = "EitherOr"
        WorkOrderConcernsDataGridView.Columns.Item("EXPR1003").Width = 400

        '         " WorkOrderConcernsTable.Concern_LongText, " &
        WorkOrderConcernsDataGridView.Columns.Item("Concern_LongText").HeaderText = "WorkOrderConcernsTable.Concern_LongText"
        WorkOrderConcernsDataGridView.Columns.Item("Concern_LongText").Width = 400

        '               " ConcernsTable.Concern_ShortText150, " &
        WorkOrderConcernsDataGridView.Columns.Item("Concern_ShortText150").HeaderText = "ConcernsTable.Concern_ShortText150"
        WorkOrderConcernsDataGridView.Columns.Item("Concern_ShortText150").Width = 400

        '                " MasterCodeBookTable.SystemDesc_ShortText100Fld, " &
        WorkOrderConcernsDataGridView.Columns.Item("SystemDesc_ShortText100Fld").HeaderText = "MasterCodeBookTable.SystemDesc_ShortText100Fld"
        WorkOrderConcernsDataGridView.Columns.Item("SystemDesc_ShortText100Fld").Width = 300


        '         " ConcernTypeTable.ConcernType_ShortText100, " &
        WorkOrderConcernsDataGridView.Columns.Item("ConcernType_ShortText100").HeaderText = "ConcernTypeTable.ConcernType_ShortText100"
        WorkOrderConcernsDataGridView.Columns.Item("ConcernType_ShortText100").Width = 300

        '       " ConcernTypeTable.ConcernTypePrefix_ShortText50, " &
        WorkOrderConcernsDataGridView.Columns.Item("ConcernTypePrefix_ShortText50").HeaderText = "ConcernTypeTable.ConcernTypePrefix_ShortText50"
        WorkOrderConcernsDataGridView.Columns.Item("ConcernTypePrefix_ShortText50").Width = 300


        WorkOrderConcernsDataGridView.Width = 0
        For i = 0 To WorkOrderConcernsDataGridView.Columns.GetColumnCount(0) - 1
            If WorkOrderConcernsDataGridView.Columns.Item(i).Visible = True Then
                WorkOrderConcernsDataGridView.Width = WorkOrderConcernsDataGridView.Width + WorkOrderConcernsDataGridView.Columns.Item(i).Width
            End If
        Next
        WorkOrderConcernsDataGridView.Width = WorkOrderConcernsDataGridView.Width + 20
        WorkOrderConcernsDataGridView.Width = 1000
        WorkOrderConcernsDataGridView.Left = (Me.Width - WorkOrderConcernsDataGridView.Width) / 2

        Dim NoOfHeaderLines = 1
        Dim RecordsDisplyed = WorkOrderConcernsRecordCount
        Dim FormLowPointFromGrid = 90
        If WorkOrderConcernsRecordCount > 27 Then
            RecordsDisplyed = 27
        Else
            RecordsDisplyed = WorkOrderConcernsRecordCount
        End If

        WorkOrderConcernsDataGridView.Height = (WorkOrderConcernsDataGridView.ColumnHeadersHeight * NoOfHeaderLines * 2) + (DataGridViewRowHeight * RecordsDisplyed)
    End Sub


    Public Sub SetupWorkOrderSelection(WorkOrderStatusSelection)
        '   0 - Outstanding for the Customer Service Specialist for registering the the work order with all concerns                                                                        TO BE Updated by 
        '   1 - Outstanding for the Assistant Service Manager			
        '           to possibly analyze And/ Or itemize the concerns into jobs 
        '           then assign to the Lead Service Specialist
        '   2 - all jobs completed	/ for finalization							  TO BE Updated by AssignedLeadMechanic         
        '   3 - Outstanding for LEAD SERVICE SPEIALIST to be assigned to Service Specialists
        '   4 - Concerns are assigned to a technician						  to be updated BY LEAD SERVICE MECHANIC
        '   5 - Partially, some jobs related are done						  to be updated by HANDS ON MECHANIC
        '   9 - Vehicle Released
        Dim OutstandingForThisUser = " = -1 "

        Select Case CurrentUserGroup
            Case "1A"                                      ' vernannekanico
                OutstandingForThisUser = " < 9 "
            Case "1B"                                      ' Systems Analyst
                OutstandingForThisUser = " < 9 "
            Case "Customer Relations Specialist"
                WorkOrderConcernsDataGridView.Columns.Item("SystemDesc_ShortText100Fld").Visible = False
                WorkOrderConcernsDataGridView.Columns.Item("ConcernType_ShortText100").Visible = False
                WorkOrderConcernsDataGridView.Columns.Item("ConcernTypePrefix_ShortText50").Visible = False
                OutstandingForThisUser = " < 3 "
            Case "3B"                                                                   '   Service Deparment Assistant Manager	
                OutstandingForThisUser = " = 1 "
            Case "3C"                                                                   '   Lead Service Specialist
                OutstandingForThisUser = " = 2 "
            Case Else
                MsgBox("UserLevelAccess = " & UserLevelAccess & "not yet addressed ")
        End Select
        Select Case WorkOrderStatusSelection
            Case 1
                WorkOrderSelectionFilter = " WHERE WorkOrderStatus_Byte " & OutstandingForThisUser
                Me.Text = "OUTSTANDING WORK ORDERS"
            Case 2
                WorkOrderSelectionFilter = " WHERE WorkOrderStatus_Byte = 2 "
                Me.Text = "FINISHED WORK ORDERS"
            Case 9
                WorkOrderSelectionFilter = " WHERE WorkOrderStatus_Byte = 9 "
                Me.Text = "WORK ORDERS RELEASED"
            Case 10
                WorkOrderSelectionFilter = ""
                Me.Text = "ALL WORK ORDERS"

        End Select

        FillWorkOrderDataGridView()
    End Sub

    Private Sub WorkOrdersDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles WorkOrdersDataGridView.RowEnter
        If e.RowIndex < 0 Then Exit Sub
        If WorkOrdersRecordCount = 0 Then Exit Sub
        CurrentWorkOrderRow = e.RowIndex
        If Not WorkOrderConcernsDataGridViewInitialized Then
            WorkOrderConcernsDataGridViewInitialized = True
        End If
        CurrentWorkOrderID = WorkOrdersDataGridView.Item("WorkOrderID_AutoNumber", CurrentWorkOrderRow).Value
        CurrentWorkOrderNumber = WorkOrdersDataGridView.Item("WorkOrderNumber_ShortText12", CurrentWorkOrderRow).Value
        CurrentWorkOrderStatus = WorkOrdersDataGridView.Item("WorkOrderStatus_Byte", CurrentWorkOrderRow).Value
        WorkOrderConcernsDataGridViewLocationY = WorkOrdersDataGridView.Location.Y + ((CurrentWorkOrderRow * DataGridViewRowHeight) + (DataGridViewRowHeight * 3))
        If WorkOrderConcernsDataGridViewLocationY < 120 Then WorkOrderConcernsDataGridViewLocationY = 120
        WorkOrderConcernsDataGridView.Left = (Me.Width - WorkOrderConcernsDataGridView.Width) / 2
        WorkOrderConcernsDataGridView.Location = New Point(WorkOrderConcernsDataGridView.Left, WorkOrderConcernsDataGridViewLocationY)
        Select Case CurrentUserGroup
            Case "1A"                                      ' vernannekanico
            Case "1B"                                      ' Systems Analyst

            Case "Customer Relations Specialist"
                DisableEdit()
                Select Case CurrentWorkOrderStatus
                    ' 0 - temporary entry during registation						  TO BE Updated by Customer Service
                    ' 1 - Work Order finalized (Submitted/Printed)					  TO BE Updated by Customer Service
                    ' 2 - assigned to the Assistant Service Manager                    to be updated by LEAD SERVICE MECHANIC
                    ' 3 - Concerns are assigned to a technician						  to be updated BY LEAD SERVICE MECHANIC
                    ' 4 - Partially, some jobs related are done						  to be updated by HANDS ON MECHANIC
                    ' 9 - all jobs completed                  
                    Case 0 ' Outstanding
                        EnableEdit()
                    Case 1
                    Case 2
                        EnableEdit()
                    Case 5
                        FinalizeToolStripMenu.Visible = True
                End Select


            Case "Service Deparment Assistant Manager"
                If WorkOrdersDataGridView.Item("WorkOrderStatus_Byte", CurrentWorkOrderRow).Value = 1 Then
                    AssignWorkOrderToolStripMenuItem.Visible = True
                Else
                    AssignWorkOrderToolStripMenuItem.Visible = False
                End If

        End Select

        FillWorkOrderConcernsDataGridView()
    End Sub
    Private Sub DetermineOptionsAccess()
        If CurrentWorkOrderStatus = 0 Then
            EnableEdit()
        Else
            DisableEdit()
        End If
    End Sub
    Private Sub EnableEdit()
        AddWorkOrderToolStripMenuItem.Visible = True
        EditWorkOrderToolStripMenuItem.Visible = True
        DeleteWorkOrderToolStripMenuItem.Visible = True
        ConcernsToolStripMenuItem.Visible = True
        AddWorkOrderConcernToolStripMenuItem.Visible = True
    End Sub
    Private Sub DisableEdit()
        '       AddWorkOrderToolStripMenuItem.Visible = False
        EditWorkOrderToolStripMenuItem.Visible = False
        DeleteWorkOrderToolStripMenuItem.Visible = False
        ConcernsToolStripMenuItem.Visible = False
        AddWorkOrderConcernToolStripMenuItem.Visible = False
        SubmitForServiceToolStripMenuItem.Visible = False
        FinalizeToolStripMenu.Visible = False
    End Sub

    Private Sub WorkOrdersDataGridView_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles WorkOrdersDataGridView.DataBindingComplete
        Dim NoOfHeaderLines = 1
        Dim RecordsDisplyed = WorkOrdersRecordCount

        If WorkOrdersRecordCount > 24 Then
            RecordsDisplyed = 24
        Else
            RecordsDisplyed = WorkOrdersRecordCount + 1
        End If
        WorkOrdersDataGridView.Height = (WorkOrdersDataGridView.ColumnHeadersHeight * NoOfHeaderLines) + (DataGridViewRowHeight * RecordsDisplyed) + DataGridViewRowHeight
        If WorkOrdersRecordCount = 0 Then
            CurrentWorkOrderID = -1
            FillWorkOrderConcernsDataGridView()
        End If

    End Sub

    Private Sub WorkOrderConcernsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles WorkOrderConcernsDataGridView.RowEnter
        RemoveConcernToolStripMenuItem.Visible = False
        If e.RowIndex < 0 Then Exit Sub
        If RecordCount = 0 Then Exit Sub

        CurrentWorkOrderConcernsRow = e.RowIndex

        If Not WorkOrderConcernsDataGridViewInitialized Then
            WorkOrderConcernsDataGridViewInitialized = True
        End If

        CurrentWorkOrderConcernID = WorkOrderConcernsDataGridView.Item("WorkOrderConcernsID_AutoNumber", CurrentWorkOrderConcernsRow).Value
        If CurrentWorkOrderStatus = 0 And WorkOrderDetailsGroup.Visible = False Then
            RemoveConcernToolStripMenuItem.Visible = True
        End If
    End Sub
    Private Sub WorkOrderConcernsDataGridView_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles WorkOrderConcernsDataGridView.DataBindingComplete

    End Sub
    Private Sub LoadWorkOrderDetails()
        If Not IsDBNull(WorkOrdersDataGridView("WorkOrderNumber_ShortText12", CurrentWorkOrderRow).Value) Then
            WorkOrderNumberTextBox.Text = WorkOrdersDataGridView("WorkOrderNumber_ShortText12", CurrentWorkOrderRow).Value
        End If
        If Not IsDBNull(WorkOrdersDataGridView("ServiceDate_DateTime", CurrentWorkOrderRow).Value) Then
            ServiceDate_DateTimeTextBox.Text = WorkOrdersDataGridView("ServiceDate_DateTime", CurrentWorkOrderRow).Value
        End If
        If Not IsDBNull(WorkOrdersDataGridView("ReleaseDate_DateTime", CurrentWorkOrderRow).Value) Then
            DateTimeOutTextBox.Text = WorkOrdersDataGridView("ReleaseDate_DateTime", CurrentWorkOrderRow).Value
        End If

        MilageMaskedTextBox.Text = IIf(IsDBNull(WorkOrdersDataGridView("VehicleMilage_Integer", CurrentWorkOrderRow).Value), "", WorkOrdersDataGridView("VehicleMilage_Integer", CurrentWorkOrderRow).Value)
        CustomerTextBox.Text = WorkOrdersDataGridView("LastName_ShortText15", CurrentWorkOrderRow).Value & " " & WorkOrdersDataGridView("FirstName_ShortText15", CurrentWorkOrderRow).Value
        VINTextBox.Text = WorkOrdersDataGridView("VinNo_ShortText20", CurrentWorkOrderRow).Value
        '        Dim VehicleDetails = WorkOrdersDataGridView("vehicleName", CurrentWorkOrderRow).Value       & ", " &
        '      WorkOrdersDataGridView("VehicleModel_ShortText20", CurrentWorkOrderRow).Value & ", " &
        '       WorkOrdersDataGridView("Engine_ShortText20", CurrentWorkOrderRow).Value

        '   VehicleDetailsTextBox.Text = VehicleDetails
        CurrentVehicleServicedID = WorkOrdersDataGridView("VehicleServicedID_LongInteger", CurrentWorkOrderRow).Value

    End Sub
    Private Sub LoadConcerns()
        FillWorkOrderConcernsDataGridView()


    End Sub
    Private Sub RemoveFromWorkOrderConcernsTable()
        'delete this routine
    End Sub

    Private Sub WorkOrderForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        'Enables calling form
        Select Case ActivatedBy.Text
            Case "VehicleManagementSystemForm"
                VehicleManagementSystemForm.Enabled = True ' triggers enabledchaned event of calling form
                VehicleManagementSystemForm.ShowInTaskbar = True
            Case Else

                Dim x = "break here"
        End Select
        ActivatedBy.Text = ""

    End Sub

    Private Sub WorkOrderForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        'Refresh datagridviw here
        ' GET RETURNED DATA HERE

        If Me.Enabled = False Then
            Exit Sub
        End If
        Select Case Tunnel2
            Case "Tunnel1IsConcernCode"
                CurrentConcernID = Tunnel1
                SaveNewWorkOrderConcern()
            Case "Tunnel1IsCustomerCode"
                CurrentCustomerID = Tunnel1 ' i think this is not needed. customer info can be obtained through the usedVehicleId
                CurrentVehicleServicedID = Tunnel3
            Case "Tunnel1IsCurrentPersonnelID"
                AssignedPersonnelID = Tunnel1 ' i think this is not needed. customer info can be obtained through the usedVehicleId
                AssignThisWorkOrder()
            Case "Tunnel1IsVehicleServicedID"
                CurrentVehicleServicedID = Tunnel1
            Case Else
                Dim xxx = 1
        End Select
        FillWorkOrderConcernsDataGridView()

    End Sub
    Private Sub SaveNewWorkOrderConcern()
        If Tunnel3 = 0 Then
            MySelection = "Select * from ConcernsTable WHERE ConcernCodeID_AutoNumber = " & Str(CurrentConcernID)
        Else
            MySelection = "Select * from LongTextConcernTable WHERE LongTextConcernID_Autonumber = " & Str(CurrentConcernID)

        End If

        If NoRecordFound() Then
            MsgBox("PROBLEM ...... unseccessful save ")
            Exit Sub
        End If
        Dim r As DataRow = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        Dim x = RecordCount
        Dim Concerntext = ""
        If Tunnel3 = 0 Then
            Concerntext = r("Concern_ShortText150")
        Else
            Concerntext = r("LongTextConcern_LongText")
        End If

        Dim WorkOrderConcernsDbTableCommand = "INSERT INTO WorkOrderConcernsTable "
        Dim WorkOrderConcernsDbTableFieldsToSelect = " ( " &
                                                 "  WorkOrderID_Integer, " &
                                                 "  Concern_LongText, " &
                                                 "  TextType_Byte, " &
                                                 "  ConcernLongTextCodeID_LongInteger " &
                                                 "  ) " &
                                          " VALUES ( " &
                                                    Str(CurrentWorkOrderID) & ",  " &
                                                    Chr(34) & Concerntext & Chr(34) & ",  " &
                                                    Str(Tunnel3) & ",  " &
                                                  Str(CurrentConcernID) &
                                                  " ) "

        MySelection = WorkOrderConcernsDbTableCommand & WorkOrderConcernsDbTableFieldsToSelect

        JustExecuteMySelection

        MySelection = "Select * from WorkOrderConcernsTable where WorkOrderID_Integer = " & Str(CurrentWorkOrderID)
        If NoRecordFound() Then
            MsgBox("unsuccesful insert")
        End If

        FillWorkOrderConcernsDataGridView()
    End Sub
    Private Sub AssignThisWorkOrder()

        WorkOrderSelectionFilter = " WHERE WorkOrderID_AutoNumber = " & Str(CurrentWorkOrderID)
        Select Case UserLevelAccess
            Case "3B"




                WorkOrderFieldsToSelect = " UPDATE WorkOrderTable  SET " &
                   " WorkOrderStatus_Byte = 2, " & ' for lead mechanic to re assign jobs to specialists
                   " AssignedLeadMechanic_longInteger = " & Str(AssignedPersonnelID) & ", " &
                   " ServiceManagerAssigning_LongInteger = " & Str(CurrentUserID)

        End Select


        MySelection = WorkOrderFieldsToSelect & WorkOrderSelectionFilter
        JustExecuteMySelection()


    End Sub


    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddWorkOrderToolStripMenuItem.Click
        PurposeOfEntry = "ADD"
        CurrentWorkOrderID = -1
        WorkOrderDetailsGroup.Visible = True
    End Sub
    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditWorkOrderToolStripMenuItem.Click
        PurposeOfEntry = "EDIT"
        '       LoadWorkOrderDetails()
        WorkOrderDetailsGroup.Visible = True
    End Sub

    Private Sub DeleteWorkOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteWorkOrderToolStripMenuItem.Click
        PurposeOfEntry = "DELETE"
        '      LoadWorkOrderDetails()
        WorkOrderDetailsGroup.Visible = True
        If WorkOrderConcernsRecordCount > 0 Then
            MsgBox("Unable to delete this Work Order." & vbCrLf & "delete first all concerns attached")
            WorkOrderDetailsGroup.Visible = False
            Exit Sub
        End If

        Dim Question As String = "Proceed to delete"
        Dim DeleteThisConcern As String = MsgBox(Question, 4)
        If DeleteThisConcern = vbNo Then
            WorkOrderDetailsGroup.Visible = False
            Exit Sub
        End If
        MySelection = "DELETE FROM WorkOrderTable WHERE WorkOrderID_AutoNumber = " & Str(CurrentWorkOrderID)

        JustExecuteMySelection()
        WorkOrderDetailsGroup.Visible = False
        SetupWorkOrderSelection(1)
        If ThisRecordNotYetExistsInTheWorkOrderTable() Then
            MsgBox("Successfuly deleted the record")
        Else
            MsgBox("UnSuccessfuly deleted the record, ????????")
        End If
    End Sub

    Private Sub RemoveConcernToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveConcernToolStripMenuItem.Click
        Dim Concern_ShortText150 As String = Trim(WorkOrderConcernsDataGridView("Concern_ShortText150", CurrentWorkOrderConcernsRow).Value)
        Dim Question As String = Trim(Concern_ShortText150) & Chr(13) & "Do you want to remove this concern"
        Dim DeleteThisConcern As String = MsgBox(Question, 4)
        If DeleteThisConcern = vbNo Then
            Exit Sub
        End If

        MySelection = "DELETE FROM WorkOrderConcernsTable WHERE WorkOrderConcernsID_AutoNumber = " & Str(CurrentWorkOrderConcernID)
        JustExecuteMySelection()
        FillWorkOrderConcernsDataGridView()

    End Sub

    Private Sub OutstandingWorkOrdersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OutstandingWorkOrdersToolStripMenuItem.Click
        If Not WorkOrderStatusSelection = 1 Then SetupWorkOrderSelection(1)
        WorkOrderStatusSelection = 1
    End Sub
    Private Sub ForFinalizationBillingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ForFinalizationBillingToolStripMenuItem.Click
        If Not WorkOrderStatusSelection = 5 Then SetupWorkOrderSelection(5)
        WorkOrderStatusSelection = 5
    End Sub
    Private Sub CompletedWorkOrdersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompletedWorkOrdersToolStripMenuItem.Click
        If Not WorkOrderStatusSelection = 9 Then SetupWorkOrderSelection(9)
        WorkOrderStatusSelection = 9
    End Sub
    Private Sub AllWorkOrdersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllWorkOrdersToolStripMenuItem.Click
        If Not WorkOrderStatusSelection = 10 Then SetupWorkOrderSelection(10)
        WorkOrderStatusSelection = 10
    End Sub

    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        If WorkOrderDetailsGroup.Visible Then
            'View or Edit mode
            If SaveWorkOrderToolStripMenuItem.Visible = False Then
                'View mode
                WorkOrderDetailsGroup.Enabled = True
                WorkOrderDetailsGroup.Visible = False
            Else
                'Edit mode
                If YouReallyWantToLeave() Then
                    WorkOrderDetailsGroup.Visible = False
                End If
            End If
        Else
            Me.Close()                                                  'Main Form  mode
        End If
    End Sub

    Private Sub AddToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles AddWorkOrderConcernToolStripMenuItem.Click
        ShowConcernsForm()

    End Sub
    Public Sub ShowConcernsForm()
        ConcernsForm.ActivatedBy.Text = Me.Name
        Me.Enabled = False
        ConcernsForm.Show()

    End Sub

    Private Sub CustomerTextBox_GotFocus(sender As Object, e As EventArgs) Handles CustomerTextBox.Click
        If LTrim(RTrim(CustomerTextBox.Text)) <> "" Then
            Dim AnswerToQuestion = MsgBox("Do you want to change this client ?", vbYesNo)
            If AnswerToQuestion = vbYes Then
                CustomerTextBox.Text = ""
            End If

        End If

        If LTrim(RTrim(MilageMaskedTextBox.Text)) = "" Then
            Dim AnswerToQuestion = MsgBox("Do you want to leave the milage blank ?", vbYesNo)
            If Not AnswerToQuestion = vbYes Then
                MilageMaskedTextBox.Select()
                Exit Sub
            End If

        End If
        If IsEmpty(CustomerTextBox.Text) Then
            ShowOwnerForm()
        End If
    End Sub
    Private Sub CustomerTextBox_TextChanged(sender As Object, e As EventArgs) Handles CustomerTextBox.TextChanged
        If Me.Enabled = False Then
            SavedCustomer = Trim(CustomerTextBox.Text)
            Exit Sub
        End If
        If NotEmpty(CustomerTextBox.Text) Then
            If OwnerForm.NameSearchTextBox.Text = CustomerTextBox.Text Then
                If Trim(CustomerTextBox.Text) = Trim(SavedCustomer) Then
                    Exit Sub
                Else
                    CustomerTextBox.Text = ""
                    OwnerForm.NameSearchTextBox.Text = CustomerTextBox.Text
                End If
                ShowOwnerForm()
            End If
            If Len(Trim(CustomerTextBox.Text)) = 1 Then
                OwnerForm.NameSearchTextBox.Text = CustomerTextBox.Text
            End If
        End If

    End Sub
    Public Sub ShowOwnerForm()
        Tunnel1 = CurrentCustomerID
        OwnerForm.ActivatedBy.Text = Me.Name
        Me.Enabled = False
        OwnerForm.Show()
    End Sub
    Private Function YouReallyWantToLeave()
        Dim NoOfEntries = 0
        Dim msg1 = "You have entered data for "
        Dim msg2 = ""
        Dim msg3 = Chr(13) & "EXIT anyway ?"

        If Not Trim(MilageMaskedTextBox.Text) = "" Then
            msg2 = "Milage "
            NoOfEntries = NoOfEntries + 1
        End If
        If Not Trim(CustomerTextBox.Text) = "" Then
            msg2 = "Customer "
            NoOfEntries = NoOfEntries + 1
        End If

        If NoOfEntries > 0 Then                                             ' ENTRIES EXISTS
            msg1 = msg1 & msg2 & msg3

            If Not MsgBox(msg1, 4) = vbYes Then
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub WorkOrderDetailsGroup_VisibleChanged(sender As Object, e As EventArgs) Handles WorkOrderDetailsGroup.VisibleChanged
        If WorkOrderDetailsGroup.Visible = False Then
            ' NOT SHOWN
            WorkOrdersDataGridView.Enabled = True
            WorkOrderConcernsDataGridView.Enabled = True

            '          DetermineOptionsAccess()
            EnableEdit()
            ViewToolStripMenuItem.Visible = True
            ConcernsToolStripMenuItem.Visible = True
            RemoveConcernToolStripMenuItem.Visible = False
            SaveWorkOrderToolStripMenuItem.Visible = False
            WorkOrderToolStripMenuItem.Text = "WORK ORDERS :"

        Else
            ' SHOWN
            If CurrentWorkOrderID > 0 Then
                LoadWorkOrderDetails()
            End If
            WorkOrdersDataGridView.Enabled = False
            WorkOrderConcernsDataGridView.Enabled = False

            '           DetermineOptionsAccess()
            DisableEdit()

            ViewToolStripMenuItem.Visible = False
            ConcernsToolStripMenuItem.Visible = False
            Select Case PurposeOfEntry
                Case "ADD"
                    WorkOrderToolStripMenuItem.Text = "ADD NEW WORK ORDER"
                    SaveWorkOrderToolStripMenuItem.Visible = True
                    AddNewWorkOrder()
                Case "EDIT"
                    WorkOrderToolStripMenuItem.Text = "EDIT THIS WORK ORDER"
                    SaveWorkOrderToolStripMenuItem.Visible = True
                Case "DELETE"
                    WorkOrderToolStripMenuItem.Text = "DELETE THIS WORK ORDER"
                Case "VIEW"
                    ConcernsToolStripMenuItem.Visible = False
                    DisableEdit()
                Case Else
                    Dim XXX = 1
            End Select
        End If
    End Sub
    Private Sub AddNewWorkOrder()
        MilageMaskedTextBox.Text = ""
        CustomerTextBox.Text = ""
        VINTextBox.Text = ""
        VehicleDetailsTextBox.Text = ""
        CurrentCustomerID = -1
        CurrentVehicleServicedID = -1

        DateTimeOutTextBox.Enabled = False
        VINTextBox.Enabled = False
        VehicleDetailsTextBox.Enabled = False

        ServiceDate_DateTimeTextBox.Text = Now()
        MilageMaskedTextBox.Select()
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles SaveWorkOrderToolStripMenuItem.Click
        Dim AnswerToMessage = ""
        If Trim(CustomerTextBox.Text) = "" Then
            CustomerTextBox.Select()
            Exit Sub
        End If
        If Trim(MilageMaskedTextBox.Text) = "" Then
            AnswerToMessage = MsgBox("Would you like to leave the Milage blank ?", vbYesNo)
            If AnswerToMessage = vbNo Then
                MilageMaskedTextBox.Select()
                Exit Sub
            End If
        End If
        Dim SavedWorkOrderSelectionFilter = WorkOrderSelectionFilter
        Select Case PurposeOfEntry
            Case "ADD"
                WorkOrderNumberTextBox.Text = GetNewWorkOrderID(Convert.ToDateTime(Trim(ServiceDate_DateTimeTextBox.Text)), Trim(MilageMaskedTextBox.Text))
                If ThisRecordNotYetExistsInTheWorkOrderTable() Then
                    RegisterNewWorkOrder()
                Else
                    MsgBox(" Record Is already registerd")
                    Close()
                    Exit Sub
                End If
            Case = "EDIT"
                If Not MsgBox(" Confirm Saving changes for EMPLOYEE ", vbYesNo) = vbYes Then
                    Exit Sub
                End If
                UpdateThisWorkOrderRecord()
        End Select
        WorkOrderSelectionFilter = SavedWorkOrderSelectionFilter
        WorkOrderDetailsGroup.Visible = False
        FillWorkOrderDataGridView()
    End Sub
    Private Sub UpdateThisWorkOrderRecord()

        WorkOrderSelectionFilter = " WHERE WorkOrderID_AutoNumber = " & Str(CurrentWorkOrderID)
        WorkOrderFieldsToSelect = " UPDATE WorkOrderTable  SET " &
                    " VehicleServicedID_LongInteger = " & Str(CurrentVehicleServicedID) & ", " &
                    " ServiceDate_DateTime = " & Chr(34) & Trim(ServiceDate_DateTimeTextBox.Text) & Chr(34) & ", " &
                    " VehicleMilage_Integer = " & MilageMaskedTextBox.Text

        MySelection = WorkOrderFieldsToSelect & WorkOrderSelectionFilter
        JustExecuteMySelection()

    End Sub

    Private Function ThisRecordNotYetExistsInTheWorkOrderTable()
        MySelection = "SELECT * " &
                       " FROM WorkOrderTable " &
                      " WHERE trim(WorkOrderNumber_ShortText12) = " & Chr(34) & Trim(WorkOrderNumberTextBox.Text) & Chr(34)

        If NoRecordFound() Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Sub RegisterNewWorkOrder()
        AddAWorkOrderRecord()
        Dim DataRowIndex As DataRow = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        CurrentWorkOrderID = DataRowIndex("WorkOrderID_AutoNumber")
        WorkOrderConcernsDataGridView.Visible = True
        AddWorkOrderConcernToolStripMenuItem.Visible = True
        RemoveConcernToolStripMenuItem.Visible = True
    End Sub
    Private Sub AddAWorkOrderRecord()
        'record was first tested if it already exist in the workorder table

        Dim WorkOrderNumber = GetNewWorkOrderID(Convert.ToDateTime(Trim(ServiceDate_DateTimeTextBox.Text)), Trim(MilageMaskedTextBox.Text))
        Dim MilageField = ""
        Dim Milage = ""
        If Not IsEmpty(MilageMaskedTextBox.Text) Then
            MilageField = " VehicleMilage_Integer, "
            Milage = Replace(MilageMaskedTextBox.Text, ",", "")
            Milage = Milage & ", "
        End If
        ' EXECUTE INSERT COMMAND
        Dim FieldsToUpdate = " ( " &
                    " WorkOrderNumber_ShortText12, " &
                    " VehicleServicedID_LongInteger, " &
                    " ServiceDate_DateTime, " &
                    MilageField &
                    " WorkOrderStatus_Byte) "

        Dim ReplacementData = "(" &
                    Chr(34) & WorkOrderNumberTextBox.Text & Chr(34) & ", " &
                    Str(CurrentVehicleServicedID) & ", " &
                    Chr(34) & Trim(ServiceDate_DateTimeTextBox.Text) & Chr(34) & ", " &
                      Milage &
                    Chr(34) & "0" & Chr(34) & ")"


        MySelection = "INSERT INTO WorkOrderTable  " & FieldsToUpdate & " VALUES " & ReplacementData

        JustExecuteMySelection()

        If ThisRecordNotYetExistsInTheWorkOrderTable() Then
            MsgBox("unsuccesful insert")
        End If
    End Sub

    Private Sub WorkOrderDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WorkOrderDetailsToolStripMenuItem.Click
        PurposeOfEntry = "VIEW"
        WorkOrderDetailsGroup.Visible = True
        WorkOrderDetailsGroup.Enabled = False
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PrintWorkOrderToolStripMenuItem.Click
        MsgBox("Print you Work Order Here")

    End Sub

    Private Sub SubmitForServiceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SubmitForServiceToolStripMenuItem.Click

        If Not MsgBox("Do you want to Submit the Work Order now to the Service Department?", vbYesNo) = vbYes Then
            Exit Sub
        End If

        WorkOrderSelectionFilter = " WHERE WorkOrderID_AutoNumber = " & Str(CurrentWorkOrderID)
        WorkOrderFieldsToSelect = " UPDATE WorkOrderTable  SET " &
                    " WorkOrderStatus_Byte = 1 "
        MySelection = WorkOrderFieldsToSelect & WorkOrderSelectionFilter
        JustExecuteMySelection()
        FillWorkOrderConcernsDataGridView()
    End Sub

    Private Sub AssignWorkOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AssignWorkOrderToolStripMenuItem.Click

        If CurrentWorkOrderStatus > 2 Then      'already assigned to lead engineer
            MsgBox("this work order has been already assigned ")
        Else
            ShowPersonnelForm()
        End If
    End Sub
    Public Sub ShowPersonnelForm()
        PersonnelForm.ActivatedByTextBox.Text = Me.Name
        Me.Enabled = False
        PersonnelForm.Show()

    End Sub

    Private Sub FinalizeToolStripMenu_Click(sender As Object, e As EventArgs) Handles FinalizeToolStripMenu.Click

    End Sub

End Class