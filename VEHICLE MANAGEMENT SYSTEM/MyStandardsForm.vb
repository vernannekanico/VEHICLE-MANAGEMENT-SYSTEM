Public Class MyStandardForm
    Private MyStandardsFieldsToSelect = ""
    Private MyStandardsSelectionFilter = ""
    Private MyStandardsSelectionOrder = ""
    Private CurrentMyStandardsRow As Integer = -1
    Private MyStandardsRecordCount As Integer = -1
    Private CurrentMyStandardID = -1
    Private CurrentMyStandardStatus As String
    Private MyStandardsDataGridViewAlreadyFormated = False

    Private SavedCallingForm As Form

    Private Sub MyStandardForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SavedCallingForm = CallingForm
        FillMyStandardsDataGridView()

    End Sub
    Private Sub FillMyStandardsDataGridView()

        MyStandardsFieldsToSelect =
"
"
        MySelection = MyStandardsFieldsToSelect & MyStandardsSelectionFilter
        JustExecuteMySelection()
        MyStandardsRecordCount = RecordCount

        MyStandardsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        If Not MyStandardsDataGridViewAlreadyFormated Then
            MyStandardsDataGridViewAlreadyFormated = True
            FormatMyStandardsDataGridView()
        End If

        Dim RecordsDisplyed = MyStandardsRecordCount
        If MyStandardsRecordCount > 10 Then
            RecordsDisplyed = 10
        Else
            RecordsDisplyed = MyStandardsRecordCount
        End If
        MyStandardsDataGridView.Height = (MyStandardsDataGridView.ColumnHeadersHeight) + (DataGridViewRowHeight * (RecordsDisplyed + 1))
        MyStandardsDataGridView.Top = MyStandardsMenuStrip.Top + MyStandardsMenuStrip.Height
    End Sub
    Private Sub FormatMyStandardsDataGridView()
        MyStandardsDataGridView.Width = 0
        For i = 0 To MyStandardsDataGridView.Columns.GetColumnCount(0) - 1

            MyStandardsDataGridView.Columns.Item(i).Visible = False
            Select Case MyStandardsDataGridView.Columns.Item(i).Name
                Case "MyStandardName_ShortText60"
                    MyStandardsDataGridView.Columns.Item(i).HeaderText = "ACTION"
                    MyStandardsDataGridView.Columns.Item(i).Width = 200
                    MyStandardsDataGridView.Columns.Item(i).Visible = True
            End Select
            If MyStandardsDataGridView.Columns.Item(i).Visible = True Then
                MyStandardsDataGridView.Width = MyStandardsDataGridView.Width + MyStandardsDataGridView.Columns.Item(i).Width
            End If
        Next
        MyStandardsDataGridView.Left = 1
    End Sub

    Private Sub MyStandardsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles MyStandardsDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If Me.Enabled = False Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If MyStandardsRecordCount = 0 Then Exit Sub

        CurrentMyStandardsRow = e.RowIndex
        CurrentMyStandardID = MyStandardsDataGridView.Item("MyStandardNameID_AutoNumber", CurrentMyStandardsRow).Value
    End Sub

    Private Sub ReturnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnToolStripMenuItem.Click
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub

End Class