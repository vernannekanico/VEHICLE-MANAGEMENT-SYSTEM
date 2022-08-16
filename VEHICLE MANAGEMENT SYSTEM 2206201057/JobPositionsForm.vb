Public Class JobPositionsForm
    Private CurrentJobPositionID As Integer = -1
    Private CurrentJobPositionRow As Integer = -1
    Private CurrentDepartmentID As Integer = -1

    Private PurposeOfEntry = ""
    Private CodeRequested = ""

    Private JobPositionsDataGridViewInitialized = False

    Private JobPositionsFieldsToSelect = ""
    Private JobPositionsTableLinks = ""
    Private JobPositionsSelectionFilter = ""
    Private JobPositionsSelectionFilterSaved = ""
    Private JobPositionsSelectionOrder = ""

    Private FieldsValues = ""
    Private FieldsToReplace = ""

    Private SavedJobPositionName = ""

    Private SavedMeWidth = 0
    Private MeLocationX As Integer
    Private MeLocationY As Integer
    Private SavedCallingForm As Form

    Private Sub JobPositionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SavedCallingForm = CallingForm

        ' form returns       Tunnel1 = CurrentJobPositionID

        ' ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        ' enable all menus needded on first show
        If NotEmpty(Tunnel1) Then
            If Tunnel1 > 0 Then
                JobPositionsSelectionFilter = " WHERE DepartmentID_LongInteger = " & Str(Tunnel1)
            End If
        End If
        EnableAddEditDeleteMenuItems()

        FillJobPositionsDataGridView()
        'SET AND RESET ALL ENTRY PARAMETERS
        ResetTunnels()
    End Sub
    Private Sub FillJobPositionsDataGridView()
        JobPositionsFieldsToSelect = "Select " &
                    " JobPositionsTable.JobPositionID_AutoNumber, " &
                    " JobPositionsTable.JobPositionName_ShortText40, " &
                    " JobPositionsTable.SystemAccessLevel_ShortText2, " &
                     " JobPositionsTable.DepartmentID_LongInteger, " &
                   " DepartmentsTable.DepartmentName_ShortText35 "

        JobPositionsTableLinks = "From JobPositionsTable LEFT Join DepartmentsTable On JobPositionsTable.DepartmentID_LongInteger = DepartmentsTable.DepartmentID_AutoNumber "

        JobPositionsSelectionOrder = " ORDER BY SystemAccessLevel_ShortText2 "

        MySelection = JobPositionsFieldsToSelect & JobPositionsTableLinks & JobPositionsSelectionFilter & JobPositionsSelectionOrder

        JustExecuteMySelection()
        JobPositionsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        JobPositionsDataGridView.Columns.Item("JobPositionID_AutoNumber").Visible = False
        JobPositionsDataGridView.Columns.Item("DepartmentID_LongInteger").Visible = False

        JobPositionsDataGridView.Columns.Item("JobPositionName_ShortText40").HeaderText = "Job Position" ' note 15 chars = 184 pixels  new pixels =20 x 184/15 = 245
        JobPositionsDataGridView.Columns.Item("JobPositionName_ShortText40").Width = 40 * 184 / 15

        JobPositionsDataGridView.Columns.Item("SystemAccessLevel_ShortText2").HeaderText = "Acess level" ' note 15 chars = 184 pixels  new pixels =20 x 184/15 = 245
        JobPositionsDataGridView.Columns.Item("SystemAccessLevel_ShortText2").Width = 11 * 184 / 15
        JobPositionsDataGridView.Columns.Item("SystemAccessLevel_ShortText2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        JobPositionsDataGridView.Columns.Item("DepartmentName_ShortText35").HeaderText = "Department" ' note 15 chars = 184 pixels  new pixels =20 x 184/15 = 245
        JobPositionsDataGridView.Columns.Item("DepartmentName_ShortText35").Width = 35 * 184 / 15


        JobPositionsDataGridView.Width = 0
        For i = 0 To JobPositionsDataGridView.Columns.GetColumnCount(0) - 1
            If JobPositionsDataGridView.Columns.Item(i).Visible = True Then
                JobPositionsDataGridView.Width = JobPositionsDataGridView.Width + JobPositionsDataGridView.Columns.Item(i).Width
            End If
        Next
        JobPositionsDataGridView.Width = JobPositionsDataGridView.Width + 20

        Me.Width = JobPositionsDataGridView.Width
        SavedMeWidth = Me.Width
        MeLocationX = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
        If MeLocationX < 0 Then MeLocationX = 0
        Me.Location = New Point(MeLocationX, MeLocationY)

    End Sub
    Private Sub JobPositionsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles JobPositionsDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If RecordCount = 0 Then Exit Sub
        If Not JobPositionsDataGridViewInitialized Then
            JobPositionsDataGridViewInitialized = True
        End If

        CurrentJobPositionRow = e.RowIndex

        CurrentJobPositionID = JobPositionsDataGridView.Item("JobPositionID_AutoNumber", CurrentJobPositionRow).Value
        CurrentDepartmentID = JobPositionsDataGridView.Item("DepartmentID_LongInteger", CurrentJobPositionRow).Value
        If DetailsGroupBox.Enabled = False Then
            If SaveToolStripMenuItem.Visible = False Then
                ShowDetailsGroupBox()
            End If
        End If
    End Sub
    Private Sub JobPositionsDataGridView_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles JobPositionsDataGridView.DataBindingComplete
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

        JobPositionsDataGridView.Height = (JobPositionsDataGridView.ColumnHeadersHeight * NoOfHeaderLines) + (DataGridViewRowHeight * RecordsDisplyed)
        Me.Height = JobPositionsDataGridView.Height + FormLowPointFromGrid + DataGridViewRowHeight

    End Sub
    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        Select Case DetailsGroupBox.Visible
            Case True
                Dim FieldChangeOccured = False

                If SavedJobPositionName <> JobPositionNameTextBox.Text Then FieldChangeOccured = True
                If FieldChangeOccured Then
                    If Not MsgBox("Do you want to discard changes ?", vbYesNo) = vbYes Then
                        Exit Sub
                    End If
                End If
                JobPositionsDataGridView.Enabled = True
                DisableModifyMode()
            Case Else
                DoCommonHouseKeeping(Me, SavedCallingForm)
        End Select
    End Sub
    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        PurposeOfEntry = "ADD"
        ' Shows the details editing group box and enables edit to the fields
        ' All DataGridViews are disabled
        ' Searching is disabled
        CurrentJobPositionID = -1
        DetailsGroupBox.Text = "Add a new JobPosition"
        EnableModifyMode()          '' Add Edit Delete are turned off and Cancel ans Save options are made available
        JobPositionNameTextBox.Enabled = False
        SystemAccessLevelTextBox.Enabled = False
    End Sub
    Private Sub ShowDetailsGroupBox()
        If Me.Width < DetailsGroupBox.Width Then
            Me.Width = DetailsGroupBox.Width + 30
        End If
        If Me.Height < (DetailsGroupBox.Height + 90 + DataGridViewRowHeight) Then
            Me.Height = DetailsGroupBox.Height + 90 + DataGridViewRowHeight
        End If

        DetailsGroupBox.Visible = True
        If Not DetailsGroupBox.Text = "" Then
            JobPositionsDataGridView.Enabled = False
        End If
        If CurrentJobPositionID = -1 Then
            JobPositionNameTextBox.Text = ""
            DepartmentTextBox.Text = ""
            SystemAccessLevelTextBox.Text = ""
            CurrentJobPositionID = -1
        Else
            JobPositionNameTextBox.Text = JobPositionsDataGridView.Item("JobPositionName_ShortText40", CurrentJobPositionRow).Value
            DepartmentTextBox.Text = JobPositionsDataGridView.Item("DepartmentName_ShortText35", CurrentJobPositionRow).Value
            SystemAccessLevelTextBox.Text = JobPositionsDataGridView.Item("SystemAccessLevel_ShortText2", CurrentJobPositionRow).Value
        End If
        SavedJobPositionName = JobPositionNameTextBox.Text
    End Sub
    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        PurposeOfEntry = "EDIT"

        If Not MsgBox("This JobPosition is currently LINKED to other Files, do you really want to change informations for this JobPosition ?", vbYesNo) = vbYes Then
            Exit Sub
        End If
        DetailsGroupBox.Text = "EDIT JobPosition"
        EnableModifyMode()
    End Sub
    Private Sub SaveCurrentFieldContents()
        Select Case PurposeOfEntry
            Case "ADD"
                If ThisJobPositionAlreadyExist() Then
                    MsgBox("This record already exists")
                    Exit Sub
                End If

                Dim FullName = Trim(JobPositionNameTextBox.Text)
                If Not MsgBox(" Confirm adding new Job Position " & FullName, vbYesNo) = vbYes Then
                    Exit Sub
                End If

                If Not SuccessfullyAddingThisJobPositionRecord() Then
                    Exit Sub
                End If
            Case "EDIT"
                Dim FullName = Trim(JobPositionNameTextBox.Text)
                If Not MsgBox(" Confirm Saving changes to Job Position " & FullName, vbYesNo) = vbYes Then
                    Exit Sub
                End If

                Dim JobPositionFilter = " WHERE JobPositionID_AutoNumber = " & Str(CurrentJobPositionID)
                Dim MyNull = Chr(34) & Chr(34)
                Dim yyyyy = ""

                JobPositionsFieldsToSelect = " UPDATE JobPositionsTable  SET " &
                                 " JobPositionName_ShortText40 = " & Chr(34) & JobPositionNameTextBox.Text & Chr(34) & ", " &
                                  " DepartmentID_LongInteger = " & Str(CurrentDepartmentID) & ", " &
                                " SystemAccessLevel_ShortText2 = " & Chr(34) & SystemAccessLevelTextBox.Text & Chr(34)
                MySelection = JobPositionsFieldsToSelect & JobPositionFilter
                If NoRecordFound() Then Dim dummy = 1
            Case Else
                Dim XXXX = 1
        End Select
        DisableModifyMode()
        FillJobPositionsDataGridView()
    End Sub
    Private Sub SelectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectToolStripMenuItem.Click
        Tunnel1 = "Tunnel2IsJobPositionID"
        Tunnel2 = CurrentJobPositionID
        Tunnel3 = JobPositionsDataGridView.Item("JobPositionName_ShortText40", CurrentJobPositionRow).Value
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub
    Private Sub EnableAddEditDeleteMenuItems()
        SelectToolStripMenuItem.Visible = True
        SaveToolStripMenuItem.Visible = False
        AddToolStripMenuItem.Visible = True
        EditToolStripMenuItem.Visible = True
        ViewToolStripMenuItem.Visible = True
        DeleteToolStripMenuItem.Visible = True
    End Sub
    Private Sub DisableAddEditDeleteMenuItems()
        SelectToolStripMenuItem.Visible = False
        SaveToolStripMenuItem.Visible = True
        AddToolStripMenuItem.Visible = False
        EditToolStripMenuItem.Visible = False
        ViewToolStripMenuItem.Visible = False
        DeleteToolStripMenuItem.Visible = False
    End Sub
    Private Sub DisableModifyMode()
        EnableAddEditDeleteMenuItems()
        Me.Width = SavedMeWidth
        DetailsGroupBox.Visible = False
        JobPositionsDataGridView.Enabled = True
    End Sub
    Private Sub EnableModifyMode()      ' Add Edit Delete are turned off and Cancel ans Save options are made available
        DisableAddEditDeleteMenuItems()
        ShowDetailsGroupBox()
    End Sub
    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        ' HERE DETERMINE FIRST ALL RELATIONS
        DetailsGroupBox.Text = "DELETE JobPosition"
        EnableModifyMode()
        If Not MsgBox("Do you want to continue deleting this EMPLOYEE ?", vbYesNo) = vbYes Then
        Else
            MySelection = "DELETE FROM JobPositionsTable WHERE JobPositionID_AutoNumber = " & Str(CurrentJobPositionID)
            JustExecuteMySelection()
            FillJobPositionsDataGridView()
        End If
        DisableModifyMode()
    End Sub
    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        If JobPositionFieldsEntriesAreNotValidAndComplete() Then Exit Sub
        SaveCurrentFieldContents()
    End Sub
    Private Function JobPositionFieldsEntriesAreNotValidAndComplete()
        If Trim(JobPositionNameTextBox.Text) = "" Then JobPositionNameTextBox.Select() : Return True
        If Trim(DepartmentTextBox.Text) = "" Then DepartmentTextBox.Select() : Return True
        If Trim(SystemAccessLevelTextBox.Text) = "" Then SystemAccessLevelTextBox.Select() : Return True
        Return False
    End Function
    Private Sub JobPositionName_TextChanged(sender As Object, e As EventArgs) Handles JobPositionNameTextBox.TextChanged
        If Len(Trim(JobPositionNameTextBox.Text)) > 35 Then
            JobPositionNameTextBox.Text = JobPositionNameTextBox.Text.Substring(0, 35)
        End If
    End Sub
    Private Sub SystemAccessLevelTextBox_TextChanged(sender As Object, e As EventArgs) Handles SystemAccessLevelTextBox.TextChanged
        If Len(Trim(SystemAccessLevelTextBox.Text)) > 2 Then
            SystemAccessLevelTextBox.Text = SystemAccessLevelTextBox.Text.Substring(0, 2)
        End If
    End Sub
    Private Function ThisJobPositionAlreadyExist()
        MySelection = "SELECT * FROM JobPositionsTable " &
            " WHERE trim(JobPositionName_ShortText40) = " & Chr(34) & Trim(JobPositionNameTextBox.Text) & Chr(34)
        If ThereIsARecord() Then
            Return True
        End If
        Return False
    End Function
    Private Function SuccessfullyAddingThisJobPositionRecord()
        ' EXECUTE INSERT COMMAND

        FieldsToReplace = "" &
            " JobPositionName_ShortText40, " &
            " DepartmentID_LongInteger, " &
            " SystemAccessLevel_ShortText2 "
        FieldsValues = "" &
            Chr(34) & Trim(JobPositionNameTextBox.Text) & Chr(34) & ", " &
            Str(CurrentDepartmentID) & ", " &
            Chr(34) & Trim(SystemAccessLevelTextBox.Text) & Chr(34)

        MySelection = "INSERT INTO JobPositionsTable  (" & FieldsToReplace & ") VALUES (" & FieldsValues & ")"

        JustExecuteMySelection()

        If ThisJobPositionAlreadyExist() Then
            r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
            CurrentJobPositionID = r("JobPositionID_AutoNumber")
        Else
            MsgBox("PROBLEM ...... unseccessful save ")
            Return False
        End If
        Return True
    End Function

    Private Sub DepartmentTextBox_TextChanged(sender As Object, e As EventArgs) Handles DepartmentTextBox.Click
        If DepartmentTextBox.Text = "" Then
            ShowDepartmenForm()
        Else
            If Me.Enabled = True Then
                If MsgBox("Do you intend to change the Department ?", vbYesNo) = vbYes Then
                    DepartmentTextBox.Text = ""
                    ShowDepartmenForm()
                End If
            End If
        End If
    End Sub
    Private Sub DepartmentTextBox_TextChanged_1(sender As Object, e As EventArgs) Handles DepartmentTextBox.GotFocus
        If DepartmentTextBox.Text = "" Then
            ShowDepartmenForm()
        End If
        If NotEmpty(DepartmentTextBox.Text) Then
            JobPositionNameTextBox.Enabled = True
            SystemAccessLevelTextBox.Enabled = True
        Else
            JobPositionNameTextBox.Enabled = False
            SystemAccessLevelTextBox.Enabled = False
        End If
    End Sub
    Private Sub ShowDepartmenForm()
        Tunnel1 = CurrentDepartmentID
        ShowCalledForm(Me, DepartmentsForm)
    End Sub

    Private Sub JobPositionsForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        If Me.Enabled = False Then Exit Sub
        CallingForm = SavedCallingForm
        Select Case Tunnel1
            Case = "Tunnel2IsDepartmentID"
                CurrentDepartmentID = Tunnel2
                DepartmentTextBox.Text = Tunnel3
        End Select

    End Sub
End Class