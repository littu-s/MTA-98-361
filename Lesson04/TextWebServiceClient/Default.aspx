<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TextWebServiceClient.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Test Form for TextWebService</h2>
            <p>
                <asp:TextBox ID="TextBox1" runat="server" Text="Enter text" />
                <br />
                <asp:Button ID="Button1" runat="server" Text="Invoke WebService Methods" OnClick="Button1_Click" />
            </p>
            <p>
                <strong>Results:</strong> <br />
                ToLower Method:
                <asp:Label ID="toLowerLabel" runat="server" Text="Label" ForeColor="Green" /> <br />
                ToUpper Method:
                <asp:Label ID="toUpperLabel" runat="server" Text="Label" ForeColor="Green" /> <br />
            </p>
        </div>
    </form>
</body>
</html>
