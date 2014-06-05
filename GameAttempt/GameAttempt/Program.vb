Friend Class Program
    Private Sub New()
    End Sub
    <STAThread()> _
    Shared Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New DKGame())
    End Sub
End Class