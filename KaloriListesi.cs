using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asim.Models
{
    public class KaloriListesi
    {
        private List<Kaloriler> _cardLines = new List<Kaloriler>();
        public List<Kaloriler> CartLines
        {
            get
            {
                return _cardLines;
            }

        }
      public void AddProduct(Kalori kaloriler,int quantity)
        {
            var line = _cardLines.FirstOrDefault(i => i.Type.Id == kaloriler.Id);
            if (line == null)
            {
                _cardLines.Add(new Kaloriler() { Type = kaloriler, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public void DeleteProduct(Kalori product)
        {
            _cardLines.RemoveAll(i => i.Type.Id == product.Id);
        }

        public double Total()
        {
            return _cardLines.Sum(i => i.Type.KaloriDegeri * i.Quantity);
        }
        public void Clear()
        {
            _cardLines.Clear();
        }
    }
    public class Kaloriler
    {
        public Kalori Type { get; set; }
        public int Quantity { get; set; }
    }

}