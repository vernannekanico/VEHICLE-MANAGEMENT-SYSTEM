Public Class ConcernsForm
    Public ConcernLevel As String
    Private CurrentConcernID As Integer = -1
    Private CurrentConcernRow As Integer = -1

    Private CurrentConcernTypeID As Integer = -1
    Private SavedCurrentConcernTypeID As Integer = -1 ' use upon update

    Private CurrentMasterCodeBookID As Integer = -1
    Private SavedCurrentMasterCodeBookID_LongIntegerID As Integer = -1 ' use upon update

    Private CurrentConcernTypeCode = ""
    Private TypeOfRequest = ""
    Public ProductCode As Integer = -1


    Private ConcernsDataGridViewInitialized = False

    Private ConcernsFieldsToSelect = ""
    Private ConcernsTablesLinks = ""
    Private ConcernsSelectionFilter = ""
    Private ConcernsSelectionFilterSaved = ""
    Private ConcernsSelectionOrder = ""
    Private MeLocationX As Integer
    Private MeLocationY As Integer
    Private ConcernsDataGridViewAlreadyFormated = False
    Private ItIsMasterCodeBookDescription = False
    Private SavedCallingForm As Form

    Private Sub ConcernsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' form returns       Tunnel1 = CurrentVehicleModelsRelationID
        '                    Tunnel2 = 

        ' form recieves on enabled  ' CurrentVehicleTypeID 
        '                           ' note: trim belongs to a model
        '                           '       model belongs to a type
        ' if empty, it has been opened not to return a code

        ' ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        SavedCallingForm = CallingForm

        MeLocationX = Me.Location.X
        MeLocationY = 50
        ' check these if needed
        'GET ALL ENTRY PARAMETERS
        ConcernTypesComboBox.Select()
        ConcernsDataGridView.Visible = False
        SearchConcernTextBox.Enabled = False
        JobsToolStripMenuItem.Visible = False
        ConcernsSelectionFilter = ""

        FillConcernsTypeComboBox()
        DisableToolStripMenuItems()
    End Sub
    Private Sub FillConcernsDataGridView()
        If ItIsMasterCodeBookDescription Then

            ConcernsFieldsToSelect = "
Select 
ConcernsTable.ConcernID_AutoNumber, 
MasterCodeBookTable.SystemDesc_ShortText100Fld, 
ConcernsTable.Concern_ShortText255, 
ConcernsTable.InformationsHeadersTypeID_LongInteger, 
ConcernsTable.MasterCodeBookId_LongInteger, 
MasterCodeBookTable.MainSystemCode_ShortText1, 
MasterCodeBookTable.SubSystemCode_ShortText24Fld, 
InformationsHeadersTypeTable.InformationsHeadersType_ShortText100, 
InformationsHeadersTypeTable.Prefix, 
InformationsHeadersTypeClassTable.InformationsHeadersTypeClass_ShortText100 
"

            ConcernsTablesLinks = "  
FROM((ConcernsTable LEFT JOIN MasterCodeBookTable ON ConcernsTable.MasterCodeBookId_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) 
LEFT JOIN InformationsHeadersTypeTable On ConcernsTable.InformationsHeadersTypeID_LongInteger = InformationsHeadersTypeTable.InformationsHeadersTypeID_AutoNumber) 
LEFT JOIN InformationsHeadersTypeClassTable On InformationsHeadersTypeTable.InformationsHeadersTypeClassID_Integer = InformationsHeadersTypeClassTable.InformationsHeadersTypeClassID_AutoNumber 
"

            ConcernsSelectionOrder = " ORDER BY SystemDesc_ShortText100Fld ASC"

            MySelection = ConcernsFieldsToSelect & ConcernsTablesLinks & ConcernsSelectionFilter & ConcernsSelectionOrder

            JustExecuteMySelection()
            ConcernsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        Else
            ConcernsFieldsToSelect = "SELECT ConcernAsIsByClientTable.LongTextConcernID_Autonumber,
