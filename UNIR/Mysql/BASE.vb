Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration
Imports System.Net

Public Class efectivo
    Dim cadena As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
    Dim varconex, conexion2 As New MySqlConnection(cadena)
    Dim datos, datos2, codata, codata3 As New DataSet 'los datos que estan en la base de datos son clases 
    Dim fila As Integer
    Public sql, cmd, sql2 As New MySqlCommand


    Private Sub efectivo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        varconex.Open()
        ' los datos de la ip del equipo 
        Dim nombreHost As String = System.Net.Dns.GetHostName
        Dim hostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(nombreHost)
        For Each ip As System.Net.IPAddress In hostInfo.AddressList
            Label7.Text = ip.ToString
        Next

        'Si El equipo tiene Ip Local para soporte
        If VariablesGoblales.Soporte = 0 Then
            Label7.Text = "sin ip" 'Caja Pos
        End If

        Dim NoCaja As String = "select id_caja,nomb_caja from pos where ip_caja ='" & Me.Label7.Text & "'"
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
        If codata.Tables(0).Rows.Count > 0 Then
            nomb_caja = codata.Tables(0).Rows(0).Item("nomb_caja")
            id_caja = codata.Tables(0).Rows(0).Item("id_caja")

        End If
        Me.Label8.Text = nomb_caja
        Me.Label9.Text = id_caja
        VENTAS.Label12.Text = id_caja
        VENTAS.Label16.Text = nomb_caja
        VENTAS2.Label12.Text = id_caja
        VENTAS2.Label16.Text = nomb_caja
        ''
        Dim cadena3 As String = "select id_usuarios,nombre from usuarios where user ='" & Me.Label3.Text & "'"
        If varconex.State = ConnectionState.Closed Then varconex.Open()
        Dim da1 As New MySqlDataAdapter(cadena3, varconex)
        da1.Fill(datos)
        'Mysqlconnection.Close()
        With datos.Tables(0).Rows(fila)
            Try
                Me.Label4.Text = .Item("nombre")
                VENTAS.Label1.Text = .Item("nombre")
                VENTAS2.Label1.Text = .Item("nombre")
                Me.Label6.Text = .Item("id_usuarios")

                VENTAS.Label9.Text = .Item("id_usuarios")
                VENTAS2.Label9.Text = .Item("id_usuarios")
                varconex.Close()
            Catch
            End Try
        End With

        Dim cmdfacth As New MySqlCommand("select facturas.id_fact, facturas.activo,facturas.venta_factura  FROM facturas INNER JOIN pos ON (facturas.id_caja = pos.id_caja) INNER JOIN usuarios ON (facturas.id_usuarios = usuarios.id_usuarios)  WHERE  usuarios.id_usuarios=" & Me.Label6.Text & " AND pos.id_caja= " & Me.Label9.Text & " and facturas.activo=1 and facturas.venta_factura=1", conexion2)
        Dim lectura_facth As MySqlDataReader
        If Not conexion2 Is Nothing Then conexion2.Close()
        conexion2.Open()
        lectura_facth = cmdfacth.ExecuteReader
        If lectura_facth.Read() Then

            Me.Label11.Text = lectura_facth.Item("activo")
            Me.Label12.Text = lectura_facth.Item("id_fact")

        End If
        If Me.Label11.Text = " " Then
            Me.Label11.Text = 0

        End If

        If ((Label13.Text <> Label6.Text) And (Label15.Text = 1)) Then
            MsgBox(Me.Label14.Text, vbExclamation, "La Caja ya esta abierta por")
            End

        End If
        'ingreso de consulta de factura para la segunda venta
        Dim cmdfacth2 As New MySqlCommand("select facturas.id_fact, facturas.activo,facturas.venta_factura  FROM facturas INNER JOIN pos ON (facturas.id_caja = pos.id_caja) INNER JOIN usuarios ON (facturas.id_usuarios = usuarios.id_usuarios)  WHERE  usuarios.id_usuarios=" & Me.Label6.Text & " AND pos.id_caja= " & Me.Label9.Text & " and facturas.activo=1 and facturas.venta_factura=2", conexion2)
        Dim lectura_facth2 As MySqlDataReader
        If Not conexion2 Is Nothing Then conexion2.Close()
        conexion2.Open()
        lectura_facth2 = cmdfacth2.ExecuteReader
        If lectura_facth2.Read() Then

            Me.Label17.Text = lectura_facth2.Item("activo")
            Me.Label18.Text = lectura_facth2.Item("id_fact")

        End If
        If Me.Label17.Text = " " Then
            Me.Label17.Text = 0

        End If

        If ((Label13.Text <> Label6.Text) And (Label15.Text = 1)) Then
            MsgBox(Me.Label14.Text, vbExclamation, "La Caja ya esta abierta por")
            End

        End If








    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim fechaactual As String = Date.Now.ToString("yyyy/MM/dd HH:mm:ss")

        Dim Query As String

        If Label10.Text = 0 Then '
            Try
                varconex.Open()
                Query = "INSERT INTO entrada_caja (id_usuarios,id_caja,fecha_entrada,valor_entrada) VALUES ('" & Me.Label6.Text & "','" & Me.Label9.Text & "','" & fechaactual & "','" + Me.NumericUpDown1.Text + "')"

                Dim cmd As MySqlCommand = New MySqlCommand(Query, varconex)
                cmd.ExecuteNonQuery()
                varconex.Close()

            Catch ex As Exception
                MsgBox("fallo el insert", vbExclamation, "Atención      SKYNET")

            End Try

            VENTAS.Label30.Text = Me.Label11.Text
            VENTAS.Label22.Text = Me.Label12.Text
            VENTAS2.Label30.Text = Me.Label17.Text
            VENTAS2.Label22.Text = Me.Label18.Text
            Me.Visible = False

            VENTAS.Show()
            ' numero_defactura.Show()

        Else

            VENTAS.Label30.Text = Me.Label11.Text
            VENTAS.Label22.Text = Me.Label12.Text
            VENTAS2.Label30.Text = Me.Label17.Text
            VENTAS2.Label22.Text = Me.Label18.Text
            Me.Visible = False

            VENTAS.Show()

        End If


    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        End
    End Sub

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub




    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Function MessageBox(NoCaja As String) As Object
        Throw New NotImplementedException
    End Function

End Class