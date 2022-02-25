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
    public class VideoManager
    {


        public async static Task<int> Insert(Video video, bool rollback = false)
        {
            try
            {
                IDbContextTransaction transaction = null;

                using (LinknightEntities dc = new LinknightEntities())
                {
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblVideo newrow = new tblVideo();
                    newrow.Id = Guid.NewGuid();
                    newrow.VideoURL = video.VideoURL;
                    newrow.LobbyId = video.LobbyId;

                    video.Id = newrow.Id;

                    dc.tblVideos.Add(newrow);
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

                    tblVideo row = dc.tblVideos.FirstOrDefault(c => c.Id == id);
                    int results = 0;
                    if (row != null)
                    {
                        if (rollback) transaction = dc.Database.BeginTransaction();

                        dc.tblVideos.Remove(row);
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

        public async static Task<int> Update(Video video, bool rollback = false)
        {
            try
            {
                IDbContextTransaction transaction = null;
                using (LinknightEntities dc = new LinknightEntities())
                {
                    tblVideo row = dc.tblVideos.FirstOrDefault(c => c.Id == video.Id);
                    int results = 0;
                    if (row != null)
                    {
                        if (rollback) transaction = dc.Database.BeginTransaction();
                        row.VideoURL = video.VideoURL;
                        row.LobbyId = video.LobbyId;

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

        public async static Task<Video> LoadById(Guid id)
        {
            try
            {
                using (LinknightEntities dc = new LinknightEntities())
                {
                    tblVideo tblVideo = dc.tblVideos.Where(c => c.Id == id).FirstOrDefault();
                    Video video = new Video();

                    if (tblVideo != null)
                    {
                        // Put the table row values into the object.
                        video.Id = tblVideo.Id;
                        video.VideoURL = tblVideo.VideoURL;
                        video.LobbyId = tblVideo.LobbyId;
                        return video;
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

        public async static Task<IEnumerable<Video>> Load()
        {
            try
            {
                List<Video> videos = new List<Video>();
                using (LinknightEntities dc = new LinknightEntities())
                {
                    dc.tblVideos
                        .ToList()
                        .ForEach(c => videos.Add(new Video
                        {
                            Id = c.Id,
                            VideoURL = c.VideoURL,
                            LobbyId = c.LobbyId
                        }));
                }
                return videos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }

}

