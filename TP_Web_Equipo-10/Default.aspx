<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_Web_Equipo_10.Default" %>

<%@ Import Namespace="ModelDomain" %>
<%@ Import Namespace="DBAccess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater runat="server" ID="rptArticleList" OnItemDataBound="rptArticleList_ItemDataBound">
            <ItemTemplate>

                <%# currID = int.Parse(Eval("id").ToString()) %>

                <div class="card" style="width: 250px">

                    <asp:Repeater runat="server" ID="rptImgList">
                        <ItemTemplate>
                            <div runat="server" visible='<%# (int.Parse(Eval("articleID").ToString()) == currID)%>'>
                                <img src="<%# Eval("imageUrl")%>" class="card-img-top img-thumbnail" alt="...">
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                    <div class="card-body">
                        <h5 class="card-title"><%#Eval("name")%></h5>
                        <p class="card-text"><%#Eval("desc")%></p>
                        <p class="card-text">$<%#Eval("price")%></p>
                    </div>
                    <asp:LinkButton ID="btnDetails" CommandArgument='<%#Eval("id")%>' runat="server" CssClass="btn btn-info" OnClick="btnDetails_Click" Text="Ver Detalles"/>
                    <asp:LinkButton ID="btnAddToCart" CommandArgument='<%#Eval("id")%>' runat="server" CssClass="btn btn-primary" OnClick="btnAddToCart_Click" Text="Agregar al Carrito" />
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
