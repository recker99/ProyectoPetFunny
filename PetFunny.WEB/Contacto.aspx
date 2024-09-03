<%@ Page Title="Contacto" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="PetFunny.WEB.Contacto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h2>Contacto</h2>
        <p>Si tienes alguna pregunta o necesitas más información, por favor completa el siguiente formulario y nos pondremos en contacto contigo lo antes posible.</p>
        <br />
        
        <div class="row justify-content-center">
            <div class="col-md-8">
                <div class="card">
                    <div class="card-body">
                        <form>
                            <div class="mb-3">
                                <label for="txtNombre" class="form-label">Nombre</label>
                                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Required="true" />
                            </div>
                            <div class="mb-3">
                                <label for="txtEmail" class="form-label">Correo Electrónico</label>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" Required="true" />
                            </div>
                            <div class="mb-3">
                                <label for="txtTelefono" class="form-label">Teléfono</label>
                                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" />
                            </div>
                            <div class="mb-3">
                                <label for="txtMensaje" class="form-label">Mensaje</label>
                                <asp:TextBox ID="txtMensaje" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5" Required="true" />
                            </div>
                            <div class="d-grid">
                                <asp:Button ID="btnEnviar" runat="server" CssClass="btn btn-primary btn-block" Text="Enviar" OnClick="btnEnviar_Click" />
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
</asp:Content>
