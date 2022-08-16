Public Class LoginForm
    Private PersonnelFieldsToSelect = ""
    Private PersonnelTablesLinks = ""
    Private PersonnelSelectionFilter = ""
    Private PersonnelSelectionFilterSaved = ""
    Private PersonnelSelectionOrder = ""
    Private FieldsValues = ""
    Private FieldsToReplace = ""
    Private TimerCount As Integer
    Private CurrentPassWordTextBoxClicked As Integer
    Private SavedCallingForm As Form

    Private Sub LoginForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        VehicleManagementSystemForm.VehicleManagementMenuStrip.Visible = True
    End Sub

    Private Sub LoginButton_Click(sender As Object, e As EventArgs) Handles LoginButton.Click
        SavedCallingForm = CallingForm
        '        UserLevelAccess = ""
        Select Case LoginButton.Text
            Case "&Confirm Entry"

                ' VALIDATION SECTION STARTS HERE

                If UsernameTextBox.Text = "Enter new Username" Then
                    UsernameTextBox.Select()
                    Exit Sub
                End If
                If PasswordTextBox.Text = "Enter new Password" Then
                    PasswordTextBox.Select()
                    PasswordTextBox.PasswordChar = "*"
                    Exit Sub
                End If
                If PassWordReEnterTextBox.Text = "Re-Enter new Password" Then
                    PassWordReEnterTextBox.PasswordChar = "*"
                    PassWordReEnterTextBox.Select()
                    Exit Sub
                End If
                If Trim(PasswordTextBox.Text) <> Trim(PassWordReEnterTextBox.Text) Then
                    MsgBox("Password entry does not match")
                    Exit Sub
                End If

                ' VALIDATION SECTION ENDS HERE
                Dim UserToFind = " WHERE UserID_AutoNumber = " & Str(CurrentUserID)

                MySelection = " UPDATE UsersTable SET " &
                              " UserName_ShortText50 = " & Chr(34) & UsernameTextBox.Text & Chr(34) & ", " &
                              " Password_ShortText25 = " & Chr(34) & PasswordTextBox.Text & Chr(34) &
                              UserToFind
                JustExecuteMySelection()
                Tunnel1 = "Login again"
                DoCommonHouseKeeping(Me, SavedCallingForm)
            Case Else
                If UsernameTextBox.Text = "" Then
                    UsernameTextBox.Select()
                    Exit Sub
                End If

                Dim UserToFind = " WHERE ucase(trim(UserName_ShortText50)) = " & Chr(34) & Trim(UsernameTextBox.Text.ToUpper) & Chr(34)

                MySelection = " 
