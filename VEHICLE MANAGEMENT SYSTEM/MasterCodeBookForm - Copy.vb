Imports excel = Microsoft.Office.Interop.Excel
Public Class MasterCodeBookForm
    Private CurrentProductCode = ""
    Private CurrentProductID As Integer
    Private CurrentProductRow As Integer

    Private CurrentJobCode = ""
    Private CurrentJobID As Integer
    Private CurrentJobRow As Integer

    Private CurrentSubSystemCodeBookID As Integer
    Public CurrentMainSystemCode As String
    Private CurrentMainSystemName As String
    Private CurrentMainCodeLength As Integer
    Private CurrentMainCodeColumn As Integer
    Private CurrentMainSystemCodeRow As Integer
    Private CurrentVehicleRepairCode As Integer

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

    Private JobsDataGridViewInitialized = False
    Private JobsRecordCount As Integer = 0

    Private JobsFieldsToSelect = ""
    Private JobsTablesLinks = ""
    Private JobsSelectionFilter = ""
    Private JobsSelectionFilterSaved = ""
    Private JobsSelectionOrder = ""
    Private PJobsFieldsValues = ""

    Private ProductsDataGridViewInitialized = False
    Private ProductsRecordCount As Integer = 0

    Private ProductsFieldsToSelect = ""
    Private ProductsTablesLinks = ""
    Private ProductsSelectionFilter = ""
    Private ProductsSelectionFilterSaved = ""
    Private ProductsSelectionOrder = ""
    Private ProductsFieldsValues = ""

    Private MainSystemCodeFieldsToSelect = ""
    Private MainSystemCodeTablesLinks = ""
    Private MainSystemCodeSelectionFilter = ""
    Private MainSystemCodeSelectionFilterSaved = ""
    Private MainSystemCodeSelectionOrder = ""

    '   Private MyAccess As New MyDbControls
    Private SubSystemCodeFieldsToSelect = ""
    Private SubSystemCodeTablesLinks = ""
    Private SubSystemCodeSelectionFilter = ""
    Private SubSystemCodeSelectionFilterSaved = ""
    Private SubSystemCodeSelectionOrder = ""

    Private PurposeOfMasterCodeBookDetailsGroupEntry = "ADD"

    Private Siblings As String = ""
    Private Children As String = ""
    Private SavedSubSystemCode = ""
    Private SavedSubSystemDesc = ""
    Private SubMainFilter = ""

    Private MasterCodeBookFieldsValues = ""
    Private MasterCodeBookFieldsToReplace = ""
    Private ProductsFieldsToReplace = ""

    Private DefaultProcedurePath = DefaultSystemPath & "\Procedures\"
    Private ExcelFileName = ""
    Private ProcedureExists = ""

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
        CurrentMainSystemCodeRow = e.RowIndex
        CurrentMainSystemName = Trim(MainSystemCodeDataGridView.Item(1, CurrentMainSystemCodeRow).Value)
        CurrentMainSystemCode = LTrim(RTrim(MainSystemCodeDataGridView.Item(0, CurrentMainSystemCodeRow).Value))
        Dim xxxx = "(Mid(SubSystemCode_ShortText24Fld,1,2) = " & Chr(34) & CurrentMainSystemCode & Chr(34)
        Dim yyyy = " And Len(Trim(SubSystemCode_ShortText24Fld)) = 4 )"
        Siblings = xxxx & yyyy
        Children = " (mid(SubSystemCode_ShortText24Fld,1,4) = " & Chr(34) & CurrentMainSystemCode & "01" & Chr(34) & ")"
        SavedSubSystemCode = CurrentSubSystemCode
        SavedSubSystemDesc = CurrentSubSystemName
        FillSubSystemDataGridView()
        SubSystemCodeDataGridView.Rows(0).Selected = True
    End Sub

    Private Sub FillSubSystemDataGridViewOriginal()
        Dim SubCodeLength = Len(Trim(CurrentSubSystemCode))
        If SavedSubSystemCode <> CurrentSubSystemCode Then
            Dim Parent = "Mid(SubSystemCode_ShortText24Fld,1," & Str(SubCodeLength - 2) & ")"
            Dim ParentKey = Parent & " = " & Mid(CurrentSubSystemCode, 1, SubCodeLength - 2)
            Dim ParentKeyLength = " And Len(Trim(SubSystemCode_ShortText24Fld)) = " & Str(SubCodeLength)
            Siblings = "(" & ParentKey & ParentKeyLength & ")"
            Children = " (mid(SubSystemCode_ShortText24Fld,1," & Str(Len(Trim(CurrentSubSystemCode))) & ") = " & Chr(34) & CurrentSubSystemCode & Chr(34) & ")"
            Dim ChildrenLength = " And Len(Trim(SubSystemCode_ShortText24Fld)) = " & Str(SubCodeLength + 2)
            Children = "(" & Children & ChildrenLength & ")"

            SavedSubSystemCode = CurrentSubSystemCode
        End If

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
        If SavedSubSystemCode <> CurrentSubSystemCode Then
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
            SavedSubSystemCode = CurrentSubSystemCode
        End If

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
        '      SubSystemCodeDataGridView.Columns.Item("SubSystemCode_ShortText24Fld").HeaderText = CurrentMainSystemCode
        '     SubSystemCodeDataGridView.Columns.Item("SystemDesc_ShortText100Fld").HeaderText = Trim(MainSystemCodeDataGridView.Item(CurrentMainCodeColumn + 1, CurrentMainSystemCodeRow).Value)

    End Sub

    Private Sub SubSystemCodeDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles SubSystemCodeDataGridView.RowEnter
        CurrentSubSystemCodeRow = e.RowIndex
        CurrentSubSystemName = Trim(SubSystemCodeDataGridView.Item(CurrentSubCodeColumn + 1, CurrentSubSystemCodeRow).Value)
        CurrentSubSystemCode = LTrim(RTrim(SubSystemCodeDataGridView.Item(0, CurrentSubSystemCodeRow).Value))
        CurrentSubSystemCodeBookID = LTrim(RTrim(SubSystemCodeDataGridView.Item("MasterCodeBookID_Autonumber", CurrentSubSystemCodeRow).Value))
        DeleteMasterCodeToolStripMenuItem.Visible = False
        CurrentMasterCodeBookSubSystemID = SubSystemCodeDataGridView.Item("MasterCodeBookID_Autonumber", CurrentSubSystemCodeRow).Value
        Dim ProcedureName = Str(1000 + CurrentVehicleRepairCode).Substring(2) & CurrentSubSystemCode
        ExcelFileName = DefaultProcedurePath & ProcedureName & ".xls"
        ProcedureExists = Dir(ExcelFileName, vbHidden)
        '---------------------------------------------------------------------------
        ' *********    DETERMINE PROCEDURE EXCELL FILE RELATED TO THE CURRENT CurrentSubSystemCode EXISTS

        If ProcedureExists = "" Then

            ' *********     try the filename with text if exist

            Dim ExcelFileNameAll = DefaultProcedurePath & ProcedureName & " *.xls"


            ProcedureExists = Dir(ExcelFileNameAll, vbHidden)
            If CurrentVehicleRepairCode > 0 Then                                        ' If the vehicle model is not set creation and opening of procedures are not provided
                ' and no deletion of child is allowed
                CreateProcedureToolStripMenuItem.Visible = True

                ' *********                                                             IF EXISTS ALLOW OPENING ELSE ALLOW CREATE

                If Not ProcedureExists = "" Then
                    CreateProcedureToolStripMenuItem.Text = "Open Procedure"
                Else
                    CreateProcedureToolStripMenuItem.Text = "CREATE Procedure"
                End If

                ' *********                                                             IF EXISTS ALLOW OPENING ELSE ALLOW CREATE

            Else
                CreateProcedureToolStripMenuItem.Text = ""
            End If
        Else
            If Not ProcedureExists = "" Then
                CreateProcedureToolStripMenuItem.Text = "Open Procedure"
            Else
                CreateProcedureToolStripMenuItem.Text = "CREATE Procedure"
            End If

            ' *********                                                                 IF EXISTS ALLOW OPENING ELSE ALLOW CREATE ENDS

        End If

        ' *********                                                                     DETERMINES PROCEDURE EXCELL FILE RELATED TO THE CURRENT CurrentSubSystemCode ENDS

        If Len(Trim(CurrentSubSystemCode)) = 2 Then
            CurrentParentCode = CurrentMainSystemCode
        Else
            CurrentParentCode = CurrentSubSystemCode
        End If

        FillJobsDataGridView()

        FillProductsDataGridView()

        ' *********     HANDLES ENABLING THE OPTION TO DELETE THE RECORD

        If ProcedureExists = "" And ProductsRecordCount = 0 Then
            DeleteMasterCodeToolStripMenuItem.Visible = True                            '   CAN DELETE IF NO PROCEDURE OR PRODUCTS LINKED EXISTS
        Else
            ExcelFileName = DefaultProcedurePath & ProcedureExists
            DeleteMasterCodeToolStripMenuItem.Visible = False
        End If

        ' *********     HANDLES ENABLING THE OPTION TO DELETE THE RECORD ends   

        SearchProductToolStripTextBox.Visible = True                                    '   ALWAYS ALLOW SEARCH MODE ON ROW ENTER

        ' Update Parent header values here 
        GEtParentDetails()

















        '--------------------------------------------------------------------------------------------
        '      If CurrentVehicleRepairCode > 0 Then            ' If the vehicle model is not set creation and opening of procedures are not provided
        '      ' and no deletion of child is allowed
        '      CreateProcedureToolStripMenuItem.Visible = True
        '
        '        If Not ProcedureExists = "" Then
        '        CreateProcedureToolStripMenuItem.Text = "Open Procedure"
        '        Else
        '        CreateProcedureToolStripMenuItem.Text = "CREATE Procedure"
        '        End If
        '        Else
        '        CreateProcedureToolStripMenuItem.Text = ""
        '        End If
        '
        '        If Len(Trim(CurrentSubSystemCode)) = 2 Then
        '        CurrentParentCode = CurrentMainSystemCode
        '        Else
        '        CurrentParentCode = CurrentSubSystemCode
        '        End If
        '
        '        FillProductsDataGridView()
        '        If ProcedureExists = "" And ProductsRecordCount = 0 Then
        '        DeleteMasterCodeToolStripMenuItem.Visible = True
        '        Else
        '        ExcelFileName = DefaultProcedurePath & ProcedureExists
        '            DeleteMasterCodeToolStripMenuItem.Visible = False
        '        End If
        '        SearchProductToolStripTextBox.Visible = True

    End Sub
    Private Sub GEtParentDetails()
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
    Private Sub FillJobsDataGridView()
        JobsFieldsToSelect = " Select SystemJobsTable.SystemJobID_AutoNumber, " &
                            " SystemJobsTable.MasterCodeBookId_LongInteger, " &
                            " SystemJobsTable.JobID_LongInteger, " &
                            " JobsTable.JobCode_ShortText30, " &
                            " JobsTable.JobDescription_ShortText255 "


        JobsTablesLinks = " FROM(SystemJobsTable " &
                            " LEFT JOIN MasterCodeBookTable On SystemJobsTable.MasterCodeBookId_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) " &
                            " LEFT JOIN JobsTable On SystemJobsTable.JobID_LongInteger = JobsTable.JobID_AutoNumber "

        JobsTablesLinks = " FROM(SystemJobsTable " &
                            " LEFT JOIN MasterCodeBookTable On SystemJobsTable.MasterCodeBookId_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) " &
                            " LEFT JOIN JobsTable On SystemJobsTable.JobID_LongInteger = JobsTable.JobID_AutoNumber "

        JobsSelectionFilter = " WHERE SystemJobsTable.MasterCodeBookId_LongInteger = " & CurrentMasterCodeBookSubSystemID.ToString

        JobsSelectionOrder = " ORDER BY JobCode_ShortText30 ASC "



        MySelection = JobsFieldsToSelect & JobsTablesLinks & JobsSelectionFilter '& JobsSelectionOrder



        JustExecuteMySelection()
        '      If RecordCount = 0 Then
        '      SelectProductToolStripMenuItem.Visible = False
        '      EditProductToolStripMenuItem.Visible = False
        '      DeleteProductToolStripMenuItem.Visible = False
        '      SearchProductToolStripTextBox.Visible = False
        ''        Else
        '           DisableModifyMyStandardMode()
        '        End If

        ' FILL DATAGRID
        JobsRecordCount = RecordCount
        JobsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        ' Initialize jobsCodeBookDataGridView
        JobsDataGridView.Columns.Item("SystemJobID_AutoNumber").Visible = False
        JobsDataGridView.Columns.Item("MasterCodeBookId_LongInteger").Visible = False
        JobsDataGridView.Columns.Item("JobID_LongInteger").Visible = False

        JobsDataGridView.Columns.Item(0).HeaderText = CurrentSubSystemCode
        JobsDataGridView.Columns.Item("JobCode_ShortText30").Width = 100

        JobsDataGridView.Columns.Item(1).HeaderText = CurrentSubSystemName
        JobsDataGridView.Columns.Item("JobDescription_ShortText255").Width = 100 * 184 / 15


        JobsDataGridView.Width = 0
        For i = 0 To JobsDataGridView.Columns.GetColumnCount(0) - 1
            If JobsDataGridView.Columns.Item(i).Visible = True Then
                JobsDataGridView.Width = JobsDataGridView.Width + JobsDataGridView.Columns.Item(i).Width
            End If
        Next
        JobsDataGridView.Width = JobsDataGridView.Width + 20
    End Sub


    Private Sub FillProductsDataGridView()
        ProductsFieldsToSelect = "Select " &
            " ProductCode_ShortText30Fld , " &
            " ProductPartID_Autonumber, " &
            " ProductDescription_ShortText250 "

        ProductsTablesLinks = " From  ProductsPartsTable "

        ProductsSelectionFilter = " WHERE mid(ProductCode_ShortText30Fld,1," & Str(Len(CurrentSubSystemCode)) & ") = " & Chr(34) & CurrentSubSystemCode & Chr(34) &
                                    " And trim(MainSystemCode_ShortText1) = " & Chr(34) & Chr(34)

        ProductsSelectionOrder = " ORDER BY ProductCode_ShortText30Fld ASC "

        MySelection = ProductsFieldsToSelect & ProductsTablesLinks & ProductsSelectionFilter & ProductsSelectionOrder
        '       MySelection = ProductsFieldsToSelect & ProductsTablesLinks & ProductsSelectionOrder
        JustExecuteMySelection()
        If RecordCount = 0 Then
            SelectProductToolStripMenuItem.Visible = False
            EditProductToolStripMenuItem.Visible = False
            DeleteProductToolStripMenuItem.Visible = False
            SearchProductToolStripTextBox.Visible = False
        Else
            '           DisableModifyMyStandardMode()
        End If

        ' FILL DATAGRID
        ProductsRecordCount = RecordCount
        ProductsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        ' Initialize ProductsCodeBookDataGridView
        ProductsDataGridView.Columns.Item("ProductPartID_Autonumber").Visible = False

        ProductsDataGridView.Columns.Item(0).HeaderText = CurrentSubSystemCode
        ProductsDataGridView.Columns.Item("ProductCode_ShortText30Fld").Width = 20 * 184 / 15

        ProductsDataGridView.Columns.Item(1).HeaderText = CurrentSubSystemName
        ProductsDataGridView.Columns.Item("ProductDescription_ShortText250").Width = 100 * 184 / 15


        ProductsDataGridView.Width = 0
        For i = 0 To ProductsDataGridView.Columns.GetColumnCount(0) - 1
            If ProductsDataGridView.Columns.Item(i).Visible = True Then
                ProductsDataGridView.Width = ProductsDataGridView.Width + ProductsDataGridView.Columns.Item(i).Width
            End If
        Next
        ProductsDataGridView.Width = ProductsDataGridView.Width + 20
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
        MasterCodeBookDetailsGroup.Text = "Add a New SUB CODE"
        EnableModifyMasterCodeBookMode()          '' Add Edit Delete are turned off and Cancel ans Save options are made available
        SearchMasterCodeBookTextBox.Visible = False
        ProductCodeBookToolStripLabel.Visible = False
        AddProductToolStripMenuItem.Visible = False
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
        MySelection = "select * from MasterCodebookTable " & SubSystemCodeSelectionFilter
        If NoRecordFound() Then
            Exit Sub
        End If
        Dim r As DataRow = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        CurrentParentName = r("SystemDesc_ShortText100Fld")
    End Sub


    Private Sub DeleteTMasterCodeoolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteMasterCodeToolStripMenuItem.Click
        PurposeOfMasterCodeBookDetailsGroupEntry = "DELETE"

        If Not MsgBox("Do you want to continue deleting this RECORD ?", vbYesNo) = vbYes Then
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
        ProductsDataGridView.Enabled = False
        ShowMasterCodeBookDetailsGroup()
    End Sub
    Private Sub DisAbleModifyMasterCodeBookMode()
        EnableAddEditDeleteMasterCodeMenuItems()
        MasterCodeBookDetailsGroup.Visible = False
        MainSystemCodeDataGridView.Enabled = True
        SubSystemCodeDataGridView.Enabled = True
        ProductsDataGridView.Enabled = True
    End Sub
    Private Sub EnableAddEditDeleteMasterCodeMenuItems()
        SelectMasterCodeToolStripMenuItem.Visible = True
        SaveMasterCodeToolStripMenuItem.Visible = False
        AddMasterCodeToolStripMenuItem.Visible = True
        EditTMasterCodeToolStripMenuItem.Visible = True
        CreateProcedureToolStripMenuItem.Visible = True
        DeleteMasterCodeToolStripMenuItem.Visible = True
        SearchMasterCodeBookTextBox.Visible = True
        SearchProductToolStripTextBox.Visible = True

    End Sub
    Private Sub DisableAddEditDeleteMasterCodeMenuItems()
        SaveMasterCodeToolStripMenuItem.Visible = True
        SelectMasterCodeToolStripMenuItem.Visible = False
        AddMasterCodeToolStripMenuItem.Visible = False
        EditTMasterCodeToolStripMenuItem.Visible = False
        CreateProcedureToolStripMenuItem.Visible = False
        DeleteMasterCodeToolStripMenuItem.Visible = False
        SearchMasterCodeBookTextBox.Visible = False
        SearchProductToolStripTextBox.Visible = False
    End Sub

    Private Sub SearchCodeBookTextBox_Click(sender As Object, e As EventArgs) Handles SearchMasterCodeBookTextBox.TextChanged
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

    Private Sub SearchProductToolStripTextBox_Click(sender As Object, e As EventArgs) Handles SearchProductToolStripTextBox.TextChanged
        If Not ProductsDataGridViewInitialized Then Exit Sub
        Dim FindKey As String = Trim(SearchProductToolStripTextBox.Text)
        If FindKey = "" Then Exit Sub

        RecordFinderDbControls.AddParam("@FindKey", "%" & FindKey & "%")


        FillProductsDataGridView()

        MySelection = "Select ProductsPartsTable.ProductCode_ShortText20Fld, " &
                             " ProductsPartsTable.[ProductDetails_ShortText100], " &
                             " BrandTable.BrandName_ShortTextFld, CountryTable.Country_ShortText25 " &
                             " From CountryTable RIGHT Join (BrandTable " &
                                               " INNER Join ProductsPartsTable On BrandTable.BrandID_IntegerFld = ProductsPartsTable.BrandID_LongIntegerFld) " &
                                                         "  ON CountryTable.CountryID_Autonumber = ProductsPartsTable.MadeIn_IntegerFld" &
                         "  WHERE ProductDetails_ShortText100 Like @FindKey " &
                           " ORDER BY ProductCode_ShortText20Fld ASC "
        MySelection = " Select ProductsPartsTable.ProductType_ShortText1, ProductsPartsTable.ProductCode_ShortText20Fld, ProductsPartsTable.PurchasedItemsID_IntegerFld, ProductsPartsTable.ProductDetails_ShortText100, BrandTable.BrandName_ShortTextFld, CountryTable.CountryName_ShortText25
