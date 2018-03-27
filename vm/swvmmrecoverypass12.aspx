<%@ Page Language="C#" AutoEventWireup="true" CodeFile="swvmmrecoverypass12.aspx.cs" Inherits="swvmmrecoverypass12" %>

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
            <tr>
                <td colspan="3" rowspan="1" style="border-bottom: black thin solid; height: 24px;
                    background-color: #313131; text-align: center">
                    <span style="color: #ffffff">Para recuperar su contraseña por favor escriba en el casillero
                        Email
                        la cuenta de correo con la que se registró. Nosotros le enviarémos su contraseña.</span></td>
            </tr>
        </table>
    
    </div>
        <table align="center" style="background-color: transparent; color: #ffffff;" border="0" cellpadding="0" cellspacing="0" >
            <tr>
                <td colspan="1" style="width: 20px; height: 45px; text-align: right">
                </td>
                <td colspan="3" style="height: 45px; text-align: left">
                    <span></span></td>
                <td colspan="1" style="width: 25px; height: 45px; text-align: right">
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
                <td colspan="3" style="height: 15px; background-color: #313131; text-align: left">
                </td>
                <td colspan="1" style="border-right: black thin solid; width: 25px; height: 15px;
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
                <td colspan="3" style="height: 24px; text-align: left; background-color: #313131;">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp;<asp:Button ID="bntEnviar" runat="server" OnClick="bntEnviar_Click" Text="Enviar" /></td>
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
    </form>
</body>
</html>
