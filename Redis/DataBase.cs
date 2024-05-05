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
        private static ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("ec2-18-210-20-184.compute-1.amazonaws.com");
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
            if (db.KeyExists(email))
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

            // Store the JSON in Redis with the UID as the key
            bool isUserStored = db.StringSet(UID.ToString(), jsonData);

            // Store the email-UID mapping in Redis
            bool isMappingStored = db.StringSet(email, UID.ToString());

            return isUserStored && isMappingStored;
        }

        public bool IsValidEmail(string email)
        {
            var regex = new Regex(@"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$");
            return regex.IsMatch(email);
        }

        public bool UpdateUserData(IDatabase db, long UID, string newUsername, string newPassword)
        {
            // Get the existing user data
            string existingJsonData = db.StringGet(UID.ToString());
            UserData existingUser = JsonConvert.DeserializeObject<UserData>(existingJsonData);

            // Update the username and password
            existingUser.UserName = newUsername;
            existingUser.Password = newPassword;

            // Serialize the updated UserData object to a JSON string
            string updatedJsonData = JsonConvert.SerializeObject(existingUser);

            // Store the updated JSON string in the Redis database with the UID as the key
            return db.StringSet(UID.ToString(), updatedJsonData);
        }

        #endregion

        #region Online Users

        public void AddOnlineUser(IDatabase db, long UID, string IP, bool search)
        {
            Online online = new Online
            {
                UID = UID,
                IP = IP,
                Searching = search,
            };

            string jsonData = JsonConvert.SerializeObject(online);

            db.StringSet($"online:{UID}", jsonData);
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
