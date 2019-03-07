using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp
{
    public class DDLClass
    {
        public int ValueField { get; set; }
        public string DisplayField { get; set; }

        public DDLClass()
        {
            //Default
        }
        public DDLClass(int valueifeld, string displayfield)
        {
            ValueField = valueifeld;
            DisplayField = displayfield;


        }
    }
}