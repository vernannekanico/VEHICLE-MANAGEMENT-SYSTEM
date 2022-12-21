Public Class ProductPartsPackingsForm
    Private ProductPartsPackingRelationsFieldsToSelect = ""
    Private ProductPartsPackingRelationsSelectionFilter = ""
    Private ProductPartsPackingRelationsSelectionOrder = ""
    Private ProductPartsPackingRelationsRecordCount As Integer = -1
    Private ProductPartsPackingRelationsDataGridViewAlreadyFormatted = False
    Private CurrentProductPartsPackingRelationsRow As Integer = -1
    Private CurrentProductsPartsPackingRelationsID = -1
    Private PurposeOfEntry = ""

    Private CurrentProductPartID = Tunnel2
    Private SavedCallingForm As Form
    Private Sub ProductPartsPackingRelationsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        SavedCallingForm = CallingForm
        If Tunnel1 = "Tunnel2IsProductPartID" Then
            CurrentProductPartID = Tunnel2
            ProductPartsPackingRelationsSelectionFilter = " WHERE ProductPartID_LongInteger = " & CurrentProductPartID.ToString
        End If
        FillProductPartsPackingRelationsDataGridView()
    End Sub
    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub
    Private Sub SelectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectToolStripMenuItem.Click
        Tunnel1 = "Tunnel2IsProductPartsPackingID"
        Tunnel2 = CurrentProductsPartsPackingRelationsID
        Tunnel3 = ProductPartsPackingRelationsDataGridView.Item("QuantityPerPack_Double", CurrentProductPartsPackingRelationsRow).Value.ToString & Space(1) &
                                      ProductPartsPackingRelationsDataGridView.Item("UnitOfTheQuantity_ShortText3", CurrentProductPartsPackingRelationsRow).Value.ToString &
                                        " / " &
                                      ProductPartsPackingRelationsDataGridView.Item("UnitOfThePacking_ShortText3", CurrentProductPartsPackingRelationsRow).Value.ToString
        Select Case SavedCallingForm.Name
            Case "ProductsPartsForm"
                ProductsPartsForm.UnitTextBox.Text = ProductPartsPackingRelationsDataGridView.Item("UnitOfThePacking_ShortText3", CurrentProductPartsPackingRelationsRow).Value
                ProductsPartsForm.PackingTextBox.Text = Tunnel3
        End Select
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub
    Private Sub FillProductPartsPackingRelationsDataGridView()

        ProductPartsPackingRelationsFieldsToSelect =
