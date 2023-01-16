Public Class WorkOrderFormCRS
    Private CurrentWorkOrderRow As Integer = -1
    Private WorkOrdersRecordCount As Integer = -1

    Private CurrentWorkOrderNumber As String

    Private CurrentConcernID As Integer = -1

    '    Private CurrentWorkOrderConcernID As Integer = -1
    Private CurrentWorkOrderConcernsRow As Integer
    Private WorkOrderConcernsRecordCount As Integer = -1
    Private CurrentWorkOrderConcernID As Integer = -1
    Private CurrentWorkOrderConcernJobID As Integer = -1
    Private CurrentLongTextConcernID = -1
    Private CurrentCustomerID As Integer = -1
    Private CurrentServicedVehicleID As Integer = -1
    Private CurrentWorkOrderConcernStatus = ""
    Private CurrentWorkOrderStatus = ""

    Private AssignedPersonnelID As Integer

    Private WorkOrdersTable As New MyDbControls
    Private WorkOrderDataGridViewInitialized = False
    Private WorkOrderConcernsDataGridViewInitialized = False
    Private WorkOrdersFieldsToSelect = ""
    Private WorkOrdersSelectionFilter = ""
    Private WorkOrdersSelectionOrder = ""

    Private WorkOrderStatusSelection As Integer = 1

    Private WorkOrderConcernsFieldsToSelect = ""
    Private WorkOrderConcernsTablesLinks = ""
    Private WorkOrderConcernsSelectionFilter = ""
    '   Private WorkOrderConcernsSelectionFilterSaved = ""
    Private WorkOrderConcernsSelectionOrder = ""
    Private WorkOrderConcernsDataGridViewAlreadyFormated = False
    Private WorkOrderConcernsDataGridViewLocationX As Integer
    Private WorkOrderConcernsDataGridViewLocationY As Integer

    '   Private Savedmilage As Integer
    Private SavedCustomer = ""
    '   Private VINSaved As String
    Private PurposeOfEntry As String
    '   Dim NewWorkOrderFormYAxis = Me.Location.Y + 100
    Private WorkOrderDataGridViewAlreadyFormated = False

    Private AllWorkOrderPartsFieldsToSelect = " "
    Private AllWorkOrderPartsTablesLinks = "   "
    Private AllWorkOrderPartsSelectionFilter = " "
    Private AllWorkOrderPartsSelectionOrder = " "
    Private AllWorkOrderPartsRecordCount = 0
    Private CurrentAllWorkOrderPartsID As Integer = -1
    Private CurrentAllWorkOrderPartsRow = -1
    Private AllWorkOrderPartsDataGridViewAlreadyFormated = False
    Private AllWorkOrderPartsDataGridViewInitialized = False

    Private SavedCallingForm As Form


    Private Sub WorkOrderForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' INITIALIZE FIRST ALL DATAGRIDVIEWS for enabling all its field for reference
        SavedCallingForm = CallingForm
        SetupFormUserAccess()
        WorkOrderConcernsDataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True '(1 - Property state = true, 2- false, 3-default on development
    End Sub
    Private Sub SetupFormUserAccess()
        DisableEdit()
        AddWorkOrderToolStripMenuItem.Visible = True
        SetupWorkOrderSelection(0)                      ' this routine proceeds to FillWorkOrdersDataGridView()

    End Sub

    Private Sub FillWorkOrdersDataGridView()
        WorkOrdersSelectionOrder = " ORDER BY WorkOrderID_AutoNumber DESC "
        Dim VehicleModels = " 
(VehiclesTable.YearManufactured_ShortText4 & space(1) & 
Trim(VehicleTypeTable.VehicleType_ShortText20) & space(1) & 
trim(VehicleModelsTable.VehicleModel_ShortText20) & space(1) & 
trim(VehicleTrimTable.VehicleTrimName_ShortText25)) AS VehicleModels,
"
        Dim CustomerServiceSpecialist = "
(trim(CSSTable.FirstName_ShortText30) & space(1) & Trim(CSSTable.LastName_ShortText30)) AS CustomerServiceSpecialist, 
"
        Dim AssistantServiceManager = " 
(trim(ASMTable.FirstName_ShortText30) & space(1) & Trim(ASMTable.LastName_ShortText30)) AS AssistantServiceManager, 
"
        Dim AssignedLeadMechanic = " 
(trim(ALMTable.FirstName_ShortText30) & space(1) & Trim(ALMTable.LastName_ShortText30)) AS AssignedLeadMechanic, 
"

        Dim OwnerName = " 
(trim(OwnersTable.FirstName_ShortText30) & space(1) & 
Trim(OwnersTable.LastName_ShortText30) & space(1) & 
trim(OwnersTable.NamePrefix_ShortText3)) AS OwnerName,
"
        WorkOrdersFieldsToSelect = " 
