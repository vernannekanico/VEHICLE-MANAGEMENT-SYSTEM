Public Class MyStandardForm
    Private MyStandardsFieldsToSelect = ""
    Private MyStandardsSelectionFilter = ""
    Private MyStandardsSelectionOrder = ""
    Private CurrentMyStandardsRow As Integer = -1
    Private MyStandardsRecordCount As Integer = -1
    Private CurrentMyStandardID = -1
    Private CurrentMyStandardStatus As String
    Private MyStandardsDataGridViewAlreadyFormated = False

    Private SavedCallingForm As Form

    Private Sub MyStandardForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SavedCallingForm = CallingForm
        FillMyStandardsDataGridView()

    End Sub
    Private Sub FillMyStandardsDataGridView()

        MyStandardsSelectionOrder = " ORDER BY MyStandardID_AutoNumber DESC "
        MyStandardsFieldsToSelect = " 
"

        MySelection = MyStandardsFieldsToSelect & MyStandardsSelectionFilter & MyStandardsSelectionOrder

        JustExecuteMySelection()
        MyStandardsRecordCount = RecordCount

        If MyStandardsRecordCount > 0 Then
            MyStandardsGroupBox.Visible = True
        Else
            MyStandardsGroupBox.Visible = False
        End If
        MyStandardsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If MyStandardsRecordCount = 0 Then
            CurrentMyStandardID = -1
        End If


        ' HERE AT ROW_ENTER, FillMyStandardConcernsDataGridView is called and MyStandardConcernsbOX IS ALREADY FORMATTED
        If Not MyStandardsDataGridViewAlreadyFormated Then
            FormatMyStandardsDataGridView()
            SetFormWidthAndGroupBoxLeft()
        End If

        SetGroupBoxHeight(5, MyStandardsRecordCount, MyStandardsGroupBox, MyStandardsDataGridView)

    End Sub
    Private Sub FormatMyStandardsDataGridView()
        MyStandardsDataGridViewAlreadyFormated = True
        MyStandardsGroupBox.Width = 0
        For i = 0 To MyStandardsDataGridView.Columns.GetColumnCount(0) - 1

            MyStandardsDataGridView.Columns.Item(i).Visible = False
            Select Case MyStandardsDataGridView.Columns.Item(i).Name
                Case "MyStandardNumber_ShortText12"
                    MyStandardsDataGridView.Columns.Item(i).HeaderText = "WORK ORDER No."
                    MyStandardsDataGridView.Columns.Item(i).Width = 120
                    MyStandardsDataGridView.Columns.Item(i).Visible = True
                Case "ServiceDate_DateTime"
                    MyStandardsDataGridView.Columns.Item(i).HeaderText = "Date/Time In"
                    MyStandardsDataGridView.Columns.Item(i).Width = 80
                    MyStandardsDataGridView.Columns(i).DefaultCellStyle.Format = "yy-MM-dd"
                    MyStandardsDataGridView.Columns.Item(i).Visible = True
                Case "VehicleMilage_Integer"
                    MyStandardsDataGridView.Columns.Item(i).HeaderText = "Milage"
                    MyStandardsDataGridView.Columns.Item(i).Width = 70
                    MyStandardsDataGridView.Columns(i).DefaultCellStyle.Format = "###,###"
                    MyStandardsDataGridView.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    MyStandardsDataGridView.Columns.Item(i).Visible = True
                Case "VehicleDescription"
                    MyStandardsDataGridView.Columns.Item("VehicleDescription").HeaderText = "VEHICLE"
                    MyStandardsDataGridView.Columns.Item("VehicleDescription").Width = 200
                    MyStandardsDataGridView.Columns.Item(i).Visible = True
                Case "OwnerName"
                    MyStandardsDataGridView.Columns.Item(i).HeaderText = "OWNER"
                    MyStandardsDataGridView.Columns.Item(i).Width = 150
                    MyStandardsDataGridView.Columns.Item(i).Visible = True
                Case "TelNo_ShortText10"
                    MyStandardsDataGridView.Columns.Item(i).HeaderText = "TEL. NO."
                    MyStandardsDataGridView.Columns.Item(i).Width = 100
                    MyStandardsDataGridView.Columns.Item(i).Visible = True
                Case "AssignedLeadMechanic"
                    MyStandardsDataGridView.Columns.Item(i).HeaderText = "Lead Mechanic"
                    MyStandardsDataGridView.Columns.Item(i).Width = 160
                    MyStandardsDataGridView.Columns.Item(i).Visible = True
                    If CurrentUserGroup = "Lead Service Specialist" Then MyStandardsDataGridView.Columns.Item(i).Visible = False
                Case "MyStandardStatus"
                    MyStandardsDataGridView.Columns.Item(i).HeaderText = "Status"
                    MyStandardsDataGridView.Columns.Item(i).Width = 171
                    MyStandardsDataGridView.Columns.Item(i).Visible = True
                Case "NewMyStandardStatus"
                    MyStandardsDataGridView.Columns.Item(i).HeaderText = "Status (new)"
                    MyStandardsDataGridView.Columns.Item(i).Width = 200
                    MyStandardsDataGridView.Columns.Item(i).Visible = True
            End Select

            If MyStandardsDataGridView.Columns.Item(i).Visible = True Then
                MyStandardsGroupBox.Width = MyStandardsGroupBox.Width + MyStandardsDataGridView.Columns.Item(i).Width
            End If
        Next
        If MyStandardsGroupBox.Width > VehicleManagementSystemForm.Width Then
            MyStandardsGroupBox.Width = VehicleManagementSystemForm.Width - 4
        End If
    End Sub
    Private Sub MyStandardsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles MyStandardsDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If MyStandardsRecordCount = 0 Then Exit Sub

        CurrentMyStandardsRow = e.RowIndex
        CurrentMyStandardID = MyStandardsDataGridView.Item("MyStandardID_AutoNumber", CurrentMyStandardsRow).Value

        FillField(CurrentMyStandardStatus, MyStandardsDataGridView.Item("MyStandardStatus", CurrentMyStandardsRow).Value)

        Select Case CurrentMyStandardStatus
            Case "Assigned"
        End Select

    End Sub
    Private Sub SetFormWidthAndGroupBoxLeft()
        Dim LargestWidth = 0
        'note for multiple pyramidal datagrid
        For i = 1 To 4
            '           If WorkOrdersGroupBox.Width > LargestWidth Then
            '          LargestWidth = WorkOrdersGroupBox.Width
            '            ElseIf WorkOrderConcernsGroupBox.Width > LargestWidth Then
            '            LargestWidth = WorkOrderConcernsGroupBox.Width
            '         ElseIf WorkOrderConcernJobsGroupBox.Width > LargestWidth Then
            '           LargestWidth = WorkOrderConcernJobsGroupBox.Width
            '           ElseIf WorkOrderPartsPerJobGroupBox.Width > LargestWidth Then
            '           LargestWidth = WorkOrderPartsPerJobGroupBox.Width
            '            End If
        Next

        If LargestWidth > VehicleManagementSystemForm.Width Then
            Me.Width = VehicleManagementSystemForm.Width - 4
        Else
            Me.Width = LargestWidth + 4
        End If

        Me.Left = (VehicleManagementSystemForm.Width - Me.Width) / 2
        MyStandardsGroupBox.Left = (Me.Width - MyStandardsGroupBox.Width) / 2
        '       WorkOrderConcernsGroupBox.Left = (Me.Width - WorkOrderConcernsGroupBox.Width) / 2
        '       WorkOrderConcernJobsGroupBox.Left = (Me.Width - WorkOrderConcernJobsGroupBox.Width) / 2
        '       WorkOrderPartsPerJobGroupBox.Left = (Me.Width - WorkOrderPartsPerJobGroupBox.Width) / 2

    End Sub

    Private Sub ReturnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnToolStripMenuItem.Click
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub

End Class