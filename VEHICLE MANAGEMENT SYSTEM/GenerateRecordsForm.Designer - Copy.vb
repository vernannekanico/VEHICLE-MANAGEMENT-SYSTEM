<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GenerateRecordsForm
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
        Me.OriginalExcelRecordsDataGridView = New System.Windows.Forms.DataGridView()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.CancelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerateWorkOrdersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.OriginalExcelRecordsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'OriginalExcelRecordsDataGridView
        '
        Me.OriginalExcelRecordsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.OriginalExcelRecordsDataGridView.Location = New System.Drawing.Point(24, 61)
        Me.OriginalExcelRecordsDataGridView.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.OriginalExcelRecordsDataGridView.Name = "OriginalExcelRecordsDataGridView"
        Me.OriginalExcelRecordsDataGridView.RowHeadersWidth = 51
        Me.OriginalExcelRecordsDataGridView.Size = New System.Drawing.Size(2810, 908)
        Me.OriginalExcelRecordsDataGridView.TabIndex = 3
        '
        'MenuStrip
        '
        Me.MenuStrip.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CancelToolStripMenuItem, Me.GenerateWorkOrdersToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Padding = New System.Windows.Forms.Padding(12, 3, 0, 3)
        Me.MenuStrip.Size = New System.Drawing.Size(1924, 38)
        Me.MenuStrip.TabIndex = 61
        Me.MenuStrip.Text = "MenuStrip1"
        '
        'CancelToolStripMenuItem
        '
        Me.CancelToolStripMenuItem.Name = "CancelToolStripMenuItem"
        Me.CancelToolStripMenuItem.Size = New System.Drawing.Size(48, 32)
        Me.CancelToolStripMenuItem.Text = "◄ "
        '
        'GenerateWorkOrdersToolStripMenuItem
        '
        Me.GenerateWorkOrdersToolStripMenuItem.Name = "GenerateWorkOrdersToolStripMenuItem"
        Me.GenerateWorkOrdersToolStripMenuItem.Size = New System.Drawing.Size(221, 32)
        Me.GenerateWorkOrdersToolStripMenuItem.Text = "Generate Work Orders"
        '
        'GenerateRecordsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1924, 1055)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.OriginalExcelRecordsDataGridView)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.Name = "GenerateRecordsForm"
        Me.Text = "Generate Records From The Exel Files."
        CType(Me.OriginalExcelRecordsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OriginalExcelRecordsDataGridView As DataGridView
    Friend WithEvents MenuStrip As MenuStrip
    Friend WithEvents CancelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GenerateWorkOrdersToolStripMenuItem As ToolStripMenuItem
End Class
