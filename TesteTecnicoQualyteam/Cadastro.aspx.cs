using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Security.Cryptography;
using System.Text;

namespace TesteTecnicoQualyteam
{

    public partial class Cadastro : Page
    {

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;User Id=root;database=ttqdb; password=3578tr");

            if (input_Codigo.Text != "" && input_Processo.Text != "" && input_Titulo.Text != "" && input_Categoria.Text != "")
            {
                HttpPostedFile hpf = FileUploadControl.PostedFile;
                try
                {
                    if (FileUploadControl.HasFile)
                    {
                       
                            try
                            {

                                string extensao = Path.GetExtension(hpf.FileName);
                                string[] extensoes_permitidas = new string[] { ".pdf", ".doc", ".docx", ".xls", ".xlsx" };
                                if (extensoes_permitidas.Contains<string>(extensao))
                                {

                                    try
                                    {
                                        conexao.Open();
                                        MySqlCommand checarCodigo = new MySqlCommand("SELECT id FROM documentos WHERE id = '" + Int32.Parse(input_Codigo.Text) + "'", conexao);
                                        if (checarCodigo.ExecuteScalar() == null)
                                        {
                                            string filename = Path.GetFileNameWithoutExtension(hpf.FileName);
                                            string nomefinal = Math.Abs(filename.GetHashCode()) + "_" + DateTime.Now.ToFileTimeUtc() + extensao;
                                            string enderecofinal = Server.MapPath("./uploads/") + nomefinal;
                                            string insertData = "INSERT INTO documentos(id, titulo, processo, categoria, arquivo, hora_upload) values (@id, @titulo, @processo, @categoria, @arquivo, @data)";
                                            MySqlCommand command = new MySqlCommand(insertData, conexao);
                                            command.Parameters.AddWithValue("@id", Int32.Parse(input_Codigo.Text));
                                            command.Parameters.AddWithValue("@titulo", input_Titulo.Text);
                                            command.Parameters.AddWithValue("@processo", input_Processo.Text);
                                            command.Parameters.AddWithValue("@categoria", input_Categoria.Text);
                                            command.Parameters.AddWithValue("@arquivo", nomefinal);
                                            command.Parameters.AddWithValue("@data", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                            command.ExecuteNonQuery();
                                            hpf.SaveAs(enderecofinal);
                                            conexao.Close();
                                            StatusLabel.Text = "Carregamento bem sucedido!";
                                            input_Codigo.Text = input_Titulo.Text = input_Processo.Text = input_Categoria.Text = "";
                                        }
                                        else
                                        {
                                            StatusLabel.Text = "Já existe um documento com este código.";
                                        }
                                    }

                                    catch (Exception ex)
                                    {
                                        StatusLabel.Text = "O carregamento falhou.\nO seguinte erro ocorreu: " + ex.Message;
                                    }

                                }
                                else
                                {
                                    StatusLabel.Text = "Extensões permitidas: .pdf, .doc, .docx, .xls e .xlsx!";
                                }

                            }
                            catch (Exception ex)
                            {
                                StatusLabel.Text = "O carregamento falhou.\nO seguinte erro ocorreu: " + ex.Message;
                            }
                   
                    }
                    else
                    {
                        StatusLabel.Text = "É necessário anexar um arquivo.";
                    }

                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "O carregamento falhou.\nO seguinte erro ocorreu: " + ex.Message;
                }
            }
            else
            {
                StatusLabel.Text = "É necessário preencher todos os campos corretamente.";
            }

        }

    }


}











