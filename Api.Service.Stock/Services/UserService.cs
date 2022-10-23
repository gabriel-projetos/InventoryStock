using Api.Service.Stock.Context;
using Api.Service.Stock.Models;
using Interfaces.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.Stock.Services
{
    //[Ioc(Interface = typeof(UserService))]
    internal class UserService
    {
        //private SharedDbContext Context { get; set; }

        //public UserService(SharedDbContext context)
        //{
        //    Context = context;
        //}
        

        //public async Task<ICourseUserRegister> Get(Guid userUid, UserRegisterOptions options)
        //{
        //    return await Query(options).FirstOrDefaultAsync(p => p.Uid == userUid);
        //}

        //public async Task<List<ICourseUserRegister>> Get(UserRegisterOptions options)
        //{
        //    return await Query(options).ToListAsync<ICourseUserRegister>();
        //}

        //public async Task<List<ICourseUserRegister>> Get()
        //{
        //    return await Query(new UserRegisterOptions()).ToListAsync<ICourseUserRegister>();
        //}


        //private IQueryable<CourseUserRegister> Query(UserRegisterOptions options)
        //{
        //    var query = Context.CourseUserRegisters.AsQueryable();
            
        //    return query;
        //}

        //public async Task<ICourseUserRegister> Update(ICourseUserRegister user)
        //{
        //    Context.Update(user);
        //    await Context.SaveChangesAsync().ConfigureAwait(false);

        //    return user;
        //}

        //public async Task<CourseUserRegister> Insert(CourseUserRegister user)
        //{
        //    Context.CourseUserRegisters.Add(user);
        //    await Context.SaveChangesAsync().ConfigureAwait(false);

        //    return user;
        //}

        //public class UserRegisterOptions
        //{
        //    public List<Guid> FilterUserUid { get; set; }
        //    public List<Guid> FilterRegisterUid { get; set; }
        //    public ContentStatus FilterAccessStatus { get; set; }
        //    public UserRegisterStatus FilterRegisterStatus { get; set; }
        //}
    }
}
