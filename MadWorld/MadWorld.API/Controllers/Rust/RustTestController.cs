using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MadWorld.Business.RustLibrary.Test;
using MadWorld.Shared.Web.Models;
using MadWorld.Shared.Web.Models.Rust;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MadWorld.API.Controllers.Rust
{
    [Route("[controller]")]
    public class RustTestController : ControllerBase
    {
        [HttpGet]
        public BaseResponse Index()
        {
            return new BaseResponse()
            {
                Error = false,
                ErrorMessage = LearnLib.plus(1, 2).ToString()
            };
        }

        [HttpGet]
        [Route("StructTest")]
        public TestResponse StructTest()
        {
            TestStruct structTest = LearnLib.test_struct_plus(1, 2);

            return new TestResponse
            {
                Error = false,
                ID = structTest.id,
                Answer = structTest.answer
            };
        }

        [HttpGet]
        [Route("StringTest")]
        public BaseResponse StringTest()
        {
            StringStruct structTest = LearnLib.test_struct_string();

            return new BaseResponse
            {
                Error = false,
                ErrorMessage = $"{structTest.id}: {structTest.AnswerToString}",
            };
        }
    }
}

