Public Class SuppliersForm
    Private SuppliersFieldsToSelect = " "
    Private SuppliersTableLinks = "   "
    Private SuppliersSelectionFilter = " "
    Private SuppliersSelectionOrder = " "
    Private SuppliersRecordCount = 0
    Private CurrentSupplierID = -1
    Private CurrentSuppliersDataGridViewRow = -1
    Private SuppliersDataGridViewAlreadyFormated = False
    Private PurposeOfEntry As String
    Private SavedCallingForm As Form

    Private Sub SuppliersForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SavedCallingForm = CallingForm
        FillSuppliersDataGridView()
    End Sub
    Private Sub SuppliersForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        If Me.Enabled = False Then
            Exit Sub
        End If
        CallingForm = SavedCallingForm

        ' GET RETURNED DATA HERE

        Select Case Tunnel1
            Case "Tunnel2IsPurchaseOrderCode"
            Case Else
                MsgBox("BREAK DEBUGGER HERE, UNDETERMINED CALLED FORM")
        End Select
        '        FillPurchaseOrdersDataGridView()


    End Sub
    'DELETE THIS
    Private Sub SuppliersForm_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed
    End Sub
    Private Sub FillSuppliersDataGridView()

        SuppliersFieldsToSelect = "
SELECT SupplierTable.SupplierID_AutoNumber,
SupplierTable.SupplierName_ShortText35, 
SupplierTable.TelNo_ShortText10, 
SupplierTable.EmailAddress_ShortText20, 
SupplierTable.Street_ShortText25, 
SupplierTable.BldgAptRmNo_ShortText25, 
SupplierTable.ContactPerson_ShortText30, 
CityTable.CityName_ShortText25, 
CityTable.StateProvID_LongInteger, 
CityTable.ZipCode_ShortText9, 
StateProvTable.StateProvName_ShortText25, 
StateProvTable.StateCode_ShortText2, 
StateProvTable.CountryID_LongInteger, 
CountryTable.CountryName_ShortText25
"
        SuppliersTableLinks = " 
