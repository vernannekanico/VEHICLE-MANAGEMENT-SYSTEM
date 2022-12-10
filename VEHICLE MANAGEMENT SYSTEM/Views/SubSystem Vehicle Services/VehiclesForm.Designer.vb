<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class VehiclesForm
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
        Me.VehicleDetailsDataGridView = New System.Windows.Forms.DataGridView()
        Me.SearchToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.SearchVehicleTypeTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.SearchVehicleModelTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.YearSearchTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.VehiclesMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.ReturnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VehicleDetailsDetailsGroupBox = New System.Windows.Forms.GroupBox()
        Me.VehicleRepairClassTextBox = New System.Windows.Forms.TextBox()
        Me.RepairYearRangeButton = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.YearManufacturedToTextBox = New System.Windows.Forms.TextBox()
        Me.YearManufacturedFromTextBox = New System.Windows.Forms.TextBox()
        Me.VehicleMakeTextBox = New System.Windows.Forms.TextBox()
        Me.VehicleModelTextBox = New System.Windows.Forms.TextBox()
        Me.FuelTypeTextBox = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.EngineSeriesTextBox = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BodyTypeTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.EngineTypeTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.VehicleTrimTextBox = New System.Windows.Forms.TextBox()
        Me.label = New System.Windows.Forms.Label()
        Me.YearManufacturedTextBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.VehicleDetailsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SearchToolStrip.SuspendLayout()
        Me.VehiclesMenuStrip.SuspendLayout()
        Me.VehicleDetailsDetailsGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'VehicleDetailsDataGridView
        '
        Me.VehicleDetailsDataGridView.AllowUserToAddRows = False
        Me.VehicleDetailsDataGridView.ColumnHeadersHeight = 26
        Me.VehicleDetailsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.VehicleDetailsDataGridView.Location = New System.Drawing.Point(0, 53)
        Me.VehicleDetailsDataGridView.Margin = New System.Windows.Forms.Padding(9, 12, 9, 12)
        Me.VehicleDetailsDataGridView.Name = "VehicleDetailsDataGridView"
        Me.VehicleDetailsDataGridView.ReadOnly = True
        Me.VehicleDetailsDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.VehicleDetailsDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.VehicleDetailsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.VehicleDetailsDataGridView.Size = New System.Drawing.Size(277, 174)
        Me.VehicleDetailsDataGridView.TabIndex = 51
        '
        'SearchToolStrip
        '
        Me.SearchToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.SearchVehicleTypeTextBox, Me.ToolStripSeparator1, Me.ToolStripLabel2, Me.SearchVehicleModelTextBox, Me.ToolStripLabel3, Me.YearSearchTextBox})
        Me.SearchToolStrip.Location = New System.Drawing.Point(0, 25)
        Me.SearchToolStrip.Name = "SearchToolStrip"
        Me.SearchToolStrip.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.SearchToolStrip.Size = New System.Drawing.Size(988, 26)
        Me.SearchToolStrip.TabIndex = 50
        Me.SearchToolStrip.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(31, 23)
        Me.ToolStripLabel1.Text = "Type"
        '
        'SearchVehicleTypeTextBox
        '
        Me.SearchVehicleTypeTextBox.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.SearchVehicleTypeTextBox.Name = "SearchVehicleTypeTextBox"
        Me.SearchVehicleTypeTextBox.Size = New System.Drawing.Size(298, 26)
        Me.SearchVehicleTypeTextBox.Text = "Search"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 26)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(41, 23)
        Me.ToolStripLabel2.Text = "Model"
        '
        'SearchVehicleModelTextBox
        '
        Me.SearchVehicleModelTextBox.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.SearchVehicleModelTextBox.Name = "SearchVehicleModelTextBox"
        Me.SearchVehicleModelTextBox.Size = New System.Drawing.Size(148, 26)
        Me.SearchVehicleModelTextBox.Text = "Search"
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(29, 23)
        Me.ToolStripLabel3.Text = "Year"
        '
        'YearSearchTextBox
        '
        Me.YearSearchTextBox.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.YearSearchTextBox.Name = "YearSearchTextBox"
        Me.YearSearchTextBox.Size = New System.Drawing.Size(100, 26)
        '
        'VehiclesMenuStrip
        '
        Me.VehiclesMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReturnToolStripMenuItem, Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.SelectToolStripMenuItem, Me.ToolStripMenuItem1, Me.ViewToolStripMenuItem, Me.SaveToolStripMenuItem})
        Me.VehiclesMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.VehiclesMenuStrip.Name = "VehiclesMenuStrip"
        Me.VehiclesMenuStrip.Padding = New System.Windows.Forms.Padding(9, 3, 0, 3)
        Me.VehiclesMenuStrip.Size = New System.Drawing.Size(988, 25)
        Me.VehiclesMenuStrip.TabIndex = 49
        Me.VehiclesMenuStrip.Text = "MenuStrip1"
        '
        'ReturnToolStripMenuItem
        '
        Me.ReturnToolStripMenuItem.Name = "ReturnToolStripMenuItem"
        Me.ReturnToolStripMenuItem.Size = New System.Drawing.Size(32, 19)
        Me.ReturnToolStripMenuItem.Text = "◄ "
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(41, 19)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 19)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(52, 19)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'SelectToolStripMenuItem
        '
        Me.SelectToolStripMenuItem.Name = "SelectToolStripMenuItem"
        Me.SelectToolStripMenuItem.Size = New System.Drawing.Size(50, 19)
        Me.SelectToolStripMenuItem.Text = "Select"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(12, 19)
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(44, 19)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(43, 19)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'VehicleDetailsDetailsGroupBox
        '
        Me.VehicleDetailsDetailsGroupBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VehicleDetailsDetailsGroupBox.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.VehicleDetailsDetailsGroupBox.Controls.Add(Me.VehicleRepairClassTextBox)
        Me.VehicleDetailsDetailsGroupBox.Controls.Add(Me.RepairYearRangeButton)
        Me.VehicleDetailsDetailsGroupBox.Controls.Add(Me.Label9)
        Me.VehicleDetailsDetailsGroupBox.Controls.Add(Me.YearManufacturedToTextBox)
        Me.VehicleDetailsDetailsGroupBox.Controls.Add(Me.YearManufacturedFromTextBox)
        Me.VehicleDetailsDetailsGroupBox.Controls.Add(Me.VehicleMakeTextBox)
        Me.VehicleDetailsDetailsGroupBox.Controls.Add(Me.VehicleModelTextBox)
        Me.VehicleDetailsDetailsGroupBox.Controls.Add(Me.FuelTypeTextBox)
        Me.VehicleDetailsDetailsGroupBox.Controls.Add(Me.Label7)
        Me.VehicleDetailsDetailsGroupBox.Controls.Add(Me.EngineSeriesTextBox)
        Me.VehicleDetailsDetailsGroupBox.Controls.Add(Me.Label6)
        Me.VehicleDetailsDetailsGroupBox.Controls.Add(Me.BodyTypeTextBox)
        Me.VehicleDetailsDetailsGroupBox.Controls.Add(Me.Label2)
        Me.VehicleDetailsDetailsGroupBox.Controls.Add(Me.EngineTypeTextBox)
        Me.VehicleDetailsDetailsGroupBox.Controls.Add(Me.Label1)
        Me.VehicleDetailsDetailsGroupBox.Controls.Add(Me.VehicleTrimTextBox)
        Me.VehicleDetailsDetailsGroupBox.Controls.Add(Me.label)
        Me.VehicleDetailsDetailsGroupBox.Controls.Add(Me.YearManufacturedTextBox)
        Me.VehicleDetailsDetailsGroupBox.Controls.Add(Me.Label4)
        Me.VehicleDetailsDetailsGroupBox.Controls.Add(Me.Label3)
        Me.VehicleDetailsDetailsGroupBox.Controls.Add(Me.Label5)
        Me.VehicleDetailsDetailsGroupBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.VehicleDetailsDetailsGroupBox.Location = New System.Drawing.Point(295, 53)
        Me.VehicleDetailsDetailsGroupBox.Name = "VehicleDetailsDetailsGroupBox"
        Me.VehicleDetailsDetailsGroupBox.Size = New System.Drawing.Size(681, 350)
        Me.VehicleDetailsDetailsGroupBox.TabIndex = 82
        Me.VehicleDetailsDetailsGroupBox.TabStop = False
        Me.VehicleDetailsDetailsGroupBox.Text = "Vehicle Details"
        Me.VehicleDetailsDetailsGroupBox.Visible = False
        '
        'VehicleRepairClassTextBox
        '
        Me.VehicleRepairClassTextBox.Enabled = False
        Me.VehicleRepairClassTextBox.Location = New System.Drawing.Point(509, 25)
        Me.VehicleRepairClassTextBox.Name = "VehicleRepairClassTextBox"
        Me.VehicleRepairClassTextBox.Size = New System.Drawing.Size(68, 26)
        Me.VehicleRepairClassTextBox.TabIndex = 103
        '
        'RepairYearRangeButton
        '
        Me.RepairYearRangeButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.RepairYearRangeButton.Location = New System.Drawing.Point(448, 122)
        Me.RepairYearRangeButton.Name = "RepairYearRangeButton"
        Me.RepairYearRangeButton.Size = New System.Drawing.Size(197, 32)
        Me.RepairYearRangeButton.TabIndex = 102
        Me.RepairYearRangeButton.Text = "Repair Year Range"
        Me.RepairYearRangeButton.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(532, 175)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(23, 20)
        Me.Label9.TabIndex = 101
        Me.Label9.Text = "to"
        '
        'YearManufacturedToTextBox
        '
        Me.YearManufacturedToTextBox.Enabled = False
        Me.YearManufacturedToTextBox.Location = New System.Drawing.Point(577, 172)
        Me.YearManufacturedToTextBox.Name = "YearManufacturedToTextBox"
        Me.YearManufacturedToTextBox.Size = New System.Drawing.Size(68, 26)
        Me.YearManufacturedToTextBox.TabIndex = 100
        '
        'YearManufacturedFromTextBox
        '
        Me.YearManufacturedFromTextBox.Enabled = False
        Me.YearManufacturedFromTextBox.Location = New System.Drawing.Point(448, 169)
        Me.YearManufacturedFromTextBox.Name = "YearManufacturedFromTextBox"
        Me.YearManufacturedFromTextBox.Size = New System.Drawing.Size(68, 26)
        Me.YearManufacturedFromTextBox.TabIndex = 99
        '
        'VehicleMakeTextBox
        '
        Me.VehicleMakeTextBox.Enabled = False
        Me.VehicleMakeTextBox.Location = New System.Drawing.Point(172, 25)
        Me.VehicleMakeTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.VehicleMakeTextBox.Name = "VehicleMakeTextBox"
        Me.VehicleMakeTextBox.Size = New System.Drawing.Size(238, 26)
        Me.VehicleMakeTextBox.TabIndex = 98
        '
        'VehicleModelTextBox
        '
        Me.VehicleModelTextBox.Location = New System.Drawing.Point(172, 58)
        Me.VehicleModelTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.VehicleModelTextBox.Name = "VehicleModelTextBox"
        Me.VehicleModelTextBox.Size = New System.Drawing.Size(238, 26)
        Me.VehicleModelTextBox.TabIndex = 97
        '
        'FuelTypeTextBox
        '
        Me.FuelTypeTextBox.Location = New System.Drawing.Point(172, 285)
        Me.FuelTypeTextBox.Name = "FuelTypeTextBox"
        Me.FuelTypeTextBox.Size = New System.Drawing.Size(238, 26)
        Me.FuelTypeTextBox.TabIndex = 96
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(17, 290)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 20)
        Me.Label7.TabIndex = 95
        Me.Label7.Text = "FuelType"
        '
        'EngineSeriesTextBox
        '
        Me.EngineSeriesTextBox.Location = New System.Drawing.Point(172, 246)
        Me.EngineSeriesTextBox.Name = "EngineSeriesTextBox"
        Me.EngineSeriesTextBox.Size = New System.Drawing.Size(238, 26)
        Me.EngineSeriesTextBox.TabIndex = 94
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 251)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(108, 20)
        Me.Label6.TabIndex = 93
        Me.Label6.Text = "Engine Series"
        '
        'BodyTypeTextBox
        '
        Me.BodyTypeTextBox.Location = New System.Drawing.Point(172, 207)
        Me.BodyTypeTextBox.Name = "BodyTypeTextBox"
        Me.BodyTypeTextBox.Size = New System.Drawing.Size(238, 26)
        Me.BodyTypeTextBox.TabIndex = 92
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 212)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 20)
        Me.Label2.TabIndex = 91
        Me.Label2.Text = "BodyType"
        '
        'EngineTypeTextBox
        '
        Me.EngineTypeTextBox.Location = New System.Drawing.Point(172, 164)
        Me.EngineTypeTextBox.Name = "EngineTypeTextBox"
        Me.EngineTypeTextBox.Size = New System.Drawing.Size(238, 26)
        Me.EngineTypeTextBox.TabIndex = 90
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 169)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 20)
        Me.Label1.TabIndex = 89
        Me.Label1.Text = "Engine"
        '
        'VehicleTrimTextBox
        '
        Me.VehicleTrimTextBox.Enabled = False
        Me.VehicleTrimTextBox.Location = New System.Drawing.Point(172, 94)
        Me.VehicleTrimTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.VehicleTrimTextBox.Name = "VehicleTrimTextBox"
        Me.VehicleTrimTextBox.Size = New System.Drawing.Size(238, 26)
        Me.VehicleTrimTextBox.TabIndex = 88
        '
        'label
        '
        Me.label.AutoSize = True
        Me.label.Location = New System.Drawing.Point(11, 99)
        Me.label.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label.Name = "label"
        Me.label.Size = New System.Drawing.Size(39, 20)
        Me.label.TabIndex = 87
        Me.label.Text = "Trim"
        '
        'YearManufacturedTextBox
        '
        Me.YearManufacturedTextBox.Location = New System.Drawing.Point(172, 128)
        Me.YearManufacturedTextBox.Name = "YearManufacturedTextBox"
        Me.YearManufacturedTextBox.Size = New System.Drawing.Size(238, 26)
        Me.YearManufacturedTextBox.TabIndex = 85
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 134)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 20)
        Me.Label4.TabIndex = 84
        Me.Label4.Text = "Year"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 64)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 20)
        Me.Label3.TabIndex = 83
        Me.Label3.Text = "Model"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 27)
        Me.Label5.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 20)
        Me.Label5.TabIndex = 82
        Me.Label5.Text = "Make"
        '
        'VehiclesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(988, 397)
        Me.ControlBox = False
        Me.Controls.Add(Me.VehicleDetailsDetailsGroupBox)
        Me.Controls.Add(Me.VehicleDetailsDataGridView)
        Me.Controls.Add(Me.SearchToolStrip)
        Me.Controls.Add(Me.VehiclesMenuStrip)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "VehiclesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vehicles"
        CType(Me.VehicleDetailsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SearchToolStrip.ResumeLayout(False)
        Me.SearchToolStrip.PerformLayout()
        Me.VehiclesMenuStrip.ResumeLayout(False)
        Me.VehiclesMenuStrip.PerformLayout()
        Me.VehicleDetailsDetailsGroupBox.ResumeLayout(False)
        Me.VehicleDetailsDetailsGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents VehicleDetailsDataGridView As DataGridView
    Friend WithEvents SearchToolStrip As ToolStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents SearchVehicleTypeTextBox As ToolStripTextBox
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents SearchVehicleModelTextBox As ToolStripTextBox
    Friend WithEvents VehiclesMenuStrip As MenuStrip
    Friend WithEvents AddToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ReturnToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripLabel3 As ToolStripLabel
    Friend WithEvents YearSearchTextBox As ToolStripTextBox
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VehicleDetailsDetailsGroupBox As GroupBox
    Friend WithEvents VehicleRepairClassTextBox As TextBox
    Friend WithEvents RepairYearRangeButton As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents YearManufacturedToTextBox As TextBox
    Friend WithEvents YearManufacturedFromTextBox As TextBox
    Friend WithEvents VehicleMakeTextBox As TextBox
    Friend WithEvents VehicleModelTextBox As TextBox
    Friend WithEvents FuelTypeTextBox As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents EngineSeriesTextBox As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents BodyTypeTextBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents EngineTypeTextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents VehicleTrimTextBox As TextBox
    Friend WithEvents label As Label
    Friend WithEvents YearManufacturedTextBox As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
End Class
