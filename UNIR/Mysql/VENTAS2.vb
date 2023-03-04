Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration
Imports System.Drawing.Printing

Public Class VENTAS2
    Private ComBuffer As Byte()
    Private Delegate Sub UpdateFormDelegate()
    Private UpdateFormDelegate1 As UpdateFormDelegate
    Dim strReturn As String
    Dim strPeso As String
    Dim car As String
    Dim salir As Integer

    Dim cadena As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
    Dim varconex, conexion, conexion2, conexion3, conexionIns As New MySqlConnection(cadena)
    Public verdata, verSdata, comArtdata, codata, solidata, endata, sadata, candata, datostotal, datositem As New DataSet
    Dim fila As Integer
    Public sql, cmd As New MySqlCommand

    Private Sub cajon()


        Dim pd As New PrintDialog()
        Dim Impresora As New System.Drawing.Printing.PrinterSettings
        pd.PrinterSettings = New PrinterSettings()

        'If (pd.ShowDialog() = DialogResult.OK) Then
        WindowsApplication1.RawPrinterHelper.SendStringToPrinter(Impresora.PrinterName, Chr(27) & Chr(112) & Chr(0) & Chr(25) & Chr(250))
        'End If

    End Sub

    Private Property e As Object
    REM primer punto de interrupciòn
    Private Sub FormVenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F10 Then
            End
        End If
        If e.KeyCode = Keys.F3 Then
            puertoserial2.Close()
            Buscar.ShowDialog()
            puertoserial2.Open()
        End If
        If e.KeyCode = Keys.F2 Then
            puertoserial2.Close()
            puertoserial2.Open()
            Call factura()
            Call numfact()
            Button1.Enabled = True
            Button3.Enabled = True
            TextBox1.Enabled = True
            DataGridView1.Enabled = True
            TextBox1.Focus()
        End If


        If e.KeyCode = Keys.F1 Then
            If TextBox1.Enabled = False Then
                Dim intResponse As DialogResult

                intResponse = MessageBox.Show("favor inicie venta con F2", "Atención             SKYNET ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                If intResponse = DialogResult.OK Then

                    COBRAR2.Close()

                End If
            Else
                puertoserial2.Close()
                COBRAR2.Label14.Text = Label1.Text
                COBRAR2.Label15.Text = Label16.Text
                COBRAR2.Label3.Text = Label9.Text
                COBRAR2.Label4.Text = Label12.Text
                COBRAR2.Label2.Text = total_venta.Text
                COBRAR2.Label9.Text = Label22.Text
                COBRAR2.Label12.Text = Label38.Text

                Me.Close()
                COBRAR2.Show()
            End If


        End If

        If e.KeyCode = Keys.F4 Then
            If TextBox1.Enabled = False Then
                MsgBox("favor inicie venta con F2.", vbExclamation, "Atención      SKYNET")

            Else
                CANTIDADES2.Label2.Text = Label5.Text
                CANTIDADES2.ShowDialog()
            End If
        End If


        If e.KeyCode = Keys.F5 Then
            Reimprimir.Label2.Text = Label9.Text
            Reimprimir.ShowDialog()

        End If
        If e.KeyCode = Keys.F6 Then
            If TextBox1.Enabled = False Then
                MsgBox("favor inicie venta con F2.", vbExclamation, "Atención      SKYNET")

            Else
                SALDOS2.Label4.Text = TextBox2.Text
                SALDOS2.MaskedTextBox1.Focus()
                SALDOS2.ShowDialog()
            End If
        End If

        'If e.KeyCode = Keys.F7 Then
        '    LOGIN_AZ.Label3.Text = Label9.Text
        '    LOGIN_AZ.Label4.Text = Label12.Text
        '    LOGIN_AZ.TextBox1.Focus()
        '    LOGIN_AZ.ShowDialog()
        'End If

        'If e.KeyCode = Keys.F8 Then
        '    LOGIN_CIERRE.Label4.Text = Label12.Text
        '    LOGIN_CIERRE.Label3.Text = Label9.Text

        '    Me.Enabled = False
        '    LOGIN_CIERRE.ShowDialog()

        'End If
        If e.KeyCode = Keys.F11 Then


            cajon()

        End If
        If e.KeyCode = Keys.Escape Then
            Button2.PerformClick()


        End If

        If e.KeyCode = Keys.F12 Then
            If TextBox1.Enabled = False Then
                MsgBox("favor inicie venta con F2.", vbExclamation, "Atención      SKYNET")

            Else
                SALDOS.Label4.Text = TextBox2.Text
                SALDOS.MaskedTextBox1.Focus()
                DESCUENTO.ShowDialog()
            End If


        End If
    End Sub
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        puertoserial2.Close()
        puertoserial2.Open()

        Call factura()
        Call numfact()

        TextBox1.Enabled = True
        Button1.Enabled = True
        Button3.Enabled = True
        DataGridView1.Enabled = True


        TextBox1.Focus()
    End Sub
    Public Sub punto()







    End Sub
    Public Sub numfact()

        Dim cmdfact2 As New MySqlCommand("select facturas.id_fact, facturas.activo,facturas.venta_factura  FROM facturas INNER JOIN pos ON (facturas.id_caja = pos.id_caja) INNER JOIN usuarios ON (facturas.id_usuarios = usuarios.id_usuarios)  WHERE  usuarios.id_usuarios=" & Me.Label9.Text & " AND pos.id_caja= " & Me.Label12.Text & " AND facturas.activo = 1 AND facturas.venta_factura=2", conexion2)
        Dim lectura_fact As MySqlDataReader
        If Not conexion2 Is Nothing Then conexion2.Close()
        conexion2.Open()
        lectura_fact = cmdfact2.ExecuteReader
        If lectura_fact.Read() Then
            Me.Label22.Text = lectura_fact.Item("id_fact")
            Me.Label30.Text = lectura_fact.Item("activo")
            VariablesGoblales.NoFact2 = lectura_fact.Item("id_fact")
        End If
        'INGRESADO JULIO 2017
        conexion2.Close()
    End Sub
    Public Sub factura()

        If Label30.Text = 1 Then

        Else

            Dim fact As String
            fact = "insert into facturas (id_caja,id_usuarios,fecha_fact,facturas.venta_factura) value ('" & Me.Label12.Text & "','" & Me.Label9.Text & "','" & Me.Label4.Text & "',2)"
            varconex.Open()
            Dim cmdfact As MySqlCommand = New MySqlCommand(fact, varconex)
            cmdfact.ExecuteNonQuery()
            varconex.Close()
        End If
    End Sub
    Public Sub insertar(Saldo As Integer)
        Dim Query, Consulta As String
        If Saldo = 0 Then
            Dim NoFact As String = "select id_venta,id_fact,articulos.id_product,articulos.promocion,articulos.cant_prom,articulos.valor_prom,cant,peso,valor_unitario,precio,articulos.iva,valor_iva " &
                                   "from ventas inner join articulos on ventas.id_product=articulos.id_product " &
                                   "where id_fact ='" & Me.Label22.Text & "' and ventas.id_product='" & Me.Label6.Text & "' and ventas.activo=1"
            Dim ProdProm As String = "select id_product,promocion,cant_prom,valor_prom from articulos where id_product='" & Me.Label6.Text & "'"
            If varconex.State = ConnectionState.Closed Then varconex.Open()
            Dim Adapter1 As New MySqlDataAdapter(ProdProm, varconex)
            Dim dts As New DataSet
            Adapter1.Fill(dts)
            varconex.Close()
            Dim IdVenta, IdProd, totalcant, peso, valorU, precio, totalPrecio, promocion, cantProm, valorProm, iva, valorIva As Integer
            Dim cant As Double
            If varconex.State = ConnectionState.Closed Then varconex.Open()
            Dim Adapter As New MySqlDataAdapter(NoFact, varconex)
            Dim ds As New DataSet
            Try
                Adapter.Fill(ds)
                varconex.Close()
                If ds.Tables(0).Rows.Count = 0 Then
                    For Each row As DataRow In dts.Tables(0).Rows
                        IdProd = row("Id_Product")
                        promocion = row("promocion")
                        cantProm = row("cant_prom")
                        valorProm = row("valor_prom")
                    Next row
                    If Label13.Text <> "GR" Then
                        Query = "insert into ventas (id_fact,id_usuarios,id_caja,id_product,cant,valor_unitario,precio,valor_iva) value ('" & Me.Label22.Text & "','" & Me.Label9.Text & "','" & Me.Label12.Text & "','" & Me.Label6.Text & "','" & Me.TextBox2.Text & "'"
                        If promocion = 0 And CInt(Me.TextBox2.Text) >= cantProm Then
                            precio = (valorProm / cantProm) * CInt(Me.TextBox2.Text)
                            valorU = valorProm / cantProm
                            Label8.Text = precio
                            Query = Query & ",'" & valorU & "','" & precio & "','" & Me.Label35.Text & "')"
                        Else
                            Query = Query & ",'" & Me.Label8.Text & "','" & Me.Label11.Text & "','" & Me.Label35.Text & "')"
                        End If
                        conexionIns.Open()
                        Dim cmd2 As MySqlCommand = New MySqlCommand(Query, conexionIns)
                        cmd2.ExecuteNonQuery()
                        Call estacompra()
                        Call total()
                        Call item()
                        Me.TextBox1.Text = ""
                        conexionIns.Close()
                    Else
                        Query = "insert into ventas (id_fact,id_usuarios,id_caja,id_product,peso,valor_unitario,precio,valor_iva) value ('" & Me.Label22.Text & "','" & Me.Label9.Text & "','" & Me.Label12.Text & "','" & Me.Label6.Text & "','" & Replace(Me.Label5.Text, ",", ".") & "'"

                        If promocion = 0 And CInt(Replace(Me.Label5.Text, ",", ".")) >= cantProm Then
                            precio = (valorProm / cantProm) * CInt(Replace(Me.Label5.Text, ",", "."))
                            valorU = (valorProm / cantProm) * 1000
                            Label8.Text = precio
                            Query = Query & ",'" & valorU & "','" & precio & "','" & Me.Label35.Text & "')"
                        Else
                            Query = Query & ",'" & Me.Label8.Text & "','" & Me.Label11.Text & "','" & Me.Label35.Text & "')"
                        End If







                        conexionIns.Open()
                        Dim cmd2 As MySqlCommand = New MySqlCommand(Query, conexionIns)
                        cmd2.ExecuteNonQuery()
                        Call estacompra()
                        Call total()
                        Call item()
                        Me.TextBox1.Text = ""
                        conexionIns.Close()
                    End If
                Else
                    For Each row As DataRow In ds.Tables(0).Rows
                        IdVenta = row("Id_venta")
                        IdProd = row("Id_Product")
                        cant = row("cant")
                        peso = row("peso")
                        '1000gr equivale a 1kg
                        valorU = row("valor_unitario")
                        precio = row("precio")
                        cantProm = row("cant_prom")
                        promocion = row("promocion")
                        valorProm = row("valor_prom")
                        iva = row("iva")
                        valorIva = row("valor_iva")
                        conexionIns.Open()
                        If Label13.Text <> "GR" Then
                            totalcant = CInt(Me.TextBox2.Text) + cant
                            valorIva = ((valorU * totalcant) * iva) / 100
                            Label31.Text = iva
                            Label5.Text = totalcant
                            If promocion = 0 And totalcant >= cantProm Then
                                totalPrecio = totalcant * (valorProm / cantProm) + valorIva
                                valorU = valorProm / cantProm
                                Label8.Text = valorU
                                Label11.Text = totalPrecio
                                Label35.Text = valorIva
                                Consulta = "UPDATE Ventas SET cant=" & totalcant & ",precio=" & totalPrecio & ",valor_unitario=" & valorU & ",valor_iva=" & valorIva & " WHERE Activo=1 AND Id_Fact=" & Me.Label22.Text & " AND Id_Product=" & IdProd
                            Else
                                totalPrecio = (totalcant * valorU) + valorIva
                                Label11.Text = totalPrecio
                                Label35.Text = valorIva
                                Consulta = "UPDATE Ventas SET cant=" & totalcant & ",precio=" & totalPrecio & ",valor_iva=" & valorIva & " WHERE Activo=1 AND Id_Fact=" & Me.Label22.Text & " AND Id_Product=" & IdProd
                            End If
                            Dim cmd3 As MySqlCommand = New MySqlCommand(Consulta, conexionIns)
                            cmd3.ExecuteNonQuery()
                            Call estacompra()
                            Call total()
                            Call item()
                            Me.TextBox1.Text = ""
                            conexionIns.Close()
                        Else
                            '1000gr equivale a 1kg
                            Dim a As Integer

                            a = peso

                            totalcant = CInt(Replace(Me.Label5.Text, ",", ".")) + a
                            Label5.Text = totalcant

                            If promocion = 0 And totalcant >= cantProm Then
                                totalPrecio = totalcant * (valorProm / cantProm)
                                valorU = (valorProm / cantProm) * 1000
                                Label8.Text = valorU
                                Label11.Text = totalPrecio
                                Consulta = "UPDATE Ventas SET peso=" & totalcant & ",precio=" & totalPrecio & ",valor_unitario=" & valorU & " WHERE Id_Fact=" & Me.Label22.Text & " AND Id_Product=" & IdProd
                            Else
                                totalPrecio = (totalcant / 1000) * valorU
                                Label11.Text = totalPrecio
                                Consulta = "UPDATE Ventas SET peso=" & totalcant & ",precio=" & totalPrecio & " WHERE Id_Fact=" & Me.Label22.Text & " AND Id_Product=" & IdProd
                            End If

                            Dim cmd3 As MySqlCommand = New MySqlCommand(Consulta, conexionIns)
                            cmd3.ExecuteNonQuery()
                            Call estacompra()
                            Call total()
                            Call item()
                            Me.TextBox1.Text = ""
                            conexionIns.Close()
                        End If
                    Next row
                End If
                Adapter.Dispose()
            Catch ex As Exception
                MsgBox("fallo update", vbExclamation, "Atención      SKYNET")
            End Try
        Else
            Call IngSaldos()
        End If
    End Sub
    Sub IngSaldos()
        Dim Query As String
        Try
            If Label13.Text <> "GR" Then
                Query = "insert into ventas (id_fact,id_usuarios,id_caja,id_product,cant,valor_unitario,precio,valor_iva) value ('" & Me.Label22.Text & "','" & Me.Label9.Text & "','" & Me.Label12.Text & "','" & Me.Label6.Text & "','" & Me.TextBox2.Text & "','" & Me.Label8.Text & "','" & Me.Label11.Text & "','" & Me.Label35.Text & "')"
                varconex.Open()
                Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
                cmd2.ExecuteNonQuery()
                Call estacompra()
                Call total()
                Call item()
                Me.TextBox1.Text = ""

                varconex.Close()

            Else
                Query = "insert into ventas (id_fact,  id_usuarios,  id_caja,  id_product,  peso,  valor_unitario,  precio,  valor_iva) value ('" & Me.Label22.Text & "','" & Me.Label9.Text & "','" & Me.Label12.Text & "','" & Me.Label6.Text & "','" & Replace(Me.Label5.Text, ",", ".") & "','" & Me.Label8.Text & "','" & Me.Label11.Text & "','" & Me.Label35.Text & "')"
                varconex.Open()
                Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
                cmd2.ExecuteNonQuery()
                Call estacompra()
                Call total()
                Call item()
                Me.TextBox1.Text = ""
                varconex.Close()

            End If
        Catch ex As Exception
            MsgBox("fallo update", vbExclamation, "Atención      SKYNET")
        End Try
    End Sub


    Private Sub FormVenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'VENTAS.puertoserial.Close()
        VENTAS.Hide()
        VENTAS.puertoserial.Close()
        ToolStripButton1.PerformClick()
        Call empresa()

        Me.TextBox1.Focus()



        Dim fechaactual As String = Date.Now.ToString("yyyy/MM/dd HH:mm:ss")

        Label4.Text = fechaactual



        If Label30.Text = "" Then
            Label30.Text = 0
        End If

        Try


            puertoserial2.Close()
            TraeConfiguracion()


            If Not puertoserial2.IsOpen Then
                puertoserial2.Open()
            Else
                puertoserial2.Close()

            End If

        Catch ex As Exception
            MsgBox("problema con la bascula reinicie el programa", vbExclamation, "Atención      SKYNET")
        End Try

        estacompra()
        total()
        item()



    End Sub
    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        End
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim cadena3 As String = "select articulos.id_product,articulos.iva,articulos.cod_product,articulos.inventario,articulos.nomb_product,articulos.precio_venta,medida.id_medida,medida.medida,articulos.promocion,articulos.cant_prom,articulos.valor_prom from articulos INNER JOIN medida ON (articulos.id_medida = medida.id_medida) WHERE articulos.cod_product= '" & TextBox1.Text & "' OR nomb_product LIKE  '%" & TextBox1.Text & "%'"

        Dim da1 As New MySqlDataAdapter(cadena3, varconex)
        Dim producto As String
        Dim nombre As String
        Dim precio As Double
        Dim medida As String

        Dim cant As Double
        Dim valor_prom As Double
        Dim promocion As Integer
        Dim idmedida As Integer
        Dim iva As Integer
        producto = ""
        nombre = ""

        medida = ""
        sql.CommandText = cadena3
        sql.Connection = varconex
        da1.SelectCommand = sql
        codata.Clear()
        da1.Fill(codata)
        If codata.Tables(0).Rows.Count = 0 Then
            MessageBox.Show("El producto digitado no es valido, o no esta creado por favor crear el artículo")
            Exit Sub
        ElseIf codata.Tables(0).Rows.Count > 1 Then
            BuscarProducto2.ShowDialog()
            If LblSalir.Text = "1" Then
                LblSalir.Text = "0"
                Exit Sub
            End If
            producto = Me.Label6.Text
            nombre = Me.Label7.Text
            precio = Me.Label8.Text
            valor_prom = Me.Label8.Text
            medida = Me.Label13.Text
            promocion = Me.Label26.Text
            cant = Me.Label27.Text
            iva = Me.Label31.Text
        ElseIf codata.Tables(0).Rows.Count = 1 Then
            producto = codata.Tables(0).Rows(0).Item("id_product")
            nombre = codata.Tables(0).Rows(0).Item("nomb_product")
            precio = codata.Tables(0).Rows(0).Item("precio_venta")
            idmedida = codata.Tables(0).Rows(0).Item("id_medida")
            medida = codata.Tables(0).Rows(0).Item("medida")
            promocion = codata.Tables(0).Rows(0).Item("promocion")
            cant = codata.Tables(0).Rows(0).Item("cant_prom")
            valor_prom = codata.Tables(0).Rows(0).Item("valor_prom")
            iva = codata.Tables(0).Rows(0).Item("iva")
            Label35.Text = ""
            Me.Label6.Text = producto
            Me.Label7.Text = nombre
            Me.Label8.Text = precio
            Me.Label13.Text = medida
            Me.Label26.Text = promocion
            Me.Label27.Text = cant
            Me.Label31.Text = iva
            Me.total_venta.Refresh()
        End If


        If ((promocion = 0) And (medida = "GR") And (Label5.Text >= cant)) Then
            Me.Label8.Text = valor_prom
            Me.Label28.Text = valor_prom
            Me.Label29.Visible = True
            Me.Label29.Text = "promocion"



        Else
            Me.Label29.Visible = False
            Me.Label8.Text = precio
        End If


        If producto = "" Then


            BuscarProducto2.Label2.Text = Label5.Text
            BuscarProducto2.ShowDialog()

            BuscarProducto2.TextBox1.Focus()
        End If


        Label7.Visible = True

        If Label13.Text <> "GR" Then
            Label5.Visible = False
            Me.Label29.Visible = False

            TextBox2.Visible = True
            TextBox1.Focus()
        Else
            TextBox2.Visible = False
            Label5.Visible = True
            TextBox1.Focus()
        End If
        promo()


        estacompra()
        VariablesGoblales.Saldo = 0
        insertar(Saldo)
        total()
        item()
        varconex.Close()


    End Sub
    Public Sub TraeConfiguracion()
        Try
            puertoserial2.Close()
            puertoserial2.PortName = "COM1"
            puertoserial2.BaudRate = "9600"
            puertoserial2.DataBits = "8"
            puertoserial2.StopBits = "1"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Public Sub puertoserial_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles puertoserial2.DataReceived
        Dim n As Integer
        Try
            UpdateFormDelegate1 = New UpdateFormDelegate(AddressOf UpdateDisplay)
            n = puertoserial2.BytesToRead ' 
            If n > 50 Then
                ComBuffer = New Byte(n - 1) {}
                puertoserial2.Read(ComBuffer, 0, n)
                Me.Invoke(UpdateFormDelegate1)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub UpdateDisplay()

        Try
            Dim incoming As String = ""
            Dim longBuffer As Long
            Dim i As Integer

            longBuffer = ComBuffer.Length
            For i = 0 To longBuffer - 1
                incoming = incoming & Chr(ComBuffer(i))
            Next
            strReturn = incoming.ToString

            If strReturn.Length > 2 Then
                i = 0
                strPeso = ""
                Dim blnLeyoNumero As Boolean
                For i = 1 To strReturn.Length
                    car = Mid(strReturn, i, 1)
                    If IsNumeric(car) Or car = "." Then
                        strPeso = strPeso & car

                        blnLeyoNumero = True
                    Else
                        If blnLeyoNumero Then Exit For
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ' //////////// EDITAR ERROR DE BASCULA

        Label5.Text = strPeso + 0

    End Sub

    Public Sub promo()
        Me.TextBox2.Text = 1
        Dim hp As Integer
        hp = Label5.Text
        Dim total, totaliva, totalfinal As Double
        If ((Label26.Text = 0) And (Label13.Text = "GR") And (hp >= Label27.Text)) Then

            total = (Label28.Text / Label27.Text) * hp
            totaliva = (total * Label31.Text / 100)
            totalfinal = total + totaliva
            Label35.Text = totaliva
            Label11.Text = totalfinal

            TextBox1.Focus()
            If ((Label26.Text = 0) And (Label13.Text <> "GR") And (TextBox2.Text >= Label27.Text)) Then

                total = (Label8.Text * TextBox2.Text)
                totaliva = (total * Label31.Text / 100)
                totalfinal = total + totaliva
                Label35.Text = totaliva
                Label11.Text = totalfinal
                TextBox1.Focus()

            End If


        Else
            If (Label13.Text <> "GR") Then
                total = (Label8.Text * TextBox2.Text)
                totaliva = (total * Label31.Text / 100)
                totalfinal = totaliva + total
                Label35.Text = totaliva
                Label11.Text = totalfinal
                TextBox1.Focus()
            Else
                total = hp * Label8.Text / 1000
                totaliva = (total * Label31.Text / 100)
                totalfinal = total + totaliva
                Label35.Text = totaliva
                Label11.Text = totalfinal
            End If
        End If





    End Sub
    Public Sub ivas()
        Dim total, totaliva, totalfinal As Double
        If ((Label31.Text = 0) And (Label13.Text <> "GR")) Then
            total = (Label8.Text * TextBox2.Text)
            totaliva = (total * Label31.Text / 100)
            totalfinal = totaliva + total
            Label35.Text = totaliva
            Label11.Text = totalfinal
            MsgBox(Label11.Text)
            TextBox1.Focus()
            ' esto si no tiene iva ni promocion
        Else
            total = Label5.Text * Label8.Text / 1000
            totaliva = (total * Label31.Text / 100)
            totalfinal = totaliva + total
            Label35.Text = totaliva
            Label11.Text = totalfinal

        End If
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Try
            puertoserial2.Close()
            COBRAR2.Label14.Text = Label1.Text
            COBRAR2.Label15.Text = Label16.Text
            COBRAR2.Label3.Text = Label9.Text
            COBRAR2.Label4.Text = Label12.Text
            COBRAR2.Label2.Text = total_venta.Text
            COBRAR2.Label9.Text = Label22.Text
            COBRAR2.Label12.Text = Label38.Text
            COBRAR2.ListBox1.Items.Clear()
            COBRAR2.TextBox1.Clear()
            Me.Close()
            COBRAR2.Show()


        Catch ex As Exception
            MsgBox("puerto com bloqueado", vbExclamation, "Atención      SKYNET")
        End Try



    End Sub

    Private Sub estacompra()
        Try
            Dim sql As String

            sql = "SELECT ventas.id_venta,articulos.cod_product, articulos.nomb_product,medida.medida,ventas.peso,ventas.cant,ventas.valor_unitario,ventas.valor_iva,ventas.precio, articulos.inventario,facturas.id_Fact FROM ventas INNER JOIN usuarios ON (ventas.id_usuarios = usuarios.id_usuarios) INNER JOIN pos ON (ventas.id_caja = pos.id_caja) INNER JOIN articulos ON (ventas.id_product = articulos.id_product) INNER JOIN medida ON (articulos.id_medida = medida.id_medida) INNER JOIN facturas ON  (ventas.id_fact = facturas.id_fact) WHERE  usuarios.id_usuarios=" & Me.Label9.Text & " AND pos.id_caja= " & Me.Label12.Text & " AND ventas.activo = 1  and facturas.id_fact=" & Me.Label22.Text & " order by ventas.id_venta desc"
            Dim Dt As New DataTable
            Dim Da As New MySqlDataAdapter(sql, varconex)
            Da.Fill(Dt)
            DataGridView1.DataSource = Dt
            DataGridView1.Columns(0).Width = 50
            DataGridView1.Columns(0).Visible = False
            DataGridView1.Columns(1).Width = 140
            DataGridView1.Columns(2).Width = 450
            DataGridView1.Columns(3).Width = 80
            DataGridView1.Columns(4).Width = 80
            DataGridView1.Columns(5).Width = 80
            DataGridView1.Columns(6).Width = 100
            DataGridView1.Columns(7).Width = 100
            DataGridView1.Columns(8).Width = 100
            DataGridView1.Columns(9).Width = 80
            DataGridView1.Columns(10).Width = 80
            DataGridView1.Columns(10).Visible = False
            varconex.Close()
            'MsgBox(sql)
        Catch ex As Exception
            MsgBox("ERROR,  Por favor reparar tablas, cierre el programa e inicie nuevamente", vbExclamation, "Atención:      SKYNET")
            End

        End Try

    End Sub
    Public Sub empresa()
        Dim cmdempr As New MySqlCommand("SELECT empresa.empresa FROM empresa", conexion)
        Try
            Dim lecturaempr As MySqlDataReader
            If Not conexion Is Nothing Then conexion.Close()
            conexion.Open()
            lecturaempr = cmdempr.ExecuteReader
            If lecturaempr.Read() Then
                Me.Label39.Text = lecturaempr.Item("empresa")
            End If
            conexion.Close()
        Catch ex As Exception
            MsgBox("la empresa aun no esta registrada", vbExclamation, "Atención      SKYNET")
        End Try
    End Sub
    Public Sub total()
        Try
            'Dim cmd As New MySqlCommand("SELECT SUM(ventas.precio) AS TOTAL FROM ventas INNER JOIN usuarios ON (ventas.id_usuarios = usuarios.id_usuarios) INNER JOIN pos ON (ventas.id_caja = pos.id_caja) INNER JOIN articulos ON (ventas.id_product = articulos.id_product) INNER JOIN medida ON (articulos.id_medida = medida.id_medida) WHERE  usuarios.id_usuarios=" & Me.Label9.Text & " AND pos.id_caja= " & Me.Label12.Text & " AND ventas.activo = 1", conexion)
            Dim cmd As New MySqlCommand("SELECT SUM(ventas.precio) AS TOTAL FROM ventas INNER JOIN usuarios ON (ventas.id_usuarios = usuarios.id_usuarios) INNER JOIN pos ON (ventas.id_caja = pos.id_caja) INNER JOIN articulos ON (ventas.id_product = articulos.id_product) INNER JOIN medida ON (articulos.id_medida = medida.id_medida) INNER JOIN facturas ON (facturas.id_fact = ventas.id_fact) WHERE  usuarios.id_usuarios=" & Me.Label9.Text & " AND pos.id_caja= " & Me.Label12.Text & " AND ventas.activo = 1 and facturas.id_fact=" & Me.Label22.Text & "", conexion)

            Dim lectura As MySqlDataReader
            If Not conexion Is Nothing Then conexion.Close()
            conexion.Open()
            lectura = cmd.ExecuteReader
            If lectura.Read() Then
                Me.total_venta.Text = FormatNumber(CStr(Math.Round(lectura.Item("TOTAL") / 50) * 50), TriState.False)
                Me.Label38.Text = CStr(Math.Round(lectura.Item("TOTAL") / 50) * 50)
            End If

        Catch ex As Exception
            Me.total_venta.Text = 0
        End Try

        conexion.Close()
    End Sub
    Public Sub item()
        '  Dim cmd As New MySqlCommand("SELECT SUM(ventas.precio) AS TOTAL FROM ventas INNER JOIN usuarios ON (ventas.id_usuarios = usuarios.id_usuarios) INNER JOIN pos ON (ventas.id_caja = pos.id_caja) INNER JOIN articulos ON (ventas.id_product = articulos.id_product) INNER JOIN medida ON (articulos.id_medida = medida.id_medida) INNER JOIN facturas ON (facturas.id_fact = ventas.id_fact) WHERE  usuarios.id_usuarios=" & Me.Label9.Text & " AND pos.id_caja= " & Me.Label12.Text & " AND ventas.activo = 1 and facturas.id_fact=" & Me.Label22.Text & "", conexion)

        Dim cmd As New MySqlCommand("select COUNT(articulos.id_product) as contar FROM ventas INNER JOIN usuarios ON (ventas.id_usuarios = usuarios.id_usuarios) INNER JOIN pos ON (ventas.id_caja = pos.id_caja) INNER JOIN articulos ON (ventas.id_product = articulos.id_product) INNER JOIN medida ON (articulos.id_medida = medida.id_medida) INNER JOIN facturas ON (facturas.id_fact = ventas.id_fact) WHERE  usuarios.id_usuarios=" & Me.Label9.Text & " AND pos.id_caja= " & Me.Label12.Text & " AND ventas.activo = 1 and facturas.id_fact=" & Me.Label22.Text & "", conexion)
        Try
            Dim lectura2 As MySqlDataReader
            If Not conexion Is Nothing Then conexion.Close()
            conexion.Open()
            lectura2 = cmd.ExecuteReader
            If lectura2.Read() Then
                Me.Label20.Text = lectura2.Item("contar")
            End If
        Catch ex As Exception
            Me.Label20.Text = 0
        End Try
        conexion.Close()
    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown


        If e.KeyCode = Keys.Enter Then
            Dim idventa As Integer
            puertoserial2.Close()
            idventa = Me.DataGridView1.CurrentRow.Cells(0).Value
            Label21.Text = idventa

            LOGIN_BORRADO2.Label1.Text = idventa
            LOGIN_BORRADO2.Label20.Text = Label16.Text
            LOGIN_BORRADO2.Label19.Text = Label1.Text
            LOGIN_BORRADO2.Label3.Text = Label9.Text
            LOGIN_BORRADO2.Label13.Text = Label12.Text
            LOGIN_BORRADO2.Label16.Text = Label22.Text
            TraeConfiguracion()
            Me.Close()
            'Me.Visible = False
            TextBox1.Focus()
            LOGIN_BORRADO2.ShowDialog()
        End If
    End Sub



    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        Dim idventa As Integer
        puertoserial2.Close()
        idventa = Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value
        Label21.Text = idventa

        LOGIN_BORRADO2.Label19.Text = Label1.Text
        LOGIN_BORRADO2.Label20.Text = Label16.Text
        LOGIN_BORRADO2.Label1.Text = idventa
        LOGIN_BORRADO2.Label3.Text = Label9.Text
        LOGIN_BORRADO2.Label13.Text = Label12.Text
        LOGIN_BORRADO2.Label16.Text = Label22.Text
        LOGIN_BORRADO2.TextBox1.Focus()

        TraeConfiguracion()
        Me.Close()
        'Me.Visible = False

        LOGIN_BORRADO2.ShowDialog()




    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        BuscarProducto2.ShowDialog()

    End Sub

    Private Sub total_venta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles total_venta.Click

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        COBRAR2.ShowDialog()

    End Sub
    Public Sub refrescar()
        Me.Refresh()
    End Sub


    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        'Call fechahora()
        'Call totalventas()
        'LOGIN_CIERRE.Label4.Text = Label12.Text
        'LOGIN_CIERRE.Label3.Text = Label9.Text

        'Me.Enabled = False
        'LOGIN_CIERRE.ShowDialog()

    End Sub
    Public Sub fechahora()
        Dim cmdfecha As New MySqlCommand("select entrada_caja.fecha_entrada  FROM entrada_caja INNER JOIN usuarios ON (entrada_caja.id_usuarios = usuarios.id_usuarios) INNER JOIN pos ON (entrada_caja.id_caja = pos.id_caja)  WHERE  usuarios.id_usuarios=" & Me.Label9.Text & " AND pos.id_caja= " & Me.Label12.Text & " AND entrada_caja.activo = 1", conexion2)
        Dim lectura_fecha As MySqlDataReader
        If Not conexion2 Is Nothing Then conexion2.Close()
        conexion2.Open()
        lectura_fecha = cmdfecha.ExecuteReader
        If lectura_fecha.Read() Then
            Me.Label25.Text = lectura_fecha.Item("fecha_entrada")
        End If
        conexion2.Close()
    End Sub
    Public Sub totalventas()
        Dim cmdtotal As New MySqlCommand("select SUM(ventas.precio) AS ventas  FROM ventas INNER JOIN pos ON (ventas.id_caja = pos.id_caja) INNER JOIN usuarios ON (ventas.id_usuarios = usuarios.id_usuarios) INNER JOIN entrada_caja ON (usuarios.id_usuarios = entrada_caja.id_usuarios) AND (pos.id_caja = entrada_caja.id_caja)  WHERE  usuarios.id_usuarios=" & Me.Label9.Text & " AND pos.id_caja= " & Me.Label12.Text & " AND ventas.activo = 2 and entrada_caja.activo = 1", conexion2)
        Dim lectura_total As MySqlDataReader
        If Not conexion2 Is Nothing Then conexion2.Close()
        conexion2.Open()
        lectura_total = cmdtotal.ExecuteReader
        If lectura_total.Read() Then
            Me.Label24.Text = lectura_total.Item("ventas")
        End If
        conexion2.Close()
    End Sub


    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        Reimprimir.Label2.Text = Label9.Text
        Reimprimir.ShowDialog()


    End Sub

    Private Sub ToolStripButton2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        puertoserial2.Close()
        Buscar.ShowDialog()
        puertoserial2.Open()
    End Sub

    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
        If Label30.Text = 1 Then
            CANTIDADES2.Label2.Text = Label5.Text
            CANTIDADES2.ShowDialog()
        Else
            MsgBox("favor inicie venta con F2", vbExclamation, "Atención      SKYNET")
        End If

    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    'Private Sub tmpPrueba_Tick(sender As Object, e As EventArgs) Handles tmpPrueba.Tick

    'End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs)
        GASTOS.ShowDialog()
    End Sub

    Private Sub Label25_Click(sender As Object, e As EventArgs) Handles Label25.Click

    End Sub

    Private Sub Label22_Click(sender As Object, e As EventArgs) Handles Label22.Click

    End Sub

    Private Sub Label20_Click(sender As Object, e As EventArgs) Handles Label20.Click

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        facturas.Show()
    End Sub

    Private Sub Button2_Click_2(sender As Object, e As EventArgs) Handles Button2.Click
        VENTAS.Show()
        puertoserial2.Close()
        Me.Hide()

    End Sub

    Private Sub Label48_Click(sender As Object, e As EventArgs) Handles Label48.Click

    End Sub

    Private Sub ToolStripButton3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        If Label30.Text = 1 Then
            SALDOS2.MaskedTextBox1.Focus()
            SALDOS2.Label4.Text = Me.TextBox2.Text
            SALDOS2.ShowDialog()
        Else
            MsgBox("favor inicie venta con F2", vbExclamation, "Atención      SKYNET")
        End If
    End Sub

    Private Sub ToolStripButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton8.Click

        'LOGIN_AZ.Label3.Text = Label9.Text
        'LOGIN_AZ.Label4.Text = Label12.Text

        'LOGIN_AZ.ShowDialog()
    End Sub

    Private Sub ToolStripButton10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub Label17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles totalventa.Click

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged


    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub Label30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label30.Click

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub

    'Private Sub tmpPrueba_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmpPrueba.Tick

    'End Sub

    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label12.Click

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click

    End Sub

    Private Sub Label16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label16.Click

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub
End Class
