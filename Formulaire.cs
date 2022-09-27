using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CVgener
{
    public partial class Formulaire : Form
    {
        string image = "";
        public Formulaire()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void buttonAjouter_Click(object sender, EventArgs e)
        {
            if(textBoxAdress.Text!=""&& textBoxAge.Text!="" 
                && textBoxCompétences.Text != "" && textBoxFormation.Text != ""
                && textBoxInformation.Text != "" && textBoxLangue.Text != "" 
                && textBoxNom.Text != "" && textBoxPrenom.Text != "" 
                && textBoxPrenom.Text != "" && textBoxVille.Text != ""&& textBoxPays.Text!=""
                && pictureBox1.Image != null)
            {
                byte[] img = null;
                FileStream fs = new FileStream(image, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);

                string personne= "INSERT INTO Personne(Nom,Prénom,Age,Address,Ville,Pays,Photo,Information)VALUES('"+textBoxNom.Text+"','"+textBoxPrenom.Text+"','"+int.Parse(textBoxAge.Text)+"','"+textBoxAdress.Text+"','"+textBoxVille.Text+ "','"+textBoxPays.Text+"','"+image+"','"+textBoxInformation.Text+"')";
                ADO.SetData(personne);
                DataTable dt=  ADO.GetData("SELECT * FROM Personne ");
                int id=0;
                foreach (DataRow row in dt.Rows)
                {
                    id = int.Parse(row["IdP"].ToString());
                    Program.idU = id;

                }

                string formation= "INSERT INTO Formation(Formation,IdP)VALUES('"+textBoxFormation.Text+"','"+id+"')";
                ADO.SetData(formation);
                string Lang= "INSERT INTO Langue(Langue,IdP)VALUES('"+textBoxLangue.Text+"','"+id+"')";
                ADO.SetData(Lang);
                string Compet= "INSERT INTO Compétences(Compétences,IdP)VALUES('" + textBoxCompétences.Text+"','"+id+"')";
                ADO.SetData(Compet);

                CVrap cv = new CVrap();
                cv.Show();


            }
            else
            {
                MessageBox.Show("veuillez remplir tous les champs");
            }
        }

        private void Formulaire_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "JPG files (*.jpg)|*.jpg|GIF files (*.gif)|*.jpg|All files (*.*)|*.*";
                dlg.Title = "Selectionner votre photo de profile";
                if(dlg.ShowDialog()== DialogResult.OK)
                {
                    image = dlg.FileName.ToString();
                   // MessageBox.Show(image+"");
                    pictureBox1.ImageLocation = image;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonAnnuler_Click(object sender, EventArgs e)
        {
           
                MessageBox.Show("wooork");
          
        }
    }
}
