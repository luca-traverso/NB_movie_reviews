// Implementation of the Multinomial Naive Bayes classifier to classify movie reviews 
// from the popular polarityv2 dataset.
// Author: Luca Traverso

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

    namespace ImpNaiveBay1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start Classification of Movie Reviews");
            // load the whole corpus. Maybe this is not efficient but makes things
            // easier with cross-validation
            string root_dir = Directory.GetCurrentDirectory() + "\\txt_sentoken\\";
            //Console.WriteLine(path__);

            List<string> doc_corpus = new List<string>();
            //string root_dir = "C:/Users/trave80/work/UQ/MEngSc/INFS7203/processing_test/txt_sentoken/";
            doc_corpus = load_corpus(root_dir);

            // load stop-words - use the scikit-learn list of stopwords
            string file_stopw = root_dir + "scikit_stopw.txt";
            Dictionary<string, int> dic_stopw = new Dictionary<string, int>();
            load_dictionary(dic_stopw, file_stopw);

            // load train and test indices. These were generated with sciki-learn
            // StratifiedKFold using 10 folds
            int nsplits = 10;
            var (l1, l2) = load_indices(root_dir, nsplits);

            // int vector indicating whether the review is positive or
            // negative. 1: inditcates positive and 0: indicates negative
            int[] labels_ = Enumerable.Repeat(0, 1000).ToArray();
            int[] labels = Enumerable.Repeat(1, 2000).ToArray();
            Array.Copy(labels_, 0, labels, 1000, 1000);

            // now ready for main loop!
            for(int ifold = 0; ifold < nsplits; ifold++)
            {
                // get train and test set
                var (xtrain, xtest, ytrain, ytest) = get_sets(doc_corpus, labels,
                                                              l1[ifold], l2[ifold]);
                // create vocabulary (based only on train corpus)
                Dictionary<string, int> vocab = new Dictionary<string, int>();
                create_vocab(xtrain, dic_stopw, vocab);

                // calculate loglikelihoods, logprior for each class (positive and negative)
                var (loglp, logpp) = nb_proba(vocab, dic_stopw, xtrain, ytrain, "positive");
                var (logln, logpn) = nb_proba(vocab, dic_stopw, xtrain, ytrain, "negative");

                // let's assess the performance of the multinomian Naive Bayes on the test dataset
                double accuracy = test_naive_bayes(vocab, dic_stopw, xtest, ytest, loglp,
                                                   logpp, logln, logpn);

                Console.WriteLine("Accuracy for fold {0} is: {1}%", ifold, accuracy);
                
            }
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

        }

        static List<string> load_corpus(string str)
        {
            // List with documents corpus
            List<string> corpus = new List<string>();

            // load positive reviews first
            string file_name_pos = "list_pos.txt";
            string pos_root = "\\pos\\";
            string file_list_pos = str + pos_root + file_name_pos;

            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(file_list_pos);
            while ((line = file.ReadLine()) != null)
            {
                string[] words = line.Split(' ').Where(s => s != String.Empty).ToArray<string>();
                //Console.WriteLine("file name {0}", words[4]);

                // file that need processing
                string file_to_proc = str + pos_root + words[4];

                // add to corpus
                corpus.Add(load_file(file_to_proc));

            }
            file.Close();

            // load positive reviews first
            string file_name_neg = "list_neg.txt";
            string neg_root = "\\neg\\";
            string file_list_neg = str + neg_root + file_name_neg;

            file = new System.IO.StreamReader(file_list_neg);
            while ((line = file.ReadLine()) != null)
            {
                string[] words = line.Split(' ').Where(s => s != String.Empty).ToArray<string>();
                //Console.WriteLine("file name {0}", words[4]);

                // file that need processing
                string file_to_proc = str + neg_root + words[4];

                // add to corpus
                corpus.Add(load_file(file_to_proc));
            }
            file.Close();

            return corpus;

        }

        static string load_file(string str)
        {
            // build string for review
            string doc_string = "";
            string line2;
            System.IO.StreamReader file2 = new System.IO.StreamReader(str);
            while ((line2 = file2.ReadLine()) != null)
            {
                doc_string += line2;
            }

            file2.Close();

            return doc_string;
        }

        public static (List<List<int>> list1, List<List<int>> list2) 
            load_indices(string str, int splits)
        {
            // create nsplits sublists and add them to list
            // a list for each pair train and test sets
            List<List<int>> list1 = new List<List<int>>();
            List<List<int>> list2 = new List<List<int>>();
            for (int i=0; i<splits; i++)
            {
                List<int> sublist1 = new List<int>();
                list1.Add(sublist1);
                List<int> sublist2 = new List<int>();
                list2.Add(sublist2);
            }

            // file containing indices for train dataset
            string file_train_ind = str + "train_indexes.txt";

            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(file_train_ind);
            // skip header
            line = file.ReadLine();
            while ((line = file.ReadLine()) != null)
            {
                string[] indices = line.Split(',');
                for (int i=1; i<splits+1; i++)
                {
                    int j = Int32.Parse(indices[i]);
                    list1[i - 1].Add(j);
                }
            }
            file.Close();

            // file containing indices for train dataset
            string file_test_ind = str + "test_indexes.txt";

            file = new System.IO.StreamReader(file_test_ind);
            // skip header
            line = file.ReadLine();
            while ((line = file.ReadLine()) != null)
            {
                string[] indices = line.Split(',');
                for (int i = 1; i < splits + 1; i++)
                {
                    int j = Int32.Parse(indices[i]);
                    list2[i - 1].Add(j);
                }
            }
            file.Close();

            return (list1, list2);
        }
        public static (List<string> xtrain, List<string> xtest,
            List<int> ytrain, List<int> ytest) get_sets(List<string> docs, int[] labels,
                                                              List<int> list1, List<int> list2)
        {
            List<string> xtrain = new List<string>();
            List<string> xtest = new List<string>();
            List<int> ytrain = new List<int>();
            List<int> ytest = new List<int>();

            xtrain = select_docs(list1, docs);
            xtest = select_docs(list2, docs);
            ytrain = select_labels(list1, labels);
            ytest = select_labels(list2, labels);

            return (xtrain, xtest, ytrain, ytest);

        }

        public static List<string> select_docs(List<int>l, List<string> d)
        {
            List<string> lst = new List<string>();
            for (int i = 0; i < l.Count; i++)
            {
                lst.Add(d[l[i]]);
            }

            return lst;
        }

        public static List<int> select_labels(List<int> l, int[] d)
        {
            List<int> lst = new List<int>();
            for (int i = 0; i < l.Count; i++)
            {
                lst.Add(d[l[i]]);
            }

            return lst;
        }

        static void load_dictionary(Dictionary<string, int> adictionary,
                                      String file_)
        {
            string stopw;
            System.IO.StreamReader infile = new System.IO.StreamReader(file_);
            while ((stopw = infile.ReadLine()) != null)
            {
                if (!adictionary.ContainsKey(stopw.Trim()))
                {
                    adictionary.Add(stopw.Trim(), 1);
                }
            }

        }

        static void create_vocab(List<string> docs,
                                 Dictionary<string, int> stopw,
                                 Dictionary<string, int> V)
        {
            for(int i=0; i<docs.Count; i++)
            {
                // tockenize the review

                string[] tokens = SplitWords(docs[i]);

                for (var j = 0; j < tokens.Length; j++)
                {
                    // update the term frequency dictionary
                    if (!stopw.ContainsKey(tokens[j]))
                    {
                        // add unique tokens to temporary dictionary
                        if (!V.ContainsKey(tokens[j].Trim()))
                        {
                            V.Add(tokens[j].Trim(), 1);
                        }
                        else
                        {
                            V[tokens[j].Trim()] += 1;
                        }
                    }
                }
            }
        }

        // The regex matches I am using matches words with possession and negations
        // so james and james's are two different words. The same for words like
        // wouldn't or could't, I do not split on the apostrophes.
        static string[] SplitWords(string str)
        {
            //
            // Split on all non-word characters.
            // ... Returns an array of all the words.
            //
            //return Regex.Split(s, @"\W+");
            //return Regex.Split(str.ToLower(), @"\W+").Where(s => s != String.Empty).ToArray<string>();
            //return Regex.Split(str.ToLower(), @"[^a-zA-Z0-9_']").Where(s => s != String.Empty).ToArray<string>();
            //return Regex.Split(str.ToLower(), @"(?i)(?<=^|\s)([a-z]+('[a-z]*)?|'[a-z]+)(?=\s|$)").Where(s => s != String.Empty).ToArray<string>();
            //return Regex.Matches(str.ToLower(), "\\w+('(s|d|t|ve|mon|ll|m|re))?").Cast<Match>().Select(x => x.Value).ToArray();
            // revised to this to allow split with _ as well
            return Regex.Matches(str.ToLower(), "[a-zA-Z0-9]+('(s|d|t|ve|mon|ll|m|re))?").Cast<Match>().Select(x => x.Value).ToArray();

            // @      special verbatim string syntax
            // \W+    one or more non-word characters together
        }

        static void write_vocab(Dictionary<string, int> V, string str)
        {
            string file_out = str + "check_vocab.txt";
            System.IO.StreamWriter outfile = new System.IO.StreamWriter(file_out);

            foreach (var token in V)
            {
                outfile.WriteLine("{0},{1}", token.Key, token.Value);
            }

            outfile.Close();

        }

        public static (Dictionary<string, double>logl, double logp) nb_proba(
            Dictionary<string,int> V, Dictionary<string, int> W, List<string> X, List<int> Y, string driver)
        {
            List<string> Xp = new List<string>();
            Dictionary<string, double> logl = new Dictionary<string, double>();
            Dictionary<string, int> vocab_cat = new Dictionary<string, int>();
            double logp = 0.0;

            // first select reviews for class
            Xp = (driver.Equals("positive") ? select_reviews(X,Y,1) : select_reviews(X,Y,0));

            // create a dictionary(key,count) based on selected class reviews 
            create_vocab(Xp, W, vocab_cat);
            Console.WriteLine(vocab_cat.Count);

            // get the count of vocabulary words in class vocabulary
            // the loglikelihood is calculated as follow [REF:Speech and Language Processing. Daniel Jurafsky & James H. Martin. Copyright 2016.]
            // logl[w,c] = 1 + count(w,c in V) / (sum(count(all w,c in V) + num w in V))
            int count_all_w = 0;
            foreach (var pair in V)
            {
                if (vocab_cat.ContainsKey(pair.Key))
                {
                    // sum(count(all w,c in V)
                    count_all_w += vocab_cat[pair.Key];
                }
            }
            foreach (var pair in V)
            {
                if (vocab_cat.ContainsKey(pair.Key))
                {
                    // logl[w,c]
                    logl.Add(pair.Key,
                        Math.Log((double)(vocab_cat[pair.Key] + 1) / (count_all_w + V.Count)));
                }
                else
                {
                    logl.Add(pair.Key,
                        Math.Log((double)(1) / (count_all_w + V.Count)));
                }
            }

            // calculate the prior
            logp = Math.Log((double)Xp.Count / X.Count);
            //Console.WriteLine("{0} and {1}", Xp.Count, logp);

            return (logl, logp);

        }

        public static List<string> select_reviews(List<string> myXtrain, List<int> myYlabel, int cat)
        {
            List<string> list = new List<string>();
            for(int i=0; i<myXtrain.Count; i++)
            {
                if (myYlabel[i] == cat)
                {
                    list.Add(myXtrain[i]);
                }
            }
            return list;
        }

        // function that tests the NB classifier on unseen reviews
        public static double test_naive_bayes(Dictionary<string, int> V,
                                              Dictionary<string, int> W,
                                              List<string> X, List<int> Y,
                                              Dictionary<string, double> loglp, double logpp,
                                              Dictionary<string, double> logln, double logpn)
        {
            // Y is only used to test the accuracy of the model!
            double accuracy = 0.0;

            int match = 0;

            for (int itest=0; itest<X.Count; itest++)
            {
                double pprob = logpp;
                double nprob = logpn;
                //double pprob_ = 0.0;
                //double nprob_ = 0.0;

                // this new review vocab
                Dictionary<string, int> vocab_test = new Dictionary<string, int>();
                string review = X[itest];
                List<string> creview = new List<string>() { review };
                create_vocab(creview, W, vocab_test);
                //Console.WriteLine(vocab_test.Count);

                foreach (var pair in vocab_test)
                {
                    if (V.ContainsKey(pair.Key))
                    {
                        pprob += (pair.Value * loglp[pair.Key]);
                        nprob += (pair.Value * logln[pair.Key]);
                    }
                }

                //Console.WriteLine("positive: {0} and negative: {1}", pprob, nprob);
                // calculate posterior probability - not use - keep logs, becomes too small
                //pprob_ = Math.Exp(pprob) / (Math.Exp(pprob) + Math.Exp(nprob));
                //nprob_ = Math.Exp(nprob) / (Math.Exp(pprob) + Math.Exp(nprob));

                int pred = (pprob > nprob ? 1 : 0);
                //Console.WriteLine("{0} {1}", pprob_, nprob_);
                match += (pred == Y[itest] ? 1 : 0);
            }
            //Console.WriteLine("{0} {1}", pprob_, nprob_);
            //Console.WriteLine(match);
            accuracy = ((double)match / Y.Count) * 100;

            return accuracy;
        }

    }
}