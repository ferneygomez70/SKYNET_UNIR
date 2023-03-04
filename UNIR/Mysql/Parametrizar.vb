Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration
Imports System.Diagnostics
Imports System.IO
Imports System.Drawing.Printing
Imports System.Runtime.InteropServices

Public Class Parametrizar

    'Dim LoginBorrado As Boolean
    'Dim SistemaPuntos As Boolean
    'Dim PrecioPorMayor As Boolean
    'Dim Creditos As Boolean
    'Dim Pagos As Boolean
    'Dim InventarioPantalla As Boolean
    'Dim IventarioFamilias As Boolean
    'Dim FechaVencimiento As Boolean
    'Dim AlertasVencimiento As Boolean
    'Dim AlertasStock As Boolean
    'Dim DobleFacturacion As Boolean
    'Dim Bascula As Boolean
    'Dim Descuento As Boolean
    'Dim AzVentas As Boolean
    'Dim AzInventario As Boolean
    'Dim Recetas As Boolean



    Dim cadena As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
    Dim varconex, varconex1, conexion As New MySqlConnection(cadena)
    Dim RawPrinterHelper As Object
    Dim strCurrency As String = ""
    Dim acceptableKey As Boolean = False


    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles lbl2.Click

    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Dim Query As String


        If Cbox_LoginBorrado.Checked = True Then
            Try
                If varconex.State = ConnectionState.Open Then varconex.Close()
                Query = "update parametrizar set Estado= 1  where Funcion = " & "'LoginBorrado'"
                varconex.Open()
                Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
                cmd2.ExecuteNonQuery()
                varconex.Close()
            Catch ex As Exception
                MsgBox("fallo de actualización LoginBorrado ", vbExclamation, "Atención      SKYNET")

            End Try
        Else
            Try
                If varconex.State = ConnectionState.Open Then varconex.Close()
                Query = "update parametrizar set Estado= 0  where Funcion = " & "'LoginBorrado'"
                varconex.Open()
                Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
                cmd2.ExecuteNonQuery()
                varconex.Close()
            Catch ex As Exception
                MsgBox("fallo de actualización LoginBorrado", vbExclamation, "Atención      SKYNET")
            End Try
        End If
        '

        If Cbox_SistemaPuntos.Checked = True Then
            Try
                If varconex.State = ConnectionState.Open Then varconex.Close()
                Query = "update parametrizar set Estado= 1  where Funcion = " & "'SistemaPuntos'"
                varconex.Open()
                Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
                cmd2.ExecuteNonQuery()
                varconex.Close()
            Catch ex As Exception
                MsgBox("fallo de actualización SistemaPuntos ", vbExclamation, "Atención      SKYNET")

            End Try
        Else
            Try
                If varconex.State = ConnectionState.Open Then varconex.Close()
                Query = "update parametrizar set Estado= 0  where Funcion = " & "'SistemaPuntos'"
                varconex.Open()
                Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
                cmd2.ExecuteNonQuery()
                varconex.Close()
            Catch ex As Exception
                MsgBox("fallo de actualización SistemaPuntos", vbExclamation, "Atención      SKYNET")
            End Try
        End If
        '

        If Cbox_PrecioPorMayor.Checked = True Then
            Try
                If varconex.State = ConnectionState.Open Then varconex.Close()
                Query = "update parametrizar set Estado= 1  where Funcion = " & "'PrecioPorMayor'"
                varconex.Open()
                Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
                cmd2.ExecuteNonQuery()
                varconex.Close()
            Catch ex As Exception
                MsgBox("fallo de actualización PrecioPorMayor ", vbExclamation, "Atención      SKYNET")

            End Try
        Else
            Try
                If varconex.State = ConnectionState.Open Then varconex.Close()
                Query = "update parametrizar set Estado= 0  where Funcion = " & "'PrecioPorMayor'"
                varconex.Open()
                Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
                cmd2.ExecuteNonQuery()
                varconex.Close()
            Catch ex As Exception
                MsgBox("fallo de actualización PrecioPorMayor", vbExclamation, "Atención      SKYNET")
            End Try
        End If
        '

        If Cbox_Creditos.Checked = True Then
            Try
                If varconex.State = ConnectionState.Open Then varconex.Close()
                Query = "update parametrizar set Estado= 1  where Funcion = " & "'Creditos'"
                varconex.Open()
                Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
                cmd2.ExecuteNonQuery()
                varconex.Close()
            Catch ex As Exception
                MsgBox("fallo de actualización Creditos ", vbExclamation, "Atención      SKYNET")

            End Try
        Else
            Try
                If varconex.State = ConnectionState.Open Then varconex.Close()
                Query = "update parametrizar set Estado= 0  where Funcion = " & "'Creditos'"
                varconex.Open()
                Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
                cmd2.ExecuteNonQuery()
                varconex.Close()
            Catch ex As Exception
                MsgBox("fallo de actualización Creditos", vbExclamation, "Atención      SKYNET")
            End Try
        End If
        '

        If Cbox_Pagos.Checked = True Then
            Try
                If varconex.State = ConnectionState.Open Then varconex.Close()
                Query = "update parametrizar set Estado= 1  where Funcion = " & "'Pagos'"
                varconex.Open()
                Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
                cmd2.ExecuteNonQuery()
                varconex.Close()
            Catch ex As Exception
                MsgBox("fallo de actualización Pagos ", vbExclamation, "Atención      SKYNET")

            End Try
        Else
            Try
                If varconex.State = ConnectionState.Open Then varconex.Close()
                Query = "update parametrizar set Estado= 0  where Funcion = " & "'Pagos'"
                varconex.Open()
                Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
                cmd2.ExecuteNonQuery()
                varconex.Close()
            Catch ex As Exception
                MsgBox("fallo de actualización Pagos", vbExclamation, "Atención      SKYNET")
            End Try
        End If
        '

        If Cbox_Inventario.Checked = True Then
            Try
                If varconex.State = ConnectionState.Open Then varconex.Close()
                Query = "update parametrizar set Estado= 1  where Funcion = " & "'InventarioPantalla'"
                varconex.Open()
                Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
                cmd2.ExecuteNonQuery()
                varconex.Close()
            Catch ex As Exception
                MsgBox("fallo de actualización InventarioPantalla ", vbExclamation, "Atención      SKYNET")

            End Try
        Else
            Try
                If varconex.State = ConnectionState.Open Then varconex.Close()
                Query = "update parametrizar set Estado= 0  where Funcion = " & "'InventarioPantalla'"
                varconex.Open()
                Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
                cmd2.ExecuteNonQuery()
                varconex.Close()
            Catch ex As Exception
                MsgBox("fallo de actualización InventarioPantalla", vbExclamation, "Atención      SKYNET")
            End Try
        End If
        '

        If Cbox_Familias.Checked = True Then
            Try
                If varconex.State = ConnectionState.Open Then varconex.Close()
                Query = "update parametrizar set Estado= 1  where Funcion = " & "'IventarioFamilias'"
                varconex.Open()
                Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
                cmd2.ExecuteNonQuery()
                varconex.Close()
            Catch ex As Exception
                MsgBox("fallo de actualización IventarioFamilias ", vbExclamation, "Atención      SKYNET")

            End Try
        Else
            Try
                If varconex.State = ConnectionState.Open Then varconex.Close()
                Query = "update parametrizar set Estado= 0  where Funcion = " & "'IventarioFamilias'"
                varconex.Open()
                Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
                cmd2.ExecuteNonQuery()
                varconex.Close()
            Catch ex As Exception
                MsgBox("fallo de actualización IventarioFamilias", vbExclamation, "Atención      SKYNET")
            End Try
        End If
        '

        If Cbox_FechaVencimiento.Checked = True Then
            Try
                If varconex.State = ConnectionState.Open Then varconex.Close()
                Query = "update parametrizar set Estado= 1  where Funcion = " & "'FechaVencimiento'"
                varconex.Open()
                Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
                cmd2.ExecuteNonQuery()
                varconex.Close()
            Catch ex As Exception
                MsgBox("fallo de actualización FechaVencimiento ", vbExclamation, "Atención      SKYNET")

            End Try
        Else
            Try
                If varconex.State = ConnectionState.Open Then varconex.Close()
                Query = "update parametrizar set Estado= 0  where Funcion = " & "'FechaVencimiento'"
                varconex.Open()
                Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
                cmd2.ExecuteNonQuery()
                varconex.Close()
            Catch ex As Exception
                MsgBox("fallo de actualización FechaVencimiento", vbExclamation, "Atención      SKYNET")
            End Try
        End If
        '

        If Cbox_AlertasVencimiento.Checked = True Then
            Try
                If varconex.State = ConnectionState.Open Then varconex.Close()
                Query = "update parametrizar set Estado= 1  where Funcion = " & "'AlertasVencimiento'"
                varconex.Open()
                Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
                cmd2.ExecuteNonQuery()
                varconex.Close()
            Catch ex As Exception
                MsgBox("fallo de actualización AlertasVencimiento ", vbExclamation, "Atención      SKYNET")

            End Try
        Else
            Try
                If varconex.State = ConnectionState.Open Then varconex.Close()
                Query = "update parametrizar set Estado= 0  where Funcion = " & "'AlertasVencimiento'"
                varconex.Open()
                Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
                cmd2.ExecuteNonQuery()
                varconex.Close()
            Catch ex As Exception
                MsgBox("fallo de actualización AlertasVencimiento", vbExclamation, "Atención      SKYNET")
            End Try
        End If
        '

        If Cbox_AlertasStock.Checked = True Then
            Try
                If varconex.State = ConnectionState.Open Then varconex.Close()
                Query = "update parametrizar set Estado= 1  where Funcion = " & "'AlertasStock'"
                varconex.Open()
                Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
                cmd2.ExecuteNonQuery()
                varconex.Close()
            Catch ex As Exception
                MsgBox("fallo de actualización AlertasStock ", vbExclamation, "Atención      SKYNET")

            End Try
        Else
            Try
                If varconex.State = ConnectionState.Open Then varconex.Close()
                Query = "update parametrizar set Estado= 0  where Funcion = " & "'AlertasStock'"
                varconex.Open()
                Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
                cmd2.ExecuteNonQuery()
                varconex.Close()
            Catch ex As Exception
                MsgBox("fallo de actualización AlertasStock", vbExclamation, "Atención      SKYNET")
            End Try
        End If
        '

        If Cbox_DobleFactura.Checked = True Then
            Try
                If varconex.State = ConnectionState.Open Then varconex.Close()
                Query = "update parametrizar set Estado= 1  where Funcion = " & "'DobleFacturacion'"
                varconex.Open()
                Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
                cmd2.ExecuteNonQuery()
                varconex.Close()
            Catch ex As Exception
                MsgBox("fallo de actualización DobleFacturacion ", vbExclamation, "Atención      SKYNET")

            End Try
        Else
            Try
                If varconex.State = ConnectionState.Open Then varconex.Close()
                Query = "update parametrizar set Estado= 0  where Funcion = " & "'DobleFacturacion'"
                varconex.Open()
                Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
                cmd2.ExecuteNonQuery()
                varconex.Close()
            Catch ex As Exception
                MsgBox("fallo de actualización DobleFacturacion", vbExclamation, "Atención      SKYNET")
            End Try
        End If
        '

        If Cbox_Peso.Checked = True Then
            Try
                If varconex.State = ConnectionState.Open Then varconex.Close()
                Query = "update parametrizar set Estado= 1  where Funcion = " & "'Bascula'"
                varconex.Open()
                Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
                cmd2.ExecuteNonQuery()
                varconex.Close()
            Catch ex As Exception
                MsgBox("fallo de actualización Bascula ", vbExclamation, "Atención      SKYNET")

            End Try
        Else
            Try
                If varconex.State = ConnectionState.Open Then varconex.Close()
                Query = "update parametrizar set Estado= 0  where Funcion = " & "'Bascula'"
                varconex.Open()
                Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
                cmd2.ExecuteNonQuery()
                varconex.Close()
            Catch ex As Exception
                MsgBox("fallo de actualización Bascula", vbExclamation, "Atención      SKYNET")
            End Try
        End If
        '

        If Cbox_Descuento.Checked = True Then
            Try
                If varconex.State = ConnectionState.Open Then varconex.Close()
                Query = "update parametrizar set Estado= 1  where Funcion = " & "'Descuento'"
                varconex.Open()
                Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
                cmd2.ExecuteNonQuery()
                varconex.Close()
            Catch ex As Exception
                MsgBox("fallo de actualización Descuento ", vbExclamation, "Atención      SKYNET")

            End Try
        Else
            Try
                If varconex.State = ConnectionState.Open Then varconex.Close()
                Query = "update parametrizar set Estado= 0  where Funcion = " & "'Descuento'"
                varconex.Open()
                Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
                cmd2.ExecuteNonQuery()
                varconex.Close()
            Catch ex As Exception
                MsgBox("fallo de actualización Descuento", vbExclamation, "Atención      SKYNET")
            End Try
        End If
        '

        If Cbox_AzVentas.Checked = True Then
            Try
                If varconex.State = ConnectionState.Open Then varconex.Close()
                Query = "update parametrizar set Estado= 1  where Funcion = " & "'AzVentas'"
                varconex.Open()
                Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
                cmd2.ExecuteNonQuery()
                varconex.Close()
            Catch ex As Exception
                MsgBox("fallo de actualización AzVentas ", vbExclamation, "Atención      SKYNET")

            End Try
        Else
            Try
                If varconex.State = ConnectionState.Open Then varconex.Close()
                Query = "update parametrizar set Estado= 0  where Funcion = " & "'AzVentas'"
                varconex.Open()
                Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
                cmd2.ExecuteNonQuery()
                varconex.Close()
            Catch ex As Exception
                MsgBox("fallo de actualización AzVentas", vbExclamation, "Atención      SKYNET")
            End Try
        End If
        '

        If Cbox_ReporteInventarioAz.Checked = True Then
            Try
                If varconex.State = ConnectionState.Open Then varconex.Close()
                Query = "update parametrizar set Estado= 1  where Funcion = " & "'AzInventario'"
                varconex.Open()
                Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
                cmd2.ExecuteNonQuery()
                varconex.Close()
            Catch ex As Exception
                MsgBox("fallo de actualización AzInventario ", vbExclamation, "Atención      SKYNET")

            End Try
        Else
            Try
                If varconex.State = ConnectionState.Open Then varconex.Close()
                Query = "update parametrizar set Estado= 0  where Funcion = " & "'AzInventario'"
                varconex.Open()
                Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
                cmd2.ExecuteNonQuery()
                varconex.Close()
            Catch ex As Exception
                MsgBox("fallo de actualización AzInventario", vbExclamation, "Atención      SKYNET")
            End Try
        End If
        '

        If Cbox_Recetas.Checked = True Then
            Try
                If varconex.State = ConnectionState.Open Then varconex.Close()
                Query = "update parametrizar set Estado= 1  where Funcion = " & "'Recetas'"
                varconex.Open()
                Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
                cmd2.ExecuteNonQuery()
                varconex.Close()
            Catch ex As Exception
                MsgBox("fallo de actualización Recetas ", vbExclamation, "Atención      SKYNET")

            End Try
        Else
            Try
                If varconex.State = ConnectionState.Open Then varconex.Close()
                Query = "update parametrizar set Estado= 0  where Funcion = " & "'Recetas'"
                varconex.Open()
                Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
                cmd2.ExecuteNonQuery()
                varconex.Close()
            Catch ex As Exception
                MsgBox("fallo de actualización Recetas", vbExclamation, "Atención      SKYNET")
            End Try
        End If
        '

    End Sub

    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles BtnLimpiar.Click
        Cbox_LoginBorrado.Checked = False
        Cbox_SistemaPuntos.Checked = False
        Cbox_PrecioPorMayor.Checked = False
        Cbox_Creditos.Checked = False
        Cbox_Pagos.Checked = False
        Cbox_Inventario.Checked = False
        Cbox_Familias.Checked = False
        Cbox_FechaVencimiento.Checked = False
        Cbox_AlertasVencimiento.Checked = False
        Cbox_AlertasStock.Checked = False
        Cbox_DobleFactura.Checked = False
        Cbox_Peso.Checked = False
        Cbox_Descuento.Checked = False
        Cbox_AzVentas.Checked = False
        Cbox_ReporteInventarioAz.Checked = False
        Cbox_Recetas.Checked = False

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ObtenerParametros()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        End
    End Sub

    Private Sub Parametrizar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ObtenerParametros()


    End Sub
    Function ObtenerParametros()
        Dim Estado As String
        Dim count As Integer
        Dim Funciones As String
        Dim Query As String = "Select Funcion, Estado From parametrizar "
        If varconex.State = ConnectionState.Closed Then varconex.Open()
        Dim Adapter As New MySqlDataAdapter(Query, varconex)
        Dim ds As New DataSet
        Adapter.Fill(ds)
        count = 1
        For Each row As DataRow In ds.Tables(0).Rows
            Funciones = (row("Funcion"))
            Estado = (row("Estado"))

            If count = 1 Then
                If "LoginBorrado" = Funciones And Estado = "1" Then
                    Cbox_LoginBorrado.Checked = True
                    VariablesGoblales.LoginBorrado = True
                Else
                    VariablesGoblales.LoginBorrado = False
                End If
            End If
            If count = 2 Then
                If "SistemaPuntos" = Funciones And Estado = "1" Then
                    Cbox_SistemaPuntos.Checked = True
                    VariablesGoblales.SistemaPuntos = True
                Else
                    VariablesGoblales.SistemaPuntos = False
                End If
            End If
            If count = 3 Then
                If "PrecioPorMayor" = Funciones And Estado = "1" Then
                    Cbox_PrecioPorMayor.Checked = True
                    VariablesGoblales.PrecioPorMayor = True
                Else
                    VariablesGoblales.PrecioPorMayor = False
                End If
            End If
            If count = 4 Then
                If "Creditos" = Funciones And Estado = "1" Then
                    Cbox_Creditos.Checked = True
                    VariablesGoblales.Creditos = True
                Else
                    VariablesGoblales.Creditos = False
                End If
            End If

            If count = 5 Then
                If "Pagos" = Funciones And Estado = "1" Then
                    Cbox_Pagos.Checked = True
                    VariablesGoblales.Pagos = True
                Else
                    VariablesGoblales.Pagos = False
                End If
            End If
            If count = 6 Then
                If "InventarioPantalla" = Funciones And Estado = "1" Then
                    Cbox_Inventario.Checked = True
                    VariablesGoblales.InventarioPantalla = True
                Else
                    VariablesGoblales.InventarioPantalla = False
                End If
            End If
            If count = 7 Then
                If "IventarioFamilias" = Funciones And Estado = "1" Then
                    Cbox_Familias.Checked = True
                    VariablesGoblales.IventarioFamilias = True
                Else
                    VariablesGoblales.IventarioFamilias = False
                End If
            End If
            If count = 8 Then
                If "FechaVencimiento" = Funciones And Estado = "1" Then
                    Cbox_FechaVencimiento.Checked = True
                    VariablesGoblales.FechaVencimiento = True
                Else
                    VariablesGoblales.FechaVencimiento = False
                End If
            End If
            If count = 9 Then
                If "AlertasVencimiento" = Funciones And Estado = "1" Then
                    Cbox_AlertasVencimiento.Checked = True
                    VariablesGoblales.AlertasVencimiento = True
                Else
                    VariablesGoblales.AlertasVencimiento = False

                End If
            End If

            If count = 10 Then
                If "AlertasStock" = Funciones And Estado = "1" Then
                    Cbox_AlertasStock.Checked = True
                    VariablesGoblales.AlertasStock = True
                Else
                    VariablesGoblales.AlertasStock = False
                End If
            End If
            If count = 11 Then
                If "DobleFacturacion" = Funciones And Estado = "1" Then
                    Cbox_DobleFactura.Checked = True
                    VariablesGoblales.DobleFacturacion = True
                Else
                    VariablesGoblales.DobleFacturacion = False
                End If
            End If
            If count = 12 Then
                If "Bascula" = Funciones And Estado = "1" Then
                    Cbox_Peso.Checked = True
                    VariablesGoblales.Bascula = True
                Else
                    VariablesGoblales.Bascula = False
                End If
            End If

            If count = 13 Then
                If "Descuento" = Funciones And Estado = "1" Then
                    Cbox_Descuento.Checked = True
                    VariablesGoblales.Descuento = True
                Else
                    VariablesGoblales.Descuento = False
                End If
            End If

            If count = 14 Then
                If "AzVentas" = Funciones And Estado = "1" Then
                    Cbox_AzVentas.Checked = True
                    VariablesGoblales.AzVentas = True
                Else
                    VariablesGoblales.AzVentas = False

                End If
            End If
            If count = 15 Then
                If "AzInventario" = Funciones And Estado = "1" Then
                    Cbox_ReporteInventarioAz.Checked = True
                    VariablesGoblales.AzInventario = True
                Else
                    VariablesGoblales.AzInventario = False
                End If
            End If
            If count = 16 Then
                If "Recetas" = Funciones And Estado = "1" Then
                    Cbox_Recetas.Checked = True
                    VariablesGoblales.Recetas = True
                Else
                    VariablesGoblales.Recetas = False
                End If
            End If

            count = count + 1
        Next row

        varconex.Close()
        Return 0
    End Function
End Class