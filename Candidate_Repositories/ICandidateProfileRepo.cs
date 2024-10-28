using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Candidate_BO;
using Microsoft.EntityFrameworkCore;

namespace Candidate_Repositories
{
    public interface ICandidateProfileRepo
    {
        public List<CandidateProfile> GetCandidates();

        public bool removeCandidate(String candidateID);

        public bool updateCandidate(CandidateProfile candidateProfile);


        public CandidateProfile searchCandidateByID(String candidateID);



        public bool AddCadidateProfile(CandidateProfile candidateProfile);

    }
}
