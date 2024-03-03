using BookShop.Domain.Models.Api.Books;
using FluentValidation;

namespace BookShop.Service.Services.Books.Validate;

public class BooksCreateOrUpdateValidator : AbstractValidator<BooksCreateOrUpdateParameters>
{
    public BooksCreateOrUpdateValidator()
    {
        RuleFor(x => x.Name)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("The book name can't be empty")
            .MinimumLength(2)
            .WithMessage("The book name is too short")
            .MaximumLength(512)
            .WithMessage("The book name is too long");
    }
    
}