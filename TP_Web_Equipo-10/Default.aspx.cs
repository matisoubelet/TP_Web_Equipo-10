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
        public List<Article> articleCartList = new List<Article>();

        public int currID = -1;

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
            articleCartList = new List<Article>();

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
            int articleId = int.Parse(((LinkButton)sender).CommandArgument);
            Article article = articleList.Find(x => x.id == articleId);

            articleCartList = (List<Article>)Session["Cart"];
            articleCartList.Add(article);
            Session["Cart"] = articleCartList;

            MasterPage master = (MasterPage)this.Master;
            master.UpdateCartItems();
          
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