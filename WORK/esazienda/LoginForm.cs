using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using Guna.UI2.WinForms;

namespace esazienda
{
    /// <summary>
    /// A simple login form that collects a username and password. Upon a
    /// successful login attempt, it writes the supplied credentials to a
    /// plain‑text file on disk and then launches the main application form.
    /// </summary>
    public partial class LoginForm : Form
    {
        private Guna2TextBox usernameBox;
        private Guna2TextBox passwordBox;
        private Guna2Button loginButton;
        private Guna2Button registerButton;

        public LoginForm()
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            usernameBox = new Guna2TextBox();
            passwordBox = new Guna2TextBox();
            loginButton = new Guna2Button();
            registerButton = new Guna2Button();
            SuspendLayout();
            // 
            // usernameBox
            // 
            usernameBox.CustomizableEdges = customizableEdges1;
            usernameBox.DefaultText = "";
            usernameBox.Font = new Font("Segoe UI", 9F);
            usernameBox.Location = new Point(85, 56);
            usernameBox.Name = "usernameBox";
            usernameBox.PasswordChar = '\0';
            usernameBox.PlaceholderText = "Username";
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
            passwordBox.Location = new Point(85, 106);
            passwordBox.Name = "passwordBox";
            passwordBox.PasswordChar = '●';
            passwordBox.PlaceholderText = "Password";
            passwordBox.SelectedText = "";
            passwordBox.ShadowDecoration.CustomizableEdges = customizableEdges4;
            passwordBox.Size = new Size(250, 36);
            passwordBox.TabIndex = 1;
            passwordBox.UseSystemPasswordChar = true;
            // 
            // loginButton
            // 
            loginButton.CustomizableEdges = customizableEdges5;
            loginButton.Font = new Font("Segoe UI", 9F);
            loginButton.ForeColor = Color.White;
            loginButton.Location = new Point(160, 156);
            loginButton.Name = "loginButton";
            loginButton.ShadowDecoration.CustomizableEdges = customizableEdges6;
            loginButton.Size = new Size(100, 36);
            loginButton.TabIndex = 2;
            loginButton.Text = "Accedi";
            loginButton.Click += LoginButton_Click;
            // 
            // registerButton
            // 
            registerButton.CustomizableEdges = customizableEdges7;
            registerButton.Font = new Font("Segoe UI", 9F);
            registerButton.ForeColor = Color.White;
            registerButton.Location = new Point(160, 196);
            registerButton.Name = "registerButton";
            registerButton.ShadowDecoration.CustomizableEdges = customizableEdges8;
            registerButton.Size = new Size(100, 36);
            registerButton.TabIndex = 3;
            registerButton.Text = "Registrati";
            registerButton.Click += RegisterButton_Click;
            // 
            // LoginForm
            // 
            ClientSize = new Size(429, 265);
            Controls.Add(usernameBox);
            Controls.Add(passwordBox);
            Controls.Add(loginButton);
            Controls.Add(registerButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ResumeLayout(false);
        }

        /// <summary>
        /// Handles the click event for the login button. If both the username
        /// and password fields contain text, the credentials are saved to a
        /// text file in the user's documents folder. After writing the file,
        /// the main application form is opened and the login form closes.
        /// </summary>
        private void LoginButton_Click(object? sender, EventArgs e)
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

                if (!File.Exists(credPath))
                {
                    MessageBox.Show("Nessun utente registrato. Registrati prima di accedere.");
                    return;
                }

                bool found = false;
                foreach (var line in File.ReadAllLines(credPath))
                {
                    var parts = line.Split(';');
                    if (parts.Length >= 2)
                    {
                        if (parts[0] == username && parts[1] == password)
                        {
                            found = true;
                            break;
                        }
                    }
                }

                if (!found)
                {
                    MessageBox.Show("Credenziali non valide. Riprovare o registrarsi.");
                    return;
                }

                // Credentials are valid, open the main form.
                this.Hide();
                using (var main = new Form1())
                {
                    main.ShowDialog();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore durante il login: " + ex.Message);
            }
        }

        /// <summary>
        /// Handles the click event for the register button. Opens the registration
        /// form to allow a new user to create an account.
        /// </summary>
        private void RegisterButton_Click(object? sender, EventArgs e)
        {
            using (var reg = new RegistrationForm())
            {
                reg.ShowDialog();
            }
        }
    }
}