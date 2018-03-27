<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<style type="text/css">
body{
	font-family:"Lucida Grande", "Lucida Sans Unicode", Verdana, Arial, Helvetica, sans-serif; 
	font-size:11px;
}
a.button{
	background:url(images/button.gif);
	display:block;
	color:#555555;
	font-weight:bold;
	height:30px;
	line-height:29px;
	margin-bottom:14px;
	text-decoration:none;
	width:191px;
	text-align:center;
}
a:hover.button{
	color:#0066CC;
}

/* Clase Boton */
	.skipintro{
		background:url(images/delete.gif) no-repeat 10px 8px;
		text-indent:30px;
		display:block;
	}
	
	.admin{
		background:url(images/admin.png) no-repeat 10px 8px;
		text-indent:30px;
		display:block;
	}
	
</style>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Vivero Market</title>
</head>

<body style="text-align: center">
    <form id="form1" runat="server">
    <object width="600" height="600">
<param name="movie" value="images/intro.swf">
<embed src="flash/intro.swf" width="600" height="600">
</embed></object><br />
        <table align="center">
            <tr>
                <td style="width: 100px; height: 17px;">
                <a href="swvmphome01.aspx" class="button"><span class="skipintro">Escapar Intro</span></a>
                    </td>
                <td style="width: 15px; height: 17px;">
                    </td>
                <td style="width: 100px; height: 17px;">
                <a href="http://admin.viveromarket.com/" target="_blank" class="button"><span class="admin">Area de Administración</span></a>
                </td>
            </tr>
        </table>  
    </form>
</body>
</html>
