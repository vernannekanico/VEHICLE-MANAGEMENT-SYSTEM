Public Class UpdateATableForm
    Private CurrentProductsPartID As Integer = -1
    Private CurrentProductsPartsRow As Integer = -1
    Private ProductsPartsRecordCount As Integer = -1
    Private CurrentProductsPartsNumber As String

    Private ProductsPartsFieldsToSelect = ""
    Private ProductsPartsTablesLinks = ""
    Private ProductsPartsSelectionFilter = ""
    Private ProductsPartsSelectionFilterSaved = ""
    Private ProductsPartsSelectionOrder = ""

    Private ProductsPartsDataGridViewInitialized = False
    Private ProductsPartsDataGridViewAlreadyFormated = False

    Private CurrentExtractedWordID As Integer = -1
    Private CurrentExtractedWordRow As Integer = -1
    Private ExtractedWordsRecordCount As Integer = -1
    Private SavedCurrentExtractedWordRow = CurrentExtractedWordRow


    Private ExtractedWordsFieldsToSelect = ""
    Private ExtractedWordsTablesLinks = ""
    Private ExtractedWordsSelectionFilter = ""
    Private ExtractedWordsSelectionFilterSaved = ""
    Private ExtractedWordsSelectionOrder = ""

    Private ExtractedWordsDataGridViewInitialized = False
    Private ExtractedWordsDataGridViewAlreadyFormated = False

    Private ExtractedWordsTypeFieldsToSelect = ""
    Private ExtractedWordsTypeTablesLinks = ""
    Private ExtractedWordsTypeSelectionOrder = ""
    Private ExtractedWordsTypeRecordCount As Integer = -1

    Private CurrentBrandID = -1


    Private ExtractedWordTypeComboBoxRow As Integer = -1
    Private JustRePhraseThenUpdateProductsPartsRecord = False

    Private Sub UpdateForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ProductsPartsDataGridView.Width = 846
        ProductsPartsDataGridView.Height = 541

        ExtractedWordsDataGridView.Width = 423
        ExtractedWordsDataGridView.Height = 541
        ProductsPartsSelectionFilter = " WHERE TypeOfThisRecord_Byte = 3 "

        FillProductsPartsDataGridView()
        FillExtractedWordTypeDataGridView()

        LoadExtractedWordTypeComboBox()
    End Sub
    Private Sub FillExtractedWordTypeDataGridView()
        ExtractedWordsTypeFieldsToSelect = "Select * "

        ExtractedWordsTypeTablesLinks = " FROM ExtractedWordTypeTable "
        ExtractedWordsTypeSelectionOrder = " ORDER BY WordType_Short_Text1, TypeCode_ShortText4 "
        MySelection = ExtractedWordsTypeFieldsToSelect & ExtractedWordsTypeTablesLinks & ExtractedWordsTypeSelectionOrder


        JustExecuteMySelection()

        ExtractedWordTypeDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        ExtractedWordsTypeRecordCount = RecordFinderDbControls.MyAccessDbDataTable.Rows.Count

    End Sub

    Private Sub FillProductsPartsDataGridView()

        ProductsPartsFieldsToSelect = "Select * "

        ProductsPartsTablesLinks = " FROM ProductsPartsTable "
        ProductsPartsSelectionOrder = " ORDER BY ProductDescription_ShortText250 ASC "
        ProductsPartsSelectionFilter = " WHERE TypeOfThisRecord_Byte = 3 "

        MySelection = ProductsPartsFieldsToSelect & ProductsPartsTablesLinks & ProductsPartsSelectionFilter & ProductsPartsSelectionOrder


        If NoRecordFound() Then
            Dim xxx = 10
        End If
        ProductsPartsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        ProductsPartsRecordCount = ProductsPartsDataGridView.Rows.Count

        If Not ProductsPartsDataGridViewAlreadyFormated Then
            ProductsPartsDataGridViewAlreadyFormated = True
            FormatProductsPartsDataGridView()
        End If
    End Sub

    Private Sub FormatProductsPartsDataGridView()
        ProductsPartsDataGridViewAlreadyFormated = True

        ProductsPartsDataGridView.Columns.Item("ProductPartID_Autonumber").Visible = False
        ProductsPartsDataGridView.Columns.Item("ProductCode_ShortText30Fld").Visible = False
        ProductsPartsDataGridView.Columns.Item("ManufacturerPartNo_ShortText30Fld").Visible = False
        ProductsPartsDataGridView.Columns.Item("ManufacturerDescription_ShortText250").Visible = False
        ProductsPartsDataGridView.Columns.Item("Unit_ShortText3").Visible = False
        ProductsPartsDataGridView.Columns.Item("BrandID_LongInteger").Visible = False
        ProductsPartsDataGridView.Columns.Item("WorkOrderItemID_LongInteger").Visible = False
        ProductsPartsDataGridView.Columns.Item("MasterCodeBookID_LongInteger").Visible = False
        ProductsPartsDataGridView.Columns.Item("MainSystemCode_ShortText1").Visible = False
        ProductsPartsDataGridView.Columns.Item("TypeOfThisRecord_Byte").Visible = False
        ProductsPartsDataGridView.Columns.Item("DeleteMe").Visible = False
        ProductsPartsDataGridView.Columns.Item("ProductCode_ShortText30FldSaved").Visible = False
        ProductsPartsDataGridView.Columns.Item("ProductDescription_ShortText250Saved").Visible = False
        ProductsPartsDataGridView.Columns.Item("MotherProductPartID_LongInteger").Visible = False
        ProductsPartsDataGridView.Columns.Item("ForDeletionRecord_YesNo").Visible = False

        ProductsPartsDataGridView.Columns.Item("ProductDescription_ShortText250").HeaderText = "description"
        ProductsPartsDataGridView.Columns.Item("ProductDescription_ShortText250").Width = 500
        ProductsPartsDataGridView.Columns.Item("ProductDescriptionFormatted").HeaderText = "formatted description"
        ProductsPartsDataGridView.Columns.Item("ProductDescriptionFormatted").Width = 500

    End Sub
    Private Sub FillExtractedWordsDataGridView()


        ExtractedWordsFieldsToSelect = " Select " &
                      " ExtractedWordsTable.ExtractedWordsID_AutoNumber, " &
                      " ExtractedWordsTable.WordTypeAndCode_Short_Text2, " &
                      " ExtractedWordsTable.ExtractedWordItem_LongInteger, " &
                      " ExtractedWordsTable.ExtractedWordActionToTake_Byte, " &
                      " ExtractedWordsTable.ExtractedWordShortText30, " &
                      " ExtractedWordsTable.CoinedWordShortText30, " &
                      " ExtractedWordsTable.ProductPartID_LongInteger, " &
                      " ExtractedWordsTable.ExtractedWordTypeID_LongInteger, " &
                      " ProductsPartsTable.BrandID_LongInteger "


        ExtractedWordsTablesLinks = " FROM( " &
                      " ExtractedWordsTable " &
                            " LEFT JOIN ProductsPartsTable On ExtractedWordsTable.ProductPartID_LongInteger = ProductsPartsTable.ProductPartID_Autonumber) " &
                            " LEFT JOIN ExtractedWordTypeTable On ExtractedWordsTable.ExtractedWordTypeID_LongInteger = ExtractedWordTypeTable.ExtractedWordTypeID_AutoNumber "

        ExtractedWordsSelectionFilter = " WHERE ProductPartID_Autonumber = " & CurrentProductsPartID.ToString

        ExtractedWordsSelectionOrder = " ORDER BY WordTypeAndCode_Short_Text2 ASC, ExtractedWordItem_LongInteger "


        MySelection = ExtractedWordsFieldsToSelect & ExtractedWordsTablesLinks & ExtractedWordsSelectionFilter & ExtractedWordsSelectionOrder
        JustExecuteMySelection()
        ExtractedWordsDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        ExtractedWordsRecordCount = RecordCount

        If Not ExtractedWordsDataGridViewAlreadyFormated Then
            FormatExtractedWordsDataGridView()
        End If
    End Sub

    Private Sub FormatExtractedWordsDataGridView()
        ExtractedWordsDataGridViewAlreadyFormated = True
        ExtractedWordsDataGridView.Width = 0
        Dim DoNotDisplayFields = "ExtractedWordsID_AutoNumber/" &
                                    "ProductPartID_LongInteger/" &
                                    "ExtractedWordTypeID_LongInteger/" &
                                    "BrandID_LongInteger/"

        For i = 0 To ExtractedWordsDataGridView.Columns.GetColumnCount(0) - 1

            If InStr(DoNotDisplayFields, ExtractedWordsDataGridView.Columns.Item(i).HeaderText & "/") > 0 Then
                ExtractedWordsDataGridView.Columns.Item(i).Visible = False
            End If
            Select Case ExtractedWordsDataGridView.Columns.Item(i).HeaderText
          '                  " ExtractedWordsTable.ExtractedWordShortText30, " &
                Case "ExtractedWordItem_LongInteger"
                    ExtractedWordsDataGridView.Columns.Item(i).HeaderText = " "
                    ExtractedWordsDataGridView.Columns.Item(i).Width = 15
                Case "ExtractedWordShortText30"
                    ExtractedWordsDataGridView.Columns.Item(i).HeaderText = "Extracted Word"
                    ExtractedWordsDataGridView.Columns.Item(i).Width = 200
        '                  " ExtractedWordsTable.CoinedWordShortText30, " &
                Case "CoinedWordShortText30"
                    ExtractedWordsDataGridView.Columns.Item(i).HeaderText = "coined word"
                    ExtractedWordsDataGridView.Columns.Item(i).Width = 200
                    '                  " ExtractedWordsTable.ExtractedWordTypeID_LongInteger, " &
            End Select

            If ExtractedWordsDataGridView.Columns.Item(i).Visible = True Then
                ExtractedWordsDataGridView.Width = ExtractedWordsDataGridView.Width + ExtractedWordsDataGridView.Columns.Item(i).Width
            End If
        Next

        '      ExtractedWordsDataGridView.Top = 30
        '      '      Me.Left = (SystemDocumentationMainMenu.Width - Me.Width) / 2
        '      Me.Location = New Point(Me.Location.X, 55)
        '     ExtractedWordsDataGridView.Left = (Me.Width - ExtractedWordsDataGridView.Width) / 2
    End Sub
    Private Sub ProductsPartsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles ProductsPartsDataGridView.RowEnter
        If e.RowIndex < 0 Then Exit Sub
        If ProductsPartsRecordCount = 0 Then Exit Sub

        CurrentProductsPartsRow = e.RowIndex
        CurrentProductsPartID = ProductsPartsDataGridView.Item("ProductPartID_Autonumber", CurrentProductsPartsRow).Value
        FillExtractedWordsDataGridView()

    End Sub

    Private Sub ExtractedWordsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles ExtractedWordsDataGridView.RowEnter
        If e.RowIndex < 0 Then Exit Sub
        If RecordCount = 0 Then Exit Sub

        CurrentExtractedWordRow = e.RowIndex
        CurrentExtractedWordID = ExtractedWordsDataGridView.Item("ExtractedWordsID_AutoNumber", CurrentExtractedWordRow).Value
    End Sub

    Private Sub SelectCustomerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectCustomerToolStripMenuItem.Click
        Dim RowCount As Integer = RecordFinderDbControls.MyAccessDbDataTable.Rows.Count
        Dim PageDisplayCounter = 0
        For EachCurrentProductPartRecord = 0 To RowCount - 1
            PageDisplayCounter = PageDisplayCounter + 1

            If PageDisplayCounter > 100 Then
                Me.Select()
                PageDisplayCounter = PageDisplayCounter + 1
                PageDisplayCounter = 0
                ProductsPartsDataGridView.Rows(EachCurrentProductPartRecord).Selected = True
                ProductsPartsDataGridView.Refresh()
                MsgBox("pause")
            End If
            CurrentProductsPartID = ProductsPartsDataGridView("ProductPartID_Autonumber", EachCurrentProductPartRecord).Value
            Dim tmpDescription = LTrim(RTrim(ProductsPartsDataGridView("ProductDescription_ShortText250", EachCurrentProductPartRecord).Value))
            Dim Saveddescription = tmpDescription
            If IsEmpty(tmpDescription) Then Continue For
            ExtractTheWords(tmpDescription)
        Next

        FillProductsPartsDataGridView()

        MsgBox("RUN THE COMPILED APPLICATION AFTER REPLACING the  ""WHATS back to avoid accidental update " & Chr(13) & "Continue the Update ?", 4)

    End Sub

    Private Sub ExtractTheWords(tmpDescription)
        Dim SpaceExistsInColumn = -1
        Dim WordExtracted = ""
        Dim tmpItemCounter = 0
        Dim EnclosedIdentifier = ""
        Dim ClosingIdentifierlocation = 0
        While Not tmpDescription = ""
            tmpItemCounter = tmpItemCounter + 1
            tmpDescription = LTrim(tmpDescription)
            SpaceExistsInColumn = InStr(tmpDescription, " ")
            If SpaceExistsInColumn = 0 Then
                WordExtracted = tmpDescription
                tmpDescription = ""
            Else
                EnclosedIdentifier = Mid(tmpDescription, 1, 1)
                If EnclosedIdentifier = "(" And InStr(tmpDescription, ")") > 0 Then
                    ClosingIdentifierlocation = InStr(tmpDescription, ")")
                    WordExtracted = Strings.Mid(tmpDescription, 1, ClosingIdentifierlocation + 1)
                    tmpDescription = Strings.Mid(tmpDescription, ClosingIdentifierlocation + 1)
                Else
                    WordExtracted = Strings.Mid(tmpDescription, 1, SpaceExistsInColumn - 1)
                    tmpDescription = Mid(tmpDescription, SpaceExistsInColumn + 1)
                End If
            End If
            If Not Len(WordExtracted) > 30 Then InsertNewExtractedWord(WordExtracted, tmpItemCounter)
        End While

    End Sub
    Private Sub InsertNewExtractedWord(WordExtracted, tmpItemCounter)

        Dim tmpQty_Integer = 0
        Dim tmpExtractedWordTypeID_LongInteger = -1

        MySelection = "SELECT * " &
                      " FROM ExtractedWordsTable " &
                      " WHERE ExtractedWordsID_AutoNumber = " & CurrentProductsPartID.ToString &
                      " AND ExtractedWordShortText30 = " & Chr(34) & WordExtracted & Chr(34)

        Dim r As DataRow
        If Not NoRecordFound() Then
            r = RecordFinderDbControls.MyAccessDbDataTable.Rows(0)
            CurrentProductsPartID = r("ExtractedWordsID_AutoNumber")
            Exit Sub
        End If

        Dim FieldsToUpdate = " ( " &
                    " ExtractedWordItem_LongInteger, " &          '1
                    " WordTypeAndCode_Short_Text2, " &          '1
                    " ExtractedWordShortText30, " &        '2
                    " ProductPartID_LongInteger, " &                '3
                    " ExtractedWordTypeID_LongInteger " &        '4
                    ") "

        Dim ReplacementData = "(" &
                    tmpItemCounter.ToString & ", " &      '1   
                    Chr(34) & "Z" & Chr(34) & ", " &        '2
                    Chr(34) & WordExtracted & Chr(34) & ", " &        '2
                    CurrentProductsPartID.ToString & ", " &            '3
                    tmpExtractedWordTypeID_LongInteger.ToString &
                    ") "

        MySelection = "INSERT INTO ExtractedWordsTable  " & FieldsToUpdate & " VALUES " & ReplacementData

        JustExecuteMySelection()


    End Sub

    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        Me.Close()
        VehicleManagementSystemForm.Select()
    End Sub
    Private Sub LoadExtractedWordTypeComboBox()
        MySelection = "Select * " &
                           " FROM ExtractedWordTypeTable ORDER BY WordType_Short_Text1, TypeCode_ShortText4 "
        JustExecuteMySelection()
        ExtractedWordTypeDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable

        ExtractedWordTypeComboBox.Items.Clear()
        ExtractedWordTypeComboBox.Items.Add("Select Word Type / Action To Take")

        ' FILL COMBOBOX
        For Each R As DataRow In RecordFinderDbControls.MyAccessDbDataTable.Rows
            ExtractedWordTypeComboBox.Items.Add(R("WordTypeDescription_ShortText45"))
        Next
        ' DISPLAY FIRS NAME FOUND
        If RecordCount > 0 Then
            For I = 0 To RecordCount - 1
                If ExtractedWordTypeComboBox.Items(I).ToString = "Select Word Type / Action To Take" Then
                    ExtractedWordTypeComboBox.Text = ExtractedWordTypeComboBox.Items(I).ToString
                End If
            Next
            '           ConcernTypesComboBox.Text = (ConcernTypesComboBox.Items(2)).ToString
        End If

    End Sub

    Private Sub ExtractedWordTypeComboBox_TextChanged(sender As Object, e As EventArgs) Handles ExtractedWordTypeComboBox.TextChanged
        If ExtractedWordTypeComboBox.Text = "Select Word Type / Action To Take" Then Exit Sub
        ' After valid Selection, disable the selection box then return control to the datagridviews so upon
        ' ExtractedWordTypeComboBox.VisibleChanged both datagriedviews are enabled
        Dim tmpSelectedIndex = ExtractedWordTypeComboBox.SelectedIndex
        If JustRePhraseThenUpdateProductsPartsRecord Then
            JustRePhraseThenUpdateProductsPartsRecord = False
            UpdateWordTypeAndCode_Short_Text2(tmpSelectedIndex)
            RePhraseThenUpdateProductsPartsRecord()
        End If
        ExtractedWordTypeComboBox.Visible = False
    End Sub
    Private Sub UpdateWordTypeAndCode_Short_Text2(tmpSelectedIndex)
        Dim AnswerTovbYesNo = ""
        AnswerTovbYesNo = MsgBox("Is This A Global Change ?", vbYesNo)
        FillExtractedWordTypeDataGridView()

        If AnswerTovbYesNo = 6 Then
            ExtractedWordsSelectionFilter = "  WHERE  LCase(ExtractedWordShortText30) = " &
                        Chr(34) & LCase(Trim(ExtractedWordsDataGridView("ExtractedWordShortText30", CurrentExtractedWordRow).Value)) & Chr(34)
        Else
            ExtractedWordsSelectionFilter = "  WHERE  ExtractedWordsID_AutoNumber = " & CurrentExtractedWordID
        End If
        Dim tmpWordTypeAndCode_Short_Text2 = ExtractedWordTypeDataGridView("WordType_Short_Text1", tmpSelectedIndex - 1).Value &
                            ExtractedWordTypeDataGridView("TypeCode_ShortText4", tmpSelectedIndex - 1).Value
        Dim tmpExtractedWordActionToTake_Byte = ExtractedWordTypeDataGridView("ActionToTake_Byte", tmpSelectedIndex - 1).Value
        MySelection = " UPDATE ExtractedWordsTable  " &
                     " SET   WordTypeAndCode_Short_Text2 = " & Chr(34) & tmpWordTypeAndCode_Short_Text2 & Chr(34) & ", " &
                      "      ExtractedWordActionToTake_Byte = " & tmpExtractedWordActionToTake_Byte.ToString & ExtractedWordsSelectionFilter
        JustExecuteMySelection()
        ' Since current extracted word has been updated then order will be changed when FillExtractedWordsDataGridView()is executed
        ' then pointer should go to the next extracted word. possibilities are number of extracted words is reduced when ever a word is deleted
        If ExtractedWordsRecordCount - 1 > CurrentExtractedWordRow Then
            CurrentExtractedWordRow = CurrentExtractedWordRow + 0
        Else
            CurrentExtractedWordRow = 0
        End If
        ' Refresh the updated ExtractedWordsDataGridView
        Dim SavedCurrentExtractedWordRow = CurrentExtractedWordRow
        FillExtractedWordsDataGridView()
        ExtractedWordsDataGridView.Rows(SavedCurrentExtractedWordRow).Selected = True
        CurrentExtractedWordRow = SavedCurrentExtractedWordRow
        ExtractedWordsDataGridView.Refresh()

    End Sub
    Private Sub ExtractedWordTypeComboBox_Click(sender As Object, e As EventArgs) Handles ExtractedWordTypeComboBox.SelectedIndexChanged
        If ExtractedWordTypeComboBox.SelectedIndex = 0 Then
            Exit Sub
        End If
        ExtractedWordsDataGridView.Enabled = True
        ExtractedWordTypeComboBox.Visible = False
        'upon selection of the type UpdateWordTypeAndCode_Short_Text2 of ExtractedWordsTable
        If JustRePhraseThenUpdateProductsPartsRecord Then
            JustRePhraseThenUpdateProductsPartsRecord = False
            UpdateWordTypeAndCode_Short_Text2(ExtractedWordTypeComboBox.SelectedIndex)
            RePhraseThenUpdateProductsPartsRecord()
        End If

    End Sub


    Private Sub ProcessVehicleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProcessVehicleToolStripMenuItem.Click
        ExtractedWordTypeComboBox.Visible = True
        ExtractedWordTypeComboBox.SelectedIndex = 0
        If ExtractedWordsDataGridView("WordTypeAndCode_Short_Text2", CurrentExtractedWordRow).Value = "Z" Then
            CheckIfIdentifiable()
        Else
            Dim AnswerTovbYesNo = MsgBox("Would you like to change classification?", vbYesNo)
            If AnswerTovbYesNo = 6 Then
                ProcessVehicleToolStripMenuItem.Visible = False
                ExtractedWordTypeComboBox.Visible = True
            End If
        End If
    End Sub
    Private Sub RePhraseThenUpdateProductsPartsRecord()
        Dim tmpRePhrasedDescription = ""
        Dim tmpExtractedWordActionToTake_Byte = ""
        Dim tmpTypeOfThisWord = ""
        Dim tmpWordIs = ""

        For EachCurrentProductPartRecord = 0 To ExtractedWordsRecordCount - 1
            tmpWordIs = ExtractedWordsDataGridView("ExtractedWordShortText30", EachCurrentProductPartRecord).Value
            Dim IsThisNull = ExtractedWordsDataGridView("ExtractedWordActionToTake_Byte", EachCurrentProductPartRecord).Value
            If Not IsDBNull(IsThisNull) = True Then
                tmpExtractedWordActionToTake_Byte = ExtractedWordsDataGridView("ExtractedWordActionToTake_Byte", EachCurrentProductPartRecord).Value
                Select Case tmpExtractedWordActionToTake_Byte
                    Case 1 '- As Is 
                        tmpRePhrasedDescription = Trim(tmpRePhrasedDescription) & Space(1) &
                                                         ExtractedWordsDataGridView("ExtractedWordShortText30", EachCurrentProductPartRecord).Value
                    Case 2 '- disregard this word linking verb - of/for/from, wiper -wiper, Motor, door
                        tmpRePhrasedDescription = Trim(tmpRePhrasedDescription) & Space(1) &
                                                        ExtractedWordsDataGridView("ExtractedWordShortText30", EachCurrentProductPartRecord).Value
                    Case 3 '- 3 - update related table and mark as 1 - As Is
                        tmpTypeOfThisWord = ExtractedWordsDataGridView("WordTypeAndCode_Short_Text2", EachCurrentProductPartRecord).Value
                        Select Case tmpTypeOfThisWord
                            Case "2D"   ' ProductSpecialName	-PZL Platinum Full Synthetic
                                UpdateProductsPartsTable(3, tmpWordIs) ' ProductSpecialName
                            Case "6"    ' model range - For 1999-2000 Honda Civic, 96-00 Honda Civic
                                UpdateProductsPartsTable(1, tmpWordIs)  ' 1 model range
                            Case "9"    'brand
                                InsertNewBrand(tmpWordIs)
                                UpdateProductsPartsTable(5, tmpWordIs)  ' 2 product code

                            Case "A"    'product code
                                If IsEmpty(ProductsPartsDataGridView("ManufacturerPartNo_ShortText30Fld", CurrentProductsPartsRow).Value) Then
                                    UpdateProductsPartsTable(2, tmpWordIs)  ' 2 product code
                                End If
                            Case Else
                                Dim xxxx = 1
                        End Select


                        ExtractedWordsSelectionFilter = "  WHERE ExtractedWordShortText30 = " & Chr(34) & tmpWordIs & Chr(34)

                        'THIS GROUP OF TYPE OF WORD WILL NOW BE DELETED FROM THE EXTRACTEDWORDSTABLE
                        MySelection = " DELETE FROM ExtractedWordsTable  " & ExtractedWordsSelectionFilter
                        JustExecuteMySelection()

                    Case 4 '- delete Me (delete from main description And redisplay)
                    Case 5 '- Join() 1 word before And 1 word after
                    Case 6 '- Delete, Disregard

                End Select
            Else
                tmpRePhrasedDescription = Trim(tmpRePhrasedDescription) & Space(1) &
                                                        ExtractedWordsDataGridView("ExtractedWordShortText30", EachCurrentProductPartRecord).Value
                tmpRePhrasedDescription = LTrim(tmpRePhrasedDescription)
            End If
        Next
        Dim SavedCurrentExtractedWordRow = CurrentExtractedWordRow
        FillExtractedWordsDataGridView()
        If SavedCurrentExtractedWordRow <= ExtractedWordsRecordCount Then
            ExtractedWordsDataGridView.Rows(SavedCurrentExtractedWordRow).Selected = True
            ExtractedWordsDataGridView.Refresh()
        End If
        UpdateProductsPartsTable(4, tmpRePhrasedDescription)

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
    Private Sub UpdateProductsPartsTable(PassedField, PassedValue)
        Dim tmpFieldUpdate = ""
        Dim tmpFieldUpdate2 = ""
        Dim tmpProductsPartsFilter = ""
        ' 1 model range
        Select Case PassedField
            Case 1 'Vehicle Generation
                tmpFieldUpdate = " VehicleGeneration150 = " & Chr(34) & PassedValue & Chr(34)
                tmpFieldUpdate2 = ", ProductDescription_ShortText250 = Replace(ProductDescription_ShortText250, " & Chr(34) & PassedValue & Chr(34) & ", " & Chr(34) & Chr(34) & ")"
                tmpProductsPartsFilter = " WHERE ProductDescription_ShortText250  LIKE " & Chr(34) & "%" & PassedValue & "%" & Chr(34)
            Case 2 'ManufacturerPartNo_ShortText30Fld & ProductDescription_ShortText250

                ' A GLOBAL CHANGE WILL OCCUR IN THIS FILTER SO SAVE THE ORIGINAL FILTER
                tmpProductsPartsFilter = " WHERE ProductDescription_ShortText250  LIKE " & Chr(34) & "%" & PassedValue & "%" & Chr(34)
                tmpFieldUpdate2 = ", ProductDescription_ShortText250 = Replace(ProductDescription_ShortText250, " & Chr(34) & PassedValue & Chr(34) & ", " & Chr(34) & Chr(34) & ")"
                tmpFieldUpdate = " ManufacturerPartNo_ShortText30Fld = " & PassedValue
                RecordFinderDbControls.AddParam("@PassedValue", "%" & PassedValue & "%")
            Case 3
            Case 4 'ProductDescriptionFormatted
                tmpFieldUpdate = " ProductDescriptionFormatted = " & Chr(34) & PassedValue & Chr(34)
                tmpProductsPartsFilter = " WHERE ProductPartID_Autonumber = " & CurrentProductsPartID.ToString
            Case 5 ' BrandID_LongInteger

                RecordFinderDbControls.AddParam("@PassedValue", "%" & PassedValue & "%")

                ' A GLOBAL CHANGE WILL OCCUR IN THIS FILTER SO SAVE THE ORIGINAL FILTER
                tmpProductsPartsFilter = " WHERE ProductDescription_ShortText250  LIKE " & Chr(34) & "%" & PassedValue & "%" & Chr(34)

                tmpFieldUpdate = " BrandID_LongInteger = " & CurrentBrandID.ToString
            Case 6 ' ProductDescription_ShortText250
                tmpFieldUpdate = " ProductDescription_ShortText250 = " & Chr(34) & PassedValue & Chr(34)
                tmpProductsPartsFilter = " WHERE ProductPartID_Autonumber  = " & CurrentProductsPartID.ToString

        End Select
        MySelection = " UPDATE ProductsPartsTable SET " &
                        tmpFieldUpdate &
                        tmpFieldUpdate2 &
                        tmpProductsPartsFilter
        JustExecuteMySelection()

        'SINCE CHANGES WERE MADE TO THE ProductsPartsTable REFRESH ProductsPartsDataGridView
        FillProductsPartsDataGridView()
    End Sub

    Private Sub CheckIfIdentifiable()
        Dim FindKey As String = "(" & Trim(ExtractedWordsDataGridView("ExtractedWordShortText30", CurrentExtractedWordRow).Value) & ")"
        RecordFinderDbControls.AddParam("@FindKey", "%" & FindKey & "%")
        ExtractedWordsTypeTablesLinks = " FROM ExtractedWordTypeTable "

        Dim ExtractedWordTypeSearchFilter = "  WHERE WordTypeDescription_ShortText45 LIKE @FindKey "

        MySelection = ExtractedWordsTypeFieldsToSelect & ExtractedWordsTypeTablesLinks & ExtractedWordTypeSearchFilter
        JustExecuteMySelection()
        ExtractedWordTypeDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        If RecordCount > 0 Then
            ExtractedWordsSelectionFilter = "  WHERE  LCase(ExtractedWordShortText30) = " &
                        Chr(34) & LCase(Trim(ExtractedWordsDataGridView("ExtractedWordShortText30", CurrentExtractedWordRow).Value)) & Chr(34)

            UpdateExtractedWordsTable()
            ExtractedWordTypeComboBox.Visible = False
        Else
            ExtractedWordTypeComboBox.Visible = True
        End If
        FillExtractedWordTypeDataGridView()
    End Sub

    Private Sub UpdateExtractedWordsTable()

        Dim tmpWordTypeAndCode_Short_Text2 = ExtractedWordTypeDataGridView("WordType_Short_Text1", 0).Value &
                            ExtractedWordTypeDataGridView("TypeCode_ShortText4", 0).Value
        Dim tmpExtractedWordActionToTake_Byte = ExtractedWordTypeDataGridView("ActionToTake_Byte", 0).Value
        MySelection = " UPDATE ExtractedWordsTable  " &
                     " SET   WordTypeAndCode_Short_Text2 = " & Chr(34) & tmpWordTypeAndCode_Short_Text2 & Chr(34) & ", " &
                      "   ExtractedWordActionToTake_Byte = " & Chr(34) & tmpExtractedWordActionToTake_Byte & Chr(34) &
                      ExtractedWordsSelectionFilter
        JustExecuteMySelection()
        Dim SavedCurrentExtractedWordRow = CurrentExtractedWordRow
        FillExtractedWordsDataGridView()
        ExtractedWordsDataGridView.Rows(SavedCurrentExtractedWordRow).Selected = True
        ExtractedWordTypeDataGridView.Refresh()
        RePhraseThenUpdateProductsPartsRecord()
        FillProductsPartsDataGridView()
        ProductsPartsDataGridView.Rows(CurrentProductsPartsRow).Selected = True
        ProductsPartsDataGridView.Refresh()

    End Sub

    Private Sub ExtractedWordTypeComboBox_VisibleChanged(sender As Object, e As EventArgs) Handles ExtractedWordTypeComboBox.VisibleChanged
        If ExtractedWordTypeComboBox.Visible = True Then
            ProductsPartsDataGridView.Enabled = False
            ExtractedWordsDataGridView.Enabled = False
            ProcessVehicleToolStripMenuItem.Visible = False
            JustRePhraseThenUpdateProductsPartsRecord = True
        Else
            ProcessVehicleToolStripMenuItem.Visible = True
            ExtractedWordsDataGridView.Enabled = True
            ProductsPartsDataGridView.Enabled = True
            JustRePhraseThenUpdateProductsPartsRecord = False
        End If
    End Sub

    Private Sub RePhraseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RePhraseToolStripMenuItem.Click
        RePhraseThenUpdateProductsPartsRecord()
        '       FillProductsPartsDataGridView()
        ProductsPartsDataGridView.Rows(CurrentProductsPartsRow).Selected = True
        ProductsPartsDataGridView.Refresh()
    End Sub

    Private Sub RePhraseAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RePhraseAllToolStripMenuItem.Click
        Dim SavedCurrentProductsPartID = CurrentProductsPartID

        For EachProductPartRecord = 0 To ProductsPartsRecordCount - 1
            CurrentProductsPartID = ProductsPartsDataGridView.Item("ProductPartID_Autonumber", EachProductPartRecord).Value
            FillExtractedWordsDataGridView()

            RePhraseThenUpdateProductsPartsRecord()
            FillProductsPartsDataGridView()
            ProductsPartsDataGridView.Rows(EachProductPartRecord).Selected = True
            ProductsPartsDataGridView.Refresh()
        Next

    End Sub


    Private Sub AddAFieldToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddANewWordToolStripMenuItem.Click
        MenuStrip2.Enabled = False
        AddANewWordGroupBox.Visible = True
    End Sub

    Private Sub SaveNewWordButton_Click(sender As Object, e As EventArgs) Handles SaveNewWordButton.Click
        Dim AnswerTovbYesNo = ""
        If IsNotEmpty(NewWordTextBox.Text) Then
            If MsgBox("Sure adding this word ?", vbYesNo) = 6 Then '6Yes
                InsertNewExtractedWord(NewWordTextBox.Text, ExtractedWordsRecordCount + 1)
                FillExtractedWordsDataGridView()
            Else
                Exit Sub
            End If
        End If
        NewWordTextBox.Text = ""
        MenuStrip2.Enabled = True
        AddANewWordGroupBox.Visible = False

    End Sub

    Private Sub CancelNewWordButton_Click(sender As Object, e As EventArgs) Handles CancelNewWordButton.Click
        MenuStrip2.Enabled = True
        AddANewWordGroupBox.Visible = False

    End Sub

    Private Sub JoinWordsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JoinWordsToolStripMenuItem.Click
        MenuStrip2.Enabled = False
        ProductsPartsDataGridView.Enabled = False
        MsgBox("Double Click word to join")
        SavedCurrentExtractedWordRow =  CurrentExtractedWordRow
    End Sub

    Private Sub ExtractedWordsDataGridView_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles ExtractedWordsDataGridView.CellMouseDoubleClick
        If MenuStrip2.Enabled = True Then Exit Sub
        If SavedCurrentExtractedWordRow = CurrentExtractedWordRow Then Exit Sub

        Dim CoinedWords = ExtractedWordsDataGridView("ExtractedWordShortText30", SavedCurrentExtractedWordRow).Value & Space(1) &
