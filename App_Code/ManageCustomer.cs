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
		connect = new SqlConnection(ConfigurationManager.ConnectionStrings["AutomartConnectionString"].ConnectionString);
	}
    public void WriteCustomer(Customer c) 
    {
        string sqlPerson = "Insert into Person(LastName, FirstName) Values(@LastName, @FirstName)";
        string sqlVehicle = "Insert into Customer.Vehicle(LicenseNumber, VehicleMake, VehicleYear, Personkey) " + "Values(@LicenseNumber, @VehicleMake, @VehicleYear, identCurrent('Person'))";
        string sqlRegisteredCustomer = "Insert into customer.RegisteredCustomer(Email, Passcode, Password, CustomerHashedPassword, PersonKey) " + "Values(@Email, @Passcode, @Password, @CustomerHashedPassword, identCurrent('Person'))";

        SqlCommand personCmd = new SqlCommand(sqlPerson, connect);
        personCmd.Parameters.AddWithValue("@LastName", c.LastName);
        personCmd.Parameters.AddWithValue("@FirstName", c.FirstName);

        SqlCommand vehicleCmd = new SqlCommand(sqlVehicle, connect);
        vehicleCmd.Parameters.AddWithValue("@LicenseNumber", c.LicenseNumber);
        vehicleCmd.Parameters.AddWithValue("@VehicleMake", c.VehicleMake);
        vehicleCmd.Parameters.AddWithValue("@VehicleYear", c.VehicleYear);

        PasscodeGenerator pg = new PasscodeGenerator();
        PasswordHash ph = new PasswordHash();
        int Passcode = pg.GetPasscode();

        SqlCommand regCustomerCmd = new SqlCommand(sqlRegisteredCustomer, connect);
        regCustomerCmd.Parameters.AddWithValue("@Email", c.Email);
        regCustomerCmd.Parameters.AddWithValue("@Passcode", Passcode);
        regCustomerCmd.Parameters.AddWithValue("@CustomerPassword", c.Password);
        regCustomerCmd.Parameters.AddWithValue("@CustomerHashedPassword", ph.HashIt(c.Password.ToString(), Passcode.ToString()));

        connect.Open();
        personCmd.ExecuteNonQuery();
        vehicleCmd.ExecuteNonQuery();
        regCustomerCmd.ExecuteNonQuery();
        connect.Close();
    }
}