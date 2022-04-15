Public Class VehicleModelsRelationsForm
    Private CurrentVehicleModelsRelationID As Integer = -1
    Private CurrentVehicleModelRelationsRow As Integer = -1

    Public CurrentVehicleMakeID As Integer
    Public CurrentVehicleModelID As Integer
    Public CurrentVehicleTrimID As Integer

    Private VehicleModelDataGridViewInitialized = False

    Private VehicleModelFieldsToSelect = ""
    Private VehicleModelsRelationsTablesLinks = ""
    Private VehicleModelSelectionFilter = ""
    Private VehicleModelSelectionFilterSaved = ""
    Private VehicleModelsRelationsDataGridViewAlreadyFormatted = False

    Private VehicleModelSelectionOrder = ""
    Private ModelsRecordCount As Integer
    Private MeLocationX As Integer

    Private PurposeOfEntry As String
    Private SavedCallingForm As Form


    Private Sub VehicleModelsRelationsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        SavedCallingForm = CallingForm
        ' calling form VehicleDetailsForm requests for CurrentVehicleModelsRelationID

        MeLocationX = Me.Location.X


        VehicleModelSelectionFilter = ""

        FillVehicleModelsRelationsDataGridView()


        'SET AND RESET ALL ENTRY PARAMETERS

    End Sub
    Private Sub FillVehicleModelsRelationsDataGridView()
        VehicleModelFieldsToSelect = "Select VehicleModelsRelationID_Autonumber, " &
                                            " VehicleTypeTable.VehicleType_ShortText20, " &
                                            " VehicleModelsTable.VehicleModel_ShortText20, " &
                                            " VehicleTrimTable.VehicleTrimName_ShortText25, " &
                                            " VehicleModelsRelationsTable.VehicleModelID_LongInteger, " &
                                            " VehicleModelsRelationsTable.VehicleTypeID_LongInteger, " &
                                            " VehicleModelsRelationsTable.VehicleTrimID_LongInteger "
        VehicleModelsRelationsTablesLinks = " FROM((VehicleModelsRelationsTable LEFT JOIN VehicleModelsTable ON VehicleModelsRelationsTable.VehicleModelID_LongInteger = VehicleModelsTable.VehicleModelID_Autonumber) LEFT JOIN VehicleTypeTable On VehicleModelsRelationsTable.VehicleTypeID_LongInteger = VehicleTypeTable.VehicleTypeID_AutoNumber) LEFT JOIN VehicleTrimTable On VehicleModelsRelationsTable.VehicleTrimID_LongInteger = VehicleTrimTable.VehicleTrimID_Autonumber "


        VehicleModelsRelationsTablesLinks = " FROM((VehicleModelsRelationsTable LEFT JOIN VehicleModelsTable ON VehicleModelsRelationsTable.VehicleModelID_LongInteger = VehicleModelsTable.VehicleModelID_Autonumber)" &
                                                                              " LEFT JOIN VehicleTypeTable On VehicleModelsRelationsTable.VehicleTypeID_LongInteger = VehicleTypeTable.VehicleTypeID_AutoNumber) " &
                                                                              " LEFT JOIN VehicleTrimTable On VehicleModelsRelationsTable.VehicleTrimID_LongInteger = VehicleTrimTable.VehicleTrimID_Autonumber "


        VehicleModelSelectionOrder = " ORDER BY VehicleType_ShortText20, VehicleModel_ShortText20, VehicleTrimName_ShortText25 "

        MySelection = VehicleModelFieldsToSelect & VehicleModelsRelationsTablesLinks & VehicleModelSelectionFilter & VehicleModelSelectionOrder

        JustExecuteMySelection()
        ModelsRecordCount = RecordCount

        VehicleModelsRelationsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable


        Dim NoOfHeaderLines = 1
        Dim RecordsDisplyed = RecordCount
        Dim FormLowPointFromGrid = 90
        If RecordCount > 25 Then
            Me.Location = New Point(MeLocationX, 50)
            RecordsDisplyed = 25
        Else
            RecordsDisplyed = RecordCount + 1
        End If
        VehicleModelsRelationsDataGridView.Height = (VehicleModelsRelationsDataGridView.ColumnHeadersHeight * NoOfHeaderLines) + (DataGridViewRowHeight * RecordsDisplyed) + DataGridViewRowHeight
        Me.Height = VehicleModelsRelationsDataGridView.Height + FormLowPointFromGrid
        If Not VehicleModelsRelationsDataGridViewAlreadyFormatted Then
            FormatVehicleModelDataGridView()
        End If
    End Sub
    Private Sub FormatVehicleModelDataGridView()
        VehicleModelsRelationsDataGridViewAlreadyFormatted = True
        VehicleModelsRelationsDataGridView.Columns.Item("VehicleModelsRelationID_Autonumber").Visible = False
        VehicleModelsRelationsDataGridView.Columns.Item("VehicleModelID_LongInteger").Visible = False
        VehicleModelsRelationsDataGridView.Columns.Item("VehicleTypeID_LongInteger").Visible = False
        VehicleModelsRelationsDataGridView.Columns.Item("VehicleTrimID_LongInteger").Visible = False

        VehicleModelsRelationsDataGridView.Columns.Item("VehicleType_ShortText20").HeaderText = "Make"
        VehicleModelsRelationsDataGridView.Columns.Item("VehicleType_ShortText20").Width = 250

        VehicleModelsRelationsDataGridView.Columns.Item("VehicleModel_ShortText20").HeaderText = "Model"
        VehicleModelsRelationsDataGridView.Columns.Item("VehicleModel_ShortText20").Width = 250

        VehicleModelsRelationsDataGridView.Columns.Item("VehicleTrimName_ShortText25").HeaderText = "Trim"
        VehicleModelsRelationsDataGridView.Columns.Item("VehicleTrimName_ShortText25").Width = 250

        VehicleModelsRelationsDataGridView.Width = VehicleModelsRelationsDataGridView.Columns.Item("VehicleType_ShortText20").Width +
                                         VehicleModelsRelationsDataGridView.Columns.Item("VehicleModel_ShortText20").Width +
                                         VehicleModelsRelationsDataGridView.Columns.Item("VehicleTrimName_ShortText25").Width + 50

        Me.Width = VehicleModelsRelationsDataGridView.Width + 10

    End Sub
    '   VehicleModelDataGridView HANDLING

    Private Sub VehicleModelsRelationsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles VehicleModelsRelationsDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If RecordCount = 0 Then Exit Sub
        CurrentVehicleModelRelationsRow = e.RowIndex
        If Not VehicleModelDataGridViewInitialized Then VehicleModelDataGridViewInitialized = True
        If CurrentVehicleModelsRelationID = VehicleModelsRelationsDataGridView.Item("VehicleModelsRelationID_Autonumber", CurrentVehicleModelRelationsRow).Value Then Exit Sub
        CurrentVehicleModelsRelationID = VehicleModelsRelationsDataGridView.Item("VehicleModelsRelationID_Autonumber", CurrentVehicleModelRelationsRow).Value

        CurrentVehicleModelID = VehicleModelsRelationsDataGridView.Item("VehicleModelID_LongInteger", CurrentVehicleModelRelationsRow).Value
        CurrentVehicleMakeID = VehicleModelsRelationsDataGridView.Item("VehicleTypeID_LongInteger", CurrentVehicleModelRelationsRow).Value
        CurrentVehicleTrimID = VehicleModelsRelationsDataGridView.Item("VehicleTrimID_LongInteger", CurrentVehicleModelRelationsRow).Value

        VehicleMakeTextBox.Text = NotNull(VehicleModelsRelationsDataGridView.Item("VehicleType_ShortText20", CurrentVehicleModelRelationsRow).Value)
        VehicleModelTextBox.Text = NotNull(VehicleModelsRelationsDataGridView.Item("VehicleModel_ShortText20", CurrentVehicleModelRelationsRow).Value)
        VehicleTrimTextBox.Text = NotNull(VehicleModelsRelationsDataGridView.Item("VehicleTrimName_ShortText25", CurrentVehicleModelRelationsRow).Value)
    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        PurposeOfEntry = "ADD"
        VehicleMakeTextBox.Text = ""
        VehicleModelTextBox.Text = ""
        VehicleTrimTextBox.Text = ""
        ModelsRelationsDetailsGroupBox.Visible = True
    End Sub
    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        PurposeOfEntry = "EDIT"
        ModelsRelationsDetailsGroupBox.Visible = True
    End Sub
    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click

        MsgBox("VALIDATE THIS FIRST")

        MySelection = "DELETE from VehicleModelsRelationsTable WHERE VehicleModelID_Autonumber = " & Str(CurrentVehicleModelsRelationID)
        JustExecuteMySelection()
        FillVehicleModelsRelationsDataGridView()
    End Sub
    Private Sub SelectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectToolStripMenuItem.Click
        Tunnel1 = "Tunnel2IsVehicleModelsRelationID"
        Tunnel2 = CurrentVehicleModelsRelationID
        If CallingForm.Name = "VehiclesForm" Then
            VehiclesForm.VehicleMakeTextBox.Text = VehicleModelsRelationsDataGridView.Item("VehicleType_ShortText20", CurrentVehicleModelRelationsRow).Value
            VehiclesForm.VehicleModelTextBox.Text = VehicleModelsRelationsDataGridView.Item("VehicleModel_ShortText20", CurrentVehicleModelRelationsRow).Value
            VehiclesForm.VehicleTrimTextBox.Text = NotNull(VehicleModelsRelationsDataGridView.Item("VehicleTrimName_ShortText25", CurrentVehicleModelRelationsRow).Value)
        End If
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub
    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub
    Private Sub ToolStripTextBoxSearch_Click(sender As Object, e As EventArgs) Handles SearchVehicleMakeTextBox.Click
        If SearchVehicleMakeTextBox.Text = "Search" Or SearchVehicleMakeTextBox.Text = "New Model Here" Then
            SearchVehicleMakeTextBox.Text = ""
        End If
    End Sub

    Private Sub SearchVehicleModelTextBox_TextChanged(sender As Object, e As EventArgs) Handles SearchVehicleMakeTextBox.TextChanged
        If Not VehicleModelDataGridViewInitialized Then Exit Sub
        Dim FindKey As String = Trim(SearchVehicleMakeTextBox.Text)
        If FindKey = "" Or FindKey = "Type New Trim Here" Or FindKey = "Search" Then
            VehicleModelSelectionFilter = VehicleModelSelectionFilterSaved
        Else
            RecordFinderDbControls.AddParam("@FindKey", "%" & FindKey & "%")
            If VehicleModelSelectionFilterSaved = "" Then
                VehicleModelSelectionFilter = " WHERE VehicleModel_ShortText20 LIKE @FindKey "
            Else
                VehicleModelSelectionFilter = VehicleModelSelectionFilterSaved & " AND VehicleModel_ShortText20 LIKE @FindKey "
            End If
        End If
        FillVehicleModelsRelationsDataGridView()

    End Sub


    Private Sub VehicleModelsRelationsForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        If Me.Enabled = False Then Exit Sub

        CallingForm = SavedCallingForm
        Select Case Tunnel1
            Case "Tunnel2IsVehicleMakeID"
                CurrentVehicleMakeID = Tunnel2
                VehicleMakeTextBox.Text = Tunnel3
            Case "Tunnel2IsVehicleModelID"
                CurrentVehicleModelID = Tunnel2
                VehicleModelTextBox.Text = Tunnel3
            Case "Tunnel2IsVehicleTrimID"
                CurrentVehicleTrimID = Tunnel2
                VehicleTrimTextBox.Text = Tunnel3
        End Select
        If VehicleMakeTextBox.Text = "" Then
            VehicleMakeTextBox.Select()
        ElseIf VehicleModelTextBox.Text = "" Then
            VehicleModelTextBox.Select()
        ElseIf VehicleTrimTextBox.Text = "" Then
            VehicleTrimTextBox.Select()
        End If
    End Sub

    Private Sub UpdateTrimID()
        Dim VehicleFieldsToUpdate = ""
        Dim VehicleFilter = " WHERE VehicleModelID_Autonumber = " & Str(CurrentVehicleModelsRelationID)
        Dim MyNull = Chr(34) & Chr(34)


        MySelection = " UPDATE VehicleModelsRelationsTable " &
                              " SET VehicleTrimID_LongInteger = " & Str(CurrentVehicleTrimID)
        MySelection = MySelection & VehicleFilter
        JustExecuteMySelection()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        If Not EntriesAreValid() Then Exit Sub
        SaveModelsRelations()
    End Sub

    Private Function EntriesAreValid()

        If Trim(VehicleMakeTextBox.Text) = "" Then
            VehicleMakeTextBox.Select()
            Return False
        Else
            If Trim(VehicleModelTextBox.Text) = "" Then
                VehicleModelTextBox.Select()
                Return False
            Else
                If Trim(VehicleTrimTextBox.Text) = "" Then
                    VehicleTrimTextBox.Select()
                    Return False
                End If
            End If
        End If
        ModelsRelationsDetailsGroupBox.Visible = True
        ModelsRelationsDetailsGroupBox.Select()
        Return True
    End Function
    Private Sub SaveModelsRelations()
        Select Case PurposeOfEntry
            Case "ADD"
                AddNewModelRelations()
            Case "EDIT"
                UpdateModelRelations()
            Case Else
                Dim xxxx = 1
        End Select
        ModelsRelationsDetailsGroupBox.Visible = False
        FillVehicleModelsRelationsDataGridView()

    End Sub
    Private Sub AddNewModelRelations()
        ' EXECUTE INSERT COMMAND

        MySelection = "Select * from VehicleModelsRelationsTable WHERE VehicleTypeID_LongInteger = " & Str(CurrentVehicleMakeID) &
                                                           " AND " & " VehicleModelID_LongInteger = " & Str(CurrentVehicleModelID) &
                                                           " AND " & " VehicleTrimID_LongInteger = " & Str(CurrentVehicleTrimID)
        If RecordIsFound() Then
            MsgBox("This MODEL already exist")
            Exit Sub
        End If


        If MsgBox(" Confirm adding this model ?", vbYesNo) = MsgBoxResult.No Then Exit Sub

        MySelection = "INSERT INTO VehicleModelsRelationsTable  (" &
                                            "VehicleTypeID_LongInteger, " &
                                            "VehicleModelID_LongInteger,  " &
                                            "VehicleTrimID_LongInteger)  " &
                                      "VALUES (" &
                                              Str(CurrentVehicleMakeID) & ", " &
                                              Str(CurrentVehicleModelID) & ", " &
                                              Str(CurrentVehicleTrimID) & " )"


        JustExecuteMySelection()
        MySelection = "Select * from VehicleModelsRelationsTable WHERE VehicleTypeID_LongInteger = " & Str(CurrentVehicleMakeID) &
                                                           " AND " & " VehicleModelID_LongInteger = " & Str(CurrentVehicleModelID) &
                                                           " AND " & " VehicleTrimID_LongInteger = " & Str(CurrentVehicleTrimID)

        If NoRecordFound() Then
            MsgBox("PROBLEM ...... unseccessful save ")
            Exit Sub
        End If
    End Sub
    Private Sub UpdateModelRelations()


        MySelection = " UPDATE VehicleModelsRelationsTable " &
                     " SET    VehicleTypeID_LongInteger = " & Str(CurrentVehicleMakeID) & ", " &
                     "        VehicleModelID_LongInteger = " & Str(CurrentVehicleModelID) & ", " &
                     "        VehicleTrimID_LongInteger = " & Str(CurrentVehicleTrimID) &
                     " WHERE  VehicleModelsRelationID_Autonumber = " & CurrentVehicleModelsRelationID.ToString

        If NoRecordFound() Then
            Dim YYY = ""
        End If

    End Sub

    Private Sub ShowVehicleMakeForm()
        ShowCalledForm(Me, VehicleMakeForm)
    End Sub

    Private Sub ShowVehicleModelsTableForm()
        VehicleModelsForm.Text = "Make : " & VehicleMakeTextBox.Text
        ShowCalledForm(Me, VehicleModelsForm)
    End Sub

    Private Sub ShowVehicleTrimsTableForm()
        ShowCalledForm(Me, VehicleTrimsForm)
    End Sub
    Private Sub VehicleMakeTextBox_Click(sender As Object, e As EventArgs) Handles VehicleMakeTextBox.Click
        If Not IsEmpty(VehicleMakeTextBox.Text) Then
            If MsgBox("Replace vehicle make: " & VehicleMakeTextBox.Text, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        End If
        ShowVehicleMakeForm()
    End Sub
    Private Sub VehicleModelTextBox_Click(sender As Object, e As EventArgs) Handles VehicleModelTextBox.Click
        If Not IsEmpty(VehicleModelTextBox.Text) Then
            If MsgBox("Replace vehicle model:  " & VehicleModelTextBox.Text, vbYesNo) = MsgBoxResult.No Then Exit Sub
        End If
        ShowVehicleModelsTableForm()
    End Sub


    Private Sub VehicleTrimTextBox_Click(sender As Object, e As EventArgs) Handles VehicleTrimTextBox.Click
        If NotEmpty(VehicleTrimTextBox.Text) Then
            If MsgBox("Replace vehicle trim:   " & VehicleTrimTextBox.Text, vbYesNo) = MsgBoxResult.No Then Exit Sub
        End If
        ShowVehicleTrimsTableForm()
    End Sub


    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        ModelsRelationsDetailsGroupBox.Visible = False
    End Sub
End Class