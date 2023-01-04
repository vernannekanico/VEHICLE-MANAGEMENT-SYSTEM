Public Class MyStandardForm
    Private MyStandardsFieldsToSelect = ""
    Private MyStandardsSelectionFilter = ""
    Private MyStandardsSelectionOrder = ""
    Private MyStandardsRecordCount As Integer = -1
    Private CurrentMyStandardsRow As Integer = -1
    Private CurrentMyStandardID = -1
    Private CurrentMyStandardStatus As String
    Private MyStandardsDataGridViewAlreadyFormated = False
    Private SaveMessage As String

    Private SavedCallingForm As Form
    Private Sub MyStandardForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MsgBox("Set this form and all containers to 12pt pixel")
        SavedCallingForm = CallingForm
        FillMyStandardsDataGridView()

    End Sub
    Private Sub FillMyStandardsDataGridView()

        MyStandardsSelectionOrder = " ORDER BY MyStandardID_AutoNumber DESC "
        MyStandardsFieldsToSelect = " 
"

        MySelection = MyStandardsFieldsToSelect & MyStandardsSelectionFilter & MyStandardsSelectionOrder

        JustExecuteMySelection()
        MyStandardsRecordCount = RecordCount

        If MyStandardsRecordCount > 0 Then
            MyStandardsGroupBox.Visible = True
        Else
            MyStandardsGroupBox.Visible = False
            CurrentMyStandardID = -1
        End If
        MyStandardsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        ' HERE AT ROW_ENTER, FillMyStandardConcernsDataGridView is called and MyStandardConcernsbOX IS ALREADY FORMATTED
        If Not MyStandardsDataGridViewAlreadyFormated Then
            FormatMyStandardsDataGridView()
            SetFormWidthAndGroupBoxLeft(Me,
                                        MyStandardsFormMenuStrip,
                                        MyStandardsGroupBox,
                                        MyStandardsGroupBox,
                                        MyStandardsGroupBox,
                                        MyStandardsGroupBox)
        End If

        SetGroupBoxHeight(5, MyStandardsRecordCount, MyStandardsGroupBox, MyStandardsDataGridView)
        Me.Top = VehicleManagementSystemForm.VehicleManagementMenuStrip.Top + VehicleManagementSystemForm.VehicleManagementMenuStrip.Height + 20
        Me.Left = VehicleManagementSystemForm.Left
        Me.Height = VehicleManagementSystemForm.Height - Me.Top

    End Sub
    Private Sub FormatMyStandardsDataGridView()
        MyStandardsDataGridViewAlreadyFormated = True
        MyStandardsGroupBox.Width = 0
        For i = 0 To MyStandardsDataGridView.Columns.GetColumnCount(0) - 1

            MyStandardsDataGridView.Columns.Item(i).Visible = False
            Select Case MyStandardsDataGridView.Columns.Item(i).Name
                Case "MyStandardNumber_ShortText12"
                    MyStandardsDataGridView.Columns.Item(i).HeaderText = "WORK ORDER No."
                    MyStandardsDataGridView.Columns.Item(i).Width = 120
                    MyStandardsDataGridView.Columns.Item(i).Visible = True
                Case "ServiceDate_DateTime"
                    MyStandardsDataGridView.Columns.Item(i).HeaderText = "Date/Time In"
                    MyStandardsDataGridView.Columns.Item(i).Width = 80
                    MyStandardsDataGridView.Columns(i).DefaultCellStyle.Format = "yy-MM-dd"
                    MyStandardsDataGridView.Columns.Item(i).Visible = True
                Case "VehicleMilage_Integer"
                    MyStandardsDataGridView.Columns.Item(i).HeaderText = "Milage"
                    MyStandardsDataGridView.Columns.Item(i).Width = 70
                    MyStandardsDataGridView.Columns(i).DefaultCellStyle.Format = "###,###"
                    MyStandardsDataGridView.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    MyStandardsDataGridView.Columns.Item(i).Visible = True
                Case "VehicleModels"
                    MyStandardsDataGridView.Columns.Item(i).HeaderText = "VEHICLE"
                    MyStandardsDataGridView.Columns.Item(i).Width = 200
                    MyStandardsDataGridView.Columns.Item(i).Visible = True
                Case "OwnerName"
                    MyStandardsDataGridView.Columns.Item(i).HeaderText = "OWNER"
                    MyStandardsDataGridView.Columns.Item(i).Width = 150
                    MyStandardsDataGridView.Columns.Item(i).Visible = True
                Case "TelNo_ShortText10"
                    MyStandardsDataGridView.Columns.Item(i).HeaderText = "TEL. NO."
                    MyStandardsDataGridView.Columns.Item(i).Width = 100
                    MyStandardsDataGridView.Columns.Item(i).Visible = True
                Case "AssignedLeadMechanic"
                    MyStandardsDataGridView.Columns.Item(i).HeaderText = "Lead Mechanic"
                    MyStandardsDataGridView.Columns.Item(i).Width = 160
                    MyStandardsDataGridView.Columns.Item(i).Visible = True
                    If CurrentUserGroup = "Lead Service Specialist" Then MyStandardsDataGridView.Columns.Item(i).Visible = False
                Case "MyStandardStatus"
                    MyStandardsDataGridView.Columns.Item(i).HeaderText = "Status"
                    MyStandardsDataGridView.Columns.Item(i).Width = 171
                    MyStandardsDataGridView.Columns.Item(i).Visible = True
                Case "NewMyStandardStatus"
                    MyStandardsDataGridView.Columns.Item(i).HeaderText = "Status (new)"
                    MyStandardsDataGridView.Columns.Item(i).Width = 200
                    MyStandardsDataGridView.Columns.Item(i).Visible = True
            End Select

            If MyStandardsDataGridView.Columns.Item(i).Visible = True Then
                MyStandardsGroupBox.Width = MyStandardsGroupBox.Width + MyStandardsDataGridView.Columns.Item(i).Width
            End If
        Next
        If MyStandardsGroupBox.Width > VehicleManagementSystemForm.Width Then
            MyStandardsGroupBox.Width = VehicleManagementSystemForm.Width - 4
        Else
            HorizontalCenter(MyStandardsGroupBox, Me)
        End If
    End Sub
    Private Sub MyStandardsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles MyStandardsDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If MyStandardsRecordCount = 0 Then Exit Sub

        CurrentMyStandardsRow = e.RowIndex
        CurrentMyStandardID = MyStandardsDataGridView.Item("MyStandardID_AutoNumber", CurrentMyStandardsRow).Value

        FillField(CurrentMyStandardStatus, MyStandardsDataGridView.Item("MyStandardStatus", CurrentMyStandardsRow).Value)

        Select Case CurrentMyStandardStatus
            Case "Assigned"
        End Select

    End Sub

    Private Sub ReturnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnToolStripMenuItem.Click
        DoCommonHouseKeeping(Me, SavedCallingForm)

    End Sub

    Private Sub MyStandardsForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        If Me.Enabled = False Then Exit Sub
        CallingForm = SavedCallingForm

        Select Case Tunnel1
            Case "Tunnel2IsMyStandardID"
                CurrentMyStandardID = Tunnel2
            Case "Tunnel3IsReturnedTextData"
                '              CurrentReturnedTextData = Tunnel3
        End Select
        FillMyStandardsDataGridView()
    End Sub

    Private Sub SaveMyStandardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveMyStandardToolStripMenuItem.Click
        SaveMessage = "Continue saving the changes ?"
        SaveChanges()
    End Sub
    Private Sub SaveChanges()
        'CHECK CHANGES REGISTER IF NEEDED
        If AChangeInMyStandardDetailsOccurred() Then
            'VALIDATE
            If MsgBox(SaveMessage, MsgBoxStyle.YesNo) = vbNo Then
                MyStandardDetailsGroupBox.Visible = False
                Exit Sub
            End If
            If Not AllEntriesOfThisMyStandardDetailsAreValid() Then Exit Sub
            RegisterDetailsOfThisMyStandardChanges()
        End If
    End Sub
    Private Function AChangeInMyStandardDetailsOccurred()
        '*******************************************************
        ' THIS ROUTINE DETERMINES ALSO IF THE PURPOSE OF ENTRY = "ADD OR EDIT
        If TheseAreNotEqual(MyStandardNameTextBox.Text, MyStandardsDataGridView.Item("", CurrentMyStandardsRow).Value) Then Return True
        Return False
    End Function
    Private Function AllEntriesOfThisMyStandardDetailsAreValid()
        If Trim(MyStandardNameTextBox.Text) = "" Then
            If MsgBox("Would you like to leave the MyStandard blank ?", vbYesNo) = vbNo Then
                Return False
            End If
        End If
        Return True
    End Function
    Private Sub RegisterDetailsOfThisMyStandardChanges()
        MySelection = " Select  * FROM MyStandardsTable WHERE MyStandardsPartID_Autonumber = " & CurrentMyStandardID
        JustExecuteMySelection()

        Dim xxMessage As String

        If RecordCount = 0 Then
            xxMessage = "Continue ADD this MyStandard ? "
        Else
            xxMessage = "Continue Save Changes ? "
        End If
        If MsgBox(xxMessage, MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            If MsgBox("Disregard your changes ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                MyStandardNameTextBox.Select()
                Exit Sub
            End If
        End If

        If RecordCount = 0 Then
            InsertNewMyStandard()
        Else
            UpdateMyStandardChanges()
        End If
    End Sub

    Private Sub InsertNewMyStandard()
        Dim sampleInteger = 1
        Dim SampleCurrentID = 1
        Dim SampleText = "Sample"
        Dim FieldsToUpdate =
                              "  StockSequence_LongInteger, " &
                               "  StockText_ShortText25, " &
                              "  StockDescription__Memo "
        Dim FieldsData =
               Val(sampleInteger).ToString & ",  " &
               SampleCurrentID.ToString & ",  " &
               InQuotes(SampleText)

        CurrentMyStandardID = InsertNewRecord("MyStandardsTable", FieldsToUpdate, FieldsData)
    End Sub
    Private Sub UpdateMyStandardChanges()
        Dim RecordFilter = " WHERE ProductsPartID_Autonumber = " & Str(CurrentMyStandardID)
        Dim SetCommand =
                    " Set " &
                    " ManufacturerPartNo_ShortText30Fld = " & InQuotes(MyStandardNameTextBox.Text) & ", "
        UpdateTable("MyStandardsTable", SetCommand, RecordFilter)
    End Sub
    Private Sub SelectMyStandardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectMyStandardToolStripMenuItem.Click

    End Sub
End Class