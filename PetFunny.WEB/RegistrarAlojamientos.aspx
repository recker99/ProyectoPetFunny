<%@ Page Title="Registrar Alojamiento" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RegistrarAlojamientos.aspx.cs" Inherits="PetFunny.WEB.RegistrarAlojamientos" %>  
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">  
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />  
</asp:Content>  

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">  
    <div class="container mt-4"> 
        <div class="row justify-content-center mt-4">
            <div class="col-md-12 text-center">
                <a href="FinalizacionEstancia.aspx" class="btn btn-info">Ver Alojamientos a Punto de Terminar</a>
            </div>
        </div>
        <br />
           <div class="row justify-content-center">
                <div class="col-md-6 col-lg-6 text-center">
                    <asp:TextBox ID="txtRutBuscar" runat="server" placeholder="Ingrese Rut para buscar" CssClass="form-control d-inline-block" />
                    <asp:Button ID="btnBuscarPorRut" runat="server" Text="Buscar" OnClick="btnBuscarPorRut_Click" CssClass="btn btn-primary ms-2 d-inline-block" />
                    <asp:Label ID="Label1" runat="server" ForeColor="Red" CssClass="d-block mt-2"></asp:Label>
                </div>
            </div>
        <br />

        <div class="row justify-content-center">  
            <div class="col-md-6 col-lg-6">  
                <div class="card p-4">  
                    <h2 class="card-title text-center mb-4">Registrar Alojamiento</h2>  
                    <asp:Panel ID="pnlForm" runat="server">  
                        <div class="mb-3">  
                            <label for="txtRut" class="form-label">RUT</label>  
                            <asp:TextBox ID="txtRut" runat="server" CssClass="form-control" />  
                            <asp:RequiredFieldValidator ID="rfvRut" runat="server" ControlToValidate="txtRut" ErrorMessage="El RUT es obligatorio." CssClass="text-danger" Display="Dynamic" />  
                        </div>  
                        <div class="mb-3">  
                            <label for="txtNombreMascota" class="form-label">Nombre de Mascota</label>  
                            <asp:TextBox ID="txtNombreMascota" runat="server" CssClass="form-control" />  
                            <asp:RequiredFieldValidator ID="rfvNombreMascota" runat="server" ControlToValidate="txtNombreMascota" ErrorMessage="El nombre de la mascota es obligatorio." CssClass="text-danger" Display="Dynamic" />  
                        </div>  
                        <div class="mb-3">  
                            <label for="ddlIdTipoMascota" class="form-label">Tipo de Mascota</label>  
                            <asp:DropDownList ID="ddlIdTipoMascota" runat="server" CssClass="form-select" AppendDataBoundItems="true">  
                                <asp:ListItem Text="Seleccione" Value="" />  
                            </asp:DropDownList>  
                            <asp:RequiredFieldValidator ID="rfvTipoMascota" runat="server" ControlToValidate="ddlIdTipoMascota" InitialValue="" ErrorMessage="Debe seleccionar un tipo de mascota." CssClass="text-danger" Display="Dynamic" />  
                        </div>  
                        <div class="mb-3">  
                            <label for="ddlIdTipoAlojamiento" class="form-label">Tipo de Alojamiento</label>  
                            <asp:DropDownList ID="ddlIdTipoAlojamiento" runat="server" CssClass="form-select" AppendDataBoundItems="true">  
                                <asp:ListItem Text="Seleccione" Value="" />  
                            </asp:DropDownList>  
                            <asp:RequiredFieldValidator ID="rfvTipoAlojamiento" runat="server" ControlToValidate="ddlIdTipoAlojamiento" InitialValue="" ErrorMessage="Debe seleccionar un tipo de alojamiento." CssClass="text-danger" Display="Dynamic" />  
                        </div>  
                        <div class="mb-3">  
                            <label for="txtFechaIngreso" class="form-label">Fecha de Ingreso</label>  
                            <asp:TextBox ID="txtFechaIngreso" runat="server" CssClass="form-control" TextMode="Date" />  
                            <asp:RequiredFieldValidator ID="rfvFechaIngreso" runat="server" ControlToValidate="txtFechaIngreso" ErrorMessage="La fecha de ingreso es obligatoria." CssClass="text-danger" Display="Dynamic" />  
                        </div>  
                        <div class="mb-3">  
                            <label for="txtDias" class="form-label">Cantidad de Días</label>  
                            <asp:TextBox ID="txtDias" runat="server" CssClass="form-control" />  
                            <asp:RequiredFieldValidator ID="rfvDias" runat="server" ControlToValidate="txtDias" ErrorMessage="La cantidad de días es obligatoria." CssClass="text-danger" Display="Dynamic" />  
                        </div>  
                        <div class="mb-3 text-center">  
                            <asp:Button ID="btnRegistrarAlojamiento" runat="server" CssClass="btn btn-primary" Text="Registrar" OnClick="btnRegistrarAlojamiento_Click" />  
                        </div>  
                        <div class="mb-3">  
                            <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger" />  
                        </div>  
                    </asp:Panel>  
                      
                </div>  
            </div>  
          </div>      
                        <!-- Listado de Alojamientos con opciones CRUD -->
                <div class="row justify-content-center mt-5">
                    <div class="col-md-10">  
                        <h3 class="text-center mb-4">Listado de Alojamientos</h3>
                      <asp:GridView ID="gvAlojamientos" runat="server" CssClass="table table-striped" AutoGenerateColumns="false" EmptyDataText="No hay alojamientos registrados" OnRowCommand="gvAlojamientos_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="Rut" HeaderText="RUT" />
                                <asp:BoundField DataField="NombreMascota" HeaderText="Nombre de la Mascota" />
                                <asp:BoundField DataField="DescripcionMascota" HeaderText="Descripción de la Mascota" />
                                <asp:BoundField DataField="DescripcionAlojamiento" HeaderText="Descripción del Alojamiento" />
                                <asp:BoundField DataField="FechaIngreso" HeaderText="Fecha de Ingreso" />
                                <asp:BoundField DataField="Dias" HeaderText="Días" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button ID="btnEdit" runat="server" CommandName="Edit" CommandArgument='<%# Container.DataItemIndex %>' Text="Editar" CssClass="btn btn-warning btn-sm" />
                                         <asp:Button ID="btnEliminar" runat="server" CommandName="Delete" CommandArgument='<%# Container.DataItemIndex %>' Text="Eliminar" CssClass="btn btn-warning btn-sm" OnClientClick="return confirm('¿Estás seguro de que deseas eliminar este alojamiento?');" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                 </div>        
            </div>  
    <br />  
</asp:Content>