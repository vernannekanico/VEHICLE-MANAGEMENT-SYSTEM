Public Class BrandsForm
    Private CurrentBrandID As Integer = -1
    Private CurrentBrandRow As Integer = -1

    Private PurposeOfEntry = ""

    Private BrandDataGridViewInitialized = False

    Private BrandFieldsToSelect = ""
    Private BrandsTableLinks = ""
    Private BrandSelectionFilter = ""
    Private BrandSelectionFilterSaved = ""
    Private BrandSelectionOrder = ""
    Private SavedCustomer = ""
    Private FieldsValues = ""
    Private FieldsToReplace = ""

    Private CodeRequested = ""
    Private MeLocationX As Integer
    Private MeLocationY As Integer
    Private SavedCallingForm As Form

    Private Sub BrandForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' form returns       Tunnel1 = CurrentBrandID

        ' ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        ' enable all menus needded on first show
        SavedCallingForm = CallingForm

        EnableAddEditDeleteMenuItems()
        MeLocationX = Me.Location.X

        FillBrandDataGridView()
        'SET AND RESET ALL ENTRY PARAMETERS
        ResetTunnels()
    End Sub
    Private Sub FillBrandDataGridView()
        BrandFieldsToSelect = "Select * "
        BrandsTableLinks = "FROM BrandsTable "

        BrandSelectionOrder = " ORDER BY BrandName_ShortText20 "

        MySelection = BrandFieldsToSelect & BrandsTableLinks & BrandSelectionFilter & BrandSelectionOrder

        JustExecuteMySelection()
        BrandDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        BrandDataGridView.Columns.Item("BrandID_AutoNumber").Visible = False

        BrandDataGridView.Columns.Item("BrandName_ShortText20").HeaderText = "Brand" ' note 15 chars = 184 pixels  new pixels =20 x 184/15 = 245
        BrandDataGridView.Columns.Item("BrandName_ShortText20").Width = 35 * 184 / 15

        BrandDataGridView.Width = BrandDataGridView.Columns.Item("BrandName_ShortText20").Width + 50

        Dim NoOfHeaderLines = 1
        Dim RecordsDisplyed = RecordCount
        Dim FormLowPointFromGrid = 90
        If RecordCount > 27 Then
            Me.Location = New Point(MeLocationX, 50)
            RecordsDisplyed = 22
        Else
            RecordsDisplyed = RecordCount + 1
        End If
        BrandDataGridView.Height = (BrandDataGridView.ColumnHeadersHeight * NoOfHeaderLines) + (DataGridViewRowHeight * RecordsDisplyed) + DataGridViewRowHeight
        Me.Height = BrandDataGridView.Height + FormLowPointFromGrid + 110
        '       VehicleTrimDataGridView.Location = New Point(1, 49)
        If Me.Height < DetailsGroupBox.Height Then
            Me.Height = DetailsGroupBox.Height + DataGridViewRowHeight
        End If

        Me.Width = BrandDataGridView.Width + 30
        If Me.Width < DetailsGroupBox.Width Then
            Me.Width = DetailsGroupBox.Width + 10
        End If

    End Sub
    Private Sub BrandDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles BrandDataGridView.RowEnter
        If e.RowIndex < 0 Then Exit Sub
        If RecordCount = 0 Then Exit Sub
        If Not BrandDataGridViewInitialized Then
            BrandDataGridViewInitialized = True
        End If

        CurrentBrandRow = e.RowIndex

        CurrentBrandID = BrandDataGridView.Item("BrandID_AutoNumber", CurrentBrandRow).Value
        If DetailsGroupBox.Enabled = False Then
            If SaveToolStripMenuItem.Visible = False Then
                ShowDetailsGroupBox()
            End If
        End If
    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        PurposeOfEntry = "ADD"
        ' Shows the details editing group box and enables edit to the fields
        ' All DataGridViews are disabled
        ' Searching is disable
        CurrentBrandID = -1
        DetailsGroupBox.Text = "Add a new Brand"
        EnableModifyMode()          '' Add Edit Delete are turned off and Cancel ans Save options are made available
    End Sub
    Private Sub ShowDetailsGroupBox()
        DetailsGroupBox.Visible = True
        If Not DetailsGroupBox.Text = "" Then
            BrandDataGridView.Enabled = False
        End If
        If CurrentBrandID = -1 Then
            BrandNameTextBox.Text = ""
            CurrentBrandID = -1
        Else
            BrandNameTextBox.Text = BrandDataGridView.Item("BrandName_ShortText20", CurrentBrandRow).Value
        End If
    End Sub
    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        PurposeOfEntry = "EDIT"

        If Not MsgBox("This Brand is currently LINKED to other Files, do you really want to change informations for this Brand ?", vbYesNo) = vbYes Then
            Exit Sub
        End If
        DetailsGroupBox.Text = "EDIT Brand"
        EnableModifyMode()
    End Sub
    Private Sub SaveCurrentFieldContents()
        Select Case PurposeOfEntry
            Case "ADD"
                If ThisBrandAlreadyExist() Then
                    MsgBox("This record already exists")
                    Exit Sub
                End If

                Dim FullName = Trim(BrandNameTextBox.Text)
                If Not MsgBox(" Confirm adding new BRAND " & FullName, vbYesNo) = vbYes Then
                    Exit Sub
                End If

                If Not SuccessfullyAddingThisBrandRecord() Then
                    Exit Sub
                End If
            Case "EDIT"
                Dim FullName = Trim(BrandNameTextBox.Text)
                If Not MsgBox(" Confirm Saving changes for Brand " & FullName, vbYesNo) = vbYes Then
                    Exit Sub
                End If

                Dim BrandFilter = " WHERE BrandID_AutoNumber = " & Str(CurrentBrandID)
                Dim MyNull = Chr(34) & Chr(34)
                Dim yyyyy = ""

                BrandFieldsToSelect = " UPDATE BrandsTable  SET " &
                    " BrandName_ShortText20 = " & Chr(34) & BrandNameTextBox.Text & Chr(34)
                MySelection = BrandFieldsToSelect & BrandFilter
                If NoRecordFound() Then Dim dummy = 1
            Case Else
                Dim XXXX = 1
        End Select
        DisableModifyMode()
        FillBrandDataGridView()
    End Sub
    Private Sub SelectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectToolStripMenuItem.Click
        Tunnel1 = "Tunnel2IsBrandID"
        Tunnel2 = CurrentBrandID
        Select Case SavedCallingForm.Name
            Case "ProductsPartsForm"
                ProductsPartsForm.BrandNameTextBox.Text = BrandDataGridView.Item("BrandName_ShortText20", CurrentBrandRow).Value
            Case Else
                MsgBox(ActivatedByTextBox.Text & "does not have case option here. PAUSE ")
        End Select
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub
    Private Sub EnableAddEditDeleteMenuItems()
        SelectToolStripMenuItem.Visible = True
        SaveToolStripMenuItem.Visible = False
        AddToolStripMenuItem.Visible = True
        EditToolStripMenuItem.Visible = True
        ViewToolStripMenuItem.Visible = True
        DeleteToolStripMenuItem.Visible = True
    End Sub
    Private Sub DisableAddEditDeleteMenuItems()
        SelectToolStripMenuItem.Visible = False
        SaveToolStripMenuItem.Visible = True
        AddToolStripMenuItem.Visible = False
        EditToolStripMenuItem.Visible = False
        ViewToolStripMenuItem.Visible = False
        DeleteToolStripMenuItem.Visible = False
    End Sub
    Private Sub DisableModifyMode()
        EnableAddEditDeleteMenuItems()
        DetailsGroupBox.Visible = False
        BrandDataGridView.Enabled = True
    End Sub
    Private Sub EnableModifyMode()      ' Add Edit Delete are turned off and Cancel ans Save options are made available
        DisableAddEditDeleteMenuItems()
        ShowDetailsGroupBox()
    End Sub
    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        ' HERE DETERMINE FIRST ALL RELATIONS
        DetailsGroupBox.Text = "DELETE Brand"
        EnableModifyMode()
        If Not MsgBox("Do you want to continue deleting this EMPLOYEE ?", vbYesNo) = vbYes Then
        Else
            MySelection = "DELETE FROM BrandsTable WHERE BrandID_AutoNumber = " & Str(CurrentBrandID)
            JustExecuteMySelection()
            FillBrandDataGridView()
        End If
        DisableModifyMode()
    End Sub
    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        If BrandFieldsEntriesAreNotValidAndComplete() Then Exit Sub
        SaveCurrentFieldContents()
    End Sub
    Private Function BrandFieldsEntriesAreNotValidAndComplete()
        If Trim(BrandNameTextBox.Text) = "" Then BrandNameTextBox.Select() : Return True
        Return False
    End Function

    Private Function ThisBrandAlreadyExist()
        MySelection = "SELECT * FROM BrandsTable " &
            " WHERE trim(BrandName_ShortText20) = " & Chr(34) & Trim(BrandNameTextBox.Text) & Chr(34)
        If ThereIsARecord() Then
            Return True
        End If
        Return False
    End Function
    Private Function SuccessfullyAddingThisBrandRecord()
        ' EXECUTE INSERT COMMAND

        If ThisBrandAlreadyExist() Then
            r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
            CurrentBrandID = r("BrandID_AutoNumber")
            Return True
        End If
        FieldsToReplace = "" &
            "BrandName_ShortText20"

        FieldsValues = "" &
            Chr(34) & Trim(BrandNameTextBox.Text) & Chr(34)

        MySelection = "INSERT INTO BrandsTable  (" & FieldsToReplace & ") VALUES (" & FieldsValues & ")"

        JustExecuteMySelection()
        FillBrandDataGridView()
        Return True
    End Function

    Private Sub BrandNameTextBox_TextChanged(sender As Object, e As EventArgs) Handles BrandNameTextBox.TextChanged
        If Len(Trim(BrandNameTextBox.Text)) > 20 Then
            BrandNameTextBox.Text = BrandNameTextBox.Text.Substring(0, 19)
        End If
    End Sub

    Private Sub ReturnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnToolStripMenuItem.Click
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub
End Class