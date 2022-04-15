Public Class TemporaryForThisProjectForm
    Private JobsHistoryFieldsToSelect = ""
    Private JobsHistoryTableLinks = ""
    Private JobsHistorySelectionFilter = ""
    Private JobsHistorySelectionOrder = ""
    Private JobsHistoryRecordCount As Integer = -1
    Private CurrentJobsHistoryID As Integer = -1
    Private CurrentJobsHistoryDataGridViewRow As Integer = -1
    Private JobsHistoryDataGridViewAlreadyFormated = False

    Private Sub TemporaryForThisProjectForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        FillJobsHistoryDataGridView()
    End Sub

    Private Sub FillJobsHistoryDataGridView()

        '   USING JobsHistoryQuery

        JobsHistoryFieldsToSelect = " Select 
WorkOrderConcernJobsTable.WorkOrderConcernJobID_AutoNumber,
WorkOrderConcernJobsTable.WorkOrderConcernID_LongInteger,
WorkOrderConcernJobsTable.InformationsHeaderID_LongInteger,
WorkOrderConcernJobsTable.WorkOrderConcernJobStatus_Byte,
WorkOrderConcernsTable.WorkOrderID_LongInteger,
Trim(InformationsHeadersTypeTable.InformationsHeadersTypePrefix_ShortText50) & Space(1) & MasterCodeBookTable.SystemDesc_ShortText100Fld AS Job,
InformationsHeadersTypeTable.InformationsHeadersTypePrefix_ShortText50, MasterCodeBookTable.SystemDesc_ShortText100Fld,
InformationsHeadersTable.InformationsHeaderDescription_ShortText255,
OriginalExcelRecordTable.description, InformationsHeadersTable.MasterCodeBookId_LongInteger,
WorkOrdersTable.ServicedVehicleID_LongInteger
"


        JobsHistoryTableLinks = "
