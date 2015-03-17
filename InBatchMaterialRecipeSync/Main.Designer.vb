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
        Me.LoadMaterialsCmdBtn = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ImportMaterialsCmdBtn = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MaterialsToAddLbl = New System.Windows.Forms.Label()
        Me.CloseCmdBtn = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GetMaterialsCmdBtn
        '
        Me.GetMaterialsCmdBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GetMaterialsCmdBtn.Location = New System.Drawing.Point(49, 73)
        Me.GetMaterialsCmdBtn.Name = "GetMaterialsCmdBtn"
        Me.GetMaterialsCmdBtn.Size = New System.Drawing.Size(204, 44)
        Me.GetMaterialsCmdBtn.TabIndex = 0
        Me.GetMaterialsCmdBtn.Text = "Create Local Export"
        Me.GetMaterialsCmdBtn.UseVisualStyleBackColor = True
        '
        'GetRecipeCmdBtn
        '
        Me.GetRecipeCmdBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GetRecipeCmdBtn.Location = New System.Drawing.Point(49, 324)
        Me.GetRecipeCmdBtn.Name = "GetRecipeCmdBtn"
        Me.GetRecipeCmdBtn.Size = New System.Drawing.Size(204, 44)
        Me.GetRecipeCmdBtn.TabIndex = 1
        Me.GetRecipeCmdBtn.Text = "Get Recipes"
        Me.GetRecipeCmdBtn.UseVisualStyleBackColor = True
        '
        'LoadMaterialsCmdBtn
        '
        Me.LoadMaterialsCmdBtn.BackColor = System.Drawing.SystemColors.Control
        Me.LoadMaterialsCmdBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LoadMaterialsCmdBtn.Location = New System.Drawing.Point(49, 131)
        Me.LoadMaterialsCmdBtn.Name = "LoadMaterialsCmdBtn"
        Me.LoadMaterialsCmdBtn.Size = New System.Drawing.Size(204, 44)
        Me.LoadMaterialsCmdBtn.TabIndex = 2
        Me.LoadMaterialsCmdBtn.Text = "Compare Exports"
        Me.LoadMaterialsCmdBtn.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(287, 73)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(805, 160)
        Me.DataGridView1.TabIndex = 3
        '
        'ImportMaterialsCmdBtn
        '
        Me.ImportMaterialsCmdBtn.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ImportMaterialsCmdBtn.Enabled = False
        Me.ImportMaterialsCmdBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImportMaterialsCmdBtn.Location = New System.Drawing.Point(49, 189)
        Me.ImportMaterialsCmdBtn.Name = "ImportMaterialsCmdBtn"
        Me.ImportMaterialsCmdBtn.Size = New System.Drawing.Size(204, 44)
        Me.ImportMaterialsCmdBtn.TabIndex = 4
        Me.ImportMaterialsCmdBtn.Text = "Import New Materials"
        Me.ImportMaterialsCmdBtn.UseVisualStyleBackColor = False
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
        Me.MaterialsToAddLbl.Location = New System.Drawing.Point(287, 137)
        Me.MaterialsToAddLbl.Name = "MaterialsToAddLbl"
        Me.MaterialsToAddLbl.Size = New System.Drawing.Size(805, 33)
        Me.MaterialsToAddLbl.TabIndex = 6
        Me.MaterialsToAddLbl.Text = "Materials To Add"
        Me.MaterialsToAddLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CloseCmdBtn
        '
        Me.CloseCmdBtn.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CloseCmdBtn.Location = New System.Drawing.Point(513, 431)
        Me.CloseCmdBtn.Name = "CloseCmdBtn"
        Me.CloseCmdBtn.Size = New System.Drawing.Size(114, 32)
        Me.CloseCmdBtn.TabIndex = 14
        Me.CloseCmdBtn.Text = "Close"
        Me.CloseCmdBtn.UseVisualStyleBackColor = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1140, 488)
        Me.Controls.Add(Me.CloseCmdBtn)
        Me.Controls.Add(Me.MaterialsToAddLbl)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ImportMaterialsCmdBtn)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.LoadMaterialsCmdBtn)
        Me.Controls.Add(Me.GetRecipeCmdBtn)
        Me.Controls.Add(Me.GetMaterialsCmdBtn)
        Me.Name = "Main"
        Me.Text = "Main"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GetMaterialsCmdBtn As System.Windows.Forms.Button
    Friend WithEvents GetRecipeCmdBtn As System.Windows.Forms.Button
    Friend WithEvents LoadMaterialsCmdBtn As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ImportMaterialsCmdBtn As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MaterialsToAddLbl As System.Windows.Forms.Label
    Friend WithEvents CloseCmdBtn As System.Windows.Forms.Button

End Class
