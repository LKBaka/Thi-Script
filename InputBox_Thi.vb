Public Class InputBox_Thi
    Public retstr As String = ""
    Public Property text_ As String
    Public Property title As String
    Public Property style As String
    Private Sub Text_Click(sender As Object, e As EventArgs) Handles Text__.Click

    End Sub

    Private Sub CancelBtn_Click(sender As Object, e As EventArgs) Handles CancelBtn.Click
        Invoke(Sub()
                   retstr = ""
                   Close()
               End Sub)
    End Sub

    Private Sub OKBtn_Click(sender As Object, e As EventArgs) Handles OKBtn.Click
        Invoke(Sub()
                   retstr = TextBox1.Text
                   Close()
               End Sub)
    End Sub

    Private Sub InputBox_Thi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Invoke(Sub()
                   Text__.Text = text_
                   Me.Text = title
                   If style = "Flat" Then
                       OKBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
                       CancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
                       TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
                   Else

                       OKBtn.FlatStyle = System.Windows.Forms.FlatStyle.Standard
                       CancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Standard
                       TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
                   End If
               End Sub)
    End Sub
End Class