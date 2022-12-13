<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.InventoriesGroupBox = New System.Windows.Forms.GroupBox()
        Me.InventoriesDataGridView = New System.Windows.Forms.DataGridView()
        Me.SearchToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.SearchMyStandardTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.StocksFormMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.ReturnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddProductToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditProductDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteProductToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmployeeDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveProductDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegisterInventoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StockDetailsGroup = New System.Windows.Forms.GroupBox()
        Me.ProductSpecificationTextBox = New System.Windows.Forms.TextBox()
        Me.PackingButton = New System.Windows.Forms.Button()
        Me.PackingTextBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.MinimumQuantityTextBox = New System.Windows.Forms.TextBox()
        Me.LocationTextBox = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.AvailableQuantitiesTextBox = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.BrandNameTextBox = New System.Windows.Forms.MaskedTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
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
        Me.INVENTORYLISTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllInventoriesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InventoriesGroupBox.SuspendLayout()
        CType(Me.InventoriesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SearchToolStrip.SuspendLayout()
        Me.StocksFormMenuStrip.SuspendLayout()
        Me.StockDetailsGroup.SuspendLayout()
        Me.InventoryItemsGroupBox.SuspendLayout()
        CType(Me.InventoryItemsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'InventoriesGroupBox
        '
        Me.InventoriesGroupBox.Controls.Add(Me.InventoriesDataGridView)
        Me.InventoriesGroupBox.Location = New System.Drawing.Point(25, 78)
        Me.InventoriesGroupBox.Name = "InventoriesGroupBox"
        Me.InventoriesGroupBox.Size = New System.Drawing.Size(311, 85)
        Me.InventoriesGroupBox.TabIndex = 95
        Me.InventoriesGroupBox.TabStop = False
        Me.InventoriesGroupBox.Text = "Outstanding Inventories"
        '
        'InventoriesDataGridView
        '
        Me.InventoriesDataGridView.AllowUserToAddRows = False
        Me.InventoriesDataGridView.AllowUserToDeleteRows = False
        Me.InventoriesDataGridView.AllowUserToOrderColumns = True
        Me.InventoriesDataGridView.AllowUserToResizeRows = False
        Me.InventoriesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.InventoriesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.InventoriesDataGridView.Location = New System.Drawing.Point(3, 22)
        Me.InventoriesDataGridView.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.InventoriesDataGridView.MultiSelect = False
        Me.InventoriesDataGridView.Name = "InventoriesDataGridView"
        Me.InventoriesDataGridView.ReadOnly = True
        Me.InventoriesDataGridView.RowHeadersVisible = False
        Me.InventoriesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.InventoriesDataGridView.Size = New System.Drawing.Size(305, 60)
        Me.InventoriesDataGridView.TabIndex = 52
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
        'StocksFormMenuStrip
        '
        Me.StocksFormMenuStrip.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StocksFormMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReturnToolStripMenuItem, Me.ViewToolStripMenuItem, Me.INVENTORYLISTToolStripMenuItem, Me.AddProductToolStripMenuItem, Me.EditProductDetailsToolStripMenuItem, Me.DeleteProductToolStripMenuItem, Me.SaveProductDetailsToolStripMenuItem, Me.RegisterInventoryToolStripMenuItem, Me.PrintToolStripMenuItem})
        Me.StocksFormMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.StocksFormMenuStrip.Name = "StocksFormMenuStrip"
        Me.StocksFormMenuStrip.Padding = New System.Windows.Forms.Padding(10, 3, 0, 3)
        Me.StocksFormMenuStrip.Size = New System.Drawing.Size(1200, 31)
        Me.StocksFormMenuStrip.TabIndex = 93
        Me.StocksFormMenuStrip.Text = "MenuStrip1"
        '
        'ReturnToolStripMenuItem
        '
        Me.ReturnToolStripMenuItem.Name = "ReturnToolStripMenuItem"
        Me.ReturnToolStripMenuItem.Size = New System.Drawing.Size(40, 25)
        Me.ReturnToolStripMenuItem.Text = "◄ "
        '
        'AddProductToolStripMenuItem
        '
        Me.AddProductToolStripMenuItem.Name = "AddProductToolStripMenuItem"
        Me.AddProductToolStripMenuItem.Size = New System.Drawing.Size(50, 25)
        Me.AddProductToolStripMenuItem.Text = "Add"
        '
        'EditProductDetailsToolStripMenuItem
        '
        Me.EditProductDetailsToolStripMenuItem.Name = "EditProductDetailsToolStripMenuItem"
        Me.EditProductDetailsToolStripMenuItem.Size = New System.Drawing.Size(48, 25)
        Me.EditProductDetailsToolStripMenuItem.Text = "Edit"
        '
        'DeleteProductToolStripMenuItem
        '
        Me.DeleteProductToolStripMenuItem.Name = "DeleteProductToolStripMenuItem"
        Me.DeleteProductToolStripMenuItem.Size = New System.Drawing.Size(66, 25)
        Me.DeleteProductToolStripMenuItem.Text = "Delete"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EmployeeDetailsToolStripMenuItem, Me.AllInventoriesToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(56, 25)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'EmployeeDetailsToolStripMenuItem
        '
        Me.EmployeeDetailsToolStripMenuItem.Name = "EmployeeDetailsToolStripMenuItem"
        Me.EmployeeDetailsToolStripMenuItem.Size = New System.Drawing.Size(218, 26)
        Me.EmployeeDetailsToolStripMenuItem.Text = "Part/Product Details"
        '
        'SaveProductDetailsToolStripMenuItem
        '
        Me.SaveProductDetailsToolStripMenuItem.Name = "SaveProductDetailsToolStripMenuItem"
        Me.SaveProductDetailsToolStripMenuItem.Size = New System.Drawing.Size(55, 25)
        Me.SaveProductDetailsToolStripMenuItem.Text = "Save"
        '
        'RegisterInventoryToolStripMenuItem
        '
        Me.RegisterInventoryToolStripMenuItem.Name = "RegisterInventoryToolStripMenuItem"
        Me.RegisterInventoryToolStripMenuItem.Size = New System.Drawing.Size(149, 25)
        Me.RegisterInventoryToolStripMenuItem.Text = "Register Inventory"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(55, 25)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'StockDetailsGroup
        '
        Me.StockDetailsGroup.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.StockDetailsGroup.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.StockDetailsGroup.Controls.Add(Me.ProductSpecificationTextBox)
        Me.StockDetailsGroup.Controls.Add(Me.PackingButton)
        Me.StockDetailsGroup.Controls.Add(Me.PackingTextBox)
        Me.StockDetailsGroup.Controls.Add(Me.Label4)
        Me.StockDetailsGroup.Controls.Add(Me.MinimumQuantityTextBox)
        Me.StockDetailsGroup.Controls.Add(Me.LocationTextBox)
        Me.StockDetailsGroup.Controls.Add(Me.Label8)
        Me.StockDetailsGroup.Controls.Add(Me.Label6)
        Me.StockDetailsGroup.Controls.Add(Me.AvailableQuantitiesTextBox)
        Me.StockDetailsGroup.Controls.Add(Me.Label7)
        Me.StockDetailsGroup.Controls.Add(Me.BrandNameTextBox)
        Me.StockDetailsGroup.Controls.Add(Me.Label12)
        Me.StockDetailsGroup.Controls.Add(Me.UnitTextBox)
        Me.StockDetailsGroup.Controls.Add(Me.Label14)
        Me.StockDetailsGroup.Controls.Add(Me.SystemPartDescriptionTextBox)
        Me.StockDetailsGroup.Controls.Add(Me.ManufacturerPartDescTextBox)
        Me.StockDetailsGroup.Controls.Add(Me.ManufacturerPartNoTextBox)
        Me.StockDetailsGroup.Controls.Add(Me.Label15)
        Me.StockDetailsGroup.Controls.Add(Me.Label16)
        Me.StockDetailsGroup.Controls.Add(Me.ManufacturerPartNoLabel)
        Me.StockDetailsGroup.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.StockDetailsGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StockDetailsGroup.Location = New System.Drawing.Point(415, 105)
        Me.StockDetailsGroup.Name = "StockDetailsGroup"
        Me.StockDetailsGroup.Size = New System.Drawing.Size(773, 471)
        Me.StockDetailsGroup.TabIndex = 99
        Me.StockDetailsGroup.TabStop = False
        Me.StockDetailsGroup.Text = "Stock Details"
        Me.StockDetailsGroup.Visible = False
        '
        'ProductSpecificationTextBox
        '
        Me.ProductSpecificationTextBox.Location = New System.Drawing.Point(383, 344)
        Me.ProductSpecificationTextBox.Name = "ProductSpecificationTextBox"
        Me.ProductSpecificationTextBox.ReadOnly = True
        Me.ProductSpecificationTextBox.Size = New System.Drawing.Size(353, 26)
        Me.ProductSpecificationTextBox.TabIndex = 124
        '
        'PackingButton
        '
        Me.PackingButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PackingButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.PackingButton.Location = New System.Drawing.Point(11, 212)
        Me.PackingButton.Name = "PackingButton"
        Me.PackingButton.Size = New System.Drawing.Size(131, 40)
        Me.PackingButton.TabIndex = 120
        Me.PackingButton.Text = "Packing"
        Me.PackingButton.UseVisualStyleBackColor = True
        '
        'PackingTextBox
        '
        Me.PackingTextBox.Location = New System.Drawing.Point(279, 218)
        Me.PackingTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PackingTextBox.Name = "PackingTextBox"
        Me.PackingTextBox.ReadOnly = True
        Me.PackingTextBox.Size = New System.Drawing.Size(176, 26)
        Me.PackingTextBox.TabIndex = 119
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Britannic Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(294, 281)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 21)
        Me.Label4.TabIndex = 60
        Me.Label4.Text = "INVENTORY"
        '
        'MinimumQuantityTextBox
        '
        Me.MinimumQuantityTextBox.Location = New System.Drawing.Point(279, 344)
        Me.MinimumQuantityTextBox.Multiline = True
        Me.MinimumQuantityTextBox.Name = "MinimumQuantityTextBox"
        Me.MinimumQuantityTextBox.Size = New System.Drawing.Size(98, 26)
        Me.MinimumQuantityTextBox.TabIndex = 59
        '
        'LocationTextBox
        '
        Me.LocationTextBox.Location = New System.Drawing.Point(279, 376)
        Me.LocationTextBox.Name = "LocationTextBox"
        Me.LocationTextBox.Size = New System.Drawing.Size(98, 26)
        Me.LocationTextBox.TabIndex = 58
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 350)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(257, 20)
        Me.Label8.TabIndex = 57
        Me.Label8.Text = "Minimum Quantity per Specification"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 382)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 20)
        Me.Label6.TabIndex = 56
        Me.Label6.Text = "Location"
        '
        'AvailableQuantitiesTextBox
        '
        Me.AvailableQuantitiesTextBox.Enabled = False
        Me.AvailableQuantitiesTextBox.Location = New System.Drawing.Point(279, 312)
        Me.AvailableQuantitiesTextBox.Name = "AvailableQuantitiesTextBox"
        Me.AvailableQuantitiesTextBox.Size = New System.Drawing.Size(98, 26)
        Me.AvailableQuantitiesTextBox.TabIndex = 55
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 318)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(148, 20)
        Me.Label7.TabIndex = 54
        Me.Label7.Text = "Available Quantities"
        '
        'BrandNameTextBox
        '
        Me.BrandNameTextBox.Location = New System.Drawing.Point(279, 152)
        Me.BrandNameTextBox.Name = "BrandNameTextBox"
        Me.BrandNameTextBox.ReadOnly = True
        Me.BrandNameTextBox.Size = New System.Drawing.Size(220, 26)
        Me.BrandNameTextBox.TabIndex = 53
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(10, 186)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(38, 20)
        Me.Label12.TabIndex = 49
        Me.Label12.Text = "Unit"
        '
        'UnitTextBox
        '
        Me.UnitTextBox.Location = New System.Drawing.Point(279, 186)
        Me.UnitTextBox.Name = "UnitTextBox"
        Me.UnitTextBox.ReadOnly = True
        Me.UnitTextBox.Size = New System.Drawing.Size(98, 26)
        Me.UnitTextBox.TabIndex = 48
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(7, 158)
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
        'INVENTORYLISTToolStripMenuItem
        '
        Me.INVENTORYLISTToolStripMenuItem.Name = "INVENTORYLISTToolStripMenuItem"
        Me.INVENTORYLISTToolStripMenuItem.Size = New System.Drawing.Size(142, 25)
        Me.INVENTORYLISTToolStripMenuItem.Text = "INVENTORY LIST:"
        '
        'AllInventoriesToolStripMenuItem
        '
        Me.AllInventoriesToolStripMenuItem.Name = "AllInventoriesToolStripMenuItem"
        Me.AllInventoriesToolStripMenuItem.Size = New System.Drawing.Size(218, 26)
        Me.AllInventoriesToolStripMenuItem.Text = "All Inventories"
        '
        'InventoriesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1200, 692)
        Me.Controls.Add(Me.InventoryItemsGroupBox)
        Me.Controls.Add(Me.StockDetailsGroup)
        Me.Controls.Add(Me.InventoriesGroupBox)
        Me.Controls.Add(Me.SearchToolStrip)
        Me.Controls.Add(Me.StocksFormMenuStrip)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "InventoriesForm"
        Me.Text = "InventoriesForm"
        Me.InventoriesGroupBox.ResumeLayout(False)
        CType(Me.InventoriesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SearchToolStrip.ResumeLayout(False)
        Me.SearchToolStrip.PerformLayout()
        Me.StocksFormMenuStrip.ResumeLayout(False)
        Me.StocksFormMenuStrip.PerformLayout()
        Me.StockDetailsGroup.ResumeLayout(False)
        Me.StockDetailsGroup.PerformLayout()
        Me.InventoryItemsGroupBox.ResumeLayout(False)
        CType(Me.InventoryItemsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents InventoriesGroupBox As GroupBox
    Friend WithEvents InventoriesDataGridView As DataGridView
    Friend WithEvents SearchToolStrip As ToolStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents SearchMyStandardTextBox As ToolStripTextBox
    Friend WithEvents StocksFormMenuStrip As MenuStrip
    Friend WithEvents ReturnToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddProductToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditProductDetailsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteProductToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EmployeeDetailsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveProductDetailsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegisterInventoryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StockDetailsGroup As GroupBox
    Friend WithEvents ProductSpecificationTextBox As TextBox
    Friend WithEvents PackingButton As Button
    Friend WithEvents PackingTextBox As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents MinimumQuantityTextBox As TextBox
    Friend WithEvents LocationTextBox As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents AvailableQuantitiesTextBox As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents BrandNameTextBox As MaskedTextBox
    Friend WithEvents Label12 As Label
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
    Friend WithEvents PrintToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents INVENTORYLISTToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AllInventoriesToolStripMenuItem As ToolStripMenuItem
End Class
