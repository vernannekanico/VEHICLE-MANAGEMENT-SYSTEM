<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class WorkOrderFormASM
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
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.WorkOrderFormASMMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.CancelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WorkOrderMenusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AssignWorkOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintWorkOrderDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WorkOrderDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OutstandingWorkOrdersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ForFinalizationBillingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CompletedWorkOrdersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllWorkOrdersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RevertWorkOrderStatsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConcernMenusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddConcernToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditConcernToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveConcernToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AssignConcernToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GetStandardJobForThisConcernToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.JobMenusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddJobToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditJobToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveJobToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AssignJobToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SubcontractJobToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RequestPartsFromWarehouseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReceivepartsfromtheCustomerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProcessJobToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.JobDoneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveWorkOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WorkOrdersDataGridView = New System.Windows.Forms.DataGridView()
        Me.WorkOrdersGroupBox = New System.Windows.Forms.GroupBox()
        Me.WorkOrderConcernsGroupBox = New System.Windows.Forms.GroupBox()
        Me.WorkOrderConcernsDataGridView = New System.Windows.Forms.DataGridView()
        Me.WorkOrderConcernJobsGroupBox = New System.Windows.Forms.GroupBox()
        Me.WorkOrderConcernJobsDataGridView = New System.Windows.Forms.DataGridView()
        Me.WorkOrderPartsPerJobGroupBox = New System.Windows.Forms.GroupBox()
        Me.WorkOrderPartsPerJobDataGridView = New System.Windows.Forms.DataGridView()
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
        Me.RevertConcernToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RevertJobStatusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WorkOrderFormASMMenuStrip.SuspendLayout()
        CType(Me.WorkOrdersDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.WorkOrdersGroupBox.SuspendLayout()
        Me.WorkOrderConcernsGroupBox.SuspendLayout()
        CType(Me.WorkOrderConcernsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.WorkOrderConcernJobsGroupBox.SuspendLayout()
        CType(Me.WorkOrderConcernJobsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.WorkOrderPartsPerJobGroupBox.SuspendLayout()
        CType(Me.WorkOrderPartsPerJobDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.WorkOrderDetailsGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        'WorkOrderFormASMMenuStrip
        '
        Me.WorkOrderFormASMMenuStrip.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WorkOrderFormASMMenuStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.WorkOrderFormASMMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CancelToolStripMenuItem, Me.WorkOrderMenusToolStripMenuItem, Me.ConcernMenusToolStripMenuItem, Me.JobMenusToolStripMenuItem, Me.SaveWorkOrderToolStripMenuItem})
        Me.WorkOrderFormASMMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.WorkOrderFormASMMenuStrip.Name = "WorkOrderFormASMMenuStrip"
        Me.WorkOrderFormASMMenuStrip.Padding = New System.Windows.Forms.Padding(9, 3, 0, 3)
        Me.WorkOrderFormASMMenuStrip.Size = New System.Drawing.Size(1284, 31)
        Me.WorkOrderFormASMMenuStrip.TabIndex = 55
        Me.WorkOrderFormASMMenuStrip.Text = "MenuStrip1"
        '
        'CancelToolStripMenuItem
        '
        Me.CancelToolStripMenuItem.Name = "CancelToolStripMenuItem"
        Me.CancelToolStripMenuItem.Size = New System.Drawing.Size(40, 25)
        Me.CancelToolStripMenuItem.Text = "◄ "
        '
        'WorkOrderMenusToolStripMenuItem
        '
        Me.WorkOrderMenusToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AssignWorkOrderToolStripMenuItem, Me.PrintWorkOrderDetailsToolStripMenuItem, Me.ViewToolStripMenuItem, Me.RevertWorkOrderStatsToolStripMenuItem})
        Me.WorkOrderMenusToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WorkOrderMenusToolStripMenuItem.Name = "WorkOrderMenusToolStripMenuItem"
        Me.WorkOrderMenusToolStripMenuItem.Size = New System.Drawing.Size(201, 25)
        Me.WorkOrderMenusToolStripMenuItem.Text = " WORK ORDER MENUS :"
        '
        'AssignWorkOrderToolStripMenuItem
        '
        Me.AssignWorkOrderToolStripMenuItem.Name = "AssignWorkOrderToolStripMenuItem"
        Me.AssignWorkOrderToolStripMenuItem.Size = New System.Drawing.Size(274, 26)
        Me.AssignWorkOrderToolStripMenuItem.Text = "Assign Work Order"
        '
        'PrintWorkOrderDetailsToolStripMenuItem
        '
        Me.PrintWorkOrderDetailsToolStripMenuItem.Name = "PrintWorkOrderDetailsToolStripMenuItem"
        Me.PrintWorkOrderDetailsToolStripMenuItem.Size = New System.Drawing.Size(274, 26)
        Me.PrintWorkOrderDetailsToolStripMenuItem.Text = "Print Work Order Details"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WorkOrderDetailsToolStripMenuItem, Me.OutstandingWorkOrdersToolStripMenuItem, Me.ForFinalizationBillingToolStripMenuItem, Me.CompletedWorkOrdersToolStripMenuItem, Me.AllWorkOrdersToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(274, 26)
        Me.ViewToolStripMenuItem.Text = "View Work Order Options"
        '
        'WorkOrderDetailsToolStripMenuItem
        '
        Me.WorkOrderDetailsToolStripMenuItem.Name = "WorkOrderDetailsToolStripMenuItem"
        Me.WorkOrderDetailsToolStripMenuItem.Size = New System.Drawing.Size(346, 26)
        Me.WorkOrderDetailsToolStripMenuItem.Text = "Work Order Details"
        '
        'OutstandingWorkOrdersToolStripMenuItem
        '
        Me.OutstandingWorkOrdersToolStripMenuItem.Name = "OutstandingWorkOrdersToolStripMenuItem"
        Me.OutstandingWorkOrdersToolStripMenuItem.Size = New System.Drawing.Size(346, 26)
        Me.OutstandingWorkOrdersToolStripMenuItem.Text = "Outstanding Work Orders"
        '
        'ForFinalizationBillingToolStripMenuItem
        '
        Me.ForFinalizationBillingToolStripMenuItem.Name = "ForFinalizationBillingToolStripMenuItem"
        Me.ForFinalizationBillingToolStripMenuItem.Size = New System.Drawing.Size(346, 26)
        Me.ForFinalizationBillingToolStripMenuItem.Text = "For Finalization / Billing"
        '
        'CompletedWorkOrdersToolStripMenuItem
        '
        Me.CompletedWorkOrdersToolStripMenuItem.Name = "CompletedWorkOrdersToolStripMenuItem"
        Me.CompletedWorkOrdersToolStripMenuItem.Size = New System.Drawing.Size(346, 26)
        Me.CompletedWorkOrdersToolStripMenuItem.Text = "Completed Work Orders / Released"
        '
        'AllWorkOrdersToolStripMenuItem
        '
        Me.AllWorkOrdersToolStripMenuItem.Name = "AllWorkOrdersToolStripMenuItem"
        Me.AllWorkOrdersToolStripMenuItem.Size = New System.Drawing.Size(346, 26)
        Me.AllWorkOrdersToolStripMenuItem.Text = "All Work Orders"
        '
        'RevertWorkOrderStatsToolStripMenuItem
        '
        Me.RevertWorkOrderStatsToolStripMenuItem.Name = "RevertWorkOrderStatsToolStripMenuItem"
        Me.RevertWorkOrderStatsToolStripMenuItem.Size = New System.Drawing.Size(274, 26)
        Me.RevertWorkOrderStatsToolStripMenuItem.Text = "Revert Work Order Status"
        '
        'ConcernMenusToolStripMenuItem
        '
        Me.ConcernMenusToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddConcernToolStripMenuItem, Me.EditConcernToolStripMenuItem, Me.RemoveConcernToolStripMenuItem, Me.AssignConcernToolStripMenuItem, Me.GetStandardJobForThisConcernToolStripMenuItem, Me.RevertConcernToolStripMenuItem})
        Me.ConcernMenusToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ConcernMenusToolStripMenuItem.Name = "ConcernMenusToolStripMenuItem"
        Me.ConcernMenusToolStripMenuItem.Size = New System.Drawing.Size(169, 25)
        Me.ConcernMenusToolStripMenuItem.Text = " CONCERN MENUS:"
        '
        'AddConcernToolStripMenuItem
        '
        Me.AddConcernToolStripMenuItem.Name = "AddConcernToolStripMenuItem"
        Me.AddConcernToolStripMenuItem.Size = New System.Drawing.Size(340, 26)
        Me.AddConcernToolStripMenuItem.Text = "Add Concern"
        '
        'EditConcernToolStripMenuItem
        '
        Me.EditConcernToolStripMenuItem.Name = "EditConcernToolStripMenuItem"
        Me.EditConcernToolStripMenuItem.Size = New System.Drawing.Size(340, 26)
        Me.EditConcernToolStripMenuItem.Text = "Edit Concern"
        '
        'RemoveConcernToolStripMenuItem
        '
        Me.RemoveConcernToolStripMenuItem.Name = "RemoveConcernToolStripMenuItem"
        Me.RemoveConcernToolStripMenuItem.Size = New System.Drawing.Size(340, 26)
        Me.RemoveConcernToolStripMenuItem.Text = "Remove Concern"
        '
        'AssignConcernToolStripMenuItem
        '
        Me.AssignConcernToolStripMenuItem.Name = "AssignConcernToolStripMenuItem"
        Me.AssignConcernToolStripMenuItem.Size = New System.Drawing.Size(340, 26)
        Me.AssignConcernToolStripMenuItem.Text = "Assign Concern"
        '
        'GetStandardJobForThisConcernToolStripMenuItem
        '
        Me.GetStandardJobForThisConcernToolStripMenuItem.Name = "GetStandardJobForThisConcernToolStripMenuItem"
        Me.GetStandardJobForThisConcernToolStripMenuItem.Size = New System.Drawing.Size(340, 26)
        Me.GetStandardJobForThisConcernToolStripMenuItem.Text = "Get Standard Job For This Concern"
        '
        'JobMenusToolStripMenuItem
        '
        Me.JobMenusToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddJobToolStripMenuItem, Me.EditJobToolStripMenuItem, Me.RemoveJobToolStripMenuItem, Me.AssignJobToolStripMenuItem, Me.SubcontractJobToolStripMenuItem, Me.RequestPartsFromWarehouseToolStripMenuItem, Me.ReceivepartsfromtheCustomerToolStripMenuItem, Me.ProcessJobToolStripMenuItem, Me.JobDoneToolStripMenuItem, Me.RevertJobStatusToolStripMenuItem})
        Me.JobMenusToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JobMenusToolStripMenuItem.Name = "JobMenusToolStripMenuItem"
        Me.JobMenusToolStripMenuItem.Size = New System.Drawing.Size(117, 25)
        Me.JobMenusToolStripMenuItem.Text = " JOB MENUS"
        '
        'AddJobToolStripMenuItem
        '
        Me.AddJobToolStripMenuItem.Name = "AddJobToolStripMenuItem"
        Me.AddJobToolStripMenuItem.Size = New System.Drawing.Size(328, 26)
        Me.AddJobToolStripMenuItem.Text = "Add Job"
        '
        'EditJobToolStripMenuItem
        '
        Me.EditJobToolStripMenuItem.Name = "EditJobToolStripMenuItem"
        Me.EditJobToolStripMenuItem.Size = New System.Drawing.Size(328, 26)
        Me.EditJobToolStripMenuItem.Text = "Edit Job"
        '
        'RemoveJobToolStripMenuItem
        '
        Me.RemoveJobToolStripMenuItem.Name = "RemoveJobToolStripMenuItem"
        Me.RemoveJobToolStripMenuItem.Size = New System.Drawing.Size(328, 26)
        Me.RemoveJobToolStripMenuItem.Text = "Remove Job"
        '
        'AssignJobToolStripMenuItem
        '
        Me.AssignJobToolStripMenuItem.Name = "AssignJobToolStripMenuItem"
        Me.AssignJobToolStripMenuItem.Size = New System.Drawing.Size(328, 26)
        Me.AssignJobToolStripMenuItem.Text = "Assign Job"
        '
        'SubcontractJobToolStripMenuItem
        '
        Me.SubcontractJobToolStripMenuItem.Name = "SubcontractJobToolStripMenuItem"
        Me.SubcontractJobToolStripMenuItem.Size = New System.Drawing.Size(328, 26)
        Me.SubcontractJobToolStripMenuItem.Text = "Sub-contract Job"
        '
        'RequestPartsFromWarehouseToolStripMenuItem
        '
        Me.RequestPartsFromWarehouseToolStripMenuItem.Name = "RequestPartsFromWarehouseToolStripMenuItem"
        Me.RequestPartsFromWarehouseToolStripMenuItem.Size = New System.Drawing.Size(328, 26)
        Me.RequestPartsFromWarehouseToolStripMenuItem.Text = "Request Parts"
        '
        'ReceivepartsfromtheCustomerToolStripMenuItem
        '
        Me.ReceivepartsfromtheCustomerToolStripMenuItem.Name = "ReceivepartsfromtheCustomerToolStripMenuItem"
        Me.ReceivepartsfromtheCustomerToolStripMenuItem.Size = New System.Drawing.Size(328, 26)
        Me.ReceivepartsfromtheCustomerToolStripMenuItem.Text = "Receive parts from the Customer"
        '
        'ProcessJobToolStripMenuItem
        '
        Me.ProcessJobToolStripMenuItem.Name = "ProcessJobToolStripMenuItem"
        Me.ProcessJobToolStripMenuItem.Size = New System.Drawing.Size(328, 26)
        Me.ProcessJobToolStripMenuItem.Text = "Process Job"
        '
        'JobDoneToolStripMenuItem
        '
        Me.JobDoneToolStripMenuItem.Name = "JobDoneToolStripMenuItem"
        Me.JobDoneToolStripMenuItem.Size = New System.Drawing.Size(328, 26)
        Me.JobDoneToolStripMenuItem.Text = "Done"
        Me.JobDoneToolStripMenuItem.Visible = False
        '
        'SaveWorkOrderToolStripMenuItem
        '
        Me.SaveWorkOrderToolStripMenuItem.Name = "SaveWorkOrderToolStripMenuItem"
        Me.SaveWorkOrderToolStripMenuItem.Size = New System.Drawing.Size(55, 25)
        Me.SaveWorkOrderToolStripMenuItem.Text = "Save"
        Me.SaveWorkOrderToolStripMenuItem.Visible = False
        '
        'WorkOrdersDataGridView
        '
        Me.WorkOrdersDataGridView.AllowUserToAddRows = False
        Me.WorkOrdersDataGridView.AllowUserToDeleteRows = False
        Me.WorkOrdersDataGridView.AllowUserToOrderColumns = True
        Me.WorkOrdersDataGridView.AllowUserToResizeRows = False
        Me.WorkOrdersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.WorkOrdersDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WorkOrdersDataGridView.Location = New System.Drawing.Point(3, 22)
        Me.WorkOrdersDataGridView.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.WorkOrdersDataGridView.MultiSelect = False
        Me.WorkOrdersDataGridView.Name = "WorkOrdersDataGridView"
        Me.WorkOrdersDataGridView.ReadOnly = True
        Me.WorkOrdersDataGridView.RowHeadersVisible = False
        Me.WorkOrdersDataGridView.RowHeadersWidth = 51
        Me.WorkOrdersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.WorkOrdersDataGridView.Size = New System.Drawing.Size(348, 289)
        Me.WorkOrdersDataGridView.TabIndex = 52
        '
        'WorkOrdersGroupBox
        '
        Me.WorkOrdersGroupBox.Controls.Add(Me.WorkOrdersDataGridView)
        Me.WorkOrdersGroupBox.Location = New System.Drawing.Point(25, 53)
        Me.WorkOrdersGroupBox.Name = "WorkOrdersGroupBox"
        Me.WorkOrdersGroupBox.Size = New System.Drawing.Size(354, 314)
        Me.WorkOrdersGroupBox.TabIndex = 59
        Me.WorkOrdersGroupBox.TabStop = False
        Me.WorkOrdersGroupBox.Text = "Work Orders"
        '
        'WorkOrderConcernsGroupBox
        '
        Me.WorkOrderConcernsGroupBox.Controls.Add(Me.WorkOrderConcernsDataGridView)
        Me.WorkOrderConcernsGroupBox.Location = New System.Drawing.Point(416, 173)
        Me.WorkOrderConcernsGroupBox.Name = "WorkOrderConcernsGroupBox"
        Me.WorkOrderConcernsGroupBox.Size = New System.Drawing.Size(259, 252)
        Me.WorkOrderConcernsGroupBox.TabIndex = 60
        Me.WorkOrderConcernsGroupBox.TabStop = False
        Me.WorkOrderConcernsGroupBox.Text = "Concerns"
        '
        'WorkOrderConcernsDataGridView
        '
        Me.WorkOrderConcernsDataGridView.AllowUserToAddRows = False
        Me.WorkOrderConcernsDataGridView.AllowUserToDeleteRows = False
        Me.WorkOrderConcernsDataGridView.AllowUserToOrderColumns = True
        Me.WorkOrderConcernsDataGridView.AllowUserToResizeRows = False
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.WorkOrderConcernsDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle8
        Me.WorkOrderConcernsDataGridView.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
        Me.WorkOrderConcernsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.Menu
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.WorkOrderConcernsDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.WorkOrderConcernsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.WorkOrderConcernsDataGridView.DefaultCellStyle = DataGridViewCellStyle10
        Me.WorkOrderConcernsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WorkOrderConcernsDataGridView.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.WorkOrderConcernsDataGridView.Location = New System.Drawing.Point(3, 22)
        Me.WorkOrderConcernsDataGridView.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.WorkOrderConcernsDataGridView.Name = "WorkOrderConcernsDataGridView"
        Me.WorkOrderConcernsDataGridView.ReadOnly = True
        Me.WorkOrderConcernsDataGridView.RowHeadersVisible = False
        Me.WorkOrderConcernsDataGridView.RowHeadersWidth = 51
        Me.WorkOrderConcernsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.WorkOrderConcernsDataGridView.Size = New System.Drawing.Size(253, 227)
        Me.WorkOrderConcernsDataGridView.TabIndex = 54
        '
        'WorkOrderConcernJobsGroupBox
        '
        Me.WorkOrderConcernJobsGroupBox.Controls.Add(Me.WorkOrderConcernJobsDataGridView)
        Me.WorkOrderConcernJobsGroupBox.Location = New System.Drawing.Point(719, 78)
        Me.WorkOrderConcernJobsGroupBox.Name = "WorkOrderConcernJobsGroupBox"
        Me.WorkOrderConcernJobsGroupBox.Size = New System.Drawing.Size(337, 219)
        Me.WorkOrderConcernJobsGroupBox.TabIndex = 61
        Me.WorkOrderConcernJobsGroupBox.TabStop = False
        Me.WorkOrderConcernJobsGroupBox.Text = "Jobs"
        '
        'WorkOrderConcernJobsDataGridView
        '
        Me.WorkOrderConcernJobsDataGridView.AllowUserToAddRows = False
        Me.WorkOrderConcernJobsDataGridView.AllowUserToDeleteRows = False
        Me.WorkOrderConcernJobsDataGridView.AllowUserToOrderColumns = True
        Me.WorkOrderConcernJobsDataGridView.AllowUserToResizeRows = False
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.WorkOrderConcernJobsDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle11
        Me.WorkOrderConcernJobsDataGridView.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
        Me.WorkOrderConcernJobsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.Menu
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.WorkOrderConcernJobsDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.WorkOrderConcernJobsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.WorkOrderConcernJobsDataGridView.DefaultCellStyle = DataGridViewCellStyle13
        Me.WorkOrderConcernJobsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WorkOrderConcernJobsDataGridView.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.WorkOrderConcernJobsDataGridView.Location = New System.Drawing.Point(3, 22)
        Me.WorkOrderConcernJobsDataGridView.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.WorkOrderConcernJobsDataGridView.Name = "WorkOrderConcernJobsDataGridView"
        Me.WorkOrderConcernJobsDataGridView.ReadOnly = True
        Me.WorkOrderConcernJobsDataGridView.RowHeadersVisible = False
        Me.WorkOrderConcernJobsDataGridView.RowHeadersWidth = 51
        Me.WorkOrderConcernJobsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.WorkOrderConcernJobsDataGridView.Size = New System.Drawing.Size(331, 194)
        Me.WorkOrderConcernJobsDataGridView.TabIndex = 57
        '
        'WorkOrderPartsPerJobGroupBox
        '
        Me.WorkOrderPartsPerJobGroupBox.Controls.Add(Me.WorkOrderPartsPerJobDataGridView)
        Me.WorkOrderPartsPerJobGroupBox.Location = New System.Drawing.Point(1079, 100)
        Me.WorkOrderPartsPerJobGroupBox.Name = "WorkOrderPartsPerJobGroupBox"
        Me.WorkOrderPartsPerJobGroupBox.Size = New System.Drawing.Size(412, 248)
        Me.WorkOrderPartsPerJobGroupBox.TabIndex = 62
        Me.WorkOrderPartsPerJobGroupBox.TabStop = False
        Me.WorkOrderPartsPerJobGroupBox.Text = "Job Parts"
        '
        'WorkOrderPartsPerJobDataGridView
        '
        Me.WorkOrderPartsPerJobDataGridView.AllowUserToAddRows = False
        Me.WorkOrderPartsPerJobDataGridView.AllowUserToDeleteRows = False
        Me.WorkOrderPartsPerJobDataGridView.AllowUserToOrderColumns = True
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WorkOrderPartsPerJobDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle14
        Me.WorkOrderPartsPerJobDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.WorkOrderPartsPerJobDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WorkOrderPartsPerJobDataGridView.Enabled = False
        Me.WorkOrderPartsPerJobDataGridView.Location = New System.Drawing.Point(3, 22)
        Me.WorkOrderPartsPerJobDataGridView.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.WorkOrderPartsPerJobDataGridView.MultiSelect = False
        Me.WorkOrderPartsPerJobDataGridView.Name = "WorkOrderPartsPerJobDataGridView"
        Me.WorkOrderPartsPerJobDataGridView.ReadOnly = True
        Me.WorkOrderPartsPerJobDataGridView.RowHeadersWidth = 51
        Me.WorkOrderPartsPerJobDataGridView.Size = New System.Drawing.Size(406, 223)
        Me.WorkOrderPartsPerJobDataGridView.TabIndex = 59
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
        Me.WorkOrderDetailsGroup.Location = New System.Drawing.Point(759, 352)
        Me.WorkOrderDetailsGroup.Name = "WorkOrderDetailsGroup"
        Me.WorkOrderDetailsGroup.Size = New System.Drawing.Size(554, 255)
        Me.WorkOrderDetailsGroup.TabIndex = 63
        Me.WorkOrderDetailsGroup.TabStop = False
        Me.WorkOrderDetailsGroup.Visible = False
        '
        'MilageMaskedTextBox
        '
        Me.MilageMaskedTextBox.Enabled = False
        Me.MilageMaskedTextBox.Location = New System.Drawing.Point(174, 113)
        Me.MilageMaskedTextBox.Name = "MilageMaskedTextBox"
        Me.MilageMaskedTextBox.Size = New System.Drawing.Size(65, 26)
        Me.MilageMaskedTextBox.TabIndex = 53
        '
        'VINTextBox
        '
        Me.VINTextBox.Enabled = False
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
        Me.VehicleDetailsTextBox.Enabled = False
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
        Me.CustomerTextBox.Enabled = False
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
        Me.DateTimeOutTextBox.Enabled = False
        Me.DateTimeOutTextBox.Location = New System.Drawing.Point(174, 79)
        Me.DateTimeOutTextBox.Name = "DateTimeOutTextBox"
        Me.DateTimeOutTextBox.Size = New System.Drawing.Size(142, 26)
        Me.DateTimeOutTextBox.TabIndex = 45
        '
        'ServiceDate_DateTimeTextBox
        '
        Me.ServiceDate_DateTimeTextBox.Enabled = False
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
        'RevertConcernToolStripMenuItem
        '
        Me.RevertConcernToolStripMenuItem.Name = "RevertConcernToolStripMenuItem"
        Me.RevertConcernToolStripMenuItem.Size = New System.Drawing.Size(340, 26)
        Me.RevertConcernToolStripMenuItem.Text = "Revert Concern Status"
        '
        'RevertJobStatusToolStripMenuItem
        '
        Me.RevertJobStatusToolStripMenuItem.Name = "RevertJobStatusToolStripMenuItem"
        Me.RevertJobStatusToolStripMenuItem.Size = New System.Drawing.Size(328, 26)
        Me.RevertJobStatusToolStripMenuItem.Text = "Revert Job Status"
        '
        'WorkOrderFormASM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1284, 749)
        Me.Controls.Add(Me.WorkOrderDetailsGroup)
        Me.Controls.Add(Me.WorkOrderConcernsGroupBox)
        Me.Controls.Add(Me.WorkOrderPartsPerJobGroupBox)
        Me.Controls.Add(Me.WorkOrderConcernJobsGroupBox)
        Me.Controls.Add(Me.WorkOrdersGroupBox)
        Me.Controls.Add(Me.WorkOrderFormASMMenuStrip)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "WorkOrderFormASM"
        Me.Text = "WorkOrderFormASM"
        Me.WorkOrderFormASMMenuStrip.ResumeLayout(False)
        Me.WorkOrderFormASMMenuStrip.PerformLayout()
        CType(Me.WorkOrdersDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.WorkOrdersGroupBox.ResumeLayout(False)
        Me.WorkOrderConcernsGroupBox.ResumeLayout(False)
        CType(Me.WorkOrderConcernsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.WorkOrderConcernJobsGroupBox.ResumeLayout(False)
        CType(Me.WorkOrderConcernJobsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.WorkOrderPartsPerJobGroupBox.ResumeLayout(False)
        CType(Me.WorkOrderPartsPerJobDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.WorkOrderDetailsGroup.ResumeLayout(False)
        Me.WorkOrderDetailsGroup.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents WorkOrderFormASMMenuStrip As MenuStrip
    Friend WithEvents CancelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WorkOrderMenusToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents JobMenusToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WorkOrdersDataGridView As DataGridView
    Friend WithEvents ConcernMenusToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WorkOrdersGroupBox As GroupBox
    Friend WithEvents WorkOrderConcernsGroupBox As GroupBox
    Friend WithEvents WorkOrderConcernJobsGroupBox As GroupBox
    Friend WithEvents WorkOrderConcernsDataGridView As DataGridView
    Friend WithEvents WorkOrderConcernJobsDataGridView As DataGridView
    Friend WithEvents WorkOrderPartsPerJobDataGridView As DataGridView
    Protected WithEvents WorkOrderPartsPerJobGroupBox As GroupBox
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
    Friend WithEvents AssignConcernToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AssignWorkOrderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PrintWorkOrderDetailsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WorkOrderDetailsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OutstandingWorkOrdersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ForFinalizationBillingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CompletedWorkOrdersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AllWorkOrdersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RemoveConcernToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddConcernToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditConcernToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RevertWorkOrderStatsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddJobToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditJobToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RemoveJobToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AssignJobToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProcessJobToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RequestPartsFromWarehouseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReceivepartsfromtheCustomerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents JobDoneToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GetStandardJobForThisConcernToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SubcontractJobToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RevertConcernToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RevertJobStatusToolStripMenuItem As ToolStripMenuItem
End Class
