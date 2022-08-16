Public Class OwnersForm
    Public CurrentOwnerId As Integer
    Private CurrentOwnerDataGridViewRow As Integer

    Private CurrentOwnedVehicleDataGridViewRow As Integer
    Private OwnedVehicleCount As Integer
    Public VehicleID As Integer
    Private MyCustomerFilter = ""
    Private FindKey As String
    Public VehiclesDbControls As New MyDbControls
    Private MeLocationX As Integer
    Private MeLocationY As Integer


    Private JobsHistoryFieldsToSelect = ""
    Private JobsHistoryTableLinks = ""
    Private JobsHistorySelectionFilter = ""
    Private JobsHistorySelectionOrder = ""
    Private JobsHistoryRecordCount As Integer = -1
    Private CurrentJobsHistoryID As Integer = -1
    Private CurrentJobsHistoryDataGridViewRow As Integer = -1
    Private JobsHistoryDataGridViewAlreadyFormated = False


    Private CurrentCityID As Double = 0
    Private PurposeOfEntry As String
    Dim PhoneNumber = ""

    Private OwnersDataGridViewAlreadyFormated As Boolean = False
    Private OwnedVehiclesDataGridViewAlreadyFormated = False
    Private CurrentOwnedVehiclesFilter = ""
    Private SavedCallingForm As Form



    '    Private OwnedVehicleDataGridViewInitialized = False

    Private Sub OwnerForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SavedCallingForm = CallingForm
        If Tunnel1 = "Tunnel2IsOwnerID" Then
            CurrentOwnerId = Tunnel2
            MyCustomerFilter = " WHERE OwnerID_AutoNumber = " & Str(CurrentOwnerId)
        End If

        FillOwnerDataGridView()

        ' PRIOR TO LOAD, FORM MAY BE LOADED WITH DATA FOR THE SEARCH FIELD

        NameSearchTextBox.Select()
        If Not (NameSearchTextBox.Text = "Search" And PhoneNumberSearchTextBox.Text = "Search") Then
            If NameSearchTextBox.Text = "Search" Then
                PhoneNumberSearchTextBox.Select()
            End If
        End If

    End Sub

    Private Sub FillOwnerDataGridView()

        MySelection = "Select OwnersTable.OwnerID_AutoNumber, " &
                      "       OwnersTable.LastName_ShortText30, " &
                      "       OwnersTable.FirstName_ShortText30, " &
                      "       OwnersTable.NamePrefix_ShortText3, " &
                      "       OwnersTable.NickName_ShortText15, " &
                      "       OwnersTable.TelNo_ShortText10, " &
                      "       OwnersTable.EmailAddress_ShortText20, " &
                      "       OwnersTable.Street_ShortText25, " &
                      "       OwnersTable.BldgAptRmNo_ShortText25, " &
                      "       OwnersTable.CityID_LongInteger, " &
                      "       CityTable.CityName_ShortText25, " &
                      "       StateProvTable.StateProvName_ShortText25, " &
                      "       CityTable.ZipCode_ShortText9, " &
                      "       StateProvTable.StateCode_ShortText2, " &
                      "       StateProvTable.CountryID_LongInteger, " &
                      "       CountryTable.CountryName_ShortText25 " &
                      "       FROM((OwnersTable LEFT JOIN CityTable ON OwnersTable.CityID_LongInteger = CityTable.CityID_AutoNumber) " &
                      "                        LEFT JOIN StateProvTable On CityTable.StateProvID_LongInteger = StateProvTable.StateProvID_AutoNumber) " &
                      "                        LEFT JOIN CountryTable On StateProvTable.CountryID_LongInteger = CountryTable.CountryID_Autonumber "

        ' FILL DATAGRID
        If NoRecordFound() Then Dim Dummytatemet = ""

        OwnerDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable


        If Not OwnersDataGridViewAlreadyFormated Then
            FormatOwnersDataGridView()
        End If

        Dim NoOfHeaderLines = 1
        Dim RecordsDisplyed = RecordCount
        Dim FormLowPointFromGrid = 90
        If RecordCount > 22 Then
            Me.Location = New Point(MeLocationX, 50)
            RecordsDisplyed = 22
        Else
            RecordsDisplyed = RecordCount + 1
        End If
        OwnedVehiclesDataGridView.Height = (OwnedVehiclesDataGridView.ColumnHeadersHeight * NoOfHeaderLines) + (DataGridViewRowHeight * RecordsDisplyed) + DataGridViewRowHeight
    End Sub
    Private Sub FormatOwnersDataGridView()
        OwnersDataGridViewAlreadyFormated = True
        OwnerDataGridView.Columns.Item("OwnerID_AutoNumber").Visible = False
        OwnerDataGridView.Columns.Item("LastName_ShortText30").HeaderText = "Last Name"
        OwnerDataGridView.Columns.Item("LastName_ShortText30").Width = 100

        OwnerDataGridView.Columns.Item("FirstName_ShortText30").HeaderText = "Firt Name"
        OwnerDataGridView.Columns.Item("FirstName_ShortText30").Width = 100

        OwnerDataGridView.Columns.Item("NickName_ShortText15").HeaderText = "Alias"
        OwnerDataGridView.Columns.Item("NickName_ShortText15").Width = 100

        OwnerDataGridView.Columns.Item("TelNo_ShortText10").HeaderText = "Phone #"
        OwnerDataGridView.Columns.Item("TelNo_ShortText10").Width = 100

    End Sub
    Private Sub OwnerDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles OwnerDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        CurrentOwnerDataGridViewRow = e.RowIndex
        If CurrentOwnerId = OwnerDataGridView.Item("OwnerID_AutoNumber", CurrentOwnerDataGridViewRow).Value Then Exit Sub
        CurrentOwnerId = OwnerDataGridView.Item("OwnerID_AutoNumber", CurrentOwnerDataGridViewRow).Value
        SelectedCustomerTextBox.Text = OwnerDataGridView.Item("FirstName_ShortText30", CurrentOwnerDataGridViewRow).Value & " " &
                                       OwnerDataGridView.Item("LastName_ShortText30", CurrentOwnerDataGridViewRow).Value & " " &
                                       OwnerDataGridView.Item("NamePrefix_ShortText3", CurrentOwnerDataGridViewRow).Value

        FillOwnedVehiclesDataGridView()

    End Sub

    Private Sub OwnedVehicleDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles OwnedVehiclesDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If OwnedVehicleCount = 0 Then Exit Sub

        CurrentOwnedVehicleDataGridViewRow = e.RowIndex
        CurrentVehicleID = OwnedVehiclesDataGridView.Item("ServicedVehicleID_AutoNumber", CurrentOwnedVehicleDataGridViewRow).Value
        JobsHistorySelectionFilter = " WHERE ServicedVehicleID_LongInteger = " & Str(CurrentVehicleID)
        SelectedVehicleTextBox.Text = OwnedVehiclesDataGridView.Item("VehicleModel", CurrentOwnedVehicleDataGridViewRow).Value
        FillJobsHistoryDataGridView()
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
            MyCustomerFilter = " WHERE FirstName_ShortText30 LIKE @FindKey or " &
                                       " LastName_ShortText30 LIKE @FindKey or " &
                                       " NickName_ShortText15 LIKE @FindKey "
        End If

        FillOwnerDataGridView()
    End Sub
    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        PurposeOfEntry = "ADD"
        CurrentCityID = -1
        CurrentOwnerId = -1
        LastNameTextBox.Text = ""
        FirstNameTextBox.Text = ""
        NamePrefixTextBox.Text = ""
        AliasTextBox.Text = ""
        EmailAddressTextBox.Text = ""
        PhoneNumberTextBox.Text = ""
        StreetTextBox.Text = ""
        BldgAptRmNoTextBox.Text = ""
        CityTextBox.Text = ""
        CountryTextBox.Text = DefaultCountryName
        StateProvTextBox.Text = DefaultStateName
        LastNameTextBox.Select()

        OwnerDetailsGroupBox.Visible = True

    End Sub
    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        PurposeOfEntry = "EDIT"
        LoadOwnerDetails()
    End Sub
    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        PurposeOfEntry = "DELETE"
        LoadOwnerDetails()
    End Sub
    Private Sub LoadOwnerDetails()
        LastNameTextBox.Text = NotNull(OwnerDataGridView.Item("LastName_ShortText30", CurrentOwnerDataGridViewRow).Value)
        FirstNameTextBox.Text = NotNull(OwnerDataGridView.Item("FirstName_ShortText30", CurrentOwnerDataGridViewRow).Value)
        NamePrefixTextBox.Text = NotNull(OwnerDataGridView.Item("NamePrefix_ShortText3", CurrentOwnerDataGridViewRow).Value)
        AliasTextBox.Text = NotNull(OwnerDataGridView.Item("NickName_ShortText15", CurrentOwnerDataGridViewRow).Value)
        PhoneNumberTextBox.Text = NotNull(OwnerDataGridView.Item("TelNo_ShortText10", CurrentOwnerDataGridViewRow).Value)
        EmailAddressTextBox.Text = NotNull(OwnerDataGridView.Item("EmailAddress_ShortText20", CurrentOwnerDataGridViewRow).Value)
        StreetTextBox.Text = NotNull(OwnerDataGridView.Item("Street_ShortText25", CurrentOwnerDataGridViewRow).Value)
        BldgAptRmNoTextBox.Text = NotNull(OwnerDataGridView.Item("BldgAptRmNo_ShortText25", CurrentOwnerDataGridViewRow).Value)
        StateProvTextBox.Text = NotNull(OwnerDataGridView.Item("StateProvName_ShortText25", CurrentOwnerDataGridViewRow).Value)
        CityTextBox.Text = NotNull(OwnerDataGridView.Item("CityName_ShortText25", CurrentOwnerDataGridViewRow).Value)
        CountryTextBox.Text = NotNull(OwnerDataGridView.Item("CountryName_ShortText25", CurrentOwnerDataGridViewRow).Value)

        OwnerDetailsGroupBox.Visible = True
    End Sub
    Private Sub EnableOwnersMenus()
        CurrentSelectionGroupBox.Enabled = True
        OwnerDataGridView.Enabled = True
        MenuStrip1.Enabled = True
        ToolStrip1.Enabled = True
    End Sub
    Private Sub EnableVehiclesMenus()
        OwnedVehiclesDataGridView.Enabled = True
        JobsHistoryDataGridView.Enabled = True
    End Sub
    Private Sub DisableOwnersMenus()
        CurrentSelectionGroupBox.Enabled = False
        OwnerDataGridView.Enabled = False
        MenuStrip1.Enabled = False
        ToolStrip1.Enabled = False
    End Sub
    Private Sub DisableVehiclesMenus()
        OwnedVehiclesDataGridView.Enabled = False
        JobsHistoryDataGridView.Enabled = False
    End Sub

    Private Sub SelectStateProvToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectCustomerToolStripMenuItem.Click
        ReturnRequestedData()
    End Sub
    Private Sub OwnedVehicleDataGridView_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles OwnedVehiclesDataGridView.CellMouseDoubleClick

        If e.RowIndex < 1 Then Exit Sub
        '          Dim VehicleName = " (VehiclesTable.YearManufactured_ShortText4 & space(1) & Trim(VehicleTypeTable.VehicleType_ShortText20) & space(1) & trim(VehicleModelsTable.VehicleModel_ShortText20) & space(1) & trim(VehicleTrimTable.VehicleTrimName_ShortText25) & space(1) & trim(VehiclesTable.Engine_ShortText20)), "
        Dim QuestionIs As String
        Dim Confirmed As Boolean
        QuestionIs = "SELECT this vehicle ?" & Chr(13) & OwnedVehiclesDataGridView(3, e.RowIndex).Value
        Confirmed = MsgBox(QuestionIs, 4)
        If Not Confirmed Then Exit Sub
        ReturnRequestedData()
    End Sub
    Private Sub ReturnRequestedData()
        Dim lastnamexx = Trim(OwnerDataGridView.Item("LastName_ShortText30", CurrentOwnerDataGridViewRow).Value.ToString)
        Dim CustomerString As String = ""
        If lastnamexx = "" Then
            CustomerString = Trim(OwnerDataGridView.Item("FirstName_ShortText30", CurrentOwnerDataGridViewRow).Value.ToString)
        Else
            CustomerString = lastnamexx & ", " & Trim(OwnerDataGridView.Item("FirstName_ShortText30", CurrentOwnerDataGridViewRow).Value)
        End If

        WorkOrderFormCRS.VehicleDetailsTextBox.Text = SelectedVehicleTextBox.Text
        WorkOrderFormCRS.CustomerTextBox.Text = SelectedCustomerTextBox.Text
        WorkOrderFormCRS.VINTextBox.Text = OwnedVehiclesDataGridView.Item("VinNo_ShortText20", CurrentOwnedVehicleDataGridViewRow).Value

        Tunnel1 = "Tunnel2IsCustomerID"
        Tunnel2 = CurrentOwnerId
        Tunnel4 = CurrentVehicleID
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub

    Private Sub FillOwnedVehiclesDataGridView()
        OwnerDataGridView.Enabled = False
        Dim VehicleName = " (VehiclesTable.YearManufactured_ShortText4 & space(1) & 
                            Trim(VehicleTypeTable.VehicleType_ShortText20) & space(1) & 
                            trim(VehicleModelsTable.VehicleModel_ShortText20) & space(1) & 
                            trim(VehicleTrimTable.VehicleTrimName_ShortText25) & space(1) & 
                            trim(VehiclesTable.Engine_ShortText20)) as VehicleModel, "

        MySelection = " Select ServicedVehiclesTable.ServicedVehicleID_AutoNumber, " &
                             VehicleName &
                             " ServicedVehiclesTable.VinNo_ShortText20, " &
                             " ServicedVehiclesTable.PlateNumber_ShortText20, " &
                             " ServicedVehiclesTable.OwnerID_LongInteger, " &
                             " ServicedVehiclesTable.VehicleID_LongInteger, " &
                             " VehiclesTable.VehicleModelsRelationID_LongInteger "

        Dim MyLinks = " FROM(((((ServicedVehiclesTable LEFT JOIN VehiclesTable ON ServicedVehiclesTable.VehicleID_LongInteger = VehiclesTable.VehicleID_AutoNumber) " &
                             " LEFT JOIN VehicleModelsRelationsTable On VehiclesTable.[VehicleModelsRelationID_LongInteger] = VehicleModelsRelationsTable.VehicleModelsRelationID_Autonumber) " &
                             " LEFT JOIN VehicleModelsTable On VehicleModelsRelationsTable.VehicleModelID_LongInteger = VehicleModelsTable.VehicleModelID_Autonumber) " &
                             " LEFT JOIN VehicleTypeTable On VehicleModelsRelationsTable.VehicleTypeID_LongInteger = VehicleTypeTable.VehicleTypeID_AutoNumber) " &
                             " LEFT JOIN VehicleTrimTable On VehicleModelsRelationsTable.VehicleTrimID_LongInteger = VehicleTrimTable.VehicleTrimID_Autonumber) " &
                             " LEFT JOIN OwnersTable On ServicedVehiclesTable.OwnerID_LongInteger = OwnersTable.OwnerID_AutoNumber "

        MySelection = MySelection & MyLinks & " WHERE OwnerID_LongInteger = " & Str(CurrentOwnerId)

        '       VehiclesDbControls.MyDbCommand(MySelection)
        JustExecuteMySelection()

        OwnedVehicleCount = RecordCount
        If OwnedVehicleCount = 0 Then
            JobsHistoryDataGridView.Visible = False
        Else
            JobsHistoryDataGridView.Visible = True
        End If
        OwnedVehiclesDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        Dim HeightToAdd = IIf(OwnedVehicleCount = 0, 0, ((OwnedVehicleCount) * DataGridViewRowHeight))
        OwnedVehiclesDataGridView.Height = OwnedVehiclesDataGridView.ColumnHeadersHeight + HeightToAdd + DataGridViewRowHeight
        JobsHistoryDataGridView.Top = OwnedVehiclesDataGridView.Top + OwnedVehiclesDataGridView.Height

        If Not OwnedVehiclesDataGridViewAlreadyFormated Then
            FormatOwnedVehiclesDataGridView()
        End If

        OwnerDataGridView.Enabled = True
    End Sub
    Private Sub FormatOwnedVehiclesDataGridView()
        OwnedVehiclesDataGridViewAlreadyFormated = True
        OwnedVehiclesDataGridView.Width = 0
        For i = 0 To OwnedVehiclesDataGridView.Columns.GetColumnCount(0) - 1
            OwnedVehiclesDataGridView.Columns.Item(i).Visible = False
            Select Case OwnedVehiclesDataGridView.Columns.Item(i).Name
                Case "VinNo_ShortText20"
                    OwnedVehiclesDataGridView.Columns.Item(i).HeaderText = "VIN"
                    OwnedVehiclesDataGridView.Columns.Item(i).Width = 200
                    OwnedVehiclesDataGridView.Columns.Item(i).Visible = True
                Case "PlateNumber_ShortText20"
                    OwnedVehiclesDataGridView.Columns.Item(i).HeaderText = "Plate #"
                    OwnedVehiclesDataGridView.Columns.Item(i).Width = 100
                    OwnedVehiclesDataGridView.Columns.Item(i).Visible = True
                Case "VehicleModel"
                    OwnedVehiclesDataGridView.Columns.Item(i).HeaderText = "Vehicle Model"
                    OwnedVehiclesDataGridView.Columns.Item(i).Width = 300
                    OwnedVehiclesDataGridView.Columns.Item(i).Visible = True
            End Select
            If OwnedVehiclesDataGridView.Columns.Item(i).Visible = True Then
                OwnedVehiclesDataGridView.Width = OwnedVehiclesDataGridView.Width + OwnedVehiclesDataGridView.Columns.Item(i).Width
            End If
        Next

        ' NOTE" SYSTEM AUTOFITS THE GRIDVIEW FIELDS ACCORDING TO THEIR WITDH

    End Sub

    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub

    Private Sub OwnerForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        If Me.Enabled = False Then Exit Sub
        CallingForm = SavedCallingForm

        Select Case Tunnel1
            Case "Tunnel2IsVehicleID"
                CurrentVehicleID = Tunnel2
                VehicleTextBox.Text = Tunnel3
        End Select

    End Sub
    Private Sub AddVehicleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddVehicleToolStripMenuItem.Click
        PurposeOfEntry = "ADD"
        CurrentVehicleID = -1 'this variable has been declared universal
        CurrentOwnedVehiclesFilter = ""
        For i = 0 To OwnedVehicleCount - 1
            CurrentOwnedVehiclesFilter = CurrentOwnedVehiclesFilter & OwnedVehiclesDataGridView.Item("VehicleID_LongInteger", i).Value & "|"
        Next
        ServicedVehicleDetailsGroupBox.Visible = True
        LoadVehiclesServicedDetailsForm()

    End Sub
    Private Sub EditVehicleToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EditVehicleToolStripMenuItem1.Click
        PurposeOfEntry = "EDIT"
        LoadVehiclesServicedDetailsForm()
    End Sub
    Private Sub RemoveVehicleToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RemoveVehicleToolStripMenuItem1.Click
        If JobsHistoryRecordCount > 0 Then
            MsgBox("This vehicle has service record(s), Unable to DELETE")
            Exit Sub
        End If
        If MsgBox("Cancel DELETING this vehicle ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then Exit Sub
        MySelection = "Delete from ServicedVehiclesTable WHERE ServicedVehicleID_AutoNumber =  " & CurrentVehicleID.ToString
        JustExecuteMySelection()
        FillOwnedVehiclesDataGridView()
    End Sub
    Private Sub LoadVehiclesServicedDetailsForm()

        If PurposeOfEntry = "ADD" Then
            VINtextBox.Text = ""
            PlateNumberTextBox.Text = ""
            VehicleTextBox.Text = ""
        Else
            VINtextBox.Text = NotNull(OwnedVehiclesDataGridView.Item("VinNo_ShortText20", CurrentOwnedVehicleDataGridViewRow).Value)
            PlateNumberTextBox.Text = NotNull(OwnedVehiclesDataGridView.Item("PlateNumber_ShortText20", CurrentOwnedVehicleDataGridViewRow).Value)
            VehicleTextBox.Text = NotNull(OwnedVehiclesDataGridView.Item(1, CurrentOwnedVehicleDataGridViewRow).Value)
        End If

        VehiclesServicedDetailsForm.Text = "CUSTOMER: " & SelectedCustomerTextBox.Text

    End Sub
    Private Sub ServicedVehicleDetailsGroupBox_VisibleChanged(sender As Object, e As EventArgs) Handles ServicedVehicleDetailsGroupBox.VisibleChanged
        If ServicedVehicleDetailsGroupBox.Visible = True Then
            DisableOwnersMenus()
            DisableVehiclesMenus()
        Else
            EnableOwnersMenus()
            EnableVehiclesMenus()
        End If
    End Sub



    Private Sub OwnedVehicleDataGridView_Click(sender As Object, e As EventArgs) Handles OwnedVehiclesDataGridView.Click
        SelectCustomerToolStripMenuItem.Visible = True
        OwnerDataGridView.Visible = True
    End Sub

    Private Sub FillJobsHistoryDataGridView()

        '   USING JobsHistoryQuery

        JobsHistoryFieldsToSelect =
            " 
Select 
WorkOrdersTable.ServiceDate_DateTime,
WorkOrderConcernJobsTable.WorkOrderConcernJobID_AutoNumber,
WorkOrderConcernJobsTable.WorkOrderConcernID_LongInteger,
WorkOrderConcernJobsTable.InformationsHeaderID_LongInteger,
WorkOrderConcernJobsTable.WorkOrderConcernJobStatus_Byte,
WorkOrderConcernsTable.WorkOrderID_LongInteger,
Trim(InformationsHeadersTypeTable.ConcernPrefix_ShortText50) & Space(1) & MasterCodeBookTable.SystemDesc_ShortText100Fld AS Job,
InformationsHeadersTypeTable.ConcernPrefix_ShortText50, MasterCodeBookTable.SystemDesc_ShortText100Fld,
InformationsHeadersTable.InformationsHeaderDescription_ShortText255,
OriginalExcelRecordTable.description, 
InformationsHeadersTable.MasterCodeBookId_LongInteger,
WorkOrdersTable.ServicedVehicleID_LongInteger
FROM (((((WorkOrderConcernJobsTable 
LEFT JOIN WorkOrderConcernsTable ON WorkOrderConcernJobsTable.WorkOrderConcernID_LongInteger = WorkOrderConcernsTable.WorkOrderConcernID_AutoNumber) 
LEFT JOIN OriginalExcelRecordTable ON WorkOrderConcernJobsTable.OriginalID_LongInteger = OriginalExcelRecordTable.OriginalID_AutoNumber) 
LEFT JOIN InformationsHeadersTable ON WorkOrderConcernJobsTable.InformationsHeaderID_LongInteger = InformationsHeadersTable.InformationsHeaderID_AutoNumber) 
LEFT JOIN InformationsHeadersTypeTable ON InformationsHeadersTable.InformationsHeadersTypeID_LongInteger = InformationsHeadersTypeTable.InformationsHeadersTypeID_AutoNumber) 
LEFT JOIN MasterCodeBookTable ON InformationsHeadersTable.MasterCodeBookId_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) 
LEFT JOIN WorkOrdersTable ON WorkOrderConcernJobsTable.WorkOrderID_LongInteger = WorkOrdersTable.WorkOrderID_AutoNumber
"



        JobsHistorySelectionOrder = " ORDER BY WorkOrdersTable.ServiceDate_DateTime DESC"

        MySelection = JobsHistoryFieldsToSelect & JobsHistorySelectionFilter & JobsHistorySelectionOrder


        JustExecuteMySelection()


        JobsHistoryRecordCount = RecordCount
        JobsHistoryDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable


        If Not JobsHistoryDataGridViewAlreadyFormated Then
            JobsHistoryDataGridViewAlreadyFormated = True
            FormatJobsHistoryDataGridView()
        End If

    End Sub


    Private Sub FormatJobsHistoryDataGridView()


        Dim HeightToAdd = IIf(JobsHistoryRecordCount = 0, 0, ((JobsHistoryRecordCount) * DataGridViewRowHeight))
        JobsHistoryDataGridView.Height = JobsHistoryDataGridView.ColumnHeadersHeight + HeightToAdd + 100

        JobsHistoryDataGridView.Width = 0

        For i = 0 To JobsHistoryDataGridView.Columns.GetColumnCount(0) - 1

            JobsHistoryDataGridView.Columns.Item(i).Visible = False

            Select Case JobsHistoryDataGridView.Columns.Item(i).Name
                Case "Job"
                    JobsHistoryDataGridView.Columns.Item(i).HeaderText = "Job"
                    JobsHistoryDataGridView.Columns.Item(i).Width = 300
                    JobsHistoryDataGridView.Columns.Item(i).Visible = True
                Case "description"
                    JobsHistoryDataGridView.Columns.Item(i).HeaderText = "History record"
                    JobsHistoryDataGridView.Columns.Item(i).Width = 300
                    JobsHistoryDataGridView.Columns.Item(i).Visible = True
                Case "ServiceDate_DateTime"
                    JobsHistoryDataGridView.Columns.Item(i).HeaderText = "Date"
                    JobsHistoryDataGridView.Columns.Item(i).Width = 100
                    JobsHistoryDataGridView.Columns.Item(i).Visible = True
            End Select
            If JobsHistoryDataGridView.Columns.Item(i).Visible = True Then
                JobsHistoryDataGridView.Width = JobsHistoryDataGridView.Width + JobsHistoryDataGridView.Columns.Item(i).Width
            End If
        Next


        JobsHistoryDataGridView.Width = OwnedVehiclesDataGridView.Width
        JobsHistoryDataGridView.Left = OwnedVehiclesDataGridView.Left

        Me.Left = (VehicleManagementSystemForm.Width - Me.Width) / 2
        Me.Location = New Point(Me.Location.X, 55)
        '===========================


        Dim NoOfHeaderLines = 1
        Dim RecordsDisplyed = JobsHistoryRecordCount
        Dim FormLowPointFromGrid = 90
        If JobsHistoryRecordCount > 15 Then
            RecordsDisplyed = 15
        Else
            RecordsDisplyed = JobsHistoryRecordCount
        End If

        JobsHistoryDataGridView.Height = (JobsHistoryDataGridView.ColumnHeadersHeight * NoOfHeaderLines * 2) + (DataGridViewRowHeight * (RecordsDisplyed + 1))



    End Sub
    Private Sub JobsHistoryDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 Then Exit Sub
        If JobsHistoryRecordCount = 0 Then Exit Sub

        CurrentJobsHistoryDataGridViewRow = e.RowIndex

        CurrentJobsHistoryID = JobsHistoryDataGridView.Item("JobsHistoryID_Autonumber", CurrentJobsHistoryDataGridViewRow).Value
    End Sub
    Private Function AChangeOccuredInOwnerDetails()
        If TheseAreNotEqual(LastNameTextBox.Text, OwnerDataGridView.Item("LastName_ShortText30", CurrentOwnerDataGridViewRow).Value, PurposeOfEntry) Then Return True
        If TheseAreNotEqual(FirstNameTextBox.Text, OwnerDataGridView.Item("FirstName_ShortText30", CurrentOwnerDataGridViewRow).Value, PurposeOfEntry) Then Return True
        If TheseAreNotEqual(NamePrefixTextBox.Text, OwnerDataGridView.Item("NamePrefix_ShortText3", CurrentOwnerDataGridViewRow).Value, PurposeOfEntry) Then Return True
        If TheseAreNotEqual(AliasTextBox.Text, OwnerDataGridView.Item("NickName_ShortText15", CurrentOwnerDataGridViewRow).Value, PurposeOfEntry) Then Return True
        If TheseAreNotEqual(EmailAddressTextBox.Text, OwnerDataGridView.Item("EmailAddress_ShortText20", CurrentOwnerDataGridViewRow).Value, PurposeOfEntry) Then Return True
        If TheseAreNotEqual(PhoneNumberTextBox.Text, OwnerDataGridView.Item("TelNo_ShortText10", CurrentOwnerDataGridViewRow).Value, PurposeOfEntry) Then Return True
        If TheseAreNotEqual(StreetTextBox.Text, OwnerDataGridView.Item("Street_ShortText25", CurrentOwnerDataGridViewRow).Value, PurposeOfEntry) Then Return True
        If TheseAreNotEqual(BldgAptRmNoTextBox.Text, OwnerDataGridView.Item("BldgAptRmNo_ShortText25", CurrentOwnerDataGridViewRow).Value, PurposeOfEntry) Then Return True
        If TheseAreNotEqual(CityTextBox.Text, OwnerDataGridView.Item("CityName_ShortText25", CurrentOwnerDataGridViewRow).Value, PurposeOfEntry) Then Return True
        If TheseAreNotEqual(StateProvTextBox.Text, DefaultStateName, PurposeOfEntry) Then Return True
        If TheseAreNotEqual(CountryTextBox.Text, DefaultCountryName, PurposeOfEntry) Then Return True
        Return False
    End Function

    Private Sub EXITSAVEChangesButton_Click(sender As Object, e As EventArgs) Handles EXITSAVEOwnerChangesButton.Click
        If Not AChangeOccuredInOwnerDetails() Then
            If MsgBox("You have no new entries to save, CANCEL Editing ?", MsgBoxStyle.YesNo) = vbYes Then OwnerDetailsGroupBox.Visible = False
            Exit Sub
        End If
        Dim xxMessage = ""
        If PurposeOfEntry = "ADD" Then
            xxMessage = "Proceed adding this as NEW CUSTOMER?"
        Else
            xxMessage = "Proceed saving CHANGES ?"
        End If
        If MsgBox(xxMessage, MsgBoxStyle.YesNo) = vbNo Then
            OwnerDetailsGroupBox.Visible = False
            Exit Sub
        End If

        If OwnerFieldsEntriesAreNotValidAndComplete() Then Exit Sub

        UpdateOwnersTable()
    End Sub

    Private Sub UpdateOwnersTable()

        ' If Record is not Found then Insert the record 
        If PurposeOfEntry = "ADD" Then
            InsertNewOwnerRecord()
        Else
            UpdateCurrentOwnerRecord()
        End If

    End Sub
    Private Sub UpdateCurrentOwnerRecord()
        Dim OwnerFieldsToUpdate = ""
        Dim OwnerFilter = " WHERE OwnerID_AutoNumber = " & Str(CurrentOwnerId)
        Dim MyNull = Chr(34) & Chr(34)

        MySelection = " UPDATE OwnersTable " &
                              " SET LastName_ShortText30 = " & Chr(34) & LastNameTextBox.Text & Chr(34) & ", " &
                              "     FirstName_ShortText30  = " & Chr(34) & FirstNameTextBox.Text & Chr(34)

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

    End Sub
    Private Sub InsertNewOwnerRecord()

        MySelection = "Select TOP 1 * FROM OwnersTable WHERE LastName_ShortText30  = " & Chr(34) & LastNameTextBox.Text & Chr(34) &
                        " AND FirstName_ShortText30 = " & Chr(34) & FirstNameTextBox.Text & Chr(34)

        If RecordIsFound() Then
            r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
            Dim xxTElNo = r("TelNo_ShortText10")
            Dim xxMessage = FirstNameTextBox.Text & LastNameTextBox.Text
            If MsgBox(xxMessage & "is existing " & vbCrLf & " is the customer's phone number " & xxTElNo & " ?", vbYesNo) = vbYes Then
                OwnerDetailsGroupBox.Visible = False
                PhoneNumberSearchTextBox.Text = xxTElNo
                Exit Sub
            End If
        End If

        Dim FieldsToUpdate = " OwnerID_AutoNumber, " &
                                " LastName_ShortText30, " &
                                " FirstName_ShortText30, " &
                                " NamePrefix_ShortText3, " &
                                " NickName_ShortText15, " &
                                " TelNo_ShortText10, " &
                                " EmailAddress_ShortText20, " &
                                " Street_ShortText25, " &
                                " BldgAptRmNo_ShortText25, " &
                                " CityID_LongInteger "

        Dim FieldsData = CurrentOwnerId.ToString & ", " &
                                Chr(34) & LastNameTextBox.Text & Chr(34) & ", " &
                                Chr(34) & FirstNameTextBox.Text & Chr(34) & ", " &
                                Chr(34) & NamePrefixTextBox.Text & Chr(34) & ", " &
                                Chr(34) & AliasTextBox.Text & Chr(34) & ", " &
                                Chr(34) & PhoneNumberTextBox.Text & Chr(34) & ", " &
                                Chr(34) & EmailAddressTextBox.Text & Chr(34) & ", " &
                                Chr(34) & StreetTextBox.Text & Chr(34) & ", " &
                                Chr(34) & BldgAptRmNoTextBox.Text & Chr(34) & ", " &
                                CurrentCityID.ToString

        CurrentOwnerId = InsertNewRecord("OwnersTable", FieldsToUpdate, FieldsData)


        MySelection = "Select TOP 1 * FROM OwnersTable WHERE LastName_ShortText30  = " & Chr(34) & LastNameTextBox.Text & Chr(34) &
                        " AND FirstName_ShortText30 = " & Chr(34) & FirstNameTextBox.Text & Chr(34)

        If NoRecordFound() Then
            MsgBox("PROBLEM ...... unseccessful save ")
            Exit Sub
        End If


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
                    MsgBox("Pls double check your phone number")
                    PhoneNumberTextBox.Select()
                    Return True
                End If
            End If
        End If
        If MaxLengthOfFieldExceeded(LastNameTextBox, 15) Then Return True
        If MaxLengthOfFieldExceeded(FirstNameTextBox, 15) Then Return True
        If MaxLengthOfFieldExceeded(NamePrefixTextBox, 3) Then Return True
        If MaxLengthOfFieldExceeded(AliasTextBox, 15) Then Return True
        If MaxLengthOfFieldExceeded(EmailAddressTextBox, 20) Then Return True
        If MaxLengthOfFieldExceeded(BldgAptRmNoTextBox, 25) Then Return True
        Return False
    End Function

    Private Sub OwnerDetailsGroupBox_VisibleChanged(sender As Object, e As EventArgs) Handles OwnerDetailsGroupBox.VisibleChanged
        If OwnerDetailsGroupBox.Visible = True Then
            DisableOwnersMenus()
            DisableVehiclesMenus()
        Else
            EnableOwnersMenus()
            EnableVehiclesMenus()
        End If
    End Sub
    Private Sub NamePrefixTextBox_TextChanged(sender As Object, e As EventArgs) Handles NamePrefixTextBox.TextChanged
        If Len(Trim(NamePrefixTextBox.Text)) > 3 Then
            NamePrefixTextBox.Text = Mid(NamePrefixTextBox.Text, 1, 0)
        End If
    End Sub
    Private Sub CityTextBox_TextChanged(sender As Object, e As EventArgs) Handles CityTextBox.Leave
        If CityTextBox.Text = "" Then Exit Sub
        Tunnel1 = StateProvTextBox.Text
        Tunnel3 = CountryTextBox.Text
        CityForm.SearchCityTextBox.Select()
        CityForm.SearchCityTextBox.Text = CityTextBox.Text
        ShowCalledForm(Me, CityForm)

    End Sub
    Private Sub VehicleTextBox_Click(sender As Object, e As EventArgs) Handles VehicleTextBox.Click
        If Not VehicleTextBox.Text = "" Then
            If MsgBox("Change the vehicle ?", MsgBoxStyle.YesNo) = vbNo Then Exit Sub
        End If
        ShowCalledForm(Me, VehiclesForm)
    End Sub
    Private Function AChangeOccuredInVehicleDetails()
        If TheseAreNotEqual(VINtextBox.Text, OwnedVehiclesDataGridView.Item("VinNo_ShortText20", CurrentOwnedVehicleDataGridViewRow).Value, PurposeOfEntry) Then Return True
        If TheseAreNotEqual(PlateNumberTextBox.Text, OwnedVehiclesDataGridView.Item("PlateNumber_ShortText20", CurrentOwnedVehicleDataGridViewRow).Value, PurposeOfEntry) Then Return True
        If TheseAreNotEqual(VehicleTextBox.Text, OwnedVehiclesDataGridView.Item(1, CurrentOwnedVehicleDataGridViewRow).Value, PurposeOfEntry) Then Return True
        Return False
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ExitSaveVehicleChangesButton.Click
        If Not AChangeOccuredInVehicleDetails() Then
            If MsgBox("You have no new entries to save, CANCEL Editing ?", MsgBoxStyle.YesNo) = vbYes Then
                OwnerDetailsGroupBox.Visible = False
                ServicedVehicleDetailsGroupBox.Visible = True
                Exit Sub
            End If
        End If
        Dim xxMessage = ""
        If PurposeOfEntry = "ADD" Then
            xxMessage = "Proceed adding this as NEW Owned Vehicle?"
        Else
            xxMessage = "Proceed saving CHANGES ?"
        End If
        If MsgBox(xxMessage, MsgBoxStyle.YesNo) = vbNo Then
            ServicedVehicleDetailsGroupBox.Visible = False
            Exit Sub
        End If
        If VehicleFieldsEntriesAreNotValidAndComplete() Then
            Exit Sub
        End If


        UpdateOwnedVehicleTable()
        ServicedVehicleDetailsGroupBox.Visible = False
        FillOwnedVehiclesDataGridView()
    End Sub
    Private Function VehicleFieldsEntriesAreNotValidAndComplete()
        If Trim(VINtextBox.Text) = "" Then
            If MsgBox("Would you like to leave the VIN INFO blank ?", vbYesNo) = MsgBoxResult.No Then
                VINtextBox.Select()
                Return True
            End If
        End If
        If Trim(PlateNumberTextBox.Text) = "" Then
            If MsgBox("Would you like to leave the PLATE # INFO blank ?", vbYesNo) = MsgBoxResult.No Then
                PlateNumberTextBox.Select()
                Return True
            End If
        End If

        Return False
    End Function
    Private Sub UpdateOwnedVehicleTable()

        ' If Record is not Found then Insert the record 
        If PurposeOfEntry = "ADD" Then
            InsertNewOwnedVehicleRecord()
        Else
            UpdateCurrentOwnedVehicleRecord()
        End If
        ServicedVehicleDetailsGroupBox.Visible = False
        FillOwnedVehiclesDataGridView()
    End Sub
    Private Sub InsertNewOwnedVehicleRecord()

        Dim FieldsToUpdate = " VinNo_ShortText20, " &
                                " PlateNumber_ShortText20, " &
                                " OwnerID_LongInteger, " &
                                " VehicleID_LongInteger "

        Dim FieldsData = Chr(34) & VINtextBox.Text & Chr(34) & ", " &
                                Chr(34) & PlateNumberTextBox.Text & Chr(34) & ", " &
                                CurrentOwnerId.ToString & ", " &
                                CurrentVehicleID.ToString()

        CurrentOwnerId = InsertNewRecord("ServicedVehiclesTable", FieldsToUpdate, FieldsData)

    End Sub
    Private Sub UpdateCurrentOwnedVehicleRecord()

        MySelection = "Select TOP 1 * FROM ServicedVehiclesTable WHERE ServicedVehicleID_AutoNumber  = " & CurrentVehicleID.ToString


        'MODIFY THIS FOR OWNED VEHICLE
        Dim OwnerFieldsToUpdate = ""
        Dim OwnerFilter = " WHERE OwnerID_AutoNumber = " & Str(CurrentOwnerId)
        Dim MyNull = Chr(34) & Chr(34)

        MySelection = " UPDATE OwnersTable " &
                              " SET LastName_ShortText30 = " & Chr(34) & LastNameTextBox.Text & Chr(34) & ", " &
                              "     FirstName_ShortText30  = " & Chr(34) & FirstNameTextBox.Text & Chr(34)

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

    End Sub

End Class