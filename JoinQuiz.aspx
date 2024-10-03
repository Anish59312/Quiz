<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JoinQuiz.aspx.cs" Inherits="QuizApp.JoinQuiz" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Join Quiz</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Join Quiz</h2>
            <asp:TextBox ID="txtQuizCode" runat="server" placeholder="Enter Quiz Code"></asp:TextBox>
            <asp:Button ID="btnJoinQuiz" runat="server" Text="Join Quiz" OnClick="btnJoinQuiz_Click" />
        </div>
    </form>
</body>
</html>
