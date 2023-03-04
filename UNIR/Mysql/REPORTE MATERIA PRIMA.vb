

Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration
Imports System.Drawing.Printing
Imports System.Diagnostics
Imports System.IO
Public Class REPORTE_MATERIA_PRIMA
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DataGridView1.Enabled = True

        Dim strSQLusuario1 As String = "select *FROM materia_prima"
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
        ' DataGridView1.Columns(3).Width = 100
    End Sub
End Class