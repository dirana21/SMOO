using System;

namespace Task1
{
    public class ZayavkaNaAviabilet
    {
        public string PunktPriznachennya { get; set; }
        public string NomerReysu { get; set; }
        public string PIBPasazhira { get; set; }
        public DateTime DataVylotu { get; set; }

        public override string ToString()
        {
            return $"Passanger: {PIBPasazhira}, Flight: {NomerReysu}, " +
                   $"Destination: {PunktPriznachennya}, Date: {DataVylotu:dd.MM.yyyy}";
        }
    }
}