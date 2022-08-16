Public Class StateProvForm
    Private CurrentStateProvID As Integer = -1
    Private CurrentStateProvRow As Integer
    Private CurrentStateProvName As String
    Private SavedStateProvID As Integer
    Dim CurrentStateProvID_AutoNumber As Integer
    Dim StateProvDataGridViewInitialized = False
    Dim currentStateID As Integer
    Dim CurrentCountryID As Integer

    Public StateProvFieldsToSelect = ""
    Public StateProvTablesLinks = ""
    Public StateProvSelectionFilter = ""
    Public StateProvSelectionOrder = ""
    Private MeLocationX As Integer
    Private MeLocationY As Integer
    Private SavedCallingForm As Form


    Private Sub StateProvForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        SavedCallingForm = CallingForm
        Me.Width = 520
        MeLocationX = Me.Location.X
        'GET ALL ENTRY PARAMETERS
        'passed params
        '   tunnel1 - current state
        '   tunnel2 - Country filter
        If NotEmpty(Tunnel1) Then
            SavedStateProvID = Tunnel1
        End If

        If NotEmpty(Tunnel2) Then
            StateProvSelectionFilter = "CountryID_LongInteger = " & Str(Tunnel2)
        End If

        FillStateProvDataGridView()

        Tunnel1 = ""
        Tunnel2 = ""
        '        StateToolStripTextBoxSearch.Select()
    End Sub
    Private Sub StateProvForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        'SET AND RESET ALL ENTRY PARAMETER
        StateToolStripTextBoxSearch.Select()

        '   CityDataGridView HANDLING
    End Sub

    Private Sub FillStateProvDataGridView()
        StateProvFieldsToSelect = " Select StateProvTable.StateProvID_AutoNumber, " &
                                         " StateProvTable.StateProvName_ShortText25, " &
                                         " StateProvTable.StateCode_ShortText2, " &
                                         " StateProvTable.CountryID_LongInteger, " &
                                         " CountryTable.CountryName_ShortText25 "

        StateProvTablesLinks = " FROM StateProvTable LEFT Join CountryTable On StateProvTable.CountryID_LongInteger = CountryTable.CountryID_Autonumber "

        StateProvSelectionOrder = "Order by StateProvName_ShortText25 Asc "
        MySelection = StateProvFieldsToSelect & StateProvTablesLinks & StateProvSelectionFilter & StateProvSelectionOrder

        JustExecuteMySelection()
        StateProvDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        StateProvDataGridView.Columns.Item("StateProvID_AutoNumber").Visible = False
        StateProvDataGridView.Columns.Item("StateProvName_ShortText25").HeaderText = "StateProv"
        StateProvDataGridView.Columns.Item("StateProvName_ShortText25").Width = 180

        StateProvDataGridView.Columns.Item("StateCode_ShortText2").HeaderText = "State Code"
        StateProvDataGridView.Columns.Item("StateCode_ShortText2").Width = 60

        StateProvDataGridView.Columns.Item("CountryID_LongInteger").HeaderText = "Country"
        StateProvDataGridView.Columns.Item("CountryID_LongInteger").Width = 180


        StateProvDataGridView.Width = 500
    End Sub
    Private Sub StateProvDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles StateProvDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If RecordCount = 0 Then Exit Sub
        CurrentStateProvRow = e.RowIndex

        If Not StateProvDataGridViewInitialized Then
            StateProvDataGridViewInitialized = True
        End If
        If CurrentStateProvID = StateProvDataGridView.Item("StateProvID_AutoNumber", CurrentStateProvRow).Value Then Exit Sub
        CurrentStateProvID = StateProvDataGridView.Item("StateProvID_AutoNumber", CurrentStateProvRow).Value
        CurrentStateProvName = StateProvDataGridView.Item("StateProvName_ShortText25", CurrentStateProvRow).Value

        CurrentStateProvID_AutoNumber = StateProvDataGridView.Item("StateProvID_AutoNumber", CurrentStateProvRow).Value
    End Sub
    Private Sub StateProvDataGridView_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles StateProvDataGridView.DataBindingComplete
        Dim NoOfHeaderLines = 2
        Dim RecordsDisplyed = RecordCount

        Dim FormLowPointFromGrid = 90
        If RecordCount > 27 Then
            Me.Location = New Point(MeLocationX, 50)
            RecordsDisplyed = 27
        Else
            RecordsDisplyed = RecordCount + 1
        End If

        StateProvDataGridView.Height = (StateProvDataGridView.ColumnHeadersHeight * NoOfHeaderLines) + (DataGridViewRowHeight * RecordsDisplyed)

        Me.Height = StateProvDataGridView.Height + FormLowPointFromGrid
        StateProvDataGridView.Location = New Point(1, 49)
    End Sub


    '   CityDataGridView HANDLING                       ENDS


    Private Sub LoadStateProvDetails()
        StateProvFieldsToSelect = " Select StateProvTable.StateProvID_Autonumber, " &
                             " StateProvTable.StateProv_ShortText9, " &
                             " StateProvTable.StateProvName_ShortText25, " &
                             " StateTable.State_ShortText25, " &
                             " CountryTable. "


        If Not IsDBNull(StateProvDataGridView("StateProvID_Autonumber", CurrentStateProvRow).Value) Then
            '            StateProvDetailsForm.StateProvTextBox.Text = StateProvDataGridView("StateProvID_Autonumber", CurrentStateProvRow).Value
        End If
        If Not IsDBNull(StateProvDataGridView("StateProv_ShortText9", CurrentStateProvRow).Value) Then
            '            StateProvDetailsForm.StateProvTextBox.Text = StateProvDataGridView("StateProv_ShortText9", CurrentStateProvRow).Value
        End If
        If Not IsDBNull(StateProvDataGridView("StateProvName_ShortText25", CurrentStateProvRow).Value) Then
            '           StateProvDetailsForm.StateProvTextBox.Text = StateProvDataGridView("StateProvName_ShortText25", CurrentStateProvRow).Value
        End If
        If Not IsDBNull(StateProvDataGridView("State_ShortText25", CurrentStateProvRow).Value) Then
            Tunnel1 = StateProvDataGridView("State_ShortText25", CurrentStateProvRow).Value
        End If
        '        StateProvDetailsForm.CurrentStateID = currentStateID
        '        StateProvDetailsForm.CurrentCountryID = CurrentCountryID
    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        Tunnel1 = "ADD"
        Tunnel2 = "California"

        '    StateProvDetailsForm.CurrentStateID = 5
        '    StateProvDetailsForm.Show()
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        Tunnel1 = "EDIT"

        '       StateProvDetailsForm.Show()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Tunnel1 = "EDIT"
        LoadStateProvDetails()
        Me.Enabled = False
        '        StateProvDetailsForm.Show()
        Dim Question As String = "Proceed to delete"
        Dim DeleteThisConcern As String = MsgBox(Question, 4)
        If Not DeleteThisConcern = "6" Then

            GoTo ResetActionTaken
        End If
        RecordFinderDbControls.AddParam("@CurrentStateProvID", CurrentStateProvID)
        MySelection = "DELETE FROM StateProvTable WHERE trim(StateProvNumber_ShortText12) = @CurrentStateProvID"

        If NoRecordFound() Then Dim DIMStateProv = 0
