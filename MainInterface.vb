﻿Public Class MainInterface

    Public trips As New List(Of Trip)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If trips.Count = 0 Then
            Button1.Enabled = False
            PilotBtn.Enabled = False
        Else
            Button1.Enabled = True
            PilotBtn.Enabled = True
        End If
    End Sub

    Private Sub btnCreateTour_Click(sender As Object, e As EventArgs) Handles btnCreateTour.Click
        Me.Hide()
        Dim CreateTour As New CreateTour()
        AddHandler CreateTour.Confirm, AddressOf AddTrip
        AddHandler CreateTour.CloseCreate, AddressOf ClosedCreatedTour
        CreateTour.Show()
    End Sub

    Private Sub ClosedCreatedTour()
        If trips.Count = 0 Then
            Button1.Enabled = False
            PilotBtn.Enabled = False
        Else
            Button1.Enabled = True
            PilotBtn.Enabled = True
        End If
        Show()
    End Sub
    Private Sub AddTrip(trip As Trip)
        Show()
        trips.Add(trip)
        If trips.Count = 0 Then
            Button1.Enabled = False
            PilotBtn.Enabled = False
        Else
            Button1.Enabled = True
            PilotBtn.Enabled = True
        End If
    End Sub

    Private Sub btnModifyTour_Click(sender As Object, e As EventArgs) Handles btnModifyTour.Click
        Dim selectTour As New SelectTour(trips, True, False)
        AddHandler selectTour.Confirm, AddressOf UpdateTrip
        selectTour.Show()
        Hide()
    End Sub

    Private Sub UpdateTrip(newTrip As Trip)
        Dim index As Integer = trips.FindIndex(Function(t) t.guid = newTrip.guid)
        If index >= 0 Then
            trips(index) = newTrip
        End If
        Show()
        If trips.Count = 0 Then
            Button1.Enabled = False
            PilotBtn.Enabled = False
        Else
            Button1.Enabled = True
            PilotBtn.Enabled = True
        End If
    End Sub

    Private Sub btnCopyTour_Click(sender As Object, e As EventArgs) Handles btnCopyTour.Click
        Dim CopyTour As New ExistingTrip()
        CopyTour.Show()
        Me.Hide()
    End Sub

    Private Sub btnCloseAll_Click(sender As Object, e As EventArgs) Handles btnCloseAll.Click
        ' Loop through all open forms and close them
        For Each frm As Form In Application.OpenForms
            If Not frm.Equals(Me) Then
                frm.Close() ' Close all forms except the current form
            End If
        Next
        Application.Exit()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim selectTour As New SelectTour(trips, False, False)
        AddHandler selectTour.TourEnd, AddressOf EndTour
        selectTour.Show()
        Hide()
    End Sub

    Private Sub PilotBtn_Click(sender As Object, e As EventArgs) Handles PilotBtn.Click
        Dim selectTour As New SelectTour(trips, False, True)
        AddHandler selectTour.TourEnd, AddressOf EndTour
        selectTour.Show()
        Hide()
    End Sub

    Private Sub EndTour()
        Show()
        If trips.Count = 0 Then
            Button1.Enabled = False
            PilotBtn.Enabled = False
        Else
            Button1.Enabled = True
            PilotBtn.Enabled = True
        End If
    End Sub
End Class
