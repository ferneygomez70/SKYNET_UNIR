<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Crear_articulos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txt_articulo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Txt_categoria = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Txt_familia = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Txt_iva = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Txt_preciocompra = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Txt_precioventa = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Txt_medida = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Txt_codigo = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Txt_promocion = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Txt_proveedor = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Txt_cantpromocion = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Txt_valorprom = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Txt_cantidad = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Txt_activo = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(521, 382)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(195, 56)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "CREAR ARTICULO"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txt_articulo
        '
        Me.txt_articulo.Location = New System.Drawing.Point(172, 32)
        Me.txt_articulo.Name = "txt_articulo"
        Me.txt_articulo.Size = New System.Drawing.Size(151, 20)
        Me.txt_articulo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "ARTICULO"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(378, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "CATEGORIA"
        '
        'Txt_categoria
        '
        Me.Txt_categoria.Location = New System.Drawing.Point(565, 21)
        Me.Txt_categoria.Name = "Txt_categoria"
        Me.Txt_categoria.Size = New System.Drawing.Size(74, 20)
        Me.Txt_categoria.TabIndex = 3
        Me.Txt_categoria.Text = "1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(378, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "FAMILIA"
        '
        'Txt_familia
        '
        Me.Txt_familia.Location = New System.Drawing.Point(565, 81)
        Me.Txt_familia.Name = "Txt_familia"
        Me.Txt_familia.Size = New System.Drawing.Size(74, 20)
        Me.Txt_familia.TabIndex = 7
        Me.Txt_familia.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(378, 127)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "IVA"
        '
        'Txt_iva
        '
        Me.Txt_iva.Location = New System.Drawing.Point(565, 125)
        Me.Txt_iva.Name = "Txt_iva"
        Me.Txt_iva.Size = New System.Drawing.Size(74, 20)
        Me.Txt_iva.TabIndex = 5
        Me.Txt_iva.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(38, 166)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "PRECIO COMPRA"
        '
        'Txt_preciocompra
        '
        Me.Txt_preciocompra.Location = New System.Drawing.Point(172, 163)
        Me.Txt_preciocompra.Name = "Txt_preciocompra"
        Me.Txt_preciocompra.Size = New System.Drawing.Size(151, 20)
        Me.Txt_preciocompra.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(38, 128)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "PRECIO VENTA"
        '
        'Txt_precioventa
        '
        Me.Txt_precioventa.Location = New System.Drawing.Point(172, 125)
        Me.Txt_precioventa.Name = "Txt_precioventa"
        Me.Txt_precioventa.Size = New System.Drawing.Size(151, 20)
        Me.Txt_precioventa.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(378, 172)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "MEDIDA"
        '
        'Txt_medida
        '
        Me.Txt_medida.Location = New System.Drawing.Point(565, 165)
        Me.Txt_medida.Name = "Txt_medida"
        Me.Txt_medida.Size = New System.Drawing.Size(74, 20)
        Me.Txt_medida.TabIndex = 11
        Me.Txt_medida.Text = "2"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(38, 88)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 13)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "CODIGO"
        '
        'Txt_codigo
        '
        Me.Txt_codigo.Location = New System.Drawing.Point(172, 81)
        Me.Txt_codigo.Name = "Txt_codigo"
        Me.Txt_codigo.Size = New System.Drawing.Size(151, 20)
        Me.Txt_codigo.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(378, 217)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "PROMOCION"
        '
        'Txt_promocion
        '
        Me.Txt_promocion.Location = New System.Drawing.Point(565, 210)
        Me.Txt_promocion.Name = "Txt_promocion"
        Me.Txt_promocion.Size = New System.Drawing.Size(74, 20)
        Me.Txt_promocion.TabIndex = 17
        Me.Txt_promocion.Text = "1"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(38, 258)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(75, 13)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "PROVEEDOR"
        '
        'Txt_proveedor
        '
        Me.Txt_proveedor.Location = New System.Drawing.Point(172, 258)
        Me.Txt_proveedor.Name = "Txt_proveedor"
        Me.Txt_proveedor.Size = New System.Drawing.Size(151, 20)
        Me.Txt_proveedor.TabIndex = 19
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(378, 258)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(108, 13)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "CANT. PROMOCION"
        '
        'Txt_cantpromocion
        '
        Me.Txt_cantpromocion.Location = New System.Drawing.Point(565, 251)
        Me.Txt_cantpromocion.Name = "Txt_cantpromocion"
        Me.Txt_cantpromocion.Size = New System.Drawing.Size(74, 20)
        Me.Txt_cantpromocion.TabIndex = 21
        Me.Txt_cantpromocion.Text = "0"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(378, 303)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(112, 13)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "VALOR PROMOCION"
        '
        'Txt_valorprom
        '
        Me.Txt_valorprom.Location = New System.Drawing.Point(565, 296)
        Me.Txt_valorprom.Name = "Txt_valorprom"
        Me.Txt_valorprom.Size = New System.Drawing.Size(74, 20)
        Me.Txt_valorprom.TabIndex = 23
        Me.Txt_valorprom.Text = "0"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(38, 214)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(62, 13)
        Me.Label13.TabIndex = 26
        Me.Label13.Text = "CANTIDAD"
        '
        'Txt_cantidad
        '
        Me.Txt_cantidad.Location = New System.Drawing.Point(172, 214)
        Me.Txt_cantidad.Name = "Txt_cantidad"
        Me.Txt_cantidad.Size = New System.Drawing.Size(151, 20)
        Me.Txt_cantidad.TabIndex = 25
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(431, 338)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(46, 13)
        Me.Label14.TabIndex = 28
        Me.Label14.Text = "ACTIVO"
        '
        'Txt_activo
        '
        Me.Txt_activo.Location = New System.Drawing.Point(565, 338)
        Me.Txt_activo.Name = "Txt_activo"
        Me.Txt_activo.Size = New System.Drawing.Size(74, 20)
        Me.Txt_activo.TabIndex = 27
        Me.Txt_activo.Text = "1"
        '
        'Crear_articulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Txt_activo)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Txt_cantidad)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Txt_valorprom)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Txt_cantpromocion)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Txt_proveedor)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Txt_promocion)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Txt_preciocompra)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Txt_precioventa)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Txt_medida)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Txt_codigo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Txt_familia)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Txt_iva)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Txt_categoria)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_articulo)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Crear_articulos"
        Me.Text = "Crear_articulos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents txt_articulo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Txt_categoria As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Txt_familia As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Txt_iva As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Txt_preciocompra As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Txt_precioventa As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Txt_medida As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Txt_codigo As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Txt_promocion As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Txt_proveedor As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Txt_cantpromocion As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Txt_valorprom As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Txt_cantidad As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Txt_activo As TextBox
End Class
