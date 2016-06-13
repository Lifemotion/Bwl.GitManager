Imports System.Xml

Public Class SourceTreeExport
    Public Shared Sub Export(tree As GitPathNode)
        Dim file = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Atlassian", "SourceTree", "bookmarks.xml")
        If IO.File.Exists(file) = False Then
            Throw New Exception("Sourcetree Bookmarks file not found: " + file)
        Else
            IO.File.Copy(file, file + ".backup-" + Now.Ticks.ToString)
            Dim bookmarks As New Xml.XmlDocument
            bookmarks.Load(file)
            Dim itemsArray = bookmarks.Item("ArrayOfTreeViewNode")
            For Each child In tree.ChildNodes
                ExportSourceTreeRecursive(bookmarks, itemsArray, child, 0)
            Next
            bookmarks.Save(file)
        End If
    End Sub

    Private Shared Sub ExportSourceTreeRecursive(doc As XmlDocument, xmlnode As Xml.XmlElement, gitnode As GitPathNode, level As Integer)
        If gitnode.Status.IsRepository Then
            Dim found As Xml.XmlElement = Nothing
            For Each node As Xml.XmlElement In xmlnode.ChildNodes
                If node.Attributes("xsi:type").Value = "BookmarkNode" And node.Item("Name").InnerText = gitnode.Name Then found = node
            Next
            If found Is Nothing Then
                Dim node = doc.CreateElement("TreeViewNode")
                Dim schemeAttr = doc.CreateAttribute("xsi", "type", "http://www.w3.org/2001/XMLSchema-instance")
                schemeAttr.Value = "BookmarkNode"
                node.Attributes.Append(schemeAttr)
                node.AppendChild(doc.CreateElement("Level")).InnerText = level.ToString
                node.AppendChild(doc.CreateElement("IsExpanded")).InnerText = "true"
                node.AppendChild(doc.CreateElement("Name")).InnerText = gitnode.Name
                node.AppendChild(doc.CreateElement("IsLeaf")).InnerText = "true"
                node.AppendChild(doc.CreateElement("Children"))
                node.AppendChild(doc.CreateElement("RepoType")).InnerText = "Git"
                node.AppendChild(doc.CreateElement("Path")).InnerText = gitnode.FullPath
                xmlnode.AppendChild(node)
                found = node
            End If
        Else
            Dim found As Xml.XmlElement = Nothing
            For Each node As Xml.XmlElement In xmlnode.ChildNodes
                If node.Attributes("xsi:type").Value = "BookmarkFolderNode" And node.Item("Name").InnerText = gitnode.Name Then found = node
            Next
            If found Is Nothing Then
                Dim node = doc.CreateElement("TreeViewNode")
                Dim schemeAttr = doc.CreateAttribute("xsi", "type", "http://www.w3.org/2001/XMLSchema-instance")
                schemeAttr.Value = "BookmarkFolderNode"
                node.Attributes.Append(schemeAttr)
                node.AppendChild(doc.CreateElement("Level")).InnerText = level.ToString
                node.AppendChild(doc.CreateElement("IsExpanded")).InnerText = "false"
                node.AppendChild(doc.CreateElement("Name")).InnerText = gitnode.Name
                node.AppendChild(doc.CreateElement("IsLeaf")).InnerText = "true"
                node.AppendChild(doc.CreateElement("Children"))
                xmlnode.AppendChild(node)
                found = node
            End If
            Dim xmlNodeChildrens = found("Children")
            For Each child In gitnode.ChildNodes
                ExportSourceTreeRecursive(doc, xmlNodeChildrens, child, level + 1)
            Next
            If xmlNodeChildrens.HasChildNodes Then found.Item("IsLeaf").InnerText = "false"
        End If
    End Sub
End Class
