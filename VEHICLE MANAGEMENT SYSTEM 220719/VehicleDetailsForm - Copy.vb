Public Class VehicleDetailsForm
    Private CurrentVehicleDetailsID As Integer = -1
    Private CurrentVehicleDetailsRow As Integer ' used when working with DataGridView
    Private CurrentVehicleTypeID As Integer = -1
    Private CurrentVehicleModelID As Integer = -1
    Private CurrentVehicleTrimID As Integer = -1
    Private CurrentVehicleRepairClassID As Integer = -1

    Private CurrentVehicleID As Integer = -1
    Private CurrentVehicleModelsRelationsID As Integer = -1

    Private VehicleDataGridViewInitialized = False

    Private VehicleFieldsDetailsToSelect = ""
    Private VehicleDetailsTablesLinks = ""
    Private VehicleDetailsSelectionFilter = ""
    Private VehicleDetailsSelectionOrder = ""


    Private SavedMeWidth = 0
    Private MeLocationX As Integer
    Private MeLocationY As Integer

    Private RequestCode As Integer = -1
    Private AllEntriesAreValid = False

    '**************************************************************************************

    Private PurposeOfVehicleDetailsDetailsGroupBoxEntry = ""
    Private SavedYearManufacturedFrom = ""
    Private SavedYearManufacturedTo = ""
    Private SavedVehicleTypeID_LongInteger As Integer = -1
    Private SavedVehicleModelID_LongInteger As Integer = -1
    Private SavedVehicleTrimID_LongInteger As Integer = -1
    Private SavedYearManufactured_ShortText4 = ""
    Private SavedVehicleRepairClassID_LongInteger As Integer = -1
    Private SavedBodyType_ShortText20 = ""
    Private SavedEngineSeries_ShortText20 = ""
    Private SavedFuelType_ShortText20 = ""
    Private SavedEngine_ShortText20 = ""

    '**************************************************************************************


    Private Sub VehicleForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        MeLocationX = Me.Location.X
        Me.Width = 520
        VehicleDetailsDataGridView.Width = 500
        Dim x = ActivatedBy
        ' callers  1 - "VehicleManagementSystemForm"

        '    Dim VehicleDetailsKeysInQuote = Chr(34) & Trim(Tunnel1) & Chr(34)
        '    VehicleDetailsSelectionFilter = " WHERE  NOT (" & VehicleDetailsKeysInQuote & " LIKE (TRIM(STR(VehicleDetailsID_AutoNumber)) & " & Chr(34) & "|" & Chr(34) & "))"

        RefreshVehhicleDetailsForm()
        SetupVehicleDetailsDataGridView()

        'SET AND RESET ALL ENTRY PARAMETERS
        ResetTunnels()

    End Sub
    Private Sub RefreshVehhicleDetailsForm()
        FillVehicleDataGridView()
        VehicleDetailsDataGridView.Enabled = True
        DisableModifyVehicleDetailsMode()
    End Sub

    Private Sub FillVehicleDataGridView()

        VehicleFieldsDetailsToSelect = " Select " &
                                       " VehicleDetailsTable.VehicleDetailsID_AutoNumber, " &
                                       " VehicleTypeTable.VehicleType_ShortText20, " &
                                       " VehicleModelsTable.VehicleModel_ShortText20, " &
                                      " VehicleTrimTable.VehicleTrimName_ShortText25, " &
                                       " VehicleDetailsTable.YearManufactured_ShortText4, " &
                                       " VehicleDetailsTable.BodyType_ShortText20, " &
                                       " VehicleDetailsTable.EngineSeries_ShortText20, " &
                                       " VehicleDetailsTable.FuelType_ShortText20, " &
                                       " VehicleDetailsTable.Engine_ShortText20, " &
                                       " VehicleDetailsTable.VehicleModelsRelationsID_LongInteger, " &
                                       " VehicleDetailsTable.VehicleRepairClassID_LongInteger, " &
                                       " VehicleModelsRelationsTable.VehicleTypeID_LongInteger, " &
                                       " VehicleModelsRelationsTable.VehicleModelID_LongInteger, " &
                                       " VehicleModelsRelationsTable.VehicleTrimID_LongInteger, " &
                                       " VehicleRepairClassTable.YearManufacturedFrom_ShortText4, " &
                                       " VehicleRepairClassTable.YearManufacturedTo_ShortText4 "


        VehicleDetailsTablesLinks = " FROM((((VehicleDetailsTable LEFT JOIN VehicleModelsRelationsTable ON VehicleDetailsTable.VehicleModelsRelationsID_LongInteger = VehicleModelsRelationsTable.[VehicleModelsRelationsID_Autonumber]) LEFT JOIN VehicleTypeTable On VehicleModelsRelationsTable.VehicleTypeID_LongInteger = VehicleTypeTable.VehicleTypeID_AutoNumber) LEFT JOIN VehicleTrimTable On VehicleModelsRelationsTable.VehicleTrimID_LongInteger = VehicleTrimTable.VehicleTrimID_Autonumber) LEFT JOIN VehicleModelsTable On VehicleModelsRelationsTable.VehicleModelID_LongInteger = VehicleModelsTable.VehicleModelID_Autonumber) LEFT JOIN VehicleRepairClassTable On VehicleDetailsTable.VehicleRepairClassID_LongInteger = VehicleRepairClassTable.VehicleRepairClassID_AutoNumber "


        VehicleDetailsSelectionOrder = " Order by VehicleType_ShortText20 Asc, " &
                                          "VehicleModel_ShortText20 Asc, " &
                                          "VehicleTrimName_ShortText25, " &
                                          "YearManufactured_ShortText4 "

        MySelection = VehicleFieldsDetailsToSelect & VehicleDetailsTablesLinks & VehicleDetailsSelectionFilter & VehicleDetailsSelectionOrder


        SavedMeWidth = Me.Width


        JustExecuteMySelection()
        If RecordCount = 0 Then
            SelectToolStripMenuItem.Visible = False
            AddToolStripMenuItem.Visible = True
            EditToolStripMenuItem.Visible = False
            DeleteToolStripMenuItem.Visible = False
            ViewToolStripMenuItem.Visible = False
            SaveToolStripMenuItem.Visible = False
            SearchToolStrip.Enabled = False
        Else
            DisableModifyVehicleDetailsMode()
        End If
        VehicleDetailsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable


    End Sub

    Private Sub SetupVehicleDetailsDataGridView()
        ' Setup DataGrid View   

        VehicleDetailsDataGridView.Columns.Item("VehicleDetailsID_AutoNumber").Visible = False
        VehicleDetailsDataGridView.Columns.Item("VehicleRepairClassID_LongInteger").Visible = False
        VehicleDetailsDataGridView.Columns.Item("VehicleModelID_LongInteger").Visible = False
        VehicleDetailsDataGridView.Columns.Item("VehicleTypeID_LongInteger").Visible = False
        VehicleDetailsDataGridView.Columns.Item("VehicleTrimID_LongInteger").Visible = False
        VehicleDetailsDataGridView.Columns.Item("VehicleModelsRelationsID_LongInteger").Visible = False

        VehicleDetailsDataGridView.Columns.Item("VehicleType_ShortText20").HeaderText = "Type"
        VehicleDetailsDataGridView.Columns.Item("VehicleType_ShortText20").Width = 150

        VehicleDetailsDataGridView.Columns.Item("VehicleModel_ShortText20").HeaderText = "Model"
        VehicleDetailsDataGridView.Columns.Item("VehicleModel_ShortText20").Width = 150

        VehicleDetailsDataGridView.Columns.Item("VehicleTrimName_ShortText25").HeaderText = "Trim"
        VehicleDetailsDataGridView.Columns.Item("VehicleTrimName_ShortText25").Width = 150

        VehicleDetailsDataGridView.Columns.Item("YearManufactured_ShortText4").HeaderText = "Year"
        VehicleDetailsDataGridView.Columns.Item("YearManufactured_ShortText4").Width = 50

        VehicleDetailsDataGridView.Columns.Item("Engine_ShortText20").HeaderText = "Engine"
        VehicleDetailsDataGridView.Columns.Item("Engine_ShortText20").Width = 150

        VehicleDetailsDataGridView.Columns.Item("BodyType_ShortText20").HeaderText = "Body Type"
        VehicleDetailsDataGridView.Columns.Item("BodyType_ShortText20").Width = 150

        VehicleDetailsDataGridView.Columns.Item("EngineSeries_ShortText20").HeaderText = "Engine Series"
        VehicleDetailsDataGridView.Columns.Item("EngineSeries_ShortText20").Width = 150

        VehicleDetailsDataGridView.Columns.Item("FuelType_ShortText20").HeaderText = "Fuel Type"
        VehicleDetailsDataGridView.Columns.Item("FuelType_ShortText20").Width = 150

        VehicleDetailsDataGridView.Columns.Item("YearManufacturedFrom_ShortText4").HeaderText = "From"
        VehicleDetailsDataGridView.Columns.Item("YearManufacturedFrom_ShortText4").Width = 50

        VehicleDetailsDataGridView.Columns.Item("YearManufacturedTo_ShortText4").HeaderText = "To"
        VehicleDetailsDataGridView.Columns.Item("YearManufacturedTo_ShortText4").Width = 50


        VehicleDetailsDataGridView.Width = VehicleDetailsDataGridView.Columns.Item("VehicleType_ShortText20").Width +
                                 VehicleDetailsDataGridView.Columns.Item("VehicleModel_ShortText20").Width +
                                  VehicleDetailsDataGridView.Columns.Item("VehicleTrimName_ShortText25").Width +
                                 VehicleDetailsDataGridView.Columns.Item("YearManufactured_ShortText4").Width +
                                  VehicleDetailsDataGridView.Columns.Item("YearManufacturedFrom_ShortText4").Width +
                                 VehicleDetailsDataGridView.Columns.Item("YearManufacturedTo_ShortText4").Width +
                                  VehicleDetailsDataGridView.Columns.Item("Engine_ShortText20").Width +
                                 VehicleDetailsDataGridView.Columns.Item("BodyType_ShortText20").Width +
                                 VehicleDetailsDataGridView.Columns.Item("EngineSeries_ShortText20").Width +
                                 VehicleDetailsDataGridView.Columns.Item("FuelType_ShortText20").Width +
                                50
        Me.Width = VehicleDetailsDataGridView.Width + 20

        ' ***************************************************************************************************************************************

        VehicleDetailsDataGridView.Width = 0
        For i = 0 To VehicleDetailsDataGridView.Columns.GetColumnCount(0) - 1
            If VehicleDetailsDataGridView.Columns.Item(i).Visible = True Then
                VehicleDetailsDataGridView.Width = VehicleDetailsDataGridView.Width + VehicleDetailsDataGridView.Columns.Item(i).Width
            End If
        Next
        VehicleDetailsDataGridView.Width = VehicleDetailsDataGridView.Width + 20

        Me.Width = VehicleDetailsDataGridView.Width + 30
        SavedMeWidth = Me.Width
        MeLocationX = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
        If MeLocationX < 0 Then
            MeLocationX = 0
        End If
        Me.Location = New Point(MeLocationX, MeLocationY)


        ' ****************************************************************************************************************************************

    End Sub
    Private Sub VehicleDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles VehicleDetailsDataGridView.RowEnter
        If e.RowIndex < 0 Then Exit Sub
        If RecordCount = 0 Then Exit Sub
        CurrentVehicleDetailsRow = e.RowIndex
        If Not VehicleDataGridViewInitialized Then
            VehicleDataGridViewInitialized = True
        End If
        If CurrentVehicleDetailsID = VehicleDetailsDataGridView.Item("VehicleDetailsID_AutoNumber", CurrentVehicleDetailsRow).Value Then Exit Sub
        CurrentVehicleDetailsID = VehicleDetailsDataGridView.Item("VehicleDetailsID_AutoNumber", CurrentVehicleDetailsRow).Value
        CurrentVehicleModelID = VehicleDetailsDataGridView.Item("VehicleModelID_LongInteger", CurrentVehicleDetailsRow).Value
        CurrentVehicleTypeID = VehicleDetailsDataGridView.Item("VehicleTypeID_LongInteger", CurrentVehicleDetailsRow).Value
        CurrentVehicleTrimID = VehicleDetailsDataGridView.Item("VehicleTrimID_LongInteger", CurrentVehicleDetailsRow).Value
        CurrentVehicleRepairClassID = Val(IIf(IsDBNull(VehicleDetailsDataGridView.Item("VehicleRepairClassID_LongInteger", CurrentVehicleDetailsRow).Value), "-1", VehicleDetailsDataGridView.Item("VehicleRepairClassID_LongInteger", CurrentVehicleDetailsRow).Value))
        CurrentVehicleModelsRelationsID = Val(IIf(IsDBNull(VehicleDetailsDataGridView.Item("VehicleModelsRelationsID_LongInteger", CurrentVehicleDetailsRow).Value), "-1", VehicleDetailsDataGridView.Item("VehicleModelsRelationsID_LongInteger", CurrentVehicleDetailsRow).Value))
    End Sub
    Private Sub VehicleDataGridView_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles VehicleDetailsDataGridView.DataBindingComplete
        Dim NoOfHeaderLines = 1
        Dim RecordsDisplyed = RecordCount
        Dim FormLowPointFromGrid = 90
        If RecordCount > 27 Then
            Me.Location = New Point(MeLocationX, 50)
            RecordsDisplyed = 27
        Else
            RecordsDisplyed = RecordCount + 1
        End If
        VehicleDetailsDataGridView.Height = (VehicleDetailsDataGridView.ColumnHeadersHeight * NoOfHeaderLines) + (DataGridViewRowHeight * RecordsDisplyed) + DataGridViewRowHeight
        Me.Height = VehicleDetailsDataGridView.Height + FormLowPointFromGrid

    End Sub
    Private Sub VehicleForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        'Enables calling form
        Select Case ActivatedBy.Text
            Case "VehicleManagementSystemForm"
                VehicleManagementSystemForm.Enabled = True ' triggers enabledchaned event of calling form
            Case "OwnerForm"
                OwnerForm.Enabled = True
            Case "VehiclesServicedForm"
                Tunnel2 = CurrentVehicleDetailsID
                '                VehiclesServicedForm.Enabled = True
            Case "VehiclesServicedDetailsForm"
                VehiclesServicedDetailsForm.Enabled = True

            Case "MasterCodeBookForm"
                If Tunnel3 > -1 Then
                    MasterCodeBookForm.Enabled = True
                Else

                End If


            Case Else
                MsgBox("Calling Form Name not specified here, hit break here")
        End Select
        ActivatedBy.Text = ""

    End Sub

    Private Sub VehicleDetailsForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        'Refresh datagridviw here
        ' GET RETURNED DATA HERE


        '************************************************************************************************************************************

        'Refresh datagridviw here
        ' GET RETURNED DATA HERE
        If Me.Enabled = False Then Exit Sub

        If Not NotEmpty(Tunnel1) Then
            Exit Sub
        End If
        Select Case RequestCode
        ' 1  = ShowVehicleModelForm()
        ' 2 = ShowVehicleRepairClassForm()
        ' 3 = ShowVehicleTrimForm()
            Case 1
                ' returned values from VehicleModelsRelationsForm
                ' Tunnel1 = CurrentVehicleModelRelationsID
                ' Tunnel2 = CurrentVehicleTypeID
                '  Tunnel3 = CurrentVehicleModelID

                CurrentVehicleModelsRelationsID = Tunnel1
                CurrentVehicleTypeID = Tunnel2
                CurrentVehicleModelID = Tunnel3
                YearManufacturedTextBox.Select()
            Case 2
                CurrentVehicleRepairClassID = Tunnel1
            Case 3
                MsgBox("Calling Form Name not specified here, break here")

        End Select


        Me.Show()

        '************************************************************************************************************************************
        ResetTunnels()

    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click

        PurposeOfVehicleDetailsDetailsGroupBoxEntry = "ADD"
        ' Shows the details editing group box and enables edit to the fields
        ' All DataGridViews are disabled
        ' Searching is disable
        CurrentVehicleDetailsID = -1
        VehicleDetailsDetailsGroupBox.Text = "Add a new Vehicle with a new Type or model or trim "
        EnableModifyVehicleDetailsMode()          '' Add Edit Delete are turned off and Cancel ans Save options are made available

    End Sub
    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        PurposeOfVehicleDetailsDetailsGroupBoxEntry = "EDIT"
        VehicleDetailsDetailsGroupBox.Text = "Edit current Vehicle "
        EnableModifyVehicleDetailsMode()          '' Add Edit Delete are turned off and Cancel ans Save options are made available

    End Sub

    Private Sub AddAVehicleRecord()

        ' EXECUTE INSERT COMMAND
        MySelection = "INSERT INTO VehicleDetailsTable (" &
                                            " VehicleModelsRelationsID_LongInteger,  " &
                                            " YearManufactured_ShortText4,  " &
                                            " Engine_ShortText20,  " &
                                            " BodyType_ShortText20,  " &
                                            " EngineSeries_ShortText20,  " &
                                            " FuelType_ShortText20,  " &
                                            " VehicleRepairClassID_LongInteger)  " &
                                             " VALUES (" &
                                               Str(CurrentVehicleModelsRelationsID) & "," &
                                               Chr(34) & Trim(RTrim(YearManufacturedTextBox.Text)) & Chr(34) & "," &
                                               Chr(34) & RTrim(EngineTypeTextBox.Text) & Chr(34) & "," &
                                               Chr(34) & RTrim(BodyTypeTextBox.Text) & Chr(34) & "," &
                                               Chr(34) & RTrim(Trim(EngineSeriesTextBox.Text)) & Chr(34) & "," &
                                               Chr(34) & RTrim(Trim(FuelTypeTextBox.Text)) & Chr(34) & "," &
                                               Str(CurrentVehicleRepairClassID) & ")"


        If NoRecordFound() Then Dim xxx As Integer = 0 'always IsNot found

        MySelection = "Select * FROM VehicleDetailsTable " &
                              " WHERE VehicleModelsRelationsID_LongInteger = " & Str(CurrentVehicleModelsRelationsID) & " AND " &
                              "       YearManufactured_ShortText4 = " & Chr(34) & Trim(YearManufacturedTextBox.Text) & Chr(34)

        If NoRecordFound() Then
            MsgBox("PROBLEM ...... unseccessful save ")
            Exit Sub
        End If

        Dim r As DataRow = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)

        CurrentVehicleID = r("VehicleDetailsID_AutoNumber")

    End Sub


    Private Sub SaveChangesToTheVehicle()

        'test existence here

        Select Case PurposeOfVehicleDetailsDetailsGroupBoxEntry
            Case "ADD"

                MySelection = "SELECT * " &
                       " FROM VehicleDetaiLsTable " &
                       " WHERE VehicleModelsRelationsID_LongInteger = " & Str(CurrentVehicleModelsRelationsID) &
                       " AND YearManufactured_ShortText4 = " & Chr(34) & Trim(YearManufacturedTextBox.Text) & Chr(34)

                If NoRecordFound() Then
                    AddAVehicleRecord()

                Else
                    MsgBox("This record already exists")
                    CurrentVehicleID = -1
                    Exit Sub
                End If

            Case "EDIT"
                Dim VehicleFieldsToUpdate = ""
                Dim VehicleFilter = " WHERE VehicleDetailsID_AutoNumber = " & Str(CurrentVehicleDetailsID)
                Dim MyNull = Chr(34) & Chr(34)


                VehicleFieldsToUpdate = " UPDATE VehicleDetailsTable SET " &
                                                           " VehicleModelsRelationsID_LongInteger = " & Str(CurrentVehicleModelsRelationsID) & ", " &
                                                           " YearManufactured_ShortText4 = " & Trim(RTrim(YearManufacturedFromTextBox.Text)) & ", " &
                                                           " VehicleRepairClassID_LongInteger = " & Str(CurrentVehicleRepairClassID)


                If NotEmpty(EngineTypeTextBox.Text) Then
                    VehicleFieldsToUpdate = VehicleFieldsToUpdate & ", Engine_ShortText20  = " & Chr(34) & EngineTypeTextBox.Text & Chr(34)
                Else
                    VehicleFieldsToUpdate = VehicleFieldsToUpdate & ", Engine_ShortText20  = " & MyNull
                End If

                If NotEmpty(BodyTypeTextBox.Text) Then
                    VehicleFieldsToUpdate = VehicleFieldsToUpdate & ", BodyType_ShortText20 = " & Chr(34) & BodyTypeTextBox.Text & Chr(34)
                Else
                    VehicleFieldsToUpdate = VehicleFieldsToUpdate & ", BodyType_ShortText20 = " & MyNull
                End If

                If NotEmpty(EngineSeriesTextBox.Text) Then
                    VehicleFieldsToUpdate = VehicleFieldsToUpdate & ", EngineSeries_ShortText20 = " & Chr(34) & EngineSeriesTextBox.Text & Chr(34)
                Else
                    VehicleFieldsToUpdate = VehicleFieldsToUpdate & ", EngineSeries_ShortText20 = " & MyNull
                End If

                If NotEmpty(FuelTypeTextBox.Text) Then
                    VehicleFieldsToUpdate = VehicleFieldsToUpdate & ", FuelType_ShortText20 = " & Chr(34) & FuelTypeTextBox.Text & Chr(34)
                Else
                    VehicleFieldsToUpdate = VehicleFieldsToUpdate & ", FuelType_ShortText20 = " & MyNull
                End If

                MySelection = VehicleFieldsToUpdate & VehicleFilter

                If NoRecordFound() Then Dim dummy = 1


        End Select


    End Sub


    ' *****************************************************************************************************************************************************

    Private Sub EnableModifyVehicleDetailsMode()      ' Add Edit Delete are turned off and Cancel ans Save options are made available
        DisableAddEditDeleteVehicleDetailsMenuItems()
        VehicleDetailsDataGridView.Enabled = False
        ShowVehicleDetailsDetailsGroupBox()
    End Sub

    Private Sub DisableModifyVehicleDetailsMode()
        EnableAddEditDeleteVehicleDetailsMenuItems()
        Me.Width = SavedMeWidth
        VehicleDetailsDetailsGroupBox.Visible = False
        VehicleDetailsDataGridView.Enabled = True
    End Sub
    Private Sub EnableAddEditDeleteVehicleDetailsMenuItems()
        SelectToolStripMenuItem.Visible = True
        SaveToolStripMenuItem.Visible = False
        AddToolStripMenuItem.Visible = True
        EditToolStripMenuItem.Visible = True
        ViewToolStripMenuItem.Visible = True
        DeleteToolStripMenuItem.Visible = True
        SearchToolStrip.Visible = True
    End Sub
    Private Sub DisableAddEditDeleteVehicleDetailsMenuItems()
        SelectToolStripMenuItem.Visible = False
        SaveToolStripMenuItem.Visible = True
        AddToolStripMenuItem.Visible = False
        EditToolStripMenuItem.Visible = False
        ViewToolStripMenuItem.Visible = False
        SearchToolStrip.Visible = False
        DeleteToolStripMenuItem.Visible = False
    End Sub


    Private Sub ShowVehicleDetailsDetailsGroupBox()

        If Me.Width < VehicleDetailsDetailsGroupBox.Width Then                                              ' detailsgroupBox is wider
            Me.Width = VehicleDetailsDetailsGroupBox.Width + 30
        End If
        If Me.Height < (VehicleDetailsDetailsGroupBox.Height + 90 + DataGridViewRowHeight) Then             ' DetailsGroupBox has more height than the gridview normally occurs with less records
            Me.Height = VehicleDetailsDetailsGroupBox.Height + 90 + DataGridViewRowHeight
        End If

        If Not VehicleDetailsDetailsGroupBox.Text = "" Then                                                  ' set by ViewToolStripMenuItem.Click in order to allow change of record in the Datagridview which
            ' enables user to view details of other records selected in the DataGridView
            '         VehicleDetailsDetailsGroupBox.Text = ""
            VehicleDetailsDataGridView.Enabled = False
        Else
            MsgBox("Calling Form Name not specified here, break here")
        End If


        If CurrentVehicleDetailsID = -1 Then                                                        ' no record selected
            CurrentVehicleTypeID = -1
            VehicleTypeTextBox.Text = ""
            CurrentVehicleModelID = -1
            VehicleModelTextBox.Text = ""
            CurrentVehicleTrimID = -1
            VehicleTrimTextBox.Text = ""
            CurrentVehicleRepairClassID = -1
            YearManufacturedFromTextBox.Text = ""
            YearManufacturedToTextBox.Text = ""
            YearManufacturedTextBox.Text = ""
            BodyTypeTextBox.Text = ""
            EngineTypeTextBox.Text = ""
            BodyTypeTextBox.Text = ""
            EngineSeriesTextBox.Text = ""
            YearManufacturedTextBox.Text = ""
            BodyTypeTextBox.Text = ""
            EngineTypeTextBox.Text = ""
            BodyTypeTextBox.Text = ""
            EngineSeriesTextBox.Text = ""
        Else                                                                                    ' record is selected to show

            YearManufacturedFromTextBox.Text = IIf(IsDBNull(VehicleDetailsDataGridView.Item("YearManufacturedFrom_ShortText4", CurrentVehicleDetailsRow).Value), "", VehicleDetailsDataGridView.Item("YearManufacturedFrom_ShortText4", CurrentVehicleDetailsRow).Value)
            YearManufacturedToTextBox.Text = IIf(IsDBNull(VehicleDetailsDataGridView.Item("YearManufacturedTo_ShortText4", CurrentVehicleDetailsRow).Value), "", VehicleDetailsDataGridView.Item("YearManufacturedTo_ShortText4", CurrentVehicleDetailsRow).Value)
            VehicleTypeTextBox.Text = IIf(IsDBNull(VehicleDetailsDataGridView.Item("VehicleType_ShortText20", CurrentVehicleDetailsRow).Value), "", VehicleDetailsDataGridView.Item("VehicleType_ShortText20", CurrentVehicleDetailsRow).Value)
            YearManufacturedTextBox.Text = IIf(IsDBNull(VehicleDetailsDataGridView.Item("YearManufactured_ShortText4", CurrentVehicleDetailsRow).Value), "", VehicleDetailsDataGridView.Item("YearManufactured_ShortText4", CurrentVehicleDetailsRow).Value)
            VehicleModelTextBox.Text = IIf(IsDBNull(VehicleDetailsDataGridView.Item("VehicleModel_ShortText20", CurrentVehicleDetailsRow).Value), "", VehicleDetailsDataGridView.Item("VehicleModel_ShortText20", CurrentVehicleDetailsRow).Value)
            VehicleTrimTextBox.Text = IIf(IsDBNull(VehicleDetailsDataGridView.Item("VehicleTrimName_ShortText25", CurrentVehicleDetailsRow).Value), "", VehicleDetailsDataGridView.Item("VehicleTrimName_ShortText25", CurrentVehicleDetailsRow).Value)
            EngineTypeTextBox.Text = IIf(IsDBNull(VehicleDetailsDataGridView.Item("Engine_ShortText20", CurrentVehicleDetailsRow).Value), "", VehicleDetailsDataGridView.Item("Engine_ShortText20", CurrentVehicleDetailsRow).Value)
            BodyTypeTextBox.Text = IIf(IsDBNull(VehicleDetailsDataGridView.Item("BodyType_ShortText20", CurrentVehicleDetailsRow).Value), "", VehicleDetailsDataGridView.Item("BodyType_ShortText20", CurrentVehicleDetailsRow).Value)
            EngineSeriesTextBox.Text = IIf(IsDBNull(VehicleDetailsDataGridView.Item("EngineSeries_ShortText20", CurrentVehicleDetailsRow).Value), "", VehicleDetailsDataGridView.Item("EngineSeries_ShortText20", CurrentVehicleDetailsRow).Value)
            FuelTypeTextBox.Text = IIf(IsDBNull(VehicleDetailsDataGridView.Item("FuelType_ShortText20", CurrentVehicleDetailsRow).Value), "", VehicleDetailsDataGridView.Item("FuelType_ShortText20", CurrentVehicleDetailsRow).Value)
        End If

        SavedVehicleTypeID_LongInteger = CurrentVehicleTypeID
        SavedVehicleModelID_LongInteger = CurrentVehicleModelID
        SavedVehicleTrimID_LongInteger = CurrentVehicleTrimID
        SavedYearManufactured_ShortText4 = YearManufacturedTextBox.Text
        SavedVehicleRepairClassID_LongInteger = CurrentVehicleRepairClassID
        SavedBodyType_ShortText20 = BodyTypeTextBox.Text
        SavedEngineSeries_ShortText20 = EngineTypeTextBox.Text
        SavedFuelType_ShortText20 = BodyTypeTextBox.Text
        SavedEngine_ShortText20 = EngineSeriesTextBox.Text

        SavedYearManufacturedFrom = YearManufacturedFromTextBox.Text
        SavedYearManufacturedTo = YearManufacturedToTextBox.Text
        VehicleDetailsDetailsGroupBox.Visible = True

    End Sub
    Private Sub YearManufacturedTextBox_Leave(sender As Object, e As EventArgs) Handles YearManufacturedTextBox.Leave
        ValidateEntries()
    End Sub
    Private Sub ValidateEntries()
        AllEntriesAreValid = False

        If Trim(VehicleModelTextBox.Text) = "" Then
            VehicleModelTextBox.Select()
            Exit Sub
        Else
            If Not ValidYearEntry(YearManufacturedTextBox.Text) Then
                YearManufacturedTextBox.Select()
                MsgBox("Invalid Year Entry")
                Exit Sub
            Else
                If CurrentVehicleRepairClassID < 1 Then
                    ShowVehicleRepairClassForm()
                End If
            End If
        End If
        ' EngineTypeTextBox.Select()
        AllEntriesAreValid = True
    End Sub

    Private Function ValidYearEntry(YearToValidate)
        If Not YearToValidate = "" Then
            If Not Val(YearToValidate) < 1900 Then
                If Not YearToValidate > Year(Today) Then
                    Return True
                End If
            End If
        End If
        Return False
    End Function



    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click

    End Sub

    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnToolStripMenuItem.Click


        ' *********************************************************************************************************************
        Select Case VehicleDetailsDetailsGroupBox.Visible
            Case True
                Dim FieldChangeOccured = False

                If SavedYearManufacturedFrom <> YearManufacturedFromTextBox.Text Then
                    FieldChangeOccured = True
                End If
                If SavedYearManufacturedTo <> YearManufacturedToTextBox.Text Then
                    FieldChangeOccured = True
                End If
                If SavedVehicleTypeID_LongInteger <> CurrentVehicleTypeID Then
                    FieldChangeOccured = True
                End If
                If SavedVehicleModelID_LongInteger <> CurrentVehicleModelID Then
                    FieldChangeOccured = True
                End If
                If SavedVehicleTrimID_LongInteger <> CurrentVehicleTrimID Then
                    FieldChangeOccured = True
                End If
                If SavedYearManufactured_ShortText4 <> YearManufacturedTextBox.Text Then
                    FieldChangeOccured = True
                End If
                If SavedBodyType_ShortText20 <> BodyTypeTextBox.Text Then
                    FieldChangeOccured = True
                End If
                If SavedEngineSeries_ShortText20 <> EngineTypeTextBox.Text Then
                    FieldChangeOccured = True
                End If
                If SavedFuelType_ShortText20 <> BodyTypeTextBox.Text Then
                    FieldChangeOccured = True
                End If
                If SavedEngine_ShortText20 <> EngineSeriesTextBox.Text Then
                    FieldChangeOccured = True
                End If

                If FieldChangeOccured Then
                    If Not MsgBox("Changes have been done. Do you want to discard changes ?", vbYesNo) = vbYes Then
                        Exit Sub
                    End If
                End If
                RefreshVehhicleDetailsForm()
            Case Else
                Tunnel1 = -1
                Me.Close()
        End Select

        ' *********************************************************************************************************************

    End Sub

    Private Sub SelectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectToolStripMenuItem.Click
        Tunnel2 = CurrentVehicleDetailsID
        Tunnel3 = CurrentVehicleRepairClassID
        Dim VehicleString =
                            VehicleDetailsDataGridView.Item("YearManufactured_ShortText4", CurrentVehicleDetailsRow).Value & " " &
                            VehicleDetailsDataGridView.Item("VehicleType_ShortText20", CurrentVehicleDetailsRow).Value & " " &
                            VehicleDetailsDataGridView.Item("VehicleModel_ShortText20", CurrentVehicleDetailsRow).Value & " " &
                            VehicleDetailsDataGridView.Item("VehicleTrimName_ShortText25", CurrentVehicleDetailsRow).Value & " " &
                            VehicleDetailsDataGridView.Item("Engine_ShortText20", CurrentVehicleDetailsRow).Value
        Select Case ActivatedBy.Text
            Case = "MasterCodeBookForm"
                MasterCodeBookForm.DefaultVehicleModelTextBox.Text = VehicleString

            Case = "VehiclesServicedDetailsForm"
                VehiclesServicedDetailsForm.VehicleTextBox.Text = VehicleString

            Case Else
                MsgBox("break, need to know which flow is this")

        End Select
        Me.Close()
    End Sub
    Private Sub VehicleDetailsDetailsGroupBox_VisibleChanged(sender As Object, e As EventArgs) Handles VehicleDetailsDetailsGroupBox.VisibleChanged
        If VehicleDetailsDetailsGroupBox.Visible = True Then
            ValidateEntries()

            If VehicleModelTextBox.Text = "" Then
                ShowVehicleModelForm()
            End If
        End If
    End Sub

    Private Sub VehicleModelTextBox_GotFocus(sender As Object, e As EventArgs) Handles VehicleModelTextBox.GotFocus
        ShowVehicleModelForm()
    End Sub
    Private Sub VehicleModelTextBox_TextChanged(sender As Object, e As EventArgs) Handles VehicleModelTextBox.TextChanged
        If Me.Enabled = True Then
            If VehicleModelTextBox.Text = "" Then
                ShowVehicleModelForm()
            End If
        Else
            ' returned values from VehicleModelsRelationsForm

            ' Tunnel1 = CurrentVehicleModelsRelationsID
            ' Tunnel2 = CurrentVehicleTypeID
            ' Tunnel3 = CurrentVehicleModelID

            '            CurrentVehicleModelsRelationsID = Tunnel1
            '

            '            CurrentVehicleTypeID = Tunnel2
            '            CurrentVehicleModelID = Tunnel3

        End If

    End Sub

    Private Sub ShowVehicleModelForm()
        RequestCode = 1
        ' 1  = ShowVehicleModelForm()
        ' 2 = ShowVehicleRepairClassForm()
        ' 3 = ShowVehicleTrimForm()

        Me.Enabled = False
        VehicleModelsRelationsForm.ActivatedBy.Text = Me.Name
        Tunnel1 = Str(CurrentVehicleTypeID)
        Tunnel2 = VehicleTypeTextBox.Text
        VehicleModelsRelationsForm.Show()
        VehicleModelsRelationsForm.SearchVehicleTypeTextBox.Text = VehicleModelTextBox.Text
        VehicleModelsRelationsForm.SearchVehicleTypeTextBox.Select()
    End Sub
    Private Sub ShowVehicleRepairClassForm()
        RequestCode = "2"
        ' 1  = ShowVehicleModelForm()
        ' 2 = ShowVehicleRepairClassForm()
        ' 3 = ShowVehicleTrimForm()

        Me.Enabled = False
        ' calling Vehicle Repair Class should clip the Type and Model to current type of vehicle
        Tunnel1 = CurrentVehicleTypeID
        Tunnel2 = CurrentVehicleModelID

        Tunnel3 = Str(CurrentVehicleModelsRelationsID)
        VehicleRepairClassForm.ActivatedBy.Text = Me.Name
        VehicleRepairClassForm.Show()
        ''       VehicleModelsRelationsForm.SearchVehicleModelTextBox.Text = VehicleModelTextBox.Text
        '       VehicleModelsRelationsForm.SearchVehicleModelTextBox.Select()
    End Sub
    Private Sub RepairYearRangeButton_Click(sender As Object, e As EventArgs) Handles RepairYearRangeButton.Click
        ShowVehicleRepairClassForm()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        ValidateEntries()
        If Not AllEntriesAreValid Then
            Exit Sub
        End If
        SaveChangesToTheVehicle()
        VehicleDetailsDetailsGroupBox.Visible = False
        RefreshVehhicleDetailsForm()

    End Sub

End Class