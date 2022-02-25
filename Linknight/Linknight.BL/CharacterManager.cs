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
    public class CharacterManager
    {


        public async static Task<int> Insert(Character character, bool rollback = false)
        {
            try
            {
                IDbContextTransaction transaction = null;

                using (LinknightEntities dc = new LinknightEntities())
                {
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblCharacter newrow = new tblCharacter();
                    newrow.Id = dc.tblCharacters.Any() ? dc.tblCharacters.Max(dt => dt.Id) + 1 : 1;
                    newrow.Color = character.Color.ToString();
                    newrow.ArmorId = character.ArmorId;
                    newrow.HelmId = character.HelmId;

                    character.Id = newrow.Id;

                    dc.tblCharacters.Add(newrow);
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

        public async static Task<int> Delete(int id, bool rollback = false)
        {
            try
            {
                IDbContextTransaction transaction = null;
                using (LinknightEntities dc = new LinknightEntities())
                {

                    tblCharacter row = dc.tblCharacters.FirstOrDefault(c => c.Id == id);
                    int results = 0;
                    if (row != null)
                    {
                        if (rollback) transaction = dc.Database.BeginTransaction();

                        dc.tblCharacters.Remove(row);
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

        public async static Task<int> Update(Character character, bool rollback = false)
        {
            try
            {
                IDbContextTransaction transaction = null;
                using (LinknightEntities dc = new LinknightEntities())
                {
                    tblCharacter row = dc.tblCharacters.FirstOrDefault(c => c.Id == character.Id);
                    int results = 0;
                    if (row != null)
                    {
                        if (rollback) transaction = dc.Database.BeginTransaction();
                        row.Color = character.Color.ToString();
                        row.ArmorId = character.ArmorId;
                        row.HelmId = character.HelmId;

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

        public async static Task<Character> LoadById(int id)
        {
            try
            {
                using (LinknightEntities dc = new LinknightEntities())
                {
                    tblCharacter tblCharacter = dc.tblCharacters.Where(c => c.Id == id).FirstOrDefault();
                    Character character = new Character();

                    if (tblCharacter != null)
                    {
                        // Put the table row values into the object.
                        character.Id = tblCharacter.Id;
                        character.Color = tblCharacter.Color.ToString();
                        character.ArmorId = tblCharacter.ArmorId;
                        character.HelmId = tblCharacter.HelmId;
                        return character;
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

        public async static Task<IEnumerable<Character>> Load()
        {
            try
            {
                List<Character> characters = new List<Character>();
                using (LinknightEntities dc = new LinknightEntities())
                {
                    dc.tblCharacters
                        .ToList()
                        .ForEach(c => characters.Add(new Character
                        {
                            Id = c.Id,
                            Color = c.Color,
                            ArmorId = c.ArmorId,
                            HelmId = c.HelmId
                        }));
                }
                return characters;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }

}

