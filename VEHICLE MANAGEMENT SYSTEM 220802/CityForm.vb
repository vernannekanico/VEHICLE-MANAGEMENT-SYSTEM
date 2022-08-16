' Initialized States to “California”, Country  to “United States of America” unless filter Is pre provided
' Filter for State And Country Is made available
' DataGridView.Width is inialized at Me.Load
' Set Tunnel1 = CurrentCityID at "Select" option

Public Class CityForm
    Private CurrentCityID As Integer = -1
    Private CurrentCityDataGridViewRow As Integer
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

    Dim PurposeOfEntry = ""
    Private SavedCallingForm As Form

    Private Sub CityForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        SavedCallingForm = CallingForm
        MeLocationX = Me.Location.X

        'GET ALL ENTRY PARAMETERS

        CitySelectionFilter = ""
        If NotEmpty(Tunnel1) Then
            DefaultStateID = GetStateID(Tunnel1)
            CitySelectionFilter = " WHERE StateProvID_LongInteger = " & Str(DefaultStateID) & " "

        End If
        If IsNotEmpty(Tunnel2) Then
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
    Private Sub CityDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles CityDataGridView.RowEnter

        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If RecordCount = 0 Then Exit Sub
        CurrentCityDataGridViewRow = e.RowIndex
        If Not CityDataGridViewInitialized Then
            CityDataGridViewInitialized = True
        End If
        If CurrentCityID = CityDataGridView.Item("CityID_AutoNumber", CurrentCityDataGridViewRow).Value Then Exit Sub
        CurrentCityID = CityDataGridView.Item("CityID_AutoNumber", CurrentCityDataGridViewRow).Value

        CurrentZipCode = CityDataGridView.Item("ZipCode_ShortText9", CurrentCityDataGridViewRow).Value

    End Sub


    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        PurposeOfEntry = "ADD"

        ' setup default here
        StateProvTextBox.Text = DefaultStateName
        CountryTextBox.Text = DefaultCountryName
        If NotEmpty(SearchCityTextBox.Text) And RecordCount = 0 Then
            CityTextBox.Text = SearchCityTextBox.Text
            SearchCityTextBox.Text = ""
        End If

        CityDetailsGroupBox.Visible = True
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        Tunnel1 = "EDIT"
        LoadCityDetails()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Tunnel1 = "EDIT"
        LoadCityDetails()


        Dim Question As String = "Proceed to delete"
        Dim DeleteThisConcern As String = MsgBox(Question, 4)
        If Not DeleteThisConcern = "6" Then

            CityDetailsGroupBox.Visible = False
            Exit Sub
        End If
        RecordFinderDbControls.AddParam("@CurrentCityID", CurrentCityID)
        MySelection = "DELETE FROM CityTable WHERE trim(CityNumber_ShortText12) = @CurrentCityID"

        If NoRecordFound() Then Dim DIMXYZ = 0
    End Sub

    Private Sub LoadCityDetails()
        CityFieldsToSelect = " Select CityTable.CityID_Autonumber, " &
                             " CityTable.City_ShortText9, " &
                             " CityTable.CityName_ShortText25, " &
                             " StateTable.State_ShortText25, " &
                             " CountryTable. "


        If Not IsDBNull(CityDataGridView("CityID_Autonumber", CurrentCityDataGridViewRow).Value) Then
            CityTextBox.Text = CityDataGridView("CityID_Autonumber", CurrentCityDataGridViewRow).Value
        End If
        If Not IsDBNull(CityDataGridView("City_ShortText9", CurrentCityDataGridViewRow).Value) Then
            CityTextBox.Text = CityDataGridView("City_ShortText9", CurrentCityDataGridViewRow).Value
        End If
        If Not IsDBNull(CityDataGridView("CityName_ShortText25", CurrentCityDataGridViewRow).Value) Then
            CityTextBox.Text = CityDataGridView("CityName_ShortText25", CurrentCityDataGridViewRow).Value
        End If
        If Not IsDBNull(CityDataGridView("State_ShortText25", CurrentCityDataGridViewRow).Value) Then
            Tunnel1 = CityDataGridView("State_ShortText25", CurrentCityDataGridViewRow).Value
        End If
    End Sub

    Private Sub ToolStripTextBoxSearch_TextChanged(sender As Object, e As EventArgs)
        If Not CityDataGridViewInitialized Then Exit Sub
        Dim FindKey As String = Trim(SearchCityTextBox.Text)
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
        Tunnel1 = "Tunnel2IsCityID"
        Tunnel2 = CurrentCityID
        Select Case CallingForm.Name
            Case "OwnersForm"
                OwnersForm.CityTextBox.Text = CityDataGridView.Item("CityName_ShortText25", CurrentCityDataGridViewRow).Value
                OwnersForm.ZipCodeTextBox.Text = CityDataGridView.Item("ZipCode_ShortText9", CurrentCityDataGridViewRow).Value
                OwnersForm.StateProvTextBox.Text = CityDataGridView.Item("StateProvName_ShortText25", CurrentCityDataGridViewRow).Value
                OwnersForm.CountryTextBox.Text = CityDataGridView.Item("CountryName_ShortText25", CurrentCityDataGridViewRow).Value
            Case "PersonnelForm"
                PersonnelsForm.CityTextBox.Text = CityDataGridView.Item("CityName_ShortText25", CurrentCityDataGridViewRow).Value
                PersonnelsForm.ZipCodeTextBox.Text = CityDataGridView.Item("ZipCode_ShortText9", CurrentCityDataGridViewRow).Value
                PersonnelsForm.StateProvTextBox.Text = CityDataGridView.Item("StateProvName_ShortText25", CurrentCityDataGridViewRow).Value
                PersonnelsForm.CountryTextBox.Text = CityDataGridView.Item("CountryName_ShortText25", CurrentCityDataGridViewRow).Value
            Case Else
                Dim xxx = 1
        End Select
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub
    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub
    Private Sub CityForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        'Refresh datagridviw here
        ' GET RETURNED DATA HERE
        If Me.Enabled = False Then Exit Sub
        CallingForm = SavedCallingForm
        Select Case Tunnel1
            Case "Tunnel2IsCityID"
                Tunnel2 = CurrentCityID
        End Select
    End Sub
    Private Sub ToolStripTextBoxSearch_Click(sender As Object, e As EventArgs) Handles SearchCityTextBox.Click
        If SearchCityTextBox.Text = "Search" Then SearchCityTextBox.Text = ""
    End Sub

    Private Sub SearchCityTextBox_TextChanged(sender As Object, e As EventArgs) Handles SearchCityTextBox.TextChanged
        If Not CityDataGridViewInitialized Then Exit Sub
        Dim FindKey As String = Trim(SearchCityTextBox.Text)
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
        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        Return Trim(r("StateProvID_AutoNumber"))
    End Function
    Private Function GetCountryID(CountryName)
        RecordFinderDbControls.AddParam("@FindKey", CountryName)

        MySelection = "Select * " &
                      "From CountryTable " &
                      " WHERE CountryName_ShortText25 = @FindKey "

        If NoRecordFound() Then Return ""
        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        Return Trim(r("CountryID_Autonumber"))
    End Function



    '****************************************************************************************************


    Private Sub SaveNewCity()
        'test existince here


        RecordFinderDbControls.AddParam("@CityName_ShortText25", Trim(CityTextBox.Text))
        RecordFinderDbControls.AddParam("@StateProvID_LongInteger", CurrentStateID)

        MySelection = "SELECT * " &
                       " FROM CityTable " &
                      " WHERE trim(CityName_ShortText25) = @CityName_ShortText25 " &
                       " AND StateProvID_LongInteger = @StateProvID_LongInteger "

        If NoRecordFound() Then
            AddACityRecord()
        Else
            MsgBox("This record already exists")
            CurrentCityID = -1
            Exit Sub
        End If
    End Sub
    Private Sub AddACityRecord()

        ' EXECUTE INSERT COMMAND

        'CityID_AutoNumber,CityName_ShortText25,StateProvID_LongInteger,

        RecordFinderDbControls.AddParam("@CityName_ShortText25", Trim(CityTextBox.Text))
        RecordFinderDbControls.AddParam("@StateProvID_LongInteger", CurrentStateID)
        RecordFinderDbControls.AddParam("@ZipCode_ShortText9", ZipCodeMaskedTextBox.Text)

        MySelection = "INSERT INTO CityTable (CityName_ShortText25, " &
                                             "StateProvID_LongInteger, " &
                                             "ZipCode_ShortText9) " &
                                             "VALUES (@CityName_ShortText25, " &
                                             "@StateProvID_LongInteger,  " &
                                             "@ZipCode_ShortText9)  "


        If NoRecordFound() Then Dim xxx As Integer = -1 'always IsNot found

        'FindForm the record And set the New cityidautonumber

        RecordFinderDbControls.AddParam("@CurrentCityName", Trim(CityTextBox.Text))

        CitySelectionFilter = "  WHERE trim(CityName_ShortText25) = @CurrentCityName "

        MySelection = "Select * FROM CityTable " & CitySelectionFilter

        If NoRecordFound() Then
            MsgBox("PROBLEM ...... not in the table add the new StateProv here make the codes here break the prog ")
            Exit Sub
        End If

        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        CurrentCityID = r("CityID_AutoNumber")
    End Sub

    Private Sub StateTextBox_Click(sender As Object, e As EventArgs) Handles StateProvTextBox.Click

        If Not Trim(StateProvTextBox.Text) = "" Then

            If MsgBox("Would you like to change the State", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                CurrentStateID = -1
                StateProvTextBox.Text = ""
            Else
                CityTextBox.Select()
                Exit Sub
            End If
        End If
        Tunnel1 = CurrentStateID
        Tunnel2 = CurrentCountryID
        StateProvForm.Show()
        StateProvForm.Select()
    End Sub

    Private Sub CityTextBox_GotFocus(sender As Object, e As EventArgs) Handles CityTextBox.GotFocus
        If Trim(CountryTextBox.Text) = "" Then
            CountryTextBox.Select()
            Exit Sub
        End If
        If Trim(StateProvTextBox.Text) = "" Then
            StateProvTextBox.Select()
        End If
    End Sub

    Private Sub StateTextBox_GotFocus(sender As Object, e As EventArgs) Handles StateProvTextBox.GotFocus
        If Trim(CountryTextBox.Text) = "" Then
            CountryTextBox.Select()
            Exit Sub
        End If
        If Trim(StateProvTextBox.Text) = "" Then
            Tunnel2 = CurrentCountryID ' filter for country
            StateProvForm.Show()
            If NotEmpty(Tunnel1) Then
                CurrentStateID = Tunnel1
                Tunnel1 = ""
            End If
        End If
        CityTextBox.Select()
    End Sub

    Private Sub CountryTextBox_GotFocus(sender As Object, e As EventArgs) Handles CountryTextBox.GotFocus
        If Trim(CountryTextBox.Text) = "" Then
            CountryForm.Show()
        End If
        StateProvTextBox.Select()
    End Sub

    Private Sub me_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        If Me.Enabled = False Then Exit Sub
        CallingForm = SavedCallingForm
        Select Case Tunnel1
            Case "Tunnel2IsCountryID"
                CurrentCountryID = Tunnel2
                CountryTextBox.Text = Tunnel3
        End Select
    End Sub

    Private Sub CityTextBox_TextChanged(sender As Object, e As EventArgs) Handles CityTextBox.TextChanged
        If Trim(CityTextBox.Text) = "Search" Then CityTextBox.Text = ""
        SearchCityTextBox.Text = Trim(CityTextBox.Text)
    End Sub

    Private Sub StateTextBox_TextChanged(sender As Object, e As EventArgs) Handles StateProvTextBox.TextChanged
        Dim CurrentStateProvName As String = Trim(StateProvTextBox.Text)
        If CurrentStateProvName = "" Then
            CurrentStateID = -1
            Exit Sub
        End If
        RecordFinderDbControls.AddParam("@CurrentStateProvName", Trim(CurrentStateProvName))

        Dim StateProvSelectionFilter = "  WHERE trim(StateProvName_ShortText25) = @CurrentStateProvName "

        MySelection = "Select * FROM StateProvTable " & StateProvSelectionFilter

        If NoRecordFound() Then
            MsgBox("PROBLEM ...... not in the table add the new StateProv here make the codes here break the prog ")
            Exit Sub
        End If

        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        CurrentStateID = r("StateProvID_AutoNumber")
    End Sub
    Private Sub CountryTextBox_TextChanged(sender As Object, e As EventArgs) Handles CountryTextBox.TextChanged
        Dim CurrentCountryName As String = Trim(CountryTextBox.Text)
        If CurrentCountryName = "" Then
            CurrentCountryID = -1
        End If
        RecordFinderDbControls.AddParam("@CurrentCountryName", CurrentCountryName)

        Dim CountrySelectionFilter = "  WHERE trim(CountryName_ShortText25) = @CurrentCountryName "

        MySelection = "Select * FROM CountryTable " & CountrySelectionFilter

        If NoRecordFound() Then
            MsgBox("PROBLEM ...... not in the table add the new country here make the codes here break the prog ")
            Exit Sub
        End If

        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        CurrentCountryID = r("CountryID_AutoNumber")
    End Sub

    Private Sub ZipCodeMaskedTextBox_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles ZipCodeMaskedTextBox.MaskInputRejected
        ZipCodeMaskedTextBox.Text = LTrim(ZipCodeMaskedTextBox.Text)
        ZipCodeMaskedTextBox.Select()
    End Sub

    Private Sub EXITSAVEChangesButton_Click(sender As Object, e As EventArgs) Handles EXITSAVEChangesButton.Click
        If Not AChangeOccured() Then
            If MsgBox("You have no new entries to save, CANCEL Editing ?", MsgBoxStyle.YesNo) = vbYes Then CityDetailsGroupBox.Visible = False
            Exit Sub
        End If

        Dim xxMessage = ""
        If PurposeOfEntry = "ADD" Then
            xxMessage = "Proceed adding this as NEW CUSTOMER?"
        Else
            xxMessage = "Proceed saving CHANGES ?"
        End If
        If MsgBox(xxMessage, MsgBoxStyle.YesNo) = vbNo Then
            CityDetailsGroupBox.Visible = False
            Exit Sub
        End If

        If CityFieldsEntriesAreNotValidAndComplete() Then Exit Sub

        UpdateCitiesTable()
    End Sub
    Private Function CityFieldsEntriesAreNotValidAndComplete()
        If Trim(CountryTextBox.Text) = "" Then
            CountryTextBox.Select()
            Return True
        End If
        If Trim(StateProvTextBox.Text) = "" Then
            StateProvTextBox.Select()
            Return True
        End If
        If Trim(CityTextBox.Text) = "" Then
            CityTextBox.Select()
            Return True
        End If
        If Trim(ZipCodeMaskedTextBox.Text) = "" Then
            ZipCodeMaskedTextBox.Select()
            Return True
        End If

        If Val(ZipCodeMaskedTextBox.Text) < 90000 Or Val(ZipCodeMaskedTextBox.Text) > 99999 Then
            ZipCodeMaskedTextBox.Select()
            Return True
        End If
        Return False
    End Function

    Private Function AChangeOccured()
        If TheseAreNotEqual(CityTextBox.Text, CityDataGridView.Item("LastName_ShortText30", CurrentCityDataGridViewRow).Value, PurposeOfEntry) Then Return True
        If TheseAreNotEqual(StateProvTextBox.Text, CityDataGridView.Item("FirstName_ShortText30", CurrentCityDataGridViewRow).Value, PurposeOfEntry) Then Return True
        If TheseAreNotEqual(ZipCodeMaskedTextBox.Text, CityDataGridView.Item("NamePrefix_ShortText3", CurrentCityDataGridViewRow).Value, PurposeOfEntry) Then Return True
        If TheseAreNotEqual(CountryTextBox.Text, CityDataGridView.Item("NickName_ShortText15", CurrentCityDataGridViewRow).Value, PurposeOfEntry) Then Return True
        Return False
    End Function

    Private Sub UpdateCitiesTable()

        ' If Record is not Found then Insert the record 
        If PurposeOfEntry = "ADD" Then
            SaveNewCity()
        Else
            '        UpdateCurrentOwnerRecord()
        End If
        CityDetailsGroupBox.Visible = False
    End Sub
End Class