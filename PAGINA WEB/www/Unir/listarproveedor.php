<?php require_once('Connections/conn.php'); ?>
<?php
mysql_select_db($database_conn, $conn);
$query_Recordset1 = "SELECT * FROM proveedores ORDER BY id_proveedor DESC";
$Recordset1 = mysql_query($query_Recordset1, $conn) or die(mysql_error());
$row_Recordset1 = mysql_fetch_assoc($Recordset1);
$totalRows_Recordset1 = mysql_num_rows($Recordset1);
?><style type="text/css">
.letra_menu {
	color: #FFF;
}
body {
	background-image: url(img/Fondo-color-verde-688051.jpeg);
}
.Estilo10 {
	color: #FFFF00;
	font-size: 24px;
}
.Estilo17 {color: #FFFF00; font-size: 12px; }
.Estilo20 {color: #FF0000; font-size: 24px; }
</style>
<link href="SpryAssets/SpryMenuBarHorizontal.css" rel="stylesheet" type="text/css" />
<script src="SpryAssets/SpryMenuBar.js" type="text/javascript"></script>

<table width="1327" border="0" align="left" cellpadding="0" cellspacing="0">
  <tr>
    <td width="1172" height="45"><p align="center" class="Estilo10">SKYNET INGENIERIA </p>
    <p align="center">&nbsp;</p>
    </td>
  </tr>
  <tr>
    <td><div align="center" class="Estilo17"></div></td>
  </tr>
</table>
<form id="form1" name="form1" method="post" action="">
  <div align="center" class="Estilo20">
    <ul id="MenuBar1" class="MenuBarHorizontal">
<li><a class="MenuBarItemSubmenu" href="#">ARTICULOS</a>
  <ul>
    <li><a href="articulos.php">CREAR</a></li>
    <li><a href="promociones.php">CAMBIAR PRECIOS</a></li>
  </ul>
</li>
      <li><a href="#" class="MenuBarItemSubmenu">USUARIOS</a>
          <ul>
            <li><a href="usuarios.php">CREAR</a></li>
            <li><a href="cajas.php">IP</a></li>
          </ul>
      </li>
      <li><a class="MenuBarItemSubmenu" href="#">FACTURAS</a>
          <ul>
            <li><a href="eliminar_producto.php">BORRAR PRODUCTO</a></li>
            <li><a href="devoluciones.php">DEVOLUCION</a></li>
            <li><a href="eliminarfactura.html">ELIMINAR FACTURAS</a></li>
          </ul>
      </li>
      <li><a href="#" class="MenuBarItemSubmenu">INFORMES</a>
          <ul>
            <li><a href="reporte4.php">TOTAL FACTURADO</a></li>
            <li><a href="reportes1.php">PRODUCTOS VENDIDOS</a></li>
            <li><a href="reporte_az.php">A-Z CAJERO</a></li>
            <li><a href="reporte_facturas.php">FACTURA POR CAJERO</a></li>
          </ul>
      </li>
      <li><a href="#" class="MenuBarItemSubmenu">GESTION</a>
          <ul>
            <li><a href="cargar_inventario.php">INVENTARIOS</a></li>
            <li><a href="#" class="MenuBarItemSubmenu">NOMINA</a>
              <ul>
                <li><a href="CREAREMPLEADO.PHP">CREAR EMPLEADO</a></li>
                <li><a href="modificarempledo.html">MODIFICAR</a></li>
                <li><a href="listarempleados.php">LISTAR</a></li>
                <li><a href="nomina.php">GENERAR NOMINA</a></li>
              </ul>
            </li>
            <li><a href="buscarcliente.html" class="MenuBarItemSubmenu">CLIENTES</a>
                <ul>
                  <li><a href="CREARCLIENTE.PHP">CREAR</a></li>
                  <li><a href="CONSULTARCLIENTES.PHP">LISTAR CLIENTE</a></li>
                  <li><a href="buscarcliente.html">MODIFICAR</a></li>
                  <li><a href="consultaclientenit.html">VER ESTADO</a></li>
                </ul>
            </li>
            <li><a href="#" class="MenuBarItemSubmenu">PROVEEDOR</a>
                <ul>
                  <li><a href="crearproveedor.php">CREAR</a></li>
                  <li><a href="modificarproveedor.html">MODIFICAR</a></li>
                  <li><a href="listarproveedor.php">LISTAR</a></li>
                  <li><a href="estadoproveedor.html">ESTADO DEL PROVEEDOR</a></li>
                </ul>
            </li>
          </ul>
      </li>
      <li><a href="index.php">SALIR</a> </li>
      <p>&nbsp;</p>
    </ul>
    <p>
      <script type="text/javascript">
var MenuBar1 = new Spry.Widget.MenuBar("MenuBar1", {imgDown:"SpryAssets/SpryMenuBarDownHover.gif", imgRight:"SpryAssets/SpryMenuBarRightHover.gif"});
      </script>
</p>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
  </div>
</form>
<form id="form2" name="form2" method="post" action="">
  <table border="1" cellpadding="1" cellspacing="1">
    <tr>
      <td>id_proveedor</td>
      <td>nit_proveedor</td>
      <td>nombre_proveedor</td>
      <td>tel_proveedor</td>
      <td>dir_proveedor</td>
    </tr>
    <?php do { ?>
      <tr>
        <td><?php echo $row_Recordset1['id_proveedor']; ?></td>
        <td><?php echo $row_Recordset1['nit_proveedor']; ?></td>
        <td><?php echo $row_Recordset1['nombre_proveedor']; ?></td>
        <td><?php echo $row_Recordset1['tel_proveedor']; ?></td>
        <td><?php echo $row_Recordset1['dir_proveedor']; ?></td>
      </tr>
      <?php } while ($row_Recordset1 = mysql_fetch_assoc($Recordset1)); ?>
  </table>
</form>
<?php
mysql_free_result($Recordset1);
?>
