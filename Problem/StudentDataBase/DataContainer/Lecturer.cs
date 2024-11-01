﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem.StudentDataBase.DataContainer
{
    internal class Lecturer : UserData
    {
        public string Specialization { get; private set; }

        public Lecturer(string? name,
                        string? lastName,
                        string? sex,
                        string? pesselNumber,
                        string? albumNumber,
                        string? specialization,
                        string? address)
        {
            Role = "Lecturer";
            Name = name ?? "Unknown";
            LastName = lastName ?? "Unknown";
            Sex = sex ?? "Unknown";
            PesselNumber = pesselNumber ?? "Unknown";
            AlbumNumber = albumNumber ?? "Unknown";
            Address = address ?? "Unknown";
            Specialization = specialization ?? "Unknown";
        }
    }
}
