<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TemporaryForThisProjectForm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.FluidSpecificationsDataGridView = New System.Windows.Forms.DataGridView()
        Me.SpecificationsMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.CancelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.FluidSpecificationsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SpecificationsMenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'FluidSpecificationsDataGridView
        '
        Me.FluidSpecificationsDataGridView.AllowUserToAddRows = False
        Me.FluidSpecificationsDataGridView.AllowUserToDeleteRows = False
        Me.FluidSpecificationsDataGridView.AllowUserToOrderColumns = True
        Me.FluidSpecificationsDataGridView.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.FluidSpecificationsDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.FluidSpecificationsDataGridView.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.FluidSpecificationsDataGridView.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
        Me.FluidSpecificationsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Menu
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.FluidSpecificationsDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.FluidSpecificationsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.FluidSpecificationsDataGridView.DefaultCellStyle = DataGridViewCellStyle3
        Me.FluidSpecificationsDataGridView.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.FluidSpecificationsDataGridView.Location = New System.Drawing.Point(526, 197)
        Me.FluidSpecificationsDataGridView.Name = "FluidSpecificationsDataGridView"
        Me.FluidSpecificationsDataGridView.ReadOnly = True
        Me.FluidSpecificationsDataGridView.RowHeadersVisible = False
        Me.FluidSpecificationsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.FluidSpecificationsDataGridView.Size = New System.Drawing.Size(233, 121)
        Me.FluidSpecificationsDataGridView.TabIndex = 99
        '
        'SpecificationsMenuStrip
        '
        Me.SpecificationsMenuStrip.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpecificationsMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CancelToolStripMenuItem, Me.ToolStripMenuItem2})
        Me.SpecificationsMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.SpecificationsMenuStrip.Name = "SpecificationsMenuStrip"
        Me.SpecificationsMenuStrip.Size = New System.Drawing.Size(1284, 29)
        Me.SpecificationsMenuStrip.TabIndex = 100
        Me.SpecificationsMenuStrip.Text = "MenuStrip1"
        '
        'CancelToolStripMenuItem
        '
        Me.CancelToolStripMenuItem.Name = "CancelToolStripMenuItem"
        Me.CancelToolStripMenuItem.Size = New System.Drawing.Size(40, 25)
        Me.CancelToolStripMenuItem.Text = "◄ "
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(12, 25)
        '
        'TemporaryForThisProjectForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1284, 514)
        Me.Controls.Add(Me.SpecificationsMenuStrip)
        Me.Controls.Add(Me.FluidSpecificationsDataGridView)
        Me.Name = "TemporaryForThisProjectForm"
        Me.Text = "TempoearyForThisProjectForm"
        CType(Me.FluidSpecificationsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SpecificationsMenuStrip.ResumeLayout(False)
        Me.SpecificationsMenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents FluidSpecificationsDataGridView As DataGridView
    Friend WithEvents SpecificationsMenuStrip As MenuStrip
    Friend WithEvents CancelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
End Class
