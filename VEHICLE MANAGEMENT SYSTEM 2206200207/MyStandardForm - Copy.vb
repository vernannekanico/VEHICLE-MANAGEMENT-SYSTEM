Public Class MyStandardForm
    Private CurrentMyStandardID As Integer = -1
    Private CurrentMyStandardRow As Integer = -1
    Private CurrentLinkedID As Double = 0

    Private PurposeOfMyStandardDetailsGroupBoxEntry = ""
    Private CodeRequested = ""

    Private MyStandardDataGridViewInitialized = False

    Private MyStandardsFieldsToSelect = ""
    Private MyStandardsTablesLinks = ""
    Private MyStandardsSelectionFilter = ""
    Private MyStandardsSelectionFilterSaved = ""
    Private MyStandardsSelectionOrder = ""

    Private MyStandardFieldsValues = ""
    Private MyStandardFieldsToReplace = ""

    Private SavedMyStandardName = ""
    Private SavedMyStandardDate = ""
    Private SavedStateProv = ""
    Private SavedZipCode = ""
    Private SavedCountry = ""

    Private SavedMeWidth = 0
    Private MeLocationX As Integer
    Private MeLocationY As Integer


    Private Sub MyStandardForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' form returns       Tunnel1 = CurrentVehicleModelRelationsID
        '                    Tunnel2 = 

        ' form recieves on enabled  ' CurrentVehicleTypeID 
        '                           ' note: trim belongs to a model
        '                           '       model belongs to a type
        ' if empty, it has been opened not to return a code

        ' ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        ' enable all menus needded on first show
        EnableAddEditDeleteMyStandardMenuItems()
        ' check these if needed
        'GET ALL ENTRY PARAMETERS

        MyStandardsSelectionFilter = ""

        FillMyStandardDataGridView()
        'SET AND RESET ALL ENTRY PARAMETERS
        ResetTunnels()
    End Sub
    Private Sub FillMyStandardDataGridView()
        MyStandardsFieldsToSelect = "Select " &
                      " MyStandardTable.MyStandardID_AutoNumber, " &
                      " MyStandardTable.MyStandardName_ShortText35, " &
                      " MyStandardTable.MyStandardDate_DateTime, " &
                      " MyStandardTable.MyLinkedID_LongInteger, " &
                      " LinkedTable.CityName_ShortText25, " &
                      " LinkedTable.ZipCode_ShortText9, " &
                      " StateProvTable.StateProvName_ShortText25, " &
                      " CountryTable.CountryName_ShortText25 "

        MyStandardsTablesLinks = " FROM((MyStandardTable LEFT JOIN LinkedTable ON MyStandardTable.MyLinkedID_LongInteger = LinkedTable.CityID_AutoNumber) " &
                                                       " LEFT JOIN StateProvTable On LinkedTable.StateProvID_LongInteger = StateProvTable.StateProvID_AutoNumber) " &
                                                       " LEFT JOIN CountryTable On StateProvTable.CountryID_LongInteger = CountryTable.CountryID_Autonumber "

        MyStandardsSelectionOrder = " ORDER BY MyStandardName_ShortText35, MyStandardDate_DateTime "

        MySelection = MyStandardsFieldsToSelect & MyStandardsTablesLinks & MyStandardsSelectionFilter & MyStandardsSelectionOrder


        JustExecuteMySelection()
        If RecordCount = 0 Then
            SelectToolStripMenuItem.Visible = False
            AddToolStripMenuItem.Visible = True
            EditToolStripMenuItem.Visible = False
            DeleteToolStripMenuItem.Visible = False
            ViewToolStripMenuItem.Visible = False
            SaveToolStripMenuItem.Visible = False
            SearchToolStrip.Enabled = False
        Else
            DisableModifyMyStandardMode()
        End If
        MyStandardDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable


    End Sub

    Private Sub MyStandardDataGridView_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles MyStandardDataGridView.DataBindingComplete
        Dim NoOfHeaderLines = 1
        Dim RecordsDisplyed = RecordCount
        Dim FormLowPointFromGrid = 90
        MeLocationY = Me.Location.Y
        If RecordCount > 27 Then
            MeLocationY = 50
            RecordsDisplyed = 22
        Else
            RecordsDisplyed = RecordCount
        End If
        MyStandardDataGridView.Height = (MyStandardDataGridView.ColumnHeadersHeight * NoOfHeaderLines) + (DataGridViewRowHeight * RecordsDisplyed)
        Me.Height = MyStandardDataGridView.Height + FormLowPointFromGrid + DataGridViewRowHeight


        MyStandardDataGridView.Columns.Item("MyStandardID_AutoNumber").Visible = False
        MyStandardDataGridView.Columns.Item("MyLinkedID_LongInteger").Visible = False

        MyStandardDataGridView.Columns.Item("MyStandardName_ShortText35").HeaderText = "MyStandardName"                'note 15 chars = 184 pixels  new pixels = char x 184/15
        MyStandardDataGridView.Columns.Item("MyStandardName_ShortText35").Width = 15 * 184 / 15

        MyStandardDataGridView.Columns.Item("MyStandardDate_DateTime").HeaderText = "MyStandardDate"
        MyStandardDataGridView.Columns.Item("MyStandardDate_DateTime").Width = 20 * 184 / 15                            ' 20 for dates with time such as now()
        MyStandardDataGridView.Columns.Item("MyStandardDate_DateTime").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        MyStandardDataGridView.Columns.Item("CityName_ShortText25").HeaderText = "CityName"                'note 15 chars = 184 pixels  new pixels = char x 184/15
        MyStandardDataGridView.Columns.Item("CityName_ShortText25").Width = 25 * 184 / 15

        MyStandardDataGridView.Columns.Item("ZipCode_ShortText9").HeaderText = "ZipCode"                'note 15 chars = 184 pixels  new pixels = char x 184/15
        MyStandardDataGridView.Columns.Item("ZipCode_ShortText9").Width = 9 * 184 / 15

        MyStandardDataGridView.Columns.Item("StateProvName_ShortText25").HeaderText = "StateProvName"                'note 15 chars = 184 pixels  new pixels = char x 184/15
        MyStandardDataGridView.Columns.Item("StateProvName_ShortText25").Width = 25 * 184 / 15

        MyStandardDataGridView.Columns.Item("CountryName_ShortText25").HeaderText = "CountryName"                'note 15 chars = 184 pixels  new pixels = char x 184/15
        MyStandardDataGridView.Columns.Item("CountryName_ShortText25").Width = 25 * 184 / 15

        MyStandardDataGridView.Width = 0
        For i = 0 To MyStandardDataGridView.Columns.GetColumnCount(0) - 1
            If MyStandardDataGridView.Columns.Item(i).Visible = True Then
                MyStandardDataGridView.Width = MyStandardDataGridView.Width + MyStandardDataGridView.Columns.Item(i).Width
            End If
        Next
        MyStandardDataGridView.Width = MyStandardDataGridView.Width + 20

        Me.Width = MyStandardDataGridView.Width + 30
        SavedMeWidth = Me.Width
        MeLocationX = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
        If MeLocationX < 0 Then
            MeLocationX = 0
        End If
        Me.Location = New Point(MeLocationX, MeLocationY)


    End Sub

    Private Sub MyStandardDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles MyStandardDataGridView.RowEnter

        If e.RowIndex < 0 Then Exit Sub
        If RecordCount = 0 Then Exit Sub
        If Not MyStandardDataGridViewInitialized Then
            MyStandardDataGridViewInitialized = True
        End If

        CurrentMyStandardRow = e.RowIndex

        CurrentMyStandardID = MyStandardDataGridView.Item("MyStandardID_AutoNumber", CurrentMyStandardRow).Value
        CurrentLinkedID = MyStandardDataGridView.Item("MyLinkedID_LongInteger", CurrentMyStandardRow).Value
        If MyStandardDetailsGroupBox.Enabled = False Then
            If SaveToolStripMenuItem.Visible = False Then
                ShowMyStandardDetailsGroupBox()
            End If
        End If
    End Sub
    Private Sub ReturnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnToolStripMenuItem.Click
        Select Case MyStandardDetailsGroupBox.Visible
            Case True
                Dim FieldChangeOccured = False

                If SavedMyStandardName <> MyStandardNameTextBox.Text Then
                    FieldChangeOccured = True
                End If
                If SavedMyStandardDate <> MyStandardDateDateTimeTextBox.Text Then
                    FieldChangeOccured = True
                End If
                If FieldChangeOccured Then
                    If Not MsgBox("Do you want to discard changes ?", vbYesNo) = vbYes Then
                        Exit Sub
                    End If
                End If
                MyStandardDataGridView.Enabled = True
                DisableModifyMyStandardMode()
            Case Else
                Tunnel1 = -1
                Me.Close()
        End Select
    End Sub
    Private Sub MyStandardForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        'Fills up tunnel1, tunnel2
        'Enables calling form

        'Enables calling form
        Select Case ActivatedByTextBox.Text
            Case "VehicleManagementSystemForm"
                VehicleManagementSystemForm.Enabled = True ' triggers enabledchaned event of calling form
            Case Else

                Dim x = "break here"
        End Select
        ActivatedByTextBox.Text = ""

    End Sub
    Private Sub MyStandardForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        If Me.Enabled = False Then
            Exit Sub
        End If

        'this portion accepts the code requested
        'coderequested is set by showform routine of the calling form
        If Tunnel1 > -1 Then

            Select Case CodeRequested
                Case = "LinkedID"
                    CurrentLinkedID = Tunnel1
                Case Else
                    MsgBox("Not soecified, hit break")
            End Select
        End If
        ResetTunnels() ' INFORMATION IN TUNNELS HAVE BEEN RECEIVED

    End Sub
    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        PurposeOfMyStandardDetailsGroupBoxEntry = "ADD"
        ' Shows the details editing group box and enables edit to the fields
        ' All DataGridViews are disabled
        ' Searching is disable
        CurrentMyStandardID = -1
        MyStandardDetailsGroupBox.Text = "Add a new EMPLOYEE"
        EnableModifyMyStandardMode()          '' Add Edit Delete are turned off and Cancel ans Save options are made available
    End Sub
    Private Sub ShowMyStandardDetailsGroupBox()

        If Me.Width < MyStandardDetailsGroupBox.Width Then                                              ' detailsgroupBox is wider
            Me.Width = MyStandardDetailsGroupBox.Width + 30
        End If
        If Me.Height < (MyStandardDetailsGroupBox.Height + 90 + DataGridViewRowHeight) Then             ' DetailsGroupBox has more height than the gridview normally occurs with less records
            Me.Height = MyStandardDetailsGroupBox.Height + 90 + DataGridViewRowHeight
        End If

        MyStandardDetailsGroupBox.Visible = True
        If Not MyStandardDetailsGroupBox.Text = "" Then                                                  ' set by ViewToolStripMenuItem.Click in order to allow change of record in the Datagridview which
            ' enables user to view details of other records slected in the DataGridView
            MyStandardDetailsGroupBox.Text = ""

            MyStandardDataGridView.Enabled = False
        End If


        If CurrentMyStandardID = -1 Then                                                        ' no record selected
            MyStandardNameTextBox.Text = ""
            MyStandardDateDateTimeTextBox.Text = Convert.ToDateTime(Now())
            LinkedTextBox.Text = ""
            StateProvTextBox.Text = ""
            ZipCodeTextBox.Text = ""
            CountryTextBox.Text = ""

            CurrentLinkedID = -1
        Else                                                                                    ' record is selected to show
            MyStandardNameTextBox.Text = IIf(IsDBNull(MyStandardDataGridView.Item("MyStandardName_ShortText35", CurrentMyStandardRow).Value), "", MyStandardDataGridView.Item("MyStandardName_ShortText35", CurrentMyStandardRow).Value)
            MyStandardDateDateTimeTextBox.Text = IIf(IsDBNull(MyStandardDataGridView.Item("MyStandardDate_DateTime", CurrentMyStandardRow).Value), "", MyStandardDataGridView.Item("MyStandardDate_DateTime", CurrentMyStandardRow).Value)
            LinkedTextBox.Text = IIf(IsDBNull(MyStandardDataGridView.Item("CityName_ShortText25", CurrentMyStandardRow).Value), "", MyStandardDataGridView.Item("CityName_ShortText25", CurrentMyStandardRow).Value)


        End If
        SavedMyStandardName = MyStandardNameTextBox.Text
        SavedMyStandardDate = MyStandardDateDateTimeTextBox.Text

    End Sub

    Private Sub SearchMyStandardTextBox_TClick(sender As Object, e As EventArgs) Handles SearchMyStandardTextBox.Click
        If SearchMyStandardTextBox.Text = "Search" Then
            SearchMyStandardTextBox.Text = ""
            Exit Sub
        End If
    End Sub
    Private Sub SearchMyStandardTextBox_TextChanged(sender As Object, e As EventArgs) Handles SearchMyStandardTextBox.TextChanged
        If SearchMyStandardTextBox.Text = "Search" Then Exit Sub
        If SearchMyStandardTextBox.Text = "" Then
            MyStandardsSelectionFilter = ""
            FillMyStandardDataGridView()

            Exit Sub
        End If

        Dim FindKey As String = Trim(SearchMyStandardTextBox.Text)

        RecordFinderDbControls.AddParam("@FindKey", "%" & FindKey & "%")
        MyStandardsSelectionFilter = " WHERE MyStandard_ShortText150 Like @FindKey  "

        FillMyStandardDataGridView()
    End Sub
    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        PurposeOfMyStandardDetailsGroupBoxEntry = "EDIT"

        'Check if there are links to the Table
        'if there exists then ask if real change action

        '       MySelection = "Select * from MyStandardTable " &
        '                     "Where MyStandardID_AutoNumber = " & Str(CurrentMyStandardID)
        '       If RecordIsFound() Then

        ' at this point EDIT FEATURE IS JUST ALLOWED

        If Not MsgBox("This MyStandard is currently LINKED to other Files, do you really want to change informations for this MyStandard ?", vbYesNo) = vbYes Then
            Exit Sub
        End If
        '       End If

        'setting the form enabled status will trigger MyStandardForm_EnabledChanged
        MyStandardDetailsGroupBox.Text = "EDIT EMPLOYEE"
        EnableModifyMyStandardMode()
    End Sub
    Private Sub EmployeeDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmployeeDetailsToolStripMenuItem.Click
        PurposeOfMyStandardDetailsGroupBoxEntry = "VIEW"
        MyStandardDetailsGroupBox.Text = ""
        MyStandardDetailsGroupBox.Enabled = False
        EnableModifyMyStandardMode()
        SaveToolStripMenuItem.Visible = False
    End Sub

    Private Sub SaveMyStandardFieldContents()
        Select Case PurposeOfMyStandardDetailsGroupBoxEntry
            Case "ADD"
                If ThisMyStandardAlreadyExist() Then
                    MsgBox("This record already exists")
                    Exit Sub
                End If

                Dim FullName = Trim(MyStandardNameTextBox.Text)
                If Not MsgBox(" Confirm adding new EMPLOYEE " & FullName, vbYesNo) = vbYes Then
                    Exit Sub
                End If

                If Not SuccessfullyAddingThisMyStandardRecord() Then
                    Exit Sub
                End If
            Case "EDIT"


                Dim FullName = Trim(MyStandardNameTextBox.Text)
                If Not MsgBox(" Confirm Saving changes for EMPLOYEE " & FullName, vbYesNo) = vbYes Then
                    Exit Sub
                End If

                Dim RecordFilter = " WHERE MyStandardID_AutoNumber = " & Str(CurrentMyStandardID)
                Dim MyNull = Chr(34) & Chr(34)
                Dim yyyyy = ""

                Dim UpdateFieldsToSelect = " UPDATE MyStandardTable  SET " &
                  IIf(NotEmpty(MyStandardNameTextBox.Text), " MyStandardName_ShortText35  = " & Chr(34) & MyStandardNameTextBox.Text & Chr(34), " MyStandardName_ShortText35 = " & MyNull) & ", " &
                                                      " MyStandardDate_DateTime  = " & Chr(34) & Trim(MyStandardDateDateTimeTextBox.Text) & Chr(34) & ", " &
                                                      " MyLinkedID_LongInteger  = " & Chr(34) & Str(CurrentLinkedID) & Chr(34)

                MySelection = UpdateFieldsToSelect & RecordFilter
                If NoRecordFound() Then Dim dummy = 1
            Case Else
                Dim XXXX = 1
        End Select
        DisableModifyMyStandardMode()
        FillMyStandardDataGridView()
    End Sub
    Private Sub SelectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectToolStripMenuItem.Click
        Tunnel1 = CurrentMyStandardID
        Select Case ActivatedByTextBox.Text
            Case "VehicleManagementSystemForm"
                VehicleManagementSystemForm.Enabled = True
            Case Else
                Dim xxx = 1
        End Select
        Me.Close()
    End Sub
    Private Sub MyStandardDataGridView_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles MyStandardDataGridView.RowHeaderMouseDoubleClick 'Select Row
        Tunnel1 = CurrentMyStandardID
        Tunnel2 = "1stRequestedCode" ' when multiple cosed are requested in a details form or group
        Me.Close()
    End Sub

    Private Sub EnableModifyMyStandardMode()      ' Add Edit Delete are turned off and Cancel ans Save options are made available
        DisableAddEditDeleteMyStandardMenuItems()
        MyStandardDataGridView.Enabled = False
        ShowMyStandardDetailsGroupBox()
    End Sub

    Private Sub DisableModifyMyStandardMode()
        EnableAddEditDeleteMyStandardMenuItems()
        Me.Width = SavedMeWidth
        MyStandardDetailsGroupBox.Visible = False
        MyStandardDataGridView.Enabled = True
    End Sub


    Private Sub EnableAddEditDeleteMyStandardMenuItems()
        SelectToolStripMenuItem.Visible = True
        SaveToolStripMenuItem.Visible = False
        AddToolStripMenuItem.Visible = True
        EditToolStripMenuItem.Visible = True
        ViewToolStripMenuItem.Visible = True
        DeleteToolStripMenuItem.Visible = True
        SearchToolStrip.Enabled = True
    End Sub
    Private Sub DisableAddEditDeleteMyStandardMenuItems()
        SelectToolStripMenuItem.Visible = False
        SaveToolStripMenuItem.Visible = True
        AddToolStripMenuItem.Visible = False
        EditToolStripMenuItem.Visible = False
        ViewToolStripMenuItem.Visible = False
        DeleteToolStripMenuItem.Visible = False
        SearchToolStrip.Enabled = False
    End Sub
    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        ' HERE DETERMINE FIRST ALL RELATIONS
        MyStandardDetailsGroupBox.Text = "DELETE EMPLOYEE"
        EnableModifyMyStandardMode()
        If Not MsgBox("Do you want to continue deleting this EMPLOYEE ?", vbYesNo) = vbYes Then
        Else
            MySelection = "DELETE FROM MyStandardTable WHERE MyStandardID_AutoNumber = " & Str(CurrentMyStandardID)
            JustExecuteMySelection()
            FillMyStandardDataGridView()
        End If
        DisableModifyMyStandardMode()
    End Sub
    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        If MyStandardFieldsEntriesAreNotValidAndComplete() Then
            Exit Sub
        End If
        SaveMyStandardFieldContents()
    End Sub
    Private Function MyStandardFieldsEntriesAreNotValidAndComplete()
        If Trim(MyStandardNameTextBox.Text) = "" Then
            MyStandardNameTextBox.Select()
            Return True
        End If
        If Trim(MyStandardDateDateTimeTextBox.Text) = "" Then
            MyStandardDateDateTimeTextBox.Select()
            Return True
        End If
        If Trim(LinkedTextBox.Text) = "" Then
            LinkedTextBox.Select()
            Return True
        End If
        Return False
    End Function
    Private Sub LastNameTextBox_TextChanged(sender As Object, e As EventArgs) Handles MyStandardNameTextBox.TextChanged
        If Len(Trim(MyStandardNameTextBox.Text)) > 35 Then
            MyStandardNameTextBox.Text = MyStandardNameTextBox.Text.Substring(0, 35)
        End If
    End Sub
    Private Sub FirstNameTextBox_TextChanged(sender As Object, e As EventArgs) Handles MyStandardDateDateTimeTextBox.TextChanged
        If Len(Trim(MyStandardDateDateTimeTextBox.Text)) > 21 Then
            MyStandardDateDateTimeTextBox.Text = MyStandardDateDateTimeTextBox.Text.Substring(0, 21)
        End If
    End Sub
    Private Function ThisMyStandardAlreadyExist()
        RecordFinderDbControls.AddParam("@MyStandardDate", Convert.ToDateTime(MyStandardDateDateTimeTextBox.Text))
        MySelection = "SELECT * FROM MyStandardTable " &
            " WHERE trim(MyStandardName_ShortText35) = " & Chr(34) & Trim(MyStandardNameTextBox.Text) & Chr(34) &
                 " And MyStandardDate_DateTime = @MyStandardDate "

        If ThereIsARecord() Then
            Return True
        End If

        Return False
    End Function
    Private Function SuccessfullyAddingThisMyStandardRecord()

        ' EXECUTE INSERT COMMAND

        MyStandardFieldsToReplace = "" &
            "MyStandardName_ShortText35, " &
            "MyStandardDate_DateTime, " &
            "MyLinkedID_LongInteger "

        MyStandardFieldsValues = "" &
            Chr(34) & Trim(MyStandardNameTextBox.Text) & Chr(34) & ", " &
            Chr(34) & Trim(MyStandardDateDateTimeTextBox.Text) & Chr(34) & ", " &
            Str(CurrentLinkedID)

        MySelection = "INSERT INTO MyStandardTable  (" & MyStandardFieldsToReplace & ") VALUES (" & MyStandardFieldsValues & ")"

        JustExecuteMySelection()

        If ThisMyStandardAlreadyExist() Then
            Dim r As DataRow = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
            CurrentMyStandardID = r("MyStandardID_AutoNumber")
        Else
            MsgBox("PROBLEM ...... unseccessful save ")
            Return False
        End If

        Return True
    End Function

    Private Sub MyStadardID_LongIntegerTextBox_Click(sender As Object, e As EventArgs) Handles LinkedTextBox.Click
        If LinkedTextBox.Text = "" Then
            ShowLinkedForm()
        Else
            If Me.Enabled = True Then
                If MsgBox("Do you intend to change the link ?", vbYesNo) = vbYes Then
                    LinkedTextBox.Text = ""
                    ShowLinkedForm()
                End If
            End If
        End If
    End Sub
    Private Sub ShowLinkedForm()
        CodeRequested = "LinkedID"
        Me.Enabled = False
        LinkedForm.ActivatedBy.Text = Me.Name
        LinkedForm.Show()
        LinkedForm.SearchLinkedTextBox.Select()
    End Sub

    Private Sub SearchToolStrip_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles SearchToolStrip.ItemClicked

    End Sub
End Class