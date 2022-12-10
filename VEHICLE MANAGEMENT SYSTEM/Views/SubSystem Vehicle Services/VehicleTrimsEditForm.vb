Public Class VehicleTrimsEditForm
    Private CurrentVehicleTrimID As Integer = -1
    Private CurrentVehicleTrimRow As Integer = -1
    Private CurrentVehicleModelID As Integer = -1

    Private VehicleTrimDataGridViewInitialized = False

    Private VehicleTrimFieldsToSelect = ""
    Private VehicleTrimTablesLinks = ""
    Private VehicleTrimSelectionFilter = ""
    Private VehicleTrimSelectionFilterSaved = ""
    Private VehicleTrimSelectionOrder = ""
    Private MeLocationX As Integer
    Private MeLocationY As Integer
    Private SavedCallingForm As Form
    Private Sub VehicleTrimForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        SavedCallingForm = CallingForm

        ' form returns       Tunnel1 = CurrentVehicleModelsRelationID
        '                    Tunnel2 = 

        ' form recieves on enabled  ' CurrentVehicleTypeID 
        '                           ' note: trim belongs to a model
        '                           '       model belongs to a type
        ' if empty, it has been opened not to return a code

        ' ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


        MeLocationX = Me.Location.X

        'GET ALL ENTRY PARAMETERS

        If Trim(Tunnel1) = "" Then
            Exit Sub ' TRIM CODE is required
        End If

        CurrentVehicleModelID = Tunnel1
        VehicleTrimSelectionFilter = ""
        VehicleTrimSelectionFilterSaved = VehicleTrimSelectionFilter
        FillVehicleTrimDataGridView()
        SetupVehicleTrimDataGridView()

        'SET AND RESET ALL ENTRY PARAMETERS
        ResetTunnels()

    End Sub
    Private Sub FillVehicleTrimDataGridView()
        VehicleTrimFieldsToSelect = " SELECT " &
                                          " VehicleTrimTable.VehicleTrimID_Autonumber, " &
                                          " VehicleTrimTable.VehicleTrimName_ShortText25, " &
                                          " VehicleModelsTable.VehicleModel_ShortText20, " &
                                          " VehicleTypeTable.VehicleType_ShortText20 "

        VehicleTrimTablesLinks = " FROM ((VehicleTrimTable LEFT JOIN VehicleModelsRelationsTable ON VehicleTrimTable.VehicleTrimID_Autonumber = VehicleModelsRelationsTable.VehicleTrimID_LongInteger) " &
                                                         " LEFT JOIN VehicleModelsTable ON VehicleModelsRelationsTable.VehicleModelID_LongInteger = VehicleModelsTable.VehicleModelID_Autonumber) " &
                                                         " LEFT JOIN VehicleTypeTable ON VehicleModelsRelationsTable.VehicleTypeID_LongInteger = VehicleTypeTable.VehicleTypeID_AutoNumber "


        VehicleTrimSelectionOrder = " ORDER BY VehicleTrimName_ShortText25, VehicleModel_ShortText20, VehicleType_ShortText20 "
        MySelection = VehicleTrimFieldsToSelect & VehicleTrimTablesLinks & VehicleTrimSelectionFilter & VehicleTrimSelectionOrder

        JustExecuteMySelection()
        VehicleTrimDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
    End Sub
    Private Sub SetupVehicleTrimDataGridView()


        VehicleTrimDataGridView.Columns.Item("VehicleTrimID_Autonumber").Visible = False

        VehicleTrimDataGridView.Columns.Item("VehicleTrimName_ShortText25").HeaderText = "Trim"
        VehicleTrimDataGridView.Columns.Item("VehicleTrimName_ShortText25").Width = 250


        VehicleTrimDataGridView.Columns.Item("VehicleModel_ShortText20").HeaderText = "exist as Model of "
        VehicleTrimDataGridView.Columns.Item("VehicleModel_ShortText20").Width = 250

        VehicleTrimDataGridView.Columns.Item("VehicleType_ShortText20").HeaderText = "Make "
        VehicleTrimDataGridView.Columns.Item("VehicleType_ShortText20").Width = 250


        VehicleTrimDataGridView.Width = VehicleTrimDataGridView.Columns.Item("VehicleTrimName_ShortText25").Width +
                                       VehicleTrimDataGridView.Columns.Item("VehicleModel_ShortText20").Width +
                                       VehicleTrimDataGridView.Columns.Item("VehicleType_ShortText20").Width + 10

        Me.Width = VehicleTrimDataGridView.Width + 10
    End Sub
    '   VehicleTrimDataGridView HANDLING

    Private Sub VehicleTrimDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles VehicleTrimDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If RecordCount = 0 Then Exit Sub
        CurrentVehicleTrimRow = e.RowIndex
        If Not VehicleTrimDataGridViewInitialized Then
            VehicleTrimDataGridViewInitialized = True
        End If
        If CurrentVehicleTrimID = VehicleTrimDataGridView.Item("VehicleTrimID_Autonumber", CurrentVehicleTrimRow).Value Then Exit Sub
        CurrentVehicleTrimID = VehicleTrimDataGridView.Item("VehicleTrimID_Autonumber", CurrentVehicleTrimRow).Value
    End Sub

    Private Sub VehicleTrimDataGridView_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles VehicleTrimDataGridView.DataBindingComplete
        Dim NoOfHeaderLines = 1
        Dim RecordsDisplyed = RecordCount
        Dim FormLowPointFromGrid = 90
        If RecordCount > 27 Then
            Me.Location = New Point(MeLocationX, 50)
            RecordsDisplyed = 27
        Else
            RecordsDisplyed = RecordCount + 1
        End If
        VehicleTrimDataGridView.Height = (VehicleTrimDataGridView.ColumnHeadersHeight * NoOfHeaderLines) + (DataGridViewRowHeight * RecordsDisplyed) + DataGridViewRowHeight
        Me.Height = VehicleTrimDataGridView.Height + FormLowPointFromGrid
        '       VehicleTrimDataGridView.Location = New Point(1, 49)
    End Sub
    Private Sub SearchVehicleTrimTextBox_GotFocus(sender As Object, e As EventArgs) Handles SearchVehicleTrimTextBox.GotFocus
        '      SearchVehicleTrimTextBox.BackColor = SearchTextBoxHighLightForeColor
        '      SearchVehicleTrimTextBox.ForeColor = SearchTextBoxHighlightBackColor

    End Sub

    Private Sub SearchVehicleTrimTextBox_LostFocus(sender As Object, e As EventArgs) Handles SearchVehicleTrimTextBox.LostFocus
        '      SearchVehicleTrimTextBox.BackColor = SearchTextBoxNormalBackColor
        '      SearchVehicleTrimTextBox.ForeColor = SearchTextBoxNormalForeColor

    End Sub
    Private Sub ToolStripTextBoxSearch_Click(sender As Object, e As EventArgs) Handles SearchVehicleTrimTextBox.Click
        If (SearchVehicleTrimTextBox.Text = "Search" Or SearchVehicleTrimTextBox.Text = "Type New Trim Here") Then
            SearchVehicleTrimTextBox.Text = ""
        End If

    End Sub

    Private Sub SearchVehicleTrimTextBox_TextChanged(sender As Object, e As EventArgs) Handles SearchVehicleTrimTextBox.TextChanged
        If Not VehicleTrimDataGridViewInitialized Then Exit Sub
        Dim FindKey As String = Trim(SearchVehicleTrimTextBox.Text)
        If FindKey = "" Or FindKey = "Type New Trim Here" Then

            VehicleTrimSelectionFilter = VehicleTrimSelectionFilterSaved
        Else
            RecordFinderDbControls.AddParam("@FindKey", "%" & FindKey & "%")
            If VehicleTrimSelectionFilterSaved = "" Then
                VehicleTrimSelectionFilter = " WHERE VehicleTrimName_ShortText25 LIKE @FindKey "
            Else
                VehicleTrimSelectionFilter = VehicleTrimSelectionFilterSaved & " AND VehicleTrimName_ShortText25 LIKE @FindKey "
            End If
        End If
        FillVehicleTrimDataGridView()
    End Sub


    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click

        If CurrentVehicleModelID < 0 Then
            MsgBox("Can ADD only when MODEL is available ")
            Exit Sub
        End If
        If Trim(SearchVehicleTrimTextBox.Text) = "Type New Trim Here" Then
            SearchVehicleTrimTextBox.Select()

            SearchVehicleTrimTextBox.BackColor = Color.Maroon
            Exit Sub


        End If
        If Trim(SearchVehicleTrimTextBox.Text) = "" Or Trim(SearchVehicleTrimTextBox.Text) = "Search" Then
            SearchVehicleTrimTextBox.Select()
            SearchVehicleTrimTextBox.Text = "Type New Trim Here"
            Exit Sub
        End If
        If RecordCount > 0 Then
            SearchVehicleTrimTextBox.Select()
            Exit Sub
        End If
        If Not MsgBox("Confirm adding " & Trim(SearchVehicleTrimTextBox.Text) & " as new TRIM for " & Me.Text & " " & " ?", vbYesNo) = vbYes Then
            SearchVehicleTrimTextBox.Select()
            Exit Sub
        End If

        '       VehicleTrimSelectionFilter = " WHERE VehicleTypeID_LongInteger = " & Str(CurrentVehicleTypeID) & " AND " & " VehicleTrimName_ShortText25 LIKE @FindKey "
        ' EXECUTE INSERT COMMAND
        ' check if this TRIM already exists
        Dim VehicleTrimInQuote = Chr(34) & Trim(SearchVehicleTrimTextBox.Text) & Chr(34)

        MySelection = "Select * FROM VehicleTrimTable WHERE trim(VehicleTrimName_ShortText25) = " & VehicleTrimInQuote

        If RecordIsFound() Then
            MsgBox("This trim already exists as trim of " & Me.Text)
            Exit Sub
        End If

        MySelection = "INSERT INTO VehicleTrimTable (" &
                                            "VehicleTrimName_ShortText25)  " &
                                      "VALUES (" &
                                              Chr(34) & Trim(SearchVehicleTrimTextBox.Text) & Chr(34) & " )"

        If NoRecordFound() Then Dim xxx As Integer = 0 'always IsNot found

        MySelection = "Select * FROM VehicleTrimTable WHERE trim(VehicleTrimName_ShortText25) = " & VehicleTrimInQuote

        If NoRecordFound() Then
            MsgBox("PROBLEM ...... unseccessful save ")
            Exit Sub
        End If
        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        CurrentVehicleTrimID = r("VehicleTrimID_AutoNumber")
        VehicleTrimSelectionFilter = ""
        FillVehicleTrimDataGridView()
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click

    End Sub
    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim VehicleTrimText = VehicleTrimDataGridView.Item("VehicleType_ShortText20", CurrentVehicleTrimRow).Value & " " &
                              VehicleTrimDataGridView.Item("VehicleModel_ShortText20", CurrentVehicleTrimRow).Value & " " &
                              VehicleTrimDataGridView.Item("VehicleTrimName_ShortText25", CurrentVehicleTrimRow).Value

        VehicleTrimSelectionFilter = " Select * from VehiclesTable WHERE VehicleModelID_LongInteger = " & Str(CurrentVehicleModelID)
        If NoRecordFound() Then
            MsgBox("Unable To delete " & VehicleTrimText)
            Exit Sub
        End If
        If Not MsgBox("Confirm DELETION of " & VehicleTrimText & " ?", vbYesNo) = vbYes Then
            SearchVehicleTrimTextBox.Select()
            Exit Sub
        End If

    End Sub

    Private Sub SelectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectToolStripMenuItem.Click

        Tunnel1 = "Tunnel2IstVehicleTrimID"
        Tunnel2 = CurrentVehicleTrimID
        Tunnel3 = VehicleTrimDataGridView.Item("VehicleTrimName_ShortText25", CurrentVehicleTrimRow).Value
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub
    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub

    Private Sub VehicleTrimForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        'Enables calling form
        Tunnel1 = CurrentVehicleTrimID
        Tunnel2 = VehicleTrimDataGridView.Item("VehicleTrimName_ShortText25", CurrentVehicleTrimRow).Value

        VehicleModelsRelationsForm.VehicleTrimTextBox.Text = VehicleTrimDataGridView.Item("VehicleTrimName_ShortText25", CurrentVehicleTrimRow).Value
        VehicleTrimsForm.Enabled = True
    End Sub

End Class