Public Class VehicleRepairClassForm
    Private CurrentVehicleModelsRelationsID As Integer = -1
    Private CurrentVehicleRepairClassRow As Integer = -1

    Private PurposeOfVehicleRepairClassDetailsGroupBoxEntry = ""
    Private CodeRequested = ""

    Private CurrentVehicleTypeID As Integer = -1
    Private CurrentVehicleModelID As Integer = -1

    Private VehicleRepairClassDataGridViewInitialized = False

    Private VehicleRepairClassFieldsToReplace = ""
    Private VehicleRepairClassFieldsValues = ""

    Private VehicleRepairClassFieldsToSelect = ""
    Private VehicleRepairClassTablesLinks = ""
    Private VehicleRepairClassSelectionFilter = ""
    Private FindModelKey As String = ""
    Private FindTypeKey As String = ""
    Private VehicleTypeSelectionFilter = ""
    Private VehicleModelSelectionFilter = ""
    Private VehicleRepairClassSelectionFilterSaved = ""

    Private VehicleRepairClassSelectionOrder = ""
    Private LastActionRequested As String = ""
    Private VehicleRepairClassRecordCount As Integer
    Private MeLocationX As Integer
    Private MeLocationY As Integer

    Private SavedMeWidth = 0
    Private SavedYearManufacturedFrom = ""
    Private SavedYearManufacturedTo = ""

    Private SavedCallingForm As Form


    Private Sub VehicleRepairClassForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        SavedCallingForm = CallingForm
        MeLocationX = Me.Location.X

        CurrentVehicleModelsRelationsID = Tunnel1
        VehicleRepairClassSelectionFilter = "  WHERE VehicleModelsRelationID_LongInteger = " & Str(CurrentVehicleModelsRelationsID)

        FillVehicleRepairClassDataGridView()
        SetupVehicleRepairClassDataGridView()

        'SET AND RESET ALL ENTRY PARAMETERS

    End Sub
    Private Sub FillVehicleRepairClassDataGridView()

        VehicleRepairClassFieldsToSelect = "SELECT VehicleTypeTable.VehicleType_ShortText20, " &
                                           " VehicleModelsTable.VehicleModel_ShortText20, " &
                                           " VehicleRepairClassTable.YearManufacturedFrom_ShortText4, " &
                                           " VehicleRepairClassTable.YearManufacturedTo_ShortText4, " &
                                           " VehicleModelsRelationsTable.VehicleModelID_LongInteger, " &
                                           " VehicleRepairClassTable.VehicleModelsRelationID_LongInteger, " &
                                           " VehicleRepairClassTable.VehicleRepairClassID_AutoNumber "

        VehicleRepairClassTablesLinks = " FROM VehicleRepairClassTable " &
                                               " LEFT JOIN ((VehicleModelsRelationsTable" &
                                               " LEFT JOIN VehicleTypeTable ON VehicleModelsRelationsTable.VehicleTypeID_LongInteger = VehicleTypeTable.VehicleTypeID_AutoNumber)" &
                                               " LEFT JOIN VehicleModelsTable ON VehicleModelsRelationsTable.[VehicleModelID_LongInteger] = VehicleModelsTable.VehicleModelID_Autonumber)" &
                                                                            " ON VehicleRepairClassTable.[VehicleModelsRelationID_LongInteger] = VehicleModelsRelationsTable.VehicleModelsRelationID_Autonumber "

        VehicleRepairClassSelectionOrder = " Order By VehicleType_ShortText20, VehicleModel_ShortText20, YearManufacturedFrom_ShortText4 "

        MySelection = VehicleRepairClassFieldsToSelect & VehicleRepairClassTablesLinks & VehicleRepairClassSelectionFilter '& VehicleRepairClassSelectionOrder 

        JustExecuteMySelection()
        VehicleRepairClassRecordCount = RecordCount

        VehicleRepairClassDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        Dim NoOfHeaderLines = 1

        Dim RecordsDisplyed = RecordCount
        Dim FormLowPointFromGrid = 90
        If RecordCount > 25 Then
            Me.Location = New Point(MeLocationX, 50)
            RecordsDisplyed = 25
        Else
            RecordsDisplyed = RecordCount + 1
        End If
        VehicleRepairClassDataGridView.Height = (VehicleRepairClassDataGridView.ColumnHeadersHeight * NoOfHeaderLines) + (DataGridViewRowHeight * RecordsDisplyed) + DataGridViewRowHeight
        Me.Height = VehicleRepairClassDataGridView.Height + FormLowPointFromGrid

    End Sub
    Private Sub SetupVehicleRepairClassDataGridView()

        VehicleRepairClassDataGridView.Columns.Item("VehicleRepairClassID_AutoNumber").Visible = False
        VehicleRepairClassDataGridView.Columns.Item("VehicleModelsRelationID_LongInteger").Visible = False
        VehicleRepairClassDataGridView.Columns.Item("VehicleModelID_LongInteger").Visible = False

        VehicleRepairClassDataGridView.Columns.Item("VehicleType_ShortText20").HeaderText = "Make"
        VehicleRepairClassDataGridView.Columns.Item("VehicleType_ShortText20").Width = 250

        VehicleRepairClassDataGridView.Columns.Item("VehicleModel_ShortText20").HeaderText = "Model"
        VehicleRepairClassDataGridView.Columns.Item("VehicleModel_ShortText20").Width = 250

        VehicleRepairClassDataGridView.Columns.Item("YearManufacturedFrom_ShortText4").HeaderText = "Years From"
        VehicleRepairClassDataGridView.Columns.Item("YearManufacturedFrom_ShortText4").Width = 100

        VehicleRepairClassDataGridView.Columns.Item("YearManufacturedTo_ShortText4").HeaderText = "To"
        VehicleRepairClassDataGridView.Columns.Item("YearManufacturedTo_ShortText4").Width = 100

        VehicleRepairClassDataGridView.Width = VehicleRepairClassDataGridView.Columns.Item("VehicleType_ShortText20").Width +
                                         VehicleRepairClassDataGridView.Columns.Item("VehicleModel_ShortText20").Width +
                                         VehicleRepairClassDataGridView.Columns.Item("YearManufacturedFrom_ShortText4").Width +
                                         VehicleRepairClassDataGridView.Columns.Item("YearManufacturedTo_ShortText4").Width + 50

        Me.Width = VehicleRepairClassDataGridView.Width + 10

    End Sub

    Private Sub VehicleModelDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles VehicleRepairClassDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If RecordCount = 0 Then Exit Sub
        CurrentVehicleRepairClassRow = e.RowIndex
        If Not VehicleRepairClassDataGridViewInitialized Then
            VehicleRepairClassDataGridViewInitialized = True
        End If
        If CurrentVehicleRepairClassID = VehicleRepairClassDataGridView.Item("VehicleRepairClassID_AutoNumber", CurrentVehicleRepairClassRow).Value Then Exit Sub
        CurrentVehicleRepairClassID = VehicleRepairClassDataGridView.Item("VehicleRepairClassID_AutoNumber", CurrentVehicleRepairClassRow).Value
    End Sub


    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click

        PurposeOfVehicleRepairClassDetailsGroupBoxEntry = "ADD"
        ' Shows the details editing group box and enables edit to the fields
        ' All DataGridViews are disabled
        ' Searching is disable
        CurrentVehicleRepairClassID = -1
        VehicleRepairClassDetailsGroupBox.Text = "Add a new VehicleRepairClass"
        EnableModifyVehicleRepairClassMode()          '' Add Edit Delete are turned off and Cancel ans Save options are made available


    End Sub

    Private Sub EnableModifyVehicleRepairClassMode()      ' Add Edit Delete are turned off and Cancel ans Save options are made available
        DisableAddEditDeleteVehicleRepairClassMenuItems()
        VehicleRepairClassDataGridView.Enabled = False
        ShowVehicleRepairClassDetailsGroupBox()
    End Sub

    Private Sub DisableModifyMasterCodeMode()
        EnableAddEditDeleteVehicleRepairClassMenuItems()
        Me.Width = SavedMeWidth
        VehicleRepairClassDetailsGroupBox.Visible = False
        VehicleRepairClassDataGridView.Enabled = True
    End Sub


    Private Sub EnableAddEditDeleteVehicleRepairClassMenuItems()
        SelectToolStripMenuItem.Visible = True
        SaveToolStripMenuItem.Visible = False
        AddToolStripMenuItem.Visible = True
        EditToolStripMenuItem.Visible = True
        ViewToolStripMenuItem.Visible = True
        DeleteToolStripMenuItem.Visible = True
        SearchVehicleTypeTextBox.Visible = True
        SearchVehicleModelTextBox.Visible = True
    End Sub
    Private Sub DisableAddEditDeleteVehicleRepairClassMenuItems()
        SelectToolStripMenuItem.Visible = False
        SaveToolStripMenuItem.Visible = True
        AddToolStripMenuItem.Visible = False
        EditToolStripMenuItem.Visible = False
        ViewToolStripMenuItem.Visible = False
        SearchVehicleTypeTextBox.Visible = False
        SearchVehicleModelTextBox.Visible = False
        DeleteToolStripMenuItem.Visible = False
    End Sub


    Private Sub ShowVehicleRepairClassDetailsGroupBox()

        If Me.Width < VehicleRepairClassDetailsGroupBox.Width Then                                              ' detailsgroupBox is wider
            Me.Width = VehicleRepairClassDetailsGroupBox.Width + 30
        End If
        If Me.Height < (VehicleRepairClassDetailsGroupBox.Height + 90 + DataGridViewRowHeight) Then             ' DetailsGroupBox has more height than the gridview normally occurs with less records
            Me.Height = VehicleRepairClassDetailsGroupBox.Height + 90 + DataGridViewRowHeight
        End If

        VehicleRepairClassDetailsGroupBox.Visible = True
        If Not VehicleRepairClassDetailsGroupBox.Text = "" Then                                                  ' set by ViewToolStripMenuItem.Click in order to allow change of record in the Datagridview which
            ' enables user to view details of other records slected in the DataGridView
            VehicleRepairClassDetailsGroupBox.Text = ""

            VehicleRepairClassDataGridView.Enabled = False
        End If


        If CurrentVehicleRepairClassID = -1 Then                                                        ' no record selected
            YearManufacturedFromTextBox.Text = VehiclesForm.YearManufacturedTextBox.Text
            YearManufacturedToTextBox.Text = VehiclesForm.YearManufacturedTextBox.Text
        Else                                                                                    ' record is selected to show
            YearManufacturedFromTextBox.Text = IIf(IsDBNull(VehicleRepairClassDataGridView.Item("YearManufacturedFrom_ShortText4", CurrentVehicleRepairClassRow).Value), "", VehicleRepairClassDataGridView.Item("YearManufacturedFrom_ShortText4", CurrentVehicleRepairClassRow).Value)
            YearManufacturedToTextBox.Text = IIf(IsDBNull(VehicleRepairClassDataGridView.Item("YearManufacturedTo_ShortText4", CurrentVehicleRepairClassRow).Value), "", VehicleRepairClassDataGridView.Item("YearManufacturedTo_ShortText4", CurrentVehicleRepairClassRow).Value)
        End If
        SavedYearManufacturedFrom = YearManufacturedFromTextBox.Text
        SavedYearManufacturedTo = YearManufacturedToTextBox.Text

    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click

        PurposeOfVehicleRepairClassDetailsGroupBoxEntry = "EDIT"

        'Check if there are links to the Table
        'if there exists then ask if real change action

        '       MySelection = "Select * from MyStandardTable " &
        '                     "Where MyStandardID_AutoNumber = " & Str(CurrentMyStandardID)
        '       If RecordIsFound() Then

        ' at this point EDIT FEATURE IS JUST ALLOWED

        If Not MsgBox("This VehicleRepairClass is currently LINKED to other Files, do you really want to change informations for this MyStandard ?", vbYesNo) = vbYes Then
            Exit Sub
        End If
        '       End If

        'setting the form enabled status will trigger MyStandardForm_EnabledChanged
        VehicleRepairClassDetailsGroupBox.Text = "EDIT VehicleRepairClass"
        EnableModifyVehicleRepairClassMode()

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim tempMake = " none "
        Dim TempModel = " none "
        Dim TempTrim = " none "
        If Not IsDBNull(VehicleRepairClassDataGridView.Item("VehicleType_ShortText20", CurrentVehicleRepairClassRow).Value) Then
            tempMake = VehicleRepairClassDataGridView.Item("VehicleType_ShortText20", CurrentVehicleRepairClassRow).Value
        End If
        If Not IsDBNull(VehicleRepairClassDataGridView.Item("VehicleModel_ShortText20", CurrentVehicleRepairClassRow).Value) Then
            TempModel = VehicleRepairClassDataGridView.Item("VehicleModel_ShortText20", CurrentVehicleRepairClassRow).Value
        End If
        If Not IsDBNull(VehicleRepairClassDataGridView.Item("VehicleTrimName_ShortText25", CurrentVehicleRepairClassRow).Value) Then
            TempTrim = VehicleRepairClassDataGridView.Item("VehicleTrimName_ShortText25", CurrentVehicleRepairClassRow).Value

        End If
        Dim AnswerToQuestion = MsgBox("Continue Deletion of Make: " & tempMake & "  Model: " & TempModel & "  Trim: " & TempTrim & " ? ", vbYesNo)

        If Not AnswerToQuestion = vbYes Then
            Exit Sub
        End If

        MySelection = "DELETE from VehicleModelsRelationsTable WHERE VehicleModelID_Autonumber = " & Str(CurrentVehicleRepairClassID)
        JustExecuteMySelection()
        FillVehicleRepairClassDataGridView()
    End Sub
    Private Sub FillVehicleRepairClassDetailsForm()
        If Not IsDBNull(VehicleRepairClassDataGridView.Item("YearManufacturedFrom", CurrentVehicleRepairClassRow).Value) Then
            VehicleModelsRelationsForm.VehicleMakeTextBox.Text = VehicleRepairClassDataGridView.Item("YearManufacturedFrom", CurrentVehicleRepairClassRow).Value
        End If
        If Not IsDBNull(VehicleRepairClassDataGridView.Item("YearManufacturedTo", CurrentVehicleRepairClassRow).Value) Then
            VehicleModelsRelationsForm.VehicleModelTextBox.Text = VehicleRepairClassDataGridView.Item("YearManufacturedTo", CurrentVehicleRepairClassRow).Value
        End If
    End Sub
    Private Sub SelectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectToolStripMenuItem.Click
        VehiclesForm.YearManufacturedFromTextBox.Text = VehicleRepairClassDataGridView.Item("YearManufacturedFrom_ShortText4", CurrentVehicleRepairClassRow).Value
        VehiclesForm.YearManufacturedToTextBox.Text = VehicleRepairClassDataGridView.Item("YearManufacturedTo_ShortText4", CurrentVehicleRepairClassRow).Value

        Tunnel1 = "Tunnel2IsVehicleRepairClassID"
        Tunnel2 = CurrentVehicleRepairClassID
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub
    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        Select Case VehicleRepairClassDetailsGroupBox.Visible
            Case True
                Dim FieldChangeOccured = False

                If SavedYearManufacturedFrom <> YearManufacturedFromTextBox.Text Then
                    FieldChangeOccured = True
                End If
                If SavedYearManufacturedFrom <> YearManufacturedToTextBox.Text Then
                    FieldChangeOccured = True
                End If
                If FieldChangeOccured Then
                    If Not MsgBox("Do you want to discard changes ?", vbYesNo) = vbYes Then
                        ' then disregard cancell selection
                        Exit Sub
                    End If
                End If
                VehicleRepairClassDataGridView.Enabled = True
                DisableModifyMasterCodeMode()
            Case Else
                DoCommonHouseKeeping(Me, SavedCallingForm)
        End Select
    End Sub
    Private Sub SearchVehicleTypeTextBox_Click(sender As Object, e As EventArgs) Handles SearchVehicleTypeTextBox.Click
        If SearchVehicleTypeTextBox.Text = "Search" Or SearchVehicleTypeTextBox.Text = "New Type Here" Then
            SearchVehicleTypeTextBox.Text = ""
        End If
    End Sub
    Private Sub SearchVehicleTypeTextBox_TextChanged(sender As Object, e As EventArgs) Handles SearchVehicleTypeTextBox.TextChanged
        If Not VehicleRepairClassDataGridViewInitialized Then Exit Sub
        FindTypeKey = Trim(SearchVehicleTypeTextBox.Text)
        If FindTypeKey = "" Or FindTypeKey = "New Type Here" Or FindTypeKey = "Search" Then
            VehicleRepairClassSelectionFilter = ""
            VehicleTypeSelectionFilter = ""
        Else
            If VehicleRepairClassSelectionFilterSaved = "" Then
                VehicleTypeSelectionFilter = " VehicleType_ShortText20 LIKE @FindTypeKey "
            Else
                VehicleRepairClassSelectionFilter = VehicleRepairClassSelectionFilterSaved & " AND VehicleType_ShortText20 LIKE @FindTypeKey "
            End If
            SetupSelection()
        End If
        FillVehicleRepairClassDataGridView()

    End Sub
    Private Sub SearchVehicleModelTextBox_Click(sender As Object, e As EventArgs) Handles SearchVehicleModelTextBox.Click
        If SearchVehicleModelTextBox.Text = "Search" Or SearchVehicleModelTextBox.Text = "New Model Here" Then
            SearchVehicleModelTextBox.Text = ""
        End If
    End Sub
    Private Sub SearchVehicleModelTextBox_TextChanged(sender As Object, e As EventArgs) Handles SearchVehicleModelTextBox.TextChanged
        If Not VehicleRepairClassDataGridViewInitialized Then Exit Sub
        FindModelKey = Trim(SearchVehicleModelTextBox.Text)
        Dim FindTypeKey As String = Trim(SearchVehicleTypeTextBox.Text)
        If FindModelKey = "" Or FindModelKey = "New Model Here" Or FindModelKey = "Search" Then
            VehicleRepairClassSelectionFilter = VehicleRepairClassSelectionFilterSaved
        Else
            VehicleModelSelectionFilter = " VehicleModel_ShortText20 LIKE @FindModelKey "
            SetupSelection()
        End If
        FillVehicleRepairClassDataGridView()

    End Sub
    Private Sub SetupSelection()
        VehicleRepairClassSelectionFilter = ""
        Dim AndText As String = ""
        Dim QueryCount = 0
        If Not VehicleTypeSelectionFilter = "" Then
            QueryCount = 1
            RecordFinderDbControls.AddParam("@FindTypeKey", "%" & FindTypeKey & "%")
        End If

        If Not VehicleModelSelectionFilter = "" Then
            QueryCount = QueryCount + 1
            RecordFinderDbControls.AddParam("@FindModelKey", "%" & FindModelKey & "%")
        End If
        If QueryCount > 0 Then
            Select Case QueryCount
                Case 1

                Case 2
                    AndText = " AND "

            End Select

        End If
        VehicleRepairClassSelectionFilter = "WHERE " & VehicleTypeSelectionFilter & AndText & VehicleModelSelectionFilter



    End Sub

    Private Sub EmployeeDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmployeeDetailsToolStripMenuItem.Click
        PurposeOfVehicleRepairClassDetailsGroupBoxEntry = "VIEW"
        VehicleRepairClassDetailsGroupBox.Text = ""
        VehicleRepairClassDetailsGroupBox.Enabled = False
        EnableModifyVehicleRepairClassMode()
        SaveToolStripMenuItem.Visible = False

    End Sub

    Private Sub YearManufacturedFromTextBox_TextChanged(sender As Object, e As EventArgs) Handles YearManufacturedFromTextBox.TextChanged
        If Not YearManufacturedFromTextBox.Text = "year should not be earlier than Vehicle year manufactured" Then
            If Not YearManufacturedFromTextBox.Text = "" Then
                If YearManufacturedFromTextBox.Text > VehiclesForm.YearManufacturedTextBox.Text Then
                    YearManufacturedFromTextBox.Text = "year should not be earlier than Vehicle year manufactured"
                End If
            End If

        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        If VehicleRepairClassFieldsEntriesAreNotValidAndComplete() Then
            Exit Sub
        End If
        SaveVehicleRepairClassFieldContents()
    End Sub
    Private Function VehicleRepairClassFieldsEntriesAreNotValidAndComplete()
        If Trim(YearManufacturedFromTextBox.Text) = "" Then
            YearManufacturedFromTextBox.Select()
            Return True
        End If
        If Trim(YearManufacturedToTextBox.Text) = "" Then
            YearManufacturedToTextBox.Select()
            Return True
        End If
        Return False
    End Function

    Private Sub SaveVehicleRepairClassFieldContents()
        Select Case PurposeOfVehicleRepairClassDetailsGroupBoxEntry
            Case "ADD"
                If ThisVehicleRepairClassAlreadyExist() Then
                    MsgBox("This record already exists")
                    Exit Sub
                End If

                Dim VehicleRepairClass = Trim(VehiclesForm.VehicleMakeTextBox.Text) & " " &
                                         Trim(VehiclesForm.VehicleModelTextBox.Text) & " From " &
                                         Trim(YearManufacturedFromTextBox.Text) & " To " &
                                         Trim(YearManufacturedToTextBox.Text)

                If Not MsgBox(" Confirm adding new Repair Class Mode for " & VehicleRepairClass, vbYesNo) = vbYes Then
                    Exit Sub
                End If

                If Not SuccessfullyAddingThisVehicleRepairClassRecord() Then
                    MsgBox("Vehicle CLASS already exists ")
                    Exit Sub
                End If
            Case "EDIT"
                Dim VehicleRepairClass = Trim(VehiclesForm.VehicleMakeTextBox.Text) & " " &
                                         Trim(VehiclesForm.VehicleModelTextBox.Text) & " From " &
                                         Trim(YearManufacturedFromTextBox.Text) & " To " &
                                         Trim(YearManufacturedToTextBox.Text)

                If Not MsgBox(" Confirm  changes to this Vehicle Repair Class Mode for " & VehicleRepairClass, vbYesNo) = vbYes Then
                    Exit Sub
                End If

                Dim VehicleRepairClassFilter = " WHERE VehicleRepairClassID_AutoNumber = " & Str(CurrentVehicleRepairClassID)
                Dim MyNull = Chr(34) & Chr(34)


                VehicleRepairClassFieldsToReplace = " UPDATE VehicleRepairClassTable  SET " &
                                                                               " YearManufacturedFrom_ShortText4  = " & Chr(34) & Trim(YearManufacturedFromTextBox.Text) & Chr(34) & ", " &
                                                                               " YearManufacturedTo_ShortText4  = " & Chr(34) & Trim(YearManufacturedToTextBox.Text) & Chr(34)

                MySelection = VehicleRepairClassFieldsToReplace & VehicleRepairClassFilter
                If NoRecordFound() Then Dim dummy = 1
            Case Else
                Dim XXXX = 1
        End Select
        DisableModifyMasterCodeMode()
        FillVehicleRepairClassDataGridView()
    End Sub
    Private Function ThisVehicleRepairClassAlreadyExist()
        VehicleRepairClassFieldsToSelect = " Select * FROM  VehicleRepairClassTable "

        Dim YearRangeFilter = " And trim(YearManufacturedFrom_ShortText4) = " & Chr(34) & Trim(YearManufacturedFromTextBox.Text) & Chr(34) &
                        " And trim(YearManufacturedTo_ShortText4) = " & Chr(34) & Trim(YearManufacturedToTextBox.Text) & Chr(34)

        Dim CombinedFilter = VehicleRepairClassSelectionFilter & YearRangeFilter
        MySelection = VehicleRepairClassFieldsToSelect & CombinedFilter

        If ThereIsARecord() Then
            Return True
        End If
        Return False
    End Function
    Private Function SuccessfullyAddingThisVehicleRepairClassRecord()
        VehicleRepairClassFieldsToSelect = " Select * FROM  VehicleRepairClassTable "

        Dim VehicleRepairClassTablesFilter = " WHERE  YearManufacturedFrom_ShortText4 = " & Chr(34) & Trim(YearManufacturedFromTextBox.Text) & Chr(34) &
                                                " AND YearManufacturedTo_ShortText4 = " & Chr(34) & Trim(YearManufacturedToTextBox.Text) & Chr(34) &
                                                " AND VehicleModelsRelationID_LongInteger = " & Str(CurrentVehicleModelsRelationsID)

        MySelection = VehicleRepairClassFieldsToSelect & VehicleRepairClassTablesFilter

        If Not NoRecordFound() Then
            Return False
        End If

        If ThisVehicleRepairClassAlreadyExist() Then
            r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
            CurrentVehicleRepairClassID = r("VehicleRepairClassID_AutoNumber")
            MsgBox("This Class already exist ")
        End If
        ' EXECUTE INSERT COMMAND

        VehicleRepairClassFieldsToReplace = "" &
            "YearManufacturedFrom_ShortText4, " &
            "YearManufacturedTo_ShortText4, " &
            "VehicleModelsRelationID_LongInteger "

        VehicleRepairClassFieldsValues = "" &
            Chr(34) & Trim(YearManufacturedFromTextBox.Text) & Chr(34) & ", " &
            Chr(34) & Trim(YearManufacturedToTextBox.Text) & Chr(34) & ", " &
            Str(CurrentVehicleModelsRelationsID)

        MySelection = "INSERT INTO VehicleRepairClassTable  (" & VehicleRepairClassFieldsToReplace & ") VALUES (" & VehicleRepairClassFieldsValues & ")"

        JustExecuteMySelection()


        Return True
    End Function

End Class