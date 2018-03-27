<%@ Page Language="C#" MasterPageFile="~/index.master" AutoEventWireup="true" CodeFile="swvmcreportcoti07.aspx.cs" Inherits="swvmcreportcoti07" Title="Reporte de Cotizaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphIndex" Runat="Server">
    <table style="width: 763px; top: 150px; height: 34px" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="9" style="height: 9px; background-color: black; width: 492px;">
            </td>
            <td colspan="1" style="width: 51px; height: 9px; background-color: black">
            </td>
        </tr>
        <tr>
            <td colspan="9" style="width: 492px">
                <strong>&nbsp; &nbsp; &nbsp; Reporte de Cotizaciones</strong></td>
            <td colspan="1" style="width: 51px">
            </td>
        </tr>
        <tr>
            <td colspan="9" style="height: 4px">
            </td>
            <td colspan="1" style="height: 4px">
            </td>
        </tr>
        <tr>
            <td colspan="9" style="border-top: black thin solid; width: 492px;">
                <asp:RadioButtonList ID="rblVer" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rblVer_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="1">Ver cotizaciones de hoy</asp:ListItem>
                    <asp:ListItem Value="0">Ver todas las cotizaciones</asp:ListItem>
                </asp:RadioButtonList></td>
            <td colspan="1" style="border-top: black thin solid; width: 51px; text-align: center">
                <span style="font-size: 7pt">
                    <a href="javascript:print()"><img src="images/print.png" border="0" style="width: 18px; height: 20px" /></a></span></td>
        </tr>
        <tr>
            <td colspan="9" style="border-top: black thin solid; width: 492px; height: 5px; text-align: center;">
            </td>
            <td colspan="1" style="border-top: black thin solid; width: 51px; height: 5px; text-align: center">
            </td>
        </tr>
        <tr>
            <td colspan="9" style="height: 10px; text-align: center">
                <asp:Label ID="lblMensaje" runat="server"></asp:Label></td>
            <td colspan="1" style="height: 10px">
            </td>
        </tr>
        <tr>
            <td colspan="9" style="height: 1px">
            </td>
            <td colspan="1" style="height: 1px">
            </td>
        </tr>
        <tr>
            <td colspan="10" style="vertical-align: top">
                <asp:GridView ID="gvCotiza" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black"
                    GridLines="Horizontal" HorizontalAlign="Center" AllowPaging="True" OnPageIndexChanging="gvCotiza_PageIndexChanging" Width="80%">
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <Columns>
                        <asp:HyperLinkField Text="Ver detalle" DataNavigateUrlFields="cid" DataNavigateUrlFormatString="swvmcdetcoti08.aspx?CID={0}" SortExpression="cid" >
                            <ControlStyle CssClass="ver" />
                        </asp:HyperLinkField>
                        <asp:BoundField DataField="fecha" DataFormatString="{0:dd-MMMM-yyyy}" HeaderText="Fecha"
                            HtmlEncode="False" ReadOnly="True" SortExpression="fecha">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="cid" HeaderText="#Pedido" ReadOnly="True" SortExpression="cid" >
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="cliente" HeaderText="Cliente" ReadOnly="True" SortExpression="cliente">
                            <ItemStyle HorizontalAlign="Justify" />
                        </asp:BoundField>
                        <asp:BoundField DataField="subtotal" HeaderText="Subtotal" ReadOnly="True" SortExpression="subtotal" >
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="iva" HeaderText="Iva" ReadOnly="True" SortExpression="iva" >
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="total" HeaderText="Total" ReadOnly="True" SortExpression="total">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="10" style="vertical-align: top; height: 4px">
            </td>
        </tr>
        <tr>
            <td colspan="9" style="border-bottom: black thin solid; height: 5px; width: 492px;">
            </td>
            <td colspan="1" style="width: 51px; border-bottom: black thin solid; height: 5px">
            </td>
        </tr>
    </table>
</asp:Content>

