using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ayakkabıi_Magaza
{
    public partial class Form1 : Form
    {
        SqlServerCustomerDal _sqlServerCustomerDal = new SqlServerCustomerDal();
        public Form1()
        {
            InitializeComponent();
        }
        Form2 _frm2;
        İnfo _info;
        int _sayac = 0;
        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _sqlServerCustomerDal.GetAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _frm2 = new Form2();
            _sayac = 1;
            timer1.Start();
        }

        public void timer1_Tick(object sender, EventArgs e)
        {
            if (_sayac == 1)
            {
                _frm2.Show();
                _frm2.Left += 150;
                if (_frm2.Left >= 1000)
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
        public void timer2_Tick(object sender, EventArgs e)
        {
            if (_sayac == 1)
            {
                _frm2.Left -= 150;
                if (_frm2.Left <= 650)
                {
                    this.TopMost = false;
                    this.Hide();
                    _frm2.TopMost = true;
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
        private void button4_Click(object sender, EventArgs e)
        {
            _info = new İnfo();
            _sayac = 2;
            timer1.Start();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GetByİd.Id = (int)dataGridView1.CurrentRow.Cells[0].Value;
            _sayac = 2;
            _info = new İnfo();
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {

        }
    }
}
