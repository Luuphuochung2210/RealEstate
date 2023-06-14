﻿using RealEstate.Models;
using Microsoft.EntityFrameworkCore;

namespace RealEstate.Reposistory
{
    public interface IPostReposistory
    {
        public List<Post> GetAll();

        public List<Post> GetTop3();

        public Boolean Create(Post post);

        public Boolean Update(Post post);

        public Boolean Delete(int postid);
    }

    public class PostReposistory : IPostReposistory
    {
        private Ntphu24072001CnaContext _ctx;
        public PostReposistory(Ntphu24072001CnaContext ctx)
        {
            _ctx = ctx;
        }

        public bool Create(Post post)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int postid)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetAll()
        {
            return _ctx.Posts
                .Include(x => x.RealEstate)
                .ThenInclude(prop => prop.Images)
                .Include(x => x.RealEstate)
                .ThenInclude(cate => cate.Category)
                .Include(x => x.RealEstate)
                .ThenInclude(locate => locate.Location)
                .Include(x => x.RealEstate)
                .ThenInclude(invest => invest.ChuDauTu).ToList();
        }

        public List<Post> GetTop3()
        {
            return _ctx.Posts
                .Include(x => x.RealEstate)
                .ThenInclude(cate => cate.Category)
                .Include(x => x.RealEstate)
                .ThenInclude(locate => locate.Location)
                .Include(x => x.RealEstate)
                .ThenInclude(invest => invest.ChuDauTu)
                .OrderByDescending(x => x.Id).Take(3).ToList();
        }

        public bool Update(Post post)
        {
            throw new NotImplementedException();
        }
    }
}