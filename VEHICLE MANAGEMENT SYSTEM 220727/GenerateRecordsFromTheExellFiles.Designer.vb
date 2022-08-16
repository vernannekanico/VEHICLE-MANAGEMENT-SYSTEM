<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GenerateRecordsForm
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
        Me.GenerateWorkOrdersButton = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.UpdatedTableDataGridView = New System.Windows.Forms.DataGridView()
        Me.STATUSButton = New System.Windows.Forms.Button()
        Me.PartsDataGridView = New System.Windows.Forms.DataGridView()
        CType(Me.UpdatedTableDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PartsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GenerateWorkOrdersButton
        '
        Me.GenerateWorkOrdersButton.Location = New System.Drawing.Point(39, 47)
        Me.GenerateWorkOrdersButton.Name = "GenerateWorkOrdersButton"
        Me.GenerateWorkOrdersButton.Size = New System.Drawing.Size(232, 23)
        Me.GenerateWorkOrdersButton.TabIndex = 0
        Me.GenerateWorkOrdersButton.Text = "Generate Work Orders"
        Me.GenerateWorkOrdersButton.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(370, 50)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(147, 20)
        Me.TextBox1.TabIndex = 1
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(580, 50)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(186, 20)
        Me.TextBox2.TabIndex = 2
        '
        'UpdatedTableDataGridView
        '
        Me.UpdatedTableDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.UpdatedTableDataGridView.Location = New System.Drawing.Point(31, 149)
        Me.UpdatedTableDataGridView.Name = "UpdatedTableDataGridView"
        Me.UpdatedTableDataGridView.Size = New System.Drawing.Size(721, 472)
        Me.UpdatedTableDataGridView.TabIndex = 3
        '
        'STATUSButton
        '
        Me.STATUSButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.STATUSButton.Location = New System.Drawing.Point(79, 87)
        Me.STATUSButton.Name = "STATUSButton"
        Me.STATUSButton.Size = New System.Drawing.Size(630, 45)
        Me.STATUSButton.TabIndex = 4
        Me.STATUSButton.Text = "Generate Work Orders"
        Me.STATUSButton.UseVisualStyleBackColor = True
        '
        'PartsDataGridView
        '
        Me.PartsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.PartsDataGridView.Location = New System.Drawing.Point(772, 149)
        Me.PartsDataGridView.Name = "PartsDataGridView"
        Me.PartsDataGridView.Size = New System.Drawing.Size(723, 150)
        Me.PartsDataGridView.TabIndex = 5
        '
        'GenerateRecordsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1507, 672)
        Me.Controls.Add(Me.PartsDataGridView)
        Me.Controls.Add(Me.STATUSButton)
        Me.Controls.Add(Me.UpdatedTableDataGridView)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.GenerateWorkOrdersButton)
        Me.Name = "GenerateRecordsForm"
        Me.Text = "Generate Records From The Exel Files."
        CType(Me.UpdatedTableDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PartsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GenerateWorkOrdersButton As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents UpdatedTableDataGridView As DataGridView
    Friend WithEvents STATUSButton As Button
    Friend WithEvents PartsDataGridView As DataGridView
End Class
