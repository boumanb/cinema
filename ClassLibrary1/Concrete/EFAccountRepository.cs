using BioscoopB3Web.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioscoopB3Web.Domain.Entities;
using BioscoopB3Web.Domain.Concrete;

namespace BioscoopB3Web.Domain.Concrete
{
    public class EFAccountRepository : IAccountRepository
    {
        private BioscoopModel BioscoopModel;

        public EFAccountRepository(BioscoopModel BioscoopModel)
        {
            this.BioscoopModel = BioscoopModel;
        }

        public bool AddCustomer(Account customer)
        {
            Account result = BioscoopModel.Accounts.Find(customer.Email);

            if (result == null)
            {
                BioscoopModel.Accounts.Add(customer);
                BioscoopModel.SaveChanges();

                return true;
            } else if (customer.City != result.City || customer.Name != result.Name || customer.LastName != result.LastName || customer.Street != result.Street || customer.StreetNumber != result.StreetNumber)
            {
                BioscoopModel.Accounts.Remove(result);
                BioscoopModel.Accounts.Add(customer);
                BioscoopModel.SaveChanges();

                return true;
            }
            else if (result.WantsNewsletter == customer.WantsNewsletter && result.Email == customer.Email)
            {
                return false;
            }
            else
            {
                BioscoopModel.Accounts.Remove(result);
                BioscoopModel.Accounts.Add(customer);
                BioscoopModel.SaveChanges();

                return true;
            }
        }

        public IEnumerable<Account> GetAllCustomers()
        {
            return BioscoopModel.Accounts;
        }

        public IEnumerable<Account> GetAllNewsLetterAccounts()
        {
            return BioscoopModel.Accounts.Where(a => a.WantsNewsletter == true).ToList();
        }

        public Account GetCustomer(string Email)
        {
            return BioscoopModel.Accounts.Find(Email);
        }
    }
}
