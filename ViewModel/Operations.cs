using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CalcProgram.ViewModel
{
    public class OperationsViewModel : NotifyClass, IDataErrorInfo
    {
        OperationModel objOperationModel = new OperationModel();        

        public OperationsViewModel()
        {
            AddCommand = new OperationCommand(Add, isValid);
            SubtractCommand = new OperationCommand(Subtract, isValid);
            MultiplyCommand = new OperationCommand(Multiply, isValid);
            DivideCommand = new OperationCommand(Divide, isValid);           
        }

        public void Add()
        {
            objOperationModel.Add();
            PropertyChangedMethod("Result");
        }

        public void Subtract()
        {
            objOperationModel.Subtract();
            PropertyChangedMethod("Result");
        }

        public void Multiply()
        {
            objOperationModel.Multiply();
            PropertyChangedMethod("Result");
        }

        public void Divide()
        {
            objOperationModel.Divide();
            PropertyChangedMethod("Result");
        }     

        bool isValid()
        {
            int Tempresult = 0;
            if (!IsValidNumber(input1, out Tempresult))
            {
                return false;
            }

            if (!IsValidNumber(input2, out Tempresult))
            {
                return false;
            }
            return true;
        }

        public OperationCommand AddCommand
        {
            get;
            set;
        }

        public OperationCommand SubtractCommand
        {
            get;
            set;
        }

        public OperationCommand MultiplyCommand
        {
            get;
            set;
        }

        public OperationCommand DivideCommand
        {
            get;
            set;
        }

        string input1;
        public string txtInput1
        {
            get
            {
                return input1;
            }
            set
            {
                input1 = value;
            }
        }

        string input2;
        public string txtInput2
        {
            get
            {
                return input2;
            }
            set
            {
                input2 = value;
            }
        }

        public string Result
        {
            get
            {
                return objOperationModel.Result.ToString();
            }
            set
            {
                objOperationModel.Result = Convert.ToDouble(value);
            }
        }       

        #region DataErrorInfo Member

        public string Error
        {
            get { return null; }
        }

        public string this[string propertyName]
        {
            get
            {
                int result;
                if (propertyName == "txtInput1")
                {
                   // objOperationCommand.Refresh();
                    if (!IsValidNumber(input1, out result))
                    {
                        objOperationModel.FirstNumber = 0;
                        return "Input must be number";
                    }
                    else
                    {
                        objOperationModel.FirstNumber = result;
                    }
                }

                int result2;
                if (propertyName == "txtInput2")
                {
                   // objOperationCommand.Refresh();
                    if (!IsValidNumber(input2, out result2))
                    {
                        objOperationModel.SecondNumber = 0;
                        return "Input must be number";
                    }
                    else
                    {
                        objOperationModel.SecondNumber = result2;
                    }
                }

                return null;
            }
        }

        public bool IsValidNumber(string input, out int output)
        {
            if (int.TryParse(input, out output))
            {
                return true;
            }
            return false;
        }

        #endregion
    }

    public class OperationCommand : ICommand
    {
        Action whatToExecute;
        Func<bool> whenToExecute;
        Action refresh;

        public OperationCommand(Action what, Func<bool> when)
        {
            whatToExecute = what;
            whenToExecute = when;           
        }

        public bool CanExecute(object parameter)
        {
            return whenToExecute();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove {
                CommandManager.RequerySuggested -= value; 
            }
        }

        public void Execute(object parameter)
        {
            whatToExecute();
        }
    }
}
