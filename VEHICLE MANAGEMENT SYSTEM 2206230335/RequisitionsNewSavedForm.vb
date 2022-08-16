Public Class RequisitionsNewSavedForm
    Private RequisitionsFieldsToSelect = ""
    Private RequisitionsTableLinks = ""
    Private RequisitionsSelectionFilter = ""
    Private RequisitionsSelectionOrder = ""
    Private RequisitionsRecordCount As Integer = -1
    Private CurrentRequisitionID As Integer = -1
    Private CurrentRequisitionsDataGridViewRow As Integer = -1
    Private RequisitionsDataGridViewAlreadyFormated = False

    Private RequisitionItemsFieldsToSelect = ""
    Private RequisitionItemsTableLinks = ""
    Private RequisitionItemsSelectionFilter = ""
    Private RequisitionItemsSelectionOrder = ""
    Private RequisitionItemsRecordCount As Integer = -1
    Private CurrentRequisitionItemID As Integer = -1
    Private CurrentRequisitionItemsDataGridViewRow As Integer = -1
    Private RequisitionItemsDataGridViewAlreadyFormated = False

    Private PurchaseStatusSelection = 0
    Private PurposeOfEntry As String
    Private Sub RequisitionsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupFormUserAccess()
        RequisitionsDataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True '(1 - Property state = true, 2- false, 3-default on development
        RequisitionItemsDataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True '(1 - Property state = true, 2- false, 3-default on development
    End Sub
    Private Sub SetupFormUserAccess()
        SetupRequisitionsSelection(0)                      ' this routine proceeds to FillRequisitionsDataGridView()

    End Sub
    Private Sub RequisitionsForm_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed
        'Enables calling form
        Select Case ActivatedByTextBox.Text
            Case "VehicleManagementSystemForm"
                VehicleManagementSystemForm.Enabled = True ' triggers enabledchaned event of calling form
            Case Else
                MsgBox(ActivatedByTextBox.Text & """ not yet filtered in the Select Case ActivatedBy.Text of """ & Me.Name)
        End Select
        ActivatedByTextBox.Text = ""
    End Sub

    Private Sub RequisitionsForm_EnabledChanged(sender As Object, e As EventArgs) Handles MyBase.EnabledChanged
        If Me.Enabled = False Then
            Me.ShowInTaskbar = False
            Exit Sub
        End If

        ' GET RETURNED DATA HERE

        Select Case Tunnel1
            Case "Tunnel2IsRequisitionCode"
                CurrentRequisitionID = Tunnel2
                '                SaveNewRequisition()
            Case Else
                MsgBox("BREAK DEBUGGER HERE, UNDETERMINED CALLED FORM")
        End Select
        FillRequisitionsDataGridView()

        Me.ShowInTaskbar = True
        Me.Show()
        Me.Select()             'enables the page to be active
        ResetTunnels() ' INFORMATION IN TUNNELS HAVE BEEN RECEIVED

    End Sub
    Private Sub ReturnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnToolStripMenuItem.Click
        Me.Close()                                                  'Main Form  mode
    End Sub
    Private Sub TemporaryForThisProjectForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillRequisitionsDataGridView()
    End Sub

    Private Sub FillRequisitionsDataGridView()

        RequisitionsFieldsToSelect = "Select 
RequisitionsTable.RequisitionID_AutoNumber,
RequisitionsTable.RequisitionRevision_Integer,
RequisitionsTable.RequisitionDate_ShortDate,
RequisitionsTable.SupplierID_LongInteger, 
RequisitionsTable.Discount_Integer, 
RequisitionsTable.TaxedAmount_Double, 
RequisitionsTable.POTotal_Double, 
SuppliersTable.SupplierName_ShortText35
 "
        RequisitionsTableLinks = " 
