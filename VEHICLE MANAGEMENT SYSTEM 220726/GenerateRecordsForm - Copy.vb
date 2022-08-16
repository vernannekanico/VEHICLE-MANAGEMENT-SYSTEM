Public Class GenerateRecordsForm
    Private CurrentOriginalExcelRecordID As Integer = -1
    Private CurrentOriginalExcelRecordRow As Integer = -1

    Private OriginalExcelRecordsFieldsToSelect = ""
    Private OriginalExcelRecordsTablesLinks = ""
    Private OriginalExcelRecordsSelectionFilter = ""
    Private OriginalExcelRecordsSelectionFilterSaved = ""
    Private OriginalExcelRecordsSelectionOrder = ""

    Private OriginalExcelRecordsCount = RecordCount
    Private OriginalExcelRecordsDataGridViewInitialized = False
    Private OriginalExcelRecordsDataGridViewAlreadyFormated = False

    Private MeLocationX As Integer
    Private MeLocationY As Integer = 50

    Dim ServiceDate_DateTime As Date
    Dim VehicleMilage_Integer As Integer
    Dim NewWorkOrderID = ""
    Private Sub GenerateRecordsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' check these if needed

        FillOriginalExcelRecordDataGridView()
        'SET AND RESET ALL ENTRY PARAMETERS
        ResetTunnels()
        Dim MyDisplacement = 25
        Me.Size = My.Computer.Screen.WorkingArea.Size
        Me.Size = New Size(Me.Size.Width, Me.Size.Height - MyDisplacement)
        Me.Size = VehicleManagementSystemForm.Size
        Me.Location = New System.Drawing.Point(0, MyDisplacement)
        Me.Width = VehicleManagementSystemForm.Width
        Me.Left = VehicleManagementSystemForm.Left
    End Sub
    Private Sub FillOriginalExcelRecordDataGridView()
        Dim OriginalExcelRecordsFieldsToSelect = " Select " &
                                                  " OriginalExcelRecordTable.WorkOrderNumber_ShortText12, " &
                                                  " OriginalExcelRecordTable.last_service_date, " &
                                                  " OriginalExcelRecordTable.latest_service_milage, " &
                                                  " OriginalExcelRecordTable.description, " &
                                                  " OriginalExcelRecordTable.QTY, " &
                                                  " OriginalExcelRecordTable.UnitName, " &
                                                  " OriginalExcelRecordTable.price, " &
                                                  " OriginalExcelRecordTable.brand, " &
                                                  " OriginalExcelRecordTable.madein, " &
                                                  " OriginalExcelRecordTable.SUPPLIER, " &
                                                  " OriginalExcelRecordTable.ServiceProvider, " &
                                                  " OriginalExcelRecordTable.VehicleCode, " &
                                                  " OriginalExcelRecordTable.OriginalID_AutoNumber "


        Dim OriginalExcelRecordsLinks = "From OriginalExcelRecordTable " &
                                             " LEFT Join WorkOrderTable On OriginalExcelRecordTable.WorkOrderNumber_ShortText12 = WorkOrderTable.WorkOrderNumber_ShortText12 "
        Dim UpdatedSelectionOrder = " ORDER BY OriginalExcelRecordTable.last_service_date ASC, OriginalExcelRecordTable.latest_service_milage ASC "

        MySelection = OriginalExcelRecordsFieldsToSelect & OriginalExcelRecordsLinks & UpdatedSelectionOrder

        If NoRecordFound() Then
            Dim xxx = 10
        End If

        OriginalExcelRecordsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        OriginalExcelRecordsCount = RecordCount

        If Not OriginalExcelRecordsDataGridViewAlreadyFormated Then
            FormatOriginalExcelRecordDataGridView()
        End If

    End Sub

    Private Sub FormatOriginalExcelRecordDataGridView()
        OriginalExcelRecordsDataGridViewAlreadyFormated = True
        OriginalExcelRecordsDataGridView.Width = 0
        Dim DoNotDisplayFields = Space(30)

        For i = 0 To OriginalExcelRecordsDataGridView.Columns.GetColumnCount(0) - 1
            If InStr(DoNotDisplayFields, OriginalExcelRecordsDataGridView.Columns.Item(i).HeaderText & "/") > 0 Then
                OriginalExcelRecordsDataGridView.Columns.Item(i).Visible = False
            End If

            If OriginalExcelRecordsDataGridView.Columns.Item(i).Visible = True Then
                OriginalExcelRecordsDataGridView.Width = OriginalExcelRecordsDataGridView.Width + OriginalExcelRecordsDataGridView.Columns.Item(i).Width
            End If
        Next
        If OriginalExcelRecordsDataGridView.Width > VehicleManagementSystemForm.Width Then
            OriginalExcelRecordsDataGridView.Width = VehicleManagementSystemForm.Width - 20
        Else
            OriginalExcelRecordsDataGridView.Width = OriginalExcelRecordsDataGridView.Width + 20
        End If

        OriginalExcelRecordsDataGridView.Top = 30
        '       Me.Left = (VehicleManagementSystemForm.Width - Me.Width) / 2
        Me.Location = New Point(Me.Location.X, 55)
        OriginalExcelRecordsDataGridView.Left = Me.Left

    End Sub

    Private Sub GenerateWorkOrderNumber()
        MsgBox("GENERATING WORK ORDER NUMBER")
        Dim RowCount As Integer = RecordFinderDbControls.MyAccessDbDataTable.Rows.Count
        For RowIndex = 0 To RowCount - 1
            Dim WorkOrderID_AutoNumber = OriginalExcelRecordsDataGridView("OriginalID_AutoNumber", RowIndex).Value
            Dim ServiceDate_DateTime = OriginalExcelRecordsDataGridView("last_service_date", RowIndex).Value
            Dim VehicleMilage = OriginalExcelRecordsDataGridView("latest_service_milage", RowIndex).Value
            Dim VehicleCode = OriginalExcelRecordsDataGridView("VehicleCode", RowIndex).Value
            CurrentRecord = WorkOrderID_AutoNumber

            NewWorkOrderID = GetNewWorkOrderID(ServiceDate_DateTime, VehicleMilage)

            NewWorkOrderID = NewWorkOrderID.Substring(0, 6) & OriginalExcelRecordsDataGridView("VehicleCode", RowIndex).Value & NewWorkOrderID.Substring(6)

            If ThisRecordNotYetExistsInTheWorkOrderTable() Then
                InsertNewWorkOrder(ServiceDate_DateTime, VehicleMilage, VehicleCode)
            Else
            End If

            UpdateOriginalExcelRecordTable(WorkOrderID_AutoNumber)

        Next
        MySelection = "Select OriginalID_AutoNumber, " &
                             " WorkOrderNumber_ShortText12, " &
                             " last_service_date, " &
                             " milage " &
                      "From   originalExcelRecordTable "

        RecordFinderDbControls.MyDbCommand(MySelection)

    End Sub
    Private Function ThisRecordNotYetExistsInTheWorkOrderTable()
        MySelection = "SELECT * " &
                       " FROM WorkOrderTable " &
                      " WHERE trim(WorkOrderNumber_ShortText12) = " & Chr(34) & NewWorkOrderID & Chr(34)

        If NoRecordFound() Then
            Return True
        Else
            Return False
        End If

    End Function
    Private Sub UpdateOriginalExcelRecordTable(WorkOrderID_AutoNumber As Integer)

        RecordFinderDbControls.AddParam("@WorkOrderID_AutoNumber", WorkOrderID_AutoNumber)
        RecordFinderDbControls.AddParam("@NewWorkOrderID", NewWorkOrderID.ToString)

        MySelection = " UPDATE originalExcelRecordTable " &
                     " SET    WorkOrderNumber_ShortText12 = " & Chr(34) & NewWorkOrderID & Chr(34) &
                     " WHERE  OriginalID_AutoNumber = @WorkOrderID_AutoNumber"
        If NoRecordFound() Then
            Dim YYY = ""
        End If

    End Sub
    Private Sub InsertNewWorkOrder(ServiceDate_DateTime, VehicleMilage_Integer, VehicleCode)
        'record was first tested if it already exist in the workorder table
        Dim CurrentVehicleServicedID = -1
        If IsDBNull(VehicleMilage_Integer) Then
            VehicleMilage_Integer = 0
        Else
            VehicleMilage_Integer = Int(Val(Replace(VehicleMilage_Integer, ",", "")))
        End If
        Select Case VehicleCode
            Case 1
                CurrentVehicleServicedID = 2   ' 95
            Case 2
                CurrentVehicleServicedID = 7    ' rav4
            Case 3
                CurrentVehicleServicedID = 1    ' civic
            Case 4
                CurrentVehicleServicedID = 4    ' 02
            Case 5
                CurrentVehicleServicedID = 3    ' 98

        End Select
        Dim FieldsToUpdate = " ( " &
                    " WorkOrderNumber_ShortText12, " &
                    " VehicleServicedID_LongInteger, " &
                    " ServiceDate_DateTime, " &
                          " VehicleMilage_Integer, " &
                    " WorkOrderStatus_Byte) "

        Dim ReplacementData = "(" &
                    Chr(34) & NewWorkOrderID & Chr(34) & ", " &
                    Str(CurrentVehicleServicedID) & ", " &
                    Chr(34) & ServiceDate_DateTime.ToString & Chr(34) & ", " &
                VehicleMilage_Integer.ToString & ", " &
                    Chr(34) & "9" & Chr(34) & ")"


        MySelection = "INSERT INTO WorkOrderTable  " & FieldsToUpdate & " VALUES " & ReplacementData

        JustExecuteMySelection()

        If ThisRecordNotYetExistsInTheWorkOrderTable() Then
            MsgBox("unsuccesful insert")
        End If
    End Sub


    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub GenerateWorkOrdersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerateWorkOrdersToolStripMenuItem.Click
        GenerateWorkOrderNumber()
    End Sub

    Private Sub OriginalExcelRecordDataGridView_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles OriginalExcelRecordsDataGridView.DataBindingComplete
        Dim NoOfHeaderLines = 1
        Dim RecordsToDisplay = 22
        Dim RecordsDisplyed = RecordCount

        If RecordCount > RecordsToDisplay Then
            RecordsDisplyed = RecordsToDisplay
        Else
            RecordsDisplyed = RecordCount + 1
        End If
        OriginalExcelRecordsDataGridView.Height = (OriginalExcelRecordsDataGridView.ColumnHeadersHeight * NoOfHeaderLines) + (DataGridViewRowHeight * RecordsDisplyed) + DataGridViewRowHeight
        If OriginalExcelRecordsCount = 0 Then
            OriginalExcelRecordsCount = -1
            FillOriginalExcelRecordDataGridView()
        End If

    End Sub

    Private Sub OriginalExcelRecordDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles OriginalExcelRecordsDataGridView.RowEnter
        If e.RowIndex < 0 Then Exit Sub
        If OriginalExcelRecordsCount = 0 Then Exit Sub

        CurrentOriginalExcelRecordRow = e.RowIndex
        If Not OriginalExcelRecordsDataGridViewInitialized Then
            OriginalExcelRecordsDataGridViewInitialized = True
        End If
        CurrentOriginalExcelRecordID = OriginalExcelRecordsDataGridView.Item("OriginalID_AutoNumber", CurrentOriginalExcelRecordRow).Value


    End Sub
End Class