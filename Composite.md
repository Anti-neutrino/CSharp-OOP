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

![UML Diagram](http://img09.deviantart.net/3496/i/2012/303/b/c/cska_sofia_football_team_wallpaper_by_haxb0x-d5jf2js.png?raw=true)