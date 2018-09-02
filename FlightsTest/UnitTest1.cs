using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;
using Moq;
using FlightsCore.Interfaces;
using FlightsCore.Models;
using FlightsWeb.Controllers;
using FlightsWeb.ViewModels;

namespace AcmeFlightsTest
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()         {
            // arrange             var mock = new Mock<IFlightService>();             FlightController home = new FlightController(mock.Object);

            CheckFlightsViewModel checkVM = new CheckFlightsViewModel
            {
                StartDate = new DateTime(2018, 9, 14),
                EndDate = new DateTime(2018, 9, 16),
                NumberOfPax = 3
            };

            // act
            var response = await home.AvialableFlightsAsync(checkVM);

            // assert
            Assert.IsType<BadRequestResult>(response);         }          [Fact]         public void Test2()         {
            /*             var mock = new Mock<IGetDataRepository>();             mock.Setup(p => p.GetNameById(1)).Returns("Jignesh");             HomeController home = new HomeController(mock.Object);             string result = home.GetNameById(1);             Assert.Equal("Jignesh", result);
            */         } 
    }
}
