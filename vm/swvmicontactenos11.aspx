<%@ Page Language="C#" MasterPageFile="~/index.master" AutoEventWireup="true" CodeFile="swvmicontactenos11.aspx.cs" Inherits="swvmicontactenos11" Title="Contáctenos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td style="width: 6px; height: 18px">
            </td>
            <td colspan="4" style="height: 18px; background-color: darkolivegreen; text-align: center;">
                <asp:Label ID="lblMensajeError" runat="server" Font-Bold="True"></asp:Label></td>
            <td style="width: 23px; height: 18px">
            </td>
        </tr>
        <tr>
            <td style="width: 6px;">
            </td>
            <td colspan="2">
                <h2>
                    Contáctenos</h2>
            </td>
            <td style="width: 75px;">
            </td>
            <td style="width: 89px;">
            </td>
            <td style="width: 23px;">
            </td>
        </tr>
        <tr>
            <td style="width: 6px">
            </td>
            <td style="width: 17px">
            </td>
            <td colspan="3">
                <table style="width: 502px; height: 50px">
                    <tr>
                        <td style="width: 26px">
                            Dirección:
                        </td>
                        <td style="width: 13px">
                        </td>
                        <td style="width: 331px">
                            <asp:Label ID="lblDir" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 26px">
                        </td>
                        <td style="width: 13px">
                        </td>
                        <td style="width: 331px">
                            <asp:Label ID="lblCiudad" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 26px">
                        </td>
                        <td style="width: 13px">
                        </td>
                        <td style="width: 331px">
                            <asp:Label ID="lblProvincia" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 26px">
                        </td>
                        <td style="width: 13px">
                        </td>
                        <td style="width: 331px">
                            <asp:Label ID="lblPais" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 26px">
                            Email:</td>
                        <td style="width: 13px">
                        </td>
                        <td style="width: 331px">
                            <asp:Label ID="lblEmail" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 26px">
                            Teléfono:</td>
                        <td style="width: 13px">
                        </td>
                        <td style="width: 331px">
                            <asp:Label ID="lblTelefono" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 26px; height: 4px;">
                        </td>
                        <td style="width: 13px; height: 4px;">
                        </td>
                        <td style="width: 331px; height: 4px;">
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 23px">
            </td>
        </tr>
        <tr>
            <td style="width: 6px; height: 10px">
            </td>
            <td colspan="4" style="height: 10px; background-color: darkolivegreen">
            </td>
            <td style="width: 23px; height: 10px">
            </td>
        </tr>
        <tr>
            <td style="width: 6px; height: 4px">
            </td>
            <td style="width: 17px; height: 4px">
            </td>
            <td style="width: 340px; height: 4px">
            </td>
            <td style="width: 75px; height: 4px">
            </td>
            <td style="width: 89px; height: 4px">
            </td>
            <td style="width: 23px; height: 4px">
            </td>
        </tr>
        <tr>
            <td style="width: 6px">
            </td>
            <td style="width: 17px">
            </td>
            <td colspan="3">
                Si desea comunicarse con nosotros por favor escríbanos desde el siguiente formulario.</td>
            <td style="width: 23px">
            </td>
        </tr>
        <tr>
            <td style="width: 6px; height: 5px">
            </td>
            <td style="width: 17px; height: 5px">
            </td>
            <td style="width: 340px; height: 5px">
            </td>
            <td style="width: 75px; height: 5px">
            </td>
            <td style="width: 89px; height: 5px">
            </td>
            <td style="width: 23px; height: 5px">
            </td>
        </tr>
        <tr>
            <td style="width: 6px">
            </td>
            <td style="width: 17px; text-align: right">
            </td>
            <td style="width: 340px">
                &nbsp;Escriba su nombre y apellidos:</td>
            <td style="width: 75px">
            </td>
            <td style="width: 89px">
            </td>
            <td style="width: 23px">
            </td>
        </tr>
        <tr>
            <td style="width: 6px">
            </td>
            <td style="width: 17px; text-align: right;">
                </td>
            <td style="width: 340px">
                <asp:TextBox ID="txtNombre" runat="server" ValidationGroup="ctl05" Width="207px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="Ingrese su Nombre Por Favor"
                    Font-Size="Large" ForeColor="#EEEE66" ValidationGroup="ctl05">*</asp:RequiredFieldValidator></td>
            <td style="width: 75px">
            </td>
            <td style="width: 89px">
            </td>
            <td style="width: 23px">
            </td>
        </tr>
        <tr>
            <td style="width: 6px;">
            </td>
            <td style="width: 17px; text-align: right">
            </td>
            <td style="width: 340px;">
                Dirección de e-mail:</td>
            <td style="width: 75px;">
            </td>
            <td style="width: 89px;">
            </td>
            <td style="width: 23px;">
            </td>
        </tr>
        <tr>
            <td style="width: 6px; height: 26px">
            </td>
            <td style="width: 17px; height: 26px; text-align: right;">
                </td>
            <td style="width: 340px; height: 26px">
                <asp:TextBox ID="txtEmail" runat="server" ValidationGroup="ctl05" Width="207px" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Ingrese su Email Por Favor"
                    Font-Size="Large" ForeColor="#EEEE66" ValidationGroup="ctl05">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="rfvEmailFormato" runat="server" ControlToValidate="txtEmail"
				ErrorMessage="Inserte Formato de Correo Valido"
                    Font-Size="Large" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="#EEEE66" ValidationGroup="ctl05">*</asp:RegularExpressionValidator></td>
            <td style="width: 75px; height: 26px">
            </td>
            <td style="width: 89px; height: 26px">
            </td>
            <td style="width: 23px; height: 26px">
            </td>
        </tr>
        <tr>
            <td style="width: 6px">
            </td>
            <td style="width: 17px; text-align: right">
            </td>
            <td style="width: 340px">
                Tema del mensaje:</td>
            <td style="width: 75px">
            </td>
            <td style="width: 89px">
            </td>
            <td style="width: 23px">
            </td>
        </tr>
        <tr>
            <td style="width: 6px">
            </td>
            <td style="width: 17px; text-align: right;">
                </td>
            <td style="width: 340px">
                <asp:TextBox ID="txtTitulo" runat="server" ValidationGroup="ctl05" Width="207px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvAsunto" runat="server" ControlToValidate="txtTitulo" ErrorMessage="Ingrese su Asunto Por Favor"
                    Font-Size="Large" ForeColor="#EEEE66" ValidationGroup="ctl05">*</asp:RequiredFieldValidator></td>
            <td style="width: 75px">
            </td>
            <td style="width: 89px">
            </td>
            <td style="width: 23px">
            </td>
        </tr>
        <tr>
            <td style="width: 6px">
            </td>
            <td style="width: 17px; text-align: right">
            </td>
            <td rowspan="1" style="width: 340px">
                Escriba su mensaje:
            </td>
            <td rowspan="1" style="width: 75px">
            </td>
            <td rowspan="1" style="width: 89px">
            </td>
            <td rowspan="1" style="width: 23px">
            </td>
        </tr>
        <tr>
            <td style="width: 6px">
            </td>
            <td style="width: 17px; text-align: right;">
            </td>
            <td rowspan="4" style="width: 340px; vertical-align: top;">
                <asp:TextBox ID="txtMensaje" runat="server" Height="146px"
                    Width="314px" TextMode="MultiLine" ValidationGroup="ctl05"></asp:TextBox><asp:RequiredFieldValidator ID="rfvMensaje" ControlToValidate="txtMensaje" 
				runat="server" ErrorMessage="Ingrese su Comentario Por Favor"
                    Font-Size="Large" ForeColor="#EEEE66" ValidationGroup="ctl05">*</asp:RequiredFieldValidator></td>
            <td rowspan="4" style="vertical-align: top;" colspan="2">
                <asp:ValidationSummary ID="rfvErrores" runat="server" ForeColor="#EEEE66" ValidationGroup="ctl05" />
            </td>
            <td rowspan="4" style="width: 23px">
            </td>
        </tr>
        <tr>
            <td style="width: 6px">
            </td>
            <td style="width: 17px">
            </td>
        </tr>
        <tr>
            <td style="width: 6px">
            </td>
            <td style="width: 17px">
                </td>
        </tr>
        <tr>
            <td style="width: 6px; height: 49px;">
            </td>
            <td style="width: 17px; height: 49px;">
            </td>
        </tr>
        <tr>
            <td style="width: 6px">
            </td>
            <td style="width: 17px">
            </td>
            <td style="width: 340px">
                <asp:CheckBox ID="ckbCopiaemail" runat="server" Text="Enviar una copia de este mensaje a su propio E-mail." Checked="True" ValidationGroup="ctl05" Visible="True" /></td>
            <td style="width: 75px">
            </td>
            <td style="width: 89px">
            </td>
            <td style="width: 23px">
            </td>
        </tr>
        <tr>
            <td style="width: 6px">
            </td>
            <td style="width: 17px">
            </td>
            <td style="width: 340px">
                <asp:Button ID="SendButton" runat="server" OnClick="SendButton_Click" Text="Enviar" ValidationGroup="ctl05" />
            </td>
            <td style="width: 75px">
            </td>
            <td style="width: 89px">
            </td>
            <td style="width: 23px">
            </td>
        </tr>
    </table>
</asp:Content>

