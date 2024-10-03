<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="~/CreateQuiz.aspx.cs" Inherits="QuizApp.CreateQuiz" EnableEventValidation="false" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create Quiz</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Create Quiz</h2>

            <asp:TextBox ID="txtQuestion" runat="server" placeholder="Enter question" ValidationGroup="questioninput"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtOption1" runat="server" placeholder="Option 1" ValidationGroup="questioninput"></asp:TextBox>
            <asp:TextBox ID="txtOption2" runat="server" placeholder="Option 2" ValidationGroup="questioninput"></asp:TextBox>
            <asp:TextBox ID="txtOption3" runat="server" placeholder="Option 3" ValidationGroup="questioninput"></asp:TextBox>
            <asp:TextBox ID="txtOption4" runat="server" placeholder="Option 4" ValidationGroup="questioninput"></asp:TextBox>
            <asp:DropDownList ID="ddlCorrectAnswer" runat="server" ValidationGroup="questioninput">
                <asp:ListItem Value="Option1">Option 1</asp:ListItem>
                <asp:ListItem Value="Option2">Option 2</asp:ListItem>
                <asp:ListItem Value="Option3">Option 3</asp:ListItem>
                <asp:ListItem Value="Option4">Option 4</asp:ListItem>
            </asp:DropDownList>

            <asp:Button ID="btnAddQuestion" runat="server" Text="Add Question" OnClick="btnAddQuestion_Click" ValidationGroup="questioninput" CausesValidation="False" />
            <br /><br />
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Option 1 is required" ForeColor="Red" ControlToValidate="txtOption1" ValidationGroup="questioninput"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Option 2 is required" ForeColor="Red" ControlToValidate="txtOption2" ValidationGroup="questioninput"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Option 3 required" ControlToValidate="txtOption3" ForeColor="Red" ValidationGroup="questioninput"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Option 4 is required" ControlToValidate="txtOption4" ForeColor="Red" ValidationGroup="questioninput"></asp:RequiredFieldValidator>
            <br /><br />
            <asp:TextBox runat="server" ID="ctlQuizName" ValidationGroup="questioninput" placeholder="Enter Quiz Name" ></asp:TextBox>
            <asp:Button ID="btnSubmitQuiz" runat="server" Text="Submit Quiz" OnClick="btnSubmitQuiz_Click" CausesValidation="False" />
        </div>
        <div style="margin-top:1rem">
            <asp:GridView ID="ctlGrid" runat="server" AutoGenerateColumns="False" OnRowCommand="ctlGrid_RowCommand">
            <Columns>
                <asp:BoundField DataField="QuestionText" HeaderText="Question" />
                <asp:BoundField DataField="Option1" HeaderText="Option 1" />
                <asp:BoundField DataField="Option2" HeaderText="Option 2" />
                <asp:BoundField DataField="Option3" HeaderText="Option 3" />
                <asp:BoundField DataField="Option4" HeaderText="Option 4" />
                <asp:BoundField DataField="CorrectAnswer" HeaderText="Correct Answer" />

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnDelete" runat="server" CommandName="DeleteRow" CommandArgument="<%# Container.DataItemIndex %>" Text="Delete" CausesValidation="False" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        </div>
    </form>
</body>
</html>
