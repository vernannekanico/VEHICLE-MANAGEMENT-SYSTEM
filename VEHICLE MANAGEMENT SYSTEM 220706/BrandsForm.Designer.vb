<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BrandsForm
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
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.ReturnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmployeeDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.SearchMyStandardTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.ActivatedByTextBox = New System.Windows.Forms.TextBox()
        Me.DetailsGroupBox = New System.Windows.Forms.GroupBox()
        Me.BrandNameTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BrandDataGridView = New System.Windows.Forms.DataGridView()
        Me.MenuStrip.SuspendLayout()
        Me.SearchToolStrip.SuspendLayout()
        Me.DetailsGroupBox.SuspendLayout()
        CType(Me.BrandDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReturnToolStripMenuItem, Me.SelectToolStripMenuItem, Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.ToolStripMenuItem1, Me.ViewToolStripMenuItem, Me.SaveToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Padding = New System.Windows.Forms.Padding(10, 3, 0, 3)
        Me.MenuStrip.Size = New System.Drawing.Size(1133, 31)
        Me.MenuStrip.TabIndex = 79
        Me.MenuStrip.Text = "MenuStrip1"
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
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(66, 25)
        Me.DeleteToolStripMenuItem.Text = "Delete"
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
        'SearchToolStrip
        '
        Me.SearchToolStrip.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.SearchMyStandardTextBox})
        Me.SearchToolStrip.Location = New System.Drawing.Point(0, 31)
        Me.SearchToolStrip.Name = "SearchToolStrip"
        Me.SearchToolStrip.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.SearchToolStrip.Size = New System.Drawing.Size(1133, 29)
        Me.SearchToolStrip.TabIndex = 80
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
        'ActivatedByTextBox
        '
        Me.ActivatedByTextBox.Location = New System.Drawing.Point(113, 303)
        Me.ActivatedByTextBox.Margin = New System.Windows.Forms.Padding(5)
        Me.ActivatedByTextBox.Name = "ActivatedByTextBox"
        Me.ActivatedByTextBox.Size = New System.Drawing.Size(105, 20)
        Me.ActivatedByTextBox.TabIndex = 82
        Me.ActivatedByTextBox.Text = "ActivatedBy"
        Me.ActivatedByTextBox.Visible = False
        '
        'DetailsGroupBox
        '
        Me.DetailsGroupBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DetailsGroupBox.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.DetailsGroupBox.Controls.Add(Me.BrandNameTextBox)
        Me.DetailsGroupBox.Controls.Add(Me.Label1)
        Me.DetailsGroupBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DetailsGroupBox.Location = New System.Drawing.Point(397, 30)
        Me.DetailsGroupBox.Name = "DetailsGroupBox"
        Me.DetailsGroupBox.Size = New System.Drawing.Size(544, 82)
        Me.DetailsGroupBox.TabIndex = 88
        Me.DetailsGroupBox.TabStop = False
        Me.DetailsGroupBox.Text = "Details"
        Me.DetailsGroupBox.Visible = False
        '
        'BrandNameTextBox
        '
        Me.BrandNameTextBox.Location = New System.Drawing.Point(114, 29)
        Me.BrandNameTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BrandNameTextBox.Name = "BrandNameTextBox"
        Me.BrandNameTextBox.Size = New System.Drawing.Size(409, 20)
        Me.BrandNameTextBox.TabIndex = 81
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "Brand"
        '
        'BrandDataGridView
        '
        Me.BrandDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.BrandDataGridView.Location = New System.Drawing.Point(0, 55)
        Me.BrandDataGridView.Margin = New System.Windows.Forms.Padding(7, 8, 7, 8)
        Me.BrandDataGridView.Name = "BrandDataGridView"
        Me.BrandDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.BrandDataGridView.Size = New System.Drawing.Size(682, 189)
        Me.BrandDataGridView.TabIndex = 87
        '
        'BrandsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1133, 450)
        Me.Controls.Add(Me.DetailsGroupBox)
        Me.Controls.Add(Me.BrandDataGridView)
        Me.Controls.Add(Me.ActivatedByTextBox)
        Me.Controls.Add(Me.SearchToolStrip)
        Me.Controls.Add(Me.MenuStrip)
        Me.Name = "BrandsForm"
        Me.Text = "BrandsForm"
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.SearchToolStrip.ResumeLayout(False)
        Me.SearchToolStrip.PerformLayout()
        Me.DetailsGroupBox.ResumeLayout(False)
        Me.DetailsGroupBox.PerformLayout()
        CType(Me.BrandDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip As MenuStrip
    Friend WithEvents ReturnToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EmployeeDetailsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SearchToolStrip As ToolStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents SearchMyStandardTextBox As ToolStripTextBox
    Friend WithEvents ActivatedByTextBox As TextBox
    Friend WithEvents DetailsGroupBox As GroupBox
    Friend WithEvents BrandNameTextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BrandDataGridView As DataGridView
End Class
