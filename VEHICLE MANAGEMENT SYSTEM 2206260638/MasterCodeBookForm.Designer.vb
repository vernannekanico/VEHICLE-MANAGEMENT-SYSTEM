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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.SearchGroupBox = New System.Windows.Forms.GroupBox()
        Me.SearchButton = New System.Windows.Forms.Button()
        Me.SearchMasterCodeBookTextBox = New System.Windows.Forms.TextBox()
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
        Me.IncludeGrandChildrenButton = New System.Windows.Forms.Button()
        Me.RenumberGroupBox = New System.Windows.Forms.GroupBox()
        Me.GoRenumberButton = New System.Windows.Forms.Button()
        Me.NewNumberTextBox = New System.Windows.Forms.TextBox()
        Me.OldNumberTextBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ChildrenButton = New System.Windows.Forms.Button()
        Me.UpButton = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ReturnButton = New System.Windows.Forms.Button()
        Me.ChangeVehicleDefaults = New System.Windows.Forms.Button()
        Me.InformationsHeadersGroupBox = New System.Windows.Forms.GroupBox()
        Me.SystemInfoHeadersDataGridView = New System.Windows.Forms.DataGridView()
        Me.InfoDetailsTextBox = New System.Windows.Forms.TextBox()
        Me.ProductDetailsGroup = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.MasterCodeBookMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.CancelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PartToolStripLabel = New System.Windows.Forms.ToolStripLabel()
        Me.SelectMasterCodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddMasterCodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditTMasterCodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteMasterCodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveMasterCodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SpecificationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RenumberToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InformationsToolStripLabel = New System.Windows.Forms.ToolStripLabel()
        Me.EditSystemInfoHeadersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectSystemInfoHeadersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddSystemInfoHeadersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveSystemInfoHeaderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HeaderDetailsToolStripLabel = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateInfoPerVehicleDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DefaultVehicleModelTextBox = New System.Windows.Forms.TextBox()
        Me.DefaultVehicleModelRepairRangeTextBox = New System.Windows.Forms.TextBox()
        CType(Me.MainSystemCodeDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SubSystemCodeDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SearchGroupBox.SuspendLayout()
        Me.MasterCodeBookDetailsGroup.SuspendLayout()
        Me.RenumberGroupBox.SuspendLayout()
        Me.InformationsHeadersGroupBox.SuspendLayout()
        CType(Me.SystemInfoHeadersDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ProductDetailsGroup.SuspendLayout()
        Me.MasterCodeBookMenuStrip.SuspendLayout()
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
        Me.MainSystemCodeDataGridView.Location = New System.Drawing.Point(6, 9)
        Me.MainSystemCodeDataGridView.Name = "MainSystemCodeDataGridView"
        Me.MainSystemCodeDataGridView.ReadOnly = True
        Me.MainSystemCodeDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.MainSystemCodeDataGridView.Size = New System.Drawing.Size(575, 295)
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
        Me.SubSystemCodeDataGridView.MultiSelect = False
        Me.SubSystemCodeDataGridView.Name = "SubSystemCodeDataGridView"
        Me.SubSystemCodeDataGridView.ReadOnly = True
        Me.SubSystemCodeDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.SubSystemCodeDataGridView.Size = New System.Drawing.Size(575, 265)
        Me.SubSystemCodeDataGridView.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.SearchGroupBox)
        Me.GroupBox1.Controls.Add(Me.MasterCodeBookDetailsGroup)
        Me.GroupBox1.Controls.Add(Me.IncludeGrandChildrenButton)
        Me.GroupBox1.Controls.Add(Me.RenumberGroupBox)
        Me.GroupBox1.Controls.Add(Me.ChildrenButton)
        Me.GroupBox1.Controls.Add(Me.UpButton)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.ReturnButton)
        Me.GroupBox1.Controls.Add(Me.MainSystemCodeDataGridView)
        Me.GroupBox1.Controls.Add(Me.SubSystemCodeDataGridView)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 75)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(627, 662)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'SearchGroupBox
        '
        Me.SearchGroupBox.Controls.Add(Me.SearchButton)
        Me.SearchGroupBox.Controls.Add(Me.SearchMasterCodeBookTextBox)
        Me.SearchGroupBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchGroupBox.Location = New System.Drawing.Point(91, 318)
        Me.SearchGroupBox.Name = "SearchGroupBox"
        Me.SearchGroupBox.Size = New System.Drawing.Size(395, 116)
        Me.SearchGroupBox.TabIndex = 86
        Me.SearchGroupBox.TabStop = False
        Me.SearchGroupBox.Visible = False
        '
        'SearchButton
        '
        Me.SearchButton.Location = New System.Drawing.Point(13, 69)
        Me.SearchButton.Name = "SearchButton"
        Me.SearchButton.Size = New System.Drawing.Size(358, 36)
        Me.SearchButton.TabIndex = 4
        Me.SearchButton.Text = "SEARCH"
        Me.SearchButton.UseVisualStyleBackColor = True
        '
        'SearchMasterCodeBookTextBox
        '
        Me.SearchMasterCodeBookTextBox.Location = New System.Drawing.Point(13, 25)
        Me.SearchMasterCodeBookTextBox.Name = "SearchMasterCodeBookTextBox"
        Me.SearchMasterCodeBookTextBox.Size = New System.Drawing.Size(358, 29)
        Me.SearchMasterCodeBookTextBox.TabIndex = 3
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
        Me.MasterCodeBookDetailsGroup.Location = New System.Drawing.Point(507, 99)
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
        Me.SubSystemLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes
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
        'IncludeGrandChildrenButton
        '
        Me.IncludeGrandChildrenButton.Location = New System.Drawing.Point(164, 310)
        Me.IncludeGrandChildrenButton.Name = "IncludeGrandChildrenButton"
        Me.IncludeGrandChildrenButton.Size = New System.Drawing.Size(259, 23)
        Me.IncludeGrandChildrenButton.TabIndex = 87
        Me.IncludeGrandChildrenButton.Text = "INCLUDE GRANDCHILDREN"
        Me.IncludeGrandChildrenButton.UseVisualStyleBackColor = True
        '
        'RenumberGroupBox
        '
        Me.RenumberGroupBox.Controls.Add(Me.GoRenumberButton)
        Me.RenumberGroupBox.Controls.Add(Me.NewNumberTextBox)
        Me.RenumberGroupBox.Controls.Add(Me.OldNumberTextBox)
        Me.RenumberGroupBox.Controls.Add(Me.Label4)
        Me.RenumberGroupBox.Controls.Add(Me.Label3)
        Me.RenumberGroupBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RenumberGroupBox.Location = New System.Drawing.Point(69, 154)
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
        'ChildrenButton
        '
        Me.ChildrenButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChildrenButton.Location = New System.Drawing.Point(593, 402)
        Me.ChildrenButton.Name = "ChildrenButton"
        Me.ChildrenButton.Size = New System.Drawing.Size(28, 23)
        Me.ChildrenButton.TabIndex = 11
        Me.ChildrenButton.Text = "↓"
        Me.ChildrenButton.UseVisualStyleBackColor = True
        '
        'UpButton
        '
        Me.UpButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UpButton.Location = New System.Drawing.Point(593, 373)
        Me.UpButton.Name = "UpButton"
        Me.UpButton.Size = New System.Drawing.Size(28, 23)
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
        'ChangeVehicleDefaults
        '
        Me.ChangeVehicleDefaults.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChangeVehicleDefaults.Location = New System.Drawing.Point(12, 38)
        Me.ChangeVehicleDefaults.Name = "ChangeVehicleDefaults"
        Me.ChangeVehicleDefaults.Size = New System.Drawing.Size(125, 30)
        Me.ChangeVehicleDefaults.TabIndex = 20
        Me.ChangeVehicleDefaults.Text = "Change vehicle"
        Me.ChangeVehicleDefaults.UseVisualStyleBackColor = True
        '
        'InformationsHeadersGroupBox
        '
        Me.InformationsHeadersGroupBox.Controls.Add(Me.SystemInfoHeadersDataGridView)
        Me.InformationsHeadersGroupBox.Controls.Add(Me.InfoDetailsTextBox)
        Me.InformationsHeadersGroupBox.Controls.Add(Me.ProductDetailsGroup)
        Me.InformationsHeadersGroupBox.Location = New System.Drawing.Point(679, 75)
        Me.InformationsHeadersGroupBox.Name = "InformationsHeadersGroupBox"
        Me.InformationsHeadersGroupBox.Size = New System.Drawing.Size(798, 703)
        Me.InformationsHeadersGroupBox.TabIndex = 4
        Me.InformationsHeadersGroupBox.TabStop = False
        '
        'SystemInfoHeadersDataGridView
        '
        Me.SystemInfoHeadersDataGridView.AllowUserToResizeColumns = False
        Me.SystemInfoHeadersDataGridView.AllowUserToResizeRows = False
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SystemInfoHeadersDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.SystemInfoHeadersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.SystemInfoHeadersDataGridView.Location = New System.Drawing.Point(22, 9)
        Me.SystemInfoHeadersDataGridView.MultiSelect = False
        Me.SystemInfoHeadersDataGridView.Name = "SystemInfoHeadersDataGridView"
        Me.SystemInfoHeadersDataGridView.ReadOnly = True
        Me.SystemInfoHeadersDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.SystemInfoHeadersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.SystemInfoHeadersDataGridView.Size = New System.Drawing.Size(571, 250)
        Me.SystemInfoHeadersDataGridView.TabIndex = 83
        '
        'InfoDetailsTextBox
        '
        Me.InfoDetailsTextBox.AcceptsReturn = True
        Me.InfoDetailsTextBox.AcceptsTab = True
        Me.InfoDetailsTextBox.Location = New System.Drawing.Point(22, 274)
        Me.InfoDetailsTextBox.Multiline = True
        Me.InfoDetailsTextBox.Name = "InfoDetailsTextBox"
        Me.InfoDetailsTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.InfoDetailsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.InfoDetailsTextBox.Size = New System.Drawing.Size(571, 330)
        Me.InfoDetailsTextBox.TabIndex = 84
        Me.InfoDetailsTextBox.Text = "Information Header Details"
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
        'MasterCodeBookMenuStrip
        '
        Me.MasterCodeBookMenuStrip.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MasterCodeBookMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CancelToolStripMenuItem, Me.PartToolStripLabel, Me.SelectMasterCodeToolStripMenuItem, Me.AddMasterCodeToolStripMenuItem, Me.EditTMasterCodeToolStripMenuItem, Me.DeleteMasterCodeToolStripMenuItem, Me.SaveMasterCodeToolStripMenuItem, Me.SpecificationsToolStripMenuItem, Me.SearchToolStripMenuItem, Me.RenumberToolStripMenuItem, Me.InformationsToolStripLabel, Me.EditSystemInfoHeadersToolStripMenuItem, Me.SelectSystemInfoHeadersToolStripMenuItem, Me.AddSystemInfoHeadersToolStripMenuItem, Me.RemoveSystemInfoHeaderToolStripMenuItem, Me.HeaderDetailsToolStripLabel})
        Me.MasterCodeBookMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MasterCodeBookMenuStrip.Name = "MasterCodeBookMenuStrip"
        Me.MasterCodeBookMenuStrip.Padding = New System.Windows.Forms.Padding(10, 3, 0, 3)
        Me.MasterCodeBookMenuStrip.Size = New System.Drawing.Size(1284, 31)
        Me.MasterCodeBookMenuStrip.TabIndex = 79
        Me.MasterCodeBookMenuStrip.Text = "MenuStrip"
        '
        'CancelToolStripMenuItem
        '
        Me.CancelToolStripMenuItem.Name = "CancelToolStripMenuItem"
        Me.CancelToolStripMenuItem.Size = New System.Drawing.Size(40, 25)
        Me.CancelToolStripMenuItem.Text = "◄ "
        '
        'PartToolStripLabel
        '
        Me.PartToolStripLabel.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.PartToolStripLabel.Font = New System.Drawing.Font("Arial", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PartToolStripLabel.Name = "PartToolStripLabel"
        Me.PartToolStripLabel.Size = New System.Drawing.Size(52, 22)
        Me.PartToolStripLabel.Text = "PART"
        '
        'SelectMasterCodeToolStripMenuItem
        '
        Me.SelectMasterCodeToolStripMenuItem.Name = "SelectMasterCodeToolStripMenuItem"
        Me.SelectMasterCodeToolStripMenuItem.Size = New System.Drawing.Size(63, 25)
        Me.SelectMasterCodeToolStripMenuItem.Text = "Select"
        '
        'AddMasterCodeToolStripMenuItem
        '
        Me.AddMasterCodeToolStripMenuItem.Name = "AddMasterCodeToolStripMenuItem"
        Me.AddMasterCodeToolStripMenuItem.Size = New System.Drawing.Size(50, 25)
        Me.AddMasterCodeToolStripMenuItem.Text = "Add"
        '
        'EditTMasterCodeToolStripMenuItem
        '
        Me.EditTMasterCodeToolStripMenuItem.Name = "EditTMasterCodeToolStripMenuItem"
        Me.EditTMasterCodeToolStripMenuItem.Size = New System.Drawing.Size(48, 25)
        Me.EditTMasterCodeToolStripMenuItem.Text = "Edit"
        '
        'DeleteMasterCodeToolStripMenuItem
        '
        Me.DeleteMasterCodeToolStripMenuItem.Name = "DeleteMasterCodeToolStripMenuItem"
        Me.DeleteMasterCodeToolStripMenuItem.Size = New System.Drawing.Size(66, 25)
        Me.DeleteMasterCodeToolStripMenuItem.Text = "Delete"
        '
        'SaveMasterCodeToolStripMenuItem
        '
        Me.SaveMasterCodeToolStripMenuItem.Name = "SaveMasterCodeToolStripMenuItem"
        Me.SaveMasterCodeToolStripMenuItem.Size = New System.Drawing.Size(55, 25)
        Me.SaveMasterCodeToolStripMenuItem.Text = "Save"
        '
        'SpecificationsToolStripMenuItem
        '
        Me.SpecificationsToolStripMenuItem.Name = "SpecificationsToolStripMenuItem"
        Me.SpecificationsToolStripMenuItem.Size = New System.Drawing.Size(117, 25)
        Me.SpecificationsToolStripMenuItem.Text = "Specifications"
        '
        'SearchToolStripMenuItem
        '
        Me.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem"
        Me.SearchToolStripMenuItem.Size = New System.Drawing.Size(69, 25)
        Me.SearchToolStripMenuItem.Text = "Search"
        '
        'RenumberToolStripMenuItem
        '
        Me.RenumberToolStripMenuItem.Name = "RenumberToolStripMenuItem"
        Me.RenumberToolStripMenuItem.Size = New System.Drawing.Size(95, 25)
        Me.RenumberToolStripMenuItem.Text = "Renumber"
        '
        'InformationsToolStripLabel
        '
        Me.InformationsToolStripLabel.Font = New System.Drawing.Font("Arial", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InformationsToolStripLabel.Name = "InformationsToolStripLabel"
        Me.InformationsToolStripLabel.Size = New System.Drawing.Size(141, 22)
        Me.InformationsToolStripLabel.Text = "INFO HEADERS :"
        '
        'EditSystemInfoHeadersToolStripMenuItem
        '
        Me.EditSystemInfoHeadersToolStripMenuItem.Name = "EditSystemInfoHeadersToolStripMenuItem"
        Me.EditSystemInfoHeadersToolStripMenuItem.Size = New System.Drawing.Size(48, 25)
        Me.EditSystemInfoHeadersToolStripMenuItem.Text = "Edit"
        '
        'SelectSystemInfoHeadersToolStripMenuItem
        '
        Me.SelectSystemInfoHeadersToolStripMenuItem.Name = "SelectSystemInfoHeadersToolStripMenuItem"
        Me.SelectSystemInfoHeadersToolStripMenuItem.Size = New System.Drawing.Size(63, 25)
        Me.SelectSystemInfoHeadersToolStripMenuItem.Text = "Select"
        '
        'AddSystemInfoHeadersToolStripMenuItem
        '
        Me.AddSystemInfoHeadersToolStripMenuItem.Name = "AddSystemInfoHeadersToolStripMenuItem"
        Me.AddSystemInfoHeadersToolStripMenuItem.Size = New System.Drawing.Size(50, 25)
        Me.AddSystemInfoHeadersToolStripMenuItem.Text = "Add"
        '
        'RemoveSystemInfoHeaderToolStripMenuItem
        '
        Me.RemoveSystemInfoHeaderToolStripMenuItem.Name = "RemoveSystemInfoHeaderToolStripMenuItem"
        Me.RemoveSystemInfoHeaderToolStripMenuItem.Size = New System.Drawing.Size(79, 25)
        Me.RemoveSystemInfoHeaderToolStripMenuItem.Text = "Remove"
        '
        'HeaderDetailsToolStripLabel
        '
        Me.HeaderDetailsToolStripLabel.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CreateInfoPerVehicleDetailsToolStripMenuItem, Me.EditDetailsToolStripMenuItem})
        Me.HeaderDetailsToolStripLabel.Name = "HeaderDetailsToolStripLabel"
        Me.HeaderDetailsToolStripLabel.Size = New System.Drawing.Size(123, 25)
        Me.HeaderDetailsToolStripLabel.Text = "Header Details"
        '
        'CreateInfoPerVehicleDetailsToolStripMenuItem
        '
        Me.CreateInfoPerVehicleDetailsToolStripMenuItem.Name = "CreateInfoPerVehicleDetailsToolStripMenuItem"
        Me.CreateInfoPerVehicleDetailsToolStripMenuItem.Size = New System.Drawing.Size(125, 26)
        Me.CreateInfoPerVehicleDetailsToolStripMenuItem.Text = "Create"
        '
        'EditDetailsToolStripMenuItem
        '
        Me.EditDetailsToolStripMenuItem.Name = "EditDetailsToolStripMenuItem"
        Me.EditDetailsToolStripMenuItem.Size = New System.Drawing.Size(125, 26)
        Me.EditDetailsToolStripMenuItem.Text = "Edit"
        Me.EditDetailsToolStripMenuItem.Visible = False
        '
        'DefaultVehicleModelTextBox
        '
        Me.DefaultVehicleModelTextBox.Enabled = False
        Me.DefaultVehicleModelTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DefaultVehicleModelTextBox.Location = New System.Drawing.Point(143, 38)
        Me.DefaultVehicleModelTextBox.Name = "DefaultVehicleModelTextBox"
        Me.DefaultVehicleModelTextBox.Size = New System.Drawing.Size(496, 31)
        Me.DefaultVehicleModelTextBox.TabIndex = 80
        Me.DefaultVehicleModelTextBox.Text = "Set Default Vehicle"
        '
        'DefaultVehicleModelRepairRangeTextBox
        '
        Me.DefaultVehicleModelRepairRangeTextBox.Enabled = False
        Me.DefaultVehicleModelRepairRangeTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DefaultVehicleModelRepairRangeTextBox.Location = New System.Drawing.Point(701, 38)
        Me.DefaultVehicleModelRepairRangeTextBox.Name = "DefaultVehicleModelRepairRangeTextBox"
        Me.DefaultVehicleModelRepairRangeTextBox.Size = New System.Drawing.Size(375, 31)
        Me.DefaultVehicleModelRepairRangeTextBox.TabIndex = 81
        '
        'MasterCodeBookForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1284, 749)
        Me.ControlBox = False
        Me.Controls.Add(Me.DefaultVehicleModelRepairRangeTextBox)
        Me.Controls.Add(Me.DefaultVehicleModelTextBox)
        Me.Controls.Add(Me.ChangeVehicleDefaults)
        Me.Controls.Add(Me.MasterCodeBookMenuStrip)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.InformationsHeadersGroupBox)
        Me.Name = "MasterCodeBookForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MasterCodeBookForm"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.MainSystemCodeDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SubSystemCodeDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.SearchGroupBox.ResumeLayout(False)
        Me.SearchGroupBox.PerformLayout()
        Me.MasterCodeBookDetailsGroup.ResumeLayout(False)
        Me.MasterCodeBookDetailsGroup.PerformLayout()
        Me.RenumberGroupBox.ResumeLayout(False)
        Me.RenumberGroupBox.PerformLayout()
        Me.InformationsHeadersGroupBox.ResumeLayout(False)
        Me.InformationsHeadersGroupBox.PerformLayout()
        CType(Me.SystemInfoHeadersDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ProductDetailsGroup.ResumeLayout(False)
        Me.ProductDetailsGroup.PerformLayout()
        Me.MasterCodeBookMenuStrip.ResumeLayout(False)
        Me.MasterCodeBookMenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MainSystemCodeDataGridView As DataGridView
    Friend WithEvents SubSystemCodeDataGridView As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents ReturnButton As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents InformationsHeadersGroupBox As GroupBox
    Friend WithEvents ChildrenButton As Button
    Friend WithEvents UpButton As Button
    Friend WithEvents MasterCodeBookMenuStrip As MenuStrip
    Friend WithEvents CancelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelectMasterCodeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddMasterCodeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditTMasterCodeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteMasterCodeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveMasterCodeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PartToolStripLabel As ToolStripLabel
    Friend WithEvents InformationsToolStripLabel As ToolStripLabel
    Friend WithEvents AddSystemInfoHeadersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditSystemInfoHeadersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RemoveSystemInfoHeaderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProductDetailsGroup As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents SelectSystemInfoHeadersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChangeVehicleDefaults As Button
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
    Friend WithEvents SystemInfoHeadersDataGridView As DataGridView
    Friend WithEvents MasterCodeBookDetailsGroup As GroupBox
    Friend WithEvents ChildSystemNameLabel As Label
    Friend WithEvents SubSystemLabel As Label
    Friend WithEvents SubSystemPrefixLabel As Label
    Friend WithEvents ChildSystemCodeTextBox As TextBox
    Friend WithEvents ParentSystemNameLabel As Label
    Friend WithEvents MainSystemLabel As Label
    Friend WithEvents MainSystemPrefixLabel As Label
    Friend WithEvents SystemNameTextBox As TextBox
    Friend WithEvents ParentSystemCodeTextBox As TextBox
    Friend WithEvents InfoDetailsTextBox As TextBox
    Friend WithEvents HeaderDetailsToolStripLabel As ToolStripMenuItem
    Friend WithEvents CreateInfoPerVehicleDetailsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditDetailsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SpecificationsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SearchToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SearchGroupBox As GroupBox
    Friend WithEvents SearchButton As Button
    Friend WithEvents SearchMasterCodeBookTextBox As TextBox
End Class
