Public Class TemporaryForThisProjectForm
    Private FluidSpecificationsFieldsToSelect = ""
    Private FluidSpecificationsSelectionFilter = ""
    Private FluidSpecificationsSelectionOrder = ""
    Private FluidSpecificationsRecordCount As Integer = -1
    Private CurrentFluidSpecificationsID As Integer = -1
    Private CurrentFluidSpecificationsDataGridViewRow As Integer = -1
    Private FluidSpecificationsDataGridViewAlreadyFormated = False


    Private SavedCallingForm As Form

    Private Sub TemporaryForThisProjectForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        SavedCallingForm = CallingForm
        FillFluidSpecificationsDataGridView()
    End Sub

    Private Sub FillFluidSpecificationsDataGridView()

        '   USING FluidSpecificationsQuery

        FluidSpecificationsFieldsToSelect =
"
SELECT SpecificationsTable.PartSpecifications_ShortText255
FROM SpecificationsTable;
"


        FluidSpecificationsSelectionFilter = " "
        FluidSpecificationsSelectionOrder = ""

        MySelection = FluidSpecificationsFieldsToSelect & FluidSpecificationsSelectionFilter & FluidSpecificationsSelectionOrder
        JustExecuteMySelection()

        FluidSpecificationsRecordCount = RecordCount
        FluidSpecificationsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If Not FluidSpecificationsDataGridViewAlreadyFormated Then
            FormatFluidSpecificationsDataGridView()
        End If
    End Sub

    Private Sub FormatFluidSpecificationsDataGridView()
        FluidSpecificationsDataGridViewAlreadyFormated = True
        FluidSpecificationsDataGridView.Width = 0

        For i = 0 To FluidSpecificationsDataGridView.Columns.GetColumnCount(0) - 1

            FluidSpecificationsDataGridView.Columns.Item(i).Visible = False

            Select Case FluidSpecificationsDataGridView.Columns.Item(i).Name
                Case "PartSpecifications_ShortText255"
                    FluidSpecificationsDataGridView.Columns.Item(i).Width = 300
                    FluidSpecificationsDataGridView.Columns.Item(i).Visible = True
            End Select
            If FluidSpecificationsDataGridView.Columns.Item(i).Visible = True Then
                FluidSpecificationsDataGridView.Width = FluidSpecificationsDataGridView.Width + FluidSpecificationsDataGridView.Columns.Item(i).Width
            End If
        Next
        If FluidSpecificationsDataGridView.Width > Me.Width Then
            FluidSpecificationsDataGridView.Width = Me.Width - 100
        Else
            FluidSpecificationsDataGridView.Width = FluidSpecificationsDataGridView.Width
        End If
        FluidSpecificationsDataGridView.Width = FluidSpecificationsDataGridView.Width
        FluidSpecificationsDataGridView.Left = (Me.Width - FluidSpecificationsDataGridView.Width) / 2
        '===========================

        Dim RecordsDisplyed = FluidSpecificationsRecordCount
        Dim FormLowPointFromGrid = 90
        If FluidSpecificationsRecordCount > 27 Then
            RecordsDisplyed = 27
        Else
            RecordsDisplyed = FluidSpecificationsRecordCount
        End If

        FluidSpecificationsDataGridView.Height = (FluidSpecificationsDataGridView.ColumnHeadersHeight) + (DataGridViewRowHeight * (RecordsDisplyed + 1))
    End Sub
    Private Sub FluidSpecificationsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 Then Exit Sub
        If FluidSpecificationsRecordCount = 0 Then Exit Sub
        CurrentFluidSpecificationsDataGridViewRow = e.RowIndex

        CurrentFluidSpecificationsID = FluidSpecificationsDataGridView.Item("FluidSpecificationsID_Autonumber", CurrentFluidSpecificationsDataGridViewRow).Value
    End Sub

    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub
End Class