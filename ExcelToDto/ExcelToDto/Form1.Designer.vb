<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.dgvList = New System.Windows.Forms.DataGridView()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.txtExcelPath = New System.Windows.Forms.TextBox()
        Me.txtOutputFolder = New System.Windows.Forms.TextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(874, 13)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(180, 40)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(874, 69)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(180, 40)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'dgvList
        '
        Me.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvList.Location = New System.Drawing.Point(19, 120)
        Me.dgvList.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvList.Name = "dgvList"
        Me.dgvList.RowHeadersWidth = 20
        Me.dgvList.RowTemplate.Height = 21
        Me.dgvList.Size = New System.Drawing.Size(803, 633)
        Me.dgvList.TabIndex = 2
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(19, 21)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(80, 28)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "選択"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'txtExcelPath
        '
        Me.txtExcelPath.Location = New System.Drawing.Point(107, 21)
        Me.txtExcelPath.Margin = New System.Windows.Forms.Padding(4)
        Me.txtExcelPath.Name = "txtExcelPath"
        Me.txtExcelPath.ReadOnly = True
        Me.txtExcelPath.Size = New System.Drawing.Size(715, 28)
        Me.txtExcelPath.TabIndex = 4
        Me.txtExcelPath.Text = "D:\TEST\029\EXCEL2DTO\新出講システム_テーブル定義_(随時更新中).xlsx"
        '
        'txtOutputFolder
        '
        Me.txtOutputFolder.Location = New System.Drawing.Point(107, 57)
        Me.txtOutputFolder.Margin = New System.Windows.Forms.Padding(4)
        Me.txtOutputFolder.Name = "txtOutputFolder"
        Me.txtOutputFolder.Size = New System.Drawing.Size(715, 28)
        Me.txtOutputFolder.TabIndex = 6
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(19, 57)
        Me.Button4.Margin = New System.Windows.Forms.Padding(4)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(80, 28)
        Me.Button4.TabIndex = 5
        Me.Button4.Text = "選択"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1074, 775)
        Me.Controls.Add(Me.txtOutputFolder)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.txtExcelPath)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.dgvList)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Font = New System.Drawing.Font("游ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents dgvList As DataGridView
    Friend WithEvents Button3 As Button
    Friend WithEvents txtExcelPath As TextBox
    Friend WithEvents txtOutputFolder As TextBox
    Friend WithEvents Button4 As Button
End Class
