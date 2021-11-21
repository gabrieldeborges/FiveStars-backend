using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace TestProject1.Infra
{

    public class ClientTestInfra : IClassFixture<WebApplicationFactory<FIVESTARS.API.Startup>>
    {
        //[Theory]
        //[MemberData(nameof(GetClients))]
        //public void ShouldCreateNewClient(Client client)
        //{
        //    //Setup DbContext and DbSet mock  
        //    var dbContextMock = new Mock<Context>();
        //    var dbSetMock = new Mock<DbSet<Client>>();
        //    dbSetMock.Setup(s => s.Update(new Client() ).Returns(Task.FromResult(new Product()));
        //    dbContextMock.Setup(s => s.Set<Product>()).Returns(dbSetMock.Object)

        //    //Execute method of SUT (ProductsRepository)  
        //    var productRepository = new ProductsRepository(dbContextMock.Object);
        //    var product = productRepository.GetByIdAsync(Guid.NewGuid()).Result;

        //    //Assert  
        //    Assert.NotNull(product);
        //    Assert.IsAssignableFrom<Product>(product);

        //}

        //[Fact]
        //public void Find_TestClassObjectPassed_ProperMethodCalled()
        //{
        //    var testObject = new Client() { ID = 1 };
        //    var testList = new List<Client>() { testObject };

        //    var dbSetMock = new Mock<DbSet<Client>>();
        //    dbSetMock.As<IQueryable<Client>>().Setup(x => x.Provider).Returns(testList.AsQueryable().Provider);
        //    dbSetMock.As<IQueryable<Client>>().Setup(x => x.Expression).Returns(testList.AsQueryable().Expression);
        //    dbSetMock.As<IQueryable<Client>>().Setup(x => x.ElementType).Returns(testList.AsQueryable().ElementType);
        //    dbSetMock.As<IQueryable<Client>>().Setup(x => x.GetEnumerator()).Returns(testList.AsQueryable().GetEnumerator());

        //    var context = new Mock<Context>();
        //    context.Setup(x => x.Set<Client>()).Returns(dbSetMock.Object);

        //    var repository = new ClientRepository(context.Object);

        //    var result = repository.SearchClients();

        //    Assert.Equal(testList, result);
        //}


        //public static IEnumerable<object[]> GetClients
        //{
        //    get
        //    {
        //        return new[]
        //        {
        //            new object[]
        //            {
        //                new Client() {NOME = "XUNIT", EMAIL = "teste@GMAIL.COM", CEP = "04824090", CPF = "41079944855", BIRTH_DATE = DateTime.Now}
        //            },new object[]
        //            {
        //                new Client() {NOME = "XUNIT2", EMAIL = "teste@GMAIL.COM", CEP = "04824090", CPF = "41079944855", BIRTH_DATE = DateTime.Now}
        //            }
        //        };
        //    }
        //}

        //[Fact]
        //public void Add_WhenHaveNoEmail()
        //{
        //    IClientRepository sut = GetInMemoryPersonRepository();
        //    var cli = new Client() { NOME = "XUNIT2", EMAIL = "teste@GMAIL.COM", CEP = "04824090", CPF = "41079944855", BIRTH_DATE = DateTime.Now };

        //    var retorno = sut.SaveClient(cli);

        //    Assert.NotNull(sut.SearchClients());
        //    Assert.Equal("fred", cli.NOME);
        //    Assert.Equal("teste@GMAIL.COM", cli.EMAIL);
        //}

        //private IClientRepository GetInMemoryPersonRepository()
        //{
        //    DbContextOptions<Context> options;
        //    var builder = new DbContextOptionsBuilder<Context>();
        //    options = builder.Options;
        //    Context personDataContext = new Context(options);
        //    personDataContext.Database.EnsureDeleted();
        //    personDataContext.Database.EnsureCreated();
        //    return new ClientRepository(personDataContext);
        //}


    }
}
