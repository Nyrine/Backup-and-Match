Imports SearchIndexer
Imports System.Xml


Public Class main
    Public XMLFile As String
    Private Sub main_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim sind As New sindex

        sind.Show()




    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim opF As New OpenFileDialog
        With opF
            .ShowDialog()
            XMLFile = .FileName
        End With
        Dim xmlDoc As New XmlDataDocument
        xmlDoc.DataSet.ReadXml(XMLFile)
        DataGridView1.DataSource = xmlDoc.DataSet.Tables
    End Sub
    Private Sub LoadBranches()

        Dim filePath As String = (XMLFile)
        Dim BranchDS As New DataSet()
        BranchDS.ReadXml(filePath)
        Try
            With DataGridView1 ' the datagridview
                .DataSource = BranchDS
                .DataMember = "branch"
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                .AutoSize = True
                .EditMode = DataGridViewEditMode.EditOnEnter
            End With
        Catch ex As Exception
            MsgBox("Branch XML File Could Not Be Loaded: " & ex.Message)
        End Try

    End Sub

End Class
