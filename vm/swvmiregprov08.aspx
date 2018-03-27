<%@ Page Language="C#" MasterPageFile="~/index.master" AutoEventWireup="true" CodeFile="swvmiregprov08.aspx.cs" Inherits="swvmiregprov08" Title="Registro de Proveedores - ViveroMarket" %>
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
                Registre sus datos y acceda a los siguientes servicios:<br />
                Ofrecer sus productos en nuestro sitio Web, administrar sus productos y datos desde el Area de Admnistración de Vivero
                Market.</p>
                <p class="regcli">
                Al presionar el botón enviar usted acepta todo los términos y condiciones que Vivero
                    Market detallada <a href="swvmpterminos13.aspx">aquí</a>.</p>
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
                    &nbsp; &nbsp; Registro de Proveedores</h2> </td>
        </tr>
        <tr>
            <td style="width: 28px; height: 3px;">
            </td>
            <td style="width: 131px; height: 3px;">
            </td>
            <td style="width: 298px; height: 3px;">
            </td>
            <td class="rcli" rowspan="1" style="width: 291px; height: 3px;" valign="top">
            </td>
        </tr>
        <tr>
            <td style="width: 28px; height: 11px;">
            </td>
            <td style="width: 131px; height: 11px;">
                <asp:Label ID="lblRuc" runat="server" Text="Ruc" Font-Bold="False" Font-Names="Tahoma"></asp:Label></td>
                
            <td style="width: 298px;">
                <asp:TextBox ID="txtRuc" runat="server" Width="238px" MaxLength="13" onkeypress="javascript:return numeros(event)"></asp:TextBox>
                *
                <asp:RequiredFieldValidator ID="rfvRuc" runat="server" ErrorMessage="Introducir Ruc" ControlToValidate="txtRuc" Font-Size="12pt" ForeColor="Yellow">*</asp:RequiredFieldValidator>
                <asp:CustomValidator ID="cvRuc" runat="server" ControlToValidate="txtRuc" Font-Size="12pt"
                    ForeColor="Yellow" OnServerValidate="cvRuc_ServerValidate">*</asp:CustomValidator></td>
            <td style="width: 291px;" rowspan="14" class="rcli" valign="top">
                &nbsp;
                <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                <asp:ValidationSummary ID="vsregprov" runat="server" Font-Bold="False"
                    ForeColor="" HeaderText="Resumen de Errores" />
            </td>
        </tr>
        <tr>
            <td style="width: 28px; height: 11px">
            </td>
            <td style="width: 131px; height: 11px">
                <asp:Label ID="lblEmpresa" runat="server" Text="Empresa"></asp:Label></td>
            <td style="width: 298px">
                <asp:TextBox ID="txtEmpresa" runat="server" MaxLength="13" onkeypress="javascript:return letras(event)"
                    Width="238px" onkeyup="this.value=this.value.toUpperCase();javascript:return unespacio(this);"></asp:TextBox>
                *
                <asp:RequiredFieldValidator ID="rfvEmpresa" runat="server" ControlToValidate="txtEmpresa"
                    ErrorMessage="Introducir Nombre de la Empresa" Font-Size="12pt" ForeColor="Yellow">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 28px">
            </td>
            <td style="width: 131px">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre Completo"></asp:Label></td>
            <td style="width: 298px">
                <asp:TextBox ID="txtNombre" runat="server" Width="238px" onkeypress="javascript:return letras(event)" onkeyup="this.value=this.value.toUpperCase();javascript:return unespacio(this);"></asp:TextBox>
                *
                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre"
                    ErrorMessage="Introducir Nombre" Font-Size="12pt" ForeColor="Yellow">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 28px">
            </td>
            <td style="width: 131px">
                <asp:Label ID="lblCargo" runat="server" Text="Cargo"></asp:Label></td>
            <td style="width: 298px">
                <asp:TextBox ID="txtCargo" runat="server" onkeypress="javascript:return letras(event)"
                    onkeyup="this.value=this.value.toUpperCase();javascript:return unespacio(this);" Width="238px"></asp:TextBox>
                *
                <asp:RequiredFieldValidator ID="rfvCargo" runat="server" ControlToValidate="txtCargo"
                    ErrorMessage="Introducir su Cargo" Font-Size="12pt"
                    ForeColor="Yellow">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 28px">
            </td>
            <td style="width: 131px">
                <asp:Label ID="lblPais" runat="server" Text="Pais"></asp:Label></td>
            <td style="width: 298px">
                <asp:TextBox ID="txtPais" runat="server" onkeypress="javascript:return letras(event)"
                    onkeyup="this.value=this.value.toUpperCase();javascript:return unespacio(this);" Width="238px"></asp:TextBox>
                *
                <asp:RequiredFieldValidator ID="rfvPais" runat="server" ControlToValidate="txtPais"
                    ErrorMessage="Introducir Pais" Font-Size="12pt" ForeColor="Yellow">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 28px;">
            </td>
            <td style="width: 131px;">
                <asp:Label ID="lblProvincia" runat="server" Text="Provincia"></asp:Label></td>
            <td style="width: 298px;">
                <asp:TextBox ID="txtProvincia" runat="server" onkeypress="javascript:return letras(event)"
                    onkeyup="this.value=this.value.toUpperCase();javascript:return unespacio(this);" Width="238px"></asp:TextBox>
                *
                <asp:RequiredFieldValidator ID="rfvProvincia" runat="server" ControlToValidate="txtProvincia"
                    ErrorMessage="Introducir Provincia" Font-Size="12pt" ForeColor="Yellow">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 28px; height: 18px;">
            </td>
            <td style="width: 131px; height: 18px;">
                <asp:Label ID="lblCiudad" runat="server" Text="Ciudad"></asp:Label></td>
            <td style="width: 298px;">
                <asp:TextBox ID="txtCiudad" runat="server" Width="238px" onkeypress="javascript:return letras(event)" onkeyup="this.value=this.value.toUpperCase();javascript:return unespacio(this);"></asp:TextBox>
                *
                <asp:RequiredFieldValidator ID="rfvCiudad" runat="server" ControlToValidate="txtCiudad"
                    ErrorMessage="Introducir Ciudad" Font-Size="12pt" ForeColor="Yellow">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 28px; height: 26px;">
            </td>
            <td style="width: 131px; height: 26px;">
                <asp:Label ID="lblDir" runat="server" Text="Dirección"></asp:Label></td>
            <td style="width: 298px;">
                <asp:TextBox ID="txtDir" runat="server" Width="238px" onkeyup="this.value=this.value.toUpperCase();javascript:return unespacio(this);"></asp:TextBox>
                *
                <asp:RequiredFieldValidator ID="rfvdir" runat="server" ControlToValidate="txtDir"
                    ErrorMessage="Introducir Dirección" Font-Size="12pt" ForeColor="Yellow">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 28px">
            </td>
            <td style="width: 131px">
                <asp:Label ID="lblFono1" runat="server" Text="Teléfono 1"></asp:Label></td>
            <td style="width: 298px">
                <asp:TextBox ID="txtFono1" runat="server" Width="238px" onkeypress="javascript:return numeros(event)"></asp:TextBox>
                *
                <asp:RequiredFieldValidator ID="rfvFono1" runat="server" ControlToValidate="txtFono1"
                    ErrorMessage="Introducir Teléfono" Font-Size="12pt" ForeColor="Yellow">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 28px;">
            </td>
            <td style="width: 131px;">
                <asp:Label ID="lblFono2" runat="server" Text="Teléfono 2" onkeypress="javascript:return numeros(event)"></asp:Label></td>
            <td style="width: 298px;">
                <asp:TextBox ID="txtFono2" runat="server" Width="238px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 28px; height: 3px;">
            </td>
            <td style="width: 131px; height: 3px;">
                <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label></td>
            <td style="width: 298px;">
                <asp:TextBox ID="txtEmail" runat="server" Width="238px" onkeyup="this.value=this.value.toLowerCase();javascript:return noespacio(this);"></asp:TextBox>
                *
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="Introducir  Email" Font-Size="12pt" ForeColor="Yellow">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="Formato de correo inválido" ForeColor="Yellow" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Font-Size="12pt">*</asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td style="width: 28px;">
            </td>
            <td style="width: 131px;">
                <asp:Label ID="lblClave" runat="server" Text="Contraseña"></asp:Label></td>
            <td style="width: 298px;">
                <asp:TextBox ID="txtClave" runat="server" Width="238px" TextMode="Password" ></asp:TextBox>
                *
                <asp:RequiredFieldValidator ID="rfvClave" runat="server" ControlToValidate="txtClave"
                    ErrorMessage="Introducir Contraseña" Font-Size="12pt" ForeColor="Yellow">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 28px">
            </td>
            <td style="width: 131px">
                <asp:Label ID="lblRClave" runat="server" Text="Confirmar Contraseña"></asp:Label></td>
            <td style="width: 298px">
                <asp:TextBox ID="txtRClave" runat="server" Width="238px" TextMode="Password" ></asp:TextBox>
                *
                <asp:CompareValidator ID="cvRClave" runat="server" ControlToCompare="txtClave"
                    ControlToValidate="txtRClave" ErrorMessage="Contraseñas diferentes" Font-Size="12pt"
                    ForeColor="Yellow">*</asp:CompareValidator></td>
        </tr>
        <tr>
            <td style="width: 28px;">
            </td>
            <td style="width: 131px;">
            </td>
            <td style="width: 298px;">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 28px;">
            </td>
            <td colspan="2">
                &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;<asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="ButtonEnviar_Click" />
                &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;<asp:Button ID="btnLimpiar" runat="server" OnClick="ButtonLimpiar_Click" Text="Limpiar" CausesValidation="False" /></td>                
            <td style="width: 291px;" valign="top">
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <span style="font-size: 11pt">&nbsp;</span><span style="font-size: 9pt">*</span><span
                    style="font-size: 11pt"> </span><span style="font-size: 9pt">Campos obligatorios</span></td>
            <td style="width: 291px" valign="top">
            </td>
        </tr>
    </table>
</asp:Content>

