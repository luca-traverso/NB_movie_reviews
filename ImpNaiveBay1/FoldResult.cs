using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpNaiveBay1
{
    public class FoldResult
    {
        public string FoldName { get; set; }
        public double Accuracy { get; set; }
        public double Status { get; set; }
        public List<MovieReviewAdapter> TestResults { get; set; }
    }
}
