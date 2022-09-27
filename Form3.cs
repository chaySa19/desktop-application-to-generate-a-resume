using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace CVgener
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string strcn = @"Data Source=DESKTOP-TQL2833\SQLEXPRESS;initial catalog=GestioNCV;Integrated Security=True";


            SqlConnection cn = new SqlConnection(strcn);
            SqlDataAdapter da = new SqlDataAdapter("select * from Personne", cn);
            DataSet1 ds = new DataSet1();
            int result=  da.Fill(ds,"Personne");
            SqlDataAdapter da1 = new SqlDataAdapter("select * from Formation", cn);
            da1.Fill(ds, "Formation");
            
           // DataSet1TableAdapters.PersonneTableAdapter TAEmp = new DataSet1TableAdapters.PersonneTableAdapter();
           //TAEmp.Fill(ds.Personne);
            dataGridView1.DataSource = ds;
        }
    }
}
