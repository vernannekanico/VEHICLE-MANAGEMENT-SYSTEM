Public Class CountryForm
    Dim CurrentCountryID As Integer
    Dim SavedCountryID As Integer
    Private SavedCallingForm As Form

    Private Sub CountryForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        'GET ALL ENTRY PARAMETERS
        SavedCallingForm = CallingForm
        SetUpCountryComboBox()
        If Not Tunnel1 = "" Then
            CountryComboBox.SelectedItem = Tunnel1
            SavedCountryID = CurrentCountryID
        End If
        'SET AND RESET ALL ENTRY PARAMETERS
    End Sub

    Private Sub SetUpCountryComboBox()
        Dim TableToUse = " CountryTable "
        Dim FieldToDisplay = "CountryName_ShortText25"
        Dim OrderBy = " ORDER BY CountryName_ShortText25 asc"

        MySelection = "SELECT * FROM " & TableToUse & OrderBy
        RecordFinderDbControls.MyDbCommand(MySelection)
        CountryComboBox.Items.Clear()

        ' FILL COMBOBOX
        For Each R As DataRow In RecordFinderDbControls.MyAccessDbDataTable.Rows
            CountryComboBox.Items.Add(R(FieldToDisplay))
        Next

        ' DISPLAY FIRS NAME FOUND
        If RecordFinderDbControls.MyAccessDbDataTable.Rows.Count > 0 Then CountryComboBox.SelectedIndex = 0

        CountryComboBox.Visible = True

    End Sub

    Private Sub GetCountryID(CountryName As String)
        ' QUERY USER
        RecordFinderDbControls.AddParam("@user", CountryName)
        MySelection = "SELECT TOP 1 CountryID_AutoNumber, CountryName_ShortText25 FROM CountryTable WHERE CountryName_ShortText25=@CountryName "

        ' REPORT & ABORT ON ERRORS OR NO RECORDS FOUND
        If NoRecordFound() Then Exit Sub

        ' GET FIRST ROW FOUND
        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)

        ' POPULATE TEXTBOXES WITH DATA
        CurrentCountryID = r("CountryID_AutoNumber")

    End Sub

    Private Sub CountryComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CountryComboBox.SelectedIndexChanged
        Dim CountrySelectedIndex = CountryComboBox.SelectedIndex
        Dim CountrySelectedItem = CountryComboBox.SelectedItem
        If NotEmpty(CountryComboBox.Text) Then GetCountryID(CountryComboBox.Text)

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click

    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click

    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click

    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles SelectCountryToolStripMenuItem.Click
        Tunnel1 = "Tunnel2IsCountryID"
        Tunnel2 = CurrentCountryID
        Tunnel3 = CityForm.CountryTextBox.Text = CountryComboBox.SelectedItem
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub
    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub
    Private Sub CountryForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        If Me.Enabled = False Then Exit Sub
        CallingForm = SavedCallingForm
    End Sub
End Class