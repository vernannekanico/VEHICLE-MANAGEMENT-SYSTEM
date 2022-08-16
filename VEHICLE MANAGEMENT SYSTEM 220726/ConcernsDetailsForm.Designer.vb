<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConcernsDetailsForm
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.CancelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActivatedByTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ConcernTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ConcernTypeTextBox = New System.Windows.Forms.TextBox()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CancelToolStripMenuItem, Me.SaveToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(14, 5, 0, 5)
        Me.MenuStrip1.Size = New System.Drawing.Size(844, 35)
        Me.MenuStrip1.TabIndex = 77
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'CancelToolStripMenuItem
        '
        Me.CancelToolStripMenuItem.Name = "CancelToolStripMenuItem"
        Me.CancelToolStripMenuItem.Size = New System.Drawing.Size(40, 25)
        Me.CancelToolStripMenuItem.Text = "◄ "
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(58, 25)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'ActivatedByTextBox
        '
        Me.ActivatedByTextBox.Location = New System.Drawing.Point(157, 123)
        Me.ActivatedByTextBox.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ActivatedByTextBox.Name = "ActivatedByTextBox"
        Me.ActivatedByTextBox.Size = New System.Drawing.Size(220, 26)
        Me.ActivatedByTextBox.TabIndex = 76
        Me.ActivatedByTextBox.Text = "ActivatedBy"
        Me.ActivatedByTextBox.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 92)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 20)
        Me.Label2.TabIndex = 73
        Me.Label2.Text = "Concern"
        '
        'ConcernTextBox
        '
        Me.ConcernTextBox.Location = New System.Drawing.Point(171, 86)
        Me.ConcernTextBox.Margin = New System.Windows.Forms.Padding(9, 12, 9, 12)
        Me.ConcernTextBox.Name = "ConcernTextBox"
        Me.ConcernTextBox.Size = New System.Drawing.Size(530, 26)
        Me.ConcernTextBox.TabIndex = 72
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 53)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 20)
        Me.Label1.TabIndex = 71
        Me.Label1.Text = "Type of Concern"
        '
        'ConcernTypeTextBox
        '
        Me.ConcernTypeTextBox.Location = New System.Drawing.Point(171, 47)
        Me.ConcernTypeTextBox.Margin = New System.Windows.Forms.Padding(9, 12, 9, 12)
        Me.ConcernTypeTextBox.Name = "ConcernTypeTextBox"
        Me.ConcernTypeTextBox.Size = New System.Drawing.Size(306, 26)
        Me.ConcernTypeTextBox.TabIndex = 70
        '
        'ConcernsDetailsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(844, 164)
        Me.ControlBox = False
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.ActivatedByTextBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ConcernTextBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ConcernTypeTextBox)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ConcernsDetailsForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ConcernsDetailsForm"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents CancelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ActivatedByTextBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ConcernTextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ConcernTypeTextBox As TextBox
End Class
