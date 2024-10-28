using Candidate_Services;
using Microsoft.AspNetCore.Mvc;

namespace CandidateManagementAPI.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class CandidateController : Controller
    {
        private ICandidateProfileServ profileServ;
        
        public CandidateController() 
        {
            profileServ = new CandidateProfileServ();
        }

        [HttpGet(Name = "GetCandidtes")]




        public IActionResult GetAllCandidate()
        {
            return Ok(profileServ.GetCandidates().ToList());
        }
    }
}
