Public Class FileSelectDialog

    Private Sub ImportFileCmdBtn_Click(sender As Object, e As EventArgs) Handles ImportFileCmdBtn.Click

        Dim fd As OpenFileDialog = New OpenFileDialog()

        fd.Title = "Open File Dialog"
        fd.InitialDirectory = "C:\"
        fd.Filter = "Text files (*.txt)|*.txt|Text files (*.txt)|*.txt"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            If Main.MaterialOrRecipe = True Then
                Main.MatExportFilename = fd.FileName
                ImportFileTxtBox.Text = Main.MatExportFilename
            ElseIf Main.MaterialOrRecipe = False Then
                Main.RecipeExportFilename = fd.FileName
                ImportFileTxtBox.Text = Main.RecipeExportFilename
            End If
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
            If Main.MaterialOrRecipe = True Then
                Main.MatComparisonFileName = fd.FileName
                FileCompareTxtBox.Text = Main.MatComparisonFileName
            ElseIf Main.MaterialOrRecipe = False Then
                Main.RecipeComparisonFileName = fd.FileName
                FileCompareTxtBox.Text = Main.RecipeComparisonFileName
            End If
        End If

    End Sub

    Private Sub CloseCmdBtn_Click(sender As Object, e As EventArgs) Handles CloseCmdBtn.Click

        Close()

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Main.MaterialOrRecipe = True Then
            If Main.MatComparisonFileName <> Nothing Then
                FileCompareTxtBox.Text = Main.MatComparisonFileName
            End If
        ElseIf Main.MaterialOrRecipe = False Then
            If Main.MatComparisonFileName <> Nothing Then
                FileCompareTxtBox.Text = Main.RecipeComparisonFileName
            End If
        End If

        CenterToParent()

    End Sub

End Class