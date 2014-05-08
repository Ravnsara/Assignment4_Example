<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <p>
         <asp:Label ID="Label1" runat="server" Text="Enter First Name: "></asp:Label>
         <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox><br />

         <asp:Label ID="Label2" runat="server" Text="Enter Last Name: "></asp:Label>
         <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox><br />

         <asp:Label ID="Label3" runat="server" Text="Enter Email: "></asp:Label>
         <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br />

         <asp:Label ID="Label4" runat="server" Text="Enter Street Address: "></asp:Label>
         <asp:TextBox ID="txtStreet" runat="server"></asp:TextBox><br />

         <asp:Label ID="Label5" runat="server" Text="Enter Apartment: "></asp:Label>
         <asp:TextBox ID="txtApartment" runat="server"></asp:TextBox><br />

         <asp:Label ID="Label6" runat="server" Text="Enter City: "></asp:Label>
         <asp:TextBox ID="txtCity" runat="server"></asp:TextBox><br />

         <asp:Label ID="Label9" runat="server" Text="Enter State: "></asp:Label>
         <asp:TextBox ID="txtState" runat="server"></asp:TextBox><br />

         <asp:Label ID="Label10" runat="server" Text="Enter Zip Code: "></asp:Label>
         <asp:TextBox ID="txtZip" runat="server"></asp:TextBox><br />

         <asp:Label ID="Label11" runat="server" Text="Enter Donation Amount: "></asp:Label>
         <asp:TextBox ID="txtDonation" runat="server"></asp:TextBox><br />

         <asp:Label ID="Label7" runat="server" Text="Enter Password: "></asp:Label>
         <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br />
         
         <asp:Label ID="Label8" runat="server" Text="Confirm Password: "></asp:Label>
         <asp:TextBox ID="txtConfirm" runat="server" TextMode="Password"></asp:TextBox><br />  
         
         <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
         <asp:Label ID="lblError" runat="server" Text=""></asp:Label>                 
     </p>
    </div>
    </form>
</body>
</html>
