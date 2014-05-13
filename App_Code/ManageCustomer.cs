using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for ManageCustomer
/// </summary>
public class ManageCustomer
{

    SqlConnection connect;

	public ManageCustomer()
	{
        connect = new SqlConnection(ConfigurationManager.ConnectionStrings["CommunityAssistConnectionString"].ConnectionString);
	}
    public void WriteCustomer(Customer c) 
    {
        string sqlPerson = "Insert into Person(PersonLastName, PersonFirstName,PersonUserName,PersonPlainPassword,Personpasskey,PersonUserPassword,PersonEntryDate) Values(@LastName, @FirstName, @UserName, @PlainPassword, @Passcode, @HashedPassword, @EntryDate)";
        string sqlPersonAddress = "Insert into PersonAddress(Street, Apartment, City, State, Zip, Personkey) " + "Values(@Street, @Apartment, @City, @State, @Zip, ident_Current('Person'))";
        string sqlDonation = "Insert into Donation(DonationAmount, DonationDate, PersonKey) " + "Values(@Donation, @DonDate, ident_Current('Person'))";

        PasscodeGenerator pg = new PasscodeGenerator();
        PasswordHash ph = new PasswordHash();
        int Passcode = pg.GetPasscode();

        SqlCommand personCmd = new SqlCommand(sqlPerson, connect);
        personCmd.Parameters.AddWithValue("@FirstName", c.FirstName);
        personCmd.Parameters.AddWithValue("@LastName", c.LastName);
        personCmd.Parameters.AddWithValue("@UserName", c.Email);
        personCmd.Parameters.AddWithValue("@PlainPassword", c.PlainPassword);
        personCmd.Parameters.AddWithValue("@Passcode", c.Passcode);
        personCmd.Parameters.AddWithValue("@HashedPassword", ph.HashIt(c.PlainPassword.ToString(), Passcode.ToString()));
        personCmd.Parameters.AddWithValue("@EntryDate", DateTime.Now);

        SqlCommand addressCmd = new SqlCommand(sqlPersonAddress, connect);
        addressCmd.Parameters.AddWithValue("@Street", c.Street);
        addressCmd.Parameters.AddWithValue("@Apartment", c.Apartment);
        addressCmd.Parameters.AddWithValue("@City", c.City);
        addressCmd.Parameters.AddWithValue("@State", c.State);
        addressCmd.Parameters.AddWithValue("@Zip", c.Zip);
     
        SqlCommand donationCmd = new SqlCommand(sqlDonation, connect);
        donationCmd.Parameters.AddWithValue("@Donation", c.Donation);
        donationCmd.Parameters.AddWithValue("@DonDate", DateTime.Now);


        connect.Open();        
        personCmd.ExecuteNonQuery();        
        addressCmd.ExecuteNonQuery();        
        donationCmd.ExecuteNonQuery();        
        connect.Close();
    }
}