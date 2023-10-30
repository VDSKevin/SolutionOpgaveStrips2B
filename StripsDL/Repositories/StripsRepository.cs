//using StripsBL.DTOs;
using StripsBL.Interfaces;
using StripsBL.Model;
using StripsDL.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using StripsBL.Exceptions;

namespace StripsDL.Repositories
{
    public class StripsRepository : IStripsRepository
    {
        private string connectionString;

        public StripsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public Strip GeefStrip(int stripId)
        {
            string sql = @"
        SELECT 
            s.Id, s.Titel, s.Nr, s.Uitgeverij, s.Reeks, 
            r.Naam AS ReeksNaam, 
            u.Naam AS UitgeverijNaam, 
            a.Id AS AuteurId, a.Naam AS AuteurNaam
        FROM 
            Strip s
        LEFT JOIN 
            Reeks r ON s.Reeks = r.Id
        LEFT JOIN 
            Uitgeverij u ON s.Uitgeverij = u.Id
        LEFT JOIN 
            StripAuteur sa ON s.Id = sa.StripId
        LEFT JOIN 
            Auteur a ON sa.AuteurId = a.Id
        WHERE 
            s.Id = @stripId
    ";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                try
                {
                    conn.Open();
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@stripId", stripId);

                    List<Auteur> auteurs = new List<Auteur>();
                    Strip strip = null;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (strip == null)
                            {
                                Uitgeverij uitgeverij = new Uitgeverij((int)dr["Uitgeverij"], (string)dr["UitgeverijNaam"]);
                                Reeks reeks = new Reeks((int)dr["Reeks"], (string)dr["ReeksNaam"]);

                                strip = new Strip((int)dr["Id"], (string)dr["Titel"], (int)dr["Nr"], reeks, uitgeverij, auteurs);
                            }

                            if (dr["AuteurId"] != DBNull.Value)
                            {
                                Auteur auteur = new Auteur((int)dr["AuteurId"], (string)dr["AuteurNaam"]);
                                auteurs.Add(auteur);
                            }
                        }
                    }

                    return strip;
                }
                catch (Exception ex)
                {
                    throw new StripsRepositoryException("GeefStrip", ex);
                }
            }
        }

    }
}
