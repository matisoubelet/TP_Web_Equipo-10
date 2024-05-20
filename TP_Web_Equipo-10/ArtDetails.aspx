<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ArtDetails.aspx.cs" Inherits="TP_Web_Equipo_10.ArtDetails" %>

<%@ Import Namespace="ModelDomain" %>
<%@ Import Namespace="DBAccess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="container" style="background-color: azure; display: flex; justify-content: center">

        <div id="carouselExample" class="carousel slide" style="max-width: 450px; display: inline-block">
            <div class="carousel-inner">

                <%foreach (Img url in imgList)
                    {
                        if (firstItem == true)
                        {%>
                <div class="carousel-item active">
                    <img src="<%: url.imageUrl %>" style="height: 400px; width: 230px" class="d-block w-100" onerror="this.src = 'https://static.thenounproject.com/png/82078-200.png'">
                </div>
                <% firstItem = false;
                }
                else
                { %>
                <div class="carousel-item">
                    <img src="<%: url.imageUrl %>" style="height: 400px; width: 230px" class="d-block w-100" onerror="this.src = 'https://static.thenounproject.com/png/82078-200.png'">
                </div>
                <% }

                    } %>
            </div>
            <% if (imgList.Count > 1)
                { %>
            <button class="carousel-control-prev" type="button" data-bs-target="#carouselExample" data-bs-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Previous</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#carouselExample" data-bs-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Next</span>
            </button>
            <% } %>
        </div>
        <%


            foreach (Brand brand in brandList)
            {
                if (brand.id == article.idBrand)
                {
                    brandName = brand.name;
                    break;
                }
            }
            foreach (Category category in categoryList)
            {
                if (category.id == article.idCategory)
                {
                    catName = category.name;
                    break;
                }
            }

        %>
        <div id="lblContainer" class="form-control" style="width: 50%; display: inline-block">
            <h5 class="card-title">Nombre: </h5>
            <input class="form-control" readonly type="text" placeholder="<%: article.name %>" aria-label=".form-control-lg example">
            <h5 class="card-title">Código: </h5>
            <input class="form-control" readonly type="text" placeholder="<%: article.code %>" aria-label="default input example">
            <h5 class="card-title">Descripción: </h5>
            <input class="form-control" readonly type="text" placeholder="<%: article.desc %>" aria-label=".form-control-sm example">
            <h5 class="card-title">Precio: </h5>
            <input class="form-control" readonly type="text" placeholder="$<%: article.price %>" aria-label="default input example">
            <h5 class="card-title">Marca: </h5>
            <input class="form-control" readonly type="text" placeholder="<%: brandName %>" aria-label=".form-control-sm example">
            <h5 class="card-title">Categoría: </h5>
            <input class="form-control" readonly type="text" placeholder="<%: catName %>" aria-label=".form-control-sm example">
        </div>

    </div>

</asp:Content>
