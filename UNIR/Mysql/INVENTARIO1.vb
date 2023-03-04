
Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration
Imports System.Drawing.Printing
Imports System.Diagnostics
Imports System.IO

Public Class INVENTARIO1

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
    Dim distrito As New Distrito()


    Dim Xdist
    Dim cadena As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
    Dim varconex, conexion, conexion2, conexion3, conexionIns As New MySqlConnection(cadena)

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DataGridView2.Enabled = True

        Dim strSQLusuario As String = "select nomb_product, precio_venta, inventario from articulos where inventario > 0 "
        cmdusuario.CommandText = strSQLusuario
        cmdusuario.CommandType = CommandType.Text
        cmdusuario.Connection = varconex
        dausuario.SelectCommand = cmdusuario

        'se limpia la tabla para volver a llenar el grid 

        If DataGridView2.Rows.Count > 0 Then
            dsusuario.Tables("articulos").Clear()

        End If

        dausuario.Fill(dsusuario, "articulos")
        DataGridView2.DataSource = dsusuario.Tables("articulos")
        DataGridView2.Columns(0).Width = 100
        DataGridView2.Columns(1).Width = 100
        DataGridView2.Columns(2).Width = 100
        Dim linea2 As DataGridViewRow
        Dim cantidad As Double
        Dim precio As Double
        Dim total As Double
        For Each linea2 In DataGridView2.Rows

            cantidad = linea2.Cells(2).Value

            precio = linea2.Cells(1).Value
            total = total + (precio * cantidad)
            Label8.Text = total
        Next
        Label5.Text = Label8.Text
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DataGridView1.Enabled = True

        Dim strSQLusuario1 As String = "select nomb_product, precio_compra, inventario from articulos where inventario > 0 and precio_compra >0"
        cmdusuario1.CommandText = strSQLusuario1
        cmdusuario1.CommandType = CommandType.Text
        cmdusuario1.Connection = varconex
        dausuario1.SelectCommand = cmdusuario1

        'se limpia la tabla para volver a llenar el grid 

        If DataGridView1.Rows.Count > 0 Then
            dsusuario1.Tables("articulos").Clear()

        End If

        dausuario1.Fill(dsusuario1, "articulos")
        DataGridView1.DataSource = dsusuario1.Tables("articulos")
        DataGridView1.Columns(0).Width = 100
        DataGridView1.Columns(1).Width = 100
        DataGridView1.Columns(2).Width = 100
        Dim linea As DataGridViewRow
        Dim cantidad As Double
        Dim precio As Double
        Dim total As Double
        For Each linea In DataGridView1.Rows

            cantidad = linea.Cells(2).Value

            precio = linea.Cells(1).Value
            total = total + (precio * cantidad)
            Label7.Text = total
        Next
        Label3.Text = Label7.Text
    End Sub

    Public verdata, verSdata, comArtdata, codata, solidata, endata, sadata, candata, datostotal, datositem As New DataSet

    Private Sub INVENTARIO1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class