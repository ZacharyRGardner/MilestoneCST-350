using MilestoneCST_350.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilestoneCST_350.Services
{
    public class GameService
    {
        // grid of buttons, id 0 - 99
        // cellgrid, gameboard, size, cellmodel grid
        public BoardModel GameBoard = new BoardModel(10);
        public GameService() { }

        public void PopulateGrid()
        {
            GameBoard.SetupLiveNeighbors(GameBoard.Difficulty);
            GameBoard.CalculateLiveNeighbors();
            for (int r = 0; r < 10; r++)
            {
                for (int c = 0; c < 10; c++)
                {
                    GameBoard.Buttons.Add(GameBoard.Grid[r, c]);
                }
            }
            
        }
        // On click method
        //private void Grid_Button_Click(object sender, MouseEventArgs e)
        //{
        //    string[] strArr = (sender as Button).Tag.ToString().Split('|');
        //    int r = int.Parse(strArr[0]);
        //    int c = int.Parse(strArr[1]);

        //    if (e.Button == MouseButtons.Left)
        //    {
        //        gameBoard.FloodFill(r, c, 10, gameBoard);
        //        UpdateButtonLabels(r, c);
        //    }
        //    if (e.Button == MouseButtons.Right)
        //    {
        //        if (!gameBoard.Grid[r, c].Visited)
        //        {
        //            if (!gameBoard.Grid[r, c].Flagged)
        //            {
        //                gameBoard.Grid[r, c].Flagged = true;
        //                btnGrid[r, c].BackgroundImage = MinesweeperGUI.Properties.Resources.minesweeperFlag; ;
        //            }
        //            else
        //            {
        //                btnGrid[r, c].BackgroundImage = null;
        //                gameBoard.Grid[r, c].Flagged = false;
        //            }
        //        }
        //        else
        //        {
        //            return;
        //        }
        //    }
        //    CheckForWin();
        //}
        public void UpdateButtonLabels(int r, int c)
        {
            if (GameBoard.Grid[r, c].Live == true)
            {
                RevealBoard(r, c);
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (GameBoard.Grid[i, j].Flagged == true)
                        {
                            // Change image to flagged image
                            GameBoard.Grid[i, j].State = 2;
                        }
                        else
                        {
                            if (GameBoard.Grid[i, j].Visited == true)
                            {
                                // Change text to number of live neighbors
                                GameBoard.Grid[i, j].State = 1;
                            }
                        }
                    }
                }
            }
        }
        public void CheckForWin()
        {
            // Count LiveAndFlagged and Visited Cells.  If they equal full board, you win
            int LiveAndFlagged = 0;
            int Visited = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (GameBoard.Grid[i, j].Visited)
                    {
                        Visited++;
                    }
                    if (GameBoard.Grid[i, j].Live && GameBoard.Grid[i, j].Flagged)
                    {
                        LiveAndFlagged++;
                    }

                }
            }
            if (LiveAndFlagged + Visited == 100)
            {
                return //something;           
            }
        }
        public void RevealBoard(int r, int c)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (GameBoard.Grid[i, j].Live)
                    {
                        //Change image to failure image
                        GameBoard.Grid[i, j].State = 3;
                    }
                    else
                    {
                        GameBoard.Grid[i, j].Flagged = false;
                        // Set text to how many live neighbors the cell has
                        
                    }
                }
            }


            // Code for failure message
        }

    }
}
