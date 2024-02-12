using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace edtoy.CommandLineOptions
{
    [Verb("random", HelpText = "Random number.")]
    public class CORandomNumber
    {
        [Option('u', "upper", Required = false, Default = "100", HelpText = "Max upper limit number.")]
        public string UpperNumberStr { set { UpperNumber = QNumberBigInteger.Parse(value); } }
        public QNumberBigInteger UpperNumber { get; set; }

        [Option('l', "lower", Required = false, Default = "0", HelpText = "Min lower limit number.")]
        public string LowerNumberStr { set { LowerNumber = QNumberBigInteger.Parse(value); } }
        public QNumberBigInteger LowerNumber { get; set; }

        [Option('n', "number", Required = false, Default = 10, HelpText = "Number of list.")]
        public int Number { get; set; }

        [Option('c', "comma", Required = false, Default = false, HelpText = "One line separated by commas.")]
        public bool OutputComma { get; set; }
    }
}
