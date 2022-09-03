using Core.Exceptions;
using Core.Utilities.Message.Turkish;
using Core.Utilities.Result;
using Moq;
using RezervationSystem.Business.Services.Concrete;
using RezervationSystem.DataAccess.Abstract;
using RezervationSystem.Dto.Concrete;
using RezervationSystem.Entity.Concrete;
using System.Linq.Expressions;

namespace Business.Test
{
    public class ReserManagerTest
    {
        Mock<IReserDal> _mockReserDal;

        public ReserManagerTest()
        {
            _mockReserDal = new Mock<IReserDal>();
        }

        //[Theory]
        //[InlineData("name", "address", "description", 1)]
        //public async Task Add_WhenValidInputsAreGiven_ShouldReturn(string name, string address, string description, decimal price)
        //{
        //    _mockReserDal.Setup(x => x.AddAsync(It.IsAny<Reser>())).ReturnsAsync((Reser reser) => reser);

        //    ReserManager reserManager = new ReserManager(_mockReserDal.Object, new TurkishLanguageMessage());
        //    IResult result = await reserManager.AddAsync(new()
        //    {
        //        Name = name,
        //        Address = address,
        //        Descripton = description,
        //        Price = price
        //    });

        //    Assert.True(result.Success);
        //}

        //[Theory]
        ////name errors
        //[InlineData("", "address", "description", 1)]
        //[InlineData("a", "address", "description", 1)]
        ////address errors
        //[InlineData("name", "", "description", 1)]
        ////description errors
        //[InlineData("name", "address", "", 1)]
        ////price errors
        //[InlineData("name", "address", "description", 0)] 
        //[InlineData("name", "address", "description", -1)]

        //public async Task Add_WhenInValidInputsAreGiven_ShouldReturnError(string name, string address, string description, decimal price)
        //{
        //    Assert.ThrowsAsync<BusinessException>(async () =>
        //    {
        //        _mockReserDal.Setup(x => x.AddAsync(It.IsAny<Reser>())).ReturnsAsync((Reser reser) => null);

        //        ReserManager reserManager = new ReserManager(_mockReserDal.Object, new TurkishLanguageMessage());
        //        await reserManager.AddAsync(new()
        //        {
        //            Name = name,
        //            Descripton = description,
        //            Address = address,
        //            Price = price
        //        });
        //    });
        //}

        //[Fact]
        //public async Task GetListData_When10RowDataReturn_ShouldReturn()
        //{
        //    _mockReserDal.Setup(x => x.GetAllAsync(true)).ReturnsAsync(resers().ToList());

        //    ReserManager reserManager = new ReserManager(_mockReserDal.Object, new TurkishLanguageMessage());
        //    IDataResult<List<ReserReadDto>> result = await reserManager.GetListAsync();

        //    Assert.Equal(result.Data.Count, 10);
        //}

        //[Theory, InlineData(1)]
        //public async Task GetById_WhenValidInputGiven_ShouldReturn(int id)
        //{
        //    _mockReserDal.Setup(x => x.GetAllAsync(It.IsAny<Expression<Func<Reser, bool>>>(), true)).ReturnsAsync(resers().ToList());

        //    ReserManager reserManager = new ReserManager(_mockReserDal.Object, new TurkishLanguageMessage());
        //    IDataResult<ReserReadDto> result = await reserManager.GetByIdAsync(id);

        //    Assert.True(result.Success);
        //}

        //[Theory]
        //[InlineData(0)]
        //[InlineData(-1)]
        //public async Task GetById_WhenInValidInputGiven_ShouldReturnError(int id)
        //{
        //    _mockReserDal.Setup(x => x.GetAllAsync(It.IsAny<Expression<Func<Reser, bool>>>(), true)).ReturnsAsync(resers().ToList());

        //    ReserManager reserManager = new ReserManager(_mockReserDal.Object, new TurkishLanguageMessage());
        //    IDataResult<ReserReadDto> result = await reserManager.GetByIdAsync(id);

        //    Assert.True(result.Success);

        //    Assert.ThrowsAsync<BusinessException>(async () =>
        //    {
        //        _mockReserDal.Setup(x => x.GetAllAsync(It.IsAny<Expression<Func<Reser, bool>>>(), true)).ReturnsAsync(resers().ToList());

        //        ReserManager reserManager = new ReserManager(_mockReserDal.Object, new TurkishLanguageMessage());
        //        await reserManager.GetByIdAsync(id); 
        //    });
        //}

        //private IEnumerable<Reser> resers()
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        yield return new()
        //        {
        //            Id = i,
        //            Name = $"name{i}",
        //            Address = $"address{i}",
        //            Descripton = $"descrpiton{i}",
        //            Price = i,
        //        };
        //    }
        //}
    }
}
