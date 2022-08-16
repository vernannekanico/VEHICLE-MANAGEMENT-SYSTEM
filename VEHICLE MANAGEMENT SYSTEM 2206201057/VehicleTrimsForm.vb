Public Class VehicleTrimsForm
    Private CurrentVehicleTrimID As Integer = -1
    Private CurrentVehicleTrimRow As Integer = -1

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


        MeLocationX = Me.Location.X


        VehicleTrimSelectionFilter = ""

        FillVehicleTrimDataGridView()

    End Sub
    Private Sub FillVehicleTrimDataGridView()
        VehicleTrimFieldsToSelect = " SELECT VehicleTrimTable.VehicleTrimID_Autonumber, VehicleTrimTable.VehicleTrimName_ShortText25 "

        VehicleTrimTablesLinks = " FROM VehicleTrimTable "

        VehicleTrimSelectionOrder = " ORDER BY VehicleTrimName_ShortText25 "
        MySelection = VehicleTrimFieldsToSelect & VehicleTrimTablesLinks & VehicleTrimSelectionFilter & VehicleTrimSelectionOrder

        JustExecuteMySelection()
        VehicleTrimDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
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

        ' ***********************************************************
        VehicleTrimDataGridView.Columns.Item("VehicleTrimID_Autonumber").Visible = False

        VehicleTrimDataGridView.Columns.Item("VehicleTrimName_ShortText25").HeaderText = "Trim"
        VehicleTrimDataGridView.Columns.Item("VehicleTrimName_ShortText25").Width = 250


        VehicleTrimDataGridView.Width = VehicleTrimDataGridView.Columns.Item("VehicleTrimName_ShortText25").Width + 10

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

    Private Sub SearchVehicleTrimTextBox_GotFocus(sender As Object, e As EventArgs) Handles SearchVehicleTrimTextBox.GotFocus
        '       SearchVehicleTrimTextBox.BackColor = SearchTextBoxHighLightForeColor
        '     SearchVehicleTrimTextBox.ForeColor = SearchTextBoxHighlightBackColor

    End Sub

    Private Sub SearchVehicleTrimTextBox_LostFocus(sender As Object, e As EventArgs) Handles SearchVehicleTrimTextBox.LostFocus
        '       SearchVehicleTrimTextBox.BackColor = SearchTextBoxNormalBackColor
        '      SearchVehicleTrimTextBox.ForeColor = SearchTextBoxNormalForeColor

    End Sub
    Private Sub ToolStripTextBoxSearch_Click(sender As Object, e As EventArgs) Handles SearchVehicleTrimTextBox.Click
        If (SearchVehicleTrimTextBox.Text = "Search" Or SearchVehicleTrimTextBox.Text = "Type New Trim Here") Then
            SearchVehicleTrimTextBox.Text = ""
        End If

    End Sub

    Private Sub SearchVehicleTrimTextBox_TextChanged(sender As Object, e As EventArgs) Handles SearchVehicleTrimTextBox.TextChanged
        If Not VehicleTrimDataGridViewInitialized Then Exit Sub
        If EditToolStripMenuItem.Text = "Save" Then Exit Sub
        Dim FindKey As String = Trim(SearchVehicleTrimTextBox.Text)
        If FindKey = "" Or FindKey = "Type New Trim Here" Then
            SearchVehicleTrimTextBox.Select()
            Exit Sub
        End If
        FindKey = SearchVehicleTrimTextBox.Text
        RecordFinderDbControls.AddParam("@FindKey", "%" & FindKey & "%")
        VehicleTrimSelectionFilter = " WHERE VehicleTrimName_ShortText25 LIKE @FindKey "
        FillVehicleTrimDataGridView()
    End Sub


    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click


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
            If Trim(SearchVehicleTrimTextBox.Text) = Trim(VehicleTrimDataGridView.Item("VehicleTrimName_ShortText25", CurrentVehicleTrimRow).Value) Then Exit Sub

        End If
        SearchVehicleTrimTextBox.Text = SearchVehicleTrimTextBox.Text.ToUpper
        If Not MsgBox("Confirm adding " & Trim(SearchVehicleTrimTextBox.Text) & " as new TRIM " & " ?", vbYesNo) = vbYes Then
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

        MySelection = "INSERT INTO VehicleTrimTable (" & "VehicleTrimName_ShortText25)  " & "VALUES (" & VehicleTrimInQuote & " )"
        ' DELETE       Chr(34) & Trim(SearchVehicleTrimTextBox.Text) & Chr(34) & " )"

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
        'Check if there are links to the Table
        'if there exists then ask if real change action

        '       MySelection = "Select * from MyStandardTable " &
        '                     "Where MyStandardID_AutoNumber = " & Str(CurrentMyStandardID)
        '       If RecordIsFound() Then

        ' at this point EDIT FEATURE IS JUST ALLOWED
        Select Case EditToolStripMenuItem.Text
            Case "Edit"
                If Not MsgBox("This TRIM is currently LINKED to other Files, DELETE 1ST ALL LINKS TO DELETE THIS TRIM, update this option to check for links before changes are made?", vbYesNo) = vbYes Then
                    Exit Sub
                End If
                '       End If

                VehicleTrimSelectionFilter = " WHERE VehicleTrimTable.VehicleTrimID_Autonumber = " & Str(CurrentVehicleTrimID) & " "
                FillVehicleTrimDataGridView()
                EditToolStripMenuItem.Text = "Save"
                AddToolStripMenuItem.Enabled = False
                DeleteToolStripMenuItem.Enabled = False
                SelectToolStripMenuItem.Enabled = False

                SearchVehicleTrimTextBox.Select()
                SearchVehicleTrimTextBox.Text = "Type New Trim Here"
            Case "Save"
                If Trim(EditToolStripMenuItem.Text) = "" Then
                    Exit Sub
                End If

                Dim VehicleTrimInQuote = Chr(34) & Trim(SearchVehicleTrimTextBox.Text) & Chr(34)

                MySelection = "Select * FROM VehicleTrimTable WHERE trim(VehicleTrimName_ShortText25) = " & VehicleTrimInQuote.ToUpper

                If RecordIsFound() Then
                    MsgBox("This trim already exists ")
                    Exit Sub
                End If


                If Not MsgBox(" Confirm Saving changes for THE TRIM " & VehicleTrimDataGridView.Item("VehicleTrimName_ShortText25", CurrentVehicleTrimRow).Value, vbYesNo) = vbYes Then
                    Exit Sub
                End If

                Dim VehicleTrimFilter = " WHERE VehicleTrimID_AutoNumber = " & Str(CurrentVehicleTrimID)

                VehicleTrimFieldsToSelect = " UPDATE VehicleTrimTable  SET " & " VehicleTrimName_ShortText25  = " & VehicleTrimInQuote.ToUpper

                MySelection = VehicleTrimFieldsToSelect & VehicleTrimFilter
                If NoRecordFound() Then Dim dummy = 1


                EditToolStripMenuItem.Text = "Edit"
                AddToolStripMenuItem.Enabled = True
                DeleteToolStripMenuItem.Enabled = True
                SelectToolStripMenuItem.Enabled = True

                SearchVehicleTrimTextBox.Text = ""
                VehicleTrimSelectionFilter = ""
                FillVehicleTrimDataGridView()
            Case Else
                Dim XXXX = 1
        End Select



    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim VehicleTrimText = VehicleTrimDataGridView.Item("VehicleTrimName_ShortText25", CurrentVehicleTrimRow).Value

        VehicleTrimSelectionFilter = " Select * from VehiclesTable  "
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
        Tunnel1 = "Tunnel2IsVehicleTrimID"
        Tunnel2 = CurrentVehicleTrimID
        Tunnel3 = VehicleTrimDataGridView.Item("VehicleTrimName_ShortText25", CurrentVehicleTrimRow).Value
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub
    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub

End Class