Public Class StockLocationsForm
    Private StocksLocationsFieldsToSelect = ""
    Private StocksLocationsSelectionFilter = ""
    Private StocksLocationsSelectionOrder = ""
    Private CurrentStocksLocationsRow As Integer = -1
    Private StocksLocationsRecordCount As Integer = -1
    Private CurrentStocksLocationID = -1
    Private StocksLocationsDataGridViewAlreadyFormated = False

    Private StorageLocationsFieldsToSelect = ""
    Private StorageLocationsSelectionFilter = ""
    Private StorageLocationsSelectionOrder = ""
    Private CurrentStorageLocationsRow As Integer = -1
    Private StorageLocationsRecordCount As Integer = -1
    Private CurrentStorageLocationID = -1
    Private StorageLocationsDataGridViewAlreadyFormated = False
    Private CurrentStorageCode = ""

    Private SavedCallingForm As Form

    Private Sub StocksLocationForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SavedCallingForm = CallingForm
        HorizontalCenter(StockLocationDetailsGroupBox, Me)
        VerticalCenter(StockLocationDetailsGroupBox, Me)
        StocksLocationsSelectionFilter = ""
        FillStocksLocationsDataGridView()
        FillStorageLocationsDataGridView()
        HorizontalCenter(InputBoxGroupBox, Me)
        VerticalCenter(InputBoxGroupBox, Me)
        StorageLocationsGroupBox.Top = StocksLocationsGroupBox.Top
        StorageLocationsGroupBox.Left = StocksLocationsGroupBox.Left
        SaveToolStripMenuItem.Visible = False
    End Sub
    Private Sub FillStocksLocationsDataGridView()

        StocksLocationsSelectionOrder = " ORDER BY StocksLocationID_AutoNumber DESC "
        StocksLocationsFieldsToSelect = " 
