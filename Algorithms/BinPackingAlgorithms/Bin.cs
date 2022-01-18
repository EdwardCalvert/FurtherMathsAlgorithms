using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjBinPacking
{
    class Bin
    {
        private List<List<int>> _bin = new List<List<int>>();
        private int _capacity;
        public Bin(int Capacity)
        {
            _capacity = Capacity;
            _bin.Add(new List<int>());
        }

        public bool RowExists(int row)
        {
            return row <_bin.Count;
        }


        public bool ObjectWillFit(int row, int size)
        {
            return _capacity - _bin[row].Sum() >= size ;
        }

        public void AddInNextFreeSpace(int size)
        {
            bool objectInBin = false;
            int row = 0;
            if(size > _capacity)
            {
                throw new Exception("Stupid, you try put object greater than capacity in bin!");
            }
            do
            {
                if (RowExists(row) && ObjectWillFit(row, size))
                {
                    _bin[row].Add(size);
                    objectInBin = true;
                }
                else {
                    if (!RowExists(row + 1))
                    {
                        _bin.Add(  new List<int>());
                        _bin[row + 1].Add(size);
                        objectInBin = true;
                    }
                    else
                    {
                        row++;
                    }

                }

                    }
            while (!objectInBin);
        }

        public void AddObject(int row, int size)
        {
            if (ObjectWillFit(row, size)){
                _bin[row].Add(size);
            }
            else
            {
                throw new Exception("This doesn't fit!");
            }
        }


        public string PrintBin()
        {

            int heightCount = 0;
            foreach (List<int> list in _bin)
            {
                if(list.Count > heightCount)
                {
                    heightCount = list.Count;
                }
            }
            int width = _bin.Count;
            string table = new("");
            for(int i=heightCount-1; i >= 0; i--) //Traverse down the bin. 
            {
                for(int j= 0; j<width; j++) //Then along the columns of the entire bin.
                {
                    table += "|";
                    if (i < _bin[j].Count) //What does it mean? Looks like the Column, (j < _bin[i].Count) //If the index is less than the height of the bin! 
                    {
                        table += _bin[j][i].ToString().PadLeft(10); //Get the value of the bin at position [i-1], [j]
                    }
                    else
                    {
                        table += new string(' ', 10);
                    }


                }
                table += "|\n";
            }
            table += new string('_', width * 11 + 1);

            return table;
        }

    }
}
