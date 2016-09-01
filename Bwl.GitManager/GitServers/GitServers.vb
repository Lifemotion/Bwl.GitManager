Imports Bwl.GitManager

Public Class GitServers
    Public Shared ReadOnly Property Providers As New List(Of IGitServer)

    Shared Sub New()
        Providers.Add(New StashServer)
        Providers.Add(New BitbucketServer)
        Providers.Add(New GithubServer)
    End Sub

    Public Shared Function GetCloneUrl(webUrl As String) As String
        Throw New NotImplementedException()
    End Function

    Public Shared Function GetWebUrl(origin As String) As String
        Throw New NotImplementedException()
    End Function

    Public Shared Function OriginSupported(origin As String) As Boolean
        Throw New NotImplementedException()
    End Function

    Public Shared Function WebUrlSupported(webUrl As String) As Boolean
        Throw New NotImplementedException()
    End Function

    Public pr

End Class
