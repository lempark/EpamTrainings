using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructAndEnumTasks
{
    namespace Task1
    {
        public struct Person
        {
            public string Name { get {return Name;}
                set
                {
                    if (value == "")
                        throw new ArgumentException("Name cannot be empty");
                    else
                        Name = value;
                }
            }

            public string Surname { get { return Surname; }
                set
                {
                    if (value == "")
                        throw new ArgumentException("Surname cannot be empty");
                    else
                        Surname = value;
                }
            }

            public int Age { get { return Age; }
                set
                {
                    if (value <= 0)
                        throw new ArgumentException("age must be higher than 0");
                    else
                        Age = value;
                }
            }

            public Person(string name , string surname , int age)
            {
                this.Name = name;
                this.Surname = surname;
                this.Age = age;
            }

            public string CheckingAge(int n)
            {
                if (n <= 0)
                    throw new ArgumentException("age must be higher than 0");
                string result;
                bool olderThan = (Age >= n) ? true : false;
                if (olderThan)
                    result = $"{Name} {Surname} older than {n}";
                else
                    result = $"{Name} {Surname} younger than {n}";
                return result;
            }
        }
    }
}