From RequisitionsTable LEFT Join SuppliersTable On RequisitionsTable.SupplierID_LongInteger = SuppliersTable.SupplierID_AutoNumber
"
        RequisitionsSelectionOrder = " ORDER BY RequisitionID_AutoNumber "

        MySelection = RequisitionsFieldsToSelect & RequisitionsTableLinks & RequisitionsSelectionFilter & RequisitionsSelectionOrder

        JustExecuteMySelection()
        RequisitionsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        RequisitionsRecordCount = RecordCount
        If Not RequisitionsDataGridViewAlreadyFormated Then FormatRequisitionsDataGridView()
        Dim FormLowPointFromGrid = 90

        Dim NoOfHeaderLines = 1
        Dim RecordsDisplyed = RequisitionsRecordCount

        If RequisitionsRecordCount > 28 Then
            RecordsDisplyed = 28
        Else
            RecordsDisplyed = RequisitionsRecordCount + 1
        End If
        RequisitionsDataGridView.Height = (RequisitionsDataGridView.ColumnHeadersHeight * NoOfHeaderLines) + (DataGridViewRowHeight * RecordsDisplyed) + DataGridViewRowHeight
        Me.Top = VehicleManagementSystemForm.VehicleManagementMenuStrip.Top + VehicleManagementSystemForm.VehicleManagementMenuStrip.Height + 20
        Me.Left = VehicleManagementSystemForm.Left

        RequisitionsDataGridView.Left = Me.Left + 20

        RequisitionDetailsGroupBox.Top = RequisitionsDataGridView.Top
        RequisitionDetailsGroupBox.Left = RequisitionsDataGridView.Left + RequisitionsDataGridView.Width + 5

        RequisitionItemsDataGridView.Left = RequisitionDetailsGroupBox.Left
        RequisitionItemsDataGridView.Top = RequisitionDetailsGroupBox.Top + RequisitionDetailsGroupBox.Height

        If RequisitionItemsDataGridView.Top + RequisitionItemsDataGridView.Height > RequisitionsDataGridView.Top + RequisitionsDataGridView.Height Then
            Me.Height = RequisitionItemsDataGridView.Top + RequisitionItemsDataGridView.Height
        Else
            Me.Height = RequisitionsDataGridView.Top + RequisitionsDataGridView.Height
        End If

    End Sub
    Private Sub FormatRequisitionsDataGridView()
        RequisitionsDataGridViewAlreadyFormated = True
        RequisitionsDataGridView.Width = 0
        For i = 0 To RequisitionsDataGridView.Columns.GetColumnCount(0) - 1

            RequisitionsDataGridView.Columns.Item(i).Visible = False

            Select Case RequisitionsDataGridView.Columns.Item(i).HeaderText
                Case "RequisitionID_AutoNumber"
                    RequisitionsDataGridView.Columns.Item(i).HeaderText = "Purchase Order ID"
                    RequisitionsDataGridView.Columns.Item(i).Width = 70
                    RequisitionsDataGridView.Columns.Item(i).Visible = True
                Case "RequisitionRevision_Integer"
                    RequisitionsDataGridView.Columns.Item(i).HeaderText = "PO rev. #"
                    RequisitionsDataGridView.Columns.Item(i).Width = 70
                    RequisitionsDataGridView.Columns.Item(i).Visible = True
                Case "RequisitionDate_ShortDate"
                    RequisitionsDataGridView.Columns.Item(i).HeaderText = "PO Date"
                    RequisitionsDataGridView.Columns.Item(i).Width = 70
                    RequisitionsDataGridView.Columns.Item(i).Visible = True
                Case "POTotal_Double"
                    RequisitionsDataGridView.Columns.Item(i).HeaderText = "PO Total"
                    RequisitionsDataGridView.Columns.Item(i).Width = 70
                    RequisitionsDataGridView.Columns.Item(i).Visible = True
                Case "SupplierName_ShortText35"
                    RequisitionsDataGridView.Columns.Item(i).HeaderText = "Supplier"
                    RequisitionsDataGridView.Columns.Item(i).Width = 200
                    RequisitionsDataGridView.Columns.Item(i).Visible = True
            End Select

            If RequisitionsDataGridView.Columns.Item(i).Visible = True Then
                RequisitionsDataGridView.Width = RequisitionsDataGridView.Width + RequisitionsDataGridView.Columns.Item(i).Width
            End If
        Next

        ' NOTE" SYSTEM AUTOFITS THE GRIDVIEW FIELDS ACCORDING TO THEIR WITDH
        Me.Width = VehicleManagementSystemForm.Width
        If RequisitionsDataGridView.Width > Me.Width + 20 Then
            RequisitionsDataGridView.Width = Me.Width - 80
        Else
            RequisitionsDataGridView.Width = RequisitionsDataGridView.Width + 20
        End If
    End Sub
    Private Sub RequisitionsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles RequisitionsDataGridView.RowEnter
        If e.RowIndex < 0 Then Exit Sub
        If RequisitionsRecordCount = 0 Then Exit Sub

        CurrentRequisitionsDataGridViewRow = e.RowIndex

        CurrentRequisitionID = RequisitionsDataGridView.Item("RequisitionID_Autonumber", CurrentRequisitionsDataGridViewRow).Value
    End Sub

    Public Sub SetupRequisitionsSelection(RequisitionsStatusSelection)
        RequisitionsStatusSelection = RequisitionsStatusSelection
        Select Case RequisitionsStatusSelection
            Case 0
                RequisitionsSelectionFilter = " WHERE RequisitionStatus_Byte  = 0 "
                Me.Text = "OUTSTANDING WORK ORDERS"
            Case 1
                RequisitionsSelectionFilter = " WHERE RequisitionsStatus_Byte = 1 "
            Case 2
                RequisitionsSelectionFilter = " WHERE RequisitionsStatus_Byte = 2 "
            Case 3
                RequisitionsSelectionFilter = " WHERE RequisitionsStatus_Byte = 3 "
                Me.Text = "FINISHED WORK ORDERS for BILLING "
            Case 9
                RequisitionsSelectionFilter = " WHERE RequisitionsStatus_Byte = 9 "
                Me.Text = "WORK ORDERS RELEASED"
            Case 10
                RequisitionsSelectionFilter = ""
                Me.Text = "ALL WORK ORDERS"

        End Select

        FillRequisitionsDataGridView()
    End Sub

    Public Sub RegisterNewRequisition()
        AddARequisitionRecord()
        Dim DataRowIndex As DataRow = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        CurrentRequisitionID = DataRowIndex("RequisitionID_AutoNumber")
        '        RequisitionConcernsDataGridView.Visible = True
        '        AddRequisitionConcernToolStripMenuItem.Visible = True
        '        RemoveConcernOrJobToolStripMenuItem.Visible = True
    End Sub
    Private Sub AddARequisitionRecord()
        'record was first tested if it already exist in the Requisition table

        ' EXECUTE INSERT COMMAND
        Dim FieldsToUpdate = " ( " &
                             " ) "

        Dim ReplacementData = "(" &
                     ")"

        MySelection = "INSERT INTO RequisitionsTable  " & FieldsToUpdate & " VALUES " & ReplacementData

        JustExecuteMySelection()

        '      MySelection = "SELECT * " &
        '                     " FROM RequisitionsTable " &
        '                    " WHERE trim(RequisitionNumber_ShortText12) = " & Chr(34) & Trim(RequisitionNumberTextBox.Text) & Chr(34)

        '     If NoRecordFound() Then
        '     MsgBox("Unsuccessful insert, chk with systems")
        '    End If
    End Sub

    Public Sub SetupRequisitionSelection(RequisitionStatusSelection)

        RequisitionStatusSelection = RequisitionStatusSelection
        Select Case RequisitionStatusSelection
            Case 0
                RequisitionsSelectionFilter = " WHERE (RequisitionStatus_Byte  = 0 OR RequisitionStatus_Byte = 3)"
                Me.Text = "OUTSTANDING WORK ORDERS"
            Case 1
                RequisitionsSelectionFilter = " WHERE RequisitionStatus_Byte = 1 "
            Case 2
                RequisitionsSelectionFilter = " WHERE RequisitionStatus_Byte = 2 "
            Case 3
                RequisitionsSelectionFilter = " WHERE RequisitionStatus_Byte = 3 "
                Me.Text = "FINISHED WORK ORDERS for BILLING "
            Case 9
                RequisitionsSelectionFilter = " WHERE RequisitionStatus_Byte = 9 "
                Me.Text = "WORK ORDERS RELEASED"
            Case 10
                RequisitionsSelectionFilter = ""
                Me.Text = "ALL WORK ORDERS"

        End Select

        FillRequisitionsDataGridView()
    End Sub
    Private Sub PODetailsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RequisitionDetailsToolStripMenuItem1.Click

    End Sub

    Private Sub OutstandingRequisitionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OutstandingRequisitionsToolStripMenuItem.Click
        If Not PurchaseStatusSelection = 0 Then SetupRequisitionSelection(0)
        PurchaseStatusSelection = 0
    End Sub

    Private Sub CompletedRequisitionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompletedRequisitionsToolStripMenuItem.Click
        If Not PurchaseStatusSelection = 9 Then SetupRequisitionSelection(9)
        PurchaseStatusSelection = 9
    End Sub

    Private Sub AllRequisitionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllRequisitionsToolStripMenuItem.Click
        If Not PurchaseStatusSelection = 10 Then SetupRequisitionSelection(10)
        PurchaseStatusSelection = 10
    End Sub

End Class