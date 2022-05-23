using AutoMapper;
using Contract;
using FrenzyAPI.ServiceCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Models.DTOs;
using Moq;
using System.Collections.Generic;

namespace FrenzyApi.Test.ServiceCoreTest
{
    [TestClass]
    public class WhenRequestHandlerCalled:Specification
    {
        private Mock<IResturantRepository> _restaurant;
        private Mock<IUsersRepository> _user;
        private IRequestHandler _handler;
        private List<Restaurant> _restaurantdata;
        private List<User> _userData;
        private List<RestaurantDto> _result;
        private Mock<IMapper> _mapper;
        protected override void Given()
        {
            _restaurant = new Mock<IResturantRepository>();
            _user = new Mock<IUsersRepository>();
            _mapper = new Mock<IMapper>();
            _restaurantdata = SerializeHelper.GetObject<List<Restaurant>>(@"DataFiles\RestaurantsTest.json", typeof(List<Restaurant>));
            _userData = SerializeHelper.GetObject<List<User>>(@"DataFiles\UsersTest.json", typeof(List<User>));
            _restaurant.Setup(x => x.GetResturantsAsync()).ReturnsAsync(_restaurantdata);
            _user.Setup(x => x.GetUsersAsync()).ReturnsAsync(_userData);
            _handler = new RequestHandler(_restaurant.Object, _user.Object, _mapper.Object) ;
        }
        protected override void When()
        {
            _result = _handler.GetResturants(new RestaurantParams { Day = "Sun", Time = "15:45" }).GetAwaiter().GetResult();
        }
        [TestMethod]
        public void When_GetResturants_Called()
        {
            Assert.IsNotNull(_result);
        }

        [TestMethod]
        public void When_GetUsersCalled()
        {
            var result = _handler.GetUsers();
            Assert.IsNotNull(result);
        }
    }
}
