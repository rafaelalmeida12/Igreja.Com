using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Igreja.Com.Aplicacao.InterfaceApp;
using Igreja.Com.Dominio.Entidades;
using Igreja.Com.Web.ViewsModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PdfSharpCore.Drawing;

namespace Igreja.Com.Web.Controllers
{
    public class DocumentosController : Controller
    {
        #region Construtores

        private readonly InterfaceMembroApp _interfaceMembro;

        public DocumentosController(InterfaceMembroApp interfaceMembro)
        {
            _interfaceMembro = interfaceMembro;
        }
        #endregion
        // GET: Documentos


        public FileResult GerarRelatorio()
        {
            using (var doc = new PdfSharpCore.Pdf.PdfDocument())
            {
                var page = doc.AddPage();
                page.Size = PdfSharpCore.PageSize.A4;
                page.Orientation = PdfSharpCore.PageOrientation.Portrait;
                var graphics = PdfSharpCore.Drawing.XGraphics.FromPdfPage(page);
                var corFonte = PdfSharpCore.Drawing.XBrushes.Black;

                var textFormatter = new PdfSharpCore.Drawing.Layout.XTextFormatter(graphics);
                var fonteOrganzacao = new PdfSharpCore.Drawing.XFont("Arial", 10);
                var fonteDescricao = new PdfSharpCore.Drawing.XFont("Arial", 8, PdfSharpCore.Drawing.XFontStyle.BoldItalic);
                var titulodetalhes = new PdfSharpCore.Drawing.XFont("Arial", 14, PdfSharpCore.Drawing.XFontStyle.Bold);
                var fonteDetalhesDescricao = new PdfSharpCore.Drawing.XFont("Arial", 7);

                var logo = @"C:\Users\Rafael\source\repos\Igreja.Com\Igreja.Com.Web\wwwroot\Imagens\logo.jpg";

                var qtdPaginas = doc.PageCount;
                textFormatter.DrawString(qtdPaginas.ToString(), new PdfSharpCore.Drawing.XFont("Arial", 10), corFonte, new PdfSharpCore.Drawing.XRect(578, 825, page.Width, page.Height));

                // Impressão do LogoTipo
                XImage imagem = XImage.FromFile(logo);
                graphics.DrawImage(imagem, 20, 10, 100, 50);

                textFormatter.DrawString("Igreja Evangelica Assembleia de Deus", fonteDescricao, corFonte, new PdfSharpCore.Drawing.XRect(225, 15, 150, 150));
                textFormatter.DrawString("Avenida Leopoldo de Matos", fonteDescricao, corFonte, new PdfSharpCore.Drawing.XRect(250, 35, 150, 150));
                textFormatter.DrawString("Guajará-Mirim RO", fonteDescricao, corFonte, new PdfSharpCore.Drawing.XRect(265, 55, 150, 150));

                var tituloDetalhes = new PdfSharpCore.Drawing.Layout.XTextFormatter(graphics);
                tituloDetalhes.Alignment = PdfSharpCore.Drawing.Layout.XParagraphAlignment.Center;
                tituloDetalhes.DrawString("Ficha Cadastro de Membro ", titulodetalhes, corFonte, new PdfSharpCore.Drawing.XRect(0, 90, page.Width, page.Height));

                textFormatter.DrawString("O senhor é meu pastor e nada me faltará", new PdfSharpCore.Drawing.XFont("Arial", 10), corFonte, new PdfSharpCore.Drawing.XRect(225, 825, page.Width, page.Height));

                int posicao = 130;
                var membro = new MembroPDF();

                foreach (var propertyInfo in membro.GetType().GetProperties())
                {
                    textFormatter.DrawString(propertyInfo.Name, fonteDescricao, corFonte, new PdfSharpCore.Drawing.XRect(20, posicao, page.Width, page.Height));
                    textFormatter.DrawString("___________________________________", fonteOrganzacao, corFonte, new PdfSharpCore.Drawing.XRect(85, posicao, page.Width, page.Height));

                    posicao = posicao + 25;
                }


                using (MemoryStream stream = new MemoryStream())
                {
                    var contantType = "application/pdf";
                    doc.Save(stream, false);

                    var nomeArquivo = "RelatorioValdir.pdf";

                    return File(stream.ToArray(), contantType, nomeArquivo);
                }

            }
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: Documentos/Details/5
        public ActionResult Carta()
        {
            return View();
        }

        // GET: Documentos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Documentos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Documentos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Documentos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Documentos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Documentos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}