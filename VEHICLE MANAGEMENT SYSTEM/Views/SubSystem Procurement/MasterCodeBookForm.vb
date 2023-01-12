Imports System.Data.SqlClient
Imports excel = Microsoft.Office.Interop.Excel
Public Class MasterCodeBookForm
    Private CurrentSubSystemCodeBookID As Integer
    Public CurrentMainSystemCode As String
    Private CurrentMainSystemName As String
    Private CurrentMainCodeLength As Integer
    Private CurrentMainCodeColumn As Integer
    Private CurrentMainSystemCodeRow As Integer

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

    Private CurrentCodeInformationsHeaderRelationID As Integer
    Private CurrentCodeInformationsHeaderRelationRow As Integer
    Private CurrentInformationHeaderID = -1
    Private CodeInformationsHeaderRelationsDataGridViewInitialized = False
    Private CodeInformationsHeaderRelationsRecordCount As Integer = 0

    Private CodeInformationsHeaderRelationsFieldsToSelect = ""
    Private CodeInformationsHeaderRelationsTablesLinks = ""
    Private CodeInformationsHeaderRelationsSelectionFilter = ""
    Private CodeInformationsHeaderRelationsSelectionFilterSaved = ""
    Private CodeInformationsHeaderRelationsSelectionOrder = ""

    Private PurposeOfMasterCodeBookDetailsGroupEntry = "ADD"

    Private Siblings As String = ""
    Private Children As String = ""
    Private SubMainFilter = ""

    Private MasterCodeBookFieldsValues = ""
    Private MasterCodeBookFieldsToReplace = ""

    Private DefaultProcedurePath = DefaultSystemPath & "\Procedures\"
    Private ExcelFileName = ""
    Private ProcedureExists = ""
    Private ProcedureName = ""
    Private SearchIsOnFlag = True
    Private ChangeItemDefaultEnabled = False
    Private SavedCallingForm As Form
    Private FixedMasterCodeId = False

    Private Sub MasterCodeBookForm_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        SavedCallingForm = CallingForm
        ' NOTE ON ENTRY TUNNEL THREE WILL CONTAIN THE SUBCODE IF REFERRING TO A SPECIFIC RECORD
        If CurrentWorkOrderID > -1 Then DefaultVehicleModelTextBox.Text = CurrentVehicleString
        MasterCodeBookDetailsGroup.Location = New Point(50, 85)
        If DefaultVehicleModelTextBox.Text = "Set Default Vehicle" Then
            CurrentVehicleID = -1
        End If
        FillMainSystemCodeDataGridView()
        Select Case SavedCallingForm.Name
            Case "ConcernsForm"
                SelectCodeInformationsHeaderRelationsToolStripMenuItem.Visible = False
                CodeInformationsHeaderRelationsToolStripLabel.Visible = False
                AddCodeInformationsHeaderRelationsToolStripMenuItem.Visible = False
                RemoveCodeInformationsHeaderRelationToolStripMenuItem.Visible = False
                InformationDetailsToolStripLabel.Visible = False
                CreateInformationDetailsToolStripMenuItem.Visible = False
            Case "JobsForm"
                SearchMasterCodeBookTextBox.Text = JobsForm.SearchJobTextBox.Text
            Case "WorkOrderFormASM"
                CurrentMasterCodeBookSubSystemID = Tunnel1
                FixedMasterCodeId = True
                MainSystemCodeDataGridView.Enabled = False
                FillSubSystemDataGridView()
            Case "StoreRequisitionsForm"
                AddCodeInformationsHeaderRelationsToolStripMenuItem.Visible = False
        End Select
        If Not SearchMasterCodeBookTextBox.Text = "" Then EnableSearch()
        SearchGroupBox.Top = MainSystemCodeDataGridView.Top
        SearchGroupBox.Left = DefaultVehicleModelTextBox.Left
    End Sub

    Private Sub SelectMasterCodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectMasterCodeToolStripMenuItem.Click
        Tunnel1 = "Tunnel2IsMasterCodeBookID"
        Tunnel2 = CurrentMasterCodeBookSubSystemID
        Tunnel3 = SubSystemCodeDataGridView.Item("SystemDesc_ShortText100Fld", CurrentSubSystemCodeRow).Value
        Tunnel4 = CurrentSubSystemCode

        DoCommonHouseKeeping(Me, SavedCallingForm)

    End Sub

    Private Sub FillMainSystemCodeDataGridView()
        Dim MainSystemCodeInQuote = InQuotes("1")
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
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then
            Exit Sub
        End If
        CurrentMainSystemCodeRow = e.RowIndex
        CurrentMainSystemName = Trim(MainSystemCodeDataGridView.Item(1, CurrentMainSystemCodeRow).Value)
        CurrentMainSystemCode = LTrim(RTrim(MainSystemCodeDataGridView.Item(0, CurrentMainSystemCodeRow).Value))
        Dim first2codes = "(Mid(SubSystemCode_ShortText24Fld,1,2) = " & InQuotes(CurrentMainSystemCode)
        Dim LengthOf4 = " And Len(Trim(SubSystemCode_ShortText24Fld)) = 4 )"
        Siblings = first2codes & LengthOf4
        Children = " (mid(SubSystemCode_ShortText24Fld,1,4) = " & InQuotes(CurrentMainSystemCode & "01") & ")"
        CurrentSubSystemCode = CurrentMainSystemCode & "01"
        CurrentSubSystemName = ""
        FillSubSystemDataGridView()
        If RecordCount > 0 Then SubSystemCodeDataGridView.Rows(0).Selected = True
    End Sub

    Private Sub FillSubSystemDataGridView()
        If FixedMasterCodeId Then
            SubSystemCodeSelectionFilter = "  WHERE MasterCodeBookID_Autonumber = " & CurrentMasterCodeBookSubSystemID.ToString

        Else
            Dim SubCodeLength = Len(Trim(CurrentSubSystemCode))
            Dim Parent = "Mid(SubSystemCode_ShortText24Fld,1," & Str(SubCodeLength - 2) & ")"
            CurrentParentCode = Parent & " = " & Mid(CurrentSubSystemCode, 1, SubCodeLength - 2)
            Dim ParentKeyLength = " And Len(Trim(SubSystemCode_ShortText24Fld)) = " & Str(SubCodeLength)
            Siblings = "(" & CurrentParentCode & ParentKeyLength & ")"
            Children = " (mid(SubSystemCode_ShortText24Fld,1," & Str(Len(Trim(CurrentSubSystemCode))) & ") = " & InQuotes(CurrentSubSystemCode) & ")"
            Dim ChildrenLength = " And Len(Trim(SubSystemCode_ShortText24Fld)) = " & Str(SubCodeLength + 2)
            Dim GrandChildren = ""
            If IncludeGrandChildren Then
                Children = "(" & Children & ")"
            Else
                Children = "(" & Children & ChildrenLength & ")"
            End If

            SubSystemCodeFieldsToSelect = "Select " &
                " SubSystemCode_ShortText24Fld, " &
                " SystemDesc_ShortText100Fld, " &
                " MasterCodeBookID_Autonumber "
            SubSystemCodeTablesLinks = " FROM MasterCodeBookTable "
            If SearchIsOnFlag = True Then
                SearchIsOnFlag = False
                SubSystemCodeSelectionFilter = "  WHERE SystemDesc_ShortText100Fld Like " & InQuotes("%" & Trim(SearchMasterCodeBookTextBox.Text) & "%")
            Else
                SubSystemCodeSelectionFilter = "where " & Siblings & " Or " & Children
                If Len(Trim(CurrentSubSystemCode)) = 2 Then
                    SubSystemCodeSelectionFilter = " WHERE " & Children
                End If
            End If

        End If

        SubSystemCodeSelectionOrder = " ORDER BY SubSystemCode_ShortText24Fld "

        MySelection = SubSystemCodeFieldsToSelect & SubSystemCodeTablesLinks & SubSystemCodeSelectionFilter & SubSystemCodeSelectionOrder

        JustExecuteMySelection()
        SubSystemCodeDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        SubSystemCodeDataGridView.Columns("MasterCodeBookID_Autonumber").Visible = False

        SubSystemCodeDataGridView.Columns.Item("SubSystemCode_ShortText24Fld").Width = 135
        SubSystemCodeDataGridView.Columns.Item("SystemDesc_ShortText100Fld").Width = 400
        SubSystemCodeDataGridView.Columns.Item("SubSystemCode_ShortText24Fld").HeaderText = CurrentMainSystemCode
        SubSystemCodeDataGridView.Columns.Item("SystemDesc_ShortText100Fld").HeaderText = Trim(MainSystemCodeDataGridView.Item(CurrentMainCodeColumn + 1, CurrentMainSystemCodeRow).Value)

        ' FILL DATAGRID

    End Sub

    Private Sub SubSystemCodeDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles SubSystemCodeDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        InfoDetailsTextBox.Text = ""
        CurrentSubSystemCodeRow = e.RowIndex

        CurrentSubSystemName = Trim(SubSystemCodeDataGridView.Item(CurrentSubCodeColumn + 1, CurrentSubSystemCodeRow).Value)
        CurrentSubSystemCode = LTrim(RTrim(SubSystemCodeDataGridView.Item(0, CurrentSubSystemCodeRow).Value))
        CurrentSubSystemCodeBookID = LTrim(RTrim(SubSystemCodeDataGridView.Item("MasterCodeBookID_Autonumber", CurrentSubSystemCodeRow).Value))
        DeleteMasterCodeToolStripMenuItem.Visible = False
        CurrentMasterCodeBookSubSystemID = SubSystemCodeDataGridView.Item("MasterCodeBookID_Autonumber", CurrentSubSystemCodeRow).Value

        FillCodeInformationsHeaderRelationsDataGridView()
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
            MsgBox(CurrentSubSystemCode & " allow adding missing link")
            If Not SuccessfullyAddingThisMasterCodeBookRecord() Then
                MsgBox("UNSECCESSFULL INSERT!!!! Of missing link record")
            Else
                MsgBox("missing link record inserted")
                MsgBox("missing link record insertion was temporarily removed, no action was done here")
            End If
            Exit Sub
        End If

        ' GET FIRST ROW FOUND
        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)

        ' Update Parent header values here 
        SubSystemCodeDataGridView.Columns("SubSystemCode_ShortText24Fld").HeaderText = r("SubSystemCode_ShortText24Fld")
        SubSystemCodeDataGridView.Columns("SystemDesc_ShortText100Fld").HeaderText = r("SystemDesc_ShortText100Fld")
        CurrentParentName = r("SystemDesc_ShortText100Fld")

    End Sub
    Private Sub FillCodeInformationsHeaderRelationsDataGridView()
        Dim CoinedInformation = " InformationsHeadersTypeTable.Prefix  & Space(1) & MasterCodeBookPartReference.SystemDesc_ShortText100Fld AS CoinedInformation, "
        CodeInformationsHeaderRelationsFieldsToSelect = " 
