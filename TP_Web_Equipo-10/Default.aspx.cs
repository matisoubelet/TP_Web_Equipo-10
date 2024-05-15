using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBAccess;
using ModelDomain;


namespace TP_Web_Equipo_10
{
    public partial class Default : System.Web.UI.Page
    {
        ArticleDBAccess DBAcceslist = new ArticleDBAccess();
        public List<Article> articleList = new List<Article>();
        public List<Img> imgList = new List<Img>();

        string searchFilter = "";
        int brandIndex = -1;
        int categoryIndex = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Trae desde la base de datos el litado de articulos y la mete en las cards
            // Trae desde la base de datos el litado de articulos con sus imagenes y la mete en las cards

            List<Article> fullArticleList = DBAcceslist.ListArticles();
            List<Img> fullImgList = DBAcceslist.ListImages();

            articleList = new List<Article>();
            imgList = new List<Img>();

            bool filtered = true;
            Img previewPic = new Img();

            if (Request.QueryString["busq"] != null)
            {
                searchFilter = Request.QueryString["busq"];
            }

            if (Request.QueryString["marca"] != null)
            {
                 brandIndex = int.Parse(Request.QueryString["marca"]);
            }

            if (Request.QueryString["categ"] != null)
            {
                categoryIndex = int.Parse(Request.QueryString["categ"]);
            }

            foreach (Article article in fullArticleList)
            {
                filtered = true;
                if (brandIndex != -1 && brandIndex != article.idBrand)
                {
                    filtered = false;
                }
                if (categoryIndex != -1 && categoryIndex != article.idCategory)
                {
                    filtered = false;
                }
                if (searchFilter != "" && !article.name.ToUpperInvariant().Contains(searchFilter.ToUpperInvariant()))
                {
                    filtered = false;
                }

                if (filtered)
                {
                    foreach (Img img in fullImgList)
                    {
                        if (article.id == img.articleID)
                        {
                            previewPic = img;
                            break;
                        }
                    }
                    articleList.Add(article);
                    imgList.Add(previewPic);
                }
            }
        }
        protected void btnDetail_Click(object sender, EventArgs e)
        {
            // Atrapa el ID del articulo donde se haya dado click al boton, y lo redirige a "ArticDetail.aspx"
            // Con el detalle del producto

            //Response.Redirect("ArticDetail.aspx", false);
        }

        protected void btnBuy_Click(object sender, EventArgs e)
        {
            // Añade al carro de compras el articulo, deberia enseñarlo al darle click al icono del carrito
            // Una vez abierto, debajo de todo el listado de productos seleccionados, deberia indicar el costo total
            // Asi como un boton que diga algo como "Realizar Pago" donde redirija el al usuario y el list de articulos
            // a "Purchases.aspx"
        }
    }
}