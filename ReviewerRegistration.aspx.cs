using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReviewerRegistration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        SubmitReviewer();
    }

    protected void SubmitReviewer() {

        LoginServiceReference.BookReviewLoginServiceClient brs = new LoginServiceReference.BookReviewLoginServiceClient();

        LoginServiceReference.ReviewerLite rlite = new LoginServiceReference.ReviewerLite();

        rlite.LastName = LastNameTextBox.Text;
        rlite.FirstName = FirstNameTextBox.Text;
        rlite.Email = EmailTextBox.Text;
        rlite.UserName = UserNameTextBox.Text;
        rlite.Password = ConfirmTextBox.Text;

        int result = brs.ReviewerRegistration(rlite);

        if (result != -1)
        {
            ResultLabel.Text = "Registration is successful";

        }else{

            ResultLabel.Text = "Registration failed";
        }
    
    }
}