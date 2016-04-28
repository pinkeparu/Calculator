using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CalcProgram
{
    class OperationModel
    {
        private double firstNumber;
        
        public double FirstNumber
        {
            get { return firstNumber; }
            set { firstNumber = value; }
        }

        private double secondNumber;

        public double SecondNumber
        {
            get { return secondNumber; }
            set { secondNumber = value; }
        }

        private double result;

        public double Result
        {
            get { return result; }
            set { result = value; }
        }

        public void Add()
        {
            Result = FirstNumber + SecondNumber;
        }

        public void Subtract()
        {
            Result = FirstNumber - SecondNumber;
        }

        public void Multiply()
        {
            Result = SecondNumber * FirstNumber;
        }

        public void Divide()
        {
            Result = FirstNumber / SecondNumber;
        }
    }
}
