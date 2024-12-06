using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminHostelManager.Models
{
    internal class AttendanceModel
    {
        private int AttendanceID {  get; set; }
        private int StudentID {  get; set; }
        private string Date {  get; set; }
        private int TimeIn {  get; set; }
        private int TimeOut { get; set; }
    }
}
