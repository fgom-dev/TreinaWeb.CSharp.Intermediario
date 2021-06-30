using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace EstudoXML
{
    public partial class frmAgenda : Form
    {
        public frmAgenda()
        {
            InitializeComponent();
        }

        private void frmAgenda_Load(object sender, EventArgs e)
        {
            lblTitulo.Text = CarregarTitulo();
            CarregarContatos();
        }

        private string CarregarTitulo()
        {
            XmlDocument documentoXML = new XmlDocument();
            documentoXML.Load(@"C:\Users\usuario022\source\repos\TreinaWeb.CSharp.Intermediario\EstudoXML\Agenda.xml");
            XmlNode noTitulo = documentoXML.SelectSingleNode("/agenda/titulo");
            return noTitulo.InnerText;            
        }

        private void CarregarContatos()
        {
            XmlDocument documentoXML = new XmlDocument();
            documentoXML.Load(@"C:\Users\usuario022\source\repos\TreinaWeb.CSharp.Intermediario\EstudoXML\Agenda.xml");
            XmlNodeList contatos = documentoXML.SelectNodes("/agenda/contatos/contato");
            foreach (XmlNode contato in contatos)
            {
                string representacaoContato = "";
                string id = contato.Attributes["id"].Value;
                string nome = contato.Attributes["nome"].Value;
                string idade = contato.Attributes["idade"].Value;
                representacaoContato = nome + ", " + idade + ", " + id;
                lbxContatos.Items.Add(representacaoContato);
            }
        }
    }
}
