<?php
	

?>
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

mysql_select_db($database_conn, $conn);
$idfact=$_GET['idfact'];
$query_articulos = "SELECT   ventas.id_venta, articulos.cod_product,   articulos.nomb_product,   ventas.peso,   ventas.cant,   ventas.valor_unitario,   ventas.precio,   ventas.valor_iva FROM   ventas   INNER JOIN facturas ON (ventas.id_fact = facturas.id_fact)   INNER JOIN usuarios ON (ventas.id_usuarios = usuarios.id_usuarios)   INNER JOIN pos ON (ventas.id_caja = pos.id_caja)   INNER JOIN articulos ON (ventas.id_product = articulos.id_product) WHERE   facturas.id_fact =$idfact and ventas.activo = 1";
$articulos = mysql_query($query_articulos, $conn) or die(mysql_error());
$row_articulos = mysql_fetch_assoc($articulos);
$totalRows_articulos = mysql_num_rows($articulos);
?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml"><!-- InstanceBegin template="/Templates/inicio.dwt.php" codeOutsideHTMLIsLocked="false" -->
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<!-- InstanceBeginEditable name="doctitle" -->
<title>SKYNET</title>
<!-- InstanceEndEditable -->
<link href="estilo.css" rel="stylesheet" type="text/css">
<!-- InstanceBeginEditable name="head" -->
<style type="text/css">
.letra_menu {
	color: #FFF;
}
.titulo {
	font-size: 18px;
	color: #F00;
}
body {
	background-image: url(img/frutas.jpg);
}
</style>
<!-- InstanceEndEditable -->
</head>

<body>
<!-- InstanceBeginEditable name="EditRegion3" -->
<?php include('menu.php'); ?>
<p><br />
    </p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><span class="titulo"><strong>Borrar Producto </strong></span><br /> 
  <?
$idfact=$_GET['idfact'];
$sql="SELECT    facturas.id_fact,   pos.nomb_caja,   usuarios.nombre FROM   facturas   INNER JOIN pos ON (facturas.id_caja = pos.id_caja)   INNER JOIN usuarios ON (facturas.id_usuarios = usuarios.id_usuarios) WHERE facturas.id_fact=$idfact";
$resultado=mysql_query($sql);
$row=mysql_fetch_array($resultado);
?>
  <br />
</p>
<table width="465" border="0" cellpadding="0" cellspacing="0">
  <tr class="letter"  bgcolor="#00A9EC">
    <td width="191"><strong>Cajero</strong></td>
    <td>&nbsp;</td>
    <td><strong>Caja</strong></td>
    <td><strong>Factura N°</strong></td>
  </tr>
  <tr>
    <td><? echo $row['nombre']; ?></td>
    <td width="42">&nbsp;</td>
    <td width="126"><? echo $row['nomb_caja']; ?></td>
    <td width="106"><? echo $row['id_fact']; ?></td>
  </tr>
</table>
<p>&nbsp;</p>
<table width="700" border="0" class="tabla">
  <tr class="letter"  bgcolor="#00A9EC" valign="baseline">
    <td width="100">cod_product</td>
    <td width="222">nomb_product</td>
    <td width="100">peso</td>
    <td width="10">cant</td>
    <td width="100">valor_unitario</td>
    <td width="100">precio</td>
    <td width="100">valor_iva</td>
    <td></td>
  </tr>
  <?php do { ?>
    <tr bgcolor="#CCCCCC"
 onmouseover="this.style.backgroundColor='#00CCFF';"
 onmouseout="this.style.backgroundColor='#CCCCCC';">
      <td><?php echo $row_articulos['cod_product']; ?></td>
      <td><?php echo $row_articulos['nomb_product']; ?></td>
      <td><?php echo $row_articulos['peso']; ?></td>
      <td><?php echo $row_articulos['cant']; ?></td>
      <td align="right"><?php echo $row_articulos['valor_unitario']; ?></td>
      <td align="right"><?php echo $row_articulos['precio']; ?></td>
      <td align="right"><?php echo $row_articulos['valor_iva']; ?></td>
       <td><a href='delete_productofact.php?idventa=<?php echo $row_articulos['id_venta']; ?>&idfact=<? echo $idfact ?>'onclick="return window.confirm('¿Esta seguro de eliminar el producto (<?php echo $row_articulos['nomb_product']; ?>)? ');"><img src="img/b_deltbl.png" border="0" /></a>
       
     
       </td>
    </tr>
    <?php } while ($row_articulos = mysql_fetch_assoc($articulos)); ?>
</table>
<!-- InstanceEndEditable -->
</body>
<!-- InstanceEnd --></html>
<?php
mysql_free_result($articulos);
?>
