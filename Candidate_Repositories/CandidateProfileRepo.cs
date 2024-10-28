using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Candidate_BO;
using Candidate_DAOs;

namespace Candidate_Repositories
{
    public class CandidateProfileRepo : ICandidateProfileRepo 
    {
        public bool AddCadidateProfile(CandidateProfile candidateProfile) => CandidateProfileDAO.Instance.AddCadidateProfile(candidateProfile);
        

        public List<CandidateProfile> GetCandidates() => CandidateProfileDAO.Instance.GetCandidates();
        

        public bool removeCandidate(string candidateID) =>CandidateProfileDAO.Instance.removeCandidate(candidateID);
        

        public CandidateProfile searchCandidateByID(string candidateID) => CandidateProfileDAO.Instance.searchCandidateByID(candidateID);
        

        public bool updateCandidate(CandidateProfile candidateProfile) =>CandidateProfileDAO.Instance.updateCandidate(candidateProfile);
        
    }
}
