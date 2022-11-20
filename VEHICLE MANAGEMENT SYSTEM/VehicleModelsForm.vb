Public Class VehicleModelsForm

    Private CurrentVehicleModelID As Integer = -1
    Private CurrentVehicleModelRow As Integer = -1

    Private VehicleModelsDataGridViewInitialized = False

    Private VehicleModelFieldsToSelect = ""
    Private VehicleModelTablesLinks = ""
    Private VehicleModelSelectionFilter = ""
    Private VehicleModelSelectionFilterSaved = ""
    Private VehicleModelSelectionOrder = ""
    Private MeLocationX As Integer
    Private MeLocationY As Integer
    Private SavedCallingForm As Form
    Private Sub VehicleModelForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        SavedCallingForm = CallingForm

        MeLocationX = Me.Location.X

        FillVehicleModelsDataGridView()
        SetupVehicleModelsDataGridView()

        'SET AND RESET ALL ENTRY PARAMETERS

    End Sub
    Private Sub FillVehicleModelsDataGridView()
        VehicleModelFieldsToSelect = " SELECT " &
                                           " * "

        VehicleModelTablesLinks = " From VehicleModelsTable "

        VehicleModelSelectionOrder = " ORDER BY VehicleModel_ShortText20 "
        MySelection = VehicleModelFieldsToSelect & VehicleModelTablesLinks & VehicleModelSelectionFilter & VehicleModelSelectionOrder
        JustExecuteMySelection()
        VehicleModelsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
    End Sub
    Private Sub SetupVehicleModelsDataGridView()

        VehicleModelsDataGridView.Columns.Item("VehicleModelID_Autonumber").Visible = False


        VehicleModelsDataGridView.Columns.Item("VehicleModel_ShortText20").HeaderText = "Model"
        VehicleModelsDataGridView.Columns.Item("VehicleModel_ShortText20").Width = 250

        VehicleModelsDataGridView.Width = VehicleModelsDataGridView.Columns.Item("VehicleModel_ShortText20").Width + 50

        Me.Width = VehicleModelsDataGridView.Width + 10
        Dim xxx = RecordCount
    End Sub
    '   VehicleModelsDataGridView HANDLING

    Private Sub VehicleModelsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles VehicleModelsDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If RecordCount = 0 Then Exit Sub
        CurrentVehicleModelRow = e.RowIndex
        If Not VehicleModelsDataGridViewInitialized Then
            VehicleModelsDataGridViewInitialized = True
        End If
        If CurrentVehicleModelID = VehicleModelsDataGridView.Item("VehicleModelID_Autonumber", CurrentVehicleModelRow).Value Then Exit Sub
        CurrentVehicleModelID = VehicleModelsDataGridView.Item("VehicleModelID_Autonumber", CurrentVehicleModelRow).Value
    End Sub

    Private Sub VehicleModelsDataGridView_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles VehicleModelsDataGridView.DataBindingComplete
        Dim NoOfHeaderLines = 1
        Dim RecordsDisplyed = RecordCount
        Dim FormLowPointFromGrid = 90
        If RecordCount > 27 Then
            Me.Location = New Point(MeLocationX, 50)
            RecordsDisplyed = 27
        Else
            RecordsDisplyed = RecordCount + 1
        End If
        VehicleModelsDataGridView.Height = (VehicleModelsDataGridView.ColumnHeadersHeight * NoOfHeaderLines) + (DataGridViewRowHeight * RecordsDisplyed) + DataGridViewRowHeight
        Me.Height = VehicleModelsDataGridView.Height + FormLowPointFromGrid
        '       VehicleModelsDataGridView.Location = New Point(1, 49)
    End Sub
    '  Private Sub SearchVehicleModelTextBox_GotFocus(sender As Object, e As EventArgs) Handles SearchVehicleModelTextBox.GotFocus
    '      SearchVehicleModelTextBox.BackColor = SearchTextBoxHighLightForeColor
    '     SearchVehicleModelTextBox.ForeColor = SearchTextBoxHighlightBackColor

    '   End Sub

    '  Private Sub SearchVehicleModelTextBox_LostFocus(sender As Object, e As EventArgs) Handles SearchVehicleModelTextBox.LostFocus
    '     SearchVehicleModelTextBox.BackColor = SearchTextBoxNormalBackColor
    '      SearchVehicleModelTextBox.ForeColor = SearchTextBoxNormalForeColor

    '  End Sub
    Private Sub ToolStripTextBoxSearch_Click(sender As Object, e As EventArgs) Handles SearchVehicleModelTextBox.Click
        If (SearchVehicleModelTextBox.Text = "Search" Or SearchVehicleModelTextBox.Text = "Type New Trim Here") Then
            SearchVehicleModelTextBox.Text = ""
        End If

    End Sub

    Private Sub SearchVehicleModelTextBox_TextChanged(sender As Object, e As EventArgs) Handles SearchVehicleModelTextBox.TextChanged
        If Not VehicleModelsDataGridViewInitialized Then Exit Sub
        Dim FindKey As String = Trim(SearchVehicleModelTextBox.Text)
        If FindKey = "" Or FindKey = "Type New Trim Here" Or FindKey = "Search" Then
            VehicleModelSelectionFilter = VehicleModelSelectionFilterSaved
        Else
            RecordFinderDbControls.AddParam("@FindKey", "%" & FindKey & "%")
            Dim SearchKeyInQuote = Chr(34) & Trim(SearchVehicleModelTextBox.Text) & Chr(34)

            If VehicleModelSelectionFilterSaved = "" Then
                VehicleModelSelectionFilter = " WHERE VehicleModel_ShortText20 LIKE @FindKey "
            Else
                VehicleModelSelectionFilter = VehicleModelSelectionFilterSaved & " AND VehicleModel_ShortText20 LIKE @FindKey "
            End If
        End If
        FillVehicleModelsDataGridView()
    End Sub


    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click

        If Trim(SearchVehicleModelTextBox.Text) = "Type New Trim Here" Then
            SearchVehicleModelTextBox.Select()

            SearchVehicleModelTextBox.BackColor = Color.Maroon
            Exit Sub


        End If
        If Trim(SearchVehicleModelTextBox.Text) = "" Or Trim(SearchVehicleModelTextBox.Text) = "Search" Then
            SearchVehicleModelTextBox.Select()
            SearchVehicleModelTextBox.Text = "Type New Trim Here"
            Exit Sub
        End If
        If RecordCount > 0 Then SearchVehicleModelTextBox.Select() : Exit Sub
        If Not MsgBox("Confirm adding " & Me.Name & " " & Trim(SearchVehicleModelTextBox.Text) & " ?", vbYesNo) = vbYes Then
            SearchVehicleModelTextBox.Select()
            Exit Sub
        End If

        '       VehicleRepairClassSelectionFilter = " WHERE VehicleTypeID_LongInteger = " & Str(CurrentVehicleTypeID) & " AND " & " VehicleModelName_ShortText25 LIKE @FindKey "
        ' EXECUTE INSERT COMMAND
        If CurrentVehicleModelID = -1 Then
            VehicleModelsRelationsForm.Show()
            If Not IsNotEmpty(Tunnel1) Then
                Exit Sub
            End If
        End If
        MySelection = "INSERT INTO VehicleModelsTable (" &
                                            "VehicleModel_ShortText20)  " &
                                      "VALUES (" &
                                              Chr(34) & Trim(SearchVehicleModelTextBox.Text) & Chr(34) & " )"

        If NoRecordFound() Then Dim xxx As Integer = 0 'always IsNot found
        Dim VehicleModelInQuote = Chr(34) & Trim(SearchVehicleModelTextBox.Text) & Chr(34)

        MySelection = "Select * FROM VehicleModelsTable WHERE trim(VehicleModel_ShortText20) = " & VehicleModelInQuote
        If NoRecordFound() Then
            MsgBox("PROBLEM ...... unseccessful save ")
            Exit Sub
        End If
        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        CurrentVehicleModelID = r("VehicleModelID_AutoNumber")
        VehicleModelSelectionFilter = ""
        FillVehicleModelsDataGridView()
    End Sub
    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click

    End Sub
    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim VehicleModelText = VehicleModelsDataGridView.Item("VehicleType_ShortText20", CurrentVehicleModelRow).Value & " " &
                              VehicleModelsDataGridView.Item("VehicleModel_ShortText20", CurrentVehicleModelRow).Value & " " &
                              VehicleModelsDataGridView.Item("VehicleModelName_ShortText25", CurrentVehicleModelRow).Value

        VehicleModelSelectionFilter = " Select * from VehiclesTable WHERE VehicleModelID_LongInteger = " & Str(CurrentVehicleModelID)
        If NoRecordFound() Then
            MsgBox("Unable To delete " & VehicleModelText)
            Exit Sub
        End If
        If Not MsgBox("Confirm DELETION of " & VehicleModelText & " ?", vbYesNo) = vbYes Then
            SearchVehicleModelTextBox.Select()
            Exit Sub
        End If

    End Sub

    Private Sub SelectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectToolStripMenuItem.Click

        Tunnel1 = "Tunnel2IsVehicleModelID"
        Tunnel2 = CurrentVehicleModelID
        Tunnel3 = VehicleModelsDataGridView.Item("VehicleModel_ShortText20", CurrentVehicleModelRow).Value
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub
    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub

End Class