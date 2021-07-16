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

    <asp:Label ID="legenda_Codigo" runat="server" Text="Código" AssociatedControlID="entradaTexto_Codigo"></asp:Label>
    <br />
    <asp:TextBox ID="entradaTexto_Codigo" runat="server" MaxLength="9"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
        ControlToValidate="entradaTexto_Codigo" runat="server"
        ForeColor="Red"
        ErrorMessage="Apenas números são permitidos no campo CÓDIGO."
        ValidationExpression="^[0-9]*$">
    </asp:RegularExpressionValidator>
    <br />

    <asp:Label ID="legenda_Titulo" runat="server" Text="Título" AssociatedControlID="entradaTexto_Titulo"></asp:Label>
    <br />
    <asp:TextBox ID="entradaTexto_Titulo" runat="server" MaxLength="50"></asp:TextBox>
    <br />

    <asp:Label ID="legenda_Processo" runat="server" Text="Processo" AssociatedControlID="entradaTexto_Processo"></asp:Label>
    <br />
    <asp:TextBox ID="entradaTexto_Processo" runat="server" MaxLength="50"></asp:TextBox>
    <br />

    <asp:Label ID="legenda_Categoria" runat="server" Text="Categoria" AssociatedControlID="entradaTexto_Categoria"></asp:Label>
    <br />
    <asp:TextBox ID="entradaTexto_Categoria" runat="server" MaxLength="50"></asp:TextBox>
    <br />

    <br />
    <asp:Label ID="legenda_Arquivo" runat="server" Font-Bold="True" Text="Arquivo"></asp:Label>
    <br />
    <div>
        <br />
        <asp:FileUpload ID="controlador_CarregamentoArquivo" runat="server" class="multi" />
        <br />
        <asp:Label runat="server" ID="legenda_EstadoCarregamento" Text="" ForeColor="Red" />
        <br />
        <asp:Button ID="botaoCarregar" runat="server" Text="Carregar" OnClick="botaoCarregar_Clique" BackColor="#000000" BorderColor="#000000" Font-Bold="True" ForeColor="White" />
        <br />
    </div>

</asp:Content>