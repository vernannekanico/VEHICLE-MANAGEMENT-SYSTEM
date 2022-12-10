<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PurchasedItemsForm
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
        Me.PurchasedItemsGroupBox = New System.Windows.Forms.GroupBox()
        Me.PurchasedItemsDataGridView = New System.Windows.Forms.DataGridView()
        Me.SearchToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.SearchPurchasedItemTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.MyStandardsFormMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.ReturnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectPurchasedItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmployeeDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PurchasedItemsGroupBox.SuspendLayout()
        CType(Me.PurchasedItemsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SearchToolStrip.SuspendLayout()
        Me.MyStandardsFormMenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'PurchasedItemsGroupBox
        '
        Me.PurchasedItemsGroupBox.Controls.Add(Me.PurchasedItemsDataGridView)
        Me.PurchasedItemsGroupBox.Location = New System.Drawing.Point(30, 218)
        Me.PurchasedItemsGroupBox.Name = "PurchasedItemsGroupBox"
        Me.PurchasedItemsGroupBox.Size = New System.Drawing.Size(267, 173)
        Me.PurchasedItemsGroupBox.TabIndex = 88
        Me.PurchasedItemsGroupBox.TabStop = False
        Me.PurchasedItemsGroupBox.Text = "Purchased Items"
        '
        'PurchasedItemsDataGridView
        '
        Me.PurchasedItemsDataGridView.AllowUserToAddRows = False
        Me.PurchasedItemsDataGridView.AllowUserToDeleteRows = False
        Me.PurchasedItemsDataGridView.AllowUserToOrderColumns = True
        Me.PurchasedItemsDataGridView.AllowUserToResizeRows = False
        Me.PurchasedItemsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.PurchasedItemsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PurchasedItemsDataGridView.Location = New System.Drawing.Point(3, 26)
        Me.PurchasedItemsDataGridView.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PurchasedItemsDataGridView.MultiSelect = False
        Me.PurchasedItemsDataGridView.Name = "PurchasedItemsDataGridView"
        Me.PurchasedItemsDataGridView.ReadOnly = True
        Me.PurchasedItemsDataGridView.RowHeadersVisible = False
        Me.PurchasedItemsDataGridView.RowHeadersWidth = 51
        Me.PurchasedItemsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.PurchasedItemsDataGridView.Size = New System.Drawing.Size(261, 144)
        Me.PurchasedItemsDataGridView.TabIndex = 52
        '
        'SearchToolStrip
        '
        Me.SearchToolStrip.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchToolStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.SearchToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.SearchPurchasedItemTextBox})
        Me.SearchToolStrip.Location = New System.Drawing.Point(0, 38)
        Me.SearchToolStrip.Name = "SearchToolStrip"
        Me.SearchToolStrip.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.SearchToolStrip.Size = New System.Drawing.Size(1200, 34)
        Me.SearchToolStrip.TabIndex = 85
        Me.SearchToolStrip.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(44, 31)
        Me.ToolStripLabel1.Text = "Key"
        '
        'SearchPurchasedItemTextBox
        '
        Me.SearchPurchasedItemTextBox.Font = New System.Drawing.Font("Segoe UI", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchPurchasedItemTextBox.Name = "SearchPurchasedItemTextBox"
        Me.SearchPurchasedItemTextBox.Size = New System.Drawing.Size(300, 34)
        Me.SearchPurchasedItemTextBox.Text = "Search"
        '
        'MyStandardsFormMenuStrip
        '
        Me.MyStandardsFormMenuStrip.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyStandardsFormMenuStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MyStandardsFormMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReturnToolStripMenuItem, Me.SelectPurchasedItemToolStripMenuItem, Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.ToolStripMenuItem1, Me.ViewToolStripMenuItem, Me.SaveToolStripMenuItem})
        Me.MyStandardsFormMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MyStandardsFormMenuStrip.Name = "MyStandardsFormMenuStrip"
        Me.MyStandardsFormMenuStrip.Padding = New System.Windows.Forms.Padding(10, 3, 0, 3)
        Me.MyStandardsFormMenuStrip.Size = New System.Drawing.Size(1200, 38)
        Me.MyStandardsFormMenuStrip.TabIndex = 84
        Me.MyStandardsFormMenuStrip.Text = "PurchasedItemsMenuStrip"
        '
        'ReturnToolStripMenuItem
        '
        Me.ReturnToolStripMenuItem.Name = "ReturnToolStripMenuItem"
        Me.ReturnToolStripMenuItem.Size = New System.Drawing.Size(48, 32)
        Me.ReturnToolStripMenuItem.Text = "◄ "
        '
        'SelectPurchasedItemToolStripMenuItem
        '
        Me.SelectPurchasedItemToolStripMenuItem.Name = "SelectPurchasedItemToolStripMenuItem"
        Me.SelectPurchasedItemToolStripMenuItem.Size = New System.Drawing.Size(78, 32)
        Me.SelectPurchasedItemToolStripMenuItem.Text = "Select"
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(63, 32)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(60, 32)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(82, 32)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(14, 32)
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EmployeeDetailsToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(67, 32)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'EmployeeDetailsToolStripMenuItem
        '
        Me.EmployeeDetailsToolStripMenuItem.Name = "EmployeeDetailsToolStripMenuItem"
        Me.EmployeeDetailsToolStripMenuItem.Size = New System.Drawing.Size(246, 32)
        Me.EmployeeDetailsToolStripMenuItem.Text = "Employee details"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(67, 32)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'PurchasedItemsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1200, 703)
        Me.Controls.Add(Me.PurchasedItemsGroupBox)
        Me.Controls.Add(Me.SearchToolStrip)
        Me.Controls.Add(Me.MyStandardsFormMenuStrip)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "PurchasedItemsForm"
        Me.Text = "PurchasedItems"
        Me.PurchasedItemsGroupBox.ResumeLayout(False)
        CType(Me.PurchasedItemsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SearchToolStrip.ResumeLayout(False)
        Me.SearchToolStrip.PerformLayout()
        Me.MyStandardsFormMenuStrip.ResumeLayout(False)
        Me.MyStandardsFormMenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PurchasedItemsGroupBox As GroupBox
    Friend WithEvents PurchasedItemsDataGridView As DataGridView
    Friend WithEvents SearchToolStrip As ToolStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents SearchPurchasedItemTextBox As ToolStripTextBox
    Friend WithEvents MyStandardsFormMenuStrip As MenuStrip
    Friend WithEvents ReturnToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelectPurchasedItemToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EmployeeDetailsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
End Class
