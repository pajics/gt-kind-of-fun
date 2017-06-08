using System.Threading;
using Microsoft.AspNetCore.Mvc;
using NrgsCodingChallenge.Controllers;
using NrgsCodingChallenge.Models;
using NrgsCodingChallenge.Repositories;
using Xunit;

namespace NrgsCodingChallenge.UnitTests.Controllers
{
    public class PlayersControllersTests
    {
        [Fact]
        public async void GetById_WithCorrectId_ReturnsCorrectPlayer()
        {
            var player = new Player(
                42,
                "Doe",
                "John",
                new Address("Infinite Loop", "1/1/2", "1234", "Los Angeles", "Californication"),
                "john.doe@example.com",
                "jodo");
            var dataProvider = new DataProvider(player);
            var controller = new PlayersController(dataProvider);

            var actualPlayer =(Player) ((ObjectResult) await controller.GetById(42, CancellationToken.None)).Value;

            Assert.Equal(42, actualPlayer.Id);
        }

        [Fact]
        public async void GetById_WithIncorrectId_Throws404()
        {
            var controller = new PlayersController(new DataProvider());

            NotFoundResult foundResult = await controller.GetById(42, CancellationToken.None) as NotFoundResult;

            Assert.NotNull(foundResult);
        }
    }
}