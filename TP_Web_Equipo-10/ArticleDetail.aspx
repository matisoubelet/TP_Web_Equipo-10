<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ArticleDetail.aspx.cs" Inherits="TP_Web_Equipo_10.ArticleDetail" %>

<%@ Import Namespace="ModelDomain" %>
<%@ Import Namespace="DBAccess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row row-cols-1 row-cols-md-3 g-4">

           
                    <div class="card" style="width: 250px">
                        <img src="<%: imgDetail.imageUrl%>" class="card-img-top img-thumbnail" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%:articleDetail.name %></h5>
                            <p class="card-text"><%: articleDetail.desc %></p>
                            <p class="card-text">$<%: articleDetail.price %></p>
                        </div>
                        
                        
                    </div>
    </div>


</asp:Content>
