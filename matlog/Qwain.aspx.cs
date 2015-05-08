using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace matlog
{
    public partial class Qwain : System.Web.UI.Page
    {
       public  int[] Y;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Y = new int[16];
             var rnd = new Random();
             var boom="";
             for (var i = 0; i < 16; i++)
             {
                 var ch= rnd.Next(2);
                 Y[i] = ch;
                 boom += Y[i];
             }

             TextBox1.Text = boom;
             
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            var vect = TextBox1.Text;
            string script;
            if (vect.Length!=16)
            {
                script = "alert(\"Неверная длина исходного вектора\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "MSGbox", script, true);
                return;
            }
            var MQ = new MinQwain();
            Y =  new int[16];
            var isCorrect=true;
            var input = TextBox1.Text;
            if (input.Length != 16)
                isCorrect = false;
            if (isCorrect)
                for (var i = 0; i < 16; i++)
                    if (input[i] == '1')
                        Y[i] = 1;
                   else if (input[i] == '0')
                       Y[i] = 0;
                   else
                   {
                       isCorrect = false;
                       break;
                   }

            if (!isCorrect)
            {
                script = "alert(\"Вектор должен состоять из '0' и '1'\");";

                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "MSGbox", script, true);
                return;
            }

            var s = MQ.Minimize(Y);
            
            var j = 0;
            var answer = TextBox2.Text;
            var splitAnswer =  answer.Split(' ','v', 'V').Where(w=>w!="").Select(ww=>ww.ToLower()).ToArray();
            
            if (splitAnswer.Length != s.Length)
                isCorrect = false;
            if(isCorrect)
                foreach (var str in s.Where(str => splitAnswer.All(w => w != str)))
                    isCorrect = false;

            script = isCorrect ? "alert(\"Все верно\");" : "alert(\"Неправильно :(\");";
            ScriptManager.RegisterStartupScript(this, GetType(),
                "MSGbox", script, true);

        }
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}