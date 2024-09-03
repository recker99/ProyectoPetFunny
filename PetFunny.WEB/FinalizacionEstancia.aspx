<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FinalizacionEstancia.aspx.cs" Inherits="PetFunny.WEB.FinalizacionEstancia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="Content/Site.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container mx-auto p-4">  
        <h1 class="text-2xl font-bold mb-4 text-center" >Alojamientos por Finalizar</h1>  
       <asp:GridView ID="gvAlojamientos" runat="server" CssClass="table table-striped" AutoGenerateColumns="False">  
            <Columns>  
                <asp:BoundField DataField="NombrePropietario" HeaderText="Nombre del Propietario" />
                <asp:BoundField DataField="NombreMascota" HeaderText="Nombre de la Mascota" />  
                <asp:BoundField DataField="TipoMascota" HeaderText="Tipo de Mascota" />  
                <asp:BoundField DataField="TipoAlojamiento" HeaderText="Tipo de Alojamiento" />  
                <asp:BoundField DataField="FechaIngreso" HeaderText="Fecha de Ingreso" />  
                <asp:BoundField DataField="FechaTermino" HeaderText="Fecha de Término" />  
            </Columns>  
        </asp:GridView>  

        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label> 
        <div class="mt-4">  
            <asp:Button ID="btnAnterior" runat="server" Text="Anterior" OnClick="btnAnterior_Click" />  
            <asp:Button ID="btnSiguiente" runat="server" Text="Siguiente" OnClick="btnSiguiente_Click" />  
        </div>  
    </div>  
</asp:Content>
