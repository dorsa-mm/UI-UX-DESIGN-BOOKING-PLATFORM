﻿Public Class TimeBusForm
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim MI As New MainInterface()
        MI.Show()
        Me.Hide()
    End Sub
End Class