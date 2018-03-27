<%@ Page Language="C#" MasterPageFile="~/index.master" AutoEventWireup="true" CodeFile="swvmmcuentaprov01.aspx.cs" Inherits="swvmmcuentaprov01" Title="Mi Cuenta - Vivero Market" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphIndex" Runat="Server">
    <table style="width: 763px; height: 34px; top: 150px;">
        <tr>
            <td colspan="9" style="height: 9px; background-color: black">
            </td>
        </tr>
        <tr>
            <td colspan="9">
                <strong>&nbsp; &nbsp; &nbsp; Datos de Cuenta Proveedor</strong></td>
        </tr>
        <tr>
            <td style="border-top: black thin solid;" colspan="9">
            </td>
        </tr>
        <tr>
            <td colspan="1" style="width: 18px; height: 28px">
            </td>
            <td style="height: 28px;" colspan="9">
                &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<asp:Button ID="btnModificar" runat="server" OnClick="btnModificar_Click"
                    Text="   Modificar" CausesValidation="False" BorderStyle="Solid" CssClass="btnmodify " />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Button ID="btnGuardar" runat="server" Text="   Guardar" Enabled="False" OnClick="btnGuardar_Click" BorderStyle="Solid" CssClass="btnsave" />
                &nbsp; &nbsp; &nbsp; &nbsp;<asp:Button ID="btnCancelar" runat="server" Text="   Cancelar" Enabled="False" OnClick="bntCancelar_Click" BorderStyle="Solid" CssClass="btncancel" CausesValidation="false" /></td>
        </tr>
        <tr>
            <td colspan="9" style="border-top: black thin solid; height: 21px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 18px;">
            </td>
            <td style="width: 139px; text-align: right;">
                Empresa:</td>
            <td style="width: 33px;">
            </td>
            <td style="width: 158px;">
                <asp:TextBox ID="txtEmpresa" runat="server" ReadOnly="True" onkeypress="javascript:return letras(event)" onkeyup="this.value=this.value.toUpperCase();javascript:return unespacio(this);" Width="147px"></asp:TextBox></td>
            <td style="width: 26px;">
                <asp:RequiredFieldValidator ID="rfvEmpresa" runat="server" ControlToValidate="txtEmpresa"
                    ForeColor="White">*</asp:RequiredFieldValidator></td>
            <td style="width: 190px; text-align: right;">
                Nombre Contacto:</td>
            <td style="width: 33px;">
            </td>
            <td style="width: 162px;">
                <asp:TextBox ID="txtNombre" runat="server" ReadOnly="True" onkeypress="javascript:return letras(event)" onkeyup="this.value=this.value.toUpperCase();javascript:return unespacio(this);" Width="147px"></asp:TextBox></td>
            <td style="width: 231px;">
                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre"
                    ForeColor="White">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 18px; height: 5px">
            </td>
            <td style="width: 139px; height: 5px">
            </td>
            <td style="width: 33px; height: 5px">
            </td>
            <td style="width: 158px; height: 5px">
            </td>
            <td style="width: 26px; height: 5px">
            </td>
            <td style="width: 190px; height: 5px">
            </td>
            <td style="width: 33px; height: 5px">
            </td>
            <td style="width: 162px; height: 5px">
            </td>
            <td style="width: 231px; height: 5px">
            </td>
        </tr>
        <tr>
            <td style="width: 18px; height: 18px">
            </td>
            <td style="width: 139px; height: 18px; text-align: right">
                Cargo:</td>
            <td style="width: 33px; height: 18px">
            </td>
            <td style="width: 158px; height: 18px">
                <asp:TextBox ID="txtCargo" runat="server" ReadOnly="True" onkeypress="javascript:return letras(event)" onkeyup="this.value=this.value.toUpperCase();javascript:return unespacio(this);" Width="147px"></asp:TextBox></td>
            <td style="width: 26px; height: 18px">
                <asp:RequiredFieldValidator ID="rfvCargo" runat="server" ControlToValidate="txtCargo"
                    ForeColor="White">*</asp:RequiredFieldValidator></td>
            <td style="width: 190px; height: 18px; text-align: right">
                Ruc:</td>
            <td style="width: 33px; height: 18px">
            </td>
            <td style="width: 162px; height: 18px">
                <asp:TextBox ID="txtRuc" runat="server" ReadOnly="True" MaxLength="13" onkeypress="javascript:return numeros(event)" Width="147px"></asp:TextBox></td>
            <td style="width: 231px; height: 18px">
                <asp:RequiredFieldValidator ID="rfvRuc" runat="server" ControlToValidate="txtRuc"
                    ForeColor="White">*</asp:RequiredFieldValidator>
                <asp:CustomValidator ControlToValidate="txtRuc" ForeColor="White" ID="cvRuc" OnServerValidate="cvRuc_ServerValidate" runat="server">*</asp:CustomValidator></td>
        </tr>
        <tr>
            <td style="width: 18px; height: 5px">
            </td>
            <td style="width: 139px; height: 5px">
            </td>
            <td style="width: 33px; height: 5px">
            </td>
            <td style="width: 158px; height: 5px">
            </td>
            <td style="width: 26px; height: 5px">
            </td>
            <td style="width: 190px; height: 5px">
            </td>
            <td style="width: 33px; height: 5px">
            </td>
            <td style="width: 162px; height: 5px">
            </td>
            <td style="width: 231px; height: 5px">
            </td>
        </tr>
        <tr>
            <td style="width: 18px; height: 18px">
            </td>
            <td style="width: 139px; height: 18px; text-align: right">
                Dirección:</td>
            <td style="width: 33px; height: 18px">
            </td>
            <td style="width: 158px; height: 18px">
                <asp:TextBox ID="txtDir" runat="server" ReadOnly="True" onkeyup="this.value=this.value.toUpperCase();javascript:return unespacio(this);" Width="147px"></asp:TextBox></td>
            <td style="width: 26px; height: 18px">
                <asp:RequiredFieldValidator ID="rfvDir" runat="server" ControlToValidate="txtDir"
                    ForeColor="White">*</asp:RequiredFieldValidator></td>
            <td style="width: 190px; height: 18px; text-align: right">
                Teléfono:</td>
            <td style="width: 33px; height: 18px">
            </td>
            <td style="width: 162px; height: 18px">
                <asp:TextBox ID="txtFono1" runat="server" ReadOnly="True" onkeypress="javascript:return numeros(event)" Width="147px"></asp:TextBox></td>
            <td style="width: 231px; height: 18px">
                <asp:RequiredFieldValidator ID="rfvFono1" runat="server" ControlToValidate="txtFono1"
                    ForeColor="White">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 18px; height: 5px">
            </td>
            <td style="width: 139px; height: 5px">
            </td>
            <td style="width: 33px; height: 5px">
            </td>
            <td style="width: 158px; height: 5px">
            </td>
            <td style="width: 26px; height: 5px">
            </td>
            <td style="width: 190px; height: 5px">
            </td>
            <td style="width: 33px; height: 5px">
            </td>
            <td style="width: 162px; height: 5px">
            </td>
            <td style="width: 231px; height: 5px">
            </td>
        </tr>
        <tr>
            <td style="width: 18px; height: 18px">
            </td>
            <td style="width: 139px; height: 18px; text-align: right">
                Teléfono2:</td>
            <td style="width: 33px; height: 18px">
            </td>
            <td style="width: 158px; height: 18px">
                <asp:TextBox ID="txtFono2" runat="server" ReadOnly="True" onkeypress="javascript:return numeros(event)" Width="147px"></asp:TextBox></td>
            <td style="width: 26px; height: 18px">
                </td>
            <td style="width: 190px; height: 18px; text-align: right">
                Pais:</td>
            <td style="width: 33px; height: 18px">
            </td>
            <td style="width: 162px; height: 18px">
                <asp:TextBox ID="txtPais" runat="server" ReadOnly="True" onkeypress="javascript:return letras(event)" onkeyup="this.value=this.value.toUpperCase();javascript:return unespacio(this);" Width="147px"></asp:TextBox></td>
            <td style="width: 231px; height: 18px">
                <asp:RequiredFieldValidator ID="rfvPais" runat="server" ControlToValidate="txtPais"
                    ForeColor="White">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 18px; height: 5px">
            </td>
            <td style="width: 139px; height: 5px">
            </td>
            <td style="width: 33px; height: 5px">
            </td>
            <td style="width: 158px; height: 5px">
            </td>
            <td style="width: 26px; height: 5px">
            </td>
            <td style="width: 190px; height: 5px">
            </td>
            <td style="width: 33px; height: 5px">
            </td>
            <td style="width: 162px; height: 5px">
            </td>
            <td style="width: 231px; height: 5px">
            </td>
        </tr>
        <tr>
            <td style="width: 18px; height: 18px">
            </td>
            <td style="width: 139px; height: 18px; text-align: right">
                Provincia:</td>
            <td style="width: 33px; height: 18px">
            </td>
            <td style="width: 158px; height: 18px">
                <asp:TextBox ID="txtProvincia" runat="server" ReadOnly="True" onkeypress="javascript:return letras(event)" onkeyup="this.value=this.value.toUpperCase();javascript:return unespacio(this);" Width="147px"></asp:TextBox></td>
            <td style="width: 26px; height: 18px">
                <asp:RequiredFieldValidator ID="rfvProvincia" runat="server" ControlToValidate="txtProvincia"
                    ForeColor="White">*</asp:RequiredFieldValidator></td>
            <td style="width: 190px; height: 18px; text-align: right">
                Ciudad:</td>
            <td style="width: 33px; height: 18px">
            </td>
            <td style="width: 162px; height: 18px">
                <asp:TextBox ID="txtCiudad" runat="server" ReadOnly="True" onkeypress="javascript:return letras(event)" onkeyup="this.value=this.value.toUpperCase();javascript:return unespacio(this);" Width="147px"></asp:TextBox></td>
            <td style="width: 231px; height: 18px">
                <asp:RequiredFieldValidator ID="rfvCiudad" runat="server" ControlToValidate="txtCiudad"
                    ForeColor="White">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 18px; height: 5px">
            </td>
            <td style="width: 139px; height: 5px">
            </td>
            <td style="width: 33px; height: 5px">
            </td>
            <td style="width: 158px; height: 5px">
            </td>
            <td style="width: 26px; height: 5px">
            </td>
            <td style="width: 190px; height: 5px">
            </td>
            <td style="width: 33px; height: 5px">
            </td>
            <td style="width: 162px; height: 5px">
            </td>
            <td style="width: 231px; height: 5px">
            </td>
        </tr>
        <tr>
            <td style="width: 18px; height: 18px">
            </td>
            <td style="width: 139px; height: 18px; text-align: right">
                Email:</td>
            <td style="width: 33px; height: 18px">
            </td>
            <td style="width: 158px; height: 18px">
                <asp:TextBox ID="txtEmail" runat="server" ReadOnly="True" onkeypress="javascript:return letras(event)" onkeyup="this.value=this.value.toLowerCase()" Width="147px"></asp:TextBox></td>
            <td style="width: 26px; height: 18px">
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                    ForeColor="White">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="revEmail" runat="server" ForeColor="White" ControlToValidate="txtEmail" ErrorMessage="Formato Email inválido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator></td>
            <td style="width: 190px; height: 18px; text-align: right">
            </td>
            <td style="width: 33px; height: 18px">
            </td>
            <td style="width: 162px; height: 18px">
            </td>
            <td style="width: 231px; height: 18px">
                </td>
        </tr>
        <tr>
            <td style="width: 18px; height: 5px">
            </td>
            <td style="width: 139px; height: 5px">
            </td>
            <td style="width: 33px; height: 5px">
            </td>
            <td style="width: 158px; height: 5px">
            </td>
            <td style="width: 26px; height: 5px">
            </td>
            <td style="width: 190px; height: 5px">
            </td>
            <td style="width: 33px; height: 5px">
            </td>
            <td style="width: 162px; height: 5px">
            </td>
            <td style="width: 231px; height: 5px">
            </td>
        </tr>
        <tr>
            <td style="width: 18px; height: 18px">
            </td>
            <td style="width: 139px; height: 18px; text-align: right">
                <asp:Label ID="lblClave" runat="server" Text="Contraseña:" Visible="False"></asp:Label></td>
            <td style="width: 33px; height: 18px">
            </td>
            <td style="width: 158px; height: 18px">
                <asp:TextBox ID="txtClave" runat="server" TextMode="Password" Visible="False" Width="147px"></asp:TextBox></td>
            <td style="width: 26px; height: 18px">
                <asp:RequiredFieldValidator ID="rfvClave" runat="server" ControlToValidate="txtClave"
                    ForeColor="White">*</asp:RequiredFieldValidator></td>
            <td style="width: 190px; height: 18px; text-align: right">
                <asp:Label ID="lblRClave" runat="server" Text="Repetir Contraseña:" Visible="False"></asp:Label></td>
            <td style="width: 33px; height: 18px">
            </td>
            <td style="width: 162px; height: 18px">
                <asp:TextBox ID="txtRClave" runat="server" TextMode="Password" Visible="False" Width="147px"></asp:TextBox></td>
            <td style="width: 231px; height: 18px">
                <asp:CompareValidator ID="cvRClave" runat="server" ControlToCompare="txtRClave" ControlToValidate="txtClave"
                    ErrorMessage="Contraseñas Diferentes" ForeColor="White">*</asp:CompareValidator></td>
        </tr>
        <tr>
            <td style="width: 18px; height: 18px">
            </td>
            <td style="height: 18px" colspan="7">
                <asp:ValidationSummary ID="vsCuentaprov" runat="server" ForeColor="DarkGoldenrod" />
                <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" ForeColor="Black"></asp:Label></td>
            <td style="width: 231px; height: 18px; text-align: right">
            </td>
        </tr>
        <tr>
            <td colspan="9" style="border-top: black thin solid; height: 18px">
                Para cambiar sus datos, presione el botón Modificar y cuando haya terminado presione
                Guardar.<br />
                Recuerde volver a escribir su contraseña o cambiarla si así desea.<br />
                <asp:Label ID="lblObligatorio" runat="server" ForeColor="Black" Text="Los campos señalados con * son obligatorios."></asp:Label></td>
        </tr>
        <tr>
            <td style="height: 5px; border-bottom: black thin solid;" colspan="9">
            </td>
        </tr>
    </table>
</asp:Content>

