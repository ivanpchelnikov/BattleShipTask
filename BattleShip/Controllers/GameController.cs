﻿using System;
using Microsoft.AspNetCore.Mvc;

namespace BattleShip.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameValidateHandler _gameValidateHandler;
        private readonly IGameDataHandler _gameDataHandler;

        public GameController()
        {
            _gameValidateHandler = new GameValidateHandler();
            _gameDataHandler = new GameDataHandler();
        }

        [HttpGet]
        public ActionResult Get()
        {
            var numOfGames = _gameDataHandler.Get();
            return Ok($"Total number of games: {numOfGames}");
        }
        [HttpPost]
        public ActionResult Create()
        {
            var game = _gameDataHandler.Create();
            return Ok(game.Id);
        }
        [HttpPut]
        [Route("{id}/{startX}/{endX}/{startY}/{endY}")]
        public ActionResult AddShip(int id, int startX, int endX, int startY, int endY)
        {
            try
            {
                _gameValidateHandler.AddShip(id, startX, endX, startY, endY);
                var resultId = _gameDataHandler.AddShip(id, startX, endX, startY, endY);
                return Ok($"Ship was added succesfully to the game Id {resultId}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Ship was not added. {ex.Message}");
            }

        }
        [HttpPut]
        [Route("attack/{id}/{x}/{y}")]
        public ActionResult Attack(int id, int x, int y)
        {
            try
            {
                _gameValidateHandler.AttackShip(id, x, y);
                var result = _gameDataHandler.AttackShip(id, x, y);
                if (result == Cell.Missed)
                {
                    return Ok($"Missed.");
                }
                else if (result == Cell.Ship)
                {
                    return Ok($"Ship");
                }
                return Ok($"Congratulation all ships are sinked. Game Over! ");
            }
            catch (Exception ex)
            {
                return BadRequest($"Ship was not atacked. {ex.Message}");
            }
        }
    }
}
