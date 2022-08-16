Imports System.Drawing.Printing

Public Class PrintBillsForm
    Dim WithEvents PD As New PrintDocument
    Dim PPD As New PrintPreviewDialog
    Dim LongPaper As Integer

    Private WorkOrdersFieldsToSelect = ""
    Private WorkOrdersSelectionFilter = ""
    Private WorkOrdersSelectionOrder = ""
    Private WorkOrdersRecordCount As Integer = -1
    Private WorkOrdersDataGridViewAlreadyFormated = False
    Private CurrentWorkOrdersRow As Integer = -1
    Private CurrentWorkOrderID = -1

    Private WorkOrderConcernsFieldsToSelect = ""
    Private WorkOrderConcernsSelectionFilter = ""
    Private WorkOrderConcernsSelectionOrder = ""
    Private WorkOrderConcernsDataGridViewAlreadyFormatted = False
    Private CurrentInformationsHeaderID As Integer
    Private WorkOrderConcernsRecordCount = -1
    Private CurrentWorkOrderConcernsRow = -1
    Private CurrentWorkOrderConcernID = -1
    Private CurrentConcernID = -1
    Private CurrentLongTextConcernID = -1

    Private WorkOrderConcernJobsFieldsToSelect = " "
    Private WorkOrderConcernJobsSelectionFilter = " "
    Private WorkOrderConcernJobsSelectionOrder = " "
    Private WorkOrderConcernJobsRecordCount = 0
    Private WorkOrderConcernJobsDataGridViewFormatted = False
    Private CurrentWorkOrderConcernJobID As Integer = -1
    Private CurrentWorkOrderConcernJobsRow = -1

    Private WorkOrderPartsPerJobFieldsToSelect = " "
    Private WorkOrderPartsPerJobSelectionFilter = " "
    Private WorkOrderPartsPerJobSelectionOrder = " "
    Private WorkOrderPartsPerJobRecordCount = 0
    Private WorkOrderPartsPerJobDataGridViewAlreadyFormatted = False
    Private CurrentWorkOrderPartsPerJobID As Integer = -1
    Private CurrentWorkOrderPartsPerJobRow = -1

    Private RighStringFormat As New StringFormat
    Private CenterStringFormat As New StringFormat
    Private F8 As New Font("Calibri", 8, FontStyle.Regular)

    Private F10 As New Font("Calibri", 10, FontStyle.Regular)
    Private F12 As New Font("Calibri", 12, FontStyle.Regular)
    Private F12b As New Font("Calibri", 12, FontStyle.Bold)
    Private F14 As New Font("Calibri", 12, FontStyle.Regular)

    Private LeftMargin As Integer
    Private CenterMargin As Integer
    Private RightMargin As Integer
    Private FormHeight As Integer


    Private SavedCallingForm As Form

    Private Sub WorkOrderForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SavedCallingForm = CallingForm
        WorkOrdersSelectionFilter = " WHERE WorkOrderID_AutoNumber = " & Tunnel1.ToString
        FillWorkOrdersDataGridView()
        WorkOrdersGroupBox.Top = PrintBillsMenuStrip.Top + PrintBillsMenuStrip.Height
        WorkOrderConcernsGroupBox.Top = WorkOrdersGroupBox.Top + WorkOrdersGroupBox.Height
        WorkOrderConcernJobsGroupBox.Top = WorkOrderConcernsGroupBox.Top + WorkOrderConcernsGroupBox.Height
        WorkOrderPartsPerJobGroupBox.Top = WorkOrderConcernJobsGroupBox.Top + WorkOrderConcernJobsGroupBox.Height
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
trim(VehicleTrimTable.VehicleTrimName_ShortText25)) AS VehicleDescription,
(trim(OwnersTable.FirstName_ShortText30) & space(1) & 
Trim(OwnersTable.LastName_ShortText30) & space(1) & 
trim(OwnersTable.NamePrefix_ShortText3)) AS VehicleOwner,
ServicedVehiclesTable.VinNo_ShortText20,
OwnersTable.TelNo_ShortText10, 
(trim(CSSTable.FirstName_ShortText30) & space(1) & Trim(CSSTable.LastName_ShortText30)) AS CustomerServiceSpecialist, 
(trim(ALMTable.FirstName_ShortText30) & space(1) & Trim(ALMTable.LastName_ShortText30)) AS leadMechanic, 
WorkOrdersTable.WorkOrderID_AutoNumber,
WorkOrdersTable.CustomerServiceInCharge_LongInteger,
WorkOrdersTable.ServiceManagerAssigning_LongInteger,
WorkOrdersTable.WorkOrderStatusID_LongInteger,
StatusesTable.StatusSequence_LongInteger,
StatusesTable.StatusText_ShortText25 AS WorkOrderStatus
FROM ((((((((((WorkOrdersTable LEFT JOIN ServicedVehiclesTable ON WorkOrdersTable.ServicedVehicleID_LongInteger = ServicedVehiclesTable.ServicedVehicleID_AutoNumber) LEFT JOIN OwnersTable ON ServicedVehiclesTable.OwnerID_LongInteger = OwnersTable.OwnerID_AutoNumber) LEFT JOIN VehiclesTable ON ServicedVehiclesTable.VehicleID_LongInteger = VehiclesTable.VehicleID_AutoNumber) LEFT JOIN VehicleModelsRelationsTable ON VehiclesTable.VehicleModelsRelationID_LongInteger = VehicleModelsRelationsTable.VehicleModelsRelationID_Autonumber) LEFT JOIN VehicleTypeTable ON VehicleModelsRelationsTable.VehicleTypeID_LongInteger = VehicleTypeTable.VehicleTypeID_AutoNumber) LEFT JOIN VehicleTrimTable ON VehicleModelsRelationsTable.VehicleTrimID_LongInteger = VehicleTrimTable.VehicleTrimID_Autonumber) LEFT JOIN VehicleModelsTable ON VehicleModelsRelationsTable.VehicleModelID_LongInteger = VehicleModelsTable.VehicleModelID_Autonumber) LEFT JOIN PersonnelTable AS CSSTable ON WorkOrdersTable.CustomerServiceInCharge_LongInteger = CSSTable.PersonnelID_AutoNumber) LEFT JOIN PersonnelTable AS ASMTable ON WorkOrdersTable.ServiceManagerAssigning_LongInteger = ASMTable.PersonnelID_AutoNumber) LEFT JOIN PersonnelTable AS ALMTable ON WorkOrdersTable.AssignedLeadMechanic_longInteger = ALMTable.PersonnelID_AutoNumber) LEFT JOIN StatusesTable ON WorkOrdersTable.WorkOrderStatusID_LongInteger = StatusesTable.StatusID_Autonumber
"

        MySelection = WorkOrdersFieldsToSelect & WorkOrdersSelectionFilter & WorkOrdersSelectionOrder

        JustExecuteMySelection()
        WorkOrdersRecordCount = RecordCount

        If WorkOrdersRecordCount > 0 Then
            WorkOrdersGroupBox.Visible = True
        Else
            WorkOrdersGroupBox.Visible = False
        End If
        WorkOrdersDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable


        ' HERE AT ROW_ENTER, FillWorkOrderConcernsDataGridView is called and WorkOrderConcernsbOX IS ALREADY FORMATTED
        If Not WorkOrdersDataGridViewAlreadyFormated Then
            FormatWorkOrdersDataGridView()
            SetFormWidthAndGroupBoxLeft()
        End If

        Dim RecordsToDisplay = 5
        SetGroupBoxHeight(RecordsToDisplay, WorkOrdersRecordCount, WorkOrdersGroupBox, WorkOrdersDataGridView)

    End Sub
    Private Sub FormatWorkOrdersDataGridView()
        WorkOrdersDataGridViewAlreadyFormated = True
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
                Case "VehicleOwner"
                    WorkOrdersDataGridView.Columns.Item(i).HeaderText = "OWNER"
                    WorkOrdersDataGridView.Columns.Item(i).Width = 150
                    WorkOrdersDataGridView.Columns.Item(i).Visible = True
                Case "TelNo_ShortText10"
                    WorkOrdersDataGridView.Columns.Item(i).HeaderText = "TEL. NO."
                    WorkOrdersDataGridView.Columns.Item(i).Width = 100
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

        WorkOrderConcernsSelectionFilter = " WHERE WorkOrderConcernsTable.WorkOrderID_LongInteger = " & CurrentWorkOrderID.ToString
        FillWorkOrderConcernsDataGridView()

    End Sub


    Private Sub FillWorkOrderConcernsDataGridView()
        Dim ActionToTake = " 
