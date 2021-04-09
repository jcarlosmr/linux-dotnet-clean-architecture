using System;
using FluentValidation;
using SocialMedia.Core.DTOs;

namespace SocialMedia.Infraestructure.Validators
{
  public class PostDtoValidator : AbstractValidator<PostDto>
  {
    public PostDtoValidator()
    {
      RuleFor(post => post.Description)
        .NotNull()
        .Length(10, 1000);

      RuleFor(post => post.Date)
        .NotNull();
    }
  }
}
