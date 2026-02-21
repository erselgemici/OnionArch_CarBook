using FluentValidation;
using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.ContactCommands;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.ContactHandlers
{
    public class CreateContactCommandHandler(IRepository<Contact> _repository, IUnitOfWork _unitOfWork, IValidator<Contact> _validator)
    : IRequestHandler<CreateContactCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = request.Adapt<Contact>();
            contact.SendDate = DateTime.Now;

            var validation = await _validator.ValidateAsync(contact);
            if (!validation.IsValid) return BaseResult<object>.Fail(validation.Errors);

            await _repository.CreateAsync(contact);
            return await _unitOfWork.SaveChangesAsync() ? BaseResult<object>.Success() : BaseResult<object>.Fail("Mesaj gönderilemedi.");
        }
    }
}
