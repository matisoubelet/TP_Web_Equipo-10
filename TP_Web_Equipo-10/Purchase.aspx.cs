using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using ModelDomain;
using DBAccess;

namespace TP_Web_Equipo_10
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Cart"] != null)
                {
                    List<Article> articleCartList = (List<Article>)Session["Cart"];
                    rptCartItems.DataSource = articleCartList;
                    rptCartItems.DataBind();

                    float total = 0;
                    foreach (var article in articleCartList)
                    {
                        total += article.price;
                    }
                    ViewState["TotalPrice"] = total.ToString();
                }
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
    }
}