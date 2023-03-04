Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration
Public Class LOGIN_AZ
    Dim cadena As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
    Dim Mysqlconnection, varconex As New MySqlConnection(cadena)
    Dim datos, datos2, codata, codata3, datos4 As New DataSet
    Public sql, cmd, command, sql2 As New MySqlCommand
    Dim fila As Integer
    Const AppName = "Mysql"
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call validaruser()
    End Sub
    Private Sub validaruser()
        Try
            Mysqlconnection.Close()
            Mysqlconnection.Open()
            Dim myadapter As New MySqlDataAdapter
            Dim sqlquery As String = "SELECT * FROM usuarios  WHERE user='" & TextBox1.Text & "' AND clave='" & TextBox2.Text & "' and id_tipouser = 1 OR 3"
            'Dim command As New MySqlCommand
            command.Connection = Mysqlconnection
            command.CommandText = sqlquery
            myadapter.SelectCommand = command
            Dim mydata As MySqlDataReader
            mydata = command.ExecuteReader()
            mydata.Read()

            If mydata.HasRows = 0 Then
                MsgBox("USUARIO INVALIDO : " & TextBox1.Text & " – " & TextBox2.Text)
            Else
                'MsgBox("ya puede borrar")
                'Call borrar() 
                Close()
                IMPRIMIR_AZ.Label1.Text = Label3.Text
                IMPRIMIR_AZ.Label2.Text = Label4.Text
                IMPRIMIR_AZ.ShowDialog()

            End If
        Catch ex As Exception
            MsgBox("intentelo de nuevo.", MsgBoxStyle.Information, AppName)

            Me.Close()


            Mysqlconnection.Close()
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub Form15_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class