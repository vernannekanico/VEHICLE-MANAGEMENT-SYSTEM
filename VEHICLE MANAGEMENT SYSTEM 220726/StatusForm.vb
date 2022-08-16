Public Class StatusForm
    Private TablesFieldsToSelect = ""
    Private TablesSelectionFilter = ""
    Private TablesSelectionOrder = ""
    Private CurrentTablesRow As Integer = -1
    Private TablesRecordCount As Integer = -1
    Private CurrentTableID = -1
    Private CurrentTableStatus As String
    Private TablesDataGridViewAlreadyFormated = False

    Private StatusesFieldsToSelect = ""
    Private StatusesSelectionFilter = ""
    Private StatusesSelectionOrder = ""
    Private CurrentStatusesRow As Integer = -1
    Private StatusesRecordCount As Integer = -1
    Private CurrentStatusID = -1
    Private CurrentStatuseStatus As String
    Private StatusesDataGridViewAlreadyFormated = False

    Private ChangesOccured = False
    Dim PurposeOfEntry = ""
    Private SavedCallingForm As Form


    Private Sub TableForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SavedCallingForm = CallingForm
        TablesSelectionOrder = " ORDER BY TableName_ShortText60 ASC "
        StatusesSelectionOrder = " ORDER BY StatusSequence_LongInteger ASC "
        FillTablesDataGridView()

    End Sub
    Private Sub FillTablesDataGridView()

        TablesFieldsToSelect =
"
SELECT TableNamesTable.TableNameID_AutoNumber, TableNamesTable.TableName_ShortText60
FROM TableNamesTable
"
        MySelection = TablesFieldsToSelect & TablesSelectionFilter & TablesSelectionOrder
        JustExecuteMySelection()
        TablesRecordCount = RecordCount

        TablesDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        If Not TablesDataGridViewAlreadyFormated Then
            TablesDataGridViewAlreadyFormated = True
            FormatTablesDataGridView()
        End If

        Dim RecordsDisplyed = TablesRecordCount
        If TablesRecordCount > 10 Then
            RecordsDisplyed = 10
        Else
            RecordsDisplyed = TablesRecordCount
        End If
        TablesDataGridView.Height = (TablesDataGridView.ColumnHeadersHeight) + (DataGridViewRowHeight * (RecordsDisplyed + 1))
        TablesDataGridView.Top = MenuStrip1.Top + MenuStrip1.Height
        StatusesDataGridView.Top = TablesDataGridView.Top + TablesDataGridView.Height
        Me.Height = 46 + TablesDataGridView.Top + TablesDataGridView.Height + StatusesDataGridView.Height
    End Sub
    Private Sub FormatTablesDataGridView()
        TablesDataGridView.Width = 0
        For i = 0 To TablesDataGridView.Columns.GetColumnCount(0) - 1

            TablesDataGridView.Columns.Item(i).Visible = False
            Select Case TablesDataGridView.Columns.Item(i).Name
                Case "TableName_ShortText60"
                    TablesDataGridView.Columns.Item(i).HeaderText = "ACTION"

                    TablesDataGridView.Columns.Item(i).Width = 300
                    TablesDataGridView.Columns.Item(i).Visible = True
            End Select
            If TablesDataGridView.Columns.Item(i).Visible = True Then
                TablesDataGridView.Width = TablesDataGridView.Width + TablesDataGridView.Columns.Item(i).Width
            End If
        Next
        If TablesDataGridView.Width > StatusesDataGridView.Width Then
            Me.Width = TablesDataGridView.Width + 2
        Else
            Me.Width = StatusesDataGridView.Width + 2
        End If
        TablesDataGridView.Left = (Me.Width - TablesDataGridView.Width) / 2
        StatusesDataGridView.Left = (Me.Width - StatusesDataGridView.Width) / 2
        StatusDetailsGroupBox.Left = (Me.Width - StatusDetailsGroupBox.Width) / 2
    End Sub

    Private Sub TablesDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles TablesDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If Me.Enabled = False Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If TablesRecordCount = 0 Then Exit Sub

        CurrentTablesRow = e.RowIndex
        CurrentTableID = TablesDataGridView.Item("TableNameID_AutoNumber", CurrentTablesRow).Value
        StatusesSelectionFilter = " WHERE TableNameID_Integer = " & CurrentTableID.ToString

        FillStatusesDataGridView()
        Me.Height = 46 + TablesDataGridView.Top + TablesDataGridView.Height + StatusesDataGridView.Height
    End Sub
    Private Sub FillStatusesDataGridView()

        StatusesFieldsToSelect =
