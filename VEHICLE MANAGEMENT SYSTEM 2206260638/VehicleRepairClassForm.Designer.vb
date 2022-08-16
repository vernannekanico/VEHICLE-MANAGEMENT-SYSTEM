<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class VehicleRepairClassForm
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.CancelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmployeeDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VehicleRepairClassDataGridView = New System.Windows.Forms.DataGridView()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.SearchVehicleTypeTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.SearchVehicleModelTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.VehicleRepairClassDetailsGroupBox = New System.Windows.Forms.GroupBox()
        Me.YearManufacturedFromTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.YearManufacturedToTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.VehicleRepairClassDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.VehicleRepairClassDetailsGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CancelToolStripMenuItem, Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.SelectToolStripMenuItem, Me.ViewToolStripMenuItem, Me.ToolStripMenuItem1, Me.SaveToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(9, 3, 0, 3)
        Me.MenuStrip1.Size = New System.Drawing.Size(1157, 31)
        Me.MenuStrip1.TabIndex = 52
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'CancelToolStripMenuItem
        '
        Me.CancelToolStripMenuItem.Name = "CancelToolStripMenuItem"
        Me.CancelToolStripMenuItem.Size = New System.Drawing.Size(40, 25)
        Me.CancelToolStripMenuItem.Text = "◄ "
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
        'SelectToolStripMenuItem
        '
        Me.SelectToolStripMenuItem.Name = "SelectToolStripMenuItem"
        Me.SelectToolStripMenuItem.Size = New System.Drawing.Size(63, 25)
        Me.SelectToolStripMenuItem.Text = "Select"
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
        Me.EmployeeDetailsToolStripMenuItem.Size = New System.Drawing.Size(220, 26)
        Me.EmployeeDetailsToolStripMenuItem.Text = "Repair Class D etails"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(12, 25)
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(55, 25)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'VehicleRepairClassDataGridView
        '
        Me.VehicleRepairClassDataGridView.AllowUserToAddRows = False
        Me.VehicleRepairClassDataGridView.ColumnHeadersHeight = 26
        Me.VehicleRepairClassDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.VehicleRepairClassDataGridView.Location = New System.Drawing.Point(9, 59)
        Me.VehicleRepairClassDataGridView.Margin = New System.Windows.Forms.Padding(9, 12, 9, 12)
        Me.VehicleRepairClassDataGridView.Name = "VehicleRepairClassDataGridView"
        Me.VehicleRepairClassDataGridView.ReadOnly = True
        Me.VehicleRepairClassDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.VehicleRepairClassDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.VehicleRepairClassDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.VehicleRepairClassDataGridView.Size = New System.Drawing.Size(279, 220)
        Me.VehicleRepairClassDataGridView.TabIndex = 51
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel2, Me.ToolStripSeparator1, Me.ToolStripLabel1, Me.SearchVehicleTypeTextBox, Me.ToolStripLabel3, Me.SearchVehicleModelTextBox})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 31)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1157, 28)
        Me.ToolStrip1.TabIndex = 54
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(54, 25)
        Me.ToolStripLabel2.Text = "Filter"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 28)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(31, 25)
        Me.ToolStripLabel1.Text = "Type"
        '
        'SearchVehicleTypeTextBox
        '
        Me.SearchVehicleTypeTextBox.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.SearchVehicleTypeTextBox.Name = "SearchVehicleTypeTextBox"
        Me.SearchVehicleTypeTextBox.Size = New System.Drawing.Size(100, 28)
        Me.SearchVehicleTypeTextBox.Text = "Search"
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(41, 25)
        Me.ToolStripLabel3.Text = "Model"
        '
        'SearchVehicleModelTextBox
        '
        Me.SearchVehicleModelTextBox.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.SearchVehicleModelTextBox.Name = "SearchVehicleModelTextBox"
        Me.SearchVehicleModelTextBox.Size = New System.Drawing.Size(100, 28)
        Me.SearchVehicleModelTextBox.Text = "Search"
        '
        'VehicleRepairClassDetailsGroupBox
        '
        Me.VehicleRepairClassDetailsGroupBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VehicleRepairClassDetailsGroupBox.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.VehicleRepairClassDetailsGroupBox.Controls.Add(Me.YearManufacturedFromTextBox)
        Me.VehicleRepairClassDetailsGroupBox.Controls.Add(Me.Label2)
        Me.VehicleRepairClassDetailsGroupBox.Controls.Add(Me.YearManufacturedToTextBox)
        Me.VehicleRepairClassDetailsGroupBox.Controls.Add(Me.Label1)
        Me.VehicleRepairClassDetailsGroupBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.VehicleRepairClassDetailsGroupBox.Location = New System.Drawing.Point(347, 77)
        Me.VehicleRepairClassDetailsGroupBox.Name = "VehicleRepairClassDetailsGroupBox"
        Me.VehicleRepairClassDetailsGroupBox.Size = New System.Drawing.Size(712, 266)
        Me.VehicleRepairClassDetailsGroupBox.TabIndex = 82
        Me.VehicleRepairClassDetailsGroupBox.TabStop = False
        Me.VehicleRepairClassDetailsGroupBox.Text = "Repair Range"
        Me.VehicleRepairClassDetailsGroupBox.Visible = False
        '
        'YearManufacturedFromTextBox
        '
        Me.YearManufacturedFromTextBox.Location = New System.Drawing.Point(297, 32)
        Me.YearManufacturedFromTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.YearManufacturedFromTextBox.Name = "YearManufacturedFromTextBox"
        Me.YearManufacturedFromTextBox.Size = New System.Drawing.Size(330, 26)
        Me.YearManufacturedFromTextBox.TabIndex = 81
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(247, 20)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "YearManufacturedTo_ShortText4"
        '
        'YearManufacturedToTextBox
        '
        Me.YearManufacturedToTextBox.Location = New System.Drawing.Point(297, 60)
        Me.YearManufacturedToTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.YearManufacturedToTextBox.Name = "YearManufacturedToTextBox"
        Me.YearManufacturedToTextBox.Size = New System.Drawing.Size(330, 26)
        Me.YearManufacturedToTextBox.TabIndex = 55
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(266, 20)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "YearManufacturedFrom_ShortText4"
        '
        'VehicleRepairClassForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1157, 737)
        Me.Controls.Add(Me.VehicleRepairClassDetailsGroupBox)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.VehicleRepairClassDataGridView)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "VehicleRepairClassForm"
        Me.Text = "VehicleRepairClassForm"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.VehicleRepairClassDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.VehicleRepairClassDetailsGroupBox.ResumeLayout(False)
        Me.VehicleRepairClassDetailsGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents CancelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents VehicleRepairClassDataGridView As DataGridView
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents SearchVehicleTypeTextBox As ToolStripTextBox
    Friend WithEvents ToolStripLabel3 As ToolStripLabel
    Friend WithEvents SearchVehicleModelTextBox As ToolStripTextBox
    Friend WithEvents VehicleRepairClassDetailsGroupBox As GroupBox
    Friend WithEvents YearManufacturedFromTextBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents YearManufacturedToTextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EmployeeDetailsToolStripMenuItem As ToolStripMenuItem
End Class
