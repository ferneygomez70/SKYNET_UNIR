<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class facturas
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
        Me.Txt_ingcodigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Btn_consultar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Txt_articulo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Txt_cantidad = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Txt_precioventa = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Txt_preciocompra = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Txt_proveedor = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.bTN_INGRESARARTICULO = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TextBox13 = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Txt_total = New System.Windows.Forms.TextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TextBox10 = New System.Windows.Forms.TextBox()
        Me.Btn_terminarfact = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Inventario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Articulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Precio_compra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Precio_venta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Proveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Txt_ingcodigo
        '
        Me.Txt_ingcodigo.Location = New System.Drawing.Point(190, 53)
        Me.Txt_ingcodigo.Name = "Txt_ingcodigo"
        Me.Txt_ingcodigo.Size = New System.Drawing.Size(100, 20)
        Me.Txt_ingcodigo.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(60, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "INGRESE CODIGO:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(185, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(375, 25)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "INGRESE LA FACTURA DE COMPRA"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(735, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Label3"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(20, 165)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1184, 93)
        Me.DataGridView1.TabIndex = 5
        '
        'Btn_consultar
        '
        Me.Btn_consultar.Location = New System.Drawing.Point(332, 45)
        Me.Btn_consultar.Name = "Btn_consultar"
        Me.Btn_consultar.Size = New System.Drawing.Size(89, 35)
        Me.Btn_consultar.TabIndex = 1
        Me.Btn_consultar.Text = "CONSULTAR"
        Me.Btn_consultar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(735, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Label4"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(213, 112)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "ARTICULO"
        '
        'Txt_articulo
        '
        Me.Txt_articulo.Location = New System.Drawing.Point(193, 139)
        Me.Txt_articulo.Name = "Txt_articulo"
        Me.Txt_articulo.Size = New System.Drawing.Size(209, 20)
        Me.Txt_articulo.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(428, 112)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "CANTIDAD"
        '
        'Txt_cantidad
        '
        Me.Txt_cantidad.BackColor = System.Drawing.Color.DarkKhaki
        Me.Txt_cantidad.Location = New System.Drawing.Point(408, 139)
        Me.Txt_cantidad.Name = "Txt_cantidad"
        Me.Txt_cantidad.Size = New System.Drawing.Size(114, 20)
        Me.Txt_cantidad.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(698, 112)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "PRECIO VENTA"
        '
        'Txt_precioventa
        '
        Me.Txt_precioventa.Location = New System.Drawing.Point(683, 139)
        Me.Txt_precioventa.Name = "Txt_precioventa"
        Me.Txt_precioventa.Size = New System.Drawing.Size(114, 20)
        Me.Txt_precioventa.TabIndex = 14
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(553, 112)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 13)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "PRECIO COMPRA"
        '
        'Txt_preciocompra
        '
        Me.Txt_preciocompra.Location = New System.Drawing.Point(543, 139)
        Me.Txt_preciocompra.Name = "Txt_preciocompra"
        Me.Txt_preciocompra.Size = New System.Drawing.Size(114, 20)
        Me.Txt_preciocompra.TabIndex = 12
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(55, 112)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "CODIGO"
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(35, 139)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(152, 20)
        Me.TextBox6.TabIndex = 16
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(829, 112)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(75, 13)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "PROVEEDOR"
        '
        'Txt_proveedor
        '
        Me.Txt_proveedor.Location = New System.Drawing.Point(813, 139)
        Me.Txt_proveedor.Name = "Txt_proveedor"
        Me.Txt_proveedor.Size = New System.Drawing.Size(114, 20)
        Me.Txt_proveedor.TabIndex = 18
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(735, 625)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(166, 24)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "TOTAL FACTURA"
        '
        'TextBox8
        '
        Me.TextBox8.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox8.Location = New System.Drawing.Point(738, 665)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(154, 31)
        Me.TextBox8.TabIndex = 20
        '
        'bTN_INGRESARARTICULO
        '
        Me.bTN_INGRESARARTICULO.Location = New System.Drawing.Point(1081, 96)
        Me.bTN_INGRESARARTICULO.Name = "bTN_INGRESARARTICULO"
        Me.bTN_INGRESARARTICULO.Size = New System.Drawing.Size(129, 63)
        Me.bTN_INGRESARARTICULO.TabIndex = 3
        Me.bTN_INGRESARARTICULO.Text = "INGRESAR ARTICULO"
        Me.bTN_INGRESARARTICULO.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(47, 16)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(62, 13)
        Me.Label16.TabIndex = 26
        Me.Label16.Text = "CANTIDAD"
        '
        'TextBox13
        '
        Me.TextBox13.Location = New System.Drawing.Point(22, 32)
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.ReadOnly = True
        Me.TextBox13.Size = New System.Drawing.Size(114, 20)
        Me.TextBox13.TabIndex = 25
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.YellowGreen
        Me.GroupBox1.Controls.Add(Me.TextBox13)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Location = New System.Drawing.Point(444, 37)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(146, 61)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DATOS DE INVENTARIO"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(960, 112)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(106, 13)
        Me.Label13.TabIndex = 35
        Me.Label13.Text = "TOTAL PRODUCTO"
        '
        'Txt_total
        '
        Me.Txt_total.Location = New System.Drawing.Point(952, 139)
        Me.Txt_total.Name = "Txt_total"
        Me.Txt_total.Size = New System.Drawing.Size(114, 20)
        Me.Txt_total.TabIndex = 34
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(717, 582)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(137, 17)
        Me.CheckBox1.TabIndex = 37
        Me.CheckBox1.Text = "FACTURA A CREDITO"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(529, 625)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(158, 24)
        Me.Label14.TabIndex = 39
        Me.Label14.Text = "DEVOLUCIONES"
        '
        'TextBox10
        '
        Me.TextBox10.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox10.Location = New System.Drawing.Point(533, 665)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New System.Drawing.Size(154, 31)
        Me.TextBox10.TabIndex = 38
        Me.TextBox10.Text = "0"
        '
        'Btn_terminarfact
        '
        Me.Btn_terminarfact.Location = New System.Drawing.Point(347, 583)
        Me.Btn_terminarfact.Name = "Btn_terminarfact"
        Me.Btn_terminarfact.Size = New System.Drawing.Size(113, 60)
        Me.Btn_terminarfact.TabIndex = 41
        Me.Btn_terminarfact.Text = "TERMINAR FACTURA"
        Me.Btn_terminarfact.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(648, 37)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(45, 13)
        Me.Label20.TabIndex = 46
        Me.Label20.Text = "Label20"
        Me.Label20.Visible = False
        '
        'ListBox2
        '
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.Location = New System.Drawing.Point(946, 343)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(286, 368)
        Me.ListBox2.TabIndex = 47
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'PrintDocument1
        '
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(1010, 295)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(45, 13)
        Me.Label15.TabIndex = 48
        Me.Label15.Text = "Label15"
        Me.Label15.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 582)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(101, 63)
        Me.Button1.TabIndex = 49
        Me.Button1.Text = "CONSULTAR INVETARIO"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(135, 582)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(113, 63)
        Me.Button2.TabIndex = 50
        Me.Button2.Text = "CREAR ARTICULOS"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.codigo, Me.Inventario, Me.Articulo, Me.Cantidad, Me.Precio_compra, Me.Precio_venta, Me.Proveedor, Me.Total})
        Me.DataGridView2.Location = New System.Drawing.Point(12, 348)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(906, 204)
        Me.DataGridView2.TabIndex = 51
        '
        'codigo
        '
        Me.codigo.HeaderText = "Codigo"
        Me.codigo.Name = "codigo"
        '
        'Inventario
        '
        Me.Inventario.HeaderText = "Inventario"
        Me.Inventario.Name = "Inventario"
        Me.Inventario.ReadOnly = True
        '
        'Articulo
        '
        Me.Articulo.HeaderText = "Articulo"
        Me.Articulo.Name = "Articulo"
        '
        'Cantidad
        '
        Me.Cantidad.HeaderText = "Cantidad Comprada"
        Me.Cantidad.Name = "Cantidad"
        '
        'Precio_compra
        '
        Me.Precio_compra.HeaderText = "Precio_compra"
        Me.Precio_compra.Name = "Precio_compra"
        '
        'Precio_venta
        '
        Me.Precio_venta.HeaderText = "Precio_venta"
        Me.Precio_venta.Name = "Precio_venta"
        '
        'Proveedor
        '
        Me.Proveedor.HeaderText = "Proveedor"
        Me.Proveedor.Name = "Proveedor"
        '
        'Total
        '
        Me.Total.HeaderText = "Total"
        Me.Total.Name = "Total"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(514, 270)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(74, 13)
        Me.Label12.TabIndex = 52
        Me.Label12.Text = "SU COMPRA:"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(1103, 270)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(129, 63)
        Me.Button3.TabIndex = 53
        Me.Button3.Text = "RECALCULAR"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(12, 665)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(101, 63)
        Me.Button4.TabIndex = 54
        Me.Button4.Text = "INGRESO MATERIA PRIMA"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(135, 665)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(113, 63)
        Me.Button5.TabIndex = 55
        Me.Button5.Text = "CONSULTAR MATERIA PRIMA"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'facturas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1250, 749)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.ListBox2)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Btn_terminarfact)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TextBox10)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Txt_total)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.bTN_INGRESARARTICULO)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TextBox8)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Txt_proveedor)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TextBox6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Txt_precioventa)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Txt_preciocompra)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Txt_cantidad)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Txt_articulo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Btn_consultar)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Txt_ingcodigo)
        Me.Name = "facturas"
        Me.Text = "facturas"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Txt_ingcodigo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Btn_consultar As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Txt_articulo As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Txt_cantidad As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Txt_precioventa As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Txt_preciocompra As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Txt_proveedor As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents TextBox8 As TextBox
    Friend WithEvents bTN_INGRESARARTICULO As Button
    Friend WithEvents Label16 As Label
    Friend WithEvents TextBox13 As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Txt_total As TextBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Label14 As Label
    Friend WithEvents TextBox10 As TextBox
    Friend WithEvents Btn_terminarfact As Button
    Friend WithEvents Label20 As Label
    Friend WithEvents ListBox2 As ListBox
    Friend WithEvents PrintDialog1 As PrintDialog
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents Label15 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents Label12 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents codigo As DataGridViewTextBoxColumn
    Friend WithEvents Inventario As DataGridViewTextBoxColumn
    Friend WithEvents Articulo As DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As DataGridViewTextBoxColumn
    Friend WithEvents Precio_compra As DataGridViewTextBoxColumn
    Friend WithEvents Precio_venta As DataGridViewTextBoxColumn
    Friend WithEvents Proveedor As DataGridViewTextBoxColumn
    Friend WithEvents Total As DataGridViewTextBoxColumn
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
End Class
