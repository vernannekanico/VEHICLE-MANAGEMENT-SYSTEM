﻿Public Class PartsSpecificationsForm
    Private PartsSpecificationsFieldsToSelect = ""
    Private PartsSpecificationsSelectionFilter = ""
    Private PartsSpecificationsSelectionOrder = ""
    Private PartsSpecificationsRecordCount As Integer = -1
    Private CurrentPartsSpecificationsDataGridViewRow As Integer = -1
    Private CurrentPartsSpecificationsID = -1
    Private PartsSpecificationsDataGridViewAlreadyFormatted = False

    Private CodeVehiclePartsSpecificationsFieldsToSelect = ""
    Private CodeVehiclePartsSpecificationsSelectionFilter = ""
    Private CodeVehiclePartsSpecificationsSelectionOrder = ""
    Private CodeVehiclePartsSpecificationsRecordCount As Integer = -1
    Private CurrentCodeVehiclePartsSpecificationsDataGridViewRow As Integer = -1
    Private CurrentCodeVehiclePartsSpecificationsRelationID = -1
    Private CodeVehiclePartsSpecificationsDataGridViewAlreadyFormatted = False

    Private PartNumberSpecificationsFieldsToSelect = ""
    Private PartNumberSpecificationsSelectionFilter = ""
    Private PartNumberSpecificationsSelectionOrder = ""
    Private PartNumberSpecificationsRecordCount As Integer = -1
    Private CurrentPartNumberSpecificationsDataGridViewRow As Integer = -1
    Private PartNumberSpecificationsDataGridViewAlreadyFormatted = False

    Private CodeVehiclePNSpecificationsFieldsToSelect = ""
    Private CodeVehiclePNSpecificationsSelectionFilter = ""
    Private CodeVehiclePNSpecificationsSelectionOrder = ""
    Private CodeVehiclePNSpecificationsRecordCount As Integer = -1
    Private CurrentCodeVehiclePNSpecificationsDataGridViewRow As Integer = -1
    Private CurrentCodeVehiclePNSpecificationID = -1
    Private CodeVehiclePNSpecificationsDataGridViewAlreadyFormatted = False

    Private QuantitySpecificationsFieldsToSelect = ""
    Private QuantitySpecificationsSelectionFilter = ""
    Private QuantitySpecificationsSelectionOrder = ""
    Private QuantitySpecificationsRecordCount As Integer = -1
    Private CurrentQuantitySpecificationsID As Integer = -1
    Private CurrentQuantitySpecificationsDataGridViewRow As Integer = -1
    Private QuantitySpecificationsDataGridViewAlreadyFormatted = False

    Private CurrentQuantitySpecificationID = -1
    Private CurrentJobDesCription = ""
    Private CurrentPartNumberSpecificationID = -1
    Private CurrentPartSpecificationsID = -1
    Private CurrentCodeVehicleID = -1
    Private CurrentInformationsHeaderID = -1
    Private CurrentMasterCodeBookID As Integer = -1
    Private SavedCallingForm As Form
    Private PurposeOfEntry = ""
    Private BackToEditMode = False

    Private Sub PartSpecificationsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' IF CodeVehiclePartsSpecifications = 1 'ONLY 1 SPECIFICATION PER PART
        '    dISABLE ABILITY TO ADD NEW. sPECIFICATIONSdATAgRIDGroupBox is made not visible
        ' NOTE CodeVehiclesRrlationsTable WILL DETERMINE ALL LINKS TO THE SPECIFICS OF THE PART
        ' INPUT WILL THEN BE MASTERCODEBOOKID AND VEHICLEID
        ' Tunnel 1 - InformationsHeaderID (Job Description) -deals with specific vehicle qty/unit specs
        ' Tunnel 2 - CodeVehicleID                          -deals with specific vehicle part specs
        ' Tunnel 3 - MasterCodeBookID                       -deals with product specifications
        ' Tunnel 4 - Vehicle Description    for view information only
        ' FillUP the PartDescriptionTextBox before entry
        ' CALLING FORM DETERMINE WHETHER THIS FORM WORKS WITH PAT OR SPECIFICATION BY
        ' ENABLING EITHER PartNumberSpecificationTextBox TO WORK WITH PATNUMBERS
        ' OR PartSpecificationsTextBox TO WORK WITH SPECIFICATION
        'HERE WE HAVE TO DETERMINE WHAT IS REQUESTED FOR
        'AND FOR EACH
        '   WE HAVE 3 MODES   - 1 SELECTING AN SPECIFICATION FROM ALL THE LISTINGS FOR ALL SPECS FOR THE PART/product
        '   AND                      2 SELECTING AN SPECIFICATION FROM THE SPECIFICATION SPECIFIC FOR THE CAR MODEL
        '   and 3 Requesting for the specified quantity and unit

        SavedCallingForm = CallingForm
        'determine what informations are to be displayed based on the requesting form
        Select Case CallingForm.Name
            Case "ProductsPartsForm"
                '               PartsSpecificationsHeaderMenuToolStripMenuItem.Visible = True
        End Select


        CurrentCodeVehicleID = Tunnel2
        CurrentMasterCodeBookID = Tunnel3
        VehicleModelTextBox.Text = Tunnel4

        If IsNotEmpty(Tunnel1) Then
            'dealing with quantity and unit specifications
            CurrentJobDesCription = Tunnel1
        Else
            ProductPartSpecificationsTextBox.Enabled = True
        End If
        ' Initialize TEXT BOXES TO DEFINE WHAT TYPE OF DATA TO STORE
        If ProductPartSpecificationsTextBox.Enabled Then
            'revised HERE WORK WITH TYPE SPECIFICATIONS ONLY
            'revision Since a part can have an specified part number and part specification also
            'then will disable this PartNoSpecificationsItemToolStripMenuItem.Visible = False

            If IsNotEmpty(Tunnel1) Then 'IS JOB SPECIFIED?
                CodeVehiclePartsSpecificationsRelationsGroupBox.Text = "Specifications for " + GetFieldValue("MasterCodeBookTable", "MasterCodeBookID_Autonumber", CurrentMasterCodeBookID, "SystemDesc_ShortText100Fld").ToString
                CodeVehiclePartsSpecificationsSelectionFilter = " WHERE CodeVehicleID_LongInteger = " & CurrentCodeVehicleID.ToString &
                                                                    " AND MasterCodeBookID_Autonumber = " & CurrentMasterCodeBookID.ToString
                FillCodeVehiclePartsSpecificationsRelations()
                'THERE WILL BE ONLY 1 PART TYPE SPECIFICATION PER VEHICLE PER PART
                'WHICH DIFFER WITH PART NUMBER SPECIFICATIONS WHERE MULTIPLE PARTS NUMBERS CAN SUPERCEEDE OTHERS
                ' SO DISABLE ABILITY TO ADD MORE SPECIFICATION BY DISABLING PartsSpecificationsGroupBox
                ' AND THE MENU OPTION
                If RecordCount > 0 Then
                    CodeVehiclePartsSpecificationsRelationsGroupBox.Visible = True
                    PartsSpecificationsHeaderMenuToolStripMenuItem.Visible = True
                    ProductsPartsSpecificationsGroupBox.Visible = False
                    AddPartSpecificationsToolStripMenuItem.Visible = False
                Else
                    CodeVehiclePartsSpecificationsRelationsGroupBox.Visible = False
                    ProductsPartsSpecificationsGroupBox.Visible = False
                    AddPartSpecificationsToolStripMenuItem.Visible = True
                End If
            Else
                'work with product specifications
                CodeVehiclePartsSpecificationsRelationsGroupBox.Visible = False
            End If
            ProductsPartsSpecificationsGroupBox.Text = "All Part Specs for " & GetFieldValue("MasterCodeBookTable", "MasterCodeBookID_Autonumber", CurrentMasterCodeBookID, "SystemDesc_ShortText100Fld")
            PartsSpecificationsSelectionFilter = " WHERE MasterCodeBookID_LongInteger = " & CurrentMasterCodeBookID.ToString
            FillPartsSpecificationsDataGridView()
            ServiceToPerformTextBox.Text = CurrentJobDesCription
            SpecifiedQuantityTextBox.Text = RequestPartsForm.SpecifiedQuantityTextBox.Text
            SpecifiedUnitTextBox.Text = RequestPartsForm.SpecifiedUnitTextBox.Text
        Else
            PartNoSpecificationsItemToolStripMenuItem.Visible = True
            DisablePartsSpecificationsOPtions()
            DisableQuantitySpecificationsOPtions()
            PartNumberSpecificationsGroupBox.Visible = False
            CodeVehiclePNSpecificationsGroupBox.Visible = True
            CodeVehiclePNSpecificationsGroupBox.Enabled = True
            MsgBox("following filter was not yet tested just modified to copy above filter of type specification")
            Stop
            CodeVehiclePNSpecificationsSelectionFilter = " WHERE CodeVehicleID_LongInteger = " & CurrentCodeVehicleID.ToString &
                                                                    " AND MasterCodeBookID_Autonumber = " & CurrentMasterCodeBookID.ToString
            FillCodeVehiclePNSpecificationsRelations()
            PartNumberSpecificationsGroupBox.Text = "All part number Specs for " + GetFieldValue("MasterCodeBookTable", "MasterCodeBookID_Autonumber", CurrentMasterCodeBookID, "SystemDesc_ShortText100Fld")
            PartNumberSpecificationsSelectionFilter = " WHERE MasterCodeBookID_LongInteger = " & CurrentMasterCodeBookID.ToString
            FillPartNumberSpecificationsDataGridView()
            PartNoSpecificationsItemToolStripMenuItem.Select()
        End If
    End Sub
    Private Sub FillCodeVehiclePartsSpecificationsRelations()
        ' FOLLOWING StripMenuItem ARE MADE VISIBLE ONLY WHEN THERE IS A RECORD FOUND
        SelectPartSpecificationsToolStripMenuItem.Visible = False
        EditPartSpecificationsToolStripMenuItem.Visible = False
        RemovePartSpecificationsToolStripMenuItem.Visible = False
        CodeVehiclePartsSpecificationsFieldsToSelect =
