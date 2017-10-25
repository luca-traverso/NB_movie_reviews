#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Linear Support Vector Machine Movie Review Sentiment Analysis
This code was inspired by:
     Unknown. (2017). Sentiment Analysis using Tf-Idf weighting: Python/Scikit-learn. 
     [online] Machine Learning in Action. 
     Available at: https://appliedmachinelearning.wordpress.com/2017/02/12/
     sentiment-analysis-using-tf-idf-weighting-pythonscikit-learn/ 
     [Accessed 3 Sep. 2017].
"""

import os
import numpy as np
from sklearn.metrics import precision_score
from sklearn.metrics import recall_score
from sklearn.metrics import accuracy_score
from sklearn.metrics import f1_score
from sklearn.svm import LinearSVC
from sklearn.feature_extraction.text import TfidfVectorizer
from sklearn.model_selection import StratifiedKFold
from sklearn.feature_extraction.text import CountVectorizer
from sklearn.metrics import confusion_matrix
import pandas as pd
import csv

TOTAL_NUM_REVIEWS = 2000
NUM_NEG_REVIEWS = 1000
NUM_POS_REVIEWS = 1000

"""
Generate the dataset from the text file reviews by loading them into memory.
The function relies on negative reviews being placed in a folder called 'neg'
and the positive reviews being placed in a folder called 'pos'. 
@returns    corpus    The dataset containg the reviews. Negative reviews are
                      first followed by positive reviews.
"""
def make_corpus():
    corpus = []
    neg_reviews = ""
    pos_reviews = ""
    for dir in os.listdir("."):
        #print(dir)
        if dir == "neg":
            neg_reviews = os.path.join(os.getcwd(), dir)
            #print(neg_reviews)
        if dir == "pos":
            pos_reviews = os.path.join(os.getcwd(), dir)
    for file in os.listdir(neg_reviews):
        review_contents = ""
        filepath = neg_reviews + "\\" + file
        with open(filepath, 'r') as review:
            for line in review:
                review_contents = review_contents + line
        corpus.append(review_contents)
    for file in os.listdir(pos_reviews):
        review_contents = ""
        filepath = pos_reviews + "\\" + file
        with open(filepath, 'r') as review:
            for line in review:
                review_contents = review_contents + line
        corpus.append(review_contents)
    return corpus         

#Create a corpus with each document having one string
corpus = make_corpus()

#Read the full vocabulary list into a dictionary.
vocab_dict = []
file = open("vocab_not_reduced.txt", "r")
for line in file:
    a = line.split()
    vocab_dict.append(a[0])
file.close

#Read the reduced vocabulary list into a dictionary.
reduced_vocab_dict = []
file = open("vocab_reduced.txt", "r")
for line in file:
    a = line.split()
    reduced_vocab_dict.append(a[0])
file.close

#Label the data as positive (1) and negative (0).
#The first 1000 reviews are from the negative reviews (txt_sentoken/neg).
#The second thousand reviews are from the positive reviews (txt_sentoken/pos).
labels = np.zeros(TOTAL_NUM_REVIEWS);
labels[0:NUM_NEG_REVIEWS] = 0;
labels[NUM_NEG_REVIEWS:NUM_NEG_REVIEWS + NUM_POS_REVIEWS] = 1; 

"""
Case 1a: SVM standard, no negation, with vocab from the reviews.
Case 2a: V not reduced, negation not handled 
         Stratified cross validation with 10 splits, tf-idf with min_df = 0, 
         max_df and max_features to a large value.
Case 3a: V reduced, negation not handled
         Stratified cross validation with 10 splits, tf-idf with min_df = 5, 
         max_df = 0.8 and max_features = 10 000.
