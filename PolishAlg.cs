using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabWork3
{
    class PolishAlg
    {
        private string brackets = "(){}[]";
        private string openBr = "({[";
        private string operations = "+-/*=%sincostanctglog";
        public string formula;

        public PolishAlg(string _formula)
        {
            formula = _formula;
        }

        private int priority (string op)
        {
            return op == "+" || op == "-" ? 1 :
        op == "*" || op == "/" || op == "%"? 2 :
        op == "="? 0 :
        op == "sin"|| op == "cos" || op == "tan" || op == "ctg" || op =="log" || op == "exp"? 4 :
        op == "^"? 3: -1;
        }

        public string Transform()
        {
            var pForm = SplitStr(formula);
            var res = new Stack<string>();
            var oper = new Stack<string>();
            foreach(var c in pForm)
            {
                if (openBr.Contains(c))
                {
                    oper.Push(c);
                }
                else if (brackets.Contains(c))
                {
                    while(!openBr.Contains(oper.Peek()))
                    {
                        res.Push(oper.Pop());
                    }
                    oper.Pop();
                }
                else if (operations.Contains(c))
                {

                    while (oper.Count != 0 && priority(oper.Peek()) >= priority(c))
                        res.Push(oper.Pop());
                    oper.Push(c);
                }
                else
                {
                    res.Push(c);
                }
            }
            while(oper.Count != 0)
            {
                res.Push(oper.Pop());
            }
            return ConvertToStr(res);
        }

        private string ConvertToStr(Stack<string> res)
        {
            var result = new StringBuilder();
            var arr = res.ToArray();
            for (var i = arr.Length-1; i >= 0; i--)
            {
                result.Append(arr[i].ToString());
                if (i != 0)
                    result.Append(",");
            }
            return result.ToString();
        }

        private string[] SplitStr(string formula)
        {
            var res = new List<string>();
            for (var i = 0; i < formula.Length; i++)
            {
                if (Char.IsDigit(formula[i]) || (formula[i] == '-' && (i == 0 || openBr.Contains(formula[i - 1]) || operations.Contains(formula[i - 1])) && Char.IsDigit(formula[i+1])))
                {
                    var a = formula[i].ToString();
                    if (formula.Length != i + 1)
                    {


                        while (Char.IsDigit(formula[i + 1]))
                        {
                            i++;
                            a += formula[i].ToString();
                            if (formula.Length <= i + 1)
                                break;
                        }
                    }
                    res.Add(a);
                }
                else
                {
                    if ((formula[i] == '-' && (i == 0 || openBr.Contains(formula[i - 1]) || operations.Contains(formula[i - 1]))) && !operations.Contains(formula[i + 1]))
                    {
                        res.Add(formula[i].ToString() + formula[i + 1].ToString());
                        i++;
                    }
                    else if (i + 3 < formula.Length && operations.Contains(formula[i].ToString() + formula[i + 1].ToString() + formula[i + 2].ToString()) && formula[i + 3] == '(')
                    {
                        
                        
                        var j = i + 4;
                        var s = "";
                        while (formula[j] != ')')
                        {
                            s += formula[j].ToString();
                            j++;
                        }

                        var microRes = new PolishAlg(s);
                        res.Add(microRes.Transform() + "," + formula[i].ToString() + formula[i + 1].ToString() + formula[i + 2].ToString());
                        i += j - i + 5;
                    }
                    else
                    {
                        res.Add(formula[i].ToString());
                    }
                }
            }
            return res.ToArray();
        }
    }

}
