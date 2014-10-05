using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using Ookii.Dialogs;

namespace CrediNET
{
    /// <summary>
    /// The Account class
    /// </summary>
    public class Account
    {
        private static CultureInfo culture = new CultureInfo("en-US");
        private string _fp = "";

        /// <summary>
        /// The filepath of the account
        /// </summary>
        public string FilePath
        {
            get { return _fp; }
        }

        private bool _cry = false;

        /// <summary>
        /// The encryption state of the account
        /// </summary>
        public bool Encrypted
        {
            get { return _cry; }
            set { _cry = value; }
        }

        private CurrencyObj _currency;

        /// <summary>
        /// The currency of the account
        /// </summary>
        public CurrencyObj Currency
        {
            get { return _currency; }
            set { _currency = value; }
        }

        /// <summary>
        /// The name of the account
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// The password of the account
        /// </summary>
        private string _pass = "";

        public string Pass
        {
            get { return _pass; }
        }

        /// <summary>
        /// Defines the password and MD5 it.
        /// </summary>
        /// <param name="mdp">Plain password</param>
        public void DefPass(string mdp)
        {
            _pass = MD5.CreateMD5Hash(mdp);
        }

        /// <summary>
        /// Defines an already-MD5ed password
        /// </summary>
        /// <param name="md5">MD5 password</param>
        public void DefPassMd5(string md5)
        {
            _pass = md5;
        }

        /// <summary>
        /// Checks if the given pass is the account's pass
        /// </summary>
        /// <param name="pass">Given plain text pass</param>
        /// <returns>pass is the password</returns>
        public bool CheckPass(string pass)
        {
            if (MD5.CreateMD5Hash(pass) == _pass)
                return true;

            return false;
        }

        private DateTime _crdate;

        /// <summary>
        /// The account's creation date
        /// </summary>
        public DateTime CreationDate
        {
            get { return _crdate; }
        }

        private List<Operation> _ops = new List<Operation>();

        /// <summary>
        /// The operations on the account
        /// </summary>
        public List<Operation> Operations
        {
            get { return _ops; }
        }

        private Dictionary<string, Color> _budgets = new Dictionary<string, Color> { { "alimentaire", Color.White }, { "divers", Color.White }, { "habitat", Color.White }, { "santé", Color.White }, { "salaire", Color.White }, { "voiture", Color.White } };

