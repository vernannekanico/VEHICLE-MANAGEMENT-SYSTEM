Public Class VehiclesForm
    Private CurrentVehicleDetailsRow As Integer ' used when working with DataGridView
    Private CurrentVehicleTypeID As Integer = -1
    Private CurrentVehicleModelID As Integer = -1
    Private CurrentVehicleTrimID As Integer = -1

    Private CurrentVehicleModelsRelationsID As Integer = -1

    Private VehicleDataGridViewInitialized = False

    Private VehicleFieldsDetailsToSelect = ""
    Private VehiclesTablesLinks = ""
    Private VehicleDetailsSelectionFilter = ""
    Private VehicleDetailsSelectionOrder = ""


    Private MeLocationX As Integer
    Private MeLocationY As Integer

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
    Private SavedCallingForm As Form
    Private VehicleDetailsGridViewAlreadyFormated = False
    Private Sub VehicleForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        SavedCallingForm = CallingForm

        VehicleDetailsDataGridView.Enabled = True
        DisableModifyVehicleDetailsMode()
        FillVehiclesDataGridView()

        'SET AND RESET ALL ENTRY PARAMETERS

    End Sub

    Private Sub FillVehiclesDataGridView()

        VehicleFieldsDetailsToSelect = " 
Select 
VehiclesTable.VehicleID_AutoNumber,
VehicleTypeTable.VehicleType_ShortText20,
VehicleModelsTable.VehicleModel_ShortText20,
VehicleTrimTable.VehicleTrimName_ShortText25,
VehiclesTable.YearManufactured_ShortText4,
VehiclesTable.BodyType_ShortText20,
VehiclesTable.EngineSeries_ShortText20,
VehiclesTable.FuelType_ShortText20, 
VehiclesTable.Engine_ShortText20, 
VehiclesTable.VehicleModelsRelationID_LongInteger, 
VehiclesTable.VehicleRepairClassID_LongInteger, 
VehicleModelsRelationsTable.VehicleTypeID_LongInteger, 
VehicleModelsRelationsTable.VehicleModelID_LongInteger, 
VehicleModelsRelationsTable.VehicleTrimID_LongInteger, 
VehicleRepairClassTable.YearManufacturedFrom_ShortText4, 
VehicleRepairClassTable.YearManufacturedTo_ShortText4 
"
        VehiclesTablesLinks =
            " 
FROM((((VehiclesTable LEFT JOIN VehicleModelsRelationsTable ON VehiclesTable.VehicleModelsRelationID_LongInteger = VehicleModelsRelationsTable.[VehicleModelsRelationID_Autonumber]) LEFT JOIN VehicleTypeTable On VehicleModelsRelationsTable.VehicleTypeID_LongInteger = VehicleTypeTable.VehicleTypeID_AutoNumber) LEFT JOIN VehicleTrimTable On VehicleModelsRelationsTable.VehicleTrimID_LongInteger = VehicleTrimTable.VehicleTrimID_Autonumber) LEFT JOIN VehicleModelsTable On VehicleModelsRelationsTable.VehicleModelID_LongInteger = VehicleModelsTable.VehicleModelID_Autonumber) LEFT JOIN VehicleRepairClassTable On VehiclesTable.VehicleRepairClassID_LongInteger = VehicleRepairClassTable.VehicleRepairClassID_AutoNumber 
"


        VehicleDetailsSelectionOrder =
