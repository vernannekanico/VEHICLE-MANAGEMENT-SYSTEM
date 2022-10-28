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

    Private StorageTypesFieldsToSelect = ""
    Private StorageTypesSelectionFilter = ""
    Private StorageTypesSelectionOrder = ""
    Private CurrentStorageTypesRow As Integer = -1
    Private StorageTypesRecordCount As Integer = -1
    Private CurrentStorageTypeID = -1
    Private StorageTypesDataGridViewAlreadyFormated = False
    Private CurrentStorageTypeCode = ""
    Private WhichStorageType = ""

    Private CurrentStoragesLocationsCounter = 1
    Private EditMode = ""
    Private SelectionMode = ""
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

        StocksLocationsSelectionOrder = " ORDER BY LocationCode_ShortText10 ASC "
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
            ActiveDGViewToolStripTextBox.Text = "Stocks Location"
            DisableAllOtherEditingOptions()
            SaveToolStripMenuItem.Visible = True
            DisableAllDataGridViews()
        Else
            DisableAllDataGridViews()
            EnableAllOtherEditingOptions()
            SaveToolStripMenuItem.Visible = False
        End If
    End Sub
    Private Sub ReturnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnToolStripMenuItem.Click
        'HERE, THIS RETURN TOOL IS USED TO EXIT FROM THE 3  DataGridViews
        CheckChangesCaller = "Return"
        If StockLocationDetailsGroupBox.Visible = False Then
            DoCommonHouseKeeping(Me, SavedCallingForm)
        Else
            CheckChanges()
        End If

    End Sub
    Private Sub CheckChanges()
        If NotValidEntries() Then Exit Sub
        If NoChangesWereMade() Then

            Select Case ActiveDGViewToolStripTextBox.Text
                Case "Storage location"
                    InputBoxGroupBox.Visible = False
                    StoragesLocationsGroupBox.Enabled = True
                Case "Stocks Location"
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
            'SAVE HERE
            Select Case ActiveDGViewToolStripTextBox.Text
                Case "Storage location"
                    UpdateStoragesTable()
                    InputBoxGroupBox.Visible = False
                    StoragesLocationsGroupBox.Enabled = True
                Case "Stocks location"
                Case Else
                    Exit Sub
            End Select
        End If
        EditMode = ""
    End Sub
    Private Function NoChangesWereMade()
        Select Case EditMode
            Case "New"
                If IsEmpty(DescriptionTextBox.Text) Then Return True
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
                StocksLocationsSelectionFilter = " WHERE Mid(LocationCode_ShortText10, 1, 2) = " & InQuotes(StorageLocationCodeTextBox.Text)
                FillStocksLocationsDataGridView()
                StocksLocationsGroupBox.Visible = True
                StoragesLocationsGroupBox.Visible = False
                If SelectionMode = "Select from list of selected" Then
                    StockLocationDetailsGroupBox.Enabled = True
                    MainStorageTypeTextBox.Select()
                    '                  then this storage location Is selected modify view to include sequence .
                    '                 ask for the type now
                Else
                    If StocksLocationsRecordCount = 0 Then
                        SelectionMode = ""
                        CurrentStoragesLocationsCounter = 1
                    Else
                        If StocksLocationsRecordCount = 1 Then
                            StockLocationDetailsGroupBox.Enabled = True
                            MainStorageTypeTextBox.Select()
                        Else
                            MsgBox("Select which storage location or press 'New' ")
                            SelectionMode = "Select from list of selected"
                        End If
                    End If
                End If
        End Select
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        EditMode = "New"
        Select Case ActiveDGViewToolStripTextBox.Text
            Case "Stocks location"
                StockLocationDetailsGroupBox.Visible = True
                StockLocationDetailsGroupBox.Enabled = True
                StorageLocationTextBox.Text = ""
                MainStorageTypeTextBox.Text = ""
                SubStorageTypeTextBox.Text = ""
                BayTextBox.Text = ""
                LevelTextBox.Text = ""
                ActiveDGViewToolStripTextBox.Text = ""
                StorageLocationTextBox.Select()
            Case "Storage location"
                CurrentStoragesLocationID = -1
                InputBoxGroupBox.Visible = True
                DescriptionTextBox.Text = ""
                DescriptionCodeTextBox.Text = ""
                StoragesLocationsGroupBox.Enabled = False
            Case "Storage Types"
                CurrentStorageTypeID = -1
                InputBoxGroupBox.Visible = True
                DescriptionTextBox.Text = ""
                DescriptionCodeTextBox.Text = ""
                StoragesLocationsGroupBox.Enabled = False
            Case Else
        End Select
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        EditMode = "Edit"
        InputBoxGroupBox.Visible = True
        FillField(DescriptionTextBox.Text, StoragesLocationsDataGridView.Item("StoragesLocation_ShortText200", CurrentStoragesLocationsRow).Value)
        FillField(DescriptionCodeTextBox.Text, StoragesLocationsDataGridView.Item("StoragesLocationCode_ShortText2", CurrentStoragesLocationsRow).Value)
        StoragesLocationsGroupBox.Enabled = False
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        EditMode = "Remove"
        Select Case ActiveDGViewToolStripTextBox.Text
            Case "Stocks Location"
                MySelection = "SELECT * FROM StocksTable WHERE StocksLocationID_LongInteger = " & CurrentStocksLocationID.ToString
                JustExecuteMySelection()

                If RecordCount > 0 Then
                    MsgBox("Unable to Delete, this location code is linked to a stock, remove link before removal from file")
                Else
                    MySelection = " DELETE FROM StocksLocationsTable WHERE StocksLocationID_AutoNumber = " & CurrentStocksLocationID.ToString
                    JustExecuteMySelection()
                End If
        End Select
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        CheckChangesCaller = "Save"
        'VALIDATE ENTRIES
        CheckChanges()
    End Sub
    Private Function NotValidEntries()
        Select Case ActiveDGViewToolStripTextBox.Text
            Case "Stocks Location"
                If IsEmpty(StorageLocationTextBox.Text) Then
                    StorageLocationTextBox.Select()
                    Return True
                End If
                If IsEmpty(MainStorageTypeTextBox.Text) Then
                    MainStorageTypeTextBox.Select()
                    Return True
                End If
                If IsEmpty(BayTextBox.Text) Then
                    If MsgBox("Leave the bay field empty ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        BayTextBox.Select()
                        Return True
                    End If
                End If
                If IsEmpty(LevelTextBox.Text) Then
                    If MsgBox("Leave the LEVEL field empty ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        LevelTextBox.Select()
                        Return True
                    End If
                End If
            Case Else
                If IsEmpty(DescriptionTextBox.Text) Then
                    DescriptionTextBox.Select()
                    Return True
                End If
                If IsEmpty(DescriptionCodeTextBox.Text) Then
                    DescriptionCodeTextBox.Select()
                    Return True
                End If
        End Select
        Return False
    End Function
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
        Dim FieldsToUpdate = " StoragesLocation_ShortText200, StoragesLocationCode_ShortText2 "
        Dim FieldsData = InQuotes(DescriptionTextBox.Text) & ", " & InQuotes(DescriptionCodeTextBox.Text)
        CurrentStoragesLocationID = InsertNewRecord("StoragesLocationsTable", FieldsToUpdate, FieldsData)

    End Sub
    Private Sub UpdateCurrentStorageLocationTable()
        Dim RecordFilter = " WHERE StoragesLocationID_Autonumber = " & CurrentStoragesLocationID.ToString
        Dim SetCommand = " SET StoragesLocation_ShortText200 = " & InQuotes(DescriptionTextBox.Text) & "," &
                             " StoragesLocationCode_ShortText2 = " & InQuotes(DescriptionCodeTextBox.Text)
        UpdateTable("StoragesLocationsTable", SetCommand, RecordFilter)
        FillStoragesLocationsDataGridView()
    End Sub
    Private Sub UpdateStoragesTable()
        MySelection = " SELECT * FROM StoragesLocationsTable WHERE StoragesLocationID_Autonumber = " & CurrentStoragesLocationID.ToString
        If RecordCount > 0 Then
            UpdateCurrentStorageLocationTable()
        Else
            AddNewStorageLocation()
        End If
    End Sub
    Private Sub FillStorageTypesDataGridView()

        StorageTypesSelectionOrder = " ORDER BY StorageTypeCode_ShortText2 DESC "
        StorageTypesFieldsToSelect = " 
SELECT 
StorageTypeID_AutoNumber,
StorageTypeCode_ShortText2,
StorageType_ShortText200
FROM StorageTypesTable
"

        MySelection = StorageTypesFieldsToSelect & StorageTypesSelectionFilter & StorageTypesSelectionOrder

        JustExecuteMySelection()
        StorageTypesRecordCount = RecordCount

        StorageTypesDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If StorageTypesRecordCount = 0 Then
            CurrentStorageTypeID = -1
        End If


        ' HERE AT ROW_ENTER, FillStorageTypeConcernsDataGridView is called and StorageTypeConcernsbOX IS ALREADY FORMATTED
        If Not StorageTypesDataGridViewAlreadyFormated Then
            FormatStorageTypesDataGridView()
            SetFormWidthAndGroupBoxLeft(Me,
                                        StocksLocationsMainMenuStrip,
                                        StocksLocationsGroupBox,
                                        StorageTypesGroupBox,
                                        StorageTypesGroupBox,
                                        StorageTypesGroupBox)
        End If

        SetGroupBoxHeight(5, StorageTypesRecordCount, StorageTypesGroupBox, StorageTypesDataGridView)
        Me.Top = VehicleManagementSystemForm.VehicleManagementMenuStrip.Top + VehicleManagementSystemForm.VehicleManagementMenuStrip.Height + 20
        Me.Left = VehicleManagementSystemForm.Left
        Me.Height = VehicleManagementSystemForm.Height - Me.Top

    End Sub
    Private Sub FormatStorageTypesDataGridView()
        StorageTypesDataGridViewAlreadyFormated = True
        StorageTypesGroupBox.Width = 0
        For i = 0 To StorageTypesDataGridView.Columns.GetColumnCount(0) - 1

            StorageTypesDataGridView.Columns.Item(i).Visible = False
            Select Case StorageTypesDataGridView.Columns.Item(i).Name
                Case "StorageType_ShortText200"
                    StorageTypesDataGridView.Columns.Item(i).HeaderText = "Storage Location"
                    StorageTypesDataGridView.Columns.Item(i).Width = 300
                    StorageTypesDataGridView.Columns.Item(i).Visible = True
            End Select

            If StorageTypesDataGridView.Columns.Item(i).Visible = True Then
                StorageTypesGroupBox.Width = StorageTypesGroupBox.Width + StorageTypesDataGridView.Columns.Item(i).Width
            End If
        Next
        If StorageTypesGroupBox.Width > VehicleManagementSystemForm.Width Then
            StorageTypesGroupBox.Width = VehicleManagementSystemForm.Width - 4
        Else
            HorizontalCenter(StorageTypesGroupBox, Me)
        End If
    End Sub
    Private Sub StorageTypesDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles StorageTypesDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If StorageTypesRecordCount = 0 Then Exit Sub

        CurrentStorageTypesRow = e.RowIndex
        CurrentStorageTypeID = StorageTypesDataGridView.Item("StorageTypeID_Autonumber", CurrentStorageTypesRow).Value
        CurrentStorageCode = StorageTypesDataGridView.Item("StorageTypeCode_ShortText2", CurrentStorageTypesRow).Value
    End Sub
    Private Sub AddNewStorageType()
        Dim FieldsToUpdate = " StorageType_ShortText200, StorageTypeCode_ShortText2 "
        Dim FieldsData = InQuotes(DescriptionTextBox.Text) & ", " & InQuotes(DescriptionCodeTextBox.Text)
        CurrentStorageTypeID = InsertNewRecord("StorageTypesTable", FieldsToUpdate, FieldsData)

    End Sub
    Private Sub UpdateCurrentStorageType()
        Dim RecordFilter = " WHERE StorageTypeID_Autonumber = " & CurrentStorageTypeID.ToString
        Dim SetCommand = " SET StorageType_ShortText200 = " & InQuotes(DescriptionTextBox.Text) & "," &
                             " StorageTypeCode_ShortText2 = " & InQuotes(DescriptionCodeTextBox.Text)
        UpdateTable("StorageTypesTable", SetCommand, RecordFilter)
        FillStorageTypesDataGridView()
    End Sub
    Private Sub UpdateStorageTypesTable()
        MySelection = " SELECT * FROM StorageTypesTable WHERE StorageTypeID_Autonumber = " & CurrentStorageTypeID.ToString
        If RecordCount > 0 Then
            UpdateCurrentStorageType()
        Else
            AddNewStorageType()
        End If
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
    Private Sub MainStorageTypeTextBox_Click(sender As Object, e As EventArgs) Handles MainStorageTypeTextBox.Click
        WhichStorageType = "Main"
        If IsEmpty(MainStorageTypeTextBox.Text) Then
            StockLocationDetailsGroupBox.Enabled = False
            StorageTypesGroupBox.Visible = True
            ActiveDGViewToolStripTextBox.Text = "Storage Types"
        Else
            If MsgBox("Would you like to change the storage location ? ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                StockLocationDetailsGroupBox.Enabled = False
                StorageTypesGroupBox.Visible = True
                ActiveDGViewToolStripTextBox.Text = "Storage Types"
            End If
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
    Private Sub StorageTypesGroupBox_VisibleChanged(sender As Object, e As EventArgs) Handles StorageTypesGroupBox.VisibleChanged
        NewToolStripMenuItem.Visible = True
        InputBoxGroupBox.Text = "Storage Location Details"
    End Sub

    Private Sub StocksLocationsGroupBox_EnabledChanged(sender As Object, e As EventArgs) Handles StocksLocationsGroupBox.EnabledChanged
        If StocksLocationsGroupBox.Enabled Then NewToolStripMenuItem.Visible = True
    End Sub

    Private Sub StoragesLocationsGroupBox_EnabledChanged(sender As Object, e As EventArgs) Handles StoragesLocationsGroupBox.EnabledChanged
        If StoragesLocationsGroupBox.Enabled Then NewToolStripMenuItem.Visible = True
    End Sub
    Private Sub StorageTypesGroupBox_EnabledChanged(sender As Object, e As EventArgs) Handles StorageTypesGroupBox.EnabledChanged
        If StorageTypesGroupBox.Enabled Then NewToolStripMenuItem.Visible = True
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