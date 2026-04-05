using System;

class Button
{
    public event EventHandler Clicked;

    public void Click()
    {
        Clicked?.Invoke(this, EventArgs.Empty);
    }
}

class TextBox
{
    private string text = "";

    public event EventHandler<string> TextChanged;

    public string Text
    {
        get { return text; }
        set
        {
            text = value;
            TextChanged?.Invoke(this, text);
        }
    }
}

class Form
{
    private Button button = new Button();
    private TextBox textBox = new TextBox();

    public Form()
    {
        button.Clicked += OnButtonClicked;
        textBox.TextChanged += OnTextChanged;
    }

    void OnButtonClicked(object sender, EventArgs e)
    {
        Console.WriteLine("Кнопка нажата!");
    }

    void OnTextChanged(object sender, string newText)
    {
        Console.WriteLine("Текст изменён: " + newText);
    }

    public void PressButton()
    {
        button.Click();
    }

    public void TypeText(string text)
    {
        textBox.Text = text;
    }
}

class Program
{
    static void Main()
    {
        Form form = new Form();
        form.TypeText("Привет");
        form.TypeText("Привет, мир!");
        form.PressButton();
    }
}
