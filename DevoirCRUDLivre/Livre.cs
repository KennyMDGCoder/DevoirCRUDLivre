using System;

public class Livre
{
    public int Id { get; set; }
    public string Titre { get; set; }
    public string? Auteur { get; set; }
    public string? ISBN { get; set; }
    public DateTime? DatePublication { get; set; }
    // public bool Disponible { get; set; } // <--- Cette ligne est SUPPRIM\u00C9E

    public string? Genre { get; set; }
    public string? Editeur { get; set; }
    public string? Resume { get; set; }

    public Livre()
    {
        Titre = string.Empty;
        // Disponible = true; // <--- Cette ligne est SUPPRIM\u00C9E
    }

    public override string ToString()
    {
        return $"{Titre} par {Auteur ?? "Inconnu"}";
    }
}