using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
public class ObjectModel
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("l")]
    [Display(Name = "Label")]
    [Required(ErrorMessage = "Le {0} de l'objet doit être fourni")]
    [MaxLength(150, ErrorMessage = "Le {0} doit avoir une longueur maximale de {1} charactères")]
    public string Label { get; set; }

    [JsonPropertyName("s")]
    [Display(Name = "Etat")]
    [Required(ErrorMessage = "L'{0} de l'objet doit être fourni")]
    public int State { get; set; }

    [JsonPropertyName("d")]
    [Display(Name = "Description")]
    [Required(ErrorMessage = "La {0} de l'objet doit être fourni")]
    [MaxLength(350, ErrorMessage = "La {0} doit avoir une longueur maximale de {1} charactères")]
    public string Description { get; set; }

    [JsonPropertyName("ido")]
    public Guid IdOwner { get; set; }

    [JsonPropertyName("v")]
    [Display(Name = "Valeur nominale")]
    [Required(ErrorMessage = "La {0} de l'objet doit être fourni")]

    public double Value { get; set; }

    [JsonPropertyName("ud")]
    public DateTime UploadDate { get; set; } = DateTime.Now;
    public UserModel? Owner { get; set; }

    [JsonPropertyName("p")]
    public IEnumerable<PhotoModel>? Photos { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Id == null)
        {
            yield return new ValidationResult("Un id doit être fourni");
        }
        yield return new ValidationResult("Autre erreur si condition true");
    }
}