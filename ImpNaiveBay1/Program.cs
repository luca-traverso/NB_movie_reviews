// Implementation of the Multinomial Naive Bayes classifier to classify movie reviews 
// from the popular polarityv2 dataset.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

    namespace ImpNaiveBay1
{
    /// <summary>
    /// This program implements the multinomial Naive Bayes algorithm as described in:
    /// [REF:Speech and Language Processing. Daniel Jurafsky and James H. Martin. Copyright 2016.]
    /// The program starts with loading all the input files required:
    /// 1- the document corpus;
    /// 2- a list of stop words;
    /// 3- 10 fold cross-validation indices.
    /// It then loops through each cross-validation fold carrying out the following steps:
    /// 4- selects the docs for train and test datasets (from document corpus) based on 
    ///     cross-validation indicies for current iteration;
    /// 5- creates a vocabulary based on train dataset;
    /// 6- calculates loglikelihoods and logpriors for each class using the train dataset;
    /// 7- calculates performance on test dataset. 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*************************************************************");
            Console.WriteLine("**********Implementation of Multinomial Naive Bayes**********");
            Console.WriteLine("*********Application to movie review classification**********");
            Console.WriteLine("*************************************************************");
            Console.WriteLine("");
            Console.WriteLine("Fold   TfIdfMNB");

            MovieReviewClassification ClassificationForm = new MovieReviewClassification();
            ClassificationForm.ShowDialog();
            
            
        }

    }
}