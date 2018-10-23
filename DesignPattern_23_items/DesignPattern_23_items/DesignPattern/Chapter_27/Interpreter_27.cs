using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_23_items.DesignPattern.Chapter_27
{
    /// <summary>
    /// 解釋器 Interpreter
    /// </summary>
    class Interpreter_27
    {
        /// <summary>
        /// 解釋器原型
        /// </summary>
        public void ExcuteInterPreter()
        {
            Context context = new Context();
            //建立語法Tree
            IList<AbstractExpression> list = new List<AbstractExpression>();
            list.Add(new TerminalExpression());
            list.Add(new NonterminalExpression());
            list.Add(new TerminalExpression());
            list.Add(new TerminalExpression());

            foreach (AbstractExpression exp in list)
            {
                exp.Interpreter(context);
            }

            Console.Read();
        }

        /// <summary>
        /// 音樂字符解釋器
        /// </summary>
        public void ExcuteInterPreterMusic()
        {
            PlayContext context = new PlayContext();

            Console.WriteLine($"上海灘: ");
            context.PlayText = "O 2 E 0.5 G 0.5 A 3 E 0.5 G 0.5 D 3 E 0.5 G 0.5 A 0.5 O 3 C 1 O 2 A 0.5 G 1 C 0.5 E 0.5 D 3";
            Expression expression = null;
            try
            {
                while (context.PlayText.Length > 0)
                {
                    string str = context.PlayText.Substring(0, 1);
                    switch (str)
                    {
                        case "O":
                            //字母為O時 實例化音階
                            expression = new Scale();
                            break;

                        case "C"://字母為 C ~ P (休止符) 時實例化音符
                        case "D":
                        case "E":
                        case "F":
                        case "G":
                        case "A":
                        case "B":
                        case "P":
                            expression = new Note();
                            break;
                    }
                    expression.Interpret(context);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }



        }

        #region 解釋器原型

        abstract class AbstractExpression
        {
            public abstract void Interpreter(Context context);
        }

        class TerminalExpression : AbstractExpression
        {
            public override void Interpreter(Context context)
            {
                Console.WriteLine("終端解釋器");
            }
        }

        class NonterminalExpression : AbstractExpression
        {
            public override void Interpreter(Context context)
            {
                Console.WriteLine("非終端解釋器");
            }
        }

        class Context
        {
            private string _input;

            public string Input
            {
                get => _input;
                set => _input = value;
            }

            private string _output;
            public string Output
            {
                get => _output;
                set => _output = value;
            }
        }




        #endregion

        #region 音樂解釋器

        /// <summary>
        /// 演奏內容
        /// </summary>
        class PlayContext
        {
            /// <summary>
            /// 文本
            /// </summary>
            private string _text;

            public string PlayText
            {
                get => _text;
                set => _text = value;
            }
        }

        /// <summary>
        /// 抽象表達式
        /// </summary>
        abstract class Expression
        {
            /// <summary>
            /// 解釋器
            /// </summary>
            /// <param name="context"></param>
            public void Interpret(PlayContext context)
            {
                if (context.PlayText.Length == 0)
                {
                    return;
                }
                else
                {
                    //英文字母  =>Key
                    string playKey = context.PlayText.Substring(0, 1);
                    context.PlayText = context.PlayText.Substring(2);

                    //對應值  => Value
                    double playValue = Convert.ToDouble(context.PlayText.Substring(0, context.PlayText.IndexOf(" ")));
                    context.PlayText = context.PlayText.Substring(context.PlayText.IndexOf(" ") + 1);

                    Excute(playKey, playValue);
                }
            }

            /// <summary>
            /// 抽象執行
            /// </summary>
            /// <param name="key"></param>
            /// <param name="value"></param>
            public abstract void Excute(string key, double value);

        }

        /// <summary>
        /// 音符對應類
        /// </summary>
        class Note : Expression
        {
            public override void Excute(string key, double value)
            {
                string note = "";
                switch (key)
                {
                    case "C":
                        note = "1";
                        break;
                    case "D":
                        note = "2";
                        break;
                    case "E":
                        note = "3";
                        break;
                    case "F":
                        note = "4";
                        break;
                    case "G":
                        note = "5";
                        break;
                    case "A":
                        note = "6";
                        break;
                    case "B":
                        note = "7";
                        break;
                }
                Console.Write($"{note} ");
            }
        }

        class Scale : Expression
        {
            public override void Excute(string key, double value)
            {
                string scale = "";
                switch (Convert.ToInt32(value))
                {
                    case 1:
                        scale = "低音";
                        break;
                    case 2:
                        scale = "中音";
                        break;
                    case 3:
                        scale = "高音";
                        break;
                }
                Console.Write($"{scale}");
            }
        }

        #endregion
    }
}
