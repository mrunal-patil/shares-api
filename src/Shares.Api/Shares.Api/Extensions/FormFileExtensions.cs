using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Shares.Api.Extensions
{
    public static class FormFileExtensions
    {
        public static bool IsValid(this IFormFile file)
        {
            if (Path.GetExtension(file.FileName).Trim().ToLowerInvariant() != ".xlsx")
                return false;

            return true;
        }
    }
}
