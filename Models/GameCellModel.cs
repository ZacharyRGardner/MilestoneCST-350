using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilestoneCST_350.Models
{
    public class GameCellModel
    {
        //properties of each cell on the Game board
        public int RowNumber { get; set; } //row number
        public int ColumnNumber { get; set; } //column number
        public int WarningNumber { get; set; } // warning number to display how many mines are adjacent to the cell
        public bool isVisited { get; set; } //isVisited is yes if the cell has been click and no if it has not been clicked
        public bool isLive { get; set; } //isLive means there is a bomb under the cell

        //sets the parameters for number of rows and columns
        public GameCellModel(int x, int y)
        {
            RowNumber = x;
            ColumnNumber = y;
        }

        public int Size { get; set; } //Size of the gameBoard
        public static GameCellModel[,] gameBoard { get; set; }

        public GameCellModel(int s)
        {
            //initial size of the game board is defined by s
            Size = s;

            gameBoard = new GameCellModel[Size, Size]; //creates the 2d array for the gameboard

            //fills each cell the gameboard
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    gameBoard[i, j] = new GameCellModel(i, j);
                    gameBoard[i, j].isLive = false; //set to false as no bombs have been placed on the gameboard yet
                    gameBoard[i, j].isVisited = false; //set to false as none of the cells have been clicked
                }
            }
        }
        
        public GameCellModel[,] MarkLiveBombs(int bombs)
        {
            int seed = DateTime.Now.Second;
            Random rand = new Random(seed);
            int b = 0;
            int x;
            int y;

            //marks bombs on the gamebaord. each cell is checked 
            while(b < bombs)
            {
                x = rand.Next() % Size;
                y = rand.Next() % Size;

                if (gameBoard[x, y].isLive) //if gamecell has bomb the method will move to the next gameCell and check again
                {
                    continue;
                }
                else
                {
                    gameBoard[x, y].isLive = true;
                    b++;                    //keeps track of the number of bombs are on the game board. We set how many. it will not exceed that limit.
                }
            }
            return gameBoard;
        }

        public GameCellModel[,] MarkNumbers() //method to mark the numbers on the gameboard. The numbers will be set by the number of bombs around them.
        {
            for(int i = 0; i < Size; i++)
            {
                for(int j = 0; j < Size; j++)
                {
                    if(gameBoard[i, j].isLive)
                    {
                        continue;
                    }
                    else
                    {
                        int nearBomb = 0;
                        //if statements to check every cell around a single cell;
                        if (i > 0 && j > 0 && gameBoard[i - 1, j - 1].isLive)
                        {
                            nearBomb++;
                        }
                        if (i > 0 && gameBoard[i - 1, j].isLive)
                        {
                            nearBomb++;
                        }
                        if (i > 0 && j < Size - 1 && gameBoard[i - 1, j + 1].isLive)
                        {
                            nearBomb++;
                        }
                        if (j > 0 && gameBoard[i, j - 1].isLive)
                        {
                            nearBomb++;
                        }
                        if (j < Size - 1 && gameBoard[i, j + 1].isLive)
                        {
                            nearBomb++;
                        }
                        if (i < Size - 1 && j > 0 && gameBoard[i + 1, j - 1].isLive)
                        {
                            nearBomb++;
                        }
                        if (i < Size - 1 && gameBoard[i + 1, j].isLive)
                        {
                            nearBomb++;
                        }
                        if (i < Size - 1 && j < Size - 1 && gameBoard[i + 1, j + 1].isLive)
                        {
                            nearBomb++;
                        }
                        gameBoard[i, j].WarningNumber = nearBomb;
                    }
                }
            }
            return gameBoard;
        }
    }
}
