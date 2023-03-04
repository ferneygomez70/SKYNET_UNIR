Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration
Public Class BuscarProducto2
    Dim cadena As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
    Dim varconex As New MySqlConnection(cadena)
    Private dsusuario As New DataSet
    Private dausuario As New MySqlDataAdapter
    Private cmdusuario As New MySqlCommand
    Dim cmd As New MySqlCommand

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        DataGridView1.Enabled = True

        Dim strSQLusuario As String = "select articulos.id_product,articulos.cod_product,articulos.nomb_product,articulos.precio_venta,medida.medida,articulos.promocion, articulos.cant_prom, articulos.valor_prom,articulos.iva from articulos INNER JOIN medida ON (articulos.id_medida = medida.id_medida) WHERE articulos.cod_product " & "like " & "'" & TextBox1.Text & "%" & "' OR articulos.nomb_product LIKE  '%" & TextBox1.Text & "%'"

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
        DataGridView1.Columns(2).Width = 400
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
        VENTAS2.Label6.Text = valor
        VENTAS2.Label8.Text = precio
        VENTAS2.Label7.Text = nombre
        VENTAS2.Label13.Text = medida
        VENTAS2.Label26.Text = promocion
        VENTAS2.Label27.Text = cant
        VENTAS2.Label31.Text = iva

        Label2.Text = VENTAS2.Label5.Text


        If ((promocion = 0) And (Label2.Text >= cant)) Then
            VENTAS2.Label8.Text = valor_prom
            VENTAS2.Label28.Text = valor_prom
            VENTAS2.Label29.Visible = True
            VENTAS2.Label29.Text = "promocion"
        Else
            VENTAS2.TextBox2.Text = 1
            VENTAS2.Label29.Visible = False
            VENTAS2.Label8.Text = precio
        End If


        Me.TextBox1.Focus()

        VENTAS2.Refresh()
        Me.Close()
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
            VENTAS2.Label6.Text = valor
            VENTAS2.Label8.Text = precio
            VENTAS2.Label7.Text = nombre
            VENTAS2.Label13.Text = medida
            VENTAS2.Label27.Text = cant
            VENTAS2.Label28.Text = valor_prom
            VENTAS2.Label31.Text = iva
            VENTAS2.Label26.Text = promocion
            VENTAS2.Label27.Text = cant
            Label2.Text = VENTAS2.Label5.Text



            If ((promocion = 0) And (Label2.Text >= cant)) Then
                VENTAS2.Label8.Text = valor_prom
                VENTAS2.Label28.Text = valor_prom
                VENTAS2.Label29.Visible = True
                VENTAS2.Label29.Text = "promocion"
            Else
                VENTAS2.Label29.Visible = False
                VENTAS2.Label26.Text = promocion
                VENTAS2.Label8.Text = precio
            End If


            Me.TextBox1.Focus()

            VENTAS2.Refresh()
            Me.Close()
        End If
    End Sub
    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If (VENTAS2.TextBox1.Text <> "") Then
            Me.TextBox1.Text = VENTAS2.TextBox1.Text
        Else
            TextBox1.Text = ""
        End If
        Me.TextBox1.Focus()
    End Sub


    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        VENTAS2.LblSalir.Text = "1"
        Close()
    End Sub
    Private Sub Form4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F10 Then
            VENTAS2.LblSalir.Text = "1"
            Close()
        End If

    End Sub
End Class
