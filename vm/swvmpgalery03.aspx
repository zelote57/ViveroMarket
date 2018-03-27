<%@ Page Language="C#" MasterPageFile="~/index.master" AutoEventWireup="true" CodeFile="swvmpgalery03.aspx.cs" Inherits="swvmpgalery03" Title="Galeria - ViveroMarket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 671px; height: 36px" class="galery">
        <tr>
            <td style="background-color: gray; text-align: center; height: 10px;" colspan="4" rowspan="2">
                <span><strong><span class="title">Plantas <%= GetUrl() %>
                </span></strong></span>
            </td>
        </tr>
        <tr>
        </tr>
        <tr>
            <td style="text-align: center;" colspan="4">
                <asp:DataList ID="dlGalery" runat="server" BackColor="White" BorderColor="#CCCCCC"
                    BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                    GridLines="Both" RepeatColumns="5" 
                    ForeColor="Black" OnItemDataBound="dlGalery_ItemDataBound"
                    CssClass="galery" RepeatDirection="Horizontal" Width="100%">
                    <FooterStyle BackColor="Gray" ForeColor="Black" />
                    <SelectedItemStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                    <ItemTemplate>
                        <table width="100%">
                            <tr>
                                <td colspan="2" style="text-align: center">
                                <a href="images/<%= GetUrl() %>/big<%# DataBinder.Eval(Container.DataItem, "SWVM04IMAGENAME")%>" 
                                rel="lightbox-gallery" 
                                title="<%#(Convert.ToString(DataBinder.Eval(Container.DataItem, "SWVM04PROD_NOMBRE"))).ToLower()%>">
                            	<img class = "reflex"src="images/<%= GetUrl() %>/<%# DataBinder.Eval(Container.DataItem, "SWVM04IMAGENAME")%>" height="100" width="100" />&nbsp;</a>
                            	</td>
                                    
                            </tr>
                            <tr>
                                <td class="name" colspan="2" style="height: 16px">
                                    <%#(Convert.ToString(DataBinder.Eval(Container.DataItem, "SWVM04PROD_NOMBRE"))).ToLower()%>
                                </td>
                            </tr>
                            <tr>
                                <td class="detail" colspan="2" style="text-align: justify">
                                    <span class="detalle">Detalle:</span>
                                    <%# ((Convert.ToString(DataBinder.Eval(Container.DataItem,
                                        "SWVM04DESCRIPCION"))).ToLower()).Substring(0,30)%>...
                                </td>
                            </tr>
                            <tr>                                                     
                                <td style="width: 100px; text-align: left; vertical-align: top;">
                                    &nbsp;
                                <a href="swvmicart05.aspx?PID=<%#DataBinder.Eval(Container.DataItem, "SWVM04PROD_ID")%>&CID=<%#DataBinder.Eval(Container.DataItem, "SWVM04CATE_ID")%>&PROV=<%#DataBinder.Eval(Container.DataItem, "SWVM04PROV_ID")%>">
                                <img alt="" src="images/car.png" height="15" width="18" /> </a></td>
                                <td class="detail" style="width: 100px; text-align: right; vertical-align: top;">
                                <a href="swvmigalerydetails04.aspx?PID=<%#DataBinder.Eval(Container.DataItem, "SWVM04PROD_ID")%>&CID=<%#DataBinder.Eval(Container.DataItem, "SWVM04CATE_ID")%>&PROV=<%#DataBinder.Eval(Container.DataItem, "SWVM04PROV_ID")%>">
                                    <img alt="" src="images/ver-mas.gif" />
                                    &nbsp;</a>
                                    </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="text-align: left">
                                    <strong>
                                    Precio:</strong>
                                    $<%#DataBinder.Eval(Container.DataItem, "SWVM04PRECIO", "{0:n}")%>                                    
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <HeaderTemplate>
                        <table width="100%">
                            <tr>
                                <td style="width: 100px; text-align: left;">
                                    &nbsp;<asp:Label ID="lblCuenta" runat="server"></asp:Label>
                                    <span>Productos<span></td>
                                <td style="text-align: right;" colspan="2" class="order">
                                    <span>Ordenar por:<%= GetOrder() %> </span>                                   
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <FooterTemplate>
                        <%= GetPaginacion() %>
                    </FooterTemplate>
                    <ItemStyle BorderWidth="1px" />
                </asp:DataList></td>
        </tr>
    </table>
</asp:Content>

