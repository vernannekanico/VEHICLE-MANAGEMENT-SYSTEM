Public Class ServiceTechnicianForm

    Private Sub WorkOrderCompletionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub ServiceTechnicianForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        'Fills up tunnel1, tunnel2
        'Enables calling form
        ActivatedBy.Text = ""

    End Sub

    Private Sub ServiceTechnicianForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub ServiceTechnicianForm_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        'Refresh datagridviw here
        ' GET RETURNED DATA HERE

    End Sub
End Class