Select " & CoinedInformation &
" 
CodeInformationsHeaderRelationsTable.CodeInformationsHeaderRelationID_AutoNumber, 
CodeInformationsHeaderRelationsTable.MasterCodeBookId_LongInteger, 
CodeInformationsHeaderRelationsTable.InformationsHeaderID_LongInteger, 
InformationsHeadersTypeTable.Prefix,
MasterCodeBookPartReference.SystemDesc_ShortText100Fld, 
InformationsHeadersTable.InformationsHeaderDescription_ShortText255
FROM ((CodeInformationsHeaderRelationsTable LEFT JOIN InformationsHeadersTable ON CodeInformationsHeaderRelationsTable.InformationsHeaderID_LongInteger = InformationsHeadersTable.InformationsHeaderID_AutoNumber) LEFT JOIN MasterCodeBookTable AS MasterCodeBookPartReference ON InformationsHeadersTable.MasterCodeBookId_LongInteger = MasterCodeBookPartReference.MasterCodeBookID_Autonumber) LEFT JOIN InformationsHeadersTypeTable ON InformationsHeadersTable.InformationsHeadersTypeID_LongInteger = InformationsHeadersTypeTable.InformationsHeadersTypeID_AutoNumber
"
        'FILTERS ALL INFORMATIONS ABOUT CURRENT MasterCodeBookID
        CodeInformationsHeaderRelationsSelectionFilter = " WHERE CodeInformationsHeaderRelationsTable.MasterCodeBookId_LongInteger = " & CurrentMasterCodeBookSubSystemID
        CodeInformationsHeaderRelationsSelectionOrder = " ORDER BY SubSystemCode_ShortText24Fld "

        MySelection = CodeInformationsHeaderRelationsFieldsToSelect & CodeInformationsHeaderRelationsSelectionFilter & CodeInformationsHeaderRelationsSelectionOrder

        JustExecuteMySelection()
        CodeInformationsHeaderRelationsRecordCount = RecordCount
        If CodeInformationsHeaderRelationsRecordCount = 0 Then
            SelectCodeInformationsHeaderRelationsToolStripMenuItem.Visible = False
            EditCodeInformationsHeaderRelationsToolStripMenuItem.Visible = False
            RemoveCodeInformationsHeaderRelationToolStripMenuItem.Visible = False
            InformationDetailsToolStripLabel.Visible = False
        Else
            SelectCodeInformationsHeaderRelationsToolStripMenuItem.Visible = True
            EditCodeInformationsHeaderRelationsToolStripMenuItem.Visible = True
            RemoveCodeInformationsHeaderRelationToolStripMenuItem.Visible = True
            InformationDetailsToolStripLabel.Visible = True
        End If
        CodeInformationsHeaderRelationsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        If Not CodeInformationsHeaderRelationsDataGridViewInitialized Then
            FormatInformationsHeadersCodeBookDataGridView()
        End If
    End Sub
    Private Sub FormatInformationsHeadersCodeBookDataGridView()
        CodeInformationsHeaderRelationsDataGridViewInitialized = True
        CodeInformationsHeaderRelationsDataGridView.Width = 0
        For i = 0 To CodeInformationsHeaderRelationsDataGridView.Columns.GetColumnCount(0) - 1

            CodeInformationsHeaderRelationsDataGridView.Columns.Item(i).Visible = False
            Select Case CodeInformationsHeaderRelationsDataGridView.Columns.Item(i).Name

                Case "CoinedInformation"
                    CodeInformationsHeaderRelationsDataGridView.Columns.Item(i).HeaderText = "INFORMATION"
                    CodeInformationsHeaderRelationsDataGridView.Columns.Item(i).Width = 300
                    CodeInformationsHeaderRelationsDataGridView.Columns.Item(i).Visible = True
                Case "InformationsHeaderDescription_ShortText255"
                    CodeInformationsHeaderRelationsDataGridView.Columns.Item(i).HeaderText = "ShortText255 old"
                    CodeInformationsHeaderRelationsDataGridView.Columns.Item(i).Width = 300
                    CodeInformationsHeaderRelationsDataGridView.Columns.Item(i).Visible = True
            End Select
            If CodeInformationsHeaderRelationsDataGridView.Columns.Item(i).Visible = True Then
                CodeInformationsHeaderRelationsDataGridView.Width = CodeInformationsHeaderRelationsDataGridView.Width + CodeInformationsHeaderRelationsDataGridView.Columns.Item(i).Width
            End If
        Next
        CodeInformationsHeaderRelationsDataGridView.Width = CodeInformationsHeaderRelationsDataGridView.Width + 20
    End Sub
    Private Sub CodeInformationsHeaderRelationsTableDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles CodeInformationsHeaderRelationsDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then
            Exit Sub
        End If

        CurrentCodeInformationsHeaderRelationRow = e.RowIndex
        CurrentCodeInformationsHeaderRelationID = CodeInformationsHeaderRelationsDataGridView("CodeInformationsHeaderRelationID_AutoNumber", CurrentCodeInformationsHeaderRelationRow).Value
        CurrentInformationHeaderID = CodeInformationsHeaderRelationsDataGridView("InformationsHeaderID_LongInteger", CurrentCodeInformationsHeaderRelationRow).Value
        If DefaultVehicleModelTextBox.Text = "Set Default Vehicle" Then
            SetDefaultVehicleLabel.Visible = True
            Exit Sub
        End If



        Dim XXVehicleRepairClassID_LongInteger = GetFieldValue("VehiclesTable", "VehicleID_AutoNumber", CurrentVehicleID, "VehicleRepairClassID_LongInteger")


        InfoDetailsTextBox.Text = ""
        Dim FileName = CodeInformationsHeaderRelationsDataGridView.Item("InformationsHeaderDescription_ShortText255", CurrentCodeInformationsHeaderRelationRow).Value
        MySelection = " Select * FROM InfoPerVehicleTable WHERE CodeInformationsHeaderRelationID_LongInteger = " & CurrentInformationHeaderID &
                                                        " and VehicleRepairClassID_LongInteger = " & XXVehicleRepairClassID_LongInteger
        JustExecuteMySelection()
        Dim FileNameFound = False
        If RecordCount > 1 Then FileNameFound = True
        If FileNameFound Then
            Dim r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
            FileName = r("FileName_ShortText255")
            ProcedureName = FileName
        Else

            ProcedureName = Str(1000 + CurrentVehicleRepairClassID).Substring(2) & (10000 + Val(CurrentInformationHeaderID)).ToString & FileName
            ProcedureName = Replace(ProcedureName, "/", "")
            ProcedureName = Replace(ProcedureName, ":", "")

        End If

        Dim OldFormatExcelFileName = DefaultProcedurePath & ProcedureName & ".xlsx"
        ExcelFileName = DefaultProcedurePath & ProcedureName & ".xlsx"
        If FileNameFound Then
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
            If CurrentVehicleRepairClassID > 0 Then                                        ' If the vehicle model is not set creation and opening of procedures are not provided
                ' and no deletion of child is allowed
                CreateInformationDetailsToolStripMenuItem.Visible = True

                ' *********                                                             IF EXISTS ALLOW OPENING ELSE ALLOW CREATE

                If Not ProcedureExists = "" Then
                    CreateInformationDetailsToolStripMenuItem.Text = "Open Informations"
                Else
                    CreateInformationDetailsToolStripMenuItem.Text = "CREATE Informations"
                End If

                ' *********                                                             IF EXISTS ALLOW OPENING ELSE ALLOW CREATE

            Else
                CreateInformationDetailsToolStripMenuItem.Text = ""
            End If
        Else
            If Not ProcedureExists = "" Then
                OpenInfoDetailFile(ExcelFileName)
                CreateInformationDetailsToolStripMenuItem.Text = "Open Informations"
                InfoDetailsTextBox.Text = Trim(InfoDetailsTextBox.Text)
                InfoDetailsTextBox.Text = Replace(InfoDetailsTextBox.Text, vbCrLf & vbTab & vbTab & vbTab, "")

            Else

                CreateInformationDetailsToolStripMenuItem.Text = "CREATE Informations"
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

    Private Sub SubSystemCodeDataGridView_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles SubSystemCodeDataGridView.RowHeaderMouseDoubleClick
        '     Tunnel1 = Trim(SubSystemCodeDataGridView"MasterCodeBookID_Autonumber", e.RowIndex).Value)
        Tunnel1 = Val(SubSystemCodeDataGridView.Item("MasterCodeBookID_Autonumber", e.RowIndex).Value)
        Tunnel2 = "Tunnel1IsMasterCode"
        Select Case SavedCallingForm.Name
            Case "ConcernsForm"
                ConcernsForm.ConcernTextBox.Text = SubSystemCodeDataGridView.Item("SystemDesc_ShortText100Fld", e.RowIndex).Value
            Case Else
                Dim xxx = 1
        End Select
        DoCommonHouseKeeping(Me, SavedCallingForm)
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
        CodeInformationsHeaderRelationsToolStripLabel.Visible = False
        AddCodeInformationsHeaderRelationsToolStripMenuItem.Visible = False
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
        Dim ParentSearchKey = ParentFieldToSearch & " = " & InQuotes(CurrentParentCode)
        Dim ParentKeyLength = " And Len(Trim(SubSystemCode_ShortText24Fld)) = " & Str(Len(Trim(CurrentSubSystemCode)) - 2)
        SubSystemCodeSelectionFilter = " where " & ParentSearchKey & ParentKeyLength
        MySelection = "Select * from MasterCodebookTable " & SubSystemCodeSelectionFilter
        If NoRecordFound() Then
            Exit Sub
        End If
        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
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
        CreateInformationDetailsToolStripMenuItem.Visible = True
        DeleteMasterCodeToolStripMenuItem.Visible = True

    End Sub
    Private Sub DisableAddEditDeleteMasterCodeMenuItems()
        SaveMasterCodeToolStripMenuItem.Visible = True
        SelectMasterCodeToolStripMenuItem.Visible = False
        AddMasterCodeToolStripMenuItem.Visible = False
        EditTMasterCodeToolStripMenuItem.Visible = False
        CreateInformationDetailsToolStripMenuItem.Visible = False
        DeleteMasterCodeToolStripMenuItem.Visible = False
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

    Private Sub OriginalFindSubCodeSelected(SavedCode)
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

    Private Sub MasterCodeBookForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        If Me.Enabled = False Then Exit Sub
        CallingForm = SavedCallingForm
        Select Case Tunnel1
            Case "Tunnel2IsVehicleID"
                SetDefaultVehicleLabel.Visible = False
                MsgBox("please pause and check same Tunnel2IsVehicleID case below")
                CurrentVehicleID = Tunnel2
                DefaultVehicleModelTextBox.Text = Tunnel3
            Case "Tunnel2IsVehicleID"
                DefaultVehicleModelTextBox.Text = Tunnel3
                CurrentVehicleRepairClassID = Tunnel2
                MySelection = "Select * from VehicleRepairClassTable WHERE VehicleRepairClassID_AutoNumber = " & Str(CurrentVehicleRepairClassID)
                If NoRecordFound() Then
                    MsgBox("break, PROBLEM Not found, Update Vehicle Repair Class code For thid vehicle ")
                    GetDefaultVehicle()
                    Exit Sub
                End If
                r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
                Tunnel1 = r("YearManufacturedFrom_ShortText4")

                DefaultVehicleModelRepairRangeTextBox.Text = " Years " & r("YearManufacturedFrom_ShortText4") & " To " & r("YearManufacturedTo_ShortText4")

            Case "Tunnel2IsInformationsHeaderID"
                ' check if vehicle and header information already exist

                Dim SavedCodeInformationsHeaderRelationsSelectionFilter = CodeInformationsHeaderRelationsSelectionFilter


                Dim CodeInformationsHeaderRelationsSelectionFilter1 = " MasterCodeBookId_LongInteger = " & CurrentMasterCodeBookSubSystemID.ToString
                Dim CodeInformationsHeaderRelationsSelectionFilter3 = " InformationsHeaderID_LongInteger = " & Tunnel2.ToString

                CodeInformationsHeaderRelationsSelectionFilter = " WHERE " & CodeInformationsHeaderRelationsSelectionFilter1 & " And " &
                                                                 CodeInformationsHeaderRelationsSelectionFilter3

                MySelection = " sELECT * FROM CodeInformationsHeaderRelationsTable " &
                              CodeInformationsHeaderRelationsSelectionFilter

                JustExecuteMySelection()
                If RecordCount = 0 Then
                    InsertANewCodeInformationsHeaderRelations(Tunnel2)
                End If

                CodeInformationsHeaderRelationsSelectionFilter = SavedCodeInformationsHeaderRelationsSelectionFilter
                FillCodeInformationsHeaderRelationsDataGridView()
        End Select

    End Sub
    Private Sub InsertANewInfoPerVehicleTable()

        MySelection = " Select top 1 * FROM InfoPerVehicleTable WHERE CodeInformationsHeaderRelationID_LongInteger = " & CurrentCodeInformationsHeaderRelationID.ToString &
                                                                " And VehicleRepairClassID_LongInteger = " & CurrentVehicleRepairClassID.ToString

        JustExecuteMySelection()
        If RecordCount > 0 Then
            MsgBox("Selected Information already attached ")
            Exit Sub
        End If

        Dim FieldsToUpdate = " ( " &
                    " CodeInformationsHeaderRelationID_LongInteger, " &
                    " VehicleRepairClassID_LongInteger, " &
                    " FileName_ShortText255" & ")"


        Dim ReplacementData = "(" &
                    CurrentCodeInformationsHeaderRelationID.ToString & ", " &
                    CurrentVehicleRepairClassID.ToString & ", " &
                    InQuotes(ProcedureName) & ")"


        MySelection = "INSERT INTO InfoPerVehicleTable  " & FieldsToUpdate & " VALUES " & ReplacementData

        JustExecuteMySelection()

        MySelection = " Select top 1 * FROM InfoPerVehicleTable WHERE CodeInformationsHeaderRelationID_LongInteger = " & CurrentCodeInformationsHeaderRelationID.ToString &
                                                                " And VehicleRepairClassID_LongInteger = " & CurrentVehicleRepairClassID.ToString

        JustExecuteMySelection()

        Dim r As DataRow

        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        Dim currentFileReferenceID = r("FileReferenceID_AutoNumber")

        MySelection = " UPDATE CodeInformationsHeaderRelationsTable  Set FileReferenceID_LongInteger  = " & currentFileReferenceID.ToString
        JustExecuteMySelection()


    End Sub
    Private Sub InsertANewCodeInformationsHeaderRelations(InformationsHeaderID_LongInteger)

        Dim FieldsToUpdate = " MasterCodeBookId_LongInteger, " &
                              " InformationsHeaderID_LongInteger "

        Dim FieldsData = CurrentMasterCodeBookSubSystemID.ToString & ", " &
                         InformationsHeaderID_LongInteger.ToString



        CurrentCodeInformationsHeaderRelationID = InsertNewRecord("CodeInformationsHeaderRelationsTable", FieldsToUpdate, FieldsData)

        FillCodeInformationsHeaderRelationsDataGridView()
        'UPDATE InformationsHeadersTable AND MARK FIELD Selected true
        UpdateTable("InformationsHeadersTable", "SET Selected = True", "WHERE InformationsHeaderID_AutoNumber = " & CurrentInformationHeaderID)

    End Sub

    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        Tunnel2 = -1
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
                ParentSystemCodeTextBox.Enabled = True
                ChildSystemCodeTextBox.Enabled = True
                DisAbleModifyMasterCodeBookMode()
            Case Else
                DoCommonHouseKeeping(Me, SavedCallingForm)
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
            Dim ParentSearchKey = ParentFieldToSearch & " = " & InQuotes(NewSearchCode)
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
        Dim ParentSearchKey = ParentFieldToSearch & " = " & InQuotes(CurrentSubSystemCode)
        Dim ParentKeyLength = " And Len(Trim(SubSystemCode_ShortText24Fld)) = " & Str(Len(Trim(CurrentSubSystemCode)))
        SubSystemCodeSelectionFilter = " where " & ParentSearchKey & ParentKeyLength
        MySelection = "Select * from MasterCodebookTable " & SubSystemCodeSelectionFilter
        If NoRecordFound() Then
            Return False
        End If
        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
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

                Dim UpdateFieldsToSelect = " UPDATE MasterCodeBookTable  Set SystemDesc_ShortText100Fld  = " & InQuotes(SystemNameTextBox.Text)

                MySelection = UpdateFieldsToSelect & RecordFilter
                If NoRecordFound() Then Dim dummy = 1

            Case Else
                Dim XXXX = 1
        End Select
        DisAbleModifyMasterCodeBookMode()

        FillSubSystemDataGridView()
        If RecordCount = 0 Then
            MsgBox("check this, record count is 0")
        End If
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
        FillCodeInformationsHeaderRelationsDataGridView()

    End Sub

    Private Function SuccessfullyAddingThisMasterCodeBookRecord()

        '  = "2" for subsystem "1" for Main code 3" For parts M- Maintenance  P-Parts

        MasterCodeBookFieldsToReplace = "" &
            "MainSystemCode_ShortText1, " &
            "SubSystemCode_ShortText24Fld, " &
            "SystemDesc_ShortText100Fld "

        MasterCodeBookFieldsValues = "" &
            InQuotes("2") & ", " &
            InQuotes(CurrentSubSystemCode) & ", " &
            InQuotes(CurrentSubSystemName.ToUpper)

        MySelection = "INSERT INTO MasterCodeBookTable  (" & MasterCodeBookFieldsToReplace & ") VALUES (" & MasterCodeBookFieldsValues & ")"

        JustExecuteMySelection()

        MySelection = "SELECT * FROM MasterCodeBookTable  WHERE TRIM(SubSystemCode_ShortText24Fld) = " & InQuotes(CurrentSubSystemCode)
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

    Private Sub GetDefaultVehicle()
        ShowCalledForm(Me, VehiclesForm)
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
            xlWorkSheet.Cells(3, 1).Select()
            xlWorkSheet.Paste()

            InfoDetailsTextBox.Paste()

            xlWorkSheet.Cells.Select()

            Dim formatRange As excel.Range
            formatRange = xlWorkSheet.Range("a1", "c100")

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

        InfoDetailsTextBox.Paste()

        Clipboard.SetText(" ")
        Clipboard.Clear()

        xlApp.Quit()
        ReleaseObject(xlWorkSheet)
        ReleaseObject(xlWorkBook)
        ReleaseObject(xlApp)

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
        InfoDetailsTextBox.Paste()
        InfoDetailsTextBox.Text = Trim(InfoDetailsTextBox.Text)
        InfoDetailsTextBox.Text = Replace(InfoDetailsTextBox.Text, "vbTab & vbTab & vbTab & ", "")
        InfoDetailsTextBox.Text = Replace(InfoDetailsTextBox.Text, "vbCrLf & vbCrLf & ", "")

        Clipboard.SetText(" ")
        Clipboard.Clear()

        xlApp.Quit()
        ReleaseObject(xlWorkSheet)
        ReleaseObject(xlWorkBook)
        ReleaseObject(xlApp)

    End Sub
    Private Sub ReleaseObject(ByVal obj As Object)
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
        ' CHECK 1ST IF THE NEW CODE ALREADY EXISTs using SubSystemCode_ShortText24Fld

        Dim SavedSubSystemCodeFieldsToSelect = SubSystemCodeFieldsToSelect

        ' CHECK THAT THE NEW CODE DOES EXIST

        MySelection = " SELECT SubSystemCode_ShortText24Fld,  SystemDesc_ShortText100Fld FROM MasterCodeBookTable 
                                        WHERE mid(SubSystemCode_ShortText24Fld,1," & Str(Len(Trim(NewNumberTextBox.Text))) & ") = " & InQuotes(Trim(NewNumberTextBox.Text)) &
                                        SubSystemCodeSelectionOrder
        JustExecuteMySelection()
        If RecordCount > 0 Then
            If RecordCount > 0 Then
                MsgBox("That number already exist")
                Exit Sub
            End If
        End If

        ' now SELECT ALL records  TO BE REPLACED
        ' STARTING FROM THE GIVEN BASE CODES AND ITS CHILDREN

        MySelection = " SELECT MasterCodeBookID_Autonumber, SubSystemCode_ShortText24Fld,  SystemDesc_ShortText100Fld FROM MasterCodeBookTable 
                                        WHERE mid(SubSystemCode_ShortText24Fld,1," & Str(Len(Trim(OldNumberTextBox.Text))) & ") = " & InQuotes(Trim(OldNumberTextBox.Text)) &
                                        SubSystemCodeSelectionOrder
        JustExecuteMySelection()

        ' THEN LOAD THE RECORDS IN THE SubSystemCodeDataGridView
        SubSystemCodeDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        Dim ThisThese = ""
        Dim ThereIsThereAre = ""
        Dim ARecords = ""
        If RecordCount = 1 Then
            ThisThese = "this record ?"
            ThereIsThereAre = "There is "
            ARecords = " record"
        Else
            ThisThese = "these records ?"
            ThereIsThereAre = "There are "
            ARecords = " records"
        End If
        ' CHECK HOW MANY InfoPerVehicle WILL BE RENUMBERED
        Dim InfoPerVehicleRecordCount = 0

        If MsgBox(ThereIsThereAre & Str(RecordCount) & ARecords & " found to be renumbered, " & " CONTINUE renumbering " & ThisThese, vbYesNo) = vbNo Then
            Exit Sub
        End If

        'UPDATE NOW, DO CHANGES HERE FOR ALL SELECTED RECORDS IN THE SubSystemCodeDataGridView
        For I = 0 To RecordCount - 1
            CurrentSubSystemCodeBookID = SubSystemCodeDataGridView.Item("MasterCodeBookID_Autonumber", I).Value
            CurrentSubSystemCode = SubSystemCodeDataGridView.Item("SubSystemCode_ShortText24Fld", I).Value

            Dim RecordFilter = " WHERE MasterCodeBookID_Autonumber = " & CurrentSubSystemCodeBookID
            Dim ReplacementCode = Replace(CurrentSubSystemCode, OldNumberTextBox.Text, NewNumberTextBox.Text)
            Dim SetCommand = " SET SubSystemCode_ShortText24Fld  = " & ReplacementCode

            UpdateTable("MasterCodeBookTable", SetCommand, RecordFilter)
            MsgBox("recover following process, break the progrm")
            Exit Sub
            ' RENUMBER THE InfoPerVehicle TOO if exist(s)
            If InfoPerVehicleRecordCount > 0 Then

                Dim UpdateFieldsToSelect = " UPDATE InfoPerVehiclePartsTable  Set InfoPerVehicleCode_ShortText20Fld  = " & "(" & InQuotes(Trim(NewNumberTextBox.Text)) &
                                                                            " & Mid(InfoPerVehicleCode_ShortText20Fld," & Str(1 + Len(Trim(OldNumberTextBox.Text))) &
                                                                             "," & Str(100 - Len(Trim(NewNumberTextBox.Text))) & "))"

                RecordFilter = " " 'WHERE mid(InfoPerVehicleCode_ShortText20Fld,1," & Str(Len(Trim(OldNumberTextBox.Text))) & ") = " & InQuotes(Trim(OldNumberTextBox.Text))

                '            MySelection = UpdateFieldsToSelect & RecordFilter
                If NoRecordFound() Then Dim dummy = 1
            End If

            Do While True
                Dim OldExcelFileName = ""
                Dim NewExcelFileName = ""
                Dim OldProcedureName = Str(1000 + CurrentVehicleRepairClassID).Substring(2) & CurrentSubSystemCode & "*"
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
        Next
        RenumberGroupBox.Visible = False
        FillSubSystemDataGridView()
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

    Private Sub AddInfoPerVehicleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddCodeInformationsHeaderRelationsToolStripMenuItem.Click
        'Tunnels 1, 2 And 3 maybe used input data to the called form. See FORM - event Load

        ' some cases may enable the calling form for the called form to automatically display related informations.
        ' CodeInformationsHeaderRelationForm is called to get an information header for instructions, specifications diagrams etc
        ' record reference should be returned
        Tunnel1 = CurrentSubSystemCodeBookID
        ShowCalledForm(Me, InformationsHeadersForm)

    End Sub

    Private Sub RemoveCodeInformationsHeaderRelationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveCodeInformationsHeaderRelationToolStripMenuItem.Click
        ' deletion not allowed if there exists references to files / information in excel file        
        If IsNotEmpty(InfoDetailsTextBox.Text) Then
            MsgBox("Remove Information Details 1st before you can delete this")
            Exit Sub
        End If
        Dim xxInformation = CodeInformationsHeaderRelationsDataGridView.Item("InformationsHeaderDescription_ShortText255", CurrentCodeInformationsHeaderRelationRow).Value
        If MsgBox(xxInformation & vbCrLf & vbCrLf & "Do you want to continue deleting this information relation ?", vbYesNo) = vbYes Then
            MySelection = "DELETE FROM CodeInformationsHeaderRelationsTable WHERE CodeInformationsHeaderRelationID_AutoNumber = " & CurrentCodeInformationsHeaderRelationID
            JustExecuteMySelection()
            FillSubSystemDataGridView()
        End If

    End Sub

    Private Sub SelectCodeInformationsHeaderRelationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectCodeInformationsHeaderRelationsToolStripMenuItem.Click
        Select Case CallingForm.Name

        'This returns the referenced Headers reference number
            Case = "ConcernsForm"
                Tunnel1 = CodeInformationsHeaderRelationsDataGridView("InformationsHeaderID_LongInteger", CurrentCodeInformationsHeaderRelationRow).Value
                ConcernsForm.ConcernTextBox.Text = CodeInformationsHeaderRelationsDataGridView("InformationsHeaderDescription_ShortText255", CurrentCodeInformationsHeaderRelationRow).Value
            Case = "VehicleManagementSystemForm"               '
            Case = "JobsForm"
                Tunnel1 = CodeInformationsHeaderRelationsDataGridView("InformationsHeaderID_LongInteger", CurrentCodeInformationsHeaderRelationRow).Value
                JobsForm.JobTextBox.Text = CodeInformationsHeaderRelationsDataGridView("InformationsHeaderDescription_ShortText255", CurrentCodeInformationsHeaderRelationRow).Value
            Case Else
                MsgBox("break, need to know which form activated this") '

        End Select
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub


    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles CreateInformationDetailsToolStripMenuItem.Click
        If DefaultVehicleModelTextBox.Text = "Set Default Vehicle" Then
            MsgBox("Pls Set Default Vehicle first")
            Exit Sub
        End If

        CreateOrReplace()
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles EditInformationDetailsToolStripMenuItem.Click
        CreateOrReplace()
    End Sub
    Private Sub CreateOrReplace()
        SetParentRecordReference("InformationsHeadersTable", "InformationsHeaderID_AutoNumber", CurrentInformationHeaderID)
        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        Dim xxInformationsHeadersTypeID = r("InformationsHeadersTypeID_LongInteger")

        SetParentRecordReference("InformationsHeadersTypeTable", "InformationsHeadersTypeID_AutoNumber", xxInformationsHeadersTypeID)
        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        Dim xxInformationsHeadersTypePrefix = r("ConcernPrefix_ShortText50")

        Me.Hide()
        Select Case xxInformationsHeadersTypePrefix
            Case "Parts Information"

            Case Else
                Me.Hide()
                Select Case CreateInformationDetailsToolStripMenuItem.Text
                    Case = "CREATE Informations"
                        CreateExcelFile()
                        ' LET THIS EXCEL FILE OPEN
                        OpenExcelFile(True)
                        CreateInformationDetailsToolStripMenuItem.Text = "Open Informations"
                        DeleteMasterCodeToolStripMenuItem.Visible = False
                    Case = "Open Informations"
                        ProcedureName = Replace(ProcedureName, "/", "")
                        OpenExcelFile(True)
                        Exit Sub
                End Select
                InfoDetailsTextBox.Text = Trim(InfoDetailsTextBox.Text)
                InfoDetailsTextBox.Text = Replace(InfoDetailsTextBox.Text, "vbTab & vbTab & vbTab & ", "")
                InfoDetailsTextBox.Text = Replace(InfoDetailsTextBox.Text, "vbCrLf & vbCrLf & ", "")
                Me.Show()
        End Select
        CodeInformationsHeaderRelationsDataGridView.Select()
    End Sub

    Private Sub SpecificationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SpecificationsToolStripMenuItem.Click
        If DefaultVehicleModelTextBox.Text = "Set Default Vehicle" Then
            MsgBox("Pls Set Default Vehicle first")
            Exit Sub
        End If
        If CurrentVehicleID = -1 Then
            MsgBox("Pls choose the subject vehicle")
            Exit Sub
        End If
        Tunnel1 = "Tunnel2IsMasterCodeBookID"
        Tunnel2 = CurrentMasterCodeBookSubSystemID
        Tunnel3 = CurrentSubSystemName & " for " & CurrentVehicleString
        ShowCalledForm(Me, PartsSpecificationsForm)
    End Sub

    Private Sub SearchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SearchToolStripMenuItem.Click
        EnableSearch()

    End Sub
    Private Sub EnableSearch()
        SearchGroupBox.Visible = True
        MasterCodeBookMenuStrip.Enabled = False
        MainSystemCodeDataGridView.Enabled = False
        SubSystemCodeDataGridView.Enabled = False
        CodeInformationsHeaderRelationsDataGridView.Enabled = False
        InfoDetailsTextBox.Enabled = False
    End Sub

    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchButton.Click
        SearchIsOnFlag = True
        SearchGroupBox.Visible = False
        MasterCodeBookMenuStrip.Enabled = True
        MainSystemCodeDataGridView.Enabled = True
        SubSystemCodeDataGridView.Enabled = True
        CodeInformationsHeaderRelationsDataGridView.Enabled = True
        InfoDetailsTextBox.Enabled = True
        If SearchMasterCodeBookTextBox.Text = "" Then Exit Sub
        FillSubSystemDataGridView()
    End Sub

    Private Sub SearchMasterCodeBookTextBox_Click(sender As Object, e As EventArgs) Handles SearchMasterCodeBookTextBox.Click
        SearchMasterCodeBookTextBox.SelectAll()
    End Sub
    Private Sub CopyDescriptionToolStripTextBox_Click(sender As Object, e As EventArgs) Handles CopyDescriptionToolStripTextBox.Click
        Clipboard.SetText(SubSystemCodeDataGridView.Item("SystemDesc_ShortText100Fld", CurrentSubSystemCodeRow).Value)
    End Sub
End Class