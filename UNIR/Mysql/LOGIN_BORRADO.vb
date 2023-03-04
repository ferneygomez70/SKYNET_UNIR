Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration
Imports System.Net
Public Class LOGIN_BORRADO
    Dim cadena As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
    Dim varconex, conexion As New MySqlConnection(cadena)
    Public verdata, verSdata, comArtdata, codata, solidata, endata, sadata, candata, datos, datositem As New DataSet
    Public sql, cmd, command As New MySqlCommand
    Dim fila As Integer
    Private Sub Form5_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.F10 Then
            VENTAS.Label16.Text = Label20.Text
            VENTAS.Label1.Text = Label19.Text
            VENTAS.Label22.Text = Label16.Text
            VENTAS.Label9.Text = Label3.Text
            VENTAS.Label12.Text = Label13.Text
            VENTAS.TextBox1.Enabled = True
            VENTAS.DataGridView1.Enabled = True
            VENTAS.BtnIngresar.Enabled = True
            VENTAS.Button3.Enabled = True
            VENTAS.TraeConfiguracion()



            Me.Close()
            VENTAS.DataGridView1.Refresh()
            VENTAS.Show()
        End If
    End Sub

    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If VariablesGoblales.LoginBorrado = False Then
            GroupBox1.Visible = False

        End If

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox1.Focus()
        Dim producto As String = "SELECT ventas.id_venta, articulos.nomb_product,medida.medida,ventas.peso,ventas.cant,ventas.valor_unitario,ventas.precio,ventas.activo FROM ventas INNER JOIN usuarios ON (ventas.id_usuarios = usuarios.id_usuarios) INNER JOIN pos ON (ventas.id_caja = pos.id_caja) INNER JOIN articulos ON (ventas.id_product = articulos.id_product) INNER JOIN medida ON (articulos.id_medida = medida.id_medida) WHERE  ventas.id_venta =" & Me.Label1.Text & ""
        If varconex.State = ConnectionState.Closed Then varconex.Open()
        Dim da2 As New MySqlDataAdapter(producto, varconex)


        Dim nombre As String
        Dim peso As Double
        Dim medida As String
        Dim cant As Integer
        Dim unitario As Integer
        Dim precio As Integer
        Dim activo As Integer

        nombre = ""

        medida = ""



        sql.CommandText = producto
        sql.Connection = varconex
        da2.SelectCommand = sql
        codata.Clear()
        da2.Fill(codata)
        If codata.Tables(0).Rows.Count > 0 Then

            nombre = codata.Tables(0).Rows(0).Item("nomb_product")
            medida = codata.Tables(0).Rows(0).Item("medida")
            peso = codata.Tables(0).Rows(0).Item("peso")
            cant = codata.Tables(0).Rows(0).Item("cant")
            unitario = codata.Tables(0).Rows(0).Item("valor_unitario")
            precio = codata.Tables(0).Rows(0).Item("precio")
            activo = codata.Tables(0).Rows(0).Item("activo")
        End If
        Me.Label4.Text = nombre
        Me.Label5.Text = medida
        Me.Label6.Text = peso
        Me.Label7.Text = cant
        Me.Label8.Text = unitario
        Me.Label9.Text = precio
        Me.Label14.Text = activo



    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim cadena3 As String = "select usuarios.id_usuarios,tipo_usuario.id_tipouser from usuarios INNER JOIN tipo_usuario ON (usuarios.id_tipouser = tipo_usuario.id_tipouser) where  usuarios.id_usuarios = " & Me.Label3.Text & ""
        ' If varconex.State = ConnectionState.Closed Then varconex.Open()
        Dim da1 As New MySqlDataAdapter(cadena3, varconex)
        da1.Fill(datos)
        'Mysqlconnection.Close()
        With datos.Tables(0).Rows(fila)
            Try
                Me.Label2.Text = .Item("id_tipouser")
                varconex.Close()

            Catch
            End Try
        End With
        If Label2.Text <> 1 & 3 Then
            MsgBox("No tiene permisos", vbExclamation, "Atención      SKYNET")
            LOGIN_CIERRE.Label4.Text = Label1.Text

            LOGIN_CIERRE.ShowDialog()
        Else
            LOGIN_CIERRE.Label4.Text = Label1.Text
            LOGIN_CIERRE.ShowDialog()

        End If


    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        VENTAS.Label1.Text = Label19.Text
        VENTAS.Label16.Text = Label20.Text
        VENTAS.Label22.Text = Label16.Text
        VENTAS.Label9.Text = Label3.Text
        VENTAS.Label12.Text = Label13.Text
        VENTAS.TextBox1.Focus()
        VENTAS.TextBox1.Enabled = True
        VENTAS.DataGridView1.Enabled = True
        VENTAS.BtnIngresar.Enabled = True
        VENTAS.Button3.Enabled = True
        VENTAS.TraeConfiguracion()



        Me.Close()
        VENTAS.DataGridView1.Refresh()
        VENTAS.Show()

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'SISTEMA DE AUTENTICACION DE  BORRADO
        If VariablesGoblales.LoginBorrado = True Then
            Call validaruser()
        Else
            Call borrar()
        End If
        Call VENTAS.total()

        VENTAS.Label1.Text = Label19.Text
        VENTAS.Label16.Text = Label20.Text
        VENTAS.Label22.Text = Label16.Text
        VENTAS.Label9.Text = Label3.Text
        VENTAS.Label12.Text = Label13.Text
        VENTAS.TextBox1.Focus()
        VENTAS.TextBox1.Enabled = True
        VENTAS.DataGridView1.Enabled = True
        VENTAS.BtnIngresar.Enabled = True
        VENTAS.Button3.Enabled = True
        VENTAS.TraeConfiguracion()



        Me.Close()
        VENTAS.DataGridView1.Refresh()
        VENTAS.Show()

    End Sub
    Private Sub validaruser()
        conexion.Close()
        Dim myadapter As New MySqlDataAdapter
        Dim sqlquery As String = "SELECT * FROM usuarios  WHERE user='" & TextBox1.Text & "' AND clave='" & TextBox2.Text & "' and id_tipouser in (1,3)"
        'Dim command As New MySqlCommand
        command.Connection = conexion
        command.CommandText = sqlquery
        myadapter.SelectCommand = command
        Dim mydata As MySqlDataReader

        conexion.Open()
        mydata = command.ExecuteReader()
        mydata.Read()

        If mydata.HasRows = 0 Then
            MsgBox("USUARIO INVALIDO, El artículo  no se borrará")
            conexion.Close()

        Else

            Call borrar()
            varconex.Close()

        End If



    End Sub
    Public Sub borrar()
        'delete  producto venta
        Dim Query As String
        Try

            Query = "update ventas set activo= 0 where id_venta=" & Me.Label1.Text & " ;update ventas set id_fact= 0 where id_venta=" & Me.Label1.Text & "; update ventas set id_usuarios= 0 where id_venta=" & Me.Label1.Text & "; update ventas set id_caja= 0 where id_venta=" & Me.Label1.Text & "; update ventas set id_product= 0 where id_venta=" & Me.Label1.Text & "; update ventas set peso= 0 where id_venta=" & Me.Label1.Text & "; update ventas set cant= 0 where id_venta=" & Me.Label1.Text & "; update ventas set valor_unitario= 0 where id_venta=" & Me.Label1.Text & "; update ventas set precio= 0 where id_venta=" & Me.Label1.Text & "; update ventas set valor_iva= 0 where id_venta=" & Me.Label1.Text & "; update ventas set id_venta= 0 where id_venta=" & Me.Label1.Text & " "

            Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
            cmd2.ExecuteNonQuery()

            VENTAS.TextBox1.Focus()
            VENTAS.Label16.Text = Label20.Text
            VENTAS.Label1.Text = Label19.Text
            VENTAS.Label22.Text = Label16.Text
            VENTAS.Label9.Text = Label3.Text
            VENTAS.Label12.Text = Label13.Text
            VENTAS.DataGridView1.Enabled = True

            VENTAS.TextBox1.Enabled = True

            VENTAS.BtnIngresar.Enabled = True
            VENTAS.Button3.Enabled = True

            VENTAS.TraeConfiguracion()



            Me.Close()


            VENTAS.Show()

            varconex.Close()


        Catch ex As Exception





        End Try

    End Sub

    Private Sub Label20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label20.Click

    End Sub

    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label12.Click

    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

    End Sub

    Private Sub Label22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label22.Click

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox2_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub
End Class