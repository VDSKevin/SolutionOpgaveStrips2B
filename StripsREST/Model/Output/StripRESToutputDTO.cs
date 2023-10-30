using StripsBL.Model;
using System.Collections.Generic;

namespace StripsREST.Model.Output
{
    public class StripRESToutputDTO
    {
        public StripRESToutputDTO(string stripURL, Strip strip, string reeksURL, string uitgeverijURL, string auteurURL)
        {
            Url = stripURL;
            Titel = strip.Titel;
            Nr = strip.Nr.ToString();
            Reeks = strip.Reeks.Naam;
            ReeksUrl = reeksURL;
            Uitgeverij = strip.Uitgeverij.Naam;
            UitgeverijUrl = uitgeverijURL;

            Auteurs = strip.Auteurs.Select(auteur => new AuteurDTO
            {
                Auteur = auteur.Naam,
                Url = auteurURL + "/" + auteur.ID
            }).ToList();
        }

        public string Url { get; set; }
        public string Titel { get; set; }
        public string? Nr { get; set; }
        public string Reeks { get; set; }
        public string ReeksUrl { get; set; }
        public string Uitgeverij { get; set; }
        public string UitgeverijUrl { get; set; }
        public List<AuteurDTO> Auteurs { get; set; } = new List<AuteurDTO>();
    }

    public class AuteurDTO
    {
        public string Auteur { get; set; }
        public string Url { get; set; }
    }
}