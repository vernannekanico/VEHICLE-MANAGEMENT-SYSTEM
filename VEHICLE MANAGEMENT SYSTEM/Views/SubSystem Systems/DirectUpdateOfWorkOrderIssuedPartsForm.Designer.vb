<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DirectUpdateOfWorkOrderIssuedPartsForm
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.CancelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdatePackingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WorkOrderIssuedPartsTablesDataGridView = New System.Windows.Forms.DataGridView()
        Me.GlobalUpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteThisIssuedItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip2.SuspendLayout()
        CType(Me.WorkOrderIssuedPartsTablesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CancelToolStripMenuItem, Me.ToolStripMenuItem1, Me.UpdatePackingToolStripMenuItem, Me.RefreshViewToolStripMenuItem, Me.GlobalUpdateToolStripMenuItem, Me.DeleteThisIssuedItemToolStripMenuItem})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(800, 29)
        Me.MenuStrip2.TabIndex = 56
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
        'RefreshViewToolStripMenuItem
        '
        Me.RefreshViewToolStripMenuItem.Name = "RefreshViewToolStripMenuItem"
        Me.RefreshViewToolStripMenuItem.Size = New System.Drawing.Size(113, 25)
        Me.RefreshViewToolStripMenuItem.Text = "Refresh View"
        '
        'WorkOrderIssuedPartsTablesDataGridView
        '
        Me.WorkOrderIssuedPartsTablesDataGridView.Anchor = System.Windows.Forms.AnchorStyles.Left
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.WorkOrderIssuedPartsTablesDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.WorkOrderIssuedPartsTablesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.WorkOrderIssuedPartsTablesDataGridView.DefaultCellStyle = DataGridViewCellStyle4
        Me.WorkOrderIssuedPartsTablesDataGridView.Location = New System.Drawing.Point(12, 66)
        Me.WorkOrderIssuedPartsTablesDataGridView.MultiSelect = False
        Me.WorkOrderIssuedPartsTablesDataGridView.Name = "WorkOrderIssuedPartsTablesDataGridView"
        Me.WorkOrderIssuedPartsTablesDataGridView.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.WorkOrderIssuedPartsTablesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.WorkOrderIssuedPartsTablesDataGridView.Size = New System.Drawing.Size(355, 101)
        Me.WorkOrderIssuedPartsTablesDataGridView.TabIndex = 55
        '
        'GlobalUpdateToolStripMenuItem
        '
        Me.GlobalUpdateToolStripMenuItem.Name = "GlobalUpdateToolStripMenuItem"
        Me.GlobalUpdateToolStripMenuItem.Size = New System.Drawing.Size(121, 25)
        Me.GlobalUpdateToolStripMenuItem.Text = "Global Update"
        '
        'DeleteThisIssuedItemToolStripMenuItem
        '
        Me.DeleteThisIssuedItemToolStripMenuItem.Name = "DeleteThisIssuedItemToolStripMenuItem"
        Me.DeleteThisIssuedItemToolStripMenuItem.Size = New System.Drawing.Size(181, 25)
        Me.DeleteThisIssuedItemToolStripMenuItem.Text = "Delete This Issued Item"
        '
        'DirectUpdateOfWorkOrderIssuedPartsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.MenuStrip2)
        Me.Controls.Add(Me.WorkOrderIssuedPartsTablesDataGridView)
        Me.Name = "DirectUpdateOfWorkOrderIssuedPartsForm"
        Me.Text = "DirectUpdateOfWorkOrderIssuedPartsForm"
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        CType(Me.WorkOrderIssuedPartsTablesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip2 As MenuStrip
    Friend WithEvents CancelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents UpdatePackingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RefreshViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WorkOrderIssuedPartsTablesDataGridView As DataGridView
    Friend WithEvents GlobalUpdateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteThisIssuedItemToolStripMenuItem As ToolStripMenuItem
End Class
