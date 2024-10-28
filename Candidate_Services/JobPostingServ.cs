using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Candidate_BO;
using Candidate_Repositories;

namespace Candidate_Services
{
    public class JobPostingServ : IJobPostingServ
    {

        private readonly IJobPostingRepo jobPostingRepo;

        public JobPostingServ() 
        {
            jobPostingRepo = new JobPostingRepo();
        
        }

        public List<JobPosting> GetJobPostings()
        {
            return jobPostingRepo.GetJobPosting();
        }



    }
}
