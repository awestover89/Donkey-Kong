Public Class Pauline : Inherits ControlSprite

    Public Sub New(ByVal control As Control)
        MyBase.New(control)
        control.BackgroundImage = My.Resources.Pauline
    End Sub

End Class
