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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.WorkOrderRequestedPartsTablesDataGridView = New System.Windows.Forms.DataGridView()
        Me.RowCountLabel = New System.Windows.Forms.Label()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.CancelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExtractedWordTypeComboBox = New System.Windows.Forms.ComboBox()
        Me.ProductDescTextBox = New System.Windows.Forms.TextBox()
        Me.AddAProductdGroupBox = New System.Windows.Forms.GroupBox()
        Me.CancelButton = New System.Windows.Forms.Button()
        Me.SaveButton = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.RefreshDataGridViewButton = New System.Windows.Forms.Button()
        Me.EditWorkOrderRequestedPartsTableButton = New System.Windows.Forms.Button()
        Me.DeleteThisJobButton = New System.Windows.Forms.Button()
        CType(Me.WorkOrderRequestedPartsTablesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip2.SuspendLayout()
        Me.AddAProductdGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'WorkOrderRequestedPartsTablesDataGridView
        '
        Me.WorkOrderRequestedPartsTablesDataGridView.Anchor = System.Windows.Forms.AnchorStyles.Left
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.WorkOrderRequestedPartsTablesDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.WorkOrderRequestedPartsTablesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.WorkOrderRequestedPartsTablesDataGridView.DefaultCellStyle = DataGridViewCellStyle2
        Me.WorkOrderRequestedPartsTablesDataGridView.Location = New System.Drawing.Point(31, 119)
        Me.WorkOrderRequestedPartsTablesDataGridView.MultiSelect = False
        Me.WorkOrderRequestedPartsTablesDataGridView.Name = "WorkOrderRequestedPartsTablesDataGridView"
        Me.WorkOrderRequestedPartsTablesDataGridView.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.WorkOrderRequestedPartsTablesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.WorkOrderRequestedPartsTablesDataGridView.Size = New System.Drawing.Size(355, 101)
        Me.WorkOrderRequestedPartsTablesDataGridView.TabIndex = 0
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
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CancelToolStripMenuItem, Me.ToolStripMenuItem1})
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
        'ExtractedWordTypeComboBox
        '
        Me.ExtractedWordTypeComboBox.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.ExtractedWordTypeComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExtractedWordTypeComboBox.ForeColor = System.Drawing.SystemColors.ScrollBar
        Me.ExtractedWordTypeComboBox.FormattingEnabled = True
        Me.ExtractedWordTypeComboBox.Location = New System.Drawing.Point(377, 32)
        Me.ExtractedWordTypeComboBox.Name = "ExtractedWordTypeComboBox"
        Me.ExtractedWordTypeComboBox.Size = New System.Drawing.Size(458, 28)
        Me.ExtractedWordTypeComboBox.TabIndex = 45
        Me.ExtractedWordTypeComboBox.Visible = False
        '
        'ProductDescTextBox
        '
        Me.ProductDescTextBox.Location = New System.Drawing.Point(6, 60)
        Me.ProductDescTextBox.Multiline = True
        Me.ProductDescTextBox.Name = "ProductDescTextBox"
        Me.ProductDescTextBox.Size = New System.Drawing.Size(368, 61)
        Me.ProductDescTextBox.TabIndex = 47
        '
        'AddAProductdGroupBox
        '
        Me.AddAProductdGroupBox.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.AddAProductdGroupBox.Controls.Add(Me.CancelButton)
        Me.AddAProductdGroupBox.Controls.Add(Me.SaveButton)
        Me.AddAProductdGroupBox.Controls.Add(Me.ProductDescTextBox)
        Me.AddAProductdGroupBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddAProductdGroupBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.AddAProductdGroupBox.Location = New System.Drawing.Point(405, 99)
        Me.AddAProductdGroupBox.Name = "AddAProductdGroupBox"
        Me.AddAProductdGroupBox.Size = New System.Drawing.Size(380, 132)
        Me.AddAProductdGroupBox.TabIndex = 48
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
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(121, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(111, 23)
        Me.Button1.TabIndex = 49
        Me.Button1.Text = "Global Update"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'RefreshDataGridViewButton
        '
        Me.RefreshDataGridViewButton.Location = New System.Drawing.Point(1007, 0)
        Me.RefreshDataGridViewButton.Name = "RefreshDataGridViewButton"
        Me.RefreshDataGridViewButton.Size = New System.Drawing.Size(125, 23)
        Me.RefreshDataGridViewButton.TabIndex = 50
        Me.RefreshDataGridViewButton.Text = "Refresh DataGridView"
        Me.RefreshDataGridViewButton.UseVisualStyleBackColor = True
        '
        'EditWorkOrderRequestedPartsTableButton
        '
        Me.EditWorkOrderRequestedPartsTableButton.Location = New System.Drawing.Point(352, 3)
        Me.EditWorkOrderRequestedPartsTableButton.Name = "EditWorkOrderRequestedPartsTableButton"
        Me.EditWorkOrderRequestedPartsTableButton.Size = New System.Drawing.Size(125, 23)
        Me.EditWorkOrderRequestedPartsTableButton.TabIndex = 51
        Me.EditWorkOrderRequestedPartsTableButton.Text = "Edit WorkOrderRequestedPartsTable"
        Me.EditWorkOrderRequestedPartsTableButton.UseVisualStyleBackColor = True
        '
        'DeleteThisJobButton
        '
        Me.DeleteThisJobButton.Location = New System.Drawing.Point(494, 3)
        Me.DeleteThisJobButton.Name = "DeleteThisJobButton"
        Me.DeleteThisJobButton.Size = New System.Drawing.Size(125, 23)
        Me.DeleteThisJobButton.TabIndex = 52
        Me.DeleteThisJobButton.Text = "Delete This WO Request"
        Me.DeleteThisJobButton.UseVisualStyleBackColor = True
        '
        'UpdateATableForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1284, 631)
        Me.Controls.Add(Me.DeleteThisJobButton)
        Me.Controls.Add(Me.AddAProductdGroupBox)
        Me.Controls.Add(Me.EditWorkOrderRequestedPartsTableButton)
        Me.Controls.Add(Me.RefreshDataGridViewButton)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ExtractedWordTypeComboBox)
        Me.Controls.Add(Me.MenuStrip2)
        Me.Controls.Add(Me.RowCountLabel)
        Me.Controls.Add(Me.WorkOrderRequestedPartsTablesDataGridView)
        Me.Name = "UpdateATableForm"
        Me.Text = "TestForm"
        CType(Me.WorkOrderRequestedPartsTablesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.AddAProductdGroupBox.ResumeLayout(False)
        Me.AddAProductdGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents WorkOrderRequestedPartsTablesDataGridView As DataGridView
    Friend WithEvents RowCountLabel As Label
    Friend WithEvents MenuStrip2 As MenuStrip
    Friend WithEvents CancelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ExtractedWordTypeComboBox As ComboBox
    Friend WithEvents ProductDescTextBox As TextBox
    Friend WithEvents AddAProductdGroupBox As GroupBox
    Friend WithEvents CancelButton As Button
    Friend WithEvents SaveButton As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents RefreshDataGridViewButton As Button
    Friend WithEvents EditWorkOrderRequestedPartsTableButton As Button
    Friend WithEvents DeleteThisJobButton As Button
End Class
