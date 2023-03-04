Public Class CAMBIO



    Private Sub mostrarcambio()
        Dim A As String
        Dim B As String
        Dim C As String
        Try


            'A = COBRAR.Label2.Text
            'B = COBRAR.TextBox1.Text
            'C = COBRAR.Label7.Text

            'Me.Label2.Text = A
            'Me.Label3.Text = B
            'Me.Label5.Text = C
        Catch ex As Exception
            MsgBox(ex.Message + ex.StackTrace)



        End Try
    End Sub


    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Label2.Text = COBRAR.Label2.Text
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        VENTAS.Show()
        Me.Hide()


        'mostrarcambio()


    End Sub
    Public Function Puntos(ByVal strValor As String, Optional ByVal intNumDecimales As Integer = 0) As String

        Dim strAux As String
        Dim strComas As String
        Dim strPuntos As String
        Dim intX As Integer
        Dim bolMenos As Boolean = False

        strComas = ""
        strValor = strValor.Replace(".", "")
        If InStr(strValor, ",") > 0 Then
            strAux = Mid(strValor, 1, InStr(strValor, ",") - 1)
            strComas = Mid(strValor, InStr(strValor, ","))
        Else
            strAux = strValor
        End If

        If Mid(strAux, 1, 1) = "-" Then
            bolMenos = True
            strAux = Mid(strAux, 2)
        End If

        strPuntos = strAux
        strAux = ""
        While strPuntos.Length > 3
            strAux = "." & Mid(strPuntos, strPuntos.Length - 2, 3) & strAux
            strPuntos = Mid(strPuntos, 1, strPuntos.Length - 3)
        End While
        If intNumDecimales <> 0 Then
            If strComas = "" Then strComas = ","
            For intX = Len(strComas) - 1 To intNumDecimales - 1
                strComas = strComas & "0"
            Next

        End If
        strAux = strPuntos & strAux & strComas
        If Mid(strAux, 1, 1) = "." Then strAux = Mid(strAux, 2)
        If bolMenos Then strAux = "-" & strAux

        Return strAux
    End Function

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Label2.Text = COBRAR.Label2.Text
    End Sub

    Private Sub CAMBIO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Text = Puntos(Label2.Text)
        Label3.Text = Puntos(Label3.Text)
        Label5.Text = Puntos(Label5.Text)
    End Sub
End Class