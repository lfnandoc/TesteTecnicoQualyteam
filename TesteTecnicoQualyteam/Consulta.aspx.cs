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
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MySqlConnection conexao = new MySqlConnection("server=SERVIDOR;User Id=USUARIO;database=BANCO; password=SENHA");
            MySqlCommand comando = new MySqlCommand("SELECT * FROM PRODUTOS", conexao);
            DataTable tabela = new DataTable();
            try
            {
                conexao.Open();
                gdvDados.DataSource = comando.ExecuteReader();
                gdvDados.DataBind();
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}