<%@ Page Title="" Language="C#" MasterPageFile="~/frm/master/site2019.Master" AutoEventWireup="true" CodeBehind="frmEventosFinal.aspx.cs" Inherits="InscripcionMinSalud.frm.procesos.frmEventosFinal" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderBienvenido" runat="server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
      
</style>
          <style type="text/css">
              .btnEsp{
                float: left;
                max-width: 200px;
                background-color: #d82f5e;
                color: white;
                margin-right: 20px;
                border-radius: 25px;
              }

    .modalBackground
    {
        background-color: Black;
        filter: alpha(opacity=90);
        opacity: 0.8;
    }
    
    .imagenP img{
             max-height:200px;
             max-width:200px;
         }
     </style>

    <style>

   .btnCancelar{
background: #30798d;
background: -moz-linear-gradient(top, #30798d 0%, #00abc8 100%);
background: -webkit-linear-gradient(top, #30798d 0%,#00abc8 100%);
background: linear-gradient(to bottom, #30798d 0%,#00abc8 100%);
filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#30798d', endColorstr='#00abc8',GradientType=0 );
border-radius: 5px;
color: #fff;
font-size: 1.9rem;
padding: 15px 30px;
border: none;
font-weight: bold;
width: 250px;
margin: 40px auto;
text-align: center;
}

         a#lnkVerMas{
background: #30798d;
background: -moz-linear-gradient(top, #30798d 0%, #00abc8 100%);
background: -webkit-linear-gradient(top, #30798d 0%,#00abc8 100%);
background: linear-gradient(to bottom, #30798d 0%,#00abc8 100%);
filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#30798d', endColorstr='#00abc8',GradientType=0 );
border-radius: 5px;
color: #fff;
font-size: 1.9rem;
padding: 15px 30px;
border: none;
font-weight: bold;
width: 250px;
margin: 40px auto;
text-align: center;
}

         th, td {
    padding: 10px;
    text-align: left;
    border-bottom: 1px solid #ddd;
}

                 a#lnkPDF{
background: #30798d;
background: -moz-linear-gradient(top, #30798d 0%, #00abc8 100%);
background: -webkit-linear-gradient(top, #30798d 0%,#00abc8 100%);
background: linear-gradient(to bottom, #30798d 0%,#00abc8 100%);
filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#30798d', endColorstr='#00abc8',GradientType=0 );
border-radius: 5px;
color: #fff;
font-size: 1.9rem;
padding: 15px 30px;
border: none;
font-weight: bold;
width: 250px;
margin: 40px auto;
text-align: center;
}
       .form-control {
display: block;
width: 100%;
height: 34px;
padding: 6px 12px;
font-size: 14px;
line-height: 1.42857143;
color: #555;
background-color: #fff;
background-image: none;
border: 1px solid #bde7ef !important;
border-radius: 4px;
-webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
-webkit-transition: border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s;
-o-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
}
h2.tag {
    font-size: 3rem;
    font-weight: bold;
    color: #17a9c7 !important;
    text-align: center;
    width: 500px;
    margin: 40px auto 20px auto !important;
}

p.centerp {
    text-align: center;
}

strong {
    color: #0aa1bc;
}

fieldset.form-group {
    margin: 40px 0px;
}

legend span {
    color: #17a9c7;
    font-weight: 700;
}

legend {
     border-bottom: 1px solid #f3a740 !important;
}

label {
       color: #266373 !important;
       margin: 20px 0px 5px 0px !important;
}

.txtMini{
	width:40% !important;
}
txtNormal{
	width:70% !important;
}
        .errormin {
        border-color:red !important;
        border-style:solid !important;
        border-width:2px !important;
        }


        input[type="checkbox"], input[type="radio"] {
line-height: normal;
width: auto;
display: inline-block;
height: auto;
margin: 4px 5px 0px 0px;
}

        
label {
    color: #266373 !important;
    margin: 0 !important;
    display: inline !important;
}


    </style>
    <link href="../../Scripts/fancy/source/fancyMins.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">

                <div class="col-md-8 col-md-offset-2">
					<h2 class="sub"><asp:Label runat="server" ID="lblTitulo" Text=""></asp:Label></h2>
				</div>
			</div>



     
    <div class="row">
        <div class="container">
        <div class="row">
            <div class="sm-8  col-md-offset-2">

    <asp:Panel runat="server" ID="pnlDelegados">




        <asp:Panel runat="server" ID="pnlAgregarDelegados">
            <h3>Es necesario ingresar <asp:Label runat="server" ID="lblCantidad"></asp:Label> delegados</h3>
           <strong> Ingrese el número  de documento del delegado, deberá estar inscritos previamente en Mi Vox-Populi </strong>
            <asp:TextBox runat="server" ID="txtDocumentoDelegado"></asp:TextBox>
            <asp:Button CssClass="btnAgregar" runat="server" ID="btnAgregarDelegado" Text="Agregar Delegado" OnClick="btnAgregarDelegado_Click" />
            <br />
            <asp:Label runat="server" Visible="true" ForeColor="Red" 
                ID="lblErrorDelegado" Text=""></asp:Label>
        </asp:Panel>
        <asp:Label runat="server" Visible="false" ID="lblDelegadosFull" Text="Ya se ingresarón todos los delegados para el evento."></asp:Label>

        <asp:GridView runat="server" AutoGenerateColumns="false" ID="grdDelegados" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                
                <asp:BoundField ItemStyle-Width="150px" HeaderText="Nombres" DataField="Nombres" />
                <asp:BoundField ItemStyle-Width="150px" HeaderText="Apellidos" DataField="Apellidos" />
                <asp:BoundField ItemStyle-Width="150px" HeaderText="Documento" DataField="Documento" />
                <asp:BoundField ItemStyle-Width="150px" HeaderText="Estado" DataField="Estado" />
                <asp:TemplateField ItemStyle-Width="150px" HeaderText="Opciones" >
                    <ItemTemplate>
                        <asp:Button runat="server" CommandArgument='<%# Eval("codRegistro") %>' ID="btnEliminar" Text="Eliminar" OnClick="btnEliminar_Click" OnClientClick="return confirm('Está seguro de eliminar el delegado?');" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>

    </asp:Panel>
                
              </div>
             </div>
         </div>
    </div> 
    <div class="spacer-20"></div>
        <div class="row">
        <div class="container">
            <div class="row">
            <div class="sm-8  col-md-offset-2">

                


<asp:Panel runat="server" ID="pnlArchivos">
 <br />

    
          
            
            <br />
            <asp:Label runat="server" Visible="true" ForeColor="Red" 
                ID="lblErrorArchivo" Text=""></asp:Label>

     
        <asp:GridView runat="server" AutoGenerateColumns="false" ID="grdArchivos" CellPadding="4" ForeColor="#333333" GridLines="None" Visible="false">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                
                <asp:TemplateField ItemStyle-Width="150px" HeaderText="Archivo modelo formato"  >
                    <ItemTemplate>
                         <asp:HyperLink runat="server" Visible="false"
                             NavigateUrl='<%# Eval("URL_ARCHIVO") %>' Target ="_blank"
                            ID="lnkArchivoPlantilla" Text='<%# Eval("nombre") %>' ></asp:HyperLink>

                        <asp:Label runat="server" id="NombreFormato" Text='<%# Eval("nombre") %>' />
                    </ItemTemplate>
                    

                </asp:TemplateField>

                <asp:TemplateField ItemStyle-Width="150px" HeaderText="Formato Diligenciado" >
                    <ItemTemplate>
                        <asp:HyperLink runat="server"
                             NavigateUrl='<%# Eval("url") %>' 
                            ID="lnkArchivo" Text="Ver Archivo cargado" Target="_blank"
                            visible='<%# Eval("url") != null && Eval("url").ToString() != string.Empty  %>'  />

                   <%--<asp:Label ID="formatoDiligenciado" runat="server" Text="NO" ForeColor="Red" ></asp:Label>--%>

                    </ItemTemplate>


                </asp:TemplateField>

                <asp:TemplateField ItemStyle-Width="150px" HeaderText="Formato Diligenciado" >
                    <ItemTemplate>
                        <asp:FileUpload runat="server" ID="fileCargar" visible="false"/>
                        
                        <asp:Button runat="server" ID="btnArchivo"
                            CommandArgument='<%# Eval("COD_FORMATO_EVENTO") %>'
                            OnClick="btnArchivo_Click"
                             Text="Declaro que he diligenciado el formato" />
                        </ItemTemplate>
               </asp:TemplateField>


            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>

</asp:Panel>
</div>
                </div>
</div>
    </div> 




    <div class="row" visible="false"  >
                             
                                <iframe width="100%" height= "700px"  src= "https://forms.office.com/Pages/ResponsePage.aspx?id=OuG3v7d_FkCDDNNxbo3YuLzNwN7HGUxDmcNyONcPDKRUNzc2QlFRMFUwRkw5VDlENDRQOU9QOE0zRiQlQCN0PWcu" frameborder= "0" marginwidth= "0" marginheight= "0" style= "border: none; max-width:100%; max-height:100vh" allowfullscreen webkitallowfullscreen mozallowfullscreen msallowfullscreen> </iframe>
                                                                          
                          </div>


    <div class="container" visible="false">
        <asp:CheckBox ID="formatoDiligenciado" Text="Declaro que he diligenciado el formulario electrónico que reúne el Consentimiento informado, Compromiso de confidencialidad y la Declaración de posible conflicto de interés." runat="server" />
         
    </div>

        <div class="row">
            <div class="sm-6  col-md-offset-3">

        <div class="call">
               <asp:Button CssClass="btnEsp"  runat="server" ID="btnVolver" Text="Volver" OnClick="btnVolver_Click" />
        
                <asp:Button CssClass="btnEsp" runat="server" ID="btnGuardar" Text="Guardar" OnClick="btnGuardar_Click" OnClientClick="return confirm('Es necesario declarar que se diligenció completamente el formulario para confirmar su asistencia al evento.');" />
          <asp:Button CssClass="btnEsp" runat="server" ID="btnCancelarAsistencia" Text="Cancelar asistencia"
               OnClick="btnCancelarAsistencia_Click" />
            
            </div>
                </div>
    </div> 
</asp:Content>
