<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ProductPartsPackingRelationsForm
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
        Me.ProductPartsPackingRelationsGroupBox = New System.Windows.Forms.GroupBox()
        Me.ProductPartsPackingRelationsDataGridView = New System.Windows.Forms.DataGridView()
        Me.ProductsPartsPackingMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.CancelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductPartsPackingRelationsGroupBox.SuspendLayout()
        CType(Me.ProductPartsPackingRelationsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ProductsPartsPackingMenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'ProductPartsPackingRelationsGroupBox
        '
        Me.ProductPartsPackingRelationsGroupBox.Controls.Add(Me.ProductPartsPackingRelationsDataGridView)
        Me.ProductPartsPackingRelationsGroupBox.Location = New System.Drawing.Point(13, 55)
        Me.ProductPartsPackingRelationsGroupBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ProductPartsPackingRelationsGroupBox.Name = "ProductPartsPackingRelationsGroupBox"
        Me.ProductPartsPackingRelationsGroupBox.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ProductPartsPackingRelationsGroupBox.Size = New System.Drawing.Size(290, 234)
        Me.ProductPartsPackingRelationsGroupBox.TabIndex = 60
        Me.ProductPartsPackingRelationsGroupBox.TabStop = False
        '
        'ProductPartsPackingRelationsDataGridView
        '
        Me.ProductPartsPackingRelationsDataGridView.AllowUserToAddRows = False
        Me.ProductPartsPackingRelationsDataGridView.AllowUserToDeleteRows = False
        Me.ProductPartsPackingRelationsDataGridView.AllowUserToOrderColumns = True
        Me.ProductPartsPackingRelationsDataGridView.AllowUserToResizeRows = False
        Me.ProductPartsPackingRelationsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ProductPartsPackingRelationsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProductPartsPackingRelationsDataGridView.Location = New System.Drawing.Point(4, 24)
        Me.ProductPartsPackingRelationsDataGridView.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ProductPartsPackingRelationsDataGridView.MultiSelect = False
        Me.ProductPartsPackingRelationsDataGridView.Name = "ProductPartsPackingRelationsDataGridView"
        Me.ProductPartsPackingRelationsDataGridView.ReadOnly = True
        Me.ProductPartsPackingRelationsDataGridView.RowHeadersVisible = False
        Me.ProductPartsPackingRelationsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ProductPartsPackingRelationsDataGridView.Size = New System.Drawing.Size(282, 205)
        Me.ProductPartsPackingRelationsDataGridView.TabIndex = 52
        '
        'ProductsPartsPackingMenuStrip
        '
        Me.ProductsPartsPackingMenuStrip.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProductsPartsPackingMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CancelToolStripMenuItem, Me.SelectToolStripMenuItem, Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.RemoveToolStripMenuItem})
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
        'RemoveToolStripMenuItem
        '
        Me.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem"
        Me.RemoveToolStripMenuItem.Size = New System.Drawing.Size(79, 25)
        Me.RemoveToolStripMenuItem.Text = "Remove"
        '
        'ProductPartsPackingRelationsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(760, 303)
        Me.Controls.Add(Me.ProductsPartsPackingMenuStrip)
        Me.Controls.Add(Me.ProductPartsPackingRelationsGroupBox)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "ProductPartsPackingRelationsForm"
        Me.Text = "UPDATE DIFFERENT PACKINGS for "
        Me.ProductPartsPackingRelationsGroupBox.ResumeLayout(False)
        CType(Me.ProductPartsPackingRelationsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ProductsPartsPackingMenuStrip.ResumeLayout(False)
        Me.ProductsPartsPackingMenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ProductPartsPackingRelationsGroupBox As GroupBox
    Friend WithEvents ProductPartsPackingRelationsDataGridView As DataGridView
    Friend WithEvents ProductsPartsPackingMenuStrip As MenuStrip
    Friend WithEvents SelectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RemoveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CancelToolStripMenuItem As ToolStripMenuItem
End Class
