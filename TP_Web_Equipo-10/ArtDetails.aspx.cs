using System;
using System.Collections;
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
        public ArticleDBAccess articleDBAccess = new ArticleDBAccess();
        public Article article = new Article();
        public List<Img> imgList = new List<Img>();
        public List<Brand> brandList = new List<Brand>();
        public List<Category> categoryList = new List<Category>();
        public Img url = new Img();
        public bool firstItem;
        public string brandName;
        public string catName;



        protected void Page_Load(object sender, EventArgs e)
        {
            firstItem = true;
            brandList = articleDBAccess.ListBrands();
            categoryList = articleDBAccess.ListCategories();

            if (Session["details"] != null)
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
                                imgList.Add(img);

                            }
                        }
                        break;

                    }
                }
            }

            //rptImages.DataSource = imgList;
            //rptImages.DataBind();
        }
    }
}