Public Class DonkeyKong : Inherits ControlSprite

    Private c As Control

    Public Sub New(ByVal control As Control)
        MyBase.New(control)
        control.BackgroundImage = My.Resources.DonkeyKong
        Location = New Point(62, 1)
        c = control
    End Sub

    Public Sub jump()
        For i = 1 To 5
            c.Location = New Point(c.Location.X, c.Location.Y - 3)
            System.Threading.Thread.Sleep(50)
        Next
        'System.Threading.Thread.Sleep(1000)
        For j = 1 To 15
            Draw()
            c.Location = New Point(c.Location.X, c.Location.Y + 1)
            System.Threading.Thread.Sleep(50)
        Next
        Draw()
    End Sub

End Class
