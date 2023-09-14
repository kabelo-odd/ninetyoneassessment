using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TopScorerConsole
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter file name");
            string fileName = "C:\\" + Console.ReadLine();
            RetrieveHighestScorer(fileName);
        }

        public static void RetrieveHighestScorer(string fileName)
        {
            // check if file exists
            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);

                int highestScore = int.MinValue;
                List<string> highestMarkScorer = new List<string>();
                foreach (string line in lines)
                {
                    //split line into array
                    string[] scorersArray = line.Split(','); 

                    if (scorersArray.Length == 3)
                    {
                        string scorerNameSurname = scorersArray[0].Trim() + " " + scorersArray[1].Trim();
                        //check and parse mark
                        if (int.TryParse(scorersArray[2], out int mark))
                        {
                            //check if the highest score is equal or more
                            if (mark == highestScore)
                            {
                                highestMarkScorer.Add(scorerNameSurname);
                            }
                            else if (mark > highestScore)
                            {
                                highestScore = mark;
                                highestMarkScorer.Clear();
                                highestMarkScorer.Add(scorerNameSurname);
                            }
                        }
                    }
                }
                //sort the list of people
                highestMarkScorer.Sort();
                if (highestMarkScorer.Count > 0)
                {
                    Console.WriteLine("\n");
                    foreach (string scorer in highestMarkScorer)
                    {
                        Console.WriteLine(scorer);
                    }

                    Console.WriteLine($"score: {highestScore}");
                }
                else
                {
                    Console.WriteLine("No data found in the CSV file.");
                }

            }
            else
             {
                Console.WriteLine("file does not exist.");
            }
        }
    }
}