ExtractedWordsDataGridView("ExtractedWordShortText30", CurrentExtractedWordRow).Value
        Dim Answer = MsgBox("Continue join the words, " & CoinedWords, vbYesNoCancel)
        Select Case Answer
            Case 2 ' cancel
                Exit Sub
            Case 6 ' yes
                Dim tmpExtractedWordsID_AutoNumber = ExtractedWordsDataGridView("ExtractedWordsID_AutoNumber", SavedCurrentExtractedWordRow).Value
                MySelection = " UPDATE ExtractedWordsTable  " &
                     " SET   ExtractedWordShortText30 = " & Chr(34) & CoinedWords & Chr(34) &
                                " WHERE ExtractedWordsID_AutoNumber = " & tmpExtractedWordsID_AutoNumber.ToString
                JustExecuteMySelection()
                tmpExtractedWordsID_AutoNumber = ExtractedWordsDataGridView("ExtractedWordsID_AutoNumber", CurrentExtractedWordRow).Value
                MySelection = " DELETE FROM ExtractedWordsTable  " &
                                 " WHERE ExtractedWordsID_AutoNumber = " & tmpExtractedWordsID_AutoNumber.ToString
                JustExecuteMySelection()

                ' update the word
                ' delete current word
            Case 7 ' no
        End Select
        MenuStrip2.Enabled = True
        ProductsPartsDataGridView.Enabled = True
        FillExtractedWordsDataGridView()
    End Sub

    Private Sub FinalizeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FinalizeToolStripMenuItem.Click
        Dim PassedValue = ProductsPartsDataGridView("ProductDescriptionFormatted", CurrentProductsPartsRow).Value
        UpdateProductsPartsTable(6, PassedValue)

    End Sub
End Class