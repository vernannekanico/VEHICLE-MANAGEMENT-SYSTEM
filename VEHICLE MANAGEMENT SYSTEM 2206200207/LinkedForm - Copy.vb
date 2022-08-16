Public Class LinkedForm
    Private CurrentCityID As Integer = -1
    Private CurrentCityRow As Integer
    Private CurrentCityID_AutoNumber As Integer
    Private CurrentStateID As Integer
    Private CurrentCountryID As Integer
    Private CurrentZipCode As String
    Private DefaultStateID As Integer
    Private DefaultCountryID As Integer

    Private CityDataGridViewInitialized = False

    Private CityFieldsToSelect = ""
    Private CityTablesLinks = ""
    Private CitySelectionFilter = ""
    Private CitySelectionOrder = ""
    Private MeLocationX As Integer
    Private MeLocationY As Integer

    Private Sub CityForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        MeLocationX = Me.Location.X

        'GET ALL ENTRY PARAMETERS

        CitySelectionFilter = ""
        If NotEmpty(Tunnel1) Then
            DefaultStateID = GetStateID(Tunnel1)
            CitySelectionFilter = " WHERE StateProvID_LongInteger = " & Str(DefaultStateID) & " "

        End If
        If NotEmpty(Tunnel2) Then
            DefaultCountryID = GetCountryID(Tunnel2)
            If NotEmpty(CitySelectionFilter) Then
                CitySelectionFilter = CitySelectionFilter & " AND CountryID_LongInteger = " & Str(DefaultCountryID) & " "
            Else
                CitySelectionFilter = " WHERE CountryID_LongInteger = " & Str(DefaultCountryID) & " "
            End If
        End If

        FillCityDataGridView()

        CityDataGridView.Columns.Item("CityID_AutoNumber").Visible = False
        CityDataGridView.Columns.Item("StateProvID_LongInteger").Visible = False
        CityDataGridView.Columns.Item("CountryID_LongInteger").Visible = False

        CityDataGridView.Columns.Item("CityName_ShortText25").HeaderText = "City"
        CityDataGridView.Columns.Item("CityName_ShortText25").Width = 150

        CityDataGridView.Columns.Item("StateProvName_ShortText25").HeaderText = "State"
        CityDataGridView.Columns.Item("StateProvName_ShortText25").Width = 150

        CityDataGridView.Columns.Item("StateCode_ShortText2").HeaderText = ""
        CityDataGridView.Columns.Item("StateCode_ShortText2").Width = 35


        CityDataGridView.Columns.Item("CountryName_ShortText25").HeaderText = "State"
        CityDataGridView.Columns.Item("CountryName_ShortText25").Width = 200

        CityDataGridView.Columns.Item("ZipCode_ShortText9").HeaderText = "ZipCode"
        CityDataGridView.Columns.Item("ZipCode_ShortText9").Width = 100


        CityDataGridView.Width = CityDataGridView.Columns.Item("CityName_ShortText25").Width +
                                 CityDataGridView.Columns.Item("StateProvName_ShortText25").Width +
                                 CityDataGridView.Columns.Item("StateCode_ShortText2").Width +
                                 CityDataGridView.Columns.Item("ZipCode_ShortText9").Width +
                                 CityDataGridView.Columns.Item("CountryName_ShortText25").Width +
                                 50
        Me.Width = CityDataGridView.Width + 10

        'SET AND RESET ALL ENTRY PARAMETERS
        ResetTunnels()

    End Sub


    '   CityDataGridView HANDLING

    Private Sub FillCityDataGridView()
        CityFieldsToSelect = " Select CityTable.CityID_AutoNumber, " &
                                    " CityTable.CityName_ShortText25, " &
                                    " CityTable.StateProvID_LongInteger, " &
                                    " StateProvTable.StateProvName_ShortText25,  " &
                                    " StateProvTable.StateCode_ShortText2,  " &
                                    " CityTable.ZipCode_ShortText9, " &
                                    " StateProvTable.CountryID_LongInteger,  " &
                                    " CountryTable.CountryName_ShortText25 "



        CityTablesLinks = " From CityTable LEFT Join (StateProvTable LEFT Join CountryTable " &
                                                   " On StateProvTable.CountryID_LongInteger = CountryTable.CountryID_Autonumber) " &
                                                   " ON CityTable.StateProvID_LongInteger = StateProvTable.StateProvID_AutoNumber "

        CitySelectionOrder = " Order by CityName_ShortText25 Asc "
        MySelection = CityFieldsToSelect & CityTablesLinks & CitySelectionFilter & CitySelectionOrder

        JustExecuteMySelection()
        CityDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

    End Sub
    Private Sub CityDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles CityDataGridView.RowEnter
        If e.RowIndex < 0 Then Exit Sub
        If RecordCount = 0 Then Exit Sub
        CurrentCityRow = e.RowIndex
        If Not CityDataGridViewInitialized Then
            CityDataGridViewInitialized = True
        End If
        If CurrentCityID = CityDataGridView.Item("CityID_AutoNumber", CurrentCityRow).Value Then Exit Sub
        CurrentCityID = CityDataGridView.Item("CityID_AutoNumber", CurrentCityRow).Value
        CurrentCityID_AutoNumber = CityDataGridView.Item("CityID_AutoNumber", CurrentCityRow).Value
        CurrentZipCode = CityDataGridView.Item("ZipCode_ShortText9", CurrentCityRow).Value

    End Sub
    Private Sub CityDataGridView_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles CityDataGridView.DataBindingComplete
        Dim NoOfHeaderLines = 2
        Dim RecordsDisplyed = RecordCount
        Dim FormLowPointFromGrid = 90
        If RecordCount > 27 Then
            Me.Location = New Point(MeLocationX, 50)
            RecordsDisplyed = 27
        Else
            RecordsDisplyed = RecordCount + 1
        End If
        CityDataGridView.Height = (CityDataGridView.ColumnHeadersHeight * NoOfHeaderLines) + (DataGridViewRowHeight * RecordsDisplyed) + DataGridViewRowHeight
        Me.Height = CityDataGridView.Height + FormLowPointFromGrid
        '       CityDataGridView.Location = New Point(1, 49)
    End Sub


    '   CityDataGridView HANDLING                       ENDS


    Private Sub ShowCityDetailsForm()
        CityDetailsForm.ActivatedBy.Text = Me.Name
        CityDetailsForm.Show()
    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        Tunnel1 = "ADD"
        ' setup default here
        CityDetailsForm.StateProvTextBox.Text = DefaultStateName
        CityDetailsForm.CountryTextBox.Text = DefaultCountryName
        If NotEmpty(SearchLinkedTextBox.Text) And RecordCount = 0 Then
            CityDetailsForm.CityTextBox.Text = SearchLinkedTextBox.Text
            SearchLinkedTextBox.Text = ""
        End If
        ShowCityDetailsForm()
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        Tunnel1 = "EDIT"
        LoadCityDetails()
        ShowCityDetailsForm()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Tunnel1 = "EDIT"
        LoadCityDetails()
        Me.Enabled = False

        ShowCityDetailsForm()

        Dim Question As String = "Proceed to delete"
        Dim DeleteThisConcern As String = MsgBox(Question, 4)
        If Not DeleteThisConcern = "6" Then

            GoTo ResetActionTaken
        End If
        RecordFinderDbControls.AddParam("@CurrentCityID", CurrentCityID)
        MySelection = "DELETE FROM CityTable WHERE trim(CityNumber_ShortText12) = @CurrentCityID"

        If NoRecordFound() Then Dim DIMXYZ = 0
