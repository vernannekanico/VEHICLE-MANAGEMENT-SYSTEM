<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DirectUpdateOfWorkOrderRequestedPartsTableForm
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.CancelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdatePackingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WorkOrderRequestedPartsTablesDataGridView = New System.Windows.Forms.DataGridView()
        Me.RefreshViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip2.SuspendLayout()
        CType(Me.WorkOrderRequestedPartsTablesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CancelToolStripMenuItem, Me.ToolStripMenuItem1, Me.UpdatePackingToolStripMenuItem, Me.RefreshViewToolStripMenuItem})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(1014, 29)
        Me.MenuStrip2.TabIndex = 54
        Me.MenuStrip2.Text = "MenuStrip2"
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
        'UpdatePackingToolStripMenuItem
        '
        Me.UpdatePackingToolStripMenuItem.Name = "UpdatePackingToolStripMenuItem"
        Me.UpdatePackingToolStripMenuItem.Size = New System.Drawing.Size(129, 25)
        Me.UpdatePackingToolStripMenuItem.Text = "Update Packing"
        '
        'WorkOrderRequestedPartsTablesDataGridView
        '
        Me.WorkOrderRequestedPartsTablesDataGridView.Anchor = System.Windows.Forms.AnchorStyles.Left
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.WorkOrderRequestedPartsTablesDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.WorkOrderRequestedPartsTablesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.WorkOrderRequestedPartsTablesDataGridView.DefaultCellStyle = DataGridViewCellStyle8
        Me.WorkOrderRequestedPartsTablesDataGridView.Location = New System.Drawing.Point(6, 192)
        Me.WorkOrderRequestedPartsTablesDataGridView.MultiSelect = False
        Me.WorkOrderRequestedPartsTablesDataGridView.Name = "WorkOrderRequestedPartsTablesDataGridView"
        Me.WorkOrderRequestedPartsTablesDataGridView.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.WorkOrderRequestedPartsTablesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.WorkOrderRequestedPartsTablesDataGridView.Size = New System.Drawing.Size(355, 101)
        Me.WorkOrderRequestedPartsTablesDataGridView.TabIndex = 53
        '
        'RefreshViewToolStripMenuItem
        '
        Me.RefreshViewToolStripMenuItem.Name = "RefreshViewToolStripMenuItem"
        Me.RefreshViewToolStripMenuItem.Size = New System.Drawing.Size(113, 25)
        Me.RefreshViewToolStripMenuItem.Text = "Refresh View"
        '
        'DirectUpdateOfWorkOrderRequestedPartsTableForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1014, 450)
        Me.Controls.Add(Me.MenuStrip2)
        Me.Controls.Add(Me.WorkOrderRequestedPartsTablesDataGridView)
        Me.Name = "DirectUpdateOfWorkOrderRequestedPartsTableForm"
        Me.Text = "DirectUpdateOfWorkOrderRequestedPartsTableForm"
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        CType(Me.WorkOrderRequestedPartsTablesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip2 As MenuStrip
    Friend WithEvents CancelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents UpdatePackingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WorkOrderRequestedPartsTablesDataGridView As DataGridView
    Friend WithEvents RefreshViewToolStripMenuItem As ToolStripMenuItem
End Class
