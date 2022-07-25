
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MilestoneCST_350.Models;
using MilestoneCST_350.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceStack.Host;

namespace MilestoneCST_350.Controllers
{
    public class GameController : Controller, IHttpHandler
    {
        //public GameService gameService = new GameService();
        public IActionResult Index(int difficulty)
        {

            /*
             * 
             * Step one: Set board difficulty,
             * populate board
             * Send view the buttons
             * 
             */
            var gameService = new GameService();
            gameService.GameBoard.Difficulty = 5;
            gameService.PopulateGrid();
            HttpContext.Session.SetObject("game", gameService);
            return View("Index", gameService);
        }

        public IActionResult Difficulty(int difficulty)
        {
            
            return PartialView("Difficulty", difficulty);
        }

        public IActionResult GameResult()
        {
            GameService gameService = new GameService();
            bool win = gameService.CheckForWin();
            if(win == true)
            {
                return View("WinResult");
            }
            else
            {
                return View("LoseResult");
            }
        }

        public void HandleButtonClick(int buttonID)
        {
            var gameService = HttpContext.Session.GetObject<GameService>("game");

            int row = gameService.Buttons[buttonID].Row;
            int column = gameService.Buttons[buttonID].Column;
            gameService.GameBoard.Grid[row, column].Live = true;
            gameService.GameBoard.Grid[row, column].Visited = true;
            gameService.GameBoard.FloodFill(row, column, 10, gameService.GameBoard);
            gameService.UpdateButtonLabels(row, column);

            HttpContext.Session.SetObject("game", gameService);
        }

        public IActionResult ShowOneButton(int buttonID)
        {
            var gameService = HttpContext.Session.GetObject<GameService>("game");

            int row = gameService.Buttons[buttonID].Row;
            int column = gameService.Buttons[buttonID].Column;
            gameService.GameBoard.Grid[row, column].Live = true;
            gameService.GameBoard.Grid[row, column].Visited = true;
            gameService.GameBoard.FloodFill(row, column, 10, gameService.GameBoard);
            gameService.UpdateButtonLabels(row, column);

            foreach (ButtonModel btn in gameService.Buttons)
            {
                btn.State = gameService.GameBoard.Grid[btn.Row, btn.Column].State;
            }

            HttpContext.Session.SetObject("game", gameService);

            return PartialView(gameService.Buttons.ElementAt(buttonID));
        }
    }
}