IIf( not ConcernAsIsByClientTable.LongTextConcern_LongText = " & Chr(34) & Chr(34) & ",  " &
                                       Chr(34) & " Diagnose " & Chr(34) & ",  " &
                                         " InformationsHeadersTypeTable.InformationsHeadersTypePrefix_ShortText50, " & ") 
"
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
WorkOrderConcernsTable.AssignedServiceSpecialist_LongInteger,
ConcernsTable.InformationsHeadersTypeID_LongInteger,
ConcernsTable.Concern_ShortText255,
InformationsHeadersTypeTable.InformationsHeadersTypePrefix_ShortText50, " &
ConcernDescription &
" 
MasterCodeBookTable.SystemDesc_ShortText100Fld,
LongTextConcern_LongText
    FROM ((((((WorkOrderConcernsTable LEFT JOIN ConcernsTable ON WorkOrderConcernsTable.ConcernID_LongInteger = ConcernsTable.ConcernID_AutoNumber) LEFT JOIN InformationsHeadersTypeTable ON ConcernsTable.InformationsHeadersTypeID_LongInteger = InformationsHeadersTypeTable.InformationsHeadersTypeID_AutoNumber) LEFT JOIN MasterCodeBookTable ON ConcernsTable.MasterCodeBookId_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) LEFT JOIN ConcernAsIsByClientTable ON WorkOrderConcernsTable.ConcernLongTextCodeID_LongInteger = ConcernAsIsByClientTable.LongTextConcernID_Autonumber) LEFT JOIN OriginalExcelRecordTable ON WorkOrderConcernsTable.OriginalID_LongInteger = OriginalExcelRecordTable.OriginalID_AutoNumber) LEFT JOIN PersonnelTable ON WorkOrderConcernsTable.AssignedServiceSpecialist_LongInteger = PersonnelTable.PersonnelID_AutoNumber) LEFT JOIN StatusesTable ON WorkOrderConcernsTable.WorkOrderConcernStatusID_LongInteger = StatusesTable.StatusID_Autonumber
    "

        WorkOrderConcernsSelectionOrder = ""

        MySelection = WorkOrderConcernsFieldsToSelect & WorkOrderConcernsSelectionFilter & WorkOrderConcernsSelectionOrder

        JustExecuteMySelection()
        WorkOrderConcernsRecordCount = RecordCount
        WorkOrderConcernsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        If Not WorkOrderConcernsDataGridViewAlreadyFormatted Then
            WorkOrderConcernsDataGridViewAlreadyFormatted = True
            FormatWorkOrderConcernsDataGridView()
        End If

        Dim RecordsToDisplay = 5
        SetGroupBoxHeight(RecordsToDisplay, WorkOrderConcernsRecordCount, WorkOrderConcernsGroupBox, WorkOrderConcernsDataGridView)
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
        Dim xxCoinedConcern = WorkOrderConcernsDataGridView.Item("CoinedConcern", CurrentWorkOrderConcernsRow).Value
        CurrentWorkOrderConcernID = WorkOrderConcernsDataGridView.Item("WorkOrderConcernID_AutoNumber", CurrentWorkOrderConcernsRow).Value
        CurrentConcernID = WorkOrderConcernsDataGridView.Item("ConcernID_LongInteger", CurrentWorkOrderConcernsRow).Value
        CurrentLongTextConcernID = WorkOrderConcernsDataGridView.Item("ConcernLongTextCodeID_LongInteger", CurrentWorkOrderConcernsRow).Value
        Dim CurrentAssignedServiceSpecialistID = WorkOrderConcernsDataGridView.Item("AssignedServiceSpecialist_LongInteger", CurrentWorkOrderConcernsRow).Value
        WorkOrderConcernJobsSelectionFilter = " WHERE WorkOrderConcernID_AutoNumber = " & CurrentWorkOrderConcernID
        FillWorkOrderConcernJobsTable()
    End Sub
    Private Sub FillWorkOrderConcernJobsTable()

        WorkOrderConcernJobsFieldsToSelect =
" 
SELECT WorkOrdersTable.WorkOrderNumber_ShortText12, 
WorkOrderConcernJobsTable.WorkOrderConcernJobID_AutoNumber, 
WorkOrderConcernJobsTable.InformationsHeaderID_LongInteger, 
WorkOrderConcernJobsTable.WorkOrderConcernJobStatus_Byte, 
WorkOrderConcernJobsTable.WorkOrderConcernID_LongInteger, 
WorkOrderConcernJobsTable.WorkOrderConcernJobStatusID_LongInteger, 
WorkOrderConcernsTable.WorkOrderID_LongInteger, 
WorkOrderConcernsTable.AssignedServiceSpecialist_LongInteger, 
WorkOrderConcernsTable.ConcernID_LongInteger, 
InformationsHeadersTypeTable.Affix & Space(1) & MasterCodeBookTable.SystemDesc_ShortText100Fld AS Job, 
InformationsHeadersTypeTable.InformationsHeadersTypePrefix_ShortText50, 
MasterCodeBookTable.SystemDesc_ShortText100Fld, 
PersonnelTable.FirstName_ShortText30, 
PersonnelTable.LastName_ShortText30, 
InformationsHeadersTable.InformationsHeaderDescription_ShortText255, 
OriginalExcelRecordTable.description, 
PersonnelTable.LastName_ShortText30 & Space(1) & Mid(PersonnelTable.FirstName_ShortText30,1,1) AS AssignedServiceSpecialist, 
InformationsHeadersTable.MasterCodeBookId_LongInteger, 
VehicleMaintenanceSchedulesTable.DoItEveryNoOfMiles_LongInteger, 
VehicleMaintenanceSchedulesTable.DoItEveryNoOfMonths_LongInteger, 
VehicleInformationsTable.VehicleInformationID_AutoNumber, 
GeneralCostOfLaborsTable.GeneralLaborCost_Currency, 
CostOfLaborsTable.LaborCostCommonMin_Currency, 
CostOfLaborsTable.LaborCostCommonMax_Currency,
MyPricesTable.MyPrice_Currency
FROM MyPricesTable RIGHT JOIN (GeneralCostOfLaborsTable RIGHT JOIN ((CostOfLaborsTable RIGHT JOIN (VehicleMaintenanceSchedulesTable RIGHT JOIN (((((WorkOrderConcernJobsTable LEFT JOIN WorkOrderConcernsTable ON WorkOrderConcernJobsTable.WorkOrderConcernID_LongInteger = WorkOrderConcernsTable.WorkOrderConcernID_AutoNumber) LEFT JOIN OriginalExcelRecordTable ON WorkOrderConcernJobsTable.OriginalID_LongInteger = OriginalExcelRecordTable.OriginalID_AutoNumber) LEFT JOIN PersonnelTable ON WorkOrderConcernJobsTable.AssignedServiceSpecialist_LongInteger = PersonnelTable.PersonnelID_AutoNumber) LEFT JOIN WorkOrdersTable ON WorkOrderConcernsTable.WorkOrderID_LongInteger = WorkOrdersTable.WorkOrderID_AutoNumber) LEFT JOIN VehicleInformationsTable ON WorkOrderConcernJobsTable.VehicleInformationID_LongInteger = VehicleInformationsTable.VehicleInformationID_AutoNumber) ON VehicleMaintenanceSchedulesTable.VehicleInformationID_LongInteger = VehicleInformationsTable.VehicleInformationID_AutoNumber) ON CostOfLaborsTable.VehicleInformationID_LongInteger = VehicleInformationsTable.VehicleInformationID_AutoNumber) LEFT JOIN ((InformationsHeadersTable LEFT JOIN InformationsHeadersTypeTable ON InformationsHeadersTable.InformationsHeadersTypeID_LongInteger = InformationsHeadersTypeTable.InformationsHeadersTypeID_AutoNumber) LEFT JOIN MasterCodeBookTable ON InformationsHeadersTable.MasterCodeBookId_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) ON VehicleInformationsTable.InformationsHeaderID_LongInteger = InformationsHeadersTable.InformationsHeaderID_AutoNumber) ON GeneralCostOfLaborsTable.InformationsHeaderID_LongInteger = InformationsHeadersTable.InformationsHeaderID_AutoNumber) ON MyPricesTable.WorkOrderConcernJobID_LongInteger = WorkOrderConcernJobsTable.WorkOrderConcernJobID_AutoNumber
"
        WorkOrderConcernJobsSelectionOrder = " ORDER BY WorkOrderConcernsTable.WorkOrderID_LongInteger DESC "

        MySelection = WorkOrderConcernJobsFieldsToSelect & WorkOrderConcernJobsSelectionFilter & WorkOrderConcernJobsSelectionOrder

        JustExecuteMySelection()
        WorkOrderConcernJobsRecordCount = RecordCount

        WorkOrderConcernJobsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If Not WorkOrderConcernJobsDataGridViewFormatted Then
            FormatWorkOrderConcernJobsDataGridView()
            SetFormWidthAndGroupBoxLeft()
        End If
        SetGroupBoxHeight(7, WorkOrderConcernJobsRecordCount, WorkOrderConcernJobsGroupBox, WorkOrderConcernJobsDataGridView)
    End Sub
    Private Sub FormatWorkOrderConcernJobsDataGridView()
        WorkOrderConcernJobsDataGridViewFormatted = True
        WorkOrderConcernJobsGroupBox.Width = 0
        For i = 0 To WorkOrderConcernJobsDataGridView.Columns.GetColumnCount(0) - 1

            WorkOrderConcernJobsDataGridView.Columns.Item(i).Visible = False

            Select Case WorkOrderConcernJobsDataGridView.Columns.Item(i).Name
                Case "Job"
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).Width = 300
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).Visible = True
                Case "GeneralLaborCost_Currency"
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).HeaderText = "General"
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).Width = 300
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).Visible = True
                Case "LaborCostCommonMin_Currency"
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).HeaderText = "Minimum"
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).Width = 300
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).Visible = True
                Case "LaborCostCommonMax_Currency"
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).HeaderText = "Maximum"
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).Width = 300
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).Visible = True
                Case "MyPrice_Currency"
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).HeaderText = "my price"
                    WorkOrderConcernJobsDataGridView.Columns.Item(i).Width = 300
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
        Dim VehicleInformationID = WorkOrderConcernJobsDataGridView.Item("VehicleInformationID_AutoNumber", CurrentWorkOrderConcernJobsRow).Value

        WorkOrderPartsPerJobSelectionFilter = " WHERE WorkOrderConcernJobID_AutoNumber = " & CurrentWorkOrderConcernJobID
        FillWorkOrderPartsPerJobDataGridView()

    End Sub
    Private Sub FillWorkOrderPartsPerJobDataGridView()
        WorkOrderPartsPerJobFieldsToSelect =
