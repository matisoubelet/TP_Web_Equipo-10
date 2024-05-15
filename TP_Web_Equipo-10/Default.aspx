<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_Web_Equipo_10.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row row-cols-1 row-cols-md-3 g-4">

        <%
    foreach (ModelDomain.Article article in articleList)
    {
        foreach (ModelDomain.Img img in imgList)
        {
            if (article.id == img.id)
            {%>
                <div class="col">
                    <div class="card">
                        <img src="<%: img.imageUrl %>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%: article.name %></h5>
                            <p class="card-text"><%: article.desc %></p>
                            <p class="card-text">$<%: article.price %></p>            
                        </div>
                        <asp:Button ID="btnDetail" runat="server" CssClass="btn btn-info" OnClick="btnDetail_Click" Text="Detalle" />
                        <asp:Button ID="btnBuy" runat="server" CssClass="btn btn-primary" OnClick="btnBuy_Click" Text="Comprar" />    
                    </div>
                </div>
         <% } %>
     <% } %>
 <% } %>
    </div>

</asp:Content>
