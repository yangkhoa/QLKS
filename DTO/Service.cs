﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Service
    {
        private string _code_service;
        private string _name_service;
	    private string _unit;
	    private double _price_service;
        private string _code_category;

        public string Code_service { get => _code_service; set => _code_service = value; }
        public string Name_service { get => _name_service; set => _name_service = value; }
        public string Unit { get => _unit; set => _unit = value; }
        public double Price_service { get => _price_service; set => _price_service = value; }
        public string Code_category { get => _code_category; set => _code_category = value; }

        public Service()
        {

        }
    }
}