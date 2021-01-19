<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ImportfromCSV
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
        Me.btnImport = New System.Windows.Forms.Button()
        Me.txtFilename = New System.Windows.Forms.TextBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.txtDBTable = New System.Windows.Forms.TextBox()
        Me.lblDBTable = New System.Windows.Forms.Label()
        Me.dgvData = New System.Windows.Forms.DataGridView()
        Me.btnBulkLoader = New System.Windows.Forms.Button()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnImport
        '
        Me.btnImport.Location = New System.Drawing.Point(244, 125)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(111, 23)
        Me.btnImport.TabIndex = 0
        Me.btnImport.Text = "Import Into Array"
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'txtFilename
        '
        Me.txtFilename.Location = New System.Drawing.Point(152, 43)
        Me.txtFilename.Name = "txtFilename"
        Me.txtFilename.Size = New System.Drawing.Size(887, 20)
        Me.txtFilename.TabIndex = 1
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(56, 41)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowse.TabIndex = 2
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'txtDBTable
        '
        Me.txtDBTable.Location = New System.Drawing.Point(152, 69)
        Me.txtDBTable.Name = "txtDBTable"
        Me.txtDBTable.Size = New System.Drawing.Size(203, 20)
        Me.txtDBTable.TabIndex = 3
        '
        'lblDBTable
        '
        Me.lblDBTable.AutoSize = True
        Me.lblDBTable.Location = New System.Drawing.Point(53, 72)
        Me.lblDBTable.Name = "lblDBTable"
        Me.lblDBTable.Size = New System.Drawing.Size(76, 13)
        Me.lblDBTable.TabIndex = 4
        Me.lblDBTable.Text = "Into DB Table:"
        '
        'dgvData
        '
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.Location = New System.Drawing.Point(10, 291)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.Size = New System.Drawing.Size(1029, 251)
        Me.dgvData.TabIndex = 5
        '
        'btnBulkLoader
        '
        Me.btnBulkLoader.Location = New System.Drawing.Point(481, 125)
        Me.btnBulkLoader.Name = "btnBulkLoader"
        Me.btnBulkLoader.Size = New System.Drawing.Size(149, 23)
        Me.btnBulkLoader.TabIndex = 6
        Me.btnBulkLoader.Text = "Import Using Bulk Loader"
        Me.btnBulkLoader.UseVisualStyleBackColor = True
        '
        'ImportfromCSV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1060, 580)
        Me.Controls.Add(Me.btnBulkLoader)
        Me.Controls.Add(Me.dgvData)
        Me.Controls.Add(Me.lblDBTable)
        Me.Controls.Add(Me.txtDBTable)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.txtFilename)
        Me.Controls.Add(Me.btnImport)
        Me.Name = "ImportfromCSV"
        Me.Text = "ImportfromCSV"
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnImport As Button
    Friend WithEvents txtFilename As TextBox
    Friend WithEvents btnBrowse As Button
    Friend WithEvents txtDBTable As TextBox
    Friend WithEvents lblDBTable As Label
    Friend WithEvents dgvData As DataGridView
    Friend WithEvents btnBulkLoader As Button
End Class
