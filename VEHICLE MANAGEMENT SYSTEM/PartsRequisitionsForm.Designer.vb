<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PartsRequisitionsForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.RequisitionItemDetailsGroupBox = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PcsPerPackTextBox = New System.Windows.Forms.TextBox()
        Me.PackingLabel = New System.Windows.Forms.Label()
        Me.POItemProductPartNoTextBox = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.RequisitionItemProductDescTextBox = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.EXITSAVEChangesButton = New System.Windows.Forms.Button()
        Me.POItemQuantityTextBox = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.POItemUnitTextBox = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.POItemPriceTextBox = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.PartsRequisitionsGroupBox = New System.Windows.Forms.GroupBox()
        Me.PartsRequisitionsDataGridView = New System.Windows.Forms.DataGridView()
        Me.PartsRequisitionsItemsGroupBox = New System.Windows.Forms.GroupBox()
        Me.PartsRequisitionsItemsDataGridView = New System.Windows.Forms.DataGridView()
        Me.WorkOrderPartsMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.ReturnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RequisitionDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OutstandingRequisitionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PartiallyOrderedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReorderedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CompletlyOrderedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllRequisitionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintRequisitionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteRequisitionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PurchasersMenuToolStripMenus = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreatePurchaseOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StoreKeepersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddPurchaseOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditPurchaseOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeletePurchaseOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SavePurchaseOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RequisitionItemDetailsGroupBox.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.PartsRequisitionsGroupBox.SuspendLayout()
        CType(Me.PartsRequisitionsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PartsRequisitionsItemsGroupBox.SuspendLayout()
        CType(Me.PartsRequisitionsItemsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.WorkOrderPartsMenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'RequisitionItemDetailsGroupBox
        '
        Me.RequisitionItemDetailsGroupBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RequisitionItemDetailsGroupBox.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.RequisitionItemDetailsGroupBox.Controls.Add(Me.GroupBox1)
        Me.RequisitionItemDetailsGroupBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RequisitionItemDetailsGroupBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.RequisitionItemDetailsGroupBox.Location = New System.Drawing.Point(502, 250)
        Me.RequisitionItemDetailsGroupBox.Name = "RequisitionItemDetailsGroupBox"
        Me.RequisitionItemDetailsGroupBox.Size = New System.Drawing.Size(734, 245)
        Me.RequisitionItemDetailsGroupBox.TabIndex = 123
        Me.RequisitionItemDetailsGroupBox.TabStop = False
        Me.RequisitionItemDetailsGroupBox.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.PcsPerPackTextBox)
        Me.GroupBox1.Controls.Add(Me.PackingLabel)
        Me.GroupBox1.Controls.Add(Me.POItemProductPartNoTextBox)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.RequisitionItemProductDescTextBox)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.EXITSAVEChangesButton)
        Me.GroupBox1.Controls.Add(Me.POItemQuantityTextBox)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.POItemUnitTextBox)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.POItemPriceTextBox)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(701, 205)
        Me.GroupBox1.TabIndex = 89
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "PURCHASE ORDER ITEM Details"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(317, 107)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 20)
        Me.Label8.TabIndex = 103
        Me.Label8.Text = "Packing"
        Me.Label8.Visible = False
        '
        'PcsPerPackTextBox
        '
        Me.PcsPerPackTextBox.Location = New System.Drawing.Point(278, 101)
        Me.PcsPerPackTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PcsPerPackTextBox.Name = "PcsPerPackTextBox"
        Me.PcsPerPackTextBox.Size = New System.Drawing.Size(38, 26)
        Me.PcsPerPackTextBox.TabIndex = 102
        Me.PcsPerPackTextBox.Visible = False
        '
        'PackingLabel
        '
        Me.PackingLabel.AutoSize = True
        Me.PackingLabel.Location = New System.Drawing.Point(197, 104)
        Me.PackingLabel.Name = "PackingLabel"
        Me.PackingLabel.Size = New System.Drawing.Size(65, 20)
        Me.PackingLabel.TabIndex = 101
        Me.PackingLabel.Text = "Packing"
        Me.PackingLabel.Visible = False
        '
        'POItemProductPartNoTextBox
        '
        Me.POItemProductPartNoTextBox.Location = New System.Drawing.Point(106, 63)
        Me.POItemProductPartNoTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.POItemProductPartNoTextBox.Name = "POItemProductPartNoTextBox"
        Me.POItemProductPartNoTextBox.Size = New System.Drawing.Size(585, 26)
        Me.POItemProductPartNoTextBox.TabIndex = 100
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(25, 66)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(51, 20)
        Me.Label20.TabIndex = 99
        Me.Label20.Text = "Part #"
        '
        'RequisitionItemProductDescTextBox
        '
        Me.RequisitionItemProductDescTextBox.Location = New System.Drawing.Point(106, 27)
        Me.RequisitionItemProductDescTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RequisitionItemProductDescTextBox.Name = "RequisitionItemProductDescTextBox"
        Me.RequisitionItemProductDescTextBox.Size = New System.Drawing.Size(585, 26)
        Me.RequisitionItemProductDescTextBox.TabIndex = 98
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(25, 30)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(64, 20)
        Me.Label19.TabIndex = 97
        Me.Label19.Text = "Product"
        '
        'EXITSAVEChangesButton
        '
        Me.EXITSAVEChangesButton.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.EXITSAVEChangesButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EXITSAVEChangesButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.EXITSAVEChangesButton.Location = New System.Drawing.Point(176, 98)
        Me.EXITSAVEChangesButton.Name = "EXITSAVEChangesButton"
        Me.EXITSAVEChangesButton.Size = New System.Drawing.Size(515, 98)
        Me.EXITSAVEChangesButton.TabIndex = 96
        Me.EXITSAVEChangesButton.Text = "EXIT / SAVE Changes"
        Me.EXITSAVEChangesButton.UseVisualStyleBackColor = False
        '
        'POItemQuantityTextBox
        '
        Me.POItemQuantityTextBox.Location = New System.Drawing.Point(106, 98)
        Me.POItemQuantityTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.POItemQuantityTextBox.Name = "POItemQuantityTextBox"
        Me.POItemQuantityTextBox.Size = New System.Drawing.Size(53, 26)
        Me.POItemQuantityTextBox.TabIndex = 95
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(29, 132)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 20)
        Me.Label6.TabIndex = 94
        Me.Label6.Text = "Unit"
        '
        'POItemUnitTextBox
        '
        Me.POItemUnitTextBox.Location = New System.Drawing.Point(106, 134)
        Me.POItemUnitTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.POItemUnitTextBox.Name = "POItemUnitTextBox"
        Me.POItemUnitTextBox.Size = New System.Drawing.Size(53, 26)
        Me.POItemUnitTextBox.TabIndex = 93
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(27, 170)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 20)
        Me.Label7.TabIndex = 92
        Me.Label7.Text = "Price"
        '
        'POItemPriceTextBox
        '
        Me.POItemPriceTextBox.Location = New System.Drawing.Point(106, 170)
        Me.POItemPriceTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.POItemPriceTextBox.Name = "POItemPriceTextBox"
        Me.POItemPriceTextBox.Size = New System.Drawing.Size(53, 26)
        Me.POItemPriceTextBox.TabIndex = 91
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(25, 101)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(68, 20)
        Me.Label16.TabIndex = 90
        Me.Label16.Text = "Quantity"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(-65, 35)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 20)
        Me.Label5.TabIndex = 89
        Me.Label5.Text = "Unit"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(-67, 73)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(44, 20)
        Me.Label21.TabIndex = 87
        Me.Label21.Text = "Price"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(-69, 4)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(68, 20)
        Me.Label22.TabIndex = 85
        Me.Label22.Text = "Quantity"
        '
        'PartsRequisitionsGroupBox
        '
        Me.PartsRequisitionsGroupBox.Controls.Add(Me.PartsRequisitionsDataGridView)
        Me.PartsRequisitionsGroupBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PartsRequisitionsGroupBox.Location = New System.Drawing.Point(25, 70)
        Me.PartsRequisitionsGroupBox.Name = "PartsRequisitionsGroupBox"
        Me.PartsRequisitionsGroupBox.Size = New System.Drawing.Size(367, 260)
        Me.PartsRequisitionsGroupBox.TabIndex = 122
        Me.PartsRequisitionsGroupBox.TabStop = False
        Me.PartsRequisitionsGroupBox.Text = "Requisitions"
        '
        'PartsRequisitionsDataGridView
        '
        Me.PartsRequisitionsDataGridView.AllowUserToAddRows = False
        Me.PartsRequisitionsDataGridView.AllowUserToDeleteRows = False
        Me.PartsRequisitionsDataGridView.AllowUserToOrderColumns = True
        Me.PartsRequisitionsDataGridView.AllowUserToResizeRows = False
        Me.PartsRequisitionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.PartsRequisitionsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PartsRequisitionsDataGridView.Location = New System.Drawing.Point(3, 22)
        Me.PartsRequisitionsDataGridView.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PartsRequisitionsDataGridView.MultiSelect = False
        Me.PartsRequisitionsDataGridView.Name = "PartsRequisitionsDataGridView"
        Me.PartsRequisitionsDataGridView.ReadOnly = True
        Me.PartsRequisitionsDataGridView.RowHeadersVisible = False
        Me.PartsRequisitionsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.PartsRequisitionsDataGridView.Size = New System.Drawing.Size(361, 235)
        Me.PartsRequisitionsDataGridView.TabIndex = 52
        '
        'PartsRequisitionsItemsGroupBox
        '
        Me.PartsRequisitionsItemsGroupBox.Controls.Add(Me.PartsRequisitionsItemsDataGridView)
        Me.PartsRequisitionsItemsGroupBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PartsRequisitionsItemsGroupBox.Location = New System.Drawing.Point(449, 83)
        Me.PartsRequisitionsItemsGroupBox.Name = "PartsRequisitionsItemsGroupBox"
        Me.PartsRequisitionsItemsGroupBox.Size = New System.Drawing.Size(335, 138)
        Me.PartsRequisitionsItemsGroupBox.TabIndex = 121
        Me.PartsRequisitionsItemsGroupBox.TabStop = False
        Me.PartsRequisitionsItemsGroupBox.Text = "Requisition Items"
        '
        'PartsRequisitionsItemsDataGridView
        '
        Me.PartsRequisitionsItemsDataGridView.AllowUserToAddRows = False
        Me.PartsRequisitionsItemsDataGridView.AllowUserToDeleteRows = False
        Me.PartsRequisitionsItemsDataGridView.AllowUserToOrderColumns = True
        Me.PartsRequisitionsItemsDataGridView.AllowUserToResizeRows = False
        Me.PartsRequisitionsItemsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.PartsRequisitionsItemsDataGridView.Dock = System.Windows.Forms.DockStyle.Top
        Me.PartsRequisitionsItemsDataGridView.Location = New System.Drawing.Point(3, 22)
        Me.PartsRequisitionsItemsDataGridView.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PartsRequisitionsItemsDataGridView.Name = "PartsRequisitionsItemsDataGridView"
        Me.PartsRequisitionsItemsDataGridView.ReadOnly = True
        Me.PartsRequisitionsItemsDataGridView.RowHeadersVisible = False
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PartsRequisitionsItemsDataGridView.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.PartsRequisitionsItemsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.PartsRequisitionsItemsDataGridView.Size = New System.Drawing.Size(329, 179)
        Me.PartsRequisitionsItemsDataGridView.TabIndex = 53
        '
        'WorkOrderPartsMenuStrip
        '
        Me.WorkOrderPartsMenuStrip.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WorkOrderPartsMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReturnToolStripMenuItem, Me.ViewToolStripMenuItem, Me.DeleteRequisitionToolStripMenuItem, Me.PurchasersMenuToolStripMenus, Me.CreatePurchaseOrderToolStripMenuItem, Me.SelectToolStripMenuItem, Me.StoreKeepersToolStripMenuItem, Me.AddPurchaseOrderToolStripMenuItem, Me.EditPurchaseOrderToolStripMenuItem, Me.DeletePurchaseOrderToolStripMenuItem, Me.SavePurchaseOrderToolStripMenuItem})
        Me.WorkOrderPartsMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.WorkOrderPartsMenuStrip.Name = "WorkOrderPartsMenuStrip"
        Me.WorkOrderPartsMenuStrip.Padding = New System.Windows.Forms.Padding(10, 3, 0, 3)
        Me.WorkOrderPartsMenuStrip.Size = New System.Drawing.Size(1284, 31)
        Me.WorkOrderPartsMenuStrip.TabIndex = 120
        Me.WorkOrderPartsMenuStrip.Text = "MenuStrip1"
        '
        'ReturnToolStripMenuItem
        '
        Me.ReturnToolStripMenuItem.Name = "ReturnToolStripMenuItem"
        Me.ReturnToolStripMenuItem.Size = New System.Drawing.Size(40, 25)
        Me.ReturnToolStripMenuItem.Text = "◄ "
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RequisitionDetailsToolStripMenuItem, Me.OutstandingRequisitionsToolStripMenuItem, Me.PartiallyOrderedToolStripMenuItem, Me.ReorderedToolStripMenuItem, Me.CompletlyOrderedToolStripMenuItem, Me.AllRequisitionsToolStripMenuItem, Me.PrintRequisitionToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(56, 25)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'RequisitionDetailsToolStripMenuItem
        '
        Me.RequisitionDetailsToolStripMenuItem.Name = "RequisitionDetailsToolStripMenuItem"
        Me.RequisitionDetailsToolStripMenuItem.Size = New System.Drawing.Size(255, 26)
        Me.RequisitionDetailsToolStripMenuItem.Text = "Requisition Details"
        '
        'OutstandingRequisitionsToolStripMenuItem
        '
        Me.OutstandingRequisitionsToolStripMenuItem.Name = "OutstandingRequisitionsToolStripMenuItem"
        Me.OutstandingRequisitionsToolStripMenuItem.Size = New System.Drawing.Size(255, 26)
        Me.OutstandingRequisitionsToolStripMenuItem.Text = "Outstanding Requisitions"
        '
        'PartiallyOrderedToolStripMenuItem
        '
        Me.PartiallyOrderedToolStripMenuItem.Name = "PartiallyOrderedToolStripMenuItem"
        Me.PartiallyOrderedToolStripMenuItem.Size = New System.Drawing.Size(255, 26)
        Me.PartiallyOrderedToolStripMenuItem.Text = "Partially Ordered"
        '
        'ReorderedToolStripMenuItem
        '
        Me.ReorderedToolStripMenuItem.Name = "ReorderedToolStripMenuItem"
        Me.ReorderedToolStripMenuItem.Size = New System.Drawing.Size(255, 26)
        Me.ReorderedToolStripMenuItem.Text = "Reordered"
        '
        'CompletlyOrderedToolStripMenuItem
        '
        Me.CompletlyOrderedToolStripMenuItem.Name = "CompletlyOrderedToolStripMenuItem"
        Me.CompletlyOrderedToolStripMenuItem.Size = New System.Drawing.Size(255, 26)
        Me.CompletlyOrderedToolStripMenuItem.Text = "Completly Ordered"
        '
        'AllRequisitionsToolStripMenuItem
        '
        Me.AllRequisitionsToolStripMenuItem.Name = "AllRequisitionsToolStripMenuItem"
        Me.AllRequisitionsToolStripMenuItem.Size = New System.Drawing.Size(255, 26)
        Me.AllRequisitionsToolStripMenuItem.Text = "All Requisitions"
        '
        'PrintRequisitionToolStripMenuItem
        '
        Me.PrintRequisitionToolStripMenuItem.Name = "PrintRequisitionToolStripMenuItem"
        Me.PrintRequisitionToolStripMenuItem.Size = New System.Drawing.Size(255, 26)
        Me.PrintRequisitionToolStripMenuItem.Text = "Print Requisition"
        '
        'DeleteRequisitionToolStripMenuItem
        '
        Me.DeleteRequisitionToolStripMenuItem.Name = "DeleteRequisitionToolStripMenuItem"
        Me.DeleteRequisitionToolStripMenuItem.Size = New System.Drawing.Size(148, 25)
        Me.DeleteRequisitionToolStripMenuItem.Text = "Delete Requisition"
        '
        'PurchasersMenuToolStripMenus
        '
        Me.PurchasersMenuToolStripMenus.Enabled = False
        Me.PurchasersMenuToolStripMenus.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PurchasersMenuToolStripMenus.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.PurchasersMenuToolStripMenus.Name = "PurchasersMenuToolStripMenus"
        Me.PurchasersMenuToolStripMenus.Size = New System.Drawing.Size(185, 25)
        Me.PurchasersMenuToolStripMenus.Text = "PURCHASERS MENU :"
        '
        'CreatePurchaseOrderToolStripMenuItem
        '
        Me.CreatePurchaseOrderToolStripMenuItem.Name = "CreatePurchaseOrderToolStripMenuItem"
        Me.CreatePurchaseOrderToolStripMenuItem.Size = New System.Drawing.Size(307, 25)
        Me.CreatePurchaseOrderToolStripMenuItem.Text = "Create Purchase Order for Items Selected"
        Me.CreatePurchaseOrderToolStripMenuItem.Visible = False
        '
        'SelectToolStripMenuItem
        '
        Me.SelectToolStripMenuItem.Name = "SelectToolStripMenuItem"
        Me.SelectToolStripMenuItem.Size = New System.Drawing.Size(467, 25)
        Me.SelectToolStripMenuItem.Text = "Submit Selected Requested Items for an Existing Purchase Order"
        Me.SelectToolStripMenuItem.Visible = False
        '
        'StoreKeepersToolStripMenuItem
        '
        Me.StoreKeepersToolStripMenuItem.Enabled = False
        Me.StoreKeepersToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StoreKeepersToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.StoreKeepersToolStripMenuItem.Name = "StoreKeepersToolStripMenuItem"
        Me.StoreKeepersToolStripMenuItem.Size = New System.Drawing.Size(197, 25)
        Me.StoreKeepersToolStripMenuItem.Text = "STORE KEEPERS MENU:"
        '
        'AddPurchaseOrderToolStripMenuItem
        '
        Me.AddPurchaseOrderToolStripMenuItem.Name = "AddPurchaseOrderToolStripMenuItem"
        Me.AddPurchaseOrderToolStripMenuItem.Size = New System.Drawing.Size(50, 25)
        Me.AddPurchaseOrderToolStripMenuItem.Text = "Add"
        '
        'EditPurchaseOrderToolStripMenuItem
        '
        Me.EditPurchaseOrderToolStripMenuItem.Name = "EditPurchaseOrderToolStripMenuItem"
        Me.EditPurchaseOrderToolStripMenuItem.Size = New System.Drawing.Size(48, 25)
        Me.EditPurchaseOrderToolStripMenuItem.Text = "Edit"
        '
        'DeletePurchaseOrderToolStripMenuItem
        '
        Me.DeletePurchaseOrderToolStripMenuItem.Name = "DeletePurchaseOrderToolStripMenuItem"
        Me.DeletePurchaseOrderToolStripMenuItem.Size = New System.Drawing.Size(66, 25)
        Me.DeletePurchaseOrderToolStripMenuItem.Text = "Delete"
        '
        'SavePurchaseOrderToolStripMenuItem
        '
        Me.SavePurchaseOrderToolStripMenuItem.Name = "SavePurchaseOrderToolStripMenuItem"
        Me.SavePurchaseOrderToolStripMenuItem.Size = New System.Drawing.Size(55, 25)
        Me.SavePurchaseOrderToolStripMenuItem.Text = "Save"
        Me.SavePurchaseOrderToolStripMenuItem.Visible = False
        '
        'PartsRequisitionsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1284, 528)
        Me.Controls.Add(Me.RequisitionItemDetailsGroupBox)
        Me.Controls.Add(Me.PartsRequisitionsGroupBox)
        Me.Controls.Add(Me.PartsRequisitionsItemsGroupBox)
        Me.Controls.Add(Me.WorkOrderPartsMenuStrip)
        Me.Name = "PartsRequisitionsForm"
        Me.Text = "Form1"
        Me.RequisitionItemDetailsGroupBox.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.PartsRequisitionsGroupBox.ResumeLayout(False)
        CType(Me.PartsRequisitionsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PartsRequisitionsItemsGroupBox.ResumeLayout(False)
        CType(Me.PartsRequisitionsItemsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.WorkOrderPartsMenuStrip.ResumeLayout(False)
        Me.WorkOrderPartsMenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RequisitionItemDetailsGroupBox As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label8 As Label
    Friend WithEvents PcsPerPackTextBox As TextBox
    Friend WithEvents PackingLabel As Label
    Friend WithEvents POItemProductPartNoTextBox As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents RequisitionItemProductDescTextBox As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents EXITSAVEChangesButton As Button
    Friend WithEvents POItemQuantityTextBox As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents POItemUnitTextBox As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents POItemPriceTextBox As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents PartsRequisitionsGroupBox As GroupBox
    Friend WithEvents PartsRequisitionsDataGridView As DataGridView
    Friend WithEvents PartsRequisitionsItemsGroupBox As GroupBox
    Friend WithEvents PartsRequisitionsItemsDataGridView As DataGridView
    Friend WithEvents WorkOrderPartsMenuStrip As MenuStrip
    Friend WithEvents ReturnToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RequisitionDetailsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OutstandingRequisitionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PartiallyOrderedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReorderedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CompletlyOrderedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AllRequisitionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PrintRequisitionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteRequisitionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PurchasersMenuToolStripMenus As ToolStripMenuItem
    Friend WithEvents CreatePurchaseOrderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StoreKeepersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddPurchaseOrderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditPurchaseOrderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeletePurchaseOrderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SavePurchaseOrderToolStripMenuItem As ToolStripMenuItem
End Class
