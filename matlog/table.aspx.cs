using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace matlog
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TextBox1.Visible = true;
            TextBox2.Visible = true;
            Label1.Visible = true;
            Button2.Visible = true;
            TextBox1.Text = Rand.operat(RadioButtonList2.SelectedValue, "3");//(RadioButtonList2.SelectedValue, RadioButtonList1.SelectedValue);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string s = TextBox1.Text;
            Formula ta = new Formula();

            string s1 = "";
           // if (RadioButtonList1.SelectedValue == "2")
            for (int x = 0; x < 2; x++)
                for (int y = 0; y < 2; y++)
                    for (int z = 0; z < 2; z++)
                    {

                        if (x == 0)
                        {
                            ta.SetVariable("X", false);
                            ta.SetVariable("x", false);
                        }
                        else
                        {
                            ta.SetVariable("X", true);
                            ta.SetVariable("x", true);
                        }
                        if (y == 0)
                        {
                            ta.SetVariable("Y", false);
                            ta.SetVariable("y", false);
                        }
                        else
                        {
                            ta.SetVariable("Y", true);
                            ta.SetVariable("y", true);
                        }
                        if (z == 0)
                        {
                            ta.SetVariable("Z", false);
                            ta.SetVariable("z", false);
                        }
                        else
                        {
                            ta.SetVariable("Z", true);
                            ta.SetVariable("z", true);
                        }

                        if (ta.Operate(s).acc == false)
                            s1 += "0";
                        else
                            s1 += "1";


                    }
            //else
            //    for (int x = 0; x < 2; x++)
            //        for (int Y = 0; Y < 2; Y++)
                        
            //            {

            //                if (x == 0)
            //                {
            //                    ta.setVariable("X", false);
            //                    ta.setVariable("x", false);
            //                }
            //                else
            //                {
            //                    ta.setVariable("X", true);
            //                    ta.setVariable("x", true);
            //                }
            //                if (Y == 0)
            //                {
            //                    ta.setVariable("Y", false);
            //                    ta.setVariable("Y", false);
            //                }
            //                else
            //                {
            //                    ta.setVariable("Y", true);
            //                    ta.setVariable("Y", true);
            //                }
                            

            //                if (ta.operate(s).acc == false)
            //                    s1 += "0";
            //                else
            //                    s1 += "1";


            //            }
            string answer = TextBox2.Text;
           
            int err=0;
            var count = Math.Pow(2,3);//Convert.ToInt32(RadioButtonList1.SelectedValue));
            if (answer.Length == count)
            {
                for (int i = 0; i < count; i++)
                    if (answer[i] != s1[i])

                        err = 1;
            }
            else
                err = 2;
            string script="";
            if (err==0)
                script = "alert(\"Все верно\");";
             if (err == 2)
                script = "alert(\"Неверная длина вектора\");";
            if (err == 1)
                script = "alert(\"Неправильно :(\");";
            ScriptManager.RegisterStartupScript(this, GetType(),
                                  "MSGbox", script, true);
            
           
            

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}