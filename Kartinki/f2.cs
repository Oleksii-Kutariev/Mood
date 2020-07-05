using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kartinki
{
	public partial class f2 : Form
	{
		int Key = 0;
		public f2(int key)
		{
			InitializeComponent();
			this.Key = key;
		}

		private void f2_Load(object sender, EventArgs e)
		{
			if (Key > 3)
			{
				pictureBox1.Load("../../Resources/Good.jpg");
				//MessageBox.Show("Good");
			}
			if (Key <= 3 && Key >= 2)
			{
				pictureBox1.Load("../../Resources/love.jpg");
			//	MessageBox.Show("Fall in love");
			}
			if (Key < 2)
			{
				pictureBox1.Load("../../Resources/bad.jpg");
			//	MessageBox.Show("Bad");
			}
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			Key = 0;
			this.Close();
		}
	}
}
