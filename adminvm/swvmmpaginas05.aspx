<%@ Page Language="C#" MasterPageFile="~/index.master" AutoEventWireup="true" CodeFile="swvmmpaginas05.aspx.cs" Inherits="swvmmpaginas05" Title="Administración de Páginas - ViveroMarket" validateRequest="false" %>

<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphIndex" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" style="width: 800px; height: 39px">
        <tr>
            <td colspan="5" style="text-align: left">
                <span style="font-size: 16pt; color: #88cc55">
                Edición de páginas de Vivero Market</span>                
            </td>
        </tr>
        <tr>
            <td style="width: 14px; height: 6px">
            </td>
            <td style="height: 6px" colspan="3">
            </td>
            <td style="width: 36px; height: 6px">
            </td>
        </tr>
        <tr>
            <td style="width: 14px; height: 22px">
            </td>
            <td style="height: 22px" colspan="4">
                Seleccione una página para editar:
                <asp:DropDownList ID="ddlPaginas" runat="server" Width="150px" DataTextField="nombre" DataValueField="pagid" OnSelectedIndexChanged="ddlPaginas_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList>
                &nbsp;<asp:Label ID="lblDescripcion" runat="server" Visible="False"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 14px; height: 10px">
            </td>
            <td style="height: 10px" colspan="3">
            </td>
            <td style="width: 36px; height: 10px">
            </td>
        </tr>
        <tr>
            <td style="width: 14px">
            </td>
            <td colspan="3">
    <FTB:FreeTextBox ID="ftbEditor" runat="server" 
    ButtonSet="NotSet" 
    Language="es-ES" 
    ToolbarStyleConfiguration="OfficeXP" 
    toolbarlayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu,FontForeColorPicker|Bold,Italic,Underline,Strikethrough,Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImage|Cut,Copy,Paste;Undo,Redo,Print|SymbolsMenu,InsertRule,InsertDate,InsertTime|InsertTable,Preview,SelectAll"
    ReadOnly="True" Width="685px">
    </FTB:FreeTextBox>
            </td>
            <td style="width: 36px">
            </td>
        </tr>
        <tr>
            <td style="width: 14px; height: 5px">
            </td>
            <td style="height: 5px" colspan="3">
                &nbsp;
            </td>
            <td style="width: 36px; height: 5px">
            </td>
        </tr>
        <tr>
            <td style="width: 14px; height: 22px">
            </td>
            <td colspan="3" style="height: 22px">
                <asp:Button ID="btnEditar" runat="server" BorderStyle="Solid" CausesValidation="False"
                    CssClass="btnmodify" Font-Bold="False" Font-Size="10pt" OnClick="btnEditar_Click"
                    Text="   Editar" />&nbsp; &nbsp;<asp:Button ID="btnGuardar" runat="server" BorderStyle="Solid"
                        CssClass="btnsave" Font-Bold="False" Font-Size="10pt" OnClick="btnGuardar_Click"
                        Text="   Guardar" Enabled="False" />
                &nbsp;
                <asp:Button ID="btnCancelar" runat="server" BorderStyle="Solid" CausesValidation="False"
                    CssClass="btncancel" Font-Bold="False" Font-Size="10pt" OnClick="btnCancelar_Click"
                    Text="   Cancelar" Enabled="False" /></td>
            <td style="width: 36px; height: 22px">
            </td>
        </tr>
        <tr>
            <td style="width: 14px; height: 6px;">
            </td>
            <td style="height: 6px;" colspan="3">
            </td>
            <td style="width: 36px; height: 6px;">
            </td>
        </tr>
    </table>
</asp:Content>

