using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MadWorld.Business.RustLibrary;
using MadWorld.Shared.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MadWorld.API.Controllers.Rust
{
    [Route("[controller]")]
    public class RustTestController : ControllerBase
    {
        public BaseResponse Index()
        {
            return new BaseResponse()
            {
                Error = false,
                ErrorMessage = LearnLib.plus(1, 2).ToString()
            };
        }
    }
}

