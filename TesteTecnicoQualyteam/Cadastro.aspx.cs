using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace TesteTecnicoQualyteam
{
    public partial class Cadastro : Page
    {
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            // Verifica se todos os campos foram preenchidos, também não aceitando strings apenas com espaços
            if (String.IsNullOrWhiteSpace(input_Codigo.Text)
                || String.IsNullOrWhiteSpace(input_Processo.Text)
                || String.IsNullOrWhiteSpace(input_Titulo.Text)
                || String.IsNullOrWhiteSpace(input_Categoria.Text))
            {
                StatusLabel.Text = "É necessário preencher todos os campos corretamente.";
                return;
            }

            //Verifica se há arquivo anexado
            if (!FileUploadControl.HasFile)
            {
                StatusLabel.Text = "É necessário selecionar um arquivo.";
                return;
            }

            //Verifica se o arquivo tem menos de 15mb
            HttpPostedFile hpf = FileUploadControl.PostedFile;
            if (hpf.ContentLength > 15728640)
            {
                StatusLabel.Text = "O tamanho do arquivo não pode exceder 15 MB.";
                return;
            }

            //Verifica a extensão do arquivo
            string extensao = Path.GetExtension(hpf.FileName);
            string[] extensoes_permitidas = new string[] { ".pdf", ".doc", ".docx", ".xls", ".xlsx" };
            if (!extensoes_permitidas.Contains<string>(extensao))
            {
                StatusLabel.Text = "Extensões permitidas: .pdf, .doc, .docx, .xls e .xlsx!";
                return;
            }

            try
            {
                //Conexão à database MySql
                MySqlConnection conexao = new MySqlConnection("server=localhost;User Id=root;database=ttqdb; password=3578tr");
                conexao.Open();

                //Verifica se já existe o código na database
                MySqlCommand checarCodigo = new MySqlCommand("SELECT id FROM documentos WHERE id = '" + Int32.Parse(input_Codigo.Text) + "'", conexao);
                if (checarCodigo.ExecuteScalar() == null)
                {
                    string filename = Path.GetFileNameWithoutExtension(hpf.FileName);

                    // O nome do arquivo será uma hash do nome original + a hora atual, para evitar duplicados
                    string nomefinal = Math.Abs(filename.GetHashCode()) + "_" + DateTime.Now.ToFileTimeUtc() + extensao;

                    // O arquivo será salvo na pasta /uploads/ do servidor
                    string enderecofinal = Server.MapPath("./uploads/") + nomefinal; 

                    //Montagem do comando para inserir na database
                    string insertData = "INSERT INTO documentos(id, titulo, processo, categoria, arquivo, hora_upload) values (@id, @titulo, @processo, @categoria, @arquivo, @data)";
                    MySqlCommand command = new MySqlCommand(insertData, conexao);
                    command.Parameters.AddWithValue("@id", Int32.Parse(input_Codigo.Text));
                    command.Parameters.AddWithValue("@titulo", input_Titulo.Text);
                    command.Parameters.AddWithValue("@processo", input_Processo.Text);
                    command.Parameters.AddWithValue("@categoria", input_Categoria.Text);
                    command.Parameters.AddWithValue("@arquivo", nomefinal);
                    command.Parameters.AddWithValue("@data", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.ExecuteNonQuery();

                    //Salva o arquivo no servidor e fecha a conexão SQL
                    hpf.SaveAs(enderecofinal); 
                    conexao.Close();

                    //Mensagem de carregamento realizado com sucesso
                    StatusLabel.Text = "Carregamento do documento '" + input_Titulo.Text + "' bem sucedido!";

                    //Esvazia as caixas na página
                    input_Codigo.Text = input_Titulo.Text = input_Processo.Text = input_Categoria.Text = ""; 
                }
                else
                {
                    StatusLabel.Text = "Já existe um documento com este código.";
                }
            }
            catch (Exception ex)
            {
                // Se acontecer qualquer erro, retornará a mensagem
                StatusLabel.Text = "O carregamento falhou.\nO seguinte erro ocorreu: " + ex.Message;
            }
        }
    }
}