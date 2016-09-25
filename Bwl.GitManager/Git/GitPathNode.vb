Public Class GitPathNode
    Public Shared Event Progress(processedCount As Integer, repNode As GitPathNode)
    Private _name As String = "Root"
    Private _fullPath As String = "#"
    Private _status As New GitRepositoryStatus
    Private _childNodes As New List(Of GitPathNode)
    Private Shared _progress As Integer = 0

    Public ReadOnly Property Name As String
        Get
            Return _name
        End Get
    End Property

    Public ReadOnly Property FullPath As String
        Get
            Return _fullPath
        End Get
    End Property

    Public ReadOnly Property Status As GitRepositoryStatus
        Get
            Return _status
        End Get
    End Property

    Public ReadOnly Property ChildNodes As List(Of GitPathNode)
        Get
            Return _childNodes
        End Get
    End Property

    Public Overrides Function ToString() As String
        Dim result = ""
        If Status.IsRepository Then
            result = "Repository " + Name + " "
            If Status.IsUncommittedChanges Then result += "uncommitted "
            result += " (" + FullPath + ")"
        Else
            result = "Directory " + Name + " (" + FullPath + ")"
        End If
        Return result
    End Function

    Public Sub UpdateStatus(recursive As Boolean, noProgress As Boolean)
        If Not noProgress Then _progress += 1 : RaiseEvent Progress(_progress, Me)
        If FullPath <> "#" Then _Status = GitTool.GetRepositoryStatus(FullPath)
        If recursive Then
            For Each child In ChildNodes
                child.UpdateStatus(recursive, noProgress)
            Next
        End If
    End Sub

    Public Sub ResetClean(recursive As Boolean, noProgress As Boolean, needReset As Boolean, needClean As Boolean, needCleanIgnored As Boolean)
        If Not noProgress Then _progress += 1 : RaiseEvent Progress(_progress, Me)
        If FullPath <> "#" Then
            If needReset Then      GitTool.RepositoryReset(FullPath, "hard")
            If needClean Then       GitTool.RepositoryClean(FullPath, needCleanIgnored)
                _status = GitTool.GetRepositoryStatus(FullPath)
            End If
            If recursive Then
            For Each child In ChildNodes
                child.ResetClean(recursive, noProgress, needReset, needClean, needCleanIgnored)
            Next
        End If
    End Sub

    Public Function GetChildCount(recursive As Boolean) As Integer
        Dim result = ChildNodes.Count
        If recursive Then
            For Each child In ChildNodes
                result += child.GetChildCount(recursive)
            Next
        End If
        Return result
    End Function

    Public Sub ResetProgress()
        _progress = 0
    End Sub

    Public Sub UpdatePull(recursive As Boolean, onlyChanged As Boolean)
        _progress += 1 : RaiseEvent Progress(_progress, Me)
        If FullPath <> "#" Then
            If Status.CanPull Or onlyChanged = False Then GitTool.RepositoryPull(FullPath)
            _Status = GitTool.GetRepositoryStatus(FullPath)
        End If
        If recursive Then
            For Each child In ChildNodes
                child.UpdatePull(recursive, onlyChanged)
            Next
        End If
    End Sub

    Public Sub UpdateFetch(recursive As Boolean, noProgress As Boolean)
        If Not noProgress Then _progress += 1 : RaiseEvent Progress(_progress, Me)
        If FullPath <> "#" Then
            GitTool.RepositoryFetch(FullPath)
            _status = GitTool.GetRepositoryStatus(FullPath)
            If _status.CanPull AndAlso GitManager.Settings.AutoPullAfterFetch.Value = True AndAlso _status.AutoPullSettings > "" Then
                Dim settings = _status.AutoPullSettings.ToLower.Split(",")
                If settings(0).Trim = "enable" Then
                    Dim allowed = True
                    If _status.IsUncommittedChanges Then
                        allowed = False
                        GitManager.App.RootLogger.AddDebug("AutoPull включен для " + Name + ", но был заблокирован неотправленными изменениями")
                    End If
                    If allowed Then

                        For i = 1 To settings.Length - 1
                            Dim prcName = settings(i).ToLower.Substring(1)
                            For Each prc In ProcessList.Processes.Clone
                                If prc.ProcessName.ToLower = prcName Then
                                    allowed = False
                                    GitManager.App.RootLogger.AddDebug("AutoPull включен для " + Name + ", но был заблокирован процессом " + prcName)
                                    Exit For
                                End If
                            Next
                        Next
                    End If
                    If allowed Then
                        GitTool.RepositoryPull(FullPath)
                        GitTool.RepositoryPull(FullPath)
                        _status = GitTool.GetRepositoryStatus(FullPath)
                        GitManager.App.RootLogger.AddMessage("AutoPull выполнен для " + Name)
                    End If
                End If
            End If
        End If
        If recursive Then
            For Each child In ChildNodes
                child.UpdateFetch(recursive, noProgress)
            Next
        End If
    End Sub

    Public Sub New()

    End Sub

    Public Sub New(path As String)
        If IO.Directory.Exists(path) = False Then Throw New ArgumentException("Path not exists: " + path)
        If IO.File.Exists(IO.Path.Combine(path, "Bwl.GitManager.sln")) And IO.File.Exists(IO.Path.Combine(path, "Bwl.GitManager", "Bwl.GitManager.vbproj")) Then
            GitManager.GitManagerRepository = Me
        End If
        If IO.Directory.Exists(IO.Path.Combine(path, ".git")) Then
            Status.IsRepository = True
            Status.RawStatusText = "(fast scan)"
        End If

        _fullPath = path
        Dim info = New IO.DirectoryInfo(path)
        _Name = info.Name
    End Sub

    Public Shared Function ContainsRepositories(node As GitPathNode) As Boolean
        If node.Status.IsRepository Then
            Return True
        Else
            For Each rc In node.ChildNodes
                If ContainsRepositories(rc) Then Return True
            Next
        End If
        Return False
    End Function

    Public Shared Function GetRepositoriesTree(rootPath As String, fastScan As Boolean) As GitPathNode
        If IO.Directory.Exists(rootPath) Then
            Dim rep = New GitPathNode(rootPath)
            If Not fastScan Then  rep.UpdateStatus(False, True)
            If rep.Status.IsRepository Then
                    _progress += 1
                    RaiseEvent Progress(_progress, rep)
                    Return rep
                Else
                    Dim childs = IO.Directory.GetDirectories(rootPath)
                    For Each child In childs
                    Dim repChild = GetRepositoriesTree(child, fastScan)
                    If ContainsRepositories(repChild) Then rep.ChildNodes.Add(repChild)
                    Next
                    Return rep
                End If
            Else
                Return Nothing
        End If
    End Function
End Class
