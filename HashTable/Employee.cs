using System;
using System.Collections.Generic;

namespace HashTable
{
    internal class Employee : IComparable<Employee>
    {
        private string firstName, lastName, street, city, state, zipcode, phoneNumber, email;
        private int id;

        public Employee()
        {
            firstName = null;
            lastName = null;
            street = null;
            city = null;
            state = null;
            zipcode = null;
            phoneNumber = null;
            email = null;
            id = 0;
        }

        public Employee(string[] inputs)
        {
            firstName = inputs[0];
            lastName = inputs[1];
            street = inputs[2];
            city = inputs[3];
            state = inputs[4];
            zipcode = inputs[5];
            phoneNumber = inputs[6];
            email = inputs[7];
            id = int.Parse(inputs[8]);
        }



        public int getID()
        {
            return id;
        }



        public void Print()
        {
            Console.WriteLine($"ID: {id}");
            Console.WriteLine(lastName + ", " + firstName);
            Console.WriteLine(street);
            Console.WriteLine(city + ", " + state + zipcode);
            Console.WriteLine(phoneNumber);
            Console.WriteLine(email + "\n");
        }

        public override string ToString()
        {
            if (id == 0)
            {
                return null;
            }
            else
            {
                return $"\nID: {id}\n{lastName}, {firstName}\n{street}\n{city}, {state} {zipcode}\n{phoneNumber}\n{email}\n";
            }
        }


        int IComparable<Employee>.CompareTo(Employee other)
        {
            return lastName.CompareTo(other.lastName);
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + id.GetHashCode();
            hash = hash * 23 + (firstName?.GetHashCode() ?? 0);
            hash = hash * 23 + (lastName?.GetHashCode() ?? 0);
            hash = hash * 23 + (email?.GetHashCode() ?? 0);
            return hash;
        }
    }
}