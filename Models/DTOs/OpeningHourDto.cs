using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DTOs
{
    public class OpeningHourDto
    {
        public string Days { get; set; }
        public string OpeningTime { get; set; }
        public string ClosingTime { get; set; }
    }
}
