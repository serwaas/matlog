<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="table.aspx.cs" Inherits="matlog.WebForm1" StyleSheetTheme="" %>
<link href="../CSS/MainStyle.css" rel="stylesheet" />

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #content {
            width: 1080px;
        }
    </style>
    <link href="WebForm1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div id ="main">
        
            <div id="logo"></div>
        <div id ="head">
            
         <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="margin-left: 91px; width:200px; color:#1a419f;	/*font-family:'';*/ font-size:16px; 
                                                                                 background-color:#cccccc; padding:3px;  margin:2px;border:1px solid #666666; margin-bottom: 16px" 
              Text="Сгенерировать функцию" Font-Names="Comic Sans MS" Font-Size="Medium" />
        <a href="index.html"><div class ="but">Меню</div></a>
             <br />
        <br />
        <br />
        <asp:TextBox ID="TextBox1" runat="server" Height="28px" ReadOnly="True" style="margin-left: 89px" Visible="False" Width="234px" Font-Names="Schadow BT" Font-Size="Larger">0</asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Введите ответ:" Visible="False" Font-Names="Schadow BT" Font-Size="Larger"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox2" runat="server" style="margin-left: 88px; margin-top: 17px; margin-bottom: 1px;" Visible="False" Width="233px" Font-Names="Schadow BT" Font-Size="Larger" OnTextChanged="TextBox2_TextChanged">00000000</asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" style="margin-left: 20px;  color:#1a419f;	/*font-family:'';*/ font-size:16px; 
                                                                                 background-color:#cccccc; padding:3px;  margin:2px;border:1px solid #666666; margin-bottom: 16px" 
             Text="OK" Visible="False" Height="35px" Width="35px" />
&nbsp;&nbsp;<asp:Panel ID="Panel1" runat="server" Height="6px" style="margin-left: 90px" Width="8px">
                <asp:Panel ID="Panel2" runat="server" Height="6px" style="margin-left: 9px" Width="8px">
                    <asp:Panel ID="Panel3" runat="server" Height="6px" style="margin-left: 9px" Width="8px">
                        <asp:Panel ID="Panel4" runat="server" Height="6px" style="margin-left: 9px" Width="8px">
                            <asp:Panel ID="Panel5" runat="server" Height="6px" style="margin-left: 9px" Width="8px">
                                <asp:Panel ID="Panel6" runat="server" Height="6px" style="margin-left: 9px; " Width="8px">
                                    <asp:Panel ID="Panel7" runat="server" Height="6px" style="margin-left: 9px" Width="8px">
                                        <asp:Panel ID="Panel8" runat="server" Height="6px" style="margin-left: 9px" Width="8px">
                                        </asp:Panel>
                                    </asp:Panel>
                                </asp:Panel>
                            </asp:Panel>
                        </asp:Panel>
                    </asp:Panel>
                </asp:Panel>
            </asp:Panel>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
            
            </div>
       <div class="verticalaccordion">
<ul>
    <li><h3>Настройки</h3>
        <div>Количество переменных<br />
            <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                
                <asp:ListItem Value="2" Selected="True">Две</asp:ListItem>
                <asp:ListItem Value="3">Три</asp:ListItem>
            </asp:RadioButtonList>
            <br />
            Количество Операций<br />
            <asp:RadioButtonList ID="RadioButtonList2" runat="server">
                <asp:ListItem Value="1" Selected="True">Одна</asp:ListItem>
                <asp:ListItem Value="2">Две</asp:ListItem>
                <asp:ListItem Value="3">Три</asp:ListItem>
            </asp:RadioButtonList>
            </div>
    </li>
    
</ul>
</div>
            </div>

    </div>
    </form>
</body>
</html>