ConcernAsIsByClientTable.LongTextConcern_LongText FROM ConcernAsIsByClientTable "

            ConcernsSelectionOrder = " ORDER BY LongTextConcern_LongText "

            MySelection = ConcernsFieldsToSelect '& ConcernsSelectionFilter '& ConcernsSelectionOrder

            JustExecuteMySelection()
            ConcernsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        End If
        FormatConcernsDataGridView()

        Dim NoOfHeaderLines = 1
        Dim RecordsDisplyed = RecordCount
        Dim FormLowPointFromGrid = 90
        If RecordCount > 27 Then
            Me.Location = New Point(MeLocationX, MeLocationY)
            RecordsDisplyed = 22
        Else
            RecordsDisplyed = RecordCount + 1
        End If
        ConcernsDataGridView.Height = (ConcernsDataGridView.ColumnHeadersHeight * NoOfHeaderLines) + (DataGridViewRowHeight * RecordsDisplyed) + DataGridViewRowHeight
        Me.Height = ConcernsDataGridView.Height + FormLowPointFromGrid + 110
        '       VehicleTrimDataGridView.Location = New Point(1, 49)
    End Sub
    Private Sub FormatConcernsDataGridView()
        ConcernsDataGridViewAlreadyFormated = True
        If ItIsMasterCodeBookDescription Then

            For i = 0 To ConcernsDataGridView.Columns.GetColumnCount(0) - 1


                Dim DoNotDisplayFields = "ConcernTypeID_LongInteger/ConcernID_AutoNumber/WorkOrderID_AutoNumber/MasterCodeBookId_LongInteger/MasterCodeBookID_AutoNumber"
                If InStr(DoNotDisplayFields, ConcernsDataGridView.Columns.Item(i).HeaderText) > 0 Then
                    ConcernsDataGridView.Columns.Item(i).Visible = False
                End If

                Select Case ConcernsDataGridView.Columns.Item(i).HeaderText
                    Case "ConcernTypePrefix_ShortText50"
                        ConcernsDataGridView.Columns.Item(i).HeaderText = " "
                        ConcernsDataGridView.Columns.Item(i).Width = 105
                    Case "InformationsHeaderDescription_ShortText255"
                        ConcernsDataGridView.Columns.Item(i).HeaderText = "CONCERNS : in HeadersInfo"
                        ConcernsDataGridView.Columns.Item(i).Width = 500
                    Case "Concern_ShortText255"
                        ConcernsDataGridView.Columns.Item(i).HeaderText = "CONCERNS : in ConcernsTable old description"
                        ConcernsDataGridView.Columns.Item(i).Width = 500

                End Select

            Next
        Else
            ConcernsFieldsToSelect = "SELECT ConcernAsIsByClientTable.LongTextConcernID_Autonumber, ConcernAsIsByClientTable.LongTextConcern_LongText
FROM ConcernAsIsByClientTable "
            ConcernsDataGridView.Columns.Item("LongTextConcernID_Autonumber").Visible = False
            ConcernsDataGridView.Columns.Item("LongTextConcern_LongText").HeaderText = "CONCERN"
            ConcernsDataGridView.Columns.Item("LongTextConcern_LongText").Width = 800
        End If


        For i = 0 To ConcernsDataGridView.Columns.GetColumnCount(0) - 1
            If ConcernsDataGridView.Columns.Item(i).Visible = True Then
                ConcernsDataGridView.Width = ConcernsDataGridView.Width + ConcernsDataGridView.Columns.Item(i).Width
            End If
        Next

        Me.Width = ConcernsDataGridView.Width + 30

    End Sub

    Private Sub ConcernTypesComboBox_TextChanged(sender As Object, e As EventArgs) Handles ConcernTypesComboBox.TextChanged
        If ConcernTypesComboBox.Text = "Select Type Of CONCERN" Then Exit Sub
        ConcernsDataGridView.Visible = True
        SearchConcernTextBox.Enabled = True
        SetParentRecordReference("InformationsHeadersTypeTable", "InformationsHeadersType_ShortText100", ConcernTypesComboBox.Text)
        If RecordCount > 0 Then
            r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
            CurrentConcernTypeID = r("InformationsHeadersTypeID_AutoNumber")
            CurrentConcernTypeCode = r("MainSystemCode_ShortText1")
            Dim ItIsAllConcerns = r("MainSystemCode_ShortText1") = "ALL CONCERNS"
            If CurrentConcernTypeCode = "D" Then

                ItIsMasterCodeBookDescription = False
                ' DO A SUB ROUTINE FOR ConcernAsIsByClientTable
                ConcernsSelectionFilter = " WHERE LongTextConcern_LongText Like " & Chr(34) & "%" & Trim(ConcernTypesComboBox.Text) & "%" & Chr(34)
                DisableToolStripMenuItems()
                If ConcernTypesComboBox.Text = "Customer Description of the Problem" Then
                    Tunnel3 = 1 ' description Is Customer Description of the Problem
                    ModifyGroupBox.Visible = False
                End If
            Else
                ' DO A SUB ROUTINE FOR ConcernsTable
                ItIsMasterCodeBookDescription = True
                ConcernsSelectionFilter = " WHERE InformationsHeadersType_ShortText100 = " & Chr(34) & Trim(ConcernTypesComboBox.Text) & Chr(34)
                Tunnel3 = 0 ' description is from MasterCodeBook 
                FillConcernsDataGridView()
            End If

        Else
            Exit Sub
        End If
        ConcernTypeTextBox.Text = ConcernTypesComboBox.Text
        FillConcernsDataGridView()
        EnableToolStripMenuItems()
    End Sub
    Public Sub FillConcernsTypeComboBox()
        MySelection = "
