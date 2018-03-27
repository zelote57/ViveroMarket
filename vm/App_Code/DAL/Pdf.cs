using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using DAL.Entidades;

namespace DAL
{
    /// <summary>
    /// Pdf: Makepdf
    /// </summary>
    public class Pdf
    {
        public void Makepdf(int cotiid, string ruta)
        {
            //funciones 
            Funciones f = new Funciones();
            //traemos datos de la tabla cotizaciones para llenar documento pdf
            CotizaBD ctzBD = new CotizaBD();
            CotizaCab cCab = ctzBD.ConsultarCab(cotiid);
            List<CotizaDet> listcDet = ctzBD.ConsultarDet(cotiid);
            
            //creacion de documento
            Document document = new Document();
            PdfWriter pdfw = default(PdfWriter);
            PdfContentByte cb = default(PdfContentByte);
            iTextSharp.text.pdf.BaseFont fuente = default(iTextSharp.text.pdf.BaseFont);
            //para que el pdf se cree en la carpeta debe asegurarse que se tienen todos los pemisos en el servidor
            pdfw = PdfWriter.GetInstance(document, new FileStream(ruta+ cotiid.ToString() + ".pdf", FileMode.Create, FileAccess.Write, FileShare.None));
            //apertura para iniciar incercion de datos
            document.Open();
            cb = pdfw.DirectContent;
            //Nueva pagina
            document.NewPage();
            cb.BeginText();
            fuente = FontFactory.GetFont(FontFactory.TIMES_ROMAN, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont;
            cb.SetFontAndSize(fuente, 20);
            cb.SetColorFill(iTextSharp.text.Color.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Cotización # " + cotiid.ToString(), 300, PageSize.LEDGER.Height - 75, 0);
            cb.EndText();
            pdfw.Flush();

            //creacion de la tabla detalle
            Table oTblDet = new Table(5, listcDet.Count - 1);
            oTblDet.DefaultHorizontalAlignment = 1;
            
            //Instancia de clienteBD para accder medoto consultarC para obetener datos del Cliente
            ClienteBD cliBD = new ClienteBD();
            Cliente cli = cliBD.ConsultarC(cCab.Cliid);
            
            //Incersion del logo al documento            
            try
            {
                Image png = Image.GetInstance(new Uri("http://viveromarket.com/images/logo.png"));
                png.SetAbsolutePosition(350, 753);
                png.ScalePercent(85);
                document.Add(png);
            }
            catch
            {
            }

            //parrafos cabecera de documento datos de ViveroMarket
            Paragraph p0 = new Paragraph(new Chunk("ViveroMarket.com / Vivero Cia. Ltd. ", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
            Paragraph p01 = new Paragraph(new Chunk("Acuerelas del Rio Mz. 225 V. 1 - Fono: 042236212", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
            Paragraph p02 = new Paragraph(new Chunk("email: ventas@viveromarket.com", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
            
            //parrafos cabecera de Cotizacion
            Paragraph p1 = new Paragraph(new Chunk("Cliente:       "+f.Mayus(cli.Nombre.ToLower())
                + tabulador1(cli.Nombre.Length) +
                "Fecha:       " + cCab.Fecha.ToShortDateString().ToString(),
                FontFactory.GetFont(FontFactory.HELVETICA, 12)));
            Paragraph p2 = new Paragraph(new Chunk("Ci/Ruc:       "+cli.Ciruc
                + tabulador2(cli.Nombre.Length,cli.Ciruc.Length) +
                "Teléfono:   "+cli.Fono1, FontFactory.GetFont(FontFactory.HELVETICA, 12)));
            Paragraph p3 = new Paragraph(new Chunk("Dirección:   " + f.Mayus(cli.Dir.ToLower()), FontFactory.GetFont(FontFactory.HELVETICA, 12)));
            Paragraph p4 = new Paragraph(new Chunk("Detalle:", FontFactory.GetFont(FontFactory.HELVETICA, 12)));

            //espacios entre parrafos 1 y parrafo4 
            p1.SpacingBefore = 50;
            p4.SpacingBefore = 15;
            
            //incersion parrafos de cabecera al documento
            document.Add(p0);
            document.Add(p01);
            document.Add(p02);
            document.Add(p1);
            document.Add(p2);
            document.Add(p3);
            document.Add(p4);

            //header del detalle
            Cell cell1 = new Cell("Codigo");
            Cell cell2 = new Cell("Producto");
            Cell cell3 = new Cell("Cantidad");
            Cell cell4 = new Cell("P. Unitario");
            Cell cell5 = new Cell("Total");
            //sombras en los headers
            cell1.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
            cell2.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
            cell3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
            cell4.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
            cell5.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
            //add  header a la taabla detalle
            oTblDet.AddCell(cell1);
            oTblDet.AddCell(cell2);
            oTblDet.AddCell(cell3);
            oTblDet.AddCell(cell4);
            oTblDet.AddCell(cell5);

            //instaciamos productoBD para acceder a metodo consultar producto para obtener nombre
            ProductoBD pBD = new ProductoBD();
            //rrecorremos la lista detalle y llenamos tabla del pdf
            for (int i = 0; i <= listcDet.Count - 1; i++)
            {
                Producto p = pBD.Consultar(listcDet[i].Prodid, listcDet[i].Cateid, listcDet[i].Prov);

                oTblDet.AddCell("P" + listcDet[i].Prodid.ToString() + "C" + listcDet[i].Cateid.ToString() + "V" + listcDet[i].Prov.ToString());
                oTblDet.AddCell(p.Nombre);
                oTblDet.AddCell(listcDet[i].Cantidad.ToString());
                oTblDet.AddCell(Math.Round(listcDet[i].Precio,2).ToString());
                oTblDet.AddCell(Math.Round(listcDet[i].Subtotal,2).ToString());
            }

            
            //separador
            Cell cell6 = new Cell("");
            cell6.Leading = 30;
            //cell6.Rowspan = 3;
            cell6.Colspan = 5;
            cell6.BackgroundColor = new Color(0xC0, 0xC0, 0xC0);
            oTblDet.AddCell(cell6);

            //separador colspan 3
            Cell cell60 = new Cell("");
            cell60.HorizontalAlignment = Element.ALIGN_RIGHT;            
            cell60.Rowspan = 3;
            cell60.Colspan = 3;            
            oTblDet.AddCell(cell60);

            //subtotal etiqueta
            Cell cell61 = new Cell("SubTotal:");
            cell61.HorizontalAlignment = Element.ALIGN_RIGHT;
            oTblDet.AddCell(cell61);            
            //subtotal valor            
            decimal st = cCab.Total / decimal.Parse("1,12");
            Cell cell62 = new Cell(Math.Round(st,2).ToString());
            oTblDet.AddCell(cell62);
            
            //iva etiqueta
            Cell cell71 = new Cell("Iva:");
            cell71.HorizontalAlignment = Element.ALIGN_RIGHT;
            oTblDet.AddCell(cell71);
            //iva valor            
            decimal iva = st * decimal.Parse("0,12");
            Cell cell72 = new Cell(Math.Round(iva, 2).ToString());
            oTblDet.AddCell(cell72);

            //total etiqueta
            Cell cell81 = new Cell("Total:");
            cell81.HorizontalAlignment = Element.ALIGN_RIGHT;
            oTblDet.AddCell(cell81);
            //total valor                        
            Cell cell82 = new Cell(Math.Round(cCab.Total, 2).ToString());
            oTblDet.AddCell(cell82);
            //incersion de tabla detalle al documento
            oTblDet.Cellpadding = 1;
            oTblDet.Offset = 15;
            document.Add(oTblDet);

            //parrafo final
            string msgfinal = "ViveroMarket.com                                 Tiempo de Valides 15 días desde su emisión";
            Paragraph pfinal = new Paragraph(new Chunk(msgfinal, FontFactory.GetFont(FontFactory.HELVETICA, 12)));
            pfinal.SpacingBefore = 20;
            //insercion parrafo final
            document.Add(pfinal);

            document.Close();
        }

        #region funciones

        //funciones que entregan  string con espacios para la cabecera
        private string tabulador1(int j)
        {
            string tabulador = string.Empty;
            int k=0;
            if (j < 20) { k = (j * 4) - (j / 2); ; } else { k = (j * 2) - (j / 2)+10; }
            string tab = " ";
            for (int i = 1; i < k; i++)
            {
                tabulador = tabulador + tab;
            }
            return tabulador;
        }

        private string tabulador2(int clinl, int clirl)
        {
            string tabulador2 = string.Empty;
            int j=0;
            if (clinl < 20) { j = (tabulador1(clinl).Length + clinl) - (clinl - clirl); } else { j = (tabulador1(clinl).Length + clinl); }
            string tab2 = " ";
            for (int i = 1; i < j; i++)
            {
                tabulador2 = tabulador2 + tab2;
            }
            return tabulador2;
        }


        #endregion
    }
}