Public Class ConcernsDetailsForm
    Private CurrentConcernID As Integer = -1
    Private CurrentConcernRow As Integer

    '    Private ConcernsServicedRecordCount As Integer
    Private CurrentConcernDetailsId As Integer
    Private UpdateOfThisRecordAllowed = False
    Private PurposeOfEntry As String

    Private ConcernFieldsToSelect = ""
    Private ConcernServicedTablesLinks = ""
    Private ConcernSelectionFilter = ""
    Private ConcernSelectionOrder = ""
    Private MeLocationX As Integer
    Private MeLocationY As Integer

    Private Sub ConcernDetailsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        '       Tunnel1 = "ADD" 
        '      Tunnel2 = CurrentWorkOrderConcernID
        '       Tunnel3 = ConcernsFilter 
        ' This Filter restricts the currently owned Concerns in the list available Concerns

        MeLocationX = Me.Location.X



        'GET ALL ENTRY PARAMETERS

        '        Dim Field1Filter As Integer
        '       Dim Field2Filter As Integer
        PurposeOfEntry = Tunnel1
        CurrentConcernID = Tunnel2
        ConcernSelectionFilter = Tunnel3



        'SET AND RESET ALL ENTRY PARAMETERS
        ResetTunnels()

    End Sub


    Private Sub ConcernDetailsForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        'Refresh datagridviw here
        ' GET RETURNED DATA HERE
        If Me.Enabled = False Then Exit Sub
        If NotEmpty(Tunnel1) Then
            Dim xxxx = 1
        End If
        If NotEmpty(Tunnel2) Then
            CurrentConcernDetailsId = Tunnel2
            '            AddNewConcern()
        End If
        Me.Show()
        Me.Select()
        ResetTunnels()
    End Sub
    Private Sub ConcernForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        'Refresh datagridviw here
        ' GET RETURNED DATA HERE

    End Sub
    Private Sub AddNewConcern()
        ' EXECUTE INSERT COMMAND

        MySelection = " INSERT INTO ConcernServicedTable (" &
                                       " ConcernTypeID_LongInteger, " &
                                       " PlateNumber_ShortText20, " &
                                       " ConcernID_LongInteger, " &
                                       " ConcernDetailsID_LongInteger " &
                                ") VALUES (" &
                                       Chr(34) & Trim(ConcernTypeTextBox.Text) & Chr(34) & "," &
                                       Chr(34) & Trim(ConcernTextBox.Text) & Chr(34) & "," &
                                       Str(CurrentConcernID) & "," &
                                       Str(CurrentConcernDetailsId) & ")"

        If NoRecordFound() Then Dim xxx As Integer = 0 'always IsNot found

        MySelection = "Select * FROM ConcernServicedTable " &
                              " WHERE ConcernID_LongInteger = " & Str(CurrentConcernID) & " AND " &
                              "       ConcernDetailsID_LongInteger = " & Trim(CurrentConcernDetailsId)

        If NoRecordFound() Then
            MsgBox("PROBLEM ...... unseccessful save ")
            Exit Sub
        End If

        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)

        CurrentConcernID = r("ConcernServicedID_AutoNumber")
    End Sub


    Private Sub ValidateEntries()
        UpdateOfThisRecordAllowed = False

        If Trim(ConcernTypeTextBox.Text) = "" Then
            Dim AnswerToMessage = MsgBox("Would you like to leave the VIN blank ?", vbYesNo)
            If AnswerToMessage = vbNo Then
                Exit Sub
            End If
        Else
            If Trim(ConcernTextBox.Text) = "" Then
                ConcernTextBox.Select()
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
        SaveConcern()
        Tunnel1 = CurrentConcernID
        Me.Close()
    End Sub
    Private Sub SaveConcern()

        'test existence here

        Select Case PurposeOfEntry
            Case "ADD"
                MySelection = "Select * FROM ConcernServicedTable " &
                              " WHERE ConcernID_LongInteger = " & Str(CurrentConcernID) & " AND " &
                              "       ConcernDetailsID_LongInteger = " & Trim(CurrentConcernDetailsId)

                If NoRecordFound() Then
                    AddNewConcern()

                Else
                    MsgBox("This record already exists")
                    CurrentConcernID = 0
                    Exit Sub
                End If

            Case "EDIT"
                Dim xxx = 1
            Case Else
                Dim xxxx = 1
        End Select
        Me.Close()

    End Sub

    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub ConcernDetailsForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed

        'Enables calling form
        Select Case ActivatedByTextBox.Text
            Case "ConcernManagementSystemForm"
                VehicleManagementSystemForm.Enabled = True ' triggers enabledchaned event of calling form
            Case "ConcernForm"
            Case Else
                Dim x = "break here"
        End Select

        ActivatedByTextBox.Text = ""
    End Sub

    Private Sub ConcernTypeTextBox_GotFocus(sender As Object, e As EventArgs) Handles ConcernTypeTextBox.GotFocus
        If IsEmpty(ConcernTypeTextBox.Text) Then
            ShowConcernTypeForm()
        End If
    End Sub
    Private Sub ShowConcernTypeForm()
        Me.Enabled = False
        ConcernTypesForm.ActivatedByTextBox.Text = Me.Name
        ConcernTypesForm.Show()

    End Sub

    Private Sub ConcernTextBox_TextChanged(sender As Object, e As EventArgs) Handles ConcernTextBox.TextChanged

    End Sub
End Class