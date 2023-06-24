using FluentValidation;

namespace LABCC.BackEnd.Domain.Entities.Usuarios;
internal class UsuarioValidator : AbstractValidator<Usuario>
{

    public UsuarioValidator()
    {
    RuleFor(u => u.Nome)
      .NotEmpty();
    }
}
