<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class OwnersForm
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
        Me.OwnerDataGridView = New System.Windows.Forms.DataGridView()
        Me.OwnedVehiclesDataGridView = New System.Windows.Forms.DataGridView()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.CancelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CUSTOMERToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectCustomerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectVehicleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddVehicleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditVehicleToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveVehicleToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.NameSearchTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.PhoneNumberSearchTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SelectedCustomerTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SelectedVehicleTextBox = New System.Windows.Forms.TextBox()
        Me.CurrentSelectionGroupBox = New System.Windows.Forms.GroupBox()
        Me.JobsHistoryDataGridView = New System.Windows.Forms.DataGridView()
        Me.OwnerDetailsGroupBox = New System.Windows.Forms.GroupBox()
        Me.PhoneNumberTextBox = New System.Windows.Forms.MaskedTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.NamePrefixTextBox = New System.Windows.Forms.TextBox()
        Me.CityTextBox = New System.Windows.Forms.TextBox()
        Me.StateProvTextBox = New System.Windows.Forms.TextBox()
        Me.ZipCodeTextBox = New System.Windows.Forms.TextBox()
        Me.EXITSAVEOwnerChangesButton = New System.Windows.Forms.Button()
        Me.BldgAptRmNoTextBox = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.CountryTextBox = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.EmailAddressTextBox = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.StreetTextBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.AliasTextBox = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.FirstNameTextBox = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.LastNameTextBox = New System.Windows.Forms.TextBox()
        Me.ServicedVehicleDetailsGroupBox = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.VehicleTextBox = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.PlateNumberTextBox = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.VINtextBox = New System.Windows.Forms.TextBox()
        Me.ExitSaveVehicleChangesButton = New System.Windows.Forms.Button()
        CType(Me.OwnerDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OwnedVehiclesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.CurrentSelectionGroupBox.SuspendLayout()
        CType(Me.JobsHistoryDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.OwnerDetailsGroupBox.SuspendLayout()
        Me.ServicedVehicleDetailsGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'OwnerDataGridView
        '
        Me.OwnerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.OwnerDataGridView.Location = New System.Drawing.Point(1, 145)
        Me.OwnerDataGridView.Name = "OwnerDataGridView"
        Me.OwnerDataGridView.ReadOnly = True
        Me.OwnerDataGridView.Size = New System.Drawing.Size(657, 507)
        Me.OwnerDataGridView.TabIndex = 0
        '
        'OwnedVehiclesDataGridView
        '
        Me.OwnedVehiclesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.OwnedVehiclesDataGridView.Location = New System.Drawing.Point(664, 57)
        Me.OwnedVehiclesDataGridView.Name = "OwnedVehiclesDataGridView"
        Me.OwnedVehiclesDataGridView.ReadOnly = True
        Me.OwnedVehiclesDataGridView.Size = New System.Drawing.Size(823, 108)
        Me.OwnedVehiclesDataGridView.TabIndex = 11
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CancelToolStripMenuItem, Me.CUSTOMERToolStripMenuItem, Me.SelectCustomerToolStripMenuItem, Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.ToolStripMenuItem1, Me.SelectVehicleToolStripMenuItem, Me.AddVehicleToolStripMenuItem, Me.EditVehicleToolStripMenuItem1, Me.RemoveVehicleToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1284, 29)
        Me.MenuStrip1.TabIndex = 43
        Me.MenuStrip1.Text = "OwnersFormMainMenuStrip"
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
        Me.CUSTOMERToolStripMenuItem.Size = New System.Drawing.Size(115, 25)
        Me.CUSTOMERToolStripMenuItem.Text = "CUSTOMER :"
        '
        'SelectCustomerToolStripMenuItem
        '
        Me.SelectCustomerToolStripMenuItem.Name = "SelectCustomerToolStripMenuItem"
        Me.SelectCustomerToolStripMenuItem.Size = New System.Drawing.Size(63, 25)
        Me.SelectCustomerToolStripMenuItem.Text = "Select"
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(50, 25)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(48, 25)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(66, 25)
        Me.DeleteToolStripMenuItem.Text = "Delete"
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
        Me.SelectVehicleToolStripMenuItem.Size = New System.Drawing.Size(550, 25)
        Me.SelectVehicleToolStripMenuItem.Text = ":                                                                                " &
    "                                 VEHICLE :"
        '
        'AddVehicleToolStripMenuItem
        '
        Me.AddVehicleToolStripMenuItem.Name = "AddVehicleToolStripMenuItem"
        Me.AddVehicleToolStripMenuItem.Size = New System.Drawing.Size(50, 25)
        Me.AddVehicleToolStripMenuItem.Text = "Add"
        '
        'EditVehicleToolStripMenuItem1
        '
        Me.EditVehicleToolStripMenuItem1.Name = "EditVehicleToolStripMenuItem1"
        Me.EditVehicleToolStripMenuItem1.Size = New System.Drawing.Size(48, 25)
        Me.EditVehicleToolStripMenuItem1.Text = "Edit"
        '
        'RemoveVehicleToolStripMenuItem1
        '
        Me.RemoveVehicleToolStripMenuItem1.Name = "RemoveVehicleToolStripMenuItem1"
        Me.RemoveVehicleToolStripMenuItem1.Size = New System.Drawing.Size(79, 25)
        Me.RemoveVehicleToolStripMenuItem1.Text = "Remove"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.NameSearchTextBox, Me.ToolStripSeparator1, Me.ToolStripLabel2, Me.PhoneNumberSearchTextBox})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 29)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1284, 26)
        Me.ToolStrip1.TabIndex = 44
        Me.ToolStrip1.Text = "OwnersFormSearchToolStrip"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(52, 23)
        Me.ToolStripLabel1.Text = "Name"
        '
        'NameSearchTextBox
        '
        Me.NameSearchTextBox.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.NameSearchTextBox.Name = "NameSearchTextBox"
        Me.NameSearchTextBox.Size = New System.Drawing.Size(200, 26)
        Me.NameSearchTextBox.Text = "Search"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 26)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(116, 23)
        Me.ToolStripLabel2.Text = "Phone Number"
        '
        'PhoneNumberSearchTextBox
        '
        Me.PhoneNumberSearchTextBox.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.PhoneNumberSearchTextBox.Name = "PhoneNumberSearchTextBox"
        Me.PhoneNumberSearchTextBox.Size = New System.Drawing.Size(100, 26)
        Me.PhoneNumberSearchTextBox.Text = "Search"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(0, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(159, 20)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "Current Selection :"
        '
        'SelectedCustomerTextBox
        '
        Me.SelectedCustomerTextBox.Location = New System.Drawing.Point(277, 15)
        Me.SelectedCustomerTextBox.Name = "SelectedCustomerTextBox"
        Me.SelectedCustomerTextBox.Size = New System.Drawing.Size(319, 26)
        Me.SelectedCustomerTextBox.TabIndex = 46
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(168, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 20)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "Vehicle     :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(168, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 20)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "Customer :"
        '
        'SelectedVehicleTextBox
        '
        Me.SelectedVehicleTextBox.Location = New System.Drawing.Point(277, 47)
        Me.SelectedVehicleTextBox.Name = "SelectedVehicleTextBox"
        Me.SelectedVehicleTextBox.Size = New System.Drawing.Size(319, 26)
        Me.SelectedVehicleTextBox.TabIndex = 49
        '
        'CurrentSelectionGroupBox
        '
        Me.CurrentSelectionGroupBox.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.CurrentSelectionGroupBox.Controls.Add(Me.Label3)
        Me.CurrentSelectionGroupBox.Controls.Add(Me.SelectedVehicleTextBox)
        Me.CurrentSelectionGroupBox.Controls.Add(Me.Label1)
        Me.CurrentSelectionGroupBox.Controls.Add(Me.SelectedCustomerTextBox)
        Me.CurrentSelectionGroupBox.Controls.Add(Me.Label2)
        Me.CurrentSelectionGroupBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurrentSelectionGroupBox.ForeColor = System.Drawing.SystemColors.Desktop
        Me.CurrentSelectionGroupBox.Location = New System.Drawing.Point(12, 57)
        Me.CurrentSelectionGroupBox.Name = "CurrentSelectionGroupBox"
        Me.CurrentSelectionGroupBox.Size = New System.Drawing.Size(646, 87)
        Me.CurrentSelectionGroupBox.TabIndex = 50
        Me.CurrentSelectionGroupBox.TabStop = False
        '
        'JobsHistoryDataGridView
        '
        Me.JobsHistoryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.JobsHistoryDataGridView.Location = New System.Drawing.Point(664, 171)
        Me.JobsHistoryDataGridView.Name = "JobsHistoryDataGridView"
        Me.JobsHistoryDataGridView.ReadOnly = True
        Me.JobsHistoryDataGridView.Size = New System.Drawing.Size(656, 108)
        Me.JobsHistoryDataGridView.TabIndex = 51
        '
        'OwnerDetailsGroupBox
        '
        Me.OwnerDetailsGroupBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OwnerDetailsGroupBox.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.OwnerDetailsGroupBox.Controls.Add(Me.PhoneNumberTextBox)
        Me.OwnerDetailsGroupBox.Controls.Add(Me.Label13)
        Me.OwnerDetailsGroupBox.Controls.Add(Me.NamePrefixTextBox)
        Me.OwnerDetailsGroupBox.Controls.Add(Me.CityTextBox)
        Me.OwnerDetailsGroupBox.Controls.Add(Me.StateProvTextBox)
        Me.OwnerDetailsGroupBox.Controls.Add(Me.ZipCodeTextBox)
        Me.OwnerDetailsGroupBox.Controls.Add(Me.EXITSAVEOwnerChangesButton)
        Me.OwnerDetailsGroupBox.Controls.Add(Me.BldgAptRmNoTextBox)
        Me.OwnerDetailsGroupBox.Controls.Add(Me.Label12)
        Me.OwnerDetailsGroupBox.Controls.Add(Me.Label11)
        Me.OwnerDetailsGroupBox.Controls.Add(Me.CountryTextBox)
        Me.OwnerDetailsGroupBox.Controls.Add(Me.Label9)
        Me.OwnerDetailsGroupBox.Controls.Add(Me.Label8)
        Me.OwnerDetailsGroupBox.Controls.Add(Me.Label7)
        Me.OwnerDetailsGroupBox.Controls.Add(Me.EmailAddressTextBox)
        Me.OwnerDetailsGroupBox.Controls.Add(Me.Label6)
        Me.OwnerDetailsGroupBox.Controls.Add(Me.Label5)
        Me.OwnerDetailsGroupBox.Controls.Add(Me.StreetTextBox)
        Me.OwnerDetailsGroupBox.Controls.Add(Me.Label4)
        Me.OwnerDetailsGroupBox.Controls.Add(Me.Label10)
        Me.OwnerDetailsGroupBox.Controls.Add(Me.AliasTextBox)
        Me.OwnerDetailsGroupBox.Controls.Add(Me.Label14)
        Me.OwnerDetailsGroupBox.Controls.Add(Me.FirstNameTextBox)
        Me.OwnerDetailsGroupBox.Controls.Add(Me.Label15)
        Me.OwnerDetailsGroupBox.Controls.Add(Me.LastNameTextBox)
        Me.OwnerDetailsGroupBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OwnerDetailsGroupBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.OwnerDetailsGroupBox.Location = New System.Drawing.Point(50, 50)
        Me.OwnerDetailsGroupBox.Name = "OwnerDetailsGroupBox"
        Me.OwnerDetailsGroupBox.Size = New System.Drawing.Size(536, 596)
        Me.OwnerDetailsGroupBox.TabIndex = 120
        Me.OwnerDetailsGroupBox.TabStop = False
        Me.OwnerDetailsGroupBox.Text = "Owner Details"
        Me.OwnerDetailsGroupBox.Visible = False
        '
        'PhoneNumberTextBox
        '
        Me.PhoneNumberTextBox.Location = New System.Drawing.Point(178, 177)
        Me.PhoneNumberTextBox.Name = "PhoneNumberTextBox"
        Me.PhoneNumberTextBox.Size = New System.Drawing.Size(122, 26)
        Me.PhoneNumberTextBox.TabIndex = 121
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(14, 108)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(116, 20)
        Me.Label13.TabIndex = 119
        Me.Label13.Text = "Jr / Sr / I / II / III"
        '
        'NamePrefixTextBox
        '
        Me.NamePrefixTextBox.Location = New System.Drawing.Point(178, 105)
        Me.NamePrefixTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.NamePrefixTextBox.Name = "NamePrefixTextBox"
        Me.NamePrefixTextBox.Size = New System.Drawing.Size(53, 26)
        Me.NamePrefixTextBox.TabIndex = 118
        '
        'CityTextBox
        '
        Me.CityTextBox.Location = New System.Drawing.Point(178, 409)
        Me.CityTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CityTextBox.Name = "CityTextBox"
        Me.CityTextBox.Size = New System.Drawing.Size(199, 26)
        Me.CityTextBox.TabIndex = 117
        '
        'StateProvTextBox
        '
        Me.StateProvTextBox.Enabled = False
        Me.StateProvTextBox.Location = New System.Drawing.Point(178, 445)
        Me.StateProvTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.StateProvTextBox.Name = "StateProvTextBox"
        Me.StateProvTextBox.Size = New System.Drawing.Size(199, 26)
        Me.StateProvTextBox.TabIndex = 116
        '
        'ZipCodeTextBox
        '
        Me.ZipCodeTextBox.Enabled = False
        Me.ZipCodeTextBox.Location = New System.Drawing.Point(178, 478)
        Me.ZipCodeTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ZipCodeTextBox.Name = "ZipCodeTextBox"
        Me.ZipCodeTextBox.Size = New System.Drawing.Size(199, 26)
        Me.ZipCodeTextBox.TabIndex = 115
        '
        'EXITSAVEOwnerChangesButton
        '
        Me.EXITSAVEOwnerChangesButton.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.EXITSAVEOwnerChangesButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EXITSAVEOwnerChangesButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.EXITSAVEOwnerChangesButton.Location = New System.Drawing.Point(26, 548)
        Me.EXITSAVEOwnerChangesButton.Name = "EXITSAVEOwnerChangesButton"
        Me.EXITSAVEOwnerChangesButton.Size = New System.Drawing.Size(493, 33)
        Me.EXITSAVEOwnerChangesButton.TabIndex = 96
        Me.EXITSAVEOwnerChangesButton.Text = "EXIT / SAVE Changes"
        Me.EXITSAVEOwnerChangesButton.UseVisualStyleBackColor = False
        '
        'BldgAptRmNoTextBox
        '
        Me.BldgAptRmNoTextBox.Location = New System.Drawing.Point(178, 371)
        Me.BldgAptRmNoTextBox.Name = "BldgAptRmNoTextBox"
        Me.BldgAptRmNoTextBox.Size = New System.Drawing.Size(330, 26)
        Me.BldgAptRmNoTextBox.TabIndex = 114
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(22, 377)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(123, 20)
        Me.Label12.TabIndex = 113
        Me.Label12.Text = "Building/Apt/Rm"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(22, 484)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(73, 20)
        Me.Label11.TabIndex = 112
        Me.Label11.Text = "Zip Code"
        '
        'CountryTextBox
        '
        Me.CountryTextBox.Enabled = False
        Me.CountryTextBox.Location = New System.Drawing.Point(178, 514)
        Me.CountryTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CountryTextBox.Name = "CountryTextBox"
        Me.CountryTextBox.Size = New System.Drawing.Size(199, 26)
        Me.CountryTextBox.TabIndex = 111
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(22, 448)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 20)
        Me.Label9.TabIndex = 110
        Me.Label9.Text = "State"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(14, 274)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(106, 24)
        Me.Label8.TabIndex = 109
        Me.Label8.Text = "ADDRESS"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 216)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(107, 20)
        Me.Label7.TabIndex = 108
        Me.Label7.Text = "Email Adrress"
        '
        'EmailAddressTextBox
        '
        Me.EmailAddressTextBox.Location = New System.Drawing.Point(178, 213)
        Me.EmailAddressTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.EmailAddressTextBox.Name = "EmailAddressTextBox"
        Me.EmailAddressTextBox.Size = New System.Drawing.Size(276, 26)
        Me.EmailAddressTextBox.TabIndex = 107
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(22, 412)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 20)
        Me.Label6.TabIndex = 106
        Me.Label6.Text = "City"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(22, 338)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 20)
        Me.Label5.TabIndex = 105
        Me.Label5.Text = "Street "
        '
        'StreetTextBox
        '
        Me.StreetTextBox.Location = New System.Drawing.Point(178, 335)
        Me.StreetTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.StreetTextBox.Name = "StreetTextBox"
        Me.StreetTextBox.Size = New System.Drawing.Size(330, 26)
        Me.StreetTextBox.TabIndex = 104
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 180)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 20)
        Me.Label4.TabIndex = 103
        Me.Label4.Text = "Phone #"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(14, 144)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 20)
        Me.Label10.TabIndex = 102
        Me.Label10.Text = "Alias"
        '
        'AliasTextBox
        '
        Me.AliasTextBox.Location = New System.Drawing.Point(178, 141)
        Me.AliasTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.AliasTextBox.Name = "AliasTextBox"
        Me.AliasTextBox.Size = New System.Drawing.Size(330, 26)
        Me.AliasTextBox.TabIndex = 101
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(14, 72)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(86, 20)
        Me.Label14.TabIndex = 100
        Me.Label14.Text = "First Name"
        '
        'FirstNameTextBox
        '
        Me.FirstNameTextBox.Location = New System.Drawing.Point(178, 69)
        Me.FirstNameTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.FirstNameTextBox.Name = "FirstNameTextBox"
        Me.FirstNameTextBox.Size = New System.Drawing.Size(330, 26)
        Me.FirstNameTextBox.TabIndex = 99
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(14, 36)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(86, 20)
        Me.Label15.TabIndex = 98
        Me.Label15.Text = "Last Name"
        '
        'LastNameTextBox
        '
        Me.LastNameTextBox.Location = New System.Drawing.Point(178, 33)
        Me.LastNameTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.LastNameTextBox.Name = "LastNameTextBox"
        Me.LastNameTextBox.Size = New System.Drawing.Size(330, 26)
        Me.LastNameTextBox.TabIndex = 97
        '
        'ServicedVehicleDetailsGroupBox
        '
        Me.ServicedVehicleDetailsGroupBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ServicedVehicleDetailsGroupBox.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ServicedVehicleDetailsGroupBox.Controls.Add(Me.Label16)
        Me.ServicedVehicleDetailsGroupBox.Controls.Add(Me.VehicleTextBox)
        Me.ServicedVehicleDetailsGroupBox.Controls.Add(Me.Label17)
        Me.ServicedVehicleDetailsGroupBox.Controls.Add(Me.PlateNumberTextBox)
        Me.ServicedVehicleDetailsGroupBox.Controls.Add(Me.Label18)
        Me.ServicedVehicleDetailsGroupBox.Controls.Add(Me.VINtextBox)
        Me.ServicedVehicleDetailsGroupBox.Controls.Add(Me.ExitSaveVehicleChangesButton)
        Me.ServicedVehicleDetailsGroupBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ServicedVehicleDetailsGroupBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ServicedVehicleDetailsGroupBox.Location = New System.Drawing.Point(200, 200)
        Me.ServicedVehicleDetailsGroupBox.Name = "ServicedVehicleDetailsGroupBox"
        Me.ServicedVehicleDetailsGroupBox.Size = New System.Drawing.Size(613, 222)
        Me.ServicedVehicleDetailsGroupBox.TabIndex = 121
        Me.ServicedVehicleDetailsGroupBox.TabStop = False
        Me.ServicedVehicleDetailsGroupBox.Text = "Serviced Vehicle Details"
        Me.ServicedVehicleDetailsGroupBox.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(24, 108)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(61, 20)
        Me.Label16.TabIndex = 102
        Me.Label16.Text = "Vehicle"
        '
        'VehicleTextBox
        '
        Me.VehicleTextBox.Location = New System.Drawing.Point(179, 104)
        Me.VehicleTextBox.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.VehicleTextBox.Name = "VehicleTextBox"
        Me.VehicleTextBox.Size = New System.Drawing.Size(409, 26)
        Me.VehicleTextBox.TabIndex = 101
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(24, 77)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(105, 20)
        Me.Label17.TabIndex = 100
        Me.Label17.Text = "Plate Number"
        '
        'PlateNumberTextBox
        '
        Me.PlateNumberTextBox.Location = New System.Drawing.Point(179, 73)
        Me.PlateNumberTextBox.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.PlateNumberTextBox.Name = "PlateNumberTextBox"
        Me.PlateNumberTextBox.Size = New System.Drawing.Size(106, 26)
        Me.PlateNumberTextBox.TabIndex = 99
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(24, 43)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(36, 20)
        Me.Label18.TabIndex = 98
        Me.Label18.Text = "VIN"
        '
        'VINtextBox
        '
        Me.VINtextBox.Location = New System.Drawing.Point(179, 40)
        Me.VINtextBox.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.VINtextBox.Name = "VINtextBox"
        Me.VINtextBox.Size = New System.Drawing.Size(205, 26)
        Me.VINtextBox.TabIndex = 97
        '
        'ExitSaveVehicleChangesButton
        '
        Me.ExitSaveVehicleChangesButton.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ExitSaveVehicleChangesButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExitSaveVehicleChangesButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ExitSaveVehicleChangesButton.Location = New System.Drawing.Point(28, 159)
        Me.ExitSaveVehicleChangesButton.Name = "ExitSaveVehicleChangesButton"
        Me.ExitSaveVehicleChangesButton.Size = New System.Drawing.Size(558, 33)
        Me.ExitSaveVehicleChangesButton.TabIndex = 96
        Me.ExitSaveVehicleChangesButton.Text = "EXIT / SAVE Changes"
        Me.ExitSaveVehicleChangesButton.UseVisualStyleBackColor = False
        '
        'OwnersForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1284, 666)
        Me.ControlBox = False
        Me.Controls.Add(Me.ServicedVehicleDetailsGroupBox)
        Me.Controls.Add(Me.OwnedVehiclesDataGridView)
        Me.Controls.Add(Me.OwnerDetailsGroupBox)
        Me.Controls.Add(Me.JobsHistoryDataGridView)
        Me.Controls.Add(Me.CurrentSelectionGroupBox)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.OwnerDataGridView)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "OwnersForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vehicle Owner"
        CType(Me.OwnerDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OwnedVehiclesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.CurrentSelectionGroupBox.ResumeLayout(False)
        Me.CurrentSelectionGroupBox.PerformLayout()
        CType(Me.JobsHistoryDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.OwnerDetailsGroupBox.ResumeLayout(False)
        Me.OwnerDetailsGroupBox.PerformLayout()
        Me.ServicedVehicleDetailsGroupBox.ResumeLayout(False)
        Me.ServicedVehicleDetailsGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents OwnerDataGridView As DataGridView
    Friend WithEvents OwnedVehiclesDataGridView As DataGridView
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents AddToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelectCustomerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents CancelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents NameSearchTextBox As ToolStripTextBox
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents PhoneNumberSearchTextBox As ToolStripTextBox
    Friend WithEvents SelectVehicleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CUSTOMERToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddVehicleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditVehicleToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents RemoveVehicleToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents Label1 As Label
    Friend WithEvents SelectedCustomerTextBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents SelectedVehicleTextBox As TextBox
    Friend WithEvents CurrentSelectionGroupBox As GroupBox
    Friend WithEvents JobsHistoryDataGridView As DataGridView
    Friend WithEvents OwnerDetailsGroupBox As GroupBox
    Friend WithEvents EXITSAVEOwnerChangesButton As Button
    Friend WithEvents PhoneNumberTextBox As MaskedTextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents NamePrefixTextBox As TextBox
    Friend WithEvents CityTextBox As TextBox
    Friend WithEvents StateProvTextBox As TextBox
    Friend WithEvents ZipCodeTextBox As TextBox
    Friend WithEvents BldgAptRmNoTextBox As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents CountryTextBox As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents EmailAddressTextBox As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents StreetTextBox As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents AliasTextBox As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents FirstNameTextBox As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents LastNameTextBox As TextBox
    Friend WithEvents ServicedVehicleDetailsGroupBox As GroupBox
    Friend WithEvents ExitSaveVehicleChangesButton As Button
    Friend WithEvents Label16 As Label
    Friend WithEvents VehicleTextBox As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents PlateNumberTextBox As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents VINtextBox As TextBox
End Class
