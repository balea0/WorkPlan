using System;
using System.IO;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace esazienda
{
    /// <summary>
    ///     Una semplice finestra per registrare un nuovo utente. Le
    ///     credenziali vengono salvate in un file di testo nella cartella
    ///     Documenti dell'utente, nel formato "username;password" per
    ///     ciascuna riga. Prima di registrare verifica che lo username
    ///     inserito non sia già presente.
    /// </summary>
    public partial class RegistrationForm : Form
    {
        private Guna2TextBox usernameBox;
        private Guna2TextBox passwordBox;
        private Guna2Button registerButton;

        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrationForm));
            usernameBox = new Guna2TextBox();
            passwordBox = new Guna2TextBox();
            registerButton = new Guna2Button();
            SuspendLayout();
            // 
            // usernameBox
            // 
            usernameBox.CustomizableEdges = customizableEdges1;
            usernameBox.DefaultText = "";
            usernameBox.Font = new Font("Segoe UI", 9F);
            usernameBox.Location = new Point(93, 70);
            usernameBox.Name = "usernameBox";
            usernameBox.PasswordChar = '\0';
            usernameBox.PlaceholderText = "Nuovo username";
            usernameBox.SelectedText = "";
            usernameBox.ShadowDecoration.CustomizableEdges = customizableEdges2;
            usernameBox.Size = new Size(250, 36);
            usernameBox.TabIndex = 0;
            // 
            // passwordBox
            // 
            passwordBox.CustomizableEdges = customizableEdges3;
            passwordBox.DefaultText = "";
            passwordBox.Font = new Font("Segoe UI", 9F);
            passwordBox.Location = new Point(93, 120);
            passwordBox.Name = "passwordBox";
            passwordBox.PasswordChar = '●';
            passwordBox.PlaceholderText = "Nuova password";
            passwordBox.SelectedText = "";
            passwordBox.ShadowDecoration.CustomizableEdges = customizableEdges4;
            passwordBox.Size = new Size(250, 36);
            passwordBox.TabIndex = 1;
            passwordBox.UseSystemPasswordChar = true;
            // 
            // registerButton
            // 
            registerButton.CustomizableEdges = customizableEdges5;
            registerButton.Font = new Font("Segoe UI", 9F);
            registerButton.ForeColor = Color.White;
            registerButton.Location = new Point(168, 170);
            registerButton.Name = "registerButton";
            registerButton.ShadowDecoration.CustomizableEdges = customizableEdges6;
            registerButton.Size = new Size(100, 36);
            registerButton.TabIndex = 2;
            registerButton.Text = "Crea account";
            registerButton.Click += RegisterButton_Click;
            // 
            // RegistrationForm
            // 
            ClientSize = new Size(429, 255);
            Controls.Add(usernameBox);
            Controls.Add(passwordBox);
            Controls.Add(registerButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "RegistrationForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Registrazione";
            ResumeLayout(false);
        }

        private void RegisterButton_Click(object? sender, EventArgs e)
        {
            string username = usernameBox.Text.Trim();
            string password = passwordBox.Text.Trim();
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Inserire sia username che password.");
                return;
            }

            try
            {
                string docPath;
                try
                {
                    docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    if (string.IsNullOrWhiteSpace(docPath))
                        docPath = AppDomain.CurrentDomain.BaseDirectory;
                }
                catch
                {
                    docPath = AppDomain.CurrentDomain.BaseDirectory;
                }
                string credPath = Path.Combine(docPath, "esazienda_users.txt");

                // Ensure file exists
                if (!File.Exists(credPath))
                {
                    using (var fs = File.Create(credPath)) { }
                }

                // Check if username already exists
                foreach (var line in File.ReadAllLines(credPath))
                {
                    var parts = line.Split(';');
                    if (parts.Length >= 2 && parts[0] == username)
                    {
                        MessageBox.Show("Username già registrato. Scegli un altro nome.");
                        return;
                    }
                }

                // Append new credentials
                File.AppendAllText(credPath, username + ";" + password + Environment.NewLine);
                MessageBox.Show("Registrazione completata. Ora puoi accedere.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore durante la registrazione: " + ex.Message);
            }
        }
    }
}