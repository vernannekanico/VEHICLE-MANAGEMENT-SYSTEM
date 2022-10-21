Public Class VehicleManagementSystemForm
    Private CurrentUsersDataGridViewRow = -1
    Private UserAccessRecordCount = -1
    Private Sub VehicleManagementSystemForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        DefaultSystemPath = Replace(DefaultSystemPath, "\bin\Debug", "")
        Me.Text = Me.Text + " in " + DefaultSystemPath
        Me.Size = (My.Computer.Screen.WorkingArea.Size)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.WindowState = FormWindowState.Maximized
        LoadRegisteredUsers()
    End Sub

    Private Sub LoadRegisteredUsers()
        MySelection = "Select UserName_ShortText50 FROM UsersTable "
        JustExecuteMySelection()
        UsersDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        UsersDataGridView.Top = 50
        UsersDataGridView.Columns.Item("UserName_ShortText50").HeaderText = "Temp Users (development stage)"
        UsersDataGridView.Columns.Item("UserName_ShortText50").Width = 300
        UsersDataGridView.Visible = True
        UsersDataGridView.Left = Me.Width - UsersDataGridView.Width - 100
    End Sub

    Private Sub ShowLoginForm()
        Me.Enabled = False
        LoginForm.Show()
    End Sub
    Private Sub VehicleManagementSystemForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        CallingForm = Me
        If Me.Enabled = False Then Exit Sub
        UsersDataGridView.Visible = False
        EnableMenus = True
        LOGOFFToolStripMenuItem.Visible = True
        LOGINToolStripMenuItem.Visible = False
        SetupSystemAccess()
        Dim xxHelloMessage = "Hello " & CurrentPersonnelName
        Me.Text = "VEHICLE REPAIR AND MAINTENANCE MANAGEMENT SYSTEM " & Space(175) & "Hello " & CurrentPersonnelName

    End Sub
    Private Sub SetupSystemAccess()

        MySelection = "
