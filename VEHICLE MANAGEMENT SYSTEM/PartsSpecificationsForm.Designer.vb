<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PartsSpecificationsForm
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SpecificationsMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.CancelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SpeceficationsItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FluidSpecificationsDetailsGroup = New System.Windows.Forms.GroupBox()
        Me.PartNumberButton = New System.Windows.Forms.Button()
        Me.VolumeSpecificationButton = New System.Windows.Forms.Button()
        Me.FluidTypeSpecificationButton = New System.Windows.Forms.Button()
        Me.SpecifiedPartNumberTextBox = New System.Windows.Forms.TextBox()
        Me.SpecifiedQuantityTextBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SpecifiedUnitTextBox = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ServiceToPerformTextBox = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.FluidSpecificationsTextBox = New System.Windows.Forms.TextBox()
        Me.Specification = New System.Windows.Forms.Label()
        Me.WorkOrderPartsDataGridView = New System.Windows.Forms.DataGridView()
        Me.PartDetailsGroupBox = New System.Windows.Forms.GroupBox()
        Me.SpecificationsGroupBox = New System.Windows.Forms.GroupBox()
        Me.SpecificationsDataGridView = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.PartDescriptionTextBox = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.SpecificationsMenuStrip.SuspendLayout()
        Me.FluidSpecificationsDetailsGroup.SuspendLayout()
        CType(Me.WorkOrderPartsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PartDetailsGroupBox.SuspendLayout()
        Me.SpecificationsGroupBox.SuspendLayout()
        CType(Me.SpecificationsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SpecificationsMenuStrip
        '
        Me.SpecificationsMenuStrip.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpecificationsMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CancelToolStripMenuItem, Me.SpeceficationsItemToolStripMenuItem, Me.SaveToolStripMenuItem, Me.ToolStripMenuItem1, Me.ToolStripMenuItem2})
        Me.SpecificationsMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.SpecificationsMenuStrip.Name = "SpecificationsMenuStrip"
        Me.SpecificationsMenuStrip.Size = New System.Drawing.Size(1284, 29)
        Me.SpecificationsMenuStrip.TabIndex = 54
        Me.SpecificationsMenuStrip.Text = "MenuStrip1"
        '
        'CancelToolStripMenuItem
        '
        Me.CancelToolStripMenuItem.Name = "CancelToolStripMenuItem"
        Me.CancelToolStripMenuItem.Size = New System.Drawing.Size(40, 25)
        Me.CancelToolStripMenuItem.Text = "◄ "
        '
        'SpeceficationsItemToolStripMenuItem
        '
        Me.SpeceficationsItemToolStripMenuItem.Enabled = False
        Me.SpeceficationsItemToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpeceficationsItemToolStripMenuItem.Name = "SpeceficationsItemToolStripMenuItem"
        Me.SpeceficationsItemToolStripMenuItem.Size = New System.Drawing.Size(197, 25)
        Me.SpeceficationsItemToolStripMenuItem.Text = "PART SPECIFICATIONS :"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(55, 25)
        Me.SaveToolStripMenuItem.Text = "Save"
        Me.SaveToolStripMenuItem.Visible = False
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(12, 25)
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(12, 25)
        '
        'FluidSpecificationsDetailsGroup
        '
        Me.FluidSpecificationsDetailsGroup.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.FluidSpecificationsDetailsGroup.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.FluidSpecificationsDetailsGroup.Controls.Add(Me.PartNumberButton)
        Me.FluidSpecificationsDetailsGroup.Controls.Add(Me.VolumeSpecificationButton)
        Me.FluidSpecificationsDetailsGroup.Controls.Add(Me.FluidTypeSpecificationButton)
        Me.FluidSpecificationsDetailsGroup.Controls.Add(Me.SpecifiedPartNumberTextBox)
        Me.FluidSpecificationsDetailsGroup.Controls.Add(Me.SpecifiedQuantityTextBox)
        Me.FluidSpecificationsDetailsGroup.Controls.Add(Me.Label3)
        Me.FluidSpecificationsDetailsGroup.Controls.Add(Me.SpecifiedUnitTextBox)
        Me.FluidSpecificationsDetailsGroup.Controls.Add(Me.Label8)
        Me.FluidSpecificationsDetailsGroup.Controls.Add(Me.ServiceToPerformTextBox)
        Me.FluidSpecificationsDetailsGroup.Controls.Add(Me.Label9)
        Me.FluidSpecificationsDetailsGroup.Controls.Add(Me.FluidSpecificationsTextBox)
        Me.FluidSpecificationsDetailsGroup.Controls.Add(Me.Specification)
        Me.FluidSpecificationsDetailsGroup.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.FluidSpecificationsDetailsGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FluidSpecificationsDetailsGroup.Location = New System.Drawing.Point(606, 50)
        Me.FluidSpecificationsDetailsGroup.Name = "FluidSpecificationsDetailsGroup"
        Me.FluidSpecificationsDetailsGroup.Size = New System.Drawing.Size(554, 435)
        Me.FluidSpecificationsDetailsGroup.TabIndex = 56
        Me.FluidSpecificationsDetailsGroup.TabStop = False
        '
        'PartNumberButton
        '
        Me.PartNumberButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.PartNumberButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PartNumberButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PartNumberButton.Location = New System.Drawing.Point(27, 11)
        Me.PartNumberButton.Name = "PartNumberButton"
        Me.PartNumberButton.Size = New System.Drawing.Size(504, 34)
        Me.PartNumberButton.TabIndex = 61
        Me.PartNumberButton.Text = "PART NUMBER"
        Me.PartNumberButton.UseVisualStyleBackColor = True
        '
        'VolumeSpecificationButton
        '
        Me.VolumeSpecificationButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.VolumeSpecificationButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VolumeSpecificationButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.VolumeSpecificationButton.Location = New System.Drawing.Point(27, 246)
        Me.VolumeSpecificationButton.Name = "VolumeSpecificationButton"
        Me.VolumeSpecificationButton.Size = New System.Drawing.Size(504, 34)
        Me.VolumeSpecificationButton.TabIndex = 60
        Me.VolumeSpecificationButton.Text = "VOLUME SPECIFICATION"
        Me.VolumeSpecificationButton.UseVisualStyleBackColor = True
        '
        'FluidTypeSpecificationButton
        '
        Me.FluidTypeSpecificationButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.FluidTypeSpecificationButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FluidTypeSpecificationButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.FluidTypeSpecificationButton.Location = New System.Drawing.Point(27, 115)
        Me.FluidTypeSpecificationButton.Name = "FluidTypeSpecificationButton"
        Me.FluidTypeSpecificationButton.Size = New System.Drawing.Size(504, 34)
        Me.FluidTypeSpecificationButton.TabIndex = 59
        Me.FluidTypeSpecificationButton.Text = "FLUID TYPE SPECIFICATIONS"
        Me.FluidTypeSpecificationButton.UseVisualStyleBackColor = True
        '
        'SpecifiedPartNumberTextBox
        '
        Me.SpecifiedPartNumberTextBox.Location = New System.Drawing.Point(126, 51)
        Me.SpecifiedPartNumberTextBox.Name = "SpecifiedPartNumberTextBox"
        Me.SpecifiedPartNumberTextBox.Size = New System.Drawing.Size(316, 26)
        Me.SpecifiedPartNumberTextBox.TabIndex = 57
        Me.SpecifiedPartNumberTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.SpecifiedPartNumberTextBox.WordWrap = False
        '
        'SpecifiedQuantityTextBox
        '
        Me.SpecifiedQuantityTextBox.Location = New System.Drawing.Point(126, 365)
        Me.SpecifiedQuantityTextBox.Name = "SpecifiedQuantityTextBox"
        Me.SpecifiedQuantityTextBox.Size = New System.Drawing.Size(79, 26)
        Me.SpecifiedQuantityTextBox.TabIndex = 52
        Me.SpecifiedQuantityTextBox.WordWrap = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 365)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 20)
        Me.Label3.TabIndex = 51
        Me.Label3.Text = "Quantity :"
        '
        'SpecifiedUnitTextBox
        '
        Me.SpecifiedUnitTextBox.Location = New System.Drawing.Point(126, 397)
        Me.SpecifiedUnitTextBox.Name = "SpecifiedUnitTextBox"
        Me.SpecifiedUnitTextBox.Size = New System.Drawing.Size(79, 26)
        Me.SpecifiedUnitTextBox.TabIndex = 50
        Me.SpecifiedUnitTextBox.WordWrap = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(23, 399)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 20)
        Me.Label8.TabIndex = 49
        Me.Label8.Text = "Unit :"
        '
        'ServiceToPerformTextBox
        '
        Me.ServiceToPerformTextBox.Enabled = False
        Me.ServiceToPerformTextBox.Location = New System.Drawing.Point(126, 286)
        Me.ServiceToPerformTextBox.Multiline = True
        Me.ServiceToPerformTextBox.Name = "ServiceToPerformTextBox"
        Me.ServiceToPerformTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ServiceToPerformTextBox.Size = New System.Drawing.Size(405, 73)
        Me.ServiceToPerformTextBox.TabIndex = 48
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(23, 286)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 20)
        Me.Label9.TabIndex = 47
        Me.Label9.Text = "Service Done"
        '
        'FluidSpecificationsTextBox
        '
        Me.FluidSpecificationsTextBox.Location = New System.Drawing.Point(126, 155)
        Me.FluidSpecificationsTextBox.Multiline = True
        Me.FluidSpecificationsTextBox.Name = "FluidSpecificationsTextBox"
        Me.FluidSpecificationsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.FluidSpecificationsTextBox.Size = New System.Drawing.Size(405, 73)
        Me.FluidSpecificationsTextBox.TabIndex = 44
        '
        'Specification
        '
        Me.Specification.AutoSize = True
        Me.Specification.Location = New System.Drawing.Point(23, 158)
        Me.Specification.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Specification.Name = "Specification"
        Me.Specification.Size = New System.Drawing.Size(108, 20)
        Me.Specification.TabIndex = 41
        Me.Specification.Text = "Specification :"
        '
        'WorkOrderPartsDataGridView
        '
        Me.WorkOrderPartsDataGridView.AllowUserToAddRows = False
        Me.WorkOrderPartsDataGridView.AllowUserToDeleteRows = False
        Me.WorkOrderPartsDataGridView.AllowUserToOrderColumns = True
        Me.WorkOrderPartsDataGridView.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WorkOrderPartsDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.WorkOrderPartsDataGridView.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.WorkOrderPartsDataGridView.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
        Me.WorkOrderPartsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.Menu
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.WorkOrderPartsDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.WorkOrderPartsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.WorkOrderPartsDataGridView.DefaultCellStyle = DataGridViewCellStyle6
        Me.WorkOrderPartsDataGridView.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.WorkOrderPartsDataGridView.Location = New System.Drawing.Point(12, 92)
        Me.WorkOrderPartsDataGridView.Name = "WorkOrderPartsDataGridView"
        Me.WorkOrderPartsDataGridView.ReadOnly = True
        Me.WorkOrderPartsDataGridView.RowHeadersVisible = False
        Me.WorkOrderPartsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.WorkOrderPartsDataGridView.Size = New System.Drawing.Size(96, 127)
        Me.WorkOrderPartsDataGridView.TabIndex = 85
        '
        'PartDetailsGroupBox
        '
        Me.PartDetailsGroupBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PartDetailsGroupBox.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.PartDetailsGroupBox.Controls.Add(Me.SpecificationsGroupBox)
        Me.PartDetailsGroupBox.Controls.Add(Me.PartDescriptionTextBox)
        Me.PartDetailsGroupBox.Controls.Add(Me.Label20)
        Me.PartDetailsGroupBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PartDetailsGroupBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PartDetailsGroupBox.Location = New System.Drawing.Point(47, 75)
        Me.PartDetailsGroupBox.Name = "PartDetailsGroupBox"
        Me.PartDetailsGroupBox.Size = New System.Drawing.Size(498, 543)
        Me.PartDetailsGroupBox.TabIndex = 125
        Me.PartDetailsGroupBox.TabStop = False
        Me.PartDetailsGroupBox.Text = "Part Details"
        Me.PartDetailsGroupBox.Visible = False
        '
        'SpecificationsGroupBox
        '
        Me.SpecificationsGroupBox.Controls.Add(Me.SpecificationsDataGridView)
        Me.SpecificationsGroupBox.Controls.Add(Me.Label1)
        Me.SpecificationsGroupBox.Controls.Add(Me.TextBox1)
        Me.SpecificationsGroupBox.Controls.Add(Me.Label16)
        Me.SpecificationsGroupBox.Controls.Add(Me.Label2)
        Me.SpecificationsGroupBox.Controls.Add(Me.TextBox2)
        Me.SpecificationsGroupBox.Enabled = False
        Me.SpecificationsGroupBox.Location = New System.Drawing.Point(18, 66)
        Me.SpecificationsGroupBox.Name = "SpecificationsGroupBox"
        Me.SpecificationsGroupBox.Size = New System.Drawing.Size(724, 181)
        Me.SpecificationsGroupBox.TabIndex = 125
        Me.SpecificationsGroupBox.TabStop = False
        Me.SpecificationsGroupBox.Text = "Specifications"
        '
        'SpecificationsDataGridView
        '
        Me.SpecificationsDataGridView.AllowUserToAddRows = False
        Me.SpecificationsDataGridView.AllowUserToDeleteRows = False
        Me.SpecificationsDataGridView.AllowUserToResizeRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        Me.SpecificationsDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.SpecificationsDataGridView.BackgroundColor = System.Drawing.SystemColors.Control
        Me.SpecificationsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.SpecificationsDataGridView.Location = New System.Drawing.Point(170, 34)
        Me.SpecificationsDataGridView.Margin = New System.Windows.Forms.Padding(7, 8, 7, 8)
        Me.SpecificationsDataGridView.Name = "SpecificationsDataGridView"
        Me.SpecificationsDataGridView.ReadOnly = True
        Me.SpecificationsDataGridView.RowHeadersVisible = False
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        Me.SpecificationsDataGridView.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.SpecificationsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.SpecificationsDataGridView.Size = New System.Drawing.Size(543, 57)
        Me.SpecificationsDataGridView.TabIndex = 125
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 20)
        Me.Label1.TabIndex = 119
        Me.Label1.Text = "Description"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(170, 151)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(53, 26)
        Me.TextBox1.TabIndex = 102
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(27, 127)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(68, 20)
        Me.Label16.TabIndex = 101
        Me.Label16.Text = "Quantity"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 154)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 20)
        Me.Label2.TabIndex = 124
        Me.Label2.Text = "Unit"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(170, 124)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(53, 26)
        Me.TextBox2.TabIndex = 104
        '
        'PartDescriptionTextBox
        '
        Me.PartDescriptionTextBox.Enabled = False
        Me.PartDescriptionTextBox.Location = New System.Drawing.Point(189, 32)
        Me.PartDescriptionTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PartDescriptionTextBox.Name = "PartDescriptionTextBox"
        Me.PartDescriptionTextBox.Size = New System.Drawing.Size(547, 26)
        Me.PartDescriptionTextBox.TabIndex = 107
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(11, 32)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(42, 20)
        Me.Label20.TabIndex = 106
        Me.Label20.Text = "Part "
        '
        'PartsSpecificationsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1284, 574)
        Me.Controls.Add(Me.PartDetailsGroupBox)
        Me.Controls.Add(Me.FluidSpecificationsDetailsGroup)
        Me.Controls.Add(Me.WorkOrderPartsDataGridView)
        Me.Controls.Add(Me.SpecificationsMenuStrip)
        Me.Name = "PartsSpecificationsForm"
        Me.Text = "PartsSpecificationsForm"
        Me.SpecificationsMenuStrip.ResumeLayout(False)
        Me.SpecificationsMenuStrip.PerformLayout()
        Me.FluidSpecificationsDetailsGroup.ResumeLayout(False)
        Me.FluidSpecificationsDetailsGroup.PerformLayout()
        CType(Me.WorkOrderPartsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PartDetailsGroupBox.ResumeLayout(False)
        Me.PartDetailsGroupBox.PerformLayout()
        Me.SpecificationsGroupBox.ResumeLayout(False)
        Me.SpecificationsGroupBox.PerformLayout()
        CType(Me.SpecificationsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SpecificationsMenuStrip As MenuStrip
    Friend WithEvents CancelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SpeceficationsItemToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents FluidSpecificationsDetailsGroup As GroupBox
    Friend WithEvents SpecifiedPartNumberTextBox As TextBox
    Friend WithEvents SpecifiedQuantityTextBox As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents SpecifiedUnitTextBox As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents FluidSpecificationsTextBox As TextBox
    Friend WithEvents Specification As Label
    Friend WithEvents PartNumberButton As Button
    Friend WithEvents VolumeSpecificationButton As Button
    Friend WithEvents FluidTypeSpecificationButton As Button
    Friend WithEvents WorkOrderPartsDataGridView As DataGridView
    Friend WithEvents ServiceToPerformTextBox As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents PartDetailsGroupBox As GroupBox
    Friend WithEvents SpecificationsGroupBox As GroupBox
    Friend WithEvents SpecificationsDataGridView As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents PartDescriptionTextBox As TextBox
    Friend WithEvents Label20 As Label
End Class
