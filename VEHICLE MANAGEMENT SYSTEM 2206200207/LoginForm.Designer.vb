<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoginForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoginForm))
        Me.LoginBox = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ShowPasswordButton = New System.Windows.Forms.Button()
        Me.PassWordReEnterTextBox = New System.Windows.Forms.TextBox()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.LoginButton = New System.Windows.Forms.Button()
        Me.PasswordTextBox = New System.Windows.Forms.TextBox()
        Me.UsernameTextBox = New System.Windows.Forms.TextBox()
        Me.PasswordLabel = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LogoPictureBox = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.LoginBox.SuspendLayout()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LoginBox
        '
        Me.LoginBox.Controls.Add(Me.Button1)
        Me.LoginBox.Controls.Add(Me.ShowPasswordButton)
        Me.LoginBox.Controls.Add(Me.PassWordReEnterTextBox)
        Me.LoginBox.Controls.Add(Me.Cancel)
        Me.LoginBox.Controls.Add(Me.LoginButton)
        Me.LoginBox.Controls.Add(Me.PasswordTextBox)
        Me.LoginBox.Controls.Add(Me.UsernameTextBox)
        Me.LoginBox.Controls.Add(Me.PasswordLabel)
        Me.LoginBox.Controls.Add(Me.Label1)
        Me.LoginBox.Controls.Add(Me.LogoPictureBox)
        Me.LoginBox.Location = New System.Drawing.Point(2, 1)
        Me.LoginBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.LoginBox.Name = "LoginBox"
        Me.LoginBox.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.LoginBox.Size = New System.Drawing.Size(508, 303)
        Me.LoginBox.TabIndex = 8
        Me.LoginBox.TabStop = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(3, 272)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(498, 24)
        Me.Button1.TabIndex = 19
        Me.Button1.Text = "&Forgot Username or Password"
        '
        'ShowPasswordButton
        '
        Me.ShowPasswordButton.Location = New System.Drawing.Point(3, 215)
        Me.ShowPasswordButton.Name = "ShowPasswordButton"
        Me.ShowPasswordButton.Size = New System.Drawing.Size(141, 32)
        Me.ShowPasswordButton.TabIndex = 18
        Me.ShowPasswordButton.Text = "&Show Password"
        Me.ShowPasswordButton.Visible = False
        '
        'PassWordReEnterTextBox
        '
        Me.PassWordReEnterTextBox.Location = New System.Drawing.Point(181, 178)
        Me.PassWordReEnterTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PassWordReEnterTextBox.Name = "PassWordReEnterTextBox"
        Me.PassWordReEnterTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PassWordReEnterTextBox.Size = New System.Drawing.Size(326, 26)
        Me.PassWordReEnterTextBox.TabIndex = 17
        Me.PassWordReEnterTextBox.Visible = False
        '
        'Cancel
        '
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.Location = New System.Drawing.Point(375, 212)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(94, 32)
        Me.Cancel.TabIndex = 16
        Me.Cancel.Text = "&Cancel"
        '
        'LoginButton
        '
        Me.LoginButton.Location = New System.Drawing.Point(212, 215)
        Me.LoginButton.Name = "LoginButton"
        Me.LoginButton.Size = New System.Drawing.Size(94, 32)
        Me.LoginButton.TabIndex = 15
        Me.LoginButton.Text = "&Login"
        '
        'PasswordTextBox
        '
        Me.PasswordTextBox.Location = New System.Drawing.Point(180, 142)
        Me.PasswordTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PasswordTextBox.Name = "PasswordTextBox"
        Me.PasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PasswordTextBox.Size = New System.Drawing.Size(327, 26)
        Me.PasswordTextBox.TabIndex = 10
        '
        'UsernameTextBox
        '
        Me.UsernameTextBox.Location = New System.Drawing.Point(180, 54)
        Me.UsernameTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UsernameTextBox.Name = "UsernameTextBox"
        Me.UsernameTextBox.Size = New System.Drawing.Size(328, 26)
        Me.UsernameTextBox.TabIndex = 8
        '
        'PasswordLabel
        '
        Me.PasswordLabel.Location = New System.Drawing.Point(177, 111)
        Me.PasswordLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.PasswordLabel.Name = "PasswordLabel"
        Me.PasswordLabel.Size = New System.Drawing.Size(330, 35)
        Me.PasswordLabel.TabIndex = 9
        Me.PasswordLabel.Text = "&Password"
        Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(177, 24)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(330, 35)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "&User name"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LogoPictureBox
        '
        Me.LogoPictureBox.Image = CType(resources.GetObject("LogoPictureBox.Image"), System.Drawing.Image)
        Me.LogoPictureBox.Location = New System.Drawing.Point(3, 11)
        Me.LogoPictureBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.LogoPictureBox.Size = New System.Drawing.Size(141, 193)
        Me.LogoPictureBox.TabIndex = 7
        Me.LogoPictureBox.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'LoginForm
        '
        Me.AcceptButton = Me.LoginButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel
        Me.ClientSize = New System.Drawing.Size(547, 306)
        Me.ControlBox = False
        Me.Controls.Add(Me.LoginBox)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LoginForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.LoginBox.ResumeLayout(False)
        Me.LoginBox.PerformLayout()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LoginBox As GroupBox
    Friend WithEvents PasswordTextBox As TextBox
    Friend WithEvents UsernameTextBox As TextBox
    Friend WithEvents PasswordLabel As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents LogoPictureBox As PictureBox
    Friend WithEvents Cancel As Button
    Friend WithEvents LoginButton As Button
    Friend WithEvents PassWordReEnterTextBox As TextBox
    Friend WithEvents ShowPasswordButton As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Button1 As Button
End Class
