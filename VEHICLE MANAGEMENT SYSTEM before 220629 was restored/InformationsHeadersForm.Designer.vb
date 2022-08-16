<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class InformationsHeadersForm
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
        Me.AddHeaderInformationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectMasterCodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditInformationsHeaderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveHeaderInformationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CodeBookFilterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CodeBookDescriptionToolStripTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.InformationsHeadersDataGridView = New System.Windows.Forms.DataGridView()
        Me.ModifyGroupBox = New System.Windows.Forms.GroupBox()
        Me.TSBPefixLabel = New System.Windows.Forms.Label()
        Me.TSBCodeTextBox = New System.Windows.Forms.TextBox()
        Me.NewInformationCodeAppexTextBox = New System.Windows.Forms.TextBox()
        Me.ParentCodeLabel = New System.Windows.Forms.Label()
        Me.InformationCODELabel = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.InformationHeaderTypesComboBox = New System.Windows.Forms.ComboBox()
        Me.InformationHeaderTextBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SearchToolStrip = New System.Windows.Forms.ToolStrip()
        Me.SearchToolStripLabel = New System.Windows.Forms.ToolStripLabel()
        Me.SearchInformationHeadersTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.TSBToolStripLabel = New System.Windows.Forms.ToolStripLabel()
        Me.ConcernTypePrefixComboBox = New System.Windows.Forms.ComboBox()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.InformationsHeadersDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ModifyGroupBox.SuspendLayout()
        Me.SearchToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CancelToolStripMenuItem, Me.AddHeaderInformationToolStripMenuItem, Me.SelectMasterCodeToolStripMenuItem, Me.EditInformationsHeaderToolStripMenuItem, Me.SaveHeaderInformationToolStripMenuItem, Me.CodeBookFilterToolStripMenuItem, Me.CodeBookDescriptionToolStripTextBox})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(9, 3, 0, 3)
        Me.MenuStrip1.Size = New System.Drawing.Size(1587, 38)
        Me.MenuStrip1.TabIndex = 48
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'CancelToolStripMenuItem
        '
        Me.CancelToolStripMenuItem.Name = "CancelToolStripMenuItem"
        Me.CancelToolStripMenuItem.Size = New System.Drawing.Size(48, 32)
        Me.CancelToolStripMenuItem.Text = "◄ "
        '
        'AddHeaderInformationToolStripMenuItem
        '
        Me.AddHeaderInformationToolStripMenuItem.Name = "AddHeaderInformationToolStripMenuItem"
        Me.AddHeaderInformationToolStripMenuItem.Size = New System.Drawing.Size(63, 32)
        Me.AddHeaderInformationToolStripMenuItem.Text = "Add"
        '
        'SelectMasterCodeToolStripMenuItem
        '
        Me.SelectMasterCodeToolStripMenuItem.Name = "SelectMasterCodeToolStripMenuItem"
        Me.SelectMasterCodeToolStripMenuItem.Size = New System.Drawing.Size(78, 32)
        Me.SelectMasterCodeToolStripMenuItem.Text = "Select"
        '
        'EditInformationsHeaderToolStripMenuItem
        '
        Me.EditInformationsHeaderToolStripMenuItem.Name = "EditInformationsHeaderToolStripMenuItem"
        Me.EditInformationsHeaderToolStripMenuItem.Size = New System.Drawing.Size(60, 32)
        Me.EditInformationsHeaderToolStripMenuItem.Text = "Edit"
        '
        'SaveHeaderInformationToolStripMenuItem
        '
        Me.SaveHeaderInformationToolStripMenuItem.Name = "SaveHeaderInformationToolStripMenuItem"
        Me.SaveHeaderInformationToolStripMenuItem.Size = New System.Drawing.Size(67, 32)
        Me.SaveHeaderInformationToolStripMenuItem.Text = "Save"
        '
        'CodeBookFilterToolStripMenuItem
        '
        Me.CodeBookFilterToolStripMenuItem.Name = "CodeBookFilterToolStripMenuItem"
        Me.CodeBookFilterToolStripMenuItem.Size = New System.Drawing.Size(105, 32)
        Me.CodeBookFilterToolStripMenuItem.Text = "Filter ON"
        '
        'CodeBookDescriptionToolStripTextBox
        '
        Me.CodeBookDescriptionToolStripTextBox.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.CodeBookDescriptionToolStripTextBox.Name = "CodeBookDescriptionToolStripTextBox"
        Me.CodeBookDescriptionToolStripTextBox.Size = New System.Drawing.Size(100, 32)
        '
        'InformationsHeadersDataGridView
        '
        Me.InformationsHeadersDataGridView.AllowUserToAddRows = False
        Me.InformationsHeadersDataGridView.AllowUserToDeleteRows = False
        Me.InformationsHeadersDataGridView.AllowUserToOrderColumns = True
        Me.InformationsHeadersDataGridView.AllowUserToResizeRows = False
        Me.InformationsHeadersDataGridView.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.InformationsHeadersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.InformationsHeadersDataGridView.Location = New System.Drawing.Point(198, 141)
        Me.InformationsHeadersDataGridView.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.InformationsHeadersDataGridView.MultiSelect = False
        Me.InformationsHeadersDataGridView.Name = "InformationsHeadersDataGridView"
        Me.InformationsHeadersDataGridView.ReadOnly = True
        Me.InformationsHeadersDataGridView.RowHeadersVisible = False
        Me.InformationsHeadersDataGridView.RowHeadersWidth = 51
        Me.InformationsHeadersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.InformationsHeadersDataGridView.Size = New System.Drawing.Size(506, 160)
        Me.InformationsHeadersDataGridView.TabIndex = 46
        '
        'ModifyGroupBox
        '
        Me.ModifyGroupBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ModifyGroupBox.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ModifyGroupBox.Controls.Add(Me.TSBPefixLabel)
        Me.ModifyGroupBox.Controls.Add(Me.TSBCodeTextBox)
        Me.ModifyGroupBox.Controls.Add(Me.NewInformationCodeAppexTextBox)
        Me.ModifyGroupBox.Controls.Add(Me.ParentCodeLabel)
        Me.ModifyGroupBox.Controls.Add(Me.InformationCODELabel)
        Me.ModifyGroupBox.Controls.Add(Me.Label1)
        Me.ModifyGroupBox.Controls.Add(Me.InformationHeaderTypesComboBox)
        Me.ModifyGroupBox.Controls.Add(Me.InformationHeaderTextBox)
        Me.ModifyGroupBox.Controls.Add(Me.Label3)
        Me.ModifyGroupBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ModifyGroupBox.Location = New System.Drawing.Point(399, 303)
        Me.ModifyGroupBox.Name = "ModifyGroupBox"
        Me.ModifyGroupBox.Size = New System.Drawing.Size(953, 136)
        Me.ModifyGroupBox.TabIndex = 68
        Me.ModifyGroupBox.TabStop = False
        Me.ModifyGroupBox.Visible = False
        '
        'TSBPefixLabel
        '
        Me.TSBPefixLabel.AutoSize = True
        Me.TSBPefixLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSBPefixLabel.Location = New System.Drawing.Point(6, 82)
        Me.TSBPefixLabel.Name = "TSBPefixLabel"
        Me.TSBPefixLabel.Size = New System.Drawing.Size(63, 25)
        Me.TSBPefixLabel.TabIndex = 83
        Me.TSBPefixLabel.Text = "TSB-"
        Me.TSBPefixLabel.Visible = False
        '
        'TSBCodeTextBox
        '
        Me.TSBCodeTextBox.Location = New System.Drawing.Point(49, 79)
        Me.TSBCodeTextBox.Name = "TSBCodeTextBox"
        Me.TSBCodeTextBox.Size = New System.Drawing.Size(179, 30)
        Me.TSBCodeTextBox.TabIndex = 82
        Me.TSBCodeTextBox.Visible = False
        '
        'NewInformationCodeAppexTextBox
        '
        Me.NewInformationCodeAppexTextBox.Location = New System.Drawing.Point(325, 41)
        Me.NewInformationCodeAppexTextBox.Name = "NewInformationCodeAppexTextBox"
        Me.NewInformationCodeAppexTextBox.Size = New System.Drawing.Size(45, 30)
        Me.NewInformationCodeAppexTextBox.TabIndex = 83
        Me.NewInformationCodeAppexTextBox.Text = "01"
        Me.NewInformationCodeAppexTextBox.Visible = False
        '
        'ParentCodeLabel
        '
        Me.ParentCodeLabel.AutoSize = True
        Me.ParentCodeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ParentCodeLabel.Location = New System.Drawing.Point(171, 41)
        Me.ParentCodeLabel.Name = "ParentCodeLabel"
        Me.ParentCodeLabel.Size = New System.Drawing.Size(180, 25)
        Me.ParentCodeLabel.TabIndex = 82
        Me.ParentCodeLabel.Text = "ParentCodeLabel"
        Me.ParentCodeLabel.Visible = False
        '
        'InformationCODELabel
        '
        Me.InformationCODELabel.AutoSize = True
        Me.InformationCODELabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InformationCODELabel.Location = New System.Drawing.Point(27, 41)
        Me.InformationCODELabel.Name = "InformationCODELabel"
        Me.InformationCODELabel.Size = New System.Drawing.Size(200, 25)
        Me.InformationCODELabel.TabIndex = 70
        Me.InformationCODELabel.Text = "Information CODE :"
        Me.InformationCODELabel.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(27, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(252, 29)
        Me.Label1.TabIndex = 69
        Me.Label1.Text = "Type of Information :"
        '
        'InformationHeaderTypesComboBox
        '
        Me.InformationHeaderTypesComboBox.FormattingEnabled = True
        Me.InformationHeaderTypesComboBox.Location = New System.Drawing.Point(234, 37)
        Me.InformationHeaderTypesComboBox.Name = "InformationHeaderTypesComboBox"
        Me.InformationHeaderTypesComboBox.Size = New System.Drawing.Size(470, 33)
        Me.InformationHeaderTypesComboBox.TabIndex = 68
        '
        'InformationHeaderTextBox
        '
        Me.InformationHeaderTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InformationHeaderTextBox.Location = New System.Drawing.Point(234, 77)
        Me.InformationHeaderTextBox.Name = "InformationHeaderTextBox"
        Me.InformationHeaderTextBox.Size = New System.Drawing.Size(696, 34)
        Me.InformationHeaderTextBox.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(27, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(193, 29)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "INFORMATION"
        '
        'SearchToolStrip
        '
        Me.SearchToolStrip.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchToolStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.SearchToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SearchToolStripLabel, Me.SearchInformationHeadersTextBox, Me.TSBToolStripLabel})
        Me.SearchToolStrip.Location = New System.Drawing.Point(0, 38)
        Me.SearchToolStrip.Name = "SearchToolStrip"
        Me.SearchToolStrip.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.SearchToolStrip.Size = New System.Drawing.Size(1587, 34)
        Me.SearchToolStrip.TabIndex = 80
        Me.SearchToolStrip.Text = "ToolStrip1"
        '
        'SearchToolStripLabel
        '
        Me.SearchToolStripLabel.Name = "SearchToolStripLabel"
        Me.SearchToolStripLabel.Size = New System.Drawing.Size(84, 31)
        Me.SearchToolStripLabel.Text = "SEARCH"
        '
        'SearchInformationHeadersTextBox
        '
        Me.SearchInformationHeadersTextBox.Font = New System.Drawing.Font("Segoe UI", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchInformationHeadersTextBox.Name = "SearchInformationHeadersTextBox"
        Me.SearchInformationHeadersTextBox.Size = New System.Drawing.Size(300, 34)
        '
        'TSBToolStripLabel
        '
        Me.TSBToolStripLabel.Name = "TSBToolStripLabel"
        Me.TSBToolStripLabel.Size = New System.Drawing.Size(110, 31)
        Me.TSBToolStripLabel.Text = "TSB listings"
        '
        'ConcernTypePrefixComboBox
        '
        Me.ConcernTypePrefixComboBox.FormattingEnabled = True
        Me.ConcernTypePrefixComboBox.Location = New System.Drawing.Point(608, 34)
        Me.ConcernTypePrefixComboBox.Name = "ConcernTypePrefixComboBox"
        Me.ConcernTypePrefixComboBox.Size = New System.Drawing.Size(374, 33)
        Me.ConcernTypePrefixComboBox.TabIndex = 81
        '
        'InformationsHeadersForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1587, 772)
        Me.Controls.Add(Me.ConcernTypePrefixComboBox)
        Me.Controls.Add(Me.SearchToolStrip)
        Me.Controls.Add(Me.ModifyGroupBox)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.InformationsHeadersDataGridView)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "InformationsHeadersForm"
        Me.Text = "Informations Header"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.InformationsHeadersDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ModifyGroupBox.ResumeLayout(False)
        Me.ModifyGroupBox.PerformLayout()
        Me.SearchToolStrip.ResumeLayout(False)
        Me.SearchToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents CancelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddHeaderInformationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InformationsHeadersDataGridView As DataGridView
    Friend WithEvents SelectMasterCodeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditInformationsHeaderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveHeaderInformationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ModifyGroupBox As GroupBox
    Friend WithEvents InformationHeaderTextBox As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents SearchToolStrip As ToolStrip
    Friend WithEvents SearchToolStripLabel As ToolStripLabel
    Friend WithEvents SearchInformationHeadersTextBox As ToolStripTextBox
    Friend WithEvents ConcernTypePrefixComboBox As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents InformationHeaderTypesComboBox As ComboBox
    Friend WithEvents NewInformationCodeAppexTextBox As TextBox
    Friend WithEvents ParentCodeLabel As Label
    Friend WithEvents InformationCODELabel As Label
    Friend WithEvents TSBPefixLabel As Label
    Friend WithEvents TSBCodeTextBox As TextBox
    Friend WithEvents TSBToolStripLabel As ToolStripLabel
    Friend WithEvents CodeBookFilterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CodeBookDescriptionToolStripTextBox As ToolStripTextBox
End Class
