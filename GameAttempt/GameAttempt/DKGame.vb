Public Class DKGame : Inherits Form

    Private _timer As Stopwatch = New Stopwatch()
    Private _lastTime As Double
    Private _lastBarrel As Double
    Private _frameCounter As Long

    Private _player As Character
    Private _dk As DonkeyKong
    Private _platforms(140) As Platform
    Private _ladders(18) As Ladder
    Private _barrels(100) As Barrel
    Private _damsel As Pauline

    'Private doneWithNew As Boolean = False
    'Private throughPaint As Boolean = False

    Private nextAvail As Integer = 0
    Private nextBarrel As Integer = 0
    Private barrelsOnScreen As Integer = 0

    Public Sub New()
        InitializeComponent()
        'dkPBox.BackgroundImage = My.Resources.DonkeyKong
        _dk = New DonkeyKong(dkPBox)
        _damsel = New Pauline(pBoxPauline)
        _player = New Character(pBoxSprite, ClientSize.Width, ClientSize.Height)
        For i = 1 To 7
            For j = 0 To 19
                Dim pBox As New PictureBox()
                Me.Controls.Add(pBox)
                _platforms(nextAvail) = New Platform(pBox, i, j)
                nextAvail += 1
            Next
        Next
        'MessageBox.Show(nextAvail)
        'For i = 0 To nextAvail - 1
        '    _platforms(i).drop()
        '    _platforms(i).Draw()
        'Next

        'addLadders()

        '_player.setLadders(_ladders)

        _lastTime = 0.0
        _lastBarrel = 6.0
        '_timer.Start()
        'doneWithNew = True
    End Sub

    Private Sub openingAnimation()
        My.Computer.Audio.Play(My.Resources.dk_gamestart, AudioPlayMode.WaitToComplete)
        Me.Invalidate()
        My.Computer.Audio.Play(My.Resources.dk_stagestart, AudioPlayMode.Background)
        'doneWithNew = False
        'MessageBox.Show("Starting Game")
        nextAvail = 0
        For i = 1 To 7
            'dkPBox.Location = New Point(dkPBox.Location.X, dkPBox.Location.Y - 15)
            'System.Threading.Thread.Sleep(1000)
            'For j = 1 To 15
            '    dkPBox.Location = New Point(dkPBox.Location.X, dkPBox.Location.Y + 1)
            'Next
            _damsel.Draw()
            If i Mod 2 = 1 Then
                lblHelp.Text = "HELP!"
                lblHelp.Update()
            End If
            _dk.jump()
            lblHelp.Text = ""
            lblHelp.Update()
            For j = 0 To 19
                _platforms(j + ((i - 1) * 20)).drop()
                _platforms(j + ((i - 1) * 20)).Draw()
                'If i Mod 2 = 0 Then
                '    If j = 5 Then
                '        _ladders(nextAvail).break()
                '        nextAvail += 1
                '    ElseIf j = 15 Then
                '        _ladders(nextAvail).break()
                '        nextAvail += 1
                '    End If
                'Else
                '    If j = 5 Then
                '        _ladders(nextAvail).break()
                '        nextAvail += 1
                '    ElseIf j = 10 Then
                '        _ladders(nextAvail).break()
                '        nextAvail += 1
                '    ElseIf j = 15 Then
                '        _ladders(nextAvail).break()
                '        nextAvail += 1
                '    End If
                'End If

            Next
        Next
        addLadders()
        _player.setLadders(_ladders)
        _player.setPlatforms(_platforms)
        _timer.Start()
    End Sub

    Private Sub addLadders()
        nextAvail = 0
        Dim h1, h2, h3
        Dim rng As New Random
        For i = 1 To 7
            Dim b As Integer = rng.Next(1, 4)
            Dim r1 As Integer = rng.Next(1, 4)
            Dim r3 As Integer = rng.Next(7, 10)
            Dim r2 As Integer = rng.Next(4, 7)
            Dim y1 = _platforms((i - 1) * 20 + r1).Location.Y '- _platforms((i - 1) * 20 + r1).Size.Height
            Dim y2 = _platforms((i - 1) * 20 + r2).Location.Y '- _platforms((i - 1) * 20 + r2).Size.Height
            Dim y3 = _platforms((i - 1) * 20 + r3).Location.Y '- _platforms((i - 1) * 20 + r3).Size.Height
            Dim x1 = r1 * 25
            Dim x2 = r2 * 25
            Dim x3 = r3 * 25
            Dim pBox1 As New PictureBox
            Dim pBox2 As New PictureBox
            Dim pBox3 As New PictureBox
            Me.Controls.Add(pBox1)
            Me.Controls.Add(pBox2)
            Me.Controls.Add(pBox3)
            If i = 7 Then
                h1 = ClientSize.Height - y1
                h2 = ClientSize.Height - y2
                h3 = ClientSize.Height - y3
            Else
                h1 = _platforms(i * 20 + r1).Location.Y - y1 + _platforms((i - 1) * 20 + r1).Size.Height
                h2 = _platforms(i * 20 + r2).Location.Y - y2 + _platforms((i - 1) * 20 + r2).Size.Height
                h3 = _platforms(i * 20 + r3).Location.Y - y3 + _platforms((i - 1) * 20 + r3).Size.Height
            End If
            If i Mod 2 = 0 Then
                _ladders(nextAvail) = New Ladder(pBox1, h1, x1, y1, b = 1)
                _ladders(nextAvail).Draw()
                nextAvail += 1
                _ladders(nextAvail) = New Ladder(pBox3, h3, x3, y3, b = 3)
                _ladders(nextAvail).Draw()
                nextAvail += 1
            Else
                _ladders(nextAvail) = New Ladder(pBox1, h1, x1, y1, b = 1)
                _ladders(nextAvail).Draw()
                nextAvail += 1
                _ladders(nextAvail) = New Ladder(pBox2, h2, x2, y2, b = 2)
                _ladders(nextAvail).Draw()
                nextAvail += 1
                _ladders(nextAvail) = New Ladder(pBox3, h3, x3, y3, b = 3)
                _ladders(nextAvail).Draw()
                nextAvail += 1
            End If
        Next
        'MessageBox.Show(nextAvail)

    End Sub

    Private Sub DKGame_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles MyBase.Paint

        Dim gameTime As Double = _timer.ElapsedMilliseconds / 1000.0
        Dim elapsedTime As Double = gameTime - _lastTime
        If _player.hasWon Then
            MessageBox.Show("Congratulations! You won in " & gameTime & " seconds!")
            Application.Exit()
            Application.Restart()
        End If
        _lastTime = gameTime
        _lastBarrel += elapsedTime
        If _lastBarrel > 10.0 Then
            createBarrel()
            _lastBarrel -= 10.0
        End If
        _frameCounter += 1

        _player.Update(gameTime, elapsedTime)

        _player.Draw()

        For i = 0 To barrelsOnScreen
            Try
                _barrels(i).Update(gameTime, elapsedTime)
                _barrels(i).Draw()
            Catch
            End Try
        Next

        'If doneWithNew Then
        '    throughPaint = True
        'End If
        Me.Invalidate()
    End Sub

    Private Sub createBarrel()
        'If Not barrelsOnScreen = 13 Then
        'MessageBox.Show("CREATING BARREL")
        Dim bPBox As New PictureBox
        Me.Controls.Add(bPBox)
        _barrels(nextBarrel) = New Barrel(bPBox, ClientSize.Width, ClientSize.Height, _ladders, _player)
        _barrels(nextBarrel).Draw()
        nextBarrel += 1
        barrelsOnScreen += 1
        'Else
        'nextBarrel = 0
        'If _barrels(nextBarrel).isDestroyed Then
        '    barrelsOnScreen = 0
        'End If
        'End If
    End Sub

    Private Sub DKGame_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        _player.KeyDown(e.KeyCode)
    End Sub

    Private Sub DKGame_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyUp
        _player.KeyUp(e.KeyCode)
    End Sub

    Private Sub DKGame_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub DKGame_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        'dkPBox.Show()
        '_player.Draw()
        _dk.Draw()
        'For i = 0 To 14
        '    _platforms(i).Draw()
        'Next
        'Application.DoEvents()
        openingAnimation()
        'Dim MyProcess As New Process
        'MyProcess.StartInfo.FileName = "DKLevel1.mid"
        'MyProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        'MyProcess.Start()
        My.Computer.Audio.Play(My.Resources.DKLevel1, AudioPlayMode.BackgroundLoop)
    End Sub
End Class