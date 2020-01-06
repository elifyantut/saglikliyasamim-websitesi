using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asim.Models
{
    public class Kalori
    {
        public int Id { get; set; }
        public string BesinAdı { get; set; }
        public string Resimler { get; set; }
        public int Miktar { get; set; }
        public double KaloriDegeri { get; set; }
        public string Açıklamsı { get; set; }
        public bool saglik { get; set; }
    }
}