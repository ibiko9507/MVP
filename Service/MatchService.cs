using Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class MatchService
    {

        public void EvaluateGame(string textFile, out string validationResult)
        {
            MatchOperation operation = new MatchOperation();
            operation.EvaluateGame( textFile, out validationResult);
        }
    }
}
