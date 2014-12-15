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
            int nombreMystere = new Random().Next(0, 100);
            int nombreDeCoups = 0, nombreEssaisMax = 10, reponsesIncorrectes, reponsesFausses;
            bool trouve = false, quitter = false, choixDiff = false;
            Console.WriteLine("JEU DU PLUS OU DU MOINS");
            
            while (quitter==false)
            {
                reponsesIncorrectes = 0;
                Console.WriteLine("\nFaites votre choix !\n");
                Console.WriteLine("Afficher la règle du jeu : tapez 1");
                Console.WriteLine("Commencer une partie : tapez 2");
                Console.WriteLine("Quitter le jeu : tapez 3");
                
                try
                {
                    int choix = Convert.ToInt32(Console.ReadLine());
                
                    if (choix == 1)
                    {
                        Console.WriteLine("\nRègle : trouver le nombre mystère en maximum 10 essais.");
                        Console.WriteLine("---Appuyez sur une touche---");
                        Console.ReadLine();
                    }
                    else if (choix == 2)
                    {
                        Console.WriteLine("\nChoisissez le niveau de difficulté :\n");
                        Console.WriteLine("Débutant (10 essais): 1");
                        Console.WriteLine("Moyen (9 essais): 2");
                        Console.WriteLine("Bon (8 essais): 3");
                        Console.WriteLine("Expert (7 essais): 4\n");
                        reponsesFausses = 0;
                        while(!choixDiff && reponsesFausses < 3)
                        {
                            try
                            {
                                while (!choixDiff && reponsesFausses < 3)
                                {
                                    try
                                    {
                                        int choix2 = Convert.ToInt32(Console.ReadLine());
                                        if (choix2 <= 4 && choix2 >= 1)
                                            switch (choix2)
                                            {
                                                case 2:
                                                    nombreEssaisMax = 9;
                                                    break;
                                                case 3:
                                                    nombreEssaisMax = 8;
                                                    break;
                                                case 4:
                                                    nombreEssaisMax = 7;
                                                    break;
                                                default:
                                                    break;
                                            }
                                        choixDiff = true;
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("\nSaisir un NOMBRE !\n");
                                        reponsesFausses++;
                                    }
                                }
                                if (reponsesFausses ==3)
                                {
                                    Console.WriteLine("\nNiveau par défaut : débutant !\n");
                                }
                                reponsesFausses = 0;
                                Console.WriteLine("\nSaisissez un nombre compris entre 1 et 99 inclus :\n");
                                
                                while (!trouve && nombreEssaisMax > 0 && reponsesIncorrectes < 3)
                                {
                                    try
                                    {
                                        int saisie = Convert.ToInt32(Console.ReadLine());
                                
                                        if (saisie == nombreMystere)
                                            trouve = true;
                                        else
                                        {
                                            if (saisie < nombreMystere)
                                                Console.WriteLine("\nTrop petit !");
                                            else
                                                Console.WriteLine("\nTrop grand !");
                                            Console.WriteLine("\nPlus que " + (nombreEssaisMax-1) + " essais. Recommencez :\n");
                                        }
                                        nombreEssaisMax--;
                                        nombreDeCoups++;
                                    }
                                    catch (Exception)
                                    {
                                        int essais = 2 - reponsesIncorrectes;
                                        Console.WriteLine("\nCeci n'est pas un nombre ! Tapez un nombre en chiffre.\n");
                                        if (essais > 0) Console.WriteLine("Encore " + essais + " fois et c'est la porte !\n");
                                        reponsesIncorrectes++;
                                    }
                                }
                                choixDiff = true;
                                if (trouve == true)
                                    Console.WriteLine("\nBravo, vous avez trouvé en seulement" + nombreDeCoups + " coup(s) !\n");
                                else
                                    Console.WriteLine("\nPerdu...\n");
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("\nNombre incorrect ! Tapez 1, 2, 3 ou 4.\n");
                                reponsesFausses++;
                            }
                        }
                    }
                    else if (choix == 3)
                        quitter = true;
                    else
                        Console.WriteLine("\nNombre incorrect ! Tapez 1, 2, ou 3.\n");
                }catch(Exception){
                    Console.WriteLine("\nSaisie incorrecte ! Tapez 1, 2 ou 3.\n");
                }
                    
            }
        }
    }
}
