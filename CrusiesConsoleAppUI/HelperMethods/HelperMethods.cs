﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrusiesConsoleAppUI.HelperMethods
{
    public class HelperMethods
    {
        public static int GetItemInRange(int pMin, int pMax) // Get User Inputs For Menus
        {

            Console.WriteLine();

            if (pMin > pMax)
            {
                throw new Exception($"Minimum value {pMin} cannot be greater than maximum value {pMax}");

            }

            int result;


            do
            {

                Console.WriteLine($"To Select A Menu Option Please Enter A Number Between {pMin} And {pMax} Inclusive.");

                string userInput = Console.ReadLine();

                Console.WriteLine("");

                try
                {
                    result = int.Parse(userInput);
                }
                catch
                {
                    Console.WriteLine($"{userInput} Is Not A Number");
                    continue;
                }

                if (result >= pMin && result <= pMax)
                {

                    return result;

                }


                Console.WriteLine($"{result} Is Not Between {pMin} And {pMax} Inclusive.");

            } while (true);

        }

        public static void DisplayPageHeader(string pageTitle)
        {
            Console.WriteLine($"------------------------------{pageTitle}------------------------------");
        }

        public static void DisplayList<T>(List<T> list, string listName)
        {
            int index = 1;
            string _listName = listName;

            Console.WriteLine($"--------------------");
            Console.WriteLine($"{listName}");
            Console.WriteLine($"--------------------");

            foreach (var item in list)
            {
                Console.WriteLine($"{index}: {item}");
                index++;
            }

            index = 1;
        }

        public static void DisplayEditingOptions(string options)
        {
            if(options == "editCruisePage")
            {
                List<string> editCruisePageOptions = new List<string>();
                editCruisePageOptions.Add("1: Edit Ports");
                editCruisePageOptions.Add("2: Edit Passengers");
                editCruisePageOptions.Add("3: Go Back");
                DisplayList(editCruisePageOptions, "Editing Options");
            }
            else if(options == "editPortPage")
            {

                List<string> addPortPageOptions = new List<string>();
                addPortPageOptions.Add("1: Add New Port");
                addPortPageOptions.Add("2: Remove Port");
                DisplayList(addPortPageOptions, "Editing Options");
            }






        }

        
        


    }


}


