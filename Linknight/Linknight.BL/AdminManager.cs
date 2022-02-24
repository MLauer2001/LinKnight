using Linknight.BL.Models;
using Linknight.PL;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Linknight.BL
{
    public class LoginFailureException : Exception
    {
        public LoginFailureException() : base("ERROR: Cannot log in with these credentials.")
        {
        }
        public LoginFailureException(string message) : base(message)
        {
        }
    }

    public class AdminManager
    {
        private static string GetHash(string password)
        {
            using (var hash = new System.Security.Cryptography.SHA1Managed())
            {
                var hashbytes = System.Text.Encoding.UTF8.GetBytes(password);
                return Convert.ToBase64String(hash.ComputeHash(hashbytes));
            }
        }

        public static int Insert(Admin admin, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (LinknightEntities dc = new LinknightEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblAdmin newAdmin = new tblAdmin();
                    newAdmin.Id = Guid.NewGuid();
                    newAdmin.UserName = admin.UserName;
                    newAdmin.FirstName = admin.FirstName;
                    newAdmin.LastName = admin.LastName;
                    newAdmin.Password = GetHash(admin.Password);
                    

                    dc.tblAdmins.Add(newAdmin);
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

        public static int Update(Admin admin, bool rollback = false)
        {
            return 0;
        }

        public static Admin LoadByUsername(string userName)
        {
            return null;
        }

        public static Admin LoadById(Guid id)
        {
            return null;
        }

        public static List<Admin> Load()
        {
            return null;
        }

        public static bool Login(Admin admin)
        {
            try
            {
                if (!string.IsNullOrEmpty(admin.UserName))
                {
                    if (!string.IsNullOrEmpty(admin.Password))
                    {
                        using (LinknightEntities dc = new LinknightEntities())
                        {
                            tblAdmin tblAdmin = dc.tblAdmins.FirstOrDefault(a => a.UserName == admin.UserName);
                            if (tblAdmin != null)
                            {
                                if (tblAdmin.Password == GetHash(admin.Password))
                                {
                                    admin.FirstName = tblAdmin.FirstName;
                                    admin.LastName = tblAdmin.LastName;
                                    admin.Id = tblAdmin.Id;
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
                    var admins = dc.tblAdmins.ToList();
                    dc.tblAdmins.RemoveRange(admins);
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
