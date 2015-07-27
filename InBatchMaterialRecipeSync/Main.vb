Imports System.IO
Imports System.Text
Imports System.Xml

Public Class Main

    'File path variables
    Public MaterialExportFilename As String = "C:\Program Files (x86)\Wonderware\InBatch\cfg\Config_A\IB_Export\SavedMaterialExport.csv"
    Public MaterialImportFilename As String = "C:\Program Files (x86)\Wonderware\InBatch\cfg\Config_A\IB_Import\SavedMaterialImport.csv"
    Public MaterialImportLogFilename As String = "C:\Program Files (x86)\Wonderware\InBatch\cfg\Config_A\IB_Import\MaterialLog.csv"

    Public RecipeExportFilename As String = "C:\Program Files (x86)\Wonderware\InBatch\cfg\Config_A\IB_Export\SavedRecipeExport.csv"
    Public RecipeExportFormulaFilename As String = "C:\Program Files (x86)\Wonderware\InBatch\cfg\Config_A\IB_Export\SavedRecipeFormulaExport.csv"
    Public RecipeXMLExportPath As String = "C:\Program Files (x86)\Wonderware\InBatch\cfg\Config_A\IB_Export\RecipeXMLExport"

    Public RecipeImportFileName As String = "C:\Program Files (x86)\Wonderware\InBatch\cfg\Config_A\IB_Import\SavedRecipeImport.csv"
    Public RecipeImportFormulaFilename As String = "C:\Program Files (x86)\Wonderware\InBatch\cfg\Config_A\IB_Import\SavedRecipeFormulaImport.csv"
    Public RecipeXMLImportPath As String = "C:\Program Files (x86)\Wonderware\InBatch\cfg\Config_A\IB_Import\RecipeXMLImport"
    Public RecipeImportLogFilename As String = "C:\Program Files (x86)\Wonderware\InBatch\cfg\Config_A\IB_Import\RecipeLog.csv"

    Dim RecipeXMLCopyPath As String = "C:\Program Files (x86)\Wonderware\InBatch\cfg\Config_A"

    'Delcaration of API variable objects and types
    Private oMaterialDB As wwMaterialLib.IMaterialDB
    Private iMaterials As wwMaterialLib.IMaterials
    Private iMaterial As wwMaterialLib.IMaterial
    Private oRecipeDB As Object
    Dim oRecipeClassType As System.Type
    Dim oMaterialClassType As System.Type

    'Delcaration of DataTables used to load information from CSVs and for maintain information for imports
    Dim MaterialImport As DataTable = New DataTable()
    Dim RecipeImportIDCrossReference As DataTable = New DataTable()
    Dim RecipeImportMaterialCrossReference As DataTable = New DataTable()
    Dim RecipeImportFormula As DataTable = New DataTable()

    'Progress Bars
    Dim ProgressBar1 As ProgressBar

    'InBatch Host server name
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
        If Not Directory.Exists(RecipeXMLExportPath) Then
            Directory.CreateDirectory(RecipeXMLExportPath)
        End If

        CenterToScreen()

    End Sub

    'Start Material Export
    Private Sub GetMaterialsCmdBtn_Click(sender As Object, e As EventArgs) Handles GetMaterialsCmdBtn.Click

        'Export materials to CSV file
        GetMaterialExport()

        MessageBox.Show("Completed")
    End Sub

    'Start Recipe Export
    Private Sub GetRecipeCmdBtn_Click(sender As Object, e As EventArgs) Handles GetRecipeCmdBtn.Click

        'Export recipes - exports recipe XML files to Config_A folder, writes Recipe Header inforamtion
        'to CSV file, and writes Recipe Formula information to another CSV file
        ExportRecipes()

        'Copy XML files from default Config_A directory to IB_Export folder
        CopyRecipeXMLExport()

        'Write CSV file with all exported recipe information
        WriteExportRecipeFile()

        'Write CSV file with all recipe formula information
        WriteExportRecipeFormulaFile()

        MessageBox.Show("Completed")
    End Sub

    'Start Material Import
    Private Sub ImportNewMaterialsCmdBtn_Click(sender As Object, e As EventArgs) Handles ImportNewMaterialsCmdBtn.Click

        'Load materials cross reference of old ID numbers vs new ID numbers into a datatable for faster access
        LoadRecipeImportMaterialCrossReference()

        'Load RecipeImportFormula - used strictly for progress bar incrementing at this time
        LoadRecipeImportFormula()

        'Modify XML files
        ModifyXMLImportMaterialsAndSave()

        'Perform import.
        AddMaterials()

        MessageBox.Show("Completed")

    End Sub

    'Start Recipe Import
    Private Sub ImportNewRecipesCmdBtn_Click(sender As Object, e As EventArgs) Handles ImportNewRecipesCmdBtn.Click
        'Load recipe cross reference of old ID numbers vs new ID numbers
        LoadRecipeImportIDCrossReference()

        'Modify XML files and save to Config_A folder
        ModifyXMLImportRecipeIDAndSave()

        'Add new recipes (recipes that don't exist in local export file but do in source)
        ImportRecipes()

        MessageBox.Show("Completed")

    End Sub

    'Close Application
    Private Sub CloseCmdBtn_Click(sender As Object, e As EventArgs) Handles CloseCmdBtn.Click

        'Close application
        Application.Exit()

    End Sub

    'Uses wwMaterialLib.wwMaterial to write material information to CSV file
    Private Sub GetMaterialExport()

        Dim Mats As wwMaterialLib.wwMaterials
        Dim Material As wwMaterialLib.wwMaterial

        'Create FileStream and StringBuilder
        Dim fs As FileStream = Nothing
        Dim sb As New StringBuilder

        'Creates file if doesn't exist
        If (Not File.Exists(MaterialExportFilename)) Then
            fs = File.Create(MaterialExportFilename)
            Using fs
            End Using
        End If

        'Query for materials of type Ingredient from host
        oMaterialDB.QueryMaterialsByType(wwMaterialLib.wwMtrlTypeEnum.wwTypeIngredient)

        Mats = oMaterialDB.Materials
        Dim n As Integer = 1

        'Progress bar
        ProgressBar1 = New ProgressBar
        ProgressBar1.Location = New Point(166, 307)
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = (Mats.Count)
        ProgressBar1.Width = 362
        ProgressBar1.Height = 30
        ProgressBar1.ForeColor = Color.Navy

        Me.Controls.Add(ProgressBar1)
        ProgressBar1.BringToFront()

        'Write materials to CSV file
        Using outfile As New StreamWriter(MaterialExportFilename)
            outfile.WriteLine("ID" & "," & "Name" & "," & "Type" & "," & "Description" & "," & "UnitOfMeasure" & "," & "HiDev" & "," & "LoDev")

            For Each Material In Mats
                outfile.Write(Mats.Item(n).ID.ToString & ",")
                outfile.Write(Mats.Item(n).Name.ToString.Replace(",", "^") & ",")
                outfile.Write(Mats.Item(n).Type.ToString.Replace(",", "^") & ",")
                outfile.Write(Mats.Item(n).Description.ToString.Replace(",", "^") & ",")
                outfile.Write(Mats.Item(n).UnitOfMeasure.ToString & ",")
                outfile.Write(Mats.Item(n).HiDev.ToString & ",")
                outfile.Write(Mats.Item(n).LoDev.ToString)
                outfile.WriteLine()

                n += 1

                ProgressBar1.Value = ProgressBar1.Value + 1
            Next

        End Using

        Me.Controls.Remove(ProgressBar1)

    End Sub

    'Uses oRecipeDB.ExportRecipeXML to export XML files to Config_A directory
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
        ProgressBar1.Location = New Point(166, 307)
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = (aRecipes.GetUpperBound(0) * 4)
        ProgressBar1.Width = 362
        ProgressBar1.Height = 30
        ProgressBar1.ForeColor = Color.Navy

        Me.Controls.Add(ProgressBar1)
        ProgressBar1.BringToFront()

        'Recipe counter
        Dim n As Integer = 1
        Dim j As Integer = 0
        Dim k As Integer = 0


        For Each recipe In aRecipes
            ReturnValue = oRecipeDB.ExportRecipeXML(aRecipes(n), 1)

            If ReturnValue = True Then
                j += 1
            ElseIf ReturnValue = False Then
                k += 1
            End If

            n += 1

            'Increment progress bar
            ProgressBar1.Value += 1

        Next

    End Sub

    'Copies XML files in Config_A directory to IB_Export directory
    Private Sub CopyRecipeXMLExport()

        'For each file of type XML copy to copy directory
        For Each f In Directory.GetFiles(RecipeXMLCopyPath, "*.XML", SearchOption.TopDirectoryOnly)

            If File.Exists(f) Then
                'Copy then delete file
                File.Copy(f, Path.Combine(RecipeXMLExportPath, Path.GetFileName(f)), True)
                File.Delete(f)
            End If
            ProgressBar1.Value += 1

        Next

    End Sub

    'Traverses through all XML files in IB_Export directory to collect recipe header information, writing to CSV file
    Private Sub WriteExportRecipeFile()
        Dim doc As New XmlDocument
        Dim namespaces As XmlNamespaceManager

        'Must delcare namespaces since they are part of the document...
        namespaces = New XmlNamespaceManager(doc.NameTable)
        namespaces.AddNamespace("xsi", "http: //www.w3.org/2001/XMLSchema-instance")
        namespaces.AddNamespace("a", "http://www.wbf.org/xml/B2MML-V0401")
        namespaces.AddNamespace("b", "http://www.wbf.org/xml/B2MML-V0401-AllExtensions")

        Using outfile As New StreamWriter(RecipeExportFilename)

            outfile.WriteLine("ID" & "," & "ProductID" & "," & "ProductName" & "," & "ApprovedForProduction" & "," & "Name")

            'For each file of type XML copy to copy directory
            For Each f In Directory.GetFiles(RecipeXMLExportPath, "*.XML", SearchOption.TopDirectoryOnly)
                doc.Load(f)

                Dim ID As String = doc.SelectSingleNode("/a:BatchInformation/a:MasterRecipe/a:ID", namespaces).InnerText
                Dim ProductID As String = doc.SelectSingleNode("/a:BatchInformation/a:MasterRecipe/a:Header/a:ProductID", namespaces).InnerText
                Dim ProductName As String = doc.SelectSingleNode("/a:BatchInformation/a:MasterRecipe/a:Header/a:ProductName", namespaces).InnerText
                Dim ApprovedForProduction As String = doc.SelectSingleNode("/a:BatchInformation/a:MasterRecipe/a:Header/b:ApprovedForProduction", namespaces).InnerText
                Dim Name As String = doc.SelectSingleNode("/a:BatchInformation/a:MasterRecipe/b:Name", namespaces).InnerText

                outfile.WriteLine(ID & "," & ProductID & "," & ProductName & "," & ApprovedForProduction & "," & Name)

                'Increment progress bar
                ProgressBar1.Value += 1

            Next

        End Using

    End Sub

    'Traverses through all XML files in IB_Export directory to collect recipe parameter information, writing to CSV file
    Private Sub WriteExportRecipeFormulaFile()
        Dim doc As New XmlDocument
        Dim namespaces As XmlNamespaceManager

        'Must delcare namespaces since they are part of the document...
        namespaces = New XmlNamespaceManager(doc.NameTable)
        namespaces.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance")
        namespaces.AddNamespace("a", "http://www.wbf.org/xml/B2MML-V0401")

        Dim ID As String
        Dim ParameterId As String
        Dim ParameterType As String
        Dim MaterialID As String

        Using outfile As New StreamWriter(RecipeExportFormulaFilename)

            outfile.WriteLine("ID" & "," & "ParameterID" & "," & "ParameterType" & "," & "MaterialID")

            'For each file of type XML copy to copy directory
            For Each f In Directory.GetFiles(RecipeXMLExportPath, "*.XML", SearchOption.TopDirectoryOnly)
                doc.Load(f)

                ID = doc.SelectSingleNode("/a:BatchInformation/a:MasterRecipe/a:ID", namespaces).InnerText

                Dim Parameters As XmlNodeList = doc.SelectNodes("/a:BatchInformation/a:MasterRecipe/a:Formula/a:Parameter", namespaces)

                For Each Parameter In Parameters
                    ParameterType = Parameter("ParameterType").InnerText

                    If ParameterType = "ProcessInput" Then
                        ParameterId = Parameter("ID").InnerText
                        MaterialID = Parameter("MaterialID").InnerText
                        outfile.WriteLine(ID & "," & ParameterId & "," & ParameterType & "," & MaterialID)
                    End If

                Next

                'Increment progress bar
                ProgressBar1.Value += 1
            Next
        End Using

        Me.Controls.Remove(ProgressBar1)
    End Sub

    'Reads in SavedMaterialImport file into datatable to be accessed through memory 
    Private Sub LoadRecipeImportMaterialCrossReference()

        RecipeImportIDCrossReference.Clear()

        'Create Streamreader
        Dim SR As StreamReader = New StreamReader(MaterialImportFilename)

        'Reads CSV file into arrays split by ", "
        Dim i As Long = 0
        Dim line As String = SR.ReadLine
        Dim strArray As String() = line.Split(", ")

        Dim row As DataRow

        For Each s As String In strArray
            RecipeImportMaterialCrossReference.Columns.Add(New DataColumn(s, GetType(String)))
        Next

        'Adds split arrays as rows into DataTable RecipeComparison
        Do
            line = SR.ReadLine
            If Not line = Nothing Then
                row = RecipeImportMaterialCrossReference.NewRow
                row.ItemArray = line.Split(",")
                RecipeImportMaterialCrossReference.Rows.Add(row)
            Else
                Exit Do
            End If
        Loop

    End Sub

    'Reads in Saved
    Private Sub LoadRecipeImportFormula()

        RecipeImportFormula.Clear()

        'Create Streamreader
        Dim SR As StreamReader = New StreamReader(RecipeImportFormulaFilename)

        'Reads CSV file into arrays split by ", "
        Dim i As Long = 0
        Dim line As String = SR.ReadLine
        Dim strArray As String() = line.Split(", ")

        Dim row As DataRow

        For Each s As String In strArray
            RecipeImportFormula.Columns.Add(New DataColumn(s, GetType(String)))
        Next

        'Adds split arrays as rows into DataTable RecipeComparison
        Do
            line = SR.ReadLine
            If Not line = Nothing Then
                row = RecipeImportFormula.NewRow
                row.ItemArray = line.Split(",")
                RecipeImportFormula.Rows.Add(row)
            Else
                Exit Do
            End If
        Loop

    End Sub

    'Traverses through all XML files in IB_Import\RecipeXMLImport directory, re-identifying all material IDs using pre-loaded data table.
    Private Sub ModifyXMLImportMaterialsAndSave()
        Dim doc As New XmlDocument
        Dim namespaces As XmlNamespaceManager

        'Must delcare namespaces since they are part of the document...
        namespaces = New XmlNamespaceManager(doc.NameTable)
        namespaces.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance")
        namespaces.AddNamespace("a", "http://www.wbf.org/xml/B2MML-V0401")

        Dim ParameterType As String
        Dim RecipeID As String
        Dim ParameterID As String
        Dim MaterialID As String
        Dim NewMaterialID As String = ""
        Dim Modified As String = "False"

        'Progress bar
        ProgressBar1 = New ProgressBar
        ProgressBar1.Location = New Point(166, 307)
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = (RecipeImportFormula.Rows.Count + RecipeImportMaterialCrossReference.Rows.Count)
        ProgressBar1.Width = 362
        ProgressBar1.Height = 30
        ProgressBar1.ForeColor = Color.Navy

        Me.Controls.Add(ProgressBar1)
        ProgressBar1.BringToFront()

        'For each file of type XML copy to copy directory
        For Each f In Directory.GetFiles(RecipeXMLImportPath, "*.XML", SearchOption.TopDirectoryOnly)
            doc.Load(f)

            RecipeID = doc.SelectSingleNode("/a:BatchInformation/a:MasterRecipe/a:ID", namespaces).InnerText

            Dim Parameters As XmlNodeList = doc.SelectNodes("/a:BatchInformation/a:MasterRecipe/a:Formula/a:Parameter", namespaces)


            For Each Parameter In Parameters
                ParameterType = Parameter("ParameterType").InnerText
                ParameterID = Parameter("ID").InnerText

                If ParameterType = "ProcessInput" Then
                    Modified = "False"

                    MaterialID = Parameter("MaterialID").InnerText
                    Dim NewIDRow() As DataRow = RecipeImportMaterialCrossReference.Select("ID = '" & MaterialID & "'")

                    For Each row As DataRow In NewIDRow
                        NewMaterialID = row(1)
                        Parameter("MaterialID").InnerText = NewMaterialID
                        Modified = "True"
                    Next

                    ProgressBar1.Value = ProgressBar1.Value + 1

                    Logger(("ModifyXMLParameter" & "," & "RecipeID: " & RecipeID & "," & "ParameterID: " & ParameterID & "," & "OldMaterialID: " & MaterialID & "," & "NewMaterialID: " & NewMaterialID & "," & Modified), "Material")

                End If

            Next

            doc.Save(f)

        Next

    End Sub

    'Uses data table and oMaterialDB.AddMaterial method to import new materials
    Private Sub AddMaterials()

        Dim ReturnValue As Integer
        Dim i As Integer = 0
        Dim j As Integer = 0

        'Adds materials that were designated to exist from the source but not in the host.
        'MatExport is stripped of matching materials in the MaterialsToAdd method

        For Each row As DataRow In RecipeImportMaterialCrossReference.Rows
            ReturnValue = oMaterialDB.AddMaterial(row(1), row(2), row(4), row(3), row(5), Convert.ToDouble(row(6)), Convert.ToDouble(row(7)))
            If ReturnValue = 0 Then
                i += 1
                Logger(("AddMaterials" & "," & "OldMaterialID: & " & row(0) & "," & "NewMaterialID" & row(1) & "," & "," & "," & "True"), "Material")
            Else
                j += 1
                Logger(("AddMaterials" & "," & "OldMaterialID: & " & row(0) & "," & "NewMaterialID" & row(1) & "," & "," & "," & "False"), "Material")
            End If

            ProgressBar1.Value = ProgressBar1.Value + 1
        Next

        Me.Controls.Remove(ProgressBar1)
        MessageBox.Show("There were " & i & " materials successfully added." & vbCrLf & "There were " & j & " materials that failed.")

    End Sub

    'Reads in SavedRecipeImport file into datatable to be accessed through memory
    Private Sub LoadRecipeImportIDCrossReference()

        RecipeImportIDCrossReference.Clear()

        'Create Streamreader
        Dim SR As StreamReader = New StreamReader(RecipeImportFileName)

        'Reads CSV file into arrays split by ", "
        Dim i As Long = 0
        Dim line As String = SR.ReadLine
        Dim strArray As String() = line.Split(", ")

        Dim row As DataRow

        For Each s As String In strArray
            RecipeImportIDCrossReference.Columns.Add(New DataColumn(s, GetType(String)))
        Next

        'Adds split arrays as rows into DataTable RecipeComparison
        Do
            line = SR.ReadLine
            If Not line = Nothing Then
                row = RecipeImportIDCrossReference.NewRow
                row.ItemArray = line.Split(", ")
                RecipeImportIDCrossReference.Rows.Add(row)
            Else
                Exit Do
            End If
        Loop

    End Sub

    'Traverses through all XML files in IB_Import\RecipeXMLImport modifying Recipe ID and the file name
    Private Sub ModifyXMLImportRecipeIDAndSave()

        Dim doc As New XmlDocument
        Dim namespaces As XmlNamespaceManager

        'Must delcare namespaces since they are part of the document...
        namespaces = New XmlNamespaceManager(doc.NameTable)
        namespaces.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance")
        namespaces.AddNamespace("a", "http://www.wbf.org/xml/B2MML-V0401")

        Dim ID As String
        Dim NewID As String = ""

        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim k As Integer = 0

        Dim Modified As String

        ProgressBar1 = New ProgressBar
        ProgressBar1.Location = New Point(166, 307)
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = (Directory.GetFiles(RecipeXMLImportPath, "*.XML", SearchOption.TopDirectoryOnly).Length * 4)
        ProgressBar1.Width = 362
        ProgressBar1.Height = 30
        ProgressBar1.ForeColor = Color.Navy

        Me.Controls.Add(ProgressBar1)
        ProgressBar1.BringToFront()

        'Traverse through all files in IB_Import\RecipeXMLImport
        For Each f In Directory.GetFiles(RecipeXMLImportPath, "*.XML", SearchOption.TopDirectoryOnly)

            Modified = "False"

            doc.Load(f)

            'Find ID field in XML file
            ID = doc.SelectSingleNode("/a:BatchInformation/a:MasterRecipe/a:ID", namespaces).InnerText

            'Search for cross reference in datatable
            Dim NewIDRow() As DataRow = RecipeImportIDCrossReference.Select("ID = '" & ID & "'")

            'Write new ID value, save to Config_A with new ID name
            For Each row As DataRow In NewIDRow
                NewID = row(1)
                doc.SelectSingleNode("/a:BatchInformation/a:MasterRecipe/a:ID", namespaces).InnerText = NewID
                doc.SelectSingleNode("/a:BatchInformation/a:MasterRecipe/a:Header/a:ProductID", namespaces).InnerText = NewID
                doc.Save(RecipeXMLCopyPath & "\" & NewID & ".xml")

                Modified = "True"
            Next

            Logger(("ModiifyXMLRecipeID" & "," & "OldRecipeID: & " & ID & "," & "New RecipeID: " & NewID & "," & Modified), "Recipe")

            ProgressBar1.Value = ProgressBar1.Value + 1

        Next
    End Sub

    'Uses oRecipeDB.ImportRecipe to import XML recipe files
    Private Sub ImportRecipes()

        Dim ReturnValue As Integer = 0

        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim k As Integer = 0

        'Traverse each XML file in Config_A directory, import each file as new Recipe. If already exists, recipe will be overwritten with new file
        For Each f In Directory.GetFiles(RecipeXMLCopyPath, "*.XML", SearchOption.TopDirectoryOnly)

            ReturnValue = oRecipeDB.ImportRecipe(Path.GetFileName(f), 1)

            If ReturnValue = True Then 'Imported
                j += 1
                Logger(("AddRecipes" & "," & "RecipeID: " & Path.GetFileNameWithoutExtension(f) & "," & "," & "True"), "Recipe")
            ElseIf ReturnValue = False Then 'Failed
                k += 1
                Logger(("AddRecipes" & "," & "RecipeID: " & Path.GetFileNameWithoutExtension(f) & "," & "," & "False"), "Recipe")
            End If
            i += 1

            File.Delete(f)

            ProgressBar1.Value = ProgressBar1.Value + 1
        Next

        MessageBox.Show("There were " & j & " recipes successfully added." & vbCrLf & "There were " & k & " recipes that failed.")

        Me.Controls.Remove(ProgressBar1)


    End Sub

    'Routine used to write to MaterialLog or RecipeLog
    Public Sub Logger(LogString As String, Item As String)
        Dim Path As String

        'Two files are created for logs, one for materials and one for recipes. Only for imports do these log files matter
        Select Case Item
            Case "Material"
                Path = MaterialImportLogFilename
            Case "Recipe"
                Path = RecipeImportLogFilename
            Case Else
                Path = ""
        End Select

        If Path <> "" Then
            Using outfile As New StreamWriter(Path, True)
                outfile.WriteLine(LogString)
            End Using
        End If

    End Sub
End Class
