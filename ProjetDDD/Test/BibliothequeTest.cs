using Bibliotheque.Application;
using Bibliotheque.Domain.Agregats;
using Bibliotheque.Domain.Entities;
using Bibliotheque.Domain.Events;
using Bibliotheque.Infrastructure;
using Bibliotheque.Infrastructure.Persistance;
using Moq;

namespace Test;

[TestClass]
public class BibliothequeTest
{
    [TestMethod]
    public void GetListBooksTest()
    {
        var mockLibrairy = new Mock<Librairy>();
        mockLibrairy.Setup(l => l.Books).Returns(new List<Book> { new Book(), new Book(), new Book() });
        var librairyService = new LibrairyService(mockLibrairy.Object, null, null);

        var books = librairyService.GetListBooks();

        Assert.IsNotNull(books);
        Assert.AreEqual(3, books.Count);
    }

    [TestMethod]
    public void GetListMembersTest()
    {
        var mockLibrairy = new Mock<Librairy>();
        mockLibrairy.Setup(l => l.Members).Returns(new List<Member> { new Member(), new Member() });
        var librairyService = new LibrairyService(mockLibrairy.Object, null, null);

        var members = librairyService.GetListMembers();

        Assert.IsNotNull(members);
        Assert.AreEqual(2, members.Count);
    }

    [TestMethod]
    public void GetListBorrowingsTest()
    {
        var mockLibrairy = new Mock<Librairy>();
        mockLibrairy.Setup(l => l.Borrowings).Returns(new List<Borrowing> { new Borrowing(), new Borrowing() });
        var librairyService = new LibrairyService(mockLibrairy.Object, null, null);

        var borrowings = librairyService.GetListBorrowings();

        Assert.IsNotNull(borrowings);
        Assert.AreEqual(2, borrowings.Count);
    }

    [TestMethod]
    public void BorrowBookTest()
    {
        var mockLibrairy = new Mock<Librairy>();
        var mockEventDispatcher = new Mock<IEventDispatcher>();
        var mockBorrowingsRepository = new Mock<BorrowingsRepository>();
        mockBorrowingsRepository.Setup(repo => repo.GetAll()).Returns(new List<Borrowing>());
        var librairyService = new LibrairyService(mockLibrairy.Object, mockEventDispatcher.Object, mockBorrowingsRepository.Object);

        var bookId = Guid.NewGuid();
        var memberId = Guid.NewGuid();
        var borrowingDate = DateTime.UtcNow;

        librairyService.BorrowBook(bookId, memberId, borrowingDate);

        mockLibrairy.Verify(l => l.Borrowings.Add(It.IsAny<Borrowing>()), Times.Once);
        mockEventDispatcher.Verify(e => e.Dispatch(It.IsAny<BookBorrowingEvent>()), Times.Once);
    }

    [TestMethod]
    public void BorrowBook_Should_Throw_Exception_When_Book_Is_Not_Available()
    {
        var mockLibrairy = new Mock<Librairy>();
        var mockEventDispatcher = new Mock<IEventDispatcher>();
        var mockBorrowingsRepository = new Mock<BorrowingsRepository>();
        var borrowing = new Borrowing
        {
            BookId = Guid.NewGuid(),
            BorrowingDate = DateTime.UtcNow.AddDays(-1),
            ReturnDate = null
        };
        mockBorrowingsRepository.Setup(repo => repo.GetAll()).Returns(new List<Borrowing> { borrowing });
        var librairyService = new LibrairyService(mockLibrairy.Object, mockEventDispatcher.Object, mockBorrowingsRepository.Object);

        var bookId = borrowing.BookId;
        var memberId = Guid.NewGuid();
        var borrowingDate = DateTime.UtcNow;

        Assert.ThrowsException<Exception>(() => librairyService.BorrowBook(bookId, memberId, borrowingDate));
    }
}