"""

#Specify cross validation with 10 folds.
kfold = StratifiedKFold(n_splits = 10)
#Specify the type of model. Here, a linear support vector classification is 
#being used as the SVM model type.
case_1a = LinearSVC()
case_2a = LinearSVC()
case_3a = LinearSVC()
   
iteration = 0            
for train, test in kfold.split(corpus, labels):
    #Partition into the test and training sets.
    x_train = [corpus[i] for i in train]
    x_test = [corpus[i] for i in test]
    y_train = labels[train]
    y_test = labels[test]
    
    #Fit the model and test.
    #Case 1a
    vectorizer_1a = CountVectorizer(input = corpus, stop_words = 'english', 
                                    vocabulary = vocab_dict)
    train_corpus_1a = vectorizer_1a.fit_transform(x_train)
    test_corpus_1a = vectorizer_1a.transform(x_test)
    case_1a.fit(train_corpus_1a, y_train)
    result_1a = case_1a.predict(test_corpus_1a)
    
    #Case 2a
    #500 000 was used for max_features to ensure it was overly large
    vectorizer_2a = TfidfVectorizer(min_df = 0, max_df = 1, 
                                    max_features = 500000, use_idf = True, 
                                    stop_words = 'english',
                                    vocabulary = vocab_dict)
    train_corpus_2a = vectorizer_2a.fit_transform(x_train)
    test_corpus_2a = vectorizer_2a.transform(x_test)
    case_2a.fit(train_corpus_2a, y_train)
    result_2a = case_2a.predict(test_corpus_2a)
    
    #Case 3a
    vectorizer_3a = TfidfVectorizer(min_df = 5, max_df = 0.8, 
                                    max_features = 10000, use_idf = True,
                                    stop_words = 'english', 
                                    vocabulary = reduced_vocab_dict)
    train_corpus_3a = vectorizer_3a.fit_transform(x_train)
    test_corpus_3a = vectorizer_3a.transform(x_test)
    case_3a.fit(train_corpus_3a, y_train)
    result_3a = case_3a.predict(test_corpus_3a)

    #Get the accuracy scores
    accuracy_1a = accuracy_score(y_test, result_1a) * 100
    accuracy_2a = accuracy_score(y_test, result_2a) * 100
    accuracy_3a = accuracy_score(y_test, result_3a) * 100

    #Get the precision scores
    precision_1a = "{0:0.2f}".format(precision_score(y_test, result_1a) * 100)
    precision_2a = "{0:0.2f}".format(precision_score(y_test, result_2a) * 100)
    precision_3a = "{0:0.2f}".format(precision_score(y_test, result_3a) * 100)
    #Get the recall scores
    recall_1a = "{0:0.2f}".format(recall_score(y_test, result_1a) * 100)
    recall_2a = "{0:0.2f}".format(recall_score(y_test, result_2a) * 100)
    recall_3a = "{0:0.2f}".format(recall_score(y_test, result_3a) * 100)
    #Get the f1-scores
    f1_1a = "{0:0.2f}".format(f1_score(y_test, result_1a) * 100) 
    f1_2a = "{0:0.2f}".format(f1_score(y_test, result_2a) * 100) 
    f1_3a = "{0:0.2f}".format(f1_score(y_test, result_3a) * 100) 
    
    #Output the results
    print("Fold\t\tSVM[Case1a]\t\tSVM[Case2a]\t\tSVM[Case3a]")
    print(iteration)
    print("Accuracy(%):\t", accuracy_1a,"\t\t\t", accuracy_2a,"\t\t\t", 
          accuracy_3a)
    print("Precision(%):\t",  precision_1a,"\t\t\t",  precision_2a,"\t\t\t",  
          precision_3a)
    print("Recall(%):\t", recall_1a,"\t\t\t", recall_2a,"\t\t\t", recall_3a)
    print("F1-measure(%):\t", f1_1a,"\t\t\t", f1_2a,"\t\t\t", f1_3a)
    print("\n")
    
    iteration = iteration + 1

# model runs with negation handled
totalsvm1b = 0           # Accuracy measure on 2000 files
totalMatSvm1b = np.zeros((2,2));  # Confusion matrix on 2000 files
totalsvm2b = 0           # Accuracy measure on 2000 files
totalMatSvm2b = np.zeros((2,2));  # Confusion matrix on 2000 files
totalsvm3b = 0           # Accuracy measure on 2000 files
totalMatSvm3b = np.zeros((2,2));  # Confusion matrix on 2000 files

# load stop words dictionary (this is the standard scilit-learn vocabulary
# augmented by "negative" stopwords)
file_name = "./vocabularies/scikit_stopw_not" + ".txt"
vstopw = []
with open(file_name, 'r') as f:
    for line in f:
        vstopw.append(line)

count = 0
for train_index, test_index in kfold.split(corpus,labels):
    # initialize new vocabulary for each fold
    cvocab_large = {}
    cvocab_red = {}
    # load existing vocabulary for current fold and
    # store it into a dictionary
    file_name_large = "./vocabularies/vocab_large_neg_" + str(count) + ".txt"
    with open(file_name_large, 'r') as f:
        for line in csv.reader(f, delimiter=',', skipinitialspace=True):
            cvocab_large[line[0]] = int(line[1])
    f.closed

    file_name_red = "./vocabularies/vocab_red_neg_" + str(count) + ".txt"
    with open(file_name_red, 'r') as f:
        for line in csv.reader(f, delimiter=',', skipinitialspace=True):
            cvocab_red[line[0]] = int(line[1])
    f.closed
        
    # define train and test datasets
    X_train = [corpus[i] for i in train_index]
    X_test = [corpus[i] for i in test_index]
    y_train, y_test = labels[train_index], labels[test_index]
    
    # call vectorizer with loaded vocabulary
    # SVM case 1b - standard count, large vocabulary, negation handled
    vectorizer1b = CountVectorizer(vocabulary=cvocab_large, stop_words=vstopw)

    # call vectorizer with loaded vocabulary
    # SVM case 2b - tf-idf, large vocabulary, negation handled
    vectorizer2b = TfidfVectorizer(vocabulary=cvocab_large, sublinear_tf=True,
                                 use_idf=True, stop_words=vstopw)

    # call vectorizer with loaded vocabulary
    # SVM case 3b - tf-idf, reduced vocabulary, negation handled
    vectorizer3b = TfidfVectorizer(vocabulary=cvocab_red, sublinear_tf=True,
                                 use_idf=True, stop_words=vstopw)

    train_corpus1b = vectorizer1b.fit_transform(X_train)
    test_corpus1b = vectorizer1b.transform(X_test)

    train_corpus_tf_idf2b = vectorizer2b.fit_transform(X_train)
    test_corpus_tf_idf2b = vectorizer2b.transform(X_test)

    train_corpus_tf_idf3b = vectorizer3b.fit_transform(X_train)
    test_corpus_tf_idf3b = vectorizer3b.transform(X_test)
    
    model1b = LinearSVC()
    model1b.fit(train_corpus1b,y_train)
    result1b = model1b.predict(test_corpus1b)

    model2b = LinearSVC()
    model2b.fit(train_corpus_tf_idf2b,y_train)
    result2b = model2b.predict(test_corpus_tf_idf2b)
    
    model3b = LinearSVC()
    model3b.fit(train_corpus_tf_idf3b,y_train)
    result3b = model3b.predict(test_corpus_tf_idf3b)
    
    totalMatSvm1b = totalMatSvm1b + confusion_matrix(y_test, result1b)
    totalsvm1b = totalsvm1b+sum(y_test==result1b)
    totalMatSvm2b = totalMatSvm2b + confusion_matrix(y_test, result2b)
    totalsvm2b = totalsvm2b+sum(y_test==result2b)
    totalMatSvm3b = totalMatSvm3b + confusion_matrix(y_test, result3b)
    totalsvm3b = totalsvm3b+sum(y_test==result3b)
    
    count+=1
print("results for SVM case 1b (%):")
print((totalsvm1b/2000.0)*100)
print("results for SVM case 2b (%):")
print((totalsvm2b/2000.0)*100)
print("results for SVM case 3b (%):")
print((totalsvm3b/2000.0)*100)