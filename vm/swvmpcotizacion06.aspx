﻿<%@ Page Language="C#" MasterPageFile="~/cotiza.master" AutoEventWireup="true" CodeFile="swvmpcotizacion06.aspx.cs" Inherits="swvmpcotizacion06" Title="Cotización - ViveroMarket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphCotiza" Runat="Server">
<table align="center" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 22px">
            </td>
            <td style="width: 592px">
            </td>
            <td style="width: 33px">
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Panel ID="pMensaje" runat="server" Height="110px" Width="125px" Visible="False">
                    <table cellpadding="0" cellspacing="0" class="0" style="border-right: black thin solid;
                        border-top: black thin solid; border-left: black thin solid; width: 660px; border-bottom: black thin solid;
                        height: 49px; background-color: #444444">
                        <tr>
                            <td style="width: 89px; height: 7px">
                            </td>
                            <td style="width: 12px; height: 7px">
                            </td>
                            <td style="width: 695px; height: 7px">
                            </td>
                            <td style="width: 57px; height: 7px">
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2" style="width: 89px; text-align: center">
                                <asp:Image ID="imgCartstate" runat="server" ImageUrl="~/images/good.png" /></td>
                            <td style="width: 12px; height: 2px;">
                            </td>
                            <td rowspan="2" style="width: 695px">
                                <p>
                                    <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="14pt"></asp:Label>&nbsp;</p>
                                <p>
                                    <asp:Label ID="lblP" runat="server" 
                                    Font-Bold="False" 
                                    Font-Names="Tahoma" 
                                    Font-Size="9pt"></asp:Label>&nbsp;</p>
                            </td>
                            <td style="width: 57px; height: 2px;">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 12px; height: 29px">
                            </td>
                            <td style="width: 57px; height: 29px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 89px; height: 12px">
                            </td>
                            <td style="width: 12px; height: 12px">
                            </td>
                            <td style="width: 695px; height: 12px">
                            </td>
                            <td style="width: 57px; height: 12px">
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    <tr>
        <td colspan="3">
            <asp:Label ID="lblMsgtop" runat="server" Text="La siguiente cotización será
             enviada a su correo electronico con los pasos a seguir para concretar la compra."></asp:Label></td>
    </tr>
        <tr>
            <td style="width: 22px; height: 10px;">
            </td>
            <td style="width: 592px; height: 10px;">
            </td>
            <td style="width: 33px; height: 10px;">
            </td>
        </tr>
    </table>
    <table align="center" border="0" cellpadding="0" cellspacing="0" class="cotiza">
        <tr>
            <td style="width: 50px; height: 20px">
            </td>
            <td colspan="7" style="height: 20px">
            </td>
            <td style="width: 50px;" rowspan="2">
                <img src="images/corner.jpg" /></td>
        </tr>
        <tr>
            <td style="width: 50px">
            </td>
            <td colspan="7">
                <h1 style="text-align: center">
                    <asp:Label ID="lblLastcotiza" runat="server"></asp:Label>&nbsp;</h1>
            </td>
        </tr>
        <tr>
            <td style="width: 50px; height: 12px;">
            </td>
            <td style="height: 12px">
            </td>
            <td style="width: 10px; height: 12px;">
            </td>
            <td style="width: 238px; height: 12px;">
            </td>
            <td style="width: 65px; height: 12px;">
            </td>
            <td style="height: 12px">
            </td>
            <td style="width: 10px; height: 12px;">
            </td>
            <td style="width: 105px; height: 12px;">
            </td>
            <td style="width: 50px; height: 12px;">
            </td>
        </tr>
        <tr>
            <td style="width: 50px">
            </td>
            <td style="text-align: left">
                <strong>Cliente:</strong></td>
            <td style="width: 10px; text-align: left">
            </td>
            <td style="width: 238px; text-align: left">
                <asp:Label ID="lblCliente" runat="server"></asp:Label></td>
            <td style="width: 65px; text-align: left">
                <strong></strong>
            </td>
            <td style="text-align: left">
                <strong>Fecha:</strong></td>
            <td style="width: 10px; text-align: left">
            </td>
            <td style="width: 105px; text-align: left">
                <asp:Label ID="lblFecha" runat="server"></asp:Label>
            </td>
            <td style="width: 50px">
            </td>
        </tr>
        <tr>
            <td style="width: 50px; height: 6px;">
            </td>
            <td style="height: 6px">
            </td>
            <td style="width: 10px; height: 6px;">
            </td>
            <td style="width: 238px; height: 6px;">
            </td>
            <td style="width: 65px; height: 6px;">
            </td>
            <td style="height: 6px">
            </td>
            <td style="width: 10px; height: 6px;">
            </td>
            <td style="width: 105px; height: 6px;">
            </td>
            <td style="width: 50px; height: 6px;">
            </td>
        </tr>
        <tr>
            <td style="width: 50px">
            </td>
            <td style="text-align: left">
                <strong>Ci/Ruc:</strong></td>
            <td style="width: 10px; text-align: left">
            </td>
            <td style="width: 238px; text-align: left">
                <asp:Label ID="lblCiruc" runat="server"></asp:Label></td>
            <td style="width: 65px">
            </td>
            <td style="text-align: left">
                <strong>Teléfono:</strong></td>
            <td style="width: 10px; text-align: left">
            </td>
            <td style="width: 105px; text-align: left">
                <asp:Label ID="lblFono" runat="server"></asp:Label></td>
            <td style="width: 50px">
            </td>
        </tr>
        <tr>
            <td style="width: 50px; height: 6px;">
            </td>
            <td style="height: 6px">
            </td>
            <td style="width: 10px; height: 6px;">
            </td>
            <td style="width: 238px; height: 6px;">
            </td>
            <td style="width: 65px; height: 6px;">
            </td>
            <td style="height: 6px">
            </td>
            <td style="width: 10px; height: 6px;">
            </td>
            <td style="width: 105px; height: 6px;">
            </td>
            <td style="width: 50px; height: 6px;">
            </td>
        </tr>
        <tr>
            <td style="width: 50px">
            </td>
            <td>
                <strong>Dirección:</strong></td>
            <td style="width: 10px">
            </td>
            <td style="width: 238px; text-align: left">
                <asp:Label ID="lblDir" runat="server"></asp:Label></td>
            <td style="width: 65px">
            </td>
            <td>
            </td>
            <td style="width: 10px">
            </td>
            <td style="width: 105px">
            </td>
            <td style="width: 50px">
            </td>
        </tr>
        <tr>
            <td style="width: 50px; height: 10px;">
            </td>
            <td style="height: 10px">
            </td>
            <td style="width: 10px; height: 10px;">
            </td>
            <td style="width: 238px; height: 10px;">
            </td>
            <td style="width: 65px; height: 10px;">
            </td>
            <td style="height: 10px">
            </td>
            <td style="width: 10px; height: 10px;">
            </td>
            <td style="width: 105px; height: 10px;">
            </td>
            <td style="width: 50px; height: 10px;">
            </td>
        </tr>
        <tr>
            <td style="width: 50px">
            </td>
            <td colspan="7" style="vertical-align: top; text-align: center">
                <asp:GridView ID="gvDetalle" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black"
                    GridLines="Horizontal" CssClass="detalle" Width="100%">
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <Columns>
                        <asp:BoundField HeaderText="C&#243;digo" DataField="codigo" SortExpression="codigo" >
                            <ItemStyle CssClass="cod" HorizontalAlign="Left" Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Producto" DataField="nombreprod" SortExpression="nombreprod" >
                            <ItemStyle CssClass="prod" HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Cantidad" DataField="cantidad" SortExpression="cantidad" >
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="P. Unitario" DataField="preciouni" SortExpression="preciouni" >
                            <ItemStyle CssClass="puni" HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="TOTAL" DataField="subtotal" SortExpression="subtotal" >
                            <ItemStyle CssClass="tot" HorizontalAlign="Right" />
                        </asp:BoundField>
                    </Columns>
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </td>
            <td style="width: 50px">
            </td>
        </tr>
        <tr>
            <td style="width: 50px; height: 2px;">
            </td>
            <td style="height: 2px">
            </td>
            <td style="width: 10px; height: 2px;">
            </td>
            <td style="width: 238px; height: 2px;">
            </td>
            <td style="width: 65px; height: 2px;">
            </td>
            <td style="height: 2px">
            </td>
            <td style="width: 10px; height: 2px;">
            </td>
            <td style="width: 105px; height: 2px;">
            </td>
            <td style="width: 50px; height: 2px;">
            </td>
        </tr>
        <tr>
            <td style="width: 50px">
            </td>
            <td colspan="7">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td style="width: 357px; height: 5px">
                        </td>
                        <td style="border-left: black thin solid; width: 9px; height: 5px; background-color: #333333; border-top: black thin solid;">
                        </td>
                        <td style="border-top: black thin solid; width: 10px; height: 5px; background-color: #333333; color: white;">
                        </td>
                        <td style="border-top: black thin solid; width: 11px; height: 5px; background-color: #333333">
                        </td>
                        <td style="border-top: black thin solid; width: 70px; height: 5px; background-color: white">
                        </td>
                        <td style="border-right: black thin solid; width: 12px; height: 5px; background-color: white; border-top: black thin solid;">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 357px; height: 5px">
                        </td>
                        <td style="border-left: black thin solid; width: 9px; height: 5px; background-color: #333333">
                        </td>
                        <td style="width: 10px; height: 5px; background-color: #333333; text-align: right; color: white;">
                            <strong>Subtotal:</strong></td>
                        <td style="width: 11px; height: 5px; background-color: #333333">
                        </td>
                        <td style="width: 70px; height: 5px; background-color: white; text-align: right;">
                            $<asp:Label ID="lblSt" runat="server"></asp:Label></td>
                        <td style="border-right: black thin solid; width: 12px; height: 5px; background-color: white">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 357px; height: 5px">
                        </td>
                        <td style="border-left: black thin solid; width: 9px; border-bottom: black thin solid;
                            height: 5px; background-color: #333333">
                        </td>
                        <td style="width: 18px; border-bottom: black thin solid; height: 5px; background-color: #333333">
                        </td>
                        <td style="width: 11px; border-bottom: black thin solid; height: 5px; background-color: #333333">
                        </td>
                        <td style="width: 70px; border-bottom: black thin solid; height: 5px; background-color: white">
                        </td>
                        <td style="border-right: black thin solid; width: 12px; border-bottom: black thin solid;
                            height: 5px; background-color: white">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 357px; height: 5px">
                        </td>
                        <td style="border-left: black thin solid; width: 9px; height: 5px; background-color: #333333">
                        </td>
                        <td style="width: 10px; height: 5px; background-color: #333333; color: white;">
                        </td>
                        <td style="width: 11px; height: 5px; background-color: #333333">
                        </td>
                        <td style="width: 70px; height: 5px; background-color: white">
                        </td>
                        <td style="border-right: black thin solid; width: 12px; height: 5px; background-color: white">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 357px; height: 5px">
                        </td>
                        <td style="border-left: black thin solid; width: 9px; height: 5px; background-color: #333333">
                        </td>
                        <td style="width: 10px; height: 5px; background-color: #333333; text-align: right; color: white;">
                            <strong>IVA:</strong></td>
                        <td style="width: 11px; height: 5px; background-color: #333333">
                        </td>
                        <td style="width: 70px; height: 5px; background-color: white; text-align: right;">
                            $<asp:Label ID="lblIva" runat="server"></asp:Label></td>
                        <td style="border-right: black thin solid; width: 12px; height: 5px; background-color: white">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 357px; height: 5px">
                        </td>
                        <td style="border-left: black thin solid; width: 9px; height: 5px; background-color: #333333; color: white; border-bottom: black thin solid;">
                        </td>
                        <td style="width: 10px; height: 5px; background-color: #333333; color: white; border-bottom: black thin solid;">
                        </td>
                        <td style="width: 11px; height: 5px; background-color: #333333; color: white; border-bottom: black thin solid;">
                        </td>
                        <td style="width: 70px; height: 5px; background-color: white; color: white; border-bottom: black thin solid;">
                        </td>
                        <td style="border-right: black thin solid; width: 12px; height: 5px; background-color: white; color: white; border-bottom: black thin solid;">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 357px; height: 5px">
                        </td>
                        <td style="border-left: black thin solid; width: 9px; height: 5px; background-color: #333333">
                        </td>
                        <td style="width: 10px; color: white; height: 5px; background-color: #333333">
                        </td>
                        <td style="width: 11px; height: 5px; background-color: #333333">
                        </td>
                        <td style="width: 70px; height: 5px; background-color: white">
                        </td>
                        <td style="border-right: black thin solid; width: 12px; height: 5px; background-color: white">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 357px; height: 5px">
                        </td>
                        <td style="border-left: black thin solid; width: 9px; height: 5px; background-color: #333333">
                        </td>
                        <td style="width: 10px; height: 5px; background-color: #333333; text-align: right; color: white;">
                            <strong>Total:</strong></td>
                        <td style="width: 11px; height: 5px; background-color: #333333">
                        </td>
                        <td style="width: 70px; height: 5px; background-color: white; text-align: right;">
                            $<asp:Label ID="lblTotal" runat="server" ForeColor="Black"></asp:Label></td>
                        <td style="border-right: black thin solid; width: 12px; height: 5px; background-color: white">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 357px; height: 5px">
                        </td>
                        <td style="border-left: black thin solid; width: 9px; height: 5px; background-color: #333333; border-bottom: black thin solid;">
                        </td>
                        <td style="width: 10px; border-bottom: black thin solid; height: 5px; background-color: #333333; color: white;">
                        </td>
                        <td style="width: 11px; border-bottom: black thin solid; height: 5px; background-color: #333333">
                        </td>
                        <td style="width: 70px; border-bottom: black thin solid; height: 5px; background-color: white">
                        </td>
                        <td style="border-right: black thin solid; width: 12px; height: 5px; background-color: white; border-bottom: black thin solid;">
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 50px">
            </td>
        </tr>
        <tr>
            <td style="width: 50px; height: 15px;">
            </td>
            <td style="height: 15px">
            </td>
            <td style="width: 10px; height: 15px;">
            </td>
            <td style="width: 238px; height: 15px;">
            </td>
            <td style="width: 65px; height: 15px;">
            </td>
            <td style="height: 15px">
            </td>
            <td style="width: 10px; height: 15px;">
            </td>
            <td style="width: 105px; height: 15px;">
            </td>
            <td style="width: 50px; height: 15px;">
            </td>
        </tr>
        <tr>
            <td style="width: 50px; height: 14px">
            </td>
            <td colspan="3" style="height: 14px">
                <strong>ViveroMarket.com</strong></td>
            <td colspan="4" style="height: 14px">
                Tiempo de Valides 15 días desde su emisión</td>
            <td style="width: 50px; height: 14px">
            </td>
        </tr>
        <tr>
            <td style="width: 50px; height: 15px">
            </td>
            <td style="height: 15px">
            </td>
            <td style="width: 10px; height: 15px">
            </td>
            <td style="width: 238px; height: 15px">
            </td>
            <td style="width: 65px; height: 15px">
            </td>
            <td style="height: 15px">
            </td>
            <td style="width: 10px; height: 15px">
            </td>
            <td style="width: 105px; height: 15px">
            </td>
            <td style="width: 50px; height: 15px">
            </td>
        </tr>
    </table>
