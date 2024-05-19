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
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        public List<Article> articleList { get; set; }
        public List<Brand> brandList { get; set; }
        public List<Category> categoryList { get; set; }
        public List<Img> imgList {  get; set; } 
        public List<Article> articleCartList { get; set; } = new List<Article>();


        string searchFilter = "";
        int brandIndex = -1;
        int categoryIndex = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            ArticleDBAccess articleDBAccess = new ArticleDBAccess();

            articleList = articleDBAccess.ListArticles();
            brandList = articleDBAccess.ListBrands();
            categoryList = articleDBAccess.ListCategories();
            imgList = articleDBAccess.ListImages();

            if (!IsPostBack)
            {
                ddlBrands.Items.Clear();
                ddlCategories.Items.Clear();

                ddlBrands.Items.Add("Todas");
                ddlCategories.Items.Add("Todas");

                foreach (Brand brand in brandList)
                {
                    ddlBrands.Items.Add(brand.name);
                }
                foreach (Category category in categoryList)
                {
                    ddlCategories.Items.Add(category.name);
                }
                SetFiltersFromSession();

                if (Session["Cart"] == null)
                {
                    Session["Cart"] = new List<Article>();
                }
                UpdateCartItems();
            }
        }

        private void SetFiltersFromSession ()
        {
            lblTemp.Text = "";
            if (Session["busq"] != null)
            {
                searchBar.Text = Session["busq"].ToString();
                lblTemp.Text += Session["busq"].ToString() + ", ";
            }
            if (Session["marca"] != null)
            {
                ddlBrands.SelectedIndex = (int)Session["marca"];
                lblTemp.Text += Session["marca"].ToString() + ", ";
            }
            if (Session["categ"] != null)
            {
                ddlCategories.SelectedIndex = (int)Session["categ"];
                lblTemp.Text += Session["categ"].ToString();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            searchFilter = searchBar.Text;

            if (Session["busq"] != null)
            {
                Session["busq"] = searchFilter;
            }
            else
            {
                Session.Add("busq", searchFilter);
            }
            SetFiltersFromSession();
            Response.Redirect("Default.aspx", false);
        }
        protected void ddlBrands_SelectedIndexChanged(object sender, EventArgs e)
        {
            brandIndex = ddlBrands.SelectedIndex;
            Debug.WriteLine(brandIndex);

            if (Session["marca"] != null)
            {
                if (brandIndex > 0)
                {
                    Session["marca"] = brandIndex;
                }
                else
                {
                    Session["marca"] = -1;
                }
            }
            else
            {
                if (brandIndex > 0)
                {
                    Session.Add("marca", brandIndex);
                }
                else
                {
                    Session.Add("marca", -1);
                }
            }
            SetFiltersFromSession();
            //Response.Redirect("Default.aspx", false);
        }

        protected void ddlCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            categoryIndex = ddlCategories.SelectedIndex;
            Debug.WriteLine(categoryIndex);

            if (Session["categ"] != null)
            {
                if (categoryIndex > 0)
                {
                    Session["categ"] = categoryIndex;
                }
                else
                {
                    Session["categ"] = -1;
                }
            }
            else
            {
                if (categoryIndex > 0)
                {
                    Session.Add("categ", categoryIndex);
                }
                else
                {
                    Session.Add("categ", -1);
                }
            }
            SetFiltersFromSession();
            //Response.Redirect("Default.aspx", false);
        }

        protected void BtnPurchase_Click(object sender, EventArgs e)
        {
            Response.Redirect("Purchase.aspx");
        }

        public void AddToCart(Article article)
        {
            List<Article> cart = (List<Article>)Session["Cart"];
            cart.Add(article);
            Session["Cart"] = cart;
            UpdateCartItems();
        }

        public void UpdateCartItems() 
        {
            List<Article> cart = (List<Article>)Session["Cart"];
            articleCartList = cart;
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            //resets the filters and loads the page
            searchFilter = searchBar.Text;
            brandIndex = ddlBrands.SelectedIndex;
            categoryIndex = ddlCategories.SelectedIndex;

            if (Session["busq"] != null)
            {
                Session["busq"] = "";
            }
            else
            {
                Session.Add("busq", "");
            }

            if (Session["marca"] != null)
            {
                Session["marca"] = -1;
            }
            else
            {
                Session.Add("marca", -1);
            }

            if (Session["categ"] != null)
            {
                Session["categ"] = -1;
            }
            else
            {
                Session.Add("categ", -1);
            }
            SetFiltersFromSession();
            Response.Redirect("Default.aspx", false);
        }

        protected void BtnEmptyCart_Click(object sender, EventArgs e)
        {
            articleCartList.Clear();
            Session["Cart"] = articleCartList;

            //Response.Redirect("Default.aspx", false);
        }
    }
}