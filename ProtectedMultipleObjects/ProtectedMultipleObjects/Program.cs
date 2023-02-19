using System;
using System.ComponentModel.Design;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using static System.Console;

namespace PrivateMultipleObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfGames, numberOfRolePlayGames;
            WriteLine("How many games would you like to enter: ");
            while (!int.TryParse(Console.ReadLine(), out numberOfGames))
            {
                Console.WriteLine("Invalid selection please provide a number of games you wish to enter: ");
            }
            VideoGames[] videoGames = new VideoGames[numberOfGames];
            WriteLine("How many role play games would you like to enter: ");
            while (!int.TryParse(Console.ReadLine(), out numberOfRolePlayGames))
            {
                Console.WriteLine("Invalid selection please provide a number of games you wish to enter: ");
            }
            RolePlayingGames[] rolePlayingGames = new RolePlayingGames[numberOfRolePlayGames];
            int choice = Menu();
            int recordNumber, gameType;
            int normalCounts = 0, roleCounts = 0;
            while (choice != 4)
            {
                Console.WriteLine("Enter 1 for normal game or 2 for Role Playing Game");
                bool isNumber = int.TryParse(Console.ReadLine(), out gameType);
                while (gameType != 1 && gameType != 2 || !isNumber)
                {
                    WriteLine("Please enter a valid selection of 1 for normal game or 2 for role playing game");
                    isNumber = int.TryParse(Console.ReadLine(), out gameType);
                }
                try
                {
                    switch (choice)
                    {
                        case 1:
                            {
                                char stopEntry = 'c';
                                if (gameType == 1)
                                {
                                    while (stopEntry != 'q' && normalCounts < videoGames.Length)
                                    {
                                        videoGames[normalCounts] = new VideoGames();
                                        videoGames[normalCounts].addChange();
                                        normalCounts++;
                                        if (normalCounts < videoGames.Length)
                                        {
                                            WriteLine("Enter q to stop adding entries or c to continue");
                                            stopEntry = char.Parse(ReadLine());
                                        }
                                        else
                                            WriteLine("The maximum entries have been entered!");
                                    }
                                }
                                else
                                {
                                    while (stopEntry != 'q' && roleCounts < rolePlayingGames.Length)
                                    {
                                        rolePlayingGames[roleCounts] = new RolePlayingGames();
                                        rolePlayingGames[roleCounts].addChange();
                                        roleCounts++;
                                        if (roleCounts < videoGames.Length)
                                        {
                                            WriteLine("Enter q to stop adding entries or c to continue");
                                            stopEntry = char.Parse(ReadLine());
                                        }
                                        else
                                            WriteLine("The maximum entries have been entered!");
                                    }
                                }
                                break;
                            }
                        case 2:
                            {
                                if (gameType == 1)
                                {
                                    WriteLine("What record would you like to alter");
                                    while (!int.TryParse(Console.ReadLine(), out recordNumber))
                                    {
                                        WriteLine("Please enter a valid record number: ");
                                    }
                                    recordNumber--;
                                    while (recordNumber < 0 || recordNumber > normalCounts - 1)
                                    {
                                        WriteLine("Please enter a valid record number: ");
                                        while (!int.TryParse(Console.ReadLine(), out recordNumber))
                                        {
                                            WriteLine("Please enter a valid record number: ");
                                        }
                                        recordNumber--;
                                    }
                                    videoGames[recordNumber].addChange();
                                }
                                else
                                {
                                    WriteLine("What record would you like to alter");
                                    while (!int.TryParse(Console.ReadLine(), out recordNumber))
                                    {
                                        WriteLine("Please enter a valid record number: ");
                                    }
                                    recordNumber--;
                                    while (recordNumber < 0 || recordNumber > roleCounts - 1)
                                    {
                                        WriteLine("Please enter a valid record number: ");
                                        while (!int.TryParse(Console.ReadLine(), out recordNumber))
                                        {
                                            WriteLine("Please enter a valid record number: ");
                                        }
                                        recordNumber--;
                                    }
                                }
                                rolePlayingGames[recordNumber].addChange();
                                break;
                            }
                        case 3:
                            {
                                if (gameType == 1)
                                {
                                    for (int x = 0; x < normalCounts; x++)
                                        videoGames[x].displayGame();
                                }
                                else
                                {
                                    for (int x = 0; x < roleCounts; x++)
                                        rolePlayingGames[x].displayGame();
                                }
                                break;
                            }
                        default:
                            {
                                WriteLine("Your entry was invalid please try again");
                                break;
                            }
                    }
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                choice = Menu();
            }

        }

        private static int Menu()
        {
            WriteLine("Main Menu");
            WriteLine("1-Add 2-Change 3-Print 4-Quit");
            int selection = 0;
            bool isNumber = int.TryParse(ReadLine(), out selection);
            while (!isNumber && selection < 1 || selection > 4)
            {
                WriteLine("Please make a valid selection!");
                WriteLine("1-Add 2-Change 3-Print 4-Quit");
                isNumber = int.TryParse(ReadLine(), out selection);
            }
            return selection;
        }
    }

    class VideoGames
    {
        protected string gameName;
        protected string gameDeveloper;
        protected string gameConsole;

        public VideoGames()
        {
            gameName = "";
            gameDeveloper = "";
            gameConsole = "";
        }

        public VideoGames(string gameName, string gameDeveloper, string gameConsole)
        {
            this.gameName = gameName;
            this.gameDeveloper = gameDeveloper;
            this.gameConsole = gameConsole;
        }

        public void GameName(string gameName)
        {
            this.gameName = gameName;
        }
        public void GameDeveloper(string gameDeveloper)
        {
            this.gameDeveloper = gameDeveloper;
        }
        public void GameConsole(string gameConsole)
        {
            this.gameConsole = gameConsole;
        }
        public string getGameName()
        {
            return this.gameName;
        }

        public string getGameDeveloper()
        {
            return this.gameDeveloper;
        }
        public string getGameConsole()
        {
            return this.gameConsole;
        }

        public virtual void addChange()
        {
            WriteLine("What is the name of the game: ");
            GameName(ReadLine());
            WriteLine("What is the game developers name: ");
            GameDeveloper(ReadLine());
            WriteLine("What console is the game on: ");
            GameConsole(ReadLine());
        }

        public virtual void displayGame()
        {
            WriteLine($"Game Name: {gameName}");
            WriteLine($"Game Developer: {gameDeveloper}");
            WriteLine($"Game Console: {gameConsole}");
        }
    }
    class RolePlayingGames : VideoGames
    {
        protected string worldName;
        protected int levelCap;

        public RolePlayingGames()
        {
            gameName = "";
            gameDeveloper = "";
            gameConsole = "";
            worldName = "";
            levelCap = 0;
        }

        public RolePlayingGames(string gameName, string gameDeveloper, string gameConsole, string worldName, int levelCap)
        {
            this.gameName = gameName;
            this.gameDeveloper = gameDeveloper;
            this.gameConsole = gameConsole;
            this.worldName = worldName;
            this.levelCap = levelCap;
        }
        public string getWorldName()
        {
            return this.worldName;
        }
        public int getLevelCap()
        {
            return this.levelCap;
        }
        public void setWorldName(string worldName)
        {
            this.worldName = worldName;
        }
        public void setLevelCap(int levelCap)
        {
            this.levelCap = levelCap;
        }

        public override void addChange()
        {
            WriteLine("What is the name of the game: ");
            gameName = ReadLine();
            WriteLine("What is the game developers name: ");
            gameDeveloper = ReadLine();
            WriteLine("What console is the game on: ");
            gameConsole = ReadLine();
            WriteLine("What is the games world name: ");
            worldName = ReadLine();
            WriteLine("What is the games level cap: ");
            levelCap = int.Parse(ReadLine());
        }
        public override void displayGame()
        {
            WriteLine($"Game Name: {gameName}");
            WriteLine($"Game Developer: {gameDeveloper}");
            WriteLine($"Game Console: {gameConsole}");
            WriteLine($"World Name: {worldName}");
            WriteLine($"Level Cap: {levelCap}");
        }
    }
}
