
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
        public GameService gameService = new GameService();

        public IActionResult Index()
        {
            gameService.PopulateGrid();

            return View("Index", gameService.Buttons);
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
