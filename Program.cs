using System;

namespace Mastermind
{
	class Program
	{
		public static void ClearCurrentConsoleLine(int x)
		{
			int currentLineCursor = Console.CursorTop;
			Console.SetCursorPosition(x, Console.CursorTop);
			Console.Write(new string(' ', Console.WindowWidth));
			Console.SetCursorPosition(x, currentLineCursor);
		}


		public static void GiveDigits(int[,] tab, int line, int col)
		{
			for (col = 0; col < 4; col++)
				{
					int digit;
					string digitInput;

					Console.SetCursorPosition(0, Console.CursorTop - 1);
					ClearCurrentConsoleLine(col);

					digitInput = Console.ReadLine();
					digit = Convert.ToInt32(digitInput);
					tab[line, col] = digit;
				}
		}


		static void Main(string[] args)
		{		
			int aSol, bSol, cSol, dSol, digitFind, digitInSol, digitInSola, digitInSolb, digitInSolc, digitInSold, lineBoard, colBoard, nbTry;
			int[,] solution = new int[1, 4];
			int[,] Board = new int[13, 4];

			Console.ForegroundColor = ConsoleColor.Gray;
			Console.Write("MASTERMIND\n");

			//TODO : REDEMANDER SI CHIFFRE PAS ENTRE 1 ET 6
			//if (aSol < 0 && aSol > 6)
			Console.Write("Donner le nombre à deviner EN APPUYANT SUR ENTREE APRES CHAQUE CHIFFRE.\n\n");

			int lineSolution = 0, colSolution = 0;
			
			GiveDigits(solution, lineSolution, colSolution);
			
			Console.SetCursorPosition(0, Console.CursorTop - 1);

			// STOCKAGE DE CHAQUE CHIFFRE DU NOMBRE SOLUTION DANS UNE VARIABLE
			aSol = solution[0, 0];
			bSol = solution[0, 1];
			cSol = solution[0, 2];
			dSol = solution[0, 3];

			for (colSolution = 0; colSolution < 4; colSolution++)
			{
				Console.Write(solution[0, colSolution]);			
			}

			Console.Write("\n\nAppuyer sur entrée pour lancer la partie");
			Console.ReadLine();
			Console.Clear();

			digitFind = 0;
			nbTry = 0;
			lineBoard = 0;

			while (nbTry != 12 && digitFind != 4)
			{
				Console.ForegroundColor = ConsoleColor.Gray;
				// REINITIALISATION DES VARIABLES DE COMPTE DES CHIFFRES BIEN PLACES ET CHIFFRES DANS LA SOLUTION
				digitInSola = 0;
				digitInSolb = 0;
				digitInSolc = 0;
				digitInSold = 0;
				digitFind = 0;

				// INCREMENTATION NOMBRE D'ESSAIS
				nbTry += 1;
				lineBoard += 1;

				Console.Write("Essai n°" + nbTry + "\n");

				// DEMANDE ET ENREGISTREMENT DU NOMBRE A TESTER
				Console.Write("Donner le nombre à tester EN APPUYANT SUR ENTREE APRES CHAQUE CHIFFRE.\n\n");

				GiveDigits(Board, lineBoard, colSolution);

				Console.SetCursorPosition(0, Console.CursorTop - 1);

				Console.ForegroundColor = ConsoleColor.Blue;
				for (colBoard = 0; colBoard < 4; colBoard++)
				{
					if (Board[lineBoard, colBoard] != 0)
					{
						Console.Write(Board[lineBoard, colBoard]);
					}
				}

				Console.Write("\n\n");

				// COMPTE DES BONS CHIFFRES BIEN PLACES
				int i;
				for (i = 0; i < 4; i++)
                {
					if (Board[lineBoard, i] == solution[0, i])
					{
						digitFind = digitFind + 1;
					}
				}

				//COMPTE DES BONS CHIFFRES MAIS MAL PLACES	
				for (colSolution = 0; colSolution < 4; colSolution++)
				{
					if (Board[lineBoard, 0] == solution[0, colSolution] && (digitInSola < 1))
					{
						digitInSola = digitInSola + 1;
						solution[0, colSolution] = -1; // EVITER DE RECOMPTABILISER UN CHIFFRE DEJA TROUVE
					}

					if ((Board[lineBoard, 1] == solution[0, colSolution]) && (digitInSolb < 1))
					{
						digitInSolb = digitInSolb + 1;
						solution[0, colSolution] = -1;
					}

					if (Board[lineBoard, 2] == solution[0, colSolution] && (digitInSolc < 1))
					{
						digitInSolc = digitInSolc + 1;
						solution[0, colSolution] = -1;
					}

					if (Board[lineBoard, 3] == solution[0, colSolution] && (digitInSold < 1))
					{
						digitInSold = digitInSold + 1;
						solution[0, colSolution] = -1;
					}
				}

				digitInSol = digitInSola + digitInSolb + digitInSolc + digitInSold;

				Console.ForegroundColor = ConsoleColor.Gray;
				Console.Write("Vous avez ");
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.Write(digitInSol + " bons chiffre(s) ");
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.Write("dont ");
				Console.ForegroundColor = ConsoleColor.Green;
				Console.Write(digitFind + " bien placé(s)\n\n");

				// REINITIALISATION DES VALEURS DE LA SOLUTION POUR PROCHAIN ESSAI (MIS A VALEUR -1 SI TROUVE AVEC ESSAI EN COURS)
				solution[0, 0] = aSol;
				solution[0, 1] = bSol;
				solution[0, 2] = cSol;
				solution[0, 3] = dSol;

			}

			Console.ForegroundColor = ConsoleColor.Blue;

			if (digitFind == 4)
			{
				Console.Write("Bravo ! Vous avez gagné !\n");
			}

			else
			{
				Console.Write("vous n'avez plus d'essais vous êtes nul !");
			}

			Console.ReadLine();
		}
	}
}
