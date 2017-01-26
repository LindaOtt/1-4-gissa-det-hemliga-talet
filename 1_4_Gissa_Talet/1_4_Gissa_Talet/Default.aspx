<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_1_4_Gissa_Talet.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>1.4 Gissa det hemliga talet</title>
    <script src="Scripts/jquery-3.1.1.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Gissa det hemliga talet</h1>
        <p>Ange ett tal mellan 1 och 100:<asp:TextBox ID="TextBoxEnterGuess" runat="server"></asp:TextBox><asp:Button ID="ButtonSubmitGuess" runat="server" Text="Skicka gissning" /></p>
        <p><asp:Label ID="LabelMadeGuesses" runat="server" Text="" Font-Bold="True" ForeColor="Red"></asp:Label></p>
        <p>
            <asp:PlaceHolder ID="PlaceHolderNewRandomNumber" runat="server" Visible="False">
                <asp:Button ID="ButtonGetNewRandomNumber" runat="server" Text="Slumpa nytt hemligt tal" />
            </asp:PlaceHolder>
        </p>
        <p>
            <asp:Label ID="LabelResultOfGuess" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
        </p>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorForGuess" runat="server" ErrorMessage="<p>Ett fel inträffade. Korrigera felet och gör ett nytt försök.</p> <ul><li>Ett tal måste anges.</li></ul>" ControlToValidate="TextBoxEnterGuess" Font-Bold="False" Display="Static"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RangeValidatorGuess" runat="server" ErrorMessage="<p>Ett fel inträffade. Korrigera felet och gör ett nytt försök.</p> <ul><li>Ange ett tal mellan 1 och 100.</li></ul>" Type="Integer" MaximumValue="100" MinimumValue="1" ControlToValidate="TextBoxEnterGuess" Display="Static" Font-Bold="False"></asp:RangeValidator>
    </div>
    </form>
</body>
</html>
