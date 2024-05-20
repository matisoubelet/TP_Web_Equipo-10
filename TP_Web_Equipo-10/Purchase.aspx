<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Purchase.aspx.cs" Inherits="TP_Web_Equipo_10.Formulario_web1" %>

<%@ Import Namespace="ModelDomain" %>
<%@ Import Namespace="DBAccess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .table-custom {
            width: 50%;
            border-collapse: collapse;
            float: left;
        }

            .table-custom th, .table-custom td {
                border: 1px solid #ccc;
                padding: 8px;
                text-align: left;
            }

            .table-custom tfoot td {
                font-weight: bold;
            }

        .form-container {
            float: right;
            width: 40%;
            padding: 5px;
        }


            .form-container .form-control {
                margin-bottom: 10px;
            }

            .form-container .btn-primary {
                width: 100%;
            }

        input[type=number]::-webkit-inner-spin-button,
        input[type=number]::-webkit-outer-spin-button {
            -webkit-appearance: none;
            margin: 0;
        }

        input[type=number] {
            -moz-appearance: textfield;
        }

        .custom-number-input {
            display: flex;
            align-items: center;
        }

            .custom-number-input button {
                padding: 0 10px;
                background: #f8f9fa;
                border: 1px solid #ced4da;
                cursor: pointer;
            }

                .custom-number-input button:hover {
                    background: #e9ecef;
                }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid" style="margin-top: 25px">
        <div class="col">
            <table class="table-custom">
                <thead>
                    <tr>
                        <th>#</th>
                        <th>Nombre</th>
                        <th>Descripción</th>
                        <th>Cantidad</th>
                        <th>Precio unitario</th>
                        <th>Importe</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptCartItems" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Container.ItemIndex + 1 %></td>
                                <td><%# Eval("article.name") %></td>
                                <td><%# Eval("article.desc") %></td>
                                <td>
                                    <div class="custom-number-input">
                                        <asp:LinkButton ID="btnMinusQ" Text="-" TextMode="Number" CssClass="btn btn-outline-secondary" runat="server" CommandArgument='<%# Eval("article.id") %>' OnClick="btnMinusQ_Click"/>
                                        <asp:TextBox id="tbxQuantity" type="number" CssClass="form-control" runat="server" Text='<%# Eval("quantity") %>' ReadOnly="true"/>
                                        <asp:LinkButton ID="btnPlusQ" Text="+" TextMode="Number" CssClass="btn btn-outline-secondary" runat="server" CommandArgument='<%# Eval("article.id") %>' OnClick="btnPlusQ_Click"/>
                                    </div>
                                </td>
                                <td>$<%# Eval("article.price") %></td>
                                <td>$<%# (float)Eval("article.price") * (int)Eval("quantity") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
                <tfoot>
                    <tr>
                        <td colspan="5">Total</td>
                        <td>$<%= GetTotalPrice() %></td>
                    </tr>
                </tfoot>
            </table>
        </div>
        <div class="col">
            <div class="form-container">
                <div class="col-md">
                    <label for="inputFirstName" class="form-label">Nombre</label>
                    <input type="text" class="form-control" id="inputFirstName" />
                </div>
                <div class="col-md">
                    <label for="inputLastName" class="form-label">Apellido</label>
                    <input type="text" class="form-control" id="inputLastName" />
                </div>
                <div class="col-md">
                    <label for="inputNationality" class="form-label">Nacionalidad</label>
                    <input type="text" class="form-control" id="inputNationality" />
                </div>
                <div class="col-md">
                    <label for="inputEmail" class="form-label">Email</label>
                    <input type="email" class="form-control" id="inputEmail" />
                </div>
                <div class="col-md">
                    <label for="inputCardNumber" class="form-label">Número de Tarjeta</label>
                    <input type="text" class="form-control" id="inputCardNumber" />
                </div>
                <div class="col-md">
                    <label for="inputSecurityNumber" class="form-label">Código de Seguridad</label>
                    <input type="text" class="form-control" id="inputSecurityNumber" />
                </div>
                <div class="col-md">
                    <asp:Button UseSubmitBehavior="false" ID="btnConfirm" CssClass="btn btn-primary" Text="Finalizar Compra" runat="server" OnClick="btnConfirm_Click"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
