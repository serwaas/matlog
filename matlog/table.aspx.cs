using System;
using System.Linq;
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

            var comp = RadioButtonList1.SelectedValue == "3" ? new[] {"x", "y", "z"} : new[] {"x", "y"};
            var s1 = ta.GetVector(s, comp);
            var answer = TextBox2.Text;
           
            var err=0;
            var deg = Convert.ToInt32(RadioButtonList1.SelectedValue);
            var count = Math.Pow(2,deg);
            if (answer.Length == count)
            {
                for (var  i = 0; i < count; i++)
                    if (answer[i] != s1[i])
                    {
                        err = 1;
                        break;
                    }
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