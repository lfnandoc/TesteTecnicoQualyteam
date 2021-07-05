using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace TesteTecnicoQualyteam
{

    public partial class Consulta : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            gridDocumentos.Sort("titulo", SortDirection.Ascending);
        }
           

        /*  protected void btnBuscar_Click(object sender, EventArgs e)
{
// Conexão ao banco de dados
MySqlConnection conexao = new MySqlConnection("server=localhost;User Id=root;database=ttqdb; password=3578tr");
MySqlCommand comando = new MySqlCommand("SELECT * FROM DOCUMENTOS WHERE TITULO LIKE @BUSCA", conexao);

try
{
conexao.Open();
comando.Parameters.AddWithValue("BUSCA", "%" + txtBusca.Text + "%");
gridDocumentos.DataSource = comando.ExecuteReader();
gridDocumentos.DataBind();
formatarTabela(gridDocumentos);
}
finally
{
conexao.Close();
}

}


protected void Page_Load(object sender, EventArgs e)
{

// Conexão ao banco de dados
MySqlConnection conexao = new MySqlConnection("server=localhost;User Id=root;database=ttqdb; password=3578tr");
MySqlCommand comando = new MySqlCommand("SELECT * FROM DOCUMENTOS", conexao);

try
{
conexao.Open();
gridDocumentos.DataSource = comando.ExecuteReader();                
gridDocumentos.DataBind();

formatarTabela(gridDocumentos);
}
finally
{
conexao.Close();
}
}

protected void formatarTabela(GridView tabela)
{
// tabela.Sort("titulo", SortDirection.Ascending);
}*/

    }
     
}
