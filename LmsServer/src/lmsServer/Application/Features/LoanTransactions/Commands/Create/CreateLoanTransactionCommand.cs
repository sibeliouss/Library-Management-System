using Application.Features.LoanTransactions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using Domain.Enums;
using NArchitecture.Core.Mailing;
using MimeKit;

using Application.Services.Members;

using Application.Services.Books;

namespace Application.Features.LoanTransactions.Commands.Create;

public class CreateLoanTransactionCommand : IRequest<CreatedLoanTransactionResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{

    public Guid MemberId { get; set; }
    public Guid BookId { get; set; }
    public ReturnStatus? ReturnStatus { get; set; }
    public DateTime ReturnTime { get; set; }
    
    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetLoanTransactions"];

    public class CreateLoanTransactionCommandHandler : IRequestHandler<CreateLoanTransactionCommand, CreatedLoanTransactionResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILoanTransactionRepository _loanTransactionRepository;
        private readonly LoanTransactionBusinessRules _loanTransactionBusinessRules;
        private readonly IMailService _mailService;
        private readonly IMemberService _memberService;
        private readonly IBookService _bookService;
        public CreateLoanTransactionCommandHandler(IMapper mapper, ILoanTransactionRepository loanTransactionRepository,
                                         LoanTransactionBusinessRules loanTransactionBusinessRules,IMailService mailService,
                                         IMemberService memberService,
                                         IBookService bookService)
        {
            _mapper = mapper;
            _loanTransactionRepository = loanTransactionRepository;
            _loanTransactionBusinessRules = loanTransactionBusinessRules;
            _mailService = mailService;
            _memberService = memberService;
            _bookService = bookService;
        }

        public async Task<CreatedLoanTransactionResponse> Handle(CreateLoanTransactionCommand request, CancellationToken cancellationToken)
        {
            
            LoanTransaction loanTransaction = _mapper.Map<LoanTransaction>(request);
            
            await _loanTransactionRepository.AddAsync(loanTransaction);
            Member? member = await _memberService.GetAsync(predicate: m => m.Id == request.MemberId, cancellationToken: cancellationToken);
            Book? book = await _bookService.GetAsync(predicate : b => b.Id == request.BookId, cancellationToken: cancellationToken);
            Mail mail = new Mail(
                subject: "Kitap Ödünç Alma",
                textBody: " Kitap Ödünç Aldýnýz " +book.Name,
                htmlBody: " Kitap Ödünç Aldýnýz <br> Alýnan Kitap :" +book.Name,
                new List<MailboxAddress>()
                { new(member.Email,member.Email)}
                );
            await _mailService.SendEmailAsync(mail);

            CreatedLoanTransactionResponse response = _mapper.Map<CreatedLoanTransactionResponse>(loanTransaction);

            
            return response;
        }
    }
}