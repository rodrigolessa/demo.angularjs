using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using SimpleBrowser;
using demo.apptarefa.domain.Models;

namespace demo.apptarefa.domain.Service
{
    public class PontoService : Robo
    {
        public PontoService()
        {
            RoboWebClient = new RoboWebClient();
        }

        /// <summary>
        /// Método onde é feito o crawler para carregar os posts.
        /// </summary>
        /// <returns>Lista de artigos ordenada por data.</returns>
        public List<Ponto> CarregaPosts()
        {
            NameValueCollection parametros = new NameValueCollection();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            //Carrega a página inicial do Blog.
            //Estou atribuindo o resultado ao HtmlAgilityPack para fazer o parse do HTML.
            this.RoboWebClient._allowAutoRedirect = false;
            var ret = this.HttpGet(@"http://netcoders.com.br/blog/");

            //Capturando apenas as tags que estão definidas como article e ordenando pelo ID de cada Tag.
            var artigosOrdenados = ret.DocumentNode.Descendants().Where(n => n.Name == "article").OrderBy(d => d.Id).ToList();
            var artigos = new List<Ponto>();

            //Percorrendo os artigos que ja foram selecionados.
            foreach (var item in artigosOrdenados)
            {
                var art = new Ponto();

                //Carregando o Html de cada artigo.
                doc.LoadHtml(item.InnerHtml);

                //Estou utilizando o HtmlAgilityPack.HtmlEntity.DeEntitize para fazer o HtmlDecode dos textos capturados de cada artigo.
                // Utilizo também o UTF8 para limpar o restante dos Encodes que estiverem na página.
                art.Titulo = HtmlAgilityPack.HtmlEntity.DeEntitize(ConvertUTF(doc.DocumentNode.DescendantsAndSelf().FirstOrDefault(d => d.Attributes["class"] != null && d.Attributes["class"].Value == "post-title entry-title").InnerText));
                art.Data = Convert.ToDateTime(HtmlAgilityPack.HtmlEntity.DeEntitize(doc.DocumentNode.DescendantsAndSelf().FirstOrDefault(d => d.Name == "span" && d.Attributes["class"].Value == "post-time").InnerText));
                art.Descricao = HtmlAgilityPack.HtmlEntity.DeEntitize(ConvertUTF(doc.DocumentNode.DescendantsAndSelf().FirstOrDefault(d => d.Attributes["class"] != null && d.Attributes["class"].Value == "entry-content").InnerText));
                art.Autor = HtmlAgilityPack.HtmlEntity.DeEntitize(ConvertUTF(doc.DocumentNode.DescendantsAndSelf().FirstOrDefault(d => d.Attributes["class"] != null && d.Attributes["class"].Value == "post-author").InnerText));
                artigos.Add(art);
            }

            return artigos.OrderBy(d => d.Data).ToList();
        }

        private string ConvertUTF(string texto)
        {
            // Convertendo o texto para o Enconding default e Array de bytes.
            byte[] data = Encoding.Default.GetBytes(texto);

            //Convertendo o texto limpo para UTF8.
            string ret = Encoding.UTF8.GetString(data);

            return ret;
        }
    }
}