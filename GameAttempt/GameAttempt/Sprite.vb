Public Class Sprite
    Public Velocity As PointF
    Public Location As PointF
    Public Size As SizeF

    Public Sub New()
    End Sub

    Public Sub New(ByVal x As Single, ByVal y As Single, ByVal width As Single, ByVal height As Single)
        Location.X = x
        Location.Y = y
        Size.Width = width
        Size.Height = height
    End Sub

    Public Overridable Sub Update(ByVal gameTime As Double, ByVal elapsedTime As Double)
        'Move the sprite based on the velocity
        Location.X += Velocity.X * CSng(elapsedTime)
        Location.Y += Velocity.Y * CSng(elapsedTime)
    End Sub

    Public Overridable Sub Draw()
        'Default behaviour right now is to do nothing. Inherited classes will do their own drawing
    End Sub


End Class