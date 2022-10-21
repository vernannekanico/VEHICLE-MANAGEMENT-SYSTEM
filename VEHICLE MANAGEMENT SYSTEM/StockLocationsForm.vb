Public Class StockLocationsForm
    Private StocksLocationsFieldsToSelect = ""
    Private StocksLocationsSelectionFilter = ""
    Private StocksLocationsSelectionOrder = ""
    Private CurrentStocksLocationsRow As Integer = -1
    Private StocksLocationsRecordCount As Integer = -1
    Private CurrentStocksLocationID = -1
    Private CurrentStocksLocationStatus As String
    Private StocksLocationsDataGridViewAlreadyFormated = False

    Private SavedCallingForm As Form

    Private Sub StocksLocationForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SavedCallingForm = CallingForm
        StocksLocationsSelectionFilter = ""
        FillStocksLocationsDataGridView()

    End Sub
    Private Sub FillStocksLocationsDataGridView()

        StocksLocationsSelectionOrder = " ORDER BY StocksLocationID_AutoNumber DESC "
        StocksLocationsFieldsToSelect = " 
SELECT StocksLocationsTable.LocationCode_ShortText10, StocksLocationsTable.LocationDescription, StorageLocationsTable.StorageLocationCode_ShortText2, StorageLocationsTable.StorageLocation_ShortText80, StorageTypesTable_1.StorageRackCode_ShortText3, StorageTypesTable_1.StorageRackDescription_ShortText50, StocksLocationsTable.StocksLocationID_AutoNumber, StocksLocationsTable.Bay, StocksLocationsTable.Level
FROM ((StocksLocationsTable LEFT JOIN StorageLocationsTable ON StocksLocationsTable.StorageLocationID_LongInteger = StorageLocationsTable.StorageLocationID_Autonumber) LEFT JOIN StorageTypesTable ON StocksLocationsTable.StorageTypeID1_LongInteger = StorageTypesTable.StorageTypeID_Autonumber) LEFT JOIN StorageTypesTable AS StorageTypesTable_1 ON StocksLocationsTable.StorageTypeID2_LongInteger = StorageTypesTable_1.StorageTypeID_Autonumber
"

        MySelection = StocksLocationsFieldsToSelect & StocksLocationsSelectionFilter & StocksLocationsSelectionOrder

        JustExecuteMySelection()
        StocksLocationsRecordCount = RecordCount

        StocksLocationsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If StocksLocationsRecordCount = 0 Then
            CurrentStocksLocationID = -1
        End If


        ' HERE AT ROW_ENTER, FillStocksLocationConcernsDataGridView is called and StocksLocationConcernsbOX IS ALREADY FORMATTED
        If Not StocksLocationsDataGridViewAlreadyFormated Then
            FormatStocksLocationsDataGridView()
            SetFormWidthAndGroupBoxLeft(Me,
                                        StocksLocationsMainMenuStrip,
                                        StocksLocationsGroupBox,
                                        StocksLocationsGroupBox,
                                        StocksLocationsGroupBox,
                                        StocksLocationsGroupBox)
        End If

        SetGroupBoxHeight(5, StocksLocationsRecordCount, StocksLocationsGroupBox, StocksLocationsDataGridView)
        Me.Top = VehicleManagementSystemForm.VehicleManagementMenuStrip.Top + VehicleManagementSystemForm.VehicleManagementMenuStrip.Height + 20
        Me.Left = VehicleManagementSystemForm.Left
        Me.Height = VehicleManagementSystemForm.Height - Me.Top

    End Sub
    Private Sub FormatStocksLocationsDataGridView()
        StocksLocationsDataGridViewAlreadyFormated = True
        StocksLocationsGroupBox.Width = 0
        For i = 0 To StocksLocationsDataGridView.Columns.GetColumnCount(0) - 1

            StocksLocationsDataGridView.Columns.Item(i).Visible = False
            Select Case StocksLocationsDataGridView.Columns.Item(i).Name
                Case "LocationCode_ShortText10"
                    StocksLocationsDataGridView.Columns.Item(i).HeaderText = "Location Code"
                    StocksLocationsDataGridView.Columns.Item(i).Width = 120
                    StocksLocationsDataGridView.Columns.Item(i).Visible = True
                Case "LocationDescription"
                    StocksLocationsDataGridView.Columns.Item(i).HeaderText = "Description"
                    StocksLocationsDataGridView.Columns.Item(i).Width = 300
                    StocksLocationsDataGridView.Columns.Item(i).Visible = True
                Case "Bay"
                    StocksLocationsDataGridView.Columns.Item(i).HeaderText = "Bay"
                    StocksLocationsDataGridView.Columns.Item(i).Width = 70
                    StocksLocationsDataGridView.Columns.Item(i).Visible = True
                Case "Level"
                    StocksLocationsDataGridView.Columns.Item(i).HeaderText = "Level (1 is the lowest)"
                    StocksLocationsDataGridView.Columns.Item(i).Width = 120
                    StocksLocationsDataGridView.Columns.Item(i).Visible = True
            End Select

            If StocksLocationsDataGridView.Columns.Item(i).Visible = True Then
                StocksLocationsGroupBox.Width = StocksLocationsGroupBox.Width + StocksLocationsDataGridView.Columns.Item(i).Width
            End If
        Next
        If StocksLocationsGroupBox.Width > VehicleManagementSystemForm.Width Then
            StocksLocationsGroupBox.Width = VehicleManagementSystemForm.Width - 4
        Else
            HorizontalCenter(StocksLocationsGroupBox, Me)
        End If
    End Sub
    Private Sub StocksLocationsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles StocksLocationsDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If StocksLocationsRecordCount = 0 Then Exit Sub

        CurrentStocksLocationsRow = e.RowIndex
        CurrentStocksLocationID = StocksLocationsDataGridView.Item("StocksLocationID_AutoNumber", CurrentStocksLocationsRow).Value

        FillField(CurrentStocksLocationStatus, StocksLocationsDataGridView.Item("StocksLocationStatus", CurrentStocksLocationsRow).Value)

        Select Case CurrentStocksLocationStatus
            Case "Assigned"
        End Select

    End Sub
    Private Sub ReturnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnToolStripMenuItem.Click
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click

    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click

    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click

    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click

    End Sub
End Class