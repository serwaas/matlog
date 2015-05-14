using System;
using System.Linq;
using System.Web.UI;

namespace matlog
{
    public partial class SDNF : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var rnd = new Random();
            var s1 = "";
            var count = RadioButtonList1.SelectedValue == "3" ? 8 : 16;
            for (var i = 0; i < count; i++)
            {
                s1 += rnd.Next(2) == 1 ? "1" : "0";
            }

            TextBox1.Text = s1;
            TextBox1.Visible = true;
            TextBox2.Visible = true;
           
            Label1.Visible = true;
            Button2.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var s= TextBox1.Text;
            var err = 0;
            
            var length = s.Length;
            
            var answer = TextBox2.Text;
            
            var scnf = DNF.SCNF(length, s);
            var splitSdnf = scnf.Split('(', ')').Where(w => w != "").ToArray();
            var splitAnswer = answer.Split('(', ')').Where(w => w != "").Select(ww => ww.ToLower()).ToArray();
            //var isCorrect = splitAnswer.Length == splitSdnf.Length;

            //if (isCorrect)
            //    isCorrect = Lol.IsEqual(splitAnswer, splitSdnf);
            var isCorrect = Lol.IsEqual(splitAnswer, splitSdnf);
            var script = isCorrect ? "alert(\"Все верно\");" : "alert(\"Неправильно :(\");";
            ScriptManager.RegisterStartupScript(this, GetType(),
                                  "MSGbox", script, true);
               
            
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}