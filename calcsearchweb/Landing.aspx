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
        <asp:ScriptManager runat="server" ID="sm">
 </asp:ScriptManager>
        <asp:updatepanel runat="server">
 <ContentTemplate>
 <asp:button id="button1" runat="server" Text="Run" onclick="Button1_Click" />
 </ContentTemplate>
 </asp:updatepanel>
        <asp:Panel ID="but" runat="server">
            </asp:Panel>
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
