<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StocksForm
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
        Me.ReturnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditProductDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteProductToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmployeeDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveProductDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StocksFormMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.InventoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegisterInventoryToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintSelectedStocksForInventoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddProductToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateProductInformationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegisterInventoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.SearchMyStandardTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.SearchToolStrip = New System.Windows.Forms.ToolStrip()
        Me.StocksDataGridView = New System.Windows.Forms.DataGridView()
        Me.StocksGroupBox = New System.Windows.Forms.GroupBox()
        Me.StockDetailsGroup = New System.Windows.Forms.GroupBox()
        Me.ProductSpecificationTextBox = New System.Windows.Forms.TextBox()
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
        Me.SpecificationInventoriesGroupBox = New System.Windows.Forms.GroupBox()
        Me.SpecificationsInventoriesDataGridView = New System.Windows.Forms.DataGridView()
        Me.StocksFormMenuStrip.SuspendLayout()
        Me.SearchToolStrip.SuspendLayout()
        CType(Me.StocksDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StocksGroupBox.SuspendLayout()
        Me.StockDetailsGroup.SuspendLayout()
        Me.SpecificationInventoriesGroupBox.SuspendLayout()
        CType(Me.SpecificationsInventoriesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReturnToolStripMenuItem
        '
        Me.ReturnToolStripMenuItem.Name = "ReturnToolStripMenuItem"
        Me.ReturnToolStripMenuItem.Size = New System.Drawing.Size(40, 25)
        Me.ReturnToolStripMenuItem.Text = "◄ "
        '
        'SelectToolStripMenuItem
        '
        Me.SelectToolStripMenuItem.Name = "SelectToolStripMenuItem"
        Me.SelectToolStripMenuItem.Size = New System.Drawing.Size(63, 25)
        Me.SelectToolStripMenuItem.Text = "Select"
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
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EmployeeDetailsToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(56, 25)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'EmployeeDetailsToolStripMenuItem
        '
        Me.EmployeeDetailsToolStripMenuItem.Name = "EmployeeDetailsToolStripMenuItem"
        Me.EmployeeDetailsToolStripMenuItem.Size = New System.Drawing.Size(197, 26)
        Me.EmployeeDetailsToolStripMenuItem.Text = "Employee details"
        '
        'SaveProductDetailsToolStripMenuItem
        '
        Me.SaveProductDetailsToolStripMenuItem.Name = "SaveProductDetailsToolStripMenuItem"
        Me.SaveProductDetailsToolStripMenuItem.Size = New System.Drawing.Size(55, 25)
        Me.SaveProductDetailsToolStripMenuItem.Text = "Save"
        Me.SaveProductDetailsToolStripMenuItem.Visible = False
        '
        'StocksFormMenuStrip
        '
        Me.StocksFormMenuStrip.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StocksFormMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReturnToolStripMenuItem, Me.SelectToolStripMenuItem, Me.InventoryToolStripMenuItem, Me.AddProductToolStripMenuItem, Me.EditProductDetailsToolStripMenuItem, Me.DeleteProductToolStripMenuItem, Me.ViewToolStripMenuItem, Me.SaveProductDetailsToolStripMenuItem, Me.UpdateProductInformationToolStripMenuItem, Me.RegisterInventoryToolStripMenuItem})
        Me.StocksFormMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.StocksFormMenuStrip.Name = "StocksFormMenuStrip"
        Me.StocksFormMenuStrip.Padding = New System.Windows.Forms.Padding(10, 3, 0, 3)
        Me.StocksFormMenuStrip.Size = New System.Drawing.Size(1200, 31)
        Me.StocksFormMenuStrip.TabIndex = 84
        Me.StocksFormMenuStrip.Text = "MenuStrip1"
        '
        'InventoryToolStripMenuItem
        '
        Me.InventoryToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegisterInventoryToolStripMenuItem1, Me.PrintSelectedStocksForInventoryToolStripMenuItem})
        Me.InventoryToolStripMenuItem.Name = "InventoryToolStripMenuItem"
        Me.InventoryToolStripMenuItem.Size = New System.Drawing.Size(88, 25)
        Me.InventoryToolStripMenuItem.Text = "Inventory"
        '
        'RegisterInventoryToolStripMenuItem1
        '
        Me.RegisterInventoryToolStripMenuItem1.Name = "RegisterInventoryToolStripMenuItem1"
        Me.RegisterInventoryToolStripMenuItem1.Size = New System.Drawing.Size(283, 26)
        Me.RegisterInventoryToolStripMenuItem1.Text = "Register Inventory"
        '
        'PrintSelectedStocksForInventoryToolStripMenuItem
        '
        Me.PrintSelectedStocksForInventoryToolStripMenuItem.Name = "PrintSelectedStocksForInventoryToolStripMenuItem"
        Me.PrintSelectedStocksForInventoryToolStripMenuItem.Size = New System.Drawing.Size(283, 26)
        Me.PrintSelectedStocksForInventoryToolStripMenuItem.Text = "Print Stocks list  for Inventory"
        '
        'AddProductToolStripMenuItem
        '
        Me.AddProductToolStripMenuItem.Name = "AddProductToolStripMenuItem"
        Me.AddProductToolStripMenuItem.Size = New System.Drawing.Size(50, 25)
        Me.AddProductToolStripMenuItem.Text = "Add"
        '
        'UpdateProductInformationToolStripMenuItem
        '
        Me.UpdateProductInformationToolStripMenuItem.Name = "UpdateProductInformationToolStripMenuItem"
        Me.UpdateProductInformationToolStripMenuItem.Size = New System.Drawing.Size(216, 25)
        Me.UpdateProductInformationToolStripMenuItem.Text = "Update Product Information"
        '
        'RegisterInventoryToolStripMenuItem
        '
        Me.RegisterInventoryToolStripMenuItem.Name = "RegisterInventoryToolStripMenuItem"
        Me.RegisterInventoryToolStripMenuItem.Size = New System.Drawing.Size(149, 25)
        Me.RegisterInventoryToolStripMenuItem.Text = "Register Inventory"
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
        'SearchToolStrip
        '
        Me.SearchToolStrip.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.SearchMyStandardTextBox})
        Me.SearchToolStrip.Location = New System.Drawing.Point(0, 31)
        Me.SearchToolStrip.Name = "SearchToolStrip"
        Me.SearchToolStrip.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.SearchToolStrip.Size = New System.Drawing.Size(1200, 29)
        Me.SearchToolStrip.TabIndex = 85
        Me.SearchToolStrip.Text = "ToolStrip1"
        '
        'StocksDataGridView
        '
        Me.StocksDataGridView.AllowUserToAddRows = False
        Me.StocksDataGridView.AllowUserToDeleteRows = False
        Me.StocksDataGridView.AllowUserToOrderColumns = True
        Me.StocksDataGridView.AllowUserToResizeRows = False
        Me.StocksDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.StocksDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.StocksDataGridView.Location = New System.Drawing.Point(3, 22)
        Me.StocksDataGridView.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.StocksDataGridView.MultiSelect = False
        Me.StocksDataGridView.Name = "StocksDataGridView"
        Me.StocksDataGridView.ReadOnly = True
        Me.StocksDataGridView.RowHeadersVisible = False
        Me.StocksDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.StocksDataGridView.Size = New System.Drawing.Size(261, 148)
        Me.StocksDataGridView.TabIndex = 52
        '
        'StocksGroupBox
        '
        Me.StocksGroupBox.Controls.Add(Me.StocksDataGridView)
        Me.StocksGroupBox.Location = New System.Drawing.Point(30, 213)
        Me.StocksGroupBox.Name = "StocksGroupBox"
        Me.StocksGroupBox.Size = New System.Drawing.Size(267, 173)
        Me.StocksGroupBox.TabIndex = 88
        Me.StocksGroupBox.TabStop = False
        Me.StocksGroupBox.Text = "All Store Stocks"
        '
        'StockDetailsGroup
        '
        Me.StockDetailsGroup.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.StockDetailsGroup.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.StockDetailsGroup.Controls.Add(Me.ProductSpecificationTextBox)
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
        Me.StockDetailsGroup.Location = New System.Drawing.Point(413, 101)
        Me.StockDetailsGroup.Name = "StockDetailsGroup"
        Me.StockDetailsGroup.Size = New System.Drawing.Size(742, 425)
        Me.StockDetailsGroup.TabIndex = 90
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
        'PackingTextBox
        '
        Me.PackingTextBox.Location = New System.Drawing.Point(279, 218)
        Me.PackingTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PackingTextBox.Name = "PackingTextBox"
        Me.PackingTextBox.ReadOnly = True
        Me.PackingTextBox.Size = New System.Drawing.Size(176, 26)
        Me.PackingTextBox.TabIndex = 119
        Me.PackingTextBox.Visible = False
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
        'SpecificationInventoriesGroupBox
        '
        Me.SpecificationInventoriesGroupBox.Controls.Add(Me.SpecificationsInventoriesDataGridView)
        Me.SpecificationInventoriesGroupBox.Location = New System.Drawing.Point(97, 419)
        Me.SpecificationInventoriesGroupBox.Name = "SpecificationInventoriesGroupBox"
        Me.SpecificationInventoriesGroupBox.Size = New System.Drawing.Size(267, 173)
        Me.SpecificationInventoriesGroupBox.TabIndex = 91
        Me.SpecificationInventoriesGroupBox.TabStop = False
        Me.SpecificationInventoriesGroupBox.Text = "This Product Specification Inventories"
        '
        'SpecificationsInventoriesDataGridView
        '
        Me.SpecificationsInventoriesDataGridView.AllowUserToAddRows = False
        Me.SpecificationsInventoriesDataGridView.AllowUserToDeleteRows = False
        Me.SpecificationsInventoriesDataGridView.AllowUserToOrderColumns = True
        Me.SpecificationsInventoriesDataGridView.AllowUserToResizeRows = False
        Me.SpecificationsInventoriesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.SpecificationsInventoriesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SpecificationsInventoriesDataGridView.Location = New System.Drawing.Point(3, 22)
        Me.SpecificationsInventoriesDataGridView.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.SpecificationsInventoriesDataGridView.MultiSelect = False
        Me.SpecificationsInventoriesDataGridView.Name = "SpecificationsInventoriesDataGridView"
        Me.SpecificationsInventoriesDataGridView.ReadOnly = True
        Me.SpecificationsInventoriesDataGridView.RowHeadersVisible = False
        Me.SpecificationsInventoriesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.SpecificationsInventoriesDataGridView.Size = New System.Drawing.Size(261, 148)
        Me.SpecificationsInventoriesDataGridView.TabIndex = 52
        '
        'StocksForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1200, 692)
        Me.Controls.Add(Me.StockDetailsGroup)
        Me.Controls.Add(Me.SpecificationInventoriesGroupBox)
        Me.Controls.Add(Me.StocksGroupBox)
        Me.Controls.Add(Me.SearchToolStrip)
        Me.Controls.Add(Me.StocksFormMenuStrip)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "StocksForm"
        Me.Text = "StocksForm"
        Me.StocksFormMenuStrip.ResumeLayout(False)
        Me.StocksFormMenuStrip.PerformLayout()
        Me.SearchToolStrip.ResumeLayout(False)
        Me.SearchToolStrip.PerformLayout()
        CType(Me.StocksDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StocksGroupBox.ResumeLayout(False)
        Me.StockDetailsGroup.ResumeLayout(False)
        Me.StockDetailsGroup.PerformLayout()
        Me.SpecificationInventoriesGroupBox.ResumeLayout(False)
        CType(Me.SpecificationsInventoriesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ReturnToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditProductDetailsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteProductToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EmployeeDetailsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveProductDetailsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StocksFormMenuStrip As MenuStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents SearchMyStandardTextBox As ToolStripTextBox
    Friend WithEvents SearchToolStrip As ToolStrip
    Friend WithEvents StocksDataGridView As DataGridView
    Friend WithEvents StocksGroupBox As GroupBox
    Friend WithEvents StockDetailsGroup As GroupBox
    Friend WithEvents ProductSpecificationTextBox As TextBox
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
    Friend WithEvents AddProductToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SpecificationInventoriesGroupBox As GroupBox
    Friend WithEvents SpecificationsInventoriesDataGridView As DataGridView
    Friend WithEvents UpdateProductInformationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InventoryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegisterInventoryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegisterInventoryToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents PrintSelectedStocksForInventoryToolStripMenuItem As ToolStripMenuItem
End Class
