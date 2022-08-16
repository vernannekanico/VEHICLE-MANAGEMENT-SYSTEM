<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DeliveriesForm
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DeliveriesMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.ReturnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeliveryHeaderToolStripMenus = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DraftPurchaseOrdersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllPurchaseOrdersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddDeliveryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteDeliveryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveDeliveryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FinalizeDeliveryEntryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeliveryItemsToolStripMenus = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddDeliveryItemsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FromCustomerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FromPurchaseOrdersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditDeliveryItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveDeliveryItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeliveryDetailsGroupBox = New System.Windows.Forms.GroupBox()
        Me.DeliveryNoteNoTextBox = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.DeliveryrDate = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DeliveryNoTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DeliveryItemsGroupBox = New System.Windows.Forms.GroupBox()
        Me.DeliveryItemsDataGridView = New System.Windows.Forms.DataGridView()
        Me.DeliveriesGroupBox = New System.Windows.Forms.GroupBox()
        Me.DeliveriesDataGridView = New System.Windows.Forms.DataGridView()
        Me.DeliveryItemDetailsGroupBox = New System.Windows.Forms.GroupBox()
        Me.PcsPerPackTextBox = New System.Windows.Forms.TextBox()
        Me.PackingLabel = New System.Windows.Forms.Label()
        Me.POItemProductPartNoTextBox = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.POItemProductDescTextBox = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.EXITSAVEChangesButton = New System.Windows.Forms.Button()
        Me.POItemQuantityTextBox = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.POItemUnitTextBox = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.BrandTextBox = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.POReferenceTextBox = New System.Windows.Forms.TextBox()
        Me.DeliveriesMenuStrip.SuspendLayout()
        Me.DeliveryDetailsGroupBox.SuspendLayout()
        Me.DeliveryItemsGroupBox.SuspendLayout()
        CType(Me.DeliveryItemsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DeliveriesGroupBox.SuspendLayout()
        CType(Me.DeliveriesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DeliveryItemDetailsGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'DeliveriesMenuStrip
        '
        Me.DeliveriesMenuStrip.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeliveriesMenuStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.DeliveriesMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReturnToolStripMenuItem, Me.DeliveryHeaderToolStripMenus, Me.ViewToolStripMenuItem, Me.AddDeliveryToolStripMenuItem, Me.DeleteDeliveryToolStripMenuItem, Me.ToolStripMenuItem1, Me.SaveDeliveryToolStripMenuItem, Me.FinalizeDeliveryEntryToolStripMenuItem, Me.DeliveryItemsToolStripMenus, Me.AddDeliveryItemsToolStripMenuItem, Me.EditDeliveryItemToolStripMenuItem, Me.RemoveDeliveryItemToolStripMenuItem})
        Me.DeliveriesMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.DeliveriesMenuStrip.Name = "DeliveriesMenuStrip"
        Me.DeliveriesMenuStrip.Padding = New System.Windows.Forms.Padding(13, 4, 0, 4)
        Me.DeliveriesMenuStrip.Size = New System.Drawing.Size(1712, 40)
        Me.DeliveriesMenuStrip.TabIndex = 84
        Me.DeliveriesMenuStrip.Text = "MenuStrip1"
        '
        'ReturnToolStripMenuItem
        '
        Me.ReturnToolStripMenuItem.Name = "ReturnToolStripMenuItem"
        Me.ReturnToolStripMenuItem.Size = New System.Drawing.Size(48, 32)
        Me.ReturnToolStripMenuItem.Text = "◄ "
        '
        'DeliveryHeaderToolStripMenus
        '
        Me.DeliveryHeaderToolStripMenus.Enabled = False
        Me.DeliveryHeaderToolStripMenus.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeliveryHeaderToolStripMenus.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.DeliveryHeaderToolStripMenus.Name = "DeliveryHeaderToolStripMenus"
        Me.DeliveryHeaderToolStripMenus.Size = New System.Drawing.Size(213, 32)
        Me.DeliveryHeaderToolStripMenus.Text = "DELIVERY HEADER :"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DraftPurchaseOrdersToolStripMenuItem, Me.AllPurchaseOrdersToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(67, 32)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'DraftPurchaseOrdersToolStripMenuItem
        '
        Me.DraftPurchaseOrdersToolStripMenuItem.Name = "DraftPurchaseOrdersToolStripMenuItem"
        Me.DraftPurchaseOrdersToolStripMenuItem.Size = New System.Drawing.Size(281, 32)
        Me.DraftPurchaseOrdersToolStripMenuItem.Text = "Draft Delivery Entries"
        '
        'AllPurchaseOrdersToolStripMenuItem
        '
        Me.AllPurchaseOrdersToolStripMenuItem.Name = "AllPurchaseOrdersToolStripMenuItem"
        Me.AllPurchaseOrdersToolStripMenuItem.Size = New System.Drawing.Size(281, 32)
        Me.AllPurchaseOrdersToolStripMenuItem.Text = "All Deliveries"
        '
        'AddDeliveryToolStripMenuItem
        '
        Me.AddDeliveryToolStripMenuItem.Name = "AddDeliveryToolStripMenuItem"
        Me.AddDeliveryToolStripMenuItem.Size = New System.Drawing.Size(63, 32)
        Me.AddDeliveryToolStripMenuItem.Text = "Add"
        '
        'DeleteDeliveryToolStripMenuItem
        '
        Me.DeleteDeliveryToolStripMenuItem.Name = "DeleteDeliveryToolStripMenuItem"
        Me.DeleteDeliveryToolStripMenuItem.Size = New System.Drawing.Size(82, 32)
        Me.DeleteDeliveryToolStripMenuItem.Text = "Delete"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(14, 32)
        '
        'SaveDeliveryToolStripMenuItem
        '
        Me.SaveDeliveryToolStripMenuItem.Name = "SaveDeliveryToolStripMenuItem"
        Me.SaveDeliveryToolStripMenuItem.Size = New System.Drawing.Size(67, 32)
        Me.SaveDeliveryToolStripMenuItem.Text = "Save"
        Me.SaveDeliveryToolStripMenuItem.Visible = False
        '
        'FinalizeDeliveryEntryToolStripMenuItem
        '
        Me.FinalizeDeliveryEntryToolStripMenuItem.Name = "FinalizeDeliveryEntryToolStripMenuItem"
        Me.FinalizeDeliveryEntryToolStripMenuItem.Size = New System.Drawing.Size(217, 32)
        Me.FinalizeDeliveryEntryToolStripMenuItem.Text = "Finalize Delivery Entry"
        '
        'DeliveryItemsToolStripMenus
        '
        Me.DeliveryItemsToolStripMenus.Enabled = False
        Me.DeliveryItemsToolStripMenus.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeliveryItemsToolStripMenus.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.DeliveryItemsToolStripMenus.Name = "DeliveryItemsToolStripMenus"
        Me.DeliveryItemsToolStripMenus.Size = New System.Drawing.Size(193, 32)
        Me.DeliveryItemsToolStripMenus.Text = "DELIVERY ITEMS :"
        '
        'AddDeliveryItemsToolStripMenuItem
        '
        Me.AddDeliveryItemsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FromCustomerToolStripMenuItem, Me.FromPurchaseOrdersToolStripMenuItem})
        Me.AddDeliveryItemsToolStripMenuItem.Name = "AddDeliveryItemsToolStripMenuItem"
        Me.AddDeliveryItemsToolStripMenuItem.Size = New System.Drawing.Size(63, 32)
        Me.AddDeliveryItemsToolStripMenuItem.Text = "Add"
        '
        'FromCustomerToolStripMenuItem
        '
        Me.FromCustomerToolStripMenuItem.Name = "FromCustomerToolStripMenuItem"
        Me.FromCustomerToolStripMenuItem.Size = New System.Drawing.Size(290, 32)
        Me.FromCustomerToolStripMenuItem.Text = "From Customer"
        '
        'FromPurchaseOrdersToolStripMenuItem
        '
        Me.FromPurchaseOrdersToolStripMenuItem.Name = "FromPurchaseOrdersToolStripMenuItem"
        Me.FromPurchaseOrdersToolStripMenuItem.Size = New System.Drawing.Size(290, 32)
        Me.FromPurchaseOrdersToolStripMenuItem.Text = "From Purchase Orders"
        '
        'EditDeliveryItemToolStripMenuItem
        '
        Me.EditDeliveryItemToolStripMenuItem.Name = "EditDeliveryItemToolStripMenuItem"
        Me.EditDeliveryItemToolStripMenuItem.Size = New System.Drawing.Size(60, 32)
        Me.EditDeliveryItemToolStripMenuItem.Text = "Edit"
        '
        'RemoveDeliveryItemToolStripMenuItem
        '
        Me.RemoveDeliveryItemToolStripMenuItem.Name = "RemoveDeliveryItemToolStripMenuItem"
        Me.RemoveDeliveryItemToolStripMenuItem.Size = New System.Drawing.Size(96, 32)
        Me.RemoveDeliveryItemToolStripMenuItem.Text = "Remove"
        '
        'DeliveryDetailsGroupBox
        '
        Me.DeliveryDetailsGroupBox.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.DeliveryDetailsGroupBox.Controls.Add(Me.Label3)
        Me.DeliveryDetailsGroupBox.Controls.Add(Me.POReferenceTextBox)
        Me.DeliveryDetailsGroupBox.Controls.Add(Me.DeliveryNoteNoTextBox)
        Me.DeliveryDetailsGroupBox.Controls.Add(Me.Label13)
        Me.DeliveryDetailsGroupBox.Controls.Add(Me.DeliveryrDate)
        Me.DeliveryDetailsGroupBox.Controls.Add(Me.Label2)
        Me.DeliveryDetailsGroupBox.Controls.Add(Me.DeliveryNoTextBox)
        Me.DeliveryDetailsGroupBox.Controls.Add(Me.Label1)
        Me.DeliveryDetailsGroupBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeliveryDetailsGroupBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DeliveryDetailsGroupBox.Location = New System.Drawing.Point(824, 77)
        Me.DeliveryDetailsGroupBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DeliveryDetailsGroupBox.Name = "DeliveryDetailsGroupBox"
        Me.DeliveryDetailsGroupBox.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DeliveryDetailsGroupBox.Size = New System.Drawing.Size(636, 253)
        Me.DeliveryDetailsGroupBox.TabIndex = 87
        Me.DeliveryDetailsGroupBox.TabStop = False
        Me.DeliveryDetailsGroupBox.Text = "Details"
        '
        'DeliveryNoteNoTextBox
        '
        Me.DeliveryNoteNoTextBox.Location = New System.Drawing.Point(162, 172)
        Me.DeliveryNoteNoTextBox.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.DeliveryNoteNoTextBox.Name = "DeliveryNoteNoTextBox"
        Me.DeliveryNoteNoTextBox.Size = New System.Drawing.Size(315, 30)
        Me.DeliveryNoteNoTextBox.TabIndex = 81
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(4, 135)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(128, 25)
        Me.Label13.TabIndex = 78
        Me.Label13.Text = "Delivery Date"
        '
        'DeliveryrDate
        '
        Me.DeliveryrDate.Location = New System.Drawing.Point(162, 131)
        Me.DeliveryrDate.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.DeliveryrDate.Name = "DeliveryrDate"
        Me.DeliveryrDate.Size = New System.Drawing.Size(311, 30)
        Me.DeliveryrDate.TabIndex = 76
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Enabled = False
        Me.Label2.Location = New System.Drawing.Point(8, 91)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 25)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "Delivery No"
        '
        'DeliveryNoTextBox
        '
        Me.DeliveryNoTextBox.Enabled = False
        Me.DeliveryNoTextBox.Location = New System.Drawing.Point(162, 86)
        Me.DeliveryNoTextBox.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.DeliveryNoTextBox.Name = "DeliveryNoTextBox"
        Me.DeliveryNoTextBox.Size = New System.Drawing.Size(311, 30)
        Me.DeliveryNoTextBox.TabIndex = 55
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 172)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(163, 25)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "Delivery Note No."
        '
        'DeliveryItemsGroupBox
        '
        Me.DeliveryItemsGroupBox.Controls.Add(Me.DeliveryItemsDataGridView)
        Me.DeliveryItemsGroupBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeliveryItemsGroupBox.Location = New System.Drawing.Point(80, 320)
        Me.DeliveryItemsGroupBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DeliveryItemsGroupBox.Name = "DeliveryItemsGroupBox"
        Me.DeliveryItemsGroupBox.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DeliveryItemsGroupBox.Size = New System.Drawing.Size(237, 156)
        Me.DeliveryItemsGroupBox.TabIndex = 109
        Me.DeliveryItemsGroupBox.TabStop = False
        Me.DeliveryItemsGroupBox.Text = "Delivery Items"
        '
        'DeliveryItemsDataGridView
        '
        Me.DeliveryItemsDataGridView.AllowUserToAddRows = False
        Me.DeliveryItemsDataGridView.AllowUserToDeleteRows = False
        Me.DeliveryItemsDataGridView.AllowUserToOrderColumns = True
        Me.DeliveryItemsDataGridView.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DeliveryItemsDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DeliveryItemsDataGridView.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
        Me.DeliveryItemsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Menu
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DeliveryItemsDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DeliveryItemsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DeliveryItemsDataGridView.DefaultCellStyle = DataGridViewCellStyle3
        Me.DeliveryItemsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DeliveryItemsDataGridView.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.DeliveryItemsDataGridView.Location = New System.Drawing.Point(4, 27)
        Me.DeliveryItemsDataGridView.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DeliveryItemsDataGridView.MultiSelect = False
        Me.DeliveryItemsDataGridView.Name = "DeliveryItemsDataGridView"
        Me.DeliveryItemsDataGridView.ReadOnly = True
        Me.DeliveryItemsDataGridView.RowHeadersVisible = False
        Me.DeliveryItemsDataGridView.RowHeadersWidth = 51
        Me.DeliveryItemsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DeliveryItemsDataGridView.Size = New System.Drawing.Size(229, 125)
        Me.DeliveryItemsDataGridView.TabIndex = 103
        '
        'DeliveriesGroupBox
        '
        Me.DeliveriesGroupBox.Controls.Add(Me.DeliveriesDataGridView)
        Me.DeliveriesGroupBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeliveriesGroupBox.Location = New System.Drawing.Point(76, 65)
        Me.DeliveriesGroupBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DeliveriesGroupBox.Name = "DeliveriesGroupBox"
        Me.DeliveriesGroupBox.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DeliveriesGroupBox.Size = New System.Drawing.Size(245, 230)
        Me.DeliveriesGroupBox.TabIndex = 108
        Me.DeliveriesGroupBox.TabStop = False
        Me.DeliveriesGroupBox.Text = "Deliveries"
        '
        'DeliveriesDataGridView
        '
        Me.DeliveriesDataGridView.AllowUserToAddRows = False
        Me.DeliveriesDataGridView.AllowUserToDeleteRows = False
        Me.DeliveriesDataGridView.AllowUserToOrderColumns = True
        Me.DeliveriesDataGridView.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DeliveriesDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DeliveriesDataGridView.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
        Me.DeliveriesDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.Menu
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DeliveriesDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DeliveriesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DeliveriesDataGridView.DefaultCellStyle = DataGridViewCellStyle6
        Me.DeliveriesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DeliveriesDataGridView.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.DeliveriesDataGridView.Location = New System.Drawing.Point(4, 27)
        Me.DeliveriesDataGridView.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DeliveriesDataGridView.Name = "DeliveriesDataGridView"
        Me.DeliveriesDataGridView.ReadOnly = True
        Me.DeliveriesDataGridView.RowHeadersVisible = False
        Me.DeliveriesDataGridView.RowHeadersWidth = 51
        Me.DeliveriesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DeliveriesDataGridView.Size = New System.Drawing.Size(237, 199)
        Me.DeliveriesDataGridView.TabIndex = 109
        '
        'DeliveryItemDetailsGroupBox
        '
        Me.DeliveryItemDetailsGroupBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DeliveryItemDetailsGroupBox.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.DeliveryItemDetailsGroupBox.Controls.Add(Me.PcsPerPackTextBox)
        Me.DeliveryItemDetailsGroupBox.Controls.Add(Me.PackingLabel)
        Me.DeliveryItemDetailsGroupBox.Controls.Add(Me.POItemProductPartNoTextBox)
        Me.DeliveryItemDetailsGroupBox.Controls.Add(Me.Label20)
        Me.DeliveryItemDetailsGroupBox.Controls.Add(Me.POItemProductDescTextBox)
        Me.DeliveryItemDetailsGroupBox.Controls.Add(Me.Label19)
        Me.DeliveryItemDetailsGroupBox.Controls.Add(Me.EXITSAVEChangesButton)
        Me.DeliveryItemDetailsGroupBox.Controls.Add(Me.POItemQuantityTextBox)
        Me.DeliveryItemDetailsGroupBox.Controls.Add(Me.Label6)
        Me.DeliveryItemDetailsGroupBox.Controls.Add(Me.POItemUnitTextBox)
        Me.DeliveryItemDetailsGroupBox.Controls.Add(Me.Label7)
        Me.DeliveryItemDetailsGroupBox.Controls.Add(Me.BrandTextBox)
        Me.DeliveryItemDetailsGroupBox.Controls.Add(Me.Label16)
        Me.DeliveryItemDetailsGroupBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeliveryItemDetailsGroupBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DeliveryItemDetailsGroupBox.Location = New System.Drawing.Point(341, 384)
        Me.DeliveryItemDetailsGroupBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DeliveryItemDetailsGroupBox.Name = "DeliveryItemDetailsGroupBox"
        Me.DeliveryItemDetailsGroupBox.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DeliveryItemDetailsGroupBox.Size = New System.Drawing.Size(953, 257)
        Me.DeliveryItemDetailsGroupBox.TabIndex = 110
        Me.DeliveryItemDetailsGroupBox.TabStop = False
        Me.DeliveryItemDetailsGroupBox.Text = "Delivery Details"
        Me.DeliveryItemDetailsGroupBox.Visible = False
        '
        'PcsPerPackTextBox
        '
        Me.PcsPerPackTextBox.Enabled = False
        Me.PcsPerPackTextBox.Location = New System.Drawing.Point(357, 175)
        Me.PcsPerPackTextBox.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.PcsPerPackTextBox.Name = "PcsPerPackTextBox"
        Me.PcsPerPackTextBox.Size = New System.Drawing.Size(49, 30)
        Me.PcsPerPackTextBox.TabIndex = 117
        Me.PcsPerPackTextBox.Visible = False
        '
        'PackingLabel
        '
        Me.PackingLabel.AutoSize = True
        Me.PackingLabel.Location = New System.Drawing.Point(237, 178)
        Me.PackingLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.PackingLabel.Name = "PackingLabel"
        Me.PackingLabel.Size = New System.Drawing.Size(82, 25)
        Me.PackingLabel.TabIndex = 116
        Me.PackingLabel.Text = "Packing"
        Me.PackingLabel.Visible = False
        '
        'POItemProductPartNoTextBox
        '
        Me.POItemProductPartNoTextBox.Enabled = False
        Me.POItemProductPartNoTextBox.Location = New System.Drawing.Point(135, 90)
        Me.POItemProductPartNoTextBox.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.POItemProductPartNoTextBox.Name = "POItemProductPartNoTextBox"
        Me.POItemProductPartNoTextBox.Size = New System.Drawing.Size(779, 30)
        Me.POItemProductPartNoTextBox.TabIndex = 115
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(27, 94)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(63, 25)
        Me.Label20.TabIndex = 114
        Me.Label20.Text = "Part #"
        '
        'POItemProductDescTextBox
        '
        Me.POItemProductDescTextBox.Location = New System.Drawing.Point(135, 46)
        Me.POItemProductDescTextBox.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.POItemProductDescTextBox.Name = "POItemProductDescTextBox"
        Me.POItemProductDescTextBox.Size = New System.Drawing.Size(779, 30)
        Me.POItemProductDescTextBox.TabIndex = 113
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(27, 49)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(79, 25)
        Me.Label19.TabIndex = 112
        Me.Label19.Text = "Product"
        '
        'EXITSAVEChangesButton
        '
        Me.EXITSAVEChangesButton.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.EXITSAVEChangesButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EXITSAVEChangesButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.EXITSAVEChangesButton.Location = New System.Drawing.Point(433, 132)
        Me.EXITSAVEChangesButton.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.EXITSAVEChangesButton.Name = "EXITSAVEChangesButton"
        Me.EXITSAVEChangesButton.Size = New System.Drawing.Size(481, 113)
        Me.EXITSAVEChangesButton.TabIndex = 111
        Me.EXITSAVEChangesButton.Text = "EXIT / SAVE Changes"
        Me.EXITSAVEChangesButton.UseVisualStyleBackColor = False
        '
        'POItemQuantityTextBox
        '
        Me.POItemQuantityTextBox.Location = New System.Drawing.Point(136, 171)
        Me.POItemQuantityTextBox.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.POItemQuantityTextBox.Name = "POItemQuantityTextBox"
        Me.POItemQuantityTextBox.Size = New System.Drawing.Size(69, 30)
        Me.POItemQuantityTextBox.TabIndex = 110
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(33, 210)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 25)
        Me.Label6.TabIndex = 109
        Me.Label6.Text = "Unit"
        '
        'POItemUnitTextBox
        '
        Me.POItemUnitTextBox.Enabled = False
        Me.POItemUnitTextBox.Location = New System.Drawing.Point(136, 213)
        Me.POItemUnitTextBox.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.POItemUnitTextBox.Name = "POItemUnitTextBox"
        Me.POItemUnitTextBox.Size = New System.Drawing.Size(69, 30)
        Me.POItemUnitTextBox.TabIndex = 108
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(29, 134)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 25)
        Me.Label7.TabIndex = 107
        Me.Label7.Text = "Brand"
        '
        'BrandTextBox
        '
        Me.BrandTextBox.Location = New System.Drawing.Point(135, 134)
        Me.BrandTextBox.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.BrandTextBox.Name = "BrandTextBox"
        Me.BrandTextBox.Size = New System.Drawing.Size(69, 30)
        Me.BrandTextBox.TabIndex = 106
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(28, 175)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(85, 25)
        Me.Label16.TabIndex = 105
        Me.Label16.Text = "Quantity"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Enabled = False
        Me.Label3.Location = New System.Drawing.Point(8, 36)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(145, 25)
        Me.Label3.TabIndex = 83
        Me.Label3.Text = "P.O. Reference"
        '
        'POReferenceTextBox
        '
        Me.POReferenceTextBox.Enabled = False
        Me.POReferenceTextBox.Location = New System.Drawing.Point(162, 33)
        Me.POReferenceTextBox.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.POReferenceTextBox.Name = "POReferenceTextBox"
        Me.POReferenceTextBox.Size = New System.Drawing.Size(311, 30)
        Me.POReferenceTextBox.TabIndex = 82
        '
        'DeliveriesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1712, 742)
        Me.Controls.Add(Me.DeliveryItemDetailsGroupBox)
        Me.Controls.Add(Me.DeliveryItemsGroupBox)
        Me.Controls.Add(Me.DeliveriesGroupBox)
        Me.Controls.Add(Me.DeliveryDetailsGroupBox)
        Me.Controls.Add(Me.DeliveriesMenuStrip)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "DeliveriesForm"
        Me.Text = "ReceiveItemsForm"
        Me.DeliveriesMenuStrip.ResumeLayout(False)
        Me.DeliveriesMenuStrip.PerformLayout()
        Me.DeliveryDetailsGroupBox.ResumeLayout(False)
        Me.DeliveryDetailsGroupBox.PerformLayout()
        Me.DeliveryItemsGroupBox.ResumeLayout(False)
        CType(Me.DeliveryItemsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DeliveriesGroupBox.ResumeLayout(False)
        CType(Me.DeliveriesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DeliveryItemDetailsGroupBox.ResumeLayout(False)
        Me.DeliveryItemDetailsGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DeliveriesMenuStrip As MenuStrip
    Friend WithEvents ReturnToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeliveryHeaderToolStripMenus As ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DraftPurchaseOrdersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AllPurchaseOrdersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddDeliveryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteDeliveryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents SaveDeliveryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FinalizeDeliveryEntryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeliveryItemsToolStripMenus As ToolStripMenuItem
    Friend WithEvents AddDeliveryItemsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditDeliveryItemToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RemoveDeliveryItemToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeliveryDetailsGroupBox As GroupBox
    Friend WithEvents DeliveryNoteNoTextBox As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents DeliveryrDate As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents DeliveryNoTextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DeliveryItemsGroupBox As GroupBox
    Friend WithEvents DeliveryItemsDataGridView As DataGridView
    Friend WithEvents DeliveriesGroupBox As GroupBox
    Friend WithEvents DeliveriesDataGridView As DataGridView
    Friend WithEvents DeliveryItemDetailsGroupBox As GroupBox
    Friend WithEvents PcsPerPackTextBox As TextBox
    Friend WithEvents PackingLabel As Label
    Friend WithEvents POItemProductPartNoTextBox As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents POItemProductDescTextBox As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents EXITSAVEChangesButton As Button
    Friend WithEvents POItemQuantityTextBox As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents POItemUnitTextBox As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents BrandTextBox As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents FromCustomerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FromPurchaseOrdersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label3 As Label
    Friend WithEvents POReferenceTextBox As TextBox
End Class
