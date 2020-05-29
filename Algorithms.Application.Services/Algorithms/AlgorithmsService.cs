﻿using Algorithms.Application.Component;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Algorithms.Application.Services.Algorithms
{
    public class AlgorithmsService : IAlgorithmsService
    {
        public AlgorithmsService()
        {
            //String[,] M = new String[4, 4] { { "S", "L", "O", "C" }, { "R", "E", "S", "C" }, { "K", "D", "P", "W" }, { "N", "A", "I", "T" } };
            //String S = "RDI";
            //SearchWordInMatrix(M, S);

            //List<int> A = new List<int>() { 6, 1, 5, 6, 9, 9, 5 };
            //CheckOddNumberTimes(A);

            //String J = "Red rum, sir, is murder";
            //CheckPalindrome(J);

            //int N = 4;
            //OddOrEven(N);

            //int numCompetitors = 5;
            //int topNCompetitors = 2;
            //int numReviews = 3;
            //string textTopNCompetitors = String.Empty;

            //List<string> competitors =
            //    new List<string> {
            //                                "anacell", "betacellular", "cetracular", "deltacellular", "eurocell"
            //                     };

            //List<string> reviews =
            //    new List<string> {
            //                                "Best services provided by anacell",
            //                                "betacellular has great services",
            //                                "anacell provides much better services than all other"
            //                     };

            ////int numCompetitors = 5;
            ////int topNCompetitors = 2;
            ////List<string> competitors = new List<string> { "anacell", "betacellular", "cetracular", "deltacellular", "eurocell" };
            ////int numReviews = 5;
            ////List<string> reviews = new List<string> {
            ////    "I love anacell Best services provided by anacell in the town",
            ////    "betacellular has great services",
            ////    "deltacellular provides much better services than betacellular",
            ////    "cetracular is worse than eurocell",
            ////    "betacellular is better than deltacellular"};

            //TopCompetitors(numCompetitors, topNCompetitors, competitors, numReviews, reviews);

            //int[] resultCalculeStates;
            //string textResultCalculeStates = String.Empty;

            //////int[] states = new int[] { 1, 1, 1, 0, 1, 1, 1, 1 };
            //////int days = 2;

            //int[] states = new int[] { 1, 0, 0, 0, 0, 1, 0, 0 };
            //int days = 1;

            //CalculeStates(states, days);

            //int resultMdcList;

            ////int[] numberList = new int[] { 2, 3, 4, 5, 6 };
            //int[] numberList = new int[] { 2, 4, 6, 8, 10 };

            //mdcList(numberList);
        }

        #region Calcule States

        public int[] CalculeStates(int[] states, int days)
        {
            int[] cell = new int[8];

            for (int i = 0; i < states.Length; i++)
            {
                if (i == states.Length - 1 || i == 0)
                    cell[i] = 0;

                else
                {
                    bool isValidPosLeft = i - days >= 0 ? true : false;
                    bool isValidposRight = i + days <= states.Length - 1 ? true : false;

                    if (isValidPosLeft && !isValidposRight)
                    {
                        if (states[i - days] == 0)
                            cell[i] = 0;
                        else
                            cell[i] = 1;
                    }

                    if (!isValidPosLeft && isValidposRight)
                    {
                        if (0 == states[i + days])
                            cell[i] = 0;
                        else
                            cell[i] = 1;
                    }

                    if (isValidPosLeft && isValidposRight)
                    {
                        if (states[i - days] == states[i + days])
                            cell[i] = 0;
                        else
                            cell[i] = 1;
                    }
                }
            }

            return (cell);
        }

        #endregion

        #region Check Odd Number of Times

        public int CheckOddNumberTimes(List<int> param)
        {
            //Write a C# API that receives an array of integers A and returns an integer X; 
            //the API shall return the integer that occurs an odd number of times.
            //Considerations:
            //a)	each integer in the array occurs an even number of times, except for one;
            //b) for example, given the array A = [6, 1, 5, 6, 9, 9, 5], the API should return 1;

            int x = 0;

            var obj = param.GroupBy(p => p).Where(p => p.Count() == 1).Select(p => p.Key).ToList();
            foreach (var aux in obj)
            {
                x = 1;
            }

            return x;
        }

        #endregion

        #region Check is Palindrome

        public bool CheckPalindrome(string param)
        {
            //Write a C# API that receives a string S and returns a Boolean Z; the API shall 
            //determine if the content of the given string S is a palindrome.
            //Considerations:
            //a)	only alphanumeric characters should be considered when validating the string S;
            //b)	cases should be ignored;
            //c)	“Red rum, sir, is murder”, “A nut for a jar of tuna”, “A Santa at Nasa” and “A car, a man, a maraca” are examples of palindromes;

            string text = param.ToLower().Replace(" ", "").Replace(".", "").Replace(",", "").Replace(";", "");
            string expression = @"^[a-z0-9]";

            Regex r = new Regex(expression, RegexOptions.IgnoreCase);
            Match m = r.Match(param);

            if (m.Success)
            {
                if (text.Length == 1)
                    return true;

                //int i = 0;
                //int j = text.Length;

                //while (i != j)
                //{
                //    if (text.Substring(i, 1) != text.Substring(j - 1, 1))
                //        return Z = false;                       

                //    i++;
                //    j--;
                //}

                //return Z = true;
                else if (text.Substring(0, 1) == text.Substring(text.Length - 1, 1))
                    return true;

                else
                    return false;
            }
            else
                return false;
        }

        #endregion

        #region MDC

        public int MDC(int[] numberList)
        {
            int mdcResult = numberList[0];

            for (int i = 1; i < numberList.Length; i++)
            {
                mdcResult = CaculeMDC(mdcResult, numberList[i]);
            }
            return mdcResult;
        }

        private int CaculeMDC(int a, int b)
        {
            while (b != 0)
            {
                int r = a % b;
                a = b;
                b = r;
            }
            return a;
        }

        #endregion

        #region Odd Or Even

        public bool OddOrEven(int param)
        {
            //Write a C# API that receives an integer N and returns a Boolean Z; 
            //the API shall determine if the given integer N is odd or even.
            //Considerations:
            //a)	it is ONLY allowed to use addition or subtraction operations;
            //b)	zero shall be considered as even;
            //c)	N is an integer which can be negative or positive;

            if (param == 0)
                return true;

            else if (param > 0)
            {
                while (param > 0)
                    param = param - 2;

                if (param == 0)
                    return true;

                else
                    return false;
            }

            else
            {
                while (param < 0)
                    param = param + 2;

                if (param == 0)
                    return true;
                else
                    return false;
            }
        }

        #endregion

        #region Search Word In Matrix

        public bool SearchWordInMatrix(string[,] M, string S)
        {
            //Write a C# API that receives a matrix of characters M, a string S and returns a Boolean Z; 
            //the API shall return if the string S exists in the matrix M;
            //Considerations:
            //a)	the search in the matrix can move downwards, to the left and diagonally;
            //b)	for example, given the matrix M = [S, L, O, C][R, E, S, C][K, D, P, W][N, A, I, T] and the string S = “RDI”, the API should return ‘true’;

            int isValidate = 0;
            int textLenght = S.Length;

            String[] values = new String[textLenght];

            for (int i = 0; i < S.Length; i++)
                values[i] = S.Substring(i, 1);

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    var p = 0;
                    while (values.Length > p)
                    {
                        if (M[i, j] == values[p])
                            isValidate++;

                        p++;
                    }

                }
            }

            if (isValidate >= values.Length)
                return true;
            else
                return false;

        }

        #endregion

        #region Top Competitors

        public List<string> TopCompetitors(int numCompetitors, int topNCompetitors, List<string> competitors, int numReviews, List<string> reviews)
        {
            List<string> result = new List<string>();
            List<int> listQtd = new List<int>();
            int controller = 0;
            int first = 0;
            int second = 0;
            int indexFirst = 0;
            int indexSecond = 0;

            for (int i = 0; i < competitors.Count; i++)
            {
                if (result.Count != 0)
                    controller += 1;

                int qtd = 0;

                for (int p = 0; p < reviews.Count; p++)
                {
                    qtd += reviews[p].Split(competitors[i]).Length - 1;
                }

                listQtd.Add(qtd);
            }

            for (int i = 0; i < listQtd.Count - 1; i++)
            {
                if (i == 0)
                {
                    first = listQtd[i];
                    indexFirst = i;
                }

                if (listQtd[i] < listQtd[i + 1])
                {
                    if (listQtd[i + 1] > first)
                    {
                        first = listQtd[i + 1];
                        indexFirst = i + 1;
                    }

                }
            }

            for (int i = 0; i < listQtd.Count - 1; i++)
            {
                if (i != indexFirst)
                {
                    if (i == 0)
                    {
                        second = listQtd[i];
                        indexSecond = i;
                    }

                    if (i + 1 == indexFirst)
                    {
                        second = listQtd[i];
                        indexSecond = i;
                    }
                    else
                    {
                        if (second == 0)
                        {
                            second = listQtd[i];
                            indexSecond = i;
                        }
                    }

                    if (listQtd[i] < listQtd[i + 1])
                    {
                        second = listQtd[i + 1];
                        indexSecond = i;
                    }

                }
            }

            result.Add(competitors[indexFirst]);
            result.Add(competitors[indexSecond]);

            return result;
        }

        #endregion

        #region Write in File

        public void CreateAndReadInFile(int numberRows, string rootPath)
        {
            var fileName = GenerateFile(rootPath, numberRows);

            Console.WriteLine("##########");
            Console.WriteLine("Try to find a row in a large file");
            string path = Path.Combine(rootPath, fileName);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            bool contains = File.ReadLines(path).Contains("91820988163");
            stopwatch.Stop();
            Console.WriteLine("Time elipsed to try find a value: {0}", stopwatch.ElapsedMilliseconds);
            Console.WriteLine($"Find something: {0}", contains);
        }

        private string GenerateFile(string rootPath, int numRows)
        {
            string filename = $"file_{numRows}_rows.txt";
            string path = Path.Combine(rootPath, filename);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            string[] lista = new string[numRows];

            for (int i = 0; i < numRows; i++)
            {
                lista[i] = Utils.GenerateCpf();
            }

            File.WriteAllLines(path, lista);

            stopwatch.Stop();

            Console.WriteLine("Time elipsed to generate test file: {0}", stopwatch.ElapsedMilliseconds);

            return filename;
        }

        #endregion

    }
}
