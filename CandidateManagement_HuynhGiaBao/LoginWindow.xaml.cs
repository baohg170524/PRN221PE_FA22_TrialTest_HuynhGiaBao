using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Candidate_BO;
using Candidate_Services;

namespace CandidateManagement_HuynhGiaBao
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private IHRAccountServ iHRAccountServ;
        public LoginWindow()
        {
            InitializeComponent();
            iHRAccountServ = new HRAccountServ();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void btnCancle_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnl_login_Click(object sender, RoutedEventArgs e)
        {
            Hraccount hraccount = iHRAccountServ.GetHraccountByEmail(txtEmail.Text.Trim());
            if (hraccount != null && hraccount.Password.Equals(txtPass.Password) )
            {
                int? roleID = hraccount.MemberRole;
                switch (roleID)
                {
                    case 1: 
                        this.Hide();
                        CandidateProfileWindow candidateForm = new CandidateProfileWindow(roleID);
                        candidateForm.Show();
                        break;
                    case 2:
                        this.Hide();
                        CandidateProfileWindow staffCandidate = new CandidateProfileWindow(roleID);
                        staffCandidate.Show();
                        break;
                    case 3: btnCancle.IsEnabled = false;
                        break;

                }
               
            }
            else
            {
                MessageBox.Show("Sorry you");
            }
        }

        private void txtPass_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}