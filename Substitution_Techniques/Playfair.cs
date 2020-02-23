using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace Substitution_Techniques
{
   public class Playfair
    {
       char[,] mykeymatrix;
       List<bool> vistited;
      public Playfair()
       {
           vistited = new List<bool>();
           mykeymatrix = new char[5, 5]; 
          for (int i = 0; i < 26; i++)
              vistited.Add(false); 
              
          
       }

      public string encrypt(string message, string key)
      {

          constructmatrix(key);
          string temp = message;
          string encrptemessage = "";
          
          temp = temp.ToUpper();
          for (int i = 0; i < temp.Length; i += 2)
          {
              int rowfirst = 0, colfirst = 0, rowsecond = 0, colsecond = 0;
              char x = temp[i], y;
              if (i + 1 < temp.Length)
                  y = temp[i + 1];
              else
                  y = 'X';
              if (x == y)
              {
                  y = 'X';
                  i--;
              }
              // detect the postion of first element in matrix
              for (int j = 0; j < 5; j++)
              {

                  for (int k = 0; k < 5; k++)
                  {
                      if (mykeymatrix[j, k] == x)
                      {
                          rowfirst = j;
                          colfirst = k;
                          break; 
                      }
                  }
              }
              // detect the postion of second element in matrix

              for (int j = 0; j < 5; j++)
              {

                  for (int k = 0; k < 5; k++)
                  {
                      if (mykeymatrix[j, k] == y)
                      {
                          rowsecond = j;
                          colsecond = k;
                          break; 
                      }
                  }
              }

              // first case : if there are in same row 
              if (rowfirst == rowsecond)
              {
                  encrptemessage += mykeymatrix[rowfirst, (colfirst + 1) % 5];
                  encrptemessage += mykeymatrix[rowfirst, (colsecond + 1) % 5];
              }
              //second case : if there are in same col 
              else if (colfirst == colsecond)
              {
                  encrptemessage += mykeymatrix[(rowfirst + 1) % 5, colfirst];
                  encrptemessage += mykeymatrix[(rowsecond + 1) % 5, colfirst];
              }

             // third case : if there are in diffrent rows and cols 

              else
              {
                  encrptemessage += mykeymatrix[rowfirst, colsecond];
                  encrptemessage += mykeymatrix[rowsecond, colfirst];
              }


          }

          MessageBox.Show(encrptemessage); 

          return encrptemessage;
      }
      public string decrypt(string encrptemessage, string key)
      {
          constructmatrix(key);

          encrptemessage = encrptemessage.ToUpper();
         string decrptmessage = ""; 
          for (int i = 0; i < encrptemessage.Length; i+=2)
          {
              int rowfirst = 0, colfirst = 0, rowsecond = 0, colsecond = 0;
              char x = encrptemessage[i];
              char y = encrptemessage[i + 1]; 
              // detect the postion of first element in matrix
              for (int j = 0; j < 5; j++)
              {

                  for (int k = 0; k < 5; k++)
                  {
                      if (mykeymatrix[j, k] == x)
                      {
                          rowfirst = j;
                          colfirst = k;
                          break;
                      }
                  }
              }
              // detect the postion of second element in matrix

              for (int j = 0; j < 5; j++)
              {

                  for (int k = 0; k < 5; k++)
                  {
                      if (mykeymatrix[j, k] == y)
                      {
                          rowsecond = j;
                          colsecond = k;
                          break;
                      }
                  }
              }

              // first case : if there are in same row 
              if (rowfirst == rowsecond)
              {

                  if(colfirst-1<0)
                      decrptmessage += mykeymatrix[rowfirst, 4];
                  else
                      decrptmessage += mykeymatrix[rowfirst, colfirst - 1];

                  if (colsecond - 1 < 0)
                      decrptmessage += mykeymatrix[rowfirst, 4];
                  else
                      decrptmessage += mykeymatrix[rowfirst, colsecond - 1];

              }
              //second case : if there are in same col 
              else if (colfirst == colsecond)
              {

                  if (rowfirst - 1 < 0)
                      decrptmessage += mykeymatrix[4, colfirst];
                  else
                      decrptmessage += mykeymatrix[rowfirst - 1, colfirst];

                  if (rowsecond - 1 < 0)
                      decrptmessage += mykeymatrix[4, colfirst];
                  else
                      decrptmessage += mykeymatrix[rowsecond - 1, colfirst]; 

              }

             // third case : if there are in diffrent rows and cols 

              else
              {
                  decrptmessage += mykeymatrix[rowfirst, colsecond];
                  decrptmessage += mykeymatrix[rowsecond, colfirst]; 
              }
          }


          MessageBox.Show(decrptmessage); 
              return decrptmessage; 
      }

      void constructmatrix(string key)
      {
          key = key.ToUpper();
          int starti = 0;
          int startj = 0;
          foreach (char c in key)
          {

              if (!vistited[c - 'A'])
              {
                  vistited[c - 'A'] = true;

                  mykeymatrix[starti, startj++] = c;
                  if (startj == 5)
                  {
                      startj = 0;
                      starti++;
                  }
                  if (c == 'I' || c == 'J')
                      vistited['I' - 'A'] = vistited['J' - 'A'] = true;
              }
          }

          for (char i = 'A'; i <= 'Z'; i++)
          {

              if (!vistited[i - 'A'])
              {

                  mykeymatrix[starti, startj] = i;
                  startj++;
                  if (startj == 5)
                  {
                      startj = 0;
                      starti++;
                  }
                  vistited[i - 'A'] = true;
                  if (i == 'I' || i == 'J')
                      vistited['I' - 'A'] = vistited['J' - 'A'] = true;
              }

          }
      }
    }
}
