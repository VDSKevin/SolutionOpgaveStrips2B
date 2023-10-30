using Newtonsoft.Json;
using StripsClientWPFStripView.Exceptions;
using StripsClientWPFStripView.Model;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace StripsClientWPFStripView.Services
{
    public class StripServiceClient
    {
        private HttpClient client;
        private string baseApiUrl = "http://localhost:5044";

        public StripServiceClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(baseApiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Strip> GetStrip(int stripId)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"/api/strips/beheer/{stripId}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    // Deserialize to an anonymous type
                    var dto = JsonConvert.DeserializeAnonymousType(json, new
                    {
                        Url = "",
                        Titel = "",
                        Nr = (string)null,
                        Reeks = "",
                        Uitgeverij = "",
                        Auteurs = new[] { new { Auteur = "", Url = (string)null } }
                    });

                    // Map to the Strip ViewModel
                    Strip strip = new Strip
                    {
                        Id = int.Parse(dto.Url.Split('/').Last()),
                        Titel = dto.Titel,
                        Nr = string.IsNullOrEmpty(dto.Nr) ? (int?)null : int.Parse(dto.Nr),
                        Reeks = dto.Reeks,
                        Uitgeverij = dto.Uitgeverij,
                        Auteurs = dto.Auteurs.Select(a => a.Auteur).ToList()
                    };

                    return strip;
                }
                else
                {
                    throw new StripServiceClientException("Failed to retrieve Strip");
                }
            }
            catch (Exception ex)
            {
                throw new StripServiceClientException("Error in StripServiceClient: " + ex.Message);
            }
        }

    }
}