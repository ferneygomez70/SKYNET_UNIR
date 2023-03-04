Imports MySql
Imports MySql.Data
Imports System.Configuration
Imports MySql.Data.MySqlClient
Imports System.Diagnostics
Imports System.IO

Public Class ingreso_mp
    Private dsusuario As New DataSet
    Private dausuario As New MySqlDataAdapter
    Private cmdusuario As New MySqlCommand

    Dim cadena As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
    Dim varconex, conexion, conexion2, conexion3, conexionIns As New MySqlConnection(cadena)

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim A As Integer
        Dim B As Integer
        Dim C As String
        A = Val(TextBox2.Text)
        B = Val(TextBox3.Text)
        C = A + B

        Dim Queryw As String
        Try
            If varconex.State = ConnectionState.Open Then varconex.Close()
            varconex.Open()
            Queryw = "update materia_prima set cantidad='" & C & "', materia_prima.costo = '" & TextBox4.Text & "' where materia_prima.id_mp='" & Txt_codigo.Text & "' "

            Dim cmd2 As MySqlCommand = New MySqlCommand(Queryw, varconex)
            cmd2.ExecuteNonQuery()

            varconex.Close()

            MessageBox.Show("*** LA CANTIDAD HA SIDO INGRESADA ****  ")
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            Txt_buscar.Text = ""
            Txt_codigo.Text = ""
            DataGridView1.Refresh()
            DataGridView1.ClearSelection()

        Catch ex As Exception
            MsgBox("fallo de actualización de materia prima", vbExclamation, "Atención      SKYNET")


        End Try

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles Txt_buscar.TextChanged

        Dim sql As String = "select materia_prima.id_mp,materia_prima.ingrediente,materia_prima.cantidad from materia_prima where materia_prima.ingrediente  " & "like " & "'" & Txt_buscar.Text & "%" & "' "
        cmdusuario.CommandText = sql
        cmdusuario.CommandType = CommandType.Text
        cmdusuario.Connection = varconex
        dausuario.SelectCommand = cmdusuario


        If DataGridView1.Rows.Count > 0 Then
            dsusuario.Tables("materia_prima").Clear()

        End If

        dausuario.Fill(dsusuario, "materia_prima")
        DataGridView1.DataSource = dsusuario.Tables("materia_prima")
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(1).Width = 100
        DataGridView1.Columns(2).Width = 300


    End Sub

    Private Sub Btn_buscar_Click(sender As Object, e As EventArgs) Handles Btn_buscar.Click
        Txt_codigo.Text = DataGridView1.CurrentRow.Cells.Item(0).Value.ToString
        TextBox1.Text = DataGridView1.CurrentRow.Cells.Item(1).Value.ToString
        TextBox2.Text = DataGridView1.CurrentRow.Cells.Item(2).Value.ToString
    End Sub
End Class