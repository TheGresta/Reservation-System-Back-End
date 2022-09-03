//using Core.Exceptions;
//using Core.Utilities.Message.Turkish;
//using Core.Utilities.Result;
//using Moq;
//using RezervationSystem.Business.Services.Concrete;
//using RezervationSystem.DataAccess.Abstract;
//using RezervationSystem.Dto.Concrete;
//using RezervationSystem.Entity.Concrete;
//using System.Linq.Expressions;

//namespace Business.Test
//{
//    public class ReserRentManagerTest
//    {
//        Mock<IReserRentDal> _mockReserDal;

//        public ReserRentManagerTest()
//        {
//            _mockReserDal = new Mock<IReserRentDal>();
//        }

//        [Theory]
//        //ReserRent ıd errors
//        [InlineData(0)]
//        [InlineData(-1)]

//        public async Task Add_WhenInValidInputsAreGiven_ShouldReturnError(int reserID)
//        {
//            Assert.ThrowsAsync<BusinessException>(async () =>
//            {
//                _mockReserDal.Setup(x => x.AddAsync(It.IsAny<ReserRent>())).ReturnsAsync((ReserRent reserRent) => null);

//                ReserRentManager reserRentManager = new ReserRentManager(_mockReserDal.Object, new TurkishLanguageMessage());
//                await reserRentManager.AddAsync(new()
//                {
//                    ReserId = reserID
//                });
//            });
//        }

//        [Fact]
//        public async Task GetListData_When10RowDataReturn_ShouldReturn()
//        {
//            _mockReserDal.Setup(x => x.GetAllAsync(true)).ReturnsAsync(reserRents().ToList());

//            ReserRentManager reserRentManager = new ReserRentManager(_mockReserDal.Object, new TurkishLanguageMessage());
//            IDataResult<List<ReserRentReadDto>> result = await reserRentManager.GetListAsync();

//            Assert.Equal(result.Data.Count, 10);
//        }

//        [Theory, InlineData(1)]
//        public async Task GetById_WhenValidInputGiven_ShouldReturn(int id)
//        {
//            _mockReserDal.Setup(x => x.GetAllAsync(It.IsAny<Expression<Func<ReserRent, bool>>>(), true)).ReturnsAsync(reserRents().ToList());

//            ReserRentManager reserRentManager = new ReserRentManager(_mockReserDal.Object, new TurkishLanguageMessage());
//            IDataResult<ReserRentReadDto> result = await reserRentManager.GetByIdAsync(id);

//            Assert.True(result.Success);
//        }

//        [Theory]
//        [InlineData(0)]
//        [InlineData(-1)]
//        public async Task GetById_WhenInValidInputGiven_ShouldReturnError(int id)
//        {
//            _mockReserDal.Setup(x => x.GetAllAsync(It.IsAny<Expression<Func<ReserRent, bool>>>(), true)).ReturnsAsync(reserRents().ToList());

//            ReserRentManager reserRentManager = new ReserRentManager(_mockReserDal.Object, new TurkishLanguageMessage());
//            IDataResult<ReserRentReadDto> result = await reserRentManager.GetByIdAsync(id);

//            Assert.True(result.Success);

//            Assert.ThrowsAsync<BusinessException>(async () =>
//            {
//                _mockReserDal.Setup(x => x.GetAllAsync(It.IsAny<Expression<Func<ReserRent, bool>>>(), true)).ReturnsAsync(reserRents().ToList());

//                ReserRentManager reserRentManager = new ReserRentManager(_mockReserDal.Object, new TurkishLanguageMessage());
//                await reserRentManager.GetByIdAsync(id);
//            });
//        }

//        private IEnumerable<ReserRent> reserRents()
//        {
//            for (int i = 0; i < 10; i++)
//            {
//                yield return new()
//                {
//                    Id = i,
//                    StartDate = DateTime.Now.AddDays(i),
//                    EndDate = DateTime.Now.AddDays(i+2)
//                };
//            }
//        }
//    }
//}
