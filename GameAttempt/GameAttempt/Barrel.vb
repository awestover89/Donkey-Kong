Public Class Barrel : Inherits ControlSprite

    Private Const Height = 5
    Private Const Width = 5
    Private Shared Color As Color = Color.Black
    Private Const speed As Double = 15

    Public MaxPositionX As Single
    Public MinPositionX As Single = 0
    Public MaxPositionY As Single

    Private direction As Integer = 1
    Private isDropping As Boolean = False
    Public isDestroyed = False
    Private row As Integer = 1

    Private killOnSight As Character


    Private ladders(18) As Ladder

    Public Sub New(ByVal control As Control, ByVal maxX As Single, ByVal maxY As Single, ByVal l As Ladder(), ByRef kos As Character)
        MyBase.New(control)
        control.Height = Height
        control.Width = Width
        setHeightWidth()
        control.BackColor = Color

        MaxPositionX = maxX
        MaxPositionY = maxY

        ladders = l

        Location.X = CSng(80)
        Location.Y = CSng(30)

        killOnSight = kos

    End Sub

    Public Overrides Sub Update(ByVal gameTime As Double, ByVal elapsedTime As Double)
        move()

        MyBase.Update(gameTime, elapsedTime)

        If Location.X < MinPositionX Then
            Location.X = MinPositionX
        End If
        If Location.X > MaxPositionX - Width Then
            Location.X = MaxPositionX - Width
        End If
        If row = 8 Then
            Location.Y = MaxPositionY - Height
            If Location.X = MinPositionX Then
                Location.X = CSng(80)
                Location.Y = CSng(30)
                direction = 0
                isDestroyed = True
                Me.Control.BackColor = Color.Empty
            End If
        End If
    End Sub

    Private Function aboveLadder() As Boolean
        For i = 0 To 17
            If Not (Location.X > ladders(i).Location.X + ladders(i).Size.Width OrElse Location.X + Size.Width < ladders(i).Location.X) Then
                If Not (Location.Y + Height + 2 > ladders(i).Location.Y + ladders(i).Size.Height OrElse Location.Y + Height + 2 < ladders(i).Location.Y) Then
                    If i = 2 Or i = 3 Or i = 7 Or i = 8 Or i = 12 Or i = 13 Or i = 17 Then
                        ladders(i).Draw()
                        isDropping = True
                        'MessageBox.Show("ABOVE A LADDER")
                        Return True
                    End If
                End If
            End If
        Next
        Return False
    End Function

    Private Sub move()
        kill()
        Dim workingVelocityY As Double = 0.0
        Dim workingVelocityX As Double = 0.0

        aboveLadder()

        If Not isDropping Then
            workingVelocityX += speed * direction
        ElseIf aboveLadder() Then
            workingVelocityY += speed
        Else
            direction = direction * -1
            isDropping = False
            row += 1
        End If

        Velocity.Y = CSng(workingVelocityY)
        Velocity.X = CSng(workingVelocityX)
    End Sub

    Private Sub kill()
        If Not (Location.X > killOnSight.Location.X + killOnSight.Size.Width OrElse Location.X + Size.Width < killOnSight.Location.X OrElse Location.Y > killOnSight.Location.Y + killOnSight.Size.Height OrElse Location.Y + Size.Height < killOnSight.Location.Y) Then
            My.Computer.Audio.Play(My.Resources.dk_die, AudioPlayMode.WaitToComplete)
            MessageBox.Show("You have been killed. Better Luck Next Time!")
            Application.Exit()
            Application.Restart()
        End If
    End Sub

End Class
