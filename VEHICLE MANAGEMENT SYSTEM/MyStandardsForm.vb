Public Class MyStandardForm
    Private ReleasedPartsFieldsToSelect = ""
    Private ReleasedPartsSelectionFilter = ""
    Private ReleasedPartsSelectionOrder = ""
    Private CurrentReleasedPartsRow As Integer = -1
    Private ReleasedPartsRecordCount As Integer = -1
    Private CurrentReleasedPartID = -1
    Private CurrentReleasedPartStatus As String
    Private ReleasedPartsDataGridViewAlreadyFormated = False

    Private SavedCallingForm As Form
    Private Sub ReleasedPartForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MsgBox("Set this form and all containers to 12pt pixel")
        SavedCallingForm = CallingForm
        FillReleasedPartsDataGridView()

    End Sub
    Private Sub FillReleasedPartsDataGridView()

        ReleasedPartsSelectionOrder = " ORDER BY ReleasedPartID_AutoNumber DESC "
        ReleasedPartsFieldsToSelect = " 
"

        MySelection = ReleasedPartsFieldsToSelect & ReleasedPartsSelectionFilter & ReleasedPartsSelectionOrder

        JustExecuteMySelection()
        ReleasedPartsRecordCount = RecordCount

        If ReleasedPartsRecordCount > 0 Then
            ReleasedPartsGroupBox.Visible = True
        Else
            ReleasedPartsGroupBox.Visible = False
        End If
        ReleasedPartsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If ReleasedPartsRecordCount = 0 Then
            CurrentReleasedPartID = -1
        End If


        ' HERE AT ROW_ENTER, FillReleasedPartConcernsDataGridView is called and ReleasedPartConcernsbOX IS ALREADY FORMATTED
        If Not ReleasedPartsDataGridViewAlreadyFormated Then
            FormatReleasedPartsDataGridView()
            SetFormWidthAndGroupBoxLeft(Me,
                                        MyStandardsFormMenuStrip,
                                        ReleasedPartsGroupBox,
                                        ReleasedPartsGroupBox,
                                        ReleasedPartsGroupBox,
                                        ReleasedPartsGroupBox)
        End If

        SetGroupBoxHeight(5, ReleasedPartsRecordCount, ReleasedPartsGroupBox, ReleasedPartsDataGridView)
        Me.Top = VehicleManagementSystemForm.VehicleManagementMenuStrip.Top + VehicleManagementSystemForm.VehicleManagementMenuStrip.Height + 20
        Me.Left = VehicleManagementSystemForm.Left
        Me.Height = VehicleManagementSystemForm.Height - Me.Top

    End Sub
    Private Sub FormatReleasedPartsDataGridView()
        ReleasedPartsDataGridViewAlreadyFormated = True
        ReleasedPartsGroupBox.Width = 0
        For i = 0 To ReleasedPartsDataGridView.Columns.GetColumnCount(0) - 1

            ReleasedPartsDataGridView.Columns.Item(i).Visible = False
            Select Case ReleasedPartsDataGridView.Columns.Item(i).Name
                Case "ReleasedPartNumber_ShortText12"
                    ReleasedPartsDataGridView.Columns.Item(i).HeaderText = "WORK ORDER No."
                    ReleasedPartsDataGridView.Columns.Item(i).Width = 120
                    ReleasedPartsDataGridView.Columns.Item(i).Visible = True
                Case "ServiceDate_DateTime"
                    ReleasedPartsDataGridView.Columns.Item(i).HeaderText = "Date/Time In"
                    ReleasedPartsDataGridView.Columns.Item(i).Width = 80
                    ReleasedPartsDataGridView.Columns(i).DefaultCellStyle.Format = "yy-MM-dd"
                    ReleasedPartsDataGridView.Columns.Item(i).Visible = True
                Case "VehicleMilage_Integer"
                    ReleasedPartsDataGridView.Columns.Item(i).HeaderText = "Milage"
                    ReleasedPartsDataGridView.Columns.Item(i).Width = 70
                    ReleasedPartsDataGridView.Columns(i).DefaultCellStyle.Format = "###,###"
                    ReleasedPartsDataGridView.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    ReleasedPartsDataGridView.Columns.Item(i).Visible = True
                Case "VehicleDescription"
                    ReleasedPartsDataGridView.Columns.Item("VehicleDescription").HeaderText = "VEHICLE"
                    ReleasedPartsDataGridView.Columns.Item("VehicleDescription").Width = 200
                    ReleasedPartsDataGridView.Columns.Item(i).Visible = True
                Case "OwnerName"
                    ReleasedPartsDataGridView.Columns.Item(i).HeaderText = "OWNER"
                    ReleasedPartsDataGridView.Columns.Item(i).Width = 150
                    ReleasedPartsDataGridView.Columns.Item(i).Visible = True
                Case "TelNo_ShortText10"
                    ReleasedPartsDataGridView.Columns.Item(i).HeaderText = "TEL. NO."
                    ReleasedPartsDataGridView.Columns.Item(i).Width = 100
                    ReleasedPartsDataGridView.Columns.Item(i).Visible = True
                Case "AssignedLeadMechanic"
                    ReleasedPartsDataGridView.Columns.Item(i).HeaderText = "Lead Mechanic"
                    ReleasedPartsDataGridView.Columns.Item(i).Width = 160
                    ReleasedPartsDataGridView.Columns.Item(i).Visible = True
                    If CurrentUserGroup = "Lead Service Specialist" Then ReleasedPartsDataGridView.Columns.Item(i).Visible = False
                Case "ReleasedPartStatus"
                    ReleasedPartsDataGridView.Columns.Item(i).HeaderText = "Status"
                    ReleasedPartsDataGridView.Columns.Item(i).Width = 171
                    ReleasedPartsDataGridView.Columns.Item(i).Visible = True
                Case "NewReleasedPartStatus"
                    ReleasedPartsDataGridView.Columns.Item(i).HeaderText = "Status (new)"
                    ReleasedPartsDataGridView.Columns.Item(i).Width = 200
                    ReleasedPartsDataGridView.Columns.Item(i).Visible = True
            End Select

            If ReleasedPartsDataGridView.Columns.Item(i).Visible = True Then
                ReleasedPartsGroupBox.Width = ReleasedPartsGroupBox.Width + ReleasedPartsDataGridView.Columns.Item(i).Width
            End If
        Next
        If ReleasedPartsGroupBox.Width > VehicleManagementSystemForm.Width Then
            ReleasedPartsGroupBox.Width = VehicleManagementSystemForm.Width - 4
        Else
            HorizontalCenter(ReleasedPartsGroupBox, Me)
        End If
    End Sub
    Private Sub ReleasedPartsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles ReleasedPartsDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If ReleasedPartsRecordCount = 0 Then Exit Sub

        CurrentReleasedPartsRow = e.RowIndex
        CurrentReleasedPartID = ReleasedPartsDataGridView.Item("ReleasedPartID_AutoNumber", CurrentReleasedPartsRow).Value

        FillField(CurrentReleasedPartStatus, ReleasedPartsDataGridView.Item("ReleasedPartStatus", CurrentReleasedPartsRow).Value)

        Select Case CurrentReleasedPartStatus
            Case "Assigned"
        End Select

    End Sub

    Private Sub ReturnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnToolStripMenuItem.Click
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub

    Private Sub ReleasedPartsForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        If Me.Enabled = False Then Exit Sub
        CallingForm = SavedCallingForm

        Select Case Tunnel1
            Case "Tunnel2IsReleasedPartID"
                CurrentReleasedPartID = Tunnel2
            Case "Tunnel3IsReturnedTextData"
                '              CurrentReturnedTextData = Tunnel3
        End Select
        FillReleasedPartsDataGridView()
    End Sub
End Class