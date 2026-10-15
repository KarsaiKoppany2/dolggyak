using System;
using System.Collections.Generic;
using System.Text;

namespace dolggyak
{
    public class Konyv
    {
        private int ar;
        private int raktarKeszlet;
        private static int osszesRegisztraltKonyv = 0;
        public string Azonosito { get; set; }
        public string Cim { get; set; }
        public string Szerzo { get; set; }
        public int Ar
        {
            get 
            {
                return ar;
            }
            set 
            {
                if (value < 0) ar = 0;
                else ar = value;
            }
        }
        public int RaktarKeszlet
        {
            get
            {
                return raktarKeszlet;
            }
            set
            {
                if (value < 0) raktarKeszlet = 0;
                else raktarKeszlet = value;
            }
        }
        public static int OsszesRegisztraltKonyv { get { return osszesRegisztraltKonyv; } }
    }
}
