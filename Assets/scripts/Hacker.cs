

using UnityEngine;


public class Hacker : MonoBehaviour
{
    //game config
    const string MenuHint = " type menu to return to main menu"; 
    string[] level1passwords = { "balance", "draft", "creditcard", "commission", "deposit" };
    string[] level2passwords = { "mob", "gangdom", "underworld", "crime", "ring", "family" };
    string[] level3passwords = { "soldiery", "combatant", "pugnacious", "militaristic", "delegation", "legionnaire" };
    // Start is called before the first frame update

    int level;
    string password;

    enum Screen { MainMenu, Password, Win };
    Screen currentscreen;


    void Start()
    {


        ShowMainMenu();
    }
   
    void ShowMainMenu()
        {
            currentscreen = Screen.MainMenu;
            Terminal.ClearScreen();
          
            Terminal.WriteLine("Phoenix Gaming");
            Terminal.WriteLine("welcome Phoenix lets get hacking");
            Terminal.WriteLine("1.World Bank");
            Terminal.WriteLine("2.Mafia Security Base");
            Terminal.WriteLine("3.Military Base");
        Terminal.WriteLine("Enter Your selection:");

        }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
            
        }
        else if (currentscreen == Screen.MainMenu)
        {
            RunMainMenu(input);
            
        }
        else if (currentscreen == Screen.Password)
        {
           Checkpassword(input);

        }

    }

     void RunMainMenu(string input)
    {
        bool isValidlevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidlevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
       
    }

    

    void AskForPassword()
    {
         currentscreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("enter password, hint:"+   password.Anagram());

        Terminal.WriteLine(MenuHint);


        void SetRandomPassword()
    {
            switch (level)
            {
                case 1:

                    password = level1passwords[Random.Range(0, level1passwords.Length)];
                    break;
                case 2:

                    password = level2passwords[Random.Range(0, level2passwords.Length)];
                    break;
                case 3:
                    password = level3passwords[Random.Range(0, level3passwords.Length)];
                    break;
                default:
                    Debug.LogError("Intruder!!!!");
                    break;
            }

        }
    }

    void  Checkpassword(string input)
    {
        if (input == password)
        {
            DisplayWinscreen();

        }
        else
        {
            AskForPassword();
        }
    }

     void DisplayWinscreen()
    {
        currentscreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(MenuHint);
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
            
                Terminal.WriteLine(@"
||====================================================================||
||//$\\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\//$\\||
||(100)==================| FEDERAL RESERVE NOTE |================(100)||
||\\$//        ~         '------========--------'                \\$//||
||<< /        /$\              // ____ \\                         \ >>||
||>>|  12    //L\\            // ///..) \\         L38036133B   12 |<<||
||<<|        \\ //           || <||  >\  ||                        |>>||
||>>|         \$/            ||  $$ --/  ||        One Hundred     |<<||
||<<|      L38036133B        *\\  |\_/  //* series                 |>>||
||>>|  12                     *\\/___\_//*   1989                  |<<||
||<<\      Treasurer     ______/Franklin\________     Secretary 12 />>||
||//$\                 ~|UNITED STATES OF AMERICA|~               /$\\||
||(100)===================  ONE HUNDRED DOLLARS =================(100)||
||\\$//\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\\$//||
||====================================================================||

                            


"

                );
                Terminal.WriteLine("WELCOME BACK SIR!");
                break;
            case 2:
                Terminal.WriteLine("MAFIA BASE LOADED SIR!");
                Terminal.WriteLine(@"
█▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█▄				 
███████████████████████
▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓◤
▀ ▐▓▓▓▓▓▓▌▀█   █▀
  ▓▓▓▓▓▓█▄▄▄▄▄█▀
 █▓▓▓▓▓▌
▐█▓▓▓▓▓
▐██████▌

"

                );
                break;
            case 3:
                Terminal.WriteLine("Welcome Back General");
                Terminal.WriteLine(@"                           
          (_) (_) |                  
 _ __ ___  _| |_| |_ __ _ _ __ _   _ 
| '_ ` _ \| | | | __/ _` | '__| | | |
| | | | | | | | | || (_| | |  | |_| |
|_| |_| |_|_|_|_|\__\__,_|_|   \__, |
                                __/ |
                               |___/ 
"
);
                break;
        }
        
    }


    // Update is called once per frame

}
