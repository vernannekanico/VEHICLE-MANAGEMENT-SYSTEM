<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StoreRequisitionsForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PartsRequisitionsMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.ReturnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RequisitionsMenuToolStripMenus = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RequisitionDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DraftRequisitionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OutstandingRequisitionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PartiallyOrderedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReorderedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CompletlyOrderedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllRequisitionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintRequisitionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SubmitRequisitionsForPurchaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RequisitionItemsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PartsRequisitionsGroupBox = New System.Windows.Forms.GroupBox()
        Me.PartsRequisitionsDataGridView = New System.Windows.Forms.DataGridView()
        Me.RequisitionItemDetailsGroupBox = New System.Windows.Forms.GroupBox()
        Me.BrandTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PartTextBox = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.POItemProductPartNoTextBox = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.RequisitionItemUnitTextBox = New System.Windows.Forms.TextBox()
        Me.RequisitionItemProductDescTextBox = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.RequisitionItemQuantityTextBox = New System.Windows.Forms.TextBox()
        Me.EXITSAVEChangesButton = New System.Windows.Forms.Button()
        Me.StoreSuppliesRequisitionsItemsGroupBox = New System.Windows.Forms.GroupBox()
        Me.StoreSuppliesRequisitionsItemsDataGridView = New System.Windows.Forms.DataGridView()
        Me.PartsRequisitionsMenuStrip.SuspendLayout()
        Me.PartsRequisitionsGroupBox.SuspendLayout()
        CType(Me.PartsRequisitionsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RequisitionItemDetailsGroupBox.SuspendLayout()
        Me.StoreSuppliesRequisitionsItemsGroupBox.SuspendLayout()
        CType(Me.StoreSuppliesRequisitionsItemsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PartsRequisitionsMenuStrip
        '
        Me.PartsRequisitionsMenuStrip.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PartsRequisitionsMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReturnToolStripMenuItem, Me.RequisitionsMenuToolStripMenus, Me.ViewToolStripMenuItem, Me.SubmitRequisitionsForPurchaseToolStripMenuItem, Me.RequisitionItemsToolStripMenuItem, Me.AddItemToolStripMenuItem, Me.EditItemToolStripMenuItem, Me.DeleteItemToolStripMenuItem})
        Me.PartsRequisitionsMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.PartsRequisitionsMenuStrip.Name = "PartsRequisitionsMenuStrip"
        Me.PartsRequisitionsMenuStrip.Padding = New System.Windows.Forms.Padding(10, 3, 0, 3)
        Me.PartsRequisitionsMenuStrip.Size = New System.Drawing.Size(1284, 31)
        Me.PartsRequisitionsMenuStrip.TabIndex = 93
        Me.PartsRequisitionsMenuStrip.Text = "MenuStrip1"
        '
        'ReturnToolStripMenuItem
        '
        Me.ReturnToolStripMenuItem.Name = "ReturnToolStripMenuItem"
        Me.ReturnToolStripMenuItem.Size = New System.Drawing.Size(40, 25)
        Me.ReturnToolStripMenuItem.Text = "◄ "
        '
        'RequisitionsMenuToolStripMenus
        '
        Me.RequisitionsMenuToolStripMenus.Enabled = False
        Me.RequisitionsMenuToolStripMenus.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RequisitionsMenuToolStripMenus.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.RequisitionsMenuToolStripMenus.Name = "RequisitionsMenuToolStripMenus"
        Me.RequisitionsMenuToolStripMenus.Size = New System.Drawing.Size(193, 25)
        Me.RequisitionsMenuToolStripMenus.Text = "REQUISITIONS MENU :"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RequisitionDetailsToolStripMenuItem, Me.DraftRequisitionsToolStripMenuItem, Me.OutstandingRequisitionsToolStripMenuItem, Me.PartiallyOrderedToolStripMenuItem, Me.ReorderedToolStripMenuItem, Me.CompletlyOrderedToolStripMenuItem, Me.AllRequisitionsToolStripMenuItem, Me.PrintRequisitionToolStripMenuItem})
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
        'DraftRequisitionsToolStripMenuItem
        '
        Me.DraftRequisitionsToolStripMenuItem.Name = "DraftRequisitionsToolStripMenuItem"
        Me.DraftRequisitionsToolStripMenuItem.Size = New System.Drawing.Size(255, 26)
        Me.DraftRequisitionsToolStripMenuItem.Text = "Draft Requisitions"
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
        'SubmitRequisitionsForPurchaseToolStripMenuItem
        '
        Me.SubmitRequisitionsForPurchaseToolStripMenuItem.Name = "SubmitRequisitionsForPurchaseToolStripMenuItem"
        Me.SubmitRequisitionsForPurchaseToolStripMenuItem.Size = New System.Drawing.Size(252, 25)
        Me.SubmitRequisitionsForPurchaseToolStripMenuItem.Text = "Submit Requisitions for Purchase"
        '
        'RequisitionItemsToolStripMenuItem
        '
        Me.RequisitionItemsToolStripMenuItem.Enabled = False
        Me.RequisitionItemsToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RequisitionItemsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.RequisitionItemsToolStripMenuItem.Name = "RequisitionItemsToolStripMenuItem"
        Me.RequisitionItemsToolStripMenuItem.Size = New System.Drawing.Size(231, 25)
        Me.RequisitionItemsToolStripMenuItem.Text = "REQUISITION ITEMS MENU:"
        '
        'AddItemToolStripMenuItem
        '
        Me.AddItemToolStripMenuItem.Name = "AddItemToolStripMenuItem"
        Me.AddItemToolStripMenuItem.Size = New System.Drawing.Size(50, 25)
        Me.AddItemToolStripMenuItem.Text = "Add"
        '
        'EditItemToolStripMenuItem
        '
        Me.EditItemToolStripMenuItem.Name = "EditItemToolStripMenuItem"
        Me.EditItemToolStripMenuItem.Size = New System.Drawing.Size(48, 25)
        Me.EditItemToolStripMenuItem.Text = "Edit"
        '
        'DeleteItemToolStripMenuItem
        '
        Me.DeleteItemToolStripMenuItem.Name = "DeleteItemToolStripMenuItem"
        Me.DeleteItemToolStripMenuItem.Size = New System.Drawing.Size(66, 25)
        Me.DeleteItemToolStripMenuItem.Text = "Delete"
        '
        'PartsRequisitionsGroupBox
        '
        Me.PartsRequisitionsGroupBox.Controls.Add(Me.PartsRequisitionsDataGridView)
        Me.PartsRequisitionsGroupBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PartsRequisitionsGroupBox.Location = New System.Drawing.Point(23, 38)
        Me.PartsRequisitionsGroupBox.Name = "PartsRequisitionsGroupBox"
        Me.PartsRequisitionsGroupBox.Size = New System.Drawing.Size(367, 260)
        Me.PartsRequisitionsGroupBox.TabIndex = 117
        Me.PartsRequisitionsGroupBox.TabStop = False
        Me.PartsRequisitionsGroupBox.Text = "Requisitions"
        Me.PartsRequisitionsGroupBox.Visible = False
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
        'RequisitionItemDetailsGroupBox
        '
        Me.RequisitionItemDetailsGroupBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RequisitionItemDetailsGroupBox.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.RequisitionItemDetailsGroupBox.Controls.Add(Me.BrandTextBox)
        Me.RequisitionItemDetailsGroupBox.Controls.Add(Me.Label2)
        Me.RequisitionItemDetailsGroupBox.Controls.Add(Me.Label1)
        Me.RequisitionItemDetailsGroupBox.Controls.Add(Me.PartTextBox)
        Me.RequisitionItemDetailsGroupBox.Controls.Add(Me.Label19)
        Me.RequisitionItemDetailsGroupBox.Controls.Add(Me.Label16)
        Me.RequisitionItemDetailsGroupBox.Controls.Add(Me.POItemProductPartNoTextBox)
        Me.RequisitionItemDetailsGroupBox.Controls.Add(Me.Label20)
        Me.RequisitionItemDetailsGroupBox.Controls.Add(Me.RequisitionItemUnitTextBox)
        Me.RequisitionItemDetailsGroupBox.Controls.Add(Me.RequisitionItemProductDescTextBox)
        Me.RequisitionItemDetailsGroupBox.Controls.Add(Me.Label6)
        Me.RequisitionItemDetailsGroupBox.Controls.Add(Me.RequisitionItemQuantityTextBox)
        Me.RequisitionItemDetailsGroupBox.Controls.Add(Me.EXITSAVEChangesButton)
        Me.RequisitionItemDetailsGroupBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RequisitionItemDetailsGroupBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.RequisitionItemDetailsGroupBox.Location = New System.Drawing.Point(163, 76)
        Me.RequisitionItemDetailsGroupBox.Name = "RequisitionItemDetailsGroupBox"
        Me.RequisitionItemDetailsGroupBox.Size = New System.Drawing.Size(710, 316)
        Me.RequisitionItemDetailsGroupBox.TabIndex = 119
        Me.RequisitionItemDetailsGroupBox.TabStop = False
        Me.RequisitionItemDetailsGroupBox.Text = "Requisition Item Details"
        Me.RequisitionItemDetailsGroupBox.Visible = False
        '
        'BrandTextBox
        '
        Me.BrandTextBox.Enabled = False
        Me.BrandTextBox.Location = New System.Drawing.Point(103, 193)
        Me.BrandTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BrandTextBox.Name = "BrandTextBox"
        Me.BrandTextBox.ReadOnly = True
        Me.BrandTextBox.Size = New System.Drawing.Size(585, 26)
        Me.BrandTextBox.TabIndex = 104
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 199)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 20)
        Me.Label2.TabIndex = 103
        Me.Label2.Text = "Brand"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 20)
        Me.Label1.TabIndex = 101
        Me.Label1.Text = "Part"
        '
        'PartTextBox
        '
        Me.PartTextBox.Location = New System.Drawing.Point(103, 42)
        Me.PartTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PartTextBox.Name = "PartTextBox"
        Me.PartTextBox.ReadOnly = True
        Me.PartTextBox.Size = New System.Drawing.Size(585, 26)
        Me.PartTextBox.TabIndex = 102
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(22, 81)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(64, 20)
        Me.Label19.TabIndex = 97
        Me.Label19.Text = "Product"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(22, 242)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(68, 20)
        Me.Label16.TabIndex = 90
        Me.Label16.Text = "Quantity"
        '
        'POItemProductPartNoTextBox
        '
        Me.POItemProductPartNoTextBox.Enabled = False
        Me.POItemProductPartNoTextBox.Location = New System.Drawing.Point(103, 155)
        Me.POItemProductPartNoTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.POItemProductPartNoTextBox.Name = "POItemProductPartNoTextBox"
        Me.POItemProductPartNoTextBox.ReadOnly = True
        Me.POItemProductPartNoTextBox.Size = New System.Drawing.Size(585, 26)
        Me.POItemProductPartNoTextBox.TabIndex = 100
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(26, 161)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(51, 20)
        Me.Label20.TabIndex = 99
        Me.Label20.Text = "Part #"
        '
        'RequisitionItemUnitTextBox
        '
        Me.RequisitionItemUnitTextBox.Location = New System.Drawing.Point(103, 275)
        Me.RequisitionItemUnitTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RequisitionItemUnitTextBox.Name = "RequisitionItemUnitTextBox"
        Me.RequisitionItemUnitTextBox.ReadOnly = True
        Me.RequisitionItemUnitTextBox.Size = New System.Drawing.Size(53, 26)
        Me.RequisitionItemUnitTextBox.TabIndex = 93
        '
        'RequisitionItemProductDescTextBox
        '
        Me.RequisitionItemProductDescTextBox.Location = New System.Drawing.Point(103, 78)
        Me.RequisitionItemProductDescTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RequisitionItemProductDescTextBox.Multiline = True
        Me.RequisitionItemProductDescTextBox.Name = "RequisitionItemProductDescTextBox"
        Me.RequisitionItemProductDescTextBox.ReadOnly = True
        Me.RequisitionItemProductDescTextBox.Size = New System.Drawing.Size(585, 67)
        Me.RequisitionItemProductDescTextBox.TabIndex = 98
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(26, 273)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 20)
        Me.Label6.TabIndex = 94
        Me.Label6.Text = "Unit"
        '
        'RequisitionItemQuantityTextBox
        '
        Me.RequisitionItemQuantityTextBox.Location = New System.Drawing.Point(103, 239)
        Me.RequisitionItemQuantityTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RequisitionItemQuantityTextBox.Name = "RequisitionItemQuantityTextBox"
        Me.RequisitionItemQuantityTextBox.Size = New System.Drawing.Size(53, 26)
        Me.RequisitionItemQuantityTextBox.TabIndex = 95
        '
        'EXITSAVEChangesButton
        '
        Me.EXITSAVEChangesButton.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.EXITSAVEChangesButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EXITSAVEChangesButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.EXITSAVEChangesButton.Location = New System.Drawing.Point(173, 237)
        Me.EXITSAVEChangesButton.Name = "EXITSAVEChangesButton"
        Me.EXITSAVEChangesButton.Size = New System.Drawing.Size(515, 64)
        Me.EXITSAVEChangesButton.TabIndex = 96
        Me.EXITSAVEChangesButton.Text = "EXIT / SAVE Changes"
        Me.EXITSAVEChangesButton.UseVisualStyleBackColor = False
        '
        'StoreSuppliesRequisitionsItemsGroupBox
        '
        Me.StoreSuppliesRequisitionsItemsGroupBox.Controls.Add(Me.StoreSuppliesRequisitionsItemsDataGridView)
        Me.StoreSuppliesRequisitionsItemsGroupBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StoreSuppliesRequisitionsItemsGroupBox.Location = New System.Drawing.Point(26, 349)
        Me.StoreSuppliesRequisitionsItemsGroupBox.Name = "StoreSuppliesRequisitionsItemsGroupBox"
        Me.StoreSuppliesRequisitionsItemsGroupBox.Size = New System.Drawing.Size(335, 138)
        Me.StoreSuppliesRequisitionsItemsGroupBox.TabIndex = 120
        Me.StoreSuppliesRequisitionsItemsGroupBox.TabStop = False
        Me.StoreSuppliesRequisitionsItemsGroupBox.Text = "Requisition Items"
        Me.StoreSuppliesRequisitionsItemsGroupBox.Visible = False
        '
        'StoreSuppliesRequisitionsItemsDataGridView
        '
        Me.StoreSuppliesRequisitionsItemsDataGridView.AllowUserToAddRows = False
        Me.StoreSuppliesRequisitionsItemsDataGridView.AllowUserToDeleteRows = False
        Me.StoreSuppliesRequisitionsItemsDataGridView.AllowUserToOrderColumns = True
        Me.StoreSuppliesRequisitionsItemsDataGridView.AllowUserToResizeRows = False
        Me.StoreSuppliesRequisitionsItemsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.StoreSuppliesRequisitionsItemsDataGridView.Dock = System.Windows.Forms.DockStyle.Top
        Me.StoreSuppliesRequisitionsItemsDataGridView.Location = New System.Drawing.Point(3, 22)
        Me.StoreSuppliesRequisitionsItemsDataGridView.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.StoreSuppliesRequisitionsItemsDataGridView.Name = "StoreSuppliesRequisitionsItemsDataGridView"
        Me.StoreSuppliesRequisitionsItemsDataGridView.ReadOnly = True
        Me.StoreSuppliesRequisitionsItemsDataGridView.RowHeadersVisible = False
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.StoreSuppliesRequisitionsItemsDataGridView.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.StoreSuppliesRequisitionsItemsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.StoreSuppliesRequisitionsItemsDataGridView.Size = New System.Drawing.Size(329, 179)
        Me.StoreSuppliesRequisitionsItemsDataGridView.TabIndex = 53
        '
        'StoreRequisitionsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1284, 669)
        Me.Controls.Add(Me.StoreSuppliesRequisitionsItemsGroupBox)
        Me.Controls.Add(Me.RequisitionItemDetailsGroupBox)
        Me.Controls.Add(Me.PartsRequisitionsGroupBox)
        Me.Controls.Add(Me.PartsRequisitionsMenuStrip)
        Me.Name = "StoreRequisitionsForm"
        Me.Text = "PartsRequisitionsForm"
        Me.PartsRequisitionsMenuStrip.ResumeLayout(False)
        Me.PartsRequisitionsMenuStrip.PerformLayout()
        Me.PartsRequisitionsGroupBox.ResumeLayout(False)
        CType(Me.PartsRequisitionsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RequisitionItemDetailsGroupBox.ResumeLayout(False)
        Me.RequisitionItemDetailsGroupBox.PerformLayout()
        Me.StoreSuppliesRequisitionsItemsGroupBox.ResumeLayout(False)
        CType(Me.StoreSuppliesRequisitionsItemsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PartsRequisitionsMenuStrip As MenuStrip
    Friend WithEvents ReturnToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PartsRequisitionsGroupBox As GroupBox
    Friend WithEvents PartsRequisitionsDataGridView As DataGridView
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RequisitionDetailsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OutstandingRequisitionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PartiallyOrderedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReorderedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CompletlyOrderedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AllRequisitionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PrintRequisitionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RequisitionsMenuToolStripMenus As ToolStripMenuItem
    Friend WithEvents RequisitionItemsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RequisitionItemDetailsGroupBox As GroupBox
    Friend WithEvents POItemProductPartNoTextBox As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents RequisitionItemProductDescTextBox As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents EXITSAVEChangesButton As Button
    Friend WithEvents RequisitionItemQuantityTextBox As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents RequisitionItemUnitTextBox As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents AddItemToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label1 As Label
    Friend WithEvents PartTextBox As TextBox
    Friend WithEvents EditItemToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteItemToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SubmitRequisitionsForPurchaseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BrandTextBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents DraftRequisitionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StoreSuppliesRequisitionsItemsGroupBox As GroupBox
    Friend WithEvents StoreSuppliesRequisitionsItemsDataGridView As DataGridView
End Class
