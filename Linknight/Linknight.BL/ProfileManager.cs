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
    public class ProfileManager
    {
        

        public static int Insert(Profile profile, bool rollback = false)
        {
            try
            {
                IDbContextTransaction transaction = null;

                using (LinknightEntities dc = new LinknightEntities())
                {
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblProfile newrow = new tblProfile();
                    newrow.Id = Guid.NewGuid();
                    newrow.Name = profile.Name;
                    newrow.LobbyId = profile.LobbyId;
                    newrow.ColorId = profile.ColorId;
                    newrow.ArmorId = profile.ArmorId;
                    newrow.HelmId = profile.HelmId;

                    profile.Id = newrow.Id;

                    dc.tblProfiles.Add(newrow);
                    int results = dc.SaveChanges();

                    if (rollback) transaction.Rollback();

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

                    tblProfile row = dc.tblProfiles.FirstOrDefault(c => c.Id == id);
                    int results = 0;
                    if (row != null)
                    {
                        if (rollback) transaction = dc.Database.BeginTransaction();

                        dc.tblProfiles.Remove(row);
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

        public async static Task<int> Update(Profile profile, bool rollback = false)
        {
            try
            {
                IDbContextTransaction transaction = null;
                using (LinknightEntities dc = new LinknightEntities())
                {
                    tblProfile row = dc.tblProfiles.FirstOrDefault(c => c.Id == profile.Id);
                    int results = 0;
                    if (row != null)
                    {
                        if (rollback) transaction = dc.Database.BeginTransaction();
                        row.Name = profile.Name;
                        row.LobbyId = profile.LobbyId;
                        row.ColorId = profile.ColorId;
                        row.HelmId = profile.HelmId;
                        row.ArmorId = profile.ArmorId;

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

        public async static Task<Profile> LoadById(Guid id)
        {
            try
            {
                using (LinknightEntities dc = new LinknightEntities())
                {
                    tblProfile tblProfile = dc.tblProfiles.Where(c => c.Id == id).FirstOrDefault();
                    Profile profile = new Profile();

                    if (tblProfile != null)
                    {
                        // Put the table row values into the object.
                        profile.Id = tblProfile.Id;
                        profile.Name = tblProfile.Name;
                        profile.LobbyId = tblProfile.LobbyId;
                        profile.ColorId = tblProfile.ColorId;
                        profile.HelmId = tblProfile.HelmId;
                        profile.ArmorId = tblProfile.ArmorId;
                        return profile;
                    }
                    else
                    {
                        throw new Exception("Could not find the row");
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async static Task<IEnumerable<Profile>> Load()
        {
            try
            {
                List<Profile> profiles = new List<Profile>();
                using (LinknightEntities dc = new LinknightEntities())
                {
                    dc.tblProfiles
                        .ToList()
                        .ForEach(c => profiles.Add(new Profile
                        {
                            Id = c.Id,
                            Name = c.Name,
                            LobbyId = c.LobbyId,
                            ColorId = c.ColorId,
                            ArmorId = c.ArmorId,
                            HelmId = c.HelmId
                        }));
                }
                return profiles;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }

}

