<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MyStandardForm
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
        Me.MyStandardDetailsGroupBox = New System.Windows.Forms.GroupBox()
        Me.MyStandardNameTextBox = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.LinkedTextBox = New System.Windows.Forms.TextBox()
        Me.StateProvTextBox = New System.Windows.Forms.TextBox()
        Me.ZipCodeTextBox = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CountryTextBox = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MyStandardDateDateTimeTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SearchToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.SearchMyStandardTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.MyStandardsFormMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.ReturnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmployeeDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.MyStandardsGroupBox = New System.Windows.Forms.GroupBox()
        Me.MyStandardsDataGridView = New System.Windows.Forms.DataGridView()
        Me.MyStandardDetailsGroupBox.SuspendLayout()
        Me.SearchToolStrip.SuspendLayout()
        Me.MyStandardsFormMenuStrip.SuspendLayout()
        Me.MyStandardsGroupBox.SuspendLayout()
        CType(Me.MyStandardsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MyStandardDetailsGroupBox
        '
        Me.MyStandardDetailsGroupBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MyStandardDetailsGroupBox.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.MyStandardDetailsGroupBox.Controls.Add(Me.MyStandardNameTextBox)
        Me.MyStandardDetailsGroupBox.Controls.Add(Me.Label13)
        Me.MyStandardDetailsGroupBox.Controls.Add(Me.LinkedTextBox)
        Me.MyStandardDetailsGroupBox.Controls.Add(Me.StateProvTextBox)
        Me.MyStandardDetailsGroupBox.Controls.Add(Me.ZipCodeTextBox)
        Me.MyStandardDetailsGroupBox.Controls.Add(Me.Label11)
        Me.MyStandardDetailsGroupBox.Controls.Add(Me.Label10)
        Me.MyStandardDetailsGroupBox.Controls.Add(Me.CountryTextBox)
        Me.MyStandardDetailsGroupBox.Controls.Add(Me.Label9)
        Me.MyStandardDetailsGroupBox.Controls.Add(Me.Label2)
        Me.MyStandardDetailsGroupBox.Controls.Add(Me.MyStandardDateDateTimeTextBox)
        Me.MyStandardDetailsGroupBox.Controls.Add(Me.Label1)
        Me.MyStandardDetailsGroupBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.MyStandardDetailsGroupBox.Location = New System.Drawing.Point(341, 195)
        Me.MyStandardDetailsGroupBox.Name = "MyStandardDetailsGroupBox"
        Me.MyStandardDetailsGroupBox.Size = New System.Drawing.Size(624, 246)
        Me.MyStandardDetailsGroupBox.TabIndex = 81
        Me.MyStandardDetailsGroupBox.TabStop = False
        Me.MyStandardDetailsGroupBox.Text = "Details"
        Me.MyStandardDetailsGroupBox.Visible = False
        '
        'MyStandardNameTextBox
        '
        Me.MyStandardNameTextBox.Location = New System.Drawing.Point(256, 29)
        Me.MyStandardNameTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MyStandardNameTextBox.Name = "MyStandardNameTextBox"
        Me.MyStandardNameTextBox.Size = New System.Drawing.Size(330, 26)
        Me.MyStandardNameTextBox.TabIndex = 81
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(16, 102)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(222, 20)
        Me.Label13.TabIndex = 78
        Me.Label13.Text = "MyStadardID_LongInteger"
        '
        'LinkedTextBox
        '
        Me.LinkedTextBox.Location = New System.Drawing.Point(256, 102)
        Me.LinkedTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.LinkedTextBox.Name = "LinkedTextBox"
        Me.LinkedTextBox.Size = New System.Drawing.Size(245, 26)
        Me.LinkedTextBox.TabIndex = 76
        '
        'StateProvTextBox
        '
        Me.StateProvTextBox.Enabled = False
        Me.StateProvTextBox.Location = New System.Drawing.Point(256, 138)
        Me.StateProvTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.StateProvTextBox.Name = "StateProvTextBox"
        Me.StateProvTextBox.Size = New System.Drawing.Size(245, 26)
        Me.StateProvTextBox.TabIndex = 75
        '
        'ZipCodeTextBox
        '
        Me.ZipCodeTextBox.Enabled = False
        Me.ZipCodeTextBox.Location = New System.Drawing.Point(256, 171)
        Me.ZipCodeTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ZipCodeTextBox.Name = "ZipCodeTextBox"
        Me.ZipCodeTextBox.Size = New System.Drawing.Size(245, 26)
        Me.ZipCodeTextBox.TabIndex = 74
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(16, 177)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(81, 20)
        Me.Label11.TabIndex = 69
        Me.Label11.Text = "Zip Code"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 213)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(71, 20)
        Me.Label10.TabIndex = 68
        Me.Label10.Text = "Country"
        '
        'CountryTextBox
        '
        Me.CountryTextBox.Enabled = False
        Me.CountryTextBox.Location = New System.Drawing.Point(256, 207)
        Me.CountryTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CountryTextBox.Name = "CountryTextBox"
        Me.CountryTextBox.Size = New System.Drawing.Size(245, 26)
        Me.CountryTextBox.TabIndex = 67
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 141)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 20)
        Me.Label9.TabIndex = 66
        Me.Label9.Text = "State"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(231, 20)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "MyStandardDate_DateTime"
        '
        'MyStandardDateDateTimeTextBox
        '
        Me.MyStandardDateDateTimeTextBox.Location = New System.Drawing.Point(256, 60)
        Me.MyStandardDateDateTimeTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MyStandardDateDateTimeTextBox.Name = "MyStandardDateDateTimeTextBox"
        Me.MyStandardDateDateTimeTextBox.Size = New System.Drawing.Size(330, 26)
        Me.MyStandardDateDateTimeTextBox.TabIndex = 55
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(259, 20)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "MyStandardName_ShortText35"
        '
        'SearchToolStrip
        '
        Me.SearchToolStrip.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.SearchMyStandardTextBox})
        Me.SearchToolStrip.Location = New System.Drawing.Point(0, 31)
        Me.SearchToolStrip.Name = "SearchToolStrip"
        Me.SearchToolStrip.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.SearchToolStrip.Size = New System.Drawing.Size(1200, 29)
        Me.SearchToolStrip.TabIndex = 79
        Me.SearchToolStrip.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(35, 26)
        Me.ToolStripLabel1.Text = "Key"
        '
        'SearchMyStandardTextBox
        '
        Me.SearchMyStandardTextBox.Font = New System.Drawing.Font("Segoe UI", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchMyStandardTextBox.Name = "SearchMyStandardTextBox"
        Me.SearchMyStandardTextBox.Size = New System.Drawing.Size(300, 29)
        Me.SearchMyStandardTextBox.Text = "Search"
        '
        'MyStandardsFormMenuStrip
        '
        Me.MyStandardsFormMenuStrip.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyStandardsFormMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReturnToolStripMenuItem, Me.SelectToolStripMenuItem, Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.ToolStripMenuItem1, Me.ViewToolStripMenuItem, Me.SaveToolStripMenuItem})
        Me.MyStandardsFormMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MyStandardsFormMenuStrip.Name = "MyStandardsFormMenuStrip"
        Me.MyStandardsFormMenuStrip.Padding = New System.Windows.Forms.Padding(10, 3, 0, 3)
        Me.MyStandardsFormMenuStrip.Size = New System.Drawing.Size(1200, 31)
        Me.MyStandardsFormMenuStrip.TabIndex = 78
        Me.MyStandardsFormMenuStrip.Text = "MenuStrip1"
        '
        'ReturnToolStripMenuItem
        '
        Me.ReturnToolStripMenuItem.Name = "ReturnToolStripMenuItem"
        Me.ReturnToolStripMenuItem.Size = New System.Drawing.Size(40, 25)
        Me.ReturnToolStripMenuItem.Text = "◄ "
        '
        'SelectToolStripMenuItem
        '
        Me.SelectToolStripMenuItem.Name = "SelectToolStripMenuItem"
        Me.SelectToolStripMenuItem.Size = New System.Drawing.Size(63, 25)
        Me.SelectToolStripMenuItem.Text = "Select"
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
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EmployeeDetailsToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(56, 25)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'EmployeeDetailsToolStripMenuItem
        '
        Me.EmployeeDetailsToolStripMenuItem.Name = "EmployeeDetailsToolStripMenuItem"
        Me.EmployeeDetailsToolStripMenuItem.Size = New System.Drawing.Size(197, 26)
        Me.EmployeeDetailsToolStripMenuItem.Text = "Employee details"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(55, 25)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(328, 95)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(599, 35)
        Me.TextBox1.TabIndex = 82
        Me.TextBox1.Text = "SETUP NEW PAGE TO SIZE 12"
        '
        'MyStandardsGroupBox
        '
        Me.MyStandardsGroupBox.Controls.Add(Me.MyStandardsDataGridView)
        Me.MyStandardsGroupBox.Location = New System.Drawing.Point(30, 87)
        Me.MyStandardsGroupBox.Name = "MyStandardsGroupBox"
        Me.MyStandardsGroupBox.Size = New System.Drawing.Size(267, 173)
        Me.MyStandardsGroupBox.TabIndex = 83
        Me.MyStandardsGroupBox.TabStop = False
        Me.MyStandardsGroupBox.Text = "Work Orders"
        '
        'MyStandardsDataGridView
        '
        Me.MyStandardsDataGridView.AllowUserToAddRows = False
        Me.MyStandardsDataGridView.AllowUserToDeleteRows = False
        Me.MyStandardsDataGridView.AllowUserToOrderColumns = True
        Me.MyStandardsDataGridView.AllowUserToResizeRows = False
        Me.MyStandardsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.MyStandardsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MyStandardsDataGridView.Location = New System.Drawing.Point(3, 22)
        Me.MyStandardsDataGridView.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MyStandardsDataGridView.MultiSelect = False
        Me.MyStandardsDataGridView.Name = "MyStandardsDataGridView"
        Me.MyStandardsDataGridView.ReadOnly = True
        Me.MyStandardsDataGridView.RowHeadersVisible = False
        Me.MyStandardsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.MyStandardsDataGridView.Size = New System.Drawing.Size(261, 148)
        Me.MyStandardsDataGridView.TabIndex = 52
        '
        'MyStandardForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1200, 472)
        Me.ControlBox = False
        Me.Controls.Add(Me.MyStandardsGroupBox)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.MyStandardDetailsGroupBox)
        Me.Controls.Add(Me.SearchToolStrip)
        Me.Controls.Add(Me.MyStandardsFormMenuStrip)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MyStandardForm"
        Me.Text = "MyStandardForm"
        Me.MyStandardDetailsGroupBox.ResumeLayout(False)
        Me.MyStandardDetailsGroupBox.PerformLayout()
        Me.SearchToolStrip.ResumeLayout(False)
        Me.SearchToolStrip.PerformLayout()
        Me.MyStandardsFormMenuStrip.ResumeLayout(False)
        Me.MyStandardsFormMenuStrip.PerformLayout()
        Me.MyStandardsGroupBox.ResumeLayout(False)
        CType(Me.MyStandardsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MyStandardDetailsGroupBox As GroupBox
    Friend WithEvents MyStandardNameTextBox As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents LinkedTextBox As TextBox
    Friend WithEvents StateProvTextBox As TextBox
    Friend WithEvents ZipCodeTextBox As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents CountryTextBox As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents MyStandardDateDateTimeTextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents SearchToolStrip As ToolStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents SearchMyStandardTextBox As ToolStripTextBox
    Friend WithEvents MyStandardsFormMenuStrip As MenuStrip
    Friend WithEvents ReturnToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EmployeeDetailsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents MyStandardsGroupBox As GroupBox
    Friend WithEvents MyStandardsDataGridView As DataGridView
End Class
