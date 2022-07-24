﻿
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
        public IActionResult Index(int difficulty)
        {
            /*
             * 
             * Step one: Set board difficulty,
             * populate board
             * Send view the buttons
             * 
             */
            gameService.GameBoard.Difficulty = difficulty;
            gameService.PopulateGrid();

            return View("Index", gameService);
        }

        public IActionResult Difficulty(int difficulty)
        {

            //GameService gameService = new GameService();
            //gameService.GameBoard.Difficulty = difficulty;
            return PartialView("Index", difficulty);
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

        //public IActionResult HandleButtonClick(string buttonID)
        //{
        //    int btnID = int.Parse(buttonID);
        //    int row = ((btnID - (btnID % 10)) / 10);
        //    int column = btnID % 10;

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
            int row = gameService.Buttons[buttonID].Row;
            int column = gameService.Buttons[buttonID].Column;
            gameService.GameBoard.Grid[row, column].Live = true;
            gameService.GameBoard.Grid[row, column].Visited = true;
            gameService.GameBoard.FloodFill(row, column, 10, gameService.GameBoard);
            gameService.UpdateButtonLabels(row, column);

        }

        public IActionResult ShowOneButton(int buttonID)
        {
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

            return PartialView(gameService.Buttons.ElementAt(buttonID));
        }
    }
}
