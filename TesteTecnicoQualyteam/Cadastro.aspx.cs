using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace TesteTecnicoQualyteam
{
    public partial class Cadastro : Page
    {
        protected void NovaMensagemEstadoCarregamento(String mensagem, Color cor)
        {
            legenda_EstadoCarregamento.Text = mensagem;
            legenda_EstadoCarregamento.ForeColor = cor;
        }

        protected Boolean ExtensaoValida(String extensao)
        {
            string[] extensoes_permitidas = new string[] { ".pdf", ".doc", ".docx", ".xls", ".xlsx" };
            if (extensoes_permitidas.Contains<string>(extensao))
            {
                return true;
            }
            return false;
        }

        protected void CarregarArquivo(HttpPostedFile arquivo)
        {
            MySqlConnection conexaoMySQL = new MySqlConnection("server=localhost;User Id=root;database=ttqdb; password=3578tr");
            conexaoMySQL.Open();
            MySqlCommand checarCodigo = new MySqlCommand("SELECT id FROM documentos WHERE id = '" + Int32.Parse(entradaTexto_Codigo.Text) + "'", conexaoMySQL);
            if (checarCodigo.ExecuteScalar() == null)
            {
                string nomeArquivoSelecionado = Path.GetFileNameWithoutExtension(arquivo.FileName);
                string nomeArquivoCarregadoNoServidor = Math.Abs(nomeArquivoSelecionado.GetHashCode()) + "_" + DateTime.Now.ToFileTimeUtc() + Path.GetExtension(arquivo.FileName);
                string enderecoArquivoCarregadoNoServidor = Server.MapPath("./uploads/") + nomeArquivoCarregadoNoServidor;
                string comandoInsercaoDB = "INSERT INTO documentos(id, titulo, processo, categoria, arquivo, hora_upload) values (@id, @titulo, @processo, @categoria, @arquivo, @data)";
                MySqlCommand comandoMySQL = new MySqlCommand(comandoInsercaoDB, conexaoMySQL);
                comandoMySQL.Parameters.AddWithValue("@id", Int32.Parse(entradaTexto_Codigo.Text));
                comandoMySQL.Parameters.AddWithValue("@titulo", entradaTexto_Titulo.Text);
                comandoMySQL.Parameters.AddWithValue("@processo", entradaTexto_Processo.Text);
                comandoMySQL.Parameters.AddWithValue("@categoria", entradaTexto_Categoria.Text);
                comandoMySQL.Parameters.AddWithValue("@arquivo", nomeArquivoCarregadoNoServidor);
                comandoMySQL.Parameters.AddWithValue("@data", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                comandoMySQL.ExecuteNonQuery();
                arquivo.SaveAs(enderecoArquivoCarregadoNoServidor);
                conexaoMySQL.Close();
                NovaMensagemEstadoCarregamento("Carregamento do documento '" + entradaTexto_Titulo.Text + "' bem sucedido!", Color.Green);
                entradaTexto_Codigo.Text = entradaTexto_Titulo.Text = entradaTexto_Processo.Text = entradaTexto_Categoria.Text = "";
            }
            else
            {
                NovaMensagemEstadoCarregamento("Já existe um documento com este código.", Color.Red);
            }
        }

        protected void botaoCarregar_Clique(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(entradaTexto_Codigo.Text)
                || String.IsNullOrWhiteSpace(entradaTexto_Processo.Text)
                || String.IsNullOrWhiteSpace(entradaTexto_Titulo.Text)
                || String.IsNullOrWhiteSpace(entradaTexto_Categoria.Text))
            {
                NovaMensagemEstadoCarregamento("Todos os campos são obrigatórios.", Color.Red);
                return;
            }

            if (!controlador_CarregamentoArquivo.HasFile)
            {
                NovaMensagemEstadoCarregamento("É necessário selecionar um arquivo.", Color.Red);
                return;
            }

            HttpPostedFile arquivoSelecionado = controlador_CarregamentoArquivo.PostedFile;
            if (arquivoSelecionado.ContentLength > 15728640)
            {
                NovaMensagemEstadoCarregamento("O tamanho do arquivo não pode exceder 15 MB.", Color.Red);
                return;
            }

            if (!ExtensaoValida(Path.GetExtension(arquivoSelecionado.FileName)))
            {
                NovaMensagemEstadoCarregamento("Extensões permitidas: *.pdf, *.doc, *.docx, *.xls e *.xlsx!", Color.Red);
                return;
            }

            try
            {
                CarregarArquivo(arquivoSelecionado);
            }
            catch (Exception ex)
            {
                NovaMensagemEstadoCarregamento("O carregamento falhou.\nO seguinte erro ocorreu: " + ex.Message, Color.Red);
            }
        }
    }
}