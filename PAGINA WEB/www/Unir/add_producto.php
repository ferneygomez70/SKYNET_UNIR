<?php require_once('Connections/conn.php'); ?>
<?php require_once('Connections/conn.php'); ?>
<?php
	

?>
<?php require_once('Connections/conn.php');  
?>
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
?>
<?php
$editFormAction = $_SERVER['PHP_SELF'];
if (isset($_SERVER['QUERY_STRING'])) {
  $editFormAction .= "?" . htmlentities($_SERVER['QUERY_STRING']);
}
?>
<?php
if ((isset($_POST["MM_insert"])) && ($_POST["MM_insert"] == "form1")) {
  $insertSQL = sprintf("INSERT INTO articulos (id_categoria, iva,familia,  nomb_product, id_medida, inventario,lote, precio_compra, precio_venta, cod_product,activo) VALUES (%s, %s, %s, %s, %s, %s,%s,%s,%s, %s, %s)",
                       GetSQLValueString($_POST['id_categoria'], "int"),
                       GetSQLValueString($_POST['iva'], "int"),
					   GetSQLValueString($_POST['familia'], "text"),
                       GetSQLValueString($_POST['nomb_product'], "text"),
					   GetSQLValueString($_POST['id_medida'], "int"),
					   GetSQLValueString($_POST['inventario'], "int"),
					   GetSQLValueString($_POST['lote'], "text"),
					   GetSQLValueString($_POST['precio_compra'], "int"),
                       GetSQLValueString($_POST['precio_venta'], "double"),
					   GetSQLValueString($_POST['cod_product'], "text"),
                       GetSQLValueString($_POST['activo'], "int"));

  mysql_select_db($database_conn, $conn);
  $Result1 = mysql_query($insertSQL, $conn) or die(mysql_error());

  $insertGoTo = "articulos.php";
  if (isset($_SERVER['QUERY_STRING'])) {
    $insertGoTo .= (strpos($insertGoTo, '?')) ? "&" : "?";
    $insertGoTo .= $_SERVER['QUERY_STRING'];
  }
  header(sprintf("Location: %s", $insertGoTo));
}
?>
<?php
mysql_select_db($database_conn, $conn);
$query_Recordset1 = "SELECT id_medida, medida FROM medida";
$Recordset1 = mysql_query($query_Recordset1, $conn) or die(mysql_error());
$row_Recordset1 = mysql_fetch_assoc($Recordset1);
$totalRows_Recordset1 = mysql_num_rows($Recordset1);

mysql_select_db($database_conn, $conn);
$query_cat = "SELECT id_categoria, categoria FROM categorias";
$cat = mysql_query($query_cat, $conn) or die(mysql_error());
$row_cat = mysql_fetch_assoc($cat);
$totalRows_cat = mysql_num_rows($cat);
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
body {
	background-image: url();
}
</style>
<!-- InstanceEndEditable -->
</head>

<body>
<!-- InstanceBeginEditable name="EditRegion3" -->
<?php include('menu.php'); ?>
<p>&nbsp;</p>
<form action="<?php echo $editFormAction; ?>" method="post" name="form1" id="form1">
<table align="left">
    <tr valign="baseline">
      <td width="147" align="right" nowrap="nowrap">Categoria:</td>
      <td width="294"><select name="id_categoria">
        <?php 
do {  
?>
        <option value="<?php echo $row_cat['id_categoria']?>" ><?php echo $row_cat['categoria']?></option>
        <?php
} while ($row_cat = mysql_fetch_assoc($cat));
?>
      </select></td>
    </tr>
    <tr valign="baseline">
      <td nowrap="nowrap" align="right">IVA:</td>
      <td><input name="iva" type="text" value="0" size="5" maxlength="5" /></td>
    </tr>
    <tr valign="baseline">
      <td nowrap="nowrap" align="right">Nombre deProducto:</td>
      <td><input type="text" name="nomb_product" value="" size="32" /></td>
    </tr>
    <tr valign="baseline">
      <td nowrap="nowrap" align="right">Familia:</td>
      <td><input type="text" name="familia" value="0" size="32" /></td>
    </tr>
    <tr valign="baseline">
      <td nowrap="nowrap" align="right">Tipo de medida:</td>
      <td><select name="id_medida">
        <?php 
do {  
?>
        <option value="<?php echo $row_Recordset1['id_medida']?>" ><?php echo $row_Recordset1['medida']?></option>
        <?php
} while ($row_Recordset1 = mysql_fetch_assoc($Recordset1));
?>
      </select></td>
    </tr>
    <tr valign="baseline">
      <td nowrap="nowrap" align="right">Cantidad:</td>
      <td><input type="text" name="inventario" value="0" size="32" /></td>
    </tr>
    <tr valign="baseline">
      <td nowrap="nowrap" align="right">Lote:</td>
      <td><input type="text" name="lote" value="0" size="32" /></td>
    </tr>
    <tr valign="baseline">
      <td nowrap="nowrap" align="right">Precio de compra:</td>
      <td><input type="text" name="precio_compra" value="0" size="32" /></td>
    </tr>
    <tr valign="baseline">
      <td nowrap="nowrap" align="right">Precio Venta:</td>
      <td><input type="text" name="precio_venta" value="" size="32" /></td>
    </tr>
    <tr valign="baseline">
      <td align="right" valign="middle" nowrap="nowrap">Activo:</td>
      <td valign="baseline"><table>
        <tr>
          <td><input name="activo" type="radio" value="1" checked="checked" />
            Activo</td>
        </tr>
        <tr>
          <td><input type="radio" name="activo" value="0" />
            Inactivo</td>
        </tr>
      </table></td>
    </tr>
    <tr valign="baseline">
      <td nowrap="nowrap" align="right">Codigo:</td>
      <td><input type="text" name="cod_product" value="" size="32" /></td>
    </tr>
    <tr valign="baseline">
      <td nowrap="nowrap" align="right">&nbsp;</td>
      <td><p>&nbsp;</p>
        <p>
          <input type="submit" value="&lt;&lt;&lt; CREAR ARTICULO &gt;&gt;&gt;" />
      </p></td>
    </tr>
  </table>
  <input type="hidden" name="MM_insert" value="form1" />
</form>
<p>&nbsp;</p>
<br />


<!-- InstanceEndEditable -->
</body>
<!-- InstanceEnd --></html>
<?php
mysql_free_result($Recordset1);

mysql_free_result($cat);
?>
