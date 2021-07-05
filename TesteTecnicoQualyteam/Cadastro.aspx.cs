using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TesteTecnicoQualyteam
{
            protected void upload_OnClick(object sender, EventArgs e)
            {
                if (FileUploadControl.PostedFile.ContentLength < 8388608)
                {
                    try
                    {
                        if (FileUploadControl.HasFile)
                        {
                            try
                            {
                                //Aqui ele vai filtrar pelo tipo de arquivo
                                if (FileUploadControl.PostedFile.ContentType == "image/jpeg" ||
                                    FileUploadControl.PostedFile.ContentType == "image/png" ||
                                    FileUploadControl.PostedFile.ContentType == "image/gif" ||
                                    FileUploadControl.PostedFile.ContentType == "image/bmp")
                                {
                                    try
                                    {
                                        //Obtem o  HttpFileCollection
                                        HttpFileCollection hfc = Request.Files;
                                        for (int i = 0; i < hfc.Count; i++)
                                        {
                                            HttpPostedFile hpf = hfc[i];
                                            if (hpf.ContentLength > 0)
                                            {
                                                //Pega o nome do arquivo
                                                string nome = System.IO.Path.GetFileName(hpf.FileName);
                                                //Pega a extensão do arquivo
                                                string extensao = Path.GetExtension(hpf.FileName);
                                                //Gera nome novo do Arquivo numericamente
                                                string filename = string.Format("{0:00000000000000}", GerarID());
                                                //Caminho a onde será salvo
                                                hpf.SaveAs(Server.MapPath("~/uploads/fotos/") + filename + i
                                                + extensao);

                                                //Prefixo p/ img pequena
                                                var prefixoP = "-p";
                                                //Prefixo p/ img grande
                                                var prefixoG = "-g";

                                                //pega o arquivo já carregado
                                                string pth = Server.MapPath("~/uploads/fotos/")
                                                + filename + i + extensao;

                                                //Redefine altura e largura da imagem e Salva o arquivo + prefixo
                                                Redefinir.resizeImageAndSave(pth, 70, 53, prefixoP);
                                                Redefinir.resizeImageAndSave(pth, 500, 331, prefixoG);
                                            }

                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                    // Mensagem se tudo ocorreu bem
                                    StatusLabel.Text = "Todas imagens carregadas com sucesso!";

                                }
                                else
                                {
                                    // Mensagem notifica que é permitido carregar apenas
                                    // as imagens definida la em cima.
                                    StatusLabel.Text = "É permitido carregar apenas imagens!";
                                }
                            }
                            catch (Exception ex)
                            {
                                // Mensagem notifica quando ocorre erros
                                StatusLabel.Text = "O arquivo não pôde ser carregado.
                                O seguinte erro ocorreu: " + ex.Message;
              }
    }
}
      catch (Exception ex)
{
    // Mensagem notifica quando ocorre erros
    StatusLabel.Text = "O arquivo não pôde ser carregado.
          O seguinte erro ocorreu: " + ex.Message;
      }
  }
  else
{
    // Mensagem notifica quando imagem é superior a 8 MB
    StatusLabel.Text = "Não é permitido carregar mais do que 8 MB";
}
}
        }

    
  
}