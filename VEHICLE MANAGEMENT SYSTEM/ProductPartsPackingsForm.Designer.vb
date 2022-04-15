<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductPartsPackingsForm
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
        Me.ProductPartsPackingsGroupBox = New System.Windows.Forms.GroupBox()
        Me.PackingDetailsGroupBox = New System.Windows.Forms.GroupBox()
        Me.UnitOfTheQuantityTextBox = New System.Windows.Forms.TextBox()
        Me.QuantityPerPackTextBox = New System.Windows.Forms.TextBox()
        Me.ProductPartsPackingsDataGridView = New System.Windows.Forms.DataGridView()
        Me.ProductsPartsPackingMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.CancelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductPartsPackingsGroupBox.SuspendLayout()
        Me.PackingDetailsGroupBox.SuspendLayout()
        CType(Me.ProductPartsPackingsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ProductsPartsPackingMenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'ProductPartsPackingsGroupBox
        '
        Me.ProductPartsPackingsGroupBox.Controls.Add(Me.ProductPartsPackingsDataGridView)
        Me.ProductPartsPackingsGroupBox.Location = New System.Drawing.Point(13, 55)
        Me.ProductPartsPackingsGroupBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ProductPartsPackingsGroupBox.Name = "ProductPartsPackingsGroupBox"
        Me.ProductPartsPackingsGroupBox.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ProductPartsPackingsGroupBox.Size = New System.Drawing.Size(290, 234)
        Me.ProductPartsPackingsGroupBox.TabIndex = 60
        Me.ProductPartsPackingsGroupBox.TabStop = False
        '
        'PackingDetailsGroupBox
        '
        Me.PackingDetailsGroupBox.Controls.Add(Me.UnitOfTheQuantityTextBox)
        Me.PackingDetailsGroupBox.Controls.Add(Me.QuantityPerPackTextBox)
        Me.PackingDetailsGroupBox.Location = New System.Drawing.Point(335, 212)
        Me.PackingDetailsGroupBox.Name = "PackingDetailsGroupBox"
        Me.PackingDetailsGroupBox.Size = New System.Drawing.Size(269, 44)
        Me.PackingDetailsGroupBox.TabIndex = 92
        Me.PackingDetailsGroupBox.TabStop = False
        Me.PackingDetailsGroupBox.Visible = False
        '
        'UnitOfTheQuantityTextBox
        '
        Me.UnitOfTheQuantityTextBox.Location = New System.Drawing.Point(154, 12)
        Me.UnitOfTheQuantityTextBox.Name = "UnitOfTheQuantityTextBox"
        Me.UnitOfTheQuantityTextBox.Size = New System.Drawing.Size(58, 26)
        Me.UnitOfTheQuantityTextBox.TabIndex = 1
        '
        'QuantityPerPackTextBox
        '
        Me.QuantityPerPackTextBox.Location = New System.Drawing.Point(60, 12)
        Me.QuantityPerPackTextBox.Name = "QuantityPerPackTextBox"
        Me.QuantityPerPackTextBox.Size = New System.Drawing.Size(58, 26)
        Me.QuantityPerPackTextBox.TabIndex = 0
        '
        'ProductPartsPackingsDataGridView
        '
        Me.ProductPartsPackingsDataGridView.AllowUserToAddRows = False
        Me.ProductPartsPackingsDataGridView.AllowUserToDeleteRows = False
        Me.ProductPartsPackingsDataGridView.AllowUserToOrderColumns = True
        Me.ProductPartsPackingsDataGridView.AllowUserToResizeRows = False
        Me.ProductPartsPackingsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ProductPartsPackingsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProductPartsPackingsDataGridView.Location = New System.Drawing.Point(4, 24)
        Me.ProductPartsPackingsDataGridView.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ProductPartsPackingsDataGridView.MultiSelect = False
        Me.ProductPartsPackingsDataGridView.Name = "ProductPartsPackingsDataGridView"
        Me.ProductPartsPackingsDataGridView.ReadOnly = True
        Me.ProductPartsPackingsDataGridView.RowHeadersVisible = False
        Me.ProductPartsPackingsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ProductPartsPackingsDataGridView.Size = New System.Drawing.Size(282, 205)
        Me.ProductPartsPackingsDataGridView.TabIndex = 52
        '
        'ProductsPartsPackingMenuStrip
        '
        Me.ProductsPartsPackingMenuStrip.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProductsPartsPackingMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CancelToolStripMenuItem, Me.SelectToolStripMenuItem, Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.SaveToolStripMenuItem})
        Me.ProductsPartsPackingMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.ProductsPartsPackingMenuStrip.Name = "ProductsPartsPackingMenuStrip"
        Me.ProductsPartsPackingMenuStrip.Padding = New System.Windows.Forms.Padding(22, 8, 0, 8)
        Me.ProductsPartsPackingMenuStrip.Size = New System.Drawing.Size(760, 41)
        Me.ProductsPartsPackingMenuStrip.TabIndex = 91
        '
        'CancelToolStripMenuItem
        '
        Me.CancelToolStripMenuItem.Name = "CancelToolStripMenuItem"
        Me.CancelToolStripMenuItem.Size = New System.Drawing.Size(40, 25)
        Me.CancelToolStripMenuItem.Text = "◄ "
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
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(55, 25)
        Me.SaveToolStripMenuItem.Text = "Save"
        Me.SaveToolStripMenuItem.Visible = False
        '
        'ProductPartsPackingsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(760, 303)
        Me.Controls.Add(Me.PackingDetailsGroupBox)
        Me.Controls.Add(Me.ProductsPartsPackingMenuStrip)
        Me.Controls.Add(Me.ProductPartsPackingsGroupBox)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "ProductPartsPackingsForm"
        Me.Text = "UPDATE DIFFERENT PACKINGS for "
        Me.ProductPartsPackingsGroupBox.ResumeLayout(False)
        Me.PackingDetailsGroupBox.ResumeLayout(False)
        Me.PackingDetailsGroupBox.PerformLayout()
        CType(Me.ProductPartsPackingsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ProductsPartsPackingMenuStrip.ResumeLayout(False)
        Me.ProductsPartsPackingMenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ProductPartsPackingsGroupBox As GroupBox
    Friend WithEvents ProductPartsPackingsDataGridView As DataGridView
    Friend WithEvents ProductsPartsPackingMenuStrip As MenuStrip
    Friend WithEvents SelectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CancelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PackingDetailsGroupBox As GroupBox
    Friend WithEvents UnitOfTheQuantityTextBox As TextBox
    Friend WithEvents QuantityPerPackTextBox As TextBox
End Class
