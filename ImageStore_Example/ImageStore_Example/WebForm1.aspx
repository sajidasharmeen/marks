<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ImageStore_Example.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Select any image"></asp:Label>
    <asp:FileUpload ID="FileUpload1" runat="server" />
        <br /><br />
        <asp:Button ID="Button1" runat="server" Text="save image" OnClick="Button1_Click" />
        <br />
        <br />
       <h2 style="color: #FF0000">show image</h2>
        <br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button2" runat="server" Text="show"  OnClick="Button2_Click"/>
        <br />
        <br />
        <asp:Image ID="Image1" runat="server" Width="200" Height="200" />
        <br />
    </div>
        
    </form>
</body>
</html>
