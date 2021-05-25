using System;
namespace UserLogin
{
    public class LoginValidation
    {
        public delegate void ActionOnError(string errorMsg);

        private string _username;
        private string _password;
        private string _errorMessage;
        private ActionOnError _actionOnError;

        public static UserRoles CurrentUserRole
        { get; private set; }
        public static string currentUserUsername
        { get; private set; }

        public LoginValidation(string username, string password, ActionOnError actionOnError)
        {
            this._username = username;
            this._password = password;
            this._actionOnError = actionOnError;
        }


        public bool ValidateUserInput(ref User user)
        {
            // Проверка на въведеното потребителско име
            Boolean emptyUsername;
            emptyUsername = _username.Equals(String.Empty);
            if (emptyUsername == true)
            {
                CurrentUserRole = UserRoles.ANONYMOUS;
                _errorMessage = "Не е посочено потребителско име";
                _actionOnError(_errorMessage);
                return false;
            }
            if (_username.Length < 5)
            {
                CurrentUserRole = UserRoles.ANONYMOUS;
                _errorMessage = "Потребителското име трябва да има повече от 5 символа.";
                _actionOnError(_errorMessage);
                return false;
            }

            // Проверка на въведената паролата
            Boolean emptyPassword;
            emptyPassword = _password.Equals(String.Empty);
            if (emptyPassword == true)
            {
                CurrentUserRole = UserRoles.ANONYMOUS;
                _errorMessage = "Не е посочена парола";
                _actionOnError(_errorMessage);
                return false;
            }
            if (_password.Length < 5)
            {
                CurrentUserRole = UserRoles.ANONYMOUS;
                _errorMessage = "Паролата трябва да има повече от 5 символа.";
                _actionOnError(_errorMessage);
                return false;
            }

            // Проверка за потребител
            User validUser = UserData.IsUserPassCorrect(_username, _password);
            if (validUser != null)
            {
                user = validUser;
                CurrentUserRole = (UserRoles)user.Role;
                currentUserUsername = _username;
                Logger.LogActivity("Успешен Login");
                return true;
            }
            else
            {
                CurrentUserRole = UserRoles.ANONYMOUS;
                _errorMessage = "Невалидно потребителско име или парола.";
                _actionOnError(_errorMessage);
                return false;
            }
        }
    }
}
