﻿Public Class GithubServer
    Implements IGitServer

    Public Function OriginSupported(origin As String) As Boolean Implements IGitServer.OriginSupported
        Dim parts = origin.Split({"/"}, StringSplitOptions.RemoveEmptyEntries)
        If parts.Length = 4 Then
            If parts(1).ToLower.Contains("github.com") Then Return True
        End If
        Return False
    End Function

    Public Function WebUrlSupported(webUrl As String) As Boolean Implements IGitServer.WebUrlSupported
        Return False
    End Function

    Public Function GetWebUrl(origin As String) As String Implements IGitServer.GetWebUrl
        Dim parts = origin.Split({"/"}, StringSplitOptions.RemoveEmptyEntries)
        If parts.Length = 4 Then
            If parts(1).ToLower = "github.com" Then
                Dim serverParts = parts(1).Split("@")
                Dim server = If(serverParts.Length = 2, serverParts(1), serverParts(0))
                Dim url = parts(0) + "//" + server + "/" + parts(2) + "/" + parts(3).Replace(".git", "") + ""
                Return url
            End If
        End If
        Throw New Exception("Origin not supported")
    End Function

    Public Function GetCloneUrl(webUrl As String) As String Implements IGitServer.GetCloneUrl
        Return ""
    End Function

End Class
