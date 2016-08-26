Public Class ProcessList
    Public Shared ReadOnly Property Processes As Process()

    Shared Sub New()
        _Processes = Process.GetProcesses

        Dim monitor As New Threading.Thread(Sub()
                                                Do
                                                    Try
                                                        _Processes = Process.GetProcesses
                                                    Catch ex As Exception
                                                    End Try
                                                Loop
                                                Threading.Thread.Sleep(3000)
                                            End Sub)
        monitor.IsBackground = True
        monitor.Name = "ProcessList Monitor"
        monitor.Start()
    End Sub

End Class
