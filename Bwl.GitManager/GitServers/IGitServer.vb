Public Interface IGitServer
    Function GetCloneUrl(webUrl As String) As String
    Function GetWebUrl(origin As String) As String
    Function OriginSupported(origin As String) As Boolean
    Function WebUrlSupported(webUrl As String) As Boolean
End Interface
