Imports Bwl.Framework

Public Class GitManager
    Public Shared ReadOnly Property App As New AppBase

    Public Class Settings
        Private Shared _storage As SettingsStorage = _App.RootStorage
        Public Shared ReadOnly Property RepPathSetting As New StringSetting(_storage, "RepositoriesPaths", "")
        Public Shared ReadOnly Property Command1Setting As New StringSetting(_storage, "Command1", "gitk|C:\Program Files\Git\cmd\gitk.exe|")
        Public Shared ReadOnly Property Command2Setting As New StringSetting(_storage, "Command2", "SourceTree|C:\Program Files (x86)\Atlassian\SourceTree\SourceTree.exe|")
        Public Shared ReadOnly Property Command3Setting As New StringSetting(_storage, "Command3", "")
        Public Shared ReadOnly Property Command4Setting As New StringSetting(_storage, "Command4", "")
        Public Shared ReadOnly Property Command5Setting As New StringSetting(_storage, "Command5", "")
        Public Shared ReadOnly Property AutoFetchEveryMinutes As New IntegerSetting(_storage, "AutoFetchEveryMinutes", 15)
        Public Shared ReadOnly Property AutoUpdateLocalEveryMinutes As New IntegerSetting(_storage, "AutoStatusEveryMinutes", 3)
        Public Shared ReadOnly Property ShowCommandsAsButtons As New BooleanSetting(_storage, "ShowCommandsAsButtons", False)
        Public Shared ReadOnly Property LastRepCount As New IntegerSetting(_storage, "LastRepositoryCount", 0)
    End Class
End Class
