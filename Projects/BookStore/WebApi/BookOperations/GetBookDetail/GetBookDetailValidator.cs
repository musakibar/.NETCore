using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBookDetail
{
    public class GetBookDetailValidator : AbstractValidator<GetBookDetailQuery>
    {
        public GetBookDetailValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0);
        }
    }

}