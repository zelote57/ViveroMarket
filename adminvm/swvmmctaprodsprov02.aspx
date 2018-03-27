<%@ Page Language="C#" MasterPageFile="~/index.master" AutoEventWireup="true" CodeFile="swvmmctaprodsprov02.aspx.cs" Inherits="swvmmctaprodsprov02" Title="Mantenimiento de Productos - Vivero Market" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphIndex" Runat="Server">
    <table style="width: 763px; top: 150px; height: 34px">
        <tr>
            <td colspan="10" style="height: 9px; background-color: black">
            </td>
        </tr>
        <tr>
            <td colspan="10">
                <strong>&nbsp; &nbsp; &nbsp; Mantenimiento de sus Productos</strong></td>
        </tr>
        <tr>
            <td colspan="10" style="border-top: black thin solid; height: 6px;">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 18px; height: 18px">
            </td>
            <td style="width: 218px; height: 18px; text-align: right">
                Id:</td>
            <td style="width: 33px; height: 18px">
            </td>
            <td style="width: 146px; height: 18px">
                <asp:TextBox ID="txtId" runat="server" Width="147px" Enabled="False" Font-Bold="False" ></asp:TextBox></td>
            <td style="width: 60px; height: 18px">
            </td>
            <td style="width: 85px; height: 18px">
            </td>
            <td style="width: 97px; height: 18px; text-align: right">
                Categoría:</td>
            <td style="width: 17px; height: 18px">
            </td>
            <td style="width: 162px; height: 18px">
                <asp:DropDownList ID="ddlCateid" runat="server" BackColor="#E3F6CE" Width="150px" DataTextField="nombre" DataValueField="cateid" Enabled="False" AutoPostBack="True" OnSelectedIndexChanged="ddlCateid_SelectedIndexChanged">
                </asp:DropDownList></td>
            <td style="width: 137px; height: 18px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 18px; height: 5px">
            </td>
            <td style="width: 218px; height: 5px; text-align: right">
            </td>
            <td style="width: 33px; height: 5px">
            </td>
            <td style="width: 146px; height: 5px">
            </td>
            <td style="width: 60px; height: 5px">
            </td>
            <td style="width: 85px; height: 5px">
            </td>
            <td style="width: 97px; height: 5px; text-align: right">
            </td>
            <td style="width: 17px; height: 5px">
            </td>
            <td style="width: 162px; height: 5px">
            </td>
            <td style="width: 137px; height: 5px">
            </td>
        </tr>
        <tr>
            <td style="width: 18px; height: 18px">
            </td>
            <td style="width: 218px; height: 18px; text-align: right">
                Nombre:</td>
            <td style="width: 33px; height: 18px">
            </td>
            <td style="width: 146px; height: 18px">
                <asp:TextBox ID="txtNombre" runat="server" Width="147px" Enabled="False" onkeypress="javascript:return letras(event)" onkeyup="this.value=this.value.toUpperCase();javascript:return unespacio(this);"></asp:TextBox></td>
            <td style="width: 60px; height: 18px">
                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre"
                    ForeColor="White" EnableTheming="False">*</asp:RequiredFieldValidator></td>
            <td style="width: 85px; height: 18px">
            </td>
            <td style="width: 97px; height: 18px; text-align: right">
                </td>
            <td style="width: 17px; height: 18px">
            </td>
            <td style="width: 162px; height: 18px">
                </td>
            <td style="width: 137px; height: 18px">
                </td>
        </tr>
        <tr>
            <td style="width: 18px; height: 5px">
            </td>
            <td style="width: 218px; height: 5px; text-align: right">
            </td>
            <td style="width: 33px; height: 5px">
            </td>
            <td style="width: 146px; height: 5px">
            </td>
            <td style="width: 60px; height: 5px">
            </td>
            <td style="width: 85px; height: 5px">
            </td>
            <td style="width: 97px; height: 5px; text-align: right">
            </td>
            <td style="width: 17px; height: 5px">
            </td>
            <td style="width: 162px; height: 5px">
            </td>
            <td style="width: 137px; height: 5px">
            </td>
        </tr>
        <tr>
            <td style="width: 18px; height: 5px">
            </td>
            <td style="width: 218px; height: 5px; text-align: right">
                Precio:</td>
            <td style="width: 33px; height: 5px">
            </td>
            <td style="width: 146px; height: 5px">
                <asp:TextBox ID="txtPrecio" runat="server" Width="147px" Enabled="False" onkeypress="javascript:return numcoma(event)"></asp:TextBox></td>
            <td style="width: 60px; height: 5px">
                <asp:RequiredFieldValidator ID="rfvPrecio" runat="server" ControlToValidate="txtPrecio"
                    ForeColor="White">*</asp:RequiredFieldValidator></td>
            <td style="width: 85px; height: 5px">
            </td>
            <td style="width: 97px; height: 5px; text-align: right">
                &nbsp;</td>
            <td style="vertical-align: top; text-align: left;" colspan="3" rowspan="7">
                &nbsp; &nbsp;
                <asp:Image ID="imgProducto" runat="server" Height="140px" Width="140px" /></td>
        </tr>
        <tr>
            <td style="width: 18px; height: 5px">
            </td>
            <td style="width: 218px; height: 5px; text-align: right">
            </td>
            <td style="width: 33px; height: 5px">
            </td>
            <td style="width: 146px; height: 5px">
            </td>
            <td style="width: 60px; height: 5px">
            </td>
            <td style="width: 85px; height: 5px">
            </td>
            <td style="width: 97px; height: 5px; text-align: right">
            </td>
        </tr>
        <tr>
            <td style="width: 18px; height: 5px">
            </td>
            <td style="width: 218px; height: 5px; text-align: right">
                Tamaño en cm:</td>
            <td style="width: 33px; height: 5px">
            </td>
            <td style="width: 146px; height: 5px">
                <asp:TextBox ID="txtSize" runat="server" Enabled="False" Width="147px" onkeypress="javascript:return numpunto(event)"></asp:TextBox></td>
            <td style="width: 60px; height: 5px">
                <asp:RequiredFieldValidator ID="rfvSize" runat="server" ControlToValidate="txtSize"
                    ForeColor="White">*</asp:RequiredFieldValidator></td>
            <td style="width: 85px; height: 5px">
            </td>
            <td style="width: 97px; height: 5px; text-align: right">
            </td>
        </tr>
        <tr>
            <td style="width: 18px; height: 5px">
            </td>
            <td style="width: 218px; height: 5px; text-align: right">
            </td>
            <td style="width: 33px; height: 5px">
            </td>
            <td style="width: 146px; height: 5px">
            </td>
            <td style="width: 60px; height: 5px">
            </td>
            <td style="width: 85px; height: 5px">
            </td>
            <td style="width: 97px; height: 5px; text-align: right">
            </td>
        </tr>
        <tr>
            <td style="width: 18px; height: 5px">
            </td>
            <td style="width: 218px; height: 5px; text-align: right">
                Link:</td>
            <td style="width: 33px; height: 5px">
            </td>
            <td style="width: 146px; height: 5px">
                <asp:TextBox ID="txtUrl" runat="server" Enabled="False" Width="147px" onkeyup="this.value=this.value.toLowerCase();javascript:return noespacio(this);" ></asp:TextBox></td>
            <td style="width: 60px; height: 5px">
                <asp:RegularExpressionValidator ID="revUrl" runat="server" ControlToValidate="txtUrl"
                    ErrorMessage="Escriba una Url válida" ForeColor="White" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?">*</asp:RegularExpressionValidator></td>
            <td style="width: 85px; height: 5px">
            </td>
            <td style="width: 97px; height: 5px; text-align: right">
                </td>
        </tr>
        <tr>
            <td style="width: 18px; height: 5px">
            </td>
            <td style="width: 218px; height: 5px; text-align: right">
            </td>
            <td style="width: 33px; height: 5px">
            </td>
            <td style="width: 146px; height: 5px">
            </td>
            <td style="width: 60px; height: 5px">
            </td>
            <td style="width: 85px; height: 5px">
            </td>
            <td style="width: 97px; height: 5px; text-align: right">
            </td>
        </tr>
        <tr>
            <td style="width: 18px; height: 5px">
            </td>
            <td style="width: 218px; height: 5px; text-align: right">
                Stock:</td>
            <td style="width: 33px; height: 5px">
            </td>
            <td style="width: 146px; height: 5px">
                <asp:TextBox ID="txtStock" runat="server" Enabled="False" Width="147px" onkeypress="javascript:return numeros(event)"></asp:TextBox></td>
            <td style="width: 60px; height: 5px">
                <asp:RequiredFieldValidator ID="rfvStock" runat="server" ControlToValidate="txtStock"
                    ForeColor="White">*</asp:RequiredFieldValidator></td>
            <td style="width: 85px; height: 5px">
            </td>
            <td style="width: 97px; height: 5px; text-align: right">
            </td>
        </tr>
        <tr>
            <td style="width: 18px; height: 5px">
            </td>
            <td style="width: 218px; height: 5px; text-align: right">
            </td>
            <td style="width: 33px; height: 5px">
            </td>
            <td style="width: 146px; height: 5px">
            </td>
            <td style="width: 60px; height: 5px">
            </td>
            <td style="width: 85px; height: 5px">
            </td>
            <td style="width: 97px; height: 5px; text-align: right">
            </td>
            <td style="height: 5px" colspan="3">
                <asp:CheckBox ID="chkActImage" runat="server" AutoPostBack="True" Checked="True"
                    OnCheckedChanged="chkActImage_CheckedChanged" Text="No actualizar Imágen" Visible="False" /></td>
        </tr>
        <tr>
            <td style="width: 18px; height: 5px">
            </td>
            <td style="width: 218px; height: 5px; text-align: right; vertical-align: top;">
                Descripción:</td>
            <td style="width: 33px; height: 5px">
            </td>
            <td style="height: 5px" colspan="2">
                <asp:TextBox ID="txtDescripcion" runat="server" Enabled="False" Height="85px" TextMode="MultiLine" Width="207px" onkeypress="javascript:return letras(event)" onkeyup="this.value=this.value.toUpperCase();javascript:return unespacio(this);"></asp:TextBox></td>
            <td style="vertical-align: top; width: 85px; height: 5px">
                <asp:CustomValidator ID="cvDescripcion" runat="server" ForeColor="White" ValidateEmptyText="True" style="vertical-align: top" ErrorMessage="Debe ingresar más de 35 carácteres en la descripción" OnServerValidate="cvDescripcion_ServerValidate">*</asp:CustomValidator></td>
            <td style="width: 97px; height: 5px; text-align: right; vertical-align: top;">
                Insertar/Modificar Imagen<br />
            </td>
            <td style="height: 5px; vertical-align: top;" colspan="3">
            
            <input id="flimage" runat="server" type="file" /><br />
                <asp:CustomValidator ID="cvFlimage" runat="server" ForeColor="White" OnServerValidate="cvFlimage_ServerValidate"
                    Style="vertical-align: top" ValidateEmptyText="True">*</asp:CustomValidator>
    <asp:Label ID="lblmessage" runat="server"></asp:Label><br />
            </td>
        </tr>
        <tr>
            <td style="width: 18px; height: 5px">
            </td>
            <td style="width: 218px; height: 5px; text-align: right">
            </td>
            <td style="width: 33px; height: 5px">
            </td>
            <td style="width: 146px; height: 5px">
            </td>
            <td style="width: 60px; height: 5px">
            </td>
            <td style="width: 85px; height: 5px">
            </td>
            <td style="width: 97px; height: 5px; text-align: right">
            </td>
            <td style="width: 17px; height: 5px">
            </td>
            <td style="width: 162px; height: 5px">
            </td>
            <td style="width: 137px; height: 5px">
            </td>
        </tr>
        <tr>
            <td style="width: 18px; height: 18px">
            </td>
            <td colspan="8" style="height: 18px; text-align: left">
                Los campos señalados con * son obligatorios.<br />
                <asp:ValidationSummary ID="vsMantprods" runat="server" ForeColor="DarkGoldenrod" />
            </td>
            <td style="width: 137px; height: 18px">
            </td>
        </tr>
        <tr>
            <td colspan="10" style="background-color: black; text-align: center; height: 15px;">
                <asp:Label ID="lblMensaje" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="10" style="border-top: black thin solid; height: 5px">
            </td>
        </tr>
        <tr>
            <td style="width: 18px; height: 18px">
            </td>
            <td colspan="2" style="height: 18px; text-align: right">
            </td>
            <td colspan="6" style="height: 18px; text-align: center;">
                <asp:Button ID="btnNuevo" runat="server" CssClass="btnnew" BorderStyle="Solid" Font-Bold="False" Font-Size="10pt" Text="   Nuevo" OnClick="btnNuevo_Click" CausesValidation="False" />
                &nbsp;&nbsp;
                <asp:Button ID="btnGuardar" runat="server" CssClass="btnsave" BorderStyle="Solid" Font-Bold="False" Font-Size="10pt" Text="   Guardar" Enabled="False" OnClick="btnGuardar_Click" />
                &nbsp;
                <asp:Button ID="btnCancelar" runat="server" CssClass="btncancel" BorderStyle="Solid" Font-Bold="False" Font-Size="10pt" Text="   Cancelar" Enabled="False" OnClick="btnCancelar_Click" CausesValidation="False" /></td>
            <td style="width: 137px; height: 18px">
            </td>
        </tr>
        <tr>
            <td colspan="10" style="height: 5px">
            </td>
        </tr>
        <tr>
            <td colspan="10" style="border-top: black thin solid; height: 5px">
            </td>
        </tr>
        <tr>
            <td colspan="10" style="height: 5px">
                Elegir categoría:
                <asp:DropDownList ID="ddlGcateid" runat="server" BackColor="#E3F6CE" Width="150px" AutoPostBack="True" DataTextField="nombre" DataValueField="cateid" OnLoad="ddlGcateid_Load" OnSelectedIndexChanged="ddlGcateid_SelectedIndexChanged">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan="10" style="height: 18px">
                &nbsp;<asp:GridView ID="gvProducto" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False" HorizontalAlign="Center" OnRowEditing="gvProducto_RowEditing" OnRowDeleting="gvProducto_RowDeleting" AllowPaging="True" OnPageIndexChanging="gvProducto_PageIndexChanging" Width="80%">
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
                        <asp:BoundField DataField="proid" HeaderText="Id" ReadOnly="True" SortExpression="proid" >
                            <ItemStyle HorizontalAlign="Center" Width="25px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="provid" HeaderText="PId" SortExpression="provid">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="nombre" HeaderText="Nombre" ReadOnly="True" SortExpression="nombre" >
                            <ItemStyle Width="160px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="stock" HeaderText="Stock" ReadOnly="True" SortExpression="stock">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="precio" HeaderText="Precio" ReadOnly="True"
                            SortExpression="precio" >
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="size" DataFormatString="{0:d} cm" HeaderText="Tama&#241;o"
                            SortExpression="size">
                            <ItemStyle HorizontalAlign="Right" />
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="fechar" DataFormatString="{0:dd-MMMM-yyyy}" HeaderText="Fecha Registro"
                            HtmlEncode="False" ReadOnly="True" SortExpression="fechar">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
                </td>
        </tr>
        <tr>
            <td colspan="10" style="height: 15px">
            </td>
        </tr>
        <tr>
            <td colspan="10" style="border-top: black thin solid; height: 18px">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

