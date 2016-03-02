using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CourseProject.Models
{
    public enum UserType
    {
        Participant, Expert
    }

    public class Account
    {
        public System.Guid ID { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите свой логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите свой пароль")]
        public string Password { get; set; }
        public string E_mail { get; set; }
        public string Telephone { get; set; }
        public UserType UserType { get; set; }
    }
}