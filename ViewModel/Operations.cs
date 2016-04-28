using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CalcProgram.ViewModel
{
    class OperationsViewModel : NotifyClass, IDataErrorInfo
    {
        OperationModel objOperationModel = new OperationModel();
        OperationCommand objOperationCommand;// = new OperationCommand();

        public OperationsViewModel()
        {
            objOperationCommand = new OperationCommand(Calculate, isValid);
        }

        bool isValid()
        {
            int Tempresult=0;
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

        bool validateInput(string value)
        {
            int result;

            if (int.TryParse(value.ToString(), out result))
            {
                return true;
            }

            return false;
        }

        public ICommand cmd
        {
            get { return objOperationCommand; }
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

        public void Calculate(object obj)
        {
            switch (obj.ToString())
            {
                case "Add":
                    objOperationModel.Add();
                    break;
                case "Subtract":
                    objOperationModel.Subtract();
                    break;
                case "Multiply":
                    objOperationModel.Multiply();
                    break;
                case "Divide":
                    objOperationModel.Divide();
                    break;
            }

            PropertyChangedMethod("Result");
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
                    objOperationCommand.Refresh();
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
                    objOperationCommand.Refresh();
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

    class OperationCommand : ICommand
    {
        Action<object> whatToExecute;
        Func<bool> whenToExecute;

        public OperationCommand(Action<object> what, Func<bool> when)
        {
            whatToExecute = what;
            whenToExecute = when;
        }

        public bool CanExecute(object parameter)
        {
            return whenToExecute();
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            whatToExecute(parameter);
        }

        public void Refresh()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
}
