<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CityForm
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
        Me.CityDataGridView = New System.Windows.Forms.DataGridView()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CancelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.SearchCityTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.SearchZipCodeTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.CityDetailsGroupBox = New System.Windows.Forms.GroupBox()
        Me.ZipCodeMaskedTextBox = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.StateProvTextBox = New System.Windows.Forms.TextBox()
        Me.CountryTextBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CityTextBox = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.EXITSAVEChangesButton = New System.Windows.Forms.Button()
        CType(Me.CityDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.CityDetailsGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'CityDataGridView
        '
        Me.CityDataGridView.AllowUserToAddRows = False
        Me.CityDataGridView.ColumnHeadersHeight = 26
        Me.CityDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.CityDataGridView.Location = New System.Drawing.Point(0, 54)
        Me.CityDataGridView.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.CityDataGridView.Name = "CityDataGridView"
        Me.CityDataGridView.ReadOnly = True
        Me.CityDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.CityDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.CityDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.CityDataGridView.Size = New System.Drawing.Size(497, 187)
        Me.CityDataGridView.TabIndex = 30
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.SelectToolStripMenuItem, Me.ToolStripMenuItem1, Me.CancelToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1015, 24)
        Me.MenuStrip1.TabIndex = 38
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(41, 20)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'SelectToolStripMenuItem
        '
        Me.SelectToolStripMenuItem.Name = "SelectToolStripMenuItem"
        Me.SelectToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.SelectToolStripMenuItem.Text = "Select"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(12, 20)
        '
        'CancelToolStripMenuItem
        '
        Me.CancelToolStripMenuItem.Name = "CancelToolStripMenuItem"
        Me.CancelToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
        Me.CancelToolStripMenuItem.Text = "Cancel"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.SearchCityTextBox, Me.ToolStripLabel2, Me.SearchZipCodeTextBox})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1015, 25)
        Me.ToolStrip1.TabIndex = 42
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(28, 22)
        Me.ToolStripLabel1.Text = "City"
        '
        'SearchCityTextBox
        '
        Me.SearchCityTextBox.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.SearchCityTextBox.Name = "SearchCityTextBox"
        Me.SearchCityTextBox.Size = New System.Drawing.Size(100, 25)
        Me.SearchCityTextBox.Text = "Search"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(52, 22)
        Me.ToolStripLabel2.Text = "ZipCode"
        '
        'SearchZipCodeTextBox
        '
        Me.SearchZipCodeTextBox.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.SearchZipCodeTextBox.Name = "SearchZipCodeTextBox"
        Me.SearchZipCodeTextBox.Size = New System.Drawing.Size(100, 25)
        Me.SearchZipCodeTextBox.Text = "Search"
        '
        'CityDetailsGroupBox
        '
        Me.CityDetailsGroupBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CityDetailsGroupBox.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.CityDetailsGroupBox.Controls.Add(Me.ZipCodeMaskedTextBox)
        Me.CityDetailsGroupBox.Controls.Add(Me.Label1)
        Me.CityDetailsGroupBox.Controls.Add(Me.StateProvTextBox)
        Me.CityDetailsGroupBox.Controls.Add(Me.CountryTextBox)
        Me.CityDetailsGroupBox.Controls.Add(Me.Label4)
        Me.CityDetailsGroupBox.Controls.Add(Me.Label3)
        Me.CityDetailsGroupBox.Controls.Add(Me.CityTextBox)
        Me.CityDetailsGroupBox.Controls.Add(Me.Label5)
        Me.CityDetailsGroupBox.Controls.Add(Me.EXITSAVEChangesButton)
        Me.CityDetailsGroupBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CityDetailsGroupBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CityDetailsGroupBox.Location = New System.Drawing.Point(385, 0)
        Me.CityDetailsGroupBox.Name = "CityDetailsGroupBox"
        Me.CityDetailsGroupBox.Size = New System.Drawing.Size(362, 220)
        Me.CityDetailsGroupBox.TabIndex = 121
        Me.CityDetailsGroupBox.TabStop = False
        Me.CityDetailsGroupBox.Text = "City Details"
        Me.CityDetailsGroupBox.Visible = False
        '
        'ZipCodeMaskedTextBox
        '
        Me.ZipCodeMaskedTextBox.Location = New System.Drawing.Point(93, 94)
        Me.ZipCodeMaskedTextBox.Mask = "00000"
        Me.ZipCodeMaskedTextBox.Name = "ZipCodeMaskedTextBox"
        Me.ZipCodeMaskedTextBox.Size = New System.Drawing.Size(55, 26)
        Me.ZipCodeMaskedTextBox.TabIndex = 104
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 97)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 20)
        Me.Label1.TabIndex = 103
        Me.Label1.Text = "Zip Code"
        '
        'StateProvTextBox
        '
        Me.StateProvTextBox.Location = New System.Drawing.Point(93, 63)
        Me.StateProvTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.StateProvTextBox.Name = "StateProvTextBox"
        Me.StateProvTextBox.Size = New System.Drawing.Size(238, 26)
        Me.StateProvTextBox.TabIndex = 102
        '
        'CountryTextBox
        '
        Me.CountryTextBox.Location = New System.Drawing.Point(93, 129)
        Me.CountryTextBox.Name = "CountryTextBox"
        Me.CountryTextBox.Size = New System.Drawing.Size(238, 26)
        Me.CountryTextBox.TabIndex = 101
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 136)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 20)
        Me.Label4.TabIndex = 100
        Me.Label4.Text = "Country"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 66)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 20)
        Me.Label3.TabIndex = 99
        Me.Label3.Text = "State"
        '
        'CityTextBox
        '
        Me.CityTextBox.Location = New System.Drawing.Point(93, 29)
        Me.CityTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CityTextBox.Name = "CityTextBox"
        Me.CityTextBox.Size = New System.Drawing.Size(238, 26)
        Me.CityTextBox.TabIndex = 98
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 29)
        Me.Label5.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 20)
        Me.Label5.TabIndex = 97
        Me.Label5.Text = "City"
        '
        'EXITSAVEChangesButton
        '
        Me.EXITSAVEChangesButton.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.EXITSAVEChangesButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EXITSAVEChangesButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.EXITSAVEChangesButton.Location = New System.Drawing.Point(16, 170)
        Me.EXITSAVEChangesButton.Name = "EXITSAVEChangesButton"
        Me.EXITSAVEChangesButton.Size = New System.Drawing.Size(315, 33)
        Me.EXITSAVEChangesButton.TabIndex = 96
        Me.EXITSAVEChangesButton.Text = "EXIT / SAVE Changes"
        Me.EXITSAVEChangesButton.UseVisualStyleBackColor = False
        '
        'CityForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1015, 436)
        Me.ControlBox = False
        Me.Controls.Add(Me.CityDetailsGroupBox)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.CityDataGridView)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CityForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CITIES"
        CType(Me.CityDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.CityDetailsGroupBox.ResumeLayout(False)
        Me.CityDetailsGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CityDataGridView As DataGridView
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents AddToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents CancelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents SearchCityTextBox As ToolStripTextBox
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents SearchZipCodeTextBox As ToolStripTextBox
    Friend WithEvents CityDetailsGroupBox As GroupBox
    Friend WithEvents EXITSAVEChangesButton As Button
    Friend WithEvents ZipCodeMaskedTextBox As MaskedTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents StateProvTextBox As TextBox
    Friend WithEvents CountryTextBox As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents CityTextBox As TextBox
    Friend WithEvents Label5 As Label
End Class
