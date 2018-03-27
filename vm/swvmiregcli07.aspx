<%@ Page Language="C#" MasterPageFile="~/index.master" AutoEventWireup="true" CodeFile="swvmiregcli07.aspx.cs" Inherits="swvmiregcli07" Title="Registro de Clientes - ViveroMarket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      
    <table style="width: 672px; height: 159px" class="ferror">
        <tr>
            <td align="left" colspan="4" style="height: 8px; background-color: darkolivegreen;" valign="middle">
            </td>
        </tr>
        <tr>
            <td align="left" colspan="4" style="height: 8px" valign="middle">
            </td>
        </tr>
        <tr>
            <td align="left" colspan="4" style="height: 8px; text-align: justify" valign="middle">
            <p class="regcli">
                Mediante el siguiente Formulario usted puede ingresar sus datos personales y ser parte
                de nuestros clientes.<br />
                Así podrá utilizar los siguientes servicios:<br />
                Cotizar directamente desde nuestro sitio Web y participar de las ofertas de Vivero
                Market.</p>
                <p class="regcli">
                    &nbsp;</p>
                <p class="regcli">
                Al presionar el botón enviar usted acepta todo los términos y condiciones que Vivero
                    Market detallada <a href="swvmpterminos13.aspx">aquí</a>.</p>
                <p class="regcli">
                        Vivero Market garantiza la total confidencialidad de los datos proporcionados por
                    sus Clientes.<br />
                </p>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="4" style="height: 8px" valign="middle">
            </td>
        </tr>
        <tr>
            <td align="left" colspan="4" style="height: 8px; background-color: darkolivegreen"
                valign="middle">
            </td>
        </tr>
        <tr>
            <td align="left" colspan="4" style="height: 8px" valign="middle">
            </td>
        </tr>
        <tr>
            <td align="left" colspan="4" valign="middle" style="height: 8px">
                <h2>
                    &nbsp; &nbsp; Registro de Clientes</h2> </td>
        </tr>
        <tr>
            <td style="width: 31px; height: 2px;">
            </td>
            <td style="width: 140px; height: 2px;">
            </td>
            <td style="width: 325px; height: 2px;">
            </td>
            <td class="rcli" rowspan="1" style="width: 240px; height: 2px;" valign="top">
            </td>
        </tr>
        <tr>
            <td style="width: 31px; height: 11px;">
            </td>
            <td style="width: 140px; height: 11px;">
                <asp:Label ID="lblCiruc" runat="server" Text="Cédula o Ruc" Font-Bold="False" Font-Names="Tahoma"></asp:Label></td>
                
            <td style="width: 325px;">
                <asp:TextBox ID="txtCiruc" runat="server" Width="238px" MaxLength="13" onkeypress="javascript:return numeros(event)"></asp:TextBox>
                *
                <asp:RequiredFieldValidator ID="rfvCiruc" runat="server" ErrorMessage="Introducir Cédula o Ruc" ControlToValidate="txtCiruc" Font-Size="12pt" ForeColor="Yellow">*</asp:RequiredFieldValidator>
                <asp:CustomValidator ID="cvCiruc" runat="server" ControlToValidate="txtCiruc" Font-Size="12pt"
                    ForeColor="Yellow" OnServerValidate="cvCiruc_ServerValidate" Width="1px">*</asp:CustomValidator></td>
            <td style="width: 240px;" rowspan="11" class="rcli" valign="top">
                &nbsp;
                <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                <asp:ValidationSummary ID="vsRegcli" runat="server" Font-Bold="False"
                    ForeColor="" HeaderText="Resumen de Errores" />
            </td>
        </tr>
        <tr>
            <td style="width: 31px">
            </td>
            <td style="width: 140px">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre Completo"></asp:Label></td>
            <td style="width: 325px; font-size: 9pt;">
                <asp:TextBox ID="txtNombre" runat="server" Width="238px" onkeypress="javascript:return letras(event)" onkeyup="this.value=this.value.toUpperCase();javascript:return unespacio(this);"></asp:TextBox>
                *
                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre"
                    ErrorMessage="Introducir Nombre" Font-Size="12pt" ForeColor="Yellow">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 31px;">
            </td>
            <td style="width: 140px;">
                <asp:Label ID="lblProvincia" runat="server" Text="Provincia"></asp:Label></td>
            <td style="width: 325px; font-size: 9pt;">
                <asp:DropDownList ID="ddlProvincia" runat="server" Width="242px" BackColor="#E3F6CE" CausesValidation="True">
                    <asp:ListItem Selected="True"></asp:ListItem>
                    <asp:ListItem>AZUAY</asp:ListItem>
                    <asp:ListItem>BOL&#205;VAR</asp:ListItem>
                    <asp:ListItem>CA&#209;AR</asp:ListItem>
                    <asp:ListItem>CARCHI</asp:ListItem>
                    <asp:ListItem>CHIMBORAZO</asp:ListItem>
                    <asp:ListItem>COTOPAXI</asp:ListItem>
                    <asp:ListItem>EL ORO</asp:ListItem>
                    <asp:ListItem>ESMERALDAS</asp:ListItem>
                    <asp:ListItem>GAL&#193;PAGOS</asp:ListItem>
                    <asp:ListItem>GUAYAS</asp:ListItem>
                    <asp:ListItem>IMBABURA</asp:ListItem>
                    <asp:ListItem>LOJA</asp:ListItem>
                    <asp:ListItem>LOS R&#205;OS</asp:ListItem>
                    <asp:ListItem>MANAB&#205;</asp:ListItem>
                    <asp:ListItem>MORONA SANTIAGO</asp:ListItem>
                    <asp:ListItem>NAPO</asp:ListItem>
                    <asp:ListItem>ORELLANA</asp:ListItem>
                    <asp:ListItem>PASTAZA</asp:ListItem>
                    <asp:ListItem>PICHINCHA</asp:ListItem>
                    <asp:ListItem>SANTA ELENA</asp:ListItem>
                    <asp:ListItem>STO. DOMINGO DE LOS TSACHILAS</asp:ListItem>
                    <asp:ListItem>SUCUMB&#205;OS</asp:ListItem>
                    <asp:ListItem>TUNGURAHUA</asp:ListItem>
                    <asp:ListItem>ZAMORA</asp:ListItem>
                    
                </asp:DropDownList>
                *
                <asp:RequiredFieldValidator ID="rfvProvincia" runat="server" ControlToValidate="ddlProvincia"
                    ErrorMessage="Introducir Provincia" Font-Size="12pt" ForeColor="Yellow">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 31px; height: 18px;">
            </td>
            <td style="width: 140px; height: 18px;">
                <asp:Label ID="lblCiudad" runat="server" Text="Ciudad"></asp:Label></td>
            <td style="width: 325px; font-size: 9pt;">
                <asp:TextBox ID="txtCiudad" runat="server" Width="238px" onkeypress="javascript:return letras(event)" onkeyup="this.value=this.value.toUpperCase();javascript:return unespacio(this);"></asp:TextBox>
                *
                <asp:RequiredFieldValidator ID="rfvCiudad" runat="server" ControlToValidate="txtCiudad"
                    ErrorMessage="Introducir Ciudad" Font-Size="12pt" ForeColor="Yellow">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 31px; height: 26px;">
            </td>
            <td style="width: 140px; height: 26px;">
                <asp:Label ID="lblDir" runat="server" Text="Dirección"></asp:Label></td>
            <td style="width: 325px; font-size: 9pt;">
                <asp:TextBox ID="txtDir" runat="server" Width="238px" onkeyup="this.value=this.value.toUpperCase();javascript:return unespacio(this);"></asp:TextBox>
                *
                <asp:RequiredFieldValidator ID="rfvDir" runat="server" ControlToValidate="txtDir"
                    ErrorMessage="Introducir Dirección" Font-Size="12pt" ForeColor="Yellow">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 31px">
            </td>
            <td style="width: 140px">
                <asp:Label ID="lblFono1" runat="server" Text="Teléfono 1"></asp:Label></td>
            <td style="width: 325px; font-size: 9pt;">
                <asp:TextBox ID="txtFono1" runat="server" Width="238px" onkeypress="javascript:return numeros(event)"></asp:TextBox>
                *
                <asp:RequiredFieldValidator ID="rfvFono1" runat="server" ControlToValidate="txtFono1"
                    ErrorMessage="Introducir Teléfono" Font-Size="12pt" ForeColor="Yellow">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 31px;">
            </td>
            <td style="width: 140px;">
                <asp:Label ID="lblFono2" runat="server" Text="Teléfono 2" onkeypress="javascript:return numeros(event)"></asp:Label></td>
            <td style="width: 325px;">
                <asp:TextBox ID="txtFono2" runat="server" Width="238px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 31px; height: 3px;">
            </td>
            <td style="width: 140px; height: 3px;">
                <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label></td>
            <td style="width: 325px; font-size: 9pt;">
                <asp:TextBox ID="txtEmail" runat="server" Width="238px" onkeyup="this.value=this.value.toLowerCase();javascript:return noespacio(this);"></asp:TextBox>
                *
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="Introducir  Email" Font-Size="12pt" ForeColor="Yellow">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="Formato de correo inválido" ForeColor="Yellow" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Font-Size="12pt">*</asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td style="width: 31px;">
            </td>
            <td style="width: 140px;">
                <asp:Label ID="lblClave" runat="server" Text="Contraseña"></asp:Label></td>
            <td style="width: 325px; font-size: 9pt;">
                <asp:TextBox ID="txtClave" runat="server" Width="238px" TextMode="Password" ></asp:TextBox>
                *
                <asp:RequiredFieldValidator ID="rfvClave" runat="server" ControlToValidate="txtClave"
                    ErrorMessage="Introducir Contraseña" Font-Size="12pt" ForeColor="Yellow">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 31px">
            </td>
            <td style="width: 140px">
                <asp:Label ID="lblRClave" runat="server" Text="Confirmar Contraseña"></asp:Label></td>
            <td style="width: 325px; font-size: 9pt;">
                <asp:TextBox ID="txtRClave" runat="server" Width="238px" TextMode="Password" ></asp:TextBox>
                *
                <asp:CompareValidator ID="cvRClave" runat="server" ControlToCompare="txtClave"
                    ControlToValidate="txtRClave" ErrorMessage="Contraseñas diferentes" Font-Size="12pt"
                    ForeColor="Yellow">*</asp:CompareValidator></td>
        </tr>
        <tr>
            <td style="width: 31px;">
            </td>
            <td style="width: 140px;">
            </td>
            <td style="width: 325px;">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 31px;">
            </td>
            <td colspan="2">
                &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;<asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="ButtonEnviar_Click" />
                &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;<asp:Button ID="btnLimpiar" runat="server" OnClick="ButtonLimpiar_Click" Text="Limpiar" CausesValidation="False" /></td>                
            <td style="width: 240px;" valign="top">
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <span style="font-size: 11pt">&nbsp;<span style="font-size: 9pt">*</span> <span style="font-size: 9pt">
                    Campos obligatorios</span></span></td>
            <td style="width: 240px" valign="top">
            </td>
        </tr>
    </table>
</asp:Content>

