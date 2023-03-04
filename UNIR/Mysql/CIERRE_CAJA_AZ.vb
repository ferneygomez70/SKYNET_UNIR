Imports System.Diagnostics
Imports System.IO
Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System.Configuration
Public Class CIERRE_CAJA_AZ
    Dim cadena As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
    Dim varconex, conexion2, conexion As New MySqlConnection(cadena)
    Private Sub Form14_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ListBox1.Items.Clear()
        Dim query2 As String
        query2 = "SELECT cierre_caja.id_salida,pos.id_caja,pos.nomb_caja,usuarios.id_usuarios,usuarios.nombre,DATE_FORMAT(entrada_caja.fecha_entrada,'%Y-%m-%d') as fechaentrada,entrada_caja.valor_entrada,cierre_caja.devoluciones,DATE_FORMAT(cierre_caja.fecha_cierre,'%Y-%m-%d') as fechacierre,cierre_caja.total_cierre FROM cierre_caja INNER JOIN entrada_caja ON (cierre_caja.id_entracaja = entrada_caja.id_entracaja) INNER JOIN usuarios ON (cierre_caja.id_usuarios = usuarios.id_usuarios) INNER JOIN pos ON (cierre_caja.id_caja = pos.id_caja) WHERE cierre_caja.id_salida = " & Me.Label1.Text & ""
        Dim cmddatos As MySqlCommand = New MySqlCommand(query2, conexion2)
        Dim lectura_datos As MySqlDataReader
        If Not conexion2 Is Nothing Then conexion2.Close()
        conexion2.Open()
        lectura_datos = cmddatos.ExecuteReader
        If lectura_datos.Read() Then
            Me.Label3.Text = lectura_datos.Item("fechaentrada")
            Me.Label10.Text = FormatNumber(lectura_datos.Item("valor_entrada"), TriState.False)
            Me.Label2.Text = lectura_datos.Item("id_caja")
            Me.Label12.Text = lectura_datos.Item("id_usuarios")
            Me.Label5.Text = lectura_datos.Item("fechacierre")
            Me.Label15.Text = lectura_datos.Item("devoluciones")
            Me.Label18.Text = lectura_datos.Item("total_cierre")
        End If
        'listbox totalventas
        Dim query As String
        query = "select SUM(facturas.total_fact) AS totalvent FROM facturas INNER JOIN usuarios ON (facturas.id_usuarios = usuarios.id_usuarios) INNER JOIN pos ON (facturas.id_caja = pos.id_caja) WHERE  usuarios.id_usuarios=" & Me.Label12.Text & " AND pos.id_caja= " & Me.Label2.Text & " AND facturas.fecha_fact BETWEEN ' " & Label3.Text & " 00:00:00'  AND ' " & Label5.Text & " 23:59:00' "
        Dim cmdtotal As MySqlCommand = New MySqlCommand(query, conexion2)
        Dim lectura_total As MySqlDataReader
        If Not conexion2 Is Nothing Then conexion2.Close()
        conexion2.Open()
        lectura_total = cmdtotal.ExecuteReader
        If lectura_total.Read() Then
            Me.Label4.Text = lectura_total.Item("totalvent")
        End If
        'listbox empresa
        Dim cmdempresa As New MySqlCommand("SELECT empresa.empresa,empresa.nit,empresa.direccion,empresa.telefono FROM empresa ", conexion)
        Dim lecturaempresa As MySqlDataReader
        'Dim ob As String
        If Not conexion Is Nothing Then conexion.Close()
        conexion.Open()
        lecturaempresa = cmdempresa.ExecuteReader
        ListBox1.Items.Add("----------------------------------------------------------")
        If lecturaempresa.Read() Then

            ListBox1.Items.Add(lecturaempresa("empresa"))
            ListBox1.Items.Add(("NIT:") & Chr(9) & lecturaempresa("nit"))
        End If
        conexion.Close()
        Dim numero1 As Integer
        Dim numero2 As Integer
        Dim numero3 As Integer

        numero1 = Me.Label4.Text
        numero3 = Me.Label15.Text
        numero2 = Me.Label10.Text


        Me.Label11.Text = (numero1 - numero3) + numero2
        Me.Label18.Text = (numero1 - numero3)
        'listbox a-z
        Dim cmdaz As New MySqlCommand("SELECT cierre_caja.id_salida,pos.nomb_caja,usuarios.nombre,entrada_caja.fecha_entrada,entrada_caja.valor_entrada,cierre_caja.devoluciones,cierre_caja.fecha_cierre,cierre_caja.total_cierre FROM cierre_caja INNER JOIN entrada_caja ON (cierre_caja.id_entracaja = entrada_caja.id_entracaja) INNER JOIN usuarios ON (cierre_caja.id_usuarios = usuarios.id_usuarios) INNER JOIN pos ON (cierre_caja.id_caja = pos.id_caja) WHERE cierre_caja.id_salida = " & Me.Label1.Text & "", conexion)
        Dim lecturaz As MySqlDataReader
        'Dim ob As String
        If Not conexion Is Nothing Then conexion.Close()
        conexion.Open()
        lecturaz = cmdaz.ExecuteReader
        ListBox1.Items.Add("----------------------------------------------------------")
        If lecturaz.Read() Then

            ListBox1.Items.Add(("CAJA:") & Chr(9) & lecturaz("nomb_caja"))
            ListBox1.Items.Add(("CAJERO:") & Chr(9) & lecturaz("nombre"))
            ListBox1.Items.Add("----------------------------------------------------------")
            ListBox1.Items.Add(("FECHA ENTRADA:") & Chr(9) & lecturaz("fecha_entrada"))
            ListBox1.Items.Add(("VALOR ENTRADA:") & Chr(9) & "$ " & (FormatNumber(lecturaz("valor_entrada"), TriState.False)))
            ListBox1.Items.Add(("TOTAL VENTAS:") & Chr(9) & Me.Label4.Text)
            ListBox1.Items.Add(("DEVOLUCIONES:") & Chr(9) & "$ " & (FormatNumber(lecturaz("devoluciones"), TriState.False)))
            ListBox1.Items.Add(("FECHA CIERRE:") & Chr(9) & lecturaz("fecha_cierre"))
            ListBox1.Items.Add(("TOTAL CIERRE:") & Chr(9) & "$ " & (FormatNumber(Me.Label18.Text, TriState.False)))
            ListBox1.Items.Add(("TOTAL EN CAJA:") & Chr(9) & "$ " & (FormatNumber(Me.Label11.Text, TriState.False)))

        End If
        ListBox1.Items.Add("----------------------------------------------------------")
        conexion.Close()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Close()
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

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        cajon()
        PrintDocument1.Print()
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
End Class