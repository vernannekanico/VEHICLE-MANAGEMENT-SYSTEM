<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ConcernsForm
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
        Me.ConcernsDataGridView = New System.Windows.Forms.DataGridView()
        Me.ConcernTypesComboBox = New System.Windows.Forms.ComboBox()
        Me.SearchToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.SearchConcernTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.CancelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.JobsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModifyGroupBox = New System.Windows.Forms.GroupBox()
        Me.ConcernTextBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ConcernTypeTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.ConcernsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SearchToolStrip.SuspendLayout()
        Me.MenuStrip.SuspendLayout()
        Me.ModifyGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'ConcernsDataGridView
        '
        Me.ConcernsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ConcernsDataGridView.Location = New System.Drawing.Point(33, 144)
        Me.ConcernsDataGridView.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ConcernsDataGridView.Name = "ConcernsDataGridView"
        Me.ConcernsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ConcernsDataGridView.Size = New System.Drawing.Size(332, 254)
        Me.ConcernsDataGridView.TabIndex = 0
        '
        'ConcernTypesComboBox
        '
        Me.ConcernTypesComboBox.FormattingEnabled = True
        Me.ConcernTypesComboBox.Location = New System.Drawing.Point(213, 85)
        Me.ConcernTypesComboBox.Name = "ConcernTypesComboBox"
        Me.ConcernTypesComboBox.Size = New System.Drawing.Size(446, 28)
        Me.ConcernTypesComboBox.TabIndex = 41
        '
        'SearchToolStrip
        '
        Me.SearchToolStrip.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.SearchConcernTextBox})
        Me.SearchToolStrip.Location = New System.Drawing.Point(0, 29)
        Me.SearchToolStrip.Name = "SearchToolStrip"
        Me.SearchToolStrip.Size = New System.Drawing.Size(961, 29)
        Me.SearchToolStrip.TabIndex = 62
        Me.SearchToolStrip.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(75, 26)
        Me.ToolStripLabel1.Text = "Concerns"
        '
        'SearchConcernTextBox
        '
        Me.SearchConcernTextBox.Font = New System.Drawing.Font("Segoe UI", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchConcernTextBox.Name = "SearchConcernTextBox"
        Me.SearchConcernTextBox.Size = New System.Drawing.Size(300, 29)
        Me.SearchConcernTextBox.Text = "Search"
        '
        'MenuStrip
        '
        Me.MenuStrip.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CancelToolStripMenuItem, Me.SelectToolStripMenuItem, Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.ToolStripMenuItem1, Me.ViewToolStripMenuItem, Me.SaveToolStripMenuItem, Me.JobsToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(961, 29)
        Me.MenuStrip.TabIndex = 60
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
        'JobsToolStripMenuItem
        '
        Me.JobsToolStripMenuItem.Name = "JobsToolStripMenuItem"
        Me.JobsToolStripMenuItem.Size = New System.Drawing.Size(53, 25)
        Me.JobsToolStripMenuItem.Text = "Jobs"
        '
        'ModifyGroupBox
        '
        Me.ModifyGroupBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ModifyGroupBox.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ModifyGroupBox.Controls.Add(Me.ConcernTextBox)
        Me.ModifyGroupBox.Controls.Add(Me.Label3)
        Me.ModifyGroupBox.Controls.Add(Me.ConcernTypeTextBox)
        Me.ModifyGroupBox.Controls.Add(Me.Label2)
        Me.ModifyGroupBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ModifyGroupBox.Location = New System.Drawing.Point(402, 148)
        Me.ModifyGroupBox.Name = "ModifyGroupBox"
        Me.ModifyGroupBox.Size = New System.Drawing.Size(704, 185)
        Me.ModifyGroupBox.TabIndex = 64
        Me.ModifyGroupBox.TabStop = False
        Me.ModifyGroupBox.Visible = False
        '
        'ConcernTextBox
        '
        Me.ConcernTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ConcernTextBox.Location = New System.Drawing.Point(222, 79)
        Me.ConcernTextBox.Multiline = True
        Me.ConcernTextBox.Name = "ConcernTextBox"
        Me.ConcernTextBox.Size = New System.Drawing.Size(470, 89)
        Me.ConcernTextBox.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(27, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 24)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Concern"
        '
        'ConcernTypeTextBox
        '
        Me.ConcernTypeTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ConcernTypeTextBox.Location = New System.Drawing.Point(222, 32)
        Me.ConcernTypeTextBox.Name = "ConcernTypeTextBox"
        Me.ConcernTypeTextBox.Size = New System.Drawing.Size(268, 29)
        Me.ConcernTypeTextBox.TabIndex = 15
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(27, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(166, 24)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Type of Concern"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(29, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(178, 24)
        Me.Label1.TabIndex = 65
        Me.Label1.Text = "Type of Concern :"
        '
        'ConcernsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(961, 412)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ModifyGroupBox)
        Me.Controls.Add(Me.SearchToolStrip)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.ConcernTypesComboBox)
        Me.Controls.Add(Me.ConcernsDataGridView)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "ConcernsForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Concerns"
        CType(Me.ConcernsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SearchToolStrip.ResumeLayout(False)
        Me.SearchToolStrip.PerformLayout()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ModifyGroupBox.ResumeLayout(False)
        Me.ModifyGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ConcernsDataGridView As DataGridView
    Friend WithEvents ConcernTypesComboBox As ComboBox
    Friend WithEvents SearchToolStrip As ToolStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents SearchConcernTextBox As ToolStripTextBox
    Friend WithEvents MenuStrip As MenuStrip
    Friend WithEvents CancelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ModifyGroupBox As GroupBox
    Friend WithEvents ConcernTextBox As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ConcernTypeTextBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label1 As Label
    Friend WithEvents JobsToolStripMenuItem As ToolStripMenuItem
End Class
