﻿using System.Net.Sockets;

namespace NrgsCodingChallenge.Models
{
    public class Player
    {
        public Player(int id, string surname, string name, Address address, string email, string nickName)
        {
            Id = id;
            Surname = surname;
            Name = name;
            Address = address;
            Email = email;
            NickName = nickName;
        }

        public int Id { get; }

        public string Surname { get; }
        public string Name { get; }
        public Address Address { get; }

        public string Email { get; }

        public string NickName { get; }
    }

    public class Address
    {
        public Address(string street, string number, string postalCode, string town, string country)
        {
            Street = street;
            Number = number;
            PostalCode = postalCode;
            Town = town;
            Country = country;
        }

        public string Street { get; }
        public string Number { get; }
        public string PostalCode { get; }
        public string Town { get; }
        public string Country { get; }
    }
}