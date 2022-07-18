using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilestoneCST_350.Models
{
    public class BoardModel
    {
        public Dictionary<int, CellModel> Cells = new Dictionary<int, CellModel>();
        public int Size { get; set; }
        public CellModel[,] Grid { get; set; }
        //Difficulty range 1-5.  1 = 10% chance each Cell is live, 5 = 50% of grid live
        public int Difficulty { get; set; }

        public BoardModel(int Size)
        {
            this.Size = Size;
            this.Grid = new CellModel[Size, Size];
            for (int r = 0; r < 10; r++)
            {
                for (int c = 0; c < 10; c++)
                {
                    Grid[r, c] = new CellModel((r* 10) + c, r, c, 0, 0, false, false, false);                 
                }
            }
        }
        public void SetupLiveNeighbors (int Difficulty)
        {
            Random r = new Random();
            switch (Difficulty)
            {
                case 1:
                    for (int i = 0; i < Size; i++)
                    {   // This for loop counts through each column
                        for (int j = 0; j < Size; j++)
                        {
                            int populate = r.Next(1, 101);
                            if (populate < 10)
                            {
                                Grid[i, j].Live = true;
                            }
                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i < Size; i++)
                    {   // This for loop counts through each column
                        for (int j = 0; j < Size; j++)
                        {
                            int populate = r.Next(1, 101);
                            if (populate < 30)
                            {
                                Grid[i, j].Live = true;
                            }
                        }
                    }
                    break;

                case 5:
                    for (int i = 0; i < Size; i++)
                    {   // This for loop counts through each column
                        for (int j = 0; j < Size; j++)
                        {
                            int populate = r.Next(1, 101);
                            if (populate < 50)
                            {
                                Grid[i, j].Live = true;
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        public void CalculateLiveNeighbors()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (Grid[i, j].Live == true)
                    {
                        Grid[i, j].LiveNeighbors = 9;
                        SetLiveNeighbors(i, j);
                    }
                }
            }
        }
        public void SetLiveNeighbors(int r, int c)
        {
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        continue;
                    }
                    if (r + i >= 0 && c + j >= 0 && r + i < Size && c + j < Size)
                    {
                        if (Grid[r + i, c + j].LiveNeighbors < 9)
                        {
                            Grid[r + i, c + j].LiveNeighbors++;
                        }
                    }
                }
            }
        }
        public void FloodFill(int r, int c, int Size, BoardModel gameBoard)
        {
            gameBoard.Grid[r, c].Visited = true;

            if (r < Size && r >= 0 && c + 1 < Size && c + 1 >= 0 && gameBoard.Grid[r, c + 1].LiveNeighbors < 2)
            {
                if (gameBoard.Grid[r, c + 1].Visited == false)
                {
                    if (!gameBoard.Grid[r, c + 1].Flagged)
                    {
                        gameBoard.Grid[r, c + 1].Visited = true;
                    }

                    FloodFill(r, c + 1, Size, gameBoard);
                }
            }
            if (r - 1 < Size && r - 1 >= 0 && c < Size && c >= 0 && gameBoard.Grid[r - 1, c].LiveNeighbors < 2)
            {
                if (gameBoard.Grid[r - 1, c].Visited == false)
                {
                    if (!gameBoard.Grid[r - 1, c].Flagged)
                    {
                        gameBoard.Grid[r - 1, c].Visited = true;
                    }
                    FloodFill(r - 1, c, Size, gameBoard);
                }
            }
            if (r < Size && r >= 0 && c - 1 < Size && c - 1 >= 0 && gameBoard.Grid[r, c - 1].LiveNeighbors < 2)
            {
                if (gameBoard.Grid[r, c - 1].Visited == false)
                {
                    if (!gameBoard.Grid[r, c - 1].Flagged)
                    {
                        gameBoard.Grid[r, c - 1].Visited = true;
                    }
                    FloodFill(r, c - 1, Size, gameBoard);
                }
            }
            if (r + 1 < Size && r + 1 >= 0 && c < Size && c >= 0 && gameBoard.Grid[r + 1, c].LiveNeighbors < 2)
            {
                if (gameBoard.Grid[r + 1, c].Visited == false)
                {
                    if (!gameBoard.Grid[r + 1, c].Flagged)
                    {
                        gameBoard.Grid[r + 1, c].Visited = true;
                    }
                    FloodFill(r + 1, c, Size, gameBoard);
                }
            }
            if (r + 1 < Size && r + 1 >= 0 && c + 1 < Size && c + 1 >= 0 && gameBoard.Grid[r + 1, c + 1].LiveNeighbors < 2)
            {
                if (gameBoard.Grid[r + 1, c + 1].Visited == false)
                {
                    if (!gameBoard.Grid[r + 1, c + 1].Flagged)
                    {
                        gameBoard.Grid[r + 1, c + 1].Visited = true;
                    }
                    FloodFill(r + 1, c + 1, Size, gameBoard);
                }
            }
            if (r - 1 < Size && r - 1 >= 0 && c + 1 < Size && c + 1 >= 0 && gameBoard.Grid[r - 1, c + 1].LiveNeighbors < 2)
            {
                if (gameBoard.Grid[r - 1, c + 1].Visited == false)
                {
                    if (!gameBoard.Grid[r - 1, c + 1].Flagged)
                    {
                        gameBoard.Grid[r - 1, c + 1].Visited = true;
                    }
                    FloodFill(r - 1, c + 1, Size, gameBoard);
                }
            }
            if (r + 1 < Size && r + 1 >= 0 && c - 1 < Size && c - 1 >= 0 && gameBoard.Grid[r + 1, c - 1].LiveNeighbors < 2)
            {
                if (gameBoard.Grid[r + 1, c - 1].Visited == false)
                {
                    if (!gameBoard.Grid[r + 1, c - 1].Flagged)
                    {
                        gameBoard.Grid[r + 1, c - 1].Visited = true;
                    }
                    FloodFill(r + 1, c - 1, Size, gameBoard);
                }
            }
            if (r - 1 < Size && r - 1 >= 0 && c - 1 < Size && c - 1 >= 0 && gameBoard.Grid[r - 1, c - 1].LiveNeighbors < 2)
            {
                if (gameBoard.Grid[r - 1, c - 1].Visited == false)
                {
                    if (!gameBoard.Grid[r - 1, c - 1].Flagged)
                    {
                        gameBoard.Grid[r - 1, c - 1].Visited = true;
                    }
                    FloodFill(r - 1, c - 1, Size, gameBoard);
                }
            }
        }
        // For given cell, check all 8 directions. up left diagonal, if no live neighbors set visited
    }
}
