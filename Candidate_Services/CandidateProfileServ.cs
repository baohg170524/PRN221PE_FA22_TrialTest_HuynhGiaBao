using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Candidate_BO;
using Candidate_DAOs;
using Candidate_Repositories;

namespace Candidate_Services
{
    public class CandidateProfileServ : ICandidateProfileServ
    {

        private readonly ICandidateProfileRepo profilerepo;

        public CandidateProfileServ()
        {
            profilerepo = new CandidateProfileRepo();
        }

        public bool AddCadidateProfile(CandidateProfile candidateProfile)
        {
            return profilerepo.AddCadidateProfile(candidateProfile);
        }


        public List<CandidateProfile> GetCandidates()
        {
            return profilerepo.GetCandidates();
        }


        public bool removeCandidate(string candidateID)
        {
            return profilerepo.removeCandidate(candidateID);
        }


        public CandidateProfile searchCandidateByID(string candidateID)
        {
            return profilerepo.searchCandidateByID(candidateID);
        }


        public bool updateCandidate(CandidateProfile candidateProfile)
        {
            return profilerepo.updateCandidate(candidateProfile);
        }


    }
}
