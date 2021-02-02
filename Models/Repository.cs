using System;
using System.Collections.Generic;

namespace Nefis413Assignment3.Models
{
    public static class Repository
    {
        private static List<AddMovie> responses = new List<AddMovie>();
        public static IEnumerable<AddMovie> Responses => responses;
        public static void AddResponse(AddMovie response)
        {
            responses.Add(response);
        }
    }
}
