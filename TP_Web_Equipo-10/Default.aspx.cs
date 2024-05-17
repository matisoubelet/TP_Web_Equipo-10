using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
        public int currID;

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

            bool filtered;
            Img previewPic = new Img();

            if (Session["busq"] != null && (string)Session["busq"] != "")
            {
                searchFilter = (string)Session["busq"];
            }
            if (Session["marca"] != null && (int)Session["marca"] != -1)
            {
                brandIndex = (int)Session["marca"];
            }

            if (Session["categ"] != null && (int)Session["categ"] != -1)
            {
                categoryIndex = (int)Session["categ"];
            }

            foreach (Article article in fullArticleList)
            {
                filtered = true;
                if (searchFilter != "" && !article.name.ToUpperInvariant().Contains(searchFilter.ToUpperInvariant()))
                {
                    filtered = false;
                }
                if (brandIndex != -1 && brandIndex != article.idBrand)
                {
                    filtered = false;
                }
                if (categoryIndex != -1 && categoryIndex != article.idCategory)
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
            if (!IsPostBack)
            {
                rptArticleList.DataSource = articleList;
                rptArticleList.DataBind();
            }
        }
        protected void btnDetails_Click(object sender, EventArgs e)
        {
            if (Session["details"] != null)
            {
                Session["details"] = ((LinkButton)sender).CommandArgument;
            }
            else
            {
                Session.Add("details", ((LinkButton)sender).CommandArgument);
            }
            Response.Redirect("ArtDetails.aspx", false);
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            Debug.WriteLine(((LinkButton)sender).CommandArgument);
            // este evento tiene que agregar el articulo con el id correspondiente al command arg
            // y avisarle a masterpage que lo tome, porque la lista tiene que estar en master page
            // para que el carrito actualice (default -> masterpage -> carrito) (no se como todavia)

            // Añade al carro de compras el articulo, deberia enseñarlo al darle click al icono del carrito
            // Una vez abierto, debajo de todo el listado de productos seleccionados, deberia indicar el costo total
            // Asi como un boton que diga algo como "Realizar Pago" donde redirija el al usuario y el list de articulos
            // a "Purchases.aspx"
        }

        protected void rptArticleList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // va y busca el repeater anidado
                Repeater rptImgList = e.Item.FindControl("rptImgList") as Repeater;

                // filtra la lista de imgs basado en el art id
                var currentArticle = (Article)e.Item.DataItem;
                var filteredImgList = imgList.Where(img => img.articleID == currentArticle.id).ToList();

                // bindea el repeater de imgs al de afuera
                rptImgList.DataSource = filteredImgList;
                rptImgList.DataBind();
                // si, nos ayudo chatgpt, pero solo un poco, los eventos asp son complicados :c (3 hr de mirar stackoverflow)
                // aparte le pedimos que nos explicara que hacia cada cosa, no copypasteamos jeje
            }
        }

    }
}