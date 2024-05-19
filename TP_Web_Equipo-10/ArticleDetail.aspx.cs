using DBAccess;
using ModelDomain;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Web_Equipo_10
{
    public partial class ArticleDetail : System.Web.UI.Page
    {
        ArticleDBAccess DBAcceslist = new ArticleDBAccess();
        
        public Article articleDetail = new Article();
        public Img imgDetail = new Img();

        protected void Page_Load(object sender, EventArgs e)
        {

            List<Article> fullArticleList = DBAcceslist.ListArticles();
            List<Img> fullImgList = DBAcceslist.ListImages();

            if (Request.QueryString["artID"] != null)
            {
                int artID = int.Parse(Request.QueryString["artID"]);

                foreach (Article art in fullArticleList) 
                {
                    if(art.id == artID) 
                    {
                        articleDetail = art;
                        foreach(Img img in fullImgList)
                        { 
                            if(img.id == art.id)
                            {
                                imgDetail = img;
                            }
                        }
                    }
                }
            }
        }



    }
}