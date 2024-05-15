<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_Web_Equipo_10.Default" %>

<%@ Import Namespace="ModelDomain" %>
<%@ Import Namespace="DBAccess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row row-cols-1 row-cols-md-3 g-4">

            <%
            foreach (Article article in articleList)
            {
                string newImgUrl = "";
                foreach (Img img in imgList)
                {
                    if (article.id == img.id)
                    {
                        newImgUrl = img.imageUrl;
                    } 
                } %>
                    <div class="card" style="width: 250px">
                        <img src="<%: newImgUrl %>" class="card-img-top img-thumbnail" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%: article.name %></h5>
                            <p class="card-text"><%: article.desc %></p>
                            <p class="card-text">$<%: article.price %></p>
                        </div>
                        <asp:Button ID="btnDetail" runat="server" CssClass="btn btn-info" OnClick="btnDetail_Click" Text="Detalles" />
                        <asp:Button ID="btnBuy" runat="server" CssClass="btn btn-primary" OnClick="btnBuy_Click" Text="Agregar al Carrito" />
                    </div>
            <% } %>
    </div>

</asp:Content>
