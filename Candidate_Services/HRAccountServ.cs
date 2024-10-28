using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Candidate_BO;
using Candidate_Repositories;

namespace Candidate_Services
{
    public class HRAccountServ : IHRAccountServ
    {
        private IHRAccountRepo iAccountRepo;
        public HRAccountServ() { 
            iAccountRepo = new HRAccountRepo();
        }
        public List<Hraccount> GetHraccount()
        {
            return iAccountRepo.GetHraccount();
        }

        public Hraccount GetHraccountByEmail(string email)
        {
            return iAccountRepo.GetHraccountByEmail(email);
        }
    }
}
