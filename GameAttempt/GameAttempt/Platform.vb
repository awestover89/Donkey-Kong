Public Class Platform : Inherits ControlSprite

    Public Const Width As Integer = 15
    Public Const Height As Integer = 5
    Public Const GapSize As Integer = 26
    Private Shared Color As Color = Color.Red

    Private row As Integer
    Private col As Integer


    Public Sub New(ByVal control As Control, ByVal r As Integer, ByVal c As Integer)
        MyBase.New(control)
        row = r
        col = c

        Location.X = CSng(col * Width)
        Location.Y = CSng(row * Height) + row * GapSize

        control.BackColor = Color
        control.Width = Width
        control.Height = Height

        setHeightWidth()
    End Sub

    Public Sub drop()
        If row Mod 2 = 0 Then
            Location.Y = Location.Y + CSng(10 - (col / 4))
        Else
            Location.Y = Location.Y + CSng(col / 4)
        End If

    End Sub

End Class
