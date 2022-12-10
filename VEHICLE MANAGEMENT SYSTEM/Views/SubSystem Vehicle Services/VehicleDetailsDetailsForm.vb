Public Class VehicleDetailsDetailsForm
    Private CurrentVehicleModelsRelationsID As Integer = -1
    Private CurrentVehicleTypeID As Integer = -1
    Private CurrentVehicleModelID As Integer = -1
    Private VehicleSelectionFilter
    Private CurrentTypeID As Integer = -1
    Private SavedTypeID As Integer
    Private VehicleRepairClassID As Integer = -1
    Private PurposeOfEntry As String
    Private AllEntriesAreValid = False
    Private VehicleFieldsDetailsToSelect = ""
    Private VehiclesTablesLinks = ""
    Private VehicleDetailsSelectionFilter = ""
    Private VehicleDetailsSelectionOrder = ""

    Private SavedYearManufacturedFrom = ""
    Private SavedYearManufacturedTo = ""
    Private SavedCallingForm As Form

    Private Sub VehicleDetailsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        SavedCallingForm = CallingForm
        CurrentVehicleID = -1


    End Sub



    Private Sub FillDetailsDetailsForm()

        VehicleFieldsDetailsToSelect = " Select " &
                                       " VehiclesTable.VehicleID_AutoNumber, " &
                                       " VehicleTypeTable.VehicleType_ShortText20, " &
                                       " VehicleModelsTable.VehicleModel_ShortText20, " &
                                       " VehicleTrimTable.VehicleTrimName_ShortText25, " &
                                       " VehiclesTable.YearManufactured_ShortText4, " &
                                       " VehiclesTable.BodyType_ShortText20, " &
                                       " VehiclesTable.EngineSeries_ShortText20, " &
                                       " VehiclesTable.FuelType_ShortText20, " &
                                       " VehiclesTable.Engine_ShortText20, " &
                                       " VehicleModelsRelationsTable.VehicleModelID_LongInteger, " &
                                       " VehicleModelsRelationsTable.VehicleTypeID_LongInteger, " &
                                       " VehicleRepairClassTable.YearManufacturedFrom_ShortText4, " &
                                       " VehicleRepairClassTable.YearManufacturedTo_ShortText4, " &
                                       " VehiclesTable.VehicleRepairClassID_LongInteger "

        VehiclesTablesLinks = " FROM((((VehiclesTable LEFT JOIN VehicleModelsRelationsTable ON VehiclesTable.VehicleModelsRelationID_LongInteger = VehicleModelsRelationsTable.[VehicleModelsRelationID_Autonumber]) LEFT JOIN VehicleTypeTable On VehicleModelsRelationsTable.VehicleTypeID_LongInteger = VehicleTypeTable.VehicleTypeID_AutoNumber) LEFT JOIN VehicleTrimTable On VehicleModelsRelationsTable.VehicleTrimID_LongInteger = VehicleTrimTable.VehicleTrimID_Autonumber) LEFT JOIN VehicleModelsTable On VehicleModelsRelationsTable.VehicleModelID_LongInteger = VehicleModelsTable.VehicleModelID_Autonumber) LEFT JOIN VehicleRepairClassTable On VehiclesTable.VehicleRepairClassID_LongInteger = VehicleRepairClassTable.VehicleRepairClassID_AutoNumber "


        VehicleDetailsSelectionOrder = " Order by VehicleType_ShortText20 Asc, " &
                                          "VehicleModel_ShortText20 Asc, " &
                                          "VehicleTrimName_ShortText25, " &
                                          "YearManufactured_ShortText4 "


        VehicleDetailsSelectionFilter = " WHERE VehicleID_AutoNumber = " & Tunnel2.ToString

        MySelection = VehicleFieldsDetailsToSelect & VehiclesTablesLinks & VehicleDetailsSelectionFilter & VehicleDetailsSelectionOrder

        JustExecuteMySelection()
        If NoRecordFound() Then
            Exit Sub
        End If
        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        CurrentVehicleTypeID = r("VehicleType_ShortText20")
        VehicleTypeTextBox.Text = r("VehicleType_ShortText20")
        CurrentVehicleModelID = r("VehicleType_ShortText20")
        CurrentVehicleRepairClassID = IIf(IsDBNull(r("VehicleRepairClassID_LongInteger")), "", r("VehicleRepairClassID_LongInteger"))
        VehicleModelTextBox.Text = r("VehicleModel_ShortText20")
        VehicleTrimTextBox.Text = IIf(IsDBNull(r("VehicleTrimName_ShortText25")), "", r("VehicleTrimName_ShortText25"))
        YearManufacturedTextBox.Text = r("YearManufactured_ShortText4")
        EngineTypeTextBox.Text = IIf(IsDBNull(r("FuelType_ShortText20")), "", r("FuelType_ShortText20"))
        BodyTypeTextBox.Text = IIf(IsDBNull(r("BodyType_ShortText20")), "", r("BodyType_ShortText20"))
        EngineSeriesTextBox.Text = IIf(IsDBNull(r("EngineSeries_ShortText20")), "", r("EngineSeries_ShortText20"))
        FuelTypeTextBox.Text = IIf(IsDBNull(r("Engine_ShortText20")), "", r("Engine_ShortText20"))
        SavedYearManufacturedFrom.Text = IIf(IsDBNull(r("YearManufacturedFrom_ShortText4")), "", r("YearManufacturedFrom_ShortText4"))
        SavedYearManufacturedTo.Text = IIf(IsDBNull(r("YearManufacturedTo_ShortText4")), "", r("YearManufacturedTo_ShortText4"))
    End Sub


    Private Sub VehicleDetailsForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        'Refresh datagridviw here
        ' GET RETURNED DATA HERE
        If Me.Enabled = False Then Exit Sub

        If Convert.ToDecimal(Tunnel1) < 0 Then
            Exit Sub
        End If
        Select Case RequestCodeTextBox.Text
        ' 1  = ShowVehicleModelForm()
        ' 2 = ShowVehicleRepairClassForm()
        ' 3 = ShowVehicleTrimForm()
            Case 1
                ' returned values from VehicleModelsRelationsForm
                ' Tunnel1 = CurrentVehicleModelsRelationID
                ' Tunnel2 = CurrentVehicleTypeID
                '  Tunnel3 = CurrentVehicleModelID

                CurrentVehicleModelsRelationsID = Tunnel1
                CurrentVehicleTypeID = Tunnel2
                CurrentVehicleModelID = Tunnel3
            Case 2
                CurrentVehicleRepairClassID = Tunnel1
            Case 3

        End Select


    End Sub


    Private Sub GetVehicleTypeID(TypeName As String)
        ' QUERY USER
        RecordFinderDbControls.AddParam("@VehicleType", TypeName)
        MySelection = "SELECT TOP 1 VehicleTypeID_AutoNumber, VehicleType_ShortText20 FROM VehicleTypeTable WHERE VehicleType_ShortText20=@VehicleType "

        ' REPORT & ABORT ON ERRORS OR NO RECORDS FOUND
        If NoRecordFound() Then Exit Sub

        ' GET FIRST ROW FOUND
        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)

        ' POPULATE TEXTBOXES WITH DATA
        CurrentTypeID = r("VehicleTypeID_AutoNumber")

    End Sub


    Private Sub GetVehicleModelID(ModelName As String)
        ' QUERY USER
        RecordFinderDbControls.AddParam("@VehicleModel", ModelName)
        MySelection = "SELECT TOP 1 VehicleModelID_AutoNumber, VehicleModel_ShortText20 FROM VehicleModelsRelationsTable WHERE VehicleModel_ShortText20=@VehicleModel "

        ' REPORT & ABORT ON ERRORS OR NO RECORDS FOUND
        If NoRecordFound() Then Exit Sub

        ' GET FIRST ROW FOUND
        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)

        ' POPULATE TEXTBOXES WITH DATA
        CurrentVehicleModelsRelationsID = r("VehicleModelsRelationID_AutoNumber")

    End Sub

    Private Sub VehicleModelTextBox_GotFocus(sender As Object, e As EventArgs) Handles VehicleModelTextBox.GotFocus

        If VehicleModelTextBox.Text = "" Then ShowVehicleModelForm()
    End Sub
    Private Sub VehicleModelTextBox_TextChanged(sender As Object, e As EventArgs) Handles VehicleModelTextBox.TextChanged

        If Me.Enabled = True Then
            If VehicleModelTextBox.Text = "" Then
                ShowVehicleModelForm()
            End If
        Else
            ' returned values from VehicleModelsRelationsForm

            ' Tunnel1 = CurrentVehicleModelsRelationID
            ' Tunnel2 = CurrentVehicleTypeID
            ' Tunnel3 = CurrentVehicleModelID



            CurrentVehicleModelsRelationsID = Tunnel1
            CurrentVehicleTypeID = Tunnel2
            CurrentVehicleModelID = Tunnel3

        End If
    End Sub

    Private Sub ShowVehicleModelForm()
        RequestCodeTextBox.Text = "1"
        ' 1  = ShowVehicleModelForm()
        ' 2 = ShowVehicleRepairClassForm()
        ' 3 = ShowVehicleTrimForm()

        Tunnel1 = Str(CurrentTypeID)
        Tunnel2 = VehicleTypeTextBox.Text
        ShowCalledForm(Me, VehicleModelsRelationsForm)
        VehicleModelsRelationsForm.SearchVehicleMakeTextBox.Text = VehicleModelTextBox.Text
        VehicleModelsRelationsForm.SearchVehicleMakeTextBox.Select()
    End Sub
    Private Sub VehicleTrimTextBox_GotFocus(sender As Object, e As EventArgs) Handles VehicleTrimTextBox.GotFocus
        If VehicleTypeTextBox.Text = "ADD New Vehicle Trim" Then VehicleTypeTextBox.Select() : Exit Sub
        If VehicleTrimTextBox.Text = "" Then ShowVehicleTrimForm()
    End Sub


    Private Sub ShowVehicleTrimForm()
        RequestCodeTextBox.Text = "3"
        ' 1  = ShowVehicleModelForm()
        ' 2 = ShowVehicleRepairClassForm()
        ' 3 = ShowVehicleTrimForm()

        Tunnel2 = Trim(VehicleTypeTextBox.Text) & " " & Trim(VehicleModelTextBox.Text)
        Tunnel1 = CurrentVehicleModelsRelationsID
        VehicleTrimsForm.Name = Trim(VehicleTypeTextBox.Text) & " " & Trim(VehicleModelTextBox.Text)

        ShowCalledForm(Me, VehicleTrimsForm)
        VehicleTrimsForm.SearchVehicleTrimTextBox.Text = VehicleTrimTextBox.Text
        VehicleTrimsForm.SearchVehicleTrimTextBox.Select()
    End Sub

End Class