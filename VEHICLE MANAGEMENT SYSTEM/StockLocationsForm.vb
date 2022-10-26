Imports System.Reflection

Public Class StockLocationsForm
    Private StocksLocationsFieldsToSelect = ""
    Private StocksLocationsSelectionFilter = ""
    Private StocksLocationsSelectionOrder = ""
    Private CurrentStocksLocationsRow As Integer = -1
    Private StocksLocationsRecordCount As Integer = -1
    Private CurrentStocksLocationID = -1
    Private StocksLocationsDataGridViewAlreadyFormated = False

    Private StoragesLocationsFieldsToSelect = ""
    Private StoragesLocationsSelectionFilter = ""
    Private StoragesLocationsSelectionOrder = ""
    Private CurrentStoragesLocationsRow As Integer = -1
    Private StoragesLocationsRecordCount As Integer = -1
    Private CurrentStoragesLocationID = -1
    Private StoragesLocationsDataGridViewAlreadyFormated = False
    Private CurrentStorageCode = ""

    Private EditMode = ""
    Private CheckChangesCaller = ""
    Private SavedCallingForm As Form

    Private Sub StocksLocationForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SavedCallingForm = CallingForm
        HorizontalCenter(StockLocationDetailsGroupBox, Me)
        VerticalCenter(StockLocationDetailsGroupBox, Me)
        StocksLocationsSelectionFilter = ""
        FillStocksLocationsDataGridView()
        FillStoragesLocationsDataGridView()
        HorizontalCenter(InputBoxGroupBox, Me)
        VerticalCenter(InputBoxGroupBox, Me)
        StoragesLocationsGroupBox.Top = StocksLocationsGroupBox.Top
        StoragesLocationsGroupBox.Left = StocksLocationsGroupBox.Left
        StocksLocationsGroupBox.Enabled = True
    End Sub
    Private Sub FillStocksLocationsDataGridView()

        StocksLocationsSelectionOrder = " ORDER BY StocksLocationID_AutoNumber DESC "
        StocksLocationsFieldsToSelect = " 
