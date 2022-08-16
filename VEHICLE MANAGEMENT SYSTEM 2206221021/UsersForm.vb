Public Class UsersForm
    Private CurrentUserRow As Integer = -1

    Private UserDataGridViewInitialized = False

    Private UsersFieldsToSelect = ""
    Private UsersTablesLinks = ""
    Private UsersSelectionFilter = ""
    Private UsersSelectionFilterSaved = ""
    Private UsersSelectionOrder = ""

    Private SavedMeWidth = 0
    Private MeLocationX As Integer
    Private MeLocationY As Integer


    Private Sub UserForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        FillUserDataGridView()
        'SET AND RESET ALL ENTRY PARAMETERS
        ResetTunnels()
    End Sub
    Private Sub FillUserDataGridView()
        UsersFieldsToSelect = "Select " &
                      " UsersTable.UserName_ShortText50, " &
                      " PersonnelTable.LastName_ShortText30, " &
                      " PersonnelTable.FirstName_ShortText30, " &
                      " DepartmentsTable.DepartmentName_ShortText35, " &
                      " JobPositionsTable.JobPositionName_ShortText40, " &
                      " JobPositionsTable.SystemAccessLevel_ShortText2 "

        UsersTablesLinks = " FROM((UsersTable LEFT JOIN PersonnelTable ON UsersTable.PersonelID_LongInteger = PersonnelTable.PersonnelID_AutoNumber) " &
                                            " LEFT JOIN JobPositionsTable On PersonnelTable.[JobPositionID_LongInteger] = JobPositionsTable.JobPositionID_AutoNumber) " &
                                            " LEFT JOIN DepartmentsTable On JobPositionsTable.DepartmentID_LongInteger = DepartmentsTable.DepartmentID_AutoNumber"

        UsersSelectionOrder = " ORDER BY UserName_ShortText50 "

        MySelection = UsersFieldsToSelect & UsersTablesLinks & UsersSelectionFilter & UsersSelectionOrder


        JustExecuteMySelection()
        UsersDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable


        UsersDataGridView.Columns.Item("UserName_ShortText50").HeaderText = "UserName"                'note 15 chars = 184 pixels  new pixels = char x 184/15
        UsersDataGridView.Columns.Item("UserName_ShortText50").Width = 20 * 184 / 15

        UsersDataGridView.Columns.Item("LastName_ShortText30").HeaderText = "UserDate"
        UsersDataGridView.Columns.Item("LastName_ShortText30").Width = 15 * 184 / 15                            ' 20 for dates with time such as now()

        UsersDataGridView.Columns.Item("FirstName_ShortText30").HeaderText = "CityName"                'note 15 chars = 184 pixels  new pixels = char x 184/15
        UsersDataGridView.Columns.Item("FirstName_ShortText30").Width = 15 * 184 / 15

        UsersDataGridView.Columns.Item("SystemAccessLevel_ShortText2").HeaderText = "ZipCode"                'note 15 chars = 184 pixels  new pixels = char x 184/15
        UsersDataGridView.Columns.Item("SystemAccessLevel_ShortText2").Width = 7 * 184 / 15
        UsersDataGridView.Columns.Item("SystemAccessLevel_ShortText2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        UsersDataGridView.Columns.Item("DepartmentName_ShortText35").HeaderText = "StateProvName"                'note 15 chars = 184 pixels  new pixels = char x 184/15
        UsersDataGridView.Columns.Item("DepartmentName_ShortText35").Width = 35 * 184 / 15

        UsersDataGridView.Columns.Item("JobPositionName_ShortText40").HeaderText = "CountryName"                'note 15 chars = 184 pixels  new pixels = char x 184/15
        UsersDataGridView.Columns.Item("JobPositionName_ShortText40").Width = 40 * 184 / 15


        UsersDataGridView.Width = 0
        For i = 0 To UsersDataGridView.Columns.GetColumnCount(0) - 1
            If UsersDataGridView.Columns.Item(i).Visible = True Then
                UsersDataGridView.Width = UsersDataGridView.Width + UsersDataGridView.Columns.Item(i).Width
            End If
        Next
        UsersDataGridView.Width = UsersDataGridView.Width + 20

        Me.Width = UsersDataGridView.Width + 30
        SavedMeWidth = Me.Width
        MeLocationX = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
        If MeLocationX < 0 Then
            MeLocationX = 0
        End If
        Me.Location = New Point(MeLocationX, MeLocationY)

    End Sub


    Private Sub UserDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles UsersDataGridView.RowEnter

        If e.RowIndex < 0 Then Exit Sub
        If RecordCount = 0 Then Exit Sub
        If Not UserDataGridViewInitialized Then
            UserDataGridViewInitialized = True
        End If

        CurrentUserRow = e.RowIndex

    End Sub
    Private Sub UserDataGridView_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles UsersDataGridView.DataBindingComplete
        Dim NoOfHeaderLines = 1
        Dim RecordsDisplyed = RecordCount
        Dim FormLowPointFromGrid = 90
        MeLocationY = Me.Location.Y
        If RecordCount > 27 Then
            MeLocationY = 50
            RecordsDisplyed = 22
        Else
            RecordsDisplyed = RecordCount
        End If
        UsersDataGridView.Height = (UsersDataGridView.ColumnHeadersHeight * NoOfHeaderLines) + (DataGridViewRowHeight * RecordsDisplyed)
        Me.Height = UsersDataGridView.Height + FormLowPointFromGrid + DataGridViewRowHeight

    End Sub
    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub UserForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        'Fills up tunnel1, tunnel2
        'Enables calling form

        'Enables calling form
        Select Case ActivatedByTextBox.Text
            Case "VehicleManagementSystemForm"
                VehicleManagementSystemForm.Enabled = True ' triggers enabledchaned event of calling form
        End Select
        ActivatedByTextBox.Text = ""

    End Sub

    Private Sub SearchUserTextBox_TClick(sender As Object, e As EventArgs) Handles SearchUserTextBox.Click
        If SearchUserTextBox.Text = "Search" Then
            SearchUserTextBox.Text = ""
            Exit Sub
        End If
    End Sub
    Private Sub SearchUserTextBox_TextChanged(sender As Object, e As EventArgs) Handles SearchUserTextBox.TextChanged
        If SearchUserTextBox.Text = "Search" Then Exit Sub
        If SearchUserTextBox.Text = "" Then
            UsersSelectionFilter = ""
            FillUserDataGridView()

            Exit Sub
        End If

        Dim FindKey As String = Trim(SearchUserTextBox.Text)

        RecordFinderDbControls.AddParam("@FindKey", "%" & FindKey & "%")
        UsersSelectionFilter = " WHERE User_ShortText150 Like @FindKey  "

        FillUserDataGridView()
    End Sub

    Private Sub EnableAddEditDeleteMenuItems()
        SearchToolStrip.Enabled = True
    End Sub
    Private Sub DisableAddEditDeleteMenuItems()
        SearchToolStrip.Enabled = False
    End Sub



End Class