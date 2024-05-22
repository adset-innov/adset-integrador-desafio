﻿using ADSET.Application.DTOs.Request;
using FluentValidation;

namespace ADSET.Application.Validators
{
    public class FilterPaginationRequestValitador : AbstractValidator<FilterPaginationRequest>
    {
        public FilterPaginationRequestValitador()
        {
            RuleFor(x => x.QtdPerPage)
                .GreaterThan(10)
                .LessThan(100)
                .NotNull()
                .NotEmpty()
                .WithMessage("Por favor envie uma quantidade valida de itens por página");

            RuleFor(x => x.PaginaAtual)
                .NotNull()
                .NotEmpty()
                .WithMessage("Por favor envie um valor");
        }
    }
}
