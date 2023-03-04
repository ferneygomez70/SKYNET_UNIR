Imports System.Diagnostics
Imports System.IO
Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System.Configuration
Public Class CIERRE_CAJA
    Dim cadena As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
    Dim varconex, conexion2, conexion, conexion3 As New MySqlConnection(cadena)
    Dim total, totald, gasto1 As Integer
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Call fechahora()
        'Call totalventas()
        'Call descuentos()
        Call insertar()
        Call actualizar_caja()
        Call actualizar_gastos()
        Call actualizar_factura()
        cajon()
        PrintDocument1.Print()
        VENTAS.Close()
        efectivo.Close()
        INICIO.Close()


    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim fnt As New Font("Times New Roman", 10, FontStyle.Regular, GraphicsUnit.Point)
        Dim ListBoxItem As String = String.Empty
        For Each LBItem As String In ListBox1.Items
            ListBoxItem = ListBoxItem & vbCrLf & LBItem
        Next
        ListBoxItem = ListBoxItem.Substring(vbCrLf.Length)
        e.Graphics.DrawString(ListBoxItem, fnt, Brushes.Black, 0, 0)
        e.HasMorePages = False
    End Sub
    Private Sub cajon()
        'Use this code if you are using COM Port
        FileOpen(1, AppDomain.CurrentDomain.BaseDirectory & "open.txt", OpenMode.Output)
        PrintLine(1, Chr(27) & Chr(112) & Chr(0) & Chr(25) & Chr(250))
        FileClose(1)
        Shell("print /d:com2 open.txt", AppWinStyle.Hide)
        'Shell("print /d:lpt1 open.txt", vbNormalFocus)
    End Sub


    Private Sub Form8_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim fechaactual As String = Date.Now.ToString("yyyy/MM/dd HH:mm:ss")
        Dim fechaactual1 As String = Date.Now.ToString("yyyy/MM/dd")
        Label5.Text = fechaactual
        Label22.Text = fechaactual1
        Me.ListBox1.Items.Clear()

        Dim query2 As String
        ' se muestra la cantidad de efectivo ingresada al momento de abrir caja
        query2 = "select id_entracaja,entrada_caja.fecha_entrada,entrada_caja.valor_entrada  FROM entrada_caja INNER JOIN usuarios ON (entrada_caja.id_usuarios = usuarios.id_usuarios) INNER JOIN pos ON (entrada_caja.id_caja = pos.id_caja)  WHERE  usuarios.id_usuarios=" & Me.Label1.Text & " AND pos.id_caja= " & Me.Label2.Text & " AND entrada_caja.activo = 1  "
        Dim cmdfecha As MySqlCommand = New MySqlCommand(query2, conexion2)
        Dim lectura_fecha As MySqlDataReader
        If Not conexion2 Is Nothing Then conexion2.Close()
        conexion2.Open()
        lectura_fecha = cmdfecha.ExecuteReader
        If lectura_fecha.Read() Then
            Me.Label3.Text = lectura_fecha.Item("fecha_entrada")
            Me.Label10.Text = FormatNumber(lectura_fecha.Item("valor_entrada"), TriState.False)
            Me.Label12.Text = lectura_fecha.Item("id_entracaja")
        End If
        Dim query As String
        Try
            query = "select SUM(facturas.total_fact) AS totalvent FROM facturas INNER JOIN usuarios ON (facturas.id_usuarios = usuarios.id_usuarios) INNER JOIN pos ON (facturas.id_caja = pos.id_caja) WHERE  usuarios.id_usuarios=" & Me.Label1.Text & " AND pos.id_caja= " & Me.Label2.Text & " AND facturas.activo=2  "
            Dim cmdtotal As MySqlCommand = New MySqlCommand(query, conexion2)
            Dim lectura_total As MySqlDataReader
            If Not conexion2 Is Nothing Then conexion2.Close()
            conexion2.Open()
            lectura_total = cmdtotal.ExecuteReader
            If lectura_total.Read() Then
                Me.Label4.Text = "$ " & FormatNumber(lectura_total.Item("totalvent"), TriState.False)
                total = FormatNumber(lectura_total.Item("totalvent"))
            End If
        Catch ex As Exception
            MsgBox(ex.Message + ex.StackTrace)
        End Try


        ''calculo de descuentos

        Try
            query = "select SUM(facturas.descuento) AS descuento FROM facturas  WHERE   facturas.activo=2  "
            Dim cmdtotald As MySqlCommand = New MySqlCommand(query, conexion2)
            Dim lectura_totald As MySqlDataReader
            If Not conexion2 Is Nothing Then conexion2.Close()
            conexion2.Open()
            lectura_totald = cmdtotald.ExecuteReader
            If lectura_totald.Read() Then
                Me.Label24.Text = "$ " & FormatNumber(lectura_totald.Item("descuento"), TriState.False)
                totald = FormatNumber(lectura_totald.Item("descuento"))
            End If
        Catch ex As Exception
            MsgBox(ex.Message + ex.StackTrace)
        End Try



        Try
            Dim devolucion As String
            devolucion = "SELECT SUM(ventas.precio) AS TOTALDEVOL FROM ventas INNER JOIN facturas ON (ventas.id_fact = facturas.id_fact) INNER JOIN pos ON (facturas.id_caja = pos.id_caja) INNER JOIN usuarios ON (facturas.id_usuarios = usuarios.id_usuarios) WHERE ventas.activo = 3 And facturas.activo = 2 and usuarios.id_usuarios=" & Me.Label1.Text & " AND pos.id_caja= " & Me.Label2.Text & ""
            Dim cmddevolucion As MySqlCommand = New MySqlCommand(devolucion, conexion2)
            Dim lectura_devolucion As MySqlDataReader

            If Not conexion2 Is Nothing Then conexion2.Close()
            conexion2.Open()
            lectura_devolucion = cmddevolucion.ExecuteReader
            If lectura_devolucion.Read() Then
                Me.Label15.Text = FormatNumber(lectura_devolucion.Item("TOTALDEVOL"), TriState.False)

            End If
        Catch ex As Exception

        End Try
        Try
            Dim devolucion1 As String
            devolucion1 = "SELECT SUM( gastos.gasto ) AS TOTALGASTO From gastos Where fecha_gasto = '" & fechaactual1 & "'and gastos.gasto_activo = 0"

            Dim cmddevolucion1 As MySqlCommand = New MySqlCommand(devolucion1, conexion3)
            Dim lectura_devolucion1 As MySqlDataReader

            If Not conexion3 Is Nothing Then conexion3.Close()
            conexion3.Open()
            lectura_devolucion1 = cmddevolucion1.ExecuteReader
            If lectura_devolucion1.Read() Then
                Me.Label21.Text = FormatNumber(lectura_devolucion1.Item("TOTALGASTO"), TriState.False)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + ex.StackTrace)
        End Try






        Dim numero1 As Integer
        Dim numero2 As Integer
        Dim numero3 As Integer
        Dim numero4 As Integer

        numero1 = total
        numero3 = Me.Label15.Text
        numero2 = Me.Label10.Text
        numero4 = Me.Label21.Text


        Me.Label11.Text = ((numero1 - numero3) + numero2) - numero4
        Me.Label18.Text = (numero1 - numero3)

        'listbox empresa
        Dim cmdempresa As New MySqlCommand("Select empresa.empresa,empresa.nit,empresa.direccion,empresa.telefono FROM empresa ", conexion)
        Dim lecturaempresa As MySqlDataReader
        'Dim ob As String
        If Not conexion Is Nothing Then conexion.Close()
        conexion.Open()
        lecturaempresa = cmdempresa.ExecuteReader

        If lecturaempresa.Read() Then

            ListBox1.Items.Add(lecturaempresa("empresa"))
            ListBox1.Items.Add(("NIT:") & Chr(9) & lecturaempresa("nit"))
        End If
        conexion.Close()
        'listbox cajero
        Dim cmdcajero As New MySqlCommand("select usuarios.nombre,pos.nomb_caja,entrada_caja.fecha_entrada,entrada_caja.valor_entrada  FROM entrada_caja INNER JOIN usuarios ON (entrada_caja.id_usuarios = usuarios.id_usuarios) INNER JOIN pos ON (entrada_caja.id_caja = pos.id_caja)  WHERE  usuarios.id_usuarios=" & Me.Label1.Text & " AND pos.id_caja= " & Me.Label2.Text & " AND entrada_caja.activo = 1 ", conexion)
        Dim lecturacajero As MySqlDataReader
        'Dim ob As String
        If Not conexion Is Nothing Then conexion.Close()
        conexion.Open()
        lecturacajero = cmdcajero.ExecuteReader

        If lecturacajero.Read() Then

            ListBox1.Items.Add(("Cajero:") & Chr(9) & lecturacajero("nombre"))
            ListBox1.Items.Add(lecturacajero("nomb_caja"))
            ListBox1.Items.Add(("fecha Entrada caja:") & Chr(9) & lecturacajero("fecha_entrada"))
            ListBox1.Items.Add(("Valor Entrada caja:") & Chr(9) & "$ " & (FormatNumber(lecturacajero("valor_entrada"), TriState.False)))
        End If
        conexion.Close()
        ListBox1.Items.Add("----------------------------------------------------------")
        ListBox1.Items.Add(("Fecha Salida Caja:") & Chr(9) & (Me.Label5.Text))
        ListBox1.Items.Add(("Total Ventas:") & Chr(9) & "$ " & (FormatNumber(total, TriState.False)))
        ListBox1.Items.Add(("Devoluciones:") & Chr(9) & "$ " & (FormatNumber(Me.Label15.Text, TriState.False)))
        ListBox1.Items.Add(("Descuentos:") & Chr(9) & "$ " & (FormatNumber(Me.Label24.Text, TriState.False)))
        ListBox1.Items.Add(("Pagos:        ") & Chr(9) & "$ " & (FormatNumber(Me.Label21.Text, TriState.False)))
        ListBox1.Items.Add(("Total Cierre:") & Chr(9) & "$ " & (FormatNumber(Me.Label18.Text, TriState.False)))
        ListBox1.Items.Add(("Total En Caja:") & Chr(9) & "$ " & (FormatNumber(Me.Label11.Text, TriState.False)))

        ListBox1.Items.Add(" No.factura  | Descuento   |")
        ListBox1.Items.Add("_____________________________________")
        Dim cmdventas As New MySqlCommand("SELECT id_fact, descuento from facturas where   facturas.activo=2 and descuento<>0 ", conexion)
        Dim lecturaventas As MySqlDataReader

        If Not conexion Is Nothing Then conexion.Close()
        conexion.Open()
        lecturaventas = cmdventas.ExecuteReader

        While lecturaventas.Read()
            Dim item1 As New ListViewItem("item1", 0)
            item1.SubItems.Add("1")
            ListBox1.Items.Add([String].Format("{0,-6}|{1,5}|", Mid(lecturaventas("id_fact"), 1, 22), lecturaventas("descuento")))


        End While

    End Sub

    '' trae los datos de los descuentos 



    Public Sub insertar()
        Dim Query As String
        Try

            Query = "insert into cierre_caja  (id_entracaja,id_usuarios,id_caja,fecha_cierre,devoluciones,total_cierre,gastos) value ('" & Me.Label12.Text & "','" & Me.Label1.Text & "','" & Me.Label2.Text & "','" & Me.Label5.Text & "','" & Me.Label15.Text & "','" & Me.Label11.Text & "', '" & Me.Label21.Text & "')"
            varconex.Open()
            Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
            cmd2.ExecuteNonQuery()




            varconex.Close()

        Catch ex As Exception
            'MsgBox(Query)
            MsgBox("Error", vbExclamation, "Atención      SKYNET")

        End Try

    End Sub
    Public Sub actualizar_caja()
        Dim update As String
        Try
            update = "update entrada_caja set activo= 0 where id_entracaja='" & Me.Label12.Text & "'"
            varconex.Open()
            Dim cmd3 As MySqlCommand = New MySqlCommand(update, varconex)
            cmd3.ExecuteNonQuery()

            varconex.Close()
        Catch ex As Exception
            MsgBox("Error", vbExclamation, "Atención      SKYNET")

        End Try
    End Sub
    Public Sub actualizar_gastos()
        Dim update As String
        Try
            update = "update gastos set gastos.gasto_activo = 1 where gastos.gasto_activo = 0"
            varconex.Open()
            Dim cmd3 As MySqlCommand = New MySqlCommand(update, varconex)
            cmd3.ExecuteNonQuery()

            varconex.Close()
        Catch ex As Exception
            MsgBox("Error", vbExclamation, "Atención      SKYNET")
        End Try
    End Sub

    Private Sub PrintPreviewDialog1_Load(sender As Object, e As EventArgs) Handles PrintPreviewDialog1.Load

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Public Sub actualizar_factura()
        Dim update2 As String
        Try
            update2 = "update facturas set activo= 0 WHERE  id_usuarios=" & Me.Label1.Text & " AND id_caja= " & Me.Label2.Text & " "

            varconex.Open()
            Dim cmd4 As MySqlCommand = New MySqlCommand(update2, varconex)
            cmd4.ExecuteNonQuery()

            varconex.Close()
        Catch ex As Exception
            MsgBox("Error", vbExclamation, "Atención      SKYNET")

        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        VENTAS.Enabled = True
        Close()
    End Sub



End Class