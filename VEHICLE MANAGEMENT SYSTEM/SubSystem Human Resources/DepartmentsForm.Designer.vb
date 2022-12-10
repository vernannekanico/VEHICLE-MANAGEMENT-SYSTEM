<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DepartmentsForm
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
        Me.DetailsGroupBox = New System.Windows.Forms.GroupBox()
        Me.DepartmentNameTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.CancelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DepartmentDataGridView = New System.Windows.Forms.DataGridView()
        Me.DetailsGroupBox.SuspendLayout()
        Me.MenuStrip.SuspendLayout()
        CType(Me.DepartmentDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DetailsGroupBox
        '
        Me.DetailsGroupBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DetailsGroupBox.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.DetailsGroupBox.Controls.Add(Me.DepartmentNameTextBox)
        Me.DetailsGroupBox.Controls.Add(Me.Label1)
        Me.DetailsGroupBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DetailsGroupBox.Location = New System.Drawing.Point(397, 34)
        Me.DetailsGroupBox.Name = "DetailsGroupBox"
        Me.DetailsGroupBox.Size = New System.Drawing.Size(544, 82)
        Me.DetailsGroupBox.TabIndex = 86
        Me.DetailsGroupBox.TabStop = False
        Me.DetailsGroupBox.Text = "Details"
        Me.DetailsGroupBox.Visible = False
        '
        'DepartmentNameTextBox
        '
        Me.DepartmentNameTextBox.Location = New System.Drawing.Point(114, 29)
        Me.DepartmentNameTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DepartmentNameTextBox.Name = "DepartmentNameTextBox"
        Me.DepartmentNameTextBox.Size = New System.Drawing.Size(409, 26)
        Me.DepartmentNameTextBox.TabIndex = 81
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 20)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "Department"
        '
        'MenuStrip
        '
        Me.MenuStrip.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CancelToolStripMenuItem, Me.SelectToolStripMenuItem, Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.ToolStripMenuItem1, Me.ViewToolStripMenuItem, Me.SaveToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Padding = New System.Windows.Forms.Padding(10, 3, 0, 3)
        Me.MenuStrip.Size = New System.Drawing.Size(1076, 31)
        Me.MenuStrip.TabIndex = 83
        Me.MenuStrip.Text = "MenuStrip1"
        '
        'CancelToolStripMenuItem
        '
        Me.CancelToolStripMenuItem.Name = "CancelToolStripMenuItem"
        Me.CancelToolStripMenuItem.Size = New System.Drawing.Size(40, 25)
        Me.CancelToolStripMenuItem.Text = "◄ "
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
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(56, 25)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(55, 25)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'DepartmentDataGridView
        '
        Me.DepartmentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DepartmentDataGridView.Location = New System.Drawing.Point(0, 59)
        Me.DepartmentDataGridView.Margin = New System.Windows.Forms.Padding(7, 8, 7, 8)
        Me.DepartmentDataGridView.Name = "DepartmentDataGridView"
        Me.DepartmentDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DepartmentDataGridView.Size = New System.Drawing.Size(682, 189)
        Me.DepartmentDataGridView.TabIndex = 82
        '
        'DepartmentsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1076, 361)
        Me.ControlBox = False
        Me.Controls.Add(Me.DetailsGroupBox)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.DepartmentDataGridView)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "DepartmentsForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DepatmentForm"
        Me.DetailsGroupBox.ResumeLayout(False)
        Me.DetailsGroupBox.PerformLayout()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        CType(Me.DepartmentDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DetailsGroupBox As GroupBox
    Friend WithEvents DepartmentNameTextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents MenuStrip As MenuStrip
    Friend WithEvents CancelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DepartmentDataGridView As DataGridView
End Class
