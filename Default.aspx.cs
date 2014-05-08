using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Customer c = new Customer();
        c.FirstName = txtFirstName.Text;
        c.LastName = txtLastName.Text;
        c.Email = txtEmail.Text;
        c.Street = txtStreet.Text;
        c.Apartment = txtApartment.Text;
        c.City = txtCity.Text;
        c.State = txtState.Text;
        c.Zip = txtZip.Text;
        c.Donation = txtDonation.Text;
        c.PlainPassword = txtPassword.Text;

        ManageCustomer mc = new ManageCustomer();
       
        {
            mc.WriteCustomer(c);
            lblError.Text = "Thanks for registering.";
        }
        
         

    }
}