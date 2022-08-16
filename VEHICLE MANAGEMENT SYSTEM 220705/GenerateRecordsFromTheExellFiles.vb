Public Class GenerateRecordsForm
    Private WorkOrderTable As New MyDbControls
    Dim WorkOrderID_AutoNumber As Integer
    Dim ServiceDate_DateTime As Date
    Dim VehicleMilage_Integer As Integer
    Dim NewWorkOrderID As Integer

    Private Sub GenerateWorkOrdersButton_Click(sender As Object, e As EventArgs) Handles GenerateWorkOrdersButton.Click
        GenerateWorkOrderNumber()
    End Sub

    Private Sub GenerateWorkOrderNumber()
        MySelection = "Select OriginalID_AutoNumber, " &
                             " WorkOrderNumber_ShortText12, " &
                             " last_service_date, " &
                             " latest_service_milage " &
                      "From   originalExcelRecordTable "

        RecordFinderDbControls.MyDbCommand(MySelection)


        UpdatedTableDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        MsgBox("GENERATING WORK ORDER NUMBER")
        Dim RowCount As Integer = RecordFinderDbControls.MyAccessDbDataTable.Rows.Count
        For RowIndex = 0 To RowCount - 1
            If RowIndex = (10 Or 20 Or 30 Or 40 Or 50 Or 60 Or 70 Or 80) Then STATUSButton.Text = RowIndex.ToString
            Dim WorkOrderID_AutoNumber = UpdatedTableDataGridView("OriginalID_AutoNumber", RowIndex).Value
            Dim ServiceDate_DateTime = UpdatedTableDataGridView("last_service_date", RowIndex).Value
            Dim VehicleMilage_Integer = UpdatedTableDataGridView("latest_service_milage", RowIndex).Value
            CurrentRecord = WorkOrderID_AutoNumber

            Dim NewWorkOrderID = GetNewWorkOrderID(ServiceDate_DateTime, VehicleMilage_Integer)

            UpdateWorkOrderTable(WorkOrderID_AutoNumber, NewWorkOrderID)
            UpdateOriginalExcelRecordTable(WorkOrderID_AutoNumber, NewWorkOrderID)

        Next
        MySelection = "Select OriginalID_AutoNumber, " &
                             " WorkOrderNumber_ShortText12, " &
                             " last_service_date, " &
                             " milage " &
                      "From   originalExcelRecordTable "

        RecordFinderDbControls.MyDbCommand(MySelection)

    End Sub
    Private Sub UpdateOriginalExcelRecordTable(WorkOrderID_AutoNumber As Integer, NewWorkOrderID As String)

        RecordFinderDbControls.AddParam("@WorkOrderID_AutoNumber", WorkOrderID_AutoNumber)
        RecordFinderDbControls.AddParam("@NewWorkOrderID", NewWorkOrderID.ToString)

        MySelection = " UPDATE originalExcelRecordTable " &
                     " SET    WorkOrderNumber_ShortText12 = " & Chr(34) & NewWorkOrderID & Chr(34) &
                     " WHERE  OriginalID_AutoNumber = @WorkOrderID_AutoNumber"
        If NoRecordFound() Then
            Dim YYY = ""
        End If

    End Sub
    Private Sub UpdateWorkOrderTable(WorkOrderID_AutoNumber As Integer, NewWorkOrderID As String)


        RecordFinderDbControls.AddParam("@WorkOrderID_AutoNumber", WorkOrderID_AutoNumber)
        RecordFinderDbControls.AddParam("@NewWorkOrderID", NewWorkOrderID.ToString)

        ' Find the code in the WorkOrderTable

        MySelection = "Select  WorkOrderID_AutoNumber from WorkOrderTable " &
                     " WHERE  trim(WorkOrderNumber_ShortText12) = @NewWorkOrderID"

        If NoRecordFound() Then
            InsertNewWorkOrder(NewWorkOrderID)
            Dim YYY = ""
        End If

    End Sub
    Private Sub InsertNewWorkOrder(NewWorkOrderID)
        WorkOrderForm.MilageMaskedTextBox.Text = VehicleMilage_Integer
        WorkOrderForm.ServiceDate_DateTimeTextBox.Text = Convert.ToString(ServiceDate_DateTime)
        WorkOrderForm.WorkOrderNumberTextBox.Text = NewWorkOrderID
        WorkOrderForm.RegisterNewWorkOrder()
        ' INSERT NEW RECORD IN WorkOrderTable


    End Sub

    Private Sub STATUSButton_Click(sender As Object, e As EventArgs) Handles STATUSButton.Click
        UpdatedTableDataGridView.Refresh()
    End Sub
End Class