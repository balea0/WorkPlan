using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esazienda
{
    internal class sezioni
    {
        public class Pianificazione_Turni
        {
            private int _ID_Pianificazione;
            private Dipendenti _ID_Dipendente;  
            private Turni _ID_Turno;            
            private DateTime _Data_Turno;
            private decimal _Ore_Pianificate;
            private string _Note;
            private string _Stato;
            private DateTime _Data_Creazione;

            static List<int> lid = new List<int>();

            public Pianificazione_Turni(int ID_Pianificazione, Dipendenti ID_Dipendente, Turni ID_Turno,
                                        DateTime Data_Turno, decimal Ore_Pianificate, string Note,
                                        string Stato, DateTime Data_Creazione)
            {
                if (lid.Contains(ID_Pianificazione))
                {
                    throw new Exception("Non può esistere due ID pianificazioni uguali");
                }
                lid.Add(ID_Pianificazione);

                _ID_Pianificazione = ID_Pianificazione;
                this.ID_Dipendente = ID_Dipendente;
                this.ID_Turno = ID_Turno;
                this.Data_Turno = Data_Turno;
                this.Ore_Pianificate = Ore_Pianificate;
                this.Note = Note;
                this.Stato = Stato;
                this.Data_Creazione = Data_Creazione;

                
               
            }

            public int ID_Pianificazione
            {
                get => _ID_Pianificazione;
            }

            
            public Dipendenti ID_Dipendente
            {
                get => _ID_Dipendente;

                set
                {
                    if (value == null)
                    {
                        throw new Exception("Il dipendente non può essere nullo");
                    }


                    if (_ID_Dipendente != null)
                    {
                        _ID_Dipendente.Pianificazioni.Remove(this);
                    }

                    _ID_Dipendente = value;


                }
            }

            
            public Turni ID_Turno
            {
                get => _ID_Turno;

                set
                {
                    if (value == null)
                    {
                        throw new Exception("Il turno non può essere nullo");
                    }
                    _ID_Turno = value;
                }
            }

            public DateTime Data_Turno
            {
                get => _Data_Turno;

                set
                {
                    if (value == DateTime.MinValue)
                    {
                        throw new Exception("La data del turno non può essere vuota");
                    }

                    if (value < DateTime.Today.AddYears(-1))
                    {
                        throw new Exception("La data del turno non può essere più vecchia di un anno");
                    }

                    _Data_Turno = value;
                }
            }

            public decimal Ore_Pianificate
            {
                get => _Ore_Pianificate;

                set
                {
                    if (value <= 0)
                    {
                        throw new Exception("Le ore pianificate devono essere maggiori di zero");
                    }

                    if (value > 24)
                    {
                        throw new Exception("Le ore pianificate non possono superare 24 ore");
                    }

                    if (value != Math.Round(value, 2))
                    {
                        throw new Exception("Le ore pianificate devono avere al massimo 2 decimali");
                    }

                    _Ore_Pianificate = value;
                }
            }

            public string Note
            {
                get => _Note;

                set
                {
                    if (value?.Length > 65535)
                    {
                        throw new Exception("Le note non possono superare la lunghezza massima consentita");
                    }
                    _Note = value ?? string.Empty;
                }
            }

            public string Stato
            {
                get => _Stato;

                set
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        throw new Exception("Lo stato non può essere vuoto");
                    }

                    string[] statiValidi = { "Pianificato", "In Corso", "Completato", "Cancellato" };

                    if (!statiValidi.Contains(value))
                    {
                        throw new Exception($"Lo stato deve essere uno dei seguenti: {string.Join(", ", statiValidi)}");
                    }

                    _Stato = value;
                }
            }

            public DateTime Data_Creazione
            {
                get => _Data_Creazione;

                set
                {
                    if (value == DateTime.MinValue)
                    {
                        throw new Exception("La data di creazione non può essere vuota");
                    }

                    if (value > DateTime.Now)
                    {
                        throw new Exception("La data di creazione non può essere nel futuro");
                    }

                    _Data_Creazione = value;
                }
            }

           
            public decimal CalcolaOreEffettive()
            {
                if (_ID_Turno == null) return _Ore_Pianificate;

                TimeSpan durata = _ID_Turno.Ora_Fine - _ID_Turno.Ora_Inizio;
                decimal oreTurno = (decimal)durata.TotalHours;

                return Math.Min(oreTurno, _Ore_Pianificate);
            }

            
            public string GetInfoDipendente()
            {
                return _ID_Dipendente?.GetNomeCompleto() ?? "Dipendente non assegnato";
            }

            
            public string GetInfoTurno()
            {
                if (_ID_Turno == null) return "Turno non assegnato";

                return $"{_ID_Turno.Nome_Turno} ({_ID_Turno.Ora_Inizio:HH:mm} - {_ID_Turno.Ora_Fine:HH:mm})";
            }

            
            public bool IsValida()
            {
                return _ID_Dipendente != null &&
                       _ID_Turno != null &&
                       _Stato != "Cancellato" &&
                       _Data_Turno >= DateTime.Today &&
                       _Ore_Pianificate > 0 &&
                       (_ID_Dipendente.Attivo || _Stato == "Completato");
            }

          
            

            public override string ToString()
            {
                return $"Pianificazione_Turni [ID={_ID_Pianificazione}, " +
                       $"Dipendente={GetInfoDipendente()}, " +
                       $"Turno={(_ID_Turno?.Nome_Turno ?? "N/D")}, " +
                       $"Data={_Data_Turno:dd/MM/yyyy}, Stato={_Stato}]";
            }
        }

        
        public class Dipendenti
        {
            private int _ID_Dipendente;
            private string _Matricola;
            private string _Nome;
            private string _Cognome;
            private string _Email;
            private string _Telefono;
            private DateTime? _Data_Assunzione;
            private Reparti _ID_Reparto;  
            private Ruoli _ID_Ruolo;      
            private bool _Attivo;

            private List<Pianificazione_Turni> _Pianificazioni;

            static List<int> lid = new List<int>();
            static List<string> matricole = new List<string>();
            static List<string> emails = new List<string>();

            public Dipendenti(int ID_Dipendente, string Matricola, string Nome, string Cognome,
                              string Email, string Telefono, DateTime? Data_Assunzione,
                              Reparti ID_Reparto, Ruoli ID_Ruolo, bool Attivo)
            {
                if (lid.Contains(ID_Dipendente))
                {
                    throw new Exception("Non può esistere due ID dipendenti uguali");
                }

                if (matricole.Contains(Matricola))
                {
                    throw new Exception("La matricola deve essere univoca");
                }

                if (!string.IsNullOrEmpty(Email) && emails.Contains(Email))
                {
                    throw new Exception("L'email deve essere univoca");
                }

                lid.Add(ID_Dipendente);
                matricole.Add(Matricola);
                if (!string.IsNullOrEmpty(Email)) emails.Add(Email);

                _ID_Dipendente = ID_Dipendente;
                this.Matricola = Matricola;
                this.Nome = Nome;
                this.Cognome = Cognome;
                this.Email = Email;
                this.Telefono = Telefono;
                this.Data_Assunzione = Data_Assunzione;
                this.ID_Reparto = ID_Reparto;
                this.ID_Ruolo = ID_Ruolo;
                this.Attivo = Attivo;

                _Pianificazioni = new List<Pianificazione_Turni>();
            }

            public int ID_Dipendente
            {
                get => _ID_Dipendente;
            }

            public string Matricola
            {
                get => _Matricola;

                set
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        throw new Exception("La matricola non può essere vuota");
                    }

                    if (value.Length > 20)
                    {
                        throw new Exception("La matricola non può superare 20 caratteri");
                    }

                    if (!matricole.Contains(value) || value == _Matricola)
                    {
                        if (_Matricola != null) matricole.Remove(_Matricola);
                        _Matricola = value;
                        matricole.Add(value);
                    }
                    else
                    {
                        throw new Exception("La matricola deve essere univoca");
                    }
                }
            }

            public string Nome
            {
                get => _Nome;

                set
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        throw new Exception("Il nome non può essere vuoto");
                    }

                    if (value.Length > 100)
                    {
                        throw new Exception("Il nome non può superare 100 caratteri");
                    }

                    _Nome = value;
                }
            }

            public string Cognome
            {
                get => _Cognome;

                set
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        throw new Exception("Il cognome non può essere vuoto");
                    }

                    if (value.Length > 100)
                    {
                        throw new Exception("Il cognome non può superare 100 caratteri");
                    }

                    _Cognome = value;
                }
            }

            public string Email
            {
                get => _Email;

                set
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        if (value.Length > 150)
                        {
                            throw new Exception("L'email non può superare 150 caratteri");
                        }

                        if (!value.Contains("@") || !value.Contains("."))
                        {
                            throw new Exception("Formato email non valido");
                        }

                        if (!emails.Contains(value) || value == _Email)
                        {
                            if (_Email != null) emails.Remove(_Email);
                            _Email = value;
                            emails.Add(value);
                        }
                        else
                        {
                            throw new Exception("L'email deve essere univoca");
                        }
                    }
                    else
                    {
                        _Email = null;
                    }
                }
            }

            public string Telefono
            {
                get => _Telefono;

                set
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        if (value.Length > 20)
                        {
                            throw new Exception("Il telefono non può superare 20 caratteri");
                        }
                    }

                    _Telefono = value;
                }
            }

            public DateTime? Data_Assunzione
            {
                get => _Data_Assunzione;

                set
                {
                    if (value.HasValue && value.Value > DateTime.Today)
                    {
                        throw new Exception("La data di assunzione non può essere nel futuro");
                    }

                    _Data_Assunzione = value;
                }
            }

            
            public Reparti ID_Reparto
            {
                get => _ID_Reparto;

                set
                {
                    _ID_Reparto = value;
                }
            }

           
            public Ruoli ID_Ruolo
            {
                get => _ID_Ruolo;

                set
                {
                    _ID_Ruolo = value;
                }
            }

            public bool Attivo
            {
                get => _Attivo;
                set => _Attivo = value;
            }

            public List<Pianificazione_Turni> Pianificazioni
            {
                get => _Pianificazioni;
            }

            

            public string GetNomeCompleto()
            {
                return $"{_Nome} {_Cognome}";
            }

            public string GetNomeReparto()
            {
                return _ID_Reparto?.Nome_Reparto ?? "Nessun reparto assegnato";
            }

            public string GetNomeRuolo()
            {
                return _ID_Ruolo?.nome_ruolo ?? "Nessun ruolo assegnato";
            }

            public bool IsDisponibilePerData(DateTime data)
            {
                return !_Pianificazioni.Any(p =>
                    p.Data_Turno.Date == data.Date &&
                    p.Stato != "Cancellato");
            }

            public List<Pianificazione_Turni> GetPianificazioniAttive()
            {
                return _Pianificazioni.Where(p => p.IsValida()).ToList();
            }

            public decimal GetOreTotaliPeriodo(DateTime dataInizio, DateTime dataFine)
            {
                return _Pianificazioni
                    .Where(p => p.Data_Turno.Date >= dataInizio.Date &&
                               p.Data_Turno.Date <= dataFine.Date &&
                               p.Stato == "Completato")
                    .Sum(p => p.CalcolaOreEffettive());
            }

           

            public override string ToString()
            {
                return $"Dipendenti [ID={_ID_Dipendente}, Matricola={_Matricola}, " +
                       $"Nome={GetNomeCompleto()}, Reparto={GetNomeReparto()}, " +
                       $"Ruolo={GetNomeRuolo()}, Attivo={_Attivo}]";
            }
        }
        public class Turni
        {
            private int _ID_Turno;
            private string _Nome_Turno;
            private DateTime _Ora_Inizio;
            private DateTime _Ora_Fine;
            private string _Descrizione;
            private string _Colore;

            static List<int> lid = new List<int>();

            public Turni(int ID_Turno, string Nome_Turno, DateTime Ora_Inizio,
                        DateTime Ora_Fine, string Descrizione, string Colore)
            {
                if (lid.Contains(ID_Turno)) { throw new Exception("Non può esistere due ID uguali"); }
                lid.Add(ID_Turno);

                _ID_Turno = ID_Turno;
                this.Nome_Turno = Nome_Turno;
                this.Ora_Inizio = Ora_Inizio;
                this.Ora_Fine = Ora_Fine;
                this.Descrizione = Descrizione;
                this.Colore = Colore;

                if (Ora_Fine < Ora_Inizio)
                {
                    throw new Exception("L'ora di fine non può essere precedente all'ora di inizio");
                }
            }

            public int ID_Turno
            {
                get => _ID_Turno;
            }

            public string Nome_Turno
            {
                get => _Nome_Turno;

                set
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        throw new Exception("Il nome del turno non può essere vuoto");
                    }

                    if (value.Length > 100)
                    {
                        throw new Exception("Il nome del turno non può superare 100 caratteri");
                    }

                    _Nome_Turno = value;
                }
            }

            public DateTime Ora_Inizio
            {
                get => _Ora_Inizio;

                set
                {
                    if (value == DateTime.MinValue)
                    {
                        throw new Exception("L'ora di inizio non può essere vuota");
                    }

                    if (_Ora_Fine != DateTime.MinValue && value > _Ora_Fine)
                    {
                        throw new Exception("L'ora di inizio non può essere successiva all'ora di fine");
                    }

                    _Ora_Inizio = value;
                }
            }

            public DateTime Ora_Fine
            {
                get => _Ora_Fine;

                set
                {
                    if (value == DateTime.MinValue)
                    {
                        throw new Exception("L'ora di fine non può essere vuota");
                    }

                    if (value < _Ora_Inizio)
                    {
                        throw new Exception("L'ora di fine non può essere precedente all'ora di inizio");
                    }

                    _Ora_Fine = value;
                }
            }

            public string Descrizione
            {
                get => _Descrizione;

                set
                {
                    if (value?.Length > 500)
                    {
                        throw new Exception("La descrizione non può superare 500 caratteri");
                    }
                    _Descrizione = value ?? string.Empty;
                }
            }

            public string Colore
            {
                get => _Colore;

                set
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        throw new Exception("Il colore non può essere vuoto");
                    }

                    
                    if (!System.Text.RegularExpressions.Regex.IsMatch(value, "^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$") &&
                        !(new[] { "rosso", "verde", "blu", "giallo", "arancione", "viola" }).Contains(value.ToLower()))
                    {
                        throw new Exception("Il colore deve essere in formato esadecimale (#RRGGBB) o un colore predefinito");
                    }

                    _Colore = value;
                }
            }

           
            public TimeSpan CalcolaDurata()
            {
                return _Ora_Fine - _Ora_Inizio;
            }

            public override string ToString()
            {
                return $"Turni [ID={_ID_Turno}, Nome={_Nome_Turno}, " +
                       $"Orario={_Ora_Inizio:HH:mm}-{_Ora_Fine:HH:mm}]";
            }
        }
        public class Ruoli
        {
            private int _id_ruolo;
            private string _nome_ruolo;

            static List<int> lid = new List<int>();
            static List<string> nomiRuoli = new List<string>();

            public Ruoli(int id_ruolo, string nome_ruolo)
            {
                if (lid.Contains(id_ruolo))
                {
                    throw new Exception("Non può esistere due ID ruolo uguali");
                }

                if (nomiRuoli.Contains(nome_ruolo))
                {
                    throw new Exception("Il nome del ruolo deve essere univoco");
                }

                lid.Add(id_ruolo);
                nomiRuoli.Add(nome_ruolo);

                _id_ruolo = id_ruolo;
                this.nome_ruolo = nome_ruolo;
            }

            public int id_ruolo
            {
                get => _id_ruolo;
            }

            public string nome_ruolo
            {
                get => _nome_ruolo;

                set
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        throw new Exception("Il nome del ruolo non può essere vuoto");
                    }

                    if (value.Length > 100)
                    {
                        throw new Exception("Il nome del ruolo non può superare 100 caratteri");
                    }

                    
                }
            }

            
            public override string ToString()
            {
                return $"Ruoli [ID={_id_ruolo}, Nome={_nome_ruolo}]";
            }

        }

        public class Reparti
        {
            private int _ID_Reparto;
            private string _Nome_Reparto;
            private string _Descrizione;
            private string _Responsabile;
            private DateTime _Data_Creazione;

            static List<int> lid = new List<int>();
            static List<string> nomiReparti = new List<string>();

            public Reparti(int ID_Reparto, string Nome_Reparto, string Descrizione,
                           string Responsabile, DateTime Data_Creazione)
            {
                if (lid.Contains(ID_Reparto))
                {
                    throw new Exception("Non può esistere due ID reparti uguali");
                }

                if (nomiReparti.Contains(Nome_Reparto))
                {
                    throw new Exception("Il nome del reparto deve essere univoco");
                }

                lid.Add(ID_Reparto);
                nomiReparti.Add(Nome_Reparto);

                _ID_Reparto = ID_Reparto;
                this.Nome_Reparto = Nome_Reparto;
                this.Descrizione = Descrizione;
                this.Responsabile = Responsabile;
                this.Data_Creazione = Data_Creazione;
            }

            public int ID_Reparto
            {
                get => _ID_Reparto;
            }

            public string Nome_Reparto
            {
                get => _Nome_Reparto;

                set
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        throw new Exception("Il nome del reparto non può essere vuoto");
                    }

                    if (value.Length > 100)
                    {
                        throw new Exception("Il nome del reparto non può superare 100 caratteri");
                    }

                    if (!nomiReparti.Contains(value) || value == _Nome_Reparto)
                    {
                        if (_Nome_Reparto != null) nomiReparti.Remove(_Nome_Reparto);
                        _Nome_Reparto = value;
                        nomiReparti.Add(value);
                    }
                    else
                    {
                        throw new Exception("Il nome del reparto deve essere univoco");
                    }
                }
            }

            public string Descrizione
            {
                get => _Descrizione;

                set
                {
                    if (value?.Length > 65535)
                    {
                        throw new Exception("La descrizione non può superare la lunghezza massima consentita");
                    }
                    _Descrizione = value ?? string.Empty;
                }
            }

            public string Responsabile
            {
                get => _Responsabile;

                set
                {
                    if (!string.IsNullOrEmpty(value) && value.Length > 100)
                    {
                        throw new Exception("Il nome del responsabile non può superare 100 caratteri");
                    }
                    _Responsabile = value ?? string.Empty;
                }
            }

            public DateTime Data_Creazione
            {
                get => _Data_Creazione;

                set
                {
                    if (value == DateTime.MinValue)
                    {
                        throw new Exception("La data di creazione non può essere vuota");
                    }

                    if (value > DateTime.Now)
                    {
                        throw new Exception("La data di creazione non può essere nel futuro");
                    }

                    _Data_Creazione = value;
                }
            }

            public override string ToString()
            {
                return $"Reparti [ID={_ID_Reparto}, Nome={_Nome_Reparto}, " +
                       $"Responsabile={_Responsabile ?? "N/D"}]";
            }
        }



    }
}

