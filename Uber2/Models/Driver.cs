﻿using System.ComponentModel.DataAnnotations;

namespace Uber2.Models
{
    public class Driver:User
    {
        public bool isFree { get; set; }
        
        public string numberPlate { get; set; }
    }
}