"
SELECT 
CodeVehiclePartsSpecificationsRelationsTable.CodeVehicleID_LongInteger, 
PartsSpecificationsTable.PartSpecifications_ShortText255, 
MasterCodeBookTable.SystemDesc_ShortText100Fld, 
MasterCodeBookTable.MasterCodeBookID_Autonumber,
CodeVehiclePartsSpecificationsRelationsTable.CodeVehiclePartsSpecificationsRelationID_AutoNumber
FROM ((CodeVehiclePartsSpecificationsRelationsTable LEFT JOIN PartsSpecificationsTable ON CodeVehiclePartsSpecificationsRelationsTable.PartsSpecificationID_LongInteger = PartsSpecificationsTable.PartsSpecificationID_AutoNumber) LEFT JOIN CodeVehiclesTable ON CodeVehiclePartsSpecificationsRelationsTable.CodeVehicleID_LongInteger = CodeVehiclesTable.CodeVehicleID_AutoNumber) LEFT JOIN MasterCodeBookTable ON CodeVehiclesTable.MasterCodeBookID_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber
"
        MySelection = CodeVehiclePartsSpecificationsFieldsToSelect & CodeVehiclePartsSpecificationsSelectionFilter

        JustExecuteMySelection()
        CodeVehiclePartsSpecificationsRecordCount = RecordCount
        If RecordCount > 0 Then
            SelectPartSpecificationsToolStripMenuItem.Visible = True
            EditPartSpecificationsToolStripMenuItem.Visible = True
            RemovePartSpecificationsToolStripMenuItem.Visible = True
        End If
        CodeVehicleSpecificationsRelationsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        CodeVehiclePartsSpecificationsRelationsGroupBox.Visible = True
        If Not CodeVehiclePartsSpecificationsDataGridViewAlreadyFormatted Then
            FormatCodeVehiclePartsSpecificationsRelationsDataGridView()
        End If
        SetGroupBoxHeight(6, CodeVehiclePartsSpecificationsRecordCount + 1, CodeVehiclePartsSpecificationsRelationsGroupBox, CodeVehicleSpecificationsRelationsDataGridView)
        CodeVehiclePartsSpecificationsRelationsGroupBox.Top = BottomOf(VehicleModelTextBox)
        CodeVehiclePartsSpecificationsRelationsGroupBox.Left = 1
        CodeVehiclePartsSpecificationsRelationsGroupBox.BringToFront()
        CodeVehiclePartsSpecificationsRelationsGroupBox.Visible = True
    End Sub

    Private Sub FormatCodeVehiclePartsSpecificationsRelationsDataGridView()
        CodeVehiclePartsSpecificationsDataGridViewAlreadyFormatted = True
        CodeVehiclePartsSpecificationsRelationsGroupBox.Width = 0

        For i = 0 To CodeVehicleSpecificationsRelationsDataGridView.Columns.GetColumnCount(0) - 1

            CodeVehicleSpecificationsRelationsDataGridView.Columns.Item(i).Visible = False

            Select Case CodeVehicleSpecificationsRelationsDataGridView.Columns.Item(i).Name
                Case "PartSpecifications_ShortText255"
                    CodeVehicleSpecificationsRelationsDataGridView.Columns.Item(i).HeaderText = "SPECIFICATIONS"
                    CodeVehicleSpecificationsRelationsDataGridView.Columns.Item(i).Width = PartDescriptionTextBox.Width
                    CodeVehicleSpecificationsRelationsDataGridView.Columns.Item(i).Visible = True
            End Select
            If CodeVehicleSpecificationsRelationsDataGridView.Columns.Item(i).Visible = True Then
                CodeVehiclePartsSpecificationsRelationsGroupBox.Width = CodeVehiclePartsSpecificationsRelationsGroupBox.Width + CodeVehicleSpecificationsRelationsDataGridView.Columns.Item(i).Width
            End If
        Next
        CodeVehicleSpecificationsRelationsDataGridView.Width = CodeVehiclePartsSpecificationsRelationsGroupBox.Width - 6

    End Sub
    Private Sub CodeVehiclePartsSpecificationsRelationsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles CodeVehicleSpecificationsRelationsDataGridView.RowEnter
        If e.RowIndex < 0 Then Exit Sub
        If CodeVehiclePartsSpecificationsRecordCount = 0 Then Exit Sub

        CurrentCodeVehiclePartsSpecificationsDataGridViewRow = e.RowIndex
        CurrentCodeVehiclePartsSpecificationsRelationID = CodeVehicleSpecificationsRelationsDataGridView.Item("CodeVehiclePartsSpecificationsRelationID_AutoNumber", CurrentCodeVehiclePartsSpecificationsDataGridViewRow).Value
    End Sub
    Private Sub FillPartsSpecificationsDataGridView()
        PartsSpecificationsFieldsToSelect =
