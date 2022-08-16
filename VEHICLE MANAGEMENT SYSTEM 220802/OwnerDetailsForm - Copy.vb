Public Class OwnerDetailsForm
    Private CurrentOwnerID As Double = 0
    Private CurrentCityID As Double = 0
    Private PurposeOfEntry As String
    Dim PhoneNumber = ""
    'SELECT OwnerTable.OwnerID_AutoNumber, OwnerTable.LastName_ShortText15, OwnerTable.FirstName_ShortText15, OwnerTable.NamePrefix_ShortText3, OwnerTable.NickName_ShortText15, OwnerTable.[CityID_LongInteger], [CityTable].TelNo_ShortText10, [CityTable].EmailCity_ShortText20, [CityTable].Street_ShortText25, [CityTable].BldgAptRmNo_ShortText25, [CityTable].ZipCodeID_LongInteger
    'FROM OwnerTable LEFT JOIN CityTable On OwnerTable.[CityID_LongInteger]=[CityTable].[CityID_AutoNumber];

    Private Sub OwnerDetailsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CurrentCityID = 0
        CurrentOwnerID = 0
        OwnerForm.Enabled = False
        PurposeOfEntry = Tunnel1
        Select Case PurposeOfEntry
            Case "ADD"
                CountryTextBox.Text = DefaultCountryName
                StateProvTextBox.Text = DefaultStateName
                LastNameTextBox.Select()
            Case "EDIT"
                CurrentOwnerID = Val(Tunnel2)

            Case "DELETE"
                CurrentOwnerID = Val(Tunnel2)
        End Select
        ResetTunnels()
    End Sub

    Private Function OwnerFieldsEntriesAreNotValidAndComplete()
        If Trim(LastNameTextBox.Text) = "" Then
            LastNameTextBox.Select()
            Return True
        Else
            If Trim(FirstNameTextBox.Text) = "" Then
                FirstNameTextBox.Select()
                Return True
            Else
                PhoneNumber = PhoneNumberTextBox.Text

                PhoneNumber = Replace(PhoneNumber, "(", "")
                PhoneNumber = Replace(PhoneNumber, ")", "")
                PhoneNumber = Replace(PhoneNumber, "-", "")
                PhoneNumber = Replace(PhoneNumber, " ", "")
                If Len(PhoneNumber) <> 10 Then
                    PhoneNumberTextBox.Select()
                    Return True
                End If
            End If
        End If
        If Len(LastNameTextBox.Text) > 15 Then
            LastNameTextBox.Text = LastNameTextBox.Text.Substring(0, 14)
            LastNameTextBox.Select()
            Return True
        End If
        If Len(FirstNameTextBox.Text) > 15 Then
            FirstNameTextBox.Text = LastNameTextBox.Text.Substring(0, 14)
            FirstNameTextBox.Select()
            Return True
        End If
        If Len(NamePrefixTextBox.Text) > 3 Then
            NamePrefixTextBox.Text = NamePrefixTextBox.Text.Substring(0, 2)
            NamePrefixTextBox.Select()
            Return True
        End If
        If Len(AliasTextBox.Text) > 15 Then
            AliasTextBox.Text = AliasTextBox.Text.Substring(0, 14)
            AliasTextBox.Select()
            Return True
        End If
        If Len(EmailAddressTextBox.Text) > 20 Then
            EmailAddressTextBox.Text = EmailAddressTextBox.Text.Substring(0, 19)
            EmailAddressTextBox.Select()
            Return True
        End If
        If Len(StreetTextBox.Text) > 25 Then
            StreetTextBox.Text = StreetTextBox.Text.Substring(0, 24)
            StreetTextBox.Select()
            Return True
        End If
        If Len(BldgAptRmNoTextBox.Text) > 25 Then
            BldgAptRmNoTextBox.Text = StreetTextBox.Text.Substring(0, 24)
            BldgAptRmNoTextBox.Select()
            Return True
        End If
        Return False
    End Function

    Private Sub OwnerDetailsForm_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed
        'Fills up tunnel1, tunnel2
        'Enables calling form

        OwnerForm.Enabled = True
        ActivatedBy.Text = ""

    End Sub

    Private Sub OwnerDetailsForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        'Refresh datagridviw here
        ' GET RETURNED DATA HERE
        If Me.Enabled = True Then
            If NotEmpty(Tunnel1) Then
                CurrentCityID = Tunnel1
            End If
        End If
    End Sub

    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        Select Case PurposeOfEntry
            Case "ADD"
                If Trim(LastNameTextBox.Text) = "" Then
                    If Trim(FirstNameTextBox.Text) = "" Then
                        GoTo CancelEntry
                    End If
                End If
                Dim CancelEntry
                CancelEntry = MsgBox("You have Entries, Do you want to CANCEL your entry?", MsgBoxStyle.YesNo)
                If CancelEntry = vbYes Then GoTo CancelEntry
                Exit Sub
            Case "EDIT"
                Dim CancelEntry
                CancelEntry = MsgBox("Do you want to EXIT without changes?", vbYesNo)
                If CancelEntry = vbYes Then GoTo CancelEntry
                Exit Sub
            Case Else
        End Select
