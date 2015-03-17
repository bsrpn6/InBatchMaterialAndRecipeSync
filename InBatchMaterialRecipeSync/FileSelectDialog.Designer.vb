<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FileSelectDialog
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ImportFileTxtBox = New System.Windows.Forms.TextBox()
        Me.FileCompareTxtBox = New System.Windows.Forms.TextBox()
        Me.ImportFileCmdBtn = New System.Windows.Forms.Button()
        Me.FileCompareCmdBtn = New System.Windows.Forms.Button()
        Me.CloseCmdBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(104, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(454, 37)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Select Files For Comparison"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 19)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "File For Import"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(379, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(133, 19)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "File To Compare"
        '
        'ImportFileTxtBox
        '
        Me.ImportFileTxtBox.BackColor = System.Drawing.Color.White
        Me.ImportFileTxtBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImportFileTxtBox.Location = New System.Drawing.Point(12, 82)
        Me.ImportFileTxtBox.Name = "ImportFileTxtBox"
        Me.ImportFileTxtBox.ReadOnly = True
        Me.ImportFileTxtBox.Size = New System.Drawing.Size(237, 26)
        Me.ImportFileTxtBox.TabIndex = 9
        '
        'FileCompareTxtBox
        '
        Me.FileCompareTxtBox.BackColor = System.Drawing.Color.White
        Me.FileCompareTxtBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FileCompareTxtBox.Location = New System.Drawing.Point(383, 82)
        Me.FileCompareTxtBox.Name = "FileCompareTxtBox"
        Me.FileCompareTxtBox.ReadOnly = True
        Me.FileCompareTxtBox.Size = New System.Drawing.Size(237, 26)
        Me.FileCompareTxtBox.TabIndex = 10
        '
        'ImportFileCmdBtn
        '
        Me.ImportFileCmdBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImportFileCmdBtn.Location = New System.Drawing.Point(256, 82)
        Me.ImportFileCmdBtn.Name = "ImportFileCmdBtn"
        Me.ImportFileCmdBtn.Size = New System.Drawing.Size(42, 26)
        Me.ImportFileCmdBtn.TabIndex = 11
        Me.ImportFileCmdBtn.Text = "..."
        Me.ImportFileCmdBtn.UseVisualStyleBackColor = True
        '
        'FileCompareCmdBtn
        '
        Me.FileCompareCmdBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FileCompareCmdBtn.Location = New System.Drawing.Point(626, 82)
        Me.FileCompareCmdBtn.Name = "FileCompareCmdBtn"
        Me.FileCompareCmdBtn.Size = New System.Drawing.Size(42, 26)
        Me.FileCompareCmdBtn.TabIndex = 12
        Me.FileCompareCmdBtn.Text = "..."
        Me.FileCompareCmdBtn.UseVisualStyleBackColor = True
        '
        'CloseCmdBtn
        '
        Me.CloseCmdBtn.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CloseCmdBtn.Location = New System.Drawing.Point(281, 139)
        Me.CloseCmdBtn.Name = "CloseCmdBtn"
        Me.CloseCmdBtn.Size = New System.Drawing.Size(114, 32)
        Me.CloseCmdBtn.TabIndex = 13
        Me.CloseCmdBtn.Text = "Close"
        Me.CloseCmdBtn.UseVisualStyleBackColor = True
        '
        'FileSelectDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(677, 198)
        Me.Controls.Add(Me.CloseCmdBtn)
        Me.Controls.Add(Me.FileCompareCmdBtn)
        Me.Controls.Add(Me.ImportFileCmdBtn)
        Me.Controls.Add(Me.FileCompareTxtBox)
        Me.Controls.Add(Me.ImportFileTxtBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FileSelectDialog"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Select Files"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ImportFileTxtBox As System.Windows.Forms.TextBox
    Friend WithEvents FileCompareTxtBox As System.Windows.Forms.TextBox
    Friend WithEvents ImportFileCmdBtn As System.Windows.Forms.Button
    Friend WithEvents FileCompareCmdBtn As System.Windows.Forms.Button
    Friend WithEvents CloseCmdBtn As System.Windows.Forms.Button
End Class
