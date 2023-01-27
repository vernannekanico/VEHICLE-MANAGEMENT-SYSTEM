<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UpdateATableForm
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
        Me.RowCountLabel = New System.Windows.Forms.Label()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.CancelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateProductPackingRelationOfTheWorkOrderRequestedPartsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateProductPackingRelationOfTheWorkOrderRequestedPartsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdatteATableStabdardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'RowCountLabel
        '
        Me.RowCountLabel.AutoSize = True
        Me.RowCountLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RowCountLabel.Location = New System.Drawing.Point(373, 585)
        Me.RowCountLabel.Name = "RowCountLabel"
        Me.RowCountLabel.Size = New System.Drawing.Size(72, 24)
        Me.RowCountLabel.TabIndex = 2
        Me.RowCountLabel.Text = "Label1"
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CancelToolStripMenuItem, Me.ToolStripMenuItem1, Me.UpdateToolStripMenuItem})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(1284, 29)
        Me.MenuStrip2.TabIndex = 44
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
        'UpdateToolStripMenuItem
        '
        Me.UpdateToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UpdateProductPackingRelationOfTheWorkOrderRequestedPartsToolStripMenuItem, Me.UpdateProductPackingRelationOfTheWorkOrderRequestedPartsToolStripMenuItem1, Me.UpdatteATableStabdardToolStripMenuItem})
        Me.UpdateToolStripMenuItem.Name = "UpdateToolStripMenuItem"
        Me.UpdateToolStripMenuItem.Size = New System.Drawing.Size(153, 25)
        Me.UpdateToolStripMenuItem.Text = "Update A Table List"
        '
        'UpdateProductPackingRelationOfTheWorkOrderRequestedPartsToolStripMenuItem
        '
        Me.UpdateProductPackingRelationOfTheWorkOrderRequestedPartsToolStripMenuItem.Enabled = False
        Me.UpdateProductPackingRelationOfTheWorkOrderRequestedPartsToolStripMenuItem.Name = "UpdateProductPackingRelationOfTheWorkOrderRequestedPartsToolStripMenuItem"
        Me.UpdateProductPackingRelationOfTheWorkOrderRequestedPartsToolStripMenuItem.Size = New System.Drawing.Size(687, 26)
        Me.UpdateProductPackingRelationOfTheWorkOrderRequestedPartsToolStripMenuItem.Text = "Update ProductsPartsPackingRelationID_LongInteger of WorkOrderRequestedPartsTable" &
    ""
        '
        'UpdateProductPackingRelationOfTheWorkOrderRequestedPartsToolStripMenuItem1
        '
        Me.UpdateProductPackingRelationOfTheWorkOrderRequestedPartsToolStripMenuItem1.Name = "UpdateProductPackingRelationOfTheWorkOrderRequestedPartsToolStripMenuItem1"
        Me.UpdateProductPackingRelationOfTheWorkOrderRequestedPartsToolStripMenuItem1.Size = New System.Drawing.Size(687, 26)
        Me.UpdateProductPackingRelationOfTheWorkOrderRequestedPartsToolStripMenuItem1.Text = "Update ProductsPartsPackingRelationID_LongInteger of  WorkOrderIssuedPartsTable"
        '
        'UpdatteATableStabdardToolStripMenuItem
        '
        Me.UpdatteATableStabdardToolStripMenuItem.Name = "UpdatteATableStabdardToolStripMenuItem"
        Me.UpdatteATableStabdardToolStripMenuItem.Size = New System.Drawing.Size(687, 26)
        Me.UpdatteATableStabdardToolStripMenuItem.Text = "Update A Table Standard"
        '
        'UpdateATableForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1284, 631)
        Me.Controls.Add(Me.MenuStrip2)
        Me.Controls.Add(Me.RowCountLabel)
        Me.Name = "UpdateATableForm"
        Me.Text = "TestForm"
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RowCountLabel As Label
    Friend WithEvents MenuStrip2 As MenuStrip
    Friend WithEvents CancelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents UpdateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UpdateProductPackingRelationOfTheWorkOrderRequestedPartsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UpdateProductPackingRelationOfTheWorkOrderRequestedPartsToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents UpdatteATableStabdardToolStripMenuItem As ToolStripMenuItem
End Class
