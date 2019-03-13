using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OBBC_Vedligeholdelse
{
    public class Menu
    {
        Controller control = new Controller();
        private const string startMenu = @"..\..\StartMenu.txt";
        private const string firstMenu = @"..\..\FirstMenu.txt";
        private const string secondMenu = @"..\..\SecondMenu.txt";
        private const string thirdMenu = @"..\..\ThirdMenu.txt";
        private const string fourthMenu = @"..\..\FourthMenu.txt";
        private const string fifthMenu = @"..\..\FifthMenu.txt";
        public void Show()
        {
            bool running = true;
            do
            {
                try
                {
                    ShowSelectedMenu(startMenu);
                    string choice = GetUserChoice();
                    Console.Clear();
                    switch (choice)
                    {
                        case "0":
                            running = false;
                            break;
                        case "1":
                            ShowCurrentReports();
                            break;
                        case "2":
                            CreateNewReport();
                            break;
                        case "3":
                            ChangeStatus();
                            break;
                        case "4":
                            ShowOldReports();
                            break;
                        case "5":
                            ShowExtraInfoReports();
                            break;
                        default:
                            Console.WriteLine("Ugyldigt valg, prøv venligst igen.");
                            Console.ReadLine();
                            break;
                    }
                    Console.Clear();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }    
            }
            while (running);
        }

        private void ShowExtraInfoReports()
        {
            ShowSelectedMenu(fifthMenu);
            int areaChoice = int.Parse(Console.ReadLine());
            control.ShowExtraInfoReports(areaChoice);
        }

        private void ShowOldReports()
        {
            ShowSelectedMenu(fourthMenu);
            int areaChoice = int.Parse(Console.ReadLine());
            control.ShowOldReports(areaChoice);
        }
        public void ShowCurrentReports()
        {
            int areaChoice;
            do
            {
                ShowSelectedMenu(firstMenu);
                if (!int.TryParse(Console.ReadLine(), out areaChoice))
                {
                    areaChoice = -1;
                }
            }
            while (control.ShowCurrentReports(areaChoice) == false);
        }
        public void ChangeStatus()
        {
            Console.WriteLine("Indtast Rapport ID: ");
            int reportID = int.Parse(Console.ReadLine());
            ShowSelectedMenu(thirdMenu);
            int statusChoice = int.Parse(Console.ReadLine());
            control.ChangeStatus(statusChoice, reportID);
        }
        public void CreateNewReport()
        {
           ShowSelectedMenu(secondMenu);
           int areaChoice = int.Parse(Console.ReadLine());
           Console.Clear();
           Console.WriteLine("Beskriv Problemet med Maskinen");
           string errorReport = Console.ReadLine();
           Console.Clear();
           string date = CurrentOrManual();
           Console.Clear();
           Console.WriteLine($"Har du Extra information af tilføje? \nHvis ingen Extra information, tryk blot enter. ");
           string extraInfo = Console.ReadLine();
           control.CreateNewReport(areaChoice, errorReport, date, extraInfo);
        }
        public void ShowSelectedMenu(string selectedMenu)
        {
            try
            {
                using (StreamReader sr = new StreamReader(selectedMenu))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Filen kunne ikke læses");
                Console.WriteLine(e.Message);
            }
        }
        private string GetUserChoice()
        {
            Console.WriteLine();
            Console.Write("Indtast dit valg: ");
            return Console.ReadLine();
        }
        private string CreateDate()
        {
            Console.WriteLine("Indtast dag (f.eks 25)");
            int day = int.Parse(Console.ReadLine());
            Console.WriteLine("Indtast måned (f.eks 12)");
            int month = int.Parse(Console.ReadLine());
            Console.WriteLine("Indtast år (f.eks 2018)");
            int year = int.Parse(Console.ReadLine());
          
            string date = $"{day}-{month}-{year}";
            return date;
        }
        private string CurrentOrManual()
        {
            string result = null;
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("Vil du manuelt skrive dato, eller vælge nuværende tidspunkt?");
                Console.WriteLine("1: Manuelt");
                Console.WriteLine("2: Nuværende tidspunkt");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                        result = CreateDate();
                        running = false;
                }
                else if (choice == 2)
                {
                        result = DateTime.Now.ToString("yyyy-MM-dd H:mm");
                        running = false;
                }
                else
                {
                    Console.WriteLine("Forkert input ");
                }
            }
            return result;
        }
    }
}
