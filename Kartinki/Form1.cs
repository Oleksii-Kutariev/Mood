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
	public partial class Form1 : Form
	{	
		const int N = 6;

		public Form1()
		{
			InitializeComponent();
		}
		void Styling()
		{
			this.dataGridView1.DefaultCellStyle.Font = new Font("Arial Black", 12 , FontStyle.Bold);
			this.dataGridView1.GridColor = Color.Black;
			this.dataGridView1.RowsDefaultCellStyle.Font = new Font("Arial Black", 15, FontStyle.Bold);
			this.dataGridView1.RowTemplate.Height = 35;
			this.dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial Black", 15, FontStyle.Bold);
		//	this.dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = ContentAlignment.TopCenter;

			//	dataGridView1.BackgroundColor = Color.White;
			dataGridView1.BorderStyle = BorderStyle.None;
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			{
				Styling();
				string[] questions = new string[N];
					questions[0] = "Do you like to smile?";
					questions[1] = "Do you like to have a rest?";
					questions[2] = "Do you like to watch TV?";
					questions[3] = "Do you like to walk with friends?";
					questions[4] = "Do you like to laugh?";
					questions[5] = "Do you like to have a shower?";
				//	questions[6] = "[One more question]";
				//	questions[7] = "[One more question]";
				//  questions[8] = "[One more question]";

				var column1 = new DataGridViewColumn();
				column1.HeaderText = "Questions: ";
				column1.Width = 400;
				//column1.CellTemplate.Style.Font
				column1.ReadOnly = true;
				column1.Name = "name";
				column1.Frozen = true;
				column1.CellTemplate = new DataGridViewTextBoxCell();

				var CheckBox1 = new DataGridViewCheckBoxColumn();
				CheckBox1.HeaderText = "Yes";
				CheckBox1.Name = "Yes";
				CheckBox1.Width = 90;
				//column2.Frozen = false;
				CheckBox1.TrueValue = false;
				CheckBox1.CellTemplate = new DataGridViewCheckBoxCell();

				var CheckBox2 = new DataGridViewCheckBoxColumn();
				CheckBox2.HeaderText = "No";
				CheckBox2.Name = "No";
				CheckBox2.Width = 90;
				//column3.Frozen = true;
				CheckBox2.CellTemplate = new DataGridViewCheckBoxCell();

				var CheckBox3 = new DataGridViewCheckBoxColumn();
				CheckBox3.HeaderText = "I don't know";
				CheckBox3.Name = "Idk";
				CheckBox3.Width = 175;
				//column4.Frozen = true;
				CheckBox3.CellTemplate = new DataGridViewCheckBoxCell();

				dataGridView1.Columns.Add(column1);
				dataGridView1.Columns.Add(CheckBox1);
				dataGridView1.Columns.Add(CheckBox2); 
				dataGridView1.Columns.Add(CheckBox3);

				dataGridView1.AllowUserToAddRows = false;
				for (int i = 0; i < N; i++)
					dataGridView1.Rows.Add(questions[i], true, false, false);	
			}
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			
		}

		private void result_button_Click(object sender, EventArgs e)
		{
			int Key = 0;
			int intKey = 0;
			for (int i = 0; i < dataGridView1.Rows.Count; i++)
			{
				bool isCellCheckedY = (bool)dataGridView1.Rows[i].Cells["Yes"].Value;
				bool isCellCheckedN = (bool)dataGridView1.Rows[i].Cells["No"].Value;
				bool isCellCheckedIdk = (bool)dataGridView1.Rows[i].Cells["Idk"].Value;

				if (isCellCheckedY == true)
				{
					intKey += 2;
				}
				if (isCellCheckedN == true)
				{
					intKey -= 1;
				}
			}
			Key = 0;
			for (int i = 0; i < dataGridView1.Rows.Count; i++)
			{
				bool isCellCheckedY = (bool)dataGridView1.Rows[i].Cells["Yes"].Value;
				bool isCellCheckedN = (bool)dataGridView1.Rows[i].Cells["No"].Value;
				bool isCellCheckedIdk = (bool)dataGridView1.Rows[i].Cells["Idk"].Value;

				if (isCellCheckedY == true)
				{
					if (isCellCheckedIdk != isCellCheckedY)
						if (isCellCheckedIdk == false && isCellCheckedN == false)
							Key += 1;
				}
				else if (isCellCheckedN == true)
				{
					if (isCellCheckedY != isCellCheckedN)
						if (isCellCheckedY == false && isCellCheckedIdk == false)
							Key += 1;
				}
				else if (isCellCheckedIdk == true)
				{
					if (isCellCheckedY != isCellCheckedIdk)
						if (isCellCheckedY == false && isCellCheckedN == false)
							Key += 1;
				}
			}
			if (Key == dataGridView1.Rows.Count)
			{
				f2 form2 = new f2(intKey);
				form2.Show();
			}
			else
				MessageBox.Show("Only 1 answer in one row!");
		}
	}

}
