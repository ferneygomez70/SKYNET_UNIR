
Imports System.Runtime.InteropServices
Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration
Imports System.Drawing.Printing
Imports System.Diagnostics
Imports System.IO
Public Class CREDITOS
    Dim RawPrinterHelper As Object
    Dim strCurrency As String = ""
    Dim acceptableKey As Boolean = False
    Private ComBuffer As Byte()
    Private Delegate Sub UpdateFormDelegate()
    Private UpdateFormDelegate1 As UpdateFormDelegate
    Dim strReturn As String
    Dim strPeso As String
    Dim car As String
    Dim salir As Integer
    Private dsusuario As New DataSet
    Private dausuario As New MySqlDataAdapter
    Private dsusuario1 As New DataSet
    Private dausuario1 As New MySqlDataAdapter
    Private cmdusuario As New MySqlCommand
    Private cmdusuario1 As New MySqlCommand
    '' GRID 2
    Private dsusuario2 As New DataSet
    Private dausuario2 As New MySqlDataAdapter
    Private dsusuario12 As New DataSet
    Private dausuario12 As New MySqlDataAdapter
    Private cmdusuario2 As New MySqlCommand
    Private cmdusuario12 As New MySqlCommand
    Dim distrito As New Distrito()


    Dim Xdist
    Dim cadena As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
    Dim varconex, conexion, conexion2, conexion3, conexionIns As New MySqlConnection(cadena)

    Private Sub CREDITOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim hora_ingreso As String = Date.Now.ToString("yyyy/MM/dd HH:mm:ss")
        TextBox4.Text = hora_ingreso
        dsusuario.Reset()
        dsusuario1.Reset()
        dsusuario12.Reset()
        DataGridView1.DataSource = dsusuario1
        DataGridView2.DataSource = dsusuario12

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""

        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""

        Me.Hide()

        VENTAS.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Then
            MessageBox.Show("DEBE INGRESAR EL NIT DEL CLIENTE")
            Exit Sub
        End If
        InsertarABONO()
        MOSTRAR_CAMBIO()
        UpdFacturaCliente()

        Call MostrarFactura()
        Dim valor As Integer
        valor = MsgBox("Desea Imprimir la Factura?", vbYesNo, "Factura")


        If valor = 6 Then
            PrintDocument1.Print()
        Else
            cajon()
        End If
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""

        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""

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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        dsusuario.Reset()
        dsusuario1.Reset()
        dsusuario12.Reset()

        DataGridView1.Enabled = True
        DataGridView2.Enabled = True
        Dim strSQLusuario1 As String = "SELECT clientes.Nombres, clientes.Nit, facturas.total_fact_credito, facturas.cancelada, facturas.estado, facturas.fecha_fact, facturas.id_fact, ventas.id_product, articulos.nomb_product, ventas.precio FROM clientes INNER JOIN facturas ON clientes.id_Cliente = facturas.id_Cliente AND clientes.Nit =" & TextBox1.Text & " AND facturas.estado =1 INNER JOIN ventas ON ventas.id_fact = facturas.id_fact INNER JOIN articulos ON articulos.id_product = ventas.id_product and facturas.credito=1 ORDER BY id_fact desc"

        cmdusuario1.CommandText = strSQLusuario1
        cmdusuario1.CommandType = CommandType.Text
        cmdusuario1.Connection = varconex
        dausuario1.SelectCommand = cmdusuario1

        'se limpia la tabla para volver a llenar el grid 


        dausuario1.Fill(dsusuario1, "materia_prima")
        DataGridView1.DataSource = dsusuario1.Tables("materia_prima")
        DataGridView1.Columns(0).Width = 100
        DataGridView1.Columns(1).Width = 200
        DataGridView1.Columns(2).Width = 200
        DataGridView1.Columns(4).Visible = False
        DataGridView1.Columns(7).Visible = False
        ' DataGridView1.Columns(3).Width = 100

        ''     LLAMADO A GRID DOS DE ABONOS

        Dim strSQLusuario12 As String = "SELECT * FROM abonos WHERE abonos.Nit =" & TextBox1.Text & " ORDER BY id_abonos desc"

        cmdusuario12.CommandText = strSQLusuario12
        cmdusuario12.CommandType = CommandType.Text
        cmdusuario12.Connection = varconex
        dausuario12.SelectCommand = cmdusuario12

        'se limpia la tabla para volver a llenar el grid 


        dausuario12.Fill(dsusuario12, "materia_prima2")
        DataGridView2.DataSource = dsusuario12.Tables("materia_prima2")
        DataGridView2.Columns(0).Width = 100
        DataGridView2.Columns(1).Width = 200
        DataGridView2.Columns(2).Width = 200
        DataGridView1.Columns(3).Width = 100
        suma()
        sumaabono()
        TextBox5.Text = Val(TextBox2.Text) - Val(TextBox3.Text)
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub suma()



        Dim linea As DataGridViewRow
        Dim TOTAL As Double
        For Each linea In DataGridView1.Rows

            TOTAL = TOTAL + linea.Cells(9).Value
            TextBox2.Text = TOTAL
        Next


    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub


    Sub MostrarFactura()
        Dim fechaactual As String = Date.Now.ToString("yyyy/MM/dd HH:mm:ss")

        Dim cambio As Long

        cambio = (TextBox5.Text - TextBox6.Text)

        Me.Label11.Text = cambio

        'Label8.Text = fechaactual

        Dim cmdempresa As New MySqlCommand("SELECT empresa.empresa,empresa.nit,empresa.direccion,empresa.ciudad,empresa.telefono,empresa.regimen FROM empresa ", conexion)
        Dim lecturaempresa As MySqlDataReader
        If Not conexion Is Nothing Then conexion.Close()
        conexion.Open()
        lecturaempresa = cmdempresa.ExecuteReader

        If lecturaempresa.Read() Then

            ListBox1.Items.Add(lecturaempresa("empresa"))
            ListBox1.Items.Add(("NIT:") & lecturaempresa("nit"))
            ListBox1.Items.Add(("REGIMEN:") & lecturaempresa("regimen"))

        End If
        ListBox1.Items.Add("*************************")
        conexion.Close()
        ' Query = "Insert Into abonos (Nit,abono,fecha_Abono,id_fact) Values ('" & TextBox1.Text & "', '" & TextBox6.Text & "','" & TextBox4.Text & "','" & TextBox7.Text & "' );"

        ListBox1.Items.Add(("ABONO DE VENTA "))
        ' ListBox1.Items.Add(Me.Label8.Text)
        ListBox1.Items.Add("<<<<<<<<<<<<<<>>>>>>>>>>>>")
        'ListBox1.Items.Add(("CLIENTE: ") & (Me.TxtCliente.Text))
        ListBox1.Items.Add(("NIT: ") & (Me.TextBox1.Text))
        ListBox1.Items.Add(("ABON0: ") & (Me.TextBox6.Text))
        ListBox1.Items.Add(("SALDO: ") & (Me.Label11.Text))
        ListBox1.Items.Add(("FECHA ABONO: ") & (Me.TextBox4.Text))
        ListBox1.Items.Add(("ABONO A FACTURA: ") & (Me.TextBox7.Text))
        'ListBox1.Items.Add(("PUNTOS ACUMULADOS: ") & (Me.Lbl_puntos.Text))
        ListBox1.Items.Add("<<<<<<<<<<<<<<>>>>>>>>>>>>")

        'Li 'stBox1.Items.Add("MED|  ARTICULO   |PRECIO|CANT|SUBT.")
        ' ListBox1.Items.Add("_____________________________________")
        'ES PARA FACTURA DE IMPRESORA DAÑADA  Dim cmdventas As New MySqlCommand("SELECT ventas.id_venta, articulos.nomb_product,ventas.valor_unitario,(ventas.peso+''+ventas.cant) as cant,ventas.precio FROM ventas INNER JOIN usuarios ON (ventas.id_usuarios = usuarios.id_usuarios) INNER JOIN pos ON (ventas.id_caja = pos.id_caja) INNER JOIN articulos ON (ventas.id_product = articulos.id_product) INNER JOIN medida ON (articulos.id_medida = medida.id_medida) WHERE  usuarios.id_usuarios=" & Me.Label3.Text & " AND pos.id_caja= " & Me.Label4.Text & " AND Id_fact=" & Label9.Text & " order by articulos.nomb_product ", conexion)
        ' Dim cmdventas As New MySqlCommand("SELECT ventas.id_venta, articulos.nomb_product,ventas.valor_unitario,medida.medida,(ventas.peso+''+ventas.cant) as cant,ventas.precio FROM ventas INNER JOIN usuarios ON (ventas.id_usuarios = usuarios.id_usuarios) INNER JOIN pos ON (ventas.id_caja = pos.id_caja) INNER JOIN articulos ON (ventas.id_product = articulos.id_product) INNER JOIN medida ON (articulos.id_medida = medida.id_medida) WHERE  usuarios.id_usuarios=" & Me.Label3.Text & " AND pos.id_caja= " & Me.Label4.Text & " AND Id_fact=" & Label9.Text & " order by articulos.nomb_product ", conexion)
        ' Dim lecturaventas As MySqlDataReader
        ' Dim BASE As Decimal
        ' If Not conexion Is Nothing Then conexion.Close()
        'conexion.Open()
        'lecturaventas = cmdventas.ExecuteReader

        ' While lecturaventas.Read()
        'Dim item1 As New ListViewItem("item1", 0)
        'item1.SubItems.Add("1")
        'ListBox1.Items.Add([String].Format("{0,-4}|{1,-12}|{2,-6}|{3,-4}|{4,5}", lecturaventas("medida"), Mid(lecturaventas("nomb_product"), 1, 12), lecturaventas("valor_unitario"), lecturaventas("cant"), lecturaventas("precio")))


        'End While
        'ListBox1.Items.Add("------------------------------")
        'julio
        'conexion.Close()

        ' cambiar como se calcula el iva
        '
        '
        '< 
        '
        '
        '
        '


    End Sub

    Private Sub sumaabono()



        Dim linea As DataGridViewRow
        Dim TOTAL As Double
        For Each linea In DataGridView2.Rows

            If linea.Cells(2).Value = "" Then
                TOTAL = TOTAL + 0
                TextBox3.Text = TOTAL
            Else
                TOTAL = TOTAL + linea.Cells(2).Value
                TextBox3.Text = TOTAL
            End If

        Next


    End Sub


    ' INSERTAR ABONO

    Sub InsertarABONO()

        Dim Query As String
        Try
            If varconex.State = ConnectionState.Open Then varconex.Close()
            Query = "Insert Into abonos (Nit,abono,fecha_Abono,id_fact) Values ('" & TextBox1.Text & "', '" & TextBox6.Text & "','" & TextBox4.Text & "','" & TextBox7.Text & "' );"
            varconex.Open()
            Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
            cmd2.ExecuteNonQuery()
            varconex.Close()
            If TextBox1.Text = "" Or TextBox4.Text = "" Or TextBox6.Text = "" Then
                MessageBox.Show(" DEBE INGRESAR LOS DATOS COMPLETOS")

            End If

        Catch ex As Exception
            MsgBox("fallo en el ingreso del abono", vbExclamation, "Atención      SKYNET")
        End Try
        MsgBox(" Se ha realizado el abono", vbExclamation, "Atención      SKYNET")
        Me.Hide()
        VENTAS.Show()

    End Sub



    Sub MOSTRAR_CAMBIO()
        Dim Query As String

        If CheckBox1.Checked = True Then
            Try
                If varconex.State = ConnectionState.Open Then varconex.Close()
                Query = "Update Facturas SET cancelada= '" & Label9.Text & "' WHERE id_fact='" & TextBox7.Text & "'"
                varconex.Open()
                Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
                cmd2.ExecuteNonQuery()

                varconex.Close()

            Catch ex As Exception
                MsgBox("fallo la actualizacion  DEL ABONO", vbExclamation, "Atención      SKYNET")
            End Try
        Else
            Try
                If varconex.State = ConnectionState.Open Then varconex.Close()
                Query = "Update Facturas SET cancelada= '" & Label8.Text & "' WHERE id_fact='" & TextBox7.Text & "'"
                varconex.Open()
                Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
                cmd2.ExecuteNonQuery()

                varconex.Close()

            Catch ex As Exception
                MsgBox("fallo la actualizacion  DEL ABONO", vbExclamation, "Atención      SKYNET")
            End Try
        End If

        Me.Hide()
        VENTAS.Show()
    End Sub


    Sub UpdFacturaCliente()
        Dim Query As String
        Try
            If varconex.State = ConnectionState.Open Then varconex.Close()
            Query = "Update Facturas SET total_fact='" & TextBox6.Text & "', activo=2 WHERE id_fact='" & TextBox7.Text & "' "
            varconex.Open()
            Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
            cmd2.ExecuteNonQuery()

            varconex.Close()

        Catch ex As Exception
            MsgBox("fallo la actualizacion Id_cliente Factura", vbExclamation, "Atención      SKYNET")
        End Try
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

End Class