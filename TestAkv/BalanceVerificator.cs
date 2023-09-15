using System;
using System.Collections.Generic;
using System.Text;

namespace TestAkv
{
    public static class BalanceVerificator
    {
        
        private static bool isMatchingPair(char char1, char char2)
        {
            if (char1 == '(' && char2 == ')')
                return true;
            else if (char1 == '{' && char2 == '}')
                return true;
            else if (char1 == '[' && char2 == ']')
                return true;
            else
                return false;
        }
        public static int areBracketsBalanced(string exp)
        {
            if (exp.Length == 0)
            {
                string message = $"Input data doesn't contains characters";
                throw new IllegalArgumentException(message);
            }
            Stack<char> st = new Stack<char>();
            Stack<int> indexes = new Stack<int>();
            int index = -1;

            for (int i = 0; i < exp.Length; i++)
            {

                if (exp[i] == '{' || exp[i] == '('
                    || exp[i] == '[')
                {               
                    st.Push(exp[i]);
                    indexes.Push(i);
                }

                if (exp[i] == '}' || exp[i] == ')'
                    || exp[i] == ']')
                {
                    if (st.Count == 0)
                    {
                        return i;
                    }
                 
                    else if (!isMatchingPair(st.Pop(),
                                             exp[i]))
                    {
                        return indexes.Pop();
                    }
                    indexes.Pop();
                }
                else if (exp[i] != '{' && exp[i] != '('
                    && exp[i] != '[' && exp[i] != '}' && exp[i] != ')'
                    && exp[i] != ']')
                {
                    string message = $"A character ‘{exp[i]}’ doesn’t belong to any known brackets type,";
                    throw new IllegalArgumentException(message, exp[i]);
                }
            }
            
            if (st.Count == 0)
                return -1; // balanced
            else
            {
                for(int i = 0; i < exp.Length; i++)
                {
                    if (exp[i] == st.Peek())
                    {
                        index = i;
                        break;
                    }
                }
                
                return index; // not balanced
            }
        }
    }
}