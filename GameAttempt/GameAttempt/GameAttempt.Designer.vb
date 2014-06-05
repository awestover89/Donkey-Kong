<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GameAttempt
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pBoxSprite = New System.Windows.Forms.PictureBox
        Me.dkPBox = New System.Windows.Forms.PictureBox
        CType(Me.pBoxSprite, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dkPBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pBoxSprite
        '
        Me.pBoxSprite.Location = New System.Drawing.Point(13, 202)
        Me.pBoxSprite.Name = "pBoxSprite"
        Me.pBoxSprite.Size = New System.Drawing.Size(51, 50)
        Me.pBoxSprite.TabIndex = 0
        Me.pBoxSprite.TabStop = False
        '
        'dkPBox
        '
        Me.dkPBox.InitialImage = Global.GameAttempt.My.Resources.Resources.DonkeyKong
        Me.dkPBox.Location = New System.Drawing.Point(62, 1)
        Me.dkPBox.Name = "dkPBox"
        Me.dkPBox.Size = New System.Drawing.Size(35, 33)
        Me.dkPBox.TabIndex = 1
        Me.dkPBox.TabStop = False
        '
        'GameAttempt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 264)
        Me.Controls.Add(Me.dkPBox)
        Me.Controls.Add(Me.pBoxSprite)
        Me.Name = "GameAttempt"
        Me.Text = "GameAttempt"
        CType(Me.pBoxSprite, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dkPBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pBoxSprite As System.Windows.Forms.PictureBox
    Friend WithEvents dkPBox As System.Windows.Forms.PictureBox
End Class
