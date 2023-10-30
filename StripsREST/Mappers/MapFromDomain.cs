using System.Collections.Generic;
using System.Net.Mail;
using StripsBL.Exceptions;
using StripsBL.Managers;
using StripsBL.Model;
using StripsREST.Model.Output;

namespace StripsREST.Mappers;

public static class MapFromDomain
{
    public static StripRESToutputDTO MapFromStripDomain(string baseApiUrl, Strip strip, StripsManager stripManager)
    {
        try
        {
            string stripURL = $"{baseApiUrl}/strip/{strip.ID}";
            string reeksURL = $"{baseApiUrl}/reeks/{strip.Reeks.ID}";
            string uitgeverijURL =
                $"{baseApiUrl}/uitgeverij/{strip.Uitgeverij.ID}";

            string auteurURL = $"{baseApiUrl}/auteur";

            StripRESToutputDTO dto = new StripRESToutputDTO(stripURL, strip, reeksURL, uitgeverijURL, auteurURL);
            return dto;
        }
        catch (Exception ex)
        {
            throw new MapException("MapFromStripDomain", ex);
        }
    }
}