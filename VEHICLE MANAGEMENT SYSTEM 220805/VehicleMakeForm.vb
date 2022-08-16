Public Class VehicleMakeForm
    Private CurrentVehicleMakeID As Integer = -1
    Private CurrentVehicleTypeRow As Integer = -1

    Private VehicleTypeDataGridViewInitialized = False

    Private VehicleTypeFieldsToSelect = ""
    Private VehicleTypeTablesLinks = ""
    Private VehicleTypeSelectionFilter = ""
    Private VehicleTypeSelectionOrder = ""
    Private MeLocationX As Integer
    Private MeLocationY As Integer
    Private SavedCallingForm As Form
    Private VehicleTypeDataGridViewAlreadyFormatted = False
    Private Sub VehicleTypeForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        SavedCallingForm = CallingForm
        ' form returns       Tunnel1 = CurrentVehicleMakeID
        '                    Tunnel2 = 
        ' ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        MeLocationX = Me.Location.X

        'GET ALL ENTRY PARAMETERS


        FillVehicleTypeDataGridView()

        'SET AND RESET ALL ENTRY PARAMETERS
    End Sub
    Private Sub FillVehicleTypeDataGridView()
        VehicleTypeFieldsToSelect = " SELECT  * "

        VehicleTypeTablesLinks = " FROM VehicleTypeTable "

        VehicleTypeSelectionOrder = " ORDER BY VehicleType_ShortText20 "
        MySelection = VehicleTypeFieldsToSelect & VehicleTypeTablesLinks & VehicleTypeSelectionFilter & VehicleTypeSelectionOrder

        JustExecuteMySelection()
        VehicleTypeDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If Not VehicleTypeDataGridViewAlreadyFormatted Then
            FormatVehicleTypeDataGridView()

        End If

    End Sub
    Private Sub FormatVehicleTypeDataGridView()
        VehicleTypeDataGridViewAlreadyFormatted = True

        VehicleTypeDataGridView.Columns.Item("VehicleTypeID_AutoNumber").Visible = False

        VehicleTypeDataGridView.Columns.Item("VehicleType_ShortText20").HeaderText = "Make"
        VehicleTypeDataGridView.Columns.Item("VehicleType_ShortText20").Width = 250

        VehicleTypeDataGridView.Width = VehicleTypeDataGridView.Columns.Item("VehicleType_ShortText20").Width + 50

        Me.Width = VehicleTypeDataGridView.Width + 10
        Dim xxx = RecordCount
    End Sub
    '   VehicleTypeDataGridView HANDLING

    Private Sub VehicleTypeDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles VehicleTypeDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If RecordCount = 0 Then Exit Sub
        CurrentVehicleTypeRow = e.RowIndex
        If Not VehicleTypeDataGridViewInitialized Then
            VehicleTypeDataGridViewInitialized = True
        End If
        If CurrentVehicleMakeID = VehicleTypeDataGridView.Item("VehicleTypeID_AutoNumber", CurrentVehicleTypeRow).Value Then Exit Sub
        CurrentVehicleMakeID = VehicleTypeDataGridView.Item("VehicleTypeID_AutoNumber", CurrentVehicleTypeRow).Value
    End Sub

    Private Sub VehicleTypeDataGridView_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles VehicleTypeDataGridView.DataBindingComplete
        Dim NoOfHeaderLines = 1
        Dim RecordsDisplyed = RecordCount
        Dim FormLowPointFromGrid = 90
        If RecordCount > 27 Then
            Me.Location = New Point(MeLocationX, 50)
            RecordsDisplyed = 27
        Else
            RecordsDisplyed = RecordCount + 1
        End If
        VehicleTypeDataGridView.Height = (VehicleTypeDataGridView.ColumnHeadersHeight * NoOfHeaderLines) + (DataGridViewRowHeight * RecordsDisplyed) + DataGridViewRowHeight
        Me.Height = VehicleTypeDataGridView.Height + FormLowPointFromGrid
        '       VehicleTypeDataGridView.Location = New Point(1, 49)
    End Sub
    Private Sub ToolStripTextBoxSearch_Click(sender As Object, e As EventArgs) Handles SearchVehicleTypeTextBox.Click
        If (SearchVehicleTypeTextBox.Text = "Search" Or SearchVehicleTypeTextBox.Text = "Type New Trim Here") Then
            SearchVehicleTypeTextBox.Text = ""
        End If

    End Sub

    Private Sub SearchVehicleTypeTextBox_TextChanged(sender As Object, e As EventArgs) Handles SearchVehicleTypeTextBox.TextChanged
        If Not VehicleTypeDataGridViewInitialized Then Exit Sub
        Dim FindKey As String = Trim(SearchVehicleTypeTextBox.Text)
        If FindKey = "" Or FindKey = "Type New Trim Here" Or FindKey = "Search" Then
            VehicleTypeSelectionFilter = ""
        Else
            RecordFinderDbControls.AddParam("@FindKey", "%" & FindKey & "%")
            VehicleTypeSelectionFilter = " WHERE VehicleType_ShortText20 LIKE @FindKey "
        End If
        FillVehicleTypeDataGridView()
    End Sub


    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click

        If Trim(SearchVehicleTypeTextBox.Text) = "Type New Trim Here" Then
            SearchVehicleTypeTextBox.Select()

            SearchVehicleTypeTextBox.BackColor = Color.Maroon
            Exit Sub


        End If
        If Trim(SearchVehicleTypeTextBox.Text) = "" Or Trim(SearchVehicleTypeTextBox.Text) = "Search" Then
            SearchVehicleTypeTextBox.Text = "Type New Trim Here"
            SearchVehicleTypeTextBox.Select()
            Exit Sub
        End If
        If RecordCount > 0 Then SearchVehicleTypeTextBox.Select() : Exit Sub
        Dim MyResponse = MsgBox("Confirm adding " & Trim(SearchVehicleTypeTextBox.Text) & " as new Make ?", vbYesNo)
        If Not MyResponse = vbYes Then
            SearchVehicleTypeTextBox.Select()
            Exit Sub
        End If

        '       VehicleTypeSelectionFilter = " WHERE VehicleTypeID_LongInteger = " & Str(CurrentVehicleMakeID) & " AND " & " VehicleTypeName_ShortText25 LIKE @FindKey "
        ' EXECUTE INSERT COMMAND

        MySelection = "INSERT INTO VehicleTypeTable (" &
                                            "VehicleType_ShortText20)  " &
                                      "VALUES (" &
                                              Chr(34) & Trim(SearchVehicleTypeTextBox.Text) & Chr(34) & " )"

        If NoRecordFound() Then Dim xxx As Integer = 0 'always IsNot found
        Dim VehicleTypeInQuote = Chr(34) & Trim(SearchVehicleTypeTextBox.Text) & Chr(34)
        MySelection = "Select * FROM VehicleTypeTable WHERE trim(VehicleType_ShortText20) = " & VehicleTypeInQuote

        If NoRecordFound() Then
            MsgBox("PROBLEM ...... unseccessful save ")
            Exit Sub
        End If
        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        CurrentVehicleMakeID = r("VehicleTypeID_AutoNumber")
        VehicleTypeSelectionFilter = ""
        FillVehicleTypeDataGridView()
    End Sub
    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click

    End Sub
    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim VehicleTypeText = VehicleTypeDataGridView.Item("VehicleType_ShortText20", CurrentVehicleTypeRow).Value & " " &
                              VehicleTypeDataGridView.Item("VehicleModel_ShortText20", CurrentVehicleTypeRow).Value & " " &
                              VehicleTypeDataGridView.Item("VehicleTypeName_ShortText25", CurrentVehicleTypeRow).Value

        ' check this       VehicleTypeSelectionFilter = " Select * from VehiclesTable WHERE VehicleModelID_LongInteger = " & Str(CurrentVehicleModelsRelationID)
        If NoRecordFound() Then
            MsgBox("Unable To delete " & VehicleTypeText)
            Exit Sub
        End If
        If Not MsgBox("Confirm DELETION of " & VehicleTypeText & " ?", vbYesNo) = vbYes Then
            SearchVehicleTypeTextBox.Select()
            Exit Sub
        End If
    End Sub

    Private Sub SelectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectToolStripMenuItem.Click

        Tunnel1 = "Tunnel2IsVehicleMakeID"
        Tunnel2 = CurrentVehicleMakeID
        Tunnel3 = VehicleTypeDataGridView.Item("VehicleType_ShortText20", CurrentVehicleTypeRow).Value
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub
    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub
End Class