using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusteriDefteri
{
    public partial class Sparkled : Form
    {
        public Sparkled()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataSet ds = DBislemleri.ulkeleriCek();
            comboBoxCountry.DisplayMember = "UlkeAdi";
            comboBoxCountry.ValueMember = "UlkeID";
            comboBoxCountry.DataSource = ds.Tables[0];
        }

        private void comboBoxCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ulkeID = (int) comboBoxCountry.SelectedValue;
            DataSet ds2 = DBislemleri.sehirleriCek(ulkeID);
            comboBoxCity.DisplayMember = "Sehir";
            comboBoxCity.ValueMember = "SehirID";
            comboBoxCity.DataSource = ds2.Tables[0];
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string adi = txtName.Text;
            string soyadi = txtSurname.Text;
            string teli = txtPhone.Text;
            int sidi = (int) comboBoxCity.SelectedValue;
            string adri = txtAdres.Text;

            DBislemleri.Addss(adi,soyadi,teli,sidi,adri);

            MessageBox.Show("Successfully Add");
            txtName.Clear();
            txtSurname.Clear();
            txtPhone.Clear();
            txtAdres.Clear();
            comboBoxCountry.SelectedIndex = 212;
            comboBoxCity.SelectedIndex = 33;

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string aranan = txtSearch.Text;
            DataSet sonuclar = DBislemleri.search(aranan);
            dataGridView1.DataSource = sonuclar.Tables[0];

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                int kisiID = (int) dataGridView1.SelectedRows[0].Cells[0].Value;
                txtNameED.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                txtSurnameED.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                txtPhoneED.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                txtAdresED.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                txtCityED.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int kisiID = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                
                string yeniad = txtNameED.Text;
                string yenisoad = txtSurnameED.Text;
                string yenitel = txtPhoneED.Text;
                string yeniadres = txtAdresED.Text;

                DBislemleri.Edit(kisiID,yeniad, yenisoad,yenitel, yeniadres);

                MessageBox.Show("Successfully Edit");
           

            }



        }

        private void btnDElete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int kisiID = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                
                DBislemleri.delete(kisiID);
                MessageBox.Show("Delete successfully");


            }

        }
    }
}
