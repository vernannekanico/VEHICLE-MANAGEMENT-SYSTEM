Module MyPublicProceduresAndFuctions
    Public Function IsEmpty(PassedObject)
        If PassedObject Is Nothing Then Return True
        If PassedObject.GetType.Name = "DateTime" Then Return False
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
        If IsEmpty(PassedObject) Then Return False
        Return True
    End Function
    Public Function ThereIsARecord()
        RecordFinderDbControls.MyDbCommand(MySelection)
        If Not String.IsNullOrEmpty(RecordFinderDbControls.Exception) Then
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
        Dim WorkOrderID1 As String
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
    Public Function TheseAreNotEqual(PassedVariable1 As Object, PassedVariable2 As Object)
        If IsEmpty(PassedVariable2) And IsEmpty(PassedVariable1) Is Nothing Then Return False
        If PassedVariable2 Is Nothing And PassedVariable1 IsNot Nothing Then Return True
        If PassedVariable1 Is Nothing And PassedVariable2 IsNot Nothing Then Return True
        If PassedVariable1.GetType.Name = "String" Then
            If PassedVariable2.GetType.Name = "Decimal" Then
                PassedVariable1 = CDec(PassedVariable1)
            End If
        Else
            If PassedVariable2.GetType.Name = "String" Then
                If PassedVariable1.GetType.Name = "Decimal" Then
                    PassedVariable2 = CDec(PassedVariable2)
                End If
            End If
        End If
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
    Public Function NotTheSame(Variable1, variable2)
        If IsEmpty(Variable1) And IsEmpty(variable2) Then Return False
        If IsEmpty(Variable1) Then Return True
        If IsEmpty(variable2) Then Return True
        If Variable1 = variable2 Then Return False
        Return True
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
        Dim SortField As String
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
        If RecordCount < 1 Then
            Return -1
        End If
        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        Return r(0)

    End Function
    Public Function SetupTableSelectionFilter(
                                                PassedStatusSequence As Integer,
                                                PassedStatusSequenceCondition As Integer,
                                                PassedForm As Form,
                                                PassedFormText As String,
                                                Optional FixedFilter As String = ""'Note when there is already a determined passed
                                                )
        ' NOTE: PassedStatusSequenceConditionS  1 FOR <=
        '                                       2 FOR =
        '                                       3 FOR >=
        '                                       4 FOR <
        '                                       5 FOR >

        If IsNotEmpty(PassedFormText) Then PassedForm.Text = PassedFormText
        Dim logicalOperator = ""
        Select Case PassedStatusSequenceCondition
            Case 1
                logicalOperator = " <= "
            Case 2
                logicalOperator = " = "
            Case 3
                logicalOperator = " >= "
            Case 4
                logicalOperator = " < "
            Case 5
                logicalOperator = " > "
        End Select
        Dim RecordsSelectionFilter = " StatusSequence_LongInteger " & logicalOperator & PassedStatusSequence.ToString
        If IsNotEmpty(FixedFilter) Then
            RecordsSelectionFilter = FixedFilter & " AND " & RecordsSelectionFilter
        End If
        RecordsSelectionFilter = " WHERE " & RecordsSelectionFilter
        Return RecordsSelectionFilter
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
            MsgBox("Input parameter error")
            Return -1
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
    Public Function GetStatusIdFor(PassedTable As String,
                                   Optional PassedStatus As String = "",
                                   Optional PassedNeededField As Decimal = 0)
        '    PassedNeededField determines which field value is returned
        '    DEFAULt is the id_autonumber

        'Validation
        MySelection = " Select top 1 * From TableNamesTable Where TableName_ShortText60 = " & InQuotes(LTrim(Trim(PassedTable)))
        JustExecuteMySelection()
        If RecordCount = 0 Then
            MsgBox("Problem with passed Table name " & PassedTable)
            Return False
        End If
        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        Dim TableNameID = r("TableNameID_AutoNumber")
        Dim Filter2 = " AND StatusSequence_LongInteger = 0 "
        If PassedStatus > "" Then Filter2 = " and StatusText_ShortText25 = " & InQuotes(PassedStatus)
        MySelection = " Select top 1 * From StatusesTable Where TableNameID_Integer = " & TableNameID.ToString & Filter2
        JustExecuteMySelection()
        If RecordCount = 0 Then
            MsgBox("Passed Status not found, need to correct this")
            Return False
        End If
        'end of validation
        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        Select Case PassedNeededField
            Case 0
                Return r("StatusID_Autonumber")
            Case 1
                Return r("StatusSequence_LongInteger")
            Case Else
                MsgBox("Needed Field value (" & PassedNeededField.ToString & ") is not correct")
                Return ""
        End Select

    End Function
    Public Function LinkExistsIn(TablesToCheck As Array, FieldName As String, LinkKey As Integer)

        For Each item As String In TablesToCheck
            MySelection = " Select TOP 1 * FROM " & item & " Where " & FieldName & " = " & LinkKey.ToString
            JustExecuteMySelection()
            If RecordCount > 0 Then
                MsgBox("link exist in " & item)
                Return True
            End If
        Next
        Return False
    End Function
    Public Function BottomOf(PassedObject)
        Return PassedObject.top + PassedObject.height
    End Function
    Public Sub SetFormWidthAndGroupBoxLeft(ActiveForm As Form,
                                           ActiveFormMenuStrip As MenuStrip,
                                           GroupBox1 As GroupBox,
                                           GroupBox2 As GroupBox,
                                           GroupBox3 As GroupBox,
                                           GroupBox4 As GroupBox)
        'Note: IF ONLY 2 OR 3 BOXES ARE INVOLVED,
        '   INDICATE GROUPBOX3 AND / OR GROUPBOX4 = GROUPBOX1
        If GroupBox1.Width >= VehicleManagementSystemForm.Width Then
            GroupBox1.Width = VehicleManagementSystemForm.Width - 4
        End If
        If GroupBox2.Width >= VehicleManagementSystemForm.Width Then
            GroupBox2.Width = VehicleManagementSystemForm.Width - 4
        End If
        If GroupBox3.Width >= VehicleManagementSystemForm.Width Then
            GroupBox3.Width = VehicleManagementSystemForm.Width - 4
        End If

        If GroupBox3.Width >= VehicleManagementSystemForm.Width Then
            GroupBox3.Width = VehicleManagementSystemForm.Width - 4
        End If

        Dim LargestWidth = 0
        For i = 1 To 4
            If GroupBox1.Width > LargestWidth Then
                LargestWidth = GroupBox1.Width

            ElseIf GroupBox2.Width > LargestWidth Then
                LargestWidth = GroupBox2.Width
            ElseIf GroupBox3.Width > LargestWidth Then
                LargestWidth = GroupBox3.Width
            ElseIf GroupBox4.Width > LargestWidth Then
                LargestWidth = GroupBox4.Width
            End If
        Next
        ActiveForm.Width = LargestWidth + 4
        ActiveForm.Left = (VehicleManagementSystemForm.Width - ActiveForm.Width) / 2

        GroupBox1.Top = ActiveFormMenuStrip.Top + ActiveFormMenuStrip.Height
        GroupBox1.Left = (ActiveForm.Width - GroupBox1.Width) / 2

        GroupBox2.Top = GroupBox1.Top + GroupBox1.Height
        GroupBox2.Left = (ActiveForm.Width - GroupBox2.Width) / 2

        If GroupBox3.Name = GroupBox1.Name Then Exit Sub
        GroupBox3.Top = GroupBox2.Top + GroupBox2.Height
        GroupBox3.Left = (ActiveForm.Width - GroupBox3.Width) / 2

        If GroupBox4.Name = GroupBox1.Name Then Exit Sub
        GroupBox4.Top = GroupBox3.Top + GroupBox3.Height
        GroupBox4.Left = (ActiveForm.Width - GroupBox4.Width) / 2

    End Sub
    Public Sub VerticalCenter(ObjectToCenter As Object, FormToCenterIn As Object)
        ObjectToCenter.top = (FormToCenterIn.height - ObjectToCenter.height) / 2
    End Sub
    Public Sub HorizontalCenter(ObjectToCenter As Object, FormToCenterIn As Object)
        ObjectToCenter.left = (FormToCenterIn.width - ObjectToCenter.width) / 2
    End Sub
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
        MySelection = " Select  * FROM " & Space(1) & TableToUpdate & Space(1) & RecordFilter
        JustExecuteMySelection()
        If RecordCount = 0 Then
            MsgBox("Unable to Update Table, NO MATCHING RECORD FOUND " & TableToUpdate & " FILTER: " & RecordFilter)
            Exit Sub
        End If
        MySelection = " UPDATE " & TableToUpdate & Space(1) & SetCommand & Space(1) & RecordFilter
        JustExecuteMySelection()
    End Sub
    Public Sub UpdateThisTable(TableToUpdate As String, FieldToCompare As String, DataToCompare As String, FieldToUpdate As String, ReplacementData As String)


        RecordFinderDbControls.AddParam("@DataToCompare", Val(DataToCompare))
        RecordFinderDbControls.AddParam("@ReplacementData", ReplacementData)


        MySelection = " UPDATE " & TableToUpdate &
                      " SET " & FieldToUpdate & " = " & Chr(34) & ReplacementData & Chr(34) &
                      " WHERE " & FieldToCompare & " = @DataToCompare"


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
    Public Sub RevertCurrentStatusOf(PassedTable As String, PassedCurrentStatusSequence As Integer, CurrentRecordID As Integer)
        If PassedCurrentStatusSequence = 0 Then Exit Sub
        MySelection = " Select top 1 * From TableNamesTable Where TableName_ShortText60 = " & InQuotes(PassedTable)
        JustExecuteMySelection()
        If RecordCount = 0 Then
            MsgBox("Problem with Table name passed " & PassedTable)
            Exit Sub
        End If
        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        Dim TableNameID = r("TableNameID_AutoNumber")
        Dim Filter2 = " AND StatusSequence_LongInteger =  " & (PassedCurrentStatusSequence - 1).ToString
        MySelection = " Select top 1 * From StatusesTable Where TableNameID_Integer = " & TableNameID.ToString & Filter2
        JustExecuteMySelection()

        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        Dim PreviousStatusID = r("StatusID_Autonumber").ToString

        Dim StatusField = Replace(PassedTable, "sTable", "StatusID_LongInteger")
        Dim TableKeyField = Replace(PassedTable, "sTable", "ID_Autonumber")
        MySelection = " UPDATE " & PassedTable &
                       " SET " & StatusField & " = " & r("StatusID_Autonumber").ToString &
                       " WHERE " & TableKeyField & "=" & CurrentRecordID
        JustExecuteMySelection()
    End Sub
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
    Public Sub SetGroupBoxHeight(RecordsToDisplay As Integer, PassedRecordCount As Integer, PassedGroupBox As GroupBox, PassedDataGridView As DataGridView)
        If PassedRecordCount > RecordsToDisplay Then
            RecordsToDisplay = RecordsToDisplay
        Else
            If PassedRecordCount = 0 Then
                PassedRecordCount = 1
            End If
            RecordsToDisplay = PassedRecordCount
        End If
        Dim TotalRowsHeight = RecordsToDisplay * DataGridViewRowHeight
        PassedGroupBox.Height = (PassedDataGridView.ColumnHeadersHeight) + TotalRowsHeight + 44
    End Sub
    Public Sub ShowCalledForm(PassedCallingForm As Form, PassedCalledForm As Form)
        If InStr(ActiveFormsQueue, PassedCalledForm.Name) > 0 Then
            MsgBox("Error. Recursive call to a form" & vbCrLf & " Called form is currently active")
            Exit Sub
        End If
        ActiveFormsQueue = ActiveFormsQueue & "," & PassedCalledForm.Name
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
        ShowInTaskbarFlag = False
        ResetTunnels() ' INFORMATION IN TUNNELS HAVE BEEN RECEIVED
        CallingForm.Select()
        CallingForm.Show()             'enables the page to be active
        ActiveFormsQueue = Replace(ActiveFormsQueue, "," & CalledForm.Name, "")

    End Sub
    Public Sub EnableMenu(SystemsDepartmentToolStripMenuItem As ToolStripMenuItem)

        If EnableMenus Then
            SystemsDepartmentToolStripMenuItem.Visible = True
            SystemsDepartmentToolStripMenuItem.Enabled = True
        Else
            SystemsDepartmentToolStripMenuItem.Visible = False
            SystemsDepartmentToolStripMenuItem.Enabled = False
        End If

    End Sub
End Module
