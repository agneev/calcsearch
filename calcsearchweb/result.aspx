<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="result.aspx.cs" Inherits="calcsearchweb.result" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<style>
    table {
    
    display:inline-block;
    border:1px;
}
table, th, td {
    border: 1px solid black;
    
}
table#t02 td {
    padding: 8px;
    text-align: left;
}
table#t03 td{
    padding: 7px;
    text-align: left;
}
table#t02 tr:nth-child(even) {
    background-color: #eee;
}
table#t02 tr:nth-child(odd) {
   background-color:#fff;
}
table#t02 th {
    background-color: black;
    color: white;
}
table#t03 tr:nth-child(even) {
    background-color: #eee;
}

table#t03 tr:nth-child(odd) {
   background-color:#fff;
}
table#t03 th {
    background-color: black;
    color: white;
}

    </style>
</head>

<body>
    <form id="form1" runat="server">
    
        <asp:Panel id="res" runat="server">
        <h2 style="text-align:left;color:cadetblue">Search Results:</h2>
            
    </asp:Panel>
        <asp:Panel id="Panel1" runat="server">
        <h2 id="tracehead"style="text-align:left;color:cadetblue">Calculation Trace :</h2>
            
    </asp:Panel>
    <asp:Panel id="calctracefinal" runat="server">
        
            
    </asp:Panel>
    </form>
</body>
</html>
