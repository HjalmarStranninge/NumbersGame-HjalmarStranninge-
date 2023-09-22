namespace NumbersGame           //Lab 3 - Gissa numret (Hjalmar Stranninge NET23)
{
    internal class Program
    {        
        static void Main(string[] args)
        {                      
            static bool CheckGuess(int playerGuess, int correctNumber)      
            {
                return playerGuess == correctNumber;   //Metod som testar om anvandaren gissat ratt, returnerar en bool          
            }
           
            Console.WriteLine("Välkommen! Jag tänker på ett nummer mellan 1-20." +
            " Kan du gissa vilket? Du får fem försök.");
            Random random = new Random();
            int correctNumber =random.Next(1,20);
            int guessCount = 0;
            bool isRunning = true;

            string[] wrongGuessLow = new string[5]
            {
                "Tyvärr, du gissade för lågt!",
                "Haha! För lågt",
                "Bra gissat, men för lågt..",
                "För lågt. Testa igen!",
                "Lågt gissat kompis. Gör ett nytt försök!",
            };
                                                                     //Arrays med olika svar på felgissningar
            string[] wrongGuessHigh = new string[5]
            {
                "Tyvärr, du gissade för högt!",
                "Haha! För högt",
                "Bra gissat, men för högt..",
                "För högt. Testa igen!",
                "Högt gissat kompis. Gör ett nytt försök!",
            };

            while (isRunning)                                                   //Loopen som håller igång spelet
            {
                int playerGuess;  
                
                try                            //Förhindrar att programmet crashar vid ogiltig inmatning, t.ex bokstav
                {
                    Console.Write("Vilket tal gissar du på? ");
                    playerGuess = int.Parse(Console.ReadLine());
                    bool isCorrect = CheckGuess(playerGuess, correctNumber);

                    if (isCorrect)                           //Om CheckGuess-metoden returnerartrue så avslutas spelet
                    {
                        Console.Clear();
                        Console.WriteLine("Wohoo! Du klarade det!");
                        break;
                    }

                    else //Returnerar den false så anvands ett if-statement för att skilja på höga och låga gissningar
                    {    //och skriva ut en passande respons. En gissning registreras ocskå
                    
                        guessCount++;

                        if (playerGuess < correctNumber)
                        {
                            Console.Clear();
                            int randomResponseLow = random.Next(0, wrongGuessLow.Length);
                            Console.WriteLine(wrongGuessLow[randomResponseLow]);
                        }

                        else
                        {
                            Console.Clear();
                            int randomResponseHigh = random.Next(0, wrongGuessHigh.Length);
                            Console.WriteLine(wrongGuessHigh[randomResponseHigh]);
                        }
                    }

                    if (guessCount == 5)            //Gissar man fel fem gånger får man frågan om man vill spela igen.
                    {                               //Svarar man ja så resetas gissningarna och spelet börjar om                
                        Console.Clear();
                        Console.WriteLine("Tyvärr, du lyckades inte gissa talet på fem försök!");
                        Console.WriteLine("Vill du försöka igen? Ja/Nej: ");
                        string answer = Console.ReadLine();
                        answer = answer.ToLower();

                        if (answer == "ja")
                        {
                            guessCount = 0;
                            Console.Clear();
                        }

                        else
                        {
                            isRunning = false;
                        }
                    }
                    }

                catch (SystemException)                //Fångar upp felinmatningar
                {
                    Console.Clear();
                    Console.WriteLine("Ogiltig input. Skriv en siffra.");
                }            
            }
        }
    }
}