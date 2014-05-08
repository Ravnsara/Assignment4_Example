using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Customer
/// </summary>
public class Customer
{
    public string FirstName { set; get; }
    public string LastName { set; get; }
    public string Email { set; get; }
    public string Street { set; get; }
    public string Apartment { set; get; }
    public string City { set; get; }
    public string State { set; get; }
    public string Zip { set; get; }
    public string Donation { set; get; }
    public string PlainPassword { get; set; }
    public byte[] Password { get; set; }
    public int Passcode { get; set; }
}