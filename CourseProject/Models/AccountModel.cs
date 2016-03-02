using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseProject.Models
{
    public class AccountModel
    {
        private List<Account> Accounts = new List<Account>();

        public AccountModel()
        {
            using(Entities db = new Entities())
            {
                var ParticipantsList = db.Участники.ToList();
                var ExpertsList = db.Участники.ToList();

                foreach(var Participant in ParticipantsList)
                    Accounts.Add(new Account() { Login = Participant.Логин, Password = Participant.Пароль, E_mail = Participant.E_mail, ID = Participant.ID_участника, Telephone = Participant.Телефон, UserType = UserType.Participant });
                foreach (var Expert in ExpertsList)
                    Accounts.Add(new Account() { Login = Expert.Логин, Password = Expert.Пароль, E_mail = Expert.E_mail, ID = Expert.ID_участника, Telephone = Expert.Телефон, UserType = UserType.Participant });
            }
        }

        public Account Find (string username)
        {
            return Accounts.Where(acc => acc.Login.Equals(username)).First();
        }

        public Account Login (string username, string password)
        {
            return Accounts.Where(acc => acc.Login.Equals(username) && acc.Password.Equals(password)).First();
        }
    }
}