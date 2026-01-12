using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace esazienda
{
    /// <summary>
    ///     La finestra principale dell'applicazione. Questa classe gestisce
    ///     la logica delle operazioni CRUD per tutte le entità (Dipendenti,
    ///     Ruoli, Reparti, Turni e Pianificazioni). La parte grafica è
    ///     definita nel file Form1.Designer.cs tramite i controlli Guna
    ///     UI2. Tutte le query sono parametrizzate per evitare injection.
    /// </summary>
    public partial class Form1 : Form
    {
        private readonly string connectionString;

        public Form1()
        {
            InitializeComponent();
            // Configura la stringa di connessione. È consigliato spostarla
            // in un file di configurazione o variabile d'ambiente.
            connectionString = "Server=192.168.103.51;Port=3306;Uid=4IB;Pwd=4ibroot;DataBase=25_26_4IB_GRUPPO_B";

            // Deferisce il caricamento dei dati e delle combo al momento in cui il form
            // viene completamente caricato (evento Load). In questo modo si evita
            // l'uso di controlli non ancora inizializzati, prevenendo eccezioni
            // NullReferenceException.
            this.Load += Form1_Load;
        }

        /// <summary>
        /// Gestisce l'evento di caricamento della form. Qui vengono
        /// popolati i combo box e caricati i dati nelle griglie, una volta
        /// che tutti i controlli sono stati creati dal designer.
        /// </summary>
        private void Form1_Load(object? sender, EventArgs e)
        {
            // Popola i combo box dipendenti, ruoli, reparti e turni.
            LoadRepartiCombo();
            LoadRuoliCombo();
            LoadTurniCombo();
            LoadDipendentiCombo();

            // Carica i dati iniziali delle tabelle.
            LoadDipendentiGrid();
            LoadRuoliGrid();
            LoadRepartiGrid();
            LoadTurniGrid();
            LoadPianificazioniGrid();
        }

        #region Load combos

        private void LoadRepartiCombo()
        {
            try
            {
                using MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                string query = "SELECT ID_Reparto, Nome_Reparto FROM Reparti";
                using MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dipRepartoCombo.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    string display = $"{row["ID_Reparto"]} - {row["Nome_Reparto"]}";
                    dipRepartoCombo.Items.Add(display);
                }
            }
            catch
            {
                // In caso di errore (es. database non raggiungibile), lascia le combo vuote.
            }
        }

        private void LoadRuoliCombo()
        {
            try
            {
                using MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                string query = "SELECT ID_Ruolo, Nome_Ruolo FROM Ruoli";
                using MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dipRuoloCombo.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    string display = $"{row["ID_Ruolo"]} - {row["Nome_Ruolo"]}";
                    dipRuoloCombo.Items.Add(display);
                }
            }
            catch
            {
            }
        }

        private void LoadTurniCombo()
        {
            try
            {
                using MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                string query = "SELECT ID_Turno, Nome_Turno FROM Turni";
                using MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                pianTurnoCombo.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    string display = $"{row["ID_Turno"]} - {row["Nome_Turno"]}";
                    pianTurnoCombo.Items.Add(display);
                }
            }
            catch
            {
            }
        }

        private void LoadDipendentiCombo()
        {
            try
            {
                using MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                string query = "SELECT ID_Dipendente, Nome, Cognome FROM Dipendenti";
                using MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                pianDipCombo.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    string display = $"{row["ID_Dipendente"]} - {row["Nome"]} {row["Cognome"]}";
                    pianDipCombo.Items.Add(display);
                }
            }
            catch
            {
            }
        }

        #endregion

        #region Load grids

        private void LoadDipendentiGrid()
        {
            // Carica i dati dei dipendenti dalla base dati. In caso di
            // errore (ad esempio, connessione non disponibile), mostra
            // un messaggio ma non interrompe l'esecuzione.
            try
            {
                using MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                string query = "SELECT ID_Dipendente, Matricola, Nome, Cognome, Email, Telefono, Data_Assunzione, ID_Reparto, ID_Ruolo, Attivo FROM Dipendenti";
                using MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dipGrid.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nel caricamento dei dipendenti: " + ex.Message);
            }
        }

        private void LoadRuoliGrid()
        {
            try
            {
                using MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                string query = "SELECT ID_Ruolo, Nome_Ruolo FROM Ruoli";
                using MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                ruoloGrid.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nel caricamento dei ruoli: " + ex.Message);
            }
        }

        private void LoadRepartiGrid()
        {
            try
            {
                using MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                string query = "SELECT ID_Reparto, Nome_Reparto, Descrizione, Responsabile, Data_Creazione FROM Reparti";
                using MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                repGrid.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nel caricamento dei reparti: " + ex.Message);
            }
        }

        private void LoadTurniGrid()
        {
            try
            {
                using MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                string query = "SELECT ID_Turno, Nome_Turno, Ora_Inizio, Ora_Fine, Descrizione FROM Turni";
                using MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                turnoGrid.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nel caricamento dei turni: " + ex.Message);
            }
        }

        private void LoadPianificazioniGrid()
        {
            try
            {
                using MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                string query = "SELECT ID_Pianificazione, ID_Dipendente, ID_Turno, Data_Turno, Ore_Pianificate, Note, Stato, Data_Creazione FROM Pianificazione_Turni";
                using MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                pianGrid.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nel caricamento delle pianificazioni: " + ex.Message);
            }
        }

        #endregion

        #region Event handlers: Dipendenti

        private void DipInsertButton_Click(object? sender, EventArgs e)
        {
            try
            {
                using MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                string query = "INSERT INTO Dipendenti (ID_Dipendente, Matricola, Nome, Cognome, Email, Telefono, Data_Assunzione, ID_Reparto, ID_Ruolo, Attivo) " +
                               "VALUES (@id, @mat, @nome, @cognome, @mail, @tel, @ass, @reparto, @ruolo, @attivo)";
                using MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", int.Parse(dipIdBox.Text));
                cmd.Parameters.AddWithValue("@mat", dipMatricolaBox.Text);
                cmd.Parameters.AddWithValue("@nome", dipNomeBox.Text);
                cmd.Parameters.AddWithValue("@cognome", dipCognomeBox.Text);
                cmd.Parameters.AddWithValue("@mail", dipEmailBox.Text);
                cmd.Parameters.AddWithValue("@tel", dipTelefonoBox.Text);
                cmd.Parameters.AddWithValue("@ass", dipDataAssunzionePicker.Value.Date);
                if (dipRepartoCombo.SelectedItem != null)
                {
                    string[] parts = dipRepartoCombo.SelectedItem.ToString().Split('-');
                    cmd.Parameters.AddWithValue("@reparto", int.Parse(parts[0].Trim()));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@reparto", DBNull.Value);
                }
                if (dipRuoloCombo.SelectedItem != null)
                {
                    string[] partsR = dipRuoloCombo.SelectedItem.ToString().Split('-');
                    cmd.Parameters.AddWithValue("@ruolo", int.Parse(partsR[0].Trim()));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ruolo", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@attivo", dipAttivoCheck.Checked);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Dipendente inserito con successo.");
                LoadDipendentiGrid();
                LoadDipendentiCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nell'inserimento: " + ex.Message);
            }
        }

        private void DipUpdateButton_Click(object? sender, EventArgs e)
        {
            try
            {
                using MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                string query = "UPDATE Dipendenti SET Matricola=@mat, Nome=@nome, Cognome=@cognome, Email=@mail, Telefono=@tel, Data_Assunzione=@ass, ID_Reparto=@reparto, ID_Ruolo=@ruolo, Attivo=@attivo WHERE ID_Dipendente=@id";
                using MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", int.Parse(dipIdBox.Text));
                cmd.Parameters.AddWithValue("@mat", dipMatricolaBox.Text);
                cmd.Parameters.AddWithValue("@nome", dipNomeBox.Text);
                cmd.Parameters.AddWithValue("@cognome", dipCognomeBox.Text);
                cmd.Parameters.AddWithValue("@mail", dipEmailBox.Text);
                cmd.Parameters.AddWithValue("@tel", dipTelefonoBox.Text);
                cmd.Parameters.AddWithValue("@ass", dipDataAssunzionePicker.Value.Date);
                if (dipRepartoCombo.SelectedItem != null)
                {
                    string[] parts = dipRepartoCombo.SelectedItem.ToString().Split('-');
                    cmd.Parameters.AddWithValue("@reparto", int.Parse(parts[0].Trim()));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@reparto", DBNull.Value);
                }
                if (dipRuoloCombo.SelectedItem != null)
                {
                    string[] partsR = dipRuoloCombo.SelectedItem.ToString().Split('-');
                    cmd.Parameters.AddWithValue("@ruolo", int.Parse(partsR[0].Trim()));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ruolo", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@attivo", dipAttivoCheck.Checked);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                    MessageBox.Show("Dipendente modificato con successo.");
                else
                    MessageBox.Show("Nessun dipendente trovato con l'ID specificato.");
                LoadDipendentiGrid();
                LoadDipendentiCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nella modifica: " + ex.Message);
            }
        }

        private void DipDeleteButton_Click(object? sender, EventArgs e)
        {
            try
            {
                using MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                string query = "DELETE FROM Dipendenti WHERE ID_Dipendente=@id";
                using MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", int.Parse(dipIdBox.Text));
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                    MessageBox.Show("Dipendente cancellato con successo.");
                else
                    MessageBox.Show("Nessun dipendente trovato con l'ID specificato.");
                LoadDipendentiGrid();
                LoadDipendentiCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nella cancellazione: " + ex.Message);
            }
        }

        private void DipLoadButton_Click(object? sender, EventArgs e)
        {
            LoadDipendentiGrid();
        }

        private void DipGrid_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dipGrid.Rows[e.RowIndex];
            dipIdBox.Text = row.Cells["ID_Dipendente"].Value?.ToString();
            dipMatricolaBox.Text = row.Cells["Matricola"].Value?.ToString();
            dipNomeBox.Text = row.Cells["Nome"].Value?.ToString();
            dipCognomeBox.Text = row.Cells["Cognome"].Value?.ToString();
            dipEmailBox.Text = row.Cells["Email"].Value?.ToString();
            dipTelefonoBox.Text = row.Cells["Telefono"].Value?.ToString();
            if (DateTime.TryParse(row.Cells["Data_Assunzione"].Value?.ToString(), out DateTime dt))
                dipDataAssunzionePicker.Value = dt;
            // Set Reparto combo
            if (row.Cells["ID_Reparto"].Value != null)
            {
                string idStr = row.Cells["ID_Reparto"].Value.ToString();
                foreach (var item in dipRepartoCombo.Items)
                {
                    if (item!.ToString()!.StartsWith(idStr + " "))
                    {
                        dipRepartoCombo.SelectedItem = item;
                        break;
                    }
                }
            }
            // Set Ruolo combo
            if (row.Cells["ID_Ruolo"].Value != null)
            {
                string idStr = row.Cells["ID_Ruolo"].Value.ToString();
                foreach (var item in dipRuoloCombo.Items)
                {
                    if (item!.ToString()!.StartsWith(idStr + " "))
                    {
                        dipRuoloCombo.SelectedItem = item;
                        break;
                    }
                }
            }
            dipAttivoCheck.Checked = row.Cells["Attivo"].Value != null && Convert.ToBoolean(row.Cells["Attivo"].Value);
        }

        #endregion

        #region Event handlers: Ruoli

        private void RuoloInsertButton_Click(object? sender, EventArgs e)
        {
            try
            {
                using MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                string query = "INSERT INTO Ruoli (ID_Ruolo, Nome_Ruolo) VALUES (@id, @nome)";
                using MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", int.Parse(ruoloIdBox.Text));
                cmd.Parameters.AddWithValue("@nome", ruoloNomeBox.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ruolo inserito.");
                LoadRuoliGrid();
                LoadRuoliCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore inserimento ruolo: " + ex.Message);
            }
        }

        private void RuoloUpdateButton_Click(object? sender, EventArgs e)
        {
            try
            {
                using MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                string query = "UPDATE Ruoli SET Nome_Ruolo=@nome WHERE ID_Ruolo=@id";
                using MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", int.Parse(ruoloIdBox.Text));
                cmd.Parameters.AddWithValue("@nome", ruoloNomeBox.Text);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                    MessageBox.Show("Ruolo aggiornato.");
                else
                    MessageBox.Show("Nessun ruolo trovato.");
                LoadRuoliGrid();
                LoadRuoliCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore modifica ruolo: " + ex.Message);
            }
        }

        private void RuoloDeleteButton_Click(object? sender, EventArgs e)
        {
            try
            {
                using MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                string query = "DELETE FROM Ruoli WHERE ID_Ruolo=@id";
                using MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", int.Parse(ruoloIdBox.Text));
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                    MessageBox.Show("Ruolo cancellato.");
                else
                    MessageBox.Show("Nessun ruolo trovato.");
                LoadRuoliGrid();
                LoadRuoliCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore cancellazione ruolo: " + ex.Message);
            }
        }

        private void RuoloLoadButton_Click(object? sender, EventArgs e)
        {
            LoadRuoliGrid();
        }

        private void RuoloGrid_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = ruoloGrid.Rows[e.RowIndex];
            ruoloIdBox.Text = row.Cells["ID_Ruolo"].Value?.ToString();
            ruoloNomeBox.Text = row.Cells["Nome_Ruolo"].Value?.ToString();
        }

        #endregion

        #region Event handlers: Reparti

        private void RepInsertButton_Click(object? sender, EventArgs e)
        {
            try
            {
                using MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                string query = "INSERT INTO Reparti (ID_Reparto, Nome_Reparto, Descrizione, Responsabile, Data_Creazione) VALUES (@id, @nome, @desc, @resp, @data)";
                using MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", int.Parse(repIdBox.Text));
                cmd.Parameters.AddWithValue("@nome", repNomeBox.Text);
                cmd.Parameters.AddWithValue("@desc", repDescrBox.Text);
                cmd.Parameters.AddWithValue("@resp", repRespBox.Text);
                cmd.Parameters.AddWithValue("@data", repDataCreazionePicker.Value.Date);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Reparto inserito.");
                LoadRepartiGrid();
                LoadRepartiCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore inserimento reparto: " + ex.Message);
            }
        }

        private void RepUpdateButton_Click(object? sender, EventArgs e)
        {
            try
            {
                using MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                string query = "UPDATE Reparti SET Nome_Reparto=@nome, Descrizione=@desc, Responsabile=@resp, Data_Creazione=@data WHERE ID_Reparto=@id";
                using MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", int.Parse(repIdBox.Text));
                cmd.Parameters.AddWithValue("@nome", repNomeBox.Text);
                cmd.Parameters.AddWithValue("@desc", repDescrBox.Text);
                cmd.Parameters.AddWithValue("@resp", repRespBox.Text);
                cmd.Parameters.AddWithValue("@data", repDataCreazionePicker.Value.Date);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                    MessageBox.Show("Reparto aggiornato.");
                else
                    MessageBox.Show("Nessun reparto trovato.");
                LoadRepartiGrid();
                LoadRepartiCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore modifica reparto: " + ex.Message);
            }
        }

        private void RepDeleteButton_Click(object? sender, EventArgs e)
        {
            try
            {
                using MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                string query = "DELETE FROM Reparti WHERE ID_Reparto=@id";
                using MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", int.Parse(repIdBox.Text));
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                    MessageBox.Show("Reparto cancellato.");
                else
                    MessageBox.Show("Nessun reparto trovato.");
                LoadRepartiGrid();
                LoadRepartiCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore cancellazione reparto: " + ex.Message);
            }
        }

        private void RepLoadButton_Click(object? sender, EventArgs e)
        {
            LoadRepartiGrid();
        }

        private void RepGrid_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = repGrid.Rows[e.RowIndex];
            repIdBox.Text = row.Cells["ID_Reparto"].Value?.ToString();
            repNomeBox.Text = row.Cells["Nome_Reparto"].Value?.ToString();
            repDescrBox.Text = row.Cells["Descrizione"].Value?.ToString();
            repRespBox.Text = row.Cells["Responsabile"].Value?.ToString();
            if (DateTime.TryParse(row.Cells["Data_Creazione"].Value?.ToString(), out DateTime dt))
                repDataCreazionePicker.Value = dt;
        }

        #endregion

        #region Event handlers: Turni

        private void TurnoInsertButton_Click(object? sender, EventArgs e)
        {
            try
            {
                using MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                string query = "INSERT INTO Turni (ID_Turno, Nome_Turno, Ora_Inizio, Ora_Fine, Descrizione) VALUES (@id, @nome, @inizio, @fine, @desc)";
                using MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", int.Parse(turnoIdBox.Text));
                cmd.Parameters.AddWithValue("@nome", turnoNomeBox.Text);
                cmd.Parameters.AddWithValue("@inizio", turnoInizioPicker.Value.ToString("HH:mm:ss"));
                cmd.Parameters.AddWithValue("@fine", turnoFinePicker.Value.ToString("HH:mm:ss"));
                cmd.Parameters.AddWithValue("@desc", turnoDescrBox.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Turno inserito.");
                LoadTurniGrid();
                LoadTurniCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore inserimento turno: " + ex.Message);
            }
        }

        private void TurnoUpdateButton_Click(object? sender, EventArgs e)
        {
            try
            {
                using MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                string query = "UPDATE Turni SET Nome_Turno=@nome, Ora_Inizio=@inizio, Ora_Fine=@fine, Descrizione=@desc WHERE ID_Turno=@id";
                using MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", int.Parse(turnoIdBox.Text));
                cmd.Parameters.AddWithValue("@nome", turnoNomeBox.Text);
                cmd.Parameters.AddWithValue("@inizio", turnoInizioPicker.Value.ToString("HH:mm:ss"));
                cmd.Parameters.AddWithValue("@fine", turnoFinePicker.Value.ToString("HH:mm:ss"));
                cmd.Parameters.AddWithValue("@desc", turnoDescrBox.Text);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                    MessageBox.Show("Turno aggiornato.");
                else
                    MessageBox.Show("Nessun turno trovato.");
                LoadTurniGrid();
                LoadTurniCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore modifica turno: " + ex.Message);
            }
        }

        private void TurnoDeleteButton_Click(object? sender, EventArgs e)
        {
            try
            {
                using MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                string query = "DELETE FROM Turni WHERE ID_Turno=@id";
                using MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", int.Parse(turnoIdBox.Text));
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                    MessageBox.Show("Turno cancellato.");
                else
                    MessageBox.Show("Nessun turno trovato.");
                LoadTurniGrid();
                LoadTurniCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore cancellazione turno: " + ex.Message);
            }
        }

        private void TurnoLoadButton_Click(object? sender, EventArgs e)
        {
            LoadTurniGrid();
        }

        private void TurnoGrid_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = turnoGrid.Rows[e.RowIndex];
            turnoIdBox.Text = row.Cells["ID_Turno"].Value?.ToString();
            turnoNomeBox.Text = row.Cells["Nome_Turno"].Value?.ToString();
            turnoDescrBox.Text = row.Cells["Descrizione"].Value?.ToString();
            if (DateTime.TryParse(row.Cells["Ora_Inizio"].Value?.ToString(), out DateTime start))
                turnoInizioPicker.Value = DateTime.Today.Add(start.TimeOfDay);
            if (DateTime.TryParse(row.Cells["Ora_Fine"].Value?.ToString(), out DateTime end))
                turnoFinePicker.Value = DateTime.Today.Add(end.TimeOfDay);
        }

        #endregion

        #region Event handlers: Pianificazioni

        private void PianInsertButton_Click(object? sender, EventArgs e)
        {
            try
            {
                using MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                string query = "INSERT INTO Pianificazione_Turni (ID_Pianificazione, ID_Dipendente, ID_Turno, Data_Turno, Ore_Pianificate, Note, Stato, Data_Creazione) " +
                               "VALUES (@id, @dip, @turno, @data, @ore, @note, @stato, @creazione)";
                using MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", int.Parse(pianIdBox.Text));
                if (pianDipCombo.SelectedItem != null)
                {
                    string[] parts = pianDipCombo.SelectedItem.ToString().Split('-');
                    cmd.Parameters.AddWithValue("@dip", int.Parse(parts[0].Trim()));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@dip", DBNull.Value);
                }
                if (pianTurnoCombo.SelectedItem != null)
                {
                    string[] partsT = pianTurnoCombo.SelectedItem.ToString().Split('-');
                    cmd.Parameters.AddWithValue("@turno", int.Parse(partsT[0].Trim()));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@turno", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@data", pianDataPicker.Value.Date);
                cmd.Parameters.AddWithValue("@ore", decimal.Parse(pianOreBox.Text));
                cmd.Parameters.AddWithValue("@note", pianNoteBox.Text);
                cmd.Parameters.AddWithValue("@stato", pianStatoCombo.SelectedItem?.ToString() ?? "Pianificato");
                cmd.Parameters.AddWithValue("@creazione", pianDataCreazionePicker.Value.Date);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Pianificazione inserita.");
                LoadPianificazioniGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore inserimento pianificazione: " + ex.Message);
            }
        }

        private void PianUpdateButton_Click(object? sender, EventArgs e)
        {
            try
            {
                using MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                string query = "UPDATE Pianificazione_Turni SET ID_Dipendente=@dip, ID_Turno=@turno, Data_Turno=@data, Ore_Pianificate=@ore, Note=@note, Stato=@stato, Data_Creazione=@creazione WHERE ID_Pianificazione=@id";
                using MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", int.Parse(pianIdBox.Text));
                if (pianDipCombo.SelectedItem != null)
                {
                    string[] parts = pianDipCombo.SelectedItem.ToString().Split('-');
                    cmd.Parameters.AddWithValue("@dip", int.Parse(parts[0].Trim()));
                }
                else
                    cmd.Parameters.AddWithValue("@dip", DBNull.Value);
                if (pianTurnoCombo.SelectedItem != null)
                {
                    string[] partsT = pianTurnoCombo.SelectedItem.ToString().Split('-');
                    cmd.Parameters.AddWithValue("@turno", int.Parse(partsT[0].Trim()));
                }
                else
                    cmd.Parameters.AddWithValue("@turno", DBNull.Value);
                cmd.Parameters.AddWithValue("@data", pianDataPicker.Value.Date);
                cmd.Parameters.AddWithValue("@ore", decimal.Parse(pianOreBox.Text));
                cmd.Parameters.AddWithValue("@note", pianNoteBox.Text);
                cmd.Parameters.AddWithValue("@stato", pianStatoCombo.SelectedItem?.ToString() ?? "Pianificato");
                cmd.Parameters.AddWithValue("@creazione", pianDataCreazionePicker.Value.Date);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                    MessageBox.Show("Pianificazione aggiornata.");
                else
                    MessageBox.Show("Nessuna pianificazione trovata.");
                LoadPianificazioniGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore modifica pianificazione: " + ex.Message);
            }
        }

        private void PianDeleteButton_Click(object? sender, EventArgs e)
        {
            try
            {
                using MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                string query = "DELETE FROM Pianificazione_Turni WHERE ID_Pianificazione=@id";
                using MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", int.Parse(pianIdBox.Text));
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                    MessageBox.Show("Pianificazione cancellata.");
                else
                    MessageBox.Show("Nessuna pianificazione trovata.");
                LoadPianificazioniGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore cancellazione pianificazione: " + ex.Message);
            }
        }

        private void PianLoadButton_Click(object? sender, EventArgs e)
        {
            LoadPianificazioniGrid();
        }

        private void PianGrid_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = pianGrid.Rows[e.RowIndex];
            pianIdBox.Text = row.Cells["ID_Pianificazione"].Value?.ToString();
            // Dipendente
            if (row.Cells["ID_Dipendente"].Value != null)
            {
                string idStr = row.Cells["ID_Dipendente"].Value.ToString();
                foreach (var item in pianDipCombo.Items)
                {
                    if (item!.ToString()!.StartsWith(idStr + " "))
                    {
                        pianDipCombo.SelectedItem = item;
                        break;
                    }
                }
            }
            // Turno
            if (row.Cells["ID_Turno"].Value != null)
            {
                string idStr = row.Cells["ID_Turno"].Value.ToString();
                foreach (var item in pianTurnoCombo.Items)
                {
                    if (item!.ToString()!.StartsWith(idStr + " "))
                    {
                        pianTurnoCombo.SelectedItem = item;
                        break;
                    }
                }
            }
            if (DateTime.TryParse(row.Cells["Data_Turno"].Value?.ToString(), out DateTime dt))
                pianDataPicker.Value = dt;
            pianOreBox.Text = row.Cells["Ore_Pianificate"].Value?.ToString();
            pianNoteBox.Text = row.Cells["Note"].Value?.ToString();
            string stato = row.Cells["Stato"].Value?.ToString() ?? "Pianificato";
            pianStatoCombo.SelectedItem = stato;
            if (DateTime.TryParse(row.Cells["Data_Creazione"].Value?.ToString(), out DateTime dc))
                pianDataCreazionePicker.Value = dc;
        }

        #endregion
    }
}