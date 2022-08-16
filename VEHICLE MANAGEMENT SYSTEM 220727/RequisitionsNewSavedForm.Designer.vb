<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RequisitionsNewSavedForm
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
        Me.WorkOrderJobsDataGridView = New System.Windows.Forms.DataGridView()
        Me.VehicleNameButton = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.RequisitionsDataGridView = New System.Windows.Forms.DataGridView()
        Me.RequisitionDetailsGroupBox = New System.Windows.Forms.GroupBox()
        Me.RequisionRevisionTextBox = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.AllJOBSButton = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.WorkOrderJobTextBox = New System.Windows.Forms.TextBox()
        Me.RequisitionNumberTextBox = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.WorkOrderNumberTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.RequisitionItemsDataGridView = New System.Windows.Forms.DataGridView()
        Me.RequisitionDateTimeTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ActivatedByTextBox = New System.Windows.Forms.TextBox()
        Me.PurchaseOrdersMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.ReturnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RequisitionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SavePurchaseOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RequisitionDetailsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OutstandingRequisitionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CompletedRequisitionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllRequisitionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.WorkOrderJobsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RequisitionsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RequisitionDetailsGroupBox.SuspendLayout()
        CType(Me.RequisitionItemsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PurchaseOrdersMenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'WorkOrderJobsDataGridView
        '
        Me.WorkOrderJobsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.WorkOrderJobsDataGridView.Location = New System.Drawing.Point(-351, -16)
        Me.WorkOrderJobsDataGridView.Name = "WorkOrderJobsDataGridView"
        Me.WorkOrderJobsDataGridView.Size = New System.Drawing.Size(240, 150)
        Me.WorkOrderJobsDataGridView.TabIndex = 88
        '
        'VehicleNameButton
        '
        Me.VehicleNameButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VehicleNameButton.Location = New System.Drawing.Point(-364, -58)
        Me.VehicleNameButton.Name = "VehicleNameButton"
        Me.VehicleNameButton.Size = New System.Drawing.Size(449, 31)
        Me.VehicleNameButton.TabIndex = 92
        Me.VehicleNameButton.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(-327, 8)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(240, 150)
        Me.DataGridView1.TabIndex = 91
        '
        'RequisitionsDataGridView
        '
        Me.RequisitionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.RequisitionsDataGridView.Location = New System.Drawing.Point(12, 34)
        Me.RequisitionsDataGridView.Name = "RequisitionsDataGridView"
        Me.RequisitionsDataGridView.Size = New System.Drawing.Size(240, 150)
        Me.RequisitionsDataGridView.TabIndex = 95
        '
        'RequisitionDetailsGroupBox
        '
        Me.RequisitionDetailsGroupBox.BackColor = System.Drawing.Color.YellowGreen
        Me.RequisitionDetailsGroupBox.Controls.Add(Me.RequisionRevisionTextBox)
        Me.RequisitionDetailsGroupBox.Controls.Add(Me.Button2)
        Me.RequisitionDetailsGroupBox.Controls.Add(Me.AllJOBSButton)
        Me.RequisitionDetailsGroupBox.Controls.Add(Me.Label3)
        Me.RequisitionDetailsGroupBox.Controls.Add(Me.WorkOrderJobTextBox)
        Me.RequisitionDetailsGroupBox.Controls.Add(Me.RequisitionNumberTextBox)
        Me.RequisitionDetailsGroupBox.Controls.Add(Me.Label13)
        Me.RequisitionDetailsGroupBox.Controls.Add(Me.WorkOrderNumberTextBox)
        Me.RequisitionDetailsGroupBox.Controls.Add(Me.Label2)
        Me.RequisitionDetailsGroupBox.Controls.Add(Me.RequisitionItemsDataGridView)
        Me.RequisitionDetailsGroupBox.Controls.Add(Me.RequisitionDateTimeTextBox)
        Me.RequisitionDetailsGroupBox.Controls.Add(Me.Label1)
        Me.RequisitionDetailsGroupBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RequisitionDetailsGroupBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.RequisitionDetailsGroupBox.Location = New System.Drawing.Point(317, 45)
        Me.RequisitionDetailsGroupBox.Name = "RequisitionDetailsGroupBox"
        Me.RequisitionDetailsGroupBox.Size = New System.Drawing.Size(1085, 615)
        Me.RequisitionDetailsGroupBox.TabIndex = 94
        Me.RequisitionDetailsGroupBox.TabStop = False
        Me.RequisitionDetailsGroupBox.Text = "Details"
        '
        'RequisionRevisionTextBox
        '
        Me.RequisionRevisionTextBox.Location = New System.Drawing.Point(546, 29)
        Me.RequisionRevisionTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RequisionRevisionTextBox.Name = "RequisionRevisionTextBox"
        Me.RequisionRevisionTextBox.Size = New System.Drawing.Size(18, 26)
        Me.RequisionRevisionTextBox.TabIndex = 89
        Me.RequisionRevisionTextBox.Text = "0"
        '
        'Button2
        '
        Me.Button2.ForeColor = System.Drawing.Color.BlueViolet
        Me.Button2.Location = New System.Drawing.Point(464, 29)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 26)
        Me.Button2.TabIndex = 88
        Me.Button2.Text = "rev "
        Me.Button2.UseVisualStyleBackColor = True
        '
        'AllJOBSButton
        '
        Me.AllJOBSButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AllJOBSButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.AllJOBSButton.Location = New System.Drawing.Point(20, 133)
        Me.AllJOBSButton.Name = "AllJOBSButton"
        Me.AllJOBSButton.Size = New System.Drawing.Size(97, 30)
        Me.AllJOBSButton.TabIndex = 87
        Me.AllJOBSButton.Text = "(All jobs)"
        Me.AllJOBSButton.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(191, 141)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 20)
        Me.Label3.TabIndex = 86
        Me.Label3.Text = "Job"
        '
        'WorkOrderJobTextBox
        '
        Me.WorkOrderJobTextBox.Location = New System.Drawing.Point(289, 135)
        Me.WorkOrderJobTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.WorkOrderJobTextBox.Name = "WorkOrderJobTextBox"
        Me.WorkOrderJobTextBox.Size = New System.Drawing.Size(533, 26)
        Me.WorkOrderJobTextBox.TabIndex = 85
        '
        'RequisitionNumberTextBox
        '
        Me.RequisitionNumberTextBox.Location = New System.Drawing.Point(289, 29)
        Me.RequisitionNumberTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RequisitionNumberTextBox.Name = "RequisitionNumberTextBox"
        Me.RequisitionNumberTextBox.Size = New System.Drawing.Size(168, 26)
        Me.RequisitionNumberTextBox.TabIndex = 81
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(16, 102)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(150, 20)
        Me.Label13.TabIndex = 78
        Me.Label13.Text = "Work Order Number"
        '
        'WorkOrderNumberTextBox
        '
        Me.WorkOrderNumberTextBox.Location = New System.Drawing.Point(289, 102)
        Me.WorkOrderNumberTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.WorkOrderNumberTextBox.Name = "WorkOrderNumberTextBox"
        Me.WorkOrderNumberTextBox.Size = New System.Drawing.Size(212, 26)
        Me.WorkOrderNumberTextBox.TabIndex = 76
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(127, 20)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "Requisition Date"
        '
        'RequisitionItemsDataGridView
        '
        Me.RequisitionItemsDataGridView.AllowUserToAddRows = False
        Me.RequisitionItemsDataGridView.AllowUserToDeleteRows = False
        Me.RequisitionItemsDataGridView.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.RequisitionItemsDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.RequisitionItemsDataGridView.BackgroundColor = System.Drawing.SystemColors.Control
        Me.RequisitionItemsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.RequisitionItemsDataGridView.Location = New System.Drawing.Point(40, 212)
        Me.RequisitionItemsDataGridView.Margin = New System.Windows.Forms.Padding(7, 8, 7, 8)
        Me.RequisitionItemsDataGridView.Name = "RequisitionItemsDataGridView"
        Me.RequisitionItemsDataGridView.ReadOnly = True
        Me.RequisitionItemsDataGridView.RowHeadersVisible = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.RequisitionItemsDataGridView.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.RequisitionItemsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.RequisitionItemsDataGridView.Size = New System.Drawing.Size(958, 364)
        Me.RequisitionItemsDataGridView.TabIndex = 77
        '
        'RequisitionDateTimeTextBox
        '
        Me.RequisitionDateTimeTextBox.Location = New System.Drawing.Point(289, 60)
        Me.RequisitionDateTimeTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RequisitionDateTimeTextBox.Name = "RequisitionDateTimeTextBox"
        Me.RequisitionDateTimeTextBox.Size = New System.Drawing.Size(297, 26)
        Me.RequisitionDateTimeTextBox.TabIndex = 55
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(148, 20)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "Requisition Number"
        '
        'ActivatedByTextBox
        '
        Me.ActivatedByTextBox.Location = New System.Drawing.Point(122, 552)
        Me.ActivatedByTextBox.Margin = New System.Windows.Forms.Padding(5)
        Me.ActivatedByTextBox.Name = "ActivatedByTextBox"
        Me.ActivatedByTextBox.Size = New System.Drawing.Size(105, 20)
        Me.ActivatedByTextBox.TabIndex = 98
        Me.ActivatedByTextBox.Text = "ActivatedByTextBox"
        Me.ActivatedByTextBox.Visible = False
        '
        'PurchaseOrdersMenuStrip
        '
        Me.PurchaseOrdersMenuStrip.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PurchaseOrdersMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReturnToolStripMenuItem, Me.RequisitionsToolStripMenuItem, Me.ToolStripMenuItem1, Me.SavePurchaseOrderToolStripMenuItem, Me.ViewToolStripMenuItem1, Me.ToolStripMenuItem2})
        Me.PurchaseOrdersMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.PurchaseOrdersMenuStrip.Name = "PurchaseOrdersMenuStrip"
        Me.PurchaseOrdersMenuStrip.Padding = New System.Windows.Forms.Padding(10, 3, 0, 3)
        Me.PurchaseOrdersMenuStrip.Size = New System.Drawing.Size(1427, 31)
        Me.PurchaseOrdersMenuStrip.TabIndex = 99
        Me.PurchaseOrdersMenuStrip.Text = "MenuStrip1"
        '
        'ReturnToolStripMenuItem
        '
        Me.ReturnToolStripMenuItem.Name = "ReturnToolStripMenuItem"
        Me.ReturnToolStripMenuItem.Size = New System.Drawing.Size(40, 25)
        Me.ReturnToolStripMenuItem.Text = "◄ "
        '
        'RequisitionsToolStripMenuItem
        '
        Me.RequisitionsToolStripMenuItem.Enabled = False
        Me.RequisitionsToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RequisitionsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.RequisitionsToolStripMenuItem.Name = "RequisitionsToolStripMenuItem"
        Me.RequisitionsToolStripMenuItem.Size = New System.Drawing.Size(140, 25)
        Me.RequisitionsToolStripMenuItem.Text = "REQUISITIONS :"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(12, 25)
        '
        'SavePurchaseOrderToolStripMenuItem
        '
        Me.SavePurchaseOrderToolStripMenuItem.Name = "SavePurchaseOrderToolStripMenuItem"
        Me.SavePurchaseOrderToolStripMenuItem.Size = New System.Drawing.Size(55, 25)
        Me.SavePurchaseOrderToolStripMenuItem.Text = "Save"
        '
        'ViewToolStripMenuItem1
        '
        Me.ViewToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RequisitionDetailsToolStripMenuItem1, Me.OutstandingRequisitionsToolStripMenuItem, Me.CompletedRequisitionsToolStripMenuItem, Me.AllRequisitionsToolStripMenuItem})
        Me.ViewToolStripMenuItem1.Name = "ViewToolStripMenuItem1"
        Me.ViewToolStripMenuItem1.Size = New System.Drawing.Size(56, 25)
        Me.ViewToolStripMenuItem1.Text = "View"
        '
        'RequisitionDetailsToolStripMenuItem1
        '
        Me.RequisitionDetailsToolStripMenuItem1.Name = "RequisitionDetailsToolStripMenuItem1"
        Me.RequisitionDetailsToolStripMenuItem1.Size = New System.Drawing.Size(300, 26)
        Me.RequisitionDetailsToolStripMenuItem1.Text = "Requisition Details"
        '
        'OutstandingRequisitionsToolStripMenuItem
        '
        Me.OutstandingRequisitionsToolStripMenuItem.Name = "OutstandingRequisitionsToolStripMenuItem"
        Me.OutstandingRequisitionsToolStripMenuItem.Size = New System.Drawing.Size(300, 26)
        Me.OutstandingRequisitionsToolStripMenuItem.Text = "Outstanding Requisition Orders"
        '
        'CompletedRequisitionsToolStripMenuItem
        '
        Me.CompletedRequisitionsToolStripMenuItem.Name = "CompletedRequisitionsToolStripMenuItem"
        Me.CompletedRequisitionsToolStripMenuItem.Size = New System.Drawing.Size(300, 26)
        Me.CompletedRequisitionsToolStripMenuItem.Text = "Completed Requisitions"
        '
        'AllRequisitionsToolStripMenuItem
        '
        Me.AllRequisitionsToolStripMenuItem.Name = "AllRequisitionsToolStripMenuItem"
        Me.AllRequisitionsToolStripMenuItem.Size = New System.Drawing.Size(300, 26)
        Me.AllRequisitionsToolStripMenuItem.Text = "All Requisitions"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Enabled = False
        Me.ToolStripMenuItem2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripMenuItem2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(221, 25)
        Me.ToolStripMenuItem2.Text = "PURCHASE ORDER ITEMS :"
        '
        'RequisitionsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1427, 759)
        Me.Controls.Add(Me.PurchaseOrdersMenuStrip)
        Me.Controls.Add(Me.ActivatedByTextBox)
        Me.Controls.Add(Me.RequisitionsDataGridView)
        Me.Controls.Add(Me.RequisitionDetailsGroupBox)
        Me.Controls.Add(Me.VehicleNameButton)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.WorkOrderJobsDataGridView)
        Me.Name = "RequisitionsForm"
        Me.Text = "RequisitionsForm"
        CType(Me.WorkOrderJobsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RequisitionsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RequisitionDetailsGroupBox.ResumeLayout(False)
        Me.RequisitionDetailsGroupBox.PerformLayout()
        CType(Me.RequisitionItemsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PurchaseOrdersMenuStrip.ResumeLayout(False)
        Me.PurchaseOrdersMenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents WorkOrderJobsDataGridView As DataGridView
    Friend WithEvents VehicleNameButton As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents RequisitionsDataGridView As DataGridView
    Friend WithEvents RequisitionDetailsGroupBox As GroupBox
    Friend WithEvents RequisionRevisionTextBox As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents AllJOBSButton As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents WorkOrderJobTextBox As TextBox
    Friend WithEvents RequisitionNumberTextBox As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents WorkOrderNumberTextBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents RequisitionItemsDataGridView As DataGridView
    Friend WithEvents RequisitionDateTimeTextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ActivatedByTextBox As TextBox
    Friend WithEvents PurchaseOrdersMenuStrip As MenuStrip
    Friend WithEvents ReturnToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RequisitionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents SavePurchaseOrderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents RequisitionDetailsToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents OutstandingRequisitionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CompletedRequisitionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AllRequisitionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
End Class
