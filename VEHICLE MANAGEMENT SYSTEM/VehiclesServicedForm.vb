Public Class VehiclesServicedForm
    Private CurrentVehiclesServicedID As Integer = -1
    Private CurrentVehiclesServicedRow As Integer
    Private CurrentVehiclesServicedID_AutoNumber As Integer
    Private CurrentVehicleTypeID As Integer

    Private VehiclesServicedDataGridViewInitialized = False

    Private VehiclesServicedFieldsToSelect = ""
    Private VehiclesServicedTablesLinks = ""
    Private VehiclesServicedSelectionFilter = ""
    Private VehiclesServicedSelectionOrder = ""
    Private MeLocationX As Integer
    Private MeLocationY As Integer
    Private SavedCallingForm As Form
    Private Sub VehiclesServicedForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        SavedCallingForm = CallingForm
        MeLocationX = Me.Location.X

        'GET ALL ENTRY PARAMETERS
        Me.Name = Trim(Tunnel2) & " Models"

        FillVehiclesServicedDataGridView()



        'SET AND RESET ALL ENTRY PARAMETERS

    End Sub
    Private Sub FillVehiclesServicedDataGridView()
        VehiclesServicedFieldsToSelect = "Select " &
                                                 " ServicedVehiclesTable.ServicedVehicleID_AutoNumber, " &
                                                 " ServicedVehiclesTable.VinNo_ShortText20, " &
                                                 " ServicedVehiclesTable.PlateNumber_ShortText20, " &
                                                 " ServicedVehiclesTable.OwnerID_LongInteger, " &
                                                 " ServicedVehiclesTable.VehicleID_LongInteger, " &
                                                 " VehiclesTable.VehicleModelsRelationID_LongInteger, " &
                                                 " VehiclesTable.YearManufactured_ShortText4, " &
                                                 " VehiclesTable.Engine_ShortText20, " &
                                                 " VehiclesTable.BodyType_ShortText20, " &
                                                 " VehiclesTable.EngineSeries_ShortText20, " &
                                                 " VehiclesTable.FuelType_ShortText20, " &
                                                 " VehicleTypeTable.VehicleType_ShortText20, " &
                                                 " VehicleModelsTable.VehicleModel_ShortText20, " &
                                                 " VehicleTrimTable.VehicleTrimName_ShortText25, " &
                                                 " OwnersTable.LastName_ShortText15, " &
                                                 " OwnersTable.FirstName_ShortText15, " &
                                                 " OwnersTable.NamePrefix_ShortText3 "
        VehiclesServicedFieldsToSelect = "Select " &
                                                 "ServicedVehiclesTable.ServicedVehicleID_AutoNumber, ServicedVehiclesTable.VinNo_ShortText20, ServicedVehiclesTable.PlateNumber_ShortText20, ServicedVehiclesTable.OwnerID_LongInteger, ServicedVehiclesTable.VehicleID_LongInteger, VehiclesTable.VehicleModelsRelationID_LongInteger, VehiclesTable.Engine_ShortText20, VehiclesTable.BodyType_ShortText20, VehiclesTable.EngineSeries_ShortText20, VehiclesTable.FuelType_ShortText20, VehicleTypeTable.VehicleType_ShortText20, VehicleModelsTable.VehicleModel_ShortText20, VehicleTrimTable.VehicleTrimName_ShortText25, OwnersTable.LastName_ShortText15, OwnersTable.FirstName_ShortText15, OwnersTable.NamePrefix_ShortText3, VehiclesTable.YearManufactured_ShortText4 "

        VehiclesServicedTablesLinks = " FROM(((((ServicedVehiclesTable LEFT JOIN VehiclesTable ON ServicedVehiclesTable.VehicleID_LongInteger = VehiclesTable.VehicleID_AutoNumber) LEFT JOIN VehicleModelsRelationsTable On VehiclesTable.VehicleModelsRelationID_LongInteger = VehicleModelsRelationsTable.[VehicleModelsRelationID_Autonumber]) LEFT JOIN VehicleModelsTable On VehicleModelsRelationsTable.VehicleModelID_LongInteger = VehicleModelsTable.VehicleModelID_Autonumber) LEFT JOIN VehicleTypeTable On VehicleModelsRelationsTable.VehicleTypeID_LongInteger = VehicleTypeTable.VehicleTypeID_AutoNumber) LEFT JOIN VehicleTrimTable On VehicleModelsRelationsTable.VehicleTrimID_LongInteger = VehicleTrimTable.VehicleTrimID_Autonumber) LEFT JOIN OwnersTable On ServicedVehiclesTable.OwnerID_LongInteger = OwnersTable.OwnerID_AutoNumber "

        VehiclesServicedSelectionOrder = " "

        MySelection = VehiclesServicedFieldsToSelect & VehiclesServicedTablesLinks



        JustExecuteMySelection()
        VehiclesServicedDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        '                                                  ServicedVehiclesTable.VinNo_ShortText20, 
        'ServicedVehiclesTable., 
        'VehiclesTable.Engine_ShortText20, 
        'VehiclesTable.BodyType_ShortText20, 
        'VehiclesTable.EngineSeries_ShortText20, 
        'VehiclesTable.FuelType_ShortText20, 
        'VehicleModelsTable.VehicleModel_ShortText20, 

        VehiclesServicedDataGridView.Columns.Item("VehicleModelsRelationID_LongInteger").Visible = False
        VehiclesServicedDataGridView.Columns.Item("ServicedVehicleID_AutoNumber").Visible = False
        VehiclesServicedDataGridView.Columns.Item("OwnerID_LongInteger").Visible = False
        VehiclesServicedDataGridView.Columns.Item("VehicleID_LongInteger").Visible = False

        VehiclesServicedDataGridView.Columns.Item("VinNo_ShortText20").HeaderText = "VIN"
        VehiclesServicedDataGridView.Columns.Item("VinNo_ShortText20").Width = 200
        VehiclesServicedDataGridView.Width = VehiclesServicedDataGridView.Columns.Item("VinNo_ShortText20").Width

        VehiclesServicedDataGridView.Columns.Item("PlateNumber_ShortText20").HeaderText = "Plate Number"
        VehiclesServicedDataGridView.Columns.Item("PlateNumber_ShortText20").Width = 100
        VehiclesServicedDataGridView.Width = VehiclesServicedDataGridView.Width + VehiclesServicedDataGridView.Columns.Item("PlateNumber_ShortText20").Width

        VehiclesServicedDataGridView.Columns.Item("LastName_ShortText15").HeaderText = "Last Name"
        VehiclesServicedDataGridView.Columns.Item("LastName_ShortText15").Width = 120
        VehiclesServicedDataGridView.Width = VehiclesServicedDataGridView.Width + VehiclesServicedDataGridView.Columns.Item("LastName_ShortText15").Width


        VehiclesServicedDataGridView.Columns.Item("FirstName_ShortText15").HeaderText = "First Name"
        VehiclesServicedDataGridView.Columns.Item("FirstName_ShortText15").Width = 120
        VehiclesServicedDataGridView.Width = VehiclesServicedDataGridView.Width + VehiclesServicedDataGridView.Columns.Item("FirstName_ShortText15").Width

        VehiclesServicedDataGridView.Columns.Item("NamePrefix_ShortText3").HeaderText = ""
        VehiclesServicedDataGridView.Columns.Item("NamePrefix_ShortText3").Width = 50
        VehiclesServicedDataGridView.Width = VehiclesServicedDataGridView.Width + VehiclesServicedDataGridView.Columns.Item("NamePrefix_ShortText3").Width

        VehiclesServicedDataGridView.Columns.Item("YearManufactured_ShortText4").HeaderText = "Year"
        VehiclesServicedDataGridView.Columns.Item("YearManufactured_ShortText4").Width = 50
        VehiclesServicedDataGridView.Width = VehiclesServicedDataGridView.Width + VehiclesServicedDataGridView.Columns.Item("YearManufactured_ShortText4").Width

        VehiclesServicedDataGridView.Columns.Item("VehicleModel_ShortText20").HeaderText = "Model"
        VehiclesServicedDataGridView.Columns.Item("VehicleModel_ShortText20").Width = 150
        VehiclesServicedDataGridView.Width = VehiclesServicedDataGridView.Width + VehiclesServicedDataGridView.Columns.Item("VehicleModel_ShortText20").Width

        VehiclesServicedDataGridView.Columns.Item("VehicleType_ShortText20").HeaderText = "Make"
        VehiclesServicedDataGridView.Columns.Item("VehicleType_ShortText20").Width = 150
        VehiclesServicedDataGridView.Width = VehiclesServicedDataGridView.Width + VehiclesServicedDataGridView.Columns.Item("VehicleType_ShortText20").Width

        VehiclesServicedDataGridView.Columns.Item("VehicleTrimName_ShortText25").HeaderText = "Trim"
        VehiclesServicedDataGridView.Columns.Item("VehicleTrimName_ShortText25").Width = 150
        VehiclesServicedDataGridView.Width = VehiclesServicedDataGridView.Width + VehiclesServicedDataGridView.Columns.Item("VehicleTrimName_ShortText25").Width




        Me.Width = VehiclesServicedDataGridView.Width + 10
    End Sub

    '   VehiclesServicedDataGridView HANDLING

    Private Sub VehiclesServicedDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles VehiclesServicedDataGridView.RowEnter
        If ShowInTaskbarFlag Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If RecordCount = 0 Then Exit Sub
        CurrentVehiclesServicedRow = e.RowIndex
        If Not VehiclesServicedDataGridViewInitialized Then
            VehiclesServicedDataGridViewInitialized = True
        End If
        If CurrentVehiclesServicedID = VehiclesServicedDataGridView.Item("ServicedVehicleID_AutoNumber", CurrentVehiclesServicedRow).Value Then Exit Sub
        CurrentVehiclesServicedID = VehiclesServicedDataGridView.Item("ServicedVehicleID_AutoNumber", CurrentVehiclesServicedRow).Value
    End Sub

    Private Sub VehiclesServicedDataGridView_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles VehiclesServicedDataGridView.DataBindingComplete
        Dim NoOfHeaderLines = 1
        Dim RecordsDisplyed = RecordCount
        Dim FormLowPointFromGrid = 90
        If RecordCount > 27 Then
            Me.Location = New Point(MeLocationX, 50)
            RecordsDisplyed = 27
        Else
            RecordsDisplyed = RecordCount + 1
        End If
        VehiclesServicedDataGridView.Height = (VehiclesServicedDataGridView.ColumnHeadersHeight * NoOfHeaderLines) + (DataGridViewRowHeight * RecordsDisplyed) + DataGridViewRowHeight
        Me.Height = VehiclesServicedDataGridView.Height + FormLowPointFromGrid
        '       VehiclesServicedDataGridView.Location = New Point(1, 49)
    End Sub



    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        If Trim(SearchVehiclesServicedTextBox.Text) = "" Then
            SearchVehiclesServicedTextBox.Text = "New Model Here"
            SearchVehiclesServicedTextBox.Select()
            Exit Sub
        End If
        If RecordCount > 0 Then SearchVehiclesServicedTextBox.Select() : Exit Sub
        If Not MsgBox("Confirm adding " & Trim(SearchVehiclesServicedTextBox.Text) & " as new " & Me.Name, vbYesNo) = vbYes Then SearchVehiclesServicedTextBox.Select() : Exit Sub
        '       VehiclesServicedSelectionFilter = " WHERE VehicleTypeID_LongInteger = " & Str(CurrentVehicleTypeID) & " AND " & " VehiclesServiced_ShortText20 LIKE @FindKey "
        ' EXECUTE INSERT COMMAND

        MySelection = "INSERT INTO VehiclesServicedTable (" &
                                            "VehiclesServiced_ShortText20, " &
                                            "VehicleTypeID_LongInteger)  " &
                                      "VALUES (" &
                                              Chr(34) & Trim(SearchVehiclesServicedTextBox.Text) & Chr(34) & "," &
                                              Str(CurrentVehicleTypeID) & " )"

        If NoRecordFound() Then Dim xxx As Integer = 0 'always IsNot found
        Dim VehiclesServicedInQuote = Chr(34) & Trim(SearchVehiclesServicedTextBox.Text) & Chr(34)
        MySelection = "Select * FROM VehiclesServicedTable WHERE trim(VehiclesServiced_ShortText20) = " & VehiclesServicedInQuote

        If NoRecordFound() Then
            MsgBox("PROBLEM ...... unseccessful save ")
            Exit Sub
        End If
        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        CurrentVehiclesServicedID = r("VehiclesServicedID_AutoNumber")
        VehiclesServicedSelectionFilter = " WHERE VehicleTypeID_LongInteger = " & Str(CurrentVehicleTypeID) & " "
        FillVehiclesServicedDataGridView()
    End Sub
    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click

    End Sub
    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        '        GetSelectedVehiclesServiced(1)
    End Sub

    Private Sub SelectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectToolStripMenuItem.Click
        Tunnel1 = "Tunnel2IsVehiclesServicedID"
        Tunnel2 = CurrentVehiclesServicedID
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub
    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click

        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub

    Private Sub ToolStripTextBoxSearch_Click(sender As Object, e As EventArgs) Handles SearchVehiclesServicedTextBox.Click
        If SearchVehiclesServicedTextBox.Text = "Search" Or SearchVehiclesServicedTextBox.Text = "New Model Here" Then SearchVehiclesServicedTextBox.Text = ""
    End Sub

    Private Sub SearchVehiclesServicedTextBox_TextChanged(sender As Object, e As EventArgs) Handles SearchVehiclesServicedTextBox.TextChanged
        If Not VehiclesServicedDataGridViewInitialized Then Exit Sub
        Dim FindKey As String = Trim(SearchVehiclesServicedTextBox.Text)
        If FindKey = "" Then
            VehiclesServicedSelectionFilter = " WHERE VehicleTypeID_LongInteger = " & Str(CurrentVehicleTypeID)
        Else
            RecordFinderDbControls.AddParam("@FindKey", "%" & FindKey & "%")
            VehiclesServicedSelectionFilter = " WHERE VehicleTypeID_LongInteger = " & Str(CurrentVehicleTypeID) & " AND " & " VehiclesServiced_ShortText20 LIKE @FindKey "
        End If
        FillVehiclesServicedDataGridView()

    End Sub
End Class