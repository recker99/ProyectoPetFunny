<%@ Page Title="Registrar Propietario" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RegistrarPropietario.aspx.cs" Inherits="PetFunny.WEB.RegistrarPropietario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="userInfo" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <div class="row justify-content-center">
            <div class="col-md-8">
                <!-- Búsqueda de propietario por RUT -->
                <div class="mb-3">
                    <h3 class="text-center">Buscar Propietario por RUT</h3>
                    <div class="input-group mb-3">
                        <asp:TextBox ID="txtBuscarRut" runat="server" CssClass="form-control" Placeholder="Ingrese RUT para buscar" />
                        <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-primary" Text="Buscar" OnClick="btnBuscar_Click" />
                    </div>
                </div>
            </div>
         </div>       
                <!-- Formulario de registro de propietario -->
          <div class="row justify-content-center">
             <div class="col-md-6 col-lg-6">
                 <div class="card p-4">
                    <h2 class="card-title text-center mb-4">Registrar Propietario</h2>
                        <div class="mb-3">
                            <label for="txtRut" class="form-label">RUT</label>
                            <asp:TextBox ID="txtRut" runat="server" CssClass="form-control" />
                        </div>
                <div class="mb-3">
                    <label for="txtNombres" class="form-label">Nombres</label>
                    <asp:TextBox ID="txtNombres" runat="server" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="txtApellidos" class="form-label">Apellidos</label>
                    <asp:TextBox ID="txtApellidos" runat="server" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="txtTelefono" class="form-label">Teléfono</label>
                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" />
                </div>
                <div class="mb-3 text-center">
                    <asp:Button ID="btnRegistrarPropietario" runat="server" Text="Registrar" OnClick="btnRegistrarPropietario_Click" />  
                    <asp:Button ID="btnActualizarPropietario" runat="server" Text="Actualizar" OnClick="btnActualizarPropietario_Click" Enabled="false" />  
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger" />
                </div>
            </div>
        </div>

        <!-- Listado de propietarios con opciones CRUD -->
        <div class="row justify-content-center mt-5">
            <div class="col-md-10">
                <h3 class="text-center mb-4">Listado de Propietarios</h3>
                <asp:GridView ID="gvPropietarios" runat="server" CssClass="table table-striped" AutoGenerateColumns="False" DataKeyNames="Rut" OnRowEditing="gvPropietarios_RowEditing" OnRowUpdating="gvPropietarios_RowUpdating" OnRowDeleting="gvPropietarios_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="Rut" HeaderText="RUT" ReadOnly="True" />
                        <asp:BoundField DataField="Nombres" HeaderText="Nombres" />
                        <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" />
                        <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" ButtonType="Button" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</div>
</asp:Content>
