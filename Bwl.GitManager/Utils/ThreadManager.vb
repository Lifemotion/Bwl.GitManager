Public Class ThreadManager
    Private Shared _list As New List(Of ThreadInfo)
    Private Shared ReadOnly _syncObject As New Object

    Public Shared Function CreateThread(info As String, start As Threading.ThreadStart) As Threading.Thread
        SyncLock _syncObject
            Dim thr As New Threading.Thread(start)
            _list.Add(New ThreadInfo With {.Thread = thr, .CreateTime = Now, .Info = info})
            Return thr
        End SyncLock
    End Function

    Public Shared Function GetAliveThreads() As ThreadInfo()
        SyncLock _syncObject
            Dim filtered As New List(Of ThreadInfo)
            For Each ti In _list
                If ti.Thread.ThreadState <> Threading.ThreadState.Stopped Then
                    filtered.Add(ti)
                End If
            Next
            _list.Clear()
            _list.AddRange(filtered)
            Return filtered.ToArray
        End SyncLock
    End Function
End Class

Public Class ThreadInfo
    Public Property Thread As Threading.Thread
    Public Property CreateTime As DateTime = Now
    Public Property Info As String
End Class
