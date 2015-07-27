<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.GetMaterialsCmdBtn = New System.Windows.Forms.Button()
        Me.GetRecipeCmdBtn = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CloseCmdBtn = New System.Windows.Forms.Button()
        Me.ImportNewMaterialsCmdBtn = New System.Windows.Forms.Button()
        Me.ImportNewRecipesCmdBtn = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'GetMaterialsCmdBtn
        '
        Me.GetMaterialsCmdBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GetMaterialsCmdBtn.Location = New System.Drawing.Point(99, 154)
        Me.GetMaterialsCmdBtn.Name = "GetMaterialsCmdBtn"
        Me.GetMaterialsCmdBtn.Size = New System.Drawing.Size(204, 44)
        Me.GetMaterialsCmdBtn.TabIndex = 0
        Me.GetMaterialsCmdBtn.Text = "Export Materials"
        Me.GetMaterialsCmdBtn.UseVisualStyleBackColor = True
        '
        'GetRecipeCmdBtn
        '
        Me.GetRecipeCmdBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GetRecipeCmdBtn.Location = New System.Drawing.Point(99, 221)
        Me.GetRecipeCmdBtn.Name = "GetRecipeCmdBtn"
        Me.GetRecipeCmdBtn.Size = New System.Drawing.Size(204, 44)
        Me.GetRecipeCmdBtn.TabIndex = 1
        Me.GetRecipeCmdBtn.Text = "Export Recipes"
        Me.GetRecipeCmdBtn.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(74, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(547, 37)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "InBatch Materials and Recipe Sync"
        '
        'CloseCmdBtn
        '
        Me.CloseCmdBtn.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CloseCmdBtn.Location = New System.Drawing.Point(290, 421)
        Me.CloseCmdBtn.Name = "CloseCmdBtn"
        Me.CloseCmdBtn.Size = New System.Drawing.Size(114, 32)
        Me.CloseCmdBtn.TabIndex = 14
        Me.CloseCmdBtn.Text = "Close"
        Me.CloseCmdBtn.UseVisualStyleBackColor = True
        '
        'ImportNewMaterialsCmdBtn
        '
        Me.ImportNewMaterialsCmdBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImportNewMaterialsCmdBtn.Location = New System.Drawing.Point(391, 154)
        Me.ImportNewMaterialsCmdBtn.Name = "ImportNewMaterialsCmdBtn"
        Me.ImportNewMaterialsCmdBtn.Size = New System.Drawing.Size(204, 44)
        Me.ImportNewMaterialsCmdBtn.TabIndex = 21
        Me.ImportNewMaterialsCmdBtn.Text = "Import Materials"
        Me.ImportNewMaterialsCmdBtn.UseVisualStyleBackColor = True
        '
        'ImportNewRecipesCmdBtn
        '
        Me.ImportNewRecipesCmdBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImportNewRecipesCmdBtn.Location = New System.Drawing.Point(391, 221)
        Me.ImportNewRecipesCmdBtn.Name = "ImportNewRecipesCmdBtn"
        Me.ImportNewRecipesCmdBtn.Size = New System.Drawing.Size(204, 44)
        Me.ImportNewRecipesCmdBtn.TabIndex = 22
        Me.ImportNewRecipesCmdBtn.Text = "Import Recipes"
        Me.ImportNewRecipesCmdBtn.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(129, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(145, 37)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "EXPORT"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(424, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(138, 37)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "IMPORT"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(694, 491)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ImportNewRecipesCmdBtn)
        Me.Controls.Add(Me.ImportNewMaterialsCmdBtn)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CloseCmdBtn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GetRecipeCmdBtn)
        Me.Controls.Add(Me.GetMaterialsCmdBtn)
        Me.Name = "Main"
        Me.Text = "Main"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GetMaterialsCmdBtn As System.Windows.Forms.Button
    Friend WithEvents GetRecipeCmdBtn As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CloseCmdBtn As System.Windows.Forms.Button
    Friend WithEvents ImportNewMaterialsCmdBtn As System.Windows.Forms.Button
    Friend WithEvents ImportNewRecipesCmdBtn As System.Windows.Forms.Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class
