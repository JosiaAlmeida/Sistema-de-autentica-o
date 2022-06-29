using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthAPIMVC.Models
{
    public class User
    {
        public int? id {get;set;}
        public string userName {get;set;}
        public string password {get;set;}
        public string? role {get;set;}
        /*public User(int id, string userName, string password, string role){
            this.id = id;
            this.userName = userName; 
            this.password = password;
            this.role = role;
        }*/
    }
}