" 
Order by VehicleType_ShortText20 Asc,
VehicleModel_ShortText20 Asc,
VehicleTrimName_ShortText25, 
YearManufactured_ShortText4 
"

        MySelection = VehicleFieldsDetailsToSelect & VehiclesTablesLinks & VehicleDetailsSelectionFilter & VehicleDetailsSelectionOrder


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

        If Not VehicleDetailsGridViewAlreadyFormated Then
            FormatOwnersDataGridView()
        End If

        Dim NoOfHeaderLines = 1
        Dim RecordsDisplyed = RecordCount
        Dim FormLowPointFromGrid = 90
        If RecordCount > 22 Then
            Me.Location = New Point(MeLocationX, 50)
            RecordsDisplyed = 22
        Else
            RecordsDisplyed = RecordCount + 1
        End If
        VehicleDetailsDataGridView.Height = (VehicleDetailsDataGridView.ColumnHeadersHeight * NoOfHeaderLines) + (DataGridViewRowHeight * RecordsDisplyed) + DataGridViewRowHeight
        Me.Height = VehicleDetailsDataGridView.Height + FormLowPointFromGrid
        Me.Top = VehiclesMenuStrip.Top + VehiclesMenuStrip.Height
        Me.Width = VehicleManagementSystemForm.Width - 4
        Me.Left = (VehicleManagementSystemForm.Width - Me.Width) / 2


    End Sub
    Private Sub FormatOwnersDataGridView()
        VehicleDetailsGridViewAlreadyFormated = True
        VehicleDetailsDataGridView.Width = 0
        For i = 0 To VehicleDetailsDataGridView.Columns.GetColumnCount(0) - 1
            VehicleDetailsDataGridView.Columns.Item(i).Visible = False
            Select Case VehicleDetailsDataGridView.Columns.Item(i).Name
                Case "VehicleType_ShortText20"
                    VehicleDetailsDataGridView.Columns.Item(i).HeaderText = "Type"
                    VehicleDetailsDataGridView.Columns.Item(i).Width = 150
                    VehicleDetailsDataGridView.Columns.Item(i).Visible = True
                Case "VehicleModel_ShortText20"
                    VehicleDetailsDataGridView.Columns.Item(i).HeaderText = "Model"
                    VehicleDetailsDataGridView.Columns.Item(i).Width = 150
                    VehicleDetailsDataGridView.Columns.Item(i).Visible = True
                Case "VehicleTrimName_ShortText25"
                    VehicleDetailsDataGridView.Columns.Item(i).HeaderText = "Trim"
                    VehicleDetailsDataGridView.Columns.Item(i).Width = 150
                    VehicleDetailsDataGridView.Columns.Item(i).Visible = True

                Case "YearManufactured_ShortText4"
                    VehicleDetailsDataGridView.Columns.Item(i).HeaderText = "Year"
                    VehicleDetailsDataGridView.Columns.Item(i).Width = 50
                    VehicleDetailsDataGridView.Columns.Item(i).Visible = True

                Case "Engine_ShortText20"
                    VehicleDetailsDataGridView.Columns.Item(i).HeaderText = "Engine"
                    VehicleDetailsDataGridView.Columns.Item(i).Width = 150
                    VehicleDetailsDataGridView.Columns.Item(i).Visible = True

                Case "BodyType_ShortText20"
                    VehicleDetailsDataGridView.Columns.Item(i).HeaderText = "Body Type"
                    VehicleDetailsDataGridView.Columns.Item(i).Width = 150
                    VehicleDetailsDataGridView.Columns.Item(i).Visible = True

                Case "EngineSeries_ShortText20"
                    VehicleDetailsDataGridView.Columns.Item(i).HeaderText = "Engine Series"
                    VehicleDetailsDataGridView.Columns.Item(i).Width = 150
                    VehicleDetailsDataGridView.Columns.Item(i).Visible = True

                Case "FuelType_ShortText20"
                    VehicleDetailsDataGridView.Columns.Item(i).HeaderText = "Fuel Type"
                    VehicleDetailsDataGridView.Columns.Item(i).Width = 150
                    VehicleDetailsDataGridView.Columns.Item(i).Visible = True

                Case "YearManufacturedFrom_ShortText4"
                    VehicleDetailsDataGridView.Columns.Item(i).HeaderText = "From"
                    VehicleDetailsDataGridView.Columns.Item(i).Width = 50
                    VehicleDetailsDataGridView.Columns.Item(i).Visible = True

                Case "YearManufacturedTo_ShortText4"
                    VehicleDetailsDataGridView.Columns.Item(i).HeaderText = "To"
                    VehicleDetailsDataGridView.Columns.Item(i).Width = 50
                    VehicleDetailsDataGridView.Columns.Item(i).Visible = True

            End Select
            If VehicleDetailsDataGridView.Columns.Item(i).Visible = True Then
                VehicleDetailsDataGridView.Width = VehicleDetailsDataGridView.Width + VehicleDetailsDataGridView.Columns.Item(i).Width
            End If
        Next
    End Sub

    Private Sub VehicleDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles VehicleDetailsDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If RecordCount = 0 Then Exit Sub
        CurrentVehicleDetailsRow = e.RowIndex
        If Not VehicleDataGridViewInitialized Then
            VehicleDataGridViewInitialized = True
        End If
        If CurrentVehicleID = VehicleDetailsDataGridView.Item("VehicleID_AutoNumber", CurrentVehicleDetailsRow).Value Then Exit Sub
        CurrentVehicleID = VehicleDetailsDataGridView.Item("VehicleID_AutoNumber", CurrentVehicleDetailsRow).Value
        CurrentVehicleModelID = VehicleDetailsDataGridView.Item("VehicleModelID_LongInteger", CurrentVehicleDetailsRow).Value
        CurrentVehicleTypeID = VehicleDetailsDataGridView.Item("VehicleTypeID_LongInteger", CurrentVehicleDetailsRow).Value
        CurrentVehicleTrimID = VehicleDetailsDataGridView.Item("VehicleTrimID_LongInteger", CurrentVehicleDetailsRow).Value
        CurrentVehicleRepairClassID = Val(IIf(IsDBNull(VehicleDetailsDataGridView.Item("VehicleRepairClassID_LongInteger", CurrentVehicleDetailsRow).Value), "-1", VehicleDetailsDataGridView.Item("VehicleRepairClassID_LongInteger", CurrentVehicleDetailsRow).Value))
        CurrentVehicleModelsRelationsID = Val(IIf(IsDBNull(VehicleDetailsDataGridView.Item("VehicleModelsRelationID_LongInteger", CurrentVehicleDetailsRow).Value), "-1", VehicleDetailsDataGridView.Item("VehicleModelsRelationID_LongInteger", CurrentVehicleDetailsRow).Value))


    End Sub

    Private Sub VehicleDetailsForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        If Me.Enabled = False Then Exit Sub
        CallingForm = SavedCallingForm
        Select Case Tunnel1
            Case "Tunnel2IsVehicleRepairClassID"
                CurrentVehicleRepairClassID = Tunnel2
            Case "Tunnel2IsVehicleModelsRelationID"
                CurrentVehicleModelsRelationsID = Tunnel2
        End Select
    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        PurposeOfVehicleDetailsDetailsGroupBoxEntry = "ADD"
        ' Shows the details editing group box and enables edit to the fields
        ' All DataGridViews are disabled
        ' Searching is disable
        CurrentVehicleID = -1
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
        MySelection = "INSERT INTO VehiclesTable (" &
                                            " VehicleModelsRelationID_LongInteger,  " &
                                            " YearManufactured_ShortText4,  " &
                                            " Engine_ShortText20,  " &
                                            " BodyType_ShortText20,  " &
                                            " EngineSeries_ShortText20,  " &
                                            " FuelType_ShortText20,  " &
                                            " VehicleRepairClassID_LongInteger)  " &
                                             " VALUES (" &
                                               Str(CurrentVehicleModelsRelationsID) & "," &
                                               InQuotes(Trim(RTrim(YearManufacturedTextBox.Text))) & "," &
                                               InQuotes(RTrim(EngineTypeTextBox.Text)) & "," &
                                               InQuotes(RTrim(BodyTypeTextBox.Text)) & "," &
                                               InQuotes(RTrim(Trim(EngineSeriesTextBox.Text))) & "," &
                                               InQuotes(RTrim(Trim(FuelTypeTextBox.Text))) & "," &
                                               Str(CurrentVehicleRepairClassID) & ")"


        If NoRecordFound() Then Dim xxx As Integer = 0 'always IsNot found

        MySelection = "Select * FROM VehiclesTable " &
                              " WHERE VehicleModelsRelationID_LongInteger = " & Str(CurrentVehicleModelsRelationsID) & " AND " &
                              "       YearManufactured_ShortText4 = " & InQuotes(Trim(YearManufacturedTextBox.Text))

        If NoRecordFound() Then
            MsgBox("PROBLEM ...... unseccessful save ")
            Exit Sub
        End If

        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)

        CurrentVehicleID = r("VehicleID_AutoNumber")

    End Sub


    Private Sub SaveChangesToTheVehicle()

        'test existence here

        Select Case PurposeOfVehicleDetailsDetailsGroupBoxEntry
            Case "ADD"

                MySelection = "SELECT * " &
                       " FROM VehiclesTable " &
                       " WHERE VehicleModelsRelationID_LongInteger = " & Str(CurrentVehicleModelsRelationsID) &
                       " AND YearManufactured_ShortText4 = " & InQuotes(Trim(YearManufacturedTextBox.Text))

                If NoRecordFound() Then
                    AddAVehicleRecord()

                Else
                    MsgBox("This record already exists")
                    CurrentVehicleID = -1
                    Exit Sub
                End If

            Case "EDIT"
                Dim VehicleFieldsToUpdate = ""
                Dim VehicleFilter = " WHERE VehicleID_AutoNumber = " & Str(CurrentVehicleID)
                Dim MyNull = Chr(34) & Chr(34)


                VehicleFieldsToUpdate = " UPDATE VehiclesTable SET " &
                                                           " VehicleModelsRelationID_LongInteger = " & Str(CurrentVehicleModelsRelationsID) & ", " &
                                                           " YearManufactured_ShortText4 = " & Trim(RTrim(YearManufacturedFromTextBox.Text)) & ", " &
                                                           " VehicleRepairClassID_LongInteger = " & Str(CurrentVehicleRepairClassID)


                If IsNotEmpty(EngineTypeTextBox.Text) Then
                    VehicleFieldsToUpdate = VehicleFieldsToUpdate & ", Engine_ShortText20  = " & InQuotes(EngineTypeTextBox.Text)
                Else
                    VehicleFieldsToUpdate = VehicleFieldsToUpdate & ", Engine_ShortText20  = " & MyNull
                End If

                If IsNotEmpty(BodyTypeTextBox.Text) Then
                    VehicleFieldsToUpdate = VehicleFieldsToUpdate & ", BodyType_ShortText20 = " & InQuotes(BodyTypeTextBox.Text)
                Else
                    VehicleFieldsToUpdate = VehicleFieldsToUpdate & ", BodyType_ShortText20 = " & MyNull
                End If

                If IsNotEmpty(EngineSeriesTextBox.Text) Then
                    VehicleFieldsToUpdate = VehicleFieldsToUpdate & ", EngineSeries_ShortText20 = " & InQuotes(EngineSeriesTextBox.Text)
                Else
                    VehicleFieldsToUpdate = VehicleFieldsToUpdate & ", EngineSeries_ShortText20 = " & MyNull
                End If

                If IsNotEmpty(FuelTypeTextBox.Text) Then
                    VehicleFieldsToUpdate = VehicleFieldsToUpdate & ", FuelType_ShortText20 = " & InQuotes(FuelTypeTextBox.Text)
                Else
                    VehicleFieldsToUpdate = VehicleFieldsToUpdate & ", FuelType_ShortText20 = " & MyNull
                End If

                MySelection = VehicleFieldsToUpdate & VehicleFilter



        End Select


    End Sub


    ' *****************************************************************************************************************************************************

    Private Sub EnableModifyVehicleDetailsMode()      ' Add Edit Delete are turned off and Cancel ans Save options are made available
        DisableAddEditDeleteVehicleDetailsMenuItems()
        VehicleDetailsDataGridView.Enabled = False
        LoadVehicleDetailsDetailsGroupBox()
    End Sub

    Private Sub DisableModifyVehicleDetailsMode()
        EnableAddEditDeleteVehicleDetailsMenuItems()
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


    Private Sub LoadVehicleDetailsDetailsGroupBox()

        If Me.Width < VehicleDetailsDetailsGroupBox.Width Then                                              ' detailsgroupBox is wider
            Me.Width = VehicleDetailsDetailsGroupBox.Width + 30
        End If
        If Me.Height < (VehicleDetailsDetailsGroupBox.Height + 90 + DataGridViewRowHeight) Then             ' DetailsGroupBox has more height than the gridview normally occurs with less records
            Me.Height = VehicleDetailsDetailsGroupBox.Height + 90 + DataGridViewRowHeight
        End If

        If CurrentVehicleID = -1 Then                                                        ' no record selected
            CurrentVehicleTypeID = -1
            VehicleMakeTextBox.Text = ""
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
            VehicleMakeTextBox.Text = IIf(IsDBNull(VehicleDetailsDataGridView.Item("VehicleType_ShortText20", CurrentVehicleDetailsRow).Value), "", VehicleDetailsDataGridView.Item("VehicleType_ShortText20", CurrentVehicleDetailsRow).Value)
            YearManufacturedTextBox.Text = IIf(IsDBNull(VehicleDetailsDataGridView.Item("YearManufactured_ShortText4", CurrentVehicleDetailsRow).Value), "", VehicleDetailsDataGridView.Item("YearManufactured_ShortText4", CurrentVehicleDetailsRow).Value)
            VehicleModelTextBox.Text = IIf(IsDBNull(VehicleDetailsDataGridView.Item("VehicleModel_ShortText20", CurrentVehicleDetailsRow).Value), "", VehicleDetailsDataGridView.Item("VehicleModel_ShortText20", CurrentVehicleDetailsRow).Value)
            VehicleTrimTextBox.Text = IIf(IsDBNull(VehicleDetailsDataGridView.Item("VehicleTrimName_ShortText25", CurrentVehicleDetailsRow).Value), "", VehicleDetailsDataGridView.Item("VehicleTrimName_ShortText25", CurrentVehicleDetailsRow).Value)
            EngineTypeTextBox.Text = IIf(IsDBNull(VehicleDetailsDataGridView.Item("Engine_ShortText20", CurrentVehicleDetailsRow).Value), "", VehicleDetailsDataGridView.Item("Engine_ShortText20", CurrentVehicleDetailsRow).Value)
            BodyTypeTextBox.Text = IIf(IsDBNull(VehicleDetailsDataGridView.Item("BodyType_ShortText20", CurrentVehicleDetailsRow).Value), "", VehicleDetailsDataGridView.Item("BodyType_ShortText20", CurrentVehicleDetailsRow).Value)
            EngineSeriesTextBox.Text = IIf(IsDBNull(VehicleDetailsDataGridView.Item("EngineSeries_ShortText20", CurrentVehicleDetailsRow).Value), "", VehicleDetailsDataGridView.Item("EngineSeries_ShortText20", CurrentVehicleDetailsRow).Value)
            FuelTypeTextBox.Text = IIf(IsDBNull(VehicleDetailsDataGridView.Item("FuelType_ShortText20", CurrentVehicleDetailsRow).Value), "", VehicleDetailsDataGridView.Item("FuelType_ShortText20", CurrentVehicleDetailsRow).Value)
        End If
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
        ElseIf Not ValidYearEntry(YearManufacturedTextBox.Text) Then
            YearManufacturedTextBox.Select()
            MsgBox("Invalid Year Entry")
            Exit Sub
        ElseIf CurrentVehicleRepairClassID < 1 Then
            ShowVehicleRepairClassForm()
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


        If VehicleDetailsDetailsGroupBox.Visible Then

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
        End If

        DoCommonHouseKeeping(Me, SavedCallingForm)

    End Sub

    Private Sub SelectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectToolStripMenuItem.Click
        Tunnel1 = "Tunnel2IsVehicleID"
        Tunnel2 = CurrentVehicleID
        Tunnel3 =
                            VehicleDetailsDataGridView.Item("YearManufactured_ShortText4", CurrentVehicleDetailsRow).Value & " " &
                            VehicleDetailsDataGridView.Item("VehicleType_ShortText20", CurrentVehicleDetailsRow).Value & " " &
                            VehicleDetailsDataGridView.Item("VehicleModel_ShortText20", CurrentVehicleDetailsRow).Value & " " &
                            VehicleDetailsDataGridView.Item("VehicleTrimName_ShortText25", CurrentVehicleDetailsRow).Value & " " &
                            VehicleDetailsDataGridView.Item("Engine_ShortText20", CurrentVehicleDetailsRow).Value
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub
    Private Sub VehicleDetailsDetailsGroupBox_VisibleChanged(sender As Object, e As EventArgs) Handles VehicleDetailsDetailsGroupBox.VisibleChanged
        If VehicleDetailsDetailsGroupBox.Visible = True Then
            DisAbleVehicleMenus()
        Else
            EnableVehicleMenus()
        End If
    End Sub
    Private Sub DisAbleVehicleMenus()
        AddToolStripMenuItem.Enabled = False
        EditToolStripMenuItem.Enabled = False
        DeleteToolStripMenuItem.Enabled = False
        SelectToolStripMenuItem.Enabled = False
        ViewToolStripMenuItem.Enabled = False
        SaveToolStripMenuItem.Enabled = True
    End Sub
    Private Sub EnableVehicleMenus()
        AddToolStripMenuItem.Enabled = True
        EditToolStripMenuItem.Enabled = True
        DeleteToolStripMenuItem.Enabled = True
        SelectToolStripMenuItem.Enabled = True
        ViewToolStripMenuItem.Enabled = True
        SaveToolStripMenuItem.Enabled = False
    End Sub
    Private Sub VehicleModelTextBox_TextChanged(sender As Object, e As EventArgs) Handles VehicleModelTextBox.Click
        If Not VehicleModelTextBox.Text = "" Then
            If MsgBox("Replace current model ? ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        End If
        ShowCalledForm(Me, VehicleModelsRelationsForm)
    End Sub
    Private Sub ShowVehicleRepairClassForm()
        Tunnel1 = CurrentVehicleModelsRelationsID
        ShowCalledForm(Me, VehicleRepairClassForm)
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
        FillVehiclesDataGridView()
    End Sub

End Class