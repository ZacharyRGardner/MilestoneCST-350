using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilestoneCST_350.Models
{
    public class CellModel
    {
        public int Id { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public int State { get; set; }
        public int LiveNeighbors { get; set; }
        public Boolean Visited { get; set; }
        public Boolean Live { get; set; }
        public Boolean Flagged { get; set; }
        public CellModel(int Row, int Column, int State, int LiveNeighbors, Boolean Visited, Boolean Live, Boolean Flagged)
        {
            this.Row = Row;
            this.Column = Column;
            this.State = State;
            this.LiveNeighbors = 0;
            this.Visited = false;
            this.Live = false;
            this.Flagged = false;
        }
        public CellModel() { }
    }
}
