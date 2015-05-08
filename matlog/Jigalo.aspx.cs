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

            var rnd=new Random();
            var s1 = "";
            if (RadioButtonList3.SelectedValue == "1")//vector
            {
                s1 = Rand.operat(RadioButtonList2.SelectedValue, "3");
            }
            else
            {
                for (var i = 0; i < 4; i++)
                {
                    if (rnd.Next(2) == 1)
                        s1 += "1";
                    else s1 += "0";
                }
                
                    for (var i = 0; i < 4; i++)
                    {
                        if (rnd.Next(2) == 1)
                            s1 += "1";
                        else s1 += "0";
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
            if (RadioButtonList3.SelectedValue == "1")
            {
                var s = TextBox1.Text;
                var ta = new Formula();

                for (var x = 0; x < 2; x++)
                    for (var y = 0; y < 2; y++)
                        for (var z = 0; z < 2; z++)
                        {

                            if (x == 0)
                            {
                                //ta.SetVariable("X", false);
                                ta.SetVariable("x", false);
                            }
                            else
                            {
                                //ta.SetVariable("X", true);
                                ta.SetVariable("x", true);
                            }
                            if (y == 0)
                            {
                                //ta.SetVariable("Y", false);
                                ta.SetVariable("y", false);
                            }
                            else
                            {
                                //ta.SetVariable("Y", true);
                                ta.SetVariable("y", true);
                            }
                            if (z == 0)
                            {
                                //ta.SetVariable("Z", false);
                                ta.SetVariable("z", false);
                            }
                            else
                            {
                                //ta.SetVariable("Z", true);
                                ta.SetVariable("z", true);
                            }

                            if (ta.Operate(s).acc == false)
                                s1 += "0";
                            else
                                s1 += "1";


                        }
            }
            else
                s1 = TextBox1.Text;
            var pol = new Poli();
            s1 = pol.operate(s1);
            var answer = TextBox2.Text;
            var splitAnswer = answer.Split(' ', '+').Where(w => w != "").Select(ww=>ww.ToLower()).ToArray();
            var splitS1 = s1.Split('+', ' ').Where(w => w != "").ToArray();
            
            var isCorrect = splitS1.Length == splitAnswer.Length;
            if (isCorrect)
                foreach (var str in splitAnswer.Where(str => splitS1.All(w => w != str)))
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