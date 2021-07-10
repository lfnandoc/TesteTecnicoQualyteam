using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TesteTecnicoQualyteam
{
    public partial class Consulta : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Classifica os documentos por título ao carregar a página
            gridDocumentos.Sort("titulo", SortDirection.Ascending);

        }

    }

}
