using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace esazienda
{
    public partial class Form1 : Form
    {
        private IContainer components = null;

        // Tab and pages
        private Guna2TabControl tabControl;
        private TabPage tabDipendenti;
        private TabPage tabRuoli;
        private TabPage tabReparti;
        private TabPage tabTurni;
        private TabPage tabPian;

        // Controls for Dipendenti
        private Panel dipInputPanel;
        private Guna2TextBox dipIdBox;
        private Guna2TextBox dipMatricolaBox;
        private Guna2TextBox dipNomeBox;
        private Guna2TextBox dipCognomeBox;
        private Guna2TextBox dipEmailBox;
        private Guna2TextBox dipTelefonoBox;
        private Guna2DateTimePicker dipDataAssunzionePicker;
        private Guna2ComboBox dipRepartoCombo;
        private Guna2ComboBox dipRuoloCombo;
        private Guna2CheckBox dipAttivoCheck;
        private Guna2Button dipInsertButton;
        private Guna2Button dipUpdateButton;
        private Guna2Button dipDeleteButton;
        private Guna2Button dipLoadButton;
        private Guna2DataGridView dipGrid;

        // Controls for Ruoli
        private Panel ruoloInputPanel;
        private Guna2TextBox ruoloIdBox;
        private Guna2TextBox ruoloNomeBox;
        private Guna2Button ruoloInsertButton;
        private Guna2Button ruoloUpdateButton;
        private Guna2Button ruoloDeleteButton;
        private Guna2Button ruoloLoadButton;
        private Guna2DataGridView ruoloGrid;

        // Controls for Reparti
        private Panel repInputPanel;
        private Guna2TextBox repIdBox;
        private Guna2TextBox repNomeBox;
        private Guna2TextBox repDescrBox;
        private Guna2TextBox repRespBox;
        private Guna2DateTimePicker repDataCreazionePicker;
        private Guna2Button repInsertButton;
        private Guna2Button repUpdateButton;
        private Guna2Button repDeleteButton;
        private Guna2Button repLoadButton;
        private Guna2DataGridView repGrid;

        // Controls for Turni
        private Panel turnoInputPanel;
        private Guna2TextBox turnoIdBox;
        private Guna2TextBox turnoNomeBox;
        private Guna2TextBox turnoDescrBox;
        private Guna2DateTimePicker turnoInizioPicker;
        private Guna2DateTimePicker turnoFinePicker;
        private Guna2Button turnoInsertButton;
        private Guna2Button turnoUpdateButton;
        private Guna2Button turnoDeleteButton;
        private Guna2Button turnoLoadButton;
        private Guna2DataGridView turnoGrid;

        // Controls for Pianificazioni
        private Panel pianInputPanel;
        private Guna2TextBox pianIdBox;
        private Guna2ComboBox pianDipCombo;
        private Guna2ComboBox pianTurnoCombo;
        private Guna2DateTimePicker pianDataPicker;
        private Guna2TextBox pianOreBox;
        private Guna2TextBox pianNoteBox;
        private Guna2ComboBox pianStatoCombo;
        private Guna2DateTimePicker pianDataCreazionePicker;
        private Guna2Button pianInsertButton;
        private Guna2Button pianUpdateButton;
        private Guna2Button pianDeleteButton;
        private Guna2Button pianLoadButton;
        private Guna2DataGridView pianGrid;

        /// <summary>
        /// Dispose any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support.
        /// </summary>
        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Form1));
            tabControl = new Guna2TabControl();
            tabDipendenti = new TabPage();
            tabRuoli = new TabPage();
            tabReparti = new TabPage();
            tabTurni = new TabPage();
            tabPian = new TabPage();
            tabControl.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Alignment = TabAlignment.Left;
            tabControl.Controls.Add(tabDipendenti);
            tabControl.Controls.Add(tabRuoli);
            tabControl.Controls.Add(tabReparti);
            tabControl.Controls.Add(tabTurni);
            tabControl.Controls.Add(tabPian);
            tabControl.Dock = DockStyle.Fill;
            tabControl.ItemSize = new Size(180, 40);
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1100, 600);
            tabControl.TabButtonHoverState.BorderColor = Color.Empty;
            tabControl.TabButtonHoverState.FillColor = Color.LightGray;
            tabControl.TabButtonHoverState.Font = new Font("Segoe UI Semibold", 10F);
            tabControl.TabButtonHoverState.ForeColor = Color.Black;
            tabControl.TabButtonHoverState.InnerColor = Color.FromArgb(40, 52, 70);
            tabControl.TabButtonIdleState.BorderColor = Color.Empty;
            tabControl.TabButtonIdleState.FillColor = Color.White;
            tabControl.TabButtonIdleState.Font = new Font("Segoe UI Semibold", 10F);
            tabControl.TabButtonIdleState.ForeColor = Color.Black;
            tabControl.TabButtonIdleState.InnerColor = Color.FromArgb(33, 42, 57);
            tabControl.TabButtonSelectedState.BorderColor = Color.Empty;
            tabControl.TabButtonSelectedState.FillColor = Color.FromArgb(29, 37, 49);
            tabControl.TabButtonSelectedState.Font = new Font("Segoe UI Semibold", 10F);
            tabControl.TabButtonSelectedState.ForeColor = Color.White;
            tabControl.TabButtonSelectedState.InnerColor = Color.FromArgb(76, 132, 255);
            tabControl.TabButtonSize = new Size(180, 40);
            tabControl.TabIndex = 0;
            tabControl.TabMenuBackColor = Color.FromArgb(33, 42, 57);
            // 
            // tabDipendenti
            // 
            tabDipendenti.Location = new Point(184, 4);
            tabDipendenti.Name = "tabDipendenti";
            tabDipendenti.Size = new Size(912, 592);
            tabDipendenti.TabIndex = 0;
            tabDipendenti.Text = "Dipendenti";
            // 
            // tabRuoli
            // 
            tabRuoli.Location = new Point(184, 4);
            tabRuoli.Name = "tabRuoli";
            tabRuoli.Size = new Size(912, 592);
            tabRuoli.TabIndex = 1;
            tabRuoli.Text = "Ruoli";
            // 
            // tabReparti
            // 
            tabReparti.Location = new Point(184, 4);
            tabReparti.Name = "tabReparti";
            tabReparti.Size = new Size(912, 592);
            tabReparti.TabIndex = 2;
            tabReparti.Text = "Reparti";
            // 
            // tabTurni
            // 
            tabTurni.Location = new Point(184, 4);
            tabTurni.Name = "tabTurni";
            tabTurni.Size = new Size(912, 592);
            tabTurni.TabIndex = 3;
            tabTurni.Text = "Turni";
            // 
            // tabPian
            // 
            tabPian.Location = new Point(184, 4);
            tabPian.Name = "tabPian";
            tabPian.Size = new Size(912, 592);
            tabPian.TabIndex = 4;
            tabPian.Text = "Pianificazioni";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 600);
            Controls.Add(tabControl);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Gestione aziendale";
            tabControl.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void BuildDipendentiTab()
        {
            this.dipInputPanel = new Panel();
            this.dipInputPanel.Dock = DockStyle.Top;
            this.dipInputPanel.Height = 180;

            int x = 10;
            int y = 10;
            int width = 150;
            int height = 30;
            int gapX = 170;

            // ID
            this.dipIdBox = new Guna2TextBox();
            this.dipIdBox.PlaceholderText = "ID Dipendente";
            this.dipIdBox.Location = new Point(x, y);
            this.dipIdBox.Size = new Size(width, height);
            this.dipInputPanel.Controls.Add(this.dipIdBox);

            // Matricola
            this.dipMatricolaBox = new Guna2TextBox();
            this.dipMatricolaBox.PlaceholderText = "Matricola";
            this.dipMatricolaBox.Location = new Point(x + gapX, y);
            this.dipMatricolaBox.Size = new Size(width, height);
            this.dipInputPanel.Controls.Add(this.dipMatricolaBox);

            // Nome
            this.dipNomeBox = new Guna2TextBox();
            this.dipNomeBox.PlaceholderText = "Nome";
            this.dipNomeBox.Location = new Point(x + gapX * 2, y);
            this.dipNomeBox.Size = new Size(width, height);
            this.dipInputPanel.Controls.Add(this.dipNomeBox);

            // Cognome
            this.dipCognomeBox = new Guna2TextBox();
            this.dipCognomeBox.PlaceholderText = "Cognome";
            this.dipCognomeBox.Location = new Point(x + gapX * 3, y);
            this.dipCognomeBox.Size = new Size(width, height);
            this.dipInputPanel.Controls.Add(this.dipCognomeBox);

            // Email
            this.dipEmailBox = new Guna2TextBox();
            this.dipEmailBox.PlaceholderText = "Email";
            this.dipEmailBox.Location = new Point(x, y + 40);
            this.dipEmailBox.Size = new Size(width, height);
            this.dipInputPanel.Controls.Add(this.dipEmailBox);

            // Telefono
            this.dipTelefonoBox = new Guna2TextBox();
            this.dipTelefonoBox.PlaceholderText = "Telefono";
            this.dipTelefonoBox.Location = new Point(x + gapX, y + 40);
            this.dipTelefonoBox.Size = new Size(width, height);
            this.dipInputPanel.Controls.Add(this.dipTelefonoBox);

            // Data Assunzione
            this.dipDataAssunzionePicker = new Guna2DateTimePicker();
            this.dipDataAssunzionePicker.Format = DateTimePickerFormat.Short;
            this.dipDataAssunzionePicker.Location = new Point(x + gapX * 2, y + 40);
            this.dipDataAssunzionePicker.Size = new Size(width, height);
            this.dipInputPanel.Controls.Add(this.dipDataAssunzionePicker);

            // Reparto
            this.dipRepartoCombo = new Guna2ComboBox();
            this.dipRepartoCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            this.dipRepartoCombo.Location = new Point(x + gapX * 3, y + 40);
            this.dipRepartoCombo.Size = new Size(width, height);
            this.dipInputPanel.Controls.Add(this.dipRepartoCombo);

            // Ruolo
            this.dipRuoloCombo = new Guna2ComboBox();
            this.dipRuoloCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            this.dipRuoloCombo.Location = new Point(x, y + 80);
            this.dipRuoloCombo.Size = new Size(width, height);
            this.dipInputPanel.Controls.Add(this.dipRuoloCombo);

            // Attivo
            this.dipAttivoCheck = new Guna2CheckBox();
            this.dipAttivoCheck.Text = "Attivo";
            this.dipAttivoCheck.Location = new Point(x + gapX, y + 80);
            this.dipAttivoCheck.Size = new Size(100, height);
            this.dipInputPanel.Controls.Add(this.dipAttivoCheck);

            // Buttons
            this.dipInsertButton = new Guna2Button();
            this.dipInsertButton.Text = "Inserisci";
            this.dipInsertButton.Location = new Point(x + gapX * 2, y + 80);
            this.dipInsertButton.Size = new Size(100, 30);
            this.dipInsertButton.Click += new EventHandler(this.DipInsertButton_Click);
            this.dipInputPanel.Controls.Add(this.dipInsertButton);

            this.dipUpdateButton = new Guna2Button();
            this.dipUpdateButton.Text = "Modifica";
            this.dipUpdateButton.Location = new Point(x + gapX * 2 + 110, y + 80);
            this.dipUpdateButton.Size = new Size(100, 30);
            this.dipUpdateButton.Click += new EventHandler(this.DipUpdateButton_Click);
            this.dipInputPanel.Controls.Add(this.dipUpdateButton);

            this.dipDeleteButton = new Guna2Button();
            this.dipDeleteButton.Text = "Cancella";
            this.dipDeleteButton.Location = new Point(x + gapX * 2 + 220, y + 80);
            this.dipDeleteButton.Size = new Size(100, 30);
            this.dipDeleteButton.Click += new EventHandler(this.DipDeleteButton_Click);
            this.dipInputPanel.Controls.Add(this.dipDeleteButton);

            this.dipLoadButton = new Guna2Button();
            this.dipLoadButton.Text = "Visualizza";
            this.dipLoadButton.Location = new Point(x + gapX * 2 + 330, y + 80);
            this.dipLoadButton.Size = new Size(100, 30);
            this.dipLoadButton.Click += new EventHandler(this.DipLoadButton_Click);
            this.dipInputPanel.Controls.Add(this.dipLoadButton);

            // DataGridView
            this.dipGrid = new Guna2DataGridView();
            this.dipGrid.Dock = DockStyle.Fill;
            this.dipGrid.ReadOnly = true;
            this.dipGrid.AllowUserToAddRows = false;
            this.dipGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dipGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dipGrid.CellClick += new DataGridViewCellEventHandler(this.DipGrid_CellClick);

            // Add to tab
            this.tabDipendenti.Controls.Add(this.dipGrid);
            this.tabDipendenti.Controls.Add(this.dipInputPanel);
        }

        private void BuildRuoliTab()
        {
            this.ruoloInputPanel = new Panel();
            this.ruoloInputPanel.Dock = DockStyle.Top;
            this.ruoloInputPanel.Height = 120;

            int x = 10;
            int y = 10;
            int width = 150;
            int height = 30;
            int gapX = 170;

            this.ruoloIdBox = new Guna2TextBox();
            this.ruoloIdBox.PlaceholderText = "ID Ruolo";
            this.ruoloIdBox.Location = new Point(x, y);
            this.ruoloIdBox.Size = new Size(width, height);
            this.ruoloInputPanel.Controls.Add(this.ruoloIdBox);

            this.ruoloNomeBox = new Guna2TextBox();
            this.ruoloNomeBox.PlaceholderText = "Nome Ruolo";
            this.ruoloNomeBox.Location = new Point(x + gapX, y);
            this.ruoloNomeBox.Size = new Size(width, height);
            this.ruoloInputPanel.Controls.Add(this.ruoloNomeBox);

            this.ruoloInsertButton = new Guna2Button();
            this.ruoloInsertButton.Text = "Inserisci";
            this.ruoloInsertButton.Location = new Point(x, y + 40);
            this.ruoloInsertButton.Size = new Size(100, 30);
            this.ruoloInsertButton.Click += new EventHandler(this.RuoloInsertButton_Click);
            this.ruoloInputPanel.Controls.Add(this.ruoloInsertButton);

            this.ruoloUpdateButton = new Guna2Button();
            this.ruoloUpdateButton.Text = "Modifica";
            this.ruoloUpdateButton.Location = new Point(x + 110, y + 40);
            this.ruoloUpdateButton.Size = new Size(100, 30);
            this.ruoloUpdateButton.Click += new EventHandler(this.RuoloUpdateButton_Click);
            this.ruoloInputPanel.Controls.Add(this.ruoloUpdateButton);

            this.ruoloDeleteButton = new Guna2Button();
            this.ruoloDeleteButton.Text = "Cancella";
            this.ruoloDeleteButton.Location = new Point(x + 220, y + 40);
            this.ruoloDeleteButton.Size = new Size(100, 30);
            this.ruoloDeleteButton.Click += new EventHandler(this.RuoloDeleteButton_Click);
            this.ruoloInputPanel.Controls.Add(this.ruoloDeleteButton);

            this.ruoloLoadButton = new Guna2Button();
            this.ruoloLoadButton.Text = "Visualizza";
            this.ruoloLoadButton.Location = new Point(x + 330, y + 40);
            this.ruoloLoadButton.Size = new Size(100, 30);
            this.ruoloLoadButton.Click += new EventHandler(this.RuoloLoadButton_Click);
            this.ruoloInputPanel.Controls.Add(this.ruoloLoadButton);

            this.ruoloGrid = new Guna2DataGridView();
            this.ruoloGrid.Dock = DockStyle.Fill;
            this.ruoloGrid.ReadOnly = true;
            this.ruoloGrid.AllowUserToAddRows = false;
            this.ruoloGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.ruoloGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.ruoloGrid.CellClick += new DataGridViewCellEventHandler(this.RuoloGrid_CellClick);

            this.tabRuoli.Controls.Add(this.ruoloGrid);
            this.tabRuoli.Controls.Add(this.ruoloInputPanel);
        }

        private void BuildRepartiTab()
        {
            this.repInputPanel = new Panel();
            this.repInputPanel.Dock = DockStyle.Top;
            this.repInputPanel.Height = 160;

            int x = 10;
            int y = 10;
            int width = 150;
            int height = 30;
            int gapX = 170;

            this.repIdBox = new Guna2TextBox();
            this.repIdBox.PlaceholderText = "ID Reparto";
            this.repIdBox.Location = new Point(x, y);
            this.repIdBox.Size = new Size(width, height);
            this.repInputPanel.Controls.Add(this.repIdBox);

            this.repNomeBox = new Guna2TextBox();
            this.repNomeBox.PlaceholderText = "Nome Reparto";
            this.repNomeBox.Location = new Point(x + gapX, y);
            this.repNomeBox.Size = new Size(width, height);
            this.repInputPanel.Controls.Add(this.repNomeBox);

            this.repDescrBox = new Guna2TextBox();
            this.repDescrBox.PlaceholderText = "Descrizione";
            this.repDescrBox.Location = new Point(x + gapX * 2, y);
            this.repDescrBox.Size = new Size(width, height);
            this.repInputPanel.Controls.Add(this.repDescrBox);

            this.repRespBox = new Guna2TextBox();
            this.repRespBox.PlaceholderText = "Responsabile";
            this.repRespBox.Location = new Point(x, y + 40);
            this.repRespBox.Size = new Size(width, height);
            this.repInputPanel.Controls.Add(this.repRespBox);

            this.repDataCreazionePicker = new Guna2DateTimePicker();
            this.repDataCreazionePicker.Format = DateTimePickerFormat.Short;
            this.repDataCreazionePicker.Location = new Point(x + gapX, y + 40);
            this.repDataCreazionePicker.Size = new Size(width, height);
            this.repInputPanel.Controls.Add(this.repDataCreazionePicker);

            this.repInsertButton = new Guna2Button();
            this.repInsertButton.Text = "Inserisci";
            this.repInsertButton.Location = new Point(x, y + 80);
            this.repInsertButton.Size = new Size(100, 30);
            this.repInsertButton.Click += new EventHandler(this.RepInsertButton_Click);
            this.repInputPanel.Controls.Add(this.repInsertButton);

            this.repUpdateButton = new Guna2Button();
            this.repUpdateButton.Text = "Modifica";
            this.repUpdateButton.Location = new Point(x + 110, y + 80);
            this.repUpdateButton.Size = new Size(100, 30);
            this.repUpdateButton.Click += new EventHandler(this.RepUpdateButton_Click);
            this.repInputPanel.Controls.Add(this.repUpdateButton);

            this.repDeleteButton = new Guna2Button();
            this.repDeleteButton.Text = "Cancella";
            this.repDeleteButton.Location = new Point(x + 220, y + 80);
            this.repDeleteButton.Size = new Size(100, 30);
            this.repDeleteButton.Click += new EventHandler(this.RepDeleteButton_Click);
            this.repInputPanel.Controls.Add(this.repDeleteButton);

            this.repLoadButton = new Guna2Button();
            this.repLoadButton.Text = "Visualizza";
            this.repLoadButton.Location = new Point(x + 330, y + 80);
            this.repLoadButton.Size = new Size(100, 30);
            this.repLoadButton.Click += new EventHandler(this.RepLoadButton_Click);
            this.repInputPanel.Controls.Add(this.repLoadButton);

            this.repGrid = new Guna2DataGridView();
            this.repGrid.Dock = DockStyle.Fill;
            this.repGrid.ReadOnly = true;
            this.repGrid.AllowUserToAddRows = false;
            this.repGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.repGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.repGrid.CellClick += new DataGridViewCellEventHandler(this.RepGrid_CellClick);

            this.tabReparti.Controls.Add(this.repGrid);
            this.tabReparti.Controls.Add(this.repInputPanel);
        }

        private void BuildTurniTab()
        {
            this.turnoInputPanel = new Panel();
            this.turnoInputPanel.Dock = DockStyle.Top;
            this.turnoInputPanel.Height = 140;

            int x = 10;
            int y = 10;
            int width = 150;
            int height = 30;
            int gapX = 170;

            this.turnoIdBox = new Guna2TextBox();
            this.turnoIdBox.PlaceholderText = "ID Turno";
            this.turnoIdBox.Location = new Point(x, y);
            this.turnoIdBox.Size = new Size(width, height);
            this.turnoInputPanel.Controls.Add(this.turnoIdBox);

            this.turnoNomeBox = new Guna2TextBox();
            this.turnoNomeBox.PlaceholderText = "Nome Turno";
            this.turnoNomeBox.Location = new Point(x + gapX, y);
            this.turnoNomeBox.Size = new Size(width, height);
            this.turnoInputPanel.Controls.Add(this.turnoNomeBox);

            this.turnoDescrBox = new Guna2TextBox();
            this.turnoDescrBox.PlaceholderText = "Descrizione";
            this.turnoDescrBox.Location = new Point(x + gapX * 2, y);
            this.turnoDescrBox.Size = new Size(width, height);
            this.turnoInputPanel.Controls.Add(this.turnoDescrBox);

            this.turnoInizioPicker = new Guna2DateTimePicker();
            this.turnoInizioPicker.Format = DateTimePickerFormat.Time;
            this.turnoInizioPicker.ShowUpDown = true;
            this.turnoInizioPicker.Location = new Point(x, y + 40);
            this.turnoInizioPicker.Size = new Size(width, height);
            this.turnoInputPanel.Controls.Add(this.turnoInizioPicker);

            this.turnoFinePicker = new Guna2DateTimePicker();
            this.turnoFinePicker.Format = DateTimePickerFormat.Time;
            this.turnoFinePicker.ShowUpDown = true;
            this.turnoFinePicker.Location = new Point(x + gapX, y + 40);
            this.turnoFinePicker.Size = new Size(width, height);
            this.turnoInputPanel.Controls.Add(this.turnoFinePicker);

            this.turnoInsertButton = new Guna2Button();
            this.turnoInsertButton.Text = "Inserisci";
            this.turnoInsertButton.Location = new Point(x, y + 80);
            this.turnoInsertButton.Size = new Size(100, 30);
            this.turnoInsertButton.Click += new EventHandler(this.TurnoInsertButton_Click);
            this.turnoInputPanel.Controls.Add(this.turnoInsertButton);

            this.turnoUpdateButton = new Guna2Button();
            this.turnoUpdateButton.Text = "Modifica";
            this.turnoUpdateButton.Location = new Point(x + 110, y + 80);
            this.turnoUpdateButton.Size = new Size(100, 30);
            this.turnoUpdateButton.Click += new EventHandler(this.TurnoUpdateButton_Click);
            this.turnoInputPanel.Controls.Add(this.turnoUpdateButton);

            this.turnoDeleteButton = new Guna2Button();
            this.turnoDeleteButton.Text = "Cancella";
            this.turnoDeleteButton.Location = new Point(x + 220, y + 80);
            this.turnoDeleteButton.Size = new Size(100, 30);
            this.turnoDeleteButton.Click += new EventHandler(this.TurnoDeleteButton_Click);
            this.turnoInputPanel.Controls.Add(this.turnoDeleteButton);

            this.turnoLoadButton = new Guna2Button();
            this.turnoLoadButton.Text = "Visualizza";
            this.turnoLoadButton.Location = new Point(x + 330, y + 80);
            this.turnoLoadButton.Size = new Size(100, 30);
            this.turnoLoadButton.Click += new EventHandler(this.TurnoLoadButton_Click);
            this.turnoInputPanel.Controls.Add(this.turnoLoadButton);

            this.turnoGrid = new Guna2DataGridView();
            this.turnoGrid.Dock = DockStyle.Fill;
            this.turnoGrid.ReadOnly = true;
            this.turnoGrid.AllowUserToAddRows = false;
            this.turnoGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.turnoGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.turnoGrid.CellClick += new DataGridViewCellEventHandler(this.TurnoGrid_CellClick);

            this.tabTurni.Controls.Add(this.turnoGrid);
            this.tabTurni.Controls.Add(this.turnoInputPanel);
        }

        private void BuildPianificazioniTab()
        {
            this.pianInputPanel = new Panel();
            this.pianInputPanel.Dock = DockStyle.Top;
            this.pianInputPanel.Height = 200;

            int x = 10;
            int y = 10;
            int width = 150;
            int height = 30;
            int gapX = 170;

            this.pianIdBox = new Guna2TextBox();
            this.pianIdBox.PlaceholderText = "ID Pianificazione";
            this.pianIdBox.Location = new Point(x, y);
            this.pianIdBox.Size = new Size(width, height);
            this.pianInputPanel.Controls.Add(this.pianIdBox);

            this.pianDipCombo = new Guna2ComboBox();
            this.pianDipCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            this.pianDipCombo.Location = new Point(x + gapX, y);
            this.pianDipCombo.Size = new Size(width, height);
            this.pianInputPanel.Controls.Add(this.pianDipCombo);

            this.pianTurnoCombo = new Guna2ComboBox();
            this.pianTurnoCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            this.pianTurnoCombo.Location = new Point(x + gapX * 2, y);
            this.pianTurnoCombo.Size = new Size(width, height);
            this.pianInputPanel.Controls.Add(this.pianTurnoCombo);

            this.pianDataPicker = new Guna2DateTimePicker();
            this.pianDataPicker.Format = DateTimePickerFormat.Short;
            this.pianDataPicker.Location = new Point(x, y + 40);
            this.pianDataPicker.Size = new Size(width, height);
            this.pianInputPanel.Controls.Add(this.pianDataPicker);

            this.pianOreBox = new Guna2TextBox();
            this.pianOreBox.PlaceholderText = "Ore Pianificate";
            this.pianOreBox.Location = new Point(x + gapX, y + 40);
            this.pianOreBox.Size = new Size(width, height);
            this.pianInputPanel.Controls.Add(this.pianOreBox);

            this.pianNoteBox = new Guna2TextBox();
            this.pianNoteBox.PlaceholderText = "Note";
            this.pianNoteBox.Location = new Point(x + gapX * 2, y + 40);
            this.pianNoteBox.Size = new Size(width, height);
            this.pianInputPanel.Controls.Add(this.pianNoteBox);

            this.pianStatoCombo = new Guna2ComboBox();
            this.pianStatoCombo.Items.AddRange(new object[] { "Pianificato", "In Corso", "Completato", "Cancellato" });
            this.pianStatoCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            this.pianStatoCombo.Location = new Point(x, y + 80);
            this.pianStatoCombo.Size = new Size(width, height);
            this.pianInputPanel.Controls.Add(this.pianStatoCombo);

            this.pianDataCreazionePicker = new Guna2DateTimePicker();
            this.pianDataCreazionePicker.Format = DateTimePickerFormat.Short;
            this.pianDataCreazionePicker.Location = new Point(x + gapX, y + 80);
            this.pianDataCreazionePicker.Size = new Size(width, height);
            this.pianInputPanel.Controls.Add(this.pianDataCreazionePicker);

            this.pianInsertButton = new Guna2Button();
            this.pianInsertButton.Text = "Inserisci";
            this.pianInsertButton.Location = new Point(x + gapX * 2, y + 80);
            this.pianInsertButton.Size = new Size(100, 30);
            this.pianInsertButton.Click += new EventHandler(this.PianInsertButton_Click);
            this.pianInputPanel.Controls.Add(this.pianInsertButton);

            this.pianUpdateButton = new Guna2Button();
            this.pianUpdateButton.Text = "Modifica";
            this.pianUpdateButton.Location = new Point(x + gapX * 2 + 110, y + 80);
            this.pianUpdateButton.Size = new Size(100, 30);
            this.pianUpdateButton.Click += new EventHandler(this.PianUpdateButton_Click);
            this.pianInputPanel.Controls.Add(this.pianUpdateButton);

            this.pianDeleteButton = new Guna2Button();
            this.pianDeleteButton.Text = "Cancella";
            this.pianDeleteButton.Location = new Point(x + gapX * 2 + 220, y + 80);
            this.pianDeleteButton.Size = new Size(100, 30);
            this.pianDeleteButton.Click += new EventHandler(this.PianDeleteButton_Click);
            this.pianInputPanel.Controls.Add(this.pianDeleteButton);

            this.pianLoadButton = new Guna2Button();
            this.pianLoadButton.Text = "Visualizza";
            this.pianLoadButton.Location = new Point(x + gapX * 2 + 330, y + 80);
            this.pianLoadButton.Size = new Size(100, 30);
            this.pianLoadButton.Click += new EventHandler(this.PianLoadButton_Click);
            this.pianInputPanel.Controls.Add(this.pianLoadButton);

            this.pianGrid = new Guna2DataGridView();
            this.pianGrid.Dock = DockStyle.Fill;
            this.pianGrid.ReadOnly = true;
            this.pianGrid.AllowUserToAddRows = false;
            this.pianGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.pianGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.pianGrid.CellClick += new DataGridViewCellEventHandler(this.PianGrid_CellClick);

            this.tabPian.Controls.Add(this.pianGrid);
            this.tabPian.Controls.Add(this.pianInputPanel);
        }
    }
}