CancelEntry:
        Me.Close()
    End Sub

    Private Sub SetOwnerTableFieldParameters()
        RecordFinderDbControls.AddParam("@OwnerID_AutoNumber", Str(CurrentOwnerID))
        RecordFinderDbControls.AddParam("@LastName_ShortText15", Trim(LastNameTextBox.Text))
        RecordFinderDbControls.AddParam("@FirstName_ShortText15", Trim(FirstNameTextBox.Text))
        RecordFinderDbControls.AddParam("@NamePrefix_ShortText3", Trim(NamePrefixTextBox.Text))
        RecordFinderDbControls.AddParam("@NickName_ShortText15", Trim(AliasTextBox.Text))
        RecordFinderDbControls.AddParam("@TelNo_ShortText10", Trim(PhoneNumberTextBox.Text))
        RecordFinderDbControls.AddParam("@EmailAddress_ShortText20", Trim(EmailAddressTextBox.Text))
        RecordFinderDbControls.AddParam("@Street_ShortText25", Trim(StreetTextBox.Text))
        RecordFinderDbControls.AddParam("@BldgAptRmNo_ShortText25", Trim(BldgAptRmNoTextBox.Text))
        RecordFinderDbControls.AddParam("@CityID_LongInteger", CurrentCityID)


    End Sub
    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        If OwnerFieldsEntriesAreNotValidAndComplete() Then
            Exit Sub
        End If

        SetOwnerTableFieldParameters()

        Select Case PurposeOfEntry
            Case "ADD"

                MySelection = "SELECT * FROM OwnerTable " &
                      " WHERE trim(LastName_ShortText15) = @LastName_ShortText15 " &
                       " AND trim(FirstName_ShortText15) = @FirstName_ShortText15 " &
                       " AND trim(NamePrefix_ShortText3) = @NamePrefix_ShortText3 "
                If RecordIsFound() Then
                    MsgBox("This record already exists")
                    Exit Sub
                Else
                    AddAnOwnerRecord()
                    'Do HERE ADD A VEHICLE

                End If
            Case "EDIT"
                Dim OwnerFieldsToUpdate = ""
                Dim OwnerFilter = " WHERE OwnerID_AutoNumber = " & Str(CurrentOwnerID)
                Dim MyNull = Chr(34) & Chr(34)

                MySelection = " UPDATE OwnerTable " &
                              " SET LastName_ShortText15 = " & Chr(34) & LastNameTextBox.Text & Chr(34) & ", " &
                              "     FirstName_ShortText15  = " & Chr(34) & FirstNameTextBox.Text & Chr(34)

                If NotEmpty(NamePrefixTextBox.Text) Then
                    MySelection = MySelection & ", NamePrefix_ShortText3  = " & Chr(34) & NamePrefixTextBox.Text & Chr(34)
                Else
                    MySelection = MySelection & ", NamePrefix_ShortText3  = " & MyNull
                End If


                If NotEmpty(AliasTextBox.Text) Then
                    MySelection = MySelection & ", NickName_ShortText15 = " & Chr(34) & AliasTextBox.Text & Chr(34)
                Else
                    MySelection = MySelection & ", NickName_ShortText15 = " & MyNull
                End If


                If NotEmpty(EmailAddressTextBox.Text) Then
                    MySelection = MySelection & ", EmailAddress_ShortText20 = " & Chr(34) & EmailAddressTextBox.Text & Chr(34)
                Else
                    MySelection = MySelection & ", EmailAddress_ShortText20 = " & MyNull
                End If

                If NotEmpty(PhoneNumberTextBox.Text) Then
                    MySelection = MySelection & ", TelNo_ShortText10 = " & Chr(34) & PhoneNumberTextBox.Text & Chr(34)
                Else
                    MySelection = MySelection & ", TelNo_ShortText10 = " & MyNull
                End If


                If NotEmpty(StreetTextBox.Text) Then
                    MySelection = MySelection & ", Street_ShortText25 = " & Chr(34) & StreetTextBox.Text & Chr(34)
                Else
                    MySelection = MySelection & ", Street_ShortText25 = " & MyNull
                End If

                If NotEmpty(BldgAptRmNoTextBox.Text) Then
                    MySelection = MySelection & ", BldgAptRmNo_ShortText25 = " & Chr(34) & BldgAptRmNoTextBox.Text & Chr(34)
                Else
                    MySelection = MySelection & ", BldgAptRmNo_ShortText25 = " & MyNull
                End If

                MySelection = MySelection & ", CityID_LongInteger = " & Str(CurrentCityID)

                MySelection = MySelection & OwnerFilter

                If NoRecordFound() Then Dim dummy = 1
                '                             "     CityID_LongInteger = " & Str(CurrentCityID) &

        End Select
        Me.Close()
    End Sub

    Private Sub AddAnOwnerRecord()

        ' EXECUTE INSERT COMMAN

        MySelection = "INSERT INTO OwnerTable (" &
                                            " LastName_ShortText15, " &
                                            " FirstName_ShortText15,  " &
                                            " NamePrefix_ShortText3,  " &
                                            " NickName_ShortText15,  " &
                                            " TelNo_ShortText10,  " &
                                             " EmailAddress_ShortText20,  " &
                                             " Street_ShortText25,  " &
                                             " BldgAptRmNo_ShortText25,  " &
                                             " CityID_LongInteger  " & ") " &
                                      "VALUES (" &
                                              Chr(34) & Trim(LastNameTextBox.Text) & Chr(34) & "," &
                                              Chr(34) & Trim(FirstNameTextBox.Text) & Chr(34) & "," &
                                              Chr(34) & Trim(NamePrefixTextBox.Text) & Chr(34) & "," &
                                              Chr(34) & Trim(AliasTextBox.Text) & Chr(34) & "," &
                                              Chr(34) & PhoneNumber & Chr(34) & "," &
                                              Chr(34) & Trim(EmailAddressTextBox.Text) & Chr(34) & "," &
                                              Chr(34) & Trim(StreetTextBox.Text) & Chr(34) & "," &
                                              Chr(34) & Trim(BldgAptRmNoTextBox.Text) & Chr(34) & "," &
                                             Str(CurrentCityID) & " )"

        '                                            " BldgAptRmNo_ShortText25,  " &
        If NoRecordFound() Then Dim xxx As Integer = 0 'always IsNot found


        RecordFinderDbControls.AddParam("@LastName_ShortText15", Trim(LastNameTextBox.Text))
        RecordFinderDbControls.AddParam("@CurrentCityID", CurrentCityID)
        Dim LastNameInQuote = Chr(34) & Trim(LastNameTextBox.Text) & Chr(34)
        MySelection = "Select * FROM OwnerTable WHERE trim(LastName_ShortText15) = " & LastNameInQuote & " And " & " CityID_LongInteger = " & Str(CurrentCityID)

        If NoRecordFound() Then
            MsgBox("PROBLEM ...... unseccessful save ")
            Exit Sub
        End If

        Dim r As DataRow = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        CurrentOwnerID = r("OwnerID_AutoNumber")

    End Sub

    Private Sub CityTextBox_TextChanged(sender As Object, e As EventArgs) Handles CityTextBox.TextChanged
        If CityTextBox.Text = "" Then Exit Sub
        If Me.Enabled = True Then
            If Not Tunnel1 = "EDIT" Then
                Tunnel1 = StateProvTextBox.Text
                Tunnel2 = CountryTextBox.Text
                ShowCityForm()
                CityForm.SearchCityTextBox.Text = CityTextBox.Text
            End If
        End If

    End Sub

    Private Sub ShowCityForm()
        Me.Enabled = False
        CityForm.ActivatedBy.Text = Me.Name
        CityForm.Show()
        CityForm.SearchCityTextBox.Select()
    End Sub

    Private Sub NamePrefixTextBox_TextChanged(sender As Object, e As EventArgs) Handles NamePrefixTextBox.TextChanged
        If Len(Trim(NamePrefixTextBox.Text)) > 3 Then
            NamePrefixTextBox.Text = Mid(NamePrefixTextBox.Text, 1, 0)
        End If
    End Sub
End Class