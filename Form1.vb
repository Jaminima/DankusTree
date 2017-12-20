Public Class Form1
#Region "Timers"
    Private Sub TmrLight_Tick(sender As Object, e As EventArgs) Handles TmrLight.Tick
        Randomize()
        Dim DecorationImages As New List(Of String)({"red", "green", "lime", "orange", "Chartreuse", "Crimson", "Cyan", "yellow"})
        For Each Picture In Controls
            If Picture.GetType Is GetType(PictureBox) Then
                Dim Light As PictureBox = Picture
                If Light.Name = "Light" Then
                    Picture.BackColor = Color.FromName(DecorationImages(Rnd() * (DecorationImages.Count - 1)))
                End If
            End If
        Next
    End Sub

    Private Sub TmrClock_Tick(sender As Object, e As EventArgs) Handles TmrClock.Tick
        LblCountDown.Text = CStr(25 - DateAndTime.Now.Day) & " Days : " &
            CStr(24 - DateAndTime.Now.Hour) & " Hours : " &
            CStr(60 - DateAndTime.Now.Minute) & " Min's : " &
            CStr(60 - DateAndTime.Now.Second) & " Sec's"
    End Sub

    Private Sub TmrSnowMove_Tick(sender As Object, e As EventArgs) Handles TmrSnowMove.Tick
        For Each Control In Controls
            If Control.GetType Is GetType(PictureBox) Then
                Dim SnowPic As PictureBox = Control
                If SnowPic.Name.Contains("Snow") Then
                    SnowPic.Top += 5
                    If SnowPic.Top >= 672 Then
                        SnowPic.Location = New Point(Rnd() * 570, 0)
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each Control In Controls
            If Control.GetType Is GetType(PictureBox) Then
                If Control.Location.X = 3 Then
                    Control.Name = "Snow"
                    Control.BackColor = Color.FromName("White")
                    Control.Location = New Point(-10, Control.Location.Y)
                ElseIf Control.Name <> "PictureXmasTree" And Not Control.Name.Contains("Snow") Then
                    Control.Name = "Light"
                End If
            End If
        Next
    End Sub

    Private Sub TmrOther_Tick(sender As Object, e As EventArgs) Handles TmrOther.Tick
        If KeepOnTop = True Then
            Me.TopMost = True
        ElseIf KeepOnTop = False Then
            Me.TopMost = False
        End If

        If ShowSnow = False Then
            For Each Control In Controls
                If Control.Name = "Snow" Then
                    Control.Visible = False
                End If
            Next
        ElseIf ShowSnow = True Then
            For Each Control In Controls
                If Control.Name = "Snow" Then
                    Control.Visible = True
                End If
            Next
        End If

        If ShowClock = True Then
            LblCountDown.Visible = True
        ElseIf ShowClock = False Then
            LblCountDown.Visible = False
        End If

        If ShowLights = True Then
            For Each Control In Controls
                If Control.Name = "Light" Then
                    Control.Visible = True
                End If
            Next
        ElseIf ShowLights = False Then
            For Each Control In Controls
                If Control.Name = "Light" Then
                    Control.Visible = False
                End If
            Next
        End If

    End Sub
#End Region
#Region "Buttons"
    Dim KeepOnTop = False,
        ShowSnow = True,
        ShowClock = True,
        ShowLights = True

    Private Sub BtnKeepOnTop_Click(sender As Object, e As EventArgs) Handles BtnKeepOnTop.Click
        If KeepOnTop = True Then
            KeepOnTop = False
            BtnKeepOnTop.BackColor = Color.DarkRed
        ElseIf KeepOnTop = False Then
            KeepOnTop = True
            BtnKeepOnTop.BackColor = Color.Green
        End If
    End Sub

    Private Sub BtnLights_Click(sender As Object, e As EventArgs) Handles BtnLights.Click
        If ShowLights = True Then
            ShowLights = False
            BtnLights.BackColor = Color.DarkRed
        ElseIf ShowLights = False Then
            ShowLights = True
            BtnLights.BackColor = Color.Green
        End If
    End Sub

    Private Sub BtnSnow_Click(sender As Object, e As EventArgs) Handles BtnSnow.Click
        If ShowSnow = True Then
            ShowSnow = False
            BtnSnow.BackColor = Color.DarkRed
        ElseIf ShowSnow = False Then
            ShowSnow = True
            BtnSnow.BackColor = Color.Green
        End If
    End Sub

    Private Sub BtnClock_Click(sender As Object, e As EventArgs) Handles BtnClock.Click
        If ShowClock = True Then
            ShowClock = False
            BtnClock.BackColor = Color.DarkRed
        ElseIf ShowClock = False Then
            ShowClock = True
            BtnClock.BackColor = Color.Green
        End If
    End Sub
#End Region
End Class
