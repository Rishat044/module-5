using System;

public interface Document
{
    void Open();
}

public class Report : Document
{
    public void Open()
    {
        Console.WriteLine("Открыть отчет.");
    }
}

public class Resume : Document
{
    public void Open()
    {
        Console.WriteLine("Открыть резюме.");
    }
}

public class Letter : Document
{
    public void Open()
    {
        Console.WriteLine("Открыть письмо.");
    }
}

// Новый класс
public class Invoice : Document
{
    public void Open()
    {
        Console.WriteLine("Открыть счет.");
    }
}

public abstract class DocumentCreator
{
    public abstract Document CreateDocument();
}







public class ReportCreator : DocumentCreator
{
    public override Document CreateDocument()
    {
        return new Report();
    }
}

public class ResumeCreator : DocumentCreator
{
    public override Document CreateDocument()
    {
        return new Resume();
    }
}

public class LetterCreator : DocumentCreator
{
    public override Document CreateDocument()
    {
        return new Letter();
    }
}

public class InvoiceCreator : DocumentCreator
{
    public override Document CreateDocument()
    {
        return new Invoice();
    }
}




public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Выберите тип документа для создания: 1 - Отчет, 2 - Резюме, 3 - Письмо, 4 - Счет");
        string choice = Console.ReadLine();

        DocumentCreator creator = null;

        switch (choice)
        {
            case "1":
                creator = new ReportCreator();
                break;
            case "2":
                creator = new ResumeCreator();
                break;
            case "3":
                creator = new LetterCreator();
                break;
            case "4":
                creator = new InvoiceCreator();
                break;
            default:
                Console.WriteLine("Неправильный выбор.");
                return;
        }

        Document document = creator.CreateDocument();

        document.Open();

        Console.WriteLine("Нажмите любую клавишу для выхода.");
        Console.ReadKey();
    }
}