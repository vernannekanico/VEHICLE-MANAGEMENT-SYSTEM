Public Class JobsForm
    Private CurrentJobID As Integer = -1
    Private CurrentJobRow As Integer = -1

    Private CurrentJobTypeID As Integer = -1
    Private SavedCurrentJobTypeID As Integer = -1 ' use upon update

    Private CurrentMasterCodeBookID As Integer = -1
    Private SavedCurrentMasterCodeBookID_LongIntegerID As Integer = -1 ' use upon update
    Private CurrentConcernID As Integer = -1

    Private CurrentJobTypeCode = ""
    Private TypeOfRequest = ""
    Public ProductCode As Integer = -1

    Private JobsDataGridViewInitialized = False

    Private JobsFieldsToSelect = ""
    Private JobsTablesLinks = ""
    Private JobsSelectionFilter = ""
    Private JobsSelectionFilterSaved = ""
    Private JobsSelectionOrder = ""
    Private MeLocationX As Integer
    Private MeLocationY As Integer
    Private JobsDataGridViewAlreadyFormated = False
    Private SavedCallingForm As Form

    Private Sub JobsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SavedCallingForm = CallingForm


        ' ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        MeLocationX = Me.Location.X
        MeLocationY = 50
        ' check these if needed
        'GET ALL ENTRY PARAMETERS


        JobsSelectionFilter = ""

        FillInformationsHeadersTypeComboBox()

        FillJobsDataGridView()


        'SET AND RESET ALL ENTRY PARAMETERS

    End Sub
    Private Sub FillJobsDataGridView()
        'USING JobsInJobsFormQuery

        JobsFieldsToSelect = "Select " &
                                     " JobsTable.JobID_AutoNumber, " &
                                     " JobsTable.InformationsHeadersTypeID_LongInteger, " &
                                     " JobsTable.MasterCodeBookId_LongInteger, " &
                                     " JobsTable.ProcedureOrInformationShortText1, " &
                                     " JobsTable.Source_Byte, " &
                                     " InformationsHeadersTypeTable.InformationsHeadersType_ShortText100, " &
                                     " InformationsHeadersTypeTable.JobPrefix50, " &
                                     " MasterCodeBookTable.SystemDesc_ShortText100Fld, " &
                                     " JobsTable.JobDescription_ShortText255 "

        JobsTablesLinks = " FROM (JobsTable  " &
            " LEFT JOIN InformationsHeadersTypeTable ON JobsTable.InformationsHeadersTypeID_LongInteger = InformationsHeadersTypeTable.InformationsHeadersTypeID_AutoNumber) " &
            " LEFT JOIN MasterCodeBookTable ON JobsTable.MasterCodeBookId_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber "

        JobsSelectionOrder = " ORDER BY SystemDesc_ShortText100Fld ASC"
        MySelection = JobsFieldsToSelect & JobsTablesLinks & JobsSelectionFilter & JobsSelectionOrder
        If NoRecordFound() Then
            Dim xxx = 10
        End If
        JobsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        If Not JobsDataGridViewAlreadyFormated Then
            FormatJobsDataGridView()
        End If
    End Sub
    Private Sub FormatJobsDataGridView()
        JobsDataGridViewAlreadyFormated = True
        For i = 0 To JobsDataGridView.Columns.GetColumnCount(0) - 1


            Dim DoNotDisplayFields = "JobID_AutoNumber, " &
                                         " JobTypeID_LongInteger, " &
                                         " MasterCodeBookId_LongInteger, " &
                                         " Source_Byte, " &
                                         "InformationsHeadersType_ShortText100 "
            If InStr(DoNotDisplayFields, JobsDataGridView.Columns.Item(i).HeaderText) > 0 Then
                JobsDataGridView.Columns.Item(i).Visible = False
            End If

            Select Case JobsDataGridView.Columns.Item(i).HeaderText
                Case "JobAffix50"
                    JobsDataGridView.Columns.Item(i).HeaderText = "Affix"
                    JobsDataGridView.Columns.Item(i).Width = 105
                Case "SystemDesc_ShortText100Fld"
                    JobsDataGridView.Columns.Item(i).HeaderText = "MasterCodeBookTable"
                    JobsDataGridView.Columns.Item(i).Width = 500
                Case "JobDescription_ShortText255"
                    JobsDataGridView.Columns.Item(i).HeaderText = "JobsTable"
                    JobsDataGridView.Columns.Item(i).Width = 500

            End Select

        Next

        For i = 0 To JobsDataGridView.Columns.GetColumnCount(0) - 1
            If JobsDataGridView.Columns.Item(i).Visible = True Then
                JobsDataGridView.Width = JobsDataGridView.Width + JobsDataGridView.Columns.Item(i).Width
            End If
        Next

        Me.Width = JobsDataGridView.Width + 30

    End Sub

    Private Sub JobTypesComboBox_TextChanged(sender As Object, e As EventArgs) Handles JobTypesComboBox.TextChanged
        If JobTypesComboBox.Text = "Select Type Of JOBS" Then Exit Sub
        Tunnel3 = 0  ' description is from MasterCodeBook 
        SetParentRecordReference("InformationsHeadersTypeTable", "InformationsHeadersType_ShortText100", JobTypesComboBox.Text)
        Dim r As DataRow
        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        CurrentJobTypeID = r("InformationsHeadersTypeID_AutoNumber")
        Dim InQuoteJobType = Chr(34) & Trim(JobTypesComboBox.Text) & Chr(34)
        JobsSelectionFilter = " WHERE InformationsHeadersTypeID_LongInteger = " & CurrentJobTypeID
        EnableToolStripMenuItems()

        Select Case JobTypesComboBox.Text
            Case "Select Type Of Job"
                DisableToolStripMenuItems()
            Case "All Jobs"
                JobsSelectionFilter = ""

            Case Else

        End Select
        SearchJobTextBox.Text = "Search"
        FillJobsDataGridView()
        JobTypeTextBox.Text = JobTypesComboBox.Text


    End Sub
    Public Sub FillInformationsHeadersTypeComboBox()

        MySelection = "Select  " &
                           " InformationsHeadersTypeTable.InformationsHeadersType_ShortText100,  " &
                           "  InformationsHeadersTypeClassTable.InformationsHeadersTypeClass_ShortText100,  " &
                           " InformationsHeadersTypeTable.InformationsHeadersTypeClassID_Integer   " &
                           " From InformationsHeadersTypeTable  " &
                                        " LEFT Join InformationsHeadersTypeClassTable  " &
                                            " On InformationsHeadersTypeTable.InformationsHeadersTypeClassID_Integer =  " &
                                               " InformationsHeadersTypeClassTable.InformationsHeadersTypeClassID_AutoNumber  " &
                          " WHERE  InformationsHeadersTypeClass_ShortText100 = " & Chr(34) & "JOBS" & Chr(34) &
                          " ORDER BY InformationsHeadersTypeClassID_Integer, InformationsHeadersType_ShortText100 "

        If NoRecordFound() Then
            Exit Sub
        End If
        ' FILL DATAGRID
        '      JobsTypeDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        ' CLEAR COMBOBOX
        JobTypesComboBox.Items.Clear()

        ' FILL COMBOBOX
        Dim JobRelatedREcords = 0
        For Each R As DataRow In RecordFinderDbControls.MyAccessDbDataTable.Rows
            JobTypesComboBox.Items.Add(R("InformationsHeadersType_ShortText100"))
            JobRelatedREcords = JobRelatedREcords + 1
        Next

        ' DISPLAY FIRS NAME FOUND
        If RecordCount > 0 Then
            For I = 0 To JobRelatedREcords - 1
                If JobTypesComboBox.Items(I).ToString = "Select Type Of JOBS" Then
                    JobTypesComboBox.Text = JobTypesComboBox.Items(I).ToString
                    Exit For
                End If
            Next
            '           JobTypesComboBox.Text = (JobTypesComboBox.Items(2)).ToString
        End If
    End Sub


    Private Sub JobsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles JobsDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If RecordCount = 0 Then Exit Sub
        If Not JobsDataGridViewInitialized Then
            JobsDataGridViewInitialized = True
        End If

        CurrentJobRow = e.RowIndex
        CurrentJobID = JobsDataGridView.Item("JobID_AutoNumber", CurrentJobRow).Value

    End Sub
    Private Sub JobsDataGridView_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles JobsDataGridView.DataBindingComplete
        Dim NoOfHeaderLines = 1
        Dim RecordsDisplyed = RecordCount
        Dim FormLowPointFromGrid = 90
        If RecordCount > 27 Then
            Me.Location = New Point(MeLocationX, MeLocationY)
            RecordsDisplyed = 22
        Else
            RecordsDisplyed = RecordCount + 1
        End If
        JobsDataGridView.Height = (JobsDataGridView.ColumnHeadersHeight * NoOfHeaderLines) + (DataGridViewRowHeight * RecordsDisplyed) + DataGridViewRowHeight
        Me.Height = JobsDataGridView.Height + FormLowPointFromGrid + 110
        '       VehicleTrimDataGridView.Location = New Point(1, 49)

    End Sub




    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        'Fills up tunnel1, tunnel2
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub

    Private Sub JobsForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        If Me.Enabled = False Then Exit Sub
        CallingForm = SavedCallingForm
        Select Case Tunnel1
            Case "Tunnel2IsMasterCodeBookID"
                CurrentMasterCodeBookID = Tunnel2
                JobTextBox.Text = Tunnel3
        End Select

    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        If CurrentJobTypeID < 1 Then
            MsgBox("Type of Job should be selected")
            Label1.Visible = True
            JobTypesComboBox.Visible = True
            JobTypesComboBox.Text = "Select Type Of JOBS"
            JobTypesComboBox.Select()
            Exit Sub
        End If

        TypeOfRequest = "ADD"
        ModifyGroupBox.Text = "Add a Job"
        ModifyGroupBox.Visible = True
        EnableAbleModifyMode()
    End Sub

    Private Sub SearchJobTextBox_TClick(sender As Object, e As EventArgs) Handles SearchJobTextBox.Click
        If SearchJobTextBox.Text = "Search" Then
            SearchJobTextBox.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub SearchJobTextBox_TextChanged(sender As Object, e As EventArgs) Handles SearchJobTextBox.TextChanged
        If SearchJobTextBox.Text = "Search" Then Exit Sub
        If SearchJobTextBox.Text = "" Then
            JobsSelectionFilter = ""
            FillJobsDataGridView()

            Exit Sub
        End If

        Dim FindKey As String = Trim(SearchJobTextBox.Text)

        JobsSelectionFilterSaved = JobsSelectionFilter
        Dim Search1 = " JobDescription_ShortText255 Like " & Chr(34) & "%" & FindKey & "%" & Chr(34)
        Dim Search2 = " SystemDesc_ShortText100Fld Like " & Chr(34) & "%" & FindKey & "%" & Chr(34)
        Dim Search3 = " ProcedureOrInformationShortText1 = " & Chr(34) & "A" & Chr(34)

        JobsSelectionFilter = " WHERE (" & Search1 & " OR " & Search2 & ") AND " & Search3

        FillJobsDataGridView()
        JobsSelectionFilter = JobsSelectionFilterSaved
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        TypeOfRequest = "UPDATE"
        'Check if there are links to the WorkOrderConcernJobsTable
        'if there exists then ask if real change action

        MySelection = "Select * from WorkOrderConcernJobsTable " &
                      "Where WorkOrderConcernJobID_AutoNumber = " & Str(CurrentJobID)

        If RecordIsFound() Then
            If Not MsgBox("This Job is LINKED to a closed WORK ORDER, do you really want to change the description ?", 4) = 6 Then
                Exit Sub
            End If
        End If

        'setting the form enabled status will trigger JobsForm_EnabledChanged
        '       JobTypeTextBox.Text = JobsDataGridView.Item("InformationsHeadersType_ShortText100", CurrentWorkOrderJobRow).Value


        If JobsDataGridView.Item("JobDescription_ShortText255", CurrentJobRow).Value > "" Then
            ModifyGroupBox.Text = "old Job: " & JobsDataGridView.Item("JobDescription_ShortText255", CurrentJobRow).Value
        End If
        SavedCurrentMasterCodeBookID_LongIntegerID = CurrentMasterCodeBookID
        SavedCurrentJobTypeID = CurrentJobTypeID
        EnableAbleModifyMode()
        ShowCalledForm(Me, MasterCodeBookForm)
    End Sub

    Private Sub SelectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectToolStripMenuItem.Click
        If IsEmpty(JobsDataGridView.Item("MasterCodeBookID_LongInteger", CurrentJobRow).Value) Then
            Tunnel1 = SearchJobTextBox.Text
            ShowCalledForm(Me, MasterCodeBookForm)
        Else
            Tunnel1 = "Tunnel2IsJobID"
            Tunnel2 = CurrentJobID

            DoCommonHouseKeeping(Me, SavedCallingForm)
        End If
    End Sub
    Private Sub JobsDataGridView_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles JobsDataGridView.RowHeaderMouseDoubleClick 'Select Row
        Tunnel1 = "Tunnel2IsJobCode"
        Tunnel2 = CurrentJobID
        Tunnel3 = 0 ' returned value 0 indicates that description comes from the Jobstable where field TextType_Byte of WorkOrderComernsTable
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub

    Private Sub EnableToolStripMenuItems()
        SelectToolStripMenuItem.Visible = True
        SaveToolStripMenuItem.Visible = True
        AddToolStripMenuItem.Visible = True
        EditToolStripMenuItem.Visible = True
        ViewToolStripMenuItem.Visible = True
        DeleteToolStripMenuItem.Visible = True
    End Sub
    Private Sub DisableToolStripMenuItems()
        SelectToolStripMenuItem.Visible = False
        SaveToolStripMenuItem.Visible = False
        AddToolStripMenuItem.Visible = False
        EditToolStripMenuItem.Visible = False
        ViewToolStripMenuItem.Visible = False
        DeleteToolStripMenuItem.Visible = False
    End Sub
    Private Sub DisableModifyMode()
        ModifyGroupBox.Visible = False
        SelectToolStripMenuItem.Visible = True
        AddToolStripMenuItem.Visible = True
        EditToolStripMenuItem.Visible = True
        DeleteToolStripMenuItem.Visible = True
        ViewToolStripMenuItem.Visible = True
        SaveToolStripMenuItem.Visible = False
    End Sub
    Private Sub EnableAbleModifyMode()
        ModifyGroupBox.Visible = True
        SelectToolStripMenuItem.Visible = False
        SaveToolStripMenuItem.Visible = True
        AddToolStripMenuItem.Visible = False
        EditToolStripMenuItem.Visible = False
        ViewToolStripMenuItem.Visible = False
        DeleteToolStripMenuItem.Visible = False
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        ModifyGroupBox.Text = "Delete a TYPE Job"
        MsgBox("not needed at this time")
        EnableAbleModifyMode()

    End Sub

    Private Sub ModifyGroupBox_Enter(sender As Object, e As EventArgs) Handles ModifyGroupBox.VisibleChanged
        If ModifyGroupBox.Visible = True Then
            JobsDataGridView.Enabled = False
        Else
            JobsDataGridView.Enabled = True
        End If
    End Sub

    Private Sub JobTypeTextBox_TextChanged(sender As Object, e As EventArgs) Handles JobTypeTextBox.GotFocus
        If JobTextBox.Text = "" Then
            Me.Enabled = False
        End If
        'study this i added the 2 command lines
        CurrentJobTypeID = Tunnel1
        EnableAbleModifyMode()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        ' maybe the type and Job is being considered here
        Select Case TypeOfRequest
            Case "ADD"
                ' EXECUTE INSERT COMMAND

                InsertIntoJobsTable()


            Case "UPDATE"
                SetParentRecordReference("JobsTable", "JobID_AutoNumber", CurrentJobID)
                Dim r As DataRow
                r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
                Dim xxJobDescription_ShortText255 = r("JobDescription_ShortText255")
                Dim JobsFilter = " WHERE JobDescription_ShortText255 = " & Chr(34) & xxJobDescription_ShortText255 & Chr(34)

                MySelection = " UPDATE JobsTable " &
                              " SET InformationsHeadersTypeID_LongInteger = " & Str(CurrentJobTypeID) & ", " &
                              "     MasterCodeBookID_LongInteger  = " & Str(CurrentMasterCodeBookID) & ", " &
                              "     DeleteMeYesNo  = " & vbNo.ToString & ", " &
                              "     Source_Byte  = " & 3.ToString & ", " &
                                 " ProcedureOrInformationShortText1 = " & Chr(34) & "A" & Chr(34)

                MySelection = MySelection & JobsFilter

                JustExecuteMySelection()

                MySelection = "Select * from JobsTable WHERE InformationsHeadersTypeID_LongInteger  = " & Str(CurrentJobTypeID) &
                                                           " AND " & "     MasterCodeBookID_LongInteger  = " & Str(CurrentMasterCodeBookID)
                JustExecuteMySelection()

                If RecordCount < 0 Then
                    MsgBox("Update not successful")
                Else
                    MsgBox(Str(RecordCount) & " record(s) updated")
                End If

            Case Else
        End Select

        FillJobsDataGridView()
        DisableModifyMode()

    End Sub
    Private Sub InsertIntoJobAsIsByClientTable()
    End Sub
    Private Sub InsertIntoJobsTable()
        MySelection = "Select * from JobsTable WHERE InformationsHeadersTypeID_LongInteger = " & Str(CurrentJobTypeID) &
                                                           " AND " & "     MasterCodeBookID_LongInteger  = " & Str(CurrentMasterCodeBookID)

        If RecordIsFound() Then
            MsgBox("This Job already exist")
            Exit Sub
        End If

        If Not MsgBox(" Confirm adding " & JobTextBox.Text, vbYesNo) = vbYes Then
            JobTextBox.Select()
            Exit Sub
        End If

        MySelection = "INSERT INTO JobsTable  (" &
                                            " InformationsHeadersTypeID_LongInteger, " &
                                            " Source_Byte, " &
                                            " ProcedureOrInformationShortText1, " &
                                            " DeleteMeYesNo, " &
                                            " MasterCodeBookId_LongInteger)  " &
                                      "VALUES (" &
                                              Str(CurrentJobTypeID) & ", " &
                                              Str(3) & ", " &
                                              Chr(34) & "A" & Chr(34) & ", " &
                                              vbNo.ToString & ", " &
                                              Str(CurrentMasterCodeBookID) & " )"

        JustExecuteMySelection()

        MySelection = "Select * from JobsTable WHERE InformationsHeadersTypeID_LongInteger = " & Str(CurrentJobTypeID) &
                                                           " AND " & "     MasterCodeBookID_LongInteger  = " & Str(CurrentMasterCodeBookID)

        If NoRecordFound() Then
            MsgBox("PROBLEM ...... unseccessful save ")
            Exit Sub
        End If
        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)

        CurrentJobID = r("JobID_AutoNumber")

    End Sub
    Private Sub JobTextBox_TextChanged(sender As Object, e As EventArgs) Handles JobTextBox.Click
        If Not JobTypesComboBox.Text = "Customer Description of the Problem" Then

            ShowCalledForm(Me, MasterCodeBookForm)
        End If
    End Sub

End Class