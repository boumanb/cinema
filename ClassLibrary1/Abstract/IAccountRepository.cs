using BioscoopB3Web.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioscoopB3Web.Domain.Abstract
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAllCustomers();
        bool AddCustomer(Account Customer);
        Account GetCustomer(String Email);
        IEnumerable<Account> GetAllNewsLetterAccounts();
    }
}
