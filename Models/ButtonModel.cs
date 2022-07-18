using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilestoneCST_350.Models
{
    public class ButtonModel
    {
        public int Id { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public int State { get; set; }

        public ButtonModel(int Id, int Row, int Column, int State)
        {
            this.Id = Id;
            this.Row = Row;
            this.Column = Column;
            this.State = State;
        }
    }
}
