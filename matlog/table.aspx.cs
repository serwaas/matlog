using System;
using System.Web.UI;
namespace matlog
{
    public partial class WebForm1 : Page
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
            TextBox1.Text = RandFunq.Operate(RadioButtonList2.SelectedValue, RadioButtonList1.SelectedValue);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var s = TextBox1.Text;
            var ta = new Formula();

            var s1 = "";
            if (RadioButtonList1.SelectedValue == "3")
                for (var x = 0; x < 2; x++)
                    for (var y = 0; y < 2; y++)
                        for (var z = 0; z < 2; z++)
                        {
                            ta.SetVariable("x", x != 0);
                            ta.SetVariable("y", y != 0);
                            ta.SetVariable("z", z != 0);

                            s1 += ta.Operate(s).acc == false ? "0" : "1";
                        }
            else
                for (var x = 0; x < 2; x++)
                    for (var y = 0; y < 2; y++)
                    {

                        ta.SetVariable("x", x != 0);
                        ta.SetVariable("y", y != 0);


                        s1 += ta.Operate(s).acc == false ? "0" : "1";


                    }
            var answer = TextBox2.Text;
           
            var err=0;
            var deg = Convert.ToInt32(RadioButtonList1.SelectedValue);
            var count = Math.Pow(2,deg);
            if (answer.Length == count)
            {
                for (var  i = 0; i < count; i++)
                    if (answer[i] != s1[i])
                        err = 1;
            }
            else
                err = 2;
            var script="";
            switch (err)
            {
                case 0:
                    script = "alert(\"Все верно\");";
                    break;
                case 1:
                    script = "alert(\"Неправильно :(\");";
                    break;
                case 2:
                    script = "alert(\"Неверная длина вектора\");";
                    break;

            }
            
            ScriptManager.RegisterStartupScript(this, GetType(),
                                  "MSGbox", script, true);
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}