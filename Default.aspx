<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="QuizApp.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quiz Application</title>
</head>
<body>
    <form id="form2" runat="server">
        <div>
            <h2>Welcome to Quiz Application</h2>
            <asp:Button ID="btnCreateQuiz" runat="server" Text="Create Quiz" OnClick="btnCreateQuiz_Click" />
            <asp:Button ID="btnJoinQuiz" runat="server" Text="Join Quiz by Code" OnClick="btnJoinQuiz_Click" />
            
            <!--<h3>Created Quizzes</h3>
            <asp:GridView ID="gvCreatedQuizzes" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="QuizName" HeaderText="Quiz Name" />
                    <asp:ButtonField Text="View Statistics" CommandName="ViewStatistics" />
                </Columns>
            </asp:GridView>
            -->

            <h3>Delete Quiz</h3>
            <asp:Button ID="btnDeleteQuiz" runat="server" Text="Delete Quiz" OnClick="btnDeleteQuiz_Click" />
            
            <!--<h3>Completed Quizzes</h3>
            <asp:GridView ID="gvCompletedQuizzes" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="QuizName" HeaderText="Quiz Name" />
                    <asp:ButtonField Text="View Results" CommandName="ViewResults" />
                </Columns>
            </asp:GridView>-->
        </div>
    </form>
</body>
</html>
