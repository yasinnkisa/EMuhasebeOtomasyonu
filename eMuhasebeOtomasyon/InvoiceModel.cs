namespace eMuhasebeOtomasyon
{
    public class InvoiceModel
    {
        public string FaturaID { get; set; }
        public string FaturaTipi { get; set; } // "Satış" veya "Alış"
        public string CariAdi { get; set; }
        public string Tarih { get; set; }
        public double ToplamTutar { get; set; }
    }
}