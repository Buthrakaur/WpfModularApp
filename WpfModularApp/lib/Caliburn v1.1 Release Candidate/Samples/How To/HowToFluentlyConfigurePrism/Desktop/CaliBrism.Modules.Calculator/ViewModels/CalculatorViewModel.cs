using System;
using System.Windows;
using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Filters;

namespace CaliBrism.Modules.Calculator.ViewModels
{
    [Rescue("GeneralRescue")]
    [PerRequest(typeof(ICalculatorViewModel))]
    public class CalculatorViewModel : Presenter, ICalculatorViewModel
    {
        public override string DisplayName
        {
            get
            {
                return "Calculator";
            }
            set
            {
                base.DisplayName = value;
            }
        }
       
        [Rescue("ActionSpecificRescue")]
        [Preview("CanDivide")]
        public int Divide(int left, int right)
        {
            return left / right;
        }

        public bool CanDivide(int left, int right)
        {
            return right != 0;
        }

        public void GeneralRescue(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

        public void ActionSpecificRescue(Exception ex)
        {
            MessageBox.Show("Divide Action: " + ex.Message);
        }
    }
}