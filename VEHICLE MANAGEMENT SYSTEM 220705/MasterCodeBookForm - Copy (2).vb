Imports excel = Microsoft.Office.Interop.Excel
Public Class MasterCodeBookForm


    Private CurrentSubSystemCodeBookID As Integer
    Public CurrentMainSystemCode As String
    Private CurrentMainSystemName As String
    Private CurrentMainCodeLength As Integer
    Private CurrentMainCodeColumn As Integer
    Private CurrentMainSystemCodeRow As Integer
    Private CurrentVehicleRepairID As Integer

    Private MainSystemCodeFieldsToSelect = ""
    Private MainSystemCodeTablesLinks = ""
    Private MainSystemCodeSelectionFilter = ""
    Private MainSystemCodeSelectionFilterSaved = ""
    Private MainSystemCodeSelectionOrder = ""

    Public CurrentSubSystemCode As String = "0101"
    Private CurrentSubSystemName As String
    Private CurrentSubCodeColumn As Integer
    Private CurrentSubSystemCodeRow As Integer = 0
    Private CurrentParentCode = ""
    Private CurrentParentName = ""
    Private CurrentMasterCodeBookSubSystemID = 1
    Private IncludeGrandChildren = False

    Private CurrentChildCode = ""
    Private CurrentChildName = ""

    '   Private MyAccess As New MyDbControls
    Private SubSystemCodeFieldsToSelect = ""
    Private SubSystemCodeTablesLinks = ""
    Private SubSystemCodeSelectionFilter = ""
    Private SubSystemCodeSelectionFilterSaved = ""
    Private SubSystemCodeSelectionOrder = ""

    Private CurrentSystemInfoHeaderID As Integer
    Private CurrentSystemInfoHeaderRow As Integer

    Private SystemInfoHeadersDataGridViewInitialized = False
    Private SystemInfoHeadersRecordCount As Integer = 0

    Private SystemInfoHeadersFieldsToSelect = ""
    Private SystemInfoHeadersTablesLinks = ""
    Private SystemInfoHeadersSelectionFilter = ""
    Private SystemInfoHeadersSelectionFilterSaved = ""
    Private SystemInfoHeadersSelectionOrder = ""

    Private PurposeOfMasterCodeBookDetailsGroupEntry = "ADD"

    Private Siblings As String = ""
    Private Children As String = ""
    '   Private SavedSubSystemCode = ""
    '   Private SavedSubSystemDesc = ""
    Private SubMainFilter = ""

    Private MasterCodeBookFieldsValues = ""
    Private MasterCodeBookFieldsToReplace = ""

    Private DefaultProcedurePath = DefaultSystemPath & "\Procedures\"
    Private ExcelFileName = ""
    Private ProcedureExists = ""
    Private CalledFormName = ""
    Private ProcedureName = ""
    Private SearchIsOnFlag = True



    Private Sub MasterCodeBookForm_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        MasterCodeBookDetailsGroup.Location = New Point(50, 85)
        Tunnel1 = ""
        If Not Tunnel2 = "" Then
            SubMainFilter = " (MainSystemCode_ShortText1 = ""2"" OR MainSystemCode_ShortText1 = " & Chr(34) & Trim(Tunnel2) & Chr(34) & ") AND "
        End If

        FillMainSystemCodeDataGridView()
        DefaultVehicleModelTextBox.Select()

    End Sub
    Private Sub SelectMasterCodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectMasterCodeToolStripMenuItem.Click
        Select Case ActivatedBy.Text
            Case = "ConcernsForm"
                Tunnel1 = CurrentMasterCodeBookSubSystemID
                ConcernsForm.ConcernTextBox.Text = SubSystemCodeDataGridView.Item("SystemDesc_ShortText100Fld", CurrentSubSystemCodeRow).Value
                '
                '        Case = "VehiclesServicedDetailsForm"
                '        VehiclesServicedDetailsForm.VehicleTextBox.Text = VehicleString'
                '
            Case Else
                MsgBox("break, need to know which form activated this") '

        End Select
        Me.Close()

    End Sub

    Private Sub FillMainSystemCodeDataGridView()
        Dim MainSystemCodeInQuote = Chr(34) & "1" & Chr(34)
        MainSystemCodeFieldsToSelect = "Select SubSystemCode_ShortText24Fld, " &
                                    " SystemDesc_ShortText100Fld "
        MainSystemCodeSelectionFilter = " WHERE MainSystemCode_ShortText1 = " & MainSystemCodeInQuote
        MainSystemCodeSelectionOrder = " ORDER BY SubSystemCode_ShortText24Fld "
        SubSystemCodeTablesLinks = " FROM MasterCodebookTable "

        MySelection = MainSystemCodeFieldsToSelect & SubSystemCodeTablesLinks & MainSystemCodeSelectionFilter & MainSystemCodeSelectionOrder

        JustExecuteMySelection()

        ' FILL DATAGRID
        MainSystemCodeDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        ' Initialize MasterCodeBookDataGridView


        MainSystemCodeDataGridView.Columns.Item("SubSystemCode_ShortText24Fld").Width = 100
        MainSystemCodeDataGridView.Columns.Item("SystemDesc_ShortText100Fld").Width = 400

        MainSystemCodeDataGridView.Columns.Item("SubSystemCode_ShortText24Fld").HeaderText = "System Code"
        MainSystemCodeDataGridView.Columns.Item("SystemDesc_ShortText100Fld").HeaderText = "System"

    End Sub
    Private Sub MainSystemCodeDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles MainSystemCodeDataGridView.RowEnter
        If e.RowIndex < 0 Then
            Exit Sub
        End If
        CurrentMainSystemCodeRow = e.RowIndex
        CurrentMainSystemName = Trim(MainSystemCodeDataGridView.Item(1, CurrentMainSystemCodeRow).Value)
        CurrentMainSystemCode = LTrim(RTrim(MainSystemCodeDataGridView.Item(0, CurrentMainSystemCodeRow).Value))
        Dim first2codes = "(Mid(SubSystemCode_ShortText24Fld,1,2) = " & Chr(34) & CurrentMainSystemCode & Chr(34)
        Dim LengthOf4 = " And Len(Trim(SubSystemCode_ShortText24Fld)) = 4 )"
        Siblings = first2codes & LengthOf4
        Children = " (mid(SubSystemCode_ShortText24Fld,1,4) = " & Chr(34) & CurrentMainSystemCode & "01" & Chr(34) & ")"
        '   SavedSubSystemCode = CurrentSubSystemCode
        '   SavedSubSystemDesc = CurrentSubSystemName
        CurrentSubSystemCode = CurrentMainSystemCode & "01"
        CurrentSubSystemName = ""
        FillSubSystemDataGridView()
        SubSystemCodeDataGridView.Rows(0).Selected = True
    End Sub

    Private Sub FillSubSystemDataGridViewOriginal()
        Dim SubCodeLength = Len(Trim(CurrentSubSystemCode))

        '      If SavedSubSystemCode <> CurrentSubSystemCode Then
        Dim Parent = "Mid(SubSystemCode_ShortText24Fld,1," & Str(SubCodeLength - 2) & ")"
        Dim ParentKey = Parent & " = " & Mid(CurrentSubSystemCode, 1, SubCodeLength - 2)
        Dim ParentKeyLength = " And Len(Trim(SubSystemCode_ShortText24Fld)) = " & Str(SubCodeLength)
        Siblings = "(" & ParentKey & ParentKeyLength & ")"
        Children = " (mid(SubSystemCode_ShortText24Fld,1," & Str(Len(Trim(CurrentSubSystemCode))) & ") = " & Chr(34) & CurrentSubSystemCode & Chr(34) & ")"
        Dim ChildrenLength = " And Len(Trim(SubSystemCode_ShortText24Fld)) = " & Str(SubCodeLength + 2)
        Children = "(" & Children & ChildrenLength & ")"

        '           SavedSubSystemCode = CurrentSubSystemCode
        '      End If

        SubSystemCodeFieldsToSelect = "Select " &
            " SubSystemCode_ShortText24Fld, " &
            " SystemDesc_ShortText100Fld, " &
            " MasterCodeBookID_Autonumber "
        SubSystemCodeTablesLinks = " FROM MasterCodeBookTable "
        SubSystemCodeSelectionFilter = "where " & SubMainFilter & Siblings & " Or " & Children
        If Len(Trim(CurrentSubSystemCode)) = 2 Then
            SubSystemCodeSelectionFilter = " WHERE " & SubMainFilter & Children
        End If

        SubSystemCodeSelectionOrder = " ORDER BY SubSystemCode_ShortText24Fld "

        MySelection = SubSystemCodeFieldsToSelect & SubSystemCodeTablesLinks & SubSystemCodeSelectionFilter & SubSystemCodeSelectionOrder

        JustExecuteMySelection()

        ' FILL DATAGRID
        SubSystemCodeDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        SubSystemCodeDataGridView.Columns("MasterCodeBookID_Autonumber").Visible = False

        SubSystemCodeDataGridView.Columns.Item("SubSystemCode_ShortText24Fld").Width = 135
        SubSystemCodeDataGridView.Columns.Item("SystemDesc_ShortText100Fld").Width = 400
        SubSystemCodeDataGridView.Columns.Item("SubSystemCode_ShortText24Fld").HeaderText = CurrentMainSystemCode
        SubSystemCodeDataGridView.Columns.Item("SystemDesc_ShortText100Fld").HeaderText = Trim(MainSystemCodeDataGridView.Item(CurrentMainCodeColumn + 1, CurrentMainSystemCodeRow).Value)

    End Sub
    Private Sub FillSubSystemDataGridView()
        Dim SubCodeLength = Len(Trim(CurrentSubSystemCode))
        '      If SavedSubSystemCode <> CurrentSubSystemCode Then
        Dim Parent = "Mid(SubSystemCode_ShortText24Fld,1," & Str(SubCodeLength - 2) & ")"
        CurrentParentCode = Parent & " = " & Mid(CurrentSubSystemCode, 1, SubCodeLength - 2)
        Dim ParentKeyLength = " And Len(Trim(SubSystemCode_ShortText24Fld)) = " & Str(SubCodeLength)
        Siblings = "(" & CurrentParentCode & ParentKeyLength & ")"
        Children = " (mid(SubSystemCode_ShortText24Fld,1," & Str(Len(Trim(CurrentSubSystemCode))) & ") = " & Chr(34) & CurrentSubSystemCode & Chr(34) & ")"
        Dim ChildrenLength = " And Len(Trim(SubSystemCode_ShortText24Fld)) = " & Str(SubCodeLength + 2)
        Dim GrandChildren = ""
        If IncludeGrandChildren Then
            Children = "(" & Children & ")"
        Else
            Children = "(" & Children & ChildrenLength & ")"
        End If
        '           SavedSubSystemCode = CurrentSubSystemCode
        '       End If

        SubSystemCodeFieldsToSelect = "Select " &
            " SubSystemCode_ShortText24Fld, " &
            " SystemDesc_ShortText100Fld, " &
            " MasterCodeBookID_Autonumber "
        SubSystemCodeTablesLinks = " FROM MasterCodeBookTable "
        SubSystemCodeSelectionFilter = "where " & SubMainFilter & Siblings & " Or " & Children
        If Len(Trim(CurrentSubSystemCode)) = 2 Then
            SubSystemCodeSelectionFilter = " WHERE " & SubMainFilter & Children
        End If

        SubSystemCodeSelectionOrder = " ORDER BY SubSystemCode_ShortText24Fld "

        MySelection = SubSystemCodeFieldsToSelect & SubSystemCodeTablesLinks & SubSystemCodeSelectionFilter & SubSystemCodeSelectionOrder

        JustExecuteMySelection()
        ' FILL DATAGRID
        Dim cccccccccc = RecordCount
        SubSystemCodeDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        SubSystemCodeDataGridView.Columns("MasterCodeBookID_Autonumber").Visible = False

        SubSystemCodeDataGridView.Columns.Item("SubSystemCode_ShortText24Fld").Width = 135
        SubSystemCodeDataGridView.Columns.Item("SystemDesc_ShortText100Fld").Width = 400
        SubSystemCodeDataGridView.Columns.Item("SubSystemCode_ShortText24Fld").HeaderText = CurrentMainSystemCode
        SubSystemCodeDataGridView.Columns.Item("SystemDesc_ShortText100Fld").HeaderText = Trim(MainSystemCodeDataGridView.Item(CurrentMainCodeColumn + 1, CurrentMainSystemCodeRow).Value)

    End Sub

    Private Sub SubSystemCodeDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles SubSystemCodeDataGridView.RowEnter
        CurrentSubSystemCodeRow = e.RowIndex

        CurrentSubSystemName = Trim(SubSystemCodeDataGridView.Item(CurrentSubCodeColumn + 1, CurrentSubSystemCodeRow).Value)
        CurrentSubSystemCode = LTrim(RTrim(SubSystemCodeDataGridView.Item(0, CurrentSubSystemCodeRow).Value))
        CurrentSubSystemCodeBookID = LTrim(RTrim(SubSystemCodeDataGridView.Item("MasterCodeBookID_Autonumber", CurrentSubSystemCodeRow).Value))
        DeleteMasterCodeToolStripMenuItem.Visible = False
        CurrentMasterCodeBookSubSystemID = SubSystemCodeDataGridView.Item("MasterCodeBookID_Autonumber", CurrentSubSystemCodeRow).Value

        FillSystemInfoHeadersDataGridView()
        '  Update Parent header values here 
        GEtParentDetails()
    End Sub
    Private Sub GEtParentDetails()
        If SearchIsOnFlag Then
            SearchIsOnFlag = False
            Exit Sub
        End If
        ' QUERY USER
        If Len(CurrentSubSystemCode) < 3 Then
            SubSystemCodeDataGridView.Columns("SubSystemCode_ShortText24Fld").HeaderText = CurrentSubSystemCode
            SubSystemCodeDataGridView.Columns("SystemDesc_ShortText100Fld").HeaderText = CurrentSubSystemCode
            Exit Sub
        End If

        Dim ParentCode = CurrentSubSystemCode.Substring(0, Len(CurrentSubSystemCode) - 2)
        RecordFinderDbControls.AddParam("@ParentCode", ParentCode)
        MySelection = "Select TOP 1 * FROM MasterCodeBookTable WHERE SubSystemCode_ShortText24Fld=@ParentCode "

        ' REPORT & ABORT ON ERRORS OR NO RECORDS FOUND
        If NoRecordFound() Then
            '   SavedCode does not exist, missing link
            CurrentSubSystemCode = ParentCode
            CurrentSubSystemName = "missing link"
            MsgBox(CurrentSubSystemCode & "allow adding missing link")
            If Not SuccessfullyAddingThisMasterCodeBookRecord() Then
                MsgBox("UNSECCESSFULL INSERT!!!! Of missing link record")
            End If

            MsgBox("missing link record inserted")

            Exit Sub
        End If

        ' GET FIRST ROW FOUND
        Dim r As DataRow = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)

        ' Update Parent header values here 
        SubSystemCodeDataGridView.Columns("SubSystemCode_ShortText24Fld").HeaderText = r("SubSystemCode_ShortText24Fld")
        SubSystemCodeDataGridView.Columns("SystemDesc_ShortText100Fld").HeaderText = r("SystemDesc_ShortText100Fld")
        CurrentParentName = r("SystemDesc_ShortText100Fld")

    End Sub
    Private Sub FillSystemInfoHeadersDataGridView()
        SystemInfoHeadersFieldsToSelect = " Select SystemInfoHeadersTable.SystemInfoHeadersID_AutoNumber, " &
                                                   " SystemInfoHeadersTable.MasterCodeBookId_LongInteger, " &
                                                   " SystemInfoHeadersTable.InformationsHeaderID_LongInteger, " &
                                                   " SystemInfoHeadersTable.InfoPerVehicleID_LongInteger, " &
                                                   " MasterCodeBookTable.SubSystemCode_ShortText24Fld, " &
                                                   " MasterCodeBookTable.SystemDesc_ShortText100Fld, " &
                                                   " InformationsHeadersTable.InformationsHeaderCode_ShortText30, " &
                                                   " InformationsHeadersTable.InformationsHeaderDescription_ShortText255, " &
                                                   " InfoPerVehicleTable.FileName_ShortText255 "

        SystemInfoHeadersTablesLinks = " FROM((SystemInfoHeadersTable LEFT JOIN MasterCodeBookTable ON SystemInfoHeadersTable.MasterCodeBookId_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) LEFT JOIN InformationsHeadersTable On SystemInfoHeadersTable.[InformationsHeaderID_LongInteger] = InformationsHeadersTable.[InformationsHeaderID_AutoNumber]) LEFT JOIN InfoPerVehicleTable On SystemInfoHeadersTable.InformationsHeaderID_LongInteger = InfoPerVehicleTable.InfoPerVehicleID_AutoNumber "

        SystemInfoHeadersSelectionFilter = " WHERE SystemInfoHeadersTable.MasterCodeBookId_LongInteger = " & CurrentMasterCodeBookSubSystemID
        SystemInfoHeadersSelectionOrder = " ORDER BY InformationsHeaderCode_ShortText30 ASC "

        MySelection = SystemInfoHeadersFieldsToSelect & SystemInfoHeadersTablesLinks & SystemInfoHeadersSelectionFilter & SystemInfoHeadersSelectionOrder

        JustExecuteMySelection()

        SystemInfoHeadersRecordCount = RecordCount
        SystemInfoHeadersDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        ' Initialize InformationsHeadersCodeBookDataGridView
        SystemInfoHeadersDataGridView.Columns.Item("SystemInfoHeadersID_AutoNumber").Visible = False
        SystemInfoHeadersDataGridView.Columns.Item("MasterCodeBookId_LongInteger").Visible = False
        SystemInfoHeadersDataGridView.Columns.Item("InformationsHeaderID_LongInteger").Visible = False
        SystemInfoHeadersDataGridView.Columns.Item("InfoPerVehicleID_LongInteger").Visible = False
        SystemInfoHeadersDataGridView.Columns.Item("SubSystemCode_ShortText24Fld").Visible = False
        SystemInfoHeadersDataGridView.Columns.Item("SystemDesc_ShortText100Fld").Visible = False

        SystemInfoHeadersDataGridView.Columns.Item("InformationsHeaderCode_ShortText30").HeaderText = CurrentSubSystemCode
        SystemInfoHeadersDataGridView.Columns.Item("InformationsHeaderCode_ShortText30").Width = 20 * 184 / 15

        SystemInfoHeadersDataGridView.Columns.Item("InformationsHeaderDescription_ShortText255").HeaderText = CurrentSubSystemName
        SystemInfoHeadersDataGridView.Columns.Item("InformationsHeaderDescription_ShortText255").Width = 100 * 184 / 15

        SystemInfoHeadersDataGridView.Width = 0
        For i = 0 To SystemInfoHeadersDataGridView.Columns.GetColumnCount(0) - 1
            If SystemInfoHeadersDataGridView.Columns.Item(i).Visible = True Then
                SystemInfoHeadersDataGridView.Width = SystemInfoHeadersDataGridView.Width + SystemInfoHeadersDataGridView.Columns.Item(i).Width
            End If
        Next
        SystemInfoHeadersDataGridView.Width = SystemInfoHeadersDataGridView.Width + 20
    End Sub



    Private Sub SubSystemCodeDataGridView_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles SubSystemCodeDataGridView.RowHeaderMouseDoubleClick
        '     Tunnel1 = Trim(SubSystemCodeDataGridView"MasterCodeBookID_Autonumber", e.RowIndex).Value)
        Tunnel1 = Val(SubSystemCodeDataGridView.Item("MasterCodeBookID_Autonumber", e.RowIndex).Value)
        Tunnel2 = "Tunnel1IsMasterCode"
        Select Case ActivatedBy.Text
            Case "ConcernsForm"
                ConcernsForm.ConcernTextBox.Text = SubSystemCodeDataGridView.Item("SystemDesc_ShortText100Fld", e.RowIndex).Value
            Case Else
                Dim xxx = 1
        End Select
        Me.Close()
    End Sub
    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddMasterCodeToolStripMenuItem.Click
        PurposeOfMasterCodeBookDetailsGroupEntry = "ADD"
        ' Shows the details editing group box and enables edit to the fields
        ' All DataGridViews are disabled
        ' Searching is disable
        CurrentSubSystemCodeBookID = -1
        MasterCodeBookDetailsGroup.Text = "Add a New Sub CODE"
        EnableModifyMasterCodeBookMode()          '' Add Edit Delete are turned off and Cancel ans Save options are made available
        SearchMasterCodeBookTextBox.Visible = False
        InformationsToolStripLabel.Visible = False
        AddSystemInfoHeadersToolStripMenuItem.Visible = False
        DetermineParentInfos()
        ParentSystemNameLabel.Text = CurrentParentName
        MainSystemPrefixLabel.Text = CurrentParentCode & "-"
        ChildSystemNameLabel.Text = CurrentSubSystemName
        SubSystemPrefixLabel.Text = CurrentSubSystemCode & "-"
        SystemNameTextBox.Enabled = False

    End Sub
    Private Sub DetermineParentInfos()
        CurrentParentCode = Mid(CurrentSubSystemCode, 1, Len(Trim(CurrentSubSystemCode)) - 2)
        If Len(Trim(CurrentParentCode)) = 2 Then
            CurrentParentName = CurrentMainSystemName
        End If

        Dim ParentFieldToSearch = "Mid(SubSystemCode_ShortText24Fld,1," & Str(Len(Trim(CurrentSubSystemCode)) - 2) & ")"
        Dim ParentSearchKey = ParentFieldToSearch & " = " & Chr(34) & CurrentParentCode & Chr(34)
        Dim ParentKeyLength = " And Len(Trim(SubSystemCode_ShortText24Fld)) = " & Str(Len(Trim(CurrentSubSystemCode)) - 2)
        SubSystemCodeSelectionFilter = " where " & ParentSearchKey & ParentKeyLength
        MySelection = "Select * from MasterCodebookTable " & SubSystemCodeSelectionFilter
        If NoRecordFound() Then
            Exit Sub
        End If
        Dim r As DataRow = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        CurrentParentName = r("SystemDesc_ShortText100Fld")
    End Sub


    Private Sub DeleteTMasterCodeoolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteMasterCodeToolStripMenuItem.Click
        PurposeOfMasterCodeBookDetailsGroupEntry = "DELETE"

        If Not MsgBox("Do you want To Continue deleting this RECORD ?", vbYesNo) = vbYes Then
        Else
            MySelection = "DELETE FROM MasterCodeBookTable WHERE MasterCodeBookID_Autonumber = " & Str(CurrentMasterCodeBookSubSystemID)
            JustExecuteMySelection()
        End If
        FillSubSystemDataGridView()
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditTMasterCodeToolStripMenuItem.Click
        PurposeOfMasterCodeBookDetailsGroupEntry = "EDIT"
        ShowMasterCodeBookDetailsGroup()

    End Sub
    Private Sub ShowMasterCodeBookDetailsGroup()
        MasterCodeBookDetailsGroup.Visible = True
        Select Case PurposeOfMasterCodeBookDetailsGroupEntry
            Case "ADD"
                ParentSystemCodeTextBox.Text = "Next SubCode"
                ChildSystemCodeTextBox.Text = "Next SubCode"
                SystemNameTextBox.Text = ""
            Case "EDIT"
                ChildSystemCodeTextBox.Enabled = False
                ParentSystemCodeTextBox.Enabled = False
                ParentSystemNameLabel.Text = CurrentMainSystemName
                ChildSystemNameLabel.Text = CurrentSubSystemName
                ParentSystemCodeTextBox.Text = CurrentMainSystemCode
                ChildSystemCodeTextBox.Text = CurrentSubSystemCode
                SystemNameTextBox.Text = CurrentSubSystemName
                Exit Sub

            Case Else
                MsgBox("Break Program Here")
        End Select
    End Sub
    Private Sub MasterCodeBookDetailsGroup_VisibleChanged(sender As Object, e As EventArgs) Handles MasterCodeBookDetailsGroup.VisibleChanged
        If MasterCodeBookDetailsGroup.Visible = True Then
            DisableAddEditDeleteMasterCodeMenuItems()
        Else
            EnableAddEditDeleteMasterCodeMenuItems()
        End If

    End Sub

    Private Sub EnableModifyMasterCodeBookMode()
        DisableAddEditDeleteMasterCodeMenuItems()
        MainSystemCodeDataGridView.Enabled = False
        SubSystemCodeDataGridView.Enabled = False
        ShowMasterCodeBookDetailsGroup()
    End Sub
    Private Sub DisAbleModifyMasterCodeBookMode()
        EnableAddEditDeleteMasterCodeMenuItems()
        MasterCodeBookDetailsGroup.Visible = False
        MainSystemCodeDataGridView.Enabled = True
        SubSystemCodeDataGridView.Enabled = True
    End Sub
    Private Sub EnableAddEditDeleteMasterCodeMenuItems()
        SelectMasterCodeToolStripMenuItem.Visible = True
        SaveMasterCodeToolStripMenuItem.Visible = False
        AddMasterCodeToolStripMenuItem.Visible = True
        EditTMasterCodeToolStripMenuItem.Visible = True
        CreateInfoPerVehicleDetailsToolStripMenuItem.Visible = True
        DeleteMasterCodeToolStripMenuItem.Visible = True
        SearchMasterCodeBookTextBox.Visible = True

    End Sub
    Private Sub DisableAddEditDeleteMasterCodeMenuItems()
        SaveMasterCodeToolStripMenuItem.Visible = True
        SelectMasterCodeToolStripMenuItem.Visible = False
        AddMasterCodeToolStripMenuItem.Visible = False
        EditTMasterCodeToolStripMenuItem.Visible = False
        CreateInfoPerVehicleDetailsToolStripMenuItem.Visible = False
        DeleteMasterCodeToolStripMenuItem.Visible = False
        SearchMasterCodeBookTextBox.Visible = False
    End Sub

    Private Sub SearchCodeBookTextBox_Click(sender As Object, e As EventArgs) Handles SearchMasterCodeBookTextBox.TextChanged
        SearchIsOnFlag = True
        If Trim(SearchMasterCodeBookTextBox.Text) = "" Then Exit Sub
        If Trim(SearchMasterCodeBookTextBox.Text) = "Search" Then Exit Sub
        Dim FindKey As String = Trim(SearchMasterCodeBookTextBox.Text)

        RecordFinderDbControls.AddParam("@FindKey", "%" & FindKey & "%")
        Dim SavedSubSystemCodeSelectionFilter = SubSystemCodeSelectionFilter

        SubSystemCodeSelectionFilter = "  WHERE SystemDesc_ShortText100Fld Like @FindKey "

        MySelection = SubSystemCodeFieldsToSelect & SubSystemCodeTablesLinks & SubSystemCodeSelectionFilter & SubSystemCodeSelectionOrder

        JustExecuteMySelection()
        SubSystemCodeDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        SubSystemCodeSelectionFilter = SavedSubSystemCodeSelectionFilter

    End Sub

    Private Sub SearchCodeBookTextBox_MouseClick(sender As Object, e As MouseEventArgs) Handles SearchMasterCodeBookTextBox.Click
        If SearchMasterCodeBookTextBox.Text = "Search" Then SearchMasterCodeBookTextBox.Text = ""
        SearchMasterCodeBookTextBox.SelectAll()

    End Sub

    Private Sub FindSubCodeSelected()
        ' you may use select and refresh here
        If SubSystemCodeDataGridView.Rows.Count = 0 Then
            Exit Sub
        End If
        FillSubSystemDataGridView()
        '       SubSystemCodeDataGridView.Rows(0).Selected = True
        Dim CurrentIndex = 0
        '     Dim whatisthecode = SubSystemCodeDataGridView(0, CurrentIndex).Value
        If SubSystemCodeDataGridView.Rows.Count > 1 Then
            SubSystemCodeDataGridView.Rows(CurrentIndex).Selected = False

            For Each row In SubSystemCodeDataGridView.Rows
                If CurrentSubSystemCode = SubSystemCodeDataGridView(0, CurrentIndex).Value Then

                    SubSystemCodeDataGridView(0, CurrentIndex).Value = CurrentSubSystemCode
                    SubSystemCodeDataGridView.Rows(CurrentIndex).Selected = True
                    '                      SendKeys.Send("{DOWN}")
                    '                      SendKeys.Send("{up}")
                    Exit Sub
                End If
                CurrentIndex = CurrentIndex + 1

            Next
        End If
        SubSystemCodeDataGridView.Refresh()

    End Sub

    Private Sub originalFindSubCodeSelected(SavedCode)
        FillSubSystemDataGridView()
        SubSystemCodeDataGridView.Rows(0).Selected = True
        Dim CurrentIndex = 0
        Dim whatisthecode = SubSystemCodeDataGridView(0, CurrentIndex).Value
        Dim Exception = ""
        Try
            Do While Not SavedCode = whatisthecode
                SubSystemCodeDataGridView.Select()
                SubSystemCodeDataGridView.Rows(CurrentIndex).Selected = True
                SendKeys.Send("{DOWN}")
                CurrentIndex = CurrentIndex + 1
                whatisthecode = SubSystemCodeDataGridView(0, CurrentIndex).Value
            Loop
        Catch ex As Exception
            Exception = ex.Message
            MsgBox(Exception)
            MsgBox("Do a break here, To check why")
            Exit Sub
        End Try

    End Sub
    Private Sub UpButton_Click(sender As Object, e As EventArgs) Handles UpButton.Click
        If Len(CurrentSubSystemCode) = 4 Then Exit Sub
        CurrentSubSystemCode = Mid(CurrentSubSystemCode, 1, Len(CurrentSubSystemCode) - 2)

        FindSubCodeSelected()

    End Sub

    Private Sub SystemInfoHeadersTableDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles SystemInfoHeadersDataGridView.RowEnter
        If e.RowIndex < 0 Then
            Exit Sub
        End If

        If Not SystemInfoHeadersDataGridViewInitialized Then
            SystemInfoHeadersDataGridViewInitialized = True
        End If

        InfoDetailsTextBox.Text = ""
        CurrentSystemInfoHeaderRow = e.RowIndex
        CurrentSystemInfoHeaderID = SystemInfoHeadersDataGridView("SystemInfoHeadersID_AutoNumber", CurrentSystemInfoHeaderRow).Value
        Dim InformationHeaderID = SystemInfoHeadersDataGridView("InformationsHeaderID_LongInteger", CurrentSystemInfoHeaderRow).Value
        Dim FileName = SystemInfoHeadersDataGridView.Item("InformationsHeaderDescription_ShortText255", CurrentSystemInfoHeaderRow).Value

        ProcedureName = Str(1000 + CurrentVehicleRepairID).Substring(2) & (10000 + Val(InformationHeaderID)).ToString & FileName
        ProcedureName = Replace(ProcedureName, "/", "")
        Dim OldFormatExcelFileName = DefaultProcedurePath & ProcedureName & ".xlsx"
        ExcelFileName = DefaultProcedurePath & ProcedureName & ".xlsx"
        If SystemInfoHeadersDataGridView.Item("InfoPerVehicleID_LongInteger", CurrentSystemInfoHeaderRow).Value > 0 Then
            ExcelFileName = DefaultProcedurePath & ProcedureName & ".xlsx"
            ProcedureExists = Dir(ExcelFileName, vbHidden)
        Else
            ProcedureExists = Dir(OldFormatExcelFileName, vbHidden)
        End If
        '---------------------------------------------------------------------------
        ' *********    DETERMINE PROCEDURE EXCELL FILE RELATED TO THE CURRENT CurrentSubSystemCode EXISTS

        If ProcedureExists = "" Then

            ' *********     try the filename with text if exist

            Dim ExcelFileNameAll = DefaultProcedurePath & ProcedureName & " *.xlsx"


            ProcedureExists = Dir(ExcelFileNameAll, vbHidden)
            If CurrentVehicleRepairID > 0 Then                                        ' If the vehicle model is not set creation and opening of procedures are not provided
                ' and no deletion of child is allowed
                CreateInfoPerVehicleDetailsToolStripMenuItem.Visible = True

                ' *********                                                             IF EXISTS ALLOW OPENING ELSE ALLOW CREATE

                If Not ProcedureExists = "" Then
                    CreateInfoPerVehicleDetailsToolStripMenuItem.Text = "Open Informations"
                Else
                    CreateInfoPerVehicleDetailsToolStripMenuItem.Text = "CREATE Informations"
                End If

                ' *********                                                             IF EXISTS ALLOW OPENING ELSE ALLOW CREATE

            Else
                CreateInfoPerVehicleDetailsToolStripMenuItem.Text = ""
            End If
        Else
            If Not ProcedureExists = "" Then
                OpenInfoDetailFile(ExcelFileName)
                CreateInfoPerVehicleDetailsToolStripMenuItem.Text = "Open Informations"

            Else

                CreateInfoPerVehicleDetailsToolStripMenuItem.Text = "CREATE Informations"
            End If

            ' *********                                                                 IF EXISTS ALLOW OPENING ELSE ALLOW CREATE ENDS

        End If
        ' *********                                                                     DETERMINES PROCEDURE EXCELL FILE RELATED TO THE CURRENT CurrentSubSystemCode ENDS

        If Len(Trim(CurrentSubSystemCode)) = 2 Then
            CurrentParentCode = CurrentMainSystemCode
        Else
            CurrentParentCode = CurrentSubSystemCode
        End If

        ' *********     HANDLES ENABLING THE OPTION TO DELETE THE RECORD

        If ProcedureExists = "" Then
            DeleteMasterCodeToolStripMenuItem.Visible = True                            '   CAN DELETE IF NO PROCEDURE OR InfoPerVehicle LINKED EXISTS
        Else
            ExcelFileName = DefaultProcedurePath & ProcedureExists
            DeleteMasterCodeToolStripMenuItem.Visible = False
        End If

        ' *********     HANDLES ENABLING THE OPTION TO DELETE THE RECORD ends   

    End Sub



    Private Sub MasterCodeBookForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        'Fills up tunnel1, tunnel2
        'Enables calling form

        Select Case ActivatedBy.Text
            Case "VehicleManagementSystemForm"
                VehicleManagementSystemForm.Enabled = True
                VehicleManagementSystemForm.Show()
            Case "ConcernsForm"
                Tunnel2 = "Tunnel1IsMasterCode"
                ConcernsForm.Enabled = True
                ConcernsForm.Show()

        End Select
        ActivatedBy.Text = ""
        ResetTunnels()

    End Sub

    Private Sub MasterCodeBookForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        If Me.Enabled = False Then
            Exit Sub
        End If

        Select Case CalledFormName
            Case "VehicleDetailsForm"
                'this portion accepts the code requested
                'coderequested is set by showform routine of the calling form
                If IsEmpty(Tunnel2) Then
                    Exit Sub
                End If

                If Tunnel2 > -1 Then
                    CurrentVehicleCode = Tunnel2
                    CurrentVehicleRepairID = Tunnel3
                    MySelection = "Select * from VehicleRepairClassTable WHERE VehicleRepairClassID_AutoNumber = " & Str(CurrentVehicleRepairID)
                    If NoRecordFound() Then
                        MsgBox("break, PROBLEM Not found, Update Vehicle Repair Class code For thid vehicle ")
                        GetDefaultVehicle()
                        Exit Sub
                    End If
                    Dim r As DataRow = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
                    Tunnel1 = r("YearManufacturedFrom_ShortText4")

                    DefaultVehicleModelRepairRangeTextBox.Text = " Years " & r("YearManufacturedFrom_ShortText4") & " To " & r("YearManufacturedTo_ShortText4")
                End If

            Case "InformationsHeadersForm"
                ' check if vehicle and header information already exist

                Dim SavedSystemInfoHeadersSelectionFilter = SystemInfoHeadersSelectionFilter


                Dim SystemInfoHeadersSelectionFilter1 = " MasterCodeBookId_LongInteger = " & CurrentMasterCodeBookSubSystemID.ToString
                Dim SystemInfoHeadersSelectionFilter2 = " InfoPerVehicleID_LongInteger = " & CurrentVehicleRepairID.ToString
                Dim SystemInfoHeadersSelectionFilter3 = " InformationsHeaderID_LongInteger = " & Tunnel1.ToString

                SystemInfoHeadersSelectionFilter = " WHERE " & SystemInfoHeadersSelectionFilter1 & " And " &
                                                                 SystemInfoHeadersSelectionFilter2 & " And " &
                                                                 SystemInfoHeadersSelectionFilter3

                MySelection = " sELECT * FROM SystemInfoHeadersTable " &
                              SystemInfoHeadersSelectionFilter

                JustExecuteMySelection()
                If RecordCount = 0 Then
                    InsertANewSystemInfoHeaders(Tunnel1)
                End If

                SystemInfoHeadersSelectionFilter = SavedSystemInfoHeadersSelectionFilter
                FillSystemInfoHeadersDataGridView()
        End Select
        ResetTunnels() ' INFORMATION IN TUNNELS HAVE BEEN RECEIVED

    End Sub
    Private Sub InsertANewInfoPerVehicleTable()
        MySelection = " Select top 1 * FROM InfoPerVehicleTable WHERE SystemInfoHeadersID_LongInteger = " & CurrentSystemInfoHeaderID.ToString &
                                                                " And VehicleRepairClassID_LongInteger = " & CurrentVehicleRepairID.ToString

        JustExecuteMySelection()
        If RecordCount > 0 Then
            MsgBox("Selected Information already attached ")
            Exit Sub
        End If

        Dim FieldsToUpdate = " ( " &
                    " SystemInfoHeadersID_LongInteger, " &
                    " VehicleRepairClassID_LongInteger, " &
                    " FileName_ShortText255" & ")"


        Dim ReplacementData = "(" &
                    CurrentSystemInfoHeaderID.ToString & ", " &
                    CurrentVehicleRepairID.ToString & ", " &
                    Chr(34) & ProcedureName & Chr(34) & ")"


        MySelection = "INSERT INTO InfoPerVehicleTable  " & FieldsToUpdate & " VALUES " & ReplacementData

        JustExecuteMySelection()


    End Sub
    Private Sub InsertANewSystemInfoHeaders(InformationsHeaderID_LongInteger)

        Dim FieldsToUpdate = " ( " &
                    " MasterCodeBookId_LongInteger, " &
                    " InformationsHeaderID_LongInteger, " &
                    " InfoPerVehicleID_LongInteger " & ")"


        Dim ReplacementData = "(" &
                    CurrentMasterCodeBookSubSystemID.ToString & ", " &
                    InformationsHeaderID_LongInteger.ToString & ", " &
                    CurrentVehicleRepairID.ToString & ")"


        MySelection = "INSERT INTO SystemInfoHeadersTable  " & FieldsToUpdate & " VALUES " & ReplacementData

        JustExecuteMySelection()

        FillSystemInfoHeadersDataGridView()
    End Sub

    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click

        If RenumberGroupBox.Visible = True Then
            RenumberGroupBox.Visible = False
            EnableAddEditDeleteMasterCodeMenuItems()
            MainSystemCodeDataGridView.Enabled = True
            SubSystemCodeDataGridView.Enabled = True
            InformationsHeadersGroupBox.Enabled = True
            Exit Sub
        End If
        Select Case MasterCodeBookDetailsGroup.Visible
            Case True
                Dim FieldChangeOccured = False

                '             If SavedMyStandardName <> MyStandardNameTextBox.Text Then
                '            FieldChangeOccured = True
                '           End If
                '           If SavedMyStandardDate <> MyStandardDateDateTimeTextBox.Text Then
                '           FieldChangeOccured = True
                '        End If
                '           If FieldChangeOccured Then
                '           If Not MsgBox("Do you want To discard changes ?", vbYesNo) = vbYes Then
                '         Exit Sub
                '          End If
                '           End If
                ParentSystemCodeTextBox.Enabled = True
                ChildSystemCodeTextBox.Enabled = True
                DisAbleModifyMasterCodeBookMode()
            Case Else
                '           Tunnel1 = -1
                Me.Close()
        End Select
    End Sub

    Private Sub MainSystemCodeTextBox_TextChanged(sender As Object, e As EventArgs) Handles ParentSystemCodeTextBox.Click
        Select Case ChildSystemCodeTextBox.Text
            Case = ""
                ChildSystemCodeTextBox.Text = "Next SubCode"
            Case <> "Next SubCode"

                If MsgBox("A New code exists In the Child Code, Do you want To update the Main Code ?", vbYesNo) = vbYes Then
                    ChildSystemCodeTextBox.Text = "Next SubCode"
                    ParentSystemCodeTextBox.Text = ""
                Else
                    ChildSystemCodeTextBox.Select()
                    Exit Sub
                End If
        End Select
        ParentSystemCodeTextBox.Select()
        If ParentSystemCodeTextBox.Text = "Next SubCode" Or ParentSystemCodeTextBox.Text = "" Then
            ParentSystemCodeTextBox.Text = GetNextAvailableCode(CurrentParentCode)
            ChildSystemCodeTextBox.Enabled = False
            SystemNameTextBox.Enabled = True
            SystemNameTextBox.Select()
        End If
    End Sub
    Private Sub SubSystemTextBox_TextChanged(sender As Object, e As EventArgs) Handles ChildSystemCodeTextBox.Click
        Select Case ParentSystemCodeTextBox.Text
            Case = ""
                ParentSystemCodeTextBox.Text = "Next SubCode"
            Case <> "Next SubCode"

                If MsgBox("A New code exists In the Parent Code, oo you want To update the Child Code ?", vbYesNo) = vbYes Then
                    ParentSystemCodeTextBox.Text = "Next SubCode"
                    ChildSystemCodeTextBox.Text = ""
                Else
                    ParentSystemCodeTextBox.Select()
                    Exit Sub
                End If
        End Select
        ChildSystemCodeTextBox.Select()
        If ChildSystemCodeTextBox.Text = "Next SubCode" Or ChildSystemCodeTextBox.Text = "" Then
            ChildSystemCodeTextBox.Text = GetNextAvailableCode(CurrentSubSystemCode)
            ParentSystemCodeTextBox.Enabled = False
            SystemNameTextBox.Enabled = True
            SystemNameTextBox.Select()
        End If
    End Sub
    Private Function GetNextAvailableCode(AffixCode As String)
        Dim NewCode = ""
        Dim NewSearchCode = ""
        For i = 101 To 199
            NewCode = Mid(i, 2, 2)
            NewSearchCode = AffixCode & NewCode
            Dim ParentFieldToSearch = "Mid(SubSystemCode_ShortText24Fld,1," & Str(Len(Trim(AffixCode)) + 2) & ")"
            Dim ParentSearchKey = ParentFieldToSearch & " = " & Chr(34) & NewSearchCode & Chr(34)
            Dim ParentKeyLength = " And Len(Trim(SubSystemCode_ShortText24Fld)) = " & Str(Len(Trim(NewSearchCode)))
            SubSystemCodeSelectionFilter = " where " & ParentSearchKey & ParentKeyLength
            MySelection = "Select * from MasterCodebookTable " & SubSystemCodeSelectionFilter
            If NoRecordFound() Then
                Return NewCode
            End If
        Next i

        Return NewCode

    End Function

    Private Sub ParentSystemCodeTextBox_TextChanged(sender As Object, e As EventArgs) Handles ParentSystemCodeTextBox.TextChanged
        If PurposeOfMasterCodeBookDetailsGroupEntry = "EDIT" Then Exit Sub
        If ParentSystemCodeTextBox.Text = "" Then Exit Sub
        If ParentSystemCodeTextBox.Text = "Next SubCode" Then Exit Sub
        If Mid(ParentSystemCodeTextBox.Text, 1, 1) < "0" Or Mid(ParentSystemCodeTextBox.Text, 1, 1) > "9" Then ParentSystemCodeTextBox.Text = "" : Exit Sub
        If Len(Trim(ParentSystemCodeTextBox.Text)) > 2 Then ParentSystemCodeTextBox.Text = Mid(ParentSystemCodeTextBox.Text, 1, 2) : Exit Sub
        If Len(Trim(ParentSystemCodeTextBox.Text)) = 2 Then
            If Mid(ParentSystemCodeTextBox.Text, 2, 1) < "0" Or Mid(ParentSystemCodeTextBox.Text, 2, 1) > "9" Then ParentSystemCodeTextBox.Text = "" : Exit Sub
            If ThisCodeAlreadyExists(CurrentParentCode & ParentSystemCodeTextBox.Text) Then
                MsgBox("this code already exist As " & Tunnel1)
                ParentSystemCodeTextBox.Text = ""
                Tunnel1 = ""
            Else
                SystemNameTextBox.Text = ""
                SystemNameTextBox.Select()
            End If
        End If
    End Sub
    Private Sub ChildSystemCodeTextBox_TextChanged(sender As Object, e As EventArgs) Handles ChildSystemCodeTextBox.TextChanged
        If PurposeOfMasterCodeBookDetailsGroupEntry = "EDIT" Then Exit Sub
        If ChildSystemCodeTextBox.Text = "" Then Exit Sub
        If ChildSystemCodeTextBox.Text = "Next SubCode" Then Exit Sub
        If ChildSystemCodeTextBox.Text < "0" Then ChildSystemCodeTextBox.Text = "" : Exit Sub
        If ChildSystemCodeTextBox.Text > "99" Then ChildSystemCodeTextBox.Text = "" : Exit Sub
        If Len(Trim(ChildSystemCodeTextBox.Text)) > 2 Then ChildSystemCodeTextBox.Text = Mid(ChildSystemCodeTextBox.Text, 1, 2) : Exit Sub
        If Len(Trim(ChildSystemCodeTextBox.Text)) = 2 Then
            If ThisCodeAlreadyExists(CurrentSubSystemCode & ChildSystemCodeTextBox.Text) Then
                MsgBox("this code already exist As " & Tunnel1)
                ChildSystemCodeTextBox.Text = ""
                Tunnel1 = ""
            End If
            SystemNameTextBox.Text = ""
            SystemNameTextBox.Select()
        End If

    End Sub
    Private Function ThisCodeAlreadyExists(CurrentParentCode)
        CurrentSubSystemCode = CurrentParentCode
        Dim ParentFieldToSearch = "Mid(SubSystemCode_ShortText24Fld,1," & Str(Len(Trim(CurrentParentCode)) + 2) & ")"
        Dim ParentSearchKey = ParentFieldToSearch & " = " & Chr(34) & CurrentSubSystemCode & Chr(34)
        Dim ParentKeyLength = " And Len(Trim(SubSystemCode_ShortText24Fld)) = " & Str(Len(Trim(CurrentSubSystemCode)))
        SubSystemCodeSelectionFilter = " where " & ParentSearchKey & ParentKeyLength
        MySelection = "Select * from MasterCodebookTable " & SubSystemCodeSelectionFilter
        If NoRecordFound() Then
            Return False
        End If
        Dim r As DataRow = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        Tunnel1 = r("SystemDesc_ShortText100Fld")

        Return True

    End Function

    Private Sub SaveMasterCodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveMasterCodeToolStripMenuItem.Click
        SystemNameTextBox.Text = LTrim(SystemNameTextBox.Text.ToUpper)
        ParentSystemCodeTextBox.Enabled = True
        ChildSystemCodeTextBox.Enabled = True
        If ParentSystemCodeTextBox.Text = "Next SubCode" Then
            If ChildSystemCodeTextBox.Text = "Next SubCode" Then Exit Sub
            If Len(Trim(ChildSystemCodeTextBox.Text)) = 1 Then
                MsgBox("Invalid Child Code")
                ChildSystemCodeTextBox.Select()
                Exit Sub
            End If
        Else

            ' here ChildSystemCodeTextBox.Text = "Next SubCode" is not needed there is a toggle off ech to be "Next SubCode"

            If Len(Trim(ParentSystemCodeTextBox.Text)) = 1 Then
                MsgBox("Invalid Parent Code")
                ParentSystemCodeTextBox.Select()
                Exit Sub
            End If
        End If

        SaveCurrentFieldContents()

    End Sub
    Private Sub SaveCurrentFieldContents()

        Select Case PurposeOfMasterCodeBookDetailsGroupEntry
            Case "ADD"
                If SystemNameTextBox.Text = "" Then SystemNameTextBox.Select() : Exit Sub
                CurrentSubSystemName = SystemNameTextBox.Text

                If Not MsgBox(" Confirm adding New code " & CurrentSubSystemCode & "-" & CurrentSubSystemName, vbYesNo) = vbYes Then
                    Exit Sub
                End If

                If Not SuccessfullyAddingThisMasterCodeBookRecord() Then
                    MsgBox("UNSECCESSFULL INSERT!!!!")
                    Exit Sub
                End If
            Case "EDIT"
                If Trim(SystemNameTextBox.Text) = "" Then
                    SystemNameTextBox.Text = CurrentSubSystemName
                    SystemNameTextBox.Select()
                    Exit Sub
                End If

                If SystemNameTextBox.Text = CurrentSubSystemName Then
                    SystemNameTextBox.Select()
                    Exit Sub
                End If
                If Not MsgBox(" Confirm Saving changes For " & CurrentSubSystemName & " To " & SystemNameTextBox.Text, vbYesNo) = vbYes Then
                    SystemNameTextBox.Select()
                    Exit Sub
                End If

                Dim RecordFilter = " WHERE MasterCodeBookID_Autonumber = " & Str(CurrentSubSystemCodeBookID)

                Dim UpdateFieldsToSelect = " UPDATE MasterCodeBookTable  Set SystemDesc_ShortText100Fld  = " & Chr(34) & SystemNameTextBox.Text & Chr(34)

                MySelection = UpdateFieldsToSelect & RecordFilter
                If NoRecordFound() Then Dim dummy = 1

            Case Else
                Dim XXXX = 1
        End Select
        DisAbleModifyMasterCodeBookMode()

        ' test if main system code has been changed here, if changed reset FillMainSystemCodeDataGridView()
        ' test if subsystem hs been change display subsystem display
        '''''''    try this
        ' Children = " (mid(SubSystemCode_ShortText24Fld,1,4) = " & Chr(34) & CurrentMainSystemCode & "01" & Chr(34) & ")"
        '        SavedSubSystemCode = CurrentSubSystemCode
        '        SavedSubSystemDesc = CurrentSubSystemName
        FillSubSystemDataGridView()
        SubSystemCodeDataGridView.Rows(0).Selected = True




        '      CurrentSubSystemCodeRow = e.RowIndex
        CurrentSubSystemName = Trim(SubSystemCodeDataGridView.Item(CurrentSubCodeColumn + 1, CurrentSubSystemCodeRow).Value)
        CurrentSubSystemCode = LTrim(RTrim(SubSystemCodeDataGridView.Item(0, CurrentSubSystemCodeRow).Value))
        CurrentSubSystemCodeBookID = Val(LTrim(RTrim(SubSystemCodeDataGridView.Item("MasterCodeBookID_Autonumber", CurrentSubSystemCodeRow).Value)))
        If Len(Trim(CurrentSubSystemCode)) = 2 Then
            CurrentParentCode = CurrentMainSystemCode
        Else
            CurrentParentCode = CurrentSubSystemCode
        End If
        FillSystemInfoHeadersDataGridView()



    End Sub

    Private Function SuccessfullyAddingThisMasterCodeBookRecord()

        '  = "2" for subsystem "1" for Main code 3" For parts M- Maintenance  P-Parts

        MasterCodeBookFieldsToReplace = "" &
            "MainSystemCode_ShortText1, " &
            "SubSystemCode_ShortText24Fld, " &
            "SystemDesc_ShortText100Fld "

        MasterCodeBookFieldsValues = "" &
            Chr(34) & "2" & Chr(34) & ", " &
            Chr(34) & CurrentSubSystemCode & Chr(34) & ", " &
            Chr(34) & CurrentSubSystemName.ToUpper & Chr(34)

        MySelection = "INSERT INTO MasterCodeBookTable  (" & MasterCodeBookFieldsToReplace & ") VALUES (" & MasterCodeBookFieldsValues & ")"

        JustExecuteMySelection()

        MySelection = "SELECT * FROM MasterCodeBookTable  WHERE TRIM(SubSystemCode_ShortText24Fld) = " & Chr(34) & CurrentSubSystemCode & Chr(34)
        If NoRecordFound() Then
            Return False
        End If
        Return True

    End Function

    Private Sub SystemNameTextBox_TextChanged(sender As Object, e As EventArgs) Handles SystemNameTextBox.Click
        If ParentSystemCodeTextBox.Text = "" Then ParentSystemCodeTextBox.Select()
        If ChildSystemCodeTextBox.Text = "" Then ChildSystemCodeTextBox.Select()
        If ParentSystemCodeTextBox.Text = "Next SubCode" And ChildSystemCodeTextBox.Text = "Next SubCode" Then
            ChildSystemCodeTextBox.Select()
            Exit Sub
        End If

    End Sub

    Private Sub CrateProcedureToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateInfoPerVehicleDetailsToolStripMenuItem.Click
        Select Case CreateInfoPerVehicleDetailsToolStripMenuItem.Text
            Case = "CREATE Informations"
                CreateExcelFile()
                OpenExcelFile(True)
                CreateInfoPerVehicleDetailsToolStripMenuItem.Text = "Open Informations"
                DeleteMasterCodeToolStripMenuItem.Visible = False

            Case = "Open Informations"
                ProcedureName = Replace(ProcedureName, "/", "")
                OpenExcelFile(True)
                Exit Sub
        End Select
        Me.Show()
        SystemInfoHeadersDataGridView.Select()
    End Sub

    Private Sub ChangeVehicleDefaults_Click(sender As Object, e As EventArgs) Handles ChangeVehicleDefaults.Click
        GetDefaultVehicle()
    End Sub

    Private Sub GetDefaultVehicle()
        Me.Enabled = False
        VehicleDetailsForm.ActivatedBy.Text = Me.Name
        VehicleDetailsForm.Show()
        CalledFormName = "VehicleDetailsForm"

    End Sub
    Private Sub CreateExcelFile()

        Dim xlApp As excel.Application = New Microsoft.Office.Interop.Excel.Application()

        If xlApp Is Nothing Then
            MessageBox.Show("Excel is not properly installed!!, paki check")
            Return
        End If

        Dim xlWorkBook As excel.Workbook
        Dim xlWorkSheet As excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value
        Dim ExcelFileTemplate = DefaultProcedurePath & "ExcelFileTemplate.xlsx"

        xlWorkBook = xlApp.Workbooks.Open(ExcelFileTemplate)
        '       xlWorkBook = xlApp.Workbooks.Add(misValue)
        xlWorkSheet = xlWorkBook.Sheets("sheet1")
        xlWorkSheet.Cells(1, 1) = DefaultVehicleModelTextBox.Text
        xlWorkSheet.Cells(2, 1) = CurrentParentName & "/" & CurrentSubSystemName
        xlWorkSheet.Cells(3, 1) = "Paste Here"

        xlWorkSheet.Cells(3, 1).select

        Do While xlWorkSheet.Cells(3, 1).value = "Paste Here"

            MsgBox("Please make Sure you already to copied the data then hit any key to proceed")

            '           EXECUTE MACRO FOR DISSECTING THE EXCEL FILE HERE

            InfoDetailsTextBox.Paste()
            InfoDetailsTextBox.Text = Trim(InfoDetailsTextBox.Text)
            InfoDetailsTextBox.Text = Replace(InfoDetailsTextBox.Text, "vbTab & vbTab & vbTab & ", "")
            InfoDetailsTextBox.Text = Replace(InfoDetailsTextBox.Text, "vbCrLf & vbCrLf & ", "")

            Clipboard.SetText(Trim(InfoDetailsTextBox.Text))
            Dim xxxx = Clipboard.GetText

            xlWorkSheet.Cells(3, 1).Select()
            xlWorkSheet.Paste()

            InfoDetailsTextBox.Paste()

            xlWorkSheet.Cells.Select()

            Dim formatRange As excel.Range
            formatRange = xlWorkSheet.Range("a1", "c100")
            '           formatRange.WrapText = False
            '           formatRange.Orientation = 0
            '           formatRange.AddIndent = False
            '           formatRange.ShrinkToFit = False

            With formatRange
                .WrapText = False
                .Orientation = 0
                .AddIndent = False
                .ShrinkToFit = False
                .MergeCells = False
            End With


            With formatRange.Font
                .Size = 14
                .Strikethrough = False
                .Superscript = False
                .Subscript = False
                .OutlineFont = False
                .Shadow = False
                .TintAndShade = 0
            End With
            xlWorkSheet.Cells.Select()
            xlWorkSheet.Cells.EntireRow.AutoFit()
            xlWorkSheet.Cells.EntireColumn.AutoFit()
            formatRange.ColumnWidth = 13.71
            xlWorkSheet.Range("F9").Select()

        Loop



        'CurrentParentName = Replace(CurrentParentName, "/", "-")
        'CurrentSubSystemName = Replace(CurrentSubSystemName, "/", "-")

        'Dim ProcedureName = Str(1000 + CurrentVehicleRepairID).Substring(2) & CurrentSubSystemCode & Space(1) & CurrentParentName & "-" & CurrentSubSystemName

        'ExcelFileName = DefaultProcedurePath & ProcedureName & ".xlsx"

        Dim Exception = ""
        Try
            ' OPEN A CONNECTION
            xlWorkBook.SaveAs(ExcelFileName)
            InsertANewInfoPerVehicleTable()
            InfoDetailsTextBox.Paste()
        Catch ex As Exception
            Exception = ex.Message
            MsgBox(Exception)
            MsgBox("do a break here, to check why")
            Exit Sub
        End Try

        xlWorkBook.Close(True, misValue, misValue)
        '              SendKeys.Send("{CR}")
        Clipboard.SetText(" ")
        Clipboard.Clear()

        xlApp.Quit()
        releaseObject(xlWorkSheet)
        releaseObject(xlWorkBook)
        releaseObject(xlApp)

    End Sub

    Private Sub OpenInfoDetailFile(InfoDetailFile)

        Dim xlApp As excel.Application = New Microsoft.Office.Interop.Excel.Application()

        If xlApp Is Nothing Then
            MessageBox.Show("Excel is not properly installed!!, paki check")
            Return
        End If

        Dim xlWorkBook As excel.Workbook
        Dim xlWorkSheet As excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value
        Dim ExcelFileTemplate = DefaultProcedurePath & "ExcelFileTemplate.xlsx"

        xlWorkBook = xlApp.Workbooks.Open(InfoDetailFile)
        xlWorkSheet = xlWorkBook.Sheets("sheet1")

        xlWorkSheet.Select()
        xlWorkSheet.Cells.Select()
        xlWorkSheet.Cells.Copy()
        '        xlWorkSheet.Copy()
        InfoDetailsTextBox.Paste()
        InfoDetailsTextBox.Text = Trim(InfoDetailsTextBox.Text)
        InfoDetailsTextBox.Text = Replace(InfoDetailsTextBox.Text, "vbTab & vbTab & vbTab & ", "")
        InfoDetailsTextBox.Text = Replace(InfoDetailsTextBox.Text, "vbCrLf & vbCrLf & ", "")

        Clipboard.SetText(" ")
        Clipboard.Clear()

        xlApp.Quit()
        releaseObject(xlWorkSheet)
        releaseObject(xlWorkBook)
        releaseObject(xlApp)

    End Sub
    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub OpenExcelFile(NewlyCreatedFile)
        Dim xlApp As excel.Application = New Microsoft.Office.Interop.Excel.Application()

        If xlApp Is Nothing Then
            MessageBox.Show("Excel is not properly installed!!")
            Return
        End If

        Dim ProcessID As Integer
        Dim NewProcess As Diagnostics.Process
        Dim Exception = ""
        Try
            NewProcess = Diagnostics.Process.Start(ExcelFileName)
        Catch ex As Exception
            Exception = ex.Message
            MsgBox(Exception)
            MsgBox("do a break here, to check why")
            Exit Sub
        End Try
        ProcessID = NewProcess.Id

        Me.Enabled = False
        NewProcess.WaitForExit()
        Dim procEC As Integer = -1

        If NewProcess.HasExited Then
            procEC = NewProcess.ExitCode
            Me.Enabled = True
            Me.Show()
        End If
    End Sub

    Private Sub DefaultVehicleModelTextBox_Click(sender As Object, e As EventArgs) Handles DefaultVehicleModelTextBox.Click
        SetDefaultVehicleModel()
    End Sub
    Private Sub DefaultVehicleModelTextBox_GotFocus(sender As Object, e As EventArgs) Handles DefaultVehicleModelTextBox.GotFocus
        SetDefaultVehicleModel()
    End Sub
    Private Sub SetDefaultVehicleModel()
        If DefaultVehicleModelTextBox.Text = "Set Default Vehicle" Then
            GetDefaultVehicle()
        End If
    End Sub

    Private Sub RenumberToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RenumberToolStripMenuItem.Click

        RenumberGroupBox.Visible = True
        DisableAddEditDeleteMasterCodeMenuItems()
        OldNumberTextBox.Text = CurrentSubSystemCode
        NewNumberTextBox.Text = ""
        MainSystemCodeDataGridView.Enabled = False
        SubSystemCodeDataGridView.Enabled = False

        InformationsHeadersGroupBox.Enabled = False

    End Sub

    Private Sub GoRenumberButton_Click(sender As Object, e As EventArgs) Handles GoRenumberButton.Click
        ' CHECK 1ST IF NEW CODE ALREADY EXIST
        '       SubSystemCode_ShortText24Fld

        Dim RecordFilter = ""
        Dim UpdateFieldsToSelect = ""

        ' check how may records will be affected

        RecordFilter = " WHERE mid(SubSystemCode_ShortText24Fld,1," & Str(Len(Trim(OldNumberTextBox.Text))) & ") = " & Chr(34) & Trim(OldNumberTextBox.Text) & Chr(34)


        ' CHECK THAT THE NEW CODE DOES EXIST


        UpdateFieldsToSelect = " SELECT * from MasterCodeBookTable "

        MySelection = UpdateFieldsToSelect & RecordFilter
        If NoRecordFound() Then Dim dummy = 1
        Dim ThisThese = ""
        Dim ThereIsThereAre = ""
        Dim ARecords = ""
        If RecordCount = 1 Then
            ThisThese = "this record ?"
            ThereIsThereAre = "There is a "
            ARecords = "record"
        Else
            ThisThese = "these records ?"
            ThereIsThereAre = "There are "
            ARecords = "records"
        End If
        ' CHECK HOW MANY InfoPerVehicle WILL BE RENUMBERED
        Dim NoOfConnectedInfoPerVehicle = ""

        ' this is tyemporary to simulate presumed record count using datagridview 
        'fix this

        Dim InfoPerVehicleRecordCount = 0





        If InfoPerVehicleRecordCount > 0 Then
            NoOfConnectedInfoPerVehicle = " AND " & Str(InfoPerVehicleRecordCount) & " related part(s) "
        End If
        If MsgBox(ThereIsThereAre & Str(RecordCount) & ARecords & " found to be renumbered, " & NoOfConnectedInfoPerVehicle & " CONTINUE renumbering " & ThisThese, vbYesNo) = vbNo Then
            Dim xxx = 1
            Exit Sub
        End If
        If Not Mid(NewNumberTextBox.Text, 1, Len(Trim(OldNumberTextBox.Text))) = Trim(OldNumberTextBox.Text) Then
            ' check for records that have the same code, if exists, determine if it is a child of the code to renumber

            RecordFilter = " WHERE mid(SubSystemCode_ShortText24Fld,1," & Str(Len(Trim(NewNumberTextBox.Text))) & ") = " & Chr(34) & Trim(NewNumberTextBox.Text) & Chr(34)


            ' CHECK THAT THE NEW CODE DOES EXIST


            UpdateFieldsToSelect = " SELECT * from MasterCodeBookTable "

            MySelection = UpdateFieldsToSelect & RecordFilter
            If NoRecordFound() Then Dim dummy = 1

            ' TEST IF CODE ALREADY EXISTS

            If RecordCount > 0 Then

                MsgBox("NEWCODE ALREADY EXISTS, FOUND " & Str(RecordCount) & " records")
                ResetMasterCodeBookForm()
                Exit Sub
            End If
            If MsgBox("Are you sure you want to CHANGE CODE " & OldNumberTextBox.Text & " TO " & NewNumberTextBox.Text, vbYesNo) = vbNo Then
                Dim xxx = 1
                Exit Sub
            End If
            RecordFilter = " WHERE mid(SubSystemCode_ShortText24Fld,1," & Str(Len(Trim(OldNumberTextBox.Text))) & ") = " & Chr(34) & Trim(OldNumberTextBox.Text) & Chr(34)

            UpdateFieldsToSelect = " UPDATE MasterCodeBookTable  SET SubSystemCode_ShortText24Fld  = " & "(" & Chr(34) &
                                    Trim(NewNumberTextBox.Text) & Chr(34) & " & Mid(SubSystemCode_ShortText24Fld," & Str(1 + Len(Trim(OldNumberTextBox.Text))) &
                                    "," & Str(100 - Len(Trim(NewNumberTextBox.Text))) & "))"


            MySelection = UpdateFieldsToSelect & RecordFilter
            If NoRecordFound() Then Dim dummy = 1

            ' RENUMBER THE InfoPerVehicle TOO if exist(s)
            If InfoPerVehicleRecordCount > 0 Then

                UpdateFieldsToSelect = " UPDATE InfoPerVehiclePartsTable  SET InfoPerVehicleCode_ShortText20Fld  = " & "(" & Chr(34) &
                                    Trim(NewNumberTextBox.Text) & Chr(34) & " & Mid(InfoPerVehicleCode_ShortText20Fld," & Str(1 + Len(Trim(OldNumberTextBox.Text))) &
                                    "," & Str(100 - Len(Trim(NewNumberTextBox.Text))) & "))"

                RecordFilter = " WHERE mid(InfoPerVehicleCode_ShortText20Fld,1," & Str(Len(Trim(OldNumberTextBox.Text))) & ") = " & Chr(34) & Trim(OldNumberTextBox.Text) & Chr(34)

                MySelection = UpdateFieldsToSelect & RecordFilter
                If NoRecordFound() Then Dim dummy = 1
            End If

            Do While True
                Dim OldExcelFileName = ""
                Dim NewExcelFileName = ""
                Dim OldProcedureName = Str(1000 + CurrentVehicleRepairID).Substring(2) & CurrentSubSystemCode & "*"
                OldExcelFileName = DefaultProcedurePath & OldProcedureName & ".xlsx"
                ProcedureExists = Dir(OldExcelFileName, vbHidden)
                If ProcedureExists = "" Then
                    Exit Do
                End If
                OldExcelFileName = DefaultProcedurePath & ProcedureExists '& ".xlsx"

                Dim NewProcedureName As String = Replace(ProcedureExists, OldNumberTextBox.Text, NewNumberTextBox.Text)
                ProcedureExists = Dir(NewProcedureName, vbHidden)
                If Not ProcedureExists = "" Then
                    MsgBox("Can not rename " & OldProcedureName & ", File " & ProcedureExists & " already exists")
                End If


                NewExcelFileName = DefaultProcedurePath & NewProcedureName
                Dim Exception = ""
                If Len(Trim(NewProcedureName)) > 24 Then
                    MsgBox("WARNING !!!!! BREAK HERE..  TOO LONG CODE IS BEING GENERATED")
                End If

                Try
                    My.Computer.FileSystem.RenameFile(OldExcelFileName, NewProcedureName)
                Catch ex As Exception
                    Exception = ex.Message
                    MsgBox(Exception)
                    MsgBox("do a break here, to check why")
                End Try
            Loop
            ResetMasterCodeBookForm()
            CurrentSubSystemCode = Trim(NewNumberTextBox.Text)
            FindSubCodeSelected()

        Else
            MsgBox("New code exists as a child code, ")
            ' the new code is a child code
            Dim xxccn = 1
        End If

    End Sub
    Private Sub ResetMasterCodeBookForm()
        EnableAddEditDeleteMasterCodeMenuItems()
        MainSystemCodeDataGridView.Enabled = True
        SubSystemCodeDataGridView.Enabled = True
        InformationsHeadersGroupBox.Enabled = True
        RenumberGroupBox.Visible = False

    End Sub
    Private Sub NewNumberTextBox_TextChanged(sender As Object, e As EventArgs) Handles NewNumberTextBox.TextChanged
        NewNumberTextBox.Text = Trim(NewNumberTextBox.Text)
        If NewNumberTextBox.Text = "" Then
            Exit Sub
        End If
        Dim LastKeyedIn = ""
        If Len(Trim(NewNumberTextBox.Text)) = 1 Then
            LastKeyedIn = NewNumberTextBox.Text
        Else
            LastKeyedIn = Mid(NewNumberTextBox.Text, Len(Trim(NewNumberTextBox.Text)), 1)

        End If
        If LastKeyedIn < "0" Or LastKeyedIn > "9" Then

            NewNumberTextBox.Text = Mid(NewNumberTextBox.Text, 1, Len(Trim(NewNumberTextBox.Text)) - 1)
        End If

    End Sub

    Private Sub SubSystemCodeDataGridView_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles SubSystemCodeDataGridView.RowHeaderMouseClick
        FindSubCodeSelected()
    End Sub
    Private Sub IncludeGrandChildrenButton_Click(sender As Object, e As EventArgs) Handles IncludeGrandChildrenButton.Click
        If IncludeGrandChildrenButton.Text = "INCLUDE GRANDCHILDREN" Then
            IncludeGrandChildrenButton.Text = "CHILDREN ONLY"
            IncludeGrandChildren = True
        Else
            IncludeGrandChildrenButton.Text = "INCLUDE GRANDCHILDREN"
            IncludeGrandChildren = False
        End If
        FillSubSystemDataGridView()
        FindSubCodeSelected()
        SubSystemCodeDataGridView.Select()
        SubSystemCodeDataGridView.Rows(CurrentSubSystemCodeRow).Selected = True
    End Sub

    Private Sub AddInfoPerVehicleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddSystemInfoHeadersToolStripMenuItem.Click
        'Tunnels 1, 2 And 3 maybe used input data to the called form. See FORM - event Load

        Me.Enabled = False
        ' some cases may enable the calling form for the called form to automatically display related informations.
        InformationsHeadersForm.ActivatedByTextBox.Text = Me.Name
        ' SystemInfoHeaderForm is called to get an information header for instructions, specifications diagrams etc
        ' record reference should be returned
        Tunnel2 = CurrentSubSystemName
        Tunnel1 = CurrentSubSystemCode
        InformationsHeadersForm.Show()
        CalledFormName = "InformationsHeadersForm"

    End Sub

    Private Sub RemoveSystemInfoHeaderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveSystemInfoHeaderToolStripMenuItem.Click
        ' deletion not allowed if there exists references to files / information in excel file        
        If Not IsEmpty(SystemInfoHeadersDataGridView.Item("FileName_ShortText255", CurrentSystemInfoHeaderRow).Value) Then
            Exit Sub
        End If
        If MsgBox("Do you want to continue deleting this RECORD ?", vbYesNo) = vbYes Then
            MySelection = "DELETE FROM SystemInfoHeadersTable WHERE SystemInfoHeadersID_Autonumber = " & Str(CurrentSystemInfoHeaderID)
            JustExecuteMySelection()
        End If
        FillSubSystemDataGridView()

    End Sub

End Class