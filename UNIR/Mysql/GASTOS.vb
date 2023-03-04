Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration
Imports System.Diagnostics
Imports System.IO


Public Class GASTOS
    Dim cadena As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
    Dim conexion, varconex As New MySqlConnection(cadena)
    Dim RawPrinterHelper As Object
    Dim strCurrency As String = ""
    Dim acceptableKey As Boolean = False
    Dim detalle As String
    Dim efectivo As String
    Dim fecha As String
    Private _titulo As Object
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        detalle = TextBox2.Text
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs)
        Call insertar()
    End Sub
    'Public Function Puntos(ByVal strValor As String, Optional ByVal intNumDecimales As Integer = 0) As String

    'Dim strAux As String
    'Dim strComas As String
    'Dim strPuntos As String
    'Dim intX As Integer
    'Dim bolMenos As Boolean = False
    '
    '   strComas = ""
    '  strValor = strValor.Replace(".", "")
    'If InStr(strValor, ",") > 0 Then
    '       strAux = Mid(strValor, 1, InStr(strValor, ",") - 1)
    '      strComas = Mid(strValor, InStr(strValor, ","))
    'Else
    '       strAux = strValor
    'End If
    '
    'If Mid(strAux, 1, 1) = "-" Then
    '      bolMenos = True
    '     strAux = Mid(strAux, 2)
    'End If
    '
    '   strPuntos = strAux
    '  strAux = ""
    'While strPuntos.Length > 3
    '       strAux = "." & Mid(strPuntos, strPuntos.Length - 2, 3) & strAux
    '      strPuntos = Mid(strPuntos, 1, strPuntos.Length - 3)
    ''End While
    'If intNumDecimales <> 0 Then
    'If strComas = "" Then strComas = ","
    'For intX = Len(strComas) - 1 To intNumDecimales - 1
    '           strComas = strComas & "0"
    'Next

    'End If
    '   strAux = strPuntos & strAux & strComas
    'If Mid(strAux, 1, 1) = "." Then strAux = Mid(strAux, 2)
    'If bolMenos Then strAux = "-" & strAux

    'Return strAux
    'End Function
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

    End Sub
    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked
        Close()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        '   TextBox1.Text = Puntos(TextBox1.Text)
        '  TextBox1.Select(TextBox1.Text.Length, 0)
        efectivo = TextBox1.Text
    End Sub

    Private Sub GASTOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        Dim fechaactual As String = Date.Now.ToString("yyyy/MM/dd")

        Label5.Text = fechaactual
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs)


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Query As String

        Try
            If varconex.State = ConnectionState.Open Then varconex.Close()
            Query = "Insert Into gastos (fecha_gasto, detalle_gasto, gasto) Value ('" & Label5.Text & "',' " & detalle & "','" & efectivo & "')"
            varconex.Open()
            Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
            cmd2.ExecuteNonQuery()
            varconex.Close()


            Close()
        Catch ex As Exception
            'MsgBox(Query)
            MsgBox(ex.Message)

        End Try
        facturas.Close()

    End Sub
    Private Sub insertar()







    End Sub






End Class