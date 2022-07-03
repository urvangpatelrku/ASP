<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Cookies_practice.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           Add&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtadd" runat="server"></asp:TextBox>
&nbsp;<br />
           Retrive: <asp:TextBox ID="txtretrive" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnadd" runat="server" OnClick="btnadd_Click" Text="Add" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnretrive" runat="server" OnClick="btnretrive_Click" Text="Retrive" />
        </div>
    </form>
</body>
</html>
