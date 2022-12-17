Public Class ProductPartsPackingsForm
    Private ProductPartsPackingsFieldsToSelect = ""
    Private ProductPartsPackingsSelectionFilter = ""
    Private ProductPartsPackingsSelectionOrder = ""
    Private ProductPartsPackingsRecordCount As Integer = -1
    Private ProductPartsPackingsDataGridViewAlreadyFormatted = False
    Private CurrentProductPartsPackingID = -1
    Private CurrentProductPartsPackingsRow As Integer = -1
    Private PurposeOfEntry = ""

    Private CurrentProductPartID = Tunnel2
    Private SavedCallingForm As Form
    Private Sub ProductPartsPackingsPackingsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        SavedCallingForm = CallingForm
        If Tunnel1 = "Tunnel2IsProductPartID" Then
            CurrentProductPartID = Tunnel2
            ProductPartsPackingsSelectionFilter = " WHERE ProductPartID_LongInteger = " & CurrentProductPartID.ToString
        End If
        FillProductPartsPackingsDataGridView()
    End Sub
    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub
    Private Sub SelectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectToolStripMenuItem.Click
        Tunnel1 = "Tunnel2IsProductPartsPackingID"
        Tunnel2 = CurrentProductPartsPackingID
        Tunnel3 = ProductPartsPackingsDataGridView.Item("QuantityPerPack_Double", CurrentProductPartsPackingsRow).Value.ToString & Space(1) &
                                      ProductPartsPackingsDataGridView.Item("UnitOfTheQuantity_ShortText3", CurrentProductPartsPackingsRow).Value.ToString &
                                        " / " &
                                      ProductPartsPackingsDataGridView.Item("UnitOfThePacking_ShortText3", CurrentProductPartsPackingsRow).Value.ToString
        Select Case SavedCallingForm.Name
            Case "ProductsPartsForm"
                ProductsPartsForm.UnitTextBox.Text = ProductPartsPackingsDataGridView.Item("UnitOfThePacking_ShortText3", CurrentProductPartsPackingsRow).Value
                ProductsPartsForm.PackingTextBox.Text = Tunnel3
        End Select
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub
    Private Sub FillProductPartsPackingsDataGridView()

        ProductPartsPackingsFieldsToSelect =
