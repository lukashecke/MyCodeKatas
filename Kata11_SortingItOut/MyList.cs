using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kata11_SortingItOut
{
    public class MyList<T> : List<T>
    {
        public void SortedAdd(T t)
        {
            int index = GetIndex(t);
            if (index == -1)
            {
                this.Add(t);
            }
            else
            {
                InsertItem(t, index);
            }
        }

        public string Decode(string crypt)
        {
            //string ret;
            //ret = crypt.ToLower();
            //ret = Regex.Replace(ret, "[^a-zA-Z]", "");
            //ret = string.Concat(ret.OrderBy(x => x));
            //return ret;
            return string.Concat(Regex.Replace(crypt.ToLower(), "[^a-zA-Z]", "").OrderBy(x => x)); 
        }

        private void InsertItem(T t, int index)
        {
            MyList<T> copy = new MyList<T>();
            this.ForEach((item) =>
            {
                copy.Add(item);
            });
            this.Clear();
            for (int i = 0; i < copy.Count + 1; i++)
            {
                if (i < index)
                {
                    this.Add(copy.ElementAt(i));

                }
                else if (i == index)
                {
                    this.Add(t);
                }
                else // i > index
                {
                    if (i <= copy.Count)
                    {
                        this.Add(copy.ElementAt(i - 1));
                    }
                }
            }
        }

        private int GetIndex(T t)
        {
            int index = -1;
            for (int i = 0; i < this.Count; i++)
            {
                if (Comparer<T>.Default.Compare(this.ElementAt(i), t) >= 0)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }
    }
}
