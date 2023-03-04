Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration
Public Class IMPRIMIR_AZ

    Dim cadena As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
    Dim varconex As New MySqlConnection(cadena)
    Private dsusuario As New DataSet
    Private dausuario As New MySqlDataAdapter
    Private cmdusuario As New MySqlCommand
    Dim cmd As New MySqlCommand
    Private Sub Form13_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.F10 Then

            Close()

        End If

    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        DataGridView1.Enabled = True
        'Label4.Text = DateTimePicker1.Value.Year & "-" & DateTimePicker1.Value.Month & "-" & DateTimePicker1.Value.Day

        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy-MM-dd"

        Label4.Text = DateTimePicker1.Text


        Dim strSQLusuario As String = "SELECT cierre_caja.id_salida as num_salida,pos.nomb_caja,usuarios.nombre,entrada_caja.fecha_entrada, cierre_caja.total_cierre FROM cierre_caja   INNER JOIN entrada_caja ON (cierre_caja.id_entracaja = entrada_caja.id_entracaja)   INNER JOIN usuarios ON (cierre_caja.id_usuarios = usuarios.id_usuarios)   INNER JOIN pos ON (cierre_caja.id_caja = pos.id_caja) WHERE     entrada_caja.fecha_entrada between ' " & Label4.Text & " 00:00:00' and  ' " & Label4.Text & " 23:59:00' ORDER BY entrada_caja.fecha_entrada desc"
        'TextBox1.Text = strSQLusuario
        cmdusuario.CommandText = strSQLusuario
        cmdusuario.CommandType = CommandType.Text
        cmdusuario.Connection = varconex
        dausuario.SelectCommand = cmdusuario

        'se limpia la tabla para volver a llenar el grid 

        If DataGridView1.Rows.Count > 0 Then
            dsusuario.Tables("cierre_caja").Clear()

        End If

        dausuario.Fill(dsusuario, "cierre_caja")
        DataGridView1.DataSource = dsusuario.Tables("cierre_caja")
    End Sub



    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        Close()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim salida As Integer

        salida = Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value
        Label5.Text = salida
        CIERRE_CAJA_AZ.Label1.Text = salida
        CIERRE_CAJA_AZ.ShowDialog()

    End Sub
    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        'Dim oForm2 As Form1

        If e.KeyCode = Keys.Enter Then
            Dim salida As Integer

            salida = Me.DataGridView1.CurrentRow.Cells(0).Value
            Label5.Text = salida
            CIERRE_CAJA_AZ.Label1.Text = salida
            CIERRE_CAJA_AZ.ShowDialog()
        End If
    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub

    Private Sub Form13_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label49_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label49.Click

    End Sub
End Class