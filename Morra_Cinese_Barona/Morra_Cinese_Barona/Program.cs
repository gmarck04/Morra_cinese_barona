/*
 * Autore: Giovanni Marchetto
 * Data 12/03/2021
 * Consegna:
 * Partendo dal gioco della morra cinese:
 * Aggiungere la modalità "maledetto baro", cioè
 *  - Aggiungere la modalità di gioco uomo vs pc (se nono è già stata fatta)
 *  - Se la differenza di punteggio è favorevole di 2 punti per l'uomo il pc si mette e barare e decide cosa fare solo che dopo che l'uomo avrà giocato, vincendo a mani basse.
 *  - Se la differenza di punteggio è favorevole di 2 punti per il pc, il pc lascia vincere l'uomo fino a riportarsi alla parità.

 */


using System;

namespace Morra_Cinese
{
    class Program
    {
        public static string mossa_giocatore1 = "";
        public static string mossa_AI = "";
        public static int Vittorie_giocatore1 = 0;
        public static int Vittorie_AI = 0;
        public static string Sasso = "Sasso";
        public static string Carta = "Carta";
        public static string Forbice = "Forbice";
        public static bool barare = true;

        static void Main(string[] args)
        {
            Random random = new Random(); //Inizializza la classe random           

            Console.WriteLine("Benvenuto nel gioco della morra cinese");

            Console.WriteLine("\nInserisci il nome del giocatore 1");
            string nome_giocatore_1 = Console.ReadLine();

            do
            {
                Console.Clear(); //pulisce la console

                Console.WriteLine($"Ora e' il turno del giocatore {nome_giocatore_1}");
                Console.WriteLine("Scegli che se vuoi buttare sasso (digita S), forbice (digita D) o carta (digita A)");
                string Scelta_Giocatore_1 = Convert.ToString(Console.ReadKey(true).KeyChar); //assegnazione valore di Scelta_Giocatore_1 e do valore letto da schermo (il valore è solo un carattere)

                while (Scelta_Giocatore_1 != "S" && Scelta_Giocatore_1 != "D" && Scelta_Giocatore_1 != "A") //ciclo che controlla che l'utente abbia messo una riposta accettabile
                {
                    Console.Clear();
                    Console.WriteLine("La risposta inserita non e' corretta...");
                    Console.WriteLine("Scegli che se vuoi buttare sasso (digita S), forbice (digita D) o carta (digita A)");
                    Scelta_Giocatore_1 = Convert.ToString(Console.ReadKey(true).KeyChar); //assegnazione valore di Scelta_Giocatore_1 e do valore letto da schermo (il valore è solo un carattere)
                }

                if (Scelta_Giocatore_1 == "S") //converte la scelta del giocatore in Sasso
                {
                    mossa_giocatore1 = Sasso;
                }
                else if (Scelta_Giocatore_1 == "D") //converte la scelta del giocatore Forbice
                {
                    mossa_giocatore1 = Forbice;
                }
                else if (Scelta_Giocatore_1 == "A") //converte la scelta del giocatore Carta
                {
                    mossa_giocatore1 = Carta;
                }

                Console.WriteLine($"\nOra e' il turno della AI");
                int Scelta_AI = random.Next(0, 2); //generatore random

                
                if (Vittorie_giocatore1 == Vittorie_AI + 2) //if che controlla se le vittorie del giocatore siano uguali a quelle dell' AI + 2
                {
                    barare = true;
                }
                else if (Vittorie_AI == Vittorie_giocatore1 + 2) //if che controlla se le vittorie del AI siano uguali a quelle dell' giocatore + 2
                {
                    barare = false;
                }

                if (barare == false) //if che controlla se barare è uguale a false
                {
                    if (mossa_giocatore1 == Carta)
                    {
                        mossa_AI = Sasso;
                    }
                    else if (mossa_giocatore1 == Sasso)
                    {
                        mossa_AI = Forbice;
                    }
                    else
                    {
                        mossa_AI = Carta;
                    }
                }
                else if (barare == true) //if che controlla se barare è uguale a true
                {
                    if (mossa_giocatore1 == Carta)
                    {
                        mossa_AI = Forbice;
                    }
                    else if (mossa_giocatore1 == Sasso)
                    {
                        mossa_AI = Carta;
                    }
                    else
                    {
                        mossa_AI = Sasso;
                    }
                }

                if (mossa_giocatore1 == mossa_AI)
                {
                    Console.WriteLine("\nPAREGGIO");
                }
                else if (mossa_giocatore1 == Sasso && mossa_AI == Forbice)
                {
                    Console.WriteLine($"\nHA VINTO IL GIOCATORE {nome_giocatore_1}");
                    Vittorie_giocatore1++;
                }
                else if (mossa_giocatore1 == Sasso && mossa_AI == Carta)
                {
                    Console.WriteLine($"\nHA VINTO LA AI");
                    Vittorie_AI++;
                }
                else if (mossa_giocatore1 == Forbice && mossa_AI == Sasso)
                {
                    Console.WriteLine($"\nHA VINTO LA AI");
                    Vittorie_AI++;
                }
                else if (mossa_giocatore1 == Forbice && mossa_AI == Carta)
                {
                    Console.WriteLine($"\nHA VINTO IL GIOCATORE {nome_giocatore_1}");
                    Vittorie_giocatore1++;
                }
                else if (mossa_giocatore1 == Carta && mossa_AI == Sasso)
                {
                    Console.WriteLine($"\nHA VINTO IL GIOCATORE {nome_giocatore_1}");
                    Vittorie_giocatore1++;
                }
                else if (mossa_giocatore1 == Carta && mossa_AI == Forbice)
                {
                    Console.WriteLine($"\nHA VINTO LA AI");
                    Vittorie_AI++;
                }

                Console.WriteLine("\nPer continuare premere qualsiasi tasto, però se vuoi terminare il gioco, premi X");              
                
            } while (Console.ReadKey().Key != ConsoleKey.X); //while che continua fino a quando digiti X

            Console.Clear();

            if (Vittorie_giocatore1 == Vittorie_AI) //pareggio
            {
                Console.WriteLine($"Il Giocatore {nome_giocatore_1} e la AI hanno pareggiato");
            }
            else if (Vittorie_giocatore1 > Vittorie_AI) //vince giocatore
            {
                Console.WriteLine($"Il Giocatore {nome_giocatore_1} ha vinto contro la AI");
            }
            else if (Vittorie_AI > Vittorie_giocatore1) //vince AI
            {
                Console.WriteLine($"La AI ha vinto contro il Giocatore {nome_giocatore_1}");
            }

            Console.WriteLine($"\nIl Giocatore {nome_giocatore_1} ha vinto n°: {Vittorie_giocatore1} , mentre la AI ha vinto n°: {Vittorie_AI} ");

            Console.ReadKey();
        }
    }
}

