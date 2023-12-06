using System.ComponentModel.DataAnnotations;

namespace _1er_logiciel_web_api;

public class BookUpdateDTO
{
    [RegularExpression(@"([A-Za-z0-9]+( [A-Za-z0-9]+)+)", ErrorMessage = "Seulement les chiffres et les lettres sont acceptées")]
    public string? Title { get; set; }
    [RegularExpression(@"([A-Za-z]+( [A-Za-z]+)+)", ErrorMessage = "Seulement des lettres sont acceptées")]
    public string? Author { get; set; }
    [RegularExpression(@"([A-Za-z]+( [A-Za-z]+)+)", ErrorMessage = "Seulement des lettres sont acceptées")]
    public string? Genre { get; set; }
    [Required]
    [RegularExpression(@"[0-9]*\.[0-9]+", ErrorMessage = "Seulement des chiffres sont acceptées")]
    public decimal Price { get; set; }
    [Required]
    [RegularExpression(@"[0-9]{4}-[0-9]{2}-[0-9]{2}", ErrorMessage = "Seulement une date est acceptée")]
    public DateTime PublishDate { get; set; }
    [RegularExpression(@"([A-Za-z0-9]+( [A-Za-z0-9]+)+)", ErrorMessage = "Seulement les chiffres et les lettres sont acceptées")]
    public string? Description { get; set; }
    [RegularExpression(@"([A-Za-z0-9]+( [A-Za-z0-9]+)+)", ErrorMessage = "Seulement les chiffres et les lettres sont acceptées")]
    public string? Remarks { get; set; }
}
