Public Class VehiclesServicedDetailsForm
    Private CurrentOwnedVehicleID As Integer = -1
    Private CurrentOwnerID As Integer
    '    Private VehiclesServicedRecordCount As Integer
    Private CurrentVehicleDetailsId As Integer
    Private UpdateOfThisRecordAllowed = False
    Private PurposeOfEntry As String

    Private VehicleFieldsToSelect = ""
    Private VehicleServicedTablesLinks = ""
    Private VehicleSelectionFilter = ""
    Private VehicleSelectionOrder = ""
    Private MeLocationX As Integer
    Private MeLocationY As Integer


    Private Sub OwnedVehicleDetailsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        '      Tunnel1 = "ADD" 
        '      Tunnel2 = CurrentOwnerID
        '      Tunnel3 = OwnedVehiclesFilter 
        ' This Filter restricts the currently owned vehicles in the list available vehicles

        MeLocationX = Me.Location.X



        'GET ALL ENTRY PARAMETERS

        '        Tunnel 1 holds the PurposeOfEntry
        '       Tunnel2 holds the CurrentUserId
        '       Tunnel3 holds the CurrentOwnedVehicleID or the VehicleServicedID_AutoNumber of the VehicleServicedTable pointing the record currently requested for EDITing
        PurposeOfEntry = Tunnel1
        CurrentOwnerID = IIf(Not IsNumeric(Tunnel2), -1, Tunnel2)
        CurrentOwnedVehicleID = Val(Tunnel3)



        'SET AND RESET ALL ENTRY PARAMETERS
        ResetTunnels()

    End Sub


    Private Sub OwnedVehicleDetailsForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        'Refresh datagridviw here
        ' GET RETURNED DATA HERE
        If Me.Enabled = False Then Exit Sub
        If NotEmpty(Tunnel1) Then
            Dim xxxx = 1
        End If
        If NotEmpty(Tunnel2) Then
            CurrentVehicleDetailsId = Tunnel2
            '            AddNewOwnedVehicle()
        End If
        Me.Show()
        Me.Select()
        ResetTunnels()
    End Sub
    Private Sub OwnerForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        'Refresh datagridviw here
        ' GET RETURNED DATA HERE




    End Sub
    Private Sub AddNewOwnedVehicle()
        ' EXECUTE INSERT COMMAND
        Dim VehicleServicedTablesFilter = ""
        If VINtextBox.Text <> "" Then
            VehicleServicedTablesFilter = " WHERE VinNo_ShortText20 " & Chr(34) & VINtextBox.Text & Chr(34) & Space(2)
        ElseIf PlateNumberTextBox.Text <> "" Then
            VehicleServicedTablesFilter = " WHERE PlateNumber_ShortText20 = " & Chr(34) & PlateNumberTextBox.Text & Chr(34) & Space(2)
        Else
            VehicleServicedTablesFilter = " WHERE OwnerID_LongInteger = " & Str(CurrentOwnerID) & " AND " & " VehicleDetailsID_LongInteger = " & Trim(CurrentVehicleDetailsId)
        End If

        If Not NoRecordFound() Then
            MsgBox("Vehicle is already linked to the owner ")
            Exit Sub
        End If

        MySelection = " INSERT INTO VehicleServicedTable (" &
                                       " VinNo_ShortText20, " &
                                       " PlateNumber_ShortText20, " &
                                       " OwnerID_LongInteger, " &
                                       " VehicleDetailsID_LongInteger " &
                                ") VALUES (" &
                                       Chr(34) & Trim(VINtextBox.Text) & Chr(34) & "," &
                                       Chr(34) & Trim(PlateNumberTextBox.Text) & Chr(34) & "," &
                                       Str(CurrentOwnerID) & "," &
                                       Str(CurrentVehicleDetailsId) & ")"

        If NoRecordFound() Then Dim xxx As Integer = 0 'always IsNot found

        MySelection = "Select * FROM VehicleServicedTable " &
                              " WHERE OwnerID_LongInteger = " & Str(CurrentOwnerID) & " AND " &
                              "       VehicleDetailsID_LongInteger = " & Trim(CurrentVehicleDetailsId)

        If NoRecordFound() Then
            MsgBox("PROBLEM ...... unseccessful save ")
            Exit Sub
        End If

        Dim r As DataRow = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)

        CurrentOwnedVehicleID = r("VehicleServicedID_AutoNumber")
    End Sub


    Private Sub ValidateEntries()
        UpdateOfThisRecordAllowed = False

        If Trim(VINtextBox.Text) = "" Then
            Dim AnswerToMessage = MsgBox("Would you like to leave the VIN blank ?", vbYesNo)
            If AnswerToMessage = vbNo Then
                Exit Sub
            End If
        Else
            If Trim(VehicleTextBox.Text) = "" Then
                VehicleTextBox.Select()
                Exit Sub
            End If
        End If
        UpdateOfThisRecordAllowed = True
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        ValidateEntries()
        If Not UpdateOfThisRecordAllowed Then
            Exit Sub
        End If
        SaveOwnedVehicle()
        Tunnel1 = CurrentOwnedVehicleID
        Me.Close()
    End Sub
    Private Sub SaveOwnedVehicle()

        'test existence here

        Select Case PurposeOfEntry
            Case "ADD"
                AddNewOwnedVehicle()
            Case "EDIT"
                If MsgBox(" Confirm  changes to this Vehicle  ") = vbYes Then
                    Exit Sub
                End If
                Dim VehicleServicedDetailsFilter = " WHERE VehicleServicedID_AutoNumber = " & Str(CurrentOwnedVehicleID)

                Dim VehicleServicedTableFieldsToReplace = " UPDATE VehicleServicedTable SET "
                If NotEmpty(VINtextBox.Text) Then
                    VehicleServicedTableFieldsToReplace = VehicleServicedTableFieldsToReplace & " VinNo_ShortText20 = " & Chr(34) & VINtextBox.Text & Chr(34) & ", "
                End If
                If NotEmpty(PlateNumberTextBox.Text) Then
                    VehicleServicedTableFieldsToReplace = VehicleServicedTableFieldsToReplace & " PlateNumber_ShortText20 = " & Chr(34) & PlateNumberTextBox.Text & Chr(34) & ", "
                End If
                VehicleServicedTableFieldsToReplace = VehicleServicedTableFieldsToReplace & " VehicleDetailsID_LongInteger = " & CurrentVehicleDetailsId.ToString

                MySelection = VehicleServicedTableFieldsToReplace & VehicleServicedDetailsFilter
                If NoRecordFound() Then Dim dummy = 1
            Case Else
                Dim xxxx = 1
        End Select
        Me.Close()

    End Sub

    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub OwnedVehicleDetailsForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed



        'Enables calling form
        Select Case ActivatedBy.Text
            Case "VehicleManagementSystemForm"
                VehicleManagementSystemForm.Enabled = True ' triggers enabledchaned event of calling form
            Case "OwnerForm"
                Tunnel2 = CurrentVehicleDetailsId ' tunnnel is customer id
                OwnerForm.Enabled = True
            Case Else
                Dim x = "break here"
        End Select
        ActivatedBy.Text = ""
        VehicleDetailsForm.Enabled = True
        ActivatedBy.Text = ""
    End Sub

    Private Sub VehicleTextBox_TextChanged(sender As Object, e As EventArgs) Handles VehicleTextBox.TextChanged
        If Me.Enabled = True Then
            ShowVehiclesDetailForm()
        End If
    End Sub
    Private Sub ShowVehiclesDetailForm()
        Tunnel1 = CurrentOwnerID
        Tunnel2 = CurrentOwnedVehicleID
        VehicleDetailsForm.ActivatedBy.Text = Me.Name
        VehicleDetailsForm.Show()
        Me.Enabled = False
    End Sub
    Private Sub VehicleTextBox_GotFocus(sender As Object, e As EventArgs) Handles VehicleTextBox.GotFocus
        If VehicleTextBox.Text = "" Then
            ShowVehiclesDetailForm()
        End If
    End Sub
End Class