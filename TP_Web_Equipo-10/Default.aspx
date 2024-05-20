<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_Web_Equipo_10.Default" %>

<%@ Import Namespace="ModelDomain" %>
<%@ Import Namespace="DBAccess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater runat="server" ID="rptArticleList" OnItemDataBound="rptArticleList_ItemDataBound">
            <ItemTemplate>
                <div hidden>
                    <%# currID = (int)Eval("id") %>
                </div>
                <div class="card" style="width: 250px; margin-left:12px; margin-top:36px">
                    <asp:Repeater runat="server" ID="rptImgList">
                        <ItemTemplate>
                            <div style="margin: 10px" runat="server" visible='<%# ((int)Eval("articleID")) == currID %>'>
                                <img style="height:210px; width:230px; margin-top:10px" src="<%# Eval("imageUrl")%>" class="card-img-top img-thumbnail" onerror="this.src = 'https://static.thenounproject.com/png/82078-200.png'">
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                    <div class="card-body">  

                        <h5 class="card-title"><%#Eval("name")%></h5>
                        <div class="form-floating mb-3">
                            <input readonly type="text" class="form-control" id="artDetail" value="<%#Eval("desc")%>">
                            <label for="artDetail">Descripción:</label>
                        </div>
                        <div class="form-floating">
                            <input readonly type="text" class="form-control" id="artPrice" value="$<%#Eval("price")%>">
                            <label for="artPrice">Precio:</label>
                        </div>
                    </div>
                        
                    <div class="card" style="margin-bottom: 10px">
                        <asp:LinkButton ID="btnDetails" CommandArgument='<%#Eval("id")%>' runat="server" CssClass="btn btn-info" OnClick="btnDetails_Click" Text="Ver Detalles"  />
                        <asp:LinkButton ID="btnAddToCart" CommandArgument='<%#Eval("id")%>' runat="server" CssClass="btn btn-primary"  OnClick="btnAddToCart_Click" Text="Agregar al Carrito" style="margin-top:8px"/>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
