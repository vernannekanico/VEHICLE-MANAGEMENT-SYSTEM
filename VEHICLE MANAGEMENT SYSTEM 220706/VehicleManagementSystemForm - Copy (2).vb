Public Class VehicleManagementSystemForm
    Private Sub VehicleManagementSystemForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Size = (My.Computer.Screen.WorkingArea.Size)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.WindowState = FormWindowState.Maximized

    End Sub
    Private Sub VehicleManagementSystemForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        DefaultSystemPath = Replace(DefaultSystemPath, "\bin\Debug", "")

        ShowLoginForm()
    End Sub
    Private Sub ShowLoginForm()
        Me.Select()
        DisableAllOptions()
        Me.Enabled = False
        LoginForm.Show()
    End Sub
    Private Sub VehicleManagementSystemForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        If Me.Enabled = False Then
            Exit Sub
        End If
        Me.Show()
        Me.Select()
        Select Case Tunnel1
            Case "Startup"
                SetupSystemAccess()
            Case "Login again"
                DisableAllOptions()
        End Select
        ResetTunnels()
    End Sub
    Private Sub SetupSystemAccess()
        Select Case UserLevelAccess
            Case ""
                DisableAllOptions()
            Case "3A"                                                                   'Service Deparment Manager
                CurrentUserGroup = "Service Deparment Manager"
                ServiceDepartmentToolStripMenuItem.Visible = True
            Case "3B"                                                                   'Service Deparment Assistant Manager
                CurrentUserGroup = "Service Deparment Assistant Manager"
                ServiceDepartmentToolStripMenuItem.Visible = True
                AsstServiceManagerToolStripMenuItem.Enabled = True

                WorkOrderForm.AddWorkOrderToolStripMenuItem.Visible = False
                WorkOrderForm.EditWorkOrderToolStripMenuItem.Visible = False
                WorkOrderForm.DeleteWorkOrderToolStripMenuItem.Visible = False
            Case "3C"                                                                   'Lead Automotive Service Specialist
                CurrentUserGroup = "Lead Automotive Service Specialist"
                ServiceDepartmentToolStripMenuItem.Visible = True
                ServiceHeadToolStripMenuItem.Enabled = True
            Case "3D"                                                                   'Automotive Service Specialist 3D
                CurrentUserGroup = "Automotive Service Specialist"
                MsgBox(UserLevelAccess & " ACCESS LEVEL has not yet been setup!")
            Case "3E"                                                                   ' 
                CurrentUserGroup = "Customer Relations Specialist"
                ServiceDepartmentToolStripMenuItem.Visible = True
                CustomerServiceToolStripMenuItem.Enabled = True
                WorkOrderForm.AssignWorkOrderToolStripMenuItem.Visible = False

            Case "1E"
                CurrentUserGroup = "Systems Engineer"
                EnableAllOptions()
            Case "1A"
                CurrentUserGroup = "Systems Manager"
                EnableAllOptions()
            Case "1B"
                CurrentUserGroup = "Systems Analyst"
                EnableAllOptions()
            Case Else
                MsgBox(UserLevelAccess & " ACCESS LEVEL has not yet been setup!")

        End Select
    End Sub
    Private Sub EnableAllOptions()

        PersonnelInformationSystemToolStripMenuItem.Visible = True
        PersonelFileToolStripMenuItem.Enabled = True

        ServiceDepartmentToolStripMenuItem.Visible = True
        CustomerServiceToolStripMenuItem.Enabled = True

        ProcurementSystemToolStripMenuItem.Visible = True


        LogisticsSystemToolStripMenuItem.Visible = True


        MaterialControlSystemToolStripMenuItem1.Visible = True
        ProductsToolStripMenuItem1.Enabled = True


        FinanceSystemToolStripMenuItem.Visible = True


        FilesToolStripMenuItem.Visible = True
        CustomersToolStripMenuItem1.Enabled = True
        CitiesToolStripMenuItem1.Enabled = True
        StatesToolStripMenuItem1.Enabled = True
        CountriesToolStripMenuItem1.Enabled = True
        VehicleTrimsToolStripMenuItem.Visible = True
        VehicleModelsToolStripMenuItem2.Enabled = True
        VehicleModelsRelationsToolStripMenuItem.Enabled = True
        VehicleMakesToolStripMenuItem1.Enabled = True
        VehicleDetailsToolStripMenuItem.Enabled = True
        VehiclesServicedToolStripMenuItem1.Enabled = True
        ConcernsToolStripMenuItem1.Enabled = True
        TypeOfConcernsToolStripMenuItem.Enabled = True
        UsersFileToolStripMenuItem.Enabled = True

        UtilitiesToolStripMenuItem.Visible = True

        FinanceSystemToolStripMenuItem.Visible = False
        UpdateToolStripMenuItem.Enabled = True
        DeleteRecordsWithDuplicateCodeAndDescriptionToolStripMenuItem.Enabled = True
        GenerateAFileToHaveAllTheWordsToolStripMenuItem.Enabled = True
        GenerateWorkOrderRecordFromTheToolStripMenuItem.Enabled = True

        LOGOFFToolStripMenuItem1.Visible = True



    End Sub

    Private Sub DisableAllOptions()
        PersonnelInformationSystemToolStripMenuItem.Visible = False
        PersonelFileToolStripMenuItem.Enabled = False

        ServiceDepartmentToolStripMenuItem.Visible = False
        CustomerServiceToolStripMenuItem.Enabled = False

        ProcurementSystemToolStripMenuItem.Visible = False


        LogisticsSystemToolStripMenuItem.Visible = False


        MaterialControlSystemToolStripMenuItem1.Visible = False
        ProductsToolStripMenuItem1.Enabled = False


        FinanceSystemToolStripMenuItem.Visible = False


        FilesToolStripMenuItem.Visible = False
        CustomersToolStripMenuItem1.Enabled = False
        CitiesToolStripMenuItem1.Enabled = False
        StatesToolStripMenuItem1.Enabled = False
        CountriesToolStripMenuItem1.Enabled = False
        VehicleTrimsToolStripMenuItem.Visible = False
        VehicleModelsToolStripMenuItem2.Enabled = False
        VehicleModelsRelationsToolStripMenuItem.Enabled = False
        VehicleMakesToolStripMenuItem1.Enabled = False
        VehicleDetailsToolStripMenuItem.Enabled = False
        VehiclesServicedToolStripMenuItem1.Enabled = False
        ConcernsToolStripMenuItem1.Enabled = False
        TypeOfConcernsToolStripMenuItem.Enabled = False
        UsersFileToolStripMenuItem.Enabled = False

        UtilitiesToolStripMenuItem.Visible = False

        FinanceSystemToolStripMenuItem.Visible = False
        UpdateToolStripMenuItem.Enabled = False
        DeleteRecordsWithDuplicateCodeAndDescriptionToolStripMenuItem.Enabled = False
        GenerateAFileToHaveAllTheWordsToolStripMenuItem.Enabled = False
        GenerateWorkOrderRecordFromTheToolStripMenuItem.Enabled = False

        LOGOFFToolStripMenuItem1.Visible = False

    End Sub
    Public Sub EnableServiceDepartmentToolStripMenuItemOnly()
        PersonnelInformationSystemToolStripMenuItem.Visible = False
        ProcurementSystemToolStripMenuItem.Visible = False
        LogisticsSystemToolStripMenuItem.Visible = False
        MaterialControlSystemToolStripMenuItem1.Visible = False
        FinanceSystemToolStripMenuItem.Visible = False
    End Sub

    Private Sub LOGOFFToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles LOGOFFToolStripMenuItem1.Click
        DisableAllOptions()
    End Sub
    Private Sub LOGINToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LOGINToolStripMenuItem.Click
        ShowLoginForm()
    End Sub

    Private Sub EXITSYSTEMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXITSYSTEMToolStripMenuItem.Click
        Application.Exit()

    End Sub

    Private Sub UpdateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateToolStripMenuItem.Click
        UpdateATableForm.Show()
    End Sub
    Private Sub GenerateWorkOrderRecordFromTheToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerateWorkOrderRecordFromTheToolStripMenuItem.Click
        GenerateRecordsForm.Show()
    End Sub
    Private Sub VehicleTrimsToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles VehicleTrimsToolStripMenuItem.Click
        Me.Enabled = False
        VehicleTrimsForm.ActivatedBy.Text = Me.Name
        VehicleTrimsForm.Show()

    End Sub
    Private Sub VehicleModelsToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles VehicleModelsToolStripMenuItem2.Click
        Me.Enabled = False
        VehicleModelsForm.ActivatedBy.Text = Me.Name
        VehicleModelsForm.Show()
    End Sub

    Private Sub VehicleModelsRelationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VehicleModelsRelationsToolStripMenuItem.Click
        Me.Enabled = False
        VehicleModelsRelationsForm.ActivatedBy.Text = Me.Name
        VehicleModelsRelationsForm.Show()
    End Sub

    Private Sub VehicleMakesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles VehicleMakesToolStripMenuItem1.Click
        Me.Enabled = False
        VehicleTypeForm.ActivatedBy.Text = Me.Name
        VehicleTypeForm.Show()

    End Sub

    Private Sub VehicleDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VehicleDetailsToolStripMenuItem.Click
        Me.Enabled = False
        VehicleDetailsForm.ActivatedBy.Text = Me.Name
        VehicleDetailsForm.Show()
    End Sub

    Private Sub VehiclesServicedToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles VehiclesServicedToolStripMenuItem1.Click
        Me.Enabled = False
        VehiclesServicedForm.ActivatedBy.Text = Me.Name
        VehiclesServicedForm.Show()
    End Sub
    Private Sub VehicleRepairClassToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VehicleRepairClassToolStripMenuItem.Click
        Me.Enabled = False
        VehicleRepairClassForm.ActivatedBy.Text = Me.Name
        VehicleRepairClassForm.Show()
    End Sub
    Private Sub CitiesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CitiesToolStripMenuItem1.Click
        Me.Enabled = False
        CityForm.ActivatedBy.Text = Me.Name
        CityForm.Show()
    End Sub

    Private Sub StatesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles StatesToolStripMenuItem1.Click
        Me.Enabled = False
        StateProvForm.ActivatedBy.Text = Me.Name
        StateProvForm.Show()
    End Sub

    Private Sub CountriesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CountriesToolStripMenuItem1.Click
        Me.Enabled = False
        CountryForm.ActivatedBy.Text = Me.Name
        Tunnel1 = "United States of America"
        CountryForm.Show()
    End Sub

    Private Sub CustomersToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CustomersToolStripMenuItem1.Click
        Me.Enabled = False
        OwnerForm.ActivatedBy.Text = Me.Name
        OwnerForm.Show()
    End Sub

    Private Sub ConcernsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ConcernsToolStripMenuItem1.Click
        Me.Enabled = False
        ConcernsForm.ActivatedBy.Text = Me.Name
        ConcernsForm.Show()
    End Sub
    Private Sub TypeOfConcernsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TypeOfConcernsToolStripMenuItem.Click
        Me.Enabled = False
        ConcernTypeForm.ActivatedByTextBox.Text = Me.Name
        ConcernTypeForm.Show()
    End Sub
    Private Sub WorkOrdersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WorkOrdersToolStripMenuItem.Click
        Me.Enabled = False
        WorkOrderForm.ActivatedBy.Text = Me.Name
        WorkOrderForm.Show()
    End Sub
    Private Sub MasterCodeBookToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MasterCodeBookToolStripMenuItem.Click
        Me.Enabled = False
        MasterCodeBookForm.ActivatedBy.Text = Me.Name
        MasterCodeBookForm.Show()
    End Sub
    Private Sub WorkOrderRegistrationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WorkOrderRegistrationToolStripMenuItem.Click
        ShowWorkOrderForm()
    End Sub
    Private Sub WorkOrdersToolStripMenuItem1_Click_1(sender As Object, e As EventArgs) Handles WorkOrdersToolStripMenuItem1.Click
        ShowWorkOrderForm()
    End Sub
    Private Sub ShowWorkOrderForm()         ' subjectnfor deletion
        Me.Enabled = False
        WorkOrderForm.ActivatedBy.Text = Me.Name
        WorkOrderForm.Show()
    End Sub
    Private Sub PartsRequisitionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PartsRequisitionsToolStripMenuItem.Click
        Me.Enabled = False
        ServiceTechnicianForm.ActivatedBy.Text = Me.Name
        ServiceTechnicianForm.Show()
    End Sub


    Private Sub JobsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JobsToolStripMenuItem.Click
        Me.Enabled = False
        WorkOrderConcernAnalysisForm.ActivatedBy.Text = Me.Name
        WorkOrderConcernAnalysisForm.Show()
    End Sub

    Private Sub PersonelFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PersonelFileToolStripMenuItem.Click
        Me.Enabled = False
        PersonnelForm.ActivatedByTextBox.Text = Me.Name
        PersonnelForm.Show()
    End Sub

    Private Sub MyStandardToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles MyStandardToolStripMenuItem1.Click
        Me.Enabled = False
        MyStandardForm.ActivatedByTextBox.Text = Me.Name
        MyStandardForm.Show()
    End Sub

    Private Sub PersonnelFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PersonnelFileToolStripMenuItem.Click
        Me.Enabled = False
        PersonnelForm.ActivatedByTextBox.Text = Me.Name
        PersonnelForm.Show()

    End Sub

    Private Sub DepartmentsFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DepartmentsFileToolStripMenuItem.Click
        Me.Enabled = False
        DepartmentsForm.ActivatedByTextBox.Text = Me.Name
        DepartmentsForm.Show()

    End Sub

    Private Sub JobPositionsFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JobPositionsFileToolStripMenuItem.Click
        Me.Enabled = False
        JobPositionsForm.ActivatedByTextBox.Text = Me.Name
        JobPositionsForm.Show()
    End Sub

    Private Sub UsersFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UsersFileToolStripMenuItem.Click ' enabled
        Me.Enabled = False
        UsersForm.ActivatedByTextBox.Text = Me.Name
        UsersForm.Show()

    End Sub

    Private Sub ServiceHeadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ServiceHeadToolStripMenuItem.Click
        Me.Enabled = False
        OwnerForm.ActivatedBy.Text = Me.Name
        OwnerForm.Show()

    End Sub

End Class
