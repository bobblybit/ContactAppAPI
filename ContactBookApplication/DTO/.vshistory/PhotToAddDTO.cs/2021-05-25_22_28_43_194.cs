using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactBookApplication.DTO
{
    public class PhotToAddDTO
    {
        public IFormFile formFile { get; set; }

    }
}
