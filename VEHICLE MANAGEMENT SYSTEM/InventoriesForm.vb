Public Class InventoriesForm
    Private InventoriesFieldsToSelect = ""
    Private InventoriesSelectionFilter = ""
    Private InventoriesSelectionOrder = ""
    Private CurrentInventoriesRow As Integer = -1
    Private InventoriesRecordCount As Integer = -1
    Private CurrentProductPartID = -1
    Private CurrentInventoriestatus As String
    Private InventoriesDataGridViewAlreadyFormated = False

    Private SavedCallingForm As Form

    Private Sub ReleasedPartForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MsgBox("Set this form and all containers to 12pt pixel")
        SavedCallingForm = CallingForm
        FillInventoriesDataGridView()

    End Sub
    Private Sub FillInventoriesDataGridView()

        InventoriesSelectionOrder = " ORDER BY ReleasedPartID_AutoNumber DESC "
        InventoriesFieldsToSelect = " 
"

        MySelection = InventoriesFieldsToSelect & InventoriesSelectionFilter & InventoriesSelectionOrder

        JustExecuteMySelection()
        InventoriesRecordCount = RecordCount

        If InventoriesRecordCount > 0 Then
            InventoriesGroupBox.Visible = True
        Else
            InventoriesGroupBox.Visible = False
        End If
        InventoriesDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If InventoriesRecordCount = 0 Then
            CurrentProductPartID = -1
        End If


        ' HERE AT ROW_ENTER, FillReleasedPartConcernsDataGridView is called and ReleasedPartConcernsbOX IS ALREADY FORMATTED
        If Not InventoriesDataGridViewAlreadyFormated Then
            FormatInventoriesDataGridView()
            SetFormWidthAndGroupBoxLeft(Me,
                                            MyStandardsFormMenuStrip,
                                            InventoriesGroupBox,
                                            InventoriesGroupBox,
                                            InventoriesGroupBox,
                                            InventoriesGroupBox)
        End If

        SetGroupBoxHeight(5, InventoriesRecordCount, InventoriesGroupBox, InventoriesDataGridView)
        Me.Top = VehicleManagementSystemForm.VehicleManagementMenuStrip.Top + VehicleManagementSystemForm.VehicleManagementMenuStrip.Height + 20
        Me.Left = VehicleManagementSystemForm.Left
        Me.Height = VehicleManagementSystemForm.Height - Me.Top

    End Sub
    Private Sub FormatInventoriesDataGridView()
        InventoriesDataGridViewAlreadyFormated = True
        InventoriesGroupBox.Width = 0
        For i = 0 To InventoriesDataGridView.Columns.GetColumnCount(0) - 1

            InventoriesDataGridView.Columns.Item(i).Visible = False
            Select Case InventoriesDataGridView.Columns.Item(i).Name
                Case "Selected"
                    InventoriesDataGridView.Columns.Item(i).HeaderText = "*"
                    InventoriesDataGridView.Columns.Item(i).Width = 20
                    InventoriesDataGridView.Columns.Item(i).Visible = True
                Case "MasterCodeBookID_LongInteger"
                    InventoriesDataGridView.Columns.Item(i).HeaderText = "CodeBookID"
                    InventoriesDataGridView.Columns.Item(i).Width = 80
                    InventoriesDataGridView.Columns.Item(i).Visible = True
                Case "ProductPartID_LongInteger"
                    InventoriesDataGridView.Columns.Item(i).HeaderText = "linked as"
                    InventoriesDataGridView.Columns.Item(i).Width = 80
                    InventoriesDataGridView.Columns.Item(i).Visible = True
                Case "SystemDesc_ShortText100Fld"
                    InventoriesDataGridView.Columns.Item(i).HeaderText = "Part Desc"
                    InventoriesDataGridView.Columns.Item(i).Width = 300
                    InventoriesDataGridView.Columns.Item(i).Visible = True
                Case "PartSpecifications_ShortText255"
                    InventoriesDataGridView.Columns.Item(i).HeaderText = "Specification"
                    InventoriesDataGridView.Columns.Item(i).Width = 150
                    InventoriesDataGridView.Columns.Item(i).Visible = True
                Case "ManufacturerPartNo_ShortText30Fld"
                    InventoriesDataGridView.Columns.Item(i).HeaderText = "Manufacturer PN"
                    InventoriesDataGridView.Columns.Item(i).Width = 150
                    InventoriesDataGridView.Columns.Item(i).Visible = True
                Case "ManufacturerDescription_ShortText250"
                    InventoriesDataGridView.Columns.Item(i).HeaderText = "Manufacturer Desc"
                    InventoriesDataGridView.Columns.Item(i).Width = 400
                    InventoriesDataGridView.Columns.Item(i).Visible = True
                Case "QuantityInStock_Double"
                    InventoriesDataGridView.Columns.Item(i).HeaderText = "Qty in Stock"
                    InventoriesDataGridView.Columns.Item(i).Width = 70
                    InventoriesDataGridView.Columns.Item(i).Visible = True
                Case "Unit_ShortText3"
                    InventoriesDataGridView.Columns.Item(i).HeaderText = "Unit"
                    InventoriesDataGridView.Columns.Item(i).Width = 70
                    InventoriesDataGridView.Columns.Item(i).Visible = True
                Case "BrandName_ShortText20"
                    InventoriesDataGridView.Columns.Item(i).HeaderText = "Brand"
                    InventoriesDataGridView.Columns.Item(i).Width = 150
                    InventoriesDataGridView.Columns.Item(i).Visible = True
                Case "MinimumQuantity_Double"
                    InventoriesDataGridView.Columns.Item(i).HeaderText = "Minimun Qty"
                    InventoriesDataGridView.Columns.Item(i).Width = 70
                    InventoriesDataGridView.Columns.Item(i).Visible = True
                Case "Location_ShortText10"
                    InventoriesDataGridView.Columns.Item(i).HeaderText = "Location"
                    InventoriesDataGridView.Columns.Item(i).Width = 70
                    InventoriesDataGridView.Columns.Item(i).Visible = True
                Case "ProductDescription_ShortText250"
                    InventoriesDataGridView.Columns.Item(i).HeaderText = "excel Desc"
                    InventoriesDataGridView.Columns.Item(i).Width = 400
                    InventoriesDataGridView.Columns.Item(i).Visible = True
                Case "VehicleRepairClassID_LongInteger"
                    InventoriesDataGridView.Columns.Item(i).HeaderText = "RepairClassID"
                    InventoriesDataGridView.Columns.Item(i).Width = 70
                    InventoriesDataGridView.Columns.Item(i).Visible = True
                Case "VehicleDescription"
                    InventoriesDataGridView.Columns.Item(i).HeaderText = "Vehicle model"
                    InventoriesDataGridView.Columns.Item(i).Width = 180
                    InventoriesDataGridView.Columns.Item(i).Visible = True
                Case "QuantityPerPack_Double"
                    InventoriesDataGridView.Columns.Item(i).HeaderText = "QtyPerPack"
                    InventoriesDataGridView.Columns.Item(i).Width = 70
                    InventoriesDataGridView.Columns.Item(i).Visible = True
                Case "UnitOfTheQuantity_ShortText3"
                    InventoriesDataGridView.Columns.Item(i).HeaderText = "UnitOfTheQuantity"
                    InventoriesDataGridView.Columns.Item(i).Width = 70
                    InventoriesDataGridView.Columns.Item(i).Visible = True
            End Select

            If InventoriesDataGridView.Columns.Item(i).Visible = True Then
                InventoriesDataGridView.Width = InventoriesDataGridView.Width + InventoriesDataGridView.Columns.Item(i).Width
            End If
        Next
        If InventoriesGroupBox.Width > VehicleManagementSystemForm.Width Then
            InventoriesGroupBox.Width = VehicleManagementSystemForm.Width - 4
        Else
            HorizontalCenter(InventoriesGroupBox, Me)
        End If
    End Sub
    Private Sub InventoriesDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles InventoriesDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If InventoriesRecordCount = 0 Then Exit Sub

        CurrentInventoriesRow = e.RowIndex
        CurrentProductPartID = InventoriesDataGridView.Item("ReleasedPartID_AutoNumber", CurrentInventoriesRow).Value

        FillField(CurrentInventoriestatus, InventoriesDataGridView.Item("Inventoriestatus", CurrentInventoriesRow).Value)

        Select Case CurrentInventoriestatus
            Case "Assigned"
        End Select

    End Sub

    Private Sub ReturnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnToolStripMenuItem.Click
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub

End Class