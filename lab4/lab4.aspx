<%@ Page Language="C#" AutoEventWireup="true" CodeFile="lab4.aspx.cs" Inherits="lab4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Rezultatų sąrašas: "></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Table ID="Table4" runat="server">
            </asp:Table>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <asp:Table ID="Table1" runat="server" GridLines="Both" Width="1px">
            </asp:Table>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Knygų atrinkimo kriterijų failas: "></asp:Label>
            <br />
            <br />
            <asp:FileUpload ID="FileUpload1" runat="server" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Įveskite, kurių metų knygas pašalinti"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Atrinkti" OnClick="Button1_Click" />
            <br />
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="<b> Pradiniai duomenys: </b>"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="Atrinkimo failo duomenys :"></asp:Label>
            <br />
            <br />
            <asp:Table ID="Table2" runat="server" GridLines="Both">
            </asp:Table>
            <br />
            <asp:Label ID="Label6" runat="server" Text="Knygų asortimento duomenys: "></asp:Label>
            <br />
            <asp:Table ID="Table3" runat="server" GridLines="Both">
            </asp:Table>
        </div>
    </form>
</body>
</html>
<head>
<style>
#Table3 {
    font-family: "Trebuchet MS", Arial, Helvetica, sans-serif;
    border-collapse: collapse;
    width: 100%;
}

#Table3 td, #customers th {
    border: 1px solid #ddd;
    padding: 8px;
}

#Table3 tr:nth-child(even){background-color: #f2f2f2;}

#Table3 tr:hover {background-color: #ddd;}

#Table3 th {
    padding-top: 12px;
    padding-bottom: 12px;
    text-align: left;
    background-color: #4CAF50;
    color: white;
}
</style>
</head>
