using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace WindowsFormsApplication5
{
    public partial class Form1 : Form
    {
        private readonly Image[] Images =
            new Image[Directory.GetFiles(Directory.GetCurrentDirectory() + @"\Images\").Length];

        private int index;

        public Form1()
        {
            InitializeComponent();
            LoadImages();
            dataGridView1.Font = new Font("Rockwell Nova Cond", 25);
            Load_Excel();
            BackColor = Color.FromArgb(254, 80, 80);


            var column0 = dataGridView1.Columns[0];
            var column1 = dataGridView1.Columns[1];
            var column2 = dataGridView1.Columns[2];

            column0.Width = 800;
            column0.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            column1.Width = 200;
            column1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            column2.Width = 200;
            column2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
            
        }

        public void LoadImages()
        {
            var path = Directory.GetCurrentDirectory() + @"\Images\";
            {
                for (var i = 0; i < Images.Length; i++)
                    Images[i] = Image.FromFile(path + i + ".jpg");
            }
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (++index >= Images.Length)
                index = 0;
            pictureBox1.Image = Images[index];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            pictureBox1.Visible = true;
            tableLayoutPanel1.Visible = false;
            dataGridView1.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            tableLayoutPanel1.Visible = true;
            timer1.Enabled = false;
            pictureBox1.Visible = false;
            
            FirstButton.BackgroundImage = Properties.Resources._1_active;
            SecondButton.BackgroundImage = Properties.Resources._1_inactive;
            ThirdButton.BackgroundImage = Properties.Resources._1_inactive;
            FourthButton.BackgroundImage = Properties.Resources._1_inactive;
            FifthButton.BackgroundImage = Properties.Resources._1_inactive;
        }

      public void Load_Excel()
        {
            DataTable tb = new DataTable();
            var path = Directory.GetCurrentDirectory() + @"\Excel\Prices.xls";
            string ConStr = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + path + "; Extended Properties=\"Excel 8.0;IMEX=1;\"";
            DataSet ds = new DataSet("EXCEL");
            OleDbConnection cn = new OleDbConnection(ConStr);
            cn.Open();
            DataTable schemaTable = cn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            string sheet1 = (string)schemaTable.Rows[0].ItemArray[2];
            string select = String.Format("SELECT * FROM [{0}]", sheet1);
            OleDbDataAdapter ad = new OleDbDataAdapter(select, cn);
            ad.Fill(ds);
            tb = ds.Tables[0];
            cn.Close();
            dataGridView1.DataSource = tb;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            //opf.Filter = "Excel (*.XLS)|*.XLS";
            //opf.ShowDialog();
            DataTable tb = new DataTable();
            string filename = opf.FileName;
            var path = Directory.GetCurrentDirectory() + @"\Excel\Prices.xls";
            string ConStr = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source="+path+"; Extended Properties=\"Excel 8.0;IMEX=1;\"";
            DataSet ds = new DataSet("EXCEL");
            OleDbConnection cn = new OleDbConnection(ConStr);
            cn.Open();
            DataTable schemaTable = cn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            string sheet1 = (string)schemaTable.Rows[0].ItemArray[2];
            string select = String.Format("SELECT * FROM [{0}]", sheet1);
            OleDbDataAdapter ad = new OleDbDataAdapter(select, cn);
            ad.Fill(ds);
            tb = ds.Tables[0];
            cn.Close();
            dataGridView1.DataSource = tb;
            var column0 = dataGridView1.Columns[0];
            var column1 = dataGridView1.Columns[1];
            var column2 = dataGridView1.Columns[2];
            column0.Width = 797;
            column1.Width = 200;
            column2.Width = 200;
            dataGridView1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            dataGridView1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                ((DataGridView) sender).SelectedCells[0].Selected = false;
            }
            catch
            {
                
            }
        }

        private void FirstButton_Click(object sender, EventArgs e)
        {
            /*FirstButton.ForeColor = Color.Black;
            SecondButton.ForeColor = Color.Gray;
            ThirdButton.ForeColor = Color.Gray;
            FourthButton.ForeColor = Color.Gray;
            FifthButton.ForeColor = Color.Gray;*/
            DataTable tb = new DataTable();
            var path = Directory.GetCurrentDirectory() + @"\Excel\Prices.xls";
            string ConStr = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + path + "; Extended Properties=\"Excel 8.0;IMEX=1;\"";
            DataSet ds = new DataSet("EXCEL");
            OleDbConnection cn = new OleDbConnection(ConStr);
            cn.Open();
            DataTable schemaTable = cn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            string sheet1 = (string)schemaTable.Rows[0].ItemArray[2];
            string select = $"SELECT * FROM [{sheet1}]";
            OleDbDataAdapter ad = new OleDbDataAdapter(select, cn);
            ad.Fill(ds);
            tb = ds.Tables[0];
            cn.Close();
            dataGridView1.DataSource = tb;
            FirstButton.BackgroundImage = Properties.Resources._1_active;
            SecondButton.BackgroundImage = Properties.Resources._1_inactive;
            ThirdButton.BackgroundImage = Properties.Resources._1_inactive;
            FourthButton.BackgroundImage = Properties.Resources._1_inactive;
            FifthButton.BackgroundImage = Properties.Resources._1_inactive;
        }
        private void SecondButton_Click(object sender, EventArgs e)
        {
            /*FirstButton.ForeColor = Color.Gray;
            SecondButton.ForeColor = Color.Black;
            ThirdButton.ForeColor = Color.Gray;
            FourthButton.ForeColor = Color.Gray;
            FifthButton.ForeColor = Color.Gray;*/
            DataTable tb = new DataTable();
            var path = Directory.GetCurrentDirectory() + @"\Excel\Prices.xls";
            string ConStr = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + path + "; Extended Properties=\"Excel 8.0;IMEX=1;\"";
            DataSet ds = new DataSet("EXCEL");
            OleDbConnection cn = new OleDbConnection(ConStr);
            cn.Open();
            DataTable schemaTable = cn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            string sheet1 = (string)schemaTable.Rows[1].ItemArray[2];
            string select = $"SELECT * FROM [{sheet1}]";
            OleDbDataAdapter ad = new OleDbDataAdapter(select, cn);
            ad.Fill(ds);
            tb = ds.Tables[0];
            cn.Close();
            dataGridView1.DataSource = tb;
            FirstButton.BackgroundImage = Properties.Resources._1_inactive;
            SecondButton.BackgroundImage = Properties.Resources._1_active;
            ThirdButton.BackgroundImage = Properties.Resources._1_inactive;
            FourthButton.BackgroundImage = Properties.Resources._1_inactive;
            FifthButton.BackgroundImage = Properties.Resources._1_inactive;
        }

        private void ThirdButton_Click(object sender, EventArgs e)
        {
            /*FirstButton.ForeColor = Color.Gray;
            SecondButton.ForeColor = Color.Gray;
            ThirdButton.ForeColor = Color.Black;
            FourthButton.ForeColor = Color.Gray;
            FifthButton.ForeColor = Color.Gray;*/
            DataTable tb = new DataTable();
            var path = Directory.GetCurrentDirectory() + @"\Excel\Prices.xls";
            string ConStr = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + path + "; Extended Properties=\"Excel 8.0;IMEX=1;\"";
            DataSet ds = new DataSet("EXCEL");
            OleDbConnection cn = new OleDbConnection(ConStr);
            cn.Open();
            DataTable schemaTable = cn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            string sheet1 = (string)schemaTable.Rows[2].ItemArray[2];
            string select = $"SELECT * FROM [{sheet1}]";
            OleDbDataAdapter ad = new OleDbDataAdapter(select, cn);
            ad.Fill(ds);
            tb = ds.Tables[0];
            cn.Close();
            dataGridView1.DataSource = tb;
            FirstButton.BackgroundImage = Properties.Resources._1_inactive;
            SecondButton.BackgroundImage = Properties.Resources._1_inactive;
            ThirdButton.BackgroundImage = Properties.Resources._1_active;
            FourthButton.BackgroundImage = Properties.Resources._1_inactive;
            FifthButton.BackgroundImage = Properties.Resources._1_inactive;
        }

        private void FourthButton_Click(object sender, EventArgs e)
        {
            /*FirstButton.ForeColor = Color.Gray;
            SecondButton.ForeColor = Color.Gray;
            ThirdButton.ForeColor = Color.Gray;
            FourthButton.ForeColor = Color.Black;
            FifthButton.ForeColor = Color.Gray;*/
            DataTable tb = new DataTable();
            var path = Directory.GetCurrentDirectory() + @"\Excel\Prices.xls";
            string ConStr = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + path + "; Extended Properties=\"Excel 8.0;IMEX=1;\"";
            DataSet ds = new DataSet("EXCEL");
            OleDbConnection cn = new OleDbConnection(ConStr);
            cn.Open();
            DataTable schemaTable = cn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            string sheet1 = (string)schemaTable.Rows[3].ItemArray[2];
            string select = $"SELECT * FROM [{sheet1}]";
            OleDbDataAdapter ad = new OleDbDataAdapter(select, cn);
            ad.Fill(ds);
            tb = ds.Tables[0];
            cn.Close();
            dataGridView1.DataSource = tb;
            FirstButton.BackgroundImage = Properties.Resources._1_inactive;
            SecondButton.BackgroundImage = Properties.Resources._1_inactive;
            ThirdButton.BackgroundImage = Properties.Resources._1_inactive;
            FourthButton.BackgroundImage = Properties.Resources._1_active;
            FifthButton.BackgroundImage = Properties.Resources._1_inactive;
        }

        private void FifthButton_Click(object sender, EventArgs e)
        {
            /*FirstButton.ForeColor = Color.Gray;
            SecondButton.ForeColor = Color.Gray;
            ThirdButton.ForeColor = Color.Gray;
            FourthButton.ForeColor = Color.Gray;
            FifthButton.ForeColor = Color.Black;*/
            DataTable tb = new DataTable();
            var path = Directory.GetCurrentDirectory() + @"\Excel\Prices.xls";
            string ConStr = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + path + "; Extended Properties=\"Excel 8.0;IMEX=1;\"";
            DataSet ds = new DataSet("EXCEL");
            OleDbConnection cn = new OleDbConnection(ConStr);
            cn.Open();
            DataTable schemaTable = cn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            string sheet1 = (string)schemaTable.Rows[4].ItemArray[2];
            string select = $"SELECT * FROM [{sheet1}]";
            OleDbDataAdapter ad = new OleDbDataAdapter(select, cn);
            ad.Fill(ds);
            tb = ds.Tables[0];
            cn.Close();
            dataGridView1.DataSource = tb;
            FirstButton.BackgroundImage = Properties.Resources._1_inactive;
            SecondButton.BackgroundImage = Properties.Resources._1_inactive;
            ThirdButton.BackgroundImage = Properties.Resources._1_inactive;
            FourthButton.BackgroundImage = Properties.Resources._1_inactive;
            FifthButton.BackgroundImage = Properties.Resources._1_active;
        }

        private void dataGridView1_MouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}