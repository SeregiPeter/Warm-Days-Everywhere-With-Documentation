/*
  Készítette: Seregi Péter
  Neptun: G9SIY0
  E-mail: seregip02@gmail.com
  Feladat: Mindenhol meleg napok
*/
//#define BIRO
using System;
namespace komplex{
    class Program{
        static void Main(string[] args){
#if BIRO
            string[] elsosor = Console.ReadLine().Split();
            int N = int.Parse(elsosor[0]);
            int M = int.Parse(elsosor[1]);
#else
            bool hiba1 = false;
            bool hiba2 = false;
            int N = 0;
            int M = 0;
            do{
                hiba1 = false;
                Console.WriteLine("Hány település és hány nap van? (1 és 1000 közötti egész számok)");
                string[] elsosor = Console.ReadLine().Split();
                if(elsosor.Length < 2){
                    hiba1 = true;
                    Console.WriteLine("Karaktert, szöveget, valós számot, nem kettő számot vagy nem megfelelő egész számot adtál meg.");
                }
                    if(!hiba1){
                    hiba1 = !int.TryParse(elsosor[0], out N) || N < 1 || N > 1000 || elsosor.Length != 2;
                    hiba2 = !int.TryParse(elsosor[1], out M) || M < 1 || M > 1000;
                    if(hiba1 || hiba2){
                        Console.WriteLine("Karaktert, szöveget, valós számot, nem kettő számot vagy nem megfelelő egész számot adtál meg.");
                    }
                }
            } while(hiba1 || hiba2);
#endif
    
            int[,] homersekletek = new int[N, M];
            string[] sor = new string[M];
#if BIRO
            for(int i = 0; i < N; i++){
                sor = Console.ReadLine().Split();
                for(int j = 0; j < M; j++){
                    homersekletek[i,j] = int.Parse(sor[j]);
                }
            }
#else
            bool hiba = false;
            for(int i = 0; i < N; i++){
                do{
                    Console.WriteLine("Adja meg a(z) " + (i+1) + ". település hőmérsékleteit");
                    sor = Console.ReadLine().Split();
                    for(int j = 0; j < M; j++){
                        hiba = !int.TryParse(sor[j], out homersekletek[i,j]) || homersekletek[i,j] < -50 || homersekletek[i,j] > 50 || sor.Length != M;
                        if(hiba){
                            Console.WriteLine("Karaktert, szöveget, valós számot, nem M db számot vagy nem megfelelő egész számot adtál meg.");
                            break;
                        }
                    }
                } while(hiba);
            }
#endif
            
            int[] mindenholMelegek = new int[M];
            int db = 0;
            for(int i = 0; i < M; i++){
                bool mindenhol = true;
                for(int j = 0; j < N; j++){
                    if(homersekletek[j,i] <= 0){
                        mindenhol = false;
                        break;
                    }
                }
                if(mindenhol){
                    mindenholMelegek[db] = i;
                    db++;
                }
            }
#if BIRO
            Console.Write(db + " ");
            for(int i = 0; i < db; i++){
                Console.Write((mindenholMelegek[i] + 1) + " ");
            }
#else
            if(db == 0){
                Console.WriteLine(db + " ilyen nap van.");
                Console.WriteLine("A bezáráshoz nyomjon egy billentyűt!");
                Console.ReadKey();
            } else{
                Console.Write(db + " ilyen nap van, ezek sorrendben a következők: ");
                for(int i = 0; i < db; i++){
                    Console.Write((mindenholMelegek[i] + 1) + " ");
                }
                Console.WriteLine("\nA bezáráshoz nyomjon egy billentyűt!");
                Console.ReadKey();
            }
#endif
        }
    }
}