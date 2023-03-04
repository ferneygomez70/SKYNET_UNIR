
Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration
Imports System.Drawing.Printing
Imports System.Diagnostics
Imports System.IO

Public Class facturas


    Private ComBuffer As Byte()
    Private Delegate Sub UpdateFormDelegate()
    Private UpdateFormDelegate1 As UpdateFormDelegate
    Dim strReturn As String
    Dim strPeso As String
    Dim car As String
    Dim salir As Integer
    Private dsusuario As New DataSet
    Private dausuario As New MySqlDataAdapter
    Private cmdusuario As New MySqlCommand

    Dim distrito As New Distrito()


    Dim Xdist


    Dim cadena As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
    Dim varconex, conexion, conexion2, conexion3, conexionIns As New MySqlConnection(cadena)
    Public verdata, verSdata, comArtdata, codata, solidata, endata, sadata, candata, datostotal, datositem As New DataSet

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Btn_terminarfact.Click

        Dim DEV1, RES1, RES2 As Double
        DEV1 = TextBox10.Text
        RES2 = TextBox8.Text
        RES1 = RES2 - DEV1
        TextBox8.Text = RES1
        Label15.Text = TextBox8.Text


        For Each linea In DataGridView2.Rows

            Dim Queryw As String
            Dim inventario_Actualizado As Integer

            Dim cant1, cant2 As Integer
            Dim cant3, cant4, cant5, cant6, cant7, cant8 As String
            cant1 = linea.cells(3).value 'cant_comprada
            cant2 = linea.cells(1).value 'inventario
            inventario_Actualizado = cant1 + cant2
            cant3 = linea.cells(4).value 'precio _compra
            cant4 = linea.cells(2).value 'articulo
            cant5 = linea.cells(5).value 'precio venta
            cant6 = linea.cells(6).value 'proveedor
            cant7 = linea.cells(7).value 'total
            cant8 = linea.cells(0).value 'codigo

            Try
                If varconex.State = ConnectionState.Open Then varconex.Close()
                varconex.Open()
                Queryw = "update articulos set inventario='" & inventario_Actualizado & "', precio_compra='" & cant3 & "',proveedor='" & cant6 & "', precio_venta='" & cant5 & "' where articulos.cod_product='" & cant8 & "' "
                ListBox2.Items.Add(cant1 & " " & cant4 & " " & cant7)
                Dim cmd2 As MySqlCommand = New MySqlCommand(Queryw, varconex)
                cmd2.ExecuteNonQuery()

                varconex.Close()


            Catch ex As Exception
                MsgBox("fallo de actualización", vbExclamation, "Atención      SKYNET")


            End Try
        Next



        If CheckBox1.Checked = True Then
            GASTOS.TextBox1.Text += "FACTURA DE CREDITO POR VALOR DE:  " & TextBox8.Text
            Label15.Text = "0"

        End If

        ListBox2.Items.Add(" ")
        ListBox2.Items.Add("*********************************** ")
        ListBox2.Items.Add((" TOTAL  FACTURA : $ ") & (TextBox8.Text))
        ListBox2.Items.Add((" TOTAL  A PAGAR FACTURA : $ ") & (Label15.Text))
        ListBox2.Items.Add("*********************************** ")
        ListBox2.Items.Add((" PROVEEDOR:  ") & (Txt_proveedor.Text))
        ListBox2.Items.Add("*********************************** ")
        ListBox2.Items.Add(" FIRMA : ____________________________ ")


        PrintDocument1.Print()
        If CheckBox1.Checked = True Then
            GASTOS.TextBox2.Text += "FACTURA DE CREDITO POR VALOR DE:  " & TextBox8.Text & "  AL PROVEEDOR   " & Me.Txt_proveedor.Text & ""
            GASTOS.TextBox1.Text = Me.Label15.Text

            MessageBox.Show("factura a credito")
            GASTOS.Show()
        Else
            GASTOS.TextBox1.Text = Me.Label15.Text
            GASTOS.TextBox2.Text = Me.Txt_proveedor.Text

            GASTOS.Show()
        End If
    End Sub

    Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs) Handles TextBox10.TextChanged

    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim fnt As New Font("Courier New", 8.5, FontStyle.Bold, GraphicsUnit.Point)

        Dim ListBoxItem As String = String.Empty

        For Each LBItem As String In ListBox2.Items

            ListBoxItem = ListBoxItem & vbCrLf & LBItem
        Next
        ListBoxItem = ListBoxItem.Substring(vbCrLf.Length)
        e.Graphics.DrawString(ListBoxItem, fnt, Brushes.Black, 0, 0)
        e.HasMorePages = False

        '   

    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        INVENTARIO1.Show()

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Crear_articulos.Show()

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click

        Dim linea As DataGridViewRow
        Dim TOTAL As Double
        Dim a, b, c As Double
        For Each linea In DataGridView2.Rows
            a = linea.Cells(3).Value
            b = linea.Cells(4).Value
            c = a * b
            linea.Cells(7).Value = c
            TOTAL = TOTAL + linea.Cells(7).Value
            TextBox8.Text = TOTAL
        Next
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ingreso_mp.Show()
        Me.Hide()


    End Sub

    Private Sub TextBox13_TextChanged(sender As Object, e As EventArgs) Handles TextBox13.TextChanged

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        REPORTE_MATERIA_PRIMA.Show()
        Me.Hide()

    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles Txt_cantidad.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles bTN_INGRESARARTICULO.Click


        If Txt_cantidad.Text = "" Or Txt_cantidad.Text < 0 Then
            MessageBox.Show("Debe ingresar una catidad de producto positiva")
        Else
            Txt_total.Text = Txt_cantidad.Text * Txt_preciocompra.Text


            Txt_ingcodigo.Text = ""



            DataGridView2.Rows.Add(TextBox6.Text, TextBox13.Text, Txt_articulo.Text, Txt_cantidad.Text, Txt_preciocompra.Text, Txt_precioventa.Text, Txt_proveedor.Text, Txt_total.Text)





            Call suma()

        End If
        Txt_articulo.Text = ""
        Txt_preciocompra.Text = ""
        Txt_precioventa.Text = ""
        Txt_total.Text = ""
        Txt_ingcodigo.Text = ""
        TextBox6.Text = ""
        Txt_cantidad.Text = ""
        Txt_ingcodigo.Focus()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Btn_consultar.Click

        TextBox6.Text = DataGridView1.CurrentRow.Cells.Item(1).Value.ToString
        Txt_articulo.Text = DataGridView1.CurrentRow.Cells.Item(2).Value.ToString
        Txt_preciocompra.Text = DataGridView1.CurrentRow.Cells.Item(3).Value.ToString
        Txt_precioventa.Text = DataGridView1.CurrentRow.Cells.Item(4).Value.ToString
        TextBox13.Text = DataGridView1.CurrentRow.Cells.Item(6).Value.ToString

        Txt_proveedor.Text = DataGridView1.CurrentRow.Cells.Item(8).Value.ToString
        Txt_cantidad.Text = ""
    End Sub
    Private Sub suma()



        Dim linea As DataGridViewRow
        Dim TOTAL As Double
        For Each linea In DataGridView2.Rows

            TOTAL = TOTAL + linea.Cells(7).Value
            TextBox8.Text = TOTAL
        Next


    End Sub


    Dim fila As Integer
    Public sql, cmd As New MySqlCommand
    Private Sub facturas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim fechaactual As String = Date.Now.ToString("yyyy/MM/dd HH:mm:ss")
        Label3.Text = fechaactual

        ListBox2.Items.Add("  FACTURA DE VENTA  ")
        ListBox2.Items.Add("   ")
        ListBox2.Items.Add(("  FECHA:  ") & (Label3.Text))
        ListBox2.Items.Add("*******************************")
        ListBox2.Items.Add(" CANT.|    ARTICULO      |  TOTAL ")

        Xdist = New Distrito(Txt_articulo.Text, Txt_cantidad.Text, Txt_preciocompra.Text, Txt_total.Text)


        DataGridView2.Columns(0).Width = 80
        DataGridView2.Columns(1).Width = 80
        DataGridView2.Columns(2).Width = 300
        DataGridView2.Columns(3).Width = 80
        DataGridView2.Columns(4).Width = 80
        DataGridView2.Columns(5).Width = 80
        DataGridView2.Columns(6).Width = 80
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_ingcodigo.TextChanged
        DataGridView1.Enabled = True

        Dim strSQLusuario As String = "select articulos.id_product,articulos.cod_product,articulos.nomb_product,articulos.precio_compra,articulos.precio_venta,medida.medida,articulos.inventario,articulos.iva,articulos.proveedor from articulos INNER JOIN medida ON (articulos.id_medida = medida.id_medida) WHERE articulos.cod_product " & "like " & "'" & Txt_ingcodigo.Text & "%" & "' OR articulos.nomb_product LIKE  '%" & Txt_ingcodigo.Text & "%'"

        cmdusuario.CommandText = strSQLusuario
        cmdusuario.CommandType = CommandType.Text
        cmdusuario.Connection = varconex
        dausuario.SelectCommand = cmdusuario

        'se limpia la tabla para volver a llenar el grid 

        If DataGridView1.Rows.Count > 0 Then
            dsusuario.Tables("articulos").Clear()

        End If

        dausuario.Fill(dsusuario, "articulos")
        DataGridView1.DataSource = dsusuario.Tables("articulos")
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(1).Width = 100
        DataGridView1.Columns(2).Width = 300
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim valor As Integer
        Dim precio As Integer
        Dim nombre As String
        Dim medida As String
        Dim cant As Double
        Dim iva As Integer
        Dim precio_compra As Integer
        Dim proveedor As String


        valor = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        nombre = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        ' TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        Txt_articulo.Text = DataGridView1.CurrentRow.Cells.Item(3).Value.ToString
        precio = DataGridView1.Rows(e.RowIndex).Cells(3).Value
        Txt_precioventa.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value


        medida = DataGridView1.Rows(e.RowIndex).Cells(4).Value
        'promocion = Me.DataGridView1.Rows(e.RowIndex).Cells(5).Value
        cant = DataGridView1.Rows(e.RowIndex).Cells(6).Value
        ' valor_prom = Me.DataGridView1.Rows(e.RowIndex).Cells(7).Value
        iva = DataGridView1.Rows(e.RowIndex).Cells(8).Value
        precio_compra = DataGridView1.Rows(e.RowIndex).Cells(9).Value
        proveedor = DataGridView1.Rows(e.RowIndex).Cells(10).Value
        Label1.Text = valor
        VENTAS.Label6.Text = valor
        VENTAS.Label8.Text = precio
        VENTAS.Label7.Text = nombre
        VENTAS.Label13.Text = medida

        VENTAS.Label27.Text = cant
        VENTAS.Label31.Text = iva

        Label2.Text = VENTAS.Label5.Text


        Txt_ingcodigo.Focus()

        VENTAS.Refresh()
        Close()
    End Sub
    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown


        If e.KeyCode = Keys.Enter Then
            Dim valor As Integer
            Dim precio As Integer
            Dim nombre As String
            Dim medida As String
            Dim cant As Double
            Dim valor_prom As Double
            Dim promocion As Integer
            Dim iva As Integer
            valor = DataGridView1.CurrentRow.Cells(0).Value
            nombre = DataGridView1.CurrentRow.Cells(2).Value
            Txt_articulo.Text = DataGridView1.CurrentRow.Cells(2).Value
            precio = DataGridView1.CurrentRow.Cells(3).Value
            Txt_precioventa.Text = DataGridView1.CurrentRow.Cells(3).Value
            medida = DataGridView1.CurrentRow.Cells(4).Value
            cant = DataGridView1.CurrentRow.Cells(6).Value
            iva = DataGridView1.CurrentRow.Cells(8).Value
            Label1.Text = valor
            VENTAS.Label6.Text = valor
            VENTAS.Label8.Text = precio
            VENTAS.Label7.Text = nombre
            VENTAS.Label13.Text = medida
            VENTAS.Label27.Text = cant
            VENTAS.Label28.Text = valor_prom
            VENTAS.Label31.Text = iva
            VENTAS.Label26.Text = promocion
            VENTAS.Label27.Text = cant

            Label2.Text = VENTAS.Label5.Text


            If ((promocion = 0) And (Label2.Text >= cant)) Then
                VENTAS.Label8.Text = valor_prom
                VENTAS.Label28.Text = valor_prom
                VENTAS.Label29.Visible = True
                VENTAS.Label29.Text = "promocion"
            Else
                VENTAS.Label29.Visible = False
                VENTAS.Label26.Text = promocion
                VENTAS.Label8.Text = precio
            End If


            Txt_ingcodigo.Focus()
            'Me.DataGridView1.DataSource = Nothing
            VENTAS.Refresh()
            Close()
        End If
    End Sub
    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If (VENTAS.TextBox1.Text <> "") Then
            Txt_ingcodigo.Text = VENTAS.TextBox1.Text
        Else
            Txt_ingcodigo.Text = ""
        End If
        Txt_ingcodigo.Focus()
    End Sub


    Private Sub Form4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F10 Then
            VENTAS.LblSalir.Text = "1"
            Close()
        End If

    End Sub



End Class

Friend Class Distrito
    Private text1 As String
    Private text2 As String
    Private text3 As String
    Private text4 As String

    Public Sub New()
    End Sub

    Public Sub New(text1 As String, text2 As String, text3 As String, text4 As String)
        Me.text1 = text1
        Me.text2 = text2
        Me.text3 = text3
        Me.text4 = text4
    End Sub
End Class
