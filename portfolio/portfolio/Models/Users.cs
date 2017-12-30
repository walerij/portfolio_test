using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace portfolio.Models
{
    public class Users
    {
        public int id { get; set; }

        public string nick { get; set; }

		[Required(ErrorMessage ="Не заполнено поле Логин")]
        public string login { get; set; }

		[Required(ErrorMessage = "Не заполнено поле Пароль")]
		[DataType(DataType.Password, ErrorMessage = "Поле не является паролем")]
		public string passw { get; set; }
    }


}