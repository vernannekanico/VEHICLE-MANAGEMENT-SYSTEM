Public Class ProductPartsPackingRelationsForm
    Private ProductPartsPackingRelationsFieldsToSelect = ""
    Private ProductPartsPackingRelationsSelectionFilter = ""
    Private ProductPartsPackingRelationsSelectionOrder = ""
    Private ProductPartsPackingRelationsRecordCount As Integer = -1
    Private ProductPartsPackingRelationsDataGridViewAlreadyFormatted = False
    Private CurrentProductPartsPackingRelationsRow As Integer = -1
    Private CurrentProductsPartsPackingRelationID = -1
    Private CurrentProductPartsPackingID = -1

    Private CurrentProductPartID = Tunnel2
    Private SavedCallingForm As Form
    Private Sub ProductPartsPackingRelationsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Upon entry if requesting for a relation id, calling program should provide Product Id in tunnel 1
        SavedCallingForm = CallingForm
        MsgBox("CLEAR ALL PROCEDURES Not USED")
        If IsEmpty(Tunnel2) Then
            MsgBox("if requesting for a relation id, calling program should provide Product Id in tunnel 1" & vbCrLf &
                      "and the Product description in tunnel 3 ", MsgBoxStyle.YesNo)
            Exit Sub
        End If
        CurrentProductPartID = Tunnel2
        Me.Text = Tunnel3
        ProductPartsPackingRelationsSelectionFilter = " WHERE ProductPartID_LongInteger = " & CurrentProductPartID.ToString
        FillProductPartsPackingRelationsDataGridView()
    End Sub
    Private Sub ProductPartsPackingRelationsForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        If Me.Enabled = False Then Exit Sub
        CallingForm = SavedCallingForm

        ' GET RETURNED DATA HERE

        Select Case Tunnel1
            Case "Tunnel2IsProductPartsPackingID"
                If MsgBox("Continue adding this in the packing list ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                CurrentProductPartsPackingID = Tunnel2
                InsertProductPartsPackingRelation()
        End Select
        FillProductPartsPackingRelationsDataGridView()
    End Sub
    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub
    Private Sub SelectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectToolStripMenuItem.Click
        If ProductPartsPackingRelationsRecordCount = 0 Then Exit Sub
        Tunnel1 = "Tunnel2IsProductsPartsPackingRelationID"
        Tunnel2 = CurrentProductsPartsPackingRelationID
        If CurrentProductPartsPackingRelationsRow = -1 Then 'for some reasons after adding CurrentProductPartsPackingRelationsRow
            ' does not trigger rowenter
            If ProductPartsPackingRelationsRecordCount = 1 Then
                CurrentProductPartsPackingRelationsRow = 0
            End If
        End If
        Tunnel3 = ProductPartsPackingRelationsDataGridView.Item("Packing", CurrentProductPartsPackingRelationsRow).Value.ToString
        Tunnel4 = ProductPartsPackingRelationsDataGridView.Item("UnitOfThePacking_ShortText3", CurrentProductPartsPackingRelationsRow).Value
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub
    Private Sub FillProductPartsPackingRelationsDataGridView()

        ProductPartsPackingRelationsFieldsToSelect =
" 
SELECT 
ProductsPartsPackingRelationsTable.ProductsPartsPackingRelationID_AutoNumber, 
ProductsPartsPackingRelationsTable.ProductPartID_LongInteger, 
Packings.QuantityPerPack_Double, 
Packings.UnitOfTheQuantity_ShortText3, 
Packings.UnitOfThePacking_ShortText3, 
Packings.Packing
FROM ProductsPartsPackingRelationsTable LEFT JOIN Packings ON ProductsPartsPackingRelationsTable.ProductsPartsPackingRelationID_AutoNumber = Packings.ProductsPartsPackingRelationID_AutoNumber"


        MySelection = ProductPartsPackingRelationsFieldsToSelect & ProductPartsPackingRelationsSelectionFilter & ProductPartsPackingRelationsSelectionOrder

        JustExecuteMySelection()
        ProductPartsPackingRelationsRecordCount = RecordCount

        ProductPartsPackingRelationsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable



        If Not ProductPartsPackingRelationsDataGridViewAlreadyFormatted Then
            FormatProductPartsPackingRelationsDataGridView()
        End If

        Dim RecordsToDisplay = 24
        SetGroupBoxHeight(RecordsToDisplay, ProductPartsPackingRelationsRecordCount, ProductPartsPackingRelationsGroupBox, ProductPartsPackingRelationsDataGridView)
        ProductPartsPackingRelationsGroupBox.Top = ProductsPartsPackingMenuStrip.Top + ProductsPartsPackingMenuStrip.Height
        Me.Height = ProductPartsPackingRelationsGroupBox.Top + ProductPartsPackingRelationsGroupBox.Height + 50

        Me.Top = (VehicleManagementSystemForm.Height - Me.Height) / 2
    End Sub
    Private Sub FormatProductPartsPackingRelationsDataGridView()
        ProductPartsPackingRelationsDataGridViewAlreadyFormatted = True
        ProductPartsPackingRelationsGroupBox.Width = 0

        For i = 0 To ProductPartsPackingRelationsDataGridView.Columns.GetColumnCount(0) - 1

            ProductPartsPackingRelationsDataGridView.Columns.Item(i).Visible = False
            Select Case ProductPartsPackingRelationsDataGridView.Columns.Item(i).Name
                Case "ManufacturerDescription_ShortText250"
                    ProductPartsPackingRelationsDataGridView.Columns.Item(i).HeaderText = ""
                    ProductPartsPackingRelationsDataGridView.Columns.Item(i).Width = 350
                    ProductPartsPackingRelationsDataGridView.Columns.Item(i).Visible = True
                Case "QuantityPerPack_Double"
                    ProductPartsPackingRelationsDataGridView.Columns.Item(i).HeaderText = "Quantity Per Pack"
                    ProductPartsPackingRelationsDataGridView.Columns.Item(i).Width = 120
                    ProductPartsPackingRelationsDataGridView.Columns.Item(i).Visible = True
                Case "UnitOfTheQuantity_ShortText3"
                    ProductPartsPackingRelationsDataGridView.Columns.Item(i).HeaderText = "Quantity Unit"
                    ProductPartsPackingRelationsDataGridView.Columns.Item(i).Width = 120
                    ProductPartsPackingRelationsDataGridView.Columns.Item(i).Visible = True
                Case "UnitOfThePacking_ShortText3"
                    ProductPartsPackingRelationsDataGridView.Columns.Item(i).HeaderText = "Packing Unit"
                    ProductPartsPackingRelationsDataGridView.Columns.Item(i).Width = 120
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
        CurrentProductsPartsPackingRelationID = ProductPartsPackingRelationsDataGridView.Item("ProductsPartsPackingRelationID_AutoNumber", CurrentProductPartsPackingRelationsRow).Value
    End Sub
    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        ShowCalledForm(Me, ProductPartsPackingsForm)
    End Sub
    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        If MsgBox("Are you sure you want to remove this packing for this product ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        MySelection = " DELETE FROM ProductsPartsPackingRelationsTable WHERE ProductsPartsPackingRelationID_AutoNumber =  " & CurrentProductsPartsPackingRelationID.ToString
        JustExecuteMySelection()
        FillProductPartsPackingRelationsDataGridView()
    End Sub
    Private Sub InsertProductPartsPackingRelation()
        Dim FieldsToUpdate = "  ProductPartID_LongInteger, " &
                             "  ProductPartsPackingID_LongInteger "

        Dim FieldsData = CurrentProductPartID.ToString & ",  " &
                         CurrentProductPartsPackingID.ToString

        CurrentProductsPartsPackingRelationID = InsertNewRecord("ProductsPartsPackingRelationsTable", FieldsToUpdate, FieldsData)
        FillProductPartsPackingRelationsDataGridView()
    End Sub

End Class