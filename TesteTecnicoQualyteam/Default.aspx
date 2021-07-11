<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TesteTecnicoQualyteam._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron" style="display: flex; justify-content: space-around;">
        <div class="">
            <h1>XYZ</h1>
            <p class="lead">Gerenciador de documentos da empresa XYZ.</p>
        </div>
        <img src="Content\Images\documento.png" height="150" />
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Consulta</h2>
            <p>
                Acesse todos os documentos cadastrados no sistema.
            </p>
            <p>
                <a class="btn btn-default" runat="server" href="~/Consulta">Ir &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Cadastro</h2>
            <p>
                Cadastre documentos no sistema.
            </p>
            <p>
                <a class="btn btn-default" runat="server" href="~/Cadastro">Ir &raquo;</a>
            </p>
        </div>
    </div>
</asp:Content>