Select  
InformationsHeadersTypeTable.InformationsHeadersType_ShortText100, 
InformationsHeadersTypeClassTable.InformationsHeadersTypeClass_ShortText100,
InformationsHeadersTypeTable.InformationsHeadersTypeClassID_Integer 
From InformationsHeadersTypeTable LEFT Join InformationsHeadersTypeClassTable On InformationsHeadersTypeTable.InformationsHeadersTypeClassID_Integer =  
InformationsHeadersTypeClassTable.InformationsHeadersTypeClassID_AutoNumber 
  WHERE  InformationsHeadersTypeClass_ShortText100 = 
" & Chr(34) & "CONCERNS" & Chr(34) &
            " ORDER BY InformationsHeadersTypeClassID_Integer, InformationsHeadersType_ShortText100 "
        If NoRecordFound() Then Exit Sub

        ' CLEAR COMBOBOX
        ConcernTypesComboBox.Items.Clear()

        ' FILL COMBOBOX
        Dim ConcernRelatedRecords = 0
        For Each R As DataRow In RecordFinderDbControls.MyAccessDbDataTable.Rows
            ConcernTypesComboBox.Items.Add(R("InformationsHeadersType_ShortText100"))
            ConcernRelatedRecords = ConcernRelatedRecords + 1
        Next

        ' DISPLAY FIRS NAME FOUND
        If RecordCount > 0 Then
            For I = 0 To ConcernRelatedRecords - 1
                If ConcernTypesComboBox.Items(I).ToString = "Select Type Of CONCERN" Then
                    ConcernTypesComboBox.Text = ConcernTypesComboBox.Items(I).ToString
                    Exit For
                End If
            Next
        End If
    End Sub


    Private Sub ConcernsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles ConcernsDataGridView.RowEnter

        If e.RowIndex < 0 Then Exit Sub
        If RecordCount = 0 Then Exit Sub
        If Not ConcernsDataGridViewInitialized Then
            ConcernsDataGridViewInitialized = True
        End If

        CurrentConcernRow = e.RowIndex
        If ItIsMasterCodeBookDescription Then
            CurrentConcernID = ConcernsDataGridView.Item("ConcernID_AutoNumber", CurrentConcernRow).Value
            '       CurrentConcernTypeID = ConcernsDataGridView.Item("ConcernTypeID_LongInteger", CurrentConcernRow).Value
            If Not (IsDBNull(ConcernsDataGridView.Item("MasterCodeBookID_LongInteger", CurrentConcernRow).Value)) Then
                CurrentMasterCodeBookID = ConcernsDataGridView.Item("MasterCodeBookID_LongInteger", CurrentConcernRow).Value

            End If
        Else
            CurrentConcernID = ConcernsDataGridView.Item("LongTextConcernID_Autonumber", CurrentConcernRow).Value

        End If

    End Sub

    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        'Fills up tunnel1, tunnel2
        Tunnel1 = "cancelled"

        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub

    Private Sub ConcernsForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        If Me.Enabled = False Then Exit Sub
        CallingForm = SavedCallingForm
        Select Case Tunnel1
            Case "Tunnel2IsMasterCodeBookID"
                CurrentMasterCodeBookID = Tunnel2
                ConcernTextBox.Text = Tunnel3
        End Select

        ' NOTE WATCH STUDY AND HOW IS THIS DO A TEST

    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        TypeOfRequest = "ADD"
        ModifyGroupBox.Text = "Add a CONCERN"
        ModifyGroupBox.Visible = True
        EnableAbleModifyMode()
    End Sub
    Private Sub ShowConcernTypeForm()
        Me.Enabled = False
        ConcernTypesForm.ActivatedByTextBox.Text = Me.Name
        ConcernTypesForm.Show()
    End Sub
    Private Sub ShowMasterCodeBookForm()
    End Sub

    Private Sub ShowConcernsDetailForm()
        Me.Enabled = False

        Tunnel1 = CurrentConcernID ' here it clips to filter only to current type
        ConcernsDetailsForm.ActivatedByTextBox.Text = Me.Name
        ConcernsDetailsForm.Text = Me.Text
        ConcernsDetailsForm.Show()

    End Sub
    Private Sub SearchConcernTextBox_TClick(sender As Object, e As EventArgs) Handles SearchConcernTextBox.Click
        If SearchConcernTextBox.Text = "Search" Then
            SearchConcernTextBox.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub SearchConcernTextBox_TextChanged(sender As Object, e As EventArgs) Handles SearchConcernTextBox.TextChanged
        If SearchConcernTextBox.Text = "Search" Then Exit Sub
        If SearchConcernTextBox.Text = "" Then

            ConcernsSelectionFilter = ""
            FillConcernsDataGridView()

            Exit Sub
        End If

        If ItIsMasterCodeBookDescription Then
            ConcernsSelectionFilter = " WHERE (Concern_ShortText255 Like " & Chr(34) & "%" & Trim(SearchConcernTextBox.Text) & "%" & Chr(34) & ") " &
                                       " Or (SystemDesc_ShortText100Fld  Like " & Chr(34) & "%" & Trim(SearchConcernTextBox.Text) & "%" & Chr(34) & ") "
        Else
            ConcernsSelectionFilter = " WHERE (LongTextConcern_LongText  Like " & Chr(34) & "%" & Trim(SearchConcernTextBox.Text) & "%" & Chr(34)
        End If

        FillConcernsDataGridView()
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        TypeOfRequest = "UPDATE"
        'Check if there are links to the WorkOrderConcernsTable
        'if there exists then ask if real change action

        MySelection = "Select * from WorkOrderConcernsTable " &
                      " Where WorkOrderConcernID_AutoNumber = " & Str(CurrentConcernID)
        If RecordIsFound() Then
            If Not MsgBox("This CONCERN is LINKED to a closed WORK ORDER, do you really want to change the description ?", 4) = 6 Then
                Exit Sub
            End If
        End If

        'setting the form enabled status will trigger ConcernsForm_EnabledChanged
        '    ConcernTypeTextBox.Text = ConcernsDataGridView.Item("Prefix", CurrentConcernRow).Value
        If ItIsMasterCodeBookDescription Then

            ConcernTextBox.Text = IIf(IsDBNull(ConcernsDataGridView.Item("InformationsHeaderDescription_ShortText255", CurrentConcernRow).Value), "", ConcernsDataGridView.Item("SystemDesc_ShortText100Fld", CurrentConcernRow).Value)

            If ConcernTextBox.Text = "" Then

                ModifyGroupBox.Text = "old CONCERN: " & ConcernsDataGridView.Item("Concern_ShortText255", CurrentConcernRow).Value

            Else
                ModifyGroupBox.Text = "Edit this CONCERN: " & ConcernsDataGridView.Item("SystemDesc_ShortText100Fld", CurrentConcernRow).Value

            End If
        Else
            ConcernTextBox.Text = IIf(IsDBNull(ConcernsDataGridView.Item("LongTextConcern_LongText", CurrentConcernRow).Value), "", ConcernsDataGridView.Item("LongTextConcern_LongText", CurrentConcernRow).Value)
        End If
        SavedCurrentMasterCodeBookID_LongIntegerID = CurrentMasterCodeBookID
        SavedCurrentConcernTypeID = CurrentConcernTypeID
        EnableAbleModifyMode()
    End Sub

    Private Sub SelectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectToolStripMenuItem.Click
        If ItIsMasterCodeBookDescription Then
            If IsEmpty(ConcernsDataGridView.Item("MasterCodeBookID_LongInteger", CurrentConcernRow).Value) Then
                ShowCalledForm(Me, MasterCodeBookForm)
            Else
                Tunnel1 = "Tunnel2IsConcernID"
                Tunnel2 = CurrentConcernID
                DoCommonHouseKeeping(Me, SavedCallingForm)
            End If
        Else
            Tunnel1 = "Tunnel2IsLongTextConcernID"
            Tunnel2 = CurrentConcernID
            DoCommonHouseKeeping(Me, SavedCallingForm)
        End If
    End Sub
    Private Sub ConcernsDataGridView_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles ConcernsDataGridView.RowHeaderMouseDoubleClick 'Select Row
        Tunnel1 = "Tunnel2IsConcernCode"
        Tunnel2 = CurrentConcernID
        Tunnel3 = 0 ' returned value 0 indicates that description comes from the concernstable where field TextType_Byte of WorkOrderComernsTable
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
        ModifyGroupBox.Text = "Delete a TYPE CONCERN"
        MsgBox("not needed at this time")
        EnableAbleModifyMode()

    End Sub

    Private Sub ModifyGroupBox_Enter(sender As Object, e As EventArgs) Handles ModifyGroupBox.VisibleChanged
        If ModifyGroupBox.Visible = True Then
            ConcernsDataGridView.Enabled = False
        Else
            ConcernsDataGridView.Enabled = True
        End If
    End Sub

    Private Sub ConcernTypeTextBox_TextChanged(sender As Object, e As EventArgs) Handles ConcernTypeTextBox.GotFocus
        If ConcernTextBox.Text = "" Then
            ShowConcernTypeForm()
        End If
    End Sub


    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        ' maybe the type and concern is being considered here
        Select Case TypeOfRequest
            Case "ADD"
                ' EXECUTE INSERT COMMAND

                If ConcernTypeTextBox.Text = "Customer Description of the Problem" Then    'Diagnosia required
                    InsertIntoConcernAsIsByClientTable()
                Else
                    InsertIntoConcernsTable()
                End If

                TypeOfRequest = "UPDATE"
            Case "UPDATE"
                If CurrentConcernTypeID = SavedCurrentConcernTypeID And CurrentMasterCodeBookID = SavedCurrentMasterCodeBookID_LongIntegerID Then
                    MsgBox("No Changes were made to update")
                    Exit Sub
                End If
                Dim InQuoteConcernOldDesc = Chr(34) & Trim(ConcernsDataGridView("Concern_ShortText255", CurrentConcernRow).Value) & Chr(34)
                Dim ConcernsFilter = " WHERE Concern_ShortText255 = " & InQuoteConcernOldDesc

                MySelection = " UPDATE ConcernsTable " &
                              " SET InformationsHeadersTypeID_LongInteger = " & Str(CurrentConcernTypeID) & ", " &
                              "     MasterCodeBookID_LongInteger  = " & Str(CurrentMasterCodeBookID)


                MySelection = MySelection & ConcernsFilter

                JustExecuteMySelection()

                MySelection = "Select * from ConcernsTable WHERE InformationsHeadersTypeID_LongInteger = " & Str(CurrentConcernTypeID) &
                                                           " AND " & "     MasterCodeBookID_LongInteger  = " & Str(CurrentMasterCodeBookID)
                JustExecuteMySelection()

                If RecordCount < 0 Then
                    MsgBox("Update not successful, PAUSE HERE")
                Else
                    MsgBox(Str(RecordCount) & " record(s) updated")
                End If

            Case Else
        End Select

        FillConcernsDataGridView()
        DisableModifyMode()

    End Sub
    Private Sub InsertIntoConcernAsIsByClientTable()
        MySelection = "INSERT INTO ConcernAsIsByClientTable  (" &
                                            " LongTextConcern_LongText)  " &
                                      "VALUES (" &
                                              Chr(34) & ConcernTextBox.Text & Chr(34) & " )"

        JustExecuteMySelection()

        MySelection = "Select * from ConcernAsIsByClientTable WHERE LongTextConcern_LongText = " & Chr(34) & ConcernTextBox.Text & Chr(34)
        If NoRecordFound() Then
            MsgBox("PROBLEM ...... unseccessful save ")
            Exit Sub
        End If
        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)

        CurrentConcernID = r("LongTextConcernID_Autonumber")

        Tunnel1 = "Tunnel2IsConcernCode"
        Tunnel2 = CurrentConcernID
        Tunnel3 = 1
        DoCommonHouseKeeping(Me, SavedCallingForm)

    End Sub
    Private Sub InsertIntoConcernsTable()
        If CurrentMasterCodeBookID > -1 Then
            MySelection = "Select * from ConcernsTable WHERE InformationsHeadersTypeID_LongInteger = " & Str(CurrentConcernTypeID) &
                " AND MasterCodeBookId_LongInteger = " & Str(CurrentMasterCodeBookID)
        Else
            MySelection = "Select * from ConcernAsIsByClientTable WHERE LongTextConcern_LongText = " & Chr(34) & ConcernTextBox.Text & Chr(34)
        End If
        If RecordIsFound() Then
            MsgBox("This CONCERN already exist")
            Exit Sub
        End If

        If Not MsgBox(" Confirm adding " & ConcernTextBox.Text, vbYesNo) = vbYes Then
            ConcernTextBox.Select()
            Exit Sub
        End If
        If CurrentMasterCodeBookID > -1 Then
            MySelection = "INSERT INTO  ConcernsTable   (" &
                                           " InformationsHeadersTypeID_LongInteger, " &
                                            " Source_Byte, " &
                                            " MasterCodeBookID_LongInteger)  " &
                                      "VALUES (" &
                                              Str(CurrentConcernTypeID) & ", " &
                                              Str(2) & ", " &
                                              Str(CurrentMasterCodeBookID) & " )"
        Else
            MySelection = "INSERT INTO ConcernAsIsByClientTable  (" &
                                           " LongTextConcern_LongText) " &
                                      "VALUES (" &
                                              Chr(34) & ConcernTextBox.Text & Chr(34) & ")"
        End If
        JustExecuteMySelection()

        If CurrentMasterCodeBookID > -1 Then
            MySelection = "Select * from ConcernsTable WHERE InformationsHeadersTypeID_LongInteger = " & Str(CurrentConcernTypeID)
        Else
            MySelection = "Select * from ConcernAsIsByClientTable WHERE LongTextConcern_LongText = " & Chr(34) & ConcernTextBox.Text & Chr(34)
        End If

        If NoRecordFound() Then
            MsgBox("PROBLEM ...... unseccessful save ")
            Exit Sub
        End If

        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        If CurrentMasterCodeBookID > -1 Then
            CurrentConcernID = r("ConcernID_AutoNumber")
        Else
            CurrentConcernID = r("LongTextConcernID_Autonumber")
        End If

    End Sub
    Private Sub ConcernTextBox_TextChanged(sender As Object, e As EventArgs) Handles ConcernTextBox.Click
        SetParentRecordReference("InformationsHeadersTypeTable", "InformationsHeadersTypeID_AutoNumber", CurrentConcernTypeID)
        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        Dim xxMainSystemCode_ShortText1 = r("MainSystemCode_ShortText1")
        If xxMainSystemCode_ShortText1 = "P" Or xxMainSystemCode_ShortText1 = "M" Then
            MasterCodeBookForm.SearchMasterCodeBookTextBox.Text = SearchConcernTextBox.Text
            ShowCalledForm(Me, MasterCodeBookForm)
        Else
            If xxMainSystemCode_ShortText1 = "D" Then
                SearchConcernTextBox.Text = ConcernTypesComboBox.Text
            End If
        End If
    End Sub

End Class