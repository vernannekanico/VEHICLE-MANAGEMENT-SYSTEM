Imports excel = Microsoft.Office.Interop.Excel
Module MyGlobalDeclarations

    Public MySelection As String = ""
    Public CurrentRecord As Integer
    Public RecordCount As Integer
    Public DefaultSystemPath = My.Computer.FileSystem.CurrentDirectory
    Public CurrentPersonnelName As String = "" ' name of employee
    Public CurrentUserGroup As String = "" ' name of employee
    Public CurrentDepartment As String = "" ' User s department
    Public CurrentUserName As String = ""      ' login name
    Public CurrentUserID As Integer = -1
    Public CurrentPersonelID As Integer = -1
    Public CurrentPassword As String = ""
    Public CurrentVehicleID As Integer = -1
    Public CurrentCodeVehicleID As Integer = -1
    Public CurrentVehicleString = ""
    Public CurrentWorkOrderID As Integer = -1
    Public DataGridViewRowHeight = 22
    Public RecordFinderDbControls As New MyDbControls
    Public Tunnel1 As String = ""
    Public Tunnel2 As Integer = -1
    Public Tunnel3 As String = ""
    Public Tunnel4 As String = ""
    Public DefaultStateName = "California"
    Public DefaultCountryName = "United States of America"
    Public SearchTextBoxNormalBackColor = "{Name=Window, ARGB=(255, 255, 255, 255)}"
    Public SearchTextBoxNormalForeColor = "{Name=WindowText, ARGB=(255, 0, 0, 0)}"
    Public SearchTextBoxHighlightBackColor = "{Name=Window, ARGB=(255, 255, 255, 255)}"
    Public SearchTextBoxHighLightForeColor = "{Name=WindowText, ARGB=(255, 0, 0, 0)}"
    Public CurrentVehicleRepairClassID As Integer = -1
    Public EnableMenus = False
    Public CallingForm As Form
    Public r As DataRow
    Public ShowInTaskbarFlag = False
    Public ActiveFormQueue = ""

End Module
