namespace Exercise2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filepath = @"../../../../results.txt";
            try
            {
                string[] lines = File.ReadAllLines(filepath);
                int totalPoints = 0, Points = 0, percentage = 0;
                foreach (string line in lines)
                {
                    string Grade;
                    percentage = Convert.ToInt32(line);//Converts the string to an int
                    Grade=GradeCalc(percentage);
                    Points=PointCalc(Grade);
                    

                    totalPoints += Points;


                }

                File.AppendAllText(filepath, Environment.NewLine + "Total Points: " + totalPoints.ToString());
            }
            catch (IOException io)
            {
                Console.WriteLine(io.Message);
            }
        }
        static string GradeCalc(int percentage)
        {
            string Grade;
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

            return Grade;
        }
        static int PointCalc(string Grade)
        {
            int Points;
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
            return Points;
        }
    }
}