" 
SELECT * FROM ProductPartPackingsQuery
"


        MySelection = ProductPartsPackingsFieldsToSelect & ProductPartsPackingsSelectionFilter & ProductPartsPackingsSelectionOrder

        JustExecuteMySelection()
        ProductPartsPackingsRecordCount = RecordCount

        ProductPartsPackingsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable



        If Not ProductPartsPackingsDataGridViewAlreadyFormatted Then
            FormatProductPartsPackingsDataGridView()
        End If

        Dim RecordsToDisplay = 20
        SetGroupBoxHeight(RecordsToDisplay, ProductPartsPackingsRecordCount, ProductPartsPackingsGroupBox, ProductPartsPackingsDataGridView)
        ProductPartsPackingsGroupBox.Top = ProductsPartsPackingMenuStrip.Top + ProductsPartsPackingMenuStrip.Height
        PackingDetailsGroupBox.Top = ProductPartsPackingsGroupBox.Top + ProductPartsPackingsGroupBox.Height
        Me.Height = ProductPartsPackingsGroupBox.Top + ProductPartsPackingsGroupBox.Height + PackingDetailsGroupBox.Height + 50
        PackingDetailsGroupBox.Left = (Me.Width - PackingDetailsGroupBox.Width) / 2

        Me.Top = (VehicleManagementSystemForm.Height - Me.Height) / 2
    End Sub

    Private Sub FormatProductPartsPackingsDataGridView()
        ProductPartsPackingsDataGridViewAlreadyFormatted = True
        ProductPartsPackingsGroupBox.Width = 0

        For i = 0 To ProductPartsPackingsDataGridView.Columns.GetColumnCount(0) - 1

            ProductPartsPackingsDataGridView.Columns.Item(i).Visible = False
            Select Case ProductPartsPackingsDataGridView.Columns.Item(i).Name
                Case "QuantityPerPack_Double"
                    ProductPartsPackingsDataGridView.Columns.Item(i).HeaderText = "Quantity Per Pack"
                    ProductPartsPackingsDataGridView.Columns.Item(i).Width = 80
                    ProductPartsPackingsDataGridView.Columns.Item(i).Visible = True
                Case "UnitOfTheQuantity_ShortText3"
                    ProductPartsPackingsDataGridView.Columns.Item(i).HeaderText = "Quantity Unit"
                    ProductPartsPackingsDataGridView.Columns.Item(i).Width = 80
                    ProductPartsPackingsDataGridView.Columns.Item(i).Visible = True
                Case "UnitOfThePacking_ShortText3"
                    ProductPartsPackingsDataGridView.Columns.Item(i).HeaderText = "Packing Unit"
                    ProductPartsPackingsDataGridView.Columns.Item(i).Width = 80
                    ProductPartsPackingsDataGridView.Columns.Item(i).Visible = True
            End Select

            If ProductPartsPackingsDataGridView.Columns.Item(i).Visible = True Then
                ProductPartsPackingsGroupBox.Width = ProductPartsPackingsGroupBox.Width + ProductPartsPackingsDataGridView.Columns.Item(i).Width
            End If
        Next
        If ProductPartsPackingsGroupBox.Width > VehicleManagementSystemForm.Width Then
            Me.Width = VehicleManagementSystemForm.Width
        Else
            Me.Width = ProductPartsPackingsGroupBox.Width + 60

        End If
        Me.Left = (VehicleManagementSystemForm.Width - Me.Width) / 2
        ProductPartsPackingsGroupBox.Left = (Me.Width - ProductPartsPackingsGroupBox.Width) / 2

    End Sub
    Private Sub ProductPartsPackingsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles ProductPartsPackingsDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If ProductPartsPackingsRecordCount = 0 Then Exit Sub

        CurrentProductPartsPackingsRow = e.RowIndex
        CurrentProductPartsPackingID = ProductPartsPackingsDataGridView.Item("ProductPartsPackingID_AutoNumber", CurrentProductPartsPackingsRow).Value
    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        PurposeOfEntry = "ADD"
        CurrentProductPartsPackingID = -1
        PackingDetailsGroupBox.Visible = True
        QuantityPerPackTextBox.Text = ""
        UnitOfTheQuantityTextBox.Text = ""
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        PurposeOfEntry = "EDIT"
        LoadPackingDetails()
    End Sub
    Private Sub LoadPackingDetails()
        PackingDetailsGroupBox.Visible = True
        QuantityPerPackTextBox.Text = NotNull(ProductPartsPackingsDataGridView.Item("QuantityPerPack_Double", CurrentProductPartsPackingsRow).Value)
        UnitOfTheQuantityTextBox.Text = NotNull(ProductPartsPackingsDataGridView.Item("UnitOfTheQuantity_ShortText3", CurrentProductPartsPackingsRow).Value)
        UnitOfThePackingTextBox.Text = NotNull(ProductPartsPackingsDataGridView.Item("UnitOfThePacking_ShortText3", CurrentProductPartsPackingsRow).Value)
    End Sub
    Private Sub PackingDetailsGroupBox_VisibleChanged(sender As Object, e As EventArgs) Handles PackingDetailsGroupBox.VisibleChanged
        If PackingDetailsGroupBox.Visible = True Then
            SelectToolStripMenuItem.Visible = False
            AddToolStripMenuItem.Visible = False
            EditToolStripMenuItem.Visible = False
            DeleteToolStripMenuItem.Visible = False
            SaveToolStripMenuItem.Visible = True
        Else
            SelectToolStripMenuItem.Visible = True
            AddToolStripMenuItem.Visible = True
            EditToolStripMenuItem.Visible = True
            DeleteToolStripMenuItem.Visible = True
            SaveToolStripMenuItem.Visible = False
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click

    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        SaveChanges()
        PackingDetailsGroupBox.Visible = False
    End Sub
    Private Sub SaveChanges()
        If IsEmpty(QuantityPerPackTextBox.Text) Then
            QuantityPerPackTextBox.Select()
            Exit Sub
        End If
        If IsEmpty(UnitOfTheQuantityTextBox.Text) Then
            UnitOfTheQuantityTextBox.Select()
            Exit Sub
        End If
        If AChangeInProductPartsPackingsOccured() Then
            Dim xxmsgResult = MsgBox("Save Changes?", MsgBoxStyle.YesNoCancel)
            If xxmsgResult = vbNo Then
                PackingDetailsGroupBox.Visible = False
                Exit Sub
            ElseIf xxmsgResult = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            RegisterProductPartsPackingsChanges()
        End If
        FillProductPartsPackingsDataGridView()
    End Sub
    Private Function AChangeInProductPartsPackingsOccured()
        '*******************************************************
        ' CHECK THIS THE TheseAreNotEqual ROUTINE WAS MODIFIED, WATCH PARAMETER pURPOSEOFENTRY
        If CurrentProductPartsPackingID < 1 Then
            Return True
        End If
        If TheseAreNotEqual(QuantityPerPackTextBox.Text, NotNull(ProductPartsPackingsDataGridView.Item("QuantityPerPack_Double", CurrentProductPartsPackingsRow).Value)) Then Return True
        If TheseAreNotEqual(UnitOfTheQuantityTextBox.Text, NotNull(ProductPartsPackingsDataGridView.Item("UnitOfTheQuantity_ShortText3", CurrentProductPartsPackingsRow).Value)) Then Return True
        If TheseAreNotEqual(UnitOfThePackingTextBox.Text, NotNull(ProductPartsPackingsDataGridView.Item("UnitOfThePacking_ShortText3", CurrentProductPartsPackingsRow).Value)) Then Return True
        Return False
    End Function
    Private Sub RegisterProductPartsPackingsChanges()
        MySelection = " Select top 1 * FROM ProductPartsPackingsTable WHERE ProductPartsPackingID_Autonumber = " & CurrentProductPartsPackingID.ToString

        JustExecuteMySelection()
        If RecordCount = 0 Then
            InsertProductPartsPacking()
        Else
            UpdateProductPartsPacking()
        End If
    End Sub
    Private Sub InsertProductPartsPacking()
        MySelection = " Select * from ProductPartsPackingsTable WHERE ProductPartID_LongInteger = " & CurrentProductPartID.ToString &
                                                                    "  AND UnitOfTheQuantity_ShortText3 = " & InQuotes(UnitOfTheQuantityTextBox.Text) &
                                                                    "  AND UnitOfThePacking_ShortText3 = " & InQuotes(UnitOfThePackingTextBox.Text) &
                                                                   "  AND QuantityPerPack_Double = " & QuantityPerPackTextBox.Text
        JustExecuteMySelection()
        If RecordCount > 0 Then
            MsgBox("This packing of this product already exist")
            Exit Sub
        End If
        Dim FieldsToUpdate = "  ProductPartID_LongInteger, " &
                       "  UnitOfTheQuantity_ShortText3, " &
                       "  UnitOfThePacking_ShortText3, " &
                       "  QuantityPerPack_Double "

        Dim FieldsData = CurrentProductPartID.ToString & ",  " &
                         InQuotes(UnitOfTheQuantityTextBox.Text) & ",  " &
                         InQuotes(UnitOfThePackingTextBox.Text) & ",  " &
                        QuantityPerPackTextBox.Text


        CurrentProductPartsPackingID = InsertNewRecord("ProductPartsPackingsTable", FieldsToUpdate, FieldsData)

    End Sub
    Private Sub UpdateProductPartsPacking()
        If MsgBox("About to replace original informations, Continue ?", MsgBoxStyle.YesNo) = vbNo Then
            Exit Sub
        End If
        Dim RecordFilter = " WHERE ProductPartsPackingID_Autonumber = " & CurrentProductPartsPackingID.ToString
        Dim SetCommand = " SET ProductPartID_LongInteger = " & CurrentProductPartID.ToString & "," &
                                      "QuantityPerPack_Double = " & Val(QuantityPerPackTextBox.Text) & "," &
                                      "UnitOfTheQuantity_ShortText3 = " & InQuotes(UnitOfTheQuantityTextBox.Text) & "," &
                                      "UnitOfThePacking_ShortText3 = " & InQuotes(UnitOfThePackingTextBox.Text)

        UpdateTable("ProductPartsPackingsTable", SetCommand, RecordFilter)

        'UPDATE ProductsPartTable AND MARK FIELD Selected true
        UpdateTable("ProductsPartsTable", "SET Selected = True", "WHERE ProductsPartID_AutoNumber = " & CurrentProductPartID.ToString)
    End Sub

End Class