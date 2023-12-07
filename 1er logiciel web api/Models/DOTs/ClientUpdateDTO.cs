using System.ComponentModel.DataAnnotations;

namespace _1er_logiciel_web_api;

public class ClientUpdateDTO //La class ClientUpdateDTO permet de renvoyer certaine informations à l'utilisateur sur des données sensibles ou bien effectuer des vérifications sur les valeurs
{
    [RegularExpression(@"([A-Za-z0-9]+( [A-Za-z0-9]+)+)", ErrorMessage = "Seulement les chiffres et les lettres sont acceptées")]
    public string? Identifiant { get; set; }
    [RegularExpression(@"([A-Za-z0-9]+( [A-Za-z0-9]+)+)", ErrorMessage = "Seulement les chiffres et les lettres sont acceptées")]
    public string? Password { get; set; }
    [RegularExpression(@"([A-Za-z0-9]+( [A-Za-z0-9]+)+)", ErrorMessage = "Seulement les chiffres et les lettres sont acceptées")]
    public string? Nom { get; set; }
    [RegularExpression(@"([A-Za-z0-9]+( [A-Za-z0-9]+)+)", ErrorMessage = "Seulement les chiffres et les lettres sont acceptées")]
    public string? Prenom { get; set; }
}