FROM ((SupplierTable LEFT JOIN CityTable ON SupplierTable.CityID_LongInteger = CityTable.CityID_AutoNumber) LEFT JOIN StateProvTable ON CityTable.StateProvID_LongInteger = StateProvTable.StateProvID_AutoNumber) LEFT JOIN CountryTable ON StateProvTable.CountryID_LongInteger = CountryTable.CountryID_Autonumber
 "

        SuppliersSelectionOrder = "        ORDER BY SupplierTable.SupplierName_ShortText35 "

        MySelection = SuppliersFieldsToSelect & SuppliersTableLinks & SuppliersSelectionFilter & SuppliersSelectionOrder
        JustExecuteMySelection()
        SuppliersDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        SuppliersRecordCount = RecordCount
        If Not SuppliersDataGridViewAlreadyFormated Then
            FormatSuppliersDataGridView()
        End If
        Dim NoOfHeaderLines = 2, RecordsToDisplay = 27

        SetGroupBoxHeight(NoOfHeaderLines, RecordsToDisplay, SuppliersRecordCount, SuppliersGroupBox, SuppliersDataGridView)
        Dim MinimumHeight = SuppliersDataGridView.Top + SupplierDetailsGroup.Height + 30
        If Me.Height < MinimumHeight Then
            Me.Height = MinimumHeight
        End If
        SupplierDetailsGroup.Top = SuppliersDataGridView.Top
    End Sub

    Private Sub FormatSuppliersDataGridView()
        SuppliersDataGridViewAlreadyFormated = True
        SuppliersGroupBox.Width = 0
        For i = 0 To SuppliersDataGridView.Columns.GetColumnCount(0) - 1
            SuppliersDataGridView.Columns.Item(i).Visible = False
            Select Case SuppliersDataGridView.Columns.Item(i).Name
                Case "SupplierName_ShortText35"
                    SuppliersDataGridView.Columns.Item(i).HeaderText = "Supplier"

                    SuppliersDataGridView.Columns.Item(i).Width = 300
                    SuppliersDataGridView.Columns.Item(i).Visible = True
            End Select

            If SuppliersDataGridView.Columns.Item(i).Visible = True Then
                SuppliersGroupBox.Width = SuppliersGroupBox.Width + SuppliersDataGridView.Columns.Item(i).Width
            End If
        Next
        ' NOTE" SYSTEM AUTOFITS THE GRIDVIEW FIELDS ACCORDING TO THEIR WITDH
        Me.Width = VehicleManagementSystemForm.Width
        If SuppliersGroupBox.Width > Me.Width + 20 Then
            SuppliersGroupBox.Width = Me.Width - 80
        Else
            SuppliersGroupBox.Width = SuppliersGroupBox.Width + 20
        End If
    End Sub

    Private Sub SuppliersDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles SuppliersDataGridView.RowEnter
        If e.RowIndex < 0 Then Exit Sub
        If SuppliersRecordCount = 0 Then Exit Sub
        CurrentSuppliersDataGridViewRow = e.RowIndex

        CurrentSupplierID = SuppliersDataGridView.Item("SupplierID_AutoNumber", CurrentSuppliersDataGridViewRow).Value
        SupplierName_ShortText35TextBox.Text = SuppliersDataGridView.Item("SupplierName_ShortText35", CurrentSuppliersDataGridViewRow).Value & " " & "details"
        ContactPerson_ShortText30TextBox.Text = NotNull(SuppliersDataGridView.Item("ContactPerson_ShortText30", CurrentSuppliersDataGridViewRow).Value)
        TelNo_ShortText10TextBox.Text = NotNull(SuppliersDataGridView.Item("TelNo_ShortText10", CurrentSuppliersDataGridViewRow).Value)
        Street_ShortText25TextBox.Text = NotNull(SuppliersDataGridView.Item("Street_ShortText25", CurrentSuppliersDataGridViewRow).Value)
        BldgAptRmNo_ShortText25TextBox.Text = NotNull(SuppliersDataGridView.Item("BldgAptRmNo_ShortText25", CurrentSuppliersDataGridViewRow).Value)
        CityID_LongIntegerTextBox.Text = NotNull(SuppliersDataGridView.Item("CityName_ShortText25", CurrentSuppliersDataGridViewRow).Value)
        StateProvName_ShortText25TextBox.Text = NotNull(SuppliersDataGridView.Item("StateProvName_ShortText25", CurrentSuppliersDataGridViewRow).Value)
        CountryName_ShortText25TextBox.Text = NotNull(SuppliersDataGridView.Item("CountryName_ShortText25", CurrentSuppliersDataGridViewRow).Value)
        EmailAddress_ShortText20TextBox.Text = NotNull(SuppliersDataGridView.Item("EmailAddress_ShortText20", CurrentSuppliersDataGridViewRow).Value)
        ZipCode_ShortText9TextBox.Text = NotNull(SuppliersDataGridView.Item("ZipCode_ShortText9", CurrentSuppliersDataGridViewRow).Value)

    End Sub

    Private Sub SelectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectToolStripMenuItem.Click
        Tunnel1 = "Tunnel2IsSupplierID"
        Tunnel2 = CurrentSupplierID
        Tunnel3 = SuppliersDataGridView.Item("SupplierName_ShortText35", CurrentSuppliersDataGridViewRow).Value
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        SupplierDetailsGroup.Visible = True
        TelNo_ShortText10TextBox.Enabled = False
        ContactPerson_ShortText30TextBox.Text = ""
        TelNo_ShortText10TextBox.Text = ""
        Street_ShortText25TextBox.Text = ""
        CityID_LongIntegerTextBox.Text = ""
        StateProvName_ShortText25TextBox.Text = ""
        PurposeOfEntry = "ADD"
        CurrentSupplierID = -1
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        PurposeOfEntry = "EDIT"
        SupplierDetailsGroup.Visible = True
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click

    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        Dim AnswerToMessage = ""
        If Trim(TelNo_ShortText10TextBox.Text) = "" Then
            TelNo_ShortText10TextBox.Select()
            Exit Sub
        End If
        If Trim(Street_ShortText25TextBox.Text) = "" Then
            Street_ShortText25TextBox.Select()
            Exit Sub
        End If
        If Trim(CityID_LongIntegerTextBox.Text) = "" Then
            AnswerToMessage = MsgBox("Would you like to leave the Brand blank ?", vbYesNo)
            If AnswerToMessage = vbNo Then
                CityID_LongIntegerTextBox.Select()
                Exit Sub
            End If
        End If
        Dim SavedSuppliersSelectionFilter = SuppliersSelectionFilter
        Select Case PurposeOfEntry
            Case "ADD"
                RegisterNewProductPart()
            Case = "EDIT"
                If Not MsgBox(" Confirm Saving changes for this Product ", vbYesNo) = vbYes Then
                    Exit Sub
                End If
                UpdateThisUpdateProductPartRecord()
        End Select
        SuppliersSelectionFilter = SavedSuppliersSelectionFilter
        SupplierDetailsGroup.Visible = False
        FillSuppliersDataGridView()
    End Sub
    Private Sub RegisterNewProductPart()
        'record was first tested if it already exist in the workorder table

        ' EXECUTE INSERT COMMAND
        Dim FieldsToUpdate = " ( " &
                    " ManufacturerPartNo_ShortText30Fld, " &
                    " ManufacturerPartNoClean_ShortText30Fld, " &
                    " ManufacturerDescription_ShortText250, " &
                    " MasterCodeBookID_LongInteger, " &
                    " BrandID_LongInteger, " &
                    " Unit_ShortText3) "

        Dim ReplacementData = "(" &
                    Chr(34) & TelNo_ShortText10TextBox.Text & Chr(34) & ", " &
                    Chr(34) & Trim(Street_ShortText25TextBox.Text) & Chr(34) & ", " &
                    Chr(34) & Trim(StateProvName_ShortText25TextBox.Text).ToUpper & Chr(34) &
                    ")"
        MySelection = "INSERT INTO SuppliersTable  " & FieldsToUpdate & " VALUES " & ReplacementData

        JustExecuteMySelection()
    End Sub
    Private Sub UpdateThisUpdateProductPartRecord()

        SuppliersSelectionFilter = " WHERE ProductsPartID_Autonumber = " '& Str(CurrentRequestedProductPartID)
        SuppliersFieldsToSelect = " UPDATE SuppliersTable  SET " &
                    " ManufacturerPartNo_ShortText30Fld = " & Str(TelNo_ShortText10TextBox.Text) & ", " &
                    " Trim(ManufacturerPartDescTextBox.Text) = " & Trim(Street_ShortText25TextBox.Text)

        MySelection = SuppliersFieldsToSelect & SuppliersSelectionFilter
        JustExecuteMySelection()

    End Sub

    Private Sub SearchSupplierToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SearchSupplierToolStripMenuItem.Click
        If SearchDescriptionToolStripTextBox.Text = "" Then Exit Sub
        If SearchDescriptionToolStripTextBox.Text = "DESCRIPTION" Then Exit Sub
        Dim SavedSuppliersSelectionFilter = SuppliersSelectionFilter
        SetSearchParameters()
        FillSuppliersDataGridView()
        SuppliersSelectionFilter = SavedSuppliersSelectionFilter
    End Sub
    Private Sub SetSearchParameters()
        SuppliersSelectionFilter = " WHERE SupplierName_ShortText35 Like " & Chr(34) & "%" & Trim(SearchDescriptionToolStripTextBox.Text) & "%" & Chr(34)

    End Sub

    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        Tunnel1 = "Tunnel2IsSupplierID"
        Tunnel2 = -1
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub
End Class