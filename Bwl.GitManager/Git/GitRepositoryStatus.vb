Public Class GitRepositoryStatus
    Public Property IsRepository As Boolean
    Public Property IsUntrackedFiles As Boolean
    Public Property IsModifiedFiles As Boolean
    Public Property IsDeletedFiles As Boolean
    Public Property IsUncommittedChanges As Boolean
    Public Property CanPull As Boolean
    Public Property CanPush As Boolean
    Public Property UpToDate As Boolean
    Public Property RawStatusText As String = ""
    Public Property IsSpecialRepository As String = ""
    Public Property AutoPullSettings As String = ""
End Class
