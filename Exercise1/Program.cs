using System.ComponentModel.Design;
using System.Diagnostics;

namespace Exercise1
{
    internal class Program



    {
        static void Main(string[] args)
        {
            string filepath = @"../../../../results.txt";
            try
            {
                string[] lines = File.ReadAllLines(filepath);
                int totalPoints = 0, Points=0, percentage=0;
                for (int i = 0; i < lines.Length; i++)
                {
                    string Grade = "";
                    Points = 0;
                    percentage = Convert.ToInt32(lines[i]);//Converts the string to an int
                    if (percentage >= 90)
                    {
                        Grade = "H1";
                    }
                    else if (percentage >= 80)
                    {
                        Grade = "H2";
                    }
                    else if (percentage >= 70)
                    {
                        Grade = "H3";
                    }
                    else if (percentage >= 60)
                    {
                        Grade = "H4";
                    }
                    else if (percentage >= 50)
                    {
                        Grade = "H5";
                    }
                    else if (percentage >= 40)
                    {
                        Grade = "H6";
                    }
                    else if (percentage >= 30)
                    {
                        Grade = "H7";
                    }
                    else
                    {
                        Grade = "H8";
                    }
                    switch (Grade)
                    {
                        case "H8":
                            Points = 0;
                            break;

                        case "H7":
                            Points = 37;
                            break;

                        case "H6":
                            Points = 46;
                            break;

                        case "H5":
                            Points = 56;
                            break;

                        case "H4":
                            Points = 66;
                            break;

                        case "H3":
                            Points = 77;
                            break;

                        case "H2":
                            Points = 88;
                            break;

                        case "H1":
                            Points = 100;
                            break;

                        default:
                            Points = 0;
                            break;
                    }
                            
                    totalPoints += Points;


                }
                
                File.AppendAllText(filepath, Environment.NewLine + "Total Points: " + totalPoints.ToString());
            }
            catch (IOException io)
            {
                Console.WriteLine(io.Message);
            }
        }
        
    }
}