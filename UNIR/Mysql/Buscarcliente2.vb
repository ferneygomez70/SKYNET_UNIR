Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration
Public Class Buscarcliente2
    Dim cadena As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
    Dim varconex As New MySqlConnection(cadena)
    Private dsusuario As New DataSet
    Private dausuario As New MySqlDataAdapter
    Private cmdusuario As New MySqlCommand
    Dim cmd As New MySqlCommand

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        DataGridView1.Enabled = True

        Dim strSQLusuario As String = "select clientes.id_cliente,clientes.Nombres, clientes.Nit from clientes   WHERE clientes.Nombres " & "like " & "'" & TextBox1.Text & "%" & "' OR clientes.Nit LIKE  '%" & TextBox1.Text & "%'"

        cmdusuario.CommandText = strSQLusuario
        cmdusuario.CommandType = CommandType.Text
        cmdusuario.Connection = varconex
        dausuario.SelectCommand = cmdusuario

        'se limpia la tabla para volver a llenar el grid 

        If DataGridView1.Rows.Count > 0 Then
            dsusuario.Tables("clientes").Clear()

        End If

        dausuario.Fill(dsusuario, "clientes")
        DataGridView1.DataSource = dsusuario.Tables("clientes")
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(1).Width = 400
        DataGridView1.Columns(2).Width = 100
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim Nombres As String
        Dim Nit As Integer



        Nombres = Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value
        Nit = Me.DataGridView1.Rows(e.RowIndex).Cells(2).Value


        Label1.Text = Nombres

        COBRAR2.TxtNit.Text = Nit


        Me.TextBox1.Focus()

        COBRAR2.Refresh()
        Me.Close()
    End Sub
    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown


        If e.KeyCode = Keys.Enter Then
            Dim Nombres As String
            Dim Nit As Integer

            Nombres = Me.DataGridView1.CurrentRow.Cells(0).Value
            Nit = Me.DataGridView1.CurrentRow.Cells(2).Value

            Label1.Text = Nombres





            Me.TextBox1.Focus()

            Me.Close()
        End If
    End Sub
    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If (COBRAR2.TxtNit.Text <> "") Then
            Me.TextBox1.Text = COBRAR2.TxtNit.Text
        Else
            TextBox1.Text = ""
        End If
        Me.TextBox1.Focus()
    End Sub


    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click

        Close()
    End Sub
    Private Sub Form4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F10 Then

            Close()
        End If

    End Sub
End Class
