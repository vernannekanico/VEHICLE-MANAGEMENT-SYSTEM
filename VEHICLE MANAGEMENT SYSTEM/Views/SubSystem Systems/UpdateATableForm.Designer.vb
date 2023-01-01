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
        Me.PurchaseOrderItemsDataGridView = New System.Windows.Forms.DataGridView()
        Me.RowCountLabel = New System.Windows.Forms.Label()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.CancelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExtractedWordTypeComboBox = New System.Windows.Forms.ComboBox()
        Me.NewWordTextBox = New System.Windows.Forms.TextBox()
        Me.AddANewWordGroupBox = New System.Windows.Forms.GroupBox()
        Me.CancelNewWordButton = New System.Windows.Forms.Button()
        Me.SaveNewWordButton = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.RefreshDataGridViewButton = New System.Windows.Forms.Button()
        CType(Me.PurchaseOrderItemsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip2.SuspendLayout()
        Me.AddANewWordGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'PurchaseOrderItemsDataGridView
        '
        Me.PurchaseOrderItemsDataGridView.Anchor = System.Windows.Forms.AnchorStyles.Left
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PurchaseOrderItemsDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.PurchaseOrderItemsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.PurchaseOrderItemsDataGridView.DefaultCellStyle = DataGridViewCellStyle2
        Me.PurchaseOrderItemsDataGridView.Location = New System.Drawing.Point(650, 300)
        Me.PurchaseOrderItemsDataGridView.Name = "PurchaseOrderItemsDataGridView"
        Me.PurchaseOrderItemsDataGridView.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PurchaseOrderItemsDataGridView.Size = New System.Drawing.Size(355, 101)
        Me.PurchaseOrderItemsDataGridView.TabIndex = 0
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
        'NewWordTextBox
        '
        Me.NewWordTextBox.Location = New System.Drawing.Point(6, 60)
        Me.NewWordTextBox.Name = "NewWordTextBox"
        Me.NewWordTextBox.Size = New System.Drawing.Size(244, 26)
        Me.NewWordTextBox.TabIndex = 47
        '
        'AddANewWordGroupBox
        '
        Me.AddANewWordGroupBox.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.AddANewWordGroupBox.Controls.Add(Me.CancelNewWordButton)
        Me.AddANewWordGroupBox.Controls.Add(Me.SaveNewWordButton)
        Me.AddANewWordGroupBox.Controls.Add(Me.NewWordTextBox)
        Me.AddANewWordGroupBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddANewWordGroupBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.AddANewWordGroupBox.Location = New System.Drawing.Point(405, 99)
        Me.AddANewWordGroupBox.Name = "AddANewWordGroupBox"
        Me.AddANewWordGroupBox.Size = New System.Drawing.Size(256, 95)
        Me.AddANewWordGroupBox.TabIndex = 48
        Me.AddANewWordGroupBox.TabStop = False
        Me.AddANewWordGroupBox.Text = "Add A New Word"
        Me.AddANewWordGroupBox.Visible = False
        '
        'CancelNewWordButton
        '
        Me.CancelNewWordButton.Location = New System.Drawing.Point(133, 20)
        Me.CancelNewWordButton.Name = "CancelNewWordButton"
        Me.CancelNewWordButton.Size = New System.Drawing.Size(99, 34)
        Me.CancelNewWordButton.TabIndex = 49
        Me.CancelNewWordButton.Text = "Cancel"
        Me.CancelNewWordButton.UseVisualStyleBackColor = True
        '
        'SaveNewWordButton
        '
        Me.SaveNewWordButton.Location = New System.Drawing.Point(29, 20)
        Me.SaveNewWordButton.Name = "SaveNewWordButton"
        Me.SaveNewWordButton.Size = New System.Drawing.Size(99, 34)
        Me.SaveNewWordButton.TabIndex = 48
        Me.SaveNewWordButton.Text = "Save"
        Me.SaveNewWordButton.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(92, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 49
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'RefreshDataGridViewButton
        '
        Me.RefreshDataGridViewButton.Location = New System.Drawing.Point(198, 6)
        Me.RefreshDataGridViewButton.Name = "RefreshDataGridViewButton"
        Me.RefreshDataGridViewButton.Size = New System.Drawing.Size(125, 23)
        Me.RefreshDataGridViewButton.TabIndex = 50
        Me.RefreshDataGridViewButton.Text = "Refresh DataGridView"
        Me.RefreshDataGridViewButton.UseVisualStyleBackColor = True
        '
        'UpdateATableForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1284, 631)
        Me.Controls.Add(Me.RefreshDataGridViewButton)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.PurchaseOrderItemsDataGridView)
        Me.Controls.Add(Me.AddANewWordGroupBox)
        Me.Controls.Add(Me.ExtractedWordTypeComboBox)
        Me.Controls.Add(Me.MenuStrip2)
        Me.Controls.Add(Me.RowCountLabel)
        Me.Name = "UpdateATableForm"
        Me.Text = "TestForm"
        CType(Me.PurchaseOrderItemsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.AddANewWordGroupBox.ResumeLayout(False)
        Me.AddANewWordGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PurchaseOrderItemsDataGridView As DataGridView
    Friend WithEvents RowCountLabel As Label
    Friend WithEvents MenuStrip2 As MenuStrip
    Friend WithEvents CancelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ExtractedWordTypeComboBox As ComboBox
    Friend WithEvents NewWordTextBox As TextBox
    Friend WithEvents AddANewWordGroupBox As GroupBox
    Friend WithEvents CancelNewWordButton As Button
    Friend WithEvents SaveNewWordButton As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents RefreshDataGridViewButton As Button
End Class
