using Linknight.BL.Models;
using Linknight.PL;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linknight.BL
{

    public class UserManager
    {
        private static string GetHash(string password)
        {
            using (var hash = new System.Security.Cryptography.SHA1Managed())
            {
                var hashbytes = System.Text.Encoding.UTF8.GetBytes(password);
                return Convert.ToBase64String(hash.ComputeHash(hashbytes));
            }
        }

        public static void Seed()
        {
            User user = new User(Guid.NewGuid(), "User1", "John", "Smith", "jsmith");
            Insert(user);

            user = new User(Guid.NewGuid(), "User2", "Sarah", "Baker", "sbaker");
            Insert(user);

            user = new User(Guid.NewGuid(), "User3", "Robert", "Tanner", "rtanner");
            Insert(user);
        }

        public static int Insert(User user, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (LinknightEntities dc = new LinknightEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblUser newuser = new tblUser();
                    newuser.Id = Guid.NewGuid();
                    newuser.Password = GetHash(user.Password);
                    newuser.FirstName = user.FirstName;
                    newuser.LastName = user.LastName;
                    newuser.Username = user.Username;

                    dc.tblUsers.Add(newuser);
                    results = dc.SaveChanges();
                    if (rollback) transaction.Rollback();

                    return results;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async static Task<int> Update(User user, bool rollback = false)
        {
            try
            {
                IDbContextTransaction transaction = null;
                using (LinknightEntities dc = new LinknightEntities())
                {
                    tblUser row = dc.tblUsers.FirstOrDefault(u => u.Id == user.Id);
                    int results = 0;
                    if(row != null)
                    {
                        if (rollback) transaction = dc.Database.BeginTransaction();
                        row.Username = user.Username;
                        row.FirstName = user.FirstName;
                        row.LastName = user.LastName;
                        row.Password = user.Password;

                        results = dc.SaveChanges();
                        if (rollback) transaction.Rollback();
                    }
                    else
                    {
                        throw new Exception("Row was not found.");
                    }
                    return results;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async static Task<int> Delete(Guid id, bool rollback = false)
        {
            try
            {
                IDbContextTransaction transaction = null;
                using (LinknightEntities dc = new LinknightEntities())
                {

                    tblUser row = dc.tblUsers.FirstOrDefault(c => c.Id == id);
                    int results = 0;
                    if (row != null)
                    {
                        if (rollback) transaction = dc.Database.BeginTransaction();

                        dc.tblUsers.Remove(row);
                        results = dc.SaveChanges();
                        if (rollback) transaction.Rollback();

                    }
                    else
                    {
                        throw new Exception("Row was not found.");
                    }
                    return results;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<User> Load()
        {
            try
            {
                List<User> users = new List<User>();
                using (LinknightEntities dc = new LinknightEntities())
                {
                    dc.tblUsers
                        .ToList()
                        .ForEach(u => users.Add(new User
                        {
                            Id = u.Id,
                            Username = u.Username,
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            Password = u.Password
                        }));
                    return users;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async static Task<List<User>> LoadById(Guid userId)
        {
            return null;
        }

        public static bool Login(User user)
        {
            try
            {
                if (!string.IsNullOrEmpty(user.Username))
                {
                    if (!string.IsNullOrEmpty(user.Password))
                    {
                        using (LinknightEntities dc = new LinknightEntities())
                        {
                            tblUser tbluser = dc.tblUsers.FirstOrDefault(u => u.Username == user.Username);
                            if (tbluser != null)
                            {
                                if (tbluser.Password == GetHash(user.Password))
                                {
                                    user.FirstName = tbluser.FirstName;
                                    user.LastName = tbluser.LastName;
                                    user.Id = tbluser.Id;
                                    return true;
                                }
                                else
                                {
                                    throw new LoginFailureException();
                                }

                            }
                            else
                            {
                                throw new Exception("User Id could not be found.");
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Password was not set.");
                    }
                }
                else
                {
                    throw new Exception("User Id was not set.");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static int DeleteAll()
        {
            try
            {
                using (LinknightEntities dc = new LinknightEntities())
                {
                    var users = dc.tblUsers.ToList();
                    dc.tblUsers.RemoveRange(users);
                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
