<%@ Page Language="C#" MasterPageFile="~/index.master" AutoEventWireup="true" CodeFile="swvmigalerydetails04.aspx.cs" Inherits="swvmigalerydetails04" Title="Detalle de Producto - ViveroMarket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" style="width: 681px; position: static;
        height: 166px">
        <tr>
            <td colspan="1" rowspan="1" style="width: 16px; height: 14px">
            </td>
            <td colspan="4" rowspan="1" style="height: 14px; background-color: black">
            </td>
            <td colspan="1" rowspan="1" style="width: 215px; height: 14px; background-color: black">
            </td>
            <td colspan="1" rowspan="1" style="width: 48px; height: 14px; background-color: black">
            </td>
        </tr>
        <tr>
            <td rowspan="1" style="width: 16px">
            </td>
            <td rowspan="1" style="width: 17px">
            </td>
            <td rowspan="1" style="width: 247px">
            </td>
            <td style="width: 7px">
            </td>
            <td style="width: 3px">
            </td>
            <td style="width: 215px">
            </td>
            <td style="width: 48px">
            </td>
        </tr>
        <tr>
            <td rowspan="1" style="width: 16px; height: 14px">
            </td>
            <td rowspan="1" style="width: 17px; height: 14px">
            </td>
            <td rowspan="1" style="width: 247px; height: 14px">
            </td>
            <td style="width: 7px; height: 14px">
            </td>
            <td style="width: 3px; height: 14px">
            </td>
            <td style="width: 215px; height: 14px">
            </td>
            <td style="width: 48px; height: 14px">
            </td>
        </tr>
        <tr>
            <td rowspan="14" style="width: 16px">
            </td>
            <td rowspan="14" style="width: 17px">
            </td>
            <td rowspan="14" style="width: 247px; text-align: center;">
                <asp:Image ID="imgProducto" runat="server" Height="270px" Width="270px" CssClass="reflex" /></td>
            <td style="width: 7px; height: 10px;">
            </td>
            <td style="height: 10px; border-bottom: black thin solid;" colspan="3">
                </td>
        </tr>
        <tr>
            <td style="width: 7px; height: 5px">
            </td>
            <td style="width: 3px; height: 5px; text-align: left">
            </td>
            <td style="width: 215px; height: 5px">
            </td>
            <td style="width: 48px; height: 5px">
            </td>
        </tr>
        <tr>
            <td style="width: 7px; height: 5px">
            </td>
            <td style="width: 3px; height: 5px; text-align: left">
                Nombre:</td>
            <td style="width: 215px; height: 5px">
                <asp:Label ID="lblNombre" runat="server"></asp:Label></td>
            <td style="width: 48px; height: 5px">
            </td>
        </tr>
        <tr>
            <td style="width: 7px; height: 10px">
            </td>
            <td style="width: 3px; height: 10px; text-align: left">
            </td>
            <td style="width: 215px; height: 10px">
            </td>
            <td style="width: 48px; height: 10px">
            </td>
        </tr>
        <tr>
            <td style="width: 7px; height: 14px">
            </td>
            <td style="width: 3px; height: 14px; text-align: left">
                Tamaño:</td>
            <td style="width: 215px; height: 14px">
                <asp:Label ID="lblSize" runat="server"></asp:Label>&nbsp; cm</td>
            <td style="width: 48px; height: 14px">
            </td>
        </tr>
        <tr>
            <td style="width: 7px; height: 10px">
            </td>
            <td style="width: 3px; height: 10px">
            </td>
            <td style="width: 215px; height: 10px">
            </td>
            <td style="width: 48px; height: 10px">
            </td>
        </tr>
        <tr>
            <td style="width: 7px; height: 14px">
            </td>
            <td style="width: 3px; height: 14px; text-align: left;">
                Precio:</td>
            <td style="width: 215px; height: 14px">
                $
                <asp:Label ID="lblPrecio" runat="server"></asp:Label></td>
            <td style="width: 48px; height: 14px">
            </td>
        </tr>
        <tr>
            <td style="width: 7px; height: 10px">
            </td>
            <td style="width: 3px; height: 10px; text-align: left">
            </td>
            <td style="width: 215px; height: 10px">
            </td>
            <td style="width: 48px; height: 10px">
            </td>
        </tr>
        <tr>
            <td style="width: 7px; height: 14px">
            </td>
            <td style="width: 3px; height: 14px; text-align: left">
                Stock:</td>
            <td style="width: 215px; height: 14px">
                <asp:Label ID="lblStock" runat="server"></asp:Label></td>
            <td style="width: 48px; height: 14px">
            </td>
        </tr>
        <tr>
            <td style="width: 7px; height: 10px;">
            </td>
            <td style="border-bottom: black thin solid; height: 10px;" colspan="3">
            </td>
        </tr>
        <tr>
            <td style="width: 7px; height: 14px">
            </td>
            <td style="width: 3px; height: 14px">
                </td>
            <td style="width: 215px; height: 14px">
            </td>
            <td style="width: 48px; height: 14px">
            </td>
        </tr>
        <tr>
            <td style="width: 7px">
            </td>
            <td style="text-align: left; vertical-align: top;" colspan="3" rowspan="3">
                <asp:Panel ID="pComprar" runat="server" Height="120px" Width="200px">
                    <table>
                        <tr>
                            <td colspan="2">
                                <strong><span style="font-size: 14pt">Comprar Producto</span></strong></td>
                        </tr>
                        <tr>
                            <td style="width: 4px; height: 5px">
                            </td>
                            <td colspan="1" style="height: 5px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 4px">
                Cantidad:</td>
                            <td colspan="1">
                <asp:TextBox ID="txtCantidad" runat="server" Width="35px" Height="20px" onkeypress="javascript:return num_sin_enter(event);"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 4px; height: 10px">
                            </td>
                            <td style="width: 89px; height: 10px">
                                <asp:Label ID="lblNoStock" runat="server" Font-Size="Smaller" ForeColor="#FF8080"
                                    Text="No tenemos suficiente stock para su pedido" Visible="False"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:ImageButton ID="btnAgregar" runat="server" ImageUrl="images/botoncar.png" OnClick="btnAgregar_Click" /></td>
                        </tr>
                        <tr>
                            <td style="width: 4px">
                            </td>
                            <td style="width: 89px">
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                </td>
        </tr>
        <tr>
            <td style="width: 7px; height: 10px">
            </td>
        </tr>
        <tr>
            <td style="width: 7px; height: 115px">
            </td>
        </tr>
        <tr>
            <td colspan="1" style="width: 16px; height: 10px">
            </td>
            <td colspan="1" style="width: 17px; height: 10px; border-bottom: black thin solid;">
            </td>
            <td colspan="3" style="height: 10px; border-bottom: black thin solid;">
            </td>
            <td colspan="1" style="width: 215px; height: 10px; border-bottom: black thin solid;">
            </td>
            <td colspan="1" style="width: 48px; height: 10px; border-bottom: black thin solid;">
            </td>
        </tr>
        <tr>
            <td colspan="1" style="width: 16px; height: 10px; text-align: left">
            </td>
            <td colspan="1" style="width: 17px; height: 10px; text-align: left">
            </td>
            <td colspan="3" style="height: 10px; text-align: left">
            </td>
            <td colspan="1" style="width: 215px; height: 10px; text-align: left">
            </td>
            <td colspan="1" style="width: 48px; height: 10px; text-align: left">
            </td>
        </tr>
        <tr>
            <td colspan="1" style="width: 16px; text-align: left; height: 14px;">
            </td>
            <td colspan="1" style="width: 17px; text-align: left; height: 14px;">
            </td>
            <td colspan="3" style="text-align: left; height: 14px;">
                Detalle:</td>
            <td colspan="1" style="width: 215px; text-align: left; height: 14px;">
                &nbsp; &nbsp; Proveedor:
                <asp:Label ID="lblProveedor" runat="server"></asp:Label></td>
            <td colspan="1" style="width: 48px; text-align: left; height: 14px;">
            </td>
        </tr>
        <tr>
            <td colspan="1" style="width: 16px; text-align: left; height: 5px;">
            </td>
            <td colspan="1" style="width: 17px; text-align: left; height: 5px;">
            </td>
            <td colspan="3" style="text-align: left; height: 5px;">
            </td>
            <td colspan="1" style="width: 215px; text-align: left; height: 5px;">
            </td>
            <td colspan="1" style="width: 48px; text-align: left; height: 5px;">
            </td>
        </tr>
        <tr>
            <td colspan="1" style="width: 16px; height: 30px; text-align: left">
            </td>
            <td colspan="1" style="width: 17px; height: 30px; text-align: left">
            </td>
            <td colspan="3" style="height: 30px; text-align: left; vertical-align: top;">
                <asp:Label ID="lblDetalle" runat="server"></asp:Label></td>
            <td colspan="1" style="width: 215px; height: 30px; text-align: left">
            </td>
            <td colspan="1" style="width: 48px; height: 30px; text-align: left">
            </td>
        </tr>
        <tr>
            <td colspan="1" style="width: 16px; height: 15px; text-align: left">
            </td>
            <td colspan="1" style="width: 17px; height: 15px; text-align: left">
            </td>
            <td colspan="3" style="vertical-align: top; height: 15px; text-align: left">
            </td>
            <td colspan="1" style="width: 215px; height: 15px; text-align: left">
            </td>
            <td colspan="1" style="width: 48px; height: 15px; text-align: left">
            </td>
        </tr>
        <tr>
            <td colspan="1" style="width: 16px; height: 14px; text-align: left">
            </td>
            <td colspan="6" style="height: 14px; background-color: black; text-align: left">
            </td>
        </tr>
        <tr>
            <td colspan="1" style="width: 16px; text-align: left; height: 32px;">
            </td>
            <td colspan="1" style="width: 17px; text-align: left; height: 32px;">
            </td>
            <td colspan="3" style="text-align: left; height: 32px;">
            </td>
            <td colspan="1" style="width: 215px; text-align: left; height: 32px;">
            </td>
            <td colspan="1" style="width: 48px; text-align: left; height: 32px;">
            </td>
        </tr>
        <tr>
            <td colspan="1" style="width: 16px; text-align: left; height: 21px;">
            </td>
            <td colspan="6" style="background-color: transparent; text-align: left; height: 21px;">
            </td>
        </tr>
    </table>
</asp:Content>

