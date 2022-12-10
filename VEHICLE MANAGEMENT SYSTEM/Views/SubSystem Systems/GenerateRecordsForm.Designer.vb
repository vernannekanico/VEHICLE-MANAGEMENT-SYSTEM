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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.OriginalExcelRecordsDataGridView = New System.Windows.Forms.DataGridView()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.CancelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerateWorkOrdersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RetructureCODEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateWorkOrderRelationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateVehicleRepairClassCodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WorkOrderRelationsTableDataGridView = New System.Windows.Forms.DataGridView()
        Me.TemporaryDataGridView = New System.Windows.Forms.DataGridView()
        CType(Me.OriginalExcelRecordsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip.SuspendLayout()
        CType(Me.WorkOrderRelationsTableDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TemporaryDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OriginalExcelRecordsDataGridView
        '
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.OriginalExcelRecordsDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.OriginalExcelRecordsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.OriginalExcelRecordsDataGridView.Location = New System.Drawing.Point(24, 61)
        Me.OriginalExcelRecordsDataGridView.Margin = New System.Windows.Forms.Padding(6)
        Me.OriginalExcelRecordsDataGridView.Name = "OriginalExcelRecordsDataGridView"
        Me.OriginalExcelRecordsDataGridView.RowHeadersWidth = 51
        Me.OriginalExcelRecordsDataGridView.Size = New System.Drawing.Size(2810, 200)
        Me.OriginalExcelRecordsDataGridView.TabIndex = 3
        '
        'MenuStrip
        '
        Me.MenuStrip.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CancelToolStripMenuItem, Me.GenerateWorkOrdersToolStripMenuItem, Me.RetructureCODEToolStripMenuItem, Me.UpdateWorkOrderRelationsToolStripMenuItem, Me.UpdateVehicleRepairClassCodeToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Padding = New System.Windows.Forms.Padding(12, 3, 0, 3)
        Me.MenuStrip.Size = New System.Drawing.Size(1284, 31)
        Me.MenuStrip.TabIndex = 61
        Me.MenuStrip.Text = "MenuStrip1"
        '
        'CancelToolStripMenuItem
        '
        Me.CancelToolStripMenuItem.Name = "CancelToolStripMenuItem"
        Me.CancelToolStripMenuItem.Size = New System.Drawing.Size(40, 25)
        Me.CancelToolStripMenuItem.Text = "◄ "
        '
        'GenerateWorkOrdersToolStripMenuItem
        '
        Me.GenerateWorkOrdersToolStripMenuItem.Name = "GenerateWorkOrdersToolStripMenuItem"
        Me.GenerateWorkOrdersToolStripMenuItem.Size = New System.Drawing.Size(178, 25)
        Me.GenerateWorkOrdersToolStripMenuItem.Text = "Generate Work Orders"
        '
        'RetructureCODEToolStripMenuItem
        '
        Me.RetructureCODEToolStripMenuItem.Name = "RetructureCODEToolStripMenuItem"
        Me.RetructureCODEToolStripMenuItem.Size = New System.Drawing.Size(154, 25)
        Me.RetructureCODEToolStripMenuItem.Text = "Re-Structure CODE"
        '
        'UpdateWorkOrderRelationsToolStripMenuItem
        '
        Me.UpdateWorkOrderRelationsToolStripMenuItem.Name = "UpdateWorkOrderRelationsToolStripMenuItem"
        Me.UpdateWorkOrderRelationsToolStripMenuItem.Size = New System.Drawing.Size(214, 25)
        Me.UpdateWorkOrderRelationsToolStripMenuItem.Text = "UpdateWorkOrderRelations"
        '
        'UpdateVehicleRepairClassCodeToolStripMenuItem
        '
        Me.UpdateVehicleRepairClassCodeToolStripMenuItem.Name = "UpdateVehicleRepairClassCodeToolStripMenuItem"
        Me.UpdateVehicleRepairClassCodeToolStripMenuItem.Size = New System.Drawing.Size(258, 25)
        Me.UpdateVehicleRepairClassCodeToolStripMenuItem.Text = "Update a specific field of any table"
        '
        'WorkOrderRelationsTableDataGridView
        '
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.WorkOrderRelationsTableDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.WorkOrderRelationsTableDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.WorkOrderRelationsTableDataGridView.Location = New System.Drawing.Point(111, 81)
        Me.WorkOrderRelationsTableDataGridView.Margin = New System.Windows.Forms.Padding(6)
        Me.WorkOrderRelationsTableDataGridView.Name = "WorkOrderRelationsTableDataGridView"
        Me.WorkOrderRelationsTableDataGridView.RowHeadersWidth = 51
        Me.WorkOrderRelationsTableDataGridView.Size = New System.Drawing.Size(810, 200)
        Me.WorkOrderRelationsTableDataGridView.TabIndex = 62
        '
        'TemporaryDataGridView
        '
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TemporaryDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.TemporaryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TemporaryDataGridView.Location = New System.Drawing.Point(175, 273)
        Me.TemporaryDataGridView.Margin = New System.Windows.Forms.Padding(6)
        Me.TemporaryDataGridView.Name = "TemporaryDataGridView"
        Me.TemporaryDataGridView.RowHeadersWidth = 51
        Me.TemporaryDataGridView.Size = New System.Drawing.Size(810, 200)
        Me.TemporaryDataGridView.TabIndex = 63
        Me.TemporaryDataGridView.Visible = False
        '
        'GenerateRecordsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1284, 452)
        Me.Controls.Add(Me.TemporaryDataGridView)
        Me.Controls.Add(Me.WorkOrderRelationsTableDataGridView)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.OriginalExcelRecordsDataGridView)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "GenerateRecordsForm"
        Me.Text = "Generate Records From The Exel Files."
        CType(Me.OriginalExcelRecordsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        CType(Me.WorkOrderRelationsTableDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TemporaryDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OriginalExcelRecordsDataGridView As DataGridView
    Friend WithEvents MenuStrip As MenuStrip
    Friend WithEvents CancelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GenerateWorkOrdersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RetructureCODEToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UpdateWorkOrderRelationsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WorkOrderRelationsTableDataGridView As DataGridView
    Friend WithEvents UpdateVehicleRepairClassCodeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TemporaryDataGridView As DataGridView
End Class
