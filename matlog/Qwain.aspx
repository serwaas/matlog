﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Qwain.aspx.cs" Inherits="matlog.Qwain" %>

<link href="CSS/MainStyle.css" rel="stylesheet" />
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
        
            
        <div id ="head">
            
         <asp:Button ID="Button1" runat="server" OnClick="Button1_Click"  style="margin-left: 91px; width:200px; color:#1a419f; font-size:16px; 
                                                                                 background-color:#cccccc; padding:3px;  margin:2px;border:1px solid #666666; margin-bottom: 16px" 
                                    Text="Сгенерировать функцию" Font-Names="Comic Sans MS" Font-Size="Medium" />
            <a href="index.html"><div class ="but">Меню</div></a>
        
             <br />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server" Height="28px" style="margin-left: 140px" Width="346px" Font-Names="Schadow BT" Font-Size="Larger" OnTextChanged="TextBox1_TextChanged" ReadOnly="True">0000000000000000</asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Введите ответ:" Font-Names="Schadow BT" Font-Size="Larger"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox2" runat="server" style="margin-left: 88px; margin-top: 17px; margin-bottom: 1px;" Width="400px" Font-Names="Schadow BT" Font-Size="Larger" OnTextChanged="TextBox2_TextChanged">xyzt V !xyz!t</asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" style="margin-left: 20px;  color:#1a419f; font-size:16px; 
                                                                                 background-color:#cccccc; padding:3px;  margin:2px;border:1px solid #666666; margin-bottom: 16px" 
                                                                         Text="OK" Height="35px" Width="35px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
            
            </div>
     
            </div>

    </div>
       
    </form>
</body>
</html>
