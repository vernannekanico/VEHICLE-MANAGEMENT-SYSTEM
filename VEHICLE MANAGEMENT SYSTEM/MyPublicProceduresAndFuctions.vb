Module MyPublicProceduresAndFuctions

    Public Function NotEmpty(text As String) As Boolean
        Return Not String.IsNullOrEmpty(text)
    End Function
    Public Function IsEmpty(PassedObject)
        If PassedObject Is Nothing Then Return True
        If IsDBNull(PassedObject) Then
            Return True
        ElseIf Trim(PassedObject.ToString) = "" Then
            Return True
        ElseIf PassedObject = "0" Then
            Return True
        ElseIf Val(PassedObject) < 0 Then
            Return True
        End If
        Return False
    End Function
    Public Function IsNotEmpty(PassedObject)

        If PassedObject Is Nothing Then Return False
        If IsDBNull(PassedObject) Then Return False
        If PassedObject.GetType().Name = "String" Then
            If Trim(PassedObject.ToString) = "" Then Return False
        Else
            If PassedObject < 1 Then Return False
        End If
        Return True
    End Function
    Public Function ThereIsARecord()
        RecordFinderDbControls.MyDbCommand(MySelection)

        If NotEmpty(RecordFinderDbControls.Exception) Then
            MsgBox(RecordFinderDbControls.Exception)
            Return False
        End If
        If RecordFinderDbControls.MyAccessDbDataTable.Rows.Count = 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Function RecordIsFound()
        If ThereIsARecord() Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function NoRecordFound()
        If ThereIsARecord() Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Function VehicleDetails()
        SetParentRecordReference("VehiclesTable", "VehicleID_AutoNumber", CurrentVehicleID)
        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        Dim xxVehicleModelsRelationsID = r("VehicleModelsRelationID_LongInteger")
        Dim xxYearManufactured = r("YearManufactured_ShortText4")
        Dim xxEngine = r("Engine_ShortText20")
        If IsEmpty(xxEngine) Then xxEngine = ""

        SetParentRecordReference("VehicleModelsRelationsTable", "VehicleModelsRelationID_Autonumber", xxVehicleModelsRelationsID)
        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        Dim xxVehicleTypeID = r("VehicleTypeID_LongInteger")
        Dim xxVehicleModelID = r("VehicleModelID_LongInteger")
        Dim xxVehicleTrimID = r("VehicleTrimID_LongInteger")

        SetParentRecordReference("VehicleTypeTable", "VehicleTypeID_Autonumber", xxVehicleTypeID)
        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        Dim xxVehicleType_ShortText20 = r("VehicleType_ShortText20")

        SetParentRecordReference("VehicleModelsTable", "VehicleModelID_Autonumber", xxVehicleModelID)
        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        Dim xxVehicleModel_ShortText20 = r("VehicleModel_ShortText20")

        Dim xxVehicleTrimName_ShortText25 = ""
        If xxVehicleTrimID > 0 Then
            SetParentRecordReference("VehicleTrimTable", "VehicleTrimID_Autonumber", xxVehicleTrimID)
            r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
            xxVehicleTrimName_ShortText25 = r("VehicleTrimName_ShortText25")
        End If

        Dim VehicleName = xxYearManufactured & Space(1) &
                            Trim(xxVehicleType_ShortText20) & Space(1) &
                            Trim(xxVehicleModel_ShortText20) & Space(1) &
                            Trim(xxVehicleTrimName_ShortText25) & Space(1) &
                            Trim(xxEngine)

        Return VehicleName

    End Function
    Public Function GetNewWorkOrderID(ServiceDate_DateTime, VehicleMilage_Integer)
        Dim WorkOrderID1 = ""
        Dim WorkOrderID2 = ""

        If IsDBNull(ServiceDate_DateTime) Then
            WorkOrderID1 = ""
        Else
            WorkOrderID1 = Format(ServiceDate_DateTime, "yyMMdd").ToString

        End If

        If IsDBNull(VehicleMilage_Integer) Then
            WorkOrderID2 = ""
        Else
            If IsNotEmpty(VehicleMilage_Integer) Then
                WorkOrderID2 = RTrim(LTrim(Str(VehicleMilage_Integer)))
            End If
        End If
        Dim NewWorkOrderID = Trim(WorkOrderID1) & WorkOrderID2


        Return NewWorkOrderID
    End Function
    Public Function TheseAreNotEqual(PassedVariable1 As Object, PassedVariable2 As Object, PurposeOfEntry As String)
        If IsEmpty(PassedVariable1) And IsEmpty(PassedVariable2) Then Return False  ' BOTH ARE EMPTY
        If IsEmpty(PassedVariable1) Or IsEmpty(PassedVariable2) Then Return True     ' 1 IS EMPTY
        If PassedVariable1 <> PassedVariable2 Then Return True
        Return False
    End Function
    Public Sub FillField(ByRef TargetContainer, TargetValue)
        Dim TypeOfTargetContainer = TargetContainer.GetType.Name
        If TargetContainer.GetType.Name = "String" Then
            If IsDBNull(TargetValue) Or TargetValue Is Nothing Then
                TargetContainer = ""
            Else
                TargetContainer = TargetValue
            End If
        Else
            If IsDBNull(TargetValue) Or TargetValue Is Nothing Then
                TargetContainer = -1
            Else
                TargetContainer = TargetValue
            End If
        End If

    End Sub
    Public Function NotNull(DbField)
        If DbField.GetType.Name = "String" Then
            If IsDBNull(DbField) Or DbField Is Nothing Then
                Return ""
            Else
                Return DbField
            End If
        Else
            If IsDBNull(DbField) Or DbField Is Nothing Then
                Return -1
            Else
                Return DbField
            End If
        End If
    End Function
    Public Function InsertNewRecord(SubjectTable As String, FieldsToUpdate As String, FieldsData As String)

        MySelection = " SELECT * FROM " & SubjectTable
        JustExecuteMySelection()
        Dim TotalRecord = RecordCount

        MySelection = " INSERT INTO " & SubjectTable & " (" & FieldsToUpdate & ") VALUES (" & FieldsData & ")"
        JustExecuteMySelection()

        MySelection = " SELECT * FROM " & SubjectTable
        JustExecuteMySelection()
        If TotalRecord = RecordCount Then
            MsgBox("Unsuccesful insert")
            Return -1
        End If

        Dim SortField = ""
        If InStr(SubjectTable, "iesTable") > 0 Then
            SortField = Replace(SubjectTable, "iesTable", "") & "yID_AutoNumber DESC"
        Else
            If InStr(SubjectTable, "sesTable") > 0 Then
                SortField = Replace(SubjectTable, "sesTable", "") & "sID_AutoNumber DESC"
            Else
                SortField = Replace(SubjectTable, "sTable", "") & "ID_AutoNumber DESC"
            End If
        End If
        MySelection = " SELECT TOP 1 * FROM " & SubjectTable & " ORDER BY " & SortField
        JustExecuteMySelection()

        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        Return r(0)
    End Function
    Public Function SetupTableSelectionFilter(
                                                ToSetRecordStatusSelection As Integer,
                                                PassedForm As Form,
                                                PassedFormText As String,
                                                FixedFilter As String 'Note when there is already a determined passed
                                                )
        Dim ToSetRecordsSelection = ""
        If IsEmpty(FixedFilter) Then
            ToSetRecordsSelection = ""
        Else
            ToSetRecordsSelection = FixedFilter
        End If
        If ToSetRecordStatusSelection <> 10 Then
            Dim xxStatusFieldName = Replace(PassedForm.Name, "sForm", "") & "Status_Byte"
            If IsEmpty(ToSetRecordsSelection) Then
                ToSetRecordsSelection = xxStatusFieldName & "  = " & ToSetRecordStatusSelection.ToString
            Else
                ToSetRecordsSelection = ToSetRecordsSelection & " AND " & xxStatusFieldName & "  = " & ToSetRecordStatusSelection.ToString
            End If
        End If
        If Not IsEmpty(ToSetRecordsSelection) Then ToSetRecordsSelection = " WHERE " & ToSetRecordsSelection
        Return ToSetRecordsSelection
    End Function

    Public Function RoundUp(DecimalValue)
        Return Math.Ceiling(DecimalValue * 10D) / 10D
    End Function
    Public Function InQuotes(PassedString As String)
        Return Chr(34) & PassedString & Chr(34)
    End Function
    Public Function MaxLengthOfFieldExceeded(PassedInputTextBox As TextBox, MaxLength As Integer)
        If Len(PassedInputTextBox.Text) > MaxLength Then
            PassedInputTextBox.Text = PassedInputTextBox.Text.Substring(0, MaxLength - 1)
            PassedInputTextBox.Select()
            Return True
        End If
        Return False
    End Function
    Public Sub JustExecuteMySelection()
        If NoRecordFound() Then Exit Sub
    End Sub
    Public Sub EnAbleAccess(MenuOption As ToolStripMenuItem)
        MenuOption.Enabled = True
    End Sub
    Public Sub SetThisMenuVisible(MenuOption As Object)
        MenuOption.Visible = True
    End Sub

    Public Sub DisAbleAccess(MenuOption As ToolStripMenuItem)
        MenuOption.Enabled = False
    End Sub
    Public Sub UpdateTable(TableToUpdate As String, SetCommand As String, RecordFilter As String)
        MySelection = " Select  * FROM " & TableToUpdate & RecordFilter
        JustExecuteMySelection()
        If RecordCount = 0 Then
            MsgBox("Unable to Update Table " & TableToUpdate & " FILTER: " & RecordFilter)
            Exit Sub
        End If
        MySelection = " UPDATE " & TableToUpdate & SetCommand & RecordFilter
        JustExecuteMySelection()
    End Sub

    Public Sub UpdateThisTable(TableToUpdate As String, FieldToCompare As String, DataToCompare As String, FieldToUpdate As String, ReplacementData As String)


        RecordFinderDbControls.AddParam("@DataToCompare", Val(DataToCompare))
        RecordFinderDbControls.AddParam("@ReplacementData", ReplacementData)


        MySelection = " UPDATE " & TableToUpdate &
                      " SET " & FieldToUpdate & " = " & Chr(34) & ReplacementData & Chr(34) &
                      " WHERE " & FieldToCompare & " = @DataToCompare"

        If NoRecordFound() Then Dim dummy = 1

        RecordFinderDbControls.AddParam("@DataToCompare", Val(DataToCompare))
        RecordFinderDbControls.AddParam("@ReplacementData", ReplacementData)


        MySelection = "select * from  " & TableToUpdate &
                      " WHERE " & FieldToCompare & " = @DataToCompare"

        If NoRecordFound() Then
            Exit Sub
        End If
        Dim r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        Dim xxx = r(FieldToUpdate)
    End Sub
    Public Sub SetParentRecordReference(ParentTableName, ParentFieldName, FieldValue)

        If TypeName(FieldValue) = "String" Then
            FieldValue = Chr(34) & FieldValue & Chr(34)
        Else
            FieldValue = FieldValue.ToString()
        End If

        MySelection = "SELECT * " &
                      " FROM " & ParentTableName &
                      " WHERE " & ParentFieldName & " = " & FieldValue

        JustExecuteMySelection()
    End Sub
    Public Function GetFieldValue(ParentTableName As String, ParentFieldName As String, FieldValue As Object, RequestedField As String)
        Dim RequestedValue As Object
        If TypeName(FieldValue) = "String" Then
            FieldValue = Chr(34) & FieldValue & Chr(34)
        Else
            FieldValue = FieldValue.ToString()
        End If

        MySelection = "SELECT * " &
                      " FROM " & ParentTableName &
                      " WHERE " & ParentFieldName & " = " & FieldValue

        JustExecuteMySelection()
        If RecordCount = 0 Then
            Dim msgbox("problem")
        End If
        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        RequestedValue = r(RequestedField)


        Return RequestedValue
    End Function
    Public Function GetCodeVehicleID(CurrentMasterCodeBookId, CurrentVehicleID)
        MySelection = " Select * From CodeVehiclesTable Where MasterCodeBookID_LongInteger = " & CurrentMasterCodeBookId.ToString &
                    " AND VehicleID_LongInteger = " & CurrentVehicleID.ToString
        JustExecuteMySelection()
        If RecordCount = 0 Then
            Dim FieldsToUpdate = " MasterCodeBookID_LongInteger, VehicleID_LongInteger "
            Dim FieldsData = CurrentMasterCodeBookId.ToString & ", " & CurrentVehicleID.ToString
            CurrentCodeVehicleID = InsertNewRecord("CodeVehiclesTable", FieldsToUpdate, FieldsData)
        Else
            r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
            CurrentCodeVehicleID = r("CodeVehicleID_AutoNumber")
        End If
        Return CurrentCodeVehicleID
    End Function
    Public Function GetStatusIdFor(PassedTable As String, Optional PassedStatus As String = "")
        MySelection = " Select top 1 * From TableNamesTable Where TableName_ShortText60 = " & InQuotes(PassedTable)
        JustExecuteMySelection()
        If RecordCount = 0 Then
            MsgBox("Table name passed not found")
            Return False
        End If
        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        Dim TableNameID = r("TableNameID_AutoNumber")
        Dim Filter2 = " AND StatusSequence_LongInteger = 0 "
        If PassedStatus > "" Then Filter2 = " and StatusText_ShortText25 = " & InQuotes(PassedStatus)
        MySelection = " Select top 1 * From StatusesTable Where TableNameID_Integer = " & TableNameID.ToString & Filter2
        JustExecuteMySelection()
        If RecordCount = 0 Then
            MsgBox("Status not found, need to correct this")
            Return False
        End If
        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        Tunnel1 = r("StatusText_ShortText25")
        Return r("StatusID_Autonumber")
    End Function
    Public Sub ResetTunnels()
        Tunnel1 = ""
        Tunnel2 = -1
        Tunnel3 = ""
        Tunnel4 = ""
    End Sub
    Public Sub SetVehicleInformations()

        SetParentRecordReference("WorkOrdersTable", "WorkOrderID_AutoNumber", CurrentWorkOrderID)
        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        Dim xxServicedVehicleID_LongInteger = r("ServicedVehicleID_LongInteger")
        If xxServicedVehicleID_LongInteger < 1 Then Exit Sub
        SetParentRecordReference("ServicedVehiclesTable", "ServicedVehicleID_AutoNumber", xxServicedVehicleID_LongInteger)
        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        CurrentVehicleID = r("VehicleID_LongInteger")

        SetParentRecordReference("VehiclesTable", "VehicleID_AutoNumber", CurrentVehicleID)
        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        CurrentVehicleRepairClassID = r("VehicleRepairClassID_LongInteger")
        Dim xxYearManufactured_ShortText4 = r("YearManufactured_ShortText4")
        Dim xxEngine_ShortText20 = r("Engine_ShortText20")
        Dim xxVehicleModelsRelationsID = r("VehicleModelsRelationID_LongInteger")

        SetParentRecordReference("VehicleModelsRelationsTable", "VehicleModelsRelationID_AutoNumber", xxVehicleModelsRelationsID)
        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        Dim xxVehicleTypeID = r("VehicleTypeID_LongInteger")
        Dim xxVehicleModelID = r("VehicleModelID_LongInteger")
        Dim xxVehicleTrimID = r("VehicleTrimID_LongInteger")

        SetParentRecordReference("VehicleTypeTable", "VehicleTypeID_AutoNumber", xxVehicleTypeID)
        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        Dim xxVehicleType_ShortText20 = r("VehicleType_ShortText20")

        SetParentRecordReference("VehicleModelsTable", "VehicleModelID_Autonumber", xxVehicleModelID)
        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        Dim xxVehicleModel_ShortText20 = r("VehicleModel_ShortText20")

        Dim xxVehicleTrimName_ShortText25 = ""
        If xxVehicleTrimID > 0 Then
            SetParentRecordReference("VehicleTrimTable", "VehicleTrimID_Autonumber", xxVehicleTrimID)
            r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
            xxVehicleTrimName_ShortText25 = r("VehicleTrimName_ShortText25")
        End If


        CurrentVehicleString =
                            xxYearManufactured_ShortText4 & " " &
                            xxVehicleType_ShortText20 & " " &
                            xxVehicleModel_ShortText20 & " " &
                            xxVehicleTrimName_ShortText25 & " " &
                            xxEngine_ShortText20
    End Sub
    Public Sub SetGroupBoxHeight(NoOfHeaderLines As Integer, RecordsToDisplay As Integer, PassedRecordCount As Integer, PassedGroupBox As GroupBox, PassedDataGridView As DataGridView)
        Dim ArrayCounter = RecordsToDisplay
        If PassedRecordCount > RecordsToDisplay Then
            RecordsToDisplay = RecordsToDisplay
            ArrayCounter = RecordsToDisplay
        Else
            ArrayCounter = PassedRecordCount
            RecordsToDisplay = PassedRecordCount
        End If
        Dim TotalRowsHeight = 0
        TotalRowsHeight = RecordsToDisplay * DataGridViewRowHeight
        PassedGroupBox.Height = (PassedDataGridView.ColumnHeadersHeight) + TotalRowsHeight + 44
    End Sub
    Public Sub ShowCalledForm(PassedCallingForm As Form, PassedCalledForm As Form)
        CallingForm = PassedCallingForm
        CallingForm.Enabled = False
        ShowInTaskbarFlag = True
        CallingForm.ShowInTaskbar = False
        ShowInTaskbarFlag = False
        PassedCalledForm.Text = PassedCalledForm.Name
        PassedCalledForm.Show()
        PassedCalledForm.Select()
        ResetTunnels() ' INFORMATION IN TUNNELS HAVE BEEN RECEIVED
    End Sub
    Public Sub DoCommonHouseKeeping(CalledForm As Form, CallingForm As Form)
        ShowInTaskbarFlag = True
        CalledForm.Close()
        CallingForm.ShowInTaskbar = True
        CallingForm.Enabled = True
        CallingForm.Show()             'enables the page to be active
        CallingForm.Select()
        ShowInTaskbarFlag = False
        ResetTunnels() ' INFORMATION IN TUNNELS HAVE BEEN RECEIVED
    End Sub
    Public Sub EnableMenu(SystemsDepartmentToolStripMenuItem As ToolStripMenuItem)
        If EnableMenus Then
            SystemsDepartmentToolStripMenuItem.Visible = True
        Else
            SystemsDepartmentToolStripMenuItem.Visible = False
        End If

    End Sub

End Module
