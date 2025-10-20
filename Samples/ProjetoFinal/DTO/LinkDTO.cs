namespace ProjetoFinal.DTO;

public class LinkDTO
{
    public string Rel { get; set; } // relação: self, delete, update etc.
    public string Href { get; set; } // URL
    public string Method { get; set; } // GET, POST, DELETE etc.

    public LinkDTO(string rel, string href, string method)
    {
        Rel = rel;
        Href = href;
        Method = method;
    }
}