using Application.Features.Members.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using MimeKit;
using NArchitecture.Core.Mailing;

namespace Application.Features.Members.Commands.Update;

public class UpdateMemberCommand : IRequest<UpdatedMemberResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

   

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMembers"];

    public class UpdateMemberCommandHandler : IRequestHandler<UpdateMemberCommand, UpdatedMemberResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMemberRepository _memberRepository;
        private readonly MemberBusinessRules _memberBusinessRules;
        private readonly IMailService _mailService;

        public UpdateMemberCommandHandler(IMapper mapper, IMemberRepository memberRepository,
                                         MemberBusinessRules memberBusinessRules,
                                         IMailService mailService)
        {
            _mapper = mapper;
            _memberRepository = memberRepository;
            _memberBusinessRules = memberBusinessRules;
            _mailService = mailService;
        }

        public async Task<UpdatedMemberResponse> Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
        {
            Member? member = await _memberRepository.GetAsync(predicate: m => m.Id == request.Id, cancellationToken: cancellationToken);
            await _memberBusinessRules.MemberShouldExistWhenSelected(member);
            member = _mapper.Map(request, member);
            Mail mail = new Mail(
                subject: "Hesap Bilgileri Güncellendi",
                textBody: " Hesap Bilgileri Güncellendi " ,
                htmlBody: "Hesap Bilgileri Güncellendi" ,
                new List<MailboxAddress>()
                { new(request.Email,request.Email)}
                );
            await _mailService.SendEmailAsync(mail);
            await _memberRepository.UpdateAsync(member!);

            UpdatedMemberResponse response = _mapper.Map<UpdatedMemberResponse>(member);
            return response;
        }
    }
}