SELECT 
StocksLocationsTable.StocksLocationID_AutoNumber, 
StocksLocationsTable.LocationCode_ShortText10, 
StorageLocationsTable.StorageLocation_ShortText200,  
MainStorageTypesTable.StorageTypeDescription_ShortText150, 
SubStorageTypesTable.StorageTypeDescription_ShortText150, 
StocksLocationsTable.Bay_ShortText1, 
StocksLocationsTable.Level_Byte
FROM ((StocksLocationsTable LEFT JOIN StorageLocationsTable ON StocksLocationsTable.StorageLocationID_LongInteger = StorageLocationsTable.StorageLocationID_Autonumber) LEFT JOIN StorageTypesTable AS MainStorageTypesTable ON StocksLocationsTable.[MainStorageType_LongInteger] = MainStorageTypesTable.StorageTypeID_Autonumber) LEFT JOIN StorageTypesTable AS SubStorageTypesTable ON StocksLocationsTable.[SubStorageType_LongInteger] = SubStorageTypesTable.StorageTypeID_Autonumber
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
                                        StorageLocationsGroupBox,
                                        StocksLocationsGroupBox,
                                        StocksLocationsGroupBox)
        End If

        SetGroupBoxHeight(5, StocksLocationsRecordCount, StocksLocationsGroupBox, StocksLocationsDataGridView)
        Me.Top = VehicleManagementSystemForm.VehicleManagementMenuStrip.Top + VehicleManagementSystemForm.VehicleManagementMenuStrip.Height + 20
        Me.Left = VehicleManagementSystemForm.Left
        Me.Height = VehicleManagementSystemForm.Height - Me.Top
        StocksLocationsGroupBox.Top = StocksLocationsMainMenuStrip.Top + StocksLocationsMainMenuStrip.Height
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
                Case "StorageLocation_ShortText200"
                    StocksLocationsDataGridView.Columns.Item(i).HeaderText = "Storage Location"
                    StocksLocationsDataGridView.Columns.Item(i).Width = 300
                    StocksLocationsDataGridView.Columns.Item(i).Visible = True
                Case "MainStorageTypesTable.StorageTypeDescription_ShortText150"
                    StocksLocationsDataGridView.Columns.Item(i).HeaderText = "Main Storage Type"
                    StocksLocationsDataGridView.Columns.Item(i).Width = 200
                    StocksLocationsDataGridView.Columns.Item(i).Visible = True
                Case "SubStorageTypesTable.StorageTypeDescription_ShortText150"
                    StocksLocationsDataGridView.Columns.Item(i).HeaderText = "Sub Storage Type"
                    StocksLocationsDataGridView.Columns.Item(i).Width = 200
                    StocksLocationsDataGridView.Columns.Item(i).Visible = True
                Case "Bay_ShortText1"
                    StocksLocationsDataGridView.Columns.Item(i).HeaderText = "Bay"
                    StocksLocationsDataGridView.Columns.Item(i).Width = 70
                    StocksLocationsDataGridView.Columns.Item(i).Visible = True
                Case "Level_Byte"
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
        End If
    End Sub
    Private Sub StocksLocationsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles StocksLocationsDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If StocksLocationsRecordCount = 0 Then Exit Sub

        CurrentStocksLocationsRow = e.RowIndex
        CurrentStocksLocationID = StocksLocationsDataGridView.Item("StocksLocationID_AutoNumber", CurrentStocksLocationsRow).Value
        CurrentStorageLocationID = StocksLocationsDataGridView.Item("StocksLocationID_AutoNumber", CurrentStocksLocationsRow).Value
    End Sub
    Private Sub ReturnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnToolStripMenuItem.Click
        Select Case ActiveDGViewToolStripTextBox.Text
            Case "Storage location"
                StorageLocationsGroupBox.Visible = False
                StockLocationDetailsGroupBox.Enabled = True
            Case "Stocks location"
                DoCommonHouseKeeping(Me, SavedCallingForm)
            Case ""
        End Select
    End Sub
    Private Sub SelectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectToolStripMenuItem.Click
        If StocksLocationsGroupBox.Enabled = True Then
            Dim cc = 1
        ElseIf StorageLocationsGroupBox.Visible = True Then
            StorageLocationTextBox.Text = StorageLocationsDataGridView.Item("StorageLocation_ShortText80", CurrentStorageLocationsRow).Value
        End If
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        If StocksLocationsGroupBox.Enabled = True Then
            StocksLocationsGroupBox.Enabled = False
            StockLocationDetailsGroupBox.Visible = True
            StorageLocationTextBox.Text = ""
            MainStorageTypeTextBox.Text = ""
            SubStorageTypeTextBox.Text = ""
            BayTextBox.Text = ""
            LevelTextBox.Text = ""
            ActiveDGViewToolStripTextBox.Text = ""
            StorageLocationTextBox.Select()
        ElseIf StorageLocationsGroupBox.Visible = True Then
            Dim xx = 1
        End If
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click

    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click

    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click

    End Sub
    Private Sub FillStorageLocationsDataGridView()

        StorageLocationsSelectionOrder = " ORDER BY StorageLocationCode_ShortText1 DESC "
        StorageLocationsFieldsToSelect = " 
