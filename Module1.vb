Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Windows.Forms

Module Module1
    Public vars As New Dictionary(Of String, String)
    Public commands As New List(Of String) From {"say", "new", "clear", "inputbox", "waitkeydown", "exit"}
    Public InputBox_ As New InputBox_Thi()
    Function _to_int(str As String) As Integer
        Try
            Return CInt(str)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Return 0
        End Try
    End Function
    Sub Main(args As String())
        'Console.WriteLine(args(0))
        If args.Count = 0 Then '代表没有启动参数，即命令行模式
            Command_Thi()
        Else '代表传入了文件路径，即文件模式
            File_Thi(args(0))
        End If
    End Sub
    Sub Command_Thi()
        File_Thi("D:\soft\Thi-Script\bin\Debug\test.txt")
    End Sub

    Async Sub File_Thi(path As String)
        Dim codes As New List(Of String) From {}
        Using codeFile As New StreamReader(path)
            While Not codeFile.EndOfStream
                Dim line = codeFile.ReadLine()
                If String.IsNullOrEmpty(line) Then Continue While
                Try
                    codes.Add(line)
                Catch ex As Exception

                End Try
            End While
        End Using

        runcode(codes)


    End Sub
    Sub runcode(codes As List(Of String))
        For codeidx = 0 To codes.Count - 1
            Dim line_splited = codes(codeidx).Split(" ")
            Dim cmd As String
            Dim args As New List(Of String) From {}
            cmd = line_splited(0)
            args = {""}.ToList()

            If cmd.ToLower = "say" Then
                args.Add(line_splited(1))
                'Console.WriteLine($"debug:{args(1)(1)}")
                If args(1)(0) <> "f" Then
                    Console.WriteLine($"{args(1)}")
                Else
                    Dim strconut = Len(args(1)) - Len(cmd) + 1
                    ' 定义一个正则表达式来匹配被#包围的文本  
                    Dim regex As New Regex("#([^#]+)#")

                    ' 找到所有匹配项  
                    Dim matches As MatchCollection = regex.Matches(args(1))

                    ' 创建一个StringBuilder来构建替换后的字符串  
                    Dim strbuilder As New StringBuilder(args(1))

                    ' 上一个匹配项的结束位置  
                    Dim lastIndex As Integer = 0

                    ' 使用Regex.Matches找到所有匹配项  
                    For Each match As Match In regex.Matches(args(1))
                        ' 将上一个匹配项和当前匹配项之间的文本添加到StringBuilder中  
                        strbuilder.Append(args(1).Substring(lastIndex, match.Index - lastIndex))

                        ' 提取#中的文本  
                        Dim key As String = match.Groups(1).Value

                        ' 检查字典中是否有该键，并进行替换  
                        If vars.ContainsKey(key) Then
                            strbuilder.Append(vars(key))
                        Else
                            ' 如果字典中没有该键，可以原样保留或进行其他处理  
                            strbuilder.Append(match.Value) ' 这里我们保留原样，包括#  
                        End If

                        ' 更新上一个匹配项的结束位置  
                        lastIndex = match.Index + match.Length
                    Next
                    ' 添加最后一个匹配项后面的所有文本（如果有的话）  
                    If lastIndex < args(1).Length Then
                        strbuilder.Append(args(1).Substring(lastIndex))
                    End If

                    ' StringBuilder转换为字符串并输出结果  
                    Dim result As String = strbuilder.ToString()
                    result = result.Replace("#", "")
                    ' result = result.Replace("f", "")

                    If strconut > 0 AndAlso result.Length > strconut Then
                        result = result.Substring(strconut - 1)
                    End If

                    ' 移除结果字符串的第一个字符（如果需要）  
                    If result.Length > 0 Then
                        result = result.Substring(1)
                    End If

                    Console.WriteLine(result.Remove(0, 1))
                End If
            ElseIf cmd.ToLower = "exit" Then
                args.Add(line_splited(1))
                Return
            ElseIf cmd.ToLower = "clear" Then
                Console.Clear()
            ElseIf cmd.ToLower = "waitkeydown" Then
                Console.ReadLine()
            ElseIf cmd.ToLower = "inputbox" Then
                Dim args_tmp = line_splited(1).Split(",")
                For i = 0 To args_tmp.Count - 1 '获取除命令外所有参数
                    args.Add(args_tmp(i))
                Next

                'Console.WriteLine($"{args(1)},{args(2)}")
                InputBox_ = New InputBox_Thi
                With InputBox_
                    .text_ = args(1)
                    .title = args(2)
                    .style = args(3)
                End With
                Application.EnableVisualStyles()
                Application.Run(InputBox_)


            ElseIf cmd.ToLower = "new" Then

                For Each arg In line_splited(1).Split(",")
                    args.Add(arg)
                Next
                vars.Add(args(1), args(2))
            ElseIf vars.ContainsKey(cmd) Then
                For Each arg In line_splited.Skip(0)
                    args.Add(arg)
                Next

                'args(2)操作符，args(3)数值
                If args(2) = "+=" Then
                    Dim add_value = _to_int(args(3))
                    Dim old_value = _to_int(vars(args(1)))
                    If add_value <> 0 And old_value <> 0 Then vars(args(1)) = old_value + add_value
                ElseIf args(2) = "-=" Then

                    Dim minus_value = _to_int(args(3))
                    Dim old_value = _to_int(vars(args(1)))
                    If minus_value <> 0 And old_value <> 0 Then vars(args(1)) = old_value - minus_value
                ElseIf args(2) = "*=" Then

                    Dim multiply_value = _to_int(args(3))
                    Dim old_value = _to_int(vars(args(1)))
                    If multiply_value <> 0 And old_value <> 0 Then vars(args(1)) = old_value * multiply_value
                ElseIf args(2) = "/=" Then

                    Dim divide_value = _to_int(args(3))
                    Dim old_value = _to_int(vars(args(1)))
                    If divide_value <> 0 And old_value <> 0 Then vars(args(1)) = old_value / divide_value
                ElseIf args(2) = "=" Then
                    Dim value = args(3)
                    If value <> 0 Then vars(args(1)) = value.ToString
                End If
            ElseIf codes(codeidx).Substring(0, 2) = "//" Then
                Continue For
            Else
                Console.WriteLine($"命令或变量不存在:[{codes(codeidx)}]")
            End If
        Next
    End Sub
End Module
