using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Transactions;

namespace Exercise5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string studentID, studentName, level, grade;
            string[] subjects = new string[7], gradesArray = new string[7];
            int[] individualPoints = new int[7];
            Console.WriteLine("Please enter name");
            Console.Write(":");
            studentName = Console.ReadLine();

            Console.WriteLine("Please enter StudentID");
            Console.Write(":");
            studentID = Console.ReadLine();
            Console.WriteLine("\nPlease enter your Subjects:");
            for (int i = 0; i < subjects.Length; i++)
            {
                //Asking for Subject
                Console.WriteLine($"\nPlease Enter Subject #{i + 1}");
                Console.Write(":");
                subjects[i] = Console.ReadLine();
                //Asking for Level
                Console.WriteLine($"Enter level for {subjects[i]} (O/H)");
                Console.Write(":");
                level = Console.ReadLine();
                grade = GradeCalc(subjects[i], level);


                //Calculates Points for Higher Level
                if (grade[0] == 'H')
                {
                    HPointCalc(grade);
                    gradesArray[i] = grade;
                    individualPoints[i] = HPointCalc(grade);
                    
                   
                }
                else if (grade[0] == 'O')
                {
                    OPointCalc(grade);
                    gradesArray[i] = grade;
                    individualPoints[i] = OPointCalc(grade);
                    
                    
                }
                else
                {
                    Console.WriteLine("Error");
                }
                FileWriter(studentName,studentID,subjects, individualPoints,gradesArray);


                
            }
            static string GradeCalc(string Subject, string level)
            {
                double percentage;
                //Input for Percentage
                Console.WriteLine($"Enter Percentage for {Subject}:");
                Console.Write("");
                percentage = double.Parse(Console.ReadLine());

                //If statements to get Grade
                string Grade = "";
                if (level == "H")
                {

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
                }
                if (level == "O")
                {

                    if (percentage >= 90)
                    {
                        Grade = "O1";
                    }
                    else if (percentage >= 80)
                    {
                        Grade = "O2";
                    }
                    else if (percentage >= 70)
                    {
                        Grade = "O3";
                    }
                    else if (percentage >= 60)
                    {
                        Grade = "O4";
                    }
                    else if (percentage >= 50)
                    {
                        Grade = "O5";
                    }
                    else if (percentage >= 40)
                    {
                        Grade = "O6";
                    }
                    else if (percentage >= 30)
                    {
                        Grade = "O7";
                    }
                    else
                    {
                        Grade = "O8";
                    }
                }

                return Grade;
            }

            static int HPointCalc(string Grade)
            {
                Dictionary<string, int> gradetoPoints = new()
                {
                    ["H8"] = 0,
                    ["H7"] = 37,
                    ["H6"] = 46,
                    ["H5"] = 56,
                    ["H4"] = 66,
                    ["H3"] = 77,
                    ["H2"] = 88,
                    ["H1"] = 100,

                };
                return gradetoPoints[Grade];
            }

            static int OPointCalc(string Grade)
            {
                Dictionary<string, int> gradetoPoints = new()
                {
                    ["O8"] = 0,
                    ["O7"] = 0,
                    ["O6"] = 12,
                    ["O5"] = 20,
                    ["O4"] = 28,
                    ["O3"] = 37,
                    ["O2"] = 46,
                    ["O1"] = 56,

                };
                return gradetoPoints[Grade];
            }

            static void FileWriter(string S_Name,string S_ID,string[] subject,int[] ind_points, string[] grade)
            {
                int totalpoints = 0;
                string resultpoints = "pointsTally.txt";
                try
                {
                    using (StreamWriter writer = new StreamWriter(resultpoints))
                    {
                        writer.WriteLine($"Name: {S_Name}");
                        writer.WriteLine($"Student ID: {S_ID}");
                        for (int i = 0; i < subject.Length; i++)
                        {
                            writer.WriteLine($"Points for {subject[i]} (Grade: {grade[i]}) = {ind_points[i]}");
                            totalpoints += ind_points[i];
                        }
                        writer.WriteLine($"Total Points = {totalpoints}");

                    }

                }
                catch (IOException e)
                {
                    Console.WriteLine("An error occurred: " + e.Message);
                }
            }

        }
    }
    
}