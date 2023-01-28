
Public Class ConsumablesForm
    Private ConsumablesCodeBook As New MasterCodeBookForm

    Private Sub ConsumablesForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Visible = False
        ConsumablesCodeBook.Show()
        ConsumablesCodeBook.Text = "CONSUMABLES : Attach " & Tunnel3 & " to its consumable part"

        Me.Close()
    End Sub
End Class