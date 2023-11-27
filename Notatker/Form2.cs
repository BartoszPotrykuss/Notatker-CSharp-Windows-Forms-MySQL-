using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Notatker
{
    public partial class Form2 : Form
    {
        static string connectionString = "server=127.0.0.1;" +
                                    "user=root;" +
                                    "password=;" +
                                    "database=todowise";
        static MySqlConnection connection = new MySqlConnection(connectionString);
        Note note;
        public Form2(Note note)
        {
            InitializeComponent();
            this.note = note;
            textBox1.Text = note.Subject;
            dateTimePicker1.Value = note.CreationDate;
            richTextBox1.Text = note.Content;
            dateTimePicker2.Value = note.ExpiryDate;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = $"UPDATE `note` SET `Subject` = '{note.Subject}', `Content` = '{note.Content}', `ExpiryDate` = '{note.ExpiryDate:yyyy-MM-dd}' WHERE `note`.`Id` = '{note.Id}';";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Błąd połączenia!", "Uwaga!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            note.Subject = textBox1.Text;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            note.Content = richTextBox1.Text;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            note.ExpiryDate = dateTimePicker2.Value;
        }
    }
}
