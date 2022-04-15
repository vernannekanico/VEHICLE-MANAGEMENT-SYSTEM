Imports System.Data.OleDb

Public Class MyDbControls
    ' CREATE YOUR DB CONNECTION
    Private MyAccessDbConnection As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" &
                                         "Data Source=vehicle Management Database.accdb;")

    ' PREPARE DB COMMAND
    Private MyAccessDbCommand As OleDbCommand

    ' DB DATA
    Public MyAccessDbDataAdapter As OleDbDataAdapter
    Public MyAccessDbDataTable As DataTable


    ' QUERY PARAMETERS
    Public MyAccessDbParameter As New List(Of OleDbParameter)

    ' QUERY STATISTICS
    '    Public RecordCount As Integer
    Public Exception As String

    Public Sub MyDbCommand(Command As String)
        ' RESET QUERY STATS
        RecordCount = 0
        Exception = ""

        Try
            ' OPEN A CONNECTION
            MyAccessDbConnection.Open()

            ' CREATE DB COMMAND
            MyAccessDbCommand = New OleDbCommand(Command, MyAccessDbConnection)

            ' LOAD PARAMS INTO DB COMMAND
            MyAccessDbParameter.ForEach(Sub(p) MyAccessDbCommand.Parameters.Add(p))

            ' CLEAR PARAMS LIST
            MyAccessDbParameter.Clear()

            ' EXECUTE COMMAND & FILL DATATABLE
            MyAccessDbDataTable = New DataTable
            MyAccessDbDataAdapter = New OleDbDataAdapter(MyAccessDbCommand)
            RecordCount = MyAccessDbDataAdapter.Fill(MyAccessDbDataTable)
        Catch ex As Exception
            Exception = ex.Message



            MsgBox(Exception)
            Dim pause = ""
        End Try

        ' CLOSE YOUR CONNECTION
        If MyAccessDbConnection.State = ConnectionState.Open Then MyAccessDbConnection.Close()
    End Sub

    ' INCLUDE QUERY & COMMAND PARAMETERS
    Public Sub AddParam(Name As String, Value As Object)
        Dim NewParam As New OleDbParameter(Name, Value)
        MyAccessDbParameter.Add(NewParam)
    End Sub
End Class

