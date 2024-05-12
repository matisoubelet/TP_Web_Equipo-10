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
        public List<Image> imgList { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            //Trae desde la base de datos el litado de articulos y la mete en las cards

            ArticleDBAccess DBAcceslist = new ArticleDBAccess();
            articleList = DBAcceslist.ListArticles();
            //imgList = DBAcceslist.ListImages(); No logro que funcione
            
        }
    }
}