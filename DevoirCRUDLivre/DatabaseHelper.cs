using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;

public static class DatabaseHelper
{
    private static string connectionString = "Data Source=DevoirCRUD.sqlite;Version=3;";

    public static void CreateTable()
    {
        string query = @"CREATE TABLE IF NOT EXISTS Livres (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Titre TEXT NOT NULL,
                            Auteur TEXT,
                            ISBN TEXT UNIQUE,
                            DatePublication TEXT,
                            Genre TEXT,
                            Editeur TEXT,
                            Resume TEXT
                        );";

        using (var connection = new SQLiteConnection(connectionString))
        {
            try
            {
                connection.Open();
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Table 'Livres' v\u00E9rifi\u00E9e/cr\u00E9\u00E9e avec succ\u00E8s.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la cr\u00E9ation de la table 'Livres' : " + ex.Message);
            }
        }
    }

    public static void InsertLivre(Livre livre)
    {
        string query = @"INSERT INTO Livres (Titre, Auteur, ISBN, DatePublication, Genre, Editeur, Resume)
                         VALUES (@Titre, @Auteur, @ISBN, @DatePublication, @Genre, @Editeur, @Resume);";

        using (var connection = new SQLiteConnection(connectionString))
        {
            try
            {
                connection.Open();
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Titre", livre.Titre);
                    command.Parameters.AddWithValue("@Auteur", livre.Auteur ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ISBN", livre.ISBN ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@DatePublication", livre.DatePublication.HasValue ? livre.DatePublication.Value.ToString("yyyy-MM-dd HH:mm:ss") : (object)DBNull.Value);
                    // Pas de @Disponible ici

                    command.Parameters.AddWithValue("@Genre", livre.Genre ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Editeur", livre.Editeur ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Resume", livre.Resume ?? (object)DBNull.Value);

                    command.ExecuteNonQuery();
                    Console.WriteLine($"Livre '{livre.Titre}' ins\u00E9r\u00E9 avec succ\u00E8s.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de l'insertion du livre '{livre.Titre}' : " + ex.Message);
            }
        }
    }

    public static void UpdateLivre(Livre livre)
    {
        string query = @"UPDATE Livres
                         SET Titre = @Titre,
                             Auteur = @Auteur,
                             ISBN = @ISBN,
                             DatePublication = @DatePublication,
                             Genre = @Genre,
                             Editeur = @Editeur,
                             Resume = @Resume
                         WHERE Id = @Id;";

        using (var connection = new SQLiteConnection(connectionString))
        {
            try
            {
                connection.Open();
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Titre", livre.Titre);
                    command.Parameters.AddWithValue("@Auteur", livre.Auteur ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ISBN", livre.ISBN ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@DatePublication", livre.DatePublication.HasValue ? livre.DatePublication.Value.ToString("yyyy-MM-dd HH:mm:ss") : (object)DBNull.Value);
                    // Pas de @Disponible ici

                    command.Parameters.AddWithValue("@Genre", livre.Genre ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Editeur", livre.Editeur ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Resume", livre.Resume ?? (object)DBNull.Value);

                    command.Parameters.AddWithValue("@Id", livre.Id);

                    command.ExecuteNonQuery();
                    Console.WriteLine($"Livre avec ID {livre.Id} mis \u00E0 jour avec succ\u00E8s.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la mise \u00E0 jour du livre avec ID {livre.Id} : " + ex.Message);
            }
        }
    }

    public static Livre? GetLivreById(int id)
    {
        Livre? livre = null;

        string query = @"SELECT Id, Titre, Auteur, ISBN, DatePublication,
                                Genre, Editeur, Resume -- Pas de Disponible ici
                         FROM Livres
                         WHERE Id = @Id;";

        using (var connection = new SQLiteConnection(connectionString))
        {
            try
            {
                connection.Open();
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            livre = new Livre();
                            livre.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            livre.Titre = reader.GetString(reader.GetOrdinal("Titre"));

                            livre.Auteur = reader.IsDBNull(reader.GetOrdinal("Auteur")) ? null : reader.GetString(reader.GetOrdinal("Auteur"));
                            livre.ISBN = reader.IsDBNull(reader.GetOrdinal("ISBN")) ? null : reader.GetString(reader.GetOrdinal("ISBN"));
                            livre.DatePublication = reader.IsDBNull(reader.GetOrdinal("DatePublication")) ? (DateTime?)null : DateTime.ParseExact(reader.GetString(reader.GetOrdinal("DatePublication")), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                            // Plus de lecture de Disponible ici

                            livre.Genre = reader.IsDBNull(reader.GetOrdinal("Genre")) ? null : reader.GetString(reader.GetOrdinal("Genre"));
                            livre.Editeur = reader.IsDBNull(reader.GetOrdinal("Editeur")) ? null : reader.GetString(reader.GetOrdinal("Editeur"));
                            livre.Resume = reader.IsDBNull(reader.GetOrdinal("Resume")) ? null : reader.GetString(reader.GetOrdinal("Resume"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la r\u00E9cup\u00E9ration du livre avec ID {id} : " + ex.Message);
            }
        }
        return livre;
    }

    public static List<Livre> GetLivres(string? searchTerm = null, string? filterBy = null)
    {
        List<Livre> livres = new List<Livre>();

        string query = @"SELECT Id, Titre, Auteur, ISBN, DatePublication,
                                Genre, Editeur, Resume -- Pas de Disponible ici
                         FROM Livres";

        bool hasWhereClause = false;

        if (!string.IsNullOrWhiteSpace(searchTerm) && !string.IsNullOrWhiteSpace(filterBy))
        {
            query += " WHERE ";
            hasWhereClause = true;
            filterBy = filterBy.Trim();

            switch (filterBy.ToLower())
            {
                case "titre":
                    query += "Titre LIKE @SearchTerm";
                    break;
                case "auteur":
                    query += "Auteur LIKE @SearchTerm";
                    break;
                case "isbn":
                    query += "ISBN LIKE @SearchTerm";
                    break;
                case "genre":
                    query += "Genre LIKE @SearchTerm";
                    break;
                case "editeur":
                    query += "Editeur LIKE @SearchTerm";
                    break;
                default:
                    Console.WriteLine($"[WARNING DatabaseHelper.GetLivres] Colonne de filtrage sp\u00E9cifi\u00E9e non valide : {filterBy}. Le filtre sera ignor\u00E9.");
                    hasWhereClause = false;
                    query = @"SELECT Id, Titre, Auteur, ISBN, DatePublication,
                                     Genre, Editeur, Resume FROM Livres";
                    break;
            }
        }

        query += " ORDER BY Titre ASC;";

        using (var connection = new SQLiteConnection(connectionString))
        {
            try
            {
                connection.Open();
                using (var command = new SQLiteCommand(query, connection))
                {
                    if (!string.IsNullOrWhiteSpace(searchTerm) && hasWhereClause)
                    {
                        command.Parameters.AddWithValue("@SearchTerm", $"%{searchTerm}%");
                    }

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Livre livre = new Livre();
                            livre.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            livre.Titre = reader.GetString(reader.GetOrdinal("Titre"));

                            livre.Auteur = reader.IsDBNull(reader.GetOrdinal("Auteur")) ? null : reader.GetString(reader.GetOrdinal("Auteur"));
                            livre.ISBN = reader.IsDBNull(reader.GetOrdinal("ISBN")) ? null : reader.GetString(reader.GetOrdinal("ISBN"));
                            livre.DatePublication = reader.IsDBNull(reader.GetOrdinal("DatePublication")) ? (DateTime?)null : DateTime.ParseExact(reader.GetString(reader.GetOrdinal("DatePublication")), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                            // Plus de lecture de Disponible ici

                            livre.Genre = reader.IsDBNull(reader.GetOrdinal("Genre")) ? null : reader.GetString(reader.GetOrdinal("Genre"));
                            livre.Editeur = reader.IsDBNull(reader.GetOrdinal("Editeur")) ? null : reader.GetString(reader.GetOrdinal("Editeur"));
                            livre.Resume = reader.IsDBNull(reader.GetOrdinal("Resume")) ? null : reader.GetString(reader.GetOrdinal("Resume"));

                            livres.Add(livre);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la r\u00E9cup\u00E9ration des livres (filtr\u00E9s/complets) : " + ex.Message);
            }
        }
        return livres;
    }

    public static void DeleteLivre(int id)
    {
        string query = "DELETE FROM Livres WHERE Id = @Id;";

        using (var connection = new SQLiteConnection(connectionString))
        {
            try
            {
                connection.Open();
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Livre avec ID {id} supprim\u00E9 avec succ\u00E8s.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la suppression du livre avec ID {id} : " + ex.Message);
            }
        }
    }
}