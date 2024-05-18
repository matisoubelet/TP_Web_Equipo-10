<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ArtDetails.aspx.cs" Inherits="TP_Web_Equipo_10.ArtDetails" %>

<%@ Import Namespace="ModelDomain" %>
<%@ Import Namespace="DBAccess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="container">


        <div id="carArticle" class="carousel slide" style="width: 50%;  display: inline-block">
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <img src="<%:img.imageUrl %>" class="d-block w-100" alt="...">
                </div>
                <div class="carousel-item">
                    <img src="..." class="d-block w-100" alt="...">
                </div>
                <div class="carousel-item">
                    <img src="..." class="d-block w-100" alt="...">
                </div>
            </div>
            <button class="carousel-control-prev" type="button" data-bs-target="#carouselExample" data-bs-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Previous</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#carouselExample" data-bs-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Next</span>
            </button>
        </div><div id="labelContainer" style="width: 50%; display: inline-block">
            <div class="form-floating mb-3">
                <input type="text" readonly class="form-control-plaintext" id="artCode"  value="<%:article.code %>">
                <label for="artCode">Código:</label>
            </div>
            <div class="form-floating mb-3">
                <input type="text" readonly class="form-control-plaintext" id="artName" value="<%:article.name %>">
                <label for="artName">Nombre:</label>
            </div>
            <div class="form-floating mb-3">
                <input type="text" readonly class="form-control-plaintext" id="artDesc"  value="<%:article.desc %>">
                <label for="artDesc">Descripción:</label>
            </div>
            <div class="form-floating mb-3">
                <input type="text" readonly class="form-control-plaintext" id="artBrand"  value="<%:article.idBrand %>">
                <label for="artBrand">Marca:</label>
            </div>
            <div class="form-floating mb-3">
                <input type="text" readonly class="form-control-plaintext" id="artCat"  value="<%:article.idCategory %>">
                <label for="artCat">Categoría:</label>
            </div>
            <div class="form-floating mb-3">
                <input type="text" readonly class="form-control-plaintext" id="artPrice"  value="$<%:article.price %>">
                <label for="artPrice">Precio:</label>
            </div>
        </div>

    </div>

</asp:Content>
