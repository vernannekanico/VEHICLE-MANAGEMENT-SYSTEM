<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RequisitionsForm
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
        Me.RequisitionsGroupBox = New System.Windows.Forms.GroupBox()
        Me.RequisitionsDataGridView = New System.Windows.Forms.DataGridView()
        Me.RequisitionsItemsGroupBox = New System.Windows.Forms.GroupBox()
        Me.RequisitionsItemsDataGridView = New System.Windows.Forms.DataGridView()
        Me.RequisitionsMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.ReturnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RequisitionDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OutstandingRequisitionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PartiallyOrderedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReorderedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CompletlyOrderedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllRequisitionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintRequisitionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WhatToDoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AssignToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RequisitionItemDetailsGroupBox.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.RequisitionsGroupBox.SuspendLayout()
        CType(Me.RequisitionsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RequisitionsItemsGroupBox.SuspendLayout()
        CType(Me.RequisitionsItemsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RequisitionsMenuStrip.SuspendLayout()
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
        'RequisitionsGroupBox
        '
        Me.RequisitionsGroupBox.Controls.Add(Me.RequisitionsDataGridView)
        Me.RequisitionsGroupBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RequisitionsGroupBox.Location = New System.Drawing.Point(25, 70)
        Me.RequisitionsGroupBox.Name = "RequisitionsGroupBox"
        Me.RequisitionsGroupBox.Size = New System.Drawing.Size(367, 260)
        Me.RequisitionsGroupBox.TabIndex = 122
        Me.RequisitionsGroupBox.TabStop = False
        Me.RequisitionsGroupBox.Text = "Requisitions"
        '
        'RequisitionsDataGridView
        '
        Me.RequisitionsDataGridView.AllowUserToAddRows = False
        Me.RequisitionsDataGridView.AllowUserToDeleteRows = False
        Me.RequisitionsDataGridView.AllowUserToOrderColumns = True
        Me.RequisitionsDataGridView.AllowUserToResizeRows = False
        Me.RequisitionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.RequisitionsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RequisitionsDataGridView.Location = New System.Drawing.Point(3, 22)
        Me.RequisitionsDataGridView.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RequisitionsDataGridView.MultiSelect = False
        Me.RequisitionsDataGridView.Name = "RequisitionsDataGridView"
        Me.RequisitionsDataGridView.ReadOnly = True
        Me.RequisitionsDataGridView.RowHeadersVisible = False
        Me.RequisitionsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.RequisitionsDataGridView.Size = New System.Drawing.Size(361, 235)
        Me.RequisitionsDataGridView.TabIndex = 52
        '
        'RequisitionsItemsGroupBox
        '
        Me.RequisitionsItemsGroupBox.Controls.Add(Me.RequisitionsItemsDataGridView)
        Me.RequisitionsItemsGroupBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RequisitionsItemsGroupBox.Location = New System.Drawing.Point(449, 83)
        Me.RequisitionsItemsGroupBox.Name = "RequisitionsItemsGroupBox"
        Me.RequisitionsItemsGroupBox.Size = New System.Drawing.Size(335, 138)
        Me.RequisitionsItemsGroupBox.TabIndex = 121
        Me.RequisitionsItemsGroupBox.TabStop = False
        Me.RequisitionsItemsGroupBox.Text = "Requisition Items"
        '
        'RequisitionsItemsDataGridView
        '
        Me.RequisitionsItemsDataGridView.AllowUserToAddRows = False
        Me.RequisitionsItemsDataGridView.AllowUserToDeleteRows = False
        Me.RequisitionsItemsDataGridView.AllowUserToOrderColumns = True
        Me.RequisitionsItemsDataGridView.AllowUserToResizeRows = False
        Me.RequisitionsItemsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.RequisitionsItemsDataGridView.Dock = System.Windows.Forms.DockStyle.Top
        Me.RequisitionsItemsDataGridView.Location = New System.Drawing.Point(3, 22)
        Me.RequisitionsItemsDataGridView.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RequisitionsItemsDataGridView.Name = "RequisitionsItemsDataGridView"
        Me.RequisitionsItemsDataGridView.ReadOnly = True
        Me.RequisitionsItemsDataGridView.RowHeadersVisible = False
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.RequisitionsItemsDataGridView.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.RequisitionsItemsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.RequisitionsItemsDataGridView.Size = New System.Drawing.Size(329, 179)
        Me.RequisitionsItemsDataGridView.TabIndex = 53
        '
        'RequisitionsMenuStrip
        '
        Me.RequisitionsMenuStrip.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RequisitionsMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReturnToolStripMenuItem, Me.ViewToolStripMenuItem, Me.WhatToDoToolStripMenuItem, Me.AssignToolStripMenuItem})
        Me.RequisitionsMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.RequisitionsMenuStrip.Name = "RequisitionsMenuStrip"
        Me.RequisitionsMenuStrip.Padding = New System.Windows.Forms.Padding(10, 3, 0, 3)
        Me.RequisitionsMenuStrip.Size = New System.Drawing.Size(1284, 31)
        Me.RequisitionsMenuStrip.TabIndex = 120
        Me.RequisitionsMenuStrip.Text = "MenuStrip1"
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
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(63, 25)
        Me.ViewToolStripMenuItem.Text = "Views"
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
        Me.ReorderedToolStripMenuItem.Text = "Re-ordered"
        '
        'CompletlyOrderedToolStripMenuItem
        '
        Me.CompletlyOrderedToolStripMenuItem.Name = "CompletlyOrderedToolStripMenuItem"
        Me.CompletlyOrderedToolStripMenuItem.Size = New System.Drawing.Size(255, 26)
        Me.CompletlyOrderedToolStripMenuItem.Text = "Completely Ordered"
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
        'WhatToDoToolStripMenuItem
        '
        Me.WhatToDoToolStripMenuItem.Name = "WhatToDoToolStripMenuItem"
        Me.WhatToDoToolStripMenuItem.Size = New System.Drawing.Size(307, 25)
        Me.WhatToDoToolStripMenuItem.Text = "Create Purchase Order for Items Selected"
        Me.WhatToDoToolStripMenuItem.Visible = False
        '
        'AssignToolStripMenuItem
        '
        Me.AssignToolStripMenuItem.Name = "AssignToolStripMenuItem"
        Me.AssignToolStripMenuItem.Size = New System.Drawing.Size(68, 25)
        Me.AssignToolStripMenuItem.Text = "Assign"
        Me.AssignToolStripMenuItem.Visible = False
        '
        'RequisitionsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1284, 528)
        Me.Controls.Add(Me.RequisitionItemDetailsGroupBox)
        Me.Controls.Add(Me.RequisitionsGroupBox)
        Me.Controls.Add(Me.RequisitionsItemsGroupBox)
        Me.Controls.Add(Me.RequisitionsMenuStrip)
        Me.Name = "RequisitionsForm"
        Me.Text = "Form1"
        Me.RequisitionItemDetailsGroupBox.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.RequisitionsGroupBox.ResumeLayout(False)
        CType(Me.RequisitionsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RequisitionsItemsGroupBox.ResumeLayout(False)
        CType(Me.RequisitionsItemsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RequisitionsMenuStrip.ResumeLayout(False)
        Me.RequisitionsMenuStrip.PerformLayout()
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
    Friend WithEvents RequisitionsGroupBox As GroupBox
    Friend WithEvents RequisitionsDataGridView As DataGridView
    Friend WithEvents RequisitionsItemsGroupBox As GroupBox
    Friend WithEvents RequisitionsItemsDataGridView As DataGridView
    Friend WithEvents RequisitionsMenuStrip As MenuStrip
    Friend WithEvents ReturnToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RequisitionDetailsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OutstandingRequisitionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PartiallyOrderedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReorderedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CompletlyOrderedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AllRequisitionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PrintRequisitionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WhatToDoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AssignToolStripMenuItem As ToolStripMenuItem
End Class