SELECT 
StorageLocationID_AutoNumber,
StorageLocationCode_ShortText1,
StorageLocation_ShortText200
FROM StorageLocationsTable
"

        MySelection = StorageLocationsFieldsToSelect & StorageLocationsSelectionFilter & StorageLocationsSelectionOrder

        JustExecuteMySelection()
        StorageLocationsRecordCount = RecordCount

        StorageLocationsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If StorageLocationsRecordCount = 0 Then
            CurrentStorageLocationID = -1
        End If


        ' HERE AT ROW_ENTER, FillStorageLocationConcernsDataGridView is called and StorageLocationConcernsbOX IS ALREADY FORMATTED
        If Not StorageLocationsDataGridViewAlreadyFormated Then
            FormatStorageLocationsDataGridView()
            SetFormWidthAndGroupBoxLeft(Me,
                                        StocksLocationsMainMenuStrip,
                                        StocksLocationsGroupBox,
                                        StorageLocationsGroupBox,
                                        StorageLocationsGroupBox,
                                        StorageLocationsGroupBox)
        End If

        SetGroupBoxHeight(5, StorageLocationsRecordCount, StorageLocationsGroupBox, StorageLocationsDataGridView)
        Me.Top = VehicleManagementSystemForm.VehicleManagementMenuStrip.Top + VehicleManagementSystemForm.VehicleManagementMenuStrip.Height + 20
        Me.Left = VehicleManagementSystemForm.Left
        Me.Height = VehicleManagementSystemForm.Height - Me.Top

    End Sub
    Private Sub FormatStorageLocationsDataGridView()
        StorageLocationsDataGridViewAlreadyFormated = True
        StorageLocationsGroupBox.Width = 0
        For i = 0 To StorageLocationsDataGridView.Columns.GetColumnCount(0) - 1

            StorageLocationsDataGridView.Columns.Item(i).Visible = False
            Select Case StorageLocationsDataGridView.Columns.Item(i).Name
                Case "StorageLocation_ShortText200"
                    StorageLocationsDataGridView.Columns.Item(i).HeaderText = "Storage Location"
                    StorageLocationsDataGridView.Columns.Item(i).Width = 300
                    StorageLocationsDataGridView.Columns.Item(i).Visible = True
            End Select

            If StorageLocationsDataGridView.Columns.Item(i).Visible = True Then
                StorageLocationsGroupBox.Width = StorageLocationsGroupBox.Width + StorageLocationsDataGridView.Columns.Item(i).Width
            End If
        Next
        If StorageLocationsGroupBox.Width > VehicleManagementSystemForm.Width Then
            StorageLocationsGroupBox.Width = VehicleManagementSystemForm.Width - 4
        Else
            HorizontalCenter(StorageLocationsGroupBox, Me)
        End If
    End Sub
    Private Sub StorageLocationsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles StorageLocationsDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If StorageLocationsRecordCount = 0 Then Exit Sub

        CurrentStorageLocationsRow = e.RowIndex
        CurrentStorageLocationID = StorageLocationsDataGridView.Item("StorageLocationID_Autonumber", CurrentStorageLocationsRow).Value
        CurrentStorageCode = StorageLocationsDataGridView.Item("StorageLocationCode_ShortText1", CurrentStorageLocationsRow).Value
    End Sub

    Private Sub StorageLocationTextBox_TextChanged(sender As Object, e As EventArgs) Handles StorageLocationTextBox.TextChanged

    End Sub

    Private Sub StorageLocationTextBox_Click(sender As Object, e As EventArgs) Handles StorageLocationTextBox.Click
        If IsEmpty(StorageLocationTextBox.Text) Then
            StorageLocationsGroupBox.Visible = True
            ActiveDGViewToolStripTextBox.Text = "Storage location"
        End If
    End Sub
    Private Sub ActiveDGViewToolStripTextBox_TextChanged(sender As Object, e As EventArgs) Handles ActiveDGViewToolStripTextBox.TextChanged
        SelectToolStripMenuItem.Visible = True
        StockLocationDetailsGroupBox.Enabled = False
        Select Case ActiveDGViewToolStripTextBox.Text
            Case "Storage location"

            Case "Stocks location"
            Case ""
                SelectToolStripMenuItem.Visible = False
                StockLocationDetailsGroupBox.Enabled = True
        End Select
    End Sub
    Private Sub StockLocationDetailsGroupBox_VisibleChanged(sender As Object, e As EventArgs) Handles StockLocationDetailsGroupBox.VisibleChanged
        If StockLocationDetailsGroupBox.Visible Then
            StockLocationDetailsGroupBox.Enabled = True
            DisableAllOtherEditingOptions()
        Else
            SaveToolStripMenuItem.Visible = False
            EnableAllOtherEditingOptions()
        End If
    End Sub
    Private Sub StockLocationDetailsGroupBox_EnabledChanged(sender As Object, e As EventArgs) Handles StockLocationDetailsGroupBox.EnabledChanged
        If StockLocationDetailsGroupBox.Visible Then
            SaveToolStripMenuItem.Visible = True
        Else
            SaveToolStripMenuItem.Visible = False
        End If
    End Sub
    Private Sub DisableAllOtherEditingOptions()
        SelectToolStripMenuItem.Visible = False
        NewToolStripMenuItem.Visible = False
        EditToolStripMenuItem.Visible = False
        RemoveToolStripMenuItem.Visible = False
    End Sub
    Private Sub EnableAllOtherEditingOptions()
        SelectToolStripMenuItem.Visible = True
        NewToolStripMenuItem.Visible = True
        EditToolStripMenuItem.Visible = True
        RemoveToolStripMenuItem.Visible = True
    End Sub

    Private Sub SelectToolStripMenuItem_VisibleChanged(sender As Object, e As EventArgs) Handles SelectToolStripMenuItem.VisibleChanged
        If SelectToolStripMenuItem.Visible Then
            SaveToolStripMenuItem.Visible = False
        End If

    End Sub
End Class