        /// <summary>
        /// The categories of operations
        /// </summary>
        public Dictionary<string, Color> Budgets
        {
            get { _budgets.OrderBy(x => x.Key); return _budgets; }
            set { _budgets = value; _budgets.OrderBy(x => x.Key); }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Account()
        {
            _crdate = DateTime.Now;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_cd">Creation date</param>
        /// <param name="filepath">Filepath</param>
        public Account(DateTime _cd, string filepath)
        {
            _crdate = _cd;
            _fp = filepath;
        }

        /// <summary>
        /// Changes the account's currency to the given one
        /// </summary>
        /// <param name="d">The given currency</param>
        /// <param name="convert">Convert all the operations to the given currency</param>
        public void ChangeCurrency(CurrencyObj d, bool convert = true)
        {
            if (!convert)
            {
                _currency = d;
            }
            else
            {
                _ops.All(x =>
                {
                    x.Credit = _currency.ToCur(d, (double)x.Credit);
                    x.Debit = _currency.ToCur(d, (double)x.Debit);
                    return true;
                });

                _currency = d;
            }
        }

        /// <summary>
        /// Saves the account
        /// </summary>
        public void Save()
        {
            if (_fp == "")
                return;

            if (!Encrypted)
            {
                ToXml(this, _fp);
            }
            else
            {
                File.WriteAllText(_fp, CryptorEngine.Encrypt(ToXml(this, _fp, false).ToString(), this.Pass, true));
            }
        }

        /// <summary>
        /// Changes the filename and save the account
        /// </summary>
        /// <param name="file">The new filename</param>
        public void SaveAs(string file)
        {
            this.
            _fp = file;
            Save();
        }

        /// <summary>
        /// Loads account from file
        /// </summary>
        /// <param name="fp">File path</param>
        /// <returns>The account from <paramref name="fp"/></returns>
        public static Account FromFile(string fp)
        {
            if (Path.GetExtension(fp) == ".cna")
            {
                return LoadAlt(fp);
            }
            else if (Path.GetExtension(fp) == ".cne")
            {
                var ax = new InputDialog();
                switch (CrediNET.Properties.Settings.Default.Lang.Name)
                {
                    case "de-DE":
                        ax.MainInstruction = "Bitte geben Sie das Passwort des Kontos.";
                        break;

                    case "fr-FR":
                        ax.MainInstruction = "Veuillez saisir le mot de passe associé au compte.";
                        break;

                    default: //case "en-US":
                        ax.MainInstruction = "Please type the account's password below.";
                        break;
                }

                if (ax.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var aeee = FromXmlCode(CryptorEngine.Decrypt(File.ReadAllText(fp), ax.Input, true), fp);
                    aeee.Encrypted = true;
                    return aeee;
                }
            }

            return null;
        }

        #region Sauvegarde

        /// <summary>
        /// Saves the given account to an XML file
        /// </summary>
        /// <param name="cm">Account to save</param>
        /// <param name="filepath">File name</param>
        /// <param name="autosave">Automatically save the file</param>
        /// <returns>The generated XDocument</returns>
        public XDocument ToXml(Account cm, string filepath = "", bool autosave = true)
        {
            var doc = new XDocument(new XElement("Compte",
                    new XElement("Nom", cm.Name),
                    new XElement("CrDate", cm.CreationDate.ToString("dd/MM/yyyy")),
                    new XElement("Devise", cm.Currency.ShortName),
                    new XElement("Passe", cm.Pass),
                    new XElement("Operations",
                        cm.Operations.Select(x => new XElement("Op",
                            new XAttribute("ID", x.ID),
                            new XAttribute("Date", x.Date.ToString("dd/MM/yyyy")),
                            new XAttribute("Comm", x.Commentary),
                            new XAttribute("Cre", x.Credit.ToString(culture.NumberFormat)),
                            new XAttribute("Deb", x.Debit.ToString(culture.NumberFormat)),
                            new XAttribute("Type", x.Type),
                            new XAttribute("Budget", x.Budget),
                            new XAttribute("Mensuel", x.Monthly.ToString())))),
                    new XElement("Budgets",
                        cm.Budgets.Select(y => new XElement("B", new XAttribute("color", ColorTranslator.ToHtml(y.Value)), y.Key)))));

            if (autosave)
                doc.Save(filepath);

            return doc;
        }

        /// <summary>
        /// Gets the account from XML code
        /// </summary>
        /// <param name="xml">XML code</param>
        /// <param name="filepath">Filename</param>
        /// <returns>The account from XML code</returns>
        public static Account FromXmlCode(string xml, string filepath)
        {
            Account cb;

            byte[] encodedString = Encoding.UTF8.GetBytes(xml);

            MemoryStream ms = new MemoryStream(encodedString);
            ms.Flush();
            ms.Position = 0;

            var d = XDocument.Load(ms);

            var c = d.Element("Compte");
            cb = new Account(DateTime.ParseExact(c.Element("CrDate").Value, "dd/MM/yyyy", CultureInfo.InvariantCulture), filepath);
            cb.Name = c.Element("Nom").Value;
            cb.DefPassMd5(c.Element("Passe").Value);
            CurrencyObj dvs = Currencies.All.First(x => x.ShortName == c.Element("Devise").Value);
            cb.ChangeCurrency(dvs, false);

            foreach (XElement a in c.Element("Operations").Nodes())
            {
                Operation op = new Operation(a.Attribute("ID").Value);
                op.Date = DateTime.ParseExact(a.Attribute("Date").Value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                op.Commentary = a.Attribute("Comm").Value;
                op.Credit = decimal.Parse(a.Attribute("Cre").Value, culture.NumberFormat);
                op.Debit = decimal.Parse(a.Attribute("Deb").Value, culture.NumberFormat);
                op.Type = a.Attribute("Type").Value;
                op.Budget = a.Attribute("Budget").Value;
                op.Monthly = bool.Parse(a.Attribute("Mensuel").Value);
                cb.Operations.Add(op);
            }

            cb.Budgets.Clear();
            foreach (XElement b in c.Element("Budgets").Nodes())
            {
                cb.Budgets.Add(b.Value, b.Attribute("color") == null ? Color.White : ColorTranslator.FromHtml(b.Attribute("color").Value));
            }

            return cb;
        }

        /// <summary>
        /// Gets the account from the XML file
        /// </summary>
        /// <param name="filePath">XML filepath</param>
        /// <returns></returns>
        public static Account FromXml(string filePath)
        {
            string xml = File.ReadAllText(filePath);
            return FromXmlCode(xml, filePath);
        }

        #endregion Sauvegarde

        /// <summary>
        /// Loads the account from account file
        /// </summary>
        /// <param name="filePath">Account file</param>
        /// <returns>Account stored in given file</returns>
        private static Account LoadAlt(string filePath)
        {
            try
            {
                var ret = FromXml(filePath);
#if !DEBUG
                var good = false;
                var try_ = 0;
                while (!good && try_ != 3)
                {
                    if (try_ == 3)
                    {
                        ret = null;
                        break;
                    }
                    else
                    {
                        InputDialog g = new InputDialog();
                        switch (CrediNET.Properties.Settings.Default.Lang.Name)
                        {
                            case "de-DE":
                                g.MainInstruction = "Bitte geben Sie das Passwort des Kontos.";
                                break;

                            case "fr-FR":
                                g.MainInstruction = "Veuillez saisir le mot de passe associé au compte.";
                                break;

                            default: //case "en-US":
                                g.MainInstruction = "Please type the account's password below.";
                                break;
                        }
                        if (g.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            var sb = MD5.CreateMD5Hash(g.Input);
                            if (sb.ToLower() == ret.Pass.ToLower())
                            {
                                good = true;
                                break;
                            }

                            try_++;
                        }
                    }
                }
                if (try_ == 3)
                {
                    MessageBox.Show("Vous avez tapé un mauvais mot de passe 3 fois. Veuillez réessayer plus tard.");
                    Application.Exit();
                }
                if(ret != null && try_ != 3)
                {
                    return ret;
                }
#endif

                return ret;
            }
            catch (Exception)
            {
                MessageBox.Show("Une erreur s'est produite lors de l'ouverture du fichier.");
                return null;
            }
        }

        #region Cryptage

        public static byte[] Encrypt(byte[] clearData, byte[] Key, byte[] IV)
        {
            MemoryStream ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();

            alg.Key = Key;
            alg.IV = IV;

            CryptoStream cs = new CryptoStream(ms,
               alg.CreateEncryptor(), CryptoStreamMode.Write);

            cs.Write(clearData, 0, clearData.Length);
            cs.Close();

            byte[] encryptedData = ms.ToArray();

            return encryptedData;
        }

        public static byte[] Decrypt(byte[] cipherData,
                                    byte[] Key, byte[] IV)
        {
            MemoryStream ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();

            alg.Key = Key;
            alg.IV = IV;

            CryptoStream cs = new CryptoStream(ms,
                alg.CreateDecryptor(), CryptoStreamMode.Write);

            cs.Write(cipherData, 0, cipherData.Length);
            cs.Close();

            byte[] decryptedData = ms.ToArray();

            return decryptedData;
        }

        #endregion Cryptage
    }
}