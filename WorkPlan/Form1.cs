using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkPlan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class DatabaseConnection
        {
            // Modifica la connessione al database con il nome corretto
            private static string connString = "Server=192.168.103.51;Port=3306;Database=25_26_4IB_GRUPPO_B;Uid=root;Pwd=4ibroot;";

            // Funzione per ottenere la connessione al database
            public static MySqlConnection GetConnection()
            {
                return new MySqlConnection(connString);
            }

            // Funzione per eseguire una query SQL e restituire i dati in un DataTable
            public static DataTable ExecuteQuery(string query)
            {
                using (var conn = GetConnection())
                {
                    var dataTable = new DataTable();
                    conn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }

            // Funzione per eseguire un comando (ad esempio un INSERT, UPDATE, DELETE)
            public static void ExecuteNonQuery(string query)
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Funzione di test per verificare la connessione al database
        private void TestConnection()
        {
            try
            {
                string query = "SELECT * FROM Dipendenti";
                DataTable result = DatabaseConnection.ExecuteQuery(query);

                dataGridView1.DataSource = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore di connessione: " + ex.Message);
            }
        }

        // Evento di caricamento del form
        private void Form1_Load(object sender, EventArgs e)
        {
            TestConnection();
        }
    }
}
