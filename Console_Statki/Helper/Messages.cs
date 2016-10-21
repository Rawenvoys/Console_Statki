﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Statki.Helper
{
    class Messages
    {
        public static string UPPER_LOWER_FRAME = "************************************************************************";
        public static string MID_FRAME = "*                                                                      *";
        public static string WELCOME_TEXT = "*                           Podaj swój nick:                           *";
        public static string START_ALERT = "Nie udało się zainicjować programu. Program zostanie wyjebany w kosmos";
        public static string CURSOR_ALERT = "Nie udało się ustawić kursora";
        public static string MENU_TEXT = "                        MENU:                                      ";
        public static string MENU_FIRST_PART = "                         ";
        public static string MENU_SECOND_PART = "           ";
        public static string MENU_NEW_GAME =           "Rozpocznij nową grę z komputerem";
        public static string MENU_NEW_GAME_2_PLAYERS = "Rozpocznij nową grę z graczem   ";
        public static string MENU_HIGHSCORES =         "Highscores                      ";
        public static string MENU_CLOSE =              "Zakończ grę                     ";
        public static string CONTROLS = "Używaj \u2191 \u2190 \u2192 \u2193 aby wybrać pozycję do ostrzału. Zatwierdź ją klikając Enter\n&-Zatopiony \n*-Pudło \n$-Trafiony \n~-Nie Odkryte ";
        public static string CONTROLS_PLACE_SHIP = "Używaj \u2191 \u2190 \u2192 \u2193 aby wybrać pozycję Statku. Zatwierdź ją klikając Enter\n&-Zatopiony \n*-Pudło \n$-Trafiony \n~-Nie Odkryte ";
        public static string GAME_SCREEN_ALERT = "Wystąpił błąd ekranu gry!"; 
        public static string MENU_ALERT = "Nie udało się poprawnie wyświetlić Menu";
        public static string SET_ALERT = "\nUstawienie w tej pozycji statku jest rzeczą awykonalną! Przekieruj swój \nkrążownik na inne koordynaty.";
        public static string SET_BOMB_ALERT = "\n nie możesz postawić bomby w tym samym miejscu";
        public static string CREATE_SCREEN_ALERT = "\nBłąd Create Screen";
        public static string GIRL_PART1 = "                         8888  8888888\n                  888888888888888888888888\n               8888:::8888888888888888888888888\n             8888::::::8888888888888888888888888888\n            88::::::::888:::8888888888888888888888888\n          88888888::::8:::::::::::88888888888888888888\n        888 8::888888::::::::::::::::::88888888888   888\n           88::::88888888::::m::::::::::88888888888    8\n         888888888888888888:M:::::::::::8888888888888\n        88888888888888888888::::::::::::M88888888888888\n        8888888888888888888888:::::::::M8888888888888888\n         8888888888888888888888:::::::M888888888888888888\n        8888888888888888::88888::::::M88888888888888888888\n      88888888888888888:::88888:::::M888888888888888   8888\n     88888888888888888:::88888::::M::;o*M*o;888888888    88\n    88888888888888888:::8888:::::M:::::::::::88888888    8\n   88888888888888888::::88::::::M:;:::::::::::888888888     \n  8888888888888888888:::8::::::M::aAa::::::::M8888888888       8\n  88   8888888888::88::::8::::M:::::::::::::888888888888888 8888\n 88  88888888888:::8:::::::::M::::::::::;::88:88888888888888888\n 8  8888888888888:::::::::::M::''@@@@@@@''::::8w8888888888888888\n ";
        public static string GIRL_PART2 = "88888888888:888::::::::::M:::::''@a@'':::::M8i888888888888888\n 8888888888::::88:::::::::M88:::::::::::::M88z88888888888888888\n 8888888888:::::8:::::::::M88888:::::::::MM888!888888888888888888\n888888888:::::8:::::::::M8888888MAmmmAMVMM888*88888888   88888888\n888888 M:::::::::::::::M888888888:::::::MM88888888888888   8888888\n8888   M::::::::::::::M88888888888::::::MM888888888888888    88888\n 888   M:::::::::::::M8888888888888M:::::mM888888888888888    8888\n  888  M::::::::::::M8888:888888888888::::m::Mm88888 888888   8888\n   88  M::::::::::::8888:88888888888888888::::::Mm8   88888   888\n   88  M::::::::::8888M::88888::888888888888:::::::Mm88888    88\n   8   MM::::::::8888M:::8888:::::888888888888::::::::Mm8     4\n      8M:::::::8888M:::::888:::::::88:::8888888::::::::Mm    2\n      88MM:::::8888M:::::::88::::::::8:::::888888:::M:::::M\n     8888M:::::888MM::::::::8:::::::::::M::::8888::::M::::M\n    88888M:::::88:M::::::::::8:::::::::::M:::8888::::::M::M\n   88 888MM:::888:M:::::::::::::::::::::::M:8888:::::::::M:\n   8 88888M:::88::M:::::::::::::::::::::::MM:88::::::::::::M\n     88888M:::88::M::::::::::*88*::::::::::M:88::::::::::::::M\n    888888M:::88::M:::::::::88@@88:::::::::M::88::::::::::::::M\n    888888MM::88::MM::::::::88@@88:::::::::M:::8::::::::::::::*8\n    88888  M:::8::MM:::::::::*88*::::::::::M:::::::::::::::::88@@\n    8888   MM::::::MM:::::::::::::::::::::MM:::::::::::::::::88@@\n     888    M:::::::MM:::::::::::::::::::MM::M::::::::::::::::*8\n     888    MM:::::::MMM::::::::::::::::MM:::MM:::::::::::::::M\n      88     M::::::::MMMM:::::::::::MMMM:::::MM::::::::::::MM\n       88    MM:::::::::MMMMMMMMMMMMMMM::::::::MMM::::::::MMM\n        88    MM::::::::::::MMMMMMM::::::::::::::MMMMMMMMMM\n         88   8MM::::::::::::::::::::::::::::::::::MMMMMM\n          8   88MM::::::::::::::::::::::M:::M::::::::MM\n              888MM::::::::::::::::::MM::::::MM::::::MM\n             88888MM:::::::::::::::MMM:::::::mM:::::MM\n             888888MM:::::::::::::MMM:::::::::MMM:::M\n            88888888MM:::::::::::MMM:::::::::::MM:::M\n           88 8888888M:::::::::MMM::::::::::::::M:::M\n           8  888888 M:::::::MM:::::::::::::::::M:::M:\n              888888 M::::::M:::::::::::::::::::M:::MM\n             888888  M:::::M::::::::::::::::::::::::M:M\n             888888  M:::::M:::::::::@::::::::::::::M::M\n             88888   M::::::::::::::@@:::::::::::::::M::M\n            88888   M::::::::::::::@@@::::::::::::::::M::M\n           88888   M:::::::::::::::@@::::::::::::::::::M::M\n          88888   M:::::m::::::::::@::::::::::Mm:::::::M:::M\n          8888   M:::::M:::::::::::::::::::::::MM:::::::M:::M\n         8888   M:::::M:::::::::::::::::::::::MMM::::::::M:::M\n        888    M:::::Mm::::::::::::::::::::::MMM:::::::::M::::M\n      8888    MM::::Mm:::::::::::::::::::::MMMM:::::::::m::m:::M\n     888      M:::::M::::::::::::::::::::MMM::::::::::::M::mm:::M\n  8888       MM:::::::::::::::::::::::::MM:::::::::::::mM::MM:::M:\n             M:::::::::::::::::::::::::M:::::::::::::::mM::MM:::Mm\n            MM::::::m:::::::::::::::::::::::::::::::::::M::MM:::MM\n            M::::::::M:::::::::::::::::::::::::::::::::::M::M:::MM  \n           MM:::::::::M:::::::::::::M:::::::::::::::::::::M:M:::MM\n           M:::::::::::M88:::::::::M:::::::::::::::::::::::MM::MMM\n           M::::::::::::8888888888M::::::::::::::::::::::::MM::MM\n           M:::::::::::::88888888M:::::::::::::::::::::::::M::MM\n           M::::::::::::::888888M:::::::::::::::::::::::::M::MM\n           M:::::::::::::::88888M:::::::::::::::::::::::::M:MM\n           M:::::::::::::::::88M::::::::::::::::::::::::::MMM\n           M:::::::::::::::::::M::::::::::::::::::::::::::MMM\n           MM:::::::::::::::::M::::::::::::::::::::::::::MMM\n            M:::::::::::::::::M::::::::::::::::::::::::::MMM\n            MM:::::::::::::::M::::::::::::::::::::::::::MMM\n             M:::::::::::::::M:::::::::::::::::::::::::MMM\n             MM:::::::::::::M:::::::::::::::::::::::::MMM\n              M:::::::::::::M::::::::::::::::::::::::MMM\n              MM:::::::::::M::::::::::::::::::::::::MMM\n               M:::::::::::M:::::::::::::::::::::::MMM  \n               MM:::::::::M:::::::::::::::::::::::MMM\n                M:::::::::M::::::::::::::::::::::MMM\n                MM:::::::M::::::::::::::::::::::MMM\n                 MM::::::M:::::::::::::::::::::MMM\n                 MM:::::M:::::::::::::::::::::MMM\n                  MM::::M::::::::::::::::::::MMM\n                  MM:::M::::::::::::::::::::MMM\n                   MM::M:::::::::::::::::::MMM\n                   MM:M:::::::::::::::::::MMM\n                    MMM::::::::::::::::::MMM\n                    MM::::::::::::::::::MMM\n                     M:::::::::::::::::MMM\n                    MM::::::::::::::::MMM\n                    MM:::::::::::::::MMM\n                    MM::::M:::::::::MMM:\n                    mMM::::MM:::::::MMMM\n                     MMM:::::::::::MMM:M\n                     mMM:::M:::::::M:M:M\n                      MM::MMMM:::::::M:M\n                      MM::MMM::::::::M:M\n                      mMM::MM::::::::M:M\n                       MM::MM:::::::::M:M\n                       MM::MM::::::::::M:m\n                       MM:::M:::::::::::MM\n                       MMM:::::::::::::::M:\n                       MMM:::::::::::::::M:\n                       MMM::::::::::::::::M\n                       MMM::::::::::::::::M\n                       MMM::::::::::::::::Mm\n                        MM::::::::::::::::MM\n                        MMM:::::::::::::::MM\n                        MMM:::::::::::::::MM\n                        MMM:::::::::::::::MM\n                        MMM:::::::::::::::MM\n                         MM::::::::::::::MMM\n                         MMM:::::::::::::MM\n                         MMM:::::::::::::MM\n                         MMM::::::::::::MM\n                          MM::::::::::::MM\n                          MM::::::::::::MM\n                          MM:::::::::::MM\n                          MMM::::::::::MM\n                          MMM::::::::::MM\n                           MM:::::::::MM\n                           MMM::::::::MM\n                           MMM::::::::MM\n                            MM::::::::MM\n                            MMM::::::MM\n                            MMM::::::MM\n                             MM::::::MM\n                             MM::::::MM\n                              MM:::::MM\n                              MM:::::MM:\n                              MM:::::M:M\n                              MM:::::M:M\n                              :M::::::M:\n                             M:M:::::::M\n                            M:::M::::::M\n                           M::::M::::::M\n                          M:::::M:::::::M\n                         M::::::MM:::::::M\n                         M:::::::M::::::::M\n                         M;:;::::M:::::::::M\n                         M:m:;:::M::::::::::M\n                         MM:m:m::M::::::::;:M\n                          MM:m::MM:::::::;:;M\n                           MM::MMM::::::;:m:M\n                            MMMM MM::::m:m:MM\n                                  MM::::m:MM\n                                   MM::::MM\n                                   MM::MM \n";
        public static string SHIP = "               ,:',:`,:',:'\n                                __||_||_||_||___\n                           ____['''''''''''''''']___\n                           \\'''''''''''''''''''''''/ \n                     ~^^~^~^~^~^~^BATTLE SHIP~~^~^~^~^~~^~^  \n\n\n ";                 
    }
}
