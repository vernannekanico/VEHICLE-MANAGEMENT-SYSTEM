<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ProductsPartsForm
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ActivatedByTextBox = New System.Windows.Forms.TextBox()
        Me.ProductsPartsDataGridView = New System.Windows.Forms.DataGridView()
        Me.ProductsPartsMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.PARTSPRODUCTSMENUToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateMasterCodeLinkToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchDescriptionToolStripTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.SearchPartNumberToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PartNoToolStripTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.SearchDescriptionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VehicleFilterToolStripTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.ToggleVehiclefilterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StocksMenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductDetailsGroup = New System.Windows.Forms.GroupBox()
        Me.PackingButton = New System.Windows.Forms.Button()
        Me.PackingTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MinimumQantityTextBox = New System.Windows.Forms.TextBox()
        Me.LocationTextBox = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.AvailableQuantitiesTextBox = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.BrandNameTextBox = New System.Windows.Forms.MaskedTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.UnitTextBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SystemPartDescriptionTextBox = New System.Windows.Forms.TextBox()
        Me.ManufacturerPartDescTextBox = New System.Windows.Forms.TextBox()
        Me.ManufacturerPartNoTextBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ManufacturerPartNoLabel = New System.Windows.Forms.Label()
        Me.CancelMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.CancelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.ProductsPartsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ProductsPartsMenuStrip.SuspendLayout()
        Me.ProductDetailsGroup.SuspendLayout()
        Me.CancelMenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'ActivatedByTextBox
        '
        Me.ActivatedByTextBox.Location = New System.Drawing.Point(49, 375)
        Me.ActivatedByTextBox.Margin = New System.Windows.Forms.Padding(8)
        Me.ActivatedByTextBox.Name = "ActivatedByTextBox"
        Me.ActivatedByTextBox.Size = New System.Drawing.Size(156, 20)
        Me.ActivatedByTextBox.TabIndex = 87
        Me.ActivatedByTextBox.Text = "ActivatedBy"
        Me.ActivatedByTextBox.Visible = False
        '
        'ProductsPartsDataGridView
        '
        Me.ProductsPartsDataGridView.AllowUserToAddRows = False
        Me.ProductsPartsDataGridView.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProductsPartsDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.ProductsPartsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ProductsPartsDataGridView.DefaultCellStyle = DataGridViewCellStyle5
        Me.ProductsPartsDataGridView.Location = New System.Drawing.Point(150, 76)
        Me.ProductsPartsDataGridView.Margin = New System.Windows.Forms.Padding(10, 12, 10, 12)
        Me.ProductsPartsDataGridView.Name = "ProductsPartsDataGridView"
        Me.ProductsPartsDataGridView.ReadOnly = True
        Me.ProductsPartsDataGridView.RowHeadersVisible = False
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ProductsPartsDataGridView.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.ProductsPartsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ProductsPartsDataGridView.Size = New System.Drawing.Size(441, 210)
        Me.ProductsPartsDataGridView.TabIndex = 86
        '
        'ProductsPartsMenuStrip
        '
        Me.ProductsPartsMenuStrip.Dock = System.Windows.Forms.DockStyle.None
        Me.ProductsPartsMenuStrip.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProductsPartsMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PARTSPRODUCTSMENUToolStripMenuItem, Me.SelectToolStripMenuItem, Me.UpdateMasterCodeLinkToolStripMenuItem, Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.SaveToolStripMenuItem, Me.ToolStripMenuItem1, Me.SearchDescriptionToolStripTextBox, Me.SearchPartNumberToolStripMenuItem, Me.PartNoToolStripTextBox, Me.SearchDescriptionToolStripMenuItem, Me.VehicleFilterToolStripTextBox, Me.ToggleVehiclefilterToolStripMenuItem, Me.StocksMenuToolStripMenuItem})
        Me.ProductsPartsMenuStrip.Location = New System.Drawing.Point(69, 0)
        Me.ProductsPartsMenuStrip.Name = "ProductsPartsMenuStrip"
        Me.ProductsPartsMenuStrip.Padding = New System.Windows.Forms.Padding(15, 5, 0, 5)
        Me.ProductsPartsMenuStrip.Size = New System.Drawing.Size(1590, 36)
        Me.ProductsPartsMenuStrip.TabIndex = 88
        Me.ProductsPartsMenuStrip.Text = "MenuStrip1"
        '
        'PARTSPRODUCTSMENUToolStripMenuItem
        '
        Me.PARTSPRODUCTSMENUToolStripMenuItem.Name = "PARTSPRODUCTSMENUToolStripMenuItem"
        Me.PARTSPRODUCTSMENUToolStripMenuItem.Size = New System.Drawing.Size(204, 26)
        Me.PARTSPRODUCTSMENUToolStripMenuItem.Text = "PARTS/PRODUCTS MENU:"
        '
        'SelectToolStripMenuItem
        '
        Me.SelectToolStripMenuItem.Name = "SelectToolStripMenuItem"
        Me.SelectToolStripMenuItem.Size = New System.Drawing.Size(63, 26)
        Me.SelectToolStripMenuItem.Text = "Select"
        '
        'UpdateMasterCodeLinkToolStripMenuItem
        '
        Me.UpdateMasterCodeLinkToolStripMenuItem.Name = "UpdateMasterCodeLinkToolStripMenuItem"
        Me.UpdateMasterCodeLinkToolStripMenuItem.Size = New System.Drawing.Size(197, 26)
        Me.UpdateMasterCodeLinkToolStripMenuItem.Text = "Update Master Code Link"
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(50, 26)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(48, 26)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(66, 26)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(55, 26)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(128, 26)
        Me.ToolStripMenuItem1.Text = "PartDescription"
        '
        'SearchDescriptionToolStripTextBox
        '
        Me.SearchDescriptionToolStripTextBox.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.SearchDescriptionToolStripTextBox.Name = "SearchDescriptionToolStripTextBox"
        Me.SearchDescriptionToolStripTextBox.Size = New System.Drawing.Size(100, 26)
        '
        'SearchPartNumberToolStripMenuItem
        '
        Me.SearchPartNumberToolStripMenuItem.Name = "SearchPartNumberToolStripMenuItem"
        Me.SearchPartNumberToolStripMenuItem.Size = New System.Drawing.Size(107, 26)
        Me.SearchPartNumberToolStripMenuItem.Text = "PartNumber"
        '
        'PartNoToolStripTextBox
        '
        Me.PartNoToolStripTextBox.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.PartNoToolStripTextBox.Name = "PartNoToolStripTextBox"
        Me.PartNoToolStripTextBox.Size = New System.Drawing.Size(100, 26)
        '
        'SearchDescriptionToolStripMenuItem
        '
        Me.SearchDescriptionToolStripMenuItem.Name = "SearchDescriptionToolStripMenuItem"
        Me.SearchDescriptionToolStripMenuItem.Size = New System.Drawing.Size(69, 26)
        Me.SearchDescriptionToolStripMenuItem.Text = "Search"
        '
        'VehicleFilterToolStripTextBox
        '
        Me.VehicleFilterToolStripTextBox.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.VehicleFilterToolStripTextBox.Name = "VehicleFilterToolStripTextBox"
        Me.VehicleFilterToolStripTextBox.Size = New System.Drawing.Size(200, 26)
        Me.VehicleFilterToolStripTextBox.Text = "VehicleFilterToolStripTextBox"
        '
        'ToggleVehiclefilterToolStripMenuItem
        '
        Me.ToggleVehiclefilterToolStripMenuItem.Name = "ToggleVehiclefilterToolStripMenuItem"
        Me.ToggleVehiclefilterToolStripMenuItem.Size = New System.Drawing.Size(50, 26)
        Me.ToggleVehiclefilterToolStripMenuItem.Text = "OFF"
        '
        'StocksMenuToolStripMenuItem
        '
        Me.StocksMenuToolStripMenuItem.Name = "StocksMenuToolStripMenuItem"
        Me.StocksMenuToolStripMenuItem.Size = New System.Drawing.Size(130, 26)
        Me.StocksMenuToolStripMenuItem.Text = "STOCKS MENU:"
        '
        'ProductDetailsGroup
        '
        Me.ProductDetailsGroup.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ProductDetailsGroup.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ProductDetailsGroup.Controls.Add(Me.PackingButton)
        Me.ProductDetailsGroup.Controls.Add(Me.PackingTextBox)
        Me.ProductDetailsGroup.Controls.Add(Me.Label1)
        Me.ProductDetailsGroup.Controls.Add(Me.MinimumQantityTextBox)
        Me.ProductDetailsGroup.Controls.Add(Me.LocationTextBox)
        Me.ProductDetailsGroup.Controls.Add(Me.Label8)
        Me.ProductDetailsGroup.Controls.Add(Me.Label9)
        Me.ProductDetailsGroup.Controls.Add(Me.AvailableQuantitiesTextBox)
        Me.ProductDetailsGroup.Controls.Add(Me.Label7)
        Me.ProductDetailsGroup.Controls.Add(Me.BrandNameTextBox)
        Me.ProductDetailsGroup.Controls.Add(Me.Label6)
        Me.ProductDetailsGroup.Controls.Add(Me.UnitTextBox)
        Me.ProductDetailsGroup.Controls.Add(Me.Label4)
        Me.ProductDetailsGroup.Controls.Add(Me.SystemPartDescriptionTextBox)
        Me.ProductDetailsGroup.Controls.Add(Me.ManufacturerPartDescTextBox)
        Me.ProductDetailsGroup.Controls.Add(Me.ManufacturerPartNoTextBox)
        Me.ProductDetailsGroup.Controls.Add(Me.Label3)
        Me.ProductDetailsGroup.Controls.Add(Me.Label2)
        Me.ProductDetailsGroup.Controls.Add(Me.ManufacturerPartNoLabel)
        Me.ProductDetailsGroup.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ProductDetailsGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProductDetailsGroup.Location = New System.Drawing.Point(371, 39)
        Me.ProductDetailsGroup.Name = "ProductDetailsGroup"
        Me.ProductDetailsGroup.Size = New System.Drawing.Size(742, 397)
        Me.ProductDetailsGroup.TabIndex = 89
        Me.ProductDetailsGroup.TabStop = False
        Me.ProductDetailsGroup.Text = "Product Details"
        Me.ProductDetailsGroup.Visible = False
        '
        'PackingButton
        '
        Me.PackingButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PackingButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.PackingButton.Location = New System.Drawing.Point(11, 210)
        Me.PackingButton.Name = "PackingButton"
        Me.PackingButton.Size = New System.Drawing.Size(131, 40)
        Me.PackingButton.TabIndex = 120
        Me.PackingButton.Text = "Packing"
        Me.PackingButton.UseVisualStyleBackColor = True
        '
        'PackingTextBox
        '
        Me.PackingTextBox.Enabled = False
        Me.PackingTextBox.Location = New System.Drawing.Point(279, 216)
        Me.PackingTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PackingTextBox.Name = "PackingTextBox"
        Me.PackingTextBox.Size = New System.Drawing.Size(176, 26)
        Me.PackingTextBox.TabIndex = 119
        Me.PackingTextBox.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Britannic Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 259)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 21)
        Me.Label1.TabIndex = 60
        Me.Label1.Text = "INVENTORY"
        '
        'MinimumQantityTextBox
        '
        Me.MinimumQantityTextBox.Location = New System.Drawing.Point(279, 325)
        Me.MinimumQantityTextBox.Multiline = True
        Me.MinimumQantityTextBox.Name = "MinimumQantityTextBox"
        Me.MinimumQantityTextBox.Size = New System.Drawing.Size(98, 26)
        Me.MinimumQantityTextBox.TabIndex = 59
        '
        'LocationTextBox
        '
        Me.LocationTextBox.Location = New System.Drawing.Point(279, 357)
        Me.LocationTextBox.Name = "LocationTextBox"
        Me.LocationTextBox.Size = New System.Drawing.Size(98, 26)
        Me.LocationTextBox.TabIndex = 58
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 331)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(135, 20)
        Me.Label8.TabIndex = 57
        Me.Label8.Text = "Minimum Quantity"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(7, 363)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 20)
        Me.Label9.TabIndex = 56
        Me.Label9.Text = "Location"
        '
        'AvailableQuantitiesTextBox
        '
        Me.AvailableQuantitiesTextBox.Enabled = False
        Me.AvailableQuantitiesTextBox.Location = New System.Drawing.Point(279, 293)
        Me.AvailableQuantitiesTextBox.Name = "AvailableQuantitiesTextBox"
        Me.AvailableQuantitiesTextBox.Size = New System.Drawing.Size(98, 26)
        Me.AvailableQuantitiesTextBox.TabIndex = 55
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 299)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(148, 20)
        Me.Label7.TabIndex = 54
        Me.Label7.Text = "Available Quantities"
        '
        'BrandNameTextBox
        '
        Me.BrandNameTextBox.Location = New System.Drawing.Point(279, 150)
        Me.BrandNameTextBox.Name = "BrandNameTextBox"
        Me.BrandNameTextBox.Size = New System.Drawing.Size(220, 26)
        Me.BrandNameTextBox.TabIndex = 53
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 187)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 20)
        Me.Label6.TabIndex = 49
        Me.Label6.Text = "Unit"
        '
        'UnitTextBox
        '
        Me.UnitTextBox.Location = New System.Drawing.Point(279, 184)
        Me.UnitTextBox.Name = "UnitTextBox"
        Me.UnitTextBox.Size = New System.Drawing.Size(98, 26)
        Me.UnitTextBox.TabIndex = 48
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 156)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 20)
        Me.Label4.TabIndex = 46
        Me.Label4.Text = "Brand"
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
        Me.ManufacturerPartDescTextBox.Location = New System.Drawing.Point(279, 76)
        Me.ManufacturerPartDescTextBox.Multiline = True
        Me.ManufacturerPartDescTextBox.Name = "ManufacturerPartDescTextBox"
        Me.ManufacturerPartDescTextBox.Size = New System.Drawing.Size(457, 68)
        Me.ManufacturerPartDescTextBox.TabIndex = 44
        '
        'ManufacturerPartNoTextBox
        '
        Me.ManufacturerPartNoTextBox.Location = New System.Drawing.Point(279, 45)
        Me.ManufacturerPartNoTextBox.Name = "ManufacturerPartNoTextBox"
        Me.ManufacturerPartNoTextBox.Size = New System.Drawing.Size(457, 26)
        Me.ManufacturerPartNoTextBox.TabIndex = 43
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 22)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(179, 20)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "System Part Description"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 82)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(232, 20)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Manufacturer's Part Description"
        '
        'ManufacturerPartNoLabel
        '
        Me.ManufacturerPartNoLabel.AutoSize = True
        Me.ManufacturerPartNoLabel.Location = New System.Drawing.Point(7, 51)
        Me.ManufacturerPartNoLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.ManufacturerPartNoLabel.Name = "ManufacturerPartNoLabel"
        Me.ManufacturerPartNoLabel.Size = New System.Drawing.Size(208, 20)
        Me.ManufacturerPartNoLabel.TabIndex = 40
        Me.ManufacturerPartNoLabel.Text = "Manufacturer's Part Number"
        '
        'CancelMenuStrip
        '
        Me.CancelMenuStrip.Dock = System.Windows.Forms.DockStyle.None
        Me.CancelMenuStrip.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CancelToolStripMenuItem, Me.ToolStripMenuItem3})
        Me.CancelMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.CancelMenuStrip.Name = "CancelMenuStrip"
        Me.CancelMenuStrip.Padding = New System.Windows.Forms.Padding(15, 5, 0, 5)
        Me.CancelMenuStrip.Size = New System.Drawing.Size(69, 35)
        Me.CancelMenuStrip.TabIndex = 91
        Me.CancelMenuStrip.Text = "MenuStrip1"
        '
        'CancelToolStripMenuItem
        '
        Me.CancelToolStripMenuItem.Name = "CancelToolStripMenuItem"
        Me.CancelToolStripMenuItem.Size = New System.Drawing.Size(40, 25)
        Me.CancelToolStripMenuItem.Text = "◄ "
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(12, 25)
        '
        'ProductsPartsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1284, 535)
        Me.Controls.Add(Me.ProductDetailsGroup)
        Me.Controls.Add(Me.CancelMenuStrip)
        Me.Controls.Add(Me.ProductsPartsMenuStrip)
        Me.Controls.Add(Me.ActivatedByTextBox)
        Me.Controls.Add(Me.ProductsPartsDataGridView)
        Me.Name = "ProductsPartsForm"
        Me.Text = "ProductsPartsForm"
        CType(Me.ProductsPartsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ProductsPartsMenuStrip.ResumeLayout(False)
        Me.ProductsPartsMenuStrip.PerformLayout()
        Me.ProductDetailsGroup.ResumeLayout(False)
        Me.ProductDetailsGroup.PerformLayout()
        Me.CancelMenuStrip.ResumeLayout(False)
        Me.CancelMenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ActivatedByTextBox As TextBox
    Friend WithEvents ProductsPartsDataGridView As DataGridView
    Friend WithEvents ProductsPartsMenuStrip As MenuStrip
    Friend WithEvents SelectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UpdateMasterCodeLinkToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SearchDescriptionToolStripTextBox As ToolStripTextBox
    Friend WithEvents SearchDescriptionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PartNoToolStripTextBox As ToolStripTextBox
    Friend WithEvents SearchPartNumberToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VehicleFilterToolStripTextBox As ToolStripTextBox
    Friend WithEvents ToggleVehiclefilterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProductDetailsGroup As GroupBox
    Friend WithEvents BrandNameTextBox As MaskedTextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents UnitTextBox As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents SystemPartDescriptionTextBox As TextBox
    Friend WithEvents ManufacturerPartDescTextBox As TextBox
    Friend WithEvents ManufacturerPartNoTextBox As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ManufacturerPartNoLabel As Label
    Friend WithEvents CancelMenuStrip As MenuStrip
    Friend WithEvents CancelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents PARTSPRODUCTSMENUToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StocksMenuToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label1 As Label
    Friend WithEvents MinimumQantityTextBox As TextBox
    Friend WithEvents LocationTextBox As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents AvailableQuantitiesTextBox As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents PackingButton As Button
    Friend WithEvents PackingTextBox As TextBox
End Class
