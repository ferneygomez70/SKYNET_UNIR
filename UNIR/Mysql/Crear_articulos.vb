

Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration
Imports System.Diagnostics
Imports System.IO
Imports System.Drawing.Printing
Imports System.Runtime.InteropServices
Public Class Crear_articulos
    Dim cadena As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
    Dim varconex, conexion As New MySqlConnection(cadena)
    Dim RawPrinterHelper As Object
    Dim strCurrency As String = ""
    Dim acceptableKey As Boolean = False
    Private _titulo As Object
    Dim f_efectivo As String

    Private Sub Crear_articulos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Txt_activo_TextChanged(sender As Object, e As EventArgs) Handles Txt_activo.TextChanged

    End Sub

    Private Sub Txt_cantpromocion_TextChanged(sender As Object, e As EventArgs) Handles Txt_cantpromocion.TextChanged

    End Sub

    Private Sub Txt_categoria_TextChanged(sender As Object, e As EventArgs) Handles Txt_categoria.TextChanged

    End Sub

    Private Sub Txt_medida_TextChanged(sender As Object, e As EventArgs) Handles Txt_medida.TextChanged

    End Sub

    Private Sub Txt_familia_TextChanged(sender As Object, e As EventArgs) Handles Txt_familia.TextChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles Txt_valorprom.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Dim Query As String
        Try
            If varconex.State = ConnectionState.Open Then varconex.Close()
            Query = "Insert Into articulos (id_categoria,iva,familia,cod_product,nomb_product,id_medida,precio_venta,promocion,cant_prom,valor_prom,inventario,activo,precio_compra,PROVEEDOR) Values ('" & Txt_categoria.Text & "', " & Txt_iva.Text & ",'" & Txt_familia.Text & "','" & Txt_codigo.Text & "','" & txt_articulo.Text & "','" & Txt_medida.Text & "','" & Txt_precioventa.Text & "','" & Txt_promocion.Text & "','" & Txt_cantpromocion.Text & "','" & Txt_valorprom.Text & "','" & Txt_cantidad.Text & "','" & Txt_activo.Text & "','" & Txt_preciocompra.Text & "','" & Txt_proveedor.Text & "');"
            varconex.Open()
            Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
            cmd2.ExecuteNonQuery()
            varconex.Close()

            MessageBox.Show("producto creado correctamente")
        Catch ex As Exception
            MsgBox("fallo en el ingreso del articulo", vbExclamation, "Atención      SKYNET")
        End Try
        'Txt_activo.Text = ""
        txt_articulo.Text = ""
        Txt_cantidad.Text = ""
        'Txt_cantpromocion.Text = ""
        Txt_codigo.Text = ""
        Txt_preciocompra.Text = ""
        Txt_precioventa.Text = ""
        Txt_proveedor.Text = ""





    End Sub

End Class