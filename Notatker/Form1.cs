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

namespace Notatker
{
    public partial class Form1 : Form
    {
        static string connectionString = "server=127.0.0.1;" +
                                    "user=root;" +
                                    "password=;" +
                                    "database=todowise";
        static MySqlConnection connection = new MySqlConnection(connectionString);
        static string query = "SELECT * FROM note";
        readonly MySqlCommand command = new MySqlCommand(query, connection);
        List<Note> notes = new List<Note>();
        public Form1()
        {
            InitializeComponent();
            try
            {
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        int id = reader.GetInt32("id");
                        string Subject = reader.GetString("Subject");
                        string Content = reader.GetString("Content");
                        DateTime CreationDate = reader.GetDateTime("CreationDate");
                        DateTime ExpiryDate = reader.GetDateTime("ExpiryDate");
                        Note note = new Note(Subject, Content, CreationDate, ExpiryDate, id);
                        notes.Add(note);
                    }
                }
            }
            catch
            {
                Close();
            }
            finally
            {
                connection.Close();
            }
                for (int i = 0; i < notes.Count; i++)
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                         string query = $"DELETE FROM note WHERE `note`.`Id` = {notes[i].Id}";
                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        if (notes[i].ExpiryDate <= DateTime.Now)
                        {
                            try
                            {
                                connection.Open();
                                cmd.ExecuteNonQuery();
                                notes.Remove(notes[i]);
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
                }
            foreach (Note note in notes)
            {
                listBox1.Items.Add(note.Subject);
            }
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            string Subject = textBox1.Text;
            string Content = richTextBox1.Text;
            DateTime CreationDate = dateTimePicker1.Value;
            DateTime ExpiryDate = dateTimePicker2.Value;
            Note note = new Note(Subject, Content, CreationDate, ExpiryDate, notes.Count);
            notes.Add(note);
            listBox1.Items.Add(note.Subject);
            string query = $"INSERT INTO `note` (`Subject`, `Content`, `CreationDate`, `ExpiryDate`, `Id`) VALUES ('{Subject}', '{Content}', '{CreationDate:yyyy-MM-dd}', '{ExpiryDate:yyyy-MM-dd}', {notes.Count});";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
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

        private void button2_Click(object sender, EventArgs e)
        {
            Note note = null;
            for (int i = 0; i < notes.Count; i++)
            {
                if (listBox1.SelectedIndex == i)
                {
                    note = notes[i];
                }
            }
            if (note == null)
            {
                MessageBox.Show("Błąd!");
            }
            Form2 form2 = new Form2(note);
            form2.Show();
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }
    }
}