FROM (((((WorkOrderConcernJobsTable 
LEFT JOIN WorkOrderConcernsTable ON WorkOrderConcernJobsTable.WorkOrderConcernID_LongInteger = WorkOrderConcernsTable.WorkOrderConcernID_AutoNumber) 
LEFT JOIN OriginalExcelRecordTable ON WorkOrderConcernJobsTable.OriginalID_LongInteger = OriginalExcelRecordTable.OriginalID_AutoNumber) 
LEFT JOIN InformationsHeadersTable ON WorkOrderConcernJobsTable.InformationsHeaderID_LongInteger = InformationsHeadersTable.InformationsHeaderID_AutoNumber) 
LEFT JOIN InformationsHeadersTypeTable ON InformationsHeadersTable.InformationsHeadersTypeID_LongInteger = InformationsHeadersTypeTable.InformationsHeadersTypeID_AutoNumber) 
LEFT JOIN MasterCodeBookTable ON InformationsHeadersTable.MasterCodeBookId_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) 
LEFT JOIN WorkOrdersTable ON WorkOrderConcernJobsTable.WorkOrderID_LongInteger = WorkOrdersTable.WorkOrderID_AutoNumber
"


        JobsHistorySelectionFilter = " WHERE JobsHistoryTable.WorkOrderID_LongInteger = " & Str(CurrentWorkOrderID)

        JobsHistorySelectionFilter = " "
        JobsHistorySelectionOrder = ""

        MySelection = JobsHistoryFieldsToSelect & JobsHistoryTableLinks & JobsHistorySelectionFilter & JobsHistorySelectionOrder


        JustExecuteMySelection()


        JobsHistoryRecordCount = RecordCount
        JobsHistoryDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable


        If Not JobsHistoryDataGridViewAlreadyFormated Then
            JobsHistoryDataGridViewAlreadyFormated = True
            FormatJobsHistoryDataGridView()
        End If
    End Sub


    Private Sub FormatJobsHistoryDataGridView()


        Dim HeightToAdd = IIf(JobsHistoryRecordCount = 0, 0, ((JobsHistoryRecordCount) * DataGridViewRowHeight))
        JobsHistoryDataGridView.Height = JobsHistoryDataGridView.ColumnHeadersHeight + HeightToAdd + 100

        JobsHistoryDataGridView.Width = 0

        For i = 0 To JobsHistoryDataGridView.Columns.GetColumnCount(0) - 1

            JobsHistoryDataGridView.Columns.Item(i).Visible = False

            Select Case JobsHistoryDataGridView.Columns.Item(i).Name
                Case "Job"
                    JobsHistoryDataGridView.Columns.Item(i).Width = 300
                    JobsHistoryDataGridView.Columns.Item(i).Visible = True
                Case "InformationsHeaderDescription_ShortText255"
                    JobsHistoryDataGridView.Columns.Item(i).Width = 300
                    JobsHistoryDataGridView.Columns.Item(i).Visible = True
                Case "description"
                    JobsHistoryDataGridView.Columns.Item(i).Width = 300
                    JobsHistoryDataGridView.Columns.Item(i).Visible = True
                Case "ManufacturerDescription_ShortText250"
                    JobsHistoryDataGridView.Columns.Item(i).HeaderText = "Manuf Desc."
                    JobsHistoryDataGridView.Columns.Item(i).Width = 300
                    JobsHistoryDataGridView.Columns.Item(i).Visible = True
                Case "ProductDescription_ShortText250"
                    JobsHistoryDataGridView.Columns.Item(i).HeaderText = "Orig excel Desc."
                    JobsHistoryDataGridView.Columns.Item(i).Width = 400
                    JobsHistoryDataGridView.Columns.Item(i).Visible = True
                Case "BrandName_ShortText20"
                    JobsHistoryDataGridView.Columns.Item(i).HeaderText = "Orig excel Desc."
                    JobsHistoryDataGridView.Columns.Item(i).Width = 200
                    JobsHistoryDataGridView.Columns.Item(i).Visible = True
            End Select
            If JobsHistoryDataGridView.Columns.Item(i).Visible = True Then
                JobsHistoryDataGridView.Width = JobsHistoryDataGridView.Width + JobsHistoryDataGridView.Columns.Item(i).Width
            End If
        Next


        If JobsHistoryDataGridView.Width > Me.Width Then
            JobsHistoryDataGridView.Width = Me.Width - 100
        Else
            JobsHistoryDataGridView.Width = JobsHistoryDataGridView.Width + 20
        End If
        JobsHistoryDataGridView.Width = JobsHistoryDataGridView.Width
        JobsHistoryDataGridView.Left = (Me.Width - JobsHistoryDataGridView.Width) / 2

        '       JobsHistoryDataGridView.Top = 30
        Me.Left = (VehicleManagementSystemForm.Width - Me.Width) / 2
        Me.Location = New Point(Me.Location.X, 55)
        JobsHistoryDataGridView.Left = (Me.Width - JobsHistoryDataGridView.Width) / 2
        '===========================


        '       JobsHistoryDataGridView.Width = JobsHistoryDataGridView.Width + 20
        '       JobsHistoryDataGridView.Width = 1000

        Dim NoOfHeaderLines = 1
        Dim RecordsDisplyed = JobsHistoryRecordCount
        Dim FormLowPointFromGrid = 90
        If JobsHistoryRecordCount > 27 Then
            RecordsDisplyed = 27
        Else
            RecordsDisplyed = JobsHistoryRecordCount
        End If

        JobsHistoryDataGridView.Height = (JobsHistoryDataGridView.ColumnHeadersHeight * NoOfHeaderLines * 2) + (DataGridViewRowHeight * (RecordsDisplyed + 1))



    End Sub
    Private Sub JobsHistoryDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 Then Exit Sub
        If JobsHistoryRecordCount = 0 Then Exit Sub

        CurrentJobsHistoryDataGridViewRow = e.RowIndex

        CurrentJobsHistoryID = JobsHistoryDataGridView.Item("JobsHistoryID_Autonumber", CurrentJobsHistoryDataGridViewRow).Value
    End Sub
End Class