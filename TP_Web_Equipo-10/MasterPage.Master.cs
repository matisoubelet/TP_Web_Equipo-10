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

        string searchFilter = "";
        bool brandFilter = false;
        bool categoryFilter = false;
        int brandIndex = 0;
        int categoryIndex = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            ArticleDBAccess articleDBAccess = new ArticleDBAccess();

            //ddlBrands.SelectedIndex = brandIndex;
            //ddlCategories.SelectedIndex = categoryIndex;
            //searchBar.Text = searchFilter;

            articleList = articleDBAccess.ListArticles();
            brandList = articleDBAccess.ListBrands();
            categoryList = articleDBAccess.ListCategories();

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
            Debug.WriteLine(brandIndex);
            Debug.WriteLine(categoryIndex);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            if (searchBar.Text != "")
            {
                searchFilter = searchBar.Text;

            }
            CallRedirectFilter();
        }

        protected void ddlCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            brandIndex = ddlCategories.SelectedIndex;
            if (brandIndex != 0)
            {
                brandFilter = true;
            }
            else
            {
                brandFilter = false;
            }
            CallRedirectFilter();
        }

        protected void ddlBrands_SelectedIndexChanged(object sender, EventArgs e)
        {
            categoryIndex = ddlBrands.SelectedIndex;
            if (categoryIndex != 0)
            {
                categoryFilter = true;
            }
            else
            {
                categoryFilter = false;
            }
            CallRedirectFilter();
        }

        private void CallRedirectFilter()
        {
            if (searchFilter != null || brandFilter || categoryFilter)
            {
                int marca = -1;
                int categ = -1;
                if (brandFilter)
                {
                    marca = brandIndex;
                }
                if (categoryFilter)
                {
                    categ = categoryIndex;
                }

                Response.Redirect("Default.aspx?busq=" + searchFilter.ToUpperInvariant() + "&marca=" + marca + "&categ=" + categ, false);
            }
        }
    }
}