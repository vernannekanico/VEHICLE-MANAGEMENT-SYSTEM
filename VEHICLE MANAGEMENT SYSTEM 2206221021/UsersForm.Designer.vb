<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UsersForm
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
        Me.ActivatedByTextBox = New System.Windows.Forms.TextBox()
        Me.SearchToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.SearchUserTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.CancelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.UsersDataGridView = New System.Windows.Forms.DataGridView()
        Me.SearchToolStrip.SuspendLayout()
        Me.MenuStrip.SuspendLayout()
        CType(Me.UsersDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ActivatedByTextBox
        '
        Me.ActivatedByTextBox.Location = New System.Drawing.Point(333, 375)
        Me.ActivatedByTextBox.Margin = New System.Windows.Forms.Padding(8)
        Me.ActivatedByTextBox.Name = "ActivatedByTextBox"
        Me.ActivatedByTextBox.Size = New System.Drawing.Size(156, 26)
        Me.ActivatedByTextBox.TabIndex = 85
        Me.ActivatedByTextBox.Text = "ActivatedBy"
        Me.ActivatedByTextBox.Visible = False
        '
        'SearchToolStrip
        '
        Me.SearchToolStrip.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.SearchUserTextBox})
        Me.SearchToolStrip.Location = New System.Drawing.Point(0, 35)
        Me.SearchToolStrip.Name = "SearchToolStrip"
        Me.SearchToolStrip.Padding = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.SearchToolStrip.Size = New System.Drawing.Size(964, 29)
        Me.SearchToolStrip.TabIndex = 84
        Me.SearchToolStrip.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(35, 26)
        Me.ToolStripLabel1.Text = "Key"
        '
        'SearchUserTextBox
        '
        Me.SearchUserTextBox.Font = New System.Drawing.Font("Segoe UI", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchUserTextBox.Name = "SearchUserTextBox"
        Me.SearchUserTextBox.Size = New System.Drawing.Size(448, 29)
        Me.SearchUserTextBox.Text = "Search"
        '
        'MenuStrip
        '
        Me.MenuStrip.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CancelToolStripMenuItem, Me.ToolStripMenuItem1})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Padding = New System.Windows.Forms.Padding(15, 5, 0, 5)
        Me.MenuStrip.Size = New System.Drawing.Size(964, 35)
        Me.MenuStrip.TabIndex = 83
        Me.MenuStrip.Text = "MenuStrip1"
        '
        'CancelToolStripMenuItem
        '
        Me.CancelToolStripMenuItem.Name = "CancelToolStripMenuItem"
        Me.CancelToolStripMenuItem.Size = New System.Drawing.Size(40, 25)
        Me.CancelToolStripMenuItem.Text = "◄ "
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(12, 25)
        '
        'UsersDataGridView
        '
        Me.UsersDataGridView.AllowUserToAddRows = False
        Me.UsersDataGridView.AllowUserToDeleteRows = False
        Me.UsersDataGridView.AllowUserToResizeRows = False
        Me.UsersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.UsersDataGridView.Location = New System.Drawing.Point(0, 61)
        Me.UsersDataGridView.Margin = New System.Windows.Forms.Padding(10, 12, 10, 12)
        Me.UsersDataGridView.Name = "UsersDataGridView"
        Me.UsersDataGridView.ReadOnly = True
        Me.UsersDataGridView.RowHeadersVisible = False
        Me.UsersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.UsersDataGridView.Size = New System.Drawing.Size(441, 291)
        Me.UsersDataGridView.TabIndex = 82
        '
        'UsersForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 418)
        Me.Controls.Add(Me.ActivatedByTextBox)
        Me.Controls.Add(Me.SearchToolStrip)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.UsersDataGridView)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "UsersForm"
        Me.Text = "UsersForm"
        Me.SearchToolStrip.ResumeLayout(False)
        Me.SearchToolStrip.PerformLayout()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        CType(Me.UsersDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ActivatedByTextBox As TextBox
    Friend WithEvents SearchToolStrip As ToolStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents SearchUserTextBox As ToolStripTextBox
    Friend WithEvents MenuStrip As MenuStrip
    Friend WithEvents CancelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents UsersDataGridView As DataGridView
End Class
