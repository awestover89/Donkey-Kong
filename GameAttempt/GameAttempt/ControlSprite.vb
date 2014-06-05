Public Class ControlSprite : Inherits Sprite

    Public Control As Control

    Public Sub New(ByVal controlIn As Control)
        Control = controlIn
        setHeightWidth()
    End Sub

    Public Overrides Sub Draw()
        Control.Location = New Point(CInt(Fix(Location.X + 0.5F)), CInt(Fix(Location.Y + 0.5F)))
        Control.Refresh()
    End Sub

    Protected Sub setHeightWidth()
        Size.Height = Control.Height
        Size.Width = Control.Width
    End Sub

End Class