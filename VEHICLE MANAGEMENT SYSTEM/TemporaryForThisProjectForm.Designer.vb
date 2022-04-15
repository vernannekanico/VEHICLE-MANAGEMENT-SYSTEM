<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TemporaryForThisProjectForm
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
        Me.JobsHistoryDataGridView = New System.Windows.Forms.DataGridView()
        CType(Me.JobsHistoryDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'JobsHistoryDataGridView
        '
        Me.JobsHistoryDataGridView.AllowUserToAddRows = False
        Me.JobsHistoryDataGridView.AllowUserToDeleteRows = False
        Me.JobsHistoryDataGridView.AllowUserToOrderColumns = True
        Me.JobsHistoryDataGridView.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.JobsHistoryDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.JobsHistoryDataGridView.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.JobsHistoryDataGridView.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
        Me.JobsHistoryDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Menu
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.JobsHistoryDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.JobsHistoryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.JobsHistoryDataGridView.DefaultCellStyle = DataGridViewCellStyle3
        Me.JobsHistoryDataGridView.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.JobsHistoryDataGridView.Location = New System.Drawing.Point(548, 197)
        Me.JobsHistoryDataGridView.Name = "JobsHistoryDataGridView"
        Me.JobsHistoryDataGridView.ReadOnly = True
        Me.JobsHistoryDataGridView.RowHeadersVisible = False
        Me.JobsHistoryDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.JobsHistoryDataGridView.Size = New System.Drawing.Size(233, 121)
        Me.JobsHistoryDataGridView.TabIndex = 99
        '
        'TemporaryForThisProjectForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1328, 514)
        Me.Controls.Add(Me.JobsHistoryDataGridView)
        Me.Name = "TemporaryForThisProjectForm"
        Me.Text = "TempoearyForThisProjectForm"
        CType(Me.JobsHistoryDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents JobsHistoryDataGridView As DataGridView
End Class