SELECT 
FormNamesTable.FormName_ShortText30, 
SystemMenusTable.MenuName_ShortText100, 
SystemMenusTable.MenuText_ShortText100, 
SystemMenusTable.FormToOpenShortText100, 
SystemMenusTable.MenuLevel1_LongInteger, 
SystemMenusTable.MenuLevel2_LongInteger, 
SystemMenusTable.MenuLevel3_LongInteger, 
DepartmentsTable.DepartmentName_ShortText35, 
JobPositionsTable.JobPositionName_ShortText40, 
PermissionsTable.PermissionID_Autonumber
FROM (((PermissionsTable LEFT JOIN SystemMenusTable ON PermissionsTable.SystemMenuID_LongInteger = SystemMenusTable.SystemMenuID_Autonumber) LEFT JOIN JobPositionsTable ON PermissionsTable.JobPositionID_LongInteger = JobPositionsTable.JobPositionID_AutoNumber) LEFT JOIN FormNamesTable ON SystemMenusTable.FormNameID_LongInteger = FormNamesTable.FormNameID_AutoNumber) LEFT JOIN DepartmentsTable ON JobPositionsTable.DepartmentID_LongInteger = DepartmentsTable.DepartmentID_AutoNumber
" & " WHERE FormName_ShortText30 = " & InQuotes(Me.Name) &
" AND JobPositionName_ShortText40 = " & InQuotes(CurrentUserGroup)
        JustExecuteMySelection()
        UsersDataGridView.DataSource = RecordFinderDbControls.MyAccessDbDataTable
        Dim MenuName_ShortText100 = ""
        For i = 0 To RecordCount - 1
            MenuName_ShortText100 = UsersDataGridView.Item("MenuName_ShortText100", i).Value
            Select Case MenuName_ShortText100
                Case "SystemsDepartmentToolStripMenuItem"
                    EnableMenu(SystemsDepartmentToolStripMenuItem)
                Case "ManagementDepartmentToolStripMenuItem"
                    EnableMenu(ManagementDepartmentToolStripMenuItem)
                Case "ServicesDepartmentToolStripMenuItem"
                    EnableMenu(ServicesDepartmentToolStripMenuItem)
                Case "FinanceDepartmentToolStripMenuItem"
                    EnableMenu(FinanceDepartmentToolStripMenuItem)
                Case "PersonnelDepartMentToolStripMenuItem"
                    EnableMenu(PersonnelDepartmentToolStripMenuItem)
                Case "UtilitiesToolStripMenuItem"
                    EnableMenu(UtilitiesToolStripMenuItem)
                Case "DirectlyUpdateTableToolStripMenuItem"
                    EnableMenu(DirectlyUpdateTableToolStripMenuItem)
                Case "GenerateWorkOrderRecordFromTheToolStripMenuItem"
                    EnableMenu(GenerateWorkOrderRecordFromTheToolStripMenuItem)
                Case "TestTemporaryFormToolStripMenuItem"
                    EnableMenu(TestTemporaryFormToolStripMenuItem)
                Case "ManagementDepartmentToolStripMenuItem"
                    EnableMenu(ManagementDepartmentToolStripMenuItem)
                Case "ServicesDepartmentToolStripMenuItem"
                    EnableMenu(ServicesDepartmentToolStripMenuItem)
                Case "CustomerServiceToolStripMenuItem"
                    EnableMenu(CustomerServiceToolStripMenuItem)
                Case "WorkOrderRegistrationToolStripMenuItem"
                    EnableMenu(WorkOrderRegistrationToolStripMenuItem)
                Case "VehicleReleaseToolStripMenuItem"
                    EnableMenu(VehicleReleaseToolStripMenuItem)
                Case "ServiceAppointmentToolStripMenuItem"
                    EnableMenu(ServiceAppointmentToolStripMenuItem)
                Case "JobReturnToolStripMenuItem"
                    EnableMenu(JobReturnToolStripMenuItem)
                Case "VehicleRepairToolStripMenuItem"
                    EnableMenu(VehicleRepairToolStripMenuItem)
                Case "WorkOrdersToolStripMenuItem"
                    EnableMenu(WorkOrdersToolStripMenuItem)
                Case "CustomerInfoSysToolStripMenuItem"
                    EnableMenu(CustomerInfoSysToolStripMenuItem)
                Case "VehicleInformationsToolStripMenuItem"
                    EnableMenu(VehicleInformationsToolStripMenuItem)
                Case "MasterCodeBookToolStripMenuItem"
                    EnableMenu(MasterCodeBookToolStripMenuItem)
                Case "FinanceDepartmentToolStripMenuItem"
                    EnableMenu(FinanceDepartmentToolStripMenuItem)
                Case "PersonnelDepartMentToolStripMenuItem"
                    EnableMenu(PersonnelDepartmentToolStripMenuItem)
                Case "ProcurementDepartmentToolStripMenuItem"
                    EnableMenu(ProcurementDepartmentToolStripMenuItem)
                Case "LogisticsDepartmentToolStripMenuItem"
                    EnableMenu(LogisticsDepartmentToolStripMenuItem)
                Case "WarehouseDepartmentToolStripMenuItem"
                    EnableMenu(WarehouseDepartmentToolStripMenuItem)
                Case "RequisitionsforPurchaseToolStripMenuItem"
                    EnableMenu(RequisitionsforPurchaseToolStripMenuItem)
                Case "InventoryToolStripMenuItem"
                    EnableMenu(InventoryToolStripMenuItem)
                Case "DeliveriesStripMenuItem"
                    EnableMenu(DeliveriesStripMenuItem)

                Case "ReleasePartsStripMenuItem"
                    EnableMenu(ReleasePartsStripMenuItem)
            End Select
        Next
    End Sub

    Private Sub LOGOFFToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles LOGOFFToolStripMenuItem.Click
        EnableMenus = False
        SetupSystemAccess()
        LOGOFFToolStripMenuItem.Visible = False
        LOGINToolStripMenuItem.Visible = True
        Me.Text = "VEHICLE REPAIR AND MAINTENANCE MANAGEMENT SYSTEM " & Space(175) & "Hello "
    End Sub
    Private Sub LOGINToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LOGINToolStripMenuItem.Click
        EnableMenus = True
        LOGINToolStripMenuItem.Visible = False
        LoadRegisteredUsers()
    End Sub

    Private Sub EXITSYSTEMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXITSYSTEMToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub GenerateWorkOrderRecordFromTheToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerateWorkOrderRecordFromTheToolStripMenuItem.Click
        GenerateRecordsForm.Show()
    End Sub
    Private Sub WorkOrderRegistrationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WorkOrderRegistrationToolStripMenuItem.Click
        ShowWorkOrderForm()
    End Sub
    Private Sub WorkOrdersServiceDeptVehicleRepairToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WorkOrdersToolStripMenuItem.Click
        ShowWorkOrderForm()
    End Sub
    Private Sub ShowWorkOrderForm()
        Me.Enabled = False
        Select Case CurrentUserGroup
            Case "Customer Relations Specialist"
                ShowCalledForm(Me, WorkOrderFormCRS)
            Case Else
                ShowCalledForm(Me, WorkOrderFormASM)
        End Select
    End Sub
    Private Sub PartsRequisitionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllServicedVehiclesOfServicesToolStripMenuItem.Click
        ShowCalledForm(Me, VehiclesServicedForm)
    End Sub



    Private Sub PersonelFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PersonnelsInformationFilesToolStripMenuItem.Click
        ShowCalledForm(Me, PersonnelsForm)
    End Sub
    Private Sub TestTemporaryFormToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestTemporaryFormToolStripMenuItem.Click
        TemporaryForThisProjectForm.Show()
    End Sub
    Private Sub PartsForDeliveriesStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReleasePartsStripMenuItem.Click
        ShowCalledForm(Me, WorkOrderPartsRequisitionsForm)
    End Sub


    Private Sub UsersDataGridView_DoubleClick(sender As Object, e As EventArgs) Handles UsersDataGridView.DoubleClick

        LoginForm.UsernameTextBox.Text = UsersDataGridView.Item("UserName_ShortText50", CurrentUsersDataGridViewRow).Value
        ShowLoginForm()

    End Sub

    Private Sub UsersDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles UsersDataGridView.RowEnter
        If e.RowIndex < 0 Then Exit Sub
        CurrentUsersDataGridViewRow = e.RowIndex
    End Sub

    Private Sub PurchaseOrderToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PurchaseOrderToolStripMenuItem1.Click
        ShowCalledForm(Me, PurchaseOrdersForm)
    End Sub

    Private Sub RToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RToolStripMenuItem.Click
        ShowCalledForm(Me, RequisitionsForm)
    End Sub

    Private Sub StoreSuppliesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StoreSuppliesToolStripMenuItem.Click
        ShowCalledForm(Me, StoreRequisitionsForm)
    End Sub

    Private Sub InventoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InventoryToolStripMenuItem.Click
        Tunnel3 = 2
        ShowCalledForm(Me, ProductsPartsForm)
    End Sub

    Private Sub FromCustomersToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub


    Private Sub CustomerInfoSysToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomerInfoSysToolStripMenuItem.Click
        ShowCalledForm(Me, OwnersForm)
    End Sub

    Private Sub VehiclesModelsRelationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VehiclesModelsRelationsToolStripMenuItem.Click
        ShowCalledForm(Me, VehicleModelsRelationsForm)
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles MasterCodeBookToolStripMenuItem.Click
        ShowCalledForm(Me, MasterCodeBookForm)
    End Sub

    Private Sub UpdateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DirectlyUpdateTableToolStripMenuItem.Click
        ShowCalledForm(Me, UpdateATableForm)
    End Sub

    Private Sub DeliveriesStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeliveriesStripMenuItem.Click
        ShowCalledForm(Me, StockLocationsForm)
        '        ShowCalledForm(Me, DeliveriesForm)
    End Sub

    Private Sub UpdateStatusTablesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateStatusTablesToolStripMenuItem.Click
        ShowCalledForm(Me, StatusForm)
    End Sub
    Private Sub ProductsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ProductsToolStripMenuItem1.Click
        ShowCalledForm(Me, ProductsPartsForm)
    End Sub

    Private Sub ProductsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductsToolStripMenuItem.Click

    End Sub
End Class
