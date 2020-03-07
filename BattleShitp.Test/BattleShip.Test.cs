using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
namespace BattleShip.Test
{
    [TestClass]
    public class BattleShip_API_Test
    {
        [TestMethod]
        public async Task BattleShip_API_Get_Test()
        {
            var factory = new WebApplicationFactory<Startup>();
            var client = factory.CreateClient();
            //Get 0 game
            var result = await client.GetAsync("/game");
            Assert.AreEqual(System.Net.HttpStatusCode.OK, result.StatusCode);
            var content = result.Content;
            var data = await content.ReadAsStringAsync();
            Assert.IsTrue(data.Contains("0"));
        }

        [TestMethod]
        public async Task BattleShip_API_Creat_Game_Test()
        {
            var factory = new WebApplicationFactory<Startup>();
            var client = factory.CreateClient();
            // Create game
            var result = await client.PostAsync("/game", null);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, result.StatusCode);
            var content = result.Content;
            var data = await content.ReadAsStringAsync();
            Assert.IsTrue(data.Contains("1"));
        }

        [TestMethod]
        public async Task BattleShip_API_AddShip_Test()
        {
            var factory = new WebApplicationFactory<Startup>();
            var client = factory.CreateClient();
            // Create game
            await client.PostAsync("/game", null);
            //Add ship
            var result = await client.PutAsync("/game/1/0/0/0/0", null );
            Assert.AreEqual(System.Net.HttpStatusCode.OK, result.StatusCode);
            var content = result.Content;
            var data = await content.ReadAsStringAsync();
            Assert.IsTrue(data.Contains("1"));
        }

        [TestMethod]
        public async Task BattleShip_API_AttackShip_Test()
        {
            var factory = new WebApplicationFactory<Startup>();
            var client = factory.CreateClient();
            // Create game
            await client.PostAsync("/game", null);
            // Attack empty board
            var result = await client.PutAsync("/game/atack/1/0/0", null);
            Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, result.StatusCode);
            var content = result.Content;
            var data = await content.ReadAsStringAsync();
            Assert.IsTrue(data.Contains("no ships"));
        }

        [TestMethod]
        public async Task BattleShip_API_AddShip_and_AttackShip_Test()
        {
            var factory = new WebApplicationFactory<Startup>();
            var client = factory.CreateClient();
            // Create game
            await client.PostAsync("/game", null);
            // Add ship
            await client.PutAsync("/game/1/0/0/0/0", null);
            // Attack ship 
            var result = await client.PutAsync("/game/atack/1/0/0", null);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, result.StatusCode);
            var content = result.Content;
            var data = await content.ReadAsStringAsync();
            Assert.IsTrue(data.Contains("Game Over"));
        }
    }
}
