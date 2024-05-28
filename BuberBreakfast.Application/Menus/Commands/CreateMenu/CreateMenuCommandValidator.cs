using FluentValidation;

namespace BuberBreakfast.Application.Menus.Commands.CreateMenu;

public class CreateMenuCommandValidator : AbstractValidator<CreateMenuCommand>
{
    public CreateMenuCommandValidator()
    {
        RuleFor(x => x.HostId).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();

        RuleForEach(x => x.Sections)
            .ChildRules(section =>
            {
                section.RuleFor(x => x.Name).NotEmpty();
                section.RuleFor(x => x.Description).NotEmpty();
                section.RuleFor(x => x.Items).NotEmpty();

                section
                    .RuleForEach(x => x.Items)
                    .ChildRules(item =>
                    {
                        item.RuleFor(x => x.Name).NotEmpty();
                        item.RuleFor(x => x.Description).NotEmpty();
                    });
            });
    }
}
