using DemoWinFormsConsultaCepWsCorreios.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoWinFormsConsultaCepWsCorreios.Formularios
{
    public partial class FrmConsultaCep : Form
    {
        public FrmConsultaCep()
        {
            InitializeComponent();
        }
        
        public DataSet GetDataSet(List<Endereco> end)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            dt.Columns.Add("Código", typeof(string));
            dt.Columns.Add("Cep", typeof(string));
            dt.Columns.Add("Rua", typeof(string));
            dt.Columns.Add("Bairro", typeof(string));
            dt.Columns.Add("Cidade", typeof(string));
            dt.Columns.Add("Estado", typeof(string));
            dt.Columns.Add("Uf", typeof(string));
            dt.Columns.Add("Complemento", typeof(string));

            foreach (Endereco _end in end)
            {
                DataRow row = dt.NewRow();
                row["Código"] = _end.id;
                row["cep"] = _end.cep;
                row["rua"] = _end.rua;
                row["bairro"] = _end.bairro;
                row["cidade"] = _end.cidade;
                row["estado"] = _end.estado;
                row["uf"] = _end.uf;
                row["complemento"] = _end.complemento;

                dt.Rows.Add(row);
            }

            ds.Tables.Add(dt);
            return ds;
        }

        private void btnConsultarCEP_Click(object sender, EventArgs e)
        {
            try
            {
                wsCorreios.AtendeClienteService request = new wsCorreios.AtendeClienteService();

                var response = request.consultaCEP(txtCEP.Text.Trim());


                List<Endereco> EnderecoList = new List<Endereco>();

                Endereco _endereco = new Endereco(response.id.ToString(), response.cep, response.end, response.bairro, response.cidade, response.cidade, response.uf, response.complemento2);

                EnderecoList.Add(_endereco);
                dgCEP.DataSource = GetDataSet(EnderecoList).Tables[0];

                PreencherForm(_endereco);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void PreencherForm(Endereco end)
        {
            txtCEP.Text = end.cep;
            txtCepR.Text = end.cep;
            txtRua.Text = end.rua;
            txtBairro.Text = end.bairro;
            txtCidade.Text = end.cidade;
            txtEstado.Text = end.estado;
            txtUf.Text = end.uf;
            txtComplemento.Text = end.complemento;
        }
    }
}
