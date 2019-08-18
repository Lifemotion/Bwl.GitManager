Public Class ProcessList
    Private Shared _processes As Process()
    Public Shared ReadOnly Property Processes As Process()
        Get
            Return _processes
        End Get
    End Property

    Shared Sub New()
        _Processes = Process.GetProcesses

        Dim monitor = ThreadManager.CreateThread("ProcessList Monitor", Sub()
                                                                            Do
                                                                                Try
                                                                                    _processes = Process.GetProcesses
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
