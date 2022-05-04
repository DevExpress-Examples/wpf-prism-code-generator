using Prism;
using Prism.Mvvm;
using System;
using DevExpress.Mvvm.CodeGenerators.Prism;
using System.Windows.Threading;

namespace ModuleA.ViewModels
{
    [GenerateViewModel(ImplementIActiveAware = true)]
    public partial class TabViewModel
    {
        DispatcherTimer counterTimer = new DispatcherTimer();

        [GenerateProperty]
        bool counterLocked;
        [GenerateProperty]
        string title;
        [GenerateProperty]
        int counter;

        //[GenerateCommand(ObservesProperties = new string[] { "CounterLocked" })]
        [GenerateCommand(ObservesCanExecuteProperty = "CounterLocked" )]
        public void UnlockCounter()
        {
            counterTimer.Start();
            CounterLocked = false;
        }
        bool CanUnlockCounter() => CounterLocked;
        [GenerateCommand(ObservesProperties = new string[] { "CounterLocked" })]
        public void LockCounter()
        {
            counterTimer.Stop();
            CounterLocked = true;
        }
        bool CanLockCounter() => !CounterLocked;

        public TabViewModel()
        {
            counterTimer.Interval = new TimeSpan(0, 0, 1);
            counterTimer.Tick += CounterTimer_Tick;
        }
        private void CounterTimer_Tick(object sender, EventArgs e)
        {
            Counter++;
        }
        void OnIsActiveChanged()
        {
            if (CounterLocked)
                return;
            if (IsActive)
                counterTimer.Start();
            else
                counterTimer.Stop();
        }

    }
}
