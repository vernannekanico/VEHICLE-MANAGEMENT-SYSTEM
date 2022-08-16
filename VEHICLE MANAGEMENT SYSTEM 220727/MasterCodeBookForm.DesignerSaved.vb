<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MasterCodeBookForm
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.MainSystemCodeDataGridView = New System.Windows.Forms.DataGridView()
        Me.SubSystemCodeDataGridView = New System.Windows.Forms.DataGridView()
        Me.ProductsDataGridView = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RenumberGroupBox = New System.Windows.Forms.GroupBox()
        Me.GoRenumberButton = New System.Windows.Forms.Button()
        Me.NewNumberTextBox = New System.Windows.Forms.TextBox()
        Me.OldNumberTextBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ServicedVehicleGroupBox = New System.Windows.Forms.GroupBox()
        Me.ContinueButton = New System.Windows.Forms.Button()
        Me.ChangeVehicleDefaults = New System.Windows.Forms.Button()
        Me.ChildrenButton = New System.Windows.Forms.Button()
        Me.UpButton = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ReturnButton = New System.Windows.Forms.Button()
        Me.MasterCodeBookDetailsGroup = New System.Windows.Forms.GroupBox()
        Me.ChildSystemNameLabel = New System.Windows.Forms.Label()
        Me.SubSystemLabel = New System.Windows.Forms.Label()
        Me.SubSystemPrefixLabel = New System.Windows.Forms.Label()
        Me.ChildSystemCodeTextBox = New System.Windows.Forms.TextBox()
        Me.ParentSystemNameLabel = New System.Windows.Forms.Label()
        Me.MainSystemLabel = New System.Windows.Forms.Label()
        Me.MainSystemPrefixLabel = New System.Windows.Forms.Label()
        Me.SystemNameTextBox = New System.Windows.Forms.TextBox()
        Me.ParentSystemCodeTextBox = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ProductDetailsGroup = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.ActivatedBy = New System.Windows.Forms.TextBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.CancelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.SelectMasterCodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddMasterCodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditTMasterCodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteMasterCodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RenumberToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateProcedureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveMasterCodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchMasterCodeBookTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.ProductCodeBookToolStripLabel = New System.Windows.Forms.ToolStripLabel()
        Me.SelectProductToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddProductToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditProductToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteProductToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchProductToolStripTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.DefaultVehicleModelTextBox = New System.Windows.Forms.TextBox()
        Me.DefaultVehicleModelRepairRangeTextBox = New System.Windows.Forms.TextBox()
        Me.IncludeGrandChildrenButton = New System.Windows.Forms.Button()
        CType(Me.MainSystemCodeDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SubSystemCodeDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProductsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.RenumberGroupBox.SuspendLayout()
        Me.ServicedVehicleGroupBox.SuspendLayout()
        Me.MasterCodeBookDetailsGroup.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.ProductDetailsGroup.SuspendLayout()
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainSystemCodeDataGridView
        '
        Me.MainSystemCodeDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MainSystemCodeDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.MainSystemCodeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.MainSystemCodeDataGridView.Location = New System.Drawing.Point(-1, 9)
        Me.MainSystemCodeDataGridView.Name = "MainSystemCodeDataGridView"
        Me.MainSystemCodeDataGridView.ReadOnly = True
        Me.MainSystemCodeDataGridView.Size = New System.Drawing.Size(575, 307)
        Me.MainSystemCodeDataGridView.TabIndex = 0
        '
        'SubSystemCodeDataGridView
        '
        Me.SubSystemCodeDataGridView.AllowUserToAddRows = False
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SubSystemCodeDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.SubSystemCodeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.SubSystemCodeDataGridView.Location = New System.Drawing.Point(0, 339)
        Me.SubSystemCodeDataGridView.Name = "SubSystemCodeDataGridView"
        Me.SubSystemCodeDataGridView.ReadOnly = True
        Me.SubSystemCodeDataGridView.Size = New System.Drawing.Size(575, 353)
        Me.SubSystemCodeDataGridView.TabIndex = 1
        '
        'ProductsDataGridView
        '
        Me.ProductsDataGridView.AllowUserToResizeColumns = False
        Me.ProductsDataGridView.AllowUserToResizeRows = False
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ProductsDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.ProductsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ProductsDataGridView.Location = New System.Drawing.Point(22, 19)
        Me.ProductsDataGridView.MultiSelect = False
        Me.ProductsDataGridView.Name = "ProductsDataGridView"
        Me.ProductsDataGridView.ReadOnly = True
        Me.ProductsDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.ProductsDataGridView.Size = New System.Drawing.Size(751, 664)
        Me.ProductsDataGridView.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.IncludeGrandChildrenButton)
        Me.GroupBox1.Controls.Add(Me.RenumberGroupBox)
        Me.GroupBox1.Controls.Add(Me.ServicedVehicleGroupBox)
        Me.GroupBox1.Controls.Add(Me.ChildrenButton)
        Me.GroupBox1.Controls.Add(Me.UpButton)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.ReturnButton)
        Me.GroupBox1.Controls.Add(Me.MainSystemCodeDataGridView)
        Me.GroupBox1.Controls.Add(Me.SubSystemCodeDataGridView)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 75)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(627, 736)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'RenumberGroupBox
        '
        Me.RenumberGroupBox.Controls.Add(Me.GoRenumberButton)
        Me.RenumberGroupBox.Controls.Add(Me.NewNumberTextBox)
        Me.RenumberGroupBox.Controls.Add(Me.OldNumberTextBox)
        Me.RenumberGroupBox.Controls.Add(Me.Label4)
        Me.RenumberGroupBox.Controls.Add(Me.Label3)
        Me.RenumberGroupBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RenumberGroupBox.Location = New System.Drawing.Point(82, 188)
        Me.RenumberGroupBox.Name = "RenumberGroupBox"
        Me.RenumberGroupBox.Size = New System.Drawing.Size(395, 116)
        Me.RenumberGroupBox.TabIndex = 85
        Me.RenumberGroupBox.TabStop = False
        Me.RenumberGroupBox.Visible = False
        '
        'GoRenumberButton
        '
        Me.GoRenumberButton.Location = New System.Drawing.Point(334, 10)
        Me.GoRenumberButton.Name = "GoRenumberButton"
        Me.GoRenumberButton.Size = New System.Drawing.Size(37, 95)
        Me.GoRenumberButton.TabIndex = 4
        Me.GoRenumberButton.Text = "GO"
        Me.GoRenumberButton.UseVisualStyleBackColor = True
        '
        'NewNumberTextBox
        '
        Me.NewNumberTextBox.Location = New System.Drawing.Point(130, 59)
        Me.NewNumberTextBox.Name = "NewNumberTextBox"
        Me.NewNumberTextBox.Size = New System.Drawing.Size(181, 29)
        Me.NewNumberTextBox.TabIndex = 3
        '
        'OldNumberTextBox
        '
        Me.OldNumberTextBox.Location = New System.Drawing.Point(130, 22)
        Me.OldNumberTextBox.Name = "OldNumberTextBox"
        Me.OldNumberTextBox.ReadOnly = True
        Me.OldNumberTextBox.Size = New System.Drawing.Size(181, 29)
        Me.OldNumberTextBox.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(114, 24)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Renumber "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(80, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 24)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "To"
        '
        'ServicedVehicleGroupBox
        '
        Me.ServicedVehicleGroupBox.Controls.Add(Me.ContinueButton)
        Me.ServicedVehicleGroupBox.Controls.Add(Me.ChangeVehicleDefaults)
        Me.ServicedVehicleGroupBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ServicedVehicleGroupBox.Location = New System.Drawing.Point(40, 19)
        Me.ServicedVehicleGroupBox.Name = "ServicedVehicleGroupBox"
        Me.ServicedVehicleGroupBox.Size = New System.Drawing.Size(457, 86)
        Me.ServicedVehicleGroupBox.TabIndex = 84
        Me.ServicedVehicleGroupBox.TabStop = False
        Me.ServicedVehicleGroupBox.Text = "Serviced Vehicle"
        Me.ServicedVehicleGroupBox.Visible = False
        '
        'ContinueButton
        '
        Me.ContinueButton.Location = New System.Drawing.Point(230, 26)
        Me.ContinueButton.Name = "ContinueButton"
        Me.ContinueButton.Size = New System.Drawing.Size(207, 39)
        Me.ContinueButton.TabIndex = 21
        Me.ContinueButton.Text = "Continue"
        Me.ContinueButton.UseVisualStyleBackColor = True
        '
        'ChangeVehicleDefaults
        '
        Me.ChangeVehicleDefaults.Location = New System.Drawing.Point(6, 27)
        Me.ChangeVehicleDefaults.Name = "ChangeVehicleDefaults"
        Me.ChangeVehicleDefaults.Size = New System.Drawing.Size(207, 39)
        Me.ChangeVehicleDefaults.TabIndex = 20
        Me.ChangeVehicleDefaults.Text = "Change"
        Me.ChangeVehicleDefaults.UseVisualStyleBackColor = True
        '
        'ChildrenButton
        '
        Me.ChildrenButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChildrenButton.Location = New System.Drawing.Point(572, 518)
        Me.ChildrenButton.Name = "ChildrenButton"
        Me.ChildrenButton.Size = New System.Drawing.Size(49, 174)
        Me.ChildrenButton.TabIndex = 11
        Me.ChildrenButton.Text = "↓"
        Me.ChildrenButton.UseVisualStyleBackColor = True
        '
        'UpButton
        '
        Me.UpButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UpButton.Location = New System.Drawing.Point(572, 339)
        Me.UpButton.Name = "UpButton"
        Me.UpButton.Size = New System.Drawing.Size(49, 178)
        Me.UpButton.TabIndex = 10
        Me.UpButton.Text = "↑"
        Me.UpButton.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(-255, 455)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(132, 23)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "<--"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ReturnButton
        '
        Me.ReturnButton.Location = New System.Drawing.Point(-403, 455)
        Me.ReturnButton.Name = "ReturnButton"
        Me.ReturnButton.Size = New System.Drawing.Size(132, 23)
        Me.ReturnButton.TabIndex = 2
        Me.ReturnButton.Text = "<--"
        Me.ReturnButton.UseVisualStyleBackColor = True
        '
        'MasterCodeBookDetailsGroup
        '
        Me.MasterCodeBookDetailsGroup.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.MasterCodeBookDetailsGroup.Controls.Add(Me.ChildSystemNameLabel)
        Me.MasterCodeBookDetailsGroup.Controls.Add(Me.SubSystemLabel)
        Me.MasterCodeBookDetailsGroup.Controls.Add(Me.SubSystemPrefixLabel)
        Me.MasterCodeBookDetailsGroup.Controls.Add(Me.ChildSystemCodeTextBox)
        Me.MasterCodeBookDetailsGroup.Controls.Add(Me.ParentSystemNameLabel)
        Me.MasterCodeBookDetailsGroup.Controls.Add(Me.MainSystemLabel)
        Me.MasterCodeBookDetailsGroup.Controls.Add(Me.MainSystemPrefixLabel)
        Me.MasterCodeBookDetailsGroup.Controls.Add(Me.SystemNameTextBox)
        Me.MasterCodeBookDetailsGroup.Controls.Add(Me.ParentSystemCodeTextBox)
        Me.MasterCodeBookDetailsGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MasterCodeBookDetailsGroup.Location = New System.Drawing.Point(679, 110)
        Me.MasterCodeBookDetailsGroup.Name = "MasterCodeBookDetailsGroup"
        Me.MasterCodeBookDetailsGroup.Size = New System.Drawing.Size(726, 250)
        Me.MasterCodeBookDetailsGroup.TabIndex = 80
        Me.MasterCodeBookDetailsGroup.TabStop = False
        Me.MasterCodeBookDetailsGroup.Visible = False
        '
        'ChildSystemNameLabel
        '
        Me.ChildSystemNameLabel.AutoSize = True
        Me.ChildSystemNameLabel.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.ChildSystemNameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChildSystemNameLabel.Location = New System.Drawing.Point(258, 108)
        Me.ChildSystemNameLabel.Name = "ChildSystemNameLabel"
        Me.ChildSystemNameLabel.Size = New System.Drawing.Size(200, 25)
        Me.ChildSystemNameLabel.TabIndex = 18
        Me.ChildSystemNameLabel.Text = "Child System Name"
        '
        'SubSystemLabel
        '
        Me.SubSystemLabel.AutoSize = True
        Me.SubSystemLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SubSystemLabel.Location = New System.Drawing.Point(9, 108)
        Me.SubSystemLabel.Name = "SubSystemLabel"
        Me.SubSystemLabel.Size = New System.Drawing.Size(139, 25)
        Me.SubSystemLabel.TabIndex = 17
        Me.SubSystemLabel.Text = "Sub System :"
        '
        'SubSystemPrefixLabel
        '
        Me.SubSystemPrefixLabel.AutoSize = True
        Me.SubSystemPrefixLabel.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.SubSystemPrefixLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SubSystemPrefixLabel.Location = New System.Drawing.Point(13, 153)
        Me.SubSystemPrefixLabel.Name = "SubSystemPrefixLabel"
        Me.SubSystemPrefixLabel.Size = New System.Drawing.Size(43, 25)
        Me.SubSystemPrefixLabel.TabIndex = 16
        Me.SubSystemPrefixLabel.Text = "00-"
        '
        'ChildSystemCodeTextBox
        '
        Me.ChildSystemCodeTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChildSystemCodeTextBox.Location = New System.Drawing.Point(263, 144)
        Me.ChildSystemCodeTextBox.Name = "ChildSystemCodeTextBox"
        Me.ChildSystemCodeTextBox.Size = New System.Drawing.Size(146, 31)
        Me.ChildSystemCodeTextBox.TabIndex = 15
        Me.ChildSystemCodeTextBox.Text = "Next SubCode"
        '
        'ParentSystemNameLabel
        '
        Me.ParentSystemNameLabel.AutoSize = True
        Me.ParentSystemNameLabel.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.ParentSystemNameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ParentSystemNameLabel.Location = New System.Drawing.Point(258, 16)
        Me.ParentSystemNameLabel.Name = "ParentSystemNameLabel"
        Me.ParentSystemNameLabel.Size = New System.Drawing.Size(214, 25)
        Me.ParentSystemNameLabel.TabIndex = 14
        Me.ParentSystemNameLabel.Text = "Parent System Name"
        '
        'MainSystemLabel
        '
        Me.MainSystemLabel.AutoSize = True
        Me.MainSystemLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainSystemLabel.Location = New System.Drawing.Point(9, 16)
        Me.MainSystemLabel.Name = "MainSystemLabel"
        Me.MainSystemLabel.Size = New System.Drawing.Size(148, 25)
        Me.MainSystemLabel.TabIndex = 13
        Me.MainSystemLabel.Text = "Main System :"
        '
        'MainSystemPrefixLabel
        '
        Me.MainSystemPrefixLabel.AutoSize = True
        Me.MainSystemPrefixLabel.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.MainSystemPrefixLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainSystemPrefixLabel.Location = New System.Drawing.Point(13, 61)
        Me.MainSystemPrefixLabel.Name = "MainSystemPrefixLabel"
        Me.MainSystemPrefixLabel.Size = New System.Drawing.Size(43, 25)
        Me.MainSystemPrefixLabel.TabIndex = 11
        Me.MainSystemPrefixLabel.Text = "00-"
        '
        'SystemNameTextBox
        '
        Me.SystemNameTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SystemNameTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SystemNameTextBox.Location = New System.Drawing.Point(18, 204)
        Me.SystemNameTextBox.Name = "SystemNameTextBox"
        Me.SystemNameTextBox.Size = New System.Drawing.Size(594, 31)
        Me.SystemNameTextBox.TabIndex = 9
        Me.SystemNameTextBox.Text = "new sub system name"
        '
        'ParentSystemCodeTextBox
        '
        Me.ParentSystemCodeTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ParentSystemCodeTextBox.Location = New System.Drawing.Point(263, 55)
        Me.ParentSystemCodeTextBox.Name = "ParentSystemCodeTextBox"
        Me.ParentSystemCodeTextBox.Size = New System.Drawing.Size(146, 31)
        Me.ParentSystemCodeTextBox.TabIndex = 8
        Me.ParentSystemCodeTextBox.Text = "Next SubCode"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ProductDetailsGroup)
        Me.GroupBox2.Controls.Add(Me.ActivatedBy)
        Me.GroupBox2.Controls.Add(Me.ProductsDataGridView)
        Me.GroupBox2.Location = New System.Drawing.Point(679, 75)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(798, 703)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        '
        'ProductDetailsGroup
        '
        Me.ProductDetailsGroup.Controls.Add(Me.Label1)
        Me.ProductDetailsGroup.Controls.Add(Me.Label2)
        Me.ProductDetailsGroup.Controls.Add(Me.TextBox1)
        Me.ProductDetailsGroup.Controls.Add(Me.TextBox2)
        Me.ProductDetailsGroup.Location = New System.Drawing.Point(34, 299)
        Me.ProductDetailsGroup.Name = "ProductDetailsGroup"
        Me.ProductDetailsGroup.Size = New System.Drawing.Size(726, 126)
        Me.ProductDetailsGroup.TabIndex = 81
        Me.ProductDetailsGroup.TabStop = False
        Me.ProductDetailsGroup.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 25)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "SYSTEM"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 25)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Code"
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(129, 67)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(549, 31)
        Me.TextBox1.TabIndex = 9
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(129, 19)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 31)
        Me.TextBox2.TabIndex = 8
        '
        'ActivatedBy
        '
        Me.ActivatedBy.Location = New System.Drawing.Point(692, 209)
        Me.ActivatedBy.Name = "ActivatedBy"
        Me.ActivatedBy.Size = New System.Drawing.Size(100, 20)
        Me.ActivatedBy.TabIndex = 43
        Me.ActivatedBy.Text = "ActivatedBy"
        Me.ActivatedBy.Visible = False
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(0, -4)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(30, 33)
        Me.Button5.TabIndex = 9
        Me.Button5.Text = "<--"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'MenuStrip
        '
        Me.MenuStrip.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CancelToolStripMenuItem, Me.ToolStripLabel1, Me.SelectMasterCodeToolStripMenuItem, Me.AddMasterCodeToolStripMenuItem, Me.EditTMasterCodeToolStripMenuItem, Me.DeleteMasterCodeToolStripMenuItem, Me.RenumberToolStripMenuItem, Me.ToolStripMenuItem1, Me.CreateProcedureToolStripMenuItem, Me.SaveMasterCodeToolStripMenuItem, Me.SearchMasterCodeBookTextBox, Me.ProductCodeBookToolStripLabel, Me.SelectProductToolStripMenuItem, Me.AddProductToolStripMenuItem, Me.EditProductToolStripMenuItem, Me.DeleteProductToolStripMenuItem, Me.SearchProductToolStripTextBox})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Padding = New System.Windows.Forms.Padding(10, 3, 0, 3)
        Me.MenuStrip.Size = New System.Drawing.Size(1489, 35)
        Me.MenuStrip.TabIndex = 79
        Me.MenuStrip.Text = "MenuStrip"
        '
        'CancelToolStripMenuItem
        '
        Me.CancelToolStripMenuItem.Name = "CancelToolStripMenuItem"
        Me.CancelToolStripMenuItem.Size = New System.Drawing.Size(40, 29)
        Me.CancelToolStripMenuItem.Text = "◄ "
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(129, 26)
        Me.ToolStripLabel1.Text = "MasterCodeBook"
        '
        'SelectMasterCodeToolStripMenuItem
        '
        Me.SelectMasterCodeToolStripMenuItem.Name = "SelectMasterCodeToolStripMenuItem"
        Me.SelectMasterCodeToolStripMenuItem.Size = New System.Drawing.Size(63, 29)
        Me.SelectMasterCodeToolStripMenuItem.Text = "Select"
        '
        'AddMasterCodeToolStripMenuItem
        '
        Me.AddMasterCodeToolStripMenuItem.Name = "AddMasterCodeToolStripMenuItem"
        Me.AddMasterCodeToolStripMenuItem.Size = New System.Drawing.Size(50, 29)
        Me.AddMasterCodeToolStripMenuItem.Text = "Add"
        '
        'EditTMasterCodeToolStripMenuItem
        '
        Me.EditTMasterCodeToolStripMenuItem.Name = "EditTMasterCodeToolStripMenuItem"
        Me.EditTMasterCodeToolStripMenuItem.Size = New System.Drawing.Size(48, 29)
        Me.EditTMasterCodeToolStripMenuItem.Text = "Edit"
        '
        'DeleteMasterCodeToolStripMenuItem
        '
        Me.DeleteMasterCodeToolStripMenuItem.Name = "DeleteMasterCodeToolStripMenuItem"
        Me.DeleteMasterCodeToolStripMenuItem.Size = New System.Drawing.Size(66, 29)
        Me.DeleteMasterCodeToolStripMenuItem.Text = "Delete"
        '
        'RenumberToolStripMenuItem
        '
        Me.RenumberToolStripMenuItem.Name = "RenumberToolStripMenuItem"
        Me.RenumberToolStripMenuItem.Size = New System.Drawing.Size(29, 29)
        Me.RenumberToolStripMenuItem.Text = "*"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(12, 29)
        '
        'CreateProcedureToolStripMenuItem
        '
        Me.CreateProcedureToolStripMenuItem.Name = "CreateProcedureToolStripMenuItem"
        Me.CreateProcedureToolStripMenuItem.Size = New System.Drawing.Size(142, 29)
        Me.CreateProcedureToolStripMenuItem.Text = "Create Procedure"
        '
        'SaveMasterCodeToolStripMenuItem
        '
        Me.SaveMasterCodeToolStripMenuItem.Name = "SaveMasterCodeToolStripMenuItem"
        Me.SaveMasterCodeToolStripMenuItem.Size = New System.Drawing.Size(55, 29)
        Me.SaveMasterCodeToolStripMenuItem.Text = "Save"
        '
        'SearchMasterCodeBookTextBox
        '
        Me.SearchMasterCodeBookTextBox.Font = New System.Drawing.Font("Segoe UI", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchMasterCodeBookTextBox.Name = "SearchMasterCodeBookTextBox"
        Me.SearchMasterCodeBookTextBox.Size = New System.Drawing.Size(150, 29)
        Me.SearchMasterCodeBookTextBox.Text = "Search"
        '
        'ProductCodeBookToolStripLabel
        '
        Me.ProductCodeBookToolStripLabel.Name = "ProductCodeBookToolStripLabel"
        Me.ProductCodeBookToolStripLabel.Size = New System.Drawing.Size(135, 26)
        Me.ProductCodeBookToolStripLabel.Text = "ProductCodeBook"
        '
        'SelectProductToolStripMenuItem
        '
        Me.SelectProductToolStripMenuItem.Name = "SelectProductToolStripMenuItem"
        Me.SelectProductToolStripMenuItem.Size = New System.Drawing.Size(63, 29)
        Me.SelectProductToolStripMenuItem.Text = "Select"
        '
        'AddProductToolStripMenuItem
        '
        Me.AddProductToolStripMenuItem.Name = "AddProductToolStripMenuItem"
        Me.AddProductToolStripMenuItem.Size = New System.Drawing.Size(50, 29)
        Me.AddProductToolStripMenuItem.Text = "Add"
        '
        'EditProductToolStripMenuItem
        '
        Me.EditProductToolStripMenuItem.Name = "EditProductToolStripMenuItem"
        Me.EditProductToolStripMenuItem.Size = New System.Drawing.Size(48, 29)
        Me.EditProductToolStripMenuItem.Text = "Edit"
        '
        'DeleteProductToolStripMenuItem
        '
        Me.DeleteProductToolStripMenuItem.Name = "DeleteProductToolStripMenuItem"
        Me.DeleteProductToolStripMenuItem.Size = New System.Drawing.Size(66, 29)
        Me.DeleteProductToolStripMenuItem.Text = "Delete"
        '
        'SearchProductToolStripTextBox
        '
        Me.SearchProductToolStripTextBox.Font = New System.Drawing.Font("Segoe UI", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchProductToolStripTextBox.Name = "SearchProductToolStripTextBox"
        Me.SearchProductToolStripTextBox.Size = New System.Drawing.Size(150, 29)
        Me.SearchProductToolStripTextBox.Text = "Search"
        '
        'DefaultVehicleModelTextBox
        '
        Me.DefaultVehicleModelTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DefaultVehicleModelTextBox.Location = New System.Drawing.Point(52, 38)
        Me.DefaultVehicleModelTextBox.Name = "DefaultVehicleModelTextBox"
        Me.DefaultVehicleModelTextBox.Size = New System.Drawing.Size(689, 31)
        Me.DefaultVehicleModelTextBox.TabIndex = 80
        Me.DefaultVehicleModelTextBox.Text = "Set Default Vehicle"
        '
        'DefaultVehicleModelRepairRangeTextBox
        '
        Me.DefaultVehicleModelRepairRangeTextBox.Enabled = False
        Me.DefaultVehicleModelRepairRangeTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DefaultVehicleModelRepairRangeTextBox.Location = New System.Drawing.Point(756, 38)
        Me.DefaultVehicleModelRepairRangeTextBox.Name = "DefaultVehicleModelRepairRangeTextBox"
        Me.DefaultVehicleModelRepairRangeTextBox.Size = New System.Drawing.Size(320, 31)
        Me.DefaultVehicleModelRepairRangeTextBox.TabIndex = 81
        '
        'IncludeGrandChildrenButton
        '
        Me.IncludeGrandChildrenButton.Location = New System.Drawing.Point(166, 318)
        Me.IncludeGrandChildrenButton.Name = "IncludeGrandChildrenButton"
        Me.IncludeGrandChildrenButton.Size = New System.Drawing.Size(259, 23)
        Me.IncludeGrandChildrenButton.TabIndex = 86
        Me.IncludeGrandChildrenButton.Text = "INCLUDE GRANDCHILDREN"
        Me.IncludeGrandChildrenButton.UseVisualStyleBackColor = True
        '
        'MasterCodeBookForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1489, 792)
        Me.ControlBox = False
        Me.Controls.Add(Me.MasterCodeBookDetailsGroup)
        Me.Controls.Add(Me.DefaultVehicleModelRepairRangeTextBox)
        Me.Controls.Add(Me.DefaultVehicleModelTextBox)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "MasterCodeBookForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MasterCodeBookForm"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.MainSystemCodeDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SubSystemCodeDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProductsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.RenumberGroupBox.ResumeLayout(False)
        Me.RenumberGroupBox.PerformLayout()
        Me.ServicedVehicleGroupBox.ResumeLayout(False)
        Me.MasterCodeBookDetailsGroup.ResumeLayout(False)
        Me.MasterCodeBookDetailsGroup.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ProductDetailsGroup.ResumeLayout(False)
        Me.ProductDetailsGroup.PerformLayout()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MainSystemCodeDataGridView As DataGridView
    Friend WithEvents SubSystemCodeDataGridView As DataGridView
    Friend WithEvents ProductsDataGridView As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents ReturnButton As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents ChildrenButton As Button
    Friend WithEvents UpButton As Button
    Friend WithEvents ActivatedBy As TextBox
    Friend WithEvents MenuStrip As MenuStrip
    Friend WithEvents CancelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelectMasterCodeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddMasterCodeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditTMasterCodeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteMasterCodeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents CreateProcedureToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveMasterCodeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents SearchMasterCodeBookTextBox As ToolStripTextBox
    Friend WithEvents ProductCodeBookToolStripLabel As ToolStripLabel
    Friend WithEvents AddProductToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditProductToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteProductToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SearchProductToolStripTextBox As ToolStripTextBox
    Friend WithEvents MasterCodeBookDetailsGroup As GroupBox
    Friend WithEvents MainSystemPrefixLabel As Label
    Friend WithEvents ParentSystemCodeTextBox As TextBox
    Friend WithEvents ProductDetailsGroup As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents SelectProductToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ParentSystemNameLabel As Label
    Friend WithEvents MainSystemLabel As Label
    Friend WithEvents ChildSystemNameLabel As Label
    Friend WithEvents SubSystemLabel As Label
    Friend WithEvents SubSystemPrefixLabel As Label
    Friend WithEvents ChildSystemCodeTextBox As TextBox
    Friend WithEvents SystemNameTextBox As TextBox
    Friend WithEvents ServicedVehicleGroupBox As GroupBox
    Friend WithEvents ChangeVehicleDefaults As Button
    Friend WithEvents ContinueButton As Button
    Friend WithEvents DefaultVehicleModelTextBox As TextBox
    Friend WithEvents DefaultVehicleModelRepairRangeTextBox As TextBox
    Friend WithEvents RenumberToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RenumberGroupBox As GroupBox
    Friend WithEvents NewNumberTextBox As TextBox
    Friend WithEvents OldNumberTextBox As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents GoRenumberButton As Button
    Friend WithEvents IncludeGrandChildrenButton As Button
End Class