" 
SELECT 
PartsSpecificationsTable.PartsSpecificationID_AutoNumber, 
PartsSpecificationsTable.MasterCodeBookID_LongInteger, 
PartsSpecificationsTable.PartSpecifications_ShortText255
FROM PartsSpecificationsTable
"
        MySelection = PartsSpecificationsFieldsToSelect & PartsSpecificationsSelectionFilter

        JustExecuteMySelection()
        PartsSpecificationsRecordCount = RecordCount
        ' HERE PartsSpecificationsGroupBox IS SET VISIBLE WHEN 
        ' CodeVehiclePartsSpecificationsCOUNT > 0
        ProductsPartsSpecificationsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If Not PartsSpecificationsDataGridViewAlreadyFormatted Then
            FormatPartsSpecificationsDataGridView()
        End If
        SetGroupBoxHeight(6, PartsSpecificationsRecordCount + 1, ProductsPartsSpecificationsGroupBox, ProductsPartsSpecificationsDataGridView)
        ProductsPartsSpecificationsGroupBox.Top = BottomOf(VehicleModelTextBox)
    End Sub

    Private Sub FormatPartsSpecificationsDataGridView()
        PartsSpecificationsDataGridViewAlreadyFormatted = True
        ProductsPartsSpecificationsGroupBox.Width = 0

        For i = 0 To ProductsPartsSpecificationsDataGridView.Columns.GetColumnCount(0) - 1

            ProductsPartsSpecificationsDataGridView.Columns.Item(i).Visible = False
            Select Case ProductsPartsSpecificationsDataGridView.Columns.Item(i).Name
                Case "PartSpecifications_ShortText255"
                    ProductsPartsSpecificationsDataGridView.Columns.Item(i).HeaderText = "SPECIFICATIONS ALL"
                    ProductsPartsSpecificationsDataGridView.Columns.Item(i).Width = PartDescriptionTextBox.Width
                    ProductsPartsSpecificationsDataGridView.Columns.Item(i).Visible = True
            End Select
            If ProductsPartsSpecificationsDataGridView.Columns.Item(i).Visible = True Then
                ProductsPartsSpecificationsGroupBox.Width = ProductsPartsSpecificationsGroupBox.Width + ProductsPartsSpecificationsDataGridView.Columns.Item(i).Width
            End If
        Next
        ProductsPartsSpecificationsGroupBox.Left = CodeVehiclePartsSpecificationsRelationsGroupBox.Left

    End Sub
    Private Sub PartsSpecificationsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles ProductsPartsSpecificationsDataGridView.RowEnter

        If ShowInTaskbarFlag Then Exit Sub
        If Me.Enabled = False Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If PartsSpecificationsRecordCount = 0 Then Exit Sub

        CurrentPartsSpecificationsDataGridViewRow = e.RowIndex
        FillField(CurrentPartsSpecificationsID, ProductsPartsSpecificationsDataGridView.Item("PartsSpecificationID_AutoNumber", CurrentPartsSpecificationsDataGridViewRow).Value)
        If ProductPartSpecificationsTextBox.Text = "type new specifications" Then ProductPartSpecificationsTextBox.SelectAll()
        EnablePartOPtions()
    End Sub
    Private Sub FillCodeVehiclePNSpecificationsRelations()
        CodeVehiclePNSpecificationsFieldsToSelect =
