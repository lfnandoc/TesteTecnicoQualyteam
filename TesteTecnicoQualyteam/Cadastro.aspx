<%@ Page Title="Cadastro" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="TesteTecnicoQualyteam.Cadastro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Cadastro de Documento</h1>
    <p>
        Realize o cadastro de novos documentos aqui.<br />
        Todos os campos são obrigatórios.<br />
        <br />
        <b>Extensões permitidas: *.pdf, *.doc, *.docx, *.xls e *.xlsx</b><br />
        <b>Tamanho máximo: 15 MB</b>
    </p>
    
    <hr />

    <asp:Label ID="labelCodigo" runat="server" Text="Código" AssociatedControlID="input_Codigo"></asp:Label>
    <br />
    <asp:TextBox ID="input_Codigo" runat="server" MaxLength="9"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
        ControlToValidate="input_Codigo" runat="server"
        ForeColor="Red"
        ErrorMessage="Apenas números são permitidos no campo CÓDIGO."
        ValidationExpression="^[0-9]*$">
    </asp:RegularExpressionValidator>
    <br />

    <asp:Label ID="labelTitulo" runat="server" Text="Título" AssociatedControlID="input_Titulo"></asp:Label>
    <br />
    <asp:TextBox ID="input_Titulo" runat="server" MaxLength="50"></asp:TextBox>
    <br />

    <asp:Label ID="labelProcesso" runat="server" Text="Processo" AssociatedControlID="input_Processo"></asp:Label>
    <br />
    <asp:TextBox ID="input_Processo" runat="server" MaxLength="50"></asp:TextBox>
    <br />

    <asp:Label ID="labelCategoria" runat="server" Text="Categoria" AssociatedControlID="input_Categoria"></asp:Label>
    <br />
    <asp:TextBox ID="input_Categoria" runat="server" MaxLength="50"></asp:TextBox>
    <br />

    <br />
    <asp:Label ID="labelArquivo" runat="server" Font-Bold="True" Text="Arquivo"></asp:Label>
    <br />
    <div>
        <br />
        <asp:FileUpload ID="FileUploadControl" runat="server" class="multi" />
        <br />
        <asp:Label runat="server" ID="StatusLabel" Text="" ForeColor="Red" />
        <br />
        <asp:Button ID="btnUpload" runat="server" Text="Carregar" OnClick="btnUpload_Click" BackColor="#000000" BorderColor="#000000" Font-Bold="True" ForeColor="White" />
        <br />
    </div>

</asp:Content>