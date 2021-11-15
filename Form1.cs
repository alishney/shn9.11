using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

using System.Data.SqlClient;

namespace shn9._11
{
    public partial class Form1 : Form
    {

        private SqlConnection sqlConnection = null;
        private SqlCommandBuilder sqlBuilder = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private DataSet dataSet = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Xiaomi\source\repos\shn9.11\shn9.11\Database1.mdf;Integrated Security=True");
            sqlConnection.Open();

            if (sqlConnection.State == ConnectionState.Open)
            {
                MessageBox.Show("Подключение установлено");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {


            SqlCommand command = new SqlCommand($"INSERT INTO [Stat] (ФИО, Должность, Зарплата) VALUES (@ФИО, @Должность, @Зарплата)", sqlConnection);
            

            command.Parameters.AddWithValue("ФИО", textBox1.Text);
            command.Parameters.AddWithValue("Должность", textBox2.Text);
            command.Parameters.AddWithValue("Зарплата", textBox3.Text);

            MessageBox.Show(command.ExecuteNonQuery().ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