Select 
UsersTable.UserID_AutoNumber,
UsersTable.UserName_ShortText50,
UsersTable.Password_ShortText25,
UsersTable.PersonelID_LongInteger,
PersonnelTable.JobPositionID_LongInteger,
PersonnelTable.LastName_ShortText30,
PersonnelTable.FirstName_ShortText30,
PersonnelTable.NamePrefix_ShortText3,
JobPositionsTable.JobPositionName_ShortText40,
DepartmentsTable.DepartmentName_ShortText35
 FROM ((UsersTable LEFT JOIN PersonnelTable ON UsersTable.PersonelID_LongInteger = PersonnelTable.PersonnelID_AutoNumber) LEFT JOIN JobPositionsTable ON PersonnelTable.[JobPositionID_LongInteger] = JobPositionsTable.JobPositionID_AutoNumber) LEFT JOIN DepartmentsTable ON JobPositionsTable.DepartmentID_LongInteger = DepartmentsTable.DepartmentID_AutoNumber 
 " &
            UserToFind
                CurrentUserID = -1
                CurrentPersonelID = -1
                CurrentPersonnelName = ""

                JustExecuteMySelection()
                If RecordCount = 0 Then
                    MsgBox("Invalid Username or Password !")
                    Exit Sub
                End If
                '  HERE USER RELATED INFORMATIONS WILL ALREADY BE AVAILABLE
                '  SET THE VALUES OF THE USER VARIABLES

                r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
                CurrentUserID = r("UserID_AutoNumber")
                CurrentPersonelID = r("PersonelID_LongInteger")
                CurrentUserGroup = r("JobPositionName_ShortText40")
                CurrentDepartment = r("DepartmentName_ShortText35")
                Dim FirstName = Trim(IIf(IsDBNull(r("FirstName_ShortText30")), "", r("FirstName_ShortText30")))
                Dim LastName = Trim(IIf(IsDBNull(r("LastName_ShortText30")), "", r("LastName_ShortText30")))
                CurrentPersonnelName = FirstName & " " & LastName

                If IsDBNull(r("Password_ShortText25")) Then
                    CurrentPassword = ""
                Else
                    CurrentPassword = r("Password_ShortText25")
                End If

                MsgBox("PASSWORD CHECKING is bypassed during the development stage, DEBUG here to restore")
                Dim bypass = True
                If Not bypass Then

                    If CurrentPassword = "" Then
                        '           regardless of user typed on the password textbox, the user Is directed to
                        '           the routine CreateUserNameAndPassword which allows the user to enter New username And password
                        '           THEN IT HAS BEEN SET TO UPDATE USERNAME AND PASSWORD
                        If Not MsgBox("Is This you " & CurrentPersonnelName & " ?", vbYesNo) = vbYes Then
                            UsernameTextBox.Text = ""
                            UsernameTextBox.Select()
                            Exit Sub
                        End If
                        CreateUserNameAndPassword()
                        '           Clear login entries then allow the user to reenter login informations
                        Exit Sub
                    End If

                    '           AT THIS POINT THERE EXIST A PASSWORD STORED
                    '           did the user entered a password, at this juncture
                    '           a password is a must

                    If PasswordTextBox.Text = "" Then ' ocurs when the login command was pressed witout password entered
                        PasswordTextBox.Select()
                        Exit Sub
                    End If

                    '           password exists
                    '           USER INPUTTED PASSWORD

                    If PasswordTextBox.Text <> CurrentPassword Then
                        MsgBox("Invalid Username or Password !")
                        Exit Sub
                    End If

                End If
                DoCommonHouseKeeping(Me, SavedCallingForm)
        End Select

    End Sub
    Private Sub UpdateUserNameAndPassword()

        ' create the user record
        FieldsToReplace = "" &
            "UserName_ShortText50, " &
            "Password_ShortText25 "

        FieldsValues = "" &
            Chr(34) & Trim(UsernameTextBox.Text) & Chr(34) & ", " &
            Chr(34) & Trim(PasswordTextBox.Text) & Chr(34)


        MySelection = "INSERT INTO UsersTable  (" & FieldsToReplace & ") VALUES (" & FieldsValues & ")"

        JustExecuteMySelection()
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub
    Private Sub UsernameTextBox_TextChanged(sender As Object, e As EventArgs) Handles UsernameTextBox.Click
        If UsernameTextBox.Text = "Enter new Username" Then
            UsernameTextBox.Text = ""
        End If
        ShowPasswordButton.Visible = False
    End Sub
    Private Sub UsernameTextBox_TextChanged_1(sender As Object, e As EventArgs) Handles UsernameTextBox.TextChanged
        If Len(Trim(UsernameTextBox.Text)) > 50 Then
            UsernameTextBox.Text = UsernameTextBox.Text.Substring(1, 50)
        End If
    End Sub

    Private Sub PasswordTextBox_Click(sender As Object, e As EventArgs) Handles PasswordTextBox.Click
        If PasswordTextBox.Text = "Enter new Password" Then
            PasswordTextBox.Text = ""
            PasswordTextBox.PasswordChar = "*"
        End If
        ShowPasswordButton.Visible = True
        CurrentPassWordTextBoxClicked = 1
    End Sub
    Private Sub PasswordTextBox_TextChanged(sender As Object, e As EventArgs) Handles PasswordTextBox.TextChanged
        If Len(Trim(PasswordTextBox.Text)) > 25 Then
            PasswordTextBox.Text = PasswordTextBox.Text.Substring(0, 25)
        End If

    End Sub

    Private Sub PasswordReEnterTextBox_TextChanged(sender As Object, e As EventArgs) Handles PassWordReEnterTextBox.Click
        If PassWordReEnterTextBox.Text = "Re-Enter new Password" Then
            PassWordReEnterTextBox.Text = ""
            PassWordReEnterTextBox.PasswordChar = "*"
        End If
        ShowPasswordButton.Visible = True
        CurrentPassWordTextBoxClicked = 2
    End Sub


    Private Function CreateUserNameAndPassword()

        UsernameTextBox.Text = "Enter new Username"
        PasswordTextBox.Text = "Enter new Password"
        PassWordReEnterTextBox.Text = "Re-Enter new Password"
        PassWordReEnterTextBox.Visible = True


        PasswordTextBox.PasswordChar = ""
        PassWordReEnterTextBox.PasswordChar = ""

        LoginButton.Text = "&Confirm Entry"

        Return True
    End Function

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Application.Exit()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ShowPasswordButton.Text = TimerCount.ToString
        If TimerCount = 0 Then
            Timer1.Enabled = False
            ShowPasswordButton.Text = "&Show Password"
            Timer1.Enabled = False
            If CurrentPassWordTextBoxClicked = 1 Then
                PasswordTextBox.PasswordChar = "*"
            Else
                PassWordReEnterTextBox.PasswordChar = "*"
            End If
        Else
            TimerCount -= 1
        End If
    End Sub

    Private Sub ShowPasswordButton_Click(sender As Object, e As EventArgs) Handles ShowPasswordButton.Click
        Timer1.Interval = 100
        If CurrentPassWordTextBoxClicked = 1 Then
            If PasswordTextBox.Text = "Enter new Password" Then
                PasswordTextBox.PasswordChar = ""
                Exit Sub
            End If
        End If
        If CurrentPassWordTextBoxClicked = 2 Then
            If PassWordReEnterTextBox.Text = "Enter new Password" Then
                PassWordReEnterTextBox.PasswordChar = ""
                Exit Sub
            End If
        End If

        TimerCount = 10
        Timer1.Enabled = True
        If CurrentPassWordTextBoxClicked = 1 Then
            PasswordTextBox.PasswordChar = ""
        Else
            PassWordReEnterTextBox.PasswordChar = ""
        End If
    End Sub
    Private Sub PasswordReEnterTextBox_Leave(sender As Object, e As EventArgs) Handles PassWordReEnterTextBox.Leave
        If PassWordReEnterTextBox.Text = "Re-Enter new Password" Then
            PassWordReEnterTextBox.PasswordChar = ""
        End If

    End Sub

End Class