Imports excel = Microsoft.Office.Interop.Excel
Public Class JobsForm
    Private CurrentJobID As Integer = -1
    Private CurrentJobRow As Integer = -1
    Private JobsRecordCount As Integer = -1

    Private JobsFieldsToSelect = ""
    Private JobsTablesLinks = ""
    Private JobsSelectionFilter = ""        'Setup before calling the sub Fill
    Private JobsSelectionFilterSaved = ""
    Private JobsSelectionOrder = ""     'Setup before calling the sub Fill

    Private JobsDataGridViewInitialized = False
    Private JobsDataGridViewAlreadyFormated = False
    Private ProcedureExists = ""
    Private ExcelFileName = ""

    Public ProcedureNamePrefix = ""
    Public CurrentSubSystemCode As Integer = -1
    Public CurrentVehicleRepairCode = ""
    Public CurrentParentName = ""
    Public CurrentSubSystemName = ""
    Private Sub JobsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' check these if needed
        'GET ALL ENTRY PARAMETERS
        JobsSelectionFilter = ""
        CurrentJobID = Val(Tunnel1)
        If Tunnel2 > 0 Then                      ' set if fixed make is required
            JobsSelectionFilter = "WHERE JobsRelationsTable.JobsID_LongInteger = " & Str(CurrentJobID)
        End If
        ProcedureNamePrefix = Tunnel3

        JobsSelectionFilterSaved = JobsSelectionFilter

        ' check these if needed

        FillJobsDataGridView()


        'SET AND RESET ALL ENTRY PARAMETERS
        ResetTunnels()
    End Sub


    Private Sub FillJobsDataGridView()
        Exit Sub
        JobsFieldsToSelect = "Select * "


        JobsTablesLinks = " FROM JobsTable "
        JobsSelectionOrder = " ORDER BY JobCode_ShortText30 ASC"

        MySelection = JobsFieldsToSelect & JobsTablesLinks & JobsSelectionFilter & JobsSelectionOrder

        If NoRecordFound() Then
            Dim xxx = 10
        End If
        JobsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        If Not JobsDataGridViewAlreadyFormated Then
            JobsDataGridViewAlreadyFormated = True
            FormatJobsDataGridView()
        End If
    End Sub
    Private Sub FormatJobsDataGridView()
        JobsDataGridViewAlreadyFormated = True

        JobsDataGridView.Columns.Item("JobTypeID_LongInteger").Visible = False
        '       JobsDataGridView.Columns.Item("JobCodeID_AutoNumber").Visible = False
        JobsDataGridView.Columns.Item("MasterCodeBookId_LongInteger").Visible = False
        JobsDataGridView.Columns.Item("JobType_ShortText100").Visible = False

        JobsDataGridView.Columns.Item("JobTypePrefix_ShortText50").HeaderText = " "
        JobsDataGridView.Columns.Item("JobTypePrefix_ShortText50").Width = 105


        JobsDataGridView.Columns.Item("SystemDesc_ShortText100Fld").HeaderText = "JobS : in Master Code Book"
        JobsDataGridView.Columns.Item("SystemDesc_ShortText100Fld").Width = 500

        JobsDataGridView.Columns.Item("Job_ShortText255").HeaderText = "JobS : in JobsTable old description"
        JobsDataGridView.Columns.Item("Job_ShortText255").Width = 500

        JobsDataGridView.Width = JobsDataGridView.Columns.Item("JobTypePrefix_ShortText50").Width +
                                     JobsDataGridView.Columns.Item("SystemDesc_ShortText100Fld").Width +
                                     JobsDataGridView.Columns.Item("Job_ShortText255").Width + 50

        Me.Width = JobsDataGridView.Width + 30
    End Sub

    Private Sub CreateProcedureToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateProcedureToolStripMenuItem.Click
        Select Case CreateProcedureToolStripMenuItem.Text
            Case = "CREATE Procedure"
                CreateExcelFile()
                OpenExcelFile(True)
                CreateProcedureToolStripMenuItem.Text = "Open Procedure"
                RemoveJobToolStripMenuItem.Visible = False

            Case = "Open Procedure"

                OpenExcelFile(True)
                Exit Sub
        End Select
        Me.Show()
        JobsDataGridView.Select()
    End Sub
    Private Sub CreateExcelFile()

        Dim xlApp As excel.Application = New Microsoft.Office.Interop.Excel.Application()

        If xlApp Is Nothing Then
            MessageBox.Show("Excel is not properly installed!!, paki check")
            Return
        End If

        Dim xlWorkBook As excel.Workbook
        Dim xlWorkSheet As excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value

        xlWorkBook = xlApp.Workbooks.Add(misValue)
        xlWorkSheet = xlWorkBook.Sheets("sheet1")
        xlWorkSheet.Cells(1, 1) = DefaultVehicleModelTextBox.Text
        xlWorkSheet.Cells(2, 1) = CurrentParentName & "/" & CurrentSubSystemName
        xlWorkSheet.Cells(3, 1) = "Paste Here"




        xlWorkSheet.Cells(3, 1).select

        Do While xlWorkSheet.Cells(3, 1).value = "Paste Here"

            MsgBox("Please make Sure you already to copied the data then hit any key to proceed")

            '           EXECUTE MACRO FOR DISSECTING THE EXCEL FILE HERE

            xlWorkSheet.Cells(3, 1).Select()
            '         xlWorkSheet.PasteSpecial(Format:="HTML", Link:=False, DisplayAsIcon:=False)
            xlWorkSheet.Paste()

            xlWorkSheet.Cells.Select()

            Dim formatRange As excel.Range
            formatRange = xlWorkSheet.Range("a1", "c100")
            '           formatRange.WrapText = False
            '           formatRange.Orientation = 0
            '           formatRange.AddIndent = False
            '           formatRange.ShrinkToFit = False

            With formatRange
                .WrapText = False
                .Orientation = 0
                .AddIndent = False
                .ShrinkToFit = False
                .MergeCells = False
            End With


            With formatRange.Font
                .Size = 14
                .Strikethrough = False
                .Superscript = False
                .Subscript = False
                .OutlineFont = False
                .Shadow = False
                .TintAndShade = 0
            End With
            xlWorkSheet.Cells.Select()
            xlWorkSheet.Cells.EntireRow.AutoFit()
            xlWorkSheet.Cells.EntireColumn.AutoFit()
            formatRange.ColumnWidth = 13.71
            xlWorkSheet.Range("F9").Select()
            '           xlWorkSheet.Columns("A:A").ColumnWidth = 6.14
            '           END EXECUTE MACRO FOR DISSECTING THE EXCEL FILE HERE 
        Loop



        CurrentParentName = Replace(CurrentParentName, "/", "-")
        CurrentSubSystemName = Replace(CurrentSubSystemName, "/", "-")

        Dim ProcedureName = Str(1000 + CurrentVehicleRepairCode).Substring(2) & CurrentSubSystemCode & Space(1) & CurrentParentName & "-" & CurrentSubSystemName

        ExcelFileName = ProcedureNamePrefix & ProcedureName & ".xlxs"

        Dim Exception = ""
        Try
            ' OPEN A CONNECTION
            xlWorkBook.SaveAs(ExcelFileName, excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue,
         excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue)
        Catch ex As Exception
            Exception = ex.Message
            MsgBox(Exception)
            MsgBox("do a break here, to check why")
            Exit Sub
        End Try

        xlWorkBook.Close(True, misValue, misValue)
        '              SendKeys.Send("{CR}")

        xlApp.Quit()
        releaseObject(xlWorkSheet)
        releaseObject(xlWorkBook)
        releaseObject(xlApp)

    End Sub
    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub OpenExcelFile(NewlyCreatedFile)
        Dim xlApp As excel.Application = New Microsoft.Office.Interop.Excel.Application()

        If xlApp Is Nothing Then
            MessageBox.Show("Excel is not properly installed!!")
            Return
        End If

        Dim ProcessID As Integer
        Dim NewProcess As Diagnostics.Process
        Dim Exception = ""
        Try
            NewProcess = Diagnostics.Process.Start(ExcelFileName)
        Catch ex As Exception
            Exception = ex.Message
            MsgBox(Exception)
            MsgBox("do a break here, to check why")
            Exit Sub
        End Try
        ProcessID = NewProcess.Id

        Me.Enabled = False
        NewProcess.WaitForExit()
        Dim procEC As Integer = -1
        If NewProcess.HasExited Then
            procEC = NewProcess.ExitCode
            Me.Enabled = True
            Me.Show()
        End If

    End Sub

    Private Sub JobsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles JobsDataGridView.RowEnter
        CurrentJobID = e.RowIndex
        Dim ProcedureName = Str(1000 + CurrentVehicleRepairCode).Substring(2) & CurrentSubSystemCode
        ExcelFileName = ProcedureNamePrefix & ProcedureName & ".xlsx"
        ProcedureExists = Dir(ExcelFileName, vbHidden)
        '---------------------------------------------------------------------------
        ' *********    DETERMINE PROCEDURE EXCELL FILE RELATED TO THE CURRENT CurrentSubSystemCode EXISTS

        If ProcedureExists = "" Then

            ' *********     try the filename with text if exist

            Dim ExcelFileNameAll = ProcedureNamePrefix & ProcedureName & " *.xlxs"


            ProcedureExists = Dir(ExcelFileNameAll, vbHidden)
            If CurrentVehicleRepairCode > 0 Then                                        ' If the vehicle model is not set creation and opening of procedures are not provided
                ' and no deletion of child is allowed
                CreateProcedureToolStripMenuItem.Visible = True

                ' *********                                                             IF EXISTS ALLOW OPENING ELSE ALLOW CREATE

                If Not ProcedureExists = "" Then
                    CreateProcedureToolStripMenuItem.Text = "Open Procedure"
                Else
                    CreateProcedureToolStripMenuItem.Text = "CREATE Procedure"
                End If

                ' *********                                                             IF EXISTS ALLOW OPENING ELSE ALLOW CREATE

            Else
                CreateProcedureToolStripMenuItem.Text = ""
            End If
        Else
            If Not ProcedureExists = "" Then
                CreateProcedureToolStripMenuItem.Text = "Open Procedure"
            Else
                CreateProcedureToolStripMenuItem.Text = "CREATE Procedure"
            End If

            ' *********                                                                 IF EXISTS ALLOW OPENING ELSE ALLOW CREATE ENDS

        End If

        ' *********                                                                     DETERMINES PROCEDURE EXCELL FILE RELATED TO THE CURRENT CurrentSubSystemCode ENDS

    End Sub

    Private Sub JobsForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        'SEE housekeeping at the return/close form (◄ ) Or double_click_event
        'Enables calling form
        Select Case ActivatedByTextBox.Text
            Case "MasterCodeBookForm"
                MasterCodeBookForm.Enabled = True
            Case "Form2"
            Case Else
                MsgBox(ActivatedByTextBox.Text & """ not yet filtered in the Select Case ActivatedBy.Text of """ & Me.Name)
        End Select
        ActivatedByTextBox.Text = ""
    End Sub
End Class