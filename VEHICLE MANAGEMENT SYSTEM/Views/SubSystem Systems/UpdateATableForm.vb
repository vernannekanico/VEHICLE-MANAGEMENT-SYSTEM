Imports System.Data.SqlClient

Public Class UpdateATableForm
    Private SavedCallingForm As Form
    Private Sub StartForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SavedCallingForm = CallingForm
        Me.Width = VehicleManagementSystemForm.Width - 4
        Me.Height = VehicleManagementSystemForm.Height - (VehicleManagementSystemForm.VehicleManagementMenuStrip.Top - VehicleManagementSystemForm.VehicleManagementMenuStrip.Height)
        Me.Top = BottomOf(VehicleManagementSystemForm.VehicleManagementMenuStrip)
        Me.Left = 1
    End Sub
    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        DoCommonHouseKeeping(Me, SavedCallingForm)
    End Sub

    Private Sub UpdateProductPackingRelationOfTheWorkOrderRequestedPartsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles UpdateProductPackingRelationOfTheWorkOrderRequestedPartsToolStripMenuItem1.Click
        ShowCalledForm(Me, DirectUpdateOfWorkOrderIssuedPartsForm)
    End Sub

    Private Sub UpdatteATableStabdardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdatteATableStabdardToolStripMenuItem.Click
        ShowCalledForm(Me, DirectUpdateATableStandardForm)
    End Sub
    ' ARCHIVED FORMS
    '       ShowCalledForm(Me, DirectUpdateOfWorkOrderRequestedPartsTableForm)
End Class