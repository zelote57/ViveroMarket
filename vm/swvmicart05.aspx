<%@ Page Language="C#" MasterPageFile="~/index.master" AutoEventWireup="true" CodeFile="swvmicart05.aspx.cs" Inherits="swvmicart05" Title="Carrito de Compras - ViveroMarket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 694px" class="cart">
        <tr>
            <td style="width: 3px">
            </td>
            <td style="width: 207px">
                <span style="font-size: 18pt; color: #000000">
                    Carrito de Compras</span></td>
            <td style="width: 3px">
            </td>
        </tr>
        <tr>
            <td style="width: 3px;">
            </td>
            <td style="width: 207px;">
                <span>
                Estos son los items de su carrito de compras.</span></td>
            <td style="width: 3px;">
            </td>
        </tr>
        <tr>
            <td style="width: 3px; height: 5px">
            </td>
            <td style="width: 207px; height: 5px">
            </td>
            <td style="width: 3px; height: 5px">
            </td>
        </tr>
        <tr>
            <td style="width: 3px;">
            </td>
            <td style="width: 207px;">
                <asp:Panel ID="pCartstate" runat="server" Height="110px" Width="125px" Visible="False">
                <table cellpadding="0" cellspacing="0" class="0" style="width: 660px; height: 49px;
                        background-color: #444444; border-right: black thin solid; border-top: black thin solid; border-left: black thin solid; border-bottom: black thin solid;">
                        <tr>
                            <td style="width: 89px; height: 10px;">
                            </td>
                            <td style="width: 12px; height: 10px;">
                            </td>
                            <td style="width: 695px; height: 10px;">
                            </td>
                            <td style="width: 57px; height: 10px;">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 89px; text-align: center;" rowspan="2">
                                <asp:Image ID="imgCartstate" runat="server" /></td>
                            <td style="width: 12px">
                            </td>
                            <td style="width: 695px" rowspan="2">
                                <p>
                                    <asp:Label ID="lblCartstatetitle" runat="server" Font-Bold="True" Font-Names="Tahoma"
                                        Font-Size="14pt"></asp:Label>&nbsp;</p>
                                <p>
                                    <asp:Label ID="lblCartstate" runat="server" Font-Bold="False" Font-Names="Tahoma" Font-Size="9pt"></asp:Label>&nbsp;</p>
                            </td>
                            <td style="width: 57px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 12px; height: 62px">
                            </td>
                            <td style="width: 57px; height: 62px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 89px; height: 20px">
                            </td>
                            <td style="width: 12px; height: 20px">
                            </td>
                            <td style="width: 695px; height: 20px">
                            </td>
                            <td style="width: 57px; height: 20px">
                            </td>
                        </tr>
                    </table>                    
                </asp:Panel>
            
            </td>
            <td style="width: 3px;">
            </td>
        </tr>
        <tr>
            <td style="width: 3px; height: 1px;">
            </td>
            <td style="width: 207px; height: 1px; text-align: center;">
                </td>
            <td style="width: 3px; height: 1px;">
            </td>
        </tr>
        <tr>
            <td style="width: 3px">
            </td>
            <td style="width: 207px">
                <asp:Label ID="lblWords" runat="server" Font-Size="13pt" Text="Productos Seleccionados" Visible="False"></asp:Label></td>
            <td style="width: 3px">
            </td>
        </tr>
        <tr>
            <td style="width: 3px; height: 4px">
            </td>
            <td style="width: 207px; height: 4px">
            </td>
            <td style="width: 3px; height: 4px">
            </td>
        </tr>
        <tr>
            <td style="width: 3px">
            </td>
            <td>
                <asp:GridView ID="gvCart" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black"
                    GridLines="Horizontal" HorizontalAlign="Center" OnRowDeleting="gvCart_RowDeleting">
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <Columns>
                        <asp:TemplateField HeaderText="Producto" SortExpression="nombreprod">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("nombreprod") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td style="width: 4px; height: 15px; text-align: center">
                                        </td>
                                        <td style="height: 15px; text-align: center">
                                <img alt ="" src="images/<%# DataBinder.Eval(Container, "DataItem.image") %>" height="50" width="50" /></td>
                                        <td style="vertical-align: middle; width: 55px; height: 15px; text-align: center" class ="lkndetails">
                                <a href="<%# DataBinder.Eval(Container, "DataItem.lnkdetails") %>">
                                <asp:Label ID="lblProducto" runat="server" Text='<%# Bind("nombreprod") %>' Font-Bold="True" CssClass="lkndetails"></asp:Label>
                                </a>
                                </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                            <ItemStyle Width="140px" />
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="codigo" HeaderText="C&#243;digo" SortExpression="codigo" >
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Precio Unitario" SortExpression="preciouni">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("preciouni") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                            <ItemTemplate>
                                <asp:Label ID="lblPrecioUni" runat="server" Text='<%# Bind("preciouni", "${0}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cantidad">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtEditCantidad" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.cantidad") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td style="width: 100px; text-align: center;">
                                <asp:TextBox ID="txtCantidad" 
                                runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.cantidad") %>'
                                    Width="47px" onkeypress="javascript:return num_sin_enter(event);" ></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; text-align: center;">
                                            <asp:Label ID="lblNoStock" runat="server" Font-Size="Smaller" ForeColor="Red"
                                                Visible="true" Text='<%# DataBinder.Eval(Container, "DataItem.msgstock") %>'></asp:Label></td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                            <ItemTemplate>
                                <asp:Label ID="lblSubTotal" runat="server" Text='<%# Bind("subtotal", "${0}") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:ButtonField ButtonType="Image" ImageUrl="~/images/delete.gif" Text="Eliminar" CommandName="Delete" >
                            <ItemStyle Width="40px" />
                        </asp:ButtonField>
                    </Columns>
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                </asp:GridView>
            </td>
            <td style="width: 3px">
            </td>
        </tr>
        <tr>
            <td style="width: 3px; height: 2px">
            </td>
            <td style="vertical-align: top; width: 207px; height: 2px; text-align: left">
            </td>
            <td style="width: 3px; height: 2px">
            </td>
        </tr>
        <tr>
            <td style="width: 3px; height: 3px;">
            </td>
            <td style="width: 207px; height: 3px; text-align: left; vertical-align: top;">
                <asp:Image ID="imgBack" runat="server" Height="19px" ImageUrl="~/images/atras.png"
                    Width="19px" />
                <strong style="vertical-align: top">
                    <asp:LinkButton ID="lknRegresar" runat="server">Seguir Comprando:</asp:LinkButton>&nbsp;
                </strong><span style="vertical-align: top;"><asp:Label
                        ID="lblCategoria" runat="server"></asp:Label></span></td>
            <td style="width: 3px; height: 3px;">
            </td>
        </tr>
        <tr>
            <td style="width: 3px">
            </td>
            <td>
                <asp:Panel ID="pCuenta" runat="server" Width="100%" Visible="False">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 10307px" rowspan="2">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ¿Hizo cambios
                            en el carro?
                            <asp:LinkButton ID="lknActualizar" runat="server" CausesValidation="False" CssClass="btnActualizar"
                                OnClick="lknActualizar_Click" Width="80px">Actualizar</asp:LinkButton></td>
                        <td style="width: 291px; height: 6px; background-color: #333333; text-align: right; border-top: black thin solid; border-left: black thin solid;">
                        </td>
                        <td style="width: 169px; height: 6px; background-color: #333333; text-align: right; border-top: black thin solid;">
                        </td>
                        <td style="width: 142px; height: 6px; background-color: #333333; text-align: right; border-right: black thin solid; border-top: black thin solid;">
                        </td>
                        <td style="border-top: black thin solid; width: 263px;
                            height: 6px; background-color: #333333; text-align: right;">
                        </td>
                        <td style="width: 79px; border-right: black thin solid; border-top: black thin solid; height: 6px; background-color: #333333; text-align: right;">
                        </td>
                        <td style="width: 116px; height: 6px">
                        </td>
                        <td style="width: 479px; height: 6px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 291px; height: 15px; background-color: #333333; text-align: right; border-left: black thin solid;">
                        </td>
                        <td style="width: 169px; height: 15px; background-color: #333333; text-align: right">
                            <strong>SubTotal:</strong></td>
                        <td style="width: 142px; height: 15px; background-color: #333333; text-align: right; border-right: black thin solid;">
                        </td>
                        <td style="width: 263px;
                            height: 15px; background-color: #333333; text-align: right">
                            $<asp:Label ID="lblSt" runat="server"></asp:Label></td>
                        <td style="width: 79px; border-right: black thin solid; height: 15px; background-color: #333333; text-align: right;">
                        </td>
                        <td style="width: 116px; height: 15px">
                        </td>
                        <td style="width: 479px; height: 15px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10307px; height: 6px">
                        </td>
                        <td style="width: 291px; height: 6px; background-color: #333333; text-align: right; border-left: black thin solid; border-bottom: black thin solid;">
                        </td>
                        <td style="width: 169px; height: 6px; background-color: #333333; text-align: right; border-bottom: black thin solid;">
                        </td>
                        <td style="width: 142px; height: 6px; background-color: #333333; text-align: right; border-right: black thin solid; border-bottom: black thin solid;">
                        </td>
                        <td style="width: 263px;
                            height: 6px; background-color: #333333; border-bottom: black thin solid; text-align: right;">
                        </td>
                        <td style="border-right: black thin solid; width: 79px;
                            height: 6px; background-color: #333333; border-bottom: black thin solid; text-align: right;">
                        </td>
                        <td style="width: 116px; height: 6px">
                        </td>
                        <td style="width: 479px; height: 6px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10307px; height: 6px">
                            <strong></strong>
                        </td>
                        <td style="border-left: black thin solid; width: 291px; height: 6px; background-color: #333333;">
                        </td>
                        <td style="width: 169px; height: 6px; background-color: #333333;">
                        </td>
                        <td style="border-right: black thin solid; width: 142px; height: 6px; background-color: #333333;">
                        </td>
                        <td style="width: 263px; height: 6px; background-color: #333333;">
                        </td>
                        <td style="border-right: black thin solid; width: 79px; height: 6px; background-color: #333333;">
                        </td>
                        <td style="width: 116px; height: 6px">
                        </td>
                        <td style="width: 479px; height: 6px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10307px; height: 15px">
                            <strong></strong>
                        </td>
                        <td style="width: 291px; height: 15px; border-left: black thin solid; background-color: #333333;">
                        </td>
                        <td style="width: 169px; height: 15px; text-align: right; background-color: #333333;">
                            <strong>
                            Iva:</strong></td>
                        <td style="border-right: black thin solid; width: 142px; height: 15px; background-color: #333333;">
                        </td>
                        <td style="width: 263px; height: 15px; text-align: right; background-color: #333333;">
                            $<asp:Label ID="lblIva" runat="server"></asp:Label></td>
                        <td style="width: 79px; height: 15px; border-right: black thin solid; background-color: #333333;">
                        </td>
                        <td style="width: 116px; height: 15px">
                        </td>
                        <td style="width: 479px; height: 15px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10307px; height: 6px">
                        </td>
                        <td style="border-left: black thin solid; width: 291px; border-bottom: black thin solid;
                            height: 6px; background-color: #333333;">
                        </td>
                        <td style="width: 169px; border-bottom: black thin solid; height: 6px; background-color: #333333;">
                        </td>
                        <td style="border-right: black thin solid; width: 142px; border-bottom: black thin solid;
                            height: 6px; background-color: #333333;">
                        </td>
                        <td style="width: 263px; border-bottom: black thin solid; height: 6px; background-color: #333333;">
                        </td>
                        <td style="border-right: black thin solid; width: 79px; border-bottom: black thin solid;
                            height: 6px; background-color: #333333;">
                        </td>
                        <td style="width: 116px; height: 6px">
                        </td>
                        <td style="width: 479px; height: 6px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10307px; height: 6px">
                        </td>
                        <td style="border-left: black thin solid; width: 291px; height: 6px; background-color: #ffe683;">
                        </td>
                        <td style="width: 169px; height: 6px; background-color: #ffe683;">
                        </td>
                        <td style="border-right: black thin solid; width: 142px; height: 6px; background-color: #ffe683;">
                        </td>
                        <td style="width: 263px; height: 6px; background-color: #ffe683;">
                        </td>
                        <td style="width: 79px; height: 6px; background-color: #ffe683; border-right: black thin solid;">
                        </td>
                        <td style="width: 116px; height: 6px">
                        </td>
                        <td style="width: 479px; height: 6px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10307px; height: 15px">
                        </td>
                        <td style="border-left: black thin solid; width: 291px; height: 15px; background-color: #ffe683;">
                        </td>
                        <td style="width: 169px; height: 15px; text-align: right; background-color: #ffe683;">
                            <strong><span style="color: #000000">
                            Total:</span></strong></td>
                        <td style="border-right: black thin solid; width: 142px; height: 15px; background-color: #ffe683;">
                        </td>
                        <td style="width: 263px; height: 6px; text-align: right; background-color: #ffe683;">
                            <span style="color: #000000">$</span><asp:Label ID="lblTotal" runat="server" ForeColor="Black"></asp:Label></td>
                        <td style="width: 79px; height: 6px; background-color: #ffe683; border-right: black thin solid;">
                        </td>
                        <td style="width: 116px; height: 15px">
                        </td>
                        <td style="width: 479px; height: 15px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10307px; height: 6px">
                        </td>
                        <td style="border-left: black thin solid; width: 291px; border-bottom: black thin solid;
                            height: 6px; background-color: #ffe683;">
                        </td>
                        <td style="width: 169px; border-bottom: black thin solid; height: 6px; background-color: #ffe683;">
                        </td>
                        <td style="border-right: black thin solid; width: 142px; border-bottom: black thin solid;
                            height: 6px; background-color: #ffe683;">
                        </td>
                        <td style="width: 263px; height: 6px; background-color: #ffe683; border-bottom: black thin solid;">
                        </td>
                        <td style="width: 79px;
                            height: 6px; background-color: #ffe683; border-right: black thin solid; border-bottom: black thin solid;">
                        </td>
                        <td style="width: 116px; height: 6px">
                        </td>
                        <td style="width: 479px; height: 6px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10307px; height: 15px">
                        </td>
                        <td style="height: 15px; width: 291px;">
                        </td>
                        <td style="height: 15px">
                        </td>
                        <td style="height: 15px">
                        </td>
                        <td style="width: 263px; height: 15px">
                        </td>
                        <td style="width: 79px; height: 15px">
                        </td>
                        <td style="width: 116px; height: 15px">
                        </td>
                        <td style="width: 479px; height: 15px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10307px; height: 6px">
                        </td>
                        <td style="width: 291px">
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td colspan="3" style="height: 6px; text-align: right">
                            <asp:LinkButton ID="lknCotizar" runat="server" CssClass="btnCotizar" OnClick="lknCotizar_Click"
                                Width="80px">Cotizar</asp:LinkButton></td>
                        <td style="width: 479px; height: 6px">
                        </td>
                    </tr>
                </table>
                </asp:Panel>
                
            </td>
            <td style="width: 3px">
            </td>
        </tr>
        <tr>
            <td style="width: 3px">
            </td>
            <td>
                </td>
            <td style="width: 3px">
            </td>
        </tr>
    </table>
    
</asp:Content>

