Public Class ConcernsForm
    Public ConcernLevel As String
    Private CurrentConcernID As Integer = -1
    Private CurrentConcernRow As Integer = -1

    Private CurrentConcernTypeID As Integer = -1
    Private SavedCurrentConcernTypeID As Integer = -1 ' use upon update

    Private CurrentMasterCodeBookID As Integer = -1
    Private SavedCurrentMasterCodeBookID As Integer = -1 ' use upon update

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
    Private Sub ConcernsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' form returns       Tunnel1 = CurrentVehicleModelRelationsID
        '                    Tunnel2 = 

        ' form recieves on enabled  ' CurrentVehicleTypeID 
        '                           ' note: trim belongs to a model
        '                           '       model belongs to a type
        ' if empty, it has been opened not to return a code

        ' ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        MeLocationX = Me.Location.X
        MeLocationY = 50
        ' check these if needed
        'GET ALL ENTRY PARAMETERS

        ConcernsSelectionFilter = ""
        If Tunnel1.GetType.Name = "String" Then
            CurrentConcernID = Val(Tunnel1)
            If Val(Tunnel1) > 0 Then                      ' set if fixed make is required
                ConcernsSelectionFilter = " WHERE ConcernsRelationsTable.ConcernsID_LongInteger = " & Str(CurrentConcernID) & " "
            End If
        End If

        ConcernsSelectionFilterSaved = ConcernsSelectionFilter

        ' check these if needed

        FillWorkOrderConcernsTypeDataGridView()

        FillConcernsDataGridView()


        'SET AND RESET ALL ENTRY PARAMETERS
        ResetTunnels()





    End Sub
    Private Sub FillConcernsDataGridView()

        ConcernsFieldsToSelect = "Select " &
                                         " ConcernsTable.ConcernTypeID_LongInteger, " &
                                         " ConcernTypeTable.MainSystemCode_ShortText1, " &
                                         " ConcernTypeTable.ConcernType_ShortText100, " &
                                         " ConcernTypeTable.ConcernTypePrefix_ShortText50, " &
                                         " ConcernCodeID_AutoNumber, " &
                                         " ConcernsTable.Concern_ShortText150, " &
                                         " ConcernsTable.MasterCodeBookId_LongInteger, " &
                                         " MasterCodeBookTable.MainSystemCode_ShortText1, " &
                                         " MasterCodeBookTable.SubSystemCode_ShortText24Fld, " &
                                         " MasterCodeBookTable.SystemDesc_ShortText100Fld "


        ConcernsTablesLinks = " FROM(ConcernsTable LEFT JOIN MasterCodeBookTable On ConcernsTable.MasterCodeBookId_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) LEFT JOIN ConcernTypeTable On ConcernsTable.ConcernTypeID_LongInteger = ConcernTypeTable.ConcernTypeID_AutoNumber "
        ConcernsSelectionOrder = " ORDER BY SystemDesc_ShortText100Fld ASC"

        MySelection = ConcernsFieldsToSelect & ConcernsTablesLinks & ConcernsSelectionFilter & ConcernsSelectionOrder

        If NoRecordFound() Then
            Dim xxx = 10
        End If

        ConcernsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        ConcernsDataGridView.Columns.Item("ConcernTypeID_LongInteger").Visible = False
        '       ConcernsDataGridView.Columns.Item("ConcernCodeID_AutoNumber").Visible = False
        ConcernsDataGridView.Columns.Item("MasterCodeBookId_LongInteger").Visible = False
        ConcernsDataGridView.Columns.Item("ConcernType_ShortText100").Visible = False

        ConcernsDataGridView.Columns.Item("ConcernTypePrefix_ShortText50").HeaderText = " "
        ConcernsDataGridView.Columns.Item("ConcernTypePrefix_ShortText50").Width = 105


        ConcernsDataGridView.Columns.Item("SystemDesc_ShortText100Fld").HeaderText = "CONCERNS : in Master Code Book"
        ConcernsDataGridView.Columns.Item("SystemDesc_ShortText100Fld").Width = 500

        ConcernsDataGridView.Columns.Item("Concern_ShortText150").HeaderText = "CONCERNS : in ConcernsTable old description"
        ConcernsDataGridView.Columns.Item("Concern_ShortText150").Width = 500



        ConcernsDataGridView.Width = ConcernsDataGridView.Columns.Item("ConcernTypePrefix_ShortText50").Width +
                                     ConcernsDataGridView.Columns.Item("SystemDesc_ShortText100Fld").Width +
                                     ConcernsDataGridView.Columns.Item("Concern_ShortText150").Width + 50

        Me.Width = ConcernsDataGridView.Width + 30




    End Sub

    Private Sub ConcernTypesComboBox_TextChanged(sender As Object, e As EventArgs) Handles ConcernTypesComboBox.TextChanged
        If ConcernTypesComboBox.Text = "Customer Description of the Problem" Then
            Tunnel3 = 1
        Else
            Tunnel3 = 0
        End If
        ConcernTypeTextBox.Text = ConcernTypesComboBox.Text
        Dim InQuoteConcernType = Chr(34) & Trim(ConcernTypesComboBox.Text) & Chr(34)
        ConcernsSelectionFilter = " WHERE ConcernType_ShortText100 = " & InQuoteConcernType
        EnableToolStripMenuItems()

        Select Case ConcernTypesComboBox.Text
            Case "Select Type Of Concern"
                DisableToolStripMenuItems()
            Case "All Concerns"
                ConcernsSelectionFilter = ""

            Case Else

        End Select
        SearchConcernTextBox.Text = "Search"
        FillConcernsDataGridView()

    End Sub
    Public Sub FillWorkOrderConcernsTypeDataGridView()
        MySelection = "Select * " &
                           " FROM ConcernTypeTable ORDER BY ConcernType_ShortText100 "
        If NoRecordFound() Then Exit Sub
        ' FILL DATAGRID
        '      ConcernsTypeDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        ' CLEAR COMBOBOX
        ConcernTypesComboBox.Items.Clear()

        ' FILL COMBOBOX
        For Each R As DataRow In RecordFinderDbControls.MyAccessDbDataTable.Rows
            ConcernTypesComboBox.Items.Add(R("ConcernType_ShortText100"))
        Next

        ' DISPLAY FIRS NAME FOUND
        If RecordCount > 0 Then
            For I = 0 To RecordCount - 1
                If ConcernTypesComboBox.Items(I).ToString = "Select Type Of Concern" Then
                    ConcernTypesComboBox.Text = ConcernTypesComboBox.Items(I).ToString
                End If
            Next
            '           ConcernTypesComboBox.Text = (ConcernTypesComboBox.Items(2)).ToString
        End If
    End Sub


    Private Sub ConcernsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles ConcernsDataGridView.RowEnter

        If e.RowIndex < 0 Then Exit Sub
        If RecordCount = 0 Then Exit Sub
        If Not ConcernsDataGridViewInitialized Then
            ConcernsDataGridViewInitialized = True
        End If

        CurrentConcernRow = e.RowIndex

        CurrentConcernID = ConcernsDataGridView.Item("ConcernCodeID_AutoNumber", CurrentConcernRow).Value
        CurrentConcernTypeID = ConcernsDataGridView.Item("ConcernTypeID_LongInteger", CurrentConcernRow).Value
        If Not (IsDBNull(ConcernsDataGridView.Item("MasterCodeBookId_LongInteger", CurrentConcernRow).Value)) Then
            CurrentMasterCodeBookID = ConcernsDataGridView.Item("MasterCodeBookId_LongInteger", CurrentConcernRow).Value

        End If

    End Sub
    Private Sub ConcernsDataGridView_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles ConcernsDataGridView.DataBindingComplete
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




    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        Tunnel1 = -1
        Me.Close()
    End Sub

    Private Sub ConcernsForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        'Fills up tunnel1, tunnel2
        'Enables calling form

        'Enables calling form
        Select Case ActivatedBy.Text
            Case "VehicleManagementSystemForm"
                VehicleManagementSystemForm.Enabled = True ' triggers enabledchaned event of calling form
            Case "WorkOrderForm"
                WorkOrderForm.Enabled = True
            Case Else
                MsgBox(ActivatedBy.Text & " not yet filtered in the Select Case ActivatedBy.Text of " & Me.Name)
        End Select
        ActivatedBy.Text = ""

    End Sub
    Private Sub ConcernsForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged

        If Me.Enabled And NotEmpty(Tunnel1) Then
            If Tunnel2 = "Tunnel1IsMasterCode" Then
                CurrentMasterCodeBookID = Tunnel1
            Else
                CurrentConcernTypeID = Tunnel1
            End If
        Else
            EnableAbleModifyMode()
        End If

    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        TypeOfRequest = "ADD"
        ModifyGroupBox.Text = "Add a CONCERN"
        ModifyGroupBox.Visible = True
        EnableAbleModifyMode()
    End Sub
    Private Sub ShowConcernTypeForm()
        Me.Enabled = False
        ConcernTypeForm.ActivatedByTextBox.Text = Me.Name
        ConcernTypeForm.Show()
    End Sub
    Private Sub ShowMasterCodeBookForm()
        Me.Enabled = False
        MasterCodeBookForm.ActivatedBy.Text = Me.Name
        MasterCodeBookForm.Show()

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

        Dim FindKey As String = Trim(SearchConcernTextBox.Text)

        RecordFinderDbControls.AddParam("@FindKey", "%" & FindKey & "%")
        ConcernsSelectionFilter = " WHERE (Concern_ShortText150 Like @FindKey) or (SystemDesc_ShortText100Fld  Like @FindKey) "

        FillConcernsDataGridView()
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        TypeOfRequest = "UPDATE"
        'Check if there are links to the WorkOrderConcernsTable
        'if there exists then ask if real change action

        MySelection = "Select * from WorkOrderConcernsTable " &
                      "Where WorkOrderConcernsID_AutoNumber = " & Str(CurrentConcernID)
        If RecordIsFound() Then
            If Not MsgBox("This CONCERN is LINKED to a closed WORK ORDER, do you really want to change the description ?", 4) = 6 Then
                Exit Sub
            End If
        End If

        'setting the form enabled status will trigger ConcernsForm_EnabledChanged
        ConcernTypeTextBox.Text = ConcernsDataGridView.Item("ConcernTypePrefix_ShortText50", CurrentConcernRow).Value
        ConcernTextBox.Text = IIf(IsDBNull(ConcernsDataGridView.Item("SystemDesc_ShortText100Fld", CurrentConcernRow).Value), "", ConcernsDataGridView.Item("SystemDesc_ShortText100Fld", CurrentConcernRow).Value)

        If ConcernTextBox.Text = "" Then

            ModifyGroupBox.Text = "old CONCERN: " & ConcernsDataGridView.Item("Concern_ShortText150", CurrentConcernRow).Value

        Else
            ModifyGroupBox.Text = "Edit this CONCERN: " & ConcernsDataGridView.Item("SystemDesc_ShortText100Fld", CurrentConcernRow).Value

        End If
        SavedCurrentMasterCodeBookID = CurrentMasterCodeBookID
        SavedCurrentConcernTypeID = CurrentConcernTypeID
        EnableAbleModifyMode()
    End Sub

    Private Sub SelectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectToolStripMenuItem.Click
        Tunnel1 = CurrentConcernID
        Tunnel2 = "Tunnel1IsConcernCode"
        Tunnel3 = 0
        Me.Close()
    End Sub
    Private Sub ConcernsDataGridView_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles ConcernsDataGridView.RowHeaderMouseDoubleClick 'Select Row
        Tunnel1 = CurrentConcernID
        Tunnel2 = "Tunnel1IsConcernCode"
        Me.Close()
    End Sub

    Private Sub ConcernsTypeDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

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

                If CurrentConcernTypeID = 3 Then    'Diagnosia required
                    InsertIntoLongTextConcernTable()
                Else
                    InsertIntoConcernsTable()
                End If


            Case "UPDATE"
                If CurrentConcernTypeID = CurrentConcernTypeID And CurrentMasterCodeBookID = SavedCurrentMasterCodeBookID Then
                    MsgBox("No Changes were made to update")
                    Exit Sub
                End If
                Dim InQuoteConcernOldDesc = Chr(34) & Trim(ConcernsDataGridView("Concern_ShortText150", CurrentConcernRow).Value) & Chr(34)
                Dim ConcernsFilter = " WHERE trim(Concern_ShortText150) = " & InQuoteConcernOldDesc

                MySelection = " UPDATE ConcernsTable " &
                              " SET ConcernTypeID_LongInteger = " & Str(CurrentConcernTypeID) & ", " &
                              "     MasterCodeBookId_LongInteger  = " & Str(CurrentMasterCodeBookID)


                MySelection = MySelection & ConcernsFilter

                JustExecuteMySelection()

                MySelection = "Select * from ConcernsTable WHERE ConcernTypeID_LongInteger = " & Str(CurrentConcernTypeID) &
                                                           " AND " & "     MasterCodeBookId_LongInteger  = " & Str(CurrentMasterCodeBookID)
                JustExecuteMySelection()

                If RecordCount < 0 Then
                    MsgBox("Update not successful")
                Else
                    MsgBox(Str(RecordCount) & " record(s) updated")
                End If

            Case Else
        End Select

        FillConcernsDataGridView()
        DisableModifyMode()

    End Sub
    Private Sub InsertIntoLongTextConcernTable()
        MySelection = "INSERT INTO LongTextConcernTable  (" &
                                            " LongTextConcern_LongText)  " &
                                      "VALUES (" &
                                              Chr(34) & ConcernTextBox.Text & Chr(34) & " )"

        JustExecuteMySelection()

        MySelection = "Select * from LongTextConcernTable WHERE LongTextConcern_LongText = " & Chr(34) & ConcernTextBox.Text & Chr(34)
        If NoRecordFound() Then
            MsgBox("PROBLEM ...... unseccessful save ")
            Exit Sub
        End If
        Dim r As DataRow = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)

        CurrentConcernID = r("LongTextConcernID_Autonumber")

        Tunnel1 = CurrentConcernID
        Tunnel2 = "Tunnel1IsConcernCode"
        Tunnel3 = 1
        Me.Close()

    End Sub
    Private Sub InsertIntoConcernsTable()
        MySelection = "Select * from ConcernsTable WHERE ConcernTypeID_LongInteger = " & Str(CurrentConcernTypeID) &
                                                           " AND " & "     MasterCodeBookId_LongInteger  = " & Str(CurrentMasterCodeBookID)

        If RecordIsFound() Then
            MsgBox("This CONCERN already exist")
            Exit Sub
        End If

        If Not MsgBox(" Confirm adding " & ConcernTextBox.Text, vbYesNo) = vbYes Then
            ConcernTextBox.Select()
            Exit Sub
        End If

        MySelection = "INSERT INTO ConcernsTable  (" &
                                            " ConcernTypeID_LongInteger, " &
                                            " MasterCodeBookId_LongInteger)  " &
                                      "VALUES (" &
                                              Str(CurrentConcernTypeID) & ", " &
                                              Str(CurrentMasterCodeBookID) & " )"

        JustExecuteMySelection()

        MySelection = "Select * from ConcernsTable WHERE ConcernTypeID_LongInteger = " & Str(CurrentConcernTypeID) &
                                                           " AND " & "     MasterCodeBookId_LongInteger  = " & Str(CurrentMasterCodeBookID)

        If NoRecordFound() Then
            MsgBox("PROBLEM ...... unseccessful save ")
            Exit Sub
        End If
        Dim r As DataRow = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)

        CurrentConcernID = r("ConcernID_AutoNumber")

    End Sub
    Private Sub ConcernTextBox_TextChanged(sender As Object, e As EventArgs) Handles ConcernTextBox.Click
        If Not ConcernTypesComboBox.Text = "Requires TROUBLE SHOOTING" Then
            ShowMasterCodeBookForm()

        End If
    End Sub

End Class