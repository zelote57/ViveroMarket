<%@ Page Language="C#" MasterPageFile="~/index.master" AutoEventWireup="true" CodeFile="swvmpnoticias10.aspx.cs" Inherits="swvmpnoticias10" Title="Noticias - ViveroMarket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="0" cellpadding="0" cellspacing="0" width="100%" class="tabla">
        <tr>
            <td style="width: 10px; height: 5px;">
            </td>
            <td style="height: 5px">
            </td>
            <td style="width: 10px; height: 5px;">
            </td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td>
                <span id="ctl00_ContentPlaceHolder1_lblContent"><span style="font-size: 14pt">Noticias
                    y Novedades de la naturaleza</span></span></td>
            <td style="width: 10px">
            </td>
        </tr>
        <tr>
            <td style="width: 10px; height: 6px;">
            </td>
            <td style="border-bottom-color: #ffbb55; height: 6px; border-bottom-style: solid">
            </td>
            <td style="width: 10px; height: 6px;">
            </td>
        </tr>
        <tr>
            <td style="width: 10px; height: 5px">
            </td>
            <td style="height: 5px">
            </td>
            <td style="width: 10px; height: 5px">
            </td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td>
                <asp:DataList ID="dlRss" runat="server"
                    Width="100%">
                    <ItemTemplate>
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 626px">
                            <tr>
                                <td style="height: 14px; font-weight: bold;">
                                <a href="<%#DataBinder.Eval(Container.DataItem, "link")%>" target="_blank" class="rss"><%#DataBinder.Eval(Container.DataItem, "titulo")%></a>
                                    </td>
                            </tr>
                            <tr>
                                <td style="width: 100px; height: 6px;">
                                </td>
                            </tr>
                            <tr>
                                <td style="color: black">
                                    <%#DataBinder.Eval(Container.DataItem, "fecha")%></td>
                            </tr>
                            <tr>
                                <td style="width: 100px; height: 5px;">
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 14px; text-align: justify;">
                                    <%#DataBinder.Eval(Container.DataItem, "detalle")%></td>
                            </tr>
                            <tr>
                                <td style="width: 100px; height: 15px">
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <FooterTemplate>
                     <%= GetPaginacion() %>
                    </FooterTemplate>
                </asp:DataList>
                <asp:Label ID="lblError" runat="server" Visible="False"></asp:Label></td>
            <td style="width: 10px">
            </td>
        </tr>
    </table>

</asp:Content>

