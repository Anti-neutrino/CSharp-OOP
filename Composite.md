# Шаблони за структуриране на обекти ( Structural Patterns)

## Composite pattern

### Мотивация

* С шаблона Composite pattern може да създаваме йерархия от класове. С него тази група от обекти на йерархията се третира по един и същи начин като един единствен обект. 
* Той се дефинира с рекурсивната дървовидна структура,представяща цялата йерархия.
* Целта е да се използват различни обекти,без значение дали обектите са прости ,или са съставени от други обекти, като се третират по един и съши начин.

### Употреба

* Windows.Forms.Control
* System.Web.UI.Control
* System.Xml.XmlNode

### Пример

```
    abstract class MailReceiver 
    {
        public abstract void SendMail();
    }


    class EmailAddress : MailReceiver
    {
        public override void SendMail() { /*...*/ }
    }

    class GroupOfEmailAddresses : MailReceiver
    {
        private List<MailReceiver> participants;
        public override void SendMail() 
        {
            foreach(var p in participants) 
            {
                p.SendMail();
            }
        }
    }

    static void Main() 
    {
        var rootGroup = new GroupOfEmailAddresses();
        rootGroup.SendMail();
    }


### UML Diagram

![UML Diagram](https://github.com/Anti-neutrino/CSharpProjects/blob/master/Resources/600px-Composite_UML_class_diagram_(fixed).svg.png "UML Diagram")