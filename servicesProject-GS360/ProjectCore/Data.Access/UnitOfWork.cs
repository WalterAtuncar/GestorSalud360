using Data.Access.Login;
using Repositories.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit.Of.Work;

namespace Data.Access
{
    public class UnitOfWork : IUnitOfWork
    {
        public ILoginRepository ILogin { get; }


        public UnitOfWork(string connectionString)
        {
            ILogin = new LoginRepository(connectionString);
        }        
    }
}
