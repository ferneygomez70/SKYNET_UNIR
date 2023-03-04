Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration

Public Class LOGIN_CIERRE
    Dim cadena As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
    Dim Mysqlconnection, varconex As New MySqlConnection(cadena)
    Dim datos, datos2, codata, codata3, datos4 As New DataSet
    Public sql, cmd, command, sql2 As New MySqlCommand
    Dim fila As Integer
    Const AppName = "Mysql"
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call validaruser()
        'Call Form1.total()


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
                MsgBox("USUARIO INVALIDO, INTENTE DE NUEVO : ", vbExclamation, "Atención      SKYNET")
            Else
                'MsgBox("ya puede borrar")
                'Call borrar()
                CIERRE_CAJA.Label1.Text = Label3.Text
                CIERRE_CAJA.Label2.Text = Label4.Text
                CIERRE_CAJA.ShowDialog()

            End If
        Catch ex As Exception
            MsgBox("ERROR", vbExclamation, "Atención      SKYNET")

            Me.Close()


            Mysqlconnection.Close()
        End Try
    End Sub
    Public Sub borrar()
        'delete  producto venta
        Dim Query As String
        Try

            Query = "update ventas set activo= 0 where id_venta=" & Label4.Text & ""
            varconex.Open()
            Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
            cmd2.ExecuteNonQuery()


            Me.Close()
            'Form5.Close()
            varconex.Close()


        Catch ex As Exception
            'MsgBox(Query)
            MsgBox("ERROR", vbExclamation, "Atención      SKYNET")



        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Close()
        VENTAS.Enabled = True
    End Sub



    Private Sub Form6_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = ""
        TextBox2.Text = ""

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
End Class