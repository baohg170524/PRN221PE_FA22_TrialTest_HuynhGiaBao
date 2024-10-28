using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Candidate_BO;
using Microsoft.EntityFrameworkCore;

namespace Candidate_DAOs
{
    public class CandidateProfileDAO 
    {
        private static CandidateManagementContext dbcontext;
        private static CandidateProfileDAO instance;

        private static GenericDAO<CandidateProfile> genericDAO;

        public CandidateProfileDAO() {
            dbcontext = new CandidateManagementContext();

            genericDAO = new GenericDAO<CandidateProfile>(dbcontext);            
        }

        public static CandidateProfileDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance= new CandidateProfileDAO();
                }
                return instance;
            }

        }
        
        public List<CandidateProfile> GetCandidates()
        {
            return genericDAO.GetAll();

        }
        public bool removeCandidate(String candidateID)
        {
            bool isSuccess = false;

            CandidateProfile candidate = searchCandidateByID(candidateID);
            if (candidate != null)
            {
                genericDAO.Delete(candidateID);
                dbcontext.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;

        }
        public bool updateCandidate(CandidateProfile candidateProfile)
        {
            bool isSuccess = false;

            CandidateProfile candidate = searchCandidateByID(candidateProfile.CandidateId);
            if (candidate != null)
            {
                

                dbcontext.Entry<CandidateProfile>(candidateProfile).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                dbcontext.SaveChanges();
                return isSuccess = true;

            }
            return isSuccess;

        }

        public CandidateProfile searchCandidateByID(string candidateID)
        {

            return dbcontext.CandidateProfiles.SingleOrDefault(candidate => candidate.CandidateId.Equals(candidateID));
        }


        public bool AddCadidateProfile(CandidateProfile candidateProfile)
        {
            bool isSuccess = false;

            CandidateProfile candidate = searchCandidateByID(candidateProfile.CandidateId);

            if (candidate == null)
            {
                dbcontext.CandidateProfiles.Add(candidateProfile);
                dbcontext.SaveChanges();
                return isSuccess = true;

            }

            return isSuccess;
        }
    }
}
