<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DirectUpdateATableStandardForm
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
        Me.AddAProductdGroupBox = New System.Windows.Forms.GroupBox()
        Me.CancelButton = New System.Windows.Forms.Button()
        Me.SaveButton = New System.Windows.Forms.Button()
        Me.ProductDescTextBox = New System.Windows.Forms.TextBox()
        Me.ExtractedWordTypeComboBox = New System.Windows.Forms.ComboBox()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.CancelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GlobalUpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteThisWorkOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WorkOrderRequestedPartsTablesDataGridView = New System.Windows.Forms.DataGridView()
        Me.AddAProductdGroupBox.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        CType(Me.WorkOrderRequestedPartsTablesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AddAProductdGroupBox
        '
        Me.AddAProductdGroupBox.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.AddAProductdGroupBox.Controls.Add(Me.CancelButton)
        Me.AddAProductdGroupBox.Controls.Add(Me.SaveButton)
        Me.AddAProductdGroupBox.Controls.Add(Me.ProductDescTextBox)
        Me.AddAProductdGroupBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddAProductdGroupBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.AddAProductdGroupBox.Location = New System.Drawing.Point(423, 119)
        Me.AddAProductdGroupBox.Name = "AddAProductdGroupBox"
        Me.AddAProductdGroupBox.Size = New System.Drawing.Size(380, 132)
        Me.AddAProductdGroupBox.TabIndex = 64
        Me.AddAProductdGroupBox.TabStop = False
        Me.AddAProductdGroupBox.Text = "Add A Product"
        Me.AddAProductdGroupBox.Visible = False
        '
        'CancelButton
        '
        Me.CancelButton.Location = New System.Drawing.Point(196, 20)
        Me.CancelButton.Name = "CancelButton"
        Me.CancelButton.Size = New System.Drawing.Size(153, 34)
        Me.CancelButton.TabIndex = 49
        Me.CancelButton.Text = "Cancel"
        Me.CancelButton.UseVisualStyleBackColor = True
        '
        'SaveButton
        '
        Me.SaveButton.Location = New System.Drawing.Point(17, 20)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(173, 34)
        Me.SaveButton.TabIndex = 48
        Me.SaveButton.Text = "Save"
        Me.SaveButton.UseVisualStyleBackColor = True
        '
        'ProductDescTextBox
        '
        Me.ProductDescTextBox.Location = New System.Drawing.Point(6, 60)
        Me.ProductDescTextBox.Multiline = True
        Me.ProductDescTextBox.Name = "ProductDescTextBox"
        Me.ProductDescTextBox.Size = New System.Drawing.Size(368, 61)
        Me.ProductDescTextBox.TabIndex = 47
        '
        'ExtractedWordTypeComboBox
        '
        Me.ExtractedWordTypeComboBox.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.ExtractedWordTypeComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExtractedWordTypeComboBox.ForeColor = System.Drawing.SystemColors.ScrollBar
        Me.ExtractedWordTypeComboBox.FormattingEnabled = True
        Me.ExtractedWordTypeComboBox.Location = New System.Drawing.Point(411, 61)
        Me.ExtractedWordTypeComboBox.Name = "ExtractedWordTypeComboBox"
        Me.ExtractedWordTypeComboBox.Size = New System.Drawing.Size(458, 28)
        Me.ExtractedWordTypeComboBox.TabIndex = 63
        Me.ExtractedWordTypeComboBox.Visible = False
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CancelToolStripMenuItem, Me.ToolStripMenuItem1, Me.EditToolStripMenuItem, Me.GlobalUpdateToolStripMenuItem, Me.RefreshViewToolStripMenuItem, Me.DeleteThisWorkOrderToolStripMenuItem})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(990, 29)
        Me.MenuStrip2.TabIndex = 62
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
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(48, 25)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'GlobalUpdateToolStripMenuItem
        '
        Me.GlobalUpdateToolStripMenuItem.Name = "GlobalUpdateToolStripMenuItem"
        Me.GlobalUpdateToolStripMenuItem.Size = New System.Drawing.Size(121, 25)
        Me.GlobalUpdateToolStripMenuItem.Text = "Global Update"
        '
        'RefreshViewToolStripMenuItem
        '
        Me.RefreshViewToolStripMenuItem.Name = "RefreshViewToolStripMenuItem"
        Me.RefreshViewToolStripMenuItem.Size = New System.Drawing.Size(113, 25)
        Me.RefreshViewToolStripMenuItem.Text = "Refresh View"
        '
        'DeleteThisWorkOrderToolStripMenuItem
        '
        Me.DeleteThisWorkOrderToolStripMenuItem.Name = "DeleteThisWorkOrderToolStripMenuItem"
        Me.DeleteThisWorkOrderToolStripMenuItem.Size = New System.Drawing.Size(184, 25)
        Me.DeleteThisWorkOrderToolStripMenuItem.Text = "Delete This Work Order"
        '
        'WorkOrderRequestedPartsTablesDataGridView
        '
        Me.WorkOrderRequestedPartsTablesDataGridView.Anchor = System.Windows.Forms.AnchorStyles.Left
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.WorkOrderRequestedPartsTablesDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.WorkOrderRequestedPartsTablesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.WorkOrderRequestedPartsTablesDataGridView.DefaultCellStyle = DataGridViewCellStyle4
        Me.WorkOrderRequestedPartsTablesDataGridView.Location = New System.Drawing.Point(37, 150)
        Me.WorkOrderRequestedPartsTablesDataGridView.MultiSelect = False
        Me.WorkOrderRequestedPartsTablesDataGridView.Name = "WorkOrderRequestedPartsTablesDataGridView"
        Me.WorkOrderRequestedPartsTablesDataGridView.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.WorkOrderRequestedPartsTablesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.WorkOrderRequestedPartsTablesDataGridView.Size = New System.Drawing.Size(355, 101)
        Me.WorkOrderRequestedPartsTablesDataGridView.TabIndex = 61
        '
        'DirectUpdateATableStandardForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(990, 450)
        Me.Controls.Add(Me.AddAProductdGroupBox)
        Me.Controls.Add(Me.ExtractedWordTypeComboBox)
        Me.Controls.Add(Me.MenuStrip2)
        Me.Controls.Add(Me.WorkOrderRequestedPartsTablesDataGridView)
        Me.Name = "DirectUpdateATableStandardForm"
        Me.Text = "DirectUpdateATableStandardForm"
        Me.AddAProductdGroupBox.ResumeLayout(False)
        Me.AddAProductdGroupBox.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        CType(Me.WorkOrderRequestedPartsTablesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AddAProductdGroupBox As GroupBox
    Friend WithEvents CancelButton As Button
    Friend WithEvents SaveButton As Button
    Friend WithEvents ProductDescTextBox As TextBox
    Friend WithEvents ExtractedWordTypeComboBox As ComboBox
    Friend WithEvents MenuStrip2 As MenuStrip
    Friend WithEvents CancelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WorkOrderRequestedPartsTablesDataGridView As DataGridView
    Friend WithEvents GlobalUpdateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RefreshViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteThisWorkOrderToolStripMenuItem As ToolStripMenuItem
End Class
