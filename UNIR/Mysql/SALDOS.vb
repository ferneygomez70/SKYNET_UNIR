Imports System.Diagnostics
Imports System.IO
Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System.Configuration
Public Class SALDOS
    Dim cadena As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
    Dim varconex, conexion2, conexion As New MySqlConnection(cadena)
    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        Close()
    End Sub
    Private Sub Form12_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.F10 Then
            Close()

        End If

    End Sub



    Private Sub Form12_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Label5.Text = 1
        MaskedTextBox1.Text = ""
        Dim query2 As String
        query2 = "select articulos.id_product,articulos.iva,articulos.cod_product,articulos.nomb_product,articulos.precio_venta,medida.id_medida,medida.medida,articulos.promocion,articulos.cant_prom,articulos.valor_prom from articulos INNER JOIN medida ON (articulos.id_medida = medida.id_medida) WHERE articulos.cod_product= 'S01'"
        Dim cmdfecha As MySqlCommand = New MySqlCommand(query2, conexion2)
        Dim lectura_fecha As MySqlDataReader
        If Not conexion2 Is Nothing Then conexion2.Close()
        conexion2.Open()
        lectura_fecha = cmdfecha.ExecuteReader
        If lectura_fecha.Read() Then
            Me.Label1.Text = lectura_fecha.Item("nomb_product")
            Me.Label2.Text = lectura_fecha.Item("id_product")
            Me.Label3.Text = lectura_fecha.Item("medida")

        End If



    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim total As Double
        If MaskedTextBox1.Text = "" Then
            MsgBox("Ingrese el valor del saldo", vbExclamation, "Atención      SKYNET")
        Else

            total = MaskedTextBox1.Text * Label5.Text
            VENTAS.Label11.Text = total
            VENTAS.Label6.Text = Label2.Text
            VENTAS.Label7.Text = Label1.Text
            VENTAS.Label13.Text = Label3.Text
            VENTAS.Label8.Text = MaskedTextBox1.Text
            VENTAS.Label29.Visible = False

            VENTAS.TextBox2.Text = Label5.Text

            'Permite agregar saldo
            VariablesGoblales.Saldo = 1
            VENTAS.Refresh()
            VENTAS.insertar(Saldo)
            Me.Close()
        End If
    End Sub

    Private Sub ToolStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub MaskedTextBox1_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles MaskedTextBox1.MaskInputRejected

    End Sub

    Private Sub Label49_Click(sender As System.Object, e As System.EventArgs) 

    End Sub
End Class