<table align="center" border="0" cellpadding="0" cellspacing="0" cssclass="tabla">
        <tr>
            <td style="width: 32px; height: 13px;">
            </td>
            <td style="width: 489px; height: 13px;">
            </td>
            <td style="width: 106px; height: 13px">
            </td>
            <td style="width: 13px; height: 13px;">
            </td>
        </tr>
        <tr>
            <td style="height: 10px;" colspan="2">
                <asp:Label ID="lblMsgbottom" runat="server" Text='Al presionar aceptar usted acepta los términos para la compra <a href="swvmpterminos13.aspx">aquí </a>descritos.'></asp:Label></td>
            <td style="width: 106px; height: 10px; text-align: right">
                <asp:LinkButton ID="lknAceptar" runat="server" CausesValidation="False" CssClass="btnAceptar"
                    Width="80px" OnClick="lknAceptar_Click">Aceptar</asp:LinkButton></td>
            <td style="width: 13px; height: 10px;">
            </td>
        </tr>
    <tr>
        <td style="width: 32px; height: 10px">
        </td>
        <td style="width: 489px; height: 10px">
        </td>
        <td style="width: 106px; height: 10px; text-align: right">
        </td>
        <td style="width: 13px; height: 10px">
        </td>
    </tr>
    </table>
</asp:Content>

