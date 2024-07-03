﻿<%@ Page Title="" Language="C#" MasterPageFile="~/frm/master/site2019.Master" AutoEventWireup="true" CodeBehind="frmNominaciones.aspx.cs" Inherits="InscripcionMinSalud.frm.procesos.frmNominaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>

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
    </style>
    <link href="../../Scripts/fancy/source/fancyMins.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


     <div class="row">
        <div class="tagline">
            <div class="container">
                <h2 class="tag">Tecnologías nominadas hasta el momento </h2>
                                  
             </div>
        </div>
    </div>

    <div class="row">
        <div class="container">
             <div class="col-md-6 col-md-offset-3">
                <h3 class="separation-title__another">  
                    </h3>
                 <p class="separation-title__another">  
                  </p>
<p class="centerp"> <strong> 
    <asp:Label runat="server" ID="lblNombreProceso"></asp:Label>
                                           </strong> </p>
            </div>
            <div class="row">
                
                <div class="col-md-8 col-md-offset-2">
                    
                    <asp:DataList runat="server" ID="datos" DataKeyField="COD_NOMINACION_PROCESO" DataSourceID="SqlDataSource1" OnItemDataBound="datos_ItemDataBound" >
                       <ItemTemplate>
                                <fieldset runat="server" id="Fieldset1" class="form-group" style=" margin:10px !important;">
                                <legend><span><%# Eval("NOMBRE_PROCESO") %></span> </legend>

                                      <div class="row" style=" margin-top:-40px;margin-bottom:10px !important;">
                                          <div class="pull-left">


                                            <label for="txtNumeroDocumentoNatural"  ClientIDMode="Static" runat="server" id="lbl2"> 
                                                <span>Nombre de la Tecnologia:</span></label> <%# Eval("ID_MANUAL") %>-<%# Eval("NOMBRE_TECNOLOGIA") %>
                                            <br />
                                              
                           <label for="txtNumeroDocumentoNatural"  ClientIDMode="Static" runat="server" id="Label1"> <span>Estado:</span></label><%# Eval("NOMBRE_ESTADO_NOMINACION") %>
                                              <br />
                                            <label for="txtNumeroDocumentoNatural"  ClientIDMode="Static" runat="server" id="Label4"> <span>Fecha nominación:</span></label><%# Eval("FECHA_NOMINACION") %>
                           
                                          </div>
                                          <div class ="pull-right">
                                              <br/><br/>
 <a href='<%# "frmInscripcionProceso.aspx?codN="+Eval("COD_NOMINACION_PROCESO")+"&codProceso="+Eval("COD_PROCESO") %>' id="lnkVerMas">Ver más</a>

                                               <a href='<%# "../informes/frmReportViewer.aspx?cod="+Eval("COD_NOMINACION_PROCESO") %>' target="_blank" id="lnkPDF">Generar PDF</a>
                           
                                          </div>
                                      </div>

                                    <div class="row">
                                        Objeciones
                                        <asp:Label runat="server" ID="lblCodNominacion" Visible="false" Text='<%# Eval("COD_NOMINACION_PROCESO") %>'></asp:Label>
                                        <asp:Repeater runat="server" ID="grdObjeciones">
                                            <ItemTemplate>
                                                <asp:HyperLink runat="server" ID="lnkObjecion"
                                                    NavigateUrl='<%# "frmObjetar.aspx?codN="+Eval("COD_NOMINACION_PROCESO")+"&codobjecion="+Eval("COD_OBJECION_PROCESO") %>'
                                                    Text='<%# Eval("REGISTRO.NOMBRE").ToString()
                                                        +" "+ Eval("REGISTRO.APELLIDOS") + " documento: "+Eval("REGISTRO.DOCUMENTO").ToString()
                                                        + " Fecha objeción:"+ Eval("FECHA_OBJECION")+"<br>" %>'
                                                     ></asp:HyperLink>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>

                                      </fieldset>
                        </ItemTemplate>

                    </asp:DataList>
                         





                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TRANSPLANTESConnectionString %>" SelectCommand="
                            SELECT 
                            RTRIM(ID_MANUAL) ID_MANUAL,
                            case when NOMBRE_TIPO_JURIDICO is null 
then  dbo.verNombreTipoNatural(registro.COD_REGISTRO) else dbo.verNombreTipo( registro.COD_TIPO_JURIDICO)  end
as TipoUsuario,REGISTRO.DOCUMENTO+''+isnull('-'+DIGITO_VERIFICACION,'') NumeroIdentificacion,
                            
                            ESTADO_NOMINACION.NOMBRE_ESTADO_NOMINACION, NOMINACION_PROCESO.COD_NOMINACION_PROCESO, PROCESO.NOMBRE_PROCESO, NOMINACION_PROCESO.ES_MEDICAMENTO, NOMINACION_PROCESO.ES_PROCEDIMIENTO, NOMINACION_PROCESO.ES_DISPOSITIVO_MEDICO, NOMINACION_PROCESO.ES_OTRO, NOMINACION_PROCESO.COD_PROCESO, NOMINACION_PROCESO.NOMBRE_TECNOLOGIA, NOMINACION_PROCESO.CIE10, NOMINACION_PROCESO.CIE10_2, NOMINACION_PROCESO.CIE10_INDICACION, NOMINACION_PROCESO.MEDICAMENTOS, NOMINACION_PROCESO.PROCEDIMIENTO, NOMINACION_PROCESO.DISPOSITIVO, NOMINACION_PROCESO.DESCRIPCION_OTRO, NOMINACION_PROCESO.CRITERIO_A, NOMINACION_PROCESO.CRITERIO_B, NOMINACION_PROCESO.CRITERIO_C, 
                            NOMINACION_PROCESO.CRITERIO_D, NOMINACION_PROCESO.CRITERIO_E, NOMINACION_PROCESO.CRITERIO_F, NOMINACION_PROCESO.ADJUNTA_EVIDENCIA, 
                            NOMINACION_PROCESO.CONFLICTO_INTERES, NOMINACION_PROCESO.FECHA_NOMINACION, REGISTRO.ES_PERSONA_NATURAL, REGISTRO.ES_PERSONA_JURIDICA,
                             REGISTRO.NOMBRE + isnull(REGISTRO.APELLIDOS,'') 'NOMBRE'
                              FROM ESTADO_NOMINACION 
                            INNER JOIN NOMINACION_PROCESO ON ESTADO_NOMINACION.COD_ESTADO_NOMINACION = NOMINACION_PROCESO.COD_ESTADO_NOMINACION
                             INNER JOIN PROCESO ON NOMINACION_PROCESO.COD_PROCESO = PROCESO.COD_PROCESO
                             INNER JOIN REGISTRO ON NOMINACION_PROCESO.COD_REGISTRO = REGISTRO.COD_REGISTRO 
left join TIPO_JURIDICO on registro.cod_tipo_juridico = TIPO_JURIDICO.COD_TIPO_JURIDICO
                            WHERE (NOMINACION_PROCESO.COD_ESTADO_NOMINACION =3) AND (NOMINACION_PROCESO.cod_proceso = @proceso)">
                            <SelectParameters>
                                <asp:QueryStringParameter Name="proceso" QueryStringField="codProceso" />
                            </SelectParameters>
                          
                    </asp:SqlDataSource>
                         





                        </div>
            </div>
            </div>
    </div>


</asp:Content>