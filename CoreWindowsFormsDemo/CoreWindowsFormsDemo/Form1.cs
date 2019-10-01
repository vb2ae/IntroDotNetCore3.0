using CoreWindowsFormsDemo.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoreWindowsFormsDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataGridView dgv = new DataGridView();
            dgv.Dock = DockStyle.Fill;
            this.Controls.Add(dgv);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

            dgv.Columns.Add(new DataGridViewTextBoxColumn { Width = 50, DataPropertyName = "Id", HeaderText="ID" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Width = 350, DataPropertyName = "Name", HeaderText="Product Name" });
            var priceColumn = new DataGridViewTextBoxColumn {
                Width = 150, 
                DataPropertyName = "Price", 
                HeaderText = "Unit Price" 
            };
            priceColumn.DefaultCellStyle.Format = "C";
            priceColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns.Add(priceColumn);
            SqLiteDataAccess data = new SqLiteDataAccess();

            data.EnsureDatabaseIsCreated();

            dgv.DataSource = data.GetDataFromDB();
        }
    }
}
