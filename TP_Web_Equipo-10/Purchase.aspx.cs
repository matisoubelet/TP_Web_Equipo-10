using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using ModelDomain;
using DBAccess;
using System.Web.Services;
using System.Diagnostics;

namespace TP_Web_Equipo_10
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        public List<CartItem> articleCartList = new List<CartItem>();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                articleCartList = (List<CartItem>)Session["Cart"];
                UpdateCartList();
            }
            
        }

        private void UpdateCartList()
        {
            if (Session["Cart"] != null)
            {
                if (IsPostBack)
                {
                    Session["Cart"] = articleCartList;
                }
                rptCartItems.DataSource = articleCartList;
                rptCartItems.DataBind();

                float total = 0;
                foreach (CartItem item in articleCartList)
                {
                    total += item.article.price * item.quantity;
                }
                ViewState["TotalPrice"] = total.ToString();
            }
        }

        protected decimal GetTotalPrice()
        {
            if (ViewState["TotalPrice"] != null)
            {
                decimal total;
                if (decimal.TryParse(ViewState["TotalPrice"].ToString(), out total))
                {
                    return total;
                }
            }
            return 0;
        }

        protected void btnMinusQ_Click(object sender, EventArgs e)
        {
            articleCartList = (List<CartItem>)Session["Cart"];
            int articleID = int.Parse(((LinkButton)sender).CommandArgument);

            foreach (CartItem item in articleCartList)
            {
                if (articleID == item.article.id)
                {
                    if (item.quantity == 1)
                    {
                        articleCartList.Remove(item);
                        break;
                    }
                    else
                    {
                        item.quantity--;
                    }
                }
            }
            UpdateCartList();
        }

        protected void btnPlusQ_Click(object sender, EventArgs e)
        {
            articleCartList = (List<CartItem>)Session["Cart"];
            int articleID = int.Parse(((LinkButton)sender).CommandArgument);

            foreach (CartItem item in articleCartList)
            {
                if (articleID == item.article.id)
                {
                    item.quantity++;
                }
            }
            UpdateCartList();
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("asdasd");
            MasterPage master = (MasterPage)this.Master;
            master.ResetFilters();
            master.EmptyCart();
            Response.Redirect("Default.aspx", false);
        }
    }
}