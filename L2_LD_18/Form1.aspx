<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form1.aspx.cs" Inherits="L2_LD_18.Form1" UnobtrusiveValidationMode="None" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Taxi Management</title>
    <link rel="stylesheet" type="text/css" href="styles.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Label ID="Label1" runat="server" Text="Minimalus automobilio amžius:"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

            <br />

            <asp:RequiredFieldValidator 
                ID="RequiredFieldValidator1"
                runat="server"
                ControlToValidate="TextBox1"
                ErrorMessage="Įveskite minimalų amžių"
                Display="Dynamic"
                CssClass="validation-error" />

            <br />

            <asp:CompareValidator
                ID="CompareValidator1"
                runat="server"
                ControlToValidate="TextBox1"
                Operator="DataTypeCheck"
                Type="Integer"
                ErrorMessage="Minimalus amžius turi būti skaičius"
                Display="Dynamic"
                CssClass="validation-error" />


            <br />


            <asp:RangeValidator
                ID="RangeValidator1"
                runat="server"
                ControlToValidate="TextBox1"
                MinimumValue="0"
                MaximumValue="1000"
                Type="Integer"
                ErrorMessage="Minimalus amžius negali būti neigiamas"
                Display="Dynamic"
                CssClass="validation-error" />

            <br /><br />

            <asp:Label ID="Label2" runat="server" Text="Maksimalus automobilio amžius:"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>

            <br />

            <asp:RequiredFieldValidator 
                ID="RequiredFieldValidator2"
                runat="server"
                ControlToValidate="TextBox2"
                ErrorMessage="Įveskite maksimalų amžių"
                Display="Dynamic"
                CssClass="validation-error" />

            <br />

            <asp:CompareValidator
                ID="CompareValidator2"
                runat="server"
                ControlToValidate="TextBox2"
                Operator="DataTypeCheck"
                Type="Integer"
                ErrorMessage="Maksimalus amžius turi būti skaičius"
                Display="Dynamic"
                CssClass="validation-error" />

            <br />

            <asp:RangeValidator
                ID="RangeValidator2"
                runat="server"
                ControlToValidate="TextBox2"
                MinimumValue="0"
                MaximumValue="1000"
                Type="Integer"
                ErrorMessage="Maksimalus amžius negali būti neigiamas"
                Display="Dynamic"
                CssClass="validation-error" />

            <br />

            <asp:CustomValidator
                ID="CustomValidator1"
                runat="server"
                ControlToValidate="TextBox2"
                ErrorMessage="Minimalus amžius negali būti didesnis už maksimalų"
                Display="Dynamic"
                CssClass="validation-error"
                OnServerValidate="CustomValidator1_ServerValidate" />

            <br /><br />

            <asp:Button ID="Button1" runat="server" Text="Rodyti sąrašus" OnClick="Button1_Click" />

            <br /><br />

            <asp:Table ID="Table1" runat="server" CssClass="taxiTable"></asp:Table>
            <br />

            <asp:Table ID="Table2" runat="server" CssClass="taxiTable"></asp:Table>
            <br />

            <asp:Table ID="Table3" runat="server" CssClass="taxiTable"></asp:Table>

            <br />
            <br />
            <asp:Label ID="Label3" runat="server"></asp:Label>

        </div>
    </form>
</body>
</html>