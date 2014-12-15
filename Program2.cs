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
            int nombreDeCoups = 0, nombreEssaisMax = 10, reponsesIncorrectes, reponsesFausses, choixErrones, nombreMystere;
            bool trouve = false, quitter = false, choixDiff;
            Console.WriteLine("JEU DU PLUS OU DU MOINS");
            
            while (quitter==false)
            {
                nombreMystere = new Random().Next(0, 100);
                
                Console.WriteLine("\nAfficher la règle du jeu : 1\nCommencer une partie : 2\nQuitter le jeu : 3\n");
                
                try
                {
                    int choix = Convert.ToInt32(Console.ReadLine());
                
                    if (choix == 1)
                    {
                        Console.WriteLine("\nRègle : trouver le nombre mystère en maximum 10 essais.\n---Appuyez sur une touche---");
                        Console.ReadLine();
                    }
                    else if (choix == 2)
                    {
                        Console.WriteLine("\nNiveau de difficulté :\nDébutant : 1\nMoyen : 2\nBon : 3\nExpert : 4\n");
                        
                        reponsesFausses = 0;
                        while(reponsesFausses < 3)
                        {
                            try
                            {
                                choixDiff = false;
                                choixErrones = 0;
                                while(!choixDiff && choixErrones < 3){
                                    int choix2 = Convert.ToInt32(Console.ReadLine());
                                    if (choix2 <= 4 && choix2 >= 1)
                                    {    
                                        nombreEssaisMax = 11 - choix2;
                                        choixDiff = true;
                                    }else{
                                        Console.WriteLine("\nSaisir 1, 2, 3 ou 4 !\n");
                                        choixErrones++;
                                    }
                                }
                                
                                if (choixErrones == 3)
                                    nombreEssaisMax = 0;
                                
                                reponsesIncorrectes = 0;    
                                while (!trouve && nombreEssaisMax > 0 && reponsesIncorrectes < 3)
                                {
                                    try
                                    {
                                        Console.WriteLine("\nSaisissez un nombre compris entre 1 et 99 inclus :\n");
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
                                        Console.WriteLine("\nCeci n'est pas un nombre ! Tapez un nombre en chiffre.\n");
                                        reponsesIncorrectes++;
                                    }
                                }
                                if (trouve == true)
                                    Console.WriteLine("\nBravo, vous avez trouvé en seulement" + nombreDeCoups + " coup(s) !\n");
                                else if (reponsesFausses >=3)
                                    Console.WriteLine("\nRetour au menu !\n");
                                else
                                    Console.WriteLine("\nPerdu...\n");
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("\nSaisir 1, 2, 3 ou 4 !\n");
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
