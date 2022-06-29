using AuthAPIMVC.Models;

namespace AuthAPIMVC.Repositories
{
    public static class UserRepository
    {
        public static User Get(string userName, string password){
            var users = new List<User>{
                new User{id=1, userName = "batman", password="batman",role="manager"},
                new User{id=2, userName = "robin", password="robin",role="employee"}
            };
            return users.FirstOrDefault(x => x.userName.ToLower() == userName.ToLower() 
                && x.password.ToLower() == password.ToLower());
        }
    }
}