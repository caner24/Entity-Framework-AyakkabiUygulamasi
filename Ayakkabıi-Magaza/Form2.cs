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

namespace Ayakkabıi_Magaza
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlServerCustomerDal _sqlServerCustomerDal = new SqlServerCustomerDal();

        public void GetAll()
        {
            dataGridView1.DataSource = _sqlServerCustomerDal.GetAll();
        }
        bool _photoResult;
        Form1 _frm1;
        İnfo _info;
        int _sayac;
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Title = "Resim Seçiniz";
                openFileDialog1.Filter = "Jpeg Dosyasi(*.jpg)|*.jpg|Png Dosyasi(*.png)|*.png";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    pbPhoto.Image = Image.FromFile(openFileDialog1.FileName);
                    _photoResult = true;
                }
            }
            catch (Exception)
            {
                throw new Expections("Yanlış bir formatta resim seçtiniz");
            }
        }
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        private void button6_Click_1(object sender, EventArgs e)
        {
            if (_photoResult == true)
            {
                _sqlServerCustomerDal.Add(new Product
                {
                    ModelAd = tbxModelName.Text,
                    ModelRenk = tbxModelColor.Text,
                    ModelStok = tbxModelStock.Text,
                    ModelTür = tbxModelType.Text,
                    ModelNumara = (byte)nudModelNumber.Value,
                    MarkaAd = tbxBrandName.Text,
                    ModelFotograf = imageToByteArray(pbPhoto.Image),
                    ModelAciklama = rtbxModelDescription.Text,
                    MarkaLogo = imageToByteArray(pbLogo.Image)
                });
                GetAll();
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            _sqlServerCustomerDal.Update(new Product
            {
                Modelid = (int)dataGridView1.CurrentRow.Cells[0].Value,
                ModelAd = tbxModelName.Text,
                ModelRenk = tbxModelColor.Text,
                ModelStok = tbxModelStock.Text,
                ModelTür = tbxModelType.Text,
                ModelNumara = (byte)nudModelNumber.Value,
                MarkaAd = tbxBrandName.Text,
                ModelFotograf = imageToByteArray(pbPhoto.Image),
                ModelAciklama = rtbxModelDescription.Text,
                MarkaLogo = imageToByteArray(pbLogo.Image)
            });
            GetAll();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            byte[] photoArrays = (byte[])dataGridView1.CurrentRow.Cells[5].Value;
            Image photo = byteArrayToImage(photoArrays);
            tbxModelName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tbxModelColor.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            tbxModelStock.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            tbxModelType.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            pbPhoto.Image = photo;
            nudModelNumber.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            tbxBrandName.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            rtbxModelDescription.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            byte[] logoArrays = (byte[])dataGridView1.CurrentRow.Cells[9].Value;
            Image logo = byteArrayToImage(logoArrays);
            pbLogo.Image = logo;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            GetAll();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            _sqlServerCustomerDal.Delete(new Product
            {

                Modelid = (int)dataGridView1.CurrentRow.Cells[0].Value
            });
            GetAll();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            _sayac = 1;
            _frm1 = new Form1();
            timer1.Start();
            _frm1 = new Form1();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_sayac == 1)
            {
                _frm1.Show();
                _frm1.Left += 150;
                if (_frm1.Left >= 1000)
                {
                    timer2.Start();
                    timer1.Stop();
                }
            }
            if (_sayac == 2)
            {
                _info.Show();
                _info.Left += 150;
                if (_info.Left >= 1000)
                {
                    timer2.Start();
                    timer1.Stop();
                }
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (_sayac == 1)
            {
                _frm1.Left -= 150;
                if (_frm1.Left <= 650)
                {
                    this.TopMost = false;
                    this.Hide();
                    _frm1.TopMost = true;
                    timer2.Stop();
                }
            }
            if (_sayac == 2)
            {
                _info.Left -= 150;
                if (_info.Left <= 650)
                {
                    this.TopMost = false;
                    this.Hide();
                    _info.TopMost = true;
                    timer2.Stop();
                }
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button9_Click(object sender, EventArgs e)
        {
            var result = _sqlServerCustomerDal.Get(textBox6.Text);
            dataGridView1.DataSource = result;


        }
        private void button4_Click(object sender, EventArgs e)
        {
            _sayac = 3;
            İnfo info = new İnfo();
            info.Show();
            this.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            _sayac = 1;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            _sayac = 2;
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Resim Seçiniz";
            openFileDialog1.Filter = "Jpeg Dosyasi(*.jpg)|*.jpg|Png Dosyasi(*.png)|*.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbLogo.Image = Image.FromFile(openFileDialog1.FileName);
                _photoResult = true;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
