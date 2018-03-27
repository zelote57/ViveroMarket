<%@ Page Language="C#" AutoEventWireup="true" CodeFile="swvmmrecoverypass00.aspx.cs" Inherits="swvmmrecoverypass00" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Vivero Market - Administración</title>
    <link href="estilo.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%">
            <tr>
                <td colspan="3" style="height: 16px; background-color: #313131">
                </td>
            </tr>
            <tr>
                <td colspan="3" rowspan="4" style="height: 24px; background-color: #313131; border-bottom: black thin solid;">
                <img src="images/logo.png" />&nbsp;</td>
            </tr>
            <tr>
            </tr>
            <tr>
            </tr>
            <tr>
            </tr>
        </table>
    
    </div>
        <table align="center" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td style="width: 161px; height: 10px">
                </td>
                <td style="width: 27px; height: 10px;">
                </td>
                <td style="width: 640px; height: 10px;">
                </td>
                <td style="width: 15px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="width: 161px; height: 16px">
                </td>
                <td style="border-top: white thin solid; border-left: white thin solid; width: 27px;
                    height: 16px; background-color: #313131">
                </td>
                <td style="border-top: white thin solid; width: 640px; height: 16px; background-color: #313131">
                </td>
                <td style="border-right: white thin solid; border-top: white thin solid; width: 15px;
                    height: 16px; background-color: #313131">
                </td>
                <td style="width: 100px; height: 16px">
                </td>
            </tr>
            <tr>
                <td style="width: 161px; height: 16px">
                </td>
                <td style="width: 27px; height: 16px; border-left: white thin solid; background-color: #313131;">
                </td>
                <td style="width: 640px; height: 16px; background-color: #313131;">
                    Para recuperar su contraseña por favor escriba en el casillero
                        Email
                        la cuenta de correo con la que se registró.<br />
                    Luego por favor seleccione el tipo de Usuario que es usted, y presione el boton
                    Enviar.<br />
                    <br />
                    Completados estos pasos revise su bandeja de entrada donde encontrará el correo
                    que enviarémos con
                    su contraseña .</td>
                <td style="border-right: white thin solid; width: 15px; height: 16px; background-color: #313131">
                </td>
                <td style="width: 100px; height: 16px">
                </td>
            </tr>
            <tr>
                <td style="width: 161px; height: 16px">
                </td>
                <td style="border-left: white thin solid; width: 27px; border-bottom: white thin solid;
                    height: 16px; background-color: #313131">
                </td>
                <td style="width: 640px; border-bottom: white thin solid; height: 16px; background-color: #313131">
                </td>
                <td style="border-right: white thin solid; width: 15px; border-bottom: white thin solid;
                    height: 16px; background-color: #313131">
                </td>
                <td style="width: 100px; height: 16px">
                </td>
            </tr>
            <tr>
                <td style="width: 161px">
                </td>
                <td style="width: 27px">
                </td>
                <td style="width: 640px">
                </td>
                <td style="width: 15px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
        </table>
        <table align="center" style="background-color: transparent; color: #ffffff;" border="0" cellpadding="0" cellspacing="0" >
            <tr>
                <td colspan="1" style="width: 20px; height: 20px; text-align: right">
                </td>
                <td colspan="3" style="height: 20px; text-align: left">
                    <span></span></td>
                <td colspan="1" style="width: 25px; height: 20px; text-align: right">
                </td>
            </tr>
            <tr>
                <td colspan="1" style="border-top: #000000 thin solid; border-left: black thin solid;
                    width: 20px; height: 23px; background-color: #313131">
                </td>
                <td colspan="3" style="border-top: #000000 thin solid; height: 23px; background-color: #313131; text-align: center;">
                </td>
                <td colspan="1" style="border-right: black thin solid; border-top: #000000 thin solid;
                    width: 25px; height: 23px; background-color: #313131">
                </td>
            </tr>
            <tr>
                <td colspan="1" style="border-left: black thin solid; width: 20px; height: 15px;
                    background-color: #313131">
                </td>
                <td colspan="3" style="height: 15px; background-color: #313131; text-align: center">
                    Tipo de Usuario</td>
                <td colspan="1" style="border-right: black thin solid; width: 25px; height: 15px;
                    background-color: #313131">
                </td>
            </tr>
            <tr>
                <td colspan="1" style="border-left: black thin solid; width: 20px; height: 3px; background-color: #313131">
                </td>
                <td colspan="3" style="height: 3px; background-color: #313131; text-align: left">
                </td>
                <td colspan="1" style="border-right: black thin solid; width: 25px; height: 3px;
                    background-color: #313131">
                </td>
            </tr>
            <tr>
                <td colspan="1" style="border-left: black thin solid; width: 20px; height: 48px;
                    background-color: #313131">
                </td>
                <td colspan="3" style="height: 48px; background-color: #313131; text-align: center">
                    <asp:RadioButtonList ID="rbList" runat="server" RepeatDirection="Horizontal" Width="224px">
                        <asp:ListItem Selected="True" Value="0">Administrador</asp:ListItem>
                        <asp:ListItem Value="1">Proveedor</asp:ListItem>
                    </asp:RadioButtonList></td>
                <td colspan="1" style="border-right: black thin solid; width: 25px; height: 48px;
                    background-color: #313131">
                </td>
            </tr>
            <tr>
                <td style="border-left: black thin solid; width: 20px; background-color: #313131">
                </td>
                <td style="width: 47px; text-align: right; background-color: #313131;">
                    Email</td>
                <td style="width: 10px; background-color: #313131; text-align: right">
                </td>
                <td style="width: 194px; background-color: #313131;">
                    <asp:TextBox ID="txtEmail" runat="server" Width="147px"></asp:TextBox><asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                        ErrorMessage="Escriba un Email válido" ForeColor="DarkGoldenrod" Display="Dynamic">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator
                            ID="revEmail" runat="server" ControlToValidate="txtEmail"
                            ErrorMessage="Formato de Email Invalido" ForeColor="DarkGoldenrod" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator></td>
                <td style="border-right: black thin solid; width: 25px; background-color: #313131">
                </td>
            </tr>
            <tr>
                <td style="border-left: black thin solid; width: 20px; height: 10px; background-color: #313131">
                </td>
                <td style="width: 47px; height: 10px; background-color: #313131">
                </td>
                <td style="width: 10px; height: 10px; background-color: #313131">
                </td>
                <td style="width: 194px; height: 10px; background-color: #313131">
                </td>
                <td style="border-right: black thin solid; width: 25px; height: 10px; background-color: #313131">
                </td>
            </tr>
            <tr>
                <td colspan="1" style="border-left: black thin solid; width: 20px; height: 24px;
                    background-color: #313131; text-align: right">
                </td>
                <td colspan="3" style="height: 24px; text-align: right; background-color: #313131;">
                    <asp:Button ID="bntEnviar" runat="server" OnClick="bntEnviar_Click" Text="Enviar" /></td>
                <td colspan="1" style="border-right: black thin solid; width: 25px; height: 24px;
                    background-color: #313131; text-align: right">
                </td>
            </tr>
            <tr>
                <td colspan="1" style="border-left: black thin solid; width: 20px; height: 5px; background-color: #313131;
                    text-align: right">
                </td>
                <td colspan="3" style="height: 5px; background-color: #313131; text-align: right">
                </td>
                <td colspan="1" style="border-right: black thin solid; width: 25px; height: 5px;
                    background-color: #313131; text-align: right">
                </td>
            </tr>
            <tr>
                <td colspan="1" style="border-left: black thin solid; width: 20px; height: 18px;
                    background-color: #313131; text-align: right">
                </td>
                <td colspan="3" style="text-align: right; height: 18px; background-color: #313131;">
                    <asp:ValidationSummary ID="vslogin" runat="server" ForeColor="DarkGoldenrod" />
                    &nbsp;&nbsp;<asp:Label ID="lblMsg" runat="server" ForeColor="DarkGoldenrod"></asp:Label>&nbsp;</td>
                <td colspan="1" style="border-right: black thin solid; width: 25px; height: 18px;
                    background-color: #313131; text-align: right">
                </td>
            </tr>
            <tr>
                <td colspan="1" style="border-left: black thin solid; width: 20px; border-bottom: black thin solid;
                    height: 13px; background-color: #313131">
                </td>
                <td colspan="3" style="border-bottom: black thin solid; height: 13px; background-color: #313131;">
                </td>
                <td colspan="1" style="border-right: black thin solid; width: 25px; border-bottom: black thin solid;
                    height: 13px; background-color: #313131">
                </td>
            </tr>
        </table>
        <br />
        <br />
    </form>
</body>
</html>
