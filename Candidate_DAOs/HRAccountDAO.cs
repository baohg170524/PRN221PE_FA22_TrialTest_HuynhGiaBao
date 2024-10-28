using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Candidate_BO;

namespace Candidate_DAOs
{
    public class HRAccountDAO
    {
        private CandidateManagementContext context;

        private static HRAccountDAO instance = null;
        // static được gọi là biến tĩnh, không đổi trong khi run

        public HRAccountDAO()
        {
            context = new CandidateManagementContext();
        }

        public static HRAccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HRAccountDAO();
                }
                return instance;
            }
        }

        public Hraccount GetHraccountByEmail(String email)
        {
            return context.Hraccounts.SingleOrDefault(m => m.Email.Equals(email));
            //lấy 1 dòng nếu có còn không thì trả ra mặc định null
            //lấy 1 đối tượng làm như trên 
        }
        public List<Hraccount> GetHraccount() 
        {
            return context.Hraccounts.ToList();
            // hàm lấy 1 danh sách (lấy tất cả)
        }
    }
}
