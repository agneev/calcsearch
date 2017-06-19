<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Landing.aspx.cs" Inherits="calcsearchweb.Landing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
table {
    width:100%;
}
table, th, td {
    border: 1px solid black;
    border-collapse: collapse;
}
th, td {
    padding: 8px;
    text-align: left;
}
table#t01 tr:nth-child(even) {
    background-color: #eee;
}
table#t01 tr:nth-child(odd) {
   background-color:#fff;
}
table#t01 th {
    background-color: black;
    color: white;
}
</style>
</head>
<body style="background-color:darkslategray">
    <form id="form1" runat="server">
    <div>
        <h1 style="text-align:center;color:cornsilk"> Welcome to Calc Search !</h1>    
    </div>
    
    <asp:Panel id="querylist" runat="server">
        <h2 style="text-align:left;color:cornsilk"> Search by Query:</h2>
            
    </asp:Panel>
    
        <p>
            &nbsp;</p>
    
        
    <asp:Table ID="t01" runat="server" Width="100%"> 
    <asp:TableRow>
        <asp:TableCell>Query</asp:TableCell>
        <asp:TableCell>Enter Value</asp:TableCell>
        
    </asp:TableRow>
</asp:Table>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Run" />
        </p>
    </form>
</body>
</html>
