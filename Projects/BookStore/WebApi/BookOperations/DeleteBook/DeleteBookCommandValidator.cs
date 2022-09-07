using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.DeleteBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>    
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0);            
        }
    }

}