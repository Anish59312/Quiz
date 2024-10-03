<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuizStatistics.aspx.cs" Inherits="QuizApp.QuizStatistics" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quiz Statistics</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Quiz Statistics</h2>
            <asp:Label ID="lblQuizName" runat="server" Text="Quiz Name"></asp:Label>
            <br />
            <asp:Label ID="lblTotalParticipants" runat="server" Text="Total Participants"></asp:Label>
            <br />
            <asp:Label ID="lblAverageMarks" runat="server" Text="Average Marks"></asp:Label>
            <br />
            <h3>Participant Results</h3>
            <asp:GridView ID="gvParticipants" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="ParticipantName" HeaderText="Participant Name" />
                    <asp:BoundField DataField="Score" HeaderText="Score" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