ResetActionTaken:
        '        StateProvDetailsForm.Close()
        '        GetSelectedStateProv(1)
    End Sub



    Private Sub ToolStripTextBoxSearch_Click(sender As Object, e As EventArgs) Handles StateToolStripTextBoxSearch.Click
        If StateToolStripTextBoxSearch.Text = "Search" Then StateToolStripTextBoxSearch.Text = ""

    End Sub

    Private Sub ToolStripTextBoxSearch_TextChanged(sender As Object, e As EventArgs) Handles StateToolStripTextBoxSearch.TextChanged
        If Not StateProvDataGridViewInitialized Then Exit Sub
        Dim FindKey As String = Trim(StateToolStripTextBoxSearch.Text)
        If FindKey = "" Then
            FillStateProvDataGridView()
            Exit Sub
        End If
        RecordFinderDbControls.AddParam("@FindKey", "%" & FindKey & "%")

        StateProvSelectionFilter = "  WHERE StateProvName_ShortText25 LIKE @FindKey "

        MySelection = StateProvFieldsToSelect & StateProvTablesLinks & StateProvSelectionFilter & StateProvSelectionOrder
        JustExecuteMySelection()
        StateProvDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
    End Sub
    Private Sub SelectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectStateProvToolStripMenuItem.Click
        Tunnel1 = "Tunnel2IsStateProvID"
        Tunnel2 = CurrentStateProvID
        Tunnel3 = CurrentStateProvName
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub
    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub
    Private Sub StateProvForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        If Me.Enabled = False Then
            LoadStateProvDetails()
            Exit Sub
        End If
        CallingForm = SavedCallingForm
        Select Case Tunnel1
            Case "?"
        End Select

    End Sub
End Class