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
    public partial class İnfo : Form
    {
        SqlServerCustomerDal _sqlServerCustomerDal = new SqlServerCustomerDal();
        public İnfo()
        {
            InitializeComponent();
        }
        Form1 _frm1;
        Form2 _frm2;
        int _sayac;
        private void İnfo_Load(object sender, EventArgs e)
        {
            tbxModelName.Text = _sqlServerCustomerDal.GetById(GetByİd.Id).ModelAd;
            tbxModelColor.Text = _sqlServerCustomerDal.GetById(GetByİd.Id).ModelRenk;
            tbxModelStock.Text = _sqlServerCustomerDal.GetById(GetByİd.Id).ModelStok;
            tbxModelType.Text = _sqlServerCustomerDal.GetById(GetByİd.Id).ModelTür;
            nudModelNumber.Text = _sqlServerCustomerDal.GetById(GetByİd.Id).ModelNumara.ToString();
            tbxBrandName.Text = _sqlServerCustomerDal.GetById(GetByİd.Id).ModelAd;
            rtbxModelDescription.Text = _sqlServerCustomerDal.GetById(GetByİd.Id).ModelAciklama;
            byte[] photoarrays = _sqlServerCustomerDal.GetById(GetByİd.Id).ModelFotograf;
            pbImage.Image = byteArrayToImage(photoarrays);
            label1.Text = _sqlServerCustomerDal.GetById(GetByİd.Id).MarkaAd;
            byte[] logoarrays = _sqlServerCustomerDal.GetById(GetByİd.Id).MarkaLogo;
            pbLogo1.Image = byteArrayToImage(logoarrays);
            pbLogo2.Image = byteArrayToImage(logoarrays);
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        private void pictureBox10_MouseMove(object sender, MouseEventArgs e)
        {
            Image img = pbImage.Image;
            int imgZoomWidth = pbImage.Width;
            int imgZoomHeight = pbImage.Height;
            if (pbImage.Image != null)
            {
                if (img.Width <= (e.X + imgZoomWidth))
                {
                    imgZoomWidth = img.Width - e.X;
                }
                if (img.Height <= (e.Y + imgZoomHeight))
                {
                    imgZoomHeight = img.Height - e.Y;
                }
                Rectangle rec = new Rectangle(e.X, e.Y, imgZoomWidth, imgZoomHeight);
                pbImageZoom.Image = cropImage(img, rec);
            }
        }
        private Image cropImage(Image img, Rectangle rec)
        {
            Bitmap bmpImage = new Bitmap(img);
            Bitmap bmpCrop = bmpImage.Clone(rec, bmpImage.PixelFormat);
            return (Image)bmpCrop;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            _sayac = 1;
            _frm1 = new Form1();
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _frm2 = new Form2();
            _sayac = 2;
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_sayac == 1)
            {
                _frm1.Show();
                _frm1.Left -= 150;
                if (_frm1.Left <= 1000)
                {
                    timer2.Start();
                    timer1.Stop();

                }
            }
            if (_sayac == 2)
            {
                _frm2.Show();
                _frm2.Left -= 150;
                if (_frm2.Left <= 1000)
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
                _frm1.Left += 150;
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
                _frm2.Left += 150;
                if (_frm2.Left <= 650)
                {
                    this.TopMost = false;
                    this.Hide();
                    _frm2.TopMost = true;
                    timer2.Stop();
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
