Imports System
Imports System.IO
Imports System.Text
Imports System.Collections.Generic

Public Class Main

    Public ImportFilename As String
    Public ComparisonFileName As String

    Public HostName As String = System.Environment.GetEnvironmentVariable("COMPUTERNAME")

    Private oMaterialDB As wwMaterialLib.IMaterialDB
    Private iMaterials As wwMaterialLib.IMaterials
    Private iMaterial As wwMaterialLib.IMaterial
    Private oRecipeDB As Object

    Dim oClassType As System.Type

    Dim dt As DataTable = New DataTable()
    Dim dt2 As DataTable = New DataTable()

    Dim BatchServerHostName As String = "localhost"

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles Me.Load
        CenterToScreen()

    End Sub

    Private Sub GetMaterials()

        oClassType = System.Type.GetTypeFromProgID("Wonderware.MaterialSrv.wwMaterialDB.1", BatchServerHostName)
        oMaterialDB = System.Activator.CreateInstance(oClassType)

        If IsDBNull(oMaterialDB) Then
            MessageBox.Show("Error")
        End If

        Dim Mats As wwMaterialLib.wwMaterials
        Dim Material As wwMaterialLib.wwMaterial

        Dim fileLoc As String = "C:\SavedExport_" & HostName & "_" & Now().ToString("MMddyy-HHmm") & ".txt"
        Dim fs As FileStream = Nothing
        Dim sb As New StringBuilder

        If (Not File.Exists(fileLoc)) Then
            fs = File.Create(fileLoc)
            Using fs

            End Using
        End If

        oMaterialDB.QueryMaterialsByType(wwMaterialLib.wwMtrlTypeEnum.wwTypeIngredient)

        Mats = oMaterialDB.Materials
        Dim n As Integer = 1

        Using outfile As New StreamWriter(fileLoc)
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

        ComparisonFileName = fileLoc

        MessageBox.Show("Materials exported successfully to " & ComparisonFileName)

    End Sub

    Private Sub LoadMaterialsFromParent()

        Dim SR As StreamReader = New StreamReader(ImportFilename)

        Dim i As Long = 0
        Dim line As String = SR.ReadLine
        Dim strArray As String() = line.Split(",")

        Dim row As DataRow

        For Each s As String In strArray
            dt.Columns.Add(New DataColumn())
        Next

        Do
            line = SR.ReadLine
            If Not line = Nothing Then
                row = dt.NewRow
                row.ItemArray = line.Split(",")
                dt.Rows.Add(row)
            Else
                Exit Do
            End If
        Loop

    End Sub

    Private Sub LoadMaterialsFromChild()

        Dim SR As StreamReader = New StreamReader(ComparisonFileName)

        Dim i As Long = 0
        Dim line As String = SR.ReadLine
        Dim strArray As String() = line.Split(",")

        Dim row As DataRow

        For Each s As String In strArray
            dt2.Columns.Add(New DataColumn())
        Next

        Do
            line = SR.ReadLine
            If Not line = Nothing Then
                row = dt2.NewRow
                row.ItemArray = line.Split(",")
                dt2.Rows.Add(row)
            Else
                Exit Do
            End If
        Loop

    End Sub

    Private Sub MaterialsToAdd()

        Dim RowsToDelete = From r1 In dt.AsEnumerable _
                       Join r2 In dt2.AsEnumerable _
                       On r1.Field(Of String)("Column1").ToString Equals r2.Field(Of String)("Column1").ToString _
                       Select r1

        For Each row As DataRow In RowsToDelete.ToArray
            row.Delete()
        Next

        If dt.Rows.Count > 0 Then
            MaterialsToAddLbl.Visible = False
            DataGridView1.DataSource = dt
            MaterialsToAddLbl.BackColor = SystemColors.AppWorkspace
            DataGridView1.BackgroundColor = Color.Gray
            ImportMaterialsCmdBtn.Enabled = True
            ImportMaterialsCmdBtn.BackColor = SystemColors.Control
        Else
            DataGridView1.DataSource = Nothing
            MaterialsToAddLbl.Visible = True
            MaterialsToAddLbl.Text = "NO NEW MATERIALS TO ADD"
            MaterialsToAddLbl.BackColor = Color.Green
            DataGridView1.BackgroundColor = Color.Green
            ImportMaterialsCmdBtn.Enabled = False
            ImportMaterialsCmdBtn.BackColor = SystemColors.ControlDark
        End If

    End Sub

    Private Sub AddMaterials()

        Dim ReturnValue As Integer
        Dim i As Integer = 0
        Dim j As Integer = 0

        oClassType = System.Type.GetTypeFromProgID("Wonderware.MaterialSrv.wwMaterialDB.1", BatchServerHostName)
        oMaterialDB = System.Activator.CreateInstance(oClassType)

        If IsDBNull(oMaterialDB) Then
            MessageBox.Show("Error")
        End If

        For Each row As DataRow In dt.Rows
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

        GetMaterials()

    End Sub

    Private Sub GetRecipeCmdBtn_Click(sender As Object, e As EventArgs) Handles GetRecipeCmdBtn.Click

        ExportRecipes()
        CopyRecipes()

    End Sub

    Private Sub ExportRecipes()
        Dim returnval As Integer
        Dim NumVersions As Integer = 0
        Dim Dates As Object = Nothing
        Dim Authors As Object = Nothing
        Dim Comments As Object = Nothing

        Dim aRecipes As System.Array
        oClassType = System.Type.GetTypeFromProgID("Wonderware.RecipeEdit.wwRecipe", BatchServerHostName)
        oRecipeDB = System.Activator.CreateInstance(oClassType)

        Dim fileLoc As String = "c:\recipesave.txt"
        Dim fs As FileStream = Nothing
        Dim sb As New StringBuilder

        If (Not File.Exists(fileLoc)) Then
            fs = File.Create(fileLoc)
            Using fs

            End Using
        End If

        If IsDBNull(oRecipeDB) Then
            MessageBox.Show("Error with oRecipeDB.")
        End If

        'Get recipes
        aRecipes = oRecipeDB.GetRecipes

        Dim ProgressBar1 As ProgressBar
        ProgressBar1 = New ProgressBar
        ProgressBar1.Location = New Point(446, 335)
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = aRecipes.GetUpperBound(0) + 1
        ProgressBar1.Width = 487
        ProgressBar1.Height = 30
        ProgressBar1.ForeColor = Color.Navy
        Me.Controls.Add(ProgressBar1)

        Dim n As Integer = 1

        Using outfile As New StreamWriter(fileLoc)

            For Each recipe In aRecipes
                returnval = oRecipeDB.ExportRecipeXML(aRecipes(n), 1)
                oRecipeDB.Open(aRecipes(n))
                'returnval = oRecipeDB.GetRecipeHistory(NumVersions, Dates, Authors, Comments)
                outfile.WriteLine(aRecipes(n).ToString & ", ")
                n += 1
                ProgressBar1.Value = n
            Next

        End Using

        Me.Controls.Remove(ProgressBar1)

        MessageBox.Show("There were " & n - 1 & " recipes exported to XML.")
    End Sub

    Private Sub LoadMaterialsCmdBtn_Click(sender As Object, e As EventArgs) Handles LoadMaterialsCmdBtn.Click

        Dim frm As New FileSelectDialog
        frm.ShowDialog()

        dt.Clear()
        dt2.Clear()
        DataGridView1.DataSource = Nothing

        If ImportFilename <> Nothing And ComparisonFileName <> Nothing Then
            LoadMaterialsFromParent()
            LoadMaterialsFromChild()
            MaterialsToAdd()
        Else
            ImportMaterialsCmdBtn.Enabled = False
            ImportMaterialsCmdBtn.BackColor = SystemColors.ControlDark
            MaterialsToAddLbl.BackColor = SystemColors.AppWorkspace
            MaterialsToAddLbl.Text = "No files selected."
            MaterialsToAddLbl.Visible = True
            DataGridView1.BackgroundColor = Color.Gray
        End If

        ImportFilename = Nothing
        ComparisonFileName = Nothing

    End Sub

    Private Sub CopyRecipes()


        For Each f In Directory.GetFiles("C:\Program Files (x86)\Wonderware\InBatch\cfg\Config_A", "*.xml", SearchOption.TopDirectoryOnly)
            If File.Exists(f) Then
                File.Copy(f, Path.Combine("C:\InBatchRecipes", Path.GetFileName(f)), True)
            End If
        Next
    End Sub

    Private Sub ImportMaterialsCmdBtn_Click(sender As Object, e As EventArgs) Handles ImportMaterialsCmdBtn.Click

        AddMaterials()

    End Sub

    Private Sub CloseCmdBtn_Click(sender As Object, e As EventArgs) Handles CloseCmdBtn.Click

        Application.Exit()

    End Sub

End Class