ResetActionTaken:
        CityDetailsForm.Close()
        '        GetSelectedCity(1)
    End Sub

    Private Sub LoadCityDetails()
        CityFieldsToSelect = " Select CityTable.CityID_Autonumber, " &
                             " CityTable.City_ShortText9, " &
                             " CityTable.CityName_ShortText25, " &
                             " StateTable.State_ShortText25, " &
                             " CountryTable. "


        If Not IsDBNull(CityDataGridView("CityID_Autonumber", CurrentCityRow).Value) Then
            CityDetailsForm.CityTextBox.Text = CityDataGridView("CityID_Autonumber", CurrentCityRow).Value
        End If
        If Not IsDBNull(CityDataGridView("City_ShortText9", CurrentCityRow).Value) Then
            CityDetailsForm.CityTextBox.Text = CityDataGridView("City_ShortText9", CurrentCityRow).Value
        End If
        If Not IsDBNull(CityDataGridView("CityName_ShortText25", CurrentCityRow).Value) Then
            CityDetailsForm.CityTextBox.Text = CityDataGridView("CityName_ShortText25", CurrentCityRow).Value
        End If
        If Not IsDBNull(CityDataGridView("State_ShortText25", CurrentCityRow).Value) Then
            Tunnel1 = CityDataGridView("State_ShortText25", CurrentCityRow).Value
        End If
    End Sub



    Private Sub ToolStripTextBoxSearch_TextChanged(sender As Object, e As EventArgs)
        If Not CityDataGridViewInitialized Then Exit Sub
        Dim FindKey As String = Trim(SearchLinkedTextBox.Text)
        Dim SearchCitySelectionFilter = ""
        If NotEmpty(FindKey) Then
            SearchCitySelectionFilter = "  WHERE CityName_ShortText25 LIKE @FindKey "
        End If
        RecordFinderDbControls.AddParam("@FindKey", "%" & FindKey & "%")
        MySelection = CityFieldsToSelect & CityTablesLinks & SearchCitySelectionFilter & CitySelectionOrder
        JustExecuteMySelection()
        CityDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
    End Sub
    Private Sub SelectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectToolStripMenuItem.Click
        Tunnel1 = CurrentCityID
        Select Case ActivatedBy.Text
            Case "OwnerDetailsForm"
                OwnerDetailsForm.CityTextBox.Text = CityDataGridView.Item("CityName_ShortText25", CurrentCityRow).Value
                OwnerDetailsForm.ZipCodeTextBox.Text = CityDataGridView.Item("ZipCode_ShortText9", CurrentCityRow).Value
                OwnerDetailsForm.StateProvTextBox.Text = CityDataGridView.Item("StateProvName_ShortText25", CurrentCityRow).Value
                OwnerDetailsForm.CountryTextBox.Text = CityDataGridView.Item("CountryName_ShortText25", CurrentCityRow).Value
            Case "PersonnelForm"
                PersonnelForm.CityTextBox.Text = CityDataGridView.Item("CityName_ShortText25", CurrentCityRow).Value
                PersonnelForm.ZipCodeTextBox.Text = CityDataGridView.Item("ZipCode_ShortText9", CurrentCityRow).Value
                PersonnelForm.StateProvTextBox.Text = CityDataGridView.Item("StateProvName_ShortText25", CurrentCityRow).Value
                PersonnelForm.CountryTextBox.Text = CityDataGridView.Item("CountryName_ShortText25", CurrentCityRow).Value
            Case "MyStandardForm"
                MyStandardForm.LinkedTextBox.Text = CityDataGridView.Item("CityName_ShortText25", CurrentCityRow).Value
                MyStandardForm.ZipCodeTextBox.Text = CityDataGridView.Item("ZipCode_ShortText9", CurrentCityRow).Value
                MyStandardForm.StateProvTextBox.Text = CityDataGridView.Item("StateProvName_ShortText25", CurrentCityRow).Value
                MyStandardForm.CountryTextBox.Text = CityDataGridView.Item("CountryName_ShortText25", CurrentCityRow).Value

            Case Else
                Dim xxx = 1
        End Select


        Me.Close()
    End Sub
    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        Tunnel1 = -1
        Me.Close()
    End Sub
    Private Sub CityForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        'Enables calling form
        Select Case ActivatedBy.Text
            Case "VehicleManagementSystemForm"
                VehicleManagementSystemForm.Enabled = True ' triggers enabledchaned event of calling form
            Case "OwnerDetailsForm"
                OwnerDetailsForm.Enabled = True
            Case "PersonnelForm"
                PersonnelForm.Enabled = True
            Case "MyStandardForm"
                MyStandardForm.Enabled = True
            Case Else

                Dim x = "break here"
        End Select
        ActivatedBy.Text = ""
    End Sub
    Private Sub CityForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        'Refresh datagridviw here
        ' GET RETURNED DATA HERE
        If Me.Enabled = True And NotEmpty(Tunnel1) Then
            FillCityDataGridView()
        End If
    End Sub
    Private Sub ToolStripTextBoxSearch_Click(sender As Object, e As EventArgs) Handles SearchLinkedTextBox.Click
        If SearchLinkedTextBox.Text = "Search" Then SearchLinkedTextBox.Text = ""
    End Sub

    Private Sub ToolStripTextBoxSearch_ReadOnlyChanged(sender As Object, e As EventArgs) Handles SearchLinkedTextBox.ReadOnlyChanged
    End Sub

    Private Sub SearchCityTextBox_TextChanged(sender As Object, e As EventArgs) Handles SearchLinkedTextBox.TextChanged
        If Not CityDataGridViewInitialized Then Exit Sub
        Dim FindKey As String = Trim(SearchLinkedTextBox.Text)
        If FindKey = "" Then Exit Sub
        RecordFinderDbControls.AddParam("@FindKey", "%" & FindKey & "%")

        Dim CitySSearchFilter = "  WHERE ZipCode_ShortText9 LIKE @FindKey or CityName_ShortText25 LIKE @FindKey "

        MySelection = CityFieldsToSelect & CityTablesLinks & CitySSearchFilter & CitySelectionOrder
        JustExecuteMySelection()
        CityDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

    End Sub
    ' FUNCTIONS
    Private Function GetStateID(StateName)

        RecordFinderDbControls.AddParam("@FindKey", StateName)

        MySelection = "Select * " &
                      "From StateProvTable " &
                      " WHERE StateProvName_ShortText25 = @FindKey "

        If NoRecordFound() Then Return ""
        Dim r As DataRow = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        Return Trim(r("StateProvID_AutoNumber"))
    End Function
    Private Function GetCountryID(CountryName)
        RecordFinderDbControls.AddParam("@FindKey", CountryName)

        MySelection = "Select * " &
                      "From CountryTable " &
                      " WHERE CountryName_ShortText25 = @FindKey "

        If NoRecordFound() Then Return ""
        Dim r As DataRow = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        Return Trim(r("CountryID_Autonumber"))
    End Function

End Class