<?php require_once('Connections/conn.php'); ?>
<?php
// *** Validate request to login to this site.

$loginFormAction = $_SERVER['PHP_SELF'];
if (isset($_GET['accesscheck'])) {
  $_SESSION['PrevUrl'] = $_GET['accesscheck'];
}

if (isset($_POST['usuario'])) {
  $loginUsername=$_POST['usuario'];
  $password=$_POST['clave'];
  $MM_fldUserAuthorization = "";
  $MM_redirectLoginSuccess = "inicio.php";
  $MM_redirectLoginFailed = "index.php";
  $MM_redirecttoReferrer = false;
  mysql_select_db($database_conn, $conn);
  
  $LoginRS__query=sprintf("SELECT user, clave FROM usuarios WHERE user='%s' AND clave='%s' AND  id_tipouser=1",
    get_magic_quotes_gpc() ? $loginUsername : addslashes($loginUsername), get_magic_quotes_gpc() ? $password : addslashes($password)); 
   
  $LoginRS = mysql_query($LoginRS__query, $conn) or die(mysql_error());
  $loginFoundUser = mysql_num_rows($LoginRS);
  if ($loginFoundUser) {
     $loginStrGroup = "";
    
    //declare two session variables and assign them
    $_SESSION['MM_Username'] = $loginUsername;
    $_SESSION['MM_UserGroup'] = $loginStrGroup;	      

    if (isset($_SESSION['PrevUrl']) && false) {
      $MM_redirectLoginSuccess = $_SESSION['PrevUrl'];	
    }
    header("Location: " . $MM_redirectLoginSuccess );
  }
  else {
    header("Location: ". $MM_redirectLoginFailed );
  }
}
?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<!-- DW6 -->
<head>
<link href="SpryAssets/SpryMenuBarHorizontal.css" rel="stylesheet" type="text/css" />
    <style>
    .letter {
  font-family: 'Tangerine', serif;
  font-size: 48px;
  text-shadow: 4px 4px 4px #aaa;
}
    .small {
	font-size: xx-small;
	color: #5B94EE;
}
    .fondo {
	color: #FFF;
}
    .fondo {
	color: #88BE4C;
}
    </style>
<title>SKYNET 4.0</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link href="SpryAssets/SpryValidationTextField.css" rel="stylesheet" type="text/css" />
<link href="SpryAssets/SpryValidationPassword.css" rel="stylesheet" type="text/css" />
<script src="SpryAssets/SpryValidationTextField.js" type="text/javascript"></script>
<script src="SpryAssets/SpryValidationPassword.js" type="text/javascript"></script>
<link href="estilo.css" rel="stylesheet" type="text/css" />
<style type="text/css">
<!--
body {
	background-image: url(img/Fondo-color-verde-688051.jpeg);
	background-repeat: no-repeat;
	background-color: #006633;
}
.Estilo6 {
	color: #FFFF00;
	font-family: Georgia, "Times New Roman", Times, serif;
	font-weight: bold;
	font-style: italic;
}
.Estilo8 {color: #FFFFFF; font-size: 36px; }
.Estilo9 {color: #FFFFFF}
.Estilo10 {color: #FFFF00}
-->
</style></head>
<body class="fondo">
<div align="center">
<p class="letter">&nbsp;</p>
<p class="ses">&nbsp;</p>
<p class="ses"><img src="img/LOGO SKYNET.jpg" width="256" height="248" /><br />
</p>
<div align="center">
  <form action="<?php echo $loginFormAction; ?>" method="POST">
<table width="460" height="251" border="0" align="center" cellpadding="1" cellspacing="1">
    <tr>
      <td width="84"><div align="left" class="Estilo10">NOMBRE:</div></td>
      <td width="319" align="left" bordercolor="#3300FF">
        <label for="usuario"></label>
        <span class="textfieldRequiredMsg">*</span><span id="sprytextfield2">
        <label for="usuario2"></label>
        <span class="textfieldRequiredMsg">*</span><span id="sprytextfield2">
        <input maxlength="10" type="text" name="usuario" id="usuario2" />
        </span></span></td>
    </tr>
    <tr>
      <td><div align="left"><span class="Estilo6">CLAVE:</span></div></td>
      <td align="left">
        <label for="clave"></label>
        <span class="passwordRequiredMsg">*</span><span id="sprypassword2">
        <label for="clave2"></label>
        <input maxlength="15" type="password" name="clave" id="clave2" />
        <span class="passwordRequiredMsg">*	</span></span></td>
    </tr>
    <tr>
      <td><div align="left"></div></td><td align="center"><div align="left">
        <input type="submit" name="button" id="button" value="ENTRAR" />
      </div></td>
    </tr>
  </table>
</form>
</div>

<p></p>
<p></p>
<p></p>
<p></p>
<p></p>
<p></p>
<p></p>
<span class="Estilo9"> ING. FERNEY GOMEZ RODRIGUEZ 3134572408</span>
<span class="Estilo9">
<script type="text/javascript">
var sprytextfield2 = new Spry.Widget.ValidationTextField("sprytextfield2");
var sprypassword2 = new Spry.Widget.ValidationPassword("sprypassword2");
</script>
</span>
</body>
</html>
