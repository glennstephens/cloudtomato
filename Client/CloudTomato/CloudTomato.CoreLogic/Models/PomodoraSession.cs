using System;
using System.Collections.Generic;
using System.Text;

namespace CloudTomato.CoreLogic.Models
{
    public class PomodoraSession
    {
        public Guid Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Notes { get; set; }
        public Guid ProjectId { get; set; }
    }
}
