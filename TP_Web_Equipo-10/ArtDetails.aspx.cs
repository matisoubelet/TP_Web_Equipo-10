using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBAccess;
using ModelDomain;

namespace TP_Web_Equipo_10
{
    public partial class ArtDetails : System.Web.UI.Page
    {
        ArticleDBAccess articleDBAccess = new ArticleDBAccess();
        public Article article = new Article();
        public Img img = new Img();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["details"] !=null)
            {
                foreach (Article article in articleDBAccess.ListArticles())
                {
                    if (article.id == int.Parse(Session["details"].ToString()))
                    {
                        this.article = article;
                        foreach (Img img in articleDBAccess.ListImages())
                        {
                            if (img.articleID == article.id)
                            {
                                this.img = img;
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            lbl.Text = article.name;
        }
    }
}