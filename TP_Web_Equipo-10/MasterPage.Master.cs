using DBAccess;
using ModelDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Web_Equipo_10
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        public string hola = "hola";
        public List<Article> articleList { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticleDBAccess DBAcceslist = new ArticleDBAccess();
            articleList = DBAcceslist.ListArticles();
        }
    }
}