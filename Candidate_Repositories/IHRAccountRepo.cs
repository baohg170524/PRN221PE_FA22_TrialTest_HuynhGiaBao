using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Candidate_BO;

namespace Candidate_Repositories
{
    public interface IHRAccountRepo
    {
        public Hraccount GetHraccountByEmail(String email);

        public List<Hraccount> GetHraccount();
    }
}
