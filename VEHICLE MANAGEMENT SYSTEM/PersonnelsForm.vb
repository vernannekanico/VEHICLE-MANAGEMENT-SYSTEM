Public Class PersonnelsForm
    Private CurrentPersonnelID As Integer = -1
    Private CurrentPersonnelRow As Integer = -1
    Private CurrentCityID As Double = 0
    Private CurrentDepartmentID As Double = 0
    Private CurrentJobPositionID As Double = 0

    Private SavedCurrent3rdFileID As Integer = -1 ' use upon update

    Private Current3rdFileID As Integer = -1

    Private PurposeOfEntry = ""

    Private SavedCurrent2ndFileID = -1

    Private PersonnelDataGridViewInitialized = False

    Private PersonnelFieldsToSelect = ""
    Private PersonnelTablesLinks = ""
    Private PersonnelSelectionFilter = ""
    Private PersonnelSelectionFilterSaved = ""
    Private PersonnelSelectionOrder = ""
    Private FieldsValues = ""
    Private FieldsToReplace = ""

    Private SavedLastName = ""
    Private SavedFirstName = ""
    Private SavedNamePrefix = ""
    Private SavedMiddleName = ""
    Private SavedAlias = ""
    Private SavedJobPosition = ""
    Private SavedDepartment = ""
    Private SavedPhoneNumber = ""
    Private SavedEmailAddress = ""
    Private SavedStreet = ""
    Private SavedBldgAptRmNo = ""
    Private SavedCity = ""
    Private SavedStateProv = ""
    Private SavedZipCode = ""
    Private SavedCountry = ""
    Private CodeRequested = ""

    Private SavedMeWidth = 0
    Private MeLocationX As Integer
    Private MeLocationY As Integer
    Private SavedCallingForm As Form


    Private Sub PersonnelForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SavedCallingForm = CallingForm
        SelectToolStripMenuItem.Visible = True
        SaveToolStripMenuItem.Visible = False
        AddToolStripMenuItem.Visible = False
        EditToolStripMenuItem.Visible = False
        ViewToolStripMenuItem.Visible = False
        DeleteToolStripMenuItem.Visible = False
        SearchToolStrip.Enabled = False
        Select Case CurrentUserGroup
            Case "Assistant Service Manager"
                PersonnelSelectionFilter = "   WHERE JobPositionName_ShortText40 = " & InQuotes("Lead Service Specialist")
            Case "Lead Service Specialist"
                PersonnelSelectionFilter = "   WHERE JobPositionName_ShortText40 = " & InQuotes("Lead Service Specialist") &
                                            "   OR JobPositionName_ShortText40 = " & InQuotes("Automotive Service Specialist")
            Case "Systems Manager"
                PersonnelSelectionFilter = "   WHERE SystemAccessLevel_ShortText2 = " & Chr(34) & "1A" & Chr(34)
                EnAbleAccess(SelectToolStripMenuItem)
                SetThisMenuVisible(SelectToolStripMenuItem)
                SaveToolStripMenuItem.Visible = True
                AddToolStripMenuItem.Visible = True
                EditToolStripMenuItem.Visible = True
                ViewToolStripMenuItem.Visible = True
                DeleteToolStripMenuItem.Visible = True
                SearchToolStrip.Enabled = True
            Case "Customer Relations Specialist"
                PersonnelSelectionFilter = "   WHERE JobPositionName_ShortText40 = " & InQuotes("Assistant Service Manager")
                EnAbleAccess(SelectToolStripMenuItem)
                SetThisMenuVisible(SelectToolStripMenuItem)
            Case "Store Keeper"
                PersonnelSelectionFilter = "   WHERE JobPositionName_ShortText40 = " & InQuotes("Lead Service Specialist") &
                                            "   OR JobPositionName_ShortText40 = " & InQuotes("Automotive Service Specialist")
            Case "Procurement Manager"
                PersonnelSelectionFilter = "   WHERE JobPositionName_ShortText40 = " & InQuotes("Purchaser")
            Case Else
                MsgBox("BREAK,  UNKOWN CALLING FORM")
        End Select


        FillPersonnelDataGridView()
        'SET AND RESET ALL ENTRY PARAMETERS
    End Sub
    Private Sub FillPersonnelDataGridView()
        PersonnelFieldsToSelect = "Select " &
                      " PersonnelTable.PersonnelID_AutoNumber, " &
                      " PersonnelTable.FirstName_ShortText30, " &
                      " PersonnelTable.LastName_ShortText30, " &
                      " PersonnelTable.NamePrefix_ShortText3, " &
                      " PersonnelTable.MidleName_ShortText15, " &
                      " PersonnelTable.NickName_ShortText15, " &
                      " PersonnelTable.TelNo_ShortText10, " &
                      " PersonnelTable.EmailAddress_ShortText20, " &
                      " PersonnelTable.Street_ShortText25, " &
                      " PersonnelTable.BldgAptRmNo_ShortText25, " &
                      " PersonnelTable.CityID_LongInteger, " &
                      " PersonnelTable.JobPositionID_LongInteger, " &
                      " PersonnelTable.DepartmentID_LongInteger, " &
                      " DepartmentsTable.DepartmentName_ShortText35, " &
                      " JobPositionsTable.JobPositionName_ShortText40, " &
                      " JobPositionsTable.SystemAccessLevel_ShortText2, " &
                      " CityTable.CityName_ShortText25, " &
                      " CityTable.ZipCode_ShortText9, " &
                      " StateProvTable.StateCode_ShortText2, " &
                      " CountryTable.CountryName_ShortText25, " &
                      " StateProvTable.StateProvName_ShortText25 "

        PersonnelTablesLinks = " FROM((((PersonnelTable LEFT JOIN CityTable ON PersonnelTable.CityID_LongInteger = CityTable.CityID_AutoNumber) " &
                                                      " LEFT JOIN DepartmentsTable On PersonnelTable.DepartmentID_LongInteger = DepartmentsTable.DepartmentID_AutoNumber) " &
                                                      " LEFT JOIN JobPositionsTable On PersonnelTable.JobPositionID_LongInteger = JobPositionsTable.JobPositionID_AutoNumber) " &
                                                      " LEFT JOIN StateProvTable On CityTable.StateProvID_LongInteger = StateProvTable.StateProvID_AutoNumber) " &
                                                      " LEFT JOIN CountryTable On StateProvTable.CountryID_LongInteger = CountryTable.CountryID_Autonumber "

        PersonnelSelectionOrder = " ORDER BY SystemAccessLevel_ShortText2, FirstName_ShortText30 "

        MySelection = PersonnelFieldsToSelect & PersonnelTablesLinks & PersonnelSelectionFilter & PersonnelSelectionOrder

        JustExecuteMySelection()
        PersonnelDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        PersonnelDataGridView.Columns.Item("PersonnelID_AutoNumber").Visible = False
        PersonnelDataGridView.Columns.Item("CityID_LongInteger").Visible = False
        PersonnelDataGridView.Columns.Item("JobPositionID_LongInteger").Visible = False
        PersonnelDataGridView.Columns.Item("DepartmentID_LongInteger").Visible = False
        PersonnelDataGridView.Columns.Item("EmailAddress_ShortText20").Visible = False
        PersonnelDataGridView.Columns.Item("TelNo_ShortText10").Visible = False
        PersonnelDataGridView.Columns.Item("Street_ShortText25").Visible = False
        PersonnelDataGridView.Columns.Item("BldgAptRmNo_ShortText25").Visible = False
        PersonnelDataGridView.Columns.Item("StateProvName_ShortText25").Visible = False
        PersonnelDataGridView.Columns.Item("CityName_ShortText25").Visible = False
        PersonnelDataGridView.Columns.Item("ZipCode_ShortText9").Visible = False
        PersonnelDataGridView.Columns.Item("StateCode_ShortText2").Visible = False
        PersonnelDataGridView.Columns.Item("CountryName_ShortText25").Visible = False
        PersonnelDataGridView.Columns.Item("NickName_ShortText15").Visible = False
        PersonnelDataGridView.Columns.Item("SystemAccessLevel_ShortText2").Visible = False

        PersonnelDataGridView.Columns.Item("LastName_ShortText30").HeaderText = "Last Name"
        PersonnelDataGridView.Columns.Item("LastName_ShortText30").Width = 15 * 184 / 15

        PersonnelDataGridView.Columns.Item("FirstName_ShortText30").HeaderText = "First Name"
        PersonnelDataGridView.Columns.Item("FirstName_ShortText30").Width = 15 * 184 / 15

        PersonnelDataGridView.Columns.Item("MidleName_ShortText15").HeaderText = "MidleName"
        PersonnelDataGridView.Columns.Item("MidleName_ShortText15").Width = 15 * 184 / 15

        PersonnelDataGridView.Columns.Item("NamePrefix_ShortText3").HeaderText = ""
        PersonnelDataGridView.Columns.Item("NamePrefix_ShortText3").Width = 3 * 184 / 15

        PersonnelDataGridView.Columns.Item("JobPositionName_ShortText40").HeaderText = "Position"
        PersonnelDataGridView.Columns.Item("JobPositionName_ShortText40").Width = 40 * 184 / 15

        PersonnelDataGridView.Columns.Item("DepartmentName_ShortText35").HeaderText = "Department"
        PersonnelDataGridView.Columns.Item("DepartmentName_ShortText35").Width = 35 * 184 / 15

        PersonnelDataGridView.Width = 0
        For i = 0 To PersonnelDataGridView.Columns.GetColumnCount(0) - 1
            If PersonnelDataGridView.Columns.Item(i).Visible = True Then
                PersonnelDataGridView.Width = PersonnelDataGridView.Width + PersonnelDataGridView.Columns.Item(i).Width
            End If
        Next
        PersonnelDataGridView.Width = PersonnelDataGridView.Width + 3

        Me.Width = PersonnelDataGridView.Width + 50
        SavedMeWidth = Me.Width
        MeLocationX = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
        If MeLocationX < 0 Then MeLocationX = 0
        Me.Location = New Point(MeLocationX, MeLocationY)

    End Sub


    Private Sub PersonnelDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles PersonnelDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If RecordCount = 0 Then Exit Sub
        If Not PersonnelDataGridViewInitialized Then
            PersonnelDataGridViewInitialized = True
        End If

        CurrentPersonnelRow = e.RowIndex

        CurrentPersonnelID = PersonnelDataGridView.Item("PersonnelID_AutoNumber", CurrentPersonnelRow).Value
        CurrentCityID = PersonnelDataGridView.Item("CityID_LongInteger", CurrentPersonnelRow).Value
        CurrentDepartmentID = PersonnelDataGridView.Item("DepartmentID_LongInteger", CurrentPersonnelRow).Value
        CurrentJobPositionID = PersonnelDataGridView.Item("JobPositionID_LongInteger", CurrentPersonnelRow).Value
        If DetailsGroupBox.Enabled = False Then
            If SaveToolStripMenuItem.Visible = False Then
                ShowDetailsGroupBox()
            End If
        End If
    End Sub
    Private Sub PersonnelDataGridView_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles PersonnelDataGridView.DataBindingComplete
        Dim NoOfHeaderLines = 1
        Dim RecordsDisplyed = RecordCount
        Dim FormLowPointFromGrid = 90
        MeLocationY = Me.Location.Y
        If RecordCount > 27 Then
            MeLocationY = 50
            RecordsDisplyed = 22
        Else
            RecordsDisplyed = RecordCount + 1
        End If
        PersonnelDataGridView.Height = (PersonnelDataGridView.ColumnHeadersHeight * NoOfHeaderLines) + (DataGridViewRowHeight * RecordsDisplyed) + DataGridViewRowHeight
        Me.Height = PersonnelDataGridView.Height + FormLowPointFromGrid + 110
        If Me.Height < 581 Then Me.Height = 700

    End Sub
    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        Select Case DetailsGroupBox.Visible
            Case True
                Dim FieldChangeOccured = False

                If SavedLastName <> LastNameTextBox.Text Then FieldChangeOccured = True
                If SavedFirstName <> FirstNameTextBox.Text Then FieldChangeOccured = True
                If SavedNamePrefix <> NamePrefixTextBox.Text Then FieldChangeOccured = True
                If SavedMiddleName <> MiddleNameTextBox.Text Then FieldChangeOccured = True
                If SavedAlias <> AliasTextBox.Text Then FieldChangeOccured = True
                If SavedJobPosition <> JobPositionTextBox.Text Then FieldChangeOccured = True
                If SavedDepartment <> DepartmentTextBox.Text Then FieldChangeOccured = True
                If SavedPhoneNumber <> PhoneNumberTextBox.Text Then FieldChangeOccured = True
                If SavedEmailAddress <> EmailAddressTextBox.Text Then FieldChangeOccured = True
                If SavedStreet <> StreetTextBox.Text Then FieldChangeOccured = True
                If SavedBldgAptRmNo <> BldgAptRmNoTextBox.Text Then FieldChangeOccured = True
                If SavedCity <> CityTextBox.Text Then FieldChangeOccured = True
                If SavedStateProv <> StateProvTextBox.Text Then FieldChangeOccured = True
                If SavedZipCode <> ZipCodeTextBox.Text Then FieldChangeOccured = True
                If SavedCountry <> CountryTextBox.Text Then FieldChangeOccured = True
                If FieldChangeOccured Then
                    If Not MsgBox("Do you want to discard changes ?", vbYesNo) = vbYes Then
                        Exit Sub
                    End If
                End If
                PersonnelDataGridView.Enabled = True
                DisableModifyMode()
            Case Else
                DoCommonHouseKeeping(Me, SavedCallingForm)
        End Select
    End Sub
    Private Sub PersonnelForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        If Me.Enabled = False Then Exit Sub
        CallingForm = SavedCallingForm

        Select Case Tunnel1
            Case = "Tunnel2IsJobPositionID"
                CurrentJobPositionID = Tunnel2
                JobPositionTextBox.Text = Tunnel3
            Case = "Tunnel2IsCityID"
                CurrentCityID = Tunnel2
            Case = "Tunnel2IsDepartmentID"
                Tunnel2 = CurrentDepartmentID
                DepartmentTextBox.Text = Tunnel3
        End Select

    End Sub
    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        PurposeOfEntry = "ADD"
        ' Shows the details editing group box and enables edit to the fields
        ' All DataGridViews are disabled
        ' Searching is disable
        CurrentPersonnelID = -1
        DetailsGroupBox.Text = "Add a new EMPLOYEE"
        EnableModifyMode()          '' Add Edit Delete are turned off and Cancel ans Save options are made available
    End Sub
    Private Sub ShowDetailsGroupBox()
        DetailsGroupBox.Visible = True
        If Not DetailsGroupBox.Text = "" Then
            PersonnelDataGridView.Enabled = False
        End If


        If CurrentPersonnelID = -1 Then
            FirstNameTextBox.Text = ""
            LastNameTextBox.Text = ""
            NamePrefixTextBox.Text = ""
            MiddleNameTextBox.Text = ""
            AliasTextBox.Text = ""
            JobPositionTextBox.Text = ""
            PhoneNumberTextBox.Text = ""
            EmailAddressTextBox.Text = ""
            StreetTextBox.Text = ""
            BldgAptRmNoTextBox.Text = ""
            CityTextBox.Text = ""
            StateProvTextBox.Text = ""
            ZipCodeTextBox.Text = ""
            CountryTextBox.Text = ""

            CurrentCityID = -1
            CurrentDepartmentID = -1
            CurrentJobPositionID = -1

        Else
            LastNameTextBox.Text = PersonnelDataGridView.Item("LastName_ShortText30", CurrentPersonnelRow).Value
            FirstNameTextBox.Text = PersonnelDataGridView.Item("FirstName_ShortText30", CurrentPersonnelRow).Value
            NamePrefixTextBox.Text = PersonnelDataGridView.Item("NamePrefix_ShortText3", CurrentPersonnelRow).Value
            MiddleNameTextBox.Text = PersonnelDataGridView.Item("MidleName_ShortText15", CurrentPersonnelRow).Value
            AliasTextBox.Text = PersonnelDataGridView.Item("NickName_ShortText15", CurrentPersonnelRow).Value
            JobPositionTextBox.Text = IIf(IsDBNull(PersonnelDataGridView.Item("JobPositionName_ShortText40", CurrentPersonnelRow).Value), "", PersonnelDataGridView.Item("JobPositionName_ShortText40", CurrentPersonnelRow).Value)
            DepartmentTextBox.Text = IIf(IsDBNull(PersonnelDataGridView.Item("DepartmentName_ShortText35", CurrentPersonnelRow).Value), "", PersonnelDataGridView.Item("DepartmentName_ShortText35", CurrentPersonnelRow).Value)
            PhoneNumberTextBox.Text = PersonnelDataGridView.Item("TelNo_ShortText10", CurrentPersonnelRow).Value
            EmailAddressTextBox.Text = If(IsDBNull(PersonnelDataGridView.Item("EmailAddress_ShortText20", CurrentPersonnelRow).Value), "", PersonnelDataGridView.Item("EmailAddress_ShortText20", CurrentPersonnelRow).Value)
            StreetTextBox.Text = If(IsDBNull(PersonnelDataGridView.Item("Street_ShortText25", CurrentPersonnelRow).Value), "", PersonnelDataGridView.Item("Street_ShortText25", CurrentPersonnelRow).Value)
            BldgAptRmNoTextBox.Text = If(IsDBNull(PersonnelDataGridView.Item("BldgAptRmNo_ShortText25", CurrentPersonnelRow).Value), "", PersonnelDataGridView.Item("BldgAptRmNo_ShortText25", CurrentPersonnelRow).Value)
            CityTextBox.Text = If(IsDBNull(PersonnelDataGridView.Item("CityName_ShortText25", CurrentPersonnelRow).Value), "", PersonnelDataGridView.Item("CityName_ShortText25", CurrentPersonnelRow).Value)
            StateProvTextBox.Text = If(IsDBNull(PersonnelDataGridView.Item("StateCode_ShortText2", CurrentPersonnelRow).Value), "", PersonnelDataGridView.Item("StateCode_ShortText2", CurrentPersonnelRow).Value)
            ZipCodeTextBox.Text = If(IsDBNull(PersonnelDataGridView.Item("ZipCode_ShortText9", CurrentPersonnelRow).Value), "", PersonnelDataGridView.Item("ZipCode_ShortText9", CurrentPersonnelRow).Value)
            CountryTextBox.Text = If(IsDBNull(PersonnelDataGridView.Item("CountryName_ShortText25", CurrentPersonnelRow).Value), "", PersonnelDataGridView.Item("CountryName_ShortText25", CurrentPersonnelRow).Value)

        End If
        SavedLastName = LastNameTextBox.Text
        SavedFirstName = FirstNameTextBox.Text
        SavedNamePrefix = NamePrefixTextBox.Text
        SavedMiddleName = MiddleNameTextBox.Text
        SavedAlias = AliasTextBox.Text
        SavedJobPosition = JobPositionTextBox.Text
        SavedDepartment = DepartmentTextBox.Text
        SavedPhoneNumber = PhoneNumberTextBox.Text
        SavedEmailAddress = EmailAddressTextBox.Text
        SavedStreet = StreetTextBox.Text
        SavedBldgAptRmNo = BldgAptRmNoTextBox.Text
        SavedCity = CityTextBox.Text
        SavedStateProv = StateProvTextBox.Text
        SavedZipCode = ZipCodeTextBox.Text
        SavedCountry = CountryTextBox.Text
    End Sub

    Private Sub DepartmentTextBox_TextChanged(sender As Object, e As EventArgs) Handles DepartmentTextBox.Click
        If DepartmentTextBox.Text = "" Then
            ShowDepartmentsForm()
        Else
            If Me.Enabled = True Then
                If MsgBox("Do you intend to change the department ?", vbYesNo) = vbYes Then
                    DepartmentTextBox.Text = ""
                    ShowDepartmentsForm()
                End If
            End If
        End If
    End Sub
    Private Sub CityTextBox_TextChanged(sender As Object, e As EventArgs) Handles CityTextBox.Click
        If CityTextBox.Text = "" Then
            ShowCityForm()
        Else
            If Me.Enabled = True Then
                If MsgBox("Do you intend to change the department ?", vbYesNo) = vbYes Then
                    DepartmentTextBox.Text = ""
                    ShowCityForm()
                End If
            End If
        End If
    End Sub
    Private Sub JobPositionTextBox_TextChanged(sender As Object, e As EventArgs) Handles JobPositionTextBox.Click
        If JobPositionTextBox.Text = "" Then
            ShowJobPositionsForm()
        Else
            If Me.Enabled = True Then
                If MsgBox("Do you intend to change the Job Function of this Employee ?", vbYesNo) = vbYes Then
                    JobPositionTextBox.Text = ""
                    ShowJobPositionsForm()
                End If
            End If
        End If
    End Sub
    Private Sub ShowDepartmentsForm()
        ShowCalledForm(Me, DepartmentsForm)
    End Sub

    Private Sub ShowJobPositionsForm()
        If IsEmpty(DepartmentTextBox.Text) Then DepartmentTextBox.Select()
        Tunnel1 = CurrentDepartmentID
        ShowCalledForm(Me, JobPositionsForm)
    End Sub

    Private Sub ShowCityForm()
        ShowCalledForm(Me, CityForm)
        CityForm.SearchCityTextBox.Select()
    End Sub

    Private Sub SearchPersonnelTextBox_TClick(sender As Object, e As EventArgs) Handles SearchPersonnelTextBox.Click
        If SearchPersonnelTextBox.Text = "Search" Then
            SearchPersonnelTextBox.Text = ""
            Exit Sub
        End If
    End Sub
    Private Sub SearchPersonnelTextBox_TextChanged(sender As Object, e As EventArgs) Handles SearchPersonnelTextBox.TextChanged
        If SearchPersonnelTextBox.Text = "Search" Then Exit Sub
        If SearchPersonnelTextBox.Text = "" Then
            PersonnelSelectionFilter = ""
            FillPersonnelDataGridView()

            Exit Sub
        End If

        Dim FindKey As String = Trim(SearchPersonnelTextBox.Text)

        RecordFinderDbControls.AddParam("@FindKey", "%" & FindKey & "%")
        PersonnelSelectionFilter = " WHERE Personnel_ShortText150 Like @FindKey  "

        FillPersonnelDataGridView()
        Dim yyy = RecordCount
    End Sub
    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        PurposeOfEntry = "EDIT"

        'Check if there are links to the Table
        'if there exists then ask if real change action

        '       MySelection = "Select * from PersonnelTable " &
        '                     "Where PersonnelID_AutoNumber = " & Str(CurrentPersonnelID)
        '       If RecordIsFound() Then

        ' at this point EDIT FEATURE IS JUST ALLOWED
        If Not MsgBox("This Personnel is currently LINKED to other Files, do you really want to change informations for this personnel ?", vbYesNo) = vbYes Then
            Exit Sub
        End If
        '       End If

        'setting the form enabled status will trigger PersonnelForm_EnabledChanged
        DetailsGroupBox.Text = "EDIT EMPLOYEE"
        EnableModifyMode()
    End Sub
    Private Sub EmployeeDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmployeeDetailsToolStripMenuItem.Click
        PurposeOfEntry = "VIEW"
        DetailsGroupBox.Text = ""
        DetailsGroupBox.Enabled = False
        EnableModifyMode()
        SaveToolStripMenuItem.Visible = False
    End Sub

    Private Sub SaveCurrentFieldContents()
        Select Case PurposeOfEntry
            Case "ADD"
                If ThisPersonnelAlreadyExist() Then
                    MsgBox("This record already exists")
                    Exit Sub
                End If

                Dim FullName = Trim(LastNameTextBox.Text) & " " & Trim(FirstNameTextBox.Text) & " " & IIf(NotEmpty(NamePrefixTextBox.Text), Trim(NamePrefixTextBox.Text) & " ", "") & MiddleNameTextBox.Text
                If Not MsgBox(" Confirm adding new EMPLOYEE " & FullName, vbYesNo) = vbYes Then
                    Exit Sub
                End If

                If Not SuccessfullyAddingThisPersonnelRecord() Then
                    Exit Sub
                End If
                CreateLoginInformations()

            Case "EDIT"
                Dim FullName = Trim(LastNameTextBox.Text) & " " & Trim(FirstNameTextBox.Text) & " " & IIf(NotEmpty(NamePrefixTextBox.Text), Trim(NamePrefixTextBox.Text) & " ", "") & MiddleNameTextBox.Text
                If Not MsgBox(" Confirm Saving changes for EMPLOYEE " & FullName, vbYesNo) = vbYes Then
                    Exit Sub
                End If
                CreateLoginInformations()

                Dim PersonnelFilter = " WHERE PersonnelID_AutoNumber = " & Str(CurrentPersonnelID)
                Dim MyNull = Chr(34) & Chr(34)
                Dim yyyyy = ""

                PersonnelFieldsToSelect = " UPDATE PersonnelTable  SET " &
                    " LastName_ShortText30 = " & Chr(34) & LastNameTextBox.Text & Chr(34) & ", " &
                                                      " FirstName_ShortText30  = " & Chr(34) & FirstNameTextBox.Text & Chr(34) & ", " &
                                                       " CityID_LongInteger  = " & Chr(34) & Str(CurrentCityID) & Chr(34) & ", " &
                                                      " DepartmentID_LongInteger  = " & Chr(34) & Str(CurrentDepartmentID) & Chr(34) & ", " &
                                                       " JobPositionID_LongInteger  = " & Chr(34) & Str(CurrentJobPositionID) & Chr(34) & ", " &
                IIf(NotEmpty(StreetTextBox.Text), " Street_ShortText25  = " & Chr(34) & StreetTextBox.Text & Chr(34), " Street_ShortText25 = " & MyNull) & ", " &
                IIf(NotEmpty(MiddleNameTextBox.Text), " MidleName_ShortText15  = " & Chr(34) & MiddleNameTextBox.Text & Chr(34), " MidleName_ShortText15 = " & MyNull) & ", " &
                 IIf(NotEmpty(BldgAptRmNoTextBox.Text), " BldgAptRmNo_ShortText25  = " & Chr(34) & BldgAptRmNoTextBox.Text & Chr(34), " BldgAptRmNo_ShortText25 = " & MyNull) & ", " &
               IIf(NotEmpty(EmailAddressTextBox.Text), " EmailAddress_ShortText20  = " & Chr(34) & EmailAddressTextBox.Text & Chr(34), " EmailAddress_ShortText20 = " & MyNull) & ", " &
                IIf(NotEmpty(NamePrefixTextBox.Text), " NamePrefix_ShortText3  = " & Chr(34) & NamePrefixTextBox.Text & Chr(34), " NamePrefix_ShortText3  = " & MyNull) & ", " &
                IIf(NotEmpty(AliasTextBox.Text), " NickName_ShortText15  = " & Chr(34) & AliasTextBox.Text & Chr(34), " NickName_ShortText15 = " & MyNull) & ", " &
                " TelNo_ShortText10 = " & Chr(34) & PhoneNumberTextBox.Text & Chr(34)



                MySelection = PersonnelFieldsToSelect & PersonnelFilter

                If NoRecordFound() Then Dim dummy = 1
            Case Else
                Dim XXXX = 1
        End Select
        DisableModifyMode()
        FillPersonnelDataGridView()

    End Sub
    Private Sub SelectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectToolStripMenuItem.Click
        Tunnel1 = "Tunnel2IsPersonnelID"
        Tunnel2 = CurrentPersonnelID
        Select Case SavedCallingForm.Name
            Case "WorkOrderPartsRequisitionsForm"
                Dim xxFirstName = PersonnelDataGridView.Item("FirstName_ShortText30", CurrentPersonnelRow).Value
                Dim xxLastName = PersonnelDataGridView.Item("LastName_ShortText30", CurrentPersonnelRow).Value
                Dim xxReceivedBy = xxLastName & Space(1) & xxFirstName

                WorkOrderPartsRequisitionsForm.ReceivedByTextBox.Text = xxReceivedBy
        End Select
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub
    Private Sub PersonnelDataGridView_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles PersonnelDataGridView.RowHeaderMouseDoubleClick 'Select Row
        Tunnel1 = CurrentPersonnelID
        Tunnel2 = "Tunnel1IsPersonnelCode"
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub
    Private Sub EnableAddEditDeleteMenuItems()
        SelectToolStripMenuItem.Visible = True
        SaveToolStripMenuItem.Visible = False
        AddToolStripMenuItem.Visible = True
        EditToolStripMenuItem.Visible = True
        ViewToolStripMenuItem.Visible = True
        DeleteToolStripMenuItem.Visible = True
        SearchToolStrip.Enabled = True

    End Sub
    Private Sub DisableAddEditDeleteMenuItems()
        SelectToolStripMenuItem.Visible = False
        SaveToolStripMenuItem.Visible = True
        AddToolStripMenuItem.Visible = False
        EditToolStripMenuItem.Visible = False
        ViewToolStripMenuItem.Visible = False
        DeleteToolStripMenuItem.Visible = False
        SearchToolStrip.Enabled = False

    End Sub
    Private Sub DisableModifyMode()
        EnableAddEditDeleteMenuItems()
        DetailsGroupBox.Visible = False
        Me.Width = SavedMeWidth
        PersonnelDataGridView.Enabled = True
    End Sub
    Private Sub EnableModifyMode()      ' Add Edit Delete are turned off and Cancel ans Save options are made available
        DisableAddEditDeleteMenuItems()
        ShowDetailsGroupBox()

        'Save Original data

    End Sub
    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        ' HERE DETERMINE FIRST ALL RELATIONS
        DetailsGroupBox.Text = "Delete a TYPE Personnel"
        DetailsGroupBox.Text = "DELETE EMPLOYEE"
        EnableModifyMode()
        If Not MsgBox("Do you want to continue deleting this EMPLOYEE ?", vbYesNo) = vbYes Then
        Else
            MySelection = "DELETE FROM PersonnelTable WHERE PersonnelID_AutoNumber = " & Str(CurrentPersonnelID)
            JustExecuteMySelection()
            FillPersonnelDataGridView()
        End If
        DisableModifyMode()
    End Sub
    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        If PersonnelFieldsEntriesAreNotValidAndComplete() Then Exit Sub
        SaveCurrentFieldContents()
    End Sub
    Private Function PersonnelFieldsEntriesAreNotValidAndComplete()
        If Trim(LastNameTextBox.Text) = "" Then LastNameTextBox.Select() : Return True
        If Trim(FirstNameTextBox.Text) = "" Then FirstNameTextBox.Select() : Return True
        If Trim(PhoneNumberTextBox.Text) = "" Then PhoneNumberTextBox.Select() : Return True
        If Trim(DepartmentTextBox.Text) = "" Then DepartmentTextBox.Select() : Return True
        If Trim(JobPositionTextBox.Text) = "" Then JobPositionTextBox.Select() : Return True
        Return False
    End Function
    Private Sub LastNameTextBox_TextChanged(sender As Object, e As EventArgs) Handles LastNameTextBox.TextChanged
        If Len(Trim(LastNameTextBox.Text)) > 15 Then
            LastNameTextBox.Text = LastNameTextBox.Text.Substring(0, 15)
        End If
    End Sub
    Private Sub FirstNameTextBox_TextChanged(sender As Object, e As EventArgs) Handles FirstNameTextBox.TextChanged
        If Len(Trim(FirstNameTextBox.Text)) > 15 Then
            FirstNameTextBox.Text = FirstNameTextBox.Text.Substring(0, 15)
        End If
    End Sub

    Private Sub NamePrefixTextBox_TextChanged(sender As Object, e As EventArgs) Handles NamePrefixTextBox.TextChanged
        If Len(Trim(NamePrefixTextBox.Text)) > 3 Then
            NamePrefixTextBox.Text = NamePrefixTextBox.Text.Substring(0, 3)
        End If

    End Sub

    Private Sub MiddleNameTextBox_TextChanged(sender As Object, e As EventArgs) Handles MiddleNameTextBox.TextChanged
        If Len(Trim(MiddleNameTextBox.Text)) > 15 Then
            MiddleNameTextBox.Text = MiddleNameTextBox.Text.Substring(0, 15)
        End If

    End Sub
    Private Sub AliasTextBox_TextChanged(sender As Object, e As EventArgs) Handles AliasTextBox.TextChanged
        '        "NickName_ShortText15, " &
        If Len(Trim(AliasTextBox.Text)) > 20 Then
            AliasTextBox.Text = AliasTextBox.Text.Substring(0, 20)
        End If
    End Sub
    Private Sub PhoneNumberTextBox_TextChanged(sender As Object, e As EventArgs) Handles PhoneNumberTextBox.TextChanged
        If Len(Trim(PhoneNumberTextBox.Text)) > 10 Then
            PhoneNumberTextBox.Text = PhoneNumberTextBox.Text.Substring(0, 10)
        End If
    End Sub
    Private Sub EmailAddressTextBox_TextChanged(sender As Object, e As EventArgs) Handles EmailAddressTextBox.TextChanged
        If Len(Trim(EmailAddressTextBox.Text)) > 20 Then
            EmailAddressTextBox.Text = EmailAddressTextBox.Text.Substring(0, 20)
        End If
    End Sub
    Private Sub StreetTextBox_TextChanged(sender As Object, e As EventArgs) Handles StreetTextBox.TextChanged
        If Len(Trim(StreetTextBox.Text)) > 25 Then
            StreetTextBox.Text = StreetTextBox.Text.Substring(0, 25)
        End If
    End Sub
    Private Sub BldgAptRmNoTextBox_TextChanged(sender As Object, e As EventArgs) Handles BldgAptRmNoTextBox.TextChanged
        If Len(Trim(BldgAptRmNoTextBox.Text)) > 25 Then
            BldgAptRmNoTextBox.Text = BldgAptRmNoTextBox.Text.Substring(0, 25)
        End If
    End Sub
    Private Function ThisPersonnelAlreadyExist()
        MySelection = "SELECT * FROM PersonnelTable " &
            " WHERE trim(LastName_ShortText30) = " & Chr(34) & Trim(LastNameTextBox.Text) & Chr(34) &
            " And trim(FirstName_ShortText30) = " & Chr(34) & Trim(FirstNameTextBox.Text) & Chr(34) &
            " AND trim(NamePrefix_ShortText3) = " & Chr(34) & Trim(NamePrefixTextBox.Text) & Chr(34)

        If ThereIsARecord() Then
            Return True
        End If

        Return False
    End Function
    Private Function ThisUserAlreadyExist()
        MySelection = "SELECT * FROM UsersTable " &
            " WHERE trim(UserName_ShortText50) = " & Chr(34) & Trim(CurrentUserName) & Chr(34) &
                    " OR PersonelID_LongInteger = " & Str(CurrentPersonnelID)                                   'password mayhave already been updated

        If ThereIsARecord() Then
            Return True
        End If

        Return False

    End Function
    Private Function SuccessfullyAddingThisPersonnelRecord()

        ' EXECUTE INSERT COMMAND

        FieldsToReplace = "" &
            "LastName_ShortText30, " &
            "FirstName_ShortText30, " &
            "NamePrefix_ShortText3, " &
            "MidleName_ShortText15, " &
            "NickName_ShortText15, " &
            "TelNo_ShortText10, " &
             "EmailAddress_ShortText20, " &
            "Street_ShortText25, " &
            "BldgAptRmNo_ShortText25, " &
            "CityID_LongInteger, " &
            "DepartmentID_LongInteger, " &
            "JobPositionID_LongInteger"

        FieldsValues = "" &
            Chr(34) & Trim(LastNameTextBox.Text) & Chr(34) & ", " &
            Chr(34) & Trim(FirstNameTextBox.Text) & Chr(34) & ", " &
            Chr(34) & Trim(NamePrefixTextBox.Text) & Chr(34) & ", " &
            Chr(34) & Trim(MiddleNameTextBox.Text) & Chr(34) & ", " &
            Chr(34) & Trim(AliasTextBox.Text) & Chr(34) & ", " &
            Chr(34) & Trim(PhoneNumberTextBox.Text) & Chr(34) & ", " &
            Chr(34) & Trim(EmailAddressTextBox.Text) & Chr(34) & ", " &
            Chr(34) & Trim(StreetTextBox.Text) & Chr(34) & ", " &
            Chr(34) & Trim(BldgAptRmNoTextBox.Text) & Chr(34) & ", " &
            Str(CurrentCityID) & ",  " &
            Str(CurrentDepartmentID) & ",  " &
            Str(CurrentJobPositionID)

        MySelection = "INSERT INTO PersonnelTable  (" & FieldsToReplace & ") VALUES (" & FieldsValues & ")"

        JustExecuteMySelection()

        If ThisPersonnelAlreadyExist() Then
            r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
            CurrentPersonnelID = r("PersonnelID_AutoNumber")
        Else
            MsgBox("PROBLEM ...... unseccessful save ")
            Return False
        End If
        Return True
    End Function
    Private Function CreateLoginInformations()
        Dim LastNameLength = Len(Trim(LastNameTextBox.Text))
        Dim LastNameFirstCharacter = Mid(LastNameTextBox.Text, 1, 1)
        Dim LastNameLastCharacter = Mid(LastNameTextBox.Text, LastNameLength, 1)
        Dim MyNull = Chr(34) & Chr(34)
        Dim NowInString = Convert.ToDateTime(Now())
        Dim xcd = NowInString.ToString
        CurrentUserName = UCase(Trim(FirstNameTextBox.Text) & LastNameFirstCharacter & LastNameLastCharacter)

        ' Verify if username already exist

        If ThisUserAlreadyExist() Then
            Return False
        End If


        ' create the user record
        FieldsToReplace = "" &
            "UserName_ShortText50, " &
            "TemporaryPasswordFor30MinutesInteger, " &
             "PersonelID_LongInteger, " &
             "LoginStatusByte, " &
              "LoginNoOfAttemptsInteger, " &
                    "LoginDateTime "

        FieldsValues = "" &
            Chr(34) & Trim(CurrentUserName) & Chr(34) & ", " &
            Str(0) & ", " &
            Str(CurrentPersonnelID) & ", " &
        Str(-1) & ",  " &
            Str(0) & ",  " &
              Chr(34) & NowInString & Chr(34)

        '          "Password_ShortText25, " &
        '     Chr(34) & MyNull & Chr(34) & ", " &


        MySelection = "INSERT INTO UsersTable  (" & FieldsToReplace & ") VALUES (" & FieldsValues & ")"

        JustExecuteMySelection()


        ' was it saved ?

        If Not ThisUserAlreadyExist() Then
            MsgBox("unable to add the user ")
            Return False
        End If
        MsgBox("take note: temporary user name assigned to this employee is " & CurrentUserName)

        Return True

    End Function

End Class