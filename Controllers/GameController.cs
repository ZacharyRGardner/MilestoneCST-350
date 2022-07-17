
using Microsoft.AspNetCore.Mvc;
using MilestoneCST_350.Models;
using MilestoneCST_350.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilestoneCST_350.Controllers
{
    public class GameController : Controller
    {         

        public IActionResult Index(int difficulty)
        {
            GameService gameService = new GameService();
            gameService.GameBoard.Difficulty = difficulty;
            gameService.PopulateGrid();

            return View("Index", gameService.GameBoard.Buttons);
        }

        public IActionResult Difficulty(int difficulty)
        {
            //GameService gameService = new GameService();
            //gameService.GameBoard.Difficulty = difficulty;
            return PartialView();
        }

        public IActionResult GameResult()
        {
            return View();
        }

        //public IActionResult HandleButtonClick(string buttonID)
        //{
        //    int btnID = int.Parse(buttonID);
        //    int row = ((btnID - (btnID % 10)) / 10);
        //    int column = btnID % 10;
            
        //    gameService.GameBoard.FloodFill(row, column, 10, gameService.GameBoard);
        //    gameService.UpdateButtonLabels(row, column);

        //        for (int r = 0; r < 10; r++)
        //        {
        //            for (int c = 0; c < 10; c++)
        //            {
        //                if (gameService.CellGrid[r, c].Visited)
        //                {
        //                    buttons.ElementAt((r * 10) + c).State = 3;
        //                }

        //            }
        //        }
        //    return View("Index", buttons);
        //}
    }
}
