Public Class ProductPartsPackingsForm
    Private ProductPartsPackingsFieldsToSelect = ""
    Private ProductPartsPackingsSelectionFilter = ""
    Private ProductPartsPackingsSelectionOrder = ""
    Private ProductPartsPackingsRecordCount As Integer = -1
    Private ProductPartsPackingsDataGridViewAlreadyFormatted = False
    Private CurrentProductPartsPackingsRow As Integer = -1
    Private CurrentProductsPartsPackingID As Object

    Private CurrentProductPartID = Tunnel2
    Private SavedCallingForm As Form
    Private Sub ProductPartsPackingsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        SavedCallingForm = CallingForm
        MsgBox("in ProductPartsPackingsForm CLEAR ALL PROCEDURES NOT USED")
        MsgBox("code deletion with checking links for 3.12 oz btl")
        FillProductPartsPackingsDataGridView()
    End Sub
    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub
    Private Sub SelectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectToolStripMenuItem.Click
        Tunnel1 = "Tunnel2IsProductPartsPackingID"
        Tunnel2 = CurrentProductsPartsPackingID
        If IsEmpty(ProductPartsPackingsDataGridView.Item("UnitOfTheQuantity_ShortText3", CurrentProductPartsPackingsRow).Value) Then
            Tunnel3 = ProductPartsPackingsDataGridView.Item("UnitOfThePacking_ShortText3", CurrentProductPartsPackingsRow).Value
        Else
            Tunnel3 = ProductPartsPackingsDataGridView.Item("QuantityPerPack_Double", CurrentProductPartsPackingsRow).Value.ToString & Space(1) &
                                      ProductPartsPackingsDataGridView.Item("UnitOfTheQuantity_ShortText3", CurrentProductPartsPackingsRow).Value.ToString &
                                        " / " &
                                      ProductPartsPackingsDataGridView.Item("UnitOfThePacking_ShortText3", CurrentProductPartsPackingsRow).Value.ToString
        End If
        Select Case SavedCallingForm.Name
            Case "ProductPartsPackingRelationsForm"
        End Select
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub
    Private Sub FillProductPartsPackingsDataGridView()
        ProductPartsPackingsSelectionOrder = " ORDER BY QuantityPerPack_Double ASC, UnitOfTheQuantity_ShortText3 ASC, UnitOfThePacking_ShortText3 ASC"
        ProductPartsPackingsFieldsToSelect =
