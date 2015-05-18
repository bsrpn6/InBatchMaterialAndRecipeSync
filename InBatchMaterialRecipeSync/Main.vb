Imports System
Imports System.IO
Imports System.Text
Imports System.Collections.Generic

Public Class Main

    'File path variables
    Public MatExportFilename As String = "C:\Program Files (x86)\Wonderware\InBatch\cfg\Config_A\InBatchSync\SavedMaterialExport.txt"
    Public MatComparisonFileName As String = "C:\Program Files (x86)\Wonderware\InBatch\cfg\Config_A\InBatchSync\SavedMaterialExportForImport.txt"

    Public RecipeExportFilename As String = "C:\Program Files (x86)\Wonderware\InBatch\cfg\Config_A\InBatchSync\SavedRecipeExport.txt"
    Public RecipeComparisonFileName As String = "C:\Program Files (x86)\Wonderware\InBatch\cfg\Config_A\InBatchSync\SavedRecipeExportForImport.txt"

    Dim RecipercpExportPath As String = "C:\Program Files (x86)\Wonderware\InBatch\cfg\Config_A\InBatchSync\RecipeRCPExport"
    Dim RecipeRCPCopyPath As String = "C:\Program Files (x86)\Wonderware\InBatch\cfg\Config_A"

    'Delcaration of API variable objects and types
    Private oMaterialDB As wwMaterialLib.IMaterialDB
    Private iMaterials As wwMaterialLib.IMaterials
    Private iMaterial As wwMaterialLib.IMaterial
    Private oRecipeDB As Object
    Dim oRecipeClassType As System.Type
    Dim oMaterialClassType As System.Type

    'Delcaration of DataTables used to load information from CSVs and for maintain information for imports
    Dim MatExport As DataTable = New DataTable()
    Dim MatComparison As DataTable = New DataTable()
    Dim RecipeExport As DataTable = New DataTable()
    Dim RecipeComparison As DataTable = New DataTable()
    Dim RecipeConflicts As DataTable = New DataTable()

    'Progress Bars
    Dim ProgressBar1 As ProgressBar
    Dim ProgressBar2 As ProgressBar

    'Host server name
    Dim BatchServerHostName As String = "localhost"

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles Me.Load

        'Instantiate oRecipeDB object
        oRecipeClassType = System.Type.GetTypeFromProgID("Wonderware.RecipeEdit.wwRecipe", BatchServerHostName)
        oRecipeDB = System.Activator.CreateInstance(oRecipeClassType)

        If IsDBNull(oRecipeDB) Then
            MessageBox.Show("Error with oRecipeDB.")
        End If

        'Instantiate oMaterialDB object
        oMaterialClassType = System.Type.GetTypeFromProgID("Wonderware.MaterialSrv.wwMaterialDB.1", BatchServerHostName)
        oMaterialDB = System.Activator.CreateInstance(oMaterialClassType)

        If IsDBNull(oMaterialDB) Then
            MessageBox.Show("Error with oMaterialDB.")
        End If

        'If folder to copy to doesn't exist, create it
        If Not Directory.Exists(RecipercpExportPath) Then
            Directory.CreateDirectory(RecipercpExportPath)
        End If

        CenterToScreen()

    End Sub

    Private Sub GetMaterialExport()

        Dim Mats As wwMaterialLib.wwMaterials
        Dim Material As wwMaterialLib.wwMaterial

        'Create FileStream and StringBuilder
        Dim fs As FileStream = Nothing
        Dim sb As New StringBuilder

        'Creates file if doesn't exist
        If (Not File.Exists(MatExportFilename)) Then
            fs = File.Create(MatExportFilename)
            Using fs
            End Using
        End If

        'Query for materials of type Ingredient from host
        oMaterialDB.QueryMaterialsByType(wwMaterialLib.wwMtrlTypeEnum.wwTypeIngredient)

        Mats = oMaterialDB.Materials
        Dim n As Integer = 1

        'Write materials to CSV file
        Using outfile As New StreamWriter(MatExportFilename)
            For Each Material In Mats
                outfile.Write(Mats.Item(n).ID.ToString & ",")
                outfile.Write(Mats.Item(n).Name.ToString & ",")
                outfile.Write(Mats.Item(n).Description.ToString & ",")
                outfile.Write(Mats.Item(n).Type.ToString & ",")
                outfile.Write(Mats.Item(n).UnitOfMeasure.ToString & ",")
                outfile.Write(Mats.Item(n).HiDev.ToString & ",")
                outfile.Write(Mats.Item(n).LoDev.ToString & ",")
                outfile.Write("*")
                outfile.WriteLine()

                n += 1
            Next
        End Using

    End Sub

    Private Sub GetMaterialExportForImport()

        Dim Mats As wwMaterialLib.wwMaterials
        Dim Material As wwMaterialLib.wwMaterial

        'Create FileStream and StringBuilder
        Dim fs As FileStream = Nothing
        Dim sb As New StringBuilder

        'Creates file if doesn't exist.
        If (Not File.Exists(MatComparisonFileName)) Then
            fs = File.Create(MatComparisonFileName)
            Using fs
            End Using
        End If

        'Queries to retrieve information using WonderWare API.
        oMaterialDB.QueryMaterialsByType(wwMaterialLib.wwMtrlTypeEnum.wwTypeIngredient)

        Mats = oMaterialDB.Materials
        Dim n As Integer = 1

        'Writes materials to CSV file
        Using outfile As New StreamWriter(MatComparisonFileName)
            For Each Material In Mats
                outfile.Write(Mats.Item(n).ID.ToString & ",")
                outfile.Write(Mats.Item(n).Name.ToString & ",")
                outfile.Write(Mats.Item(n).Description.ToString & ",")
                outfile.Write(Mats.Item(n).Type.ToString & ",")
                outfile.Write(Mats.Item(n).UnitOfMeasure.ToString & ",")
                outfile.Write(Mats.Item(n).HiDev.ToString & ",")
                outfile.Write(Mats.Item(n).LoDev.ToString & ",")
                outfile.Write("*")
                outfile.WriteLine()

                n += 1
            Next
        End Using

    End Sub

    Private Sub LoadMaterialsFromParent()

        MatExport.Clear()

        'Create StreamReader
        Dim SR As StreamReader = New StreamReader(MatExportFilename)

        'Reads CSV file into arrays split by ","
        Dim i As Long = 0
        Dim line As String = SR.ReadLine
        Dim strArray As String() = line.Split(",")

        Dim row As DataRow

        For Each s As String In strArray
            MatExport.Columns.Add(New DataColumn())
        Next

        'Adds split arrays as rows into DataTable RecipeExport
        Do
            line = SR.ReadLine
            If Not line = Nothing Then
                row = MatExport.NewRow
                row.ItemArray = line.Split(",")
                MatExport.Rows.Add(row)
            Else
                Exit Do
            End If
        Loop

    End Sub

    Private Sub LoadRecipesFromParent()

        RecipeExport.Clear()

        'Create StreamReader
        Dim SR As StreamReader = New StreamReader(RecipeExportFilename)

        'Reads CSV file into arrays split by ","
        Dim i As Long = 0
        Dim line As String = SR.ReadLine
        Dim strArray As String() = line.Split(",")

        Dim row As DataRow

        For Each s As String In strArray
            RecipeExport.Columns.Add(New DataColumn())
        Next

        'Adds split arrays as rows into DataTable RecipeExport
        Do
            line = SR.ReadLine
            If Not line = Nothing Then
                row = RecipeExport.NewRow
                row.ItemArray = line.Split(",")
                RecipeExport.Rows.Add(row)
            Else
                Exit Do
            End If
        Loop

    End Sub

    Private Sub LoadMaterialsFromChild()

        MatComparison.Clear()

        'Create StreamReader
        Dim SR As StreamReader = New StreamReader(MatComparisonFileName)

        'Reads CSV file into arrays split by ","
        Dim i As Long = 0
        Dim line As String = SR.ReadLine
        Dim strArray As String() = line.Split(",")

        Dim row As DataRow

        For Each s As String In strArray
            MatComparison.Columns.Add(New DataColumn())
        Next

        'Adds split arrays as rows into DataTable MatComparison
        Do
            line = SR.ReadLine
            If Not line = Nothing Then
                row = MatComparison.NewRow
                row.ItemArray = line.Split(",")
                MatComparison.Rows.Add(row)
            Else
                Exit Do
            End If
        Loop

    End Sub

    Private Sub LoadRecipesFromChild()

        RecipeComparison.Clear()

        'Create Streamreader
        Dim SR As StreamReader = New StreamReader(RecipeComparisonFileName)

        'Reads CSV file into arrays split by ","
        Dim i As Long = 0
        Dim line As String = SR.ReadLine
        Dim strArray As String() = line.Split(",")

        Dim row As DataRow

        For Each s As String In strArray
            RecipeComparison.Columns.Add(New DataColumn())
        Next

        'Adds split arrays as rows into DataTable RecipeComparison
        Do
            line = SR.ReadLine
            If Not line = Nothing Then
                row = RecipeComparison.NewRow
                row.ItemArray = line.Split(",")
                RecipeComparison.Rows.Add(row)
            Else
                Exit Do
            End If
        Loop

    End Sub

    Private Sub MaterialsToAdd()

        'Queries to find materials that need to be added.
        'Deletes matching records, leaving behind only new materials in the MatExport DataTable.
        Dim RowsToDelete = From r1 In MatExport.AsEnumerable _
                       Join r2 In MatComparison.AsEnumerable _
                       On r1.Field(Of String)("Column1").ToString Equals r2.Field(Of String)("Column1").ToString _
                       Select r1

        For Each row As DataRow In RowsToDelete.ToArray
            row.Delete()
        Next

        If MatExport.Rows.Count > 0 Then 'New materials exist that need added
            MaterialsToAddLbl.Visible = False
            DataGridView1.DataSource = MatExport
            MaterialsToAddLbl.BackColor = SystemColors.AppWorkspace
            DataGridView1.BackgroundColor = Color.Gray
        Else 'No new materials were found
            DataGridView1.DataSource = Nothing
            MaterialsToAddLbl.Visible = True
            MaterialsToAddLbl.Text = "NO NEW MATERIALS TO ADD"
            MaterialsToAddLbl.BackColor = Color.Green
            DataGridView1.BackgroundColor = Color.Green
        End If

    End Sub

    Private Sub RecipesToAdd()

        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim k As Integer = 0

        'Strips matching recipes leaving only unsynced recipes, i.e., those that exist in source but not in host.
        'This DataTable is used to automatically add these "new" recipes.
        Dim RowsToDelete = From r1 In RecipeExport.AsEnumerable _
                       Join r2 In RecipeComparison.AsEnumerable _
                       On r1.Field(Of String)("Column1").ToString Equals r2.Field(Of String)("Column1").ToString _
                       Select r1

        For Each row As DataRow In RowsToDelete.ToArray
            row.Delete()
        Next

    End Sub

    Private Sub RecipesConflicts()

        RecipeConflicts.Clear()

        'Queries to find matching rows.
        Dim MatchingRows = From r1 In RecipeExport.AsEnumerable _
                       Join r2 In RecipeComparison.AsEnumerable _
                       On r1.Field(Of String)("Column1").ToString Equals r2.Field(Of String)("Column1").ToString _
                       Select r1

        'Matching rows are added to the RecipeConflicts DataTable to be used later.
        RecipeConflicts = MatchingRows.CopyToDataTable

        If RecipeConflicts.Rows.Count > 0 Then 'Conflicts to exist
            RecipesToAddLbl.Visible = False

            'Adds the column to the DataTable to allow user selection of which recipes should be overwritten.
            Dim columnn As DataColumn = RecipeConflicts.Columns.Add("Import", Type.GetType("System.Boolean"))
            columnn.ReadOnly = False
            For Each row In RecipeConflicts.Rows
                row.Item(row.Table.Columns("Import").Ordinal) = False
            Next

            DataGridView2.DataSource = RecipeConflicts
            RecipesToAddLbl.BackColor = SystemColors.AppWorkspace
            DataGridView2.BackgroundColor = Color.Gray
            ImportRecipesCmdBtn.Enabled = True
            ImportRecipesCmdBtn.BackColor = SystemColors.Control
            ImportRecipesCmdBtn.Visible = True
        Else 'No conflicts found
            DataGridView2.DataSource = Nothing
            RecipesToAddLbl.Visible = True
            RecipesToAddLbl.Text = "NO CONFLICTS"
            RecipesToAddLbl.BackColor = Color.Green
            DataGridView2.BackgroundColor = Color.Green
            ImportRecipesCmdBtn.Enabled = False
            ImportRecipesCmdBtn.BackColor = SystemColors.ControlDark
            ImportRecipesCmdBtn.Visible = False
        End If

    End Sub

    Private Sub AddMaterials()

        Dim ReturnValue As Integer
        Dim i As Integer = 0
        Dim j As Integer = 0

        'Adds materials that were designated to exist from the source but not in the host.
        'MatExport is stripped of matching materials in the MaterialsToAdd method
        For Each row As DataRow In MatExport.Rows
            ReturnValue = oMaterialDB.AddMaterial(row.Item(0), row.Item(1), row.Item(2), row.Item(3), row.Item(4), row.Item(5), row.Item(6))
            If ReturnValue = 0 Then
                i += 1
            Else
                j += 1
            End If
        Next

        MessageBox.Show("There were " & i & " materials successfully added." & vbCrLf & "There were " & j & " materials that failed.")

    End Sub


    Private Sub GetMaterialsCmdBtn_Click(sender As Object, e As EventArgs) Handles GetMaterialsCmdBtn.Click

        'Reinitialize controls
        MaterialsToAddLbl.Visible = False
        DataGridView1.DataSource = Nothing

        'Export materials
        GetMaterialExport()

        'Show success
        MaterialsToAddLbl.Text = "Materials Successfully Exported"
        MaterialsToAddLbl.BackColor = Color.Green
        DataGridView1.BackgroundColor = Color.Green
        MaterialsToAddLbl.Visible = True

    End Sub

    Private Sub GetRecipeCmdBtn_Click(sender As Object, e As EventArgs) Handles GetRecipeCmdBtn.Click

        'Reinitialize controls
        RecipesToAddLbl.Visible = False
        DataGridView2.DataSource = Nothing

        'Reinitialize controls
        DataGridView2.DataSource = Nothing

        'Export recipes
        ExportRecipes()

        'Copy recipes to InBatchSync folder
        CopyRecipes()

        'Show success
        RecipesToAddLbl.Text = "Recipes Successfully Exported"
        RecipesToAddLbl.BackColor = Color.Green
        DataGridView2.BackgroundColor = Color.Green
        RecipesToAddLbl.Visible = True

    End Sub

    Private Sub ExportRecipes()

        Dim ReturnValue As Integer
        Dim aRecipes As System.Array

        'Create FileStream and StringBuilder for parsing
        Dim fs As FileStream = Nothing
        Dim sb As New StringBuilder

        'Create file if doesn't exist.
        If (Not File.Exists(RecipeExportFilename)) Then
            fs = File.Create(RecipeExportFilename)
            Using fs
            End Using
        End If

        'Get recipes using InBatch API
        aRecipes = oRecipeDB.GetRecipes

        'Progress bar
        ProgressBar1 = New ProgressBar
        ProgressBar1.Location = New Point(446, 450)
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = (aRecipes.GetUpperBound(0) * 2)
        ProgressBar1.Width = 487
        ProgressBar1.Height = 30
        ProgressBar1.ForeColor = Color.Navy

        Me.Controls.Add(ProgressBar1)
        ProgressBar1.BringToFront()

        'Recipe counter
        Dim n As Integer = 1
        Dim j As Integer = 0
        Dim k As Integer = 0


        'Write recipe information to CSV file
        Using outfile As New StreamWriter(RecipeExportFilename)

            For Each recipe In aRecipes
                ReturnValue = oRecipeDB.ExportRecipe(aRecipes(n), 1)

                If ReturnValue = True Then
                    j += 1
                ElseIf ReturnValue = False Then
                    k += 1
                End If
                'Write to file
                outfile.WriteLine(aRecipes(n).ToString & "," & oRecipeDB.ProductName & "," & oRecipeDB.RecipeID & "," & oRecipeDB.RecipeName)
                n += 1

                'Increment progress bar
                ProgressBar1.Value += 1
            Next

        End Using


    End Sub

    Private Sub ExportRecipesForImport()

        Dim aRecipes As System.Array

        'Create FileStream and StringBuilder
        Dim fs As FileStream = Nothing
        Dim sb As New StringBuilder

        'Create file if doesn't exist
        If (Not File.Exists(RecipeComparisonFileName)) Then
            fs = File.Create(RecipeComparisonFileName)
            Using fs
            End Using
        End If

        'Get recipes
        aRecipes = oRecipeDB.GetRecipes

        'Progress bar
        Dim ProgressBar1 As ProgressBar
        ProgressBar1 = New ProgressBar
        ProgressBar1.Location = New Point(446, 450)
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = aRecipes.GetUpperBound(0) + 1
        ProgressBar1.Width = 487
        ProgressBar1.Height = 30
        ProgressBar1.ForeColor = Color.Navy

        Me.Controls.Add(ProgressBar1)
        ProgressBar1.BringToFront()

        'Counter
        Dim n As Integer = 1

        'Write recipe information to file
        Using outfile As New StreamWriter(RecipeComparisonFileName)

            For Each recipe In aRecipes
                If Not oRecipeDB.Open(aRecipes(n)) Then
                    MessageBox.Show("Not open")
                End If
                'Write to file
                outfile.WriteLine(aRecipes(n).ToString & "," & oRecipeDB.ProductName & "," & oRecipeDB.RecipeID & "," & oRecipeDB.RecipeName)
                n += 1

                'Incremenet progress bar
                ProgressBar1.Value = n
            Next

        End Using

        Me.Controls.Remove(ProgressBar1)

    End Sub

    Private Sub CopyRecipes()

        'For each file of type rcp copy to copy directory
        For Each f In Directory.GetFiles(RecipeRCPCopyPath, "*.rcp", SearchOption.TopDirectoryOnly)
            If File.Exists(f) Then
                'Copy then delete file
                File.Copy(f, Path.Combine(RecipercpExportPath, Path.GetFileName(f)), True)
                File.Delete(f)
            End If
            ProgressBar1.Value += 1
        Next

        Me.Controls.Remove(ProgressBar1)
    End Sub

    Private Sub ImportMaterialsCmdBtn_Click(sender As Object, e As EventArgs)

        'Add materials that dont' exist.
        AddMaterials()

    End Sub

    Private Sub CloseCmdBtn_Click(sender As Object, e As EventArgs) Handles CloseCmdBtn.Click

        'Close application
        Application.Exit()

    End Sub

    Private Sub ImportRecipesCmdBtn_Click(sender As Object, e As EventArgs) Handles ImportRecipesCmdBtn.Click

        'Add selected recipes that were shown to already exist and were selected to overwrite existing by user
        AddRecipeConflicts()

    End Sub

    Private Sub AddNewRecipes()

        Dim ReturnValue As Integer
        'Path where the RecipeExport method delivers exported files and where we want to copy them to.
        Dim RecipercpExportPath As String = "C:\Program Files (x86)\Wonderware\InBatch\cfg\Config_A\InBatchSync\RecipercpExport\"
        Dim RecipeRCPCopyPath As String = "C:\Program Files (x86)\Wonderware\InBatch\cfg\Config_A\"

        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim k As Integer = 0

        'If rows were added to query that were in the source (RecipeExport) that didn't match the host, then add them
        'RecipeExport is stripped of all matching recipes by the RecipesToAdd method
        If RecipeExport.Rows.Count > 0 Then
            For Each row As DataRow In RecipeExport.Rows

                File.Copy(RecipercpExportPath & row.Item(0).ToString & ".rcp", RecipeRCPCopyPath & row.Item(0).ToString & ".rcp", True)
                'ReturnValue = oRecipeDB.ImportRecipe("0358255.rcp", True)
                ReturnValue = oRecipeDB.ImportRecipe(row.Item(0).ToString & ".rcp", 1)
                If ReturnValue = True Then
                    j += 1
                ElseIf ReturnValue = False Then
                    k += 1
                End If
                i += 1
            Next
            MessageBox.Show("There were " & j & " recipes successfully added." & vbCrLf & "There were " & k & " recipes that failed.")
        Else
            MessageBox.Show("There were no new recipes to add.")
        End If

    End Sub

    Private Sub AddRecipeConflicts()

        Dim ReturnValue As Integer
        'Path where the RecipeExport method delivers exported files and where we want to copy them to.
        Dim RecipercpExportPath As String = "C:\Program Files (x86)\Wonderware\InBatch\cfg\Config_A\InBatchSync\RecipercpExport\"
        Dim RecipeRCPCopyPath As String = "C:\Program Files (x86)\Wonderware\InBatch\cfg\Config_A\"

        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim k As Integer = 0

        'Adds recipes that were shown to be in conflict by a join query
        'The recipes are selected by the user by marking them for import
        If RecipeConflicts.Rows.Count > 0 Then
            For Each row As DataRow In RecipeConflicts.Rows
                If row.Item(row.Table.Columns("Import").Ordinal) = True Then
                    File.Copy(RecipercpExportPath & row.Item(0).ToString & ".rcp", RecipeRCPCopyPath & row.Item(0).ToString & ".rcp", True)
                    ReturnValue = oRecipeDB.ImportRecipe("C:\Program Files (x86)\Wonderware\InBatch\cfg\Config_A\InBatchSync\RecipeRCPExport\" & row.Item(0).ToString & ".rcp", 1)
                    If ReturnValue = True Then
                        j += 1
                    ElseIf ReturnValue = False Then
                        k += 1
                    End If
                    i += 1
                End If
            Next
            MessageBox.Show("There were " & j & " recipes successfully added." & vbCrLf & "There were " & k & " recipes that failed.")
        Else
            MessageBox.Show("There were no new recipes to add.")
        End If

    End Sub

    Private Sub ImportNewMaterialsCmdBtn_Click(sender As Object, e As EventArgs) Handles ImportNewMaterialsCmdBtn.Click

        'Get local export of materials for comparison.
        GetMaterialExportForImport()

        'Load materials from source (parent) export file.
        LoadMaterialsFromParent()

        'Load local export of materials for comparison.
        LoadMaterialsFromChild()

        'Perform comparison.
        MaterialsToAdd()

        'Perform import.
        AddMaterials()

    End Sub

    Private Sub ImportNewRecipesCmdBtn_Click(sender As Object, e As EventArgs) Handles ImportNewRecipesCmdBtn.Click

        'Get local export of recipies for comparison.
        ExportRecipesForImport()

        'Load recipes from source (parent) export file
        LoadRecipesFromParent()

        'Load local export of recipes for comparison.
        LoadRecipesFromChild()

        'Load conflicts (recipes that already exist).
        RecipesConflicts()

        'Perform comparison to find NEW recipes to add
        RecipesToAdd()

        'Add new recipes (recipes that don't exist in local export file but do in source).
        AddNewRecipes()

    End Sub
End Class
