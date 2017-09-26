using System;
using DevExpress.Xpo;
using System.Collections.Generic;

namespace ImpNaiveBay1
{
    public enum MovieReviewClass
    {
        Positive,
        Negative
    }
    public class TokenLikelihood
    {
        public string Token { get; set; }
        public double Likelihood { get; set; }
        public double PositiveLogProbability { get; set; }
        public double NegativeLogProbability { get; set; }
    }
    public class MovieReviewAdapter
    {
        public string MovieReviewFileName { get; set; }
        public MovieReviewClass Label  { get; set; }
        public MovieReviewClass PredictedLabel { get; set; }
        public double PosPercentage { get; set; }
        public double NegPercentage { get; set; }
        public List<TokenLikelihood> DocTokens { get; set; }
        public string Content { get; set; }
    }

}