Public Class VehiclesServicedDetailsForm
    Private CurrentOwnedVehicleID As Integer = -1
    Private CurrentOwnerID As Integer
    '    Private VehiclesServicedRecordCount As Integer
    Private UpdateOfThisRecordAllowed = False
    Private PurposeOfEntry As String
    Private VehicleFieldsToSelect = ""
    Private ServicedVehiclesTablesLinks = ""
    Private VehicleSelectionFilter = ""
    Private VehicleSelectionOrder = ""
    Private MeLocationX As Integer
    Private MeLocationY As Integer
    Private SavedCallingForm As Form

    Private Sub OwnedVehicleDetailsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        SavedCallingForm = CallingForm        '      Tunnel1 = "ADD" 
        '      Tunnel2 = CurrentOwnerID
        '      Tunnel3 = OwnedVehiclesFilter 
        ' This Filter restricts the currently owned vehicles in the list available vehicles

        MeLocationX = Me.Location.X


        'GET ALL ENTRY PARAMETERS

        '        Tunnel 1 holds the PurposeOfEntry
        '       Tunnel2 holds the CurrentUserId
        '       Tunnel3 holds the CurrentOwnedVehicleID or the ServicedVehicleID_AutoNumber of the ServicedVehiclesTable pointing the record currently requested for EDITing
        CurrentVehicleID = -1
        PurposeOfEntry = Tunnel1
        CurrentOwnerID = IIf(Not IsNumeric(Tunnel2), -1, Tunnel2)
        CurrentOwnedVehicleID = Val(Tunnel3)
        VINtextBox.Enabled = True
        PlateNumberTextBox.Enabled = True
        VehicleTextBox.Enabled = True


    End Sub


    Private Sub OwnedVehicleDetailsForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        'Refresh datagridviw here
        ' GET RETURNED DATA HERE
        If Me.Enabled = False Then Exit Sub
        If NotEmpty(Tunnel1) Then
            Select Case Tunnel1
                Case "VehicleID"
                    AddNewOwnedVehicle()
                Case Else
                    MsgBox("break here")
            End Select
        End If
    End Sub
    Private Sub AddNewOwnedVehicle()
        ' EXECUTE INSERT COMMAND
        Dim ServicedVehiclesTablesFilter = ""
        If VINtextBox.Text <> "" Then
            ServicedVehiclesTablesFilter = " WHERE VinNo_ShortText20 = " & Chr(34) & VINtextBox.Text & Chr(34) & Space(2)
        ElseIf PlateNumberTextBox.Text <> "" Then
            ServicedVehiclesTablesFilter = " WHERE PlateNumber_ShortText20 = " & Chr(34) & PlateNumberTextBox.Text & Chr(34) & Space(2)
        Else
            ServicedVehiclesTablesFilter = " WHERE OwnerID_LongInteger = " & Str(CurrentOwnerID) & " AND " & " VehicleID_LongInteger = " & Trim(CurrentVehicleID)
        End If
        MySelection = "Select * FROM ServicedVehiclesTable " & ServicedVehiclesTablesFilter

        If Not NoRecordFound() Then
            MsgBox("Vehicle is already linked to the owner ")
            Exit Sub
        End If

        MySelection = " INSERT INTO ServicedVehiclesTable (" &
                                       " VinNo_ShortText20, " &
                                       " PlateNumber_ShortText20, " &
                                       " OwnerID_LongInteger, " &
                                       " VehicleID_LongInteger " &
                                ") VALUES (" &
                                       Chr(34) & Trim(VINtextBox.Text) & Chr(34) & "," &
                                       Chr(34) & Trim(PlateNumberTextBox.Text) & Chr(34) & "," &
                                       Str(CurrentOwnerID) & "," &
                                       Str(CurrentVehicleID) & ")"

        If NoRecordFound() Then Dim xxx As Integer = 0 'always IsNot found

        MySelection = "Select * FROM ServicedVehiclesTable " &
                              " WHERE OwnerID_LongInteger = " & Str(CurrentOwnerID) & " AND " &
                              "       VehicleID_LongInteger = " & Trim(CurrentVehicleID)

        If NoRecordFound() Then
            MsgBox("PROBLEM ...... unseccessful save ")
            Exit Sub
        End If

        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)

        CurrentOwnedVehicleID = r("ServicedVehicleID_AutoNumber")
    End Sub


    Private Sub ValidateEntries()
        UpdateOfThisRecordAllowed = False

        UpdateOfThisRecordAllowed = True
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        ValidateEntries()
        If Not UpdateOfThisRecordAllowed Then
            Exit Sub
        End If
        PurposeOfEntry = "ADD"
        SaveOwnedVehicle()
        Tunnel1 = "Tunnel2IsOwnedVehicleID"
        Tunnel2 = CurrentOwnedVehicleID
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub
    Private Sub SaveOwnedVehicle()

        Dim ServicedVehicleDetailsFilter = " SELECT * FROM ServicedVehiclesTable WHERE ServicedVehicleID_AutoNumber = " & Str(CurrentOwnedVehicleID)
        'test existence here
        MySelection = ServicedVehicleDetailsFilter
        If RecordIsFound() Then
            PurposeOfEntry = "EDIT"
        Else
            PurposeOfEntry = "ADD"
        End If

        Select Case PurposeOfEntry
            Case "ADD"
                AddNewOwnedVehicle()
            Case "EDIT"
                If MsgBox(" Confirm  changes to this Vehicle  ") = vbYes Then
                    Exit Sub
                End If
                ServicedVehicleDetailsFilter = " WHERE ServicedVehicleID_AutoNumber = " & Str(CurrentOwnedVehicleID)

                Dim ServicedVehiclesTableFieldsToReplace = " UPDATE ServicedVehiclesTable SET "
                If NotEmpty(VINtextBox.Text) Then
                    ServicedVehiclesTableFieldsToReplace = ServicedVehiclesTableFieldsToReplace & " VinNo_ShortText20 = " & Chr(34) & VINtextBox.Text & Chr(34) & ", "
                End If
                If NotEmpty(PlateNumberTextBox.Text) Then
                    ServicedVehiclesTableFieldsToReplace = ServicedVehiclesTableFieldsToReplace & " PlateNumber_ShortText20 = " & Chr(34) & PlateNumberTextBox.Text & Chr(34) & ", "
                End If
                ServicedVehiclesTableFieldsToReplace = ServicedVehiclesTableFieldsToReplace & " VehicleID_LongInteger = " & CurrentVehicleID.ToString

                MySelection = ServicedVehiclesTableFieldsToReplace & ServicedVehicleDetailsFilter
                If NoRecordFound() Then Dim dummy = 1
            Case Else
                MsgBox("nO aCTION IS GIVEN HERE, BREAK AND CORRECT")
        End Select
    End Sub

    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub
    Private Sub OwnedVehicleDetailsForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
    End Sub

    Private Sub VehicleTextBox_TextChanged(sender As Object, e As EventArgs) Handles VehicleTextBox.TextChanged
        If Me.Enabled = True Then
            ShowVehiclesDetailForm()
        End If
    End Sub
    Private Sub ShowVehiclesDetailForm()
        Tunnel1 = CurrentOwnerID
        Tunnel2 = CurrentOwnedVehicleID
        VehiclesForm.Show()
        Me.Enabled = False
    End Sub
    Private Sub VehicleTextBox_GotFocus(sender As Object, e As EventArgs) Handles VehicleTextBox.GotFocus
        If VehicleTextBox.Text = "" Then
            ShowVehiclesDetailForm()
        End If
    End Sub
End Class