"
SELECT WorkOrderPartsTable.WorkOrderPartID_AutoNumber, 
MasterCodeBookTable.MasterCodeBookID_Autonumber, 
MasterCodeBookTable.SystemDesc_ShortText100Fld, 
WorkOrderPartsTable.Quantity_Integer, 
WorkOrderPartsTable.Unit_ShortText3, 
WorkOrderPartsTable.ProductPartID_LongInteger, 
WorkOrderPartsTable.AssignedLeadMechanic_longInteger,
WorkOrderRequestedPartsHeadersTable.WorkOrderRequestedPartsHeaderID_AutoNumber, 
WorkOrderConcernJobsTable.WorkOrderConcernJobID_AutoNumber,
InformationsHeadersTable.InformationsHeaderID_AutoNumber, 
WorkOrderPartsTable.CodeVehicleID_LongInteger, 
OrderedProductsPartsTable.ManufacturerDescription_ShortText250, 
OrderedProductsPartsTable.ManufacturerPartNo_ShortText30Fld, 
WorkOrderReceivedPartsTable.ReceivedQuantity_Double, 
ProductsPartsTable.ManufacturerPartNo_ShortText30Fld, 
ProductsPartsTable.ManufacturerDescription_ShortText250, 
ProductsPartsTable.Unit_ShortText3, 
BrandsTable.BrandName_ShortText20
FROM ((WorkOrderReceivedPartsTable RIGHT JOIN (((((WorkOrderPartsTable LEFT JOIN MasterCodeBookTable ON WorkOrderPartsTable.MasterCodeBookID_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) LEFT JOIN WorkOrderRequestedPartsHeadersTable ON WorkOrderPartsTable.WorkOrderRequestedPartsHeaderID_LongInteger = WorkOrderRequestedPartsHeadersTable.WorkOrderRequestedPartsHeaderID_AutoNumber) LEFT JOIN WorkOrderConcernJobsTable ON WorkOrderPartsTable.WorkOrderConcernJobID_LongInteger = WorkOrderConcernJobsTable.WorkOrderConcernJobID_AutoNumber) LEFT JOIN InformationsHeadersTable ON WorkOrderPartsTable.InformationsHeaderID_LongInteger = InformationsHeadersTable.InformationsHeaderID_AutoNumber) LEFT JOIN ProductsPartsTable AS OrderedProductsPartsTable ON WorkOrderPartsTable.ProductPartID_LongInteger = OrderedProductsPartsTable.ProductsPartID_Autonumber) ON WorkOrderReceivedPartsTable.WorkOrderPartID_LongInteger = WorkOrderPartsTable.WorkOrderPartID_AutoNumber) LEFT JOIN ProductsPartsTable ON WorkOrderReceivedPartsTable.ProductPartID_LongInteger = ProductsPartsTable.ProductsPartID_Autonumber) LEFT JOIN BrandsTable ON ProductsPartsTable.BrandID_LongInteger = BrandsTable.BrandID_Autonumber
"


        WorkOrderPartsPerJobSelectionOrder = "  "
        MySelection = WorkOrderPartsPerJobFieldsToSelect & WorkOrderPartsPerJobSelectionFilter
        JustExecuteMySelection()
        WorkOrderPartsPerJobRecordCount = RecordCount
        WorkOrderPartsPerJobDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If WorkOrderPartsPerJobRecordCount > 0 Then
            WorkOrderPartsPerJobGroupBox.Visible = True
        Else
            WorkOrderPartsPerJobGroupBox.Visible = False
        End If
        WorkOrderPartsPerJobDataGridView.Top = WorkOrderConcernJobsDataGridView.Top + WorkOrderConcernJobsDataGridView.Height
        Dim RecordsToDisplay = 5
        SetGroupBoxHeight(RecordsToDisplay, WorkOrderPartsPerJobRecordCount, WorkOrderPartsPerJobGroupBox, WorkOrderPartsPerJobDataGridView)
        If Not WorkOrderPartsPerJobDataGridViewAlreadyFormatted Then FormatWorkOrderPartsPerJobDataGridView()
    End Sub
    Private Sub FormatWorkOrderPartsPerJobDataGridView()
        Dim PartsFromCustomer = False
        If WorkOrderPartsPerJobRecordCount > 0 Then
            '    If IsNotEmpty(WorkOrderPartsPerJobDataGridView.Item("ProductsPartsTable.ManufacturerDescription_ShortText250", CurrentWorkOrderPartsPerJobRow).Value) Then
            '   PartsFromCustomer = True
            'End If
        End If
        WorkOrderPartsPerJobDataGridViewAlreadyFormatted = True
        WorkOrderPartsPerJobGroupBox.Width = 0


        For i = 0 To WorkOrderPartsPerJobDataGridView.Columns.GetColumnCount(0) - 1
            WorkOrderPartsPerJobDataGridView.Columns.Item(i).Visible = False
            Select Case WorkOrderPartsPerJobDataGridView.Columns.Item(i).Name
                Case "ProductsPartsTable.ManufacturerPartNo_ShortText30Fld"
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).HeaderText = "Manuf PN"
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).Width = 150
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).Visible = True
                Case "ProductsPartsTable.ManufacturerDescription_ShortText250"
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).HeaderText = "Product"
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).Width = 400
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).Visible = True
                Case "ProductsPartsTable.Unit_ShortText3"
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).HeaderText = "UNIT"
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).Width = 100
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).Visible = True
                Case "ReceivedQuantity_Double"
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).HeaderText = "QTY"
                    WorkOrderPartsPerJobDataGridView.Columns.Item(i).Width = 60
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
    Private Sub SetFormWidthAndGroupBoxLeft()

        If WorkOrdersGroupBox.Width > VehicleManagementSystemForm.Width Then
            Me.Width = VehicleManagementSystemForm.Width - 4
        End If

        Me.Left = (VehicleManagementSystemForm.Width - Me.Width) / 2
    End Sub

    Private Sub ReturnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnToolStripMenuItem.Click
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub

    Private Sub PrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintToolStripMenuItem.Click
        PrintBill()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click

    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click

    End Sub
    Private Sub PD_BeginPrint(sender As Object, e As PrintEventArgs) Handles PD.BeginPrint
        Dim PageSetup As New PageSettings
        PageSetup.PaperSize = New PaperSize("Custom", 826, 1169)
        PD.DefaultPageSettings = PageSetup
    End Sub
    Private Sub PrintBill()
        PPD.Document = PD
        PPD.ShowDialog()

    End Sub
    Private Sub PD_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PD.PrintPage
        LeftMargin = PrintDocument.DefaultPageSettings.Margins.Left
        CenterMargin = PrintDocument.DefaultPageSettings.PaperSize.Width / 2
        RightMargin = PrintDocument.DefaultPageSettings.PaperSize.Width

        CenterMargin = PrintDocument.DefaultPageSettings.PaperSize.Width / 2
        RightMargin = PrintDocument.DefaultPageSettings.PaperSize.Width
        RighStringFormat.Alignment = StringAlignment.Far
        CenterStringFormat.Alignment = StringAlignment.Center

        Dim line As New String("-"c, 490)

        Dim IndentOfPartsPrice = 670
        Dim IndentOfPartsPriceHeader = 670
        Dim IndentOfLaborPrice = 720
        Dim IndentOfLaborPriceHeader = 720
        Dim IndentOfUnit = 620
        Dim IndentOfQuantity = 600
        Dim IndentOfJobs = 20
        Dim IndentOfParts = 40

        e.Graphics.DrawString("Nick Garage Car-Shop", F14, Brushes.Black, CenterMargin, 5, CenterStringFormat)
        e.Graphics.DrawString("for relatives and friends only", F10, Brushes.Black, CenterMargin, 25, CenterStringFormat)
        e.Graphics.DrawString("La Puente ", F14, Brushes.Black, CenterMargin, 40, CenterStringFormat)

        Dim xxVehicleDescription = WorkOrdersDataGridView.Item("VehicleDescription", CurrentWorkOrdersRow).Value
        Dim xxVinNo = WorkOrdersDataGridView.Item("VinNo_ShortText20", CurrentWorkOrdersRow).Value
        Dim xxCustomer = WorkOrdersDataGridView.Item("VehicleOwner", CurrentWorkOrdersRow).Value
        Dim xxServiceDate = WorkOrdersDataGridView.Item("ServiceDate_DateTime", CurrentWorkOrdersRow).Value
        Dim xxWorkOrderNumber = WorkOrdersDataGridView.Item("WorkOrderNumber_ShortText12", CurrentWorkOrdersRow).Value
        Dim xxVehicleMilage = WorkOrdersDataGridView.Item("VehicleMilage_Integer", CurrentWorkOrdersRow).Value
        Dim xxAssistedBy = WorkOrdersDataGridView.Item("CustomerServiceSpecialist", CurrentWorkOrdersRow).Value
        Dim xxServiceSpecialist = WorkOrdersDataGridView.Item("leadMechanic", CurrentWorkOrdersRow).Value
        Dim xxTelNr = WorkOrdersDataGridView.Item("TelNo_ShortText10", CurrentWorkOrdersRow).Value

        Dim TotalPartsPrice = 0
        Dim TotalLaborCost = 0
        Dim TotalWorkOrderCharge = 0

        FormHeight = 75

        e.Graphics.DrawString("Work Order Number : ", F10, Brushes.Black, 0, FormHeight)
        e.Graphics.DrawString(xxWorkOrderNumber, F10, Brushes.Black, 130, FormHeight)

        e.Graphics.DrawString("Service Date : ", F10, Brushes.Black, 0, FormHeight + 15)
        e.Graphics.DrawString(xxServiceDate, F10, Brushes.Black, 130, FormHeight + 15)

        e.Graphics.DrawString("Vehicle : ", F10, Brushes.Black, 0, FormHeight + 30)
        e.Graphics.DrawString(xxVehicleDescription, F10, Brushes.Black, 130, FormHeight + 30)

        e.Graphics.DrawString("Milage In : ", F10, Brushes.Black, 0, FormHeight + 45)
        e.Graphics.DrawString(Format(xxVehicleMilage, "#,###,##0"), F10, Brushes.Black, 130, FormHeight + 45)

        e.Graphics.DrawString("Customer Name: ", F10, Brushes.Black, 450, FormHeight)
        e.Graphics.DrawString(xxCustomer, F10, Brushes.Black, 550, FormHeight)

        e.Graphics.DrawString("Tel #: ", F10, Brushes.Black, 450, FormHeight + 15)
        e.Graphics.DrawString(xxTelNr, F10, Brushes.Black, 550, FormHeight + 15)

        e.Graphics.DrawString("Assisted By : ", F10, Brushes.Black, 450, FormHeight + 30)
        e.Graphics.DrawString(xxAssistedBy, F10, Brushes.Black, 550, FormHeight + 30)

        e.Graphics.DrawString("Lead Mechanic : ", F10, Brushes.Black, 450, FormHeight + 45)
        e.Graphics.DrawString(xxServiceSpecialist, F10, Brushes.Black, 550, FormHeight + 45)

        e.Graphics.DrawString(line, F10, Brushes.Black, 0, FormHeight + 90)

        FormHeight = 180
        e.Graphics.DrawString("Parts", F10, Brushes.Black, IndentOfPartsPriceHeader, FormHeight)
        e.Graphics.DrawString("Labor", F10, Brushes.Black, IndentOfLaborPriceHeader, FormHeight)
        FormHeight = +FormHeight + 15

        For WorkOrderConcernIndex = 0 To WorkOrderConcernsRecordCount - 1
            Dim xxConcern = WorkOrderConcernsDataGridView.Item("CoinedConcern", WorkOrderConcernIndex).Value
            e.Graphics.DrawString(Str(WorkOrderConcernIndex + 1) & ". " & xxConcern, F10, Brushes.Black, 0, FormHeight)
            FormHeight = +FormHeight + 15
            CurrentWorkOrderConcernID = WorkOrderConcernsDataGridView.Item("WorkOrderConcernID_AutoNumber", WorkOrderConcernIndex).Value
            WorkOrderConcernJobsSelectionFilter = " WHERE WorkOrderConcernID_AutoNumber = " & CurrentWorkOrderConcernID
            FillWorkOrderConcernJobsTable()

            For WorkOrderConcernJobIndex = 0 To WorkOrderConcernJobsRecordCount - 1
                Dim xxPrice As Integer = 0
                Dim xxAmount As Integer = 0
                Dim xxJob = WorkOrderConcernJobsDataGridView.Item("Job", WorkOrderConcernJobIndex).Value


                FormHeight = +FormHeight + 15
                CurrentInformationsHeaderID = WorkOrderConcernJobsDataGridView.Item("InformationsHeaderID_LongInteger", CurrentWorkOrderConcernJobsRow).Value

                Dim xxMyPrice = WorkOrderConcernJobsDataGridView.Item("MyPrice_Currency", WorkOrderConcernJobIndex).Value
                Dim xxGeneralLaborCost = WorkOrderConcernJobsDataGridView.Item("GeneralLaborCost_Currency", WorkOrderConcernJobIndex).Value
                Dim xxLaborCostCommonMin = WorkOrderConcernJobsDataGridView.Item("LaborCostCommonMin_Currency", WorkOrderConcernJobIndex).Value
                Dim xxLaborCostCommonMax = WorkOrderConcernJobsDataGridView.Item("LaborCostCommonMax_Currency", WorkOrderConcernJobIndex).Value
                If IsNotEmpty(xxMyPrice) Then
                    xxAmount = xxMyPrice
                ElseIf IsNotEmpty(xxGeneralLaborCost) Then
                    xxAmount = xxGeneralLaborCost
                ElseIf IsNotEmpty(xxLaborCostCommonMin) Then
                    xxAmount = xxLaborCostCommonMin * 40 / 100
                End If
                TotalLaborCost += xxAmount

                Dim xxStringAmount As String = Str(xxAmount)
                xxStringAmount = "$" & xxStringAmount

                xxStringAmount = xxStringAmount.PadLeft(9 - xxStringAmount.Length)

                e.Graphics.DrawString(xxJob, F10, Brushes.Black, IndentOfJobs, FormHeight)
                e.Graphics.DrawString(xxStringAmount, F10, Brushes.Black, IndentOfLaborPrice, FormHeight)
                FormHeight = +FormHeight + 15

                CurrentWorkOrderConcernJobID = WorkOrderConcernJobsDataGridView.Item("WorkOrderConcernJobID_AutoNumber", WorkOrderConcernJobIndex).Value
                WorkOrderPartsPerJobSelectionFilter = " WHERE WorkOrderConcernJobID_AutoNumber = " & CurrentWorkOrderConcernJobID
                FillWorkOrderPartsPerJobDataGridView()

                For WorkOrderPartsPerJobIndex = 0 To WorkOrderPartsPerJobRecordCount - 1
                    Dim xxPartNumber = "P/N " & WorkOrderPartsPerJobDataGridView.Item("ProductsPartsTable.ManufacturerPartNo_ShortText30Fld", WorkOrderPartsPerJobIndex).Value
                    Dim xxProduct = WorkOrderPartsPerJobDataGridView.Item("ProductsPartsTable.ManufacturerDescription_ShortText250", WorkOrderPartsPerJobIndex).Value
                    Dim xxBrand = WorkOrderPartsPerJobDataGridView.Item("BrandName_ShortText20", WorkOrderPartsPerJobIndex).Value
                    xxProduct = Replace(xxProduct, vbCrLf, Space(1))
                    Dim xxQuantity = WorkOrderPartsPerJobDataGridView.Item("ReceivedQuantity_Double", WorkOrderPartsPerJobIndex).Value
                    Dim xxUnit = WorkOrderPartsPerJobDataGridView.Item("ProductsPartsTable.Unit_ShortText3", WorkOrderPartsPerJobIndex).Value
                    If xxQuantity > 1 Then
                        xxUnit = xxUnit & "s"
                    End If
                    If IsNotEmpty(WorkOrderPartsPerJobDataGridView.Item("BrandName_ShortText20", WorkOrderPartsPerJobIndex).Value) Then
                        If Not InStr(xxProduct.toupper, xxBrand.toupper) > 0 Then
                            xxProduct = xxProduct & ", " & xxBrand
                        End If
                    End If
                    If IsNotEmpty(xxPartNumber) Then
                        xxProduct = xxPartNumber & " " & xxProduct
                    End If
                    Dim ProductWidth = 90
                    While Len(xxProduct) > ProductWidth
                        For i = ProductWidth To 0 Step -1
                            If xxProduct.Substring(i, 1) = " " Then
                                e.Graphics.DrawString(xxProduct.Substring(0, i), F10, Brushes.Black, IndentOfParts, FormHeight)
                                FormHeight = +FormHeight + 15
                                xxProduct = xxProduct.Substring(i + 1)
                                Exit For
                            End If
                        Next
                    End While
                    e.Graphics.DrawString(xxProduct, F10, Brushes.Black, IndentOfParts, FormHeight)
                    e.Graphics.DrawString(xxQuantity, F10, Brushes.Black, IndentOfQuantity, FormHeight)
                    e.Graphics.DrawString(xxUnit, F10, Brushes.Black, IndentOfUnit, FormHeight)
                    FormHeight = +FormHeight + 15
                Next
                FormHeight = +FormHeight + 5
            Next
            FormHeight = +FormHeight + 5
        Next
        e.Graphics.DrawString("=====", F10, Brushes.Black, IndentOfPartsPriceHeader, FormHeight)
        e.Graphics.DrawString("=====", F10, Brushes.Black, IndentOfLaborPriceHeader, FormHeight)
        FormHeight = +FormHeight + 15

        TotalWorkOrderCharge = TotalPartsPrice + TotalLaborCost
        e.Graphics.DrawString(TotalWorkOrderCharge, F10, Brushes.Black, IndentOfLaborPriceHeader, FormHeight)
        If TotalPartsPrice > 0 Then
            e.Graphics.DrawString(TotalPartsPrice, F10, Brushes.Black, IndentOfLaborPriceHeader, FormHeight)
            FormHeight = +FormHeight + 15
        End If
        e.Graphics.DrawString("Total", F10, Brushes.Black, 500, FormHeight)

    End Sub
    Private Sub PrintPageHeader(e)
        PrintPageHeader(e)
    End Sub

End Class