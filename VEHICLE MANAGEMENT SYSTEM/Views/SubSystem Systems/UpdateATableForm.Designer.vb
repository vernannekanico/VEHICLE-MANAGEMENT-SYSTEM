﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.FinalizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExtractedWordTypeComboBox = New System.Windows.Forms.ComboBox()
        Me.ExtractedWordTypeDataGridView = New System.Windows.Forms.DataGridView()
        Me.NewWordTextBox = New System.Windows.Forms.TextBox()
        Me.AddANewWordGroupBox = New System.Windows.Forms.GroupBox()
        Me.CancelNewWordButton = New System.Windows.Forms.Button()
        Me.SaveNewWordButton = New System.Windows.Forms.Button()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
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
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle25.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ProductsPartsDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle25
        Me.ProductsPartsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle26.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ProductsPartsDataGridView.DefaultCellStyle = DataGridViewCellStyle26
        Me.ProductsPartsDataGridView.Location = New System.Drawing.Point(0, 32)
        Me.ProductsPartsDataGridView.Name = "ProductsPartsDataGridView"
        Me.ProductsPartsDataGridView.Size = New System.Drawing.Size(355, 101)
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
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle27.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ExtractedWordsDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle27
        Me.ExtractedWordsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle28.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle28.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle28.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle28.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle28.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ExtractedWordsDataGridView.DefaultCellStyle = DataGridViewCellStyle28
        Me.ExtractedWordsDataGridView.Location = New System.Drawing.Point(0, 159)
        Me.ExtractedWordsDataGridView.Name = "ExtractedWordsDataGridView"
        Me.ExtractedWordsDataGridView.Size = New System.Drawing.Size(355, 101)
        Me.ExtractedWordsDataGridView.TabIndex = 3
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CancelToolStripMenuItem, Me.CUSTOMERToolStripMenuItem, Me.ToolStripMenuItem1, Me.SelectVehicleToolStripMenuItem, Me.ToolStripMenuItem2})
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
        Me.CUSTOMERToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectCustomerToolStripMenuItem})
        Me.CUSTOMERToolStripMenuItem.Enabled = False
        Me.CUSTOMERToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CUSTOMERToolStripMenuItem.Name = "CUSTOMERToolStripMenuItem"
        Me.CUSTOMERToolStripMenuItem.Size = New System.Drawing.Size(228, 25)
        Me.CUSTOMERToolStripMenuItem.Text = "Update ProductsPartsTable"
        '
        'SelectCustomerToolStripMenuItem
        '
        Me.SelectCustomerToolStripMenuItem.Name = "SelectCustomerToolStripMenuItem"
        Me.SelectCustomerToolStripMenuItem.Size = New System.Drawing.Size(186, 26)
        Me.SelectCustomerToolStripMenuItem.Text = "Extract Words"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(12, 25)
        '
        'SelectVehicleToolStripMenuItem
        '
        Me.SelectVehicleToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProcessVehicleToolStripMenuItem, Me.RePhraseToolStripMenuItem, Me.RePhraseAllToolStripMenuItem, Me.AddANewWordToolStripMenuItem, Me.JoinWordsToolStripMenuItem, Me.FinalizeToolStripMenuItem})
        Me.SelectVehicleToolStripMenuItem.Enabled = False
        Me.SelectVehicleToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SelectVehicleToolStripMenuItem.Name = "SelectVehicleToolStripMenuItem"
        Me.SelectVehicleToolStripMenuItem.Size = New System.Drawing.Size(194, 25)
        Me.SelectVehicleToolStripMenuItem.Text = ":  EXTRACTED WORDS :"
        '
        'ProcessVehicleToolStripMenuItem
        '
        Me.ProcessVehicleToolStripMenuItem.Name = "ProcessVehicleToolStripMenuItem"
        Me.ProcessVehicleToolStripMenuItem.Size = New System.Drawing.Size(199, 26)
        Me.ProcessVehicleToolStripMenuItem.Text = "Process"
        '
        'RePhraseToolStripMenuItem
        '
        Me.RePhraseToolStripMenuItem.Name = "RePhraseToolStripMenuItem"
        Me.RePhraseToolStripMenuItem.Size = New System.Drawing.Size(199, 26)
        Me.RePhraseToolStripMenuItem.Text = "RePhrase"
        '
        'RePhraseAllToolStripMenuItem
        '
        Me.RePhraseAllToolStripMenuItem.Name = "RePhraseAllToolStripMenuItem"
        Me.RePhraseAllToolStripMenuItem.Size = New System.Drawing.Size(199, 26)
        Me.RePhraseAllToolStripMenuItem.Text = "RePhrase All"
        '
        'AddANewWordToolStripMenuItem
        '
        Me.AddANewWordToolStripMenuItem.Name = "AddANewWordToolStripMenuItem"
        Me.AddANewWordToolStripMenuItem.Size = New System.Drawing.Size(199, 26)
        Me.AddANewWordToolStripMenuItem.Text = "AddANewWord"
        '
        'JoinWordsToolStripMenuItem
        '
        Me.JoinWordsToolStripMenuItem.Name = "JoinWordsToolStripMenuItem"
        Me.JoinWordsToolStripMenuItem.Size = New System.Drawing.Size(199, 26)
        Me.JoinWordsToolStripMenuItem.Text = "JoinWords"
        '
        'FinalizeToolStripMenuItem
        '
        Me.FinalizeToolStripMenuItem.Name = "FinalizeToolStripMenuItem"
        Me.FinalizeToolStripMenuItem.Size = New System.Drawing.Size(199, 26)
        Me.FinalizeToolStripMenuItem.Text = "Finalize"
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
        DataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle29.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle29.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle29.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle29.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle29.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ExtractedWordTypeDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle29
        Me.ExtractedWordTypeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle30.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle30.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle30.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle30.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle30.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ExtractedWordTypeDataGridView.DefaultCellStyle = DataGridViewCellStyle30
        Me.ExtractedWordTypeDataGridView.Location = New System.Drawing.Point(0, 304)
        Me.ExtractedWordTypeDataGridView.Name = "ExtractedWordTypeDataGridView"
        Me.ExtractedWordTypeDataGridView.Size = New System.Drawing.Size(355, 49)
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
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(278, 25)
        Me.ToolStripMenuItem2.Text = "Update VehicleInformationsTable"
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
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents SelectVehicleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExtractedWordTypeComboBox As ComboBox
    Friend WithEvents ExtractedWordTypeDataGridView As DataGridView
    Friend WithEvents NewWordTextBox As TextBox
    Friend WithEvents AddANewWordGroupBox As GroupBox
    Friend WithEvents CancelNewWordButton As Button
    Friend WithEvents SaveNewWordButton As Button
    Friend WithEvents SelectCustomerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProcessVehicleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RePhraseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RePhraseAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddANewWordToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents JoinWordsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FinalizeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
End Class