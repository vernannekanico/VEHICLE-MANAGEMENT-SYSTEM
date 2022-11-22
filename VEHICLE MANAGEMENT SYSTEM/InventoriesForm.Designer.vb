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
        Me.ReturnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddProductToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditProductToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteProductToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmployeeDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveProductToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MyStandardsFormMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.SearchMyStandardTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.SearchToolStrip = New System.Windows.Forms.ToolStrip()
        Me.InventoriesDataGridView = New System.Windows.Forms.DataGridView()
        Me.InventoriesGroupBox = New System.Windows.Forms.GroupBox()
        Me.ProductDetailsGroup = New System.Windows.Forms.GroupBox()
        Me.ProductSpecificationTextBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PartSpecificationTextBox = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PackingButton = New System.Windows.Forms.Button()
        Me.PackingTextBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.MinimumQantityTextBox = New System.Windows.Forms.TextBox()
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
        Me.MyStandardsFormMenuStrip.SuspendLayout()
        Me.SearchToolStrip.SuspendLayout()
        CType(Me.InventoriesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.InventoriesGroupBox.SuspendLayout()
        Me.ProductDetailsGroup.SuspendLayout()
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
        'AddProductToolStripMenuItem
        '
        Me.AddProductToolStripMenuItem.Name = "AddProductToolStripMenuItem"
        Me.AddProductToolStripMenuItem.Size = New System.Drawing.Size(50, 25)
        Me.AddProductToolStripMenuItem.Text = "Add"
        '
        'EditProductToolStripMenuItem
        '
        Me.EditProductToolStripMenuItem.Name = "EditProductToolStripMenuItem"
        Me.EditProductToolStripMenuItem.Size = New System.Drawing.Size(48, 25)
        Me.EditProductToolStripMenuItem.Text = "Edit"
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
        'SaveProductToolStripMenuItem
        '
        Me.SaveProductToolStripMenuItem.Name = "SaveProductToolStripMenuItem"
        Me.SaveProductToolStripMenuItem.Size = New System.Drawing.Size(55, 25)
        Me.SaveProductToolStripMenuItem.Text = "Save"
        '
        'MyStandardsFormMenuStrip
        '
        Me.MyStandardsFormMenuStrip.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyStandardsFormMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReturnToolStripMenuItem, Me.SelectToolStripMenuItem, Me.AddProductToolStripMenuItem, Me.EditProductToolStripMenuItem, Me.DeleteProductToolStripMenuItem, Me.ViewToolStripMenuItem, Me.SaveProductToolStripMenuItem})
        Me.MyStandardsFormMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MyStandardsFormMenuStrip.Name = "MyStandardsFormMenuStrip"
        Me.MyStandardsFormMenuStrip.Padding = New System.Windows.Forms.Padding(10, 3, 0, 3)
        Me.MyStandardsFormMenuStrip.Size = New System.Drawing.Size(1200, 31)
        Me.MyStandardsFormMenuStrip.TabIndex = 84
        Me.MyStandardsFormMenuStrip.Text = "MenuStrip1"
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
        Me.InventoriesDataGridView.Size = New System.Drawing.Size(261, 148)
        Me.InventoriesDataGridView.TabIndex = 52
        '
        'InventoriesGroupBox
        '
        Me.InventoriesGroupBox.Controls.Add(Me.InventoriesDataGridView)
        Me.InventoriesGroupBox.Location = New System.Drawing.Point(30, 213)
        Me.InventoriesGroupBox.Name = "InventoriesGroupBox"
        Me.InventoriesGroupBox.Size = New System.Drawing.Size(267, 173)
        Me.InventoriesGroupBox.TabIndex = 88
        Me.InventoriesGroupBox.TabStop = False
        Me.InventoriesGroupBox.Text = "Inventories"
        '
        'ProductDetailsGroup
        '
        Me.ProductDetailsGroup.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ProductDetailsGroup.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ProductDetailsGroup.Controls.Add(Me.ProductSpecificationTextBox)
        Me.ProductDetailsGroup.Controls.Add(Me.Label3)
        Me.ProductDetailsGroup.Controls.Add(Me.PartSpecificationTextBox)
        Me.ProductDetailsGroup.Controls.Add(Me.Label5)
        Me.ProductDetailsGroup.Controls.Add(Me.PackingButton)
        Me.ProductDetailsGroup.Controls.Add(Me.PackingTextBox)
        Me.ProductDetailsGroup.Controls.Add(Me.Label4)
        Me.ProductDetailsGroup.Controls.Add(Me.MinimumQantityTextBox)
        Me.ProductDetailsGroup.Controls.Add(Me.LocationTextBox)
        Me.ProductDetailsGroup.Controls.Add(Me.Label8)
        Me.ProductDetailsGroup.Controls.Add(Me.Label6)
        Me.ProductDetailsGroup.Controls.Add(Me.AvailableQuantitiesTextBox)
        Me.ProductDetailsGroup.Controls.Add(Me.Label7)
        Me.ProductDetailsGroup.Controls.Add(Me.BrandNameTextBox)
        Me.ProductDetailsGroup.Controls.Add(Me.Label12)
        Me.ProductDetailsGroup.Controls.Add(Me.UnitTextBox)
        Me.ProductDetailsGroup.Controls.Add(Me.Label14)
        Me.ProductDetailsGroup.Controls.Add(Me.SystemPartDescriptionTextBox)
        Me.ProductDetailsGroup.Controls.Add(Me.ManufacturerPartDescTextBox)
        Me.ProductDetailsGroup.Controls.Add(Me.ManufacturerPartNoTextBox)
        Me.ProductDetailsGroup.Controls.Add(Me.Label15)
        Me.ProductDetailsGroup.Controls.Add(Me.Label16)
        Me.ProductDetailsGroup.Controls.Add(Me.ManufacturerPartNoLabel)
        Me.ProductDetailsGroup.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ProductDetailsGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProductDetailsGroup.Location = New System.Drawing.Point(413, 101)
        Me.ProductDetailsGroup.Name = "ProductDetailsGroup"
        Me.ProductDetailsGroup.Size = New System.Drawing.Size(742, 491)
        Me.ProductDetailsGroup.TabIndex = 90
        Me.ProductDetailsGroup.TabStop = False
        Me.ProductDetailsGroup.Text = "Product Details"
        Me.ProductDetailsGroup.Visible = False
        '
        'ProductSpecificationTextBox
        '
        Me.ProductSpecificationTextBox.Location = New System.Drawing.Point(279, 201)
        Me.ProductSpecificationTextBox.Name = "ProductSpecificationTextBox"
        Me.ProductSpecificationTextBox.ReadOnly = True
        Me.ProductSpecificationTextBox.Size = New System.Drawing.Size(457, 26)
        Me.ProductSpecificationTextBox.TabIndex = 124
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 207)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(163, 20)
        Me.Label3.TabIndex = 123
        Me.Label3.Text = "Product  Specification"
        '
        'PartSpecificationTextBox
        '
        Me.PartSpecificationTextBox.Enabled = False
        Me.PartSpecificationTextBox.Location = New System.Drawing.Point(279, 49)
        Me.PartSpecificationTextBox.Name = "PartSpecificationTextBox"
        Me.PartSpecificationTextBox.ReadOnly = True
        Me.PartSpecificationTextBox.Size = New System.Drawing.Size(457, 26)
        Me.PartSpecificationTextBox.TabIndex = 122
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 55)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(133, 20)
        Me.Label5.TabIndex = 121
        Me.Label5.Text = "Part Specification"
        '
        'PackingButton
        '
        Me.PackingButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PackingButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.PackingButton.Location = New System.Drawing.Point(11, 296)
        Me.PackingButton.Name = "PackingButton"
        Me.PackingButton.Size = New System.Drawing.Size(131, 40)
        Me.PackingButton.TabIndex = 120
        Me.PackingButton.Text = "Packing"
        Me.PackingButton.UseVisualStyleBackColor = True
        '
        'PackingTextBox
        '
        Me.PackingTextBox.Enabled = False
        Me.PackingTextBox.Location = New System.Drawing.Point(279, 302)
        Me.PackingTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PackingTextBox.Name = "PackingTextBox"
        Me.PackingTextBox.Size = New System.Drawing.Size(176, 26)
        Me.PackingTextBox.TabIndex = 119
        Me.PackingTextBox.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Britannic Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(7, 345)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 21)
        Me.Label4.TabIndex = 60
        Me.Label4.Text = "INVENTORY"
        '
        'MinimumQantityTextBox
        '
        Me.MinimumQantityTextBox.Location = New System.Drawing.Point(279, 411)
        Me.MinimumQantityTextBox.Multiline = True
        Me.MinimumQantityTextBox.Name = "MinimumQantityTextBox"
        Me.MinimumQantityTextBox.Size = New System.Drawing.Size(98, 26)
        Me.MinimumQantityTextBox.TabIndex = 59
        '
        'LocationTextBox
        '
        Me.LocationTextBox.Location = New System.Drawing.Point(279, 443)
        Me.LocationTextBox.Name = "LocationTextBox"
        Me.LocationTextBox.Size = New System.Drawing.Size(98, 26)
        Me.LocationTextBox.TabIndex = 58
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 417)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(135, 20)
        Me.Label8.TabIndex = 57
        Me.Label8.Text = "Minimum Quantity"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 449)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 20)
        Me.Label6.TabIndex = 56
        Me.Label6.Text = "Location"
        '
        'AvailableQuantitiesTextBox
        '
        Me.AvailableQuantitiesTextBox.Enabled = False
        Me.AvailableQuantitiesTextBox.Location = New System.Drawing.Point(279, 379)
        Me.AvailableQuantitiesTextBox.Name = "AvailableQuantitiesTextBox"
        Me.AvailableQuantitiesTextBox.Size = New System.Drawing.Size(98, 26)
        Me.AvailableQuantitiesTextBox.TabIndex = 55
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 385)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(148, 20)
        Me.Label7.TabIndex = 54
        Me.Label7.Text = "Available Quantities"
        '
        'BrandNameTextBox
        '
        Me.BrandNameTextBox.Location = New System.Drawing.Point(279, 236)
        Me.BrandNameTextBox.Name = "BrandNameTextBox"
        Me.BrandNameTextBox.Size = New System.Drawing.Size(220, 26)
        Me.BrandNameTextBox.TabIndex = 53
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(10, 270)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(38, 20)
        Me.Label12.TabIndex = 49
        Me.Label12.Text = "Unit"
        '
        'UnitTextBox
        '
        Me.UnitTextBox.Location = New System.Drawing.Point(279, 270)
        Me.UnitTextBox.Name = "UnitTextBox"
        Me.UnitTextBox.Size = New System.Drawing.Size(98, 26)
        Me.UnitTextBox.TabIndex = 48
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(7, 242)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(52, 20)
        Me.Label14.TabIndex = 46
        Me.Label14.Text = "Brand"
        '
        'SystemPartDescriptionTextBox
        '
        Me.SystemPartDescriptionTextBox.Enabled = False
        Me.SystemPartDescriptionTextBox.Location = New System.Drawing.Point(279, 16)
        Me.SystemPartDescriptionTextBox.Name = "SystemPartDescriptionTextBox"
        Me.SystemPartDescriptionTextBox.Size = New System.Drawing.Size(457, 26)
        Me.SystemPartDescriptionTextBox.TabIndex = 45
        '
        'ManufacturerPartDescTextBox
        '
        Me.ManufacturerPartDescTextBox.Location = New System.Drawing.Point(279, 125)
        Me.ManufacturerPartDescTextBox.Multiline = True
        Me.ManufacturerPartDescTextBox.Name = "ManufacturerPartDescTextBox"
        Me.ManufacturerPartDescTextBox.Size = New System.Drawing.Size(457, 68)
        Me.ManufacturerPartDescTextBox.TabIndex = 44
        '
        'ManufacturerPartNoTextBox
        '
        Me.ManufacturerPartNoTextBox.Enabled = False
        Me.ManufacturerPartNoTextBox.Location = New System.Drawing.Point(279, 94)
        Me.ManufacturerPartNoTextBox.Name = "ManufacturerPartNoTextBox"
        Me.ManufacturerPartNoTextBox.Size = New System.Drawing.Size(457, 26)
        Me.ManufacturerPartNoTextBox.TabIndex = 43
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(7, 22)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(179, 20)
        Me.Label15.TabIndex = 42
        Me.Label15.Text = "System Part Description"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(7, 131)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(232, 20)
        Me.Label16.TabIndex = 41
        Me.Label16.Text = "Manufacturer's Part Description"
        '
        'ManufacturerPartNoLabel
        '
        Me.ManufacturerPartNoLabel.AutoSize = True
        Me.ManufacturerPartNoLabel.Location = New System.Drawing.Point(7, 100)
        Me.ManufacturerPartNoLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.ManufacturerPartNoLabel.Name = "ManufacturerPartNoLabel"
        Me.ManufacturerPartNoLabel.Size = New System.Drawing.Size(208, 20)
        Me.ManufacturerPartNoLabel.TabIndex = 40
        Me.ManufacturerPartNoLabel.Text = "Manufacturer's Part Number"
        '
        'InventoryForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1200, 692)
        Me.Controls.Add(Me.ProductDetailsGroup)
        Me.Controls.Add(Me.InventoriesGroupBox)
        Me.Controls.Add(Me.SearchToolStrip)
        Me.Controls.Add(Me.MyStandardsFormMenuStrip)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "InventoryForm"
        Me.Text = "InventoryForm"
        Me.MyStandardsFormMenuStrip.ResumeLayout(False)
        Me.MyStandardsFormMenuStrip.PerformLayout()
        Me.SearchToolStrip.ResumeLayout(False)
        Me.SearchToolStrip.PerformLayout()
        CType(Me.InventoriesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.InventoriesGroupBox.ResumeLayout(False)
        Me.ProductDetailsGroup.ResumeLayout(False)
        Me.ProductDetailsGroup.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ReturnToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddProductToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditProductToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteProductToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EmployeeDetailsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveProductToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MyStandardsFormMenuStrip As MenuStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents SearchMyStandardTextBox As ToolStripTextBox
    Friend WithEvents SearchToolStrip As ToolStrip
    Friend WithEvents InventoriesDataGridView As DataGridView
    Friend WithEvents InventoriesGroupBox As GroupBox
    Friend WithEvents ProductDetailsGroup As GroupBox
    Friend WithEvents ProductSpecificationTextBox As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents PartSpecificationTextBox As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents PackingButton As Button
    Friend WithEvents PackingTextBox As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents MinimumQantityTextBox As TextBox
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
End Class
