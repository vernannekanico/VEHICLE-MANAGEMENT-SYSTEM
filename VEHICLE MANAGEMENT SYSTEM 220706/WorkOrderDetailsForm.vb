Public Class WorkOrderDetailsForm
    Private ExitAnyway As Boolean = False
    Private NoOfEntries As Integer = 0
    Private ConcernsDBControl As New MyDbControls
    Private WorkOrderConcernsDataGridViewInitialized = False

    Private WorkOrderConcernsDbTableCommand = ""
    Private WorkOrderConcernsDbTableFieldsToSelect = ""
    Private WorkOrderConcernsDbTableLinks = ""
    Private WorkOrderConcernsDbTableRecordsSelectionFilter = ""
    Private WorkOrderConcernsDbTableRecordsOrder = ""

    Private MeLocationX As Integer
    Private MeLocationY As Integer




    Private Function NoConcernEntryExist()
        MySelection = "Select * " &
                           " FROM WorkOrderConcernsTempTable "
        '       Dim xxx As Boolean = NoRecordFound() ' this line seems to be not needed
        If NoRecordFound() Then
            Return True
        Else
            Return False
        End If
    End Function



End Class