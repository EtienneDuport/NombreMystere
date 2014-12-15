using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quitter = false, sortir = false, trouver = false;
            int erreursMenu = 0, erreursDiff = 0, erreursNombre = 0, choix, nombreMystere, essais;
            Console.WriteLine("JEU DU PLUS OU DU MOINS");
            while (!quitter)
            {
                Console.WriteLine("\n---MENU---\nRègle  : 1\nJouer  : 2\nSortir : 3\n");
                nombreMystere = new Random().Next(0, 100);
                try
                {
                    choix = Convert.ToInt32(Console.ReadLine());
                    if (choix == 1) Console.WriteLine("\nRègle : trouver le nombre mystère en maximum 10 essais.\n");
                    else if (choix == 2)
                    {
                        sortir = false;
                        while (!sortir)
                        {
                            try
                            {
                                Console.WriteLine("\n-Difficulté-\nDébutant : 1\nMoyen    : 2\nBon      : 3\nExpert   : 4\n");
                                choix = Convert.ToInt32(Console.ReadLine());
                                trouver = false; 
                                if (1 < choix && choix < 5)
                                {
                                    essais = 11 - choix;
                                    Console.WriteLine("Saisissez un nombre entre 1 et 99 inclus :\n");
                                    while (!sortir)
                                    {
                                        try
                                        {
                                            choix = Convert.ToInt32(Console.ReadLine());
                                            if (choix == nombreMystere){
                                                sortir = true;
                                                Console.WriteLine("\nGagné !\n");
                                            }  
                                            else
                                            {
                                                if (--essais == 0){
                                                    sortir = true;
                                                    Console.WriteLine("\nPerdu !\n");
                                                }
                                                else if (choix < nombreMystere)
                                                    Console.WriteLine("\nTrop petit !");
                                                else
                                                    Console.WriteLine("\nTrop grand !");
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            Console.WriteLine("\nVeuillez taper un nombre en CHIFFRES.\n");
                                            if (++erreursNombre == 3)
                                            {
                                                sortir = true;
                                                erreursNombre = 0;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nVeuillez taper 1, 2, 3 ou 4.\n"); 
                                    if (++erreursDiff == 3)
                                    {
                                        sortir = true;
                                        erreursDiff = 0;
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("\nVeuillez taper un nombre en CHIFFRES.\n");
                                if (++erreursDiff == 3)
                                {
                                    sortir = true;
                                    erreursDiff = 0;
                                }
                            }
                        }
                    }
                    else if (choix == 3) quitter = true;
                    else
                    {
                        Console.WriteLine("\nVeuillez taper 1, 2 ou 3.\n");
                        if (++erreursMenu == 3) quitter = true;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nVeuillez taper un nombre en CHIFFRES.\n"); 
                    if (++erreursMenu == 3) quitter = true;
                }
            }
        }
    }
}
