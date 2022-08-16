Public Class VehicleModelsRelationsDetailsForm
    Private CurrentVehicleModelRelationsID As Integer = -1
    Private CurrentVehicleTypeID As Integer = -1
    Private CurrentVehicleModelID As Integer = -1
    Private CurrentVehicleTrimID As Integer = -1
    Private CurrentModelName As String

    Private UpdateOfThisRecordAllowed = False
    Private PurposeOfEntry As String

    Private VehicleModelRelationsFieldsToSelect = ""
    Private VehicleModelRelationsTablesLinks = ""
    Private VehicleModelRelationsSelectionFilter = ""
    Private VehicleModelRelationsSelectionOrder = ""
    Private FormOpened As String

    Private SavedVehicleTypeID As Integer = -1
    Private SavedVehicleModelID As Integer = -1
    Private SavedVehicleTrimID As Integer = -1
    Private MeLocationX As Integer
    Private MeLocationY As Integer



    Private Sub VehicleModelsRelationsDetails_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' form recieves on load     'tunnel1 ADD, EDIT, DELETE saved on PurposeOfMasterCodeBookDetailsGroupEntry
        '                            Tunnel2 = CurrentVehicleModelRelationsID USED ON EDIT AND DELETE ONLY add leaves it empty

        ' form returns       Tunnel1 = 
        '                    Tunnel2 = 

        ' form sends         Tunnel1 = CurrentVehicleTypeID ' here it clips to filter only to current type
        '                              type has to be present before requesting for trim since 
        '                              Trim belongs to a model And model belongs to a type'

        ' form recieves on enabled  ' tunnel1 returned code maybe CurrentVehicleTypeID or CurrentVehicleModelID 
        'If IsEmpty(Tunnel1) Then Entry was cancelled
        '                           ' Tunnel2 - 2 '    Add, 3 ' change trim,  4 ' change type

        ' ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        MeLocationX = Me.Location.X

        PurposeOfEntry = Tunnel1        ' "ADD, EDIT or DELETE"
        CurrentVehicleModelRelationsID = Tunnel2    ' needs to be returned for record update upon return to parent

        If NotEmpty(VehicleTypeTextBox.Text) Then       'if Make exist then records are filtered only to the vehicle make
            VehicleTypeTextBox.Enabled = False          'disable entry
        End If

        'SET AND RESET ALL ENTRY PARAMETERS
        ResetTunnels()

    End Sub


    Private Sub VehicleModelsRelationsDetailsForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        'Refresh datagridviw here
        ' GET RETURNED DATA HERE
        If Me.Enabled = False Then
            Exit Sub
        End If
        Me.Show()
        Me.Select()
        If NotEmpty(Tunnel1) Then       ' Determines if there is a selected record
            Select Case FormOpened
                Case "VehicleTypeForm"
                    CurrentVehicleTypeID = Tunnel1
                Case "VehicleModelsForm"
                    CurrentVehicleModelID = Tunnel1

                Case "VehicleTrimsForm"
                    CurrentVehicleTrimID = Tunnel1
                    If CurrentVehicleTrimID < 0 Then

                        If MsgBox(" Continue without trim? ", vbYesNo) = vbYes Then
                            VehicleTrimTextBox.Enabled = False
                        Else
                            Me.Close()
                            ResetTunnels()
                        End If
                        Exit Sub
                    End If

                Case Else
                    Dim aaa = 1
            End Select
        Else
            ' cancel was executed
            Exit Sub ' Not sure of tunnel1 used at this point
            ResetTunnels()
        End If
        ResetTunnels()
        ValidateEntries()

    End Sub




    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        ValidateEntries()
        If Not UpdateOfThisRecordAllowed Then
            Exit Sub
        End If
        SaveModelsRelations()
        Tunnel1 = CurrentVehicleModelRelationsID
        Me.Close()
    End Sub
    Private Sub SaveModelsRelations()

        ' when records > 0 no action




        'test existence here

        Select Case PurposeOfEntry
            Case "ADD"

                AddNewModelRelations()

            Case "EDIT"
                Dim xxx = 1
            Case Else
                Dim xxxx = 1
        End Select
        Me.Close()

    End Sub
    Private Sub AddNewModelRelations()
        ' EXECUTE INSERT COMMAND

        MySelection = "Select * from VehicleModelsRelationsTable WHERE VehicleTypeID_LongInteger = " & Str(CurrentVehicleTypeID) &
                                                           " AND " & " VehicleModelID_LongInteger = " & Str(CurrentVehicleModelID) &
                                                           " AND " & " VehicleTrimID_LongInteger = " & Str(CurrentVehicleTrimID)

        If RecordIsFound() Then
            MsgBox("This MODEL already exist")
            Exit Sub
        End If
        Dim yyy = VehicleTypeTextBox.Text & " " & VehicleModelTextBox.Text & " " & VehicleTrimTextBox.Text
        If NoRecordFound() Then Dim xxx As Integer = 0 'always IsNot found


        If Not MsgBox(" Confirm adding " & yyy, vbYesNo) = vbYes Then
            VehicleTypeTextBox.Select()
            Exit Sub
        End If

        MySelection = "INSERT INTO VehicleModelsRelationsTable  (" &
                                            "VehicleTypeID_LongInteger, " &
                                            "VehicleModelID_LongInteger,  " &
                                            "VehicleTrimID_LongInteger)  " &
                                      "VALUES (" &
                                              Str(CurrentVehicleTypeID) & ", " &
                                              Str(CurrentVehicleModelID) & ", " &
                                              Str(CurrentVehicleTrimID) & " )"


        If NoRecordFound() Then Dim xxx As Integer = 0 'always IsNot found
        MySelection = "Select * from VehicleModelsRelationsTable WHERE VehicleTypeID_LongInteger = " & Str(CurrentVehicleTypeID) &
                                                           " AND " & " VehicleModelID_LongInteger = " & Str(CurrentVehicleModelID) &
                                                           " AND " & " VehicleTrimID_LongInteger = " & Str(CurrentVehicleTrimID)

        If NoRecordFound() Then
            MsgBox("PROBLEM ...... unseccessful save ")
            Exit Sub
        End If
        Dim r As DataRow = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        CurrentVehicleModelRelationsID = r("VehicleModelID_AutoNumber")

    End Sub
    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        Tunnel1 = CurrentVehicleModelRelationsID
        Me.Close()
    End Sub
    Private Sub VehicleModelsRelationsDetailsForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed

        'Enables calling form
        Select Case ActivatedBy.Text
            Case "VehicleManagementSystemForm"
                VehicleManagementSystemForm.Enabled = True ' triggers enabledchaned event of calling form
            Case "OwnerForm"
                Tunnel2 = CurrentVehicleModelRelationsID ' tunnnel is customer id
                OwnerForm.Enabled = True
            Case "VehicleModelsForm"
                VehicleModelsForm.Enabled = True
            Case "VehicleModelsRelationsForm"
                VehicleModelsRelationsForm.Enabled = True
            Case Else
                Dim x = "break here"
        End Select
        ActivatedBy.Text = ""
    End Sub
    Private Sub ValidateEntries()
        UpdateOfThisRecordAllowed = False ' used by deletion mode

        If Trim(VehicleTypeTextBox.Text) = "" Then
            ShowVehicleTypeTableForm()
            Exit Sub
        Else
            If Trim(VehicleModelTextBox.Text) = "" Then
                ShowVehicleModelsTableForm()
                Exit Sub
            Else
                'If Trim(VehicleTrimTextBox.Text) = "" Then
                'ShowVehicleTrimsTableForm()
                '  Exit Sub
                'End If
            End If
        End If
        UpdateOfThisRecordAllowed = True
    End Sub

    Private Sub MakeTextBox_GotClick(sender As Object, e As EventArgs) Handles VehicleTypeTextBox.Click
        If NotEmpty(VehicleTypeTextBox.Text) Then
            If (Len(Trim(VehicleTypeTextBox.Text))) > 1 Then
                Dim AnswerToQuestion = MsgBox("Would you like to change " & VehicleTypeTextBox.Text, vbYesNo)

                If AnswerToQuestion = vbYes Then
                    VehicleTypeTextBox.Text = ""
                End If
                Exit Sub
            End If
        End If
        ShowVehicleTypeTableForm()
    End Sub
    Private Sub TrimTextBox_Click(sender As Object, e As EventArgs) Handles VehicleTrimTextBox.Click
        If NotEmpty(VehicleTrimTextBox.Text) Then
            If (Len(Trim(VehicleTrimTextBox.Text))) > 1 Then
                Dim AnswerToQuestion = MsgBox("Would you like to change " & VehicleTrimTextBox.Text, vbYesNo)

                If AnswerToQuestion = vbYes Then
                    VehicleTrimTextBox.Text = ""
                    ShowVehicleTrimsTableForm()
                End If
                Exit Sub
            End If
        End If
    End Sub
    Private Sub VehicleModelTextBox_GotFocus(sender As Object, e As EventArgs) Handles VehicleModelTextBox.GotFocus
        VehicleTypeTextBox.Select()
    End Sub
    Private Sub VehicleModelTextBox_Click(sender As Object, e As EventArgs) Handles VehicleModelTextBox.Click
        If NotEmpty(VehicleModelTextBox.Text) Then
            If (Len(Trim(VehicleModelTextBox.Text))) > 1 Then
                Dim AnswerToQuestion = MsgBox("Would you like to change " & VehicleModelTextBox.Text, vbYesNo)
                If AnswerToQuestion = vbYes Then
                    VehicleModelTextBox.Text = ""
                End If
                Exit Sub
            End If
        End If
        If IsEmpty(VehicleTypeTextBox.Text) Then
            ValidateEntries()
        End If
        ShowVehicleModelsTableForm()
    End Sub
    Private Sub VehicleMakeTextBox_TextChanged(sender As Object, e As EventArgs) Handles VehicleTypeTextBox.TextChanged
        ' changes occurs when 1 - changed by vehicleTypeForm re-entry after selection, maybe determined by form status
        If Me.Enabled = False Then ' if event is triggerd by an external form
            Exit Sub
        End If
        ShowVehicleTypeTableForm()
    End Sub

    Private Sub VehicleModelTextBox_TextChanged(sender As Object, e As EventArgs) Handles VehicleModelTextBox.TextChanged
        If Me.Enabled = False Then ' if event is triggerd by an external form
            Exit Sub
        End If
        ShowVehicleModelsTableForm()
    End Sub
    Private Sub VehicleTrimTextBox_TextChanged(sender As Object, e As EventArgs) Handles VehicleTrimTextBox.TextChanged
        ' changes occurs when 1 - changed by vehicleTrimAddForm re-entry after selection, maybe determined by form status
        If Me.Enabled = False Then ' if event is triggerd by an external form
            Exit Sub
        End If
        If NotEmpty(Tunnel1) Then
            Exit Sub
        End If
        ShowVehicleTrimsTableForm()
    End Sub

    Private Sub ShowVehicleTypeTableForm()
        Me.Enabled = False
        VehicleTypeForm.ActivatedBy.Text = Me.Name
        SavedVehicleTypeID = CurrentVehicleTypeID
        VehicleTypeForm.Show()
        FormOpened = "VehicleTypeForm"
    End Sub

    Private Sub ShowVehicleModelsTableForm()
        Me.Enabled = False
        ' request only for model code if exist type code
        'may delete this if thre is no need to clip the type
        Tunnel1 = CurrentVehicleTypeID ' here it clips to filter only to current type
        SavedVehicleModelID = CurrentVehicleModelID
        VehicleModelsForm.ActivatedBy.Text = Me.Name
        VehicleModelsForm.Text = "Make : " & VehicleTypeTextBox.Text
        VehicleModelsForm.Show()
        FormOpened = "VehicleModelsForm"
    End Sub

    Private Sub ShowVehicleTrimsTableForm()
        Me.Enabled = False

        If Not CurrentVehicleModelID > 0 Then ' request only for trim code if exist model code
            VehicleTypeTextBox.Select()
            Exit Sub
        End If

        SavedVehicleTrimID = CurrentVehicleTrimID
        VehicleTrimsForm.ActivatedBy.Text = Me.Name
        VehicleTrimsForm.Text = "Trims "
        VehicleTrimsForm.Show()
        FormOpened = "VehicleTrimsForm"
    End Sub


End Class