Public Class DepartmentsForm
    Private CurrentDepartmentID As Integer = -1
    Private CurrentDepartmentRow As Integer = -1


    Private DepartmentDataGridViewInitialized = False

    Private DepartmentFieldsToSelect = ""
    Private DepartmentsTableLinks = ""
    Private DepartmentSelectionFilter = ""
    Private DepartmentSelectionFilterSaved = ""
    Private DepartmentSelectionOrder = ""

    Private FieldsValues = ""
    Private FieldsToReplace = ""

    Private SavedDepartmentName = ""

    Private CodeRequested = ""
    Private MeLocationX As Integer
    Private MeLocationY As Integer
    Private SavedCallingForm As Form
    Private PurposeOfEntry = ""


    Private Sub DepartmentForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SavedCallingForm = CallingForm

        ' form returns       Tunnel1 = CurrentDepartmentID

        ' ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        ' enable all menus needded on first show

        EnableAddEditDeleteMenuItems()
        MeLocationX = Me.Location.X

        FillDepartmentDataGridView()
        'SET AND RESET ALL ENTRY PARAMETERS
    End Sub
    Private Sub FillDepartmentDataGridView()
        DepartmentFieldsToSelect = "Select " &
                    " DepartmentsTable.DepartmentID_AutoNumber, " &
                    " DepartmentsTable.DepartmentName_ShortText35 "

        DepartmentsTableLinks = "FROM DepartmentsTable "

        DepartmentSelectionOrder = " ORDER BY DepartmentName_ShortText35 "

        MySelection = DepartmentFieldsToSelect & DepartmentsTableLinks & DepartmentSelectionFilter & DepartmentSelectionOrder

        JustExecuteMySelection()
        DepartmentDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        DepartmentDataGridView.Columns.Item("DepartmentID_AutoNumber").Visible = False

        DepartmentDataGridView.Columns.Item("DepartmentName_ShortText35").HeaderText = "Department" ' note 15 chars = 184 pixels  new pixels =20 x 184/15 = 245
        DepartmentDataGridView.Columns.Item("DepartmentName_ShortText35").Width = 35 * 184 / 15

        DepartmentDataGridView.Width = DepartmentDataGridView.Columns.Item("DepartmentName_ShortText35").Width + 50
        Me.Width = DepartmentDataGridView.Width + 30
        If Me.Width < DetailsGroupBox.Width Then
            Me.Width = DetailsGroupBox.Width + 10
        End If

    End Sub
    Private Sub DepartmentDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DepartmentDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If RecordCount = 0 Then Exit Sub
        If Not DepartmentDataGridViewInitialized Then
            DepartmentDataGridViewInitialized = True
        End If

        CurrentDepartmentRow = e.RowIndex

        CurrentDepartmentID = DepartmentDataGridView.Item("DepartmentID_AutoNumber", CurrentDepartmentRow).Value
        If DetailsGroupBox.Enabled = False Then
            If SaveToolStripMenuItem.Visible = False Then
                ShowDetailsGroupBox()
            End If
        End If
    End Sub
    Private Sub DepartmentDataGridView_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles DepartmentDataGridView.DataBindingComplete
        Dim NoOfHeaderLines = 1
        Dim RecordsDisplyed = RecordCount
        Dim FormLowPointFromGrid = 90
        If RecordCount > 27 Then
            Me.Location = New Point(MeLocationX, 50)
            RecordsDisplyed = 22
        Else
            RecordsDisplyed = RecordCount + 1
        End If
        DepartmentDataGridView.Height = (DepartmentDataGridView.ColumnHeadersHeight * NoOfHeaderLines) + (DataGridViewRowHeight * RecordsDisplyed) + DataGridViewRowHeight
        Me.Height = DepartmentDataGridView.Height + FormLowPointFromGrid + 110
        '       VehicleTrimDataGridView.Location = New Point(1, 49)
        If Me.Height < DetailsGroupBox.Height Then
            Me.Height = DetailsGroupBox.Height + DataGridViewRowHeight
        End If

    End Sub
    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        Select Case DetailsGroupBox.Visible
            Case True
                Dim FieldChangeOccured = False

                If SavedDepartmentName <> DepartmentNameTextBox.Text Then FieldChangeOccured = True
                If FieldChangeOccured Then
                    If Not MsgBox("Do you want to discard changes ?", vbYesNo) = vbYes Then
                        Exit Sub
                    End If
                End If
                DepartmentDataGridView.Enabled = True
                DisableModifyMode()
            Case Else
                DoCommonHouseKeeping(Me, SavedCallingForm)
        End Select
    End Sub
    Private Sub DepartmentForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        'Fills up tunnel1, tunnel2
        'Enables calling form

        'Enables calling form
        Select Case CallingForm.Name
            Case "VehicleManagementSystemForm"
                VehicleManagementSystemForm.Enabled = True ' triggers enabledchaned event of calling form
            Case "PersonnelForm"
                PersonnelsForm.Enabled = True
            Case "JobPositionsForm"
                JobPositionsForm.Enabled = True
            Case Else
                Dim x = "break here"
        End Select
        CallingForm.Name = ""
    End Sub
    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        PurposeOfEntry = "ADD"
        ' Shows the details editing group box and enables edit to the fields
        ' All DataGridViews are disabled
        ' Searching is disable
        CurrentDepartmentID = -1
        DetailsGroupBox.Text = "Add a new DEPARTMENT"
        EnableModifyMode()          '' Add Edit Delete are turned off and Cancel ans Save options are made available
    End Sub
    Private Sub ShowDetailsGroupBox()
        DetailsGroupBox.Visible = True
        If Not DetailsGroupBox.Text = "" Then
            DepartmentDataGridView.Enabled = False
        End If
        If CurrentDepartmentID = -1 Then
            DepartmentNameTextBox.Text = ""
            CurrentDepartmentID = -1
        Else
            DepartmentNameTextBox.Text = DepartmentDataGridView.Item("DepartmentName_ShortText35", CurrentDepartmentRow).Value
        End If
        SavedDepartmentName = DepartmentNameTextBox.Text
    End Sub
    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        PurposeOfEntry = "EDIT"

        If Not MsgBox("This Department is currently LINKED to other Files, do you really want to change informations for this Department ?", vbYesNo) = vbYes Then
            Exit Sub
        End If
        DetailsGroupBox.Text = "EDIT DEPARTMENT"
        EnableModifyMode()
    End Sub
    Private Sub SaveCurrentFieldContents()
        Select Case PurposeOfEntry
            Case "ADD"
                If ThisDepartmentAlreadyExist() Then
                    MsgBox("This record already exists")
                    Exit Sub
                End If

                Dim FullName = Trim(DepartmentNameTextBox.Text)
                If Not MsgBox(" Confirm adding new EMPLOYEE " & FullName, vbYesNo) = vbYes Then
                    Exit Sub
                End If

                If Not SuccessfullyAddingThisDepartmentRecord() Then
                    Exit Sub
                End If
            Case "EDIT"
                Dim FullName = Trim(DepartmentNameTextBox.Text)
                If Not MsgBox(" Confirm Saving changes for DEPARTMENT " & FullName, vbYesNo) = vbYes Then
                    Exit Sub
                End If

                Dim DepartmentFilter = " WHERE DepartmentID_AutoNumber = " & Str(CurrentDepartmentID)
                Dim MyNull = Chr(34) & Chr(34)
                Dim yyyyy = ""

                DepartmentFieldsToSelect = " UPDATE DepartmentsTable  SET " &
                    " DepartmentName_ShortText35 = " & Chr(34) & DepartmentNameTextBox.Text & Chr(34)
                MySelection = DepartmentFieldsToSelect & DepartmentFilter
                If NoRecordFound() Then Dim dummy = 1
            Case Else
                Dim XXXX = 1
        End Select
        DisableModifyMode()
        FillDepartmentDataGridView()
    End Sub
    Private Sub SelectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectToolStripMenuItem.Click
        Tunnel1 = "Tunnel2IsDepartmentID"
        Tunnel2 = CurrentDepartmentID
        Tunnel3 = DepartmentDataGridView.Item("DepartmentName_ShortText35", CurrentDepartmentRow).Value

        Select Case CallingForm.Name
            Case "JobPositionsForm"
                JobPositionsForm.DepartmentTextBox.Text = DepartmentDataGridView.Item("DepartmentName_ShortText35", CurrentDepartmentRow).Value
            Case Else

                Dim xxx = 1
        End Select
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
        DetailsGroupBox.Visible = False
        DepartmentDataGridView.Enabled = True
    End Sub
    Private Sub EnableModifyMode()      ' Add Edit Delete are turned off and Cancel ans Save options are made available
        DisableAddEditDeleteMenuItems()
        ShowDetailsGroupBox()
    End Sub
    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        ' HERE DETERMINE FIRST ALL RELATIONS
        DetailsGroupBox.Text = "DELETE DEPARTMENT"
        EnableModifyMode()
        If Not MsgBox("Do you want to continue deleting this EMPLOYEE ?", vbYesNo) = vbYes Then
        Else
            MySelection = "DELETE FROM DepartmentsTable WHERE DepartmentID_AutoNumber = " & Str(CurrentDepartmentID)
            JustExecuteMySelection()
            FillDepartmentDataGridView()
        End If
        DisableModifyMode()
    End Sub
    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        If DepartmentFieldsEntriesAreNotValidAndComplete() Then Exit Sub
        SaveCurrentFieldContents()
    End Sub
    Private Function DepartmentFieldsEntriesAreNotValidAndComplete()
        If Trim(DepartmentNameTextBox.Text) = "" Then DepartmentNameTextBox.Select() : Return True
        Return False
    End Function
    Private Sub DepartmentName_TextChanged(sender As Object, e As EventArgs) Handles DepartmentNameTextBox.TextChanged
        If Len(Trim(DepartmentNameTextBox.Text)) > 35 Then
            DepartmentNameTextBox.Text = DepartmentNameTextBox.Text.Substring(0, 23)
        End If
    End Sub
    Private Function ThisDepartmentAlreadyExist()
        MySelection = "SELECT * FROM DepartmentsTable " &
            " WHERE trim(DepartmentName_ShortText35) = " & Chr(34) & Trim(DepartmentNameTextBox.Text) & Chr(34)
        If ThereIsARecord() Then
            Return True
        End If
        Return False
    End Function
    Private Function SuccessfullyAddingThisDepartmentRecord()
        ' EXECUTE INSERT COMMAND

        FieldsToReplace = "" &
            "DepartmentName_ShortText35"

        FieldsValues = "" &
            Chr(34) & Trim(DepartmentNameTextBox.Text) & Chr(34)

        MySelection = "INSERT INTO DepartmentsTable  (" & FieldsToReplace & ") VALUES (" & FieldsValues & ")"

        JustExecuteMySelection()

        If ThisDepartmentAlreadyExist() Then
            r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
            CurrentDepartmentID = r("DepartmentID_AutoNumber")
        Else
            MsgBox("PROBLEM ...... unseccessful save ")
            Return False
        End If
        Return True
    End Function
End Class