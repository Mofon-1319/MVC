using System;

namespace WebApp.Entity
{
    public class Customer
    {
        public string userName { get; set; }
        public string userGender { get; set; }
        public string userId { get; set; }
        public string userPassword { get; set; }

        public long userPhone { get; set; }

        public DateTime dateOfBirth { get; set; }

        public Customer()
        {

        }
        public Customer(string userId, string password)
        {
            this.userId = userId;
            this.userPassword = password;
        }
        public Customer(string name, string sex, string userId, string password, long phone, DateTime date)
        {
            this.userName = name;
            userGender = sex;
            this.userId = userId;
            this.userPassword = password;
            this.userPhone = phone;
            dateOfBirth = date;
        }
    }
}
