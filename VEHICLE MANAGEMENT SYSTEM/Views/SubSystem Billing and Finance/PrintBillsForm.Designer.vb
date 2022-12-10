<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintBillsForm
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PrintDocument = New System.Drawing.Printing.PrintDocument()
        Me.PrintBillsMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.ReturnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditPriceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WorkOrdersGroupBox = New System.Windows.Forms.GroupBox()
        Me.WorkOrdersDataGridView = New System.Windows.Forms.DataGridView()
        Me.WorkOrderConcernsGroupBox = New System.Windows.Forms.GroupBox()
        Me.WorkOrderConcernsDataGridView = New System.Windows.Forms.DataGridView()
        Me.WorkOrderConcernJobsGroupBox = New System.Windows.Forms.GroupBox()
        Me.WorkOrderConcernJobsDataGridView = New System.Windows.Forms.DataGridView()
        Me.WorkOrderPartsPerJobGroupBox = New System.Windows.Forms.GroupBox()
        Me.WorkOrderPartsPerJobDataGridView = New System.Windows.Forms.DataGridView()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.PriceDetailsGroupBox = New System.Windows.Forms.GroupBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.PrintBillsMenuStrip.SuspendLayout()
        Me.WorkOrdersGroupBox.SuspendLayout()
        CType(Me.WorkOrdersDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.WorkOrderConcernsGroupBox.SuspendLayout()
        CType(Me.WorkOrderConcernsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.WorkOrderConcernJobsGroupBox.SuspendLayout()
        CType(Me.WorkOrderConcernJobsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.WorkOrderPartsPerJobGroupBox.SuspendLayout()
        CType(Me.WorkOrderPartsPerJobDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PriceDetailsGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'PrintBillsMenuStrip
        '
        Me.PrintBillsMenuStrip.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrintBillsMenuStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.PrintBillsMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReturnToolStripMenuItem, Me.EditToolStripMenuItem, Me.SaveToolStripMenuItem, Me.PrintToolStripMenuItem, Me.EditPriceToolStripMenuItem})
        Me.PrintBillsMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.PrintBillsMenuStrip.Name = "PrintBillsMenuStrip"
        Me.PrintBillsMenuStrip.Padding = New System.Windows.Forms.Padding(15, 5, 0, 5)
        Me.PrintBillsMenuStrip.Size = New System.Drawing.Size(1458, 42)
        Me.PrintBillsMenuStrip.TabIndex = 83
        Me.PrintBillsMenuStrip.Text = "MenuStrip1"
        '
        'ReturnToolStripMenuItem
        '
        Me.ReturnToolStripMenuItem.Name = "ReturnToolStripMenuItem"
        Me.ReturnToolStripMenuItem.Size = New System.Drawing.Size(48, 32)
        Me.ReturnToolStripMenuItem.Text = "◄ "
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(60, 32)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(67, 32)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(67, 32)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'EditPriceToolStripMenuItem
        '
        Me.EditPriceToolStripMenuItem.Name = "EditPriceToolStripMenuItem"
        Me.EditPriceToolStripMenuItem.Size = New System.Drawing.Size(107, 32)
        Me.EditPriceToolStripMenuItem.Text = "Edit Price"
        '
        'WorkOrdersGroupBox
        '
        Me.WorkOrdersGroupBox.Controls.Add(Me.WorkOrdersDataGridView)
        Me.WorkOrdersGroupBox.Location = New System.Drawing.Point(37, 88)
        Me.WorkOrdersGroupBox.Name = "WorkOrdersGroupBox"
        Me.WorkOrdersGroupBox.Size = New System.Drawing.Size(373, 61)
        Me.WorkOrdersGroupBox.TabIndex = 85
        Me.WorkOrdersGroupBox.TabStop = False
        Me.WorkOrdersGroupBox.Text = "Work Orders"
        '
        'WorkOrdersDataGridView
        '
        Me.WorkOrdersDataGridView.AllowUserToAddRows = False
        Me.WorkOrdersDataGridView.AllowUserToDeleteRows = False
        Me.WorkOrdersDataGridView.AllowUserToOrderColumns = True
        Me.WorkOrdersDataGridView.AllowUserToResizeRows = False
        Me.WorkOrdersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.WorkOrdersDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WorkOrdersDataGridView.Location = New System.Drawing.Point(3, 26)
        Me.WorkOrdersDataGridView.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.WorkOrdersDataGridView.MultiSelect = False
        Me.WorkOrdersDataGridView.Name = "WorkOrdersDataGridView"
        Me.WorkOrdersDataGridView.ReadOnly = True
        Me.WorkOrdersDataGridView.RowHeadersVisible = False
        Me.WorkOrdersDataGridView.RowHeadersWidth = 51
        Me.WorkOrdersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.WorkOrdersDataGridView.Size = New System.Drawing.Size(367, 32)
        Me.WorkOrdersDataGridView.TabIndex = 52
        '
        'WorkOrderConcernsGroupBox
        '
        Me.WorkOrderConcernsGroupBox.Controls.Add(Me.WorkOrderConcernsDataGridView)
        Me.WorkOrderConcernsGroupBox.Location = New System.Drawing.Point(28, 173)
        Me.WorkOrderConcernsGroupBox.Name = "WorkOrderConcernsGroupBox"
        Me.WorkOrderConcernsGroupBox.Size = New System.Drawing.Size(331, 71)
        Me.WorkOrderConcernsGroupBox.TabIndex = 86
        Me.WorkOrderConcernsGroupBox.TabStop = False
        Me.WorkOrderConcernsGroupBox.Text = "Concerns"
        '
        'WorkOrderConcernsDataGridView
        '
        Me.WorkOrderConcernsDataGridView.AllowUserToAddRows = False
        Me.WorkOrderConcernsDataGridView.AllowUserToDeleteRows = False
        Me.WorkOrderConcernsDataGridView.AllowUserToOrderColumns = True
        Me.WorkOrderConcernsDataGridView.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.WorkOrderConcernsDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.WorkOrderConcernsDataGridView.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
        Me.WorkOrderConcernsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Menu
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.WorkOrderConcernsDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.WorkOrderConcernsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.WorkOrderConcernsDataGridView.DefaultCellStyle = DataGridViewCellStyle3
        Me.WorkOrderConcernsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WorkOrderConcernsDataGridView.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.WorkOrderConcernsDataGridView.Location = New System.Drawing.Point(3, 26)
        Me.WorkOrderConcernsDataGridView.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.WorkOrderConcernsDataGridView.Name = "WorkOrderConcernsDataGridView"
        Me.WorkOrderConcernsDataGridView.ReadOnly = True
        Me.WorkOrderConcernsDataGridView.RowHeadersVisible = False
        Me.WorkOrderConcernsDataGridView.RowHeadersWidth = 51
        Me.WorkOrderConcernsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.WorkOrderConcernsDataGridView.Size = New System.Drawing.Size(325, 42)
        Me.WorkOrderConcernsDataGridView.TabIndex = 54
        '
        'WorkOrderConcernJobsGroupBox
        '
        Me.WorkOrderConcernJobsGroupBox.Controls.Add(Me.WorkOrderConcernJobsDataGridView)
        Me.WorkOrderConcernJobsGroupBox.Location = New System.Drawing.Point(28, 264)
        Me.WorkOrderConcernJobsGroupBox.Name = "WorkOrderConcernJobsGroupBox"
        Me.WorkOrderConcernJobsGroupBox.Size = New System.Drawing.Size(337, 60)
        Me.WorkOrderConcernJobsGroupBox.TabIndex = 87
        Me.WorkOrderConcernJobsGroupBox.TabStop = False
        Me.WorkOrderConcernJobsGroupBox.Text = "Jobs"
        '
        'WorkOrderConcernJobsDataGridView
        '
        Me.WorkOrderConcernJobsDataGridView.AllowUserToAddRows = False
        Me.WorkOrderConcernJobsDataGridView.AllowUserToDeleteRows = False
        Me.WorkOrderConcernJobsDataGridView.AllowUserToOrderColumns = True
        Me.WorkOrderConcernJobsDataGridView.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.WorkOrderConcernJobsDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.WorkOrderConcernJobsDataGridView.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
        Me.WorkOrderConcernJobsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.Menu
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.WorkOrderConcernJobsDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.WorkOrderConcernJobsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.WorkOrderConcernJobsDataGridView.DefaultCellStyle = DataGridViewCellStyle6
        Me.WorkOrderConcernJobsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WorkOrderConcernJobsDataGridView.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.WorkOrderConcernJobsDataGridView.Location = New System.Drawing.Point(3, 26)
        Me.WorkOrderConcernJobsDataGridView.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.WorkOrderConcernJobsDataGridView.Name = "WorkOrderConcernJobsDataGridView"
        Me.WorkOrderConcernJobsDataGridView.ReadOnly = True
        Me.WorkOrderConcernJobsDataGridView.RowHeadersVisible = False
        Me.WorkOrderConcernJobsDataGridView.RowHeadersWidth = 51
        Me.WorkOrderConcernJobsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.WorkOrderConcernJobsDataGridView.Size = New System.Drawing.Size(331, 31)
        Me.WorkOrderConcernJobsDataGridView.TabIndex = 57
        '
        'WorkOrderPartsPerJobGroupBox
        '
        Me.WorkOrderPartsPerJobGroupBox.Controls.Add(Me.WorkOrderPartsPerJobDataGridView)
        Me.WorkOrderPartsPerJobGroupBox.Location = New System.Drawing.Point(31, 354)
        Me.WorkOrderPartsPerJobGroupBox.Name = "WorkOrderPartsPerJobGroupBox"
        Me.WorkOrderPartsPerJobGroupBox.Size = New System.Drawing.Size(458, 51)
        Me.WorkOrderPartsPerJobGroupBox.TabIndex = 88
        Me.WorkOrderPartsPerJobGroupBox.TabStop = False
        Me.WorkOrderPartsPerJobGroupBox.Text = "Job Parts"
        '
        'WorkOrderPartsPerJobDataGridView
        '
        Me.WorkOrderPartsPerJobDataGridView.AllowUserToAddRows = False
        Me.WorkOrderPartsPerJobDataGridView.AllowUserToDeleteRows = False
        Me.WorkOrderPartsPerJobDataGridView.AllowUserToOrderColumns = True
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WorkOrderPartsPerJobDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.WorkOrderPartsPerJobDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.WorkOrderPartsPerJobDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WorkOrderPartsPerJobDataGridView.Location = New System.Drawing.Point(3, 26)
        Me.WorkOrderPartsPerJobDataGridView.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.WorkOrderPartsPerJobDataGridView.MultiSelect = False
        Me.WorkOrderPartsPerJobDataGridView.Name = "WorkOrderPartsPerJobDataGridView"
        Me.WorkOrderPartsPerJobDataGridView.ReadOnly = True
        Me.WorkOrderPartsPerJobDataGridView.RowHeadersWidth = 51
        Me.WorkOrderPartsPerJobDataGridView.Size = New System.Drawing.Size(452, 22)
        Me.WorkOrderPartsPerJobDataGridView.TabIndex = 59
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(233, 538)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(108, 25)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "discount %"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Job :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(31, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 25)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Vehicle :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(69, 174)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 25)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "General :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(69, 209)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 25)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Minimum ::"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(69, 246)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 25)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Maximum :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(31, 123)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 25)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Price :"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(150, 43)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 30)
        Me.TextBox1.TabIndex = 6
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(150, 79)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 30)
        Me.TextBox2.TabIndex = 7
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(201, 171)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(100, 30)
        Me.TextBox3.TabIndex = 8
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(201, 211)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(100, 30)
        Me.TextBox4.TabIndex = 9
        '
        'PriceDetailsGroupBox
        '
        Me.PriceDetailsGroupBox.Controls.Add(Me.TextBox5)
        Me.PriceDetailsGroupBox.Controls.Add(Me.TextBox4)
        Me.PriceDetailsGroupBox.Controls.Add(Me.TextBox3)
        Me.PriceDetailsGroupBox.Controls.Add(Me.TextBox2)
        Me.PriceDetailsGroupBox.Controls.Add(Me.TextBox1)
        Me.PriceDetailsGroupBox.Controls.Add(Me.Label7)
        Me.PriceDetailsGroupBox.Controls.Add(Me.Label5)
        Me.PriceDetailsGroupBox.Controls.Add(Me.Label4)
        Me.PriceDetailsGroupBox.Controls.Add(Me.Label3)
        Me.PriceDetailsGroupBox.Controls.Add(Me.Label2)
        Me.PriceDetailsGroupBox.Controls.Add(Me.Label1)
        Me.PriceDetailsGroupBox.Location = New System.Drawing.Point(524, 93)
        Me.PriceDetailsGroupBox.Name = "PriceDetailsGroupBox"
        Me.PriceDetailsGroupBox.Size = New System.Drawing.Size(703, 309)
        Me.PriceDetailsGroupBox.TabIndex = 89
        Me.PriceDetailsGroupBox.TabStop = False
        Me.PriceDetailsGroupBox.Text = "Price Details"
        Me.PriceDetailsGroupBox.Visible = False
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(201, 248)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(100, 30)
        Me.TextBox5.TabIndex = 90
        '
        'PrintBillsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1458, 692)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.PriceDetailsGroupBox)
        Me.Controls.Add(Me.WorkOrderPartsPerJobGroupBox)
        Me.Controls.Add(Me.WorkOrderConcernJobsGroupBox)
        Me.Controls.Add(Me.WorkOrderConcernsGroupBox)
        Me.Controls.Add(Me.WorkOrdersGroupBox)
        Me.Controls.Add(Me.PrintBillsMenuStrip)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainMenuStrip = Me.PrintBillsMenuStrip
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PrintBillsForm"
        Me.Text = "Print Bills"
        Me.PrintBillsMenuStrip.ResumeLayout(False)
        Me.PrintBillsMenuStrip.PerformLayout()
        Me.WorkOrdersGroupBox.ResumeLayout(False)
        CType(Me.WorkOrdersDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.WorkOrderConcernsGroupBox.ResumeLayout(False)
        CType(Me.WorkOrderConcernsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.WorkOrderConcernJobsGroupBox.ResumeLayout(False)
        CType(Me.WorkOrderConcernJobsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.WorkOrderPartsPerJobGroupBox.ResumeLayout(False)
        CType(Me.WorkOrderPartsPerJobDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PriceDetailsGroupBox.ResumeLayout(False)
        Me.PriceDetailsGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PrintDocument As Printing.PrintDocument
    Friend WithEvents PrintBillsMenuStrip As MenuStrip
    Friend WithEvents ReturnToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WorkOrdersGroupBox As GroupBox
    Friend WithEvents WorkOrdersDataGridView As DataGridView
    Friend WithEvents WorkOrderConcernsGroupBox As GroupBox
    Friend WithEvents WorkOrderConcernsDataGridView As DataGridView
    Friend WithEvents WorkOrderConcernJobsGroupBox As GroupBox
    Friend WithEvents WorkOrderConcernJobsDataGridView As DataGridView
    Protected WithEvents WorkOrderPartsPerJobGroupBox As GroupBox
    Friend WithEvents WorkOrderPartsPerJobDataGridView As DataGridView
    Friend WithEvents UpdateGroupBox As GroupBox
    Friend WithEvents UpdateVehicleInformationsTablDataGridView As DataGridView
    Friend WithEvents EditPriceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label6 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents PriceDetailsGroupBox As GroupBox
    Friend WithEvents TextBox5 As TextBox
End Class
