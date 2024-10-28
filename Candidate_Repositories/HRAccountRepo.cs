using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Candidate_BO;
using Candidate_DAOs;

namespace Candidate_Repositories
{
    public class HRAccountRepo : IHRAccountRepo
    {
        public List<Hraccount> GetHraccount()=>HRAccountDAO.Instance.GetHraccount();
       

        public Hraccount GetHraccountByEmail(string email)=>HRAccountDAO.Instance.GetHraccountByEmail(email);
        
    }
}