" 
SELECT * FROM ProductsPartsPackingRelationsTable
"


        MySelection = ProductPartsPackingRelationsFieldsToSelect & ProductPartsPackingRelationsSelectionFilter & ProductPartsPackingRelationsSelectionOrder

        JustExecuteMySelection()
        ProductPartsPackingRelationsRecordCount = RecordCount

        ProductPartsPackingRelationsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable



        If Not ProductPartsPackingRelationsDataGridViewAlreadyFormatted Then
            FormatProductPartsPackingRelationsDataGridView()
        End If

        Dim RecordsToDisplay = 20
        SetGroupBoxHeight(RecordsToDisplay, ProductPartsPackingRelationsRecordCount, ProductPartsPackingRelationsGroupBox, ProductPartsPackingRelationsDataGridView)
        ProductPartsPackingRelationsGroupBox.Top = ProductsPartsPackingMenuStrip.Top + ProductsPartsPackingMenuStrip.Height
        PackingDetailsGroupBox.Top = ProductPartsPackingRelationsGroupBox.Top + ProductPartsPackingRelationsGroupBox.Height
        Me.Height = ProductPartsPackingRelationsGroupBox.Top + ProductPartsPackingRelationsGroupBox.Height + PackingDetailsGroupBox.Height + 50
        PackingDetailsGroupBox.Left = (Me.Width - PackingDetailsGroupBox.Width) / 2

        Me.Top = (VehicleManagementSystemForm.Height - Me.Height) / 2
    End Sub
    Private Sub FormatProductPartsPackingRelationsDataGridView()
        ProductPartsPackingRelationsDataGridViewAlreadyFormatted = True
        ProductPartsPackingRelationsGroupBox.Width = 0

        For i = 0 To ProductPartsPackingRelationsDataGridView.Columns.GetColumnCount(0) - 1

            ProductPartsPackingRelationsDataGridView.Columns.Item(i).Visible = False
            Select Case ProductPartsPackingRelationsDataGridView.Columns.Item(i).Name
                Case "QuantityPerPack_Double"
                    ProductPartsPackingRelationsDataGridView.Columns.Item(i).HeaderText = "Quantity Per Pack"
                    ProductPartsPackingRelationsDataGridView.Columns.Item(i).Width = 80
                    ProductPartsPackingRelationsDataGridView.Columns.Item(i).Visible = True
                Case "UnitOfTheQuantity_ShortText3"
                    ProductPartsPackingRelationsDataGridView.Columns.Item(i).HeaderText = "Quantity Unit"
                    ProductPartsPackingRelationsDataGridView.Columns.Item(i).Width = 80
                    ProductPartsPackingRelationsDataGridView.Columns.Item(i).Visible = True
                Case "UnitOfThePacking_ShortText3"
                    ProductPartsPackingRelationsDataGridView.Columns.Item(i).HeaderText = "Packing Unit"
                    ProductPartsPackingRelationsDataGridView.Columns.Item(i).Width = 80
                    ProductPartsPackingRelationsDataGridView.Columns.Item(i).Visible = True
            End Select

            If ProductPartsPackingRelationsDataGridView.Columns.Item(i).Visible = True Then
                ProductPartsPackingRelationsGroupBox.Width = ProductPartsPackingRelationsGroupBox.Width + ProductPartsPackingRelationsDataGridView.Columns.Item(i).Width
            End If
        Next
        If ProductPartsPackingRelationsGroupBox.Width > VehicleManagementSystemForm.Width Then
            Me.Width = VehicleManagementSystemForm.Width
        Else
            Me.Width = ProductPartsPackingRelationsGroupBox.Width + 60

        End If
        Me.Left = (VehicleManagementSystemForm.Width - Me.Width) / 2
        ProductPartsPackingRelationsGroupBox.Left = (Me.Width - ProductPartsPackingRelationsGroupBox.Width) / 2

    End Sub
    Private Sub ProductPartsPackingRelationsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles ProductPartsPackingRelationsDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If ProductPartsPackingRelationsRecordCount = 0 Then Exit Sub

        CurrentProductPartsPackingRelationsRow = e.RowIndex
        CurrentProductsPartsPackingRelationsID = ProductPartsPackingRelationsDataGridView.Item("ProductsPartsPackingRelationsID_AutoNumber", CurrentProductPartsPackingRelationsRow).Value
    End Sub
    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        PurposeOfEntry = "ADD"
        CurrentProductsPartsPackingRelationsID = -1
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
        QuantityPerPackTextBox.Text = NotNull(ProductPartsPackingRelationsDataGridView.Item("QuantityPerPack_Double", CurrentProductPartsPackingRelationsRow).Value)
        UnitOfTheQuantityTextBox.Text = NotNull(ProductPartsPackingRelationsDataGridView.Item("UnitOfTheQuantity_ShortText3", CurrentProductPartsPackingRelationsRow).Value)
        UnitOfThePackingTextBox.Text = NotNull(ProductPartsPackingRelationsDataGridView.Item("UnitOfThePacking_ShortText3", CurrentProductPartsPackingRelationsRow).Value)
    End Sub
    Private Sub PackingDetailsGroupBox_VisibleChanged(sender As Object, e As EventArgs) Handles PackingDetailsGroupBox.VisibleChanged
        If PackingDetailsGroupBox.Visible = True Then
            SelectToolStripMenuItem.Visible = False
            AddToolStripMenuItem.Visible = False
            EditToolStripMenuItem.Visible = False
            RemoveToolStripMenuItem.Visible = False
            SaveToolStripMenuItem.Visible = True
        Else
            SelectToolStripMenuItem.Visible = True
            AddToolStripMenuItem.Visible = True
            EditToolStripMenuItem.Visible = True
            RemoveToolStripMenuItem.Visible = True
            SaveToolStripMenuItem.Visible = False
        End If
    End Sub
    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click

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
        If AChangeInProductPartsPackingRelationsOccured() Then
            Dim xxmsgResult = MsgBox("Save Changes?", MsgBoxStyle.YesNoCancel)
            If xxmsgResult = vbNo Then
                PackingDetailsGroupBox.Visible = False
                Exit Sub
            ElseIf xxmsgResult = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            RegisterProductPartsPackingRelationsChanges()
        End If
        FillProductPartsPackingRelationsDataGridView()
    End Sub
    Private Function AChangeInProductPartsPackingRelationsOccured()
        '*******************************************************
        ' CHECK THIS THE TheseAreNotEqual ROUTINE WAS MODIFIED, WATCH PARAMETER pURPOSEOFENTRY
        If CurrentProductsPartsPackingRelationsID < 1 Then
            Return True
        End If
        If TheseAreNotEqual(QuantityPerPackTextBox.Text, NotNull(ProductPartsPackingRelationsDataGridView.Item("QuantityPerPack_Double", CurrentProductPartsPackingRelationsRow).Value)) Then Return True
        If TheseAreNotEqual(UnitOfTheQuantityTextBox.Text, NotNull(ProductPartsPackingRelationsDataGridView.Item("UnitOfTheQuantity_ShortText3", CurrentProductPartsPackingRelationsRow).Value)) Then Return True
        If TheseAreNotEqual(UnitOfThePackingTextBox.Text, NotNull(ProductPartsPackingRelationsDataGridView.Item("UnitOfThePacking_ShortText3", CurrentProductPartsPackingRelationsRow).Value)) Then Return True
        Return False
    End Function
    Private Sub RegisterProductPartsPackingRelationsChanges()
        'NOTE DO VALIDATION FIRST
        'PACKING IS DIFFERENT FROM PRODUCTPARTPACKING
        MySelection = " Select top 1 * FROM ProductPartsPackingRelationsTable WHERE QuantityPerPack_Double = " & Val(QuantityPerPackTextBox.Text) &
                        " AND UnitOfTheQuantity_ShortText3 = " & InQuotes(UnitOfTheQuantityTextBox.Text) &
                        " AND UnitOfThePacking_ShortText3 = " & InQuotes(UnitOfThePackingTextBox.Text)

        JustExecuteMySelection()
        If RecordCount = 0 Then
            'HERE THE PACKING IS NOT FOUND SO INSERT THE NEW PACKING AND SET THE CURRENT PACKING
            InsertProductPartsPacking()
        Else
            Dim r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
            CurrentProductsPartsPackingRelationsID = r("ProductPartsPackingRelationID_Autonumber")
        End If
        'NOTE IF THE IS A LINK IN THE ProductsPartsPackingRelationsTable THEN YOU CAN NOT UPDATE

        UpdateProductPartsPackingRelations()
    End Sub
    Private Sub InsertProductPartsPacking()
        'modify this ProductPartID_LongInteger has been deleted
        MySelection = " Select * from ProductPartsPackingRelationsTable WHERE UnitOfTheQuantity_ShortText3 = " & InQuotes(UnitOfTheQuantityTextBox.Text) &
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


        CurrentProductsPartsPackingRelationsID = InsertNewRecord("ProductPartsPackingRelationsTable", FieldsToUpdate, FieldsData)

    End Sub
    Private Sub UpdateProductPartsPackingRelations()
        If MsgBox("About to replace original informations, Continue ?", MsgBoxStyle.YesNo) = vbNo Then
            Exit Sub
        End If
        Dim RecordFilter = " WHERE ProductPartsPackingID_Autonumber = " & CurrentProductsPartsPackingRelationsID.ToString
        Dim SetCommand = " SET " &
                            "QuantityPerPack_Double = " & Val(QuantityPerPackTextBox.Text) & "," &
                            "UnitOfTheQuantity_ShortText3 = " & InQuotes(UnitOfTheQuantityTextBox.Text) & "," &
                            "UnitOfThePacking_ShortText3 = " & InQuotes(UnitOfThePackingTextBox.Text)

        UpdateTable("ProductPartsPackingRelationsTable", SetCommand, RecordFilter)

        'UPDATE ProductsPartTable AND MARK FIELD Selected true
        UpdateTable("ProductsPartsTable", "SET Selected = True", "WHERE ProductsPartID_AutoNumber = " & CurrentProductPartID.ToString)
    End Sub
End Class