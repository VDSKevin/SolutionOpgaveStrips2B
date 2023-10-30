using System.Collections.Generic;

namespace StripsClientWPFStripView.Model
{
    public class Strip
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public int? Nr { get; set; }
        public string Reeks { get; set; }
        public string Uitgeverij { get; set; }
        public List<string> Auteurs { get; set; }

        public Strip()
        {
            Auteurs = new List<string>();
        }
    }
}