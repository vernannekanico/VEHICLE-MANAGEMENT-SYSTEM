Public Class ConcernTypesForm
    Private CurrentConcernTypeID As Integer = -1
    Private CurrentConcernTypeRow As Integer = -1

    Private ConcernTypesDataGridViewInitialized = False

    Private ConcernTypeFieldsToSelect = ""
    Private ConcernTypeTablesLinks = ""
    Private ConcernTypeSelectionFilter = ""
    Private ConcernTypeSelectionFilterSaved = ""
    Private ConcernTypeSelectionOrder = ""

    Public ConcernTypeID_AutoNumber As Integer
    Private MeLocationX As Integer
    Private MeLocationY As Integer

    Private Sub ConcernTypeForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' form returns       Tunnel1 = CurrentConcernTypeID
        '                    Tunnel2 = 

        ' form recieves on enabled  ' CurrentVehicleTypeID 
        '                           ' note: trim belongs to a model
        '                           '       model belongs to a type

        ' if empty, it has been opened not to return a code

        ' ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


        MeLocationX = Me.Location.X
        EnableModifyMode()
        'GET ALL ENTRY PARAMETERS
        'may delete this if there is no need
        ConcernTypeSelectionFilterSaved = ConcernTypeSelectionFilter ' delete this

        FillConcernTypesDataGridView()

        'SET AND RESET ALL ENTRY PARAMETERS
        ResetTunnels()



    End Sub
    Private Sub FillConcernTypesDataGridView()

        MySelection = "Select * FROM ConcernTypeTable "

        If NoRecordFound() Then Dim xxx = 10


        ConcernTypeDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        SetupConcernTypesDataGridView()



    End Sub
    Private Sub SetupConcernTypesDataGridView()
        MySelection = "Select ConcernTypeID_AutoNumber, " &
                      "       MainSystemCode_ShortText1,  " &
                      "       ConcernType_ShortText100,  " &
                      "       ConcernTypePrefix_ShortText50 "

        ConcernTypeDataGridView.Columns.Item("ConcernTypeID_AutoNumber").Visible = False

        ConcernTypeDataGridView.Columns.Item("MainSystemCode_ShortText1").HeaderText = "Code"
        ConcernTypeDataGridView.Columns.Item("MainSystemCode_ShortText1").Width = 50

        ConcernTypeDataGridView.Columns.Item("ConcernType_ShortText100").HeaderText = "Type of Concern"
        ConcernTypeDataGridView.Columns.Item("ConcernType_ShortText100").Width = 500

        ConcernTypeDataGridView.Columns.Item("ConcernTypePrefix_ShortText50").HeaderText = "Action Required"
        ConcernTypeDataGridView.Columns.Item("ConcernTypePrefix_ShortText50").Width = 500

        ConcernTypeDataGridView.Width = ConcernTypeDataGridView.Columns.Item("MainSystemCode_ShortText1").Width +
                                 ConcernTypeDataGridView.Columns.Item("ConcernType_ShortText100").Width +
                                 ConcernTypeDataGridView.Columns.Item("ConcernTypePrefix_ShortText50").Width +
                                 50
        Me.Width = ConcernTypeDataGridView.Width + 10

        'SET AND RESET ALL ENTRY PARAMETERS
        ResetTunnels()
    End Sub

    Private Sub ConcernTypeDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles ConcernTypeDataGridView.RowEnter
        If e.RowIndex = -1 Then ConcernTypeID_AutoNumber = -1 : Exit Sub
        CurrentConcernTypeRow = e.RowIndex
        CurrentConcernTypeID = ConcernTypeDataGridView("ConcernTypeID_AutoNumber", CurrentConcernTypeRow).Value

    End Sub
    Private Sub ConcernTypeDataGridView_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles ConcernTypeDataGridView.DataBindingComplete
        Dim NoOfHeaderLines = 2
        Dim RecordsDisplyed = RecordCount
        Dim FormLowPointFromGrid = 90
        If RecordCount > 27 Then
            Me.Location = New Point(MeLocationX, 50)
            RecordsDisplyed = 27
        Else
            RecordsDisplyed = RecordCount + 1
        End If
        ConcernTypeDataGridView.Height = (ConcernTypeDataGridView.ColumnHeadersHeight * NoOfHeaderLines) + (DataGridViewRowHeight * RecordsDisplyed) + DataGridViewRowHeight
        Me.Height = ConcernTypeDataGridView.Height + FormLowPointFromGrid
        '       ConcernTypeDataGridView.Location = New Point(1, 49)
    End Sub

    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        If ModifyGroupBox.Visible = True Then
            EnableModifyMode()
        Else
            Tunnel1 = -1
            Me.Close()
        End If

    End Sub

    Private Sub ConcernTypeForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        'Enables calling form
        Select Case ActivatedByTextBox.Text
            Case "VehicleManagementSystemForm"
                VehicleManagementSystemForm.Enabled = True ' triggers enabledchaned event of calling form

            Case "ConcernsDetailsForm"
                CurrentConcernTypeID = Tunnel1
                ConcernsDetailsForm.Enabled = True
            Case "ConcernsForm"
                ConcernsForm.Enabled = True
            Case Else
                Dim x = "break here"
        End Select
        ActivatedByTextBox.Text = ""
    End Sub

    Private Sub ConcernTypeForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        'Refresh datagridviw here
        ' GET RETURNED DATA HERE

    End Sub



    Private Sub SelectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectToolStripMenuItem.Click
        Tunnel1 = CurrentConcernTypeID

        ConcernsForm.ConcernTypesComboBox.Text = ConcernTypeDataGridView("ConcernType_ShortText100", CurrentConcernTypeRow).Value
        Me.Close()
    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        ModifyGroupBox.Text = "Add a TYPE CONCERN"
        DisAbleModifyMode()
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        ModifyGroupBox.Text = "Edit a TYPE CONCERN"
        DisAbleModifyMode()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        ModifyGroupBox.Text = "Delete a TYPE CONCERN"
        MsgBox("not needed at this time")
        DisAbleModifyMode()
    End Sub
    Private Sub EnableModifyMode()
        ModifyGroupBox.Visible = False
        SelectToolStripMenuItem.Visible = True
        AddToolStripMenuItem.Visible = True
        EditToolStripMenuItem.Visible = True
        DeleteToolStripMenuItem.Visible = True
        ViewToolStripMenuItem.Visible = True
        SaveToolStripMenuItem.Visible = False
    End Sub
    Private Sub DisAbleModifyMode()
        ModifyGroupBox.Visible = True
        SelectToolStripMenuItem.Visible = False
        SaveToolStripMenuItem.Visible = True
        AddToolStripMenuItem.Visible = False
        EditToolStripMenuItem.Visible = False
        ViewToolStripMenuItem.Visible = False
        DeleteToolStripMenuItem.Visible = False
    End Sub

End Class