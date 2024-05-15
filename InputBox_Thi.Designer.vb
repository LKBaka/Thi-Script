<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InputBox_Thi
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InputBox_Thi))
        Me.Text__ = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.OKBtn = New System.Windows.Forms.Button()
        Me.CancelBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Text__
        '
        Me.Text__.Font = New System.Drawing.Font("黑体", 16.0!)
        Me.Text__.Location = New System.Drawing.Point(38, 31)
        Me.Text__.Name = "Text__"
        Me.Text__.Size = New System.Drawing.Size(541, 197)
        Me.Text__.TabIndex = 0
        Me.Text__.Text = "内容"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(43, 254)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(666, 30)
        Me.TextBox1.TabIndex = 1
        '
        'OKBtn
        '
        Me.OKBtn.Font = New System.Drawing.Font("黑体", 10.0!)
        Me.OKBtn.Location = New System.Drawing.Point(600, 31)
        Me.OKBtn.Name = "OKBtn"
        Me.OKBtn.Size = New System.Drawing.Size(109, 40)
        Me.OKBtn.TabIndex = 2
        Me.OKBtn.Text = "确定"
        Me.OKBtn.UseVisualStyleBackColor = True
        '
        'CancelBtn
        '
        Me.CancelBtn.Font = New System.Drawing.Font("黑体", 10.0!)
        Me.CancelBtn.Location = New System.Drawing.Point(600, 77)
        Me.CancelBtn.Name = "CancelBtn"
        Me.CancelBtn.Size = New System.Drawing.Size(109, 40)
        Me.CancelBtn.TabIndex = 3
        Me.CancelBtn.Text = "取消"
        Me.CancelBtn.UseVisualStyleBackColor = True
        '
        'InputBox_Thi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(721, 307)
        Me.Controls.Add(Me.CancelBtn)
        Me.Controls.Add(Me.OKBtn)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Text__)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "InputBox_Thi"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Text__ As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents OKBtn As System.Windows.Forms.Button
    Friend WithEvents CancelBtn As System.Windows.Forms.Button
End Class
