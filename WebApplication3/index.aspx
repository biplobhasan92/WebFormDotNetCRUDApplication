<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebApplication3.index" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
        <style type="text/css">
            .auto-style8 {
                width: 100%;
            }
            .auto-style9 {
                width: 167px;
            }
            .auto-style10 {
                width: 462px;
            }
            .auto-style11 {
                color: #CC3300;
            }
            .auto-style12 {
                width: 237px;
            }
            </style>
    </head>
    <body>
        <form id="form1" runat="server">
            <div align="center">
                <h1>Employee Information System</h1>
            </div>
            <br/>

            <table class="auto-style8">
                <tr>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style10">
                        <asp:TextBox ID="txtRecordID" runat="server" Visible="False"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style9">Employee ID</td>
                    <td class="auto-style10">
                        <asp:TextBox ID="txtEmp_id" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style9">Employee Name</td>
                    <td class="auto-style10">
                        <asp:TextBox ID="txtEmp_name" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style9">Employee Department</td>
                    <td class="auto-style10">
                        <asp:DropDownList ID="DropDownDept" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style9">Employee Gender</td>
                    <td class="auto-style10">
                        <asp:RadioButtonList ID="rdoGender" runat="server">
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style10">
                        <asp:Label ID="lblMessage" runat="server" CssClass="auto-style11"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style10">
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click1" Text="Save" />
                        <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click1" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" OnClientClick="return confirm('Do you want to Delete ?')" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style10">
                        
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style12">&nbsp;</td>
                    <td colspan="2">
                        <asp:GridView ID="GridView1" runat="server" Width="626px" OnRowDataBound="GridView1_RowDataBound">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Select</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>

        </form>
    </body>
</html>
