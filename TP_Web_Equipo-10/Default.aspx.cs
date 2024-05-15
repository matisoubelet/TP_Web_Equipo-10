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

        public List<Article> articleList { get; set; }
        public List<Img> imgList { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            //Trae desde la base de datos el litado de articulos y la mete en las cards
            // Trae desde la base de datos el litado de articulos con sus imagenes y la mete en las cards
            if (!IsPostBack)
            {
                ArticleDBAccess DBAcceslist = new ArticleDBAccess();
                articleList = DBAcceslist.ListArticles();
                imgList = DBAcceslist.ListImages();
            }
            else
            {
                string searchText = Request.QueryString["filtro"];
                articleList = new List<Article>();

                ArticleDBAccess DBAcceslist = new ArticleDBAccess();
                List<Article> fullList = DBAcceslist.ListArticles();

                if (!string.IsNullOrEmpty(searchText))
                {
                    foreach (Article art in fullList)
                    {
                        if (art.name.Contains(searchText))
                        {
                            articleList.Add(art);
                        }
                    }
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