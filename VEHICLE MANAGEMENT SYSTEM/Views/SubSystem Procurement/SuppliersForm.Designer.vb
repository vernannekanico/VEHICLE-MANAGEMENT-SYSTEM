<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SuppliersForm
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ActivatedByTextBox = New System.Windows.Forms.TextBox()
        Me.SupplierssPartsMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.CancelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchSupplierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchDescriptionToolStripTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.SupplierDetailsGroup = New System.Windows.Forms.GroupBox()
        Me.EmailAddress_ShortText20TextBox = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.BldgAptRmNo_ShortText25TextBox = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CountryName_ShortText25TextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CityID_LongIntegerTextBox = New System.Windows.Forms.MaskedTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.StateProvName_ShortText25TextBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ContactPerson_ShortText30TextBox = New System.Windows.Forms.TextBox()
        Me.Street_ShortText25TextBox = New System.Windows.Forms.TextBox()
        Me.TelNo_ShortText10TextBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ManufacturerPartNoLabel = New System.Windows.Forms.Label()
        Me.SuppliersDataGridView = New System.Windows.Forms.DataGridView()
        Me.SuppliersGroupBox = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ZipCode_ShortText9TextBox = New System.Windows.Forms.TextBox()
        Me.SupplierName_ShortText35TextBox = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.SupplierssPartsMenuStrip.SuspendLayout()
        Me.SupplierDetailsGroup.SuspendLayout()
        CType(Me.SuppliersDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuppliersGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'ActivatedByTextBox
        '
        Me.ActivatedByTextBox.Location = New System.Drawing.Point(1035, 57)
        Me.ActivatedByTextBox.Margin = New System.Windows.Forms.Padding(5)
        Me.ActivatedByTextBox.Name = "ActivatedByTextBox"
        Me.ActivatedByTextBox.Size = New System.Drawing.Size(105, 26)
        Me.ActivatedByTextBox.TabIndex = 86
        Me.ActivatedByTextBox.Text = "ActivatedByTextBox"
        Me.ActivatedByTextBox.Visible = False
        '
        'SupplierssPartsMenuStrip
        '
        Me.SupplierssPartsMenuStrip.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SupplierssPartsMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CancelToolStripMenuItem, Me.ToolStripMenuItem1, Me.SelectToolStripMenuItem, Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.SaveToolStripMenuItem, Me.SearchSupplierToolStripMenuItem, Me.SearchDescriptionToolStripTextBox})
        Me.SupplierssPartsMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.SupplierssPartsMenuStrip.Name = "SupplierssPartsMenuStrip"
        Me.SupplierssPartsMenuStrip.Padding = New System.Windows.Forms.Padding(15, 5, 0, 5)
        Me.SupplierssPartsMenuStrip.Size = New System.Drawing.Size(1303, 36)
        Me.SupplierssPartsMenuStrip.TabIndex = 89
        Me.SupplierssPartsMenuStrip.Text = "MenuStrip1"
        '
        'CancelToolStripMenuItem
        '
        Me.CancelToolStripMenuItem.Name = "CancelToolStripMenuItem"
        Me.CancelToolStripMenuItem.Size = New System.Drawing.Size(40, 26)
        Me.CancelToolStripMenuItem.Text = "◄ "
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(12, 26)
        '
        'SelectToolStripMenuItem
        '
        Me.SelectToolStripMenuItem.Name = "SelectToolStripMenuItem"
        Me.SelectToolStripMenuItem.Size = New System.Drawing.Size(63, 26)
        Me.SelectToolStripMenuItem.Text = "Select"
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(50, 26)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(48, 26)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(66, 26)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(55, 26)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'SearchSupplierToolStripMenuItem
        '
        Me.SearchSupplierToolStripMenuItem.Name = "SearchSupplierToolStripMenuItem"
        Me.SearchSupplierToolStripMenuItem.Size = New System.Drawing.Size(131, 26)
        Me.SearchSupplierToolStripMenuItem.Text = "Search Supplier"
        '
        'SearchDescriptionToolStripTextBox
        '
        Me.SearchDescriptionToolStripTextBox.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.SearchDescriptionToolStripTextBox.Name = "SearchDescriptionToolStripTextBox"
        Me.SearchDescriptionToolStripTextBox.Size = New System.Drawing.Size(100, 26)
        Me.SearchDescriptionToolStripTextBox.Text = "SUPPLIER"
        '
        'SupplierDetailsGroup
        '
        Me.SupplierDetailsGroup.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.SupplierDetailsGroup.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.SupplierDetailsGroup.Controls.Add(Me.SupplierName_ShortText35TextBox)
        Me.SupplierDetailsGroup.Controls.Add(Me.Label9)
        Me.SupplierDetailsGroup.Controls.Add(Me.Label8)
        Me.SupplierDetailsGroup.Controls.Add(Me.ZipCode_ShortText9TextBox)
        Me.SupplierDetailsGroup.Controls.Add(Me.EmailAddress_ShortText20TextBox)
        Me.SupplierDetailsGroup.Controls.Add(Me.Label7)
        Me.SupplierDetailsGroup.Controls.Add(Me.BldgAptRmNo_ShortText25TextBox)
        Me.SupplierDetailsGroup.Controls.Add(Me.Label5)
        Me.SupplierDetailsGroup.Controls.Add(Me.CountryName_ShortText25TextBox)
        Me.SupplierDetailsGroup.Controls.Add(Me.Label1)
        Me.SupplierDetailsGroup.Controls.Add(Me.CityID_LongIntegerTextBox)
        Me.SupplierDetailsGroup.Controls.Add(Me.Label6)
        Me.SupplierDetailsGroup.Controls.Add(Me.StateProvName_ShortText25TextBox)
        Me.SupplierDetailsGroup.Controls.Add(Me.Label4)
        Me.SupplierDetailsGroup.Controls.Add(Me.ContactPerson_ShortText30TextBox)
        Me.SupplierDetailsGroup.Controls.Add(Me.Street_ShortText25TextBox)
        Me.SupplierDetailsGroup.Controls.Add(Me.TelNo_ShortText10TextBox)
        Me.SupplierDetailsGroup.Controls.Add(Me.Label3)
        Me.SupplierDetailsGroup.Controls.Add(Me.Label2)
        Me.SupplierDetailsGroup.Controls.Add(Me.ManufacturerPartNoLabel)
        Me.SupplierDetailsGroup.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.SupplierDetailsGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SupplierDetailsGroup.Location = New System.Drawing.Point(542, 57)
        Me.SupplierDetailsGroup.Name = "SupplierDetailsGroup"
        Me.SupplierDetailsGroup.Size = New System.Drawing.Size(709, 432)
        Me.SupplierDetailsGroup.TabIndex = 91
        Me.SupplierDetailsGroup.TabStop = False
        Me.SupplierDetailsGroup.Text = "Supplier Details"
        '
        'EmailAddress_ShortText20TextBox
        '
        Me.EmailAddress_ShortText20TextBox.Location = New System.Drawing.Point(165, 145)
        Me.EmailAddress_ShortText20TextBox.Name = "EmailAddress_ShortText20TextBox"
        Me.EmailAddress_ShortText20TextBox.Size = New System.Drawing.Size(457, 26)
        Me.EmailAddress_ShortText20TextBox.TabIndex = 59
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(18, 151)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(121, 20)
        Me.Label7.TabIndex = 58
        Me.Label7.Text = "EMAIL Address"
        '
        'BldgAptRmNo_ShortText25TextBox
        '
        Me.BldgAptRmNo_ShortText25TextBox.Location = New System.Drawing.Point(165, 241)
        Me.BldgAptRmNo_ShortText25TextBox.Multiline = True
        Me.BldgAptRmNo_ShortText25TextBox.Name = "BldgAptRmNo_ShortText25TextBox"
        Me.BldgAptRmNo_ShortText25TextBox.Size = New System.Drawing.Size(457, 26)
        Me.BldgAptRmNo_ShortText25TextBox.TabIndex = 57
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 340)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 20)
        Me.Label5.TabIndex = 56
        Me.Label5.Text = "Country"
        '
        'CountryName_ShortText25TextBox
        '
        Me.CountryName_ShortText25TextBox.Location = New System.Drawing.Point(165, 337)
        Me.CountryName_ShortText25TextBox.Name = "CountryName_ShortText25TextBox"
        Me.CountryName_ShortText25TextBox.Size = New System.Drawing.Size(209, 26)
        Me.CountryName_ShortText25TextBox.TabIndex = 55
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 247)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 20)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "Apt #."
        '
        'CityID_LongIntegerTextBox
        '
        Me.CityID_LongIntegerTextBox.Location = New System.Drawing.Point(165, 273)
        Me.CityID_LongIntegerTextBox.Name = "CityID_LongIntegerTextBox"
        Me.CityID_LongIntegerTextBox.Size = New System.Drawing.Size(209, 26)
        Me.CityID_LongIntegerTextBox.TabIndex = 53
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(18, 308)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(120, 20)
        Me.Label6.TabIndex = 49
        Me.Label6.Text = "State / Province"
        '
        'StateProvName_ShortText25TextBox
        '
        Me.StateProvName_ShortText25TextBox.Location = New System.Drawing.Point(165, 305)
        Me.StateProvName_ShortText25TextBox.Name = "StateProvName_ShortText25TextBox"
        Me.StateProvName_ShortText25TextBox.Size = New System.Drawing.Size(209, 26)
        Me.StateProvName_ShortText25TextBox.TabIndex = 48
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 276)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 20)
        Me.Label4.TabIndex = 46
        Me.Label4.Text = "City / Town"
        '
        'ContactPerson_ShortText30TextBox
        '
        Me.ContactPerson_ShortText30TextBox.Enabled = False
        Me.ContactPerson_ShortText30TextBox.Location = New System.Drawing.Point(165, 87)
        Me.ContactPerson_ShortText30TextBox.Name = "ContactPerson_ShortText30TextBox"
        Me.ContactPerson_ShortText30TextBox.Size = New System.Drawing.Size(457, 26)
        Me.ContactPerson_ShortText30TextBox.TabIndex = 45
        '
        'Street_ShortText25TextBox
        '
        Me.Street_ShortText25TextBox.Location = New System.Drawing.Point(165, 209)
        Me.Street_ShortText25TextBox.Multiline = True
        Me.Street_ShortText25TextBox.Name = "Street_ShortText25TextBox"
        Me.Street_ShortText25TextBox.Size = New System.Drawing.Size(457, 26)
        Me.Street_ShortText25TextBox.TabIndex = 44
        '
        'TelNo_ShortText10TextBox
        '
        Me.TelNo_ShortText10TextBox.Location = New System.Drawing.Point(165, 116)
        Me.TelNo_ShortText10TextBox.Name = "TelNo_ShortText10TextBox"
        Me.TelNo_ShortText10TextBox.Size = New System.Drawing.Size(457, 26)
        Me.TelNo_ShortText10TextBox.TabIndex = 43
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 93)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(119, 20)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Contact Person"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 215)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 20)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Street No."
        '
        'ManufacturerPartNoLabel
        '
        Me.ManufacturerPartNoLabel.AutoSize = True
        Me.ManufacturerPartNoLabel.Location = New System.Drawing.Point(18, 122)
        Me.ManufacturerPartNoLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.ManufacturerPartNoLabel.Name = "ManufacturerPartNoLabel"
        Me.ManufacturerPartNoLabel.Size = New System.Drawing.Size(90, 20)
        Me.ManufacturerPartNoLabel.TabIndex = 40
        Me.ManufacturerPartNoLabel.Text = "Tel Number"
        '
        'SuppliersDataGridView
        '
        Me.SuppliersDataGridView.AllowUserToAddRows = False
        Me.SuppliersDataGridView.AllowUserToDeleteRows = False
        Me.SuppliersDataGridView.AllowUserToResizeRows = False
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuppliersDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.SuppliersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.SuppliersDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuppliersDataGridView.Location = New System.Drawing.Point(3, 22)
        Me.SuppliersDataGridView.Margin = New System.Windows.Forms.Padding(10, 12, 10, 12)
        Me.SuppliersDataGridView.Name = "SuppliersDataGridView"
        Me.SuppliersDataGridView.ReadOnly = True
        Me.SuppliersDataGridView.RowHeadersVisible = False
        Me.SuppliersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.SuppliersDataGridView.Size = New System.Drawing.Size(445, 319)
        Me.SuppliersDataGridView.TabIndex = 90
        '
        'SuppliersGroupBox
        '
        Me.SuppliersGroupBox.Controls.Add(Me.SuppliersDataGridView)
        Me.SuppliersGroupBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuppliersGroupBox.Location = New System.Drawing.Point(12, 39)
        Me.SuppliersGroupBox.Name = "SuppliersGroupBox"
        Me.SuppliersGroupBox.Size = New System.Drawing.Size(451, 344)
        Me.SuppliersGroupBox.TabIndex = 107
        Me.SuppliersGroupBox.TabStop = False
        Me.SuppliersGroupBox.Text = "Supplierss"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(18, 373)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 20)
        Me.Label8.TabIndex = 61
        Me.Label8.Text = "Zip Code"
        '
        'ZipCode_ShortText9TextBox
        '
        Me.ZipCode_ShortText9TextBox.Location = New System.Drawing.Point(165, 370)
        Me.ZipCode_ShortText9TextBox.Name = "ZipCode_ShortText9TextBox"
        Me.ZipCode_ShortText9TextBox.Size = New System.Drawing.Size(209, 26)
        Me.ZipCode_ShortText9TextBox.TabIndex = 60
        '
        'SupplierName_ShortText35TextBox
        '
        Me.SupplierName_ShortText35TextBox.Enabled = False
        Me.SupplierName_ShortText35TextBox.Location = New System.Drawing.Point(165, 58)
        Me.SupplierName_ShortText35TextBox.Name = "SupplierName_ShortText35TextBox"
        Me.SupplierName_ShortText35TextBox.Size = New System.Drawing.Size(457, 26)
        Me.SupplierName_ShortText35TextBox.TabIndex = 63
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(18, 64)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 20)
        Me.Label9.TabIndex = 62
        Me.Label9.Text = "Supplier"
        '
        'SuppliersForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1303, 692)
        Me.Controls.Add(Me.SuppliersGroupBox)
        Me.Controls.Add(Me.SupplierDetailsGroup)
        Me.Controls.Add(Me.SupplierssPartsMenuStrip)
        Me.Controls.Add(Me.ActivatedByTextBox)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "SuppliersForm"
        Me.Text = "Form1"
        Me.SupplierssPartsMenuStrip.ResumeLayout(False)
        Me.SupplierssPartsMenuStrip.PerformLayout()
        Me.SupplierDetailsGroup.ResumeLayout(False)
        Me.SupplierDetailsGroup.PerformLayout()
        CType(Me.SuppliersDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuppliersGroupBox.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ActivatedByTextBox As TextBox
    Friend WithEvents SupplierssPartsMenuStrip As MenuStrip
    Friend WithEvents CancelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents SelectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SearchSupplierToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SearchDescriptionToolStripTextBox As ToolStripTextBox
    Friend WithEvents SupplierDetailsGroup As GroupBox
    Friend WithEvents CityID_LongIntegerTextBox As MaskedTextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents StateProvName_ShortText25TextBox As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ContactPerson_ShortText30TextBox As TextBox
    Friend WithEvents Street_ShortText25TextBox As TextBox
    Friend WithEvents TelNo_ShortText10TextBox As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ManufacturerPartNoLabel As Label
    Friend WithEvents SuppliersDataGridView As DataGridView
    Friend WithEvents SuppliersGroupBox As GroupBox
    Friend WithEvents BldgAptRmNo_ShortText25TextBox As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents CountryName_ShortText25TextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents EmailAddress_ShortText20TextBox As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents ZipCode_ShortText9TextBox As TextBox
    Friend WithEvents SupplierName_ShortText35TextBox As TextBox
    Friend WithEvents Label9 As Label
End Class
