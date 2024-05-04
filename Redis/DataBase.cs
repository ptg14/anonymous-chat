using StackExchange.Redis;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.ApplicationServices;

namespace anonymous_chat.Redis
{
    public class DataBase
    {
        private static ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("ec2-18-204-20-251.compute-1.amazonaws.com");
        private static IDatabase db = redis.GetDatabase();

        public bool StoreUserData(IDatabase db, string email, string username, string password, string ipAddress)
        {
            if (!IsValidEmail(email))
            {
                throw new ArgumentException("Invalid email format", nameof(email));
            }
            // Check if the email is already in use
            if (db.SetContains("emails", email))
            {
                throw new ArgumentException("Email is already in use", nameof(email));
            }
            // Create a UserData instance
            UserData user = new UserData
            {
                UserName = username,
                Email = email,
                Password = password,
                IPAddress = ipAddress
            };

            // Serialize the UserData instance to JSON
            string json = JsonConvert.SerializeObject(user);

            // Get the next user ID
            long UID = db.StringIncrement("UID");

            // Store the JSON in Redis
            return db.StringSet($"user:{UID}", json);
        }

        public bool IsValidEmail(string email)
        {
            var regex = new Regex(@"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$");
            return regex.IsMatch(email);
        }

        public IDatabase GetDatabase()
        {
            return db;
        }
    }
}
