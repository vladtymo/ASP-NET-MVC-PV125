﻿using Core.DTOs;
using FluentValidation;

namespace Core.Validators
{
    public class ProductValidators : AbstractValidator<CreateProductDto>
    {
        public ProductValidators()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2);

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0).WithMessage("Value {PropertyValue} is incorrect. {PropertyName} must be greater than or equal to 0");

            RuleFor(x => x.Image)
                .NotNull().WithMessage("Product image is required!");

            //RuleFor(x => x.ImagePath)
            //    .Must(LinkMustBeAUri).WithMessage("{PropertyName} has incorrect URL format");
        }

        private static bool LinkMustBeAUri(string? link)
        {
            if (string.IsNullOrWhiteSpace(link))
            {
                return false;
            }

            //Courtesy of @Pure.Krome's comment and https://stackoverflow.com/a/25654227/563532
            Uri outUri;
            return Uri.TryCreate(link, UriKind.Absolute, out outUri)
                   && (outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps);
        }
    }
}
