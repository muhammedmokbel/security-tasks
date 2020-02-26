using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace Substitution_Techniques
{
    public class Ceaser
    {

        Dictionary<char, int> lower_alphabet;
        Dictionary<char, int> upper_alphabet;
        List<char> map_lower;
        List<char> map_upper;
        int mykey;
        public Ceaser()
        {

            lower_alphabet = new Dictionary<char, int>();
            upper_alphabet = new Dictionary<char, int>();
            map_lower = new List<char>();
            map_upper = new List<char>();
            mykey = 8;
            int index = 0;
            for (char i = 'a'; i <= 'z'; i++)
            {
                lower_alphabet[i] = index;
                map_lower.Add(i);
                index++;
            }
            index = 0;
            for (char i = 'A'; i <= 'Z'; i++)
            {
                upper_alphabet[i] = index;
                map_upper.Add(i);
                index++;
            }


        }
        public string encrypt(string message, int key)
        {
            string encrptedmessage = "";
            mykey = key;
            for (int i = 0; i < message.Length; i++)
            {
                if (message.ElementAt(i) >= 97)
                {
                    int temp = lower_alphabet[message.ElementAt(i)];
                    temp += mykey;
                    temp %= 26;
                    encrptedmessage += map_upper.ElementAt(temp);
                }
                else
                {
                    int temp = upper_alphabet[message.ElementAt(i)];
                    temp += mykey;
                    temp %= 26;
                    encrptedmessage += map_upper.ElementAt(temp);
                }
            }
            return encrptedmessage;
        }

        public string decrypt(string encrptedmassage, int key)
        {
            string message = "";
            for (int i = 0; i < encrptedmassage.Length; i++)
            {
                int temp = upper_alphabet[encrptedmassage.ElementAt(i)];
                for (int j = 0; j < 26; j++)
                {
                    if ((j + key) % 26 == temp)
                    {
                        message += map_lower.ElementAt(j);
                        break;
                    }
                }
            }


            return message;
        }

        public int Analyse(string message, string encrptedmassage)
        {
            for (int i = 0; i < 26; i++)
            {

                if (message[0] >= 97)
                {
                    int temp = lower_alphabet[message[0]];
                    if ((temp + i) % 26 == upper_alphabet[encrptedmassage[0]])
                    {
                        mykey = i;
                        break;
                    }
                }
                else
                {

                    int temp = upper_alphabet[message[0]];
                    if ((temp + i) % 26 == upper_alphabet[encrptedmassage[0]])
                    {
                        mykey = i;
                        break;
                    }
                }
            }

            return mykey;


        }
    }
    
}
