using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;
using CrediNET.Properties;

namespace CrediNET
{
    internal static class CurrencyExtensions
    {
        /// <summary>
        /// Gets the exchange rates of the specified currencies
        /// </summary>
        /// <param name="FromCurrency">First currency</param>
        /// <param name="ToCurrency">Second currency</param>
        /// <returns>The exchange rate from the first currency to the second</returns>
        public static double ExchangeRate(CurrencyObj FromCurrency, CurrencyObj ToCurrency)
        {
            var webrequest = WebRequest.Create("http://www.webservicex.net/CurrencyConvertor.asmx/ConversionRate?FromCurrency=" + FromCurrency.ShortName + "&ToCurrency=" + ToCurrency.ShortName);
            var response = (HttpWebResponse)webrequest.GetResponse();
            var dataStream = response.GetResponseStream();
            // ReSharper disable once AssignNullToNotNullAttribute
            var reader = new StreamReader(dataStream);
            var responseFromServer = reader.ReadToEnd();
            var doc = new XmlDocument();
            doc.LoadXml(responseFromServer);
            var value = double.Parse(doc.InnerText, CultureInfo.InvariantCulture);
            reader.Close();
            dataStream.Close();
            response.Close();
            return value;
        }

        /// <summary>
        /// Convert an amount from a currency to another
        /// </summary>
        /// <param name="b">From this currency</param>
        /// <param name="d">To this currency</param>
        /// <param name="montant">Amount</param>
        /// <returns>Amount in the destination currency</returns>
        public static decimal FromCur(this CurrencyObj b, CurrencyObj d, double montant)
        {
            var rt = ExchangeRate(d, b);
            return (decimal)(montant * rt);
        }

        /// <summary>
        /// Convertit un montant d'une devise vers une autre.
        /// </summary>
        /// <param name="b">From this currency</param>
        /// <param name="d">To this currency</param>
        /// <param name="montant">Amount</param>
        /// <returns>Amount in the destination currency</returns>
        public static decimal ToCur(this CurrencyObj b, CurrencyObj d, double montant)
        {
            var rt = ExchangeRate(b, d);
            return (decimal)(montant * rt);
        }
    }

    public class CurrencyObj
    {
        protected bool Equals(CurrencyObj other)
        {
            return this == other;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_symbol != null ? _symbol.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_name != null ? _name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ _rapp.GetHashCode();
                hashCode = (hashCode * 397) ^ (_sname != null ? _sname.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(CurrencyObj a, CurrencyObj b)
        {
            if (ReferenceEquals(a, b))
                return true;

            if (((object)a == null) || ((object)b == null))
                return false;

            return (a.Name == b.Name) &&
                (Math.Abs(a.RappBase - b.RappBase) < 0) &&
                (a.Symbol == b.Symbol) &&
                (a.ShortName == b.ShortName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((CurrencyObj) obj);
        }

        public static bool operator !=(CurrencyObj a, CurrencyObj b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Symbol of the currency (example : €)
        /// </summary>
        private string _symbol = "";

        public string Symbol
        {
            get { return _symbol; }
        }

        /// <summary>
        /// Long name of the currency
        /// </summary>
        private string _name = "";

        public string Name
        {
            get { return _name + " (" + _sname + ")"; }
        }

        /// <summary>
        /// (for debugging purposes) Exchange rate from this currency to Euro
        /// </summary>
        private double _rapp = -1;

        public double RappBase
        {
            get
            {
                if (Math.Abs(_rapp - (-1)) < 0)
                    return CurrencyExtensions.ExchangeRate(Currencies.Euro, this);
                else
                    return _rapp;
            }
        }

        /// <summary>
        /// Short name (example : EUR, USD)
        /// </summary>
        private string _sname = "";

        public string ShortName
        {
            get { return _sname; }
        }

        public static implicit operator CurrencyObj(string d)
        {
            return Currencies.All.First(x => x.ShortName == d);
        }

        public static explicit operator string(CurrencyObj f)
        {
            return f.ShortName;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public CurrencyObj()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="n">Name</param>
        /// <param name="s">Symbol</param>
        /// <param name="abb">Short name</param>
        /// <param name="rapp">Exchange rate to Euro</param>
        public CurrencyObj(string n, string s, string abb, double rapp = -1)
        {
            _symbol = s;
            _name = n;
            if (Math.Abs(rapp - (-1)) > 0)
                _rapp = rapp;
            _sname = abb;
        }
    }

    public class Currencies
    {
        public static void Init()
        {
            switch (Settings.Default.Lang.Name)
            {
                case "en-US":

                    Euro = new CurrencyObj("Euro", "€", "EUR");
                    US_Dollar = new CurrencyObj("American dollar", "$", "USD");
                    AU_Dollar = new CurrencyObj("Australian dollar", "$", "AUD");
                    CA_Dollar = new CurrencyObj("Canadian dollar", "$", "CAD");
                    CHI_Yuan = new CurrencyObj("Chinese Yuan", "¥", "CNY");
                    JAP_Yen = new CurrencyObj("Japanese Yen", "¥", "JPY");
                    SWI_Franc = new CurrencyObj("Swiss franc", "Fr", "CHF");

                    break;

                default:        //case "fr-FR"

                    Euro = new CurrencyObj("Euro", "€", "EUR");
                    US_Dollar = new CurrencyObj("Dollar américain", "$", "USD");
                    AU_Dollar = new CurrencyObj("Dollar australien", "$", "AUD");
                    CA_Dollar = new CurrencyObj("Dollar canadien", "$", "CAD");
                    CHI_Yuan = new CurrencyObj("Yuan chinois", "¥", "CNY");
                    JAP_Yen = new CurrencyObj("Yen japonais", "¥", "JPY");
                    SWI_Franc = new CurrencyObj("Franc suisse", "Fr", "CHF");

                    break;
            }

            BaseUnit = new CurrencyObj("Base unit", "BU", "BU", 1);

            All = new List<CurrencyObj> { Euro, US_Dollar, AU_Dollar, CA_Dollar, CHI_Yuan, JAP_Yen, SWI_Franc };
        }

        public static List<CurrencyObj> All;

        public static CurrencyObj BaseUnit;
        public static CurrencyObj Euro;
        public static CurrencyObj US_Dollar;
        public static CurrencyObj AU_Dollar;
        public static CurrencyObj CA_Dollar;
        public static CurrencyObj CHI_Yuan;
        public static CurrencyObj JAP_Yen;
        public static CurrencyObj SWI_Franc;
    }
}