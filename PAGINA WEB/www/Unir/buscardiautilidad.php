<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml"><!-- InstanceBegin template="/Templates/inicio.dwt.php" codeOutsideHTMLIsLocked="false" -->
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<!-- InstanceBeginEditable name="doctitle" -->
<title>SKYNET</title>
<!-- InstanceEndEditable -->
<link href="estilo.css" rel="stylesheet" type="text/css">
<!-- InstanceBeginEditable name="head" -->
<script type="text/javascript" src="calendar.js"></script>
    <script type="text/javascript" src="calendar-setup.js"></script>
    <script type="text/javascript" src="lang/calendar-en.js"></script>
     <style type="text/css"> 
    @import url("calendar-win2k-cold-1.css"); 
     </style>
<style type="text/css">
.letra_menu {
	color: #FFF;
}

</style>
<link href="SpryAssets/SpryValidationSelect.css" rel="stylesheet" type="text/css" />
<script src="SpryAssets/SpryValidationSelect.js" type="text/javascript"></script>
<script src="SpryAssets/SpryValidationTextField.js" type="text/javascript"></script>
<link href="SpryAssets/SpryValidationTextField.css" rel="stylesheet" type="text/css" />
<!-- InstanceEndEditable -->
</head>

<body>
<!-- InstanceBeginEditable name="EditRegion3" -->
<?php include('menu.php'); ?>
<p>
  <?php
$report=$_GET['report'];
?>
  <br />
  <br />
</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><strong>Ingrese la fecha de hoy para saber la utilidad del dia</strong><br />
  <br />
</p>
<form action="reporte_total_diautili.php" method="get">
  <table width="481" border="0" class="tabla">
    <tr>
      <td width="100">Fecha Desde</td>
      <td width="151" align="left"><span id="sprytextfield1">
        <label for="fecha"></label>
        <input type="text" name="fecha" id="cal-field-2"/>
         <script type="text/javascript">
            Calendar.setup({
              inputField    : "cal-field-2",
              button        : "cal-button-2"
            });
                  </script>
        <span class="textfieldRequiredMsg">Se necesita un valor.</span></span>
    
    <tr>
      <td colspan="4" align="center"><input type="submit" name="button" id="button" value="Generar Reporte" /></td>
    </tr>
  </table>
</form>
<script type="text/javascript">
var sprytextfield1 = new Spry.Widget.ValidationTextField("sprytextfield1");

</script>
<!-- InstanceEndEditable -->
</body>
<!-- InstanceEnd --></html>

