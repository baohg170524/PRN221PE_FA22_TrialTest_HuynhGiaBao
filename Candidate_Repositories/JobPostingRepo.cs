using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Candidate_BO;
using Candidate_DAOs;

namespace Candidate_Repositories
{
    public class JobPostingRepo : IJobPostingRepo
    {
        public List<JobPosting> GetJobPosting() => JobPostingDAO.Instance.GetJobPostings(); 


    }
}