"
SELECT 
CodeVehiclePartNumbersSpecificationsRelationsTable.CodeVehiclePartNumbersSpecificationsRelationID_AutoNumber, 
CodeVehiclePartNumbersSpecificationsRelationsTable.CodeVehicleID_LongInteger, 
PartNumbersSpecificationsTable.PartNumberSpecifications_ShortText30, 
MasterCodeBookTable.SystemDesc_ShortText100Fld
FROM (CodeVehiclePartNumbersSpecificationsRelationsTable LEFT JOIN PartNumbersSpecificationsTable ON CodeVehiclePartNumbersSpecificationsRelationsTable.[PartNumbersSpecificationID_LongInteger] = PartNumbersSpecificationsTable.PartNUmbersSpecificationID_AutoNumber) LEFT JOIN (CodeVehiclesTable LEFT JOIN MasterCodeBookTable ON CodeVehiclesTable.MasterCodeBookID_LongInteger = MasterCodeBookTable.MasterCodeBookID_Autonumber) ON CodeVehiclePartNumbersSpecificationsRelationsTable.CodeVehicleID_LongInteger = CodeVehiclesTable.CodeVehicleID_AutoNumber
"
        MySelection = CodeVehiclePNSpecificationsFieldsToSelect & CodeVehiclePNSpecificationsSelectionFilter

        JustExecuteMySelection()
        CodeVehiclePNSpecificationsDataGridView.Enabled = True
        PartNumberSpecificationsGroupBox.Visible = False
        CodeVehiclePNSpecificationsRecordCount = RecordCount
        If CodeVehiclePNSpecificationsRecordCount = 0 Then
            'THERE IS NO part SPECIFICATION YET FOR THIS CODE
            'MUST ADD NEW PART SPECIFICATION 1ST IN THE PART SPECIFICATION LIST
            'ENABLE RDITING OF THE PartNumberSpecifications LIST
            CodeVehiclePNSpecificationsDataGridView.Enabled = False
            PartNumberSpecificationsGroupBox.Visible = True
        End If

        If CodeVehiclePNSpecificationsDataGridView.Enabled = True Then  'CodeVehiclePNSpecificationsDataGridView is active
            SelectPartNumberToolStripMenuItem.Visible = False
            EditPartNumberToolStripMenuItem.Visible = False
            RemovePartNumberToolStripMenuItem.Visible = False
            If CodeVehiclePNSpecificationsRecordCount > 0 Then
                SelectPartNumberToolStripMenuItem.Visible = True
                EditPartNumberToolStripMenuItem.Visible = True
                RemovePartNumberToolStripMenuItem.Visible = True
            End If
        End If
        If PartNumberSpecificationsGroupBox.Visible Then
            SelectPartNumberToolStripMenuItem.Visible = True
            EditPartNumberToolStripMenuItem.Visible = True
            RemovePartNumberToolStripMenuItem.Visible = True
        End If

        CodeVehiclePNSpecificationsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If Not CodeVehiclePNSpecificationsDataGridViewAlreadyFormatted Then
            FormatCodeVehiclePNSpecificationsDataGridView()
        End If
        SetGroupBoxHeight(6, CodeVehiclePNSpecificationsRecordCount + 1, CodeVehiclePNSpecificationsGroupBox, CodeVehiclePNSpecificationsDataGridView)
        CodeVehiclePNSpecificationsGroupBox.Top = VehicleModelTextBox.Top + VehicleModelTextBox.Height + 2
    End Sub

    Private Sub FormatCodeVehiclePNSpecificationsDataGridView()
        CodeVehiclePNSpecificationsDataGridViewAlreadyFormatted = True
        CodeVehiclePNSpecificationsGroupBox.Width = 0

        For i = 0 To CodeVehiclePNSpecificationsDataGridView.Columns.GetColumnCount(0) - 1

            CodeVehiclePNSpecificationsDataGridView.Columns.Item(i).Visible = False

            Select Case CodeVehiclePNSpecificationsDataGridView.Columns.Item(i).Name
                Case "PartNumberSpecifications_ShortText30"
                    CodeVehiclePNSpecificationsDataGridView.Columns.Item(i).HeaderText = "SPECIFICATIONS"
                    CodeVehiclePNSpecificationsDataGridView.Columns.Item(i).Width = PartDescriptionTextBox.Width
                    CodeVehiclePNSpecificationsDataGridView.Columns.Item(i).Visible = True
            End Select
            If CodeVehiclePNSpecificationsDataGridView.Columns.Item(i).Visible = True Then
                CodeVehiclePNSpecificationsGroupBox.Width = CodeVehiclePNSpecificationsGroupBox.Width + CodeVehiclePNSpecificationsDataGridView.Columns.Item(i).Width
            End If
        Next
        CodeVehiclePNSpecificationsDataGridView.Width = CodeVehiclePNSpecificationsGroupBox.Width - 6
        CodeVehiclePNSpecificationsGroupBox.Left = PartDescriptionTextBox.Left

    End Sub
    Private Sub CodeVehiclePNSpecificationsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles CodeVehiclePNSpecificationsDataGridView.RowEnter
        If e.RowIndex < 0 Then Exit Sub
        If CodeVehiclePNSpecificationsRecordCount = 0 Then Exit Sub

        CurrentCodeVehiclePNSpecificationsDataGridViewRow = e.RowIndex
        CurrentCodeVehiclePNSpecificationID = CodeVehiclePNSpecificationsDataGridView.Item("CodeVehiclePartNumbersSpecificationsRelationID_AutoNumber", CurrentCodeVehiclePNSpecificationsDataGridViewRow).Value
    End Sub

    Private Sub FillPartNumberSpecificationsDataGridView()
        PartNumberSpecificationsFieldsToSelect =
" 
SELECT PartNumbersSpecificationsTable.PartNUmbersSpecificationID_AutoNumber, 
PartNumbersSpecificationsTable.MasterCodeBookID_LongInteger, 
PartNumbersSpecificationsTable.PartNumberSpecifications_ShortText30
FROM PartNumbersSpecificationsTable
"
        MySelection = PartNumberSpecificationsFieldsToSelect & PartNumberSpecificationsSelectionFilter

        JustExecuteMySelection()
        PartNumberSpecificationsRecordCount = RecordCount
        If PartNumberSpecificationsRecordCount > 0 Then
            PartNumberSpecificationsGroupBox.Visible = True
        Else
            PartNumberSpecificationsGroupBox.Visible = False
        End If

        If PartNumberSpecificationsGroupBox.Visible = True Then
            SelectPartNumberToolStripMenuItem.Visible = False
            EditPartNumberToolStripMenuItem.Visible = False
            RemovePartNumberToolStripMenuItem.Visible = False
            If PartNumberSpecificationsRecordCount > 0 Then
                SelectPartNumberToolStripMenuItem.Visible = True
                EditPartNumberToolStripMenuItem.Visible = True
                RemovePartNumberToolStripMenuItem.Visible = True
            End If
        End If
        PartNumberSpecificationsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If Not PartNumberSpecificationsDataGridViewAlreadyFormatted Then
            FormatPartNumberSpecificationsDataGridView()
        End If
        SetGroupBoxHeight(6, PartNumberSpecificationsRecordCount + 1, PartNumberSpecificationsGroupBox, PartNumberSpecificationsDataGridView)
        PartNumberSpecificationsGroupBox.Top = CodeVehiclePNSpecificationsGroupBox.Top + CodeVehiclePNSpecificationsGroupBox.Height

    End Sub

    Private Sub FormatPartNumberSpecificationsDataGridView()
        PartNumberSpecificationsDataGridViewAlreadyFormatted = True
        PartNumberSpecificationsGroupBox.Width = 0

        For i = 0 To PartNumberSpecificationsDataGridView.Columns.GetColumnCount(0) - 1

            PartNumberSpecificationsDataGridView.Columns.Item(i).Visible = False
            Select Case PartNumberSpecificationsDataGridView.Columns.Item(i).Name
                Case "PartNumberSpecifications_ShortText30"
                    PartNumberSpecificationsDataGridView.Columns.Item(i).HeaderText = "SPECIFICATIONS"
                    PartNumberSpecificationsDataGridView.Columns.Item(i).Width = PartDescriptionTextBox.Width
                    PartNumberSpecificationsDataGridView.Columns.Item(i).Visible = True
            End Select
            If PartNumberSpecificationsDataGridView.Columns.Item(i).Visible = True Then
                PartNumberSpecificationsGroupBox.Width = PartNumberSpecificationsGroupBox.Width + PartNumberSpecificationsDataGridView.Columns.Item(i).Width
            End If
        Next
        PartNumberSpecificationsGroupBox.Left = CodeVehiclePNSpecificationsGroupBox.Left

    End Sub
    Private Sub PartNumberSpecificationsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles PartNumberSpecificationsDataGridView.RowEnter
        SelectPartNumberToolStripMenuItem.Visible = False
        If ShowInTaskbarFlag Then Exit Sub
        If Me.Enabled = False Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        If PartNumberSpecificationsRecordCount = 0 Then Exit Sub
        SelectPartNumberToolStripMenuItem.Visible = True
        CurrentPartNumberSpecificationsDataGridViewRow = e.RowIndex
        FillField(CurrentPartNumberSpecificationID, PartNumberSpecificationsDataGridView.Item("PartNUmbersSpecificationID_AutoNumber", CurrentPartNumberSpecificationsDataGridViewRow).Value)
    End Sub
    Private Sub FillQuantitySpecificationsDataGridView()

        '   USING QuantitySpecificationsQuery

        QuantitySpecificationsFieldsToSelect =
            " 
