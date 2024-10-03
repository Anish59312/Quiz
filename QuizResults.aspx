<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuizResults.aspx.cs" Inherits="QuizApp.QuizResults" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quiz Results</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Your Results</h1>
            <asp:Label ID="lblScore" runat="server" Text="Your Score"></asp:Label>
            <br />
            <h2>In Percentage</h2>
            <asp:Label ID="lblPercentage" runat="server" Text="Percentage "></asp:Label>
            <br />
            <br />
            <h2 style="font-family:'Gill Sans'">
            <asp:Label ID="lblisPassed" runat="server" Text=""></asp:Label>
            <br /></h2>

            <!--<h3>Correct Answers:</h3>-->
            <asp:Repeater ID="rptCorrectAnswers" runat="server">
                <ItemTemplate>
                    <div>
                        <%# Eval("QuestionText") %>: <%# Eval("CorrectAnswer") %>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
