using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees_Task_A
{
    class text : IComparable
    {
        private int count = 0;
        private string word;

        public string Word
        {
            set { Word = word; }
            get { return word; }
        }
 
        public int Count
        {
            set { Count = count; }
            get { return count; }
        }
        public void increase()
        {
            count++;
        }

        public text(string word)
        {
            this.word = word;
            count++;
        }

        public int CompareTo(object obj)
        {
            text other = (text)obj;
            return word.CompareTo(other.word);
        }
        public override string ToString()
        {
            return Word +": " +  Count;
        }
    }
}
