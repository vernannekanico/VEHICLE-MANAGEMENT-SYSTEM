<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class WorkOrderForm
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.WorkOrdersDataGridView = New System.Windows.Forms.DataGridView()
        Me.WorkOrderConcernsDataGridView = New System.Windows.Forms.DataGridView()
        Me.ActivatedBy = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.CancelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WorkOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddWorkOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditWorkOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteWorkOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintWorkOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SubmitForServiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FinalizeToolStripMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveWorkOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AssignWorkOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WorkOrderDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OutstandingWorkOrdersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ForFinalizationBillingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CompletedWorkOrdersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllWorkOrdersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConcernsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddWorkOrderConcernToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveConcernToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.WorkOrderDetailsGroup = New System.Windows.Forms.GroupBox()
        Me.MilageMaskedTextBox = New System.Windows.Forms.MaskedTextBox()
        Me.VINTextBox = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.VehicleDetailsTextBox = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CustomerTextBox = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DateTimeOutTextBox = New System.Windows.Forms.TextBox()
        Me.ServiceDate_DateTimeTextBox = New System.Windows.Forms.TextBox()
        Me.WorkOrderNumberTextBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.WorkOrdersDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WorkOrderConcernsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.WorkOrderDetailsGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        'WorkOrdersDataGridView
        '
        Me.WorkOrdersDataGridView.AllowUserToAddRows = False
        Me.WorkOrdersDataGridView.AllowUserToDeleteRows = False
        Me.WorkOrdersDataGridView.AllowUserToOrderColumns = True
        Me.WorkOrdersDataGridView.AllowUserToResizeRows = False
        Me.WorkOrdersDataGridView.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.WorkOrdersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.WorkOrdersDataGridView.DefaultCellStyle = DataGridViewCellStyle5
        Me.WorkOrdersDataGridView.Location = New System.Drawing.Point(716, 74)
        Me.WorkOrdersDataGridView.MultiSelect = False
        Me.WorkOrdersDataGridView.Name = "WorkOrdersDataGridView"
        Me.WorkOrdersDataGridView.ReadOnly = True
        Me.WorkOrdersDataGridView.RowHeadersVisible = False
        Me.WorkOrdersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.WorkOrdersDataGridView.Size = New System.Drawing.Size(465, 202)
        Me.WorkOrdersDataGridView.TabIndex = 5
        '
        'WorkOrderConcernsDataGridView
        '
        Me.WorkOrderConcernsDataGridView.AllowUserToAddRows = False
        Me.WorkOrderConcernsDataGridView.AllowUserToDeleteRows = False
        Me.WorkOrderConcernsDataGridView.AllowUserToOrderColumns = True
        Me.WorkOrderConcernsDataGridView.AllowUserToResizeRows = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.WorkOrderConcernsDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.WorkOrderConcernsDataGridView.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.WorkOrderConcernsDataGridView.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
        Me.WorkOrderConcernsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.Menu
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.WorkOrderConcernsDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.WorkOrderConcernsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.WorkOrderConcernsDataGridView.DefaultCellStyle = DataGridViewCellStyle8
        Me.WorkOrderConcernsDataGridView.Location = New System.Drawing.Point(379, 256)
        Me.WorkOrderConcernsDataGridView.Name = "WorkOrderConcernsDataGridView"
        Me.WorkOrderConcernsDataGridView.ReadOnly = True
        Me.WorkOrderConcernsDataGridView.RowHeadersVisible = False
        Me.WorkOrderConcernsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.WorkOrderConcernsDataGridView.Size = New System.Drawing.Size(468, 300)
        Me.WorkOrderConcernsDataGridView.TabIndex = 21
        '
        'ActivatedBy
        '
        Me.ActivatedBy.Location = New System.Drawing.Point(1058, 7)
        Me.ActivatedBy.Name = "ActivatedBy"
        Me.ActivatedBy.Size = New System.Drawing.Size(100, 20)
        Me.ActivatedBy.TabIndex = 43
        Me.ActivatedBy.Visible = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CancelToolStripMenuItem, Me.WorkOrderToolStripMenuItem, Me.AddWorkOrderToolStripMenuItem, Me.EditWorkOrderToolStripMenuItem, Me.DeleteWorkOrderToolStripMenuItem, Me.PrintWorkOrderToolStripMenuItem, Me.SubmitForServiceToolStripMenuItem, Me.FinalizeToolStripMenu, Me.SaveWorkOrderToolStripMenuItem, Me.AssignWorkOrderToolStripMenuItem, Me.ViewToolStripMenuItem, Me.ConcernsToolStripMenuItem, Me.AddWorkOrderConcernToolStripMenuItem, Me.RemoveConcernToolStripMenuItem, Me.ToolStripMenuItem1, Me.ToolStripMenuItem2})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1284, 29)
        Me.MenuStrip1.TabIndex = 44
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'CancelToolStripMenuItem
        '
        Me.CancelToolStripMenuItem.Name = "CancelToolStripMenuItem"
        Me.CancelToolStripMenuItem.Size = New System.Drawing.Size(40, 25)
        Me.CancelToolStripMenuItem.Text = "◄ "
        '
        'WorkOrderToolStripMenuItem
        '
        Me.WorkOrderToolStripMenuItem.Enabled = False
        Me.WorkOrderToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WorkOrderToolStripMenuItem.Name = "WorkOrderToolStripMenuItem"
        Me.WorkOrderToolStripMenuItem.Size = New System.Drawing.Size(148, 25)
        Me.WorkOrderToolStripMenuItem.Text = " WORK ORDERS :"
        '
        'AddWorkOrderToolStripMenuItem
        '
        Me.AddWorkOrderToolStripMenuItem.Name = "AddWorkOrderToolStripMenuItem"
        Me.AddWorkOrderToolStripMenuItem.Size = New System.Drawing.Size(50, 25)
        Me.AddWorkOrderToolStripMenuItem.Text = "Add"
        '
        'EditWorkOrderToolStripMenuItem
        '
        Me.EditWorkOrderToolStripMenuItem.Name = "EditWorkOrderToolStripMenuItem"
        Me.EditWorkOrderToolStripMenuItem.Size = New System.Drawing.Size(48, 25)
        Me.EditWorkOrderToolStripMenuItem.Text = "Edit"
        '
        'DeleteWorkOrderToolStripMenuItem
        '
        Me.DeleteWorkOrderToolStripMenuItem.Name = "DeleteWorkOrderToolStripMenuItem"
        Me.DeleteWorkOrderToolStripMenuItem.Size = New System.Drawing.Size(66, 25)
        Me.DeleteWorkOrderToolStripMenuItem.Text = "Delete"
        '
        'PrintWorkOrderToolStripMenuItem
        '
        Me.PrintWorkOrderToolStripMenuItem.Name = "PrintWorkOrderToolStripMenuItem"
        Me.PrintWorkOrderToolStripMenuItem.Size = New System.Drawing.Size(55, 25)
        Me.PrintWorkOrderToolStripMenuItem.Text = "Print"
        '
        'SubmitForServiceToolStripMenuItem
        '
        Me.SubmitForServiceToolStripMenuItem.Name = "SubmitForServiceToolStripMenuItem"
        Me.SubmitForServiceToolStripMenuItem.Size = New System.Drawing.Size(150, 25)
        Me.SubmitForServiceToolStripMenuItem.Text = "Submit for Service"
        '
        'FinalizeToolStripMenu
        '
        Me.FinalizeToolStripMenu.Name = "FinalizeToolStripMenu"
        Me.FinalizeToolStripMenu.Size = New System.Drawing.Size(74, 25)
        Me.FinalizeToolStripMenu.Text = "Finalize"
        '
        'SaveWorkOrderToolStripMenuItem
        '
        Me.SaveWorkOrderToolStripMenuItem.Name = "SaveWorkOrderToolStripMenuItem"
        Me.SaveWorkOrderToolStripMenuItem.Size = New System.Drawing.Size(55, 25)
        Me.SaveWorkOrderToolStripMenuItem.Text = "Save"
        Me.SaveWorkOrderToolStripMenuItem.Visible = False
        '
        'AssignWorkOrderToolStripMenuItem
        '
        Me.AssignWorkOrderToolStripMenuItem.Name = "AssignWorkOrderToolStripMenuItem"
        Me.AssignWorkOrderToolStripMenuItem.Size = New System.Drawing.Size(150, 25)
        Me.AssignWorkOrderToolStripMenuItem.Text = "Assign WorkOrder"
        Me.AssignWorkOrderToolStripMenuItem.Visible = False
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WorkOrderDetailsToolStripMenuItem, Me.OutstandingWorkOrdersToolStripMenuItem, Me.ForFinalizationBillingToolStripMenuItem, Me.CompletedWorkOrdersToolStripMenuItem, Me.AllWorkOrdersToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(56, 25)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'WorkOrderDetailsToolStripMenuItem
        '
        Me.WorkOrderDetailsToolStripMenuItem.Name = "WorkOrderDetailsToolStripMenuItem"
        Me.WorkOrderDetailsToolStripMenuItem.Size = New System.Drawing.Size(325, 26)
        Me.WorkOrderDetailsToolStripMenuItem.Text = "Work Order Details"
        '
        'OutstandingWorkOrdersToolStripMenuItem
        '
        Me.OutstandingWorkOrdersToolStripMenuItem.Name = "OutstandingWorkOrdersToolStripMenuItem"
        Me.OutstandingWorkOrdersToolStripMenuItem.Size = New System.Drawing.Size(325, 26)
        Me.OutstandingWorkOrdersToolStripMenuItem.Text = "Outstanding Work Orders"
        '
        'ForFinalizationBillingToolStripMenuItem
        '
        Me.ForFinalizationBillingToolStripMenuItem.Name = "ForFinalizationBillingToolStripMenuItem"
        Me.ForFinalizationBillingToolStripMenuItem.Size = New System.Drawing.Size(325, 26)
        Me.ForFinalizationBillingToolStripMenuItem.Text = "For Finalization / Billing"
        '
        'CompletedWorkOrdersToolStripMenuItem
        '
        Me.CompletedWorkOrdersToolStripMenuItem.Name = "CompletedWorkOrdersToolStripMenuItem"
        Me.CompletedWorkOrdersToolStripMenuItem.Size = New System.Drawing.Size(325, 26)
        Me.CompletedWorkOrdersToolStripMenuItem.Text = "Completed Work Orders / Released"
        '
        'AllWorkOrdersToolStripMenuItem
        '
        Me.AllWorkOrdersToolStripMenuItem.Name = "AllWorkOrdersToolStripMenuItem"
        Me.AllWorkOrdersToolStripMenuItem.Size = New System.Drawing.Size(325, 26)
        Me.AllWorkOrdersToolStripMenuItem.Text = "All Work Orders"
        '
        'ConcernsToolStripMenuItem
        '
        Me.ConcernsToolStripMenuItem.Enabled = False
        Me.ConcernsToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ConcernsToolStripMenuItem.Name = "ConcernsToolStripMenuItem"
        Me.ConcernsToolStripMenuItem.Size = New System.Drawing.Size(160, 25)
        Me.ConcernsToolStripMenuItem.Text = ":          CONCERNS :"
        '
        'AddWorkOrderConcernToolStripMenuItem
        '
        Me.AddWorkOrderConcernToolStripMenuItem.Name = "AddWorkOrderConcernToolStripMenuItem"
        Me.AddWorkOrderConcernToolStripMenuItem.Size = New System.Drawing.Size(50, 25)
        Me.AddWorkOrderConcernToolStripMenuItem.Text = "Add"
        '
        'RemoveConcernToolStripMenuItem
        '
        Me.RemoveConcernToolStripMenuItem.Name = "RemoveConcernToolStripMenuItem"
        Me.RemoveConcernToolStripMenuItem.Size = New System.Drawing.Size(141, 25)
        Me.RemoveConcernToolStripMenuItem.Text = "Remove Concern"
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
        'WorkOrderDetailsGroup
        '
        Me.WorkOrderDetailsGroup.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.WorkOrderDetailsGroup.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.WorkOrderDetailsGroup.Controls.Add(Me.MilageMaskedTextBox)
        Me.WorkOrderDetailsGroup.Controls.Add(Me.VINTextBox)
        Me.WorkOrderDetailsGroup.Controls.Add(Me.Label7)
        Me.WorkOrderDetailsGroup.Controls.Add(Me.VehicleDetailsTextBox)
        Me.WorkOrderDetailsGroup.Controls.Add(Me.Label6)
        Me.WorkOrderDetailsGroup.Controls.Add(Me.CustomerTextBox)
        Me.WorkOrderDetailsGroup.Controls.Add(Me.Label5)
        Me.WorkOrderDetailsGroup.Controls.Add(Me.Label4)
        Me.WorkOrderDetailsGroup.Controls.Add(Me.DateTimeOutTextBox)
        Me.WorkOrderDetailsGroup.Controls.Add(Me.ServiceDate_DateTimeTextBox)
        Me.WorkOrderDetailsGroup.Controls.Add(Me.WorkOrderNumberTextBox)
        Me.WorkOrderDetailsGroup.Controls.Add(Me.Label3)
        Me.WorkOrderDetailsGroup.Controls.Add(Me.Label2)
        Me.WorkOrderDetailsGroup.Controls.Add(Me.Label1)
        Me.WorkOrderDetailsGroup.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.WorkOrderDetailsGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WorkOrderDetailsGroup.Location = New System.Drawing.Point(30, 74)
        Me.WorkOrderDetailsGroup.Name = "WorkOrderDetailsGroup"
        Me.WorkOrderDetailsGroup.Size = New System.Drawing.Size(554, 255)
        Me.WorkOrderDetailsGroup.TabIndex = 45
        Me.WorkOrderDetailsGroup.TabStop = False
        Me.WorkOrderDetailsGroup.Visible = False
        '
        'MilageMaskedTextBox
        '
        Me.MilageMaskedTextBox.Location = New System.Drawing.Point(174, 113)
        Me.MilageMaskedTextBox.Name = "MilageMaskedTextBox"
        Me.MilageMaskedTextBox.Size = New System.Drawing.Size(65, 26)
        Me.MilageMaskedTextBox.TabIndex = 53
        '
        'VINTextBox
        '
        Me.VINTextBox.Location = New System.Drawing.Point(174, 182)
        Me.VINTextBox.Name = "VINTextBox"
        Me.VINTextBox.Size = New System.Drawing.Size(249, 26)
        Me.VINTextBox.TabIndex = 52
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 186)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 20)
        Me.Label7.TabIndex = 51
        Me.Label7.Text = "VIN"
        '
        'VehicleDetailsTextBox
        '
        Me.VehicleDetailsTextBox.Location = New System.Drawing.Point(174, 214)
        Me.VehicleDetailsTextBox.Name = "VehicleDetailsTextBox"
        Me.VehicleDetailsTextBox.Size = New System.Drawing.Size(357, 26)
        Me.VehicleDetailsTextBox.TabIndex = 50
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 220)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(114, 20)
        Me.Label6.TabIndex = 49
        Me.Label6.Text = "Vehicle Details"
        '
        'CustomerTextBox
        '
        Me.CustomerTextBox.Location = New System.Drawing.Point(174, 147)
        Me.CustomerTextBox.Name = "CustomerTextBox"
        Me.CustomerTextBox.Size = New System.Drawing.Size(357, 26)
        Me.CustomerTextBox.TabIndex = 48
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 153)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 20)
        Me.Label5.TabIndex = 47
        Me.Label5.Text = "Customer"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 119)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 20)
        Me.Label4.TabIndex = 46
        Me.Label4.Text = "Milage"
        '
        'DateTimeOutTextBox
        '
        Me.DateTimeOutTextBox.Location = New System.Drawing.Point(174, 79)
        Me.DateTimeOutTextBox.Name = "DateTimeOutTextBox"
        Me.DateTimeOutTextBox.Size = New System.Drawing.Size(142, 26)
        Me.DateTimeOutTextBox.TabIndex = 45
        '
        'ServiceDate_DateTimeTextBox
        '
        Me.ServiceDate_DateTimeTextBox.Location = New System.Drawing.Point(174, 47)
        Me.ServiceDate_DateTimeTextBox.Name = "ServiceDate_DateTimeTextBox"
        Me.ServiceDate_DateTimeTextBox.Size = New System.Drawing.Size(249, 26)
        Me.ServiceDate_DateTimeTextBox.TabIndex = 44
        '
        'WorkOrderNumberTextBox
        '
        Me.WorkOrderNumberTextBox.Enabled = False
        Me.WorkOrderNumberTextBox.Location = New System.Drawing.Point(174, 15)
        Me.WorkOrderNumberTextBox.Name = "WorkOrderNumberTextBox"
        Me.WorkOrderNumberTextBox.Size = New System.Drawing.Size(100, 26)
        Me.WorkOrderNumberTextBox.TabIndex = 43
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 85)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 20)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Date / Time Out"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 52)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 20)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Date / Time In"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 21)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(150, 20)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "Work Order Number"
        '
        'WorkOrderForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1284, 694)
        Me.ControlBox = False
        Me.Controls.Add(Me.WorkOrderDetailsGroup)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.ActivatedBy)
        Me.Controls.Add(Me.WorkOrderConcernsDataGridView)
        Me.Controls.Add(Me.WorkOrdersDataGridView)
        Me.Name = "WorkOrderForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "WORK ORDERS"
        CType(Me.WorkOrdersDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WorkOrderConcernsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.WorkOrderDetailsGroup.ResumeLayout(False)
        Me.WorkOrderDetailsGroup.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents WorkOrdersDataGridView As DataGridView
    Friend WithEvents WorkOrderConcernsDataGridView As DataGridView
    Friend WithEvents ActivatedBy As TextBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents CancelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddWorkOrderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditWorkOrderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteWorkOrderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PrintWorkOrderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WorkOrderDetailsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OutstandingWorkOrdersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CompletedWorkOrdersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AllWorkOrdersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AssignWorkOrderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConcernsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddWorkOrderConcernToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RemoveConcernToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WorkOrderDetailsGroup As GroupBox
    Friend WithEvents MilageMaskedTextBox As MaskedTextBox
    Friend WithEvents VINTextBox As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents VehicleDetailsTextBox As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents CustomerTextBox As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents DateTimeOutTextBox As TextBox
    Friend WithEvents ServiceDate_DateTimeTextBox As TextBox
    Friend WithEvents WorkOrderNumberTextBox As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents SaveWorkOrderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WorkOrderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SubmitForServiceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FinalizeToolStripMenu As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ForFinalizationBillingToolStripMenuItem As ToolStripMenuItem
End Class
