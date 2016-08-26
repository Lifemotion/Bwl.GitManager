Imports Bwl.Framework

Public Class GitManager
    Public Shared _app As New AppBase
    Public Shared GitManagerRepository As GitPathNode

    Public Shared ReadOnly Property App As AppBase
        Get
            Return _app
        End Get
    End Property

    Public Class Settings
        Private Shared _storage As SettingsStorage = _App.RootStorage
        Public Shared Property RepPathSetting As New StringSetting(_storage, "RepositoriesPaths", "")
        Public Shared Property Command1Setting As New StringSetting(_storage, "Command1", "gitk|C:\Program Files\Git\cmd\gitk.exe|")
        Public Shared Property Command2Setting As New StringSetting(_storage, "Command2", "SourceTree|C:\Program Files (x86)\Atlassian\SourceTree\SourceTree.exe|")
        Public Shared Property Command3Setting As New StringSetting(_storage, "Command3", "")
        Public Shared Property Command4Setting As New StringSetting(_storage, "Command4", "")
        Public Shared Property Command5Setting As New StringSetting(_storage, "Command5", "")
        Public Shared Property AutoFetchEveryMinutes As New IntegerSetting(_storage, "AutoFetchEveryMinutes", 15)
        Public Shared Property AutoUpdateLocalEveryMinutes As New IntegerSetting(_storage, "AutoStatusEveryMinutes", 3)
        Public Shared Property AutoPullAfterFetch As New BooleanSetting(_storage, "AutoPullAfterFetch", False)
        Public Shared Property ShowCommandsAsButtons As New BooleanSetting(_storage, "ShowCommandsAsButtons", True)
        Public Shared Property LastRepCount As New IntegerSetting(_storage, "LastRepositoryCount", 0)
    End Class
End Class
