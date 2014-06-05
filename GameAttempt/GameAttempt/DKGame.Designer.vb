<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DKGame
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
        Me.lblHelp = New System.Windows.Forms.Label
        Me.pBoxPauline = New System.Windows.Forms.PictureBox
        Me.dkPBox = New System.Windows.Forms.PictureBox
        Me.pBoxSprite = New System.Windows.Forms.PictureBox
        CType(Me.pBoxPauline, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dkPBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pBoxSprite, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblHelp
        '
        Me.lblHelp.AutoSize = True
        Me.lblHelp.Location = New System.Drawing.Point(20, 1)
        Me.lblHelp.MaximumSize = New System.Drawing.Size(100, 100)
        Me.lblHelp.Name = "lblHelp"
        Me.lblHelp.Size = New System.Drawing.Size(0, 13)
        Me.lblHelp.TabIndex = 3
        '
        'pBoxPauline
        '
        Me.pBoxPauline.InitialImage = Global.GameAttempt.My.Resources.Resources.Pauline
        Me.pBoxPauline.Location = New System.Drawing.Point(0, 0)
        Me.pBoxPauline.Name = "pBoxPauline"
        Me.pBoxPauline.Size = New System.Drawing.Size(13, 35)
        Me.pBoxPauline.TabIndex = 2
        Me.pBoxPauline.TabStop = False
        '
        'dkPBox
        '
        Me.dkPBox.Location = New System.Drawing.Point(62, 1)
        Me.dkPBox.Name = "dkPBox"
        Me.dkPBox.Size = New System.Drawing.Size(35, 33)
        Me.dkPBox.TabIndex = 1
        Me.dkPBox.TabStop = False
        '
        'pBoxSprite
        '
        Me.pBoxSprite.Location = New System.Drawing.Point(53, 246)
        Me.pBoxSprite.Name = "pBoxSprite"
        Me.pBoxSprite.Size = New System.Drawing.Size(10, 10)
        Me.pBoxSprite.TabIndex = 0
        Me.pBoxSprite.TabStop = False
        '
        'DKGame
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 264)
        Me.Controls.Add(Me.lblHelp)
        Me.Controls.Add(Me.pBoxPauline)
        Me.Controls.Add(Me.dkPBox)
        Me.Controls.Add(Me.pBoxSprite)
        Me.Name = "DKGame"
        Me.Text = "DKGame"
        CType(Me.pBoxPauline, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dkPBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pBoxSprite, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pBoxSprite As System.Windows.Forms.PictureBox
    Friend WithEvents dkPBox As System.Windows.Forms.PictureBox
    Friend WithEvents pBoxPauline As System.Windows.Forms.PictureBox
    Friend WithEvents lblHelp As System.Windows.Forms.Label
End Class
