

Public Class Ladder : Inherits ControlSprite

    Private Const Width = 15
    Private isBreakable As Boolean
    Private c As Control

    Public Sub New(ByVal control As Control, ByVal h As Integer, ByVal x As Integer, ByVal y As Integer, ByVal breakable As Boolean)
        MyBase.New(control)
        c = control
        c.Height = h
        c.Width = Width
        c.BackgroundImage = My.Resources.LadderImg

        setHeightWidth()

        isBreakable = breakable
        Location.X = CSng(x)
        Location.Y = CSng(y)

        break()
    End Sub

    Public Function isBroken() As Boolean
        Return isBreakable
    End Function

    Public Sub break()
        If isBreakable Then
            c.BackgroundImage = My.Resources.LadderBroken
        End If
    End Sub

End Class
