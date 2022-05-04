# WPF - View Model Code Generator for PRISM

The free DevExpress MVVM Code Generator helps you avoid boilerplate code in your view model. It supports the following PRISM view model features:

*   Commands

    ```csharp
    // synchronous command
    [GenerateCommand]
    public void SomeMethod (int? commandParameter) => {
        MessageBox.Show(“Simple Command”);
    }

    // asynchronous command
    [GenerateCommand]
    public Task SomeAsyncMethod (int? commandParameter) => {
        return Task.CompletedTask;
    }
    ```

* ObservesCanExecuteProperty parameter

    ```csharp
    [GenerateCommand(ObservesCanExecuteProperty = "CounterLocked")]
    public void UnlockCounter() {
        // ...
    }
    bool CanLockCounter() => !CounterLocked;
    ```

* ObservesProperties parameter

    ```csharp
    [GenerateCommand(ObservesProperties = new string[] { "CounterLocked" })]
    public void LockCounter() {
        // ...
    }
    bool CanLockCounter() => !CounterLocked;
    ```

* IActiveAware interface

    ```csharp
    [GenerateViewModel(ImplementIActiveAware = true)]
    public partial class TabViewModel {
        void OnIsActiveChanged() {
            // ...
        }
    }
    ```

The generator also supports standard view model features, such as automatically generated properties with INotifyPropertyChanged and INotifyPropertyChanging implementation:

```csharp
[GenerateProperty]
bool counterLocked;
```

The following topic lists all supported PRISM features: [Third-party Libraries Support -> Prism Library](https://docs.devexpress.com/WPF/402989/mvvm-framework/viewmodels/compile-time-generated-viewmodels#third-party-libraries-support).