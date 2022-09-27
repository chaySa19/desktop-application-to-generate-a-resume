using System;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace CVgener
{
    public partial class CVrap : Form
    {
        public CVrap()
        {
            InitializeComponent();
        }
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
        }

        private void CVrap_Load(object sender, EventArgs e)
        {
            string strcn = @"Data Source=DESKTOP-TQL2833\SQLEXPRESS;initial catalog=GestioNCV;Integrated Security=True";
            SqlConnection cn = new SqlConnection(strcn);
            SqlDataAdapter da = new SqlDataAdapter("select * from Personne", cn);
            DataSet2 ds = new DataSet2();
            da.Fill(ds,"Personne");
            SqlDataAdapter da1 = new SqlDataAdapter("select * from Formation where IdP='" + Program.idU + "'", cn);
            da1.Fill(ds, "Formation");
            SqlDataAdapter da2 = new SqlDataAdapter("select * from Compétences where IdP='" + Program.idU + "'", cn);
            da2.Fill(ds, "Compétences");
            SqlDataAdapter da3 = new SqlDataAdapter("select * from Langue where IdP='" + Program.idU + "'", cn);
            da3.Fill(ds, "Langue");
            CrystalReport3 cr = new CrystalReport3();
            cr.SetDataSource(ds);
            crystalReportViewer1.ReportSource = cr;

        }
    }
}
