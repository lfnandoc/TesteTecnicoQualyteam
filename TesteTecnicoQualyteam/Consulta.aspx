<%@ Page Title="Consulta" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Consulta.aspx.cs" Inherits="TesteTecnicoQualyteam.Consulta" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Consulta de Documentos.</h1>
     <p>Consulte todos os documentos armazenados pela empresa nesta página.</p>

      <hr />
    <asp:GridView ID="gridDocumentos" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="id" DataSourceID="TTQdb" ForeColor="Black" GridLines="Horizontal" PageSize="20" Width="700px">
        <Columns>
            <asp:BoundField DataField="hora_upload" HeaderText="Hora do Upload" SortExpression="hora_upload" HeaderStyle-CssClass="text-center"/>
            <asp:BoundField DataField="id" HeaderText="Código" ReadOnly="True" SortExpression="id"  HeaderStyle-CssClass="text-center"/>
            <asp:BoundField DataField="titulo" HeaderText="Título" SortExpression="titulo"  HeaderStyle-CssClass="text-center"/>
            <asp:BoundField DataField="processo" HeaderText="Processo" SortExpression="processo"  HeaderStyle-CssClass="text-center"/>
            <asp:BoundField DataField="categoria" HeaderText="Categoria" SortExpression="categoria"  HeaderStyle-CssClass="text-center"/>
            <asp:TemplateField HeaderText="Arquivo" SortExpression="arquivo"  HeaderStyle-CssClass="text-center">
                <ItemTemplate>             
                    <asp:HyperLink ID="DownloadLink" runat="server" NavigateUrl='<%# Eval("arquivo", "/uploads/{0}") %>' target="_blank"> 
                        <asp:Button ID="ButtonDownload" runat="server" Text="Download" UseSubmitBehavior="False" />
                    </asp:HyperLink>
                 </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" Font-Italic="False" />
        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
    </asp:GridView>

    

    <asp:SqlDataSource runat="server" ID="TTQdb" ConnectionString='<%$ ConnectionStrings:ttqdbConnectionString2 %>' ProviderName='<%$ ConnectionStrings:ttqdbConnectionString2.ProviderName %>' SelectCommand="SELECT * FROM DOCUMENTOS" ></asp:SqlDataSource>
</asp:Content>





