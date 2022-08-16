<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VehicleModelsRelationsDetailsForm
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
        Me.ModelLabel = New System.Windows.Forms.Label()
        Me.VehicleModelTextBox = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.CancelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActivatedBy = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.VehicleTrimTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.VehicleTypeTextBox = New System.Windows.Forms.TextBox()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ModelLabel
        '
        Me.ModelLabel.AutoSize = True
        Me.ModelLabel.Location = New System.Drawing.Point(8, 121)
        Me.ModelLabel.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.ModelLabel.Name = "ModelLabel"
        Me.ModelLabel.Size = New System.Drawing.Size(56, 20)
        Me.ModelLabel.TabIndex = 87
        Me.ModelLabel.Text = "Model:"
        '
        'VehicleModelTextBox
        '
        Me.VehicleModelTextBox.Location = New System.Drawing.Point(85, 120)
        Me.VehicleModelTextBox.Margin = New System.Windows.Forms.Padding(9, 12, 9, 12)
        Me.VehicleModelTextBox.Name = "VehicleModelTextBox"
        Me.VehicleModelTextBox.Size = New System.Drawing.Size(157, 26)
        Me.VehicleModelTextBox.TabIndex = 86
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CancelToolStripMenuItem, Me.SaveToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(14, 5, 0, 5)
        Me.MenuStrip1.Size = New System.Drawing.Size(567, 35)
        Me.MenuStrip1.TabIndex = 85
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
        'ActivatedBy
        '
        Me.ActivatedBy.Location = New System.Drawing.Point(128, 197)
        Me.ActivatedBy.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ActivatedBy.Name = "ActivatedBy"
        Me.ActivatedBy.Size = New System.Drawing.Size(220, 26)
        Me.ActivatedBy.TabIndex = 84
        Me.ActivatedBy.Text = "ActivatedBy"
        Me.ActivatedBy.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 176)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 20)
        Me.Label2.TabIndex = 83
        Me.Label2.Text = "TRIM :"
        '
        'VehicleTrimTextBox
        '
        Me.VehicleTrimTextBox.Location = New System.Drawing.Point(85, 170)
        Me.VehicleTrimTextBox.Margin = New System.Windows.Forms.Padding(9, 12, 9, 12)
        Me.VehicleTrimTextBox.Name = "VehicleTrimTextBox"
        Me.VehicleTrimTextBox.Size = New System.Drawing.Size(157, 26)
        Me.VehicleTrimTextBox.TabIndex = 82
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 76)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 20)
        Me.Label1.TabIndex = 81
        Me.Label1.Text = "MAKE :"
        '
        'VehicleTypeTextBox
        '
        Me.VehicleTypeTextBox.Location = New System.Drawing.Point(85, 70)
        Me.VehicleTypeTextBox.Margin = New System.Windows.Forms.Padding(9, 12, 9, 12)
        Me.VehicleTypeTextBox.Name = "VehicleTypeTextBox"
        Me.VehicleTypeTextBox.Size = New System.Drawing.Size(306, 26)
        Me.VehicleTypeTextBox.TabIndex = 80
        '
        'VehicleModelsRelationsDetailsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(567, 247)
        Me.ControlBox = False
        Me.Controls.Add(Me.ModelLabel)
        Me.Controls.Add(Me.VehicleModelTextBox)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.ActivatedBy)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.VehicleTrimTextBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.VehicleTypeTextBox)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "VehicleModelsRelationsDetailsForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VehicleModelsRelationsDetailsForm"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ModelLabel As Label
    Friend WithEvents VehicleModelTextBox As TextBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents CancelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ActivatedBy As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents VehicleTrimTextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents VehicleTypeTextBox As TextBox
End Class
