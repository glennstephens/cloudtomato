using System;

namespace CloudTomato.CoreLogic.Models
{
    public class Project
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public double HourlyRate { get; set; }
        public string Notes { get; set; }
    }
}
