<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PetFunny.WEB.Default" %>  
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">  
</asp:Content>  
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">  
    <div class="container">  
        <div class="text-center mt-4">
            <h1>"El mejor segundo hogar de tu mascota"</h1>
            <h4><asp:Label ID="lblWelcome" runat="server"></asp:Label></h4>  
        </div>  
    </div>  

    <!-- Sección de Alojamientos -->  
    <div class="container mt-4">  
        <h3 class="text-center">Alojamientos Disponibles</h3>  
        <div class="row">  
            <!-- alojamiento 1 -->  
            <div class="col-md-4 mb-4">  
                <div class="card">  
                    <img src="images/pets1.jpg" class="card-img-top" alt="Alojamiento 1">  
                    <div class="card-body">  
                        <h5 class="card-title">Alojamiento Premium</h5>  
                        <p class="card-text">Disfruta de un alojamiento cómodo y seguro para tu mascota con todas las comodidades.</p>  
                        <a href="Contacto.aspx" class="btn btn-primary">Más Información</a>  
                    </div>  
                </div>  
            </div>  

            <!-- alojamiento 2 -->  
            <div class="col-md-4 mb-4">  
                <div class="card">  
                    <img src="images/pets2.jpg" class="card-img-top" alt="Alojamiento 2">  
                    <div class="card-body">  
                        <h5 class="card-title">Alojamiento Estándar</h5>  
                        <p class="card-text">Un alojamiento básico pero cómodo para tu mascota. Ideal para estancias cortas.</p>  
                        <a href="Contacto.aspx" class="btn btn-primary">Más Información</a>  
                    </div>  
                </div>  
            </div>  

            <!-- alojamiento 3 -->  
            <div class="col-md-4 mb-4">  
                <div class="card">  
                    <img src="images/pets3.jpg" class="card-img-top" alt="Alojamiento 3">  
                    <div class="card-body">  
                        <h5 class="card-title">Alojamiento de Lujo</h5>  
                        <p class="card-text">Para quienes buscan lo mejor para sus mascotas, con servicios exclusivos y atención personalizada.</p>  
                        <a href="Contacto.aspx" class="btn btn-primary">Más Información</a>  
                    </div>  
                </div>  
            </div>  
        </div>  
        
        <!-- Sección de Contacto o Reserva -->  
        <div class="text-center mt-4">  
            <h3>¿Interesado en Reservar?</h3>  
            <p>Contáctanos para obtener más información o hacer una reserva.</p>  
            <a href="Contacto.aspx" class="btn btn-primary">Contáctanos</a>  
        </div>  
    </div>
    <br />
</asp:Content>