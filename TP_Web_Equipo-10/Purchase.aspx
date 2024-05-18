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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table-custom">
        <thead>
            <tr>
                <th>#</th>
                <th>Nombre</th>
                <th>Descripción</th>
                <th>Precio</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptCartItems" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Container.ItemIndex + 1 %></td>
                        <td><%# Eval("name") %></td>
                        <td><%# Eval("desc") %></td>
                        <td>$<%# Eval("price") %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="3">Total</td>
                <td>$<%= GetTotalPrice() %></td>
            </tr>
        </tfoot>
    </table>




    <div class="form-container">

        <div class="col-md-8">
            <label for="inputFirstName" class="form-label">Nombre</label>
            <input type="text" class="form-control" id="inputFirstName" />
        </div>
        <div class="col-md-8">
            <label for="inputLastName" class="form-label">Apellido</label>
            <input type="text" class="form-control" id="inputLastName" />
        </div>
        <div class="col-md-8">
            <label for="inputNationality" class="form-label">Nacionalidad</label>
            <input type="text" class="form-control" id="inputNationality" />
        </div>
        <div class="col-md-8">
            <label for="inputEmail" class="form-label">Email</label>
            <input type="email" class="form-control" id="inputEmail" />
        </div>
        <div class="col-md-8">
            <label for="inputCardNumber" class="form-label">Número de Tarjeta</label>
            <input type="text" class="form-control" id="inputCardNumber" />
        </div>
        <div class="col-md-8">
            <label for="inputSecurityNumber" class="form-label">Código de Seguridad</label>
            <input type="text" class="form-control" id="inputSecurityNumber" />
        </div>
        <div class="col-12">
            <button type="submit" class="btn btn-primary">Finalizar Comprar</button>
        </div>

    </div>

</asp:Content>
