using System;
using System.Linq;
using System.Web.UI;


namespace matlog
{
    public partial class Qwain : Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
          
             var rnd = new Random();
             var text="";
            for (var i = 0; i < 16; i++)
                text += rnd.Next(2);

            TextBox1.Text = text;
             
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
            var mq = new MinQwain();
            var y =  new int[16];
            var isCorrect=true;
            var input = TextBox1.Text;
            if (input.Length != 16)
                isCorrect = false;
            if (isCorrect)
                for (var i = 0; i < 16; i++)
                    switch (input[i])
                    {
                        case  '1':
                            y[i] = 1;
                            break;
                        case '0':
                            y[i] = 0;
                            break;
                        default:
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

            var s = mq.Minimize(y);

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