" 
SELECT * FROM ProductPartsPackingsTable "
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
                Case "ManufacturerDescription_ShortText250"
                    ProductPartsPackingsDataGridView.Columns.Item(i).HeaderText = ""
                    ProductPartsPackingsDataGridView.Columns.Item(i).Width = 350
                    ProductPartsPackingsDataGridView.Columns.Item(i).Visible = True
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
        CurrentProductsPartsPackingID = ProductPartsPackingsDataGridView.Item("ProductPartsPackingID_Autonumber", CurrentProductPartsPackingsRow).Value
    End Sub
    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        CurrentProductsPartsPackingID = -1
        PackingDetailsGroupBox.Visible = True
        QuantityPerPackTextBox.Text = ""
        UnitOfTheQuantityTextBox.Text = ""
    End Sub
    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
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
    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        If MsgBox("Are you sure you want to remove this packing for this product ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        MySelection = " DELETE FROM ProductsPartsPackingRelationsTable WHERE ProductsPartsPackingRelationsID_AutoNumber =  " & CurrentProductsPartsPackingID.ToString
        JustExecuteMySelection()
        FillProductPartsPackingsDataGridView()
    End Sub
    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        SaveChanges()
    End Sub
    Private Sub SaveChanges()
        If AChangeInProductPartsPackingsOccured() Then
            If IsEmpty(QuantityPerPackTextBox.Text) Then
                QuantityPerPackTextBox.Select()
                Exit Sub
            End If
            If IsEmpty(UnitOfTheQuantityTextBox.Text) Then
                If QuantityPerPackTextBox.Text <> 1 Then
                    QuantityPerPackTextBox.Select()
                    MsgBox("To make this as the base unit (smallest unit) for this Product QuantityPerPack should be 1, otherwise ")
                    Exit Sub
                End If
            End If
            Dim xxmsgResult = MsgBox("Save Changes?", MsgBoxStyle.YesNoCancel)
            If xxmsgResult = vbNo Then
                PackingDetailsGroupBox.Visible = False
                Exit Sub
            ElseIf xxmsgResult = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            RegisterProductPartsPackingsChanges()
        End If
        PackingDetailsGroupBox.Visible = False
        FillProductPartsPackingsDataGridView()
    End Sub
    Private Function AChangeInProductPartsPackingsOccured()
        '*******************************************************
        ' CHECK THIS THE TheseAreNotEqual ROUTINE WAS MODIFIED, WATCH PARAMETER pURPOSEOFENTRY
        If CurrentProductsPartsPackingID < 1 Then
            Return True
        End If
        If TheseAreNotEqual(QuantityPerPackTextBox.Text, NotNull(ProductPartsPackingsDataGridView.Item("QuantityPerPack_Double", CurrentProductPartsPackingsRow).Value)) Then Return True
        If TheseAreNotEqual(UnitOfTheQuantityTextBox.Text, NotNull(ProductPartsPackingsDataGridView.Item("UnitOfTheQuantity_ShortText3", CurrentProductPartsPackingsRow).Value)) Then Return True
        If TheseAreNotEqual(UnitOfThePackingTextBox.Text, NotNull(ProductPartsPackingsDataGridView.Item("UnitOfThePacking_ShortText3", CurrentProductPartsPackingsRow).Value)) Then Return True
        Return False
    End Function
    Private Sub RegisterProductPartsPackingsChanges()
        'NOTE DO VALIDATION FIRST
        'PACKING IS DIFFERENT FROM PRODUCTPARTPACKING
        MySelection = " Select top 1 * FROM ProductPartsPackingsTable WHERE QuantityPerPack_Double = " & Val(QuantityPerPackTextBox.Text) &
                        " AND UnitOfTheQuantity_ShortText3 = " & InQuotes(UnitOfTheQuantityTextBox.Text) &
                        " AND UnitOfThePacking_ShortText3 = " & InQuotes(UnitOfThePackingTextBox.Text)

        JustExecuteMySelection()
        If RecordCount = 0 Then
            'HERE THE PACKING IS NOT FOUND SO INSERT THE NEW PACKING AND SET THE CURRENT PACKING
            InsertProductPartsPacking()
        Else
            Dim r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
            CurrentProductsPartsPackingID = r("ProductPartsPackingID_Autonumber")
        End If
    End Sub
    Private Sub InsertProductPartsPacking()
        'modify this ProductPartID_LongInteger has been deleted
        MySelection = " Select * from ProductPartsPackingsTable WHERE UnitOfTheQuantity_ShortText3 = " & InQuotes(UnitOfTheQuantityTextBox.Text) &
                                                                    "  AND UnitOfThePacking_ShortText3 = " & InQuotes(UnitOfThePackingTextBox.Text) &
                                                                   "  AND QuantityPerPack_Double = " & QuantityPerPackTextBox.Text
        JustExecuteMySelection()
        If RecordCount > 0 Then
            MsgBox("This packing already exist")
            Exit Sub
        End If
        'modify this ProductPartID_LongInteger has been deleted
        Dim FieldsToUpdate = "  UnitOfTheQuantity_ShortText3, " &
                             "  UnitOfThePacking_ShortText3, " &
                             "  QuantityPerPack_Double "

        Dim FieldsData = InQuotes(UnitOfTheQuantityTextBox.Text) & ",  " &
                         InQuotes(UnitOfThePackingTextBox.Text) & ",  " &
                         QuantityPerPackTextBox.Text


        CurrentProductsPartsPackingID = InsertNewRecord("ProductPartsPackingsTable", FieldsToUpdate, FieldsData)

    End Sub
    Private Sub UpdateProductPartsPackings()
        If MsgBox("About to replace original informations, Continue ?", MsgBoxStyle.YesNo) = vbNo Then
            Exit Sub
        End If
        Dim RecordFilter = " WHERE ProductPartsPackingID_Autonumber = " & CurrentProductsPartsPackingID.ToString
        Dim SetCommand = " SET " &
                            "QuantityPerPack_Double = " & Val(QuantityPerPackTextBox.Text) & "," &
                            "UnitOfTheQuantity_ShortText3 = " & InQuotes(UnitOfTheQuantityTextBox.Text) & "," &
                            "UnitOfThePacking_ShortText3 = " & InQuotes(UnitOfThePackingTextBox.Text)

        UpdateTable("ProductPartsPackingsTable", SetCommand, RecordFilter)
        MsgBox("SET Selected = True FOR this product")
        UpdateTable("ProductsPartsTable", "SET Selected = True", "WHERE ProductsPartID_AutoNumber = " & CurrentProductPartID.ToString)
    End Sub
End Class