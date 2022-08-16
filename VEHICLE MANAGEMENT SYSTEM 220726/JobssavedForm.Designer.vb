<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class JobsForm
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
        Me.AddJobToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveJobToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateProcedureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.JobsDataGridView = New System.Windows.Forms.DataGridView()
        Me.ActivatedByTextBox = New System.Windows.Forms.TextBox()
        Me.DefaultVehicleModelTextBox = New System.Windows.Forms.TextBox()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.JobsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CancelToolStripMenuItem, Me.AddJobToolStripMenuItem, Me.RemoveJobToolStripMenuItem, Me.CreateProcedureToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(9, 3, 0, 3)
        Me.MenuStrip1.Size = New System.Drawing.Size(1060, 31)
        Me.MenuStrip1.TabIndex = 48
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'CancelToolStripMenuItem
        '
        Me.CancelToolStripMenuItem.Name = "CancelToolStripMenuItem"
        Me.CancelToolStripMenuItem.Size = New System.Drawing.Size(40, 25)
        Me.CancelToolStripMenuItem.Text = "◄ "
        '
        'AddJobToolStripMenuItem
        '
        Me.AddJobToolStripMenuItem.Name = "AddJobToolStripMenuItem"
        Me.AddJobToolStripMenuItem.Size = New System.Drawing.Size(50, 25)
        Me.AddJobToolStripMenuItem.Text = "Add"
        '
        'RemoveJobToolStripMenuItem
        '
        Me.RemoveJobToolStripMenuItem.Name = "RemoveJobToolStripMenuItem"
        Me.RemoveJobToolStripMenuItem.Size = New System.Drawing.Size(107, 25)
        Me.RemoveJobToolStripMenuItem.Text = "Remove Job"
        '
        'CreateProcedureToolStripMenuItem
        '
        Me.CreateProcedureToolStripMenuItem.Name = "CreateProcedureToolStripMenuItem"
        Me.CreateProcedureToolStripMenuItem.Size = New System.Drawing.Size(142, 25)
        Me.CreateProcedureToolStripMenuItem.Text = "Create Procedure"
        '
        'JobsDataGridView
        '
        Me.JobsDataGridView.AllowUserToAddRows = False
        Me.JobsDataGridView.AllowUserToDeleteRows = False
        Me.JobsDataGridView.AllowUserToOrderColumns = True
        Me.JobsDataGridView.AllowUserToResizeRows = False
        Me.JobsDataGridView.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.JobsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.JobsDataGridView.Location = New System.Drawing.Point(18, 126)
        Me.JobsDataGridView.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.JobsDataGridView.MultiSelect = False
        Me.JobsDataGridView.Name = "JobsDataGridView"
        Me.JobsDataGridView.ReadOnly = True
        Me.JobsDataGridView.RowHeadersVisible = False
        Me.JobsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.JobsDataGridView.Size = New System.Drawing.Size(1024, 234)
        Me.JobsDataGridView.TabIndex = 46
        '
        'ActivatedByTextBox
        '
        Me.ActivatedByTextBox.Location = New System.Drawing.Point(836, 89)
        Me.ActivatedByTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ActivatedByTextBox.Name = "ActivatedByTextBox"
        Me.ActivatedByTextBox.Size = New System.Drawing.Size(148, 26)
        Me.ActivatedByTextBox.TabIndex = 49
        Me.ActivatedByTextBox.Visible = False
        '
        'DefaultVehicleModelTextBox
        '
        Me.DefaultVehicleModelTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DefaultVehicleModelTextBox.Location = New System.Drawing.Point(18, 49)
        Me.DefaultVehicleModelTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DefaultVehicleModelTextBox.Name = "DefaultVehicleModelTextBox"
        Me.DefaultVehicleModelTextBox.Size = New System.Drawing.Size(1032, 31)
        Me.DefaultVehicleModelTextBox.TabIndex = 81
        Me.DefaultVehicleModelTextBox.Text = "Set Default Vehicle"
        '
        'JobsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1060, 446)
        Me.Controls.Add(Me.DefaultVehicleModelTextBox)
        Me.Controls.Add(Me.ActivatedByTextBox)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.JobsDataGridView)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "JobsForm"
        Me.Text = "JobsForm"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.JobsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents CancelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddJobToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RemoveJobToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents JobsDataGridView As DataGridView
    Friend WithEvents ActivatedByTextBox As TextBox
    Friend WithEvents CreateProcedureToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DefaultVehicleModelTextBox As TextBox
End Class
