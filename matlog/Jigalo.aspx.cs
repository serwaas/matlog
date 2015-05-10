using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace matlog
{
    public partial class Jigalo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            var rnd = new Random();
            var s1 = "";
            if (RadioButtonList3.SelectedValue == "1") //vector
            {
                s1 = RandFunq.Operate(RadioButtonList2.SelectedValue, RadioButtonList1.SelectedValue);
            }
            else
            {
                var count = RadioButtonList1.SelectedValue == "2" ? 4 : 8;
                for (var i = 0; i < count; i++)
                {
                    s1 += rnd.Next(2) == 1 ? "1" : "0";
                }


            }
            TextBox1.Text = s1;
            TextBox1.Visible = true;
            TextBox2.Visible = true;
            Label1.Visible = true;
            Button2.Visible = true;


                    
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var s1 = "";
            var components = new string[3];
            if (RadioButtonList3.SelectedValue == "1")
            {
                var s = TextBox1.Text;
                components =
                    s.Split(' ', '(', ')', '<', '-', '>', 'V', 'v', '*','!').Where(w => w != "").OrderBy(r => r).Distinct().ToArray();
                var ta = new Formula();
                if (components.Length == 3)
                {
                    for (var x = 0; x < 2; x++)
                        for (var y = 0; y < 2; y++)
                            for (var z = 0; z < 2; z++)
                            {
                                ta.SetVariable("x", x != 0);
                                ta.SetVariable("y", y != 0);
                                ta.SetVariable("z", z != 0);

                                s1 += ta.Operate(s).acc == false ? "0" : "1";
                            }
                }
                else
                {
                    for (var x = 0; x < 2; x++)
                        for (var y = 0; y < 2; y++)
                        {
                            ta.SetVariable(components[0], x != 0);
                            ta.SetVariable(components[1], y != 0);

                            s1 += ta.Operate(s).acc == false ? "0" : "1";
                        }
                }
            }
            else
            {
                components = RadioButtonList1.SelectedValue == "2" ? new[] {"x", "y"} : new[] {"x", "y", "z"};
                s1 = TextBox1.Text;
            }
            var poll = Polinom.Operate(s1, components);
            
            var answer = TextBox2.Text;
            var splitAnswer = answer.Split(' ', '+').Where(w => w != "").Select(ww=>ww.ToLower()).ToArray();
            
            var isCorrect = poll.Length == splitAnswer.Length;
            if (isCorrect)
                foreach (var str in splitAnswer.Where(str => poll.All(w => w != str)))
                    isCorrect = false;
           


            
            var script = isCorrect ? "alert(\"Все верно\");" : "alert(\"Неправильно :( " + s1 + " \");";
            ScriptManager.RegisterStartupScript(this, GetType(),
                                  "MSGbox", script, true);
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}