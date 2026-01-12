

using MySql;
using MySql.Data.MySqlClient;
using System.Data;

namespace esazienda
{
    public partial class Form1 : Form
    {


        private string connectionString;
        public Form1()
        {
            InitializeComponent();
            connectionString = "Server=192.168.103.51;Port=3306;Uid=4IB;Pwd=4ibroot;DataBase=25_26_4IB_GRUPPO_B";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int ID_turno)) ;
            string Nome_turno = textBox2.Text;
            string descrizione = textBox3.Text;
            DateTime Ora_inizio = dateTimePicker1.Value;
            DateTime Ora_fINE = dateTimePicker2.Value;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO Turni (ID_Turno, Nome_Turno, Ora_Inizio, Ora_Fine, Descrizione) " +
                              "VALUES (@id, @nome, @inizio, @fine, @desc)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
                    cmd.Parameters.AddWithValue("@nome", textBox2.Text);
                    cmd.Parameters.AddWithValue("@inizio", dateTimePicker1.Value.ToString("HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@fine", dateTimePicker2.Value.ToString("HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@desc", textBox3.Text);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Fatto! Dati salvati.");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "DELETE FROM Turni WHERE ID_Turno = @id";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", int.Parse(textBox5.Text));
                    cmd.ExecuteNonQuery();

                }
            }

            MessageBox.Show($"sono stati cancellati del tipo turni");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int idDaModificare = int.Parse(textBox6.Text);

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Query per modificare il turno
                    string query = @"UPDATE Turni SET 
                            Nome_Turno = @nome,
                            Ora_Inizio = @inizio,
                            Ora_Fine = @fine,
                            Descrizione = @desc
                            WHERE ID_Turno = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idDaModificare);
                        cmd.Parameters.AddWithValue("@nome", textBox7.Text);
                        cmd.Parameters.AddWithValue("@inizio", dateTimePicker3.Value.ToString("HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@fine", dateTimePicker4.Value.ToString("HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@desc", textBox8.Text);

                        int righeModificate = cmd.ExecuteNonQuery();

                        if (righeModificate > 0)
                        {
                            MessageBox.Show("Turno modificato con successo!");
                        }
                        else
                        {
                            MessageBox.Show("Nessun turno trovato con questo ID");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM Turni";

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
            }

            MessageBox.Show($"Caricati {dataGridView1.RowCount - 1} turni");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Prendi la riga cliccata
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            // Metti i dati nelle textbox
            textBox6.Text = row.Cells["ID_Turno"].Value?.ToString();        // ID
            textBox7.Text = row.Cells["Nome_Turno"].Value?.ToString();     // Nome
            textBox8.Text = row.Cells["Descrizione"].Value?.ToString();    // Descrizione

            // Per le ore (se sono stringhe)
            string oraInizio = row.Cells["Ora_Inizio"].Value?.ToString();
            string oraFine = row.Cells["Ora_Fine"].Value?.ToString();

            if (!string.IsNullOrEmpty(oraInizio) && DateTime.TryParse(oraInizio, out DateTime dtInizio))
                dateTimePicker3.Value = dtInizio;

            if (!string.IsNullOrEmpty(oraFine) && DateTime.TryParse(oraFine, out DateTime dtFine))
                dateTimePicker4.Value = dtFine;

            // Vai alla tabPage3
            tabControl1.SelectedTab = tabPage2;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex < 0) return;

            //// Prendi l'ID dalla prima colonna
            //string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value?.ToString();

            //if (!string.IsNullOrEmpty(id))
            //{
            //    // Metti l'ID nella textBox1
            //    textBox1.Text = id;

            //    // Vai alla tabPage3
            //    tabControl1.SelectedTab = tabPage2;
            //}
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
