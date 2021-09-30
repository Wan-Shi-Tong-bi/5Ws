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

namespace PatientManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Patient pat = new Patient
            {
                FirstName = txtFirstName.Text,
                BedWetter = cheBedWetter.Checked,
                Birthday = datBirthday.Value,
                LastName = txtLastName.Text,
                IsMale = btnMale.Checked
            };

            listPatient.Items.Add(pat);
        }

        private void btnRmPatient_Click(object sender, EventArgs e)
        {
            try
            {
                listPatient.Items.RemoveAt(listPatient.SelectedIndex);
            }
            catch (ArgumentOutOfRangeException)
            {

            }

        }

        private void öffnenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = "";
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*|csv files (*.csv)|*.csv";
            if (file.ShowDialog() == DialogResult.OK)
            {
                path = file.FileName;
            }
            else return;

            listPatient.Items.Clear();
            string[] lines = File.ReadAllLines(path);
            

            foreach (string line in lines)
            {
                Patient p;
                Patient.TryParse(line, out p);
                listPatient.Items.Add(p);
            }

        }

        private void speichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = "";
            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*|csv files (*.csv)|*.csv";
            if (file.ShowDialog() == DialogResult.OK)
            {
                path = file.FileName;
            }
            else return;

            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (Patient pat in listPatient.Items)
                    writer.WriteLine(pat.WriteFileString());
                writer.Close();
            }
            
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
