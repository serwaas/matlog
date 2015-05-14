using System;
using System.Linq;
using System.Web.UI;

namespace matlog
{
    public partial class SCNF : Page
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
                if (rnd.Next(2) == 1)
                    s1 += "1";
                else s1 += "0";
            }

            
            TextBox1.Text = s1;
            TextBox1.Visible = true;
            TextBox2.Visible = true;
           
            Label1.Visible = true;
            Button2.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var err = 0;
            var s = TextBox1.Text;
            var length = s.Length;
            
            var answer = TextBox2.Text;

            var sdnf = DNF.SDNF(length, s);
            var splitScnf = sdnf.Split(' ', 'v').Where(w => w != "").ToArray(); 
            var splitAnswer = answer.Split(' ','v','V').Where(w => w != "").Select(ww=>ww.ToLower()).ToArray();
            //var isCorrect = splitAnswer.Length == splitScnf.Length;
            //if (isCorrect)
            //    isCorrect = Lol.IsEqual(splitAnswer, splitScnf);

            var isCorrect = Lol.IsEqual(splitAnswer, splitScnf);
            var script = isCorrect ? "alert(\"Все верно\");" : "alert(\"Неправильно :(\");";
            ScriptManager.RegisterStartupScript(this, GetType(),
                                  "MSGbox", script, true);
                
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}