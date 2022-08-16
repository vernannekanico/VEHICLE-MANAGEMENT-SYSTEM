Public Class InformationsHeadersForm
    Private CurrentInformationsHeaderID As Integer = -1
    Private CurrentInformationsHeaderRow As Integer = -1
    Private InformationsHeadersRecordCount As Integer = -1
    Private CurrentMainSystemCode_ShortText1 = ""
    Private CurrentInformationHeaderTypesComboBox = -1

    Private InformationsHeadersFieldsToSelect = ""
    Private InformationsHeadersTablesLinks = ""
    Private InformationsHeadersSelectionFilter = ""        'Setup before calling the sub Fill
    Private InformationsHeadersSelectionFilterSaved = ""
    Private InformationsHeadersSelectionOrder = ""     'Setup before calling the sub Fill

    Private InformationsHeadersDataGridViewInitialized = False
    Private InformationsHeadersDataGridViewAlreadyFormated = False
    Private InformationExists = ""
    Private ExcelFileName = ""

    Public InformationNamePrefix = ""
    Public CurrentInformationsHeaderCode = ""
    Public CurrentVehicleRepairCode = ""
    Public CurrentParentName = ""
    Public CurrentInformationsHeaderName = ""
    Private CurrentMasterCodeBookID As Integer
    Private InformationsHeadersTypeID = -1
    Private LastChangeRequest = ""
    Private CurrentProcedureOrInformationShortText1 = ""
    Private SavedCallingForm As Form

    Private Sub InformationsHeadersForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SavedCallingForm = CallingForm
        ' UPDATE THE CALLING PROGRAM TO PUT VALUE ON  TUNNEL1 AND UPDATE ParentCodeLabel AND ParentCodeLabel
        Dim r As DataRow
        Select Case CallingForm.Name
            Case "WorkOrderFormASM"
                If IsNotEmpty(Tunnel2) Then 'CONCERNiD OTHERWISE THIS  CONCERN  IS ON TROUBLESHOOTING STATUS
                    'FOR CONCERNS THAT REQUIRES TROUBLE SHOOIING THIS ROUTINE IS NOT NEEDED
                    SetParentRecordReference("ConcernsTable", "ConcernID_AutoNumber", Val(Tunnel2))
                    r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)

                    'this concern is related to the what is referred to by the MasterCodeBookId_LongInteger
                    CurrentMasterCodeBookID = r("MasterCodeBookId_LongInteger")
                End If
            Case "MasterCodeBookForm"
                CurrentMasterCodeBookID = Tunnel1
        End Select
        If CurrentMasterCodeBookID > 0 Then

            ' IF MasterCodeBookID IS IDENTIFIED THEN LIST ALL INFORMATIONS RELATED 


            SetParentRecordReference("MasterCodeBookTable", "MasterCodeBookID_Autonumber", CurrentMasterCodeBookID)
            r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
            ParentCodeLabel.Text = r("SubSystemCode_ShortText24Fld")
            CurrentMainSystemCode_ShortText1 = r("MainSystemCode_ShortText1")
            InformationHeaderTextBox.Text = r("SystemDesc_ShortText100Fld")
            CurrentInformationsHeaderName = r("SystemDesc_ShortText100Fld")

            If CurrentInformationsHeaderName = "TECHNICAL SERVICE BULLETINS" Then
                InformationsHeadersSelectionFilter = " WHERE InformationsHeaderCode_ShortText30 LIKE " & Chr(34) & "%TSB-%" & Chr(34)
            Else
                SearchInformationHeadersTextBox.Text = InformationHeaderTextBox.Text
                SearchInformationsHeaders()
            End If
            '  REVISIONMySelection = "SELECT * " &                           REVISION
            ' REVISION           " FROM InformationsHeadersTable " &         REVISION
            'InformationsHeadersSelectionFilter =
            '          " WHERE MID(InformationsHeaderCode_ShortText30,1," & Len(Trim(ParentCodeLabel.Text)) & ") = " & Chr(34) & ParentCodeLabel.Text & Chr(34) &
            '         " AND LEN(TRIM(InformationsHeaderCode_ShortText30)) = " & Len(Trim(ParentCodeLabel.Text)) + 2
            '  REVISION    Else                                              REVISION
            ' REVISION         MySelection = "SELECT * FROM InformationsHeadersTable "      
        End If
        FillInformationsHeadersDataGridView()
        ' REVISION      JustExecuteMySelection()                             REVISION
        ' REVISION InformationsHeadersRecordCount = RecordCount               REVISION 
        ' REVISION InformationsHeadersDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        If CurrentMasterCodeBookID > 0 And InformationsHeadersRecordCount > 0 Then
            Dim LastCode = InformationsHeadersDataGridView.Item("InformationsHeaderCode_ShortText30", InformationsHeadersRecordCount - 1).Value
            Dim LastCodeLength = Len(Trim(ParentCodeLabel.Text))
            Dim LastSeries = Mid(LastCode, LastCodeLength + 1, 2)
            Dim NextSeriesPlus100 = 1
            For NextSeries = 1 To 100
                NextSeriesPlus100 = (NextSeries + 100).ToString
                NewInformationCodeAppexTextBox.Text = Mid(NextSeriesPlus100, 2, 2)

                CurrentInformationsHeaderCode = ParentCodeLabel.Text & NewInformationCodeAppexTextBox.Text
                Dim MatchExists = False
                For i = 0 To InformationsHeadersRecordCount - 1
                    If CurrentInformationsHeaderCode = NotNull(InformationsHeadersDataGridView.Item("InformationsHeaderCode_ShortText30", i).Value) Then
                        MatchExists = True
                    End If
                Next
                If MatchExists Then Continue For
                Exit For
            Next
        Else
            NewInformationCodeAppexTextBox.Text = "01"
            ParentCodeLabel.Text = ""
        End If
        CurrentInformationsHeaderCode = ParentCodeLabel.Text & NewInformationCodeAppexTextBox.Text


        FillInformationsHeaderTypeComboBox()

        'SET AND RESET ALL ENTRY PARAMETERS
    End Sub

    Private Sub FillInformationsHeadersDataGridView()
        Dim CoinedInformation = " InformationsHeadersTypeTable.Prefix  & Space(1) & MasterCodeBookTable.SystemDesc_ShortText100Fld AS CoinedInformation, "

        InformationsHeadersFieldsToSelect = "
