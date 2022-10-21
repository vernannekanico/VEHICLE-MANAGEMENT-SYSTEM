<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StockLocationsForm
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
        Me.StocksLocationsGroupBox = New System.Windows.Forms.GroupBox()
        Me.StocksLocationsDataGridView = New System.Windows.Forms.DataGridView()
        Me.StockLocationDetailsGroupBox = New System.Windows.Forms.GroupBox()
        Me.MyStandardNameTextBox = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.LinkedTextBox = New System.Windows.Forms.TextBox()
        Me.StateProvTextBox = New System.Windows.Forms.TextBox()
        Me.ZipCodeTextBox = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CountryTextBox = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MyStandardDateDateTimeTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.StockLOcationSearchToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.StockLocationTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.StocksLocationsMainMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.ReturnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmployeeDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StocksLocationsGroupBox.SuspendLayout()
        CType(Me.StocksLocationsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StockLocationDetailsGroupBox.SuspendLayout()
        Me.StockLOcationSearchToolStrip.SuspendLayout()
        Me.StocksLocationsMainMenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'StocksLocationsGroupBox
        '
        Me.StocksLocationsGroupBox.Controls.Add(Me.StocksLocationsDataGridView)
        Me.StocksLocationsGroupBox.Location = New System.Drawing.Point(30, 179)
        Me.StocksLocationsGroupBox.Name = "StocksLocationsGroupBox"
        Me.StocksLocationsGroupBox.Size = New System.Drawing.Size(267, 173)
        Me.StocksLocationsGroupBox.TabIndex = 88
        Me.StocksLocationsGroupBox.TabStop = False
        Me.StocksLocationsGroupBox.Text = "Stock Locations"
        '
        'StocksLocationsDataGridView
        '
        Me.StocksLocationsDataGridView.AllowUserToAddRows = False
        Me.StocksLocationsDataGridView.AllowUserToDeleteRows = False
        Me.StocksLocationsDataGridView.AllowUserToOrderColumns = True
        Me.StocksLocationsDataGridView.AllowUserToResizeRows = False
        Me.StocksLocationsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.StocksLocationsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.StocksLocationsDataGridView.Location = New System.Drawing.Point(3, 22)
        Me.StocksLocationsDataGridView.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.StocksLocationsDataGridView.MultiSelect = False
        Me.StocksLocationsDataGridView.Name = "StocksLocationsDataGridView"
        Me.StocksLocationsDataGridView.ReadOnly = True
        Me.StocksLocationsDataGridView.RowHeadersVisible = False
        Me.StocksLocationsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.StocksLocationsDataGridView.Size = New System.Drawing.Size(261, 148)
        Me.StocksLocationsDataGridView.TabIndex = 52
        '
        'StockLocationDetailsGroupBox
        '
        Me.StockLocationDetailsGroupBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StockLocationDetailsGroupBox.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.StockLocationDetailsGroupBox.Controls.Add(Me.MyStandardNameTextBox)
        Me.StockLocationDetailsGroupBox.Controls.Add(Me.Label13)
        Me.StockLocationDetailsGroupBox.Controls.Add(Me.LinkedTextBox)
        Me.StockLocationDetailsGroupBox.Controls.Add(Me.StateProvTextBox)
        Me.StockLocationDetailsGroupBox.Controls.Add(Me.ZipCodeTextBox)
        Me.StockLocationDetailsGroupBox.Controls.Add(Me.Label11)
        Me.StockLocationDetailsGroupBox.Controls.Add(Me.Label10)
        Me.StockLocationDetailsGroupBox.Controls.Add(Me.CountryTextBox)
        Me.StockLocationDetailsGroupBox.Controls.Add(Me.Label9)
        Me.StockLocationDetailsGroupBox.Controls.Add(Me.Label2)
        Me.StockLocationDetailsGroupBox.Controls.Add(Me.MyStandardDateDateTimeTextBox)
        Me.StockLocationDetailsGroupBox.Controls.Add(Me.Label1)
        Me.StockLocationDetailsGroupBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.StockLocationDetailsGroupBox.Location = New System.Drawing.Point(341, 287)
        Me.StockLocationDetailsGroupBox.Name = "StockLocationDetailsGroupBox"
        Me.StockLocationDetailsGroupBox.Size = New System.Drawing.Size(624, 246)
        Me.StockLocationDetailsGroupBox.TabIndex = 86
        Me.StockLocationDetailsGroupBox.TabStop = False
        Me.StockLocationDetailsGroupBox.Text = "Details"
        Me.StockLocationDetailsGroupBox.Visible = False
        '
        'MyStandardNameTextBox
        '
        Me.MyStandardNameTextBox.Location = New System.Drawing.Point(256, 29)
        Me.MyStandardNameTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MyStandardNameTextBox.Name = "MyStandardNameTextBox"
        Me.MyStandardNameTextBox.Size = New System.Drawing.Size(330, 26)
        Me.MyStandardNameTextBox.TabIndex = 81
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(16, 102)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(199, 20)
        Me.Label13.TabIndex = 78
        Me.Label13.Text = "MyStadardID_LongInteger"
        '
        'LinkedTextBox
        '
        Me.LinkedTextBox.Location = New System.Drawing.Point(256, 102)
        Me.LinkedTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.LinkedTextBox.Name = "LinkedTextBox"
        Me.LinkedTextBox.Size = New System.Drawing.Size(245, 26)
        Me.LinkedTextBox.TabIndex = 76
        '
        'StateProvTextBox
        '
        Me.StateProvTextBox.Enabled = False
        Me.StateProvTextBox.Location = New System.Drawing.Point(256, 138)
        Me.StateProvTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.StateProvTextBox.Name = "StateProvTextBox"
        Me.StateProvTextBox.Size = New System.Drawing.Size(245, 26)
        Me.StateProvTextBox.TabIndex = 75
        '
        'ZipCodeTextBox
        '
        Me.ZipCodeTextBox.Enabled = False
        Me.ZipCodeTextBox.Location = New System.Drawing.Point(256, 171)
        Me.ZipCodeTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ZipCodeTextBox.Name = "ZipCodeTextBox"
        Me.ZipCodeTextBox.Size = New System.Drawing.Size(245, 26)
        Me.ZipCodeTextBox.TabIndex = 74
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(16, 177)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(73, 20)
        Me.Label11.TabIndex = 69
        Me.Label11.Text = "Zip Code"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 213)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 20)
        Me.Label10.TabIndex = 68
        Me.Label10.Text = "Country"
        '
        'CountryTextBox
        '
        Me.CountryTextBox.Enabled = False
        Me.CountryTextBox.Location = New System.Drawing.Point(256, 207)
        Me.CountryTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CountryTextBox.Name = "CountryTextBox"
        Me.CountryTextBox.Size = New System.Drawing.Size(245, 26)
        Me.CountryTextBox.TabIndex = 67
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 141)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 20)
        Me.Label9.TabIndex = 66
        Me.Label9.Text = "State"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(208, 20)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "MyStandardDate_DateTime"
        '
        'MyStandardDateDateTimeTextBox
        '
        Me.MyStandardDateDateTimeTextBox.Location = New System.Drawing.Point(256, 60)
        Me.MyStandardDateDateTimeTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MyStandardDateDateTimeTextBox.Name = "MyStandardDateDateTimeTextBox"
        Me.MyStandardDateDateTimeTextBox.Size = New System.Drawing.Size(330, 26)
        Me.MyStandardDateDateTimeTextBox.TabIndex = 55
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(233, 20)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "MyStandardName_ShortText35"
        '
        'StockLOcationSearchToolStrip
        '
        Me.StockLOcationSearchToolStrip.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StockLOcationSearchToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.StockLocationTextBox})
        Me.StockLOcationSearchToolStrip.Location = New System.Drawing.Point(0, 31)
        Me.StockLOcationSearchToolStrip.Name = "StockLOcationSearchToolStrip"
        Me.StockLOcationSearchToolStrip.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.StockLOcationSearchToolStrip.Size = New System.Drawing.Size(1051, 29)
        Me.StockLOcationSearchToolStrip.TabIndex = 85
        Me.StockLOcationSearchToolStrip.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(35, 26)
        Me.ToolStripLabel1.Text = "Key"
        '
        'StockLocationTextBox
        '
        Me.StockLocationTextBox.Font = New System.Drawing.Font("Segoe UI", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StockLocationTextBox.Name = "StockLocationTextBox"
        Me.StockLocationTextBox.Size = New System.Drawing.Size(300, 29)
        Me.StockLocationTextBox.Text = "Search"
        '
        'StocksLocationsMainMenuStrip
        '
        Me.StocksLocationsMainMenuStrip.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StocksLocationsMainMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReturnToolStripMenuItem, Me.SelectToolStripMenuItem, Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.RemoveToolStripMenuItem, Me.ToolStripMenuItem1, Me.ViewToolStripMenuItem, Me.SaveToolStripMenuItem})
        Me.StocksLocationsMainMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.StocksLocationsMainMenuStrip.Name = "StocksLocationsMainMenuStrip"
        Me.StocksLocationsMainMenuStrip.Padding = New System.Windows.Forms.Padding(10, 3, 0, 3)
        Me.StocksLocationsMainMenuStrip.Size = New System.Drawing.Size(1051, 31)
        Me.StocksLocationsMainMenuStrip.TabIndex = 84
        Me.StocksLocationsMainMenuStrip.Text = "MenuStrip"
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
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(50, 25)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(48, 25)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'RemoveToolStripMenuItem
        '
        Me.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem"
        Me.RemoveToolStripMenuItem.Size = New System.Drawing.Size(79, 25)
        Me.RemoveToolStripMenuItem.Text = "Remove"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(12, 25)
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
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(55, 25)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'StockLocationsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1051, 624)
        Me.Controls.Add(Me.StocksLocationsGroupBox)
        Me.Controls.Add(Me.StockLocationDetailsGroupBox)
        Me.Controls.Add(Me.StockLOcationSearchToolStrip)
        Me.Controls.Add(Me.StocksLocationsMainMenuStrip)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "StockLocationsForm"
        Me.Text = "StockLocationsForm"
        Me.StocksLocationsGroupBox.ResumeLayout(False)
        CType(Me.StocksLocationsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StockLocationDetailsGroupBox.ResumeLayout(False)
        Me.StockLocationDetailsGroupBox.PerformLayout()
        Me.StockLOcationSearchToolStrip.ResumeLayout(False)
        Me.StockLOcationSearchToolStrip.PerformLayout()
        Me.StocksLocationsMainMenuStrip.ResumeLayout(False)
        Me.StocksLocationsMainMenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StocksLocationsGroupBox As GroupBox
    Friend WithEvents StocksLocationsDataGridView As DataGridView
    Friend WithEvents StockLocationDetailsGroupBox As GroupBox
    Friend WithEvents MyStandardNameTextBox As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents LinkedTextBox As TextBox
    Friend WithEvents StateProvTextBox As TextBox
    Friend WithEvents ZipCodeTextBox As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents CountryTextBox As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents MyStandardDateDateTimeTextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents StockLOcationSearchToolStrip As ToolStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents StockLocationTextBox As ToolStripTextBox
    Friend WithEvents StocksLocationsMainMenuStrip As MenuStrip
    Friend WithEvents ReturnToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RemoveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EmployeeDetailsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
End Class
