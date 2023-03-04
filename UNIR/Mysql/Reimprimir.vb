Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration
Imports System.Diagnostics
Imports System.IO
Public Class Reimprimir
    Dim cadena As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
    Dim varconex, conexion As New MySqlConnection(cadena)
    Private Sub Form9_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.F10 Then
            Close()

        End If
        If e.KeyCode = Keys.F5 Then
            cajon()
            PrintDocument1.Print()
            Close()
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.ListBox1.Items.Clear()

        If TextBox1.Text = "" Then
            MsgBox("Factura incorrecta", vbExclamation, "Atención               SKYNET")
            TextBox1.Focus()

        Else
            ListBox1.Items.Add("--------------------------------------------------------------------")
            Dim cmdempresa As New MySqlCommand("SELECT empresa.empresa,empresa.nit,empresa.direccion,empresa.ciudad,empresa.telefono FROM empresa ", conexion)
            Dim lecturaempresa As MySqlDataReader
            'Dim ob As String
            If Not conexion Is Nothing Then conexion.Close()
            conexion.Open()
            lecturaempresa = cmdempresa.ExecuteReader

            If lecturaempresa.Read() Then

                ListBox1.Items.Add(lecturaempresa("empresa"))
                ListBox1.Items.Add(("NIT:") & lecturaempresa("nit"))
                ListBox1.Items.Add(lecturaempresa("direccion"))
                ListBox1.Items.Add(lecturaempresa("ciudad"))
                ListBox1.Items.Add(("TELEFONO:") & lecturaempresa("telefono"))
            End If

            conexion.Close()

            ListBox1.Items.Add("_______________________________________________")
            'LISTBOX CAJA

            Dim cmdpos As New MySqlCommand("SELECT facturas.id_fact,facturas.fecha_fact,usuarios.nombre,pos.nomb_caja,nit,nombres,direccion,telefono " &
                                           "FROM facturas INNER JOIN Clientes ON facturas.id_cliente=clientes.id_cliente " &
                                                         "INNER JOIN pos ON (facturas.id_caja = pos.id_caja) " &
                                                         "INNER JOIN usuarios ON (facturas.id_usuarios = usuarios.id_usuarios) " &
                                           "WHERE facturas.id_fact = " & Me.TextBox1.Text & "", conexion)
            Dim lecturacaja As MySqlDataReader
            'Dim ob As String
            If Not conexion Is Nothing Then conexion.Close()
            conexion.Open()
            lecturacaja = cmdpos.ExecuteReader
            If lecturacaja.Read() Then
                'Dim item1 As New ListViewItem("item1", 0)
                ListBox1.Items.Add(("FACTURA N°:") & lecturacaja("id_fact"))
                ListBox1.Items.Add(("FECHA FACTURA:") & lecturacaja("fecha_fact"))
                ListBox1.Items.Add(lecturacaja("nomb_caja"))
                ListBox1.Items.Add(("ATENDIDO POR:") & lecturacaja("nombre"))
                ListBox1.Items.Add(("NIT:") & lecturacaja("Nit"))
                ListBox1.Items.Add(("NOMBRES:") & lecturacaja("Nombres"))
                ListBox1.Items.Add(("DIRECCIÓN:") & lecturacaja("Direccion"))
                ListBox1.Items.Add(("TELEFONO:") & lecturacaja("Telefono"))
            End If
            conexion.Close()

            ''
            ListBox1.Items.Add("____________________________________________________________________")
            ListBox1.Items.Add(("DESC") & Chr(9) & ("CANT") & Chr(9) & ("PESO") & Chr(9) & ("V/U") & Chr(9) & ("SUBTOT"))
            ListBox1.Items.Add("_____________________________________________________________________")
            'listbox venta
            Try
                Dim cmdventas As New MySqlCommand("SELECT articulos.nomb_product,ventas.peso,sum(ventas.cant)as cantidad,ventas.valor_unitario,sum(ventas.precio) as total,facturas.fecha_fact,facturas.total_fact,facturas.efectivo,facturas.cambio,ventas.activo FROM facturas INNER JOIN ventas ON (facturas.id_fact = ventas.id_fact) INNER JOIN articulos ON (ventas.id_product = articulos.id_product) WHERE facturas.id_fact = " & TextBox1.Text & " and ventas.activo =2  group by articulos.id_product ", conexion)
                Dim lecturaventas As MySqlDataReader
                'Dim ob As String
                If Not conexion Is Nothing Then conexion.Close()
                conexion.Open()
                lecturaventas = cmdventas.ExecuteReader
                While lecturaventas.Read()
                    Dim item1 As New ListViewItem("item1", 0)
                    item1.SubItems.Add("1")
                    ListBox1.Items.Add(Mid(lecturaventas("nomb_product"), 1, 5) & Chr(9) & lecturaventas("cantidad") & Chr(9) & lecturaventas("peso") & Chr(9) & lecturaventas("valor_unitario") & Chr(9) & lecturaventas("total"))
                End While

                ListBox1.Items.Add("______________________________________________________________________")
                ListBox1.Items.Add(("TOTAL: $") & lecturaventas("total_fact"))
                'ListBox1.Items.Add(("EFECTIVO: $") & lecturaventas("efectivo"))
                'ListBox1.Items.Add(("CAMBIO: $") & lecturaventas("cambio"))
                conexion.Close()



                Dim cmddevol As New MySqlCommand("SELECT SUM(ventas.precio) AS TOTALDEVOL FROM ventas INNER JOIN facturas ON (ventas.id_fact = facturas.id_fact) WHERE VENTAS.ACTIVO = 3 And facturas.id_fact=" & TextBox1.Text & "", conexion)
                Dim lecturadelvol As MySqlDataReader
                'Dim ob As String
                If Not conexion Is Nothing Then conexion.Close()
                conexion.Open()
                lecturadelvol = cmddevol.ExecuteReader

                If lecturadelvol.Read() Then
                    ListBox1.Items.Add(("DEVOLUCIONES: $") & lecturadelvol("TOTALDEVOL"))
                End If
                conexion.Close()

                Dim cmdtotalfinal As New MySqlCommand("SELECT SUM(ventas.precio) AS TOTALDEVOL,facturas.total_fact,( facturas.total_fact-SUM(ventas.precio)) as resta FROM ventas INNER JOIN facturas ON (ventas.id_fact = facturas.id_fact) WHERE VENTAS.ACTIVO = 3 AND  facturas.id_fact = " & TextBox1.Text & "  GROUP by facturas.id_fact", conexion)
                Dim lecturatotalfinal As MySqlDataReader
                'Dim ob As String
                If Not conexion Is Nothing Then conexion.Close()
                conexion.Open()
                lecturatotalfinal = cmdtotalfinal.ExecuteReader

                If lecturatotalfinal.Read() Then
                    ListBox1.Items.Add(("TOTAL FACTURA: $") & lecturatotalfinal("resta"))
                End If
                conexion.Close()
            Catch ex As Exception
                MsgBox("N° Factura no Existe", vbExclamation, "Atención               SKYNET")
                TextBox1.Text = ""
                TextBox1.Focus()
            End Try






            ListBox1.Items.Add("_____________________________________________________________________")
            ListBox1.Items.Add("COPIA DE FACTURA")
            'LISTBOX usuario

            Dim cmdusuario As New MySqlCommand("SELECT nombre FROM usuarios where id_usuarios= " & Me.Label2.Text & "", conexion)
            Dim lecturausuario As MySqlDataReader
            'Dim ob As String
            If Not conexion Is Nothing Then conexion.Close()
            conexion.Open()
            lecturausuario = cmdusuario.ExecuteReader

            If lecturausuario.Read() Then

                ListBox1.Items.Add(("IMPRESA POR:") & lecturausuario("nombre"))

            End If
            ListBox1.Items.Add(("FECHA IMPRESION:") & (Me.Label3.Text))
            conexion.Close()
            ListBox1.Items.Add("GRACIAS POR SU COMPRA")
            ToolStripButton4.Enabled = True
        End If

    End Sub

    Private Sub Form9_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim fechaactual As String = Date.Now.ToString()
        Label3.Text = fechaactual
        ToolStripButton4.Enabled = False
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

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        cajon()
        PrintDocument1.Print()
        Close()
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        Close()
    End Sub
    Private Sub cajon()
        'Use this code if you are using COM Port
        FileOpen(1, AppDomain.CurrentDomain.BaseDirectory & "open.txt", OpenMode.Output)
        PrintLine(1, Chr(27) & Chr(112) & Chr(0) & Chr(25) & Chr(250))
        FileClose(1)
        Shell("print /d:com2 open.txt", AppWinStyle.Hide)
        'Shell("print /d:lpt1 open.txt", vbNormalFocus)
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub
End Class