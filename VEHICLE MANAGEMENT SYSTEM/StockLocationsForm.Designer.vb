﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.StorageLocationTextBox = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.SubStorageTypeTextBox = New System.Windows.Forms.TextBox()
        Me.BayTextBox = New System.Windows.Forms.TextBox()
        Me.LevelTextBox = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MainStorageTypeTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.StockLOcationSearchToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.StockLocationTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.StocksLocationsMainMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.ReturnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActiveDGViewToolStripTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.SelectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StoragesLocationsGroupBox = New System.Windows.Forms.GroupBox()
        Me.StoragesLocationsDataGridView = New System.Windows.Forms.DataGridView()
        Me.InputBoxGroupBox = New System.Windows.Forms.GroupBox()
        Me.InputTextBox = New System.Windows.Forms.TextBox()
        Me.StocksLocationsGroupBox.SuspendLayout()
        CType(Me.StocksLocationsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StockLocationDetailsGroupBox.SuspendLayout()
        Me.StockLOcationSearchToolStrip.SuspendLayout()
        Me.StocksLocationsMainMenuStrip.SuspendLayout()
        Me.StoragesLocationsGroupBox.SuspendLayout()
        CType(Me.StoragesLocationsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.InputBoxGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'StocksLocationsGroupBox
        '
        Me.StocksLocationsGroupBox.Controls.Add(Me.StocksLocationsDataGridView)
        Me.StocksLocationsGroupBox.Enabled = False
        Me.StocksLocationsGroupBox.Location = New System.Drawing.Point(30, 179)
        Me.StocksLocationsGroupBox.Name = "StocksLocationsGroupBox"
        Me.StocksLocationsGroupBox.Size = New System.Drawing.Size(267, 173)
        Me.StocksLocationsGroupBox.TabIndex = 88
        Me.StocksLocationsGroupBox.TabStop = False
        Me.StocksLocationsGroupBox.Text = "Stocks Locations"
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
        Me.StockLocationDetailsGroupBox.Controls.Add(Me.StorageLocationTextBox)
        Me.StockLocationDetailsGroupBox.Controls.Add(Me.Label13)
        Me.StockLocationDetailsGroupBox.Controls.Add(Me.SubStorageTypeTextBox)
        Me.StockLocationDetailsGroupBox.Controls.Add(Me.BayTextBox)
        Me.StockLocationDetailsGroupBox.Controls.Add(Me.LevelTextBox)
        Me.StockLocationDetailsGroupBox.Controls.Add(Me.Label11)
        Me.StockLocationDetailsGroupBox.Controls.Add(Me.Label9)
        Me.StockLocationDetailsGroupBox.Controls.Add(Me.Label2)
        Me.StockLocationDetailsGroupBox.Controls.Add(Me.MainStorageTypeTextBox)
        Me.StockLocationDetailsGroupBox.Controls.Add(Me.Label1)
        Me.StockLocationDetailsGroupBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.StockLocationDetailsGroupBox.Location = New System.Drawing.Point(341, 287)
        Me.StockLocationDetailsGroupBox.Name = "StockLocationDetailsGroupBox"
        Me.StockLocationDetailsGroupBox.Size = New System.Drawing.Size(624, 214)
        Me.StockLocationDetailsGroupBox.TabIndex = 86
        Me.StockLocationDetailsGroupBox.TabStop = False
        Me.StockLocationDetailsGroupBox.Text = "Details"
        Me.StockLocationDetailsGroupBox.Visible = False
        '
        'StorageLocationTextBox
        '
        Me.StorageLocationTextBox.Location = New System.Drawing.Point(256, 29)
        Me.StorageLocationTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.StorageLocationTextBox.Name = "StorageLocationTextBox"
        Me.StorageLocationTextBox.Size = New System.Drawing.Size(330, 26)
        Me.StorageLocationTextBox.TabIndex = 81
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(16, 102)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(137, 20)
        Me.Label13.TabIndex = 78
        Me.Label13.Text = "Sub Storage Type"
        '
        'SubStorageTypeTextBox
        '
        Me.SubStorageTypeTextBox.Location = New System.Drawing.Point(256, 102)
        Me.SubStorageTypeTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.SubStorageTypeTextBox.Name = "SubStorageTypeTextBox"
        Me.SubStorageTypeTextBox.Size = New System.Drawing.Size(245, 26)
        Me.SubStorageTypeTextBox.TabIndex = 76
        '
        'BayTextBox
        '
        Me.BayTextBox.Enabled = False
        Me.BayTextBox.Location = New System.Drawing.Point(256, 138)
        Me.BayTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BayTextBox.Name = "BayTextBox"
        Me.BayTextBox.Size = New System.Drawing.Size(245, 26)
        Me.BayTextBox.TabIndex = 75
        '
        'LevelTextBox
        '
        Me.LevelTextBox.Enabled = False
        Me.LevelTextBox.Location = New System.Drawing.Point(256, 171)
        Me.LevelTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.LevelTextBox.Name = "LevelTextBox"
        Me.LevelTextBox.Size = New System.Drawing.Size(245, 26)
        Me.LevelTextBox.TabIndex = 74
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(16, 177)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(164, 20)
        Me.Label11.TabIndex = 69
        Me.Label11.Text = "Level ( 1 is the lowest)"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 141)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 20)
        Me.Label9.TabIndex = 66
        Me.Label9.Text = "Bay (Column)"
        Me.Label9.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(142, 20)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "Main Storage Type"
        '
        'MainStorageTypeTextBox
        '
        Me.MainStorageTypeTextBox.Location = New System.Drawing.Point(256, 60)
        Me.MainStorageTypeTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MainStorageTypeTextBox.Name = "MainStorageTypeTextBox"
        Me.MainStorageTypeTextBox.Size = New System.Drawing.Size(330, 26)
        Me.MainStorageTypeTextBox.TabIndex = 55
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(131, 20)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "Storage Location"
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
        Me.StocksLocationsMainMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReturnToolStripMenuItem, Me.ActiveDGViewToolStripTextBox, Me.SelectToolStripMenuItem, Me.NewToolStripMenuItem, Me.EditToolStripMenuItem, Me.RemoveToolStripMenuItem, Me.ToolStripMenuItem1, Me.SaveToolStripMenuItem})
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
        'ActiveDGViewToolStripTextBox
        '
        Me.ActiveDGViewToolStripTextBox.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ActiveDGViewToolStripTextBox.Name = "ActiveDGViewToolStripTextBox"
        Me.ActiveDGViewToolStripTextBox.Size = New System.Drawing.Size(100, 25)
        Me.ActiveDGViewToolStripTextBox.Text = "Stocks location"
        '
        'SelectToolStripMenuItem
        '
        Me.SelectToolStripMenuItem.Name = "SelectToolStripMenuItem"
        Me.SelectToolStripMenuItem.Size = New System.Drawing.Size(63, 25)
        Me.SelectToolStripMenuItem.Text = "Select"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(54, 25)
        Me.NewToolStripMenuItem.Text = "New"
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
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(55, 25)
        Me.SaveToolStripMenuItem.Text = "Save"
        Me.SaveToolStripMenuItem.Visible = False
        '
        'StoragesLocationsGroupBox
        '
        Me.StoragesLocationsGroupBox.Controls.Add(Me.StoragesLocationsDataGridView)
        Me.StoragesLocationsGroupBox.Location = New System.Drawing.Point(319, 89)
        Me.StoragesLocationsGroupBox.Name = "StoragesLocationsGroupBox"
        Me.StoragesLocationsGroupBox.Size = New System.Drawing.Size(267, 173)
        Me.StoragesLocationsGroupBox.TabIndex = 89
        Me.StoragesLocationsGroupBox.TabStop = False
        Me.StoragesLocationsGroupBox.Text = "Storages Locations"
        Me.StoragesLocationsGroupBox.Visible = False
        '
        'StoragesLocationsDataGridView
        '
        Me.StoragesLocationsDataGridView.AllowUserToAddRows = False
        Me.StoragesLocationsDataGridView.AllowUserToDeleteRows = False
        Me.StoragesLocationsDataGridView.AllowUserToOrderColumns = True
        Me.StoragesLocationsDataGridView.AllowUserToResizeRows = False
        Me.StoragesLocationsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.StoragesLocationsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.StoragesLocationsDataGridView.Location = New System.Drawing.Point(3, 22)
        Me.StoragesLocationsDataGridView.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.StoragesLocationsDataGridView.MultiSelect = False
        Me.StoragesLocationsDataGridView.Name = "StoragesLocationsDataGridView"
        Me.StoragesLocationsDataGridView.ReadOnly = True
        Me.StoragesLocationsDataGridView.RowHeadersVisible = False
        Me.StoragesLocationsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.StoragesLocationsDataGridView.Size = New System.Drawing.Size(261, 148)
        Me.StoragesLocationsDataGridView.TabIndex = 52
        '
        'InputBoxGroupBox
        '
        Me.InputBoxGroupBox.Controls.Add(Me.InputTextBox)
        Me.InputBoxGroupBox.Location = New System.Drawing.Point(638, 111)
        Me.InputBoxGroupBox.Name = "InputBoxGroupBox"
        Me.InputBoxGroupBox.Size = New System.Drawing.Size(401, 66)
        Me.InputBoxGroupBox.TabIndex = 90
        Me.InputBoxGroupBox.TabStop = False
        Me.InputBoxGroupBox.Text = "Input Box"
        Me.InputBoxGroupBox.Visible = False
        '
        'InputTextBox
        '
        Me.InputTextBox.Location = New System.Drawing.Point(3, 22)
        Me.InputTextBox.Name = "InputTextBox"
        Me.InputTextBox.Size = New System.Drawing.Size(392, 26)
        Me.InputTextBox.TabIndex = 0
        '
        'StockLocationsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1051, 624)
        Me.Controls.Add(Me.InputBoxGroupBox)
        Me.Controls.Add(Me.StoragesLocationsGroupBox)
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
        Me.StoragesLocationsGroupBox.ResumeLayout(False)
        CType(Me.StoragesLocationsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.InputBoxGroupBox.ResumeLayout(False)
        Me.InputBoxGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StocksLocationsGroupBox As GroupBox
    Friend WithEvents StocksLocationsDataGridView As DataGridView
    Friend WithEvents StockLocationDetailsGroupBox As GroupBox
    Friend WithEvents StorageLocationTextBox As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents SubStorageTypeTextBox As TextBox
    Friend WithEvents BayTextBox As TextBox
    Friend WithEvents LevelTextBox As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents MainStorageTypeTextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents StockLOcationSearchToolStrip As ToolStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents StockLocationTextBox As ToolStripTextBox
    Friend WithEvents StocksLocationsMainMenuStrip As MenuStrip
    Friend WithEvents ReturnToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RemoveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StoragesLocationsGroupBox As GroupBox
    Friend WithEvents StoragesLocationsDataGridView As DataGridView
    Friend WithEvents InputBoxGroupBox As GroupBox
    Friend WithEvents InputTextBox As TextBox
    Friend WithEvents ActiveDGViewToolStripTextBox As ToolStripTextBox
End Class
