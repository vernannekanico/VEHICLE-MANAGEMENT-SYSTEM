<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdateATableForm
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ProductsPartsDataGridView = New System.Windows.Forms.DataGridView()
        Me.RowCountLabel = New System.Windows.Forms.Label()
        Me.ExtractedWordsDataGridView = New System.Windows.Forms.DataGridView()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.CancelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CUSTOMERToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectCustomerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectVehicleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProcessVehicleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RePhraseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RePhraseAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddANewWordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.JoinWordsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExtractedWordTypeComboBox = New System.Windows.Forms.ComboBox()
        Me.ExtractedWordTypeDataGridView = New System.Windows.Forms.DataGridView()
        Me.NewWordTextBox = New System.Windows.Forms.TextBox()
        Me.AddANewWordGroupBox = New System.Windows.Forms.GroupBox()
        Me.CancelNewWordButton = New System.Windows.Forms.Button()
        Me.SaveNewWordButton = New System.Windows.Forms.Button()
        Me.FinalizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.ProductsPartsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExtractedWordsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip2.SuspendLayout()
        CType(Me.ExtractedWordTypeDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AddANewWordGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'ProductsPartsDataGridView
        '
        Me.ProductsPartsDataGridView.Anchor = System.Windows.Forms.AnchorStyles.Left
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ProductsPartsDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.ProductsPartsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ProductsPartsDataGridView.DefaultCellStyle = DataGridViewCellStyle2
        Me.ProductsPartsDataGridView.Location = New System.Drawing.Point(0, 32)
        Me.ProductsPartsDataGridView.Name = "ProductsPartsDataGridView"
        Me.ProductsPartsDataGridView.Size = New System.Drawing.Size(355, 356)
        Me.ProductsPartsDataGridView.TabIndex = 0
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
        'ExtractedWordsDataGridView
        '
        Me.ExtractedWordsDataGridView.Anchor = System.Windows.Forms.AnchorStyles.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ExtractedWordsDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.ExtractedWordsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ExtractedWordsDataGridView.DefaultCellStyle = DataGridViewCellStyle4
        Me.ExtractedWordsDataGridView.Location = New System.Drawing.Point(905, 32)
        Me.ExtractedWordsDataGridView.Name = "ExtractedWordsDataGridView"
        Me.ExtractedWordsDataGridView.Size = New System.Drawing.Size(238, 101)
        Me.ExtractedWordsDataGridView.TabIndex = 3
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CancelToolStripMenuItem, Me.CUSTOMERToolStripMenuItem, Me.SelectCustomerToolStripMenuItem, Me.ToolStripMenuItem1, Me.SelectVehicleToolStripMenuItem, Me.ProcessVehicleToolStripMenuItem, Me.RePhraseToolStripMenuItem, Me.RePhraseAllToolStripMenuItem, Me.AddANewWordToolStripMenuItem, Me.JoinWordsToolStripMenuItem, Me.FinalizeToolStripMenuItem})
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
        'CUSTOMERToolStripMenuItem
        '
        Me.CUSTOMERToolStripMenuItem.Enabled = False
        Me.CUSTOMERToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CUSTOMERToolStripMenuItem.Name = "CUSTOMERToolStripMenuItem"
        Me.CUSTOMERToolStripMenuItem.Size = New System.Drawing.Size(134, 25)
        Me.CUSTOMERToolStripMenuItem.Text = "Products/Parts"
        '
        'SelectCustomerToolStripMenuItem
        '
        Me.SelectCustomerToolStripMenuItem.Name = "SelectCustomerToolStripMenuItem"
        Me.SelectCustomerToolStripMenuItem.Size = New System.Drawing.Size(117, 25)
        Me.SelectCustomerToolStripMenuItem.Text = "Extract Words"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(12, 25)
        '
        'SelectVehicleToolStripMenuItem
        '
        Me.SelectVehicleToolStripMenuItem.Enabled = False
        Me.SelectVehicleToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SelectVehicleToolStripMenuItem.Name = "SelectVehicleToolStripMenuItem"
        Me.SelectVehicleToolStripMenuItem.Size = New System.Drawing.Size(194, 25)
        Me.SelectVehicleToolStripMenuItem.Text = ":  EXTRACTED WORDS :"
        '
        'ProcessVehicleToolStripMenuItem
        '
        Me.ProcessVehicleToolStripMenuItem.Name = "ProcessVehicleToolStripMenuItem"
        Me.ProcessVehicleToolStripMenuItem.Size = New System.Drawing.Size(75, 25)
        Me.ProcessVehicleToolStripMenuItem.Text = "Process"
        '
        'RePhraseToolStripMenuItem
        '
        Me.RePhraseToolStripMenuItem.Name = "RePhraseToolStripMenuItem"
        Me.RePhraseToolStripMenuItem.Size = New System.Drawing.Size(87, 25)
        Me.RePhraseToolStripMenuItem.Text = "RePhrase"
        '
        'RePhraseAllToolStripMenuItem
        '
        Me.RePhraseAllToolStripMenuItem.Name = "RePhraseAllToolStripMenuItem"
        Me.RePhraseAllToolStripMenuItem.Size = New System.Drawing.Size(109, 25)
        Me.RePhraseAllToolStripMenuItem.Text = "RePhrase All"
        '
        'AddANewWordToolStripMenuItem
        '
        Me.AddANewWordToolStripMenuItem.Name = "AddANewWordToolStripMenuItem"
        Me.AddANewWordToolStripMenuItem.Size = New System.Drawing.Size(130, 25)
        Me.AddANewWordToolStripMenuItem.Text = "AddANewWord"
        '
        'JoinWordsToolStripMenuItem
        '
        Me.JoinWordsToolStripMenuItem.Name = "JoinWordsToolStripMenuItem"
        Me.JoinWordsToolStripMenuItem.Size = New System.Drawing.Size(95, 25)
        Me.JoinWordsToolStripMenuItem.Text = "JoinWords"
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
        'ExtractedWordTypeDataGridView
        '
        Me.ExtractedWordTypeDataGridView.Anchor = System.Windows.Forms.AnchorStyles.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ExtractedWordTypeDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.ExtractedWordTypeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ExtractedWordTypeDataGridView.DefaultCellStyle = DataGridViewCellStyle6
        Me.ExtractedWordTypeDataGridView.Location = New System.Drawing.Point(511, 421)
        Me.ExtractedWordTypeDataGridView.Name = "ExtractedWordTypeDataGridView"
        Me.ExtractedWordTypeDataGridView.Size = New System.Drawing.Size(248, 49)
        Me.ExtractedWordTypeDataGridView.TabIndex = 46
        Me.ExtractedWordTypeDataGridView.Visible = False
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
        'FinalizeToolStripMenuItem
        '
        Me.FinalizeToolStripMenuItem.Name = "FinalizeToolStripMenuItem"
        Me.FinalizeToolStripMenuItem.Size = New System.Drawing.Size(74, 25)
        Me.FinalizeToolStripMenuItem.Text = "Finalize"
        '
        'UpdateATableForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1284, 631)
        Me.Controls.Add(Me.AddANewWordGroupBox)
        Me.Controls.Add(Me.ExtractedWordsDataGridView)
        Me.Controls.Add(Me.ExtractedWordTypeComboBox)
        Me.Controls.Add(Me.ExtractedWordTypeDataGridView)
        Me.Controls.Add(Me.MenuStrip2)
        Me.Controls.Add(Me.RowCountLabel)
        Me.Controls.Add(Me.ProductsPartsDataGridView)
        Me.Name = "UpdateATableForm"
        Me.Text = "TestForm"
        CType(Me.ProductsPartsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExtractedWordsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        CType(Me.ExtractedWordTypeDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AddANewWordGroupBox.ResumeLayout(False)
        Me.AddANewWordGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ProductsPartsDataGridView As DataGridView
    Friend WithEvents RowCountLabel As Label
    Friend WithEvents ExtractedWordsDataGridView As DataGridView
    Friend WithEvents MenuStrip2 As MenuStrip
    Friend WithEvents CancelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CUSTOMERToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelectCustomerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents SelectVehicleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProcessVehicleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExtractedWordTypeComboBox As ComboBox
    Friend WithEvents ExtractedWordTypeDataGridView As DataGridView
    Friend WithEvents RePhraseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RePhraseAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddANewWordToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NewWordTextBox As TextBox
    Friend WithEvents AddANewWordGroupBox As GroupBox
    Friend WithEvents CancelNewWordButton As Button
    Friend WithEvents SaveNewWordButton As Button
    Friend WithEvents JoinWordsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FinalizeToolStripMenuItem As ToolStripMenuItem
End Class
