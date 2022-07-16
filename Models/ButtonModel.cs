using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilestoneCST_350.Models
{
    public class ButtonModel
    {
        public int Id { get; set; }
        public int State { get; set; }

        public ButtonModel(int id, int state)
        {
            Id = id;
            State = state;
        }

        public ButtonModel() { }
    }
}