SELECT
WorkOrdersTable.WorkOrderNumber_ShortText12,
WorkOrdersTable.ServiceDate_DateTime,
WorkOrdersTable.ReleaseDate_DateTime,
WorkOrdersTable.VehicleMilage_Integer,
" & VehicleModels & OwnerName & " 
OwnersTable.TelNo_ShortText10, 
" &
CustomerServiceSpecialist &
AssistantServiceManager &
AssignedLeadMechanic & "
OwnersTable.OwnerID_AutoNumber,
ServicedVehiclesTable.VinNo_ShortText20,
WorkOrdersTable.ServicedVehicleID_LongInteger,
WorkOrdersTable.WorkOrderID_AutoNumber,
WorkOrdersTable.CustomerServiceInCharge_LongInteger,
WorkOrdersTable.ServiceManagerAssigning_LongInteger,
WorkOrdersTable.AssignedLeadMechanic_longInteger, 
StatusesTable.StatusSequence_LongInteger,
StatusesTable.StatusText_ShortText25 AS WorkOrderStatus
FROM ((((((((((WorkOrdersTable LEFT JOIN ServicedVehiclesTable ON WorkOrdersTable.ServicedVehicleID_LongInteger = ServicedVehiclesTable.ServicedVehicleID_AutoNumber) LEFT JOIN OwnersTable ON ServicedVehiclesTable.OwnerID_LongInteger = OwnersTable.OwnerID_AutoNumber) LEFT JOIN VehiclesTable ON ServicedVehiclesTable.VehicleID_LongInteger = VehiclesTable.VehicleID_AutoNumber) LEFT JOIN VehicleModelsRelationsTable ON VehiclesTable.VehicleModelsRelationID_LongInteger = VehicleModelsRelationsTable.VehicleModelsRelationID_Autonumber) LEFT JOIN VehicleTypeTable ON VehicleModelsRelationsTable.VehicleTypeID_LongInteger = VehicleTypeTable.VehicleTypeID_AutoNumber) LEFT JOIN VehicleTrimTable ON VehicleModelsRelationsTable.VehicleTrimID_LongInteger = VehicleTrimTable.VehicleTrimID_Autonumber) LEFT JOIN VehicleModelsTable ON VehicleModelsRelationsTable.VehicleModelID_LongInteger = VehicleModelsTable.VehicleModelID_Autonumber) LEFT JOIN PersonnelTable AS CSSTable ON WorkOrdersTable.CustomerServiceInCharge_LongInteger = CSSTable.PersonnelID_AutoNumber) LEFT JOIN PersonnelTable AS ASMTable ON WorkOrdersTable.ServiceManagerAssigning_LongInteger = ASMTable.PersonnelID_AutoNumber) LEFT JOIN PersonnelTable AS ALMTable ON WorkOrdersTable.AssignedLeadMechanic_longInteger = ALMTable.PersonnelID_AutoNumber) LEFT JOIN StatusesTable ON WorkOrdersTable.WorkOrderStatusID_LongInteger = StatusesTable.StatusID_Autonumber
"

        MySelection = WorkOrdersFieldsToSelect & WorkOrdersSelectionFilter & WorkOrdersSelectionOrder

        JustExecuteMySelection()
        WorkOrdersRecordCount = RecordCount

        PrintBillToolStripMenu.Visible = False
        SubmitForServiceToolStripMenuItem.Visible = False
        PrintWorkOrderToolStripMenuItem.Visible = False
        EditWorkOrderToolStripMenuItem.Visible = False
        DeleteWorkOrderToolStripMenuItem.Visible = False
        AddWorkOrderConcernToolStripMenuItem.Visible = False
        RemoveConcernOrJobToolStripMenuItem.Visible = False
        WorkOrdersDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If Not WorkOrderDataGridViewAlreadyFormated Then
            FormatWorkOrdersDataGridView()
        End If
        Dim NoOfHeaderLines = 1
        Dim RecordsDisplyed = WorkOrdersRecordCount

        If WorkOrdersRecordCount > 24 Then
            RecordsDisplyed = 24
        Else
            RecordsDisplyed = WorkOrdersRecordCount + 1
        End If
        WorkOrdersDataGridView.Height = (WorkOrdersDataGridView.ColumnHeadersHeight * NoOfHeaderLines) + (DataGridViewRowHeight * RecordsDisplyed) + DataGridViewRowHeight

    End Sub
    Private Sub FormatWorkOrdersDataGridView()
        WorkOrderDataGridViewAlreadyFormated = True
        WorkOrdersDataGridView.Width = 0
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
                WorkOrdersDataGridView.Width = WorkOrdersDataGridView.Width + WorkOrdersDataGridView.Columns.Item(i).Width
            End If
        Next
        If WorkOrdersDataGridView.Width > VehicleManagementSystemForm.Width Then
            WorkOrdersDataGridView.Width = VehicleManagementSystemForm.Width - 4
        End If
        If WorkOrdersDataGridView.Width > VehicleManagementSystemForm.Width Then
            WorkOrdersDataGridView.Width = Me.Width - 100
        Else
            WorkOrdersDataGridView.Width = WorkOrdersDataGridView.Width + 20
            Dim LargestWidth = WorkOrdersDataGridView.Width
            If LargestWidth < WorkOrderConcernsDataGridView.Width Then LargestWidth = WorkOrderConcernsDataGridView.Width

            Me.Width = LargestWidth + 10
        End If
        WorkOrderConcernsDataGridView.Width = WorkOrderConcernsDataGridView.Width

        WorkOrderConcernsDataGridView.Left = (Me.Width - WorkOrderConcernsDataGridView.Width) / 2
        WorkOrdersDataGridView.Top = 30
        Me.Left = (VehicleManagementSystemForm.Width - Me.Width) / 2
        Me.Location = New Point(Me.Location.X, 55)
        WorkOrdersDataGridView.Left = (Me.Width - WorkOrdersDataGridView.Width) / 2
        WorkOrderConcernsDataGridView.Top = WorkOrdersDataGridView.Top + WorkOrdersDataGridView.Height
    End Sub
    Private Sub WorkOrdersDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles WorkOrdersDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub

        If e.RowIndex < 0 Then Exit Sub
        If WorkOrdersRecordCount = 0 Then Exit Sub
        CurrentWorkOrderRow = e.RowIndex

        If Not WorkOrderConcernsDataGridViewInitialized Then
            WorkOrderConcernsDataGridViewInitialized = True
        End If
        CurrentWorkOrderID = WorkOrdersDataGridView.Item("WorkOrderID_AutoNumber", CurrentWorkOrderRow).Value
        SetVehicleInformations()
        CurrentWorkOrderNumber = WorkOrdersDataGridView.Item("WorkOrderNumber_ShortText12", CurrentWorkOrderRow).Value
        CurrentServicedVehicleID = WorkOrdersDataGridView.Item("ServicedVehicleID_LongInteger", CurrentWorkOrderRow).Value
        FillField(CurrentWorkOrderStatus, WorkOrdersDataGridView.Item("WorkOrderStatus", CurrentWorkOrderRow).Value)

        PrintBillToolStripMenu.Visible = False
        ConcernOrJobToolStripMenuItem.Visible = True
        AddWorkOrderConcernToolStripMenuItem.Visible = True
        PrintWorkOrderToolStripMenuItem.Visible = True
        WorkOrderConcernsDataGridView.Enabled = True
        EnableEdit()
        ' see table documentation

        FillWorkOrderConcernsDataGridView()
        Select Case CurrentWorkOrderStatus
            Case "Draft Work Order" ' Outstanding / Temporary entry status 
                If WorkOrderConcernsRecordCount > 0 Then
                    PrintWorkOrderToolStripMenuItem.Visible = True
                    SubmitForServiceToolStripMenuItem.Visible = True
                End If
            Case "For Billing"
                DisableEdit()
                WorkOrderConcernsDataGridView.Enabled = False
                ConcernOrJobToolStripMenuItem.Visible = False
                AddWorkOrderConcernToolStripMenuItem.Visible = False
                PrintBillToolStripMenu.Visible = True
                PrintWorkOrderToolStripMenuItem.Visible = False
        End Select

        AllWorkOrderPartsSelectionFilter = " WHERE WorkOrderPartsTable.WorkOrderConcernJobID_LongInteger = " & CurrentWorkOrderID
        AllWorkOrderPartsDataGridView.Visible = False
        FillAllWorkOrdersPartsDataGridView()
    End Sub
    Private Sub FillWorkOrderConcernsDataGridView() 'THIS IS THE SAME AS FillWorkOrderConcernsDataGridView() OF FormASM
        'NOTE IF MasterCodeBookTable.SystemDesc_ShortText100Fld IS EMPTY IT MEANS 
        ' ConcernAsIsByClientTable.LongTextConcern_LongText


        Dim ActionToTake = " 
