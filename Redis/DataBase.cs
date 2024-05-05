using StackExchange.Redis;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.ApplicationServices;
using System.Security.Cryptography;

namespace anonymous_chat.Redis
{
    public class DataBase
    {
        private static ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("ec2-18-204-20-251.compute-1.amazonaws.com");
        private static IDatabase db = redis.GetDatabase();

        public bool IsConnected()
        {
            try
            {
            return redis.IsConnected;
            }
            catch (Exception)
            {
                throw new ArgumentException("Cannot connect to the database server");
            }
        }

        #region User Data

        public bool StoreUserData(IDatabase db, string email, string username, string password)
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

            // Get the next user ID
            long UID = db.StringIncrement("UID");

            // Create a UserData instance
            UserData user = new UserData
            {
                UID = UID,
                UserName = username,
                Email = email,
                Password = password,
            };

            // Serialize the UserData instance to JSON
            string jsonData = JsonConvert.SerializeObject(user);

            // Store the JSON in Redis
            return db.StringSet($"user:{UID}", jsonData);
        }

        public bool IsValidEmail(string email)
        {
            var regex = new Regex(@"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$");
            return regex.IsMatch(email);
        }

        public bool UpdateUserData(IDatabase db, long UID, string email, string username, string password)
        {
            // Update a UserData instance
            UserData user = new UserData
            {
                UserName = username,
                Password = password,
            };

            // Serialize the UserData object to a JSON string
            string jsonData = JsonConvert.SerializeObject(user);

            // Store the JSON string in the Redis database with the key "user:{UID}"
            return db.StringSet($"user:{UID}", jsonData);
        }

        #endregion

        public IDatabase GetDatabase()
        {
            if (IsConnected())
            {
                return db;
            }
            else
            {
                throw new ArgumentException("Cannot connect to the database server");
            }
        }
    }
}
