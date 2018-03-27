<%@ Page Language="C#" MasterPageFile="~/index.master" AutoEventWireup="true" CodeFile="swvmmmantusers02.aspx.cs" Inherits="swvmmmantusers02" Title="Mantenimiento de Usuarios - Vivero Market" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphIndex" Runat="Server">
    <table style="width: 763px; top: 150px; height: 34px">
        <tr>
            <td colspan="9" style="height: 9px; background-color: black">
            </td>
        </tr>
        <tr>
            <td colspan="9">
                <strong>&nbsp; &nbsp; &nbsp; Mantenimiento de Usuarios</strong></td>
        </tr>
        <tr>
            <td colspan="9" style="border-top: black thin solid; height: 22px;">
            </td>
        </tr>
        <tr>
            <td style="width: 18px; height: 18px">
            </td>
            <td style="width: 139px; height: 18px; text-align: right">
                Id:</td>
            <td style="width: 33px; height: 18px">
            </td>
            <td style="width: 158px; height: 18px">
                <asp:TextBox ID="txtId" runat="server" Width="147px" Enabled="False" Font-Bold="False" ></asp:TextBox></td>
            <td style="width: 31px; height: 18px">
            </td>
            <td style="width: 196px; height: 18px; text-align: right">
                Nombre:</td>
            <td style="width: 33px; height: 18px">
            </td>
            <td style="width: 162px; height: 18px">
                <asp:TextBox ID="txtNombre" runat="server" Width="147px" Enabled="False" onkeypress="javascript:return letras(event)" onkeyup="this.value=this.value.toUpperCase();javascript:return unespacio(this);"></asp:TextBox></td>
            <td style="width: 231px; height: 18px">
                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre"
                    ForeColor="White">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 18px; height: 5px">
            </td>
            <td style="width: 139px; height: 5px; text-align: right">
            </td>
            <td style="width: 33px; height: 5px">
            </td>
            <td style="width: 158px; height: 5px">
            </td>
            <td style="width: 31px; height: 5px">
            </td>
            <td style="width: 196px; height: 5px; text-align: right">
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
                <asp:TextBox ID="txtCargo" runat="server" Width="147px" Enabled="False" onkeypress="javascript:return letras(event)" onkeyup="this.value=this.value.toUpperCase();javascript:return unespacio(this);"></asp:TextBox></td>
            <td style="width: 31px; height: 18px">
                <asp:RequiredFieldValidator ID="rfvCargo" runat="server" ControlToValidate="txtCargo"
                    ForeColor="White">*</asp:RequiredFieldValidator></td>
            <td style="width: 196px; height: 18px; text-align: right">
                Departamento:</td>
            <td style="width: 33px; height: 18px">
            </td>
            <td style="width: 162px; height: 18px">
                <asp:TextBox ID="txtDepartamento" runat="server" Width="147px" Enabled="False" onkeypress="javascript:return letras(event)" onkeyup="this.value=this.value.toUpperCase();javascript:return unespacio(this);"></asp:TextBox></td>
            <td style="width: 231px; height: 18px">
                <asp:RequiredFieldValidator ID="rfvDepartamento" runat="server" ControlToValidate="txtDepartamento"
                    ForeColor="White">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 18px; height: 5px">
            </td>
            <td style="width: 139px; height: 5px; text-align: right">
            </td>
            <td style="width: 33px; height: 5px">
            </td>
            <td style="width: 158px; height: 5px">
            </td>
            <td style="width: 31px; height: 5px">
            </td>
            <td style="width: 196px; height: 5px; text-align: right">
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
                <asp:TextBox ID="txtEmail" runat="server" Width="147px" Enabled="False" onkeyup="this.value=this.value.toLowerCase();javascript:return unespacio(this);"></asp:TextBox></td>
            <td style="width: 31px; height: 18px">
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                    ForeColor="White">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="revEmail" runat="server" ForeColor="White" ErrorMessage="Formato Email inválido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail">*</asp:RegularExpressionValidator></td>
            <td style="width: 196px; height: 18px; text-align: right">
                Estado:</td>
            <td style="width: 33px; height: 18px">
            </td>
            <td style="width: 162px; height: 18px">
                <asp:DropDownList ID="ddlEstado" runat="server" BackColor="#E3F6CE" Width="150px" Enabled="False">
                    <asp:ListItem Value="A">Activo</asp:ListItem>
                    <asp:ListItem Value="I">Inactivo</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 231px; height: 18px">
            </td>
        </tr>
        <tr>
            <td style="width: 18px; height: 5px">
            </td>
            <td style="width: 139px; height: 5px; text-align: right">
            </td>
            <td style="width: 33px; height: 5px">
            </td>
            <td style="width: 158px; height: 5px">
            </td>
            <td style="width: 31px; height: 5px">
            </td>
            <td style="width: 196px; height: 5px; text-align: right">
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
                <asp:TextBox ID="txtClave" runat="server" TextMode="Password" Width="147px" Visible="False" onkeyup="javascript:return unespacio(this);"></asp:TextBox></td>
            <td style="width: 31px; height: 18px">
                <asp:RequiredFieldValidator ID="rfvClave" runat="server" ControlToValidate="txtClave"
                    ForeColor="White">*</asp:RequiredFieldValidator></td>
            <td style="width: 196px; height: 18px; text-align: right">
                <asp:Label ID="lblRClave" runat="server" Text="Confirmar Contraseña:" Visible="False"></asp:Label></td>
            <td style="width: 33px; height: 18px">
            </td>
            <td style="width: 162px; height: 18px">
                <asp:TextBox ID="txtRClave" runat="server" TextMode="Password" Width="147px" Visible="False" onkeyup="javascript:return unespacio(this);"></asp:TextBox></td>
            <td style="width: 231px; height: 18px">
                <asp:CompareValidator ID="cvRClave" runat="server" ControlToCompare="txtRClave" ControlToValidate="txtClave"
                    ErrorMessage="Contraseñas Diferentes" ForeColor="White">*</asp:CompareValidator></td>
        </tr>
        <tr>
            <td style="width: 18px; height: 18px">
            </td>
            <td style="width: 139px; height: 18px; text-align: right">
            </td>
            <td style="width: 33px; height: 18px">
            </td>
            <td style="width: 158px; height: 18px">
            </td>
            <td style="width: 31px; height: 18px">
            </td>
            <td style="width: 196px; height: 18px; text-align: right">
            </td>
            <td style="width: 33px; height: 18px">
            </td>
            <td style="width: 162px; height: 18px">
            </td>
            <td style="width: 231px; height: 18px">
            </td>
        </tr>
        <tr>
            <td colspan="9" style="background-color: black; text-align: center; height: 15px;">
                <asp:Label ID="lblMensaje" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="9" style="border-top: black thin solid; height: 5px">
            </td>
        </tr>
        <tr>
            <td style="width: 18px; height: 18px">
            </td>
            <td colspan="2" style="height: 18px; text-align: right">
            </td>
            <td colspan="5" style="height: 18px; text-align: center;">
                <asp:Button ID="btnNuevo" runat="server" CssClass="btnnew" BorderStyle="Solid" Font-Bold="False" Font-Size="10pt" Text="   Nuevo" OnClick="btnNuevo_Click" CausesValidation="False" />
                &nbsp;&nbsp;
                <asp:Button ID="btnGuardar" runat="server" CssClass="btnsave" BorderStyle="Solid" Font-Bold="False" Font-Size="10pt" Text="   Guardar" Enabled="False" OnClick="btnGuardar_Click" />
                &nbsp;
                <asp:Button ID="btnCancelar" runat="server" CssClass="btncancel" BorderStyle="Solid" Font-Bold="False" Font-Size="10pt" Text="   Cancelar" Enabled="False" OnClick="btnCancelar_Click" CausesValidation="False" /></td>
            <td style="width: 231px; height: 18px">
            </td>
        </tr>
        <tr>
            <td colspan="9" style="height: 5px">
            </td>
        </tr>
        <tr>
            <td colspan="9" style="border-top: black thin solid; height: 18px">
                &nbsp;<asp:GridView ID="gvUsuario" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False" HorizontalAlign="Center" OnRowEditing="gvUsuario_RowEditing" OnRowDeleting="gvUsuario_RowDeleting">
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:ButtonField ButtonType="Image" CommandName="Edit" ImageUrl="~/images/017.png"
                            Text="Editar">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:ButtonField>
                        <asp:ButtonField ButtonType="Image" CommandName="Delete" ImageUrl="~/images/005.png" 
                            Text="Eliminar">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:ButtonField>
                        <asp:BoundField DataField="userid" HeaderText="Id" ReadOnly="True" SortExpression="userid" >
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="nombre" HeaderText="Nombre" ReadOnly="True" SortExpression="nombre" />
                        <asp:BoundField DataField="cargo" HeaderText="Cargo" ReadOnly="True" SortExpression="cargo">
                            <ItemStyle HorizontalAlign="Justify" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="departamento" HeaderText="Departamento" ReadOnly="True"
                            SortExpression="departamento" />
                        <asp:BoundField DataField="email" HeaderText="Email" ReadOnly="True" SortExpression="email" />
                        <asp:BoundField DataField="estado" HeaderText="Estado" ReadOnly="True" SortExpression="estado">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="fechar" DataFormatString="{0:dd-MMMM-yyyy}" HeaderText="Fecha Registro"
                            HtmlEncode="False" ReadOnly="True" SortExpression="fechar">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
                </td>
        </tr>
        <tr>
            <td colspan="9" style="height: 15px">
            </td>
        </tr>
        <tr>
            <td colspan="9" style="border-top: black thin solid; height: 18px">
                Los campos señalados con * son obligatorios.<br />
                <asp:ValidationSummary ID="vsMantusers" runat="server" ForeColor="DarkGoldenrod" />
            </td>
        </tr>
        <tr>
            <td colspan="9" style="border-bottom: black thin solid; height: 5px">
            </td>
        </tr>
    </table>
</asp:Content>