"
SELECT TableNamesTable.TableNameID_AutoNumber, 
TableNamesTable.TableName_ShortText60, 
StatusesTable.StatusID_Autonumber, 
StatusesTable.StatusSequence_LongInteger, 
StatusesTable.StatusText_ShortText25, 
StatusesTable.OldStatus_Byte, 
StatusesTable.StatusDescription__Memo
FROM StatusesTable LEFT JOIN TableNamesTable ON StatusesTable.TableNameID_Integer = TableNamesTable.TableNameID_AutoNumber
"
        MySelection = StatusesFieldsToSelect & StatusesSelectionFilter
        JustExecuteMySelection()
        StatusesRecordCount = RecordCount

        StatusesDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        If Not StatusesDataGridViewAlreadyFormated Then
            StatusesDataGridViewAlreadyFormated = True
            FormatStatusesDataGridView()
        End If

        Dim RecordsDisplyed = StatusesRecordCount
        If StatusesRecordCount > 10 Then
            RecordsDisplyed = 10
        Else
            RecordsDisplyed = StatusesRecordCount
        End If
        StatusesDataGridView.Height = (StatusesDataGridView.ColumnHeadersHeight) + (DataGridViewRowHeight * (RecordsDisplyed + 1))
    End Sub
    Private Sub FormatStatusesDataGridView()
        StatusesDataGridView.Width = 0
        For i = 0 To StatusesDataGridView.Columns.GetColumnCount(0) - 1

            StatusesDataGridView.Columns.Item(i).Visible = False
            Select Case StatusesDataGridView.Columns.Item(i).Name
                Case "StatusID_Autonumber"
                    StatusesDataGridView.Columns.Item(i).HeaderText = "StatusID"
                    StatusesDataGridView.Columns.Item(i).Width = 70
                    StatusesDataGridView.Columns.Item(i).Visible = True
                Case "StatusSequence_LongInteger"
                    StatusesDataGridView.Columns.Item(i).HeaderText = "Sequence"
                    StatusesDataGridView.Columns.Item(i).Width = 100
                    StatusesDataGridView.Columns.Item(i).Visible = True
                Case "StatusText_ShortText25"
                    StatusesDataGridView.Columns.Item(i).HeaderText = "Status"
                    StatusesDataGridView.Columns.Item(i).Width = 200
                    StatusesDataGridView.Columns.Item(i).Visible = True
                Case "OldStatus_Byte"
                    StatusesDataGridView.Columns.Item(i).HeaderText = "OldStatus_Byte"
                    StatusesDataGridView.Columns.Item(i).Width = 200
                    StatusesDataGridView.Columns.Item(i).Visible = True
                Case "StatusDescription__Memo"
                    StatusesDataGridView.Columns.Item(i).HeaderText = "comments"
                    StatusesDataGridView.Columns.Item(i).Width = 200
                    StatusesDataGridView.Columns.Item(i).Visible = True
            End Select
            If StatusesDataGridView.Columns.Item(i).Visible = True Then
                StatusesDataGridView.Width = StatusesDataGridView.Width + StatusesDataGridView.Columns.Item(i).Width
            End If
        Next
    End Sub

    Private Sub StatusesDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles StatusesDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If Me.Enabled = False Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If StatusesRecordCount = 0 Then Exit Sub
        CurrentStatusesRow = e.RowIndex
        CurrentStatusID = StatusesDataGridView.Item("StatusID_AutoNumber", CurrentStatusesRow).Value
        StatusByteTextBox.Text = StatusesDataGridView.Item("OldStatus_Byte", CurrentStatusesRow).Value
        SequenceOfActionTextBox.Text = StatusesDataGridView.Item("StatusSequence_LongInteger", CurrentStatusesRow).Value
        StatusOfActionTextBox.Text = StatusesDataGridView.Item("StatusText_ShortText25", CurrentStatusesRow).Value
        FillField(RemarksTextBox.Text, StatusesDataGridView.Item("StatusDescription__Memo", CurrentStatusesRow).Value)
    End Sub

    Private Sub ReturnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnToolStripMenuItem.Click
        If StatusDetailsGroupBox.Visible = True Then
            SaveChanges()
            If ChangesOccured Then
                FillStatusesDataGridView()
            End If
            StatusDetailsGroupBox.Visible = False
        Else
            DoCommonHouseKeeping(Me, SavedCallingForm)
        End If
    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddStatusToolStripMenuItem.Click
        PurposeOfEntry = "ADD"

        ' setup default here
        If StatusesRecordCount = 0 Then
            SequenceOfActionTextBox.Text = StatusesRecordCount.ToString
        Else
            SequenceOfActionTextBox.Text = (StatusesRecordCount).ToString
        End If
        CurrentStatusID = -1
        StatusByteTextBox.Text = ""
        StatusOfActionTextBox.Text = ""
        RemarksTextBox.Text = ""
        StatusDetailsGroupBox.Visible = True
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditStatusToolStripMenuItem.Click
        If StatusesRecordCount < 1 Then Exit Sub
        PurposeOfEntry = "EDIT"
        StatusDetailsGroupBox.Visible = True
        StatusOfActionTextBox.Enabled = False
    End Sub

    Private Sub SelectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectStatusToolStripMenuItem.Click

    End Sub

    Private Sub StatusDetailsGroupBox_VisibleChanged(sender As Object, e As EventArgs) Handles StatusDetailsGroupBox.VisibleChanged
        If StatusDetailsGroupBox.Visible = True Then
            SaveStatusToolStripMenuItem.Visible = True
            AddStatusToolStripMenuItem.Visible = False
            EditStatusToolStripMenuItem.Visible = False
            DeleteStatusToolStripMenuItem.Visible = False
            TablesDataGridView.Enabled = False
            StatusesDataGridView.Enabled = False
        Else
            SaveStatusToolStripMenuItem.Visible = False
            AddStatusToolStripMenuItem.Visible = True
            EditStatusToolStripMenuItem.Visible = True
            DeleteStatusToolStripMenuItem.Visible = True
            TablesDataGridView.Enabled = True
            StatusesDataGridView.Enabled = True
        End If
    End Sub

    Private Sub DeleteStatusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteStatusToolStripMenuItem.Click

    End Sub
    Private Sub SaveStatusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveStatusToolStripMenuItem.Click
        ChangesOccured = False
        SaveChanges()
        If ChangesOccured Then
            FillStatusesDataGridView()
            StatusDetailsGroupBox.Visible = False
        End If
    End Sub

    Private Sub SaveChanges()
        If Not ValidStatusEntries() Then Exit Sub
        SaveStatusChanges()
    End Sub
    Private Function ValidStatusEntries()
        If SequenceOfActionTextBox.Text = "" Or DuplicateEntry(CurrentTableID, "StatusSequence_LongInteger", 0, SequenceOfActionTextBox.Text) Then
            SequenceOfActionTextBox.Select()
            Return False
        End If
        If StatusOfActionTextBox.Text = "" Or DuplicateEntry(CurrentTableID, "StatusText_ShortText25", 1, StatusOfActionTextBox.Text) Then
            StatusOfActionTextBox.Select()
            Return False
        End If
        If StatusByteTextBox.Text = "" Then
            If MsgBox("Leave  StatusByte blank ?", MsgBoxStyle.YesNo) = vbYesNo Then
                StatusByteTextBox.Select()
                Return False
            End If
            Return True
        End If
        If DuplicateEntry(CurrentTableID, "OldStatus_Byte", 0, StatusByteTextBox.Text) Then
            StatusByteTextBox.Select()
            Return False
        End If

        Return True
    End Function
    Private Function DuplicateEntry(TableNameID_Integer As Decimal, PassedFieldName As String, PassedFieldType As Decimal, PassedTextBoxText As String)
        'NOTE: for PassedFieldType: 1 = String
        Dim PassedValue = Val(PassedTextBoxText).ToString
        If PassedFieldType = 1 Then PassedValue = InQuotes(PassedTextBoxText)
        MySelection = " Select top 1 * FROM StatusesTable WHERE " & PassedFieldName & " = " & PassedValue &
                        " And TableNameID_Integer = " & TableNameID_Integer.ToString &
                        " And StatusID_Autonumber <> " & CurrentStatusID.ToString
        JustExecuteMySelection()
        If RecordCount = 0 Then Return False
        MsgBox("Duplicate Entry for " & PassedFieldName)
        Return True
    End Function

    Private Sub SaveStatusChanges()
        If AChangeInStatusOccured() Then
            ChangesOccured = True
            If MsgBox("Save Changes ?", MsgBoxStyle.YesNo) = vbNo Then
                StatusDetailsGroupBox.Visible = False
                Exit Sub
            End If
            RegisterStatusChanges()
        End If
    End Sub
    Private Function AChangeInStatusOccured()

        '*******************************************************
        ' THIS ROUTINE DETERMINES ALSO IF THE PURPOSE OF ENTRY = "ADD OR EDIT
        If PurposeOfEntry = "ADD" Then Return True
        If TheseAreNotEqual(SequenceOfActionTextBox.Text, StatusesDataGridView.Item("StatusSequence_LongInteger", CurrentStatusesRow).Value, PurposeOfEntry) Then Return True
        If TheseAreNotEqual(StatusOfActionTextBox.Text, StatusesDataGridView.Item("StatusText_ShortText25", CurrentStatusesRow).Value, PurposeOfEntry) Then Return True
        If TheseAreNotEqual(RemarksTextBox.Text, StatusesDataGridView.Item("StatusDescription__Memo", CurrentStatusesRow).Value, PurposeOfEntry) Then Return True
        Return False
    End Function
    Private Sub RegisterStatusChanges()
        MySelection = " Select top 1 * FROM StatusesTable WHERE StatusID_Autonumber = " & CurrentStatusID.ToString
        JustExecuteMySelection()
        If RecordCount = 0 Then
            InsertNewStatus()
        Else
            UpdateStatus()
        End If
        FillStatusesDataGridView()
    End Sub
    Private Sub InsertNewStatus()
        Dim xxField = IIf(StatusByteTextBox.Text = "", "", "  OldStatus_Byte, ")
        Dim xxFieldValue = IIf(StatusByteTextBox.Text = "", "", StatusByteTextBox.Text & ",  ")
        Dim FieldsToUpdate =
                       "  StatusSequence_LongInteger, " &
                       "  TableNameID_Integer, " &
                       "  StatusText_ShortText25, " &
                          xxField &
                       "  StatusDescription__Memo "

        Dim FieldsData =
                        Val(SequenceOfActionTextBox.Text).ToString & ",  " &
                        CurrentTableID.ToString & ",  " &
                        InQuotes(StatusOfActionTextBox.Text) & ",  " &
                        xxFieldValue &
                        InQuotes(RemarksTextBox.Text)

        CurrentStatusID = InsertNewRecord("StatusesTable", FieldsToUpdate, FieldsData)
    End Sub
    Private Sub UpdateStatus()
        If MsgBox("About to replace original informations, Continue ?", MsgBoxStyle.YesNo) = vbNo Then
            Exit Sub
        End If
        Dim RecordFilter = " WHERE StatusID_Autonumber = " & CurrentStatusID.ToString
        Dim SetCommand = " SET StatusSequence_LongInteger = " & Val(SequenceOfActionTextBox.Text).ToString & "," &
                                      "StatusText_ShortText25 = " & InQuotes(StatusOfActionTextBox.Text) & "," &
                                      "TableNameID_Integer = " & CurrentTableID.ToString & "," &
                                      "StatusDescription__Memo = " & InQuotes(RemarksTextBox.Text)

        UpdateTable("StatusesTable", SetCommand, RecordFilter)
    End Sub

End Class