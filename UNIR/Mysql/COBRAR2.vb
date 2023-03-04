Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration
Imports System.Diagnostics
Imports System.IO
Imports System.Drawing.Printing
Imports System.Runtime.InteropServices
Public Class COBRAR2

    Dim cadena As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
    Dim varconex, conexion As New MySqlConnection(cadena)
    Dim RawPrinterHelper As Object
    Dim strCurrency As String = ""
    Dim acceptableKey As Boolean = False
    Private _titulo As Object
    Dim f_efectivo As String




    Private Sub Form7_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Enter Then
            ToolStripButton4.PerformClick()
        End If
        If e.KeyCode = Keys.F10 Then
            VENTAS2.TextBox1.Focus()
            VENTAS2.Label1.Text = Label14.Text
            VENTAS2.Label16.Text = Label15.Text
            VENTAS2.Label9.Text = Label3.Text
            VENTAS2.Label12.Text = Label4.Text
            VENTAS2.Label22.Text = Label9.Text
            VENTAS2.TextBox1.Enabled = True
            VENTAS2.Button1.Enabled = True
            VENTAS2.Button3.Enabled = True
            VENTAS2.DataGridView1.Enabled = True
            VENTAS2.TextBox1.Focus()
            VENTAS2.Show()
            Close()
        End If

        If e.KeyCode = Keys.F5 Then
            If TxtNit.Text = "" Then
                MsgBox("Debe Ingresar el Nit", MsgBoxStyle.Critical, "Validar Nit")
                TxtNit.Focus()
                Exit Sub
            ElseIf TxtCliente.Text = "" Then
                MsgBox("Debe Ingresar el Cliente", MsgBoxStyle.Critical, "Validar Nit")
                TxtCliente.Focus()
                Exit Sub
            ElseIf TxtDireccion.Text = "" Then
                MsgBox("Debe Ingresar la dirección", MsgBoxStyle.Critical, "Validar Nit")
                TxtDireccion.Focus()
                Exit Sub
            ElseIf TxtTelefono.Text = "" Then
                MsgBox("Debe Ingresar el Telefono", MsgBoxStyle.Critical, "Validar Nit")
                TxtTelefono.Focus()
                Exit Sub
            End If
            If TextBox1.Text = "" Then
                MsgBox("Ingrese cantidad de efectivo", vbExclamation, "Atención      SKYNET")

            Else
                If Label2.Text = 0 Then
                    MsgBox("NO HAY articulos", vbExclamation, "Atención      SKYNET")
                Else
                    'cajon()
                    Call updatefact()
                    Call updateventas2()
                    Call MostrarFactura()
                    Call UpdFacturaCliente()

                    If VariablesGoblales.SistemaPuntos = True Then
                        Call calculo_puntos()
                        Call ingreso_puntos()
                    End If

                    ListBox1.Items.Add(("EFECTIVO: $") & (Me.TextBox1.Text))
                        ListBox1.Items.Add(("CAMBIO: $") & (Me.Label7.Text))
                        CAMBIO2.Label5.Text = Label7.Text
                        CAMBIO2.Label3.Text = TextBox1.Text
                        CAMBIO2.Label2.Text = Label2.Text
                        ListBox1.Items.Add("_________________________________")
                        Dim cmdpos As New MySqlCommand("SELECT pos.nomb_caja FROM pos where pos.id_caja= " & Me.Label4.Text & "", conexion)
                        Dim lecturacaja As MySqlDataReader

                        If Not conexion Is Nothing Then conexion.Close()
                        conexion.Open()
                        lecturacaja = cmdpos.ExecuteReader

                        If lecturacaja.Read() Then

                            ListBox1.Items.Add(lecturacaja("nomb_caja"))

                        End If

                        conexion.Close()
                        ListBox1.Items.Add(("CAJERO:") & Chr(9) & (Me.Label14.Text))

                        Dim cmdempresa2 As New MySqlCommand("SELECT empresa.empresa,empresa.nit,empresa.direccion,empresa.telefono,empresa.ciudad,empresa.observacion FROM empresa ", conexion)
                        Dim lecturaempresa2 As MySqlDataReader

                        If Not conexion Is Nothing Then conexion.Close()
                        conexion.Open()
                        lecturaempresa2 = cmdempresa2.ExecuteReader

                        If lecturaempresa2.Read() Then
                            ListBox1.Items.Add(lecturaempresa2("direccion"))
                            ListBox1.Items.Add(("TELEFONO:") & lecturaempresa2("telefono"))
                            ListBox1.Items.Add(lecturaempresa2("ciudad"))
                            ListBox1.Items.Add(("") & lecturaempresa2("observacion") & (""))
                            ListBox1.Items.Add("")
                            ListBox1.Items.Add("*********************************")
                            'ListBox1.Items.Add("   VENTAS SOFTWARE 313 4572408")
                            ListBox1.Items.Add("*********************************")
                        End If
                        Dim valor As Integer
                        valor = MsgBox("Desea Imprimir la Factura?", vbYesNo, "Factura")
                        If valor = 6 Then
                            PrintDocument1.Print()
                        Else
                            cajon()
                        End If
                        Call ManejoInventarios(VariablesGoblales.NoFact)
                        VENTAS2.Label1.Text = Label14.Text
                        VENTAS2.Label16.Text = Label15.Text
                        VENTAS2.Label9.Text = Label3.Text
                        VENTAS2.Label12.Text = Label4.Text
                        VENTAS2.TextBox1.Enabled = False
                        VENTAS2.Button1.Enabled = False
                        VENTAS2.Button3.Enabled = False
                        VENTAS2.DataGridView1.DataSource = Nothing
                        VENTAS2.total_venta.Text = Nothing
                        VENTAS2.Label7.Text = Nothing
                        VENTAS2.Label8.Text = Nothing
                        VENTAS2.Label20.Text = Nothing

                        VENTAS2.Label30.Text = 0
                        Me.Close()
                        conexion.Close()
                        CAMBIO2.Show()
                        'VENTAS2.Show()
                    End If
                End If
        End If
    End Sub
    Sub ManejoInventarios(ByVal noFac As Integer)
        Dim Idprod, Diferencia As Integer
        Dim UpdSQL As String = ""
        Dim Inventario As String = "SELECT Id_Venta, Id_Fact, Ventas.id_Product, cant, peso, IFNULL(inventario,0) as inventario, " &
                                   "CASE WHEN Id_Medida =1 THEN " &
                                   "IFNULL(inventario,0) - peso " &
                                   "ELSE IFNULL(inventario,0) - cant " &
                                   "END AS Diferencia " &
                                   "FROM VENTAS LEFT JOIN Articulos " &
                                   "ON Ventas.id_Product = Articulos.id_Product " &
                                   "WHERE Ventas.Id_Product NOT IN ('S01') AND Id_Fact = " & noFac
        If varconex.State = ConnectionState.Closed Then varconex.Open()
        Dim Adapter As New MySqlDataAdapter(Inventario, varconex)
        Dim ds As New DataSet
        Adapter.Fill(ds)
        For Each row As DataRow In ds.Tables(0).Rows
            Idprod = row("Id_Product")
            Diferencia = row("Diferencia")
            UpdSQL = UpdSQL & "UPDATE Articulos SET inventario=" & Diferencia & " WHERE Id_Product=" & Idprod & ";"
            If varconex.State = ConnectionState.Closed Then varconex.Open()
            Dim ActInventario As New MySqlDataAdapter(UpdSQL, varconex)
            Dim dts As New DataSet
            ActInventario.Fill(dts)
        Next row
        varconex.Close()
        'Actualiza el campo cantidad en la tabla articulos

    End Sub
    Function ObtenerNit(ByVal Nit As Integer) As Integer
        Dim CodCliente As Integer
        Dim Query As String = "Select Id_Cliente From Clientes Where Nit LIKE " & Nit
        If varconex.State = ConnectionState.Closed Then varconex.Open()
        Dim Adapter As New MySqlDataAdapter(Query, varconex)
        Dim ds As New DataSet
        Adapter.Fill(ds)
        If ds.Tables(0).Rows.Count = 0 Then
            CodCliente = 0
        Else
            For Each row As DataRow In ds.Tables(0).Rows
                CodCliente = CInt(row("Id_Cliente"))
            Next row
        End If
        varconex.Close()
        Return CodCliente
    End Function
    Private Sub Form7_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If TxtNit.Text = "" Or TxtCliente.Text = "" Or TxtDireccion.Text = "" Or TxtTelefono.Text = "" Then
            ToolStripButton4.Enabled = False
        Else
            ToolStripButton4.Enabled = True
        End If

        Dim fechaactual As String = Date.Now.ToString("yyyy/MM/dd HH:mm:ss")

        Label8.Text = fechaactual

        'Mostrar Factura
        'Dim cmdempresa As New MySqlCommand("SELECT empresa.empresa,empresa.nit,empresa.direccion,empresa.ciudad,empresa.telefono,empresa.regimen FROM empresa ", conexion)
        'Dim lecturaempresa As MySqlDataReader
        'If Not conexion Is Nothing Then conexion.Close()
        'conexion.Open()
        'lecturaempresa = cmdempresa.ExecuteReader

        'If lecturaempresa.Read() Then

        '    ListBox1.Items.Add(lecturaempresa("empresa"))
        '    ListBox1.Items.Add(("NIT:") & lecturaempresa("nit"))
        '    ListBox1.Items.Add(("REGIMEN:") & lecturaempresa("regimen"))

        'End If
        'ListBox1.Items.Add("<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>")
        'conexion.Close()
        'ListBox1.Items.Add(("FACTURA DE VENTA N°.") & (Me.Label9.Text))
        'ListBox1.Items.Add(Me.Label8.Text)
        'ListBox1.Items.Add("<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>")
        'ListBox1.Items.Add(("CLIENTE: ") & (Me.TxtCliente.Text))
        'ListBox1.Items.Add(("NIT: ") & (Me.TxtNit.Text))
        'ListBox1.Items.Add(("DIRECCIÓN: ") & (Me.TxtDireccion.Text))
        'ListBox1.Items.Add(("TELEFONO: ") & (Me.TxtTelefono.Text))
        'ListBox1.Items.Add("<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>")

        'ListBox1.Items.Add("ARTICULO  |PRECIO|MED|CANT|SUBT.")
        'ListBox1.Items.Add("_____________________________________")
        'Dim cmdventas As New MySqlCommand("SELECT ventas.id_venta, articulos.nomb_product,ventas.valor_unitario,medida.medida,(ventas.peso+''+ventas.cant) as cant,ventas.precio FROM ventas INNER JOIN usuarios ON (ventas.id_usuarios = usuarios.id_usuarios) INNER JOIN pos ON (ventas.id_caja = pos.id_caja) INNER JOIN articulos ON (ventas.id_product = articulos.id_product) INNER JOIN medida ON (articulos.id_medida = medida.id_medida) WHERE  usuarios.id_usuarios=" & Me.Label3.Text & " AND pos.id_caja= " & Me.Label4.Text & " AND ventas.activo = 1 order by articulos.nomb_product ", conexion)
        'Dim lecturaventas As MySqlDataReader
        'If Not conexion Is Nothing Then conexion.Close()
        'conexion.Open()
        'lecturaventas = cmdventas.ExecuteReader

        'While lecturaventas.Read()
        '    Dim item1 As New ListViewItem("item1", 0)
        '    item1.SubItems.Add("1")
        '    ListBox1.Items.Add([String].Format("{0,-10}|{1,-5}|{2,-3}|{3,-4}|{4,5}", Mid(lecturaventas("nomb_product"), 1, 8), lecturaventas("valor_unitario"), lecturaventas("medida"), lecturaventas("cant"), lecturaventas("precio")))


        'End While
        'ListBox1.Items.Add("------------------------------------")


        'Dim cmdiva As New MySqlCommand("SELECT SUM(`ventas`.`valor_iva`) as iva FROM ventas INNER JOIN usuarios ON (ventas.id_usuarios = usuarios.id_usuarios) INNER JOIN pos ON (ventas.id_caja = pos.id_caja) INNER JOIN articulos ON (ventas.id_product = articulos.id_product) INNER JOIN medida ON (articulos.id_medida = medida.id_medida) WHERE usuarios.id_usuarios=" & Me.Label3.Text & " AND pos.id_caja= " & Me.Label4.Text & " AND ventas.activo = 1", conexion)
        'Dim lecturaiva As MySqlDataReader

        'If Not conexion Is Nothing Then conexion.Close()
        'conexion.Open()
        'lecturaiva = cmdiva.ExecuteReader

        'If lecturaiva.Read() Then

        '    ListBox1.Items.Add(("IVA: $ ") & lecturaiva("iva"))

        'End If

        'conexion.Close()

        'ListBox1.Items.Add(("TOTAL VENTA: $ ") & (Me.Label2.Text))



        'conexion.Close()
        'ListBox1.Items.Add("_______________________________________")

    End Sub

    Sub MostrarFactura()
        Dim fechaactual As String = Date.Now.ToString("yyyy/MM/dd HH:mm:ss")


        If VariablesGoblales.SistemaPuntos = True Then
            Call calculo_puntos()
            Call ingreso_puntos()
        End If

        Label8.Text = fechaactual

        Dim cmdempresa As New MySqlCommand("SELECT empresa.empresa,empresa.nit,empresa.direccion,empresa.ciudad,empresa.telefono,empresa.regimen FROM empresa ", conexion)
        Dim lecturaempresa As MySqlDataReader
        If Not conexion Is Nothing Then conexion.Close()
        conexion.Open()
        lecturaempresa = cmdempresa.ExecuteReader

        If lecturaempresa.Read() Then

            ListBox1.Items.Add(lecturaempresa("empresa"))
            ListBox1.Items.Add(("         NIT:") & lecturaempresa("nit"))
            ListBox1.Items.Add(("    REGIMEN:") & lecturaempresa("regimen"))

        End If
        ListBox1.Items.Add("********************************")
        conexion.Close()
        ListBox1.Items.Add(("FACTURA DE VENTA N°.") & (Me.Label9.Text))
        ListBox1.Items.Add(Me.Label8.Text)
        ListBox1.Items.Add("<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>")
        ListBox1.Items.Add(("CLIENTE: ") & (Me.TxtCliente.Text))
        ListBox1.Items.Add(("NIT: ") & (Me.TxtNit.Text))
        ListBox1.Items.Add(("DIRECCIÓN: ") & (Me.TxtDireccion.Text))
        ListBox1.Items.Add(("TELEFONO: ") & (Me.TxtTelefono.Text))
        ListBox1.Items.Add(("  PUNTOS ESTA COMPRA: ") & (Me.Lbl_puntos_estaventa.Text))
        ListBox1.Items.Add(("  PUNTOS ACUMULADOS: ") & (Me.Lbl_puntos.Text))
        ListBox1.Items.Add("<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>")

        ListBox1.Items.Add("ARTICULO  |PRECIO|MED|CANT|SUBT.")
        ListBox1.Items.Add("_____________________________________")
        Dim cmdventas As New MySqlCommand("SELECT ventas.id_venta, articulos.nomb_product,ventas.valor_unitario,medida.medida,(ventas.peso+''+ventas.cant) as cant,ventas.precio FROM ventas INNER JOIN usuarios ON (ventas.id_usuarios = usuarios.id_usuarios) INNER JOIN pos ON (ventas.id_caja = pos.id_caja) INNER JOIN articulos ON (ventas.id_product = articulos.id_product) INNER JOIN medida ON (articulos.id_medida = medida.id_medida) WHERE  usuarios.id_usuarios=" & Me.Label3.Text & " AND pos.id_caja= " & Me.Label4.Text & " AND Id_fact=" & Label9.Text & " order by articulos.nomb_product ", conexion)
        Dim lecturaventas As MySqlDataReader
        Dim BASE As Decimal
        If Not conexion Is Nothing Then conexion.Close()
        conexion.Open()
        lecturaventas = cmdventas.ExecuteReader

        While lecturaventas.Read()
            Dim item1 As New ListViewItem("item1", 0)
            item1.SubItems.Add("1")
            ListBox1.Items.Add([String].Format("{0,-10}|{1,-6}|{2,-3}|{3,-4}|{4,5}", Mid(lecturaventas("nomb_product"), 1, 8), lecturaventas("valor_unitario"), lecturaventas("medida"), lecturaventas("cant"), lecturaventas("precio")))


        End While
        ListBox1.Items.Add("------------------------------------")
        'julio
        conexion.Close()

        ' cambiar como se calcula el iva
        '
        '
        '< 
        '
        '
        '
        '


        Dim cmdiva As New MySqlCommand("SELECT SUM(`ventas`.`valor_iva`) as iva FROM ventas INNER JOIN usuarios ON (ventas.id_usuarios = usuarios.id_usuarios) INNER JOIN pos ON (ventas.id_caja = pos.id_caja) INNER JOIN articulos ON (ventas.id_product = articulos.id_product) INNER JOIN medida ON (articulos.id_medida = medida.id_medida) WHERE usuarios.id_usuarios=" & Me.Label3.Text & " AND pos.id_caja= " & Me.Label4.Text & " AND Id_fact=" & Label9.Text, conexion)
        Dim lecturaiva As MySqlDataReader

        If Not conexion Is Nothing Then conexion.Close()
        conexion.Open()
        lecturaiva = cmdiva.ExecuteReader

        If lecturaiva.Read() Then
            BASE = Me.Label2.Text - lecturaiva("iva")
            ListBox1.Items.Add(("BASE: $ ") & FormatNumber(BASE, 0))
            ListBox1.Items.Add(("IVA: $ ") & lecturaiva("iva"))

        End If

        conexion.Close()

        ListBox1.Items.Add(("TOTAL VENTA: $ ") & (Me.Label2.Text))



        conexion.Close()
        ListBox1.Items.Add("_________________________________")
    End Sub
    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        Dim fnt As New Font("Courier New", 8.5, FontStyle.Bold, GraphicsUnit.Point)

        Dim ListBoxItem As String = String.Empty

        For Each LBItem As String In ListBox1.Items

            ListBoxItem = ListBoxItem & vbCrLf & LBItem
        Next
        ListBoxItem = ListBoxItem.Substring(vbCrLf.Length)
        e.Graphics.DrawString(ListBoxItem, fnt, Brushes.Black, 0, 0)
        e.HasMorePages = False


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
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

        'TextBox1.Text = Puntos(TextBox1.Text)
        TextBox1.Select(TextBox1.Text.Length, 0)
        Try
            Dim cambio As Long

            cambio = (TextBox1.Text - Label2.Text)

            Me.Label7.Text = cambio


        Catch ex As Exception
            Me.Label7.Text = 0
        End Try

    End Sub
    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Public Sub updatefact()
        Dim Query As String
        Try
            If varconex.State = ConnectionState.Open Then varconex.Close()

            Query = "update facturas set activo= 2, fecha_fact='" & Label8.Text & "', total_fact=" & Label12.Text & ",efectivo=" & TextBox1.Text & ",cambio =" & Label7.Text & " where id_fact=" & Label9.Text & " and id_caja =" & Label4.Text & " and id_usuarios=" & Label3.Text & " and facturas.activo=1"
            varconex.Open()
            Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
            cmd2.ExecuteNonQuery()

            varconex.Close()


        Catch ex As Exception
            MsgBox("fallo de actualización", vbExclamation, "Atención      SKYNET")


        End Try
    End Sub
    Public Sub updateventas2()
        Dim update As String
        Try

            If varconex.State = ConnectionState.Open Then varconex.Close()
            update = "update ventas set activo= 2 where id_fact=" & Label9.Text & " and id_caja =" & Label4.Text & " and id_usuarios=" & Label3.Text & " and activo=1 "
            varconex.Open()
            Dim cmd3 As MySqlCommand = New MySqlCommand(update, varconex)
            cmd3.ExecuteNonQuery()

            varconex.Close()


        Catch ex As Exception

            MsgBox("Fallo de actualización", vbExclamation, "Atención      SKYNET")



        End Try
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        VENTAS2.TextBox1.Focus()
        VENTAS2.Label1.Text = Label14.Text
        VENTAS2.Label16.Text = Label15.Text
        VENTAS2.Label9.Text = Label3.Text
        VENTAS2.Label12.Text = Label4.Text
        VENTAS2.Label22.Text = Label9.Text
        VENTAS2.TextBox1.Enabled = True
        VENTAS2.Button1.Enabled = True
        VENTAS2.Button3.Enabled = True
        VENTAS2.DataGridView1.Enabled = True

        VENTAS2.Show()
        Close()
    End Sub

    Private Sub cajon()

        'FileOpen(1, AppDomain.CurrentDomain.BaseDirectory & "open.txt", OpenMode.Output)
        'PrintLine(1, Chr(27) & Chr(110) & Chr(0) & Chr(25) & Chr(250))
        'FileClose(1)
        'Shell("print /d:USB1 open.txt", AppWinStyle.Hide)
        'srp 280 secuencias de escape 27,112,0,64,240
        Dim pd As New PrintDialog()
        Dim Impresora As New System.Drawing.Printing.PrinterSettings
        pd.PrinterSettings = New PrinterSettings()

        'If (pd.ShowDialog() = DialogResult.OK) Then
        WindowsApplication1.RawPrinterHelper.SendStringToPrinter(Impresora.PrinterName, Chr(27) & Chr(112) & Chr(0) & Chr(25) & Chr(250))
        'End If

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub ToolStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub


    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click

    End Sub

    Private Sub Label14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label14.Click

    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click

        If TextBox1.Text = "" Then
            MsgBox("Ingrese cantidad de efectivo ", vbExclamation, "Atención      SKYNET")

        Else
            If Label2.Text = 0 Then
                MsgBox("no hay nada para facturar")
            Else
                'cajon()
                Call updatefact()
                Call updateventas2()


                If VariablesGoblales.SistemaPuntos = True Then
                    Call calculo_puntos()
                    Call ingreso_puntos()
                End If


                If TxtNit.Text = "" Then

                        MsgBox("Debe Ingresar el Nit", MsgBoxStyle.Critical, "Validar Nit")
                        TxtNit.Focus()
                        Exit Sub
                    ElseIf TxtCliente.Text = "" Then
                        MsgBox("Debe Ingresar el Cliente", MsgBoxStyle.Critical, "Validar Nit")
                        TxtCliente.Focus()
                        Exit Sub
                    ElseIf TxtDireccion.Text = "" Then
                        MsgBox("Debe Ingresar la dirección", MsgBoxStyle.Critical, "Validar Nit")
                        TxtDireccion.Focus()
                        Exit Sub
                    ElseIf TxtTelefono.Text = "" Then
                        MsgBox("Debe Ingresar el Telefono", MsgBoxStyle.Critical, "Validar Nit")
                        TxtTelefono.Focus()
                        Exit Sub
                    End If
                    Call MostrarFactura()
                    Call UpdFacturaCliente()

                    ListBox1.Items.Add(("EFECTIVO: $") & (Me.TextBox1.Text))
                    ListBox1.Items.Add(("CAMBIO: $") & (Me.Label7.Text))
                    CAMBIO2.Label5.Text = Label7.Text
                    CAMBIO2.Label3.Text = TextBox1.Text
                    CAMBIO2.Label2.Text = Label2.Text
                    ListBox1.Items.Add("_________________________________")
                    Dim cmdpos As New MySqlCommand("SELECT pos.nomb_caja FROM pos where pos.id_caja= " & Me.Label4.Text & "", conexion)
                    Dim lecturacaja As MySqlDataReader
                    If Not conexion Is Nothing Then conexion.Close()
                    conexion.Open()
                    lecturacaja = cmdpos.ExecuteReader

                    If lecturacaja.Read() Then

                        ListBox1.Items.Add(lecturacaja("nomb_caja"))

                    End If
                    conexion.Close()
                    ListBox1.Items.Add(("CAJERO: ") & (Me.Label14.Text))
                    Dim cmdempresa2 As New MySqlCommand("SELECT empresa.empresa,empresa.nit,empresa.direccion,empresa.telefono,empresa.ciudad,empresa.observacion FROM empresa ", conexion)
                    Dim lecturaempresa2 As MySqlDataReader

                    If Not conexion Is Nothing Then conexion.Close()
                    conexion.Open()
                    lecturaempresa2 = cmdempresa2.ExecuteReader

                    If lecturaempresa2.Read() Then
                        ListBox1.Items.Add(lecturaempresa2("direccion"))
                        ListBox1.Items.Add(("TELEFONO:") & lecturaempresa2("telefono"))
                        ListBox1.Items.Add(lecturaempresa2("ciudad"))
                        ListBox1.Items.Add(("") & lecturaempresa2("observacion") & (""))
                        ListBox1.Items.Add("")
                        ListBox1.Items.Add("*********************************")
                        'ListBox1.Items.Add("   VENTAS SOFTWARE 313 4572408")
                        ListBox1.Items.Add("*********************************")

                    End If
                    Dim valor As Integer
                    valor = MsgBox("Desea Imprimir la Factura?", vbYesNo, "Factura")
                    If valor = 6 Then
                        PrintDocument1.Print()

                    Else

                        cajon()
                    End If
                    Call ManejoInventarios(VariablesGoblales.NoFact)
                    VENTAS2.Label1.Text = Label14.Text
                    VENTAS2.Label16.Text = Label15.Text
                    VENTAS2.Label9.Text = Label3.Text
                    VENTAS2.Label12.Text = Label4.Text
                    VENTAS2.TextBox1.Enabled = False
                    VENTAS2.Button1.Enabled = False
                    VENTAS2.Button3.Enabled = False
                    VENTAS2.DataGridView1.DataSource = Nothing
                    VENTAS2.total_venta.Text = Nothing
                    VENTAS2.Label7.Text = Nothing
                    VENTAS2.Label8.Text = Nothing
                    VENTAS2.Label20.Text = Nothing

                    VENTAS2.Label30.Text = 0
                    Me.Close()
                    'VENTAS2.Show()
                    CAMBIO2.Show()
                    conexion.Close()

                End If
            End If
    End Sub
    Sub InsertarClientes()
        If ObtenerNit(TxtNit.Text) = 0 Then
            Dim Query As String
            Try
                If varconex.State = ConnectionState.Open Then varconex.Close()
                Query = "Insert Into Clientes (Nombres,Nit,Direccion,Telefono) Values ('" & TxtCliente.Text & "', " & TxtNit.Text & ",'" & TxtDireccion.Text & "','" & TxtTelefono.Text & "');"
                varconex.Open()
                Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
                cmd2.ExecuteNonQuery()
                varconex.Close()
                If TxtNit.Text = "" Or TxtCliente.Text = "" Or TxtDireccion.Text = "" Or TxtTelefono.Text = "" Then
                    ToolStripButton4.Enabled = False
                Else
                    ToolStripButton4.Enabled = True
                End If

            Catch ex As Exception
                MsgBox("fallo en el ingreso del cliente", vbExclamation, "Atención      SKYNET")
            End Try
        End If
    End Sub
    Private Sub ingreso_puntos()

        Dim Query As String
        Try
            If varconex.State = ConnectionState.Open Then varconex.Close()

            Query = "update clientes Set clientes.puntos=" & Lbl_puntos.Text & " where Nit=" & TxtNit.Text & ""
            varconex.Open()
            Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
            cmd2.ExecuteNonQuery()

            varconex.Close()


        Catch ex As Exception
            MsgBox("fallo de actualización ingreso puntos", vbExclamation, "Atención      SKYNET")


        End Try

    End Sub
    Private Sub calculo_puntos()
        Dim venta_puntos As Integer
        Dim puntos_totales As Integer
        venta_puntos = Math.Truncate(Label12.Text / 1000) - TextBox3.Text
        Lbl_puntos_estaventa.Text = venta_puntos
        puntos_totales = Val(Lbl_puntos_estaventa.Text) + Val(TextBox2.Text)
        Lbl_puntos.Text = puntos_totales

    End Sub



    Sub MOSTRAR_CAMBIO()
        Dim Query As String
        Try
            If varconex.State = ConnectionState.Open Then varconex.Close()
            Query = "Update Facturas SET Id_Cliente=" & ObtenerNit(TxtNit.Text) & " WHERE Id_Fact=" & Label9.Text
            varconex.Open()
            Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
            cmd2.ExecuteNonQuery()

            varconex.Close()

        Catch ex As Exception
            MsgBox("fallo la actualizacion Id_cliente Factura", vbExclamation, "Atención      SKYNET")
        End Try
    End Sub



    Sub UpdFacturaCliente()
        Dim Query As String
        Try
            If varconex.State = ConnectionState.Open Then varconex.Close()
            Query = "Update Facturas SET Id_Cliente=" & ObtenerNit(TxtNit.Text) & " WHERE Id_Fact=" & Label9.Text
            varconex.Open()
            Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
            cmd2.ExecuteNonQuery()

            varconex.Close()

        Catch ex As Exception
            MsgBox("fallo la actualizacion Id_cliente Factura", vbExclamation, "Atención      SKYNET")
        End Try
    End Sub

    ' Click event handler for a button - designed to show how to use the
    ' SendFileToPrinter and SendBytesToPrinter functions.
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Allow the user to select a file.
        Dim ofd As New OpenFileDialog()
        If ofd.ShowDialog(Me) Then
            ' Allow the user to select a printer.
            Dim pd As New PrintDialog()
            pd.PrinterSettings = New PrinterSettings()
            If (pd.ShowDialog() = DialogResult.OK) Then
                ' Print the file to the printer.
                RawPrinterHelper.SendFileToPrinter(pd.PrinterSettings.PrinterName, ofd.FileName)
            End If
        End If
    End Sub ' Button1_Click()

    ' Click event handler for a button - designed to show how to use the
    ' SendBytesToPrinter function to send a string to the printer.
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim s As String
        Dim pd As New PrintDialog()
        Dim Impresora As New RawPrinterHelper
        pd.PrinterSettings = New PrinterSettings()
        If (pd.ShowDialog() = DialogResult.OK) Then
            WindowsApplication1.RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, Chr(27) & Chr(112) & Chr(0) & Chr(25) & Chr(250))
        End If
    End Sub ' Button2_Click()

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub

    Private Sub Label19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub


    Private Sub BtnValidarNit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnValidarNit.Click
        If TxtNit.Text = "" Then
            MsgBox("Debe Ingresar el Nit..", MsgBoxStyle.Critical, "Ingresar Nit")
            Exit Sub
        End If
        Dim Query As String = "Select Nit, Nombres, Direccion,Telefono,puntos From Clientes Where Nit LIKE " & Me.TxtNit.Text

        'Dim Query As String = "Select Nit, Nombres, Direccion,Telefono From Clientes Where Nit LIKE " & Me.TxtNit.Text
        Dim Adapter As New MySqlDataAdapter(Query, varconex)
        Dim ds As New DataSet
        Adapter.Fill(ds)
        If varconex.State = ConnectionState.Closed Then varconex.Open()
        Try
            If ds.Tables(0).Rows.Count = 0 Then
                MsgBox("Nit no existe por favor ingrese la información", MsgBoxStyle.Critical, AcceptButton)
                VariablesGoblales.ValidarNit = 0
                TxtCliente.Text = ""
                TxtDireccion.Text = ""
                TxtTelefono.Text = ""
                TxtCliente.Focus()
                BtnIngresarNit.Enabled = True
            Else
                VariablesGoblales.ValidarNit = 1
                For Each row As DataRow In ds.Tables(0).Rows
                    TxtCliente.Text = row("Nombres")
                    TxtDireccion.Text = row("Direccion")
                    TxtTelefono.Text = row("Telefono")
                    TextBox2.Text = row("puntos")
                Next row
                If TxtNit.Text = "" Or TxtCliente.Text = "" Or TxtDireccion.Text = "" Or TxtTelefono.Text = "" Then
                    ToolStripButton4.Enabled = False
                Else
                    ToolStripButton4.Enabled = True
                End If
                Adapter.Dispose()
                varconex.Close()
            End If

        Catch ex As Exception
            MsgBox("fallo consulta nit", vbExclamation, "Atención      SKYNET")
        End Try

    End Sub

    Private Sub BtnIngresarNit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIngresarNit.Click
        InsertarClientes()
        BtnIngresarNit.Enabled = False
        BtnValidarNit.Enabled = False
        TxtNit.Enabled = False
        TxtCliente.Enabled = False
        TxtDireccion.Enabled = False
        TxtTelefono.Enabled = False
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Buscarcliente2.ShowDialog()
    End Sub


    Private Sub Label22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label22.Click

    End Sub



    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress

    End Sub

    Private Sub TxtNit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNit.TextChanged

    End Sub
End Class