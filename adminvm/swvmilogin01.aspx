<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="swvmilogin01.aspx.cs" Inherits="swvmilogin01" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
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
                <img src="images/logo.png" />
                    <span style="font-size: 24pt">Area de Administración</span></td>
            </tr>
            <tr>
            </tr>
            <tr>
            </tr>
            <tr>
            </tr>
        </table>
    
    </div>
        <table align="center" style="background-color: transparent" border="0" cellpadding="0" cellspacing="0" class="tabla">
            <tr>
                <td colspan="1" style="width: 20px; height: 45px; text-align: right">
                </td>
                <td colspan="3" style="height: 45px; text-align: right">
                </td>
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
                <td colspan="1" style="border-left: black thin solid; width: 20px; height: 24px;
                    background-color: #313131">
                </td>
                <td colspan="3" style="height: 24px; background-color: #313131; text-align: left;"><img src="images/candado.png" style="width: 47px; height: 43px" /><span style="font-size: 13pt">Acceso a la Administración</span></td>
                <td colspan="1" style="border-right: black thin solid; width: 25px; height: 24px;
                    background-color: #313131">
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
                <td style="width: 71px; text-align: right; background-color: #313131;">
                    <asp:Label ID="lblUser" runat="server" Text="Email:"></asp:Label></td>
                <td style="width: 10px; background-color: #313131; text-align: right">
                </td>
                <td style="width: 171px; background-color: #313131;">
                    <asp:TextBox ID="txtUser" runat="server" Width="147px"></asp:TextBox><asp:RequiredFieldValidator ID="rfvUser" runat="server" ControlToValidate="txtUser"
                        ErrorMessage="Escriba un Email válido" ForeColor="DarkGoldenrod" Display="Dynamic">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator
                            ID="revUser" runat="server" ControlToValidate="txtUser"
                            ErrorMessage="Formato de Email Invalido" ForeColor="DarkGoldenrod" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator></td>
                <td style="border-right: black thin solid; width: 25px; background-color: #313131">
                </td>
            </tr>
            <tr>
                <td style="border-left: black thin solid; width: 20px; height: 5px; background-color: #313131">
                </td>
                <td style="width: 71px; height: 5px; background-color: #313131">
                </td>
                <td style="width: 10px; height: 5px; background-color: #313131">
                </td>
                <td style="width: 171px; height: 5px; background-color: #313131">
                </td>
                <td style="border-right: black thin solid; width: 25px; height: 5px; background-color: #313131">
                </td>
            </tr>
            <tr>
                <td style="border-left: black thin solid; width: 20px; height: 23px; background-color: #313131">
                </td>
                <td style="width: 71px; text-align: right; height: 23px; background-color: #313131;">
                    <asp:Label ID="lblClave" runat="server" Text="Contraseña:"></asp:Label></td>
                <td style="width: 10px; height: 23px; background-color: #313131; text-align: right">
                </td>
                <td style="width: 171px; height: 23px; background-color: #313131;">
                    <asp:TextBox ID="txtClave" runat="server" TextMode="Password" Width="147px"></asp:TextBox><asp:RequiredFieldValidator ID="rfvClave" runat="server" ControlToValidate="txtClave"
                        ErrorMessage="Escriba Contraseña" ForeColor="DarkGoldenrod">*</asp:RequiredFieldValidator></td>
                <td style="border-right: black thin solid; width: 25px; height: 23px; background-color: #313131">
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
                <td colspan="1" style="border-left: black thin solid; width: 20px; height: 24px;
                    background-color: #313131; text-align: right">
                </td>
                <td colspan="3" style="height: 24px; text-align: right; background-color: #313131;">
                    <asp:Button ID="bntAcceder" runat="server" OnClick="LoginButton_Click" Text="Acceder" /></td>
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
                    &nbsp;<asp:Label ID="lblError" runat="server" ForeColor="DarkGoldenrod" Visible="False"></asp:Label></td>
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
