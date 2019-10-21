using System;
using System.Linq;


namespace StructAndEnumTasks
{
    public struct Person
    {
        #region Fields
        string name;
        string surname;
        int age;
        #endregion
        #region Properties
        public string Name { get {return name;}
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("Name cannot be empty");
                if (value.Any(char.IsDigit))
                    throw new ArgumentException("Name cannot be number");
                else
                    name = value;
            }
        }
    
        public string Surname { get { return surname; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("Surname cannot be empty");
                if (value.Any(char.IsDigit))
                    throw new ArgumentException("Surname cannot be number");
                else
                    surname = value;
            }
        }
    
        public int Age { get { return age; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("age must be higher than 0");
                else
                    age = value;
            }
        }
        #endregion
    
        #region Constructors
        public Person(string name , string surname , int age)
            :this()
        {
            Name = name;
            Surname = surname;
            Age = age;
        }
        #endregion
    
        #region Methods
        public string CheckingAge(int n)
        {
            if (n <= 0)
                throw new ArgumentException("n must be higher than 0");
            if ((Age >= n) ? true : false)
                return $"{Name} {Surname} older than {n}";
            else
                return $"{Name} {Surname} younger than {n}";
        }
        #endregion
    }
}
