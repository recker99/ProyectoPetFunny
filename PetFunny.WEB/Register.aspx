<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="PetFunny.WEB.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="d-flex justify-content-center align-items-center" style="min-height: 80vh;">  
    <div class="col-md-4">  
        <div class="card p-4">  
            <h2 class="text-center mb-4">Registro de Usuario</h2>  
            <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="Red" CssClass="d-block text-center mb-3"></asp:Label>  
            <div class="d-flex flex-column">  
                <div class="form-group">  
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control mb-3" placeholder="Nombre de Usuario" required="true"></asp:TextBox>  
                </div>  
                <div class="form-group">  
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control mb-3" TextMode="Password" placeholder="Contraseña" required="true"></asp:TextBox>  
                </div>  
                <div class="form-group">  
                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control mb-4" placeholder="Nombres" required="true"></asp:TextBox>  
                </div>
                <div class="form-group">  
                    <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control mb-4" placeholder="Apellidos" required="true"></asp:TextBox>  
                </div>
                    <asp:Button ID="btnRegister" runat="server" Text="Registrar" CssClass="btn btn-primary btn-block" OnClick="btnRegister_Click" />  
                </div>  
            </div>  
        </div>  
    </div>  
</asp:Content>
