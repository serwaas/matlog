<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SDNF.aspx.cs" Inherits="matlog.SDNF" %>
<link href="../CSS/MainStyle.css" rel="stylesheet" />
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-TYpe" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div id ="main">
        
            <div id="logo"></div>
        <div id ="head">
            
             <br />
            
         <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="margin-left: 91px; width:200px; color:#1a419f;	/*font-familY:'';*/ font-size:16px; 
                                                                                 background-color:#cccccc; padding:3px;  margin:2px;border:1px solid #666666; margin-bottom: 16px" 
                     Text="Сгенерировать функцию" Font-Names="Comic Sans MS" Font-Size="Medium" />
        <a href="index.html"><div class ="but">Меню</div></a>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server" Height="28px" style="margin-left: 89px" Visible="False" Width="234px" Font-Names="Schadow BT" Font-Size="Larger">0</asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Введите ответ:" Visible="False" Font-Names="Schadow BT" Font-Size="Larger"></asp:Label>
        <br />
&nbsp;&nbsp;<asp:TextBox ID="TextBox2" runat="server" style="margin-left: 88px; margin-top: 17px; margin-bottom: 1px;" Visible="False" Width="402px" Font-Names="Schadow BT" Font-Size="Larger" OnTextChanged="TextBox2_TextChanged">(x v y v z v t)(!x v !y)</asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;<asp:Button ID="Button2" runat="server" OnClick="Button2_Click" style="margin-left: 20px;  color:#1a419f;	/*font-familY:'';*/ font-size:16px; 
                                                                                 background-color:#cccccc; padding:3px;  margin:2px;border:1px solid #666666; margin-bottom: 16px" 
                  Text="OK" Visible="False" Height="35px" Width="35px" />
            &nbsp;<%--<asp:Panel ID="Panel1" runat="server" Height="6px" style="margin-left: 90px" Width="8px">
                <asp:Panel ID="Panel2" runat="server" Height="6px" style="margin-left: 8px" Width="8px">
                    <asp:Panel ID="Panel3" runat="server" Height="6px" style="margin-left: 8px" Width="8px">
                        <asp:Panel ID="Panel4" runat="server" Height="6px" style="margin-left: 8px" Width="8px">
                            <asp:Panel ID="Panel5" runat="server" Height="6px" style="margin-left: 8px" Width="8px">
                                <asp:Panel ID="Panel6" runat="server" Height="6px" style="margin-left: 8px; " Width="8px">
                                    <asp:Panel ID="Panel7" runat="server" Height="6px" style="margin-left: 8px" Width="8px">
                                        <asp:Panel ID="Panel8" runat="server" Height="6px" style="margin-left: 8px" Width="16px">
                                            <asp:Panel ID="Panel9" runat="server" Height="6px" style="margin-left: 8px" Width="16px">
                                                <asp:Panel ID="Panel10" runat="server" Height="6px" style="margin-left: 8px" Width="16px">
                                                    
                                                </asp:Panel>
                                            </asp:Panel>
                                        </asp:Panel>
                                    </asp:Panel>
                                </asp:Panel>
                            </asp:Panel>
                        </asp:Panel>
                    </asp:Panel>
                </asp:Panel>
            </asp:Panel>--%>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
            
            
    
            
            </div>
                    <div class="verticalaccordion">
<ul>
    <li><h3>Настройки</h3>
        <div>
            Количество переменных<br />
            <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                
                <asp:ListItem Value="3" >Три</asp:ListItem>
                <asp:ListItem Value="4" Selected="True">Четыре</asp:ListItem>
            </asp:RadioButtonList>
            <br />
            
            
        </div>
    </li>
    
</ul>
</div>

</div>
            

    </div>
    </form>
</body>
</html>
