Public Class FileSelectDialog

    Private Sub ImportFileCmdBtn_Click(sender As Object, e As EventArgs) Handles ImportFileCmdBtn.Click

        Dim fd As OpenFileDialog = New OpenFileDialog()

        fd.Title = "Open File Dialog"
        fd.InitialDirectory = "C:\"
        fd.Filter = "Text files (*.txt)|*.txt|Text files (*.txt)|*.txt"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            Main.ImportFilename = fd.FileName
            ImportFileTxtBox.Text = Main.ImportFilename
        End If

    End Sub

    Private Sub FileCompareCmdBtn_Click(sender As Object, e As EventArgs) Handles FileCompareCmdBtn.Click

        Dim fd As OpenFileDialog = New OpenFileDialog()

        fd.Title = "Open File Dialog"
        fd.InitialDirectory = "C:\"
        fd.Filter = "Text files (*.txt)|*.txt|Text files (*.txt)|*.txt"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            Main.ComparisonFileName = fd.FileName
            FileCompareTxtBox.Text = Main.ComparisonFileName
        End If

    End Sub

    Private Sub CloseCmdBtn_Click(sender As Object, e As EventArgs) Handles CloseCmdBtn.Click

        Close()

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Main.ComparisonFileName <> Nothing Then
            FileCompareTxtBox.Text = Main.ComparisonFileName
        End If

        CenterToParent()

    End Sub

End Class