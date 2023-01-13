﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InventoriesForm
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
        Me.InventoryHeadersGroupBox = New System.Windows.Forms.GroupBox()
        Me.InventoryHeadersDataGridView = New System.Windows.Forms.DataGridView()
        Me.SearchToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.SearchMyStandardTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.InventoriesFormMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.ReturnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewInventoriesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmployeeDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllInventoriesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.INVENTORYLISTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddInventoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditInventoryDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteInventoryItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveInventoryDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SubmitForApprovalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ApproveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegisterInventoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintInventoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetForApprovalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InventoryDetailsGroup = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BulkBalanceUnitTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BulkBalanceTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ProductSpecificationTextBox = New System.Windows.Forms.TextBox()
        Me.PackingTextBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LocationTextBox = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.QtyInBasicUnitTextBox = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.BrandNameTextBox = New System.Windows.Forms.MaskedTextBox()
        Me.UnitTextBox = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.SystemPartDescriptionTextBox = New System.Windows.Forms.TextBox()
        Me.ManufacturerPartDescTextBox = New System.Windows.Forms.TextBox()
        Me.ManufacturerPartNoTextBox = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.ManufacturerPartNoLabel = New System.Windows.Forms.Label()
        Me.InventoryItemsGroupBox = New System.Windows.Forms.GroupBox()
        Me.InventoryItemsDataGridView = New System.Windows.Forms.DataGridView()
        Me.InventoryHeadersGroupBox.SuspendLayout()
        CType(Me.InventoryHeadersDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SearchToolStrip.SuspendLayout()
        Me.InventoriesFormMenuStrip.SuspendLayout()
        Me.InventoryDetailsGroup.SuspendLayout()
        Me.InventoryItemsGroupBox.SuspendLayout()
        CType(Me.InventoryItemsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'InventoryHeadersGroupBox
        '
        Me.InventoryHeadersGroupBox.Controls.Add(Me.InventoryHeadersDataGridView)
        Me.InventoryHeadersGroupBox.Location = New System.Drawing.Point(25, 78)
        Me.InventoryHeadersGroupBox.Name = "InventoryHeadersGroupBox"
        Me.InventoryHeadersGroupBox.Size = New System.Drawing.Size(311, 85)
        Me.InventoryHeadersGroupBox.TabIndex = 95
        Me.InventoryHeadersGroupBox.TabStop = False
        Me.InventoryHeadersGroupBox.Text = "Outstanding Inventories"
        '
        'InventoryHeadersDataGridView
        '
        Me.InventoryHeadersDataGridView.AllowUserToAddRows = False
        Me.InventoryHeadersDataGridView.AllowUserToDeleteRows = False
        Me.InventoryHeadersDataGridView.AllowUserToOrderColumns = True
        Me.InventoryHeadersDataGridView.AllowUserToResizeRows = False
        Me.InventoryHeadersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.InventoryHeadersDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.InventoryHeadersDataGridView.Location = New System.Drawing.Point(3, 22)
        Me.InventoryHeadersDataGridView.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.InventoryHeadersDataGridView.MultiSelect = False
        Me.InventoryHeadersDataGridView.Name = "InventoryHeadersDataGridView"
        Me.InventoryHeadersDataGridView.ReadOnly = True
        Me.InventoryHeadersDataGridView.RowHeadersVisible = False
        Me.InventoryHeadersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.InventoryHeadersDataGridView.Size = New System.Drawing.Size(305, 60)
        Me.InventoryHeadersDataGridView.TabIndex = 52
        '
        'SearchToolStrip
        '
        Me.SearchToolStrip.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.SearchMyStandardTextBox})
        Me.SearchToolStrip.Location = New System.Drawing.Point(0, 31)
        Me.SearchToolStrip.Name = "SearchToolStrip"
        Me.SearchToolStrip.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.SearchToolStrip.Size = New System.Drawing.Size(1200, 29)
        Me.SearchToolStrip.TabIndex = 94
        Me.SearchToolStrip.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(35, 26)
        Me.ToolStripLabel1.Text = "Key"
        '
        'SearchMyStandardTextBox
        '
        Me.SearchMyStandardTextBox.Font = New System.Drawing.Font("Segoe UI", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchMyStandardTextBox.Name = "SearchMyStandardTextBox"
        Me.SearchMyStandardTextBox.Size = New System.Drawing.Size(300, 29)
        Me.SearchMyStandardTextBox.Text = "Search"
        '
        'InventoriesFormMenuStrip
        '
        Me.InventoriesFormMenuStrip.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InventoriesFormMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReturnToolStripMenuItem, Me.ViewInventoriesToolStripMenuItem, Me.INVENTORYLISTToolStripMenuItem, Me.AddInventoryToolStripMenuItem, Me.EditInventoryDetailsToolStripMenuItem, Me.DeleteInventoryItemToolStripMenuItem, Me.SaveInventoryDetailsToolStripMenuItem, Me.SubmitForApprovalToolStripMenuItem, Me.ApproveToolStripMenuItem, Me.RegisterInventoryToolStripMenuItem, Me.PrintInventoryToolStripMenuItem, Me.ResetForApprovalToolStripMenuItem})
        Me.InventoriesFormMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.InventoriesFormMenuStrip.Name = "InventoriesFormMenuStrip"
        Me.InventoriesFormMenuStrip.Padding = New System.Windows.Forms.Padding(10, 3, 0, 3)
        Me.InventoriesFormMenuStrip.Size = New System.Drawing.Size(1200, 31)
        Me.InventoriesFormMenuStrip.TabIndex = 93
        Me.InventoriesFormMenuStrip.Text = "MenuStrip1"
        '
        'ReturnToolStripMenuItem
        '
        Me.ReturnToolStripMenuItem.Name = "ReturnToolStripMenuItem"
        Me.ReturnToolStripMenuItem.Size = New System.Drawing.Size(40, 25)
        Me.ReturnToolStripMenuItem.Text = "◄ "
        '
        'ViewInventoriesToolStripMenuItem
        '
        Me.ViewInventoriesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EmployeeDetailsToolStripMenuItem, Me.AllInventoriesToolStripMenuItem})
        Me.ViewInventoriesToolStripMenuItem.Name = "ViewInventoriesToolStripMenuItem"
        Me.ViewInventoriesToolStripMenuItem.Size = New System.Drawing.Size(56, 25)
        Me.ViewInventoriesToolStripMenuItem.Text = "View"
        '
        'EmployeeDetailsToolStripMenuItem
        '
        Me.EmployeeDetailsToolStripMenuItem.Name = "EmployeeDetailsToolStripMenuItem"
        Me.EmployeeDetailsToolStripMenuItem.Size = New System.Drawing.Size(218, 26)
        Me.EmployeeDetailsToolStripMenuItem.Text = "Part/Product Details"
        '
        'AllInventoriesToolStripMenuItem
        '
        Me.AllInventoriesToolStripMenuItem.Name = "AllInventoriesToolStripMenuItem"
        Me.AllInventoriesToolStripMenuItem.Size = New System.Drawing.Size(218, 26)
        Me.AllInventoriesToolStripMenuItem.Text = "All Inventories"
        '
        'INVENTORYLISTToolStripMenuItem
        '
        Me.INVENTORYLISTToolStripMenuItem.Name = "INVENTORYLISTToolStripMenuItem"
        Me.INVENTORYLISTToolStripMenuItem.Size = New System.Drawing.Size(142, 25)
        Me.INVENTORYLISTToolStripMenuItem.Text = "INVENTORY LIST:"
        '
        'AddInventoryToolStripMenuItem
        '
        Me.AddInventoryToolStripMenuItem.Name = "AddInventoryToolStripMenuItem"
        Me.AddInventoryToolStripMenuItem.Size = New System.Drawing.Size(50, 25)
        Me.AddInventoryToolStripMenuItem.Text = "Add"
        '
        'EditInventoryDetailsToolStripMenuItem
        '
        Me.EditInventoryDetailsToolStripMenuItem.Name = "EditInventoryDetailsToolStripMenuItem"
        Me.EditInventoryDetailsToolStripMenuItem.Size = New System.Drawing.Size(48, 25)
        Me.EditInventoryDetailsToolStripMenuItem.Text = "Edit"
        '
        'DeleteInventoryItemToolStripMenuItem
        '
        Me.DeleteInventoryItemToolStripMenuItem.Name = "DeleteInventoryItemToolStripMenuItem"
        Me.DeleteInventoryItemToolStripMenuItem.Size = New System.Drawing.Size(66, 25)
        Me.DeleteInventoryItemToolStripMenuItem.Text = "Delete"
        '
        'SaveInventoryDetailsToolStripMenuItem
        '
        Me.SaveInventoryDetailsToolStripMenuItem.Name = "SaveInventoryDetailsToolStripMenuItem"
        Me.SaveInventoryDetailsToolStripMenuItem.Size = New System.Drawing.Size(55, 25)
        Me.SaveInventoryDetailsToolStripMenuItem.Text = "Save"
        '
        'SubmitForApprovalToolStripMenuItem
        '
        Me.SubmitForApprovalToolStripMenuItem.Name = "SubmitForApprovalToolStripMenuItem"
        Me.SubmitForApprovalToolStripMenuItem.Size = New System.Drawing.Size(166, 25)
        Me.SubmitForApprovalToolStripMenuItem.Text = "Submit For Approval"
        '
        'ApproveToolStripMenuItem
        '
        Me.ApproveToolStripMenuItem.Name = "ApproveToolStripMenuItem"
        Me.ApproveToolStripMenuItem.Size = New System.Drawing.Size(81, 25)
        Me.ApproveToolStripMenuItem.Text = "Approve"
        '
        'RegisterInventoryToolStripMenuItem
        '
        Me.RegisterInventoryToolStripMenuItem.Name = "RegisterInventoryToolStripMenuItem"
        Me.RegisterInventoryToolStripMenuItem.Size = New System.Drawing.Size(149, 25)
        Me.RegisterInventoryToolStripMenuItem.Text = "Register Inventory"
        '
        'PrintInventoryToolStripMenuItem
        '
        Me.PrintInventoryToolStripMenuItem.Name = "PrintInventoryToolStripMenuItem"
        Me.PrintInventoryToolStripMenuItem.Size = New System.Drawing.Size(55, 25)
        Me.PrintInventoryToolStripMenuItem.Text = "Print"
        '
        'ResetForApprovalToolStripMenuItem
        '
        Me.ResetForApprovalToolStripMenuItem.Name = "ResetForApprovalToolStripMenuItem"
        Me.ResetForApprovalToolStripMenuItem.Size = New System.Drawing.Size(154, 25)
        Me.ResetForApprovalToolStripMenuItem.Text = "Reset For Approval"
        '
        'InventoryDetailsGroup
        '
        Me.InventoryDetailsGroup.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.InventoryDetailsGroup.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.InventoryDetailsGroup.Controls.Add(Me.Label3)
        Me.InventoryDetailsGroup.Controls.Add(Me.BulkBalanceUnitTextBox)
        Me.InventoryDetailsGroup.Controls.Add(Me.Label2)
        Me.InventoryDetailsGroup.Controls.Add(Me.BulkBalanceTextBox)
        Me.InventoryDetailsGroup.Controls.Add(Me.Label1)
        Me.InventoryDetailsGroup.Controls.Add(Me.ProductSpecificationTextBox)
        Me.InventoryDetailsGroup.Controls.Add(Me.PackingTextBox)
        Me.InventoryDetailsGroup.Controls.Add(Me.Label4)
        Me.InventoryDetailsGroup.Controls.Add(Me.LocationTextBox)
        Me.InventoryDetailsGroup.Controls.Add(Me.Label8)
        Me.InventoryDetailsGroup.Controls.Add(Me.Label6)
        Me.InventoryDetailsGroup.Controls.Add(Me.QtyInBasicUnitTextBox)
        Me.InventoryDetailsGroup.Controls.Add(Me.Label7)
        Me.InventoryDetailsGroup.Controls.Add(Me.BrandNameTextBox)
        Me.InventoryDetailsGroup.Controls.Add(Me.UnitTextBox)
        Me.InventoryDetailsGroup.Controls.Add(Me.Label14)
        Me.InventoryDetailsGroup.Controls.Add(Me.SystemPartDescriptionTextBox)
        Me.InventoryDetailsGroup.Controls.Add(Me.ManufacturerPartDescTextBox)
        Me.InventoryDetailsGroup.Controls.Add(Me.ManufacturerPartNoTextBox)
        Me.InventoryDetailsGroup.Controls.Add(Me.Label15)
        Me.InventoryDetailsGroup.Controls.Add(Me.Label16)
        Me.InventoryDetailsGroup.Controls.Add(Me.ManufacturerPartNoLabel)
        Me.InventoryDetailsGroup.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.InventoryDetailsGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InventoryDetailsGroup.Location = New System.Drawing.Point(380, 88)
        Me.InventoryDetailsGroup.Name = "InventoryDetailsGroup"
        Me.InventoryDetailsGroup.Size = New System.Drawing.Size(773, 417)
        Me.InventoryDetailsGroup.TabIndex = 99
        Me.InventoryDetailsGroup.TabStop = False
        Me.InventoryDetailsGroup.Text = "Stock Details"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 363)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 20)
        Me.Label3.TabIndex = 129
        Me.Label3.Text = "Unit / Packing"
        '
        'BulkBalanceUnitTextBox
        '
        Me.BulkBalanceUnitTextBox.Location = New System.Drawing.Point(383, 330)
        Me.BulkBalanceUnitTextBox.Name = "BulkBalanceUnitTextBox"
        Me.BulkBalanceUnitTextBox.ReadOnly = True
        Me.BulkBalanceUnitTextBox.Size = New System.Drawing.Size(98, 26)
        Me.BulkBalanceUnitTextBox.TabIndex = 128
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 304)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(248, 20)
        Me.Label2.TabIndex = 127
        Me.Label2.Text = "Qty in Basic Unit or Sealed packs)"
        '
        'BulkBalanceTextBox
        '
        Me.BulkBalanceTextBox.Location = New System.Drawing.Point(279, 329)
        Me.BulkBalanceTextBox.Name = "BulkBalanceTextBox"
        Me.BulkBalanceTextBox.Size = New System.Drawing.Size(98, 26)
        Me.BulkBalanceTextBox.TabIndex = 126
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 332)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(204, 20)
        Me.Label1.TabIndex = 125
        Me.Label1.Text = "Bulk Balance (unit in packs)"
        '
        'ProductSpecificationTextBox
        '
        Me.ProductSpecificationTextBox.Location = New System.Drawing.Point(279, 154)
        Me.ProductSpecificationTextBox.Name = "ProductSpecificationTextBox"
        Me.ProductSpecificationTextBox.ReadOnly = True
        Me.ProductSpecificationTextBox.Size = New System.Drawing.Size(353, 26)
        Me.ProductSpecificationTextBox.TabIndex = 124
        '
        'PackingTextBox
        '
        Me.PackingTextBox.Location = New System.Drawing.Point(279, 363)
        Me.PackingTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PackingTextBox.Name = "PackingTextBox"
        Me.PackingTextBox.ReadOnly = True
        Me.PackingTextBox.Size = New System.Drawing.Size(202, 26)
        Me.PackingTextBox.TabIndex = 119
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Britannic Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(7, 263)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 21)
        Me.Label4.TabIndex = 60
        Me.Label4.Text = "INVENTORY"
        '
        'LocationTextBox
        '
        Me.LocationTextBox.Location = New System.Drawing.Point(279, 216)
        Me.LocationTextBox.Name = "LocationTextBox"
        Me.LocationTextBox.ReadOnly = True
        Me.LocationTextBox.Size = New System.Drawing.Size(220, 26)
        Me.LocationTextBox.TabIndex = 58
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 160)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(257, 20)
        Me.Label8.TabIndex = 57
        Me.Label8.Text = "Minimum Quantity per Specification"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 222)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 20)
        Me.Label6.TabIndex = 56
        Me.Label6.Text = "Location"
        '
        'QtyInBasicUnitTextBox
        '
        Me.QtyInBasicUnitTextBox.Location = New System.Drawing.Point(279, 298)
        Me.QtyInBasicUnitTextBox.Name = "QtyInBasicUnitTextBox"
        Me.QtyInBasicUnitTextBox.Size = New System.Drawing.Size(98, 26)
        Me.QtyInBasicUnitTextBox.TabIndex = 55
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 284)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(156, 20)
        Me.Label7.TabIndex = 54
        Me.Label7.Text = "Available Quantities :"
        '
        'BrandNameTextBox
        '
        Me.BrandNameTextBox.Location = New System.Drawing.Point(279, 184)
        Me.BrandNameTextBox.Name = "BrandNameTextBox"
        Me.BrandNameTextBox.ReadOnly = True
        Me.BrandNameTextBox.Size = New System.Drawing.Size(220, 26)
        Me.BrandNameTextBox.TabIndex = 53
        '
        'UnitTextBox
        '
        Me.UnitTextBox.Location = New System.Drawing.Point(383, 298)
        Me.UnitTextBox.Name = "UnitTextBox"
        Me.UnitTextBox.ReadOnly = True
        Me.UnitTextBox.Size = New System.Drawing.Size(98, 26)
        Me.UnitTextBox.TabIndex = 48
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(7, 190)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(52, 20)
        Me.Label14.TabIndex = 46
        Me.Label14.Text = "Brand"
        '
        'SystemPartDescriptionTextBox
        '
        Me.SystemPartDescriptionTextBox.Location = New System.Drawing.Point(279, 16)
        Me.SystemPartDescriptionTextBox.Name = "SystemPartDescriptionTextBox"
        Me.SystemPartDescriptionTextBox.ReadOnly = True
        Me.SystemPartDescriptionTextBox.Size = New System.Drawing.Size(457, 26)
        Me.SystemPartDescriptionTextBox.TabIndex = 45
        '
        'ManufacturerPartDescTextBox
        '
        Me.ManufacturerPartDescTextBox.Location = New System.Drawing.Point(279, 78)
        Me.ManufacturerPartDescTextBox.Multiline = True
        Me.ManufacturerPartDescTextBox.Name = "ManufacturerPartDescTextBox"
        Me.ManufacturerPartDescTextBox.ReadOnly = True
        Me.ManufacturerPartDescTextBox.Size = New System.Drawing.Size(457, 68)
        Me.ManufacturerPartDescTextBox.TabIndex = 44
        '
        'ManufacturerPartNoTextBox
        '
        Me.ManufacturerPartNoTextBox.Location = New System.Drawing.Point(279, 47)
        Me.ManufacturerPartNoTextBox.Name = "ManufacturerPartNoTextBox"
        Me.ManufacturerPartNoTextBox.ReadOnly = True
        Me.ManufacturerPartNoTextBox.Size = New System.Drawing.Size(457, 26)
        Me.ManufacturerPartNoTextBox.TabIndex = 43
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(7, 22)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(238, 20)
        Me.Label15.TabIndex = 42
        Me.Label15.Text = "System Part/Product Description"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(7, 84)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(232, 20)
        Me.Label16.TabIndex = 41
        Me.Label16.Text = "Manufacturer's Part Description"
        '
        'ManufacturerPartNoLabel
        '
        Me.ManufacturerPartNoLabel.AutoSize = True
        Me.ManufacturerPartNoLabel.Location = New System.Drawing.Point(7, 53)
        Me.ManufacturerPartNoLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.ManufacturerPartNoLabel.Name = "ManufacturerPartNoLabel"
        Me.ManufacturerPartNoLabel.Size = New System.Drawing.Size(208, 20)
        Me.ManufacturerPartNoLabel.TabIndex = 40
        Me.ManufacturerPartNoLabel.Text = "Manufacturer's Part Number"
        '
        'InventoryItemsGroupBox
        '
        Me.InventoryItemsGroupBox.Controls.Add(Me.InventoryItemsDataGridView)
        Me.InventoryItemsGroupBox.Location = New System.Drawing.Point(28, 189)
        Me.InventoryItemsGroupBox.Name = "InventoryItemsGroupBox"
        Me.InventoryItemsGroupBox.Size = New System.Drawing.Size(308, 94)
        Me.InventoryItemsGroupBox.TabIndex = 100
        Me.InventoryItemsGroupBox.TabStop = False
        Me.InventoryItemsGroupBox.Text = "Inventory Items"
        '
        'InventoryItemsDataGridView
        '
        Me.InventoryItemsDataGridView.AllowUserToAddRows = False
        Me.InventoryItemsDataGridView.AllowUserToDeleteRows = False
        Me.InventoryItemsDataGridView.AllowUserToOrderColumns = True
        Me.InventoryItemsDataGridView.AllowUserToResizeRows = False
        Me.InventoryItemsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.InventoryItemsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.InventoryItemsDataGridView.Location = New System.Drawing.Point(3, 22)
        Me.InventoryItemsDataGridView.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.InventoryItemsDataGridView.MultiSelect = False
        Me.InventoryItemsDataGridView.Name = "InventoryItemsDataGridView"
        Me.InventoryItemsDataGridView.ReadOnly = True
        Me.InventoryItemsDataGridView.RowHeadersVisible = False
        Me.InventoryItemsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.InventoryItemsDataGridView.Size = New System.Drawing.Size(302, 69)
        Me.InventoryItemsDataGridView.TabIndex = 52
        '
        'InventoriesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1200, 692)
        Me.Controls.Add(Me.InventoryDetailsGroup)
        Me.Controls.Add(Me.InventoryItemsGroupBox)
        Me.Controls.Add(Me.InventoryHeadersGroupBox)
        Me.Controls.Add(Me.SearchToolStrip)
        Me.Controls.Add(Me.InventoriesFormMenuStrip)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "InventoriesForm"
        Me.Text = "InventoriesForm"
        Me.InventoryHeadersGroupBox.ResumeLayout(False)
        CType(Me.InventoryHeadersDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SearchToolStrip.ResumeLayout(False)
        Me.SearchToolStrip.PerformLayout()
        Me.InventoriesFormMenuStrip.ResumeLayout(False)
        Me.InventoriesFormMenuStrip.PerformLayout()
        Me.InventoryDetailsGroup.ResumeLayout(False)
        Me.InventoryDetailsGroup.PerformLayout()
        Me.InventoryItemsGroupBox.ResumeLayout(False)
        CType(Me.InventoryItemsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents InventoryHeadersGroupBox As GroupBox
    Friend WithEvents InventoryHeadersDataGridView As DataGridView
    Friend WithEvents SearchToolStrip As ToolStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents SearchMyStandardTextBox As ToolStripTextBox
    Friend WithEvents InventoriesFormMenuStrip As MenuStrip
    Friend WithEvents ReturnToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddInventoryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditInventoryDetailsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteInventoryItemToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewInventoriesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EmployeeDetailsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveInventoryDetailsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegisterInventoryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InventoryDetailsGroup As GroupBox
    Friend WithEvents ProductSpecificationTextBox As TextBox
    Friend WithEvents PackingTextBox As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents LocationTextBox As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents QtyInBasicUnitTextBox As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents BrandNameTextBox As MaskedTextBox
    Friend WithEvents UnitTextBox As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents SystemPartDescriptionTextBox As TextBox
    Friend WithEvents ManufacturerPartDescTextBox As TextBox
    Friend WithEvents ManufacturerPartNoTextBox As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents ManufacturerPartNoLabel As Label
    Friend WithEvents InventoryItemsGroupBox As GroupBox
    Friend WithEvents InventoryItemsDataGridView As DataGridView
    Friend WithEvents PrintInventoryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents INVENTORYLISTToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AllInventoriesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label2 As Label
    Friend WithEvents BulkBalanceTextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BulkBalanceUnitTextBox As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents SubmitForApprovalToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ApproveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ResetForApprovalToolStripMenuItem As ToolStripMenuItem
End Class
