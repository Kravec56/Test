using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new UsersDB())
            {
                System.Console.Write("Введите фамилию: ");
                var fam1 = System.Console.ReadLine();

                var user = new User { fam = fam1 };
                db.Users.Add(user);
                db.SaveChanges();

                var query = from b in db.Users
                            orderby b.fam
                            select b;

                System.Console.WriteLine("Все пользователи:");
                foreach (var item in query)
                {
                    System.Console.WriteLine(item.fam);
                }
            }
        }

    }
    public class User
    {
        public int id { get; set; }
        public string fam { get; set; }
        public string name { get; set; }
        public string date_s { get; set; }
        public string date_p { get; set; }
        public string status { get; set; }

        public virtual List<Task> Tasks { get; set; }
    }
    public class Task
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string date_s { get; set; }
        public string date_p { get; set; }
        public string status { get; set; }
        public int User_p_id { get; set; }
        public int User_i_id { get; set; }
        public virtual User User { get; set; }
    }
    public class UsersDB : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}
