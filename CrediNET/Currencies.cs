using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Xml;
using CrediNET.Languages;
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
            var webrequest =
                WebRequest.Create("http://www.webservicex.net/CurrencyConvertor.asmx/ConversionRate?FromCurrency=" +
                                  FromCurrency.ShortName + "&ToCurrency=" + ToCurrency.ShortName);
            var response = (HttpWebResponse) webrequest.GetResponse();
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
            return (decimal) (montant * rt);
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
            return (decimal) (montant * rt);
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

            if (((object) a == null) || ((object) b == null))
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
                    return CurrencyExtensions.ExchangeRate(Currencies.EUR, this);
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
        
        public static List<CurrencyObj> All
        {
            get
            {
                var res = typeof (Currencies)
                    .GetFields(BindingFlags.Public | BindingFlags.Static)
                    .Where(f => f.FieldType == typeof (CurrencyObj))
                    .Select(x => (CurrencyObj) (x.GetValue(null))).ToList();
                res.Remove(Currencies.BaseUnit);
                res.OrderBy(x => x.Name);
                return res;
            }
        }

        public static CurrencyObj BaseUnit;
        


        public static void Init()
        {
            switch (Settings.Default.Lang.Name)
            {
                case "en-US":
                    AFA = new CurrencyObj(en_US.Currency_AFA, "؋", "AFA");
                    ALL = new CurrencyObj(en_US.Currency_ALL, "Lek", "ALL");
                    DZD = new CurrencyObj(en_US.Currency_DZD, "دج", "DZD");
                    ARS = new CurrencyObj(en_US.Currency_ARS, "$", "ARS");
                    AWG = new CurrencyObj(en_US.Currency_AWG, "ƒ", "AWG");
                    AUD = new CurrencyObj(en_US.Currency_AUD, "$", "AUD");
                    BSD = new CurrencyObj(en_US.Currency_BSD, "$", "BSD");
                    BHD = new CurrencyObj(en_US.Currency_BHD, ".د.ب", "BHD");
                    BDT = new CurrencyObj(en_US.Currency_BDT, "৳", "BDT");
                    BBD = new CurrencyObj(en_US.Currency_BBD, "Bds$", "BBD");
                    BZD = new CurrencyObj(en_US.Currency_BZD, "BZ$", "BZD");
                    BMD = new CurrencyObj(en_US.Currency_BMD, "$", "BMD");
                    BTN = new CurrencyObj(en_US.Currency_BTN, "Nu", "BTN");
                    BOB = new CurrencyObj(en_US.Currency_BOB, "Bs", "BOB");
                    BWP = new CurrencyObj(en_US.Currency_BWP, "P", "BWP");
                    BRL = new CurrencyObj(en_US.Currency_BRL, "R$", "BRL");
                    GBP = new CurrencyObj(en_US.Currency_GBP, "£", "GBP");
                    BND = new CurrencyObj(en_US.Currency_BND, "$", "BND");
                    BIF = new CurrencyObj(en_US.Currency_BIF, "Fbu", "BIF");
                    XOF = new CurrencyObj(en_US.Currency_XOF, "CFA", "XOF");
                    XAF = new CurrencyObj(en_US.Currency_XAF, "FCFA", "XAF");
                    KHR = new CurrencyObj(en_US.Currency_KHR, "៛", "KHR");
                    CAD = new CurrencyObj(en_US.Currency_CAD, "$", "CAD");
                    CVE = new CurrencyObj(en_US.Currency_CVE, "$", "CVE");
                    KYD = new CurrencyObj(en_US.Currency_KYD, "$", "KYD");
                    CLP = new CurrencyObj(en_US.Currency_CLP, "$", "CLP");
                    CNY = new CurrencyObj(en_US.Currency_CNY, "¥", "CNY");
                    COP = new CurrencyObj(en_US.Currency_COP, "$", "COP");
                    KMF = new CurrencyObj(en_US.Currency_KMF, "CF", "KMF");
                    CRC = new CurrencyObj(en_US.Currency_CRC, "₡", "CRC");
                    HRK = new CurrencyObj(en_US.Currency_HRK, "kn", "HRK");
                    CUP = new CurrencyObj(en_US.Currency_CUP, "$", "CUP");
                    CYP = new CurrencyObj(en_US.Currency_CYP, "£", "CYP");
                    CZK = new CurrencyObj(en_US.Currency_CZK, "Kč", "CZK");
                    DKK = new CurrencyObj(en_US.Currency_DKK, "kr", "DKK");
                    DJF = new CurrencyObj(en_US.Currency_DJF, "Fdj", "DJF");
                    DOP = new CurrencyObj(en_US.Currency_DOP, "$", "DOP");
                    XCD = new CurrencyObj(en_US.Currency_XCD, "$", "XCD");
                    EGP = new CurrencyObj(en_US.Currency_EGP, "E£", "EGP");
                    SVC = new CurrencyObj(en_US.Currency_SVC, "₡", "SVC");
                    ETB = new CurrencyObj(en_US.Currency_ETB, "ብር", "ETB");
                    EUR = new CurrencyObj(en_US.Currency_EUR, "€", "EUR");
                    FKP = new CurrencyObj(en_US.Currency_FKP, "£", "FKP");
                    GMD = new CurrencyObj(en_US.Currency_GMD, "D", "GMD");
                    GHC = new CurrencyObj(en_US.Currency_GHC, "GH₵", "GHC");
                    GIP = new CurrencyObj(en_US.Currency_GIP, "£", "GIP");
                    GTQ = new CurrencyObj(en_US.Currency_GTQ, "Q", "GTQ");
                    GNF = new CurrencyObj(en_US.Currency_GNF, "FG", "GNF");
                    GYD = new CurrencyObj(en_US.Currency_GYD, "$", "GYD");
                    HTG = new CurrencyObj(en_US.Currency_HTG, "G", "HTG");
                    HNL = new CurrencyObj(en_US.Currency_HNL, "L", "HNL");
                    HKD = new CurrencyObj(en_US.Currency_HKD, "$", "HKD");
                    HUF = new CurrencyObj(en_US.Currency_HUF, "Ft", "HUF");
                    ISK = new CurrencyObj(en_US.Currency_ISK, "kr", "ISK");
                    INR = new CurrencyObj(en_US.Currency_INR, "INR", "INR");
                    IDR = new CurrencyObj(en_US.Currency_IDR, "Rp", "IDR");
                    IQD = new CurrencyObj(en_US.Currency_IQD, "ع.د", "IQD");
                    ILS = new CurrencyObj(en_US.Currency_ILS, "₪", "ILS");
                    JMD = new CurrencyObj(en_US.Currency_JMD, "$", "JMD");
                    JPY = new CurrencyObj(en_US.Currency_JPY, "¥", "JPY");
                    JOD = new CurrencyObj(en_US.Currency_JOD, "JD", "JOD");
                    KZT = new CurrencyObj(en_US.Currency_KZT, "₸", "KZT");
                    KES = new CurrencyObj(en_US.Currency_KES, "KSh", "KES");
                    KRW = new CurrencyObj(en_US.Currency_KRW, "₩", "KRW");
                    KWD = new CurrencyObj(en_US.Currency_KWD, "د.ك", "KWD");
                    LAK = new CurrencyObj(en_US.Currency_LAK, "₭", "LAK");
                    LBP = new CurrencyObj(en_US.Currency_LBP, "ل.ل", "LBP");
                    LSL = new CurrencyObj(en_US.Currency_LSL, "L", "LSL");
                    LRD = new CurrencyObj(en_US.Currency_LRD, "$", "LRD");
                    LYD = new CurrencyObj(en_US.Currency_LYD, "ل.د", "LYD");
                    LTL = new CurrencyObj(en_US.Currency_LTL, "Lt", "LTL");
                    MOP = new CurrencyObj(en_US.Currency_MOP, "MOP$", "MOP");
                    MKD = new CurrencyObj(en_US.Currency_MKD, "ден", "MKD");
                    MWK = new CurrencyObj(en_US.Currency_MWK, "MK", "MWK");
                    MYR = new CurrencyObj(en_US.Currency_MYR, "RM", "MYR");
                    MVR = new CurrencyObj(en_US.Currency_MVR, "Rf", "MVR");
                    MTL = new CurrencyObj(en_US.Currency_MTL, "₤", "MTL");
                    MRO = new CurrencyObj(en_US.Currency_MRO, "UM", "MRO");
                    MUR = new CurrencyObj(en_US.Currency_MUR, "₨", "MUR");
                    MXN = new CurrencyObj(en_US.Currency_MXN, "$", "MXN");
                    MDL = new CurrencyObj(en_US.Currency_MDL, "leu", "MDL");
                    MNT = new CurrencyObj(en_US.Currency_MNT, "₮", "MNT");
                    MAD = new CurrencyObj(en_US.Currency_MAD, "د.م.", "MAD");
                    MZM = new CurrencyObj(en_US.Currency_MZM, "MT", "MZM");
                    MMK = new CurrencyObj(en_US.Currency_MMK, "K", "MMK");
                    NAD = new CurrencyObj(en_US.Currency_NAD, "$", "NAD");
                    NPR = new CurrencyObj(en_US.Currency_NPR, "₨", "NPR");
                    ANG = new CurrencyObj(en_US.Currency_ANG, "Naƒ", "ANG");
                    NZD = new CurrencyObj(en_US.Currency_NZD, "$", "NZD");
                    NIO = new CurrencyObj(en_US.Currency_NIO, "C$", "NIO");
                    NGN = new CurrencyObj(en_US.Currency_NGN, "₦", "NGN");
                    KPW = new CurrencyObj(en_US.Currency_KPW, "₩", "KPW");
                    NOK = new CurrencyObj(en_US.Currency_NOK, "kr", "NOK");
                    OMR = new CurrencyObj(en_US.Currency_OMR, "ر.ع.", "OMR");
                    XPF = new CurrencyObj(en_US.Currency_XPF, "F", "XPF");
                    PKR = new CurrencyObj(en_US.Currency_PKR, "₨", "PKR");
                    PAB = new CurrencyObj(en_US.Currency_PAB, "B", "PAB");
                    PGK = new CurrencyObj(en_US.Currency_PGK, "K", "PGK");
                    PYG = new CurrencyObj(en_US.Currency_PYG, "₲", "PYG");
                    PEN = new CurrencyObj(en_US.Currency_PEN, "S", "PEN");
                    PHP = new CurrencyObj(en_US.Currency_PHP, "$", "PHP");
                    PLN = new CurrencyObj(en_US.Currency_PLN, "zł", "PLN");
                    QAR = new CurrencyObj(en_US.Currency_QAR, "ر.ق", "QAR");
                    ROL = new CurrencyObj(en_US.Currency_ROL, "leu", "ROL");
                    RUB = new CurrencyObj(en_US.Currency_RUB, "₽", "RUB");
                    WST = new CurrencyObj(en_US.Currency_WST, "WS$", "WST");
                    STD = new CurrencyObj(en_US.Currency_STD, "Db", "STD");
                    SAR = new CurrencyObj(en_US.Currency_SAR, "ر.س", "SAR");
                    SCR = new CurrencyObj(en_US.Currency_SCR, "SR", "SCR");
                    SLL = new CurrencyObj(en_US.Currency_SLL, "Le", "SLL");
                    SGD = new CurrencyObj(en_US.Currency_SGD, "$", "SGD");
                    SKK = new CurrencyObj(en_US.Currency_SKK, "Sk", "SKK");
                    SBD = new CurrencyObj(en_US.Currency_SBD, "$", "SBD");
                    SOS = new CurrencyObj(en_US.Currency_SOS, "Sh.So.", "SOS");
                    ZAR = new CurrencyObj(en_US.Currency_ZAR, "R", "ZAR");
                    LKR = new CurrencyObj(en_US.Currency_LKR, "රු", "LKR");
                    SHP = new CurrencyObj(en_US.Currency_SHP, "£", "SHP");
                    SDD = new CurrencyObj(en_US.Currency_SDD, "£Sd", "SDD");
                    SRG = new CurrencyObj(en_US.Currency_SRG, "ƒ", "SRG");
                    SZL = new CurrencyObj(en_US.Currency_SZL, "L", "SZL");
                    SEK = new CurrencyObj(en_US.Currency_SEK, "kr", "SEK");
                    TRY = new CurrencyObj(en_US.Currency_TRY, "₺", "TRY");
                    CHF = new CurrencyObj(en_US.Currency_CHF, "Fr", "CHF");
                    SYP = new CurrencyObj(en_US.Currency_SYP, "£", "SYP");
                    TWD = new CurrencyObj(en_US.Currency_TWD, "$", "TWD");
                    TZS = new CurrencyObj(en_US.Currency_TZS, "x", "TZS");
                    THB = new CurrencyObj(en_US.Currency_THB, "฿", "THB");
                    TOP = new CurrencyObj(en_US.Currency_TOP, "T$", "TOP");
                    TTD = new CurrencyObj(en_US.Currency_TTD, "$", "TTD");
                    TND = new CurrencyObj(en_US.Currency_TND, "د.ت", "TND");
                    USD = new CurrencyObj(en_US.Currency_USD, "$", "USD");
                    AED = new CurrencyObj(en_US.Currency_AED, "د.إ", "AED");
                    UGX = new CurrencyObj(en_US.Currency_UGX, "Ush", "UGX");
                    UAH = new CurrencyObj(en_US.Currency_UAH, "₴", "UAH");
                    UYU = new CurrencyObj(en_US.Currency_UYU, "$", "UYU");
                    VUV = new CurrencyObj(en_US.Currency_VUV, "VT", "VUV");
                    VEB = new CurrencyObj(en_US.Currency_VEB, "Bs", "VEB");
                    VND = new CurrencyObj(en_US.Currency_VND, "₫", "VND");
                    YER = new CurrencyObj(en_US.Currency_YER, "﷼", "YER");
                    ZMK = new CurrencyObj(en_US.Currency_ZMK, "ZMK", "ZMK");
                    ZWD = new CurrencyObj(en_US.Currency_ZWD, "$", "ZWD");
                    break;
                case "de-DE":
                    AFA = new CurrencyObj("Afghani", "؋", "AFA");
                    ALL = new CurrencyObj("Albanischer Lek", "Lek", "ALL");
                    DZD = new CurrencyObj("Algerischer Dinar", "دج", "DZD");
                    ARS = new CurrencyObj("Argentinischer Peso", "$", "ARS");
                    AWG = new CurrencyObj("Aruba-Florin", "ƒ", "AWG");
                    AUD = new CurrencyObj("Australian dollar", "$", "AUD");
                    BSD = new CurrencyObj("Bahamian dollar", "$", "BSD");
                    BHD = new CurrencyObj("Bahraini dinar", ".د.ب", "BHD");
                    BDT = new CurrencyObj("Bangladesh Taka", "৳", "BDT");
                    BBD = new CurrencyObj("Barbadian Dollar", "Bds$", "BBD");
                    BZD = new CurrencyObj("Belize Dollar", "BZ$", "BZD");
                    BMD = new CurrencyObj("Bermuda Dollar", "$", "BMD");
                    BTN = new CurrencyObj("Bhutanese Ngultrum", "Nu", "BTN");
                    BOB = new CurrencyObj("Bolivian Boliviano", "Bs", "BOB");
                    BWP = new CurrencyObj("Botswana Pula", "P", "BWP");
                    BRL = new CurrencyObj("Brazilian Real", "R$", "BRL");
                    GBP = new CurrencyObj("British Pound", "£", "GBP");
                    BND = new CurrencyObj("Brunei Dollar", "$", "BND");
                    BIF = new CurrencyObj("Burundi Franc", "Fbu", "BIF");
                    XOF = new CurrencyObj("CFA Franc (BCEAO)", "CFA", "XOF");
                    XAF = new CurrencyObj("CFA Franc (BEAC)", "FCFA", "XAF");
                    KHR = new CurrencyObj("Cambodia Riel", "៛", "KHR");
                    CAD = new CurrencyObj("Canadian Dollar", "$", "CAD");
                    CVE = new CurrencyObj("Cape Verde Escudo", "$", "CVE");
                    KYD = new CurrencyObj("Cayman Islands Dollar", "$", "KYD");
                    CLP = new CurrencyObj("Chilean Peso", "$", "CLP");
                    CNY = new CurrencyObj("Chinese Yuan", "¥", "CNY");
                    COP = new CurrencyObj("Colombian Peso", "$", "COP");
                    KMF = new CurrencyObj("Comoros Franc", "CF", "KMF");
                    CRC = new CurrencyObj("Costa Rica Colòn", "₡", "CRC");
                    HRK = new CurrencyObj("Croatian Kuna", "kn", "HRK");
                    CUP = new CurrencyObj("Cuban Peso", "$", "CUP");
                    CYP = new CurrencyObj("Cyprus Pound", "£", "CYP");
                    CZK = new CurrencyObj("Czech Koruna", "Kč", "CZK");
                    DKK = new CurrencyObj("Danish Krone", "kr", "DKK");
                    DJF = new CurrencyObj("Djiboutian Franc", "Fdj", "DJF");
                    DOP = new CurrencyObj("Dominican Peso", "$", "DOP");
                    XCD = new CurrencyObj("East Caribbean Dollar", "$", "XCD");
                    EGP = new CurrencyObj("Egyptian Pound", "E£", "EGP");
                    SVC = new CurrencyObj("El Salvador Colòn", "₡", "SVC");
                    ETB = new CurrencyObj("Ethiopian Birr", "ብር", "ETB");
                    EUR = new CurrencyObj("Euro", "€", "EUR");
                    FKP = new CurrencyObj("Falkland Islands Pound", "£", "FKP");
                    GMD = new CurrencyObj("Gambian Dalasi", "D", "GMD");
                    GHC = new CurrencyObj("Ghanian Cedi", "GH₵", "GHC");
                    GIP = new CurrencyObj("Gibraltar Pound", "£", "GIP");
                    GTQ = new CurrencyObj("Guatemalan Quetzal", "Q", "GTQ");
                    GNF = new CurrencyObj("Guinean Franc", "FG", "GNF");
                    GYD = new CurrencyObj("Guyana Dollar", "$", "GYD");
                    HTG = new CurrencyObj("Haitian Gourde", "G", "HTG");
                    HNL = new CurrencyObj("Honduran Lempira", "L", "HNL");
                    HKD = new CurrencyObj("Hong Kong Dollar", "$", "HKD");
                    HUF = new CurrencyObj("Hungarian Forint", "Ft", "HUF");
                    ISK = new CurrencyObj("Icelandic Króna", "kr", "ISK");
                    INR = new CurrencyObj("Indian Rupee", "INR", "INR");
                    IDR = new CurrencyObj("Indonesian Rupiah", "Rp", "IDR");
                    IQD = new CurrencyObj("Iraqi Dinar", "ع.د", "IQD");
                    ILS = new CurrencyObj("Israeli Shekel", "₪", "ILS");
                    JMD = new CurrencyObj("Jamaican Dollar", "$", "JMD");
                    JPY = new CurrencyObj("Japanese Yen", "¥", "JPY");
                    JOD = new CurrencyObj("Jordanian Dinar", "JD", "JOD");
                    KZT = new CurrencyObj("Kazakhstani Tenge", "₸", "KZT");
                    KES = new CurrencyObj("Kenyan Shilling", "KSh", "KES");
                    KRW = new CurrencyObj("South Korean Won", "₩", "KRW");
                    KWD = new CurrencyObj("Kuwaiti Dinar", "د.ك", "KWD");
                    LAK = new CurrencyObj("Lao Kip", "₭", "LAK");
                    LBP = new CurrencyObj("Lebanese Pound", "ل.ل", "LBP");
                    LSL = new CurrencyObj("Lesotho Loti", "L", "LSL");
                    LRD = new CurrencyObj("Liberian Dollar", "$", "LRD");
                    LYD = new CurrencyObj("Libyan Dinar", "ل.د", "LYD");
                    LTL = new CurrencyObj("Lithuanian Lita", "Lt", "LTL");
                    MOP = new CurrencyObj("Macanese Pataca", "MOP$", "MOP");
                    MKD = new CurrencyObj("Macedonian Denar", "ден", "MKD");
                    MWK = new CurrencyObj("Malawian Kwacha", "MK", "MWK");
                    MYR = new CurrencyObj("Malaysian Ringgit", "RM", "MYR");
                    MVR = new CurrencyObj("Maldives Rufiyaa", "Rf", "MVR");
                    MTL = new CurrencyObj("Maltese Lira", "₤", "MTL");
                    MRO = new CurrencyObj("Mauritania Ouguiya", "UM", "MRO");
                    MUR = new CurrencyObj("Mauritian Rupee", "₨", "MUR");
                    MXN = new CurrencyObj("Mexican Peso", "$", "MXN");
                    MDL = new CurrencyObj("Moldovan Leu", "leu", "MDL");
                    MNT = new CurrencyObj("Mongolian Tugrik", "₮", "MNT");
                    MAD = new CurrencyObj("Moroccan Dirham", "د.م.", "MAD");
                    MZM = new CurrencyObj("Mozambique Metical", "MT", "MZM");
                    MMK = new CurrencyObj("Myanmar Kyat", "K", "MMK");
                    NAD = new CurrencyObj("Namibian Dollar", "$", "NAD");
                    NPR = new CurrencyObj("Nepalese Rupee", "₨", "NPR");
                    ANG = new CurrencyObj("Netherlands Antillean Guilder", "Naƒ", "ANG");
                    NZD = new CurrencyObj("New Zealand Dollar", "$", "NZD");
                    NIO = new CurrencyObj("Nicaragua Cordoba", "C$", "NIO");
                    NGN = new CurrencyObj("Nigerian Naira", "₦", "NGN");
                    KPW = new CurrencyObj("North Korean Won", "₩", "KPW");
                    NOK = new CurrencyObj("Norwegian Krone", "kr", "NOK");
                    OMR = new CurrencyObj("Omani Rial", "ر.ع.", "OMR");
                    XPF = new CurrencyObj("Pacific Franc", "F", "XPF");
                    PKR = new CurrencyObj("Pakistani Rupee", "₨", "PKR");
                    PAB = new CurrencyObj("Panamanian Balboa", "B", "PAB");
                    PGK = new CurrencyObj("Papua New Guinean Kina", "K", "PGK");
                    PYG = new CurrencyObj("Paraguayan Guaraní", "₲", "PYG");
                    PEN = new CurrencyObj("Peruvian Nuevo Sol", "S", "PEN");
                    PHP = new CurrencyObj("Philippine Peso", "$", "PHP");
                    PLN = new CurrencyObj("Polish Zloty", "zł", "PLN");
                    QAR = new CurrencyObj("Qatari Riyal", "ر.ق", "QAR");
                    ROL = new CurrencyObj("Romanian Leu", "leu", "ROL");
                    RUB = new CurrencyObj("Russian Rouble", "₽", "RUB");
                    WST = new CurrencyObj("Samoan tālā", "WS$", "WST");
                    STD = new CurrencyObj("São Tomé and Príncipe dobra", "Db", "STD");
                    SAR = new CurrencyObj("Saudi riyal", "ر.س", "SAR");
                    SCR = new CurrencyObj("Seychellois rupee", "SR", "SCR");
                    SLL = new CurrencyObj("Sierra Leonean leone", "Le", "SLL");
                    SGD = new CurrencyObj("Singapore Dollar", "$", "SGD");
                    SKK = new CurrencyObj("Slovak Koruna", "Sk", "SKK");
                    SBD = new CurrencyObj("Solomon Islands Dollar", "$", "SBD");
                    SOS = new CurrencyObj("Somali Shilling", "Sh.So.", "SOS");
                    ZAR = new CurrencyObj("South African Rand", "R", "ZAR");
                    LKR = new CurrencyObj("Sri Lankan Rupee", "රු", "LKR");
                    SHP = new CurrencyObj("Saint Helena Pound", "£", "SHP");
                    SDD = new CurrencyObj("Sudanese Dinar", "£Sd", "SDD");
                    SRG = new CurrencyObj("Surinam Guilder", "ƒ", "SRG");
                    SZL = new CurrencyObj("Swaziland Lilangeni", "L", "SZL");
                    SEK = new CurrencyObj("Swedish Krona", "kr", "SEK");
                    TRY = new CurrencyObj("Turkish lira", "₺", "TRY");
                    CHF = new CurrencyObj("Swiss Franc", "Fr", "CHF");
                    SYP = new CurrencyObj("Syrian Pound", "£", "SYP");
                    TWD = new CurrencyObj("Taiwan Dollar", "$", "TWD");
                    TZS = new CurrencyObj("Tanzanian Shilling", "x", "TZS");
                    THB = new CurrencyObj("Thai Baht", "฿", "THB");
                    TOP = new CurrencyObj("Tongan paʻanga", "T$", "TOP");
                    TTD = new CurrencyObj("Trinidad & Tobago Dollar", "$", "TTD");
                    TND = new CurrencyObj("Tunisian Dinar", "د.ت", "TND");
                    USD = new CurrencyObj("U.S. Dollar", "$", "USD");
                    AED = new CurrencyObj("United Arab Emirates dirham", "د.إ", "AED");
                    UGX = new CurrencyObj("Ugandan Shilling", "Ush", "UGX");
                    UAH = new CurrencyObj("Ukraine Hryvnia", "₴", "UAH");
                    UYU = new CurrencyObj("Uruguayan New Peso", "$", "UYU");
                    VUV = new CurrencyObj("Vanuatu Vatu", "VT", "VUV");
                    VEB = new CurrencyObj("Venezuelan Bolivar", "Bs", "VEB");
                    VND = new CurrencyObj("Vietnamese dong", "₫", "VND");
                    YER = new CurrencyObj("Yemeni Riyal", "﷼", "YER");
                    ZMK = new CurrencyObj("Zambian Kwacha", "ZMK", "ZMK");
                    ZWD = new CurrencyObj("Zimbabwe Dollar", "$", "ZWD");
                    break;
                case "vi-VN":
                    AFA = new CurrencyObj("Afghan afghani", "؋", "AFA");
                    ALL = new CurrencyObj("Albanian lek", "Lek", "ALL");
                    DZD = new CurrencyObj("Algerian dinar", "دج", "DZD");
                    ARS = new CurrencyObj("Argentine peso", "$", "ARS");
                    AWG = new CurrencyObj("Aruban florin", "ƒ", "AWG");
                    AUD = new CurrencyObj("Australian dollar", "$", "AUD");
                    BSD = new CurrencyObj("Bahamian dollar", "$", "BSD");
                    BHD = new CurrencyObj("Bahraini dinar", ".د.ب", "BHD");
                    BDT = new CurrencyObj("Bangladesh taka", "৳", "BDT");
                    BBD = new CurrencyObj("Barbadian dollar", "Bds$", "BBD");
                    BZD = new CurrencyObj("Belize dollar", "BZ$", "BZD");
                    BMD = new CurrencyObj("Bermuda dollar", "$", "BMD");
                    BTN = new CurrencyObj("Bhutanese ngultrum", "Nu", "BTN");
                    BOB = new CurrencyObj("Bolivian boliviano", "Bs", "BOB");
                    BWP = new CurrencyObj("Botswana pula", "P", "BWP");
                    BRL = new CurrencyObj("Brazilian real", "R$", "BRL");
                    GBP = new CurrencyObj("British pound", "£", "GBP");
                    BND = new CurrencyObj("Brunei dollar", "$", "BND");
                    BIF = new CurrencyObj("Burundian franc", "Fbu", "BIF");
                    XOF = new CurrencyObj("CFA Franc (BCEAO)", "CFA", "XOF");
                    XAF = new CurrencyObj("CFA Franc (BEAC)", "FCFA", "XAF");
                    KHR = new CurrencyObj("Cambodian riel", "៛", "KHR");
                    CAD = new CurrencyObj("Canadian dollar", "$", "CAD");
                    CVE = new CurrencyObj("Cape Verdean escudo", "$", "CVE");
                    KYD = new CurrencyObj("Cayman Islands Dollar", "$", "KYD");
                    CLP = new CurrencyObj("Chilean Peso", "$", "CLP");
                    CNY = new CurrencyObj("Chinese Yuan", "¥", "CNY");
                    COP = new CurrencyObj("Colombian Peso", "$", "COP");
                    KMF = new CurrencyObj("Comoros Franc", "CF", "KMF");
                    CRC = new CurrencyObj("Costa Rican Colón", "₡", "CRC");
                    HRK = new CurrencyObj("Croatian Kuna", "kn", "HRK");
                    CUP = new CurrencyObj("Cuban Peso", "$", "CUP");
                    CYP = new CurrencyObj("Cyprus Pound", "£", "CYP");
                    CZK = new CurrencyObj("Czech Koruna", "Kč", "CZK");
                    DKK = new CurrencyObj("Danish Krone", "kr", "DKK");
                    DJF = new CurrencyObj("Djiboutian Franc", "Fdj", "DJF");
                    DOP = new CurrencyObj("Dominican Peso", "$", "DOP");
                    XCD = new CurrencyObj("East Caribbean Dollar", "$", "XCD");
                    EGP = new CurrencyObj("Egyptian Pound", "E£", "EGP");
                    SVC = new CurrencyObj("El Salvador Colòn", "₡", "SVC");
                    ETB = new CurrencyObj("Ethiopian Birr", "ብር", "ETB");
                    EUR = new CurrencyObj("Euro", "€", "EUR");
                    FKP = new CurrencyObj("Falkland Islands Pound", "£", "FKP");
                    GMD = new CurrencyObj("Gambian Dalasi", "D", "GMD");
                    GHC = new CurrencyObj("Ghanian Cedi", "GH₵", "GHC");
                    GIP = new CurrencyObj("Gibraltar Pound", "£", "GIP");
                    GTQ = new CurrencyObj("Guatemalan Quetzal", "Q", "GTQ");
                    GNF = new CurrencyObj("Guinean Franc", "FG", "GNF");
                    GYD = new CurrencyObj("Guyana Dollar", "$", "GYD");
                    HTG = new CurrencyObj("Haitian Gourde", "G", "HTG");
                    HNL = new CurrencyObj("Honduran Lempira", "L", "HNL");
                    HKD = new CurrencyObj("Hong Kong Dollar", "$", "HKD");
                    HUF = new CurrencyObj("Hungarian Forint", "Ft", "HUF");
                    ISK = new CurrencyObj("Icelandic Króna", "kr", "ISK");
                    INR = new CurrencyObj("Indian Rupee", "INR", "INR");
                    IDR = new CurrencyObj("Indonesian Rupiah", "Rp", "IDR");
                    IQD = new CurrencyObj("Iraqi Dinar", "ع.د", "IQD");
                    ILS = new CurrencyObj("Israeli Shekel", "₪", "ILS");
                    JMD = new CurrencyObj("Jamaican Dollar", "$", "JMD");
                    JPY = new CurrencyObj("Japanese Yen", "¥", "JPY");
                    JOD = new CurrencyObj("Jordanian Dinar", "JD", "JOD");
                    KZT = new CurrencyObj("Kazakhstani Tenge", "₸", "KZT");
                    KES = new CurrencyObj("Kenyan Shilling", "KSh", "KES");
                    KRW = new CurrencyObj("South Korean Won", "₩", "KRW");
                    KWD = new CurrencyObj("Kuwaiti Dinar", "د.ك", "KWD");
                    LAK = new CurrencyObj("Lao Kip", "₭", "LAK");
                    LBP = new CurrencyObj("Lebanese Pound", "ل.ل", "LBP");
                    LSL = new CurrencyObj("Lesotho Loti", "L", "LSL");
                    LRD = new CurrencyObj("Liberian Dollar", "$", "LRD");
                    LYD = new CurrencyObj("Libyan Dinar", "ل.د", "LYD");
                    LTL = new CurrencyObj("Lithuanian Lita", "Lt", "LTL");
                    MOP = new CurrencyObj("Macanese Pataca", "MOP$", "MOP");
                    MKD = new CurrencyObj("Macedonian Denar", "ден", "MKD");
                    MWK = new CurrencyObj("Malawian Kwacha", "MK", "MWK");
                    MYR = new CurrencyObj("Malaysian Ringgit", "RM", "MYR");
                    MVR = new CurrencyObj("Maldives Rufiyaa", "Rf", "MVR");
                    MTL = new CurrencyObj("Maltese Lira", "₤", "MTL");
                    MRO = new CurrencyObj("Mauritania Ouguiya", "UM", "MRO");
                    MUR = new CurrencyObj("Mauritian Rupee", "₨", "MUR");
                    MXN = new CurrencyObj("Mexican Peso", "$", "MXN");
                    MDL = new CurrencyObj("Moldovan Leu", "leu", "MDL");
                    MNT = new CurrencyObj("Mongolian Tugrik", "₮", "MNT");
                    MAD = new CurrencyObj("Moroccan Dirham", "د.م.", "MAD");
                    MZM = new CurrencyObj("Mozambique Metical", "MT", "MZM");
                    MMK = new CurrencyObj("Myanmar Kyat", "K", "MMK");
                    NAD = new CurrencyObj("Namibian Dollar", "$", "NAD");
                    NPR = new CurrencyObj("Nepalese Rupee", "₨", "NPR");
                    ANG = new CurrencyObj("Netherlands Antillean Guilder", "Naƒ", "ANG");
                    NZD = new CurrencyObj("New Zealand Dollar", "$", "NZD");
                    NIO = new CurrencyObj("Nicaragua Cordoba", "C$", "NIO");
                    NGN = new CurrencyObj("Nigerian Naira", "₦", "NGN");
                    KPW = new CurrencyObj("North Korean Won", "₩", "KPW");
                    NOK = new CurrencyObj("Norwegian Krone", "kr", "NOK");
                    OMR = new CurrencyObj("Omani Rial", "ر.ع.", "OMR");
                    XPF = new CurrencyObj("Pacific Franc", "F", "XPF");
                    PKR = new CurrencyObj("Pakistani Rupee", "₨", "PKR");
                    PAB = new CurrencyObj("Panamanian Balboa", "B", "PAB");
                    PGK = new CurrencyObj("Papua New Guinean Kina", "K", "PGK");
                    PYG = new CurrencyObj("Paraguayan Guaraní", "₲", "PYG");
                    PEN = new CurrencyObj("Peruvian Nuevo Sol", "S", "PEN");
                    PHP = new CurrencyObj("Philippine Peso", "$", "PHP");
                    PLN = new CurrencyObj("Polish Zloty", "zł", "PLN");
                    QAR = new CurrencyObj("Qatari Riyal", "ر.ق", "QAR");
                    ROL = new CurrencyObj("Romanian Leu", "leu", "ROL");
                    RUB = new CurrencyObj("Russian Rouble", "₽", "RUB");
                    WST = new CurrencyObj("Samoan tālā", "WS$", "WST");
                    STD = new CurrencyObj("São Tomé and Príncipe dobra", "Db", "STD");
                    SAR = new CurrencyObj("Saudi riyal", "ر.س", "SAR");
                    SCR = new CurrencyObj("Seychellois rupee", "SR", "SCR");
                    SLL = new CurrencyObj("Sierra Leonean leone", "Le", "SLL");
                    SGD = new CurrencyObj("Singapore Dollar", "$", "SGD");
                    SKK = new CurrencyObj("Slovak Koruna", "Sk", "SKK");
                    SBD = new CurrencyObj("Solomon Islands Dollar", "$", "SBD");
                    SOS = new CurrencyObj("Somali Shilling", "Sh.So.", "SOS");
                    ZAR = new CurrencyObj("South African Rand", "R", "ZAR");
                    LKR = new CurrencyObj("Sri Lankan Rupee", "රු", "LKR");
                    SHP = new CurrencyObj("Saint Helena Pound", "£", "SHP");
                    SDD = new CurrencyObj("Sudanese Dinar", "£Sd", "SDD");
                    SRG = new CurrencyObj("Surinam Guilder", "ƒ", "SRG");
                    SZL = new CurrencyObj("Swaziland Lilangeni", "L", "SZL");
                    SEK = new CurrencyObj("Swedish Krona", "kr", "SEK");
                    TRY = new CurrencyObj("Turkish lira", "₺", "TRY");
                    CHF = new CurrencyObj("Swiss Franc", "Fr", "CHF");
                    SYP = new CurrencyObj("Syrian Pound", "£", "SYP");
                    TWD = new CurrencyObj("Taiwan Dollar", "$", "TWD");
                    TZS = new CurrencyObj("Tanzanian Shilling", "x", "TZS");
                    THB = new CurrencyObj("Thai Baht", "฿", "THB");
                    TOP = new CurrencyObj("Tongan paʻanga", "T$", "TOP");
                    TTD = new CurrencyObj("Trinidad & Tobago Dollar", "$", "TTD");
                    TND = new CurrencyObj("Tunisian Dinar", "د.ت", "TND");
                    USD = new CurrencyObj("U.S. Dollar", "$", "USD");
                    AED = new CurrencyObj("United Arab Emirates dirham", "د.إ", "AED");
                    UGX = new CurrencyObj("Ugandan Shilling", "Ush", "UGX");
                    UAH = new CurrencyObj("Ukraine Hryvnia", "₴", "UAH");
                    UYU = new CurrencyObj("Uruguayan New Peso", "$", "UYU");
                    VUV = new CurrencyObj("Vanuatu Vatu", "VT", "VUV");
                    VEB = new CurrencyObj("Venezuelan Bolivar", "Bs", "VEB");
                    VND = new CurrencyObj("Vietnamese dong", "₫", "VND");
                    YER = new CurrencyObj("Yemeni Riyal", "﷼", "YER");
                    ZMK = new CurrencyObj("Zambian Kwacha", "ZMK", "ZMK");
                    ZWD = new CurrencyObj("Zimbabwe Dollar", "$", "ZWD");
                    break;
                default:
                    AFA = new CurrencyObj("Afghani afghan", "؋", "AFA");
                    ALL = new CurrencyObj("Lek albanien", "Lek", "ALL");
                    DZD = new CurrencyObj("Dinar algérien", "دج", "DZD");
                    ARS = new CurrencyObj("Peso argentin", "$", "ARS");
                    AWG = new CurrencyObj("Florin arubais", "ƒ", "AWG");
                    AUD = new CurrencyObj("Dollar australien", "$", "AUD");
                    BSD = new CurrencyObj("Dollar bahaméen", "$", "BSD");
                    BHD = new CurrencyObj("Dinar bahreïni", ".د.ب", "BHD");
                    BDT = new CurrencyObj("Taka", "৳", "BDT");
                    BBD = new CurrencyObj("Dollar barbadien", "Bds$", "BBD");
                    BZD = new CurrencyObj("Dollar bélizien", "BZ$", "BZD");
                    BMD = new CurrencyObj("Dollar bermudien", "$", "BMD");
                    BTN = new CurrencyObj("Ngultrum", "Nu", "BTN");
                    BOB = new CurrencyObj("Boliviano bolivien", "Bs", "BOB");
                    BWP = new CurrencyObj("Pula", "P", "BWP");
                    BRL = new CurrencyObj("Réal brésilien", "R$", "BRL");
                    GBP = new CurrencyObj("Livre sterling", "£", "GBP");
                    BND = new CurrencyObj("Dollar de Brunei", "$", "BND");
                    BIF = new CurrencyObj("Franc burundais", "Fbu", "BIF");
                    XOF = new CurrencyObj("Franc CFA (UEMOA)", "CFA", "XOF");
                    XAF = new CurrencyObj("Franc CFA (CEMAC)", "FCFA", "XAF");
                    KHR = new CurrencyObj("Riel", "៛", "KHR");
                    CAD = new CurrencyObj("Dollar canadien", "$", "CAD");
                    CVE = new CurrencyObj("Escudo cap-verdien", "$", "CVE");
                    KYD = new CurrencyObj("Dollar des îles Caïmans", "$", "KYD");
                    CLP = new CurrencyObj("Peso chilien", "$", "CLP");
                    CNY = new CurrencyObj("Yuan chinois", "¥", "CNY");
                    COP = new CurrencyObj("Peso colombien", "$", "COP");
                    KMF = new CurrencyObj("Franc comorien", "CF", "KMF");
                    CRC = new CurrencyObj("Colón costaricien", "₡", "CRC");
                    HRK = new CurrencyObj("Croatian Kuna", "kn", "HRK");
                    CUP = new CurrencyObj("Cuban Peso", "$", "CUP");
                    CYP = new CurrencyObj("Cyprus Pound", "£", "CYP");
                    CZK = new CurrencyObj("Czech Koruna", "Kč", "CZK");
                    DKK = new CurrencyObj("Danish Krone", "kr", "DKK");
                    DJF = new CurrencyObj("Djiboutian Franc", "Fdj", "DJF");
                    DOP = new CurrencyObj("Dominican Peso", "$", "DOP");
                    XCD = new CurrencyObj("East Caribbean Dollar", "$", "XCD");
                    EGP = new CurrencyObj("Egyptian Pound", "E£", "EGP");
                    SVC = new CurrencyObj("El Salvador Colòn", "₡", "SVC");
                    ETB = new CurrencyObj("Ethiopian Birr", "ብር", "ETB");
                    EUR = new CurrencyObj("Euro", "€", "EUR");
                    FKP = new CurrencyObj("Falkland Islands Pound", "£", "FKP");
                    GMD = new CurrencyObj("Gambian Dalasi", "D", "GMD");
                    GHC = new CurrencyObj("Ghanian Cedi", "GH₵", "GHC");
                    GIP = new CurrencyObj("Gibraltar Pound", "£", "GIP");
                    GTQ = new CurrencyObj("Guatemalan Quetzal", "Q", "GTQ");
                    GNF = new CurrencyObj("Guinean Franc", "FG", "GNF");
                    GYD = new CurrencyObj("Guyana Dollar", "$", "GYD");
                    HTG = new CurrencyObj("Haitian Gourde", "G", "HTG");
                    HNL = new CurrencyObj("Honduran Lempira", "L", "HNL");
                    HKD = new CurrencyObj("Hong Kong Dollar", "$", "HKD");
                    HUF = new CurrencyObj("Hungarian Forint", "Ft", "HUF");
                    ISK = new CurrencyObj("Icelandic Króna", "kr", "ISK");
                    INR = new CurrencyObj("Indian Rupee", "INR", "INR");
                    IDR = new CurrencyObj("Indonesian Rupiah", "Rp", "IDR");
                    IQD = new CurrencyObj("Iraqi Dinar", "ع.د", "IQD");
                    ILS = new CurrencyObj("Israeli Shekel", "₪", "ILS");
                    JMD = new CurrencyObj("Jamaican Dollar", "$", "JMD");
                    JPY = new CurrencyObj("Japanese Yen", "¥", "JPY");
                    JOD = new CurrencyObj("Jordanian Dinar", "JD", "JOD");
                    KZT = new CurrencyObj("Kazakhstani Tenge", "₸", "KZT");
                    KES = new CurrencyObj("Kenyan Shilling", "KSh", "KES");
                    KRW = new CurrencyObj("South Korean Won", "₩", "KRW");
                    KWD = new CurrencyObj("Kuwaiti Dinar", "د.ك", "KWD");
                    LAK = new CurrencyObj("Lao Kip", "₭", "LAK");
                    LBP = new CurrencyObj("Lebanese Pound", "ل.ل", "LBP");
                    LSL = new CurrencyObj("Lesotho Loti", "L", "LSL");
                    LRD = new CurrencyObj("Liberian Dollar", "$", "LRD");
                    LYD = new CurrencyObj("Libyan Dinar", "ل.د", "LYD");
                    LTL = new CurrencyObj("Lithuanian Lita", "Lt", "LTL");
                    MOP = new CurrencyObj("Macanese Pataca", "MOP$", "MOP");
                    MKD = new CurrencyObj("Macedonian Denar", "ден", "MKD");
                    MWK = new CurrencyObj("Malawian Kwacha", "MK", "MWK");
                    MYR = new CurrencyObj("Malaysian Ringgit", "RM", "MYR");
                    MVR = new CurrencyObj("Maldives Rufiyaa", "Rf", "MVR");
                    MTL = new CurrencyObj("Maltese Lira", "₤", "MTL");
                    MRO = new CurrencyObj("Mauritania Ouguiya", "UM", "MRO");
                    MUR = new CurrencyObj("Mauritian Rupee", "₨", "MUR");
                    MXN = new CurrencyObj("Mexican Peso", "$", "MXN");
                    MDL = new CurrencyObj("Moldovan Leu", "leu", "MDL");
                    MNT = new CurrencyObj("Mongolian Tugrik", "₮", "MNT");
                    MAD = new CurrencyObj("Moroccan Dirham", "د.م.", "MAD");
                    MZM = new CurrencyObj("Mozambique Metical", "MT", "MZM");
                    MMK = new CurrencyObj("Myanmar Kyat", "K", "MMK");
                    NAD = new CurrencyObj("Namibian Dollar", "$", "NAD");
                    NPR = new CurrencyObj("Nepalese Rupee", "₨", "NPR");
                    ANG = new CurrencyObj("Netherlands Antillean Guilder", "Naƒ", "ANG");
                    NZD = new CurrencyObj("New Zealand Dollar", "$", "NZD");
                    NIO = new CurrencyObj("Nicaragua Cordoba", "C$", "NIO");
                    NGN = new CurrencyObj("Nigerian Naira", "₦", "NGN");
                    KPW = new CurrencyObj("North Korean Won", "₩", "KPW");
                    NOK = new CurrencyObj("Norwegian Krone", "kr", "NOK");
                    OMR = new CurrencyObj("Omani Rial", "ر.ع.", "OMR");
                    XPF = new CurrencyObj("Pacific Franc", "F", "XPF");
                    PKR = new CurrencyObj("Pakistani Rupee", "₨", "PKR");
                    PAB = new CurrencyObj("Panamanian Balboa", "B", "PAB");
                    PGK = new CurrencyObj("Papua New Guinean Kina", "K", "PGK");
                    PYG = new CurrencyObj("Paraguayan Guaraní", "₲", "PYG");
                    PEN = new CurrencyObj("Peruvian Nuevo Sol", "S", "PEN");
                    PHP = new CurrencyObj("Philippine Peso", "$", "PHP");
                    PLN = new CurrencyObj("Polish Zloty", "zł", "PLN");
                    QAR = new CurrencyObj("Qatari Riyal", "ر.ق", "QAR");
                    ROL = new CurrencyObj("Romanian Leu", "leu", "ROL");
                    RUB = new CurrencyObj("Russian Rouble", "₽", "RUB");
                    WST = new CurrencyObj("Samoan tālā", "WS$", "WST");
                    STD = new CurrencyObj("São Tomé and Príncipe dobra", "Db", "STD");
                    SAR = new CurrencyObj("Saudi riyal", "ر.س", "SAR");
                    SCR = new CurrencyObj("Seychellois rupee", "SR", "SCR");
                    SLL = new CurrencyObj("Sierra Leonean leone", "Le", "SLL");
                    SGD = new CurrencyObj("Singapore Dollar", "$", "SGD");
                    SKK = new CurrencyObj("Slovak Koruna", "Sk", "SKK");
                    SBD = new CurrencyObj("Solomon Islands Dollar", "$", "SBD");
                    SOS = new CurrencyObj("Somali Shilling", "Sh.So.", "SOS");
                    ZAR = new CurrencyObj("South African Rand", "R", "ZAR");
                    LKR = new CurrencyObj("Sri Lankan Rupee", "රු", "LKR");
                    SHP = new CurrencyObj("Saint Helena Pound", "£", "SHP");
                    SDD = new CurrencyObj("Sudanese Dinar", "£Sd", "SDD");
                    SRG = new CurrencyObj("Surinam Guilder", "ƒ", "SRG");
                    SZL = new CurrencyObj("Swaziland Lilangeni", "L", "SZL");
                    SEK = new CurrencyObj("Swedish Krona", "kr", "SEK");
                    TRY = new CurrencyObj("Turkish lira", "₺", "TRY");
                    CHF = new CurrencyObj("Swiss Franc", "Fr", "CHF");
                    SYP = new CurrencyObj("Syrian Pound", "£", "SYP");
                    TWD = new CurrencyObj("Taiwan Dollar", "$", "TWD");
                    TZS = new CurrencyObj("Tanzanian Shilling", "x", "TZS");
                    THB = new CurrencyObj("Thai Baht", "฿", "THB");
                    TOP = new CurrencyObj("Tongan paʻanga", "T$", "TOP");
                    TTD = new CurrencyObj("Trinidad & Tobago Dollar", "$", "TTD");
                    TND = new CurrencyObj("Tunisian Dinar", "د.ت", "TND");
                    USD = new CurrencyObj("U.S. Dollar", "$", "USD");
                    AED = new CurrencyObj("United Arab Emirates dirham", "د.إ", "AED");
                    UGX = new CurrencyObj("Ugandan Shilling", "Ush", "UGX");
                    UAH = new CurrencyObj("Ukraine Hryvnia", "₴", "UAH");
                    UYU = new CurrencyObj("Uruguayan New Peso", "$", "UYU");
                    VUV = new CurrencyObj("Vanuatu Vatu", "VT", "VUV");
                    VEB = new CurrencyObj("Venezuelan Bolivar", "Bs", "VEB");
                    VND = new CurrencyObj("Vietnamese dong", "₫", "VND");
                    YER = new CurrencyObj("Yemeni Riyal", "﷼", "YER");
                    ZMK = new CurrencyObj("Zambian Kwacha", "ZMK", "ZMK");
                    ZWD = new CurrencyObj("Zimbabwe Dollar", "$", "ZWD");
                    break;
            }
            BaseUnit = new CurrencyObj("Base unit", "BU", "BU", 1);
        }



        public static CurrencyObj AFA;
        public static CurrencyObj ALL;
        public static CurrencyObj DZD;
        public static CurrencyObj ARS;
        public static CurrencyObj AWG;
        public static CurrencyObj AUD;
        public static CurrencyObj BSD;
        public static CurrencyObj BHD;
        public static CurrencyObj BDT;
        public static CurrencyObj BBD;
        public static CurrencyObj BZD;
        public static CurrencyObj BMD;
        public static CurrencyObj BTN;
        public static CurrencyObj BOB;
        public static CurrencyObj BWP;
        public static CurrencyObj BRL;
        public static CurrencyObj GBP;
        public static CurrencyObj BND;
        public static CurrencyObj BIF;
        public static CurrencyObj XOF;
        public static CurrencyObj XAF;
        public static CurrencyObj KHR;
        public static CurrencyObj CAD;
        public static CurrencyObj CVE;
        public static CurrencyObj KYD;
        public static CurrencyObj CLP;
        public static CurrencyObj CNY;
        public static CurrencyObj COP;
        public static CurrencyObj KMF;
        public static CurrencyObj CRC;
        public static CurrencyObj HRK;
        public static CurrencyObj CUP;
        public static CurrencyObj CYP;
        public static CurrencyObj CZK;
        public static CurrencyObj DKK;
        public static CurrencyObj DJF;
        public static CurrencyObj DOP;
        public static CurrencyObj XCD;
        public static CurrencyObj EGP;
        public static CurrencyObj SVC;
        public static CurrencyObj ETB;
        public static CurrencyObj EUR;
        public static CurrencyObj FKP;
        public static CurrencyObj GMD;
        public static CurrencyObj GHC;
        public static CurrencyObj GIP;
        public static CurrencyObj GTQ;
        public static CurrencyObj GNF;
        public static CurrencyObj GYD;
        public static CurrencyObj HTG;
        public static CurrencyObj HNL;
        public static CurrencyObj HKD;
        public static CurrencyObj HUF;
        public static CurrencyObj ISK;
        public static CurrencyObj INR;
        public static CurrencyObj IDR;
        public static CurrencyObj IQD;
        public static CurrencyObj ILS;
        public static CurrencyObj JMD;
        public static CurrencyObj JPY;
        public static CurrencyObj JOD;
        public static CurrencyObj KZT;
        public static CurrencyObj KES;
        public static CurrencyObj KRW;
        public static CurrencyObj KWD;
        public static CurrencyObj LAK;
        public static CurrencyObj LBP;
        public static CurrencyObj LSL;
        public static CurrencyObj LRD;
        public static CurrencyObj LYD;
        public static CurrencyObj LTL;
        public static CurrencyObj MOP;
        public static CurrencyObj MKD;
        public static CurrencyObj MWK;
        public static CurrencyObj MYR;
        public static CurrencyObj MVR;
        public static CurrencyObj MTL;
        public static CurrencyObj MRO;
        public static CurrencyObj MUR;
        public static CurrencyObj MXN;
        public static CurrencyObj MDL;
        public static CurrencyObj MNT;
        public static CurrencyObj MAD;
        public static CurrencyObj MZM;
        public static CurrencyObj MMK;
        public static CurrencyObj NAD;
        public static CurrencyObj NPR;
        public static CurrencyObj ANG;
        public static CurrencyObj NZD;
        public static CurrencyObj NIO;
        public static CurrencyObj NGN;
        public static CurrencyObj KPW;
        public static CurrencyObj NOK;
        public static CurrencyObj OMR;
        public static CurrencyObj XPF;
        public static CurrencyObj PKR;
        public static CurrencyObj PAB;
        public static CurrencyObj PGK;
        public static CurrencyObj PYG;
        public static CurrencyObj PEN;
        public static CurrencyObj PHP;
        public static CurrencyObj PLN;
        public static CurrencyObj QAR;
        public static CurrencyObj ROL;
        public static CurrencyObj RUB;
        public static CurrencyObj WST;
        public static CurrencyObj STD;
        public static CurrencyObj SAR;
        public static CurrencyObj SCR;
        public static CurrencyObj SLL;
        public static CurrencyObj SGD;
        public static CurrencyObj SKK;
        public static CurrencyObj SBD;
        public static CurrencyObj SOS;
        public static CurrencyObj ZAR;
        public static CurrencyObj LKR;
        public static CurrencyObj SHP;
        public static CurrencyObj SDD;
        public static CurrencyObj SRG;
        public static CurrencyObj SZL;
        public static CurrencyObj SEK;
        public static CurrencyObj TRY;
        public static CurrencyObj CHF;
        public static CurrencyObj SYP;
        public static CurrencyObj TWD;
        public static CurrencyObj TZS;
        public static CurrencyObj THB;
        public static CurrencyObj TOP;
        public static CurrencyObj TTD;
        public static CurrencyObj TND;
        public static CurrencyObj USD;
        public static CurrencyObj AED;
        public static CurrencyObj UGX;
        public static CurrencyObj UAH;
        public static CurrencyObj UYU;
        public static CurrencyObj VUV;
        public static CurrencyObj VEB;
        public static CurrencyObj VND;
        public static CurrencyObj YER;
        public static CurrencyObj ZMK;
        public static CurrencyObj ZWD;


    }
}