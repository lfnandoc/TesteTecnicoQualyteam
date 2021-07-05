<%@ Page Title="Cadastro" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="TesteTecnicoQualyteam.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h1>Cadastro de Documento</h1>
     <p></p>      <hr/>
    <form enctype="multipart/form-data" method="post">
    <asp:Label ID="labelCodigo" runat="server" Text="Código"></asp:Label>
  
    <br/>
    <asp:TextBox ID="input_Codigo" runat="server"></asp:TextBox>
      <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
    ControlToValidate="input_Codigo" runat="server"
   ForeColor="Red"
    ErrorMessage="Apenas números são permitidos no campo CÓDIGO."
    ValidationExpression="\d+">
</asp:RegularExpressionValidator>
    <br/>
    <asp:Label ID="labelProcesso" runat="server" Text="Processo"></asp:Label>
    <br/>
    <asp:TextBox ID="input_Processo" runat="server"></asp:TextBox>
    <br/>
    <asp:Label ID="labelTitulo" runat="server" Text="Título"></asp:Label>
    <br/>
    <asp:TextBox ID="input_Titulo" runat="server"></asp:TextBox>
    <br/>
    <asp:Label ID="labelCategoria" runat="server" Text="Categoria"></asp:Label>
    <br/>
    <asp:TextBox ID="input_Categoria" runat="server"></asp:TextBox>
    <br/>
     <asp:Label ID="labelArquivo" runat="server" Text="Arquivo"></asp:Label>
   <br/>
          <dl>
        <dt>
            <label asp-for="FileUpload.FormFile"></label>
        </dt>
        <dd>
            <input asp-for="FileUpload.FormFile" type="file">
            <span asp-validation-for="FileUpload.FormFile"></span>
        </dd>
    </dl>
    <input asp-page-handler="upload" Click="upload_OnClick" class="btn" type="submit" value="Subir Arquivo" />
        </form>

</asp:Content>
