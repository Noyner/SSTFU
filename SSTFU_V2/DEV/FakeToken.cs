using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SSTFU_V2.Models;
namespace SSTFU_V2.DEV
{
    public class FakeAuthService
    {
        public const string FAKE_USER_TOKEN= "0x00000";

        public async Task<EUser> EnsureFakeUser(EFDBContext context)
        {
            EUser user = await context.Users.FirstOrDefaultAsync(u=>u.Token==FAKE_USER_TOKEN);
            if(user==null)
            {
                user = MakeFakeUser();
                context.Users.Add(user);
               await context.SaveChangesAsync();
            }
            return user;
        }
        public EUser MakeFakeUser()
        {
            var user = new EUser()
            {
                Token=FAKE_USER_TOKEN,
                fName="Имя",
                lName="Фамилия",
                fatherName="Отчество",
                Email="bob@bobmail.com",
                PhoneNumber="+79990003311",
                banFlag=false
            };
            return user;

        }
    }
}
