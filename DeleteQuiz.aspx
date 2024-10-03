<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteQuiz.aspx.cs" Inherits="QuizApp.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>Delete Quiz</h3>
            <asp:Label ID="lblQuizId" runat="server" Text="Enter Quiz ID:"></asp:Label>
            <asp:TextBox ID="txtQuizId" runat="server"></asp:TextBox>
            <br /><br />
            <asp:Button ID="btnSubmitDelete" runat="server" Text="Submit" OnClick="btnSubmitDelete_Click" />
            <br />
            <asp:Label ID="lbl2QuizId" runat="server" Text="Enter Quiz ID:"></asp:Label>

        </div>
    </form>
</body>
</html>
