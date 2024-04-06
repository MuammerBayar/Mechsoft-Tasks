
/*
You have a text that some of the words in reverse order.
The text also contains some words in the correct order, and they are wrapped in parenthesis.
Write a function fixes all of the words and,
remove the parenthesis that is used for marking the correct words.

Your function should return the same text defined in the constant correctAnswer, please keep in mind
that shortest way possible will get you extra points.
*/

using Microsoft.VisualBasic;

internal class Program
{
    private static void Main(string[] args)
    {
        var inputText = "nhoJ (Griffith) nodnoL saw (an) (American) ,tsilevon ,tsilanruoj (and) laicos .tsivitca ((A) reenoip (of) laicremmoc noitcif (and) naciremA ,senizagam (he) saw eno (of) (the) tsrif (American) srohtua (to) emoceb (an) lanoitanretni ytirbelec (and) nrae a egral enutrof (from) ).gnitirw";
        var correctAnswer = "John Griffith London was an American novelist, journalist, and social activist. (A pioneer of commercial fiction and American magazines, he was one of the first American authors to become an international celebrity and earn a large fortune from writing.)";

        string ReverseText(string input)
        {
            input += " ";
            var result = "";
            var bIndex = 0;
            var lIndex = inputText.IndexOf(" ", bIndex); ;

            while (true)
            {
                if (input[bIndex].Equals('('))
                {
                    int temp1 = input.IndexOf(")", bIndex);
                    int temp2 = input.IndexOf("(", bIndex + 1);
                    if ( temp2 != -1 && temp2 < temp1 )
                    {
                        result += "(" + input.Substring(temp2 + 1, temp1 - temp2 - 1) + " ";
                        bIndex = input.IndexOf(" ", bIndex) + 1;
                        lIndex = input.IndexOf(" ", bIndex);
                        continue;
                    }

                    result += input.Substring(bIndex + 1, temp1 - bIndex - 1) + " ";
                    bIndex = input.IndexOf(" ", bIndex) + 1;
                }
                else
                {
                    result += Reverse(inputText.Substring(bIndex, lIndex - bIndex).ToCharArray()) + " ";
                    bIndex = lIndex + 1;
                }

                lIndex = input.IndexOf(" ", bIndex);

                if (lIndex == -1)
                    break;

            }
            
            return result.Trim();
        }
        
        string Reverse(char[] arr)
        {
            Array.Reverse(arr);
            return new string(arr);
        }

        void Swap(char[]arr, int i, int k)
        {
            var temp = arr[i];
            arr[i] = arr[k];
            arr[k] = temp;
        }

        Console.WriteLine(ReverseText(inputText) == correctAnswer ? "Correct !!!" : "Wrong answer...!");
        Console.ReadLine();
    }
}