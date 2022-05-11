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
    public static class LobbyManager
    {
        public async static Task<int> Insert(Lobby lobby, bool rollback = false)
        {
            try
            {
                IDbContextTransaction transaction = null;

                using (LinknightEntities dc = new LinknightEntities())
                {
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblLobby newrow = new tblLobby();
                    newrow.Id = Guid.NewGuid();
                    newrow.LobbyKey = lobby.LobbyKey;

                    lobby.Id = newrow.Id;

                    dc.tblLobbies.Add(newrow);
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
        public async static Task<int> Update(Lobby lobby, bool rollback = false)
        {
            try
            {
                IDbContextTransaction transaction = null;
                using (LinknightEntities dc = new LinknightEntities())
                {
                    tblLobby row = dc.tblLobbies.FirstOrDefault(c => c.Id == lobby.Id);
                    int results = 0;
                    if (row != null)
                    {
                        if (rollback) transaction = dc.Database.BeginTransaction();
                        row.LobbyKey = lobby.LobbyKey;

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

        public async static Task<Lobby> LoadById(Guid id)
        {
            try
            {
                using (LinknightEntities dc = new LinknightEntities())
                {
                    tblLobby tblLobby = dc.tblLobbies.Where(c => c.Id == id).FirstOrDefault();
                    Lobby lobby = new Lobby();

                    if (tblLobby != null)
                    {
                        // Put the table row values into the object.
                        lobby.Id = tblLobby.Id;
                        lobby.LobbyKey = tblLobby.LobbyKey;
                        return lobby;
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

        public async static Task<List<Lobby>> Load()
        {
            try
            {
                using (var dc = new LinknightEntities())
                {
                    List<Lobby> lobbies = new List<Lobby>();

                    dc.tblLobbies.ToList().ForEach(row => lobbies.Add(new Lobby()
                    {
                        Id = row.Id,
                        LobbyKey = row.LobbyKey
                    }));

                    return lobbies;
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
                using (LinknightEntities dc = new LinknightEntities())
                {
                    int result = 0;
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblLobby deleterow = dc.tblLobbies.FirstOrDefault(row => row.Id == id);

                    if (deleterow != null)
                    {
                        dc.tblLobbies.Remove(deleterow);
                        result = dc.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Row was not found.");
                    }

                    if (rollback) transaction.Rollback();

                    return result;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

    }

}