Select 
InformationsHeadersTable.Selected, 
" & CoinedInformation & "
InformationsHeadersTable.InformationsHeaderID_AutoNumber, 
InformationsHeadersTable.InformationsHeaderCode_ShortText30,
InformationsHeadersTypeTable.InformationsHeadersTypeID_AutoNumber,
InformationsHeadersTypeTable.InformationsHeadersType_ShortText100, 
InformationsHeadersTable.MasterCodeBookId_LongInteger, 
InformationsHeadersTable.ProcedureOrInformationShortText1, 
InformationsHeadersTypeTable.Prefix, 
InformationsHeadersTable.InformationsHeaderDescription_ShortText255, 
MasterCodeBookTable.SystemDesc_ShortText100Fld, 
InformationsHeadersTable.MotherInformationsHeaderID_LongInteger,
InformationsHeadersTable.Source_Byte
FROM(InformationsHeadersTable LEFT JOIN MasterCodeBookTable On InformationsHeadersTable.MasterCodeBookId_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) LEFT JOIN InformationsHeadersTypeTable On InformationsHeadersTable.InformationsHeadersTypeID_LongInteger = InformationsHeadersTypeTable.InformationsHeadersTypeID_AutoNumber 
"
        InformationsHeadersSelectionOrder = " ORDER BY SystemDesc_ShortText100Fld,  Selected "


        MySelection = InformationsHeadersFieldsToSelect & InformationsHeadersSelectionFilter & InformationsHeadersSelectionOrder '

        JustExecuteMySelection()

        InformationsHeadersDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        InformationsHeadersRecordCount = RecordCount
        If Not InformationsHeadersDataGridViewAlreadyFormated Then
            InformationsHeadersDataGridViewAlreadyFormated = True
            FormatInformationsHeadersDataGridView()
        End If
    End Sub
    Private Sub FormatInformationsHeadersDataGridView()
        InformationsHeadersDataGridViewAlreadyFormated = True
        InformationsHeadersDataGridView.Width = 0
        For i = 0 To InformationsHeadersDataGridView.Columns.GetColumnCount(0) - 1

            InformationsHeadersDataGridView.Columns.Item(i).Visible = False
            Select Case InformationsHeadersDataGridView.Columns.Item(i).Name
                Case "Selected"
                    InformationsHeadersDataGridView.Columns.Item(i).HeaderText = "*"
                    InformationsHeadersDataGridView.Columns.Item(i).Width = 20
                    InformationsHeadersDataGridView.Columns.Item(i).Visible = True
                Case "CoinedInformation"
                    InformationsHeadersDataGridView.Columns.Item(i).HeaderText = "INFORMATION"
                    InformationsHeadersDataGridView.Columns.Item(i).Width = 300
                    InformationsHeadersDataGridView.Columns.Item(i).Visible = True

                Case "MasterCodeBookId_LongInteger"
                    InformationsHeadersDataGridView.Columns.Item(i).HeaderText = "CodeBookID"
                    InformationsHeadersDataGridView.Columns.Item(i).Width = 70
                    InformationsHeadersDataGridView.Columns.Item(i).Visible = True
                Case "ProcedureOrInformationShortText1"
                    InformationsHeadersDataGridView.Columns.Item(i).HeaderText = "Proc or Info"
                    InformationsHeadersDataGridView.Columns.Item(i).Width = 70
                    InformationsHeadersDataGridView.Columns.Item(i).Visible = True
                Case "Prefix"
                    InformationsHeadersDataGridView.Columns.Item(i).Width = 150
                    InformationsHeadersDataGridView.Columns.Item(i).Visible = True
                Case "InformationsHeaderDescription_ShortText255"
                    InformationsHeadersDataGridView.Columns.Item(i).HeaderText = "InformationsHeaderDescription_ShortText255"
                    InformationsHeadersDataGridView.Columns.Item(i).Width = 300
                    InformationsHeadersDataGridView.Columns.Item(i).Visible = True
                Case "SystemDesc_ShortText100Fld"
                    InformationsHeadersDataGridView.Columns.Item(i).Width = 300
                    InformationsHeadersDataGridView.Columns.Item(i).Visible = True
                Case "MotherInformationsHeaderID_LongInteger"
                    InformationsHeadersDataGridView.Columns.Item(i).Width = 100
                    InformationsHeadersDataGridView.Columns.Item(i).Visible = True
            End Select

            If InformationsHeadersDataGridView.Columns.Item(i).Visible = True Then
                InformationsHeadersDataGridView.Width = InformationsHeadersDataGridView.Width + InformationsHeadersDataGridView.Columns.Item(i).Width
            End If
        Next

        ' NOTE" SYSTEM AUTOFITS THE GRIDVIEW FIELDS ACCORDING TO THEIR WITDH

        If InformationsHeadersDataGridView.Width > Me.Width + 20 Then
            InformationsHeadersDataGridView.Width = Me.Width - 80
        Else
            InformationsHeadersDataGridView.Width = InformationsHeadersDataGridView.Width + 20
            Dim LargestWidth = InformationsHeadersDataGridView.Width
        End If

        ' NOTE IF YOU WANT TO CENTER THE GRIDVIEW
        '       InformationsHeadersDataGridView.Left = (Me.Width - InformationsHeadersDataGridView.Width) / 2

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
    Private Sub InformationsHeadersDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles InformationsHeadersDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then
            Exit Sub
        End If
        CurrentInformationsHeaderRow = e.RowIndex
        CurrentInformationsHeaderID = InformationsHeadersDataGridView.Item("InformationsHeaderID_AutoNumber", CurrentInformationsHeaderRow).Value

        SelectMasterCodeToolStripMenuItem.Visible = True
    End Sub


    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        Tunnel1 = -1
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub

    Private Sub SelectMasterCodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectMasterCodeToolStripMenuItem.Click
        If IsEmpty(InformationsHeadersDataGridView.Item("MasterCodeBookId_LongInteger", CurrentInformationsHeaderRow).Value) Then
            MsgBox("Information does not have reference to MastercodeBook " & vbCrLf & vbCrLf & "Edit Mode is set")
            EditInformationsHeaderDetails()
            Exit Sub
        End If
        Tunnel1 = "Tunnel2IsInformationsHeaderID"
        Tunnel2 = CurrentInformationsHeaderID
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub


    Private Sub EditInformationsHeaderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditInformationsHeaderToolStripMenuItem.Click
        EditInformationsHeaderDetails()

    End Sub
    Private Sub EditInformationsHeaderDetails()
        ModifyGroupBox.Visible = True
        EditInformationsHeaderToolStripMenuItem.Visible = False
        SelectMasterCodeToolStripMenuItem.Visible = False
        AddHeaderInformationToolStripMenuItem.Visible = False
        InformationHeaderTypesComboBox.Visible = True
        InformationHeaderTypesComboBox.Select()
        LastChangeRequest = "EDIT"
    End Sub
    Private Sub AddHeaderInformationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddHeaderInformationToolStripMenuItem.Click
        ModifyGroupBox.Visible = True
        InformationHeaderTypesComboBox.Visible = True
        EditInformationsHeaderToolStripMenuItem.Visible = False
        SelectMasterCodeToolStripMenuItem.Visible = False
        AddHeaderInformationToolStripMenuItem.Visible = False
        LastChangeRequest = "ADD"
    End Sub
    Public Sub FillInformationHeadersTypeDataGridView()
        MySelection = "Select * " &
                           " FROM InformationsHeadersTypeTable ORDER BY InformationsHeadersType_ShortText100 "
        If NoRecordFound() Then Exit Sub

        ' FILL DATAGRID
        '  ConcernsTypeDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        ' CLEAR COMBOBOX
        InformationHeaderTypesComboBox.Items.Clear()

        ' FILL COMBOBOX

        For Each R As DataRow In RecordFinderDbControls.MyAccessDbDataTable.Rows
            InformationHeaderTypesComboBox.Items.Add(R("ConcernType_ShortText100"))
            ConcernTypePrefixComboBox.Items.Add(R("InformationsHeadersTypeID_AutoNumber"))
        Next

        ' DISPLAY FIRS NAME FOUND
        If RecordCount > 0 Then
            For I = 0 To RecordCount - 1
                If InformationHeaderTypesComboBox.Items(I).ToString = "Select Type Of Concern" Then
                    InformationHeaderTypesComboBox.Items(I).value = "Select Type Of InformationHeader"
                    InformationHeaderTypesComboBox.Text = InformationHeaderTypesComboBox.Items(I).ToString
                End If
            Next
            '           ConcernTypesComboBox.Text = (ConcernTypesComboBox.Items(2)).ToString
        End If
    End Sub
    Public Sub FillInformationsHeaderTypeComboBox()
        MySelection = "Select * " &
                           " FROM InformationsHeadersTypeTable WHERE InformationsHeadersTypeClassID_Integer = 1 ORDER BY InformationsHeadersType_ShortText100 "
        If NoRecordFound() Then
            Exit Sub
        End If

        ' CLEAR COMBOBOX
        InformationHeaderTypesComboBox.Items.Clear()

        ' FILL COMBOBOX
        Dim SelectedRecords = 0
        For Each R As DataRow In RecordFinderDbControls.MyAccessDbDataTable.Rows
            '            If R("InformationsHeadersTypeClassID_Integer") = 1 Then Continue For                                ' CONCERNS

            InformationHeaderTypesComboBox.Items.Add(R("InformationsHeadersType_ShortText100"))
            ConcernTypePrefixComboBox.Items.Add(R("Prefix"))
            SelectedRecords = SelectedRecords + 1
        Next

        InformationHeaderTypesComboBox.Text = "Select Type Of INFORMATION"
    End Sub


    Private Sub SearchInformationHeadersTextBox_TClick(sender As Object, e As EventArgs) Handles SearchInformationHeadersTextBox.Click
        If SearchInformationHeadersTextBox.Text = "Search" Then
            SearchInformationHeadersTextBox.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub InsertNewInformationsHeaderItem()


        Dim CurrentSource_Byte = 2
        Dim CurrentDeleteMeYesNo = False
        ' TEST IF RECORD EXISTS
        Dim r As DataRow
        Dim xxSearchKey = InformationHeaderTypesComboBox.Text & Space(1) & InformationHeaderTextBox.Text

        MySelection = "SELECT * " &
                      " FROM InformationsHeadersTable " &
                      " WHERE InformationsHeaderDescription_ShortText255 = " & Chr(34) & xxSearchKey & Chr(34)

        If Not NoRecordFound() Then
            r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
            CurrentInformationsHeaderID = r("InformationsHeaderID_AutoNumber")
            MsgBox(InformationHeaderTextBox.Text & " already exist")
            Exit Sub
        End If
        If TSBCodeTextBox.Text = "" Then
            NewInformationCodeAppexTextBox.Text = Mid(InformationsHeadersTypeID + 100, 2, 2)
            CurrentInformationsHeaderCode = ParentCodeLabel.Text & NewInformationCodeAppexTextBox.Text
        Else
            CurrentInformationsHeaderCode = "TSB-" & TSBCodeTextBox.Text
        End If

        Dim tmpSourceByte = 2
        Dim ZeroValue = 0
        Dim FieldsToUpdate = " (" &
                             " InformationsHeaderCode_ShortText30" &        '1
                             ", " & " InformationsHeaderDescription_ShortText255" &     '2
                             ", " & " InformationsHeadersTypeID_LongInteger" &                      '3
                             ", " & " MasterCodeBookId_LongInteger " &        '4
                             ", " & " Source_Byte " &           '5
                             ", " & " DeleteMeYesNo " &                   '7
                             ", " & " ProcedureOrInformationShortText1 " &            '8
                    ") "
        Dim ReplacementData = "(" &
                                Chr(34) & CurrentInformationsHeaderCode & Chr(34) &         '1  InformationsHeaderCode_ShortText30" '1 
                                ", " & Chr(34) & xxSearchKey & Chr(34) &  '2  InformationsHeaderDescription_ShortText255" & '2
                                ", " & InformationsHeadersTypeID.ToString &                      '3  InformationsHeadersTypeID_LongInteger" &                  '3
                                ", " & CurrentMasterCodeBookID.ToString &                   '4  MasterCodeBookId_LongInteger " &              '4
                                ", " & tmpSourceByte.ToString &                             '5  Source_Byte " &                                5
                                ", " & vbNo &                                 '7  DeleteMeYes/No " &                            '7
                                ", " & Chr(34) & CurrentProcedureOrInformationShortText1 & Chr(34) &
                   ") "

        MySelection = "INSERT INTO InformationsHeadersTable  " & FieldsToUpdate & " VALUES " & ReplacementData

        JustExecuteMySelection()


        FillInformationsHeadersDataGridView()

    End Sub
    Sub GetNextSystemCode()

    End Sub

    Private Sub SaveHeaderInformationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveHeaderInformationToolStripMenuItem.Click

        If LastChangeRequest = "EDIT" Then
            UpdateInformationsHeaderItem()
        Else
            InsertNewInformationsHeaderItem()
        End If

        InformationCODELabel.Visible = False
        InformationHeaderTypesComboBox.Visible = False
        TSBCodeTextBox.Text = ""
        TSBCodeTextBox.Visible = False
        TSBCodeTextBox.Select()
        TSBPefixLabel.Visible = False

        ModifyGroupBox.Visible = False
        EditInformationsHeaderToolStripMenuItem.Visible = True
        SelectMasterCodeToolStripMenuItem.Visible = True
        AddHeaderInformationToolStripMenuItem.Visible = True
        LastChangeRequest = ""
    End Sub
    Private Sub UpdateInformationsHeaderItem()


        MySelection = " UPDATE InformationsHeadersTable " &
                  " SET InformationsHeaderDescription_ShortText255  = " & Chr(34) & InformationHeaderTextBox.Text & Chr(34) &
                  ", InformationsHeaderCode_ShortText30 = " & Chr(34) & CurrentInformationsHeaderCode & Chr(34) &
                  ", MotherInformationsHeaderID_LongInteger = " & CurrentInformationsHeaderID &
                  ", MasterCodeBookId_LongInteger = " & CurrentMasterCodeBookID.ToString &
                  ", MainSystemCode_ShortText1 = " & Chr(34) & CurrentMainSystemCode_ShortText1 & Chr(34) &
                  ", InformationsHeadersTypeID_LongInteger = " & InformationsHeadersTypeID.ToString &
                  " WHERE InformationsHeaderID_AutoNumber = " & CurrentInformationsHeaderID.ToString


        JustExecuteMySelection()

        InformationCODELabel.Visible = False
        InformationHeaderTypesComboBox.Visible = False
        FillInformationsHeadersDataGridView()
    End Sub
    Private Sub InformationHeaderTypesComboBox_TextChanged(sender As Object, e As EventArgs) Handles InformationHeaderTypesComboBox.TextChanged
        If InformationHeaderTypesComboBox.Text = "" Then Exit Sub
        If InformationHeaderTypesComboBox.Text = "Select Type Of INFORMATION" Then Exit Sub
        ConcernTypePrefixComboBox.Text = InformationHeaderTypesComboBox.Text
        '      InformationHeaderTextBox.Text = ConcernTypePrefixComboBox.Items(InformationHeaderTypesComboBox.SelectedIndex) & Space(1) & CurrentInformationsHeaderName
        'SetParentRecordReference("InformationsHeadersTypeTable", "InformationsHeadersTypePrefix_ShortText50", InformationHeaderTypesComboBox.Text)
        'Dim r As DataRow
        'r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        'InformationsHeadersTypeID = r("InformationsHeadersTypeID_AutoNumber")
        'CurrentMainSystemCode_ShortText1 = r("MainSystemCode_ShortText1")
        If InformationHeaderTypesComboBox.Text = "Technical Service Bulletin" Then
            TSBCodeTextBox.Text = "TSB Title ?"
            TSBCodeTextBox.Visible = True
            TSBCodeTextBox.Select()
            TSBPefixLabel.Visible = True
            InformationHeaderTextBox.Text = "TSB Title ?"
        End If
    End Sub

    Private Sub TSBToolStripLabel_Click(sender As Object, e As EventArgs) Handles TSBToolStripLabel.Click
        InformationsHeadersSelectionFilterSaved = InformationsHeadersSelectionFilter

        InformationsHeadersSelectionFilter = " WHERE InformationsHeaderCode_ShortText30 LIKE " & Chr(34) & "%TSB-%" & Chr(34)
        FillInformationsHeadersDataGridView()
        InformationsHeadersSelectionFilter = InformationsHeadersSelectionFilterSaved

    End Sub

    Private Sub SearchToolStripLabel_Click(sender As Object, e As EventArgs) Handles SearchToolStripLabel.Click
        SearchInformationsHeaders()
        FillInformationsHeadersDataGridView()

    End Sub

    Private Sub SearchInformationsHeaders()
        If SearchInformationHeadersTextBox.Text = "" Then
            InformationsHeadersSelectionFilter = ""
            FillInformationsHeadersDataGridView()

            Exit Sub
        End If

        Dim FindKey As String = Trim(SearchInformationHeadersTextBox.Text)

        'InformationsHeadersSelectionFilterSaved = InformationsHeadersSelectionFilter
        Dim Search1 = " InformationsHeaderDescription_ShortText255 Like " & Chr(34) & "%" & Trim(SearchInformationHeadersTextBox.Text) & "%" & Chr(34)
        Dim Search2 = " SystemDesc_ShortText100Fld Like " & Chr(34) & "%" & Trim(SearchInformationHeadersTextBox.Text) & "%" & Chr(34)
        '       Dim Search3 = " InformationsHeadersTable.ProcedureOrInformationShortText1 = " & Chr(34) & CurrentProcedureOrInformationShortText1 & Chr(34)
        Dim Search3 = " "

        InformationsHeadersSelectionFilter = " WHERE (" & Search1 & " Or " & Search2 & ") " 'And " & Search3

        'FillInformationsHeadersDataGridView()

    End Sub


    Private Sub ConcernTypePrefixComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ConcernTypePrefixComboBox.SelectedIndexChanged
        CurrentProcedureOrInformationShortText1 = ""
        If ConcernTypePrefixComboBox.Text = "" Then Exit Sub
        If ConcernTypePrefixComboBox.Text = "Select Type Of INFORMATION" Then Exit Sub
        SetParentRecordReference("InformationsHeadersTypeTable", "InformationsHeadersTypePrefix_ShortText50", ConcernTypePrefixComboBox.Text)
        Dim r As DataRow
        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        InformationsHeadersTypeID = r("InformationsHeadersTypeID_AutoNumber")
        CurrentProcedureOrInformationShortText1 = r("ProcedureOrInformationShortText1")

    End Sub

    Private Sub InformationHeaderTextBox_Click(sender As Object, e As EventArgs) Handles InformationHeaderTextBox.Click
        If InformationHeaderTextBox.Text <> "" Then
            If MsgBox("Do you want to replace information ?", vbYesNo) = vbNo Then Exit Sub
        End If

        MasterCodeBookForm.SearchMasterCodeBookTextBox.Text = SearchInformationHeadersTextBox.Text
        ShowCalledForm(Me, MasterCodeBookForm)
    End Sub
    Private Sub InformationHeaderTypesComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles InformationHeaderTypesComboBox.SelectedIndexChanged
        SetSaveMenu()
    End Sub
    Private Sub SetSaveMenu()
        SaveHeaderInformationToolStripMenuItem.Visible = False
        If InformationHeaderTextBox.Text = "" Then
            InformationHeaderTextBox.Select()
            Exit Sub
        End If
        If InformationHeaderTypesComboBox.Text = "Select Type Of INFORMATION" Then
            InformationHeaderTypesComboBox.Select()
            Exit Sub
        End If
        SaveHeaderInformationToolStripMenuItem.Visible = True
    End Sub

    Private Sub InformationsHeadersForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        If Me.Enabled = False Then Exit Sub
        CallingForm = SavedCallingForm
        Select Case Tunnel1
            Case "Tunnel2IsMasterCodeBookID"
                CurrentMasterCodeBookID = Tunnel2
                ParentCodeLabel.Text = Tunnel4
                InformationHeaderTextBox.Text = Tunnel3
                SaveHeaderInformationToolStripMenuItem.Visible = True
        End Select
    End Sub

    Private Sub VehicleFilterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CodeBookFilterToolStripMenuItem.Click
        If CodeBookFilterToolStripMenuItem.Text = "Set Vehicle Filter ON" Then
            CodeBookFilterToolStripMenuItem.Text = "Set Vehicle Filter OFF"
        Else
            CodeBookFilterToolStripMenuItem.Text = "Set Vehicle Filter ON"
        End If


    End Sub
End Class