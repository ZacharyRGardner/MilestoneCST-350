using Microsoft.AspNetCore.Mvc;
using MilestoneCST_350.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilestoneCST_350.Controllers
{
    public class GameBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
