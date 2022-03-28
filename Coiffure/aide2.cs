using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Coiffure
{
    public partial class aide2 : Form
    {
        SqlConnection cn;
        string chemin = "";
        public aide2()
        {
            InitializeComponent();
        }

        private void btn_suppression_Click(object sender, EventArgs e)
        {
            pnlsuppression.Visible = true;
            pnlavis.Visible = false;
            StreamReader red = new StreamReader("Appsetting.txt");
            chemin = red.ReadToEnd();

            cn = new SqlConnection(Mylib.DecryptSym(Convert.FromBase64String(chemin), Mylib.cle, Mylib.iv));
           
          if(MessageBox.Show("Etes-vous sure de vouloir supprimer votre compte ? ", "suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
          {
                SqlCommand com = new SqlCommand("delete from client where email like ('" + txtemail.Text + "')");
                com.ExecuteNonQuery();
          
            MessageBox.Show("Suppression avec succee");}
          else
            {
                pnlsuppression.Visible = false;
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_ajouterAvis_Click(object sender, EventArgs e)
        {
            pnlavis.Visible = true;
        }

        private void btn_envoyer_Click(object sender, EventArgs e)
        {
            txt_avis.Text = "Merci d'avoir partager votre avis.";
        }
    }
}
