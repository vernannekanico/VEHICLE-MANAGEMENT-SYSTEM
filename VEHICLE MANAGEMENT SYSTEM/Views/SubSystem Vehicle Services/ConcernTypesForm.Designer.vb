<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConcernTypesForm
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
        Me.ConcernTypeDataGridView = New System.Windows.Forms.DataGridView()
        Me.ActivatedByTextBox = New System.Windows.Forms.TextBox()
        Me.ConcernTypeMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.CancelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModifyGroupBox = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ConcernTypeTextBox = New System.Windows.Forms.TextBox()
        Me.ConcernTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ActionToTakeTextBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.ConcernTypeDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ConcernTypeMenuStrip.SuspendLayout()
        Me.ModifyGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'ConcernTypeDataGridView
        '
        Me.ConcernTypeDataGridView.AllowUserToAddRows = False
        Me.ConcernTypeDataGridView.AllowUserToDeleteRows = False
        Me.ConcernTypeDataGridView.AllowUserToResizeColumns = False
        Me.ConcernTypeDataGridView.AllowUserToResizeRows = False
        Me.ConcernTypeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ConcernTypeDataGridView.Location = New System.Drawing.Point(-3, 43)
        Me.ConcernTypeDataGridView.Margin = New System.Windows.Forms.Padding(5)
        Me.ConcernTypeDataGridView.MultiSelect = False
        Me.ConcernTypeDataGridView.Name = "ConcernTypeDataGridView"
        Me.ConcernTypeDataGridView.ReadOnly = True
        Me.ConcernTypeDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ConcernTypeDataGridView.Size = New System.Drawing.Size(198, 147)
        Me.ConcernTypeDataGridView.TabIndex = 0
        '
        'ActivatedByTextBox
        '
        Me.ActivatedByTextBox.Location = New System.Drawing.Point(245, 43)
        Me.ActivatedByTextBox.Name = "ActivatedByTextBox"
        Me.ActivatedByTextBox.Size = New System.Drawing.Size(100, 26)
        Me.ActivatedByTextBox.TabIndex = 44
        Me.ActivatedByTextBox.Text = "ActivatedBy"
        Me.ActivatedByTextBox.Visible = False
        '
        'ConcernTypeMenuStrip
        '
        Me.ConcernTypeMenuStrip.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ConcernTypeMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CancelToolStripMenuItem, Me.SelectToolStripMenuItem, Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.ViewToolStripMenuItem, Me.SaveToolStripMenuItem})
        Me.ConcernTypeMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.ConcernTypeMenuStrip.Name = "ConcernTypeMenuStrip"
        Me.ConcernTypeMenuStrip.Size = New System.Drawing.Size(1045, 29)
        Me.ConcernTypeMenuStrip.TabIndex = 60
        Me.ConcernTypeMenuStrip.Text = "MenuStrip1"
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
        'ModifyGroupBox
        '
        Me.ModifyGroupBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ModifyGroupBox.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ModifyGroupBox.Controls.Add(Me.ActionToTakeTextBox)
        Me.ModifyGroupBox.Controls.Add(Me.Label3)
        Me.ModifyGroupBox.Controls.Add(Me.ConcernTextBox)
        Me.ModifyGroupBox.Controls.Add(Me.Label2)
        Me.ModifyGroupBox.Controls.Add(Me.ConcernTypeTextBox)
        Me.ModifyGroupBox.Controls.Add(Me.Label1)
        Me.ModifyGroupBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ModifyGroupBox.Location = New System.Drawing.Point(224, 114)
        Me.ModifyGroupBox.Name = "ModifyGroupBox"
        Me.ModifyGroupBox.Size = New System.Drawing.Size(704, 172)
        Me.ModifyGroupBox.TabIndex = 61
        Me.ModifyGroupBox.TabStop = False
        Me.ModifyGroupBox.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(19, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Code"
        '
        'ConcernTypeTextBox
        '
        Me.ConcernTypeTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ConcernTypeTextBox.Location = New System.Drawing.Point(214, 25)
        Me.ConcernTypeTextBox.Name = "ConcernTypeTextBox"
        Me.ConcernTypeTextBox.Size = New System.Drawing.Size(58, 29)
        Me.ConcernTypeTextBox.TabIndex = 1
        '
        'ConcernTextBox
        '
        Me.ConcernTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ConcernTextBox.Location = New System.Drawing.Point(214, 66)
        Me.ConcernTextBox.Name = "ConcernTextBox"
        Me.ConcernTextBox.Size = New System.Drawing.Size(460, 29)
        Me.ConcernTextBox.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(19, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(166, 24)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Type of Concern"
        '
        'ActionToTakeTextBox
        '
        Me.ActionToTakeTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ActionToTakeTextBox.Location = New System.Drawing.Point(214, 113)
        Me.ActionToTakeTextBox.Name = "ActionToTakeTextBox"
        Me.ActionToTakeTextBox.Size = New System.Drawing.Size(339, 29)
        Me.ActionToTakeTextBox.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 119)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(142, 24)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Action to take "
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(55, 25)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(56, 25)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'ConcernTypeForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1045, 408)
        Me.ControlBox = False
        Me.Controls.Add(Me.ModifyGroupBox)
        Me.Controls.Add(Me.ConcernTypeMenuStrip)
        Me.Controls.Add(Me.ActivatedByTextBox)
        Me.Controls.Add(Me.ConcernTypeDataGridView)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "ConcernTypeForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ConcernTypeForm"
        CType(Me.ConcernTypeDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ConcernTypeMenuStrip.ResumeLayout(False)
        Me.ConcernTypeMenuStrip.PerformLayout()
        Me.ModifyGroupBox.ResumeLayout(False)
        Me.ModifyGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ConcernTypeDataGridView As DataGridView
    Friend WithEvents ActivatedByTextBox As TextBox
    Friend WithEvents ConcernTypeMenuStrip As MenuStrip
    Friend WithEvents CancelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ModifyGroupBox As GroupBox
    Friend WithEvents ActionToTakeTextBox As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ConcernTextBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ConcernTypeTextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
End Class