FROM(ProductsPartsTable LEFT JOIN BrandTable On ProductsPartsTable.BrandID_LongIntegerFld = BrandTable.BrandID_Autonumber) LEFT JOIN CountryTable On ProductsPartsTable.MadeIn_IntegerFld = CountryTable.CountryID_Autonumber "
        If NoRecordFound() Then
            Exit Sub
            ProductsRecordCount = 0
        End If
        ProductsRecordCount = RecordCount
        ProductsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable


    End Sub

    Private Sub SearchProductToolStripTextBox_MouseClick(sender As Object, e As MouseEventArgs) Handles SearchProductToolStripTextBox.Click
        If SearchProductToolStripTextBox.Text = "Search" Then SearchProductToolStripTextBox.Text = ""

    End Sub
    Private Sub FindSubCodeSelected(SavedCode)
        FillSubSystemDataGridView()
        '       SubSystemCodeDataGridView.Rows(0).Selected = True
        If Not RecordCount > 0 Then
            Exit Sub

        End If
        Dim CurrentIndex = 0
        Dim whatisthecode = SubSystemCodeDataGridView(0, CurrentIndex).Value
        Dim Exception = ""
        Dim xxx = SubSystemCodeDataGridView.Rows.Count
        If SubSystemCodeDataGridView.Rows.Count > 1 Then
            SubSystemCodeDataGridView.Rows(CurrentIndex).Selected = False

            Try
                '               Do While Not SavedCode = whatisthecode
                '               SubSystemCodeDataGridView.Select()
                '               SubSystemCodeDataGridView.Rows(CurrentIndex).Selected = True
                '               SendKeys.Send("{DOWN}")
                '               CurrentIndex = CurrentIndex + 1
                '               whatisthecode = SubSystemCodeDataGridView(0, CurrentIndex).Value
                '               Loop
                '               CurrentIndex = 0
                For Each row In SubSystemCodeDataGridView.Rows
                    If SavedCode = SubSystemCodeDataGridView(0, CurrentIndex).Value Then

                        SubSystemCodeDataGridView(0, CurrentIndex).Value = SavedCode
                        SubSystemCodeDataGridView.Rows(CurrentIndex).Selected = True
                        '                      SendKeys.Send("{DOWN}")
                        '                      SendKeys.Send("{up}")
                        Exit Try
                    End If
                    CurrentIndex = CurrentIndex + 1

                Next
            Catch ex As Exception
                Exception = ex.Message
                MsgBox(Exception)
                MsgBox("do a break here, to check why")
                Exit Sub
            End Try
        End If

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
            MsgBox("do a break here, to check why")
            Exit Sub
        End Try

    End Sub
    Private Sub UpButton_Click(sender As Object, e As EventArgs) Handles UpButton.Click
        If Len(CurrentSubSystemCode) = 4 Then Exit Sub
        CurrentSubSystemCode = Mid(CurrentSubSystemCode, 1, Len(CurrentSubSystemCode) - 2)
        Dim SavedCode = CurrentSubSystemCode

        FindSubCodeSelected(SavedCode)

    End Sub
    Private Sub ProductsDataGridView_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles ProductsDataGridView.RowHeaderMouseClick
        MsgBox("ProductsDataGridView.RowHeaderMouseClick")
    End Sub


    Private Sub ProductsDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles ProductsDataGridView.CellContentClick
        MsgBox("ProductsDataGridView.CellContentClick")
    End Sub
    Private Sub ProductsDataGridView_MouseClick(sender As Object, e As MouseEventArgs) Handles ProductsDataGridView.MouseClick
        MsgBox("ProductsDataGridView.MouseClick")

        If IsNotEmpty(CurrentProductCode) Then
            CurrentSubSystemCode = Mid(CurrentProductCode, 1, Len(CurrentProductCode) - 2)
        End If
        If Len(CurrentSubSystemCode) = 4 Then Exit Sub
        Dim SavedCode = CurrentSubSystemCode
        CurrentSubSystemCode = Mid(CurrentSubSystemCode, 1, Len(CurrentSubSystemCode) - 2)
        FindSubCodeSelected(SavedCode)
    End Sub

    Private Sub JobsTableDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles JobsDataGridView.RowEnter
        If e.RowIndex < 0 Then Exit Sub
        If ProductsRecordCount < 1 Then Exit Sub
        If Not JobsDataGridViewInitialized Then
            JobsDataGridViewInitialized = True
        End If

        CurrentJobRow = e.RowIndex
        CurrentJobID = JobsDataGridView("JobID_LongInteger", e.RowIndex).Value
    End Sub

    Private Sub ProductsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles ProductsDataGridView.RowEnter
        If e.RowIndex < 0 Then Exit Sub
        If ProductsRecordCount < 1 Then Exit Sub
        If Not ProductsDataGridViewInitialized Then
            ProductsDataGridViewInitialized = True
        End If

        CurrentProductRow = e.RowIndex
        CurrentProductID = ProductsDataGridView("ProductPartID_Autonumber", e.RowIndex).Value
        '     If DetailsGroupBox.Enabled = False Then
        '     If SaveToolStripMenuItem.Visible = False Then
        '     ShowMyStandardDetailsGroupBox()
        '     End If

    End Sub

    Private Sub ProductsDataGridView_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles ProductsDataGridView.RowHeaderMouseDoubleClick
        MsgBox("ProductsDataGridView.RowHeaderMouseDoubleClick")

        Tunnel1 = Trim(ProductsDataGridView.Item("MasterCodeBookID_Autonumber", e.RowIndex).Value)

        Me.Close()
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

        'this portion accepts the code requested
        'coderequested is set by showform routine of the calling form
        If IsEmpty(Tunnel2) Then
            Exit Sub
        End If

        If Tunnel2 > -1 Then
            CurrentVehicleCode = Tunnel2
            CurrentVehicleRepairCode = Tunnel3
            MySelection = "select * from VehicleRepairClassTable WHERE VehicleRepairClassID_AutoNumber = " & Str(CurrentVehicleRepairCode)
            If NoRecordFound() Then
                MsgBox("break, PROBLEM not found, Update Vehicle Repair Class code for thid vehicle ")
                GetDefaultVehicle()
                Exit Sub
            End If
            Dim r As DataRow = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
            Tunnel1 = r("YearManufacturedFrom_ShortText4")

            DefaultVehicleModelRepairRangeTextBox.Text = " Years " & r("YearManufacturedFrom_ShortText4") & " To " & r("YearManufacturedTo_ShortText4")
        End If
        ResetTunnels() ' INFORMATION IN TUNNELS HAVE BEEN RECEIVED

    End Sub

    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click

        If RenumberGroupBox.Visible = True Then
            RenumberGroupBox.Visible = False
            EnableAddEditDeleteMasterCodeMenuItems()
            MainSystemCodeDataGridView.Enabled = True
            SubSystemCodeDataGridView.Enabled = True
            JobsPartsGroupBox.Enabled = True
            Exit Sub
        End If
        Select Case MasterCodeBookDetailsGroup.Visible
            Case True
                Dim FieldChangeOccured = False

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

                If MsgBox("A new code exists in the Child Code, do you want to update the Main Code ?", vbYesNo) = vbYes Then
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

                If MsgBox("A new code exists in the Parent Code, oo you want to update the Child Code ?", vbYesNo) = vbYes Then
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
            MySelection = "select * from MasterCodebookTable " & SubSystemCodeSelectionFilter
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
                MsgBox("this code already exist as " & Tunnel1)
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
                MsgBox("this code already exist as " & Tunnel1)
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
        MySelection = "select * from MasterCodebookTable " & SubSystemCodeSelectionFilter
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

                If Not MsgBox(" Confirm adding new code " & CurrentSubSystemCode & "-" & CurrentSubSystemName, vbYesNo) = vbYes Then
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
                If Not MsgBox(" Confirm Saving changes for " & CurrentSubSystemName & " to " & SystemNameTextBox.Text, vbYesNo) = vbYes Then
                    SystemNameTextBox.Select()
                    Exit Sub
                End If

                Dim RecordFilter = " WHERE MasterCodeBookID_Autonumber = " & Str(CurrentSubSystemCodeBookID)

                Dim UpdateFieldsToSelect = " UPDATE MasterCodeBookTable  SET SystemDesc_ShortText100Fld  = " & Chr(34) & SystemNameTextBox.Text & Chr(34)

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
        FillJobsDataGridView()

        FillProductsDataGridView()


    End Sub

    Private Function SuccessfullyAddingThisMasterCodeBookRecord()

        '  = "2" for subsystem "1" for Main code 3" for parts M- Maintenance  P-Parts

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


    Private Sub ChangeVehicleDefaults_Click(sender As Object, e As EventArgs) Handles ChangeVehicleDefaults.Click
        GetDefaultVehicle()
    End Sub

    Private Sub ContinueButton_Click(sender As Object, e As EventArgs) Handles ContinueButton.Click
        GetDefaultVehicle()
        Dim ProcedureNamePrefix = Str(1000 + CurrentVehicleRepairCode).Substring(2) & CurrentSubSystemCode
        ExcelFileName = DefaultProcedurePath & ProcedureNamePrefix



        ' you need to study this part since the create and open procudue are moved to jobsform

        '        OpenExcelFile(False)
        ServicedVehicleGroupBox.Visible = False
        EnableAddEditDeleteMasterCodeMenuItems()
    End Sub
    Private Sub GetDefaultVehicle()
        Me.Enabled = False
        VehicleDetailsForm.ActivatedBy.Text = Me.Name
        VehicleDetailsForm.Show()

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
        ServicedVehicleGroupBox.Visible = True
    End Sub
    Private Sub DefaultVehicleModelTextBox_Leave(sender As Object, e As EventArgs) Handles DefaultVehicleModelTextBox.Leave
        ServicedVehicleGroupBox.Visible = False

    End Sub
    Private Sub RenumberToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RenumberToolStripMenuItem.Click

        RenumberGroupBox.Visible = True
        DisableAddEditDeleteMasterCodeMenuItems()
        OldNumberTextBox.Text = CurrentSubSystemCode
        NewNumberTextBox.Text = ""
        MainSystemCodeDataGridView.Enabled = False
        SubSystemCodeDataGridView.Enabled = False

        JobsPartsGroupBox.Enabled = False

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles GoRenumberButton.Click
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
        ' CHECK HOW MANY PRODUCTS WILL BE RENUMBERED
        Dim NoOfConnectedProducts = ""
        If ProductsRecordCount > 0 Then
            NoOfConnectedProducts = " AND " & Str(ProductsRecordCount) & " related part(s) "
        End If
        If MsgBox(ThereIsThereAre & Str(RecordCount) & ARecords & " found to be renumbered, " & NoOfConnectedProducts & " CONTINUE renumbering " & ThisThese, vbYesNo) = vbNo Then
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

            ' RENUMBER THE PRODUCTS TOO if exist(s)
            If ProductsRecordCount > 0 Then

                UpdateFieldsToSelect = " UPDATE ProductsPartsTable  SET ProductCode_ShortText20Fld  = " & "(" & Chr(34) &
                                    Trim(NewNumberTextBox.Text) & Chr(34) & " & Mid(ProductCode_ShortText20Fld," & Str(1 + Len(Trim(OldNumberTextBox.Text))) &
                                    "," & Str(100 - Len(Trim(NewNumberTextBox.Text))) & "))"

                RecordFilter = " WHERE mid(ProductCode_ShortText20Fld,1," & Str(Len(Trim(OldNumberTextBox.Text))) & ") = " & Chr(34) & Trim(OldNumberTextBox.Text) & Chr(34)

                MySelection = UpdateFieldsToSelect & RecordFilter
                If NoRecordFound() Then Dim dummy = 1
            End If

            Do While True
                Dim OldExcelFileName = ""
                Dim NewExcelFileName = ""
                Dim OldProcedureName = Str(1000 + CurrentVehicleRepairCode).Substring(2) & CurrentSubSystemCode & "*"
                OldExcelFileName = DefaultProcedurePath & OldProcedureName & ".xls"
                ProcedureExists = Dir(OldExcelFileName, vbHidden)
                If ProcedureExists = "" Then
                    Exit Do
                End If
                OldExcelFileName = DefaultProcedurePath & ProcedureExists '& ".xls"

                '       Dim vehiclecode = Str(1000 + CurrentVehicleRepairCode).Substring(2)
                '       Dim TrailingName = Mid(ProcedureExists, 4 + Len(Trim(OldNumberTextBox.Text)))

                Dim NewProcedureName As String = Replace(ProcedureExists, OldNumberTextBox.Text, NewNumberTextBox.Text)
                ProcedureExists = Dir(NewProcedureName, vbHidden)
                If Not ProcedureExists = "" Then
                    MsgBox("Can not rename " & OldProcedureName & ", File " & ProcedureExists & " already exists")
                End If

                '      Dim NewProcedureName = vehiclecode & Trim(NewNumberTextBox.Text) & TrailingName

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
            FindSubCodeSelected(Trim(CurrentSubSystemCode))

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
        JobsPartsGroupBox.Enabled = True
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
        Dim SavedCode = SubSystemCodeDataGridView(0, e.RowIndex).Value
        FindSubCodeSelected(CurrentSubSystemCode)

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
        FindSubCodeSelected(CurrentSubSystemCode)
        SubSystemCodeDataGridView.Select()
        SubSystemCodeDataGridView.Rows(CurrentSubSystemCodeRow).Selected = True

    End Sub

    Private Sub AddProductToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddProductToolStripMenuItem.Click

        ' Tunnels 1, 2 And 3 maybe used input data to the called form. See FORM - event Load
        ' This would affect event Me.EnabledChanged	

        Me.Enabled = False
        ' some cases may enable the calling form for the called form to automatically display related informations.
        JobsForm.ProcedureNamePrefix = ProcedureNamePrefix
        JobsForm.CurrentSubSystemCode = CurrentSubSystemCode
        JobsForm.CurrentVehicleRepairCode = CurrentVehicleRepairCode
        JobsForm.CurrentParentName = CurrentParentName
        JobsForm.CurrentSubSystemName = CurrentSubSystemName
        JobsForm.ActivatedByTextBox.Text = Me.Name
        ' name of activating form is passed on to the form to activate
        Tunnel3 = ProcedureNamePrefix
        JobsForm.Show()

    End Sub
End Class