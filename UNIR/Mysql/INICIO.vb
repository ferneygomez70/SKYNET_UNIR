Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration
Imports System.Net
Public Class INICIO
    Dim cadena As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
    Dim Mysqlconnection, varconex, conexion2 As New MySqlConnection(cadena)
    Dim datos, datos2, codata, codata3, datos4 As New DataSet
    Public sql, cmd, command, sql2 As New MySqlCommand

    Private Sub Label11_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtUserName_TextChanged(sender As Object, e As EventArgs) Handles txtUserName.TextChanged

    End Sub

    Dim fila As Integer
    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' los datos de la ip del equipo 
        Dim nombreHost As String = System.Net.Dns.GetHostName
        Dim hostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(nombreHost)
        For Each ip As System.Net.IPAddress In hostInfo.AddressList
            Label4.Text = ip.ToString
        Next

        Dim NoCaja As String = "select id_caja,nomb_caja from pos where ip_caja ='" & Me.Label4.Text & "'"
        If varconex.State = ConnectionState.Closed Then varconex.Open()
        Dim da2 As New MySqlDataAdapter(NoCaja, varconex)

        Dim nomb_caja As String
        Dim id_caja As String

        nomb_caja = ""
        id_caja = ""

        sql.CommandText = NoCaja
        sql.Connection = varconex
        da2.SelectCommand = sql
        codata.Clear()
        da2.Fill(codata)
        ' se busca si hay una ip si la ha asigna el nombre  y el ide de la caja 
        If codata.Tables(0).Rows.Count > 0 Then
            nomb_caja = codata.Tables(0).Rows(0).Item("nomb_caja")
            id_caja = codata.Tables(0).Rows(0).Item("id_caja")
            VariablesGoblales.Soporte = 1
        Else
            ' sino asigna variable soporte o y da nombre cajero
            VariablesGoblales.Soporte = 0
            nomb_caja = "CAJA 1"
            id_caja = 7
        End If
        Me.Label5.Text = nomb_caja
        VENTAS.Label16.Text = nomb_caja
        VENTAS2.Label16.Text = nomb_caja
        Dim pos As String = "select id_entracaja,usuarios.nombre,usuarios.id_usuarios,pos.id_caja, entrada_caja.activo from entrada_caja INNER JOIN pos ON (entrada_caja.id_caja = pos.id_caja) INNER JOIN usuarios ON (entrada_caja.id_usuarios = usuarios.id_usuarios) where pos.ip_caja ='" & Me.Label4.Text & "' and entrada_caja.activo=1"
        If varconex.State = ConnectionState.Closed Then varconex.Open()
        Dim da3 As New MySqlDataAdapter(pos, varconex)

        Dim activo As Integer


        sql2.CommandText = pos
        sql2.Connection = varconex
        da3.SelectCommand = sql2
        codata3.Clear()
        da3.Fill(codata3)
        If codata3.Tables(0).Rows.Count > 0 Then
            activo = codata3.Tables(0).Rows(0).Item("id_entracaja")
            Label7.Text = codata3.Tables(0).Rows(0).Item("id_usuarios")
            Label8.Text = codata3.Tables(0).Rows(0).Item("nombre")
            Label9.Text = codata3.Tables(0).Rows(0).Item("activo")
        End If
        Me.Label6.Text = activo
        ''

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Try
            Mysqlconnection.Close()
            Mysqlconnection.Open()

        Catch myerror As MySqlException
            MessageBox.Show("error de conexion con base de datos" & myerror.Message)
        End Try
        Dim myadapter As New MySqlDataAdapter
        Dim sqlquery As String = "SELECT * FROM usuarios WHERE user='" & txtUserName.Text & "' AND clave='" & txtPassword.Text & "';"
        command.Connection = Mysqlconnection
        command.CommandText = sqlquery
        myadapter.SelectCommand = command
        Dim mydata As MySqlDataReader
        mydata = command.ExecuteReader()
        mydata.Read()
        'tipo usuario 4 es programador para parametrizar fucnionalidades
        If mydata("id_tipouser") = 4 Then
            Mysqlconnection.Close()
            Parametrizar.Show()
            Me.Visible = False
        Else

            If mydata.HasRows = 0 Then
                MsgBox("Datos Incorrectos, vuelva a intentarlo, con un usuario valido", vbExclamation, "Atención               SKYNET")
                Mysqlconnection.Close()
            Else
                Dim valor As String
                Dim activo As Integer

                If Label9.Text = "" Then
                    Label9.Text = 0
                End If


                If Me.Label6.Text = 0 Then

                    activo = Me.Label6.Text
                    valor = Me.txtUserName.Text
                    efectivo.NumericUpDown1.Focus()
                    efectivo.Label10.Text = activo
                    efectivo.Label13.Text = Label7.Text
                    efectivo.Label14.Text = Label8.Text
                    efectivo.Label3.Text = valor
                    efectivo.Label15.Text = Label9.Text
                    Me.Visible = False
                    efectivo.ShowDialog()
                    'INICIO2.txtUserName.Text = Me.txtUserName.Text
                    'INICIO2.txtPassword.Text = Me.txtPassword.Text


                Else
                    activo = Me.Label6.Text
                    valor = Me.txtUserName.Text
                    efectivo.Label3.Text = valor
                    efectivo.Label10.Text = activo
                    efectivo.Label13.Text = Label9.Text
                    efectivo.NumericUpDown1.Enabled = False
                    efectivo.Label13.Text = Label7.Text
                    efectivo.Label14.Text = Label8.Text
                    efectivo.Label15.Text = Label9.Text
                    Me.Visible = False
                    efectivo.ShowDialog()
                    'INICIO2.txtUserName.Text = Me.txtUserName.Text
                    'INICIO2.txtPassword.Text = Me.txtPassword.Text


                End If


                Mysqlconnection.Close()
                Parametrizar.ObtenerParametros()
            End If
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        End

    End Sub



    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

    End Sub

    Private Sub Label49_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

    End Sub
End Class