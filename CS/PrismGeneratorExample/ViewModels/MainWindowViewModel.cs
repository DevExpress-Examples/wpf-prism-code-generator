using Prism.Mvvm;
using DevExpress.Mvvm.CodeGenerators.Prism;

namespace PrismGeneratorExample.ViewModels
{
    [GenerateViewModel(ImplementIActiveAware = true)]
    public partial class MainWindowViewModel : BindableBase
    {
        [GenerateProperty]
        string title = "Prism Generated View Model Example";
    }
}
