<?php require_once('Connections/conn.php'); ?>
<?php
if (!function_exists("GetSQLValueString")) {
function GetSQLValueString($theValue, $theType, $theDefinedValue = "", $theNotDefinedValue = "") 
{
  if (PHP_VERSION < 6) {
    $theValue = get_magic_quotes_gpc() ? stripslashes($theValue) : $theValue;
  }

  $theValue = function_exists("mysql_real_escape_string") ? mysql_real_escape_string($theValue) : mysql_escape_string($theValue);

  switch ($theType) {
    case "text":
      $theValue = ($theValue != "") ? "'" . $theValue . "'" : "NULL";
      break;    
    case "long":
    case "int":
      $theValue = ($theValue != "") ? intval($theValue) : "NULL";
      break;
    case "double":
      $theValue = ($theValue != "") ? doubleval($theValue) : "NULL";
      break;
    case "date":
      $theValue = ($theValue != "") ? "'" . $theValue . "'" : "NULL";
      break;
    case "defined":
      $theValue = ($theValue != "") ? $theDefinedValue : $theNotDefinedValue;
      break;
  }
  return $theValue;
}
}

$editFormAction = $_SERVER['PHP_SELF'];
if (isset($_SERVER['QUERY_STRING'])) {
  $editFormAction .= "?" . htmlentities($_SERVER['QUERY_STRING']);
}

if ((isset($_POST["MM_update"])) && ($_POST["MM_update"] == "form3")) {
  $updateSQL = sprintf("UPDATE clientes SET Nombres=%s, Nit=%s, Direccion=%s, Telefono=%s WHERE id_cliente=%s",
                       GetSQLValueString($_POST['Nombres'], "text"),
                       GetSQLValueString($_POST['Nit'], "int"),
                       GetSQLValueString($_POST['Direccion'], "text"),
                       GetSQLValueString($_POST['Telefono'], "text"),
                       GetSQLValueString($_POST['id_cliente'], "int"));

  mysql_select_db($database_conn, $conn);
  $Result1 = mysql_query($updateSQL, $conn) or die(mysql_error());

  $updateGoTo = "CONSULTARCLIENTES.PHP";
  if (isset($_SERVER['QUERY_STRING'])) {
    $updateGoTo .= (strpos($updateGoTo, '?')) ? "&" : "?";
    $updateGoTo .= $_SERVER['QUERY_STRING'];
  }
  header(sprintf("Location: %s", $updateGoTo));
}

function GetSQLValueString($theValue, $theType, $theDefinedValue = "", $theNotDefinedValue = "") 
{
  $theValue = (!get_magic_quotes_gpc()) ? addslashes($theValue) : $theValue;

  switch ($theType) {
    case "text":
      $theValue = ($theValue != "") ? "'" . $theValue . "'" : "NULL";
      break;    
    case "long":
    case "int":
      $theValue = ($theValue != "") ? intval($theValue) : "NULL";
      break;
    case "double":
      $theValue = ($theValue != "") ? "'" . doubleval($theValue) . "'" : "NULL";
      break;
    case "date":
      $theValue = ($theValue != "") ? "'" . $theValue . "'" : "NULL";
      break;
    case "defined":
      $theValue = ($theValue != "") ? $theDefinedValue : $theNotDefinedValue;
      break;
  }
  return $theValue;
}

$colname_Recordset1 = "-1";
if (isset($_GET['Nit'])) {
  $colname_Recordset1 = $_GET['Nit'];
}
mysql_select_db($database_conn, $conn);
$query_Recordset1 = sprintf("SELECT * FROM clientes WHERE Nit = %s", GetSQLValueString($colname_Recordset1, "int"));
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
.Estilo2 {color: #000033; }
.Estilo10 {color: #FFFF00; }
.Estilo17 {color: #FFFF00; font-size: 12px; }
.Estilo20 {color: #FF0000; font-size: 24px; }
</style>
<link href="SpryAssets/SpryMenuBarHorizontal.css" rel="stylesheet" type="text/css" />
<script src="SpryAssets/SpryMenuBar.js" type="text/javascript"></script>

<table width="1172" border="0" align="left" cellpadding="0" cellspacing="0">
  <tr>
    <td width="1172"><div align="center" class="Estilo20">
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
            <li><a href="nominasin foto.php" class="MenuBarItemSubmenu">NOMINA</a>
              <ul>
                <li><a href="CREAREMPLEADO.PHP">CREAR EMPLEADO</a></li>
<li><a href="modificarempleado.php">MODIFICAR</a></li>
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
                <li><a href="modificarproveedor.php">MODIFICAR</a></li>
                <li><a href="proveedores.php">LISTAR</a></li>
                <li><a href="estadoproveedor.html">ESTADO DEL PROVEEDOR</a></li>
              </ul>
            </li>
          </ul>
        </li>
        <li><a href="index.php">SALIR</a>      </li>
      </ul>
      <p>&nbsp;</p>
    </div></td>
  </tr>
  <tr>
    <td><div align="center" class="Estilo17"></div></td>
  </tr>
</table>
<form id="form1" name="form1" method="post" action="">
  <p>&nbsp;</p>
  <p>&nbsp;</p>
</form>
<script type="text/javascript">
var MenuBar1 = new Spry.Widget.MenuBar("MenuBar1", {imgDown:"SpryAssets/SpryMenuBarDownHover.gif", imgRight:"SpryAssets/SpryMenuBarRightHover.gif"});
</script>
<form id="form2" name="form2" method="get" action="buscarcliente.PHP?$Nit">
  <p>
    <label></label>
    <label></label>
    <?php
mysql_free_result($Recordset1);
?>
</p>
  <p>&nbsp;</p>
</form>
<form action="<?php echo $editFormAction; ?>" method="post" name="form3" id="form3">
  <table align="center">
    <tr valign="baseline">
      <td nowrap="nowrap" align="right">Nombres:</td>
      <td><input type="text" name="Nombres" value="<?php echo htmlentities($row_Recordset1['Nombres'], ENT_COMPAT, ''); ?>" size="32" /></td>
    </tr>
    <tr valign="baseline">
      <td nowrap="nowrap" align="right">Nit:</td>
      <td><input type="text" name="Nit" value="<?php echo htmlentities($row_Recordset1['Nit'], ENT_COMPAT, ''); ?>" size="32" /></td>
    </tr>
    <tr valign="baseline">
      <td nowrap="nowrap" align="right">Direccion:</td>
      <td><input type="text" name="Direccion" value="<?php echo htmlentities($row_Recordset1['Direccion'], ENT_COMPAT, ''); ?>" size="32" /></td>
    </tr>
    <tr valign="baseline">
      <td nowrap="nowrap" align="right">Telefono:</td>
      <td><input type="text" name="Telefono" value="<?php echo htmlentities($row_Recordset1['Telefono'], ENT_COMPAT, ''); ?>" size="32" /></td>
    </tr>
    <tr valign="baseline">
      <td nowrap="nowrap" align="right">&nbsp;</td>
      <td><input type="submit" value="Actualizar registro" /></td>
    </tr>
  </table>
  <input type="hidden" name="MM_update" value="form3" />
  <input type="hidden" name="id_cliente" value="<?php echo $row_Recordset1['id_cliente']; ?>" />
</form>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
