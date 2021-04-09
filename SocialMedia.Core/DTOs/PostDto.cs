using System;

namespace SocialMedia.Core.DTOs
{
  public class PostDto
  {
    public int PostId { get; set; }
    public int UserId { get; set; }
    public DateTime? Date { get; set; } // El simbolo ? convierte la propiedad en opcional, puede ser nula
    public string Description { get; set; }
    public string Image { get; set; }
  }
}