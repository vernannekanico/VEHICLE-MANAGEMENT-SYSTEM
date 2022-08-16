Module MyPublicProceduresAndFuctions

    Public Function NotEmpty(text As String) As Boolean
        Return Not String.IsNullOrEmpty(text)
    End Function
    Public Function IsEmpty(text As String) As Boolean
        Return String.IsNullOrEmpty(text)
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
    Public Sub JustExecuteMySelection()
        If NoRecordFound() Then Exit Sub
    End Sub
    Public Function NoRecordFound()
        If ThereIsARecord() Then
            Return False
        Else
            Return True
        End If
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
            WorkOrderID2 = RTrim(LTrim(Str(VehicleMilage_Integer)))
        End If

        Dim NewWorkOrderID = Trim(WorkOrderID1) & WorkOrderID2
        If NewWorkOrderID = "" Then
            MsgBox("Current record " & Trim(Str(CurrentRecord)) & " is not valid, investigate? ")
        End If
        Return NewWorkOrderID

    End Function
    Public Sub EnAbleAccess(MenuOption As ToolStripMenuItem)
        MenuOption.Enabled = False
    End Sub

    Public Sub DisAbleAccess(MenuOption As ToolStripMenuItem)
        MenuOption.Enabled = False
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
        Dim r As DataRow = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        Dim xxx = r(FieldToUpdate)
    End Sub
    Public Sub InsertThisRecord()

    End Sub
    Public Sub ResetTunnels()
        Tunnel1 = ""
        Tunnel2 = ""
        Tunnel3 = ""
    End Sub

End Module
