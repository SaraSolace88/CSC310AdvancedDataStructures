using System;

namespace DynamicArrays
{
    internal class Contact : IComparable<Contact>
    {
        private string firstName, lastName, street, city, state, zipcode, phoneNumber, email;



        public Contact(string[] inputs)
        {
            firstName = inputs[0];
            lastName = inputs[1];
            street = inputs[2];
            city = inputs[3];
            state = inputs[4];
            zipcode = inputs[5];
            phoneNumber = inputs[6];
            email = inputs[7];
        }



        public void Print()
        {
            Console.WriteLine(lastName + ", " + firstName);
            Console.WriteLine(street);
            Console.WriteLine(city + ", " + state + zipcode);
            Console.WriteLine(phoneNumber);
            Console.WriteLine(email + "\n");
        }


        int IComparable<Contact>.CompareTo(Contact other)
        {
            return lastName.CompareTo(other.lastName);
        }
    }
}
