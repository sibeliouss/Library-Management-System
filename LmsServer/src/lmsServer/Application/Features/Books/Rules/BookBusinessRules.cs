using Application.Features.Books.Constants;
using Application.Features.Books.Queries.GetList;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Books.Rules;

public class BookBusinessRules : BaseBusinessRules
{
    private readonly IBookRepository _bookRepository;
    private readonly ILocalizationService _localizationService;

    public BookBusinessRules(IBookRepository bookRepository, ILocalizationService localizationService)
    {
        _bookRepository = bookRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, BooksBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task BookShouldExistWhenSelected(Book? book)
    {
        if (book == null)
            await throwBusinessException(BooksBusinessMessages.BookNotExists);
    }

    public async Task BookIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Book? book = await _bookRepository.GetAsync(
            predicate: b => b.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await BookShouldExistWhenSelected(book);
    }
    public async Task BookShouldBeNotExists(string bookName)
    {
        bool doesExists = await _bookRepository.AnyAsync(predicate: u => u.Name == bookName);
        if (doesExists)
            await throwBusinessException(BooksBusinessMessages.BookAlreadyExists);
    }

  
    /*
    public async Task GetBooksByAuthor(Guid authorId, Guid bookId)
    {
        List<Book> response = await _bookRepository.Query().Where(b => b.AuthorId != authorId && b.Id != bookId)
            .Take(3)
            .ToListAsync();
    }
    */
    
    
}