IIf( not ConcernAsIsByClientTable.LongTextConcern_LongText = " & Chr(34) & Chr(34) & ",  " &
                                       Chr(34) & " Diagnose " & Chr(34) & ",  " &
                                         " InformationsHeadersTypeTable.ConcernPrefix_ShortText50, " & ") 
"

        Dim ConcernDescription = " 
IIf( not ConcernAsIsByClientTable.LongTextConcern_LongText = " & Chr(34) & Chr(34) & ",  " &
                                       " ConcernAsIsByClientTable.LongTextConcern_LongText, " &
                                        " MasterCodeBookTable.SystemDesc_ShortText100Fld) as  CoinedConcern, 
"

        ConcernDescription = ActionToTake & " & Space(1) & " & ConcernDescription


        WorkOrderConcernsFieldsToSelect =
 " 
 Select 
 WorkOrderConcernsTable.WorkOrderConcernID_AutoNumber,
 WorkOrderConcernsTable.WorkOrderID_LongInteger,
 WorkOrderConcernsTable.ConcernID_LongInteger,
 WorkOrderConcernsTable.ConcernLongTextCodeID_LongInteger,
 ConcernsTable.InformationsHeadersTypeID_LongInteger,
 ConcernsTable.Concern_ShortText255,
 InformationsHeadersTypeTable.ConcernPrefix_ShortText50, 
 " & ConcernDescription &
 " 
 MasterCodeBookTable.SystemDesc_ShortText100Fld,
 LongTextConcern_LongText,
OriginalExcelRecordTable.description 
, StatusesTable.StatusText_ShortText25
FROM (((((WorkOrderConcernsTable LEFT JOIN ConcernsTable ON WorkOrderConcernsTable.ConcernID_LongInteger = ConcernsTable.ConcernID_AutoNumber) LEFT JOIN InformationsHeadersTypeTable ON ConcernsTable.InformationsHeadersTypeID_LongInteger = InformationsHeadersTypeTable.InformationsHeadersTypeID_AutoNumber) LEFT JOIN MasterCodeBookTable ON ConcernsTable.MasterCodeBookId_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) LEFT JOIN ConcernAsIsByClientTable ON WorkOrderConcernsTable.ConcernLongTextCodeID_LongInteger = ConcernAsIsByClientTable.LongTextConcernID_Autonumber) LEFT JOIN OriginalExcelRecordTable ON WorkOrderConcernsTable.OriginalID_LongInteger = OriginalExcelRecordTable.OriginalID_AutoNumber) LEFT JOIN StatusesTable ON WorkOrderConcernsTable.WorkOrderConcernStatusID_LongInteger = StatusesTable.StatusID_Autonumber
"
        WorkOrderConcernsSelectionFilter = " WHERE WorkOrderConcernsTable.WorkOrderID_LongInteger = " & Str(CurrentWorkOrderID)

        MySelection = WorkOrderConcernsFieldsToSelect & WorkOrderConcernsSelectionFilter & WorkOrderConcernsSelectionOrder
        JustExecuteMySelection()

        WorkOrderConcernsRecordCount = RecordCount
        If RecordCount > 0 Then
            WorkOrderConcernsDataGridView.Visible = True
        Else
            WorkOrderConcernsDataGridView.Visible = False
        End If

        WorkOrderConcernsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        '=======================================================================================


        If Not WorkOrderConcernsDataGridViewAlreadyFormated Then
            WorkOrderConcernsDataGridViewAlreadyFormated = True
            FormatWorkOrderConcernsDataGridView()
        End If

        Dim NoOfHeaderLines = 1
        Dim RecordsDisplyed = WorkOrderConcernsRecordCount
        Dim FormLowPointFromGrid = 90
        If WorkOrderConcernsRecordCount > 10 Then
            RecordsDisplyed = 10
        Else
            RecordsDisplyed = WorkOrderConcernsRecordCount
        End If

        WorkOrderConcernsDataGridView.Height = (WorkOrderConcernsDataGridView.ColumnHeadersHeight * NoOfHeaderLines * 2) + (DataGridViewRowHeight * (RecordsDisplyed + 1))

    End Sub

    Private Sub FormatWorkOrderConcernsDataGridView()


        Dim HeightToAdd = IIf(WorkOrderConcernsRecordCount = 0, 0, ((WorkOrderConcernsRecordCount) * DataGridViewRowHeight))
        WorkOrderConcernsDataGridView.Height = WorkOrderConcernsDataGridView.ColumnHeadersHeight + HeightToAdd + 100

        WorkOrderConcernsDataGridView.Width = 0

        For i = 0 To WorkOrderConcernsDataGridView.Columns.GetColumnCount(0) - 1

            WorkOrderConcernsDataGridView.Columns.Item(i).Visible = False

            Select Case WorkOrderConcernsDataGridView.Columns.Item(i).Name
                Case "CoinedConcern"
                    WorkOrderConcernsDataGridView.Columns.Item(i).HeaderText = "CONCERN"
                    WorkOrderConcernsDataGridView.Columns.Item(i).Width = 500
                    WorkOrderConcernsDataGridView.Columns.Item(i).Visible = True
                Case "Concern_ShortText255"
                    WorkOrderConcernsDataGridView.Columns.Item(i).HeaderText = "Concern_ShortText255"
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


        If WorkOrderConcernsDataGridView.Width > Me.Width Then
            WorkOrderConcernsDataGridView.Width = Me.Width - 4
        End If
        WorkOrderConcernsDataGridView.Left = (Me.Width - WorkOrderConcernsDataGridView.Width) / 2

        Me.Location = New Point(Me.Location.X, 55)
        WorkOrdersDataGridView.Left = (Me.Width - WorkOrdersDataGridView.Width) / 2
        '===========================

    End Sub
    Private Sub WorkOrderConcernsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles WorkOrderConcernsDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If WorkOrderConcernsRecordCount = 0 Then Exit Sub

        CurrentWorkOrderConcernsRow = e.RowIndex
        RemoveConcernOrJobToolStripMenuItem.Visible = False
        If Not WorkOrderConcernsDataGridViewInitialized Then
            WorkOrderConcernsDataGridViewInitialized = True
        End If

        CurrentWorkOrderConcernID = WorkOrderConcernsDataGridView.Item("WorkOrderConcernID_AutoNumber", CurrentWorkOrderConcernsRow).Value
        CurrentConcernID = WorkOrderConcernsDataGridView.Item("ConcernID_LongInteger", CurrentWorkOrderConcernsRow).Value
        CurrentLongTextConcernID = WorkOrderConcernsDataGridView.Item("ConcernID_LongInteger", CurrentWorkOrderConcernsRow).Value
        CurrentWorkOrderConcernStatus = WorkOrderConcernsDataGridView.Item("StatusText_ShortText25", CurrentWorkOrderConcernsRow).Value
        EditConcernToolStripMenuItem.Visible = False
        PrintBillToolStripMenu.Visible = False
        If IsEmpty(CurrentWorkOrderConcernStatus) Then
            MsgBox("fixthis, null WorkOrderConcernStatus in the workorderConcernsTable")
        Else
            Select Case CurrentWorkOrderConcernStatus
                Case "Draft Work Order"
                    EditConcernToolStripMenuItem.Visible = True
                    If WorkOrderDetailsGroup.Visible = False Then
                        RemoveConcernOrJobToolStripMenuItem.Visible = True
                    End If
            End Select
        End If
    End Sub
    Private Sub FillAllWorkOrdersPartsDataGridView()
        'USING WorkOrderPartsForCRSQuery
        AllWorkOrderPartsFieldsToSelect =
"Select 
WorkOrderPartsTable.WorkOrderPartID_AutoNumber,
WorkOrderPartsTable.WorkOrderConcernJobID_LongInteger,
WorkOrderPartsTable.ProductPartID_LongInteger,
WorkOrderPartsTable.Quantity_Integer, 
WorkOrderPartsTable.Price_Currency,
ProductsPartsTable.ManufacturerPartNo_ShortText30Fld,
ProductsPartsTable.ProductDescription_ShortText250,
WorkOrderConcernsTable.WorkOrderID_LongInteger
FROM ((WorkOrderPartsTable LEFT JOIN ProductsPartsTable ON WorkOrderPartsTable.ProductPartID_LongInteger = ProductsPartsTable.ProductsPartID_Autonumber) LEFT JOIN WorkOrderConcernJobsTable ON WorkOrderPartsTable.WorkOrderConcernJobID_LongInteger = WorkOrderConcernJobsTable.WorkOrderConcernJobID_AutoNumber) LEFT JOIN WorkOrderConcernsTable ON WorkOrderConcernJobsTable.WorkOrderConcernID_LongInteger = WorkOrderConcernsTable.WorkOrderConcernID_AutoNumber
"
        MySelection = AllWorkOrderPartsFieldsToSelect & AllWorkOrderPartsTablesLinks & AllWorkOrderPartsSelectionFilter & AllWorkOrderPartsSelectionOrder

        JustExecuteMySelection()
        AllWorkOrderPartsRecordCount = RecordCount
        If RecordCount > 0 Then
            AllWorkOrderPartsDataGridView.Visible = True
        End If
        AllWorkOrderPartsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If Not AllWorkOrderPartsDataGridViewAlreadyFormated Then
            AllWorkOrderPartsDataGridViewAlreadyFormated = True
            FormatAllWorkOrderPartsDataGridView()
        End If
    End Sub

    Private Sub FormatAllWorkOrderPartsDataGridView()
        AllWorkOrderPartsDataGridView.Width = 0
        For i = 0 To AllWorkOrderPartsDataGridView.Columns.GetColumnCount(0) - 1

            Dim DoNotDisplayFields = ", " &
                                     " , "

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

        ' NOTE" SYSTEM AUTOFITS THE GRIDVIEW FIELDS ACCORDING To THEIR WITDH

        If AllWorkOrderPartsDataGridView.Width > Me.Width + 20 Then
            AllWorkOrderPartsDataGridView.Width = Me.Width - 80
        Else
            AllWorkOrderPartsDataGridView.Width = AllWorkOrderPartsDataGridView.Width + 20
            Dim LargestWidth = AllWorkOrderPartsDataGridView.Width
        End If
        ' NOTE IF YOU WANT TO CENTER THE GRIDVIEW
        '       AllWorkOrderPartsDataGridView.Left = (Me.Width - AllWorkOrderPartsDataGridView.Width) / 2
    End Sub


    Public Sub SetupWorkOrderSelection(WorkOrderStatusSelection)
        Select Case WorkOrderStatusSelection
            Case 0
                Select Case CurrentUserGroup
                    Case "Customer Relations Specialist"
                        WorkOrdersSelectionFilter = SetupTableSelectionFilter(GetStatusIdFor("WorkOrdersTable", "Draft Work Order", 1), 2, Me, "Draft Work Order and For Billing")
                        Dim xx2ndFilter = SetupTableSelectionFilter(GetStatusIdFor("WorkOrdersTable", "For Billing", 1), 2, Me, "Draft Work Order and For Billing")
                        WorkOrdersSelectionFilter += " OR " & Replace(xx2ndFilter, "WHERE", Space(1))
                    Case "Lead Service Specialist"
                        WorkOrdersSelectionFilter = " WHERE (StatusSequence_LongInteger  > " & GetStatusIdFor("WorkOrdersTable", "For Analysis", 1) &
                                               " AND StatusSequence_LongInteger  <  " & GetStatusIdFor("WorkOrdersTable", "For Billing", 1) &
                                               ") AND AssignedLeadMechanic_longInteger = " & CurrentPersonelID.ToString
                End Select
            Case 10
                WorkOrdersSelectionFilter = ""
                Me.Text = "ALL WORK ORDERS"
        End Select
        FillWorkOrdersDataGridView()
    End Sub

    Private Sub DetermineOptionsAccess()
        If CurrentWorkOrderStatus = 0 Then
            EnableEdit()
        Else
            DisableEdit()
        End If
    End Sub
    Private Sub EnableEdit()
        EditWorkOrderToolStripMenuItem.Visible = True
        DeleteWorkOrderToolStripMenuItem.Visible = True
        AddWorkOrderConcernToolStripMenuItem.Visible = True
    End Sub
    Private Sub DisableEdit()
        EditWorkOrderToolStripMenuItem.Visible = False
        DeleteWorkOrderToolStripMenuItem.Visible = False
    End Sub
    Private Sub WorkOrdersDataGridView_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles WorkOrdersDataGridView.DataBindingComplete
        If ShowInTaskbarFlag Then Exit Sub
        If WorkOrdersRecordCount = 0 Then
            CurrentWorkOrderID = -1
            FillWorkOrderConcernsDataGridView()
        End If
    End Sub

    Private Sub WorkOrderConcernsDataGridView_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs)
        Dim HeightToAdd = IIf(WorkOrderConcernsRecordCount = 0, 0, ((WorkOrderConcernsRecordCount) * DataGridViewRowHeight))
        WorkOrderConcernsDataGridView.Height = WorkOrderConcernsDataGridView.ColumnHeadersHeight + HeightToAdd + 22



    End Sub
    Private Sub LoadWorkOrderDetails()
        Dim xxWorkOrderID_AutoNumber = WorkOrdersDataGridView("WorkOrderID_AutoNumber", CurrentWorkOrderRow).Value

        SetParentRecordReference("WorkOrdersTable", "WorkOrderID_AutoNumber", xxWorkOrderID_AutoNumber)
        Dim r As DataRow
        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)


        '       CurrentInformationsHeaderCode = r("SubSystemCode_ShortText24Fld")
        If Not IsDBNull(r("WorkOrderNumber_ShortText12")) Then
            WorkOrderNumberTextBox.Text = r("WorkOrderNumber_ShortText12")
        End If
        If Not IsDBNull(r("ServiceDate_DateTime")) Then
            ServiceDate_DateTimeTextBox.Text = r("ServiceDate_DateTime")
        End If
        If Not IsDBNull(r("ReleaseDate_DateTime")) Then
            DateTimeOutTextBox.Text = r("ReleaseDate_DateTime")
        End If

        MilageMaskedTextBox.Text = IIf(IsDBNull(r("VehicleMilage_Integer")), "", r("VehicleMilage_Integer"))
        CustomerTextBox.Text = WorkOrdersDataGridView.Item("OwnerName", CurrentWorkOrderRow).Value
        If IsNotEmpty(WorkOrdersDataGridView("VinNo_ShortText20", CurrentWorkOrderRow).Value) Then
            VINTextBox.Text = WorkOrdersDataGridView("VinNo_ShortText20", CurrentWorkOrderRow).Value
        End If
        VehicleDetailsTextBox.Text = WorkOrdersDataGridView.Item("VehicleModels", CurrentWorkOrderRow).Value

    End Sub
    Private Sub LoadConcerns()
        FillWorkOrderConcernsDataGridView()


    End Sub


    Private Sub WorkOrderForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged

        If Me.Enabled = False Then Exit Sub
        CallingForm = SavedCallingForm
        Select Case Tunnel1
            Case "Tunnel2IsConcernID"
                CurrentConcernID = Tunnel2
                SaveNewWorkOrderConcern()
                FillWorkOrderConcernsDataGridView()
            Case "Tunnel2IsLongTextConcernID"
                CurrentLongTextConcernID = Tunnel2
                SaveNewWorkOrderConcern()
                FillWorkOrderConcernsDataGridView()
            Case "Tunnel2IsCustomerID"
                AddWorkOrderToolStripMenuItem.Visible = False
                EditWorkOrderToolStripMenuItem.Visible = False
                ViewToolStripMenuItem.Visible = False
                CurrentCustomerID = Tunnel2
                CurrentServicedVehicleID = Tunnel4
            Case "Tunnel2IsPersonnelID"
                AssignedPersonnelID = Tunnel2 ' i think this is not needed. customer info can be obtained through the usedVehicleId
                AssignThisWorkOrder()
            Case "Tunnel2IsServicedVehicleID"
                CurrentServicedVehicleID = Tunnel2
            Case "cancelled"


        End Select

    End Sub

    Private Sub SaveNewWorkOrderConcern()
        If CurrentConcernID > 0 Then
            WorkOrderConcernsSelectionFilter = " WHERE WorkOrderID_LongInteger = " & CurrentWorkOrderID.ToString &
                                            " AND ConcernID_LongInteger = " & CurrentConcernID.ToString
        Else
            WorkOrderConcernsSelectionFilter = " WHERE WorkOrderID_LongInteger = " & CurrentWorkOrderID.ToString &
                                            " AND ConcernLongTextCodeID_LongInteger = " & CurrentLongTextConcernID.ToString
        End If

        WorkOrderConcernsFieldsToSelect = " SELECT top 1 * FROM WorkOrderConcernsTable "

        MySelection = WorkOrderConcernsFieldsToSelect & WorkOrderConcernsSelectionFilter

        If RecordIsFound() Then
            MsgBox("This concern is already linked")
            Exit Sub
        End If

        Dim FieldsToUpdate = "  WorkOrderID_LongInteger, " &
                             "  TextType_Byte, " &
                             "  ConcernID_LongInteger, " &
                             " WorkOrderConcernStatusID_LongInteger, " &
                             " ConcernLongTextCodeID_LongInteger"

        Dim FieldsData = Str(CurrentWorkOrderID) & ",  " &
                         Str(1) & ",  " &
                         CurrentConcernID.ToString & ",  " &
                         GetStatusIdFor("WorkOrderConcernsTable").ToString & ",  " &
                         CurrentLongTextConcernID.ToString


        CurrentWorkOrderConcernID = InsertNewRecord("WorkOrderConcernsTable", FieldsToUpdate, FieldsData)

        FillWorkOrdersDataGridView()
    End Sub
    Private Sub AssignThisWorkOrder()

        WorkOrdersSelectionFilter = " WHERE WorkOrderID_AutoNumber = " & Str(CurrentWorkOrderID)
        Select Case CurrentUserGroup
            Case "Customer Relations Specialist"
                MsgBox("note WorkOrderStatus_Byte was DELETED, BREAK ")
                '                 " WorkOrderStatus_Byte = 2, " & ' for lead mechanic to re assign jobs to specialists
                WorkOrdersFieldsToSelect = " UPDATE WorkOrdersTable  SET " &
                    " WorkOrderStatusID_LongInteger = " & GetStatusIdFor("WorkOrdersTable", "For Analysis") & ", " & ' for lead mechanic to re assign jobs to specialists
                  " AssignedLeadMechanic_longInteger = " & Str(AssignedPersonnelID) & ", " &
                   " ServiceManagerAssigning_LongInteger = " & Str(CurrentUserID)
        End Select
        MySelection = WorkOrdersFieldsToSelect & WorkOrdersSelectionFilter
        JustExecuteMySelection()
        For i = 0 To WorkOrderConcernsRecordCount - 1
            WorkOrderConcernsSelectionFilter = " WHERE WorkOrderConcernID_AutoNumber = " & Str(CurrentWorkOrderConcernID)
            CurrentWorkOrderConcernID = WorkOrderConcernsDataGridView.Item("WorkOrderConcernID_AutoNumber", i).Value
            WorkOrdersFieldsToSelect = " UPDATE WorkOrderConcernsTable  SET " &
                    " WorkOrderConcernStatusID_LongInteger = " & GetStatusIdFor("WorkOrderConcernsTable", "No Action Yet")
        Next
    End Sub


    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddWorkOrderToolStripMenuItem.Click
        PurposeOfEntry = "ADD"
        CurrentWorkOrderID = -1
        WorkOrderDetailsGroup.Visible = True
    End Sub
    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditWorkOrderToolStripMenuItem.Click
        PurposeOfEntry = "EDIT"
        WorkOrderDetailsGroup.Visible = True
    End Sub

    Private Sub DeleteWorkOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteWorkOrderToolStripMenuItem.Click
        PurposeOfEntry = "DELETE"
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
        MySelection = "DELETE FROM WorkOrdersTable WHERE WorkOrderID_AutoNumber = " & Str(CurrentWorkOrderID)

        JustExecuteMySelection()
        WorkOrderDetailsGroup.Visible = False
        If ThisRecordNotYetExistsInTheWorkOrdersTable() Then
            MsgBox("Successfuly deleted the record")
        Else
            MsgBox("UnSuccessfuly deleted the record, ????????")
        End If
        FillWorkOrdersDataGridView()
    End Sub

    Private Sub RemoveConcernToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveConcernOrJobToolStripMenuItem.Click
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

    Private Sub OutstandingWorkOrdersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OutstandingWorkOrdersToolStripMenuItem.Click
        If Not WorkOrderStatusSelection = 0 Then SetupWorkOrderSelection(0)
        WorkOrderStatusSelection = 0
    End Sub
    Private Sub ForFinalizationBillingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ForFinalizationBillingToolStripMenuItem.Click
        If Not WorkOrderStatusSelection = 3 Then SetupWorkOrderSelection(3)
    End Sub
    Private Sub CompletedWorkOrdersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompletedWorkOrdersToolStripMenuItem.Click
        If Not WorkOrderStatusSelection = 9 Then SetupWorkOrderSelection(9)
        WorkOrderStatusSelection = 9
    End Sub
    Private Sub AllWorkOrdersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllWorkOrdersToolStripMenuItem.Click
        WorkOrdersSelectionFilter = " WHERE CustomerServiceSpecialist = " & CurrentPersonelID.ToString
        If MsgBox("Do you want to view all regardless of Custumer Service Specialist", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then WorkOrdersSelectionFilter = ""
        FillWorkOrdersDataGridView()
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
            DoCommonHouseKeeping(Me, SavedCallingForm)
        End If
    End Sub

    Private Sub AddToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles AddWorkOrderConcernToolStripMenuItem.Click
        CurrentLongTextConcernID = -1
        CurrentConcernID = -1
        ShowCalledForm(Me, ConcernsForm)
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
        If IsNotEmpty(CustomerTextBox.Text) Then
            If OwnersForm.NameSearchTextBox.Text = CustomerTextBox.Text Then
                If Trim(CustomerTextBox.Text) = Trim(SavedCustomer) Then
                    Exit Sub
                Else
                    CustomerTextBox.Text = ""
                    OwnersForm.NameSearchTextBox.Text = CustomerTextBox.Text
                End If
                ShowOwnerForm()
            End If
            If Len(Trim(CustomerTextBox.Text)) = 1 Then
                OwnersForm.NameSearchTextBox.Text = CustomerTextBox.Text
            End If
        End If

    End Sub
    Public Sub ShowOwnerForm()
        If CurrentCustomerID > 0 Then
            Tunnel1 = "Tunnel2IsOwnerID"
            Tunnel2 = CurrentCustomerID
        End If
        ShowCalledForm(Me, OwnersForm)
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
            EnableEdit()
            ConcernOrJobToolStripMenuItem.Visible = True
            AddWorkOrderConcernToolStripMenuItem.Visible = True
            SaveWorkOrderToolStripMenuItem.Visible = False
            WorkOrderToolStripMenuItem.Text = "WORK ORDERS :"

        Else
            ' SHOWN
            If CurrentWorkOrderID > 0 Then
                LoadWorkOrderDetails()
            End If
            WorkOrdersDataGridView.Enabled = False
            WorkOrderConcernsDataGridView.Enabled = False
            DisableEdit()
            ConcernOrJobToolStripMenuItem.Visible = False
            AddWorkOrderConcernToolStripMenuItem.Visible = False
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
        CurrentServicedVehicleID = -1

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
        Dim SavedWorkOrderSelectionFilter = WorkOrdersSelectionFilter
        Select Case PurposeOfEntry
            Case "ADD"
                WorkOrderNumberTextBox.Text = GetNewWorkOrderID(Convert.ToDateTime(Trim(ServiceDate_DateTimeTextBox.Text)), Trim(MilageMaskedTextBox.Text))
                If ThisRecordNotYetExistsInTheWorkOrdersTable() Then
                    RegisterNewWorkOrder()
                Else
                    MsgBox(" Record Is already registerd")
                    DoCommonHouseKeeping(Me, SavedCallingForm)
                    Exit Sub
                End If
            Case = "EDIT"
                If Not MsgBox(" Confirm Saving changes to Work Order Details", vbYesNo) = vbYes Then
                    Exit Sub
                End If
                UpdateThisWorkOrderRecord()
        End Select
        WorkOrdersSelectionFilter = SavedWorkOrderSelectionFilter
        WorkOrderDetailsGroup.Visible = False
        SetupWorkOrderSelection(0)
    End Sub
    Private Sub UpdateThisWorkOrderRecord()

        WorkOrdersSelectionFilter = " WHERE WorkOrderID_AutoNumber = " & Str(CurrentWorkOrderID)
        WorkOrderNumberTextBox.Text = GetNewWorkOrderID(Convert.ToDateTime(Trim(ServiceDate_DateTimeTextBox.Text)), Trim(MilageMaskedTextBox.Text))
        WorkOrdersFieldsToSelect = " UPDATE WorkOrdersTable  SET " &
                    "  WorkOrderNumber_ShortText12 = " & InQuotes(WorkOrderNumberTextBox.Text) & ", " &
                    " ServicedVehicleID_LongInteger = " & Str(CurrentServicedVehicleID) & ", " &
                    " ServiceDate_DateTime = " & Chr(34) & Trim(ServiceDate_DateTimeTextBox.Text) & Chr(34) & ", " &
                    " VehicleMilage_Integer = " & MilageMaskedTextBox.Text


        MySelection = WorkOrdersFieldsToSelect & WorkOrdersSelectionFilter
        JustExecuteMySelection()

    End Sub

    Private Function ThisRecordNotYetExistsInTheWorkOrdersTable()
        MySelection = "SELECT * " &
                       " FROM WorkOrdersTable " &
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
        RemoveConcernOrJobToolStripMenuItem.Visible = True
    End Sub
    Private Sub AddAWorkOrderRecord()
        'record was first Ownered if it already exist in the workorder table

        Dim WorkOrderNumber = GetNewWorkOrderID(Convert.ToDateTime(Trim(ServiceDate_DateTimeTextBox.Text)), Trim(MilageMaskedTextBox.Text))
        Dim MilageField = ""
        Dim Milage = ""
        If IsNotEmpty(MilageMaskedTextBox.Text) Then
            MilageField = " VehicleMilage_Integer, "
            Milage = Replace(MilageMaskedTextBox.Text, ",", "")
            Milage = Milage & ", "
        End If
        ' EXECUTE INSERT COMMAND
        Dim FieldsToUpdate =
                    " WorkOrderNumber_ShortText12, " &
                    " ServicedVehicleID_LongInteger, " &
                    " ServiceDate_DateTime, " &
                    MilageField &
                    " CustomerServiceInCharge_LongInteger, " &
                    " WorkOrderStatusID_LongInteger "

        Dim FieldsData =
                    Chr(34) & WorkOrderNumberTextBox.Text & Chr(34) & ", " &
                    Str(CurrentServicedVehicleID) & ", " &
                    Chr(34) & Trim(ServiceDate_DateTimeTextBox.Text) & Chr(34) & ", " &
                      Milage &
                    Str(CurrentPersonelID) & ", " &
                    GetStatusIdFor("WorkOrdersTable")


        CurrentWorkOrderID = InsertNewRecord("WorkOrdersTable", FieldsToUpdate, FieldsData)

        JustExecuteMySelection()

        If ThisRecordNotYetExistsInTheWorkOrdersTable() Then
            MsgBox("unsuccesful insert")
        End If
    End Sub

    Private Sub WorkOrderDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WorkOrderDetailsToolStripMenuItem.Click
        PurposeOfEntry = "VIEW"
        WorkOrderDetailsGroup.BringToFront()
        WorkOrderDetailsGroup.Visible = True
        WorkOrderDetailsGroup.Enabled = False
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PrintWorkOrderToolStripMenuItem.Click
        MsgBox("Print you Work Order Here")

    End Sub

    Private Sub SubmitForServiceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SubmitForServiceToolStripMenuItem.Click
        If WorkOrderConcernsRecordCount = 0 Then
            MsgBox("NO concern is attached yet")
        End If

        If Not MsgBox("Do you want to Submit the Work Order now to the Service Department?", vbYesNo) = vbYes Then
            Exit Sub
        End If

        WorkOrdersSelectionFilter = " WHERE WorkOrderID_AutoNumber = " & Str(CurrentWorkOrderID)
        WorkOrdersFieldsToSelect = " UPDATE WorkOrdersTable  SET " &
                    " WorkOrderStatusID_LongInteger =  " & GetStatusIdFor("WorkOrdersTable", "For Analysis")
        MySelection = WorkOrdersFieldsToSelect & WorkOrdersSelectionFilter
        JustExecuteMySelection()

        SetupWorkOrderSelection(0)
        WorkOrderStatusSelection = 0

        FillWorkOrdersDataGridView()
    End Sub
    Private Sub AssignWorkOrderToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If CurrentWorkOrderStatus > 2 Then      'already assigned to lead engineer
            MsgBox("this work order has been already assigned ")
        Else
            ShowPersonnelForm()
        End If
    End Sub
    Public Sub ShowPersonnelForm()
        ShowCalledForm(Me, PersonnelsForm)
    End Sub

    Private Sub EditToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles EditConcernToolStripMenuItem.Click
        PurposeOfEntry = "EDIT"
        ShowCalledForm(Me, ConcernsForm)
    End Sub

    Private Sub ServiceDate_DateTimeTextBox_Click(sender As Object, e As EventArgs) Handles ServiceDate_DateTimeTextBox.Click
        If MsgBox("DO YOU INTEND TO REPLACE THE DATE", vbYesNo) = MsgBoxResult.No Then Exit Sub
        ServiceDate_DateTimeTextBox.Text = Now()

    End Sub

    Private Sub PrintBillToolStripMenu_Click(sender As Object, e As EventArgs) Handles PrintBillToolStripMenu.Click
        Tunnel1 = CurrentWorkOrderID
        ShowCalledForm(Me, PrintBillsForm)
    End Sub
End Class