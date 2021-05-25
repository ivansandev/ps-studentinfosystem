using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UserLogin
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Въведете потребителско име: ");
            string username = Console.ReadLine();
            Console.Write("Въведете парола: ");
            string password = Console.ReadLine();

            LoginValidation validator = new LoginValidation(username, password, showErrorMessage);

            User user = null;

            if (validator.ValidateUserInput(ref user))
            {
                Console.WriteLine("Потребителско име: " + user.Username);
                Console.WriteLine("Парола: " + user.Password);
                Console.WriteLine("Факултетен номер: " + user.FakNum);
            }

            switch (LoginValidation.CurrentUserRole)
            {
                case UserRoles.ANONYMOUS:
                    Console.WriteLine("Анонимен потребител! Моля наявете се с вашата сметка.");
                    break;

                case UserRoles.ADMIN:
                    Console.WriteLine("Административни права - АКТИВНИ.");
                    adminMenu();
                    break;

                case UserRoles.INSPECTOR:
                    Console.WriteLine("Инспектор потребител - АКТИВЕН.");
                    break;

                case UserRoles.PROFESSOR:
                    Console.WriteLine("Професор потребител - АКТИВЕН.");
                    break;

                case UserRoles.STUDENT:
                    Console.WriteLine("Студент потребител - АКТИВЕН.");
                    break;
            }
        }
        private static void showErrorMessage(string errorMessage)
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("[ERROR] " + errorMessage);
            Console.WriteLine("---------------------------------------------");
        }

        private static void adminMenu()
        {
            Console.WriteLine("Изберете опция:" +
                        "\n0. Изход" +
                        "\n1. Промяна на роля на потребител" +
                        "\n2. Промяна на активност на потребител" +
                        "\n3. Списък на потребителите" +
                        "\n4. Преглед на лог на активност" +
                        "\n5. Преглед на текуща активност");

            String username;
            int choice;
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 0: break;

                // Промяна на роля на потребител
                case 1:
                    Console.Write("Въведете потребителското име което искате да променяте: ");
                    username = Console.ReadLine();

                    Console.WriteLine("0 - АНОНИМЕН; 1 - АДМИН; 2 - ИНСПЕКТОР; 3 - ПРОФЕСОР; 4 - СТУДЕНТ;");
                    Console.Write("Въведете новата роля (с число) за потребител \"" + username + "\": ");

                    int newRoleInt;
                    UserRoles newRole;
                    // Проверка на входните данни (дали са int и валидация на числото спрямо възможните опции)
                    try
                    {
                        newRoleInt = Convert.ToInt32(Console.ReadLine());

                        if (newRoleInt < 0 || newRoleInt > 4)
                            throw new System.FormatException();

                        newRole = (UserRoles)newRoleInt;

                    }
                    catch (System.FormatException)
                    {
                        showErrorMessage("Моля въведете число между 0 и 4.");
                        break;
                    }

                    UserData.AssignUserRole(username, newRole);
                    break;

                // Промяна на активност на потребител
                case 2:
                    Console.Write("Въведете потребителското име което искате да променяте: ");
                    username = Console.ReadLine();

                    Console.WriteLine("Формат за дата: MM/DD/YYYY HH:MM:SS PM");
                    Console.Write("Въведете новата дата и час за активност на потребител \"" + username + "\": ");
                    string newActiveDateInput = Console.ReadLine();

                    DateTime newActiveDate = new DateTime();
                    // Валидация на въведената дата/час
                    try
                    {
                        newActiveDate = Convert.ToDateTime(newActiveDateInput);
                    }
                    catch (System.FormatException)
                    {
                        showErrorMessage("Грешен формат на въведената дата/час.");
                        break;
                    }

                    UserData.SetUserActiveTo(username, newActiveDate);
                    break;

                // Списък на потребителите
                case 3:
                    // за следващо упражнение...
                    break;

                // Преглед на лог на активност
                case 4:
                    Console.WriteLine("*** ЛОГ НА АКТИВНОСТ ***");
                    IEnumerable<string> log = Logger.GetLogs();
                    StringBuilder logStr = new StringBuilder();

                    foreach (string activity in log)
                    {
                        Console.WriteLine(activity);
                        logStr.Append(activity + Environment.NewLine);
                    }
                    Console.Write(logStr);
                    break;

                // Преглед на текуща активност
                case 5:
                    Console.Write("Въведете филтър: ");
                    string filter = Console.ReadLine();
                    Console.WriteLine(Environment.NewLine + "*** ТЕКУЩА АКТИВНОСТ ***");

                    IEnumerable<string> currentActivities = Logger.GetCurrentSessionActivities(filter);
                    StringBuilder strActivities = new StringBuilder();
                    foreach (string activity in currentActivities)
                    {
                        strActivities.Append(activity + Environment.NewLine);
                    }
                    Console.WriteLine(strActivities);
                    break;

                default:
                    break;
            }
        }
    }
}
