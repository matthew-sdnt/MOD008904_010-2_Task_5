using System;
using System.Collections.Generic;
using System.Text;

namespace Task_5.Classes
{
    internal class Student
    {
        //Fields
        private int student_id;
        private string first_name;
        private string last_name;
        private string gender;
        private string postcode;

        //Properties
        public int Student_ID
        {
            get { return this.student_id; }
        }
        public string First_Name
        {
            get { return this.first_name; }
            set { this.first_name = value; }
        }
        public string Last_Name
        {
            get { return this.last_name; }
            set { this.last_name = value; }
        }
        public string Gender
        {
            get { return this.gender; }
            set { this.gender = value; }
        }
        public string Postcode
        {
            get { return this.postcode; }
            set { this.postcode = value; }
        }

        //Constructor
        public Student(string p_first_name, string p_last_name, string p_gender, string p_postcode)
        {
            Random rand = new Random();
            
            this.student_id = rand.Next(0, 10000000);
            this.first_name = p_first_name;
            this.last_name = p_last_name;
            this.gender = p_gender;
            this.postcode = p_postcode; 
        }
    }
}
