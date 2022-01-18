using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjBinPacking
{
    class FirstFitDecreasingAlgorithm
    {
        private Bin _bin;
        private List<int> _objectsToFill;
        public FirstFitDecreasingAlgorithm( Bin bin, List<int> objectsToFill)
        {
            _bin = bin;
            _objectsToFill = objectsToFill;

            SortObjectsDescending();
            FitObjectsIntoBins();


        }

        private void SortObjectsDescending()
        {
            _objectsToFill.Sort();
                _objectsToFill.Reverse();
        }

        private void FitObjectsIntoBins()
        {
            foreach(int i in _objectsToFill)
            {
                _bin.AddInNextFreeSpace(i);
            }

            Console.WriteLine(_bin.PrintBin());
        }
    }
}
