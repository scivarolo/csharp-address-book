﻿using System;
using System.Collections.Generic;

namespace address_book
{
    class Program
    {
        /*
            1. Add the required classes to make the following code compile.
            HINT: Use a Dictionary in the AddressBook class to store Contacts. The key should be the contact's email address.

            2. Run the program and observe the exception.

            3. Add try/catch blocks in the appropriate locations to prevent the program from crashing
                Print meaningful error messages in the catch blocks.
        */

        public class Contact {

            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }

            public string FullName {
                get
                {
                    return $"{FirstName} {LastName}";
                }
            }

        }

        public class AddressBook {
            public List<Contact> contacts = new List<Contact>();

            public void AddContact(Contact contact)
            {
                contacts.Add(contact);
            }

            public Contact GetByEmail(string email)
            {
                Contact contact = contacts.Find(c => c.Email == email);
                return contact;
            }

        }

        static void Main(string[] args)
        {
            // Create a few contacts
            Contact bob = new Contact() {
                FirstName = "Bob",
                LastName = "Smith",
                Email = "bob.smith@email.com",
                Address = "100 Some Ln, Testville, TN 11111",
            };
            Contact sue = new Contact() {
                FirstName = "Sue",
                LastName = "Jones",
                Email = "sue.jones@email.com",
                Address = "322 Other Ln, Testville, TN 11111",
            };
            Contact juan = new Contact() {
                FirstName = "Juan",
                LastName = "Lopez",
                Email = "juan.lopez@email.com",
                Address = "105 Easy Ln, Testville, TN 11111",
            };

            // Create an AddressBook and add the Contacts
            AddressBook addressBook = new AddressBook();
            addressBook.AddContact(bob);
            addressBook.AddContact(sue);
            addressBook.AddContact(juan);

            addressBook.AddContact(sue);

            // Create a list of emails that match our Contacts
            List<string> emails = new List<string>() {
                "sue.jones@email.com",
                "bob.smith@email.com",
                "juan.lopez@email.com",
            };

            emails.Insert(1, "elyse.dawson@email.com");

            foreach (string email in emails)
            {
                try
                {
                    Contact contact = addressBook.GetByEmail(email);
                    Console.WriteLine("----------------------------");
                    Console.WriteLine($"Name: {contact.FullName}");
                    Console.WriteLine($"Email: {contact.Email}");
                    Console.WriteLine($"Address: {contact.Address}");
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine($"{email} not found in you Address Book.");
                }
            }
        }
    }
}
