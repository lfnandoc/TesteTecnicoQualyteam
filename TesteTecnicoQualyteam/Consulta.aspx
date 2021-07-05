<%@ Page Title="Consulta" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Consulta.aspx.cs" Inherits="TesteTecnicoQualyteam.Consulta" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Consulta de Documentos.</h1>
     <p>Consulte todos os documentos armazenados pela empresa nesta página.</p>

      <hr />
    <asp:GridView ID="gridDocumentos" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="id" DataSourceID="TTQdb" EnableSortingAndPagingCallbacks="True" ForeColor="Black" GridLines="Horizontal" PageSize="20" Width="500px">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="Código" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="titulo" HeaderText="Título" SortExpression="titulo" />
            <asp:BoundField DataField="processo" HeaderText="Processo" SortExpression="processo" />
            <asp:BoundField DataField="categoria" HeaderText="Categoria" SortExpression="categoria" />
            <asp:BoundField DataField="arquivo" HeaderText="Download" SortExpression="arquivo" />
        </Columns>
        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
    </asp:GridView>

    

    <asp:SqlDataSource runat="server" ID="TTQdb" ConnectionString='<%$ ConnectionStrings:ttqdbConnectionString2 %>' ProviderName='<%$ ConnectionStrings:ttqdbConnectionString2.ProviderName %>' SelectCommand="SELECT * FROM DOCUMENTOS" ></asp:SqlDataSource>
</asp:Content>





