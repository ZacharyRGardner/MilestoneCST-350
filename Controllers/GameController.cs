
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
        static CellModel[,] CellGrid = new CellModel[10,10];

        static BoardModel board = new BoardModel(10);


        static List<ButtonModel> buttons = new List<ButtonModel>();

        static GameService gameService = new GameService();

        public IActionResult Index()
        {

            gameService.CellGrid = CellGrid;
            gameService.PopulateGrid(10);

            if (buttons.Count < 100)
            {
                for (int i = 0; i < 100; i++)
                {
                    buttons.Add(new ButtonModel(i, 0));
                }
            }
            return View("Index", buttons);
        }

        public IActionResult HandleButtonClick(string buttonID)
        {
            int btnID = int.Parse(buttonID);
            int row = ((btnID - (btnID % 10)) / 10);
            int column = btnID % 10;
            
            gameService.GameBoard.FloodFill(row, column, 10, gameService.GameBoard);
            gameService.UpdateButtonLabels(row, column);

                for (int r = 0; r < 10; r++)
                {
                    for (int c = 0; c < 10; c++)
                    {
                        if (gameService.CellGrid[r, c].Visited)
                        {
                            buttons.ElementAt((r * 10) + c).State = 3;
                        }

                    }
                }
            return View("Index", buttons);
        }
    }
}
