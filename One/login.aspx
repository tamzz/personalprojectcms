<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Project.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="css/bootstrap.css" rel="stylesheet">
    <link href="css/login.css" rel="stylesheet">
   
    
</head>
<body>
    <form id="form1" runat="server">
        <div>
      <img class="mb-4" src="https://ialwaysbelievedinfutures.com/wp-content/uploads/2016/07/Go-Girl-Logo.png" alt="" width="72" height="72">
      <h1 class="h3 mb-3 font-weight-normal">Please sign in</h1>
     

            <asp:Label ID="Label2" runat="server" Text="User ID"></asp:Label>
      <asp:TextBox ID="Userid" runat="server"   class="form-control" placeholder="User id" required autofocus ></asp:TextBox>



     <asp:Label ID="Label3" runat="server" Text="Password"></asp:Label>
     

      <asp:TextBox ID="Password" runat="server" type="password"  class="form-control" placeholder="Password" required autofocus ></asp:TextBox>

      <div class="checkbox mb-3">
        
          <br />
          <asp:Label ID="Label1" runat="server" ></asp:Label>
        
        
      </div>
            <asp:Button ID="Button1" runat="server" class="btn btn-outline-dark" Text="Log In" OnClick="Button1_Click" />
      <p class="mt-5 mb-3 text-muted">&copy; ITT Group 2018 </p>
        </div>





        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True" >
        <asp:ListItem Text="January" Value="1"></asp:ListItem>
        <asp:ListItem Text="February" Value="2"></asp:ListItem>
        </asp:DropDownList>



        <asp:DropDownList ID="mm" runat="server"  >
        <asp:ListItem Text="Jan01" Value="Jan"></asp:ListItem>
        <asp:ListItem Text="Jan02" Value="Jan"></asp:ListItem>
        <asp:ListItem Text="Feb01" Value="Feb"></asp:ListItem>
        <asp:ListItem Text="Feb02" Value="Feb"></asp:ListItem>
        </asp:DropDownList>


        <asp:RadioButtonList ID="rblMeasurementSystem" runat="server" OnSelectedIndexChanged="rblMeasurementSystem_SelectedIndexChanged" AutoPostBack="True">
    <asp:ListItem Text="Metric" Value="metric" />
    <asp:ListItem Text="US" Value="us" />
</asp:RadioButtonList>


    </form>
</body>
</html>