SELECT 
StocksLocationsTable.StocksLocationID_AutoNumber, 
StocksLocationsTable.LocationCode_ShortText10, 
StoragesLocationsTable.StoragesLocation_ShortText200,  
MainStorageTypesTable.StorageTypeDescription_ShortText150, 
SubStorageTypesTable.StorageTypeDescription_ShortText150, 
StocksLocationsTable.Bay_ShortText1, 
StocksLocationsTable.Level_Byte
FROM ((StocksLocationsTable LEFT JOIN StoragesLocationsTable ON StocksLocationsTable.StoragesLocationID_LongInteger = StoragesLocationsTable.StoragesLocationID_Autonumber) LEFT JOIN StorageTypesTable AS MainStorageTypesTable ON StocksLocationsTable.[MainStorageType_LongInteger] = MainStorageTypesTable.StorageTypeID_Autonumber) LEFT JOIN StorageTypesTable AS SubStorageTypesTable ON StocksLocationsTable.[SubStorageType_LongInteger] = SubStorageTypesTable.StorageTypeID_Autonumber
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
                                        StoragesLocationsGroupBox,
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
                Case "StoragesLocation_ShortText200"
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
        CurrentStoragesLocationID = StocksLocationsDataGridView.Item("StocksLocationID_AutoNumber", CurrentStocksLocationsRow).Value
    End Sub
    Private Sub ReturnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnToolStripMenuItem.Click
        CheckChangesCaller = "Return"
        If Not StockLocationDetailsGroupBox.Visible Then
            DoCommonHouseKeeping(Me, SavedCallingForm)
            Exit Sub
        End If
        CheckChanges()
        DoCommonHouseKeeping(Me, SavedCallingForm)

    End Sub
    Private Sub CheckChanges()
        If NotValidEntries() Then Exit Sub
        If NoChangesWereMade() Then

            Select Case ActiveDGViewToolStripTextBox.Text
                Case "Storage location"
                    InputBoxGroupBox.Visible = False
                    StoragesLocationsGroupBox.Enabled = True
                Case Else
                    StockLocationDetailsGroupBox.Visible = False
            End Select
            Exit Sub
        Else
            If CheckChangesCaller = "Return" Then
                If MsgBox("Would you like to disregard the changes", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    DoCommonHouseKeeping(Me, SavedCallingForm)
                    Exit Sub
                End If
            Else
                If MsgBox("Continue save the changes", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            End If
            Select Case ActiveDGViewToolStripTextBox.Text
                Case "Storage location"
                    StoragesLocationsGroupBox.Visible = False
                    StockLocationDetailsGroupBox.Enabled = True
                Case "Stocks location"
                    StockLocationDetailsGroupBox.Enabled = False
                    StockLocationDetailsGroupBox.Visible = False
                    StocksLocationsGroupBox.Enabled = True
                Case ""
                Case Else
            End Select
        End If
        'SAVE HERE
        Select Case ActiveDGViewToolStripTextBox.Text
            Case "Storage location"
                UpdateStoragesTable()
                InputBoxGroupBox.Visible = False
                StoragesLocationsGroupBox.Enabled = True
            Case Else
                Exit Sub
        End Select
        EditMode = ""
    End Sub
    Private Function NoChangesWereMade()
        Select Case EditMode
            Case "New"
            Case "Edit"
                Select Case ActiveDGViewToolStripTextBox.Text
                    Case "Storage location"
                        If DescriptionTextBox.Text = StoragesLocationsDataGridView.Item("StoragesLocation_ShortText200", CurrentStoragesLocationsRow).Value Then Return True
                End Select
            Case ""         'StockLocationDetailsGroupBox.Visible = true
                StockLocationDetailsGroupBox.Visible = False
                StocksLocationsDataGridView.Enabled = True
        End Select
        Return False
    End Function
    Private Sub SelectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectToolStripMenuItem.Click
        Select Case ActiveDGViewToolStripTextBox.Text
            Case "Storage location"
                FillField(StorageLocationTextBox.Text, StoragesLocationsDataGridView.Item("StoragesLocation_ShortText200", CurrentStoragesLocationsRow).Value)
                FillField(StorageLocationCodeTextBox.Text, StoragesLocationsDataGridView.Item("StoragesLocationCode_ShortText2", CurrentStoragesLocationsRow).Value)
                StockLocationDetailsGroupBox.Enabled = True
        End Select
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        EditMode = "New"
        If StocksLocationsGroupBox.Enabled = True Then
            StockLocationDetailsGroupBox.Visible = True
            StockLocationDetailsGroupBox.Enabled = True
            StorageLocationTextBox.Text = ""
            MainStorageTypeTextBox.Text = ""
            SubStorageTypeTextBox.Text = ""
            BayTextBox.Text = ""
            LevelTextBox.Text = ""
            ActiveDGViewToolStripTextBox.Text = ""
            StorageLocationTextBox.Select()
        ElseIf StoragesLocationsGroupBox.Visible = True Then
            Dim xx = 1
        End If
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        EditMode = "Edit"
        InputBoxGroupBox.Visible = True
        FillField(DescriptionTextBox.Text, StoragesLocationsDataGridView.Item("StoragesLocation_ShortText200", CurrentStoragesLocationsRow).Value)
        StoragesLocationsGroupBox.Enabled = False
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        EditMode = ""

    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        CheckChangesCaller = "Save"
        'VALIDATE ENTRIES
        CheckChanges()
    End Sub
    Private Function NotValidEntries()
        Dim Validation = False
        If IsEmpty(DescriptionTextBox.Text) Then
            Validation = True
            DescriptionTextBox.Select()
        End If
        If IsEmpty(DescriptionCodeTextBox.Text) Then
            Validation = True
            DescriptionCodeTextBox.Select()
        End If
        Return Validation
    End Function

    Private Sub UpdateStoragesTable()
        MySelection = " SELECT * FROM StoragesLocationsTable WHERE StoragesLocationID_Autonumber = " & CurrentStoragesLocationID.ToString
        If RecordCount > 0 Then
            UpdateCurrentStorageLocationTable()
        Else
            AddNewStorageLocation()
        End If
    End Sub

    Private Sub FillStoragesLocationsDataGridView()

        StoragesLocationsSelectionOrder = " ORDER BY StoragesLocationCode_ShortText2 DESC "
        StoragesLocationsFieldsToSelect = " 
SELECT 
StoragesLocationID_AutoNumber,
StoragesLocationCode_ShortText2,
StoragesLocation_ShortText200
FROM StoragesLocationsTable
"

        MySelection = StoragesLocationsFieldsToSelect & StoragesLocationsSelectionFilter & StoragesLocationsSelectionOrder

        JustExecuteMySelection()
        StoragesLocationsRecordCount = RecordCount

        StoragesLocationsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If StoragesLocationsRecordCount = 0 Then
            CurrentStoragesLocationID = -1
        End If


        ' HERE AT ROW_ENTER, FillStoragesLocationConcernsDataGridView is called and StoragesLocationConcernsbOX IS ALREADY FORMATTED
        If Not StoragesLocationsDataGridViewAlreadyFormated Then
            FormatStoragesLocationsDataGridView()
            SetFormWidthAndGroupBoxLeft(Me,
                                        StocksLocationsMainMenuStrip,
                                        StocksLocationsGroupBox,
                                        StoragesLocationsGroupBox,
                                        StoragesLocationsGroupBox,
                                        StoragesLocationsGroupBox)
        End If

        SetGroupBoxHeight(5, StoragesLocationsRecordCount, StoragesLocationsGroupBox, StoragesLocationsDataGridView)
        Me.Top = VehicleManagementSystemForm.VehicleManagementMenuStrip.Top + VehicleManagementSystemForm.VehicleManagementMenuStrip.Height + 20
        Me.Left = VehicleManagementSystemForm.Left
        Me.Height = VehicleManagementSystemForm.Height - Me.Top

    End Sub
    Private Sub FormatStoragesLocationsDataGridView()
        StoragesLocationsDataGridViewAlreadyFormated = True
        StoragesLocationsGroupBox.Width = 0
        For i = 0 To StoragesLocationsDataGridView.Columns.GetColumnCount(0) - 1

            StoragesLocationsDataGridView.Columns.Item(i).Visible = False
            Select Case StoragesLocationsDataGridView.Columns.Item(i).Name
                Case "StoragesLocation_ShortText200"
                    StoragesLocationsDataGridView.Columns.Item(i).HeaderText = "Storage Location"
                    StoragesLocationsDataGridView.Columns.Item(i).Width = 300
                    StoragesLocationsDataGridView.Columns.Item(i).Visible = True
            End Select

            If StoragesLocationsDataGridView.Columns.Item(i).Visible = True Then
                StoragesLocationsGroupBox.Width = StoragesLocationsGroupBox.Width + StoragesLocationsDataGridView.Columns.Item(i).Width
            End If
        Next
        If StoragesLocationsGroupBox.Width > VehicleManagementSystemForm.Width Then
            StoragesLocationsGroupBox.Width = VehicleManagementSystemForm.Width - 4
        Else
            HorizontalCenter(StoragesLocationsGroupBox, Me)
        End If
    End Sub
    Private Sub StoragesLocationsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles StoragesLocationsDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If StoragesLocationsRecordCount = 0 Then Exit Sub

        CurrentStoragesLocationsRow = e.RowIndex
        CurrentStoragesLocationID = StoragesLocationsDataGridView.Item("StoragesLocationID_Autonumber", CurrentStoragesLocationsRow).Value
        CurrentStorageCode = StoragesLocationsDataGridView.Item("StoragesLocationCode_ShortText2", CurrentStoragesLocationsRow).Value
    End Sub
    Private Sub AddNewStorageLocation()

    End Sub
    Private Sub UpdateCurrentStorageLocationTable()
        Dim RecordFilter = " WHERE StoragesLocationID_Autonumber = " & CurrentStoragesLocationID.ToString
        Dim SetCommand = " SET StoragesLocation_ShortText200 = " & InQuotes(DescriptionTextBox.Text) & "," &
                             " StoragesLocationCode_ShortText2 = " & InQuotes(DescriptionCodeTextBox.Text)
        UpdateTable("StoragesLocationsTable", SetCommand, RecordFilter)
        FillStoragesLocationsDataGridView()
    End Sub
    Private Sub StoragesLocationTextBox_TextChanged(sender As Object, e As EventArgs) Handles StorageLocationTextBox.TextChanged
    End Sub

    Private Sub StoragesLocationTextBox_Click(sender As Object, e As EventArgs) Handles StorageLocationTextBox.Click
        If IsEmpty(StorageLocationTextBox.Text) Then
            StockLocationDetailsGroupBox.Enabled = False
            StoragesLocationsGroupBox.Visible = True
            ActiveDGViewToolStripTextBox.Text = "Storage location"
        Else
            If MsgBox("Would you like to change the storage location ? ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                StockLocationDetailsGroupBox.Enabled = False
                StoragesLocationsGroupBox.Visible = True
                ActiveDGViewToolStripTextBox.Text = "Storage location"
            End If
        End If
    End Sub
    Private Sub StockLocationDetailsGroupBox_VisibleChanged(sender As Object, e As EventArgs) Handles StockLocationDetailsGroupBox.VisibleChanged
        If StockLocationDetailsGroupBox.Visible Then
            DisableAllDataGridViews()
        Else
            StockLocationDetailsGroupBox.Enabled = False
            StocksLocationsGroupBox.Enabled = True
        End If
    End Sub
    Private Sub StockLocationDetailsGroupBox_EnabledChanged(sender As Object, e As EventArgs) Handles StockLocationDetailsGroupBox.EnabledChanged
        If StockLocationDetailsGroupBox.Enabled Then
            DisableAllOtherEditingOptions()
            SaveToolStripMenuItem.Visible = True
            DisableAllDataGridViews()
        Else
            DisableAllDataGridViews()
            EnableAllOtherEditingOptions()
            SaveToolStripMenuItem.Visible = False
        End If
    End Sub

    Private Sub DisableAllOtherEditingOptions()
        SelectToolStripMenuItem.Visible = False
        EditToolStripMenuItem.Visible = False
        RemoveToolStripMenuItem.Visible = False
    End Sub
    Private Sub EnableAllOtherEditingOptions()
        SelectToolStripMenuItem.Visible = True
        EditToolStripMenuItem.Visible = True
        RemoveToolStripMenuItem.Visible = True
    End Sub
    Private Sub DisableAllDataGridViews()
        NewToolStripMenuItem.Visible = False
        StocksLocationsGroupBox.Enabled = False
        StoragesLocationsGroupBox.Visible = False
        DisableAllOtherEditingOptions()
    End Sub

    Private Sub StoragesLocationsGroupBox_VisibleChanged(sender As Object, e As EventArgs) Handles StoragesLocationsGroupBox.VisibleChanged
        If StoragesLocationsGroupBox.Visible Then
            NewToolStripMenuItem.Visible = True
            InputBoxGroupBox.Text = "Storage Location Details"
        End If
    End Sub

    Private Sub StocksLocationsGroupBox_EnabledChanged(sender As Object, e As EventArgs) Handles StocksLocationsGroupBox.EnabledChanged
        If StocksLocationsGroupBox.Enabled Then NewToolStripMenuItem.Visible = True
    End Sub

    Private Sub StoragesLocationsGroupBox_EnabledChanged(sender As Object, e As EventArgs) Handles StoragesLocationsGroupBox.EnabledChanged
        If StoragesLocationsGroupBox.Enabled Then NewToolStripMenuItem.Visible = True
    End Sub

    Private Sub InputBoxGroupBox_VisibleChanged(sender As Object, e As EventArgs) Handles InputBoxGroupBox.VisibleChanged
        If InputBoxGroupBox.Visible Then
            DisableAllOtherEditingOptions()
            SaveToolStripMenuItem.Visible = True
            DisableAllDataGridViews()
        Else
            DisableAllDataGridViews()
            EnableAllOtherEditingOptions()
            SaveToolStripMenuItem.Visible = False
        End If
    End Sub

    Private Sub DescriptionTextBox_TextChanged(sender As Object, e As EventArgs) Handles DescriptionTextBox.TextChanged
        If IsNotEmpty(DescriptionTextBox.Text) Then DescriptionCodeTextBox.Enabled = True
    End Sub
    Private Sub DescriptionCodeTextBox_Click(sender As Object, e As EventArgs) Handles DescriptionCodeTextBox.Click
        If IsEmpty(DescriptionCodeTextBox.Text) Then DescriptionCodeTextBox.Text = GetSuggestionCode(DescriptionTextBox.Text)
    End Sub
    Private Function GetSuggestionCode(Description)
        Dim SuggestionCode = ""
        Dim SecondWordStartColumn = InStr(Description, Space(1))
        If SecondWordStartColumn > 0 Then
            SuggestionCode = Mid(Description, 1, 1).ToUpper & Mid(Description, SecondWordStartColumn + 1, 1).ToUpper
        Else
            SuggestionCode = Mid(Description, 1, 1).ToUpper & Mid(Description, 2, 1).ToLower
        End If
        Return SuggestionCode
    End Function

End Class