<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StatusForm
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ReturnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddStatusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditStatusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteStatusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectStatusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveStatusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TablesDataGridView = New System.Windows.Forms.DataGridView()
        Me.StatusesDataGridView = New System.Windows.Forms.DataGridView()
        Me.StatusDetailsGroupBox = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.StatusOfActionTextBox = New System.Windows.Forms.TextBox()
        Me.RemarksTextBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SequenceOfActionTextBox = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.StatusByteTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.TablesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusDetailsGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReturnToolStripMenuItem, Me.AddStatusToolStripMenuItem, Me.EditStatusToolStripMenuItem, Me.DeleteStatusToolStripMenuItem, Me.SelectStatusToolStripMenuItem, Me.ToolStripMenuItem1, Me.SaveStatusToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(9, 3, 0, 3)
        Me.MenuStrip1.Size = New System.Drawing.Size(1200, 25)
        Me.MenuStrip1.TabIndex = 123
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ReturnToolStripMenuItem
        '
        Me.ReturnToolStripMenuItem.Name = "ReturnToolStripMenuItem"
        Me.ReturnToolStripMenuItem.Size = New System.Drawing.Size(32, 19)
        Me.ReturnToolStripMenuItem.Text = "◄ "
        '
        'AddStatusToolStripMenuItem
        '
        Me.AddStatusToolStripMenuItem.Name = "AddStatusToolStripMenuItem"
        Me.AddStatusToolStripMenuItem.Size = New System.Drawing.Size(41, 19)
        Me.AddStatusToolStripMenuItem.Text = "Add"
        '
        'EditStatusToolStripMenuItem
        '
        Me.EditStatusToolStripMenuItem.Name = "EditStatusToolStripMenuItem"
        Me.EditStatusToolStripMenuItem.Size = New System.Drawing.Size(39, 19)
        Me.EditStatusToolStripMenuItem.Text = "Edit"
        '
        'DeleteStatusToolStripMenuItem
        '
        Me.DeleteStatusToolStripMenuItem.Name = "DeleteStatusToolStripMenuItem"
        Me.DeleteStatusToolStripMenuItem.Size = New System.Drawing.Size(52, 19)
        Me.DeleteStatusToolStripMenuItem.Text = "Delete"
        '
        'SelectStatusToolStripMenuItem
        '
        Me.SelectStatusToolStripMenuItem.Name = "SelectStatusToolStripMenuItem"
        Me.SelectStatusToolStripMenuItem.Size = New System.Drawing.Size(50, 19)
        Me.SelectStatusToolStripMenuItem.Text = "Select"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(12, 19)
        '
        'SaveStatusToolStripMenuItem
        '
        Me.SaveStatusToolStripMenuItem.Name = "SaveStatusToolStripMenuItem"
        Me.SaveStatusToolStripMenuItem.Size = New System.Drawing.Size(43, 19)
        Me.SaveStatusToolStripMenuItem.Text = "Save"
        Me.SaveStatusToolStripMenuItem.Visible = False
        '
        'TablesDataGridView
        '
        Me.TablesDataGridView.AllowUserToAddRows = False
        Me.TablesDataGridView.ColumnHeadersHeight = 26
        Me.TablesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.TablesDataGridView.Location = New System.Drawing.Point(18, 37)
        Me.TablesDataGridView.Margin = New System.Windows.Forms.Padding(9, 12, 9, 12)
        Me.TablesDataGridView.Name = "TablesDataGridView"
        Me.TablesDataGridView.ReadOnly = True
        Me.TablesDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.TablesDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.TablesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TablesDataGridView.Size = New System.Drawing.Size(107, 97)
        Me.TablesDataGridView.TabIndex = 122
        '
        'StatusesDataGridView
        '
        Me.StatusesDataGridView.AllowUserToAddRows = False
        Me.StatusesDataGridView.ColumnHeadersHeight = 26
        Me.StatusesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.StatusesDataGridView.Location = New System.Drawing.Point(102, 148)
        Me.StatusesDataGridView.Margin = New System.Windows.Forms.Padding(9, 12, 9, 12)
        Me.StatusesDataGridView.Name = "StatusesDataGridView"
        Me.StatusesDataGridView.ReadOnly = True
        Me.StatusesDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.StatusesDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.StatusesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.StatusesDataGridView.Size = New System.Drawing.Size(170, 94)
        Me.StatusesDataGridView.TabIndex = 126
        '
        'StatusDetailsGroupBox
        '
        Me.StatusDetailsGroupBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StatusDetailsGroupBox.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.StatusDetailsGroupBox.Controls.Add(Me.StatusByteTextBox)
        Me.StatusDetailsGroupBox.Controls.Add(Me.Label1)
        Me.StatusDetailsGroupBox.Controls.Add(Me.Label2)
        Me.StatusDetailsGroupBox.Controls.Add(Me.StatusOfActionTextBox)
        Me.StatusDetailsGroupBox.Controls.Add(Me.RemarksTextBox)
        Me.StatusDetailsGroupBox.Controls.Add(Me.Label4)
        Me.StatusDetailsGroupBox.Controls.Add(Me.SequenceOfActionTextBox)
        Me.StatusDetailsGroupBox.Controls.Add(Me.Label6)
        Me.StatusDetailsGroupBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusDetailsGroupBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.StatusDetailsGroupBox.Location = New System.Drawing.Point(304, 86)
        Me.StatusDetailsGroupBox.Name = "StatusDetailsGroupBox"
        Me.StatusDetailsGroupBox.Size = New System.Drawing.Size(570, 237)
        Me.StatusDetailsGroupBox.TabIndex = 127
        Me.StatusDetailsGroupBox.TabStop = False
        Me.StatusDetailsGroupBox.Text = "Status Details"
        Me.StatusDetailsGroupBox.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 165)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 20)
        Me.Label2.TabIndex = 132
        Me.Label2.Text = "Remarks"
        '
        'StatusOfActionTextBox
        '
        Me.StatusOfActionTextBox.Location = New System.Drawing.Point(189, 123)
        Me.StatusOfActionTextBox.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.StatusOfActionTextBox.Name = "StatusOfActionTextBox"
        Me.StatusOfActionTextBox.Size = New System.Drawing.Size(355, 26)
        Me.StatusOfActionTextBox.TabIndex = 131
        '
        'RemarksTextBox
        '
        Me.RemarksTextBox.Location = New System.Drawing.Point(189, 162)
        Me.RemarksTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RemarksTextBox.Multiline = True
        Me.RemarksTextBox.Name = "RemarksTextBox"
        Me.RemarksTextBox.Size = New System.Drawing.Size(355, 62)
        Me.RemarksTextBox.TabIndex = 130
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(31, 126)
        Me.Label4.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 20)
        Me.Label4.TabIndex = 129
        Me.Label4.Text = "Status"
        '
        'SequenceOfActionTextBox
        '
        Me.SequenceOfActionTextBox.Location = New System.Drawing.Point(190, 81)
        Me.SequenceOfActionTextBox.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.SequenceOfActionTextBox.Name = "SequenceOfActionTextBox"
        Me.SequenceOfActionTextBox.Size = New System.Drawing.Size(20, 26)
        Me.SequenceOfActionTextBox.TabIndex = 128
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(29, 87)
        Me.Label6.Margin = New System.Windows.Forms.Padding(9, 0, 9, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(149, 20)
        Me.Label6.TabIndex = 127
        Me.Label6.Text = "Sequence of Action"
        '
        'StatusByteTextBox
        '
        Me.StatusByteTextBox.Location = New System.Drawing.Point(190, 44)
        Me.StatusByteTextBox.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.StatusByteTextBox.Name = "StatusByteTextBox"
        Me.StatusByteTextBox.Size = New System.Drawing.Size(20, 26)
        Me.StatusByteTextBox.TabIndex = 134
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 50)
        Me.Label1.Margin = New System.Windows.Forms.Padding(9, 0, 9, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 20)
        Me.Label1.TabIndex = 133
        Me.Label1.Text = "Status_Byte"
        '
        'StatusForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1200, 692)
        Me.Controls.Add(Me.StatusDetailsGroupBox)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.StatusesDataGridView)
        Me.Controls.Add(Me.TablesDataGridView)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "StatusForm"
        Me.Text = "StatusForm"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.TablesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusDetailsGroupBox.ResumeLayout(False)
        Me.StatusDetailsGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents AddStatusToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditStatusToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteStatusToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelectStatusToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents TablesDataGridView As DataGridView
    Friend WithEvents StatusesDataGridView As DataGridView
    Friend WithEvents ReturnToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusDetailsGroupBox As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents StatusOfActionTextBox As TextBox
    Friend WithEvents RemarksTextBox As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents SequenceOfActionTextBox As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents SaveStatusToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusByteTextBox As TextBox
    Friend WithEvents Label1 As Label
End Class
