Public Class Character : Inherits ControlSprite

    Private _upKey As Keys
    Private _downKey As Keys
    Private _leftKey As Keys
    Private _rightKey As Keys
    Private _isUpKeyPressed As Boolean
    Private _isDownKeyPressed As Boolean
    Private _isLeftKeyPressed As Boolean
    Private _isRightKeyPressed As Boolean

    Private ladders(18) As Ladder
    Private platforms(140) As Platform
    Private row = 7

    Private _isJumping As Boolean
    Private _initY As Single = 0

    Public MaxPositionX As Single
    Public MinPositionX As Single
    Public MaxPositionY As Single
    Public MinPositionY As Single

    Public Const Width As Integer = 10
    Public Const Height As Integer = 10
    Private Shared Color As Color = Color.DarkSlateBlue
    Private Const _speed As Double = 40

    Public Sub New(ByVal control As Control, ByVal maxPosX As Single, ByVal maxPosY As Single)
        MyBase.New(control)
        control.BackgroundImage = My.Resources.Mario
        MaxPositionX = maxPosX
        MaxPositionY = maxPosY
        MinPositionX = 0
        MinPositionY = 0

        Location.X = 10
        Location.Y = maxPosY

        control.BackColor = Color
        control.Width = Width
        control.Height = Height

        setHeightWidth()

        _upKey = Keys.Up
        _downKey = Keys.Down
        _leftKey = Keys.Left
        _rightKey = Keys.Right

    End Sub

    Public Overrides Sub Update(ByVal gameTime As Double, ByVal elapsedTime As Double)
        processMove()

        MyBase.Update(gameTime, elapsedTime)

        If Location.Y < MinPositionY Then
            Location.Y = MinPositionY
        End If
        If Location.Y > MaxPositionY - Height Then
            Location.Y = MaxPositionY - Height
        End If
        If Location.X < MinPositionX Then
            Location.X = MinPositionX
        End If
        If Location.X > MaxPositionX - Width Then
            Location.X = MaxPositionX - Width
        End If
    End Sub

    Public Sub setLadders(ByRef ladders() As Ladder)
        Me.ladders = ladders
    End Sub

    Public Function hasWon() As Boolean
        If Location.Y < 30 And Location.X < MaxPositionX / 2 Then
            Return True
        End If
        Return False
    End Function

    Private Sub processMove()
        Dim workingVelocityY As Double = 0.0
        Dim workingVelocityX As Double = 0.0

        If Not collision() And Not _isJumping And Not Location.Y < onPlatform() Then
            workingVelocityY += _speed / 2
        End If

        If _isJumping Then
            'jumpDown()
            If Location.Y >= _initY Then
                _isJumping = False
            Else
                workingVelocityY += _speed / 4
            End If
        End If

        If _isUpKeyPressed Then
            If collision() Then
                workingVelocityY -= _speed
            ElseIf Not _isJumping Then
                jumpUp()
            End If
        End If
        If _isDownKeyPressed Then
            If aboveLadder() Then
                workingVelocityY += _speed
            End If
        End If
        If _isLeftKeyPressed Then
            workingVelocityX += -_speed
        End If
        If _isRightKeyPressed Then
            workingVelocityX += _speed
        End If
        Velocity.Y = CSng(workingVelocityY)
        Velocity.X = CSng(workingVelocityX)
    End Sub

    Private Sub jumpUp()
        _initY = CSng(Location.Y)
        Location.Y = Location.Y - 8
        _isJumping = True
    End Sub

    Private Sub jumpDown()
        If Location.Y >= _initY Then
            _isJumping = False
        Else
            Velocity.Y = CSng(_speed)
        End If
    End Sub

    Private Function collision() As Boolean
        For i = 0 To 17
            If Not (Location.X > ladders(i).Location.X + ladders(i).Size.Width OrElse Location.X + Size.Width < ladders(i).Location.X OrElse Location.Y > ladders(i).Location.Y + ladders(i).Size.Height OrElse Location.Y + Size.Height < ladders(i).Location.Y) Then
                ladders(i).Draw()
                If Not (ladders(i).isBroken) Then
                    _isJumping = False
                    Return True
                End If
            End If
        Next
        Return False
    End Function

    Private Function aboveLadder() As Boolean
        For i = 0 To 17
            If Not (Location.X > ladders(i).Location.X + ladders(i).Size.Width OrElse Location.X + Size.Width < ladders(i).Location.X) Then
                If Not (Location.Y + Height + 2 > ladders(i).Location.Y + ladders(i).Size.Height OrElse Location.Y + Height + 2 < ladders(i).Location.Y) Then
                    ladders(i).Draw()
                    Return True
                End If
            End If
        Next
        Return False
    End Function

    Public Sub KeyDown(ByVal keys As Keys)

        If keys = _upKey Then
            _isUpKeyPressed = True
        End If
        If keys = _downKey Then
            _isDownKeyPressed = True
        End If
        If keys = _leftKey Then
            _isLeftKeyPressed = True
        End If
        If keys = _rightKey Then
            _isRightKeyPressed = True
        End If
    End Sub

    Public Sub KeyUp(ByVal keys As Keys)

        If keys = _upKey Then
            _isUpKeyPressed = False
            'If _isJumping Then
            '    jumpDown()
            'End If
            'If Not _isJumping Then
            '    jumpUp()
            'End If
        End If
        If keys = _downKey Then
            _isDownKeyPressed = False
        End If
        If keys = _leftKey Then
            _isLeftKeyPressed = False
        End If
        If keys = _rightKey Then
            _isRightKeyPressed = False
        End If
    End Sub

    Public Sub setPlatforms(ByRef p() As Platform)
        platforms = p
    End Sub


    Private Function onPlatform() As Single
        For i = 0 To 139
            If Location.Y > platforms(i).Location.Y Then
                i += 19
                Continue For
            End If
            If Not (Location.X > platforms(i).Location.X + platforms(i).Size.Width OrElse Location.X + Size.Width < platforms(i).Location.X OrElse Location.Y > platforms(i).Location.Y + platforms(i).Size.Height OrElse Location.Y + Size.Height < platforms(i).Location.Y) Then
                platforms(i).Draw()
                Return platforms(i).Location.Y
            End If
        Next
        Return Location.Y
    End Function
End Class
