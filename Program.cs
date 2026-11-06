using Task_5.Classes;

namespace Task_5
{
    internal class Program
    {
        static int input_int(string p_prompt) //Method to input integers. For this program, this is only here to provide function to the range restricted overload of this method.
        {
            //Variables
            int num;

            //Logic
            Console.Write(p_prompt); //Prompt user.
            while (!int.TryParse(Console.ReadLine(), out num)) //Takes input, loops if not a double.
            {
                Console.Clear();
                Console.WriteLine("Please input an integer."); //Error.
                Console.Write(p_prompt); //Reprompt user.
            }

            return num;
        }
        static int input_int(string p_prompt, int p_min, int p_max) //An overload of the input_int method that reprompts if the input is not in a certain range.
        {
            //Variables
            int num;

            //Logic
            do
            {
                num = input_int(p_prompt); //Calls the input_int method defined prior and passes the prompt in.
                if (num < p_min || num > p_max)
                {
                    Console.Clear();
                    Console.WriteLine($"Please input a number in the given range ({p_min} - {p_max}).");
                }
            } while (num < p_min || num > p_max); //Check if number is in the given range.

            Console.Clear();
            return num;
        }
        static string input_string(string p_prompt)
        {
            string str;

            do
            {
                Console.Write(p_prompt);
                str = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(str))
                {
                    Console.WriteLine("Please do not input whitespace.");
                }
            } while (string.IsNullOrWhiteSpace(str));

            return str;
        }
        static void Main(string[] args)
        {
            //MOD008904 010-2 Task_5 - Student Management System
            //Variables
            int choice;
            string find_usr_first;
            string find_usr_last;
            int found_usr = -1;
            List<Student> records = new List<Student>();
            StreamWriter stream;
            string log_file = "log.csv";

            //Logic
            if (!File.Exists(log_file))
            {
                stream = new StreamWriter(log_file, append: true);
                stream.WriteLine("Student ID,First Name,Last Name,Gender,Postcode");
                stream.Flush();
            }
            else
            {
                stream = new StreamWriter(log_file, append: true);
            }

            do
            {
                choice = input_int("1. Add new record\n2. View student records\n3. Find student record\n4. Edit student record\n5. Delete student record\n6. Exit\nChoice: ", 1, 6);
                Console.Clear();
                switch (choice)
                {
                    case 1: //Add record.
                        records.Add(new Student(input_string("First Name: "), input_string("Last Name: "), input_string("Gender: "), input_string("Postcode: ")));
                        break;
                    case 2: //View records.
                        for (int i = 0; i < records.Count; i++)
                        {
                            Console.WriteLine($"Student {i + 1}, name: {records[i].First_Name} {records[i].Last_Name}, Gender: {records[i].Gender}, Postcode: {records[i].Postcode}");
                        }
                        break;
                    case 3: //Find record.
                        find_usr_first = input_string("Enter the first name of the student you are trying to find: ");
                        find_usr_last = input_string("Enter the last name of the student you are trying to find: ");
                        for (int i = 0; i < records.Count; i++)
                        {
                            if (find_usr_first.ToLower() == records[i].First_Name.ToLower() && find_usr_last.ToLower() == records[i].Last_Name.ToLower())
                            {
                                found_usr = i;
                            }
                        }
                        if (found_usr != -1)
                        {
                            Console.WriteLine($"Name: {records[found_usr].First_Name} {records[found_usr].Last_Name}, Gender: {records[found_usr].Gender}, Postcode: {records[found_usr].Postcode}");

                        }
                        found_usr = -1;
                        break;
                    case 4: //Edit record.
                        find_usr_first = input_string("Enter the first name of the student you are trying to edit: ");
                        find_usr_last = input_string("Enter the last name of the student you are trying to edit: ");
                        for (int i = 0; i < records.Count; i++)
                        {
                            if (find_usr_first.ToLower() == records[i].First_Name.ToLower() && find_usr_last.ToLower() == records[i].Last_Name.ToLower())
                            {
                                found_usr = i;
                            }
                        }
                        if (found_usr != -1)
                        {
                            records[found_usr] = new Student(input_string("First Name: "), input_string("Last Name: "), input_string("Gender: "), input_string("Postcode: "));
                        }
                        found_usr = -1;
                        break;
                    case 5: //Delete record.
                        find_usr_first = input_string("Enter the first name of the student you are trying to edit: ");
                        find_usr_last = input_string("Enter the last name of the student you are trying to edit: ");
                        for (int i = 0; i < records.Count; i++)
                        {
                            if (find_usr_first.ToLower() == records[i].First_Name.ToLower() && find_usr_last.ToLower() == records[i].Last_Name.ToLower())
                            {
                                found_usr = i;
                            }
                        }
                        if (found_usr != -1)
                        {
                            records.Remove(records[found_usr]);
                        }
                        found_usr = -1;
                        break;
                    case 6:
                        foreach (Student student in records)
                        {
                            stream.WriteLine($"{student.Student_ID},{student.First_Name},{student.Last_Name},{student.Gender},{student.Postcode}");
                        }
                        stream.Flush();
                        Console.WriteLine("Exiting.");
                        break;
                    default:
                        Console.WriteLine("Error, invalid input.");
                        break;
                }
                Console.WriteLine("Press enter to continue.");
                Console.ReadLine();
                Console.Clear();
            } while (choice != 6);
        }
    }
}
