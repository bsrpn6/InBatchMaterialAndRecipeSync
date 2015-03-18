<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GetMaterialsCmdBtn = New System.Windows.Forms.Button()
        Me.GetRecipeCmdBtn = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MaterialsToAddLbl = New System.Windows.Forms.Label()
        Me.CloseCmdBtn = New System.Windows.Forms.Button()
        Me.ImportRecipesCmdBtn = New System.Windows.Forms.Button()
        Me.RecipesToAddLbl = New System.Windows.Forms.Label()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ImportNewMaterialsCmdBtn = New System.Windows.Forms.Button()
        Me.ImportNewRecipesCmdBtn = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GetMaterialsCmdBtn
        '
        Me.GetMaterialsCmdBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GetMaterialsCmdBtn.Location = New System.Drawing.Point(49, 132)
        Me.GetMaterialsCmdBtn.Name = "GetMaterialsCmdBtn"
        Me.GetMaterialsCmdBtn.Size = New System.Drawing.Size(204, 44)
        Me.GetMaterialsCmdBtn.TabIndex = 0
        Me.GetMaterialsCmdBtn.Text = "Export Materials"
        Me.GetMaterialsCmdBtn.UseVisualStyleBackColor = True
        '
        'GetRecipeCmdBtn
        '
        Me.GetRecipeCmdBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GetRecipeCmdBtn.Location = New System.Drawing.Point(49, 383)
        Me.GetRecipeCmdBtn.Name = "GetRecipeCmdBtn"
        Me.GetRecipeCmdBtn.Size = New System.Drawing.Size(204, 44)
        Me.GetRecipeCmdBtn.TabIndex = 1
        Me.GetRecipeCmdBtn.Text = "Export Recipes"
        Me.GetRecipeCmdBtn.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(287, 132)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(805, 160)
        Me.DataGridView1.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(297, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(547, 37)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "InBatch Materials and Recipe Sync"
        '
        'MaterialsToAddLbl
        '
        Me.MaterialsToAddLbl.BackColor = System.Drawing.Color.Gray
        Me.MaterialsToAddLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaterialsToAddLbl.Location = New System.Drawing.Point(287, 196)
        Me.MaterialsToAddLbl.Name = "MaterialsToAddLbl"
        Me.MaterialsToAddLbl.Size = New System.Drawing.Size(805, 33)
        Me.MaterialsToAddLbl.TabIndex = 6
        Me.MaterialsToAddLbl.Text = "Materials To Add"
        Me.MaterialsToAddLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CloseCmdBtn
        '
        Me.CloseCmdBtn.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CloseCmdBtn.Location = New System.Drawing.Point(513, 610)
        Me.CloseCmdBtn.Name = "CloseCmdBtn"
        Me.CloseCmdBtn.Size = New System.Drawing.Size(114, 32)
        Me.CloseCmdBtn.TabIndex = 14
        Me.CloseCmdBtn.Text = "Close"
        Me.CloseCmdBtn.UseVisualStyleBackColor = True
        '
        'ImportRecipesCmdBtn
        '
        Me.ImportRecipesCmdBtn.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ImportRecipesCmdBtn.Enabled = False
        Me.ImportRecipesCmdBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImportRecipesCmdBtn.Location = New System.Drawing.Point(49, 499)
        Me.ImportRecipesCmdBtn.Name = "ImportRecipesCmdBtn"
        Me.ImportRecipesCmdBtn.Size = New System.Drawing.Size(204, 44)
        Me.ImportRecipesCmdBtn.TabIndex = 16
        Me.ImportRecipesCmdBtn.Text = "Import Conflicts"
        Me.ImportRecipesCmdBtn.UseVisualStyleBackColor = False
        Me.ImportRecipesCmdBtn.Visible = False
        '
        'RecipesToAddLbl
        '
        Me.RecipesToAddLbl.BackColor = System.Drawing.Color.Gray
        Me.RecipesToAddLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RecipesToAddLbl.Location = New System.Drawing.Point(287, 447)
        Me.RecipesToAddLbl.Name = "RecipesToAddLbl"
        Me.RecipesToAddLbl.Size = New System.Drawing.Size(805, 33)
        Me.RecipesToAddLbl.TabIndex = 18
        Me.RecipesToAddLbl.Text = "Recipes To Add"
        Me.RecipesToAddLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(287, 383)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView2.Size = New System.Drawing.Size(805, 160)
        Me.DataGridView2.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(433, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(275, 37)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Materials To Add"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(435, 343)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(270, 37)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Recipe Conflicts"
        '
        'ImportNewMaterialsCmdBtn
        '
        Me.ImportNewMaterialsCmdBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImportNewMaterialsCmdBtn.Location = New System.Drawing.Point(49, 196)
        Me.ImportNewMaterialsCmdBtn.Name = "ImportNewMaterialsCmdBtn"
        Me.ImportNewMaterialsCmdBtn.Size = New System.Drawing.Size(204, 44)
        Me.ImportNewMaterialsCmdBtn.TabIndex = 21
        Me.ImportNewMaterialsCmdBtn.Text = "Import Materials"
        Me.ImportNewMaterialsCmdBtn.UseVisualStyleBackColor = True
        '
        'ImportNewRecipesCmdBtn
        '
        Me.ImportNewRecipesCmdBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImportNewRecipesCmdBtn.Location = New System.Drawing.Point(49, 441)
        Me.ImportNewRecipesCmdBtn.Name = "ImportNewRecipesCmdBtn"
        Me.ImportNewRecipesCmdBtn.Size = New System.Drawing.Size(204, 44)
        Me.ImportNewRecipesCmdBtn.TabIndex = 22
        Me.ImportNewRecipesCmdBtn.Text = "Import Recipes"
        Me.ImportNewRecipesCmdBtn.UseVisualStyleBackColor = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1140, 655)
        Me.Controls.Add(Me.ImportNewRecipesCmdBtn)
        Me.Controls.Add(Me.ImportNewMaterialsCmdBtn)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ImportRecipesCmdBtn)
        Me.Controls.Add(Me.CloseCmdBtn)
        Me.Controls.Add(Me.MaterialsToAddLbl)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GetRecipeCmdBtn)
        Me.Controls.Add(Me.GetMaterialsCmdBtn)
        Me.Controls.Add(Me.RecipesToAddLbl)
        Me.Controls.Add(Me.DataGridView2)
        Me.Name = "Main"
        Me.Text = "Main"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GetMaterialsCmdBtn As System.Windows.Forms.Button
    Friend WithEvents GetRecipeCmdBtn As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MaterialsToAddLbl As System.Windows.Forms.Label
    Friend WithEvents CloseCmdBtn As System.Windows.Forms.Button
    Friend WithEvents ImportRecipesCmdBtn As System.Windows.Forms.Button
    Friend WithEvents RecipesToAddLbl As System.Windows.Forms.Label
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ImportNewMaterialsCmdBtn As System.Windows.Forms.Button
    Friend WithEvents ImportNewRecipesCmdBtn As System.Windows.Forms.Button

End Class
