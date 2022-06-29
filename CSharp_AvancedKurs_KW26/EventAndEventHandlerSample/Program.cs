// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

MyApp app = new MyApp();



public class MyApp
{
    private ProgressBarComponent progressBarComponent;

    private ProgressBarComponent2 progressBarComponent2;

    public MyApp()
    {
        progressBarComponent = new ProgressBarComponent();

        //Methode ProgressBarComponent_MessageEvent arbeitet mit Event ShowPercentChangedEvent zusammen
        progressBarComponent.ShowPercentChangedEvent += ProgressBarComponent_ShowPercentEvent;
        progressBarComponent.MessageEvent += ProgressBarComponent_MessageEvent;
        progressBarComponent.StartProcess();


        progressBarComponent2 = new();
        progressBarComponent2.PercentValueChanged += ProgressBarComponent2_PercentValueChanged;
        progressBarComponent2.ProgressCompleted += ProgressBarComponent2_ProgressCompleted;
        progressBarComponent2.Start();

    }

    private void ProgressBarComponent2_ProgressCompleted(object? sender, EventArgs e)
    {
        PercentFinishArgs percentFinishArgs = (PercentFinishArgs)e;

        Console.WriteLine(percentFinishArgs.Message);
    }

    private void ProgressBarComponent2_PercentValueChanged(object? sender, EventArgs e)
    {
        PercentChangeArgs percentChangeArgs = (PercentChangeArgs)e;

        Console.WriteLine(percentChangeArgs.Percent.ToString()) ;

    }

    private void ProgressBarComponent_MessageEvent(string message)
    {
        Console.WriteLine(message);
    }

    private void ProgressBarComponent_ShowPercentEvent(int percent)
    {
        Console.WriteLine(percent);
    }
}




#region event-delegate

public delegate void ShowPercentValueChangedDelegate(int percent);
public delegate void MessageDelegate(string message);


public class ProgressBarComponent
{
    //Wir wollen Methoden an unseren Delegates von draußen anbinden
    public event ShowPercentValueChangedDelegate ShowPercentChangedEvent; //Wenn ich ShowPercentEvent aufrufe-> erreichen wir eine Methode, die sich dranhängt
    public event MessageDelegate MessageEvent;

    public void StartProcess()
    {
        for(int i = 0; i < 100; i++)
        {
            //fire an event
            //Methode wird aufgerufen die dranhängt -> private void ProgressBarComponent_ShowPercentEvent(int percent)
            
            //null check -> gibt es Methode, die unser Event verwenden möchte
            if (ShowPercentChangedEvent != null)
                ShowPercentChangedEvent(i);
        }

        //fire an event
        //Methode wird aufgerufen die dranhängt -> ProgressBarComponent_ShowPercentEvent(int percent)
        
        if (MessageEvent != null)
            MessageEvent("wird sind fertig");
    }

}

#endregion


#region event handler

public class ProgressBarComponent2
{

    public event EventHandler PercentValueChanged;
    public event EventHandler ProgressCompleted;

    public void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine(i);

            if (PercentValueChanged != null)
                PercentValueChanged(this, new PercentChangeArgs() { Percent = i });
        }


        if (ProgressCompleted != null)
            ProgressCompleted(this, new PercentFinishArgs() { Message = "Sind fertig" });
    }
}

public class PercentChangeArgs : EventArgs
{
    public int Percent { get; set; }
}


public class PercentFinishArgs : EventArgs
{
    public string Message { get; set; }
}


#endregion