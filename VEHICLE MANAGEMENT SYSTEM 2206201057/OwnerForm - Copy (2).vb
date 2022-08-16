Public Class OwnerForm
    Public CurrentOwnerId As Integer
    Private CurrentOwnerDataGridViewRow As Integer

    Private CurrentOwnedVehicleID As Integer
    Private CurrentOwnedVehicleDataGridViewRow As Integer
    Private OwnedVehicleCount As Integer
    Public VehicleID As Integer
    Private MyCustomerFilter = ""
    Private FindKey As String
    Private YetPassedThisWay As Boolean = False
    Public VehiclesDbControls As New MyDbControls
    Private MeLocationX As Integer
    Private MeLocationY As Integer


    '    Private OwnedVehicleDataGridViewInitialized = False

    Private Sub OwnerForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not IsNumeric(Tunnel1) Then
            Tunnel1 = Val(0)
            Tunnel1 = Val(Tunnel1)
        End If
        CurrentOwnerId = Tunnel1

        If Not CurrentOwnerId < 0 Then MyCustomerFilter = " WHERE OwnerID_AutoNumber = " & Str(CurrentOwnerId)

        FillOwnerDataGridView()
        SetupOwnerDataGridView()

        ' PRIOR TO LOAD, FORM MAY BE LOADED WITH DATA FOR THE SEARCH FIELD

        NameSearchTextBox.Select()
        If Not (NameSearchTextBox.Text = "Search" And PhoneNumberSearchTextBox.Text = "Search") Then
            If NameSearchTextBox.Text = "Search" Then
                PhoneNumberSearchTextBox.Select()
            End If
        End If

        'SET AND RESET ALL ENTRY PARAMETERS
        ResetTunnels()

    End Sub

    Private Sub FillOwnerDataGridView()

        MySelection = "Select OwnerTable.OwnerID_AutoNumber, " &
                      "       OwnerTable.LastName_ShortText15, " &
                      "       OwnerTable.FirstName_ShortText15, " &
                      "       OwnerTable.NamePrefix_ShortText3, " &
                      "       OwnerTable.NickName_ShortText15, " &
                      "       OwnerTable.TelNo_ShortText10, " &
                      "       OwnerTable.EmailAddress_ShortText20, " &
                      "       OwnerTable.Street_ShortText25, " &
                      "       OwnerTable.BldgAptRmNo_ShortText25, " &
                      "       OwnerTable.CityID_LongInteger, " &
                      "       CityTable.CityName_ShortText25, " &
                      "       StateProvTable.StateProvName_ShortText25, " &
                      "       CityTable.ZipCode_ShortText9, " &
                      "       StateProvTable.StateCode_ShortText2, " &
                      "       StateProvTable.CountryID_LongInteger, " &
                      "       CountryTable.CountryName_ShortText25 " &
                      "       FROM((OwnerTable LEFT JOIN CityTable ON OwnerTable.CityID_LongInteger = CityTable.CityID_AutoNumber) " &
                      "                        LEFT JOIN StateProvTable On CityTable.StateProvID_LongInteger = StateProvTable.StateProvID_AutoNumber) " &
                      "                        LEFT JOIN CountryTable On StateProvTable.CountryID_LongInteger = CountryTable.CountryID_Autonumber "

        ' FILL DATAGRID
        If NoRecordFound() Then Dim Dummytatemet = ""

        OwnerDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

    End Sub
    Private Sub SetupOwnerDataGridView()
        OwnerDataGridView.Columns.Item("OwnerID_AutoNumber").Visible = False
        OwnerDataGridView.Columns.Item("LastName_ShortText15").HeaderText = "Last Name"
        OwnerDataGridView.Columns.Item("LastName_ShortText15").Width = 100

        OwnerDataGridView.Columns.Item("FirstName_ShortText15").HeaderText = "Firt Name"
        OwnerDataGridView.Columns.Item("FirstName_ShortText15").Width = 100

        OwnerDataGridView.Columns.Item("NickName_ShortText15").HeaderText = "Alias"
        OwnerDataGridView.Columns.Item("NickName_ShortText15").Width = 100

        OwnerDataGridView.Columns.Item("TelNo_ShortText10").HeaderText = "Phone #"
        OwnerDataGridView.Columns.Item("TelNo_ShortText10").Width = 100

        CurrentOwnerId = OwnerDataGridView.Item("OwnerID_AutoNumber", CurrentOwnerDataGridViewRow).Value

    End Sub
    Private Sub OwnerDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles OwnerDataGridView.RowEnter
        If e.RowIndex < 0 Then
            Exit Sub
        End If
        CurrentOwnerDataGridViewRow = e.RowIndex
        If CurrentOwnerId = OwnerDataGridView.Item("OwnerID_AutoNumber", CurrentOwnerDataGridViewRow).Value Then
            Exit Sub
        End If
        CurrentOwnerId = OwnerDataGridView.Item("OwnerID_AutoNumber", CurrentOwnerDataGridViewRow).Value
        SelectedCustomerTextBox.Text = OwnerDataGridView.Item("FirstName_ShortText15", CurrentOwnerDataGridViewRow).Value & " " &
                                       OwnerDataGridView.Item("LastName_ShortText15", CurrentOwnerDataGridViewRow).Value & " " &
                                       OwnerDataGridView.Item("NamePrefix_ShortText3", CurrentOwnerDataGridViewRow).Value

        If RecordFinderDbControls.MyAccessDbDataTable.Rows.Count = 0 Then
            NameSearchTextBox.Text = ""
            PhoneNumberSearchTextBox.Text = ""
            CurrentOwnerId = -1
        End If
        GetOwnedVehicles()

    End Sub

    Private Sub OwnedVehicleDataGridView_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles OwnedVehicleDataGridView.DataBindingComplete
        Dim NoOfHeaderLines = 1
        Dim RecordsDisplyed = RecordCount
        Dim FormLowPointFromGrid = 90
        If RecordCount > 27 Then
            Me.Location = New Point(MeLocationX, 50)
            RecordsDisplyed = 27
        Else
            RecordsDisplyed = RecordCount + 1
        End If
        OwnedVehicleDataGridView.Height = (OwnedVehicleDataGridView.ColumnHeadersHeight * NoOfHeaderLines) + (DataGridViewRowHeight * RecordsDisplyed) + DataGridViewRowHeight

    End Sub
    Private Sub OwnedVehicleDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles OwnedVehicleDataGridView.RowEnter
        If e.RowIndex < 0 Then Exit Sub
        If RecordCount = 0 Then Exit Sub

        CurrentOwnedVehicleDataGridViewRow = e.RowIndex
        '      If Not OwnedVehicleDataGridViewInitialized Then
        '      OwnedVehicleDataGridViewInitialized = True
        '      End If
        CurrentOwnedVehicleID = OwnedVehicleDataGridView.Item("VehicleServicedID_AutoNumber", CurrentOwnedVehicleDataGridViewRow).Value



        SelectedVehicleTextBox.Text = OwnedVehicleDataGridView.Item(1, CurrentOwnedVehicleDataGridViewRow).Value
    End Sub

    Private Sub NameSearchTextBox_GotFocus(sender As Object, e As EventArgs)
        PhoneNumberSearchTextBox.Text = ""
    End Sub

    Private Sub PhoneNumberSearchTextBox_GotFocus(sender As Object, e As EventArgs)
        NameSearchTextBox.Text = ""
    End Sub
    Private Sub ToolStripTextBox1_Click(sender As Object, e As EventArgs) Handles PhoneNumberSearchTextBox.Click
        NameSearchTextBox.Text = ""
    End Sub

    Private Sub NameSearchTextBox_TextChanged(sender As Object, e As EventArgs) Handles NameSearchTextBox.TextChanged
        If NameSearchTextBox.Text = "Search" Then Exit Sub
        FindKey = Trim(NameSearchTextBox.Text)
        If NotEmpty(FindKey) Then
            RecordFinderDbControls.AddParam("@FindKey", "%" & FindKey & "%")
            MyCustomerFilter = " WHERE FirstName_ShortText15 LIKE @FindKey or " &
                                       " LastName_ShortText15 LIKE @FindKey or " &
                                       " NickName_ShortText15 LIKE @FindKey "
        End If

        FillOwnerDataGridView()
    End Sub
    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        Tunnel1 = "ADD"
        OwnerDetailsForm.ActivatedBy.Text = Me.Name
        If Not (NameSearchTextBox.Text = "" Or NameSearchTextBox.Text = "Search") Then
            OwnerDetailsForm.LastNameTextBox.Text = NameSearchTextBox.Text
        End If
        OwnerDetailsForm.Show()

    End Sub
    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        Tunnel1 = "EDIT"
        Tunnel2 = CurrentOwnerId
        LoadOwnerDetails()
        OwnerDetailsForm.ActivatedBy.Text = Me.Name
        OwnerDetailsForm.Show()

    End Sub
    Private Sub LoadOwnerDetails()
        If Not IsDBNull(OwnerDataGridView.Item("LastName_ShortText15", CurrentOwnerDataGridViewRow).Value) Then
            OwnerDetailsForm.LastNameTextBox.Text = OwnerDataGridView.Item("LastName_ShortText15", CurrentOwnerDataGridViewRow).Value
        End If

        If Not IsDBNull(OwnerDataGridView.Item("FirstName_ShortText15", CurrentOwnerDataGridViewRow).Value) Then
            OwnerDetailsForm.FirstNameTextBox.Text = OwnerDataGridView.Item("FirstName_ShortText15", CurrentOwnerDataGridViewRow).Value
        End If

        If Not IsDBNull(OwnerDataGridView.Item("NamePrefix_ShortText3", CurrentOwnerDataGridViewRow).Value) Then
            OwnerDetailsForm.NamePrefixTextBox.Text = OwnerDataGridView.Item("NamePrefix_ShortText3", CurrentOwnerDataGridViewRow).Value
        End If

        If Not IsDBNull(OwnerDataGridView.Item("NickName_ShortText15", CurrentOwnerDataGridViewRow).Value) Then
            OwnerDetailsForm.AliasTextBox.Text = OwnerDataGridView.Item("NickName_ShortText15", CurrentOwnerDataGridViewRow).Value
        End If

        If Not IsDBNull(OwnerDataGridView.Item("EmailAddress_ShortText20", CurrentOwnerDataGridViewRow).Value) Then
            OwnerDetailsForm.EmailAddressTextBox.Text = OwnerDataGridView.Item("EmailAddress_ShortText20", CurrentOwnerDataGridViewRow).Value
        End If

        If Not IsDBNull(OwnerDataGridView.Item("TelNo_ShortText10", CurrentOwnerDataGridViewRow).Value) Then
            OwnerDetailsForm.PhoneNumberTextBox.Text = OwnerDataGridView.Item("TelNo_ShortText10", CurrentOwnerDataGridViewRow).Value
        End If

        If Not IsDBNull(OwnerDataGridView.Item("Street_ShortText25", CurrentOwnerDataGridViewRow).Value) Then
            OwnerDetailsForm.StreetTextBox.Text = OwnerDataGridView.Item("Street_ShortText25", CurrentOwnerDataGridViewRow).Value
        End If

        If Not IsDBNull(OwnerDataGridView.Item("BldgAptRmNo_ShortText25", CurrentOwnerDataGridViewRow).Value) Then
            OwnerDetailsForm.BldgAptRmNoTextBox.Text = OwnerDataGridView.Item("BldgAptRmNo_ShortText25", CurrentOwnerDataGridViewRow).Value
        End If

        If Not IsDBNull(OwnerDataGridView.Item("CityName_ShortText25", CurrentOwnerDataGridViewRow).Value) Then
            OwnerDetailsForm.CityTextBox.Text = OwnerDataGridView.Item("CityName_ShortText25", CurrentOwnerDataGridViewRow).Value
        End If

        If Not IsDBNull(OwnerDataGridView.Item("StateProvName_ShortText25", CurrentOwnerDataGridViewRow).Value) Then
            OwnerDetailsForm.StateProvTextBox.Text = OwnerDataGridView.Item("StateProvName_ShortText25", CurrentOwnerDataGridViewRow).Value
        End If

        If Not IsDBNull(OwnerDataGridView.Item("CountryName_ShortText25", CurrentOwnerDataGridViewRow).Value) Then
            OwnerDetailsForm.CountryTextBox.Text = OwnerDataGridView.Item("CountryName_ShortText25", CurrentOwnerDataGridViewRow).Value
        End If


    End Sub
    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Tunnel1 = "DELETE"

    End Sub
    Private Sub SelectStateProvToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectCustomerToolStripMenuItem.Click


        Tunnel1 = CurrentOwnerId
        Tunnel2 = "Tunnel1IsCustomerCode"
        Tunnel3 = CurrentOwnedVehicleID

        Me.Close()
    End Sub



    Private Sub GetOwnedVehicles()
        OwnerDataGridView.Enabled = False
        Dim VehicleName = " (VehicleDetailsTable.YearManufactured_ShortText4 & space(1) & Trim(VehicleTypeTable.VehicleType_ShortText20) & space(1) & trim(VehicleModelsTable.VehicleModel_ShortText20) & space(1) & trim(VehicleTrimTable.VehicleTrimName_ShortText25) & space(1) & trim(VehicleDetailsTable.Engine_ShortText20)), "

        MySelection = " Select VehicleServicedTable.VehicleServicedID_AutoNumber, " &
                             VehicleName &
                             " VehicleServicedTable.VinNo_ShortText20, " &
                             " VehicleServicedTable.PlateNumber_ShortText20, " &
                             " VehicleServicedTable.OwnerID_LongInteger, " &
                             " VehicleServicedTable.VehicleDetailsID_LongInteger, " &
                             " VehicleDetailsTable.VehicleModelsRelationsID_LongInteger "

        Dim MyLinks = " FROM(((((VehicleServicedTable LEFT JOIN VehicleDetailsTable ON VehicleServicedTable.VehicleDetailsID_LongInteger = VehicleDetailsTable.VehicleDetailsID_AutoNumber) " &
                             " LEFT JOIN VehicleModelsRelationsTable On VehicleDetailsTable.[VehicleModelsRelationsID_LongInteger] = VehicleModelsRelationsTable.VehicleModelsRelationsID_Autonumber) " &
                             " LEFT JOIN VehicleModelsTable On VehicleModelsRelationsTable.VehicleModelID_LongInteger = VehicleModelsTable.VehicleModelID_Autonumber) " &
                             " LEFT JOIN VehicleTypeTable On VehicleModelsRelationsTable.VehicleTypeID_LongInteger = VehicleTypeTable.VehicleTypeID_AutoNumber) " &
                             " LEFT JOIN VehicleTrimTable On VehicleModelsRelationsTable.VehicleTrimID_LongInteger = VehicleTrimTable.VehicleTrimID_Autonumber) " &
                             " LEFT JOIN OwnerTable On VehicleServicedTable.OwnerID_LongInteger = OwnerTable.OwnerID_AutoNumber "

        MySelection = MySelection & MyLinks & " WHERE OwnerID_LongInteger = " & Str(CurrentOwnerId)

        VehiclesDbControls.MyDbCommand(MySelection)



        OwnedVehicleDataGridView.DataSource = VehiclesDbControls.MyAccessDbDataTable
        OwnedVehicleCount = VehiclesDbControls.MyAccessDbDataTable.Rows.Count

        If Not YetPassedThisWay Then
            YetPassedThisWay = True
            OwnedVehicleDataGridView.Columns.Item("VehicleServicedID_AutoNumber").Visible = False
            OwnedVehicleDataGridView.Columns.Item("VehicleDetailsID_LongInteger").Visible = False
            OwnedVehicleDataGridView.Columns.Item("OwnerID_LongInteger").Visible = False
            OwnedVehicleDataGridView.Columns.Item("VehicleModelsRelationsID_LongInteger").Visible = False

            OwnedVehicleDataGridView.Columns.Item("VinNo_ShortText20").Width = 200
            OwnedVehicleDataGridView.Columns.Item("VinNo_ShortText20").HeaderText = "VIN"

            OwnedVehicleDataGridView.Columns.Item("PlateNumber_ShortText20").Width = 100
            OwnedVehicleDataGridView.Columns.Item("PlateNumber_ShortText20").HeaderText = "Plate #"

            OwnedVehicleDataGridView.Columns.Item(1).Width = 300
            OwnedVehicleDataGridView.Columns.Item(1).HeaderText = "Vehicle Model"

        End If

        Select Case OwnedVehicleCount
            Case 0

                ShowVehiclesServicedDetailsForm()

        End Select
        OwnerDataGridView.Enabled = True
    End Sub
    Private Sub VehiclesServicedFormShow()

    End Sub

    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        Me.Close()
    End Sub


    Private Sub OwnedVehicleDataGridView_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles OwnedVehicleDataGridView.CellMouseDoubleClick

        Dim QuestionIs As String
        Dim Confirmed As Boolean
        If e.RowIndex >= 0 Then

            QuestionIs = "SELECT this vehicle ?" & Chr(13) & OwnedVehicleDataGridView(3, e.RowIndex).Value
            Confirmed = MsgBox(QuestionIs, 4)
            If Confirmed Then
                Dim xxx = IIf(IsDBNull(OwnedVehicleDataGridView("Engine_ShortText20", e.RowIndex).Value), "", OwnedVehicleDataGridView("Engine_ShortText20", e.RowIndex).Value)
                WorkOrderForm.VehicleDetailsTextBox.Text = Trim(OwnedVehicleDataGridView("YearManufactured_ShortText4", e.RowIndex).Value) & ", " &
                          Trim(OwnedVehicleDataGridView("VehicleType_ShortText20", e.RowIndex).Value) & ", " &
                          Trim(OwnedVehicleDataGridView("VehicleModel_ShortText20", e.RowIndex).Value) & ", " &
                          Trim(OwnedVehicleDataGridView("VehicleTrimName_ShortText25", e.RowIndex).Value) & ", " &
                               xxx

                WorkOrderForm.VINTextBox.Text = Trim(OwnedVehicleDataGridView("VinNo_ShortText20", e.RowIndex).Value)
                '            WorkOrderForm.CurrentCustomerID = CurrentOwnerId
                '            WorkOrderForm.CurrentVehicleServicedID = Trim(OwnedVehicleDataGridView("VehicleServicedID_AutoNumber", e.RowIndex).Value.ToString)

                Dim lastnamexx = Trim(OwnerDataGridView.Item("LastName_ShortText15", CurrentOwnerDataGridViewRow).Value.ToString)
                Dim CustomerString As String = ""
                If lastnamexx = "" Then
                    CustomerString = Trim(OwnerDataGridView.Item("FirstName_ShortText15", CurrentOwnerDataGridViewRow).Value.ToString)
                Else
                    CustomerString = lastnamexx & ", " & Trim(OwnerDataGridView.Item("FirstName_ShortText15", CurrentOwnerDataGridViewRow).Value)
                End If
                WorkOrderForm.CustomerTextBox.Text = CustomerString
                Tunnel2 = "Tunnel1IsVehicleServicedID"
                Tunnel1 = CurrentOwnedVehicleID
                Me.Close()
            End If
        End If
    End Sub

    Private Sub OwnerForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed

        'Enables calling form

        Select Case ActivatedBy.Text
            Case "VehicleManagementSystemForm"
                VehicleManagementSystemForm.Enabled = True
            Case "WorkOrderForm"

                WorkOrderForm.VehicleDetailsTextBox.Text = SelectedVehicleTextBox.Text
                WorkOrderForm.CustomerTextBox.Text = SelectedCustomerTextBox.Text
                WorkOrderForm.VINTextBox.Text = OwnedVehicleDataGridView.Item("VinNo_ShortText20", CurrentOwnedVehicleDataGridViewRow).Value
                WorkOrderForm.Enabled = True
            Case Else
                Dim xxx = 1
        End Select
        ActivatedBy.Text = ""

    End Sub

    Private Sub OwnerForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        'Refresh datagridviw here
        ' GET RETURNED DATA HERE

        ' maybe enabled by adding an owner OWNER DETAIS OR VEHICLES
        'ADD A New RECORD ON VehicleServicedTable UPON SELECT ON VEHICLE THEN CREATE A New VehicleServicedTable
        If Me.Enabled = False Then Exit Sub
        If NotEmpty(Tunnel1) Then
            CurrentOwnerId = Tunnel1
            FillOwnerDataGridView()

        End If
        If NotEmpty(Tunnel2) Then
            CurrentOwnedVehicleID = Tunnel2
            FillOwnerDataGridView()
        End If
        ' update vehicle table here

        Me.Show()

        Me.Select()
        ResetTunnels()
        FillOwnerDataGridView()
    End Sub
    Private Sub AddVehicleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddVehicleToolStripMenuItem.Click
        Tunnel1 = "ADD"
        Dim OwnedVehiclesFilter As String = ""
        For i = 0 To OwnedVehicleCount - 1
            OwnedVehiclesFilter = OwnedVehiclesFilter & OwnedVehicleDataGridView.Item("VehicleDetailsID_LongInteger", i).Value & "|"
        Next

        Tunnel1 = "ADD"
        Tunnel2 = CurrentOwnerId
        Tunnel3 = OwnedVehiclesFilter
        ShowVehiclesServicedDetailsForm()
    End Sub
    Private Sub ShowVehiclesServicedDetailsForm()

        Me.Enabled = False
        Dim txtPlateNumber = ""
        If IsDBNull(OwnedVehicleDataGridView.Item("PlateNumber_ShortText20", CurrentOwnedVehicleDataGridViewRow).Value) Then
            txtPlateNumber = ""
        Else
            txtPlateNumber = OwnedVehicleDataGridView.Item("PlateNumber_ShortText20", CurrentOwnedVehicleDataGridViewRow).Value
        End If
        VehiclesServicedDetailsForm.Text = "CUSTOMER: " & SelectedCustomerTextBox.Text
        VehiclesServicedDetailsForm.ActivatedBy.Text = Me.Name
        VehiclesServicedDetailsForm.VINtextBox.Text = OwnedVehicleDataGridView.Item("VinNo_ShortText20", CurrentOwnedVehicleDataGridViewRow).Value
        VehiclesServicedDetailsForm.PlateNumberTextBox.Text = txtPlateNumber
        VehiclesServicedDetailsForm.VehicleTextBox.Text = OwnedVehicleDataGridView.Item(1, CurrentOwnedVehicleDataGridViewRow).Value
        VehiclesServicedDetailsForm.Show()
    End Sub

    Private Sub EditVehicleToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EditVehicleToolStripMenuItem1.Click
        Tunnel1 = "EDIT"
        Tunnel2 = CurrentOwnerId
        Tunnel3 = CurrentOwnedVehicleID
        '       LoadOwnedVehicleDetails()
        ShowVehiclesServicedDetailsForm()
    End Sub
    Private Sub LoadOwnedVehicleDetails()
        OwnedVehicleDataGridView.Columns.Item("VehicleServicedID_AutoNumber").Visible = False
        OwnedVehicleDataGridView.Columns.Item("VehicleDetailsID_LongInteger").Visible = False
        OwnedVehicleDataGridView.Columns.Item("OwnerID_LongInteger").Visible = False

        OwnedVehicleDataGridView.Columns.Item("VinNo_ShortText20").Width = 200
        OwnedVehicleDataGridView.Columns.Item("VinNo_ShortText20").HeaderText = "VIN"

        OwnedVehicleDataGridView.Columns.Item("PlateNumber_ShortText20").Width = 100
        OwnedVehicleDataGridView.Columns.Item("PlateNumber_ShortText20").HeaderText = "Plate #"

        OwnedVehicleDataGridView.Columns.Item("YearManufactured_ShortText4").Width = 50
        OwnedVehicleDataGridView.Columns.Item("YearManufactured_ShortText4").HeaderText = "Year"

        OwnedVehicleDataGridView.Columns.Item("VehicleType_ShortText20").Width = 100
        OwnedVehicleDataGridView.Columns.Item("VehicleType_ShortText20").HeaderText = "Make"

        OwnedVehicleDataGridView.Columns.Item("VehicleModel_ShortText20").Width = 100
        OwnedVehicleDataGridView.Columns.Item("VehicleModel_ShortText20").HeaderText = "Model"

        OwnedVehicleDataGridView.Columns.Item("VehicleTrimName_ShortText25").Width = 50
        OwnedVehicleDataGridView.Columns.Item("VehicleTrimName_ShortText25").HeaderText = "Trim"

        If Not IsDBNull(OwnedVehicleDataGridView.Item("LastName_ShortText15", CurrentOwnedVehicleDataGridViewRow).Value) Then
            OwnerDetailsForm.LastNameTextBox.Text = OwnerDataGridView.Item("LastName_ShortText15", CurrentOwnerDataGridViewRow).Value
        End If

        If Not IsDBNull(OwnedVehicleDataGridView.Item("FirstName_ShortText15", CurrentOwnedVehicleDataGridViewRow).Value) Then
            OwnerDetailsForm.FirstNameTextBox.Text = OwnerDataGridView.Item("FirstName_ShortText15", CurrentOwnerDataGridViewRow).Value
        End If

        If Not IsDBNull(OwnedVehicleDataGridView.Item("NamePrefix_ShortText3", CurrentOwnedVehicleDataGridViewRow).Value) Then
            OwnerDetailsForm.NamePrefixTextBox.Text = OwnerDataGridView.Item("NamePrefix_ShortText3", CurrentOwnerDataGridViewRow).Value
        End If

        If Not IsDBNull(OwnedVehicleDataGridView.Item("NickName_ShortText15", CurrentOwnedVehicleDataGridViewRow).Value) Then
            OwnerDetailsForm.AliasTextBox.Text = OwnerDataGridView.Item("NickName_ShortText15", CurrentOwnerDataGridViewRow).Value
        End If

    End Sub


    Private Sub RemoveVehicleToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RemoveVehicleToolStripMenuItem1.Click
        '        Dim CurrentServicedVehicleID = OwnedVehicleDataGridView.Item("VehicleDetailsID_LongInteger", CurrentOwnedVehicleDataGridViewRow).Value

        RecordFinderDbControls.AddParam("@CurrentServicedVehicleID", CurrentOwnedVehicleID)


        MySelection = "Select * from WorkOrderTable WHERE VehicleServicedID_LongInteger = @CurrentOwnedVehicleID"
        JustExecuteMySelection()

        If RecordCount > 0 Then
            MsgBox("This vehicle has a service record, unable to delete")
            Exit Sub
        End If

        RecordFinderDbControls.AddParam("@CurrentServicedVehicleID", CurrentOwnedVehicleID)

        MySelection = "Delete from VehicleServicedTable WHERE VehicleServicedID_AutoNumber = @CurrentOwnedVehicleID"
        JustExecuteMySelection()
        GetOwnedVehicles()
    End Sub

    Private Sub OwnedVehicleDataGridView_Click(sender As Object, e As EventArgs) Handles OwnedVehicleDataGridView.Click
        SelectCustomerToolStripMenuItem.Visible = True
        OwnerDataGridView.Visible = True
    End Sub



End Class