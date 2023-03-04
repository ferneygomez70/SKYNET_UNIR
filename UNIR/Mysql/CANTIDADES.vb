Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration
Public Class CANTIDADES
    Dim cadena As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
    Dim varconex As New MySqlConnection(cadena)
    Private dsusuario As New DataSet
    Private dausuario As New MySqlDataAdapter
    Private cmdusuario As New MySqlCommand
    Dim cmd As New MySqlCommand
    Private Sub Form11_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F10 Then

            Close()
        End If

    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

        DataGridView1.Enabled = True
        ' esta es la linea original para cantidades le quito que medida sea diferente de uno  Dim strSQLusuario As String = "select articulos.id_product,articulos.cod_product,articulos.nomb_product,articulos.precio_venta,medida.medida,articulos.promocion, articulos.cant_prom, articulos.valor_prom,articulos.iva from articulos INNER JOIN medida ON (articulos.id_medida = medida.id_medida) WHERE (articulos.cod_product " & "like " & "'" & TextBox1.Text & "%" & "'or articulos.nomb_product " & "like " & "'" & TextBox1.Text & "%" & "') and medida.id_medida <> 1"
        Dim strSQLusuario As String = "select articulos.id_product,articulos.cod_product,articulos.nomb_product,articulos.precio_venta,medida.medida,articulos.promocion, articulos.cant_prom, articulos.valor_prom,articulos.iva from articulos INNER JOIN medida ON (articulos.id_medida = medida.id_medida) WHERE (articulos.cod_product " & "like " & "'" & TextBox1.Text & "%" & "'or articulos.nomb_product " & "like " & "'" & TextBox1.Text & "%" & "')"

        cmdusuario.CommandText = strSQLusuario
        cmdusuario.CommandType = CommandType.Text
        cmdusuario.Connection = varconex
        dausuario.SelectCommand = cmdusuario

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
        Dim valor_prom As Double
        Dim promocion As Integer
        Dim iva As Integer

        valor = Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value
        nombre = Me.DataGridView1.Rows(e.RowIndex).Cells(2).Value
        precio = Me.DataGridView1.Rows(e.RowIndex).Cells(3).Value
        medida = Me.DataGridView1.Rows(e.RowIndex).Cells(4).Value
        promocion = Me.DataGridView1.Rows(e.RowIndex).Cells(5).Value
        cant = Me.DataGridView1.Rows(e.RowIndex).Cells(6).Value
        valor_prom = Me.DataGridView1.Rows(e.RowIndex).Cells(7).Value
        iva = Me.DataGridView1.Rows(e.RowIndex).Cells(8).Value

        Label1.Text = valor
        Label4.Text = nombre
        Label5.Text = precio
        'Label6.Text = iva


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

            valor = Me.DataGridView1.CurrentRow.Cells(0).Value
            nombre = Me.DataGridView1.CurrentRow.Cells(2).Value
            precio = Me.DataGridView1.CurrentRow.Cells(3).Value
            medida = Me.DataGridView1.CurrentRow.Cells(4).Value
            promocion = Me.DataGridView1.CurrentRow.Cells(5).Value
            cant = Me.DataGridView1.CurrentRow.Cells(6).Value
            valor_prom = Me.DataGridView1.CurrentRow.Cells(7).Value
            iva = Me.DataGridView1.CurrentRow.Cells(8).Value

            Label1.Text = valor
            Label4.Text = nombre
            Label5.Text = precio


        End If
    End Sub

    Private Sub Form11_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label4.Text = ""
        Label5.Text = ""
        Label6.Text = ""
        TextBox1.Text = ""
        NumericUpDown1.Text = 1
        Me.TextBox1.Focus()
    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or NumericUpDown1.Text = "" Then
            MsgBox("Ingrese producto", vbExclamation, "Atención      SKYNET")
        Else
            Dim valor As Integer
            Dim precio As Integer
            Dim nombre As String
            Dim medida As String
            Dim cant As Double
            Dim valor_prom As Double
            Dim promocion As Integer
            Dim iva As Integer

            valor = Me.DataGridView1.CurrentRow.Cells(0).Value
            nombre = Me.DataGridView1.CurrentRow.Cells(2).Value
            precio = Me.DataGridView1.CurrentRow.Cells(3).Value
            medida = Me.DataGridView1.CurrentRow.Cells(4).Value
            promocion = Me.DataGridView1.CurrentRow.Cells(5).Value
            cant = Me.DataGridView1.CurrentRow.Cells(6).Value
            valor_prom = Me.DataGridView1.CurrentRow.Cells(7).Value
            iva = Me.DataGridView1.CurrentRow.Cells(8).Value

            Label1.Text = valor
            Label4.Text = nombre
            Label5.Text = precio

            VENTAS.Label6.Text = valor
            VENTAS.Label8.Text = Label5.Text
            VENTAS.Label7.Visible = True
            VENTAS.Label7.Text = nombre
            VENTAS.Label13.Text = medida
            VENTAS.Label31.Text = iva
            VENTAS.TextBox2.Visible = True
            VENTAS.TextBox2.Text = Me.NumericUpDown1.Text
            VENTAS.Label29.Visible = False
            VENTAS.Label8.Text = precio

            If ((promocion = 0) And (NumericUpDown1.Text >= cant)) Then
                Label5.Text = valor_prom
                VENTAS.Label8.Text = valor_prom
                VENTAS.Label29.Visible = True
                VENTAS.Label29.Text = "promocion"
            End If
            Dim total, totalfinal, totaliva As Double
            If ((promocion = 0) And (NumericUpDown1.Text >= cant)) Then
                total = (NumericUpDown1.Text * Label5.Text) / cant


                totaliva = (total * iva / 100)
                totalfinal = totaliva + total
                VENTAS.Label35.Text = totaliva
                VENTAS.Label5.Visible = False
                VENTAS.Label11.Text = totalfinal

            Else
                total = (Label5.Text * NumericUpDown1.Text)
                totaliva = (total * iva / 100)
                totalfinal = totaliva + total
                VENTAS.Label35.Text = totaliva
                VENTAS.Label5.Visible = False
                VENTAS.Label11.Text = totalfinal
                'Label7.Text = Math.Round(totalfinal, 0)
            End If

            VENTAS.Refresh()
            VariablesGoblales.Saldo = 0
            VENTAS.insertar(Saldo)
            Me.Close()
        End If



    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        Close()
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NumericUpDown1.ValueChanged


    End Sub
End Class
