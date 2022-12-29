Public Class GenerateRecordsForm
    Private CurrentOriginalExcelRecordID As Integer = -1
    Private CurrentOriginalExcelRecordRow As Integer = -1
    Private CurrentWorkOrderID As Integer = -1
    Private CurrentJobID As Integer = -1
    Private CurrentConcernID As Integer = -1
    Private CurrentProductPartID As Integer = -1
    Private CurrentBrandID As Integer = -1
    Private CurrentServicedVehicleID As Integer = -1
    Private CurrentServiceProviderID As Integer = -1
    Private currentSupplierID As Integer = -1
    Private DisplayCounter = 0

    Private OriginalExcelRecordsFieldsToSelect = ""
    Private OriginalExcelRecordsTablesLinks = ""
    Private OriginalExcelRecordsSelectionFilter = ""
    Private OriginalExcelRecordsSelectionFilterSaved = ""
    Private OriginalExcelRecordsSelectionOrder = ""

    Private OriginalExcelRecordsCount = RecordCount
    Private OriginalExcelRecordsDataGridViewInitialized = False
    Private OriginalExcelRecordsDataGridViewAlreadyFormated = False

    Private MeLocationX As Integer
    Private MeLocationY As Integer = 50

    Dim ServiceDate_DateTime As Date
    Dim VehicleMilage_Integer As Integer
    Dim NewWorkOrderID = ""
    Dim TypeOfThisRecord = 0

    Private Sub GenerateRecordsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        OriginalExcelRecordsDataGridView.ScrollBars = DataGridViewTriState.True
        FillOriginalExcelRecordDataGridView()
        'SET AND RESET ALL ENTRY PARAMETERS
        ResetTunnels()
        Dim MyDisplacement = 25
        Me.Size = My.Computer.Screen.WorkingArea.Size
        Me.Size = New Size(Me.Size.Width, Me.Size.Height - MyDisplacement)
        Me.Size = VehicleManagementSystemForm.Size
        Me.Location = New System.Drawing.Point(0, MyDisplacement)
        Me.Width = VehicleManagementSystemForm.Width
        Me.Left = VehicleManagementSystemForm.Left
    End Sub
    Private Sub FillOriginalExcelRecordDataGridView()
        Dim OriginalExcelRecordsFieldsToSelect = " Select " &
                                                  " OriginalExcelRecordTable.RecordType, " &
                                                  " OriginalExcelRecordTable.WorkOrderNumber_ShortText12, " &
                                                  " OriginalExcelRecordTable.last_service_date, " &
                                                  " OriginalExcelRecordTable.latest_service_milage, " &
                                                  " OriginalExcelRecordTable.codeSaved, " &
                                                  " OriginalExcelRecordTable.code, " &
                                                  " OriginalExcelRecordTable.SupplierCode, " &
                                                  " OriginalExcelRecordTable.description, " &
                                                  " OriginalExcelRecordTable.productdescription, " &
                                                  " OriginalExcelRecordTable.QTY, " &
                                                  " OriginalExcelRecordTable.UnitName, " &
                                                  " OriginalExcelRecordTable.price, " &
                                                  " OriginalExcelRecordTable.ORIGINALCODE, " &
                                                  " OriginalExcelRecordTable.brand, " &
                                                  " OriginalExcelRecordTable.madein, " &
                                                  " OriginalExcelRecordTable.SUPPLIER, " &
                                                  " OriginalExcelRecordTable.ServiceProvider, " &
                                                  " OriginalExcelRecordTable.VehicleCode, " &
                                                  " OriginalExcelRecordTable.productlink1, " &
                                                  " OriginalExcelRecordTable.productlink2, " &
                                                  " OriginalExcelRecordTable.productlink3, " &
                                                  " OriginalExcelRecordTable.WorkOrderID_LongInteger, " &
                                                  " OriginalExcelRecordTable.MainSystemCode_ShortText1, " &
                                                  " OriginalExcelRecordTable.MasterCodeBookID_LongInteger, " &
                                                  " OriginalExcelRecordTable.OriginalID_AutoNumber "

        '                                                  " OriginalExcelRecordTable., " &



        Dim OriginalExcelRecordsLinks = "From OriginalExcelRecordTable " &
                                             " LEFT Join WorkOrdersTable On OriginalExcelRecordTable.WorkOrderNumber_ShortText12 = WorkOrdersTable.WorkOrderNumber_ShortText12 "
        Dim UpdatedSelectionOrder = " ORDER BY OriginalExcelRecordTable.last_service_date ASC, OriginalExcelRecordTable.latest_service_milage ASC "

        MySelection = OriginalExcelRecordsFieldsToSelect & OriginalExcelRecordsLinks & UpdatedSelectionOrder

        If NoRecordFound() Then
            Dim xxx = 10
        End If

        OriginalExcelRecordsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        OriginalExcelRecordsCount = RecordCount

        If Not OriginalExcelRecordsDataGridViewAlreadyFormated Then
            FormatOriginalExcelRecordDataGridView()
        End If

    End Sub

    Private Sub FormatOriginalExcelRecordDataGridView()
        OriginalExcelRecordsDataGridViewAlreadyFormated = True
        '       OriginalExcelRecordsDataGridView.Width = 0
        Dim DoNotDisplayFields = Space(30)


        For i = 0 To OriginalExcelRecordsDataGridView.Columns.GetColumnCount(0) - 1
            If InStr(DoNotDisplayFields, OriginalExcelRecordsDataGridView.Columns.Item(i).HeaderText & "/") > 0 Then
                OriginalExcelRecordsDataGridView.Columns.Item(i).Visible = False
            End If

            If OriginalExcelRecordsDataGridView.Columns.Item(i).Visible = True Then
                '               OriginalExcelRecordsDataGridView.Width = OriginalExcelRecordsDataGridView.Width + OriginalExcelRecordsDataGridView.Columns.Item(i).Width
            End If
            Select Case OriginalExcelRecordsDataGridView.Columns.Item(i).HeaderText
                Case "WorkOrderNumber_ShortText12"
                    OriginalExcelRecordsDataGridView.Columns.Item(i).HeaderText = "WORK ORDER No."
                    OriginalExcelRecordsDataGridView.Columns.Item(i).Width = 120
                Case "last_service_date"
                    OriginalExcelRecordsDataGridView.Columns.Item(i).HeaderText = "Date"
                    OriginalExcelRecordsDataGridView.Columns.Item(i).Width = 80
                    OriginalExcelRecordsDataGridView.Columns(i).DefaultCellStyle.Format = "yy-MM-dd"
                Case "latest_service_milage"
                    OriginalExcelRecordsDataGridView.Columns.Item(i).HeaderText = "milage"
                    OriginalExcelRecordsDataGridView.Columns.Item(i).Width = 80
                Case "description"
                    OriginalExcelRecordsDataGridView.Columns.Item(i).Width = 440
                Case "QTY"
                    OriginalExcelRecordsDataGridView.Columns.Item(i).HeaderText = "qty"
                    OriginalExcelRecordsDataGridView.Columns.Item(i).Width = 40
                Case "UnitName"
                    OriginalExcelRecordsDataGridView.Columns.Item(i).HeaderText = "unit"
                    OriginalExcelRecordsDataGridView.Columns.Item(i).Width = 40
                Case "price"
                    OriginalExcelRecordsDataGridView.Columns.Item(i).HeaderText = "price"
                    OriginalExcelRecordsDataGridView.Columns.Item(i).Width = 80
            End Select
        Next
        If OriginalExcelRecordsDataGridView.Width > VehicleManagementSystemForm.Width Then
            '           OriginalExcelRecordsDataGridView.Width = VehicleManagementSystemForm.Width - 20
        Else
            '           OriginalExcelRecordsDataGridView.Width = OriginalExcelRecordsDataGridView.Width + 20
        End If

        OriginalExcelRecordsDataGridView.Top = 30
        Me.Location = New Point(Me.Location.X, 55)
        OriginalExcelRecordsDataGridView.Left = Me.Left
        OriginalExcelRecordsDataGridView.Width = Me.Width

    End Sub

    Private Sub GenerateWorkOrderNumber()
        MsgBox("GENERATING WORK ORDER NUMBER")
        Dim RowCount As Integer = RecordFinderDbControls.MyAccessDbDataTable.Rows.Count
        Dim WorkOrderIsRequired = False
        Dim SavedWorkOrder = ""

        For CurrentOriginalExcelRecordRow = 0 To RowCount - 1
            'RecordType Number                          1 -header 2-job 3-part of OriginalExcelRecordTable
            CurrentOriginalExcelRecordID = OriginalExcelRecordsDataGridView("OriginalID_AutoNumber", CurrentOriginalExcelRecordRow).Value

            CurrentWorkOrderID = -1
            CurrentConcernID = -1
            CurrentJobID = -1
            CurrentProductPartID = -1
            currentSupplierID = -1
            CurrentBrandID = -1
            CurrentServicedVehicleID = -1
            CurrentServiceProviderID = -1

            TypeOfThisRecord = 1

            If ThisIsAPart() Then
                TypeOfThisRecord = 3
            Else
                If ThisIsAJob() Then
                    TypeOfThisRecord = 2
                Else
                    ' THIS Is A HEADER
                    TypeOfThisRecord = 1
                End If
            End If


            If TypeOfThisRecord = 1 Then
                InsertNewHeader()
                Continue For
            End If

            NewWorkOrderID = GetNewWorkOrderID(OriginalExcelRecordsDataGridView("last_service_date", CurrentOriginalExcelRecordRow).Value, OriginalExcelRecordsDataGridView("latest_service_milage", CurrentOriginalExcelRecordRow).Value)
            NewWorkOrderID = NewWorkOrderID & Space(12 - Len(Trim(NewWorkOrderID)))

            If IsNotEmpty(OriginalExcelRecordsDataGridView.Item("brand", CurrentOriginalExcelRecordRow).Value) Then
                InsertNewBrand(OriginalExcelRecordsDataGridView.Item("brand", CurrentOriginalExcelRecordRow).Value)
            End If

            If IsNotEmpty(OriginalExcelRecordsDataGridView("SUPPLIER", CurrentOriginalExcelRecordRow).Value) Then
                InsertNewSupplier(OriginalExcelRecordsDataGridView("SUPPLIER", CurrentOriginalExcelRecordRow).Value)
            End If

            If IsNotEmpty(OriginalExcelRecordsDataGridView("ServiceProvider", CurrentOriginalExcelRecordRow).Value) Then
                InsertNewServiceProvider(OriginalExcelRecordsDataGridView("ServiceProvider", CurrentOriginalExcelRecordRow).Value)
            End If

            If Trim(NewWorkOrderID) = "" Then
                NewWorkOrderID = "NoData" & OriginalExcelRecordsDataGridView("VehicleCode", CurrentOriginalExcelRecordRow).Value & CurrentServiceProviderID.ToString & currentSupplierID.ToString
            Else
                NewWorkOrderID = NewWorkOrderID.Substring(0, 6) & OriginalExcelRecordsDataGridView("VehicleCode", CurrentOriginalExcelRecordRow).Value & NewWorkOrderID.Substring(6)
            End If
            InsertNewWorkOrder()
            InsertNewWorkOrderItem() ' CurrentWorkOrderID is now available for others to use 
            ' THEN UPDATE THIS TABLE AT THE END


            Select Case TypeOfThisRecord
                Case 1
                    InsertNewHeader()
                    Continue For
                Case 2
                Case 3
                    InsertNewProductPart()
            End Select
            If OriginalExcelRecordsDataGridView("VehicleCode", CurrentOriginalExcelRecordRow).Value <> 9 Then
                InsertNewJob()
                InsertNewConcern()
            End If
            UpdateWorkOrderRelations()
            UpdateOriginalExcelRecordTable()
        Next
        MySelection = "Select OriginalID_AutoNumber, " &
                             " WorkOrderNumber_ShortText12, " &
                             " last_service_date, " &
                             " latest_service_milage " &
                      "From   originalExcelRecordTable "
        RecordFinderDbControls.MyDbCommand(MySelection)
    End Sub

    Private Function ThisIsAPart()
        If IsEmpty(OriginalExcelRecordsDataGridView("QTY", CurrentOriginalExcelRecordRow).Value) Then
            If IsEmpty(OriginalExcelRecordsDataGridView("price", CurrentOriginalExcelRecordRow).Value) Then
                Return False
            End If
        End If
        Return True
    End Function

    Private Function ThisIsAJob()
        If IsEmpty(OriginalExcelRecordsDataGridView("last_service_date", CurrentOriginalExcelRecordRow).Value) Then
            If IsEmpty(OriginalExcelRecordsDataGridView("latest_service_milage", CurrentOriginalExcelRecordRow).Value) Then
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub UpdateOriginalExcelRecordTable()

        MySelection = " UPDATE originalExcelRecordTable SET " &
                     "  WorkOrderNumber_ShortText12 = " & Chr(34) & NewWorkOrderID & Chr(34) & ", " &
                     "  RecordType = " & TypeOfThisRecord.ToString & ", " &
                     " WorkOrderID_LongInteger = " & CurrentWorkOrderID.ToString & ", " &
                     " ProductPartID_LongInteger = " & CurrentProductPartID.ToString & ", " &
                      " WorkOrderItemID_LongInteger = " & CurrentWorkOrderID.ToString & ", " &
                      " SupplierID_LongInteger = " & currentSupplierID.ToString &
                    " WHERE  OriginalID_AutoNumber = " & CurrentOriginalExcelRecordID.ToString
        JustExecuteMySelection()
    End Sub

    Private Sub InsertNewWorkOrder()
        MySelection = "SELECT * " &
                       " FROM WorkOrdersTable " &
                      " WHERE trim(WorkOrderNumber_ShortText12) = " & Chr(34) & NewWorkOrderID & Chr(34)

        Dim r As DataRow
        If Not NoRecordFound() Then
            r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
            CurrentWorkOrderID = r("WorkOrderID_AutoNumber")
            Exit Sub
        End If

        'record was first tested if it already exist in the workorder table
        Dim CurrentServicedVehicleID = -1
        If IsDBNull(VehicleMilage_Integer) Then
            VehicleMilage_Integer = 0
        Else
            VehicleMilage_Integer = Int(Val(Replace(VehicleMilage_Integer, ",", "")))
        End If
        Select Case OriginalExcelRecordsDataGridView("VehicleCode", CurrentOriginalExcelRecordRow).Value
            Case 1
                CurrentServicedVehicleID = 2   ' 95
            Case 2
                CurrentServicedVehicleID = 7    ' rav4
            Case 3
                CurrentServicedVehicleID = 1    ' civic
            Case 4
                CurrentServicedVehicleID = 4    ' 02
            Case 5
                CurrentServicedVehicleID = 3    ' 98
            Case 6
                CurrentServicedVehicleID = 17    ' PILOT

        End Select


        Dim FieldsToUpdate = " ( " &
                    " WorkOrderNumber_ShortText12, " &
                    " ServicedVehicleID_LongInteger "


        Dim ReplacementData = "(" &
                    Chr(34) & NewWorkOrderID & Chr(34) & ", " &
                    Str(CurrentServicedVehicleID)

        If IsNotEmpty(ServiceDate_DateTime.ToString) Then
            FieldsToUpdate = FieldsToUpdate & ", ServiceDate_DateTime "
            ReplacementData = ReplacementData & ", " & Chr(34) & ServiceDate_DateTime.ToString & Chr(34)
        End If

        If IsNotEmpty(VehicleMilage_Integer.ToString) Then
            FieldsToUpdate = FieldsToUpdate & ", VehicleMilage_Integer "
            ReplacementData = ReplacementData & ", " & Chr(34) & VehicleMilage_Integer.ToString & Chr(34)
        End If
        FieldsToUpdate = FieldsToUpdate & ")"
        ReplacementData = ReplacementData & ")"
        MySelection = "INSERT INTO WorkOrdersTable  " & FieldsToUpdate & " VALUES " & ReplacementData
        JustExecuteMySelection()

        MySelection = "SELECT * " &
                       " FROM WorkOrdersTable " &
                      " WHERE trim(WorkOrderNumber_ShortText12) = " & Chr(34) & NewWorkOrderID & Chr(34)

        If NoRecordFound() Then Dim CurrentWorkOrderID = -1
        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        CurrentWorkOrderID = r("WorkOrderID_AutoNumber")
    End Sub

    Private Sub InsertNewWorkOrderItem()
        Dim tmpQty_Integer = 0
        If IsNotEmpty(OriginalExcelRecordsDataGridView("QTY", CurrentOriginalExcelRecordRow).Value) Then
            tmpQty_Integer = OriginalExcelRecordsDataGridView("QTY", CurrentOriginalExcelRecordRow).Value
        End If
        Dim tmpPrice_Currency = OriginalExcelRecordsDataGridView("price", CurrentOriginalExcelRecordRow).Value
        If IsEmpty(tmpPrice_Currency) Then
            tmpPrice_Currency = 0
        End If

        MySelection = "SELECT * " &
                      " FROM WorkOrderRelationsTable " &
                      " WHERE WorkOrderID_LongInteger = " & CurrentWorkOrderID.ToString &
                      " AND ProductPartID_LongInteger = " & CurrentProductPartID.ToString &
                      " AND Price_Currency = " & tmpPrice_Currency.ToString &
                      " AND SupplierID_LongInteger = " & currentSupplierID.ToString &
                      " AND Qty_Integer = " & tmpQty_Integer.ToString

        Dim r As DataRow
        If Not NoRecordFound() Then
            r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
            CurrentWorkOrderID = r("WorkOrderRelationID_AutoNumber")
            Exit Sub
        End If

        Dim FieldsToUpdate = " ( " &
                    " WorkOrderID_LongInteger, " &          '1
                    " ConcernID_LongInteger, " &        '2
                    " InformationsHeaderID_LongInteger, " &                '3
                    " ProductPartID_LongInteger, " &        '4
                    " SupplierID_LongInteger, " &           '5
                    " Qty_Integer, " &                      '6
                    " Price_Currency, " &                   '7
                    " OriginalID_LongInteger " &            '8
                    ") "

        Dim ReplacementData = "(" &
                   CurrentWorkOrderID.ToString & ", " &      '1   
                    CurrentConcernID.ToString & ", " &        '2
                    CurrentJobID.ToString & ", " &            '3
                    CurrentProductPartID.ToString & ", " &    '4
                    currentSupplierID.ToString & ", " &       '5
                    tmpQty_Integer.ToString & ", " &          '6
                    tmpPrice_Currency.ToString & ", " &       '7
                    CurrentOriginalExcelRecordID.ToString &   '8
                    ") "

        MySelection = "INSERT INTO WorkOrderRelationsTable  " & FieldsToUpdate & " VALUES " & ReplacementData

        JustExecuteMySelection()

        MySelection = "SELECT * " &
                      " FROM WorkOrderRelationsTable " &
                      " WHERE WorkOrderID_LongInteger = " & CurrentWorkOrderID.ToString &
                      " AND ProductPartID_LongInteger = " & CurrentProductPartID.ToString &
                      " AND Qty_Integer = " & tmpQty_Integer.ToString &
                      " AND Price_Currency = " & tmpPrice_Currency.ToString &
                      " AND SupplierID_LongInteger = " & currentSupplierID.ToString

        JustExecuteMySelection()
        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        CurrentWorkOrderID = r("WorkOrderRelationID_AutoNumber")

    End Sub
    Private Sub UpdateWorkOrderRelations()

        MySelection = " UPDATE WorkOrderRelationsTable SET " &
                     "  WorkOrderID_LongInteger = " & CurrentWorkOrderID.ToString & ", " &
                     " ConcernID_LongInteger = " & CurrentConcernID.ToString & ", " &
                     " InformationsHeaderID_LongInteger = " & CurrentJobID.ToString & ", " &
                     " ProductPartID_LongInteger = " & CurrentProductPartID.ToString & ", " &
                     " SupplierID_LongInteger = " & currentSupplierID.ToString & ", " &
                       " OriginalID_LongInteger = " & CurrentOriginalExcelRecordID.ToString &
                    " WHERE WorkOrderRelationID_AutoNumber = " & CurrentWorkOrderID.ToString


        JustExecuteMySelection()

        MySelection = "SELECT * " &
                      " FROM WorkOrderRelationsTable " &
                      " WHERE WorkOrderRelationID_AutoNumber = " & CurrentWorkOrderID.ToString


        JustExecuteMySelection()
        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        CurrentWorkOrderID = r("WorkOrderRelationID_AutoNumber")

    End Sub

    Private Sub InsertNewBrand(PassedBrand)

        MySelection = "Select * " &
                      "From BrandTable " &
                      " WHERE trim(BrandName_ShortText20) = " & Chr(34) & Trim(PassedBrand) & Chr(34)

        Dim r As DataRow
        If Not NoRecordFound() Then
            r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
            CurrentBrandID = r("BrandID_Autonumber")
            Exit Sub
        End If


        Dim FieldsToUpdate = " ( " & "BrandName_ShortText20 )"

        Dim ReplacementData = "(" & Chr(34) & PassedBrand & Chr(34) & ") "

        MySelection = "INSERT INTO BrandTable   " & FieldsToUpdate & " VALUES " & ReplacementData
        JustExecuteMySelection()

        MySelection = "Select * " &
                      "From BrandTable " &
                      " WHERE trim(BrandName_ShortText20) = " & Chr(34) & Trim(PassedBrand) & Chr(34)

        JustExecuteMySelection()
        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        CurrentBrandID = r("BrandID_Autonumber")

    End Sub
    Private Sub InsertNewSupplier(PassedSupplier)
        MySelection = "Select * " &
                      "From SuppliersTable " &
                      " WHERE trim(SupplierName_ShortText35) = " & Chr(34) & Trim(PassedSupplier) & Chr(34)

        Dim r As DataRow
        If Not NoRecordFound() Then
            r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
            currentSupplierID = r("SupplierID_AutoNumber")
            Exit Sub
        End If


        Dim FieldsToUpdate = " ( " &
                            "SupplierName_ShortText35)"

        Dim ReplacementData = "(" &
            Chr(34) & PassedSupplier & Chr(34) & ") "

        MySelection = "INSERT INTO SuppliersTable  " & FieldsToUpdate & " VALUES " & ReplacementData
        JustExecuteMySelection()

        MySelection = "Select * " &
                      "From SuppliersTable " &
                      " WHERE trim(SupplierName_ShortText35) = " & Chr(34) & Trim(PassedSupplier) & Chr(34)

        JustExecuteMySelection()
        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        currentSupplierID = r("SupplierID_AutoNumber")

    End Sub
    Private Sub InsertNewServiceProvider(PassedServiceProvider)
        MySelection = "Select * " &
                      "From ServiceProviderTable " &
                      " WHERE trim(ServiceProvider_Short_Text35) = " & Chr(34) & Trim(PassedServiceProvider) & Chr(34)

        Dim r As DataRow
        If Not NoRecordFound() Then
            r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
            CurrentServiceProviderID = r("ServiceProviderID_Autonumber")
            Exit Sub
        End If


        Dim FieldsToUpdate = " ( " &
                            "ServiceProvider_Short_Text35)"

        Dim ReplacementData = "(" &
            Chr(34) & PassedServiceProvider & Chr(34) & ") "

        MySelection = "INSERT INTO ServiceProviderTable  " & FieldsToUpdate & " VALUES " & ReplacementData
        JustExecuteMySelection()

        MySelection = "Select * " &
                      "From ServiceProviderTable " &
                      " WHERE trim(ServiceProvider_Short_Text35) = " & Chr(34) & Trim(PassedServiceProvider) & Chr(34)

        JustExecuteMySelection()
        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        CurrentServiceProviderID = r("ServiceProviderID_AutoNumber")


    End Sub
    Private Sub InsertNewProductHyperlink(PassedproductPart_Hyperlink)
        Dim testPos = InStr(PassedproductPart_Hyperlink, " ")
        If testPos > 0 Then
            Exit Sub
        End If
        MySelection = "Select * " &
                      "From ProductsPartsHyperLinksTable " &
                      " WHERE trim(productPart_Hyperlink) = " & Chr(34) & Trim(PassedproductPart_Hyperlink) & Chr(34)

        If Not NoRecordFound() Then
            Exit Sub
        End If


        Dim FieldsToUpdate = " ( " &
                            "ProductPartID_LongInteger, " &
                            "productPart_Hyperlink" & ") "

        Dim ReplacementData = " (" &
            CurrentProductPartID.ToString & ", " &
            Chr(34) & PassedproductPart_Hyperlink & Chr(34) & ") "

        MySelection = "INSERT INTO ProductsPartsHyperLinksTable  " & FieldsToUpdate & " VALUES " & ReplacementData
        JustExecuteMySelection()

    End Sub
    Private Sub InsertNewConcern()

        Dim tmpProductDescription_ShortText255 = ""
        If IsNotEmpty(OriginalExcelRecordsDataGridView.Item("description", CurrentOriginalExcelRecordRow).Value) Then
            tmpProductDescription_ShortText255 = OriginalExcelRecordsDataGridView.Item("description", CurrentOriginalExcelRecordRow).Value
            tmpProductDescription_ShortText255 = Replace(tmpProductDescription_ShortText255, Chr(34), " in")
        End If

        MySelection = "SELECT * " &
                       " FROM ConcernsTable " &
                      " WHERE trim(Concern_ShortText255) = " & Chr(34) & Trim(tmpProductDescription_ShortText255) & Chr(34)

        If RecordIsFound() Then
            r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
            CurrentConcernID = r("ConcernCodeID_AutoNumber")
            Exit Sub
        End If

        Dim tmpConcernTypeID_LongInteger = 0
        Dim tmpMasterCodeBookId_LongInteger = -1
        Dim tmpSource_Byte = 2


        Dim FieldsToUpdate = " (" &
                    " Concern_ShortText255, " &
                    " ConcernTypeID_LongInteger, " &
                    " MasterCodeBookId_LongInteger, " &
                    " Source_Byte " &
                    ") "

        Dim FieldsValue = "(" &
                    Chr(34) & tmpProductDescription_ShortText255 & Chr(34) & ", " &
                    tmpConcernTypeID_LongInteger.ToString & ", " &
                    tmpMasterCodeBookId_LongInteger.ToString & ", " &
                    tmpSource_Byte.ToString &
                    ") "

        MySelection = "INSERT INTO ConcernsTable  " & FieldsToUpdate & " VALUES " & FieldsValue

        JustExecuteMySelection()

    End Sub
    Private Sub InsertNewJob()

        Dim tmpProductCode_ShortText30Fld = ""
        If IsNotEmpty(OriginalExcelRecordsDataGridView.Item("Code", CurrentOriginalExcelRecordRow).Value) Then
            tmpProductCode_ShortText30Fld = OriginalExcelRecordsDataGridView.Item("Code", CurrentOriginalExcelRecordRow).Value
        End If

        Dim tmpProductDescription_ShortText255 = ""
        If IsNotEmpty(OriginalExcelRecordsDataGridView.Item("description", CurrentOriginalExcelRecordRow).Value) Then
            tmpProductDescription_ShortText255 = OriginalExcelRecordsDataGridView.Item("description", CurrentOriginalExcelRecordRow).Value
            tmpProductDescription_ShortText255 = Replace(tmpProductDescription_ShortText255, Chr(34), " in")
        End If

        MySelection = "SELECT * " &
                       " FROM HeaderInformationsTable " &
                      " WHERE trim(HeaderInformationCode_ShortText30) = " & Chr(34) & Trim(tmpProductCode_ShortText30Fld) & Chr(34) &
                      " AND trim(HeaderInformationDescription_ShortText255) = " & Chr(34) & Trim(tmpProductDescription_ShortText255) & Chr(34)

        If RecordIsFound() Then
            r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
            CurrentJobID = r("InformationsHeaderID_AutoNumber")
            Exit Sub
        End If

        Dim tmpConcernTypeID_LongInteger = 0
        Dim tmpMasterCodeBookId_LongInteger = -1
        Dim tmpSource_Byte = 1


        Dim FieldsToUpdate = " (" &
                    " HeaderInformationCode_ShortText30, " &
                    " HeaderInformationDescription_ShortText255, " &
                    " ConcernTypeID_LongInteger, " &
                    " MasterCodeBookId_LongInteger, " &
                    " Source_Byte " &
                    ") "

        Dim FieldsValue = "(" &
                    Chr(34) & tmpProductCode_ShortText30Fld & Chr(34) & ", " &
                    Chr(34) & tmpProductDescription_ShortText255 & Chr(34) & ", " &
                    tmpConcernTypeID_LongInteger.ToString & ", " &
                    tmpMasterCodeBookId_LongInteger.ToString & ", " &
                    tmpSource_Byte.ToString &
                    ") "



        MySelection = "INSERT INTO HeaderInformationsTable  " & FieldsToUpdate & " VALUES " & FieldsValue

        JustExecuteMySelection()

    End Sub
    Private Sub InsertNewHeader()
        Dim tmpProductCode_ShortText30Fld = ""
        If IsNotEmpty(OriginalExcelRecordsDataGridView.Item("Code", CurrentOriginalExcelRecordRow).Value) Then
            tmpProductCode_ShortText30Fld = OriginalExcelRecordsDataGridView.Item("Code", CurrentOriginalExcelRecordRow).Value
        End If

        Dim tmpProductDescription_ShortText250 = ""
        If IsNotEmpty(OriginalExcelRecordsDataGridView.Item("description", CurrentOriginalExcelRecordRow).Value) Then
            tmpProductDescription_ShortText250 = OriginalExcelRecordsDataGridView.Item("description", CurrentOriginalExcelRecordRow).Value
        End If

        Dim tmpMainSystemCode_ShortText1 = ""
        If IsNotEmpty(OriginalExcelRecordsDataGridView.Item("MainSystemCode_ShortText1", CurrentOriginalExcelRecordRow).Value) Then
            tmpMainSystemCode_ShortText1 = OriginalExcelRecordsDataGridView.Item("MainSystemCode_ShortText1", CurrentOriginalExcelRecordRow).Value
        End If

        Dim tmpMasterCodeBookID_LongInteger = -1
        If IsNotEmpty(OriginalExcelRecordsDataGridView.Item("MasterCodeBookID_LongInteger", CurrentOriginalExcelRecordRow).Value) Then
            tmpMasterCodeBookID_LongInteger = OriginalExcelRecordsDataGridView.Item("MasterCodeBookID_LongInteger", CurrentOriginalExcelRecordRow).Value
        End If

        MySelection = "SELECT * " &
                       " FROM ProductsPartsTable " &
                      " WHERE trim(ProductCode_ShortText30Fld) = " & Chr(34) & Trim(tmpProductCode_ShortText30Fld) & Chr(34) &
                      " AND trim(ProductDescription_ShortText250) = " & Chr(34) & Trim(tmpProductDescription_ShortText250) & Chr(34)

        If Not NoRecordFound() Then
            If IsNotEmpty(tmpMainSystemCode_ShortText1) Then
                r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
                CurrentProductPartID = r("ProductsPartID_Autonumber")
                MySelection = " UPDATE ProductsPartsTable " &
                     " SET    MainSystemCode_ShortText1 = " & Chr(34) & tmpMainSystemCode_ShortText1 & Chr(34) & ", " &
                     "     MasterCodeBookID_LongInteger = " & tmpMasterCodeBookID_LongInteger.ToString &
                     "  WHERE  ProductsPartID_Autonumber = " & CurrentProductPartID.ToString

                JustExecuteMySelection()

            End If
            Exit Sub
        End If

        Dim tmpManufacturerPartNo_ShortText30Fld = ""
        Dim tmpManufacturerDescription_ShortText250 = ""
        Dim tmpUnit_ShortText3 = ""
        Dim tmpWorkOrderItemID_LongInteger = -1
        Dim tmpBrandID_LongInteger = -1

        Dim FieldsToUpdate = " (" &
                    " ProductCode_ShortText30Fld, " &
                    " ManufacturerPartNo_ShortText30Fld, " &
                    " ProductDescription_ShortText250, " &
                    " ManufacturerDescription_ShortText250, " &
                    " Unit_ShortText3, " &
                    " WorkOrderItemID_LongInteger, " &
                    " BrandID_LongInteger, " &
                    " OriginalID_LongInteger, " &
                    " TypeOfThisRecord_Byte, " &
                    " MainSystemCode_ShortText1, " &
                    " MasterCodeBookID_LongInteger) "


        Dim FieldsValue = "(" &
                    Chr(34) & tmpProductCode_ShortText30Fld & Chr(34) & ", " &
                    Chr(34) & tmpManufacturerPartNo_ShortText30Fld & Chr(34) & ", " &
                    Chr(34) & tmpProductDescription_ShortText250 & Chr(34) & ", " &
                    Chr(34) & tmpManufacturerDescription_ShortText250 & Chr(34) & ", " &
                    Chr(34) & tmpUnit_ShortText3 & Chr(34) & ", " &
                    CurrentWorkOrderID.ToString & ", " &
                    CurrentBrandID.ToString & ", " &
                    CurrentOriginalExcelRecordID.ToString & ", " &
                    TypeOfThisRecord.ToString & ", " &
                    Chr(34) & tmpMainSystemCode_ShortText1 & Chr(34) & ", " &
                    tmpMasterCodeBookID_LongInteger.ToString &
                    ") "

        MySelection = "INSERT INTO ProductsPartsTable  " & FieldsToUpdate & " VALUES " & FieldsValue

        JustExecuteMySelection()

    End Sub
    Private Sub InsertNewProductPart()

        CurrentProductPartID = -1
        Dim tmpProductCode_ShortText30Fld = ""
        If IsNotEmpty(OriginalExcelRecordsDataGridView.Item("Code", CurrentOriginalExcelRecordRow).Value) Then
            tmpProductCode_ShortText30Fld = OriginalExcelRecordsDataGridView.Item("Code", CurrentOriginalExcelRecordRow).Value
        End If

        Dim tmpProductDescription_ShortText250 = ""
        If IsNotEmpty(OriginalExcelRecordsDataGridView.Item("description", CurrentOriginalExcelRecordRow).Value) Then
            tmpProductDescription_ShortText250 = OriginalExcelRecordsDataGridView.Item("description", CurrentOriginalExcelRecordRow).Value
            ' due to some descriptions have " in them then we will rephrase the description
            tmpProductDescription_ShortText250 = Replace(tmpProductDescription_ShortText250, Chr(34), " in")
            If Len(Trim(tmpProductDescription_ShortText250)) > 150 Then
                tmpProductDescription_ShortText250 = tmpProductDescription_ShortText250.Substring(0, 249)
            End If
        End If

        MySelection = "SELECT * " &
                       " FROM ProductsPartsTable " &
                      " WHERE trim(ProductCode_ShortText30Fld) = " & Chr(34) & Trim(tmpProductCode_ShortText30Fld) & Chr(34) &
                      " AND trim(ProductDescription_ShortText250) = " & Chr(34) & Trim(tmpProductDescription_ShortText250) & Chr(34)

        Dim r As DataRow
        If Not NoRecordFound() Then
            r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
            CurrentProductPartID = r("ProductsPartID_Autonumber")
            Exit Sub
        End If

        Dim tmpManufacturerPartNo_ShortText30Fld = ""
        If IsNotEmpty(OriginalExcelRecordsDataGridView.Item("SupplierCode", CurrentOriginalExcelRecordRow).Value) Then
            tmpManufacturerPartNo_ShortText30Fld = OriginalExcelRecordsDataGridView.Item("SupplierCode", CurrentOriginalExcelRecordRow).Value
        End If


        Dim tmpManufacturerDescription_ShortText250 = tmpProductDescription_ShortText250

        If IsNotEmpty(OriginalExcelRecordsDataGridView.Item("productdescription", CurrentOriginalExcelRecordRow).Value) Then
            tmpManufacturerDescription_ShortText250 = OriginalExcelRecordsDataGridView.Item("productdescription", CurrentOriginalExcelRecordRow).Value
            If Len(Trim(tmpManufacturerDescription_ShortText250)) > 150 Then
                tmpManufacturerDescription_ShortText250 = tmpManufacturerDescription_ShortText250.Substring(0, 249)
            End If
        End If

        Dim tmpUnit_ShortText3 = ""
        If IsNotEmpty(OriginalExcelRecordsDataGridView.Item("UnitName", CurrentOriginalExcelRecordRow).Value) Then
            tmpUnit_ShortText3 = OriginalExcelRecordsDataGridView.Item("UnitName", CurrentOriginalExcelRecordRow).Value
        End If

        Dim tmpWorkOrderItemID_LongInteger = CurrentWorkOrderID
        Dim tmpBrandID_LongInteger = -1
        Dim tmpMainSystemCode_ShortText1 = ""
        Dim tmpMasterCodeBookID_LongInteger = -1

        Dim FieldsToUpdate = " (" &
                    " ProductCode_ShortText30Fld, " &
                    " ManufacturerPartNo_ShortText30Fld, " &
                    " ProductDescription_ShortText250, " &
                    " ManufacturerDescription_ShortText250, " &
                    " Unit_ShortText3, " &
                    " WorkOrderItemID_LongInteger, " &
                    " BrandID_LongInteger, " &
                    " OriginalID_LongInteger, " &
                    " TypeOfThisRecord_Byte, " &
                    " MainSystemCode_ShortText1, " &
                    " MasterCodeBookID_LongInteger) "



        Dim FieldsValue = "(" &
                    Chr(34) & tmpProductCode_ShortText30Fld & Chr(34) & ", " &
                    Chr(34) & tmpManufacturerPartNo_ShortText30Fld & Chr(34) & ", " &
                    Chr(34) & tmpProductDescription_ShortText250 & Chr(34) & ", " &
                    Chr(34) & tmpManufacturerDescription_ShortText250 & Chr(34) & ", " &
                    Chr(34) & tmpUnit_ShortText3 & Chr(34) & ", " &
                    CurrentWorkOrderID.ToString & ", " &
                    CurrentBrandID.ToString & ", " &
                    CurrentOriginalExcelRecordID.ToString & ", " &
                   TypeOfThisRecord.ToString & ", " &
                    Chr(34) & tmpMainSystemCode_ShortText1 & Chr(34) & ", " &
                    tmpMasterCodeBookID_LongInteger.ToString &
                    ") "


        MySelection = "INSERT INTO ProductsPartsTable  " & FieldsToUpdate & " VALUES " & FieldsValue

        JustExecuteMySelection()

        MySelection = "SELECT * " &
                       " FROM ProductsPartsTable " &
                      " WHERE trim(ProductCode_ShortText30Fld) = " & Chr(34) & Trim(tmpProductCode_ShortText30Fld) & Chr(34) &
                      " AND trim(ProductDescription_ShortText250) = " & Chr(34) & Trim(tmpProductDescription_ShortText250) & Chr(34)

        JustExecuteMySelection()
        r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
        CurrentProductPartID = r("ProductsPartID_Autonumber")
        If IsNotEmpty(OriginalExcelRecordsDataGridView.Item("productlink1", CurrentOriginalExcelRecordRow).Value) Then
            InsertNewProductHyperlink(OriginalExcelRecordsDataGridView.Item("productlink1", CurrentOriginalExcelRecordRow).Value)
        End If
        If IsNotEmpty(OriginalExcelRecordsDataGridView.Item("productlink2", CurrentOriginalExcelRecordRow).Value) Then
            InsertNewProductHyperlink(OriginalExcelRecordsDataGridView.Item("productlink2", CurrentOriginalExcelRecordRow).Value)
        End If
        If IsNotEmpty(OriginalExcelRecordsDataGridView.Item("productlink3", CurrentOriginalExcelRecordRow).Value) Then
            InsertNewProductHyperlink(OriginalExcelRecordsDataGridView.Item("productlink3", CurrentOriginalExcelRecordRow).Value)
        End If

    End Sub

    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub GenerateWorkOrdersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerateWorkOrdersToolStripMenuItem.Click
        GenerateWorkOrderNumber()
    End Sub

    Private Sub OriginalExcelRecordDataGridView_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles OriginalExcelRecordsDataGridView.DataBindingComplete
        Dim NoOfHeaderLines = 1
        Dim RecordsToDisplay = 30
        Dim RecordsDisplyed = RecordCount

        If RecordCount > RecordsToDisplay Then
            RecordsDisplyed = RecordsToDisplay
        Else
            RecordsDisplyed = RecordCount + 1
        End If
        OriginalExcelRecordsDataGridView.Height = (OriginalExcelRecordsDataGridView.ColumnHeadersHeight * NoOfHeaderLines) + (DataGridViewRowHeight * RecordsDisplyed) + DataGridViewRowHeight
        If OriginalExcelRecordsCount = 0 Then
            OriginalExcelRecordsCount = -1
            FillOriginalExcelRecordDataGridView()
        End If
        '      OriginalExcelRecordsDataGridView.Width = 3300
    End Sub

    Private Sub OriginalExcelRecordDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles OriginalExcelRecordsDataGridView.RowEnter
        If e.RowIndex < 0 Then Exit Sub
        If OriginalExcelRecordsCount = 0 Then Exit Sub

        CurrentOriginalExcelRecordRow = e.RowIndex
        If Not OriginalExcelRecordsDataGridViewInitialized Then
            OriginalExcelRecordsDataGridViewInitialized = True
        End If
        CurrentOriginalExcelRecordID = OriginalExcelRecordsDataGridView.Item("OriginalID_AutoNumber", CurrentOriginalExcelRecordRow).Value

    End Sub

    Private Sub RetructureCODEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RetructureCODEToolStripMenuItem.Click
        Dim RowCount As Integer = RecordFinderDbControls.MyAccessDbDataTable.Rows.Count
        Dim PageDisplayCounter = 0
        For EachCurrentOriginalExcelRecord = 0 To RowCount - 1
            If PageDisplayCounter = 30 Then
                Me.Select()
                PageDisplayCounter = PageDisplayCounter + 1
                PageDisplayCounter = 0
                OriginalExcelRecordsDataGridView.Rows("code").Selected = True
                OriginalExcelRecordsDataGridView.Refresh()
            End If

            Dim CurrentOriginalExcelRecord = OriginalExcelRecordsDataGridView("OriginalID_AutoNumber", EachCurrentOriginalExcelRecord).Value
            Dim NewDescription = OriginalExcelRecordsDataGridView("description", EachCurrentOriginalExcelRecord).Value
            Dim Saveddescription = NewDescription
            If IsEmpty(NewDescription) Then Continue For
            NewDescription = Replace(NewDescription, "HONDA CIVIC ", "")
            NewDescription = Replace(NewDescription, "Rav4: ", "")
            If Not NewDescription = Saveddescription Then

                MySelection = " UPDATE originalExcelRecordTable " &
                     " SET    description = " & Chr(34) & NewDescription & Chr(34) &
                     "  WHERE  OriginalID_AutoNumber = " & CurrentOriginalExcelRecordID.ToString
                If NoRecordFound() Then
                    Dim YYY = ""
                End If

            End If
        Next

        FillOriginalExcelRecordDataGridView()

    End Sub

    Private Sub UpdateWorkOrderRelationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateWorkOrderRelationsToolStripMenuItem.Click
        MsgBox("UpdateWorkOrderRelations")
        Dim WorkOrderRelationsRecordRow = -1
        Dim CurrrentWorkOrderRelationsID = -1
        Dim tmpConcern = ""
        Dim tmpConcernCodeID = -1
        Dim r As DataRow

        MySelection = " Select * from WorkOrderRelationsTable "
        JustExecuteMySelection()
        WorkOrderRelationsTableDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        For WorkOrderRelationsRecordRow = 0 To RecordCount - 1
            'RecordType Number                          1 -header 2-job 3-part of OriginalExcelRecordTable
            Dim xxxxx = OriginalExcelRecordsDataGridView.Columns.Item(1).HeaderText


            CurrrentWorkOrderRelationsID = WorkOrderRelationsTableDataGridView.Item("WorkOrderRelationID_AutoNumber", WorkOrderRelationsRecordRow).Value

            If IsEmpty(WorkOrderRelationsTableDataGridView.Item("Concern_LongText", WorkOrderRelationsRecordRow).Value) Then
                Continue For
            End If

            tmpConcern = Trim(WorkOrderRelationsTableDataGridView.Item("Concern_LongText", WorkOrderRelationsRecordRow).Value)
            MySelection = "SELECT * " &
                       " FROM ConcernsTable " &
                      " WHERE trim(Concern_ShortText255) = " & Chr(34) & tmpConcern & Chr(34)
            While NoRecordFound()


                Dim tmpConcernTypeID_LongInteger = 0
                Dim tmpMasterCodeBookId_LongInteger = -1
                Dim tmpSource_Byte = 2


                Dim FieldsToUpdate = " (" &
                    " Concern_ShortText255, " &
                    " ConcernTypeID_LongInteger, " &
                    " MasterCodeBookId_LongInteger, " &
                    " Source_Byte " &
                    ") "

                Dim FieldsValue = "(" &
                    Chr(34) & tmpConcern & Chr(34) & ", " &
                    tmpConcernTypeID_LongInteger.ToString & ", " &
                    tmpMasterCodeBookId_LongInteger.ToString & ", " &
                    tmpSource_Byte.ToString &
                    ") "

                MySelection = "INSERT INTO ConcernsTable  " & FieldsToUpdate & " VALUES " & FieldsValue
                JustExecuteMySelection()

                MySelection = "SELECT * " &
                       " FROM ConcernsTable " &
                      " WHERE trim(Concern_ShortText255) = " & Chr(34) & tmpConcern & Chr(34)

            End While

            r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
            CurrentConcernID = r("ConcernCodeID_AutoNumber")
            MySelection = " UPDATE WorkOrderRelationsTable SET " &
                     " ConcernID_LongInteger = " & CurrentConcernID.ToString & ", " &
                     " InformationsHeaderID_LongInteger = -1 " & ", " &
                     " ProductPartID_LongInteger = -1 " & ", " &
                     " SupplierID_LongInteger = -1 " & ", " &
                     " OriginalID_LongInteger = -1 " &
                    " WHERE WorkOrderRelationID_AutoNumber = " & CurrrentWorkOrderRelationsID.ToString
            JustExecuteMySelection()
        Next
    End Sub

    Private Sub UpdateVehicleRepairClassCodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateVehicleRepairClassCodeToolStripMenuItem.Click
        MsgBox("To use this routine modify following commands")
        Exit Sub
        TemporaryDataGridView.Visible = True
        MySelection = "SELECT OriginalExcelRecordTable.OriginalID_AutoNumber, ProductsPartsTable.ProductsPartID_Autonumber, OriginalExcelRecordTable.description, ProductsPartsTable.MasterCodeBookID_LongInteger, OriginalExcelRecordTable.SupplierCode, ProductsPartsTable.PartNumber_ShortText30Fld, OriginalExcelRecordTable.VehicleCode, ProductsPartsTable.ServicedVehicleID_LongInteger, ProductsPartsTable.VehicleRepairClassID_LongInteger, ProductsPartsTable.ServicedVehicleID_LongInteger " &
        " FROM OriginalExcelRecordTable RIGHT JOIN ProductsPartsTable ON OriginalExcelRecordTable.ProductPartID_LongInteger = ProductsPartsTable.ProductsPartID_Autonumber "
        JustExecuteMySelection()
        TemporaryDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        '       Exit Sub
        Dim xxPartNumber_ShortText30Fld = ""
        Dim xxServicedVehicleID = -1
        Dim xxProductPartID = -1
        For i = 0 To RecordCount
            If IsNotEmpty(TemporaryDataGridView.Item("SupplierCode", i).Value) Then
                If TemporaryDataGridView.Item("SupplierCode", i).Value = "no code" Then Continue For
                xxPartNumber_ShortText30Fld = TemporaryDataGridView.Item("SupplierCode", i).Value
                If IsNotEmpty(TemporaryDataGridView.Item("ProductsPartID_Autonumber", i).Value) Then
                    xxProductPartID = TemporaryDataGridView.Item("ProductsPartID_Autonumber", i).Value
                    MySelection = " UPDATE ProductsPartsTable SET " &
                     "  PartNumber_ShortText30Fld = " & Chr(34) & xxPartNumber_ShortText30Fld & Chr(34) &
                    " WHERE  ProductsPartID_Autonumber = " & xxProductPartID
                    JustExecuteMySelection()
                End If
            End If
        Next
        MySelection = "SELECT OriginalExcelRecordTable.OriginalID_AutoNumber, ProductsPartsTable.ProductsPartID_Autonumber, OriginalExcelRecordTable.description, ProductsPartsTable.MasterCodeBookID_LongInteger, OriginalExcelRecordTable.SupplierCode, ProductsPartsTable.PartNumber_ShortText30Fld, OriginalExcelRecordTable.VehicleCode, ProductsPartsTable.ServicedVehicleID_LongInteger, ProductsPartsTable.VehicleRepairClassID_LongInteger, ProductsPartsTable.ServicedVehicleID_LongInteger " &
        " FROM OriginalExcelRecordTable RIGHT JOIN ProductsPartsTable ON OriginalExcelRecordTable.ProductPartID_LongInteger = ProductsPartsTable.ProductsPartID_Autonumber "
        JustExecuteMySelection()
        TemporaryDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
    End Sub
End Class