SELECT QuantitySpecificationsTable.QuantitySpecificationID_AutoNumber,
QuantitySpecificationsTable.InformationsHeaderID_LongInteger,
QuantitySpecificationsTable.CodeVehicleID_LongInteger,
InformationsHeadersTable.InformationsHeaderDescription_ShortText255,
QuantitySpecificationsTable.SpecifiedQuantity_Double,
QuantitySpecificationsTable.SpecifiedUnit_ShortText3
FROM QuantitySpecificationsTable INNER JOIN InformationsHeadersTable ON QuantitySpecificationsTable.InformationsHeaderID_LongInteger = InformationsHeadersTable.InformationsHeaderID_AutoNumber
"

        QuantitySpecificationsSelectionOrder = ""

        MySelection = QuantitySpecificationsFieldsToSelect & QuantitySpecificationsSelectionFilter & QuantitySpecificationsSelectionOrder


        JustExecuteMySelection()
        QuantitySpecificationsRecordCount = RecordCount
        QuantitySpecificationsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If QuantitySpecificationsRecordCount = 0 Then
            QuantitySpecificationsDataGridView.Visible = False
        Else
            QuantitySpecificationsDataGridView.Visible = True
        End If

        If Not QuantitySpecificationsDataGridViewAlreadyFormatted Then
            FormatQuantitySpecificationsDataGridView()
        End If
    End Sub


    Private Sub FormatQuantitySpecificationsDataGridView()
        QuantitySpecificationsDataGridViewAlreadyFormatted = True

        QuantitySpecificationsDataGridView.Width = 0

        For i = 0 To QuantitySpecificationsDataGridView.Columns.GetColumnCount(0) - 1

            QuantitySpecificationsDataGridView.Columns.Item(i).Visible = False

            Select Case QuantitySpecificationsDataGridView.Columns.Item(i).Name
                Case "InformationsHeaderDescription_ShortText255"
                    QuantitySpecificationsDataGridView.Columns.Item(i).HeaderText = "JOB"
                    QuantitySpecificationsDataGridView.Columns.Item(i).Width = 300
                    QuantitySpecificationsDataGridView.Columns.Item(i).Visible = True
                Case "SpecifiedQuantity_Double"
                    QuantitySpecificationsDataGridView.Columns.Item(i).HeaderText = "QTY"
                    QuantitySpecificationsDataGridView.Columns.Item(i).Width = 60
                    QuantitySpecificationsDataGridView.Columns.Item(i).Visible = True
                Case "SpecifiedUnit_ShortText3"
                    QuantitySpecificationsDataGridView.Columns.Item(i).HeaderText = "UNIT"
                    QuantitySpecificationsDataGridView.Columns.Item(i).Width = 100
                    QuantitySpecificationsDataGridView.Columns.Item(i).Visible = True
            End Select
            If QuantitySpecificationsDataGridView.Columns.Item(i).Visible = True Then
                QuantitySpecificationsDataGridView.Width = QuantitySpecificationsDataGridView.Width + QuantitySpecificationsDataGridView.Columns.Item(i).Width
            End If
        Next

        If QuantitySpecificationsDataGridView.Width > Me.Width Then
            QuantitySpecificationsDataGridView.Width = Me.Width - 100
        Else
            QuantitySpecificationsDataGridView.Width = QuantitySpecificationsDataGridView.Width + 20
        End If
        QuantitySpecificationsDataGridView.Width = QuantitySpecificationsDataGridView.Width

        Me.Left = (VehicleManagementSystemForm.Width - Me.Width) / 2
        Me.Location = New Point(Me.Location.X, 55)
        '===========================

        Dim RecordsDisplyed = QuantitySpecificationsRecordCount
        Dim FormLowPointFromGrid = 90
        If QuantitySpecificationsRecordCount > 27 Then
            RecordsDisplyed = 27
        Else
            RecordsDisplyed = QuantitySpecificationsRecordCount
        End If

        QuantitySpecificationsDataGridView.Height = (QuantitySpecificationsDataGridView.ColumnHeadersHeight) + (DataGridViewRowHeight * (RecordsDisplyed + 1))



    End Sub
    Private Sub QuantitySpecificationsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles QuantitySpecificationsDataGridView.RowEnter

        If e.RowIndex < 0 Then Exit Sub
        If QuantitySpecificationsRecordCount = 0 Then Exit Sub

        CurrentQuantitySpecificationsDataGridViewRow = e.RowIndex

        CurrentQuantitySpecificationsID = QuantitySpecificationsDataGridView.Item("QuantitySpecificationsID_Autonumber", CurrentQuantitySpecificationsDataGridViewRow).Value
    End Sub

    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        '      RegisterPartsSpecificationsChanges()()
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub
    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        If AChangeInPartNumberSpecificationOccured() Then
            RegisterPartNumberSpecificationChanges()
        Else
            If AChangeInPartSpecificationsOccured() Then
                RegisterPartsSpecificationsChanges()
            End If
        End If
        If BackToEditMode Then Exit Sub
        SaveToolStripMenuItem.Visible = False
        PartNumberSpecificationTextBox.Text = ""
        ProductPartSpecificationsTextBox.Text = ""
        PartSpecificationsDetailsGroup.Visible = False
    End Sub
    Private Function AChangeInPartNumberSpecificationOccured()
        If CurrentPartNumberSpecificationID = -1 Then
            If IsNotEmpty(PartNumberSpecificationTextBox.Text) Then Return True
        Else
            If TheseAreNotEqual(PartNumberSpecificationTextBox.Text, ProductsPartsSpecificationsDataGridView.Item("PartNumber_ShortText25", CurrentPartsSpecificationsDataGridViewRow).Value) Then Return True
        End If
        Return False
    End Function
    Private Sub RegisterPartNumberSpecificationChanges()
        If MsgBox("Continue saving  Part Number specification ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            If MsgBox("Discard your part number specification changes ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                PartNumberSpecificationTextBox.SelectAll()
                Exit Sub
            End If
        End If

        MySelection = " SELECT * FROM PartNumbersSpecificationsTable WHERE PartNumberSpecifications_ShortText30 = " &
                                                            InQuotes(PartNumberSpecificationTextBox.Text)
        JustExecuteMySelection()

        If RecordCount > 0 Then
            If CurrentPartNumberSpecificationID = -1 Then
                Dim r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
                Dim xxx = r("PartNUmbersSpecificationID_AutoNumber")
                PartNumberSpecificationsGroupBox.Visible = True
                MsgBox(PartNumberSpecificationTextBox.Text & "ALREADY EXIST!")
            Else
                UpdatePartNumberSpecifications()
            End If
        Else
            InsertNewPartNumberSpecification()
        End If
        FillPartNumberSpecificationsDataGridView()
    End Sub
    Private Sub UpdatePartNumberSpecifications()
        'UPDATE LIST OF ALL PART NUMBER SPWCIFICATIONS
        Dim RecordFilter = " WHERE PartNUmbersSpecificationID_AutoNumber = " & CurrentPartNumberSpecificationID.ToString
        Dim SetCommand = " SET MasterCodeBookID_LongInteger = " & CurrentMasterCodeBookID.ToString & "," &
                          " PartNumberSpecifications_ShortText30 = " & InQuotes(PartNumberSpecificationTextBox.Text)
        UpdateTable("PartNumbersSpecificationsTable", SetCommand, RecordFilter)
    End Sub
    Private Sub InsertNewPartNumberSpecification()
        'insert into the LIST OF ALL PART NUMBER SPWCIFICATIONS
        Dim FieldsToUpdate = "  MasterCodeBookID_LongInteger, " &
                             "  PartNumberSpecifications_ShortText30 "

        Dim FieldsData = CurrentMasterCodeBookID.ToString & ",  " &
                         InQuotes(PartNumberSpecificationTextBox.Text)

        CurrentPartNumberSpecificationID = InsertNewRecord("PartNumbersSpecificationsTable", FieldsToUpdate, FieldsData)
    End Sub

    Private Sub RegisterPartsSpecificationsChanges()
        If MsgBox("Continue saving  Part specification ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            If MsgBox("Discard your Part specification changes ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                ProductPartSpecificationsTextBox.SelectAll()
                Exit Sub
            End If
        End If

        MySelection = " SELECT * FROM PartsSpecificationsTable WHERE PartSpecifications_ShortText255 = " & InQuotes(ProductPartSpecificationsTextBox.Text) &
            " AND MasterCodeBookID_LongInteger = " & CurrentMasterCodeBookID.ToString
        JustExecuteMySelection()
        If RecordCount > 0 Then
            UpdatePartsSpecifications()
        Else
            InsertNewPartsSpecification()
        End If

        FillPartsSpecificationsDataGridView()
    End Sub
    Private Sub UpdatePartsSpecifications()
        'UPDATE LIST OF ALL Parts SPECIFICATIONS
        Dim RecordFilter = " WHERE PartsSpecificationID_AutoNumber = " & CurrentPartsSpecificationsID.ToString
        Dim SetCommand = " SET MasterCodeBookID_LongInteger = " & CurrentMasterCodeBookID.ToString & "," &
                          " PartsSpecifications_ShortText255 = " & InQuotes(ProductPartSpecificationsTextBox.Text)
        UpdateTable("PartsSpecificationsTable", SetCommand, RecordFilter)
    End Sub
    Private Sub InsertNewPartsSpecification()
        'insert into the LIST OF ALL Parts SPWCIFICATIONS
        Dim FieldsToUpdate = "  MasterCodeBookID_LongInteger, " &
                             "  PartSpecifications_ShortText255 "

        Dim FieldsData = CurrentMasterCodeBookID.ToString & ",  " &
                         InQuotes(ProductPartSpecificationsTextBox.Text)

        CurrentPartNumberSpecificationID = InsertNewRecord("PartsSpecificationsTable", FieldsToUpdate, FieldsData)
    End Sub

    Private Function AChangeInQuantitySpecificationsOccured()
        If CurrentPartsSpecificationsDataGridViewRow > -1 Then
            If TheseAreNotEqual(SpecifiedQuantityTextBox.Text, ProductsPartsSpecificationsDataGridView.Item("SpecifiedQuantity_Double", CurrentPartsSpecificationsDataGridViewRow).Value) Then Return True
            If TheseAreNotEqual(SpecifiedUnitTextBox.Text, ProductsPartsSpecificationsDataGridView.Item("SpecifiedUnit_ShortText3", CurrentPartsSpecificationsDataGridViewRow).Value) Then Return True
        Else
            If IsNotEmpty(SpecifiedQuantityTextBox.Text) Then Return True
            If IsNotEmpty(SpecifiedUnitTextBox.Text) Then Return True
        End If
        Return False
    End Function
    Private Function AChangeInPartSpecificationsOccured()
        If CurrentPartsSpecificationsDataGridViewRow > -1 Then
            If TheseAreNotEqual(ProductPartSpecificationsTextBox.Text, ProductsPartsSpecificationsDataGridView.Item("PartSpecifications_ShortText255", CurrentPartsSpecificationsDataGridViewRow).Value) Then Return True
        Else
            If IsNotEmpty(ProductPartSpecificationsTextBox.Text) Then Return True
        End If
        Return False
    End Function
    Private Sub RegisterPartSpecificationsChanges()
        If MsgBox("Would you like to update Part specifications for this part ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            If MsgBox("Disregard your part specifications changes ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                ProductPartSpecificationsTextBox.SelectAll()
                BackToEditMode = True
                Exit Sub
            End If
        End If
        MySelection = " Select top 1 * FROM PartsSpecificationsTable WHERE CodeVehicleID_LongInteger = " & CurrentCodeVehicleID &
                        " AND PartSpecifications_ShortText255 = " & ProductPartSpecificationsTextBox.Text
        JustExecuteMySelection()
        If RecordCount = 0 Then
            InsertNewPartSpecifications()
        Else
            UpdatePartSpecifications()
        End If
    End Sub
    Private Sub InsertNewPartSpecifications()
        Dim FieldsToUpdate = "  PartSpecifications_ShortText255 "

        Dim FieldsData = InQuotes(PartNumberSpecificationTextBox.Text)

        CurrentPartSpecificationsID = InsertNewRecord("PartsSpecificationsTable", FieldsToUpdate, FieldsData)
    End Sub
    Private Sub UpdatePartSpecifications()
        If MsgBox("About to replace previous Specifications, Continue ?", MsgBoxStyle.YesNo) = vbNo Then
            Exit Sub
        End If
        Dim RecordFilter = " WHERE PartsSpecificationsID_AutoNumber = " & CurrentPartSpecificationsID.ToString
        Dim SetCommand = " SET CodeVehicleID_LongInteger = " & CurrentCodeVehicleID.ToString & "," &
                          "PartSpecifications_ShortText255 = " & InQuotes(ProductPartSpecificationsTextBox.Text)
        UpdateTable("PartsSpecificationsTable", SetCommand, RecordFilter)
    End Sub
    Private Sub RegisterQuantitySpecificationsChanges()
        If MsgBox("Would you like to update Specifications for this part ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            If MsgBox("Disregard your part Specifications changes ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                ProductPartSpecificationsTextBox.SelectAll()
                BackToEditMode = True
                Exit Sub
            End If
        End If
        MySelection = " Select top 1 * FROM QuantitySpecificationsTable WHERE InformationsHeaderID_LongInteger = " & CurrentInformationsHeaderID.ToString &
                        " AND CodeVehicleID_LongInteger = " & CurrentCodeVehicleID.ToString
        JustExecuteMySelection()
        If RecordCount = 0 Then
            InsertNewQuantitySpecifications()
        Else
            UpdateQuantitySpecifications()
        End If
    End Sub
    Private Sub InsertNewQuantitySpecifications()
        Dim FieldsToUpdate = "  CodeVehicleID_LongInteger, " &
                             "  PartSpecifications_ShortText255 "

        Dim FieldsData = CurrentCodeVehicleID.ToString & ",  " &
                         InQuotes(ProductPartSpecificationsTextBox.Text)

        CurrentPartNumberSpecificationID = InsertNewRecord("PartsSpecificationsTable", FieldsToUpdate, FieldsData)
    End Sub
    Private Sub UpdateQuantitySpecifications()
        If MsgBox("About to replace previous Specifications, Continue ?", MsgBoxStyle.YesNo) = vbNo Then
            Exit Sub
        End If
        Dim RecordFilter = " WHERE PartsSpecificationID_AutoNumber = " & CurrentPartSpecificationsID.ToString
        Dim SetCommand = " SET CodeVehicleID_LongInteger = " & CurrentCodeVehicleID.ToString & "," &
                          "PartSpecifications_ShortText255 = " & InQuotes(ProductPartSpecificationsTextBox.Text)
        UpdateTable("PartsSpecificationsTable", SetCommand, RecordFilter)
    End Sub
    Private Sub SelectPartsSpecificationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectPartSpecificationsToolStripMenuItem.Click
        Select Case CallingForm.Name
            Case "ProductsPartsForm"
                ProductsPartsForm.ProductSpecificationTextBox.Text =
                    ProductsPartsSpecificationsDataGridView.Item("PartSpecifications_ShortText255", CurrentPartsSpecificationsDataGridViewRow).Value

                Tunnel1 = "Tunnel2IsPartsSpecificationsID"
                Tunnel2 = CurrentPartsSpecificationsID
            Case "RequestPartsForm"
                'HERE WE HAVE TO DETERMINE WHAT IS REQUESTED FOR
                'AND FOR EACH
                '   WE HAVE 2 MODES   - 1 SELECTING AN SPECIFICATION FROM ALL THE LISTINGS FOR ALL SPECS FOR THE PART
                '   AND                      2 SELECTING AN SPECIFICATION FROM THE SPECIFICATION SPECIFIC FOR THE CAR MODEL
                '   AND CAN BE DETERMINED BY 
                If ProductPartSpecificationsTextBox.Enabled Then ' PART TYPE SPECIFICATION IS REQESTED
                    If ProductsPartsSpecificationsGroupBox.Visible Then ' SELECT MEANS SELECTING FOR PARTICULAR SPECIFICATION FOR
                        ' THIS VEHICLE
                        If MsgBox("Continue Adding this as Specification for " & VehicleModelTextBox.Text, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            Dim FieldsToUpdate = "  CodeVehicleID_LongInteger, " &
                                         " PartsSpecificationID_LongInteger "
                            Dim FieldsData = CurrentCodeVehicleID.ToString & ", " &
                                     CurrentPartsSpecificationsID

                            CurrentCodeVehiclePartsSpecificationsRelationID = InsertNewRecord("CodeVehiclePartsSpecificationsRelationsTable", FieldsToUpdate, FieldsData)
                            FillCodeVehiclePartsSpecificationsRelations()
                            CodeVehiclePartsSpecificationsRelationsGroupBox.Enabled = True
                            ProductsPartsSpecificationsGroupBox.Visible = False
                            Exit Sub
                        End If
                    End If
                End If
                'RETURN THE SPECIFICATION
                Tunnel1 = "CodeVehiclePartsSpecificationsRelationID"
                Tunnel2 = CurrentCodeVehiclePartsSpecificationsRelationID


                RequestPartsForm.SpecificationsTextBox.Text = CodeVehicleSpecificationsRelationsDataGridView.Item("PartSpecifications_ShortText255", CurrentCodeVehiclePartsSpecificationsDataGridViewRow).Value
            Case Else
                MsgBox("Break, there has been chages here, UPDATING WILL BE I 2 MODES, CALLER SPECIFIES THE VEHICLE OR JUST SPECIFICATION IS FOR ALL PARTS")
                Stop
        End Select
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub
    Private Sub SpecifiedPartNumberTextBox_TextChanged(sender As Object, e As EventArgs) Handles PartNumberSpecificationTextBox.TextChanged

    End Sub

    Private Sub PartsSpecificationsTextBox_Click(sender As Object, e As EventArgs) Handles ProductPartSpecificationsTextBox.Click
        If ProductPartSpecificationsTextBox.ReadOnly = False Then Exit Sub
        EnablePartOPtions()
    End Sub
    Private Sub EnablePartOPtions()
        PartsSpecificationsHeaderMenuToolStripMenuItem.Visible = True
        If PartsSpecificationsRecordCount = 0 Then
            SelectPartSpecificationsToolStripMenuItem.Visible = False
            EditPartSpecificationsToolStripMenuItem.Visible = False
            RemovePartSpecificationsToolStripMenuItem.Visible = False
        Else
            SelectPartSpecificationsToolStripMenuItem.Visible = True
            EditPartSpecificationsToolStripMenuItem.Visible = True
            RemovePartSpecificationsToolStripMenuItem.Visible = True
        End If
    End Sub
    Private Sub EnablePartNUmberOPtions()
        PartNoSpecificationsItemToolStripMenuItem.Visible = True
        If PartNumberSpecificationsRecordCount = 0 Then
            SelectPartNumberToolStripMenuItem.Visible = False
            EditPartNumberToolStripMenuItem.Visible = False
            RemovePartNumberToolStripMenuItem.Visible = False
        Else
            SelectPartNumberToolStripMenuItem.Visible = True
            EditPartNumberToolStripMenuItem.Visible = True
            RemovePartNumberToolStripMenuItem.Visible = True
        End If
    End Sub
    Private Sub DisablePartsSpecificationsOPtions()
        PartsSpecificationsHeaderMenuToolStripMenuItem.Visible = False
        SelectPartSpecificationsToolStripMenuItem.Visible = False
        EditPartSpecificationsToolStripMenuItem.Visible = False
        RemovePartSpecificationsToolStripMenuItem.Visible = False
    End Sub
    Private Sub EnablePartSpecificationsOPtions()
        PartNoSpecificationsItemToolStripMenuItem.Visible = True
    End Sub
    Private Sub DisablePartSpecificationsOPtions()
        PartNoSpecificationsItemToolStripMenuItem.Visible = False
    End Sub
    Private Sub EnableQuantitySpecificationsOPtions()
        QuantitySpecificationsToolStripTextBox.Visible = True
    End Sub
    Private Sub DisableQuantitySpecificationsOPtions()
        QuantitySpecificationsToolStripTextBox.Visible = False
    End Sub

    Private Sub LinkAnSpecification()
        CurrentPartSpecificationsID = -1
        DisablePartsSpecificationsOPtions()
        SaveToolStripMenuItem.Visible = True
        ProductsPartsSpecificationsGroupBox.Visible = True
        ProductPartSpecificationsTextBox.ReadOnly = False
        ProductPartSpecificationsTextBox.Select()

    End Sub

    Private Sub AddPartsSpecificationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddPartSpecificationsToolStripMenuItem.Click
        'IF THE GENERAL SPECIFICATIONS FOR THE PART IS VISIBLE THEN WHAT HAS BEEN SELECTED WILL BE ADDED TO THE
        ' SPECIFIC CAR OTHERWISE INPUT AS NEW SPECIFICATION FOR THE PART AND SAVE IT AS A GENERAL SPECIFICATION FOR THE PART

        CurrentPartsSpecificationsID = -1
        ProductPartSpecificationsTextBox.Text = "type new specifications"
        ProductPartSpecificationsTextBox.ReadOnly = False
        ProductPartSpecificationsTextBox.SelectAll()
        SaveToolStripMenuItem.Visible = True
        '        PartSpecificationsDetailsGroup.Visible = True
    End Sub


    Private Sub RemovePartsSpecificationsToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles RemovePartSpecificationsToolStripMenuItem.Click
        Dim TablesToCheck = {"ProductsPartsTable"}
        If LinkExistsIn(TablesToCheck, "PartsSpecificationID_LongInteger", CurrentPartsSpecificationsID) Then
            MsgBox("Remove first the link in ProductsPartsTable before you can delete this")
            Exit Sub
        End If
        If MsgBox("NO link found, Are sure you want to delete this specification ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        MySelection = " DELETE FROM PartsSpecificationsTable WHERE PartsSpecificationID_AutoNumber =  " & CurrentPartsSpecificationsID
        JustExecuteMySelection()
        FillPartsSpecificationsDataGridView()
    End Sub

    Private Sub SelectPartNumberToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectPartNumberToolStripMenuItem.Click
        If PartNumberSpecificationsGroupBox.Visible = True Then
            PartNumberSpecificationsGroupBox.Visible = False
            MySelection = " Select * FROM CodeVehiclePartNumbersSpecificationsRelationsTable WHERE PartNumbersSpecificationID_LongInteger = " & CurrentPartNumberSpecificationID &
                            " AND CodeVehicleID_LongInteger = " & CurrentCodeVehicleID.ToString
            CurrentPartNumberSpecificationID.ToString()
            JustExecuteMySelection()
            If RecordCount > 0 Then
                MsgBox("Selected Specification already in the list")
                Exit Sub
            End If
            Dim FieldsToUpdate = "  CodeVehicleID_LongInteger, " &
                             "  PartNumbersSpecificationID_LongInteger "

            Dim FieldsData = CurrentCodeVehicleID.ToString & ",  " &
                         CurrentPartNumberSpecificationID.ToString

            CurrentCodeVehiclePNSpecificationID = InsertNewRecord("CodeVehiclePartNumbersSpecificationsRelationsTable", FieldsToUpdate, FieldsData)
            CodeVehiclePNSpecificationsGroupBox.Enabled = True
            FillCodeVehiclePNSpecificationsRelations()
        Else
            Tunnel1 = "Tunnel2IsCodeVehiclePNSpecificationID"
            Tunnel2 = CurrentCodeVehiclePNSpecificationID
            Select Case SavedCallingForm.Name
                Case "RequestPartsForm"
                    RequestPartsForm.PartNumberSpecificationTextBox.Text = CodeVehiclePNSpecificationsDataGridView.Item("PartNumberSpecifications_ShortText30", CurrentCodeVehiclePNSpecificationsDataGridViewRow).Value
            End Select
            DoCommonHouseKeeping(Me, SavedCallingForm)
        End If
    End Sub
    Private Sub AddPartNumberToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddPartNumberToolStripMenuItem.Click
        PartSpecificationsDetailsGroup.Visible = True
        CodeVehiclePNSpecificationsGroupBox.Enabled = False
        CurrentPartNumberSpecificationID = -1
        PartNumberSpecificationTextBox.ReadOnly = False
        PartNumberSpecificationTextBox.Enabled = True
        PartNumberSpecificationTextBox.Text = "type new part number specification"
        PartNumberSpecificationTextBox.SelectAll()
        SaveToolStripMenuItem.Visible = True
    End Sub
    Private Sub EditPartNumberToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditPartNumberToolStripMenuItem.Click
        PartNumberSpecificationTextBox.ReadOnly = False
        PartNumberSpecificationTextBox.SelectAll()
    End Sub
    Private Sub RemovePartNumberToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemovePartNumberToolStripMenuItem.Click
    End Sub
    Private Sub DeletePartNumberToolStripMenuItem_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub CopySpecificationToolStripTextBox_Click(sender As Object, e As EventArgs) Handles CopySpecificationToolStripTextBox.Click
        SpecificationsContextMenuStrip.Hide()
        Clipboard.SetText(ProductsPartsSpecificationsDataGridView.Item("PartSpecifications_ShortText255", CurrentPartsSpecificationsDataGridViewRow).Value)
    End Sub

    Private Sub PasteSpecificationToolStripTextBox_Click(sender As Object, e As EventArgs)
        ProductPartSpecificationsTextBox.Text = Clipboard.GetText()
    End Sub

    Private Sub EditPartSpecificationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditPartSpecificationsToolStripMenuItem.Click
        If MsgBox("Are you sure you want to change description ? ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        ProductPartSpecificationsTextBox.Text = ProductsPartsSpecificationsDataGridView.Item("PartSpecifications_ShortText255", CurrentPartsSpecificationsDataGridViewRow).Value
        If ProductsPartsSpecificationsGroupBox.Visible = False Then
            ProductsPartsSpecificationsGroupBox.Visible = True
        End If
        ProductPartSpecificationsTextBox.ReadOnly = False
        ProductPartSpecificationsTextBox.SelectAll()
        SaveToolStripMenuItem.Visible = True
        PartSpecificationsDetailsGroup.Visible = True
    End Sub

    Private Sub CodeVehiclePartsSpecificationsGroupBox_VisibleChanged(sender As Object, e As EventArgs) Handles CodeVehiclePartsSpecificationsRelationsGroupBox.VisibleChanged
        ' WHEN PRODUCT SPECIFICATION is visible/activated then CodeVehiclePartsSpecificationsRelationsGroupBox is deactivated and vice versa
        If CodeVehiclePartsSpecificationsRelationsGroupBox.Visible Then
            ProductsPartsSpecificationsGroupBox.Visible = False
        Else
            ProductsPartsSpecificationsGroupBox.Visible = True
        End If
    End Sub

End Class