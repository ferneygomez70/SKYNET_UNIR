Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration
Public Class Buscar
    Private ComBuffer As Byte()
    Private Delegate Sub UpdateFormDelegate()
    Private UpdateFormDelegate1 As UpdateFormDelegate
    Dim strReturn As String
    Dim strPeso As String
    Dim car As String
    Dim cadena As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
    Dim varconex As New MySqlConnection(cadena)
    Private dsusuario As New DataSet
    Private dausuario As New MySqlDataAdapter
    Private cmdusuario As New MySqlCommand
    Dim cmd As New MySqlCommand

    Private Sub Buscar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = ""
            Try
                'Me.TopMost = True 'se pondra en primer plano la aplicacion
                puertoserial.Open()
                TraeConfiguracion()

                'antes que nada hay que abrir el puerto
                If Not puertoserial.IsOpen Then
                    puertoserial.Open()
                Else
                    puertoserial.Close()

                End If

            Catch ex As Exception
                MsgBox("problema con la bascula reinicie el programa")
            End Try

    End Sub

    Public Sub TraeConfiguracion()
        Try
            puertoserial.Close()
            puertoserial.PortName = "COM1" 'puerto de comunicacion
            puertoserial.BaudRate = "9600" ' velocidad
            puertoserial.DataBits = "8" ' bits  de paridad
            puertoserial.StopBits = "1" ' bits de parada
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Public Sub puertoserial_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles puertoserial.DataReceived
        Dim n As Integer
        Try
            UpdateFormDelegate1 = New UpdateFormDelegate(AddressOf UpdateDisplay)
            n = puertoserial.BytesToRead ' capturamos el numero de bytes leidos
            If n > 50 Then
                ComBuffer = New Byte(n - 1) {} 'redimensionamos
                puertoserial.Read(ComBuffer, 0, n) 'leemos el dato
                Me.Invoke(UpdateFormDelegate1)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub UpdateDisplay()
        'variables locales
        Try
            Dim incoming As String = ""
            Dim longBuffer As Long
            Dim i As Integer
            'calcularmos la longitud del buffer y guardamos la información en una variable
            longBuffer = ComBuffer.Length
            For i = 0 To longBuffer - 1
                incoming = incoming & Chr(ComBuffer(i))
            Next
            strReturn = incoming.ToString
            'ahora solo tenemos que formatear la cadena tal como deseemos.
            'Yo conecte el puerto a una báscula por tanto necesito capturar el dato del pesaje
            '------------------------------------------------
            If strReturn.Length > 2 Then
                i = 0
                strPeso = ""
                Dim blnLeyoNumero As Boolean
                For i = 1 To strReturn.Length
                    car = Mid(strReturn, i, 1)
                    If IsNumeric(car) Or car = "." Then
                        strPeso = strPeso & car
                        blnLeyoNumero = True
                    Else
                        If blnLeyoNumero Then Exit For
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        '--------------------------------------------------
        'Listo ahora el dato lo mostramos en el label, ahora si a probarlo
        Me.Label10.Text = strPeso + 0 'label del peso

    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        DataGridView1.Enabled = True
        Dim strSQLusuario As String = "select articulos.id_product,articulos.cod_product,articulos.nomb_product,articulos.precio_venta,medida.medida,articulos.promocion, articulos.cant_prom, articulos.valor_prom,articulos.iva from articulos INNER JOIN medida ON (articulos.id_medida = medida.id_medida) WHERE articulos.cod_product " & "like " & "'" & TextBox1.Text & "%" & "'or articulos.nomb_product " & "like " & "'" & TextBox1.Text & "%" & "'"

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

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        puertoserial.Close()
        Me.Close()
    End Sub


    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Label16.Text = ""
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

        'Label16.Text = ""
        Label7.Text = medida
        Label8.Text = iva
        Label11.Text = nombre
        Label12.Text = precio
        ' Label13.Text = promocion
        Label5.Text = cant

        Label14.Text = valor_prom

        If Label7.Text <> "GR" Then
            Label10.Visible = False
            Label6.Visible = True
        Else
            Label10.Visible = True
            Label6.Visible = False

        End If

        If ((promocion = 0) And (Label10.Text >= cant)) Then
            Label5.Text = cant
            'Label5.Text = Label5.Text + 100
            Me.Label12.Text = valor_prom
            Me.Label14.Text = valor_prom
            Me.Label16.Visible = True
            Me.Label16.Text = "promocion"
            'MsgBox("esta es una hp promocion")
        Else
            Me.Label16.Visible = False
            Me.Label12.Text = precio


        End If
        Dim total, totalfinal As Double

        If ((Label8.Text = 0) And (Label7.Text <> "GR")) Then

            total = Label12.Text * Label6.Text
            Label15.Text = total
            TextBox1.Focus()
        Else
            total = Label10.Text * Label12.Text / 1000
            Label15.Text = total

        End If
        If Label7.Text <> "GR" Then
            total = (Label12.Text * Label6.Text)
            totalfinal = (total * Label8.Text / 100) + total

            Label15.Text = totalfinal
            TextBox1.Focus()
        Else
            total = Label10.Text * Label12.Text / 1000
            totalfinal = (total * Label8.Text / 100) + total
            Label15.Text = totalfinal

        End If


    End Sub
    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown

        Label16.Text = ""
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

            'Label16.Text = ""
            Label7.Text = medida
            Label8.Text = iva
            Label11.Text = nombre
            Label12.Text = precio
            'Label13.Text = promocion
            Label5.Text = cant

            Label14.Text = valor_prom

            If Label7.Text <> "GR" Then
                Label10.Visible = False
                Label6.Visible = True


            Else
                Label10.Visible = True
                Label6.Visible = False

            End If

            If ((promocion = 0) And (Label10.Text >= cant)) Then
                Label5.Text = cant
                'Label5.Text = Label5.Text + 100


                Me.Label12.Text = valor_prom
                Me.Label14.Text = valor_prom
                Me.Label16.Visible = True
                Me.Label16.Text = "promocion"
                'MsgBox("esta es una hp promocion")
            Else
                Me.Label16.Visible = False
                Me.Label12.Text = precio


            End If
            Dim total, totalfinal As Double

            If (Label8.Text = 0) Then
                If Label7.Text <> "GR" Then
                    total = Label12.Text * Label6.Text
                    Label15.Text = total
                    Me.TextBox1.Focus()
                Else
                    total = Label10.Text * Label12.Text / 1000
                    Label15.Text = total

                End If
            Else
                If Label7.Text <> "GR" Then
                    total = (Label12.Text * Label6.Text)
                    totalfinal = (total * Label8.Text / 100) + total

                    Label15.Text = totalfinal
                    TextBox1.Focus()
                Else
                    total = Label10.Text * Label12.Text / 1000
                    totalfinal = (total * Label8.Text / 100) + total
                    Label15.Text = totalfinal

                End If
            End If
        End If
    End Sub

    Private Sub Form10_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F10 Then
            puertoserial.Close()
            Close()
        End If

    End Sub
End Class