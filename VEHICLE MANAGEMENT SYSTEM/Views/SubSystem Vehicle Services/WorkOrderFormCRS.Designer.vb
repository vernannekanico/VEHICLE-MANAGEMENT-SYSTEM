﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class WorkOrderFormCRS
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.WorkOrdersDataGridView = New System.Windows.Forms.DataGridView()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.CancelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WorkOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddWorkOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditWorkOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteWorkOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintWorkOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SubmitForServiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintBillToolStripMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveWorkOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WorkOrderDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OutstandingWorkOrdersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ForFinalizationBillingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CompletedWorkOrdersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllWorkOrdersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConcernOrJobToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddWorkOrderConcernToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditConcernToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveConcernOrJobToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.WorkOrderConcernsDataGridView = New System.Windows.Forms.DataGridView()
        Me.AllWorkOrderPartsDataGridView = New System.Windows.Forms.DataGridView()
        CType(Me.WorkOrdersDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.WorkOrderDetailsGroup.SuspendLayout()
        CType(Me.WorkOrderConcernsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AllWorkOrderPartsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.WorkOrdersDataGridView.DefaultCellStyle = DataGridViewCellStyle1
        Me.WorkOrdersDataGridView.Location = New System.Drawing.Point(864, 291)
        Me.WorkOrdersDataGridView.MultiSelect = False
        Me.WorkOrdersDataGridView.Name = "WorkOrdersDataGridView"
        Me.WorkOrdersDataGridView.ReadOnly = True
        Me.WorkOrdersDataGridView.RowHeadersVisible = False
        Me.WorkOrdersDataGridView.RowHeadersWidth = 51
        Me.WorkOrdersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.WorkOrdersDataGridView.Size = New System.Drawing.Size(294, 138)
        Me.WorkOrdersDataGridView.TabIndex = 5
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CancelToolStripMenuItem, Me.WorkOrderToolStripMenuItem, Me.AddWorkOrderToolStripMenuItem, Me.EditWorkOrderToolStripMenuItem, Me.DeleteWorkOrderToolStripMenuItem, Me.PrintWorkOrderToolStripMenuItem, Me.SubmitForServiceToolStripMenuItem, Me.PrintBillToolStripMenu, Me.SaveWorkOrderToolStripMenuItem, Me.ViewToolStripMenuItem, Me.ConcernOrJobToolStripMenuItem, Me.AddWorkOrderConcernToolStripMenuItem, Me.EditConcernToolStripMenuItem, Me.RemoveConcernOrJobToolStripMenuItem, Me.ToolStripMenuItem1, Me.ToolStripMenuItem2})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(4, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(963, 29)
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
        'PrintBillToolStripMenu
        '
        Me.PrintBillToolStripMenu.Name = "PrintBillToolStripMenu"
        Me.PrintBillToolStripMenu.Size = New System.Drawing.Size(80, 25)
        Me.PrintBillToolStripMenu.Text = "Print Bill"
        '
        'SaveWorkOrderToolStripMenuItem
        '
        Me.SaveWorkOrderToolStripMenuItem.Name = "SaveWorkOrderToolStripMenuItem"
        Me.SaveWorkOrderToolStripMenuItem.Size = New System.Drawing.Size(55, 25)
        Me.SaveWorkOrderToolStripMenuItem.Text = "Save"
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
        'ConcernOrJobToolStripMenuItem
        '
        Me.ConcernOrJobToolStripMenuItem.Enabled = False
        Me.ConcernOrJobToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ConcernOrJobToolStripMenuItem.Name = "ConcernOrJobToolStripMenuItem"
        Me.ConcernOrJobToolStripMenuItem.Size = New System.Drawing.Size(160, 25)
        Me.ConcernOrJobToolStripMenuItem.Text = ":          CONCERNS :"
        '
        'AddWorkOrderConcernToolStripMenuItem
        '
        Me.AddWorkOrderConcernToolStripMenuItem.Name = "AddWorkOrderConcernToolStripMenuItem"
        Me.AddWorkOrderConcernToolStripMenuItem.Size = New System.Drawing.Size(50, 25)
        Me.AddWorkOrderConcernToolStripMenuItem.Text = "Add"
        '
        'EditConcernToolStripMenuItem
        '
        Me.EditConcernToolStripMenuItem.Name = "EditConcernToolStripMenuItem"
        Me.EditConcernToolStripMenuItem.Size = New System.Drawing.Size(48, 25)
        Me.EditConcernToolStripMenuItem.Text = "Edit"
        '
        'RemoveConcernOrJobToolStripMenuItem
        '
        Me.RemoveConcernOrJobToolStripMenuItem.Name = "RemoveConcernOrJobToolStripMenuItem"
        Me.RemoveConcernOrJobToolStripMenuItem.Size = New System.Drawing.Size(79, 25)
        Me.RemoveConcernOrJobToolStripMenuItem.Text = "Remove"
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
        Me.WorkOrderDetailsGroup.Location = New System.Drawing.Point(34, 47)
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
        'WorkOrderConcernsDataGridView
        '
        Me.WorkOrderConcernsDataGridView.AllowUserToAddRows = False
        Me.WorkOrderConcernsDataGridView.AllowUserToDeleteRows = False
        Me.WorkOrderConcernsDataGridView.AllowUserToOrderColumns = True
        Me.WorkOrderConcernsDataGridView.AllowUserToResizeRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.WorkOrderConcernsDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.WorkOrderConcernsDataGridView.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.WorkOrderConcernsDataGridView.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
        Me.WorkOrderConcernsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Menu
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.WorkOrderConcernsDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.WorkOrderConcernsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.WorkOrderConcernsDataGridView.DefaultCellStyle = DataGridViewCellStyle4
        Me.WorkOrderConcernsDataGridView.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.WorkOrderConcernsDataGridView.Location = New System.Drawing.Point(624, 134)
        Me.WorkOrderConcernsDataGridView.Name = "WorkOrderConcernsDataGridView"
        Me.WorkOrderConcernsDataGridView.ReadOnly = True
        Me.WorkOrderConcernsDataGridView.RowHeadersVisible = False
        Me.WorkOrderConcernsDataGridView.RowHeadersWidth = 51
        Me.WorkOrderConcernsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.WorkOrderConcernsDataGridView.Size = New System.Drawing.Size(368, 121)
        Me.WorkOrderConcernsDataGridView.TabIndex = 24
        Me.WorkOrderConcernsDataGridView.Visible = False
        '
        'AllWorkOrderPartsDataGridView
        '
        Me.AllWorkOrderPartsDataGridView.AllowUserToAddRows = False
        Me.AllWorkOrderPartsDataGridView.AllowUserToDeleteRows = False
        Me.AllWorkOrderPartsDataGridView.AllowUserToOrderColumns = True
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AllWorkOrderPartsDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.AllWorkOrderPartsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.AllWorkOrderPartsDataGridView.Location = New System.Drawing.Point(34, 320)
        Me.AllWorkOrderPartsDataGridView.MultiSelect = False
        Me.AllWorkOrderPartsDataGridView.Name = "AllWorkOrderPartsDataGridView"
        Me.AllWorkOrderPartsDataGridView.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.AllWorkOrderPartsDataGridView.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.AllWorkOrderPartsDataGridView.RowHeadersWidth = 51
        Me.AllWorkOrderPartsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.AllWorkOrderPartsDataGridView.Size = New System.Drawing.Size(626, 150)
        Me.AllWorkOrderPartsDataGridView.TabIndex = 58
        Me.AllWorkOrderPartsDataGridView.Visible = False
        '
        'WorkOrderFormCRS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(963, 609)
        Me.ControlBox = False
        Me.Controls.Add(Me.WorkOrderDetailsGroup)
        Me.Controls.Add(Me.AllWorkOrderPartsDataGridView)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.WorkOrdersDataGridView)
        Me.Controls.Add(Me.WorkOrderConcernsDataGridView)
        Me.Name = "WorkOrderFormCRS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "WORK ORDERS"
        CType(Me.WorkOrdersDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.WorkOrderDetailsGroup.ResumeLayout(False)
        Me.WorkOrderDetailsGroup.PerformLayout()
        CType(Me.WorkOrderConcernsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AllWorkOrderPartsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents WorkOrdersDataGridView As DataGridView
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
    Friend WithEvents ConcernOrJobToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddWorkOrderConcernToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RemoveConcernOrJobToolStripMenuItem As ToolStripMenuItem
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
    Friend WithEvents PrintBillToolStripMenu As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ForFinalizationBillingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WorkOrderConcernsDataGridView As DataGridView
    Friend WithEvents EditConcernToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AllWorkOrderPartsDataGridView As DataGridView
End Class